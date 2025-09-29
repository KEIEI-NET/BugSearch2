using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 仕入データオブジェクトコンバートクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入関連クラスの項目コンバート制御を行います。</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2008.05.21</br>
	/// <br></br>
	/// </remarks>
	public class ConvertStockSlip
	{
		/// <summary>
		/// PramData→UIData移項処理
		/// </summary>
		/// <param name="stockSlipWork">仕入データワークオブジェクト</param>
		/// <returns>仕入データオブジェクト</returns>
		public static StockSlip UIDataFromParamData( StockSlipWork stockSlipWork )
		{
			StockSlip stockSlip = new StockSlip();

			#region ●項目セット

			stockSlip.CreateDateTime = stockSlipWork.CreateDateTime;			// 作成日時
			stockSlip.UpdateDateTime = stockSlipWork.UpdateDateTime;			// 更新日時
			stockSlip.EnterpriseCode = stockSlipWork.EnterpriseCode;			// 企業コード
			stockSlip.FileHeaderGuid = stockSlipWork.FileHeaderGuid;			// GUID
			stockSlip.UpdEmployeeCode = stockSlipWork.UpdEmployeeCode;			// 更新従業員コード
			stockSlip.UpdAssemblyId1 = stockSlipWork.UpdAssemblyId1;			// 更新アセンブリID1
			stockSlip.UpdAssemblyId2 = stockSlipWork.UpdAssemblyId2;			// 更新アセンブリID2
			stockSlip.LogicalDeleteCode = stockSlipWork.LogicalDeleteCode;		// 論理削除区分
			stockSlip.SupplierFormal = stockSlipWork.SupplierFormal;			// 仕入形式
			stockSlip.SupplierSlipNo = stockSlipWork.SupplierSlipNo;			// 仕入伝票番号
			stockSlip.SectionCode = stockSlipWork.SectionCode;					// 拠点コード
			stockSlip.SubSectionCode = stockSlipWork.SubSectionCode;			// 部門コード
			stockSlip.DebitNoteDiv = stockSlipWork.DebitNoteDiv;				// 赤伝区分
			stockSlip.DebitNLnkSuppSlipNo = stockSlipWork.DebitNLnkSuppSlipNo;	// 赤黒連結仕入伝票番号
			stockSlip.SupplierSlipCd = stockSlipWork.SupplierSlipCd;			// 仕入伝票区分
			stockSlip.StockGoodsCd = stockSlipWork.StockGoodsCd;				// 仕入商品区分
			stockSlip.AccPayDivCd = stockSlipWork.AccPayDivCd;					// 買掛区分
			stockSlip.StockSectionCd = stockSlipWork.StockSectionCd;			// 仕入拠点コード
			stockSlip.StockAddUpSectionCd = stockSlipWork.StockAddUpSectionCd;	// 仕入計上拠点コード
			stockSlip.StockSlipUpdateCd = stockSlipWork.StockSlipUpdateCd;		// 仕入伝票更新区分
			stockSlip.InputDay = stockSlipWork.InputDay;						// 入力日
			stockSlip.ArrivalGoodsDay = stockSlipWork.ArrivalGoodsDay;			// 入荷日
			stockSlip.StockDate = stockSlipWork.StockDate;						// 仕入日
			stockSlip.StockAddUpADate = stockSlipWork.StockAddUpADate;			// 仕入計上日付
			stockSlip.DelayPaymentDiv = stockSlipWork.DelayPaymentDiv;			// 来勘区分
			stockSlip.PayeeCode = stockSlipWork.PayeeCode;						// 支払先コード
			stockSlip.PayeeSnm = stockSlipWork.PayeeSnm;						// 支払先略称
			stockSlip.SupplierCd = stockSlipWork.SupplierCd;					// 仕入先コード
			stockSlip.SupplierNm1 = stockSlipWork.SupplierNm1;					// 仕入先名1
			stockSlip.SupplierNm2 = stockSlipWork.SupplierNm2;					// 仕入先名2
			stockSlip.SupplierSnm = stockSlipWork.SupplierSnm;					// 仕入先略称
			stockSlip.BusinessTypeCode = stockSlipWork.BusinessTypeCode;		// 業種コード
			stockSlip.BusinessTypeName = stockSlipWork.BusinessTypeName;		// 業種名称
			stockSlip.SalesAreaCode = stockSlipWork.SalesAreaCode;				// 販売エリアコード
			stockSlip.SalesAreaName = stockSlipWork.SalesAreaName;				// 販売エリア名称
			stockSlip.StockInputCode = stockSlipWork.StockInputCode;			// 仕入入力者コード
			stockSlip.StockInputName = stockSlipWork.StockInputName;			// 仕入入力者名称
			stockSlip.StockAgentCode = stockSlipWork.StockAgentCode;			// 仕入担当者コード
			stockSlip.StockAgentName = stockSlipWork.StockAgentName;			// 仕入担当者名称
			stockSlip.SuppTtlAmntDspWayCd = stockSlipWork.SuppTtlAmntDspWayCd;	// 仕入先総額表示方法区分
			stockSlip.TtlAmntDispRateApy = stockSlipWork.TtlAmntDispRateApy;	// 総額表示掛率適用区分
			stockSlip.StockTotalPrice = stockSlipWork.StockTotalPrice;			// 仕入金額合計
			stockSlip.StockSubttlPrice = stockSlipWork.StockSubttlPrice;		// 仕入金額小計
			stockSlip.StockTtlPricTaxInc = stockSlipWork.StockTtlPricTaxInc;	// 仕入金額計（税込み）
			stockSlip.StockTtlPricTaxExc = stockSlipWork.StockTtlPricTaxExc;	// 仕入金額計（税抜き）
			stockSlip.StockNetPrice = stockSlipWork.StockNetPrice;				// 仕入正価金額
			stockSlip.StockPriceConsTax = stockSlipWork.StockPriceConsTax;		// 仕入金額消費税額
			stockSlip.TtlItdedStcOutTax = stockSlipWork.TtlItdedStcOutTax;		// 仕入外税対象額合計
			stockSlip.TtlItdedStcInTax = stockSlipWork.TtlItdedStcInTax;		// 仕入内税対象額合計
			stockSlip.TtlItdedStcTaxFree = stockSlipWork.TtlItdedStcTaxFree;	// 仕入非課税対象額合計
			stockSlip.StockOutTax = stockSlipWork.StockOutTax;					// 仕入金額消費税額（外税）
			stockSlip.StckPrcConsTaxInclu = stockSlipWork.StckPrcConsTaxInclu;	// 仕入金額消費税額（内税）
			stockSlip.StckDisTtlTaxExc = stockSlipWork.StckDisTtlTaxExc;		// 仕入値引金額計（税抜き）
			stockSlip.ItdedStockDisOutTax = stockSlipWork.ItdedStockDisOutTax;	// 仕入値引外税対象額合計
			stockSlip.ItdedStockDisInTax = stockSlipWork.ItdedStockDisInTax;	// 仕入値引内税対象額合計
			stockSlip.ItdedStockDisTaxFre = stockSlipWork.ItdedStockDisTaxFre;	// 仕入値引非課税対象額合計
			stockSlip.StockDisOutTax = stockSlipWork.StockDisOutTax;			// 仕入値引消費税額（外税）
			stockSlip.StckDisTtlTaxInclu = stockSlipWork.StckDisTtlTaxInclu;	// 仕入値引消費税額（内税）
			stockSlip.TaxAdjust = stockSlipWork.TaxAdjust;						// 消費税調整額
			stockSlip.BalanceAdjust = stockSlipWork.BalanceAdjust;				// 残高調整額
			stockSlip.SuppCTaxLayCd = stockSlipWork.SuppCTaxLayCd;				// 仕入先消費税転嫁方式コード
			stockSlip.SupplierConsTaxRate = stockSlipWork.SupplierConsTaxRate;	// 仕入先消費税税率
			stockSlip.AccPayConsTax = stockSlipWork.AccPayConsTax;				// 買掛消費税
			stockSlip.StockFractionProcCd = stockSlipWork.StockFractionProcCd;	// 仕入端数処理区分
			stockSlip.AutoPayment = stockSlipWork.AutoPayment;					// 自動支払区分
			stockSlip.AutoPaySlipNum = stockSlipWork.AutoPaySlipNum;			// 自動支払伝票番号
			stockSlip.RetGoodsReasonDiv = stockSlipWork.RetGoodsReasonDiv;		// 返品理由コード
			stockSlip.RetGoodsReason = stockSlipWork.RetGoodsReason;			// 返品理由
			stockSlip.PartySaleSlipNum = stockSlipWork.PartySaleSlipNum;		// 相手先伝票番号
			stockSlip.SupplierSlipNote1 = stockSlipWork.SupplierSlipNote1;		// 仕入伝票備考1
			stockSlip.SupplierSlipNote2 = stockSlipWork.SupplierSlipNote2;		// 仕入伝票備考2
			stockSlip.DetailRowCount = stockSlipWork.DetailRowCount;			// 明細行数
			stockSlip.EdiSendDate = stockSlipWork.EdiSendDate;					// ＥＤＩ送信日
			stockSlip.EdiTakeInDate = stockSlipWork.EdiTakeInDate;				// ＥＤＩ取込日
			stockSlip.UoeRemark1 = stockSlipWork.UoeRemark1;					// ＵＯＥリマーク１
			stockSlip.UoeRemark2 = stockSlipWork.UoeRemark2;					// ＵＯＥリマーク２
			stockSlip.SlipPrintDivCd = stockSlipWork.SlipPrintDivCd;			// 伝票発行区分
			stockSlip.SlipPrintFinishCd = stockSlipWork.SlipPrintFinishCd;		// 伝票発行済区分
			stockSlip.StockSlipPrintDate = stockSlipWork.StockSlipPrintDate;	// 仕入伝票発行日
			stockSlip.SlipPrtSetPaperId = stockSlipWork.SlipPrtSetPaperId;		// 伝票印刷設定用帳票ID
			stockSlip.SlipAddressDiv = stockSlipWork.SlipAddressDiv;			// 伝票住所区分
			stockSlip.AddresseeCode = stockSlipWork.AddresseeCode;				// 納品先コード
			stockSlip.AddresseeName = stockSlipWork.AddresseeName;				// 納品先名称
			stockSlip.AddresseeName2 = stockSlipWork.AddresseeName2;			// 納品先名称2
			stockSlip.AddresseePostNo = stockSlipWork.AddresseePostNo;			// 納品先郵便番号
			stockSlip.AddresseeAddr1 = stockSlipWork.AddresseeAddr1;			// 納品先住所1(都道府県市区郡・町村・字)
			stockSlip.AddresseeAddr3 = stockSlipWork.AddresseeAddr3;			// 納品先住所3(番地)
			stockSlip.AddresseeAddr4 = stockSlipWork.AddresseeAddr4;			// 納品先住所4(アパート名称)
			stockSlip.AddresseeTelNo = stockSlipWork.AddresseeTelNo;			// 納品先電話番号
			stockSlip.AddresseeFaxNo = stockSlipWork.AddresseeFaxNo;			// 納品先FAX番号
			stockSlip.DirectSendingCd = stockSlipWork.DirectSendingCd;			// 直送区分

			#endregion

			return stockSlip;
		}

		/// <summary>
		/// PramData→UIData移項処理
		/// </summary>
		/// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
		/// <returns>仕入明細データオブジェクトリスト</returns>
		public static List<StockDetail> UIDataFromParamData( StockDetailWork[] stockDetailWorkArray )
		{
			if (stockDetailWorkArray == null) return null;

			List<StockDetail> stockDetailList = new List<StockDetail>();

			foreach (StockDetailWork stockDetailWork in stockDetailWorkArray)
			{
				stockDetailList.Add(UIDataFromParamData(stockDetailWork));
			}

			return stockDetailList;
		}

		/// <summary>
		/// PramData→UIData移項処理
		/// </summary>
		/// <param name="addUpSrcStockDetailWorkList">計上元仕入明細データワークオブジェクト配列</param>
		/// <returns>仕入明細データオブジェクトリスト</returns>
        public static List<StockDetail> UIDataFromParamData( AddUpOrgStockDetailWork[] addUpSrcStockDetailWorkList )
		{
			if (addUpSrcStockDetailWorkList == null) return null;

			List<StockDetail> addUppOrgStockDetailList = new List<StockDetail>();

            foreach (AddUpOrgStockDetailWork addUpOrgStockDetailWork in addUpSrcStockDetailWorkList)
			{
				addUppOrgStockDetailList.Add(UIDataFromParamData((StockDetailWork)addUpOrgStockDetailWork));
			}

			return addUppOrgStockDetailList;
		}

		/// <summary>
		/// PramData→UIData移項処理
		/// </summary>
		/// <param name="stockDetailWork">仕入明細データワークオブジェクト</param>
		/// <returns>仕入明細データオブジェクト</returns>
		public static StockDetail UIDataFromParamData( StockDetailWork stockDetailWork )
		{
			StockDetail stockDetail = new StockDetail();

			#region ●項目セット

			// ※倉庫コードはトリムしてセット

            stockDetail.CreateDateTime = stockDetailWork.CreateDateTime;                // 作成日時
            stockDetail.UpdateDateTime = stockDetailWork.UpdateDateTime;                // 更新日時
            stockDetail.EnterpriseCode = stockDetailWork.EnterpriseCode;                // 企業コード
            stockDetail.FileHeaderGuid = stockDetailWork.FileHeaderGuid;                // GUID
            stockDetail.UpdEmployeeCode = stockDetailWork.UpdEmployeeCode;              // 更新従業員コード
            stockDetail.UpdAssemblyId1 = stockDetailWork.UpdAssemblyId1;                // 更新アセンブリID1
            stockDetail.UpdAssemblyId2 = stockDetailWork.UpdAssemblyId2;                // 更新アセンブリID2
            stockDetail.LogicalDeleteCode = stockDetailWork.LogicalDeleteCode;          // 論理削除区分
            stockDetail.AcceptAnOrderNo = stockDetailWork.AcceptAnOrderNo;              // 受注番号
            stockDetail.SupplierFormal = stockDetailWork.SupplierFormal;                // 仕入形式
            stockDetail.SupplierSlipNo = stockDetailWork.SupplierSlipNo;                // 仕入伝票番号
            stockDetail.StockRowNo = stockDetailWork.StockRowNo;                        // 仕入行番号
            stockDetail.SectionCode = stockDetailWork.SectionCode;                      // 拠点コード
            stockDetail.SubSectionCode = stockDetailWork.SubSectionCode;                // 部門コード
            stockDetail.CommonSeqNo = stockDetailWork.CommonSeqNo;                      // 共通通番
            stockDetail.StockSlipDtlNum = stockDetailWork.StockSlipDtlNum;              // 仕入明細通番
            stockDetail.SupplierFormalSrc = stockDetailWork.SupplierFormalSrc;          // 仕入形式（元）
            stockDetail.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNumSrc;        // 仕入明細通番（元）
            stockDetail.AcptAnOdrStatusSync = stockDetailWork.AcptAnOdrStatusSync;      // 受注ステータス（同時）
            stockDetail.SalesSlipDtlNumSync = stockDetailWork.SalesSlipDtlNumSync;      // 売上明細通番（同時）
            stockDetail.StockSlipCdDtl = stockDetailWork.StockSlipCdDtl;                // 仕入伝票区分（明細）
            stockDetail.StockInputCode = stockDetailWork.StockInputCode;                // 仕入入力者コード
            stockDetail.StockInputName = stockDetailWork.StockInputName;                // 仕入入力者名称
            stockDetail.StockAgentCode = stockDetailWork.StockAgentCode;                // 仕入担当者コード
            stockDetail.StockAgentName = stockDetailWork.StockAgentName;                // 仕入担当者名称
            stockDetail.GoodsKindCode = stockDetailWork.GoodsKindCode;                  // 商品属性
            stockDetail.GoodsMakerCd = stockDetailWork.GoodsMakerCd;                    // 商品メーカーコード
            stockDetail.MakerName = stockDetailWork.MakerName;                          // メーカー名称
            stockDetail.MakerKanaName = stockDetailWork.MakerKanaName;                  // メーカーカナ名称
            stockDetail.CmpltMakerKanaName = stockDetailWork.CmpltMakerKanaName;        // メーカーカナ名称（一式）
            stockDetail.GoodsNo = stockDetailWork.GoodsNo;                              // 商品番号
            stockDetail.GoodsName = stockDetailWork.GoodsName;                          // 商品名称
            stockDetail.GoodsNameKana = stockDetailWork.GoodsNameKana;                  // 商品名称カナ
            stockDetail.GoodsLGroup = stockDetailWork.GoodsLGroup;                      // 商品大分類コード
            stockDetail.GoodsLGroupName = stockDetailWork.GoodsLGroupName;              // 商品大分類名称
            stockDetail.GoodsMGroup = stockDetailWork.GoodsMGroup;                      // 商品中分類コード
            stockDetail.GoodsMGroupName = stockDetailWork.GoodsMGroupName;              // 商品中分類名称
            stockDetail.BLGroupCode = stockDetailWork.BLGroupCode;                      // BLグループコード
            stockDetail.BLGroupName = stockDetailWork.BLGroupName;                      // BLグループコード名称
            stockDetail.BLGoodsCode = stockDetailWork.BLGoodsCode;                      // BL商品コード
            stockDetail.BLGoodsFullName = stockDetailWork.BLGoodsFullName;              // BL商品コード名称（全角）
            stockDetail.EnterpriseGanreCode = stockDetailWork.EnterpriseGanreCode;      // 自社分類コード
            stockDetail.EnterpriseGanreName = stockDetailWork.EnterpriseGanreName;      // 自社分類名称
            stockDetail.WarehouseCode = stockDetailWork.WarehouseCode.Trim();           // 倉庫コード
            stockDetail.WarehouseName = stockDetailWork.WarehouseName;                  // 倉庫名称
            stockDetail.WarehouseShelfNo = stockDetailWork.WarehouseShelfNo;            // 倉庫棚番
            stockDetail.StockOrderDivCd = stockDetailWork.StockOrderDivCd;              // 仕入在庫取寄せ区分
            stockDetail.OpenPriceDiv = stockDetailWork.OpenPriceDiv;                    // オープン価格区分
            stockDetail.GoodsRateRank = stockDetailWork.GoodsRateRank;                  // 商品掛率ランク
            stockDetail.CustRateGrpCode = stockDetailWork.CustRateGrpCode;              // 得意先掛率グループコード
            stockDetail.SuppRateGrpCode = stockDetailWork.SuppRateGrpCode;              // 仕入先掛率グループコード
            stockDetail.ListPriceTaxExcFl = stockDetailWork.ListPriceTaxExcFl;          // 定価（税抜，浮動）
            stockDetail.ListPriceTaxIncFl = stockDetailWork.ListPriceTaxIncFl;          // 定価（税込，浮動）
            stockDetail.StockRate = stockDetailWork.StockRate;                          // 仕入率
            stockDetail.RateSectStckUnPrc = stockDetailWork.RateSectStckUnPrc;          // 掛率設定拠点（仕入単価）
            stockDetail.RateDivStckUnPrc = stockDetailWork.RateDivStckUnPrc;            // 掛率設定区分（仕入単価）
            stockDetail.UnPrcCalcCdStckUnPrc = stockDetailWork.UnPrcCalcCdStckUnPrc;    // 単価算出区分（仕入単価）
            stockDetail.PriceCdStckUnPrc = stockDetailWork.PriceCdStckUnPrc;            // 価格区分（仕入単価）
            stockDetail.StdUnPrcStckUnPrc = stockDetailWork.StdUnPrcStckUnPrc;          // 基準単価（仕入単価）
            stockDetail.FracProcUnitStcUnPrc = stockDetailWork.FracProcUnitStcUnPrc;    // 端数処理単位（仕入単価）
            stockDetail.FracProcStckUnPrc = stockDetailWork.FracProcStckUnPrc;          // 端数処理（仕入単価）
            stockDetail.StockUnitPriceFl = stockDetailWork.StockUnitPriceFl;            // 仕入単価（税抜，浮動）
            stockDetail.StockUnitTaxPriceFl = stockDetailWork.StockUnitTaxPriceFl;      // 仕入単価（税込，浮動）
            stockDetail.StockUnitChngDiv = stockDetailWork.StockUnitChngDiv;            // 仕入単価変更区分
            stockDetail.BfStockUnitPriceFl = stockDetailWork.BfStockUnitPriceFl;        // 変更前仕入単価（浮動）
            stockDetail.BfListPrice = stockDetailWork.BfListPrice;                      // 変更前定価
            stockDetail.RateBLGoodsCode = stockDetailWork.RateBLGoodsCode;              // BL商品コード（掛率）
            stockDetail.RateBLGoodsName = stockDetailWork.RateBLGoodsName;              // BL商品コード名称（掛率）
            stockDetail.RateGoodsRateGrpCd = stockDetailWork.RateGoodsRateGrpCd;        // 商品掛率グループコード（掛率）
            stockDetail.RateGoodsRateGrpNm = stockDetailWork.RateGoodsRateGrpNm;        // 商品掛率グループ名称（掛率）
            stockDetail.RateBLGroupCode = stockDetailWork.RateBLGroupCode;              // BLグループコード（掛率）
            stockDetail.RateBLGroupName = stockDetailWork.RateBLGroupName;              // BLグループ名称（掛率）
            stockDetail.StockCount = stockDetailWork.StockCount;                        // 仕入数
            stockDetail.OrderCnt = stockDetailWork.OrderCnt;                            // 発注数量
            stockDetail.OrderAdjustCnt = stockDetailWork.OrderAdjustCnt;                // 発注調整数
            stockDetail.OrderRemainCnt = stockDetailWork.OrderRemainCnt;                // 発注残数
            stockDetail.RemainCntUpdDate = stockDetailWork.RemainCntUpdDate;            // 残数更新日
            stockDetail.StockPriceTaxExc = stockDetailWork.StockPriceTaxExc;            // 仕入金額（税抜き）
            stockDetail.StockPriceTaxInc = stockDetailWork.StockPriceTaxInc;            // 仕入金額（税込み）
            stockDetail.StockGoodsCd = stockDetailWork.StockGoodsCd;                    // 仕入商品区分
            stockDetail.StockPriceConsTax = stockDetailWork.StockPriceConsTax;          // 仕入金額消費税額
            stockDetail.TaxationCode = stockDetailWork.TaxationCode;                    // 課税区分
            stockDetail.StockDtiSlipNote1 = stockDetailWork.StockDtiSlipNote1;          // 仕入伝票明細備考1
            stockDetail.SalesCustomerCode = stockDetailWork.SalesCustomerCode;          // 販売先コード
            stockDetail.SalesCustomerSnm = stockDetailWork.SalesCustomerSnm;            // 販売先略称
            stockDetail.SlipMemo1 = stockDetailWork.SlipMemo1;                          // 伝票メモ１
            stockDetail.SlipMemo2 = stockDetailWork.SlipMemo2;                          // 伝票メモ２
            stockDetail.SlipMemo3 = stockDetailWork.SlipMemo3;                          // 伝票メモ３
            stockDetail.InsideMemo1 = stockDetailWork.InsideMemo1;                      // 社内メモ１
            stockDetail.InsideMemo2 = stockDetailWork.InsideMemo2;                      // 社内メモ２
            stockDetail.InsideMemo3 = stockDetailWork.InsideMemo3;                      // 社内メモ３
            stockDetail.SupplierCd = stockDetailWork.SupplierCd;                        // 仕入先コード
            stockDetail.SupplierSnm = stockDetailWork.SupplierSnm;                      // 仕入先略称
            stockDetail.AddresseeCode = stockDetailWork.AddresseeCode;                  // 納品先コード
            stockDetail.AddresseeName = stockDetailWork.AddresseeName;                  // 納品先名称
            stockDetail.DirectSendingCd = stockDetailWork.DirectSendingCd;              // 直送区分
            stockDetail.OrderNumber = stockDetailWork.OrderNumber;                      // 発注番号
            stockDetail.WayToOrder = stockDetailWork.WayToOrder;                        // 注文方法
            stockDetail.DeliGdsCmpltDueDate = stockDetailWork.DeliGdsCmpltDueDate;      // 納品完了予定日
            stockDetail.ExpectDeliveryDate = stockDetailWork.ExpectDeliveryDate;        // 希望納期
            stockDetail.OrderDataCreateDiv = stockDetailWork.OrderDataCreateDiv;        // 発注データ作成区分
            stockDetail.OrderDataCreateDate = stockDetailWork.OrderDataCreateDate;      // 発注データ作成日
            stockDetail.OrderFormIssuedDiv = stockDetailWork.OrderFormIssuedDiv;        // 発注書発行済区分


			#endregion

			return stockDetail;
		}

		/// <summary>
		/// PramData→UIData移項処理
		/// </summary>
		/// <param name="salesTempWorkList">売上データ(仕入同時計上)ワークオブジェクト配列</param>
		/// <returns>売上データ(仕入同時計上)データオブジェクトリスト</returns>
		public static List<SalesTemp> UIDataFromParamData( SalesTempWork[] salesTempWorkList )
		{
			if (salesTempWorkList == null) return null;

			List<SalesTemp> salesTempList = new List<SalesTemp>();

			foreach (SalesTempWork salesTempWork in salesTempWorkList)
			{
				salesTempList.Add(UIDataFromParamData((SalesTempWork)salesTempWork));
			}

			return salesTempList;
		}

		/// <summary>
		/// PramData→UIData移項処理
		/// </summary>
		/// <param name="salesTempWork">売上データ(仕入同時計上)ワークオブジェクト</param>
		/// <returns>売上データ(仕入同時計上)オブジェクト</returns>
		public static SalesTemp UIDataFromParamData( SalesTempWork salesTempWork )
		{
			SalesTemp salesTemp = new SalesTemp();

			#region ●項目セット

			// ※倉庫コードはトリムしてセット

			salesTemp.CreateDateTime = salesTempWork.CreateDateTime;
			salesTemp.UpdateDateTime = salesTempWork.UpdateDateTime;
			salesTemp.EnterpriseCode = salesTempWork.EnterpriseCode;
			salesTemp.FileHeaderGuid = salesTempWork.FileHeaderGuid;
			salesTemp.UpdEmployeeCode = salesTempWork.UpdEmployeeCode;
			salesTemp.UpdAssemblyId1 = salesTempWork.UpdAssemblyId1;
			salesTemp.UpdAssemblyId2 = salesTempWork.UpdAssemblyId2;
			salesTemp.LogicalDeleteCode = salesTempWork.LogicalDeleteCode;
			salesTemp.AcptAnOdrStatus = salesTempWork.AcptAnOdrStatus;
			salesTemp.SectionCode = salesTempWork.SectionCode;
			salesTemp.SubSectionCode = salesTempWork.SubSectionCode;
			salesTemp.MinSectionCode = salesTempWork.MinSectionCode;
			salesTemp.DebitNoteDiv = salesTempWork.DebitNoteDiv;
			salesTemp.DebitNLnkAcptAnOdr = salesTempWork.DebitNLnkAcptAnOdr;
			salesTemp.SalesSlipCd = salesTempWork.SalesSlipCd;
			salesTemp.AccRecDivCd = salesTempWork.AccRecDivCd;
			salesTemp.SalesInpSecCd = salesTempWork.SalesInpSecCd;
			salesTemp.DemandAddUpSecCd = salesTempWork.DemandAddUpSecCd;
			salesTemp.ResultsAddUpSecCd = salesTempWork.ResultsAddUpSecCd;
			salesTemp.UpdateSecCd = salesTempWork.UpdateSecCd;
			salesTemp.SearchSlipDate = salesTempWork.SearchSlipDate;
			salesTemp.ShipmentDay = salesTempWork.ShipmentDay;
			salesTemp.SalesDate = salesTempWork.SalesDate;
			salesTemp.AddUpADate = salesTempWork.AddUpADate;
			salesTemp.DelayPaymentDiv = salesTempWork.DelayPaymentDiv;
			salesTemp.ClaimCode = salesTempWork.ClaimCode;
			salesTemp.ClaimSnm = salesTempWork.ClaimSnm;
			salesTemp.CustomerCode = salesTempWork.CustomerCode;
			salesTemp.CustomerName = salesTempWork.CustomerName;
			salesTemp.CustomerName2 = salesTempWork.CustomerName2;
			salesTemp.CustomerSnm = salesTempWork.CustomerSnm;
			salesTemp.HonorificTitle = salesTempWork.HonorificTitle;
			salesTemp.OutputNameCode = salesTempWork.OutputNameCode;
			salesTemp.BusinessTypeCode = salesTempWork.BusinessTypeCode;
			salesTemp.BusinessTypeName = salesTempWork.BusinessTypeName;
			salesTemp.SalesAreaCode = salesTempWork.SalesAreaCode;
			salesTemp.SalesAreaName = salesTempWork.SalesAreaName;
			salesTemp.SalesInputCode = salesTempWork.SalesInputCode;
			salesTemp.SalesInputName = salesTempWork.SalesInputName;
			salesTemp.FrontEmployeeCd = salesTempWork.FrontEmployeeCd;
			salesTemp.FrontEmployeeNm = salesTempWork.FrontEmployeeNm;
			salesTemp.SalesEmployeeCd = salesTempWork.SalesEmployeeCd;
			salesTemp.SalesEmployeeNm = salesTempWork.SalesEmployeeNm;
			salesTemp.ConsTaxLayMethod = salesTempWork.ConsTaxLayMethod;
			salesTemp.ConsTaxRate = salesTempWork.ConsTaxRate;
			salesTemp.FractionProcCd = salesTempWork.FractionProcCd;
			salesTemp.AutoDepositCd = salesTempWork.AutoDepositCd;
			salesTemp.AutoDepoSlipNum = salesTempWork.AutoDepoSlipNum;
			salesTemp.SlipAddressDiv = salesTempWork.SlipAddressDiv;
			salesTemp.AddresseeCode = salesTempWork.AddresseeCode;
			salesTemp.AddresseeName = salesTempWork.AddresseeName;
			salesTemp.AddresseeName2 = salesTempWork.AddresseeName2;
			salesTemp.AddresseePostNo = salesTempWork.AddresseePostNo;
			salesTemp.AddresseeAddr1 = salesTempWork.AddresseeAddr1;
			salesTemp.AddresseeAddr2 = salesTempWork.AddresseeAddr2;
			salesTemp.AddresseeAddr3 = salesTempWork.AddresseeAddr3;
			salesTemp.AddresseeAddr4 = salesTempWork.AddresseeAddr4;
			salesTemp.AddresseeTelNo = salesTempWork.AddresseeTelNo;
			salesTemp.AddresseeFaxNo = salesTempWork.AddresseeFaxNo;
			salesTemp.PartySaleSlipNum = salesTempWork.PartySaleSlipNum;
			salesTemp.SlipNote = salesTempWork.SlipNote;
			salesTemp.SlipNote2 = salesTempWork.SlipNote2;
			salesTemp.RetGoodsReasonDiv = salesTempWork.RetGoodsReasonDiv;
			salesTemp.RetGoodsReason = salesTempWork.RetGoodsReason;
			salesTemp.DetailRowCount = salesTempWork.DetailRowCount;
			salesTemp.DeliveredGoodsDiv = salesTempWork.DeliveredGoodsDiv;
			salesTemp.DeliveredGoodsDivNm = salesTempWork.DeliveredGoodsDivNm;
			salesTemp.ReconcileFlag = salesTempWork.ReconcileFlag;
			salesTemp.SlipPrtSetPaperId = salesTempWork.SlipPrtSetPaperId;
			salesTemp.CompleteCd = salesTempWork.CompleteCd;
			salesTemp.ClaimType = salesTempWork.ClaimType;
			salesTemp.SalesPriceFracProcCd = salesTempWork.SalesPriceFracProcCd;
			salesTemp.ListPricePrintDiv = salesTempWork.ListPricePrintDiv;
			salesTemp.EraNameDispCd1 = salesTempWork.EraNameDispCd1;
			salesTemp.AcceptAnOrderNo = salesTempWork.AcceptAnOrderNo;
			salesTemp.CommonSeqNo = salesTempWork.CommonSeqNo;
			salesTemp.SalesSlipDtlNum = salesTempWork.SalesSlipDtlNum;
			salesTemp.AcptAnOdrStatusSrc = salesTempWork.AcptAnOdrStatusSrc;
			salesTemp.SalesSlipDtlNumSrc = salesTempWork.SalesSlipDtlNumSrc;
			salesTemp.SupplierFormalSync = salesTempWork.SupplierFormalSync;
			salesTemp.StockSlipDtlNumSync = salesTempWork.StockSlipDtlNumSync;
			salesTemp.SalesSlipCdDtl = salesTempWork.SalesSlipCdDtl;
			salesTemp.OrderNumber = salesTempWork.OrderNumber;
			salesTemp.StockMngExistCd = salesTempWork.StockMngExistCd;
			salesTemp.DeliGdsCmpltDueDate = salesTempWork.DeliGdsCmpltDueDate;
			salesTemp.GoodsKindCode = salesTempWork.GoodsKindCode;
			salesTemp.GoodsMakerCd = salesTempWork.GoodsMakerCd;
			salesTemp.MakerName = salesTempWork.MakerName;
			salesTemp.GoodsNo = salesTempWork.GoodsNo;
			salesTemp.GoodsName = salesTempWork.GoodsName;
			salesTemp.GoodsShortName = salesTempWork.GoodsShortName;
			salesTemp.GoodsSetDivCd = salesTempWork.GoodsSetDivCd;
			salesTemp.LargeGoodsGanreCode = salesTempWork.LargeGoodsGanreCode;
			salesTemp.LargeGoodsGanreName = salesTempWork.LargeGoodsGanreName;
			salesTemp.MediumGoodsGanreCode = salesTempWork.MediumGoodsGanreCode;
			salesTemp.MediumGoodsGanreName = salesTempWork.MediumGoodsGanreName;
			salesTemp.DetailGoodsGanreCode = salesTempWork.DetailGoodsGanreCode;
			salesTemp.DetailGoodsGanreName = salesTempWork.DetailGoodsGanreName;
			salesTemp.BLGoodsCode = salesTempWork.BLGoodsCode;
			salesTemp.BLGoodsFullName = salesTempWork.BLGoodsFullName;
			salesTemp.EnterpriseGanreCode = salesTempWork.EnterpriseGanreCode;
			salesTemp.EnterpriseGanreName = salesTempWork.EnterpriseGanreName;
			salesTemp.WarehouseCode = salesTempWork.WarehouseCode.Trim();
			salesTemp.WarehouseName = salesTempWork.WarehouseName;
			salesTemp.WarehouseShelfNo = salesTempWork.WarehouseShelfNo;
			salesTemp.SalesOrderDivCd = salesTempWork.SalesOrderDivCd;
			salesTemp.OpenPriceDiv = salesTempWork.OpenPriceDiv;
			salesTemp.UnitCode = salesTempWork.UnitCode;
			salesTemp.UnitName = salesTempWork.UnitName;
			salesTemp.GoodsRateRank = salesTempWork.GoodsRateRank;
			salesTemp.CustRateGrpCode = salesTempWork.CustRateGrpCode;
			salesTemp.SuppRateGrpCode = salesTempWork.SuppRateGrpCode;
			salesTemp.ListPriceRate = salesTempWork.ListPriceRate;
			salesTemp.RateSectPriceUnPrc = salesTempWork.RateSectPriceUnPrc;
			salesTemp.RateDivLPrice = salesTempWork.RateDivLPrice;
			salesTemp.UnPrcCalcCdLPrice = salesTempWork.UnPrcCalcCdLPrice;
			salesTemp.PriceCdLPrice = salesTempWork.PriceCdLPrice;
			salesTemp.StdUnPrcLPrice = salesTempWork.StdUnPrcLPrice;
			salesTemp.FracProcUnitLPrice = salesTempWork.FracProcUnitLPrice;
			salesTemp.FracProcLPrice = salesTempWork.FracProcLPrice;
			salesTemp.ListPriceTaxIncFl = salesTempWork.ListPriceTaxIncFl;
			salesTemp.ListPriceTaxExcFl = salesTempWork.ListPriceTaxExcFl;
			salesTemp.ListPriceChngCd = salesTempWork.ListPriceChngCd;
			salesTemp.SalesRate = salesTempWork.SalesRate;
			salesTemp.RateSectSalUnPrc = salesTempWork.RateSectSalUnPrc;
			salesTemp.RateDivSalUnPrc = salesTempWork.RateDivSalUnPrc;
			salesTemp.UnPrcCalcCdSalUnPrc = salesTempWork.UnPrcCalcCdSalUnPrc;
			salesTemp.PriceCdSalUnPrc = salesTempWork.PriceCdSalUnPrc;
			salesTemp.StdUnPrcSalUnPrc = salesTempWork.StdUnPrcSalUnPrc;
			salesTemp.FracProcUnitSalUnPrc = salesTempWork.FracProcUnitSalUnPrc;
			salesTemp.FracProcSalUnPrc = salesTempWork.FracProcSalUnPrc;
			salesTemp.SalesUnPrcTaxIncFl = salesTempWork.SalesUnPrcTaxIncFl;
			salesTemp.SalesUnPrcTaxExcFl = salesTempWork.SalesUnPrcTaxExcFl;
			salesTemp.SalesUnPrcChngCd = salesTempWork.SalesUnPrcChngCd;
			salesTemp.CostRate = salesTempWork.CostRate;
			salesTemp.RateSectCstUnPrc = salesTempWork.RateSectCstUnPrc;
			salesTemp.RateDivUnCst = salesTempWork.RateDivUnCst;
			salesTemp.UnPrcCalcCdUnCst = salesTempWork.UnPrcCalcCdUnCst;
			salesTemp.PriceCdUnCst = salesTempWork.PriceCdUnCst;
			salesTemp.StdUnPrcUnCst = salesTempWork.StdUnPrcUnCst;
			salesTemp.FracProcUnitUnCst = salesTempWork.FracProcUnitUnCst;
			salesTemp.FracProcUnCst = salesTempWork.FracProcUnCst;
			salesTemp.SalesUnitCost = salesTempWork.SalesUnitCost;
			salesTemp.SalesUnitCostChngDiv = salesTempWork.SalesUnitCostChngDiv;
			salesTemp.RateBLGoodsCode = salesTempWork.RateBLGoodsCode;
			salesTemp.RateBLGoodsName = salesTempWork.RateBLGoodsName;
			salesTemp.BargainCd = salesTempWork.BargainCd;
			salesTemp.BargainNm = salesTempWork.BargainNm;
			salesTemp.ShipmentCnt = salesTempWork.ShipmentCnt;
			salesTemp.SalesMoneyTaxInc = salesTempWork.SalesMoneyTaxInc;
			salesTemp.SalesMoneyTaxExc = salesTempWork.SalesMoneyTaxExc;
			salesTemp.Cost = salesTempWork.Cost;
			salesTemp.GrsProfitChkDiv = salesTempWork.GrsProfitChkDiv;
			salesTemp.SalesGoodsCd = salesTempWork.SalesGoodsCd;
			salesTemp.SalsePriceConsTax = salesTempWork.SalsePriceConsTax;
			salesTemp.TaxationDivCd = salesTempWork.TaxationDivCd;
			salesTemp.PartySlipNumDtl = salesTempWork.PartySlipNumDtl;
			salesTemp.DtlNote = salesTempWork.DtlNote;
			salesTemp.SupplierCd = salesTempWork.SupplierCd;
			salesTemp.SupplierSnm = salesTempWork.SupplierSnm;
			salesTemp.SlipMemo1 = salesTempWork.SlipMemo1;
			salesTemp.SlipMemo2 = salesTempWork.SlipMemo2;
			salesTemp.SlipMemo3 = salesTempWork.SlipMemo3;
			salesTemp.SlipMemo4 = salesTempWork.SlipMemo4;
			salesTemp.SlipMemo5 = salesTempWork.SlipMemo5;
			salesTemp.SlipMemo6 = salesTempWork.SlipMemo6;
			salesTemp.InsideMemo1 = salesTempWork.InsideMemo1;
			salesTemp.InsideMemo2 = salesTempWork.InsideMemo2;
			salesTemp.InsideMemo3 = salesTempWork.InsideMemo3;
			salesTemp.InsideMemo4 = salesTempWork.InsideMemo4;
			salesTemp.InsideMemo5 = salesTempWork.InsideMemo5;
			salesTemp.InsideMemo6 = salesTempWork.InsideMemo6;
			salesTemp.BfListPrice = salesTempWork.BfListPrice;
			salesTemp.BfSalesUnitPrice = salesTempWork.BfSalesUnitPrice;
			salesTemp.BfUnitCost = salesTempWork.BfUnitCost;
			salesTemp.PrtGoodsNo = salesTempWork.PrtGoodsNo;
			salesTemp.PrtGoodsName = salesTempWork.PrtGoodsName;
			salesTemp.PrtGoodsMakerCd = salesTempWork.PrtGoodsMakerCd;
			salesTemp.PrtGoodsMakerNm = salesTempWork.PrtGoodsMakerNm;
			//salesTempRow.SupplierSlipCd = salesTempWork.SupplierSlipCd;
			//salesTempRow.TotalAmountDispWayCd = salesTempWork.TotalAmountDispWayCd;
			//salesTempRow.TtlAmntDispRateApy = salesTempWork.TtlAmntDispRateApy;
			//salesTempRow.ConfirmedDiv = salesTempWork.ConfirmedDiv;
			//salesTempRow.NTimeCalcStDate = salesTempWork.NTimeCalcStDate;
			//salesTempRow.TotalDay = salesTempWork.TotalDay;
			salesTemp.DtlRelationGuid = salesTempWork.DtlRelationGuid;

			#endregion

			return salesTemp;
		}

		/// <summary>
		/// PramData→UIData移項処理
		/// </summary>
		/// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		/// <param name="salesSlipWorkList">売上データオブジェクトリスト</param>
		/// <param name="salesDetailWorkList">売上明細データオブジェクトリスト</param>
		/// <returns>売上データ(仕入同時計上)オブジェクトリスト</returns>
		public static List<SalesTemp> UIDataFromParamData( List<StockDetail> stockDetailList, List<SalesSlipWork> salesSlipWorkList, List<SalesDetailWork> salesDetailWorkList )
		{
			if (( salesSlipWorkList == null ) || ( salesDetailWorkList == null )) return null;

			List<SalesTemp> salesTempList = new List<SalesTemp>();

			foreach (SalesDetailWork salesDetailWork in salesDetailWorkList)
			{
				// 伝票情報の取得
				SalesSlipWork salesSlipWork = null;
				foreach (SalesSlipWork salesSlipWorkTemp in salesSlipWorkList)
				{
					if (( salesDetailWork.AcptAnOdrStatus == salesSlipWorkTemp.AcptAnOdrStatus ) &&
						( salesDetailWork.SalesSlipNum == salesSlipWorkTemp.SalesSlipNum ))
					{
						salesSlipWork = salesSlipWorkTemp;
						break;
					}
				}

				if (salesSlipWork ==null)continue;

				// 同時仕入情報の取得
				foreach (StockDetail stockDetail in stockDetailList)
				{
					if (( stockDetail.AcptAnOdrStatusSync == salesDetailWork.AcptAnOdrStatus ) &&
						( stockDetail.SalesSlipDtlNumSync == salesDetailWork.SalesSlipDtlNum ) &&
						( stockDetail.StockSlipDtlNum == salesDetailWork.StockSlipDtlNumSync ) &&
						( stockDetail.SupplierFormal == salesDetailWork.SupplierFormalSync ))
					{
						salesTempList.Add((SalesTemp)UIDataFromParamData(salesSlipWork, salesDetailWork));
					}
				}
			}

			return salesTempList;
		}

		/// <summary>
		/// PramData→UIData移項処理
		/// </summary>
		/// <param name="salesSlipWork">売上データワークオブジェクト</param>
		/// <param name="salesDetailWork">売上明細データワークオブジェクト</param>
		/// <returns>売上データ(仕入同時計上)オブジェクト</returns>
		public static SalesTemp UIDataFromParamData( SalesSlipWork salesSlipWork, SalesDetailWork salesDetailWork )
		{
			SalesTemp salesTemp = new SalesTemp();

			#region ●項目セット

			#region ■売上データからセットする項目

			salesTemp.CreateDateTime = salesSlipWork.CreateDateTime;
			salesTemp.UpdateDateTime = salesSlipWork.UpdateDateTime;
			salesTemp.EnterpriseCode = salesSlipWork.EnterpriseCode;
			salesTemp.FileHeaderGuid = salesSlipWork.FileHeaderGuid;
			salesTemp.UpdEmployeeCode = salesSlipWork.UpdEmployeeCode;
			salesTemp.UpdAssemblyId1 = salesSlipWork.UpdAssemblyId1;
			salesTemp.UpdAssemblyId2 = salesSlipWork.UpdAssemblyId2;
			salesTemp.LogicalDeleteCode = salesSlipWork.LogicalDeleteCode;
			salesTemp.AcptAnOdrStatus = salesSlipWork.AcptAnOdrStatus;
			salesTemp.SectionCode = salesSlipWork.SectionCode;
			salesTemp.SubSectionCode = salesSlipWork.SubSectionCode;
			salesTemp.DebitNoteDiv = salesSlipWork.DebitNoteDiv;
			salesTemp.SalesSlipCd = salesSlipWork.SalesSlipCd;
			salesTemp.AccRecDivCd = salesSlipWork.AccRecDivCd;
			salesTemp.SalesInpSecCd = salesSlipWork.SalesInpSecCd;
			salesTemp.DemandAddUpSecCd = salesSlipWork.DemandAddUpSecCd;
			salesTemp.ResultsAddUpSecCd = salesSlipWork.ResultsAddUpSecCd;
			salesTemp.UpdateSecCd = salesSlipWork.UpdateSecCd;
			salesTemp.SearchSlipDate = salesSlipWork.SearchSlipDate;
			salesTemp.ShipmentDay = salesSlipWork.ShipmentDay;
			salesTemp.SalesDate = salesSlipWork.SalesDate;
			salesTemp.AddUpADate = salesSlipWork.AddUpADate;
			salesTemp.DelayPaymentDiv = salesSlipWork.DelayPaymentDiv;
			salesTemp.ClaimCode = salesSlipWork.ClaimCode;
			salesTemp.ClaimSnm = salesSlipWork.ClaimSnm;
			salesTemp.CustomerCode = salesSlipWork.CustomerCode;
			salesTemp.CustomerName = salesSlipWork.CustomerName;
			salesTemp.CustomerName2 = salesSlipWork.CustomerName2;
			salesTemp.CustomerSnm = salesSlipWork.CustomerSnm;
			salesTemp.HonorificTitle = salesSlipWork.HonorificTitle;
			salesTemp.OutputNameCode = salesSlipWork.OutputNameCode;
			salesTemp.BusinessTypeCode = salesSlipWork.BusinessTypeCode;
			salesTemp.BusinessTypeName = salesSlipWork.BusinessTypeName;
			salesTemp.SalesAreaCode = salesSlipWork.SalesAreaCode;
			salesTemp.SalesAreaName = salesSlipWork.SalesAreaName;
			salesTemp.SalesInputCode = salesSlipWork.SalesInputCode;
			salesTemp.SalesInputName = salesSlipWork.SalesInputName;
			salesTemp.FrontEmployeeCd = salesSlipWork.FrontEmployeeCd;
			salesTemp.FrontEmployeeNm = salesSlipWork.FrontEmployeeNm;
			salesTemp.SalesEmployeeCd = salesSlipWork.SalesEmployeeCd;
			salesTemp.SalesEmployeeNm = salesSlipWork.SalesEmployeeNm;
			salesTemp.ConsTaxLayMethod = salesSlipWork.ConsTaxLayMethod;
			salesTemp.ConsTaxRate = salesSlipWork.ConsTaxRate;
			salesTemp.FractionProcCd = salesSlipWork.FractionProcCd;
			salesTemp.AutoDepositCd = salesSlipWork.AutoDepositCd;
			//salesTempRow.AutoDepoSlipNum = salesSlipWork.AutoDepoSlipNum;
			salesTemp.SlipAddressDiv = salesSlipWork.SlipAddressDiv;
			salesTemp.AddresseeCode = salesSlipWork.AddresseeCode;
			salesTemp.AddresseeName = salesSlipWork.AddresseeName;
			salesTemp.AddresseeName2 = salesSlipWork.AddresseeName2;
			salesTemp.AddresseePostNo = salesSlipWork.AddresseePostNo;
			salesTemp.AddresseeAddr1 = salesSlipWork.AddresseeAddr1;
			salesTemp.AddresseeAddr3 = salesSlipWork.AddresseeAddr3;
			salesTemp.AddresseeAddr4 = salesSlipWork.AddresseeAddr4;
			salesTemp.AddresseeTelNo = salesSlipWork.AddresseeTelNo;
			salesTemp.AddresseeFaxNo = salesSlipWork.AddresseeFaxNo;
			salesTemp.PartySaleSlipNum = salesSlipWork.PartySaleSlipNum;
			salesTemp.SlipNote = salesSlipWork.SlipNote;
			salesTemp.SlipNote2 = salesSlipWork.SlipNote2;
			salesTemp.RetGoodsReasonDiv = salesSlipWork.RetGoodsReasonDiv;
			salesTemp.RetGoodsReason = salesSlipWork.RetGoodsReason;
			salesTemp.DetailRowCount = salesSlipWork.DetailRowCount;
			salesTemp.DeliveredGoodsDiv = salesSlipWork.DeliveredGoodsDiv;
			salesTemp.DeliveredGoodsDivNm = salesSlipWork.DeliveredGoodsDivNm;
			salesTemp.ReconcileFlag = salesSlipWork.ReconcileFlag;
			salesTemp.SlipPrtSetPaperId = salesSlipWork.SlipPrtSetPaperId;
			salesTemp.CompleteCd = salesSlipWork.CompleteCd;
			salesTemp.SalesPriceFracProcCd = salesSlipWork.SalesPriceFracProcCd;
			salesTemp.ListPricePrintDiv = salesSlipWork.ListPricePrintDiv;
			salesTemp.EraNameDispCd1 = salesSlipWork.EraNameDispCd1;
			//salesTempRow.AcceptAnOrderNo = salesSlipWork.AcceptAnOrderNo;
			//salesTempRow.CommonSeqNo = salesSlipWork.CommonSeqNo;
			//salesTempRow.SalesSlipDtlNum = salesSlipWork.SalesSlipDtlNum;
			//salesTempRow.AcptAnOdrStatusSrc = salesSlipWork.AcptAnOdrStatusSrc;
			//salesTempRow.SalesSlipDtlNumSrc = salesSlipWork.SalesSlipDtlNumSrc;
			//salesTempRow.SupplierFormalSync = salesSlipWork.SupplierFormalSync;
			//salesTempRow.StockSlipDtlNumSync = salesSlipWork.StockSlipDtlNumSync;
			//salesTempRow.SalesSlipCdDtl = salesSlipWork.SalesSlipCdDtl;
			salesTemp.OrderNumber = salesSlipWork.OrderNumber;
			//salesTempRow.StockMngExistCd = salesSlipWork.StockMngExistCd;
			//salesTempRow.DeliGdsCmpltDueDate = salesSlipWork.DeliGdsCmpltDueDate;
			//salesTempRow.GoodsKindCode = salesSlipWork.GoodsKindCode;
			//salesTempRow.GoodsMakerCd = salesSlipWork.GoodsMakerCd;
			//salesTempRow.MakerName = salesSlipWork.MakerName;
			//salesTempRow.GoodsNo = salesSlipWork.GoodsNo;
			//salesTempRow.GoodsName = salesSlipWork.GoodsName;
			//salesTempRow.GoodsShortName = salesSlipWork.GoodsShortName;
			//salesTempRow.GoodsSetDivCd = salesSlipWork.GoodsSetDivCd;
			//salesTempRow.LargeGoodsGanreCode = salesSlipWork.LargeGoodsGanreCode;
			//salesTempRow.LargeGoodsGanreName = salesSlipWork.LargeGoodsGanreName;
			//salesTempRow.MediumGoodsGanreCode = salesSlipWork.MediumGoodsGanreCode;
			//salesTempRow.MediumGoodsGanreName = salesSlipWork.MediumGoodsGanreName;
			//salesTempRow.DetailGoodsGanreCode = salesSlipWork.DetailGoodsGanreCode;
			//salesTempRow.DetailGoodsGanreName = salesSlipWork.DetailGoodsGanreName;
			//salesTempRow.BLGoodsCode = salesSlipWork.BLGoodsCode;
			//salesTempRow.BLGoodsFullName = salesSlipWork.BLGoodsFullName;
			//salesTempRow.EnterpriseGanreCode = salesSlipWork.EnterpriseGanreCode;
			//salesTempRow.EnterpriseGanreName = salesSlipWork.EnterpriseGanreName;
			//salesTempRow.WarehouseCode = salesSlipWork.WarehouseCode;
			//salesTempRow.WarehouseName = salesSlipWork.WarehouseName;
			//salesTempRow.WarehouseShelfNo = salesSlipWork.WarehouseShelfNo;
			//salesTempRow.SalesOrderDivCd = salesSlipWork.SalesOrderDivCd;
			//salesTempRow.OpenPriceDiv = salesSlipWork.OpenPriceDiv;
			//salesTempRow.UnitCode = salesSlipWork.UnitCode;
			//salesTempRow.UnitName = salesSlipWork.UnitName;
			//salesTempRow.GoodsRateRank = salesSlipWork.GoodsRateRank;
			//salesTempRow.CustRateGrpCode = salesSlipWork.CustRateGrpCode;
			//salesTempRow.SuppRateGrpCode = salesSlipWork.SuppRateGrpCode;
			//salesTempRow.ListPriceRate = salesSlipWork.ListPriceRate;
			//salesTempRow.RateSectPriceUnPrc = salesSlipWork.RateSectPriceUnPrc;
			//salesTempRow.RateDivLPrice = salesSlipWork.RateDivLPrice;
			//salesTempRow.UnPrcCalcCdLPrice = salesSlipWork.UnPrcCalcCdLPrice;
			//salesTempRow.PriceCdLPrice = salesSlipWork.PriceCdLPrice;
			//salesTempRow.StdUnPrcLPrice = salesSlipWork.StdUnPrcLPrice;
			//salesTempRow.FracProcUnitLPrice = salesSlipWork.FracProcUnitLPrice;
			//salesTempRow.FracProcLPrice = salesSlipWork.FracProcLPrice;
			//salesTempRow.ListPriceTaxIncFl = salesSlipWork.ListPriceTaxIncFl;
			//salesTempRow.ListPriceTaxExcFl = salesSlipWork.ListPriceTaxExcFl;
			//salesTempRow.ListPriceChngCd = salesSlipWork.ListPriceChngCd;
			//salesTempRow.SalesRate = salesSlipWork.SalesRate;
			//salesTempRow.RateSectSalUnPrc = salesSlipWork.RateSectSalUnPrc;
			//salesTempRow.RateDivSalUnPrc = salesSlipWork.RateDivSalUnPrc;
			//salesTempRow.UnPrcCalcCdSalUnPrc = salesSlipWork.UnPrcCalcCdSalUnPrc;
			//salesTempRow.PriceCdSalUnPrc = salesSlipWork.PriceCdSalUnPrc;
			//salesTempRow.StdUnPrcSalUnPrc = salesSlipWork.StdUnPrcSalUnPrc;
			//salesTempRow.FracProcUnitSalUnPrc = salesSlipWork.FracProcUnitSalUnPrc;
			//salesTempRow.FracProcSalUnPrc = salesSlipWork.FracProcSalUnPrc;
			//salesTempRow.SalesUnPrcTaxIncFl = salesSlipWork.SalesUnPrcTaxIncFl;
			//salesTempRow.SalesUnPrcTaxExcFl = salesSlipWork.SalesUnPrcTaxExcFl;
			//salesTempRow.SalesUnPrcChngCd = salesSlipWork.SalesUnPrcChngCd;
			//salesTempRow.CostRate = salesSlipWork.CostRate;
			//salesTempRow.RateSectCstUnPrc = salesSlipWork.RateSectCstUnPrc;
			//salesTempRow.RateDivUnCst = salesSlipWork.RateDivUnCst;
			//salesTempRow.UnPrcCalcCdUnCst = salesSlipWork.UnPrcCalcCdUnCst;
			//salesTempRow.PriceCdUnCst = salesSlipWork.PriceCdUnCst;
			//salesTempRow.StdUnPrcUnCst = salesSlipWork.StdUnPrcUnCst;
			//salesTempRow.FracProcUnitUnCst = salesSlipWork.FracProcUnitUnCst;
			//salesTempRow.FracProcUnCst = salesSlipWork.FracProcUnCst;
			//salesTempRow.SalesUnitCost = salesSlipWork.SalesUnitCost;
			//salesTempRow.SalesUnitCostChngDiv = salesSlipWork.SalesUnitCostChngDiv;
			//salesTempRow.RateBLGoodsCode = salesSlipWork.RateBLGoodsCode;
			//salesTempRow.RateBLGoodsName = salesSlipWork.RateBLGoodsName;
			//salesTempRow.BargainCd = salesSlipWork.BargainCd;
			//salesTempRow.BargainNm = salesSlipWork.BargainNm;
			//salesTempRow.ShipmentCnt = salesSlipWork.ShipmentCnt;
			//salesTempRow.SalesMoneyTaxInc = salesSlipWork.SalesMoneyTaxInc;
			//salesTempRow.SalesMoneyTaxExc = salesSlipWork.SalesMoneyTaxExc;
			//salesTempRow.Cost = salesSlipWork.Cost;
			//salesTempRow.GrsProfitChkDiv = salesSlipWork.GrsProfitChkDiv;
			//salesTempRow.SalesGoodsCd = salesSlipWork.SalesGoodsCd;
			//salesTempRow.SalsePriceConsTax = salesSlipWork.SalsePriceConsTax;
			//salesTempRow.TaxationDivCd = salesSlipWork.TaxationDivCd;
			//salesTempRow.PartySlipNumDtl = salesSlipWork.PartySlipNumDtl;
			//salesTempRow.DtlNote = salesSlipWork.DtlNote;
			//salesTempRow.SupplierCd = salesSlipWork.SupplierCd;
			//salesTempRow.SupplierSnm = salesSlipWork.SupplierSnm;
			//salesTempRow.SlipMemo1 = salesSlipWork.SlipMemo1;
			//salesTempRow.SlipMemo2 = salesSlipWork.SlipMemo2;
			//salesTempRow.SlipMemo3 = salesSlipWork.SlipMemo3;
			//salesTempRow.SlipMemo4 = salesSlipWork.SlipMemo4;
			//salesTempRow.SlipMemo5 = salesSlipWork.SlipMemo5;
			//salesTempRow.SlipMemo6 = salesSlipWork.SlipMemo6;
			//salesTempRow.InsideMemo1 = salesSlipWork.InsideMemo1;
			//salesTempRow.InsideMemo2 = salesSlipWork.InsideMemo2;
			//salesTempRow.InsideMemo3 = salesSlipWork.InsideMemo3;
			//salesTempRow.InsideMemo4 = salesSlipWork.InsideMemo4;
			//salesTempRow.InsideMemo5 = salesSlipWork.InsideMemo5;
			//salesTempRow.InsideMemo6 = salesSlipWork.InsideMemo6;
			//salesTempRow.BfListPrice = salesSlipWork.BfListPrice;
			//salesTempRow.BfSalesUnitPrice = salesSlipWork.BfSalesUnitPrice;
			//salesTempRow.BfUnitCost = salesSlipWork.BfUnitCost;
			//salesTempRow.PrtGoodsNo = salesSlipWork.PrtGoodsNo;
			//salesTempRow.PrtGoodsName = salesSlipWork.PrtGoodsName;
			//salesTempRow.PrtGoodsMakerCd = salesSlipWork.PrtGoodsMakerCd;
			//salesTempRow.PrtGoodsMakerNm = salesSlipWork.PrtGoodsMakerNm;
			//salesTempRow.SupplierSlipCd = salesSlipWork.SupplierSlipCd;
			//salesTempRow.TotalAmountDispWayCd = salesSlipWork.TotalAmountDispWayCd;
			//salesTempRow.TtlAmntDispRateApy = salesSlipWork.TtlAmntDispRateApy;
			//salesTempRow.ConfirmedDiv = salesSlipWork.ConfirmedDiv;
			//salesTempRow.NTimeCalcStDate = salesSlipWork.NTimeCalcStDate;
			//salesTempRow.TotalDay = salesSlipWork.TotalDay;
			//salesTempRow.DtlRelationGuid = salesSlipWork.DtlRelationGuid;


			#endregion

			#region ■売上明細データからセットする項目

			// ※倉庫コードはトリムしてセット

			//salesTempRow.CreateDateTime = salesDetailWork.CreateDateTime;
			//salesTempRow.UpdateDateTime = salesDetailWork.UpdateDateTime;
			//salesTempRow.EnterpriseCode = salesDetailWork.EnterpriseCode;
			//salesTempRow.FileHeaderGuid = salesDetailWork.FileHeaderGuid;
			//salesTempRow.UpdEmployeeCode = salesDetailWork.UpdEmployeeCode;
			//salesTempRow.UpdAssemblyId1 = salesDetailWork.UpdAssemblyId1;
			//salesTempRow.UpdAssemblyId2 = salesDetailWork.UpdAssemblyId2;
			//salesTempRow.LogicalDeleteCode = salesDetailWork.LogicalDeleteCode;
			//salesTempRow.AcptAnOdrStatus = salesDetailWork.AcptAnOdrStatus;
			//salesTempRow.SectionCode = salesDetailWork.SectionCode;
			//salesTempRow.SubSectionCode = salesDetailWork.SubSectionCode;
			//salesTempRow.MinSectionCode = salesDetailWork.MinSectionCode;
			//salesTempRow.DebitNoteDiv = salesDetailWork.DebitNoteDiv;
			//salesTempRow.DebitNLnkAcptAnOdr = salesDetailWork.DebitNLnkAcptAnOdr;
			//salesTempRow.SalesSlipCd = salesDetailWork.SalesSlipCd;
			//salesTempRow.AccRecDivCd = salesDetailWork.AccRecDivCd;
			//salesTempRow.SalesInpSecCd = salesDetailWork.SalesInpSecCd;
			//salesTempRow.DemandAddUpSecCd = salesDetailWork.DemandAddUpSecCd;
			//salesTempRow.ResultsAddUpSecCd = salesDetailWork.ResultsAddUpSecCd;
			//salesTempRow.UpdateSecCd = salesDetailWork.UpdateSecCd;
			//salesTempRow.SearchSlipDate = salesDetailWork.SearchSlipDate;
			//salesTempRow.ShipmentDay = salesDetailWork.ShipmentDay;
			//salesTempRow.SalesDate = salesDetailWork.SalesDate;
			//salesTempRow.AddUpADate = salesDetailWork.AddUpADate;
			//salesTempRow.DelayPaymentDiv = salesDetailWork.DelayPaymentDiv;
			//salesTempRow.ClaimCode = salesDetailWork.ClaimCode;
			//salesTempRow.ClaimSnm = salesDetailWork.ClaimSnm;
			//salesTempRow.CustomerCode = salesDetailWork.CustomerCode;
			//salesTempRow.CustomerName = salesDetailWork.CustomerName;
			//salesTempRow.CustomerName2 = salesDetailWork.CustomerName2;
			//salesTempRow.CustomerSnm = salesDetailWork.CustomerSnm;
			//salesTempRow.HonorificTitle = salesDetailWork.HonorificTitle;
			//salesTempRow.OutputNameCode = salesDetailWork.OutputNameCode;
			//salesTempRow.BusinessTypeCode = salesDetailWork.BusinessTypeCode;
			//salesTempRow.BusinessTypeName = salesDetailWork.BusinessTypeName;
			//salesTempRow.SalesAreaCode = salesDetailWork.SalesAreaCode;
			//salesTempRow.SalesAreaName = salesDetailWork.SalesAreaName;
			//salesTempRow.SalesInputCode = salesDetailWork.SalesInputCode;
			//salesTempRow.SalesInputName = salesDetailWork.SalesInputName;
			//salesTempRow.FrontEmployeeCd = salesDetailWork.FrontEmployeeCd;
			//salesTempRow.FrontEmployeeNm = salesDetailWork.FrontEmployeeNm;
			//salesTempRow.SalesEmployeeCd = salesDetailWork.SalesEmployeeCd;
			//salesTempRow.SalesEmployeeNm = salesDetailWork.SalesEmployeeNm;
			//salesTempRow.ConsTaxLayMethod = salesDetailWork.ConsTaxLayMethod;
			//salesTempRow.ConsTaxRate = salesDetailWork.ConsTaxRate;
			//salesTempRow.FractionProcCd = salesDetailWork.FractionProcCd;
			//salesTempRow.AutoDepositCd = salesDetailWork.AutoDepositCd;
			//salesTempRow.AutoDepoSlipNum = salesDetailWork.AutoDepoSlipNum;
			//salesTempRow.SlipAddressDiv = salesDetailWork.SlipAddressDiv;
			//salesTempRow.AddresseeCode = salesDetailWork.AddresseeCode;
			//salesTempRow.AddresseeName = salesDetailWork.AddresseeName;
			//salesTempRow.AddresseeName2 = salesDetailWork.AddresseeName2;
			//salesTempRow.AddresseePostNo = salesDetailWork.AddresseePostNo;
			//salesTempRow.AddresseeAddr1 = salesDetailWork.AddresseeAddr1;
			//salesTempRow.AddresseeAddr2 = salesDetailWork.AddresseeAddr2;
			//salesTempRow.AddresseeAddr3 = salesDetailWork.AddresseeAddr3;
			//salesTempRow.AddresseeAddr4 = salesDetailWork.AddresseeAddr4;
			//salesTempRow.AddresseeTelNo = salesDetailWork.AddresseeTelNo;
			//salesTempRow.AddresseeFaxNo = salesDetailWork.AddresseeFaxNo;
			//salesTempRow.PartySaleSlipNum = salesDetailWork.PartySaleSlipNum;
			//salesTempRow.SlipNote = salesDetailWork.SlipNote;
			//salesTempRow.SlipNote2 = salesDetailWork.SlipNote2;
			//salesTempRow.RetGoodsReasonDiv = salesDetailWork.RetGoodsReasonDiv;
			//salesTempRow.RetGoodsReason = salesDetailWork.RetGoodsReason;
			//salesTempRow.DetailRowCount = salesDetailWork.DetailRowCount;
			//salesTempRow.DeliveredGoodsDiv = salesDetailWork.DeliveredGoodsDiv;
			//salesTempRow.DeliveredGoodsDivNm = salesDetailWork.DeliveredGoodsDivNm;
			//salesTempRow.ReconcileFlag = salesDetailWork.ReconcileFlag;
			//salesTempRow.SlipPrtSetPaperId = salesDetailWork.SlipPrtSetPaperId;
			//salesTempRow.CompleteCd = salesDetailWork.CompleteCd;
			//salesTempRow.ClaimType = salesDetailWork.ClaimType;
			//salesTempRow.SalesPriceFracProcCd = salesDetailWork.SalesPriceFracProcCd;
			//salesTempRow.ListPricePrintDiv = salesDetailWork.ListPricePrintDiv;
			//salesTempRow.EraNameDispCd1 = salesDetailWork.EraNameDispCd1;
			salesTemp.AcceptAnOrderNo = salesDetailWork.AcceptAnOrderNo;
			salesTemp.CommonSeqNo = salesDetailWork.CommonSeqNo;
			salesTemp.SalesSlipDtlNum = salesDetailWork.SalesSlipDtlNum;
			salesTemp.AcptAnOdrStatusSrc = salesDetailWork.AcptAnOdrStatusSrc;
			salesTemp.SalesSlipDtlNumSrc = salesDetailWork.SalesSlipDtlNumSrc;
			salesTemp.SupplierFormalSync = salesDetailWork.SupplierFormalSync;
			salesTemp.StockSlipDtlNumSync = salesDetailWork.StockSlipDtlNumSync;
			salesTemp.SalesSlipCdDtl = salesDetailWork.SalesSlipCdDtl;
			salesTemp.OrderNumber = salesDetailWork.OrderNumber;
			salesTemp.DeliGdsCmpltDueDate = salesDetailWork.DeliGdsCmpltDueDate;
			salesTemp.GoodsKindCode = salesDetailWork.GoodsKindCode;
			salesTemp.GoodsMakerCd = salesDetailWork.GoodsMakerCd;
			salesTemp.MakerName = salesDetailWork.MakerName;
			salesTemp.GoodsNo = salesDetailWork.GoodsNo;
			salesTemp.GoodsName = salesDetailWork.GoodsName;
			//salesTemp.GoodsShortName = salesDetailWork.GoodsShortName;
			salesTemp.BLGoodsCode = salesDetailWork.BLGoodsCode;
			salesTemp.BLGoodsFullName = salesDetailWork.BLGoodsFullName;
			salesTemp.EnterpriseGanreCode = salesDetailWork.EnterpriseGanreCode;
			salesTemp.EnterpriseGanreName = salesDetailWork.EnterpriseGanreName;
			salesTemp.WarehouseCode = salesDetailWork.WarehouseCode.Trim();
			salesTemp.WarehouseName = salesDetailWork.WarehouseName;
			salesTemp.WarehouseShelfNo = salesDetailWork.WarehouseShelfNo;
			salesTemp.SalesOrderDivCd = salesDetailWork.SalesOrderDivCd;
			salesTemp.OpenPriceDiv = salesDetailWork.OpenPriceDiv;
			salesTemp.GoodsRateRank = salesDetailWork.GoodsRateRank;
			salesTemp.CustRateGrpCode = salesDetailWork.CustRateGrpCode;
			salesTemp.ListPriceRate = salesDetailWork.ListPriceRate;
			salesTemp.RateSectPriceUnPrc = salesDetailWork.RateSectPriceUnPrc;
			salesTemp.RateDivLPrice = salesDetailWork.RateDivLPrice;
			salesTemp.UnPrcCalcCdLPrice = salesDetailWork.UnPrcCalcCdLPrice;
			salesTemp.PriceCdLPrice = salesDetailWork.PriceCdLPrice;
			salesTemp.StdUnPrcLPrice = salesDetailWork.StdUnPrcLPrice;
			salesTemp.FracProcUnitLPrice = salesDetailWork.FracProcUnitLPrice;
			salesTemp.FracProcLPrice = salesDetailWork.FracProcLPrice;
			salesTemp.ListPriceTaxIncFl = salesDetailWork.ListPriceTaxIncFl;
			salesTemp.ListPriceTaxExcFl = salesDetailWork.ListPriceTaxExcFl;
			salesTemp.ListPriceChngCd = salesDetailWork.ListPriceChngCd;
			salesTemp.SalesRate = salesDetailWork.SalesRate;
			salesTemp.RateSectSalUnPrc = salesDetailWork.RateSectSalUnPrc;
			salesTemp.RateDivSalUnPrc = salesDetailWork.RateDivSalUnPrc;
			salesTemp.UnPrcCalcCdSalUnPrc = salesDetailWork.UnPrcCalcCdSalUnPrc;
			salesTemp.PriceCdSalUnPrc = salesDetailWork.PriceCdSalUnPrc;
			salesTemp.StdUnPrcSalUnPrc = salesDetailWork.StdUnPrcSalUnPrc;
			salesTemp.FracProcUnitSalUnPrc = salesDetailWork.FracProcUnitSalUnPrc;
			salesTemp.FracProcSalUnPrc = salesDetailWork.FracProcSalUnPrc;
			salesTemp.SalesUnPrcTaxIncFl = salesDetailWork.SalesUnPrcTaxIncFl;
			salesTemp.SalesUnPrcTaxExcFl = salesDetailWork.SalesUnPrcTaxExcFl;
			salesTemp.SalesUnPrcChngCd = salesDetailWork.SalesUnPrcChngCd;
			salesTemp.CostRate = salesDetailWork.CostRate;
			salesTemp.RateSectCstUnPrc = salesDetailWork.RateSectCstUnPrc;
			salesTemp.RateDivUnCst = salesDetailWork.RateDivUnCst;
			salesTemp.UnPrcCalcCdUnCst = salesDetailWork.UnPrcCalcCdUnCst;
			salesTemp.PriceCdUnCst = salesDetailWork.PriceCdUnCst;
			salesTemp.StdUnPrcUnCst = salesDetailWork.StdUnPrcUnCst;
			salesTemp.FracProcUnitUnCst = salesDetailWork.FracProcUnitUnCst;
			salesTemp.FracProcUnCst = salesDetailWork.FracProcUnCst;
			salesTemp.SalesUnitCost = salesDetailWork.SalesUnitCost;
			salesTemp.SalesUnitCostChngDiv = salesDetailWork.SalesUnitCostChngDiv;
			salesTemp.RateBLGoodsCode = salesDetailWork.RateBLGoodsCode;
			salesTemp.RateBLGoodsName = salesDetailWork.RateBLGoodsName;
			salesTemp.ShipmentCnt = salesDetailWork.ShipmentCnt;
			salesTemp.SalesMoneyTaxInc = salesDetailWork.SalesMoneyTaxInc;
			salesTemp.SalesMoneyTaxExc = salesDetailWork.SalesMoneyTaxExc;
			salesTemp.Cost = salesDetailWork.Cost;
			salesTemp.GrsProfitChkDiv = salesDetailWork.GrsProfitChkDiv;
			salesTemp.SalesGoodsCd = salesDetailWork.SalesGoodsCd;
			salesTemp.TaxationDivCd = salesDetailWork.TaxationDivCd;
			salesTemp.PartySlipNumDtl = salesDetailWork.PartySlipNumDtl;
			salesTemp.DtlNote = salesDetailWork.DtlNote;
			salesTemp.SupplierCd = salesDetailWork.SupplierCd;
			salesTemp.SupplierSnm = salesDetailWork.SupplierSnm;
			salesTemp.SlipMemo1 = salesDetailWork.SlipMemo1;
			salesTemp.SlipMemo2 = salesDetailWork.SlipMemo2;
			salesTemp.SlipMemo3 = salesDetailWork.SlipMemo3;
			salesTemp.InsideMemo1 = salesDetailWork.InsideMemo1;
			salesTemp.InsideMemo2 = salesDetailWork.InsideMemo2;
			salesTemp.InsideMemo3 = salesDetailWork.InsideMemo3;
			salesTemp.BfListPrice = salesDetailWork.BfListPrice;
			salesTemp.BfSalesUnitPrice = salesDetailWork.BfSalesUnitPrice;
			salesTemp.BfUnitCost = salesDetailWork.BfUnitCost;
			//salesTempRow.SupplierSlipCd = salesDetailWork.SupplierSlipCd;
			//salesTempRow.TotalAmountDispWayCd = salesDetailWork.TotalAmountDispWayCd;
			//salesTempRow.TtlAmntDispRateApy = salesDetailWork.TtlAmntDispRateApy;
			//salesTempRow.ConfirmedDiv = salesDetailWork.ConfirmedDiv;
			//salesTempRow.NTimeCalcStDate = salesDetailWork.NTimeCalcStDate;
			//salesTempRow.TotalDay = salesDetailWork.TotalDay;
			salesTemp.DtlRelationGuid = salesDetailWork.DtlRelationGuid;


			#endregion

			#endregion

			return salesTemp;
		}



		/// <summary>
		/// UIData→PramData移項処理
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
        /// <returns>仕入データワークオブジェクト</returns>
        /// <remarks>
        /// <br>Update Note: 2011/12/15 tianjw</br>
        /// <br>             Redmine#27390 拠点管理/売上日のチェック</br>
        /// </remarks>
		public static StockSlipWork ParamDataFromUIData( StockSlip stockSlip )
		{
			StockSlipWork stockSlipWork = new StockSlipWork();

			#region ●項目セット

			stockSlipWork.CreateDateTime = stockSlip.CreateDateTime;			// 作成日時
			stockSlipWork.UpdateDateTime = stockSlip.UpdateDateTime;			// 更新日時
			stockSlipWork.EnterpriseCode = stockSlip.EnterpriseCode;			// 企業コード
			stockSlipWork.FileHeaderGuid = stockSlip.FileHeaderGuid;			// GUID
			stockSlipWork.UpdEmployeeCode = stockSlip.UpdEmployeeCode;			// 更新従業員コード
			stockSlipWork.UpdAssemblyId1 = stockSlip.UpdAssemblyId1;			// 更新アセンブリID1
			stockSlipWork.UpdAssemblyId2 = stockSlip.UpdAssemblyId2;			// 更新アセンブリID2
			stockSlipWork.LogicalDeleteCode = stockSlip.LogicalDeleteCode;		// 論理削除区分
			stockSlipWork.SupplierFormal = stockSlip.SupplierFormal;			// 仕入形式
			stockSlipWork.SupplierSlipNo = stockSlip.SupplierSlipNo;			// 仕入伝票番号
			stockSlipWork.SectionCode = stockSlip.SectionCode;					// 拠点コード
			stockSlipWork.SubSectionCode = stockSlip.SubSectionCode;			// 部門コード
			stockSlipWork.DebitNoteDiv = stockSlip.DebitNoteDiv;				// 赤伝区分
			stockSlipWork.DebitNLnkSuppSlipNo = stockSlip.DebitNLnkSuppSlipNo;	// 赤黒連結仕入伝票番号
			stockSlipWork.SupplierSlipCd = stockSlip.SupplierSlipCd;			// 仕入伝票区分
			stockSlipWork.StockGoodsCd = stockSlip.StockGoodsCd;				// 仕入商品区分
			stockSlipWork.AccPayDivCd = stockSlip.AccPayDivCd;					// 買掛区分
			stockSlipWork.StockSectionCd = stockSlip.StockSectionCd;			// 仕入拠点コード
			stockSlipWork.StockAddUpSectionCd = stockSlip.StockAddUpSectionCd;	// 仕入計上拠点コード
			stockSlipWork.StockSlipUpdateCd = stockSlip.StockSlipUpdateCd;		// 仕入伝票更新区分
			stockSlipWork.InputDay = stockSlip.InputDay;						// 入力日
			stockSlipWork.ArrivalGoodsDay = stockSlip.ArrivalGoodsDay;			// 入荷日
			stockSlipWork.StockDate = stockSlip.StockDate;						// 仕入日
            stockSlipWork.PreStockDate = stockSlip.PreStockDate;				// 前回仕入日 // ADD 2011/12/15
			stockSlipWork.StockAddUpADate = stockSlip.StockAddUpADate;			// 仕入計上日付
			stockSlipWork.DelayPaymentDiv = stockSlip.DelayPaymentDiv;			// 来勘区分
			stockSlipWork.PayeeCode = stockSlip.PayeeCode;						// 支払先コード
			stockSlipWork.PayeeSnm = stockSlip.PayeeSnm;						// 支払先略称
			stockSlipWork.SupplierCd = stockSlip.SupplierCd;					// 仕入先コード
			stockSlipWork.SupplierNm1 = stockSlip.SupplierNm1;					// 仕入先名1
			stockSlipWork.SupplierNm2 = stockSlip.SupplierNm2;					// 仕入先名2
			stockSlipWork.SupplierSnm = stockSlip.SupplierSnm;					// 仕入先略称
			stockSlipWork.BusinessTypeCode = stockSlip.BusinessTypeCode;		// 業種コード
			stockSlipWork.BusinessTypeName = stockSlip.BusinessTypeName;		// 業種名称
			stockSlipWork.SalesAreaCode = stockSlip.SalesAreaCode;				// 販売エリアコード
			stockSlipWork.SalesAreaName = stockSlip.SalesAreaName;				// 販売エリア名称
			stockSlipWork.StockInputCode = stockSlip.StockInputCode;			// 仕入入力者コード
			stockSlipWork.StockInputName = stockSlip.StockInputName;			// 仕入入力者名称
			stockSlipWork.StockAgentCode = stockSlip.StockAgentCode;			// 仕入担当者コード
			stockSlipWork.StockAgentName = stockSlip.StockAgentName;			// 仕入担当者名称
			stockSlipWork.SuppTtlAmntDspWayCd = stockSlip.SuppTtlAmntDspWayCd;	// 仕入先総額表示方法区分
			stockSlipWork.TtlAmntDispRateApy = stockSlip.TtlAmntDispRateApy;	// 総額表示掛率適用区分
			stockSlipWork.StockTotalPrice = stockSlip.StockTotalPrice;			// 仕入金額合計
			stockSlipWork.StockSubttlPrice = stockSlip.StockSubttlPrice;		// 仕入金額小計
			stockSlipWork.StockTtlPricTaxInc = stockSlip.StockTtlPricTaxInc;	// 仕入金額計（税込み）
			stockSlipWork.StockTtlPricTaxExc = stockSlip.StockTtlPricTaxExc;	// 仕入金額計（税抜き）
			stockSlipWork.StockNetPrice = stockSlip.StockNetPrice;				// 仕入正価金額
			stockSlipWork.StockPriceConsTax = stockSlip.StockPriceConsTax;		// 仕入金額消費税額
			stockSlipWork.TtlItdedStcOutTax = stockSlip.TtlItdedStcOutTax;		// 仕入外税対象額合計
			stockSlipWork.TtlItdedStcInTax = stockSlip.TtlItdedStcInTax;		// 仕入内税対象額合計
			stockSlipWork.TtlItdedStcTaxFree = stockSlip.TtlItdedStcTaxFree;	// 仕入非課税対象額合計
			stockSlipWork.StockOutTax = stockSlip.StockOutTax;					// 仕入金額消費税額（外税）
			stockSlipWork.StckPrcConsTaxInclu = stockSlip.StckPrcConsTaxInclu;	// 仕入金額消費税額（内税）
			stockSlipWork.StckDisTtlTaxExc = stockSlip.StckDisTtlTaxExc;		// 仕入値引金額計（税抜き）
			stockSlipWork.ItdedStockDisOutTax = stockSlip.ItdedStockDisOutTax;	// 仕入値引外税対象額合計
			stockSlipWork.ItdedStockDisInTax = stockSlip.ItdedStockDisInTax;	// 仕入値引内税対象額合計
			stockSlipWork.ItdedStockDisTaxFre = stockSlip.ItdedStockDisTaxFre;	// 仕入値引非課税対象額合計
			stockSlipWork.StockDisOutTax = stockSlip.StockDisOutTax;			// 仕入値引消費税額（外税）
			stockSlipWork.StckDisTtlTaxInclu = stockSlip.StckDisTtlTaxInclu;	// 仕入値引消費税額（内税）
			stockSlipWork.TaxAdjust = stockSlip.TaxAdjust;						// 消費税調整額
			stockSlipWork.BalanceAdjust = stockSlip.BalanceAdjust;				// 残高調整額
			stockSlipWork.SuppCTaxLayCd = stockSlip.SuppCTaxLayCd;				// 仕入先消費税転嫁方式コード
			stockSlipWork.SupplierConsTaxRate = stockSlip.SupplierConsTaxRate;	// 仕入先消費税税率
			stockSlipWork.AccPayConsTax = stockSlip.AccPayConsTax;				// 買掛消費税
			stockSlipWork.StockFractionProcCd = stockSlip.StockFractionProcCd;	// 仕入端数処理区分
			stockSlipWork.AutoPayment = stockSlip.AutoPayment;					// 自動支払区分
			stockSlipWork.AutoPaySlipNum = stockSlip.AutoPaySlipNum;			// 自動支払伝票番号
			stockSlipWork.RetGoodsReasonDiv = stockSlip.RetGoodsReasonDiv;		// 返品理由コード
			stockSlipWork.RetGoodsReason = stockSlip.RetGoodsReason;			// 返品理由
			stockSlipWork.PartySaleSlipNum = stockSlip.PartySaleSlipNum;		// 相手先伝票番号
			stockSlipWork.SupplierSlipNote1 = stockSlip.SupplierSlipNote1;		// 仕入伝票備考1
			stockSlipWork.SupplierSlipNote2 = stockSlip.SupplierSlipNote2;		// 仕入伝票備考2
			stockSlipWork.DetailRowCount = stockSlip.DetailRowCount;			// 明細行数
			stockSlipWork.EdiSendDate = stockSlip.EdiSendDate;					// ＥＤＩ送信日
			stockSlipWork.EdiTakeInDate = stockSlip.EdiTakeInDate;				// ＥＤＩ取込日
			stockSlipWork.UoeRemark1 = stockSlip.UoeRemark1;					// ＵＯＥリマーク１
			stockSlipWork.UoeRemark2 = stockSlip.UoeRemark2;					// ＵＯＥリマーク２
			stockSlipWork.SlipPrintDivCd = stockSlip.SlipPrintDivCd;			// 伝票発行区分
			stockSlipWork.SlipPrintFinishCd = stockSlip.SlipPrintFinishCd;		// 伝票発行済区分
			stockSlipWork.StockSlipPrintDate = stockSlip.StockSlipPrintDate;	// 仕入伝票発行日
			stockSlipWork.SlipPrtSetPaperId = stockSlip.SlipPrtSetPaperId;		// 伝票印刷設定用帳票ID
			stockSlipWork.SlipAddressDiv = stockSlip.SlipAddressDiv;			// 伝票住所区分
			stockSlipWork.AddresseeCode = stockSlip.AddresseeCode;				// 納品先コード
			stockSlipWork.AddresseeName = stockSlip.AddresseeName;				// 納品先名称
			stockSlipWork.AddresseeName2 = stockSlip.AddresseeName2;			// 納品先名称2
			stockSlipWork.AddresseePostNo = stockSlip.AddresseePostNo;			// 納品先郵便番号
			stockSlipWork.AddresseeAddr1 = stockSlip.AddresseeAddr1;			// 納品先住所1(都道府県市区郡・町村・字)
			stockSlipWork.AddresseeAddr3 = stockSlip.AddresseeAddr3;			// 納品先住所3(番地)
			stockSlipWork.AddresseeAddr4 = stockSlip.AddresseeAddr4;			// 納品先住所4(アパート名称)
			stockSlipWork.AddresseeTelNo = stockSlip.AddresseeTelNo;			// 納品先電話番号
			stockSlipWork.AddresseeFaxNo = stockSlip.AddresseeFaxNo;			// 納品先FAX番号
			stockSlipWork.DirectSendingCd = stockSlip.DirectSendingCd;			// 直送区分

			#endregion


            // 補正
            // 仕入担当者名称
            if (stockSlipWork.StockAgentName.Length > 16)
            {
                stockSlipWork.StockAgentName = stockSlip.StockAgentName.Substring(0, 16);
            }
            // 仕入入力者名称
            if (stockSlipWork.StockInputName.Length > 16)
            {
                stockSlipWork.StockInputName = stockSlip.StockInputName.Substring(0, 16);
            }

			return stockSlipWork;
		}
		/// <summary>
		/// UIData→PramData移項処理
		/// </summary>
		/// <param name="stockDetail">仕入明細データオブジェクト</param>
		/// <returns>仕入明細データワークオブジェクト</returns>
		public static StockDetailWork ParamDataFromUIData( StockDetail stockDetail )
		{
			StockDetailWork stockDetailWork = new StockDetailWork();

			#region ●項目セット

            stockDetailWork.CreateDateTime = stockDetail.CreateDateTime;                // 作成日時
            stockDetailWork.UpdateDateTime = stockDetail.UpdateDateTime;                // 更新日時
            stockDetailWork.EnterpriseCode = stockDetail.EnterpriseCode;                // 企業コード
            stockDetailWork.FileHeaderGuid = stockDetail.FileHeaderGuid;                // GUID
            stockDetailWork.UpdEmployeeCode = stockDetail.UpdEmployeeCode;              // 更新従業員コード
            stockDetailWork.UpdAssemblyId1 = stockDetail.UpdAssemblyId1;                // 更新アセンブリID1
            stockDetailWork.UpdAssemblyId2 = stockDetail.UpdAssemblyId2;                // 更新アセンブリID2
            stockDetailWork.LogicalDeleteCode = stockDetail.LogicalDeleteCode;          // 論理削除区分
            stockDetailWork.AcceptAnOrderNo = stockDetail.AcceptAnOrderNo;              // 受注番号
            stockDetailWork.SupplierFormal = stockDetail.SupplierFormal;                // 仕入形式
            stockDetailWork.SupplierSlipNo = stockDetail.SupplierSlipNo;                // 仕入伝票番号
            stockDetailWork.StockRowNo = stockDetail.StockRowNo;                        // 仕入行番号
            stockDetailWork.SectionCode = stockDetail.SectionCode;                      // 拠点コード
            stockDetailWork.SubSectionCode = stockDetail.SubSectionCode;                // 部門コード
            stockDetailWork.CommonSeqNo = stockDetail.CommonSeqNo;                      // 共通通番
            stockDetailWork.StockSlipDtlNum = stockDetail.StockSlipDtlNum;              // 仕入明細通番
            stockDetailWork.SupplierFormalSrc = stockDetail.SupplierFormalSrc;          // 仕入形式（元）
            stockDetailWork.StockSlipDtlNumSrc = stockDetail.StockSlipDtlNumSrc;        // 仕入明細通番（元）
            stockDetailWork.AcptAnOdrStatusSync = stockDetail.AcptAnOdrStatusSync;      // 受注ステータス（同時）
            stockDetailWork.SalesSlipDtlNumSync = stockDetail.SalesSlipDtlNumSync;      // 売上明細通番（同時）
            stockDetailWork.StockSlipCdDtl = stockDetail.StockSlipCdDtl;                // 仕入伝票区分（明細）
            stockDetailWork.StockInputCode = stockDetail.StockInputCode;                // 仕入入力者コード
            stockDetailWork.StockInputName = stockDetail.StockInputName;                // 仕入入力者名称
            stockDetailWork.StockAgentCode = stockDetail.StockAgentCode;                // 仕入担当者コード
            stockDetailWork.StockAgentName = stockDetail.StockAgentName;                // 仕入担当者名称
            stockDetailWork.GoodsKindCode = stockDetail.GoodsKindCode;                  // 商品属性
            stockDetailWork.GoodsMakerCd = stockDetail.GoodsMakerCd;                    // 商品メーカーコード
            stockDetailWork.MakerName = stockDetail.MakerName;                          // メーカー名称
            stockDetailWork.MakerKanaName = stockDetail.MakerKanaName;                  // メーカーカナ名称
            stockDetailWork.CmpltMakerKanaName = stockDetail.CmpltMakerKanaName;        // メーカーカナ名称（一式）
            stockDetailWork.GoodsNo = stockDetail.GoodsNo;                              // 商品番号
            stockDetailWork.GoodsName = stockDetail.GoodsName;                          // 商品名称
            stockDetailWork.GoodsNameKana = stockDetail.GoodsNameKana;                  // 商品名称カナ
            stockDetailWork.GoodsLGroup = stockDetail.GoodsLGroup;                      // 商品大分類コード
            stockDetailWork.GoodsLGroupName = stockDetail.GoodsLGroupName;              // 商品大分類名称
            stockDetailWork.GoodsMGroup = stockDetail.GoodsMGroup;                      // 商品中分類コード
            stockDetailWork.GoodsMGroupName = stockDetail.GoodsMGroupName;              // 商品中分類名称
            stockDetailWork.BLGroupCode = stockDetail.BLGroupCode;                      // BLグループコード
            stockDetailWork.BLGroupName = stockDetail.BLGroupName;                      // BLグループコード名称
            stockDetailWork.BLGoodsCode = stockDetail.BLGoodsCode;                      // BL商品コード
            stockDetailWork.BLGoodsFullName = stockDetail.BLGoodsFullName;              // BL商品コード名称（全角）
            stockDetailWork.EnterpriseGanreCode = stockDetail.EnterpriseGanreCode;      // 自社分類コード
            stockDetailWork.EnterpriseGanreName = stockDetail.EnterpriseGanreName;      // 自社分類名称
            stockDetailWork.WarehouseCode = stockDetail.WarehouseCode;                  // 倉庫コード
            stockDetailWork.WarehouseName = stockDetail.WarehouseName;                  // 倉庫名称
            stockDetailWork.WarehouseShelfNo = stockDetail.WarehouseShelfNo;            // 倉庫棚番
            stockDetailWork.StockOrderDivCd = stockDetail.StockOrderDivCd;              // 仕入在庫取寄せ区分
            stockDetailWork.OpenPriceDiv = stockDetail.OpenPriceDiv;                    // オープン価格区分
            stockDetailWork.GoodsRateRank = stockDetail.GoodsRateRank;                  // 商品掛率ランク
            stockDetailWork.CustRateGrpCode = stockDetail.CustRateGrpCode;              // 得意先掛率グループコード
            stockDetailWork.SuppRateGrpCode = stockDetail.SuppRateGrpCode;              // 仕入先掛率グループコード
            stockDetailWork.ListPriceTaxExcFl = stockDetail.ListPriceTaxExcFl;          // 定価（税抜，浮動）
            stockDetailWork.ListPriceTaxIncFl = stockDetail.ListPriceTaxIncFl;          // 定価（税込，浮動）
            stockDetailWork.StockRate = stockDetail.StockRate;                          // 仕入率
            stockDetailWork.RateSectStckUnPrc = stockDetail.RateSectStckUnPrc;          // 掛率設定拠点（仕入単価）
            stockDetailWork.RateDivStckUnPrc = stockDetail.RateDivStckUnPrc;            // 掛率設定区分（仕入単価）
            stockDetailWork.UnPrcCalcCdStckUnPrc = stockDetail.UnPrcCalcCdStckUnPrc;    // 単価算出区分（仕入単価）
            stockDetailWork.PriceCdStckUnPrc = stockDetail.PriceCdStckUnPrc;            // 価格区分（仕入単価）
            stockDetailWork.StdUnPrcStckUnPrc = stockDetail.StdUnPrcStckUnPrc;          // 基準単価（仕入単価）
            stockDetailWork.FracProcUnitStcUnPrc = stockDetail.FracProcUnitStcUnPrc;    // 端数処理単位（仕入単価）
            stockDetailWork.FracProcStckUnPrc = stockDetail.FracProcStckUnPrc;          // 端数処理（仕入単価）
            stockDetailWork.StockUnitPriceFl = stockDetail.StockUnitPriceFl;            // 仕入単価（税抜，浮動）
            stockDetailWork.StockUnitTaxPriceFl = stockDetail.StockUnitTaxPriceFl;      // 仕入単価（税込，浮動）
            stockDetailWork.StockUnitChngDiv = stockDetail.StockUnitChngDiv;            // 仕入単価変更区分
            stockDetailWork.BfStockUnitPriceFl = stockDetail.BfStockUnitPriceFl;        // 変更前仕入単価（浮動）
            stockDetailWork.BfListPrice = stockDetail.BfListPrice;                      // 変更前定価
            stockDetailWork.RateBLGoodsCode = stockDetail.RateBLGoodsCode;              // BL商品コード（掛率）
            stockDetailWork.RateBLGoodsName = stockDetail.RateBLGoodsName;              // BL商品コード名称（掛率）
            stockDetailWork.RateGoodsRateGrpCd = stockDetail.RateGoodsRateGrpCd;        // 商品掛率グループコード（掛率）
            stockDetailWork.RateGoodsRateGrpNm = stockDetail.RateGoodsRateGrpNm;        // 商品掛率グループ名称（掛率）
            stockDetailWork.RateBLGroupCode = stockDetail.RateBLGroupCode;              // BLグループコード（掛率）
            stockDetailWork.RateBLGroupName = stockDetail.RateBLGroupName;              // BLグループ名称（掛率）
            stockDetailWork.StockCount = stockDetail.StockCount;                        // 仕入数
            stockDetailWork.OrderCnt = stockDetail.OrderCnt;                            // 発注数量
            stockDetailWork.OrderAdjustCnt = stockDetail.OrderAdjustCnt;                // 発注調整数
            stockDetailWork.OrderRemainCnt = stockDetail.OrderRemainCnt;                // 発注残数
            stockDetailWork.RemainCntUpdDate = stockDetail.RemainCntUpdDate;            // 残数更新日
            stockDetailWork.StockPriceTaxExc = stockDetail.StockPriceTaxExc;            // 仕入金額（税抜き）
            stockDetailWork.StockPriceTaxInc = stockDetail.StockPriceTaxInc;            // 仕入金額（税込み）
            stockDetailWork.StockGoodsCd = stockDetail.StockGoodsCd;                    // 仕入商品区分
            stockDetailWork.StockPriceConsTax = stockDetail.StockPriceConsTax;          // 仕入金額消費税額
            stockDetailWork.TaxationCode = stockDetail.TaxationCode;                    // 課税区分
            stockDetailWork.StockDtiSlipNote1 = stockDetail.StockDtiSlipNote1;          // 仕入伝票明細備考1
            stockDetailWork.SalesCustomerCode = stockDetail.SalesCustomerCode;          // 販売先コード
            stockDetailWork.SalesCustomerSnm = stockDetail.SalesCustomerSnm;            // 販売先略称
            stockDetailWork.SlipMemo1 = stockDetail.SlipMemo1;                          // 伝票メモ１
            stockDetailWork.SlipMemo2 = stockDetail.SlipMemo2;                          // 伝票メモ２
            stockDetailWork.SlipMemo3 = stockDetail.SlipMemo3;                          // 伝票メモ３
            stockDetailWork.InsideMemo1 = stockDetail.InsideMemo1;                      // 社内メモ１
            stockDetailWork.InsideMemo2 = stockDetail.InsideMemo2;                      // 社内メモ２
            stockDetailWork.InsideMemo3 = stockDetail.InsideMemo3;                      // 社内メモ３
            stockDetailWork.SupplierCd = stockDetail.SupplierCd;                        // 仕入先コード
            stockDetailWork.SupplierSnm = stockDetail.SupplierSnm;                      // 仕入先略称
            stockDetailWork.AddresseeCode = stockDetail.AddresseeCode;                  // 納品先コード
            stockDetailWork.AddresseeName = stockDetail.AddresseeName;                  // 納品先名称
            stockDetailWork.DirectSendingCd = stockDetail.DirectSendingCd;              // 直送区分
            stockDetailWork.OrderNumber = stockDetail.OrderNumber;                      // 発注番号
            stockDetailWork.WayToOrder = stockDetail.WayToOrder;                        // 注文方法
            stockDetailWork.DeliGdsCmpltDueDate = stockDetail.DeliGdsCmpltDueDate;      // 納品完了予定日
            stockDetailWork.ExpectDeliveryDate = stockDetail.ExpectDeliveryDate;        // 希望納期
            stockDetailWork.OrderDataCreateDiv = stockDetail.OrderDataCreateDiv;        // 発注データ作成区分
            stockDetailWork.OrderDataCreateDate = stockDetail.OrderDataCreateDate;      // 発注データ作成日
            stockDetailWork.OrderFormIssuedDiv = stockDetail.OrderFormIssuedDiv;        // 発注書発行済区分


			#endregion

            stockDetailWork.DtlRelationGuid = stockDetail.DtlRelationGuid;				// 明細関連付けGUID

            // 補正
            // 仕入担当者名称
            if (stockDetailWork.StockAgentName.Length > 16)
            {
                stockDetailWork.StockAgentName = stockDetailWork.StockAgentName.Substring(0, 16);
            }
            // 仕入入力者名称
            if (stockDetailWork.StockInputName.Length > 16)
            {
                stockDetailWork.StockInputName = stockDetailWork.StockInputName.Substring(0, 16);
            }

			return stockDetailWork;
		}


		/// <summary>
		/// UIData→PramData移項処理
		/// </summary>
		/// <param name="salesTemp">売上データ(仕入同時計上)オブジェクト</param>
		/// <returns>売上データ(仕入同時計上)ワークオブジェクト</returns>
		public static SalesTempWork ParamDataFromUIData( SalesTemp salesTemp )
		{
			SalesTempWork salesTempWork = new SalesTempWork();

			#region ●項目セット

			salesTempWork.CreateDateTime = salesTemp.CreateDateTime;
			salesTempWork.UpdateDateTime = salesTemp.UpdateDateTime;
			salesTempWork.EnterpriseCode = salesTemp.EnterpriseCode;
			salesTempWork.FileHeaderGuid = salesTemp.FileHeaderGuid;
			salesTempWork.UpdEmployeeCode = salesTemp.UpdEmployeeCode;
			salesTempWork.UpdAssemblyId1 = salesTemp.UpdAssemblyId1;
			salesTempWork.UpdAssemblyId2 = salesTemp.UpdAssemblyId2;
			salesTempWork.LogicalDeleteCode = salesTemp.LogicalDeleteCode;
			salesTempWork.AcptAnOdrStatus = salesTemp.AcptAnOdrStatus;
			salesTempWork.SectionCode = salesTemp.SectionCode;
			salesTempWork.SubSectionCode = salesTemp.SubSectionCode;
			salesTempWork.MinSectionCode = salesTemp.MinSectionCode;
			salesTempWork.DebitNoteDiv = salesTemp.DebitNoteDiv;
			salesTempWork.DebitNLnkAcptAnOdr = salesTemp.DebitNLnkAcptAnOdr;
			salesTempWork.SalesSlipCd = salesTemp.SalesSlipCd;
			salesTempWork.AccRecDivCd = salesTemp.AccRecDivCd;
			salesTempWork.SalesInpSecCd = salesTemp.SalesInpSecCd;
			salesTempWork.DemandAddUpSecCd = salesTemp.DemandAddUpSecCd;
			salesTempWork.ResultsAddUpSecCd = salesTemp.ResultsAddUpSecCd;
			salesTempWork.UpdateSecCd = salesTemp.UpdateSecCd;
			salesTempWork.SearchSlipDate = salesTemp.SearchSlipDate;
			salesTempWork.ShipmentDay = salesTemp.ShipmentDay;
			salesTempWork.SalesDate = salesTemp.SalesDate;
			salesTempWork.AddUpADate = salesTemp.AddUpADate;
			salesTempWork.DelayPaymentDiv = salesTemp.DelayPaymentDiv;
			salesTempWork.ClaimCode = salesTemp.ClaimCode;
			salesTempWork.ClaimSnm = salesTemp.ClaimSnm;
			salesTempWork.CustomerCode = salesTemp.CustomerCode;
			salesTempWork.CustomerName = salesTemp.CustomerName;
			salesTempWork.CustomerName2 = salesTemp.CustomerName2;
			salesTempWork.CustomerSnm = salesTemp.CustomerSnm;
			salesTempWork.HonorificTitle = salesTemp.HonorificTitle;
			salesTempWork.OutputNameCode = salesTemp.OutputNameCode;
			salesTempWork.BusinessTypeCode = salesTemp.BusinessTypeCode;
			salesTempWork.BusinessTypeName = salesTemp.BusinessTypeName;
			salesTempWork.SalesAreaCode = salesTemp.SalesAreaCode;
			salesTempWork.SalesAreaName = salesTemp.SalesAreaName;
			salesTempWork.SalesInputCode = salesTemp.SalesInputCode;
			salesTempWork.SalesInputName = salesTemp.SalesInputName;
			salesTempWork.FrontEmployeeCd = salesTemp.FrontEmployeeCd;
			salesTempWork.FrontEmployeeNm = salesTemp.FrontEmployeeNm;
			salesTempWork.SalesEmployeeCd = salesTemp.SalesEmployeeCd;
			salesTempWork.SalesEmployeeNm = salesTemp.SalesEmployeeNm;
			salesTempWork.ConsTaxLayMethod = salesTemp.ConsTaxLayMethod;
			salesTempWork.ConsTaxRate = salesTemp.ConsTaxRate;
			salesTempWork.FractionProcCd = salesTemp.FractionProcCd;
			salesTempWork.AutoDepositCd = salesTemp.AutoDepositCd;
			salesTempWork.AutoDepoSlipNum = salesTemp.AutoDepoSlipNum;
			salesTempWork.SlipAddressDiv = salesTemp.SlipAddressDiv;
			salesTempWork.AddresseeCode = salesTemp.AddresseeCode;
			salesTempWork.AddresseeName = salesTemp.AddresseeName;
			salesTempWork.AddresseeName2 = salesTemp.AddresseeName2;
			salesTempWork.AddresseePostNo = salesTemp.AddresseePostNo;
			salesTempWork.AddresseeAddr1 = salesTemp.AddresseeAddr1;
			salesTempWork.AddresseeAddr2 = salesTemp.AddresseeAddr2;
			salesTempWork.AddresseeAddr3 = salesTemp.AddresseeAddr3;
			salesTempWork.AddresseeAddr4 = salesTemp.AddresseeAddr4;
			salesTempWork.AddresseeTelNo = salesTemp.AddresseeTelNo;
			salesTempWork.AddresseeFaxNo = salesTemp.AddresseeFaxNo;
			salesTempWork.PartySaleSlipNum = salesTemp.PartySaleSlipNum;
			salesTempWork.SlipNote = salesTemp.SlipNote;
			salesTempWork.SlipNote2 = salesTemp.SlipNote2;
			salesTempWork.RetGoodsReasonDiv = salesTemp.RetGoodsReasonDiv;
			salesTempWork.RetGoodsReason = salesTemp.RetGoodsReason;
			salesTempWork.DetailRowCount = salesTemp.DetailRowCount;
			salesTempWork.DeliveredGoodsDiv = salesTemp.DeliveredGoodsDiv;
			salesTempWork.DeliveredGoodsDivNm = salesTemp.DeliveredGoodsDivNm;
			salesTempWork.ReconcileFlag = salesTemp.ReconcileFlag;
			salesTempWork.SlipPrtSetPaperId = salesTemp.SlipPrtSetPaperId;
			salesTempWork.CompleteCd = salesTemp.CompleteCd;
			salesTempWork.ClaimType = salesTemp.ClaimType;
			salesTempWork.SalesPriceFracProcCd = salesTemp.SalesPriceFracProcCd;
			salesTempWork.ListPricePrintDiv = salesTemp.ListPricePrintDiv;
			salesTempWork.EraNameDispCd1 = salesTemp.EraNameDispCd1;
			salesTempWork.AcceptAnOrderNo = salesTemp.AcceptAnOrderNo;
			salesTempWork.CommonSeqNo = salesTemp.CommonSeqNo;
			salesTempWork.SalesSlipDtlNum = salesTemp.SalesSlipDtlNum;
			salesTempWork.AcptAnOdrStatusSrc = salesTemp.AcptAnOdrStatusSrc;
			salesTempWork.SalesSlipDtlNumSrc = salesTemp.SalesSlipDtlNumSrc;
			salesTempWork.SupplierFormalSync = salesTemp.SupplierFormalSync;
			salesTempWork.StockSlipDtlNumSync = salesTemp.StockSlipDtlNumSync;
			salesTempWork.SalesSlipCdDtl = salesTemp.SalesSlipCdDtl;
			salesTempWork.OrderNumber = salesTemp.OrderNumber;
			salesTempWork.StockMngExistCd = salesTemp.StockMngExistCd;
			salesTempWork.DeliGdsCmpltDueDate = salesTemp.DeliGdsCmpltDueDate;
			salesTempWork.GoodsKindCode = salesTemp.GoodsKindCode;
			salesTempWork.GoodsMakerCd = salesTemp.GoodsMakerCd;
			salesTempWork.MakerName = salesTemp.MakerName;
			salesTempWork.GoodsNo = salesTemp.GoodsNo;
			salesTempWork.GoodsName = salesTemp.GoodsName;
			salesTempWork.GoodsShortName = salesTemp.GoodsShortName;
			salesTempWork.GoodsSetDivCd = salesTemp.GoodsSetDivCd;
			salesTempWork.LargeGoodsGanreCode = salesTemp.LargeGoodsGanreCode;
			salesTempWork.LargeGoodsGanreName = salesTemp.LargeGoodsGanreName;
			salesTempWork.MediumGoodsGanreCode = salesTemp.MediumGoodsGanreCode;
			salesTempWork.MediumGoodsGanreName = salesTemp.MediumGoodsGanreName;
			salesTempWork.DetailGoodsGanreCode = salesTemp.DetailGoodsGanreCode;
			salesTempWork.DetailGoodsGanreName = salesTemp.DetailGoodsGanreName;
			salesTempWork.BLGoodsCode = salesTemp.BLGoodsCode;
			salesTempWork.BLGoodsFullName = salesTemp.BLGoodsFullName;
			salesTempWork.EnterpriseGanreCode = salesTemp.EnterpriseGanreCode;
			salesTempWork.EnterpriseGanreName = salesTemp.EnterpriseGanreName;
			salesTempWork.WarehouseCode = salesTemp.WarehouseCode;
			salesTempWork.WarehouseName = salesTemp.WarehouseName;
			salesTempWork.WarehouseShelfNo = salesTemp.WarehouseShelfNo;
			salesTempWork.SalesOrderDivCd = salesTemp.SalesOrderDivCd;
			salesTempWork.OpenPriceDiv = salesTemp.OpenPriceDiv;
			salesTempWork.UnitCode = salesTemp.UnitCode;
			salesTempWork.UnitName = salesTemp.UnitName;
			salesTempWork.GoodsRateRank = salesTemp.GoodsRateRank;
			salesTempWork.CustRateGrpCode = salesTemp.CustRateGrpCode;
			salesTempWork.SuppRateGrpCode = salesTemp.SuppRateGrpCode;
			salesTempWork.ListPriceRate = salesTemp.ListPriceRate;
			salesTempWork.RateSectPriceUnPrc = salesTemp.RateSectPriceUnPrc;
			salesTempWork.RateDivLPrice = salesTemp.RateDivLPrice;
			salesTempWork.UnPrcCalcCdLPrice = salesTemp.UnPrcCalcCdLPrice;
			salesTempWork.PriceCdLPrice = salesTemp.PriceCdLPrice;
			salesTempWork.StdUnPrcLPrice = salesTemp.StdUnPrcLPrice;
			salesTempWork.FracProcUnitLPrice = salesTemp.FracProcUnitLPrice;
			salesTempWork.FracProcLPrice = salesTemp.FracProcLPrice;
			salesTempWork.ListPriceTaxIncFl = salesTemp.ListPriceTaxIncFl;
			salesTempWork.ListPriceTaxExcFl = salesTemp.ListPriceTaxExcFl;
			salesTempWork.ListPriceChngCd = salesTemp.ListPriceChngCd;
			salesTempWork.SalesRate = salesTemp.SalesRate;
			salesTempWork.RateSectSalUnPrc = salesTemp.RateSectSalUnPrc;
			salesTempWork.RateDivSalUnPrc = salesTemp.RateDivSalUnPrc;
			salesTempWork.UnPrcCalcCdSalUnPrc = salesTemp.UnPrcCalcCdSalUnPrc;
			salesTempWork.PriceCdSalUnPrc = salesTemp.PriceCdSalUnPrc;
			salesTempWork.StdUnPrcSalUnPrc = salesTemp.StdUnPrcSalUnPrc;
			salesTempWork.FracProcUnitSalUnPrc = salesTemp.FracProcUnitSalUnPrc;
			salesTempWork.FracProcSalUnPrc = salesTemp.FracProcSalUnPrc;
			salesTempWork.SalesUnPrcTaxIncFl = salesTemp.SalesUnPrcTaxIncFl;
			salesTempWork.SalesUnPrcTaxExcFl = salesTemp.SalesUnPrcTaxExcFl;
			salesTempWork.SalesUnPrcChngCd = salesTemp.SalesUnPrcChngCd;
			salesTempWork.CostRate = salesTemp.CostRate;
			salesTempWork.RateSectCstUnPrc = salesTemp.RateSectCstUnPrc;
			salesTempWork.RateDivUnCst = salesTemp.RateDivUnCst;
			salesTempWork.UnPrcCalcCdUnCst = salesTemp.UnPrcCalcCdUnCst;
			salesTempWork.PriceCdUnCst = salesTemp.PriceCdUnCst;
			salesTempWork.StdUnPrcUnCst = salesTemp.StdUnPrcUnCst;
			salesTempWork.FracProcUnitUnCst = salesTemp.FracProcUnitUnCst;
			salesTempWork.FracProcUnCst = salesTemp.FracProcUnCst;
			salesTempWork.SalesUnitCost = salesTemp.SalesUnitCost;
			salesTempWork.SalesUnitCostChngDiv = salesTemp.SalesUnitCostChngDiv;
			salesTempWork.RateBLGoodsCode = salesTemp.RateBLGoodsCode;
			salesTempWork.RateBLGoodsName = salesTemp.RateBLGoodsName;
			salesTempWork.BargainCd = salesTemp.BargainCd;
			salesTempWork.BargainNm = salesTemp.BargainNm;
			salesTempWork.ShipmentCnt = salesTemp.ShipmentCnt;
			salesTempWork.SalesMoneyTaxInc = salesTemp.SalesMoneyTaxInc;
			salesTempWork.SalesMoneyTaxExc = salesTemp.SalesMoneyTaxExc;
			salesTempWork.Cost = salesTemp.Cost;
			salesTempWork.GrsProfitChkDiv = salesTemp.GrsProfitChkDiv;
			salesTempWork.SalesGoodsCd = salesTemp.SalesGoodsCd;
			salesTempWork.SalsePriceConsTax = salesTemp.SalsePriceConsTax;
			salesTempWork.TaxationDivCd = salesTemp.TaxationDivCd;
			salesTempWork.PartySlipNumDtl = salesTemp.PartySlipNumDtl;
			salesTempWork.DtlNote = salesTemp.DtlNote;
			salesTempWork.SupplierCd = salesTemp.SupplierCd;
			salesTempWork.SupplierSnm = salesTemp.SupplierSnm;
			salesTempWork.SlipMemo1 = salesTemp.SlipMemo1;
			salesTempWork.SlipMemo2 = salesTemp.SlipMemo2;
			salesTempWork.SlipMemo3 = salesTemp.SlipMemo3;
			salesTempWork.SlipMemo4 = salesTemp.SlipMemo4;
			salesTempWork.SlipMemo5 = salesTemp.SlipMemo5;
			salesTempWork.SlipMemo6 = salesTemp.SlipMemo6;
			salesTempWork.InsideMemo1 = salesTemp.InsideMemo1;
			salesTempWork.InsideMemo2 = salesTemp.InsideMemo2;
			salesTempWork.InsideMemo3 = salesTemp.InsideMemo3;
			salesTempWork.InsideMemo4 = salesTemp.InsideMemo4;
			salesTempWork.InsideMemo5 = salesTemp.InsideMemo5;
			salesTempWork.InsideMemo6 = salesTemp.InsideMemo6;
			salesTempWork.BfListPrice = salesTemp.BfListPrice;
			salesTempWork.BfSalesUnitPrice = salesTemp.BfSalesUnitPrice;
			salesTempWork.BfUnitCost = salesTemp.BfUnitCost;
			salesTempWork.PrtGoodsNo = salesTemp.PrtGoodsNo;
			salesTempWork.PrtGoodsName = salesTemp.PrtGoodsName;
			salesTempWork.PrtGoodsMakerCd = salesTemp.PrtGoodsMakerCd;
			salesTempWork.PrtGoodsMakerNm = salesTemp.PrtGoodsMakerNm;
			//salesTempWork.SupplierSlipCd = salesTempRow.SupplierSlipCd;
			//salesTempWork.TotalAmountDispWayCd = salesTempRow.TotalAmountDispWayCd;
			//salesTempWork.TtlAmntDispRateApy = salesTempRow.TtlAmntDispRateApy;
			//salesTempWork.ConfirmedDiv = salesTempRow.ConfirmedDiv;
			//salesTempWork.NTimeCalcStDate = salesTempRow.NTimeCalcStDate;
			//salesTempWork.TotalDay = salesTempRow.TotalDay;
			salesTempWork.DtlRelationGuid = salesTemp.DtlRelationGuid;

			#endregion

			return salesTempWork;
		}

		/// <summary>
		/// 項目コピー処理
		/// </summary>
		/// <param name="source">コピー元仕入データオブジェクト</param>
		/// <param name="target">コピー先仕入データオブジェクト</param>
		public static void CopyItem( StockSlip source, ref StockSlip target )
		{
			#region ●項目セット

			//target.CreateDateTime = source.CreateDateTime;				// 作成日時
			//target.UpdateDateTime = source.UpdateDateTime;				// 更新日時
			//target.EnterpriseCode = source.EnterpriseCode;				// 企業コード
			//target.FileHeaderGuid = source.FileHeaderGuid;				// GUID
			//target.UpdEmployeeCode = source.UpdEmployeeCode;			// 更新従業員コード
			//target.UpdAssemblyId1 = source.UpdAssemblyId1;				// 更新アセンブリID1
			//target.UpdAssemblyId2 = source.UpdAssemblyId2;				// 更新アセンブリID2
			//target.LogicalDeleteCode = source.LogicalDeleteCode;		// 論理削除区分
			target.SupplierFormal = source.SupplierFormal;				// 仕入形式
			target.SupplierSlipNo = source.SupplierSlipNo;				// 仕入伝票番号
			target.SectionCode = source.SectionCode;					// 拠点コード
			target.SubSectionCode = source.SubSectionCode;				// 部門コード
			target.DebitNoteDiv = source.DebitNoteDiv;					// 赤伝区分
			target.DebitNLnkSuppSlipNo = source.DebitNLnkSuppSlipNo;	// 赤黒連結仕入伝票番号
			target.SupplierSlipCd = source.SupplierSlipCd;				// 仕入伝票区分
			target.StockGoodsCd = source.StockGoodsCd;					// 仕入商品区分
			target.AccPayDivCd = source.AccPayDivCd;					// 買掛区分
			target.StockSectionCd = source.StockSectionCd;				// 仕入拠点コード
			target.StockAddUpSectionCd = source.StockAddUpSectionCd;	// 仕入計上拠点コード
			target.StockSlipUpdateCd = source.StockSlipUpdateCd;		// 仕入伝票更新区分
			target.InputDay = source.InputDay;							// 入力日
			target.ArrivalGoodsDay = source.ArrivalGoodsDay;			// 入荷日
			target.StockDate = source.StockDate;						// 仕入日
			target.StockAddUpADate = source.StockAddUpADate;			// 仕入計上日付
			target.DelayPaymentDiv = source.DelayPaymentDiv;			// 来勘区分
			target.PayeeCode = source.PayeeCode;						// 支払先コード
			target.PayeeSnm = source.PayeeSnm;							// 支払先略称
			target.SupplierCd = source.SupplierCd;						// 仕入先コード
			target.SupplierNm1 = source.SupplierNm1;					// 仕入先名1
			target.SupplierNm2 = source.SupplierNm2;					// 仕入先名2
			target.SupplierSnm = source.SupplierSnm;					// 仕入先略称
			target.BusinessTypeCode = source.BusinessTypeCode;			// 業種コード
			target.BusinessTypeName = source.BusinessTypeName;			// 業種名称
			target.SalesAreaCode = source.SalesAreaCode;				// 販売エリアコード
			target.SalesAreaName = source.SalesAreaName;				// 販売エリア名称
			target.StockInputCode = source.StockInputCode;				// 仕入入力者コード
			target.StockInputName = source.StockInputName;				// 仕入入力者名称
			target.StockAgentCode = source.StockAgentCode;				// 仕入担当者コード
			target.StockAgentName = source.StockAgentName;				// 仕入担当者名称
			target.SuppTtlAmntDspWayCd = source.SuppTtlAmntDspWayCd;	// 仕入先総額表示方法区分
			target.TtlAmntDispRateApy = source.TtlAmntDispRateApy;		// 総額表示掛率適用区分
			target.StockTotalPrice = source.StockTotalPrice;			// 仕入金額合計
			target.StockSubttlPrice = source.StockSubttlPrice;			// 仕入金額小計
			target.StockTtlPricTaxInc = source.StockTtlPricTaxInc;		// 仕入金額計（税込み）
			target.StockTtlPricTaxExc = source.StockTtlPricTaxExc;		// 仕入金額計（税抜き）
			target.StockNetPrice = source.StockNetPrice;				// 仕入正価金額
			target.StockPriceConsTax = source.StockPriceConsTax;		// 仕入金額消費税額
			target.TtlItdedStcOutTax = source.TtlItdedStcOutTax;		// 仕入外税対象額合計
			target.TtlItdedStcInTax = source.TtlItdedStcInTax;			// 仕入内税対象額合計
			target.TtlItdedStcTaxFree = source.TtlItdedStcTaxFree;		// 仕入非課税対象額合計
			target.StockOutTax = source.StockOutTax;					// 仕入金額消費税額（外税）
			target.StckPrcConsTaxInclu = source.StckPrcConsTaxInclu;	// 仕入金額消費税額（内税）
			target.StckDisTtlTaxExc = source.StckDisTtlTaxExc;			// 仕入値引金額計（税抜き）
			target.ItdedStockDisOutTax = source.ItdedStockDisOutTax;	// 仕入値引外税対象額合計
			target.ItdedStockDisInTax = source.ItdedStockDisInTax;		// 仕入値引内税対象額合計
			target.ItdedStockDisTaxFre = source.ItdedStockDisTaxFre;	// 仕入値引非課税対象額合計
			target.StockDisOutTax = source.StockDisOutTax;				// 仕入値引消費税額（外税）
			target.StckDisTtlTaxInclu = source.StckDisTtlTaxInclu;		// 仕入値引消費税額（内税）
			target.TaxAdjust = source.TaxAdjust;						// 消費税調整額
			target.BalanceAdjust = source.BalanceAdjust;				// 残高調整額
			target.SuppCTaxLayCd = source.SuppCTaxLayCd;				// 仕入先消費税転嫁方式コード
			target.SupplierConsTaxRate = source.SupplierConsTaxRate;	// 仕入先消費税税率
			target.AccPayConsTax = source.AccPayConsTax;				// 買掛消費税
			target.StockFractionProcCd = source.StockFractionProcCd;	// 仕入端数処理区分
			target.AutoPayment = source.AutoPayment;					// 自動支払区分
			target.AutoPaySlipNum = source.AutoPaySlipNum;				// 自動支払伝票番号
			target.RetGoodsReasonDiv = source.RetGoodsReasonDiv;		// 返品理由コード
			target.RetGoodsReason = source.RetGoodsReason;				// 返品理由
			target.PartySaleSlipNum = source.PartySaleSlipNum;			// 相手先伝票番号
			target.SupplierSlipNote1 = source.SupplierSlipNote1;		// 仕入伝票備考1
			target.SupplierSlipNote2 = source.SupplierSlipNote2;		// 仕入伝票備考2
			target.DetailRowCount = source.DetailRowCount;				// 明細行数
			target.EdiSendDate = source.EdiSendDate;					// ＥＤＩ送信日
			target.EdiTakeInDate = source.EdiTakeInDate;				// ＥＤＩ取込日
			target.UoeRemark1 = source.UoeRemark1;						// ＵＯＥリマーク１
			target.UoeRemark2 = source.UoeRemark2;						// ＵＯＥリマーク２
			target.SlipPrintDivCd = source.SlipPrintDivCd;				// 伝票発行区分
			target.SlipPrintFinishCd = source.SlipPrintFinishCd;		// 伝票発行済区分
			target.StockSlipPrintDate = source.StockSlipPrintDate;		// 仕入伝票発行日
			target.SlipPrtSetPaperId = source.SlipPrtSetPaperId;		// 伝票印刷設定用帳票ID
			target.SlipAddressDiv = source.SlipAddressDiv;				// 伝票住所区分
			target.AddresseeCode = source.AddresseeCode;				// 納品先コード
			target.AddresseeName = source.AddresseeName;				// 納品先名称
			target.AddresseeName2 = source.AddresseeName2;				// 納品先名称2
			target.AddresseePostNo = source.AddresseePostNo;			// 納品先郵便番号
			target.AddresseeAddr1 = source.AddresseeAddr1;				// 納品先住所1(都道府県市区郡・町村・字)
			target.AddresseeAddr3 = source.AddresseeAddr3;				// 納品先住所3(番地)
			target.AddresseeAddr4 = source.AddresseeAddr4;				// 納品先住所4(アパート名称)
			target.AddresseeTelNo = source.AddresseeTelNo;				// 納品先電話番号
			target.AddresseeFaxNo = source.AddresseeFaxNo;				// 納品先FAX番号
			target.DirectSendingCd = source.DirectSendingCd;			// 直送区分
			target.SupplierSlipDisplay = source.SupplierSlipDisplay;	// 仕入伝票区分(画面表示用)
			target.SuppRateGrpCode = source.SuppRateGrpCode;			// 仕入先掛率グループコード
			target.WarehouseCode = source.WarehouseCode;				// 倉庫コード
			target.WarehouseName = source.WarehouseName;				// 倉庫名称
			target.InputMode = source.InputMode;						// 入力モード
			target.PayeeName = source.PayeeName;						// 支払先名称
			target.PayeeName2 = source.PayeeName2;						// 支払先名称2
			target.NTimeCalcStDate = source.NTimeCalcStDate;			// 次回勘定開始日
			target.PaymentTotalDay = source.PaymentTotalDay;			// 支払締日

			#endregion
		}

		/// <summary>
		/// 項目コピー処理
		/// </summary>
		/// <param name="source">コピー元仕入データオブジェクト</param>
		/// <param name="target">コピー先仕入データオブジェクト</param>
		public static void CopyItem( StockDetail source, ref StockDetail target )
		{
			#region ●項目セット

            target.CreateDateTime = source.CreateDateTime;                  // 作成日時
            target.UpdateDateTime = source.UpdateDateTime;                  // 更新日時
            target.EnterpriseCode = source.EnterpriseCode;                  // 企業コード
            target.FileHeaderGuid = source.FileHeaderGuid;                  // GUID
            target.UpdEmployeeCode = source.UpdEmployeeCode;                // 更新従業員コード
            target.UpdAssemblyId1 = source.UpdAssemblyId1;                  // 更新アセンブリID1
            target.UpdAssemblyId2 = source.UpdAssemblyId2;                  // 更新アセンブリID2
            target.LogicalDeleteCode = source.LogicalDeleteCode;            // 論理削除区分
            target.AcceptAnOrderNo = source.AcceptAnOrderNo;                // 受注番号
            target.SupplierFormal = source.SupplierFormal;                  // 仕入形式
            target.SupplierSlipNo = source.SupplierSlipNo;                  // 仕入伝票番号
            target.StockRowNo = source.StockRowNo;                          // 仕入行番号
            target.SectionCode = source.SectionCode;                        // 拠点コード
            target.SubSectionCode = source.SubSectionCode;                  // 部門コード
            target.CommonSeqNo = source.CommonSeqNo;                        // 共通通番
            target.StockSlipDtlNum = source.StockSlipDtlNum;                // 仕入明細通番
            target.SupplierFormalSrc = source.SupplierFormalSrc;            // 仕入形式（元）
            target.StockSlipDtlNumSrc = source.StockSlipDtlNumSrc;          // 仕入明細通番（元）
            target.AcptAnOdrStatusSync = source.AcptAnOdrStatusSync;        // 受注ステータス（同時）
            target.SalesSlipDtlNumSync = source.SalesSlipDtlNumSync;        // 売上明細通番（同時）
            target.StockSlipCdDtl = source.StockSlipCdDtl;                  // 仕入伝票区分（明細）
            target.StockInputCode = source.StockInputCode;                  // 仕入入力者コード
            target.StockInputName = source.StockInputName;                  // 仕入入力者名称
            target.StockAgentCode = source.StockAgentCode;                  // 仕入担当者コード
            target.StockAgentName = source.StockAgentName;                  // 仕入担当者名称
            target.GoodsKindCode = source.GoodsKindCode;                    // 商品属性
            target.GoodsMakerCd = source.GoodsMakerCd;                      // 商品メーカーコード
            target.MakerName = source.MakerName;                            // メーカー名称
            target.MakerKanaName = source.MakerKanaName;                    // メーカーカナ名称
            target.CmpltMakerKanaName = source.CmpltMakerKanaName;          // メーカーカナ名称（一式）
            target.GoodsNo = source.GoodsNo;                                // 商品番号
            target.GoodsName = source.GoodsName;                            // 商品名称
            target.GoodsNameKana = source.GoodsNameKana;                    // 商品名称カナ
            target.GoodsLGroup = source.GoodsLGroup;                        // 商品大分類コード
            target.GoodsLGroupName = source.GoodsLGroupName;                // 商品大分類名称
            target.GoodsMGroup = source.GoodsMGroup;                        // 商品中分類コード
            target.GoodsMGroupName = source.GoodsMGroupName;                // 商品中分類名称
            target.BLGroupCode = source.BLGroupCode;                        // BLグループコード
            target.BLGroupName = source.BLGroupName;                        // BLグループコード名称
            target.BLGoodsCode = source.BLGoodsCode;                        // BL商品コード
            target.BLGoodsFullName = source.BLGoodsFullName;                // BL商品コード名称（全角）
            target.EnterpriseGanreCode = source.EnterpriseGanreCode;        // 自社分類コード
            target.EnterpriseGanreName = source.EnterpriseGanreName;        // 自社分類名称
            target.WarehouseCode = source.WarehouseCode;                    // 倉庫コード
            target.WarehouseName = source.WarehouseName;                    // 倉庫名称
            target.WarehouseShelfNo = source.WarehouseShelfNo;              // 倉庫棚番
            target.StockOrderDivCd = source.StockOrderDivCd;                // 仕入在庫取寄せ区分
            target.OpenPriceDiv = source.OpenPriceDiv;                      // オープン価格区分
            target.GoodsRateRank = source.GoodsRateRank;                    // 商品掛率ランク
            target.CustRateGrpCode = source.CustRateGrpCode;                // 得意先掛率グループコード
            target.SuppRateGrpCode = source.SuppRateGrpCode;                // 仕入先掛率グループコード
            target.ListPriceTaxExcFl = source.ListPriceTaxExcFl;            // 定価（税抜，浮動）
            target.ListPriceTaxIncFl = source.ListPriceTaxIncFl;            // 定価（税込，浮動）
            target.StockRate = source.StockRate;                            // 仕入率
            target.RateSectStckUnPrc = source.RateSectStckUnPrc;            // 掛率設定拠点（仕入単価）
            target.RateDivStckUnPrc = source.RateDivStckUnPrc;              // 掛率設定区分（仕入単価）
            target.UnPrcCalcCdStckUnPrc = source.UnPrcCalcCdStckUnPrc;      // 単価算出区分（仕入単価）
            target.PriceCdStckUnPrc = source.PriceCdStckUnPrc;              // 価格区分（仕入単価）
            target.StdUnPrcStckUnPrc = source.StdUnPrcStckUnPrc;            // 基準単価（仕入単価）
            target.FracProcUnitStcUnPrc = source.FracProcUnitStcUnPrc;      // 端数処理単位（仕入単価）
            target.FracProcStckUnPrc = source.FracProcStckUnPrc;            // 端数処理（仕入単価）
            target.StockUnitPriceFl = source.StockUnitPriceFl;              // 仕入単価（税抜，浮動）
            target.StockUnitTaxPriceFl = source.StockUnitTaxPriceFl;        // 仕入単価（税込，浮動）
            target.StockUnitChngDiv = source.StockUnitChngDiv;              // 仕入単価変更区分
            target.BfStockUnitPriceFl = source.BfStockUnitPriceFl;          // 変更前仕入単価（浮動）
            target.BfListPrice = source.BfListPrice;                        // 変更前定価
            target.RateBLGoodsCode = source.RateBLGoodsCode;                // BL商品コード（掛率）
            target.RateBLGoodsName = source.RateBLGoodsName;                // BL商品コード名称（掛率）
            target.RateGoodsRateGrpCd = source.RateGoodsRateGrpCd;          // 商品掛率グループコード（掛率）
            target.RateGoodsRateGrpNm = source.RateGoodsRateGrpNm;          // 商品掛率グループ名称（掛率）
            target.RateBLGroupCode = source.RateBLGroupCode;                // BLグループコード（掛率）
            target.RateBLGroupName = source.RateBLGroupName;                // BLグループ名称（掛率）
            target.StockCount = source.StockCount;                          // 仕入数
            target.OrderCnt = source.OrderCnt;                              // 発注数量
            target.OrderAdjustCnt = source.OrderAdjustCnt;                  // 発注調整数
            target.OrderRemainCnt = source.OrderRemainCnt;                  // 発注残数
            target.RemainCntUpdDate = source.RemainCntUpdDate;              // 残数更新日
            target.StockPriceTaxExc = source.StockPriceTaxExc;              // 仕入金額（税抜き）
            target.StockPriceTaxInc = source.StockPriceTaxInc;              // 仕入金額（税込み）
            target.StockGoodsCd = source.StockGoodsCd;                      // 仕入商品区分
            target.StockPriceConsTax = source.StockPriceConsTax;            // 仕入金額消費税額
            target.TaxationCode = source.TaxationCode;                      // 課税区分
            target.StockDtiSlipNote1 = source.StockDtiSlipNote1;            // 仕入伝票明細備考1
            target.SalesCustomerCode = source.SalesCustomerCode;            // 販売先コード
            target.SalesCustomerSnm = source.SalesCustomerSnm;              // 販売先略称
            target.SlipMemo1 = source.SlipMemo1;                            // 伝票メモ１
            target.SlipMemo2 = source.SlipMemo2;                            // 伝票メモ２
            target.SlipMemo3 = source.SlipMemo3;                            // 伝票メモ３
            target.InsideMemo1 = source.InsideMemo1;                        // 社内メモ１
            target.InsideMemo2 = source.InsideMemo2;                        // 社内メモ２
            target.InsideMemo3 = source.InsideMemo3;                        // 社内メモ３
            target.SupplierCd = source.SupplierCd;                          // 仕入先コード
            target.SupplierSnm = source.SupplierSnm;                        // 仕入先略称
            target.AddresseeCode = source.AddresseeCode;                    // 納品先コード
            target.AddresseeName = source.AddresseeName;                    // 納品先名称
            target.DirectSendingCd = source.DirectSendingCd;                // 直送区分
            target.OrderNumber = source.OrderNumber;                        // 発注番号
            target.WayToOrder = source.WayToOrder;                          // 注文方法
            target.DeliGdsCmpltDueDate = source.DeliGdsCmpltDueDate;        // 納品完了予定日
            target.ExpectDeliveryDate = source.ExpectDeliveryDate;          // 希望納期
            target.OrderDataCreateDiv = source.OrderDataCreateDiv;          // 発注データ作成区分
            target.OrderDataCreateDate = source.OrderDataCreateDate;        // 発注データ作成日
            target.OrderFormIssuedDiv = source.OrderFormIssuedDiv;          // 発注書発行済区分
            target.DtlRelationGuid = source.DtlRelationGuid;                // 明細関連付けGUID
            target.GoodsOfferDate = source.GoodsOfferDate;                  // 商品提供日付
            target.PriceStartDate = source.PriceStartDate;                  // 価格開始日付
            target.PriceOfferDate = source.PriceOfferDate;                  // 価格提供日付

			#endregion
		}

		/// <summary>
		/// 項目コピー処理
		/// </summary>
		/// <param name="source">コピー元売上データ(仕入同時計上)オブジェクト</param>
		/// <param name="target">コピー先売上データ(仕入同時計上)オブジェクト</param>
		public static void CopyItem( SalesTemp source, ref SalesTemp target )
		{
			#region ●項目コピー

			//target.CreateDateTime = source.CreateDateTime;
			//target.UpdateDateTime = source.UpdateDateTime;
			//target.EnterpriseCode = source.EnterpriseCode;
			//target.FileHeaderGuid = source.FileHeaderGuid;
			//target.UpdEmployeeCode = source.UpdEmployeeCode;
			//target.UpdAssemblyId1 = source.UpdAssemblyId1;
			//target.UpdAssemblyId2 = source.UpdAssemblyId2;
			//target.LogicalDeleteCode = source.LogicalDeleteCode;
			target.AcptAnOdrStatus = source.AcptAnOdrStatus;
			target.SectionCode = source.SectionCode;
			target.SubSectionCode = source.SubSectionCode;
			target.MinSectionCode = source.MinSectionCode;
			target.DebitNoteDiv = source.DebitNoteDiv;
			target.DebitNLnkAcptAnOdr = source.DebitNLnkAcptAnOdr;
			target.SalesSlipCd = source.SalesSlipCd;
			target.AccRecDivCd = source.AccRecDivCd;
			target.SalesInpSecCd = source.SalesInpSecCd;
			target.DemandAddUpSecCd = source.DemandAddUpSecCd;
			target.ResultsAddUpSecCd = source.ResultsAddUpSecCd;
			target.UpdateSecCd = source.UpdateSecCd;
			target.SearchSlipDate = source.SearchSlipDate;
			target.ShipmentDay = source.ShipmentDay;
			target.SalesDate = source.SalesDate;
			target.AddUpADate = source.AddUpADate;
			target.DelayPaymentDiv = source.DelayPaymentDiv;
			target.ClaimCode = source.ClaimCode;
			target.ClaimSnm = source.ClaimSnm;
			target.CustomerCode = source.CustomerCode;
			target.CustomerName = source.CustomerName;
			target.CustomerName2 = source.CustomerName2;
			target.CustomerSnm = source.CustomerSnm;
			target.HonorificTitle = source.HonorificTitle;
			target.OutputNameCode = source.OutputNameCode;
			target.BusinessTypeCode = source.BusinessTypeCode;
			target.BusinessTypeName = source.BusinessTypeName;
			target.SalesAreaCode = source.SalesAreaCode;
			target.SalesAreaName = source.SalesAreaName;
			target.SalesInputCode = source.SalesInputCode;
			target.SalesInputName = source.SalesInputName;
			target.FrontEmployeeCd = source.FrontEmployeeCd;
			target.FrontEmployeeNm = source.FrontEmployeeNm;
			target.SalesEmployeeCd = source.SalesEmployeeCd;
			target.SalesEmployeeNm = source.SalesEmployeeNm;
			target.ConsTaxLayMethod = source.ConsTaxLayMethod;
			target.ConsTaxRate = source.ConsTaxRate;
			target.FractionProcCd = source.FractionProcCd;
			target.AutoDepositCd = source.AutoDepositCd;
			target.AutoDepoSlipNum = source.AutoDepoSlipNum;
			target.SlipAddressDiv = source.SlipAddressDiv;
			target.AddresseeCode = source.AddresseeCode;
			target.AddresseeName = source.AddresseeName;
			target.AddresseeName2 = source.AddresseeName2;
			target.AddresseePostNo = source.AddresseePostNo;
			target.AddresseeAddr1 = source.AddresseeAddr1;
			target.AddresseeAddr2 = source.AddresseeAddr2;
			target.AddresseeAddr3 = source.AddresseeAddr3;
			target.AddresseeAddr4 = source.AddresseeAddr4;
			target.AddresseeTelNo = source.AddresseeTelNo;
			target.AddresseeFaxNo = source.AddresseeFaxNo;
			target.PartySaleSlipNum = source.PartySaleSlipNum;
			target.SlipNote = source.SlipNote;
			target.SlipNote2 = source.SlipNote2;
			target.RetGoodsReasonDiv = source.RetGoodsReasonDiv;
			target.RetGoodsReason = source.RetGoodsReason;
			target.DetailRowCount = source.DetailRowCount;
			target.DeliveredGoodsDiv = source.DeliveredGoodsDiv;
			target.DeliveredGoodsDivNm = source.DeliveredGoodsDivNm;
			target.ReconcileFlag = source.ReconcileFlag;
			target.SlipPrtSetPaperId = source.SlipPrtSetPaperId;
			target.CompleteCd = source.CompleteCd;
			target.ClaimType = source.ClaimType;
			target.SalesPriceFracProcCd = source.SalesPriceFracProcCd;
			target.ListPricePrintDiv = source.ListPricePrintDiv;
			target.EraNameDispCd1 = source.EraNameDispCd1;
			target.AcceptAnOrderNo = source.AcceptAnOrderNo;
			target.CommonSeqNo = source.CommonSeqNo;
			target.SalesSlipDtlNum = source.SalesSlipDtlNum;
			target.AcptAnOdrStatusSrc = source.AcptAnOdrStatusSrc;
			target.SalesSlipDtlNumSrc = source.SalesSlipDtlNumSrc;
			target.SupplierFormalSync = source.SupplierFormalSync;
			target.StockSlipDtlNumSync = source.StockSlipDtlNumSync;
			target.SalesSlipCdDtl = source.SalesSlipCdDtl;
			target.OrderNumber = source.OrderNumber;
			target.StockMngExistCd = source.StockMngExistCd;
			target.DeliGdsCmpltDueDate = source.DeliGdsCmpltDueDate;
			target.GoodsKindCode = source.GoodsKindCode;
			target.GoodsMakerCd = source.GoodsMakerCd;
			target.MakerName = source.MakerName;
			target.GoodsNo = source.GoodsNo;
			target.GoodsName = source.GoodsName;
			target.GoodsShortName = source.GoodsShortName;
			target.GoodsSetDivCd = source.GoodsSetDivCd;
			target.LargeGoodsGanreCode = source.LargeGoodsGanreCode;
			target.LargeGoodsGanreName = source.LargeGoodsGanreName;
			target.MediumGoodsGanreCode = source.MediumGoodsGanreCode;
			target.MediumGoodsGanreName = source.MediumGoodsGanreName;
			target.DetailGoodsGanreCode = source.DetailGoodsGanreCode;
			target.DetailGoodsGanreName = source.DetailGoodsGanreName;
			target.BLGoodsCode = source.BLGoodsCode;
			target.BLGoodsFullName = source.BLGoodsFullName;
			target.EnterpriseGanreCode = source.EnterpriseGanreCode;
			target.EnterpriseGanreName = source.EnterpriseGanreName;
			target.WarehouseCode = source.WarehouseCode;
			target.WarehouseName = source.WarehouseName;
			target.WarehouseShelfNo = source.WarehouseShelfNo;
			target.SalesOrderDivCd = source.SalesOrderDivCd;
			target.OpenPriceDiv = source.OpenPriceDiv;
			target.UnitCode = source.UnitCode;
			target.UnitName = source.UnitName;
			target.GoodsRateRank = source.GoodsRateRank;
			target.CustRateGrpCode = source.CustRateGrpCode;
			target.SuppRateGrpCode = source.SuppRateGrpCode;
			target.ListPriceRate = source.ListPriceRate;
			target.RateSectPriceUnPrc = source.RateSectPriceUnPrc;
			target.RateDivLPrice = source.RateDivLPrice;
			target.UnPrcCalcCdLPrice = source.UnPrcCalcCdLPrice;
			target.PriceCdLPrice = source.PriceCdLPrice;
			target.StdUnPrcLPrice = source.StdUnPrcLPrice;
			target.FracProcUnitLPrice = source.FracProcUnitLPrice;
			target.FracProcLPrice = source.FracProcLPrice;
			target.ListPriceTaxIncFl = source.ListPriceTaxIncFl;
			target.ListPriceTaxExcFl = source.ListPriceTaxExcFl;
			target.ListPriceChngCd = source.ListPriceChngCd;
			target.SalesRate = source.SalesRate;
			target.RateSectSalUnPrc = source.RateSectSalUnPrc;
			target.RateDivSalUnPrc = source.RateDivSalUnPrc;
			target.UnPrcCalcCdSalUnPrc = source.UnPrcCalcCdSalUnPrc;
			target.PriceCdSalUnPrc = source.PriceCdSalUnPrc;
			target.StdUnPrcSalUnPrc = source.StdUnPrcSalUnPrc;
			target.FracProcUnitSalUnPrc = source.FracProcUnitSalUnPrc;
			target.FracProcSalUnPrc = source.FracProcSalUnPrc;
			target.SalesUnPrcTaxIncFl = source.SalesUnPrcTaxIncFl;
			target.SalesUnPrcTaxExcFl = source.SalesUnPrcTaxExcFl;
			target.SalesUnPrcChngCd = source.SalesUnPrcChngCd;
			target.CostRate = source.CostRate;
			target.RateSectCstUnPrc = source.RateSectCstUnPrc;
			target.RateDivUnCst = source.RateDivUnCst;
			target.UnPrcCalcCdUnCst = source.UnPrcCalcCdUnCst;
			target.PriceCdUnCst = source.PriceCdUnCst;
			target.StdUnPrcUnCst = source.StdUnPrcUnCst;
			target.FracProcUnitUnCst = source.FracProcUnitUnCst;
			target.FracProcUnCst = source.FracProcUnCst;
			target.SalesUnitCost = source.SalesUnitCost;
			target.SalesUnitCostChngDiv = source.SalesUnitCostChngDiv;
			target.RateBLGoodsCode = source.RateBLGoodsCode;
			target.RateBLGoodsName = source.RateBLGoodsName;
			target.BargainCd = source.BargainCd;
			target.BargainNm = source.BargainNm;
			target.ShipmentCnt = source.ShipmentCnt;
			target.SalesMoneyTaxInc = source.SalesMoneyTaxInc;
			target.SalesMoneyTaxExc = source.SalesMoneyTaxExc;
			target.Cost = source.Cost;
			target.GrsProfitChkDiv = source.GrsProfitChkDiv;
			target.SalesGoodsCd = source.SalesGoodsCd;
			target.SalsePriceConsTax = source.SalsePriceConsTax;
			target.TaxationDivCd = source.TaxationDivCd;
			target.PartySlipNumDtl = source.PartySlipNumDtl;
			target.DtlNote = source.DtlNote;
			target.SupplierCd = source.SupplierCd;
			target.SupplierSnm = source.SupplierSnm;
			target.SlipMemo1 = source.SlipMemo1;
			target.SlipMemo2 = source.SlipMemo2;
			target.SlipMemo3 = source.SlipMemo3;
			target.SlipMemo4 = source.SlipMemo4;
			target.SlipMemo5 = source.SlipMemo5;
			target.SlipMemo6 = source.SlipMemo6;
			target.InsideMemo1 = source.InsideMemo1;
			target.InsideMemo2 = source.InsideMemo2;
			target.InsideMemo3 = source.InsideMemo3;
			target.InsideMemo4 = source.InsideMemo4;
			target.InsideMemo5 = source.InsideMemo5;
			target.InsideMemo6 = source.InsideMemo6;
			target.BfListPrice = source.BfListPrice;
			target.BfSalesUnitPrice = source.BfSalesUnitPrice;
			target.BfUnitCost = source.BfUnitCost;
			target.PrtGoodsNo = source.PrtGoodsNo;
			target.PrtGoodsName = source.PrtGoodsName;
			target.PrtGoodsMakerCd = source.PrtGoodsMakerCd;
			target.PrtGoodsMakerNm = source.PrtGoodsMakerNm;
			target.SupplierSlipCd = source.SupplierSlipCd;
			target.TotalAmountDispWayCd = source.TotalAmountDispWayCd;
			target.TtlAmntDispRateApy = source.TtlAmntDispRateApy;
			//target.ConfirmedDiv = source.ConfirmedDiv;
			target.NTimeCalcStDate = source.NTimeCalcStDate;
			target.TotalDay = source.TotalDay;
			//target.DtlRelationGuid = source.DtlRelationGuid;

			#endregion
		}
	}

    /// <summary>
    /// 仕入関連のCustomSerializeArrayList分解クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : IOWriteを仕入モードで使用した場合のCustomSerializeArrayListの分解処理を行います。</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2008.09.25</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.09.25　佐々木 健  新規作成</br>
    /// </remarks>
    public class DivisionStockSlipCustomSerializeArrayList
    {
        #region ■Public Static Methods

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（書き込み用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="stockSlipWork">仕入データワークオブジェクト</param>
        /// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgStockDetailWork">計上元明細データワークオブジェクト配列</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        /// <param name="paymentDataWork">支払データワークオブジェクト</param>
        /// <param name="salesTempWorkArray">売上データ(仕入同時計上)ワークオブジェクト配列</param>
        public static void DivisionCustomSerializeArrayListForWritingResult( CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWork, out PaymentDataWork paymentDataWork, out StockWork[] stockWorkArray, out SalesTempWork[] salesTempWorkArray )
        {
            DivisionCustomSerializeArrayListForAfterWritingResultProc(paraList, out stockSlipWork, out stockDetailWorkArray, out addUpOrgStockDetailWork, out paymentDataWork, out stockWorkArray, out salesTempWorkArray);
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（読み込み用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="paraList2">カスタムシリアライズリストオブジェクト</param>
        /// <param name="stockSlipWork">仕入データワークオブジェクト</param>
        /// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgStockDetailWorkArray">計上元明細データワークオブジェクト配列</param>
        /// <param name="paymentDataWork">支払データワークオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        /// <param name="salesSlipWorkList">売上データワークオブジェクトリスト</param>
        /// <param name="salesDetailWorkList">売上明細データワークオブジェクトリスト</param>
        /// <param name="salesTempWorkArray">売上データ(同時)ワークオブジェクト配列</param>
        public static void DivisionCustomSerializeArrayListForReadingResult( CustomSerializeArrayList paraList, CustomSerializeArrayList paraList2, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray, out PaymentDataWork paymentDataWork, out StockWork[] stockWorkArray, out List<SalesSlipWork> salesSlipWorkList, out List<SalesDetailWork> salesDetailWorkList, out SalesTempWork[] salesTempWorkArray )
        {
            DivisionCustomSerializeArrayListForReadingResultProc(paraList, paraList2, out stockSlipWork, out stockDetailWorkArray, out addUpOrgStockDetailWorkArray, out paymentDataWork, out stockWorkArray, out salesSlipWorkList, out salesDetailWorkList, out salesTempWorkArray);
        }

        /// <summary>
        /// CustomSerializeArrayListを仕入明細データオブジェクト、売上データオブジェクト、売上明細データオブジェクトに分割します。（明細読み込み用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="paraList2">カスタムシリアライズリストオブジェクト</param>
        /// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
        /// <param name="salesSlipWorkArray">売上データワークオブジェクト配列</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        public static void DivisionCustomSerializeArrayListForDetailsReadingResult( CustomSerializeArrayList paraList, CustomSerializeArrayList paraList2, out StockDetailWork[] stockDetailWorkArray, out SalesSlipWork[] salesSlipWorkArray, out SalesDetailWork[] salesDetailWorkArray )
        {
            DivisionCustomSerializeArrayListForDetailsReadingResultProc(paraList, paraList2, out stockDetailWorkArray, out salesSlipWorkArray, out salesDetailWorkArray);
        }

        #endregion

        #region ■Private Static Methods

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（書き込み用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="stockSlipWork">仕入データワークオブジェクト</param>
        /// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgStockDetailWork">計上元明細データワークオブジェクト配列</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        /// <param name="paymentDataWork">支払データワークオブジェクト</param>
        /// <param name="salesTempWorkArray">売上データ(仕入同時計上)ワークオブジェクト配列</param>
        private static void DivisionCustomSerializeArrayListForAfterWritingResultProc( CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWork, out PaymentDataWork paymentDataWork, out StockWork[] stockWorkArray, out SalesTempWork[] salesTempWorkArray )
        {
            //------------------------------------------------------------------------------------
            // 書き込み後のCustomSerializeArrayListの構造（書き込み時と同じ）
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList					書き込みパラメータリスト
            //      --IOWriteCtrlOptWork					IOWrite制御ワークオブジェクト
            //      --CustomSerializeArrayList				仕入リスト
            //          --StockSlipWork						仕入データオブジェクト
            //          --ArrayList							仕入明細リスト
            //              --StockDetailWork				仕入明細データオブジェクト
            //          --ArrayList							計上元明細リスト
            //              --AddUppOrgStockDetailWork		計上元仕入明細データオブジェクト
            //          --ArrayList							在庫リスト
            //              --StockWork						在庫データオブジェクト
            //          --PaymentSlpWork					支払データオブジェクト
            //      --CustomSerializeArrayList				同時売上情報
            //          --SalesTempWork						同時入力売上データオブジェクト
            //------------------------------------------------------------------------------------

            stockSlipWork = null;
            stockDetailWorkArray = null;
            addUpOrgStockDetailWork = null;
            paymentDataWork = null;
            stockWorkArray = null;
            salesTempWorkArray = null;

            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is CustomSerializeArrayList)
                {
                    CustomSerializeArrayList slipArrayList = (CustomSerializeArrayList)paraList[i];

                    for (int cnt = 0; cnt < slipArrayList.Count; cnt++)
                    {
                        if (slipArrayList[cnt] is StockSlipWork)
                        {
                            stockSlipWork = (StockSlipWork)slipArrayList[cnt];
                        }
                        else if (slipArrayList[cnt] is PaymentDataWork)
                        {
                            paymentDataWork = (PaymentDataWork)slipArrayList[cnt];
                        }
                        else if (slipArrayList[cnt] is ArrayList)
                        {
                            ArrayList list = (ArrayList)slipArrayList[cnt];

                            if (list.Count == 0) continue;

                            if (list[0] is AddUpOrgStockDetailWork)
                            {
                                addUpOrgStockDetailWork = (AddUpOrgStockDetailWork[])list.ToArray(typeof(AddUpOrgStockDetailWork));
                            }
                            else if (list[0] is StockDetailWork)
                            {
                                stockDetailWorkArray = (StockDetailWork[])list.ToArray(typeof(StockDetailWork));
                            }
                            else if (list[0] is StockWork)
                            {
                                stockWorkArray = (StockWork[])list.ToArray(typeof(StockWork));
                            }
                        }
                        if (slipArrayList[cnt] is SalesTempWork)
                        {
                            salesTempWorkArray = (SalesTempWork[])slipArrayList.ToArray(typeof(SalesTempWork));
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（読み込み用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="paraList2">カスタムシリアライズリストオブジェクト</param>
        /// <param name="stockSlipWork">仕入データワークオブジェクト</param>
        /// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgStockDetailWorkArray">計上元明細データワークオブジェクト配列</param>
        /// <param name="paymentDataWork">支払データワークオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        /// <param name="salesSlipWorkList">売上データワークオブジェクトリスト</param>
        /// <param name="salesDetailWorkList">売上明細データワークオブジェクトリスト</param>
        /// <param name="salesTempWorkArray">売上データ(同時)ワークオブジェクト配列</param>
        private static void DivisionCustomSerializeArrayListForReadingResultProc( CustomSerializeArrayList paraList, CustomSerializeArrayList paraList2, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray, out PaymentDataWork paymentDataWork, out StockWork[] stockWorkArray, out List<SalesSlipWork> salesSlipWorkList, out List<SalesDetailWork> salesDetailWorkList, out SalesTempWork[] salesTempWorkArray )
        {
            //-----------------------------------------------------------------------------------------------------------------------
            // 読み込み後のCustomSerializeArrayListの構造
            //-----------------------------------------------------------------------------------------------------------------------
            //  CustomSerializeArrayList                仕入情報リスト                                      
            //      --StockSlipWork                     仕入データオブジェクト
            //      --ArrayList							仕入明細リスト
            //      --StockDetailWork                   仕入明細データオブジェクト
            //      --PaymentDataWork                   支払データ
            //      --ArrayList                         計上元仕入明細リスト
            //      --AddUpOrgStockDetailWork           計上元仕入明細データオブジェクト
            //
            //-----------------------------------------------------------------------------------------------------------------------
            //
            //  CustomSerializeArrayList                計上／売上情報リスト
            //      --CustomSerializeArrayList          計上元伝票データ
            //          --StockSlipWork                 計上元仕入データオブジェクト
            //          --ArrayList                     計上元仕入明細リスト
            //              --StockDetailWork           計上元仕入明細データオブジェクト
            //          --PaymentDataWork               計上元の支払データ
            //          --ArrayList                     計上元の計上元仕入明細リスト
            //              --AddUpOrgStockDetailWork   計上元の計上元仕入明細データオブジェクト
            //      --CustomSerializeArrayList          同時入力売上データ
            //          --SalesSlipWork                 同時入力売上データオブジェクト
            //          --ArrayList                     同時入力売上明細リスト
            //              --SalesDetailWork           同時入力売上明細データオブジェクト
            //          --ArrayList                     同時入力の計上元売上明細リスト
            //              --AddUpOrgSalesDetailWork   同時入力の計上元売上明細データオブジェクト
            //      --CustomSerializeArrayList          同時入力計上元売上データ
            //          --SalesSlipWork                 同時入力計上元売上データオブジェクト
            //          --ArrayList                     同時入力計上元売上明細リスト
            //              --SalesDetailWork           同時入力計上元売上明細データオブジェクト
            //          --ArrayList                     同時入力の計上元売上明細リスト
            //              --AddUpOrgSalesDetailWork   同時入力の計上元売上明細データオブジェクト
            //      --CustomSerializeArrayList          同時入力売上データ(仕入同時計上)
            //          --SalesTempWork[]               同時入力売上データ(仕入同時計上)データ配列
            //-----------------------------------------------------------------------------------------------------------------------

            // 仕入情報の取得
            DivisionCustomSerializeArrayListForStockSlipInfo(paraList, out stockSlipWork, out stockDetailWorkArray, out addUpOrgStockDetailWorkArray, out paymentDataWork, out stockWorkArray);

            salesTempWorkArray = null;
            salesSlipWorkList = new List<SalesSlipWork>();
            salesDetailWorkList = new List<SalesDetailWork>();

            for (int i = 0; i < paraList2.Count; i++)
            {
                if (paraList2[i] is CustomSerializeArrayList)
                {
                    object objSlipWork;
                    object objDetailWorkArray;
                    object objAddUpOrgDetailWorkArray;
                    object objDepsitMainWork;
                    object objDepositAlwWork;
                    StockWork[] stockWorkArray2;

                    DivisionCustomSerializeArrayListProc((CustomSerializeArrayList)paraList2[i], out objSlipWork, out objDetailWorkArray, out objAddUpOrgDetailWorkArray, out objDepsitMainWork, out objDepositAlwWork, out stockWorkArray2);

                    if (objDetailWorkArray != null)
                    {
                        if (objDetailWorkArray is SalesTempWork[])
                        {
                            salesTempWorkArray = (SalesTempWork[])objDetailWorkArray;
                        }
                        else if (objDetailWorkArray is SalesDetailWork[])
                        {
                            if (objSlipWork is SalesSlipWork)
                            {
                                salesSlipWorkList.Add((SalesSlipWork)objSlipWork);
                            }
                            salesDetailWorkList.AddRange((SalesDetailWork[])objDetailWorkArray);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// CustomSerializeArrayListを仕入明細データオブジェクト、売上データオブジェクト、売上明細データオブジェクトに分割します。（明細読み込み用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="paraList2">カスタムシリアライズリストオブジェクト</param>
        /// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
        /// <param name="salesSlipWorkArray">売上データワークオブジェクト配列</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        private static void DivisionCustomSerializeArrayListForDetailsReadingResultProc( CustomSerializeArrayList paraList, CustomSerializeArrayList paraList2, out StockDetailWork[] stockDetailWorkArray, out SalesSlipWork[] salesSlipWorkArray, out SalesDetailWork[] salesDetailWorkArray )
        {
            stockDetailWorkArray = null;
            salesSlipWorkArray = null;
            salesDetailWorkArray = null;

            ArrayList retStockDetailWorkList = new ArrayList();
            for (int x = 0; x < paraList.Count; x++)
            {
                if (paraList[x] is ArrayList)
                {
                    ArrayList retList = (ArrayList)paraList[x];
                    for (int i = 0; i < retList.Count; i++)
                    {
                        if (retList[i] is StockDetailWork)
                        {
                            retStockDetailWorkList.Add((StockDetailWork)retList[i]);
                        }
                    }
                }
            }

            stockDetailWorkArray = (StockDetailWork[])retStockDetailWorkList.ToArray(typeof(StockDetailWork));

            if (paraList2 != null)
            {
                ArrayList retSalesSlipWorkList = new ArrayList();
                ArrayList retSalesDetailWorkList = new ArrayList();

                for (int i = 0; i < paraList2.Count; i++)
                {
                    if (paraList2[i] is CustomSerializeArrayList)
                    {
                        SalesSlipWork readSalesSlipWork;
                        SalesDetailWork[] readSalesDetailWorkArray;

                        DivisionCustomSerializeArrayListForSalesSlipInfo((CustomSerializeArrayList)paraList2[i], out readSalesSlipWork, out readSalesDetailWorkArray);

                        if (readSalesSlipWork != null) retSalesSlipWorkList.Add(readSalesSlipWork);

                        if (readSalesDetailWorkArray != null) retSalesDetailWorkList.AddRange(readSalesDetailWorkArray);
                    }
                }

                salesSlipWorkArray = (SalesSlipWork[])retSalesSlipWorkList.ToArray(typeof(SalesSlipWork));
                salesDetailWorkArray = (SalesDetailWork[])retSalesDetailWorkList.ToArray(typeof(SalesDetailWork));
            }
        }

        #region ○仕入伝票情報用

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（仕入伝票情報用）（オーバーロード）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="stockSlipWork">仕入データワークオブジェクト</param>
        /// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgStockDetailWorkArray">計上元明細データワークオブジェクト配列</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        /// <param name="paymentDataWork">支払データワークオブジェクト</param>
        private static void DivisionCustomSerializeArrayListForStockSlipInfo( CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray, out PaymentDataWork paymentDataWork, out StockWork[] stockWorkArray )
        {
            stockSlipWork = null;
            stockDetailWorkArray = null;
            addUpOrgStockDetailWorkArray = null;
            paymentDataWork = null;
            stockWorkArray = null;

            object objStockSlipWork;
            object objStockDetailWorkArray;
            object objPaymentWork;
            object objDepositAlwWork;
            object objAddUpOrgStockDetailWorkArray;

            DivisionCustomSerializeArrayListProc(paraList, out objStockSlipWork, out objStockDetailWorkArray, out objAddUpOrgStockDetailWorkArray, out objPaymentWork, out objDepositAlwWork, out stockWorkArray);

            if (( objStockSlipWork != null ) && ( objStockSlipWork is StockSlipWork )) stockSlipWork = (StockSlipWork)objStockSlipWork;

            if (( objStockDetailWorkArray != null ) && ( objStockDetailWorkArray is StockDetailWork[] )) stockDetailWorkArray = (StockDetailWork[])objStockDetailWorkArray;

            if (( objAddUpOrgStockDetailWorkArray != null ) && ( objAddUpOrgStockDetailWorkArray is AddUpOrgStockDetailWork[] )) addUpOrgStockDetailWorkArray = (AddUpOrgStockDetailWork[])objAddUpOrgStockDetailWorkArray;

            if (( objPaymentWork != null ) && ( objPaymentWork is PaymentDataWork )) paymentDataWork = (PaymentDataWork)objPaymentWork;
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（仕入伝票情報用）（オーバーロード）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="stockSlipWork">仕入データワークオブジェクト</param>
        /// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
        private static void DivisionCustomSerializeArrayListForStockSlipInfo( CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray )
        {
            stockSlipWork = null;
            stockDetailWorkArray = null;

            object objStockSlipWork;
            object objStockDetailWorkArray;
            object objAddUpOrgStockDetailWorkArray;
            object objPaymentWork;
            object objDepositAlwWork;
            StockWork[] stockWorkArray;

            DivisionCustomSerializeArrayListProc(paraList, out objStockSlipWork, out objStockDetailWorkArray, out objAddUpOrgStockDetailWorkArray, out objPaymentWork, out objDepositAlwWork, out stockWorkArray);

            if (( objStockSlipWork != null ) && ( objStockSlipWork is StockSlipWork )) stockSlipWork = (StockSlipWork)objStockSlipWork;

            if (( objStockDetailWorkArray != null ) && ( objStockDetailWorkArray is StockDetailWork[] )) stockDetailWorkArray = (StockDetailWork[])objStockDetailWorkArray;
        }
        #endregion

        #region ○売上伝票情報用

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（売上伝票情報用）（オーバーロード）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="salesSlipWork">売上データオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="addUppOrgSalesDetailWorkArray">計上元売上明細データワークオブジェクト配列</param>
        /// <param name="depsitMainWork">入金データオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        private static void DivisionCustomSerializeArrayListForSalesSlipInfo( CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUppOrgSalesDetailWorkArray, out DepsitMainWork depsitMainWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray )
        {
            salesSlipWork = null;
            salesDetailWorkArray = null;
            addUppOrgSalesDetailWorkArray = null;
            depsitMainWork = null;
            depositAlwWork = null;
            stockWorkArray = null;

            object objSalesSlipWork;
            object objSalesDetailWorkArray;
            object objAddUpOrgSalesDetailWorkArray;
            object objDepsitMainWork;
            object objDepositAlwWork;

            DivisionCustomSerializeArrayListProc(paraList, out objSalesSlipWork, out objSalesDetailWorkArray, out objAddUpOrgSalesDetailWorkArray, out objDepsitMainWork, out objDepositAlwWork, out stockWorkArray);

            if (( objSalesSlipWork != null ) && ( objSalesSlipWork is SalesSlipWork )) salesSlipWork = (SalesSlipWork)objSalesSlipWork;

            if (( objSalesDetailWorkArray != null ) && ( objSalesDetailWorkArray is SalesDetailWork[] )) salesDetailWorkArray = (SalesDetailWork[])objSalesDetailWorkArray;

            if (( objAddUpOrgSalesDetailWorkArray != null ) && ( objAddUpOrgSalesDetailWorkArray is AddUpOrgSalesDetailWork[] )) objAddUpOrgSalesDetailWorkArray = (AddUpOrgSalesDetailWork[])objAddUpOrgSalesDetailWorkArray;

            if (( objDepsitMainWork != null ) && ( objDepsitMainWork is DepsitMainWork )) depsitMainWork = (DepsitMainWork)objDepsitMainWork;

            if (( objDepositAlwWork != null ) && ( objDepositAlwWork is DepositAlwWork )) depositAlwWork = (DepositAlwWork)objDepositAlwWork;
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（売上情報用）（オーバーロード）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="salesSlipWork">売上データオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        private static void DivisionCustomSerializeArrayListForSalesSlipInfo( CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray )
        {
            salesSlipWork = null;
            salesDetailWorkArray = null;

            object objSalesSlipWork;
            object objSalesDetailWorkArray;
            object objAddUpOrgSalesDetailWorkArray;
            object objDepsitMainWork;
            object objDepositAlwWork;
            StockWork[] stockWorkArray;

            DivisionCustomSerializeArrayListProc(paraList, out objSalesSlipWork, out objSalesDetailWorkArray, out objAddUpOrgSalesDetailWorkArray, out objDepsitMainWork, out objDepositAlwWork, out stockWorkArray);

            if (( objSalesSlipWork != null ) && ( objSalesSlipWork is SalesSlipWork )) salesSlipWork = (SalesSlipWork)objSalesSlipWork;

            if (( objSalesDetailWorkArray != null ) && ( objSalesDetailWorkArray is SalesDetailWork[] )) salesDetailWorkArray = (SalesDetailWork[])objSalesDetailWorkArray;
        }

        #endregion

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="slipWork">伝票データワークオブジェクト</param>
        /// <param name="detailWorkArray">明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgDetailWorkArray">計上元明細データワークオブジェクト配列</param>
        /// <param name="depsitMainWork">入金データワークオブジェクト</param>
        /// <param name="depositAlwWork">入金データワークオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        private static void DivisionCustomSerializeArrayListProc( CustomSerializeArrayList paraList, out object slipWork, out object detailWorkArray, out object addUpOrgDetailWorkArray, out object depsitMainWork, out object depositAlwWork, out StockWork[] stockWorkArray )
        {
            slipWork = null;
            detailWorkArray = null;
            addUpOrgDetailWorkArray = null;
            depsitMainWork = null;
            depositAlwWork = null;
            stockWorkArray = null;

            for (int i = 0; i < paraList.Count; i++)
            {
                if (( paraList[i] is StockSlipWork ) || ( paraList[i] is SalesSlipWork ))
                {
                    slipWork = paraList[i];
                }
                else if (( paraList[i] is PaymentDataWork ) || ( paraList[i] is DepsitMainWork ))
                {
                    depsitMainWork = paraList[i];
                }
                else if (paraList[i] is DepositAlwWork)
                {
                    depositAlwWork = paraList[i];
                }
                else if (paraList[i] is SalesTempWork)
                {
                    detailWorkArray = (SalesTempWork[])paraList.ToArray(typeof(SalesTempWork));
                    break;
                }
                else if (paraList[i] is ArrayList)
                {
                    ArrayList list = (ArrayList)paraList[i];

                    if (list.Count == 0) continue;

                    if (list[0] is AddUpOrgStockDetailWork)
                    {
                        addUpOrgDetailWorkArray = (AddUpOrgStockDetailWork[])list.ToArray(typeof(AddUpOrgStockDetailWork));
                    }
                    else if (list[0] is AddUpOrgSalesDetailWork)
                    {
                        addUpOrgDetailWorkArray = (AddUpOrgSalesDetailWork[])list.ToArray(typeof(AddUpOrgSalesDetailWork));
                    }
                    else if (list[0] is StockDetailWork)
                    {
                        detailWorkArray = (StockDetailWork[])list.ToArray(typeof(StockDetailWork));
                    }
                    else if (list[0] is SalesDetailWork)
                    {
                        detailWorkArray = (SalesDetailWork[])list.ToArray(typeof(SalesDetailWork));
                    }
                    else if (list[0] is StockWork)
                    {
                        stockWorkArray = (StockWork[])list.ToArray(typeof(StockWork));
                    }
                }
            }
        }

        /// <summary>
        /// CustomSerializeArrayListを仕入明細データオブジェクトに分割します。
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
        private static void DivisionCustomSerializeArrayList( CustomSerializeArrayList paraList, out StockDetailWork[] stockDetailWorkArray )
        {
            stockDetailWorkArray = null;

            ArrayList retStockDetailWorkList = new ArrayList();
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is StockDetailWork)
                {
                    retStockDetailWorkList.Add((StockDetailWork)paraList[i]);
                }
            }
            stockDetailWorkArray = (StockDetailWork[])retStockDetailWorkList.ToArray(typeof(StockDetailWork));
        }

        #endregion


    }
}
