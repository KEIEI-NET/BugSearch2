using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   DCHNB02014EA
	/// <summary>
	/// 受注出荷確認表抽出結果データテーブルスキーマクラス
	/// </summary>
	/// <remarks>
	/// <br>受注出荷確認表の抽出結果テーブルスキーマです。</br>
    /// <br>UpdateNote : 2008/10/31 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>UpdateNote : 2009/01/30 上野 俊治　受注数、受注残数追加</br>
    /// </remarks>
	public class DCHNB02014EA
	{
		#region Public Members
		
		/// <summary>受注出荷確認表データテーブル名</summary>
		public const string CT_OrderConfDataTable = "SalesConfDataTable";
		/// <summary>受注出荷確認表バッファデータテーブル名</summary>
		public const string CT_OrderConfBuffDataTable = "SalesConfBuffDataTable";

		#region 受注出荷確認表（伝票形式）カラム情報

		/// <summary>拠点コード[共通]</summary>
		public const string CT_OrderConf_SectionCode = "SectionCode";

		/// <summary>拠点ガイド名称（拠点名称）[共通]</summary>
		/// <remarks>拠点情報設定マスタより取得</remarks>
		public const string CT_OrderConf_SectionGuideNm = "SectionGuideNm";
		
		/// <summary>得意先コード[共通]</summary>
		public const string CT_OrderConf_CustomerCodeRF = "CustomerCode";

		/// <summary>得意先略称[共通]</summary>
		public const string CT_OrderConf_CustomerSnmRF = "CustomerSnm";

		/// <summary>売上入力者コード[共通]</summary>
		public const string CT_OrderConf_SalesInputCodeRF = "SalesInputCode";

		/// <summary>売上入力者名称[共通]</summary>
		public const string CT_OrderConf_SalesInputNameRF = "SalesInputName";

		/// <summary>販売従業員（担当者）コード[共通]</summary>
		public const string CT_OrderConf_SalesEmployeeCdRF = "SalesEmployeeCd";

		/// <summary>販売従業員（担当者）名称[共通]</summary>
		public const string CT_OrderConf_SalesEmployeeNmRF = "SalesEmployeeNm";

		/// <summary>受注ステータス[共通]</summary>
		/// <remarks>20:受注 40:出荷</remarks>
		public const string CT_OrderConf_AcptAnOdrStatusRF = "AcptAnOdrStatus";

		/// <summary>売上伝票番号[伝票]</summary>
		public const string CT_OrderConf_SalesSlipNumRF = "SalesSlipNum";

		/// <summary>売上伝票区分[伝票]</summary>
		/// <remarks>0:売上,1:返品</remarks>
		public const string CT_OrderConf_SalesSlipCdRF = "SalesSlipCd";

		/// <summary>売掛区分[共通]</summary>
		/// <remarks>0:売掛なし,1:売掛</remarks>
		public const string CT_OrderConf_AccRecDivCd = "AccRecDivCd";

		/// <summary>取引区分名[伝票]</summary>
		/// <remarks>リモート部で算出(売上伝票区分・売掛区分を使用)</remarks>
		public const string CT_OrderConf_TransactionNameRF = "TransactionName";

		/// <summary>伝票検索日付(入力日付)[共通]</summary>
		/// <remarks>YYYYMMDD</remarks>
		public const string CT_OrderConf_SearchSlipDateRF = "SearchSlipDate";

		/// <summary>出荷日付[共通]</summary>
		/// <remarks>YYYYMMDD</remarks>
		public const string CT_OrderConf_ShipmentDayRF = "ShipmentDay";

		/// <summary>売上（受注）日付[共通]</summary>
		public const string CT_OrderConf_SalesDateRF = "SalesDate";

		/// <summary>計上日付(請求日)[共通]</summary>
		/// <remarks>YYYYMMDD</remarks>
		public const string CT_OrderConf_AddUpADateRF = "AddUpADate";

		/// <summary>相手先伝票番号[共通]</summary>
		public const string CT_OrderConf_PartySaleSlipNumRF = "PartySaleSlipNum";

        // 2008.07.25 30413 犬飼 [共通]の項目追加 >>>>>>START
        /// <summary> 受付従業員コード[共通] </summary>
        public const string CT_OrderConf_FrontEmployeeCd = "FrontEmployeeCd";
        /// <summary> 受付従業員名称[共通] </summary>
        public const string CT_OrderConf_FrontEmployeeNm = "FrontEmployeeNm";
        // 2008.07.25 30413 犬飼 [共通]の項目追加 <<<<<<END
        // --- ADD 2009/01/30 -------------------------------->>>>>
        /// <summary> 受注残数 </summary>
        public const string CT_OrderConf_AcptAnOdrRemainCnt = "AcptAnOdrRemainCnt";
        /// <summary> 受注数量 </summary>
        public const string CT_OrderConf_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> 受注調整数 </summary>
        public const string CT_OrderConf_AcptAnOdrAdjustCnt = "AcptAnOdrAdjustCnt";
        /// <summary> 受注数 </summary>
        public const string CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt = "AcceptAnOrderCntPlusAdjustCnt";
        // --- ADD 2009/01/30 --------------------------------<<<<<

        /// <summary>売上（受注）伝票合計(税抜)[伝票]</summary>
		/// <remarks>(値引も含む)</remarks>
		public const string CT_OrderConf_SalesTotalTaxExcRF = "SalesTotalTaxExc";

		/// <summary>売上（受注）伝票合計(税込)[伝票]</summary>
		/// <remarks>(値引も含む)</remarks>
		public const string CT_OrderConf_SalesTotalTaxIncRF = "SalesTotalTaxInc";

		/// <summary>売上（受注）値引金額計(税抜)[伝票]</summary>
		public const string CT_OrderConf_SalesDisTtlTaxExcRF = "SalesDisTtlTaxExc";

		/// <summary>売上（受注）値引金額計(税込)[伝票]</summary>
		public const string CT_OrderConf_SalesDisTtlTaxIncluRF = "SalesDisTtlTaxInclu";

		/// <summary>原価金額計[伝票]</summary>
		public const string CT_OrderConf_TotalCostRF = "TotalCost";

		/// <summary>粗利率[伝票]</summary>
		/// <remarks>リモート部で算出</remarks>
		public const string CT_OrderConf_GrossMarginRate = "GrossMarginRate";

		/// <summary>粗利チェックマーク[伝票]</summary>
		/// <remarks>リモート部で算出</remarks>
		public const string CT_OrderConf_GrossMarginMarkSlip = "GrossMarginMarkSlip";

        // 2008.07.25 30413 犬飼 [伝票]の項目追加 >>>>>>START
        /// <summary> 伝票備考[伝票] </summary>
        public const string CT_OrderConf_SlipNote = "SlipNote";
        // 2008.07.25 30413 犬飼 [伝票]の項目追加 <<<<<<END
        

		/// <summary>売上行番号[明細]</summary>
		public const string CT_OrderConf_SalesRowNoRF = "SalesRowNo";

		/// <summary>売上伝票区分[明細]</summary>
		/// <remarks>0:売上,1:返品,2:値引,9:一式</remarks>
		public const string CT_OrderConf_SalesSlipCdDtlRF = "SalesSlipCdDtl";

		/// <summary>売上伝票区分名[明細]</summary>
		/// <remarks>0:売上,1:返品,2:値引,9:一式</remarks>
		public const string CT_OrderConf_SalesSlipNmDtl = "SalesSlipNmDtl";

		///// <summary>商品メーカーコード[明細]</summary>
		//public const string CT_OrderConf_GoodsMakerCdRF = "GoodsMakerCd";

		/// <summary>メーカー名称[明細]</summary>
		public const string CT_OrderConf_MakerNameRF = "MakerName";

		/// <summary>商品番号[明細]</summary>
		public const string CT_OrderConf_GoodsNoRF = "GoodsNo";

		/// <summary>商品名称[明細]</summary>
		public const string CT_OrderConf_GoodsNameRF = "GoodsName";

		///// <summary>単位コード[明細]</summary>
		//public const string CT_OrderConf_UnitCodeRF = "UnitCode";

		/// <summary>単位名称[明細]</summary>
		public const string CT_OrderConf_UnitNameRF = "UnitName";

		/// <summary>出荷数（数量）[明細]</summary>
		public const string CT_OrderConf_ShipmentCntRF = "ShipmentCnt";

		///// <summary>売上単価(税込)[明細]</summary>
		//public const string CT_OrderConf_SalesUnPrcTaxIncFlRF = "SalesUnPrcTaxIncFl";

		/// <summary>売上単価(税抜)[明細]</summary>
		public const string CT_OrderConf_SalesUnPrcTaxExcFlRF = "SalesUnPrcTaxExcFl";

		///// <summary>売上金額(税込)[明細]</summary>
		//public const string CT_OrderConf_SalesMoneyTaxIncRF = "SalesMoneyTaxInc";

		/// <summary>売上金額(税抜)[明細]</summary>
		public const string CT_OrderConf_SalesMoneyTaxExcRF = "SalesMoneyTaxExc";

		/// <summary>原価単価[明細]</summary>
		public const string CT_OrderConf_SalesUnitCostRF = "SalesUnitCost";

		/// <summary>原価金額[明細]</summary>
		public const string CT_OrderConf_CostRF = "Cost";

		/// <summary>粗利率[明細]</summary>
		/// <remarks>リモート部で算出</remarks>
		public const string CT_OrderConf_GrossMarginRateDtl = "GrossMarginRateDtl";

		/// <summary>粗利チェックマーク[明細]</summary>
		/// <remarks>リモート部で算出</remarks>
		public const string CT_OrderConf_GrossMarginMarkDtl = "GrossMarginMarkDtl";

		///// <summary>相手先伝票番号（得意先注文番号）[明細]</summary>
		//public const string CT_OrderConf_PartySlipNumDtlRF = "PpartySlipNumDtl";

        // 2008.07.25 30413 犬飼 [明細]の項目追加 >>>>>>START
        /// <summary> 仕入先コード[明細] </summary>
        public const string CT_OrderConf_SupplierCd = "SupplierCd";
        /// <summary> 仕入先略称[明細] </summary>
        public const string CT_OrderConf_SupplierSnm = "SupplierSnm";
        /// <summary> 仕入伝票番号[明細] </summary>
        public const string CT_OrderConf_SupplierSlipNo = "SupplierSlipNo";
        /// <summary> 倉庫コード[明細]  </summary>
        public const string CT_OrderConf_WarehouseCode = "WarehouseCode";
        /// <summary> 倉庫名称[明細] </summary>
        public const string CT_OrderConf_WarehouseName = "WarehouseName";
        /// <summary> 業種コード[明細] </summary>
        public const string CT_OrderConf_BusinessTypeCode = "BusinessTypeCode";
        /// <summary> 業種名称[明細] </summary>
        public const string CT_OrderConf_BusinessTypeName = "BusinessTypeName";
        /// <summary> 販売区分コード[明細] </summary>
        public const string CT_OrderConf_SalesCode = "SalesCode";
        /// <summary> 販売区分名称[明細] </summary>
        public const string CT_OrderConf_SalesCdNm = "SalesCdNm";
        /// <summary> 車種全角名称[明細] </summary>
        public const string CT_OrderConf_ModelFullName = "ModelFullName";
        /// <summary> 型式（フル型）[明細] </summary>
        public const string CT_OrderConf_FullModel = "FullModel";
        /// <summary> 型式指定番号[明細] </summary>
        public const string CT_OrderConf_ModelDesignationNo = "ModelDesignationNo";
        /// <summary> 類別番号[明細] </summary>
        public const string CT_OrderConf_CategoryNo = "CategoryNo";
        /// <summary> 車輌管理コード[明細] </summary>
        public const string CT_OrderConf_CarMngCode = "CarMngCode";
        /// <summary> 初年度[明細] </summary>
        public const string CT_OrderConf_FirstEntryDate = "FirstEntryDate";
        /// <summary> 伝票備考２[明細] </summary>
        public const string CT_OrderConf_SlipNote2 = "SlipNote2";
        /// <summary> 伝票備考３[明細] </summary>
        public const string CT_OrderConf_SlipNote3 = "SlipNote3";
        /// <summary> BL商品コード[明細] </summary>
        public const string CT_OrderConf_BLGoodsCode = "BLGoodsCode";
        /// <summary> BL商品コード名称（全角）[明細] </summary>
        public const string CT_OrderConf_BLGoodsFullName = "BLGoodsFullName";
        /// <summary> 売上在庫取寄せ区分 </summary>
        public const string CT_OrderConf_SalesOrderDivCd = "SalesOrderDivCd";
        // 2008.07.25 30413 犬飼 [明細]の項目追加 <<<<<<END

        // ↓↓テーブル定義書以外の追加項目
        /// <summary> 売上伝票区分名称 </summary>
        public const string CT_OrderConf_SalesSlipName = "SalesSlipName";

        /// <summary> 類別(明細) </summary>
        public const string CT_OrderConf_CategoryDtl = "CategoryDtl";

        /// <summary> 売上在庫取寄せ区分名称 </summary>
        public const string CT_OrderConf_SalesOrderDivName = "SalesOrderDivName";

        /// <summary> 消費税 </summary>
        public const string CT_OrderConf_Tax = "Tax";

        /// <summary> 粗利(税抜き)(伝票) </summary>
        public const string CT_OrderConf_GrossProfit = "GrossProfit";

        /// <summary> 粗利(税抜き)(明細) </summary>
        public const string CT_OrderConf_GrossProfitDtl = "GrossProfitDtl";





		/// <summary>粗利チェック下限</summary>
		public const string CT_OrderConf_GrsProfitCheckLower = "GrsProfitCheckLower";

		/// <summary>粗利チェック適正</summary>
		public const string CT_OrderConf_GrsProfitCheckBest = "GrsProfitCheckBest";

		/// <summary>粗利チェック上限</summary>
		public const string CT_OrderConf_GrsProfitCheckUpper = "GrsProfitCheckUpper";

		/// <summary>消費税[伝票] </summary>
		public const string CT_OrderConf_ConsTaxSlip = "ConsTaxSlip";

		/// <summary>消費税[明細] </summary>
		public const string CT_OrderConf_ConsTaxDtl = "ConsTaxDtl";

		/// <summary>消費税（売上）[伝票] </summary>
		public const string CT_OrderConf_ConsTaxSlSlip = "ConsTaxSlSlip";

		/// <summary>消費税（売上）[明細] </summary>
		public const string CT_OrderConf_ConsTaxSlDtl = "ConsTaxSlDtl";

		/// <summary>消費税（返品）[伝票] </summary>
		public const string CT_OrderConf_ConsTaxRtnSlip = "ConsTaxRtnSlip";

		/// <summary>消費税（返品）[明細] </summary>
		public const string CT_OrderConf_ConsTaxRtnDtl = "ConsTaxRtnDtl";

		/// <summary>消費税（値引き）[伝票] </summary>
		public const string CT_OrderConf_ConsTaxDisSlip = "ConsTaxDisSlip";

		/// <summary>消費税（値引き）[明細] </summary>
		public const string CT_OrderConf_ConsTaxDisDtl = "ConsTaxDisDtl";


        // 2009.01.27 30413 犬飼 消費税と合計金額の追加 >>>>>>START
        // ↓↓小計部[伝票]の定義
        /// <summary>売上数[伝票] </summary>
        public const string CT_OrderConf_CntSales = "CntSales";
        
        /// <summary>売上額[伝票] </summary>
		public const string CT_OrderConf_SalesMoney = "SalesMoney";

        /// <summary>原価金額計（売上）[伝票]</summary>
        public const string CT_OrderConf_TotalCostSl = "TotalCostSl";

        /// <summary>売上合計粗利(税抜き)(伝票)</summary>
        public const string CT_OrderConf_SalesGrossProfit = "SalesGrossProfit";

        /// <summary>売上合計消費税(伝票)</summary>
        public const string CT_OrderConf_SalesTax = "SalesTax";

        /// <summary>売上の消費税込合計金額(伝票)</summary>
        public const string CT_OrderConf_SalesTotalAll = "SalesTotalAll";

        /// <summary>返品数[伝票] </summary>
        public const string CT_OrderConf_CntReturn = "CntReturn";

		/// <summary>返品額[伝票] </summary>
		public const string CT_OrderConf_ReturnSalesMoney = "ReturnSalesMoney";
        
        /// <summary>原価金額計（返品）[伝票]</summary>
        public const string CT_OrderConf_TotalCostRtn = "TotalCostRtn";

        /// <summary>返品合計粗利(税抜き)(伝票)</summary>
        public const string CT_OrderConf_ReturnGrossProfit = "ReturnGrossProfit";

        /// <summary>返品合計消費税(伝票)</summary>
        public const string CT_OrderConf_ReturnTax = "ReturnTax";

        /// <summary>返品の消費税込合計金額(伝票)</summary>
        public const string CT_OrderConf_ReturnTotalAll = "ReturnTotalAll";

        /// <summary>値引き合計原価(税抜き)(伝票)</summary>
        public const string CT_OrderConf_DistCost = "DistCost";

        /// <summary>値引き合計粗利(税抜き)(伝票)</summary>
        public const string CT_OrderConf_DistGrossProfit = "DistGrossProfit";

        /// <summary>値引き合計消費税(伝票)</summary>
        public const string CT_OrderConf_DistTax = "DistTax";

        /// <summary>値引きの消費税込合計金額(伝票)</summary>
        public const string CT_OrderConf_DistTotalAll = "DistTotalAll";


        // ↓↓小計部[明細]の追加項目
        /// <summary>売上数[明細] </summary>
        public const string CT_OrderConf_CntSalesDtl = "CntSalesDtl";

        /// <summary>『売上』額[明細] </summary>
        public const string CT_OrderConf_SalesMoneyDtl = "SalesMoneyDtl";

        /// <summary>原価金額計（売上）[明細]</summary>
        public const string CT_OrderConf_TotalCostDtl = "TotalCostDtl";

        /// <summary>売上合計粗利(税抜き)(明細)</summary>
        public const string CT_OrderConf_SalesGrossProfitDtl = "SalesGrossProfitDtl";

        /// <summary>売上合計消費税(明細)</summary>
        public const string CT_OrderConf_SalesDtlTax = "SalesDtlTax";

        /// <summary>返品数[明細] </summary>
        public const string CT_OrderConf_CntReturnDtl = "CntReturnDtl";

        /// <summary>返品額[明細] </summary>
        public const string CT_OrderConf_SalesMoneyRtnDtl = "SalesMoneyRtnDtl";

        /// <summary>原価金額（返品）[明細]</summary>
        public const string CT_OrderConf_TotalCostRtnDtl = "TotalCostRtnDtl";

        /// <summary>返品合計粗利(税抜き)(明細)</summary>
        public const string CT_OrderConf_ReturnGrossProfitDtl = "ReturnGrossProfitDtl";

        /// <summary>返品合計消費税(明細)</summary>
        public const string CT_OrderConf_ReturnDtlTax = "ReturnDtlTax";

        /// <summary>『値引』金額[明細]</summary>
        public const string CT_OrderConf_SalesDisTtlTaxExcDtl = "SalesDisTtlTaxExcDtl";

        /// <summary>値引き合計原価金額(税抜き)(明細)</summary>
        public const string CT_OrderConf_DistDtlCost = "DistDtlCost";

        /// <summary>値引き合計粗利(税抜き)(明細)</summary>
        public const string CT_OrderConf_DistGrossProfitDtl = "DistGrossProfitDtl";

        /// <summary>値引き合計消費税(明細)</summary>
        public const string CT_OrderConf_DistDtlTax = "DistDtlTax";
        // 2009.01.27 30413 犬飼 消費税と合計金額の追加 <<<<<<END
        


		/// <summary>純売上（原価金額）[伝票]</summary>
		public const string CT_OrderConf_PureTotalCost = "PureTotalCost";
		
		/// <summary>純売上（原価金額）[明細]</summary>
		public const string CT_OrderConf_PureTotalCostDtl = "PureTotalCostDtl";

		///// <summary>『値引』原価金額[明細]</summary>
		//public const string CT_OrderConf_TotalDisCostRtnDtl = "TotalDisCostRtnDtl";

        // --- ADD 2008/10/31 ------------------------------------------------------------>>>>>
        /// <summary>消費税転嫁方式[伝票]</summary>
        public const string CT_OrderConf_ConsTaxLayMethod = "ConsTaxLayMethod";
        /// <summary>課税区分[明細]</summary>
        public const string CT_OrderConf_TaxationDivCd = "TaxationDivCd";
        /// <summary>合計金額(金額＋消費税)</summary>
        public const string CT_OrderConf_SalesTotalTaxExcPlusTax = "SalesTotalTaxExcPlusTax";
        // --- ADD 2008/10/31 ------------------------------------------------------------<<<<<

        // 2008.11.27 30413 犬飼 印刷項目の追加 >>>>>>START
        /// <summary> 定価（税抜，浮動） </summary>
        public const string CT_OrderConf_ListPriceTaxExcFl = "ListPriceTaxExcFl";
        // 2008.11.27 30413 犬飼 印刷項目の追加 <<<<<<END
        
		public const string COL_KEYBREAK_AR = "KEYBREAK_AR";				// キーブレイク

		#endregion

		#endregion

		#region Constructor
		/// <summary>
		/// 受注出荷確認表抽出結果データテーブルスキーマクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br> 受注出荷確認表抽出結果データテーブルスキーマクラスの初期化及びインスタンス生成を行います。</br>
		/// </remarks>
		public DCHNB02014EA()
		{
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// データセット、データテーブル設定処理
		/// </summary>
		public static void SettingDataSet(ref DataSet ds)
		{
			// テーブルが存在するかどうかをチェック
			if ((ds.Tables.Contains(CT_OrderConfDataTable)))
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
				ds.Tables[CT_OrderConfDataTable].Clear();
			}
			else
			{
				CreateSaleConfTable(ref ds, 0);

			}

			// 売上チェックリストバッファデータテーブル------------------------------------------
			// テーブルが存在するかどうかをチェック
			if ((ds.Tables.Contains(CT_OrderConfBuffDataTable)))
			{
				// TODO:テーブルが存在するときはクリアーするのみ
				// スキーマをもう一度設定するようなことはしない。
				ds.Tables[CT_OrderConfBuffDataTable].Clear();
			}
			else
			{
				CreateSaleConfTable(ref ds, 1);
			}
		}

		#endregion

		#region Private Methods
		
		/// <summary>
		/// 受注出荷確認表(伝票形式)抽出結果作成処理
		/// </summary>
		/// <remarks>
        private static void CreateSaleConfTable(ref DataSet ds, int buffCheck)
        {
            DataTable dt = null;
            if (buffCheck == 0)
            {
                // スキーマ設定
                ds.Tables.Add(CT_OrderConfDataTable);
                dt = ds.Tables[CT_OrderConfDataTable];
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(CT_OrderConfBuffDataTable);
                dt = ds.Tables[CT_OrderConfBuffDataTable];
            }

            // 拠点コード
            dt.Columns.Add(CT_OrderConf_SectionCode, typeof(string));
            dt.Columns[CT_OrderConf_SectionCode].DefaultValue = "";
            // 拠点ガイド名称（拠点名称）
            dt.Columns.Add(CT_OrderConf_SectionGuideNm, typeof(string));
            dt.Columns[CT_OrderConf_SectionGuideNm].DefaultValue = "";
            // 得意先コード
            dt.Columns.Add(CT_OrderConf_CustomerCodeRF, typeof(Int32));
            dt.Columns[CT_OrderConf_CustomerCodeRF].DefaultValue = 0;
            // 得意先名称
            dt.Columns.Add(CT_OrderConf_CustomerSnmRF, typeof(string));
            dt.Columns[CT_OrderConf_CustomerSnmRF].DefaultValue = "";
            //売上入力者コード[共通]
            dt.Columns.Add(CT_OrderConf_SalesInputCodeRF, typeof(string));
            dt.Columns[CT_OrderConf_SalesInputCodeRF].DefaultValue = "";
            //売上入力者名称[共通]
            dt.Columns.Add(CT_OrderConf_SalesInputNameRF, typeof(string));
            dt.Columns[CT_OrderConf_SalesInputNameRF].DefaultValue = "";
            //販売従業員（担当者）コード[共通]
            dt.Columns.Add(CT_OrderConf_SalesEmployeeCdRF, typeof(string));
            dt.Columns[CT_OrderConf_SalesEmployeeCdRF].DefaultValue = "";
            //販売従業員（担当者）名称[共通]
            dt.Columns.Add(CT_OrderConf_SalesEmployeeNmRF, typeof(string));
            dt.Columns[CT_OrderConf_SalesEmployeeNmRF].DefaultValue = "";
            //受注ステータス[共通]
            dt.Columns.Add(CT_OrderConf_AcptAnOdrStatusRF, typeof(Int32));
            dt.Columns[CT_OrderConf_AcptAnOdrStatusRF].DefaultValue = 0;
            //売上伝票番号[伝票]
            dt.Columns.Add(CT_OrderConf_SalesSlipNumRF, typeof(string));
            dt.Columns[CT_OrderConf_SalesSlipNumRF].DefaultValue = "";
            //売上伝票区分[伝票]	0:売上,1:返品
            dt.Columns.Add(CT_OrderConf_SalesSlipCdRF, typeof(Int32));
            dt.Columns[CT_OrderConf_SalesSlipCdRF].DefaultValue = 0;
            //売掛区分[共通]		0:売掛なし,1:売掛
            dt.Columns.Add(CT_OrderConf_AccRecDivCd, typeof(Int32));
            dt.Columns[CT_OrderConf_AccRecDivCd].DefaultValue = 0;
            //取引区分名[伝票]
            dt.Columns.Add(CT_OrderConf_TransactionNameRF, typeof(string));
            dt.Columns[CT_OrderConf_TransactionNameRF].DefaultValue = "";
            //伝票検索日付(入力日付)[共通]
            dt.Columns.Add(CT_OrderConf_SearchSlipDateRF, typeof(DateTime));
            dt.Columns[CT_OrderConf_SearchSlipDateRF].DefaultValue = null;
            // 出荷日付[共通]
            dt.Columns.Add(CT_OrderConf_ShipmentDayRF, typeof(DateTime));
            dt.Columns[CT_OrderConf_ShipmentDayRF].DefaultValue = null;
            // 売上（受注）日付[共通] 
            dt.Columns.Add(CT_OrderConf_SalesDateRF, typeof(DateTime));
            dt.Columns[CT_OrderConf_SalesDateRF].DefaultValue = null;
            //計上日付(請求日)[共通]
            dt.Columns.Add(CT_OrderConf_AddUpADateRF, typeof(DateTime));
            dt.Columns[CT_OrderConf_AddUpADateRF].DefaultValue = null;
            //相手先伝票番号[共通]
            dt.Columns.Add(CT_OrderConf_PartySaleSlipNumRF, typeof(string));
            dt.Columns[CT_OrderConf_PartySaleSlipNumRF].DefaultValue = "";

            // 2008.07.25 30413 犬飼 [共通]の項目追加 >>>>>>START
            // 受付従業員コード[共通]
            dt.Columns.Add(CT_OrderConf_FrontEmployeeCd, typeof(string));
            dt.Columns[CT_OrderConf_FrontEmployeeCd].DefaultValue = "";
            // 受付従業員名称[共通]
            dt.Columns.Add(CT_OrderConf_FrontEmployeeNm, typeof(string));
            dt.Columns[CT_OrderConf_FrontEmployeeNm].DefaultValue = "";
            // 2008.07.25 30413 犬飼 [共通]の項目追加 <<<<<<END


            //売上（受注）伝票合計(税抜)[伝票]
            dt.Columns.Add(CT_OrderConf_SalesTotalTaxIncRF, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesTotalTaxIncRF].DefaultValue = 0;
            //売上（受注）伝票合計(税込)[伝票]
            dt.Columns.Add(CT_OrderConf_SalesTotalTaxExcRF, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesTotalTaxExcRF].DefaultValue = 0;
            //売上（受注）値引金額計(税抜)[伝票]
            dt.Columns.Add(CT_OrderConf_SalesDisTtlTaxExcRF, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesDisTtlTaxExcRF].DefaultValue = 0;
            //売上（受注）値引金額計(税込)[伝票]
            dt.Columns.Add(CT_OrderConf_SalesDisTtlTaxIncluRF, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesDisTtlTaxIncluRF].DefaultValue = 0;
            //原価金額計[伝票]
            dt.Columns.Add(CT_OrderConf_TotalCostRF, typeof(Int64));
            dt.Columns[CT_OrderConf_TotalCostRF].DefaultValue = 0;
            //粗利率[伝票]
            dt.Columns.Add(CT_OrderConf_GrossMarginRate, typeof(Double));
            dt.Columns[CT_OrderConf_GrossMarginRate].DefaultValue = 0.0;
            //粗利チェックマーク[伝票]
            dt.Columns.Add(CT_OrderConf_GrossMarginMarkSlip, typeof(string));
            dt.Columns[CT_OrderConf_GrossMarginMarkSlip].DefaultValue = "";

            // 2008.07.25 30413 犬飼 [伝票]の項目追加 >>>>>>START
            // 伝票備考[伝票]
            dt.Columns.Add(CT_OrderConf_SlipNote, typeof(string));
            dt.Columns[CT_OrderConf_SlipNote].DefaultValue = "";
            // 2008.07.25 30413 犬飼 [伝票]の項目追加 <<<<<<END


            //売上行番号[明細]
            dt.Columns.Add(CT_OrderConf_SalesRowNoRF, typeof(Int32));
            dt.Columns[CT_OrderConf_SalesRowNoRF].DefaultValue = 0;
            //売上伝票区分[明細]
            dt.Columns.Add(CT_OrderConf_SalesSlipCdDtlRF, typeof(Int32));
            dt.Columns[CT_OrderConf_SalesSlipCdDtlRF].DefaultValue = 0;
            //売上伝票区分名[明細]
            dt.Columns.Add(CT_OrderConf_SalesSlipNmDtl, typeof(string));
            dt.Columns[CT_OrderConf_SalesSlipNmDtl].DefaultValue = "";
            ////商品メーカーコード[明細]
            //dt.Columns.Add(CT_OrderConf_GoodsMakerCdRF, typeof(Int32));
            //dt.Columns[CT_OrderConf_GoodsMakerCdRF].DefaultValue = 0;
            //メーカー名称[明細]
            dt.Columns.Add(CT_OrderConf_MakerNameRF, typeof(string));
            dt.Columns[CT_OrderConf_MakerNameRF].DefaultValue = "";
            // 商品番号[明細]
            dt.Columns.Add(CT_OrderConf_GoodsNoRF, typeof(string));
            dt.Columns[CT_OrderConf_GoodsNoRF].DefaultValue = "";
            // 商品名称[明細]
            dt.Columns.Add(CT_OrderConf_GoodsNameRF, typeof(string));
            dt.Columns[CT_OrderConf_GoodsNameRF].DefaultValue = "";
            //単位コード[明細]
            //dt.Columns.Add(CT_OrderConf_UnitCodeRF, typeof(Int32));
            //dt.Columns[CT_OrderConf_UnitCodeRF].DefaultValue = 0;
            //単位名称[明細]
            dt.Columns.Add(CT_OrderConf_UnitNameRF, typeof(string));
            dt.Columns[CT_OrderConf_UnitNameRF].DefaultValue = "";
            //出荷数（数量）[明細]
            dt.Columns.Add(CT_OrderConf_ShipmentCntRF, typeof(Double));
            dt.Columns[CT_OrderConf_ShipmentCntRF].DefaultValue = 0;
            ////売上単価(税込)[明細]
            //dt.Columns.Add(CT_OrderConf_SalesUnPrcTaxIncFlRF, typeof(Int64));
            //dt.Columns[CT_OrderConf_SalesUnPrcTaxIncFlRF].DefaultValue = 0;
            //売上単価(税抜)[明細]
            dt.Columns.Add(CT_OrderConf_SalesUnPrcTaxExcFlRF, typeof(Double));
            dt.Columns[CT_OrderConf_SalesUnPrcTaxExcFlRF].DefaultValue = 0;
            ////売上金額(税込)[明細]
            //dt.Columns.Add(CT_OrderConf_SalesMoneyTaxIncRF, typeof(Int64));
            //dt.Columns[CT_OrderConf_SalesMoneyTaxIncRF].DefaultValue = 0;
            //売上金額(税抜)[明細]
            dt.Columns.Add(CT_OrderConf_SalesMoneyTaxExcRF, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesMoneyTaxExcRF].DefaultValue = 0;
            //原価単価[明細]
            dt.Columns.Add(CT_OrderConf_SalesUnitCostRF, typeof(Double));
            dt.Columns[CT_OrderConf_SalesUnitCostRF].DefaultValue = 0;
            //原価金額[明細]
            dt.Columns.Add(CT_OrderConf_CostRF, typeof(Int64));
            dt.Columns[CT_OrderConf_CostRF].DefaultValue = 0;
            //粗利率[明細]
            dt.Columns.Add(CT_OrderConf_GrossMarginRateDtl, typeof(Double));
            dt.Columns[CT_OrderConf_GrossMarginRateDtl].DefaultValue = 0;
            //粗利チェックマーク[明細]
            dt.Columns.Add(CT_OrderConf_GrossMarginMarkDtl, typeof(string));
            dt.Columns[CT_OrderConf_GrossMarginMarkDtl].DefaultValue = "";
            ////相手先伝票番号[明細]
            //dt.Columns.Add(CT_OrderConf_PartySlipNumDtlRF, typeof(string));
            //dt.Columns[CT_OrderConf_PartySlipNumDtlRF].DefaultValue = "";

            // 2008.07.25 30413 犬飼 [明細]の項目追加 >>>>>>START
            // 仕入先コード[明細]
            dt.Columns.Add(CT_OrderConf_SupplierCd, typeof(string));
            dt.Columns[CT_OrderConf_SupplierCd].DefaultValue = "";
            // 仕入先略称[明細]
            dt.Columns.Add(CT_OrderConf_SupplierSnm, typeof(string));
            dt.Columns[CT_OrderConf_SupplierSnm].DefaultValue = "";
            // 仕入伝票番号[明細]
            dt.Columns.Add(CT_OrderConf_SupplierSlipNo, typeof(string));
            dt.Columns[CT_OrderConf_SupplierSlipNo].DefaultValue = "";
            // 倉庫コード[明細]
            dt.Columns.Add(CT_OrderConf_WarehouseCode, typeof(string));
            dt.Columns[CT_OrderConf_WarehouseCode].DefaultValue = "";
            // 倉庫名称[明細]
            dt.Columns.Add(CT_OrderConf_WarehouseName, typeof(string));
            dt.Columns[CT_OrderConf_WarehouseName].DefaultValue = "";
            // 業種コード[明細]
            dt.Columns.Add(CT_OrderConf_BusinessTypeCode, typeof(Int32));
            dt.Columns[CT_OrderConf_BusinessTypeCode].DefaultValue = 0;
            // 業種名称[明細]
            dt.Columns.Add(CT_OrderConf_BusinessTypeName, typeof(string));
            dt.Columns[CT_OrderConf_BusinessTypeName].DefaultValue = "";
            // 販売区分コード[明細]
            dt.Columns.Add(CT_OrderConf_SalesCode, typeof(string));
            dt.Columns[CT_OrderConf_SalesCode].DefaultValue = "";
            // 販売区分名称[明細]
            dt.Columns.Add(CT_OrderConf_SalesCdNm, typeof(string));
            dt.Columns[CT_OrderConf_SalesCdNm].DefaultValue = "";
            // 車種全角名称[明細]
            dt.Columns.Add(CT_OrderConf_ModelFullName, typeof(string));
            dt.Columns[CT_OrderConf_ModelFullName].DefaultValue = "";
            // 型式（フル型）[明細]
            dt.Columns.Add(CT_OrderConf_FullModel, typeof(string));
            dt.Columns[CT_OrderConf_FullModel].DefaultValue = "";
            // 型式指定番号[明細]
            dt.Columns.Add(CT_OrderConf_ModelDesignationNo, typeof(Int32));
            dt.Columns[CT_OrderConf_ModelDesignationNo].DefaultValue = 0;
            // 類別番号[明細]
            dt.Columns.Add(CT_OrderConf_CategoryNo, typeof(Int32));
            dt.Columns[CT_OrderConf_CategoryNo].DefaultValue = 0;
            // 車輌管理コード[明細]
            dt.Columns.Add(CT_OrderConf_CarMngCode, typeof(string));
            dt.Columns[CT_OrderConf_CarMngCode].DefaultValue = "";
            // 初年度[明細]
            dt.Columns.Add(CT_OrderConf_FirstEntryDate, typeof(string));
            dt.Columns[CT_OrderConf_FirstEntryDate].DefaultValue = "";
            // 伝票備考２[明細]
            dt.Columns.Add(CT_OrderConf_SlipNote2, typeof(string));
            dt.Columns[CT_OrderConf_SlipNote2].DefaultValue = "";
            // 伝票備考３[明細]
            dt.Columns.Add(CT_OrderConf_SlipNote3, typeof(string));
            dt.Columns[CT_OrderConf_SlipNote3].DefaultValue = "";
            // BL商品コード[明細]
            dt.Columns.Add(CT_OrderConf_BLGoodsCode, typeof(string));
            dt.Columns[CT_OrderConf_BLGoodsCode].DefaultValue = "";
            // 売上在庫取寄せ区分
            dt.Columns.Add(CT_OrderConf_SalesOrderDivCd, typeof(Int32));
            dt.Columns[CT_OrderConf_SalesOrderDivCd].DefaultValue = 0;
            // 2008.07.25 30413 犬飼 [明細]の項目追加 <<<<<<END
            // --- ADD 2009/01/30 -------------------------------->>>>>
            // 受注残数
            dt.Columns.Add(CT_OrderConf_AcptAnOdrRemainCnt, typeof(double));
            dt.Columns[CT_OrderConf_AcptAnOdrRemainCnt].DefaultValue = 0;

            // 受注数量
            dt.Columns.Add(CT_OrderConf_AcceptAnOrderCnt, typeof(double));
            dt.Columns[CT_OrderConf_AcceptAnOrderCnt].DefaultValue = 0;

            // 受注調整数
            dt.Columns.Add(CT_OrderConf_AcptAnOdrAdjustCnt, typeof(double));
            dt.Columns[CT_OrderConf_AcptAnOdrAdjustCnt].DefaultValue = 0;

            // 受注数
            dt.Columns.Add(CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt, typeof(double));
            dt.Columns[CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt].DefaultValue = 0;
            // --- ADD 2009/01/30 --------------------------------<<<<<

            // ↓↓テーブル定義書以外の追加項目
            // 売上伝票区分名称
            dt.Columns.Add(CT_OrderConf_SalesSlipName, typeof(string));
            dt.Columns[CT_OrderConf_SalesSlipName].DefaultValue = "";

            // 類別(明細)
            dt.Columns.Add(CT_OrderConf_CategoryDtl, typeof(string));
            dt.Columns[CT_OrderConf_CategoryDtl].DefaultValue = "";

            // 売上在庫取寄せ区分名称
            dt.Columns.Add(CT_OrderConf_SalesOrderDivName, typeof(string));
            dt.Columns[CT_OrderConf_SalesOrderDivName].DefaultValue = "";

            // 消費税
            dt.Columns.Add(CT_OrderConf_Tax, typeof(Int64));
            dt.Columns[CT_OrderConf_Tax].DefaultValue = 0;

            // 粗利(税抜き)(伝票)
            dt.Columns.Add(CT_OrderConf_GrossProfit, typeof(Int64));
            dt.Columns[CT_OrderConf_GrossProfit].DefaultValue = 0;

            // 粗利(税抜き)(明細)
            dt.Columns.Add(CT_OrderConf_GrossProfitDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_GrossProfitDtl].DefaultValue = 0;




            //粗利チェック下限
            dt.Columns.Add(CT_OrderConf_GrsProfitCheckLower, typeof(Double));
            dt.Columns[CT_OrderConf_GrsProfitCheckLower].DefaultValue = 0;
            //粗利チェック適正
            dt.Columns.Add(CT_OrderConf_GrsProfitCheckBest, typeof(Double));
            dt.Columns[CT_OrderConf_GrsProfitCheckBest].DefaultValue = 0;
            //粗利チェック上限
            dt.Columns.Add(CT_OrderConf_GrsProfitCheckUpper, typeof(Double));
            dt.Columns[CT_OrderConf_GrsProfitCheckUpper].DefaultValue = 0;
            //消費税[伝票]
            dt.Columns.Add(CT_OrderConf_ConsTaxSlip, typeof(Int64));
            dt.Columns[CT_OrderConf_ConsTaxSlip].DefaultValue = 0;
            //消費税[明細]
            dt.Columns.Add(CT_OrderConf_ConsTaxDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_ConsTaxDtl].DefaultValue = 0;
            //消費税（売上）[伝票]
            dt.Columns.Add(CT_OrderConf_ConsTaxSlSlip, typeof(Int64));
            dt.Columns[CT_OrderConf_ConsTaxSlSlip].DefaultValue = 0;
            //消費税（売上）[明細]
            dt.Columns.Add(CT_OrderConf_ConsTaxSlDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_ConsTaxSlDtl].DefaultValue = 0;
            //消費税（返品）[伝票]
            dt.Columns.Add(CT_OrderConf_ConsTaxRtnSlip, typeof(Int64));
            dt.Columns[CT_OrderConf_ConsTaxRtnSlip].DefaultValue = 0;
            //消費税（返品）[明細]
            dt.Columns.Add(CT_OrderConf_ConsTaxRtnDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_ConsTaxRtnDtl].DefaultValue = 0;
            //消費税（値引）[伝票]
            dt.Columns.Add(CT_OrderConf_ConsTaxDisSlip, typeof(Int64));
            dt.Columns[CT_OrderConf_ConsTaxDisSlip].DefaultValue = 0;
            //消費税（値引）[明細]
            dt.Columns.Add(CT_OrderConf_ConsTaxDisDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_ConsTaxDisDtl].DefaultValue = 0;


            // 2009.01.27 30413 犬飼 消費税と合計金額の追加 >>>>>>START
            // ↓↓小計部[伝票]の設定
            //売上数[伝票]
            dt.Columns.Add(CT_OrderConf_CntSales, typeof(Int32));
            dt.Columns[CT_OrderConf_CntSales].DefaultValue = 0;
            //売上額[伝票]
            dt.Columns.Add(CT_OrderConf_SalesMoney, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesMoney].DefaultValue = 0;
            //原価金額計（売上）[伝票]
            dt.Columns.Add(CT_OrderConf_TotalCostSl, typeof(Int64));
            dt.Columns[CT_OrderConf_TotalCostSl].DefaultValue = 0;
            //売上合計粗利(税抜き)(伝票)
            dt.Columns.Add(CT_OrderConf_SalesGrossProfit, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesGrossProfit].DefaultValue = 0;
            // 売上合計消費税(伝票)
            dt.Columns.Add(CT_OrderConf_SalesTax, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesTax].DefaultValue = 0;
            // 売上の消費税込合計金額(伝票)
            dt.Columns.Add(CT_OrderConf_SalesTotalAll, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesTotalAll].DefaultValue = 0;

            //返品数[伝票]
            dt.Columns.Add(CT_OrderConf_CntReturn, typeof(Int32));
            dt.Columns[CT_OrderConf_CntReturn].DefaultValue = 0;
            //返品額[伝票]
            dt.Columns.Add(CT_OrderConf_ReturnSalesMoney, typeof(Int64));
            dt.Columns[CT_OrderConf_ReturnSalesMoney].DefaultValue = 0;
            //原価金額計（返品）[伝票]
            dt.Columns.Add(CT_OrderConf_TotalCostRtn, typeof(Int64));
            dt.Columns[CT_OrderConf_TotalCostRtn].DefaultValue = 0;
            //返品合計粗利(税抜き)(伝票)
            dt.Columns.Add(CT_OrderConf_ReturnGrossProfit, typeof(Int64));
            dt.Columns[CT_OrderConf_ReturnGrossProfit].DefaultValue = 0;
            // 返品合計消費税(伝票)
            dt.Columns.Add(CT_OrderConf_ReturnTax, typeof(Int64));
            dt.Columns[CT_OrderConf_ReturnTax].DefaultValue = 0;
            // 返品の消費税込合計金額(伝票)
            dt.Columns.Add(CT_OrderConf_ReturnTotalAll, typeof(Int64));
            dt.Columns[CT_OrderConf_ReturnTotalAll].DefaultValue = 0;

            //値引き合計原価(税抜き)(伝票)
            dt.Columns.Add(CT_OrderConf_DistCost, typeof(Int64));
            dt.Columns[CT_OrderConf_DistCost].DefaultValue = 0;
            //値引き合計粗利(税抜き)(伝票)
            dt.Columns.Add(CT_OrderConf_DistGrossProfit, typeof(Int64));
            dt.Columns[CT_OrderConf_DistGrossProfit].DefaultValue = 0;
            // 値引き合計消費税(伝票)
            dt.Columns.Add(CT_OrderConf_DistTax, typeof(Int64));
            dt.Columns[CT_OrderConf_DistTax].DefaultValue = 0;
            // 値引きの消費税込合計金額(伝票)
            dt.Columns.Add(CT_OrderConf_DistTotalAll, typeof(Int64));
            dt.Columns[CT_OrderConf_DistTotalAll].DefaultValue = 0;

            // ↓↓小計部[明細]の設定
            //売上数[明細]
            dt.Columns.Add(CT_OrderConf_CntSalesDtl, typeof(Int32));
            dt.Columns[CT_OrderConf_CntSalesDtl].DefaultValue = 0;
            //売上額[明細]
            dt.Columns.Add(CT_OrderConf_SalesMoneyDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesMoneyDtl].DefaultValue = 0;
            //原価金額計（売上）[明細]
            dt.Columns.Add(CT_OrderConf_TotalCostDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_TotalCostDtl].DefaultValue = 0;
            //売上合計粗利(税抜き)(明細)
            dt.Columns.Add(CT_OrderConf_SalesGrossProfitDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesGrossProfitDtl].DefaultValue = 0;
            // 売上合計消費税(明細)
            dt.Columns.Add(CT_OrderConf_SalesDtlTax, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesDtlTax].DefaultValue = 0;

            //返品数[明細]
            dt.Columns.Add(CT_OrderConf_CntReturnDtl, typeof(Int32));
            dt.Columns[CT_OrderConf_CntReturnDtl].DefaultValue = 0;
            //返品額[明細]
            dt.Columns.Add(CT_OrderConf_SalesMoneyRtnDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesMoneyRtnDtl].DefaultValue = 0;
            //原価金額計（返品）[明細]
            dt.Columns.Add(CT_OrderConf_TotalCostRtnDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_TotalCostRtnDtl].DefaultValue = 0;
            //返品合計粗利(税抜き)(明細)
            dt.Columns.Add(CT_OrderConf_ReturnGrossProfitDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_ReturnGrossProfitDtl].DefaultValue = 0;
            // 返品合計消費税(明細)
            dt.Columns.Add(CT_OrderConf_ReturnDtlTax, typeof(Int64));
            dt.Columns[CT_OrderConf_ReturnDtlTax].DefaultValue = 0;

            //『値引』金額[明細]
            dt.Columns.Add(CT_OrderConf_SalesDisTtlTaxExcDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_SalesDisTtlTaxExcDtl].DefaultValue = 0;
            // 値引き合計原価金額(税抜き)(明細)
            dt.Columns.Add(CT_OrderConf_DistDtlCost, typeof(Int64));
            dt.Columns[CT_OrderConf_DistDtlCost].DefaultValue = 0;
            // 値引き合計粗利(税抜き)(明細)
            dt.Columns.Add(CT_OrderConf_DistGrossProfitDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_DistGrossProfitDtl].DefaultValue = 0;
            // 値引き合計消費税(明細)
            dt.Columns.Add(CT_OrderConf_DistDtlTax, typeof(Int64));
            dt.Columns[CT_OrderConf_DistDtlTax].DefaultValue = 0;
            // 2009.01.27 30413 犬飼 消費税と合計金額の追加 <<<<<<END


            //純売上[伝票]
            dt.Columns.Add(CT_OrderConf_PureTotalCost, typeof(Int64));
            dt.Columns[CT_OrderConf_PureTotalCost].DefaultValue = 0;
            //純売上[明細]
            dt.Columns.Add(CT_OrderConf_PureTotalCostDtl, typeof(Int64));
            dt.Columns[CT_OrderConf_PureTotalCostDtl].DefaultValue = 0;
            ////『値引』原価金額[明細]
            //dt.Columns.Add(CT_OrderConf_TotalDisCostRtnDtl, typeof(Int64));
            //dt.Columns[CT_OrderConf_TotalDisCostRtnDtl].DefaultValue = 0;

            // --- ADD 2008/10/31 ------------------------------------------------------------>>>>>
            // 消費税転嫁方式[伝票]
            dt.Columns.Add(CT_OrderConf_ConsTaxLayMethod, typeof(Int32));
            dt.Columns[CT_OrderConf_ConsTaxLayMethod].DefaultValue = 0;
            // 課税区分[明細]
            dt.Columns.Add(CT_OrderConf_TaxationDivCd, typeof(Int32));
            dt.Columns[CT_OrderConf_TaxationDivCd].DefaultValue = 0;
            // 売上金額消費税額（内税）[伝票]
            dt.Columns.Add(CT_OrderConf_SalesTotalTaxExcPlusTax, typeof(Double));
            dt.Columns[CT_OrderConf_SalesTotalTaxExcPlusTax].DefaultValue = 0;
            // --- ADD 2008/10/31 ------------------------------------------------------------<<<<<

            // 2008.11.27 30413 犬飼 印刷項目の追加 >>>>>>START
            // 定価（税抜，浮動）
            dt.Columns.Add(CT_OrderConf_ListPriceTaxExcFl, typeof(Double));
            dt.Columns[CT_OrderConf_ListPriceTaxExcFl].DefaultValue = 0;
            // 2008.11.27 30413 犬飼 印刷項目の追加 <<<<<<END

#if false
				//
				dt.Columns.Add(,typeof());
				dt.Columns[].DefaultValue = ;
#endif


            // キーブレイク
            dt.Columns.Add(COL_KEYBREAK_AR, typeof(string));
            dt.Columns[COL_KEYBREAK_AR].DefaultValue = "";
        }

		#endregion

		}
	}
