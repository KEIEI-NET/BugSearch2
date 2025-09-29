//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 売上データテーブルスキーマクラス
// プログラム概要   : 売上データテーブル定義を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 売上データテーブルスキーマクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データ抽出結果テーブルスキーマ</br>
    /// <br>Programmer : 96186　立花裕輔</br>
    /// <br>Date       : 2008.05.26</br>
    /// </remarks>
    public class SalesSlipSchema
    {
        #region Public Members
        /// <summary>売上データテーブル名</summary>
        public const string CT_SalesSlipDataTable = "SalesSlipDataTable";

        /// <summary>受注データテーブル名</summary>
        public const string CT_AcptSlipDataTable = "AcptSlipDataTable";

        #region カラム初期情報
        public const double defValueDouble = 0;
        public const Int64 defValueInt64 = 0;
        public const Int32 defValueInt32 = 0;
        public const string defValuestring = "";
        #endregion

        #region カラム情報
        /// <summary> 作成日時 </summary>
        public const string ct_Col_CreateDateTime = "CreateDateTime";
        /// <summary> 更新日時 </summary>
        public const string ct_Col_UpdateDateTime = "UpdateDateTime";
        /// <summary> 企業コード </summary>
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        /// <summary> GUID </summary>
        public const string ct_Col_FileHeaderGuid = "FileHeaderGuid";
        /// <summary> 更新従業員コード </summary>
        public const string ct_Col_UpdEmployeeCode = "UpdEmployeeCode";
        /// <summary> 更新アセンブリID1 </summary>
        public const string ct_Col_UpdAssemblyId1 = "UpdAssemblyId1";
        /// <summary> 更新アセンブリID2 </summary>
        public const string ct_Col_UpdAssemblyId2 = "UpdAssemblyId2";
        /// <summary> 論理削除区分 </summary>
        public const string ct_Col_LogicalDeleteCode = "LogicalDeleteCode";
        /// <summary> 受注ステータス </summary>
        public const string ct_Col_AcptAnOdrStatus = "AcptAnOdrStatus";
        /// <summary> 売上伝票番号 </summary>
        public const string ct_Col_SalesSlipNum = "SalesSlipNum";
        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 部門コード </summary>
        public const string ct_Col_SubSectionCode = "SubSectionCode";
        /// <summary> 赤伝区分 </summary>
        public const string ct_Col_DebitNoteDiv = "DebitNoteDiv";
        /// <summary> 赤黒連結売上伝票番号 </summary>
        public const string ct_Col_DebitNLnkSalesSlNum = "DebitNLnkSalesSlNum";
        /// <summary> 売上伝票区分 </summary>
        public const string ct_Col_SalesSlipCd = "SalesSlipCd";
        /// <summary> 売上商品区分 </summary>
        public const string ct_Col_SalesGoodsCd = "SalesGoodsCd";
        /// <summary> 売掛区分 </summary>
        public const string ct_Col_AccRecDivCd = "AccRecDivCd";
        /// <summary> 売上入力拠点コード </summary>
        public const string ct_Col_SalesInpSecCd = "SalesInpSecCd";
        /// <summary> 請求計上拠点コード </summary>
        public const string ct_Col_DemandAddUpSecCd = "DemandAddUpSecCd";
        /// <summary> 実績計上拠点コード </summary>
        public const string ct_Col_ResultsAddUpSecCd = "ResultsAddUpSecCd";
        /// <summary> 更新拠点コード </summary>
        public const string ct_Col_UpdateSecCd = "UpdateSecCd";
        /// <summary> 売上伝票更新区分 </summary>
        public const string ct_Col_SalesSlipUpdateCd = "SalesSlipUpdateCd";
        /// <summary> 伝票検索日付 </summary>
        public const string ct_Col_SearchSlipDate = "SearchSlipDate";
        /// <summary> 出荷日付 </summary>
        public const string ct_Col_ShipmentDay = "ShipmentDay";
        /// <summary> 売上日付 </summary>
        public const string ct_Col_SalesDate = "SalesDate";
        /// <summary> 計上日付 </summary>
        public const string ct_Col_AddUpADate = "AddUpADate";
        /// <summary> 来勘区分 </summary>
        public const string ct_Col_DelayPaymentDiv = "DelayPaymentDiv";
        /// <summary> 見積書番号 </summary>
        public const string ct_Col_EstimateFormNo = "EstimateFormNo";
        /// <summary> 見積区分 </summary>
        public const string ct_Col_EstimateDivide = "EstimateDivide";
        /// <summary> 入力担当者コード </summary>
        public const string ct_Col_InputAgenCd = "InputAgenCd";
        /// <summary> 入力担当者名称 </summary>
        public const string ct_Col_InputAgenNm = "InputAgenNm";
        /// <summary> 売上入力者コード </summary>
        public const string ct_Col_SalesInputCode = "SalesInputCode";
        /// <summary> 売上入力者名称 </summary>
        public const string ct_Col_SalesInputName = "SalesInputName";
        /// <summary> 受付従業員コード </summary>
        public const string ct_Col_FrontEmployeeCd = "FrontEmployeeCd";
        /// <summary> 受付従業員名称 </summary>
        public const string ct_Col_FrontEmployeeNm = "FrontEmployeeNm";
        /// <summary> 販売従業員コード </summary>
        public const string ct_Col_SalesEmployeeCd = "SalesEmployeeCd";
        /// <summary> 販売従業員名称 </summary>
        public const string ct_Col_SalesEmployeeNm = "SalesEmployeeNm";
        /// <summary> 総額表示方法区分 </summary>
        public const string ct_Col_TotalAmountDispWayCd = "TotalAmountDispWayCd";
        /// <summary> 総額表示掛率適用区分 </summary>
        public const string ct_Col_TtlAmntDispRateApy = "TtlAmntDispRateApy";
        /// <summary> 売上伝票合計（税込み） </summary>
        public const string ct_Col_SalesTotalTaxInc = "SalesTotalTaxInc";
        /// <summary> 売上伝票合計（税抜き） </summary>
        public const string ct_Col_SalesTotalTaxExc = "SalesTotalTaxExc";
        /// <summary> 売上部品合計（税込み） </summary>
        public const string ct_Col_SalesPrtTotalTaxInc = "SalesPrtTotalTaxInc";
        /// <summary> 売上部品合計（税抜き） </summary>
        public const string ct_Col_SalesPrtTotalTaxExc = "SalesPrtTotalTaxExc";
        /// <summary> 売上作業合計（税込み） </summary>
        public const string ct_Col_SalesWorkTotalTaxInc = "SalesWorkTotalTaxInc";
        /// <summary> 売上作業合計（税抜き） </summary>
        public const string ct_Col_SalesWorkTotalTaxExc = "SalesWorkTotalTaxExc";
        /// <summary> 売上小計（税込み） </summary>
        public const string ct_Col_SalesSubtotalTaxInc = "SalesSubtotalTaxInc";
        /// <summary> 売上小計（税抜き） </summary>
        public const string ct_Col_SalesSubtotalTaxExc = "SalesSubtotalTaxExc";
        /// <summary> 売上部品小計（税込み） </summary>
        public const string ct_Col_SalesPrtSubttlInc = "SalesPrtSubttlInc";
        /// <summary> 売上部品小計（税抜き） </summary>
        public const string ct_Col_SalesPrtSubttlExc = "SalesPrtSubttlExc";
        /// <summary> 売上作業小計（税込み） </summary>
        public const string ct_Col_SalesWorkSubttlInc = "SalesWorkSubttlInc";
        /// <summary> 売上作業小計（税抜き） </summary>
        public const string ct_Col_SalesWorkSubttlExc = "SalesWorkSubttlExc";
        /// <summary> 売上正価金額 </summary>
        public const string ct_Col_SalesNetPrice = "SalesNetPrice";
        /// <summary> 売上小計（税） </summary>
        public const string ct_Col_SalesSubtotalTax = "SalesSubtotalTax";
        /// <summary> 売上外税対象額 </summary>
        public const string ct_Col_ItdedSalesOutTax = "ItdedSalesOutTax";
        /// <summary> 売上内税対象額 </summary>
        public const string ct_Col_ItdedSalesInTax = "ItdedSalesInTax";
        /// <summary> 売上小計非課税対象額 </summary>
        public const string ct_Col_SalSubttlSubToTaxFre = "SalSubttlSubToTaxFre";
        /// <summary> 売上金額消費税額（外税） </summary>
        public const string ct_Col_SalesOutTax = "SalesOutTax";
        /// <summary> 売上金額消費税額（内税） </summary>
        public const string ct_Col_SalAmntConsTaxInclu = "SalAmntConsTaxInclu";
        /// <summary> 売上値引金額計（税抜き） </summary>
        public const string ct_Col_SalesDisTtlTaxExc = "SalesDisTtlTaxExc";
        /// <summary> 売上値引外税対象額合計 </summary>
        public const string ct_Col_ItdedSalesDisOutTax = "ItdedSalesDisOutTax";
        /// <summary> 売上値引内税対象額合計 </summary>
        public const string ct_Col_ItdedSalesDisInTax = "ItdedSalesDisInTax";
        /// <summary> 部品値引対象額合計（税抜き） </summary>
        public const string ct_Col_ItdedPartsDisOutTax = "ItdedPartsDisOutTax";
        /// <summary> 部品値引対象額合計（税込み） </summary>
        public const string ct_Col_ItdedPartsDisInTax = "ItdedPartsDisInTax";
        /// <summary> 作業値引対象額合計（税抜き） </summary>
        public const string ct_Col_ItdedWorkDisOutTax = "ItdedWorkDisOutTax";
        /// <summary> 作業値引対象額合計（税込み） </summary>
        public const string ct_Col_ItdedWorkDisInTax = "ItdedWorkDisInTax";
        /// <summary> 売上値引非課税対象額合計 </summary>
        public const string ct_Col_ItdedSalesDisTaxFre = "ItdedSalesDisTaxFre";
        /// <summary> 売上値引消費税額（外税） </summary>
        public const string ct_Col_SalesDisOutTax = "SalesDisOutTax";
        /// <summary> 売上値引消費税額（内税） </summary>
        public const string ct_Col_SalesDisTtlTaxInclu = "SalesDisTtlTaxInclu";
        /// <summary> 部品値引率 </summary>
        public const string ct_Col_PartsDiscountRate = "PartsDiscountRate";
        /// <summary> 工賃値引率 </summary>
        public const string ct_Col_RavorDiscountRate = "RavorDiscountRate";
        /// <summary> 原価金額計 </summary>
        public const string ct_Col_TotalCost = "TotalCost";
        /// <summary> 消費税転嫁方式 </summary>
        public const string ct_Col_ConsTaxLayMethod = "ConsTaxLayMethod";
        /// <summary> 消費税税率 </summary>
        public const string ct_Col_ConsTaxRate = "ConsTaxRate";
        /// <summary> 端数処理区分 </summary>
        public const string ct_Col_FractionProcCd = "FractionProcCd";
        /// <summary> 売掛消費税 </summary>
        public const string ct_Col_AccRecConsTax = "AccRecConsTax";
        /// <summary> 自動入金区分 </summary>
        public const string ct_Col_AutoDepositCd = "AutoDepositCd";
        /// <summary> 自動入金伝票番号 </summary>
        public const string ct_Col_AutoDepositSlipNo = "AutoDepositSlipNo";
        /// <summary> 入金引当合計額 </summary>
        public const string ct_Col_DepositAllowanceTtl = "DepositAllowanceTtl";
        /// <summary> 入金引当残高 </summary>
        public const string ct_Col_DepositAlwcBlnce = "DepositAlwcBlnce";
        /// <summary> 請求先コード </summary>
        public const string ct_Col_ClaimCode = "ClaimCode";
        /// <summary> 請求先略称 </summary>
        public const string ct_Col_ClaimSnm = "ClaimSnm";
        /// <summary> 得意先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 得意先名称 </summary>
        public const string ct_Col_CustomerName = "CustomerName";
        /// <summary> 得意先名称2 </summary>
        public const string ct_Col_CustomerName2 = "CustomerName2";
        /// <summary> 得意先略称 </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> 敬称 </summary>
        public const string ct_Col_HonorificTitle = "HonorificTitle";
        /// <summary> 諸口コード </summary>
        public const string ct_Col_OutputNameCode = "OutputNameCode";
        /// <summary> 諸口名称 </summary>
        public const string ct_Col_OutputName = "OutputName";
        /// <summary> 得意先伝票番号 </summary>
        public const string ct_Col_CustSlipNo = "CustSlipNo";
        /// <summary> 伝票住所区分 </summary>
        public const string ct_Col_SlipAddressDiv = "SlipAddressDiv";
        /// <summary> 納品先コード </summary>
        public const string ct_Col_AddresseeCode = "AddresseeCode";
        /// <summary> 納品先名称 </summary>
        public const string ct_Col_AddresseeName = "AddresseeName";
        /// <summary> 納品先名称2 </summary>
        public const string ct_Col_AddresseeName2 = "AddresseeName2";
        /// <summary> 納品先郵便番号 </summary>
        public const string ct_Col_AddresseePostNo = "AddresseePostNo";
        /// <summary> 納品先住所1(都道府県市区郡・町村・字) </summary>
        public const string ct_Col_AddresseeAddr1 = "AddresseeAddr1";
        /// <summary> 納品先住所3(番地) </summary>
        public const string ct_Col_AddresseeAddr3 = "AddresseeAddr3";
        /// <summary> 納品先住所4(アパート名称) </summary>
        public const string ct_Col_AddresseeAddr4 = "AddresseeAddr4";
        /// <summary> 納品先電話番号 </summary>
        public const string ct_Col_AddresseeTelNo = "AddresseeTelNo";
        /// <summary> 納品先FAX番号 </summary>
        public const string ct_Col_AddresseeFaxNo = "AddresseeFaxNo";
        /// <summary> 相手先伝票番号 </summary>
        public const string ct_Col_PartySaleSlipNum = "PartySaleSlipNum";
        /// <summary> 伝票備考 </summary>
        public const string ct_Col_SlipNote = "SlipNote";
        /// <summary> 伝票備考２ </summary>
        public const string ct_Col_SlipNote2 = "SlipNote2";
        /// <summary> 伝票備考３ </summary>
        public const string ct_Col_SlipNote3 = "SlipNote3";
        /// <summary> 返品理由コード </summary>
        public const string ct_Col_RetGoodsReasonDiv = "RetGoodsReasonDiv";
        /// <summary> 返品理由 </summary>
        public const string ct_Col_RetGoodsReason = "RetGoodsReason";
        /// <summary> レジ処理日 </summary>
        public const string ct_Col_RegiProcDate = "RegiProcDate";
        /// <summary> レジ番号 </summary>
        public const string ct_Col_CashRegisterNo = "CashRegisterNo";
        /// <summary> POSレシート番号 </summary>
        public const string ct_Col_PosReceiptNo = "PosReceiptNo";
        /// <summary> 明細行数 </summary>
        public const string ct_Col_DetailRowCount = "DetailRowCount";
        /// <summary> ＥＤＩ送信日 </summary>
        public const string ct_Col_EdiSendDate = "EdiSendDate";
        /// <summary> ＥＤＩ取込日 </summary>
        public const string ct_Col_EdiTakeInDate = "EdiTakeInDate";
        /// <summary> ＵＯＥリマーク１ </summary>
        public const string ct_Col_UoeRemark1 = "UoeRemark1";
        /// <summary> ＵＯＥリマーク２ </summary>
        public const string ct_Col_UoeRemark2 = "UoeRemark2";
        /// <summary> 伝票発行区分 </summary>
        public const string ct_Col_SlipPrintDivCd = "SlipPrintDivCd";
        /// <summary> 伝票発行済区分 </summary>
        public const string ct_Col_SlipPrintFinishCd = "SlipPrintFinishCd";
        /// <summary> 売上伝票発行日 </summary>
        public const string ct_Col_SalesSlipPrintDate = "SalesSlipPrintDate";
        /// <summary> 業種コード </summary>
        public const string ct_Col_BusinessTypeCode = "BusinessTypeCode";
        /// <summary> 業種名称 </summary>
        public const string ct_Col_BusinessTypeName = "BusinessTypeName";
        /// <summary> 発注番号 </summary>
        public const string ct_Col_OrderNumber = "OrderNumber";
        /// <summary> 納品区分 </summary>
        public const string ct_Col_DeliveredGoodsDiv = "DeliveredGoodsDiv";
        /// <summary> 納品区分名称 </summary>
        public const string ct_Col_DeliveredGoodsDivNm = "DeliveredGoodsDivNm";
        /// <summary> 販売エリアコード </summary>
        public const string ct_Col_SalesAreaCode = "SalesAreaCode";
        /// <summary> 販売エリア名称 </summary>
        public const string ct_Col_SalesAreaName = "SalesAreaName";
        /// <summary> 消込フラグ </summary>
        public const string ct_Col_ReconcileFlag = "ReconcileFlag";
        /// <summary> 伝票印刷設定用帳票ID </summary>
        public const string ct_Col_SlipPrtSetPaperId = "SlipPrtSetPaperId";
        /// <summary> 一式伝票区分 </summary>
        public const string ct_Col_CompleteCd = "CompleteCd";
        /// <summary> 売上金額端数処理区分 </summary>
        public const string ct_Col_SalesPriceFracProcCd = "SalesPriceFracProcCd";
        /// <summary> 在庫商品合計金額（税抜） </summary>
        public const string ct_Col_StockGoodsTtlTaxExc = "StockGoodsTtlTaxExc";
        /// <summary> 純正商品合計金額（税抜） </summary>
        public const string ct_Col_PureGoodsTtlTaxExc = "PureGoodsTtlTaxExc";
        /// <summary> 定価印刷区分 </summary>
        public const string ct_Col_ListPricePrintDiv = "ListPricePrintDiv";
        /// <summary> 元号表示区分１ </summary>
        public const string ct_Col_EraNameDispCd1 = "EraNameDispCd1";
        /// <summary> 見積消費税区分 </summary>
        public const string ct_Col_EstimaTaxDivCd = "EstimaTaxDivCd";
        /// <summary> 見積書印刷区分 </summary>
        public const string ct_Col_EstimateFormPrtCd = "EstimateFormPrtCd";
        /// <summary> 見積件名 </summary>
        public const string ct_Col_EstimateSubject = "EstimateSubject";
        /// <summary> 脚注１ </summary>
        public const string ct_Col_Footnotes1 = "Footnotes1";
        /// <summary> 脚注２ </summary>
        public const string ct_Col_Footnotes2 = "Footnotes2";
        /// <summary> 見積タイトル１ </summary>
        public const string ct_Col_EstimateTitle1 = "EstimateTitle1";
        /// <summary> 見積タイトル２ </summary>
        public const string ct_Col_EstimateTitle2 = "EstimateTitle2";
        /// <summary> 見積タイトル３ </summary>
        public const string ct_Col_EstimateTitle3 = "EstimateTitle3";
        /// <summary> 見積タイトル４ </summary>
        public const string ct_Col_EstimateTitle4 = "EstimateTitle4";
        /// <summary> 見積タイトル５ </summary>
        public const string ct_Col_EstimateTitle5 = "EstimateTitle5";
        /// <summary> 見積備考１ </summary>
        public const string ct_Col_EstimateNote1 = "EstimateNote1";
        /// <summary> 見積備考２ </summary>
        public const string ct_Col_EstimateNote2 = "EstimateNote2";
        /// <summary> 見積備考３ </summary>
        public const string ct_Col_EstimateNote3 = "EstimateNote3";
        /// <summary> 見積備考４ </summary>
        public const string ct_Col_EstimateNote4 = "EstimateNote4";
        /// <summary> 見積備考５ </summary>
        public const string ct_Col_EstimateNote5 = "EstimateNote5";
        /// <summary> 見積有効期限 </summary>
        public const string ct_Col_EstimateValidityDate = "EstimateValidityDate";
        /// <summary> 品番印字区分 </summary>
        public const string ct_Col_PartsNoPrtCd = "PartsNoPrtCd";
        /// <summary> オプション印字区分 </summary>
        public const string ct_Col_OptionPringDivCd = "OptionPringDivCd";
        /// <summary> 掛率使用区分 </summary>
        public const string ct_Col_RateUseCode = "RateUseCode";

        /// <summary> 売上伝票番号（仮） </summary>
        public const string ct_Col_TempSalesSlipNum = "TempSalesSlipNum";
        /// <summary> 出庫数合計 </summary>
        public const string ct_Col_TotalCnt = "TotalCnt";
        /// <summary>UOE伝票種別</summary>
        public const string ct_Col_SlipCd = "SlipCd";
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// 売上データテーブルスキーマクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上データテーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
        /// <br>Programmer : 96186　立花裕輔</br>
        /// <br>Date       : 2008.05.26</br>
        /// </remarks>
        public SalesSlipSchema()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// データセット、データテーブル設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2006.01.21</br>
        /// </remarks>
        public static void SettingDataSet(ref DataSet ds, string dataTableName)
        {
            // テーブルが存在するかどうかをチェック
            if ((ds.Tables.Contains(dataTableName)))
            {
                // TODO:テーブルが存在するときはクリアーするのみ
                // スキーマをもう一度設定するようなことはしない。
                ds.Tables[dataTableName].Clear();
            }
            else
            {
                CreateTable(ref ds, dataTableName);

            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 売上データ作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2008.05.26</br>
        /// </remarks>
        private static void CreateTable(ref DataSet ds, string dataTableName)
        {
            DataTable dt = null;
            // スキーマ設定
            ds.Tables.Add(dataTableName);
            dt = ds.Tables[dataTableName];

            // 作成日時
            dt.Columns.Add(ct_Col_CreateDateTime, typeof(Int64));
            dt.Columns[ct_Col_CreateDateTime].DefaultValue = defValueInt64;
            // 更新日時
            dt.Columns.Add(ct_Col_UpdateDateTime, typeof(Int64));
            dt.Columns[ct_Col_UpdateDateTime].DefaultValue = defValueInt64;
            // 企業コード
            dt.Columns.Add(ct_Col_EnterpriseCode, typeof(string));
            dt.Columns[ct_Col_EnterpriseCode].DefaultValue = defValuestring;
            // GUID
            dt.Columns.Add(ct_Col_FileHeaderGuid, typeof(Guid));
            dt.Columns[ct_Col_FileHeaderGuid].DefaultValue = Guid.Empty;
            // 更新従業員コード
            dt.Columns.Add(ct_Col_UpdEmployeeCode, typeof(string));
            dt.Columns[ct_Col_UpdEmployeeCode].DefaultValue = defValuestring;
            // 更新アセンブリID1
            dt.Columns.Add(ct_Col_UpdAssemblyId1, typeof(string));
            dt.Columns[ct_Col_UpdAssemblyId1].DefaultValue = defValuestring;
            // 更新アセンブリID2
            dt.Columns.Add(ct_Col_UpdAssemblyId2, typeof(string));
            dt.Columns[ct_Col_UpdAssemblyId2].DefaultValue = defValuestring;
            // 論理削除区分
            dt.Columns.Add(ct_Col_LogicalDeleteCode, typeof(Int32));
            dt.Columns[ct_Col_LogicalDeleteCode].DefaultValue = defValueInt32;
            // 受注ステータス
            dt.Columns.Add(ct_Col_AcptAnOdrStatus, typeof(Int32));
            dt.Columns[ct_Col_AcptAnOdrStatus].DefaultValue = defValueInt32;
            // 売上伝票番号
            dt.Columns.Add(ct_Col_SalesSlipNum, typeof(string));
            dt.Columns[ct_Col_SalesSlipNum].DefaultValue = defValuestring;
            // 拠点コード
            dt.Columns.Add(ct_Col_SectionCode, typeof(string));
            dt.Columns[ct_Col_SectionCode].DefaultValue = defValuestring;
            // 部門コード
            dt.Columns.Add(ct_Col_SubSectionCode, typeof(Int32));
            dt.Columns[ct_Col_SubSectionCode].DefaultValue = defValueInt32;
            // 赤伝区分
            dt.Columns.Add(ct_Col_DebitNoteDiv, typeof(Int32));
            dt.Columns[ct_Col_DebitNoteDiv].DefaultValue = defValueInt32;
            // 赤黒連結売上伝票番号
            dt.Columns.Add(ct_Col_DebitNLnkSalesSlNum, typeof(string));
            dt.Columns[ct_Col_DebitNLnkSalesSlNum].DefaultValue = defValuestring;
            // 売上伝票区分
            dt.Columns.Add(ct_Col_SalesSlipCd, typeof(Int32));
            dt.Columns[ct_Col_SalesSlipCd].DefaultValue = defValueInt32;
            // 売上商品区分
            dt.Columns.Add(ct_Col_SalesGoodsCd, typeof(Int32));
            dt.Columns[ct_Col_SalesGoodsCd].DefaultValue = defValueInt32;
            // 売掛区分
            dt.Columns.Add(ct_Col_AccRecDivCd, typeof(Int32));
            dt.Columns[ct_Col_AccRecDivCd].DefaultValue = defValueInt32;
            // 売上入力拠点コード
            dt.Columns.Add(ct_Col_SalesInpSecCd, typeof(string));
            dt.Columns[ct_Col_SalesInpSecCd].DefaultValue = defValuestring;
            // 請求計上拠点コード
            dt.Columns.Add(ct_Col_DemandAddUpSecCd, typeof(string));
            dt.Columns[ct_Col_DemandAddUpSecCd].DefaultValue = defValuestring;
            // 実績計上拠点コード
            dt.Columns.Add(ct_Col_ResultsAddUpSecCd, typeof(string));
            dt.Columns[ct_Col_ResultsAddUpSecCd].DefaultValue = defValuestring;
            // 更新拠点コード
            dt.Columns.Add(ct_Col_UpdateSecCd, typeof(string));
            dt.Columns[ct_Col_UpdateSecCd].DefaultValue = defValuestring;
            // 売上伝票更新区分
            dt.Columns.Add(ct_Col_SalesSlipUpdateCd, typeof(Int32));
            dt.Columns[ct_Col_SalesSlipUpdateCd].DefaultValue = defValueInt32;
            // 伝票検索日付
            dt.Columns.Add(ct_Col_SearchSlipDate, typeof(DateTime));
            dt.Columns[ct_Col_SearchSlipDate].DefaultValue = DateTime.MinValue;
            // 出荷日付
            dt.Columns.Add(ct_Col_ShipmentDay, typeof(DateTime));
            dt.Columns[ct_Col_ShipmentDay].DefaultValue = DateTime.MinValue;
            // 売上日付
            dt.Columns.Add(ct_Col_SalesDate, typeof(DateTime));
            dt.Columns[ct_Col_SalesDate].DefaultValue = DateTime.MinValue;
            // 計上日付
            dt.Columns.Add(ct_Col_AddUpADate, typeof(DateTime));
            dt.Columns[ct_Col_AddUpADate].DefaultValue = DateTime.MinValue;
            // 来勘区分
            dt.Columns.Add(ct_Col_DelayPaymentDiv, typeof(Int32));
            dt.Columns[ct_Col_DelayPaymentDiv].DefaultValue = defValueInt32;
            // 見積書番号
            dt.Columns.Add(ct_Col_EstimateFormNo, typeof(string));
            dt.Columns[ct_Col_EstimateFormNo].DefaultValue = defValuestring;
            // 見積区分
            dt.Columns.Add(ct_Col_EstimateDivide, typeof(Int32));
            dt.Columns[ct_Col_EstimateDivide].DefaultValue = defValueInt32;
            // 入力担当者コード
            dt.Columns.Add(ct_Col_InputAgenCd, typeof(string));
            dt.Columns[ct_Col_InputAgenCd].DefaultValue = defValuestring;
            // 入力担当者名称
            dt.Columns.Add(ct_Col_InputAgenNm, typeof(string));
            dt.Columns[ct_Col_InputAgenNm].DefaultValue = defValuestring;
            // 売上入力者コード
            dt.Columns.Add(ct_Col_SalesInputCode, typeof(string));
            dt.Columns[ct_Col_SalesInputCode].DefaultValue = defValuestring;
            // 売上入力者名称
            dt.Columns.Add(ct_Col_SalesInputName, typeof(string));
            dt.Columns[ct_Col_SalesInputName].DefaultValue = defValuestring;
            // 受付従業員コード
            dt.Columns.Add(ct_Col_FrontEmployeeCd, typeof(string));
            dt.Columns[ct_Col_FrontEmployeeCd].DefaultValue = defValuestring;
            // 受付従業員名称
            dt.Columns.Add(ct_Col_FrontEmployeeNm, typeof(string));
            dt.Columns[ct_Col_FrontEmployeeNm].DefaultValue = defValuestring;
            // 販売従業員コード
            dt.Columns.Add(ct_Col_SalesEmployeeCd, typeof(string));
            dt.Columns[ct_Col_SalesEmployeeCd].DefaultValue = defValuestring;
            // 販売従業員名称
            dt.Columns.Add(ct_Col_SalesEmployeeNm, typeof(string));
            dt.Columns[ct_Col_SalesEmployeeNm].DefaultValue = defValuestring;
            // 総額表示方法区分
            dt.Columns.Add(ct_Col_TotalAmountDispWayCd, typeof(Int32));
            dt.Columns[ct_Col_TotalAmountDispWayCd].DefaultValue = defValueInt32;
            // 総額表示掛率適用区分
            dt.Columns.Add(ct_Col_TtlAmntDispRateApy, typeof(Int32));
            dt.Columns[ct_Col_TtlAmntDispRateApy].DefaultValue = defValueInt32;
            // 売上伝票合計（税込み）
            dt.Columns.Add(ct_Col_SalesTotalTaxInc, typeof(Int64));
            dt.Columns[ct_Col_SalesTotalTaxInc].DefaultValue = defValueInt64;
            // 売上伝票合計（税抜き）
            dt.Columns.Add(ct_Col_SalesTotalTaxExc, typeof(Int64));
            dt.Columns[ct_Col_SalesTotalTaxExc].DefaultValue = defValueInt64;
            // 売上部品合計（税込み）
            dt.Columns.Add(ct_Col_SalesPrtTotalTaxInc, typeof(Int64));
            dt.Columns[ct_Col_SalesPrtTotalTaxInc].DefaultValue = defValueInt64;
            // 売上部品合計（税抜き）
            dt.Columns.Add(ct_Col_SalesPrtTotalTaxExc, typeof(Int64));
            dt.Columns[ct_Col_SalesPrtTotalTaxExc].DefaultValue = defValueInt64;
            // 売上作業合計（税込み）
            dt.Columns.Add(ct_Col_SalesWorkTotalTaxInc, typeof(Int64));
            dt.Columns[ct_Col_SalesWorkTotalTaxInc].DefaultValue = defValueInt64;
            // 売上作業合計（税抜き）
            dt.Columns.Add(ct_Col_SalesWorkTotalTaxExc, typeof(Int64));
            dt.Columns[ct_Col_SalesWorkTotalTaxExc].DefaultValue = defValueInt64;
            // 売上小計（税込み）
            dt.Columns.Add(ct_Col_SalesSubtotalTaxInc, typeof(Int64));
            dt.Columns[ct_Col_SalesSubtotalTaxInc].DefaultValue = defValueInt64;
            // 売上小計（税抜き）
            dt.Columns.Add(ct_Col_SalesSubtotalTaxExc, typeof(Int64));
            dt.Columns[ct_Col_SalesSubtotalTaxExc].DefaultValue = defValueInt64;
            // 売上部品小計（税込み）
            dt.Columns.Add(ct_Col_SalesPrtSubttlInc, typeof(Int64));
            dt.Columns[ct_Col_SalesPrtSubttlInc].DefaultValue = defValueInt64;
            // 売上部品小計（税抜き）
            dt.Columns.Add(ct_Col_SalesPrtSubttlExc, typeof(Int64));
            dt.Columns[ct_Col_SalesPrtSubttlExc].DefaultValue = defValueInt64;
            // 売上作業小計（税込み）
            dt.Columns.Add(ct_Col_SalesWorkSubttlInc, typeof(Int64));
            dt.Columns[ct_Col_SalesWorkSubttlInc].DefaultValue = defValueInt64;
            // 売上作業小計（税抜き）
            dt.Columns.Add(ct_Col_SalesWorkSubttlExc, typeof(Int64));
            dt.Columns[ct_Col_SalesWorkSubttlExc].DefaultValue = defValueInt64;
            // 売上正価金額
            dt.Columns.Add(ct_Col_SalesNetPrice, typeof(Int64));
            dt.Columns[ct_Col_SalesNetPrice].DefaultValue = defValueInt64;
            // 売上小計（税）
            dt.Columns.Add(ct_Col_SalesSubtotalTax, typeof(Int64));
            dt.Columns[ct_Col_SalesSubtotalTax].DefaultValue = defValueInt64;
            // 売上外税対象額
            dt.Columns.Add(ct_Col_ItdedSalesOutTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedSalesOutTax].DefaultValue = defValueInt64;
            // 売上内税対象額
            dt.Columns.Add(ct_Col_ItdedSalesInTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedSalesInTax].DefaultValue = defValueInt64;
            // 売上小計非課税対象額
            dt.Columns.Add(ct_Col_SalSubttlSubToTaxFre, typeof(Int64));
            dt.Columns[ct_Col_SalSubttlSubToTaxFre].DefaultValue = defValueInt64;
            // 売上金額消費税額（外税）
            dt.Columns.Add(ct_Col_SalesOutTax, typeof(Int64));
            dt.Columns[ct_Col_SalesOutTax].DefaultValue = defValueInt64;
            // 売上金額消費税額（内税）
            dt.Columns.Add(ct_Col_SalAmntConsTaxInclu, typeof(Int64));
            dt.Columns[ct_Col_SalAmntConsTaxInclu].DefaultValue = defValueInt64;
            // 売上値引金額計（税抜き）
            dt.Columns.Add(ct_Col_SalesDisTtlTaxExc, typeof(Int64));
            dt.Columns[ct_Col_SalesDisTtlTaxExc].DefaultValue = defValueInt64;
            // 売上値引外税対象額合計
            dt.Columns.Add(ct_Col_ItdedSalesDisOutTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedSalesDisOutTax].DefaultValue = defValueInt64;
            // 売上値引内税対象額合計
            dt.Columns.Add(ct_Col_ItdedSalesDisInTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedSalesDisInTax].DefaultValue = defValueInt64;
            // 部品値引対象額合計（税抜き）
            dt.Columns.Add(ct_Col_ItdedPartsDisOutTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedPartsDisOutTax].DefaultValue = defValueInt64;
            // 部品値引対象額合計（税込み）
            dt.Columns.Add(ct_Col_ItdedPartsDisInTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedPartsDisInTax].DefaultValue = defValueInt64;
            // 作業値引対象額合計（税抜き）
            dt.Columns.Add(ct_Col_ItdedWorkDisOutTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedWorkDisOutTax].DefaultValue = defValueInt64;
            // 作業値引対象額合計（税込み）
            dt.Columns.Add(ct_Col_ItdedWorkDisInTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedWorkDisInTax].DefaultValue = defValueInt64;
            // 売上値引非課税対象額合計
            dt.Columns.Add(ct_Col_ItdedSalesDisTaxFre, typeof(Int64));
            dt.Columns[ct_Col_ItdedSalesDisTaxFre].DefaultValue = defValueInt64;
            // 売上値引消費税額（外税）
            dt.Columns.Add(ct_Col_SalesDisOutTax, typeof(Int64));
            dt.Columns[ct_Col_SalesDisOutTax].DefaultValue = defValueInt64;
            // 売上値引消費税額（内税）
            dt.Columns.Add(ct_Col_SalesDisTtlTaxInclu, typeof(Int64));
            dt.Columns[ct_Col_SalesDisTtlTaxInclu].DefaultValue = defValueInt64;
            // 部品値引率
            dt.Columns.Add(ct_Col_PartsDiscountRate, typeof(Double));
            dt.Columns[ct_Col_PartsDiscountRate].DefaultValue = defValueDouble;
            // 工賃値引率
            dt.Columns.Add(ct_Col_RavorDiscountRate, typeof(Double));
            dt.Columns[ct_Col_RavorDiscountRate].DefaultValue = defValueDouble;
            // 原価金額計
            dt.Columns.Add(ct_Col_TotalCost, typeof(Int64));
            dt.Columns[ct_Col_TotalCost].DefaultValue = defValueInt64;
            // 消費税転嫁方式
            dt.Columns.Add(ct_Col_ConsTaxLayMethod, typeof(Int32));
            dt.Columns[ct_Col_ConsTaxLayMethod].DefaultValue = defValueInt32;
            // 消費税税率
            dt.Columns.Add(ct_Col_ConsTaxRate, typeof(Double));
            dt.Columns[ct_Col_ConsTaxRate].DefaultValue = defValueDouble;
            // 端数処理区分
            dt.Columns.Add(ct_Col_FractionProcCd, typeof(Int32));
            dt.Columns[ct_Col_FractionProcCd].DefaultValue = defValueInt32;
            // 売掛消費税
            dt.Columns.Add(ct_Col_AccRecConsTax, typeof(Int64));
            dt.Columns[ct_Col_AccRecConsTax].DefaultValue = defValueInt64;
            // 自動入金区分
            dt.Columns.Add(ct_Col_AutoDepositCd, typeof(Int32));
            dt.Columns[ct_Col_AutoDepositCd].DefaultValue = defValueInt32;
            // 自動入金伝票番号
            dt.Columns.Add(ct_Col_AutoDepositSlipNo, typeof(Int32));
            dt.Columns[ct_Col_AutoDepositSlipNo].DefaultValue = defValueInt32;
            // 入金引当合計額
            dt.Columns.Add(ct_Col_DepositAllowanceTtl, typeof(Int64));
            dt.Columns[ct_Col_DepositAllowanceTtl].DefaultValue = defValueInt64;
            // 入金引当残高
            dt.Columns.Add(ct_Col_DepositAlwcBlnce, typeof(Int64));
            dt.Columns[ct_Col_DepositAlwcBlnce].DefaultValue = defValueInt64;
            // 請求先コード
            dt.Columns.Add(ct_Col_ClaimCode, typeof(Int32));
            dt.Columns[ct_Col_ClaimCode].DefaultValue = defValueInt32;
            // 請求先略称
            dt.Columns.Add(ct_Col_ClaimSnm, typeof(string));
            dt.Columns[ct_Col_ClaimSnm].DefaultValue = defValuestring;
            // 得意先コード
            dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
            dt.Columns[ct_Col_CustomerCode].DefaultValue = defValueInt32;
            // 得意先名称
            dt.Columns.Add(ct_Col_CustomerName, typeof(string));
            dt.Columns[ct_Col_CustomerName].DefaultValue = defValuestring;
            // 得意先名称2
            dt.Columns.Add(ct_Col_CustomerName2, typeof(string));
            dt.Columns[ct_Col_CustomerName2].DefaultValue = defValuestring;
            // 得意先略称
            dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
            dt.Columns[ct_Col_CustomerSnm].DefaultValue = defValuestring;
            // 敬称
            dt.Columns.Add(ct_Col_HonorificTitle, typeof(string));
            dt.Columns[ct_Col_HonorificTitle].DefaultValue = defValuestring;
            // 諸口コード
            dt.Columns.Add(ct_Col_OutputNameCode, typeof(Int32));
            dt.Columns[ct_Col_OutputNameCode].DefaultValue = defValueInt32;
            // 諸口名称
            dt.Columns.Add(ct_Col_OutputName, typeof(string));
            dt.Columns[ct_Col_OutputName].DefaultValue = defValuestring;
            // 得意先伝票番号
            dt.Columns.Add(ct_Col_CustSlipNo, typeof(Int32));
            dt.Columns[ct_Col_CustSlipNo].DefaultValue = defValueInt32;
            // 伝票住所区分
            dt.Columns.Add(ct_Col_SlipAddressDiv, typeof(Int32));
            dt.Columns[ct_Col_SlipAddressDiv].DefaultValue = defValueInt32;
            // 納品先コード
            dt.Columns.Add(ct_Col_AddresseeCode, typeof(Int32));
            dt.Columns[ct_Col_AddresseeCode].DefaultValue = defValueInt32;
            // 納品先名称
            dt.Columns.Add(ct_Col_AddresseeName, typeof(string));
            dt.Columns[ct_Col_AddresseeName].DefaultValue = defValuestring;
            // 納品先名称2
            dt.Columns.Add(ct_Col_AddresseeName2, typeof(string));
            dt.Columns[ct_Col_AddresseeName2].DefaultValue = defValuestring;
            // 納品先郵便番号
            dt.Columns.Add(ct_Col_AddresseePostNo, typeof(string));
            dt.Columns[ct_Col_AddresseePostNo].DefaultValue = defValuestring;
            // 納品先住所1(都道府県市区郡・町村・字)
            dt.Columns.Add(ct_Col_AddresseeAddr1, typeof(string));
            dt.Columns[ct_Col_AddresseeAddr1].DefaultValue = defValuestring;
            // 納品先住所3(番地)
            dt.Columns.Add(ct_Col_AddresseeAddr3, typeof(string));
            dt.Columns[ct_Col_AddresseeAddr3].DefaultValue = defValuestring;
            // 納品先住所4(アパート名称)
            dt.Columns.Add(ct_Col_AddresseeAddr4, typeof(string));
            dt.Columns[ct_Col_AddresseeAddr4].DefaultValue = defValuestring;
            // 納品先電話番号
            dt.Columns.Add(ct_Col_AddresseeTelNo, typeof(string));
            dt.Columns[ct_Col_AddresseeTelNo].DefaultValue = defValuestring;
            // 納品先FAX番号
            dt.Columns.Add(ct_Col_AddresseeFaxNo, typeof(string));
            dt.Columns[ct_Col_AddresseeFaxNo].DefaultValue = defValuestring;
            // 相手先伝票番号
            dt.Columns.Add(ct_Col_PartySaleSlipNum, typeof(string));
            dt.Columns[ct_Col_PartySaleSlipNum].DefaultValue = defValuestring;
            // 伝票備考
            dt.Columns.Add(ct_Col_SlipNote, typeof(string));
            dt.Columns[ct_Col_SlipNote].DefaultValue = defValuestring;
            // 伝票備考２
            dt.Columns.Add(ct_Col_SlipNote2, typeof(string));
            dt.Columns[ct_Col_SlipNote2].DefaultValue = defValuestring;
            // 伝票備考３
            dt.Columns.Add(ct_Col_SlipNote3, typeof(string));
            dt.Columns[ct_Col_SlipNote3].DefaultValue = defValuestring;
            // 返品理由コード
            dt.Columns.Add(ct_Col_RetGoodsReasonDiv, typeof(Int32));
            dt.Columns[ct_Col_RetGoodsReasonDiv].DefaultValue = defValueInt32;
            // 返品理由
            dt.Columns.Add(ct_Col_RetGoodsReason, typeof(string));
            dt.Columns[ct_Col_RetGoodsReason].DefaultValue = defValuestring;
            // レジ処理日
            dt.Columns.Add(ct_Col_RegiProcDate, typeof(DateTime));
            dt.Columns[ct_Col_RegiProcDate].DefaultValue = DateTime.MinValue;
            // レジ番号
            dt.Columns.Add(ct_Col_CashRegisterNo, typeof(Int32));
            dt.Columns[ct_Col_CashRegisterNo].DefaultValue = defValueInt32;
            // POSレシート番号
            dt.Columns.Add(ct_Col_PosReceiptNo, typeof(Int32));
            dt.Columns[ct_Col_PosReceiptNo].DefaultValue = defValueInt32;
            // 明細行数
            dt.Columns.Add(ct_Col_DetailRowCount, typeof(Int32));
            dt.Columns[ct_Col_DetailRowCount].DefaultValue = defValueInt32;
            // ＥＤＩ送信日
            dt.Columns.Add(ct_Col_EdiSendDate, typeof(DateTime));
            dt.Columns[ct_Col_EdiSendDate].DefaultValue = DateTime.MinValue;
            // ＥＤＩ取込日
            dt.Columns.Add(ct_Col_EdiTakeInDate, typeof(DateTime));
            dt.Columns[ct_Col_EdiTakeInDate].DefaultValue = DateTime.MinValue;
            // ＵＯＥリマーク１
            dt.Columns.Add(ct_Col_UoeRemark1, typeof(string));
            dt.Columns[ct_Col_UoeRemark1].DefaultValue = defValuestring;
            // ＵＯＥリマーク２
            dt.Columns.Add(ct_Col_UoeRemark2, typeof(string));
            dt.Columns[ct_Col_UoeRemark2].DefaultValue = defValuestring;
            // 伝票発行区分
            dt.Columns.Add(ct_Col_SlipPrintDivCd, typeof(Int32));
            dt.Columns[ct_Col_SlipPrintDivCd].DefaultValue = defValueInt32;
            // 伝票発行済区分
            dt.Columns.Add(ct_Col_SlipPrintFinishCd, typeof(Int32));
            dt.Columns[ct_Col_SlipPrintFinishCd].DefaultValue = defValueInt32;
            // 売上伝票発行日
            dt.Columns.Add(ct_Col_SalesSlipPrintDate, typeof(DateTime));
            dt.Columns[ct_Col_SalesSlipPrintDate].DefaultValue = DateTime.MinValue;
            // 業種コード
            dt.Columns.Add(ct_Col_BusinessTypeCode, typeof(Int32));
            dt.Columns[ct_Col_BusinessTypeCode].DefaultValue = defValueInt32;
            // 業種名称
            dt.Columns.Add(ct_Col_BusinessTypeName, typeof(string));
            dt.Columns[ct_Col_BusinessTypeName].DefaultValue = defValuestring;
            // 発注番号
            dt.Columns.Add(ct_Col_OrderNumber, typeof(string));
            dt.Columns[ct_Col_OrderNumber].DefaultValue = defValuestring;
            // 納品区分
            dt.Columns.Add(ct_Col_DeliveredGoodsDiv, typeof(Int32));
            dt.Columns[ct_Col_DeliveredGoodsDiv].DefaultValue = defValueInt32;
            // 納品区分名称
            dt.Columns.Add(ct_Col_DeliveredGoodsDivNm, typeof(string));
            dt.Columns[ct_Col_DeliveredGoodsDivNm].DefaultValue = defValuestring;
            // 販売エリアコード
            dt.Columns.Add(ct_Col_SalesAreaCode, typeof(Int32));
            dt.Columns[ct_Col_SalesAreaCode].DefaultValue = defValueInt32;
            // 販売エリア名称
            dt.Columns.Add(ct_Col_SalesAreaName, typeof(string));
            dt.Columns[ct_Col_SalesAreaName].DefaultValue = defValuestring;
            // 消込フラグ
            dt.Columns.Add(ct_Col_ReconcileFlag, typeof(Int32));
            dt.Columns[ct_Col_ReconcileFlag].DefaultValue = defValueInt32;
            // 伝票印刷設定用帳票ID
            dt.Columns.Add(ct_Col_SlipPrtSetPaperId, typeof(string));
            dt.Columns[ct_Col_SlipPrtSetPaperId].DefaultValue = defValuestring;
            // 一式伝票区分
            dt.Columns.Add(ct_Col_CompleteCd, typeof(Int32));
            dt.Columns[ct_Col_CompleteCd].DefaultValue = defValueInt32;
            // 売上金額端数処理区分
            dt.Columns.Add(ct_Col_SalesPriceFracProcCd, typeof(Int32));
            dt.Columns[ct_Col_SalesPriceFracProcCd].DefaultValue = defValueInt32;
            // 在庫商品合計金額（税抜）
            dt.Columns.Add(ct_Col_StockGoodsTtlTaxExc, typeof(Int64));
            dt.Columns[ct_Col_StockGoodsTtlTaxExc].DefaultValue = defValueInt64;
            // 純正商品合計金額（税抜）
            dt.Columns.Add(ct_Col_PureGoodsTtlTaxExc, typeof(Int64));
            dt.Columns[ct_Col_PureGoodsTtlTaxExc].DefaultValue = defValueInt64;
            // 定価印刷区分
            dt.Columns.Add(ct_Col_ListPricePrintDiv, typeof(Int32));
            dt.Columns[ct_Col_ListPricePrintDiv].DefaultValue = defValueInt32;
            // 元号表示区分１
            dt.Columns.Add(ct_Col_EraNameDispCd1, typeof(Int32));
            dt.Columns[ct_Col_EraNameDispCd1].DefaultValue = defValueInt32;
            // 見積消費税区分
            dt.Columns.Add(ct_Col_EstimaTaxDivCd, typeof(Int32));
            dt.Columns[ct_Col_EstimaTaxDivCd].DefaultValue = defValueInt32;
            // 見積書印刷区分
            dt.Columns.Add(ct_Col_EstimateFormPrtCd, typeof(Int32));
            dt.Columns[ct_Col_EstimateFormPrtCd].DefaultValue = defValueInt32;
            // 見積件名
            dt.Columns.Add(ct_Col_EstimateSubject, typeof(string));
            dt.Columns[ct_Col_EstimateSubject].DefaultValue = defValuestring;
            // 脚注１
            dt.Columns.Add(ct_Col_Footnotes1, typeof(string));
            dt.Columns[ct_Col_Footnotes1].DefaultValue = defValuestring;
            // 脚注２
            dt.Columns.Add(ct_Col_Footnotes2, typeof(string));
            dt.Columns[ct_Col_Footnotes2].DefaultValue = defValuestring;
            // 見積タイトル１
            dt.Columns.Add(ct_Col_EstimateTitle1, typeof(string));
            dt.Columns[ct_Col_EstimateTitle1].DefaultValue = defValuestring;
            // 見積タイトル２
            dt.Columns.Add(ct_Col_EstimateTitle2, typeof(string));
            dt.Columns[ct_Col_EstimateTitle2].DefaultValue = defValuestring;
            // 見積タイトル３
            dt.Columns.Add(ct_Col_EstimateTitle3, typeof(string));
            dt.Columns[ct_Col_EstimateTitle3].DefaultValue = defValuestring;
            // 見積タイトル４
            dt.Columns.Add(ct_Col_EstimateTitle4, typeof(string));
            dt.Columns[ct_Col_EstimateTitle4].DefaultValue = defValuestring;
            // 見積タイトル５
            dt.Columns.Add(ct_Col_EstimateTitle5, typeof(string));
            dt.Columns[ct_Col_EstimateTitle5].DefaultValue = defValuestring;
            // 見積備考１
            dt.Columns.Add(ct_Col_EstimateNote1, typeof(string));
            dt.Columns[ct_Col_EstimateNote1].DefaultValue = defValuestring;
            // 見積備考２
            dt.Columns.Add(ct_Col_EstimateNote2, typeof(string));
            dt.Columns[ct_Col_EstimateNote2].DefaultValue = defValuestring;
            // 見積備考３
            dt.Columns.Add(ct_Col_EstimateNote3, typeof(string));
            dt.Columns[ct_Col_EstimateNote3].DefaultValue = defValuestring;
            // 見積備考４
            dt.Columns.Add(ct_Col_EstimateNote4, typeof(string));
            dt.Columns[ct_Col_EstimateNote4].DefaultValue = defValuestring;
            // 見積備考５
            dt.Columns.Add(ct_Col_EstimateNote5, typeof(string));
            dt.Columns[ct_Col_EstimateNote5].DefaultValue = defValuestring;
            // 見積有効期限
            dt.Columns.Add(ct_Col_EstimateValidityDate, typeof(DateTime));
            dt.Columns[ct_Col_EstimateValidityDate].DefaultValue = DateTime.MinValue;
            // 品番印字区分
            dt.Columns.Add(ct_Col_PartsNoPrtCd, typeof(Int32));
            dt.Columns[ct_Col_PartsNoPrtCd].DefaultValue = defValueInt32;
            // オプション印字区分
            dt.Columns.Add(ct_Col_OptionPringDivCd, typeof(Int32));
            dt.Columns[ct_Col_OptionPringDivCd].DefaultValue = defValueInt32;
            // 掛率使用区分
            dt.Columns.Add(ct_Col_RateUseCode, typeof(Int32));
            dt.Columns[ct_Col_RateUseCode].DefaultValue = defValueInt32;

            // 売上伝票番号(仮)
            dt.Columns.Add(ct_Col_TempSalesSlipNum, typeof(string));
            dt.Columns[ct_Col_TempSalesSlipNum].DefaultValue = defValuestring;
            // 出庫数合計
            dt.Columns.Add(ct_Col_TotalCnt, typeof(Int32));
            dt.Columns[ct_Col_TotalCnt].DefaultValue = defValueInt32;
            // UOE伝票種別
            dt.Columns.Add(ct_Col_SlipCd, typeof(Int32));
            dt.Columns[ct_Col_SlipCd].DefaultValue = defValueInt32;

            //PrimaryKeyの設定
            //売上データテーブル
            //受注ステータス＋売上伝票番号(仮)
            if (dataTableName == CT_SalesSlipDataTable)
            {
                dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_AcptAnOdrStatus], dt.Columns[ct_Col_TempSalesSlipNum] };
            }
            //受注データテーブル
            //受注ステータス＋売上伝票番号
            else
            {
                dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_AcptAnOdrStatus], dt.Columns[ct_Col_SalesSlipNum] };
            }
        }
        #endregion
    }
}