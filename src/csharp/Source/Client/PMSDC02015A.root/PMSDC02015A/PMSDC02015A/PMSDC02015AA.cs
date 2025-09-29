//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上連携テキスト出力
// プログラム概要   : 売上連携テキスト出力帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570219-00     作成担当 : 田建委
// 作 成 日  2019/12/02      修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11570219-00     作成担当 : 寺田義啓
// 更 新 日  2020/02/04      修正内容 : （修正内容一覧No.２）備考出力設定項目変更対応
//----------------------------------------------------------------------------//
// 管理番号  11670214-00     作成担当 : 3H 尹安
// 更 新 日  2019/09/03      修正内容 : 売上データ出力文字種拡張対応
//                                      ①連携データの品名全角文字を半角スペースに変換する処理をせず、元の品名のまま送信する
//                                      ②連携データの商品名称カナが未設定の場合、商品名称を設定する
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using Broadleaf.Application.Resources;
using System.Threading;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上データテキスト出力 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 売上データテキスト出力で使用するデータを取得する。</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2019/12/02</br>
    /// </remarks>
    public class SalesCprtAcs
    {
        #region ■ Constructor
        /// <summary>
        /// 売上データテキスト出力アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上データテキスト出力アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public SalesCprtAcs()
        {
            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ログイン拠点を取得
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._iSalesCprtWorkDB = (ISalesCprtWorkDB)MediationSalesCprtResultDB.GetSalesCprtWorkDB();

            //伝票印刷設定マスタリストの取得
            _slipPrtSetAcs = new SlipPrtSetAcs();

            _custSlipMngAcs = new CustSlipMngAcs();

            _slipTypeController = new SlipTypeController();

            //伝票印刷設定マスタリスト
            ArrayList slipPrtSetList;

            _slipPrtSetAcs.SearchSlipPrtSet(out slipPrtSetList, this._enterpriseCode);

            //得意先マスタ（伝票管理）リスト
            int totalCount;
            _custSlipMngAcs.SearchOnlyCustSlipMng(out totalCount, this._enterpriseCode);

            _slipTypeController.EnterpriseCode = this._enterpriseCode;
            _slipTypeController.SlipPrtSetList = GetSlipPrtSet(slipPrtSetList);
            _slipTypeController.CustSlipMngList = GetCustSlipMng(_custSlipMngAcs.CustSlipMngList);
            ReadMaker(this._enterpriseCode);
            GetPosTerminalMg(out this._posTerminalMg, this._enterpriseCode);

        }

        /// <summary>
        /// 売上データテキスト出力アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上データテキスト出力アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        static SalesCprtAcs()
        {
            stc_Employee = null;
            stc_PrtOutSet = null;					// 帳票出力設定データクラス	
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }
        }
        #endregion ■ Constructor

        #region ■ Static Member
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			            // 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	            // 帳票出力設定アクセスクラス

        #region API定義
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);

        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int InternetAttemptConnect(int dwReserved);
        #endregion
        #endregion ■ Static Member

        #region ■ Private Member
        ISalesCprtWorkDB _iSalesCprtWorkDB;

        private ArrayList codeList = new ArrayList();
        private ArrayList dataList = new ArrayList();
        private Hashtable _sectionCdTable = new Hashtable();

        private DataTable _salesHistoryDt;			// 印刷DataTable

        private const string ZERO = "0";
        private const string ONE = "1";
        private const string TWO = "2";
        private const string STRING_BOUNDARY = "-----------------------------7d21cef303f8";
        private const string STRING_CHANGE_ROW = "\r\n";
        private const int ERROR_SUCCESS = 0;
        private const int SUPPLIERCD = 0;

        /// <summary>ログメッセージ：送信対象データ無し</summary>
        private const string LOGMSG_NODATA = "該当するデータはありません";
        /// <summary>ログメッセージ：送信準備エラー</summary>
        private const string LOGMSG_ERROR = "送信準備エラー";
        /// <summary>ログメッセージ：Javaバージョンエラー</summary>
        private const string LOGMSG_JAVAVERERR = "Javaのバージョンが古い為、実行できません。バージョン5.0以上のJavaをインストールして下さい。";
        /// <summary>ログメッセージ：通信エラー</summary>
        private const string LOGMSG_SENDERR = "通信エラー";
        /// <summary>ログメッセージ：ユーザーとパスワード不正</summary>
        private const string LOGMSG_USERERR = "ユーザーとパスワード不正";
        /// <summary>ログメッセージ：タイムアウトエラー</summary>
        private const string LOGMSG_TIMEOUTERR = "タイムアウトエラー";
        /// <summary>ログメッセージ：通信エラー補正</summary>
        private const string LOGMSG_SENDADDERR = "(Code:";
        /// <summary>ログメッセージ：予想外のエラー</summary>
        private const string LOGMSG_UNEXPECTEDERR = "予期せぬ例外が発生しました。(Code:-999)";
        private const string LOGMSG_RETRYCNT = "(Retry)";

        private const string CtWebSendError = "連携先への送信に失敗しました。";
        private const string CtRequestError = "インターネット回線接続に失敗しました。";
        private const string CtWebError = "連携先へのリクエスト送信に失敗しました。";
        private const string CtHeaderError = "情報取得処理に失敗しました。";
        private const string CtWSSETokenError = "連携先との認証情報取得に失敗しました。";
        private const string CtDigestError = "暗号化処理に失敗しました。";
        private const string CtResponseError = "連携先の結果受信に失敗しました。";
        private const string CtConnectError = "連携先への接続に失敗しました。";
        // プログラムID
        private const string CtPGID = "PMSDC02015A";
        /// <summary> XMLファイル名称 </summary>
        private const string XML_FILE_NAME = "PMSDC02015A_RetryWaitTimeSetting.xml";
        private DataSet UiDataSet;

        /// <summary>送信日時（開始）</summary>
        private long _sendDateTimeStart;
        /// <summary>送信日時（終了）</summary>
        private long _sendDateTimeEnd;
        /// <summary>送信伝票枚数</summary>
        private int _sendSlipCount;
        /// <summary>送信伝票明細数</summary>
        private int _sendSlipDtlCnt;
        /// <summary>送信伝票合計金額</summary>
        private long _sendSlipTotalMny;

        /// <summary>送信日時（終了）</summary>
        public long SendDateTimeEnd
        {
            set { this._sendDateTimeEnd = value; }
            get { return this._sendDateTimeEnd; }
        }

        private SlipPrtSetAcs _slipPrtSetAcs = null;

        private CustSlipMngAcs _custSlipMngAcs = null;

        private SlipTypeController _slipTypeController = null;

        private ArrayList _resultWorkClone;
        // メーカーアクセスクラス
        private MakerAcs _makerAcs = null;

        // メーカーデータ格納用
        private static Hashtable _makerListStc = null;

        //接続情報マスタ
        private SalCprtConnectInfoWorkAcs _connectInfoWorkAcs = null;
        private HttpWebRequest request = null;
        // 端末設定
        private PosTerminalMg _posTerminalMg = null;

        // 企業コード
        private string _enterpriseCode = "";

        // 拠点コード
        private string _sectionCode = "";

        #endregion ■ Private Member

        #region ■ Public Property
        /// <summary>
        /// 印刷データセット(読み取り専用)
        /// </summary>
        public DataTable SalesHistoryDt
        {
            get { return this._salesHistoryDt; }
        }
        #endregion ■ Public Property

        #region ■ Public Method
        /// <summary>
        /// データ抽出処理
        /// </summary>
        /// <param name="salesCprtCndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="connectInfoWork">接続情報</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// <br>Update Note: 2020/02/04 寺田 義啓</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>           :（修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        public int SearchSalesHistoryProcMain(SalesCprtCndtnWork salesCprtCndtn, out string errMsg, SalCprtConnectInfoWork connectInfoWork)
        {
            //↓ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
            //return this.SearchSalesHistoryProc(salesCprtCndtn, out errMsg);
            return this.SearchSalesHistoryProc(salesCprtCndtn, out errMsg, connectInfoWork);
            //↑ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
        }

        /// <summary>
        /// 印刷データ抽出処理
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public DataTable GetprintdataTable()
        {
            DataView printdataView;
            DataTable printdataTable = null;

            if (this._salesHistoryDt != null && this._salesHistoryDt.Rows.Count > 0)
            {
                // DataView作成
                printdataView = new DataView(this._salesHistoryDt, string.Empty, GetSortOrder(), DataViewRowState.CurrentRows);

                // DataTable Create ----------------------------------------------------------
                PMSDC02014EA.CreatePrintDataTable(ref printdataTable);

                //前回拠点コード
                string befSectionCode = string.Empty;
                //前回得意先ｺｰﾄﾞ
                string befCustomerCode = string.Empty;

                List<List<DataRowView>> tempList = new List<List<DataRowView>>();
                List<DataRowView> temp = new List<DataRowView>();

                for (int i = 0; i < printdataView.Count; i++)
                {
                    DataRowView dataRowView = (DataRowView)printdataView[i];

                    if ((string.IsNullOrEmpty(befSectionCode) && string.IsNullOrEmpty(befCustomerCode))
                        || (!befSectionCode.Equals(dataRowView[PMSDC02014EA.ct_Col_SectionCodeRF])
                        || (!befCustomerCode.Equals(dataRowView[PMSDC02014EA.ct_Col_CustomerCode]))))
                    {
                        if (string.IsNullOrEmpty(befSectionCode) && string.IsNullOrEmpty(befCustomerCode))
                        {
                            temp.Add(dataRowView);
                        }

                        if ((!string.IsNullOrEmpty(befSectionCode) && (!string.IsNullOrEmpty(befCustomerCode)))
                            && (!befSectionCode.Equals(dataRowView[PMSDC02014EA.ct_Col_SectionCodeRF])
                        || (!befCustomerCode.Equals(dataRowView[PMSDC02014EA.ct_Col_CustomerCode]))))
                        {
                            tempList.Add(temp);

                            temp = new List<DataRowView>();

                            temp.Add(dataRowView);
                        }
                        else if ((!string.IsNullOrEmpty(befSectionCode)) && (!string.IsNullOrEmpty(befCustomerCode)))
                        {
                            temp.Add(dataRowView);
                        }

                        befSectionCode = dataRowView[PMSDC02014EA.ct_Col_SectionCodeRF].ToString();

                        befCustomerCode = dataRowView[PMSDC02014EA.ct_Col_CustomerCode].ToString();

                    }
                    else
                    {
                        temp.Add(dataRowView);
                    }

                    if (i == (printdataView.Count - 1))
                    {
                        tempList.Add(temp);
                    }
                }

                foreach (List<DataRowView> detailList in tempList)
                {
                    //前回売上伝票番号
                    string befSalesSlipNum = string.Empty;

                    DataRow dr = printdataTable.NewRow();

                    //伝票枚数
                    int slipCountSum = 0;
                    //売上合計
                    long salesMoneySum = 0;
                    //値引予定額
                    long salesSupplierMoneySum = 0;

                    //行数
                    int pureCount = 0;

                    for (int j = 0; j < detailList.Count; j++)
                    {
                        DataRowView detailView = (DataRowView)detailList[j];

                        //伝票枚数
                        string salesSlipNum = detailView[PMSDC02014EA.ct_Col_SalesSlipNum].ToString();
                        if (!string.IsNullOrEmpty(salesSlipNum) && (!befSalesSlipNum.Equals(salesSlipNum)))
                        {
                            slipCountSum++;
                        }
                        befSalesSlipNum = salesSlipNum;

                        //売上合計
                        salesMoneySum += Convert.ToInt64(detailView[PMSDC02014EA.ct_Col_PdfSalesMoneyTaxExc]);

                        //値引予定額
                        long salesMoneyDetail = Convert.ToInt64(detailView[PMSDC02014EA.ct_Col_PdfSalesMoneyTaxExc]);
                        long supplierMoneyDetail = Convert.ToInt64(detailView[PMSDC02014EA.ct_Col_PdfSupplierMoney]);
                        salesSupplierMoneySum += (salesMoneyDetail - supplierMoneyDetail);
                        //行数
                        pureCount++;
                    }
                    dr[PMSDC02014EA.ct_Col_CustomerCode] = detailList[0][PMSDC02014EA.ct_Col_CustomerCode];
                    dr[PMSDC02014EA.ct_Col_SectionCodeRF] = detailList[0][PMSDC02014EA.ct_Col_SectionCodeRF];
                    dr[PMSDC02014EA.ct_Col_SectionGuideSnm] = detailList[0][PMSDC02014EA.ct_Col_SectionGuideSnm];
                    dr[PMSDC02014EA.ct_Col_CustomerSnm] = detailList[0][PMSDC02014EA.ct_Col_CustomerSnm];
                    dr[PMSDC02014EA.ct_Col_SlipCountSum] = slipCountSum.ToString();
                    dr[PMSDC02014EA.ct_Col_SalesMoneySum] = salesMoneySum.ToString();
                    dr[PMSDC02014EA.ct_Col_SalesSupplierMoneySum] = salesSupplierMoneySum.ToString();
                    dr[PMSDC02014EA.ct_Col_PureCount] = pureCount.ToString();

                    printdataTable.Rows.Add(dr);
                }
            }
            else
            {
                printdataTable = new DataTable();
            }

            return printdataTable;
        }

        /// <summary>
        /// 売上抽出データ更新処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public int Write(out string errMsg)
        {
            return this.WriteProc(this._resultWorkClone, out errMsg);
        }
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ データ取得
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="salesCprtCndtn"></param>
        /// <param name="errMsg"></param>
        /// <param name="connectInfoWork"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// <br>Update Note: 2020/02/04 寺田 義啓</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>           :（修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        private int SearchSalesHistoryProc(SalesCprtCndtnWork salesCprtCndtn, out string errMsg, SalCprtConnectInfoWork connectInfoWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            this._sendDateTimeStart = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
            int logStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            SalCprtSndLogListResultWork salCprtSndLogWork = new SalCprtSndLogListResultWork();

            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMSDC02014EA.CreateDataTable(ref this._salesHistoryDt);

                // データ取得  ----------------------------------------------------------------
                object salesHistoryResultWork = null;
                status = _iSalesCprtWorkDB.Search(out salesHistoryResultWork, (object)salesCprtCndtn);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        ArrayList salesHistoryResultList = salesHistoryResultWork as ArrayList;

                        //データのConvert処理 
                        //↓ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
                        //status = GetSalesHistoryData(salesCprtCndtn, salesHistoryResultList);
                        status = GetSalesHistoryData(salesCprtCndtn, salesHistoryResultList, connectInfoWork);
                        //↑ UPD 2020/02/04 Y.Terada  修正内容一覧No.2

                        // 伝票枚数、明細枚数、合計金額の計算
                        CalcuSalseInfo();

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                        {
                            errMsg = "該当するデータがありません。";
                            // 送信ログを登録
                            this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // 送信日時（終了）
                            logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, 2, LOGMSG_NODATA);
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        errMsg = "該当するデータがありません。";
                        //送信ログの登録
                        this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // 送信日時（終了）
                        logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, 2, LOGMSG_NODATA);
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                        errMsg = "データ抽出処理に失敗しました。";
                        //送信ログの登録
                        this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // 送信日時（終了）
                        logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, status, LOGMSG_ERROR);
                        break;
                    default:
                        errMsg = "データ抽出処理に失敗しました。";
                        //送信ログの登録
                        this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // 送信日時（終了）
                        logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, -1, LOGMSG_ERROR);
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                //送信ログの登録
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // 送信日時（終了）
                logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, status, LOGMSG_ERROR);
            }
            return status;
        }
        #endregion

        #region ◎ ソート順作成
        /// <summary>
        /// ソート順作成
        /// </summary>
        /// <returns>ソート文字列</returns>
        /// <remarks>
        /// <br>Note       : ソート文字列の取得処理を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string GetSortOrder()
        {
            StringBuilder strSortOrder = new StringBuilder();

            strSortOrder.Append(string.Format("{0} ASC,", PMSDC02014EA.ct_Col_SectionCodeRF));
            strSortOrder.Append(string.Format("{0} ASC,", PMSDC02014EA.ct_Col_CustomerCode));
            strSortOrder.Append(string.Format("{0} ASC", PMSDC02014EA.ct_Col_SalesSlipNum));

            return strSortOrder.ToString();
        }
        #endregion

        #region ◎ 売上抽出データ更新処理
        /// <summary>
        /// 売上抽出データ更新
        /// </summary>
        /// <param name="resultWork"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 売上抽出データを更新する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private int WriteProc(ArrayList resultWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            errMsg = string.Empty;

            object objectresultWork = resultWork as object;

            if (resultWork != null && resultWork.Count > 0)
            {
                // 書き込み処理
                status = this._iSalesCprtWorkDB.Write(ref objectresultWork);
            }

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                errMsg = "売上抽出データ更新処理に失敗しました。";
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            return status;
        }
        #region ReadMaker
        /// <summary>
        /// メーカーデータ読み込み処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メーカーマスタ情報を全件取得します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private int ReadMaker(string enterpriseCode)
        {
            _makerListStc = new Hashtable();

            if (this._makerAcs == null)
            {
                // メーカーアクセスクラス
				this._makerAcs = new MakerAcs();
            }
            ArrayList makerList;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = this._makerAcs.SearchAll(out makerList, enterpriseCode);

            if ((status == 0) && (makerList.Count > 0))
            {
                foreach (MakerUMnt makerUMnt in (ArrayList)makerList)
                {
                    //---------------------------------
                    // Key  ：メーカーコード
                    // Value：メーカー名称
                    //---------------------------------
                    _makerListStc.Add(makerUMnt.GoodsMakerCd, makerUMnt.MakerName);
                }
            }
            return status;
        }
        #endregion ReadMaker

        #region メーカー名称取得
        /// <summary>
        /// メーカー名称取得
        /// </summary>
        /// <remarks>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        /// <br>Note       : メーカー名称を取得します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public string GetMakerName(int goodsMakerCd)
        {
            string retStr = "";

            if ((_makerListStc != null) && (_makerListStc.ContainsKey(goodsMakerCd) == true))
            {
                retStr = _makerListStc[goodsMakerCd].ToString();
            }
            return retStr;
        }
        #endregion

        #endregion
        #endregion ◆ 帳票データ取得

        #region ◎ 取得データ展開処理
        #endregion ◆ データ展開処理

        #region ◆ 帳票設定データ取得
        #region ◎ 帳票出力設定取得処理
        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // データは読込済みか？
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "帳票出力設定の読込に失敗しました";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        #endregion ◆ 帳票設定データ取得

        /// <summary>
        /// 取得データ処理
        /// </summary>
        /// <param name="salesCprtCndtn">UI抽出条件クラス</param>
        /// <param name="resultWork">取得データ</param>
        /// <param name="connectInfoWork">接続情報</param>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// <br>Update Note: 2020/02/04 寺田 義啓</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>           :（修正内容一覧No.2）備考設定変更項目追加</br>
        /// </remarks>
        private int GetSalesHistoryData(SalesCprtCndtnWork salesCprtCndtn, ArrayList resultWork, SalCprtConnectInfoWork connectInfoWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            //売上抽出データ更新用
            _resultWorkClone = new ArrayList();

            foreach (SalesCprtWork salesCprtWork in resultWork)
            {
                //送信区分(0:手動;1:自動)
                if (salesCprtCndtn.SendDataDiv == 0)
                {
                    //売上抽出データにレコードが存在しない
                    if (salesCprtCndtn.PdfOutDiv == 0)
                    {
                        if ((salesCprtWork.SEAcptAnOdrStatus == 0
                            && string.IsNullOrEmpty(salesCprtWork.SEEnterpriseCode)
                            && salesCprtWork.SESalesCreateDateTime == 0
                            && string.IsNullOrEmpty(salesCprtWork.SESalesSlipNum)) ||
                            (salesCprtWork.SEAcptAnOdrStatus != 0
                            && salesCprtWork.SESalesCreateDateTime != salesCprtWork.SalesUpdateDateTime))
                        {
                            //↓ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
                            //ConvertSalesHistoryData(salesCprtWork);
                            ConvertSalesHistoryData(salesCprtWork, connectInfoWork);
                            //↑ UPD 2020/02/04 Y.Terada  修正内容一覧No.2

                            _resultWorkClone.Add(salesCprtWork);
                        }
                    }
                    //売上抽出データにレコードが存在する
                    else if (salesCprtCndtn.PdfOutDiv == 1)
                    {
                        if (salesCprtWork.SEAcptAnOdrStatus != 0
                            && !string.IsNullOrEmpty(salesCprtWork.SEEnterpriseCode)
                            && salesCprtWork.SESalesCreateDateTime == salesCprtWork.SalesUpdateDateTime
                            && !string.IsNullOrEmpty(salesCprtWork.SESalesSlipNum))
                        {
                            //↓ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
                            //ConvertSalesHistoryData(salesCprtWork);
                            ConvertSalesHistoryData(salesCprtWork, connectInfoWork);
                            //↑ UPD 2020/02/04 Y.Terada  修正内容一覧No.2

                            _resultWorkClone.Add(salesCprtWork);
                        }

                    }
                    //全て（売上抽出データに依存しない）
                    else
                    {
                        //↓ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
                        //ConvertSalesHistoryData(salesCprtWork);
                        ConvertSalesHistoryData(salesCprtWork, connectInfoWork);
                        //↑ UPD 2020/02/04 Y.Terada  修正内容一覧No.2

                        _resultWorkClone.Add(salesCprtWork);
                    }
                }
                else
                {
                    //↓ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
                    //ConvertSalesHistoryData(salesCprtWork);
                    ConvertSalesHistoryData(salesCprtWork, connectInfoWork);
                    //↑ UPD 2020/02/04 Y.Terada  修正内容一覧No.2

                    _resultWorkClone.Add(salesCprtWork);
                }
            }

            if (_resultWorkClone.Count == 0)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// 取得データConvert処理
        /// </summary>
        /// <param name="salesCprtWork">取得データ</param>
        /// <param name="connectInfoWork">接続情報</param>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// <br>Update Note: 2020/02/04 寺田 義啓</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>           :（修正内容一覧No.2）備考設定変更項目追加</br>
        /// <br>Update Note: 2020/09/15 3H 尹安</br>
        /// <br>管理番号   : 11670214-00</br>
        /// <br>           : 売上データ出力文字種拡張対応</br>
        /// </remarks>
        private void ConvertSalesHistoryData(SalesCprtWork salesCprtWork, SalCprtConnectInfoWork connectInfoWork)
        {
            DataRow dr = _salesHistoryDt.NewRow();

            //AB伝票№
            dr[PMSDC02014EA.ct_Col_SalesSlipNum] =salesCprtWork.SalesSlipNum;
            //元黒伝票番号
            dr[PMSDC02014EA.ct_Col_DebitNLnkSalesSlNum] = salesCprtWork.DebitNLnkSalesSlNum;
            //請求区分
            if (salesCprtWork.SalesSlipCd == 0)
            {
                dr[PMSDC02014EA.ct_Col_RequestDiv] = "010";
            }
            else if (salesCprtWork.SalesSlipCd == 1)
            {
                dr[PMSDC02014EA.ct_Col_RequestDiv] = "020";
            }

            //売上日
            dr[PMSDC02014EA.ct_Col_AddUpADate] = salesCprtWork.AddUpADate.ToString("yyyyMMdd");

            //純正優良区分
            int goodsMakerCd = salesCprtWork.GoodsMakerCd;
            dr[PMSDC02014EA.ct_Col_GoodDiv] = GetGoodDiv(goodsMakerCd);

            //AB売上率
            dr[PMSDC02014EA.ct_Col_AbSalesRate] = "0000";

            //行№
            dr[PMSDC02014EA.ct_Col_SalesRowNo] = DataNoSubStr(4, salesCprtWork.SalesRowNo.ToString("d4"));

            //管理№
            bool flag = GetBlEffective(salesCprtWork.CustomerCode);

            if (flag == true)
            {
                dr[PMSDC02014EA.ct_Col_AdministrationNo] = DataNoSubStr(4, salesCprtWork.PrtBLGoodsCode.ToString("d4"));
            }
            else
            {
                dr[PMSDC02014EA.ct_Col_AdministrationNo] = "0000";
            }

            //管理名称（品番）
            dr[PMSDC02014EA.ct_Col_GoodsNo] = GetCharFormat(salesCprtWork.GoodsNo);

            //品名
            // dr[PMSDC02014EA.ct_Col_GoodsNameKana] = DataNoSubStr(100,GetGoodsNameCharFormat(salesCprtWork.GoodsNameKana)); // 2020/09/15 3H 尹安 DEL
            dr[PMSDC02014EA.ct_Col_GoodsNameKana] = DataNoSubStr(100, GetGoodsNameCharFormat(salesCprtWork.GoodsNameKana, salesCprtWork.GoodsName)); // 2020/09/15 3H 尹安 ADD

            //BL商品ｺｰﾄﾞ 20191216ゼロサプレス依頼
            //dr[PMSDC02014EA.ct_Col_BLGoodsCode] = DataNoSubStr(5, salesCprtWork.BLGoodsCode.ToString("d5"));
            dr[PMSDC02014EA.ct_Col_BLGoodsCode] = DataNoSubStr(5, salesCprtWork.BLGoodsCode.ToString("G0"));

            //数量
            dr[PMSDC02014EA.ct_Col_ShipmentCnt] = GetShipmentCnt(salesCprtWork.ShipmentCnt);

            //納入単価
            dr[PMSDC02014EA.ct_Col_SalesUnPrcTaxExcFl] = salesCprtWork.SalesUnPrcTaxExcFl.ToString("0000000.00");

            //納入金額
            dr[PMSDC02014EA.ct_Col_SalesMoneyTaxExc] = GetNumFormat(salesCprtWork.SalesMoneyTaxExc);

            //PDF用納入金額
            dr[PMSDC02014EA.ct_Col_PdfSalesMoneyTaxExc] = GetNumRound(salesCprtWork.SalesMoneyTaxExc);

            //仕入金額
            dr[PMSDC02014EA.ct_Col_SupplierMoney] = GetNumFormat(salesCprtWork.SalesUnPrcTaxExcFl);

            //PDF用仕入金額
            dr[PMSDC02014EA.ct_Col_PdfSupplierMoney] = GetNumFormat(salesCprtWork.SalesUnPrcTaxExcFl);

            //売上金額
            dr[PMSDC02014EA.ct_Col_SalesMoney] = "00000000";

            //経費区分
            dr[PMSDC02014EA.ct_Col_ExpenseDivCd] = "0";

            //得意先ｺｰﾄﾞ
            dr[PMSDC02014EA.ct_Col_CustomerCode] = salesCprtWork.CustomerCode.ToString("d8");

            //ｱｯﾌﾟﾃﾞｰﾄＹＭＤ
            dr[PMSDC02014EA.ct_Col_SearchSlipDate] = salesCprtWork.SearchSlipDate.ToString("yyyyMMdd");

            //仕入先コード
            dr[PMSDC02014EA.ct_Col_SupplierCd] = salesCprtWork.SupplierCd.ToString("d8");

            //メーカーコード
            dr[PMSDC02014EA.ct_Col_GoodsMakerCd] = DataNoSubStr(4, salesCprtWork.GoodsMakerCd.ToString("d4"));

            //地区ｺｰﾄﾞ
            dr[PMSDC02014EA.ct_Col_AreaCd] = "0";

            //ＦＩＬＬＥＲ
            dr[PMSDC02014EA.ct_Col_Filler] = " ";

            //拠点コード
            dr[PMSDC02014EA.ct_Col_SectionCodeRF] = salesCprtWork.ResultsAddUpSecCd;

            // 拠点ガイド略称
            string sectionGuideSnm = "";
            if (string.IsNullOrEmpty(salesCprtWork.SectionGuideSnm))
            {
                sectionGuideSnm = "未登録";
            }
            else
            {
                sectionGuideSnm = salesCprtWork.SectionGuideSnm;
            }
            dr[PMSDC02014EA.ct_Col_SectionGuideSnm] = sectionGuideSnm;

            // 得意先略称
            string customerSnm = "";
            if (string.IsNullOrEmpty(salesCprtWork.CustomerSnm))
            {
                customerSnm = "未登録";
            }
            else
            {
                customerSnm = salesCprtWork.CustomerSnm;
            }
            dr[PMSDC02014EA.ct_Col_CustomerSnm] = customerSnm;

            // 伝票備考
            //↓ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
            //dr[PMSDC02014EA.ct_Col_SlipNote] = DataNoSubStr(30,salesCprtWork.SlipNote);
            long partySalesLipNum_lng = 0;
            string partySalesLipNum = string.Empty;
            if (long.TryParse(salesCprtWork.PartySalesLipNum, out partySalesLipNum_lng))
            {
                partySalesLipNum = partySalesLipNum_lng.ToString("G0");
            }
            else
            {
                partySalesLipNum = salesCprtWork.PartySalesLipNum;
            }

            if (connectInfoWork.Note1SetDiv == 1)
            {
                dr[PMSDC02014EA.ct_Col_SlipNote] = partySalesLipNum;
            }
            else if (connectInfoWork.Note1SetDiv == 2)
            {
                dr[PMSDC02014EA.ct_Col_SlipNote] = "";
            }
            else
            {
                dr[PMSDC02014EA.ct_Col_SlipNote] = DataNoSubStr(30, salesCprtWork.SlipNote);
            }
            //↑ UPD 2020/02/04 Y.Terada  修正内容一覧No.2

            // 伝票備考2
            //↓ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
            //dr[PMSDC02014EA.ct_Col_SlipNote2] = DataNoSubStr(30, salesCprtWork.SlipNote2);
            if (connectInfoWork.Note2SetDiv == 1)
            {
                dr[PMSDC02014EA.ct_Col_SlipNote2] = partySalesLipNum;
            }
            else if (connectInfoWork.Note2SetDiv == 2)
            {
                dr[PMSDC02014EA.ct_Col_SlipNote2] = "";
            }
            else
            {
                dr[PMSDC02014EA.ct_Col_SlipNote2] = DataNoSubStr(30, salesCprtWork.SlipNote2);
            }
            //↑ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
            
            // 伝票備考3
            //↓ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
            //dr[PMSDC02014EA.ct_Col_SlipNote3] = DataNoSubStr(30, salesCprtWork.SlipNote3);
            if (connectInfoWork.Note3SetDiv == 1)
            {
                dr[PMSDC02014EA.ct_Col_SlipNote3] = partySalesLipNum;
            }
            else if (connectInfoWork.Note3SetDiv == 2)
            {
                dr[PMSDC02014EA.ct_Col_SlipNote3] = "";
            }
            else
            {
                dr[PMSDC02014EA.ct_Col_SlipNote3] = DataNoSubStr(30, salesCprtWork.SlipNote3);
            }
            //↑ UPD 2020/02/04 Y.Terada  修正内容一覧No.2

            // 更新日時
            dr[PMSDC02014EA.ct_Col_UpDate] = Convert.ToInt64(salesCprtWork.UpdateDateTime.ToString("yyyyMMddHHmmss"));
            // 伝票区分
            dr[PMSDC02014EA.ct_Col_SalesSlipCd] = salesCprtWork.SalesSlipCd.ToString("d2");
            // メーカー名
            dr[PMSDC02014EA.ct_Col_MakerName] = DataNoSubStr(30, GetMakerName(salesCprtWork.GoodsMakerCd));

            _salesHistoryDt.Rows.Add(dr);
        }

        /// <summary>
        /// 下n桁の取得処理
        /// </summary>
        /// <param name="index">抽出条件</param>
        /// <param name="DataNo">伝票番号</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       :下n桁の取得処理を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string DataNoSubStr(int index, string DataNo)
        {
            string DataNum = DataNo;

            // 下n桁のみ：下からn桁のみを取得
            if (DataNo.Length > index)
            {
                DataNum = DataNo.Substring((DataNo.Length - index), index);
            }
            return DataNum;
        }

        /// <summary>
        /// 純正優良区分の取得処理
        /// </summary>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <returns>純正優良区分</returns>
        /// <remarks>
        /// <br>Note       : 純正優良区分の取得処理を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string GetGoodDiv(int goodsMakerCd)
        {
            string DataNum = ONE;

            if (goodsMakerCd > 0)
            {
                if ((1 <= goodsMakerCd) && (99 >= goodsMakerCd))
                {
                    DataNum = ONE;
                }
                else
                {
                    DataNum = TWO;
                }
            }

            return DataNum;
        }


        /// <summary>
        /// BL商品コードの印字有無の取得処理
        /// </summary>
        /// <param name="customerCode">BL商品コード</param>
        /// <returns>有無</returns>
        /// <remarks>
        /// <br>Note       : BL商品コードの印字有無の取得処理を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private bool GetBlEffective(int customerCode)
        {
            bool flag = false;
            SlipPrtSet slipPrtSet;
            SlipTypeController.SlipKind slipKind = SlipTypeController.SlipKind.SalesSlip;
            _slipTypeController.GetSlipType(slipKind, out slipPrtSet, _sectionCode, customerCode);

            if (ZERO.Equals(slipPrtSet.EachSlipTypeColPrt2.ToString()))
            {
                flag = false;
            }
            else if (ONE.Equals(slipPrtSet.EachSlipTypeColPrt2.ToString()))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 全角文字の取得処理
        /// </summary>
        /// <param name="data">品番</param>
        /// <returns>有無</returns>
        /// <remarks>
        /// <br>Note       : 全角文字の取得処理を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string GetCharFormat(string data)
        {
            string s;

            StringBuilder sb = new StringBuilder();

            if (!String.IsNullOrEmpty(data))
            {
                char[] datachar = data.ToCharArray();

                foreach (char c in datachar)
                {
                    if (2 * c.ToString().Length == Encoding.Default.GetByteCount(c.ToString()))
                    {
                        sb.Append(" ");
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
            }

            if (sb.ToString().Length > 16)
            {
                s = sb.ToString().Substring(0, 16);
            }
            else
            {
                s = sb.ToString();
            }

            return s;

        }

        // 2020/09/15 3H 尹安 DEL START >>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 全角文字の取得処理
        ///// </summary>
        ///// <param name="data">品名</param>
        ///// <returns>有無</returns>
        ///// <remarks>
        ///// <br>Note       : 全角文字の取得処理を行います。</br>
        ///// <br>Programmer : 田建委</br>
        ///// <br>Date       : 2019/12/02</br>
        ///// </remarks>
        //private string GetGoodsNameCharFormat(string data)
        //{
        //    string s;

        //    StringBuilder sb = new StringBuilder();

        //    if (!String.IsNullOrEmpty(data))
        //    {
        //        char[] datachar = data.ToCharArray();

        //        foreach (char c in datachar)
        //        {
        //            if (2 * c.ToString().Length == Encoding.Default.GetByteCount(c.ToString()))
        //            {
        //                sb.Append(" ");
        //            }
        //            else
        //            {
        //                sb.Append(c);
        //            }
        //        }
        //    }

        //    s = sb.ToString();

        //    return s;

        //}
        // 2020/09/15 3H 尹安 DEL END   <<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2020/09/15 3H 尹安 ADD START >>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 商品名称
        /// </summary>
        /// <param name="GoodsNameKana">商品名称カナ</param>
        /// <param name="GoodsName">商品名称</param>
        /// <returns>商品名称</returns>
        private string GetGoodsNameCharFormat(string GoodsNameKana, string GoodsName)
        {
            // 商品名称カナ未設定の場合、商品名称を出力
            if (String.IsNullOrEmpty(GoodsNameKana))
            {
                return GoodsName;
            }
            return GoodsNameKana;

        }
        // 2020/09/15 3H 尹安 ADD END   <<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 出荷数マイナス値の場合の取得処理
        /// </summary>
        /// <returns>有無</returns>
        /// <remarks>
        /// <br>Note       : 出荷数マイナス値の場合の取得処理を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string GetShipmentCnt(Double data)
        {
            string result;

            if (data < 0)
            {
                result = data.ToString("00000000.00");
            }
            else
            {
                result = data.ToString("000000000.00");
            }

            return result;
        }

        /// <summary>
        /// 小数点以下1桁で四捨五入、マイナス値の場合の取得処理
        /// </summary>
        /// <returns>有無</returns>
        /// <remarks>
        /// <br>Note       : 小数点以下1桁で四捨五入、マイナス値の場合の取得処理を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string GetNumFormat(Double data)
        {
            long numFormat;
            string result;
            FractionCalculate.FracCalcMoney(data, 1, 2, out numFormat);

            if (numFormat < 0)
            {
                if (numFormat.ToString().Length > 10)
                {
                    numFormat = Convert.ToInt64(DataNoSubStr(9, numFormat.ToString())) * (-1);

                    result = numFormat.ToString("d9");
                }
                else
                {
                    result = numFormat.ToString("d9");
                }
            }
            else
            {
                result = DataNoSubStr(10, numFormat.ToString("d10"));
            }

            return result;
        }

        /// <summary>
        /// 小数点以下1桁で四捨五入、マイナス値の場合の取得処理
        /// </summary>
        /// <returns>有無</returns>
        /// <remarks>
        /// <br>Note       : 小数点以下1桁で四捨五入、マイナス値の場合の取得処理を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string GetNumRound(Double data)
        {
            long numFormat;
            FractionCalculate.FracCalcMoney(data, 1, 2, out numFormat);

            return numFormat.ToString();
        }

        /// <summary>
        /// 得意先マスタ（伝票管理）リストの取得処理
        /// </summary>
        /// <returns>得意先マスタ（伝票管理）リスト</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（伝票管理）リストの取得処理を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private List<CustSlipMng> GetCustSlipMng(ArrayList inputList)
        {
            List<CustSlipMng> resulrList = new List<CustSlipMng>();

            foreach (CustSlipMng custSlipMng in inputList)
            {
                resulrList.Add(custSlipMng);
            }

            return resulrList;
        }

        /// <summary>
        /// 伝票印刷設定マスタリストの取得処理
        /// </summary>
        /// <returns>伝票印刷設定マスタリスト</returns>
        /// <remarks>
        /// <br>Note       : 伝票印刷設定マスタリストの取得処理を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private List<SlipPrtSet> GetSlipPrtSet(ArrayList inputList)
        {
            List<SlipPrtSet> resulrList = new List<SlipPrtSet>();

            foreach (SlipPrtSet slipPrtSet in inputList)
            {
                resulrList.Add(slipPrtSet);
            }

            return resulrList;
        }

        #region [自動送信]
        /// <summary>
        /// Webサーバと送受信します。
        /// </summary>
        /// <param name="salesCprtCndtn">条件</param>
        /// <param name="fileName">ファイル名</param>
        /// <param name="salCprtSndLogWork">送信ログ情報</param>
        /// <param name="logStatus">送信ログ登録ステータス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note	   : Webサーバと送受信します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>								
        /// </remarks>
        public int SendAndReceive(ref SalesCprtCndtnWork salesCprtCndtn, String fileName, out SalCprtSndLogListResultWork salCprtSndLogWork, out int logStatus) 
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL; 
            string xmlFileName = string.Empty;
            string logErrMsg = string.Empty;
            logStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            salCprtSndLogWork = new SalCprtSndLogListResultWork();

            if (fileName.Contains("."))
            {
                int index = fileName.LastIndexOf(".");
                xmlFileName = fileName.Substring(0, index) + ".XML";
            }
            else 
            {
                xmlFileName = fileName + ".XML";
            }

            SalCprtConnectInfoWork connectInfoWork = null;
            try
            {
                if (null == this._connectInfoWorkAcs)
                {
                    this._connectInfoWorkAcs = new SalCprtConnectInfoWorkAcs();
                }
                else
                {
                    //なし
                }
                status = this._connectInfoWorkAcs.Read(out connectInfoWork, salesCprtCndtn.EnterpriseCode, SUPPLIERCD, salesCprtCndtn.SectionCode, salesCprtCndtn.CustomerCode);
            }
            catch (Exception ex)
            {
                ex.ToString();
                status = -1;
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logErrMsg = LOGMSG_ERROR;
                //送信ログの登録
                logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, status, logErrMsg);
                return status;
            }

            if (connectInfoWork == null || status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                status = -1;
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logErrMsg = LOGMSG_ERROR;
                //送信ログの登録
                logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, status, logErrMsg);
                return status;
            }

            //String command = CommandOrganization(connectInfoWork, fileName);
            //if (string.IsNullOrEmpty(command) || command.Equals("<1.5.0"))
            //{
            //    status = -1;
            //    this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
            //    logErrMsg = LOGMSG_JAVAVERERR;
            //    //送信ログの登録
            //    logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, status, logErrMsg);
            //    return status;
            //}

            bool errFlag = false;
            string errMsg = string.Empty;
            int retryCnt = connectInfoWork.RetryCnt;
            status = Send(connectInfoWork, xmlFileName, salesCprtCndtn, ref salCprtSndLogWork, ref errFlag, ref errMsg, retryCnt);

            return status;
        }

        /// <summary>
        /// Webサーバに送信します。
        /// </summary>
        /// <param name="connectInfoWork">売上連携接続情報</param>
        /// <param name="fileName">ファイル名</param>
        /// <param name="salesCprtCndtn">条件</param>
        /// <param name="salCprtSndLogWork">送信ログ情報</param>
        /// <param name="errFlag">エラーフラグ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="retryCnt">リトライ回数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note	   : Webサーバに送信処理を行う</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private int Send(SalCprtConnectInfoWork connectInfoWork, String fileName, SalesCprtCndtnWork salesCprtCndtn, ref SalCprtSndLogListResultWork salCprtSndLogWork, ref bool errFlag, ref string errMsg, int retryCnt)
        {
            int status = -1;
            int logStatus = -1;
            string logErrMsg = string.Empty;
            string exErrMsg = string.Empty;
            string ret = string.Empty;
            try
            {
                SalesCprtAcsSendRequest sendRequest = new SalesCprtAcsSendRequest();
                ret = sendRequest.SendRequest(connectInfoWork, fileName, ref errFlag, ref errMsg, connectInfoWork.LoginTimeoutVal * 1000, retryCnt);

                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                if (errFlag)
                {
                    status = -1;
                }
                if (string.IsNullOrEmpty(ret))
                {
                    status = -1;
                    logErrMsg = LOGMSG_UNEXPECTEDERR;
                }
                else if (ret != "0")
                {
                    status = -1;
                    if ("10194062" == ret)
                    {
                        logErrMsg = LOGMSG_USERERR;
                    }
                    else if (ret == LOGMSG_TIMEOUTERR)
                    {
                        logErrMsg = LOGMSG_TIMEOUTERR;
                    }
                    else if (ret == "90101")
                    {
                        logErrMsg = CtWebSendError + LOGMSG_SENDADDERR + "90101)";
                        exErrMsg = CtWebSendError;
                    }
                    else if (ret == "90102")
                    {
                        logErrMsg = CtRequestError + LOGMSG_SENDADDERR + "90102)";
                        exErrMsg = CtRequestError;
                    }
                    else if (ret == "90103")
                    {
                        logErrMsg = CtWebError + LOGMSG_SENDADDERR + "90103)";
                        exErrMsg = CtWebError;
                    }
                    else if (ret == "90104")
                    {
                        logErrMsg = CtHeaderError + LOGMSG_SENDADDERR + "90104)";
                        exErrMsg = CtHeaderError;
                    }
                    else if (ret == "90105")
                    {
                        logErrMsg = CtWSSETokenError + LOGMSG_SENDADDERR + "90105)";
                        exErrMsg = CtWSSETokenError;
                    }
                    else if (ret == "90106")
                    {
                        logErrMsg = CtDigestError + LOGMSG_SENDADDERR + "90106)";
                        exErrMsg = CtDigestError;
                    }
                    else if (ret == "90107")
                    {
                        logErrMsg = CtResponseError + LOGMSG_SENDADDERR + "90107)";
                        exErrMsg = CtResponseError;
                    }
                    else if (ret == "90108")
                    {
                        logErrMsg = CtConnectError + LOGMSG_SENDADDERR + "90108)";
                        exErrMsg = CtConnectError;
                    }
                    else
                    {
                        logErrMsg = errMsg;
                    }
                }
                else
                {
                    status = 0;
                }

                // エラー内容をファイルで出力する
                if (status != 0)
                {
                    int intRet = 0;
                    if (int.TryParse(ret, out intRet))
                    {
                        LogWrite(intRet, exErrMsg, errMsg);
                    }
                }
            }
            catch (Exception exc)
            {
                exc.ToString();
                status = -1;
                //送信ログの登録
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logErrMsg = LOGMSG_UNEXPECTEDERR;
            }
            finally
            {
                if (retryCnt > 0)
                {
                    logErrMsg = logErrMsg + LOGMSG_RETRYCNT;
                }

                //送信ログの登録
                logStatus = WriteLogInfo(salesCprtCndtn, ref salCprtSndLogWork, status, logErrMsg);

                if (status == -1)
                {
                    if (retryCnt == 0)
                    {
                        ret = LOGMSG_TIMEOUTERR;
                    }
                    else
                    {
                        retryCnt = retryCnt - 1;
                        int waitTime = GetWaitTime();
                        Thread.Sleep(waitTime);
                        this._sendDateTimeStart = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                        status = Send(connectInfoWork, fileName, salesCprtCndtn, ref salCprtSndLogWork, ref errFlag, ref errMsg, retryCnt);
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// 待ち時間取得
        /// </summary>
        /// <returns>waitTime</returns>
        /// <remarks>
        /// <br>Note	   : 待ち時間を取得します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>			
        /// </remarks>
        public int GetWaitTime()
        {
            int waitTime = 5000;
            try
            {
                string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME);

                if (UserSettingController.ExistUserSetting(fileName))
                {
                    if (UiDataSet == null)
                    {
                        UiDataSet = new DataSet();
                    }
                    UiDataSet.ReadXml(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, fileName));
                    waitTime = Convert.ToInt32(UiDataSet.Tables["RetryWaitTimeInfo"].Rows[0][0]);
                }
            }
            catch
            {
                waitTime = 5000;
            }
            return waitTime;
        }

        /// <summary>
        /// 伝票枚数、明細数、売上合計の計算
        /// </summary>
        /// <remarks>
        /// <br>Note		: 伝票枚数、明細数、売上合計の計算を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>		
        /// </remarks>
        private void CalcuSalseInfo()
        {
            DataView printdataView;
            this._sendSlipCount = 0;
            this._sendSlipDtlCnt = 0;
            this._sendSlipTotalMny = 0;

            if (this._salesHistoryDt != null && this._salesHistoryDt.Rows.Count > 0)
            {
                //伝票枚数
                int slipCountSum = 0;
                //明細数
                int detailCount = 0;
                //売上合計
                long salesMoneySum = 0;

                //前回売上伝票番号
                string befSalesSlipNum = string.Empty;

                // DataView作成
                printdataView = new DataView(this._salesHistoryDt, string.Empty, GetSortOrder(), DataViewRowState.CurrentRows);

                for (int i = 0; i < printdataView.Count; i++)
                {
                    DataRowView detailView = (DataRowView)printdataView[i];

                    //伝票枚数
                    string salesSlipNum = detailView[PMSDC02014EA.ct_Col_SalesSlipNum].ToString();
                    if (!string.IsNullOrEmpty(salesSlipNum) && (!befSalesSlipNum.Equals(salesSlipNum)))
                    {
                        slipCountSum++;
                    }
                    befSalesSlipNum = salesSlipNum;

                    //明細数
                    detailCount++;

                    //売上合計
                    salesMoneySum += Convert.ToInt64(detailView[PMSDC02014EA.ct_Col_PdfSalesMoneyTaxExc]);
                }

                this._sendSlipCount = slipCountSum;
                this._sendSlipDtlCnt = detailCount;
                this._sendSlipTotalMny = salesMoneySum;
            }
        }

        /// <summary>
        /// 送信ログ情報の登録
        /// </summary>
        /// <param name="salesCprtCndtn">検索条件</param>
        /// <param name="salCprtSndLogWork">送信ログ情報</param>
        /// <param name="sendResult">送信の戻したステータス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: 送信ログ情報を登録します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>		
        /// </remarks>
        public int WriteLogInfo(SalesCprtCndtnWork salesCprtCndtn, ref SalCprtSndLogListResultWork salCprtSndLogWork, int sendResult, string errMsg)
        {
            int status = -1;

            //送信ログの作成
            salCprtSndLogWork = MakeLogInfo(salesCprtCndtn, sendResult, errMsg);
            object obj = salCprtSndLogWork;

            //送信ログの登録
            status = _iSalesCprtWorkDB.WriteLog(ref obj);
            salCprtSndLogWork = obj as SalCprtSndLogListResultWork;

            return status;
        }

        /// <summary>
        /// 送信ログ情報の作成
        /// </summary>
        /// <param name="salesCprtCndtn">検索条件</param>
        /// <param name="sendResult">送信の戻したステータス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>送信ログ情報</returns>
        /// <remarks>
        /// <br>Note		: 送信ログ情報を作成します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date        : 2019/12/02</br>		
        /// </remarks>
        private SalCprtSndLogListResultWork MakeLogInfo(SalesCprtCndtnWork salesCprtCndtn, int sendResult, string errMsg)
        {
            SalCprtSndLogListResultWork salCprtSndLogWork = new SalCprtSndLogListResultWork();
            // 企業コード
            salCprtSndLogWork.EnterpriseCode = this._enterpriseCode;
            // 論理削除区分
            salCprtSndLogWork.LogicalDeleteCode = 0;
            // 拠点コード
            salCprtSndLogWork.SectionCode = this._sectionCode;
            // 送信日時（開始）
            salCprtSndLogWork.SendDateTimeStart = this._sendDateTimeStart;
            // 送信日時（終了）
            salCprtSndLogWork.SendDateTimeEnd = this._sendDateTimeEnd;

            if (salesCprtCndtn.SendDataDiv == 0)
            {
                // 送信対象開始日付
                salCprtSndLogWork.SendObjDateStart = salesCprtCndtn.AddUpADateSt;
                // 送信対象終了日付
                salCprtSndLogWork.SendObjDateEnd = salesCprtCndtn.AddUpADateEd;
                // 自動送信区分
                salCprtSndLogWork.SAndEAutoSendDiv = 0;
                // 送信対象得意先（開始）
                salCprtSndLogWork.SendObjCustStart = salesCprtCndtn.CustomerCode;
                // 送信対象得意先（終了）
                salCprtSndLogWork.SendObjCustEnd = salesCprtCndtn.CustomerCode;
                // 送信対象区分
                salCprtSndLogWork.SendObjDiv = salesCprtCndtn.PdfOutDiv; 
            }
            else
            {
                // 送信対象開始日付
                salCprtSndLogWork.SendObjDateStart = salesCprtCndtn.SalesInfoTimeSt;
                // 送信対象終了日付
                salCprtSndLogWork.SendObjDateEnd = salesCprtCndtn.SalesInfoTimeEd;
                // 自動送信区分
                salCprtSndLogWork.SAndEAutoSendDiv = 1;
                // 送信対象得意先（開始）
                salCprtSndLogWork.SendObjCustStart = salesCprtCndtn.CustomerCode;
                // 送信対象得意先（終了）
                salCprtSndLogWork.SendObjCustEnd = salesCprtCndtn.CustomerCode;
                // 送信対象区分
                salCprtSndLogWork.SendObjDiv = salesCprtCndtn.AutoDataSendDiv;
            }


            if (sendResult == 0)
            {
                // 送信結果
                salCprtSndLogWork.SendResults = 0;
                // 送信エラー内容
                salCprtSndLogWork.SendErrorContents = string.Empty;
                // 送信伝票枚数
                salCprtSndLogWork.SendSlipCount = this._sendSlipCount;
                // 送信伝票明細数
                salCprtSndLogWork.SendSlipDtlCnt = this._sendSlipDtlCnt;
                // 送信伝票合計金額
                salCprtSndLogWork.SendSlipTotalMny = this._sendSlipTotalMny;
            }
            else
            {
                // 送信結果
                if (sendResult == 2) // 送信データなしの場合、ステータスは「2」で固定
                {
                    salCprtSndLogWork.SendResults = 2;
                }
                else
                {
                    salCprtSndLogWork.SendResults = 1;
                }
                // 送信エラー内容
                salCprtSndLogWork.SendErrorContents = errMsg;
                // 送信伝票枚数
                salCprtSndLogWork.SendSlipCount = 0;
                // 送信伝票明細数
                salCprtSndLogWork.SendSlipDtlCnt = 0;
                // 送信伝票合計金額
                salCprtSndLogWork.SendSlipTotalMny = 0;
            }

            return salCprtSndLogWork;
        }

        /// <summary>
        /// 送信データフィル名の処理します
        /// </summary>
        /// <param name="value">フィル名</param>
        /// <returns>送信データフィル名</returns>
        /// <remarks>
        /// <br>Note		: 送信データフィル名の処理します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date        : 2019/12/02</br>										
        /// </remarks>
        private String SetFileNm(String value)
        {
            if (String.IsNullOrEmpty(value))
                return "";
            if (value.Contains("."))
            {
                value = value.Substring(0, value.IndexOf('.'));
            }
            if (value.ToUpper().EndsWith(".TXT"))
            {
                return value;
            }
            else
            {
                return value + ".txt";
            }
        }

        /// <summary>
        /// コマンドオプションの処理します
        /// </summary>
        /// <param name="connectInfoWork">接続先情報</param>
        /// <param name="fileName">送信データフィル名</param>
        /// <returns>コマンド</returns>
        /// <remarks>
        /// <br>Note		: コマンドオプションの処理します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date        : 2019/12/02</br>		
        /// </remarks>
        private String CommandOrganization(SalCprtConnectInfoWork connectInfoWork, String fileName)
        {
            String userName = connectInfoWork.SendCcnctUserid.Trim();
            String password = connectInfoWork.SendCcnctPass.Trim();
            String fileId = connectInfoWork.CnectFileId.Trim();
            String mode = "S";
            String logLevel = "2";
            int templength = fileName.Length;
            int tempof = fileName.LastIndexOf("\\");
            String dataName =SetFileNm( fileName.Substring(fileName.LastIndexOf("\\")+1 , (fileName.Length -1)- fileName.LastIndexOf("\\")));
            string httpHead = "";
            //HTTP/HTTPS プロトコル  
            httpHead = "https://";
            String connectURL = httpHead + connectInfoWork.CprtUrl;
            String dataPath = System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.PRTOUT);

            String logName = GetLogName();
            bool verFlag = false;
            string errMsg = string.Empty; 
            String command = "";
            String version = RunCmd("java -version", ref verFlag, 0, errMsg, 2000, 0); 
            if (!verFlag)
            {
                if (String.CompareOrdinal(version, "\"1.5.0\"") >= 0)
                {
                    command = "Java dtrcmd";
                }
                else
                {
                    command = "<1.5.0";
                    return command;
                }

                command = "Java -cp dtrcmd.jar dtrcmd";
            }
            else
            {
                return command;
            }
            command = command + " -u " + ExchangeString(userName)
                              + " -p " + ExchangeString(password)
                              + " -m " + ExchangeString(mode)
                              + " -f " + ExchangeString(fileId)
                              + " -c " + ExchangeString(connectURL)
                              + " -d " + ExchangeString(dataPath + "\\" + dataName)
                              + " -o " + ExchangeString(logName)
                              + " -v " + ExchangeString(logLevel);
            return command;
             
        }

        /// <summary>
        /// DOS Command文字の転換
        /// </summary>
        /// <param name="inputStr">文字</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: コマンドオプションの処理します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date        : 2019/12/02</br>		
        /// </remarks>
        private string ExchangeString(string inputStr)
        {
            string str = string.Empty;
            str = inputStr.Replace("\"", "\"\"\"");
            str = "\"" + str + "\"";

            return str;
        }

        /// <summary>
        /// コマンドを実行します。
        /// </summary>
        /// <param name="command">コマンド</param>
        /// <param name="errFlag">エラーフラグ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: コマンドを実行します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date        : 2019/12/02</br>										
        /// </remarks>
        private String RunCmd(String command,ref bool errFlag) 
        {
            string ret = null;
            string err = null;
            string otp = null;
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            try
            {
                p.Start();
                p.StandardInput.WriteLine(command);
                p.StandardInput.WriteLine("exit");
                otp = p.StandardOutput.ReadToEnd();
                err = p.StandardError.ReadToEnd();
                if (null == err || String.IsNullOrEmpty(err))
                {
                    errFlag = false;
                    string[] arr = Regex.Split(otp, "\r\n");
                    bool flg = false;
                    foreach (string str in arr)
                    {
                        if (flg)
                        {
                            if (!string.IsNullOrEmpty(str))
                            {
                                ret = str;
                                break;
                            }
                        }
                        if (str.Contains("Java dtrcmd14"))
                        {
                            flg = true;
                        }
                    }
                }
                else 
                {
                    errFlag = true;
                    ret = err;
                }
            }
            catch(Exception e) 
            {
                e.ToString();
            }
            finally 
            {
                if (p != null) p.Close();
            }
            return ret;
        }

        /// <summary>
        /// コマンドを実行します。
        /// </summary>
        /// <param name="command">コマンド</param>
        /// <param name="errFlag">エラーフラグ</param>
        /// <param name="mode">モード</param>
        /// <param name="errMsg">エラーステータス</param>
        /// <param name="timeout">タイムアウト</param>
        /// <param name="retryCnt">リトライ回数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: コマンドを実行します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date        : 2019/12/02</br>
        /// </remarks>
        private String RunCmd(String command, ref bool errFlag, int mode, string errMsg, int timeout, int retryCnt) 
        {
            string ret = errMsg; 
            string err = null;
            string otp = null;

            if (retryCnt == -1)
            {
                ret = LOGMSG_TIMEOUTERR;
                return ret;
            }

            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            try
            {
                if (mode == 0)
                {
                    p.Start();
                    p.StandardInput.WriteLine(command);
                    p.StandardInput.WriteLine("exit");
                    err = p.StandardError.ReadToEnd();
                    if (!String.IsNullOrEmpty(err))
                    {
                        errFlag = false;
                        string[] arr = Regex.Split(err, "\r\n");
                        foreach (string str in arr)
                        {
                            if (str.Contains("java version"))
                            {
                                ret = str.Substring(13);
                                break;
                            }
                        }
                    }
                    else
                    {
                        errFlag = true;
                        ret = err;
                    }
                }
                else if (mode == 1)
                {
                    p.Start();
                    p.StandardInput.WriteLine(command);
                    p.StandardInput.WriteLine("exit");
                    otp = p.StandardOutput.ReadToEnd();
                    err = p.StandardError.ReadToEnd();
                    if (null == err || String.IsNullOrEmpty(err))
                    {
                        errFlag = false;
                        string[] arr = Regex.Split(otp, "\r\n");
                        foreach (string str in arr)
                        {
                            if (str.Contains("returncode="))
                            {
                                ret = str.Substring(str.IndexOf("returncode=") + 11);
                                break;
                            }
                        }
                    }
                    else
                    {
                        errFlag = true;
                        ret = err;
                    }
                }

                if (timeout != 0 && !p.WaitForExit(timeout))
                {
                    p.Kill();

                    retryCnt = retryCnt - 1;
                    RunCmd(command, ref errFlag, mode, ret, timeout, retryCnt);
                }
            }
            catch (Exception e)
            {
                e.ToString();
                errFlag = true;
                ret = string.Empty;
            }
            finally
            {
                if (p != null) p.Close();
            }
            return ret;
        }

        /// <summary>
        /// ログファイル名
        /// </summary>
        /// <returns>ログファイル名</returns>
        /// <remarks>
        /// <br>Note		: ログファイル名</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date        : 2019/12/02</br>								
        /// </remarks>
        private String GetLogName()
        {
            string workDir;
            // ﾚｼﾞｽﾄﾘｷｰ取得
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Product\Partsman");
            if (null == key)
            {
                workDir = @"C:\SFNETASM";
            }
            else
            {
                workDir = key.GetValue("InstallDirectory", @"C:\SFNETASM").ToString();
            }
            //フォーだあるのかの判断
            string folderPath = workDir + "\\LOG\\";
            if (!Directory.Exists(folderPath))
            {
                DirectoryInfo di = Directory.CreateDirectory(folderPath);
                DirectoryInfo dis = di.CreateSubdirectory("SAndESend\\");
            }
            else
            {

                if (!Directory.Exists(folderPath + "SAndESend\\"))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folderPath + "SAndESend\\");
                }
            }

            String ret = folderPath + "SAndESend\\";
            ret += DateTime.Now.ToString("yyyyMMdd") + ".log";
            return ret;
        }

        /// <summary>
        /// 回線オープン処理
        /// </summary>
        /// <param name="connectInfo">条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 回線オープン処理します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date        : 2019/12/02</br>									
        /// </remarks>
        private bool RequestOpen(ConnectInfoWork connectInfo)
        {
            bool isConnected;
            int flags;
            isConnected = InternetGetConnectedState(out flags, 0);

            if (InternetAttemptConnect(0) != ERROR_SUCCESS || isConnected == false)
            {
                // 回線おオーペンエラー
                return false;
            }
            string httpHead = "";

            //HTTP/HTTPS プロトコル  
            if (connectInfo.DaihatsuOrdreDiv == 0)
            {
                httpHead = "http://";
            }
            else
            {
                httpHead = "https://";
            }
            //接続先情報マスタの発注手配区分（ダイハツ）＋接続先情報マスタの発注URL＋接続先情報マスタの在庫確認URL
            request = (HttpWebRequest)HttpWebRequest.Create(httpHead + connectInfo.OrderUrl + connectInfo.StockCheckUrl);
            request.Method = "POST";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.0.3705; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            return true;
        }

        /// <summary>
        /// 送信電文データをWebサービス用パラメータに変換する
        /// </summary>
        /// <param name="connectInfo">条件</param>
        /// <param name="fileName">ファイル名</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 送信電文データをWebサービス用パラメータに変換します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date        : 2019/12/02</br>									
        /// </remarks>
        private string ConvertUoeSndHedToXML(ConnectInfoWork connectInfo, string fileName)
        {
            // ヘッダ情報追加
            HeaderMake(connectInfo);
            string xmlFileString = "";
            xmlFileString = fileChange(fileName);

            return xmlFileString;
        }

        /// <summary>
        /// ヘッダ情報追加
        /// </summary>
        /// <param name="connectInfo">条件</param>
        /// <remarks>
        /// <br>Note		: ヘッダ情報追加します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date        : 2019/12/02</br>								
        /// </remarks>
        private void HeaderMake(ConnectInfoWork connectInfo)
        {
            request.Accept = "*/*";
            request.Headers.Add("Accept-Language" , "ja");
            //WSSE認証用の文字列を作る
            string wsse = CreateWSSEToken(connectInfo.ConnectUserId, connectInfo.ConnectPassword);

            request.Headers.Add("X-WSSE:"+wsse);

            request.ContentType = "multipart/form-data; boundary=" + STRING_BOUNDARY.Substring(2);
            request.KeepAlive = true;
            //接続先情報マスタのログインタイムアウト
            if (connectInfo.LoginTimeoutVal != 0)
            {
                request.Timeout = connectInfo.LoginTimeoutVal * 1000;
            }
        }

        /// <summary>
        /// 認証用摘要をを生成します。
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 認証用摘要をを生成します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date        : 2019/12/02</br>							
        /// </remarks>
        private string CreateWSSEToken(string userName, string password)
        {
            StringBuilder wsseToken = new StringBuilder();
            string nonce = CreateNonce();
            string created = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffffZ");
            string passwordDigest = Convert.ToBase64String(Encoding.UTF8.GetBytes(GetDigest(String.Format("{0}{1}{2}", nonce, created, password))));

            //Username Tokenの文字列を生成する 
            wsseToken.Append("UsernameToken ");
            wsseToken.AppendFormat("Username=\"{0}\", ", userName);
            wsseToken.AppendFormat("PasswordDigest=\"{0}\", ", passwordDigest);
            wsseToken.AppendFormat("Nonce=\"{0}\", ", nonce);
            wsseToken.AppendFormat("Created=\"{0}\" ", created);

            return wsseToken.ToString();
        }

        /// <summary>
        /// Nonceを生成します。
        /// Nonceは精度の高い擬似乱数生成器を利用してください。
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: Nonceは精度の高い擬似乱数生成します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date        : 2019/12/02</br>								
        /// </remarks>
        private string CreateNonce()
        {
            Random r = new Random();
            double d1 = r.NextDouble();
            double d2 = d1 * d1;
            return GetDigest(d2.ToString());
        }

        /// <summary>
        /// 16進数表記のSHA-1メッセージダイジェストを生成します。
        /// </summary>
        /// <param name="source">source</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 16進数表記のSHA-1メッセージダイジェストを生成します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date        : 2019/12/02</br>							
        /// </remarks>
        private string GetDigest(string source)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            StringBuilder answer = new StringBuilder();
            foreach (Byte b in sha1.ComputeHash(Encoding.UTF8.GetBytes(source)))
            {
                if (b < 16)
                {
                    answer.Append("0");
                }
                answer.Append(Convert.ToString(b, 16));
            }
            return answer.ToString();
        }

        /// <summary>
        /// ファイルを変更
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: ファイルを変更します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date        : 2019/12/02</br>								
        /// </remarks>
        private string fileChange(string fileName)
        {
            //ファイルへ送信
            string fileString = "";
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                byte[] byDate = new byte[file.Length];
                char[] charDate = new char[file.Length];
                file.Read(byDate, 0, (int)file.Length);
                Decoder d = Encoding.UTF8.GetDecoder();
                d.GetChars(byDate, 0, byDate.Length, charDate, 0);
                for (int i = 0; i < charDate.Length; i++)
                {
                    fileString = fileString + charDate[i];
                }
                file.Close();
            }
            catch (Exception)
            {
                fileString = "";
            }
            return fileString;
        }

        #endregion
        #region
        /// <summary>
        /// ログ出力処理
        /// </summary>
        /// <param name="intRet"></param>
        /// <param name="exErrMsg"></param>
        /// <param name="pMsg"></param>
        /// <remarks>
        /// <br>Note       :ログ出力処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private void LogWrite(int intRet, string exErrMsg, string pMsg)
        {
            System.IO.FileStream _fs;										// ファイルストリーム
            System.IO.StreamWriter _sw;										// ストリームwriter
            DateTime edt = DateTime.Now;
            try
            {
                // Logフォルダー
                string logFolderPath = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "Log"), CtPGID);
                if (!Directory.Exists(logFolderPath))
                {
                    // Logフォルダーが存在しない場合、作成する
                    Directory.CreateDirectory(logFolderPath);
                }

                string fileName = _posTerminalMg.CashRegisterNo + "_" + edt.ToString("yyyyMMdd") + ".Log";
                // ログファイル
                string logFilePath = Path.Combine(logFolderPath, fileName);
                _fs = new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.Write);
                _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
                //yyyy/MM/dd hh:mm:ss
                _sw.WriteLine(string.Format("{0,-19} {1,-5}　{2}　{3}　{4}", edt, edt.Millisecond, intRet, exErrMsg, pMsg));
                if (_sw != null)
                    _sw.Close();
                if (_fs != null)
                    _fs.Close();
            }
            catch (Exception)
            {
            }
        }
         #endregion 

        # region [端末設定取得]
        /// <summary>
        /// 端末設定取得処理
        /// </summary>
        /// <param name="posTerminalMg">POS端末管理設定</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 端末設定取得処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private int GetPosTerminalMg(out PosTerminalMg posTerminalMg, string enterpriseCode)
        {
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            return acs.Search(out posTerminalMg, enterpriseCode);
        }
        #endregion
        #endregion ■ Private Method
    }
}
