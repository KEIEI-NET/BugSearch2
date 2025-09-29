//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入データテーブルスキーマクラス
// プログラム概要   : 仕入データテーブル定義を行う
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
    /// 仕入データテーブルスキーマクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入データ抽出結果テーブルスキーマ</br>
    /// <br>Programmer : 96186　立花裕輔</br>
    /// <br>Date       : 2008.05.26</br>
    /// </remarks>
    public class StockSlipSchema
    {
        #region Public Members
        /// <summary>仕入データテーブル名</summary>
        public const string CT_StockSlipDataTable = "StockSlipDataTable";

        /// <summary>Uoe仕入データテーブル名</summary>
        public const string CT_UoeStockSlipDataTable = "UoeStockSlipDataTable";

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
        /// <summary> 仕入形式 </summary>
        public const string ct_Col_SupplierFormal = "SupplierFormal";
        /// <summary> 仕入伝票番号 </summary>
        public const string ct_Col_SupplierSlipNo = "SupplierSlipNo";
        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 部門コード </summary>
        public const string ct_Col_SubSectionCode = "SubSectionCode";
        /// <summary> 赤伝区分 </summary>
        public const string ct_Col_DebitNoteDiv = "DebitNoteDiv";
        /// <summary> 赤黒連結仕入伝票番号 </summary>
        public const string ct_Col_DebitNLnkSuppSlipNo = "DebitNLnkSuppSlipNo";
        /// <summary> 仕入伝票区分 </summary>
        public const string ct_Col_SupplierSlipCd = "SupplierSlipCd";
        /// <summary> 仕入商品区分 </summary>
        public const string ct_Col_StockGoodsCd = "StockGoodsCd";
        /// <summary> 買掛区分 </summary>
        public const string ct_Col_AccPayDivCd = "AccPayDivCd";
        /// <summary> 仕入拠点コード </summary>
        public const string ct_Col_StockSectionCd = "StockSectionCd";
        /// <summary> 仕入計上拠点コード </summary>
        public const string ct_Col_StockAddUpSectionCd = "StockAddUpSectionCd";
        /// <summary> 仕入伝票更新区分 </summary>
        public const string ct_Col_StockSlipUpdateCd = "StockSlipUpdateCd";
        /// <summary> 入力日 </summary>
        public const string ct_Col_InputDay = "InputDay";
        /// <summary> 入荷日 </summary>
        public const string ct_Col_ArrivalGoodsDay = "ArrivalGoodsDay";
        /// <summary> 仕入日 </summary>
        public const string ct_Col_StockDate = "StockDate";
        /// <summary> 仕入計上日付 </summary>
        public const string ct_Col_StockAddUpADate = "StockAddUpADate";
        /// <summary> 来勘区分 </summary>
        public const string ct_Col_DelayPaymentDiv = "DelayPaymentDiv";
        /// <summary> 支払先コード </summary>
        public const string ct_Col_PayeeCode = "PayeeCode";
        /// <summary> 支払先略称 </summary>
        public const string ct_Col_PayeeSnm = "PayeeSnm";
        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> 仕入先名1 </summary>
        public const string ct_Col_SupplierNm1 = "SupplierNm1";
        /// <summary> 仕入先名2 </summary>
        public const string ct_Col_SupplierNm2 = "SupplierNm2";
        /// <summary> 仕入先略称 </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        /// <summary> 業種コード </summary>
        public const string ct_Col_BusinessTypeCode = "BusinessTypeCode";
        /// <summary> 業種名称 </summary>
        public const string ct_Col_BusinessTypeName = "BusinessTypeName";
        /// <summary> 販売エリアコード </summary>
        public const string ct_Col_SalesAreaCode = "SalesAreaCode";
        /// <summary> 販売エリア名称 </summary>
        public const string ct_Col_SalesAreaName = "SalesAreaName";
        /// <summary> 仕入入力者コード </summary>
        public const string ct_Col_StockInputCode = "StockInputCode";
        /// <summary> 仕入入力者名称 </summary>
        public const string ct_Col_StockInputName = "StockInputName";
        /// <summary> 仕入担当者コード </summary>
        public const string ct_Col_StockAgentCode = "StockAgentCode";
        /// <summary> 仕入担当者名称 </summary>
        public const string ct_Col_StockAgentName = "StockAgentName";
        /// <summary> 仕入先総額表示方法区分 </summary>
        public const string ct_Col_SuppTtlAmntDspWayCd = "SuppTtlAmntDspWayCd";
        /// <summary> 総額表示掛率適用区分 </summary>
        public const string ct_Col_TtlAmntDispRateApy = "TtlAmntDispRateApy";
        /// <summary> 仕入金額合計 </summary>
        public const string ct_Col_StockTotalPrice = "StockTotalPrice";
        /// <summary> 仕入金額小計 </summary>
        public const string ct_Col_StockSubttlPrice = "StockSubttlPrice";
        /// <summary> 仕入金額計（税込み） </summary>
        public const string ct_Col_StockTtlPricTaxInc = "StockTtlPricTaxInc";
        /// <summary> 仕入金額計（税抜き） </summary>
        public const string ct_Col_StockTtlPricTaxExc = "StockTtlPricTaxExc";
        /// <summary> 仕入正価金額 </summary>
        public const string ct_Col_StockNetPrice = "StockNetPrice";
        /// <summary> 仕入金額消費税額 </summary>
        public const string ct_Col_StockPriceConsTax = "StockPriceConsTax";
        /// <summary> 仕入外税対象額合計 </summary>
        public const string ct_Col_TtlItdedStcOutTax = "TtlItdedStcOutTax";
        /// <summary> 仕入内税対象額合計 </summary>
        public const string ct_Col_TtlItdedStcInTax = "TtlItdedStcInTax";
        /// <summary> 仕入非課税対象額合計 </summary>
        public const string ct_Col_TtlItdedStcTaxFree = "TtlItdedStcTaxFree";
        /// <summary> 仕入金額消費税額（外税） </summary>
        public const string ct_Col_StockOutTax = "StockOutTax";
        /// <summary> 仕入金額消費税額（内税） </summary>
        public const string ct_Col_StckPrcConsTaxInclu = "StckPrcConsTaxInclu";
        /// <summary> 仕入値引金額計（税抜き） </summary>
        public const string ct_Col_StckDisTtlTaxExc = "StckDisTtlTaxExc";
        /// <summary> 仕入値引外税対象額合計 </summary>
        public const string ct_Col_ItdedStockDisOutTax = "ItdedStockDisOutTax";
        /// <summary> 仕入値引内税対象額合計 </summary>
        public const string ct_Col_ItdedStockDisInTax = "ItdedStockDisInTax";
        /// <summary> 仕入値引非課税対象額合計 </summary>
        public const string ct_Col_ItdedStockDisTaxFre = "ItdedStockDisTaxFre";
        /// <summary> 仕入値引消費税額（外税） </summary>
        public const string ct_Col_StockDisOutTax = "StockDisOutTax";
        /// <summary> 仕入値引消費税額（内税） </summary>
        public const string ct_Col_StckDisTtlTaxInclu = "StckDisTtlTaxInclu";
        /// <summary> 消費税調整額 </summary>
        public const string ct_Col_TaxAdjust = "TaxAdjust";
        /// <summary> 残高調整額 </summary>
        public const string ct_Col_BalanceAdjust = "BalanceAdjust";
        /// <summary> 仕入先消費税転嫁方式コード </summary>
        public const string ct_Col_SuppCTaxLayCd = "SuppCTaxLayCd";
        /// <summary> 仕入先消費税税率 </summary>
        public const string ct_Col_SupplierConsTaxRate = "SupplierConsTaxRate";
        /// <summary> 買掛消費税 </summary>
        public const string ct_Col_AccPayConsTax = "AccPayConsTax";
        /// <summary> 仕入端数処理区分 </summary>
        public const string ct_Col_StockFractionProcCd = "StockFractionProcCd";
        /// <summary> 自動支払区分 </summary>
        public const string ct_Col_AutoPayment = "AutoPayment";
        /// <summary> 自動支払伝票番号 </summary>
        public const string ct_Col_AutoPaySlipNum = "AutoPaySlipNum";
        /// <summary> 返品理由コード </summary>
        public const string ct_Col_RetGoodsReasonDiv = "RetGoodsReasonDiv";
        /// <summary> 返品理由 </summary>
        public const string ct_Col_RetGoodsReason = "RetGoodsReason";
        /// <summary> 相手先伝票番号 </summary>
        public const string ct_Col_PartySaleSlipNum = "PartySaleSlipNum";
        /// <summary> 仕入伝票備考1 </summary>
        public const string ct_Col_SupplierSlipNote1 = "SupplierSlipNote1";
        /// <summary> 仕入伝票備考2 </summary>
        public const string ct_Col_SupplierSlipNote2 = "SupplierSlipNote2";
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
        /// <summary> 仕入伝票発行日 </summary>
        public const string ct_Col_StockSlipPrintDate = "StockSlipPrintDate";
        /// <summary> 伝票印刷設定用帳票ID </summary>
        public const string ct_Col_SlipPrtSetPaperId = "SlipPrtSetPaperId";
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
        /// <summary> 直送区分 </summary>
        public const string ct_Col_DirectSendingCd = "DirectSendingCd";

        /// <summary> 共通伝票番号 </summary>
        public const string ct_Col_CommonSlipNo = "CommonSlipNo";
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// 仕入データテーブルスキーマクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入データテーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
        /// <br>Programmer : 96186　立花裕輔</br>
        /// <br>Date       : 2008.05.26</br>
        /// </remarks>
        public StockSlipSchema()
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
        /// 仕入データ作成処理
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
            dt.Columns.Add(ct_Col_CreateDateTime, typeof(DateTime));
            dt.Columns[ct_Col_CreateDateTime].DefaultValue = DateTime.MinValue;
            // 更新日時
            dt.Columns.Add(ct_Col_UpdateDateTime, typeof(DateTime));
            dt.Columns[ct_Col_UpdateDateTime].DefaultValue = DateTime.MinValue;
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
            // 仕入形式
            dt.Columns.Add(ct_Col_SupplierFormal, typeof(Int32));
            dt.Columns[ct_Col_SupplierFormal].DefaultValue = defValueInt32;
            // 仕入伝票番号
            dt.Columns.Add(ct_Col_SupplierSlipNo, typeof(Int32));
            dt.Columns[ct_Col_SupplierSlipNo].DefaultValue = defValueInt32;
            // 拠点コード
            dt.Columns.Add(ct_Col_SectionCode, typeof(string));
            dt.Columns[ct_Col_SectionCode].DefaultValue = defValuestring;
            // 部門コード
            dt.Columns.Add(ct_Col_SubSectionCode, typeof(Int32));
            dt.Columns[ct_Col_SubSectionCode].DefaultValue = defValueInt32;
            // 赤伝区分
            dt.Columns.Add(ct_Col_DebitNoteDiv, typeof(Int32));
            dt.Columns[ct_Col_DebitNoteDiv].DefaultValue = defValueInt32;
            // 赤黒連結仕入伝票番号
            dt.Columns.Add(ct_Col_DebitNLnkSuppSlipNo, typeof(Int32));
            dt.Columns[ct_Col_DebitNLnkSuppSlipNo].DefaultValue = defValueInt32;
            // 仕入伝票区分
            dt.Columns.Add(ct_Col_SupplierSlipCd, typeof(Int32));
            dt.Columns[ct_Col_SupplierSlipCd].DefaultValue = defValueInt32;
            // 仕入商品区分
            dt.Columns.Add(ct_Col_StockGoodsCd, typeof(Int32));
            dt.Columns[ct_Col_StockGoodsCd].DefaultValue = defValueInt32;
            // 買掛区分
            dt.Columns.Add(ct_Col_AccPayDivCd, typeof(Int32));
            dt.Columns[ct_Col_AccPayDivCd].DefaultValue = defValueInt32;
            // 仕入拠点コード
            dt.Columns.Add(ct_Col_StockSectionCd, typeof(string));
            dt.Columns[ct_Col_StockSectionCd].DefaultValue = defValuestring;
            // 仕入計上拠点コード
            dt.Columns.Add(ct_Col_StockAddUpSectionCd, typeof(string));
            dt.Columns[ct_Col_StockAddUpSectionCd].DefaultValue = defValuestring;
            // 仕入伝票更新区分
            dt.Columns.Add(ct_Col_StockSlipUpdateCd, typeof(Int32));
            dt.Columns[ct_Col_StockSlipUpdateCd].DefaultValue = defValueInt32;
            // 入力日
            dt.Columns.Add(ct_Col_InputDay, typeof(DateTime));
            dt.Columns[ct_Col_InputDay].DefaultValue = DateTime.MinValue;
            // 入荷日
            dt.Columns.Add(ct_Col_ArrivalGoodsDay, typeof(DateTime));
            dt.Columns[ct_Col_ArrivalGoodsDay].DefaultValue = DateTime.MinValue;
            // 仕入日
            dt.Columns.Add(ct_Col_StockDate, typeof(DateTime));
            dt.Columns[ct_Col_StockDate].DefaultValue = DateTime.MinValue;
            // 仕入計上日付
            dt.Columns.Add(ct_Col_StockAddUpADate, typeof(DateTime));
            dt.Columns[ct_Col_StockAddUpADate].DefaultValue = DateTime.MinValue;
            // 来勘区分
            dt.Columns.Add(ct_Col_DelayPaymentDiv, typeof(Int32));
            dt.Columns[ct_Col_DelayPaymentDiv].DefaultValue = defValueInt32;
            // 支払先コード
            dt.Columns.Add(ct_Col_PayeeCode, typeof(Int32));
            dt.Columns[ct_Col_PayeeCode].DefaultValue = defValueInt32;
            // 支払先略称
            dt.Columns.Add(ct_Col_PayeeSnm, typeof(string));
            dt.Columns[ct_Col_PayeeSnm].DefaultValue = defValuestring;
            // 仕入先コード
            dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
            dt.Columns[ct_Col_SupplierCd].DefaultValue = defValueInt32;
            // 仕入先名1
            dt.Columns.Add(ct_Col_SupplierNm1, typeof(string));
            dt.Columns[ct_Col_SupplierNm1].DefaultValue = defValuestring;
            // 仕入先名2
            dt.Columns.Add(ct_Col_SupplierNm2, typeof(string));
            dt.Columns[ct_Col_SupplierNm2].DefaultValue = defValuestring;
            // 仕入先略称
            dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));
            dt.Columns[ct_Col_SupplierSnm].DefaultValue = defValuestring;
            // 業種コード
            dt.Columns.Add(ct_Col_BusinessTypeCode, typeof(Int32));
            dt.Columns[ct_Col_BusinessTypeCode].DefaultValue = defValueInt32;
            // 業種名称
            dt.Columns.Add(ct_Col_BusinessTypeName, typeof(string));
            dt.Columns[ct_Col_BusinessTypeName].DefaultValue = defValuestring;
            // 販売エリアコード
            dt.Columns.Add(ct_Col_SalesAreaCode, typeof(Int32));
            dt.Columns[ct_Col_SalesAreaCode].DefaultValue = defValueInt32;
            // 販売エリア名称
            dt.Columns.Add(ct_Col_SalesAreaName, typeof(string));
            dt.Columns[ct_Col_SalesAreaName].DefaultValue = defValuestring;
            // 仕入入力者コード
            dt.Columns.Add(ct_Col_StockInputCode, typeof(string));
            dt.Columns[ct_Col_StockInputCode].DefaultValue = defValuestring;
            // 仕入入力者名称
            dt.Columns.Add(ct_Col_StockInputName, typeof(string));
            dt.Columns[ct_Col_StockInputName].DefaultValue = defValuestring;
            // 仕入担当者コード
            dt.Columns.Add(ct_Col_StockAgentCode, typeof(string));
            dt.Columns[ct_Col_StockAgentCode].DefaultValue = defValuestring;
            // 仕入担当者名称
            dt.Columns.Add(ct_Col_StockAgentName, typeof(string));
            dt.Columns[ct_Col_StockAgentName].DefaultValue = defValuestring;
            // 仕入先総額表示方法区分
            dt.Columns.Add(ct_Col_SuppTtlAmntDspWayCd, typeof(Int32));
            dt.Columns[ct_Col_SuppTtlAmntDspWayCd].DefaultValue = defValueInt32;
            // 総額表示掛率適用区分
            dt.Columns.Add(ct_Col_TtlAmntDispRateApy, typeof(Int32));
            dt.Columns[ct_Col_TtlAmntDispRateApy].DefaultValue = defValueInt32;
            // 仕入金額合計
            dt.Columns.Add(ct_Col_StockTotalPrice, typeof(Int64));
            dt.Columns[ct_Col_StockTotalPrice].DefaultValue = defValueInt64;
            // 仕入金額小計
            dt.Columns.Add(ct_Col_StockSubttlPrice, typeof(Int64));
            dt.Columns[ct_Col_StockSubttlPrice].DefaultValue = defValueInt64;
            // 仕入金額計（税込み）
            dt.Columns.Add(ct_Col_StockTtlPricTaxInc, typeof(Int64));
            dt.Columns[ct_Col_StockTtlPricTaxInc].DefaultValue = defValueInt64;
            // 仕入金額計（税抜き）
            dt.Columns.Add(ct_Col_StockTtlPricTaxExc, typeof(Int64));
            dt.Columns[ct_Col_StockTtlPricTaxExc].DefaultValue = defValueInt64;
            // 仕入正価金額
            dt.Columns.Add(ct_Col_StockNetPrice, typeof(Int64));
            dt.Columns[ct_Col_StockNetPrice].DefaultValue = defValueInt64;
            // 仕入金額消費税額
            dt.Columns.Add(ct_Col_StockPriceConsTax, typeof(Int64));
            dt.Columns[ct_Col_StockPriceConsTax].DefaultValue = defValueInt64;
            // 仕入外税対象額合計
            dt.Columns.Add(ct_Col_TtlItdedStcOutTax, typeof(Int64));
            dt.Columns[ct_Col_TtlItdedStcOutTax].DefaultValue = defValueInt64;
            // 仕入内税対象額合計
            dt.Columns.Add(ct_Col_TtlItdedStcInTax, typeof(Int64));
            dt.Columns[ct_Col_TtlItdedStcInTax].DefaultValue = defValueInt64;
            // 仕入非課税対象額合計
            dt.Columns.Add(ct_Col_TtlItdedStcTaxFree, typeof(Int64));
            dt.Columns[ct_Col_TtlItdedStcTaxFree].DefaultValue = defValueInt64;
            // 仕入金額消費税額（外税）
            dt.Columns.Add(ct_Col_StockOutTax, typeof(Int64));
            dt.Columns[ct_Col_StockOutTax].DefaultValue = defValueInt64;
            // 仕入金額消費税額（内税）
            dt.Columns.Add(ct_Col_StckPrcConsTaxInclu, typeof(Int64));
            dt.Columns[ct_Col_StckPrcConsTaxInclu].DefaultValue = defValueInt64;
            // 仕入値引金額計（税抜き）
            dt.Columns.Add(ct_Col_StckDisTtlTaxExc, typeof(Int64));
            dt.Columns[ct_Col_StckDisTtlTaxExc].DefaultValue = defValueInt64;
            // 仕入値引外税対象額合計
            dt.Columns.Add(ct_Col_ItdedStockDisOutTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedStockDisOutTax].DefaultValue = defValueInt64;
            // 仕入値引内税対象額合計
            dt.Columns.Add(ct_Col_ItdedStockDisInTax, typeof(Int64));
            dt.Columns[ct_Col_ItdedStockDisInTax].DefaultValue = defValueInt64;
            // 仕入値引非課税対象額合計
            dt.Columns.Add(ct_Col_ItdedStockDisTaxFre, typeof(Int64));
            dt.Columns[ct_Col_ItdedStockDisTaxFre].DefaultValue = defValueInt64;
            // 仕入値引消費税額（外税）
            dt.Columns.Add(ct_Col_StockDisOutTax, typeof(Int64));
            dt.Columns[ct_Col_StockDisOutTax].DefaultValue = defValueInt64;
            // 仕入値引消費税額（内税）
            dt.Columns.Add(ct_Col_StckDisTtlTaxInclu, typeof(Int64));
            dt.Columns[ct_Col_StckDisTtlTaxInclu].DefaultValue = defValueInt64;
            // 消費税調整額
            dt.Columns.Add(ct_Col_TaxAdjust, typeof(Int64));
            dt.Columns[ct_Col_TaxAdjust].DefaultValue = defValueInt64;
            // 残高調整額
            dt.Columns.Add(ct_Col_BalanceAdjust, typeof(Int64));
            dt.Columns[ct_Col_BalanceAdjust].DefaultValue = defValueInt64;
            // 仕入先消費税転嫁方式コード
            dt.Columns.Add(ct_Col_SuppCTaxLayCd, typeof(Int32));
            dt.Columns[ct_Col_SuppCTaxLayCd].DefaultValue = defValueInt32;
            // 仕入先消費税税率
            dt.Columns.Add(ct_Col_SupplierConsTaxRate, typeof(Double));
            dt.Columns[ct_Col_SupplierConsTaxRate].DefaultValue = defValueDouble;
            // 買掛消費税
            dt.Columns.Add(ct_Col_AccPayConsTax, typeof(Int64));
            dt.Columns[ct_Col_AccPayConsTax].DefaultValue = defValueInt64;
            // 仕入端数処理区分
            dt.Columns.Add(ct_Col_StockFractionProcCd, typeof(Int32));
            dt.Columns[ct_Col_StockFractionProcCd].DefaultValue = defValueInt32;
            // 自動支払区分
            dt.Columns.Add(ct_Col_AutoPayment, typeof(Int32));
            dt.Columns[ct_Col_AutoPayment].DefaultValue = defValueInt32;
            // 自動支払伝票番号
            dt.Columns.Add(ct_Col_AutoPaySlipNum, typeof(Int32));
            dt.Columns[ct_Col_AutoPaySlipNum].DefaultValue = defValueInt32;
            // 返品理由コード
            dt.Columns.Add(ct_Col_RetGoodsReasonDiv, typeof(Int32));
            dt.Columns[ct_Col_RetGoodsReasonDiv].DefaultValue = defValueInt32;
            // 返品理由
            dt.Columns.Add(ct_Col_RetGoodsReason, typeof(string));
            dt.Columns[ct_Col_RetGoodsReason].DefaultValue = defValuestring;
            // 相手先伝票番号
            dt.Columns.Add(ct_Col_PartySaleSlipNum, typeof(string));
            dt.Columns[ct_Col_PartySaleSlipNum].DefaultValue = defValuestring;
            // 仕入伝票備考1
            dt.Columns.Add(ct_Col_SupplierSlipNote1, typeof(string));
            dt.Columns[ct_Col_SupplierSlipNote1].DefaultValue = defValuestring;
            // 仕入伝票備考2
            dt.Columns.Add(ct_Col_SupplierSlipNote2, typeof(string));
            dt.Columns[ct_Col_SupplierSlipNote2].DefaultValue = defValuestring;
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
            // 仕入伝票発行日
            dt.Columns.Add(ct_Col_StockSlipPrintDate, typeof(DateTime));
            dt.Columns[ct_Col_StockSlipPrintDate].DefaultValue = DateTime.MinValue;
            // 伝票印刷設定用帳票ID
            dt.Columns.Add(ct_Col_SlipPrtSetPaperId, typeof(string));
            dt.Columns[ct_Col_SlipPrtSetPaperId].DefaultValue = defValuestring;
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
            // 直送区分
            dt.Columns.Add(ct_Col_DirectSendingCd, typeof(Int32));
            dt.Columns[ct_Col_DirectSendingCd].DefaultValue = defValueInt32;

            // 共通伝票番号
            dt.Columns.Add(ct_Col_CommonSlipNo, typeof(string));
            dt.Columns[ct_Col_CommonSlipNo].DefaultValue = defValuestring;

            //PrimaryKeyの設定
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_SupplierFormal], dt.Columns[ct_Col_CommonSlipNo] };
        }
        #endregion
    }
}