using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 得意先設定(伝票設定)マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先設定(伝票設定)マスタのアクセス制御を行います。</br>
    /// <br>Programmer : 30416 長沼 賢二</br>
    /// <br>Date       : 2008.06.26</br>
    /// <br>Update Note: 2008.09.22 30452 上野 俊治</br>
    /// <br>             PM.NS対応</br>
    /// <br>             ・得意先伝票番号ヘッダ、得意先伝票番号フッタを削除</br>
    /// <br>Update Note: 2008.12.10 30365 宮津 銀次郎</br>
    /// <br>             得意先マスタの得意先伝票番号区分が0の得意先が</br>
    /// <br>             左側グリッドに表示されないように修正。</br>
    /// <br>             DBの得意先を読みに行く回数を多少減らし、少々の高速化。</br>
    /// <br>             速度については要改善。</br>
    /// <br>Update Note: 2009.02.12 30452 上野 俊治</br>
    /// <br>             速度アップ対応</br>
    /// <br>Update Note: 2009.02.13 30452 上野 俊治</br>
    /// <br>             速度アップ対応</br>
    /// </remarks>
    public class CustSlipNoSetAcs
    {
        //----------------------------------------
        // 得意先設定(伝票設定)マスタ定数定義
        //----------------------------------------
        public const string CREATEDATETIME = "CreateDateTime";
        public const string UPDATEDATETIME = "UpdateDateTime";
        public const string ENTERPRISECODE = "EnterpriseCode";
        public const string FILEHEADERGUID = "FileHeaderGuid";
        public const string UPDEMPLOYEECODE = "UpdEmployeeCode";
        public const string UPDASSEMBLYID1 = "UpdAssemblyId1";
        public const string UPDASSEMBLYID2 = "UpdAssemblyId2";
        public const string LOGICALDELETECODE = "LogicalDeleteCode";

        public const string CUSTOMERCODE_TITLE = "得意先コード";
        public const string CUSTOMERNAME_TITLE = "得意先略称";
        public const string ADDUPYEARMONTH_TITLE = "計上年月";
        public const string PRESENTCUSTSLIPNO_TITLE = "現在得意先伝票番号";
        public const string STARTCUSTSLIPNO_TITLE = "開始得意先伝票番号";
        public const string ENDCUSTSLIPNO_TITLE = "終了得意先伝票番号";
        //public const string CUSTSLIPNOHEADER_TITLE = "得意先伝票番号ヘッダ"; //DEL 2008/09/22
        //public const string CUSTSLIPNOFOOTER_TITLE = "得意先伝票番号フッタ"; //DEL 2008/09/22
        public const string DELETE_DATE_TITLE = "削除日";

        // テーブル名
        public const string MAIN_TABLE = "MainTable";
        public const string SECOND_TABLE = "SecondTable";

        // private member定義
        // リモートオブジェクト格納バッファ
        private ICustSlipNoSetDB _iCustSlipNoSetDB = null;    // 設定リモート

        private DataSet _dataTableList = null;

        private string _enterpriseCode = "";

        // 文字列結合用
        private StringBuilder _stringBuilder = null;

        private CustomerInfoAcs _customerInfoAcs; // ADD 2009/02/12

        #region Construcstor
        /// <summary>
        /// 得意先設定(伝票設定)マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先設定(伝票設定)マスタアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public CustSlipNoSetAcs()
        {
            try
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                // リモートオブジェクト取得
                this._iCustSlipNoSetDB = (ICustSlipNoSetDB)MediationCustSlipNoSetDB.GetCustSlipNoSetDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iCustSlipNoSetDB = null;
            }

            // データセット列情報構築処理
            this._dataTableList = new DataSet();
            DataSetColumnConstruction(ref this._dataTableList);

            // 文字列結合用
            this._stringBuilder = new StringBuilder();

            this._customerInfoAcs = new CustomerInfoAcs(); // ADD 2009/02/12
        }
        #endregion

        // 列挙型
        /// <summary>オンラインモードの列挙型です。</summary>
        public enum OnlineMode
        {
            /// <summary>オフライン</summary>
            Offline,
            /// <summary>オンライン</summary>
            Online
        }

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iCustSlipNoSetDB == null)
            {
                return (int)OnlineMode.Offline;
            }
            else
            {
                return (int)OnlineMode.Online;
            }
        }

        #region Property
        /// <summary>第１テーブル（得意先コードテーブル）</summary>
        public DataTable DtMainTable
        {
            get { return this._dataTableList.Tables[MAIN_TABLE]; }
        }
        /// <summary>第２テーブル（計上年月テーブル）</summary>
        public DataTable DtDetailsTable
        {
            get { return this._dataTableList.Tables[SECOND_TABLE]; }
        }
        #endregion

        #region public member

        #region GetTable テーブル取得
        /// <summary>
        /// テーブル取得
        /// </summary>
        /// <param name="tableName">テーブル名</param>		
        /// <returns>DataTable</returns>
        /// <remarks>
        /// <br>Note       : 指定されたテーブルのオブジェクトを返します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public DataTable GetTable(string tableName)
        {
            if (this._dataTableList.Tables.Contains(tableName))
            {
                return this._dataTableList.Tables[tableName];
            }
            return null;
        }
        #endregion

        #region GetSlipOutputSet 得意先設定(伝票設定)データ取得
        /// <summary>
        /// 得意先設定(伝票設定)データ取得
        /// </summary>
        /// <param name="customerCode">得意先コード</param>		
        /// <param name="addYearMonth">計上年月</param>		
        /// <param name="custSlipNoSet">得意先設定(伝票設定)クラス</param>
        /// <param name="message">エラーメッセージ</param>		
        /// <returns>ファンクションのステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定されたKEYを持つ得意先設定(伝票設定)クラスを返します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int GetSlipOutputSet(int customerCode,
                                    int addYearMonth,
                                    out CustSlipNoSet custSlipNoSet,
                                    out string message)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            custSlipNoSet = new CustSlipNoSet();
            message = "";

            try
            {
                DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {  customerCode,
																								addYearMonth });
                if (dr == null)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                }

                // 作成日時
                custSlipNoSet.CreateDateTime = (DateTime)dr[CREATEDATETIME];
                // 更新日時
                custSlipNoSet.UpdateDateTime = (DateTime)dr[UPDATEDATETIME];
                // 企業コード
                custSlipNoSet.EnterpriseCode = dr[ENTERPRISECODE].ToString();
                // GUID
                custSlipNoSet.FileHeaderGuid = (Guid)dr[FILEHEADERGUID];
                // 更新従業員コード
                custSlipNoSet.UpdEmployeeCode = dr[UPDEMPLOYEECODE].ToString();
                // 更新アセンブリID1
                custSlipNoSet.UpdAssemblyId1 = dr[UPDASSEMBLYID1].ToString();
                // 更新アセンブリID2
                custSlipNoSet.UpdAssemblyId2 = dr[UPDASSEMBLYID2].ToString();
                // 論理削除区分
                custSlipNoSet.LogicalDeleteCode = Convert.ToInt32(dr[LOGICALDELETECODE]);

                // 得意先コード
                custSlipNoSet.CustomerCode = (Int32)dr[CUSTOMERCODE_TITLE];
                // 計上年月
                custSlipNoSet.AddUpYearMonth = (Int32)dr[ADDUPYEARMONTH_TITLE];
                // 現在得意先伝票番号
                custSlipNoSet.PresentCustSlipNo = (Int64)dr[PRESENTCUSTSLIPNO_TITLE];
                // 開始得意先伝票番号
                custSlipNoSet.StartCustSlipNo = (Int64)dr[STARTCUSTSLIPNO_TITLE];
                // 終了得意先伝票番号
                custSlipNoSet.EndCustSlipNo = (Int64)dr[ENDCUSTSLIPNO_TITLE];
                // --- DEL 2008/09/22 -------------------------------->>>>>
                //// 得意先伝票番号ヘッダ
                //custSlipNoSet.CustSlipNoHeader = dr[CUSTSLIPNOHEADER_TITLE].ToString();
                //// 得意先伝票番号フッタ
                //custSlipNoSet.CustSlipNoFooter = dr[CUSTSLIPNOFOOTER_TITLE].ToString();
                // --- DEL 2008/09/22 --------------------------------<<<<<

                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                custSlipNoSet = null;
            }

            return status;
        }
        #endregion

        #region Search 検索処理
        /// <summary>
        /// 検索処理（論理削除含まない）
        /// </summary>
        /// <param name="retArrayList">読込結果コレクション(ArrayList)</param>
        /// <param name="retTotalCnt">読込対象データ総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="message">メッセージ</param>		
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先設定(伝票設定)の全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Search(out ArrayList retArrayList, out int retTotalCnt, out bool nextData, string enterpriseCode, out string message)
        {
            DataSet dmyDataSet = null;	// データセットは使用しない

            // 検索
            int status = SearchProc(out retArrayList, out dmyDataSet, out retTotalCnt, out nextData, enterpriseCode, 0, out message);

            return status;
        }

        /// <summary>
        /// 検索処理（論理削除含まない）
        /// </summary>
        /// <param name="retList">読込結果コレクション(DataSet)</param>
        /// <param name="retTotalCnt">読込対象データ総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="message">メッセージ</param>		
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先設定(伝票設定)の全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Search(out DataSet retList, out int retTotalCnt, out bool nextData, string enterpriseCode, out string message)
        {
            ArrayList dmyArrayList = null;	// ArrayListは使用しない

            // 検索
            int status = SearchProc(out dmyArrayList, out retList, out retTotalCnt, out nextData, enterpriseCode, 0, out message);

            return status;
        }
        #endregion

        #region SearchAll 検索処理
        /// <summary>
        /// 検索処理（論理削除含む）
        /// </summary>
        /// <param name="retArrayList">読込結果コレクション(ArrayList)</param>
        /// <param name="retTotalCnt">読込対象データ総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="message">メッセージ</param>		
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先設定(伝票設定)の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int SearchAll(out ArrayList retArrayList, out int retTotalCnt, out bool nextData, string enterpriseCode, out string message)
        {
            DataSet dmyDataSet = null;	// データセットは使用しない

            // 検索
            int status = SearchProc(out retArrayList, out dmyDataSet, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, out message);

            return status;
        }

        /// <summary>
        /// 検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション(DataSet)</param>
        /// <param name="retTotalCnt">読込対象データ総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="message">メッセージ</param>		
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先設定(伝票設定)の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int SearchAll(out DataSet retList, out int retTotalCnt, out bool nextData, string enterpriseCode, string sectionCode, out string message)
        {
            ArrayList dmyArrayList = null;	// ArrayListは使用しない

            // 検索
            int status = SearchProc(out dmyArrayList, out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, out message);

            return status;
        }
        #endregion

        #region Write 書き込み処理
        /// <summary>
        /// 書き込み処理
        /// </summary>
        /// <param name="custSlipNoSet">保存データ</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 書き込み処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Write(ref CustSlipNoSet custSlipNoSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // クラスデータをワーククラスデータに変換
                CustSlipNoSetWork custSlipNoSetWork = CopyToSlipOutputSetWorkFromSlipOutputSet(custSlipNoSet);

                ArrayList paraSlipOutputSetWorkList = new ArrayList();
                paraSlipOutputSetWorkList.Add(custSlipNoSetWork);
                object paraObj = paraSlipOutputSetWorkList;

                // 書き込み処理
                status = this._iCustSlipNoSetDB.Write(ref paraObj);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 何かしらのエラー発生
                    message = "登録に失敗しました。";
                    return status;
                }

                // ワークデータをクラスデータに変換
                custSlipNoSetWork = (CustSlipNoSetWork)((ArrayList)paraObj)[0];
                custSlipNoSet = CopyToSlipOutputSetFromSlipOutputSetWork(custSlipNoSetWork);

                // データ登録済みチェック
                DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] { custSlipNoSetWork.CustomerCode,
																						       custSlipNoSetWork.AddUpYearMonth });
                if (dr == null)
                {
                    // 未登録の場合はワークデータをDataRowに変換
                    dr = CopyToDataRowFromSlipOutputSetWork(ref custSlipNoSetWork);

                    // 未登録の場合はレコードを追加
                    this._dataTableList.Tables[SECOND_TABLE].Rows.Add(dr);
                }
                else
                {
                    // 登録済みの場合は更新
                    dr[UPDATEDATETIME] = custSlipNoSetWork.UpdateDateTime;
                    dr[UPDEMPLOYEECODE] = custSlipNoSetWork.UpdEmployeeCode;
                    dr[UPDASSEMBLYID1] = custSlipNoSetWork.UpdAssemblyId1;
                    dr[UPDASSEMBLYID2] = custSlipNoSetWork.UpdAssemblyId2;

                    // 得意先コード
                    dr[CUSTOMERCODE_TITLE] = custSlipNoSetWork.CustomerCode;
                    // 計上年月
                    dr[ADDUPYEARMONTH_TITLE] = custSlipNoSetWork.AddUpYearMonth;

                    // 現在得意先伝票番号
                    dr[PRESENTCUSTSLIPNO_TITLE] = custSlipNoSetWork.PresentCustSlipNo;
                    // 開始得意先伝票番号
                    dr[STARTCUSTSLIPNO_TITLE] = custSlipNoSetWork.StartCustSlipNo;
                    // 終了得意先伝票番号
                    dr[ENDCUSTSLIPNO_TITLE] = custSlipNoSetWork.EndCustSlipNo;

                    // --- DEL 2008/09/22 -------------------------------->>>>>
                    //// 得意先伝票番号ヘッダ
                    //dr[CUSTSLIPNOHEADER_TITLE] = custSlipNoSetWork.CustSlipNoHeader;
                    //// 得意先伝票番号フッタ
                    //dr[CUSTSLIPNOFOOTER_TITLE] = custSlipNoSetWork.CustSlipNoFooter;
                    // --- DEL 2008/09/22 --------------------------------<<<<<
                }

                this._dataTableList.AcceptChanges();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._iCustSlipNoSetDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region LogicalDelete 論理削除処理
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="custSlipNoSet">得意先設定(伝票設定)クラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 論理削除処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int LogicalDelete(ref CustSlipNoSet custSlipNoSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // クラスデータをワーククラスデータに変換
                CustSlipNoSetWork custSlipNoSetWork = CopyToSlipOutputSetWorkFromSlipOutputSet(custSlipNoSet);

                ArrayList slipOutputSetWorkList = new ArrayList();
                slipOutputSetWorkList.Add(custSlipNoSetWork);
                object paraObj = slipOutputSetWorkList;

                // 削除処理
                status = this._iCustSlipNoSetDB.LogicalDelete(ref paraObj);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 何かしらのエラー発生
                    message = "削除に失敗しました。";
                    return status;
                }

                // クラスデータに反映
                custSlipNoSetWork = (CustSlipNoSetWork)((ArrayList)paraObj)[0];
                custSlipNoSet = CopyToSlipOutputSetFromSlipOutputSetWork(custSlipNoSetWork);

                // データテーブルに反映
                DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	custSlipNoSet.CustomerCode,
																								custSlipNoSet.AddUpYearMonth });
                if (dr != null)
                {
                    dr = CopyToDataRowFromSlipOutputSetWork(ref custSlipNoSetWork);
                }
                this._dataTableList.AcceptChanges();


                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._iCustSlipNoSetDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region Revival 復旧処理
        /// <summary>
        /// 復旧処理
        /// </summary>
        /// <param name="custSlipNoSet">得意先設定(伝票設定)クラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <remarks>
        /// <returns>ステータス</returns>
        /// <br>Note       : 復旧処理（論理削除復旧）を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Revival(ref CustSlipNoSet custSlipNoSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // クラスデータをワーククラスデータに変換
                CustSlipNoSetWork custSlipNoSetWork = CopyToSlipOutputSetWorkFromSlipOutputSet(custSlipNoSet);

                ArrayList paraSlipOutputSetWorkList = new ArrayList();
                paraSlipOutputSetWorkList.Add(custSlipNoSetWork);
                object paraObj = paraSlipOutputSetWorkList;

                // 書き込み処理
                status = this._iCustSlipNoSetDB.RevivalLogicalDelete(ref paraObj);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 何かしらのエラー発生
                    message = "削除に失敗しました。";
                    return status;
                }

                // クラスデータに反映
                custSlipNoSetWork = (CustSlipNoSetWork)((ArrayList)paraObj)[0];
                custSlipNoSet = CopyToSlipOutputSetFromSlipOutputSetWork(custSlipNoSetWork);

                // データテーブルに反映
                DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	custSlipNoSet.CustomerCode,
																								custSlipNoSet.AddUpYearMonth });
                if (dr != null)
                {
                    dr = CopyToDataRowFromSlipOutputSetWork(ref custSlipNoSetWork);
                }
                this._dataTableList.AcceptChanges();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._iCustSlipNoSetDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region Delete 削除処理
        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="custSlipNoSet">得意先設定(伝票設定)クラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 削除処理（物理削除）を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Delete(ref CustSlipNoSet custSlipNoSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // クラスデータをワーククラスデータに変換
                CustSlipNoSetWork custSlipNoSetWork = CopyToSlipOutputSetWorkFromSlipOutputSet(custSlipNoSet);

                ArrayList custSlipNoSetArray = new ArrayList();
                custSlipNoSetArray.Add(custSlipNoSetWork);
                object retobj = (object)custSlipNoSetArray;

                // 書き込み処理
                status = this._iCustSlipNoSetDB.Delete(retobj);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 何かしらのエラー発生
                    message = "削除に失敗しました。";
                    return status;
                }

                // データ登録済みチェック
                DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	custSlipNoSet.CustomerCode,
																								custSlipNoSet.AddUpYearMonth });
                if (dr != null)
                {
                    // 物理削除したデータを削除
                    this._dataTableList.Tables[SECOND_TABLE].Rows.Remove(dr);
                }
                this._dataTableList.AcceptChanges();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._iCustSlipNoSetDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #endregion

        #region private member

        #region データセット列情報構築処理
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
            //----------------------------------------------------------------
            // 得意先コードテーブル列定義
            //----------------------------------------------------------------
            DataTable cashRegisterNoTable = new DataTable(MAIN_TABLE);

            // 得意先コード
            cashRegisterNoTable.Columns.Add(CUSTOMERCODE_TITLE, typeof(string));
            // 得意先名称
            cashRegisterNoTable.Columns.Add(CUSTOMERNAME_TITLE, typeof(string));

            cashRegisterNoTable.PrimaryKey = new DataColumn[] { cashRegisterNoTable.Columns[CUSTOMERCODE_TITLE] };
            this._dataTableList.Tables.Add(cashRegisterNoTable);

            //----------------------------------------------------------------
            // 計上年月テーブル列定義
            //----------------------------------------------------------------
            DataTable slipPrtTable = new DataTable(SECOND_TABLE);

            // 作成日時
            slipPrtTable.Columns.Add(CREATEDATETIME, typeof(DateTime));
            // 更新日時
            slipPrtTable.Columns.Add(UPDATEDATETIME, typeof(DateTime));
            // 企業コード
            slipPrtTable.Columns.Add(ENTERPRISECODE, typeof(string));
            // GUID
            slipPrtTable.Columns.Add(FILEHEADERGUID, typeof(Guid));
            // 更新従業員コード
            slipPrtTable.Columns.Add(UPDEMPLOYEECODE, typeof(string));
            // 更新アセンブリID1
            slipPrtTable.Columns.Add(UPDASSEMBLYID1, typeof(string));
            // 更新アセンブリID2
            slipPrtTable.Columns.Add(UPDASSEMBLYID2, typeof(string));
            // 論理削除区分
            slipPrtTable.Columns.Add(LOGICALDELETECODE, typeof(Int32));

            // 得意先コード
            slipPrtTable.Columns.Add(CUSTOMERCODE_TITLE, typeof(Int32));
            // 計上年月
            slipPrtTable.Columns.Add(ADDUPYEARMONTH_TITLE, typeof(Int32));

            // 現在得意先伝票番号
            slipPrtTable.Columns.Add(PRESENTCUSTSLIPNO_TITLE, typeof(Int64));
            // 開始得意先伝票番号
            slipPrtTable.Columns.Add(STARTCUSTSLIPNO_TITLE, typeof(Int64));
            // 終了得意先伝票番号
            slipPrtTable.Columns.Add(ENDCUSTSLIPNO_TITLE, typeof(Int64));

            // --- DEL 2008/09/22 -------------------------------->>>>>
            //// 得意先伝票番号ヘッダ
            //slipPrtTable.Columns.Add(CUSTSLIPNOHEADER_TITLE, typeof(string));
            //// 得意先伝票番号フッタ
            //slipPrtTable.Columns.Add(CUSTSLIPNOFOOTER_TITLE, typeof(string));
            // --- DEL 2008/09/22 --------------------------------<<<<<
            

            // 削除日
            slipPrtTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));

            slipPrtTable.PrimaryKey = new DataColumn[] { slipPrtTable.Columns[CUSTOMERCODE_TITLE],
											 			 slipPrtTable.Columns[ADDUPYEARMONTH_TITLE] };

            this._dataTableList.Tables.Add(slipPrtTable);

        }
        #endregion

        #region クラスメンバコピー処理
        /// <summary>
        /// クラスメンバーコピー処理（得意先設定(伝票設定)クラス⇒得意先設定(伝票設定)ワーククラス）
        /// </summary>
        /// <param name="custSlipNoSet">得意先設定(伝票設定)クラス</param>
        /// <returns>CustSlipNoSetWork</returns>
        /// <remarks>
        /// <br>Note       : 得意先設定(伝票設定)クラスから得意先設定(伝票設定)ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private CustSlipNoSetWork CopyToSlipOutputSetWorkFromSlipOutputSet(CustSlipNoSet custSlipNoSet)
        {
            CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();

            // 作成日時
            custSlipNoSetWork.CreateDateTime = custSlipNoSet.CreateDateTime;
            // 更新日時
            custSlipNoSetWork.UpdateDateTime = custSlipNoSet.UpdateDateTime;
            // 企業コード
            custSlipNoSetWork.EnterpriseCode = custSlipNoSet.EnterpriseCode;
            // GUID
            custSlipNoSetWork.FileHeaderGuid = custSlipNoSet.FileHeaderGuid;
            // 更新従業員コード
            custSlipNoSetWork.UpdEmployeeCode = custSlipNoSet.UpdEmployeeCode;
            // 更新アセンブリID1
            custSlipNoSetWork.UpdAssemblyId1 = custSlipNoSet.UpdAssemblyId1;
            // 更新アセンブリID2
            custSlipNoSetWork.UpdAssemblyId2 = custSlipNoSet.UpdAssemblyId2;
            // 論理削除区分
            custSlipNoSetWork.LogicalDeleteCode = custSlipNoSet.LogicalDeleteCode;

            // 得意先コード
            custSlipNoSetWork.CustomerCode = custSlipNoSet.CustomerCode;
            // 計上年月
            custSlipNoSetWork.AddUpYearMonth = custSlipNoSet.AddUpYearMonth;

            // 現在得意先伝票番号
            custSlipNoSetWork.PresentCustSlipNo = custSlipNoSet.PresentCustSlipNo;
            // 開始得意先伝票番号
            custSlipNoSetWork.StartCustSlipNo = custSlipNoSet.StartCustSlipNo;
            // 終了得意先伝票番号
            custSlipNoSetWork.EndCustSlipNo = custSlipNoSet.EndCustSlipNo;

            // --- DEL 2008/09/22 -------------------------------->>>>>
            //// 得意先伝票番号ヘッダ
            //custSlipNoSetWork.CustSlipNoHeader = custSlipNoSet.CustSlipNoHeader;
            //// 得意先伝票番号フッタ
            //custSlipNoSetWork.CustSlipNoFooter = custSlipNoSet.CustSlipNoFooter;
            // --- DEL 2008/09/22 --------------------------------<<<<<

            return custSlipNoSetWork;
        }

        /// <summary>
        /// クラスメンバーコピー処理（得意先設定(伝票設定)ワーククラス⇒得意先設定(伝票設定)クラス）
        /// </summary>
        /// <param name="custSlipNoSetWork">得意先設定(伝票設定)ワーククラス</param>
        /// <returns>CustSlipNoSet</returns>
        /// <remarks>
        /// <br>Note       : 得意先設定(伝票設定)ワーククラスから得意先設定(伝票設定)クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private CustSlipNoSet CopyToSlipOutputSetFromSlipOutputSetWork(CustSlipNoSetWork custSlipNoSetWork)
        {
            CustSlipNoSet custSlipNoSet = new CustSlipNoSet();

            // 作成日時
            custSlipNoSet.CreateDateTime = custSlipNoSetWork.CreateDateTime;
            // 更新日時
            custSlipNoSet.UpdateDateTime = custSlipNoSetWork.UpdateDateTime;
            // 企業コード
            custSlipNoSet.EnterpriseCode = custSlipNoSetWork.EnterpriseCode;
            // GUID
            custSlipNoSet.FileHeaderGuid = custSlipNoSetWork.FileHeaderGuid;
            // 更新従業員コード
            custSlipNoSet.UpdEmployeeCode = custSlipNoSetWork.UpdEmployeeCode;
            // 更新アセンブリID1
            custSlipNoSet.UpdAssemblyId1 = custSlipNoSetWork.UpdAssemblyId1;
            // 更新アセンブリID2
            custSlipNoSet.UpdAssemblyId2 = custSlipNoSetWork.UpdAssemblyId2;
            // 論理削除区分
            custSlipNoSet.LogicalDeleteCode = custSlipNoSetWork.LogicalDeleteCode;

            // 得意先コード
            custSlipNoSet.CustomerCode = custSlipNoSetWork.CustomerCode;
            // 計上年月
            custSlipNoSet.AddUpYearMonth = custSlipNoSetWork.AddUpYearMonth;

            // 現在得意先伝票番号
            custSlipNoSet.PresentCustSlipNo = custSlipNoSetWork.PresentCustSlipNo;
            // 開始得意先伝票番号
            custSlipNoSet.StartCustSlipNo = custSlipNoSetWork.StartCustSlipNo;
            // 終了得意先伝票番号
            custSlipNoSet.EndCustSlipNo = custSlipNoSetWork.EndCustSlipNo;

            // --- DEL 2008/09/22 -------------------------------->>>>>
            //// 得意先伝票番号ヘッダ
            //custSlipNoSet.CustSlipNoHeader = custSlipNoSetWork.CustSlipNoHeader;
            //// 得意先伝票番号フッタ
            //custSlipNoSet.CustSlipNoFooter = custSlipNoSetWork.CustSlipNoFooter;
            // --- DEL 2008/09/22 --------------------------------<<<<<

            return custSlipNoSet;
        }

        /// <summary>
        /// クラスメンバーコピー処理（得意先設定(伝票設定)クラス⇒DataRow）
        /// </summary>
        /// <param name="custSlipNoSetWork">得意先設定(伝票設定)クラス</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : 得意先設定(伝票設定)ワーククラスから得意先設定(伝票設定)クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private DataRow CopyToDataRowFromSlipOutputSetWork(ref CustSlipNoSetWork custSlipNoSetWork)
        {
            CustSlipNoSet custSlipNoSet = CopyToSlipOutputSetFromSlipOutputSetWork(custSlipNoSetWork);

            // 得意先設定(伝票設定)マスタへの登録
            DataRow dr;
            dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	custSlipNoSet.CustomerCode,
																					custSlipNoSet.AddUpYearMonth});
            if (dr == null)
            {
                dr = this._dataTableList.Tables[SECOND_TABLE].NewRow();
            }

            // 作成日時
            dr[CREATEDATETIME] = custSlipNoSet.CreateDateTime;
            // 更新日時
            dr[UPDATEDATETIME] = custSlipNoSet.UpdateDateTime;
            // 企業コード
            dr[ENTERPRISECODE] = custSlipNoSet.EnterpriseCode;

            if (custSlipNoSet.FileHeaderGuid == Guid.Empty)
            {
                // GUID
                dr[FILEHEADERGUID] = Guid.NewGuid();
            }
            else
            {
                // GUID
                dr[FILEHEADERGUID] = custSlipNoSet.FileHeaderGuid;
            }
            // 更新従業員コード
            dr[UPDEMPLOYEECODE] = custSlipNoSet.UpdEmployeeCode;
            // 更新アセンブリID1
            dr[UPDASSEMBLYID1] = custSlipNoSet.UpdAssemblyId1;
            // 更新アセンブリID2
            dr[UPDASSEMBLYID2] = custSlipNoSet.UpdAssemblyId2;
            // 論理削除区分
            dr[LOGICALDELETECODE] = custSlipNoSet.LogicalDeleteCode;

            // 得意先コード
            dr[CUSTOMERCODE_TITLE] = custSlipNoSet.CustomerCode;
            // 計上年月
            dr[ADDUPYEARMONTH_TITLE] = custSlipNoSet.AddUpYearMonth;

            // 現在得意先伝票番号
            dr[PRESENTCUSTSLIPNO_TITLE] = custSlipNoSet.PresentCustSlipNo;
            // 開始得意先伝票番号
            dr[STARTCUSTSLIPNO_TITLE] = custSlipNoSet.StartCustSlipNo;
            // 終了得意先伝票番号
            dr[ENDCUSTSLIPNO_TITLE] = custSlipNoSet.EndCustSlipNo;

            // --- DEL 2008/09/22 -------------------------------->>>>>
            //// 得意先伝票番号ヘッダ
            //dr[CUSTSLIPNOHEADER_TITLE] = custSlipNoSet.CustSlipNoHeader;
            //// 得意先伝票番号フッタ
            //dr[CUSTSLIPNOFOOTER_TITLE] = custSlipNoSet.CustSlipNoFooter;
            // --- DEL 2008/09/22 --------------------------------<<<<<

            // 削除日
            if (custSlipNoSet.LogicalDeleteCode == 0)
            {
                dr[DELETE_DATE_TITLE] = "";
            }
            else
            {
                dr[DELETE_DATE_TITLE] = custSlipNoSet.UpdateDateTimeJpInFormal;
            }

            return dr;
        }

        #endregion

        #region SearchProc 検索処理メイン（論理削除含む）
        /// <summary>
        /// 検索処理メイン（論理削除含む）
        /// </summary>
        /// <param name="retArrayList">読込結果コレクション(ArrayList)</param>
        /// <param name="retList">読込結果コレクション(DataSet)</param>
        /// <param name="retTotalCnt">読込対象データ総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private int SearchProc(out ArrayList retArrayList
                                , out DataSet retList
                                , out int retTotalCnt
                                , out bool nextData
                                , string enterpriseCode
                                , ConstantManagement.LogicalMode logicalMode
                                , out string message)
        {

            int status = 0;
            retList = null;
            retTotalCnt = 0;
            nextData = false;
            message = "";

            retArrayList = new ArrayList();

            // 得意先マスタの論理削除が0(正常)、得意先伝票番号区分が0以外の場合保存。
            // 得意先コードと名称(Name)を保持
            Dictionary<int, string> customerList = new Dictionary<int, string>(); // ADD 2009/02/13

            // ADD 2009/02/13 得意先マスタと伝票設定マスタの読込み順を変更
            //==========================================
            // 得意先マスタ読み込み
            //==========================================

            CustomerSearchRet[] customerSearchRetArray;
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;

            // 得意先マスタ取得
            status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);

            if (status == 0)
            {
                if (customerSearchRetArray.Length <= 0)
                {

                }
                else
                {
                    foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
                    {
                        // --- DEL 2009/02/12 -------------------------------->>>>>
                        //    // ADD 2008/12/02 不具合対応[8568] ---------->>>>>
                        //if (customerSearchRet.LogicalDeleteCode == 0)
                        //    {
                        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/10 G.Miyatsu ADD
                        //        //CustomerInfo customerInfo = new CustomerInfo();
                        //        //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                        //        // --- DEL 2009/02/12 -------------------------------->>>>>
                        //        if (customerInfoWorkList.ContainsKey(customerSearchRet.CustomerCode))
                        //        {
                        //            customerInfo = customerInfoWorkList[customerSearchRet.CustomerCode];
                        //        }
                        //        else
                        //        {
                        //            status = _customerInfoAcs.ReadDBData(0, this._enterpriseCode, customerSearchRet.CustomerCode, out customerInfo);
                        //            customerInfoWorkList.Add(customerSearchRet.CustomerCode, customerInfo);
                        //        }
                        //        // --- DEL 2009/02/12 --------------------------------<<<<<
                        //        if( (status == 0)&&(customerInfo.CustomerSlipNoDiv != 0) ){
                        //                // データテーブルへ格納
                        //                AddRowFromCustomerSearchRet(customerSearchRet, customerInfo);
                        //        }
                        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/10 G.Miyatsu ADD
                        //    }
                        //    // ADD 2008/12/02 不具合対応[8568] ----------<<<<<
                        ////}
                        // --- DEL 2009/02/12 --------------------------------<<<<<
                        // --- ADD 2009/02/12 -------------------------------->>>>>
                        if (customerSearchRet.LogicalDeleteCode == 0 && customerSearchRet.CustomerSlipNoDiv != 0)
                        {
                            if (this._dataTableList.Tables[MAIN_TABLE].Rows.Find(new object[] { customerSearchRet.CustomerCode }) == null)
                            {
                                DataRow dr = this._dataTableList.Tables[MAIN_TABLE].NewRow();

                                dr[CUSTOMERCODE_TITLE] = customerSearchRet.CustomerCode;
                                dr[CUSTOMERNAME_TITLE] = customerSearchRet.Name;

                                this._dataTableList.Tables[MAIN_TABLE].Rows.Add(dr);
                            }

                            if (!customerList.ContainsKey(customerSearchRet.CustomerCode))
                            {
                                customerList.Add(customerSearchRet.CustomerCode, customerSearchRet.Name);
                            }
                        }
                        // --- ADD 2009/02/12 --------------------------------<<<<<
                    }
                }
            }

            //==========================================
            // 得意先設定(伝票設定)マスタ読み込み
            //==========================================
            // 抽出条件パラメータ
            CustSlipNoSetWork paraWork = new CustSlipNoSetWork();

            paraWork.EnterpriseCode = enterpriseCode;

            // 数値型の項目は「0」データを考慮し、全検索対象時は「-1」とする
            paraWork.AddUpYearMonth = -1;	// 計上年月

            ArrayList custSlipNoSetWorkArray = new ArrayList();

            // リモート戻りリスト
            object custSlipNoSetWorkList = (object)custSlipNoSetWorkArray;

            // 得意先情報の一時保管
            Dictionary<int, object> customerInfoWorkList = new Dictionary<int,object>();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/10 G.Miyatsu ADD
            // 得意先設定(伝票設定)マスタ検索
            status = this._iCustSlipNoSetDB.Search(ref custSlipNoSetWorkList, paraWork, 0, logicalMode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/10 G.Miyatsu ADD

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //CustomerInfo customerInfo; // ADD 2009/02/12

                // データテーブルにセット
                foreach (CustSlipNoSetWork custSlipNoSetWork in (ArrayList)custSlipNoSetWorkList)
                {
                    // --- DEL 2009/02/13 -------------------------------->>>>>
                    //// ADD 2008/12/02 不具合対応[8568] ---------->>>>>

                    //    //CustomerInfo customerInfo = new CustomerInfo();
                    //    //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                    //    int customerCode = custSlipNoSetWork.CustomerCode;
                    //    status = _customerInfoAcs.ReadDBData(0, this._enterpriseCode, customerCode, out customerInfo);
                    //    if (status == 0 )
                    //    {
                    //        // >>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/10 G.Miyatsu ADD
                    //        // 逐次読み込まなくてもいいように顧客情報をここに保管しておく
                    //        if (!customerInfoWorkList.ContainsKey(customerCode))
                    //        {
                    //            customerInfoWorkList.Add(customerCode, customerInfo);
                    //        }
                    //        // <<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/10 G.Miyatsu ADD

                    //            // ADD 2008/12/02 不具合対応[8568] ----------<<<<<
                    //            // データテーブルへ格納
                    //            //AddRowFromSlipOutputSetWork(custSlipNoSetWork); // 2008/12/10 G.Miyatsu DEL
                    //            AddRowFromSlipOutputSetWork(custSlipNoSetWork, customerInfo); // 2008/12/10 G.Miyatsu ADD
                                
                    //            // ArrayListへ格納
                    //            retArrayList.Add(CopyToSlipOutputSetFromSlipOutputSetWork(custSlipNoSetWork));
                    //            // ADD 2008/12/02 不具合対応[8568] ---------->>>>>
                    //    }
                    //    else
                    //    {
                    //        //break; // DEL 2009/02/12
                    //        continue; // ADD 2009/02/12
                    //    }
                    //// ADD 2008/12/02 不具合対応[8568] ----------<<<<<
                    // --- DEL 2009/02/13 --------------------------------<<<<<
                    // --- ADD 2009/02/13 -------------------------------->>>>>
                    if (customerList.ContainsKey(custSlipNoSetWork.CustomerCode))
                    {
                        // データテーブルへ格納
                        AddRowFromSlipOutputSetWork(custSlipNoSetWork, customerList);

                        // ArrayListへ格納
                        retArrayList.Add(CopyToSlipOutputSetFromSlipOutputSetWork(custSlipNoSetWork));
                    }
                    // --- ADD 2009/02/13 --------------------------------<<<<<
                }
            }
            
            //==========================================
            // データセットを返す
            //==========================================
            retList = this._dataTableList;

            return status;
        }
        #endregion

        /// <summary>
        /// 得意先マスタ　→　データテーブル　追加処理
        /// </summary>
        /// <param name="custSlipNoSetWork">得意先設定(伝票設定)ワーククラス</param>
        //private void AddRowFromCustomerSearchRet(CustomerSearchRet customerSearchRet) // 2008/12/10 G.Miyatsu DEL
        private void AddRowFromCustomerSearchRet(CustomerSearchRet customerSearchRet , object customerInfo) // 2008/12/10 G.Miyatsu ADD
        {
            DataRow dr;
            
            try
            { 
                // 第１グリッド（得意先コード）
                if (((CustomerInfo)customerInfo).CustomerSlipNoDiv != 0)
                {
                    if (this._dataTableList.Tables[MAIN_TABLE].Rows.Find(new object[] { customerSearchRet.CustomerCode }) == null)
                    {
                        dr = this._dataTableList.Tables[MAIN_TABLE].NewRow();
                        dr[CUSTOMERCODE_TITLE] = customerSearchRet.CustomerCode;
                        //dr[CUSTOMERNAME_TITLE] = GetCustomerName(customerSearchRet.CustomerCode); // 2008/12/10 G.Miyatsu DEL
                        dr[CUSTOMERNAME_TITLE] = ((CustomerInfo)customerInfo).Name; // 2008/12/10 G.Miyatsu ADD
                        
                        this._dataTableList.Tables[MAIN_TABLE].Rows.Add(dr);
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 得意先設定(伝票設定)マスタ　→　データテーブル　追加処理
        /// </summary>
        /// <param name="custSlipNoSetWork">得意先設定(伝票設定)ワーククラス</param>
        /// 
        //private void AddRowFromSlipOutputSetWork(CustSlipNoSetWork custSlipNoSetWork) // 2008/12/10 G.Miyatsu DEL
        //private void AddRowFromSlipOutputSetWork(CustSlipNoSetWork custSlipNoSetWork, object customerInfo) // 2008/12/10 G.Miyatsu ADD // DEL 2009/02/13
        private void AddRowFromSlipOutputSetWork(CustSlipNoSetWork custSlipNoSetWork, Dictionary<int, string> customerList)
        {
            DataRow dr;

            try
            {
                //if (((CustomerInfo)customerInfo).CustomerSlipNoDiv != 0) // DEL 2009/02/13
                //{
                    // 第１グリッド（得意先コード）
                    if (this._dataTableList.Tables[MAIN_TABLE].Rows.Find(new object[] { custSlipNoSetWork.CustomerCode }) == null)
                    {
                        dr = this._dataTableList.Tables[MAIN_TABLE].NewRow();
                        dr[CUSTOMERCODE_TITLE] = custSlipNoSetWork.CustomerCode;
                        //dr[CUSTOMERNAME_TITLE] = GetCustomerName(custSlipNoSetWork.CustomerCode); // 2008/12/10 G.Miyatsu DEL
                        //dr[CUSTOMERNAME_TITLE] = ((CustomerInfo)customerInfo).Name; // 2008/12/10 G.Miyatsu ADD // DEL 2009/02/13
                        dr[CUSTOMERNAME_TITLE] = customerList[custSlipNoSetWork.CustomerCode];  // ADD 2009/02/13

                        this._dataTableList.Tables[MAIN_TABLE].Rows.Add(dr);
                    }

                    // 第２グリッド（計上年月）
                    if (this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	custSlipNoSetWork.CustomerCode,
                                                                                        custSlipNoSetWork.AddUpYearMonth }) == null)
                    {
                        dr = CopyToDataRowFromSlipOutputSetWork(ref custSlipNoSetWork);
                        this._dataTableList.Tables[SECOND_TABLE].Rows.Add(dr);
                    }
                //}
            }
            catch
            {
            }
        }

        /// <summary>
        /// 得意先設定(伝票設定)読み込み処理
        /// </summary>
        /// <param name="custSlipNoSet">得意先設定(伝票設定)オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="addUpYearMonth">計上年月</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先設定(伝票設定)情報を読み込みます。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Read(out CustSlipNoSet custSlipNoSet,
                        string enterpriseCode,
                        Int32 customerCode,
                        Int32 addUpYearMonth)
        {
            try
            {
                int status = 0;
                custSlipNoSet = null;
                CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();

                // キー項目設定
                custSlipNoSetWork.EnterpriseCode = enterpriseCode;
                custSlipNoSetWork.CustomerCode = customerCode;
                custSlipNoSetWork.AddUpYearMonth = addUpYearMonth;

                ArrayList custSlipNoSetArray = new ArrayList();

                custSlipNoSetArray.Add(custSlipNoSetWork);

                object retobj = (object)custSlipNoSetArray;
                   
                // 得意先設定(伝票設定)読み込み 
                status = this._iCustSlipNoSetDB.Read(ref retobj, 0);

                if (status == 0)
                {
                    ArrayList retArray = (ArrayList)retobj;
                    custSlipNoSetWork = (CustSlipNoSetWork)retArray[0];

                    // クラス内メンバコピー
                    //slipOutputSet = CopyToSlipOutputSetFromSlipOutputSetWork(slipOutputSetWork);
                }

                if (status == 0)
                {
                    // クラス内メンバコピー
                    custSlipNoSet = CopyToSlipOutputSetFromSlipOutputSetWork(custSlipNoSetWork);
                }

                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                custSlipNoSet = null;
                //オフライン時はnullをセット
                this._iCustSlipNoSetDB = null;
                return -1;
            }
        }

        #endregion

        #region 各種変換
        /// <summary>
        /// NULL文字変換処理
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <returns>string型データ</returns>
        /// <remarks>
        /// <br>Note       : NULL文字が含まれている場合ダブルクォートへ変換する</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public static string NullChgStr(object obj)
        {
            string ret;
            try
            {
                if (obj == null)
                {
                    ret = "";
                }
                else
                {
                    ret = obj.ToString();
                }
            }
            catch
            {
                ret = "";
            }
            return ret;
        }

        /// <summary>
        /// NULL文字変換処理
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <returns>int型データ</returns>
        /// <remarks>
        /// <br>Note       : NULL文字が含まれている場合「0」へ変換する</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public static int NullChgInt(object obj)
        {
            int ret;
            try
            {
                if ((obj == null) || (string.Equals(obj.ToString(), "") == true))
                {
                    ret = 0;
                }
                else
                {
                    ret = Convert.ToInt32(obj);
                }
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
        #endregion

        #region [2008/12/10 G.Miyatsu DEL]
        ///// <summary>
        ///// 得意先名称取得処理
        ///// </summary>
        ///// <param name="customerCode">得意先コード</param>
        ///// <returns>得意先名称</returns>
        ///// <remarks>
        ///// <br>Note       : 得意先名称を取得します。</br>
        ///// <br>Programmer : 30416 長沼 賢二</br>
        ///// <br>Date       : 2008.06.24</br>
        ///// </remarks>
        //private string GetCustomerName(int customerCode)
        //{
        //    string customerName = "";

        //    int status;

        //    CustomerInfo customerInfo = new CustomerInfo();
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();


        //    try
        //    {
        //        status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);

        //        if (status == 0)
        //        {
        //            customerName = customerInfo.CustomerSnm.Trim();
        //        }
        //    }
        //    catch
        //    {
        //        customerName = "";
        //    }

        //    return customerName;
        //}
        #endregion
    }
}
