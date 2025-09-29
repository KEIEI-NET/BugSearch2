//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : S&E売上データテキスト出力
// プログラム概要   : S&E売上データテキスト出力帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/08/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh
// 修 正 日  2012/12/07  修正内容 : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh
// 作 成 日  2013/02/25  修正内容 : Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh
// 作 成 日  2013/03/06  修正内容 : Ｓ＆Ｅ(AB) テキスト出力自動送信の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh
// 作 成 日  2013/05/21  修正内容 : Ｓ＆Ｅ(AB) テキスト出力自動送信Javaツールを利用する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh
// 作 成 日  2013/06/24  修正内容 : Redmine#37017 S&Eブレーキ送信コマンド
//----------------------------------------------------------------------------//
// 管理番号 10901034-00  作成担当 : 田建委  
// 修 正 日  2013/06/26  修正内容 : 自動送信処理の追加及び送信ログの登録
//----------------------------------------------------------------------------//
// 管理番号 10901034-00  作成担当 : 田建委  
// 修 正 日  2013/07/25  修正内容 : Redmine#39145 エラー発生時もS&E売上抽出データ更新した場合がある対応
//----------------------------------------------------------------------------//
// 管理番号 10901034-00  作成担当 : 田建委  
// 修 正 日  2013/08/07  修正内容 : Redmine#39695 抽出結果無時の結果画面表示の変更対応
//----------------------------------------------------------------------------//
// 管理番号 10901034-00  作成担当 : 田建委  
// 修 正 日  2013/08/12  修正内容 : Redmine#39695 抽出結果無時のログ内容の変更対応
//----------------------------------------------------------------------------//
// 管理番号 11670121-00  作成担当 : 石崎  
// 修 正 日  2020/02/26  修正内容 : S&E改良対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
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
// ----- ADD zhuhh 2013/03/06 for Redmine#35011 ----->>>>>
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Win32;
// ----- ADD zhuhh 2013/03/06 for Redmine#35011 -----<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上データテキスト出力 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 売上データテキスト出力で使用するデータを取得する。</br>
    /// <br>Programmer	: 張凱</br>
    /// <br>Date		: 2009.08.13</br>
    /// <br>UpdateNote  : 2012/12/07 zhuhh</br>
    /// <br>            : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修</br>
    /// <br>UpdateNote  : 2013/02/25 zhuhh</br>
    /// <br>            : Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更</br>
    /// <br>UpdateNote  : 2013/05/21 zhuhh</br>
    /// <br>            : 自動送信Javaツールを利用する</br>
    /// <br>UpdateNote  : 2013/06/24 zhuhh</br>
    /// <br>            : S&Eブレーキ送信コマンド</br>
    /// <br>UpdateNote  : 2013/06/26 田建委</br>
    /// <br>            : 自動送信処理の追加及び送信ログの登録</br>
    /// <br>UpdateNote  : 2013/07/25 田建委</br>
    /// <br>            : Redmine#39145 エラー発生時もS&E売上抽出データ更新した場合がある対応</br>
    /// <br>UpdateNote  : 2013/08/07 田建委</br>
    /// <br>            : Redmine#39695 抽出結果無時の結果画面表示の変更対応</br>
    /// <br>UpdateNote  : 2013/08/12 田建委</br>
    /// <br>            : Redmine#39695 抽出結果無時のログ内容の変更対応</br>
    /// <br>UpdateNote  : 2020/02/26 石崎</br>
    /// <br>            : Ｓ＆Ｅ改良対応</br>
    /// </remarks>
    public class SalesHistoryAcs
    {
        #region ■ Constructor
        /// <summary>
        /// 売上データテキスト出力アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上データテキスト出力アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        public SalesHistoryAcs()
        {
            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ログイン拠点を取得
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._iSalesHistoryJoinWorkDB = (ISalesHistoryJoinWorkDB)MediationSalesHistoryJoinResultDB.GetSalesHistoryJoinWorkDB();

            //伝票印刷設定マスタリストの取得
            _slipPrtSetAcs = new SlipPrtSetAcs();

            _custSlipMngAcs = new CustSlipMngAcs();

            _slipTypeController = new SlipTypeController();


            // ----- ADD 石崎 2020/02/26 ----->>>>>
            //メーカー・品番AB商品コード変換マスタの取得
            _MakerGoodsCodeSetAcs = new MakerGoodsCodeSetAcs();
            // ----- ADD 石崎 2020/02/26 -----<<<<<


            //伝票印刷設定マスタリスト
            ArrayList slipPrtSetList;

            _slipPrtSetAcs.SearchSlipPrtSet(out slipPrtSetList, this._enterpriseCode);

            //得意先マスタ（伝票管理）リスト
            int totalCount;
            _custSlipMngAcs.SearchOnlyCustSlipMng(out totalCount, this._enterpriseCode);

            _slipTypeController.EnterpriseCode = this._enterpriseCode;
            _slipTypeController.SlipPrtSetList = GetSlipPrtSet(slipPrtSetList);
            _slipTypeController.CustSlipMngList = GetCustSlipMng(_custSlipMngAcs.CustSlipMngList);
        }

        /// <summary>
        /// 売上データテキスト出力アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上データテキスト出力アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        static SalesHistoryAcs()
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

        // ----- ADD zhuhh 2013/03/06 for Redmine#35011----->>>>>
        #region API定義
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);

        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int InternetAttemptConnect(int dwReserved);
        #endregion
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011-----<<<<<
        #endregion ■ Static Member

        #region ■ Private Member
        ISalesHistoryJoinWorkDB _iSalesHistoryJoinWorkDB;

        private ArrayList codeList = new ArrayList();
        private ArrayList dataList = new ArrayList();
        private Hashtable _sectionCdTable = new Hashtable();

        private DataTable _salesHistoryDt;			// 印刷DataTable

        private const string ZERO = "0";
        private const string ONE = "1";
        private const string TWO = "2";
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011----->>>>>
        private const string STRING_BOUNDARY = "-----------------------------7d21cef303f8";
        private const string STRING_CHANGE_ROW = "\r\n";
        private const int ERROR_SUCCESS = 0;
        //固定の仕入先「913011」
        //private const int SUPPLIERCD = 913011;// DEL 田建委 2013/06/26
        private const int SUPPLIERCD = 0; // ADD 田建委 2013/06/26
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011-----<<<<<

        // ----- ADD 田建委 2013/06/26 ----->>>>>
        /// <summary>ログメッセージ：送信対象データ無し</summary>
        //private const string LOGMSG_NODATA = "送信対象データ無し"; // DEL 田建委 2013/08/07 Redmine#39695
        private const string LOGMSG_NODATA = "該当するデータはありません"; // ADD 田建委 2013/08/07 Redmine#39695
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
        // --- ADD 田建委 2013/07/25 --->>>>>
        /// <summary>ログメッセージ：予想外のエラー</summary>
        private const string LOGMSG_UNEXPECTEDERR = "予期せぬ例外が発生しました。(Code:-999)";
        // --- ADD 田建委 2013/07/25 ---<<<<<

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
        // ----- ADD 田建委 2013/06/26 -----<<<<<

        private SlipPrtSetAcs _slipPrtSetAcs = null;

        private CustSlipMngAcs _custSlipMngAcs = null;

        private SlipTypeController _slipTypeController = null;

        private ArrayList _resultWorkClone;

        // ----- ADD zhuhh 2013/03/06 for Redmine#35011 ----->>>>>
        //接続情報マスタ
        private ConnectInfoWorkAcs _connectInfoWorkAcs = null;
        private HttpWebRequest request = null;
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011 -----<<<<<
        // ----- ADD 石崎 2020/02/26 ----->>>>>
        //メーカー・品番AB商品コード変換マスタの取得
        private MakerGoodsCodeSetAcs _MakerGoodsCodeSetAcs = null;
        // ----- ADD 石崎 2020/02/26 -----<<<<<

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
        /// <param name="salesHistoryCndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        public int SearchSalesHistoryProcMain(SalesHistoryCndtn salesHistoryCndtn, out string errMsg)
        {
            return this.SearchSalesHistoryProc(salesHistoryCndtn, out errMsg);
        }

        /// <summary>
        /// 印刷データ抽出処理
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
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
                PMSAE02014EA.CreatePrintDataTable(ref printdataTable);

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
                        || (!befSectionCode.Equals(dataRowView[PMSAE02014EA.ct_Col_SectionCodeRF])
                        || (!befCustomerCode.Equals(dataRowView[PMSAE02014EA.ct_Col_CustomerCode]))))
                    {
                        if (string.IsNullOrEmpty(befSectionCode) && string.IsNullOrEmpty(befCustomerCode))
                        {
                            temp.Add(dataRowView);
                        }

                        if ((!string.IsNullOrEmpty(befSectionCode) && (!string.IsNullOrEmpty(befCustomerCode)))
                            && (!befSectionCode.Equals(dataRowView[PMSAE02014EA.ct_Col_SectionCodeRF])
                        || (!befCustomerCode.Equals(dataRowView[PMSAE02014EA.ct_Col_CustomerCode]))))
                        {
                            tempList.Add(temp);

                            temp = new List<DataRowView>();

                            temp.Add(dataRowView);
                        }
                        else if ((!string.IsNullOrEmpty(befSectionCode)) && (!string.IsNullOrEmpty(befCustomerCode)))
                        {
                            temp.Add(dataRowView);
                        }

                        befSectionCode = dataRowView[PMSAE02014EA.ct_Col_SectionCodeRF].ToString();

                        befCustomerCode = dataRowView[PMSAE02014EA.ct_Col_CustomerCode].ToString();

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

                    //行数（純正）
                    int pureCount = 0;
                    //売上金額（純正）
                    long pureSalesMoneyTaxExc = 0;
                    //仕切金額（純正）
                    long pureSupplierMoney = 0;
                    //行数（優良）
                    int priCount = 0;
                    //売上金額（優良）
                    long priSalesMoneyTaxExc = 0;
                    //仕切金額（優良）
                    long priSupplierMoney = 0;

                    for (int j = 0; j < detailList.Count; j++)
                    {
                        DataRowView detailView = (DataRowView)detailList[j];

                        //伝票枚数
                        string salesSlipNum = detailView[PMSAE02014EA.ct_Col_SalesSlipNum].ToString();
                        if (!string.IsNullOrEmpty(salesSlipNum) && (!befSalesSlipNum.Equals(salesSlipNum)))
                        {
                            slipCountSum++;
                        }
                        befSalesSlipNum = salesSlipNum;

                        //売上合計
                        salesMoneySum += Convert.ToInt64(detailView[PMSAE02014EA.ct_Col_PdfSalesMoneyTaxExc]);

                        //値引予定額
                        long salesMoneyDetail = Convert.ToInt64(detailView[PMSAE02014EA.ct_Col_PdfSalesMoneyTaxExc]);
                        long supplierMoneyDetail = Convert.ToInt64(detailView[PMSAE02014EA.ct_Col_PdfSupplierMoney]);
                        salesSupplierMoneySum += (salesMoneyDetail - supplierMoneyDetail);

                        //（純正）
                        if (ONE.Equals(detailView[PMSAE02014EA.ct_Col_GoodDiv].ToString()))
                        {
                            //行数（純正）
                            pureCount++;
                            //売上金額（純正）
                            pureSalesMoneyTaxExc += Convert.ToInt64(detailView[PMSAE02014EA.ct_Col_PdfSalesMoneyTaxExc]);
                            //仕切金額（純正）
                            pureSupplierMoney += Convert.ToInt64(detailView[PMSAE02014EA.ct_Col_PdfSupplierMoney]);
                        }

                        //（優良）
                        if (TWO.Equals(detailView[PMSAE02014EA.ct_Col_GoodDiv].ToString()))
                        {
                            //行数（優良）
                            priCount++;
                            //売上金額（優良）
                            priSalesMoneyTaxExc += Convert.ToInt64(detailView[PMSAE02014EA.ct_Col_PdfSalesMoneyTaxExc]);
                            //仕切金額（優良）
                            priSupplierMoney += Convert.ToInt64(detailView[PMSAE02014EA.ct_Col_PdfSupplierMoney]);
                        }
                    }

                    dr[PMSAE02014EA.ct_Col_CustomerCode] = detailList[0][PMSAE02014EA.ct_Col_CustomerCode];
                    dr[PMSAE02014EA.ct_Col_PureDefferent] = (pureSalesMoneyTaxExc - pureSupplierMoney);
                    dr[PMSAE02014EA.ct_Col_PriDefferent] = (priSalesMoneyTaxExc - priSupplierMoney); ;
                    dr[PMSAE02014EA.ct_Col_SectionCodeRF] = detailList[0][PMSAE02014EA.ct_Col_SectionCodeRF];
                    dr[PMSAE02014EA.ct_Col_SectionGuideSnm] = detailList[0][PMSAE02014EA.ct_Col_SectionGuideSnm];
                    dr[PMSAE02014EA.ct_Col_CustomerSnm] = detailList[0][PMSAE02014EA.ct_Col_CustomerSnm];
                    dr[PMSAE02014EA.ct_Col_SlipCountSum] = slipCountSum.ToString();
                    dr[PMSAE02014EA.ct_Col_SalesMoneySum] = salesMoneySum.ToString();
                    dr[PMSAE02014EA.ct_Col_SalesSupplierMoneySum] = salesSupplierMoneySum.ToString();
                    dr[PMSAE02014EA.ct_Col_PureCount] = pureCount.ToString();
                    dr[PMSAE02014EA.ct_Col_PureSalesMoneyTaxExc] = pureSalesMoneyTaxExc.ToString();
                    dr[PMSAE02014EA.ct_Col_PureSupplierMoney] = pureSupplierMoney.ToString();
                    dr[PMSAE02014EA.ct_Col_PriCount] = priCount.ToString();
                    dr[PMSAE02014EA.ct_Col_PriSalesMoneyTaxExc] = priSalesMoneyTaxExc.ToString();
                    dr[PMSAE02014EA.ct_Col_PriSupplierMoney] = priSupplierMoney.ToString();

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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
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
        /// <param name="salesHistoryCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// <br>UpdateNote : 2013/06/26 田建委</br>
        /// <br>           : 自動送信処理の追加及び送信ログの登録</br>
        /// <br>UpdateNote : 2013/08/12 田建委</br>
        /// <br>           : Redmine#39695 抽出結果無時のログ内容の変更対応</br>
        /// </remarks>
        private int SearchSalesHistoryProc(SalesHistoryCndtn salesHistoryCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            //----- ADD 田建委 2013/06/26 ----------------->>>>>
            this._sendDateTimeStart = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // 送信日時（開始）
            //int logStatus = (int)ConstantManagement.MethodResult.ctFNC_NORMAL; // DEL 田建委 2013/07/25
            int logStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL; // ADD 田建委 2013/07/25
            SAndESalSndLogListResultWork sAndESalSndLogWork = new SAndESalSndLogListResultWork();
            //----- ADD 田建委 2013/06/26 -----------------<<<<<

            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMSAE02014EA.CreateDataTable(ref this._salesHistoryDt);

                // 抽出条件展開  --------------------------------------------------------------
                SalesHistoryCndtnWork salesHistoryCndtnWork = new SalesHistoryCndtnWork();
                status = this.DevSalesHistory(salesHistoryCndtn, out salesHistoryCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object salesHistoryResultWork = null;
                status = _iSalesHistoryJoinWorkDB.Search(out salesHistoryResultWork, (object)salesHistoryCndtnWork);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        ArrayList salesHistoryResultList = salesHistoryResultWork as ArrayList;

                        //データのConvert処理
                        status  = GetSalesHistoryData(salesHistoryCndtn, salesHistoryResultList);

                        // 伝票枚数、明細枚数、合計金額の計算
                        CalcuSalseInfo(); // ADD 田建委 2013/06/26

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                        {
                            errMsg = "該当するデータがありません。";
                            // ----- ADD 田建委 2013/06/26 ----->>>>>
                            // 手動送信（売上テキスト出力から）の場合、且つ、自動送信区分が「する」
                            // あるいは自動送信の場合、送信ログを登録
                            if ((salesHistoryCndtn.SendDataDiv == 0 && salesHistoryCndtn.AutoDataSendDiv == 0) || salesHistoryCndtn.SendDataDiv == 1)
                            {
                                //送信ログの登録
                                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // 送信日時（終了）
                                //logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_NODATA); // DEL 田建委 2013/08/12 Redmine#39695
                                logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, 2, LOGMSG_NODATA); // ADD 田建委 2013/08/12 Redmine#39695
                            }
                            // ----- ADD 田建委 2013/06/26 -----<<<<<
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        errMsg = "該当するデータがありません。";
                        // ----- ADD 田建委 2013/06/26 ----->>>>>
                        // 手動送信（売上テキスト出力から）の場合、且つ、自動送信区分が「する」
                        // あるいは自動送信の場合、送信ログを登録
                        if ((salesHistoryCndtn.SendDataDiv == 0 && salesHistoryCndtn.AutoDataSendDiv == 0) || salesHistoryCndtn.SendDataDiv == 1)
                        {
                            //送信ログの登録
                            this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // 送信日時（終了）
                            //logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_NODATA); // DEL 田建委 2013/08/12 Redmine#39695
                            logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, 2, LOGMSG_NODATA); // ADD 田建委 2013/08/12 Redmine#39695
                        }
                        // ----- ADD 田建委 2013/06/26 -----<<<<<
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                        errMsg = "データ抽出処理に失敗しました。";
                        // ----- ADD 田建委 2013/06/26 ----->>>>>
                        // 手動送信（売上テキスト出力から）の場合、且つ、自動送信区分が「する」
                        // あるいは自動送信の場合、送信ログを登録
                        if ((salesHistoryCndtn.SendDataDiv == 0 && salesHistoryCndtn.AutoDataSendDiv == 0) || salesHistoryCndtn.SendDataDiv == 1)
                        {
                            //送信ログの登録
                            this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // 送信日時（終了）
                            logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_ERROR);
                        }
                        // ----- ADD 田建委 2013/06/26 -----<<<<<
                        break;
                    default:
                        errMsg = "データ抽出処理に失敗しました。";
                        // ----- ADD 田建委 2013/06/26 ----->>>>>
                        // 手動送信（売上テキスト出力から）の場合、且つ、自動送信区分が「する」
                        // あるいは自動送信の場合、送信ログを登録
                        if ((salesHistoryCndtn.SendDataDiv == 0 && salesHistoryCndtn.AutoDataSendDiv == 0) || salesHistoryCndtn.SendDataDiv == 1)
                        {
                            //送信ログの登録
                            this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // 送信日時（終了）
                            //logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_ERROR); // DEL 田建委 2013/08/12 Redmine#39695
                            logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, -1, LOGMSG_ERROR); // ADD 田建委 2013/08/12 Redmine#39695
                        }
                        // ----- ADD 田建委 2013/06/26 -----<<<<<
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                // ----- ADD 田建委 2013/06/26 ----->>>>>
                // 手動送信（売上テキスト出力から）の場合、且つ、自動送信区分が「する」
                // あるいは自動送信の場合、送信ログを登録
                if ((salesHistoryCndtn.SendDataDiv == 0 && salesHistoryCndtn.AutoDataSendDiv == 0) || salesHistoryCndtn.SendDataDiv == 1)
                {
                    //送信ログの登録
                    this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // 送信日時（終了）
                    logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, LOGMSG_ERROR);
                }
                // ----- ADD 田建委 2013/06/26 -----<<<<<
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private string GetSortOrder()
        {
            StringBuilder strSortOrder = new StringBuilder();

            strSortOrder.Append(string.Format("{0} ASC,", PMSAE02014EA.ct_Col_SectionCodeRF));
            strSortOrder.Append(string.Format("{0} ASC,", PMSAE02014EA.ct_Col_CustomerCode));
            strSortOrder.Append(string.Format("{0} ASC", PMSAE02014EA.ct_Col_SalesSlipNum));

            return strSortOrder.ToString();
        }
        #endregion

        #region ◎ S&E売上抽出データ更新処理
        /// <summary>
        /// 売上抽出データ更新
        /// </summary>
        /// <param name="resultWork"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 売上抽出データを更新する。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private int WriteProc(ArrayList resultWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            errMsg = string.Empty;

            object objectresultWork = resultWork as object;

            if (resultWork != null && resultWork.Count > 0)
            {
                // 書き込み処理
                status = this._iSalesHistoryJoinWorkDB.Write(ref objectresultWork);
            }

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                errMsg = "S&E売上抽出データ更新処理に失敗しました。";
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            return status;
        }


        #endregion
        #endregion ◆ 帳票データ取得

        #region ◎ 取得データ展開処理

        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="salesHistoryCndtn">UI抽出条件クラス</param>
        /// <param name="salesHistoryCndtnWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevSalesHistory(SalesHistoryCndtn salesHistoryCndtn, out SalesHistoryCndtnWork salesHistoryCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            salesHistoryCndtnWork = new SalesHistoryCndtnWork();
            try
            {
                // 企業コード 
                salesHistoryCndtnWork.EnterpriseCode = salesHistoryCndtn.EnterpriseCode;
                // 拠点コードリスト
                salesHistoryCndtnWork.SectionCodeList = salesHistoryCndtn.SectionCodeList;
                // 計上日(開始)
                salesHistoryCndtnWork.AddUpADateSt = salesHistoryCndtn.AddUpADateSt;
                // 計上日(終了)
                salesHistoryCndtnWork.AddUpADateEd = salesHistoryCndtn.AddUpADateEd;
                //得意先(開始)
                salesHistoryCndtnWork.CustomerCodeSt = salesHistoryCndtn.CustomerCodeSt;
                //得意先(終了)
                salesHistoryCndtnWork.CustomerCodeEd = salesHistoryCndtn.CustomerCodeEd;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }


        #endregion ◎ 抽出条件展開処理
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
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
        /// <param name="salesHistoryCndtn">UI抽出条件クラス</param>
        /// <param name="resultWork">取得データ</param>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// <br>UpdateNote : 2020/2/26 石崎</br>
        /// <br>           : Ｓ＆Ｅ改良対応 </br>
        /// </remarks>
        private int GetSalesHistoryData(SalesHistoryCndtn salesHistoryCndtn, ArrayList resultWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // ----- ADD 石崎 2020/02/26 ----->>>>>
            //メーカー・品番AB商品コード変換マスタの取得
            ArrayList sAEMkrGdsCdChgList = new ArrayList();
            sAEMkrGdsCdChgList.Clear();
            status = this._MakerGoodsCodeSetAcs.SearchAll(out sAEMkrGdsCdChgList, this._enterpriseCode);
            // ----- ADD 石崎 2020/02/26 -----<<<<<
            //S&E売上抽出データ更新用
            _resultWorkClone = new ArrayList();

            foreach (SalesHistoryJoinWork salesHistoryJoinWork in resultWork)
            {
                //S&E売上抽出データにレコードが存在しない
                if (salesHistoryCndtn.PdfOutDiv == 0)
                {
                    if (salesHistoryJoinWork.SEAcptAnOdrStatus == 0
                        && string.IsNullOrEmpty(salesHistoryJoinWork.SEEnterpriseCode)
                        && salesHistoryJoinWork.SESalesCreateDateTime == 0
                        && string.IsNullOrEmpty(salesHistoryJoinWork.SESalesSlipNum))
                    {
                        ConvertSalesHistoryData(salesHistoryJoinWork, sAEMkrGdsCdChgList);

                        _resultWorkClone.Add(salesHistoryJoinWork);
                    }
                }
                //S&E売上抽出データにレコードが存在する
                else if (salesHistoryCndtn.PdfOutDiv == 1)
                {
                    if (salesHistoryJoinWork.SEAcptAnOdrStatus != 0
                        && !string.IsNullOrEmpty(salesHistoryJoinWork.SEEnterpriseCode)
                        && salesHistoryJoinWork.SESalesCreateDateTime != 0
                        && !string.IsNullOrEmpty(salesHistoryJoinWork.SESalesSlipNum))
                    {
                        ConvertSalesHistoryData(salesHistoryJoinWork, sAEMkrGdsCdChgList);

                        _resultWorkClone.Add(salesHistoryJoinWork);
                    }

                }
                //全て（S&E売上抽出データに依存しない）
                else
                {
                    ConvertSalesHistoryData(salesHistoryJoinWork, sAEMkrGdsCdChgList);

                    _resultWorkClone.Add(salesHistoryJoinWork);
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
        /// <param name="salesHistoryJoinWork">取得データ</param>
        /// <param name="sAEMkrGdsCdChgWorkList">メーカー・品番AB商品コード変換マスタの取得データ</param>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// <br>UpdateNote : 2012/12/07 zhuhh</br>
        /// <br>           : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修</br>
        /// <br>UpdateNote : 2013/02/25 zhuhh</br>
        /// <br>           : Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更</br>
        /// <br>UpdateNote : 2013/03/06 zhuhh</br>
        /// <br>           : Ｓ＆Ｅ(AB) テキスト出力自動送信の追加</br>
        /// <br>UpdateNote : 2020/2/26 石崎</br>
        /// <br>           : Ｓ＆Ｅ改良対応</br>
        /// </remarks>
        private void ConvertSalesHistoryData(SalesHistoryJoinWork salesHistoryJoinWork, ArrayList sAEMkrGdsCdChgWorkList)  // ----- UPD 石崎 2020/02/26 
        {
            DataRow dr = _salesHistoryDt.NewRow();

            //AB伝票№
            dr[PMSAE02014EA.ct_Col_SalesSlipNum] = DataNoSubStr(6, salesHistoryJoinWork.SalesSlipNum);

            //請求区分
            if (salesHistoryJoinWork.SalesSlipCd == 0)
            {
                dr[PMSAE02014EA.ct_Col_RequestDiv] = "010";
            }
            else if (salesHistoryJoinWork.SalesSlipCd == 1)
            {
                dr[PMSAE02014EA.ct_Col_RequestDiv] = "020";
            }
            else
            {
                //
            }

            //AB店舗ｺｰﾄﾞ
            dr[PMSAE02014EA.ct_Col_AddresseeShopCd] = salesHistoryJoinWork.AddresseeShopCd;

            //売上日
            dr[PMSAE02014EA.ct_Col_AddUpADate] = salesHistoryJoinWork.AddUpADate.ToString("yyyyMMdd");

            //純正優良区分
            int goodsMakerCd = salesHistoryJoinWork.GoodsMakerCd;
            dr[PMSAE02014EA.ct_Col_GoodDiv] = GetGoodDiv(goodsMakerCd, salesHistoryJoinWork);

            //部品商ｺｰﾄﾞ
            if (ONE.Equals(dr[PMSAE02014EA.ct_Col_GoodDiv]))
            {
                dr[PMSAE02014EA.ct_Col_TradCompCd] = salesHistoryJoinWork.PureTradCompCd;

            }
            else if (TWO.Equals(dr[PMSAE02014EA.ct_Col_GoodDiv]))
            {
                dr[PMSAE02014EA.ct_Col_TradCompCd] = salesHistoryJoinWork.PriTradCompCd;

            }

            //Ｓ＆Ｅ仕入率
            double tradCompRate = 0;
            if (ONE.Equals(dr[PMSAE02014EA.ct_Col_GoodDiv]))
            {
                tradCompRate = salesHistoryJoinWork.PureTradCompRate * 10;

            }
            else if (TWO.Equals(dr[PMSAE02014EA.ct_Col_GoodDiv]))
            {
                tradCompRate = salesHistoryJoinWork.PriTradCompRate * 10;
            }
            dr[PMSAE02014EA.ct_Col_TradCompRate] = DataNoSubStr(4, tradCompRate.ToString("0000"));

            //AB売上率
            dr[PMSAE02014EA.ct_Col_AbSalesRate] = "0000";

            //行№
            dr[PMSAE02014EA.ct_Col_SalesRowNo] = DataNoSubStr(2, salesHistoryJoinWork.SalesRowNo.ToString("d2"));

            //管理№
            bool flag = GetBlEffective(salesHistoryJoinWork.CustomerCode);

            if (flag == true)
            {
                dr[PMSAE02014EA.ct_Col_AdministrationNo] = DataNoSubStr(4, salesHistoryJoinWork.PrtBLGoodsCode.ToString("d4"));
            }
            else
            {
                dr[PMSAE02014EA.ct_Col_AdministrationNo] = "0000";
            }


            //管理名称（品番）
            dr[PMSAE02014EA.ct_Col_GoodsNo] = GetCharFormat(salesHistoryJoinWork.GoodsNo);

            //品名
            //dr[PMSAE02014EA.ct_Col_GoodsNameKana] = GetCharFormat(salesHistoryJoinWork.GoodsNameKana);// DEL zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更
            dr[PMSAE02014EA.ct_Col_GoodsNameKana] = GetGoodsNameCharFormat(salesHistoryJoinWork.GoodsNameKana);// ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更

            // ----- add 石崎 2020/02/26 ----->>>>>
            //商品ｺｰﾄﾞ
            string ABGoodsCode = string.Empty;
            foreach (SAndEMkrGdsCdChg sAEMkrGdsCdChgWork in sAEMkrGdsCdChgWorkList)
            {
                if ((DataNoSubStr(4, salesHistoryJoinWork.GoodsMakerCd.ToString("d4")) == DataNoSubStr(4, sAEMkrGdsCdChgWork.GoodsMakerCd.ToString("d4")))
                    && (GetCharFormat(salesHistoryJoinWork.GoodsNo) == GetCharFormat(sAEMkrGdsCdChgWork.GoodsNo))
                    && (sAEMkrGdsCdChgWork.LogicalDeleteCode) == 0 )
                {
                    dr[PMSAE02014EA.ct_Col_AbGoodsNo] = sAEMkrGdsCdChgWork.ABGoodsCode.PadLeft(8, '0');
                    ABGoodsCode = sAEMkrGdsCdChgWork.ABGoodsCode;
                    break;
                }
            }
            if (string.IsNullOrEmpty(ABGoodsCode))
            {
                if (!string.IsNullOrEmpty(salesHistoryJoinWork.ABGoodsCode))
                {
                    dr[PMSAE02014EA.ct_Col_AbGoodsNo] = salesHistoryJoinWork.ABGoodsCode.PadLeft(8, '0'); 
                }
                else
                {
                    dr[PMSAE02014EA.ct_Col_AbGoodsNo] = salesHistoryJoinWork.SetABGoodsCode.PadLeft(8, '0'); 
                }
            }
            // ----- add 石崎 2020/02/26 -----<<<<<
            // ----- del 石崎 2020/02/26 ----->>>>>
            ////商品ｺｰﾄﾞ
            //if (!string.IsNullOrEmpty(salesHistoryJoinWork.ABGoodsCode))
            //{
            //    //dr[PMSAE02014EA.ct_Col_AbGoodsNo] = salesHistoryJoinWork.ABGoodsCode;// DEL zhuhh 2012/12/07 AB商品コードの桁数の改修
            //    dr[PMSAE02014EA.ct_Col_AbGoodsNo] = salesHistoryJoinWork.ABGoodsCode.PadLeft(8, '0'); // ADD zhuhh 2012/12/07 AB商品コードの桁数の改修
            //}
            //else
            //{
            //    //dr[PMSAE02014EA.ct_Col_AbGoodsNo] = salesHistoryJoinWork.SetABGoodsCode;// DEL zhuhh 2012/12/07 AB商品コードの桁数の改修
            //    dr[PMSAE02014EA.ct_Col_AbGoodsNo] = salesHistoryJoinWork.SetABGoodsCode.PadLeft(8, '0'); // ADD zhuhh 2012/12/07 AB商品コードの桁数の改修
            //}
            // ----- del 石崎 2020/02/26 -----<<<<<

            //数量
            dr[PMSAE02014EA.ct_Col_ShipmentCnt] = GetNumFormat(salesHistoryJoinWork.ShipmentCnt);

            //納入単価
            dr[PMSAE02014EA.ct_Col_SalesUnPrcTaxExcFl] = GetNumFormat(salesHistoryJoinWork.SalesUnPrcTaxExcFl);

            //納入金額
            dr[PMSAE02014EA.ct_Col_SalesMoneyTaxExc] = GetNumFormat(salesHistoryJoinWork.SalesMoneyTaxExc);

            //PDF用納入金額
            dr[PMSAE02014EA.ct_Col_PdfSalesMoneyTaxExc] = GetNumRound(salesHistoryJoinWork.SalesMoneyTaxExc);

            //仕入金額
            dr[PMSAE02014EA.ct_Col_SupplierMoney] = GetSupplierMoney(dr[PMSAE02014EA.ct_Col_GoodDiv].ToString(), salesHistoryJoinWork,1);

            //PDF用仕入金額
            dr[PMSAE02014EA.ct_Col_PdfSupplierMoney] = GetSupplierMoney(dr[PMSAE02014EA.ct_Col_GoodDiv].ToString(), salesHistoryJoinWork,2);

            //売上金額
            dr[PMSAE02014EA.ct_Col_SalesMoney] = "00000000";

            // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更----->>>>>
            //店舗売価
            dr[PMSAE02014EA.ct_Col_ShopMoney] = GetNumFormat(salesHistoryJoinWork.ListPriceTaxExcFl);

            //売価金額
            dr[PMSAE02014EA.ct_Col_PriceMoney] = GetNumFormatWithoutMinus(salesHistoryJoinWork.ListPriceTaxExcFl * salesHistoryJoinWork.ShipmentCnt);
            // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更-----<<<<<

            //Txt得意先ｺｰﾄﾞ
            dr[PMSAE02014EA.ct_Col_TxtCustomerCode] = salesHistoryJoinWork.SAndEMngCode;

            //得意先ｺｰﾄﾞ
            dr[PMSAE02014EA.ct_Col_CustomerCode] = salesHistoryJoinWork.CustomerCode.ToString("d8");

            //地区ｺｰﾄﾞ
            dr[PMSAE02014EA.ct_Col_AreaCd] = "0";

            //ｱｯﾌﾟﾃﾞｰﾄＹＭＤ
            dr[PMSAE02014EA.ct_Col_SearchSlipDate] = salesHistoryJoinWork.SearchSlipDate.ToString("yyyyMMdd");

            //仕入先コード
            dr[PMSAE02014EA.ct_Col_SupplierCd] = salesHistoryJoinWork.SupplierCd.ToString("d8");

            //経費区分
            string expenseDivCd;
            if (salesHistoryJoinWork.ExpenseDivCd == 0)
            {
                expenseDivCd = "1";
            }
            else
            {
                expenseDivCd = salesHistoryJoinWork.ExpenseDivCd.ToString();
            }
            dr[PMSAE02014EA.ct_Col_ExpenseDivCd] = expenseDivCd;

            //メーカーコード
            dr[PMSAE02014EA.ct_Col_GoodsMakerCd] = DataNoSubStr(4, salesHistoryJoinWork.GoodsMakerCd.ToString("d4"));

            // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更----->>>>>
            //注文ナンバー
            dr[PMSAE02014EA.ct_Col_OrderNum] = "999999";
            // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更-----<<<<<

            //ＦＩＬＬＥＲ
            dr[PMSAE02014EA.ct_Col_Filler] = " ";

            //拠点コード
            dr[PMSAE02014EA.ct_Col_SectionCodeRF] = salesHistoryJoinWork.ResultsAddUpSecCd;

            // 拠点ガイド略称
            string sectionGuideSnm = "";
            if (string.IsNullOrEmpty(salesHistoryJoinWork.SectionGuideSnm))
            {
                sectionGuideSnm = "未登録";
            }
            else
            {
                sectionGuideSnm = salesHistoryJoinWork.SectionGuideSnm;
            }
            dr[PMSAE02014EA.ct_Col_SectionGuideSnm] = sectionGuideSnm;

            // 得意先略称
            string customerSnm = "";
            if (string.IsNullOrEmpty(salesHistoryJoinWork.CustomerSnm))
            {
                customerSnm = "未登録";
            }
            else
            {
                customerSnm = salesHistoryJoinWork.CustomerSnm;
            }
            dr[PMSAE02014EA.ct_Col_CustomerSnm] = customerSnm;
            // ----- ADD zhuhh 2013/03/06 for Redmine#35011----->>>>>
            // データ区分
            dr[PMSAE02014EA.ct_Col_DataDiv] = "01";

            // パーツマン端末コード
            dr[PMSAE02014EA.ct_Col_PartsManWSCD] = "";
            // ----- ADD zhuhh 2013/03/06 for Redmine#35011-----<<<<<
            _salesHistoryDt.Rows.Add(dr);
        }

        /// <summary>
        /// 下n桁の取得処理
        /// </summary>
        /// <param name="index">抽出条件</param>
        /// <param name="DataNo">伝票番号</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       :  下n桁の取得処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
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
        /// <param name="inputGoodsMakerCd">抽出条件</param>
        /// <param name="salesHistoryJoinWork">伝票番号</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 純正優良区分の取得処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private string GetGoodDiv(int inputGoodsMakerCd, SalesHistoryJoinWork salesHistoryJoinWork)
        {
            string DataNum;

            if (inputGoodsMakerCd > 0)
            {
                bool isExistFlg = false;
                bool isExistTwoFlg = false;

                // 商品メーカーコード追加
                ArrayList goodsMakerCdList = new ArrayList();

                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd1);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd2);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd3);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd4);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd5);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd6);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd7);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd8);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd9);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd10);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd11);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd12);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd13);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd14);
                goodsMakerCdList.Add(salesHistoryJoinWork.GoodsMakerCd15);

                // データ比較
                foreach (int goodsMakserCd in goodsMakerCdList)
                {
                    if (inputGoodsMakerCd == goodsMakserCd)
                    {
                        isExistFlg = true;
                        break;
                    }
                }

                if ((1 <= inputGoodsMakerCd) && (99 >= inputGoodsMakerCd))
                {
                    isExistTwoFlg = true;
                }

                if ((isExistFlg == true) || (isExistTwoFlg == true))
                {
                    DataNum = ONE;
                }
                else
                {
                    DataNum = TWO;
                }
            }
            else
            {
                DataNum = TWO;
            }

            return DataNum;
        }

        /// <summary>
        /// BL商品コードの印字有無の取得処理
        /// </summary>
        /// <returns>有無</returns>
        /// <remarks>
        /// <br>Note       : BL商品コードの印字有無の取得処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
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
        /// <returns>有無</returns>
        /// <remarks>
        /// <br>Note       : 全角文字の取得処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
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

        // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更----->>>>>
        /// <summary>
        /// 全角文字の取得処理
        /// </summary>
        /// <returns>有無</returns>
        /// <remarks>
        /// <br>Note       : 全角文字の取得処理を行います。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/02/25</br>
        /// </remarks>
        private string GetGoodsNameCharFormat(string data)
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

            if (sb.ToString().Length > 20)
            {
                s = sb.ToString().Substring(0, 20);
            }
            else
            {
                s = sb.ToString().PadRight(20,' ');
            }

            return s;

        }

        /// <summary>
        /// 小数点以下1桁で四捨五入、マイナス値はプラスになります
        /// </summary>
        /// <returns>有無</returns>
        /// <remarks>
        /// <br>Note       : 小数点以下1桁で四捨五入、マイナス値はプラスになります。</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/02/25</br>
        /// </remarks>
        private string GetNumFormatWithoutMinus(Double data)
        {
            long numFormat;            
            FractionCalculate.FracCalcMoney(data, 1, 2, out numFormat);

            if (numFormat < 0) 
            {
                numFormat = numFormat * (-1);
            }

            return DataNoSubStr(8, numFormat.ToString("d8"));
        }
        // ----- ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更-----<<<<<

        /// <summary>
        /// 小数点以下1桁で四捨五入、マイナス値の場合の取得処理
        /// </summary>
        /// <returns>有無</returns>
        /// <remarks>
        /// <br>Note       : 小数点以下1桁で四捨五入、マイナス値の場合の取得処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private string GetNumFormat(Double data)
        {
            long numFormat;
            string result;
            FractionCalculate.FracCalcMoney(data, 1, 2, out numFormat);

            if (numFormat < 0)
            {
                if (numFormat.ToString().Length > 8)
                {
                    numFormat = Convert.ToInt64(DataNoSubStr(7, numFormat.ToString())) * (-1);

                    result = numFormat.ToString("d7");
                }
                else
                {
                    result = numFormat.ToString("d7");
                }
            }
            else
            {
                result = DataNoSubStr(8, numFormat.ToString("d8"));
            }

            return result;
        }

        /// <summary>
        /// 小数点以下1桁で四捨五入、マイナス値の場合の取得処理
        /// </summary>
        /// <returns>有無</returns>
        /// <remarks>
        /// <br>Note       : 小数点以下1桁で四捨五入、マイナス値の場合の取得処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private string GetNumRound(Double data)
        {
            long numFormat;
            FractionCalculate.FracCalcMoney(data, 1, 2, out numFormat);

            return numFormat.ToString();
        }

        /// <summary>
        /// 仕入金額の取得処理
        /// </summary>
        /// <returns>有無</returns>
        /// <remarks>
        /// <br>Note       : 仕入金額の取得処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
        /// </remarks>
        private string GetSupplierMoney(string goodDiv, SalesHistoryJoinWork salesHistoryJoinWork ,int flag)
        {
            double input = 0;
            double numFormat = 0;

            if (ONE.Equals(goodDiv))
            {
                input = (salesHistoryJoinWork.SalesUnPrcTaxExcFl * salesHistoryJoinWork.PureTradCompRate / 100);

                FractionCalculate.FracCalcMoney(input, 1, 2, out numFormat);
            }
            else if (TWO.Equals(goodDiv))
            {
                input = (salesHistoryJoinWork.SalesUnPrcTaxExcFl * salesHistoryJoinWork.PriTradCompRate / 100);

                FractionCalculate.FracCalcMoney(input, 1, 2, out numFormat);
            }

            if (flag == 1)
            {
                return GetNumFormat(numFormat * salesHistoryJoinWork.ShipmentCnt);
            }
            else
            {
                return GetNumRound(numFormat * salesHistoryJoinWork.ShipmentCnt);
            }
        }

        /// <summary>
        /// 得意先マスタ（伝票管理）リストの取得処理
        /// </summary>
        /// <returns>得意先マスタ（伝票管理）リスト</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（伝票管理）リストの取得処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.13</br>
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

        // ----- ADD zhuhh 2013/03/06 for Redmine#35011 ----->>>>>
        #region [自動送信]
        /// <summary>
        /// Webサーバと送受信します。
        /// </summary>
        /// <param name="salesHistoryCndtn">条件</param>
        /// <param name="fileName">ファイル名</param>
        /// <param name="sAndESalSndLogWork">送信ログ情報</param>
        /// <param name="logStatus">送信ログ登録ステータス</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: Webサーバと送受信します。</br>
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
        /// <br>UpdateNote  : 2013/05/21 zhuhh</br>
        /// <br>            : 自動送信Javaツールを利用する</br>
        /// <br>UpdateNote  : 2013/06/24 zhuhh</br>
        /// <br>            : S&Eブレーキ送信コマンド</br>
        /// <br>UpdateNote  : 2013/06/26 田建委</br>
        /// <br>            : 自動送信処理の追加及び送信ログの登録</br>
        /// <br>UpdateNote  : 2013/07/25 田建委</br>
        /// <br>            : Redmine#39145 エラー発生時もS&E売上抽出データ更新した場合がある対応</br>
        /// </remarks>
        //public int SendAndReceive(ref SalesHistoryCndtn salesHistoryCndtn, String fileName) // DEL 田建委 2013/06/26
        public int SendAndReceive(ref SalesHistoryCndtn salesHistoryCndtn, String fileName, out SAndESalSndLogListResultWork sAndESalSndLogWork, out int logStatus) // ADD 田建委 2013/06/26
        {
            //int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL; // DEL 田建委 2013/07/25
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL; // ADD 田建委 2013/07/25
            string xmlFileName = string.Empty;

            //----- ADD 田建委 2013/06/26 ---------->>>>>
            string logErrMsg = string.Empty;
            //logStatus = (int)ConstantManagement.MethodResult.ctFNC_NORMAL; // DEL 田建委 2013/07/25
            logStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL; // ADD 田建委 2013/07/25
            sAndESalSndLogWork = new SAndESalSndLogListResultWork();
            //----- ADD 田建委 2013/06/26 ----------<<<<<

            if (fileName.Contains("."))
            {
                int index = fileName.LastIndexOf(".");
                xmlFileName = fileName.Substring(0, index) + ".XML";
            }
            else 
            {
                xmlFileName = fileName + ".XML";
            }

            ConnectInfoWork connectInfoWork = null;
            try
            {
                if (null == this._connectInfoWorkAcs)
                {
                    this._connectInfoWorkAcs = new ConnectInfoWorkAcs();
                }
                else
                { 
                    //なし
                }
                status = this._connectInfoWorkAcs.Read(out connectInfoWork, salesHistoryCndtn.EnterpriseCode, SUPPLIERCD);
            }
            catch (Exception ex)
            {
                ex.ToString();
                status = -1;
                // ----- ADD 田建委 2013/06/26 ----->>>>>
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logErrMsg = LOGMSG_ERROR;
                //送信ログの登録
                logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, logErrMsg);
                // ----- ADD 田建委 2013/06/26 -----<<<<<
                return status;
            }

            if (connectInfoWork == null || status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                status = -1;
                // ----- ADD 田建委 2013/06/26 ----->>>>>
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logErrMsg = LOGMSG_ERROR;
                //送信ログの登録
                logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, logErrMsg);
                // ----- ADD 田建委 2013/06/26 -----<<<<<
                return status;
            }

            /* ----- DEL zhuhh 2013/05/21 for Redmine#35639 ----->>>>>
            string myString = "";
            string content = "";
            string fileRecStream = "";
            string errorMessage = "";

            // 回線オープン処理
            if (RequestOpen(connectInfoWork))
            {
                HttpWebResponse response = null;
                try
                {
                    // 送信電文データをXMLファイルに変換する
                    content = ConvertUoeSndHedToXML(connectInfoWork, xmlFileName);

                    myString += STRING_BOUNDARY;
                    myString += STRING_CHANGE_ROW;
                    myString += "Content-Disposition: form-data; name=\"xml_data\"; ";
                    myString += "filename=\"" + fileName + "\"";
                    myString += STRING_CHANGE_ROW;
                    myString += STRING_CHANGE_ROW;

                    myString = myString + content + STRING_CHANGE_ROW + STRING_BOUNDARY + "--" + STRING_CHANGE_ROW;

                    byte[] body = Encoding.ASCII.GetBytes(myString);

                    using (Stream reqStream = request.GetRequestStream())
                    {
                        reqStream.Write(body, 0, body.Length);
                        reqStream.Close();
                    }
                    response = (HttpWebResponse)request.GetResponse();
                    using (Stream revStream = response.GetResponseStream())
                    {                                                
                        StreamReader sr = new StreamReader(revStream, Encoding.GetEncoding(932));
                        fileRecStream = sr.ReadToEnd();

                    }
                }
                catch (WebException ex)
                {
                    errorMessage = ex.Message;
                    status = -1;
                    return status;
                }
                response.Close();
                try
                {
                    //Recファイル作成

                    if (fileRecStream == string.Empty)
                    {
                        status = -1;
                        errorMessage = "ﾃﾞｰﾀ受信中にｴﾗｰが発生(受信ファイル内容がありません) ";
                        return status;
                    }

                    string fileRecName = xmlFileName.Substring(0,xmlFileName.Length-4) + "RECV.XML";

                    FileStream file = new FileStream(fileRecName, FileMode.Create);

                    file.Write(Encoding.UTF8.GetBytes(fileRecStream), 0, Encoding.UTF8.GetByteCount(fileRecStream));
                    file.Close();

                }
                catch (Exception ex)
                {
                    ex.ToString();
                    status = -1;
                    return status;
                }
            }
            else
            {
                status = -1;
                return status;
            }
               ----- DEL zhuhh 2013/05/21 for Redmine#35639 -----<<<<< */
            // ----- ADD zhuhh 2013/05/21 for Redmine#35639 ----->>>>>

            String command = CommandOrganization(connectInfoWork, fileName);
            // ----- ADD 田建委 2013/06/26 ----->>>>>
            if (string.IsNullOrEmpty(command) || command.Equals("<1.5.0"))
            {
                status = -1;
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                logErrMsg = LOGMSG_JAVAVERERR;
                //送信ログの登録
                logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, logErrMsg);
                return status;
            }
            // ----- ADD 田建委 2013/06/26 -----<<<<<

            bool errFlag = false;
            string errMsg = string.Empty; // ADD 田建委 2013/06/26
            try
            {
                //status = int.Parse(RunCmd(command, ref errFlag));// DEL zhuhh 2013/06/24 for Redmine#37017
                //status = int.Parse(RunCmd(command, ref errFlag, 1));// ADD zhuhh 2013/06/24 for Redmine#37017 // DEL 田建委 2013/06/26
                string ret = RunCmd(command, ref errFlag, 1, errMsg, connectInfoWork.LoginTimeoutVal * 1000, connectInfoWork.RetryCnt); // ADD 田建委 2013/06/26
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // ADD 田建委 2013/06/26
                if (errFlag)
                {
                    status = -1;
                }
                // ----- DEL 田建委 2013/06/26 ----->>>>>
                //if (status != 0)
                //{
                //    status = -1;
                //}
                // ----- DEL 田建委 2013/06/26 -----<<<<<
                // ----- ADD 田建委 2013/06/26 ----->>>>>
                // --- ADD 田建委 2013/07/25 --->>>>>
                if (string.IsNullOrEmpty(ret))
                {
                    status = -1;
                    logErrMsg = LOGMSG_UNEXPECTEDERR;
                } 
                else
                // --- ADD 田建委 2013/07/25 ---<<<<<
                if (ret != "0")
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
                    else
                    {
                        int intRet = 0;
                        if (!int.TryParse(ret, out intRet))
                        {
                            ret = "その他";
                        }
                        logErrMsg = LOGMSG_SENDERR + LOGMSG_SENDADDERR + ret + ")";
                    }
                }
                // --- ADD 田建委 2013/07/25 --->>>>>
                else
                {
                    status = 0;
                }
                // --- ADD 田建委 2013/07/25 ---<<<<<
                //送信ログの登録
                logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, logErrMsg);
                // ----- ADD 田建委 2013/06/26 -----<<<<<
            }
            catch (Exception exc)
            {
                exc.ToString();
                status = -1;
                // ----- ADD 田建委 2013/06/26 ----->>>>>
                //送信ログの登録
                this._sendDateTimeEnd = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")); // ADD 田建委 2013/06/26
                //logErrMsg = LOGMSG_SENDERR; // DEL 田建委 2013/07/25
                logErrMsg = LOGMSG_UNEXPECTEDERR; // ADD 田建委 2013/07/25
                logStatus = WriteLogInfo(salesHistoryCndtn, ref sAndESalSndLogWork, status, logErrMsg);
                // ----- ADD 田建委 2013/06/26 -----<<<<<
            }
            // ----- ADD zhuhh 2013/05/21 for Redmine#35639 -----<<<<<
            return status;
        }

        // ----- ADD 田建委 2013/06/26 ----->>>>>
        /// <summary>
        /// 伝票枚数、明細数、売上合計の計算
        /// </summary>
        /// <remarks>
        /// <br>Note		: 伝票枚数、明細数、売上合計の計算を行います。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2013/06/26</br>
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
                    string salesSlipNum = detailView[PMSAE02014EA.ct_Col_SalesSlipNum].ToString();
                    if (!string.IsNullOrEmpty(salesSlipNum) && (!befSalesSlipNum.Equals(salesSlipNum)))
                    {
                        slipCountSum++;
                    }
                    befSalesSlipNum = salesSlipNum;

                    //明細数
                    detailCount++;

                    //売上合計
                    salesMoneySum += Convert.ToInt64(detailView[PMSAE02014EA.ct_Col_PdfSalesMoneyTaxExc]);
                }

                this._sendSlipCount = slipCountSum;
                this._sendSlipDtlCnt = detailCount;
                this._sendSlipTotalMny = salesMoneySum;
            }
        }

        /// <summary>
        /// 送信ログ情報の登録
        /// </summary>
        /// <param name="salesHistoryCndtn">検索条件</param>
        /// <param name="sAndESalSndLogWork">送信ログ情報</param>
        /// <param name="sendResult">送信の戻したステータス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: 送信ログ情報を登録します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        public int WriteLogInfo(SalesHistoryCndtn salesHistoryCndtn, ref SAndESalSndLogListResultWork sAndESalSndLogWork, int sendResult, string errMsg)
        {
            int status = -1;

            //送信ログの作成
            sAndESalSndLogWork = MakeLogInfo(salesHistoryCndtn, sendResult, errMsg);
            object obj = sAndESalSndLogWork;

            //送信ログの登録
            status = _iSalesHistoryJoinWorkDB.WriteLog(ref obj);
            sAndESalSndLogWork = obj as SAndESalSndLogListResultWork;

            return status;
        }

        /// <summary>
        /// 送信ログ情報の作成
        /// </summary>
        /// <param name="salesHistoryCndtn">検索条件</param>
        /// <param name="sendResult">送信の戻したステータス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>送信ログ情報</returns>
        /// <remarks>
        /// <br>Note		: 送信ログ情報を作成します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2013/06/26</br>
        /// <br>UpdateNote  : 2013/08/12 田建委</br>
        /// <br>            : Redmine#39695 抽出結果無時のログ内容の変更対応</br>
        /// </remarks>
        private SAndESalSndLogListResultWork MakeLogInfo(SalesHistoryCndtn salesHistoryCndtn, int sendResult, string errMsg)
        {
            SAndESalSndLogListResultWork sAndESalSndLogWork = new SAndESalSndLogListResultWork();
            // 企業コード
            sAndESalSndLogWork.EnterpriseCode = this._enterpriseCode;
            // 論理削除区分
            sAndESalSndLogWork.LogicalDeleteCode = 0;
            // 拠点コード
            sAndESalSndLogWork.SectionCode = this._sectionCode;
            // 送信日時（開始）
            sAndESalSndLogWork.SendDateTimeStart = this._sendDateTimeStart;
            // 送信日時（終了）
            sAndESalSndLogWork.SendDateTimeEnd = this._sendDateTimeEnd;
            // 送信対象開始日付
            sAndESalSndLogWork.SendObjDateStart = salesHistoryCndtn.AddUpADateSt;
            // 送信対象終了日付
            sAndESalSndLogWork.SendObjDateEnd = salesHistoryCndtn.AddUpADateEd;
            // (0:手動;1:自動)
            if (salesHistoryCndtn.SendDataDiv == 0)
            {
                // 自動送信区分
                sAndESalSndLogWork.SAndEAutoSendDiv = 0;
                // 送信対象得意先（開始）
                sAndESalSndLogWork.SendObjCustStart = salesHistoryCndtn.CustomerCodeSt;
                // 送信対象得意先（終了）
                sAndESalSndLogWork.SendObjCustEnd = salesHistoryCndtn.CustomerCodeEd;
                // 自動送信区分
            }
            else
            {
                sAndESalSndLogWork.SAndEAutoSendDiv = 1;
                // 送信対象得意先（開始）
                sAndESalSndLogWork.SendObjCustStart = 0;
                // 送信対象得意先（終了）
                sAndESalSndLogWork.SendObjCustEnd = 0;
            }
            // 送信対象区分
            if (salesHistoryCndtn.PdfOutDiv == 0)
            {
                sAndESalSndLogWork.SendObjDiv = 1; // 未出力分→未送信
            }
            else if (salesHistoryCndtn.PdfOutDiv == 1)
            {
                sAndESalSndLogWork.SendObjDiv = 2; // 出力分→送信済
            }
            else if (salesHistoryCndtn.PdfOutDiv == 2)
            {
                sAndESalSndLogWork.SendObjDiv = 0; // 全て→全て
            }

            if (sendResult == 0)
            {
                // 送信結果
                sAndESalSndLogWork.SendResults = 0;
                // 送信エラー内容
                sAndESalSndLogWork.SendErrorContents = string.Empty;
                // 送信伝票枚数
                sAndESalSndLogWork.SendSlipCount = this._sendSlipCount;
                // 送信伝票明細数
                sAndESalSndLogWork.SendSlipDtlCnt = this._sendSlipDtlCnt;
                // 送信伝票合計金額
                sAndESalSndLogWork.SendSlipTotalMny = this._sendSlipTotalMny;
            }
            else
            {
                // 送信結果
                //----- ADD 田建委 2013/08/12 Redmine#39695 ----->>>>>
                if (sendResult == 2) // 送信データなしの場合、ステータスは「2」で固定
                {
                    sAndESalSndLogWork.SendResults = 2;
                }
                else
                {
                    sAndESalSndLogWork.SendResults = 1;
                }
                //----- ADD 田建委 2013/08/12 Redmine#39695 -----<<<<<
                //sAndESalSndLogWork.SendResults = 1; // DEL 田建委 2013/08/12 Redmine#39695
                // 送信エラー内容
                sAndESalSndLogWork.SendErrorContents = errMsg;
                // 送信伝票枚数
                sAndESalSndLogWork.SendSlipCount = 0;
                // 送信伝票明細数
                sAndESalSndLogWork.SendSlipDtlCnt = 0;
                // 送信伝票合計金額
                sAndESalSndLogWork.SendSlipTotalMny = 0;
            }

            return sAndESalSndLogWork;
        }
        // ----- ADD 田建委 2013/06/26 -----<<<<<

        // ----- ADD zhuhh 2013/05/21 for Redmine#35639 ----->>>>>
        /// <summary>
        /// 送信データフィル名の処理します
        /// </summary>
        /// <param name="value">フィル名</param>
        /// <returns>送信データフィル名</returns>
        /// <remarks>
        /// <br>Note		: 送信データフィル名の処理します。</br>
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/05/21</br>										
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/05/21</br>										
        /// <br>UpdateNote  : 2013/06/24 zhuhh</br>
        /// <br>            : S&Eブレーキ送信コマンド</br>
        /// </remarks>
        private String CommandOrganization(ConnectInfoWork connectInfoWork, String fileName)
        {
            //----- DEL 田建委 2013/06/26 ---------->>>>>
            //String userName = connectInfoWork.ConnectUserId;
            //String password = connectInfoWork.ConnectPassword;
            //----- DEL 田建委 2013/06/26 ----------<<<<<
            //----- ADD 田建委 2013/06/26 ---------->>>>>
            String userName = connectInfoWork.SAndECnctUserId.Trim();
            String password = connectInfoWork.SAndECnctPass.Trim();
            //----- ADD 田建委 2013/06/26 ----------<<<<<
            String fileId = connectInfoWork.CnectFileId.Trim();// ADD zhuhh 2013/06/24 for Redmine#37017
            String mode = "S";
            String logLevel = "2";// ADD zhuhh 2013/06/24 for Redmine#37017
            int templength = fileName.Length;
            int tempof = fileName.LastIndexOf("\\");
            String dataName =SetFileNm( fileName.Substring(fileName.LastIndexOf("\\")+1 , (fileName.Length -1)- fileName.LastIndexOf("\\")));
            string httpHead = "";
            //HTTP/HTTPS プロトコル  
            if (connectInfoWork.DaihatsuOrdreDiv == 0)
            {
                httpHead = "http://";
            }
            else
            {
                httpHead = "https://";
            }
            String connectURL = httpHead+connectInfoWork.OrderUrl+connectInfoWork.StockCheckUrl;
            String dataPath = fileName.Substring(0, fileName.LastIndexOf("\\"));
            /* ----- DEL zhuhh 2013/06/24 for Redmine#37017 ----->>>>>
            String logPath = dataPath;

            String command = "Java dtrcmd14"
                           + " -u " + userName
                           + " -p " + password
                           + " -m " + mode
                           + " -f " + dataName
                           + " -c " + connectURL
                           + " -d " + dataPath
                           + " -o " + logPath;
               ----- DEL zhuhh 2013/06/24 for Redmine#37017 -----<<<<<*/
            // ----- ADD zhuhh 2013/06/24 for Redmine#37017 ----->>>>>
            String logName = GetLogName();
            bool verFlag = false;
            string errMsg = string.Empty; // ADD 田建委 2013/06/26
            String command = "";
            //String version = RunCmd("java -version", ref verFlag, 0); // DEL 田建委 2013/06/26
            String version = RunCmd("java -version", ref verFlag, 0, errMsg, 2000, 0); // ADD 田建委 2013/06/26
            if (!verFlag)
            {
                if (String.CompareOrdinal(version, "\"1.5.0\"") >= 0)
                {
                    command = "Java dtrcmd";
                }
                else
                {
                    //command = "Java dtrcmd14"; // DEL 田建委 2013/06/26
                    //----- ADD 田建委 2013/06/26 ----->>>>>
                    command = "<1.5.0";
                    return command;
                    //----- ADD 田建委 2013/06/26 -----<<<<<
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
            // ----- ADD zhuhh 2013/06/24 for Redmine#37017 -----<<<<<
            return command;
             
        }

        //----- ADD 田建委 2013/06/26 ------------------------->>>>>
        /// <summary>
        /// DOS Command文字の転換
        /// </summary>
        /// <param name="inputStr">文字</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: コマンドオプションの処理します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2013/06/26</br>
        /// </remarks>
        private string ExchangeString(string inputStr)
        {
            string str = string.Empty;
            str = inputStr.Replace("\"", "\"\"\"");
            str = "\"" + str + "\"";

            return str;
        }
        //----- ADD 田建委 2013/06/26 -------------------------<<<<<

        /// <summary>
        /// コマンドを実行します。
        /// </summary>
        /// <param name="command">コマンド</param>
        /// <param name="errFlag">エラーフラグ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: コマンドを実行します。</br>
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/05/21</br>										
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

        // ----- ADD zhuhh 2013/06/24 for Redmine#37017 ----->>>>>
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/06/24</br>
        /// <br>UpdateNote  : 2013/07/25 田建委</br>
        /// <br>            : Redmine#39145 エラー発生時もS&E売上抽出データ更新した場合がある対応</br>
        /// </remarks>
        //private String RunCmd(String command, ref bool errFlag, int mode) // DEL 田建委 2013/06/26
        private String RunCmd(String command, ref bool errFlag, int mode, string errMsg, int timeout, int retryCnt) // ADD 田建委 2013/06/26
        {
            //string ret = null; // DEL 田建委 2013/06/26
            string ret = errMsg; // ADD 田建委 2013/06/26
            string err = null;
            string otp = null;

            //----- ADD 田建委 2013/06/26 ----->>>>>
            if (retryCnt == -1)
            {
                ret = LOGMSG_TIMEOUTERR;
                return ret;
            }
            //----- ADD 田建委 2013/06/26 -----<<<<<

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

                //----- ADD 田建委 2013/06/26 ----->>>>>
                if (timeout != 0 && !p.WaitForExit(timeout))
                {
                    p.Kill();

                    retryCnt = retryCnt - 1;
                    RunCmd(command, ref errFlag, mode, ret, timeout, retryCnt);
                }
                //----- ADD 田建委 2013/06/26 -----<<<<<
            }
            catch (Exception e)
            {
                e.ToString();
                //----- ADD 田建委 2013/06/26 ----->>>>>
                errFlag = true;
                ret = string.Empty;
                //----- ADD 田建委 2013/06/26 -----<<<<<
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/06/24</br>										
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
        // ----- ADD zhuhh 2013/06/24 for Redmine#37017 -----<<<<<
        // ----- ADD zhuhh 2013/05/21 for Redmine#35639 -----<<<<<

        /// <summary>
        /// 回線オープン処理
        /// </summary>
        /// <param name="connectInfo">条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 回線オープン処理します。</br>
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
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
        /// <br>Programmer	: zhuhh</br>
        /// <br>Date		: 2013/03/06</br>										
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
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011 -----<<<<<
        #endregion ■ Private Method
    }
}
