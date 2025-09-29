//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先一括修正
// プログラム概要   ：得意先の変更を一括で行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2008/11/27     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/07     修正内容：Mantis【13030】領収書出力区分の追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/13     修正内容：Mantis【9494】得意先変動情報の取得処理を修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/01/29     修正内容：Mantis【14950】請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/02/09     修正内容：Mantis【14976】グリッド制御の拡張
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/02/17     修正内容：合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の区分名称を変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/02/24     修正内容：Mantis【15033】伝票印刷区分×5を追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/02/24     修正内容：Mantis【15032】請求書出力区分が表示されてしまう
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/03/02     修正内容：Mantis【14976】グリッド制御の拡張(マウス操作で列移動ができない)
// ---------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// グリッド初期設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : グリッド初期設定を行います。</br>
    /// <br>Programmer : 30414 忍 幸史</br>
    /// <br>Date       : 2008/11/20</br>
    /// </remarks>
    internal class GridInitialSetting
    {
        #region ■ Constants

        // グリッド列
        public const string column_No = "No";
        public const string column_CustomerCode = "CutomerCode";
        public const string column_CustomerSubCode = "CustomerSubCode";
        public const string column_CustomerName = "CustomerName";
        public const string column_CustomerName2 = "CustomerName2";
        public const string column_CustomerSnm = "CustomerSnm";
        public const string column_CustomerKana = "CustomerKana";
        public const string column_HonorificTitle = "HonorificTitle";
        public const string column_OutputName = "OutputName";
        public const string column_MngSectionName = "MngSectionName";
        public const string column_MngSectionGuide = "MngSectionGuide";
        public const string column_CustomerAgentName = "CustomerAgentName";
        public const string column_CustomerAgentGuide = "CustomerAgentGuide";
        public const string column_OldCustomerAgentName = "OldCustomerAgentName";
        public const string column_OldCustomerAgentGuide = "OldCustomerAgentGuide";
        public const string column_CustAgentChgDate = "CustAgentChgDate";
        public const string column_TransStopDate = "TransStopDate";
        public const string column_CarMngDivCd = "CarMngDivCd";
        public const string column_CorporateDivCode = "CorporateDivCode";
        public const string column_AcceptWholeSale = "AcceptWholeSale";
        public const string column_CustomerAttributeDiv = "CustomerAttributeDiv";
        public const string column_CustWarehouseName = "CustWarehouseName";
        public const string column_CustWarehouseGuide = "CustWarehouseGuide";
        public const string column_BusinessTypeName = "BusinessTypeName";
        public const string column_JobTypeName = "JobTypeName";
        public const string column_SalesAreaName = "SalesAreaName";
        public const string column_CustAnalysCode1 = "CustAnalysCode1";
        public const string column_CustAnalysCode2 = "CustAnalysCode2";
        public const string column_CustAnalysCode3 = "CustAnalysCode3";
        public const string column_CustAnalysCode4 = "CustAnalysCode4";
        public const string column_CustAnalysCode5 = "CustAnalysCode5";
        public const string column_CustAnalysCode6 = "CustAnalysCode6";
        public const string column_ClaimSectionSnm = "ClaimSectionSnm";
        public const string column_ClaimSectionGuide = "ClaimSectionGuide";
        public const string column_ClaimSnm = "ClaimSnm";
        public const string column_ClaimGuide = "ClaimGuide";
        public const string column_TotalDay = "TotalDay";
        public const string column_CollectMoneyName = "CollectMoneyName";
        public const string column_CollectMoneyDay = "CollectMoneyDay";
        public const string column_CollectCond = "CollectCond";
        public const string column_CollectSight = "CollectSight";
        public const string column_NTimeCalcStDate = "NTimeCalcStDate";
        public const string column_BillCollecterName = "BillCollecterName";
        public const string column_BillCollecterGuide = "BillCollecterGuide";
        public const string column_CustCTaXLayRefCd = "CustCTaXLayRefCd";
        public const string column_ConsTaxLayMethod = "ConsTaxLayMethod";
        public const string column_CreditMngCode = "CreditMngCode";
        public const string column_CreditMoney = "CreditMoney";     // ADD 2009/04/13
        public const string column_WarningCreditMoney = "WarningCreditMoney";
        public const string column_DepoDelCode = "DepoDelCode";
        public const string column_AccRecDivCd = "AccRecDivCd";
        public const string column_SalesUnPrcFrcProcCd = "SalesUnPrcFrcProcCd";
        public const string column_SalesUnPrcFrcProcGuide = "SalesUnPrcFrcProcGuide";
        public const string column_SalesMoneyFrcProcCd = "SalesMoneyFrcProcCd";
        public const string column_SalesMoneyFrcProcGuide = "SalesMoneyFrcProcGuide";
        public const string column_SalesCnsTaxFrcProcCd = "SalesCnsTaxFrcProcCd";
        public const string column_SalesCnsTaxFrcProcGuide = "SalesCnsTaxFrcProcGuide";
        public const string column_PostNo = "PostNo";
        public const string column_PostNoGuide = "PostNoGuide";
        public const string column_Address1 = "Address1";
        public const string column_Address3 = "Address3";
        public const string column_Address4 = "Address4";
        public const string column_HomeTelNo = "HomeTelNo";
        public const string column_HomeFaxNo = "HomeFaxNo";
        public const string column_OfficeTelNo = "OfficeTelNo";
        public const string column_PortableTelNo = "PortableTelNo";
        public const string column_OfficeFaxNo = "OfficeFaxNo";
        public const string column_OthersTelNo = "OthersTelNo";
        public const string column_SearchTelNo = "SearchTelNo";
        public const string column_MainContactCode = "MainContactCode";
        public const string column_CustomerAgent = "CustomerAgent";
        public const string column_MainSendMailAddrCd = "MainSendMailAddrCd";
        public const string column_MailAddress1 = "MailAddress1";
        public const string column_MailSendCode1 = "MailSendCode1";
        public const string column_MailAddrKindCode1 = "MailAddrKindCode1";
        public const string column_MailAddress2 = "MailAddress2";
        public const string column_MailSendCode2 = "MailSendCode2";
        public const string column_MailAddrKindCode2 = "MailAddrKindCode2";
        public const string column_ReceiptOutputCode = "ReceiptOutputCode";     // ADD 2009/04/07
        public const string column_BillOutputCode = "BillOutputCode";   // TODO:使用しない…請求書出力区分コード

        // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ---------->>>>>
        public const string column_SalesSlipPrtDiv  = "SalesSlipPrtDiv";    // 納品書出力（売上伝票発行区分）
        public const string column_AcpOdrrSlipPrtDiv= "AcpOdrrSlipPrtDiv";  // 受注伝票出力（受注伝票発行区分）
        public const string column_ShipmSlipPrtDiv  = "ShipmSlipPrtDiv";    // 貸出伝票出力（出荷伝票発行区分）
        public const string column_EstimatePrtDiv   = "EstimatePrtDiv";     // 見積伝票出力（見積伝票発行区分）
        public const string column_UOESlipPrtDiv    = "UOESlipPrtDiv";      // UOE伝票出力（UOE伝票発行区分）
        // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ----------<<<<<

        // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
        public const string column_TotalBillOutputDiv   = "TotalBillOutputDiv";     // 合計請求書出力
        public const string column_DetailBillOutputCode = "DetailBillOutputCode";   // 明細請求書出力
        public const string column_SlipTtlBillOutputDiv = "SlipTtlBillOutputDiv";   // 伝票合計請求書出力
        // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

        public const string column_DmOutCode = "DmOutCode";
        public const string column_CustSlipNoMngCd = "CustSlipNoMngCd";
        public const string column_CustomerSlipNoDiv = "CustomerSlipNoDiv";
        public const string column_QrcodePrtCd = "QrcodePrtCd";

        public int depositStKindCd1 = 0;

        #endregion ■ Constants


        #region ■ Private Members

        private UserGuideAcs _userGuideAcs;
        private AlItmDspNmAcs _alItmDspNmAcs;
        private DepositStAcs _depositStAcs;
        private MoneyKindAcs _moneyKindAcs;

        private AlItmDspNm _alItmDspNm;
        private DepositSt _depositSt;
        private Dictionary<int, string> _jobTypeDic;
        private Dictionary<int, string> _businessTypeDic;
        private Dictionary<int, string> _salesAreaDic;
        private Dictionary<int, MoneyKind> _moneyKindDic;

        #endregion ■ Private Members


        #region ■ Constructor

        /// <summary>
        /// グリッド初期設定クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド初期設定クラスのインスタンスを作成します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public GridInitialSetting()
        {
            this._userGuideAcs = new UserGuideAcs();
            this._alItmDspNmAcs = new AlItmDspNmAcs();
            this._depositStAcs = new DepositStAcs();
            this._moneyKindAcs = new MoneyKindAcs();

            // マスタ読込
            ReadAlItmDspNm();
            ReadJobTypeCode();
            ReadBusinessTypeCode();
            ReadSalesAreaCode();
            ReadDepositSt();
            ReadMoneyKind();
        }

        #endregion ■ Constructor


        #region ■ Properties

        public AlItmDspNm AlItmDspNm
        {
            get { return this._alItmDspNm; }
        }

        public Dictionary<int, string> JobTypeDic
        {
            get { return this._jobTypeDic; }
        }

        public Dictionary<int, string> BusinessTypeDic
        {
            get { return this._businessTypeDic; }
        }

        public Dictionary<int, string> SalesAreaDic
        {
            get { return this._salesAreaDic; }
        }

        #endregion ■ Properties


        #region ■ Public Methods

        /// <summary>
        /// グリッド列作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド列を作成します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public DataTable CreateColumn()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add(column_No, typeof(int));
            dataTable.Columns.Add(column_CustomerCode, typeof(string));
            dataTable.Columns.Add(column_CustomerSubCode, typeof(string));
            dataTable.Columns.Add(column_CustomerName, typeof(string));
            dataTable.Columns.Add(column_CustomerName2, typeof(string));
            dataTable.Columns.Add(column_CustomerSnm, typeof(string));
            dataTable.Columns.Add(column_CustomerKana, typeof(string));
            dataTable.Columns.Add(column_HonorificTitle, typeof(string));
            dataTable.Columns.Add(column_OutputName, typeof(int));
            dataTable.Columns.Add(column_MngSectionName, typeof(string));
            dataTable.Columns.Add(column_MngSectionGuide, typeof(string));
            dataTable.Columns.Add(column_CustomerAgentName, typeof(string));
            dataTable.Columns.Add(column_CustomerAgentGuide, typeof(string));
            dataTable.Columns.Add(column_OldCustomerAgentName, typeof(string));
            dataTable.Columns.Add(column_OldCustomerAgentGuide, typeof(string));
            dataTable.Columns.Add(column_CustAgentChgDate, typeof(DateTime));
            dataTable.Columns.Add(column_TransStopDate, typeof(DateTime));
            dataTable.Columns.Add(column_CarMngDivCd, typeof(int));
            dataTable.Columns.Add(column_CorporateDivCode, typeof(int));
            dataTable.Columns.Add(column_AcceptWholeSale, typeof(int));
            dataTable.Columns.Add(column_CustomerAttributeDiv, typeof(int));
            dataTable.Columns.Add(column_CustWarehouseName, typeof(string));
            dataTable.Columns.Add(column_CustWarehouseGuide, typeof(string));
            dataTable.Columns.Add(column_BusinessTypeName, typeof(int));
            dataTable.Columns.Add(column_JobTypeName, typeof(int));
            dataTable.Columns.Add(column_SalesAreaName, typeof(int));
            dataTable.Columns.Add(column_CustAnalysCode1, typeof(int));
            dataTable.Columns.Add(column_CustAnalysCode2, typeof(int));
            dataTable.Columns.Add(column_CustAnalysCode3, typeof(int));
            dataTable.Columns.Add(column_CustAnalysCode4, typeof(int));
            dataTable.Columns.Add(column_CustAnalysCode5, typeof(int));
            dataTable.Columns.Add(column_CustAnalysCode6, typeof(int));
            dataTable.Columns.Add(column_ClaimSectionSnm, typeof(string));
            dataTable.Columns.Add(column_ClaimSectionGuide, typeof(string));
            dataTable.Columns.Add(column_ClaimSnm, typeof(string));
            dataTable.Columns.Add(column_ClaimGuide, typeof(string));
            dataTable.Columns.Add(column_TotalDay, typeof(int));
            dataTable.Columns.Add(column_CollectMoneyName, typeof(int));
            dataTable.Columns.Add(column_CollectMoneyDay, typeof(int));
            dataTable.Columns.Add(column_CollectCond, typeof(int));
            dataTable.Columns.Add(column_CollectSight, typeof(int));
            dataTable.Columns.Add(column_NTimeCalcStDate, typeof(int));
            dataTable.Columns.Add(column_BillCollecterName, typeof(string));
            dataTable.Columns.Add(column_BillCollecterGuide, typeof(string));
            dataTable.Columns.Add(column_CustCTaXLayRefCd, typeof(int));
            dataTable.Columns.Add(column_ConsTaxLayMethod, typeof(int));
            dataTable.Columns.Add(column_CreditMngCode, typeof(int));
            dataTable.Columns.Add(column_CreditMoney, typeof(string));      // ADD 2009/04/13
            dataTable.Columns.Add(column_WarningCreditMoney, typeof(string));
            dataTable.Columns.Add(column_DepoDelCode, typeof(int));
            dataTable.Columns.Add(column_AccRecDivCd, typeof(int));
            dataTable.Columns.Add(column_SalesUnPrcFrcProcCd, typeof(int));
            dataTable.Columns.Add(column_SalesUnPrcFrcProcGuide, typeof(string));
            dataTable.Columns.Add(column_SalesMoneyFrcProcCd, typeof(int));
            dataTable.Columns.Add(column_SalesMoneyFrcProcGuide, typeof(string));
            dataTable.Columns.Add(column_SalesCnsTaxFrcProcCd, typeof(int));
            dataTable.Columns.Add(column_SalesCnsTaxFrcProcGuide, typeof(string));
            dataTable.Columns.Add(column_PostNo, typeof(string));
            dataTable.Columns.Add(column_PostNoGuide, typeof(string));
            dataTable.Columns.Add(column_Address1, typeof(string));
            dataTable.Columns.Add(column_Address3, typeof(string));
            dataTable.Columns.Add(column_Address4, typeof(string));
            dataTable.Columns.Add(column_HomeTelNo, typeof(string));
            dataTable.Columns.Add(column_HomeFaxNo, typeof(string));
            dataTable.Columns.Add(column_OfficeTelNo, typeof(string));
            dataTable.Columns.Add(column_PortableTelNo, typeof(string));
            dataTable.Columns.Add(column_OfficeFaxNo, typeof(string));
            dataTable.Columns.Add(column_OthersTelNo, typeof(string));
            dataTable.Columns.Add(column_SearchTelNo, typeof(string));
            dataTable.Columns.Add(column_MainContactCode, typeof(int));
            dataTable.Columns.Add(column_CustomerAgent, typeof(string));
            dataTable.Columns.Add(column_MainSendMailAddrCd, typeof(int));
            dataTable.Columns.Add(column_MailAddress1, typeof(string));
            dataTable.Columns.Add(column_MailSendCode1, typeof(int));
            dataTable.Columns.Add(column_MailAddrKindCode1, typeof(int));
            dataTable.Columns.Add(column_MailAddress2, typeof(string));
            dataTable.Columns.Add(column_MailSendCode2, typeof(int));
            dataTable.Columns.Add(column_MailAddrKindCode2, typeof(int));
            dataTable.Columns.Add(column_ReceiptOutputCode, typeof(int));   // ADD 2009/04/07
            dataTable.Columns.Add(column_BillOutputCode, typeof(int));  // TODO:使用しない…請求書出力区分コード

            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ---------->>>>>
            dataTable.Columns.Add(column_SalesSlipPrtDiv, typeof(int));     // 納品書出力（売上伝票発行区分）
            dataTable.Columns.Add(column_AcpOdrrSlipPrtDiv, typeof(int));   // 受注伝票出力（受注伝票発行区分）
            dataTable.Columns.Add(column_ShipmSlipPrtDiv, typeof(int));     // 貸出伝票出力（出荷伝票発行区分）
            dataTable.Columns.Add(column_EstimatePrtDiv, typeof(int));      // 見積伝票出力（見積伝票発行区分）
            dataTable.Columns.Add(column_UOESlipPrtDiv, typeof(int));       // UOE伝票出力（UOE伝票発行区分）
            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ----------<<<<<

            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
            dataTable.Columns.Add(column_TotalBillOutputDiv, typeof(int));  // 合計請求書出力
            dataTable.Columns.Add(column_DetailBillOutputCode, typeof(int));// 明細請求書出力
            dataTable.Columns.Add(column_SlipTtlBillOutputDiv, typeof(int));// 伝票合計請求書出力
            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

            dataTable.Columns.Add(column_DmOutCode, typeof(int));
            dataTable.Columns.Add(column_CustSlipNoMngCd, typeof(int));
            dataTable.Columns.Add(column_CustomerSlipNoDiv, typeof(int));
            dataTable.Columns.Add(column_QrcodePrtCd, typeof(int));

            return dataTable;
        }

        /// <summary>
        /// TODO:グリッド初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド初期設定を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public void SetGridInitialLayout(ref UltraGrid uGrid)
        {
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…列交換、列固定、行フィルタを可能にする ---------->>>>>
            // 列交換を可能にする
            uGrid.DisplayLayout.Override.AllowColMoving = AllowColMoving.Default;   // ADD 2010/03/02 Mantis【14976】グリッド制御の拡張(マウス操作で列移動ができない)
            uGrid.DisplayLayout.Override.AllowColSwapping = AllowColSwapping.WithinGroup;
            // 列固定を可能にする
            uGrid.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.Button;
            // 行フィルタを可能にする
            uGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…列交換、列固定、行フィルタを可能にする ----------<<<<<

            if (uGrid.DisplayLayout.Bands[0].Columns.Count == 0)
            {
                uGrid.DataSource = CreateColumn();
            }

            ColumnsCollection columns = uGrid.DisplayLayout.Bands[0].Columns;

            //--------------------------------------
            // 固定ヘッダー
            //--------------------------------------
            columns[column_No].Header.Fixed = true;
            columns[column_CustomerCode].Header.Fixed = true;

            //--------------------------------------
            // 入力不可
            //--------------------------------------
            columns[column_No].CellActivation = Activation.Disabled;
            columns[column_CustomerCode].CellActivation = Activation.Disabled;

            //--------------------------------------
            // セルカラー
            //--------------------------------------
            columns[column_No].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            columns[column_No].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            columns[column_No].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[column_No].CellAppearance.ForeColor = Color.White;
            columns[column_No].CellAppearance.ForeColorDisabled = Color.White;

            for (int index = 2; index < columns.Count; index++)
            {
                columns[index].CellAppearance.BackColorDisabled = Color.Gainsboro;
            }

            //--------------------------------------
            // キャプション
            //--------------------------------------
            columns[column_No].Header.Caption = "No.";
            columns[column_CustomerCode].Header.Caption = "得意先ｺｰﾄﾞ";
            columns[column_CustomerSubCode].Header.Caption = "ｻﾌﾞｺｰﾄﾞ";
            columns[column_CustomerName].Header.Caption = "得意先名1";
            columns[column_CustomerName2].Header.Caption = "得意先名2";
            columns[column_CustomerSnm].Header.Caption = "得意先略称";
            columns[column_CustomerKana].Header.Caption = "得意先名(ｶﾅ)";
            columns[column_HonorificTitle].Header.Caption = "敬称";
            columns[column_OutputName].Header.Caption = "諸口";
            columns[column_MngSectionName].Header.Caption = "管理拠点";
            columns[column_MngSectionGuide].Header.Caption = "";
            columns[column_CustomerAgentName].Header.Caption = "得意先担当";
            columns[column_CustomerAgentGuide].Header.Caption = "";
            columns[column_OldCustomerAgentName].Header.Caption = "旧担当";
            columns[column_OldCustomerAgentGuide].Header.Caption = "";
            columns[column_CustAgentChgDate].Header.Caption = "担当者変更日";
            columns[column_TransStopDate].Header.Caption = "取引中止日";
            columns[column_CarMngDivCd].Header.Caption = "車輌管理";
            columns[column_CorporateDivCode].Header.Caption = "個人・法人";
            columns[column_AcceptWholeSale].Header.Caption = "得意先種別";
            columns[column_CustomerAttributeDiv].Header.Caption = "得意先属性";
            columns[column_CustWarehouseName].Header.Caption = "優先倉庫";
            columns[column_CustWarehouseGuide].Header.Caption = "";
            columns[column_BusinessTypeName].Header.Caption = "業種";
            columns[column_JobTypeName].Header.Caption = "職種";
            columns[column_SalesAreaName].Header.Caption = "地区";
            columns[column_CustAnalysCode1].Header.Caption = "分析ｺｰﾄﾞ1";
            columns[column_CustAnalysCode2].Header.Caption = "分析ｺｰﾄﾞ2";
            columns[column_CustAnalysCode3].Header.Caption = "分析ｺｰﾄﾞ3";
            columns[column_CustAnalysCode4].Header.Caption = "分析ｺｰﾄﾞ4";
            columns[column_CustAnalysCode5].Header.Caption = "分析ｺｰﾄﾞ5";
            columns[column_CustAnalysCode6].Header.Caption = "分析ｺｰﾄﾞ6";
            columns[column_ClaimSectionSnm].Header.Caption = "請求拠点";
            columns[column_ClaimSectionGuide].Header.Caption = "";
            columns[column_ClaimSnm].Header.Caption = "請求先ｺｰﾄﾞ";
            columns[column_ClaimGuide].Header.Caption = "";
            columns[column_TotalDay].Header.Caption = "締日";
            columns[column_CollectMoneyName].Header.Caption = "集金月";
            columns[column_CollectMoneyDay].Header.Caption = "集金日";
            columns[column_CollectCond].Header.Caption = "回収条件";
            columns[column_CollectSight].Header.Caption = "回収ｻｲﾄ";
            columns[column_NTimeCalcStDate].Header.Caption = "次回勘定";
            columns[column_BillCollecterName].Header.Caption = "集金担当";
            columns[column_BillCollecterGuide].Header.Caption = "";
            columns[column_CustCTaXLayRefCd].Header.Caption = "転嫁方式参照";
            columns[column_ConsTaxLayMethod].Header.Caption = "消費税転嫁方式";
            columns[column_CreditMngCode].Header.Caption = "与信管理";
            columns[column_CreditMoney].Header.Caption = "与信額";      // ADD 2009/04/13
            columns[column_WarningCreditMoney].Header.Caption = "警告与信額";
            columns[column_DepoDelCode].Header.Caption = "入金消込";
            columns[column_AccRecDivCd].Header.Caption = "売掛区分";
            columns[column_SalesUnPrcFrcProcCd].Header.Caption = "単価端数";
            columns[column_SalesUnPrcFrcProcGuide].Header.Caption = "";
            columns[column_SalesMoneyFrcProcCd].Header.Caption = "金額端数";
            columns[column_SalesMoneyFrcProcGuide].Header.Caption = "";
            columns[column_SalesCnsTaxFrcProcCd].Header.Caption = "税端数";
            columns[column_SalesCnsTaxFrcProcGuide].Header.Caption = "";
            columns[column_PostNo].Header.Caption = "郵便番号";
            columns[column_PostNoGuide].Header.Caption = "";
            columns[column_Address1].Header.Caption = "住所1";
            columns[column_Address3].Header.Caption = "住所2";
            columns[column_Address4].Header.Caption = "住所3";
            columns[column_HomeTelNo].Header.Caption = this._alItmDspNm.HomeTelNoDspName.Trim();
            columns[column_HomeFaxNo].Header.Caption = this._alItmDspNm.HomeFaxNoDspName.Trim();
            columns[column_OfficeTelNo].Header.Caption = this._alItmDspNm.OfficeTelNoDspName.Trim();
            columns[column_PortableTelNo].Header.Caption = this._alItmDspNm.MobileTelNoDspName.Trim();
            columns[column_OfficeFaxNo].Header.Caption = this._alItmDspNm.OfficeFaxNoDspName.Trim();
            columns[column_OthersTelNo].Header.Caption = this._alItmDspNm.OtherTelNoDspName.Trim();
            columns[column_SearchTelNo].Header.Caption = "検索番号";
            columns[column_MainContactCode].Header.Caption = "主連絡先";
            columns[column_CustomerAgent].Header.Caption = "得意先担当者";
            columns[column_MainSendMailAddrCd].Header.Caption = "主送信先";
            columns[column_MailAddress1].Header.Caption = "ﾒｰﾙｱﾄﾞﾚｽ1";
            columns[column_MailSendCode1].Header.Caption = "ﾒｰﾙ区分1";
            columns[column_MailAddrKindCode1].Header.Caption = "ﾒｰﾙ種別1";
            columns[column_MailAddress2].Header.Caption = "ﾒｰﾙｱﾄﾞﾚｽ2";
            columns[column_MailSendCode2].Header.Caption = "ﾒｰﾙ区分2";
            columns[column_MailAddrKindCode2].Header.Caption = "ﾒｰﾙ種別2";
            columns[column_ReceiptOutputCode].Header.Caption = "領収書出力";    // ADD 2009/04/07
            columns[column_BillOutputCode].Header.Caption = "請求書出力";   // TODO:使用しない…請求書出力区分コード

            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ---------->>>>>
            columns[column_SalesSlipPrtDiv].Header.Caption  = "納品書出力";     // 納品書出力（売上伝票発行区分）
            columns[column_AcpOdrrSlipPrtDiv].Header.Caption= "受注伝票出力";   // 受注伝票出力（受注伝票発行区分）
            columns[column_ShipmSlipPrtDiv].Header.Caption  = "貸出伝票出力";   // 貸出伝票出力（出荷伝票発行区分）
            columns[column_EstimatePrtDiv].Header.Caption   = "見積伝票出力";   // 見積伝票出力（見積伝票発行区分）
            columns[column_UOESlipPrtDiv].Header.Caption    = "UOE伝票出力";    // UOE伝票出力（UOE伝票発行区分）
            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ----------<<<<<

            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
            columns[column_TotalBillOutputDiv].Header.Caption   = "合計請求書出力";
            columns[column_DetailBillOutputCode].Header.Caption = "明細請求書出力";
            columns[column_SlipTtlBillOutputDiv].Header.Caption = "伝票合計請求書出力";
            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

//            columns[column_DmOutCode].Header.Caption = "DM出力"; // DEL 2022/03/04 田村顕成 電子帳簿連携対応
            columns[column_DmOutCode].Header.Caption = "電子帳簿出力"; // ADD 2022/03/04 田村顕成 電子帳簿連携対応
            columns[column_CustSlipNoMngCd].Header.Caption = "相手伝番管理";
            columns[column_CustomerSlipNoDiv].Header.Caption = "伝番区分";
            columns[column_QrcodePrtCd].Header.Caption = "QRｺｰﾄﾞ印刷";

            //--------------------------------------
            // 列幅
            //--------------------------------------
            columns[column_No].Width = 45;
            columns[column_CustomerCode].Width = 90;
            columns[column_CustomerSubCode].Width = 170;
            columns[column_CustomerName].Width = 490;
            columns[column_CustomerName2].Width = 490;
            columns[column_CustomerSnm].Width = 330;
            columns[column_CustomerKana].Width = 250;
            columns[column_HonorificTitle].Width = 80;
            columns[column_OutputName].Width = 140;
            columns[column_MngSectionName].Width = 110;
            columns[column_MngSectionGuide].Width = 24;
            columns[column_CustomerAgentName].Width = 140;
            columns[column_CustomerAgentGuide].Width = 24;
            columns[column_OldCustomerAgentName].Width = 140;
            columns[column_OldCustomerAgentGuide].Width = 24;
            columns[column_CustAgentChgDate].Width = 130;
            columns[column_TransStopDate].Width = 130;
            columns[column_CarMngDivCd].Width = 105;
            columns[column_CorporateDivCode].Width = 90;
            columns[column_AcceptWholeSale].Width = 95;
            columns[column_CustomerAttributeDiv].Width = 105;
            columns[column_CustWarehouseName].Width = 140;
            columns[column_CustWarehouseGuide].Width = 24;
            columns[column_BusinessTypeName].Width = 140;
            columns[column_JobTypeName].Width = 140;
            columns[column_SalesAreaName].Width = 140;
            columns[column_CustAnalysCode1].Width = 85;
            columns[column_CustAnalysCode2].Width = 85;
            columns[column_CustAnalysCode3].Width = 85;
            columns[column_CustAnalysCode4].Width = 85;
            columns[column_CustAnalysCode5].Width = 85;
            columns[column_CustAnalysCode6].Width = 85;
            columns[column_ClaimSectionSnm].Width = 110;
            columns[column_ClaimSectionGuide].Width = 24;
            columns[column_ClaimSnm].Width = 140;
            columns[column_ClaimGuide].Width = 24;
            columns[column_TotalDay].Width = 50;
            columns[column_CollectMoneyName].Width = 90;
            columns[column_CollectMoneyDay].Width = 60;
            columns[column_CollectCond].Width = 80;
            columns[column_CollectSight].Width = 75;
            columns[column_NTimeCalcStDate].Width = 70;
            columns[column_BillCollecterName].Width = 140;
            columns[column_BillCollecterGuide].Width = 24;
            columns[column_CustCTaXLayRefCd].Width = 120;
            columns[column_ConsTaxLayMethod].Width = 120;
            columns[column_CreditMngCode].Width = 80;
            columns[column_CreditMoney].Width = 110;        // ADD 2009/04/13
            columns[column_WarningCreditMoney].Width = 110;
            columns[column_DepoDelCode].Width = 80;
            columns[column_AccRecDivCd].Width = 90;
            columns[column_SalesUnPrcFrcProcCd].Width = 80;
            columns[column_SalesUnPrcFrcProcGuide].Width = 24;
            columns[column_SalesMoneyFrcProcCd].Width = 80;
            columns[column_SalesMoneyFrcProcGuide].Width = 24;
            columns[column_SalesCnsTaxFrcProcCd].Width = 80;
            columns[column_SalesCnsTaxFrcProcGuide].Width = 24;
            columns[column_PostNo].Width = 90;
            columns[column_PostNoGuide].Width = 24;
            columns[column_Address1].Width = 490;
            columns[column_Address3].Width = 360;
            columns[column_Address4].Width = 490;
            columns[column_HomeTelNo].Width = 135;
            columns[column_HomeFaxNo].Width = 135;
            columns[column_OfficeTelNo].Width = 135;
            columns[column_PortableTelNo].Width = 135;
            columns[column_OfficeFaxNo].Width = 135;
            columns[column_OthersTelNo].Width = 135;
            columns[column_SearchTelNo].Width = 75;
            columns[column_MainContactCode].Width = 135;
            columns[column_CustomerAgent].Width = 330;
            columns[column_MainSendMailAddrCd].Width = 100;
            columns[column_MailAddress1].Width = 520;
            columns[column_MailSendCode1].Width = 110;
            columns[column_MailAddrKindCode1].Width = 90;
            columns[column_MailAddress2].Width = 520;
            columns[column_MailSendCode2].Width = 110;
            columns[column_MailAddrKindCode2].Width = 90;
            columns[column_ReceiptOutputCode].Width = 95;   // ADD 2009/04/07
            columns[column_BillOutputCode].Width = 95;  // TODO:使用しない…請求書出力区分コード

            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ---------->>>>>
            columns[column_SalesSlipPrtDiv].Width   = 150;  // 納品書出力（売上伝票発行区分）
            columns[column_AcpOdrrSlipPrtDiv].Width = 150;  // 受注伝票出力（受注伝票発行区分）
            columns[column_ShipmSlipPrtDiv].Width   = 150;  // 貸出伝票出力（出荷伝票発行区分）
            columns[column_EstimatePrtDiv].Width    = 150;  // 見積伝票出力（見積伝票発行区分）
            columns[column_UOESlipPrtDiv].Width     = 150;  // UOE伝票出力（UOE伝票発行区分）
            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ----------<<<<<

            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
            columns[column_TotalBillOutputDiv].Width    = 150;  // 合計請求書出力
            columns[column_DetailBillOutputCode].Width  = 150;  // 明細請求書出力
            columns[column_SlipTtlBillOutputDiv].Width  = 150;  // 伝票合計請求書出力
            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

            columns[column_DmOutCode].Width = 80;
            columns[column_CustSlipNoMngCd].Width = 120;
            columns[column_CustomerSlipNoDiv].Width = 110;
            columns[column_QrcodePrtCd].Width = 110;

            //--------------------------------------
            // 入力桁数
            //--------------------------------------
            columns[column_No].MaxLength = 4;
            columns[column_CustomerCode].MaxLength = 8;
            columns[column_CustomerSubCode].MaxLength = 20;
            columns[column_CustomerName].MaxLength = 30;
            columns[column_CustomerName2].MaxLength = 30;
            columns[column_CustomerSnm].MaxLength = 20;
            columns[column_CustomerKana].MaxLength = 30;
            columns[column_HonorificTitle].MaxLength = 4;
            columns[column_MngSectionName].MaxLength = 2;
            columns[column_CustomerAgentName].MaxLength = 4;
            columns[column_OldCustomerAgentName].MaxLength = 4;
            columns[column_CustWarehouseName].MaxLength = 4;
            columns[column_CustAnalysCode1].MaxLength = 3;
            columns[column_CustAnalysCode2].MaxLength = 3;
            columns[column_CustAnalysCode3].MaxLength = 3;
            columns[column_CustAnalysCode4].MaxLength = 3;
            columns[column_CustAnalysCode5].MaxLength = 3;
            columns[column_CustAnalysCode6].MaxLength = 3;
            columns[column_ClaimSectionSnm].MaxLength = 2;
            columns[column_ClaimSnm].MaxLength = 8;
            columns[column_TotalDay].MaxLength = 2;
            columns[column_CollectMoneyDay].MaxLength = 2;
            columns[column_CollectSight].MaxLength = 3;
            columns[column_NTimeCalcStDate].MaxLength = 2;
            columns[column_BillCollecterName].MaxLength = 4;
            columns[column_CreditMoney].MaxLength = 10;     // ADD 2009/04/13
            columns[column_WarningCreditMoney].MaxLength = 10;
            columns[column_SalesUnPrcFrcProcCd].MaxLength = 8;
            columns[column_SalesMoneyFrcProcCd].MaxLength = 8;
            columns[column_SalesCnsTaxFrcProcCd].MaxLength = 8;
            columns[column_PostNo].MaxLength = 10;
            columns[column_Address1].MaxLength = 30;
            columns[column_Address3].MaxLength = 22;
            columns[column_Address4].MaxLength = 30;
            columns[column_HomeTelNo].MaxLength = 16;
            columns[column_HomeFaxNo].MaxLength = 16;
            columns[column_OfficeTelNo].MaxLength = 16;
            columns[column_PortableTelNo].MaxLength = 16;
            columns[column_OfficeFaxNo].MaxLength = 16;
            columns[column_OthersTelNo].MaxLength = 16;
            columns[column_SearchTelNo].MaxLength = 4;
            columns[column_CustomerAgent].MaxLength = 20;
            columns[column_MailAddress1].MaxLength = 64;
            columns[column_MailAddress2].MaxLength = 64;

            //--------------------------------------
            // テキスト位置(HAlign)
            //--------------------------------------
            columns[column_No].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CustomerCode].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CustomerSubCode].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustomerName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustomerName2].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustomerSnm].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustomerKana].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_HonorificTitle].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_OutputName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MngSectionName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MngSectionGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_CustomerAgentName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustomerAgentGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_OldCustomerAgentName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_OldCustomerAgentGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_CustAgentChgDate].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_TransStopDate].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CarMngDivCd].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CorporateDivCode].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_AcceptWholeSale].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustomerAttributeDiv].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustWarehouseName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustWarehouseGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_BusinessTypeName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_JobTypeName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_SalesAreaName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustAnalysCode1].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CustAnalysCode2].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CustAnalysCode3].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CustAnalysCode4].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CustAnalysCode5].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CustAnalysCode6].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_ClaimSectionSnm].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_ClaimSectionGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_ClaimSnm].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_ClaimGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_TotalDay].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CollectMoneyName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CollectMoneyDay].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CollectCond].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CollectSight].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_NTimeCalcStDate].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_BillCollecterName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_BillCollecterGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_CustCTaXLayRefCd].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_ConsTaxLayMethod].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CreditMngCode].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CreditMoney].CellAppearance.TextHAlign = HAlign.Right;       // ADD 2009/04/13
            columns[column_WarningCreditMoney].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_DepoDelCode].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_AccRecDivCd].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_SalesUnPrcFrcProcCd].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_SalesUnPrcFrcProcGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_SalesMoneyFrcProcCd].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_SalesMoneyFrcProcGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_SalesCnsTaxFrcProcCd].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_SalesCnsTaxFrcProcGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_PostNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_PostNoGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_Address1].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_Address3].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_Address4].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_HomeTelNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_HomeFaxNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_OfficeTelNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_PortableTelNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_OfficeFaxNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_OthersTelNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_SearchTelNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MainContactCode].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustomerAgent].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MainSendMailAddrCd].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MailAddress1].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MailSendCode1].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MailAddrKindCode1].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MailAddress2].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MailSendCode2].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MailAddrKindCode2].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_ReceiptOutputCode].CellAppearance.TextHAlign = HAlign.Left;      // ADD 2009/04/07
            columns[column_BillOutputCode].CellAppearance.TextHAlign = HAlign.Left; // TODO:使用しない…請求書出力区分コード

            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ---------->>>>>
            columns[column_SalesSlipPrtDiv].CellAppearance.TextHAlign   = HAlign.Left;  // 納品書出力（売上伝票発行区分）
            columns[column_AcpOdrrSlipPrtDiv].CellAppearance.TextHAlign = HAlign.Left;  // 受注伝票出力（受注伝票発行区分）
            columns[column_ShipmSlipPrtDiv].CellAppearance.TextHAlign   = HAlign.Left;  // 貸出伝票出力（出荷伝票発行区分）
            columns[column_EstimatePrtDiv].CellAppearance.TextHAlign    = HAlign.Left;  // 見積伝票出力（見積伝票発行区分）
            columns[column_UOESlipPrtDiv].CellAppearance.TextHAlign     = HAlign.Left;  // UOE伝票出力（UOE伝票発行区分）
            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ----------<<<<<

            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
            columns[column_TotalBillOutputDiv].CellAppearance.TextHAlign    = HAlign.Left;  // 合計請求書出力
            columns[column_DetailBillOutputCode].CellAppearance.TextHAlign  = HAlign.Left;  // 明細請求書出力
            columns[column_SlipTtlBillOutputDiv].CellAppearance.TextHAlign  = HAlign.Left;  // 伝票合計請求書出力
            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

            columns[column_DmOutCode].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustSlipNoMngCd].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustomerSlipNoDiv].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_QrcodePrtCd].CellAppearance.TextHAlign = HAlign.Left;

            //--------------------------------------
            // テキスト位置(VAlign)
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellAppearance.TextVAlign = VAlign.Middle;
            }

            //--------------------------------------
            // 日付コントロール設定
            //--------------------------------------
            columns[column_CustAgentChgDate].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            columns[column_TransStopDate].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;

            columns[column_CustAgentChgDate].CellDisplayStyle = CellDisplayStyle.FormattedText;
            columns[column_TransStopDate].CellDisplayStyle = CellDisplayStyle.FormattedText;

            columns[column_CustAgentChgDate].Format = "yyyy年MM月dd日";
            columns[column_TransStopDate].Format = "yyyy年MM月dd日";

            //--------------------------------------
            // ガイドボタン設定
            //--------------------------------------
            Image guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            columns[column_MngSectionGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_CustomerAgentGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_OldCustomerAgentGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_CustWarehouseGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_ClaimSectionGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_ClaimGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_BillCollecterGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_SalesUnPrcFrcProcGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_SalesMoneyFrcProcGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_SalesCnsTaxFrcProcGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_PostNoGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;

            columns[column_MngSectionGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_CustomerAgentGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_OldCustomerAgentGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_CustWarehouseGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_ClaimSectionGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_ClaimGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_BillCollecterGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_SalesUnPrcFrcProcGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_SalesMoneyFrcProcGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_SalesCnsTaxFrcProcGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_PostNoGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;

            columns[column_MngSectionGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_CustomerAgentGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_OldCustomerAgentGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_CustWarehouseGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_ClaimSectionGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_ClaimGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_BillCollecterGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_SalesUnPrcFrcProcGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_SalesMoneyFrcProcGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_SalesCnsTaxFrcProcGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_PostNoGuide].CellButtonAppearance.Image = guideButtonImage;

            columns[column_MngSectionGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_CustomerAgentGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_OldCustomerAgentGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_CustWarehouseGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_ClaimSectionGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_ClaimGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_BillCollecterGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_SalesUnPrcFrcProcGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_SalesMoneyFrcProcGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_SalesCnsTaxFrcProcGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_PostNoGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;

            columns[column_MngSectionGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_CustomerAgentGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_OldCustomerAgentGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_CustWarehouseGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_ClaimSectionGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_ClaimGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_BillCollecterGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_SalesUnPrcFrcProcGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_SalesMoneyFrcProcGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_SalesCnsTaxFrcProcGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_PostNoGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;

            columns[column_MngSectionGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_CustomerAgentGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_OldCustomerAgentGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_CustWarehouseGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_ClaimSectionGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_ClaimGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_BillCollecterGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_SalesUnPrcFrcProcGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_SalesMoneyFrcProcGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_SalesCnsTaxFrcProcGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_PostNoGuide].CellAppearance.Cursor = Cursors.Hand;

            //--------------------------------------
            // コンボボックス設定
            //--------------------------------------
            ValueList valueList = new ValueList();
            valueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

            // FIXME:016.諸口
            #region 諸口

            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Clear();
            //valueList.ValueListItems.Add(0, "得意先名称1・2");
            //valueList.ValueListItems.Add(1, "得意先名称1");
            //valueList.ValueListItems.Add(2, "得意先名称2");
            //valueList.ValueListItems.Add(3, "諸口名称");
            // columns[column_OutputName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:得意先名称1・2");
            valueList.ValueListItems.Add(1, "1:得意先名称1");
            valueList.ValueListItems.Add(2, "2:得意先名称2");
            valueList.ValueListItems.Add(3, "3:諸口名称");
            columns[column_OutputName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_OutputName].ValueList = valueList.Clone();
            
            #endregion // 諸口

            // FIXME:090.車輌管理
            #region 車輌管理

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "しない");
            //valueList.ValueListItems.Add(1, "登録(確認)");
            //valueList.ValueListItems.Add(2, "登録(自動)");
            //valueList.ValueListItems.Add(3, "登録無");
            //columns[column_CarMngDivCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:しない");
            valueList.ValueListItems.Add(1, "1:登録(確認)");
            valueList.ValueListItems.Add(2, "2:登録(自動)");
            valueList.ValueListItems.Add(3, "3:登録無");
            columns[column_CarMngDivCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_CarMngDivCd].ValueList = valueList.Clone();

            #endregion // 車輌管理

            // FIXME:018.個人・法人
            #region 個人・法人

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "個人");
            //valueList.ValueListItems.Add(1, "法人");
            //valueList.ValueListItems.Add(2, "大口法人");
            //valueList.ValueListItems.Add(3, "業者");
            //valueList.ValueListItems.Add(4, "社員");
            //columns[column_CorporateDivCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:個人");
            valueList.ValueListItems.Add(1, "1:法人");
            valueList.ValueListItems.Add(2, "2:大口法人");
            valueList.ValueListItems.Add(3, "3:業者");
            valueList.ValueListItems.Add(4, "4:社員");
            columns[column_CorporateDivCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_CorporateDivCode].ValueList = valueList.Clone();

            #endregion // 個人・法人

            // FIXME:070.得意先種別　※業販先区分
            #region 得意先種別

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(1, "得意先");
            //valueList.ValueListItems.Add(2, "納入先");
            //columns[column_AcceptWholeSale].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(1, "1:得意先");
            valueList.ValueListItems.Add(2, "2:納入先");
            columns[column_AcceptWholeSale].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_AcceptWholeSale].ValueList = valueList.Clone();

            #endregion // 得意先種別

            // FIXME:019.得意先属性
            #region 得意先属性

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "正式取引先");
            //valueList.ValueListItems.Add(8, "社内取引先");
            //valueList.ValueListItems.Add(9, "諸口口座");
            //columns[column_CustomerAttributeDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:正式取引先");
            valueList.ValueListItems.Add(8, "8:社内取引先");
            valueList.ValueListItems.Add(9, "9:諸口口座");
            columns[column_CustomerAttributeDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_CustomerAttributeDiv].ValueList = valueList.Clone();

            #endregion // 得意先属性

            // FIXME:021.業種
            #region 業種

            valueList.ValueListItems.Clear();
            valueList.ValueListItems.Add(0, " ");
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //foreach (int code in this._businessTypeDic.Keys)
            //{
            //    valueList.ValueListItems.Add(code, this._businessTypeDic[code]);
            //}
            //columns[column_BusinessTypeName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            const string VALUE_NAME_FORMAT = "{0}:{1}";
            const string USER_GUIDE_CODE_FORMAT = "d4";

            foreach (int code in this._businessTypeDic.Keys)
            {
                valueList.ValueListItems.Add(code, string.Format(VALUE_NAME_FORMAT, code.ToString(USER_GUIDE_CODE_FORMAT), this._businessTypeDic[code]));
            }
            columns[column_BusinessTypeName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_BusinessTypeName].ValueList = valueList.Clone();

            #endregion // 業種

            // FIXME:020.職種
            #region 職種

            valueList.ValueListItems.Clear();
            valueList.ValueListItems.Add(0, " ");
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //foreach (int code in this._jobTypeDic.Keys)
            //{
            //    valueList.ValueListItems.Add(code, this._jobTypeDic[code]);
            //}
            //columns[column_JobTypeName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            foreach (int code in this._jobTypeDic.Keys)
            {
                valueList.ValueListItems.Add(code, string.Format(VALUE_NAME_FORMAT, code.ToString(USER_GUIDE_CODE_FORMAT), this._jobTypeDic[code]));
            }
            columns[column_JobTypeName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_JobTypeName].ValueList = valueList.Clone();

            #endregion // 職種

            // FIXME:022.地区
            #region 地区

            valueList.ValueListItems.Clear();
            valueList.ValueListItems.Add(0, " ");
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //foreach (int code in this._salesAreaDic.Keys)
            //{
            //    valueList.ValueListItems.Add(code, this._salesAreaDic[code]);
            //}
            //columns[column_SalesAreaName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            foreach (int code in this._salesAreaDic.Keys)
            {
                valueList.ValueListItems.Add(code, string.Format(VALUE_NAME_FORMAT, code.ToString(USER_GUIDE_CODE_FORMAT), this._salesAreaDic[code]));
            }
            columns[column_SalesAreaName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_SalesAreaName].ValueList = valueList.Clone();

            #endregion // 地区

            // FIXME:046.集金月
            #region 集金月

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "当月");
            //valueList.ValueListItems.Add(1, "翌月");
            //valueList.ValueListItems.Add(2, "翌々月");
            //valueList.ValueListItems.Add(3, "翌々々月");
            //columns[column_CollectMoneyName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:当月");
            valueList.ValueListItems.Add(1, "1:翌月");
            valueList.ValueListItems.Add(2, "2:翌々月");
            valueList.ValueListItems.Add(3, "3:翌々々月");
            columns[column_CollectMoneyName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_CollectMoneyName].ValueList = valueList.Clone();

            #endregion // 集金月

            // FIXME:049.回収条件
            #region 回収条件

            valueList.ValueListItems.Clear();
            // 回収条件リスト取得
            Dictionary<int, string> collectCondDic = GetCollectCondDic();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //foreach (int key in collectCondDic.Keys)
            //{
            //    valueList.ValueListItems.Add(key, collectCondDic[key]);
            //}
            //columns[column_CollectCond].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            foreach (int key in collectCondDic.Keys)
            {
                valueList.ValueListItems.Add(key, string.Format(VALUE_NAME_FORMAT, key.ToString("d2"), collectCondDic[key]));
            }
            columns[column_CollectCond].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_CollectCond].ValueList = valueList.Clone();

            #endregion // 回収条件

            // FIXME:076.転嫁方式参照
            #region 転嫁方式参照

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "税率設定参照");
            //valueList.ValueListItems.Add(1, "得意先参照");
            //columns[column_CustCTaXLayRefCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:税率設定参照");
            valueList.ValueListItems.Add(1, "1:得意先参照");
            columns[column_CustCTaXLayRefCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_CustCTaXLayRefCd].ValueList = valueList.Clone();

            #endregion // 転嫁方式参照

            // FIXME:077.消費税転嫁方式
            #region 消費税転嫁方式

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "伝票転嫁");
            //valueList.ValueListItems.Add(1, "明細転嫁");
            //valueList.ValueListItems.Add(2, "請求親");
            //valueList.ValueListItems.Add(3, "請求子");
            //valueList.ValueListItems.Add(9, "非課税");
            //columns[column_ConsTaxLayMethod].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:伝票転嫁");
            valueList.ValueListItems.Add(1, "1:明細転嫁");
            valueList.ValueListItems.Add(2, "2:請求親");
            valueList.ValueListItems.Add(3, "3:請求子");
            valueList.ValueListItems.Add(9, "9:非課税");
            columns[column_ConsTaxLayMethod].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_ConsTaxLayMethod].ValueList = valueList.Clone();

            #endregion // 消費税転嫁方式

            // FIXME:071.与信管理
            #region 与信管理

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "しない");
            //valueList.ValueListItems.Add(1, "する");
            //columns[column_CreditMngCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:しない");
            valueList.ValueListItems.Add(1, "1:する");
            columns[column_CreditMngCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_CreditMngCode].ValueList = valueList.Clone();

            #endregion // 与信管理

            // FIXME:072.入金消込
            #region 入金消込

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "しない");
            //valueList.ValueListItems.Add(1, "する");
            //columns[column_DepoDelCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:しない");
            valueList.ValueListItems.Add(1, "1:する");
            columns[column_DepoDelCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_DepoDelCode].ValueList = valueList.Clone();

            #endregion // 入金消込

            // FIXME:073.売掛区分
            #region 売掛区分

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "売掛なし");
            //valueList.ValueListItems.Add(1, "売掛");
            //columns[column_AccRecDivCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:売掛なし");
            valueList.ValueListItems.Add(1, "1:売掛");
            columns[column_AccRecDivCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_AccRecDivCd].ValueList = valueList.Clone();

            #endregion // 売掛区分

            // FIXME:033.主連絡先
            #region 主連絡先

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, this._alItmDspNm.HomeTelNoDspName.Trim());
            //valueList.ValueListItems.Add(1, this._alItmDspNm.HomeFaxNoDspName.Trim());
            //valueList.ValueListItems.Add(2, this._alItmDspNm.OfficeTelNoDspName.Trim());
            //valueList.ValueListItems.Add(3, this._alItmDspNm.MobileTelNoDspName.Trim());
            //valueList.ValueListItems.Add(4, this._alItmDspNm.OfficeFaxNoDspName.Trim());
            //valueList.ValueListItems.Add(5, this._alItmDspNm.OtherTelNoDspName.Trim());
            //columns[column_MainContactCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, string.Format(VALUE_NAME_FORMAT, 0, this._alItmDspNm.HomeTelNoDspName.Trim()));
            valueList.ValueListItems.Add(1, string.Format(VALUE_NAME_FORMAT, 1, this._alItmDspNm.HomeFaxNoDspName.Trim()));
            valueList.ValueListItems.Add(2, string.Format(VALUE_NAME_FORMAT, 2, this._alItmDspNm.OfficeTelNoDspName.Trim()));
            valueList.ValueListItems.Add(3, string.Format(VALUE_NAME_FORMAT, 3, this._alItmDspNm.MobileTelNoDspName.Trim()));
            valueList.ValueListItems.Add(4, string.Format(VALUE_NAME_FORMAT, 4, this._alItmDspNm.OfficeFaxNoDspName.Trim()));
            valueList.ValueListItems.Add(5, string.Format(VALUE_NAME_FORMAT, 5, this._alItmDspNm.OtherTelNoDspName.Trim()));
            columns[column_MainContactCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_MainContactCode].ValueList = valueList.Clone();

            #endregion // 主連絡先

            // FIXME:055.主送信先
            #region 主送信先

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "ﾒｰﾙｱﾄﾞﾚｽ1");
            //valueList.ValueListItems.Add(1, "ﾒｰﾙｱﾄﾞﾚｽ2");
            //columns[column_MainSendMailAddrCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:ﾒｰﾙｱﾄﾞﾚｽ1");
            valueList.ValueListItems.Add(1, "1:ﾒｰﾙｱﾄﾞﾚｽ2");
            columns[column_MainSendMailAddrCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_MainSendMailAddrCd].ValueList = valueList.Clone();

            #endregion // 主送信先

            // FIXME:059.メール区分1
            #region メール区分1

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "送信しない");
            //valueList.ValueListItems.Add(1, "送信する");
            //columns[column_MailSendCode1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:送信しない");
            valueList.ValueListItems.Add(1, "1:送信する");
            columns[column_MailSendCode1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_MailSendCode1].ValueList = valueList.Clone();

            #endregion // メール区分1

            // FIXME:056.メール種別1
            #region メール種別1

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "自宅");
            //valueList.ValueListItems.Add(1, "会社");
            //valueList.ValueListItems.Add(2, "携帯端末");
            //valueList.ValueListItems.Add(3, "本人以外");
            //valueList.ValueListItems.Add(99, "その他");
            //columns[column_MailAddrKindCode1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:自宅");
            valueList.ValueListItems.Add(1, "1:会社");
            valueList.ValueListItems.Add(2, "2:携帯端末");
            valueList.ValueListItems.Add(3, "3:本人以外");
            valueList.ValueListItems.Add(99, "99:その他");
            columns[column_MailAddrKindCode1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_MailAddrKindCode1].ValueList = valueList.Clone();

            #endregion // メール種別1

            // FIXME:064.メール区分2
            #region メール区分2

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "送信しない");
            //valueList.ValueListItems.Add(1, "送信する");
            //columns[column_MailSendCode2].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:送信しない");
            valueList.ValueListItems.Add(1, "1:送信する");
            columns[column_MailSendCode2].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_MailSendCode2].ValueList = valueList.Clone();

            #endregion // メール区分2

            // FIXME:061.メール種別2
            #region メール種別2

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "自宅");
            //valueList.ValueListItems.Add(1, "会社");
            //valueList.ValueListItems.Add(2, "携帯端末");
            //valueList.ValueListItems.Add(3, "本人以外");
            //valueList.ValueListItems.Add(99, "その他");
            //columns[column_MailAddrKindCode2].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:自宅");
            valueList.ValueListItems.Add(1, "1:会社");
            valueList.ValueListItems.Add(2, "2:携帯端末");
            valueList.ValueListItems.Add(3, "3:本人以外");
            valueList.ValueListItems.Add(99, "99:その他");
            columns[column_MailAddrKindCode2].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_MailAddrKindCode2].ValueList = valueList.Clone();

            #endregion // メール種別2

            // FIXME:122.領収書出力
            #region 領収書出力

            // ADD 2009/04/07 ------>>>
            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "する");
            //valueList.ValueListItems.Add(1, "しない");
            //columns[column_ReceiptOutputCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:する");
            valueList.ValueListItems.Add(1, "1:しない");
            columns[column_ReceiptOutputCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_ReceiptOutputCode].ValueList = valueList.Clone();
            // ADD 2009/04/07 ------<<<

            #endregion // 領収書出力

            // FIXME:043.請求書出力区分コード…使用しない
            #region 請求書出力

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "する");
            //valueList.ValueListItems.Add(1, "しない");
            //columns[column_BillOutputCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:する");
            valueList.ValueListItems.Add(1, "1:しない");
            columns[column_BillOutputCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_BillOutputCode].ValueList = valueList.Clone();

            #endregion // 請求書出力

            // FIXME:117.納品書出力（売上伝票発行区分）, 118.受注伝票出力（受注伝票発行区分）, 119.貸出伝票出力（出荷伝票発行区分）, 120.見積伝票出力（見積伝票発行区分）, 121.UOE伝票出力（UOE伝票発行区分）
            #region 納品書出力、受注伝票出力、貸出伝票出力、見積伝票出力、UOE伝票出力
            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ---------->>>>>
            valueList.ValueListItems.Clear();
            valueList.ValueListItems.Add(0, "0:標準");
            valueList.ValueListItems.Add(1, "1:未使用");
            valueList.ValueListItems.Add(2, "2:使用");
            // 納品書出力
            columns[column_SalesSlipPrtDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            columns[column_SalesSlipPrtDiv].ValueList = valueList.Clone();
            // 受注伝票出力
            columns[column_AcpOdrrSlipPrtDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            columns[column_AcpOdrrSlipPrtDiv].ValueList = valueList.Clone();
            // 貸出伝票出力
            columns[column_ShipmSlipPrtDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            columns[column_ShipmSlipPrtDiv].ValueList = valueList.Clone();
            // 見積伝票出力
            columns[column_EstimatePrtDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            columns[column_EstimatePrtDiv].ValueList = valueList.Clone();
            // UOE伝票出力
            columns[column_UOESlipPrtDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            columns[column_UOESlipPrtDiv].ValueList = valueList.Clone();
            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ----------<<<<<
            #endregion // 納品書出力、受注伝票出力、貸出伝票出力、見積伝票出力、UOE伝票出力

            // FIXME:126.合計請求書出力, 127.明細請求書出力, 128.伝票合計請求書出力
            #region 合計請求書出力、明細請求書出力、伝票合計請求書出力

            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            #region 削除コード
            //valueList.ValueListItems.Clear();
            //valueList.ValueListItems.Add(0, "標準");
            //valueList.ValueListItems.Add(1, "使用する");
            //valueList.ValueListItems.Add(2, "使用しない");
            //// 合計請求書出力
            //columns[column_TotalBillOutputDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            //columns[column_TotalBillOutputDiv].ValueList = valueList.Clone();
            //// 明細請求書出力
            //columns[column_DetailBillOutputCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            //columns[column_DetailBillOutputCode].ValueList = valueList.Clone();
            //// 伝票合計請求書出力
            //columns[column_SlipTtlBillOutputDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            //columns[column_SlipTtlBillOutputDiv].ValueList = valueList.Clone();
            #endregion
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Clear();
            valueList.ValueListItems.Add(0, "0:標準");
            valueList.ValueListItems.Add(1, "1:使用");  // MOD 2010/02/17 区分名称の変更 "使用する"→"使用"
            valueList.ValueListItems.Add(2, "2:未使用");// MOD 2010/02/17 区分名称の変更 "使用しない"→"未使用"
            // 合計請求書出力
            columns[column_TotalBillOutputDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            columns[column_TotalBillOutputDiv].ValueList = valueList.Clone();
            // 明細請求書出力
            columns[column_DetailBillOutputCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            columns[column_DetailBillOutputCode].ValueList = valueList.Clone();
            // 伝票合計請求書出力
            columns[column_SlipTtlBillOutputDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            columns[column_SlipTtlBillOutputDiv].ValueList = valueList.Clone();
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

            #endregion // 合計請求書出力、明細請求書出力、伝票合計請求書出力

            // FIXME:053.DM出力
            #region DM出力

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "する");
            //valueList.ValueListItems.Add(1, "しない");
            //columns[column_DmOutCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:する");
            valueList.ValueListItems.Add(1, "1:しない");
            columns[column_DmOutCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_DmOutCode].ValueList = valueList.Clone();

            #endregion // DM出力

            // FIXME:074.相手伝番管理
            #region 相手伝番管理

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "全体設定参照");
            //valueList.ValueListItems.Add(1, "しない");
            //valueList.ValueListItems.Add(2, "する");
            //columns[column_CustSlipNoMngCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:全体設定参照");
            valueList.ValueListItems.Add(1, "1:しない");
            valueList.ValueListItems.Add(2, "2:する");
            columns[column_CustSlipNoMngCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_CustSlipNoMngCd].ValueList = valueList.Clone();

            #endregion // 相手伝番管理

            // FIXME:086.伝番区分
            #region 伝番区分

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "使用しない");
            //valueList.ValueListItems.Add(1, "連番");
            //valueList.ValueListItems.Add(2, "締毎");
            //valueList.ValueListItems.Add(3, "期末");
            //columns[column_CustomerSlipNoDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:使用しない");
            valueList.ValueListItems.Add(1, "1:連番");
            valueList.ValueListItems.Add(2, "2:締毎");
            valueList.ValueListItems.Add(3, "3:期末");
            columns[column_CustomerSlipNoDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_CustomerSlipNoDiv].ValueList = valueList.Clone();

            #endregion // 伝番区分

            // FIXME:098.QRコード印刷
            #region QRコード印刷

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            //valueList.ValueListItems.Add(0, "標準");
            //valueList.ValueListItems.Add(1, "印字しない");
            //valueList.ValueListItems.Add(2, "印字する");
            //valueList.ValueListItems.Add(3, "返品含む");
            //columns[column_QrcodePrtCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ---------->>>>>
            valueList.ValueListItems.Add(0, "0:標準");
            valueList.ValueListItems.Add(1, "1:印字しない");
            valueList.ValueListItems.Add(2, "2:印字する");
            valueList.ValueListItems.Add(3, "3:返品含む");
            columns[column_QrcodePrtCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS対応[14976]：グリッド制御の拡張…表示を「区分値：区分名」とし、グリッドセルに区分値の入力を可能とする ----------<<<<<
            columns[column_QrcodePrtCd].ValueList = valueList.Clone();

            #endregion // QRコード印刷

            // ADD 2010/02/24 MANTIS対応[15032]：請求書出力区分が表示されてしまう ---------->>>>>
            //--------------------------------------
            // デフォルト列表示位置　※↑キャプションを設定している実装をアレンジ
            //--------------------------------------
            #region デフォルト列表示位置

            int visiblePosition = 0;

            columns[column_No].Header.VisiblePosition = ++visiblePosition; // "No.";
            columns[column_CustomerCode].Header.VisiblePosition = ++visiblePosition; // "得意先ｺｰﾄﾞ";
            columns[column_CustomerSubCode].Header.VisiblePosition = ++visiblePosition; // "ｻﾌﾞｺｰﾄﾞ";
            columns[column_CustomerName].Header.VisiblePosition = ++visiblePosition; // "得意先名1";
            columns[column_CustomerName2].Header.VisiblePosition = ++visiblePosition; // "得意先名2";
            columns[column_CustomerSnm].Header.VisiblePosition = ++visiblePosition; // "得意先略称";
            columns[column_CustomerKana].Header.VisiblePosition = ++visiblePosition; // "得意先名(ｶﾅ)";
            columns[column_HonorificTitle].Header.VisiblePosition = ++visiblePosition; // "敬称";
            columns[column_OutputName].Header.VisiblePosition = ++visiblePosition; // "諸口";
            columns[column_MngSectionName].Header.VisiblePosition = ++visiblePosition; // "管理拠点";
            columns[column_MngSectionGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_CustomerAgentName].Header.VisiblePosition = ++visiblePosition; // "得意先担当";
            columns[column_CustomerAgentGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_OldCustomerAgentName].Header.VisiblePosition = ++visiblePosition; // "旧担当";
            columns[column_OldCustomerAgentGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_CustAgentChgDate].Header.VisiblePosition = ++visiblePosition; // "担当者変更日";
            columns[column_TransStopDate].Header.VisiblePosition = ++visiblePosition; // "取引中止日";
            columns[column_CarMngDivCd].Header.VisiblePosition = ++visiblePosition; // "車輌管理";
            columns[column_CorporateDivCode].Header.VisiblePosition = ++visiblePosition; // "個人・法人";
            columns[column_AcceptWholeSale].Header.VisiblePosition = ++visiblePosition; // "得意先種別";
            columns[column_CustomerAttributeDiv].Header.VisiblePosition = ++visiblePosition; // "得意先属性";
            columns[column_CustWarehouseName].Header.VisiblePosition = ++visiblePosition; // "優先倉庫";
            columns[column_CustWarehouseGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_BusinessTypeName].Header.VisiblePosition = ++visiblePosition; // "業種";
            columns[column_JobTypeName].Header.VisiblePosition = ++visiblePosition; // "職種";
            columns[column_SalesAreaName].Header.VisiblePosition = ++visiblePosition; // "地区";
            columns[column_CustAnalysCode1].Header.VisiblePosition = ++visiblePosition; // "分析ｺｰﾄﾞ1";
            columns[column_CustAnalysCode2].Header.VisiblePosition = ++visiblePosition; // "分析ｺｰﾄﾞ2";
            columns[column_CustAnalysCode3].Header.VisiblePosition = ++visiblePosition; // "分析ｺｰﾄﾞ3";
            columns[column_CustAnalysCode4].Header.VisiblePosition = ++visiblePosition; // "分析ｺｰﾄﾞ4";
            columns[column_CustAnalysCode5].Header.VisiblePosition = ++visiblePosition; // "分析ｺｰﾄﾞ5";
            columns[column_CustAnalysCode6].Header.VisiblePosition = ++visiblePosition; // "分析ｺｰﾄﾞ6";
            columns[column_ClaimSectionSnm].Header.VisiblePosition = ++visiblePosition; // "請求拠点";
            columns[column_ClaimSectionGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_ClaimSnm].Header.VisiblePosition = ++visiblePosition; // "請求先ｺｰﾄﾞ";
            columns[column_ClaimGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_TotalDay].Header.VisiblePosition = ++visiblePosition; // "締日";
            columns[column_CollectMoneyName].Header.VisiblePosition = ++visiblePosition; // "集金月";
            columns[column_CollectMoneyDay].Header.VisiblePosition = ++visiblePosition; // "集金日";
            columns[column_CollectCond].Header.VisiblePosition = ++visiblePosition; // "回収条件";
            columns[column_CollectSight].Header.VisiblePosition = ++visiblePosition; // "回収ｻｲﾄ";
            columns[column_NTimeCalcStDate].Header.VisiblePosition = ++visiblePosition; // "次回勘定";
            columns[column_BillCollecterName].Header.VisiblePosition = ++visiblePosition; // "集金担当";
            columns[column_BillCollecterGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_CustCTaXLayRefCd].Header.VisiblePosition = ++visiblePosition; // "転嫁方式参照";
            columns[column_ConsTaxLayMethod].Header.VisiblePosition = ++visiblePosition; // "消費税転嫁方式";
            columns[column_CreditMngCode].Header.VisiblePosition = ++visiblePosition; // "与信管理";
            columns[column_CreditMoney].Header.VisiblePosition = ++visiblePosition; // "与信額";
            columns[column_WarningCreditMoney].Header.VisiblePosition = ++visiblePosition; // "警告与信額";
            columns[column_DepoDelCode].Header.VisiblePosition = ++visiblePosition; // "入金消込";
            columns[column_AccRecDivCd].Header.VisiblePosition = ++visiblePosition; // "売掛区分";
            columns[column_SalesUnPrcFrcProcCd].Header.VisiblePosition = ++visiblePosition; // "単価端数";
            columns[column_SalesUnPrcFrcProcGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_SalesMoneyFrcProcCd].Header.VisiblePosition = ++visiblePosition; // "金額端数";
            columns[column_SalesMoneyFrcProcGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_SalesCnsTaxFrcProcCd].Header.VisiblePosition = ++visiblePosition; // "税端数";
            columns[column_SalesCnsTaxFrcProcGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_PostNo].Header.VisiblePosition = ++visiblePosition; // "郵便番号";
            columns[column_PostNoGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_Address1].Header.VisiblePosition = ++visiblePosition; // "住所1";
            columns[column_Address3].Header.VisiblePosition = ++visiblePosition; // "住所2";
            columns[column_Address4].Header.VisiblePosition = ++visiblePosition; // "住所3";
            columns[column_HomeTelNo].Header.VisiblePosition = ++visiblePosition; // this._alItmDspNm.HomeTelNoDspName.Trim();
            columns[column_HomeFaxNo].Header.VisiblePosition = ++visiblePosition; // this._alItmDspNm.HomeFaxNoDspName.Trim();
            columns[column_OfficeTelNo].Header.VisiblePosition = ++visiblePosition; // this._alItmDspNm.OfficeTelNoDspName.Trim();
            columns[column_PortableTelNo].Header.VisiblePosition = ++visiblePosition; // this._alItmDspNm.MobileTelNoDspName.Trim();
            columns[column_OfficeFaxNo].Header.VisiblePosition = ++visiblePosition; // this._alItmDspNm.OfficeFaxNoDspName.Trim();
            columns[column_OthersTelNo].Header.VisiblePosition = ++visiblePosition; // this._alItmDspNm.OtherTelNoDspName.Trim();
            columns[column_SearchTelNo].Header.VisiblePosition = ++visiblePosition; // "検索番号";
            columns[column_MainContactCode].Header.VisiblePosition = ++visiblePosition; // "主連絡先";
            columns[column_CustomerAgent].Header.VisiblePosition = ++visiblePosition; // "得意先担当者";
            columns[column_MainSendMailAddrCd].Header.VisiblePosition = ++visiblePosition; // "主送信先";
            columns[column_MailAddress1].Header.VisiblePosition = ++visiblePosition; // "ﾒｰﾙｱﾄﾞﾚｽ1";
            columns[column_MailSendCode1].Header.VisiblePosition = ++visiblePosition; // "ﾒｰﾙ区分1";
            columns[column_MailAddrKindCode1].Header.VisiblePosition = ++visiblePosition; // "ﾒｰﾙ種別1";
            columns[column_MailAddress2].Header.VisiblePosition = ++visiblePosition; // "ﾒｰﾙｱﾄﾞﾚｽ2";
            columns[column_MailSendCode2].Header.VisiblePosition = ++visiblePosition; // "ﾒｰﾙ区分2";
            columns[column_MailAddrKindCode2].Header.VisiblePosition = ++visiblePosition; // "ﾒｰﾙ種別2";
            columns[column_ReceiptOutputCode].Header.VisiblePosition = ++visiblePosition; // "領収書出力";

            // TODO:使用しない…請求書出力区分コード
            columns[column_BillOutputCode].Header.VisiblePosition = ++visiblePosition; // "請求書出力";

            columns[column_SalesSlipPrtDiv].Header.VisiblePosition = ++visiblePosition; // "納品書出力";     // 納品書出力（売上伝票発行区分）
            columns[column_AcpOdrrSlipPrtDiv].Header.VisiblePosition = ++visiblePosition; // "受注伝票出力";   // 受注伝票出力（受注伝票発行区分）
            columns[column_ShipmSlipPrtDiv].Header.VisiblePosition = ++visiblePosition; // "貸出伝票出力";   // 貸出伝票出力（出荷伝票発行区分）
            columns[column_EstimatePrtDiv].Header.VisiblePosition = ++visiblePosition; // "見積伝票出力";   // 見積伝票出力（見積伝票発行区分）
            columns[column_UOESlipPrtDiv].Header.VisiblePosition = ++visiblePosition; // "UOE伝票出力";    // UOE伝票出力（UOE伝票発行区分）

            columns[column_TotalBillOutputDiv].Header.VisiblePosition = ++visiblePosition; // "合計請求書出力";
            columns[column_DetailBillOutputCode].Header.VisiblePosition = ++visiblePosition; // "明細請求書出力";
            columns[column_SlipTtlBillOutputDiv].Header.VisiblePosition = ++visiblePosition; // "伝票合計請求書出力";

            columns[column_DmOutCode].Header.VisiblePosition = ++visiblePosition; // "DM出力";
            columns[column_CustSlipNoMngCd].Header.VisiblePosition = ++visiblePosition; // "相手伝番管理";
            columns[column_CustomerSlipNoDiv].Header.VisiblePosition = ++visiblePosition; // "伝番区分";
            columns[column_QrcodePrtCd].Header.VisiblePosition = ++visiblePosition; // "QRｺｰﾄﾞ印刷";

            #endregion // デフォルト列表示位置
            // ADD 2010/02/24 MANTIS対応[15032]：請求書出力区分が表示されてしまう ----------<<<<<

            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
            // TODO:使用しない…請求書出力区分コード
            columns[column_BillOutputCode].Hidden = true;
            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<
        }

        /// <summary>
        /// 初期表示設定処理
        /// </summary>
        /// <param name="cells">セルコレクション</param>
        /// <remarks>
        /// <br>Note       : グリッドの対象行に初期表示を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public void SetInitialDisp(ref CellsCollection cells, string belongSectionName)
        {
            cells[GridInitialSetting.column_CustomerSubCode].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustomerSnm].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustomerKana].Value = DBNull.Value;
            cells[GridInitialSetting.column_HonorificTitle].Value = "様";
            cells[GridInitialSetting.column_OutputName].Value = 0;
            cells[GridInitialSetting.column_MngSectionName].Value = belongSectionName;
            cells[GridInitialSetting.column_CustomerAgentName].Value = LoginInfoAcquisition.Employee.Name.Trim();
            cells[GridInitialSetting.column_OldCustomerAgentName].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustAgentChgDate].Value = DBNull.Value;
            cells[GridInitialSetting.column_TransStopDate].Value = DBNull.Value;
            cells[GridInitialSetting.column_CarMngDivCd].Value = 0;
            cells[GridInitialSetting.column_CorporateDivCode].Value = 0;
            cells[GridInitialSetting.column_AcceptWholeSale].Value = 1;
            cells[GridInitialSetting.column_CustomerAttributeDiv].Value = 0;
            cells[GridInitialSetting.column_CustWarehouseName].Value = DBNull.Value;
            cells[GridInitialSetting.column_BusinessTypeName].Value = 0;
            cells[GridInitialSetting.column_JobTypeName].Value = 0;
            cells[GridInitialSetting.column_SalesAreaName].Value = 0;
            cells[GridInitialSetting.column_CustAnalysCode1].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustAnalysCode2].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustAnalysCode3].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustAnalysCode4].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustAnalysCode5].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustAnalysCode6].Value = DBNull.Value;
            cells[GridInitialSetting.column_ClaimSectionSnm].Value = belongSectionName;
            cells[GridInitialSetting.column_ClaimSnm].Value = cells[GridInitialSetting.column_CustomerSnm].Value;
            cells[GridInitialSetting.column_TotalDay].Value = DBNull.Value;
            cells[GridInitialSetting.column_CollectMoneyName].Value = 0;
            cells[GridInitialSetting.column_CollectMoneyDay].Value = DBNull.Value;
            cells[GridInitialSetting.column_CollectCond].Value = this._depositSt.DepositStKindCd1;
            cells[GridInitialSetting.column_CollectSight].Value = DBNull.Value;
            cells[GridInitialSetting.column_NTimeCalcStDate].Value = DBNull.Value;
            cells[GridInitialSetting.column_BillCollecterName].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustCTaXLayRefCd].Value = 0;
            cells[GridInitialSetting.column_CreditMngCode].Value = 0;
            cells[GridInitialSetting.column_CreditMoney].Value = DBNull.Value;      // ADD 2009/04/13
            cells[GridInitialSetting.column_WarningCreditMoney].Value = DBNull.Value;
            cells[GridInitialSetting.column_DepoDelCode].Value = 0;
            cells[GridInitialSetting.column_AccRecDivCd].Value = 1;
            cells[GridInitialSetting.column_SalesUnPrcFrcProcCd].Value = 0;
            cells[GridInitialSetting.column_SalesMoneyFrcProcCd].Value = 0;
            cells[GridInitialSetting.column_SalesCnsTaxFrcProcCd].Value = 0;
            cells[GridInitialSetting.column_HomeTelNo].Value = DBNull.Value;
            cells[GridInitialSetting.column_HomeFaxNo].Value = DBNull.Value;
            cells[GridInitialSetting.column_PortableTelNo].Value = DBNull.Value;
            cells[GridInitialSetting.column_OthersTelNo].Value = DBNull.Value;
            cells[GridInitialSetting.column_SearchTelNo].Value = DBNull.Value;
            cells[GridInitialSetting.column_MainContactCode].Value = 0;
            cells[GridInitialSetting.column_CustomerAgent].Value = DBNull.Value;
            cells[GridInitialSetting.column_MainSendMailAddrCd].Value = 0;
            cells[GridInitialSetting.column_MailAddress1].Value = DBNull.Value;
            cells[GridInitialSetting.column_MailSendCode1].Value = 0;
            cells[GridInitialSetting.column_MailAddrKindCode1].Value = 0;
            cells[GridInitialSetting.column_MailAddress2].Value = DBNull.Value;
            cells[GridInitialSetting.column_MailSendCode2].Value = 0;
            cells[GridInitialSetting.column_MailAddrKindCode2].Value = 0;
            cells[GridInitialSetting.column_ReceiptOutputCode].Value = 0;       // ADD 2009/04/07
            cells[GridInitialSetting.column_BillOutputCode].Value = 0;  // TODO:使用しない…請求書出力区分コード

            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ---------->>>>>
            cells[GridInitialSetting.column_SalesSlipPrtDiv].Value  = 0;    // 納品書出力（売上伝票発行区分）
            cells[GridInitialSetting.column_AcpOdrrSlipPrtDiv].Value= 0;    // 受注伝票出力（受注伝票発行区分）
            cells[GridInitialSetting.column_ShipmSlipPrtDiv].Value  = 0;    // 貸出伝票出力（出荷伝票発行区分）
            cells[GridInitialSetting.column_EstimatePrtDiv].Value   = 0;    // 見積伝票出力（見積伝票発行区分）
            cells[GridInitialSetting.column_UOESlipPrtDiv].Value    = 0;    // UOE伝票出力（UOE伝票発行区分）
            // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ----------<<<<<

            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
            cells[GridInitialSetting.column_TotalBillOutputDiv].Value   = 0;    // 合計請求書出力
            cells[GridInitialSetting.column_DetailBillOutputCode].Value = 0;    // 明細請求書出力
            cells[GridInitialSetting.column_SlipTtlBillOutputDiv].Value = 0;    // 伝票合計請求書出力
            // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

            cells[GridInitialSetting.column_DmOutCode].Value = 1;
            cells[GridInitialSetting.column_CustSlipNoMngCd].Value = 0;
            cells[GridInitialSetting.column_CustomerSlipNoDiv].Value = 0;
            cells[GridInitialSetting.column_QrcodePrtCd].Value = 0;
        }

        #endregion ■ Public Methods


        #region ■ Private Methods

        /// <summary>
        /// 入金設定マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入金設定マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private void ReadDepositSt()
        {
            try
            {
                int status = this._depositStAcs.Read(out this._depositSt, LoginInfoAcquisition.EnterpriseCode, 0);
                if (status != 0)
                {
                    this._depositSt = new DepositSt();
                }
            }
            catch
            {
                this._depositSt = new DepositSt();
            }
        }

        /// <summary>
        /// 金額種別設定マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 金額種別設定マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private void ReadMoneyKind()
        {
            this._moneyKindDic = new Dictionary<int, MoneyKind>();

            try
            {
                ArrayList retList;

                int status = this._moneyKindAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (MoneyKind moneyKind in retList)
                    {
                        // 金額設定区分が「0:入金」を使用
                        if ((moneyKind.LogicalDeleteCode == 0) && (moneyKind.PriceStCode == 0))
                        {
                            this._moneyKindDic.Add(moneyKind.MoneyKindCode, moneyKind);
                        }
                    }
                }
            }
            catch
            {
                this._moneyKindDic = new Dictionary<int, MoneyKind>();
            }
        }

        /// <summary>
        /// 全体項目表示名称設定マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 全体項目表示名称設定マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private void ReadAlItmDspNm()
        {
            try
            {
                int status = this._alItmDspNmAcs.Read(out this._alItmDspNm, LoginInfoAcquisition.EnterpriseCode);
                if (status != 0)
                {
                    this._alItmDspNm = new AlItmDspNm();
                }
            }
            catch
            {
                this._alItmDspNm = new AlItmDspNm();
            }
        }

        /// <summary>
        /// 職種データ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザーガイドマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private void ReadJobTypeCode()
        {
            this._jobTypeDic = new Dictionary<int, string>();

            ReadUserGdBd(34, ref this._jobTypeDic);
        }

        /// <summary>
        /// 業種データ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザーガイドマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private void ReadBusinessTypeCode()
        {
            this._businessTypeDic = new Dictionary<int, string>();

            ReadUserGdBd(33, ref this._businessTypeDic);
        }

        /// <summary>
        /// 地区データ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザーガイドマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private void ReadSalesAreaCode()
        {
            this._salesAreaDic = new Dictionary<int, string>();

            ReadUserGdBd(21, ref this._salesAreaDic);
        }

        /// <summary>
        /// ユーザーガイドマスタ読込処理
        /// </summary>
        /// <param name="userGuideDivCd">ガイド区分</param>
        /// <param name="targetDic">対象Dictionary</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ユーザーガイドマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private int ReadUserGdBd(int userGuideDivCd, ref Dictionary<int, string> targetDic)
        {
            try
            {
                ArrayList retList;

                int status = this._userGuideAcs.SearchAllDivCodeBody(out retList, LoginInfoAcquisition.EnterpriseCode,
                                                                     userGuideDivCd, UserGuideAcsData.UserBodyData);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            targetDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                        }
                    }
                }
            }
            catch
            {
                targetDic = new Dictionary<int, string>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 回収条件リスト取得処理
        /// </summary>
        /// <returns>回収条件リスト</returns>
        /// <remarks>
        /// <br>Note       : 入金設定マスタ、金額種別設定マスタより回収条件リストを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public Dictionary<int, string> GetCollectCondDic()
        {
            Dictionary<int, string> collctCondDic = new Dictionary<int, string>();

            // 入金設定金種コード1
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd1))
            {
                depositStKindCd1 = this._depositSt.DepositStKindCd1;    // 2010/07/14 Add
                collctCondDic.Add(this._depositSt.DepositStKindCd1, this._moneyKindDic[this._depositSt.DepositStKindCd1].MoneyKindName);
            }
            // 入金設定金種コード2
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd2))
            {
                collctCondDic.Add(this._depositSt.DepositStKindCd2, this._moneyKindDic[this._depositSt.DepositStKindCd2].MoneyKindName);
            }
            // 入金設定金種コード3
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd3))
            {
                collctCondDic.Add(this._depositSt.DepositStKindCd3, this._moneyKindDic[this._depositSt.DepositStKindCd3].MoneyKindName);
            }
            // 入金設定金種コード4
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd4))
            {
                collctCondDic.Add(this._depositSt.DepositStKindCd4, this._moneyKindDic[this._depositSt.DepositStKindCd4].MoneyKindName);
            }
            // 入金設定金種コード5
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd5))
            {
                collctCondDic.Add(this._depositSt.DepositStKindCd5, this._moneyKindDic[this._depositSt.DepositStKindCd5].MoneyKindName);
            }
            // 入金設定金種コード6
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd6))
            {
                collctCondDic.Add(this._depositSt.DepositStKindCd6, this._moneyKindDic[this._depositSt.DepositStKindCd6].MoneyKindName);
            }
            // 入金設定金種コード7
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd7))
            {
                collctCondDic.Add(this._depositSt.DepositStKindCd7, this._moneyKindDic[this._depositSt.DepositStKindCd7].MoneyKindName);
            }
            // 入金設定金種コード8
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd8))
            {
                collctCondDic.Add(this._depositSt.DepositStKindCd8, this._moneyKindDic[this._depositSt.DepositStKindCd8].MoneyKindName);
            }

            return collctCondDic;
        }

        #endregion ■ Private Methods
    }
}
