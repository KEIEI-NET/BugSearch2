using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 入金確認表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入金確認表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22035 三橋 弘憲</br>
    /// <br>Date       : 2007.03.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>           :   2007.11.15  DC.NS 用に改造  横川昌令</br>
    /// <br></br>
    /// <br>Update Note: ＰＭ.Ｎ用に変更 </br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.07.01</br>
    /// <br></br>
    /// <br>Update Note: 不具合修正 </br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.21</br>
    /// <br></br>
    /// <br>Update Note: 不具合修正(値引・手数料のみのデータも抽出対象に修正 MANTIS ID:12645) </br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2009.04.20</br>
    /// <br></br>
    /// <br>Update Note: 速度チューニング</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/06/02</br>
    /// </remarks>
    [Serializable]
    public class DepsitListWorkDB : RemoteDB, IDepsitListWorkDB
    {
        /// <summary>
        /// 入金確認表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        public DepsitListWorkDB()
            :
        base("MAHNB02016D", "Broadleaf.Application.Remoting.ParamData.DepsitMainListResultWork", "DEPSITMAINRF") //基底クラスのコンストラクタ
        {
        }

        #region 入金のみ取得処理
        /// <summary>
        /// 指定された企業コードの入金確認表LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="depsitMainListResultWork">検索結果（入金）</param>
        /// <param name="depsitMainListParamWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの入金確認表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.06</br>
        public int SearchDepsitOnly(out object depsitMainListResultWork, object depsitMainListParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            depsitMainListResultWork = null;

            DepsitMainListParamWork _depsitMainListParamWork = depsitMainListParamWork as DepsitMainListParamWork;

            try
            {
                status = SearchDepsitOnlyProc(out depsitMainListResultWork, _depsitMainListParamWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchDepsitOnly Exception=" + ex.Message);
                depsitMainListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの入金確認表LISTを全て戻します
        /// </summary>
        /// <param name="depsitMainListResultWork">検索結果（入金）</param>
        /// <param name="depsitMainListParamWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの入金確認表LISTを全て戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.06</br>
        private int SearchDepsitOnlyProc(out object depsitMainListResultWork, DepsitMainListParamWork depsitMainListParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //@SqlEncryptInfo sqlEncryptInfo = null;

            depsitMainListResultWork = null;

            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //@//●暗号化部品準備処理
                //@sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF"});
                //@//暗号化キーOPEN（SQLExceptionの可能性有り）
                //@sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //入金データ取得実行部
                status = SearchDepsitMainAction(ref al, ref sqlConnection, depsitMainListParamWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchDepositOnlyProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    //@//暗号化キークローズ
                    //@if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            depsitMainListResultWork = al;

            return status;
        }
        #endregion

        #region 入金,引当取得処理 [DC.NSではサポートしていません]
        /*
        /// <summary>
        /// 指定された企業コードの入金確認表LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="depsitMainListResultWork">検索結果（入金）</param>
        /// <param name="depsitAlwcListResultWork">検索結果（引当）</param>
        /// <param name="depsitMainListParamWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの入金確認表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.06</br>
        public int SearchDepsitAndAllowance(out object depsitMainListResultWork, out object depsitAlwcListResultWork, object depsitMainListParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            depsitMainListResultWork = null;
            depsitAlwcListResultWork = null;

            DepsitMainListParamWork depsitMainListParamWork = depsitMainListParamWork as DepsitMainListParamWork;

            try
            {
                status = SearchDepsitAndAllowanceProc(out depsitMainListResultWork, out depsitAlwcListResultWork, depsitMainListParamWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchDepsitAndAllowance Exception=" + ex.Message);
                depsitMainListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの入金確認表LISTを全て戻します
        /// </summary>
        /// <param name="depsitMainListResultWork">検索結果（入金）</param>
        /// <param name="depsitAlwcListResultWork">検索結果（引当）</param>
        /// <param name="depsitMainListParamWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの入金確認表LISTを全て戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.06</br>
        private int SearchDepsitAndAllowanceProc(out object depsitMainListResultWork, out object depsitAlwcListResultWork, DepsitMainListParamWork depsitMainListParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int st1 = status;
            int st2 = status;
            SqlConnection sqlConnection = null;
            SqlEncryptInfo sqlEncryptInfo = null;

            depsitMainListResultWork = null;
            depsitAlwcListResultWork = null;

            ArrayList al = new ArrayList();   //抽出結果
            ArrayList al2 = new ArrayList();  //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //●暗号化部品準備処理
                sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //暗号化キーOPEN（SQLExceptionの可能性有り）
                sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //入金データ取得実行部
                st1 = SearchDepsitMainAction(ref al, ref sqlConnection, depsitMainListParamWork, logicalMode);
                //引当データ取得実行部
                st2 = SearchDepositAlwAction(ref al2, ref sqlConnection, depsitMainListParamWork, logicalMode);

                status = st1;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchDepsitAndAllowanceProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    //暗号化キークローズ
                    if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            depsitMainListResultWork = al;
            depsitAlwcListResultWork = al2;

            return status;
        }
        */
        #endregion

        #region 総合計取得処理
        /// <summary>
        /// 指定された企業コードの入金確認表LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="depsitMainListResultWork">検索結果（入金）</param>
        /// <param name="depsitMainListParamWork">検索パラメータ</param>
        /// <param name="sectionDepositDiv">0:金種のみ、1:金種＆拠点コード</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの入金確認表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.06</br>
        public int SearchAllTotal(out object depsitMainListResultWork, object depsitMainListParamWork, int sectionDepositDiv, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            depsitMainListResultWork = null;

            DepsitMainListParamWork _depsitMainListParamWork = depsitMainListParamWork as DepsitMainListParamWork;

            try
            {
                status = SearchAllTotalProc(out depsitMainListResultWork, _depsitMainListParamWork, sectionDepositDiv, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchAllTotal Exception=" + ex.Message);
                depsitMainListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの入金確認表LISTを全て戻します
        /// </summary>
        /// <param name="depsitMainListResultWork">検索結果（入金）</param>
        /// <param name="depsitMainListParamWork">検索パラメータ</param>
        /// <param name="sectionDepositDiv">0:金種のみ、1:金種＆拠点コード</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの入金確認表LISTを全て戻します</br>
        /// <br>Programmer : 22035 三橋 弘憲</br>
        /// <br>Date       : 2007.03.06</br>
        private int SearchAllTotalProc(out object depsitMainListResultWork, DepsitMainListParamWork depsitMainListParamWork, int sectionDepositDiv, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //@SqlEncryptInfo sqlEncryptInfo = null;

            depsitMainListResultWork = null;

            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //@//●暗号化部品準備処理
                //@sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //@//暗号化キーOPEN（SQLExceptionの可能性有り）
                //@sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //総合計取得実行部
                status = SearchAllTotalAction(ref al, ref sqlConnection, depsitMainListParamWork, sectionDepositDiv, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchAllTotalProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    //@//暗号化キークローズ
                    //@if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            depsitMainListResultWork = al;

            return status;
        }
        #endregion

        #region 入金データ取得処理（実行部）
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="depsitMainListParamWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchDepsitMainAction(ref ArrayList al, ref SqlConnection sqlConnection, DepsitMainListParamWork depsitMainListParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            //int OutPutDiv = 0;　//ソート順を適用する為の区分

            try
            {
                string selectTxt = string.Empty;

                #region Select文作成
                selectTxt += "SELECT DISTINCT" + Environment.NewLine;
                //selectTxt += "     DEPSIT2.CREATEDATETIMERF " + Environment.NewLine; // ADD 2009.02.18
                selectTxt += "     DEPSIT2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DEPOSITDEBITNOTECDRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DEPOSITSLIPNORF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.INPUTDEPOSITSECCDRF" + Environment.NewLine;
                selectTxt += "    ,SEC.SECTIONGUIDENMRF INPUTDEPOSITSECNMRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "    ,SEC1.SECTIONGUIDENMRF ADDUPSECNAMERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.INPUTDAYRF " + Environment.NewLine; // ADD 2009/03/26
                selectTxt += "    ,DEPSIT2.DEPOSITDATERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.ADDUPADATERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DEPOSITTOTALRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DEPOSITRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.FEEDEPOSITRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DISCOUNTDEPOSITRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.AUTODEPOSITCDRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DRAFTDRAWINGDATERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DRAFTKINDRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DRAFTKINDNAMERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DRAFTDIVIDERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DRAFTDIVIDENAMERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DRAFTNORF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DEPOSITAGENTCODERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DEPOSITAGENTNMRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DEPOSITINPUTAGENTCDRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.DEPOSITINPUTAGENTNMRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.CLAIMSNMRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.OUTLINERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.BANKCODERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT2.BANKNAMERF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD1.DEPOSITROWNORF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD1.MONEYKINDCODERF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD1.MONEYKINDNAMERF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD1.MONEYKINDDIVRF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD1.DEPOSITRF DEPOSITDTLRF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD1.VALIDITYTERMRF" + Environment.NewLine;
                selectTxt += "    ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                selectTxt += "    ,EMPLOY.NAMERF" + Environment.NewLine;
                selectTxt += " FROM" + Environment.NewLine;
                selectTxt += "(" + Environment.NewLine;
                selectTxt += " SELECT" + Environment.NewLine;
                selectTxt += "     DEPSIT.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT.ACPTANODRSTATUSRF" + Environment.NewLine;   // ADD 2010/06/02
                selectTxt += "    ,DEPSIT.DEPOSITSLIPNORF" + Environment.NewLine;
                selectTxt += " FROM DEPSITMAINRF DEPSIT " + Environment.NewLine;
                // 修正 2009/04/20 入金明細が存在しなくても抽出対象にする(値引・手数料のみの場合、入金明細ができないため) >>>
                //selectTxt += " INNER JOIN DEPSITDTLRF DEPSITD ON DEPSITD.ENTERPRISECODERF=DEPSIT.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " LEFT JOIN DEPSITDTLRF DEPSITD ON DEPSITD.ENTERPRISECODERF=DEPSIT.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009/04/20 <<<
                selectTxt += " AND DEPSITD.ACPTANODRSTATUSRF=DEPSIT.ACPTANODRSTATUSRF" + Environment.NewLine;  // ADD 2010/06/02
                selectTxt += " AND DEPSITD.DEPOSITSLIPNORF=DEPSIT.DEPOSITSLIPNORF" + Environment.NewLine;

                #region WHERE句
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += " DEPSIT.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    selectTxt += " AND DEPSIT.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    selectTxt += " AND DEPSIT.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                }
                //拠点コード    ※配列で複数指定される
                if (depsitMainListParamWork.DepositAddupSecCodeList != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in depsitMainListParamWork.DepositAddupSecCodeList)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }

                    if (sectionCodestr != "")
                    {
                        selectTxt += " AND DEPSIT.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                    }
                }
                //入金計上日条件設定
                if (depsitMainListParamWork.St_AddUpADate != 0)
                {
                    selectTxt += " AND DEPSIT.ADDUPADATERF >= " + depsitMainListParamWork.St_AddUpADate.ToString();
                }
                if (depsitMainListParamWork.Ed_AddUpADate != 0)
                {
                    if (depsitMainListParamWork.St_AddUpADate == 0)
                    {
                        selectTxt += " AND (DEPSIT.ADDUPADATERF IS NULL OR";
                    }
                    else
                    {
                        selectTxt += " AND";
                    }
                    selectTxt += " DEPSIT.ADDUPADATERF <= " + depsitMainListParamWork.Ed_AddUpADate.ToString();
                    if (depsitMainListParamWork.St_AddUpADate == 0)
                    {
                        selectTxt += " ) ";
                    }
                }

                //入金入力日条件設定
                if (depsitMainListParamWork.St_CreateDate != 0)
                {
                    //selectTxt += " AND DEPSIT.DEPOSITDATERF >= " + depsitMainListParamWork.St_CreateDate.ToString();
                    selectTxt += " AND DEPSIT.INPUTDAYRF >= " + depsitMainListParamWork.St_CreateDate.ToString(); // ADD 2009/03/26
                }
                if (depsitMainListParamWork.Ed_CreateDate != 0)
                {
                    if (depsitMainListParamWork.St_CreateDate == 0)
                    {
                        //selectTxt += " AND (DEPSIT.DEPOSITDATERF IS NULL OR";
                        selectTxt += " AND (DEPSIT.INPUTDAYRF IS NULL OR";  //ADD 2009/03/26
                    }
                    else
                    {
                        selectTxt += " AND";
                    }
                    //selectTxt += " DEPSIT.DEPOSITDATERF <= " + depsitMainListParamWork.Ed_CreateDate.ToString();
                    selectTxt += " DEPSIT.INPUTDAYRF <= " + depsitMainListParamWork.Ed_CreateDate.ToString(); // ADD 2009/03/26
                    if (depsitMainListParamWork.St_CreateDate == 0)
                    {
                        selectTxt += " ) ";
                    }
                }

                //得意先コード設定
                if (depsitMainListParamWork.St_CustomerCode != 0)
                {
                    selectTxt += " AND DEPSIT.CUSTOMERCODERF>=@STCUSTOMERCODE ";
                }
                if (depsitMainListParamWork.Ed_CustomerCode != 0)
                {
                    selectTxt += " AND DEPSIT.CUSTOMERCODERF<=@EDCUSTOMERCODE ";
                }

                //カナ設定
                if (depsitMainListParamWork.St_CustomerKana != "")
                {
                    selectTxt += " AND CUST.KANARF>=@STKANA ";
                }
                if (depsitMainListParamWork.Ed_CustomerKana != "")
                {
                    selectTxt += " AND (CUST.KANARF<=@EDKANA OR CUST.KANARF LIKE @EDKANA) ";
                }

                //担当者区分
                switch (depsitMainListParamWork.EmployeeKind)
                {
                    case 0:
                        {
                            //得意先担当者設定
                            if (depsitMainListParamWork.St_EmployeeCd != "")
                            {
                                selectTxt += " AND CUST.CUSTOMERAGENTCDRF>=@STCUSTOMERAGENTCD ";
                            }
                            if (depsitMainListParamWork.Ed_EmployeeCd != "")
                            {
                                if (depsitMainListParamWork.St_EmployeeCd == "")
                                {
                                    selectTxt += " AND (CUST.CUSTOMERAGENTCDRF IS NULL OR";
                                }
                                else
                                {
                                    selectTxt += " AND (";
                                }

                                selectTxt += " CUST.CUSTOMERAGENTCDRF<=@EDCUSTOMERAGENTCD OR CUST.CUSTOMERAGENTCDRF LIKE @EDCUSTOMERAGENTCD) ";
                            }
                            break;
                        }
                    case 1:
                        {
                            //集金担当者設定
                            if (depsitMainListParamWork.St_EmployeeCd != "")
                            {
                                selectTxt += " AND CUST.BILLCOLLECTERCDRF>=@STDEPOSITAGENTCODE ";
                            }
                            if (depsitMainListParamWork.Ed_EmployeeCd != "")
                            {
                                if (depsitMainListParamWork.St_EmployeeCd == "")
                                {
                                    selectTxt += " AND (CUST.BILLCOLLECTERCDRF IS NULL OR";
                                }
                                else
                                {
                                    selectTxt += " AND (";
                                }

                                selectTxt += " CUST.BILLCOLLECTERCDRF<=@EDDEPOSITAGENTCODE OR CUST.BILLCOLLECTERCDRF LIKE @EDDEPOSITAGENTCODE) ";
                            }
                            break;
                        }
                    case 2:
                        {
                            //入金担当者設定
                            if (depsitMainListParamWork.St_EmployeeCd != "")
                            {
                                selectTxt += " AND DEPSIT.DEPOSITAGENTCODERF>=@STDEPOSITAGENTCODE ";
                            }
                            if (depsitMainListParamWork.Ed_EmployeeCd != "")
                            {
                                if (depsitMainListParamWork.St_EmployeeCd == "")
                                {
                                    selectTxt += " AND (DEPSIT.DEPOSITAGENTCODERF IS NULL OR";
                                }
                                else
                                {
                                    selectTxt += " AND (";
                                }

                                selectTxt += " DEPSIT.DEPOSITAGENTCODERF<=@EDDEPOSITAGENTCODE OR DEPSIT.DEPOSITAGENTCODERF LIKE @EDDEPOSITAGENTCODE) ";
                            }
                            break;
                        }
                    case 3:
                        {
                            //入金入力者設定
                            if (depsitMainListParamWork.St_EmployeeCd != "")
                            {
                                selectTxt += " AND DEPSIT.DEPOSITINPUTAGENTCDRF>=@STDEPOSITINPUTAGENTCD ";
                            }
                            if (depsitMainListParamWork.Ed_EmployeeCd != "")
                            {
                                if (depsitMainListParamWork.St_EmployeeCd == "")
                                {
                                    selectTxt += " AND (DEPSIT.DEPOSITINPUTAGENTCDRF IS NULL OR";
                                }
                                else
                                {
                                    selectTxt += " AND (";
                                }

                                selectTxt += " DEPSIT.DEPOSITINPUTAGENTCDRF<=@EDDEPOSITINPUTAGENTCD OR DEPSIT.DEPOSITINPUTAGENTCDRF LIKE @EDDEPOSITINPUTAGENTCD) ";
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                //入金伝票番号設定
                if (depsitMainListParamWork.St_DepositSlipNo != 0)
                {
                    selectTxt += " AND DEPSIT.DEPOSITSLIPNORF>=@STDEPOSITSLIPNO ";
                }
                if (depsitMainListParamWork.Ed_DepositSlipNo != 0)
                {
                    selectTxt += " AND DEPSIT.DEPOSITSLIPNORF<=@EDDEPOSITSLIPNO ";
                }

                //入金金種設定
                if (depsitMainListParamWork.DepositCdKind != null)
                {
                    if (depsitMainListParamWork.DepositCdKind.Count > 0)
                    {
                        if (Convert.ToInt32(depsitMainListParamWork.DepositCdKind[0]) > -1)
                        {
                            ArrayList DepositKindArray = new ArrayList(depsitMainListParamWork.DepositCdKind);
                            if ((DepositKindArray != null) && (DepositKindArray.Count > 0))
                            {
                                string depositKindint = "";
                                int kindint;
                                for (int i = 0; i < DepositKindArray.Count; i++)
                                {
                                    kindint = Convert.ToInt32(DepositKindArray[i]);
                                    if (kindint != -1)
                                    {
                                        if (depositKindint != "")
                                        {
                                            depositKindint += ",";
                                        }
                                        depositKindint += "'" + kindint + "'";
                                    }
                                }

                                if (depositKindint != "")
                                {
                                    selectTxt += " AND DEPSITD.MONEYKINDCODERF IN (" + depositKindint + ") ";
                                }
                            }
                        }
                    }
                }

                ////預り金区分
                //if (depsitMainListParamWork.DepositCd != -1)
                //{
                //    switch (depsitMainListParamWork.DepositCd)
                //    {
                //        case 0:     // 全て
                //            break;
                //        case 1:     // 通常
                //            selectTxt += " AND DEPSIT.DEPOSITCDRF=0 AND DEPSIT.AUTODEPOSITCDRF=0 ";
                //            break;
                //        case 2:     // 預り金
                //            selectTxt += " AND DEPSIT.DEPOSITCDRF=1 ";
                //            break;
                //        case 3:     // 自動
                //            selectTxt += " AND DEPSIT.AUTODEPOSITCDRF=1 ";
                //            break;
                //        default:
                //            break;
                //    }
                //}

                // 入金区分(0:全て 1:通常入金のみ 2:自動入金のみ)
                switch (depsitMainListParamWork.DepositDiv)
                {
                    case 1:
                        {
                            selectTxt += " AND DEPSIT.AUTODEPOSITCDRF = 0 ";
                            break;
                        }
                    case 2:
                        {
                            selectTxt += " AND DEPSIT.AUTODEPOSITCDRF = 1 ";
                            break;
                        }
                }

                // --- ADD 2008.10.10 ---------->>>>>
                //引当区分AllowanceDiv
                if (depsitMainListParamWork.AllowanceDiv != 0)
                {
                    switch (depsitMainListParamWork.AllowanceDiv)
                    {
                        case 1:  //引当済み  入金引当額[DepositAllowanceRF]＝入金引当残高[DepositAlwcBlnceRF]の時、且つ、0以外
                            //          入金引当額[DepositAllowanceRF]が0以外、且つ、入金引当残高[DepositAlwcBlnceRF]=0
                            selectTxt += " AND (DEPSIT.DEPOSITALLOWANCERF!=0 AND DEPSIT.DEPOSITALWCBLNCERF=0) ";
                            break;
                        case 2:  //一部引当  入金引当額[DepositAllowanceRF]≠0 且つ、入金引当残高[DepositAlwcBlnceRF]≠0の時
                            selectTxt += " AND (DEPSIT.DEPOSITALLOWANCERF<>0 AND DEPSIT.DEPOSITALWCBLNCERF<>0) ";
                            break;
                        case 3:  //未引当  入金引当額[DepositAllowanceRF]=0、且つ、入金引当残高[DepositAlwcBlnceRF]が0以外
                            selectTxt += " AND (DEPSIT.DEPOSITALLOWANCERF=0 AND DEPSIT.DEPOSITALWCBLNCERF<>0) ";
                            break;
                        default:
                            break;
                    }
                }
                // --- ADD 2008.10.10 ----------<<<<<
                #endregion

                selectTxt += ") AS DEPSIT1" + Environment.NewLine;
                selectTxt += " INNER JOIN DEPSITMAINRF DEPSIT2 ON DEPSIT2.ENTERPRISECODERF=DEPSIT1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND DEPSIT2.ACPTANODRSTATUSRF=DEPSIT1.ACPTANODRSTATUSRF" + Environment.NewLine;  // ADD 2010/06/02
                selectTxt += " AND DEPSIT2.DEPOSITSLIPNORF=DEPSIT1.DEPOSITSLIPNORF" + Environment.NewLine;
                // 修正 2009/04/20 >>>
                //selectTxt += " INNER JOIN DEPSITDTLRF DEPSITD1 ON DEPSITD1.ENTERPRISECODERF=DEPSIT1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " LEFT JOIN DEPSITDTLRF DEPSITD1 ON DEPSITD1.ENTERPRISECODERF=DEPSIT1.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009/04/20 <<<
                selectTxt += " AND DEPSITD1.ACPTANODRSTATUSRF=DEPSIT1.ACPTANODRSTATUSRF" + Environment.NewLine;  // ADD 2010/06/02
                selectTxt += " AND DEPSITD1.DEPOSITSLIPNORF=DEPSIT1.DEPOSITSLIPNORF" + Environment.NewLine;
                selectTxt += " INNER JOIN SECINFOSETRF SEC ON SEC.ENTERPRISECODERF=DEPSIT1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SEC.SECTIONCODERF=DEPSIT2.INPUTDEPOSITSECCDRF" + Environment.NewLine;
                selectTxt += " INNER JOIN SECINFOSETRF SEC1 ON SEC1.ENTERPRISECODERF=DEPSIT1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SEC1.SECTIONCODERF=DEPSIT2.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += " INNER JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=DEPSIT1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUST.CUSTOMERCODERF=DEPSIT2.CUSTOMERCODERF" + Environment.NewLine;
                //selectTxt += " INNER JOIN EMPLOYEERF EMPLOY ON EMPLOY.ENTERPRISECODERF=DEPSIT1.ENTERPRISECODERF" + Environment.NewLine; // DEL 2008.11.21
                selectTxt += " LEFT JOIN EMPLOYEERF EMPLOY ON EMPLOY.ENTERPRISECODERF=DEPSIT1.ENTERPRISECODERF" + Environment.NewLine;  // ADD 2008.11.21
                selectTxt += " AND EMPLOY.EMPLOYEECODERF=CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Prameterオブジェクトの作成/値設定
                SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.EnterpriseCode);


                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                if (depsitMainListParamWork.St_CustomerCode != 0)
                {
                    SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                    paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(depsitMainListParamWork.St_CustomerCode);
                }
                if (depsitMainListParamWork.Ed_CustomerCode != 0)
                {
                    SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                    paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(depsitMainListParamWork.Ed_CustomerCode);
                }

                //カナ設定
                if (depsitMainListParamWork.St_CustomerKana != "")
                {
                    SqlParameter paraStCustomerKana = sqlCommand.Parameters.Add("@STKANA", SqlDbType.NVarChar);
                    paraStCustomerKana.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_CustomerKana);
                }
                if (depsitMainListParamWork.Ed_CustomerKana != "")
                {
                    SqlParameter paraEdCustomerKana = sqlCommand.Parameters.Add("@EDKANA", SqlDbType.NVarChar);
                    paraEdCustomerKana.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_CustomerKana + "%");
                }

                //担当者区分
                switch (depsitMainListParamWork.EmployeeKind)
                {
                    case 0:
                        {
                            //得意先担当者設定
                            if (depsitMainListParamWork.St_EmployeeCd != "")
                            {
                                SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STCUSTOMERAGENTCD", SqlDbType.NChar);
                                paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_EmployeeCd);
                            }
                            if (depsitMainListParamWork.Ed_EmployeeCd != "")
                            {
                                SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDCUSTOMERAGENTCD", SqlDbType.NChar);
                                paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_EmployeeCd + "%");
                            }
                            break;
                        }
                    case 1:
                        {
                            //集金担当者設定
                            if (depsitMainListParamWork.St_EmployeeCd != "")
                            {
                                SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STDEPOSITAGENTCODE", SqlDbType.NChar);
                                paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_EmployeeCd);
                            }
                            if (depsitMainListParamWork.Ed_EmployeeCd != "")
                            {
                                SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDDEPOSITAGENTCODE", SqlDbType.NChar);
                                paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_EmployeeCd + "%");
                            }
                            break;
                        }
                    case 2:
                        {
                            //入金担当者設定
                            if (depsitMainListParamWork.St_EmployeeCd != "")
                            {
                                SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STDEPOSITAGENTCODE", SqlDbType.NChar);
                                paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_EmployeeCd);
                            }
                            if (depsitMainListParamWork.Ed_EmployeeCd != "")
                            {
                                SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDDEPOSITAGENTCODE", SqlDbType.NChar);
                                paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_EmployeeCd + "%");
                            }
                            break;
                        }
                    case 3:
                        {
                            //入金入力者設定
                            if (depsitMainListParamWork.St_EmployeeCd != "")
                            {
                                SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STDEPOSITINPUTAGENTCD", SqlDbType.NChar);
                                paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_EmployeeCd);
                            }
                            if (depsitMainListParamWork.Ed_EmployeeCd != "")
                            {
                                SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDDEPOSITINPUTAGENTCD", SqlDbType.NChar);
                                paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_EmployeeCd + "%");
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                if (depsitMainListParamWork.St_DepositSlipNo != 0)
                {
                    SqlParameter paraStDepositSlipNo = sqlCommand.Parameters.Add("@STDEPOSITSLIPNO", SqlDbType.Int);
                    paraStDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainListParamWork.St_DepositSlipNo);
                }
                if (depsitMainListParamWork.Ed_DepositSlipNo != 0)
                {
                    SqlParameter paraEdDepositSlipNo = sqlCommand.Parameters.Add("@EDDEPOSITSLIPNO", SqlDbType.Int);
                    paraEdDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainListParamWork.Ed_DepositSlipNo);
                }
                #endregion

                ////WHERE文の作成
                //sqlCommand.CommandText += MakeWhereString(ref sqlCommand, depsitMainListParamWork, OutPutDiv, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    DepsitMainListResultWork wkDepsitMainListResultWork = new DepsitMainListResultWork();
                    //wkDepsitMainListResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkDepsitMainListResultWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
                    wkDepsitMainListResultWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                    wkDepsitMainListResultWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                    wkDepsitMainListResultWork.InputDepositSecNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECNMRF"));
                    wkDepsitMainListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    wkDepsitMainListResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
                    wkDepsitMainListResultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));  // ADD 2009/03/26
                    wkDepsitMainListResultWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
                    wkDepsitMainListResultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    wkDepsitMainListResultWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"));
                    wkDepsitMainListResultWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
                    wkDepsitMainListResultWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));
                    wkDepsitMainListResultWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
                    wkDepsitMainListResultWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                    wkDepsitMainListResultWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                    wkDepsitMainListResultWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                    wkDepsitMainListResultWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                    wkDepsitMainListResultWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                    wkDepsitMainListResultWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                    wkDepsitMainListResultWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                    wkDepsitMainListResultWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                    wkDepsitMainListResultWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                    wkDepsitMainListResultWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTCDRF"));
                    wkDepsitMainListResultWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));
                    wkDepsitMainListResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    wkDepsitMainListResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    wkDepsitMainListResultWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                    wkDepsitMainListResultWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                    wkDepsitMainListResultWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                    wkDepsitMainListResultWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                    wkDepsitMainListResultWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                    wkDepsitMainListResultWork.DepositRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITROWNORF"));
                    wkDepsitMainListResultWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
                    wkDepsitMainListResultWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                    wkDepsitMainListResultWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
                    wkDepsitMainListResultWork.DepositDtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITDTLRF"));
                    wkDepsitMainListResultWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
                    wkDepsitMainListResultWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
                    wkDepsitMainListResultWork.CustomerAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                    #endregion

                    al.Add(wkDepsitMainListResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchDepsitMainAction Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {

                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region 引当データ取得処理（実行部）[DC.NSではサポートしていません]
        /*
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="depsitMainListParamWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchDepositAlwAction(ref ArrayList al, ref SqlConnection sqlConnection, DepsitMainListParamWork depsitMainListParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            int OutPutDiv = 1;

            try
            {
                // 対象テーブル
                // DEPOSITMAINRF  DPM   入金マスタ
                // CUSTOMERRF     CTM   得意先マスタ
                // DEPOSITALWRF   DPA   入金引当マスタ
                // SALESSLIPRF    SLS   売上データ
                // SECINFOSETRF   SIS   拠点情報設定マスタ
                // SECINFOSETRF   SIS2  拠点情報設定マスタ
                // SECINFOSETRF   SIS3  拠点情報設定マスタ

                string SelectDm = "";

                #region Select文作成
                SelectDm += "SELECT";

                //入金マスタ結果取得
                SelectDm += " DPA.RECONCILEADDUPDATERF DPA_RECONCILEADDUPDATERF";
                SelectDm += ", DPA.ACCEPTANORDERNORF DPA_ACCEPTANORDERNORF";
                SelectDm += ", SLS.ACPTANODRSTATUSRF SLS_ACPTANODRSTATUSRF";
                SelectDm += ", SLS.SALESSLIPNUMRF SLS_SALESSLIPNUMRF";
                SelectDm += ", SLS.ACPTANODRSLIPNUMRF SLS_ACPTANODRSLIPNUMRF";
                SelectDm += ", SLS.ESTIMATESLIPNORF SLS_ESTIMATESLIPNORF";
                SelectDm += ", SLS.DEBITNOTEDIVRF SLS_DEBITNOTEDIVRF";
                SelectDm += ", SLS.DEBITNLNKACPTANODRRF SLS_DEBITNLNKACPTANODRRF";
                SelectDm += ", SLS.SALESSLIPCDRF SLS_SALESSLIPCDRF";
                SelectDm += ", SLS.SALESFORMALRF SLS_SALESFORMALRF";
                SelectDm += ", SLS.SALESINPSECCDRF SLS_SALESINPSECCDRF";
                SelectDm += ", SIS.SECTIONGUIDENMRF SIS_SALESINPSECNMRF";
                SelectDm += ", SLS.RESULTSADDUPSECCDRF SLS_RESULTSADDUPSECCDRF";
                SelectDm += ", SIS2.SECTIONGUIDENMRF SIS2_RESULTSADDUPSECNMRF";
                SelectDm += ", SLS.UPDATESECCDRF SLS_UPDATESECCDRF";
                SelectDm += ", SIS3.SECTIONGUIDENMRF SIS3_UPDATESECCDRF";
                SelectDm += ", SLS.ESTIMATEDATERF SLS_ESTIMATEDATERF";
                SelectDm += ", SLS.ACCEPTANORDERDATERF SLS_ACCEPTANORDERDATERF";
                SelectDm += ", SLS.SALESDATERF SLS_SALESDATERF";
                SelectDm += ", SLS.ADDUPADATERF SLS_SALESADDUPADATERF";
                SelectDm += ", SLS.ACCRECDIVCDRF SLS_ACCRECDIVCDRF";
                SelectDm += ", SLS.DEMANDABLETTLRF SLS_DEMANDABLETTLRF";
                SelectDm += ", SLS.DEPOSITALLOWANCETTLRF SLS_DEPOSITALLOWANCETTLRF";
                SelectDm += ", SLS.MNYDEPOALLOWANCETTLRF SLS_MNYDEPOALLOWANCETTLRF";
                SelectDm += ", SLS.DEPOSITALWCBLNCERF SLS_DEPOSITALWCBLNCERF";
                SelectDm += ", SLS.CLAIMCODERF SLS_CLAIMCODERF";
                SelectDm += ", SLS.CLAIMNAME1RF SLS_CLAIMNAME1RF";
                SelectDm += ", SLS.CLAIMNAME2RF SLS_CLAIMNAME2RF";
                SelectDm += ", SLS.CUSTOMERCODERF SLS_CUSTOMERCODERF";
                SelectDm += ", SLS.CUSTOMERNAMERF SLS_CUSTOMERNAMERF";
                SelectDm += ", SLS.CUSTOMERNAME2RF SLS_CUSTOMERNAME2RF";
                SelectDm += ", SLS.HONORIFICTITLERF SLS_HONORIFICTITLERF";
                SelectDm += ", SLS.KANARF SLS_KANARF";

                //2007.03.16 22035 三橋 add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
                //売上データ変更に伴う取得項目追加
                SelectDm += ", SLS.SEARCHSLIPNUMRF SLS_SEARCHSLIPNUMRF";
                SelectDm += ", SLS.SALESSLIPKINDRF SLS_SALESSLIPKINDRF";
                //2007.03.16 22035 三橋 add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<END

                SelectDm += ", DPA.ADDUPSECCODERF DPA_ADDUPSECCODERF";
                SelectDm += ", SIS4.SECTIONGUIDENMRF SIS4_SECTIONGUIDENMRF";
                SelectDm += ", DPA.DEPOSITSLIPNORF DPA_DEPOSITSLIPNORF";

                SelectDm += " FROM DEPSITMAINRF DPM";

                SelectDm += " LEFT JOIN CUSTOMERRF CTM ON CTM.ENTERPRISECODERF=DPM.ENTERPRISECODERF AND CTM.CUSTOMERCODERF=DPM.CUSTOMERCODERF";
                SelectDm += " LEFT JOIN DEPOSITALWRF DPA ON DPA.ENTERPRISECODERF=DPM.ENTERPRISECODERF AND DPA.DEPOSITSLIPNORF=DPM.DEPOSITSLIPNORF";
                SelectDm += " LEFT JOIN SALESSLIPRF SLS ON SLS.ENTERPRISECODERF=DPA.ENTERPRISECODERF AND SLS.ACCEPTANORDERNORF=DPA.ACCEPTANORDERNORF";
                SelectDm += " LEFT JOIN SECINFOSETRF SIS ON SIS.ENTERPRISECODERF=SLS.ENTERPRISECODERF AND SIS.SECTIONCODERF=SLS.SALESINPSECCDRF";
                SelectDm += " LEFT JOIN SECINFOSETRF SIS2 ON SIS2.ENTERPRISECODERF=SLS.ENTERPRISECODERF AND SIS2.SECTIONCODERF=SLS.DEMANDADDUPSECCDRF";
                SelectDm += " LEFT JOIN SECINFOSETRF SIS3 ON SIS3.ENTERPRISECODERF=SLS.ENTERPRISECODERF AND SIS3.SECTIONCODERF=SLS.RESULTSADDUPSECCDRF";
                SelectDm += " LEFT JOIN SECINFOSETRF SIS4 ON SIS4.ENTERPRISECODERF=DPA.ENTERPRISECODERF AND SIS4.SECTIONCODERF=DPA.ADDUPSECCODERF";
                #endregion

                sqlCommand = new SqlCommand(SelectDm, sqlConnection);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, depsitMainListParamWork, OutPutDiv, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    DepsitAlwcListResultWork wkDepsitAlwcListResultWork = new DepsitAlwcListResultWork();

                    //在庫車両入出庫管理マスタ結果取得内容格納
                    wkDepsitAlwcListResultWork.ReconcileAddUpDate  = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DPA_RECONCILEADDUPDATERF"));
                    wkDepsitAlwcListResultWork.AcceptAnOrderNo     = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DPA_ACCEPTANORDERNORF"));
                    wkDepsitAlwcListResultWork.AcptAnOdrStatus     = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_ACPTANODRSTATUSRF"));
                    wkDepsitAlwcListResultWork.SalesSlipNum        = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_SALESSLIPNUMRF"));
                    wkDepsitAlwcListResultWork.AcptAnOdrSlipNum    = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_ACPTANODRSLIPNUMRF"));
                    wkDepsitAlwcListResultWork.EstimateSlipNo      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_ESTIMATESLIPNORF"));
                    wkDepsitAlwcListResultWork.DebitNoteDiv        = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_DEBITNOTEDIVRF"));
                    wkDepsitAlwcListResultWork.DebitNLnkAcptAnOdr  = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_DEBITNLNKACPTANODRRF"));
                    wkDepsitAlwcListResultWork.SalesSlipCd         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_SALESSLIPCDRF"));
                    wkDepsitAlwcListResultWork.SalesFormal         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_SALESFORMALRF"));
                    wkDepsitAlwcListResultWork.SalesInpSecCd       = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_SALESINPSECCDRF"));
                    wkDepsitAlwcListResultWork.SalesInpSecNm       = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SIS_SALESINPSECNMRF"));
                    wkDepsitAlwcListResultWork.ResultsAddUpSecCd   = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_RESULTSADDUPSECCDRF"));
                    wkDepsitAlwcListResultWork.ResultsAddUpSecNm   = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SIS2_RESULTSADDUPSECNMRF"));
                    wkDepsitAlwcListResultWork.UpdateSecCd         = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_UPDATESECCDRF"));
                    wkDepsitAlwcListResultWork.UpdateSecNm         = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SIS3_UPDATESECCDRF"));
                    wkDepsitAlwcListResultWork.EstimateDate        = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SLS_ESTIMATEDATERF"));
                    wkDepsitAlwcListResultWork.AcceptAnOrderDate   = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SLS_ACCEPTANORDERDATERF"));
                    wkDepsitAlwcListResultWork.SalesDate           = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SLS_SALESDATERF"));
                    wkDepsitAlwcListResultWork.SalesAddUpADate     = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SLS_SALESADDUPADATERF"));
                    wkDepsitAlwcListResultWork.AccRecDivCd         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_ACCRECDIVCDRF"));
                    wkDepsitAlwcListResultWork.DemandableTtl       = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLS_DEMANDABLETTLRF"));
                    wkDepsitAlwcListResultWork.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLS_DEPOSITALLOWANCETTLRF"));
                    wkDepsitAlwcListResultWork.MnyDepoAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLS_MNYDEPOALLOWANCETTLRF"));
                    wkDepsitAlwcListResultWork.DepositAlwcBlnce    = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLS_DEPOSITALWCBLNCERF"));
                    wkDepsitAlwcListResultWork.ClaimCode           = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_CLAIMCODERF"));
                    wkDepsitAlwcListResultWork.ClaimName1          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_CLAIMNAME1RF"));
                    wkDepsitAlwcListResultWork.ClaimName2          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_CLAIMNAME2RF"));
                    wkDepsitAlwcListResultWork.CustomerCode        = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_CUSTOMERCODERF"));
                    wkDepsitAlwcListResultWork.ClaimName1          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_CUSTOMERNAMERF"));
                    wkDepsitAlwcListResultWork.ClaimName2          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_CUSTOMERNAME2RF"));
                    wkDepsitAlwcListResultWork.HonorificTitle      = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_HONORIFICTITLERF"));
                    wkDepsitAlwcListResultWork.Kana                = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_KANARF"));

                    wkDepsitAlwcListResultWork.DepositAddupSecCd   = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DPA_ADDUPSECCODERF"));
                    wkDepsitAlwcListResultWork.DepositAddupSecNm   = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SIS4_SECTIONGUIDENMRF"));
                    wkDepsitAlwcListResultWork.DepositSlipNo       = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DPA_DEPOSITSLIPNORF"));
                    wkDepsitAlwcListResultWork.SearchSlipNum       = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLS_SEARCHSLIPNUMRF"));
                    wkDepsitAlwcListResultWork.SalesSlipKind       = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLS_SALESSLIPKINDRF"));
                    #endregion

                    al.Add(wkDepsitAlwcListResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchDepsitAlwAction Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        */ 
        #endregion

        #region 総合計取得処理（実行部）
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="depsitMainListParamWork">検索条件格納クラス</param>
        /// <param name="sectionDepositDiv">0:金種のみ、1:金種＆拠点コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchAllTotalAction(ref ArrayList al, ref SqlConnection sqlConnection, DepsitMainListParamWork depsitMainListParamWork, int sectionDepositDiv, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            int OutPutDiv = 2;

            try
            {
                string selectTxt = string.Empty;

                #region Select文作成
                //拠点＆金種＆預り金＆自動入金区分で集計を行う場合
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "     DEPSIT.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "    ,SEC.SECTIONGUIDENMRF ADDUPSECNAMERF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT.ADDUPADATERF" + Environment.NewLine;
                selectTxt += "    ,SUM(DEPSIT.DEPOSITTOTALRF) SUM_DEPOSITTOTALRF" + Environment.NewLine;
                selectTxt += "    ,SUM(DEPSIT.DEPOSITRF) SUM_DEPOSITRF" + Environment.NewLine;
                selectTxt += "    ,SUM(DEPSIT.FEEDEPOSITRF) SUM_FEEDEPOSITRF" + Environment.NewLine;
                selectTxt += "    ,SUM(DEPSIT.DISCOUNTDEPOSITRF) SUM_DISCOUNTDEPOSITRF" + Environment.NewLine;
                selectTxt += "    ,DEPSIT.AUTODEPOSITCDRF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD.MONEYKINDCODERF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD.MONEYKINDNAMERF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD.MONEYKINDDIVRF" + Environment.NewLine;
                selectTxt += "    ,DEPSITD.DEPOSITRF DEPOSITDTLRF" + Environment.NewLine;
                selectTxt += " FROM DEPSITMAINRF DEPSIT " + Environment.NewLine;
                selectTxt += " LEFT JOIN DEPSITDTLRF DEPSITD ON DEPSITD.ENTERPRISECODERF=DEPSIT.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND DEPSITD.DEPOSITSLIPNORF=DEPSIT.DEPOSITSLIPNORF" + Environment.NewLine;
                selectTxt += " LEFT JOIN SECINFOSETRF SEC ON SEC1.ENTERPRISECODERF=DEPSIT.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SEC.SECTIONCODERF=DEPSIT.AddUpSecCodeRF" + Environment.NewLine;
                selectTxt += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=DEPSIT.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUST.CUSTOMERCODERF=DEPSIT.CUSTOMERCODERF" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, depsitMainListParamWork, OutPutDiv, logicalMode);

                sqlCommand.CommandText += " GROUP BY ";
                if (depsitMainListParamWork.PrintDiv == 3)
                {
                    sqlCommand.CommandText += "DEPSIT.ADDUPADATERF, ";
                }
                if (sectionDepositDiv == 1)
                    sqlCommand.CommandText += "DEPSIT.ADDUPSECCODERF, SEC.SECTIONGUIDENMRF, DEPSITD.MONEYKINDCODERF, DEPSITD.MONEYKINDNAMERF, DEPSITD.MONEYKINDDIVRF, DPM.AUTODEPOSITCDRF ";
                else
                    sqlCommand.CommandText += "DEPSITD.MONEYKINDCODERF, DEPSITD.MONEYKINDNAMERF, DEPSITD.MONEYKINDDIVRF, DPM.AUTODEPOSITCDRF ";

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    DepsitMainListResultWork wkDepsitMainListResultWork = new DepsitMainListResultWork();

                    //入金マスタ結果取得内容格納
                    if (sectionDepositDiv == 1)
                    {
                        wkDepsitMainListResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        wkDepsitMainListResultWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    }
                    if (depsitMainListParamWork.PrintDiv == 3)
                    {
                        wkDepsitMainListResultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    }
                    wkDepsitMainListResultWork.DepositTotal          = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_DEPOSITTOTALRF"));
                    wkDepsitMainListResultWork.Deposit               = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_DEPOSITRF"));
                    wkDepsitMainListResultWork.FeeDeposit            = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_FEEDEPOSITRF"));
                    wkDepsitMainListResultWork.DiscountDeposit       = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_DISCOUNTDEPOSITRF"));
                    wkDepsitMainListResultWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                    wkDepsitMainListResultWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDCODERF"));
                    wkDepsitMainListResultWork.MoneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                    wkDepsitMainListResultWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONEYKINDDIVRF"));
                    wkDepsitMainListResultWork.DepositDtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITDTLRF"));
                    #endregion

                    al.Add(wkDepsitMainListResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DepsitListWorkDB.SearchDepsitMainAction Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="depsitMainListParamWork">検索条件格納クラス</param>
        /// <param name="outPutDiv">出力区分 0:入金のみ、1:入金＆引当、2:総合計</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, DepsitMainListParamWork depsitMainListParamWork, int outPutDiv, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = " WHERE ";

            //企業コード
            retstring += " DEPSIT.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND DEPSIT.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND DEPSIT.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //拠点コード    ※配列で複数指定される
            if (depsitMainListParamWork.DepositAddupSecCodeList != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in depsitMainListParamWork.DepositAddupSecCodeList)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND DEPSIT.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                    //##retstring += " AND DPM.INPUTDEPOSITSECCDRF IN (" + sectionCodestr + ") ";
                }
            }

            //入金計上日条件設定
            if (depsitMainListParamWork.St_AddUpADate != 0)
            {
                retstring += " AND DEPSIT.ADDUPADATERF >= " + depsitMainListParamWork.St_AddUpADate.ToString();
            }
            if (depsitMainListParamWork.Ed_AddUpADate != 0)
            {
                if (depsitMainListParamWork.St_AddUpADate == 0)
                {
                    retstring += " AND (DEPSIT.ADDUPADATERF IS NULL OR";
                }
                else
                {
                    retstring += " AND";
                }
                retstring += " DEPSIT.ADDUPADATERF <= " + depsitMainListParamWork.Ed_AddUpADate.ToString();
                if (depsitMainListParamWork.St_AddUpADate == 0)
                {
                    retstring += " ) ";
                }
            }

            //入金入力日条件設定
            if (depsitMainListParamWork.St_CreateDate != 0)
            {
                //retstring += " AND DEPSIT.DEPOSITDATERF >= " + depsitMainListParamWork.St_CreateDate.ToString();
                retstring += " AND DEPSIT.INPUTDAYRF >= " + depsitMainListParamWork.St_CreateDate.ToString();  //ADD 2009/03/26
            }
            if (depsitMainListParamWork.Ed_CreateDate != 0)
            {
                if (depsitMainListParamWork.St_CreateDate == 0)
                {
                    //retstring += " AND (DEPSIT.DEPOSITDATERF IS NULL OR";
                    retstring += " AND (DEPSIT.INPUTDAYRF IS NULL OR";  //ADD 2009/03/26
                }
                else
                {
                    retstring += " AND";
                }
                //retstring += " DEPSIT.DEPOSITDATERF <= " + depsitMainListParamWork.Ed_CreateDate.ToString();
                retstring += " DEPSIT.INPUTDAYRF <= " + depsitMainListParamWork.Ed_CreateDate.ToString();  //ADD 2009/03/26
                if (depsitMainListParamWork.St_CreateDate == 0)
                {
                    retstring += " ) ";
                }
            }

            //得意先コード設定
            if (depsitMainListParamWork.St_CustomerCode != 0)
            {
                retstring += " AND DEPSIT.CUSTOMERCODERF>=@STCUSTOMERCODE ";
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(depsitMainListParamWork.St_CustomerCode);
            }
            if (depsitMainListParamWork.Ed_CustomerCode != 0)
            {
                retstring += " AND DEPSIT.CUSTOMERCODERF<=@EDCUSTOMERCODE ";
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(depsitMainListParamWork.Ed_CustomerCode);
            }

            //カナ設定
            if (depsitMainListParamWork.St_CustomerKana != "")
            {
                retstring += " AND CUST.KANARF>=@STKANA ";
                SqlParameter paraStCustomerKana = sqlCommand.Parameters.Add("@STKANA", SqlDbType.NVarChar);
                paraStCustomerKana.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_CustomerKana);
            }
            if (depsitMainListParamWork.Ed_CustomerKana != "")
            {
                retstring += " AND (CUST.KANARF<=@EDKANA OR CUST.KANARF LIKE @EDKANA) ";
                SqlParameter paraEdCustomerKana = sqlCommand.Parameters.Add("@EDKANA", SqlDbType.NVarChar);
                paraEdCustomerKana.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_CustomerKana + "%");
            }

            //担当者区分
            switch(depsitMainListParamWork.EmployeeKind)
            {
                case 0:
                    {
                        //得意先担当者設定
                        if (depsitMainListParamWork.St_EmployeeCd != "")
                        {
                            retstring += " AND CUST.CUSTOMERAGENTCDRF>=@STCUSTOMERAGENTCD ";
                            SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STCUSTOMERAGENTCD", SqlDbType.NChar);
                            paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_EmployeeCd);
                        }
                        if (depsitMainListParamWork.Ed_EmployeeCd != "")
                        {
                            if (depsitMainListParamWork.St_EmployeeCd == "")
                            {
                                retstring += " AND (CUST.CUSTOMERAGENTCDRF IS NULL OR";
                            }
                            else
                            {
                                retstring += " AND (";
                            }

                            retstring += " CUST.CUSTOMERAGENTCDRF<=@EDCUSTOMERAGENTCD OR CUST.CUSTOMERAGENTCDRF LIKE @EDCUSTOMERAGENTCD) ";
                            SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDCUSTOMERAGENTCD", SqlDbType.NChar);
                            paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_EmployeeCd + "%");
                        }
                        break;
                    }
                case 1:
                    {
                        //集金担当者設定
                        if (depsitMainListParamWork.St_EmployeeCd != "")
                        {
                            retstring += " AND CUST.BILLCOLLECTERCDRF>=@STDEPOSITAGENTCODE ";
                            SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STDEPOSITAGENTCODE", SqlDbType.NChar);
                            paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_EmployeeCd);
                        }
                        if (depsitMainListParamWork.Ed_EmployeeCd != "")
                        {
                            if (depsitMainListParamWork.St_EmployeeCd == "")
                            {
                                retstring += " AND (CUST.BILLCOLLECTERCDRF IS NULL OR";
                            }
                            else
                            {
                                retstring += " AND (";
                            }

                            retstring += " CUST.BILLCOLLECTERCDRF<=@EDDEPOSITAGENTCODE OR CUST.BILLCOLLECTERCDRF LIKE @EDDEPOSITAGENTCODE) ";
                            SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDDEPOSITAGENTCODE", SqlDbType.NChar);
                            paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_EmployeeCd + "%");
                        }
                        break;
                    }
                case 2:
                    {
                        //入金担当者設定
                        if (depsitMainListParamWork.St_EmployeeCd != "")
                        {
                            retstring += " AND DEPSIT.DEPOSITAGENTCODERF>=@STDEPOSITAGENTCODE ";
                            SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STDEPOSITAGENTCODE", SqlDbType.NChar);
                            paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_EmployeeCd);
                        }
                        if (depsitMainListParamWork.Ed_EmployeeCd != "")
                        {
                            if (depsitMainListParamWork.St_EmployeeCd == "")
                            {
                                retstring += " AND (DEPSIT.DEPOSITAGENTCODERF IS NULL OR";
                            }
                            else
                            {
                                retstring += " AND (";
                            }

                            retstring += " DEPSIT.DEPOSITAGENTCODERF<=@EDDEPOSITAGENTCODE OR DEPSIT.DEPOSITAGENTCODERF LIKE @EDDEPOSITAGENTCODE) ";
                            SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDDEPOSITAGENTCODE", SqlDbType.NChar);
                            paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_EmployeeCd + "%");
                        }
                        break;
                    }
                case 3:
                    {
                        //入金入力者設定
                        if (depsitMainListParamWork.St_EmployeeCd != "")
                        {
                            retstring += " AND DEPSIT.DEPOSITINPUTAGENTCDRF>=@STDEPOSITINPUTAGENTCD ";
                            SqlParameter paraStEmployeeCode = sqlCommand.Parameters.Add("@STDEPOSITINPUTAGENTCD", SqlDbType.NChar);
                            paraStEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.St_EmployeeCd);
                        }
                        if (depsitMainListParamWork.Ed_EmployeeCd != "")
                        {
                            if (depsitMainListParamWork.St_EmployeeCd == "")
                            {
                                retstring += " AND (DEPSIT.DEPOSITINPUTAGENTCDRF IS NULL OR";
                            }
                            else
                            {
                                retstring += " AND (";
                            }

                            retstring += " DEPSIT.DEPOSITINPUTAGENTCDRF<=@EDDEPOSITINPUTAGENTCD OR DEPSIT.DEPOSITINPUTAGENTCDRF LIKE @EDDEPOSITINPUTAGENTCD) ";
                            SqlParameter paraEdEmployeeCode = sqlCommand.Parameters.Add("@EDDEPOSITINPUTAGENTCD", SqlDbType.NChar);
                            paraEdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainListParamWork.Ed_EmployeeCd + "%");
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            //入金伝票番号設定
            if (depsitMainListParamWork.St_DepositSlipNo != 0)
            {
                retstring += " AND DEPSIT.DEPOSITSLIPNORF>=@STDEPOSITSLIPNO ";
                SqlParameter paraStDepositSlipNo = sqlCommand.Parameters.Add("@STDEPOSITSLIPNO", SqlDbType.Int);
                paraStDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainListParamWork.St_DepositSlipNo);
            }
            if (depsitMainListParamWork.Ed_DepositSlipNo != 0)
            {
                retstring += " AND DEPSIT.DEPOSITSLIPNORF<=@EDDEPOSITSLIPNO ";
                SqlParameter paraEdDepositSlipNo = sqlCommand.Parameters.Add("@EDDEPOSITSLIPNO", SqlDbType.Int);
                paraEdDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainListParamWork.Ed_DepositSlipNo);
            }

            //入金金種設定
            if (depsitMainListParamWork.DepositCdKind != null)
            {
                if (depsitMainListParamWork.DepositCdKind.Count > 0)
                {
                    if (Convert.ToInt32(depsitMainListParamWork.DepositCdKind[0]) > -1)
                    {
                        ArrayList DepositKindArray = new ArrayList(depsitMainListParamWork.DepositCdKind);
                        if ((DepositKindArray != null) && (DepositKindArray.Count > 0))
                        {
                            string depositKindint = "";
                            int kindint;
                            for (int i = 0; i < DepositKindArray.Count; i++)
                            {
                                kindint = Convert.ToInt32(DepositKindArray[i]);
                                if (kindint != -1)
                                {
                                    if (depositKindint != "")
                                    {
                                        depositKindint += ",";
                                    }
                                    depositKindint += "'" + kindint + "'";
                                }
                            }

                            if (depositKindint != "")
                            {
                                retstring += " AND DEPSITD.MONEYKINDCODERF IN (" + depositKindint + ") ";
                            }
                        }
                    }
                }
            }

            ////預り金区分
            //if (depsitMainListParamWork.DepositCd != -1)
            //{
            //    switch (depsitMainListParamWork.DepositCd)
            //    {
            //        case 0:     // 全て
            //            break;
            //        case 1:     // 通常
            //            retstring += " AND DEPSIT.DEPOSITCDRF=0 AND DEPSIT.AUTODEPOSITCDRF=0 ";
            //            break;
            //        case 2:     // 預り金
            //            retstring += " AND DEPSIT.DEPOSITCDRF=1 ";
            //            break;
            //        case 3:     // 自動
            //            retstring += " AND DEPSIT.AUTODEPOSITCDRF=1 ";
            //            break;
            //        default:
            //            break;
            //    }
            //}

            // 2008.07.01 del start --------------------------------->>
            //引当区分
            //if (depsitMainListParamWork.AllowanceDiv != -1)
            //{
            //    switch (depsitMainListParamWork.AllowanceDiv)
            //    {
            //        case 0:     // 引当済み (入金引当残高=0 AND 入金引当額<>0)
            //            retstring += " AND DEPSIT.DEPOSITALWCBLNCERF=0 AND DEPSIT.DEPOSITALLOWANCERF<>0 ";
            //            break;
            //        case 1:     // 一部引当 (入金引当残高>0 AND 入金引当額>0)
            //            retstring += " AND DEPSIT.DEPOSITALWCBLNCERF<>0 AND DEPSIT.DEPOSITALLOWANCERF<>0 ";
            //            break;
            //        case 2:     // 未引当   (入金引当残高>0 AND 入金引当額=0)
            //            retstring += " AND DEPSIT.DEPOSITALWCBLNCERF<>0 AND DEPSIT.DEPOSITALLOWANCERF=0 ";
            //            break;
            //        default:
            //            break;
            //    }
            //}
            
            //入金のみの場合にソート順作成
            //if (outPutDiv == 0)
            //{
            //    //ソート順
            //    retstring += " ORDER BY";

                // 2008.02.01 update　全社指定の場合の仕様変更 [ 常に拠点コードをソートキーに追加する ]
                ////拠点コードが選択されているか
                //if (depsitMainListParamWork.DepositAddupSecCodeList != null)
                //{
                //    //retstring += " DPM.ADDUPSECCODERF, ";
                //    retstring += " DPM.INPUTDEPOSITSECCDRF, ";
                //}
                //
            //    retstring += " DEPSIT.ADDUPSECCODERF, ";
                //##retstring += " DPM.INPUTDEPOSITSECCDRF, ";
            //    switch (depsitMainListParamWork.SortOrder)
            //    {
            //        case 0:
            //            {
            //                retstring += " DEPSIT.ADDUPADATERF, DEPSIT.CUSTOMERCODERF, DEPSIT.DEPOSITSLIPNORF, DEPSIT.DEBITNOTELINKDEPONORF ";
            //                break;
            //            }
            //        case 1:
            //            {
            //                retstring += " DEPSIT.ADDUPADATERF, CUST.KANARF, DEPSIT.CUSTOMERCODERF, DEPSIT.DEPOSITSLIPNORF, DEPSIT.DEBITNOTELINKDEPONORF ";
            //                break;
            //            }
            //        case 2:
            //            {
            //                retstring += " DEPSIT.ADDUPADATERF, ";
            //                switch(depsitMainListParamWork.EmployeeKind)
            //                {
            //                    case 0:
            //                        {
            //                            retstring += " CUST.CUSTOMERAGENTCDRF, ";
            //                            break;
            //                        }
            //                    case 1:
            //                        {
            //                            retstring += " CUST.BILLCOLLECTERCDRF, ";
            //                            break;
            //                        }
            //                    case 2:
            //                        {
            //                            retstring += " DEPSIT.DEPOSITAGENTCODERF, ";
            //                            break;
            //                        }
            //                    case 3:
            //                        {
            //                            retstring += " DEPSIT.DEPOSITINPUTAGENTCDRF, ";
            //                            break;
            //                        }
            //                    default:
            //                        {
            //                            retstring += " CUST.CUSTOMERAGENTCDRF, ";
            //                            break;
            //                        }
            //                }
            //                retstring += " DEPSIT.CUSTOMERCODERF, ";
            //                retstring += " DEPSIT.DEPOSITSLIPNORF, ";
            //                retstring += " DEPSIT.DEBITNOTELINKDEPONORF ";
            //                break;
            //            }
            //        case 3:
            //            {
            //                retstring += " DEPSIT.DEPOSITDATERF ";
            //                break;
            //            }
            //        case 4:
            //            {
            //                retstring += " DEPSIT.ADDUPADATERF ";
            //                break;
            //            }
            //        case 5:
            //            {
            //                retstring += " DEPSIT.DEPOSITSLIPNORF ";
            //                break;
            //            }
            //        default:
            //            {
            //                break;
            //            }
            //    }
            //}
            // 2008.07.01 del end -----------------------------------<<

            #endregion
            return retstring;
        }
    }
}
