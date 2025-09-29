//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   売上情報コンバータークラス
//                  :   PMKYO07223D.DLL
// Name Space       :   Broadleaf.Application.Remoting.ParamData
// Programmer       :   斉建華
// Date             :   2011.08.05
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   APSalesInfoConverter
    /// <summary>
    /// 売上コンバータークラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上情報ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   08/05</br>
    /// <br>Genarated Date   :   2011/08/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class APSalesInfoConverter
    {
        /// <summary>
        /// 受信した売上伝票から拠点側の売上にコンバーター
        /// </summary>
        /// <param name="apSalesSlipWork">受信した売上データ</param>
        /// <returns>拠点側の売上データ</returns>
        public SalesSlipWork GetSecSalesSlipWork(APSalesSlipWork apSalesSlipWork)
        {
            SalesSlipWork secSalesSlipWork = new SalesSlipWork();

            secSalesSlipWork.CreateDateTime = apSalesSlipWork.CreateDateTime;
            secSalesSlipWork.UpdateDateTime = apSalesSlipWork.UpdateDateTime;
            secSalesSlipWork.EnterpriseCode = apSalesSlipWork.EnterpriseCode;
            secSalesSlipWork.FileHeaderGuid = apSalesSlipWork.FileHeaderGuid;
            secSalesSlipWork.UpdEmployeeCode = apSalesSlipWork.UpdEmployeeCode;
            secSalesSlipWork.UpdAssemblyId1 = apSalesSlipWork.UpdAssemblyId1;
            secSalesSlipWork.UpdAssemblyId2 = apSalesSlipWork.UpdAssemblyId2;
            secSalesSlipWork.LogicalDeleteCode = apSalesSlipWork.LogicalDeleteCode;
            secSalesSlipWork.AcptAnOdrStatus = apSalesSlipWork.AcptAnOdrStatus;
            secSalesSlipWork.SalesSlipNum = apSalesSlipWork.SalesSlipNum;
            secSalesSlipWork.SectionCode = apSalesSlipWork.SectionCode;
            secSalesSlipWork.SubSectionCode = apSalesSlipWork.SubSectionCode;
            secSalesSlipWork.DebitNoteDiv = apSalesSlipWork.DebitNoteDiv;
            secSalesSlipWork.DebitNLnkSalesSlNum = apSalesSlipWork.DebitNLnkSalesSlNum;
            secSalesSlipWork.SalesSlipCd = apSalesSlipWork.SalesSlipCd;
            secSalesSlipWork.SalesGoodsCd = apSalesSlipWork.SalesGoodsCd;
            secSalesSlipWork.AccRecDivCd = apSalesSlipWork.AccRecDivCd;
            secSalesSlipWork.SalesInpSecCd = apSalesSlipWork.SalesInpSecCd;
            secSalesSlipWork.DemandAddUpSecCd = apSalesSlipWork.DemandAddUpSecCd;
            secSalesSlipWork.ResultsAddUpSecCd = apSalesSlipWork.ResultsAddUpSecCd;
            secSalesSlipWork.UpdateSecCd = apSalesSlipWork.UpdateSecCd;
            secSalesSlipWork.SalesSlipUpdateCd = apSalesSlipWork.SalesSlipUpdateCd;
            secSalesSlipWork.SearchSlipDate = apSalesSlipWork.SearchSlipDate;
            secSalesSlipWork.ShipmentDay = apSalesSlipWork.ShipmentDay;
            secSalesSlipWork.SalesDate = apSalesSlipWork.SalesDate;
            secSalesSlipWork.AddUpADate = apSalesSlipWork.AddUpADate;
            secSalesSlipWork.DelayPaymentDiv = apSalesSlipWork.DelayPaymentDiv;
            secSalesSlipWork.EstimateFormNo = apSalesSlipWork.EstimateFormNo;
            secSalesSlipWork.EstimateDivide = apSalesSlipWork.EstimateDivide;
            secSalesSlipWork.InputAgenCd = apSalesSlipWork.InputAgenCd;
            secSalesSlipWork.InputAgenNm = apSalesSlipWork.InputAgenNm;
            secSalesSlipWork.SalesInputCode = apSalesSlipWork.SalesInputCode;
            secSalesSlipWork.SalesInputName = apSalesSlipWork.SalesInputName;
            secSalesSlipWork.FrontEmployeeCd = apSalesSlipWork.FrontEmployeeCd;
            secSalesSlipWork.FrontEmployeeNm = apSalesSlipWork.FrontEmployeeNm;
            secSalesSlipWork.SalesEmployeeCd = apSalesSlipWork.SalesEmployeeCd;
            secSalesSlipWork.SalesEmployeeNm = apSalesSlipWork.SalesEmployeeNm;
            secSalesSlipWork.TotalAmountDispWayCd = apSalesSlipWork.TotalAmountDispWayCd;
            secSalesSlipWork.TtlAmntDispRateApy = apSalesSlipWork.TtlAmntDispRateApy;
            secSalesSlipWork.SalesTotalTaxInc = apSalesSlipWork.SalesTotalTaxInc;
            secSalesSlipWork.SalesTotalTaxExc = apSalesSlipWork.SalesTotalTaxExc;
            secSalesSlipWork.SalesPrtTotalTaxInc = apSalesSlipWork.SalesPrtTotalTaxInc;
            secSalesSlipWork.SalesPrtTotalTaxExc = apSalesSlipWork.SalesPrtTotalTaxExc;
            secSalesSlipWork.SalesWorkTotalTaxInc = apSalesSlipWork.SalesWorkTotalTaxInc;
            secSalesSlipWork.SalesWorkTotalTaxExc = apSalesSlipWork.SalesWorkTotalTaxExc;
            secSalesSlipWork.SalesSubtotalTaxInc = apSalesSlipWork.SalesSubtotalTaxInc;
            secSalesSlipWork.SalesSubtotalTaxExc = apSalesSlipWork.SalesSubtotalTaxExc;
            secSalesSlipWork.SalesPrtSubttlInc = apSalesSlipWork.SalesPrtSubttlInc;
            secSalesSlipWork.SalesPrtSubttlExc = apSalesSlipWork.SalesPrtSubttlExc;
            secSalesSlipWork.SalesWorkSubttlInc = apSalesSlipWork.SalesWorkSubttlInc;
            secSalesSlipWork.SalesWorkSubttlExc = apSalesSlipWork.SalesWorkSubttlExc;
            secSalesSlipWork.SalesNetPrice = apSalesSlipWork.SalesNetPrice;
            secSalesSlipWork.SalesSubtotalTax = apSalesSlipWork.SalesSubtotalTax;
            secSalesSlipWork.ItdedSalesOutTax = apSalesSlipWork.ItdedSalesOutTax;
            secSalesSlipWork.ItdedSalesInTax = apSalesSlipWork.ItdedSalesInTax;
            secSalesSlipWork.SalSubttlSubToTaxFre = apSalesSlipWork.SalSubttlSubToTaxFre;
            secSalesSlipWork.SalesOutTax = apSalesSlipWork.SalesOutTax;
            secSalesSlipWork.SalAmntConsTaxInclu = apSalesSlipWork.SalAmntConsTaxInclu;
            secSalesSlipWork.SalesDisTtlTaxExc = apSalesSlipWork.SalesDisTtlTaxExc;
            secSalesSlipWork.ItdedSalesDisOutTax = apSalesSlipWork.ItdedSalesDisOutTax;
            secSalesSlipWork.ItdedSalesDisInTax = apSalesSlipWork.ItdedSalesDisInTax;
            secSalesSlipWork.ItdedPartsDisOutTax = apSalesSlipWork.ItdedPartsDisOutTax;
            secSalesSlipWork.ItdedPartsDisInTax = apSalesSlipWork.ItdedPartsDisInTax;
            secSalesSlipWork.ItdedWorkDisOutTax = apSalesSlipWork.ItdedWorkDisOutTax;
            secSalesSlipWork.ItdedWorkDisInTax = apSalesSlipWork.ItdedWorkDisInTax;
            secSalesSlipWork.ItdedSalesDisTaxFre = apSalesSlipWork.ItdedSalesDisTaxFre;
            secSalesSlipWork.SalesDisOutTax = apSalesSlipWork.SalesDisOutTax;
            secSalesSlipWork.SalesDisTtlTaxInclu = apSalesSlipWork.SalesDisTtlTaxInclu;
            secSalesSlipWork.PartsDiscountRate = apSalesSlipWork.PartsDiscountRate;
            secSalesSlipWork.RavorDiscountRate = apSalesSlipWork.RavorDiscountRate;
            secSalesSlipWork.TotalCost = apSalesSlipWork.TotalCost;
            secSalesSlipWork.ConsTaxLayMethod = apSalesSlipWork.ConsTaxLayMethod;
            secSalesSlipWork.ConsTaxRate = apSalesSlipWork.ConsTaxRate;
            secSalesSlipWork.FractionProcCd = apSalesSlipWork.FractionProcCd;
            secSalesSlipWork.AccRecConsTax = apSalesSlipWork.AccRecConsTax;
            secSalesSlipWork.AutoDepositCd = apSalesSlipWork.AutoDepositCd;
            secSalesSlipWork.AutoDepositSlipNo = apSalesSlipWork.AutoDepositSlipNo;
            secSalesSlipWork.DepositAllowanceTtl = apSalesSlipWork.DepositAllowanceTtl;
            secSalesSlipWork.DepositAlwcBlnce = apSalesSlipWork.DepositAlwcBlnce;
            secSalesSlipWork.ClaimCode = apSalesSlipWork.ClaimCode;
            secSalesSlipWork.ClaimSnm = apSalesSlipWork.ClaimSnm;
            secSalesSlipWork.CustomerCode = apSalesSlipWork.CustomerCode;
            secSalesSlipWork.CustomerName = apSalesSlipWork.CustomerName;
            secSalesSlipWork.CustomerName2 = apSalesSlipWork.CustomerName2;
            secSalesSlipWork.CustomerSnm = apSalesSlipWork.CustomerSnm;
            secSalesSlipWork.HonorificTitle = apSalesSlipWork.HonorificTitle;
            secSalesSlipWork.OutputNameCode = apSalesSlipWork.OutputNameCode;
            secSalesSlipWork.OutputName = apSalesSlipWork.OutputName;
            secSalesSlipWork.CustSlipNo = apSalesSlipWork.CustSlipNo;
            secSalesSlipWork.SlipAddressDiv = apSalesSlipWork.SlipAddressDiv;
            secSalesSlipWork.AddresseeCode = apSalesSlipWork.AddresseeCode;
            secSalesSlipWork.AddresseeName = apSalesSlipWork.AddresseeName;
            secSalesSlipWork.AddresseeName2 = apSalesSlipWork.AddresseeName2;
            secSalesSlipWork.AddresseePostNo = apSalesSlipWork.AddresseePostNo;
            secSalesSlipWork.AddresseeAddr1 = apSalesSlipWork.AddresseeAddr1;
            secSalesSlipWork.AddresseeAddr3 = apSalesSlipWork.AddresseeAddr3;
            secSalesSlipWork.AddresseeAddr4 = apSalesSlipWork.AddresseeAddr4;
            secSalesSlipWork.AddresseeTelNo = apSalesSlipWork.AddresseeTelNo;
            secSalesSlipWork.AddresseeFaxNo = apSalesSlipWork.AddresseeFaxNo;
            secSalesSlipWork.PartySaleSlipNum = apSalesSlipWork.PartySaleSlipNum;
            secSalesSlipWork.SlipNote = apSalesSlipWork.SlipNote;
            secSalesSlipWork.SlipNote2 = apSalesSlipWork.SlipNote2;
            secSalesSlipWork.SlipNote3 = apSalesSlipWork.SlipNote3;
            secSalesSlipWork.RetGoodsReasonDiv = apSalesSlipWork.RetGoodsReasonDiv;
            secSalesSlipWork.RetGoodsReason = apSalesSlipWork.RetGoodsReason;
            secSalesSlipWork.RegiProcDate = apSalesSlipWork.RegiProcDate;
            secSalesSlipWork.CashRegisterNo = apSalesSlipWork.CashRegisterNo;
            secSalesSlipWork.PosReceiptNo = apSalesSlipWork.PosReceiptNo;
            secSalesSlipWork.DetailRowCount = apSalesSlipWork.DetailRowCount;
            secSalesSlipWork.EdiSendDate = apSalesSlipWork.EdiSendDate;
            secSalesSlipWork.EdiTakeInDate = apSalesSlipWork.EdiTakeInDate;
            secSalesSlipWork.UoeRemark1 = apSalesSlipWork.UoeRemark1;
            secSalesSlipWork.UoeRemark2 = apSalesSlipWork.UoeRemark2;
            secSalesSlipWork.SlipPrintDivCd = apSalesSlipWork.SlipPrintDivCd;
            secSalesSlipWork.SlipPrintFinishCd = apSalesSlipWork.SlipPrintFinishCd;
            secSalesSlipWork.SalesSlipPrintDate = apSalesSlipWork.SalesSlipPrintDate;
            secSalesSlipWork.BusinessTypeCode = apSalesSlipWork.BusinessTypeCode;
            secSalesSlipWork.BusinessTypeName = apSalesSlipWork.BusinessTypeName;
            secSalesSlipWork.OrderNumber = apSalesSlipWork.OrderNumber;
            secSalesSlipWork.DeliveredGoodsDiv = apSalesSlipWork.DeliveredGoodsDiv;
            secSalesSlipWork.DeliveredGoodsDivNm = apSalesSlipWork.DeliveredGoodsDivNm;
            secSalesSlipWork.SalesAreaCode = apSalesSlipWork.SalesAreaCode;
            secSalesSlipWork.SalesAreaName = apSalesSlipWork.SalesAreaName;
            secSalesSlipWork.ReconcileFlag = apSalesSlipWork.ReconcileFlag;
            secSalesSlipWork.SlipPrtSetPaperId = apSalesSlipWork.SlipPrtSetPaperId;
            secSalesSlipWork.CompleteCd = apSalesSlipWork.CompleteCd;
            secSalesSlipWork.SalesPriceFracProcCd = apSalesSlipWork.SalesPriceFracProcCd;
            secSalesSlipWork.StockGoodsTtlTaxExc = apSalesSlipWork.StockGoodsTtlTaxExc;
            secSalesSlipWork.PureGoodsTtlTaxExc = apSalesSlipWork.PureGoodsTtlTaxExc;
            secSalesSlipWork.ListPricePrintDiv = apSalesSlipWork.ListPricePrintDiv;
            secSalesSlipWork.EraNameDispCd1 = apSalesSlipWork.EraNameDispCd1;
            secSalesSlipWork.EstimaTaxDivCd = apSalesSlipWork.EstimaTaxDivCd;
            secSalesSlipWork.EstimateFormPrtCd = apSalesSlipWork.EstimateFormPrtCd;
            secSalesSlipWork.EstimateSubject = apSalesSlipWork.EstimateSubject;
            secSalesSlipWork.Footnotes1 = apSalesSlipWork.Footnotes1;
            secSalesSlipWork.Footnotes2 = apSalesSlipWork.Footnotes2;
            secSalesSlipWork.EstimateTitle1 = apSalesSlipWork.EstimateTitle1;
            secSalesSlipWork.EstimateTitle2 = apSalesSlipWork.EstimateTitle2;
            secSalesSlipWork.EstimateTitle3 = apSalesSlipWork.EstimateTitle3;
            secSalesSlipWork.EstimateTitle4 = apSalesSlipWork.EstimateTitle4;
            secSalesSlipWork.EstimateTitle5 = apSalesSlipWork.EstimateTitle5;
            secSalesSlipWork.EstimateNote1 = apSalesSlipWork.EstimateNote1;
            secSalesSlipWork.EstimateNote2 = apSalesSlipWork.EstimateNote2;
            secSalesSlipWork.EstimateNote3 = apSalesSlipWork.EstimateNote3;
            secSalesSlipWork.EstimateNote4 = apSalesSlipWork.EstimateNote4;
            secSalesSlipWork.EstimateNote5 = apSalesSlipWork.EstimateNote5;
            secSalesSlipWork.EstimateValidityDate = apSalesSlipWork.EstimateValidityDate;
            secSalesSlipWork.PartsNoPrtCd = apSalesSlipWork.PartsNoPrtCd;
            secSalesSlipWork.OptionPringDivCd = apSalesSlipWork.OptionPringDivCd;
            secSalesSlipWork.RateUseCode = apSalesSlipWork.RateUseCode;

            return secSalesSlipWork;
        }

        /// <summary>
        /// 受信した売上明細から拠点側の売上明細にコンバーター
        /// </summary>
        /// <param name="apSalesDetailWork">受信した売上明細</param>
        /// <returns>拠点側の売上明細データ</returns>
        public SalesDetailWork GetSecSalesDetailWork(APSalesDetailWork apSalesDetailWork)
        {
            SalesDetailWork secSalesDetailWork = new SalesDetailWork();

            secSalesDetailWork.CreateDateTime = apSalesDetailWork.CreateDateTime;
            secSalesDetailWork.UpdateDateTime = apSalesDetailWork.UpdateDateTime;
            secSalesDetailWork.EnterpriseCode = apSalesDetailWork.EnterpriseCode;
            secSalesDetailWork.FileHeaderGuid = apSalesDetailWork.FileHeaderGuid;
            secSalesDetailWork.UpdEmployeeCode = apSalesDetailWork.UpdEmployeeCode;
            secSalesDetailWork.UpdAssemblyId1 = apSalesDetailWork.UpdAssemblyId1;
            secSalesDetailWork.UpdAssemblyId2 = apSalesDetailWork.UpdAssemblyId2;
            secSalesDetailWork.LogicalDeleteCode = apSalesDetailWork.LogicalDeleteCode;
            secSalesDetailWork.AcceptAnOrderNo = apSalesDetailWork.AcceptAnOrderNo;
            secSalesDetailWork.AcptAnOdrStatus = apSalesDetailWork.AcptAnOdrStatus;
            secSalesDetailWork.SalesSlipNum = apSalesDetailWork.SalesSlipNum;
            secSalesDetailWork.SalesRowNo = apSalesDetailWork.SalesRowNo;
            secSalesDetailWork.SalesRowDerivNo = apSalesDetailWork.SalesRowDerivNo;
            secSalesDetailWork.SectionCode = apSalesDetailWork.SectionCode;
            secSalesDetailWork.SubSectionCode = apSalesDetailWork.SubSectionCode;
            secSalesDetailWork.SalesDate = apSalesDetailWork.SalesDate;
            secSalesDetailWork.CommonSeqNo = apSalesDetailWork.CommonSeqNo;
            secSalesDetailWork.SalesSlipDtlNum = apSalesDetailWork.SalesSlipDtlNum;
            secSalesDetailWork.AcptAnOdrStatusSrc = apSalesDetailWork.AcptAnOdrStatusSrc;
            secSalesDetailWork.SalesSlipDtlNumSrc = apSalesDetailWork.SalesSlipDtlNumSrc;
            secSalesDetailWork.SupplierFormalSync = apSalesDetailWork.SupplierFormalSync;
            secSalesDetailWork.StockSlipDtlNumSync = apSalesDetailWork.StockSlipDtlNumSync;
            secSalesDetailWork.SalesSlipCdDtl = apSalesDetailWork.SalesSlipCdDtl;
            secSalesDetailWork.DeliGdsCmpltDueDate = apSalesDetailWork.DeliGdsCmpltDueDate;
            secSalesDetailWork.GoodsKindCode = apSalesDetailWork.GoodsKindCode;
            secSalesDetailWork.GoodsSearchDivCd = apSalesDetailWork.GoodsSearchDivCd;
            secSalesDetailWork.GoodsMakerCd = apSalesDetailWork.GoodsMakerCd;
            secSalesDetailWork.MakerName = apSalesDetailWork.MakerName;
            secSalesDetailWork.MakerKanaName = apSalesDetailWork.MakerKanaName;
            secSalesDetailWork.GoodsNo = apSalesDetailWork.GoodsNo;
            secSalesDetailWork.GoodsName = apSalesDetailWork.GoodsName;
            secSalesDetailWork.GoodsNameKana = apSalesDetailWork.GoodsNameKana;
            secSalesDetailWork.GoodsLGroup = apSalesDetailWork.GoodsLGroup;
            secSalesDetailWork.GoodsLGroupName = apSalesDetailWork.GoodsLGroupName;
            secSalesDetailWork.GoodsMGroup = apSalesDetailWork.GoodsMGroup;
            secSalesDetailWork.GoodsMGroupName = apSalesDetailWork.GoodsMGroupName;
            secSalesDetailWork.BLGroupCode = apSalesDetailWork.BLGroupCode;
            secSalesDetailWork.BLGroupName = apSalesDetailWork.BLGroupName;
            secSalesDetailWork.BLGoodsCode = apSalesDetailWork.BLGoodsCode;
            secSalesDetailWork.BLGoodsFullName = apSalesDetailWork.BLGoodsFullName;
            secSalesDetailWork.EnterpriseGanreCode = apSalesDetailWork.EnterpriseGanreCode;
            secSalesDetailWork.EnterpriseGanreName = apSalesDetailWork.EnterpriseGanreName;
            secSalesDetailWork.WarehouseCode = apSalesDetailWork.WarehouseCode;
            secSalesDetailWork.WarehouseName = apSalesDetailWork.WarehouseName;
            secSalesDetailWork.WarehouseShelfNo = apSalesDetailWork.WarehouseShelfNo;
            secSalesDetailWork.SalesOrderDivCd = apSalesDetailWork.SalesOrderDivCd;
            secSalesDetailWork.OpenPriceDiv = apSalesDetailWork.OpenPriceDiv;
            secSalesDetailWork.GoodsRateRank = apSalesDetailWork.GoodsRateRank;
            secSalesDetailWork.CustRateGrpCode = apSalesDetailWork.CustRateGrpCode;
            secSalesDetailWork.ListPriceRate = apSalesDetailWork.ListPriceRate;
            secSalesDetailWork.RateSectPriceUnPrc = apSalesDetailWork.RateSectPriceUnPrc;
            secSalesDetailWork.RateDivLPrice = apSalesDetailWork.RateDivLPrice;
            secSalesDetailWork.UnPrcCalcCdLPrice = apSalesDetailWork.UnPrcCalcCdLPrice;
            secSalesDetailWork.PriceCdLPrice = apSalesDetailWork.PriceCdLPrice;
            secSalesDetailWork.StdUnPrcLPrice = apSalesDetailWork.StdUnPrcLPrice;
            secSalesDetailWork.FracProcUnitLPrice = apSalesDetailWork.FracProcUnitLPrice;
            secSalesDetailWork.FracProcLPrice = apSalesDetailWork.FracProcLPrice;
            secSalesDetailWork.ListPriceTaxIncFl = apSalesDetailWork.ListPriceTaxIncFl;
            secSalesDetailWork.ListPriceTaxExcFl = apSalesDetailWork.ListPriceTaxExcFl;
            secSalesDetailWork.ListPriceChngCd = apSalesDetailWork.ListPriceChngCd;
            secSalesDetailWork.SalesRate = apSalesDetailWork.SalesRate;
            secSalesDetailWork.RateSectSalUnPrc = apSalesDetailWork.RateSectSalUnPrc;
            secSalesDetailWork.RateDivSalUnPrc = apSalesDetailWork.RateDivSalUnPrc;
            secSalesDetailWork.UnPrcCalcCdSalUnPrc = apSalesDetailWork.UnPrcCalcCdSalUnPrc;
            secSalesDetailWork.PriceCdSalUnPrc = apSalesDetailWork.PriceCdSalUnPrc;
            secSalesDetailWork.StdUnPrcSalUnPrc = apSalesDetailWork.StdUnPrcSalUnPrc;
            secSalesDetailWork.FracProcUnitSalUnPrc = apSalesDetailWork.FracProcUnitSalUnPrc;
            secSalesDetailWork.FracProcSalUnPrc = apSalesDetailWork.FracProcSalUnPrc;
            secSalesDetailWork.SalesUnPrcTaxIncFl = apSalesDetailWork.SalesUnPrcTaxIncFl;
            secSalesDetailWork.SalesUnPrcTaxExcFl = apSalesDetailWork.SalesUnPrcTaxExcFl;
            secSalesDetailWork.SalesUnPrcChngCd = apSalesDetailWork.SalesUnPrcChngCd;
            secSalesDetailWork.CostRate = apSalesDetailWork.CostRate;
            secSalesDetailWork.RateSectCstUnPrc = apSalesDetailWork.RateSectCstUnPrc;
            secSalesDetailWork.RateDivUnCst = apSalesDetailWork.RateDivUnCst;
            secSalesDetailWork.UnPrcCalcCdUnCst = apSalesDetailWork.UnPrcCalcCdUnCst;
            secSalesDetailWork.PriceCdUnCst = apSalesDetailWork.PriceCdUnCst;
            secSalesDetailWork.StdUnPrcUnCst = apSalesDetailWork.StdUnPrcUnCst;
            secSalesDetailWork.FracProcUnitUnCst = apSalesDetailWork.FracProcUnitUnCst;
            secSalesDetailWork.FracProcUnCst = apSalesDetailWork.FracProcUnCst;
            secSalesDetailWork.SalesUnitCost = apSalesDetailWork.SalesUnitCost;
            secSalesDetailWork.SalesUnitCostChngDiv = apSalesDetailWork.SalesUnitCostChngDiv;
            secSalesDetailWork.RateBLGoodsCode = apSalesDetailWork.RateBLGoodsCode;
            secSalesDetailWork.RateBLGoodsName = apSalesDetailWork.RateBLGoodsName;
            secSalesDetailWork.RateGoodsRateGrpCd = apSalesDetailWork.RateGoodsRateGrpCd;
            secSalesDetailWork.RateGoodsRateGrpNm = apSalesDetailWork.RateGoodsRateGrpNm;
            secSalesDetailWork.RateBLGroupCode = apSalesDetailWork.RateBLGroupCode;
            secSalesDetailWork.RateBLGroupName = apSalesDetailWork.RateBLGroupName;
            secSalesDetailWork.PrtBLGoodsCode = apSalesDetailWork.PrtBLGoodsCode;
            secSalesDetailWork.PrtBLGoodsName = apSalesDetailWork.PrtBLGoodsName;
            secSalesDetailWork.SalesCode = apSalesDetailWork.SalesCode;
            secSalesDetailWork.SalesCdNm = apSalesDetailWork.SalesCdNm;
            secSalesDetailWork.WorkManHour = apSalesDetailWork.WorkManHour;
            secSalesDetailWork.ShipmentCnt = apSalesDetailWork.ShipmentCnt;
            secSalesDetailWork.AcceptAnOrderCnt = apSalesDetailWork.AcceptAnOrderCnt;
            secSalesDetailWork.AcptAnOdrAdjustCnt = apSalesDetailWork.AcptAnOdrAdjustCnt;
            secSalesDetailWork.AcptAnOdrRemainCnt = apSalesDetailWork.AcptAnOdrRemainCnt;
            secSalesDetailWork.RemainCntUpdDate = apSalesDetailWork.RemainCntUpdDate;
            secSalesDetailWork.SalesMoneyTaxInc = apSalesDetailWork.SalesMoneyTaxInc;
            secSalesDetailWork.SalesMoneyTaxExc = apSalesDetailWork.SalesMoneyTaxExc;
            secSalesDetailWork.Cost = apSalesDetailWork.Cost;
            secSalesDetailWork.GrsProfitChkDiv = apSalesDetailWork.GrsProfitChkDiv;
            secSalesDetailWork.SalesGoodsCd = apSalesDetailWork.SalesGoodsCd;
            secSalesDetailWork.SalesPriceConsTax = apSalesDetailWork.SalesPriceConsTax;
            secSalesDetailWork.TaxationDivCd = apSalesDetailWork.TaxationDivCd;
            secSalesDetailWork.PartySlipNumDtl = apSalesDetailWork.PartySlipNumDtl;
            secSalesDetailWork.DtlNote = apSalesDetailWork.DtlNote;
            secSalesDetailWork.SupplierCd = apSalesDetailWork.SupplierCd;
            secSalesDetailWork.SupplierSnm = apSalesDetailWork.SupplierSnm;
            secSalesDetailWork.OrderNumber = apSalesDetailWork.OrderNumber;
            secSalesDetailWork.WayToOrder = apSalesDetailWork.WayToOrder;
            secSalesDetailWork.SlipMemo1 = apSalesDetailWork.SlipMemo1;
            secSalesDetailWork.SlipMemo2 = apSalesDetailWork.SlipMemo2;
            secSalesDetailWork.SlipMemo3 = apSalesDetailWork.SlipMemo3;
            secSalesDetailWork.InsideMemo1 = apSalesDetailWork.InsideMemo1;
            secSalesDetailWork.InsideMemo2 = apSalesDetailWork.InsideMemo2;
            secSalesDetailWork.InsideMemo3 = apSalesDetailWork.InsideMemo3;
            secSalesDetailWork.BfListPrice = apSalesDetailWork.BfListPrice;
            secSalesDetailWork.BfSalesUnitPrice = apSalesDetailWork.BfSalesUnitPrice;
            secSalesDetailWork.BfUnitCost = apSalesDetailWork.BfUnitCost;
            secSalesDetailWork.CmpltSalesRowNo = apSalesDetailWork.CmpltSalesRowNo;
            secSalesDetailWork.CmpltGoodsMakerCd = apSalesDetailWork.CmpltGoodsMakerCd;
            secSalesDetailWork.CmpltMakerName = apSalesDetailWork.CmpltMakerName;
            secSalesDetailWork.CmpltMakerKanaName = apSalesDetailWork.CmpltMakerKanaName;
            secSalesDetailWork.CmpltGoodsName = apSalesDetailWork.CmpltGoodsName;
            secSalesDetailWork.CmpltShipmentCnt = apSalesDetailWork.CmpltShipmentCnt;
            secSalesDetailWork.CmpltSalesUnPrcFl = apSalesDetailWork.CmpltSalesUnPrcFl;
            secSalesDetailWork.CmpltSalesMoney = apSalesDetailWork.CmpltSalesMoney;
            secSalesDetailWork.CmpltSalesUnitCost = apSalesDetailWork.CmpltSalesUnitCost;
            secSalesDetailWork.CmpltCost = apSalesDetailWork.CmpltCost;
            secSalesDetailWork.CmpltPartySalSlNum = apSalesDetailWork.CmpltPartySalSlNum;
            secSalesDetailWork.CmpltNote = apSalesDetailWork.CmpltNote;
            secSalesDetailWork.PrtGoodsNo = apSalesDetailWork.PrtGoodsNo;
            secSalesDetailWork.PrtMakerCode = apSalesDetailWork.PrtMakerCode;
            secSalesDetailWork.PrtMakerName = apSalesDetailWork.PrtMakerName;

            return secSalesDetailWork;
        }

        /// <summary>
        /// 受信した売上明細から計上元明細データにコンバーター
        /// </summary>
        /// <param name="apSalesDetailWork">受信した売上明細</param>
        /// <returns>拠点側の計上元明細データ</returns>
        public AddUpOrgSalesDetailWork GetAddUpOrgSalesDetailWork(APSalesDetailWork apSalesDetailWork)
        {
            AddUpOrgSalesDetailWork addUpOrgSalesDetailWork = new AddUpOrgSalesDetailWork();

            addUpOrgSalesDetailWork.CreateDateTime = apSalesDetailWork.CreateDateTime;
            addUpOrgSalesDetailWork.UpdateDateTime = apSalesDetailWork.UpdateDateTime;
            addUpOrgSalesDetailWork.EnterpriseCode = apSalesDetailWork.EnterpriseCode;
            addUpOrgSalesDetailWork.FileHeaderGuid = apSalesDetailWork.FileHeaderGuid;
            addUpOrgSalesDetailWork.UpdEmployeeCode = apSalesDetailWork.UpdEmployeeCode;
            addUpOrgSalesDetailWork.UpdAssemblyId1 = apSalesDetailWork.UpdAssemblyId1;
            addUpOrgSalesDetailWork.UpdAssemblyId2 = apSalesDetailWork.UpdAssemblyId2;
            addUpOrgSalesDetailWork.LogicalDeleteCode = apSalesDetailWork.LogicalDeleteCode;
            addUpOrgSalesDetailWork.AcceptAnOrderNo = apSalesDetailWork.AcceptAnOrderNo;
            addUpOrgSalesDetailWork.AcptAnOdrStatus = apSalesDetailWork.AcptAnOdrStatus;
            addUpOrgSalesDetailWork.SalesSlipNum = apSalesDetailWork.SalesSlipNum;
            addUpOrgSalesDetailWork.SalesRowNo = apSalesDetailWork.SalesRowNo;
            addUpOrgSalesDetailWork.SalesRowDerivNo = apSalesDetailWork.SalesRowDerivNo;
            addUpOrgSalesDetailWork.SectionCode = apSalesDetailWork.SectionCode;
            addUpOrgSalesDetailWork.SubSectionCode = apSalesDetailWork.SubSectionCode;
            addUpOrgSalesDetailWork.SalesDate = apSalesDetailWork.SalesDate;
            addUpOrgSalesDetailWork.CommonSeqNo = apSalesDetailWork.CommonSeqNo;
            addUpOrgSalesDetailWork.SalesSlipDtlNum = apSalesDetailWork.SalesSlipDtlNum;
            addUpOrgSalesDetailWork.AcptAnOdrStatusSrc = apSalesDetailWork.AcptAnOdrStatusSrc;
            addUpOrgSalesDetailWork.SalesSlipDtlNumSrc = apSalesDetailWork.SalesSlipDtlNumSrc;
            addUpOrgSalesDetailWork.SupplierFormalSync = apSalesDetailWork.SupplierFormalSync;
            addUpOrgSalesDetailWork.StockSlipDtlNumSync = apSalesDetailWork.StockSlipDtlNumSync;
            addUpOrgSalesDetailWork.SalesSlipCdDtl = apSalesDetailWork.SalesSlipCdDtl;
            addUpOrgSalesDetailWork.DeliGdsCmpltDueDate = apSalesDetailWork.DeliGdsCmpltDueDate;
            addUpOrgSalesDetailWork.GoodsKindCode = apSalesDetailWork.GoodsKindCode;
            addUpOrgSalesDetailWork.GoodsSearchDivCd = apSalesDetailWork.GoodsSearchDivCd;
            addUpOrgSalesDetailWork.GoodsMakerCd = apSalesDetailWork.GoodsMakerCd;
            addUpOrgSalesDetailWork.MakerName = apSalesDetailWork.MakerName;
            addUpOrgSalesDetailWork.MakerKanaName = apSalesDetailWork.MakerKanaName;
            addUpOrgSalesDetailWork.GoodsNo = apSalesDetailWork.GoodsNo;
            addUpOrgSalesDetailWork.GoodsName = apSalesDetailWork.GoodsName;
            addUpOrgSalesDetailWork.GoodsNameKana = apSalesDetailWork.GoodsNameKana;
            addUpOrgSalesDetailWork.GoodsLGroup = apSalesDetailWork.GoodsLGroup;
            addUpOrgSalesDetailWork.GoodsLGroupName = apSalesDetailWork.GoodsLGroupName;
            addUpOrgSalesDetailWork.GoodsMGroup = apSalesDetailWork.GoodsMGroup;
            addUpOrgSalesDetailWork.GoodsMGroupName = apSalesDetailWork.GoodsMGroupName;
            addUpOrgSalesDetailWork.BLGroupCode = apSalesDetailWork.BLGroupCode;
            addUpOrgSalesDetailWork.BLGroupName = apSalesDetailWork.BLGroupName;
            addUpOrgSalesDetailWork.BLGoodsCode = apSalesDetailWork.BLGoodsCode;
            addUpOrgSalesDetailWork.BLGoodsFullName = apSalesDetailWork.BLGoodsFullName;
            addUpOrgSalesDetailWork.EnterpriseGanreCode = apSalesDetailWork.EnterpriseGanreCode;
            addUpOrgSalesDetailWork.EnterpriseGanreName = apSalesDetailWork.EnterpriseGanreName;
            addUpOrgSalesDetailWork.WarehouseCode = apSalesDetailWork.WarehouseCode;
            addUpOrgSalesDetailWork.WarehouseName = apSalesDetailWork.WarehouseName;
            addUpOrgSalesDetailWork.WarehouseShelfNo = apSalesDetailWork.WarehouseShelfNo;
            addUpOrgSalesDetailWork.SalesOrderDivCd = apSalesDetailWork.SalesOrderDivCd;
            addUpOrgSalesDetailWork.OpenPriceDiv = apSalesDetailWork.OpenPriceDiv;
            addUpOrgSalesDetailWork.GoodsRateRank = apSalesDetailWork.GoodsRateRank;
            addUpOrgSalesDetailWork.CustRateGrpCode = apSalesDetailWork.CustRateGrpCode;
            addUpOrgSalesDetailWork.ListPriceRate = apSalesDetailWork.ListPriceRate;
            addUpOrgSalesDetailWork.RateSectPriceUnPrc = apSalesDetailWork.RateSectPriceUnPrc;
            addUpOrgSalesDetailWork.RateDivLPrice = apSalesDetailWork.RateDivLPrice;
            addUpOrgSalesDetailWork.UnPrcCalcCdLPrice = apSalesDetailWork.UnPrcCalcCdLPrice;
            addUpOrgSalesDetailWork.PriceCdLPrice = apSalesDetailWork.PriceCdLPrice;
            addUpOrgSalesDetailWork.StdUnPrcLPrice = apSalesDetailWork.StdUnPrcLPrice;
            addUpOrgSalesDetailWork.FracProcUnitLPrice = apSalesDetailWork.FracProcUnitLPrice;
            addUpOrgSalesDetailWork.FracProcLPrice = apSalesDetailWork.FracProcLPrice;
            addUpOrgSalesDetailWork.ListPriceTaxIncFl = apSalesDetailWork.ListPriceTaxIncFl;
            addUpOrgSalesDetailWork.ListPriceTaxExcFl = apSalesDetailWork.ListPriceTaxExcFl;
            addUpOrgSalesDetailWork.ListPriceChngCd = apSalesDetailWork.ListPriceChngCd;
            addUpOrgSalesDetailWork.SalesRate = apSalesDetailWork.SalesRate;
            addUpOrgSalesDetailWork.RateSectSalUnPrc = apSalesDetailWork.RateSectSalUnPrc;
            addUpOrgSalesDetailWork.RateDivSalUnPrc = apSalesDetailWork.RateDivSalUnPrc;
            addUpOrgSalesDetailWork.UnPrcCalcCdSalUnPrc = apSalesDetailWork.UnPrcCalcCdSalUnPrc;
            addUpOrgSalesDetailWork.PriceCdSalUnPrc = apSalesDetailWork.PriceCdSalUnPrc;
            addUpOrgSalesDetailWork.StdUnPrcSalUnPrc = apSalesDetailWork.StdUnPrcSalUnPrc;
            addUpOrgSalesDetailWork.FracProcUnitSalUnPrc = apSalesDetailWork.FracProcUnitSalUnPrc;
            addUpOrgSalesDetailWork.FracProcSalUnPrc = apSalesDetailWork.FracProcSalUnPrc;
            addUpOrgSalesDetailWork.SalesUnPrcTaxIncFl = apSalesDetailWork.SalesUnPrcTaxIncFl;
            addUpOrgSalesDetailWork.SalesUnPrcTaxExcFl = apSalesDetailWork.SalesUnPrcTaxExcFl;
            addUpOrgSalesDetailWork.SalesUnPrcChngCd = apSalesDetailWork.SalesUnPrcChngCd;
            addUpOrgSalesDetailWork.CostRate = apSalesDetailWork.CostRate;
            addUpOrgSalesDetailWork.RateSectCstUnPrc = apSalesDetailWork.RateSectCstUnPrc;
            addUpOrgSalesDetailWork.RateDivUnCst = apSalesDetailWork.RateDivUnCst;
            addUpOrgSalesDetailWork.UnPrcCalcCdUnCst = apSalesDetailWork.UnPrcCalcCdUnCst;
            addUpOrgSalesDetailWork.PriceCdUnCst = apSalesDetailWork.PriceCdUnCst;
            addUpOrgSalesDetailWork.StdUnPrcUnCst = apSalesDetailWork.StdUnPrcUnCst;
            addUpOrgSalesDetailWork.FracProcUnitUnCst = apSalesDetailWork.FracProcUnitUnCst;
            addUpOrgSalesDetailWork.FracProcUnCst = apSalesDetailWork.FracProcUnCst;
            addUpOrgSalesDetailWork.SalesUnitCost = apSalesDetailWork.SalesUnitCost;
            addUpOrgSalesDetailWork.SalesUnitCostChngDiv = apSalesDetailWork.SalesUnitCostChngDiv;
            addUpOrgSalesDetailWork.RateBLGoodsCode = apSalesDetailWork.RateBLGoodsCode;
            addUpOrgSalesDetailWork.RateBLGoodsName = apSalesDetailWork.RateBLGoodsName;
            addUpOrgSalesDetailWork.RateGoodsRateGrpCd = apSalesDetailWork.RateGoodsRateGrpCd;
            addUpOrgSalesDetailWork.RateGoodsRateGrpNm = apSalesDetailWork.RateGoodsRateGrpNm;
            addUpOrgSalesDetailWork.RateBLGroupCode = apSalesDetailWork.RateBLGroupCode;
            addUpOrgSalesDetailWork.RateBLGroupName = apSalesDetailWork.RateBLGroupName;
            addUpOrgSalesDetailWork.PrtBLGoodsCode = apSalesDetailWork.PrtBLGoodsCode;
            addUpOrgSalesDetailWork.PrtBLGoodsName = apSalesDetailWork.PrtBLGoodsName;
            addUpOrgSalesDetailWork.SalesCode = apSalesDetailWork.SalesCode;
            addUpOrgSalesDetailWork.SalesCdNm = apSalesDetailWork.SalesCdNm;
            addUpOrgSalesDetailWork.WorkManHour = apSalesDetailWork.WorkManHour;
            addUpOrgSalesDetailWork.ShipmentCnt = apSalesDetailWork.ShipmentCnt;
            addUpOrgSalesDetailWork.AcceptAnOrderCnt = apSalesDetailWork.AcceptAnOrderCnt;
            addUpOrgSalesDetailWork.AcptAnOdrAdjustCnt = apSalesDetailWork.AcptAnOdrAdjustCnt;
            addUpOrgSalesDetailWork.AcptAnOdrRemainCnt = apSalesDetailWork.AcptAnOdrRemainCnt;
            addUpOrgSalesDetailWork.RemainCntUpdDate = apSalesDetailWork.RemainCntUpdDate;
            addUpOrgSalesDetailWork.SalesMoneyTaxInc = apSalesDetailWork.SalesMoneyTaxInc;
            addUpOrgSalesDetailWork.SalesMoneyTaxExc = apSalesDetailWork.SalesMoneyTaxExc;
            addUpOrgSalesDetailWork.Cost = apSalesDetailWork.Cost;
            addUpOrgSalesDetailWork.GrsProfitChkDiv = apSalesDetailWork.GrsProfitChkDiv;
            addUpOrgSalesDetailWork.SalesGoodsCd = apSalesDetailWork.SalesGoodsCd;
            addUpOrgSalesDetailWork.SalesPriceConsTax = apSalesDetailWork.SalesPriceConsTax;
            addUpOrgSalesDetailWork.TaxationDivCd = apSalesDetailWork.TaxationDivCd;
            addUpOrgSalesDetailWork.PartySlipNumDtl = apSalesDetailWork.PartySlipNumDtl;
            addUpOrgSalesDetailWork.DtlNote = apSalesDetailWork.DtlNote;
            addUpOrgSalesDetailWork.SupplierCd = apSalesDetailWork.SupplierCd;
            addUpOrgSalesDetailWork.SupplierSnm = apSalesDetailWork.SupplierSnm;
            addUpOrgSalesDetailWork.OrderNumber = apSalesDetailWork.OrderNumber;
            addUpOrgSalesDetailWork.WayToOrder = apSalesDetailWork.WayToOrder;
            addUpOrgSalesDetailWork.SlipMemo1 = apSalesDetailWork.SlipMemo1;
            addUpOrgSalesDetailWork.SlipMemo2 = apSalesDetailWork.SlipMemo2;
            addUpOrgSalesDetailWork.SlipMemo3 = apSalesDetailWork.SlipMemo3;
            addUpOrgSalesDetailWork.InsideMemo1 = apSalesDetailWork.InsideMemo1;
            addUpOrgSalesDetailWork.InsideMemo2 = apSalesDetailWork.InsideMemo2;
            addUpOrgSalesDetailWork.InsideMemo3 = apSalesDetailWork.InsideMemo3;
            addUpOrgSalesDetailWork.BfListPrice = apSalesDetailWork.BfListPrice;
            addUpOrgSalesDetailWork.BfSalesUnitPrice = apSalesDetailWork.BfSalesUnitPrice;
            addUpOrgSalesDetailWork.BfUnitCost = apSalesDetailWork.BfUnitCost;
            addUpOrgSalesDetailWork.CmpltSalesRowNo = apSalesDetailWork.CmpltSalesRowNo;
            addUpOrgSalesDetailWork.CmpltGoodsMakerCd = apSalesDetailWork.CmpltGoodsMakerCd;
            addUpOrgSalesDetailWork.CmpltMakerName = apSalesDetailWork.CmpltMakerName;
            addUpOrgSalesDetailWork.CmpltMakerKanaName = apSalesDetailWork.CmpltMakerKanaName;
            addUpOrgSalesDetailWork.CmpltGoodsName = apSalesDetailWork.CmpltGoodsName;
            addUpOrgSalesDetailWork.CmpltShipmentCnt = apSalesDetailWork.CmpltShipmentCnt;
            addUpOrgSalesDetailWork.CmpltSalesUnPrcFl = apSalesDetailWork.CmpltSalesUnPrcFl;
            addUpOrgSalesDetailWork.CmpltSalesMoney = apSalesDetailWork.CmpltSalesMoney;
            addUpOrgSalesDetailWork.CmpltSalesUnitCost = apSalesDetailWork.CmpltSalesUnitCost;
            addUpOrgSalesDetailWork.CmpltCost = apSalesDetailWork.CmpltCost;
            addUpOrgSalesDetailWork.CmpltPartySalSlNum = apSalesDetailWork.CmpltPartySalSlNum;
            addUpOrgSalesDetailWork.CmpltNote = apSalesDetailWork.CmpltNote;
            addUpOrgSalesDetailWork.PrtGoodsNo = apSalesDetailWork.PrtGoodsNo;
            addUpOrgSalesDetailWork.PrtMakerCode = apSalesDetailWork.PrtMakerCode;
            addUpOrgSalesDetailWork.PrtMakerName = apSalesDetailWork.PrtMakerName;

            return addUpOrgSalesDetailWork;
        }
    }
}
