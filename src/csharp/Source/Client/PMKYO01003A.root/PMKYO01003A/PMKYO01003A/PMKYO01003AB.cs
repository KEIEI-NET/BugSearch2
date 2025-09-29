using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// データ送信処理のデータ変換スクラス
    /// </summary>
    /// <remarks>
	/// <br>Note       : データ送信処理のデータ変換です。</br>
	/// <br>Programmer : 譚洪</br>
	/// <br>Date       : 2009.04.02</br>
    /// <br>Update Note  : 2009/09/14 馮文雄</br>
	/// <br>             :     PM.NS-2-A.車輌管理</br>
	/// <br>             :     受注マスタ（車両）に車輌備考の追加</br>
	/// <br>Update Note  : 2011/09/15 張莉莉</br>
	/// <br>             :     #24923　ファイルレイアウト変更による項目追加対応</br>
    /// <br>Update Note  : SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
    /// <br>Programmer   : FSI厚川 宏</br>
    /// <br>Date         : 2013/03/22</br>
    /// <br>管理番号     : 10900269-00</br>
    /// <br>Update Note  : PMKOBETSU-3877の対応</br>
    /// <br>Programmer   : 譚洪</br>
    /// <br>Date         : 2020/09/25</br>
    /// <br>管理番号     : 11600006-00</br>
    /// </remarks>
    public class ConvertReceive
    {
        /// <summary>
        /// 売上データPramData→UIData移項処理
        /// </summary>
        /// <param name="salesSlipWork">売上データ</param>
        /// <returns>DC売上データ</returns>
        public static DCSalesSlipWork SearchDataFromUpdateData(APSalesSlipWork salesSlipWork)
        {
            if (salesSlipWork == null)
            {
                return null;
            }

            DCSalesSlipWork dcSalesSlipWork = new DCSalesSlipWork();
            // 売上データ変換
            dcSalesSlipWork.CreateDateTime = salesSlipWork.CreateDateTime;
            dcSalesSlipWork.UpdateDateTime = salesSlipWork.UpdateDateTime;
            dcSalesSlipWork.EnterpriseCode = salesSlipWork.EnterpriseCode;
            dcSalesSlipWork.FileHeaderGuid = salesSlipWork.FileHeaderGuid;
            dcSalesSlipWork.UpdEmployeeCode = salesSlipWork.UpdEmployeeCode;
            dcSalesSlipWork.UpdAssemblyId1 = salesSlipWork.UpdAssemblyId1;
            dcSalesSlipWork.UpdAssemblyId2 = salesSlipWork.UpdAssemblyId2;
            dcSalesSlipWork.LogicalDeleteCode = salesSlipWork.LogicalDeleteCode;
            dcSalesSlipWork.AcptAnOdrStatus = salesSlipWork.AcptAnOdrStatus;
            dcSalesSlipWork.SalesSlipNum = salesSlipWork.SalesSlipNum;
            dcSalesSlipWork.SectionCode = salesSlipWork.SectionCode;
            dcSalesSlipWork.SubSectionCode = salesSlipWork.SubSectionCode;
            dcSalesSlipWork.DebitNoteDiv = salesSlipWork.DebitNoteDiv;
            dcSalesSlipWork.DebitNLnkSalesSlNum = salesSlipWork.DebitNLnkSalesSlNum;
            dcSalesSlipWork.SalesSlipCd = salesSlipWork.SalesSlipCd;
            dcSalesSlipWork.SalesGoodsCd = salesSlipWork.SalesGoodsCd;
            dcSalesSlipWork.AccRecDivCd = salesSlipWork.AccRecDivCd;
            dcSalesSlipWork.SalesInpSecCd = salesSlipWork.SalesInpSecCd;
            dcSalesSlipWork.DemandAddUpSecCd = salesSlipWork.DemandAddUpSecCd;
            dcSalesSlipWork.ResultsAddUpSecCd = salesSlipWork.ResultsAddUpSecCd;
            dcSalesSlipWork.UpdateSecCd = salesSlipWork.UpdateSecCd;
            dcSalesSlipWork.SalesSlipUpdateCd = salesSlipWork.SalesSlipUpdateCd;
            dcSalesSlipWork.SearchSlipDate = salesSlipWork.SearchSlipDate;
            dcSalesSlipWork.ShipmentDay = salesSlipWork.ShipmentDay;
            dcSalesSlipWork.SalesDate = salesSlipWork.SalesDate;
            dcSalesSlipWork.AddUpADate = salesSlipWork.AddUpADate;
            dcSalesSlipWork.DelayPaymentDiv = salesSlipWork.DelayPaymentDiv;
            dcSalesSlipWork.EstimateFormNo = salesSlipWork.EstimateFormNo;
            dcSalesSlipWork.EstimateDivide = salesSlipWork.EstimateDivide;
            dcSalesSlipWork.InputAgenCd = salesSlipWork.InputAgenCd;
            dcSalesSlipWork.InputAgenNm = salesSlipWork.InputAgenNm;
            dcSalesSlipWork.SalesInputCode = salesSlipWork.SalesInputCode;
            dcSalesSlipWork.SalesInputName = salesSlipWork.SalesInputName;
            dcSalesSlipWork.FrontEmployeeCd = salesSlipWork.FrontEmployeeCd;
            dcSalesSlipWork.FrontEmployeeNm = salesSlipWork.FrontEmployeeNm;
            dcSalesSlipWork.SalesEmployeeCd = salesSlipWork.SalesEmployeeCd;
            dcSalesSlipWork.SalesEmployeeNm = salesSlipWork.SalesEmployeeNm;
            dcSalesSlipWork.TotalAmountDispWayCd = salesSlipWork.TotalAmountDispWayCd;
            dcSalesSlipWork.TtlAmntDispRateApy = salesSlipWork.TtlAmntDispRateApy;
            dcSalesSlipWork.SalesTotalTaxInc = salesSlipWork.SalesTotalTaxInc;
            dcSalesSlipWork.SalesTotalTaxExc = salesSlipWork.SalesTotalTaxExc;
            dcSalesSlipWork.SalesPrtTotalTaxInc = salesSlipWork.SalesPrtTotalTaxInc;
            dcSalesSlipWork.SalesPrtTotalTaxExc = salesSlipWork.SalesPrtTotalTaxExc;
            dcSalesSlipWork.SalesWorkTotalTaxInc = salesSlipWork.SalesWorkTotalTaxInc;
            dcSalesSlipWork.SalesWorkTotalTaxExc = salesSlipWork.SalesWorkTotalTaxExc;
            dcSalesSlipWork.SalesSubtotalTaxInc = salesSlipWork.SalesSubtotalTaxInc;
            dcSalesSlipWork.SalesSubtotalTaxExc = salesSlipWork.SalesSubtotalTaxExc;
            dcSalesSlipWork.SalesPrtSubttlInc = salesSlipWork.SalesPrtSubttlInc;
            dcSalesSlipWork.SalesPrtSubttlExc = salesSlipWork.SalesPrtSubttlExc;
            dcSalesSlipWork.SalesWorkSubttlInc = salesSlipWork.SalesWorkSubttlInc;
            dcSalesSlipWork.SalesWorkSubttlExc = salesSlipWork.SalesWorkSubttlExc;
            dcSalesSlipWork.SalesNetPrice = salesSlipWork.SalesNetPrice;
            dcSalesSlipWork.SalesSubtotalTax = salesSlipWork.SalesSubtotalTax;
            dcSalesSlipWork.ItdedSalesOutTax = salesSlipWork.ItdedSalesOutTax;
            dcSalesSlipWork.ItdedSalesInTax = salesSlipWork.ItdedSalesInTax;
            dcSalesSlipWork.SalSubttlSubToTaxFre = salesSlipWork.SalSubttlSubToTaxFre;
            dcSalesSlipWork.SalesOutTax = salesSlipWork.SalesOutTax;
            dcSalesSlipWork.SalAmntConsTaxInclu = salesSlipWork.SalAmntConsTaxInclu;
            dcSalesSlipWork.SalesDisTtlTaxExc = salesSlipWork.SalesDisTtlTaxExc;
            dcSalesSlipWork.ItdedSalesDisOutTax = salesSlipWork.ItdedSalesDisOutTax;
            dcSalesSlipWork.ItdedSalesDisInTax = salesSlipWork.ItdedSalesDisInTax;
            dcSalesSlipWork.ItdedPartsDisOutTax = salesSlipWork.ItdedPartsDisOutTax;
            dcSalesSlipWork.ItdedPartsDisInTax = salesSlipWork.ItdedPartsDisInTax;
            dcSalesSlipWork.ItdedWorkDisOutTax = salesSlipWork.ItdedWorkDisOutTax;
            dcSalesSlipWork.ItdedWorkDisInTax = salesSlipWork.ItdedWorkDisInTax;
            dcSalesSlipWork.ItdedSalesDisTaxFre = salesSlipWork.ItdedSalesDisTaxFre;
            dcSalesSlipWork.SalesDisOutTax = salesSlipWork.SalesDisOutTax;
            dcSalesSlipWork.SalesDisTtlTaxInclu = salesSlipWork.SalesDisTtlTaxInclu;
            dcSalesSlipWork.PartsDiscountRate = salesSlipWork.PartsDiscountRate;
            dcSalesSlipWork.RavorDiscountRate = salesSlipWork.RavorDiscountRate;
            dcSalesSlipWork.TotalCost = salesSlipWork.TotalCost;
            dcSalesSlipWork.ConsTaxLayMethod = salesSlipWork.ConsTaxLayMethod;
            dcSalesSlipWork.ConsTaxRate = salesSlipWork.ConsTaxRate;
            dcSalesSlipWork.FractionProcCd = salesSlipWork.FractionProcCd;
            dcSalesSlipWork.AccRecConsTax = salesSlipWork.AccRecConsTax;
            dcSalesSlipWork.AutoDepositCd = salesSlipWork.AutoDepositCd;
            dcSalesSlipWork.AutoDepositSlipNo = salesSlipWork.AutoDepositSlipNo;
            dcSalesSlipWork.DepositAllowanceTtl = salesSlipWork.DepositAllowanceTtl;
            dcSalesSlipWork.DepositAlwcBlnce = salesSlipWork.DepositAlwcBlnce;
            dcSalesSlipWork.ClaimCode = salesSlipWork.ClaimCode;
            dcSalesSlipWork.ClaimSnm = salesSlipWork.ClaimSnm;
            dcSalesSlipWork.CustomerCode = salesSlipWork.CustomerCode;
            dcSalesSlipWork.CustomerName = salesSlipWork.CustomerName;
            dcSalesSlipWork.CustomerName2 = salesSlipWork.CustomerName2;
            dcSalesSlipWork.CustomerSnm = salesSlipWork.CustomerSnm;
            dcSalesSlipWork.HonorificTitle = salesSlipWork.HonorificTitle;
            dcSalesSlipWork.OutputNameCode = salesSlipWork.OutputNameCode;
            dcSalesSlipWork.OutputName = salesSlipWork.OutputName;
            dcSalesSlipWork.CustSlipNo = salesSlipWork.CustSlipNo;
            dcSalesSlipWork.SlipAddressDiv = salesSlipWork.SlipAddressDiv;
            dcSalesSlipWork.AddresseeCode = salesSlipWork.AddresseeCode;
            dcSalesSlipWork.AddresseeName = salesSlipWork.AddresseeName;
            dcSalesSlipWork.AddresseeName2 = salesSlipWork.AddresseeName2;
            dcSalesSlipWork.AddresseePostNo = salesSlipWork.AddresseePostNo;
            dcSalesSlipWork.AddresseeAddr1 = salesSlipWork.AddresseeAddr1;
            dcSalesSlipWork.AddresseeAddr3 = salesSlipWork.AddresseeAddr3;
            dcSalesSlipWork.AddresseeAddr4 = salesSlipWork.AddresseeAddr4;
            dcSalesSlipWork.AddresseeTelNo = salesSlipWork.AddresseeTelNo;
            dcSalesSlipWork.AddresseeFaxNo = salesSlipWork.AddresseeFaxNo;
            dcSalesSlipWork.PartySaleSlipNum = salesSlipWork.PartySaleSlipNum;
            dcSalesSlipWork.SlipNote = salesSlipWork.SlipNote;
            dcSalesSlipWork.SlipNote2 = salesSlipWork.SlipNote2;
            dcSalesSlipWork.SlipNote3 = salesSlipWork.SlipNote3;
            dcSalesSlipWork.RetGoodsReasonDiv = salesSlipWork.RetGoodsReasonDiv;
            dcSalesSlipWork.RetGoodsReason = salesSlipWork.RetGoodsReason;
            dcSalesSlipWork.RegiProcDate = salesSlipWork.RegiProcDate;
            dcSalesSlipWork.CashRegisterNo = salesSlipWork.CashRegisterNo;
            dcSalesSlipWork.PosReceiptNo = salesSlipWork.PosReceiptNo;
            dcSalesSlipWork.DetailRowCount = salesSlipWork.DetailRowCount;
            dcSalesSlipWork.EdiSendDate = salesSlipWork.EdiSendDate;
            dcSalesSlipWork.EdiTakeInDate = salesSlipWork.EdiTakeInDate;
            dcSalesSlipWork.UoeRemark1 = salesSlipWork.UoeRemark1;
            dcSalesSlipWork.UoeRemark2 = salesSlipWork.UoeRemark2;
            dcSalesSlipWork.SlipPrintDivCd = salesSlipWork.SlipPrintDivCd;
            dcSalesSlipWork.SlipPrintFinishCd = salesSlipWork.SlipPrintFinishCd;
            dcSalesSlipWork.SalesSlipPrintDate = salesSlipWork.SalesSlipPrintDate;
            dcSalesSlipWork.BusinessTypeCode = salesSlipWork.BusinessTypeCode;
            dcSalesSlipWork.BusinessTypeName = salesSlipWork.BusinessTypeName;
            dcSalesSlipWork.OrderNumber = salesSlipWork.OrderNumber;
            dcSalesSlipWork.DeliveredGoodsDiv = salesSlipWork.DeliveredGoodsDiv;
            dcSalesSlipWork.DeliveredGoodsDivNm = salesSlipWork.DeliveredGoodsDivNm;
            dcSalesSlipWork.SalesAreaCode = salesSlipWork.SalesAreaCode;
            dcSalesSlipWork.SalesAreaName = salesSlipWork.SalesAreaName;
            dcSalesSlipWork.ReconcileFlag = salesSlipWork.ReconcileFlag;
            dcSalesSlipWork.SlipPrtSetPaperId = salesSlipWork.SlipPrtSetPaperId;
            dcSalesSlipWork.CompleteCd = salesSlipWork.CompleteCd;
            dcSalesSlipWork.SalesPriceFracProcCd = salesSlipWork.SalesPriceFracProcCd;
            dcSalesSlipWork.StockGoodsTtlTaxExc = salesSlipWork.StockGoodsTtlTaxExc;
            dcSalesSlipWork.PureGoodsTtlTaxExc = salesSlipWork.PureGoodsTtlTaxExc;
            dcSalesSlipWork.ListPricePrintDiv = salesSlipWork.ListPricePrintDiv;
            dcSalesSlipWork.EraNameDispCd1 = salesSlipWork.EraNameDispCd1;
            dcSalesSlipWork.EstimaTaxDivCd = salesSlipWork.EstimaTaxDivCd;
            dcSalesSlipWork.EstimateFormPrtCd = salesSlipWork.EstimateFormPrtCd;
            dcSalesSlipWork.EstimateSubject = salesSlipWork.EstimateSubject;
            dcSalesSlipWork.Footnotes1 = salesSlipWork.Footnotes1;
            dcSalesSlipWork.Footnotes2 = salesSlipWork.Footnotes2;
            dcSalesSlipWork.EstimateTitle1 = salesSlipWork.EstimateTitle1;
            dcSalesSlipWork.EstimateTitle2 = salesSlipWork.EstimateTitle2;
            dcSalesSlipWork.EstimateTitle3 = salesSlipWork.EstimateTitle3;
            dcSalesSlipWork.EstimateTitle4 = salesSlipWork.EstimateTitle4;
            dcSalesSlipWork.EstimateTitle5 = salesSlipWork.EstimateTitle5;
            dcSalesSlipWork.EstimateNote1 = salesSlipWork.EstimateNote1;
            dcSalesSlipWork.EstimateNote2 = salesSlipWork.EstimateNote2;
            dcSalesSlipWork.EstimateNote3 = salesSlipWork.EstimateNote3;
            dcSalesSlipWork.EstimateNote4 = salesSlipWork.EstimateNote4;
            dcSalesSlipWork.EstimateNote5 = salesSlipWork.EstimateNote5;
            dcSalesSlipWork.EstimateValidityDate = salesSlipWork.EstimateValidityDate;
            dcSalesSlipWork.PartsNoPrtCd = salesSlipWork.PartsNoPrtCd;
            dcSalesSlipWork.OptionPringDivCd = salesSlipWork.OptionPringDivCd;
            dcSalesSlipWork.RateUseCode = salesSlipWork.RateUseCode;

            return dcSalesSlipWork;
        }

        /// <summary>
        /// 売上明細データPramData→UIData移項処理
        /// </summary>
        /// <param name="salesDetailWork">売上明細データ</param>
        /// <returns>売上明細データ</returns>
        /// <br>Update Note: PMKOBETSU-3877の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/09/25</br>
        public static DCSalesDetailWork SearchDataFromUpdateData(APSalesDetailWork salesDetailWork)
        {
            if (salesDetailWork == null)
            {
                return null;
            }

            DCSalesDetailWork dcSalesDetailWork = new DCSalesDetailWork();

            // 売上明細データ変換
            dcSalesDetailWork.CreateDateTime = salesDetailWork.CreateDateTime;
            dcSalesDetailWork.UpdateDateTime = salesDetailWork.UpdateDateTime;
            dcSalesDetailWork.EnterpriseCode = salesDetailWork.EnterpriseCode;
            dcSalesDetailWork.FileHeaderGuid = salesDetailWork.FileHeaderGuid;
            dcSalesDetailWork.UpdEmployeeCode = salesDetailWork.UpdEmployeeCode;
            dcSalesDetailWork.UpdAssemblyId1 = salesDetailWork.UpdAssemblyId1;
            dcSalesDetailWork.UpdAssemblyId2 = salesDetailWork.UpdAssemblyId2;
            dcSalesDetailWork.LogicalDeleteCode = salesDetailWork.LogicalDeleteCode;
            dcSalesDetailWork.AcceptAnOrderNo = salesDetailWork.AcceptAnOrderNo;
            dcSalesDetailWork.AcptAnOdrStatus = salesDetailWork.AcptAnOdrStatus;
            dcSalesDetailWork.SalesSlipNum = salesDetailWork.SalesSlipNum;
            dcSalesDetailWork.SalesRowNo = salesDetailWork.SalesRowNo;
            dcSalesDetailWork.SalesRowDerivNo = salesDetailWork.SalesRowDerivNo;
            dcSalesDetailWork.SectionCode = salesDetailWork.SectionCode;
            dcSalesDetailWork.SubSectionCode = salesDetailWork.SubSectionCode;
            dcSalesDetailWork.SalesDate = salesDetailWork.SalesDate;
            dcSalesDetailWork.CommonSeqNo = salesDetailWork.CommonSeqNo;
            dcSalesDetailWork.SalesSlipDtlNum = salesDetailWork.SalesSlipDtlNum;
            dcSalesDetailWork.AcptAnOdrStatusSrc = salesDetailWork.AcptAnOdrStatusSrc;
            dcSalesDetailWork.SalesSlipDtlNumSrc = salesDetailWork.SalesSlipDtlNumSrc;
            dcSalesDetailWork.SupplierFormalSync = salesDetailWork.SupplierFormalSync;
            dcSalesDetailWork.StockSlipDtlNumSync = salesDetailWork.StockSlipDtlNumSync;
            dcSalesDetailWork.SalesSlipCdDtl = salesDetailWork.SalesSlipCdDtl;
            dcSalesDetailWork.DeliGdsCmpltDueDate = salesDetailWork.DeliGdsCmpltDueDate;
            dcSalesDetailWork.GoodsKindCode = salesDetailWork.GoodsKindCode;
            dcSalesDetailWork.GoodsSearchDivCd = salesDetailWork.GoodsSearchDivCd;
            dcSalesDetailWork.GoodsMakerCd = salesDetailWork.GoodsMakerCd;
            dcSalesDetailWork.MakerName = salesDetailWork.MakerName;
            dcSalesDetailWork.MakerKanaName = salesDetailWork.MakerKanaName;
            dcSalesDetailWork.GoodsNo = salesDetailWork.GoodsNo;
            dcSalesDetailWork.GoodsName = salesDetailWork.GoodsName;
            dcSalesDetailWork.GoodsNameKana = salesDetailWork.GoodsNameKana;
            dcSalesDetailWork.GoodsLGroup = salesDetailWork.GoodsLGroup;
            dcSalesDetailWork.GoodsLGroupName = salesDetailWork.GoodsLGroupName;
            dcSalesDetailWork.GoodsMGroup = salesDetailWork.GoodsMGroup;
            dcSalesDetailWork.GoodsMGroupName = salesDetailWork.GoodsMGroupName;
            dcSalesDetailWork.BLGroupCode = salesDetailWork.BLGroupCode;
            dcSalesDetailWork.BLGroupName = salesDetailWork.BLGroupName;
            dcSalesDetailWork.BLGoodsCode = salesDetailWork.BLGoodsCode;
            dcSalesDetailWork.BLGoodsFullName = salesDetailWork.BLGoodsFullName;
            dcSalesDetailWork.EnterpriseGanreCode = salesDetailWork.EnterpriseGanreCode;
            dcSalesDetailWork.EnterpriseGanreName = salesDetailWork.EnterpriseGanreName;
            dcSalesDetailWork.WarehouseCode = salesDetailWork.WarehouseCode;
            dcSalesDetailWork.WarehouseName = salesDetailWork.WarehouseName;
            dcSalesDetailWork.WarehouseShelfNo = salesDetailWork.WarehouseShelfNo;
            dcSalesDetailWork.SalesOrderDivCd = salesDetailWork.SalesOrderDivCd;
            dcSalesDetailWork.OpenPriceDiv = salesDetailWork.OpenPriceDiv;
            dcSalesDetailWork.GoodsRateRank = salesDetailWork.GoodsRateRank;
            dcSalesDetailWork.CustRateGrpCode = salesDetailWork.CustRateGrpCode;
            dcSalesDetailWork.ListPriceRate = salesDetailWork.ListPriceRate;
            dcSalesDetailWork.RateSectPriceUnPrc = salesDetailWork.RateSectPriceUnPrc;
            dcSalesDetailWork.RateDivLPrice = salesDetailWork.RateDivLPrice;
            dcSalesDetailWork.UnPrcCalcCdLPrice = salesDetailWork.UnPrcCalcCdLPrice;
            dcSalesDetailWork.PriceCdLPrice = salesDetailWork.PriceCdLPrice;
            dcSalesDetailWork.StdUnPrcLPrice = salesDetailWork.StdUnPrcLPrice;
            dcSalesDetailWork.FracProcUnitLPrice = salesDetailWork.FracProcUnitLPrice;
            dcSalesDetailWork.FracProcLPrice = salesDetailWork.FracProcLPrice;
            dcSalesDetailWork.ListPriceTaxIncFl = salesDetailWork.ListPriceTaxIncFl;
            dcSalesDetailWork.ListPriceTaxExcFl = salesDetailWork.ListPriceTaxExcFl;
            dcSalesDetailWork.ListPriceChngCd = salesDetailWork.ListPriceChngCd;
            dcSalesDetailWork.SalesRate = salesDetailWork.SalesRate;
            dcSalesDetailWork.RateSectSalUnPrc = salesDetailWork.RateSectSalUnPrc;
            dcSalesDetailWork.RateDivSalUnPrc = salesDetailWork.RateDivSalUnPrc;
            dcSalesDetailWork.UnPrcCalcCdSalUnPrc = salesDetailWork.UnPrcCalcCdSalUnPrc;
            dcSalesDetailWork.PriceCdSalUnPrc = salesDetailWork.PriceCdSalUnPrc;
            dcSalesDetailWork.StdUnPrcSalUnPrc = salesDetailWork.StdUnPrcSalUnPrc;
            dcSalesDetailWork.FracProcUnitSalUnPrc = salesDetailWork.FracProcUnitSalUnPrc;
            dcSalesDetailWork.FracProcSalUnPrc = salesDetailWork.FracProcSalUnPrc;
            dcSalesDetailWork.SalesUnPrcTaxIncFl = salesDetailWork.SalesUnPrcTaxIncFl;
            dcSalesDetailWork.SalesUnPrcTaxExcFl = salesDetailWork.SalesUnPrcTaxExcFl;
            dcSalesDetailWork.SalesUnPrcChngCd = salesDetailWork.SalesUnPrcChngCd;
            dcSalesDetailWork.CostRate = salesDetailWork.CostRate;
            dcSalesDetailWork.RateSectCstUnPrc = salesDetailWork.RateSectCstUnPrc;
            dcSalesDetailWork.RateDivUnCst = salesDetailWork.RateDivUnCst;
            dcSalesDetailWork.UnPrcCalcCdUnCst = salesDetailWork.UnPrcCalcCdUnCst;
            dcSalesDetailWork.PriceCdUnCst = salesDetailWork.PriceCdUnCst;
            dcSalesDetailWork.StdUnPrcUnCst = salesDetailWork.StdUnPrcUnCst;
            dcSalesDetailWork.FracProcUnitUnCst = salesDetailWork.FracProcUnitUnCst;
            dcSalesDetailWork.FracProcUnCst = salesDetailWork.FracProcUnCst;
            dcSalesDetailWork.SalesUnitCost = salesDetailWork.SalesUnitCost;
            dcSalesDetailWork.SalesUnitCostChngDiv = salesDetailWork.SalesUnitCostChngDiv;
            dcSalesDetailWork.RateBLGoodsCode = salesDetailWork.RateBLGoodsCode;
            dcSalesDetailWork.RateBLGoodsName = salesDetailWork.RateBLGoodsName;
            dcSalesDetailWork.RateGoodsRateGrpCd = salesDetailWork.RateGoodsRateGrpCd;
            dcSalesDetailWork.RateGoodsRateGrpNm = salesDetailWork.RateGoodsRateGrpNm;
            dcSalesDetailWork.RateBLGroupCode = salesDetailWork.RateBLGroupCode;
            dcSalesDetailWork.RateBLGroupName = salesDetailWork.RateBLGroupName;
            dcSalesDetailWork.PrtBLGoodsCode = salesDetailWork.PrtBLGoodsCode;
            dcSalesDetailWork.PrtBLGoodsName = salesDetailWork.PrtBLGoodsName;
            dcSalesDetailWork.SalesCode = salesDetailWork.SalesCode;
            dcSalesDetailWork.SalesCdNm = salesDetailWork.SalesCdNm;
            dcSalesDetailWork.WorkManHour = salesDetailWork.WorkManHour;
            dcSalesDetailWork.ShipmentCnt = salesDetailWork.ShipmentCnt;
            dcSalesDetailWork.AcceptAnOrderCnt = salesDetailWork.AcceptAnOrderCnt;
            dcSalesDetailWork.AcptAnOdrAdjustCnt = salesDetailWork.AcptAnOdrAdjustCnt;
            dcSalesDetailWork.AcptAnOdrRemainCnt = salesDetailWork.AcptAnOdrRemainCnt;
            dcSalesDetailWork.RemainCntUpdDate = salesDetailWork.RemainCntUpdDate;
            dcSalesDetailWork.SalesMoneyTaxInc = salesDetailWork.SalesMoneyTaxInc;
            dcSalesDetailWork.SalesMoneyTaxExc = salesDetailWork.SalesMoneyTaxExc;
            dcSalesDetailWork.Cost = salesDetailWork.Cost;
            dcSalesDetailWork.GrsProfitChkDiv = salesDetailWork.GrsProfitChkDiv;
            dcSalesDetailWork.SalesGoodsCd = salesDetailWork.SalesGoodsCd;
            dcSalesDetailWork.SalesPriceConsTax = salesDetailWork.SalesPriceConsTax;
            dcSalesDetailWork.TaxationDivCd = salesDetailWork.TaxationDivCd;
            dcSalesDetailWork.PartySlipNumDtl = salesDetailWork.PartySlipNumDtl;
            dcSalesDetailWork.DtlNote = salesDetailWork.DtlNote;
            dcSalesDetailWork.SupplierCd = salesDetailWork.SupplierCd;
            dcSalesDetailWork.SupplierSnm = salesDetailWork.SupplierSnm;
            dcSalesDetailWork.OrderNumber = salesDetailWork.OrderNumber;
            dcSalesDetailWork.WayToOrder = salesDetailWork.WayToOrder;
            dcSalesDetailWork.SlipMemo1 = salesDetailWork.SlipMemo1;
            dcSalesDetailWork.SlipMemo2 = salesDetailWork.SlipMemo2;
            dcSalesDetailWork.SlipMemo3 = salesDetailWork.SlipMemo3;
            dcSalesDetailWork.InsideMemo1 = salesDetailWork.InsideMemo1;
            dcSalesDetailWork.InsideMemo2 = salesDetailWork.InsideMemo2;
            dcSalesDetailWork.InsideMemo3 = salesDetailWork.InsideMemo3;
            dcSalesDetailWork.BfListPrice = salesDetailWork.BfListPrice;
            dcSalesDetailWork.BfSalesUnitPrice = salesDetailWork.BfSalesUnitPrice;
            dcSalesDetailWork.BfUnitCost = salesDetailWork.BfUnitCost;
            dcSalesDetailWork.CmpltSalesRowNo = salesDetailWork.CmpltSalesRowNo;
            dcSalesDetailWork.CmpltGoodsMakerCd = salesDetailWork.CmpltGoodsMakerCd;
            dcSalesDetailWork.CmpltMakerName = salesDetailWork.CmpltMakerName;
            dcSalesDetailWork.CmpltMakerKanaName = salesDetailWork.CmpltMakerKanaName;
            dcSalesDetailWork.CmpltGoodsName = salesDetailWork.CmpltGoodsName;
            dcSalesDetailWork.CmpltShipmentCnt = salesDetailWork.CmpltShipmentCnt;
            dcSalesDetailWork.CmpltSalesUnPrcFl = salesDetailWork.CmpltSalesUnPrcFl;
            dcSalesDetailWork.CmpltSalesMoney = salesDetailWork.CmpltSalesMoney;
            dcSalesDetailWork.CmpltSalesUnitCost = salesDetailWork.CmpltSalesUnitCost;
            dcSalesDetailWork.CmpltCost = salesDetailWork.CmpltCost;
            dcSalesDetailWork.CmpltPartySalSlNum = salesDetailWork.CmpltPartySalSlNum;
            dcSalesDetailWork.CmpltNote = salesDetailWork.CmpltNote;
            dcSalesDetailWork.PrtGoodsNo = salesDetailWork.PrtGoodsNo;
            dcSalesDetailWork.PrtMakerCode = salesDetailWork.PrtMakerCode;
            dcSalesDetailWork.PrtMakerName = salesDetailWork.PrtMakerName;
            // ↓ 2009.05.26 liuyang add
            dcSalesDetailWork.CampaignCode = salesDetailWork.CampaignCode;
            dcSalesDetailWork.CampaignName = salesDetailWork.CampaignName;
            dcSalesDetailWork.GoodsDivCd = salesDetailWork.GoodsDivCd;
            dcSalesDetailWork.AnswerDelivDate = salesDetailWork.AnswerDelivDate;
            dcSalesDetailWork.RecycleDiv = salesDetailWork.RecycleDiv;
            dcSalesDetailWork.RecycleDivNm = salesDetailWork.RecycleDivNm;
            dcSalesDetailWork.WayToAcptOdr = salesDetailWork.WayToAcptOdr;
            // ↑ 2009.05.26 liuyang add

			// ADD 2011/09/15 ---------- >>>>>
			dcSalesDetailWork.AutoAnswerDivSCM = salesDetailWork.AutoAnswerDivSCM;
			dcSalesDetailWork.AcceptOrOrderKind = salesDetailWork.AcceptOrOrderKind;
			dcSalesDetailWork.InquiryNumber = salesDetailWork.InquiryNumber;
			dcSalesDetailWork.InqRowNumber = salesDetailWork.InqRowNumber;
			// ADD 2011/09/15 ---------- <<<<<
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 ----->>>>>
            dcSalesDetailWork.RentSyncSupplier = salesDetailWork.RentSyncSupplier; // 貸出同時仕入先
            dcSalesDetailWork.RentSyncStockDate = salesDetailWork.RentSyncStockDate; // 貸出同時仕入日
            dcSalesDetailWork.RentSyncSupSlipNo = salesDetailWork.RentSyncSupSlipNo; // 貸出同時仕入伝票番号
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 -----<<<<<
            return dcSalesDetailWork;
        }

        /// <summary>
        /// 売上履歴データPramData→UIData移項処理
        /// </summary>
        /// <param name="salesHistoryWork">売上履歴データ</param>
        /// <returns>DC売上履歴データ</returns>
        public static DCSalesHistoryWork SearchDataFromUpdateData(APSalesHistoryWork salesHistoryWork)
        {
            if (salesHistoryWork == null)
            {
                return null;
            }

            DCSalesHistoryWork dcSalesHistoryWork = new DCSalesHistoryWork();

            // 売上履歴データ変換
            dcSalesHistoryWork.CreateDateTime = salesHistoryWork.CreateDateTime;
            dcSalesHistoryWork.UpdateDateTime = salesHistoryWork.UpdateDateTime;
            dcSalesHistoryWork.EnterpriseCode = salesHistoryWork.EnterpriseCode;
            dcSalesHistoryWork.FileHeaderGuid = salesHistoryWork.FileHeaderGuid;
            dcSalesHistoryWork.UpdEmployeeCode = salesHistoryWork.UpdEmployeeCode;
            dcSalesHistoryWork.UpdAssemblyId1 = salesHistoryWork.UpdAssemblyId1;
            dcSalesHistoryWork.UpdAssemblyId2 = salesHistoryWork.UpdAssemblyId2;
            dcSalesHistoryWork.LogicalDeleteCode = salesHistoryWork.LogicalDeleteCode;
            dcSalesHistoryWork.AcptAnOdrStatus = salesHistoryWork.AcptAnOdrStatus;
            dcSalesHistoryWork.SalesSlipNum = salesHistoryWork.SalesSlipNum;
            dcSalesHistoryWork.SectionCode = salesHistoryWork.SectionCode;
            dcSalesHistoryWork.SubSectionCode = salesHistoryWork.SubSectionCode;
            dcSalesHistoryWork.DebitNoteDiv = salesHistoryWork.DebitNoteDiv;
            dcSalesHistoryWork.DebitNLnkSalesSlNum = salesHistoryWork.DebitNLnkSalesSlNum;
            dcSalesHistoryWork.SalesSlipCd = salesHistoryWork.SalesSlipCd;
            dcSalesHistoryWork.SalesGoodsCd = salesHistoryWork.SalesGoodsCd;
            dcSalesHistoryWork.AccRecDivCd = salesHistoryWork.AccRecDivCd;
            dcSalesHistoryWork.SalesInpSecCd = salesHistoryWork.SalesInpSecCd;
            dcSalesHistoryWork.DemandAddUpSecCd = salesHistoryWork.DemandAddUpSecCd;
            dcSalesHistoryWork.ResultsAddUpSecCd = salesHistoryWork.ResultsAddUpSecCd;
            dcSalesHistoryWork.UpdateSecCd = salesHistoryWork.UpdateSecCd;
            dcSalesHistoryWork.SalesSlipUpdateCd = salesHistoryWork.SalesSlipUpdateCd;
            dcSalesHistoryWork.SearchSlipDate = salesHistoryWork.SearchSlipDate;
            dcSalesHistoryWork.ShipmentDay = salesHistoryWork.ShipmentDay;
            dcSalesHistoryWork.SalesDate = salesHistoryWork.SalesDate;
            dcSalesHistoryWork.AddUpADate = salesHistoryWork.AddUpADate;
            dcSalesHistoryWork.DelayPaymentDiv = salesHistoryWork.DelayPaymentDiv;
            dcSalesHistoryWork.InputAgenCd = salesHistoryWork.InputAgenCd;
            dcSalesHistoryWork.InputAgenNm = salesHistoryWork.InputAgenNm;
            dcSalesHistoryWork.SalesInputCode = salesHistoryWork.SalesInputCode;
            dcSalesHistoryWork.SalesInputName = salesHistoryWork.SalesInputName;
            dcSalesHistoryWork.FrontEmployeeCd = salesHistoryWork.FrontEmployeeCd;
            dcSalesHistoryWork.FrontEmployeeNm = salesHistoryWork.FrontEmployeeNm;
            dcSalesHistoryWork.SalesEmployeeCd = salesHistoryWork.SalesEmployeeCd;
            dcSalesHistoryWork.SalesEmployeeNm = salesHistoryWork.SalesEmployeeNm;
            dcSalesHistoryWork.TotalAmountDispWayCd = salesHistoryWork.TotalAmountDispWayCd;
            dcSalesHistoryWork.TtlAmntDispRateApy = salesHistoryWork.TtlAmntDispRateApy;
            dcSalesHistoryWork.SalesTotalTaxInc = salesHistoryWork.SalesTotalTaxInc;
            dcSalesHistoryWork.SalesTotalTaxExc = salesHistoryWork.SalesTotalTaxExc;
            dcSalesHistoryWork.SalesPrtTotalTaxInc = salesHistoryWork.SalesPrtTotalTaxInc;
            dcSalesHistoryWork.SalesPrtTotalTaxExc = salesHistoryWork.SalesPrtTotalTaxExc;
            dcSalesHistoryWork.SalesWorkTotalTaxInc = salesHistoryWork.SalesWorkTotalTaxInc;
            dcSalesHistoryWork.SalesWorkTotalTaxExc = salesHistoryWork.SalesWorkTotalTaxExc;
            dcSalesHistoryWork.SalesSubtotalTaxInc = salesHistoryWork.SalesSubtotalTaxInc;
            dcSalesHistoryWork.SalesSubtotalTaxExc = salesHistoryWork.SalesSubtotalTaxExc;
            dcSalesHistoryWork.SalesPrtSubttlInc = salesHistoryWork.SalesPrtSubttlInc;
            dcSalesHistoryWork.SalesPrtSubttlExc = salesHistoryWork.SalesPrtSubttlExc;
            dcSalesHistoryWork.SalesWorkSubttlInc = salesHistoryWork.SalesWorkSubttlInc;
            dcSalesHistoryWork.SalesWorkSubttlExc = salesHistoryWork.SalesWorkSubttlExc;
            dcSalesHistoryWork.SalesNetPrice = salesHistoryWork.SalesNetPrice;
            dcSalesHistoryWork.SalesSubtotalTax = salesHistoryWork.SalesSubtotalTax;
            dcSalesHistoryWork.ItdedSalesOutTax = salesHistoryWork.ItdedSalesOutTax;
            dcSalesHistoryWork.ItdedSalesInTax = salesHistoryWork.ItdedSalesInTax;
            dcSalesHistoryWork.SalSubttlSubToTaxFre = salesHistoryWork.SalSubttlSubToTaxFre;
            dcSalesHistoryWork.SalesOutTax = salesHistoryWork.SalesOutTax;
            dcSalesHistoryWork.SalAmntConsTaxInclu = salesHistoryWork.SalAmntConsTaxInclu;
            dcSalesHistoryWork.SalesDisTtlTaxExc = salesHistoryWork.SalesDisTtlTaxExc;
            dcSalesHistoryWork.ItdedSalesDisOutTax = salesHistoryWork.ItdedSalesDisOutTax;
            dcSalesHistoryWork.ItdedSalesDisInTax = salesHistoryWork.ItdedSalesDisInTax;
            dcSalesHistoryWork.ItdedPartsDisOutTax = salesHistoryWork.ItdedPartsDisOutTax;
            dcSalesHistoryWork.ItdedPartsDisInTax = salesHistoryWork.ItdedPartsDisInTax;
            dcSalesHistoryWork.ItdedWorkDisOutTax = salesHistoryWork.ItdedWorkDisOutTax;
            dcSalesHistoryWork.ItdedWorkDisInTax = salesHistoryWork.ItdedWorkDisInTax;
            dcSalesHistoryWork.ItdedSalesDisTaxFre = salesHistoryWork.ItdedSalesDisTaxFre;
            dcSalesHistoryWork.SalesDisOutTax = salesHistoryWork.SalesDisOutTax;
            dcSalesHistoryWork.SalesDisTtlTaxInclu = salesHistoryWork.SalesDisTtlTaxInclu;
            dcSalesHistoryWork.PartsDiscountRate = salesHistoryWork.PartsDiscountRate;
            dcSalesHistoryWork.RavorDiscountRate = salesHistoryWork.RavorDiscountRate;
            dcSalesHistoryWork.TotalCost = salesHistoryWork.TotalCost;
            dcSalesHistoryWork.ConsTaxLayMethod = salesHistoryWork.ConsTaxLayMethod;
            dcSalesHistoryWork.ConsTaxRate = salesHistoryWork.ConsTaxRate;
            dcSalesHistoryWork.FractionProcCd = salesHistoryWork.FractionProcCd;
            dcSalesHistoryWork.AccRecConsTax = salesHistoryWork.AccRecConsTax;
            dcSalesHistoryWork.AutoDepositCd = salesHistoryWork.AutoDepositCd;
            dcSalesHistoryWork.AutoDepositSlipNo = salesHistoryWork.AutoDepositSlipNo;
            dcSalesHistoryWork.DepositAllowanceTtl = salesHistoryWork.DepositAllowanceTtl;
            dcSalesHistoryWork.DepositAlwcBlnce = salesHistoryWork.DepositAlwcBlnce;
            dcSalesHistoryWork.ClaimCode = salesHistoryWork.ClaimCode;
            dcSalesHistoryWork.ClaimSnm = salesHistoryWork.ClaimSnm;
            dcSalesHistoryWork.CustomerCode = salesHistoryWork.CustomerCode;
            dcSalesHistoryWork.CustomerName = salesHistoryWork.CustomerName;
            dcSalesHistoryWork.CustomerName2 = salesHistoryWork.CustomerName2;
            dcSalesHistoryWork.CustomerSnm = salesHistoryWork.CustomerSnm;
            dcSalesHistoryWork.HonorificTitle = salesHistoryWork.HonorificTitle;
            dcSalesHistoryWork.OutputNameCode = salesHistoryWork.OutputNameCode;
            dcSalesHistoryWork.OutputName = salesHistoryWork.OutputName;
            dcSalesHistoryWork.CustSlipNo = salesHistoryWork.CustSlipNo;
            dcSalesHistoryWork.SlipAddressDiv = salesHistoryWork.SlipAddressDiv;
            dcSalesHistoryWork.AddresseeCode = salesHistoryWork.AddresseeCode;
            dcSalesHistoryWork.AddresseeName = salesHistoryWork.AddresseeName;
            dcSalesHistoryWork.AddresseeName2 = salesHistoryWork.AddresseeName2;
            dcSalesHistoryWork.AddresseePostNo = salesHistoryWork.AddresseePostNo;
            dcSalesHistoryWork.AddresseeAddr1 = salesHistoryWork.AddresseeAddr1;
            dcSalesHistoryWork.AddresseeAddr3 = salesHistoryWork.AddresseeAddr3;
            dcSalesHistoryWork.AddresseeAddr4 = salesHistoryWork.AddresseeAddr4;
            dcSalesHistoryWork.AddresseeTelNo = salesHistoryWork.AddresseeTelNo;
            dcSalesHistoryWork.AddresseeFaxNo = salesHistoryWork.AddresseeFaxNo;
            dcSalesHistoryWork.PartySaleSlipNum = salesHistoryWork.PartySaleSlipNum;
            dcSalesHistoryWork.SlipNote = salesHistoryWork.SlipNote;
            dcSalesHistoryWork.SlipNote2 = salesHistoryWork.SlipNote2;
            dcSalesHistoryWork.SlipNote3 = salesHistoryWork.SlipNote3;
            dcSalesHistoryWork.RetGoodsReasonDiv = salesHistoryWork.RetGoodsReasonDiv;
            dcSalesHistoryWork.RetGoodsReason = salesHistoryWork.RetGoodsReason;
            dcSalesHistoryWork.DetailRowCount = salesHistoryWork.DetailRowCount;
            dcSalesHistoryWork.EdiSendDate = salesHistoryWork.EdiSendDate;
            dcSalesHistoryWork.EdiTakeInDate = salesHistoryWork.EdiTakeInDate;
            dcSalesHistoryWork.UoeRemark1 = salesHistoryWork.UoeRemark1;
            dcSalesHistoryWork.UoeRemark2 = salesHistoryWork.UoeRemark2;
            dcSalesHistoryWork.SlipPrintDivCd = salesHistoryWork.SlipPrintDivCd;
            dcSalesHistoryWork.SlipPrintFinishCd = salesHistoryWork.SlipPrintFinishCd;
            dcSalesHistoryWork.SalesSlipPrintDate = salesHistoryWork.SalesSlipPrintDate;
            dcSalesHistoryWork.BusinessTypeCode = salesHistoryWork.BusinessTypeCode;
            dcSalesHistoryWork.BusinessTypeName = salesHistoryWork.BusinessTypeName;
            dcSalesHistoryWork.DeliveredGoodsDiv = salesHistoryWork.DeliveredGoodsDiv;
            dcSalesHistoryWork.DeliveredGoodsDivNm = salesHistoryWork.DeliveredGoodsDivNm;
            dcSalesHistoryWork.SalesAreaCode = salesHistoryWork.SalesAreaCode;
            dcSalesHistoryWork.SalesAreaName = salesHistoryWork.SalesAreaName;
            dcSalesHistoryWork.SlipPrtSetPaperId = salesHistoryWork.SlipPrtSetPaperId;
            dcSalesHistoryWork.CompleteCd = salesHistoryWork.CompleteCd;
            dcSalesHistoryWork.SalesPriceFracProcCd = salesHistoryWork.SalesPriceFracProcCd;
            dcSalesHistoryWork.StockGoodsTtlTaxExc = salesHistoryWork.StockGoodsTtlTaxExc;
            dcSalesHistoryWork.PureGoodsTtlTaxExc = salesHistoryWork.PureGoodsTtlTaxExc;
            dcSalesHistoryWork.ListPricePrintDiv = salesHistoryWork.ListPricePrintDiv;
            dcSalesHistoryWork.EraNameDispCd1 = salesHistoryWork.EraNameDispCd1;

            return dcSalesHistoryWork;
        }

        /// <summary>
        /// 売上履歴明細データPramData→UIData移項処理
        /// </summary>
        /// <param name="salesHistDtlWork">売上履歴明細データ</param>
        /// <returns>DC売上履歴明細データ</returns>
        /// <br>Update Note: PMKOBETSU-3877の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/09/25</br>
        public static DCSalesHistDtlWork SearchDataFromUpdateData(APSalesHistDtlWork salesHistDtlWork)
        {
            if (salesHistDtlWork == null)
            {
                return null;
            }

            DCSalesHistDtlWork dcSalesHistDtlWork = new DCSalesHistDtlWork();

            // 売上履歴明細データ変換
            dcSalesHistDtlWork.CreateDateTime = salesHistDtlWork.CreateDateTime;
            dcSalesHistDtlWork.UpdateDateTime = salesHistDtlWork.UpdateDateTime;
            dcSalesHistDtlWork.EnterpriseCode = salesHistDtlWork.EnterpriseCode;
            dcSalesHistDtlWork.FileHeaderGuid = salesHistDtlWork.FileHeaderGuid;
            dcSalesHistDtlWork.UpdEmployeeCode = salesHistDtlWork.UpdEmployeeCode;
            dcSalesHistDtlWork.UpdAssemblyId1 = salesHistDtlWork.UpdAssemblyId1;
            dcSalesHistDtlWork.UpdAssemblyId2 = salesHistDtlWork.UpdAssemblyId2;
            dcSalesHistDtlWork.LogicalDeleteCode = salesHistDtlWork.LogicalDeleteCode;
            dcSalesHistDtlWork.AcceptAnOrderNo = salesHistDtlWork.AcceptAnOrderNo;
            dcSalesHistDtlWork.AcptAnOdrStatus = salesHistDtlWork.AcptAnOdrStatus;
            dcSalesHistDtlWork.SalesSlipNum = salesHistDtlWork.SalesSlipNum;
            dcSalesHistDtlWork.SalesRowNo = salesHistDtlWork.SalesRowNo;
            dcSalesHistDtlWork.SalesRowDerivNo = salesHistDtlWork.SalesRowDerivNo;
            dcSalesHistDtlWork.SectionCode = salesHistDtlWork.SectionCode;
            dcSalesHistDtlWork.SubSectionCode = salesHistDtlWork.SubSectionCode;
            dcSalesHistDtlWork.SalesDate = salesHistDtlWork.SalesDate;
            dcSalesHistDtlWork.CommonSeqNo = salesHistDtlWork.CommonSeqNo;
            dcSalesHistDtlWork.SalesSlipDtlNum = salesHistDtlWork.SalesSlipDtlNum;
            dcSalesHistDtlWork.AcptAnOdrStatusSrc = salesHistDtlWork.AcptAnOdrStatusSrc;
            dcSalesHistDtlWork.SalesSlipDtlNumSrc = salesHistDtlWork.SalesSlipDtlNumSrc;
            dcSalesHistDtlWork.SupplierFormalSync = salesHistDtlWork.SupplierFormalSync;
            dcSalesHistDtlWork.StockSlipDtlNumSync = salesHistDtlWork.StockSlipDtlNumSync;
            dcSalesHistDtlWork.SalesSlipCdDtl = salesHistDtlWork.SalesSlipCdDtl;
            dcSalesHistDtlWork.GoodsKindCode = salesHistDtlWork.GoodsKindCode;
            dcSalesHistDtlWork.GoodsMakerCd = salesHistDtlWork.GoodsMakerCd;
            dcSalesHistDtlWork.MakerName = salesHistDtlWork.MakerName;
            dcSalesHistDtlWork.MakerKanaName = salesHistDtlWork.MakerKanaName;
            dcSalesHistDtlWork.GoodsNo = salesHistDtlWork.GoodsNo;
            dcSalesHistDtlWork.GoodsName = salesHistDtlWork.GoodsName;
            dcSalesHistDtlWork.GoodsNameKana = salesHistDtlWork.GoodsNameKana;
            dcSalesHistDtlWork.GoodsLGroup = salesHistDtlWork.GoodsLGroup;
            dcSalesHistDtlWork.GoodsLGroupName = salesHistDtlWork.GoodsLGroupName;
            dcSalesHistDtlWork.GoodsMGroup = salesHistDtlWork.GoodsMGroup;
            dcSalesHistDtlWork.GoodsMGroupName = salesHistDtlWork.GoodsMGroupName;
            dcSalesHistDtlWork.BLGroupCode = salesHistDtlWork.BLGroupCode;
            dcSalesHistDtlWork.BLGroupName = salesHistDtlWork.BLGroupName;
            dcSalesHistDtlWork.BLGoodsCode = salesHistDtlWork.BLGoodsCode;
            dcSalesHistDtlWork.BLGoodsFullName = salesHistDtlWork.BLGoodsFullName;
            dcSalesHistDtlWork.EnterpriseGanreCode = salesHistDtlWork.EnterpriseGanreCode;
            dcSalesHistDtlWork.EnterpriseGanreName = salesHistDtlWork.EnterpriseGanreName;
            dcSalesHistDtlWork.WarehouseCode = salesHistDtlWork.WarehouseCode;
            dcSalesHistDtlWork.WarehouseName = salesHistDtlWork.WarehouseName;
            dcSalesHistDtlWork.WarehouseShelfNo = salesHistDtlWork.WarehouseShelfNo;
            dcSalesHistDtlWork.SalesOrderDivCd = salesHistDtlWork.SalesOrderDivCd;
            dcSalesHistDtlWork.OpenPriceDiv = salesHistDtlWork.OpenPriceDiv;
            dcSalesHistDtlWork.GoodsRateRank = salesHistDtlWork.GoodsRateRank;
            dcSalesHistDtlWork.CustRateGrpCode = salesHistDtlWork.CustRateGrpCode;
            dcSalesHistDtlWork.ListPriceRate = salesHistDtlWork.ListPriceRate;
            dcSalesHistDtlWork.RateSectPriceUnPrc = salesHistDtlWork.RateSectPriceUnPrc;
            dcSalesHistDtlWork.RateDivLPrice = salesHistDtlWork.RateDivLPrice;
            dcSalesHistDtlWork.UnPrcCalcCdLPrice = salesHistDtlWork.UnPrcCalcCdLPrice;
            dcSalesHistDtlWork.PriceCdLPrice = salesHistDtlWork.PriceCdLPrice;
            dcSalesHistDtlWork.StdUnPrcLPrice = salesHistDtlWork.StdUnPrcLPrice;
            dcSalesHistDtlWork.FracProcUnitLPrice = salesHistDtlWork.FracProcUnitLPrice;
            dcSalesHistDtlWork.FracProcLPrice = salesHistDtlWork.FracProcLPrice;
            dcSalesHistDtlWork.ListPriceTaxIncFl = salesHistDtlWork.ListPriceTaxIncFl;
            dcSalesHistDtlWork.ListPriceTaxExcFl = salesHistDtlWork.ListPriceTaxExcFl;
            dcSalesHistDtlWork.ListPriceChngCd = salesHistDtlWork.ListPriceChngCd;
            dcSalesHistDtlWork.SalesRate = salesHistDtlWork.SalesRate;
            dcSalesHistDtlWork.RateSectSalUnPrc = salesHistDtlWork.RateSectSalUnPrc;
            dcSalesHistDtlWork.RateDivSalUnPrc = salesHistDtlWork.RateDivSalUnPrc;
            dcSalesHistDtlWork.UnPrcCalcCdSalUnPrc = salesHistDtlWork.UnPrcCalcCdSalUnPrc;
            dcSalesHistDtlWork.PriceCdSalUnPrc = salesHistDtlWork.PriceCdSalUnPrc;
            dcSalesHistDtlWork.StdUnPrcSalUnPrc = salesHistDtlWork.StdUnPrcSalUnPrc;
            dcSalesHistDtlWork.FracProcUnitSalUnPrc = salesHistDtlWork.FracProcUnitSalUnPrc;
            dcSalesHistDtlWork.FracProcSalUnPrc = salesHistDtlWork.FracProcSalUnPrc;
            dcSalesHistDtlWork.SalesUnPrcTaxIncFl = salesHistDtlWork.SalesUnPrcTaxIncFl;
            dcSalesHistDtlWork.SalesUnPrcTaxExcFl = salesHistDtlWork.SalesUnPrcTaxExcFl;
            dcSalesHistDtlWork.SalesUnPrcChngCd = salesHistDtlWork.SalesUnPrcChngCd;
            dcSalesHistDtlWork.CostRate = salesHistDtlWork.CostRate;
            dcSalesHistDtlWork.RateSectCstUnPrc = salesHistDtlWork.RateSectCstUnPrc;
            dcSalesHistDtlWork.RateDivUnCst = salesHistDtlWork.RateDivUnCst;
            dcSalesHistDtlWork.UnPrcCalcCdUnCst = salesHistDtlWork.UnPrcCalcCdUnCst;
            dcSalesHistDtlWork.PriceCdUnCst = salesHistDtlWork.PriceCdUnCst;
            dcSalesHistDtlWork.StdUnPrcUnCst = salesHistDtlWork.StdUnPrcUnCst;
            dcSalesHistDtlWork.FracProcUnitUnCst = salesHistDtlWork.FracProcUnitUnCst;
            dcSalesHistDtlWork.FracProcUnCst = salesHistDtlWork.FracProcUnCst;
            dcSalesHistDtlWork.SalesUnitCost = salesHistDtlWork.SalesUnitCost;
            dcSalesHistDtlWork.SalesUnitCostChngDiv = salesHistDtlWork.SalesUnitCostChngDiv;
            dcSalesHistDtlWork.RateBLGoodsCode = salesHistDtlWork.RateBLGoodsCode;
            dcSalesHistDtlWork.RateBLGoodsName = salesHistDtlWork.RateBLGoodsName;
            dcSalesHistDtlWork.RateGoodsRateGrpCd = salesHistDtlWork.RateGoodsRateGrpCd;
            dcSalesHistDtlWork.RateGoodsRateGrpNm = salesHistDtlWork.RateGoodsRateGrpNm;
            dcSalesHistDtlWork.RateBLGroupCode = salesHistDtlWork.RateBLGroupCode;
            dcSalesHistDtlWork.RateBLGroupName = salesHistDtlWork.RateBLGroupName;
            dcSalesHistDtlWork.PrtBLGoodsCode = salesHistDtlWork.PrtBLGoodsCode;
            dcSalesHistDtlWork.PrtBLGoodsName = salesHistDtlWork.PrtBLGoodsName;
            dcSalesHistDtlWork.SalesCode = salesHistDtlWork.SalesCode;
            dcSalesHistDtlWork.SalesCdNm = salesHistDtlWork.SalesCdNm;
            dcSalesHistDtlWork.WorkManHour = salesHistDtlWork.WorkManHour;
            dcSalesHistDtlWork.ShipmentCnt = salesHistDtlWork.ShipmentCnt;
            dcSalesHistDtlWork.SalesMoneyTaxInc = salesHistDtlWork.SalesMoneyTaxInc;
            dcSalesHistDtlWork.SalesMoneyTaxExc = salesHistDtlWork.SalesMoneyTaxExc;
            dcSalesHistDtlWork.Cost = salesHistDtlWork.Cost;
            dcSalesHistDtlWork.GrsProfitChkDiv = salesHistDtlWork.GrsProfitChkDiv;
            dcSalesHistDtlWork.SalesGoodsCd = salesHistDtlWork.SalesGoodsCd;
            dcSalesHistDtlWork.SalesPriceConsTax = salesHistDtlWork.SalesPriceConsTax;
            dcSalesHistDtlWork.TaxationDivCd = salesHistDtlWork.TaxationDivCd;
            dcSalesHistDtlWork.PartySlipNumDtl = salesHistDtlWork.PartySlipNumDtl;
            dcSalesHistDtlWork.DtlNote = salesHistDtlWork.DtlNote;
            dcSalesHistDtlWork.SupplierCd = salesHistDtlWork.SupplierCd;
            dcSalesHistDtlWork.SupplierSnm = salesHistDtlWork.SupplierSnm;
            dcSalesHistDtlWork.OrderNumber = salesHistDtlWork.OrderNumber;
            dcSalesHistDtlWork.WayToOrder = salesHistDtlWork.WayToOrder;
            dcSalesHistDtlWork.SlipMemo1 = salesHistDtlWork.SlipMemo1;
            dcSalesHistDtlWork.SlipMemo2 = salesHistDtlWork.SlipMemo2;
            dcSalesHistDtlWork.SlipMemo3 = salesHistDtlWork.SlipMemo3;
            dcSalesHistDtlWork.InsideMemo1 = salesHistDtlWork.InsideMemo1;
            dcSalesHistDtlWork.InsideMemo2 = salesHistDtlWork.InsideMemo2;
            dcSalesHistDtlWork.InsideMemo3 = salesHistDtlWork.InsideMemo3;
            dcSalesHistDtlWork.BfListPrice = salesHistDtlWork.BfListPrice;
            dcSalesHistDtlWork.BfSalesUnitPrice = salesHistDtlWork.BfSalesUnitPrice;
            dcSalesHistDtlWork.BfUnitCost = salesHistDtlWork.BfUnitCost;
            dcSalesHistDtlWork.CmpltSalesRowNo = salesHistDtlWork.CmpltSalesRowNo;
            dcSalesHistDtlWork.CmpltGoodsMakerCd = salesHistDtlWork.CmpltGoodsMakerCd;
            dcSalesHistDtlWork.CmpltMakerName = salesHistDtlWork.CmpltMakerName;
            dcSalesHistDtlWork.CmpltMakerKanaName = salesHistDtlWork.CmpltMakerKanaName;
            dcSalesHistDtlWork.CmpltGoodsName = salesHistDtlWork.CmpltGoodsName;
            dcSalesHistDtlWork.CmpltShipmentCnt = salesHistDtlWork.CmpltShipmentCnt;
            dcSalesHistDtlWork.CmpltSalesUnPrcFl = salesHistDtlWork.CmpltSalesUnPrcFl;
            dcSalesHistDtlWork.CmpltSalesMoney = salesHistDtlWork.CmpltSalesMoney;
            dcSalesHistDtlWork.CmpltSalesUnitCost = salesHistDtlWork.CmpltSalesUnitCost;
            dcSalesHistDtlWork.CmpltCost = salesHistDtlWork.CmpltCost;
            dcSalesHistDtlWork.CmpltPartySalSlNum = salesHistDtlWork.CmpltPartySalSlNum;
            dcSalesHistDtlWork.CmpltNote = salesHistDtlWork.CmpltNote;
            dcSalesHistDtlWork.PrtGoodsNo = salesHistDtlWork.PrtGoodsNo;
            dcSalesHistDtlWork.PrtMakerCode = salesHistDtlWork.PrtMakerCode;
            dcSalesHistDtlWork.PrtMakerName = salesHistDtlWork.PrtMakerName;
            // ↓ 2009.05.26 liuyang add
            dcSalesHistDtlWork.CampaignCode = salesHistDtlWork.CampaignCode;
            dcSalesHistDtlWork.CampaignName = salesHistDtlWork.CampaignName;
            dcSalesHistDtlWork.GoodsDivCd = salesHistDtlWork.GoodsDivCd;
            dcSalesHistDtlWork.AnswerDelivDate = salesHistDtlWork.AnswerDelivDate;
            dcSalesHistDtlWork.RecycleDiv = salesHistDtlWork.RecycleDiv;
            dcSalesHistDtlWork.RecycleDivNm = salesHistDtlWork.RecycleDivNm;
            dcSalesHistDtlWork.WayToAcptOdr = salesHistDtlWork.WayToAcptOdr;
            // ↑ 2009.05.26 liuyang add

			// ADD 2011/09/15 ---------- >>>>>
			dcSalesHistDtlWork.AutoAnswerDivSCM = salesHistDtlWork.AutoAnswerDivSCM;
			dcSalesHistDtlWork.AcceptOrOrderKind = salesHistDtlWork.AcceptOrOrderKind;
			dcSalesHistDtlWork.InquiryNumber = salesHistDtlWork.InquiryNumber;
			dcSalesHistDtlWork.InqRowNumber = salesHistDtlWork.InqRowNumber;
			// ADD 2011/09/15 ---------- <<<<<
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 ----->>>>>
            dcSalesHistDtlWork.RentSyncSupplier = salesHistDtlWork.RentSyncSupplier; // 貸出同時仕入先
            dcSalesHistDtlWork.RentSyncStockDate = salesHistDtlWork.RentSyncStockDate; // 貸出同時仕入日
            dcSalesHistDtlWork.RentSyncSupSlipNo = salesHistDtlWork.RentSyncSupSlipNo; // 貸出同時仕入伝票番号
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 -----<<<<<
            return dcSalesHistDtlWork;
        }

        /// <summary>
        /// 入金データPramData→UIData移項処理
        /// </summary>
        /// <param name="depsitMainWork">入金データ</param>
        /// <returns>DC入金データ</returns>
        public static DCDepsitMainWork SearchDataFromUpdateData(APDepsitMainWork depsitMainWork)
        {
            if (depsitMainWork == null)
            {
                return null;
            }

            DCDepsitMainWork dcDepsitMainWork = new DCDepsitMainWork();

            // 変換
            dcDepsitMainWork.CreateDateTime = depsitMainWork.CreateDateTime;
            dcDepsitMainWork.UpdateDateTime = depsitMainWork.UpdateDateTime;
            dcDepsitMainWork.EnterpriseCode = depsitMainWork.EnterpriseCode;
            dcDepsitMainWork.FileHeaderGuid = depsitMainWork.FileHeaderGuid;
            dcDepsitMainWork.UpdEmployeeCode = depsitMainWork.UpdEmployeeCode;
            dcDepsitMainWork.UpdAssemblyId1 = depsitMainWork.UpdAssemblyId1;
            dcDepsitMainWork.UpdAssemblyId2 = depsitMainWork.UpdAssemblyId2;
            dcDepsitMainWork.LogicalDeleteCode = depsitMainWork.LogicalDeleteCode;
            dcDepsitMainWork.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus;
            dcDepsitMainWork.DepositDebitNoteCd = depsitMainWork.DepositDebitNoteCd;
            dcDepsitMainWork.DepositSlipNo = depsitMainWork.DepositSlipNo;
            dcDepsitMainWork.SalesSlipNum = depsitMainWork.SalesSlipNum;
            dcDepsitMainWork.InputDepositSecCd = depsitMainWork.InputDepositSecCd;
            dcDepsitMainWork.AddUpSecCode = depsitMainWork.AddUpSecCode;
            dcDepsitMainWork.UpdateSecCd = depsitMainWork.UpdateSecCd;
            dcDepsitMainWork.SubSectionCode = depsitMainWork.SubSectionCode;
            dcDepsitMainWork.InputDay = depsitMainWork.InputDay;
            dcDepsitMainWork.DepositDate = depsitMainWork.DepositDate;
            dcDepsitMainWork.AddUpADate = depsitMainWork.AddUpADate;
            dcDepsitMainWork.DepositTotal = depsitMainWork.DepositTotal;
            dcDepsitMainWork.Deposit = depsitMainWork.Deposit;
            dcDepsitMainWork.FeeDeposit = depsitMainWork.FeeDeposit;
            dcDepsitMainWork.DiscountDeposit = depsitMainWork.DiscountDeposit;
            dcDepsitMainWork.AutoDepositCd = depsitMainWork.AutoDepositCd;
            dcDepsitMainWork.DraftDrawingDate = depsitMainWork.DraftDrawingDate;
            dcDepsitMainWork.DraftKind = depsitMainWork.DraftKind;
            dcDepsitMainWork.DraftKindName = depsitMainWork.DraftKindName;
            dcDepsitMainWork.DraftDivide = depsitMainWork.DraftDivide;
            dcDepsitMainWork.DraftDivideName = depsitMainWork.DraftDivideName;
            dcDepsitMainWork.DraftNo = depsitMainWork.DraftNo;
            dcDepsitMainWork.DepositAllowance = depsitMainWork.DepositAllowance;
            dcDepsitMainWork.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce;
            dcDepsitMainWork.DebitNoteLinkDepoNo = depsitMainWork.DebitNoteLinkDepoNo;
            dcDepsitMainWork.LastReconcileAddUpDt = depsitMainWork.LastReconcileAddUpDt;
            dcDepsitMainWork.DepositAgentCode = depsitMainWork.DepositAgentCode;
            dcDepsitMainWork.DepositAgentNm = depsitMainWork.DepositAgentNm;
            dcDepsitMainWork.DepositInputAgentCd = depsitMainWork.DepositInputAgentCd;
            dcDepsitMainWork.DepositInputAgentNm = depsitMainWork.DepositInputAgentNm;
            dcDepsitMainWork.CustomerCode = depsitMainWork.CustomerCode;
            dcDepsitMainWork.CustomerName = depsitMainWork.CustomerName;
            dcDepsitMainWork.CustomerName2 = depsitMainWork.CustomerName2;
            dcDepsitMainWork.CustomerSnm = depsitMainWork.CustomerSnm;
            dcDepsitMainWork.ClaimCode = depsitMainWork.ClaimCode;
            dcDepsitMainWork.ClaimName = depsitMainWork.ClaimName;
            dcDepsitMainWork.ClaimName2 = depsitMainWork.ClaimName2;
            dcDepsitMainWork.ClaimSnm = depsitMainWork.ClaimSnm;
            dcDepsitMainWork.Outline = depsitMainWork.Outline;
            dcDepsitMainWork.BankCode = depsitMainWork.BankCode;
            dcDepsitMainWork.BankName = depsitMainWork.BankName;

            return dcDepsitMainWork;
        }

        /// <summary>
        /// 入金明細データPramData→UIData移項処理
        /// </summary>
        /// <param name="depsitDtlWork">入金明細データ</param>
        /// <returns>DC入金明細データ</returns>
        public static DCDepsitDtlWork SearchDataFromUpdateData(APDepsitDtlWork depsitDtlWork)
        {
            if (depsitDtlWork == null)
            {
                return null;
            }

            DCDepsitDtlWork dcDepsitDtlWork = new DCDepsitDtlWork();

            // 入金明細データ変換
            dcDepsitDtlWork.CreateDateTime = depsitDtlWork.CreateDateTime;
            dcDepsitDtlWork.UpdateDateTime = depsitDtlWork.UpdateDateTime;
            dcDepsitDtlWork.EnterpriseCode = depsitDtlWork.EnterpriseCode;
            dcDepsitDtlWork.FileHeaderGuid = depsitDtlWork.FileHeaderGuid;
            dcDepsitDtlWork.UpdEmployeeCode = depsitDtlWork.UpdEmployeeCode;
            dcDepsitDtlWork.UpdAssemblyId1 = depsitDtlWork.UpdAssemblyId1;
            dcDepsitDtlWork.UpdAssemblyId2 = depsitDtlWork.UpdAssemblyId2;
            dcDepsitDtlWork.LogicalDeleteCode = depsitDtlWork.LogicalDeleteCode;
            dcDepsitDtlWork.AcptAnOdrStatus = depsitDtlWork.AcptAnOdrStatus;
            dcDepsitDtlWork.DepositSlipNo = depsitDtlWork.DepositSlipNo;
            dcDepsitDtlWork.DepositRowNo = depsitDtlWork.DepositRowNo;
            dcDepsitDtlWork.MoneyKindCode = depsitDtlWork.MoneyKindCode;
            dcDepsitDtlWork.MoneyKindName = depsitDtlWork.MoneyKindName;
            dcDepsitDtlWork.MoneyKindDiv = depsitDtlWork.MoneyKindDiv;
            dcDepsitDtlWork.Deposit = depsitDtlWork.Deposit;
            dcDepsitDtlWork.ValidityTerm = depsitDtlWork.ValidityTerm;

            return dcDepsitDtlWork;
        }

        /// <summary>
        /// 仕入データPramData→UIData移項処理
        /// </summary>
        /// <param name="stockSlipWork">仕入データ</param>
        /// <returns>DC仕入データ</returns>
        public static DCStockSlipWork SearchDataFromUpdateData(APStockSlipWork stockSlipWork)
        {
            if (stockSlipWork == null)
            {
                return null;
            }

            DCStockSlipWork dcStockSlipWork = new DCStockSlipWork();

            // 仕入データ変換
            dcStockSlipWork.CreateDateTime = stockSlipWork.CreateDateTime;
            dcStockSlipWork.UpdateDateTime = stockSlipWork.UpdateDateTime;
            dcStockSlipWork.EnterpriseCode = stockSlipWork.EnterpriseCode;
            dcStockSlipWork.FileHeaderGuid = stockSlipWork.FileHeaderGuid;
            dcStockSlipWork.UpdEmployeeCode = stockSlipWork.UpdEmployeeCode;
            dcStockSlipWork.UpdAssemblyId1 = stockSlipWork.UpdAssemblyId1;
            dcStockSlipWork.UpdAssemblyId2 = stockSlipWork.UpdAssemblyId2;
            dcStockSlipWork.LogicalDeleteCode = stockSlipWork.LogicalDeleteCode;
            dcStockSlipWork.SupplierFormal = stockSlipWork.SupplierFormal;
            dcStockSlipWork.SupplierSlipNo = stockSlipWork.SupplierSlipNo;
            dcStockSlipWork.SectionCode = stockSlipWork.SectionCode;
            dcStockSlipWork.SubSectionCode = stockSlipWork.SubSectionCode;
            dcStockSlipWork.DebitNoteDiv = stockSlipWork.DebitNoteDiv;
            dcStockSlipWork.DebitNLnkSuppSlipNo = stockSlipWork.DebitNLnkSuppSlipNo;
            dcStockSlipWork.SupplierSlipCd = stockSlipWork.SupplierSlipCd;
            dcStockSlipWork.StockGoodsCd = stockSlipWork.StockGoodsCd;
            dcStockSlipWork.AccPayDivCd = stockSlipWork.AccPayDivCd;
            dcStockSlipWork.StockSectionCd = stockSlipWork.StockSectionCd;
            dcStockSlipWork.StockAddUpSectionCd = stockSlipWork.StockAddUpSectionCd;
            dcStockSlipWork.StockSlipUpdateCd = stockSlipWork.StockSlipUpdateCd;
            dcStockSlipWork.InputDay = stockSlipWork.InputDay;
            dcStockSlipWork.ArrivalGoodsDay = stockSlipWork.ArrivalGoodsDay;
            dcStockSlipWork.StockDate = stockSlipWork.StockDate;
            dcStockSlipWork.StockAddUpADate = stockSlipWork.StockAddUpADate;
            dcStockSlipWork.DelayPaymentDiv = stockSlipWork.DelayPaymentDiv;
            dcStockSlipWork.PayeeCode = stockSlipWork.PayeeCode;
            dcStockSlipWork.PayeeSnm = stockSlipWork.PayeeSnm;
            dcStockSlipWork.SupplierCd = stockSlipWork.SupplierCd;
            dcStockSlipWork.SupplierNm1 = stockSlipWork.SupplierNm1;
            dcStockSlipWork.SupplierNm2 = stockSlipWork.SupplierNm2;
            dcStockSlipWork.SupplierSnm = stockSlipWork.SupplierSnm;
            dcStockSlipWork.BusinessTypeCode = stockSlipWork.BusinessTypeCode;
            dcStockSlipWork.BusinessTypeName = stockSlipWork.BusinessTypeName;
            dcStockSlipWork.SalesAreaCode = stockSlipWork.SalesAreaCode;
            dcStockSlipWork.SalesAreaName = stockSlipWork.SalesAreaName;
            dcStockSlipWork.StockInputCode = stockSlipWork.StockInputCode;
            dcStockSlipWork.StockInputName = stockSlipWork.StockInputName;
            dcStockSlipWork.StockAgentCode = stockSlipWork.StockAgentCode;
            dcStockSlipWork.StockAgentName = stockSlipWork.StockAgentName;
            dcStockSlipWork.SuppTtlAmntDspWayCd = stockSlipWork.SuppTtlAmntDspWayCd;
            dcStockSlipWork.TtlAmntDispRateApy = stockSlipWork.TtlAmntDispRateApy;
            dcStockSlipWork.StockTotalPrice = stockSlipWork.StockTotalPrice;
            dcStockSlipWork.StockSubttlPrice = stockSlipWork.StockSubttlPrice;
            dcStockSlipWork.StockTtlPricTaxInc = stockSlipWork.StockTtlPricTaxInc;
            dcStockSlipWork.StockTtlPricTaxExc = stockSlipWork.StockTtlPricTaxExc;
            dcStockSlipWork.StockNetPrice = stockSlipWork.StockNetPrice;
            dcStockSlipWork.StockPriceConsTax = stockSlipWork.StockPriceConsTax;
            dcStockSlipWork.TtlItdedStcOutTax = stockSlipWork.TtlItdedStcOutTax;
            dcStockSlipWork.TtlItdedStcInTax = stockSlipWork.TtlItdedStcInTax;
            dcStockSlipWork.TtlItdedStcTaxFree = stockSlipWork.TtlItdedStcTaxFree;
            dcStockSlipWork.StockOutTax = stockSlipWork.StockOutTax;
            dcStockSlipWork.StckPrcConsTaxInclu = stockSlipWork.StckPrcConsTaxInclu;
            dcStockSlipWork.StckDisTtlTaxExc = stockSlipWork.StckDisTtlTaxExc;
            dcStockSlipWork.ItdedStockDisOutTax = stockSlipWork.ItdedStockDisOutTax;
            dcStockSlipWork.ItdedStockDisInTax = stockSlipWork.ItdedStockDisInTax;
            dcStockSlipWork.ItdedStockDisTaxFre = stockSlipWork.ItdedStockDisTaxFre;
            dcStockSlipWork.StockDisOutTax = stockSlipWork.StockDisOutTax;
            dcStockSlipWork.StckDisTtlTaxInclu = stockSlipWork.StckDisTtlTaxInclu;
            dcStockSlipWork.TaxAdjust = stockSlipWork.TaxAdjust;
            dcStockSlipWork.BalanceAdjust = stockSlipWork.BalanceAdjust;
            dcStockSlipWork.SuppCTaxLayCd = stockSlipWork.SuppCTaxLayCd;
            dcStockSlipWork.SupplierConsTaxRate = stockSlipWork.SupplierConsTaxRate;
            dcStockSlipWork.AccPayConsTax = stockSlipWork.AccPayConsTax;
            dcStockSlipWork.StockFractionProcCd = stockSlipWork.StockFractionProcCd;
            dcStockSlipWork.AutoPayment = stockSlipWork.AutoPayment;
            dcStockSlipWork.AutoPaySlipNum = stockSlipWork.AutoPaySlipNum;
            dcStockSlipWork.RetGoodsReasonDiv = stockSlipWork.RetGoodsReasonDiv;
            dcStockSlipWork.RetGoodsReason = stockSlipWork.RetGoodsReason;
            dcStockSlipWork.PartySaleSlipNum = stockSlipWork.PartySaleSlipNum;
            dcStockSlipWork.SupplierSlipNote1 = stockSlipWork.SupplierSlipNote1;
            dcStockSlipWork.SupplierSlipNote2 = stockSlipWork.SupplierSlipNote2;
            dcStockSlipWork.DetailRowCount = stockSlipWork.DetailRowCount;
            dcStockSlipWork.EdiSendDate = stockSlipWork.EdiSendDate;
            dcStockSlipWork.EdiTakeInDate = stockSlipWork.EdiTakeInDate;
            dcStockSlipWork.UoeRemark1 = stockSlipWork.UoeRemark1;
            dcStockSlipWork.UoeRemark2 = stockSlipWork.UoeRemark2;
            dcStockSlipWork.SlipPrintDivCd = stockSlipWork.SlipPrintDivCd;
            dcStockSlipWork.SlipPrintFinishCd = stockSlipWork.SlipPrintFinishCd;
            dcStockSlipWork.StockSlipPrintDate = stockSlipWork.StockSlipPrintDate;
            dcStockSlipWork.SlipPrtSetPaperId = stockSlipWork.SlipPrtSetPaperId;
            dcStockSlipWork.SlipAddressDiv = stockSlipWork.SlipAddressDiv;
            dcStockSlipWork.AddresseeCode = stockSlipWork.AddresseeCode;
            dcStockSlipWork.AddresseeName = stockSlipWork.AddresseeName;
            dcStockSlipWork.AddresseeName2 = stockSlipWork.AddresseeName2;
            dcStockSlipWork.AddresseePostNo = stockSlipWork.AddresseePostNo;
            dcStockSlipWork.AddresseeAddr1 = stockSlipWork.AddresseeAddr1;
            dcStockSlipWork.AddresseeAddr3 = stockSlipWork.AddresseeAddr3;
            dcStockSlipWork.AddresseeAddr4 = stockSlipWork.AddresseeAddr4;
            dcStockSlipWork.AddresseeTelNo = stockSlipWork.AddresseeTelNo;
            dcStockSlipWork.AddresseeFaxNo = stockSlipWork.AddresseeFaxNo;
            dcStockSlipWork.DirectSendingCd = stockSlipWork.DirectSendingCd;

            return dcStockSlipWork;
        }

        /// <summary>
        /// 仕入明細データPramData→UIData移項処理
        /// </summary>
        /// <param name="stockDetailWork">仕入明細データ</param>
        /// <returns>DC仕入明細データ</returns>
        public static DCStockDetailWork SearchDataFromUpdateData(APStockDetailWork stockDetailWork)
        {
            if (stockDetailWork == null)
            {
                return null;
            }

            DCStockDetailWork dcStockDetailWork = new DCStockDetailWork();

            // 変換
            dcStockDetailWork.CreateDateTime = stockDetailWork.CreateDateTime;
            dcStockDetailWork.UpdateDateTime = stockDetailWork.UpdateDateTime;
            dcStockDetailWork.EnterpriseCode = stockDetailWork.EnterpriseCode;
            dcStockDetailWork.FileHeaderGuid = stockDetailWork.FileHeaderGuid;
            dcStockDetailWork.UpdEmployeeCode = stockDetailWork.UpdEmployeeCode;
            dcStockDetailWork.UpdAssemblyId1 = stockDetailWork.UpdAssemblyId1;
            dcStockDetailWork.UpdAssemblyId2 = stockDetailWork.UpdAssemblyId2;
            dcStockDetailWork.LogicalDeleteCode = stockDetailWork.LogicalDeleteCode;
            dcStockDetailWork.AcceptAnOrderNo = stockDetailWork.AcceptAnOrderNo;
            dcStockDetailWork.SupplierFormal = stockDetailWork.SupplierFormal;
            dcStockDetailWork.SupplierSlipNo = stockDetailWork.SupplierSlipNo;
            dcStockDetailWork.StockRowNo = stockDetailWork.StockRowNo;
            dcStockDetailWork.SectionCode = stockDetailWork.SectionCode;
            dcStockDetailWork.SubSectionCode = stockDetailWork.SubSectionCode;
            dcStockDetailWork.CommonSeqNo = stockDetailWork.CommonSeqNo;
            dcStockDetailWork.StockSlipDtlNum = stockDetailWork.StockSlipDtlNum;
            dcStockDetailWork.SupplierFormalSrc = stockDetailWork.SupplierFormalSrc;
            dcStockDetailWork.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNumSrc;
            dcStockDetailWork.AcptAnOdrStatusSync = stockDetailWork.AcptAnOdrStatusSync;
            dcStockDetailWork.SalesSlipDtlNumSync = stockDetailWork.SalesSlipDtlNumSync;
            dcStockDetailWork.StockSlipCdDtl = stockDetailWork.StockSlipCdDtl;
            dcStockDetailWork.StockInputCode = stockDetailWork.StockInputCode;
            dcStockDetailWork.StockInputName = stockDetailWork.StockInputName;
            dcStockDetailWork.StockAgentCode = stockDetailWork.StockAgentCode;
            dcStockDetailWork.StockAgentName = stockDetailWork.StockAgentName;
            dcStockDetailWork.GoodsKindCode = stockDetailWork.GoodsKindCode;
            dcStockDetailWork.GoodsMakerCd = stockDetailWork.GoodsMakerCd;
            dcStockDetailWork.MakerName = stockDetailWork.MakerName;
            dcStockDetailWork.MakerKanaName = stockDetailWork.MakerKanaName;
            dcStockDetailWork.CmpltMakerKanaName = stockDetailWork.CmpltMakerKanaName;
            dcStockDetailWork.GoodsNo = stockDetailWork.GoodsNo;
            dcStockDetailWork.GoodsName = stockDetailWork.GoodsName;
            dcStockDetailWork.GoodsNameKana = stockDetailWork.GoodsNameKana;
            dcStockDetailWork.GoodsLGroup = stockDetailWork.GoodsLGroup;
            dcStockDetailWork.GoodsLGroupName = stockDetailWork.GoodsLGroupName;
            dcStockDetailWork.GoodsMGroup = stockDetailWork.GoodsMGroup;
            dcStockDetailWork.GoodsMGroupName = stockDetailWork.GoodsMGroupName;
            dcStockDetailWork.BLGroupCode = stockDetailWork.BLGroupCode;
            dcStockDetailWork.BLGroupName = stockDetailWork.BLGroupName;
            dcStockDetailWork.BLGoodsCode = stockDetailWork.BLGoodsCode;
            dcStockDetailWork.BLGoodsFullName = stockDetailWork.BLGoodsFullName;
            dcStockDetailWork.EnterpriseGanreCode = stockDetailWork.EnterpriseGanreCode;
            dcStockDetailWork.EnterpriseGanreName = stockDetailWork.EnterpriseGanreName;
            dcStockDetailWork.WarehouseCode = stockDetailWork.WarehouseCode;
            dcStockDetailWork.WarehouseName = stockDetailWork.WarehouseName;
            dcStockDetailWork.WarehouseShelfNo = stockDetailWork.WarehouseShelfNo;
            dcStockDetailWork.StockOrderDivCd = stockDetailWork.StockOrderDivCd;
            dcStockDetailWork.OpenPriceDiv = stockDetailWork.OpenPriceDiv;
            dcStockDetailWork.GoodsRateRank = stockDetailWork.GoodsRateRank;
            dcStockDetailWork.CustRateGrpCode = stockDetailWork.CustRateGrpCode;
            dcStockDetailWork.SuppRateGrpCode = stockDetailWork.SuppRateGrpCode;
            dcStockDetailWork.ListPriceTaxExcFl = stockDetailWork.ListPriceTaxExcFl;
            dcStockDetailWork.ListPriceTaxIncFl = stockDetailWork.ListPriceTaxIncFl;
            dcStockDetailWork.StockRate = stockDetailWork.StockRate;
            dcStockDetailWork.RateSectStckUnPrc = stockDetailWork.RateSectStckUnPrc;
            dcStockDetailWork.RateDivStckUnPrc = stockDetailWork.RateDivStckUnPrc;
            dcStockDetailWork.UnPrcCalcCdStckUnPrc = stockDetailWork.UnPrcCalcCdStckUnPrc;
            dcStockDetailWork.PriceCdStckUnPrc = stockDetailWork.PriceCdStckUnPrc;
            dcStockDetailWork.StdUnPrcStckUnPrc = stockDetailWork.StdUnPrcStckUnPrc;
            dcStockDetailWork.FracProcUnitStcUnPrc = stockDetailWork.FracProcUnitStcUnPrc;
            dcStockDetailWork.FracProcStckUnPrc = stockDetailWork.FracProcStckUnPrc;
            dcStockDetailWork.StockUnitPriceFl = stockDetailWork.StockUnitPriceFl;
            dcStockDetailWork.StockUnitTaxPriceFl = stockDetailWork.StockUnitTaxPriceFl;
            dcStockDetailWork.StockUnitChngDiv = stockDetailWork.StockUnitChngDiv;
            dcStockDetailWork.BfStockUnitPriceFl = stockDetailWork.BfStockUnitPriceFl;
            dcStockDetailWork.BfListPrice = stockDetailWork.BfListPrice;
            dcStockDetailWork.RateBLGoodsCode = stockDetailWork.RateBLGoodsCode;
            dcStockDetailWork.RateBLGoodsName = stockDetailWork.RateBLGoodsName;
            dcStockDetailWork.RateGoodsRateGrpCd = stockDetailWork.RateGoodsRateGrpCd;
            dcStockDetailWork.RateGoodsRateGrpNm = stockDetailWork.RateGoodsRateGrpNm;
            dcStockDetailWork.RateBLGroupCode = stockDetailWork.RateBLGroupCode;
            dcStockDetailWork.RateBLGroupName = stockDetailWork.RateBLGroupName;
            dcStockDetailWork.StockCount = stockDetailWork.StockCount;
            dcStockDetailWork.OrderCnt = stockDetailWork.OrderCnt;
            dcStockDetailWork.OrderAdjustCnt = stockDetailWork.OrderAdjustCnt;
            dcStockDetailWork.OrderRemainCnt = stockDetailWork.OrderRemainCnt;
            dcStockDetailWork.RemainCntUpdDate = stockDetailWork.RemainCntUpdDate;
            dcStockDetailWork.StockPriceTaxExc = stockDetailWork.StockPriceTaxExc;
            dcStockDetailWork.StockPriceTaxInc = stockDetailWork.StockPriceTaxInc;
            dcStockDetailWork.StockGoodsCd = stockDetailWork.StockGoodsCd;
            dcStockDetailWork.StockPriceConsTax = stockDetailWork.StockPriceConsTax;
            dcStockDetailWork.TaxationCode = stockDetailWork.TaxationCode;
            dcStockDetailWork.StockDtiSlipNote1 = stockDetailWork.StockDtiSlipNote1;
            dcStockDetailWork.SalesCustomerCode = stockDetailWork.SalesCustomerCode;
            dcStockDetailWork.SalesCustomerSnm = stockDetailWork.SalesCustomerSnm;
            dcStockDetailWork.SlipMemo1 = stockDetailWork.SlipMemo1;
            dcStockDetailWork.SlipMemo2 = stockDetailWork.SlipMemo2;
            dcStockDetailWork.SlipMemo3 = stockDetailWork.SlipMemo3;
            dcStockDetailWork.InsideMemo1 = stockDetailWork.InsideMemo1;
            dcStockDetailWork.InsideMemo2 = stockDetailWork.InsideMemo2;
            dcStockDetailWork.InsideMemo3 = stockDetailWork.InsideMemo3;
            dcStockDetailWork.SupplierCd = stockDetailWork.SupplierCd;
            dcStockDetailWork.SupplierSnm = stockDetailWork.SupplierSnm;
            dcStockDetailWork.AddresseeCode = stockDetailWork.AddresseeCode;
            dcStockDetailWork.AddresseeName = stockDetailWork.AddresseeName;
            dcStockDetailWork.DirectSendingCd = stockDetailWork.DirectSendingCd;
            dcStockDetailWork.OrderNumber = stockDetailWork.OrderNumber;
            dcStockDetailWork.WayToOrder = stockDetailWork.WayToOrder;
            dcStockDetailWork.DeliGdsCmpltDueDate = stockDetailWork.DeliGdsCmpltDueDate;
            dcStockDetailWork.ExpectDeliveryDate = stockDetailWork.ExpectDeliveryDate;
            dcStockDetailWork.OrderDataCreateDiv = stockDetailWork.OrderDataCreateDiv;
            dcStockDetailWork.OrderDataCreateDate = stockDetailWork.OrderDataCreateDate;
            dcStockDetailWork.OrderFormIssuedDiv = stockDetailWork.OrderFormIssuedDiv;

            return dcStockDetailWork;
        }

        /// <summary>
        /// 仕入履歴データPramData→UIData移項処理
        /// </summary>
        /// <param name="stockSlipHistWork">仕入履歴データ</param>
        /// <returns>DC仕入履歴データ</returns>
        public static DCStockSlipHistWork SearchDataFromUpdateData(APStockSlipHistWork stockSlipHistWork)
        {
            if (stockSlipHistWork == null)
            {
                return null;
            }

            DCStockSlipHistWork dcStockSlipHistWork = new DCStockSlipHistWork();

            // 仕入履歴データ変換
            dcStockSlipHistWork.CreateDateTime = stockSlipHistWork.CreateDateTime;
            dcStockSlipHistWork.UpdateDateTime = stockSlipHistWork.UpdateDateTime;
            dcStockSlipHistWork.EnterpriseCode = stockSlipHistWork.EnterpriseCode;
            dcStockSlipHistWork.FileHeaderGuid = stockSlipHistWork.FileHeaderGuid;
            dcStockSlipHistWork.UpdEmployeeCode = stockSlipHistWork.UpdEmployeeCode;
            dcStockSlipHistWork.UpdAssemblyId1 = stockSlipHistWork.UpdAssemblyId1;
            dcStockSlipHistWork.UpdAssemblyId2 = stockSlipHistWork.UpdAssemblyId2;
            dcStockSlipHistWork.LogicalDeleteCode = stockSlipHistWork.LogicalDeleteCode;
            dcStockSlipHistWork.SupplierFormal = stockSlipHistWork.SupplierFormal;
            dcStockSlipHistWork.SupplierSlipNo = stockSlipHistWork.SupplierSlipNo;
            dcStockSlipHistWork.SectionCode = stockSlipHistWork.SectionCode;
            dcStockSlipHistWork.SubSectionCode = stockSlipHistWork.SubSectionCode;
            dcStockSlipHistWork.DebitNoteDiv = stockSlipHistWork.DebitNoteDiv;
            dcStockSlipHistWork.DebitNLnkSuppSlipNo = stockSlipHistWork.DebitNLnkSuppSlipNo;
            dcStockSlipHistWork.SupplierSlipCd = stockSlipHistWork.SupplierSlipCd;
            dcStockSlipHistWork.StockGoodsCd = stockSlipHistWork.StockGoodsCd;
            dcStockSlipHistWork.AccPayDivCd = stockSlipHistWork.AccPayDivCd;
            dcStockSlipHistWork.StockSectionCd = stockSlipHistWork.StockSectionCd;
            dcStockSlipHistWork.StockAddUpSectionCd = stockSlipHistWork.StockAddUpSectionCd;
            dcStockSlipHistWork.StockSlipUpdateCd = stockSlipHistWork.StockSlipUpdateCd;
            dcStockSlipHistWork.InputDay = stockSlipHistWork.InputDay;
            dcStockSlipHistWork.ArrivalGoodsDay = stockSlipHistWork.ArrivalGoodsDay;
            dcStockSlipHistWork.StockDate = stockSlipHistWork.StockDate;
            dcStockSlipHistWork.StockAddUpADate = stockSlipHistWork.StockAddUpADate;
            dcStockSlipHistWork.DelayPaymentDiv = stockSlipHistWork.DelayPaymentDiv;
            dcStockSlipHistWork.PayeeCode = stockSlipHistWork.PayeeCode;
            dcStockSlipHistWork.PayeeSnm = stockSlipHistWork.PayeeSnm;
            dcStockSlipHistWork.SupplierCd = stockSlipHistWork.SupplierCd;
            dcStockSlipHistWork.SupplierNm1 = stockSlipHistWork.SupplierNm1;
            dcStockSlipHistWork.SupplierNm2 = stockSlipHistWork.SupplierNm2;
            dcStockSlipHistWork.SupplierSnm = stockSlipHistWork.SupplierSnm;
            dcStockSlipHistWork.BusinessTypeCode = stockSlipHistWork.BusinessTypeCode;
            dcStockSlipHistWork.BusinessTypeName = stockSlipHistWork.BusinessTypeName;
            dcStockSlipHistWork.SalesAreaCode = stockSlipHistWork.SalesAreaCode;
            dcStockSlipHistWork.SalesAreaName = stockSlipHistWork.SalesAreaName;
            dcStockSlipHistWork.StockInputCode = stockSlipHistWork.StockInputCode;
            dcStockSlipHistWork.StockInputName = stockSlipHistWork.StockInputName;
            dcStockSlipHistWork.StockAgentCode = stockSlipHistWork.StockAgentCode;
            dcStockSlipHistWork.StockAgentName = stockSlipHistWork.StockAgentName;
            dcStockSlipHistWork.SuppTtlAmntDspWayCd = stockSlipHistWork.SuppTtlAmntDspWayCd;
            dcStockSlipHistWork.TtlAmntDispRateApy = stockSlipHistWork.TtlAmntDispRateApy;
            dcStockSlipHistWork.StockTotalPrice = stockSlipHistWork.StockTotalPrice;
            dcStockSlipHistWork.StockSubttlPrice = stockSlipHistWork.StockSubttlPrice;
            dcStockSlipHistWork.StockTtlPricTaxInc = stockSlipHistWork.StockTtlPricTaxInc;
            dcStockSlipHistWork.StockTtlPricTaxExc = stockSlipHistWork.StockTtlPricTaxExc;
            dcStockSlipHistWork.StockNetPrice = stockSlipHistWork.StockNetPrice;
            dcStockSlipHistWork.StockPriceConsTax = stockSlipHistWork.StockPriceConsTax;
            dcStockSlipHistWork.TtlItdedStcOutTax = stockSlipHistWork.TtlItdedStcOutTax;
            dcStockSlipHistWork.TtlItdedStcInTax = stockSlipHistWork.TtlItdedStcInTax;
            dcStockSlipHistWork.TtlItdedStcTaxFree = stockSlipHistWork.TtlItdedStcTaxFree;
            dcStockSlipHistWork.StockOutTax = stockSlipHistWork.StockOutTax;
            dcStockSlipHistWork.StckPrcConsTaxInclu = stockSlipHistWork.StckPrcConsTaxInclu;
            dcStockSlipHistWork.StckDisTtlTaxExc = stockSlipHistWork.StckDisTtlTaxExc;
            dcStockSlipHistWork.ItdedStockDisOutTax = stockSlipHistWork.ItdedStockDisOutTax;
            dcStockSlipHistWork.ItdedStockDisInTax = stockSlipHistWork.ItdedStockDisInTax;
            dcStockSlipHistWork.ItdedStockDisTaxFre = stockSlipHistWork.ItdedStockDisTaxFre;
            dcStockSlipHistWork.StockDisOutTax = stockSlipHistWork.StockDisOutTax;
            dcStockSlipHistWork.StckDisTtlTaxInclu = stockSlipHistWork.StckDisTtlTaxInclu;
            dcStockSlipHistWork.TaxAdjust = stockSlipHistWork.TaxAdjust;
            dcStockSlipHistWork.BalanceAdjust = stockSlipHistWork.BalanceAdjust;
            dcStockSlipHistWork.SuppCTaxLayCd = stockSlipHistWork.SuppCTaxLayCd;
            dcStockSlipHistWork.SupplierConsTaxRate = stockSlipHistWork.SupplierConsTaxRate;
            dcStockSlipHistWork.AccPayConsTax = stockSlipHistWork.AccPayConsTax;
            dcStockSlipHistWork.StockFractionProcCd = stockSlipHistWork.StockFractionProcCd;
            dcStockSlipHistWork.AutoPayment = stockSlipHistWork.AutoPayment;
            dcStockSlipHistWork.AutoPaySlipNum = stockSlipHistWork.AutoPaySlipNum;
            dcStockSlipHistWork.RetGoodsReasonDiv = stockSlipHistWork.RetGoodsReasonDiv;
            dcStockSlipHistWork.RetGoodsReason = stockSlipHistWork.RetGoodsReason;
            dcStockSlipHistWork.PartySaleSlipNum = stockSlipHistWork.PartySaleSlipNum;
            dcStockSlipHistWork.SupplierSlipNote1 = stockSlipHistWork.SupplierSlipNote1;
            dcStockSlipHistWork.SupplierSlipNote2 = stockSlipHistWork.SupplierSlipNote2;
            dcStockSlipHistWork.DetailRowCount = stockSlipHistWork.DetailRowCount;
            dcStockSlipHistWork.EdiSendDate = stockSlipHistWork.EdiSendDate;
            dcStockSlipHistWork.EdiTakeInDate = stockSlipHistWork.EdiTakeInDate;
            dcStockSlipHistWork.UoeRemark1 = stockSlipHistWork.UoeRemark1;
            dcStockSlipHistWork.UoeRemark2 = stockSlipHistWork.UoeRemark2;
            dcStockSlipHistWork.SlipPrintDivCd = stockSlipHistWork.SlipPrintDivCd;
            dcStockSlipHistWork.SlipPrintFinishCd = stockSlipHistWork.SlipPrintFinishCd;
            dcStockSlipHistWork.StockSlipPrintDate = stockSlipHistWork.StockSlipPrintDate;
            dcStockSlipHistWork.SlipPrtSetPaperId = stockSlipHistWork.SlipPrtSetPaperId;

            return dcStockSlipHistWork;
        }

        /// <summary>
        /// 仕入履歴明細データPramData→UIData移項処理
        /// </summary>
        /// <param name="stockSlHistDtlWork">仕入履歴明細データ</param>
        /// <returns>DC仕入履歴明細データ</returns>
        public static DCStockSlHistDtlWork SearchDataFromUpdateData(APStockSlHistDtlWork stockSlHistDtlWork)
        {
            if (stockSlHistDtlWork == null)
            {
                return null;
            }

            DCStockSlHistDtlWork dcStockSlHistDtlWork = new DCStockSlHistDtlWork();

            // 仕入履歴明細データ変換
            dcStockSlHistDtlWork.CreateDateTime = stockSlHistDtlWork.CreateDateTime;
            dcStockSlHistDtlWork.UpdateDateTime = stockSlHistDtlWork.UpdateDateTime;
            dcStockSlHistDtlWork.EnterpriseCode = stockSlHistDtlWork.EnterpriseCode;
            dcStockSlHistDtlWork.FileHeaderGuid = stockSlHistDtlWork.FileHeaderGuid;
            dcStockSlHistDtlWork.UpdEmployeeCode = stockSlHistDtlWork.UpdEmployeeCode;
            dcStockSlHistDtlWork.UpdAssemblyId1 = stockSlHistDtlWork.UpdAssemblyId1;
            dcStockSlHistDtlWork.UpdAssemblyId2 = stockSlHistDtlWork.UpdAssemblyId2;
            dcStockSlHistDtlWork.LogicalDeleteCode = stockSlHistDtlWork.LogicalDeleteCode;
            dcStockSlHistDtlWork.AcceptAnOrderNo = stockSlHistDtlWork.AcceptAnOrderNo;
            dcStockSlHistDtlWork.SupplierFormal = stockSlHistDtlWork.SupplierFormal;
            dcStockSlHistDtlWork.SupplierSlipNo = stockSlHistDtlWork.SupplierSlipNo;
            dcStockSlHistDtlWork.StockRowNo = stockSlHistDtlWork.StockRowNo;
            dcStockSlHistDtlWork.SectionCode = stockSlHistDtlWork.SectionCode;
            dcStockSlHistDtlWork.SubSectionCode = stockSlHistDtlWork.SubSectionCode;
            dcStockSlHistDtlWork.CommonSeqNo = stockSlHistDtlWork.CommonSeqNo;
            dcStockSlHistDtlWork.StockSlipDtlNum = stockSlHistDtlWork.StockSlipDtlNum;
            dcStockSlHistDtlWork.SupplierFormalSrc = stockSlHistDtlWork.SupplierFormalSrc;
            dcStockSlHistDtlWork.StockSlipDtlNumSrc = stockSlHistDtlWork.StockSlipDtlNumSrc;
            dcStockSlHistDtlWork.AcptAnOdrStatusSync = stockSlHistDtlWork.AcptAnOdrStatusSync;
            dcStockSlHistDtlWork.SalesSlipDtlNumSync = stockSlHistDtlWork.SalesSlipDtlNumSync;
            dcStockSlHistDtlWork.StockSlipCdDtl = stockSlHistDtlWork.StockSlipCdDtl;
            dcStockSlHistDtlWork.StockAgentCode = stockSlHistDtlWork.StockAgentCode;
            dcStockSlHistDtlWork.StockAgentName = stockSlHistDtlWork.StockAgentName;
            dcStockSlHistDtlWork.GoodsKindCode = stockSlHistDtlWork.GoodsKindCode;
            dcStockSlHistDtlWork.GoodsMakerCd = stockSlHistDtlWork.GoodsMakerCd;
            dcStockSlHistDtlWork.MakerName = stockSlHistDtlWork.MakerName;
            dcStockSlHistDtlWork.MakerKanaName = stockSlHistDtlWork.MakerKanaName;
            dcStockSlHistDtlWork.CmpltMakerKanaName = stockSlHistDtlWork.CmpltMakerKanaName;
            dcStockSlHistDtlWork.GoodsNo = stockSlHistDtlWork.GoodsNo;
            dcStockSlHistDtlWork.GoodsName = stockSlHistDtlWork.GoodsName;
            dcStockSlHistDtlWork.GoodsNameKana = stockSlHistDtlWork.GoodsNameKana;
            dcStockSlHistDtlWork.GoodsLGroup = stockSlHistDtlWork.GoodsLGroup;
            dcStockSlHistDtlWork.GoodsLGroupName = stockSlHistDtlWork.GoodsLGroupName;
            dcStockSlHistDtlWork.GoodsMGroup = stockSlHistDtlWork.GoodsMGroup;
            dcStockSlHistDtlWork.GoodsMGroupName = stockSlHistDtlWork.GoodsMGroupName;
            dcStockSlHistDtlWork.BLGroupCode = stockSlHistDtlWork.BLGroupCode;
            dcStockSlHistDtlWork.BLGroupName = stockSlHistDtlWork.BLGroupName;
            dcStockSlHistDtlWork.BLGoodsCode = stockSlHistDtlWork.BLGoodsCode;
            dcStockSlHistDtlWork.BLGoodsFullName = stockSlHistDtlWork.BLGoodsFullName;
            dcStockSlHistDtlWork.EnterpriseGanreCode = stockSlHistDtlWork.EnterpriseGanreCode;
            dcStockSlHistDtlWork.EnterpriseGanreName = stockSlHistDtlWork.EnterpriseGanreName;
            dcStockSlHistDtlWork.WarehouseCode = stockSlHistDtlWork.WarehouseCode;
            dcStockSlHistDtlWork.WarehouseName = stockSlHistDtlWork.WarehouseName;
            dcStockSlHistDtlWork.WarehouseShelfNo = stockSlHistDtlWork.WarehouseShelfNo;
            dcStockSlHistDtlWork.StockOrderDivCd = stockSlHistDtlWork.StockOrderDivCd;
            dcStockSlHistDtlWork.OpenPriceDiv = stockSlHistDtlWork.OpenPriceDiv;
            dcStockSlHistDtlWork.GoodsRateRank = stockSlHistDtlWork.GoodsRateRank;
            dcStockSlHistDtlWork.CustRateGrpCode = stockSlHistDtlWork.CustRateGrpCode;
            dcStockSlHistDtlWork.SuppRateGrpCode = stockSlHistDtlWork.SuppRateGrpCode;
            dcStockSlHistDtlWork.ListPriceTaxExcFl = stockSlHistDtlWork.ListPriceTaxExcFl;
            dcStockSlHistDtlWork.ListPriceTaxIncFl = stockSlHistDtlWork.ListPriceTaxIncFl;
            dcStockSlHistDtlWork.StockRate = stockSlHistDtlWork.StockRate;
            dcStockSlHistDtlWork.RateSectStckUnPrc = stockSlHistDtlWork.RateSectStckUnPrc;
            dcStockSlHistDtlWork.RateDivStckUnPrc = stockSlHistDtlWork.RateDivStckUnPrc;
            dcStockSlHistDtlWork.UnPrcCalcCdStckUnPrc = stockSlHistDtlWork.UnPrcCalcCdStckUnPrc;
            dcStockSlHistDtlWork.PriceCdStckUnPrc = stockSlHistDtlWork.PriceCdStckUnPrc;
            dcStockSlHistDtlWork.StdUnPrcStckUnPrc = stockSlHistDtlWork.StdUnPrcStckUnPrc;
            dcStockSlHistDtlWork.FracProcUnitStcUnPrc = stockSlHistDtlWork.FracProcUnitStcUnPrc;
            dcStockSlHistDtlWork.FracProcStckUnPrc = stockSlHistDtlWork.FracProcStckUnPrc;
            dcStockSlHistDtlWork.StockUnitPriceFl = stockSlHistDtlWork.StockUnitPriceFl;
            dcStockSlHistDtlWork.StockUnitTaxPriceFl = stockSlHistDtlWork.StockUnitTaxPriceFl;
            dcStockSlHistDtlWork.StockUnitChngDiv = stockSlHistDtlWork.StockUnitChngDiv;
            dcStockSlHistDtlWork.BfStockUnitPriceFl = stockSlHistDtlWork.BfStockUnitPriceFl;
            dcStockSlHistDtlWork.BfListPrice = stockSlHistDtlWork.BfListPrice;
            dcStockSlHistDtlWork.RateBLGoodsCode = stockSlHistDtlWork.RateBLGoodsCode;
            dcStockSlHistDtlWork.RateBLGoodsName = stockSlHistDtlWork.RateBLGoodsName;
            dcStockSlHistDtlWork.RateGoodsRateGrpCd = stockSlHistDtlWork.RateGoodsRateGrpCd;
            dcStockSlHistDtlWork.RateGoodsRateGrpNm = stockSlHistDtlWork.RateGoodsRateGrpNm;
            dcStockSlHistDtlWork.RateBLGroupCode = stockSlHistDtlWork.RateBLGroupCode;
            dcStockSlHistDtlWork.RateBLGroupName = stockSlHistDtlWork.RateBLGroupName;
            dcStockSlHistDtlWork.StockCount = stockSlHistDtlWork.StockCount;
            dcStockSlHistDtlWork.StockPriceTaxExc = stockSlHistDtlWork.StockPriceTaxExc;
            dcStockSlHistDtlWork.StockPriceTaxInc = stockSlHistDtlWork.StockPriceTaxInc;
            dcStockSlHistDtlWork.StockGoodsCd = stockSlHistDtlWork.StockGoodsCd;
            dcStockSlHistDtlWork.StockPriceConsTax = stockSlHistDtlWork.StockPriceConsTax;
            dcStockSlHistDtlWork.TaxationCode = stockSlHistDtlWork.TaxationCode;
            dcStockSlHistDtlWork.StockDtiSlipNote1 = stockSlHistDtlWork.StockDtiSlipNote1;
            dcStockSlHistDtlWork.SalesCustomerCode = stockSlHistDtlWork.SalesCustomerCode;
            dcStockSlHistDtlWork.SalesCustomerSnm = stockSlHistDtlWork.SalesCustomerSnm;
            dcStockSlHistDtlWork.OrderNumber = stockSlHistDtlWork.OrderNumber;
            dcStockSlHistDtlWork.SlipMemo1 = stockSlHistDtlWork.SlipMemo1;
            dcStockSlHistDtlWork.SlipMemo2 = stockSlHistDtlWork.SlipMemo2;
            dcStockSlHistDtlWork.SlipMemo3 = stockSlHistDtlWork.SlipMemo3;
            dcStockSlHistDtlWork.InsideMemo1 = stockSlHistDtlWork.InsideMemo1;
            dcStockSlHistDtlWork.InsideMemo2 = stockSlHistDtlWork.InsideMemo2;
            dcStockSlHistDtlWork.InsideMemo3 = stockSlHistDtlWork.InsideMemo3;

            return dcStockSlHistDtlWork;
        }

        /// <summary>
        /// 支払伝票マスタPramData→UIData移項処理
        /// </summary>
        /// <param name="paymentSlpWork">支払伝票マスタ</param>
        /// <returns>DC支払伝票マスタ</returns>
        public static DCPaymentSlpWork SearchDataFromUpdateData(APPaymentSlpWork paymentSlpWork)
        {
            if (paymentSlpWork == null)
            {
                return null;
            }

            DCPaymentSlpWork dcPaymentSlpWork = new DCPaymentSlpWork();

            // 支払伝票マスタ変換
            dcPaymentSlpWork.CreateDateTime = paymentSlpWork.CreateDateTime;
            dcPaymentSlpWork.UpdateDateTime = paymentSlpWork.UpdateDateTime;
            dcPaymentSlpWork.EnterpriseCode = paymentSlpWork.EnterpriseCode;
            dcPaymentSlpWork.FileHeaderGuid = paymentSlpWork.FileHeaderGuid;
            dcPaymentSlpWork.UpdEmployeeCode = paymentSlpWork.UpdEmployeeCode;
            dcPaymentSlpWork.UpdAssemblyId1 = paymentSlpWork.UpdAssemblyId1;
            dcPaymentSlpWork.UpdAssemblyId2 = paymentSlpWork.UpdAssemblyId2;
            dcPaymentSlpWork.LogicalDeleteCode = paymentSlpWork.LogicalDeleteCode;
            dcPaymentSlpWork.DebitNoteDiv = paymentSlpWork.DebitNoteDiv;
            dcPaymentSlpWork.PaymentSlipNo = paymentSlpWork.PaymentSlipNo;
            dcPaymentSlpWork.SupplierFormal = paymentSlpWork.SupplierFormal;
            dcPaymentSlpWork.SupplierSlipNo = paymentSlpWork.SupplierSlipNo;
            dcPaymentSlpWork.SupplierCd = paymentSlpWork.SupplierCd;
            dcPaymentSlpWork.SupplierNm1 = paymentSlpWork.SupplierNm1;
            dcPaymentSlpWork.SupplierNm2 = paymentSlpWork.SupplierNm2;
            dcPaymentSlpWork.SupplierSnm = paymentSlpWork.SupplierSnm;
            dcPaymentSlpWork.PayeeCode = paymentSlpWork.PayeeCode;
            dcPaymentSlpWork.PayeeName = paymentSlpWork.PayeeName;
            dcPaymentSlpWork.PayeeName2 = paymentSlpWork.PayeeName2;
            dcPaymentSlpWork.PayeeSnm = paymentSlpWork.PayeeSnm;
            dcPaymentSlpWork.PaymentInpSectionCd = paymentSlpWork.PaymentInpSectionCd;
            dcPaymentSlpWork.InputDay = paymentSlpWork.InputDay;
            dcPaymentSlpWork.AddUpSecCode = paymentSlpWork.AddUpSecCode;
            dcPaymentSlpWork.UpdateSecCd = paymentSlpWork.UpdateSecCd;
            dcPaymentSlpWork.SubSectionCode = paymentSlpWork.SubSectionCode;
            dcPaymentSlpWork.PaymentDate = paymentSlpWork.PaymentDate;
            dcPaymentSlpWork.AddUpADate = paymentSlpWork.AddUpADate;
            dcPaymentSlpWork.PaymentTotal = paymentSlpWork.PaymentTotal;
            dcPaymentSlpWork.Payment = paymentSlpWork.Payment;
            dcPaymentSlpWork.FeePayment = paymentSlpWork.FeePayment;
            dcPaymentSlpWork.DiscountPayment = paymentSlpWork.DiscountPayment;
            dcPaymentSlpWork.AutoPayment = paymentSlpWork.AutoPayment;
            dcPaymentSlpWork.DraftDrawingDate = paymentSlpWork.DraftDrawingDate;
            dcPaymentSlpWork.DraftKind = paymentSlpWork.DraftKind;
            dcPaymentSlpWork.DraftKindName = paymentSlpWork.DraftKindName;
            dcPaymentSlpWork.DraftDivide = paymentSlpWork.DraftDivide;
            dcPaymentSlpWork.DraftDivideName = paymentSlpWork.DraftDivideName;
            dcPaymentSlpWork.DraftNo = paymentSlpWork.DraftNo;
            dcPaymentSlpWork.DebitNoteLinkPayNo = paymentSlpWork.DebitNoteLinkPayNo;
            dcPaymentSlpWork.PaymentAgentCode = paymentSlpWork.PaymentAgentCode;
            dcPaymentSlpWork.PaymentAgentName = paymentSlpWork.PaymentAgentName;
            dcPaymentSlpWork.PaymentInputAgentCd = paymentSlpWork.PaymentInputAgentCd;
            dcPaymentSlpWork.PaymentInputAgentNm = paymentSlpWork.PaymentInputAgentNm;
            dcPaymentSlpWork.Outline = paymentSlpWork.Outline;
            dcPaymentSlpWork.BankCode = paymentSlpWork.BankCode;
            dcPaymentSlpWork.BankName = paymentSlpWork.BankName;

            return dcPaymentSlpWork;
        }

        /// <summary>
        /// 支払明細データPramData→UIData移項処理
        /// </summary>
        /// <param name="paymentDtlWork">支払明細データ</param>
        /// <returns>DC支払明細データ</returns>
        public static DCPaymentDtlWork SearchDataFromUpdateData(APPaymentDtlWork paymentDtlWork)
        {
            if (paymentDtlWork == null)
            {
                return null;
            }

            DCPaymentDtlWork dcPaymentDtlWork = new DCPaymentDtlWork();

            // 支払明細データ変換
            dcPaymentDtlWork.CreateDateTime = paymentDtlWork.CreateDateTime;
            dcPaymentDtlWork.UpdateDateTime = paymentDtlWork.UpdateDateTime;
            dcPaymentDtlWork.EnterpriseCode = paymentDtlWork.EnterpriseCode;
            dcPaymentDtlWork.FileHeaderGuid = paymentDtlWork.FileHeaderGuid;
            dcPaymentDtlWork.UpdEmployeeCode = paymentDtlWork.UpdEmployeeCode;
            dcPaymentDtlWork.UpdAssemblyId1 = paymentDtlWork.UpdAssemblyId1;
            dcPaymentDtlWork.UpdAssemblyId2 = paymentDtlWork.UpdAssemblyId2;
            dcPaymentDtlWork.LogicalDeleteCode = paymentDtlWork.LogicalDeleteCode;
            dcPaymentDtlWork.SupplierFormal = paymentDtlWork.SupplierFormal;
            dcPaymentDtlWork.PaymentSlipNo = paymentDtlWork.PaymentSlipNo;
            dcPaymentDtlWork.PaymentRowNo = paymentDtlWork.PaymentRowNo;
            dcPaymentDtlWork.MoneyKindCode = paymentDtlWork.MoneyKindCode;
            dcPaymentDtlWork.MoneyKindName = paymentDtlWork.MoneyKindName;
            dcPaymentDtlWork.MoneyKindDiv = paymentDtlWork.MoneyKindDiv;
            dcPaymentDtlWork.Payment = paymentDtlWork.Payment;
            dcPaymentDtlWork.ValidityTerm = paymentDtlWork.ValidityTerm;

            return dcPaymentDtlWork;
        }

        /// <summary>
        /// 受注マスタPramData→UIData移項処理
        /// </summary>
        /// <param name="acceptOdrWork">受注マスタ</param>
        /// <returns>DC受注マスタ</returns>
        public static DCAcceptOdrWork SearchDataFromUpdateData(APAcceptOdrWork acceptOdrWork)
        {
            if (acceptOdrWork == null)
            {
                return null;
            }

            DCAcceptOdrWork dcAcceptOdrWork = new DCAcceptOdrWork();

            // 受注マスタ変換
            dcAcceptOdrWork.CreateDateTime = acceptOdrWork.CreateDateTime;
            dcAcceptOdrWork.UpdateDateTime = acceptOdrWork.UpdateDateTime;
            dcAcceptOdrWork.EnterpriseCode = acceptOdrWork.EnterpriseCode;
            dcAcceptOdrWork.FileHeaderGuid = acceptOdrWork.FileHeaderGuid;
            dcAcceptOdrWork.UpdEmployeeCode = acceptOdrWork.UpdEmployeeCode;
            dcAcceptOdrWork.UpdAssemblyId1 = acceptOdrWork.UpdAssemblyId1;
            dcAcceptOdrWork.UpdAssemblyId2 = acceptOdrWork.UpdAssemblyId2;
            dcAcceptOdrWork.LogicalDeleteCode = acceptOdrWork.LogicalDeleteCode;
            dcAcceptOdrWork.SectionCode = acceptOdrWork.SectionCode;
            dcAcceptOdrWork.AcceptAnOrderNo = acceptOdrWork.AcceptAnOrderNo;
            dcAcceptOdrWork.AcptAnOdrStatus = acceptOdrWork.AcptAnOdrStatus;
            dcAcceptOdrWork.SalesSlipNum = acceptOdrWork.SalesSlipNum;
            dcAcceptOdrWork.DataInputSystem = acceptOdrWork.DataInputSystem;
            dcAcceptOdrWork.CommonSeqNo = acceptOdrWork.CommonSeqNo;
            dcAcceptOdrWork.SlipDtlNum = acceptOdrWork.SlipDtlNum;
            dcAcceptOdrWork.SlipDtlNumDerivNo = acceptOdrWork.SlipDtlNumDerivNo;
            dcAcceptOdrWork.SrcLinkDataCode = acceptOdrWork.SrcLinkDataCode;
            dcAcceptOdrWork.SrcSlipDtlNum = acceptOdrWork.SrcSlipDtlNum;

            return dcAcceptOdrWork;
        }

        /// <summary>
        /// 受注マスタ（車両）PramData→UIData移項処理
        /// </summary>
        /// <param name="acceptOdrCarWork">受注マスタ（車両）</param>
        /// <returns>受注マスタ（車両）</returns>
        /// <br>Update Note: SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/03/22</br>
        public static DCAcceptOdrCarWork SearchDataFromUpdateData(APAcceptOdrCarWork acceptOdrCarWork)
        {
            if (acceptOdrCarWork == null)
            {
                return null;
            }

            DCAcceptOdrCarWork dcAcceptOdrCarWork = new DCAcceptOdrCarWork();

            // 受注マスタ（車両）変換
            dcAcceptOdrCarWork.CreateDateTime = acceptOdrCarWork.CreateDateTime;
            dcAcceptOdrCarWork.UpdateDateTime = acceptOdrCarWork.UpdateDateTime;
            dcAcceptOdrCarWork.EnterpriseCode = acceptOdrCarWork.EnterpriseCode;
            dcAcceptOdrCarWork.FileHeaderGuid = acceptOdrCarWork.FileHeaderGuid;
            dcAcceptOdrCarWork.UpdEmployeeCode = acceptOdrCarWork.UpdEmployeeCode;
            dcAcceptOdrCarWork.UpdAssemblyId1 = acceptOdrCarWork.UpdAssemblyId1;
            dcAcceptOdrCarWork.UpdAssemblyId2 = acceptOdrCarWork.UpdAssemblyId2;
            dcAcceptOdrCarWork.LogicalDeleteCode = acceptOdrCarWork.LogicalDeleteCode;
            dcAcceptOdrCarWork.AcceptAnOrderNo = acceptOdrCarWork.AcceptAnOrderNo;
            dcAcceptOdrCarWork.AcptAnOdrStatus = acceptOdrCarWork.AcptAnOdrStatus;
            dcAcceptOdrCarWork.DataInputSystem = acceptOdrCarWork.DataInputSystem;
            dcAcceptOdrCarWork.CarMngNo = acceptOdrCarWork.CarMngNo;
            dcAcceptOdrCarWork.CarMngCode = acceptOdrCarWork.CarMngCode;
            dcAcceptOdrCarWork.NumberPlate1Code = acceptOdrCarWork.NumberPlate1Code;
            dcAcceptOdrCarWork.NumberPlate1Name = acceptOdrCarWork.NumberPlate1Name;
            dcAcceptOdrCarWork.NumberPlate2 = acceptOdrCarWork.NumberPlate2;
            dcAcceptOdrCarWork.NumberPlate3 = acceptOdrCarWork.NumberPlate3;
            dcAcceptOdrCarWork.NumberPlate4 = acceptOdrCarWork.NumberPlate4;
            dcAcceptOdrCarWork.FirstEntryDate = acceptOdrCarWork.FirstEntryDate;
            dcAcceptOdrCarWork.MakerCode = acceptOdrCarWork.MakerCode;
            dcAcceptOdrCarWork.MakerFullName = acceptOdrCarWork.MakerFullName;
            dcAcceptOdrCarWork.MakerHalfName = acceptOdrCarWork.MakerHalfName;
            dcAcceptOdrCarWork.ModelCode = acceptOdrCarWork.ModelCode;
            dcAcceptOdrCarWork.ModelSubCode = acceptOdrCarWork.ModelSubCode;
            dcAcceptOdrCarWork.ModelFullName = acceptOdrCarWork.ModelFullName;
            dcAcceptOdrCarWork.ModelHalfName = acceptOdrCarWork.ModelHalfName;
            dcAcceptOdrCarWork.ExhaustGasSign = acceptOdrCarWork.ExhaustGasSign;
            dcAcceptOdrCarWork.SeriesModel = acceptOdrCarWork.SeriesModel;
            dcAcceptOdrCarWork.CategorySignModel = acceptOdrCarWork.CategorySignModel;
            dcAcceptOdrCarWork.FullModel = acceptOdrCarWork.FullModel;
            dcAcceptOdrCarWork.ModelDesignationNo = acceptOdrCarWork.ModelDesignationNo;
            dcAcceptOdrCarWork.CategoryNo = acceptOdrCarWork.CategoryNo;
            dcAcceptOdrCarWork.FrameModel = acceptOdrCarWork.FrameModel;
            dcAcceptOdrCarWork.FrameNo = acceptOdrCarWork.FrameNo;
            dcAcceptOdrCarWork.SearchFrameNo = acceptOdrCarWork.SearchFrameNo;
            dcAcceptOdrCarWork.EngineModelNm = acceptOdrCarWork.EngineModelNm;
            dcAcceptOdrCarWork.RelevanceModel = acceptOdrCarWork.RelevanceModel;
            dcAcceptOdrCarWork.SubCarNmCd = acceptOdrCarWork.SubCarNmCd;
            dcAcceptOdrCarWork.ModelGradeSname = acceptOdrCarWork.ModelGradeSname;
            dcAcceptOdrCarWork.ColorCode = acceptOdrCarWork.ColorCode;
            dcAcceptOdrCarWork.ColorName1 = acceptOdrCarWork.ColorName1;
            dcAcceptOdrCarWork.TrimCode = acceptOdrCarWork.TrimCode;
            dcAcceptOdrCarWork.TrimName = acceptOdrCarWork.TrimName;
            dcAcceptOdrCarWork.Mileage = acceptOdrCarWork.Mileage;
            dcAcceptOdrCarWork.FullModelFixedNoAry = acceptOdrCarWork.FullModelFixedNoAry;
            dcAcceptOdrCarWork.CategoryObjAry = acceptOdrCarWork.CategoryObjAry;
            dcAcceptOdrCarWork.CarNote = acceptOdrCarWork.CarNote;  // ADD 2009/09/14
            dcAcceptOdrCarWork.DomesticForeignCode = acceptOdrCarWork.DomesticForeignCode;  // ADD 2013/03/22            

            return dcAcceptOdrCarWork;
        }

        /// <summary>
        /// 売上月次集計データPramData→UIData移項処理
        /// </summary>
        /// <param name="mTtlSalesSlipWork">売上月次集計データ</param>
        /// <returns>売上月次集計データ</returns>
        public static DCMTtlSalesSlipWork SearchDataFromUpdateData(APMTtlSalesSlipWork mTtlSalesSlipWork)
        {
            if (mTtlSalesSlipWork == null)
            {
                return null;
            }

            DCMTtlSalesSlipWork dcMTtlSalesSlipWork = new DCMTtlSalesSlipWork();

            // 売上月次集計データ変換
            dcMTtlSalesSlipWork.CreateDateTime = mTtlSalesSlipWork.CreateDateTime;
            dcMTtlSalesSlipWork.UpdateDateTime = mTtlSalesSlipWork.UpdateDateTime;
            dcMTtlSalesSlipWork.EnterpriseCode = mTtlSalesSlipWork.EnterpriseCode;
            dcMTtlSalesSlipWork.FileHeaderGuid = mTtlSalesSlipWork.FileHeaderGuid;
            dcMTtlSalesSlipWork.UpdEmployeeCode = mTtlSalesSlipWork.UpdEmployeeCode;
            dcMTtlSalesSlipWork.UpdAssemblyId1 = mTtlSalesSlipWork.UpdAssemblyId1;
            dcMTtlSalesSlipWork.UpdAssemblyId2 = mTtlSalesSlipWork.UpdAssemblyId2;
            dcMTtlSalesSlipWork.LogicalDeleteCode = mTtlSalesSlipWork.LogicalDeleteCode;
            dcMTtlSalesSlipWork.AddUpSecCode = mTtlSalesSlipWork.AddUpSecCode;
            dcMTtlSalesSlipWork.AddUpYearMonth = mTtlSalesSlipWork.AddUpYearMonth;
            dcMTtlSalesSlipWork.RsltTtlDivCd = mTtlSalesSlipWork.RsltTtlDivCd;
            dcMTtlSalesSlipWork.EmployeeDivCd = mTtlSalesSlipWork.EmployeeDivCd;
            dcMTtlSalesSlipWork.EmployeeCode = mTtlSalesSlipWork.EmployeeCode;
            dcMTtlSalesSlipWork.CustomerCode = mTtlSalesSlipWork.CustomerCode;
            dcMTtlSalesSlipWork.SupplierCd = mTtlSalesSlipWork.SupplierCd;
            dcMTtlSalesSlipWork.SalesCode = mTtlSalesSlipWork.SalesCode;
            dcMTtlSalesSlipWork.SalesTimes = mTtlSalesSlipWork.SalesTimes;
            dcMTtlSalesSlipWork.TotalSalesCount = mTtlSalesSlipWork.TotalSalesCount;
            dcMTtlSalesSlipWork.SalesMoney = mTtlSalesSlipWork.SalesMoney;
            dcMTtlSalesSlipWork.SalesRetGoodsPrice = mTtlSalesSlipWork.SalesRetGoodsPrice;
            dcMTtlSalesSlipWork.DiscountPrice = mTtlSalesSlipWork.DiscountPrice;
            dcMTtlSalesSlipWork.GrossProfit = mTtlSalesSlipWork.GrossProfit;

            return dcMTtlSalesSlipWork;
        }

        /// <summary>
        /// 商品別売上月次集計データPramData→UIData移項処理
        /// </summary>
        /// <param name="goodsMTtlSaSlipWork">商品別売上月次集計データ</param>
        /// <returns>DC商品別売上月次集計データ</returns>
        public static DCGoodsMTtlSaSlipWork SearchDataFromUpdateData(APGoodsMTtlSaSlipWork goodsMTtlSaSlipWork)
        {
            if (goodsMTtlSaSlipWork == null)
            {
                return null;
            }

            DCGoodsMTtlSaSlipWork dcGoodsMTtlSaSlipWork = new DCGoodsMTtlSaSlipWork();

            // 商品別売上月次集計データ変換
            dcGoodsMTtlSaSlipWork.CreateDateTime = goodsMTtlSaSlipWork.CreateDateTime;
            dcGoodsMTtlSaSlipWork.UpdateDateTime = goodsMTtlSaSlipWork.UpdateDateTime;
            dcGoodsMTtlSaSlipWork.EnterpriseCode = goodsMTtlSaSlipWork.EnterpriseCode;
            dcGoodsMTtlSaSlipWork.FileHeaderGuid = goodsMTtlSaSlipWork.FileHeaderGuid;
            dcGoodsMTtlSaSlipWork.UpdEmployeeCode = goodsMTtlSaSlipWork.UpdEmployeeCode;
            dcGoodsMTtlSaSlipWork.UpdAssemblyId1 = goodsMTtlSaSlipWork.UpdAssemblyId1;
            dcGoodsMTtlSaSlipWork.UpdAssemblyId2 = goodsMTtlSaSlipWork.UpdAssemblyId2;
            dcGoodsMTtlSaSlipWork.LogicalDeleteCode = goodsMTtlSaSlipWork.LogicalDeleteCode;
            dcGoodsMTtlSaSlipWork.AddUpSecCode = goodsMTtlSaSlipWork.AddUpSecCode;
            dcGoodsMTtlSaSlipWork.AddUpYearMonth = goodsMTtlSaSlipWork.AddUpYearMonth;
            dcGoodsMTtlSaSlipWork.RsltTtlDivCd = goodsMTtlSaSlipWork.RsltTtlDivCd;
            dcGoodsMTtlSaSlipWork.EmployeeCode = goodsMTtlSaSlipWork.EmployeeCode;
            dcGoodsMTtlSaSlipWork.CustomerCode = goodsMTtlSaSlipWork.CustomerCode;
            dcGoodsMTtlSaSlipWork.BLGoodsCode = goodsMTtlSaSlipWork.BLGoodsCode;
            dcGoodsMTtlSaSlipWork.GoodsMakerCd = goodsMTtlSaSlipWork.GoodsMakerCd;
            dcGoodsMTtlSaSlipWork.GoodsNo = goodsMTtlSaSlipWork.GoodsNo;
            dcGoodsMTtlSaSlipWork.SupplierCd = goodsMTtlSaSlipWork.SupplierCd;
            dcGoodsMTtlSaSlipWork.SalesTimes = goodsMTtlSaSlipWork.SalesTimes;
            dcGoodsMTtlSaSlipWork.TotalSalesCount = goodsMTtlSaSlipWork.TotalSalesCount;
            dcGoodsMTtlSaSlipWork.SalesMoney = goodsMTtlSaSlipWork.SalesMoney;
            dcGoodsMTtlSaSlipWork.SalesRetGoodsPrice = goodsMTtlSaSlipWork.SalesRetGoodsPrice;
            dcGoodsMTtlSaSlipWork.DiscountPrice = goodsMTtlSaSlipWork.DiscountPrice;
            dcGoodsMTtlSaSlipWork.GrossProfit = goodsMTtlSaSlipWork.GrossProfit;

            return dcGoodsMTtlSaSlipWork;
        }

        /// <summary>
        /// 仕入月次集計データPramData→UIData移項処理
        /// </summary>
        /// <param name="mTtlStockSlipWork">仕入月次集計データ</param>
        /// <returns>DC仕入月次集計データ</returns>
        public static DCMTtlStockSlipWork SearchDataFromUpdateData(APMTtlStockSlipWork mTtlStockSlipWork)
        {
            if (mTtlStockSlipWork == null)
            {
                return null;
            }

            DCMTtlStockSlipWork dcMTtlStockSlipWork = new DCMTtlStockSlipWork();

            // 仕入月次集計データ変換
            dcMTtlStockSlipWork.CreateDateTime = mTtlStockSlipWork.CreateDateTime;
            dcMTtlStockSlipWork.UpdateDateTime = mTtlStockSlipWork.UpdateDateTime;
            dcMTtlStockSlipWork.EnterpriseCode = mTtlStockSlipWork.EnterpriseCode;
            dcMTtlStockSlipWork.FileHeaderGuid = mTtlStockSlipWork.FileHeaderGuid;
            dcMTtlStockSlipWork.UpdEmployeeCode = mTtlStockSlipWork.UpdEmployeeCode;
            dcMTtlStockSlipWork.UpdAssemblyId1 = mTtlStockSlipWork.UpdAssemblyId1;
            dcMTtlStockSlipWork.UpdAssemblyId2 = mTtlStockSlipWork.UpdAssemblyId2;
            dcMTtlStockSlipWork.LogicalDeleteCode = mTtlStockSlipWork.LogicalDeleteCode;
            dcMTtlStockSlipWork.StockSectionCd = mTtlStockSlipWork.StockSectionCd;
            dcMTtlStockSlipWork.StockDateYm = mTtlStockSlipWork.StockDateYm;
            dcMTtlStockSlipWork.RsltTtlDivCd = mTtlStockSlipWork.RsltTtlDivCd;
            dcMTtlStockSlipWork.EmployeeCode = mTtlStockSlipWork.EmployeeCode;
            dcMTtlStockSlipWork.SupplierCd = mTtlStockSlipWork.SupplierCd;
            dcMTtlStockSlipWork.StockTotalPrice = mTtlStockSlipWork.StockTotalPrice;
            dcMTtlStockSlipWork.TotalStockCount = mTtlStockSlipWork.TotalStockCount;
            dcMTtlStockSlipWork.StockRetGoodsPrice = mTtlStockSlipWork.StockRetGoodsPrice;
            dcMTtlStockSlipWork.StockTotalDiscount = mTtlStockSlipWork.StockTotalDiscount;

            return dcMTtlStockSlipWork;
        }

        /// <summary>
        /// 在庫調整データPramData→UIData移項処理
        /// </summary>
        /// <param name="stockAdjustWork">在庫調整データ</param>
        /// <returns>DC在庫調整データ</returns>
        public static DCStockAdjustWork SearchDataFromUpdateData(APStockAdjustWork stockAdjustWork)
        {
            if (stockAdjustWork == null)
            {
                return null;
            }

            DCStockAdjustWork dcStockAdjustWork = new DCStockAdjustWork();

            // 在庫調整データ変換
            dcStockAdjustWork.CreateDateTime = stockAdjustWork.CreateDateTime;
            dcStockAdjustWork.UpdateDateTime = stockAdjustWork.UpdateDateTime;
            dcStockAdjustWork.EnterpriseCode = stockAdjustWork.EnterpriseCode;
            dcStockAdjustWork.FileHeaderGuid = stockAdjustWork.FileHeaderGuid;
            dcStockAdjustWork.UpdEmployeeCode = stockAdjustWork.UpdEmployeeCode;
            dcStockAdjustWork.UpdAssemblyId1 = stockAdjustWork.UpdAssemblyId1;
            dcStockAdjustWork.UpdAssemblyId2 = stockAdjustWork.UpdAssemblyId2;
            dcStockAdjustWork.LogicalDeleteCode = stockAdjustWork.LogicalDeleteCode;
            dcStockAdjustWork.SectionCode = stockAdjustWork.SectionCode;
            dcStockAdjustWork.StockAdjustSlipNo = stockAdjustWork.StockAdjustSlipNo;
            dcStockAdjustWork.AcPaySlipCd = stockAdjustWork.AcPaySlipCd;
            dcStockAdjustWork.AcPayTransCd = stockAdjustWork.AcPayTransCd;
            dcStockAdjustWork.AdjustDate = stockAdjustWork.AdjustDate;
            dcStockAdjustWork.InputDay = stockAdjustWork.InputDay;
            dcStockAdjustWork.StockSectionCd = stockAdjustWork.StockSectionCd;
            dcStockAdjustWork.StockInputCode = stockAdjustWork.StockInputCode;
            dcStockAdjustWork.StockInputName = stockAdjustWork.StockInputName;
            dcStockAdjustWork.StockAgentCode = stockAdjustWork.StockAgentCode;
            dcStockAdjustWork.StockAgentName = stockAdjustWork.StockAgentName;
            dcStockAdjustWork.StockSubttlPrice = stockAdjustWork.StockSubttlPrice;
            dcStockAdjustWork.SlipNote = stockAdjustWork.SlipNote;

            return dcStockAdjustWork;
        }

        /// <summary>
        /// 在庫調整明細データPramData→UIData移項処理
        /// </summary>
        /// <param name="stockAdjustDtlWork">在庫調整明細データ</param>
        /// <returns>DC在庫調整明細データ</returns>
        public static DCStockAdjustDtlWork SearchDataFromUpdateData(APStockAdjustDtlWork stockAdjustDtlWork)
        {
            if (stockAdjustDtlWork == null)
            {
                return null;
            }

            DCStockAdjustDtlWork dcStockAdjustDtlWork = new DCStockAdjustDtlWork();

            // 在庫調整明細データ変換
            dcStockAdjustDtlWork.CreateDateTime = stockAdjustDtlWork.CreateDateTime;
            dcStockAdjustDtlWork.UpdateDateTime = stockAdjustDtlWork.UpdateDateTime;
            dcStockAdjustDtlWork.EnterpriseCode = stockAdjustDtlWork.EnterpriseCode;
            dcStockAdjustDtlWork.FileHeaderGuid = stockAdjustDtlWork.FileHeaderGuid;
            dcStockAdjustDtlWork.UpdEmployeeCode = stockAdjustDtlWork.UpdEmployeeCode;
            dcStockAdjustDtlWork.UpdAssemblyId1 = stockAdjustDtlWork.UpdAssemblyId1;
            dcStockAdjustDtlWork.UpdAssemblyId2 = stockAdjustDtlWork.UpdAssemblyId2;
            dcStockAdjustDtlWork.LogicalDeleteCode = stockAdjustDtlWork.LogicalDeleteCode;
            dcStockAdjustDtlWork.SectionCode = stockAdjustDtlWork.SectionCode;
            dcStockAdjustDtlWork.StockAdjustSlipNo = stockAdjustDtlWork.StockAdjustSlipNo;
            dcStockAdjustDtlWork.StockAdjustRowNo = stockAdjustDtlWork.StockAdjustRowNo;
            dcStockAdjustDtlWork.SupplierFormalSrc = stockAdjustDtlWork.SupplierFormalSrc;
            dcStockAdjustDtlWork.StockSlipDtlNumSrc = stockAdjustDtlWork.StockSlipDtlNumSrc;
            dcStockAdjustDtlWork.AcPaySlipCd = stockAdjustDtlWork.AcPaySlipCd;
            dcStockAdjustDtlWork.AcPayTransCd = stockAdjustDtlWork.AcPayTransCd;
            dcStockAdjustDtlWork.AdjustDate = stockAdjustDtlWork.AdjustDate;
            dcStockAdjustDtlWork.InputDay = stockAdjustDtlWork.InputDay;
            dcStockAdjustDtlWork.GoodsMakerCd = stockAdjustDtlWork.GoodsMakerCd;
            dcStockAdjustDtlWork.MakerName = stockAdjustDtlWork.MakerName;
            dcStockAdjustDtlWork.GoodsNo = stockAdjustDtlWork.GoodsNo;
            dcStockAdjustDtlWork.GoodsName = stockAdjustDtlWork.GoodsName;
            dcStockAdjustDtlWork.StockUnitPriceFl = stockAdjustDtlWork.StockUnitPriceFl;
            dcStockAdjustDtlWork.BfStockUnitPriceFl = stockAdjustDtlWork.BfStockUnitPriceFl;
            dcStockAdjustDtlWork.AdjustCount = stockAdjustDtlWork.AdjustCount;
            dcStockAdjustDtlWork.DtlNote = stockAdjustDtlWork.DtlNote;
            dcStockAdjustDtlWork.WarehouseCode = stockAdjustDtlWork.WarehouseCode;
            dcStockAdjustDtlWork.WarehouseName = stockAdjustDtlWork.WarehouseName;
            dcStockAdjustDtlWork.BLGoodsCode = stockAdjustDtlWork.BLGoodsCode;
            dcStockAdjustDtlWork.BLGoodsFullName = stockAdjustDtlWork.BLGoodsFullName;
            dcStockAdjustDtlWork.WarehouseShelfNo = stockAdjustDtlWork.WarehouseShelfNo;
            dcStockAdjustDtlWork.ListPriceFl = stockAdjustDtlWork.ListPriceFl;
            dcStockAdjustDtlWork.OpenPriceDiv = stockAdjustDtlWork.OpenPriceDiv;
            dcStockAdjustDtlWork.StockPriceTaxExc = stockAdjustDtlWork.StockPriceTaxExc;


            return dcStockAdjustDtlWork;
        }

        /// <summary>
        /// 在庫移動データPramData→UIData移項処理
        /// </summary>
        /// <param name="stockMoveWork">在庫移動データ</param>
        /// <returns>DC在庫移動データ</returns>
        public static DCStockMoveWork SearchDataFromUpdateData(APStockMoveWork stockMoveWork)
        {
            if (stockMoveWork == null)
            {
                return null;
            }

            DCStockMoveWork dcStockMoveWork = new DCStockMoveWork();

            // 在庫移動データ変換
            dcStockMoveWork.CreateDateTime = stockMoveWork.CreateDateTime;
            dcStockMoveWork.UpdateDateTime = stockMoveWork.UpdateDateTime;
            dcStockMoveWork.EnterpriseCode = stockMoveWork.EnterpriseCode;
            dcStockMoveWork.FileHeaderGuid = stockMoveWork.FileHeaderGuid;
            dcStockMoveWork.UpdEmployeeCode = stockMoveWork.UpdEmployeeCode;
            dcStockMoveWork.UpdAssemblyId1 = stockMoveWork.UpdAssemblyId1;
            dcStockMoveWork.UpdAssemblyId2 = stockMoveWork.UpdAssemblyId2;
            dcStockMoveWork.LogicalDeleteCode = stockMoveWork.LogicalDeleteCode;
            dcStockMoveWork.StockMoveFormal = stockMoveWork.StockMoveFormal;
            dcStockMoveWork.StockMoveSlipNo = stockMoveWork.StockMoveSlipNo;
            dcStockMoveWork.StockMoveRowNo = stockMoveWork.StockMoveRowNo;
            dcStockMoveWork.UpdateSecCd = stockMoveWork.UpdateSecCd;
            dcStockMoveWork.BfSectionCode = stockMoveWork.BfSectionCode;
            dcStockMoveWork.BfSectionGuideSnm = stockMoveWork.BfSectionGuideSnm;
            dcStockMoveWork.BfEnterWarehCode = stockMoveWork.BfEnterWarehCode;
            dcStockMoveWork.BfEnterWarehName = stockMoveWork.BfEnterWarehName;
            dcStockMoveWork.AfSectionCode = stockMoveWork.AfSectionCode;
            dcStockMoveWork.AfSectionGuideSnm = stockMoveWork.AfSectionGuideSnm;
            dcStockMoveWork.AfEnterWarehCode = stockMoveWork.AfEnterWarehCode;
            dcStockMoveWork.AfEnterWarehName = stockMoveWork.AfEnterWarehName;
            dcStockMoveWork.ShipmentScdlDay = stockMoveWork.ShipmentScdlDay;
            dcStockMoveWork.ShipmentFixDay = stockMoveWork.ShipmentFixDay;
            dcStockMoveWork.ArrivalGoodsDay = stockMoveWork.ArrivalGoodsDay;
            dcStockMoveWork.InputDay = stockMoveWork.InputDay;
            dcStockMoveWork.MoveStatus = stockMoveWork.MoveStatus;
            dcStockMoveWork.StockMvEmpCode = stockMoveWork.StockMvEmpCode;
            dcStockMoveWork.StockMvEmpName = stockMoveWork.StockMvEmpName;
            dcStockMoveWork.ShipAgentCd = stockMoveWork.ShipAgentCd;
            dcStockMoveWork.ShipAgentNm = stockMoveWork.ShipAgentNm;
            dcStockMoveWork.ReceiveAgentCd = stockMoveWork.ReceiveAgentCd;
            dcStockMoveWork.ReceiveAgentNm = stockMoveWork.ReceiveAgentNm;
            dcStockMoveWork.SupplierCd = stockMoveWork.SupplierCd;
            dcStockMoveWork.SupplierSnm = stockMoveWork.SupplierSnm;
            dcStockMoveWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;
            dcStockMoveWork.MakerName = stockMoveWork.MakerName;
            dcStockMoveWork.GoodsNo = stockMoveWork.GoodsNo;
            dcStockMoveWork.GoodsName = stockMoveWork.GoodsName;
            dcStockMoveWork.GoodsNameKana = stockMoveWork.GoodsNameKana;
            dcStockMoveWork.StockDiv = stockMoveWork.StockDiv;
            dcStockMoveWork.StockUnitPriceFl = stockMoveWork.StockUnitPriceFl;
            dcStockMoveWork.TaxationDivCd = stockMoveWork.TaxationDivCd;
            dcStockMoveWork.MoveCount = stockMoveWork.MoveCount;
            dcStockMoveWork.BfShelfNo = stockMoveWork.BfShelfNo;
            dcStockMoveWork.AfShelfNo = stockMoveWork.AfShelfNo;
            dcStockMoveWork.BLGoodsCode = stockMoveWork.BLGoodsCode;
            dcStockMoveWork.BLGoodsFullName = stockMoveWork.BLGoodsFullName;
            dcStockMoveWork.ListPriceFl = stockMoveWork.ListPriceFl;
            dcStockMoveWork.Outline = stockMoveWork.Outline;
            dcStockMoveWork.WarehouseNote1 = stockMoveWork.WarehouseNote1;
            dcStockMoveWork.SlipPrintFinishCd = stockMoveWork.SlipPrintFinishCd;
            dcStockMoveWork.StockMovePrice = stockMoveWork.StockMovePrice;

            return dcStockMoveWork;
        }

        /// <summary>
        /// 在庫受払履歴データPramData→UIData移項処理
        /// </summary>
        /// <param name="stockAcPayHistWork">在庫受払履歴データ</param>
        /// <returns>DC在庫受払履歴データ</returns>
        public static DCStockAcPayHistWork SearchDataFromUpdateData(APStockAcPayHistWork stockAcPayHistWork)
        {
            if (stockAcPayHistWork == null)
            {
                return null;
            }

            DCStockAcPayHistWork dcStockAcPayHistWork = new DCStockAcPayHistWork();

            // 在庫受払履歴データ変換
            dcStockAcPayHistWork.CreateDateTime = stockAcPayHistWork.CreateDateTime;
            dcStockAcPayHistWork.UpdateDateTime = stockAcPayHistWork.UpdateDateTime;
            dcStockAcPayHistWork.EnterpriseCode = stockAcPayHistWork.EnterpriseCode;
            dcStockAcPayHistWork.FileHeaderGuid = stockAcPayHistWork.FileHeaderGuid;
            dcStockAcPayHistWork.UpdEmployeeCode = stockAcPayHistWork.UpdEmployeeCode;
            dcStockAcPayHistWork.UpdAssemblyId1 = stockAcPayHistWork.UpdAssemblyId1;
            dcStockAcPayHistWork.UpdAssemblyId2 = stockAcPayHistWork.UpdAssemblyId2;
            dcStockAcPayHistWork.LogicalDeleteCode = stockAcPayHistWork.LogicalDeleteCode;
            dcStockAcPayHistWork.IoGoodsDay = stockAcPayHistWork.IoGoodsDay;
            dcStockAcPayHistWork.AddUpADate = stockAcPayHistWork.AddUpADate;
            dcStockAcPayHistWork.AcPaySlipCd = stockAcPayHistWork.AcPaySlipCd;
            dcStockAcPayHistWork.AcPaySlipNum = stockAcPayHistWork.AcPaySlipNum;
            dcStockAcPayHistWork.AcPaySlipRowNo = stockAcPayHistWork.AcPaySlipRowNo;
            dcStockAcPayHistWork.AcPayHistDateTime = stockAcPayHistWork.AcPayHistDateTime;
            dcStockAcPayHistWork.AcPayTransCd = stockAcPayHistWork.AcPayTransCd;
            dcStockAcPayHistWork.InputSectionCd = stockAcPayHistWork.InputSectionCd;
            dcStockAcPayHistWork.InputSectionGuidNm = stockAcPayHistWork.InputSectionGuidNm;
            dcStockAcPayHistWork.InputAgenCd = stockAcPayHistWork.InputAgenCd;
            dcStockAcPayHistWork.InputAgenNm = stockAcPayHistWork.InputAgenNm;
            dcStockAcPayHistWork.MoveStatus = stockAcPayHistWork.MoveStatus;
            dcStockAcPayHistWork.CustSlipNo = stockAcPayHistWork.CustSlipNo;
            dcStockAcPayHistWork.SlipDtlNum = stockAcPayHistWork.SlipDtlNum;
            dcStockAcPayHistWork.AcPayNote = stockAcPayHistWork.AcPayNote;
            dcStockAcPayHistWork.GoodsMakerCd = stockAcPayHistWork.GoodsMakerCd;
            dcStockAcPayHistWork.MakerName = stockAcPayHistWork.MakerName;
            dcStockAcPayHistWork.GoodsNo = stockAcPayHistWork.GoodsNo;
            dcStockAcPayHistWork.GoodsName = stockAcPayHistWork.GoodsName;
            dcStockAcPayHistWork.BLGoodsCode = stockAcPayHistWork.BLGoodsCode;
            dcStockAcPayHistWork.BLGoodsFullName = stockAcPayHistWork.BLGoodsFullName;
            dcStockAcPayHistWork.SectionCode = stockAcPayHistWork.SectionCode;
            dcStockAcPayHistWork.SectionGuideNm = stockAcPayHistWork.SectionGuideNm;
            dcStockAcPayHistWork.WarehouseCode = stockAcPayHistWork.WarehouseCode;
            dcStockAcPayHistWork.WarehouseName = stockAcPayHistWork.WarehouseName;
            dcStockAcPayHistWork.ShelfNo = stockAcPayHistWork.ShelfNo;
            dcStockAcPayHistWork.BfSectionCode = stockAcPayHistWork.BfSectionCode;
            dcStockAcPayHistWork.BfSectionGuideNm = stockAcPayHistWork.BfSectionGuideNm;
            dcStockAcPayHistWork.BfEnterWarehCode = stockAcPayHistWork.BfEnterWarehCode;
            dcStockAcPayHistWork.BfEnterWarehName = stockAcPayHistWork.BfEnterWarehName;
            dcStockAcPayHistWork.BfShelfNo = stockAcPayHistWork.BfShelfNo;
            dcStockAcPayHistWork.AfSectionCode = stockAcPayHistWork.AfSectionCode;
            dcStockAcPayHistWork.AfSectionGuideNm = stockAcPayHistWork.AfSectionGuideNm;
            dcStockAcPayHistWork.AfEnterWarehCode = stockAcPayHistWork.AfEnterWarehCode;
            dcStockAcPayHistWork.AfEnterWarehName = stockAcPayHistWork.AfEnterWarehName;
            dcStockAcPayHistWork.AfShelfNo = stockAcPayHistWork.AfShelfNo;
            dcStockAcPayHistWork.CustomerCode = stockAcPayHistWork.CustomerCode;
            dcStockAcPayHistWork.CustomerSnm = stockAcPayHistWork.CustomerSnm;
            dcStockAcPayHistWork.SupplierCd = stockAcPayHistWork.SupplierCd;
            dcStockAcPayHistWork.SupplierSnm = stockAcPayHistWork.SupplierSnm;
            dcStockAcPayHistWork.ArrivalCnt = stockAcPayHistWork.ArrivalCnt;
            dcStockAcPayHistWork.ShipmentCnt = stockAcPayHistWork.ShipmentCnt;
            dcStockAcPayHistWork.OpenPriceDiv = stockAcPayHistWork.OpenPriceDiv;
            dcStockAcPayHistWork.ListPriceTaxExcFl = stockAcPayHistWork.ListPriceTaxExcFl;
            dcStockAcPayHistWork.StockUnitPriceFl = stockAcPayHistWork.StockUnitPriceFl;
            dcStockAcPayHistWork.StockPrice = stockAcPayHistWork.StockPrice;
            dcStockAcPayHistWork.SalesUnPrcTaxExcFl = stockAcPayHistWork.SalesUnPrcTaxExcFl;
            dcStockAcPayHistWork.SalesMoney = stockAcPayHistWork.SalesMoney;
            dcStockAcPayHistWork.SupplierStock = stockAcPayHistWork.SupplierStock;
            dcStockAcPayHistWork.AcpOdrCount = stockAcPayHistWork.AcpOdrCount;
            dcStockAcPayHistWork.SalesOrderCount = stockAcPayHistWork.SalesOrderCount;
            dcStockAcPayHistWork.MovingSupliStock = stockAcPayHistWork.MovingSupliStock;
            dcStockAcPayHistWork.NonAddUpShipmCnt = stockAcPayHistWork.NonAddUpShipmCnt;
            dcStockAcPayHistWork.NonAddUpArrGdsCnt = stockAcPayHistWork.NonAddUpArrGdsCnt;
            dcStockAcPayHistWork.ShipmentPosCnt = stockAcPayHistWork.ShipmentPosCnt;
            dcStockAcPayHistWork.PresentStockCnt = stockAcPayHistWork.PresentStockCnt;

            return dcStockAcPayHistWork;
        }

		//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
		/// <summary>
		/// 入金引当マスタPramData→UIData移項処理
		/// </summary>
		/// <param name="depositAlwWork">入金引当マスタ</param>
		/// <returns>DC入金引当マスタ</returns>
		public static DCDepositAlwWork SearchDataFromUpdateData(APDepositAlwWork depositAlwWork)
		{
			if (depositAlwWork == null)
			{
				return null;
			}

			DCDepositAlwWork dCDepositAlwWork = new DCDepositAlwWork();

			// 入金引当マスタ変換
			dCDepositAlwWork.CreateDateTime = depositAlwWork.CreateDateTime;
			dCDepositAlwWork.UpdateDateTime = depositAlwWork.UpdateDateTime;
			dCDepositAlwWork.EnterpriseCode = depositAlwWork.EnterpriseCode;
			dCDepositAlwWork.FileHeaderGuid = depositAlwWork.FileHeaderGuid;
			dCDepositAlwWork.UpdEmployeeCode = depositAlwWork.UpdEmployeeCode;
			dCDepositAlwWork.UpdAssemblyId1 = depositAlwWork.UpdAssemblyId1;
			dCDepositAlwWork.UpdAssemblyId2 = depositAlwWork.UpdAssemblyId2;
			dCDepositAlwWork.LogicalDeleteCode = depositAlwWork.LogicalDeleteCode;
			dCDepositAlwWork.InputDepositSecCd = depositAlwWork.InputDepositSecCd;
			dCDepositAlwWork.AddUpSecCode = depositAlwWork.AddUpSecCode;
			dCDepositAlwWork.AcptAnOdrStatus = depositAlwWork.AcptAnOdrStatus;
			dCDepositAlwWork.SalesSlipNum = depositAlwWork.SalesSlipNum;
			dCDepositAlwWork.ReconcileDate = depositAlwWork.ReconcileDate;
			dCDepositAlwWork.ReconcileAddUpDate = depositAlwWork.ReconcileAddUpDate;
			dCDepositAlwWork.DepositSlipNo = depositAlwWork.DepositSlipNo;
			dCDepositAlwWork.DepositAllowance = depositAlwWork.DepositAllowance;
			dCDepositAlwWork.DepositAgentCode = depositAlwWork.DepositAgentCode;
			dCDepositAlwWork.DepositAgentNm = depositAlwWork.DepositAgentNm;
			dCDepositAlwWork.CustomerCode = depositAlwWork.CustomerCode;
			dCDepositAlwWork.CustomerName = depositAlwWork.CustomerName;
			dCDepositAlwWork.CustomerName2 = depositAlwWork.CustomerName2;
			dCDepositAlwWork.DebitNoteOffSetCd = depositAlwWork.DebitNoteOffSetCd;

			return dCDepositAlwWork;
		}

		/// <summary>
		/// 受取手形データPramData→UIData移項処理
		/// </summary>
		/// <param name="rcvDraftDataWork">受取手形データ</param>
		/// <returns>DC受取手形データ</returns>
		public static DCRcvDraftDataWork SearchDataFromUpdateData(APRcvDraftDataWork rcvDraftDataWork)
		{
			if (rcvDraftDataWork == null)
			{
				return null;
			}

			DCRcvDraftDataWork dCRcvDraftDataWork = new DCRcvDraftDataWork();

			// 受取手形データ変換
			dCRcvDraftDataWork.CreateDateTime = rcvDraftDataWork.CreateDateTime;
			dCRcvDraftDataWork.UpdateDateTime = rcvDraftDataWork.UpdateDateTime;
			dCRcvDraftDataWork.EnterpriseCode = rcvDraftDataWork.EnterpriseCode;
			dCRcvDraftDataWork.FileHeaderGuid = rcvDraftDataWork.FileHeaderGuid;
			dCRcvDraftDataWork.UpdEmployeeCode = rcvDraftDataWork.UpdEmployeeCode;
			dCRcvDraftDataWork.UpdAssemblyId1 = rcvDraftDataWork.UpdAssemblyId1;
			dCRcvDraftDataWork.UpdAssemblyId2 = rcvDraftDataWork.UpdAssemblyId2;
			dCRcvDraftDataWork.LogicalDeleteCode = rcvDraftDataWork.LogicalDeleteCode;
			dCRcvDraftDataWork.RcvDraftNo = rcvDraftDataWork.RcvDraftNo;
			dCRcvDraftDataWork.DraftKindCd = rcvDraftDataWork.DraftKindCd;
			dCRcvDraftDataWork.DraftDivide = rcvDraftDataWork.DraftDivide;
			dCRcvDraftDataWork.Deposit = rcvDraftDataWork.Deposit;
			dCRcvDraftDataWork.BankAndBranchCd = rcvDraftDataWork.BankAndBranchCd;
			dCRcvDraftDataWork.BankAndBranchNm = rcvDraftDataWork.BankAndBranchNm;
			dCRcvDraftDataWork.SectionCode = rcvDraftDataWork.SectionCode;
			dCRcvDraftDataWork.AddUpSecCode = rcvDraftDataWork.AddUpSecCode;
			dCRcvDraftDataWork.CustomerCode = rcvDraftDataWork.CustomerCode;
			dCRcvDraftDataWork.CustomerName = rcvDraftDataWork.CustomerName;
			dCRcvDraftDataWork.CustomerName2 = rcvDraftDataWork.CustomerName2;
			dCRcvDraftDataWork.CustomerSnm = rcvDraftDataWork.CustomerSnm;
			dCRcvDraftDataWork.ProcDate = rcvDraftDataWork.ProcDate;
			dCRcvDraftDataWork.DraftDrawingDate = rcvDraftDataWork.DraftDrawingDate;
			dCRcvDraftDataWork.ValidityTerm = rcvDraftDataWork.ValidityTerm;
			dCRcvDraftDataWork.DraftStmntDate = rcvDraftDataWork.DraftStmntDate;
			dCRcvDraftDataWork.Outline1 = rcvDraftDataWork.Outline1;
			dCRcvDraftDataWork.Outline2 = rcvDraftDataWork.Outline2;
			dCRcvDraftDataWork.AcptAnOdrStatus = rcvDraftDataWork.AcptAnOdrStatus;
			dCRcvDraftDataWork.DepositSlipNo = rcvDraftDataWork.DepositSlipNo;
			dCRcvDraftDataWork.DepositRowNo = rcvDraftDataWork.DepositRowNo;
			dCRcvDraftDataWork.DepositDate = rcvDraftDataWork.DepositDate;


			return dCRcvDraftDataWork;
		}

		/// <summary>
		/// 支払手形データPramData→UIData移項処理
		/// </summary>
		/// <param name="payDraftDataWork">支払手形データ</param>
		/// <returns>DC支払手形データ</returns>
		public static DCPayDraftDataWork SearchDataFromUpdateData(APPayDraftDataWork payDraftDataWork)
		{
			if (payDraftDataWork == null)
			{
				return null;
			}

			DCPayDraftDataWork dCPayDraftDataWork = new DCPayDraftDataWork();

			// 支払手形データ変換
			dCPayDraftDataWork.CreateDateTime = payDraftDataWork.CreateDateTime;
			dCPayDraftDataWork.UpdateDateTime = payDraftDataWork.UpdateDateTime;
			dCPayDraftDataWork.EnterpriseCode = payDraftDataWork.EnterpriseCode;
			dCPayDraftDataWork.FileHeaderGuid = payDraftDataWork.FileHeaderGuid;
			dCPayDraftDataWork.UpdEmployeeCode = payDraftDataWork.UpdEmployeeCode;
			dCPayDraftDataWork.UpdAssemblyId1 = payDraftDataWork.UpdAssemblyId1;
			dCPayDraftDataWork.UpdAssemblyId2 = payDraftDataWork.UpdAssemblyId2;
			dCPayDraftDataWork.LogicalDeleteCode = payDraftDataWork.LogicalDeleteCode;
			dCPayDraftDataWork.PayDraftNo = payDraftDataWork.PayDraftNo;
			dCPayDraftDataWork.DraftKindCd = payDraftDataWork.DraftKindCd;
			dCPayDraftDataWork.DraftDivide = payDraftDataWork.DraftDivide;
			dCPayDraftDataWork.Payment = payDraftDataWork.Payment;
			dCPayDraftDataWork.BankAndBranchCd = payDraftDataWork.BankAndBranchCd;
			dCPayDraftDataWork.BankAndBranchNm = payDraftDataWork.BankAndBranchNm;
			dCPayDraftDataWork.SectionCode = payDraftDataWork.SectionCode;
			dCPayDraftDataWork.AddUpSecCode = payDraftDataWork.AddUpSecCode;
			dCPayDraftDataWork.SupplierCd = payDraftDataWork.SupplierCd;
			dCPayDraftDataWork.SupplierNm1 = payDraftDataWork.SupplierNm1;
			dCPayDraftDataWork.SupplierNm2 = payDraftDataWork.SupplierNm2;
			dCPayDraftDataWork.SupplierSnm = payDraftDataWork.SupplierSnm;
			dCPayDraftDataWork.ProcDate = payDraftDataWork.ProcDate;
			dCPayDraftDataWork.DraftDrawingDate = payDraftDataWork.DraftDrawingDate;
			dCPayDraftDataWork.ValidityTerm = payDraftDataWork.ValidityTerm;
			dCPayDraftDataWork.DraftStmntDate = payDraftDataWork.DraftStmntDate;
			dCPayDraftDataWork.Outline1 = payDraftDataWork.Outline1;
			dCPayDraftDataWork.Outline2 = payDraftDataWork.Outline2;
			dCPayDraftDataWork.SupplierFormal = payDraftDataWork.SupplierFormal;
			dCPayDraftDataWork.PaymentSlipNo = payDraftDataWork.PaymentSlipNo;
			dCPayDraftDataWork.PaymentRowNo = payDraftDataWork.PaymentRowNo;
			dCPayDraftDataWork.PaymentDate = payDraftDataWork.PaymentDate;

			return dCPayDraftDataWork;
		}
		//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
    }
}
