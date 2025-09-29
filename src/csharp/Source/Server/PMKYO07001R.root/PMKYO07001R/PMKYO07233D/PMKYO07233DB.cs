//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   仕入情報ワーククラス
//                  :   PMKYO07233D.DLL
// Name Space       :   Broadleaf.Application.Remoting.ParamData
// Programmer       :   張莉莉
// Date             :   2011.08.05
//----------------------------------------------------------------------
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   APStockInfoConverter
	/// <summary>
	/// 仕入情報ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入情報ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   12/11</br>
	/// <br>Genarated Date   :   2011/08/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class APStockInfoConverter
	{
		/// <summary>
		/// 受信した仕入伝票から拠点側の仕入にコンバーター
		/// </summary>
		/// <param name="apStockSlipWork"></param>
		/// <returns></returns>
		public StockSlipWork GetSecStockSlipWork(APStockSlipWork apStockSlipWork)
		{
			StockSlipWork secStockSlipWork = new StockSlipWork();

			secStockSlipWork.CreateDateTime = apStockSlipWork.CreateDateTime;
			secStockSlipWork.UpdateDateTime = apStockSlipWork.UpdateDateTime;
			secStockSlipWork.EnterpriseCode = apStockSlipWork.EnterpriseCode;
			secStockSlipWork.FileHeaderGuid = apStockSlipWork.FileHeaderGuid;
			secStockSlipWork.UpdEmployeeCode = apStockSlipWork.UpdEmployeeCode;
			secStockSlipWork.UpdAssemblyId1 = apStockSlipWork.UpdAssemblyId1;
			secStockSlipWork.UpdAssemblyId2 = apStockSlipWork.UpdAssemblyId2;
			secStockSlipWork.LogicalDeleteCode = apStockSlipWork.LogicalDeleteCode;
			secStockSlipWork.SupplierFormal = apStockSlipWork.SupplierFormal;
			secStockSlipWork.SupplierSlipNo = apStockSlipWork.SupplierSlipNo;
			secStockSlipWork.SectionCode = apStockSlipWork.SectionCode;
			secStockSlipWork.SubSectionCode = apStockSlipWork.SubSectionCode;
			secStockSlipWork.DebitNoteDiv = apStockSlipWork.DebitNoteDiv;
			secStockSlipWork.DebitNLnkSuppSlipNo = apStockSlipWork.DebitNLnkSuppSlipNo;
			secStockSlipWork.SupplierSlipCd = apStockSlipWork.SupplierSlipCd;
			secStockSlipWork.StockGoodsCd = apStockSlipWork.StockGoodsCd;
			secStockSlipWork.AccPayDivCd = apStockSlipWork.AccPayDivCd;
			secStockSlipWork.StockSectionCd = apStockSlipWork.StockSectionCd;
			secStockSlipWork.StockAddUpSectionCd = apStockSlipWork.StockAddUpSectionCd;
			secStockSlipWork.StockSlipUpdateCd = apStockSlipWork.StockSlipUpdateCd;
			secStockSlipWork.InputDay = apStockSlipWork.InputDay;
			secStockSlipWork.ArrivalGoodsDay = apStockSlipWork.ArrivalGoodsDay;
			secStockSlipWork.StockDate = apStockSlipWork.StockDate;
			secStockSlipWork.StockAddUpADate = apStockSlipWork.StockAddUpADate;
			secStockSlipWork.DelayPaymentDiv = apStockSlipWork.DelayPaymentDiv;
			secStockSlipWork.PayeeCode = apStockSlipWork.PayeeCode;
			secStockSlipWork.PayeeSnm = apStockSlipWork.PayeeSnm;
			secStockSlipWork.SupplierCd = apStockSlipWork.SupplierCd;
			secStockSlipWork.SupplierNm1 = apStockSlipWork.SupplierNm1;
			secStockSlipWork.SupplierNm2 = apStockSlipWork.SupplierNm2;
			secStockSlipWork.SupplierSnm = apStockSlipWork.SupplierSnm;
			secStockSlipWork.BusinessTypeCode = apStockSlipWork.BusinessTypeCode;
			secStockSlipWork.BusinessTypeName = apStockSlipWork.BusinessTypeName;
			secStockSlipWork.SalesAreaCode = apStockSlipWork.SalesAreaCode;
			secStockSlipWork.SalesAreaName = apStockSlipWork.SalesAreaName;
			secStockSlipWork.StockInputCode = apStockSlipWork.StockInputCode;
			secStockSlipWork.StockInputName = apStockSlipWork.StockInputName;
			secStockSlipWork.StockAgentCode = apStockSlipWork.StockAgentCode;
			secStockSlipWork.StockAgentName = apStockSlipWork.StockAgentName;
			secStockSlipWork.SuppTtlAmntDspWayCd = apStockSlipWork.SuppTtlAmntDspWayCd;
			secStockSlipWork.TtlAmntDispRateApy = apStockSlipWork.TtlAmntDispRateApy;
			secStockSlipWork.StockTotalPrice = apStockSlipWork.StockTotalPrice;
			secStockSlipWork.StockSubttlPrice = apStockSlipWork.StockSubttlPrice;
			secStockSlipWork.StockTtlPricTaxInc = apStockSlipWork.StockTtlPricTaxInc;
			secStockSlipWork.StockTtlPricTaxExc = apStockSlipWork.StockTtlPricTaxExc;
			secStockSlipWork.StockNetPrice = apStockSlipWork.StockNetPrice;
			secStockSlipWork.StockPriceConsTax = apStockSlipWork.StockPriceConsTax;
			secStockSlipWork.TtlItdedStcOutTax = apStockSlipWork.TtlItdedStcOutTax;
			secStockSlipWork.TtlItdedStcInTax = apStockSlipWork.TtlItdedStcInTax;
			secStockSlipWork.TtlItdedStcTaxFree = apStockSlipWork.TtlItdedStcTaxFree;
			secStockSlipWork.StockOutTax = apStockSlipWork.StockOutTax;
			secStockSlipWork.StckPrcConsTaxInclu = apStockSlipWork.StckPrcConsTaxInclu;
			secStockSlipWork.StckDisTtlTaxExc = apStockSlipWork.StckDisTtlTaxExc;
			secStockSlipWork.ItdedStockDisOutTax = apStockSlipWork.ItdedStockDisOutTax;
			secStockSlipWork.ItdedStockDisInTax = apStockSlipWork.ItdedStockDisInTax;
			secStockSlipWork.ItdedStockDisTaxFre = apStockSlipWork.ItdedStockDisTaxFre;
			secStockSlipWork.StockDisOutTax = apStockSlipWork.StockDisOutTax;
			secStockSlipWork.StckDisTtlTaxInclu = apStockSlipWork.StckDisTtlTaxInclu;
			secStockSlipWork.TaxAdjust = apStockSlipWork.TaxAdjust;
			secStockSlipWork.BalanceAdjust = apStockSlipWork.BalanceAdjust;
			secStockSlipWork.SuppCTaxLayCd = apStockSlipWork.SuppCTaxLayCd;
			secStockSlipWork.SupplierConsTaxRate = apStockSlipWork.SupplierConsTaxRate;
			secStockSlipWork.AccPayConsTax = apStockSlipWork.AccPayConsTax;
			secStockSlipWork.StockFractionProcCd = apStockSlipWork.StockFractionProcCd;
			secStockSlipWork.AutoPayment = apStockSlipWork.AutoPayment;
			secStockSlipWork.AutoPaySlipNum = apStockSlipWork.AutoPaySlipNum;
			secStockSlipWork.RetGoodsReasonDiv = apStockSlipWork.RetGoodsReasonDiv;
			secStockSlipWork.RetGoodsReason = apStockSlipWork.RetGoodsReason;
			secStockSlipWork.PartySaleSlipNum = apStockSlipWork.PartySaleSlipNum;
			secStockSlipWork.SupplierSlipNote1 = apStockSlipWork.SupplierSlipNote1;
			secStockSlipWork.SupplierSlipNote2 = apStockSlipWork.SupplierSlipNote2;
			secStockSlipWork.DetailRowCount = apStockSlipWork.DetailRowCount;
			secStockSlipWork.EdiSendDate = apStockSlipWork.EdiSendDate;
			secStockSlipWork.EdiTakeInDate = apStockSlipWork.EdiTakeInDate;
			secStockSlipWork.UoeRemark1 = apStockSlipWork.UoeRemark1;
			secStockSlipWork.UoeRemark2 = apStockSlipWork.UoeRemark2;
			secStockSlipWork.SlipPrintDivCd = apStockSlipWork.SlipPrintDivCd;
			secStockSlipWork.SlipPrintFinishCd = apStockSlipWork.SlipPrintFinishCd;
			secStockSlipWork.StockSlipPrintDate = apStockSlipWork.StockSlipPrintDate;
			secStockSlipWork.SlipPrtSetPaperId = apStockSlipWork.SlipPrtSetPaperId;
			secStockSlipWork.SlipAddressDiv = apStockSlipWork.SlipAddressDiv;
			secStockSlipWork.AddresseeCode = apStockSlipWork.AddresseeCode;
			secStockSlipWork.AddresseeName = apStockSlipWork.AddresseeName;
			secStockSlipWork.AddresseeName2 = apStockSlipWork.AddresseeName2;
			secStockSlipWork.AddresseePostNo = apStockSlipWork.AddresseePostNo;
			secStockSlipWork.AddresseeAddr1 = apStockSlipWork.AddresseeAddr1;
			secStockSlipWork.AddresseeAddr3 = apStockSlipWork.AddresseeAddr3;
			secStockSlipWork.AddresseeAddr4 = apStockSlipWork.AddresseeAddr4;
			secStockSlipWork.AddresseeTelNo = apStockSlipWork.AddresseeTelNo;
			secStockSlipWork.AddresseeFaxNo = apStockSlipWork.AddresseeFaxNo;
			secStockSlipWork.DirectSendingCd = apStockSlipWork.DirectSendingCd;

			return secStockSlipWork;
		}

		/// <summary>
		/// 受信した仕入明細伝票から拠点側の仕入明細にコンバーター
		/// </summary>
		/// <param name="apStockDetailWork"></param>
		/// <returns></returns>
		public StockDetailWork GetSecStockDetailWork(APStockDetailWork apStockDetailWork)
		{
			StockDetailWork secStockDetailWork = new StockDetailWork();

			secStockDetailWork.CreateDateTime = apStockDetailWork.CreateDateTime;
			secStockDetailWork.UpdateDateTime = apStockDetailWork.UpdateDateTime;
			secStockDetailWork.EnterpriseCode = apStockDetailWork.EnterpriseCode;
			secStockDetailWork.FileHeaderGuid = apStockDetailWork.FileHeaderGuid;
			secStockDetailWork.UpdEmployeeCode = apStockDetailWork.UpdEmployeeCode;
			secStockDetailWork.UpdAssemblyId1 = apStockDetailWork.UpdAssemblyId1;
			secStockDetailWork.UpdAssemblyId2 = apStockDetailWork.UpdAssemblyId2;
			secStockDetailWork.LogicalDeleteCode = apStockDetailWork.LogicalDeleteCode;
			secStockDetailWork.AcceptAnOrderNo = apStockDetailWork.AcceptAnOrderNo;
			secStockDetailWork.SupplierFormal = apStockDetailWork.SupplierFormal;
			secStockDetailWork.SupplierSlipNo = apStockDetailWork.SupplierSlipNo;
			secStockDetailWork.StockRowNo = apStockDetailWork.StockRowNo;
			secStockDetailWork.SectionCode = apStockDetailWork.SectionCode;
			secStockDetailWork.SubSectionCode = apStockDetailWork.SubSectionCode;
			secStockDetailWork.CommonSeqNo = apStockDetailWork.CommonSeqNo;
			secStockDetailWork.StockSlipDtlNum = apStockDetailWork.StockSlipDtlNum;
			secStockDetailWork.SupplierFormalSrc = apStockDetailWork.SupplierFormalSrc;
			secStockDetailWork.StockSlipDtlNumSrc = apStockDetailWork.StockSlipDtlNumSrc;
			secStockDetailWork.AcptAnOdrStatusSync = apStockDetailWork.AcptAnOdrStatusSync;
			secStockDetailWork.SalesSlipDtlNumSync = apStockDetailWork.SalesSlipDtlNumSync;
			secStockDetailWork.StockSlipCdDtl = apStockDetailWork.StockSlipCdDtl;
			secStockDetailWork.StockInputCode = apStockDetailWork.StockInputCode;
			secStockDetailWork.StockInputName = apStockDetailWork.StockInputName;
			secStockDetailWork.StockAgentCode = apStockDetailWork.StockAgentCode;
			secStockDetailWork.StockAgentName = apStockDetailWork.StockAgentName;
			secStockDetailWork.GoodsKindCode = apStockDetailWork.GoodsKindCode;
			secStockDetailWork.GoodsMakerCd = apStockDetailWork.GoodsMakerCd;
			secStockDetailWork.MakerName = apStockDetailWork.MakerName;
			secStockDetailWork.MakerKanaName = apStockDetailWork.MakerKanaName;
			secStockDetailWork.CmpltMakerKanaName = apStockDetailWork.CmpltMakerKanaName;
			secStockDetailWork.GoodsNo = apStockDetailWork.GoodsNo;
			secStockDetailWork.GoodsName = apStockDetailWork.GoodsName;
			secStockDetailWork.GoodsNameKana = apStockDetailWork.GoodsNameKana;
			secStockDetailWork.GoodsLGroup = apStockDetailWork.GoodsLGroup;
			secStockDetailWork.GoodsLGroupName = apStockDetailWork.GoodsLGroupName;
			secStockDetailWork.GoodsMGroup = apStockDetailWork.GoodsMGroup;
			secStockDetailWork.GoodsMGroupName = apStockDetailWork.GoodsMGroupName;
			secStockDetailWork.BLGroupCode = apStockDetailWork.BLGroupCode;
			secStockDetailWork.BLGroupName = apStockDetailWork.BLGroupName;
			secStockDetailWork.BLGoodsCode = apStockDetailWork.BLGoodsCode;
			secStockDetailWork.BLGoodsFullName = apStockDetailWork.BLGoodsFullName;
			secStockDetailWork.EnterpriseGanreCode = apStockDetailWork.EnterpriseGanreCode;
			secStockDetailWork.EnterpriseGanreName = apStockDetailWork.EnterpriseGanreName;
			secStockDetailWork.WarehouseCode = apStockDetailWork.WarehouseCode;
			secStockDetailWork.WarehouseName = apStockDetailWork.WarehouseName;
			secStockDetailWork.WarehouseShelfNo = apStockDetailWork.WarehouseShelfNo;
			secStockDetailWork.StockOrderDivCd = apStockDetailWork.StockOrderDivCd;
			secStockDetailWork.OpenPriceDiv = apStockDetailWork.OpenPriceDiv;
			secStockDetailWork.GoodsRateRank = apStockDetailWork.GoodsRateRank;
			secStockDetailWork.CustRateGrpCode = apStockDetailWork.CustRateGrpCode;
			secStockDetailWork.SuppRateGrpCode = apStockDetailWork.SuppRateGrpCode;
			secStockDetailWork.ListPriceTaxExcFl = apStockDetailWork.ListPriceTaxExcFl;
			secStockDetailWork.ListPriceTaxIncFl = apStockDetailWork.ListPriceTaxIncFl;
			secStockDetailWork.StockRate = apStockDetailWork.StockRate;
			secStockDetailWork.RateSectStckUnPrc = apStockDetailWork.RateSectStckUnPrc;
			secStockDetailWork.RateDivStckUnPrc = apStockDetailWork.RateDivStckUnPrc;
			secStockDetailWork.UnPrcCalcCdStckUnPrc = apStockDetailWork.UnPrcCalcCdStckUnPrc;
			secStockDetailWork.PriceCdStckUnPrc = apStockDetailWork.PriceCdStckUnPrc;
			secStockDetailWork.StdUnPrcStckUnPrc = apStockDetailWork.StdUnPrcStckUnPrc;
			secStockDetailWork.FracProcUnitStcUnPrc = apStockDetailWork.FracProcUnitStcUnPrc;
			secStockDetailWork.FracProcStckUnPrc = apStockDetailWork.FracProcStckUnPrc;
			secStockDetailWork.StockUnitPriceFl = apStockDetailWork.StockUnitPriceFl;
			secStockDetailWork.StockUnitTaxPriceFl = apStockDetailWork.StockUnitTaxPriceFl;
			secStockDetailWork.StockUnitChngDiv = apStockDetailWork.StockUnitChngDiv;
			secStockDetailWork.BfStockUnitPriceFl = apStockDetailWork.BfStockUnitPriceFl;
			secStockDetailWork.BfListPrice = apStockDetailWork.BfListPrice;
			secStockDetailWork.RateBLGoodsCode = apStockDetailWork.RateBLGoodsCode;
			secStockDetailWork.RateBLGoodsName = apStockDetailWork.RateBLGoodsName;
			secStockDetailWork.RateGoodsRateGrpCd = apStockDetailWork.RateGoodsRateGrpCd;
			secStockDetailWork.RateGoodsRateGrpNm = apStockDetailWork.RateGoodsRateGrpNm;
			secStockDetailWork.RateBLGroupCode = apStockDetailWork.RateBLGroupCode;
			secStockDetailWork.RateBLGroupName = apStockDetailWork.RateBLGroupName;
			secStockDetailWork.StockCount = apStockDetailWork.StockCount;
			secStockDetailWork.OrderCnt = apStockDetailWork.OrderCnt;
			secStockDetailWork.OrderAdjustCnt = apStockDetailWork.OrderAdjustCnt;
			secStockDetailWork.OrderRemainCnt = apStockDetailWork.OrderRemainCnt;
			secStockDetailWork.RemainCntUpdDate = apStockDetailWork.RemainCntUpdDate;
			secStockDetailWork.StockPriceTaxExc = apStockDetailWork.StockPriceTaxExc;
			secStockDetailWork.StockPriceTaxInc = apStockDetailWork.StockPriceTaxInc;
			secStockDetailWork.StockGoodsCd = apStockDetailWork.StockGoodsCd;
			secStockDetailWork.StockPriceConsTax = apStockDetailWork.StockPriceConsTax;
			secStockDetailWork.TaxationCode = apStockDetailWork.TaxationCode;
			secStockDetailWork.StockDtiSlipNote1 = apStockDetailWork.StockDtiSlipNote1;
			secStockDetailWork.SalesCustomerCode = apStockDetailWork.SalesCustomerCode;
			secStockDetailWork.SalesCustomerSnm = apStockDetailWork.SalesCustomerSnm;
			secStockDetailWork.SlipMemo1 = apStockDetailWork.SlipMemo1;
			secStockDetailWork.SlipMemo2 = apStockDetailWork.SlipMemo2;
			secStockDetailWork.SlipMemo3 = apStockDetailWork.SlipMemo3;
			secStockDetailWork.InsideMemo1 = apStockDetailWork.InsideMemo1;
			secStockDetailWork.InsideMemo2 = apStockDetailWork.InsideMemo2;
			secStockDetailWork.InsideMemo3 = apStockDetailWork.InsideMemo3;
			secStockDetailWork.SupplierCd = apStockDetailWork.SupplierCd;
			secStockDetailWork.SupplierSnm = apStockDetailWork.SupplierSnm;
			secStockDetailWork.AddresseeCode = apStockDetailWork.AddresseeCode;
			secStockDetailWork.AddresseeName = apStockDetailWork.AddresseeName;
			secStockDetailWork.DirectSendingCd = apStockDetailWork.DirectSendingCd;
			secStockDetailWork.OrderNumber = apStockDetailWork.OrderNumber;
			secStockDetailWork.WayToOrder = apStockDetailWork.WayToOrder;
			secStockDetailWork.DeliGdsCmpltDueDate = apStockDetailWork.DeliGdsCmpltDueDate;
			secStockDetailWork.ExpectDeliveryDate = apStockDetailWork.ExpectDeliveryDate;
			secStockDetailWork.OrderDataCreateDiv = apStockDetailWork.OrderDataCreateDiv;
			secStockDetailWork.OrderDataCreateDate = apStockDetailWork.OrderDataCreateDate;
			secStockDetailWork.OrderFormIssuedDiv = apStockDetailWork.OrderFormIssuedDiv;

			return secStockDetailWork;
		}

		/// <summary>
		/// 受信した仕入明細伝票から計上元明細データにコンバーター
		/// </summary>
		/// <param name="apStockDetailWork"></param>
		/// <returns></returns>
		public AddUpOrgStockDetailWork GetAddUpOrgStockDetailWork(APStockDetailWork apStockDetailWork)
		{
			AddUpOrgStockDetailWork addUpOrgStockDetailWork = new AddUpOrgStockDetailWork();

			addUpOrgStockDetailWork.CreateDateTime = apStockDetailWork.CreateDateTime;
			addUpOrgStockDetailWork.UpdateDateTime = apStockDetailWork.UpdateDateTime;
			addUpOrgStockDetailWork.EnterpriseCode = apStockDetailWork.EnterpriseCode;
			addUpOrgStockDetailWork.FileHeaderGuid = apStockDetailWork.FileHeaderGuid;
			addUpOrgStockDetailWork.UpdEmployeeCode = apStockDetailWork.UpdEmployeeCode;
			addUpOrgStockDetailWork.UpdAssemblyId1 = apStockDetailWork.UpdAssemblyId1;
			addUpOrgStockDetailWork.UpdAssemblyId2 = apStockDetailWork.UpdAssemblyId2;
			addUpOrgStockDetailWork.LogicalDeleteCode = apStockDetailWork.LogicalDeleteCode;
			addUpOrgStockDetailWork.AcceptAnOrderNo = apStockDetailWork.AcceptAnOrderNo;
			addUpOrgStockDetailWork.SupplierFormal = apStockDetailWork.SupplierFormal;
			addUpOrgStockDetailWork.SupplierSlipNo = apStockDetailWork.SupplierSlipNo;
			addUpOrgStockDetailWork.StockRowNo = apStockDetailWork.StockRowNo;
			addUpOrgStockDetailWork.SectionCode = apStockDetailWork.SectionCode;
			addUpOrgStockDetailWork.SubSectionCode = apStockDetailWork.SubSectionCode;
			addUpOrgStockDetailWork.CommonSeqNo = apStockDetailWork.CommonSeqNo;
			addUpOrgStockDetailWork.StockSlipDtlNum = apStockDetailWork.StockSlipDtlNum;
			addUpOrgStockDetailWork.SupplierFormalSrc = apStockDetailWork.SupplierFormalSrc;
			addUpOrgStockDetailWork.StockSlipDtlNumSrc = apStockDetailWork.StockSlipDtlNumSrc;
			addUpOrgStockDetailWork.AcptAnOdrStatusSync = apStockDetailWork.AcptAnOdrStatusSync;
			addUpOrgStockDetailWork.SalesSlipDtlNumSync = apStockDetailWork.SalesSlipDtlNumSync;
			addUpOrgStockDetailWork.StockSlipCdDtl = apStockDetailWork.StockSlipCdDtl;
			addUpOrgStockDetailWork.StockInputCode = apStockDetailWork.StockInputCode;
			addUpOrgStockDetailWork.StockInputName = apStockDetailWork.StockInputName;
			addUpOrgStockDetailWork.StockAgentCode = apStockDetailWork.StockAgentCode;
			addUpOrgStockDetailWork.StockAgentName = apStockDetailWork.StockAgentName;
			addUpOrgStockDetailWork.GoodsKindCode = apStockDetailWork.GoodsKindCode;
			addUpOrgStockDetailWork.GoodsMakerCd = apStockDetailWork.GoodsMakerCd;
			addUpOrgStockDetailWork.MakerName = apStockDetailWork.MakerName;
			addUpOrgStockDetailWork.MakerKanaName = apStockDetailWork.MakerKanaName;
			addUpOrgStockDetailWork.CmpltMakerKanaName = apStockDetailWork.CmpltMakerKanaName;
			addUpOrgStockDetailWork.GoodsNo = apStockDetailWork.GoodsNo;
			addUpOrgStockDetailWork.GoodsName = apStockDetailWork.GoodsName;
			addUpOrgStockDetailWork.GoodsNameKana = apStockDetailWork.GoodsNameKana;
			addUpOrgStockDetailWork.GoodsLGroup = apStockDetailWork.GoodsLGroup;
			addUpOrgStockDetailWork.GoodsLGroupName = apStockDetailWork.GoodsLGroupName;
			addUpOrgStockDetailWork.GoodsMGroup = apStockDetailWork.GoodsMGroup;
			addUpOrgStockDetailWork.GoodsMGroupName = apStockDetailWork.GoodsMGroupName;
			addUpOrgStockDetailWork.BLGroupCode = apStockDetailWork.BLGroupCode;
			addUpOrgStockDetailWork.BLGroupName = apStockDetailWork.BLGroupName;
			addUpOrgStockDetailWork.BLGoodsCode = apStockDetailWork.BLGoodsCode;
			addUpOrgStockDetailWork.BLGoodsFullName = apStockDetailWork.BLGoodsFullName;
			addUpOrgStockDetailWork.EnterpriseGanreCode = apStockDetailWork.EnterpriseGanreCode;
			addUpOrgStockDetailWork.EnterpriseGanreName = apStockDetailWork.EnterpriseGanreName;
			addUpOrgStockDetailWork.WarehouseCode = apStockDetailWork.WarehouseCode;
			addUpOrgStockDetailWork.WarehouseName = apStockDetailWork.WarehouseName;
			addUpOrgStockDetailWork.WarehouseShelfNo = apStockDetailWork.WarehouseShelfNo;
			addUpOrgStockDetailWork.StockOrderDivCd = apStockDetailWork.StockOrderDivCd;
			addUpOrgStockDetailWork.OpenPriceDiv = apStockDetailWork.OpenPriceDiv;
			addUpOrgStockDetailWork.GoodsRateRank = apStockDetailWork.GoodsRateRank;
			addUpOrgStockDetailWork.CustRateGrpCode = apStockDetailWork.CustRateGrpCode;
			addUpOrgStockDetailWork.SuppRateGrpCode = apStockDetailWork.SuppRateGrpCode;
			addUpOrgStockDetailWork.ListPriceTaxExcFl = apStockDetailWork.ListPriceTaxExcFl;
			addUpOrgStockDetailWork.ListPriceTaxIncFl = apStockDetailWork.ListPriceTaxIncFl;
			addUpOrgStockDetailWork.StockRate = apStockDetailWork.StockRate;
			addUpOrgStockDetailWork.RateSectStckUnPrc = apStockDetailWork.RateSectStckUnPrc;
			addUpOrgStockDetailWork.RateDivStckUnPrc = apStockDetailWork.RateDivStckUnPrc;
			addUpOrgStockDetailWork.UnPrcCalcCdStckUnPrc = apStockDetailWork.UnPrcCalcCdStckUnPrc;
			addUpOrgStockDetailWork.PriceCdStckUnPrc = apStockDetailWork.PriceCdStckUnPrc;
			addUpOrgStockDetailWork.StdUnPrcStckUnPrc = apStockDetailWork.StdUnPrcStckUnPrc;
			addUpOrgStockDetailWork.FracProcUnitStcUnPrc = apStockDetailWork.FracProcUnitStcUnPrc;
			addUpOrgStockDetailWork.FracProcStckUnPrc = apStockDetailWork.FracProcStckUnPrc;
			addUpOrgStockDetailWork.StockUnitPriceFl = apStockDetailWork.StockUnitPriceFl;
			addUpOrgStockDetailWork.StockUnitTaxPriceFl = apStockDetailWork.StockUnitTaxPriceFl;
			addUpOrgStockDetailWork.StockUnitChngDiv = apStockDetailWork.StockUnitChngDiv;
			addUpOrgStockDetailWork.BfStockUnitPriceFl = apStockDetailWork.BfStockUnitPriceFl;
			addUpOrgStockDetailWork.BfListPrice = apStockDetailWork.BfListPrice;
			addUpOrgStockDetailWork.RateBLGoodsCode = apStockDetailWork.RateBLGoodsCode;
			addUpOrgStockDetailWork.RateBLGoodsName = apStockDetailWork.RateBLGoodsName;
			addUpOrgStockDetailWork.RateGoodsRateGrpCd = apStockDetailWork.RateGoodsRateGrpCd;
			addUpOrgStockDetailWork.RateGoodsRateGrpNm = apStockDetailWork.RateGoodsRateGrpNm;
			addUpOrgStockDetailWork.RateBLGroupCode = apStockDetailWork.RateBLGroupCode;
			addUpOrgStockDetailWork.RateBLGroupName = apStockDetailWork.RateBLGroupName;
			addUpOrgStockDetailWork.StockCount = apStockDetailWork.StockCount;
			addUpOrgStockDetailWork.OrderCnt = apStockDetailWork.OrderCnt;
			addUpOrgStockDetailWork.OrderAdjustCnt = apStockDetailWork.OrderAdjustCnt;
			addUpOrgStockDetailWork.OrderRemainCnt = apStockDetailWork.OrderRemainCnt;
			addUpOrgStockDetailWork.RemainCntUpdDate = apStockDetailWork.RemainCntUpdDate;
			addUpOrgStockDetailWork.StockPriceTaxExc = apStockDetailWork.StockPriceTaxExc;
			addUpOrgStockDetailWork.StockPriceTaxInc = apStockDetailWork.StockPriceTaxInc;
			addUpOrgStockDetailWork.StockGoodsCd = apStockDetailWork.StockGoodsCd;
			addUpOrgStockDetailWork.StockPriceConsTax = apStockDetailWork.StockPriceConsTax;
			addUpOrgStockDetailWork.TaxationCode = apStockDetailWork.TaxationCode;
			addUpOrgStockDetailWork.StockDtiSlipNote1 = apStockDetailWork.StockDtiSlipNote1;
			addUpOrgStockDetailWork.SalesCustomerCode = apStockDetailWork.SalesCustomerCode;
			addUpOrgStockDetailWork.SalesCustomerSnm = apStockDetailWork.SalesCustomerSnm;
			addUpOrgStockDetailWork.SlipMemo1 = apStockDetailWork.SlipMemo1;
			addUpOrgStockDetailWork.SlipMemo2 = apStockDetailWork.SlipMemo2;
			addUpOrgStockDetailWork.SlipMemo3 = apStockDetailWork.SlipMemo3;
			addUpOrgStockDetailWork.InsideMemo1 = apStockDetailWork.InsideMemo1;
			addUpOrgStockDetailWork.InsideMemo2 = apStockDetailWork.InsideMemo2;
			addUpOrgStockDetailWork.InsideMemo3 = apStockDetailWork.InsideMemo3;
			addUpOrgStockDetailWork.SupplierCd = apStockDetailWork.SupplierCd;
			addUpOrgStockDetailWork.SupplierSnm = apStockDetailWork.SupplierSnm;
			addUpOrgStockDetailWork.AddresseeCode = apStockDetailWork.AddresseeCode;
			addUpOrgStockDetailWork.AddresseeName = apStockDetailWork.AddresseeName;
			addUpOrgStockDetailWork.DirectSendingCd = apStockDetailWork.DirectSendingCd;
			addUpOrgStockDetailWork.OrderNumber = apStockDetailWork.OrderNumber;
			addUpOrgStockDetailWork.WayToOrder = apStockDetailWork.WayToOrder;
			addUpOrgStockDetailWork.DeliGdsCmpltDueDate = apStockDetailWork.DeliGdsCmpltDueDate;
			addUpOrgStockDetailWork.ExpectDeliveryDate = apStockDetailWork.ExpectDeliveryDate;
			addUpOrgStockDetailWork.OrderDataCreateDiv = apStockDetailWork.OrderDataCreateDiv;
			addUpOrgStockDetailWork.OrderDataCreateDate = apStockDetailWork.OrderDataCreateDate;
			addUpOrgStockDetailWork.OrderFormIssuedDiv = apStockDetailWork.OrderFormIssuedDiv;

			return addUpOrgStockDetailWork;
		}
	}
}
