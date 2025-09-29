//============================================================================//
// システム         : PM.NS
// プログラム名称   : 得意先マスタリモート
// プログラム概要   : 得意先マスタへの読込・書込・削除などを提供します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 10402071-00  作成担当 : 21112
// 作 成 日  2008/04/23  修正内容 : SFTOK01130R をベースにPM.NS用を作成
//
// 管理番号 10402071-00  作成担当 : 23015 森本 大輝
// 作 成 日  2008/09/02  修正内容 : 物理削除機能追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 23012 畠中 啓次朗
// 作 成 日  2009/04/09  修正内容 : 得意先一括登録修正のWrite処理を統合
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2010/09/26  修正内容 : Redmine障害報告 #14483の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/10/28  修正内容 : 業種、職種、地区、銀行区分名称は、ユーザーガイド側で論理削除時に名称を取得しない
//----------------------------------------------------------------------------//
// 管理番号  10970681-00 作成担当：陳健
// 修正日    K2014/02/06 修正内容：前橋京和商会個別 得意先マスタ改良対応
// ---------------------------------------------------------------------------//
// 管理番号  11770021-00 作成担当：梶谷貴士
// 修正日    2021/05/10  修正内容：得意先情報ガイド表示PKG対応
// ---------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note         : 得意先の実データ操作を行うクラスです。</br>
    /// <br>Programmer   : 21112</br>
    /// <br>Date         : 2007.02.14</br>
    /// <br></br>
    /// <br>Update Note  : 2007.05.21　19026　湯山　美樹　Sync対応</br>
    /// <br></br>
    /// <br>Update Note  : DC.NS用に改良売上金額処理区分設定マスタを別リモートで処理する為</br>
    /// <br>               不要メソッドの削除</br>
    /// <br>Programmer   : 22008　長内　数馬</br>
    /// <br>Date         : 2007.08.14</br>
    /// <br></br>
    /// <br>Update Note  : DC.NS用に得意先マスタの変更に伴う修正</br>
    /// <br>Update Note  : 家族構成マスタに対する処理を削除(コメントアウト)</br>
    /// <br>Programmer   : 21112　久保田　誠</br>
    /// <br>Date         : 2007.08.23</br>
    /// <br></br>
    /// <br>Update Note  : ローカルシンク対応</br>
    /// <br>Programmer   : 980081 山田 明友</br>
    /// <br>Date         : 2008.02.07</br>
    /// <br></br>
    /// <br>Update Note  : PM.NS用に改編</br>
    /// <br>Programmer   : 21112</br>
    /// <br>Date         : 2008.04.23</br>
    /// <br></br>
    /// <br>Update Note  : 物理削除処理追加</br>
    /// <br>Programmer   : 23015 森本 大輝</br>
    /// <br>Date         : 2008.09.02</br>
    /// <br></br>
    /// <br>Update Note  : 得意先(変動情報)マスタの更新処理追加</br>
    /// <br>Programmer   : 23012 畠中 啓次朗</br>
    /// <br>Date         : 2008.10.14</br>
    /// <br></br>
    /// <br>Update Note  : 論理削除処理のチェック追加</br>
    /// <br>Update Note  : 得意先(掛率グループ)マスタと得意先(伝票番号)の更新処理追加</br>
    /// <br>Programmer   : 30009 渋谷 大輔</br>
    /// <br>Date         : 2008.11.14</br>
    /// <br></br>
    /// <br>Update Note  : 得意先優先倉庫コードの型を変更(Int32→NChar)</br>
    /// <br>Programmer   : 30009 渋谷 大輔</br>
    /// <br>Date         : 2008.12.01</br>
    /// <br></br>
    /// <br>Update Note  : Searchメソッド追加</br>
    /// <br>Programmer   : 23012 畠中 啓次朗</br>
    /// <br>Date         : 2009.01.19</br>
    /// <br></br>
    /// <br>Update Note  : 合計請求書出力、明細請求書出力、伝票合計請求書出力の更新処理追加</br>
    /// <br>             : 得意先一括修正にも伝票タイプ毎の区分を修正できるようにする</br>
    /// <br>Programmer   : 30531 大矢 睦美</br>
    /// <br>Date         : 2010.01.04</br>
    /// <br></br>
    /// <br>Update Note  : 簡単問合せアカウントグループID 追加</br>
    /// <br>Programmer   : 22008 長内 数馬</br>
    /// <br>Date         : 2010/06/25</br>
    /// <br></br>
    /// <br>Update Note  : 業種、職種、地区、銀行区分名称は、ユーザーガイド側で論理削除時に名称を取得しない</br>
    /// <br>Programmer   : 21024 佐々木 健</br>
    /// <br>Date         : 2010/10/28</br>
    /// <br></br>
    /// <br>Update Note  : 得意先情報関連メモマスタの検索処理、登録処理、更新処理、論理削除処理追加</br>
    /// <br>Programmer   : 陳健</br>
    /// <br>Date         : K2014/02/06</br>
    /// <br></br>
    /// <br>Update Note  : 得意先情報ガイド表示PKG対応にて、得意先情報ガイド表示区分を追加</br>
    /// <br>Programmer   : 梶谷 貴士</br>
    /// <br>Date         : 2021/05/10</br>
    /// </remarks>
    [Serializable]
    public class CustomerDB : RemoteDB, ICustomerInfoDB, IGetSyncdataList
    {
        /// <summary>
        /// 得意先DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public CustomerDB()
            : base("PMKHN09016D", "Broadleaf.Application.Remoting.ParamData.CustomerWork", "CUSTOMERRF")
        {

        }

        // ===================================================================================== //
        // Read関連　パブリックメソッド
        // ===================================================================================== //
        # region 得意先マスタ読み込み処理
        /// <summary>
        /// 得意先マスタ読み込み処理
        /// </summary>
        /// <param name="paraList">CustomSerializeList(得意先マスタ、備考マスタ、家族構成マスタリスト)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コード、得意先コードの得意先を戻します</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public int Read(ref object paraList)
        {
            return this.Read(ConstantManagement.LogicalMode.GetData01, ref paraList);
        }
        # endregion

        # region 得意先マスタ読み込み処理
        /// <summary>
        /// 得意先マスタ読み込み処理
        /// </summary>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コード、得意先コードの得意先を戻します</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public int Read(ConstantManagement.LogicalMode logicalMode, ref object paraList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CustomerWork customerWork = null;

            ArrayList paraCustomList = paraList as ArrayList;

            // オブジェクトの取得(カスタムArray内から検索)
            if (paraCustomList == null)
            {
                base.WriteErrorLog("プログラムエラー。対象パラメータが未指定です", status);
                return status;
            }
            else if (paraCustomList.Count > 0)
            {
                // List内の得意先リストを抽出
                foreach (object obj in paraCustomList)
                {
                    if (customerWork == null)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = obj as CustomerWork;
                        }
                    }
                }
            }

            if (customerWork == null)
            {
                base.WriteErrorLog("プログラムエラー。抽出対象オブジェクトパラメータが未指定です。", status);
                return status;
            }

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            // 各publicメソッドの開始時にコネクション文字列を取得
            // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return status;

            SqlConnection sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            try
            {
                // 得意先マスタ読み込み処理
                status = this.ReadCustomerWork(ref customerWork, ref sqlConnection, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    customSerializeArrayList.Add(customerWork);
                }
            }
            // 例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "得意先マスタの読み込みに失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            paraList = (object)customSerializeArrayList;
            return status;
        }
        # endregion

        # region 得意先マスタ読み込み処理（得意先コード複数指定）
        /// <summary>
        /// 得意先マスタ読み込み処理（得意先コード複数指定）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCodeArray">得意先コード配列</param>
        /// <param name="customerWorkArray">得意先情報クラス配列</param>
        /// <param name="statusArray">ステータス配列</param>
        /// <param name="sqlConnection">ＳＱＬコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コード、得意先コードの得意先を複数件戻します</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public int Read(string enterpriseCode, int[] customerCodeArray, out CustomerWork[] customerWorkArray, out int[] statusArray, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if ((sqlConnection == null) || (customerCodeArray == null) || (customerCodeArray.Length == 0))
            {
                customerWorkArray = new CustomerWork[0];
                statusArray = new Int32[0];
                return status;
            }

            statusArray = new Int32[customerCodeArray.Length];
            customerWorkArray = new CustomerWork[customerCodeArray.Length];

            for (int i = 0; i < customerCodeArray.Length; i++)
            {
                CustomerWork customerWork = new CustomerWork();
                customerWork.EnterpriseCode = enterpriseCode;
                customerWork.CustomerCode = customerCodeArray[i];

                statusArray[i] = this.ReadCustomerWork(ref customerWork, ref sqlConnection, ConstantManagement.LogicalMode.GetData0);
                customerWorkArray[i] = customerWork;
            }

            foreach (int i in statusArray)
            {
                if (i == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }

            return status;
        }
        # endregion

        # region 得意先マスタ存在チェック処理
        /// <summary>
        /// 得意先マスタ存在チェック処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>ステータス</returns>
        public int ExistData(string enterpriseCode, int customerCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 各publicメソッドの開始時にコネクション文字列を取得
            // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return status;

            SqlConnection sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            try
            {
                status = this.ExistCheckProc(enterpriseCode, customerCode, logicalMode, sqlConnection);
            }
            // 例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "得意先マスタ存在チェック処理に失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        # endregion

        // ===================================================================================== //
        // Read関連　プライベートメソッド
        // ===================================================================================== //
        # region 得意先マスタ読み込み処理
        /// <summary>
        /// 得意先マスタ読み込み処理
        /// </summary>
        /// <param name="customerWork">得意先ワーククラス</param>
        /// <param name="sqlConnection">ＳＱＬコネクション</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コード、得意先コードの得意先を戻します</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        private int ReadCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;
                
                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUST.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CUST.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CUST.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CUST.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSUBCODERF" + Environment.NewLine;
                sqlText += " ,CUST.NAMERF" + Environment.NewLine;
                sqlText += " ,CUST.NAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.HONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,CUST.KANARF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMECODERF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.CORPORATEDIVCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.JOBTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,CUST.POSTNORF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS3RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS4RF" + Environment.NewLine;
                sqlText += " ,CUST.HOMETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.PORTABLETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.HOMEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OTHERSTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MAINCONTACTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SEARCHTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE6RF" + Environment.NewLine;                       
                sqlText += " ,CUST.BILLOUTPUTCODERF" + Environment.NewLine;                
                sqlText += " ,CUST.BILLOUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTCONDRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMCODERF" + Environment.NewLine;
                sqlText += " ,CUST.TRANSSTOPDATERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.MAINSENDMAILADDRCDRF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += " ,CUST.OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTAGENTCHGDATERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCEPTWHOLESALERF" + Environment.NewLine;
                sqlText += " ,CUST.CREDITMNGCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DEPODELCODERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                sqlText += " ,CUST.PURECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO1RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO2RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO3RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CARMNGDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DEFSALESSLIPCDRF" + Environment.NewLine;
                sqlText += " ,CUST.LAVORRATERANKRF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLPRNRF" + Environment.NewLine;
                sqlText += " ,CUST.DEPOBANKCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTWAREHOUSECDRF" + Environment.NewLine;
                sqlText += " ,CUST.QRCODEPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE1RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE2RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE3RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE4RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE5RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE6RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE7RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE8RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE9RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE10RF" + Environment.NewLine;
                // ADD 2009.02.05 >>>
                sqlText += " ,CUST.SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTIMATEPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.UOESLIPPRTDIVRF" + Environment.NewLine;
                // ADD 2009.02.05 <<<
                // --- ADD 2009/04/06 ------>>>
                sqlText += " ,CUST.RECEIPTOUTPUTCODERF" + Environment.NewLine;
                // --- ADD 2009/04/06 ------<<<
                // --- ADD 2009.05.20 ------>>>
                sqlText += " ,CUST.CUSTOMEREPCODERF " + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSECCODERF " + Environment.NewLine;
                sqlText += " ,CUST.ONLINEKINDDIVRF " + Environment.NewLine;
                // --- ADD 2009.05.20 ------<<<
                // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                sqlText += " ,CUST.TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                sqlText += " ,CUST.SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;  // ADD 2010/06/25

                sqlText += " ,AREA.GUIDENAMERF AS SALESAREANAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAMERF AS CLAIMNAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAME2RF AS CLAIMNAME2" + Environment.NewLine;
                sqlText += " ,CLIM.CUSTOMERSNMRF AS CLAIMSNM" + Environment.NewLine;
                sqlText += " ,CAGT.NAMERF AS CUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,OAGT.NAMERF AS OLDCUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,CLSC.SECTIONGUIDENMRF AS CLAIMSECTIONNAME" + Environment.NewLine;
                sqlText += " ,DBNK.GUIDENAMERF AS DEPOBANKNAME" + Environment.NewLine;
                sqlText += " ,WARE.WAREHOUSENAMERF AS CUSTWAREHOUSENAME" + Environment.NewLine;
                sqlText += " ,MGSC.SECTIONGUIDENMRF AS MNGSECTIONNAME" + Environment.NewLine;
                sqlText += " ,JBTP.GUIDENAMERF AS JOBTYPENAME" + Environment.NewLine;
                sqlText += " ,BSTP.GUIDENAMERF AS BUSINESSTYPENAME" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF AS CUST" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN CUSTOMERRF AS CLIM" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLIM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMCODERF = CLIM.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS CAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERAGENTCDRF = CAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS OAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = OAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.OLDCUSTOMERAGENTCDRF = OAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS CLSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMSECTIONCODERF = CLSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS MGSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = MGSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.MNGSECTIONCODERF = MGSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = WARE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTWAREHOUSECDRF = WARE.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS AREA" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = AREA.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.SALESAREACODERF = AREA.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND AREA.USERGUIDEDIVCDRF = 21  -- 販売エリア区分" + Environment.NewLine;
                sqlText += "    AND AREA.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS DBNK" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = DBNK.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.DEPOBANKCODERF = DBNK.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND DBNK.USERGUIDEDIVCDRF = 46  -- 銀行区分" + Environment.NewLine;
                sqlText += "    AND DBNK.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS JBTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = JBTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.JOBTYPECODERF = JBTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND JBTP.USERGUIDEDIVCDRF = 34  -- 職種区分" + Environment.NewLine;
                sqlText += "    AND JBTP.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS BSTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = BSTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.BUSINESSTYPECODERF = BSTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND BSTP.USERGUIDEDIVCDRF = 33  -- 業種区分" + Environment.NewLine;
                sqlText += "    AND BSTP.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUST.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                # endregion

                // Selectコマンドの生成
                SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection);

                // Parameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.ReaderToCustomerWork(ref myReader, ref customerWork);

                    // 論理削除区分チェック処理
                    status = this.LogicalDeleteCodeCheck(customerWork.LogicalDeleteCode, logicalMode);
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "得意先マスタの読み込みに失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }

            return status;
        }
        # endregion

        // ADD 2009.01.19 >>>
        // ===================================================================================== //
        // Search関連　パブリックメソッド
        // ===================================================================================== //
        # region 得意先マスタ読み込み処理（得意先コード複数指定）
        /// <summary>
        /// 得意先マスタ読み込み処理（得意先コード複数指定）
        /// </summary>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コード、得意先コードの親得意先と子得意先を複数件戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2009.01.19</br>
        /// </remarks>       
        public int Search(ConstantManagement.LogicalMode logicalMode, ref object paraList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CustomerWork customerWork = null;

            ArrayList paraCustomList = paraList as ArrayList;

            // オブジェクトの取得(カスタムArray内から検索)
            if (paraCustomList == null)
            {
                base.WriteErrorLog("プログラムエラー。対象パラメータが未指定です", status);
                return status;
            }
            else if (paraCustomList.Count > 0)
            {
                // List内の得意先リストを抽出
                foreach (object obj in paraCustomList)
                {
                    if (customerWork == null)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = obj as CustomerWork;
                        }
                    }
                }
            }

            if (customerWork == null)
            {
                base.WriteErrorLog("プログラムエラー。抽出対象オブジェクトパラメータが未指定です。", status);
                return status;
            }

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            // 各publicメソッドの開始時にコネクション文字列を取得
            // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return status;

            SqlConnection sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            try
            {
                for (int i = 0; i < paraCustomList.Count; i++)
                {
                    customerWork = paraCustomList[i] as CustomerWork;

                    // 得意先マスタ読み込み処理
                    status = this.SearchCustomerWork(ref customSerializeArrayList, ref customerWork, ref sqlConnection, logicalMode);
                }
            }
            // 例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "得意先マスタの読み込みに失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            paraList = (object)customSerializeArrayList;
            return status;
        }
        # endregion

        // ===================================================================================== //
        // Search関連　プライベートメソッド
        // ===================================================================================== //
        # region 得意先マスタ読み込み処理
        /// <summary>
        /// 得意先マスタ読み込み処理
        /// </summary>
        /// <param name="ResultcustomerWork">抽出結果</param>
        /// <param name="customerWork">得意先ワーククラス</param>
        /// <param name="sqlConnection">ＳＱＬコネクション</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コード、得意先コードの親得意先と子得意先を戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2009.01.19</br>
        /// </remarks>
        private int SearchCustomerWork(ref CustomSerializeArrayList ResultcustomerWork, ref CustomerWork customerWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUST.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CUST.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CUST.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CUST.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSUBCODERF" + Environment.NewLine;
                sqlText += " ,CUST.NAMERF" + Environment.NewLine;
                sqlText += " ,CUST.NAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.HONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,CUST.KANARF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMECODERF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.CORPORATEDIVCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.JOBTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,CUST.POSTNORF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS3RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS4RF" + Environment.NewLine;
                sqlText += " ,CUST.HOMETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.PORTABLETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.HOMEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OTHERSTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MAINCONTACTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SEARCHTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE6RF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTCONDRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMCODERF" + Environment.NewLine;
                sqlText += " ,CUST.TRANSSTOPDATERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.MAINSENDMAILADDRCDRF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += " ,CUST.OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTAGENTCHGDATERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCEPTWHOLESALERF" + Environment.NewLine;
                sqlText += " ,CUST.CREDITMNGCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DEPODELCODERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                sqlText += " ,CUST.PURECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO1RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO2RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO3RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CARMNGDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DEFSALESSLIPCDRF" + Environment.NewLine;
                sqlText += " ,CUST.LAVORRATERANKRF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLPRNRF" + Environment.NewLine;
                sqlText += " ,CUST.DEPOBANKCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTWAREHOUSECDRF" + Environment.NewLine;
                sqlText += " ,CUST.QRCODEPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE1RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE2RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE3RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE4RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE5RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE6RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE7RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE8RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE9RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE10RF" + Environment.NewLine;
                // ADD 2009.02.05 >>>
                sqlText += " ,CUST.SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTIMATEPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.UOESLIPPRTDIVRF" + Environment.NewLine;
                // ADD 2009.02.05 <<<
                // --- ADD 2009/04/06 ------>>>
                sqlText += " ,CUST.RECEIPTOUTPUTCODERF" + Environment.NewLine;
                // --- ADD 2009/04/06 ------<<<
                // --- ADD 2009.05.20 ------>>>
                sqlText += " ,CUST.CUSTOMEREPCODERF " + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSECCODERF " + Environment.NewLine;
                sqlText += " ,CUST.ONLINEKINDDIVRF " + Environment.NewLine;
                // --- ADD 2009.05.20 ------<<<
                // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                sqlText += " ,CUST.TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                sqlText += " ,CUST.SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;  // ADD 2010/06/25
                sqlText += " ,AREA.GUIDENAMERF AS SALESAREANAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAMERF AS CLAIMNAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAME2RF AS CLAIMNAME2" + Environment.NewLine;
                sqlText += " ,CLIM.CUSTOMERSNMRF AS CLAIMSNM" + Environment.NewLine;
                sqlText += " ,CAGT.NAMERF AS CUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,OAGT.NAMERF AS OLDCUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,CLSC.SECTIONGUIDENMRF AS CLAIMSECTIONNAME" + Environment.NewLine;
                sqlText += " ,DBNK.GUIDENAMERF AS DEPOBANKNAME" + Environment.NewLine;
                sqlText += " ,WARE.WAREHOUSENAMERF AS CUSTWAREHOUSENAME" + Environment.NewLine;
                sqlText += " ,MGSC.SECTIONGUIDENMRF AS MNGSECTIONNAME" + Environment.NewLine;
                sqlText += " ,JBTP.GUIDENAMERF AS JOBTYPENAME" + Environment.NewLine;
                sqlText += " ,BSTP.GUIDENAMERF AS BUSINESSTYPENAME" + Environment.NewLine;           
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF AS CUST" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN CUSTOMERRF AS CLIM" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLIM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMCODERF = CLIM.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS CAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERAGENTCDRF = CAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS OAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = OAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.OLDCUSTOMERAGENTCDRF = OAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS CLSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMSECTIONCODERF = CLSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS MGSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = MGSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.MNGSECTIONCODERF = MGSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = WARE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTWAREHOUSECDRF = WARE.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS AREA" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = AREA.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.SALESAREACODERF = AREA.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND AREA.USERGUIDEDIVCDRF = 21  -- 販売エリア区分" + Environment.NewLine;
                sqlText += "    AND AREA.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS DBNK" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = DBNK.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.DEPOBANKCODERF = DBNK.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND DBNK.USERGUIDEDIVCDRF = 46  -- 銀行区分" + Environment.NewLine;
                sqlText += "    AND DBNK.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS JBTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = JBTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.JOBTYPECODERF = JBTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND JBTP.USERGUIDEDIVCDRF = 34  -- 職種区分" + Environment.NewLine;
                sqlText += "    AND JBTP.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS BSTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = BSTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.BUSINESSTYPECODERF = BSTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND BSTP.USERGUIDEDIVCDRF = 33  -- 業種区分" + Environment.NewLine;
                sqlText += "    AND BSTP.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUST.CLAIMCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                # endregion

                // Selectコマンドの生成
                SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection);

                // Parameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                //if (myReader.Read())
                //{
                //    this.ReaderToCustomerWork(ref myReader, ref customerWork);

                //    // 論理削除区分チェック処理
                //    status = this.LogicalDeleteCodeCheck(customerWork.LogicalDeleteCode, logicalMode);
                //}
                while (myReader.Read())
                {
                    customerWork = new CustomerWork();
                    this.ReaderToCustomerWork(ref myReader, ref customerWork);
                    ResultcustomerWork.Add(customerWork);
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "得意先マスタの読み込みに失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }

            return status;
        }
        # endregion
        // ADD 2009.01.19 <<<

        // ===================================================================================== //
        // Write関連　パブリックメソッド
        // ===================================================================================== //
        # region 得意先マスタ登録処理 public int Write(ref object paraList, out ArrayList duplicationItemList)
        /// <summary>
        /// 得意先マスタ登録処理
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <param name="duplicationItemList">重複エラー時の重複項目</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタを登録、更新します</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public int Write(ref object paraList, out ArrayList duplicationItemList)
        {
            return this.Write(ref paraList, out duplicationItemList, 0);
        }
        # endregion

        # region 得意先マスタ登録処理 public int Write(ref object paraList, out ArrayList duplicationItemList, int carMngNo)
        /// <summary>
        /// 得意先マスタ登録処理
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <param name="duplicationItemList">重複エラー時の重複項目</param>
        /// <param name="carMngNo">得意先と車両を同時登録する際の車両管理番号</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタを登録、更新します</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public int Write(ref object paraList, out ArrayList duplicationItemList, int carMngNo)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			string retMsg = "";
			duplicationItemList = new ArrayList();

			int customerCode = 0;
			CustomerWork customerWork = null;

			ArrayList paraCustomList = paraList as ArrayList;


			// オブジェクトの取得(カスタムArray内から検索)
			if (paraCustomList == null)
			{
				base.WriteErrorLog("プログラムエラー。対象パラメータが未指定です", status);
				return status;
			}
			else if (paraCustomList.Count > 0)
			{
				// List内の得意先・備考・家族構成リストを抽出
				foreach (object obj in paraCustomList)
				{
					if (customerWork == null)
					{
						if (obj is CustomerWork)
						{
							customerWork = obj as CustomerWork;

							// 得意先コードと企業コードを待避
							if (customerCode == 0)
							{
								customerCode = customerWork.CustomerCode;
							}
						}
					}
				}
			}

            if (customerWork == null)
			{
				base.WriteErrorLog("プログラムエラー。抽出対象オブジェクトパラメータが未指定です。", status);
				return status;
			}

			CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
			ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;

			try
			{
				// 登録前の得意先情報用
				CustomerWork customerWorkBef = new CustomerWork();
                // --- ADD 2008.10.14 得意先マスタ(変動情報)書き込み処理 >>>
                
                //if (customerWork.CreditMngCode == 1)
                
                    CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                    CustomerChangeWork customerChangeWork = new CustomerChangeWork();
                    int CusChangestatus = 0;
                
                // --- ADD 2008.10.14 <<<
                // 2009.02.20
                ArrayList WriteCustomList = new ArrayList();
                ArrayList changeWorkLogicalDeleteList = new ArrayList();                
                ArrayList changeWorkWriteList = new ArrayList();
               

				// 排他Lock
				//ctrlExclsvOdAcs = new ControlExclusiveOrderAccess();
				//status = this.ControlExclusiveProc(0,ref ctrlExclsvOdAcs,ref customerWork, ref retMsg);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{

					// 各publicメソッドの開始時にコネクション文字列を取得
					// メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
					SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
					string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
					if (connectionText == null || connectionText == "") return status;

					sqlConnection = new SqlConnection(connectionText);
					sqlConnection.Open();

                    // トランザクションスタート
					sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

					// ログイン情報取得クラスをインスタンス化
					ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();
                    changeWorkLogicalDeleteList = new ArrayList();
                    changeWorkWriteList = new ArrayList();

                    // ADD 2009.01.19 >>>
                    for (int i = 0; i < paraCustomList.Count; i++)
                    {
                        customerWork = paraCustomList[i] as CustomerWork;
                        customerCode = customerWork.CustomerCode;
                    // ADD 2009.01.19 <<<
                        // ================================================================================= //
                        // 得意先更新前情報取得
                        // ================================================================================= //
                        if (customerWork != null)
                        {
                            if ((customerWork.EnterpriseCode.Trim() != "") && (customerWork.CustomerCode != 0))
                            {
                                // 2009.02.20
                                // Read用コネクションをインスタンス化
                                SqlConnection sqlConnection_read = new SqlConnection(connectionText);
                                sqlConnection_read.Open();

                                customerWorkBef.EnterpriseCode = customerWork.EnterpriseCode;
                                customerWorkBef.CustomerCode = customerWork.CustomerCode;

                                // 得意先情報取得（登録前）
                                status = this.ReadCustomerWork(ref customerWorkBef, ref sqlConnection_read, ConstantManagement.LogicalMode.GetData0);

                                // --- ADD 2008.10.14 得意先マスタ(変動情報)書き込み処理 >>>
                                if (customerWork.CreditMngCode == 1)
                                {
                                    customerChangeWork = new CustomerChangeWork();
                                    customerChangeWork.EnterpriseCode = customerWork.EnterpriseCode;
                                    customerChangeWork.CustomerCode = customerWork.CustomerCode;
                                    // 得意先マスタ(変動情報)取得
                                    CusChangestatus = customerChangeDB.ReadProc(ref customerChangeWork, 0, ref sqlConnection_read);
                                }
                                // ADD 2008.10.14 <<<      

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    // 該当データ無しの場合は正常とする
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                sqlConnection_read.Close();
                            }
                        }

                        // ================================================================================= //
                        // 得意先コードの採番
                        // ================================================================================= //
                        // 得意先コードが入っていない場合のみ
                        if (customerCode == 0)
                        {
                            // 入力拠点コードを退避
                            string sectionCode = customerWork.InpSectionCode;

                            // 得意先コード採番処理
                            status = this.CreateCustomerCode(customerWork.EnterpriseCode, sectionCode, out customerCode, out retMsg, ref sqlConnection, ref sqlTransaction);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (customerWork.CustomerCode != 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }

                                if (customerWork != null)
                                {
                                    if (customerWork.CustomerCode == 0)
                                    {
                                        customerWork.CustomerCode = customerCode;
                                    }

                                    if (customerWork.ClaimCode == 0)
                                    {
                                        customerWork.ClaimCode = customerCode;
                                    }

                                }
                            }
                            else
                            {
                                duplicationItemList.Add(retMsg);
                            }
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 得意先マスタ書き込みリスト作成
                            WriteCustomList.Add(customerWork);

                            // 得意先マスタ(変動情報)書き込みリスト作成
                            // 与信管理=1:する　且つ　親得意先
                            if ((customerWork.CreditMngCode == 1)&&(customerWork.ClaimCode == customerWork.CustomerCode))
                            {
                                if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 復旧処理
                                    // ADD 2009/04/09 >>>
                                    if (customerWork.WriteDiv == 1) // 0:得意先マスタ 1:得意先一括修正
                                    {
                                        customerChangeWork.CreditMoney = customerWork.CreditMoney;
                                        customerChangeWork.WarningCreditMoney = customerWork.WarningCreditMoney;
                                        customerChangeWork.PrsntAccRecBalance = customerWork.PrsntAccRecBalance;
                                    }
                                    // ADD 2009/04/09 <<<
                                    changeWorkLogicalDeleteList.Add(customerChangeWork);
                                }
                                if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 新規作成処理
                                    // ADD 2009/04/09 >>>
                                    if (customerWork.WriteDiv == 1) // 0:得意先マスタ 1:得意先一括修正
                                    {
                                        customerChangeWork.CreditMoney = customerWork.CreditMoney;
                                        customerChangeWork.WarningCreditMoney = customerWork.WarningCreditMoney;
                                        customerChangeWork.PrsntAccRecBalance = customerWork.PrsntAccRecBalance;
                                    }
                                    // ADD 2009/04/09 <<<
                                    changeWorkWriteList.Add(customerChangeWork);
                                }
                            }

                        }
                    // ADD 2009.01.19 >>>
                    }
                    // ADD 2009.01.19 <<<

                    // 得意先マスタ書込
                    for (int i = 0; i < WriteCustomList.Count; i++)
                    {
                        customerWork = WriteCustomList[i] as CustomerWork;
                        status = this.WriteCustomerWork(ref customerWork, ref sqlConnection, ref sqlTransaction, ref duplicationItemList);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            customSerializeArrayList.Add((CustomerWork)customerWork);
                        }
                    }
                    // << 得意先マスタ(変動情報)書き込み処理 >>
                    if (changeWorkLogicalDeleteList.Count > 0)
                    {
                        if (customerWork.WriteDiv == 1) // 0:得意先マスタ 1:得意先一括修正
                        {
                            // 更新処理
                            customerChangeDB.WriteProc(ref changeWorkLogicalDeleteList, ref sqlConnection, ref sqlTransaction);
                        }
                        else
                        {
                            // 復旧処理
                            customerChangeDB.LogicalDeleteProc(ref changeWorkLogicalDeleteList, 1, ref sqlConnection, ref sqlTransaction);
                        }
                    }
                    if (changeWorkWriteList.Count > 0)
                    {
                        // 新規作成処理
                        customerChangeDB.WriteProc(ref changeWorkWriteList, ref sqlConnection, ref sqlTransaction);
                    }
                    
                        //// ================================================================================= //
                        //// 得意先データ書き込み処理
                        //// ================================================================================= //
                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    if (customerWork != null)
                        //    {
                        //        status = this.WriteCustomerWork(ref customerWork, ref sqlConnection, ref sqlTransaction, ref duplicationItemList);

                            
                        //        // --- ADD 2008.10.14 得意先マスタ(変動情報)書き込み処理 >>>
                        //        if (customerWork.CreditMngCode == 1)
                        //        {
                        //            // 復旧処理
                        //            if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //            {
                        //                //パラメータのキャスト
                        //                ArrayList changeWorkparaList = new ArrayList();
                        //                changeWorkparaList.Add(customerChangeWork);
                        //                CusChangestatus = customerChangeDB.LogicalDeleteProc(ref changeWorkparaList, 1, ref sqlConnection, ref sqlTransaction);
                        //            }

                        //            // 新規作成処理
                        //            if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        //            {
                        //                //パラメータのキャスト
                        //                ArrayList changeWorkparaList = new ArrayList();
                        //                changeWorkparaList.Add(customerChangeWork);
                        //                CusChangestatus = customerChangeDB.WriteProc(ref changeWorkparaList, ref sqlConnection, ref sqlTransaction);
                        //            }
                        //        }
                        //        // --- ADD 2008.10.14 <<<

                        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //        {
                        //            customSerializeArrayList.Add((CustomerWork)customerWork);
                        //        }

                        //    }
                        //}
                    
					// コミット
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						sqlTransaction.Commit();
					}
				}
				else
				{
					if (retMsg.Trim() != "")
					{
						duplicationItemList.Add(retMsg);
					}
				}
			}
			// 例外処理
			catch(SqlException ex)
			{
				status = base.WriteSQLErrorLog(ex, "得意先マスタの書き込みに失敗しました。", ex.Number);
			}
			catch(Exception ex)
			{
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
			}
			finally
			{
				// 排他Lock破棄
				//this.ControlExclusiveProc(1, ref ctrlExclsvOdAcs, ref customerWork, ref retMsg);

				// トランザクション破棄
				if (sqlTransaction != null) sqlTransaction.Dispose();

				// コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
			}

			paraList = (object)customSerializeArrayList;
            return status;
		}
        # endregion

        // ===================================================================================== //
        // Write関連　プライベートメソッド
        // ===================================================================================== //
        # region 得意先データ登録処理
        /// <summary>
        /// 得意先データ登録処理
        /// </summary>
        /// <param name="customerWork">登録受得意先報</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="duplicationItemList">重複エラー時の重複項目</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先情報を登録、更新します</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2005.07.11</br>
        /// </remarks>
        private int WriteCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref ArrayList duplicationItemList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;

            try
            {
                // Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, CUSTOMERCODERF FROM CUSTOMERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction))
                {
                    // Parameterオブジェクトのクリア
                    sqlCommand.Parameters.Clear();

                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomercode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                    findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                    sqlCommand.CommandTimeout = 3600;
                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                        if (_updateDateTime != customerWork.UpdateDateTime)
                        {
                            // 新規登録で該当データ有りの場合には重複
                            if (customerWork.UpdateDateTime == DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            // 既存データで更新日時違いの場合には排他
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }

                            if ((myReader != null) && (!myReader.IsClosed))
                            {
                                myReader.Close();
                            }

                            return status;
                        }

                        string sqlText = string.Empty;

                        // ADD 2009/04/09 >>>
                        if (customerWork.WriteDiv == 0) // 0:得意先マスタ 1:得意先一括修正 
                        {
                        // ADD 2009/04/09 <<<
                            # region [UPDATE文]
                            sqlText += "UPDATE CUSTOMERRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSUBCODERF = @CUSTOMERSUBCODE" + Environment.NewLine;
                            sqlText += " ,NAMERF = @NAME" + Environment.NewLine;
                            sqlText += " ,NAME2RF = @NAME2" + Environment.NewLine;
                            sqlText += " ,HONORIFICTITLERF = @HONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,KANARF = @KANA" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSNMRF = @CUSTOMERSNM" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMECODERF = @OUTPUTNAMECODE" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMERF = @OUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,CORPORATEDIVCODERF = @CORPORATEDIVCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERATTRIBUTEDIVRF = @CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,JOBTYPECODERF = @JOBTYPECODE" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF = @BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF = @SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,POSTNORF = @POSTNO" + Environment.NewLine;
                            sqlText += " ,ADDRESS1RF = @ADDRESS1" + Environment.NewLine;
                            sqlText += " ,ADDRESS3RF = @ADDRESS3" + Environment.NewLine;
                            sqlText += " ,ADDRESS4RF = @ADDRESS4" + Environment.NewLine;
                            sqlText += " ,HOMETELNORF = @HOMETELNO" + Environment.NewLine;
                            sqlText += " ,OFFICETELNORF = @OFFICETELNO" + Environment.NewLine;
                            sqlText += " ,PORTABLETELNORF = @PORTABLETELNO" + Environment.NewLine;
                            sqlText += " ,HOMEFAXNORF = @HOMEFAXNO" + Environment.NewLine;
                            sqlText += " ,OFFICEFAXNORF = @OFFICEFAXNO" + Environment.NewLine;
                            sqlText += " ,OTHERSTELNORF = @OTHERSTELNO" + Environment.NewLine;
                            sqlText += " ,MAINCONTACTCODERF = @MAINCONTACTCODE" + Environment.NewLine;
                            sqlText += " ,SEARCHTELNORF = @SEARCHTELNO" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF = @MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF = @INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE1RF = @CUSTANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE2RF = @CUSTANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE3RF = @CUSTANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE4RF = @CUSTANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE5RF = @CUSTANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE6RF = @CUSTANALYSCODE6" + Environment.NewLine;                            
                            sqlText += " ,BILLOUTPUTCODERF = @BILLOUTPUTCODE" + Environment.NewLine;                          
                            sqlText += " ,BILLOUTPUTNAMERF = @BILLOUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,TOTALDAYRF = @TOTALDAY" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYCODERF = @COLLECTMONEYCODE" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYNAMERF = @COLLECTMONEYNAME" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYDAYRF = @COLLECTMONEYDAY" + Environment.NewLine;
                            sqlText += " ,COLLECTCONDRF = @COLLECTCOND" + Environment.NewLine;
                            sqlText += " ,COLLECTSIGHTRF = @COLLECTSIGHT" + Environment.NewLine;
                            sqlText += " ,CLAIMCODERF = @CLAIMCODE" + Environment.NewLine;
                            sqlText += " ,TRANSSTOPDATERF = @TRANSSTOPDATE" + Environment.NewLine;
                            sqlText += " ,DMOUTCODERF = @DMOUTCODE" + Environment.NewLine;
                            sqlText += " ,DMOUTNAMERF = @DMOUTNAME" + Environment.NewLine;
                            sqlText += " ,MAINSENDMAILADDRCDRF = @MAINSENDMAILADDRCD" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE1RF = @MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF = @MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF = @MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF = @MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME1RF = @MAILSENDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF = @MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF = @MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF = @MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF = @MAILSENDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME2RF = @MAILSENDNAME2" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTCDRF = @CUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,BILLCOLLECTERCDRF = @BILLCOLLECTERCD" + Environment.NewLine;
                            sqlText += " ,OLDCUSTOMERAGENTCDRF = @OLDCUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,CUSTAGENTCHGDATERF = @CUSTAGENTCHGDATE" + Environment.NewLine;
                            sqlText += " ,ACCEPTWHOLESALERF = @ACCEPTWHOLESALE" + Environment.NewLine;
                            sqlText += " ,CREDITMNGCODERF = @CREDITMNGCODE" + Environment.NewLine;
                            sqlText += " ,DEPODELCODERF = @DEPODELCODE" + Environment.NewLine;
                            sqlText += " ,ACCRECDIVCDRF = @ACCRECDIVCD" + Environment.NewLine;
                            sqlText += " ,CUSTSLIPNOMNGCDRF = @CUSTSLIPNOMNGCD" + Environment.NewLine;
                            sqlText += " ,PURECODERF = @PURECODE" + Environment.NewLine;
                            sqlText += " ,CUSTCTAXLAYREFCDRF = @CUSTCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,CONSTAXLAYMETHODRF = @CONSTAXLAYMETHOD" + Environment.NewLine;
                            sqlText += " ,TOTALAMOUNTDISPWAYCDRF = @TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                            sqlText += " ,TOTALAMNTDSPWAYREFRF = @TOTALAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO1RF = @ACCOUNTNOINFO1" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO2RF = @ACCOUNTNOINFO2" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO3RF = @ACCOUNTNOINFO3" + Environment.NewLine;
                            sqlText += " ,SALESUNPRCFRCPROCCDRF = @SALESUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,SALESMONEYFRCPROCCDRF = @SALESMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,SALESCNSTAXFRCPROCCDRF = @SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSLIPNODIVRF = @CUSTOMERSLIPNODIV" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF = @NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTRF = @CUSTOMERAGENT" + Environment.NewLine;
                            sqlText += " ,CLAIMSECTIONCODERF = @CLAIMSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,CARMNGDIVCDRF = @CARMNGDIVCD" + Environment.NewLine;
                            sqlText += " ,BILLPARTSNOPRTCDRF = @BILLPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,DELIPARTSNOPRTCDRF = @DELIPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,DEFSALESSLIPCDRF = @DEFSALESSLIPCD" + Environment.NewLine;
                            sqlText += " ,LAVORRATERANKRF = @LAVORRATERANK" + Environment.NewLine;
                            sqlText += " ,SLIPTTLPRNRF = @SLIPTTLPRN" + Environment.NewLine;
                            sqlText += " ,DEPOBANKCODERF = @DEPOBANKCODE" + Environment.NewLine;
                            sqlText += " ,CUSTWAREHOUSECDRF = @CUSTWAREHOUSECD" + Environment.NewLine;
                            sqlText += " ,QRCODEPRTCDRF = @QRCODEPRTCD" + Environment.NewLine;
                            sqlText += " ,DELIHONORIFICTTLRF = @DELIHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,BILLHONORIFICTTLRF = @BILLHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,ESTMHONORIFICTTLRF = @ESTMHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,RECTHONORIFICTTLRF = @RECTHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,DELIHONORTTLPRTDIVRF = @DELIHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,BILLHONORTTLPRTDIVRF = @BILLHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,ESTMHONORTTLPRTDIVRF = @ESTMHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,RECTHONORTTLPRTDIVRF = @RECTHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,NOTE1RF = @NOTE1" + Environment.NewLine;
                            sqlText += " ,NOTE2RF = @NOTE2" + Environment.NewLine;
                            sqlText += " ,NOTE3RF = @NOTE3" + Environment.NewLine;
                            sqlText += " ,NOTE4RF = @NOTE4" + Environment.NewLine;
                            sqlText += " ,NOTE5RF = @NOTE5" + Environment.NewLine;
                            sqlText += " ,NOTE6RF = @NOTE6" + Environment.NewLine;
                            sqlText += " ,NOTE7RF = @NOTE7" + Environment.NewLine;
                            sqlText += " ,NOTE8RF = @NOTE8" + Environment.NewLine;
                            sqlText += " ,NOTE9RF = @NOTE9" + Environment.NewLine;
                            sqlText += " ,NOTE10RF = @NOTE10" + Environment.NewLine;
                            // ADD 2009.02.05 >>>
                            sqlText += " ,SALESSLIPPRTDIVRF = @SALESSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,SHIPMSLIPPRTDIVRF = @SHIPMSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,ACPODRRSLIPPRTDIVRF = @ACPODRRSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,ESTIMATEPRTDIVRF = @ESTIMATEPRTDIV" + Environment.NewLine;
                            sqlText += " ,UOESLIPPRTDIVRF = @UOESLIPPRTDIV" + Environment.NewLine;
                            // ADD 2009.02.05 <<<

                            // --- ADD 2009/04/06 ------>>>
                            sqlText += " ,RECEIPTOUTPUTCODERF = @RECEIPTOUTPUTCODE" + Environment.NewLine;
                            // --- ADD 2009/04/06 ------<<<
                            // --- ADD 2009/05/20 ------>>>
                            sqlText += " , CUSTOMEREPCODERF = @CUSTOMEREPCODE" + Environment.NewLine;
                            sqlText += " , CUSTOMERSECCODERF = @CUSTOMERSECCODE" + Environment.NewLine;
                            sqlText += " , ONLINEKINDDIVRF = @ONLINEKINDDIV" + Environment.NewLine;
                            // --- ADD 2009/05/20 ------>>>
                            // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                            sqlText += " , TOTALBILLOUTPUTDIVRF = @TOTALBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " , DETAILBILLOUTPUTCODERF = @DETAILBILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " , SLIPTTLBILLOUTPUTDIVRF = @SLIPTTLBILLOUTPUTDIV" + Environment.NewLine;
                            // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                            sqlText += " , SIMPLINQACNTACNTGRIDRF = @SIMPLINQACNTACNTGRID" + Environment.NewLine; // ADD 2010/06/25
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            # endregion
                        // ADD 2009/04/09 >>>
                        }
                        else if (customerWork.WriteDiv == 1)  // 0:得意先マスタ 1:得意先一括修正 
                        {
                            # region [UPDATE文]
                            sqlText += "UPDATE CUSTOMERRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSUBCODERF = @CUSTOMERSUBCODE" + Environment.NewLine;
                            sqlText += " ,NAMERF = @NAME" + Environment.NewLine;
                            sqlText += " ,NAME2RF = @NAME2" + Environment.NewLine;
                            sqlText += " ,HONORIFICTITLERF = @HONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,KANARF = @KANA" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSNMRF = @CUSTOMERSNM" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMECODERF = @OUTPUTNAMECODE" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMERF = @OUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,CORPORATEDIVCODERF = @CORPORATEDIVCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERATTRIBUTEDIVRF = @CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,JOBTYPECODERF = @JOBTYPECODE" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF = @BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF = @SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,POSTNORF = @POSTNO" + Environment.NewLine;
                            sqlText += " ,ADDRESS1RF = @ADDRESS1" + Environment.NewLine;
                            sqlText += " ,ADDRESS3RF = @ADDRESS3" + Environment.NewLine;
                            sqlText += " ,ADDRESS4RF = @ADDRESS4" + Environment.NewLine;
                            sqlText += " ,HOMETELNORF = @HOMETELNO" + Environment.NewLine;
                            sqlText += " ,OFFICETELNORF = @OFFICETELNO" + Environment.NewLine;
                            sqlText += " ,PORTABLETELNORF = @PORTABLETELNO" + Environment.NewLine;
                            sqlText += " ,HOMEFAXNORF = @HOMEFAXNO" + Environment.NewLine;
                            sqlText += " ,OFFICEFAXNORF = @OFFICEFAXNO" + Environment.NewLine;
                            sqlText += " ,OTHERSTELNORF = @OTHERSTELNO" + Environment.NewLine;
                            sqlText += " ,MAINCONTACTCODERF = @MAINCONTACTCODE" + Environment.NewLine;
                            sqlText += " ,SEARCHTELNORF = @SEARCHTELNO" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF = @MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF = @INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE1RF = @CUSTANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE2RF = @CUSTANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE3RF = @CUSTANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE4RF = @CUSTANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE5RF = @CUSTANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE6RF = @CUSTANALYSCODE6" + Environment.NewLine;                            
                            sqlText += " ,BILLOUTPUTCODERF = @BILLOUTPUTCODE" + Environment.NewLine;                        
                            sqlText += " ,BILLOUTPUTNAMERF = @BILLOUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,TOTALDAYRF = @TOTALDAY" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYCODERF = @COLLECTMONEYCODE" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYNAMERF = @COLLECTMONEYNAME" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYDAYRF = @COLLECTMONEYDAY" + Environment.NewLine;
                            sqlText += " ,COLLECTCONDRF = @COLLECTCOND" + Environment.NewLine;
                            sqlText += " ,COLLECTSIGHTRF = @COLLECTSIGHT" + Environment.NewLine;
                            sqlText += " ,CLAIMCODERF = @CLAIMCODE" + Environment.NewLine;
                            sqlText += " ,TRANSSTOPDATERF = @TRANSSTOPDATE" + Environment.NewLine;
                            sqlText += " ,DMOUTCODERF = @DMOUTCODE" + Environment.NewLine;
                            sqlText += " ,DMOUTNAMERF = @DMOUTNAME" + Environment.NewLine;
                            sqlText += " ,MAINSENDMAILADDRCDRF = @MAINSENDMAILADDRCD" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE1RF = @MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF = @MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF = @MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF = @MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME1RF = @MAILSENDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF = @MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF = @MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF = @MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF = @MAILSENDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME2RF = @MAILSENDNAME2" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTCDRF = @CUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,BILLCOLLECTERCDRF = @BILLCOLLECTERCD" + Environment.NewLine;
                            sqlText += " ,OLDCUSTOMERAGENTCDRF = @OLDCUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,CUSTAGENTCHGDATERF = @CUSTAGENTCHGDATE" + Environment.NewLine;
                            sqlText += " ,ACCEPTWHOLESALERF = @ACCEPTWHOLESALE" + Environment.NewLine;
                            sqlText += " ,CREDITMNGCODERF = @CREDITMNGCODE" + Environment.NewLine;
                            sqlText += " ,DEPODELCODERF = @DEPODELCODE" + Environment.NewLine;
                            sqlText += " ,ACCRECDIVCDRF = @ACCRECDIVCD" + Environment.NewLine;
                            sqlText += " ,CUSTSLIPNOMNGCDRF = @CUSTSLIPNOMNGCD" + Environment.NewLine;
                            sqlText += " ,PURECODERF = @PURECODE" + Environment.NewLine;
                            sqlText += " ,CUSTCTAXLAYREFCDRF = @CUSTCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,CONSTAXLAYMETHODRF = @CONSTAXLAYMETHOD" + Environment.NewLine;
                            sqlText += " ,TOTALAMOUNTDISPWAYCDRF = @TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                            sqlText += " ,TOTALAMNTDSPWAYREFRF = @TOTALAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO1RF = @ACCOUNTNOINFO1" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO2RF = @ACCOUNTNOINFO2" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO3RF = @ACCOUNTNOINFO3" + Environment.NewLine;
                            sqlText += " ,SALESUNPRCFRCPROCCDRF = @SALESUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,SALESMONEYFRCPROCCDRF = @SALESMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,SALESCNSTAXFRCPROCCDRF = @SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSLIPNODIVRF = @CUSTOMERSLIPNODIV" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF = @NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTRF = @CUSTOMERAGENT" + Environment.NewLine;
                            sqlText += " ,CLAIMSECTIONCODERF = @CLAIMSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,CARMNGDIVCDRF = @CARMNGDIVCD" + Environment.NewLine;
                            sqlText += " ,BILLPARTSNOPRTCDRF = @BILLPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,DELIPARTSNOPRTCDRF = @DELIPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,DEFSALESSLIPCDRF = @DEFSALESSLIPCD" + Environment.NewLine;
                            sqlText += " ,LAVORRATERANKRF = @LAVORRATERANK" + Environment.NewLine;
                            sqlText += " ,SLIPTTLPRNRF = @SLIPTTLPRN" + Environment.NewLine;
                            sqlText += " ,DEPOBANKCODERF = @DEPOBANKCODE" + Environment.NewLine;
                            sqlText += " ,CUSTWAREHOUSECDRF = @CUSTWAREHOUSECD" + Environment.NewLine;
                            sqlText += " ,QRCODEPRTCDRF = @QRCODEPRTCD" + Environment.NewLine;
                            sqlText += " ,DELIHONORIFICTTLRF = @DELIHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,BILLHONORIFICTTLRF = @BILLHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,ESTMHONORIFICTTLRF = @ESTMHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,RECTHONORIFICTTLRF = @RECTHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,DELIHONORTTLPRTDIVRF = @DELIHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,BILLHONORTTLPRTDIVRF = @BILLHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,ESTMHONORTTLPRTDIVRF = @ESTMHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,RECTHONORTTLPRTDIVRF = @RECTHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,NOTE1RF = @NOTE1" + Environment.NewLine;
                            sqlText += " ,NOTE2RF = @NOTE2" + Environment.NewLine;
                            sqlText += " ,NOTE3RF = @NOTE3" + Environment.NewLine;
                            sqlText += " ,NOTE4RF = @NOTE4" + Environment.NewLine;
                            sqlText += " ,NOTE5RF = @NOTE5" + Environment.NewLine;
                            sqlText += " ,NOTE6RF = @NOTE6" + Environment.NewLine;
                            sqlText += " ,NOTE7RF = @NOTE7" + Environment.NewLine;
                            sqlText += " ,NOTE8RF = @NOTE8" + Environment.NewLine;
                            sqlText += " ,NOTE9RF = @NOTE9" + Environment.NewLine;
                            sqlText += " ,NOTE10RF = @NOTE10" + Environment.NewLine;
                            // --- ADD 2009/04/07 -------->>>
                            sqlText += " ,RECEIPTOUTPUTCODERF = @RECEIPTOUTPUTCODE" + Environment.NewLine;
                            // --- ADD 2009/04/07 --------<<<
                            // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                            sqlText += " ,TOTALBILLOUTPUTDIVRF = @TOTALBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,DETAILBILLOUTPUTCODERF = @DETAILBILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,SLIPTTLBILLOUTPUTDIVRF = @SLIPTTLBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,SALESSLIPPRTDIVRF = @SALESSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,SHIPMSLIPPRTDIVRF = @SHIPMSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,ACPODRRSLIPPRTDIVRF = @ACPODRRSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,ESTIMATEPRTDIVRF = @ESTIMATEPRTDIV" + Environment.NewLine;
                            sqlText += " ,UOESLIPPRTDIVRF = @UOESLIPPRTDIV" + Environment.NewLine;
                            // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                            sqlText += " ,SIMPLINQACNTACNTGRIDRF = @SIMPLINQACNTACNTGRID" + Environment.NewLine;  // ADD 2010/06/25
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            # endregion
                        }
                        // ADD 2009/04/09 <<<
                        sqlCommand.CommandText = sqlText;

                        // KEYコマンドを再設定
                        findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (customerWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                            if ((myReader != null) && (!myReader.IsClosed))
                            {
                                myReader.Close();
                            }

                            return status;
                        }

                        // 新規作成時のSQL文を生成

                        string sqlText = string.Empty;
                        // ADD 2009/04/09 >>>
                        if (customerWork.WriteDiv == 0) // 0:得意先マスタ 1:得意先一括修正
                        {
                        // ADD 2009/04/09 <<<
                            # region [INSERT文]
                            sqlText += "INSERT INTO CUSTOMERRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSUBCODERF" + Environment.NewLine;
                            sqlText += " ,NAMERF" + Environment.NewLine;
                            sqlText += " ,NAME2RF" + Environment.NewLine;
                            sqlText += " ,HONORIFICTITLERF" + Environment.NewLine;
                            sqlText += " ,KANARF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMECODERF" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMERF" + Environment.NewLine;
                            sqlText += " ,CORPORATEDIVCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                            sqlText += " ,JOBTYPECODERF" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                            sqlText += " ,POSTNORF" + Environment.NewLine;
                            sqlText += " ,ADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,ADDRESS3RF" + Environment.NewLine;
                            sqlText += " ,ADDRESS4RF" + Environment.NewLine;
                            sqlText += " ,HOMETELNORF" + Environment.NewLine;
                            sqlText += " ,OFFICETELNORF" + Environment.NewLine;
                            sqlText += " ,PORTABLETELNORF" + Environment.NewLine;
                            sqlText += " ,HOMEFAXNORF" + Environment.NewLine;
                            sqlText += " ,OFFICEFAXNORF" + Environment.NewLine;
                            sqlText += " ,OTHERSTELNORF" + Environment.NewLine;
                            sqlText += " ,MAINCONTACTCODERF" + Environment.NewLine;
                            sqlText += " ,SEARCHTELNORF" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE1RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE2RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE3RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE4RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE5RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE6RF" + Environment.NewLine;                            
                            sqlText += " ,BILLOUTPUTCODERF" + Environment.NewLine;                  
                            sqlText += " ,BILLOUTPUTNAMERF" + Environment.NewLine;       
                            sqlText += " ,TOTALDAYRF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYCODERF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYNAMERF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYDAYRF" + Environment.NewLine;
                            sqlText += " ,COLLECTCONDRF" + Environment.NewLine;
                            sqlText += " ,COLLECTSIGHTRF" + Environment.NewLine;
                            sqlText += " ,CLAIMCODERF" + Environment.NewLine;
                            sqlText += " ,TRANSSTOPDATERF" + Environment.NewLine;
                            sqlText += " ,DMOUTCODERF" + Environment.NewLine;
                            sqlText += " ,DMOUTNAMERF" + Environment.NewLine;
                            sqlText += " ,MAINSENDMAILADDRCDRF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME2RF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,BILLCOLLECTERCDRF" + Environment.NewLine;
                            sqlText += " ,OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTAGENTCHGDATERF" + Environment.NewLine;
                            sqlText += " ,ACCEPTWHOLESALERF" + Environment.NewLine;
                            sqlText += " ,CREDITMNGCODERF" + Environment.NewLine;
                            sqlText += " ,DEPODELCODERF" + Environment.NewLine;
                            sqlText += " ,ACCRECDIVCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                            sqlText += " ,PURECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                            sqlText += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlText += " ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                            sqlText += " ,TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                            sqlText += " ,SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTRF" + Environment.NewLine;
                            sqlText += " ,CLAIMSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,CARMNGDIVCDRF" + Environment.NewLine;
                            sqlText += " ,BILLPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DELIPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DEFSALESSLIPCDRF" + Environment.NewLine;
                            sqlText += " ,LAVORRATERANKRF" + Environment.NewLine;
                            sqlText += " ,SLIPTTLPRNRF" + Environment.NewLine;
                            sqlText += " ,DEPOBANKCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTWAREHOUSECDRF" + Environment.NewLine;
                            sqlText += " ,QRCODEPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DELIHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,BILLHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,ESTMHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,RECTHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,NOTE1RF" + Environment.NewLine;
                            sqlText += " ,NOTE2RF" + Environment.NewLine;
                            sqlText += " ,NOTE3RF" + Environment.NewLine;
                            sqlText += " ,NOTE4RF" + Environment.NewLine;
                            sqlText += " ,NOTE5RF" + Environment.NewLine;
                            sqlText += " ,NOTE6RF" + Environment.NewLine;
                            sqlText += " ,NOTE7RF" + Environment.NewLine;
                            sqlText += " ,NOTE8RF" + Environment.NewLine;
                            sqlText += " ,NOTE9RF" + Environment.NewLine;
                            sqlText += " ,NOTE10RF" + Environment.NewLine;
                            // ADD 2009.02.05 >>> 
                            sqlText += " ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ESTIMATEPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,UOESLIPPRTDIVRF" + Environment.NewLine;
                            // ADD 2009.02.05 <<<

                            // --- ADD 2009/04/06 ------>>>
                            sqlText += " ,RECEIPTOUTPUTCODERF" + Environment.NewLine;
                            // --- ADD 2009/04/06 ------<<<
                            // --- ADD 2009/05/20 ------>>>
                            sqlText += " ,CUSTOMEREPCODERF " + Environment.NewLine;
                            sqlText += " ,CUSTOMERSECCODERF " + Environment.NewLine;
                            sqlText += " ,ONLINEKINDDIVRF " + Environment.NewLine;
                            // --- ADD 2009/05/20 ------<<<
                            // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                            sqlText += " ,TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                            sqlText += " ,DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                            sqlText += " ,SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;                            
                            // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                            sqlText += " ,SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;  // ADD 2010/06/25
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSUBCODE" + Environment.NewLine;
                            sqlText += " ,@NAME" + Environment.NewLine;
                            sqlText += " ,@NAME2" + Environment.NewLine;
                            sqlText += " ,@HONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,@KANA" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSNM" + Environment.NewLine;
                            sqlText += " ,@OUTPUTNAMECODE" + Environment.NewLine;
                            sqlText += " ,@OUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,@CORPORATEDIVCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,@JOBTYPECODE" + Environment.NewLine;
                            sqlText += " ,@BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,@SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,@POSTNO" + Environment.NewLine;
                            sqlText += " ,@ADDRESS1" + Environment.NewLine;
                            sqlText += " ,@ADDRESS3" + Environment.NewLine;
                            sqlText += " ,@ADDRESS4" + Environment.NewLine;
                            sqlText += " ,@HOMETELNO" + Environment.NewLine;
                            sqlText += " ,@OFFICETELNO" + Environment.NewLine;
                            sqlText += " ,@PORTABLETELNO" + Environment.NewLine;
                            sqlText += " ,@HOMEFAXNO" + Environment.NewLine;
                            sqlText += " ,@OFFICEFAXNO" + Environment.NewLine;
                            sqlText += " ,@OTHERSTELNO" + Environment.NewLine;
                            sqlText += " ,@MAINCONTACTCODE" + Environment.NewLine;
                            sqlText += " ,@SEARCHTELNO" + Environment.NewLine;
                            sqlText += " ,@MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE6" + Environment.NewLine;                                                       
                            sqlText += " ,@BILLOUTPUTCODE" + Environment.NewLine;                     
                            sqlText += " ,@BILLOUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,@TOTALDAY" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYCODE" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYNAME" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYDAY" + Environment.NewLine;
                            sqlText += " ,@COLLECTCOND" + Environment.NewLine;
                            sqlText += " ,@COLLECTSIGHT" + Environment.NewLine;
                            sqlText += " ,@CLAIMCODE" + Environment.NewLine;
                            sqlText += " ,@TRANSSTOPDATE" + Environment.NewLine;
                            sqlText += " ,@DMOUTCODE" + Environment.NewLine;
                            sqlText += " ,@DMOUTNAME" + Environment.NewLine;
                            sqlText += " ,@MAINSENDMAILADDRCD" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDNAME2" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,@BILLCOLLECTERCD" + Environment.NewLine;
                            sqlText += " ,@OLDCUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,@CUSTAGENTCHGDATE" + Environment.NewLine;
                            sqlText += " ,@ACCEPTWHOLESALE" + Environment.NewLine;
                            sqlText += " ,@CREDITMNGCODE" + Environment.NewLine;
                            sqlText += " ,@DEPODELCODE" + Environment.NewLine;
                            sqlText += " ,@ACCRECDIVCD" + Environment.NewLine;
                            sqlText += " ,@CUSTSLIPNOMNGCD" + Environment.NewLine;
                            sqlText += " ,@PURECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                            sqlText += " ,@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                            sqlText += " ,@TOTALAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO1" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO2" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO3" + Environment.NewLine;
                            sqlText += " ,@SALESUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@SALESMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSLIPNODIV" + Environment.NewLine;
                            sqlText += " ,@NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERAGENT" + Environment.NewLine;
                            sqlText += " ,@CLAIMSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@CARMNGDIVCD" + Environment.NewLine;
                            sqlText += " ,@BILLPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,@DELIPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,@DEFSALESSLIPCD" + Environment.NewLine;
                            sqlText += " ,@LAVORRATERANK" + Environment.NewLine;
                            sqlText += " ,@SLIPTTLPRN" + Environment.NewLine;
                            sqlText += " ,@DEPOBANKCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTWAREHOUSECD" + Environment.NewLine;
                            sqlText += " ,@QRCODEPRTCD" + Environment.NewLine;
                            sqlText += " ,@DELIHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@BILLHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@ESTMHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@RECTHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@DELIHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@BILLHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@ESTMHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@RECTHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@NOTE1" + Environment.NewLine;
                            sqlText += " ,@NOTE2" + Environment.NewLine;
                            sqlText += " ,@NOTE3" + Environment.NewLine;
                            sqlText += " ,@NOTE4" + Environment.NewLine;
                            sqlText += " ,@NOTE5" + Environment.NewLine;
                            sqlText += " ,@NOTE6" + Environment.NewLine;
                            sqlText += " ,@NOTE7" + Environment.NewLine;
                            sqlText += " ,@NOTE8" + Environment.NewLine;
                            sqlText += " ,@NOTE9" + Environment.NewLine;
                            sqlText += " ,@NOTE10" + Environment.NewLine;
                            // ADD 2009.02.05 >>>
                            sqlText += " ,@SALESSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,@SHIPMSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,@ACPODRRSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,@ESTIMATEPRTDIV" + Environment.NewLine;
                            sqlText += " ,@UOESLIPPRTDIV" + Environment.NewLine;
                            // ADD 2009.02.05 <<<

                            // --- ADD 2009/04/06 ------>>>
                            sqlText += " ,@RECEIPTOUTPUTCODE" + Environment.NewLine;
                            // --- ADD 2009/04/06 ------<<<
                            // --- ADD 2009/05/20 ------>>>
                            sqlText += " ,@CUSTOMEREPCODE " + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSECCODE " + Environment.NewLine;
                            sqlText += " ,@ONLINEKINDDIV " + Environment.NewLine;
                            // --- ADD 2009/05/20 ------<<<
                            // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                            sqlText += " ,@TOTALBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,@DETAILBILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@SLIPTTLBILLOUTPUTDIV" + Environment.NewLine;
                            // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                            sqlText += " ,@SIMPLINQACNTACNTGRID" + Environment.NewLine;  // ADD 20101/06/25
                            sqlText += ")" + Environment.NewLine;
                            # endregion
                        // ADD 2009/04/09 >>>
                        }
                        else if (customerWork.WriteDiv == 1) // 0:得意先マスタ 1:得意先一括修正
                        {
                            # region [INSERT文]
                            sqlText += "INSERT INTO CUSTOMERRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSUBCODERF" + Environment.NewLine;
                            sqlText += " ,NAMERF" + Environment.NewLine;
                            sqlText += " ,NAME2RF" + Environment.NewLine;
                            sqlText += " ,HONORIFICTITLERF" + Environment.NewLine;
                            sqlText += " ,KANARF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMECODERF" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMERF" + Environment.NewLine;
                            sqlText += " ,CORPORATEDIVCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                            sqlText += " ,JOBTYPECODERF" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                            sqlText += " ,POSTNORF" + Environment.NewLine;
                            sqlText += " ,ADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,ADDRESS3RF" + Environment.NewLine;
                            sqlText += " ,ADDRESS4RF" + Environment.NewLine;
                            sqlText += " ,HOMETELNORF" + Environment.NewLine;
                            sqlText += " ,OFFICETELNORF" + Environment.NewLine;
                            sqlText += " ,PORTABLETELNORF" + Environment.NewLine;
                            sqlText += " ,HOMEFAXNORF" + Environment.NewLine;
                            sqlText += " ,OFFICEFAXNORF" + Environment.NewLine;
                            sqlText += " ,OTHERSTELNORF" + Environment.NewLine;
                            sqlText += " ,MAINCONTACTCODERF" + Environment.NewLine;
                            sqlText += " ,SEARCHTELNORF" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE1RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE2RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE3RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE4RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE5RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE6RF" + Environment.NewLine;                                                  
                            sqlText += " ,BILLOUTPUTCODERF" + Environment.NewLine;                           
                            sqlText += " ,BILLOUTPUTNAMERF" + Environment.NewLine;
                            sqlText += " ,TOTALDAYRF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYCODERF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYNAMERF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYDAYRF" + Environment.NewLine;
                            sqlText += " ,COLLECTCONDRF" + Environment.NewLine;
                            sqlText += " ,COLLECTSIGHTRF" + Environment.NewLine;
                            sqlText += " ,CLAIMCODERF" + Environment.NewLine;
                            sqlText += " ,TRANSSTOPDATERF" + Environment.NewLine;
                            sqlText += " ,DMOUTCODERF" + Environment.NewLine;
                            sqlText += " ,DMOUTNAMERF" + Environment.NewLine;
                            sqlText += " ,MAINSENDMAILADDRCDRF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME2RF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,BILLCOLLECTERCDRF" + Environment.NewLine;
                            sqlText += " ,OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTAGENTCHGDATERF" + Environment.NewLine;
                            sqlText += " ,ACCEPTWHOLESALERF" + Environment.NewLine;
                            sqlText += " ,CREDITMNGCODERF" + Environment.NewLine;
                            sqlText += " ,DEPODELCODERF" + Environment.NewLine;
                            sqlText += " ,ACCRECDIVCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                            sqlText += " ,PURECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                            sqlText += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlText += " ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                            sqlText += " ,TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                            sqlText += " ,SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTRF" + Environment.NewLine;
                            sqlText += " ,CLAIMSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,CARMNGDIVCDRF" + Environment.NewLine;
                            sqlText += " ,BILLPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DELIPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DEFSALESSLIPCDRF" + Environment.NewLine;
                            sqlText += " ,LAVORRATERANKRF" + Environment.NewLine;
                            sqlText += " ,SLIPTTLPRNRF" + Environment.NewLine;
                            sqlText += " ,DEPOBANKCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTWAREHOUSECDRF" + Environment.NewLine;
                            sqlText += " ,QRCODEPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DELIHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,BILLHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,ESTMHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,RECTHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,NOTE1RF" + Environment.NewLine;
                            sqlText += " ,NOTE2RF" + Environment.NewLine;
                            sqlText += " ,NOTE3RF" + Environment.NewLine;
                            sqlText += " ,NOTE4RF" + Environment.NewLine;
                            sqlText += " ,NOTE5RF" + Environment.NewLine;
                            sqlText += " ,NOTE6RF" + Environment.NewLine;
                            sqlText += " ,NOTE7RF" + Environment.NewLine;
                            sqlText += " ,NOTE8RF" + Environment.NewLine;
                            sqlText += " ,NOTE9RF" + Environment.NewLine;
                            sqlText += " ,NOTE10RF" + Environment.NewLine;
                            // --- ADD 2009/04/07 -------->>>
                            sqlText += " ,RECEIPTOUTPUTCODERF" + Environment.NewLine;
                            // --- ADD 2009/04/07 --------<<<
                            // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                            sqlText += " ,TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                            sqlText += " ,DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                            sqlText += " ,SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                            
                            sqlText += " ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ESTIMATEPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,UOESLIPPRTDIVRF" + Environment.NewLine;
                            // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                            sqlText += " ,SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;  // ADD 2010/06/25
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSUBCODE" + Environment.NewLine;
                            sqlText += " ,@NAME" + Environment.NewLine;
                            sqlText += " ,@NAME2" + Environment.NewLine;
                            sqlText += " ,@HONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,@KANA" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSNM" + Environment.NewLine;
                            sqlText += " ,@OUTPUTNAMECODE" + Environment.NewLine;
                            sqlText += " ,@OUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,@CORPORATEDIVCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,@JOBTYPECODE" + Environment.NewLine;
                            sqlText += " ,@BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,@SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,@POSTNO" + Environment.NewLine;
                            sqlText += " ,@ADDRESS1" + Environment.NewLine;
                            sqlText += " ,@ADDRESS3" + Environment.NewLine;
                            sqlText += " ,@ADDRESS4" + Environment.NewLine;
                            sqlText += " ,@HOMETELNO" + Environment.NewLine;
                            sqlText += " ,@OFFICETELNO" + Environment.NewLine;
                            sqlText += " ,@PORTABLETELNO" + Environment.NewLine;
                            sqlText += " ,@HOMEFAXNO" + Environment.NewLine;
                            sqlText += " ,@OFFICEFAXNO" + Environment.NewLine;
                            sqlText += " ,@OTHERSTELNO" + Environment.NewLine;
                            sqlText += " ,@MAINCONTACTCODE" + Environment.NewLine;
                            sqlText += " ,@SEARCHTELNO" + Environment.NewLine;
                            sqlText += " ,@MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE6" + Environment.NewLine;
                            sqlText += " ,@BILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@BILLOUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,@TOTALDAY" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYCODE" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYNAME" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYDAY" + Environment.NewLine;
                            sqlText += " ,@COLLECTCOND" + Environment.NewLine;
                            sqlText += " ,@COLLECTSIGHT" + Environment.NewLine;
                            sqlText += " ,@CLAIMCODE" + Environment.NewLine;
                            sqlText += " ,@TRANSSTOPDATE" + Environment.NewLine;
                            sqlText += " ,@DMOUTCODE" + Environment.NewLine;
                            sqlText += " ,@DMOUTNAME" + Environment.NewLine;
                            sqlText += " ,@MAINSENDMAILADDRCD" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDNAME2" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,@BILLCOLLECTERCD" + Environment.NewLine;
                            sqlText += " ,@OLDCUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,@CUSTAGENTCHGDATE" + Environment.NewLine;
                            sqlText += " ,@ACCEPTWHOLESALE" + Environment.NewLine;
                            sqlText += " ,@CREDITMNGCODE" + Environment.NewLine;
                            sqlText += " ,@DEPODELCODE" + Environment.NewLine;
                            sqlText += " ,@ACCRECDIVCD" + Environment.NewLine;
                            sqlText += " ,@CUSTSLIPNOMNGCD" + Environment.NewLine;
                            sqlText += " ,@PURECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                            sqlText += " ,@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                            sqlText += " ,@TOTALAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO1" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO2" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO3" + Environment.NewLine;
                            sqlText += " ,@SALESUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@SALESMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSLIPNODIV" + Environment.NewLine;
                            sqlText += " ,@NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERAGENT" + Environment.NewLine;
                            sqlText += " ,@CLAIMSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@CARMNGDIVCD" + Environment.NewLine;
                            sqlText += " ,@BILLPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,@DELIPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,@DEFSALESSLIPCD" + Environment.NewLine;
                            sqlText += " ,@LAVORRATERANK" + Environment.NewLine;
                            sqlText += " ,@SLIPTTLPRN" + Environment.NewLine;
                            sqlText += " ,@DEPOBANKCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTWAREHOUSECD" + Environment.NewLine;
                            sqlText += " ,@QRCODEPRTCD" + Environment.NewLine;
                            sqlText += " ,@DELIHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@BILLHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@ESTMHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@RECTHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@DELIHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@BILLHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@ESTMHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@RECTHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@NOTE1" + Environment.NewLine;
                            sqlText += " ,@NOTE2" + Environment.NewLine;
                            sqlText += " ,@NOTE3" + Environment.NewLine;
                            sqlText += " ,@NOTE4" + Environment.NewLine;
                            sqlText += " ,@NOTE5" + Environment.NewLine;
                            sqlText += " ,@NOTE6" + Environment.NewLine;
                            sqlText += " ,@NOTE7" + Environment.NewLine;
                            sqlText += " ,@NOTE8" + Environment.NewLine;
                            sqlText += " ,@NOTE9" + Environment.NewLine;
                            sqlText += " ,@NOTE10" + Environment.NewLine;
                            // --- ADD 2009/04/07 -------->>>
                            sqlText += " ,@RECEIPTOUTPUTCODE" + Environment.NewLine;
                            // --- ADD 2009/04/07 --------<<<
                            // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                            sqlText += " ,@TOTALBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,@DETAILBILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@SLIPTTLBILLOUTPUTDIV" + Environment.NewLine;

                            sqlText += " ,@SALESSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@ESTIMATEPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@UOESLIPPRTDIVRF" + Environment.NewLine;
                            // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                            sqlText += " ,@SIMPLINQACNTACNTGRID" + Environment.NewLine;  // ADD 2010/06/25
                            sqlText += ")" + Environment.NewLine;
                            # endregion

                        }
                        // ADD 2009/04/09 <<<
                        sqlCommand.CommandText = sqlText;

                        // 登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                    }

                    // ADD 2009/04/09 >>>
                    if (customerWork.WriteDiv == 0) // 0:得意先マスタ 1:得意先一括修正                    
                    {
                    // ADD 2009/04/09 <<<
                        # region Parameterオブジェクトの作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCustomerSubCode = sqlCommand.Parameters.Add("@CUSTOMERSUBCODE", SqlDbType.NVarChar);
                        SqlParameter paraName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar);
                        SqlParameter paraName2 = sqlCommand.Parameters.Add("@NAME2", SqlDbType.NVarChar);
                        SqlParameter paraHonorificTitle = sqlCommand.Parameters.Add("@HONORIFICTITLE", SqlDbType.NVarChar);
                        SqlParameter paraKana = sqlCommand.Parameters.Add("@KANA", SqlDbType.NVarChar);
                        SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                        SqlParameter paraOutputNameCode = sqlCommand.Parameters.Add("@OUTPUTNAMECODE", SqlDbType.Int);
                        SqlParameter paraOutputName = sqlCommand.Parameters.Add("@OUTPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraCorporateDivCode = sqlCommand.Parameters.Add("@CORPORATEDIVCODE", SqlDbType.Int);
                        SqlParameter paraCustomerAttributeDiv = sqlCommand.Parameters.Add("@CUSTOMERATTRIBUTEDIV", SqlDbType.Int);
                        SqlParameter paraJobTypeCode = sqlCommand.Parameters.Add("@JOBTYPECODE", SqlDbType.Int);
                        SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                        SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                        SqlParameter paraPostNo = sqlCommand.Parameters.Add("@POSTNO", SqlDbType.NVarChar);
                        SqlParameter paraAddress1 = sqlCommand.Parameters.Add("@ADDRESS1", SqlDbType.NVarChar);
                        SqlParameter paraAddress3 = sqlCommand.Parameters.Add("@ADDRESS3", SqlDbType.NVarChar);
                        SqlParameter paraAddress4 = sqlCommand.Parameters.Add("@ADDRESS4", SqlDbType.NVarChar);
                        SqlParameter paraHomeTelNo = sqlCommand.Parameters.Add("@HOMETELNO", SqlDbType.NVarChar);
                        SqlParameter paraOfficeTelNo = sqlCommand.Parameters.Add("@OFFICETELNO", SqlDbType.NVarChar);
                        SqlParameter paraPortableTelNo = sqlCommand.Parameters.Add("@PORTABLETELNO", SqlDbType.NVarChar);
                        SqlParameter paraHomeFaxNo = sqlCommand.Parameters.Add("@HOMEFAXNO", SqlDbType.NVarChar);
                        SqlParameter paraOfficeFaxNo = sqlCommand.Parameters.Add("@OFFICEFAXNO", SqlDbType.NVarChar);
                        SqlParameter paraOthersTelNo = sqlCommand.Parameters.Add("@OTHERSTELNO", SqlDbType.NVarChar);
                        SqlParameter paraMainContactCode = sqlCommand.Parameters.Add("@MAINCONTACTCODE", SqlDbType.Int);
                        SqlParameter paraSearchTelNo = sqlCommand.Parameters.Add("@SEARCHTELNO", SqlDbType.NChar);
                        SqlParameter paraMngSectionCode = sqlCommand.Parameters.Add("@MNGSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInpSectionCode = sqlCommand.Parameters.Add("@INPSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCustAnalysCode1 = sqlCommand.Parameters.Add("@CUSTANALYSCODE1", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode2 = sqlCommand.Parameters.Add("@CUSTANALYSCODE2", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode3 = sqlCommand.Parameters.Add("@CUSTANALYSCODE3", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode4 = sqlCommand.Parameters.Add("@CUSTANALYSCODE4", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode5 = sqlCommand.Parameters.Add("@CUSTANALYSCODE5", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode6 = sqlCommand.Parameters.Add("@CUSTANALYSCODE6", SqlDbType.Int);                                         
                        SqlParameter paraBillOutputCode = sqlCommand.Parameters.Add("@BILLOUTPUTCODE", SqlDbType.Int);                   
                        SqlParameter paraBillOutputName = sqlCommand.Parameters.Add("@BILLOUTPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@TOTALDAY", SqlDbType.Int);
                        SqlParameter paraCollectMoneyCode = sqlCommand.Parameters.Add("@COLLECTMONEYCODE", SqlDbType.Int);
                        SqlParameter paraCollectMoneyName = sqlCommand.Parameters.Add("@COLLECTMONEYNAME", SqlDbType.NVarChar);
                        SqlParameter paraCollectMoneyDay = sqlCommand.Parameters.Add("@COLLECTMONEYDAY", SqlDbType.Int);
                        SqlParameter paraCollectCond = sqlCommand.Parameters.Add("@COLLECTCOND", SqlDbType.Int);
                        SqlParameter paraCollectSight = sqlCommand.Parameters.Add("@COLLECTSIGHT", SqlDbType.Int);
                        SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                        SqlParameter paraTransStopDate = sqlCommand.Parameters.Add("@TRANSSTOPDATE", SqlDbType.Int);
                        SqlParameter paraDmOutCode = sqlCommand.Parameters.Add("@DMOUTCODE", SqlDbType.Int);
                        SqlParameter paraDmOutName = sqlCommand.Parameters.Add("@DMOUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraMainSendMailAddrCd = sqlCommand.Parameters.Add("@MAINSENDMAILADDRCD", SqlDbType.Int);
                        SqlParameter paraMailAddrKindCode1 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE1", SqlDbType.Int);
                        SqlParameter paraMailAddrKindName1 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME1", SqlDbType.NVarChar);
                        SqlParameter paraMailAddress1 = sqlCommand.Parameters.Add("@MAILADDRESS1", SqlDbType.NVarChar);
                        SqlParameter paraMailSendCode1 = sqlCommand.Parameters.Add("@MAILSENDCODE1", SqlDbType.Int);
                        SqlParameter paraMailSendName1 = sqlCommand.Parameters.Add("@MAILSENDNAME1", SqlDbType.NVarChar);
                        SqlParameter paraMailAddrKindCode2 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE2", SqlDbType.Int);
                        SqlParameter paraMailAddrKindName2 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME2", SqlDbType.NVarChar);
                        SqlParameter paraMailAddress2 = sqlCommand.Parameters.Add("@MAILADDRESS2", SqlDbType.NVarChar);
                        SqlParameter paraMailSendCode2 = sqlCommand.Parameters.Add("@MAILSENDCODE2", SqlDbType.Int);
                        SqlParameter paraMailSendName2 = sqlCommand.Parameters.Add("@MAILSENDNAME2", SqlDbType.NVarChar);
                        SqlParameter paraCustomerAgentCd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCD", SqlDbType.NChar);
                        SqlParameter paraBillCollecterCd = sqlCommand.Parameters.Add("@BILLCOLLECTERCD", SqlDbType.NChar);
                        SqlParameter paraOldCustomerAgentCd = sqlCommand.Parameters.Add("@OLDCUSTOMERAGENTCD", SqlDbType.NChar);
                        SqlParameter paraCustAgentChgDate = sqlCommand.Parameters.Add("@CUSTAGENTCHGDATE", SqlDbType.Int);
                        SqlParameter paraAcceptWholeSale = sqlCommand.Parameters.Add("@ACCEPTWHOLESALE", SqlDbType.Int);
                        SqlParameter paraCreditMngCode = sqlCommand.Parameters.Add("@CREDITMNGCODE", SqlDbType.Int);
                        SqlParameter paraDepoDelCode = sqlCommand.Parameters.Add("@DEPODELCODE", SqlDbType.Int);
                        SqlParameter paraAccRecDivCd = sqlCommand.Parameters.Add("@ACCRECDIVCD", SqlDbType.Int);
                        SqlParameter paraCustSlipNoMngCd = sqlCommand.Parameters.Add("@CUSTSLIPNOMNGCD", SqlDbType.Int);
                        SqlParameter paraPureCode = sqlCommand.Parameters.Add("@PURECODE", SqlDbType.Int);
                        SqlParameter paraCustCTaXLayRefCd = sqlCommand.Parameters.Add("@CUSTCTAXLAYREFCD", SqlDbType.Int);
                        SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                        SqlParameter paraTotalAmountDispWayCd = sqlCommand.Parameters.Add("@TOTALAMOUNTDISPWAYCD", SqlDbType.Int);
                        SqlParameter paraTotalAmntDspWayRef = sqlCommand.Parameters.Add("@TOTALAMNTDSPWAYREF", SqlDbType.Int);
                        SqlParameter paraAccountNoInfo1 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO1", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo2 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO2", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo3 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO3", SqlDbType.NVarChar);
                        SqlParameter paraSalesUnPrcFrcProcCd = sqlCommand.Parameters.Add("@SALESUNPRCFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraSalesMoneyFrcProcCd = sqlCommand.Parameters.Add("@SALESMONEYFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraSalesCnsTaxFrcProcCd = sqlCommand.Parameters.Add("@SALESCNSTAXFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraCustomerSlipNoDiv = sqlCommand.Parameters.Add("@CUSTOMERSLIPNODIV", SqlDbType.Int);
                        SqlParameter paraNTimeCalcStDate = sqlCommand.Parameters.Add("@NTIMECALCSTDATE", SqlDbType.Int);
                        SqlParameter paraCustomerAgent = sqlCommand.Parameters.Add("@CUSTOMERAGENT", SqlDbType.NVarChar);
                        SqlParameter paraClaimSectionCode = sqlCommand.Parameters.Add("@CLAIMSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCarMngDivCd = sqlCommand.Parameters.Add("@CARMNGDIVCD", SqlDbType.Int);
                        SqlParameter paraBillPartsNoPrtCd = sqlCommand.Parameters.Add("@BILLPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraDeliPartsNoPrtCd = sqlCommand.Parameters.Add("@DELIPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraDefSalesSlipCd = sqlCommand.Parameters.Add("@DEFSALESSLIPCD", SqlDbType.Int);
                        SqlParameter paraLavorRateRank = sqlCommand.Parameters.Add("@LAVORRATERANK", SqlDbType.Int);
                        SqlParameter paraSlipTtlPrn = sqlCommand.Parameters.Add("@SLIPTTLPRN", SqlDbType.Int);
                        SqlParameter paraDepoBankCode = sqlCommand.Parameters.Add("@DEPOBANKCODE", SqlDbType.Int);
                        SqlParameter paraCustWarehouseCd = sqlCommand.Parameters.Add("@CUSTWAREHOUSECD", SqlDbType.NChar);
                        SqlParameter paraQrcodePrtCd = sqlCommand.Parameters.Add("@QRCODEPRTCD", SqlDbType.Int);
                        SqlParameter paraDeliHonorificTtl = sqlCommand.Parameters.Add("@DELIHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraBillHonorificTtl = sqlCommand.Parameters.Add("@BILLHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraEstmHonorificTtl = sqlCommand.Parameters.Add("@ESTMHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraRectHonorificTtl = sqlCommand.Parameters.Add("@RECTHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraDeliHonorTtlPrtDiv = sqlCommand.Parameters.Add("@DELIHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraBillHonorTtlPrtDiv = sqlCommand.Parameters.Add("@BILLHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraEstmHonorTtlPrtDiv = sqlCommand.Parameters.Add("@ESTMHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraRectHonorTtlPrtDiv = sqlCommand.Parameters.Add("@RECTHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraNote1 = sqlCommand.Parameters.Add("@NOTE1", SqlDbType.NVarChar);
                        SqlParameter paraNote2 = sqlCommand.Parameters.Add("@NOTE2", SqlDbType.NVarChar);
                        SqlParameter paraNote3 = sqlCommand.Parameters.Add("@NOTE3", SqlDbType.NVarChar);
                        SqlParameter paraNote4 = sqlCommand.Parameters.Add("@NOTE4", SqlDbType.NVarChar);
                        SqlParameter paraNote5 = sqlCommand.Parameters.Add("@NOTE5", SqlDbType.NVarChar);
                        SqlParameter paraNote6 = sqlCommand.Parameters.Add("@NOTE6", SqlDbType.NVarChar);
                        SqlParameter paraNote7 = sqlCommand.Parameters.Add("@NOTE7", SqlDbType.NVarChar);
                        SqlParameter paraNote8 = sqlCommand.Parameters.Add("@NOTE8", SqlDbType.NVarChar);
                        SqlParameter paraNote9 = sqlCommand.Parameters.Add("@NOTE9", SqlDbType.NVarChar);
                        SqlParameter paraNote10 = sqlCommand.Parameters.Add("@NOTE10", SqlDbType.NVarChar);
                        // ADD 2009.02.05 >>>
                        SqlParameter paraSalesSlipPrtDiv = sqlCommand.Parameters.Add("@SALESSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraShipmSlipPrtDiv = sqlCommand.Parameters.Add("@SHIPMSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraEstimatePrtDiv = sqlCommand.Parameters.Add("@ESTIMATEPRTDIV", SqlDbType.Int);
                        SqlParameter paraUOESlipPrtDiv = sqlCommand.Parameters.Add("@UOESLIPPRTDIV", SqlDbType.Int);
                        // ADD 2009.02.05 <<<

                        // --- ADD 2009/04/06 ------>>>
                        SqlParameter paraReceiptOutputCode = sqlCommand.Parameters.Add("@RECEIPTOUTPUTCODE", SqlDbType.Int);
                        // --- ADD 2009/04/06 ------<<<
                        // --- ADD 2009/05/20 ------>>>
                        SqlParameter paraCustomerEpCode = sqlCommand.Parameters.Add("@CUSTOMEREPCODE", SqlDbType.NChar);  // 得意先企業コード
                        SqlParameter paraCustomerSecCode = sqlCommand.Parameters.Add("@CUSTOMERSECCODE", SqlDbType.NChar);  // 得意先拠点コード
                        SqlParameter paraOnlineKindDiv = sqlCommand.Parameters.Add("@ONLINEKINDDIV", SqlDbType.Int);  // オンライン種別区分
                        // --- ADD 2009/05/20 ------<<<
                        // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                        SqlParameter paraTotalBillOutputDiv = sqlCommand.Parameters.Add("@TOTALBILLOUTPUTDIV", SqlDbType.Int);
                        SqlParameter paraDetailBillOutputCode = sqlCommand.Parameters.Add("@DETAILBILLOUTPUTCODE", SqlDbType.Int);
                        SqlParameter paraSlipTtlBillOutputDiv = sqlCommand.Parameters.Add("@SLIPTTLBILLOUTPUTDIV", SqlDbType.Int);
                        // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                        SqlParameter paraSimplInqAcntAcntGrId = sqlCommand.Parameters.Add("@SIMPLINQACNTACNTGRID", SqlDbType.NChar);  // 簡単問合せアカウントグループID // ADD 2010/06/25

                        # endregion

                        # region Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(customerWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(customerWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(customerWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);
                        paraCustomerSubCode.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSubCode);
                        paraName.Value = SqlDataMediator.SqlSetString(customerWork.Name);
                        paraName2.Value = SqlDataMediator.SqlSetString(customerWork.Name2);
                        paraHonorificTitle.Value = SqlDataMediator.SqlSetString(customerWork.HonorificTitle);
                        paraKana.Value = SqlDataMediator.SqlSetString(customerWork.Kana);
                        paraCustomerSnm.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSnm);
                        paraOutputNameCode.Value = SqlDataMediator.SqlSetInt32(customerWork.OutputNameCode);
                        paraOutputName.Value = SqlDataMediator.SqlSetString(customerWork.OutputName);
                        paraCorporateDivCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CorporateDivCode);
                        paraCustomerAttributeDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerAttributeDiv);
                        paraJobTypeCode.Value = SqlDataMediator.SqlSetInt32(customerWork.JobTypeCode);
                        paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(customerWork.BusinessTypeCode);
                        paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesAreaCode);
                        paraPostNo.Value = SqlDataMediator.SqlSetString(customerWork.PostNo);
                        paraAddress1.Value = SqlDataMediator.SqlSetString(customerWork.Address1);
                        paraAddress3.Value = SqlDataMediator.SqlSetString(customerWork.Address3);
                        paraAddress4.Value = SqlDataMediator.SqlSetString(customerWork.Address4);
                        paraHomeTelNo.Value = SqlDataMediator.SqlSetString(customerWork.HomeTelNo);
                        paraOfficeTelNo.Value = SqlDataMediator.SqlSetString(customerWork.OfficeTelNo);
                        paraPortableTelNo.Value = SqlDataMediator.SqlSetString(customerWork.PortableTelNo);
                        paraHomeFaxNo.Value = SqlDataMediator.SqlSetString(customerWork.HomeFaxNo);
                        paraOfficeFaxNo.Value = SqlDataMediator.SqlSetString(customerWork.OfficeFaxNo);
                        paraOthersTelNo.Value = SqlDataMediator.SqlSetString(customerWork.OthersTelNo);
                        paraMainContactCode.Value = SqlDataMediator.SqlSetInt32(customerWork.MainContactCode);
                        paraSearchTelNo.Value = SqlDataMediator.SqlSetString(customerWork.SearchTelNo);
                        paraMngSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.MngSectionCode);
                        paraInpSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.InpSectionCode);
                        paraCustAnalysCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode1);
                        paraCustAnalysCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode2);
                        paraCustAnalysCode3.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode3);
                        paraCustAnalysCode4.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode4);
                        paraCustAnalysCode5.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode5);
                        paraCustAnalysCode6.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode6);                                              
                        paraBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.BillOutputCode);                    
                        paraBillOutputName.Value = SqlDataMediator.SqlSetString(customerWork.BillOutputName);
                        paraTotalDay.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalDay);
                        paraCollectMoneyCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectMoneyCode);
                        paraCollectMoneyName.Value = SqlDataMediator.SqlSetString(customerWork.CollectMoneyName);
                        paraCollectMoneyDay.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectMoneyDay);
                        paraCollectCond.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectCond);
                        paraCollectSight.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectSight);
                        paraClaimCode.Value = SqlDataMediator.SqlSetInt32(customerWork.ClaimCode);
                        paraTransStopDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerWork.TransStopDate);
                        paraDmOutCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DmOutCode);
                        paraDmOutName.Value = SqlDataMediator.SqlSetString(customerWork.DmOutName);
                        paraMainSendMailAddrCd.Value = SqlDataMediator.SqlSetInt32(customerWork.MainSendMailAddrCd);
                        paraMailAddrKindCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.MailAddrKindCode1);
                        paraMailAddrKindName1.Value = SqlDataMediator.SqlSetString(customerWork.MailAddrKindName1);
                        paraMailAddress1.Value = SqlDataMediator.SqlSetString(customerWork.MailAddress1);
                        paraMailSendCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.MailSendCode1);
                        paraMailSendName1.Value = SqlDataMediator.SqlSetString(customerWork.MailSendName1);
                        paraMailAddrKindCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.MailAddrKindCode2);
                        paraMailAddrKindName2.Value = SqlDataMediator.SqlSetString(customerWork.MailAddrKindName2);
                        paraMailAddress2.Value = SqlDataMediator.SqlSetString(customerWork.MailAddress2);
                        paraMailSendCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.MailSendCode2);
                        paraMailSendName2.Value = SqlDataMediator.SqlSetString(customerWork.MailSendName2);
                        paraCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerWork.CustomerAgentCd);
                        paraBillCollecterCd.Value = SqlDataMediator.SqlSetString(customerWork.BillCollecterCd);
                        paraOldCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerWork.OldCustomerAgentCd);
                        paraCustAgentChgDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerWork.CustAgentChgDate);
                        paraAcceptWholeSale.Value = SqlDataMediator.SqlSetInt32(customerWork.AcceptWholeSale);
                        paraCreditMngCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CreditMngCode);
                        paraDepoDelCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DepoDelCode);
                        paraAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(customerWork.AccRecDivCd);
                        paraCustSlipNoMngCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CustSlipNoMngCd);
                        paraPureCode.Value = SqlDataMediator.SqlSetInt32(customerWork.PureCode);
                        paraCustCTaXLayRefCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CustCTaXLayRefCd);
                        paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(customerWork.ConsTaxLayMethod);
                        paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalAmountDispWayCd);
                        paraTotalAmntDspWayRef.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalAmntDspWayRef);
                        paraAccountNoInfo1.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo1);
                        paraAccountNoInfo2.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo2);
                        paraAccountNoInfo3.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo3);
                        paraSalesUnPrcFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesUnPrcFrcProcCd);
                        paraSalesMoneyFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesMoneyFrcProcCd);
                        paraSalesCnsTaxFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesCnsTaxFrcProcCd);
                        paraCustomerSlipNoDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerSlipNoDiv);
                        paraNTimeCalcStDate.Value = SqlDataMediator.SqlSetInt32(customerWork.NTimeCalcStDate);
                        paraCustomerAgent.Value = SqlDataMediator.SqlSetString(customerWork.CustomerAgent);
                        paraClaimSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.ClaimSectionCode);
                        paraCarMngDivCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CarMngDivCd);
                        paraBillPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.BillPartsNoPrtCd);
                        paraDeliPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.DeliPartsNoPrtCd);
                        paraDefSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(customerWork.DefSalesSlipCd);
                        paraLavorRateRank.Value = SqlDataMediator.SqlSetInt32(customerWork.LavorRateRank);
                        paraSlipTtlPrn.Value = SqlDataMediator.SqlSetInt32(customerWork.SlipTtlPrn);
                        paraDepoBankCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DepoBankCode);
                        paraCustWarehouseCd.Value = SqlDataMediator.SqlSetString(customerWork.CustWarehouseCd);
                        paraQrcodePrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.QrcodePrtCd);
                        paraDeliHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.DeliHonorificTtl);
                        paraBillHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.BillHonorificTtl);
                        paraEstmHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.EstmHonorificTtl);
                        paraRectHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.RectHonorificTtl);
                        paraDeliHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.DeliHonorTtlPrtDiv);
                        paraBillHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.BillHonorTtlPrtDiv);
                        paraEstmHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.EstmHonorTtlPrtDiv);
                        paraRectHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.RectHonorTtlPrtDiv);
                        paraNote1.Value = SqlDataMediator.SqlSetString(customerWork.Note1);
                        paraNote2.Value = SqlDataMediator.SqlSetString(customerWork.Note2);
                        paraNote3.Value = SqlDataMediator.SqlSetString(customerWork.Note3);
                        paraNote4.Value = SqlDataMediator.SqlSetString(customerWork.Note4);
                        paraNote5.Value = SqlDataMediator.SqlSetString(customerWork.Note5);
                        paraNote6.Value = SqlDataMediator.SqlSetString(customerWork.Note6);
                        paraNote7.Value = SqlDataMediator.SqlSetString(customerWork.Note7);
                        paraNote8.Value = SqlDataMediator.SqlSetString(customerWork.Note8);
                        paraNote9.Value = SqlDataMediator.SqlSetString(customerWork.Note9);
                        paraNote10.Value = SqlDataMediator.SqlSetString(customerWork.Note10);
                        // ADD 2009.02.05 >>>
                        paraSalesSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesSlipPrtDiv);
                        paraShipmSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.ShipmSlipPrtDiv);
                        paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.AcpOdrrSlipPrtDiv);
                        paraEstimatePrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.EstimatePrtDiv);
                        paraUOESlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.UOESlipPrtDiv);
                        // ADD 2009.02.05 <<<

                        // --- ADD 2009/04/06 ------>>>
                        paraReceiptOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.ReceiptOutputCode);
                        // --- ADD 2009/04/06 ------<<<

                        // --- ADD 2009/05/20 ------>>>
                        paraCustomerEpCode.Value = SqlDataMediator.SqlSetString(customerWork.CustomerEpCode);  // 得意先企業コード
                        paraCustomerSecCode.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSecCode);  // 得意先拠点コード
                        paraOnlineKindDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.OnlineKindDiv);  // オンライン種別区分
                        // --- ADD 2009/05/20 ------<<<
                        // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                        paraTotalBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalBillOutputDiv);
                        paraDetailBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DetailBillOutputCode);
                        paraSlipTtlBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.SlipTtlBillOutputDiv);
                        // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                        paraSimplInqAcntAcntGrId.Value = SqlDataMediator.SqlSetString(customerWork.SimplInqAcntAcntGrId);  // 簡単問合せアカウントグループID // ADD 2010/06/25
                        # endregion
                    // ADD 2009/04/09 >>>
                    }
                    else if (customerWork.WriteDiv == 1) // 0:得意先マスタ 1:得意先一括修正
                    {
                        # region Parameterオブジェクトの作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCustomerSubCode = sqlCommand.Parameters.Add("@CUSTOMERSUBCODE", SqlDbType.NVarChar);
                        SqlParameter paraName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar);
                        SqlParameter paraName2 = sqlCommand.Parameters.Add("@NAME2", SqlDbType.NVarChar);
                        SqlParameter paraHonorificTitle = sqlCommand.Parameters.Add("@HONORIFICTITLE", SqlDbType.NVarChar);
                        SqlParameter paraKana = sqlCommand.Parameters.Add("@KANA", SqlDbType.NVarChar);
                        SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                        SqlParameter paraOutputNameCode = sqlCommand.Parameters.Add("@OUTPUTNAMECODE", SqlDbType.Int);
                        SqlParameter paraOutputName = sqlCommand.Parameters.Add("@OUTPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraCorporateDivCode = sqlCommand.Parameters.Add("@CORPORATEDIVCODE", SqlDbType.Int);
                        SqlParameter paraCustomerAttributeDiv = sqlCommand.Parameters.Add("@CUSTOMERATTRIBUTEDIV", SqlDbType.Int);
                        SqlParameter paraJobTypeCode = sqlCommand.Parameters.Add("@JOBTYPECODE", SqlDbType.Int);
                        SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                        SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                        SqlParameter paraPostNo = sqlCommand.Parameters.Add("@POSTNO", SqlDbType.NVarChar);
                        SqlParameter paraAddress1 = sqlCommand.Parameters.Add("@ADDRESS1", SqlDbType.NVarChar);
                        SqlParameter paraAddress3 = sqlCommand.Parameters.Add("@ADDRESS3", SqlDbType.NVarChar);
                        SqlParameter paraAddress4 = sqlCommand.Parameters.Add("@ADDRESS4", SqlDbType.NVarChar);
                        SqlParameter paraHomeTelNo = sqlCommand.Parameters.Add("@HOMETELNO", SqlDbType.NVarChar);
                        SqlParameter paraOfficeTelNo = sqlCommand.Parameters.Add("@OFFICETELNO", SqlDbType.NVarChar);
                        SqlParameter paraPortableTelNo = sqlCommand.Parameters.Add("@PORTABLETELNO", SqlDbType.NVarChar);
                        SqlParameter paraHomeFaxNo = sqlCommand.Parameters.Add("@HOMEFAXNO", SqlDbType.NVarChar);
                        SqlParameter paraOfficeFaxNo = sqlCommand.Parameters.Add("@OFFICEFAXNO", SqlDbType.NVarChar);
                        SqlParameter paraOthersTelNo = sqlCommand.Parameters.Add("@OTHERSTELNO", SqlDbType.NVarChar);
                        SqlParameter paraMainContactCode = sqlCommand.Parameters.Add("@MAINCONTACTCODE", SqlDbType.Int);
                        SqlParameter paraSearchTelNo = sqlCommand.Parameters.Add("@SEARCHTELNO", SqlDbType.NChar);
                        SqlParameter paraMngSectionCode = sqlCommand.Parameters.Add("@MNGSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInpSectionCode = sqlCommand.Parameters.Add("@INPSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCustAnalysCode1 = sqlCommand.Parameters.Add("@CUSTANALYSCODE1", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode2 = sqlCommand.Parameters.Add("@CUSTANALYSCODE2", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode3 = sqlCommand.Parameters.Add("@CUSTANALYSCODE3", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode4 = sqlCommand.Parameters.Add("@CUSTANALYSCODE4", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode5 = sqlCommand.Parameters.Add("@CUSTANALYSCODE5", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode6 = sqlCommand.Parameters.Add("@CUSTANALYSCODE6", SqlDbType.Int);                                          
                        SqlParameter paraBillOutputCode = sqlCommand.Parameters.Add("@BILLOUTPUTCODE", SqlDbType.Int);                        
                        SqlParameter paraBillOutputName = sqlCommand.Parameters.Add("@BILLOUTPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@TOTALDAY", SqlDbType.Int);
                        SqlParameter paraCollectMoneyCode = sqlCommand.Parameters.Add("@COLLECTMONEYCODE", SqlDbType.Int);
                        SqlParameter paraCollectMoneyName = sqlCommand.Parameters.Add("@COLLECTMONEYNAME", SqlDbType.NVarChar);
                        SqlParameter paraCollectMoneyDay = sqlCommand.Parameters.Add("@COLLECTMONEYDAY", SqlDbType.Int);
                        SqlParameter paraCollectCond = sqlCommand.Parameters.Add("@COLLECTCOND", SqlDbType.Int);
                        SqlParameter paraCollectSight = sqlCommand.Parameters.Add("@COLLECTSIGHT", SqlDbType.Int);
                        SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                        SqlParameter paraTransStopDate = sqlCommand.Parameters.Add("@TRANSSTOPDATE", SqlDbType.Int);
                        SqlParameter paraDmOutCode = sqlCommand.Parameters.Add("@DMOUTCODE", SqlDbType.Int);
                        SqlParameter paraDmOutName = sqlCommand.Parameters.Add("@DMOUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraMainSendMailAddrCd = sqlCommand.Parameters.Add("@MAINSENDMAILADDRCD", SqlDbType.Int);
                        SqlParameter paraMailAddrKindCode1 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE1", SqlDbType.Int);
                        SqlParameter paraMailAddrKindName1 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME1", SqlDbType.NVarChar);
                        SqlParameter paraMailAddress1 = sqlCommand.Parameters.Add("@MAILADDRESS1", SqlDbType.NVarChar);
                        SqlParameter paraMailSendCode1 = sqlCommand.Parameters.Add("@MAILSENDCODE1", SqlDbType.Int);
                        SqlParameter paraMailSendName1 = sqlCommand.Parameters.Add("@MAILSENDNAME1", SqlDbType.NVarChar);
                        SqlParameter paraMailAddrKindCode2 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE2", SqlDbType.Int);
                        SqlParameter paraMailAddrKindName2 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME2", SqlDbType.NVarChar);
                        SqlParameter paraMailAddress2 = sqlCommand.Parameters.Add("@MAILADDRESS2", SqlDbType.NVarChar);
                        SqlParameter paraMailSendCode2 = sqlCommand.Parameters.Add("@MAILSENDCODE2", SqlDbType.Int);
                        SqlParameter paraMailSendName2 = sqlCommand.Parameters.Add("@MAILSENDNAME2", SqlDbType.NVarChar);
                        SqlParameter paraCustomerAgentCd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCD", SqlDbType.NChar);
                        SqlParameter paraBillCollecterCd = sqlCommand.Parameters.Add("@BILLCOLLECTERCD", SqlDbType.NChar);
                        SqlParameter paraOldCustomerAgentCd = sqlCommand.Parameters.Add("@OLDCUSTOMERAGENTCD", SqlDbType.NChar);
                        SqlParameter paraCustAgentChgDate = sqlCommand.Parameters.Add("@CUSTAGENTCHGDATE", SqlDbType.Int);
                        SqlParameter paraAcceptWholeSale = sqlCommand.Parameters.Add("@ACCEPTWHOLESALE", SqlDbType.Int);
                        SqlParameter paraCreditMngCode = sqlCommand.Parameters.Add("@CREDITMNGCODE", SqlDbType.Int);
                        SqlParameter paraDepoDelCode = sqlCommand.Parameters.Add("@DEPODELCODE", SqlDbType.Int);
                        SqlParameter paraAccRecDivCd = sqlCommand.Parameters.Add("@ACCRECDIVCD", SqlDbType.Int);
                        SqlParameter paraCustSlipNoMngCd = sqlCommand.Parameters.Add("@CUSTSLIPNOMNGCD", SqlDbType.Int);
                        SqlParameter paraPureCode = sqlCommand.Parameters.Add("@PURECODE", SqlDbType.Int);
                        SqlParameter paraCustCTaXLayRefCd = sqlCommand.Parameters.Add("@CUSTCTAXLAYREFCD", SqlDbType.Int);
                        SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                        SqlParameter paraTotalAmountDispWayCd = sqlCommand.Parameters.Add("@TOTALAMOUNTDISPWAYCD", SqlDbType.Int);
                        SqlParameter paraTotalAmntDspWayRef = sqlCommand.Parameters.Add("@TOTALAMNTDSPWAYREF", SqlDbType.Int);
                        SqlParameter paraAccountNoInfo1 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO1", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo2 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO2", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo3 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO3", SqlDbType.NVarChar);
                        SqlParameter paraSalesUnPrcFrcProcCd = sqlCommand.Parameters.Add("@SALESUNPRCFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraSalesMoneyFrcProcCd = sqlCommand.Parameters.Add("@SALESMONEYFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraSalesCnsTaxFrcProcCd = sqlCommand.Parameters.Add("@SALESCNSTAXFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraCustomerSlipNoDiv = sqlCommand.Parameters.Add("@CUSTOMERSLIPNODIV", SqlDbType.Int);
                        SqlParameter paraNTimeCalcStDate = sqlCommand.Parameters.Add("@NTIMECALCSTDATE", SqlDbType.Int);
                        SqlParameter paraCustomerAgent = sqlCommand.Parameters.Add("@CUSTOMERAGENT", SqlDbType.NVarChar);
                        SqlParameter paraClaimSectionCode = sqlCommand.Parameters.Add("@CLAIMSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCarMngDivCd = sqlCommand.Parameters.Add("@CARMNGDIVCD", SqlDbType.Int);
                        SqlParameter paraBillPartsNoPrtCd = sqlCommand.Parameters.Add("@BILLPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraDeliPartsNoPrtCd = sqlCommand.Parameters.Add("@DELIPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraDefSalesSlipCd = sqlCommand.Parameters.Add("@DEFSALESSLIPCD", SqlDbType.Int);
                        SqlParameter paraLavorRateRank = sqlCommand.Parameters.Add("@LAVORRATERANK", SqlDbType.Int);
                        SqlParameter paraSlipTtlPrn = sqlCommand.Parameters.Add("@SLIPTTLPRN", SqlDbType.Int);
                        SqlParameter paraDepoBankCode = sqlCommand.Parameters.Add("@DEPOBANKCODE", SqlDbType.Int);
                        //SqlParameter paraCustWarehouseCd = sqlCommand.Parameters.Add("@CUSTWAREHOUSECD", SqlDbType.Int);// DEL 2008.12.10
                        SqlParameter paraCustWarehouseCd = sqlCommand.Parameters.Add("@CUSTWAREHOUSECD", SqlDbType.NChar); // ADD 2008.12.10
                        SqlParameter paraQrcodePrtCd = sqlCommand.Parameters.Add("@QRCODEPRTCD", SqlDbType.Int);
                        SqlParameter paraDeliHonorificTtl = sqlCommand.Parameters.Add("@DELIHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraBillHonorificTtl = sqlCommand.Parameters.Add("@BILLHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraEstmHonorificTtl = sqlCommand.Parameters.Add("@ESTMHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraRectHonorificTtl = sqlCommand.Parameters.Add("@RECTHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraDeliHonorTtlPrtDiv = sqlCommand.Parameters.Add("@DELIHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraBillHonorTtlPrtDiv = sqlCommand.Parameters.Add("@BILLHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraEstmHonorTtlPrtDiv = sqlCommand.Parameters.Add("@ESTMHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraRectHonorTtlPrtDiv = sqlCommand.Parameters.Add("@RECTHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraNote1 = sqlCommand.Parameters.Add("@NOTE1", SqlDbType.NVarChar);
                        SqlParameter paraNote2 = sqlCommand.Parameters.Add("@NOTE2", SqlDbType.NVarChar);
                        SqlParameter paraNote3 = sqlCommand.Parameters.Add("@NOTE3", SqlDbType.NVarChar);
                        SqlParameter paraNote4 = sqlCommand.Parameters.Add("@NOTE4", SqlDbType.NVarChar);
                        SqlParameter paraNote5 = sqlCommand.Parameters.Add("@NOTE5", SqlDbType.NVarChar);
                        SqlParameter paraNote6 = sqlCommand.Parameters.Add("@NOTE6", SqlDbType.NVarChar);
                        SqlParameter paraNote7 = sqlCommand.Parameters.Add("@NOTE7", SqlDbType.NVarChar);
                        SqlParameter paraNote8 = sqlCommand.Parameters.Add("@NOTE8", SqlDbType.NVarChar);
                        SqlParameter paraNote9 = sqlCommand.Parameters.Add("@NOTE9", SqlDbType.NVarChar);
                        SqlParameter paraNote10 = sqlCommand.Parameters.Add("@NOTE10", SqlDbType.NVarChar);
                        // --- ADD 2009/04/07 -------->>>
                        SqlParameter paraReceiptOutputCode = sqlCommand.Parameters.Add("@RECEIPTOUTPUTCODE", SqlDbType.Int);
                        // --- ADD 2009/04/07 --------<<<
                        // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                        SqlParameter paraTotalBillOutputDiv = sqlCommand.Parameters.Add("@TOTALBILLOUTPUTDIV", SqlDbType.Int);
                        SqlParameter paraDetailBillOutputCode = sqlCommand.Parameters.Add("@DETAILBILLOUTPUTCODE", SqlDbType.Int);
                        SqlParameter paraSlipTtlBillOutputDiv = sqlCommand.Parameters.Add("@SLIPTTLBILLOUTPUTDIV", SqlDbType.Int);

                        SqlParameter paraSalesSlipPrtDiv = sqlCommand.Parameters.Add("@SALESSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraShipmSlipPrtDiv = sqlCommand.Parameters.Add("@SHIPMSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraEstimatePrtDiv = sqlCommand.Parameters.Add("@ESTIMATEPRTDIV", SqlDbType.Int);
                        SqlParameter paraUOESlipPrtDiv = sqlCommand.Parameters.Add("@UOESLIPPRTDIV", SqlDbType.Int);
                        // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                        SqlParameter paraSimplInqAcntAcntGrId = sqlCommand.Parameters.Add("@SIMPLINQACNTACNTGRID", SqlDbType.NChar); // ADD 2010/06/25
                        # endregion

                        # region Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(customerWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(customerWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(customerWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);
                        paraCustomerSubCode.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSubCode);
                        paraName.Value = SqlDataMediator.SqlSetString(customerWork.Name);
                        paraName2.Value = SqlDataMediator.SqlSetString(customerWork.Name2);
                        paraHonorificTitle.Value = SqlDataMediator.SqlSetString(customerWork.HonorificTitle);
                        paraKana.Value = SqlDataMediator.SqlSetString(customerWork.Kana);
                        paraCustomerSnm.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSnm);
                        paraOutputNameCode.Value = SqlDataMediator.SqlSetInt32(customerWork.OutputNameCode);
                        paraOutputName.Value = SqlDataMediator.SqlSetString(customerWork.OutputName);
                        paraCorporateDivCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CorporateDivCode);
                        paraCustomerAttributeDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerAttributeDiv);
                        paraJobTypeCode.Value = SqlDataMediator.SqlSetInt32(customerWork.JobTypeCode);
                        paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(customerWork.BusinessTypeCode);
                        paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesAreaCode);
                        paraPostNo.Value = SqlDataMediator.SqlSetString(customerWork.PostNo);
                        paraAddress1.Value = SqlDataMediator.SqlSetString(customerWork.Address1);
                        paraAddress3.Value = SqlDataMediator.SqlSetString(customerWork.Address3);
                        paraAddress4.Value = SqlDataMediator.SqlSetString(customerWork.Address4);
                        paraHomeTelNo.Value = SqlDataMediator.SqlSetString(customerWork.HomeTelNo);
                        paraOfficeTelNo.Value = SqlDataMediator.SqlSetString(customerWork.OfficeTelNo);
                        paraPortableTelNo.Value = SqlDataMediator.SqlSetString(customerWork.PortableTelNo);
                        paraHomeFaxNo.Value = SqlDataMediator.SqlSetString(customerWork.HomeFaxNo);
                        paraOfficeFaxNo.Value = SqlDataMediator.SqlSetString(customerWork.OfficeFaxNo);
                        paraOthersTelNo.Value = SqlDataMediator.SqlSetString(customerWork.OthersTelNo);
                        paraMainContactCode.Value = SqlDataMediator.SqlSetInt32(customerWork.MainContactCode);
                        paraSearchTelNo.Value = SqlDataMediator.SqlSetString(customerWork.SearchTelNo);
                        paraMngSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.MngSectionCode);
                        paraInpSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.InpSectionCode);
                        paraCustAnalysCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode1);
                        paraCustAnalysCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode2);
                        paraCustAnalysCode3.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode3);
                        paraCustAnalysCode4.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode4);
                        paraCustAnalysCode5.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode5);
                        paraCustAnalysCode6.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode6);                                              
                        paraBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.BillOutputCode);                        
                        paraBillOutputName.Value = SqlDataMediator.SqlSetString(customerWork.BillOutputName);
                        paraTotalDay.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalDay);
                        paraCollectMoneyCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectMoneyCode);
                        paraCollectMoneyName.Value = SqlDataMediator.SqlSetString(customerWork.CollectMoneyName);
                        paraCollectMoneyDay.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectMoneyDay);
                        paraCollectCond.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectCond);
                        paraCollectSight.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectSight);
                        paraClaimCode.Value = SqlDataMediator.SqlSetInt32(customerWork.ClaimCode);
                        paraTransStopDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerWork.TransStopDate);
                        paraDmOutCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DmOutCode);
                        paraDmOutName.Value = SqlDataMediator.SqlSetString(customerWork.DmOutName);
                        paraMainSendMailAddrCd.Value = SqlDataMediator.SqlSetInt32(customerWork.MainSendMailAddrCd);
                        paraMailAddrKindCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.MailAddrKindCode1);
                        paraMailAddrKindName1.Value = SqlDataMediator.SqlSetString(customerWork.MailAddrKindName1);
                        paraMailAddress1.Value = SqlDataMediator.SqlSetString(customerWork.MailAddress1);
                        paraMailSendCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.MailSendCode1);
                        paraMailSendName1.Value = SqlDataMediator.SqlSetString(customerWork.MailSendName1);
                        paraMailAddrKindCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.MailAddrKindCode2);
                        paraMailAddrKindName2.Value = SqlDataMediator.SqlSetString(customerWork.MailAddrKindName2);
                        paraMailAddress2.Value = SqlDataMediator.SqlSetString(customerWork.MailAddress2);
                        paraMailSendCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.MailSendCode2);
                        paraMailSendName2.Value = SqlDataMediator.SqlSetString(customerWork.MailSendName2);
                        paraCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerWork.CustomerAgentCd);
                        paraBillCollecterCd.Value = SqlDataMediator.SqlSetString(customerWork.BillCollecterCd);
                        paraOldCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerWork.OldCustomerAgentCd);
                        paraCustAgentChgDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerWork.CustAgentChgDate);
                        paraAcceptWholeSale.Value = SqlDataMediator.SqlSetInt32(customerWork.AcceptWholeSale);
                        paraCreditMngCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CreditMngCode);
                        paraDepoDelCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DepoDelCode);
                        paraAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(customerWork.AccRecDivCd);
                        paraCustSlipNoMngCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CustSlipNoMngCd);
                        paraPureCode.Value = SqlDataMediator.SqlSetInt32(customerWork.PureCode);
                        paraCustCTaXLayRefCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CustCTaXLayRefCd);
                        paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(customerWork.ConsTaxLayMethod);
                        paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalAmountDispWayCd);
                        paraTotalAmntDspWayRef.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalAmntDspWayRef);
                        paraAccountNoInfo1.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo1);
                        paraAccountNoInfo2.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo2);
                        paraAccountNoInfo3.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo3);
                        paraSalesUnPrcFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesUnPrcFrcProcCd);
                        paraSalesMoneyFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesMoneyFrcProcCd);
                        paraSalesCnsTaxFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesCnsTaxFrcProcCd);
                        paraCustomerSlipNoDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerSlipNoDiv);
                        paraNTimeCalcStDate.Value = SqlDataMediator.SqlSetInt32(customerWork.NTimeCalcStDate);
                        paraCustomerAgent.Value = SqlDataMediator.SqlSetString(customerWork.CustomerAgent);
                        paraClaimSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.ClaimSectionCode);
                        paraCarMngDivCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CarMngDivCd);
                        paraBillPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.BillPartsNoPrtCd);
                        paraDeliPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.DeliPartsNoPrtCd);
                        paraDefSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(customerWork.DefSalesSlipCd);
                        paraLavorRateRank.Value = SqlDataMediator.SqlSetInt32(customerWork.LavorRateRank);
                        paraSlipTtlPrn.Value = SqlDataMediator.SqlSetInt32(customerWork.SlipTtlPrn);
                        paraDepoBankCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DepoBankCode);
                        paraCustWarehouseCd.Value = SqlDataMediator.SqlSetString(customerWork.CustWarehouseCd);
                        paraQrcodePrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.QrcodePrtCd);
                        paraDeliHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.DeliHonorificTtl);
                        paraBillHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.BillHonorificTtl);
                        paraEstmHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.EstmHonorificTtl);
                        paraRectHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.RectHonorificTtl);
                        paraDeliHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.DeliHonorTtlPrtDiv);
                        paraBillHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.BillHonorTtlPrtDiv);
                        paraEstmHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.EstmHonorTtlPrtDiv);
                        paraRectHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.RectHonorTtlPrtDiv);
                        paraNote1.Value = SqlDataMediator.SqlSetString(customerWork.Note1);
                        paraNote2.Value = SqlDataMediator.SqlSetString(customerWork.Note2);
                        paraNote3.Value = SqlDataMediator.SqlSetString(customerWork.Note3);
                        paraNote4.Value = SqlDataMediator.SqlSetString(customerWork.Note4);
                        paraNote5.Value = SqlDataMediator.SqlSetString(customerWork.Note5);
                        paraNote6.Value = SqlDataMediator.SqlSetString(customerWork.Note6);
                        paraNote7.Value = SqlDataMediator.SqlSetString(customerWork.Note7);
                        paraNote8.Value = SqlDataMediator.SqlSetString(customerWork.Note8);
                        paraNote9.Value = SqlDataMediator.SqlSetString(customerWork.Note9);
                        paraNote10.Value = SqlDataMediator.SqlSetString(customerWork.Note10);
                        // --- ADD 2009/04/07 -------->>>
                        paraReceiptOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.ReceiptOutputCode);
                        // --- ADD 2009/04/07 --------<<<
                        // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                        paraTotalBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalBillOutputDiv);
                        paraDetailBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DetailBillOutputCode);
                        paraSlipTtlBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.SlipTtlBillOutputDiv);

                        paraSalesSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesSlipPrtDiv);
                        paraShipmSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.ShipmSlipPrtDiv);
                        paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.AcpOdrrSlipPrtDiv);
                        paraEstimatePrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.EstimatePrtDiv);
                        paraUOESlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.UOESlipPrtDiv);
                        // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                        paraSimplInqAcntAcntGrId.Value = SqlDataMediator.SqlSetString(customerWork.SimplInqAcntAcntGrId);  // ADD 2010/06/25
                        # endregion
                    }
                    // ADD 2009/04/09 <<<
                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "得意先マスタの書込みに失敗しました。", ex.Number);
                sqlTransaction.Rollback();
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                if ((myReader != null) && (!myReader.IsClosed))
                {
                    myReader.Close();
                }

                myReader.Dispose();
            }

            return status;
        }
        # endregion

        // --- ADD 2008/09/02 ---------->>>>>

        // ===================================================================================== //
        // Delete関連　パブリックメソッド
        // ===================================================================================== //
        #region 得意先マスタ物理削除処理 public int Delete(ref object paraList)
        /// <summary>
        /// 得意先マスタ物理処理
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタを物理削除します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.02</br>
        /// </remarks>
        public int Delete(ref object paraList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            CustomerWork customerWork = null;

            ArrayList paraCustomList = paraList as ArrayList;

            if (paraCustomList == null)
            {
                base.WriteErrorLog("プログラムエラー。対象パラメータが未指定です", status);
                return status;
            }
            else if (paraCustomList.Count > 0)
            {
                // List内の得意先・備考・家族構成リストを抽出
                foreach (object obj in paraCustomList)
                {
                    if (customerWork == null)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = obj as CustomerWork;
                        }
                    }
                }
            }

            if (customerWork == null)
            {
                base.WriteErrorLog("プログラムエラー。抽出対象オブジェクトパラメータが未指定です。", status);
                return status;
            }

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection_read = null;

            try
            {
                // 各publicメソッドの開始時にコネクション文字列を取得
                // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                    return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // Read用コネクションをインスタンス化
                sqlConnection_read = new SqlConnection(connectionText);
                sqlConnection_read.Open();

                // ログイン情報取得クラスをインスタンス化
                ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();

                // --- ADD 2008.10.14 >>>
                CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                CustomerChangeWork customerChangeWork = new CustomerChangeWork();
                int CusChangestatus = 0;
                // --- ADD 2008.10.14 <<<
                // 2008.11.14 add ----------------------------------------------------------------->>
                // 得意先(掛率グループ)物理削除
                CustRateGroupDB custRateGroupDB = new CustRateGroupDB();
                CustRateGroupWork custRateGroupWork = new CustRateGroupWork();
                ArrayList custRateGroupList = new ArrayList();
                int CustRtGrpstatus = 0;

                // 得意先(伝票番号)物理削除
                CustSlipNoSetDB custSlipNoSetDB = new CustSlipNoSetDB();
                CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();
                ArrayList custSlipNoSetList = new ArrayList();
                int CustSlipNostatus = 0;
                // 2008.11.14 add -----------------------------------------------------------------<<


                // ================================================================================= //
                // 得意先マスタ物理削除
                // ================================================================================= //
                ArrayList duplicationItemList = new ArrayList();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (customerWork != null)
                    {
                        // --- ADD 2008.10.14 得意先マスタ(変動情報)物理削除処理 >>>
                        if (customerWork.CreditMngCode == 1)
                        {
                            // パラメーター設定
                            customerChangeWork.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
                            customerChangeWork.CustomerCode = customerWork.CustomerCode;     // 得意先コード
                            // 得意先マスタ(変動情報)取得
                            CusChangestatus = customerChangeDB.ReadProc(ref customerChangeWork, 0, ref sqlConnection_read);
                        }
                        // --- ADD 2008.10.14 <<<
                        // 2008.11.14 add ----------------------------------------------------------------->>
                        // 得意先(掛率グループ)取得
                        custRateGroupWork.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
                        custRateGroupWork.CustomerCode = customerWork.CustomerCode;     // 得意先コード
                        CustRtGrpstatus = custRateGroupDB.Search(ref custRateGroupList, custRateGroupWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                        // 得意先(伝票番号)取得
                        custSlipNoSetWork.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
                        custSlipNoSetWork.CustomerCode = customerWork.CustomerCode;     // 得意先コード
                        CustSlipNostatus = custSlipNoSetDB.Search(ref custSlipNoSetList, custSlipNoSetWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                        // 2008.11.14 add -----------------------------------------------------------------<<

                        status = this.DeleteProc(ref customerWork, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            customSerializeArrayList.Add((CustomerWork)customerWork);
                        }

                        // --- ADD 2008.10.14 得意先マスタ(変動情報)物理削除処理 >>>                            
                        if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //パラメータのキャスト
                            ArrayList changeWorkparaList = new ArrayList();
                            changeWorkparaList.Add(customerChangeWork);
                            CusChangestatus = customerChangeDB.DeleteProc(changeWorkparaList, ref sqlConnection, ref sqlTransaction);

                        }
                        // --- ADD 2008.10.14 <<<
                        // 2008.11.14 add ----------------------------------------------------------------->>
                        // 得意先(掛率グループ)物理削除処理
                        if (CustRtGrpstatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustRtGrpstatus = custRateGroupDB.Delete(custRateGroupList, ref sqlConnection, ref sqlTransaction);

                        }

                        // 得意先(伝票番号)物理削除処理
                        if (CustSlipNostatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustSlipNostatus = custSlipNoSetDB.Delete(custSlipNoSetList, ref sqlConnection, ref sqlTransaction);

                        }

                        // 2008.11.14 add -----------------------------------------------------------------<<

                    }
                }

                // コミット
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
            }
            // 例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "得意先マスタの物理削除に失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection_read != null)
                {
                    sqlConnection_read.Close();
                    sqlConnection_read.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }
            }

            paraList = (object)customSerializeArrayList;
            return status;
        }
        #endregion

        // ===================================================================================== //
        // Delete関連　プライベートメソッド
        // ===================================================================================== //
        #region 得意先マスタ物理削除処理
        /// <summary>
        /// 得意先マスタ物理処理
        /// </summary>
        /// <param name="customerWork">CustomSerializeList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタを物理削除します</br>
        /// <br>Programmer : 23015 森本 大輝</br>
        /// <br>Date       : 2008.09.02</br>
        /// </remarks>
        private int DeleteProc(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Selectコマンドの生成
                #region [SELECT文]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " FROM CUSTOMERRF" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                #endregion

                // Prameterオブジェクトの作成
                sqlCommand.Parameters.Clear();
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomercode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                // Parameterオブジェクトへ値設定
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != customerWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }

                    //Deleteコマンドの生成
                    #region [DELETE文]
                    sqlText = string.Empty;
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += " FROM CUSTOMERRF" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion

                    // KEYコマンドを再設定
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                    findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);
                }
                else
                {
                    // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                        myReader.Dispose();
                    }

                    return status;
                }

                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                if ((myReader != null) && (!myReader.IsClosed))
                {
                    myReader.Close();
                    myReader.Dispose();
                }

                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "得意先マスタの物理削除に失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "得意先マスタの物理削除に失敗しました。", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }

            return status;
        }
        #endregion

        // --- ADD 2008/09/02 ----------<<<<<

        // ===================================================================================== //
        // LogidalDelete関連　パブリックメソッド
        // ===================================================================================== //
        # region 得意先マスタ論理削除処理 public int LogicalDelete(ref object paraList, bool carDeleteFlg)
        /// <summary>
        /// 得意先マスタ論理削除処理
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <param name="carDeleteFlg">車両削除フラグ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタを論理削除します</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public int LogicalDelete(ref object paraList, bool carDeleteFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            CustomerWork customerWork = null;
            //CusCarNoteWork cusCarNoteWork = null;  削除予定

            ArrayList paraCustomList = paraList as ArrayList;

            //オブジェクトの取得(カスタムArray内から検索)
            if (paraCustomList == null)
            {
                base.WriteErrorLog("プログラムエラー。対象パラメータが未指定です", status);
                return status;
            }
            else if (paraCustomList.Count > 0)
            {
                // List内の得意先・備考・家族構成リストを抽出
                foreach (object obj in paraCustomList)
                {
                    if (customerWork == null)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = obj as CustomerWork;
                        }
                    }
                }
            }

            //削除予定
            //if ((customerWork == null) && (cusCarNoteWork == null))                                //ADD 2007/08/23 M.Kubota
            if (customerWork == null)
            {
                base.WriteErrorLog("プログラムエラー。抽出対象オブジェクトパラメータが未指定です。", status);
                return status;
            }

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection_read = null;

            try
            {
                // 各publicメソッドの開始時にコネクション文字列を取得
                // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                    return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // Read用コネクションをインスタンス化
                sqlConnection_read = new SqlConnection(connectionText);
                sqlConnection_read.Open();

                // ログイン情報取得クラスをインスタンス化
                ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();

                // --- ADD 2008.10.14 >>>
                CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                CustomerChangeWork paraCustomerChangeWork = new CustomerChangeWork();
                int CusChangestatus = 0;
                if (customerWork.CreditMngCode == 1)
                {
                    // パラメーター設定
                    paraCustomerChangeWork.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
                    paraCustomerChangeWork.CustomerCode = customerWork.CustomerCode;     // 得意先コード
                    // 得意先マスタ(変動情報)取得
                    CusChangestatus = customerChangeDB.ReadProc(ref paraCustomerChangeWork, 0, ref sqlConnection_read);
                }
                // --- ADD 2008.10.14 <<<
                // 2008.11.14 add ----------------------------------------------------------------->>
                // 得意先(掛率グループ)取得
                CustRateGroupDB custRateGroupDB = new CustRateGroupDB();
                CustRateGroupWork custRateGroupWork = new CustRateGroupWork();
                ArrayList custRateGroupList = new ArrayList();
                int CustRtGrpstatus = 0;
                custRateGroupWork.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
                custRateGroupWork.CustomerCode = customerWork.CustomerCode;     // 得意先コード
                CustRtGrpstatus = custRateGroupDB.Search(ref custRateGroupList, custRateGroupWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                // 得意先(伝票番号)取得
                CustSlipNoSetDB custSlipNoSetDB = new CustSlipNoSetDB();
                CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();
                ArrayList custSlipNoSetList = new ArrayList();
                int CustSlipNostatus = 0;
                custSlipNoSetWork.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
                custSlipNoSetWork.CustomerCode = customerWork.CustomerCode;     // 得意先コード
                CustSlipNostatus = custSlipNoSetDB.Search(ref custSlipNoSetList, custSlipNoSetWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                // 2008.11.14 add -----------------------------------------------------------------<<


                // ================================================================================= //
                // 得意先マスタ論理削除
                // ================================================================================= //
                ArrayList duplicationItemList = new ArrayList();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (customerWork != null)
                    {
                        status = this.LogicalDeleteCustomerWork(ref customerWork, ref sqlConnection, ref sqlTransaction, 0);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            customSerializeArrayList.Add((CustomerWork)customerWork);
                        }
                        // --- ADD 2008.10.14 得意先マスタ(変動情報)論理削除処理 >>>
                        if (customerWork.CreditMngCode == 1)
                        {
                            if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //パラメータのキャスト
                                ArrayList paraCustomerChangeList = new ArrayList();
                                paraCustomerChangeList.Add(paraCustomerChangeWork);

                                CusChangestatus = customerChangeDB.LogicalDeleteProc(ref paraCustomerChangeList, 0, ref sqlConnection, ref sqlTransaction);
                            }
                        }
                        // --- ADD 2008.10.14 <<<
                        // 2008.11.14 add ----------------------------------------------------------------->>
                        // 得意先(掛率グループ)論理削除処理
                        if (CustRtGrpstatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustRtGrpstatus = custRateGroupDB.LogicalDelete(ref custRateGroupList, 0, ref sqlConnection, ref sqlTransaction);

                        }

                        // 得意先(伝票番号)論理削除処理
                        if (CustSlipNostatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustSlipNostatus = custSlipNoSetDB.LogicalDelete(ref custSlipNoSetList, 0, ref sqlConnection, ref sqlTransaction);

                        }

                        // 2008.11.14 add -----------------------------------------------------------------<<

                    }
                }

                // コミット
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
            }
            // 例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "得意先マスタの論理削除に失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection_read != null)
                {
                    sqlConnection_read.Close();
                    sqlConnection_read.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }
            }

            paraList = (object)customSerializeArrayList;
            return status;
        }
        # endregion

        // ===================================================================================== //
        // LogidalDelete関連　プライベートメソッド
        // ===================================================================================== //
        # region 得意先マスタ論理削除処理 private int LogicalDeleteCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int procMode)
        /// <summary>
        /// 得意先マスタ論理削除処理
        /// </summary>
        /// <param name="customerWork">得意先マスタオブジェクト</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタを論理削除します</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        private int LogicalDeleteCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int procMode)
        {
            int logicalDelCd = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, CUSTOMERCODERF FROM CUSTOMERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction))
                {
                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomercode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                    findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                    sqlCommand.CommandTimeout = 3600;
                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != customerWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }
                        // 現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlCommand.CommandText = "UPDATE CUSTOMERRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";

                        // KEYコマンドを再設定
                        findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                        if ((myReader != null) && (!myReader.IsClosed))
                        {
                            myReader.Close();
                            myReader.Dispose();
                        }

                        return status;
                    }

                    sqlCommand.Cancel();

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                    }

                    // 論理削除モードの場合
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            return status;
                        }
                        else if (logicalDelCd == 0)
                        {
                            customerWork.LogicalDeleteCode = 1;
                        }
                        else
                        {
                            customerWork.LogicalDeleteCode = 3;
                        }
                    }
                    // 復活モードの場合
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            customerWork.LogicalDeleteCode = 0;
                        }
                        else
                        {
                            if (logicalDelCd == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            }

                            if ((myReader != null) && (!myReader.IsClosed))
                            {
                                myReader.Close();
                                myReader.Dispose();
                            }

                            return status;
                        }
                    }

                    // Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdatedatetime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdcustomercode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdassemblyid1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdassemblyid2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicaldeletecode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定(更新用)
                    paraUpdatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.UpdateDateTime);
                    paraUpdcustomercode.Value = SqlDataMediator.SqlSetString(customerWork.UpdEmployeeCode);
                    paraUpdassemblyid1.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId1);
                    paraUpdassemblyid2.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId2);
                    paraLogicaldeletecode.Value = SqlDataMediator.SqlSetInt32(customerWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                if ((myReader != null) && (!myReader.IsClosed))
                {
                    myReader.Close();
                    myReader.Dispose();
                }

                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "得意先マスタの論理削除に失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "得意先マスタの論理削除に失敗しました。", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }

            return status;

        }
        # endregion

        // ===================================================================================== //
        // RevivalLogidalDelete関連　パブリックメソッド
        // ===================================================================================== //
        # region 得意先マスタ論理削除復活処理 public int RevivalLogicalDelete(ref object paraList)
        /// <summary>
        /// 得意先マスタ論理削除復活処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタの論理削除デーを復活します</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public int RevivalLogicalDelete(string enterpriseCode, int customerCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            CustomerWork customerWork = new CustomerWork();
            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection_read = null;

            try
            {
                // 各publicメソッドの開始時にコネクション文字列を取得
                // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                    return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // Read用コネクションをインスタンス化
                sqlConnection_read = new SqlConnection(connectionText);
                sqlConnection_read.Open();

                // ログイン情報取得クラスをインスタンス化
                ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();


                // --- ADD 2008.10.14 得意先マスタ(変動情報)復旧処理 >>>
                CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                CustomerChangeWork paraCustomerChangeWork = new CustomerChangeWork();
                int CusChangestatus = 0;
                // --- ADD 2008.10.14 <<<
                // 2008.11.14 add ----------------------------------------------------------------->>
                // 得意先(掛率グループ)復旧処理
                CustRateGroupDB custRateGroupDB = new CustRateGroupDB();
                CustRateGroupWork custRateGroupWork = new CustRateGroupWork();
                ArrayList custRateGroupList = new ArrayList();
                int CustRtGrpstatus = 0;

                // 得意先(伝票番号)復旧処理
                CustSlipNoSetDB custSlipNoSetDB = new CustSlipNoSetDB();
                CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();
                ArrayList custSlipNoSetList = new ArrayList();
                int CustSlipNostatus = 0;
                // 2008.11.14 add -----------------------------------------------------------------<<


                // 得意先マスタ復元処理
                ArrayList duplicationItemList = new ArrayList();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 得意先マスタパラメータ設定
                    customerWork.EnterpriseCode = enterpriseCode;
                    customerWork.CustomerCode = customerCode;

                    // 得意先マスタ取得処理
                    status = this.ReadCustomerWork(ref customerWork, ref sqlConnection_read, ConstantManagement.LogicalMode.GetData1);

                    // ADD 2008.10.14 >>>
                    if (customerWork.CreditMngCode == 1)
                    {
                        // パラメーター設定
                        paraCustomerChangeWork.EnterpriseCode = enterpriseCode; // 企業コード
                        paraCustomerChangeWork.CustomerCode = customerCode;     // 得意先コード
                        // 得意先マスタ(変動情報)取得
                        CusChangestatus = customerChangeDB.ReadProc(ref paraCustomerChangeWork, 0, ref sqlConnection_read);
                    }
                    // ADD 2008.10.14 <<<
                    // 2008.11.14 add ----------------------------------------------------------------->>
                    // 得意先(掛率グループ)取得
                    custRateGroupWork.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
                    custRateGroupWork.CustomerCode = customerWork.CustomerCode;     // 得意先コード
                    CustRtGrpstatus = custRateGroupDB.Search(ref custRateGroupList, custRateGroupWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                    // 得意先(伝票番号)取得
                    custSlipNoSetWork.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
                    custSlipNoSetWork.CustomerCode = customerWork.CustomerCode;     // 得意先コード
                    CustSlipNostatus = custSlipNoSetDB.Search(ref custSlipNoSetList, custSlipNoSetWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                    // 2008.11.14 add -----------------------------------------------------------------<<


                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = this.LogicalDeleteCustomerWork(ref customerWork, ref sqlConnection, ref sqlTransaction, 1);
                        
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            customSerializeArrayList.Add(customerWork);
                        }

                        // --- ADD 2008.10.14 得意先マスタ(変動情報)復旧処理 >>>
                        if (customerWork.CreditMngCode == 1)
                        {
                            // パラメーター設定
                            if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //パラメータのキャスト
                                ArrayList paraList = new ArrayList();
                                paraList.Add(paraCustomerChangeWork);
                                CusChangestatus = customerChangeDB.LogicalDeleteProc(ref paraList, 1, ref sqlConnection, ref sqlTransaction);
                            }
                        }
                        // --- ADD 2008.10.14 <<<
                        // 2008.11.14 add ----------------------------------------------------------------->>
                        // 得意先(掛率グループ)復旧処理
                        if (CustRtGrpstatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustRtGrpstatus = custRateGroupDB.LogicalDelete(ref custRateGroupList, 1, ref sqlConnection, ref sqlTransaction);

                        }

                        // 得意先(伝票番号)復旧処理
                        if (CustSlipNostatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustSlipNostatus = custSlipNoSetDB.LogicalDelete(ref custSlipNoSetList, 1, ref sqlConnection, ref sqlTransaction);

                        }

                        // 2008.11.14 add -----------------------------------------------------------------<<
                    }
                }

                // コミット
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
            }
            // 例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "得意先マスタの論理削除復元に失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "得意先マスタの論理削除復元に失敗しました。", status);
            }

            finally
            {
                // コネクション破棄
                if (sqlConnection_read != null)
                {
                    sqlConnection_read.Close();
                    sqlConnection_read.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }
            }

            return status;
        }
        # endregion

        // ===================================================================================== //
        // 削除チェック関連　パブリックメソッド
        // ===================================================================================== //
        #region 得意先マスタ削除チェック処理 public int DeleteCheck(string enterpriseCode, int customerCode, out string message, out bool checkFlg)
        /// <summary>
        /// 得意先マスタ削除チェック処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="message">メッセージ</param>
        /// <param name="checkFlg">チェック結果[true:削除ＯＫ][false:削除ＮＧ]</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタの削除チェック処理を行います</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2005.09.26</br>
        /// </remarks>
        public int DeleteCheck(string enterpriseCode, int customerCode, out string message, out bool checkFlg)
        {
            checkFlg = true;
            message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 各publicメソッドの開始時にコネクション文字列を取得
            // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return status;

            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // ============================================================================= //
                // 得意先情報取得処理
                // ============================================================================= //
                CustomerWork customerWork = new CustomerWork();
                customerWork.EnterpriseCode = enterpriseCode;
                customerWork.CustomerCode = customerCode;
                status = this.ReadCustomerWork(ref customerWork, ref sqlConnection, ConstantManagement.LogicalMode.GetData0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // OK
                    //2008.11.14 add 得意先マスタ(総括設定)チェック処理 ------------------------>>
                    SumCustStDB sumCustStDB = new SumCustStDB();
                    ArrayList retList = new ArrayList();
                    SumCustStWork sumCustStWork = new SumCustStWork();
                    sumCustStWork.EnterpriseCode = enterpriseCode;
                    sumCustStWork.SumClaimCustCode = customerCode;
                    
                    object retObj = retList;
                    object paraObj = sumCustStWork;

                    // 総括得意先をチェック
                    status = sumCustStDB.Search(ref retObj, paraObj, 4, ConstantManagement.LogicalMode.GetData012);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 存在したらNG
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        checkFlg = false;
                        message = "総括に設定済の為、削除できません";
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        // OK
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        sumCustStWork = new SumCustStWork();
                        sumCustStWork.EnterpriseCode = enterpriseCode;
                        sumCustStWork.CustomerCode = customerCode;

                        paraObj = sumCustStWork;

                        // 総括得意先をチェック
                        status = sumCustStDB.Search(ref retObj, paraObj, 4, ConstantManagement.LogicalMode.GetData012);
                        
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 存在したらNG
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            checkFlg = false;
                            message = "総括に設定済の為、削除できません";
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            
                            //親得意先の場合 親子関係チェック
                            if (customerWork.CustomerCode == customerWork.ClaimCode)
                            {
                                status = this.CheckCustomerWork(ref customerWork, ref sqlConnection, ConstantManagement.LogicalMode.GetData0);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 存在したらNG
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                    checkFlg = false;
                                    message = "親得意先は削除できません。"+Environment.NewLine;
                                    message += "削除する場合は、子得意先を先に削除して下さい。";
                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // OK
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                else
                                {
                                    // エラー
                                }
                            }
                            else
                            {
                                // OK
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                        else
                        {
                            // エラー
                        }

                    }
                    else
                    {
                        // エラー
                    }

                    //2008.11.14 add ---------------------------------------------------------<<
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    checkFlg = false;
                    message = "この得意先は既に他端末にて削除されています。";
                }
                else
                {
                    // エラー
                }

                if ((!checkFlg) || (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    return status;

            }
            // 例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "得意先マスタ削除チェック処理に失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "得意先マスタ削除チェック処理に失敗しました。", status);
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        # endregion

        // ===================================================================================== //
        // 削除チェック関連　プライベートメソッド
        // ===================================================================================== //
        #region 得意先親子関係チェック private int CheckCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        /// <summary>
        /// 得意先マスタ親子情報チェック処理
        /// </summary>
        /// <param name="customerWork">得意先ワーククラス</param>
        /// <param name="sqlConnection">ＳＱＬコネクション</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コード、請求先コードの得意先を戻します</br>
        /// <br>Programmer : 23012</br>
        /// <br>Date       : 2009.02.05</br>
        /// </remarks>
        private int CheckCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUST.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CUST.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CUST.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CUST.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSUBCODERF" + Environment.NewLine;
                sqlText += " ,CUST.NAMERF" + Environment.NewLine;
                sqlText += " ,CUST.NAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.HONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,CUST.KANARF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMECODERF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.CORPORATEDIVCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.JOBTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,CUST.POSTNORF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS3RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS4RF" + Environment.NewLine;
                sqlText += " ,CUST.HOMETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.PORTABLETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.HOMEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OTHERSTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MAINCONTACTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SEARCHTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE6RF" + Environment.NewLine;             
                sqlText += " ,CUST.BILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTCONDRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMCODERF" + Environment.NewLine;
                sqlText += " ,CUST.TRANSSTOPDATERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.MAINSENDMAILADDRCDRF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += " ,CUST.OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTAGENTCHGDATERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCEPTWHOLESALERF" + Environment.NewLine;
                sqlText += " ,CUST.CREDITMNGCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DEPODELCODERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                sqlText += " ,CUST.PURECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO1RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO2RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO3RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CARMNGDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DEFSALESSLIPCDRF" + Environment.NewLine;
                sqlText += " ,CUST.LAVORRATERANKRF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLPRNRF" + Environment.NewLine;
                sqlText += " ,CUST.DEPOBANKCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTWAREHOUSECDRF" + Environment.NewLine;
                sqlText += " ,CUST.QRCODEPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE1RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE2RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE3RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE4RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE5RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE6RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE7RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE8RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE9RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE10RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTIMATEPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.UOESLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECEIPTOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMEREPCODERF " + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSECCODERF " + Environment.NewLine;
                sqlText += " ,CUST.ONLINEKINDDIVRF " + Environment.NewLine;
                // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                sqlText += " ,CUST.TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                sqlText += " ,CUST.SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;  // ADD 2010/06/25
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF AS CUST" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUST.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "  AND CUST.CUSTOMERCODERF != @FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "  AND CUST.CLAIMCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                
                # endregion

                // Selectコマンドの生成
                SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection);

                // Parameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "得意先マスタの読み込みに失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }

            return status;
        }
        #endregion

        # region 得意先削除チェック区分取得処理
        /*削除予定 (未使用)
        /// <summary>
        /// 得意先削除チェック区分取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sqlConnection">ＳＱＬコネクション</param>
        /// <returns>得意先削除チェック区分</returns>
        /// <remarks>
        /// <br>Note       : 全体初期値設定マスタより、得意先削除チェック区分を取得します</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2005.09.26</br>
        /// </remarks>
        private int GetCustomerDelChkDivCd(string enterpriseCode, string sectionCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int customerDelChkDivCd = 0;

            SqlDataReader myReader = null;

            try
            {
                // Selectコマンドの生成
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT CUSTOMERDELCHKDIVCDRF FROM ALLDEFSETRF " +
                    "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND SECTIONCODERF=@FINDSECTIONCODE",
                    sqlConnection);

                // Parameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    customerDelChkDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERDELCHKDIVCDRF"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);

                #if DEBUG
                Console.WriteLine(ex.Message);
                # endif
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }

            return customerDelChkDivCd;
        }
        */
        # endregion

        // ===================================================================================== //
        // その他　パブリックメソッド
        // ===================================================================================== //
        # region 得意先締日取得処理 private int GetCustomerTotalDay(string enterpriseCode, int customerCode, ref int totalDay, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        /// <summary>
        /// 得意先締日取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="totalDay">締日</param>
        /// <param name="sqlConnection">ＳＱＬコネクション</param>
        /// <param name="sqlTransaction">ＳＱＬトランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コード、得意先コードの締日を取得します。</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        public int GetCustomerTotalDay(string enterpriseCode, int customerCode, ref int totalDay, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.GetCustomerTotalDayProc(enterpriseCode, customerCode, ref totalDay, ref sqlConnection, ref sqlTransaction);
        }
        #endregion

        # region 得意先締日取得処理 private int GetCustomerTotalDay(string enterpriseCode, int customerCode, ref int totalDay, ref SqlConnection sqlConnection)
        /// <summary>
        /// 得意先締日取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="totalDay">締日</param>
        /// <param name="sqlConnection">ＳＱＬコネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コード、得意先コードの締日を取得します。</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2005.09.21</br>
        /// </remarks>
        public int GetCustomerTotalDay(string enterpriseCode, int customerCode, ref int totalDay, ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            return this.GetCustomerTotalDay(enterpriseCode, customerCode, ref totalDay, ref sqlConnection, ref sqlTransaction);
        }
        # endregion

        # region 更新日変更チェック処理 public bool IsUpdateDateTimeChange(DateTime updateDateTime, string enterpriseCode, int customerCode)
        /// <summary>
        /// 更新日変更チェック処理
        /// </summary>
        /// <param name="updateDateTime">更新日</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>true:変更有り false:変更無し</returns>
        public bool IsUpdateDateTimeChange(DateTime updateDateTime, string enterpriseCode, int customerCode)
        {
            // 各publicメソッドの開始時にコネクション文字列を取得
            // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return true;

            SqlConnection sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            bool isChange;
            int status = this.IsUpdateDateTimeChangeProc(out isChange, updateDateTime, enterpriseCode, customerCode, sqlConnection);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                isChange = true;
            }

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return isChange;
        }
        # endregion

        // ===================================================================================== //
        // その他　プライベートメソッド
        // ===================================================================================== //
        # region 得意先締日取得処理 private int GetCustomerTotalDay(string enterpriseCode, int customerCode, ref int totalDay, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        /// <summary>
        /// 得意先締日取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="totalDay">締日</param>
        /// <param name="sqlConnection">ＳＱＬコネクション</param>
        /// <param name="sqlTransaction">ＳＱＬトランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コード、得意先コードの締日を取得します。</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        private int GetCustomerTotalDayProc(string enterpriseCode, int customerCode, ref int totalDay, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                // Selectコマンドの生成

                string sqlText = string.Empty;

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUST.TOTALDAYRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF AS CUST" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUST.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "  AND CUST.LOGICALDELETECODERF = @FINDLOGICALDELETECODE " + Environment.NewLine;

                SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                // Parameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    totalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "得意先締日取得に失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "得意先締日取得に失敗しました。", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region 得意先コード採番処理
        /// <summary>
        /// 得意先コード採番処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="retMsg">リターンメッセージ</param>
        /// <param name="sqlConnection">Ｓｑｌコネクション</param>
        /// <param name="sqlTransaction">Ｓｑｌトランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先コードを採番して返します</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        private int CreateCustomerCode(string enterpriseCode, string sectionCode, out int customerCode, out string retMsg,ref SqlConnection sqlConnection,ref SqlTransaction sqlTransaction)
        {
            //戻り値初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            customerCode = 0;
            retMsg = "";

            NumberNumbering numberNumbering = new NumberNumbering();

            //番号範囲分ループ
            int firstNo = 0;
            int loopCnt = 0;	//最大ループカウンタ

            while (loopCnt <= 999999999)
            {
                string retNo;
                int no;
                Int32 ptnCd;
                Int32 noCode = 1;		// 番号ＣＤ：得意先コード

                // 番号採番
                status = numberNumbering.Numbering(enterpriseCode, sectionCode, noCode, new string[0], out retNo, out ptnCd, out retMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                    no = Convert.ToInt32(retNo);

                    // 初回採番番号を保存
                    if (firstNo == 0)
                    {
                        firstNo = no;
                    }
                    //初回番号と同一番号が採番された場合ループカウンタをMaxにして終了
                    else if (firstNo == no)
                    {
                        loopCnt = 999999999;
                        break;
                    }

                    SqlDataReader myReader = null;

                    // 得意先コード空き番チェック
                    try
                    {
                        // Selectコマンドの生成
                        SqlCommand sqlCommand = new SqlCommand("SELECT CUSTOMERCODERF FROM CUSTOMERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction);

                        // Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(no);

                        sqlCommand.CommandTimeout = 3600;
                        myReader = sqlCommand.ExecuteReader();

                        // データ無しの場合には戻り値をセット
                        if (!myReader.Read())
                        {
                            customerCode = no;
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                    catch (SqlException ex)
                    {
                        // 基底クラスに例外を渡して処理してもらう
                        status = base.WriteSQLErrorLog(ex, "得意先コードの採番に失敗しました。", ex.Number);
                        break;
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        base.WriteErrorLog(ex, "得意先コードの採番に失敗しました。", status);
                        break;
                    }
                    finally
                    {
                        if (myReader != null)
                        {
                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                            myReader.Dispose();
                        }
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        break;
                    }
                }
                // 採番できなかった場合には処理中断。
                else
                {
                    break;
                }

                // 同一番号がある場合にはループカウンタをインクリメントし再採番
                loopCnt++;
            }

            // 全件ループしても取得出来ない場合
            if (loopCnt == 999999999 && status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                retMsg = "得意先コードに空き番号がありません。削除可能な得意先を削除してください。";
            }

            //エラーでもステータス及びメッセージはそのまま戻す
            return status;
        }
        # endregion

        # region 排他コントロール処理
        ///// <summary>
        ///// 排他コントロール処理
        ///// </summary>
        ///// <param name="mode">処理区分 0:Lock 1:UnLock</param>
        ///// <param name="ctrlExclsvOdAcs">排他部品オブジェクト</param>
        ///// <param name="customerWork">排他設定得意先クラス</param>
        ///// <param name="msg">エラーメッセージ</param>
        ///// <returns>STATUS</returns>
        //private int ControlExclusiveProc(int mode, ref ControlExclusiveOrderAccess ctrlExclsvOdAcs,ref CustomerWork customerWork,ref string msg)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    // パラメータチェック
        //    if ((customerWork == null) || (customerWork.EnterpriseCode.Trim() == "") || (customerWork.CustomerCode == 0))
        //    {
        //        return status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }

        //    // 排他Lockモードの場合
        //    if (mode == 0)
        //    {
        //        // 得意先コードをセット
        //        Int32[] customerCodeList = new Int32[1];
        //        Int32[] acceptAnOrderNoList = new Int32[0];

        //        customerCodeList[0] = customerWork.CustomerCode;

        //        status = ctrlExclsvOdAcs.LockDB(customerWork.EnterpriseCode, customerCodeList, acceptAnOrderNoList);

        //        if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE ||
        //            status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
        //        {
        //            msg = "排他の為登録出来ませんでした。しばらくお待ちになって再度登録してください";
        //        }
        //        if (status == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
        //        {
        //            msg = "データサーバーの接続がタイムアウトになりました。しばらくお待ちになって再度登録してください";
        //        }
        //    }
        //    // 排他UnLockモードの場合
        //    else
        //    {
        //        status = ctrlExclsvOdAcs.UnlockDB();
        //    }

        //    return status;
        //}
        # endregion

        # region 論理削除区分チェック処理
        /// <summary>
        /// 論理削除区分チェック処理
        /// </summary>
        /// <param name="logicalDeleteCode">論理削除区分</param>
        /// <param name="logicalMode">論理削除データ抽出モード</param>
        /// <returns>0:該当データあり 4:該当データなし</returns>
        /// <remarks>
        /// <br>Note		: 論理削除データ抽出モードを元に、論理削除区分のチェックを行います。</br>
        /// <br>Programmer	: 980079 妻鳥  謙一郎</br>
        /// <br>Date		: 2006.01.17</br>
        /// </remarks>
        private int LogicalDeleteCodeCheck(int logicalDeleteCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            switch (logicalMode)
            {
                case ConstantManagement.LogicalMode.GetData0:
                    {
                        if (logicalDeleteCode == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        break;
                    }
                case ConstantManagement.LogicalMode.GetData01:
                    {
                        if ((logicalDeleteCode == 0) || (logicalDeleteCode == 1))
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        break;
                    }
                case ConstantManagement.LogicalMode.GetData012:
                    {
                        if ((logicalDeleteCode == 0) || (logicalDeleteCode == 1) || (logicalDeleteCode == 2))
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        break;
                    }
                case ConstantManagement.LogicalMode.GetData1:
                    {
                        if (logicalDeleteCode == 1)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        break;
                    }
                case ConstantManagement.LogicalMode.GetData2:
                    {
                        if (logicalDeleteCode == 2)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        break;
                    }
                case ConstantManagement.LogicalMode.GetData3:
                    {
                        if (logicalDeleteCode == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        break;
                    }
                default:
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
                    }
            }

            return status;
        }
        # endregion

        # region 得意先マスタ存在チェック
        /// <summary>
        /// 得意先マスタ存在チェック
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>STATUS</returns>
        private int ExistCheckProc(string enterpriseCode, int customerCode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                SqlCommand sqlCommand;

                sqlCommand = new SqlCommand("SELECT CUSTOMERRF.LOGICALDELETECODERF" +
                    " FROM CUSTOMERRF" +
                    " WHERE CUSTOMERRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERRF.CUSTOMERCODERF=@FINDCUSTOMERCODE",
                    sqlConnection);

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                // Parameterオブジェクトへ値設定
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(customerCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    int logicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    status = this.LogicalDeleteCodeCheck(logicalDeleteCode, logicalMode);
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "得意先マスタの存在チェックに失敗しました。", ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }
            return status;
        }
        # endregion

        # region 更新日変更チェック処理
        /// <summary>
        /// 更新日変更チェック処理
        /// </summary>
        /// <param name="isChange">変更有無</param>
        /// <param name="updateDateTime">更新日</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>STATUS</returns>
        private int IsUpdateDateTimeChangeProc(out bool isChange, DateTime updateDateTime, string enterpriseCode, int customerCode, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            isChange = true;
            SqlDataReader myReader = null;

            try
            {
                SqlCommand sqlCommand;

                sqlCommand = new SqlCommand("SELECT CUSTOMERRF.UPDATEDATETIMERF" +
                    " FROM CUSTOMERRF" +
                    " WHERE CUSTOMERRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERRF.CUSTOMERCODERF=@FINDCUSTOMERCODE AND CUSTOMERRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE",
                    sqlConnection);

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                // Parameterオブジェクトへ値設定
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(customerCode);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt(0);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    DateTime source = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));

                    if (source == updateDateTime)
                    {
                        isChange = false;
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "得意先マスタの更新日チェックに失敗しました。", ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }

            return status;
        }
        # endregion

        # region 得意先名称取得処理
        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCodeArray">得意先コード配列</param>
        /// <param name="nameTable">名称Hashtable</param>
        /// <param name="name2Table">名称2Hashtable</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先コードを複数指定し、名称と名称２をHashtableで取得します</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2006.06.28</br>
        /// </remarks>
        public int GetName(string enterpriseCode, int[] customerCodeArray, out Hashtable nameTable, out Hashtable name2Table)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            nameTable = new Hashtable();
            name2Table = new Hashtable();

            CustomerWork[] customerWorkArray;
            int[] statusArray;

            // 各publicメソッドの開始時にコネクション文字列を取得
            // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return status;

            SqlConnection sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            try
            {
                status = this.Read(enterpriseCode, customerCodeArray, out customerWorkArray, out statusArray, ref sqlConnection);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (CustomerWork customerWork in customerWorkArray)
                    {
                        if (!(nameTable.ContainsKey(customerWork.CustomerCode)))
                        {
                            nameTable.Add(customerWork.CustomerCode, customerWork.Name);
                        }

                        if (!(name2Table.ContainsKey(customerWork.CustomerCode)))
                        {
                            name2Table.Add(customerWork.CustomerCode, customerWork.Name2);
                        }
                    }
                }
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        # endregion

        // ===================================================================================== //
        // IGetSyncdataList メンバ
        // ===================================================================================== //
        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlText = string.Empty;

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUSTOMERSUBCODERF" + Environment.NewLine;
                sqlText += " ,NAMERF" + Environment.NewLine;
                sqlText += " ,NAME2RF" + Environment.NewLine;
                sqlText += " ,HONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,KANARF" + Environment.NewLine;
                sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,OUTPUTNAMECODERF" + Environment.NewLine;
                sqlText += " ,OUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CORPORATEDIVCODERF" + Environment.NewLine;
                sqlText += " ,CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,JOBTYPECODERF" + Environment.NewLine;
                sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,POSTNORF" + Environment.NewLine;
                sqlText += " ,ADDRESS1RF" + Environment.NewLine;
                sqlText += " ,ADDRESS3RF" + Environment.NewLine;
                sqlText += " ,ADDRESS4RF" + Environment.NewLine;
                sqlText += " ,HOMETELNORF" + Environment.NewLine;
                sqlText += " ,OFFICETELNORF" + Environment.NewLine;
                sqlText += " ,PORTABLETELNORF" + Environment.NewLine;
                sqlText += " ,HOMEFAXNORF" + Environment.NewLine;
                sqlText += " ,OFFICEFAXNORF" + Environment.NewLine;
                sqlText += " ,OTHERSTELNORF" + Environment.NewLine;
                sqlText += " ,MAINCONTACTCODERF" + Environment.NewLine;
                sqlText += " ,SEARCHTELNORF" + Environment.NewLine;
                sqlText += " ,MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,CUSTANALYSCODE6RF" + Environment.NewLine;                             
                sqlText += " ,BILLOUTPUTCODERF" + Environment.NewLine;                
                sqlText += " ,BILLOUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += " ,COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += " ,COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += " ,COLLECTCONDRF" + Environment.NewLine;
                sqlText += " ,COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += " ,CLAIMCODERF" + Environment.NewLine;
                sqlText += " ,TRANSSTOPDATERF" + Environment.NewLine;
                sqlText += " ,DMOUTCODERF" + Environment.NewLine;
                sqlText += " ,DMOUTNAMERF" + Environment.NewLine;
                sqlText += " ,MAINSENDMAILADDRCDRF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,MAILSENDNAME1RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,MAILSENDCODE2RF" + Environment.NewLine;
                sqlText += " ,MAILSENDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += " ,OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUSTAGENTCHGDATERF" + Environment.NewLine;
                sqlText += " ,ACCEPTWHOLESALERF" + Environment.NewLine;
                sqlText += " ,CREDITMNGCODERF" + Environment.NewLine;
                sqlText += " ,DEPODELCODERF" + Environment.NewLine;
                sqlText += " ,ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                sqlText += " ,PURECODERF" + Environment.NewLine;
                sqlText += " ,CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += " ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += " ,TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                sqlText += " ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                sqlText += " ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                sqlText += " ,SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,CUSTOMERAGENTRF" + Environment.NewLine;
                sqlText += " ,CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CARMNGDIVCDRF" + Environment.NewLine;
                sqlText += " ,BILLPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,DELIPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,DEFSALESSLIPCDRF" + Environment.NewLine;
                sqlText += " ,LAVORRATERANKRF" + Environment.NewLine;
                sqlText += " ,SLIPTTLPRNRF" + Environment.NewLine;
                sqlText += " ,DEPOBANKCODERF" + Environment.NewLine;
                sqlText += " ,CUSTWAREHOUSECDRF" + Environment.NewLine;
                sqlText += " ,QRCODEPRTCDRF" + Environment.NewLine;
                sqlText += " ,DELIHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,BILLHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,ESTMHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,RECTHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,NOTE1RF" + Environment.NewLine;
                sqlText += " ,NOTE2RF" + Environment.NewLine;
                sqlText += " ,NOTE3RF" + Environment.NewLine;
                sqlText += " ,NOTE4RF" + Environment.NewLine;
                sqlText += " ,NOTE5RF" + Environment.NewLine;
                sqlText += " ,NOTE6RF" + Environment.NewLine;
                sqlText += " ,NOTE7RF" + Environment.NewLine;
                sqlText += " ,NOTE8RF" + Environment.NewLine;
                sqlText += " ,NOTE9RF" + Environment.NewLine;
                sqlText += " ,NOTE10RF" + Environment.NewLine;
                // ADD 2009.02.05 >>>
                sqlText += " ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,ESTIMATEPRTDIVRF" + Environment.NewLine;
                sqlText += " ,UOESLIPPRTDIVRF" + Environment.NewLine;
                // ADD 2009.02.05 <<<
                // --- ADD 2009/04/06 ------>>>
                sqlText += " ,RECEIPTOUTPUTCODERF" + Environment.NewLine;
                // --- ADD 2009/04/06 ------<<<
                // --- ADD 2009.05.20 ------>>>
                sqlText += " ,CUST.CUSTOMEREPCODERF " + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSECCODERF " + Environment.NewLine;
                sqlText += " ,CUST.ONLINEKINDDIVRF " + Environment.NewLine;
                // --- ADD 2009.05.20 ------<<<
                // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                sqlText += " ,TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                sqlText += " ,SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;  // ADD 2010/06/25

                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF" + Environment.NewLine;
                sqlCommand = new SqlCommand("", sqlConnection);
                sqlCommand.CommandText = sqlText;

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(ReaderToCustomerWork(ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "得意先マスタのローカルシンク用データの取得に失敗しました。", ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }

            arraylistdata = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">Sync用データ</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //差分シンクの場合は更新日付の範囲指定
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }


        /// <summary>
        /// 得意先マスタの読込結果(SqlDataReader)を得意先マスタワーク(CustomerWork)に格納します。
        /// </summary>
        /// <param name="myReader">得意先マスタの読込結果</param>
        /// <param name="customerWork">得意先マスタワーク</param>
        private void ReaderToCustomerWork(ref SqlDataReader myReader, ref CustomerWork customerWork)
        {
            if (myReader != null && customerWork != null)
            {
                # region [格納処理]
                customerWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                customerWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                customerWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                customerWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                customerWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                customerWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                customerWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                customerWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                customerWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                customerWork.CustomerSubCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSUBCODERF"));
                customerWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                customerWork.Name2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
                customerWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                customerWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                customerWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                customerWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
                customerWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
                customerWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"));
                customerWork.CustomerAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERATTRIBUTEDIVRF"));
                customerWork.JobTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOBTYPECODERF"));
                customerWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                customerWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                customerWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                customerWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                customerWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                customerWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                customerWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
                customerWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
                customerWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                customerWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
                customerWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
                customerWork.OthersTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERSTELNORF"));
                customerWork.MainContactCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
                customerWork.SearchTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHTELNORF"));
                customerWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                customerWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONCODERF"));
                customerWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
                customerWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
                customerWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
                customerWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
                customerWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
                customerWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));                              
                customerWork.BillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLOUTPUTCODERF"));                
                customerWork.BillOutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLOUTPUTNAMERF"));
                customerWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
                customerWork.CollectMoneyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));
                customerWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
                customerWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
                customerWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
                customerWork.CollectSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTSIGHTRF"));
                customerWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                customerWork.TransStopDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TRANSSTOPDATERF"));
                customerWork.DmOutCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMOUTCODERF"));
                customerWork.DmOutName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMOUTNAMERF"));
                customerWork.MainSendMailAddrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINSENDMAILADDRCDRF"));
                customerWork.MailAddrKindCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE1RF"));
                customerWork.MailAddrKindName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME1RF"));
                customerWork.MailAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS1RF"));
                customerWork.MailSendCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE1RF"));
                customerWork.MailSendName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME1RF"));
                customerWork.MailAddrKindCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE2RF"));
                customerWork.MailAddrKindName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME2RF"));
                customerWork.MailAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS2RF"));
                customerWork.MailSendCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE2RF"));
                customerWork.MailSendName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME2RF"));
                customerWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
                customerWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
                customerWork.OldCustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTCDRF"));
                customerWork.CustAgentChgDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CUSTAGENTCHGDATERF"));
                customerWork.AcceptWholeSale = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTWHOLESALERF"));
                customerWork.CreditMngCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITMNGCODERF"));
                customerWork.DepoDelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPODELCODERF"));
                customerWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                customerWork.CustSlipNoMngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNOMNGCDRF"));
                customerWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                customerWork.CustCTaXLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCTAXLAYREFCDRF"));
                customerWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                customerWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                customerWork.TotalAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMNTDSPWAYREFRF"));
                customerWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
                customerWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
                customerWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
                customerWork.SalesUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCFRCPROCCDRF"));
                customerWork.SalesMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESMONEYFRCPROCCDRF"));
                customerWork.SalesCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));
                customerWork.CustomerSlipNoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERSLIPNODIVRF"));
                customerWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NTIMECALCSTDATERF"));
                customerWork.CustomerAgent = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTRF"));
                customerWork.ClaimSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));
                customerWork.CarMngDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGDIVCDRF"));
                customerWork.BillPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLPARTSNOPRTCDRF"));
                customerWork.DeliPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIPARTSNOPRTCDRF"));
                customerWork.DefSalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFSALESSLIPCDRF"));
                customerWork.LavorRateRank = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LAVORRATERANKRF"));
                customerWork.SlipTtlPrn = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLPRNRF"));
                customerWork.DepoBankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOBANKCODERF"));
                customerWork.CustWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTWAREHOUSECDRF"));
                customerWork.QrcodePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("QRCODEPRTCDRF"));
                customerWork.DeliHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORIFICTTLRF"));
                customerWork.BillHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORIFICTTLRF"));
                customerWork.EstmHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORIFICTTLRF"));
                customerWork.RectHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORIFICTTLRF"));
                customerWork.DeliHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIHONORTTLPRTDIVRF"));
                customerWork.BillHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLHONORTTLPRTDIVRF"));
                customerWork.EstmHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTMHONORTTLPRTDIVRF"));
                customerWork.RectHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECTHONORTTLPRTDIVRF"));
                customerWork.Note1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
                customerWork.Note2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
                customerWork.Note3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
                customerWork.Note4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE4RF"));
                customerWork.Note5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE5RF"));
                customerWork.Note6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE6RF"));
                customerWork.Note7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE7RF"));
                customerWork.Note8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE8RF"));
                customerWork.Note9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE9RF"));
                customerWork.Note10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE10RF"));
                // ADD 2009.02.05 >>>
                customerWork.SalesSlipPrtDiv =SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRTDIVRF"));
                customerWork.ShipmSlipPrtDiv =SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMSLIPPRTDIVRF"));
                customerWork.AcpOdrrSlipPrtDiv =SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF"));
                customerWork.EstimatePrtDiv =SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEPRTDIVRF"));
                customerWork.UOESlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESLIPPRTDIVRF"));
                // ADD 2009.02.05 <<<
                // --- ADD 2009/04/06 ------>>>
                customerWork.ReceiptOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIPTOUTPUTCODERF"));
                // --- ADD 2009/04/06 ------<<<
                customerWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAME"));
                customerWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME"));
                customerWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2"));
                customerWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNM"));
                customerWork.CustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTNM"));
                customerWork.OldCustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTNM"));
                customerWork.ClaimSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONNAME"));
                customerWork.DepoBankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOBANKNAME"));
                customerWork.CustWarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTWAREHOUSENAME"));
                customerWork.MngSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONNAME"));
                customerWork.JobTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOBTYPENAME"));
                customerWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAME"));
                // --- ADD 2009/05/20 ------>>>
                customerWork.CustomerEpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMEREPCODERF"));  // 得意先企業コード
                customerWork.CustomerSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSECCODERF"));  // 得意先拠点コード
                customerWork.OnlineKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEKINDDIVRF"));  // オンライン種別区分
                // --- ADD 2009/05/20 ------<<<
                // --- ADD  大矢睦美  2010/01/04 ---------->>>>>
                customerWork.TotalBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALBILLOUTPUTDIVRF"));  // 合計請求書出力区分
                customerWork.DetailBillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILBILLOUTPUTCODERF"));  // 明細請求書出力区分
                customerWork.SlipTtlBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLBILLOUTPUTDIVRF"));  // 伝票合計請求書出力区分
                // --- ADD  大矢睦美  2010/01/04 ----------<<<<<
                customerWork.SimplInqAcntAcntGrId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SIMPLINQACNTACNTGRIDRF"));    // 2010/06/25 Add
                # endregion
            }
        }

        /// <summary>
        /// 得意先マスタの読込結果(SqlDataReader)を得意先マスタワーク(CustomerWork)に格納します。
        /// </summary>
        /// <param name="myReader">得意先マスタの読込結果</param>
        /// <returns>得意先マスタワーク</returns>
        private CustomerWork ReaderToCustomerWork(ref SqlDataReader myReader)
        {
            CustomerWork customerWork = new CustomerWork();

            this.ReaderToCustomerWork(ref myReader, ref customerWork);

            return customerWork;
        }
        #endregion

        // --- ADD 2010/09/26 ---------->>>>>
        /// <summary>
        /// 得意先マスタのALL読込
        /// </summary>
        /// <param name="paraObj">検索Para</param>
        /// <param name="customerWorkList">検索結果</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタをALL読込します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        public int Search(object paraObj,out object customerWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            customerWorkList = null;

            CustomerWork customerWork = paraObj as CustomerWork;

            // 各publicメソッドの開始時にコネクション文字列を取得
            // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return status;

            ArrayList retList = new ArrayList();

            try
            {
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                string sqlText = string.Empty;

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUST.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CUST.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CUST.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CUST.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSUBCODERF" + Environment.NewLine;
                sqlText += " ,CUST.NAMERF" + Environment.NewLine;
                sqlText += " ,CUST.NAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.HONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,CUST.KANARF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMECODERF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.CORPORATEDIVCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.JOBTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,CUST.POSTNORF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS3RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS4RF" + Environment.NewLine;
                sqlText += " ,CUST.HOMETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.PORTABLETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.HOMEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OTHERSTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MAINCONTACTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SEARCHTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE6RF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTCONDRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMCODERF" + Environment.NewLine;
                sqlText += " ,CUST.TRANSSTOPDATERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.MAINSENDMAILADDRCDRF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += " ,CUST.OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTAGENTCHGDATERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCEPTWHOLESALERF" + Environment.NewLine;
                sqlText += " ,CUST.CREDITMNGCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DEPODELCODERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                sqlText += " ,CUST.PURECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO1RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO2RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO3RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CARMNGDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DEFSALESSLIPCDRF" + Environment.NewLine;
                sqlText += " ,CUST.LAVORRATERANKRF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLPRNRF" + Environment.NewLine;
                sqlText += " ,CUST.DEPOBANKCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTWAREHOUSECDRF" + Environment.NewLine;
                sqlText += " ,CUST.QRCODEPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE1RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE2RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE3RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE4RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE5RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE6RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE7RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE8RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE9RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE10RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTIMATEPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.UOESLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECEIPTOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMEREPCODERF " + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSECCODERF " + Environment.NewLine;
                sqlText += " ,CUST.ONLINEKINDDIVRF " + Environment.NewLine;
                sqlText += " ,CUST.TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;
                sqlText += " ,AREA.GUIDENAMERF AS SALESAREANAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAMERF AS CLAIMNAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAME2RF AS CLAIMNAME2" + Environment.NewLine;
                sqlText += " ,CLIM.CUSTOMERSNMRF AS CLAIMSNM" + Environment.NewLine;
                sqlText += " ,CAGT.NAMERF AS CUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,OAGT.NAMERF AS OLDCUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,CLSC.SECTIONGUIDENMRF AS CLAIMSECTIONNAME" + Environment.NewLine;
                sqlText += " ,DBNK.GUIDENAMERF AS DEPOBANKNAME" + Environment.NewLine;
                sqlText += " ,WARE.WAREHOUSENAMERF AS CUSTWAREHOUSENAME" + Environment.NewLine;
                sqlText += " ,MGSC.SECTIONGUIDENMRF AS MNGSECTIONNAME" + Environment.NewLine;
                sqlText += " ,JBTP.GUIDENAMERF AS JOBTYPENAME" + Environment.NewLine;
                sqlText += " ,BSTP.GUIDENAMERF AS BUSINESSTYPENAME" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF AS CUST" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN CUSTOMERRF AS CLIM" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLIM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMCODERF = CLIM.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS CAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERAGENTCDRF = CAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS OAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = OAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.OLDCUSTOMERAGENTCDRF = OAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS CLSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMSECTIONCODERF = CLSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS MGSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = MGSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.MNGSECTIONCODERF = MGSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = WARE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTWAREHOUSECDRF = WARE.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS AREA" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = AREA.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.SALESAREACODERF = AREA.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND AREA.USERGUIDEDIVCDRF = 21  -- 販売エリア区分" + Environment.NewLine;
                sqlText += "    AND AREA.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS DBNK" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = DBNK.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.DEPOBANKCODERF = DBNK.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND DBNK.USERGUIDEDIVCDRF = 46  -- 銀行区分" + Environment.NewLine;
                sqlText += "    AND DBNK.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS JBTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = JBTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.JOBTYPECODERF = JBTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND JBTP.USERGUIDEDIVCDRF = 34  -- 職種区分" + Environment.NewLine;
                sqlText += "    AND JBTP.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS BSTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = BSTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.BUSINESSTYPECODERF = BSTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND BSTP.USERGUIDEDIVCDRF = 33  -- 業種区分" + Environment.NewLine;
                sqlText += "    AND BSTP.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUST.LOGICALDELETECODERF = 0" + Environment.NewLine;

                # endregion

                // Selectコマンドの生成
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                // Parameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    customerWork = new CustomerWork();
                    this.ReaderToCustomerWork(ref myReader, ref customerWork);
                    retList.Add(customerWork);
                }

                customerWorkList = (object)retList;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "得意先マスタのローカルシンク用データの取得に失敗しました。", ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }

                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        // --- ADD 2010/09/26 ----------<<<<<
        // ADD 陳健 K2014/02/06 ------------------------------------->>>>>
        #region ▼前橋京和商会個別

        # region 前橋京和商会個別について、得意先マスタと得意先メモDB読み込み処理
        /// <summary>
        /// 前橋京和商会個別について、得意先マスタと得意先メモDB読み込み処理
        /// </summary>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コード、得意先コードの得意先を戻します</br>
        /// <br>Programmer : 陳健</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        public int MaehashiRead(ConstantManagement.LogicalMode logicalMode, ref object paraList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CustomerWork customerWork = null;

            ArrayList paraCustomList = paraList as ArrayList;

            // オブジェクトの取得(カスタムArray内から検索)
            if (paraCustomList == null)
            {
                base.WriteErrorLog("プログラムエラー。対象パラメータが未指定です", status);
                return status;
            }
            else if (paraCustomList.Count > 0)
            {
                // List内の得意先リストを抽出
                foreach (object obj in paraCustomList)
                {
                    if (customerWork == null)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = obj as CustomerWork;
                        }
                    }
                }
            }

            if (customerWork == null)
            {
                base.WriteErrorLog("プログラムエラー。抽出対象オブジェクトパラメータが未指定です。", status);
                return status;
            }

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            // 各publicメソッドの開始時にコネクション文字列を取得
            // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
                return status;

            SqlConnection sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            try
            {
                // 得意先マスタ読み込み処理
                status = this.MaehashiReadCustomerWork(ref customerWork, ref sqlConnection, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    customSerializeArrayList.Add(customerWork);
                }
            }
            // 例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "得意先マスタの読み込みに失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            paraList = (object)customSerializeArrayList;
            return status;
        }

        /// <summary>
        /// 前橋京和商会個別について、得意先マスタと得意先メモDB読み込み処理
        /// </summary>
        /// <param name="customerWork">得意先ワーククラス</param>
        /// <param name="sqlConnection">ＳＱＬコネクション</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コード、得意先コードの得意先を戻します</br>
        /// <br>Programmer : 陳健</br>
        /// <br>Date       : K2014/02/06</br>
        /// <br>Note       : 得意先情報ガイド表示PKG対応にて得意先ガイド表示区分追加</br>
        /// <br>Programmer : 梶谷貴士</br>
        /// <br>Date       : 2021/05/10</br>
        /// </remarks>
        private int MaehashiReadCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUST.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CUST.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CUST.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CUST.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSUBCODERF" + Environment.NewLine;
                sqlText += " ,CUST.NAMERF" + Environment.NewLine;
                sqlText += " ,CUST.NAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.HONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,CUST.KANARF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMECODERF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.CORPORATEDIVCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.JOBTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,CUST.POSTNORF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS3RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS4RF" + Environment.NewLine;
                sqlText += " ,CUST.HOMETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.PORTABLETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.HOMEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OTHERSTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MAINCONTACTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SEARCHTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE6RF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTCONDRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMCODERF" + Environment.NewLine;
                sqlText += " ,CUST.TRANSSTOPDATERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.MAINSENDMAILADDRCDRF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += " ,CUST.OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTAGENTCHGDATERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCEPTWHOLESALERF" + Environment.NewLine;
                sqlText += " ,CUST.CREDITMNGCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DEPODELCODERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                sqlText += " ,CUST.PURECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO1RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO2RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO3RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CARMNGDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DEFSALESSLIPCDRF" + Environment.NewLine;
                sqlText += " ,CUST.LAVORRATERANKRF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLPRNRF" + Environment.NewLine;
                sqlText += " ,CUST.DEPOBANKCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTWAREHOUSECDRF" + Environment.NewLine;
                sqlText += " ,CUST.QRCODEPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE1RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE2RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE3RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE4RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE5RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE6RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE7RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE8RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE9RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE10RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTIMATEPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.UOESLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECEIPTOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMEREPCODERF " + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSECCODERF " + Environment.NewLine;
                sqlText += " ,CUST.ONLINEKINDDIVRF " + Environment.NewLine;
                sqlText += " ,CUST.TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,CUSTMEMO.NOTEINFORF" + Environment.NewLine;
                sqlText += " ,CUST.SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;
                // --- ADD 梶谷 貴士 2021/05/10 ---------->>>>>
                sqlText += " ,ISNULL(CUSTMEMO.DISPLAYDIVCODERF, 0) AS DISPLAYDIVCODERF" + Environment.NewLine;  //得意先マスタ（メモ情報）のレコードがない場合に0：表示を初期表示するため
                // --- ADD 梶谷 貴士 2021/05/10 ----------<<<<<
                sqlText += " ,AREA.GUIDENAMERF AS SALESAREANAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAMERF AS CLAIMNAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAME2RF AS CLAIMNAME2" + Environment.NewLine;
                sqlText += " ,CLIM.CUSTOMERSNMRF AS CLAIMSNM" + Environment.NewLine;
                sqlText += " ,CAGT.NAMERF AS CUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,OAGT.NAMERF AS OLDCUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,CLSC.SECTIONGUIDENMRF AS CLAIMSECTIONNAME" + Environment.NewLine;
                sqlText += " ,DBNK.GUIDENAMERF AS DEPOBANKNAME" + Environment.NewLine;
                sqlText += " ,WARE.WAREHOUSENAMERF AS CUSTWAREHOUSENAME" + Environment.NewLine;
                sqlText += " ,MGSC.SECTIONGUIDENMRF AS MNGSECTIONNAME" + Environment.NewLine;
                sqlText += " ,JBTP.GUIDENAMERF AS JOBTYPENAME" + Environment.NewLine;
                sqlText += " ,BSTP.GUIDENAMERF AS BUSINESSTYPENAME" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF AS CUST" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN CUSTOMERRF AS CLIM" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLIM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMCODERF = CLIM.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS CAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERAGENTCDRF = CAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS OAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = OAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.OLDCUSTOMERAGENTCDRF = OAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS CLSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMSECTIONCODERF = CLSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS MGSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = MGSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.MNGSECTIONCODERF = MGSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = WARE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTWAREHOUSECDRF = WARE.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS AREA" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = AREA.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.SALESAREACODERF = AREA.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND AREA.USERGUIDEDIVCDRF = 21  -- 販売エリア区分" + Environment.NewLine;
                sqlText += "    AND AREA.LOGICALDELETECODERF = 0" + Environment.NewLine;    // 2010/10/28 Add
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS DBNK" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = DBNK.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.DEPOBANKCODERF = DBNK.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND DBNK.USERGUIDEDIVCDRF = 46  -- 銀行区分" + Environment.NewLine;
                sqlText += "    AND DBNK.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS JBTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = JBTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.JOBTYPECODERF = JBTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND JBTP.USERGUIDEDIVCDRF = 34  -- 職種区分" + Environment.NewLine;
                sqlText += "    AND JBTP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS BSTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = BSTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.BUSINESSTYPECODERF = BSTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND BSTP.USERGUIDEDIVCDRF = 33  -- 業種区分" + Environment.NewLine;
                sqlText += "    AND BSTP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN CUSTOMERMEMORF AS CUSTMEMO" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CUSTMEMO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERCODERF = CUSTMEMO.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUST.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                # endregion

                // Selectコマンドの生成
                SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection);

                // Parameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.MaehashiReaderToCustomerWork(ref myReader, ref customerWork);

                    // 論理削除区分チェック処理
                    status = this.LogicalDeleteCodeCheck(customerWork.LogicalDeleteCode, logicalMode);
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "得意先マスタの読み込みに失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 得意先マスタと得意先メモDBの読込結果(SqlDataReader)を得意先マスタワーク(CustomerWork)に格納します。
        /// </summary>
        /// <param name="myReader">得意先マスタと得意先メモDBの読込結果</param>
        /// <param name="customerWork">得意先マスタワーク</param>
        /// <remarks>
        /// <br>Note       : 得意先情報ガイド表示区分を追加</br>
        /// <br>Programmer : 梶谷 貴士</br>
        /// <br>Date       : 2021/05/10</br>
        /// </remarks>
        private void MaehashiReaderToCustomerWork(ref SqlDataReader myReader, ref CustomerWork customerWork)
        {
            if (myReader != null && customerWork != null)
            {
                # region [格納処理]
                customerWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                customerWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                customerWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                customerWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                customerWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                customerWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                customerWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                customerWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                customerWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                customerWork.CustomerSubCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSUBCODERF"));
                customerWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                customerWork.Name2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
                customerWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                customerWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                customerWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                customerWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
                customerWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
                customerWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"));
                customerWork.CustomerAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERATTRIBUTEDIVRF"));
                customerWork.JobTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOBTYPECODERF"));
                customerWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                customerWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                customerWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                customerWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                customerWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                customerWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                customerWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
                customerWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
                customerWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                customerWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
                customerWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
                customerWork.OthersTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERSTELNORF"));
                customerWork.MainContactCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
                customerWork.SearchTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHTELNORF"));
                customerWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                customerWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONCODERF"));
                customerWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
                customerWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
                customerWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
                customerWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
                customerWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
                customerWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
                customerWork.BillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLOUTPUTCODERF"));
                customerWork.BillOutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLOUTPUTNAMERF"));
                customerWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
                customerWork.CollectMoneyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));
                customerWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
                customerWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
                customerWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
                customerWork.CollectSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTSIGHTRF"));
                customerWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                customerWork.TransStopDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TRANSSTOPDATERF"));
                customerWork.DmOutCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMOUTCODERF"));
                customerWork.DmOutName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMOUTNAMERF"));
                customerWork.MainSendMailAddrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINSENDMAILADDRCDRF"));
                customerWork.MailAddrKindCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE1RF"));
                customerWork.MailAddrKindName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME1RF"));
                customerWork.MailAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS1RF"));
                customerWork.MailSendCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE1RF"));
                customerWork.MailSendName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME1RF"));
                customerWork.MailAddrKindCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE2RF"));
                customerWork.MailAddrKindName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME2RF"));
                customerWork.MailAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS2RF"));
                customerWork.MailSendCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE2RF"));
                customerWork.MailSendName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME2RF"));
                customerWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
                customerWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
                customerWork.OldCustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTCDRF"));
                customerWork.CustAgentChgDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CUSTAGENTCHGDATERF"));
                customerWork.AcceptWholeSale = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTWHOLESALERF"));
                customerWork.CreditMngCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITMNGCODERF"));
                customerWork.DepoDelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPODELCODERF"));
                customerWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                customerWork.CustSlipNoMngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNOMNGCDRF"));
                customerWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                customerWork.CustCTaXLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCTAXLAYREFCDRF"));
                customerWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                customerWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                customerWork.TotalAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMNTDSPWAYREFRF"));
                customerWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
                customerWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
                customerWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
                customerWork.SalesUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCFRCPROCCDRF"));
                customerWork.SalesMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESMONEYFRCPROCCDRF"));
                customerWork.SalesCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));
                customerWork.CustomerSlipNoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERSLIPNODIVRF"));
                customerWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NTIMECALCSTDATERF"));
                customerWork.CustomerAgent = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTRF"));
                customerWork.ClaimSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));
                customerWork.CarMngDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGDIVCDRF"));
                customerWork.BillPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLPARTSNOPRTCDRF"));
                customerWork.DeliPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIPARTSNOPRTCDRF"));
                customerWork.DefSalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFSALESSLIPCDRF"));
                customerWork.LavorRateRank = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LAVORRATERANKRF"));
                customerWork.SlipTtlPrn = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLPRNRF"));
                customerWork.DepoBankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOBANKCODERF"));
                customerWork.CustWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTWAREHOUSECDRF"));
                customerWork.QrcodePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("QRCODEPRTCDRF"));
                customerWork.DeliHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORIFICTTLRF"));
                customerWork.BillHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORIFICTTLRF"));
                customerWork.EstmHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORIFICTTLRF"));
                customerWork.RectHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORIFICTTLRF"));
                customerWork.DeliHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIHONORTTLPRTDIVRF"));
                customerWork.BillHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLHONORTTLPRTDIVRF"));
                customerWork.EstmHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTMHONORTTLPRTDIVRF"));
                customerWork.RectHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECTHONORTTLPRTDIVRF"));
                customerWork.Note1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
                customerWork.Note2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
                customerWork.Note3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
                customerWork.Note4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE4RF"));
                customerWork.Note5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE5RF"));
                customerWork.Note6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE6RF"));
                customerWork.Note7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE7RF"));
                customerWork.Note8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE8RF"));
                customerWork.Note9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE9RF"));
                customerWork.Note10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE10RF"));
                customerWork.SalesSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRTDIVRF"));
                customerWork.ShipmSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMSLIPPRTDIVRF"));
                customerWork.AcpOdrrSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF"));
                customerWork.EstimatePrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEPRTDIVRF"));
                customerWork.UOESlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESLIPPRTDIVRF"));
                customerWork.ReceiptOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIPTOUTPUTCODERF"));
                customerWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAME"));
                customerWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME"));
                customerWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2"));
                customerWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNM"));
                customerWork.CustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTNM"));
                customerWork.OldCustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTNM"));
                customerWork.ClaimSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONNAME"));
                customerWork.DepoBankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOBANKNAME"));
                customerWork.CustWarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTWAREHOUSENAME"));
                customerWork.MngSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONNAME"));
                customerWork.JobTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOBTYPENAME"));
                customerWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAME"));
                customerWork.CustomerEpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMEREPCODERF"));  // 得意先企業コード
                customerWork.CustomerSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSECCODERF"));  // 得意先拠点コード
                customerWork.OnlineKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEKINDDIVRF"));  // オンライン種別区分
                customerWork.TotalBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALBILLOUTPUTDIVRF"));  // 合計請求書出力区分
                customerWork.DetailBillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILBILLOUTPUTCODERF"));  // 明細請求書出力区分
                customerWork.SlipTtlBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLBILLOUTPUTDIVRF"));  // 伝票合計請求書出力区分
                customerWork.NoteInfo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTEINFORF"));  // メモ
                customerWork.SimplInqAcntAcntGrId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SIMPLINQACNTACNTGRIDRF"));
                // --- ADD 梶谷 貴士 2021/05/10 ---------->>>>>
                customerWork.DisplayDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYDIVCODERF"));
                // --- ADD 梶谷 貴士 2021/05/10 ----------<<<<<
                # endregion
            }
        }

        # endregion

        # region 前橋京和商会個別について、得意先マスタと得意先メモDB登録処理
        /// <summary>
        /// 前橋京和商会個別について、得意先マスタと得意先メモDB登録処理
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <param name="duplicationItemList">重複エラー時の重複項目</param>
        /// <param name="carMngNo">得意先と車両を同時登録する際の車両管理番号</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタと得意先メモDBを登録、更新します</br>
        /// <br>Programmer : 陳健</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        public int MaehashiWrite(ref object paraList, out ArrayList duplicationItemList, int carMngNo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMsg = "";
            duplicationItemList = new ArrayList();

            int customerCode = 0;
            CustomerWork customerWork = null;

            ArrayList paraCustomList = paraList as ArrayList;


            // オブジェクトの取得(カスタムArray内から検索)
            if (paraCustomList == null)
            {
                base.WriteErrorLog("プログラムエラー。対象パラメータが未指定です", status);
                return status;
            }
            else if (paraCustomList.Count > 0)
            {
                // List内の得意先・備考・家族構成リストを抽出
                foreach (object obj in paraCustomList)
                {
                    if (customerWork == null)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = obj as CustomerWork;

                            // 得意先コードと企業コードを待避
                            if (customerCode == 0)
                            {
                                customerCode = customerWork.CustomerCode;
                            }
                        }
                    }
                }
            }

            if (customerWork == null)
            {
                base.WriteErrorLog("プログラムエラー。抽出対象オブジェクトパラメータが未指定です。", status);
                return status;
            }

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ControlExclusiveOrderAccess ctrlExclsvOdAcs = null;

            try
            {
                // 登録前の得意先情報用
                CustomerWork customerWorkBef = new CustomerWork();

                CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                CustomerChangeWork customerChangeWork = new CustomerChangeWork();
                int CusChangestatus = 0;

                ArrayList WriteCustomList = new ArrayList();
                ArrayList changeWorkLogicalDeleteList = new ArrayList();
                ArrayList changeWorkWriteList = new ArrayList();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    // 各publicメソッドの開始時にコネクション文字列を取得
                    // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    // トランザクションスタート
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    // ログイン情報取得クラスをインスタンス化
                    ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();
                    changeWorkLogicalDeleteList = new ArrayList();
                    changeWorkWriteList = new ArrayList();

                    for (int i = 0; i < paraCustomList.Count; i++)
                    {
                        customerWork = paraCustomList[i] as CustomerWork;
                        customerCode = customerWork.CustomerCode;
                        // ================================================================================= //
                        // 得意先更新前情報取得
                        // ================================================================================= //
                        if (customerWork != null)
                        {
                            if ((customerWork.EnterpriseCode.Trim() != "") && (customerWork.CustomerCode != 0))
                            {
                                // 2009.02.20
                                // Read用コネクションをインスタンス化
                                SqlConnection sqlConnection_read = new SqlConnection(connectionText);
                                sqlConnection_read.Open();

                                customerWorkBef.EnterpriseCode = customerWork.EnterpriseCode;
                                customerWorkBef.CustomerCode = customerWork.CustomerCode;

                                // 得意先情報取得（登録前）
                                status = this.MaehashiReadCustomerWork(ref customerWorkBef, ref sqlConnection_read, ConstantManagement.LogicalMode.GetData0);

                                if (customerWork.CreditMngCode == 1)
                                {
                                    customerChangeWork = new CustomerChangeWork();
                                    customerChangeWork.EnterpriseCode = customerWork.EnterpriseCode;
                                    customerChangeWork.CustomerCode = customerWork.CustomerCode;
                                    // 得意先マスタ(変動情報)取得
                                    CusChangestatus = customerChangeDB.ReadProc(ref customerChangeWork, 0, ref sqlConnection_read);
                                }   

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    // 該当データ無しの場合は正常とする
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                sqlConnection_read.Close();
                            }
                        }

                        // ================================================================================= //
                        // 得意先コードの採番
                        // ================================================================================= //
                        // 得意先コードが入っていない場合のみ
                        if (customerCode == 0)
                        {
                            // 入力拠点コードを退避
                            string sectionCode = customerWork.InpSectionCode;

                            // 得意先コード採番処理
                            status = this.CreateCustomerCode(customerWork.EnterpriseCode, sectionCode, out customerCode, out retMsg, ref sqlConnection, ref sqlTransaction);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (customerWork.CustomerCode != 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }

                                if (customerWork != null)
                                {
                                    if (customerWork.CustomerCode == 0)
                                    {
                                        customerWork.CustomerCode = customerCode;
                                    }

                                    if (customerWork.ClaimCode == 0)
                                    {
                                        customerWork.ClaimCode = customerCode;
                                    }

                                }
                            }
                            else
                            {
                                duplicationItemList.Add(retMsg);
                            }
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 得意先マスタ書き込みリスト作成
                            WriteCustomList.Add(customerWork);

                            // 得意先マスタ(変動情報)書き込みリスト作成
                            // 与信管理=1:する　且つ　親得意先
                            if ((customerWork.CreditMngCode == 1) && (customerWork.ClaimCode == customerWork.CustomerCode))
                            {
                                if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // 復旧処理
                                    if (customerWork.WriteDiv == 1) // 0:得意先マスタ 1:得意先一括修正
                                    {
                                        customerChangeWork.CreditMoney = customerWork.CreditMoney;
                                        customerChangeWork.WarningCreditMoney = customerWork.WarningCreditMoney;
                                        customerChangeWork.PrsntAccRecBalance = customerWork.PrsntAccRecBalance;
                                    }
                                    changeWorkLogicalDeleteList.Add(customerChangeWork);
                                }
                                if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    // 新規作成処理
                                    if (customerWork.WriteDiv == 1) // 0:得意先マスタ 1:得意先一括修正
                                    {
                                        customerChangeWork.CreditMoney = customerWork.CreditMoney;
                                        customerChangeWork.WarningCreditMoney = customerWork.WarningCreditMoney;
                                        customerChangeWork.PrsntAccRecBalance = customerWork.PrsntAccRecBalance;
                                    }
                                    changeWorkWriteList.Add(customerChangeWork);
                                }
                            }

                        }
                    }

                    // 得意先マスタ書込
                    for (int i = 0; i < WriteCustomList.Count; i++)
                    {
                        customerWork = WriteCustomList[i] as CustomerWork;
                        status = this.MaehashiWriteCustomerWork(ref customerWork, ref sqlConnection, ref sqlTransaction, ref duplicationItemList);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            customSerializeArrayList.Add((CustomerWork)customerWork);
                        }
                    }
                    // << 得意先マスタ(変動情報)書き込み処理 >>
                    if (changeWorkLogicalDeleteList.Count > 0)
                    {
                        if (customerWork.WriteDiv == 1) // 0:得意先マスタ 1:得意先一括修正
                        {
                            // 更新処理
                            customerChangeDB.WriteProc(ref changeWorkLogicalDeleteList, ref sqlConnection, ref sqlTransaction);
                        }
                        else
                        {
                            // 復旧処理
                            customerChangeDB.LogicalDeleteProc(ref changeWorkLogicalDeleteList, 1, ref sqlConnection, ref sqlTransaction);
                        }
                    }
                    if (changeWorkWriteList.Count > 0)
                    {
                        // 新規作成処理
                        customerChangeDB.WriteProc(ref changeWorkWriteList, ref sqlConnection, ref sqlTransaction);
                    }

                    // コミット
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        sqlTransaction.Commit();
                    }
                }
                else
                {
                    if (retMsg.Trim() != "")
                    {
                        duplicationItemList.Add(retMsg);
                    }
                }
            }
            // 例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "得意先マスタの書き込みに失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {

                // トランザクション破棄
                if (sqlTransaction != null) sqlTransaction.Dispose();

                // コネクション破棄
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            paraList = (object)customSerializeArrayList;
            return status;
        }

        /// <summary>
        /// 前橋京和商会個別について、得意先データ登録処理
        /// </summary>
        /// <param name="customerWork">登録受得意先報</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="duplicationItemList">重複エラー時の重複項目</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先情報を登録、更新します</br>
        /// <br>Programmer : 陳健</br>
        /// <br>Date       : K2014/02/06</br>
        /// <br>Note       : 得意先情報ガイド表示区分を追加</br>
        /// <br>Programmer : 梶谷 貴士</br>
        /// <br>Date       : 2021/05/10</br>
        /// </remarks>
        private int MaehashiWriteCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref ArrayList duplicationItemList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;
            DateTime updDateTimeTmp = customerWork.UpdateDateTime;
            try
            {
                #region 得意先マスタDBの処理
                // Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, CUSTOMERCODERF FROM CUSTOMERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction))
                {
                    // Parameterオブジェクトのクリア
                    sqlCommand.Parameters.Clear();

                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomercode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                    findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                    sqlCommand.CommandTimeout = 3600;
                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                        if (_updateDateTime != customerWork.UpdateDateTime)
                        {
                            // 新規登録で該当データ有りの場合には重複
                            if (customerWork.UpdateDateTime == DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            // 既存データで更新日時違いの場合には排他
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }

                            if ((myReader != null) && (!myReader.IsClosed))
                            {
                                myReader.Close();
                            }

                            return status;
                        }

                        string sqlText = string.Empty;

                        if (customerWork.WriteDiv == 0) // 0:得意先マスタ 1:得意先一括修正 
                        {
                            # region [UPDATE文]
                            sqlText += "UPDATE CUSTOMERRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSUBCODERF = @CUSTOMERSUBCODE" + Environment.NewLine;
                            sqlText += " ,NAMERF = @NAME" + Environment.NewLine;
                            sqlText += " ,NAME2RF = @NAME2" + Environment.NewLine;
                            sqlText += " ,HONORIFICTITLERF = @HONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,KANARF = @KANA" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSNMRF = @CUSTOMERSNM" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMECODERF = @OUTPUTNAMECODE" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMERF = @OUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,CORPORATEDIVCODERF = @CORPORATEDIVCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERATTRIBUTEDIVRF = @CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,JOBTYPECODERF = @JOBTYPECODE" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF = @BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF = @SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,POSTNORF = @POSTNO" + Environment.NewLine;
                            sqlText += " ,ADDRESS1RF = @ADDRESS1" + Environment.NewLine;
                            sqlText += " ,ADDRESS3RF = @ADDRESS3" + Environment.NewLine;
                            sqlText += " ,ADDRESS4RF = @ADDRESS4" + Environment.NewLine;
                            sqlText += " ,HOMETELNORF = @HOMETELNO" + Environment.NewLine;
                            sqlText += " ,OFFICETELNORF = @OFFICETELNO" + Environment.NewLine;
                            sqlText += " ,PORTABLETELNORF = @PORTABLETELNO" + Environment.NewLine;
                            sqlText += " ,HOMEFAXNORF = @HOMEFAXNO" + Environment.NewLine;
                            sqlText += " ,OFFICEFAXNORF = @OFFICEFAXNO" + Environment.NewLine;
                            sqlText += " ,OTHERSTELNORF = @OTHERSTELNO" + Environment.NewLine;
                            sqlText += " ,MAINCONTACTCODERF = @MAINCONTACTCODE" + Environment.NewLine;
                            sqlText += " ,SEARCHTELNORF = @SEARCHTELNO" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF = @MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF = @INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE1RF = @CUSTANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE2RF = @CUSTANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE3RF = @CUSTANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE4RF = @CUSTANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE5RF = @CUSTANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE6RF = @CUSTANALYSCODE6" + Environment.NewLine;
                            sqlText += " ,BILLOUTPUTCODERF = @BILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,BILLOUTPUTNAMERF = @BILLOUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,TOTALDAYRF = @TOTALDAY" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYCODERF = @COLLECTMONEYCODE" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYNAMERF = @COLLECTMONEYNAME" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYDAYRF = @COLLECTMONEYDAY" + Environment.NewLine;
                            sqlText += " ,COLLECTCONDRF = @COLLECTCOND" + Environment.NewLine;
                            sqlText += " ,COLLECTSIGHTRF = @COLLECTSIGHT" + Environment.NewLine;
                            sqlText += " ,CLAIMCODERF = @CLAIMCODE" + Environment.NewLine;
                            sqlText += " ,TRANSSTOPDATERF = @TRANSSTOPDATE" + Environment.NewLine;
                            sqlText += " ,DMOUTCODERF = @DMOUTCODE" + Environment.NewLine;
                            sqlText += " ,DMOUTNAMERF = @DMOUTNAME" + Environment.NewLine;
                            sqlText += " ,MAINSENDMAILADDRCDRF = @MAINSENDMAILADDRCD" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE1RF = @MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF = @MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF = @MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF = @MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME1RF = @MAILSENDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF = @MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF = @MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF = @MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF = @MAILSENDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME2RF = @MAILSENDNAME2" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTCDRF = @CUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,BILLCOLLECTERCDRF = @BILLCOLLECTERCD" + Environment.NewLine;
                            sqlText += " ,OLDCUSTOMERAGENTCDRF = @OLDCUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,CUSTAGENTCHGDATERF = @CUSTAGENTCHGDATE" + Environment.NewLine;
                            sqlText += " ,ACCEPTWHOLESALERF = @ACCEPTWHOLESALE" + Environment.NewLine;
                            sqlText += " ,CREDITMNGCODERF = @CREDITMNGCODE" + Environment.NewLine;
                            sqlText += " ,DEPODELCODERF = @DEPODELCODE" + Environment.NewLine;
                            sqlText += " ,ACCRECDIVCDRF = @ACCRECDIVCD" + Environment.NewLine;
                            sqlText += " ,CUSTSLIPNOMNGCDRF = @CUSTSLIPNOMNGCD" + Environment.NewLine;
                            sqlText += " ,PURECODERF = @PURECODE" + Environment.NewLine;
                            sqlText += " ,CUSTCTAXLAYREFCDRF = @CUSTCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,CONSTAXLAYMETHODRF = @CONSTAXLAYMETHOD" + Environment.NewLine;
                            sqlText += " ,TOTALAMOUNTDISPWAYCDRF = @TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                            sqlText += " ,TOTALAMNTDSPWAYREFRF = @TOTALAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO1RF = @ACCOUNTNOINFO1" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO2RF = @ACCOUNTNOINFO2" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO3RF = @ACCOUNTNOINFO3" + Environment.NewLine;
                            sqlText += " ,SALESUNPRCFRCPROCCDRF = @SALESUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,SALESMONEYFRCPROCCDRF = @SALESMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,SALESCNSTAXFRCPROCCDRF = @SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSLIPNODIVRF = @CUSTOMERSLIPNODIV" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF = @NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTRF = @CUSTOMERAGENT" + Environment.NewLine;
                            sqlText += " ,CLAIMSECTIONCODERF = @CLAIMSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,CARMNGDIVCDRF = @CARMNGDIVCD" + Environment.NewLine;
                            sqlText += " ,BILLPARTSNOPRTCDRF = @BILLPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,DELIPARTSNOPRTCDRF = @DELIPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,DEFSALESSLIPCDRF = @DEFSALESSLIPCD" + Environment.NewLine;
                            sqlText += " ,LAVORRATERANKRF = @LAVORRATERANK" + Environment.NewLine;
                            sqlText += " ,SLIPTTLPRNRF = @SLIPTTLPRN" + Environment.NewLine;
                            sqlText += " ,DEPOBANKCODERF = @DEPOBANKCODE" + Environment.NewLine;
                            sqlText += " ,CUSTWAREHOUSECDRF = @CUSTWAREHOUSECD" + Environment.NewLine;
                            sqlText += " ,QRCODEPRTCDRF = @QRCODEPRTCD" + Environment.NewLine;
                            sqlText += " ,DELIHONORIFICTTLRF = @DELIHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,BILLHONORIFICTTLRF = @BILLHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,ESTMHONORIFICTTLRF = @ESTMHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,RECTHONORIFICTTLRF = @RECTHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,DELIHONORTTLPRTDIVRF = @DELIHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,BILLHONORTTLPRTDIVRF = @BILLHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,ESTMHONORTTLPRTDIVRF = @ESTMHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,RECTHONORTTLPRTDIVRF = @RECTHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,NOTE1RF = @NOTE1" + Environment.NewLine;
                            sqlText += " ,NOTE2RF = @NOTE2" + Environment.NewLine;
                            sqlText += " ,NOTE3RF = @NOTE3" + Environment.NewLine;
                            sqlText += " ,NOTE4RF = @NOTE4" + Environment.NewLine;
                            sqlText += " ,NOTE5RF = @NOTE5" + Environment.NewLine;
                            sqlText += " ,NOTE6RF = @NOTE6" + Environment.NewLine;
                            sqlText += " ,NOTE7RF = @NOTE7" + Environment.NewLine;
                            sqlText += " ,NOTE8RF = @NOTE8" + Environment.NewLine;
                            sqlText += " ,NOTE9RF = @NOTE9" + Environment.NewLine;
                            sqlText += " ,NOTE10RF = @NOTE10" + Environment.NewLine;
                            sqlText += " ,SALESSLIPPRTDIVRF = @SALESSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,SHIPMSLIPPRTDIVRF = @SHIPMSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,ACPODRRSLIPPRTDIVRF = @ACPODRRSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,ESTIMATEPRTDIVRF = @ESTIMATEPRTDIV" + Environment.NewLine;
                            sqlText += " ,UOESLIPPRTDIVRF = @UOESLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,RECEIPTOUTPUTCODERF = @RECEIPTOUTPUTCODE" + Environment.NewLine;
                            sqlText += " , CUSTOMEREPCODERF = @CUSTOMEREPCODE" + Environment.NewLine;
                            sqlText += " , CUSTOMERSECCODERF = @CUSTOMERSECCODE" + Environment.NewLine;
                            sqlText += " , ONLINEKINDDIVRF = @ONLINEKINDDIV" + Environment.NewLine;
                            sqlText += " , TOTALBILLOUTPUTDIVRF = @TOTALBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " , DETAILBILLOUTPUTCODERF = @DETAILBILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " , SLIPTTLBILLOUTPUTDIVRF = @SLIPTTLBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " , SIMPLINQACNTACNTGRIDRF = @SIMPLINQACNTACNTGRID" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            # endregion
                        }
                        else if (customerWork.WriteDiv == 1)  // 0:得意先マスタ 1:得意先一括修正 
                        {
                            # region [UPDATE文]
                            sqlText += "UPDATE CUSTOMERRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSUBCODERF = @CUSTOMERSUBCODE" + Environment.NewLine;
                            sqlText += " ,NAMERF = @NAME" + Environment.NewLine;
                            sqlText += " ,NAME2RF = @NAME2" + Environment.NewLine;
                            sqlText += " ,HONORIFICTITLERF = @HONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,KANARF = @KANA" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSNMRF = @CUSTOMERSNM" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMECODERF = @OUTPUTNAMECODE" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMERF = @OUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,CORPORATEDIVCODERF = @CORPORATEDIVCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERATTRIBUTEDIVRF = @CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,JOBTYPECODERF = @JOBTYPECODE" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF = @BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF = @SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,POSTNORF = @POSTNO" + Environment.NewLine;
                            sqlText += " ,ADDRESS1RF = @ADDRESS1" + Environment.NewLine;
                            sqlText += " ,ADDRESS3RF = @ADDRESS3" + Environment.NewLine;
                            sqlText += " ,ADDRESS4RF = @ADDRESS4" + Environment.NewLine;
                            sqlText += " ,HOMETELNORF = @HOMETELNO" + Environment.NewLine;
                            sqlText += " ,OFFICETELNORF = @OFFICETELNO" + Environment.NewLine;
                            sqlText += " ,PORTABLETELNORF = @PORTABLETELNO" + Environment.NewLine;
                            sqlText += " ,HOMEFAXNORF = @HOMEFAXNO" + Environment.NewLine;
                            sqlText += " ,OFFICEFAXNORF = @OFFICEFAXNO" + Environment.NewLine;
                            sqlText += " ,OTHERSTELNORF = @OTHERSTELNO" + Environment.NewLine;
                            sqlText += " ,MAINCONTACTCODERF = @MAINCONTACTCODE" + Environment.NewLine;
                            sqlText += " ,SEARCHTELNORF = @SEARCHTELNO" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF = @MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF = @INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE1RF = @CUSTANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE2RF = @CUSTANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE3RF = @CUSTANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE4RF = @CUSTANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE5RF = @CUSTANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE6RF = @CUSTANALYSCODE6" + Environment.NewLine;
                            sqlText += " ,BILLOUTPUTCODERF = @BILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,BILLOUTPUTNAMERF = @BILLOUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,TOTALDAYRF = @TOTALDAY" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYCODERF = @COLLECTMONEYCODE" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYNAMERF = @COLLECTMONEYNAME" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYDAYRF = @COLLECTMONEYDAY" + Environment.NewLine;
                            sqlText += " ,COLLECTCONDRF = @COLLECTCOND" + Environment.NewLine;
                            sqlText += " ,COLLECTSIGHTRF = @COLLECTSIGHT" + Environment.NewLine;
                            sqlText += " ,CLAIMCODERF = @CLAIMCODE" + Environment.NewLine;
                            sqlText += " ,TRANSSTOPDATERF = @TRANSSTOPDATE" + Environment.NewLine;
                            sqlText += " ,DMOUTCODERF = @DMOUTCODE" + Environment.NewLine;
                            sqlText += " ,DMOUTNAMERF = @DMOUTNAME" + Environment.NewLine;
                            sqlText += " ,MAINSENDMAILADDRCDRF = @MAINSENDMAILADDRCD" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE1RF = @MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF = @MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF = @MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF = @MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME1RF = @MAILSENDNAME1" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF = @MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF = @MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF = @MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF = @MAILSENDCODE2" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME2RF = @MAILSENDNAME2" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTCDRF = @CUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,BILLCOLLECTERCDRF = @BILLCOLLECTERCD" + Environment.NewLine;
                            sqlText += " ,OLDCUSTOMERAGENTCDRF = @OLDCUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,CUSTAGENTCHGDATERF = @CUSTAGENTCHGDATE" + Environment.NewLine;
                            sqlText += " ,ACCEPTWHOLESALERF = @ACCEPTWHOLESALE" + Environment.NewLine;
                            sqlText += " ,CREDITMNGCODERF = @CREDITMNGCODE" + Environment.NewLine;
                            sqlText += " ,DEPODELCODERF = @DEPODELCODE" + Environment.NewLine;
                            sqlText += " ,ACCRECDIVCDRF = @ACCRECDIVCD" + Environment.NewLine;
                            sqlText += " ,CUSTSLIPNOMNGCDRF = @CUSTSLIPNOMNGCD" + Environment.NewLine;
                            sqlText += " ,PURECODERF = @PURECODE" + Environment.NewLine;
                            sqlText += " ,CUSTCTAXLAYREFCDRF = @CUSTCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,CONSTAXLAYMETHODRF = @CONSTAXLAYMETHOD" + Environment.NewLine;
                            sqlText += " ,TOTALAMOUNTDISPWAYCDRF = @TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                            sqlText += " ,TOTALAMNTDSPWAYREFRF = @TOTALAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO1RF = @ACCOUNTNOINFO1" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO2RF = @ACCOUNTNOINFO2" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO3RF = @ACCOUNTNOINFO3" + Environment.NewLine;
                            sqlText += " ,SALESUNPRCFRCPROCCDRF = @SALESUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,SALESMONEYFRCPROCCDRF = @SALESMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,SALESCNSTAXFRCPROCCDRF = @SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSLIPNODIVRF = @CUSTOMERSLIPNODIV" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF = @NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTRF = @CUSTOMERAGENT" + Environment.NewLine;
                            sqlText += " ,CLAIMSECTIONCODERF = @CLAIMSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,CARMNGDIVCDRF = @CARMNGDIVCD" + Environment.NewLine;
                            sqlText += " ,BILLPARTSNOPRTCDRF = @BILLPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,DELIPARTSNOPRTCDRF = @DELIPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,DEFSALESSLIPCDRF = @DEFSALESSLIPCD" + Environment.NewLine;
                            sqlText += " ,LAVORRATERANKRF = @LAVORRATERANK" + Environment.NewLine;
                            sqlText += " ,SLIPTTLPRNRF = @SLIPTTLPRN" + Environment.NewLine;
                            sqlText += " ,DEPOBANKCODERF = @DEPOBANKCODE" + Environment.NewLine;
                            sqlText += " ,CUSTWAREHOUSECDRF = @CUSTWAREHOUSECD" + Environment.NewLine;
                            sqlText += " ,QRCODEPRTCDRF = @QRCODEPRTCD" + Environment.NewLine;
                            sqlText += " ,DELIHONORIFICTTLRF = @DELIHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,BILLHONORIFICTTLRF = @BILLHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,ESTMHONORIFICTTLRF = @ESTMHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,RECTHONORIFICTTLRF = @RECTHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,DELIHONORTTLPRTDIVRF = @DELIHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,BILLHONORTTLPRTDIVRF = @BILLHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,ESTMHONORTTLPRTDIVRF = @ESTMHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,RECTHONORTTLPRTDIVRF = @RECTHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,NOTE1RF = @NOTE1" + Environment.NewLine;
                            sqlText += " ,NOTE2RF = @NOTE2" + Environment.NewLine;
                            sqlText += " ,NOTE3RF = @NOTE3" + Environment.NewLine;
                            sqlText += " ,NOTE4RF = @NOTE4" + Environment.NewLine;
                            sqlText += " ,NOTE5RF = @NOTE5" + Environment.NewLine;
                            sqlText += " ,NOTE6RF = @NOTE6" + Environment.NewLine;
                            sqlText += " ,NOTE7RF = @NOTE7" + Environment.NewLine;
                            sqlText += " ,NOTE8RF = @NOTE8" + Environment.NewLine;
                            sqlText += " ,NOTE9RF = @NOTE9" + Environment.NewLine;
                            sqlText += " ,NOTE10RF = @NOTE10" + Environment.NewLine;
                            sqlText += " ,RECEIPTOUTPUTCODERF = @RECEIPTOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,TOTALBILLOUTPUTDIVRF = @TOTALBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,DETAILBILLOUTPUTCODERF = @DETAILBILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,SLIPTTLBILLOUTPUTDIVRF = @SLIPTTLBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,SALESSLIPPRTDIVRF = @SALESSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,SHIPMSLIPPRTDIVRF = @SHIPMSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,ACPODRRSLIPPRTDIVRF = @ACPODRRSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,ESTIMATEPRTDIVRF = @ESTIMATEPRTDIV" + Environment.NewLine;
                            sqlText += " ,UOESLIPPRTDIVRF = @UOESLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,SIMPLINQACNTACNTGRIDRF = @SIMPLINQACNTACNTGRID" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            # endregion
                        }
                        sqlCommand.CommandText = sqlText;

                        // KEYコマンドを再設定
                        findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (customerWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                            if ((myReader != null) && (!myReader.IsClosed))
                            {
                                myReader.Close();
                            }

                            return status;
                        }

                        // 新規作成時のSQL文を生成

                        string sqlText = string.Empty;
                        if (customerWork.WriteDiv == 0) // 0:得意先マスタ 1:得意先一括修正
                        {
                            # region [INSERT文]
                            sqlText += "INSERT INTO CUSTOMERRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSUBCODERF" + Environment.NewLine;
                            sqlText += " ,NAMERF" + Environment.NewLine;
                            sqlText += " ,NAME2RF" + Environment.NewLine;
                            sqlText += " ,HONORIFICTITLERF" + Environment.NewLine;
                            sqlText += " ,KANARF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMECODERF" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMERF" + Environment.NewLine;
                            sqlText += " ,CORPORATEDIVCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                            sqlText += " ,JOBTYPECODERF" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                            sqlText += " ,POSTNORF" + Environment.NewLine;
                            sqlText += " ,ADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,ADDRESS3RF" + Environment.NewLine;
                            sqlText += " ,ADDRESS4RF" + Environment.NewLine;
                            sqlText += " ,HOMETELNORF" + Environment.NewLine;
                            sqlText += " ,OFFICETELNORF" + Environment.NewLine;
                            sqlText += " ,PORTABLETELNORF" + Environment.NewLine;
                            sqlText += " ,HOMEFAXNORF" + Environment.NewLine;
                            sqlText += " ,OFFICEFAXNORF" + Environment.NewLine;
                            sqlText += " ,OTHERSTELNORF" + Environment.NewLine;
                            sqlText += " ,MAINCONTACTCODERF" + Environment.NewLine;
                            sqlText += " ,SEARCHTELNORF" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE1RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE2RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE3RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE4RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE5RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE6RF" + Environment.NewLine;
                            sqlText += " ,BILLOUTPUTCODERF" + Environment.NewLine;
                            sqlText += " ,BILLOUTPUTNAMERF" + Environment.NewLine;
                            sqlText += " ,TOTALDAYRF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYCODERF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYNAMERF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYDAYRF" + Environment.NewLine;
                            sqlText += " ,COLLECTCONDRF" + Environment.NewLine;
                            sqlText += " ,COLLECTSIGHTRF" + Environment.NewLine;
                            sqlText += " ,CLAIMCODERF" + Environment.NewLine;
                            sqlText += " ,TRANSSTOPDATERF" + Environment.NewLine;
                            sqlText += " ,DMOUTCODERF" + Environment.NewLine;
                            sqlText += " ,DMOUTNAMERF" + Environment.NewLine;
                            sqlText += " ,MAINSENDMAILADDRCDRF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME2RF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,BILLCOLLECTERCDRF" + Environment.NewLine;
                            sqlText += " ,OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTAGENTCHGDATERF" + Environment.NewLine;
                            sqlText += " ,ACCEPTWHOLESALERF" + Environment.NewLine;
                            sqlText += " ,CREDITMNGCODERF" + Environment.NewLine;
                            sqlText += " ,DEPODELCODERF" + Environment.NewLine;
                            sqlText += " ,ACCRECDIVCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                            sqlText += " ,PURECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                            sqlText += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlText += " ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                            sqlText += " ,TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                            sqlText += " ,SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTRF" + Environment.NewLine;
                            sqlText += " ,CLAIMSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,CARMNGDIVCDRF" + Environment.NewLine;
                            sqlText += " ,BILLPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DELIPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DEFSALESSLIPCDRF" + Environment.NewLine;
                            sqlText += " ,LAVORRATERANKRF" + Environment.NewLine;
                            sqlText += " ,SLIPTTLPRNRF" + Environment.NewLine;
                            sqlText += " ,DEPOBANKCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTWAREHOUSECDRF" + Environment.NewLine;
                            sqlText += " ,QRCODEPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DELIHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,BILLHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,ESTMHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,RECTHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,NOTE1RF" + Environment.NewLine;
                            sqlText += " ,NOTE2RF" + Environment.NewLine;
                            sqlText += " ,NOTE3RF" + Environment.NewLine;
                            sqlText += " ,NOTE4RF" + Environment.NewLine;
                            sqlText += " ,NOTE5RF" + Environment.NewLine;
                            sqlText += " ,NOTE6RF" + Environment.NewLine;
                            sqlText += " ,NOTE7RF" + Environment.NewLine;
                            sqlText += " ,NOTE8RF" + Environment.NewLine;
                            sqlText += " ,NOTE9RF" + Environment.NewLine;
                            sqlText += " ,NOTE10RF" + Environment.NewLine;
                            sqlText += " ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ESTIMATEPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,UOESLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,RECEIPTOUTPUTCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMEREPCODERF " + Environment.NewLine;
                            sqlText += " ,CUSTOMERSECCODERF " + Environment.NewLine;
                            sqlText += " ,ONLINEKINDDIVRF " + Environment.NewLine;
                            sqlText += " ,TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                            sqlText += " ,DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                            sqlText += " ,SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                            sqlText += " ,SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSUBCODE" + Environment.NewLine;
                            sqlText += " ,@NAME" + Environment.NewLine;
                            sqlText += " ,@NAME2" + Environment.NewLine;
                            sqlText += " ,@HONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,@KANA" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSNM" + Environment.NewLine;
                            sqlText += " ,@OUTPUTNAMECODE" + Environment.NewLine;
                            sqlText += " ,@OUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,@CORPORATEDIVCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,@JOBTYPECODE" + Environment.NewLine;
                            sqlText += " ,@BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,@SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,@POSTNO" + Environment.NewLine;
                            sqlText += " ,@ADDRESS1" + Environment.NewLine;
                            sqlText += " ,@ADDRESS3" + Environment.NewLine;
                            sqlText += " ,@ADDRESS4" + Environment.NewLine;
                            sqlText += " ,@HOMETELNO" + Environment.NewLine;
                            sqlText += " ,@OFFICETELNO" + Environment.NewLine;
                            sqlText += " ,@PORTABLETELNO" + Environment.NewLine;
                            sqlText += " ,@HOMEFAXNO" + Environment.NewLine;
                            sqlText += " ,@OFFICEFAXNO" + Environment.NewLine;
                            sqlText += " ,@OTHERSTELNO" + Environment.NewLine;
                            sqlText += " ,@MAINCONTACTCODE" + Environment.NewLine;
                            sqlText += " ,@SEARCHTELNO" + Environment.NewLine;
                            sqlText += " ,@MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE6" + Environment.NewLine;
                            sqlText += " ,@BILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@BILLOUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,@TOTALDAY" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYCODE" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYNAME" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYDAY" + Environment.NewLine;
                            sqlText += " ,@COLLECTCOND" + Environment.NewLine;
                            sqlText += " ,@COLLECTSIGHT" + Environment.NewLine;
                            sqlText += " ,@CLAIMCODE" + Environment.NewLine;
                            sqlText += " ,@TRANSSTOPDATE" + Environment.NewLine;
                            sqlText += " ,@DMOUTCODE" + Environment.NewLine;
                            sqlText += " ,@DMOUTNAME" + Environment.NewLine;
                            sqlText += " ,@MAINSENDMAILADDRCD" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDNAME2" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,@BILLCOLLECTERCD" + Environment.NewLine;
                            sqlText += " ,@OLDCUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,@CUSTAGENTCHGDATE" + Environment.NewLine;
                            sqlText += " ,@ACCEPTWHOLESALE" + Environment.NewLine;
                            sqlText += " ,@CREDITMNGCODE" + Environment.NewLine;
                            sqlText += " ,@DEPODELCODE" + Environment.NewLine;
                            sqlText += " ,@ACCRECDIVCD" + Environment.NewLine;
                            sqlText += " ,@CUSTSLIPNOMNGCD" + Environment.NewLine;
                            sqlText += " ,@PURECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                            sqlText += " ,@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                            sqlText += " ,@TOTALAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO1" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO2" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO3" + Environment.NewLine;
                            sqlText += " ,@SALESUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@SALESMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSLIPNODIV" + Environment.NewLine;
                            sqlText += " ,@NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERAGENT" + Environment.NewLine;
                            sqlText += " ,@CLAIMSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@CARMNGDIVCD" + Environment.NewLine;
                            sqlText += " ,@BILLPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,@DELIPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,@DEFSALESSLIPCD" + Environment.NewLine;
                            sqlText += " ,@LAVORRATERANK" + Environment.NewLine;
                            sqlText += " ,@SLIPTTLPRN" + Environment.NewLine;
                            sqlText += " ,@DEPOBANKCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTWAREHOUSECD" + Environment.NewLine;
                            sqlText += " ,@QRCODEPRTCD" + Environment.NewLine;
                            sqlText += " ,@DELIHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@BILLHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@ESTMHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@RECTHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@DELIHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@BILLHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@ESTMHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@RECTHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@NOTE1" + Environment.NewLine;
                            sqlText += " ,@NOTE2" + Environment.NewLine;
                            sqlText += " ,@NOTE3" + Environment.NewLine;
                            sqlText += " ,@NOTE4" + Environment.NewLine;
                            sqlText += " ,@NOTE5" + Environment.NewLine;
                            sqlText += " ,@NOTE6" + Environment.NewLine;
                            sqlText += " ,@NOTE7" + Environment.NewLine;
                            sqlText += " ,@NOTE8" + Environment.NewLine;
                            sqlText += " ,@NOTE9" + Environment.NewLine;
                            sqlText += " ,@NOTE10" + Environment.NewLine;
                            sqlText += " ,@SALESSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,@SHIPMSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,@ACPODRRSLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,@ESTIMATEPRTDIV" + Environment.NewLine;
                            sqlText += " ,@UOESLIPPRTDIV" + Environment.NewLine;
                            sqlText += " ,@RECEIPTOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMEREPCODE " + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSECCODE " + Environment.NewLine;
                            sqlText += " ,@ONLINEKINDDIV " + Environment.NewLine;
                            sqlText += " ,@TOTALBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,@DETAILBILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@SLIPTTLBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,@SIMPLINQACNTACNTGRID" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            # endregion
                        }
                        else if (customerWork.WriteDiv == 1) // 0:得意先マスタ 1:得意先一括修正
                        {
                            # region [INSERT文]
                            sqlText += "INSERT INTO CUSTOMERRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSUBCODERF" + Environment.NewLine;
                            sqlText += " ,NAMERF" + Environment.NewLine;
                            sqlText += " ,NAME2RF" + Environment.NewLine;
                            sqlText += " ,HONORIFICTITLERF" + Environment.NewLine;
                            sqlText += " ,KANARF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMECODERF" + Environment.NewLine;
                            sqlText += " ,OUTPUTNAMERF" + Environment.NewLine;
                            sqlText += " ,CORPORATEDIVCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                            sqlText += " ,JOBTYPECODERF" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                            sqlText += " ,POSTNORF" + Environment.NewLine;
                            sqlText += " ,ADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,ADDRESS3RF" + Environment.NewLine;
                            sqlText += " ,ADDRESS4RF" + Environment.NewLine;
                            sqlText += " ,HOMETELNORF" + Environment.NewLine;
                            sqlText += " ,OFFICETELNORF" + Environment.NewLine;
                            sqlText += " ,PORTABLETELNORF" + Environment.NewLine;
                            sqlText += " ,HOMEFAXNORF" + Environment.NewLine;
                            sqlText += " ,OFFICEFAXNORF" + Environment.NewLine;
                            sqlText += " ,OTHERSTELNORF" + Environment.NewLine;
                            sqlText += " ,MAINCONTACTCODERF" + Environment.NewLine;
                            sqlText += " ,SEARCHTELNORF" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE1RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE2RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE3RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE4RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE5RF" + Environment.NewLine;
                            sqlText += " ,CUSTANALYSCODE6RF" + Environment.NewLine;
                            sqlText += " ,BILLOUTPUTCODERF" + Environment.NewLine;
                            sqlText += " ,BILLOUTPUTNAMERF" + Environment.NewLine;
                            sqlText += " ,TOTALDAYRF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYCODERF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYNAMERF" + Environment.NewLine;
                            sqlText += " ,COLLECTMONEYDAYRF" + Environment.NewLine;
                            sqlText += " ,COLLECTCONDRF" + Environment.NewLine;
                            sqlText += " ,COLLECTSIGHTRF" + Environment.NewLine;
                            sqlText += " ,CLAIMCODERF" + Environment.NewLine;
                            sqlText += " ,TRANSSTOPDATERF" + Environment.NewLine;
                            sqlText += " ,DMOUTCODERF" + Environment.NewLine;
                            sqlText += " ,DMOUTNAMERF" + Environment.NewLine;
                            sqlText += " ,MAINSENDMAILADDRCDRF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE1RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME1RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRKINDNAME2RF" + Environment.NewLine;
                            sqlText += " ,MAILADDRESS2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDCODE2RF" + Environment.NewLine;
                            sqlText += " ,MAILSENDNAME2RF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,BILLCOLLECTERCDRF" + Environment.NewLine;
                            sqlText += " ,OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTAGENTCHGDATERF" + Environment.NewLine;
                            sqlText += " ,ACCEPTWHOLESALERF" + Environment.NewLine;
                            sqlText += " ,CREDITMNGCODERF" + Environment.NewLine;
                            sqlText += " ,DEPODELCODERF" + Environment.NewLine;
                            sqlText += " ,ACCRECDIVCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                            sqlText += " ,PURECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                            sqlText += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                            sqlText += " ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                            sqlText += " ,TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                            sqlText += " ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                            sqlText += " ,SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERAGENTRF" + Environment.NewLine;
                            sqlText += " ,CLAIMSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,CARMNGDIVCDRF" + Environment.NewLine;
                            sqlText += " ,BILLPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DELIPARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DEFSALESSLIPCDRF" + Environment.NewLine;
                            sqlText += " ,LAVORRATERANKRF" + Environment.NewLine;
                            sqlText += " ,SLIPTTLPRNRF" + Environment.NewLine;
                            sqlText += " ,DEPOBANKCODERF" + Environment.NewLine;
                            sqlText += " ,CUSTWAREHOUSECDRF" + Environment.NewLine;
                            sqlText += " ,QRCODEPRTCDRF" + Environment.NewLine;
                            sqlText += " ,DELIHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,BILLHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,ESTMHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,RECTHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,NOTE1RF" + Environment.NewLine;
                            sqlText += " ,NOTE2RF" + Environment.NewLine;
                            sqlText += " ,NOTE3RF" + Environment.NewLine;
                            sqlText += " ,NOTE4RF" + Environment.NewLine;
                            sqlText += " ,NOTE5RF" + Environment.NewLine;
                            sqlText += " ,NOTE6RF" + Environment.NewLine;
                            sqlText += " ,NOTE7RF" + Environment.NewLine;
                            sqlText += " ,NOTE8RF" + Environment.NewLine;
                            sqlText += " ,NOTE9RF" + Environment.NewLine;
                            sqlText += " ,NOTE10RF" + Environment.NewLine;
                            sqlText += " ,RECEIPTOUTPUTCODERF" + Environment.NewLine;
                            sqlText += " ,TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                            sqlText += " ,DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                            sqlText += " ,SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;

                            sqlText += " ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,ESTIMATEPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,UOESLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSUBCODE" + Environment.NewLine;
                            sqlText += " ,@NAME" + Environment.NewLine;
                            sqlText += " ,@NAME2" + Environment.NewLine;
                            sqlText += " ,@HONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,@KANA" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSNM" + Environment.NewLine;
                            sqlText += " ,@OUTPUTNAMECODE" + Environment.NewLine;
                            sqlText += " ,@OUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,@CORPORATEDIVCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,@JOBTYPECODE" + Environment.NewLine;
                            sqlText += " ,@BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,@SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,@POSTNO" + Environment.NewLine;
                            sqlText += " ,@ADDRESS1" + Environment.NewLine;
                            sqlText += " ,@ADDRESS3" + Environment.NewLine;
                            sqlText += " ,@ADDRESS4" + Environment.NewLine;
                            sqlText += " ,@HOMETELNO" + Environment.NewLine;
                            sqlText += " ,@OFFICETELNO" + Environment.NewLine;
                            sqlText += " ,@PORTABLETELNO" + Environment.NewLine;
                            sqlText += " ,@HOMEFAXNO" + Environment.NewLine;
                            sqlText += " ,@OFFICEFAXNO" + Environment.NewLine;
                            sqlText += " ,@OTHERSTELNO" + Environment.NewLine;
                            sqlText += " ,@MAINCONTACTCODE" + Environment.NewLine;
                            sqlText += " ,@SEARCHTELNO" + Environment.NewLine;
                            sqlText += " ,@MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE1" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE2" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE3" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE4" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE5" + Environment.NewLine;
                            sqlText += " ,@CUSTANALYSCODE6" + Environment.NewLine;
                            sqlText += " ,@BILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@BILLOUTPUTNAME" + Environment.NewLine;
                            sqlText += " ,@TOTALDAY" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYCODE" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYNAME" + Environment.NewLine;
                            sqlText += " ,@COLLECTMONEYDAY" + Environment.NewLine;
                            sqlText += " ,@COLLECTCOND" + Environment.NewLine;
                            sqlText += " ,@COLLECTSIGHT" + Environment.NewLine;
                            sqlText += " ,@CLAIMCODE" + Environment.NewLine;
                            sqlText += " ,@TRANSSTOPDATE" + Environment.NewLine;
                            sqlText += " ,@DMOUTCODE" + Environment.NewLine;
                            sqlText += " ,@DMOUTNAME" + Environment.NewLine;
                            sqlText += " ,@MAINSENDMAILADDRCD" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE1" + Environment.NewLine;
                            sqlText += " ,@MAILSENDNAME1" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRKINDNAME2" + Environment.NewLine;
                            sqlText += " ,@MAILADDRESS2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDCODE2" + Environment.NewLine;
                            sqlText += " ,@MAILSENDNAME2" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,@BILLCOLLECTERCD" + Environment.NewLine;
                            sqlText += " ,@OLDCUSTOMERAGENTCD" + Environment.NewLine;
                            sqlText += " ,@CUSTAGENTCHGDATE" + Environment.NewLine;
                            sqlText += " ,@ACCEPTWHOLESALE" + Environment.NewLine;
                            sqlText += " ,@CREDITMNGCODE" + Environment.NewLine;
                            sqlText += " ,@DEPODELCODE" + Environment.NewLine;
                            sqlText += " ,@ACCRECDIVCD" + Environment.NewLine;
                            sqlText += " ,@CUSTSLIPNOMNGCD" + Environment.NewLine;
                            sqlText += " ,@PURECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                            sqlText += " ,@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                            sqlText += " ,@TOTALAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO1" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO2" + Environment.NewLine;
                            sqlText += " ,@ACCOUNTNOINFO3" + Environment.NewLine;
                            sqlText += " ,@SALESUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@SALESMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERSLIPNODIV" + Environment.NewLine;
                            sqlText += " ,@NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERAGENT" + Environment.NewLine;
                            sqlText += " ,@CLAIMSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@CARMNGDIVCD" + Environment.NewLine;
                            sqlText += " ,@BILLPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,@DELIPARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " ,@DEFSALESSLIPCD" + Environment.NewLine;
                            sqlText += " ,@LAVORRATERANK" + Environment.NewLine;
                            sqlText += " ,@SLIPTTLPRN" + Environment.NewLine;
                            sqlText += " ,@DEPOBANKCODE" + Environment.NewLine;
                            sqlText += " ,@CUSTWAREHOUSECD" + Environment.NewLine;
                            sqlText += " ,@QRCODEPRTCD" + Environment.NewLine;
                            sqlText += " ,@DELIHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@BILLHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@ESTMHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@RECTHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@DELIHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@BILLHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@ESTMHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@RECTHONORTTLPRTDIV" + Environment.NewLine;
                            sqlText += " ,@NOTE1" + Environment.NewLine;
                            sqlText += " ,@NOTE2" + Environment.NewLine;
                            sqlText += " ,@NOTE3" + Environment.NewLine;
                            sqlText += " ,@NOTE4" + Environment.NewLine;
                            sqlText += " ,@NOTE5" + Environment.NewLine;
                            sqlText += " ,@NOTE6" + Environment.NewLine;
                            sqlText += " ,@NOTE7" + Environment.NewLine;
                            sqlText += " ,@NOTE8" + Environment.NewLine;
                            sqlText += " ,@NOTE9" + Environment.NewLine;
                            sqlText += " ,@NOTE10" + Environment.NewLine;
                            sqlText += " ,@RECEIPTOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@TOTALBILLOUTPUTDIV" + Environment.NewLine;
                            sqlText += " ,@DETAILBILLOUTPUTCODE" + Environment.NewLine;
                            sqlText += " ,@SLIPTTLBILLOUTPUTDIV" + Environment.NewLine;

                            sqlText += " ,@SALESSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@ESTIMATEPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@UOESLIPPRTDIVRF" + Environment.NewLine;
                            sqlText += " ,@SIMPLINQACNTACNTGRID" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            # endregion

                        }
                        sqlCommand.CommandText = sqlText;

                        // 登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                    }

                    if (customerWork.WriteDiv == 0) // 0:得意先マスタ 1:得意先一括修正                    
                    {
                        # region Parameterオブジェクトの作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCustomerSubCode = sqlCommand.Parameters.Add("@CUSTOMERSUBCODE", SqlDbType.NVarChar);
                        SqlParameter paraName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar);
                        SqlParameter paraName2 = sqlCommand.Parameters.Add("@NAME2", SqlDbType.NVarChar);
                        SqlParameter paraHonorificTitle = sqlCommand.Parameters.Add("@HONORIFICTITLE", SqlDbType.NVarChar);
                        SqlParameter paraKana = sqlCommand.Parameters.Add("@KANA", SqlDbType.NVarChar);
                        SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                        SqlParameter paraOutputNameCode = sqlCommand.Parameters.Add("@OUTPUTNAMECODE", SqlDbType.Int);
                        SqlParameter paraOutputName = sqlCommand.Parameters.Add("@OUTPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraCorporateDivCode = sqlCommand.Parameters.Add("@CORPORATEDIVCODE", SqlDbType.Int);
                        SqlParameter paraCustomerAttributeDiv = sqlCommand.Parameters.Add("@CUSTOMERATTRIBUTEDIV", SqlDbType.Int);
                        SqlParameter paraJobTypeCode = sqlCommand.Parameters.Add("@JOBTYPECODE", SqlDbType.Int);
                        SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                        SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                        SqlParameter paraPostNo = sqlCommand.Parameters.Add("@POSTNO", SqlDbType.NVarChar);
                        SqlParameter paraAddress1 = sqlCommand.Parameters.Add("@ADDRESS1", SqlDbType.NVarChar);
                        SqlParameter paraAddress3 = sqlCommand.Parameters.Add("@ADDRESS3", SqlDbType.NVarChar);
                        SqlParameter paraAddress4 = sqlCommand.Parameters.Add("@ADDRESS4", SqlDbType.NVarChar);
                        SqlParameter paraHomeTelNo = sqlCommand.Parameters.Add("@HOMETELNO", SqlDbType.NVarChar);
                        SqlParameter paraOfficeTelNo = sqlCommand.Parameters.Add("@OFFICETELNO", SqlDbType.NVarChar);
                        SqlParameter paraPortableTelNo = sqlCommand.Parameters.Add("@PORTABLETELNO", SqlDbType.NVarChar);
                        SqlParameter paraHomeFaxNo = sqlCommand.Parameters.Add("@HOMEFAXNO", SqlDbType.NVarChar);
                        SqlParameter paraOfficeFaxNo = sqlCommand.Parameters.Add("@OFFICEFAXNO", SqlDbType.NVarChar);
                        SqlParameter paraOthersTelNo = sqlCommand.Parameters.Add("@OTHERSTELNO", SqlDbType.NVarChar);
                        SqlParameter paraMainContactCode = sqlCommand.Parameters.Add("@MAINCONTACTCODE", SqlDbType.Int);
                        SqlParameter paraSearchTelNo = sqlCommand.Parameters.Add("@SEARCHTELNO", SqlDbType.NChar);
                        SqlParameter paraMngSectionCode = sqlCommand.Parameters.Add("@MNGSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInpSectionCode = sqlCommand.Parameters.Add("@INPSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCustAnalysCode1 = sqlCommand.Parameters.Add("@CUSTANALYSCODE1", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode2 = sqlCommand.Parameters.Add("@CUSTANALYSCODE2", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode3 = sqlCommand.Parameters.Add("@CUSTANALYSCODE3", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode4 = sqlCommand.Parameters.Add("@CUSTANALYSCODE4", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode5 = sqlCommand.Parameters.Add("@CUSTANALYSCODE5", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode6 = sqlCommand.Parameters.Add("@CUSTANALYSCODE6", SqlDbType.Int);
                        SqlParameter paraBillOutputCode = sqlCommand.Parameters.Add("@BILLOUTPUTCODE", SqlDbType.Int);
                        SqlParameter paraBillOutputName = sqlCommand.Parameters.Add("@BILLOUTPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@TOTALDAY", SqlDbType.Int);
                        SqlParameter paraCollectMoneyCode = sqlCommand.Parameters.Add("@COLLECTMONEYCODE", SqlDbType.Int);
                        SqlParameter paraCollectMoneyName = sqlCommand.Parameters.Add("@COLLECTMONEYNAME", SqlDbType.NVarChar);
                        SqlParameter paraCollectMoneyDay = sqlCommand.Parameters.Add("@COLLECTMONEYDAY", SqlDbType.Int);
                        SqlParameter paraCollectCond = sqlCommand.Parameters.Add("@COLLECTCOND", SqlDbType.Int);
                        SqlParameter paraCollectSight = sqlCommand.Parameters.Add("@COLLECTSIGHT", SqlDbType.Int);
                        SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                        SqlParameter paraTransStopDate = sqlCommand.Parameters.Add("@TRANSSTOPDATE", SqlDbType.Int);
                        SqlParameter paraDmOutCode = sqlCommand.Parameters.Add("@DMOUTCODE", SqlDbType.Int);
                        SqlParameter paraDmOutName = sqlCommand.Parameters.Add("@DMOUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraMainSendMailAddrCd = sqlCommand.Parameters.Add("@MAINSENDMAILADDRCD", SqlDbType.Int);
                        SqlParameter paraMailAddrKindCode1 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE1", SqlDbType.Int);
                        SqlParameter paraMailAddrKindName1 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME1", SqlDbType.NVarChar);
                        SqlParameter paraMailAddress1 = sqlCommand.Parameters.Add("@MAILADDRESS1", SqlDbType.NVarChar);
                        SqlParameter paraMailSendCode1 = sqlCommand.Parameters.Add("@MAILSENDCODE1", SqlDbType.Int);
                        SqlParameter paraMailSendName1 = sqlCommand.Parameters.Add("@MAILSENDNAME1", SqlDbType.NVarChar);
                        SqlParameter paraMailAddrKindCode2 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE2", SqlDbType.Int);
                        SqlParameter paraMailAddrKindName2 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME2", SqlDbType.NVarChar);
                        SqlParameter paraMailAddress2 = sqlCommand.Parameters.Add("@MAILADDRESS2", SqlDbType.NVarChar);
                        SqlParameter paraMailSendCode2 = sqlCommand.Parameters.Add("@MAILSENDCODE2", SqlDbType.Int);
                        SqlParameter paraMailSendName2 = sqlCommand.Parameters.Add("@MAILSENDNAME2", SqlDbType.NVarChar);
                        SqlParameter paraCustomerAgentCd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCD", SqlDbType.NChar);
                        SqlParameter paraBillCollecterCd = sqlCommand.Parameters.Add("@BILLCOLLECTERCD", SqlDbType.NChar);
                        SqlParameter paraOldCustomerAgentCd = sqlCommand.Parameters.Add("@OLDCUSTOMERAGENTCD", SqlDbType.NChar);
                        SqlParameter paraCustAgentChgDate = sqlCommand.Parameters.Add("@CUSTAGENTCHGDATE", SqlDbType.Int);
                        SqlParameter paraAcceptWholeSale = sqlCommand.Parameters.Add("@ACCEPTWHOLESALE", SqlDbType.Int);
                        SqlParameter paraCreditMngCode = sqlCommand.Parameters.Add("@CREDITMNGCODE", SqlDbType.Int);
                        SqlParameter paraDepoDelCode = sqlCommand.Parameters.Add("@DEPODELCODE", SqlDbType.Int);
                        SqlParameter paraAccRecDivCd = sqlCommand.Parameters.Add("@ACCRECDIVCD", SqlDbType.Int);
                        SqlParameter paraCustSlipNoMngCd = sqlCommand.Parameters.Add("@CUSTSLIPNOMNGCD", SqlDbType.Int);
                        SqlParameter paraPureCode = sqlCommand.Parameters.Add("@PURECODE", SqlDbType.Int);
                        SqlParameter paraCustCTaXLayRefCd = sqlCommand.Parameters.Add("@CUSTCTAXLAYREFCD", SqlDbType.Int);
                        SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                        SqlParameter paraTotalAmountDispWayCd = sqlCommand.Parameters.Add("@TOTALAMOUNTDISPWAYCD", SqlDbType.Int);
                        SqlParameter paraTotalAmntDspWayRef = sqlCommand.Parameters.Add("@TOTALAMNTDSPWAYREF", SqlDbType.Int);
                        SqlParameter paraAccountNoInfo1 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO1", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo2 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO2", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo3 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO3", SqlDbType.NVarChar);
                        SqlParameter paraSalesUnPrcFrcProcCd = sqlCommand.Parameters.Add("@SALESUNPRCFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraSalesMoneyFrcProcCd = sqlCommand.Parameters.Add("@SALESMONEYFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraSalesCnsTaxFrcProcCd = sqlCommand.Parameters.Add("@SALESCNSTAXFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraCustomerSlipNoDiv = sqlCommand.Parameters.Add("@CUSTOMERSLIPNODIV", SqlDbType.Int);
                        SqlParameter paraNTimeCalcStDate = sqlCommand.Parameters.Add("@NTIMECALCSTDATE", SqlDbType.Int);
                        SqlParameter paraCustomerAgent = sqlCommand.Parameters.Add("@CUSTOMERAGENT", SqlDbType.NVarChar);
                        SqlParameter paraClaimSectionCode = sqlCommand.Parameters.Add("@CLAIMSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCarMngDivCd = sqlCommand.Parameters.Add("@CARMNGDIVCD", SqlDbType.Int);
                        SqlParameter paraBillPartsNoPrtCd = sqlCommand.Parameters.Add("@BILLPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraDeliPartsNoPrtCd = sqlCommand.Parameters.Add("@DELIPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraDefSalesSlipCd = sqlCommand.Parameters.Add("@DEFSALESSLIPCD", SqlDbType.Int);
                        SqlParameter paraLavorRateRank = sqlCommand.Parameters.Add("@LAVORRATERANK", SqlDbType.Int);
                        SqlParameter paraSlipTtlPrn = sqlCommand.Parameters.Add("@SLIPTTLPRN", SqlDbType.Int);
                        SqlParameter paraDepoBankCode = sqlCommand.Parameters.Add("@DEPOBANKCODE", SqlDbType.Int);
                        SqlParameter paraCustWarehouseCd = sqlCommand.Parameters.Add("@CUSTWAREHOUSECD", SqlDbType.NChar);
                        SqlParameter paraQrcodePrtCd = sqlCommand.Parameters.Add("@QRCODEPRTCD", SqlDbType.Int);
                        SqlParameter paraDeliHonorificTtl = sqlCommand.Parameters.Add("@DELIHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraBillHonorificTtl = sqlCommand.Parameters.Add("@BILLHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraEstmHonorificTtl = sqlCommand.Parameters.Add("@ESTMHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraRectHonorificTtl = sqlCommand.Parameters.Add("@RECTHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraDeliHonorTtlPrtDiv = sqlCommand.Parameters.Add("@DELIHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraBillHonorTtlPrtDiv = sqlCommand.Parameters.Add("@BILLHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraEstmHonorTtlPrtDiv = sqlCommand.Parameters.Add("@ESTMHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraRectHonorTtlPrtDiv = sqlCommand.Parameters.Add("@RECTHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraNote1 = sqlCommand.Parameters.Add("@NOTE1", SqlDbType.NVarChar);
                        SqlParameter paraNote2 = sqlCommand.Parameters.Add("@NOTE2", SqlDbType.NVarChar);
                        SqlParameter paraNote3 = sqlCommand.Parameters.Add("@NOTE3", SqlDbType.NVarChar);
                        SqlParameter paraNote4 = sqlCommand.Parameters.Add("@NOTE4", SqlDbType.NVarChar);
                        SqlParameter paraNote5 = sqlCommand.Parameters.Add("@NOTE5", SqlDbType.NVarChar);
                        SqlParameter paraNote6 = sqlCommand.Parameters.Add("@NOTE6", SqlDbType.NVarChar);
                        SqlParameter paraNote7 = sqlCommand.Parameters.Add("@NOTE7", SqlDbType.NVarChar);
                        SqlParameter paraNote8 = sqlCommand.Parameters.Add("@NOTE8", SqlDbType.NVarChar);
                        SqlParameter paraNote9 = sqlCommand.Parameters.Add("@NOTE9", SqlDbType.NVarChar);
                        SqlParameter paraNote10 = sqlCommand.Parameters.Add("@NOTE10", SqlDbType.NVarChar);
                        SqlParameter paraSalesSlipPrtDiv = sqlCommand.Parameters.Add("@SALESSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraShipmSlipPrtDiv = sqlCommand.Parameters.Add("@SHIPMSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraEstimatePrtDiv = sqlCommand.Parameters.Add("@ESTIMATEPRTDIV", SqlDbType.Int);
                        SqlParameter paraUOESlipPrtDiv = sqlCommand.Parameters.Add("@UOESLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraReceiptOutputCode = sqlCommand.Parameters.Add("@RECEIPTOUTPUTCODE", SqlDbType.Int);
                        SqlParameter paraCustomerEpCode = sqlCommand.Parameters.Add("@CUSTOMEREPCODE", SqlDbType.NChar);  // 得意先企業コード
                        SqlParameter paraCustomerSecCode = sqlCommand.Parameters.Add("@CUSTOMERSECCODE", SqlDbType.NChar);  // 得意先拠点コード
                        SqlParameter paraOnlineKindDiv = sqlCommand.Parameters.Add("@ONLINEKINDDIV", SqlDbType.Int);  // オンライン種別区分
                        SqlParameter paraTotalBillOutputDiv = sqlCommand.Parameters.Add("@TOTALBILLOUTPUTDIV", SqlDbType.Int);
                        SqlParameter paraDetailBillOutputCode = sqlCommand.Parameters.Add("@DETAILBILLOUTPUTCODE", SqlDbType.Int);
                        SqlParameter paraSlipTtlBillOutputDiv = sqlCommand.Parameters.Add("@SLIPTTLBILLOUTPUTDIV", SqlDbType.Int);
                        SqlParameter paraSimplInqAcntAcntGrId = sqlCommand.Parameters.Add("@SIMPLINQACNTACNTGRID", SqlDbType.NChar);  // 簡単問合せアカウントグループID
                        // --- ADD 梶谷 貴士 2021/05/10 ---------->>>>>
                        SqlParameter paraDisplayDivCode = sqlCommand.Parameters.Add("@DISPLAYDIVCODE", SqlDbType.Int);
                        // --- ADD 梶谷 貴士 2021/05/10 ----------<<<<<
                        SqlParameter paraNoteInfo = sqlCommand.Parameters.Add("@NOTEINFO", SqlDbType.NChar);

                        # endregion

                        # region Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(customerWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(customerWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(customerWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);
                        paraCustomerSubCode.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSubCode);
                        paraName.Value = SqlDataMediator.SqlSetString(customerWork.Name);
                        paraName2.Value = SqlDataMediator.SqlSetString(customerWork.Name2);
                        paraHonorificTitle.Value = SqlDataMediator.SqlSetString(customerWork.HonorificTitle);
                        paraKana.Value = SqlDataMediator.SqlSetString(customerWork.Kana);
                        paraCustomerSnm.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSnm);
                        paraOutputNameCode.Value = SqlDataMediator.SqlSetInt32(customerWork.OutputNameCode);
                        paraOutputName.Value = SqlDataMediator.SqlSetString(customerWork.OutputName);
                        paraCorporateDivCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CorporateDivCode);
                        paraCustomerAttributeDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerAttributeDiv);
                        paraJobTypeCode.Value = SqlDataMediator.SqlSetInt32(customerWork.JobTypeCode);
                        paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(customerWork.BusinessTypeCode);
                        paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesAreaCode);
                        paraPostNo.Value = SqlDataMediator.SqlSetString(customerWork.PostNo);
                        paraAddress1.Value = SqlDataMediator.SqlSetString(customerWork.Address1);
                        paraAddress3.Value = SqlDataMediator.SqlSetString(customerWork.Address3);
                        paraAddress4.Value = SqlDataMediator.SqlSetString(customerWork.Address4);
                        paraHomeTelNo.Value = SqlDataMediator.SqlSetString(customerWork.HomeTelNo);
                        paraOfficeTelNo.Value = SqlDataMediator.SqlSetString(customerWork.OfficeTelNo);
                        paraPortableTelNo.Value = SqlDataMediator.SqlSetString(customerWork.PortableTelNo);
                        paraHomeFaxNo.Value = SqlDataMediator.SqlSetString(customerWork.HomeFaxNo);
                        paraOfficeFaxNo.Value = SqlDataMediator.SqlSetString(customerWork.OfficeFaxNo);
                        paraOthersTelNo.Value = SqlDataMediator.SqlSetString(customerWork.OthersTelNo);
                        paraMainContactCode.Value = SqlDataMediator.SqlSetInt32(customerWork.MainContactCode);
                        paraSearchTelNo.Value = SqlDataMediator.SqlSetString(customerWork.SearchTelNo);
                        paraMngSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.MngSectionCode);
                        paraInpSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.InpSectionCode);
                        paraCustAnalysCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode1);
                        paraCustAnalysCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode2);
                        paraCustAnalysCode3.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode3);
                        paraCustAnalysCode4.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode4);
                        paraCustAnalysCode5.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode5);
                        paraCustAnalysCode6.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode6);
                        paraBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.BillOutputCode);
                        paraBillOutputName.Value = SqlDataMediator.SqlSetString(customerWork.BillOutputName);
                        paraTotalDay.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalDay);
                        paraCollectMoneyCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectMoneyCode);
                        paraCollectMoneyName.Value = SqlDataMediator.SqlSetString(customerWork.CollectMoneyName);
                        paraCollectMoneyDay.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectMoneyDay);
                        paraCollectCond.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectCond);
                        paraCollectSight.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectSight);
                        paraClaimCode.Value = SqlDataMediator.SqlSetInt32(customerWork.ClaimCode);
                        paraTransStopDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerWork.TransStopDate);
                        paraDmOutCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DmOutCode);
                        paraDmOutName.Value = SqlDataMediator.SqlSetString(customerWork.DmOutName);
                        paraMainSendMailAddrCd.Value = SqlDataMediator.SqlSetInt32(customerWork.MainSendMailAddrCd);
                        paraMailAddrKindCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.MailAddrKindCode1);
                        paraMailAddrKindName1.Value = SqlDataMediator.SqlSetString(customerWork.MailAddrKindName1);
                        paraMailAddress1.Value = SqlDataMediator.SqlSetString(customerWork.MailAddress1);
                        paraMailSendCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.MailSendCode1);
                        paraMailSendName1.Value = SqlDataMediator.SqlSetString(customerWork.MailSendName1);
                        paraMailAddrKindCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.MailAddrKindCode2);
                        paraMailAddrKindName2.Value = SqlDataMediator.SqlSetString(customerWork.MailAddrKindName2);
                        paraMailAddress2.Value = SqlDataMediator.SqlSetString(customerWork.MailAddress2);
                        paraMailSendCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.MailSendCode2);
                        paraMailSendName2.Value = SqlDataMediator.SqlSetString(customerWork.MailSendName2);
                        paraCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerWork.CustomerAgentCd);
                        paraBillCollecterCd.Value = SqlDataMediator.SqlSetString(customerWork.BillCollecterCd);
                        paraOldCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerWork.OldCustomerAgentCd);
                        paraCustAgentChgDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerWork.CustAgentChgDate);
                        paraAcceptWholeSale.Value = SqlDataMediator.SqlSetInt32(customerWork.AcceptWholeSale);
                        paraCreditMngCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CreditMngCode);
                        paraDepoDelCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DepoDelCode);
                        paraAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(customerWork.AccRecDivCd);
                        paraCustSlipNoMngCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CustSlipNoMngCd);
                        paraPureCode.Value = SqlDataMediator.SqlSetInt32(customerWork.PureCode);
                        paraCustCTaXLayRefCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CustCTaXLayRefCd);
                        paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(customerWork.ConsTaxLayMethod);
                        paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalAmountDispWayCd);
                        paraTotalAmntDspWayRef.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalAmntDspWayRef);
                        paraAccountNoInfo1.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo1);
                        paraAccountNoInfo2.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo2);
                        paraAccountNoInfo3.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo3);
                        paraSalesUnPrcFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesUnPrcFrcProcCd);
                        paraSalesMoneyFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesMoneyFrcProcCd);
                        paraSalesCnsTaxFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesCnsTaxFrcProcCd);
                        paraCustomerSlipNoDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerSlipNoDiv);
                        paraNTimeCalcStDate.Value = SqlDataMediator.SqlSetInt32(customerWork.NTimeCalcStDate);
                        paraCustomerAgent.Value = SqlDataMediator.SqlSetString(customerWork.CustomerAgent);
                        paraClaimSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.ClaimSectionCode);
                        paraCarMngDivCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CarMngDivCd);
                        paraBillPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.BillPartsNoPrtCd);
                        paraDeliPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.DeliPartsNoPrtCd);
                        paraDefSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(customerWork.DefSalesSlipCd);
                        paraLavorRateRank.Value = SqlDataMediator.SqlSetInt32(customerWork.LavorRateRank);
                        paraSlipTtlPrn.Value = SqlDataMediator.SqlSetInt32(customerWork.SlipTtlPrn);
                        paraDepoBankCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DepoBankCode);
                        paraCustWarehouseCd.Value = SqlDataMediator.SqlSetString(customerWork.CustWarehouseCd);
                        paraQrcodePrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.QrcodePrtCd);
                        paraDeliHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.DeliHonorificTtl);
                        paraBillHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.BillHonorificTtl);
                        paraEstmHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.EstmHonorificTtl);
                        paraRectHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.RectHonorificTtl);
                        paraDeliHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.DeliHonorTtlPrtDiv);
                        paraBillHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.BillHonorTtlPrtDiv);
                        paraEstmHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.EstmHonorTtlPrtDiv);
                        paraRectHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.RectHonorTtlPrtDiv);
                        paraNote1.Value = SqlDataMediator.SqlSetString(customerWork.Note1);
                        paraNote2.Value = SqlDataMediator.SqlSetString(customerWork.Note2);
                        paraNote3.Value = SqlDataMediator.SqlSetString(customerWork.Note3);
                        paraNote4.Value = SqlDataMediator.SqlSetString(customerWork.Note4);
                        paraNote5.Value = SqlDataMediator.SqlSetString(customerWork.Note5);
                        paraNote6.Value = SqlDataMediator.SqlSetString(customerWork.Note6);
                        paraNote7.Value = SqlDataMediator.SqlSetString(customerWork.Note7);
                        paraNote8.Value = SqlDataMediator.SqlSetString(customerWork.Note8);
                        paraNote9.Value = SqlDataMediator.SqlSetString(customerWork.Note9);
                        paraNote10.Value = SqlDataMediator.SqlSetString(customerWork.Note10);
                        paraSalesSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesSlipPrtDiv);
                        paraShipmSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.ShipmSlipPrtDiv);
                        paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.AcpOdrrSlipPrtDiv);
                        paraEstimatePrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.EstimatePrtDiv);
                        paraUOESlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.UOESlipPrtDiv);

                        paraReceiptOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.ReceiptOutputCode);

                        paraCustomerEpCode.Value = SqlDataMediator.SqlSetString(customerWork.CustomerEpCode);  // 得意先企業コード
                        paraCustomerSecCode.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSecCode);  // 得意先拠点コード
                        paraOnlineKindDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.OnlineKindDiv);  // オンライン種別区分
                        paraTotalBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalBillOutputDiv);
                        paraDetailBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DetailBillOutputCode);
                        paraSlipTtlBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.SlipTtlBillOutputDiv);
                        paraSimplInqAcntAcntGrId.Value = SqlDataMediator.SqlSetString(customerWork.SimplInqAcntAcntGrId);  // 簡単問合せアカウントグループID
                        // --- ADD 梶谷 貴士 2021/05/10 ---------->>>>>
                        paraDisplayDivCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DisplayDivCode);    //得意先ガイド表示区分
                        // --- ADD 梶谷 貴士 2021/05/10 ----------<<<<<
                        paraNoteInfo.Value = SqlDataMediator.SqlSetString(customerWork.NoteInfo);   // メモ
                        # endregion
                    }
                    else if (customerWork.WriteDiv == 1) // 0:得意先マスタ 1:得意先一括修正
                    {
                        # region Parameterオブジェクトの作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCustomerSubCode = sqlCommand.Parameters.Add("@CUSTOMERSUBCODE", SqlDbType.NVarChar);
                        SqlParameter paraName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar);
                        SqlParameter paraName2 = sqlCommand.Parameters.Add("@NAME2", SqlDbType.NVarChar);
                        SqlParameter paraHonorificTitle = sqlCommand.Parameters.Add("@HONORIFICTITLE", SqlDbType.NVarChar);
                        SqlParameter paraKana = sqlCommand.Parameters.Add("@KANA", SqlDbType.NVarChar);
                        SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                        SqlParameter paraOutputNameCode = sqlCommand.Parameters.Add("@OUTPUTNAMECODE", SqlDbType.Int);
                        SqlParameter paraOutputName = sqlCommand.Parameters.Add("@OUTPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraCorporateDivCode = sqlCommand.Parameters.Add("@CORPORATEDIVCODE", SqlDbType.Int);
                        SqlParameter paraCustomerAttributeDiv = sqlCommand.Parameters.Add("@CUSTOMERATTRIBUTEDIV", SqlDbType.Int);
                        SqlParameter paraJobTypeCode = sqlCommand.Parameters.Add("@JOBTYPECODE", SqlDbType.Int);
                        SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                        SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                        SqlParameter paraPostNo = sqlCommand.Parameters.Add("@POSTNO", SqlDbType.NVarChar);
                        SqlParameter paraAddress1 = sqlCommand.Parameters.Add("@ADDRESS1", SqlDbType.NVarChar);
                        SqlParameter paraAddress3 = sqlCommand.Parameters.Add("@ADDRESS3", SqlDbType.NVarChar);
                        SqlParameter paraAddress4 = sqlCommand.Parameters.Add("@ADDRESS4", SqlDbType.NVarChar);
                        SqlParameter paraHomeTelNo = sqlCommand.Parameters.Add("@HOMETELNO", SqlDbType.NVarChar);
                        SqlParameter paraOfficeTelNo = sqlCommand.Parameters.Add("@OFFICETELNO", SqlDbType.NVarChar);
                        SqlParameter paraPortableTelNo = sqlCommand.Parameters.Add("@PORTABLETELNO", SqlDbType.NVarChar);
                        SqlParameter paraHomeFaxNo = sqlCommand.Parameters.Add("@HOMEFAXNO", SqlDbType.NVarChar);
                        SqlParameter paraOfficeFaxNo = sqlCommand.Parameters.Add("@OFFICEFAXNO", SqlDbType.NVarChar);
                        SqlParameter paraOthersTelNo = sqlCommand.Parameters.Add("@OTHERSTELNO", SqlDbType.NVarChar);
                        SqlParameter paraMainContactCode = sqlCommand.Parameters.Add("@MAINCONTACTCODE", SqlDbType.Int);
                        SqlParameter paraSearchTelNo = sqlCommand.Parameters.Add("@SEARCHTELNO", SqlDbType.NChar);
                        SqlParameter paraMngSectionCode = sqlCommand.Parameters.Add("@MNGSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInpSectionCode = sqlCommand.Parameters.Add("@INPSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCustAnalysCode1 = sqlCommand.Parameters.Add("@CUSTANALYSCODE1", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode2 = sqlCommand.Parameters.Add("@CUSTANALYSCODE2", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode3 = sqlCommand.Parameters.Add("@CUSTANALYSCODE3", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode4 = sqlCommand.Parameters.Add("@CUSTANALYSCODE4", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode5 = sqlCommand.Parameters.Add("@CUSTANALYSCODE5", SqlDbType.Int);
                        SqlParameter paraCustAnalysCode6 = sqlCommand.Parameters.Add("@CUSTANALYSCODE6", SqlDbType.Int);
                        SqlParameter paraBillOutputCode = sqlCommand.Parameters.Add("@BILLOUTPUTCODE", SqlDbType.Int);
                        SqlParameter paraBillOutputName = sqlCommand.Parameters.Add("@BILLOUTPUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@TOTALDAY", SqlDbType.Int);
                        SqlParameter paraCollectMoneyCode = sqlCommand.Parameters.Add("@COLLECTMONEYCODE", SqlDbType.Int);
                        SqlParameter paraCollectMoneyName = sqlCommand.Parameters.Add("@COLLECTMONEYNAME", SqlDbType.NVarChar);
                        SqlParameter paraCollectMoneyDay = sqlCommand.Parameters.Add("@COLLECTMONEYDAY", SqlDbType.Int);
                        SqlParameter paraCollectCond = sqlCommand.Parameters.Add("@COLLECTCOND", SqlDbType.Int);
                        SqlParameter paraCollectSight = sqlCommand.Parameters.Add("@COLLECTSIGHT", SqlDbType.Int);
                        SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                        SqlParameter paraTransStopDate = sqlCommand.Parameters.Add("@TRANSSTOPDATE", SqlDbType.Int);
                        SqlParameter paraDmOutCode = sqlCommand.Parameters.Add("@DMOUTCODE", SqlDbType.Int);
                        SqlParameter paraDmOutName = sqlCommand.Parameters.Add("@DMOUTNAME", SqlDbType.NVarChar);
                        SqlParameter paraMainSendMailAddrCd = sqlCommand.Parameters.Add("@MAINSENDMAILADDRCD", SqlDbType.Int);
                        SqlParameter paraMailAddrKindCode1 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE1", SqlDbType.Int);
                        SqlParameter paraMailAddrKindName1 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME1", SqlDbType.NVarChar);
                        SqlParameter paraMailAddress1 = sqlCommand.Parameters.Add("@MAILADDRESS1", SqlDbType.NVarChar);
                        SqlParameter paraMailSendCode1 = sqlCommand.Parameters.Add("@MAILSENDCODE1", SqlDbType.Int);
                        SqlParameter paraMailSendName1 = sqlCommand.Parameters.Add("@MAILSENDNAME1", SqlDbType.NVarChar);
                        SqlParameter paraMailAddrKindCode2 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE2", SqlDbType.Int);
                        SqlParameter paraMailAddrKindName2 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME2", SqlDbType.NVarChar);
                        SqlParameter paraMailAddress2 = sqlCommand.Parameters.Add("@MAILADDRESS2", SqlDbType.NVarChar);
                        SqlParameter paraMailSendCode2 = sqlCommand.Parameters.Add("@MAILSENDCODE2", SqlDbType.Int);
                        SqlParameter paraMailSendName2 = sqlCommand.Parameters.Add("@MAILSENDNAME2", SqlDbType.NVarChar);
                        SqlParameter paraCustomerAgentCd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCD", SqlDbType.NChar);
                        SqlParameter paraBillCollecterCd = sqlCommand.Parameters.Add("@BILLCOLLECTERCD", SqlDbType.NChar);
                        SqlParameter paraOldCustomerAgentCd = sqlCommand.Parameters.Add("@OLDCUSTOMERAGENTCD", SqlDbType.NChar);
                        SqlParameter paraCustAgentChgDate = sqlCommand.Parameters.Add("@CUSTAGENTCHGDATE", SqlDbType.Int);
                        SqlParameter paraAcceptWholeSale = sqlCommand.Parameters.Add("@ACCEPTWHOLESALE", SqlDbType.Int);
                        SqlParameter paraCreditMngCode = sqlCommand.Parameters.Add("@CREDITMNGCODE", SqlDbType.Int);
                        SqlParameter paraDepoDelCode = sqlCommand.Parameters.Add("@DEPODELCODE", SqlDbType.Int);
                        SqlParameter paraAccRecDivCd = sqlCommand.Parameters.Add("@ACCRECDIVCD", SqlDbType.Int);
                        SqlParameter paraCustSlipNoMngCd = sqlCommand.Parameters.Add("@CUSTSLIPNOMNGCD", SqlDbType.Int);
                        SqlParameter paraPureCode = sqlCommand.Parameters.Add("@PURECODE", SqlDbType.Int);
                        SqlParameter paraCustCTaXLayRefCd = sqlCommand.Parameters.Add("@CUSTCTAXLAYREFCD", SqlDbType.Int);
                        SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                        SqlParameter paraTotalAmountDispWayCd = sqlCommand.Parameters.Add("@TOTALAMOUNTDISPWAYCD", SqlDbType.Int);
                        SqlParameter paraTotalAmntDspWayRef = sqlCommand.Parameters.Add("@TOTALAMNTDSPWAYREF", SqlDbType.Int);
                        SqlParameter paraAccountNoInfo1 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO1", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo2 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO2", SqlDbType.NVarChar);
                        SqlParameter paraAccountNoInfo3 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO3", SqlDbType.NVarChar);
                        SqlParameter paraSalesUnPrcFrcProcCd = sqlCommand.Parameters.Add("@SALESUNPRCFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraSalesMoneyFrcProcCd = sqlCommand.Parameters.Add("@SALESMONEYFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraSalesCnsTaxFrcProcCd = sqlCommand.Parameters.Add("@SALESCNSTAXFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraCustomerSlipNoDiv = sqlCommand.Parameters.Add("@CUSTOMERSLIPNODIV", SqlDbType.Int);
                        SqlParameter paraNTimeCalcStDate = sqlCommand.Parameters.Add("@NTIMECALCSTDATE", SqlDbType.Int);
                        SqlParameter paraCustomerAgent = sqlCommand.Parameters.Add("@CUSTOMERAGENT", SqlDbType.NVarChar);
                        SqlParameter paraClaimSectionCode = sqlCommand.Parameters.Add("@CLAIMSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCarMngDivCd = sqlCommand.Parameters.Add("@CARMNGDIVCD", SqlDbType.Int);
                        SqlParameter paraBillPartsNoPrtCd = sqlCommand.Parameters.Add("@BILLPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraDeliPartsNoPrtCd = sqlCommand.Parameters.Add("@DELIPARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraDefSalesSlipCd = sqlCommand.Parameters.Add("@DEFSALESSLIPCD", SqlDbType.Int);
                        SqlParameter paraLavorRateRank = sqlCommand.Parameters.Add("@LAVORRATERANK", SqlDbType.Int);
                        SqlParameter paraSlipTtlPrn = sqlCommand.Parameters.Add("@SLIPTTLPRN", SqlDbType.Int);
                        SqlParameter paraDepoBankCode = sqlCommand.Parameters.Add("@DEPOBANKCODE", SqlDbType.Int);
                        SqlParameter paraCustWarehouseCd = sqlCommand.Parameters.Add("@CUSTWAREHOUSECD", SqlDbType.NChar); // ADD 2008.12.10
                        SqlParameter paraQrcodePrtCd = sqlCommand.Parameters.Add("@QRCODEPRTCD", SqlDbType.Int);
                        SqlParameter paraDeliHonorificTtl = sqlCommand.Parameters.Add("@DELIHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraBillHonorificTtl = sqlCommand.Parameters.Add("@BILLHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraEstmHonorificTtl = sqlCommand.Parameters.Add("@ESTMHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraRectHonorificTtl = sqlCommand.Parameters.Add("@RECTHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraDeliHonorTtlPrtDiv = sqlCommand.Parameters.Add("@DELIHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraBillHonorTtlPrtDiv = sqlCommand.Parameters.Add("@BILLHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraEstmHonorTtlPrtDiv = sqlCommand.Parameters.Add("@ESTMHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraRectHonorTtlPrtDiv = sqlCommand.Parameters.Add("@RECTHONORTTLPRTDIV", SqlDbType.Int);
                        SqlParameter paraNote1 = sqlCommand.Parameters.Add("@NOTE1", SqlDbType.NVarChar);
                        SqlParameter paraNote2 = sqlCommand.Parameters.Add("@NOTE2", SqlDbType.NVarChar);
                        SqlParameter paraNote3 = sqlCommand.Parameters.Add("@NOTE3", SqlDbType.NVarChar);
                        SqlParameter paraNote4 = sqlCommand.Parameters.Add("@NOTE4", SqlDbType.NVarChar);
                        SqlParameter paraNote5 = sqlCommand.Parameters.Add("@NOTE5", SqlDbType.NVarChar);
                        SqlParameter paraNote6 = sqlCommand.Parameters.Add("@NOTE6", SqlDbType.NVarChar);
                        SqlParameter paraNote7 = sqlCommand.Parameters.Add("@NOTE7", SqlDbType.NVarChar);
                        SqlParameter paraNote8 = sqlCommand.Parameters.Add("@NOTE8", SqlDbType.NVarChar);
                        SqlParameter paraNote9 = sqlCommand.Parameters.Add("@NOTE9", SqlDbType.NVarChar);
                        SqlParameter paraNote10 = sqlCommand.Parameters.Add("@NOTE10", SqlDbType.NVarChar);
                        SqlParameter paraReceiptOutputCode = sqlCommand.Parameters.Add("@RECEIPTOUTPUTCODE", SqlDbType.Int);
                        SqlParameter paraTotalBillOutputDiv = sqlCommand.Parameters.Add("@TOTALBILLOUTPUTDIV", SqlDbType.Int);
                        SqlParameter paraDetailBillOutputCode = sqlCommand.Parameters.Add("@DETAILBILLOUTPUTCODE", SqlDbType.Int);
                        SqlParameter paraSlipTtlBillOutputDiv = sqlCommand.Parameters.Add("@SLIPTTLBILLOUTPUTDIV", SqlDbType.Int);

                        SqlParameter paraSalesSlipPrtDiv = sqlCommand.Parameters.Add("@SALESSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraShipmSlipPrtDiv = sqlCommand.Parameters.Add("@SHIPMSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraEstimatePrtDiv = sqlCommand.Parameters.Add("@ESTIMATEPRTDIV", SqlDbType.Int);
                        SqlParameter paraUOESlipPrtDiv = sqlCommand.Parameters.Add("@UOESLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraSimplInqAcntAcntGrId = sqlCommand.Parameters.Add("@SIMPLINQACNTACNTGRID", SqlDbType.NChar);
                        # endregion

                        # region Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(customerWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(customerWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(customerWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);
                        paraCustomerSubCode.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSubCode);
                        paraName.Value = SqlDataMediator.SqlSetString(customerWork.Name);
                        paraName2.Value = SqlDataMediator.SqlSetString(customerWork.Name2);
                        paraHonorificTitle.Value = SqlDataMediator.SqlSetString(customerWork.HonorificTitle);
                        paraKana.Value = SqlDataMediator.SqlSetString(customerWork.Kana);
                        paraCustomerSnm.Value = SqlDataMediator.SqlSetString(customerWork.CustomerSnm);
                        paraOutputNameCode.Value = SqlDataMediator.SqlSetInt32(customerWork.OutputNameCode);
                        paraOutputName.Value = SqlDataMediator.SqlSetString(customerWork.OutputName);
                        paraCorporateDivCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CorporateDivCode);
                        paraCustomerAttributeDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerAttributeDiv);
                        paraJobTypeCode.Value = SqlDataMediator.SqlSetInt32(customerWork.JobTypeCode);
                        paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(customerWork.BusinessTypeCode);
                        paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesAreaCode);
                        paraPostNo.Value = SqlDataMediator.SqlSetString(customerWork.PostNo);
                        paraAddress1.Value = SqlDataMediator.SqlSetString(customerWork.Address1);
                        paraAddress3.Value = SqlDataMediator.SqlSetString(customerWork.Address3);
                        paraAddress4.Value = SqlDataMediator.SqlSetString(customerWork.Address4);
                        paraHomeTelNo.Value = SqlDataMediator.SqlSetString(customerWork.HomeTelNo);
                        paraOfficeTelNo.Value = SqlDataMediator.SqlSetString(customerWork.OfficeTelNo);
                        paraPortableTelNo.Value = SqlDataMediator.SqlSetString(customerWork.PortableTelNo);
                        paraHomeFaxNo.Value = SqlDataMediator.SqlSetString(customerWork.HomeFaxNo);
                        paraOfficeFaxNo.Value = SqlDataMediator.SqlSetString(customerWork.OfficeFaxNo);
                        paraOthersTelNo.Value = SqlDataMediator.SqlSetString(customerWork.OthersTelNo);
                        paraMainContactCode.Value = SqlDataMediator.SqlSetInt32(customerWork.MainContactCode);
                        paraSearchTelNo.Value = SqlDataMediator.SqlSetString(customerWork.SearchTelNo);
                        paraMngSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.MngSectionCode);
                        paraInpSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.InpSectionCode);
                        paraCustAnalysCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode1);
                        paraCustAnalysCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode2);
                        paraCustAnalysCode3.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode3);
                        paraCustAnalysCode4.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode4);
                        paraCustAnalysCode5.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode5);
                        paraCustAnalysCode6.Value = SqlDataMediator.SqlSetInt32(customerWork.CustAnalysCode6);
                        paraBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.BillOutputCode);
                        paraBillOutputName.Value = SqlDataMediator.SqlSetString(customerWork.BillOutputName);
                        paraTotalDay.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalDay);
                        paraCollectMoneyCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectMoneyCode);
                        paraCollectMoneyName.Value = SqlDataMediator.SqlSetString(customerWork.CollectMoneyName);
                        paraCollectMoneyDay.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectMoneyDay);
                        paraCollectCond.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectCond);
                        paraCollectSight.Value = SqlDataMediator.SqlSetInt32(customerWork.CollectSight);
                        paraClaimCode.Value = SqlDataMediator.SqlSetInt32(customerWork.ClaimCode);
                        paraTransStopDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerWork.TransStopDate);
                        paraDmOutCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DmOutCode);
                        paraDmOutName.Value = SqlDataMediator.SqlSetString(customerWork.DmOutName);
                        paraMainSendMailAddrCd.Value = SqlDataMediator.SqlSetInt32(customerWork.MainSendMailAddrCd);
                        paraMailAddrKindCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.MailAddrKindCode1);
                        paraMailAddrKindName1.Value = SqlDataMediator.SqlSetString(customerWork.MailAddrKindName1);
                        paraMailAddress1.Value = SqlDataMediator.SqlSetString(customerWork.MailAddress1);
                        paraMailSendCode1.Value = SqlDataMediator.SqlSetInt32(customerWork.MailSendCode1);
                        paraMailSendName1.Value = SqlDataMediator.SqlSetString(customerWork.MailSendName1);
                        paraMailAddrKindCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.MailAddrKindCode2);
                        paraMailAddrKindName2.Value = SqlDataMediator.SqlSetString(customerWork.MailAddrKindName2);
                        paraMailAddress2.Value = SqlDataMediator.SqlSetString(customerWork.MailAddress2);
                        paraMailSendCode2.Value = SqlDataMediator.SqlSetInt32(customerWork.MailSendCode2);
                        paraMailSendName2.Value = SqlDataMediator.SqlSetString(customerWork.MailSendName2);
                        paraCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerWork.CustomerAgentCd);
                        paraBillCollecterCd.Value = SqlDataMediator.SqlSetString(customerWork.BillCollecterCd);
                        paraOldCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerWork.OldCustomerAgentCd);
                        paraCustAgentChgDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerWork.CustAgentChgDate);
                        paraAcceptWholeSale.Value = SqlDataMediator.SqlSetInt32(customerWork.AcceptWholeSale);
                        paraCreditMngCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CreditMngCode);
                        paraDepoDelCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DepoDelCode);
                        paraAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(customerWork.AccRecDivCd);
                        paraCustSlipNoMngCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CustSlipNoMngCd);
                        paraPureCode.Value = SqlDataMediator.SqlSetInt32(customerWork.PureCode);
                        paraCustCTaXLayRefCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CustCTaXLayRefCd);
                        paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(customerWork.ConsTaxLayMethod);
                        paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalAmountDispWayCd);
                        paraTotalAmntDspWayRef.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalAmntDspWayRef);
                        paraAccountNoInfo1.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo1);
                        paraAccountNoInfo2.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo2);
                        paraAccountNoInfo3.Value = SqlDataMediator.SqlSetString(customerWork.AccountNoInfo3);
                        paraSalesUnPrcFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesUnPrcFrcProcCd);
                        paraSalesMoneyFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesMoneyFrcProcCd);
                        paraSalesCnsTaxFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesCnsTaxFrcProcCd);
                        paraCustomerSlipNoDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerSlipNoDiv);
                        paraNTimeCalcStDate.Value = SqlDataMediator.SqlSetInt32(customerWork.NTimeCalcStDate);
                        paraCustomerAgent.Value = SqlDataMediator.SqlSetString(customerWork.CustomerAgent);
                        paraClaimSectionCode.Value = SqlDataMediator.SqlSetString(customerWork.ClaimSectionCode);
                        paraCarMngDivCd.Value = SqlDataMediator.SqlSetInt32(customerWork.CarMngDivCd);
                        paraBillPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.BillPartsNoPrtCd);
                        paraDeliPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.DeliPartsNoPrtCd);
                        paraDefSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(customerWork.DefSalesSlipCd);
                        paraLavorRateRank.Value = SqlDataMediator.SqlSetInt32(customerWork.LavorRateRank);
                        paraSlipTtlPrn.Value = SqlDataMediator.SqlSetInt32(customerWork.SlipTtlPrn);
                        paraDepoBankCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DepoBankCode);
                        paraCustWarehouseCd.Value = SqlDataMediator.SqlSetString(customerWork.CustWarehouseCd);
                        paraQrcodePrtCd.Value = SqlDataMediator.SqlSetInt32(customerWork.QrcodePrtCd);
                        paraDeliHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.DeliHonorificTtl);
                        paraBillHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.BillHonorificTtl);
                        paraEstmHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.EstmHonorificTtl);
                        paraRectHonorificTtl.Value = SqlDataMediator.SqlSetString(customerWork.RectHonorificTtl);
                        paraDeliHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.DeliHonorTtlPrtDiv);
                        paraBillHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.BillHonorTtlPrtDiv);
                        paraEstmHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.EstmHonorTtlPrtDiv);
                        paraRectHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.RectHonorTtlPrtDiv);
                        paraNote1.Value = SqlDataMediator.SqlSetString(customerWork.Note1);
                        paraNote2.Value = SqlDataMediator.SqlSetString(customerWork.Note2);
                        paraNote3.Value = SqlDataMediator.SqlSetString(customerWork.Note3);
                        paraNote4.Value = SqlDataMediator.SqlSetString(customerWork.Note4);
                        paraNote5.Value = SqlDataMediator.SqlSetString(customerWork.Note5);
                        paraNote6.Value = SqlDataMediator.SqlSetString(customerWork.Note6);
                        paraNote7.Value = SqlDataMediator.SqlSetString(customerWork.Note7);
                        paraNote8.Value = SqlDataMediator.SqlSetString(customerWork.Note8);
                        paraNote9.Value = SqlDataMediator.SqlSetString(customerWork.Note9);
                        paraNote10.Value = SqlDataMediator.SqlSetString(customerWork.Note10);
                        paraReceiptOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.ReceiptOutputCode);
                        paraTotalBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.TotalBillOutputDiv);
                        paraDetailBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DetailBillOutputCode);
                        paraSlipTtlBillOutputDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.SlipTtlBillOutputDiv);

                        paraSalesSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.SalesSlipPrtDiv);
                        paraShipmSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.ShipmSlipPrtDiv);
                        paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.AcpOdrrSlipPrtDiv);
                        paraEstimatePrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.EstimatePrtDiv);
                        paraUOESlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerWork.UOESlipPrtDiv);
                        paraSimplInqAcntAcntGrId.Value = SqlDataMediator.SqlSetString(customerWork.SimplInqAcntAcntGrId);
                        # endregion
                    }
                    sqlCommand.ExecuteNonQuery();
                }
                #endregion

                #region 得意先メモDBの処理
                // Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, CUSTOMERCODERF FROM CUSTOMERMEMORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction))
                {
                    // Parameterオブジェクトのクリア
                    sqlCommand.Parameters.Clear();

                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomercode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                    findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                    sqlCommand.CommandTimeout = 3600;
                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        string sqlText = string.Empty;

                        if (customerWork.WriteDiv == 0) // 0:得意先マスタ
                        {
                            # region [UPDATE文]
                            sqlText += "UPDATE CUSTOMERMEMORF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            // --- ADD 梶谷 貴士 2021/05/10 ---------->>>>>
                            sqlText += " ,DISPLAYDIVCODERF = @DISPLAYDIVCODE" + Environment.NewLine;    //得意先情報ガイド表示区分
                            // --- ADD 梶谷 貴士 2021/05/10 ----------<<<<<
                            sqlText += " ,NOTEINFORF = @NOTEINFO" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            # endregion
                        }
                        sqlCommand.CommandText = sqlText;

                        // KEYコマンドを再設定
                        findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 新規作成時のSQL文を生成

                        string sqlText = string.Empty;
                        if (customerWork.WriteDiv == 0) // 0:得意先マスタ
                        {
                            # region [INSERT文]
                            sqlText += "INSERT INTO CUSTOMERMEMORF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                            // --- ADD 梶谷 貴士 2021/05/10 ---------->>>>>
                            sqlText += " ,DISPLAYDIVCODERF" + Environment.NewLine;    //得意先情報ガイド表示区分
                            // --- ADD 梶谷 貴士 2021/05/10 ----------<<<<<
                            sqlText += " ,NOTEINFORF" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                            // --- ADD 梶谷 貴士 2021/05/10 ---------->>>>>
                            sqlText += " ,@DISPLAYDIVCODE" + Environment.NewLine;    //得意先情報ガイド表示区分
                            // --- ADD 梶谷 貴士 2021/05/10 ----------<<<<<
                            sqlText += " ,@NOTEINFO" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            # endregion
                        }
                        sqlCommand.CommandText = sqlText;

                        // 登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                    }

                    if (customerWork.WriteDiv == 0) // 0:得意先マスタ                  
                    {
                        # region Parameterオブジェクトの作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        // --- ADD 梶谷 貴士 2021/05/10 ---------->>>>>
                        SqlParameter paraDisplayDivCode = sqlCommand.Parameters.Add("@DISPLAYDIVCODE", SqlDbType.Int);    //得意先情報ガイド表示区分
                        // --- ADD 梶谷 貴士 2021/05/10 ----------<<<<<
                        SqlParameter paraNoteInfo = sqlCommand.Parameters.Add("@NOTEINFO", SqlDbType.NChar);

                        # endregion

                        # region Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(customerWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(customerWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(customerWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);
                        // --- ADD 梶谷 貴士 2021/05/10 ---------->>>>>
                        paraDisplayDivCode.Value = SqlDataMediator.SqlSetInt32(customerWork.DisplayDivCode);    //得意先情報ガイド表示区分
                        // --- ADD 梶谷 貴士 2021/05/10 ----------<<<<<
                        paraNoteInfo.Value = SqlDataMediator.SqlSetString(customerWork.NoteInfo);   // メモ
                        # endregion
                    }
                    sqlCommand.ExecuteNonQuery();
                }
                #endregion

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "得意先マスタの書込みに失敗しました。", ex.Number);
                sqlTransaction.Rollback();
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                if ((myReader != null) && (!myReader.IsClosed))
                {
                    myReader.Close();
                }

                myReader.Dispose();
            }

            return status;
        }
        # endregion

        # region 前橋京和商会個別について、得意先マスタと得意先メモDB論理削除処理
        /// <summary>
        /// 前橋京和商会個別について、得意先マスタと得意先メモDB論理削除処理
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <param name="carDeleteFlg">車両削除フラグ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタと得意先メモDBを論理削除します</br>
        /// <br>Programmer : 陳健</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        public int MaehashiLogicalDelete(ref object paraList, bool carDeleteFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            CustomerWork customerWork = null;

            ArrayList paraCustomList = paraList as ArrayList;

            //オブジェクトの取得(カスタムArray内から検索)
            if (paraCustomList == null)
            {
                base.WriteErrorLog("プログラムエラー。対象パラメータが未指定です", status);
                return status;
            }
            else if (paraCustomList.Count > 0)
            {
                // List内の得意先・備考・家族構成リストを抽出
                foreach (object obj in paraCustomList)
                {
                    if (customerWork == null)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = obj as CustomerWork;
                        }
                    }
                }
            }

            //削除予定
            if (customerWork == null)
            {
                base.WriteErrorLog("プログラムエラー。抽出対象オブジェクトパラメータが未指定です。", status);
                return status;
            }

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection_read = null;

            try
            {
                // 各publicメソッドの開始時にコネクション文字列を取得
                // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                    return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // Read用コネクションをインスタンス化
                sqlConnection_read = new SqlConnection(connectionText);
                sqlConnection_read.Open();

                // ログイン情報取得クラスをインスタンス化
                ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();

                CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                CustomerChangeWork paraCustomerChangeWork = new CustomerChangeWork();
                int CusChangestatus = 0;
                if (customerWork.CreditMngCode == 1)
                {
                    // パラメーター設定
                    paraCustomerChangeWork.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
                    paraCustomerChangeWork.CustomerCode = customerWork.CustomerCode;     // 得意先コード
                    // 得意先マスタ(変動情報)取得
                    CusChangestatus = customerChangeDB.ReadProc(ref paraCustomerChangeWork, 0, ref sqlConnection_read);
                }
                // 得意先(掛率グループ)取得
                CustRateGroupDB custRateGroupDB = new CustRateGroupDB();
                CustRateGroupWork custRateGroupWork = new CustRateGroupWork();
                ArrayList custRateGroupList = new ArrayList();
                int CustRtGrpstatus = 0;
                custRateGroupWork.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
                custRateGroupWork.CustomerCode = customerWork.CustomerCode;     // 得意先コード
                CustRtGrpstatus = custRateGroupDB.Search(ref custRateGroupList, custRateGroupWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                // 得意先(伝票番号)取得
                CustSlipNoSetDB custSlipNoSetDB = new CustSlipNoSetDB();
                CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();
                ArrayList custSlipNoSetList = new ArrayList();
                int CustSlipNostatus = 0;
                custSlipNoSetWork.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
                custSlipNoSetWork.CustomerCode = customerWork.CustomerCode;     // 得意先コード
                CustSlipNostatus = custSlipNoSetDB.Search(ref custSlipNoSetList, custSlipNoSetWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);



                // ================================================================================= //
                // 得意先マスタ論理削除
                // ================================================================================= //
                ArrayList duplicationItemList = new ArrayList();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (customerWork != null)
                    {
                        status = this.MaehashiLogicalDeleteCustomerWork(ref customerWork, ref sqlConnection, ref sqlTransaction, 0);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            customSerializeArrayList.Add((CustomerWork)customerWork);
                        }
                        if (customerWork.CreditMngCode == 1)
                        {
                            if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //パラメータのキャスト
                                ArrayList paraCustomerChangeList = new ArrayList();
                                paraCustomerChangeList.Add(paraCustomerChangeWork);

                                CusChangestatus = customerChangeDB.LogicalDeleteProc(ref paraCustomerChangeList, 0, ref sqlConnection, ref sqlTransaction);
                            }
                        }
                        // 得意先(掛率グループ)論理削除処理
                        if (CustRtGrpstatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustRtGrpstatus = custRateGroupDB.LogicalDelete(ref custRateGroupList, 0, ref sqlConnection, ref sqlTransaction);

                        }

                        // 得意先(伝票番号)論理削除処理
                        if (CustSlipNostatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustSlipNostatus = custSlipNoSetDB.LogicalDelete(ref custSlipNoSetList, 0, ref sqlConnection, ref sqlTransaction);

                        }


                    }
                }

                // コミット
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
            }
            // 例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "得意先マスタの論理削除に失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection_read != null)
                {
                    sqlConnection_read.Close();
                    sqlConnection_read.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }
            }

            paraList = (object)customSerializeArrayList;
            return status;
        }

        /// <summary>
        /// 前橋京和商会個別について、得意先マスタと得意先メモDB論理削除処理
        /// </summary>
        /// <param name="customerWork">得意先マスタオブジェクト</param>
        /// <param name="sqlConnection">sqlコネクションオブジェクト</param>
        /// <param name="sqlTransaction">sqlトランザクションオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタと得意先メモDBを論理削除します</br>
        /// <br>Programmer : 陳健</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        private int MaehashiLogicalDeleteCustomerWork(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int procMode)
        {
            int logicalDelCd = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF, ENTERPRISECODERF, CUSTOMERCODERF FROM CUSTOMERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction))
                {
                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomercode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                    findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                    sqlCommand.CommandTimeout = 3600;
                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != customerWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }
                        // 現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlCommand.CommandText = "UPDATE CUSTOMERRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        sqlCommand.CommandText += Environment.NewLine;
                        // CUSTOMERMEMORFが前橋京和商会個別に新追加した得意先メモDBをアップデートする。
                        sqlCommand.CommandText += "UPDATE CUSTOMERMEMORF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                        // KEYコマンドを再設定
                        findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                        if ((myReader != null) && (!myReader.IsClosed))
                        {
                            myReader.Close();
                            myReader.Dispose();
                        }

                        return status;
                    }

                    sqlCommand.Cancel();

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                    }

                    // 論理削除モードの場合
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            return status;
                        }
                        else if (logicalDelCd == 0)
                        {
                            customerWork.LogicalDeleteCode = 1;
                        }
                        else
                        {
                            customerWork.LogicalDeleteCode = 3;
                        }
                    }
                    // 復活モードの場合
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            customerWork.LogicalDeleteCode = 0;
                        }
                        else
                        {
                            if (logicalDelCd == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            }

                            if ((myReader != null) && (!myReader.IsClosed))
                            {
                                myReader.Close();
                                myReader.Dispose();
                            }

                            return status;
                        }
                    }

                    // Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdatedatetime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdcustomercode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdassemblyid1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdassemblyid2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicaldeletecode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定(更新用)
                    paraUpdatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerWork.UpdateDateTime);
                    paraUpdcustomercode.Value = SqlDataMediator.SqlSetString(customerWork.UpdEmployeeCode);
                    paraUpdassemblyid1.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId1);
                    paraUpdassemblyid2.Value = SqlDataMediator.SqlSetString(customerWork.UpdAssemblyId2);
                    paraLogicaldeletecode.Value = SqlDataMediator.SqlSetInt32(customerWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                if ((myReader != null) && (!myReader.IsClosed))
                {
                    myReader.Close();
                    myReader.Dispose();
                }

                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "得意先マスタの論理削除に失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "得意先マスタの論理削除に失敗しました。", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }

            return status;

        }
        # endregion

        #region 前橋京和商会個別について、得意先マスタと得意先メモDB物理削除処理
        /// <summary>
        /// 前橋京和商会個別について、得意先マスタと得意先メモDB物理処理
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタと得意先メモDBを物理削除します</br>
        /// <br>Programmer : 陳健</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        public int MaehashiDelete(ref object paraList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            CustomerWork customerWork = null;

            ArrayList paraCustomList = paraList as ArrayList;

            if (paraCustomList == null)
            {
                base.WriteErrorLog("プログラムエラー。対象パラメータが未指定です", status);
                return status;
            }
            else if (paraCustomList.Count > 0)
            {
                // List内の得意先・備考・家族構成リストを抽出
                foreach (object obj in paraCustomList)
                {
                    if (customerWork == null)
                    {
                        if (obj is CustomerWork)
                        {
                            customerWork = obj as CustomerWork;
                        }
                    }
                }
            }

            if (customerWork == null)
            {
                base.WriteErrorLog("プログラムエラー。抽出対象オブジェクトパラメータが未指定です。", status);
                return status;
            }

            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection_read = null;

            try
            {
                // 各publicメソッドの開始時にコネクション文字列を取得
                // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                    return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // Read用コネクションをインスタンス化
                sqlConnection_read = new SqlConnection(connectionText);
                sqlConnection_read.Open();

                // ログイン情報取得クラスをインスタンス化
                ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();

                // --- ADD 2008.10.14 >>>
                CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                CustomerChangeWork customerChangeWork = new CustomerChangeWork();
                int CusChangestatus = 0;
                // 得意先(掛率グループ)物理削除
                CustRateGroupDB custRateGroupDB = new CustRateGroupDB();
                CustRateGroupWork custRateGroupWork = new CustRateGroupWork();
                ArrayList custRateGroupList = new ArrayList();
                int CustRtGrpstatus = 0;

                // 得意先(伝票番号)物理削除
                CustSlipNoSetDB custSlipNoSetDB = new CustSlipNoSetDB();
                CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();
                ArrayList custSlipNoSetList = new ArrayList();
                int CustSlipNostatus = 0;


                // ================================================================================= //
                // 得意先マスタ物理削除
                // ================================================================================= //
                ArrayList duplicationItemList = new ArrayList();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (customerWork != null)
                    {
                        // --- ADD 2008.10.14 得意先マスタ(変動情報)物理削除処理 >>>
                        if (customerWork.CreditMngCode == 1)
                        {
                            // パラメーター設定
                            customerChangeWork.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
                            customerChangeWork.CustomerCode = customerWork.CustomerCode;     // 得意先コード
                            // 得意先マスタ(変動情報)取得
                            CusChangestatus = customerChangeDB.ReadProc(ref customerChangeWork, 0, ref sqlConnection_read);
                        }
                        // 得意先(掛率グループ)取得
                        custRateGroupWork.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
                        custRateGroupWork.CustomerCode = customerWork.CustomerCode;     // 得意先コード
                        CustRtGrpstatus = custRateGroupDB.Search(ref custRateGroupList, custRateGroupWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                        // 得意先(伝票番号)取得
                        custSlipNoSetWork.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
                        custSlipNoSetWork.CustomerCode = customerWork.CustomerCode;     // 得意先コード
                        CustSlipNostatus = custSlipNoSetDB.Search(ref custSlipNoSetList, custSlipNoSetWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);


                        status = this.MaehashiDeleteProc(ref customerWork, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            customSerializeArrayList.Add((CustomerWork)customerWork);
                        }
                         
                        if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //パラメータのキャスト
                            ArrayList changeWorkparaList = new ArrayList();
                            changeWorkparaList.Add(customerChangeWork);
                            CusChangestatus = customerChangeDB.DeleteProc(changeWorkparaList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 得意先(掛率グループ)物理削除処理
                        if (CustRtGrpstatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustRtGrpstatus = custRateGroupDB.Delete(custRateGroupList, ref sqlConnection, ref sqlTransaction);

                        }

                        // 得意先(伝票番号)物理削除処理
                        if (CustSlipNostatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustSlipNostatus = custSlipNoSetDB.Delete(custSlipNoSetList, ref sqlConnection, ref sqlTransaction);

                        }


                    }
                }

                // コミット
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
            }
            // 例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "得意先マスタの物理削除に失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                // コネクション破棄
                if (sqlConnection_read != null)
                {
                    sqlConnection_read.Close();
                    sqlConnection_read.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }
            }

            paraList = (object)customSerializeArrayList;
            return status;
        }

        /// <summary>
        /// 前橋京和商会個別について、得意先マスタと得意先メモDB物理処理
        /// </summary>
        /// <param name="customerWork">CustomSerializeList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタと得意先メモDBを物理削除します</br>
        /// <br>Programmer : 陳健</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        private int MaehashiDeleteProc(ref CustomerWork customerWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Selectコマンドの生成
                #region [SELECT文]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " FROM CUSTOMERRF" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                #endregion

                // Prameterオブジェクトの作成
                sqlCommand.Parameters.Clear();
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomercode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                // Parameterオブジェクトへ値設定
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != customerWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }

                    //Deleteコマンドの生成
                    #region [DELETE文]
                    sqlText = string.Empty;
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += " FROM CUSTOMERRF" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += Environment.NewLine;
                    // 得意先メモDB
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += " FROM CUSTOMERMEMORF" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;
                    #endregion

                    // KEYコマンドを再設定
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                    findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);
                }
                else
                {
                    // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                        myReader.Dispose();
                    }

                    return status;
                }

                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                if ((myReader != null) && (!myReader.IsClosed))
                {
                    myReader.Close();
                    myReader.Dispose();
                }

                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "得意先マスタの物理削除に失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "得意先マスタの物理削除に失敗しました。", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }

            return status;
        }
        #endregion

        # region 前橋京和商会個別について、得意先マスタと得意先メモDB論理削除復活処理
        /// <summary>
        /// 得意先マスタと得意先メモDB論理削除復活処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタと得意先メモDBの論理削除デーを復活します</br>
        /// <br>Programmer : 陳健</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        public int MaehashiRevivalLogicalDelete(string enterpriseCode, int customerCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            CustomerWork customerWork = new CustomerWork();
            CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection_read = null;

            try
            {
                // 各publicメソッドの開始時にコネクション文字列を取得
                // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "")
                    return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // Read用コネクションをインスタンス化
                sqlConnection_read = new SqlConnection(connectionText);
                sqlConnection_read.Open();

                // ログイン情報取得クラスをインスタンス化
                ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();


                CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                CustomerChangeWork paraCustomerChangeWork = new CustomerChangeWork();
                int CusChangestatus = 0;
                // 得意先(掛率グループ)復旧処理
                CustRateGroupDB custRateGroupDB = new CustRateGroupDB();
                CustRateGroupWork custRateGroupWork = new CustRateGroupWork();
                ArrayList custRateGroupList = new ArrayList();
                int CustRtGrpstatus = 0;

                // 得意先(伝票番号)復旧処理
                CustSlipNoSetDB custSlipNoSetDB = new CustSlipNoSetDB();
                CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();
                ArrayList custSlipNoSetList = new ArrayList();
                int CustSlipNostatus = 0;


                // 得意先マスタ復元処理
                ArrayList duplicationItemList = new ArrayList();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 得意先マスタパラメータ設定
                    customerWork.EnterpriseCode = enterpriseCode;
                    customerWork.CustomerCode = customerCode;

                    // 得意先マスタ取得処理
                    status = this.MaehashiReadCustomerWork(ref customerWork, ref sqlConnection_read, ConstantManagement.LogicalMode.GetData1);

                    if (customerWork.CreditMngCode == 1)
                    {
                        // パラメーター設定
                        paraCustomerChangeWork.EnterpriseCode = enterpriseCode; // 企業コード
                        paraCustomerChangeWork.CustomerCode = customerCode;     // 得意先コード
                        // 得意先マスタ(変動情報)取得
                        CusChangestatus = customerChangeDB.ReadProc(ref paraCustomerChangeWork, 0, ref sqlConnection_read);
                    }
                    // 得意先(掛率グループ)取得
                    custRateGroupWork.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
                    custRateGroupWork.CustomerCode = customerWork.CustomerCode;     // 得意先コード
                    CustRtGrpstatus = custRateGroupDB.Search(ref custRateGroupList, custRateGroupWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);

                    // 得意先(伝票番号)取得
                    custSlipNoSetWork.EnterpriseCode = customerWork.EnterpriseCode; // 企業コード
                    custSlipNoSetWork.CustomerCode = customerWork.CustomerCode;     // 得意先コード
                    CustSlipNostatus = custSlipNoSetDB.Search(ref custSlipNoSetList, custSlipNoSetWork, 0, ConstantManagement.LogicalMode.GetDataAll, ref sqlConnection, ref sqlTransaction);



                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = this.MaehashiLogicalDeleteCustomerWork(ref customerWork, ref sqlConnection, ref sqlTransaction, 1);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            customSerializeArrayList.Add(customerWork);
                        }

                        if (customerWork.CreditMngCode == 1)
                        {
                            // パラメーター設定
                            if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //パラメータのキャスト
                                ArrayList paraList = new ArrayList();
                                paraList.Add(paraCustomerChangeWork);
                                CusChangestatus = customerChangeDB.LogicalDeleteProc(ref paraList, 1, ref sqlConnection, ref sqlTransaction);
                            }
                        }
                        // 得意先(掛率グループ)復旧処理
                        if (CustRtGrpstatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustRtGrpstatus = custRateGroupDB.LogicalDelete(ref custRateGroupList, 1, ref sqlConnection, ref sqlTransaction);

                        }

                        // 得意先(伝票番号)復旧処理
                        if (CustSlipNostatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            CustSlipNostatus = custSlipNoSetDB.LogicalDelete(ref custSlipNoSetList, 1, ref sqlConnection, ref sqlTransaction);

                        }

                    }
                }

                // コミット
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
            }
            // 例外処理
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "得意先マスタの論理削除復元に失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "得意先マスタの論理削除復元に失敗しました。", status);
            }

            finally
            {
                // コネクション破棄
                if (sqlConnection_read != null)
                {
                    sqlConnection_read.Close();
                    sqlConnection_read.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }
            }

            return status;
        }
        # endregion

        #endregion ▲前橋京和商会個別
        // ADD 陳健 K2014/02/06 --------------------------------------<<<<<
    }
}
