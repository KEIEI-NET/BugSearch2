using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 売上確認表(明細単位)抽出結果データテーブルスキーマクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 売上確認表(明細単位)の抽出結果テーブルスキーマです。</br>
	/// <br>Programmer : 22021　谷藤　範幸</br>
	/// <br>Date       : 2006.01.27</br>
    /// <br>UpdateNote : 2008/10/31 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/06/29 30517 夏野 駿希</br>
    /// <br>             Mantis.15691　車種名の印字を車種全角名称から車種半角名称へ変更する。</br>
    /// <br>UpdateNote : 2010/07/14 30531 大矢 睦美</br>
    /// <br>           : Mantis【15806】品名に伝票と同じく品名カナをセットするように修正</br>
    /// <br>UpdateNote : 2011/07/18 施健</br>
    /// <br>           : 自動回答を追加する</br>
    /// <br>UpdateNote : 2011/11/29 陳建明</br>
    /// <br>           : 障害報告 #8076売上確認表/訂正伝票と削除伝票の区別についての対応</br>
    /// <br>Update Note: 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 2020/02/27 3H 尹安</br>
    /// <br>Update Note: 11800255-00　インボイス対応（税率別合計金額不具合修正）</br>
    /// <br>Programmer : 2020/09/05  陳艶丹</br>
    /// </remarks>
	public class MAHNB02349EA
	{
		#region Public Members
        /// <summary>売上確認表(明細単位)データテーブル名</summary>
        public const string CT_SalesConfDataTable = "SalesConfDataTable";

        /// <summary>売上確認表(明細単位)バッファデータテーブル名</summary>
        public const string CT_SalesConfBuffDataTable = "SalesConfBuffDataTable";

		#region 売上確認表（明細単位）カラム情報

        /// <summary> 拠点コード </summary>
        public const string CT_Col_SectionCode = "SectionCode";

        /// <summary> 拠点ガイド名称 </summary>
        public const string CT_Col_SectionGuideNm = "SectionGuideNm";

        /// <summary> 部門コード </summary>
        public const string CT_Col_SubSectionCode = "SubSectionCode";

        /// <summary> 部門名称 </summary>
        public const string CT_Col_SubSectionName = "SubSectionName";

        /// <summary> 売上伝票番号 </summary>
        public const string CT_Col_SalesSlipNum = "SalesSlipNum";

        /// <summary> 請求先コード </summary>
        public const string CT_Col_ClaimCode = "ClaimCode";

        /// <summary> 請求先略称 </summary>
        public const string CT_Col_ClaimSnm = "ClaimSnm";

        /// <summary> 得意先コード </summary>
        public const string CT_Col_CustomerCode = "CustomerCode";

        /// <summary> 得意先略称 </summary>
        public const string CT_Col_CustomerSnm = "CustomerSnm";

        /// <summary> 出荷日付 </summary>
        public const string CT_Col_ShipmentDay = "ShipmentDay";

        /// <summary> 売上日付 </summary>
        public const string CT_Col_SalesDate = "SalesDate";

        /// <summary> 計上日付 </summary>
        public const string CT_Col_AddUpADate = "AddUpADate";

        /// <summary> 売上伝票区分 </summary>
        public const string CT_Col_SalesSlipCd = "SalesSlipCd";

        /// <summary> 売掛区分 </summary>
        public const string CT_Col_AccRecDivCd = "AccRecDivCd";

        /// <summary> 売上入力者コード </summary>
        public const string CT_Col_SalesInputCode = "SalesInputCode";

        /// <summary> 売上入力者名称 </summary>
        public const string CT_Col_SalesInputName = "SalesInputName";

        /// <summary> 受付従業員コード </summary>
        public const string CT_Col_FrontEmployeeCd = "FrontEmployeeCd";

        /// <summary> 受付従業員名称 </summary>
        public const string CT_Col_FrontEmployeeNm = "FrontEmployeeNm";

        /// <summary> 販売従業員コード </summary>
        public const string CT_Col_SalesEmployeeCd = "SalesEmployeeCd";

        /// <summary> 販売従業員名称 </summary>
        public const string CT_Col_SalesEmployeeNm = "SalesEmployeeNm";

        /// <summary> 相手先伝票番号 </summary>
        public const string CT_Col_PartySaleSlipNum = "PartySaleSlipNum";

        /// <summary> 売上伝票合計（税込み） </summary>
        public const string CT_Col_SalesTotalTaxInc = "SalesTotalTaxInc";

        /// <summary> 売上伝票合計（税抜き） </summary>
        public const string CT_Col_SalesTotalTaxExc = "SalesTotalTaxExc";

        /// <summary> 原価金額計 </summary>
        public const string CT_Col_TotalCost = "TotalCost";

        /// <summary> 返品理由コード </summary>
        public const string CT_Col_RetGoodsReasonDiv = "RetGoodsReasonDiv";

        /// <summary> 返品理由 </summary>
        public const string CT_Col_RetGoodsReason = "RetGoodsReason";

        /// <summary> 得意先伝票番号 </summary>
        public const string CT_Col_CustSlipNo = "CustSlipNo";

        /// <summary> 伝票備考 </summary>
        public const string CT_Col_SlipNote = "SlipNote";

        /// <summary> 伝票備考２ </summary>
        public const string CT_Col_SlipNote2 = "SlipNote2";

        /// <summary> 伝票備考３ </summary>
        public const string CT_Col_SlipNote3 = "SlipNote3";

        /// <summary> 業種コード </summary>
        public const string CT_Col_BusinessTypeCode = "BusinessTypeCode";

        /// <summary> 業種名称 </summary>
        public const string CT_Col_BusinessTypeName = "BusinessTypeName";

        /// <summary> 販売エリアコード </summary>
        public const string CT_Col_SalesAreaCode = "SalesAreaCode";

        /// <summary> 販売エリア名称 </summary>
        public const string CT_Col_SalesAreaName = "SalesAreaName";

        /// <summary> ＵＯＥリマーク１ </summary>
        public const string CT_Col_UoeRemark1 = "UoeRemark1";

        /// <summary> ＵＯＥリマーク２ </summary>
        public const string CT_Col_UoeRemark2 = "UoeRemark2";

        /// <summary> 商品番号 </summary>
        public const string CT_Col_GoodsNo = "GoodsNo";

        /// <summary> 商品名称 </summary>
        public const string CT_Col_GoodsName = "GoodsName";

        /// <summary> BL商品コード </summary>
        public const string CT_Col_BLGoodsCode = "BLGoodsCode";

        /// <summary> BL商品コード名称（全角） </summary>
        public const string CT_Col_BLGoodsFullName = "BLGoodsFullName";

        /// <summary> 売上在庫取寄せ区分 </summary>
        public const string CT_Col_SalesOrderDivCd = "SalesOrderDivCd";

        /// <summary> 定価（税込，浮動） </summary>
        public const string CT_Col_ListPriceTaxIncFl = "ListPriceTaxIncFl";

        /// <summary> 定価（税抜，浮動） </summary>
        public const string CT_Col_ListPriceTaxExcFl = "ListPriceTaxExcFl";

        /// <summary> 売価率 </summary>
        public const string CT_Col_SalesRate = "SalesRate";

        /// <summary> 出荷数 </summary>
        public const string CT_Col_ShipmentCnt = "ShipmentCnt";

        /// <summary> 原価単価 </summary>
        public const string CT_Col_SalesUnitCost = "SalesUnitCost";

        /// <summary> 売上単価（税込，浮動） </summary>
        public const string CT_Col_SalesUnPrcTaxIncFl = "SalesUnPrcTaxIncFl";

        /// <summary> 売上単価（税抜，浮動） </summary>
        public const string CT_Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";

        /// <summary> 原価 </summary>
        public const string CT_Col_Cost = "Cost";

        /// <summary> 売上金額（税込み） </summary>
        public const string CT_Col_SalesMoneyTaxInc = "SalesMoneyTaxInc";

        /// <summary> 売上金額（税抜き） </summary>
        public const string CT_Col_SalesMoneyTaxExc = "SalesMoneyTaxExc";

        /// <summary> 仕入先コード </summary>
        public const string CT_Col_SupplierCd = "SupplierCd";

        /// <summary> 仕入先略称 </summary>
        public const string CT_Col_SupplierSnm = "SupplierSnm";

        /// <summary> 仕入伝票番号 </summary>
        public const string CT_Col_SupplierSlipNo = "SupplierSlipNo";

        /// <summary> 倉庫コード </summary>
        public const string CT_Col_WarehouseCode = "WarehouseCode";

        /// <summary> 倉庫名称 </summary>
        public const string CT_Col_WarehouseName = "WarehouseName";

        /// <summary> 倉庫棚番 </summary>
        public const string CT_Col_WarehouseShelfNo = "WarehouseShelfNo";

        /// <summary> 販売区分コード </summary>
        public const string CT_Col_SalesCode = "SalesCode";

        /// <summary> 販売区分名称 </summary>
        public const string CT_Col_SalesCdNm = "SalesCdNm";

        /// <summary> 車種全角名称 </summary>
        public const string CT_Col_ModelFullName = "ModelFullName";

        /// <summary> 型式（フル型） </summary>
        public const string CT_Col_FullModel = "FullModel";

        /// <summary> 型式指定番号 </summary>
        public const string CT_Col_ModelDesignationNo = "ModelDesignationNo";

        /// <summary> 類別番号 </summary>
        public const string CT_Col_CategoryNo = "CategoryNo";

        /// <summary> 車輌管理コード </summary>
        public const string CT_Col_CarMngCode = "CarMngCode";

        /// <summary> 初年度 </summary>
        public const string CT_Col_FirstEntryDate = "FirstEntryDate";

        /// <summary> 取引区分名[伝票] </summary>
        public const string CT_Col_TransactionName = "TransactionName";

        /// <summary> 粗利率[伝票] </summary>
        public const string CT_Col_GrossMarginRate = "GrossMarginRate";

        /// <summary> 粗利チェックマーク[伝票] </summary>
        public const string CT_Col_GrossMarginMarkSlip = "GrossMarginMarkSlip";

        /// <summary> 粗利率[明細] </summary>
        public const string CT_Col_GrossMarginRateDtl = "GrossMarginRateDtl";

        /// <summary> 粗利チェックマーク[明細] </summary>
        public const string CT_Col_GrossMarginMarkDtl = "GrossMarginMarkDtl";

        /// <summary> 売上伝票区分（明細） </summary>
        public const string CT_Col_SalesSlipCdDtl = "SalesSlipCdDtl";

        /// <summary> 売上値引金額計（税抜き） </summary>
        public const string CT_Col_SalesDisTtlTaxExc = "SalesDisTtlTaxExc";

        /// <summary>伝票検索日付(入力日付)</summary>
        /// <remarks>YYYYMMDD</remarks>
        public const string CT_Col_SearchSlipDate = "SearchSlipDate";


        // ↓↓テーブル定義書以外の追加項目
        /// <summary> 売上伝票区分名称 </summary>
        public const string CT_Col_SalesSlipName = "SalesSlipName";

        /// <summary> 類別(明細) </summary>
        public const string CT_Col_CategoryDtl = "CategoryDtl";

        /// <summary> 売上在庫取寄せ区分名称 </summary>
        public const string CT_Col_SalesOrderDivName = "SalesOrderDivName";

        /// <summary> 消費税 </summary>
        public const string CT_SalesConf_Tax = "Tax";

        // --- ADD  施健  2011/07/18 ---------->>>>>
        /// <summary> 自動回答 </summary>
        public const string CT_AutoAnswer = "AutoAnswer";
        // --- ADD  施健  2011/07/18 ----------<<<<<

        /// <summary> 粗利(税抜き)(伝票) </summary>
        public const string CT_SalesConf_GrossProfit = "GrossProfit";

        /// <summary> 粗利(税抜き)(明細) </summary>
        public const string CT_SalesConf_GrossProfitDtl = "GrossProfitDtl";

        /// <summary> 売上行番号(明細) </summary>
        public const string CT_SalesConf_SalesRowNo = "SalesRowNo";

        // 2009.01.21 30413 犬飼 消費税と合計金額の追加 >>>>>>START
        // ↓↓小計部(伝票)の追加項目
        /// <summary>売上数(伝票)</summary>
        public const string CT_SalesConf_SalesCountNumber = "SalesCountNumber";

        /// <summary>売上合計金額</summary>
        public const string CT_SalesConf_TotalMeter = "TotalMeter";

        /// <summary>売上合計原価(税抜き)(伝票)</summary>
        public const string CT_SalesConf_SalesCost = "SalesCost";

        /// <summary>売上合計粗利(税抜き)(伝票)</summary>
        public const string CT_SalesConf_SalesGrossProfit = "SalesGrossProfit";

        /// <summary>売上合計消費税(伝票)</summary>
        public const string CT_SalesConf_SalesTax = "SalesTax";

        /// <summary>売上の消費税込合計金額(伝票)</summary>
        public const string CT_SalesConf_SalesTotalAll = "SalesTotalAll";

        /// <summary>返品数(伝票)</summary>
        public const string CT_SalesConf_ReturnCountNumber = "ReturnCountNumber";

        /// <summary>返品合計金額(税抜き)(伝票)</summary>
        public const string CT_SalesConf_ReturnSalesMoney = "ReturnSalesMoney";
        
        /// <summary>返品合計原価(税抜き)(伝票)</summary>
        public const string CT_SalesConf_SalesReturnCost = "SalesReturnCost";

        /// <summary>返品合計粗利(税抜き)(伝票)</summary>
        public const string CT_SalesConf_ReturnGrossProfit = "ReturnGrossProfit";

        /// <summary>返品合計消費税(伝票)</summary>
        public const string CT_SalesConf_ReturnTax = "ReturnTax";

        /// <summary>返品の消費税込合計金額(伝票)</summary>
        public const string CT_SalesConf_ReturnTotalAll = "ReturnTotalAll";

        /// <summary>値引き合計金額(税抜き)(伝票)</summary>
        public const string CT_SalesConf_DistSalesMoney = "DistSalesMoney";

        /// <summary>値引き合計原価(税抜き)(伝票)</summary>
        public const string CT_SalesConf_DistCost = "DistCost";

        /// <summary>値引き合計粗利(税抜き)(伝票)</summary>
        public const string CT_SalesConf_DistGrossProfit = "DistGrossProfit";

        /// <summary>値引き合計消費税(伝票)</summary>
        public const string CT_SalesConf_DistTax = "DistTax";

        /// <summary>値引きの消費税込合計金額(伝票)</summary>
        public const string CT_SalesConf_DistTotalAll = "DistTotalAll";


        // ↓↓小計部(明細)の追加項目
        /// <summary>売上数(明細)</summary>
        public const string CT_SalesConf_SalesCountnumberDtl = "SalesCountnumberDtl";
        
        /// <summary>売上合計金額(明細)</summary>
        public const string CT_SalesConf_SalesDtl = "SalesDtl";

        /// <summary>売上合計原価(税抜き)(明細)</summary>
        public const string CT_SalesConf_SalesCostDtl = "SalesCostDtl";

        /// <summary>売上合計粗利(税抜き)(明細)</summary>
        public const string CT_SalesConf_SalesGrossProfitDtl = "SalesGrossProfitDtl";

        /// <summary>売上合計消費税(明細)</summary>
        public const string CT_SalesConf_SalesDtlTax = "SalesDtlTax";

        /// <summary>返品数(明細)</summary>
        public const string CT_SalesConf_ReturnSalesCountDtl = "ReturnSalesCountDtl";

        /// <summary>返品合計金額(明細)</summary>
        public const string CT_SalesConf_ReturnDtl = "ReturnDtl";

        /// <summary>返品合計原価(税抜き)(明細)</summary>
        public const string CT_SalesConf_SalesReturnCostDtl = "SalesReturnCostDtl";

        /// <summary>返品合計粗利(税抜き)(明細)</summary>
        public const string CT_SalesConf_ReturnGrossProfitDtl = "ReturnGrossProfitDtl";

        /// <summary>返品合計消費税(明細)</summary>
        public const string CT_SalesConf_ReturnDtlTax = "ReturnDtlTax";

        /// <summary>値引き合計金額(明細)</summary>
        public const string CT_SalesConf_DistDtl = "DistDtl";

        /// <summary>値引き合計原価金額(税抜き)(明細)</summary>
        public const string CT_SalesConf_DistDtlCost = "DistDtlCost";

        /// <summary>値引き合計粗利(税抜き)(明細)</summary>
        public const string CT_SalesConf_DistGrossProfitDtl = "DistGrossProfitDtl";

        /// <summary>値引き合計消費税(明細)</summary>
        public const string CT_SalesConf_DistDtlTax = "DistDtlTax";
        // 2009.01.21 30413 犬飼 消費税と合計金額の追加 <<<<<<END

        // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
        /// <summary> 消費税税率 </summary>
        public const String CT_Col_ConsTaxRate = "ConsTaxRate";

        #region 「消費税税率1」
        /// <summary>Title_税率1</summary>
        public const string CT_SalesConf_TaxRate1_Title = "TaxRate1Title";

        /// <summary>売上数_税率1</summary>
        public const string CT_SalesConf_TaxRate1_SalesCountnumberDtl = "TaxRate1SalesCountnumberDtl";

        /// <summary>売上金額_税率1</summary>
        public const string CT_SalesConf_TaxRate1_SalesDtl = "TaxRate1SalesDtl";

        /// <summary>売上の消費税込合計金額_税率1</summary>
        public const string CT_SalesConf_TaxRate1_SalesTotalAll = "TaxRate1SalesTotalAll";

        /// <summary>売上消費税_税率1</summary>
        public const string CT_SalesConf_TaxRate1_SalesDtlTax = "TaxRate1SalesDtlTax";

        /// <summary>売上原価(税抜き)_税率1</summary>
        public const string CT_SalesConf_TaxRate1_SalesCostDtl = "TaxRate1SalesCostDtl";

        /// <summary>Title_税率1</summary>
        public const string CT_SalesConf_TaxRate1_ReturnTitle = "TaxRate1ReturnTitle";

        /// <summary>返品数_税率1</summary>
        public const string CT_SalesConf_TaxRate1_ReturnSalesCountDtl = "TaxRate1ReturnSalesCountDtl";

        /// <summary>返品金額_税率1</summary>
        public const string CT_SalesConf_TaxRate1_ReturnDtl = "TaxRate1ReturnDtl";

        /// <summary>返品消費税_税率1</summary>
        public const string CT_SalesConf_TaxRate1_ReturnDtlTax = "TaxRate1ReturnDtlTax";

        /// <summary>返品の消費税込合計金額_税率1</summary>
        public const string CT_SalesConf_TaxRate1_ReturnTotalAll = "TaxRate1ReturnTotalAll";

        /// <summary>返品原価(税抜き)_税率1</summary>
        public const string CT_SalesConf_TaxRate1_ReturnCostDtl = "TaxRate1ReturnCostDtl";
        #endregion

        #region 「消費税税率2」
        /// <summary>Title_税率2</summary>
        public const string CT_SalesConf_TaxRate2_Title = "TaxRate2Title";

        /// <summary>売上数_税率２</summary>
        public const string CT_SalesConf_TaxRate2_SalesCountnumberDtl = "TaxRate2SalesCountnumberDtl";

        /// <summary>売上金額_税率２</summary>
        public const string CT_SalesConf_TaxRate2_SalesDtl = "TaxRate2SalesDtl";

        /// <summary>売上消費税_税率２</summary>
        public const string CT_SalesConf_TaxRate2_SalesDtlTax = "TaxRate2SalesDtlTax";

        /// <summary>売上の消費税込合計金額_税率２</summary>
        public const string CT_SalesConf_TaxRate2_SalesTotalAll = "TaxRate2SalesTotalAll";

        /// <summary>売上原価(税抜き)_税率２</summary>
        public const string CT_SalesConf_TaxRate2_SalesCostDtl = "TaxRate2SalesCostDtl";

        /// <summary>Title_税率２</summary>
        public const string CT_SalesConf_TaxRate2_ReturnTitle = "TaxRate2ReturnTitle";

        /// <summary>返品数_税率２</summary>
        public const string CT_SalesConf_TaxRate2_ReturnSalesCountDtl = "TaxRate2ReturnSalesCountDtl";

        /// <summary>返品金額_税率２</summary>
        public const string CT_SalesConf_TaxRate2_ReturnDtl = "TaxRate2ReturnDtl";

        /// <summary>返品消費税_税率２</summary>
        public const string CT_SalesConf_TaxRate2_ReturnDtlTax = "TaxRate2ReturnDtlTax";

        /// <summary>返品の消費税込合計金額_税率２</summary>
        public const string CT_SalesConf_TaxRate2_ReturnTotalAll = "TaxRate2ReturnTotalAll";

        /// <summary>返品原価(税抜き)_税率２</summary>
        public const string CT_SalesConf_TaxRate2_ReturnCostDtl = "TaxRate2ReturnCostDtl";
        #endregion

        #region 「消費税税率 その他」
        /// <summary>Title_その他</summary>
        public const string CT_SalesConf_Other_Title = "OtherTitle";

        /// <summary>売上数_その他</summary>
        public const string CT_SalesConf_Other_SalesCountnumberDtl = "OtherSalesCountnumberDtl";

        /// <summary>売上金額_その他</summary>
        public const string CT_SalesConf_Other_SalesDtl = "OtherSalesDtl";

        /// <summary>売上消費税_その他</summary>
        public const string CT_SalesConf_Other_SalesDtlTax = "OtherSalesDtlTax";

        /// <summary>売上の消費税込合計金額_その他</summary>
        public const string CT_SalesConf_Other_SalesTotalAll = "OtherSalesTotalAll";

        /// <summary>売上原価(税抜き)_その他</summary>
        public const string CT_SalesConf_Other_SalesCostDtl = "OtherSalesCostDtl";

        /// <summary>Title_その他</summary>
        public const string CT_SalesConf_Other_ReturnTitle = "OtherReturnTitle";

        /// <summary>返品数_その他</summary>
        public const string CT_SalesConf_Other_ReturnSalesCountDtl = "OtherReturnSalesCountDtl";

        /// <summary>返品合計金額_その他</summary>
        public const string CT_SalesConf_Other_ReturnDtl = "OtherReturnDtl";

        /// <summary>返品合計消費税_その他</summary>
        public const string CT_SalesConf_Other_ReturnDtlTax = "OtherReturnDtlTax";

        /// <summary>返品の消費税込合計金額_その他</summary>
        public const string CT_SalesConf_Other_ReturnTotalAll = "OtherReturnTotalAll";

        /// <summary>返品原価(税抜き)_その他</summary>
        public const string CT_SalesConf_Other_ReturnCostDtl = "OtherReturnCostDtl";

        #endregion
        // --- ADD END 3H 尹安 2020/02/27 -----<<<<<

        // ----- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
        #region 「消費税税率 非課税」
        /// <summary>Title_非課税</summary>
        public const string CT_SalesConf_TaxFree_Title = "TaxFreeTitle";

        /// <summary>売上数_非課税</summary>
        public const string CT_SalesConf_TaxFree_SalesCountnumberDtl = "TaxFreeSalesCountnumberDtl";

        /// <summary>売上金額_非課税</summary>
        public const string CT_SalesConf_TaxFree_SalesDtl = "TaxFreeSalesDtl";

        /// <summary>売上消費税_非課税</summary>
        public const string CT_SalesConf_TaxFree_SalesDtlTax = "TaxFreeSalesDtlTax";

        /// <summary>売上の消費税込合計金額_非課税</summary>
        public const string CT_SalesConf_TaxFree_SalesTotalAll = "TaxFreeSalesTotalAll";

        /// <summary>売上原価(税抜き)_非課税</summary>
        public const string CT_SalesConf_TaxFree_SalesCostDtl = "TaxFreeSalesCostDtl";

        /// <summary>Title_非課税</summary>
        public const string CT_SalesConf_TaxFree_ReturnTitle = "TaxFreeReturnTitle";

        /// <summary>返品数_非課税</summary>
        public const string CT_SalesConf_TaxFree_ReturnSalesCountDtl = "TaxFreeReturnSalesCountDtl";

        /// <summary>返品合計金額_非課税</summary>
        public const string CT_SalesConf_TaxFree_ReturnDtl = "TaxFreeReturnDtl";

        /// <summary>返品合計消費税_非課税</summary>
        public const string CT_SalesConf_TaxFree_ReturnDtlTax = "TaxFreeReturnDtlTax";

        /// <summary>返品の消費税込合計金額_非課税</summary>
        public const string CT_SalesConf_TaxFree_ReturnTotalAll = "TaxFreeReturnTotalAll";

        /// <summary>返品原価(税抜き)_非課税</summary>
        public const string CT_SalesConf_TaxFree_ReturnCostDtl = "TaxFreeReturnCostDtl";

        #endregion
        // ----- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<

        // 伝票タイプの印字用日付
        /// <summary> 売上日付(伝票タイプ印字用) </summary>
        /// <remarks>YY/MM/DD</remarks>
        public const string CT_Col_SalesDateY2 = "SalesDateY2";

        /// <summary> 計上日付(伝票タイプ印字用) </summary>
        /// <remarks>YY/MM/DD</remarks>
        public const string CT_Col_AddUpADateY2 = "AddUpADateY2";

        /// <summary> 伝票検索日付(入力日付)(伝票タイプ印字用) </summary>
        /// <remarks>YY/MM/DD</remarks>
        public const string CT_Col_SearchSlipDateY2 = "SearchSlipDateY2";

        // --- ADD 2008/10/31 --------------------------------------------------------->>>>>
        /// <summary>消費税転嫁方式[伝票]</summary>
        public const string CT_Col_ConsTaxLayMethod = "ConsTaxLayMethod";		
        /// <summary>課税区分[明細]</summary>
        public const string CT_Col_TaxationDivCd = "TaxationDivCd";
        /// <summary>合計金額(金額＋消費税)</summary>
        public const string CT_Col_SalesTotalTaxExcPlusTax = "SalesTotalTaxExcPlusTax";
        // --- ADD 2008/10/31 ---------------------------------------------------------<<<<<

        // 2010/06/29 Add >>>
        /// <summary> 車種半角名称 </summary>
        public const string CT_Col_ModelHalfName = "ModelHalfName";
        // 2010/06/29 Add <<<

        // --- ADD  大矢睦美  2010/07/14 ---------->>>>>
        /// <summary> 商品名称カナ</summary>
        public const string CT_Col_GoodsNameKana = "GoodsNameKana";
        // --- ADD  大矢睦美  2010/07/14 ----------<<<<<
        
        /// <summary>キーブレイク</summary>
        public const string COL_KEYBREAK_AR = "KEYBREAK_AR";

        public const string CT_COL_LOGICALDELETECODE = "LogicalDeleteCode";// --- ADD  陳建明  2010/11/29 
        #endregion

        #endregion

        #region Constructor
        /// <summary>
		/// 売上確認表抽出結果データテーブルスキーマクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上確認表抽出結果データテーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
		/// <br>Programmer : 22021　谷藤　範幸</br>
		/// <br>Date       : 2006.01.27</br>
		/// </remarks>
		public MAHNB02349EA()
		{
		}
		#endregion
		
		#region Public Methods
		/// <summary>
		/// データセット、データテーブル設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 22021 谷藤　範幸</br>
		/// <br>Date       : 2006.01.21</br>
		/// </remarks>
		public static void SettingDataSet(ref DataSet ds)
		{
			// テーブルが存在するかどうかをチェック
			if ( (ds.Tables.Contains(CT_SalesConfDataTable)) )
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
				ds.Tables[CT_SalesConfDataTable].Clear();
			}
			else
			{
                CreateSaleConfTable(ref ds, 0);

			}
			
			// 売上チェックリストバッファデータテーブル------------------------------------------
			// テーブルが存在するかどうかをチェック
			if ((ds.Tables.Contains(CT_SalesConfBuffDataTable)))
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
				ds.Tables[CT_SalesConfBuffDataTable].Clear();
			}
			else
			{
                CreateSaleConfTable(ref ds, 1);
			}
		}

		#endregion
		
		#region Private Methods
		
		/// <summary>
		/// 売上確認表(明細単位)抽出結果作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 22021 谷藤　範幸</br>
		/// <br>Date       : 2006.01.28</br>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
		/// <br>Programmer : 3H 尹安</br>
		/// </remarks>
		private static void CreateSaleConfTable(ref DataSet ds, int buffCheck)
		{
			DataTable dt = null;
			if(buffCheck == 0)
			{
				// スキーマ設定
				ds.Tables.Add(CT_SalesConfDataTable);
				dt = ds.Tables[CT_SalesConfDataTable];
			}
			else
			{
				// スキーマ設定
				ds.Tables.Add(CT_SalesConfBuffDataTable);
				dt = ds.Tables[CT_SalesConfBuffDataTable];
			}

            string defValueString = "";
            Int32 defValueInt32 = 0;
            Int64 defValueInt64 = 0;
            Double defValueDouble = 0.0;

            // 拠点コード
            dt.Columns.Add(CT_Col_SectionCode, typeof(string));
            dt.Columns[CT_Col_SectionCode].DefaultValue = defValueString;

            // 拠点ガイド名称
            dt.Columns.Add(CT_Col_SectionGuideNm, typeof(string));
            dt.Columns[CT_Col_SectionGuideNm].DefaultValue = defValueString;

            // 部門コード
            dt.Columns.Add(CT_Col_SubSectionCode, typeof(Int32));
            dt.Columns[CT_Col_SubSectionCode].DefaultValue = defValueInt32;

            // 部門名称
            dt.Columns.Add(CT_Col_SubSectionName, typeof(string));
            dt.Columns[CT_Col_SubSectionName].DefaultValue = defValueString;

            // 売上伝票番号
            dt.Columns.Add(CT_Col_SalesSlipNum, typeof(string));
            dt.Columns[CT_Col_SalesSlipNum].DefaultValue = defValueString;

            // 請求先コード
            dt.Columns.Add(CT_Col_ClaimCode, typeof(Int32));
            dt.Columns[CT_Col_ClaimCode].DefaultValue = defValueInt32;

            // 請求先略称
            dt.Columns.Add(CT_Col_ClaimSnm, typeof(string));
            dt.Columns[CT_Col_ClaimSnm].DefaultValue = defValueString;

            // 得意先コード
            dt.Columns.Add(CT_Col_CustomerCode, typeof(Int32));
            dt.Columns[CT_Col_CustomerCode].DefaultValue = defValueInt32;

            // 得意先略称
            dt.Columns.Add(CT_Col_CustomerSnm, typeof(string));
            dt.Columns[CT_Col_CustomerSnm].DefaultValue = defValueString;

            // 出荷日付
            dt.Columns.Add(CT_Col_ShipmentDay, typeof(string));
            dt.Columns[CT_Col_ShipmentDay].DefaultValue = defValueString;

            // 売上日付
            dt.Columns.Add(CT_Col_SalesDate, typeof(string));
            dt.Columns[CT_Col_SalesDate].DefaultValue = defValueString;

            // 計上日付
            dt.Columns.Add(CT_Col_AddUpADate, typeof(string));
            dt.Columns[CT_Col_AddUpADate].DefaultValue = defValueString;

            // 売上伝票区分
            dt.Columns.Add(CT_Col_SalesSlipCd, typeof(Int32));
            dt.Columns[CT_Col_SalesSlipCd].DefaultValue = defValueInt32;

            // 売掛区分
            dt.Columns.Add(CT_Col_AccRecDivCd, typeof(Int32));
            dt.Columns[CT_Col_AccRecDivCd].DefaultValue = defValueInt32;

            // 売上入力者コード
            dt.Columns.Add(CT_Col_SalesInputCode, typeof(string));
            dt.Columns[CT_Col_SalesInputCode].DefaultValue = defValueString;

            // 売上入力者名称
            dt.Columns.Add(CT_Col_SalesInputName, typeof(string));
            dt.Columns[CT_Col_SalesInputName].DefaultValue = defValueString;

            // 受付従業員コード
            dt.Columns.Add(CT_Col_FrontEmployeeCd, typeof(string));
            dt.Columns[CT_Col_FrontEmployeeCd].DefaultValue = defValueString;

            // 受付従業員名称
            dt.Columns.Add(CT_Col_FrontEmployeeNm, typeof(string));
            dt.Columns[CT_Col_FrontEmployeeNm].DefaultValue = defValueString;

            // 販売従業員コード
            dt.Columns.Add(CT_Col_SalesEmployeeCd, typeof(string));
            dt.Columns[CT_Col_SalesEmployeeCd].DefaultValue = defValueString;

            // 販売従業員名称
            dt.Columns.Add(CT_Col_SalesEmployeeNm, typeof(string));
            dt.Columns[CT_Col_SalesEmployeeNm].DefaultValue = defValueString;

            // 相手先伝票番号
            dt.Columns.Add(CT_Col_PartySaleSlipNum, typeof(string));
            dt.Columns[CT_Col_PartySaleSlipNum].DefaultValue = defValueString;

            // 売上伝票合計（税込み）
            dt.Columns.Add(CT_Col_SalesTotalTaxInc, typeof(Int64));
            dt.Columns[CT_Col_SalesTotalTaxInc].DefaultValue = defValueInt64;

            // 売上伝票合計（税抜き）
            dt.Columns.Add(CT_Col_SalesTotalTaxExc, typeof(Int64));
            dt.Columns[CT_Col_SalesTotalTaxExc].DefaultValue = defValueInt64;

            // 原価金額計
            dt.Columns.Add(CT_Col_TotalCost, typeof(Int64));
            dt.Columns[CT_Col_TotalCost].DefaultValue = defValueInt64;

            // 返品理由コード
            dt.Columns.Add(CT_Col_RetGoodsReasonDiv, typeof(string));
            dt.Columns[CT_Col_RetGoodsReasonDiv].DefaultValue = defValueString;

            // 返品理由
            dt.Columns.Add(CT_Col_RetGoodsReason, typeof(string));
            dt.Columns[CT_Col_RetGoodsReason].DefaultValue = defValueString;

            // 得意先伝票番号
            dt.Columns.Add(CT_Col_CustSlipNo, typeof(string));
            dt.Columns[CT_Col_CustSlipNo].DefaultValue = defValueString;

            // 伝票備考
            dt.Columns.Add(CT_Col_SlipNote, typeof(string));
            dt.Columns[CT_Col_SlipNote].DefaultValue = defValueString;

            // 伝票備考２
            dt.Columns.Add(CT_Col_SlipNote2, typeof(string));
            dt.Columns[CT_Col_SlipNote2].DefaultValue = defValueString;

            // 伝票備考３
            dt.Columns.Add(CT_Col_SlipNote3, typeof(string));
            dt.Columns[CT_Col_SlipNote3].DefaultValue = defValueString;

            // 業種コード
            dt.Columns.Add(CT_Col_BusinessTypeCode, typeof(Int32));
            dt.Columns[CT_Col_BusinessTypeCode].DefaultValue = defValueInt32;

            // 業種名称
            dt.Columns.Add(CT_Col_BusinessTypeName, typeof(string));
            dt.Columns[CT_Col_BusinessTypeName].DefaultValue = defValueString;

            // 販売エリアコード
            dt.Columns.Add(CT_Col_SalesAreaCode, typeof(Int32));
            dt.Columns[CT_Col_SalesAreaCode].DefaultValue = defValueInt32;

            // 販売エリア名称
            dt.Columns.Add(CT_Col_SalesAreaName, typeof(string));
            dt.Columns[CT_Col_SalesAreaName].DefaultValue = defValueString;

            // ＵＯＥリマーク１
            dt.Columns.Add(CT_Col_UoeRemark1, typeof(string));
            dt.Columns[CT_Col_UoeRemark1].DefaultValue = defValueString;

            // ＵＯＥリマーク２
            dt.Columns.Add(CT_Col_UoeRemark2, typeof(string));
            dt.Columns[CT_Col_UoeRemark2].DefaultValue = defValueString;

            // 商品番号
            dt.Columns.Add(CT_Col_GoodsNo, typeof(string));
            dt.Columns[CT_Col_GoodsNo].DefaultValue = defValueString;

            // 商品名称
            dt.Columns.Add(CT_Col_GoodsName, typeof(string));
            dt.Columns[CT_Col_GoodsName].DefaultValue = defValueString;

            // BL商品コード
            dt.Columns.Add(CT_Col_BLGoodsCode, typeof(string));
            dt.Columns[CT_Col_BLGoodsCode].DefaultValue = defValueString;

            // BL商品コード名称（全角）
            dt.Columns.Add(CT_Col_BLGoodsFullName, typeof(string));
            dt.Columns[CT_Col_BLGoodsFullName].DefaultValue = defValueString;

            // 売上在庫取寄せ区分
            dt.Columns.Add(CT_Col_SalesOrderDivCd, typeof(Int32));
            dt.Columns[CT_Col_SalesOrderDivCd].DefaultValue = defValueInt32;

            // 定価（税込，浮動）
            dt.Columns.Add(CT_Col_ListPriceTaxIncFl, typeof(Double));
            dt.Columns[CT_Col_ListPriceTaxIncFl].DefaultValue = defValueDouble;

            // 定価（税抜，浮動）
            dt.Columns.Add(CT_Col_ListPriceTaxExcFl, typeof(Double));
            dt.Columns[CT_Col_ListPriceTaxExcFl].DefaultValue = defValueDouble;

            // 売価率
            dt.Columns.Add(CT_Col_SalesRate, typeof(Double));
            dt.Columns[CT_Col_SalesRate].DefaultValue = defValueDouble;

            // 出荷数
            dt.Columns.Add(CT_Col_ShipmentCnt, typeof(Double));
            dt.Columns[CT_Col_ShipmentCnt].DefaultValue = defValueDouble;

            // 原価単価
            dt.Columns.Add(CT_Col_SalesUnitCost, typeof(Double));
            dt.Columns[CT_Col_SalesUnitCost].DefaultValue = defValueDouble;

            // 売上単価（税込，浮動）
            dt.Columns.Add(CT_Col_SalesUnPrcTaxIncFl, typeof(Double));
            dt.Columns[CT_Col_SalesUnPrcTaxIncFl].DefaultValue = defValueDouble;

            // 売上単価（税抜，浮動）
            dt.Columns.Add(CT_Col_SalesUnPrcTaxExcFl, typeof(Double));
            dt.Columns[CT_Col_SalesUnPrcTaxExcFl].DefaultValue = defValueDouble;

            // 原価
            dt.Columns.Add(CT_Col_Cost, typeof(Int64));
            dt.Columns[CT_Col_Cost].DefaultValue = defValueInt64;

            // 売上金額（税込み）
            dt.Columns.Add(CT_Col_SalesMoneyTaxInc, typeof(Int64));
            dt.Columns[CT_Col_SalesMoneyTaxInc].DefaultValue = defValueInt64;

            // 売上金額（税抜き）
            dt.Columns.Add(CT_Col_SalesMoneyTaxExc, typeof(Int64));
            dt.Columns[CT_Col_SalesMoneyTaxExc].DefaultValue = defValueInt64;

            // 仕入先コード
            dt.Columns.Add(CT_Col_SupplierCd, typeof(string));
            dt.Columns[CT_Col_SupplierCd].DefaultValue = defValueString;

            // 仕入先略称
            dt.Columns.Add(CT_Col_SupplierSnm, typeof(string));
            dt.Columns[CT_Col_SupplierSnm].DefaultValue = defValueString;

            // 仕入伝票番号
            dt.Columns.Add(CT_Col_SupplierSlipNo, typeof(string));
            dt.Columns[CT_Col_SupplierSlipNo].DefaultValue = defValueString;

            // 倉庫コード
            dt.Columns.Add(CT_Col_WarehouseCode, typeof(string));
            dt.Columns[CT_Col_WarehouseCode].DefaultValue = defValueString;

            // 倉庫名称
            dt.Columns.Add(CT_Col_WarehouseName, typeof(string));
            dt.Columns[CT_Col_WarehouseName].DefaultValue = defValueString;

            // 倉庫棚番
            dt.Columns.Add(CT_Col_WarehouseShelfNo, typeof(string));
            dt.Columns[CT_Col_WarehouseShelfNo].DefaultValue = defValueString;

            // 販売区分コード
            dt.Columns.Add(CT_Col_SalesCode, typeof(string));
            dt.Columns[CT_Col_SalesCode].DefaultValue = defValueString;

            // 販売区分名称
            dt.Columns.Add(CT_Col_SalesCdNm, typeof(string));
            dt.Columns[CT_Col_SalesCdNm].DefaultValue = defValueString;

            // 車種全角名称
            dt.Columns.Add(CT_Col_ModelFullName, typeof(string));
            dt.Columns[CT_Col_ModelFullName].DefaultValue = defValueString;

            // 型式（フル型）
            dt.Columns.Add(CT_Col_FullModel, typeof(string));
            dt.Columns[CT_Col_FullModel].DefaultValue = defValueString;

            // 型式指定番号
            dt.Columns.Add(CT_Col_ModelDesignationNo, typeof(Int32));
            dt.Columns[CT_Col_ModelDesignationNo].DefaultValue = defValueInt32;

            // 類別番号
            dt.Columns.Add(CT_Col_CategoryNo, typeof(Int32));
            dt.Columns[CT_Col_CategoryNo].DefaultValue = defValueInt32;

            // 車輌管理コード
            dt.Columns.Add(CT_Col_CarMngCode, typeof(string));
            dt.Columns[CT_Col_CarMngCode].DefaultValue = defValueString;

            // 初年度
            dt.Columns.Add(CT_Col_FirstEntryDate, typeof(string));
            dt.Columns[CT_Col_FirstEntryDate].DefaultValue = defValueString;

            // 取引区分名[伝票]
            dt.Columns.Add(CT_Col_TransactionName, typeof(string));
            dt.Columns[CT_Col_TransactionName].DefaultValue = defValueString;

            // 粗利率[伝票]
            dt.Columns.Add(CT_Col_GrossMarginRate, typeof(Double));
            dt.Columns[CT_Col_GrossMarginRate].DefaultValue = defValueDouble;

            // 粗利チェックマーク[伝票]
            dt.Columns.Add(CT_Col_GrossMarginMarkSlip, typeof(string));
            dt.Columns[CT_Col_GrossMarginMarkSlip].DefaultValue = defValueString;

            // 粗利率[明細]
            dt.Columns.Add(CT_Col_GrossMarginRateDtl, typeof(Double));
            dt.Columns[CT_Col_GrossMarginRateDtl].DefaultValue = defValueDouble;

            // 粗利チェックマーク[明細]
            dt.Columns.Add(CT_Col_GrossMarginMarkDtl, typeof(string));
            dt.Columns[CT_Col_GrossMarginMarkDtl].DefaultValue = defValueString;

            // 売上伝票区分（明細）
            dt.Columns.Add(CT_Col_SalesSlipCdDtl, typeof(Int32));
            dt.Columns[CT_Col_SalesSlipCdDtl].DefaultValue = defValueInt32;

            // 売上値引金額計（税抜き）
            dt.Columns.Add(CT_Col_SalesDisTtlTaxExc, typeof(Int64));
            dt.Columns[CT_Col_SalesDisTtlTaxExc].DefaultValue = defValueInt64;

            // 伝票検索日付(入力日付)
            dt.Columns.Add(CT_Col_SearchSlipDate, typeof(string));
            dt.Columns[CT_Col_SearchSlipDate].DefaultValue = defValueString;


            // ↓↓テーブル定義書以外の追加項目
            // 売上伝票区分名称
            dt.Columns.Add(CT_Col_SalesSlipName, typeof(string));
            dt.Columns[CT_Col_SalesSlipName].DefaultValue = defValueString;

            // 類別(明細)
            dt.Columns.Add(CT_Col_CategoryDtl, typeof(string));
            dt.Columns[CT_Col_CategoryDtl].DefaultValue = defValueString;

            // 売上在庫取寄せ区分名称
            dt.Columns.Add(CT_Col_SalesOrderDivName, typeof(string));
            dt.Columns[CT_Col_SalesOrderDivName].DefaultValue = defValueString;

            // 消費税
            dt.Columns.Add(CT_SalesConf_Tax, typeof(Int64));
            dt.Columns[CT_SalesConf_Tax].DefaultValue = defValueInt64;

            // --- ADD  施健  2011/07/18 ---------->>>>>
            // 自動回答
            dt.Columns.Add(CT_AutoAnswer, typeof(string));
            dt.Columns[CT_AutoAnswer].DefaultValue = defValueString;
            // --- ADD  施健  2011/07/18 ----------<<<<<

            // 粗利(税抜き)(伝票)
            dt.Columns.Add(CT_SalesConf_GrossProfit, typeof(Int64));
            dt.Columns[CT_SalesConf_GrossProfit].DefaultValue = defValueInt64;

            // 粗利(税抜き)(明細)
            dt.Columns.Add(CT_SalesConf_GrossProfitDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_GrossProfitDtl].DefaultValue = defValueInt64;

            // 売上行番号(明細)
            dt.Columns.Add(CT_SalesConf_SalesRowNo, typeof(Int32));
            dt.Columns[CT_SalesConf_SalesRowNo].DefaultValue = defValueInt32;


            // 2009.01.21 30413 犬飼 消費税と合計金額の追加 >>>>>>START
            // ↓↓小計部の追加項目
            // 売上数(伝票)
            dt.Columns.Add(CT_SalesConf_SalesCountNumber, typeof(Int32));
            dt.Columns[CT_SalesConf_SalesCountNumber].DefaultValue = defValueInt32;

            // 売上合計金額
            dt.Columns.Add(CT_SalesConf_TotalMeter, typeof(Int64));
            dt.Columns[CT_SalesConf_TotalMeter].DefaultValue = defValueInt64;

            // 売上合計原価(税抜き)(伝票)
            dt.Columns.Add(CT_SalesConf_SalesCost, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesCost].DefaultValue = defValueInt64;

            // 売上合計粗利(税抜き)(伝票)
            dt.Columns.Add(CT_SalesConf_SalesGrossProfit, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesGrossProfit].DefaultValue = defValueInt64;

            // 売上合計消費税(伝票)
            dt.Columns.Add(CT_SalesConf_SalesTax, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesTax].DefaultValue = defValueInt64;

            // 売上の消費税込合計金額(伝票)
            dt.Columns.Add(CT_SalesConf_SalesTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesTotalAll].DefaultValue = defValueInt64;

            // 返品数(伝票)
            dt.Columns.Add(CT_SalesConf_ReturnCountNumber, typeof(Int32));
            dt.Columns[CT_SalesConf_ReturnCountNumber].DefaultValue = defValueInt32;

            // 返品合計金額(税抜き)(伝票)
            dt.Columns.Add(CT_SalesConf_ReturnSalesMoney, typeof(Int64));
            dt.Columns[CT_SalesConf_ReturnSalesMoney].DefaultValue = defValueInt64;

            // 返品合計原価(税抜き)(伝票)
            dt.Columns.Add(CT_SalesConf_SalesReturnCost, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesReturnCost].DefaultValue = defValueInt64;

            // 返品合計粗利(税抜き)(伝票)
            dt.Columns.Add(CT_SalesConf_ReturnGrossProfit, typeof(Int64));
            dt.Columns[CT_SalesConf_ReturnGrossProfit].DefaultValue = defValueInt64;

            // 返品合計消費税(伝票)
            dt.Columns.Add(CT_SalesConf_ReturnTax, typeof(Int64));
            dt.Columns[CT_SalesConf_ReturnTax].DefaultValue = defValueInt64;

            // 返品の消費税込合計金額(伝票)
            dt.Columns.Add(CT_SalesConf_ReturnTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_ReturnTotalAll].DefaultValue = defValueInt64;

            // 値引き合計金額(税抜き)(伝票)
            dt.Columns.Add(CT_SalesConf_DistSalesMoney, typeof(Int64));
            dt.Columns[CT_SalesConf_DistSalesMoney].DefaultValue = defValueInt64;

            // 値引き合計原価(税抜き)(伝票)
            dt.Columns.Add(CT_SalesConf_DistCost, typeof(Int64));
            dt.Columns[CT_SalesConf_DistCost].DefaultValue = defValueInt64;

            // 値引き合計粗利(税抜き)(伝票)
            dt.Columns.Add(CT_SalesConf_DistGrossProfit, typeof(Int64));
            dt.Columns[CT_SalesConf_DistGrossProfit].DefaultValue = defValueInt64;

            // 値引き合計消費税(伝票)
            dt.Columns.Add(CT_SalesConf_DistTax, typeof(Int64));
            dt.Columns[CT_SalesConf_DistTax].DefaultValue = defValueInt64;

            // 値引きの消費税込合計金額(伝票)
            dt.Columns.Add(CT_SalesConf_DistTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_DistTotalAll].DefaultValue = defValueInt64;


            // ↓↓小計部(明細)の追加項目
            // 売上数(明細)
            dt.Columns.Add(CT_SalesConf_SalesCountnumberDtl, typeof(Int32));
            dt.Columns[CT_SalesConf_SalesCountnumberDtl].DefaultValue = defValueInt32;

            // 売上合計金額(明細)
            dt.Columns.Add(CT_SalesConf_SalesDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesDtl].DefaultValue = defValueInt64;

            // 売上合計原価(税抜き)(明細)
            dt.Columns.Add(CT_SalesConf_SalesCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesCostDtl].DefaultValue = defValueInt64;

            // 売上合計粗利(税抜き)(明細)
            dt.Columns.Add(CT_SalesConf_SalesGrossProfitDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesGrossProfitDtl].DefaultValue = defValueInt64;

            // 売上合計消費税(明細)
            dt.Columns.Add(CT_SalesConf_SalesDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesDtlTax].DefaultValue = defValueInt64;

            // 返品数(明細)
            dt.Columns.Add(CT_SalesConf_ReturnSalesCountDtl, typeof(Int32));
            dt.Columns[CT_SalesConf_ReturnSalesCountDtl].DefaultValue = defValueInt32;

            // 返品合計金額(明細)
            dt.Columns.Add(CT_SalesConf_ReturnDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_ReturnDtl].DefaultValue = defValueInt64;

            // 返品合計原価(税抜き)(明細)
            dt.Columns.Add(CT_SalesConf_SalesReturnCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_SalesReturnCostDtl].DefaultValue = defValueInt64;

            // 返品合計粗利(税抜き)(明細)
            dt.Columns.Add(CT_SalesConf_ReturnGrossProfitDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_ReturnGrossProfitDtl].DefaultValue = defValueInt64;

            // 返品合計消費税(明細)
            dt.Columns.Add(CT_SalesConf_ReturnDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_ReturnDtlTax].DefaultValue = defValueInt64;

            // 値引き合計金額(明細)
            dt.Columns.Add(CT_SalesConf_DistDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_DistDtl].DefaultValue = defValueInt64;

            // 値引き合計原価金額(税抜き)(明細)
            dt.Columns.Add(CT_SalesConf_DistDtlCost, typeof(Int64));
            dt.Columns[CT_SalesConf_DistDtlCost].DefaultValue = defValueInt64;

            // 値引き合計粗利(税抜き)(明細)
            dt.Columns.Add(CT_SalesConf_DistGrossProfitDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_DistGrossProfitDtl].DefaultValue = defValueInt64;

            // 値引き合計消費税(明細)
            dt.Columns.Add(CT_SalesConf_DistDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_DistDtlTax].DefaultValue = defValueInt64;
            // 2009.01.21 30413 犬飼 消費税と合計金額の追加 <<<<<<END

            // --- ADD START 3H 尹安 2020/02/27 ----->>>>>
            dt.Columns.Add(CT_Col_ConsTaxRate, typeof(String));
            dt.Columns[CT_Col_ConsTaxRate].DefaultValue = defValueString;

            #region 「消費税税率税率1」
            // Title_税率1
            dt.Columns.Add(CT_SalesConf_TaxRate1_Title, typeof(String));
            dt.Columns[CT_SalesConf_TaxRate1_Title].DefaultValue = defValueString;

            // 売上数_税率1
            dt.Columns.Add(CT_SalesConf_TaxRate1_SalesCountnumberDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_SalesCountnumberDtl].DefaultValue = defValueInt64;

            // 売上金額_税率1
            dt.Columns.Add(CT_SalesConf_TaxRate1_SalesDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_SalesDtl].DefaultValue = defValueInt64;

            // 売上消費税_税率1
            dt.Columns.Add(CT_SalesConf_TaxRate1_SalesDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_SalesDtlTax].DefaultValue = defValueInt64;

            // 売上の消費税込合計金額_税率1
            dt.Columns.Add(CT_SalesConf_TaxRate1_SalesTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_SalesTotalAll].DefaultValue = defValueInt64;

            // 売上原価(税抜き)_税率1
            dt.Columns.Add(CT_SalesConf_TaxRate1_SalesCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_SalesCostDtl].DefaultValue = defValueInt64;

            // 返品Title_税率1
            dt.Columns.Add(CT_SalesConf_TaxRate1_ReturnTitle, typeof(String));
            dt.Columns[CT_SalesConf_TaxRate1_ReturnTitle].DefaultValue = defValueString;

            // 返品数_税率1
            dt.Columns.Add(CT_SalesConf_TaxRate1_ReturnSalesCountDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_ReturnSalesCountDtl].DefaultValue = defValueInt64;

            // 返品金額_税率1
            dt.Columns.Add(CT_SalesConf_TaxRate1_ReturnDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_ReturnDtl].DefaultValue = defValueInt64;

            // 返品消費税_税率1
            dt.Columns.Add(CT_SalesConf_TaxRate1_ReturnDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_ReturnDtlTax].DefaultValue = defValueInt64;

            // 返品の消費税込合計金額_税率1
            dt.Columns.Add(CT_SalesConf_TaxRate1_ReturnTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_ReturnTotalAll].DefaultValue = defValueInt64;

            // 返品原価(税抜き)_税率1
            dt.Columns.Add(CT_SalesConf_TaxRate1_ReturnCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate1_ReturnCostDtl].DefaultValue = defValueInt64;
            #endregion

            #region 「消費税税率税率２」
            // Title_税率2
            dt.Columns.Add(CT_SalesConf_TaxRate2_Title, typeof(String));
            dt.Columns[CT_SalesConf_TaxRate2_Title].DefaultValue = defValueString;

            // 売上数_税率２
            dt.Columns.Add(CT_SalesConf_TaxRate2_SalesCountnumberDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_SalesCountnumberDtl].DefaultValue = defValueInt64;

            // 売上金額_税率２
            dt.Columns.Add(CT_SalesConf_TaxRate2_SalesDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_SalesDtl].DefaultValue = defValueInt64;

            // 売上消費税_税率２
            dt.Columns.Add(CT_SalesConf_TaxRate2_SalesDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_SalesDtlTax].DefaultValue = defValueInt64;

            // 売上の消費税込合計金額_税率２
            dt.Columns.Add(CT_SalesConf_TaxRate2_SalesTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_SalesTotalAll].DefaultValue = defValueInt64;

            // 売上原価(税抜き)_税率２
            dt.Columns.Add(CT_SalesConf_TaxRate2_SalesCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_SalesCostDtl].DefaultValue = defValueInt64;

            // 返品Title_税率2
            dt.Columns.Add(CT_SalesConf_TaxRate2_ReturnTitle, typeof(String));
            dt.Columns[CT_SalesConf_TaxRate2_ReturnTitle].DefaultValue = defValueString;

            // 返品数_税率２
            dt.Columns.Add(CT_SalesConf_TaxRate2_ReturnSalesCountDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_ReturnSalesCountDtl].DefaultValue = defValueInt64;

            // 返品金額_税率２
            dt.Columns.Add(CT_SalesConf_TaxRate2_ReturnDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_ReturnDtl].DefaultValue = defValueInt64;

            // 返品消費税_税率２
            dt.Columns.Add(CT_SalesConf_TaxRate2_ReturnDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_ReturnDtlTax].DefaultValue = defValueInt64;

            // 返品の消費税込合計金額_税率２
            dt.Columns.Add(CT_SalesConf_TaxRate2_ReturnTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_ReturnTotalAll].DefaultValue = defValueInt64;

            // 返品原価(税抜き)_税率２
            dt.Columns.Add(CT_SalesConf_TaxRate2_ReturnCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxRate2_ReturnCostDtl].DefaultValue = defValueInt64;
            #endregion

            #region 「消費税税率その他」
            // Title__その他
            dt.Columns.Add(CT_SalesConf_Other_Title, typeof(String));
            dt.Columns[CT_SalesConf_Other_Title].DefaultValue = defValueString;

            // 売上数_その他
            dt.Columns.Add(CT_SalesConf_Other_SalesCountnumberDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_SalesCountnumberDtl].DefaultValue = defValueInt64;

            // 売上金額_その他
            dt.Columns.Add(CT_SalesConf_Other_SalesDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_SalesDtl].DefaultValue = defValueInt64;

            // 売上消費税_その他
            dt.Columns.Add(CT_SalesConf_Other_SalesDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_SalesDtlTax].DefaultValue = defValueInt64;

            // 売上の消費税込合計金額_その他
            dt.Columns.Add(CT_SalesConf_Other_SalesTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_SalesTotalAll].DefaultValue = defValueInt64;

            // 売上原価(税抜き)_その他
            dt.Columns.Add(CT_SalesConf_Other_SalesCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_SalesCostDtl].DefaultValue = defValueInt64;

            // Title__その他
            dt.Columns.Add(CT_SalesConf_Other_ReturnTitle, typeof(String));
            dt.Columns[CT_SalesConf_Other_ReturnTitle].DefaultValue = defValueString;

            // 返品数_その他
            dt.Columns.Add(CT_SalesConf_Other_ReturnSalesCountDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_ReturnSalesCountDtl].DefaultValue = defValueInt64;

            // 返品金額_その他
            dt.Columns.Add(CT_SalesConf_Other_ReturnDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_ReturnDtl].DefaultValue = defValueInt64;

            // 返品消費税_その他
            dt.Columns.Add(CT_SalesConf_Other_ReturnDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_ReturnDtlTax].DefaultValue = defValueInt64;

            // 返品の消費税込合計金額_その他
            dt.Columns.Add(CT_SalesConf_Other_ReturnTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_ReturnTotalAll].DefaultValue = defValueInt64;

            // 返品原価(税抜き)_その他
            dt.Columns.Add(CT_SalesConf_Other_ReturnCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_Other_ReturnCostDtl].DefaultValue = defValueInt64;
            #endregion
            // --- ADD END 3H 尹安 2020/02/27 -----<<<<<       

            // ----- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
            #region 「消費税税率非課税」
            // Title__非課税
            dt.Columns.Add(CT_SalesConf_TaxFree_Title, typeof(String));
            dt.Columns[CT_SalesConf_TaxFree_Title].DefaultValue = defValueString;

            // 売上数_非課税
            dt.Columns.Add(CT_SalesConf_TaxFree_SalesCountnumberDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_SalesCountnumberDtl].DefaultValue = defValueInt64;

            // 売上金額_非課税
            dt.Columns.Add(CT_SalesConf_TaxFree_SalesDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_SalesDtl].DefaultValue = defValueInt64;

            // 売上消費税_非課税
            dt.Columns.Add(CT_SalesConf_TaxFree_SalesDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_SalesDtlTax].DefaultValue = defValueInt64;

            // 売上の消費税込合計金額_非課税
            dt.Columns.Add(CT_SalesConf_TaxFree_SalesTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_SalesTotalAll].DefaultValue = defValueInt64;

            // 売上原価(税抜き)_非課税
            dt.Columns.Add(CT_SalesConf_TaxFree_SalesCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_SalesCostDtl].DefaultValue = defValueInt64;

            // Title__非課税
            dt.Columns.Add(CT_SalesConf_TaxFree_ReturnTitle, typeof(String));
            dt.Columns[CT_SalesConf_TaxFree_ReturnTitle].DefaultValue = defValueString;

            // 返品数_非課税
            dt.Columns.Add(CT_SalesConf_TaxFree_ReturnSalesCountDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_ReturnSalesCountDtl].DefaultValue = defValueInt64;

            // 返品金額_非課税
            dt.Columns.Add(CT_SalesConf_TaxFree_ReturnDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_ReturnDtl].DefaultValue = defValueInt64;

            // 返品消費税_非課税
            dt.Columns.Add(CT_SalesConf_TaxFree_ReturnDtlTax, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_ReturnDtlTax].DefaultValue = defValueInt64;

            // 返品の消費税込合計金額_非課税
            dt.Columns.Add(CT_SalesConf_TaxFree_ReturnTotalAll, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_ReturnTotalAll].DefaultValue = defValueInt64;

            // 返品原価(税抜き)_非課税
            dt.Columns.Add(CT_SalesConf_TaxFree_ReturnCostDtl, typeof(Int64));
            dt.Columns[CT_SalesConf_TaxFree_ReturnCostDtl].DefaultValue = defValueInt64;
            #endregion
            // ----- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<

            // 伝票タイプの印字用日付
            // 売上日付
            dt.Columns.Add(CT_Col_SalesDateY2, typeof(string));
            dt.Columns[CT_Col_SalesDateY2].DefaultValue = defValueString;

            // 計上日付
            dt.Columns.Add(CT_Col_AddUpADateY2, typeof(string));
            dt.Columns[CT_Col_AddUpADateY2].DefaultValue = defValueString;

            // 伝票検索日付(入力日付)
            dt.Columns.Add(CT_Col_SearchSlipDateY2, typeof(string));
            dt.Columns[CT_Col_SearchSlipDateY2].DefaultValue = defValueString;

            // --- ADD 2008/10/31 --------------------------------------------------------->>>>>
            // 消費税転嫁方式[伝票]
            dt.Columns.Add(CT_Col_ConsTaxLayMethod, typeof(Int32));
            dt.Columns[CT_Col_ConsTaxLayMethod].DefaultValue = defValueInt32;
            // 課税区分[明細]
            dt.Columns.Add(CT_Col_TaxationDivCd, typeof(Int32));
            dt.Columns[CT_Col_TaxationDivCd].DefaultValue = defValueInt32;
            // 合計金額(金額＋消費税)
            dt.Columns.Add(CT_Col_SalesTotalTaxExcPlusTax, typeof(Double));
            dt.Columns[CT_Col_SalesTotalTaxExcPlusTax].DefaultValue = defValueDouble;
            // --- ADD 2008/10/31 ---------------------------------------------------------<<<<<

            // 2010/06/29 Add >>>
            // 車種半角名称
            dt.Columns.Add(CT_Col_ModelHalfName, typeof(string));
            dt.Columns[CT_Col_ModelHalfName].DefaultValue = defValueString;
            // 2010/06/29 Add <<<

            // --- ADD  大矢睦美  2010/07/14 ---------->>>>>
            //商品名称カナ
            dt.Columns.Add(CT_Col_GoodsNameKana, typeof(string));
            dt.Columns[CT_Col_GoodsNameKana].DefaultValue = defValueString;
            // --- ADD  大矢睦美  2010/07/14 ----------<<<<<

            // キーブレイク
			dt.Columns.Add(COL_KEYBREAK_AR, typeof(string));
			dt.Columns[COL_KEYBREAK_AR].DefaultValue = "";
		    
            // --- ADD  陳建明  2010/11/29 ---------->>>>>
            dt.Columns.Add(CT_COL_LOGICALDELETECODE, typeof(string));
            dt.Columns[CT_COL_LOGICALDELETECODE].DefaultValue = "";
            // --- ADD  陳建明  2010/11/29 ----------<<<<<
		}

		#endregion
	}
}