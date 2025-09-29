//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄偉兵
// 修 正 日  2009/09/08   修正内容 : 受注マスタ（車両）に車輌備考の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/09/15  修正内容 : #24923　ファイルレイアウト変更による項目追加対応
//----------------------------------------------------------------------------//
// 管理番号  10900269-00 作成担当 : FSI厚川 宏
// 修 正 日  2013/03/22  修正内容 : SPK車台番号文字列対応に伴う国産/外車区分の追加
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 譚洪
// 修 正 日  2020/09/25  修正内容 : PMKOBETSU-3877の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 送信処理
    /// </summary>
    /// <remarks>
    /// <br>Update Note  : 2009/09/08 黄偉兵</br>
    /// <br>             :     PM.NS-2-A.車輌管理</br>
    /// <br>             :     受注マスタ（車両）に車輌備考の追加</br>
    /// <br>Update Note  : SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
    /// <br>Programmer   : FSI厚川 宏</br>
    /// <br>Date         : 2013/03/22</br>
    /// <br>Update Note  : PMKOBETSU-3877の対応</br>
    /// <br>Programmer   : 譚洪</br>
    /// <br>Date         : 2020/09/25</br>
    /// </remarks>
    public class ConvertReceive
    {
        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcSalesSlipWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APSalesSlipWork SearchDataFromUpdateData(DCSalesSlipWork dcSalesSlipWork)
        {
            if (dcSalesSlipWork == null)
            {
                return null;
            }

            APSalesSlipWork salesSlipWork = new APSalesSlipWork();
            // データ変換
            salesSlipWork.CreateDateTime = dcSalesSlipWork.CreateDateTime;
            salesSlipWork.UpdateDateTime = dcSalesSlipWork.UpdateDateTime;
            salesSlipWork.EnterpriseCode = dcSalesSlipWork.EnterpriseCode;
            salesSlipWork.FileHeaderGuid = dcSalesSlipWork.FileHeaderGuid;
            salesSlipWork.UpdEmployeeCode = dcSalesSlipWork.UpdEmployeeCode;
            salesSlipWork.UpdAssemblyId1 = dcSalesSlipWork.UpdAssemblyId1;
            salesSlipWork.UpdAssemblyId2 = dcSalesSlipWork.UpdAssemblyId2;
            salesSlipWork.LogicalDeleteCode = dcSalesSlipWork.LogicalDeleteCode;
            salesSlipWork.AcptAnOdrStatus = dcSalesSlipWork.AcptAnOdrStatus;
            salesSlipWork.SalesSlipNum = dcSalesSlipWork.SalesSlipNum;
            salesSlipWork.SectionCode = dcSalesSlipWork.SectionCode;
            salesSlipWork.SubSectionCode = dcSalesSlipWork.SubSectionCode;
            salesSlipWork.DebitNoteDiv = dcSalesSlipWork.DebitNoteDiv;
            salesSlipWork.DebitNLnkSalesSlNum = dcSalesSlipWork.DebitNLnkSalesSlNum;
            salesSlipWork.SalesSlipCd = dcSalesSlipWork.SalesSlipCd;
            salesSlipWork.SalesGoodsCd = dcSalesSlipWork.SalesGoodsCd;
            salesSlipWork.AccRecDivCd = dcSalesSlipWork.AccRecDivCd;
            salesSlipWork.SalesInpSecCd = dcSalesSlipWork.SalesInpSecCd;
            salesSlipWork.DemandAddUpSecCd = dcSalesSlipWork.DemandAddUpSecCd;
            salesSlipWork.ResultsAddUpSecCd = dcSalesSlipWork.ResultsAddUpSecCd;
            salesSlipWork.UpdateSecCd = dcSalesSlipWork.UpdateSecCd;
            salesSlipWork.SalesSlipUpdateCd = dcSalesSlipWork.SalesSlipUpdateCd;
            salesSlipWork.SearchSlipDate = dcSalesSlipWork.SearchSlipDate;
            salesSlipWork.ShipmentDay = dcSalesSlipWork.ShipmentDay;
            salesSlipWork.SalesDate = dcSalesSlipWork.SalesDate;
            salesSlipWork.AddUpADate = dcSalesSlipWork.AddUpADate;
            salesSlipWork.DelayPaymentDiv = dcSalesSlipWork.DelayPaymentDiv;
            salesSlipWork.EstimateFormNo = dcSalesSlipWork.EstimateFormNo;
            salesSlipWork.EstimateDivide = dcSalesSlipWork.EstimateDivide;
            salesSlipWork.InputAgenCd = dcSalesSlipWork.InputAgenCd;
            salesSlipWork.InputAgenNm = dcSalesSlipWork.InputAgenNm;
            salesSlipWork.SalesInputCode = dcSalesSlipWork.SalesInputCode;
            salesSlipWork.SalesInputName = dcSalesSlipWork.SalesInputName;
            salesSlipWork.FrontEmployeeCd = dcSalesSlipWork.FrontEmployeeCd;
            salesSlipWork.FrontEmployeeNm = dcSalesSlipWork.FrontEmployeeNm;
            salesSlipWork.SalesEmployeeCd = dcSalesSlipWork.SalesEmployeeCd;
            salesSlipWork.SalesEmployeeNm = dcSalesSlipWork.SalesEmployeeNm;
            salesSlipWork.TotalAmountDispWayCd = dcSalesSlipWork.TotalAmountDispWayCd;
            salesSlipWork.TtlAmntDispRateApy = dcSalesSlipWork.TtlAmntDispRateApy;
            salesSlipWork.SalesTotalTaxInc = dcSalesSlipWork.SalesTotalTaxInc;
            salesSlipWork.SalesTotalTaxExc = dcSalesSlipWork.SalesTotalTaxExc;
            salesSlipWork.SalesPrtTotalTaxInc = dcSalesSlipWork.SalesPrtTotalTaxInc;
            salesSlipWork.SalesPrtTotalTaxExc = dcSalesSlipWork.SalesPrtTotalTaxExc;
            salesSlipWork.SalesWorkTotalTaxInc = dcSalesSlipWork.SalesWorkTotalTaxInc;
            salesSlipWork.SalesWorkTotalTaxExc = dcSalesSlipWork.SalesWorkTotalTaxExc;
            salesSlipWork.SalesSubtotalTaxInc = dcSalesSlipWork.SalesSubtotalTaxInc;
            salesSlipWork.SalesSubtotalTaxExc = dcSalesSlipWork.SalesSubtotalTaxExc;
            salesSlipWork.SalesPrtSubttlInc = dcSalesSlipWork.SalesPrtSubttlInc;
            salesSlipWork.SalesPrtSubttlExc = dcSalesSlipWork.SalesPrtSubttlExc;
            salesSlipWork.SalesWorkSubttlInc = dcSalesSlipWork.SalesWorkSubttlInc;
            salesSlipWork.SalesWorkSubttlExc = dcSalesSlipWork.SalesWorkSubttlExc;
            salesSlipWork.SalesNetPrice = dcSalesSlipWork.SalesNetPrice;
            salesSlipWork.SalesSubtotalTax = dcSalesSlipWork.SalesSubtotalTax;
            salesSlipWork.ItdedSalesOutTax = dcSalesSlipWork.ItdedSalesOutTax;
            salesSlipWork.ItdedSalesInTax = dcSalesSlipWork.ItdedSalesInTax;
            salesSlipWork.SalSubttlSubToTaxFre = dcSalesSlipWork.SalSubttlSubToTaxFre;
            salesSlipWork.SalesOutTax = dcSalesSlipWork.SalesOutTax;
            salesSlipWork.SalAmntConsTaxInclu = dcSalesSlipWork.SalAmntConsTaxInclu;
            salesSlipWork.SalesDisTtlTaxExc = dcSalesSlipWork.SalesDisTtlTaxExc;
            salesSlipWork.ItdedSalesDisOutTax = dcSalesSlipWork.ItdedSalesDisOutTax;
            salesSlipWork.ItdedSalesDisInTax = dcSalesSlipWork.ItdedSalesDisInTax;
            salesSlipWork.ItdedPartsDisOutTax = dcSalesSlipWork.ItdedPartsDisOutTax;
            salesSlipWork.ItdedPartsDisInTax = dcSalesSlipWork.ItdedPartsDisInTax;
            salesSlipWork.ItdedWorkDisOutTax = dcSalesSlipWork.ItdedWorkDisOutTax;
            salesSlipWork.ItdedWorkDisInTax = dcSalesSlipWork.ItdedWorkDisInTax;
            salesSlipWork.ItdedSalesDisTaxFre = dcSalesSlipWork.ItdedSalesDisTaxFre;
            salesSlipWork.SalesDisOutTax = dcSalesSlipWork.SalesDisOutTax;
            salesSlipWork.SalesDisTtlTaxInclu = dcSalesSlipWork.SalesDisTtlTaxInclu;
            salesSlipWork.PartsDiscountRate = dcSalesSlipWork.PartsDiscountRate;
            salesSlipWork.RavorDiscountRate = dcSalesSlipWork.RavorDiscountRate;
            salesSlipWork.TotalCost = dcSalesSlipWork.TotalCost;
            salesSlipWork.ConsTaxLayMethod = dcSalesSlipWork.ConsTaxLayMethod;
            salesSlipWork.ConsTaxRate = dcSalesSlipWork.ConsTaxRate;
            salesSlipWork.FractionProcCd = dcSalesSlipWork.FractionProcCd;
            salesSlipWork.AccRecConsTax = dcSalesSlipWork.AccRecConsTax;
            salesSlipWork.AutoDepositCd = dcSalesSlipWork.AutoDepositCd;
            salesSlipWork.AutoDepositSlipNo = dcSalesSlipWork.AutoDepositSlipNo;
            salesSlipWork.DepositAllowanceTtl = dcSalesSlipWork.DepositAllowanceTtl;
            salesSlipWork.DepositAlwcBlnce = dcSalesSlipWork.DepositAlwcBlnce;
            salesSlipWork.ClaimCode = dcSalesSlipWork.ClaimCode;
            salesSlipWork.ClaimSnm = dcSalesSlipWork.ClaimSnm;
            salesSlipWork.CustomerCode = dcSalesSlipWork.CustomerCode;
            salesSlipWork.CustomerName = dcSalesSlipWork.CustomerName;
            salesSlipWork.CustomerName2 = dcSalesSlipWork.CustomerName2;
            salesSlipWork.CustomerSnm = dcSalesSlipWork.CustomerSnm;
            salesSlipWork.HonorificTitle = dcSalesSlipWork.HonorificTitle;
            salesSlipWork.OutputNameCode = dcSalesSlipWork.OutputNameCode;
            salesSlipWork.OutputName = dcSalesSlipWork.OutputName;
            salesSlipWork.CustSlipNo = dcSalesSlipWork.CustSlipNo;
            salesSlipWork.SlipAddressDiv = dcSalesSlipWork.SlipAddressDiv;
            salesSlipWork.AddresseeCode = dcSalesSlipWork.AddresseeCode;
            salesSlipWork.AddresseeName = dcSalesSlipWork.AddresseeName;
            salesSlipWork.AddresseeName2 = dcSalesSlipWork.AddresseeName2;
            salesSlipWork.AddresseePostNo = dcSalesSlipWork.AddresseePostNo;
            salesSlipWork.AddresseeAddr1 = dcSalesSlipWork.AddresseeAddr1;
            salesSlipWork.AddresseeAddr3 = dcSalesSlipWork.AddresseeAddr3;
            salesSlipWork.AddresseeAddr4 = dcSalesSlipWork.AddresseeAddr4;
            salesSlipWork.AddresseeTelNo = dcSalesSlipWork.AddresseeTelNo;
            salesSlipWork.AddresseeFaxNo = dcSalesSlipWork.AddresseeFaxNo;
            salesSlipWork.PartySaleSlipNum = dcSalesSlipWork.PartySaleSlipNum;
            salesSlipWork.SlipNote = dcSalesSlipWork.SlipNote;
            salesSlipWork.SlipNote2 = dcSalesSlipWork.SlipNote2;
            salesSlipWork.SlipNote3 = dcSalesSlipWork.SlipNote3;
            salesSlipWork.RetGoodsReasonDiv = dcSalesSlipWork.RetGoodsReasonDiv;
            salesSlipWork.RetGoodsReason = dcSalesSlipWork.RetGoodsReason;
            salesSlipWork.RegiProcDate = dcSalesSlipWork.RegiProcDate;
            salesSlipWork.CashRegisterNo = dcSalesSlipWork.CashRegisterNo;
            salesSlipWork.PosReceiptNo = dcSalesSlipWork.PosReceiptNo;
            salesSlipWork.DetailRowCount = dcSalesSlipWork.DetailRowCount;
            salesSlipWork.EdiSendDate = dcSalesSlipWork.EdiSendDate;
            salesSlipWork.EdiTakeInDate = dcSalesSlipWork.EdiTakeInDate;
            salesSlipWork.UoeRemark1 = dcSalesSlipWork.UoeRemark1;
            salesSlipWork.UoeRemark2 = dcSalesSlipWork.UoeRemark2;
            salesSlipWork.SlipPrintDivCd = dcSalesSlipWork.SlipPrintDivCd;
            salesSlipWork.SlipPrintFinishCd = dcSalesSlipWork.SlipPrintFinishCd;
            salesSlipWork.SalesSlipPrintDate = dcSalesSlipWork.SalesSlipPrintDate;
            salesSlipWork.BusinessTypeCode = dcSalesSlipWork.BusinessTypeCode;
            salesSlipWork.BusinessTypeName = dcSalesSlipWork.BusinessTypeName;
            salesSlipWork.OrderNumber = dcSalesSlipWork.OrderNumber;
            salesSlipWork.DeliveredGoodsDiv = dcSalesSlipWork.DeliveredGoodsDiv;
            salesSlipWork.DeliveredGoodsDivNm = dcSalesSlipWork.DeliveredGoodsDivNm;
            salesSlipWork.SalesAreaCode = dcSalesSlipWork.SalesAreaCode;
            salesSlipWork.SalesAreaName = dcSalesSlipWork.SalesAreaName;
            salesSlipWork.ReconcileFlag = dcSalesSlipWork.ReconcileFlag;
            salesSlipWork.SlipPrtSetPaperId = dcSalesSlipWork.SlipPrtSetPaperId;
            salesSlipWork.CompleteCd = dcSalesSlipWork.CompleteCd;
            salesSlipWork.SalesPriceFracProcCd = dcSalesSlipWork.SalesPriceFracProcCd;
            salesSlipWork.StockGoodsTtlTaxExc = dcSalesSlipWork.StockGoodsTtlTaxExc;
            salesSlipWork.PureGoodsTtlTaxExc = dcSalesSlipWork.PureGoodsTtlTaxExc;
            salesSlipWork.ListPricePrintDiv = dcSalesSlipWork.ListPricePrintDiv;
            salesSlipWork.EraNameDispCd1 = dcSalesSlipWork.EraNameDispCd1;
            salesSlipWork.EstimaTaxDivCd = dcSalesSlipWork.EstimaTaxDivCd;
            salesSlipWork.EstimateFormPrtCd = dcSalesSlipWork.EstimateFormPrtCd;
            salesSlipWork.EstimateSubject = dcSalesSlipWork.EstimateSubject;
            salesSlipWork.Footnotes1 = dcSalesSlipWork.Footnotes1;
            salesSlipWork.Footnotes2 = dcSalesSlipWork.Footnotes2;
            salesSlipWork.EstimateTitle1 = dcSalesSlipWork.EstimateTitle1;
            salesSlipWork.EstimateTitle2 = dcSalesSlipWork.EstimateTitle2;
            salesSlipWork.EstimateTitle3 = dcSalesSlipWork.EstimateTitle3;
            salesSlipWork.EstimateTitle4 = dcSalesSlipWork.EstimateTitle4;
            salesSlipWork.EstimateTitle5 = dcSalesSlipWork.EstimateTitle5;
            salesSlipWork.EstimateNote1 = dcSalesSlipWork.EstimateNote1;
            salesSlipWork.EstimateNote2 = dcSalesSlipWork.EstimateNote2;
            salesSlipWork.EstimateNote3 = dcSalesSlipWork.EstimateNote3;
            salesSlipWork.EstimateNote4 = dcSalesSlipWork.EstimateNote4;
            salesSlipWork.EstimateNote5 = dcSalesSlipWork.EstimateNote5;
            salesSlipWork.EstimateValidityDate = dcSalesSlipWork.EstimateValidityDate;
            salesSlipWork.PartsNoPrtCd = dcSalesSlipWork.PartsNoPrtCd;
            salesSlipWork.OptionPringDivCd = dcSalesSlipWork.OptionPringDivCd;
            salesSlipWork.RateUseCode = dcSalesSlipWork.RateUseCode;

            return salesSlipWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcSalesDetailWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        /// <br>Update Note: PMKOBETSU-3877の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/09/25</br>
        public static APSalesDetailWork SearchDataFromUpdateData(DCSalesDetailWork dcSalesDetailWork)
        {
            if (dcSalesDetailWork == null)
            {
                return null;
            }

            APSalesDetailWork salesDetailWork = new APSalesDetailWork();

            // 変換
            salesDetailWork.CreateDateTime = dcSalesDetailWork.CreateDateTime;
            salesDetailWork.UpdateDateTime = dcSalesDetailWork.UpdateDateTime;
            salesDetailWork.EnterpriseCode = dcSalesDetailWork.EnterpriseCode;
            salesDetailWork.FileHeaderGuid = dcSalesDetailWork.FileHeaderGuid;
            salesDetailWork.UpdEmployeeCode = dcSalesDetailWork.UpdEmployeeCode;
            salesDetailWork.UpdAssemblyId1 = dcSalesDetailWork.UpdAssemblyId1;
            salesDetailWork.UpdAssemblyId2 = dcSalesDetailWork.UpdAssemblyId2;
            salesDetailWork.LogicalDeleteCode = dcSalesDetailWork.LogicalDeleteCode;
            salesDetailWork.AcceptAnOrderNo = dcSalesDetailWork.AcceptAnOrderNo;
            salesDetailWork.AcptAnOdrStatus = dcSalesDetailWork.AcptAnOdrStatus;
            salesDetailWork.SalesSlipNum = dcSalesDetailWork.SalesSlipNum;
            salesDetailWork.SalesRowNo = dcSalesDetailWork.SalesRowNo;
            salesDetailWork.SalesRowDerivNo = dcSalesDetailWork.SalesRowDerivNo;
            salesDetailWork.SectionCode = dcSalesDetailWork.SectionCode;
            salesDetailWork.SubSectionCode = dcSalesDetailWork.SubSectionCode;
            salesDetailWork.SalesDate = dcSalesDetailWork.SalesDate;
            salesDetailWork.CommonSeqNo = dcSalesDetailWork.CommonSeqNo;
            salesDetailWork.SalesSlipDtlNum = dcSalesDetailWork.SalesSlipDtlNum;
            salesDetailWork.AcptAnOdrStatusSrc = dcSalesDetailWork.AcptAnOdrStatusSrc;
            salesDetailWork.SalesSlipDtlNumSrc = dcSalesDetailWork.SalesSlipDtlNumSrc;
            salesDetailWork.SupplierFormalSync = dcSalesDetailWork.SupplierFormalSync;
            salesDetailWork.StockSlipDtlNumSync = dcSalesDetailWork.StockSlipDtlNumSync;
            salesDetailWork.SalesSlipCdDtl = dcSalesDetailWork.SalesSlipCdDtl;
            salesDetailWork.DeliGdsCmpltDueDate = dcSalesDetailWork.DeliGdsCmpltDueDate;
            salesDetailWork.GoodsKindCode = dcSalesDetailWork.GoodsKindCode;
            salesDetailWork.GoodsSearchDivCd = dcSalesDetailWork.GoodsSearchDivCd;
            salesDetailWork.GoodsMakerCd = dcSalesDetailWork.GoodsMakerCd;
            salesDetailWork.MakerName = dcSalesDetailWork.MakerName;
            salesDetailWork.MakerKanaName = dcSalesDetailWork.MakerKanaName;
            salesDetailWork.GoodsNo = dcSalesDetailWork.GoodsNo;
            salesDetailWork.GoodsName = dcSalesDetailWork.GoodsName;
            salesDetailWork.GoodsNameKana = dcSalesDetailWork.GoodsNameKana;
            salesDetailWork.GoodsLGroup = dcSalesDetailWork.GoodsLGroup;
            salesDetailWork.GoodsLGroupName = dcSalesDetailWork.GoodsLGroupName;
            salesDetailWork.GoodsMGroup = dcSalesDetailWork.GoodsMGroup;
            salesDetailWork.GoodsMGroupName = dcSalesDetailWork.GoodsMGroupName;
            salesDetailWork.BLGroupCode = dcSalesDetailWork.BLGroupCode;
            salesDetailWork.BLGroupName = dcSalesDetailWork.BLGroupName;
            salesDetailWork.BLGoodsCode = dcSalesDetailWork.BLGoodsCode;
            salesDetailWork.BLGoodsFullName = dcSalesDetailWork.BLGoodsFullName;
            salesDetailWork.EnterpriseGanreCode = dcSalesDetailWork.EnterpriseGanreCode;
            salesDetailWork.EnterpriseGanreName = dcSalesDetailWork.EnterpriseGanreName;
            salesDetailWork.WarehouseCode = dcSalesDetailWork.WarehouseCode;
            salesDetailWork.WarehouseName = dcSalesDetailWork.WarehouseName;
            salesDetailWork.WarehouseShelfNo = dcSalesDetailWork.WarehouseShelfNo;
            salesDetailWork.SalesOrderDivCd = dcSalesDetailWork.SalesOrderDivCd;
            salesDetailWork.OpenPriceDiv = dcSalesDetailWork.OpenPriceDiv;
            salesDetailWork.GoodsRateRank = dcSalesDetailWork.GoodsRateRank;
            salesDetailWork.CustRateGrpCode = dcSalesDetailWork.CustRateGrpCode;
            salesDetailWork.ListPriceRate = dcSalesDetailWork.ListPriceRate;
            salesDetailWork.RateSectPriceUnPrc = dcSalesDetailWork.RateSectPriceUnPrc;
            salesDetailWork.RateDivLPrice = dcSalesDetailWork.RateDivLPrice;
            salesDetailWork.UnPrcCalcCdLPrice = dcSalesDetailWork.UnPrcCalcCdLPrice;
            salesDetailWork.PriceCdLPrice = dcSalesDetailWork.PriceCdLPrice;
            salesDetailWork.StdUnPrcLPrice = dcSalesDetailWork.StdUnPrcLPrice;
            salesDetailWork.FracProcUnitLPrice = dcSalesDetailWork.FracProcUnitLPrice;
            salesDetailWork.FracProcLPrice = dcSalesDetailWork.FracProcLPrice;
            salesDetailWork.ListPriceTaxIncFl = dcSalesDetailWork.ListPriceTaxIncFl;
            salesDetailWork.ListPriceTaxExcFl = dcSalesDetailWork.ListPriceTaxExcFl;
            salesDetailWork.ListPriceChngCd = dcSalesDetailWork.ListPriceChngCd;
            salesDetailWork.SalesRate = dcSalesDetailWork.SalesRate;
            salesDetailWork.RateSectSalUnPrc = dcSalesDetailWork.RateSectSalUnPrc;
            salesDetailWork.RateDivSalUnPrc = dcSalesDetailWork.RateDivSalUnPrc;
            salesDetailWork.UnPrcCalcCdSalUnPrc = dcSalesDetailWork.UnPrcCalcCdSalUnPrc;
            salesDetailWork.PriceCdSalUnPrc = dcSalesDetailWork.PriceCdSalUnPrc;
            salesDetailWork.StdUnPrcSalUnPrc = dcSalesDetailWork.StdUnPrcSalUnPrc;
            salesDetailWork.FracProcUnitSalUnPrc = dcSalesDetailWork.FracProcUnitSalUnPrc;
            salesDetailWork.FracProcSalUnPrc = dcSalesDetailWork.FracProcSalUnPrc;
            salesDetailWork.SalesUnPrcTaxIncFl = dcSalesDetailWork.SalesUnPrcTaxIncFl;
            salesDetailWork.SalesUnPrcTaxExcFl = dcSalesDetailWork.SalesUnPrcTaxExcFl;
            salesDetailWork.SalesUnPrcChngCd = dcSalesDetailWork.SalesUnPrcChngCd;
            salesDetailWork.CostRate = dcSalesDetailWork.CostRate;
            salesDetailWork.RateSectCstUnPrc = dcSalesDetailWork.RateSectCstUnPrc;
            salesDetailWork.RateDivUnCst = dcSalesDetailWork.RateDivUnCst;
            salesDetailWork.UnPrcCalcCdUnCst = dcSalesDetailWork.UnPrcCalcCdUnCst;
            salesDetailWork.PriceCdUnCst = dcSalesDetailWork.PriceCdUnCst;
            salesDetailWork.StdUnPrcUnCst = dcSalesDetailWork.StdUnPrcUnCst;
            salesDetailWork.FracProcUnitUnCst = dcSalesDetailWork.FracProcUnitUnCst;
            salesDetailWork.FracProcUnCst = dcSalesDetailWork.FracProcUnCst;
            salesDetailWork.SalesUnitCost = dcSalesDetailWork.SalesUnitCost;
            salesDetailWork.SalesUnitCostChngDiv = dcSalesDetailWork.SalesUnitCostChngDiv;
            salesDetailWork.RateBLGoodsCode = dcSalesDetailWork.RateBLGoodsCode;
            salesDetailWork.RateBLGoodsName = dcSalesDetailWork.RateBLGoodsName;
            salesDetailWork.RateGoodsRateGrpCd = dcSalesDetailWork.RateGoodsRateGrpCd;
            salesDetailWork.RateGoodsRateGrpNm = dcSalesDetailWork.RateGoodsRateGrpNm;
            salesDetailWork.RateBLGroupCode = dcSalesDetailWork.RateBLGroupCode;
            salesDetailWork.RateBLGroupName = dcSalesDetailWork.RateBLGroupName;
            salesDetailWork.PrtBLGoodsCode = dcSalesDetailWork.PrtBLGoodsCode;
            salesDetailWork.PrtBLGoodsName = dcSalesDetailWork.PrtBLGoodsName;
            salesDetailWork.SalesCode = dcSalesDetailWork.SalesCode;
            salesDetailWork.SalesCdNm = dcSalesDetailWork.SalesCdNm;
            salesDetailWork.WorkManHour = dcSalesDetailWork.WorkManHour;
            salesDetailWork.ShipmentCnt = dcSalesDetailWork.ShipmentCnt;
            salesDetailWork.AcceptAnOrderCnt = dcSalesDetailWork.AcceptAnOrderCnt;
            salesDetailWork.AcptAnOdrAdjustCnt = dcSalesDetailWork.AcptAnOdrAdjustCnt;
            salesDetailWork.AcptAnOdrRemainCnt = dcSalesDetailWork.AcptAnOdrRemainCnt;
            salesDetailWork.RemainCntUpdDate = dcSalesDetailWork.RemainCntUpdDate;
            salesDetailWork.SalesMoneyTaxInc = dcSalesDetailWork.SalesMoneyTaxInc;
            salesDetailWork.SalesMoneyTaxExc = dcSalesDetailWork.SalesMoneyTaxExc;
            salesDetailWork.Cost = dcSalesDetailWork.Cost;
            salesDetailWork.GrsProfitChkDiv = dcSalesDetailWork.GrsProfitChkDiv;
            salesDetailWork.SalesGoodsCd = dcSalesDetailWork.SalesGoodsCd;
            salesDetailWork.SalesPriceConsTax = dcSalesDetailWork.SalesPriceConsTax;
            salesDetailWork.TaxationDivCd = dcSalesDetailWork.TaxationDivCd;
            salesDetailWork.PartySlipNumDtl = dcSalesDetailWork.PartySlipNumDtl;
            salesDetailWork.DtlNote = dcSalesDetailWork.DtlNote;
            salesDetailWork.SupplierCd = dcSalesDetailWork.SupplierCd;
            salesDetailWork.SupplierSnm = dcSalesDetailWork.SupplierSnm;
            salesDetailWork.OrderNumber = dcSalesDetailWork.OrderNumber;
            salesDetailWork.WayToOrder = dcSalesDetailWork.WayToOrder;
            salesDetailWork.SlipMemo1 = dcSalesDetailWork.SlipMemo1;
            salesDetailWork.SlipMemo2 = dcSalesDetailWork.SlipMemo2;
            salesDetailWork.SlipMemo3 = dcSalesDetailWork.SlipMemo3;
            salesDetailWork.InsideMemo1 = dcSalesDetailWork.InsideMemo1;
            salesDetailWork.InsideMemo2 = dcSalesDetailWork.InsideMemo2;
            salesDetailWork.InsideMemo3 = dcSalesDetailWork.InsideMemo3;
            salesDetailWork.BfListPrice = dcSalesDetailWork.BfListPrice;
            salesDetailWork.BfSalesUnitPrice = dcSalesDetailWork.BfSalesUnitPrice;
            salesDetailWork.BfUnitCost = dcSalesDetailWork.BfUnitCost;
            salesDetailWork.CmpltSalesRowNo = dcSalesDetailWork.CmpltSalesRowNo;
            salesDetailWork.CmpltGoodsMakerCd = dcSalesDetailWork.CmpltGoodsMakerCd;
            salesDetailWork.CmpltMakerName = dcSalesDetailWork.CmpltMakerName;
            salesDetailWork.CmpltMakerKanaName = dcSalesDetailWork.CmpltMakerKanaName;
            salesDetailWork.CmpltGoodsName = dcSalesDetailWork.CmpltGoodsName;
            salesDetailWork.CmpltShipmentCnt = dcSalesDetailWork.CmpltShipmentCnt;
            salesDetailWork.CmpltSalesUnPrcFl = dcSalesDetailWork.CmpltSalesUnPrcFl;
            salesDetailWork.CmpltSalesMoney = dcSalesDetailWork.CmpltSalesMoney;
            salesDetailWork.CmpltSalesUnitCost = dcSalesDetailWork.CmpltSalesUnitCost;
            salesDetailWork.CmpltCost = dcSalesDetailWork.CmpltCost;
            salesDetailWork.CmpltPartySalSlNum = dcSalesDetailWork.CmpltPartySalSlNum;
            salesDetailWork.CmpltNote = dcSalesDetailWork.CmpltNote;
            salesDetailWork.PrtGoodsNo = dcSalesDetailWork.PrtGoodsNo;
            salesDetailWork.PrtMakerCode = dcSalesDetailWork.PrtMakerCode;
            salesDetailWork.PrtMakerName = dcSalesDetailWork.PrtMakerName;
            // ↓ 2009.05.26 liuyang add
            salesDetailWork.CampaignCode = dcSalesDetailWork.CampaignCode;
            salesDetailWork.CampaignName = dcSalesDetailWork.CampaignName;
            salesDetailWork.GoodsDivCd = dcSalesDetailWork.GoodsDivCd;
            salesDetailWork.AnswerDelivDate = dcSalesDetailWork.AnswerDelivDate;
            salesDetailWork.RecycleDiv = dcSalesDetailWork.RecycleDiv;
            salesDetailWork.RecycleDivNm = dcSalesDetailWork.RecycleDivNm;
            salesDetailWork.WayToAcptOdr = dcSalesDetailWork.WayToAcptOdr;
            // ↑ 2009.05.26 liuyang add
			// ADD 2011/09/15 ---------- >>>>>
			salesDetailWork.AutoAnswerDivSCM = dcSalesDetailWork.AutoAnswerDivSCM;
			salesDetailWork.AcceptOrOrderKind = dcSalesDetailWork.AcceptOrOrderKind;
			salesDetailWork.InquiryNumber = dcSalesDetailWork.InquiryNumber;
			salesDetailWork.InqRowNumber = dcSalesDetailWork.InqRowNumber;
			// ADD 2011/09/15 ---------- <<<<<
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 ----->>>>>
            salesDetailWork.RentSyncSupplier = dcSalesDetailWork.RentSyncSupplier; // 貸出同時仕入先
            salesDetailWork.RentSyncStockDate = dcSalesDetailWork.RentSyncStockDate; // 貸出同時仕入日
            salesDetailWork.RentSyncSupSlipNo = dcSalesDetailWork.RentSyncSupSlipNo; // 貸出同時仕入伝票番号
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 -----<<<<<
            return salesDetailWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcSalesHistoryWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APSalesHistoryWork SearchDataFromUpdateData(DCSalesHistoryWork dcSalesHistoryWork)
        {
            if (dcSalesHistoryWork == null)
            {
                return null;
            }

            APSalesHistoryWork salesHistoryWork = new APSalesHistoryWork();

            // 変換
            salesHistoryWork.CreateDateTime = dcSalesHistoryWork.CreateDateTime;
            salesHistoryWork.UpdateDateTime = dcSalesHistoryWork.UpdateDateTime;
            salesHistoryWork.EnterpriseCode = dcSalesHistoryWork.EnterpriseCode;
            salesHistoryWork.FileHeaderGuid = dcSalesHistoryWork.FileHeaderGuid;
            salesHistoryWork.UpdEmployeeCode = dcSalesHistoryWork.UpdEmployeeCode;
            salesHistoryWork.UpdAssemblyId1 = dcSalesHistoryWork.UpdAssemblyId1;
            salesHistoryWork.UpdAssemblyId2 = dcSalesHistoryWork.UpdAssemblyId2;
            salesHistoryWork.LogicalDeleteCode = dcSalesHistoryWork.LogicalDeleteCode;
            salesHistoryWork.AcptAnOdrStatus = dcSalesHistoryWork.AcptAnOdrStatus;
            salesHistoryWork.SalesSlipNum = dcSalesHistoryWork.SalesSlipNum;
            salesHistoryWork.SectionCode = dcSalesHistoryWork.SectionCode;
            salesHistoryWork.SubSectionCode = dcSalesHistoryWork.SubSectionCode;
            salesHistoryWork.DebitNoteDiv = dcSalesHistoryWork.DebitNoteDiv;
            salesHistoryWork.DebitNLnkSalesSlNum = dcSalesHistoryWork.DebitNLnkSalesSlNum;
            salesHistoryWork.SalesSlipCd = dcSalesHistoryWork.SalesSlipCd;
            salesHistoryWork.SalesGoodsCd = dcSalesHistoryWork.SalesGoodsCd;
            salesHistoryWork.AccRecDivCd = dcSalesHistoryWork.AccRecDivCd;
            salesHistoryWork.SalesInpSecCd = dcSalesHistoryWork.SalesInpSecCd;
            salesHistoryWork.DemandAddUpSecCd = dcSalesHistoryWork.DemandAddUpSecCd;
            salesHistoryWork.ResultsAddUpSecCd = dcSalesHistoryWork.ResultsAddUpSecCd;
            salesHistoryWork.UpdateSecCd = dcSalesHistoryWork.UpdateSecCd;
            salesHistoryWork.SalesSlipUpdateCd = dcSalesHistoryWork.SalesSlipUpdateCd;
            salesHistoryWork.SearchSlipDate = dcSalesHistoryWork.SearchSlipDate;
            salesHistoryWork.ShipmentDay = dcSalesHistoryWork.ShipmentDay;
            salesHistoryWork.SalesDate = dcSalesHistoryWork.SalesDate;
            salesHistoryWork.AddUpADate = dcSalesHistoryWork.AddUpADate;
            salesHistoryWork.DelayPaymentDiv = dcSalesHistoryWork.DelayPaymentDiv;
            salesHistoryWork.InputAgenCd = dcSalesHistoryWork.InputAgenCd;
            salesHistoryWork.InputAgenNm = dcSalesHistoryWork.InputAgenNm;
            salesHistoryWork.SalesInputCode = dcSalesHistoryWork.SalesInputCode;
            salesHistoryWork.SalesInputName = dcSalesHistoryWork.SalesInputName;
            salesHistoryWork.FrontEmployeeCd = dcSalesHistoryWork.FrontEmployeeCd;
            salesHistoryWork.FrontEmployeeNm = dcSalesHistoryWork.FrontEmployeeNm;
            salesHistoryWork.SalesEmployeeCd = dcSalesHistoryWork.SalesEmployeeCd;
            salesHistoryWork.SalesEmployeeNm = dcSalesHistoryWork.SalesEmployeeNm;
            salesHistoryWork.TotalAmountDispWayCd = dcSalesHistoryWork.TotalAmountDispWayCd;
            salesHistoryWork.TtlAmntDispRateApy = dcSalesHistoryWork.TtlAmntDispRateApy;
            salesHistoryWork.SalesTotalTaxInc = dcSalesHistoryWork.SalesTotalTaxInc;
            salesHistoryWork.SalesTotalTaxExc = dcSalesHistoryWork.SalesTotalTaxExc;
            salesHistoryWork.SalesPrtTotalTaxInc = dcSalesHistoryWork.SalesPrtTotalTaxInc;
            salesHistoryWork.SalesPrtTotalTaxExc = dcSalesHistoryWork.SalesPrtTotalTaxExc;
            salesHistoryWork.SalesWorkTotalTaxInc = dcSalesHistoryWork.SalesWorkTotalTaxInc;
            salesHistoryWork.SalesWorkTotalTaxExc = dcSalesHistoryWork.SalesWorkTotalTaxExc;
            salesHistoryWork.SalesSubtotalTaxInc = dcSalesHistoryWork.SalesSubtotalTaxInc;
            salesHistoryWork.SalesSubtotalTaxExc = dcSalesHistoryWork.SalesSubtotalTaxExc;
            salesHistoryWork.SalesPrtSubttlInc = dcSalesHistoryWork.SalesPrtSubttlInc;
            salesHistoryWork.SalesPrtSubttlExc = dcSalesHistoryWork.SalesPrtSubttlExc;
            salesHistoryWork.SalesWorkSubttlInc = dcSalesHistoryWork.SalesWorkSubttlInc;
            salesHistoryWork.SalesWorkSubttlExc = dcSalesHistoryWork.SalesWorkSubttlExc;
            salesHistoryWork.SalesNetPrice = dcSalesHistoryWork.SalesNetPrice;
            salesHistoryWork.SalesSubtotalTax = dcSalesHistoryWork.SalesSubtotalTax;
            salesHistoryWork.ItdedSalesOutTax = dcSalesHistoryWork.ItdedSalesOutTax;
            salesHistoryWork.ItdedSalesInTax = dcSalesHistoryWork.ItdedSalesInTax;
            salesHistoryWork.SalSubttlSubToTaxFre = dcSalesHistoryWork.SalSubttlSubToTaxFre;
            salesHistoryWork.SalesOutTax = dcSalesHistoryWork.SalesOutTax;
            salesHistoryWork.SalAmntConsTaxInclu = dcSalesHistoryWork.SalAmntConsTaxInclu;
            salesHistoryWork.SalesDisTtlTaxExc = dcSalesHistoryWork.SalesDisTtlTaxExc;
            salesHistoryWork.ItdedSalesDisOutTax = dcSalesHistoryWork.ItdedSalesDisOutTax;
            salesHistoryWork.ItdedSalesDisInTax = dcSalesHistoryWork.ItdedSalesDisInTax;
            salesHistoryWork.ItdedPartsDisOutTax = dcSalesHistoryWork.ItdedPartsDisOutTax;
            salesHistoryWork.ItdedPartsDisInTax = dcSalesHistoryWork.ItdedPartsDisInTax;
            salesHistoryWork.ItdedWorkDisOutTax = dcSalesHistoryWork.ItdedWorkDisOutTax;
            salesHistoryWork.ItdedWorkDisInTax = dcSalesHistoryWork.ItdedWorkDisInTax;
            salesHistoryWork.ItdedSalesDisTaxFre = dcSalesHistoryWork.ItdedSalesDisTaxFre;
            salesHistoryWork.SalesDisOutTax = dcSalesHistoryWork.SalesDisOutTax;
            salesHistoryWork.SalesDisTtlTaxInclu = dcSalesHistoryWork.SalesDisTtlTaxInclu;
            salesHistoryWork.PartsDiscountRate = dcSalesHistoryWork.PartsDiscountRate;
            salesHistoryWork.RavorDiscountRate = dcSalesHistoryWork.RavorDiscountRate;
            salesHistoryWork.TotalCost = dcSalesHistoryWork.TotalCost;
            salesHistoryWork.ConsTaxLayMethod = dcSalesHistoryWork.ConsTaxLayMethod;
            salesHistoryWork.ConsTaxRate = dcSalesHistoryWork.ConsTaxRate;
            salesHistoryWork.FractionProcCd = dcSalesHistoryWork.FractionProcCd;
            salesHistoryWork.AccRecConsTax = dcSalesHistoryWork.AccRecConsTax;
            salesHistoryWork.AutoDepositCd = dcSalesHistoryWork.AutoDepositCd;
            salesHistoryWork.AutoDepositSlipNo = dcSalesHistoryWork.AutoDepositSlipNo;
            salesHistoryWork.DepositAllowanceTtl = dcSalesHistoryWork.DepositAllowanceTtl;
            salesHistoryWork.DepositAlwcBlnce = dcSalesHistoryWork.DepositAlwcBlnce;
            salesHistoryWork.ClaimCode = dcSalesHistoryWork.ClaimCode;
            salesHistoryWork.ClaimSnm = dcSalesHistoryWork.ClaimSnm;
            salesHistoryWork.CustomerCode = dcSalesHistoryWork.CustomerCode;
            salesHistoryWork.CustomerName = dcSalesHistoryWork.CustomerName;
            salesHistoryWork.CustomerName2 = dcSalesHistoryWork.CustomerName2;
            salesHistoryWork.CustomerSnm = dcSalesHistoryWork.CustomerSnm;
            salesHistoryWork.HonorificTitle = dcSalesHistoryWork.HonorificTitle;
            salesHistoryWork.OutputNameCode = dcSalesHistoryWork.OutputNameCode;
            salesHistoryWork.OutputName = dcSalesHistoryWork.OutputName;
            salesHistoryWork.CustSlipNo = dcSalesHistoryWork.CustSlipNo;
            salesHistoryWork.SlipAddressDiv = dcSalesHistoryWork.SlipAddressDiv;
            salesHistoryWork.AddresseeCode = dcSalesHistoryWork.AddresseeCode;
            salesHistoryWork.AddresseeName = dcSalesHistoryWork.AddresseeName;
            salesHistoryWork.AddresseeName2 = dcSalesHistoryWork.AddresseeName2;
            salesHistoryWork.AddresseePostNo = dcSalesHistoryWork.AddresseePostNo;
            salesHistoryWork.AddresseeAddr1 = dcSalesHistoryWork.AddresseeAddr1;
            salesHistoryWork.AddresseeAddr3 = dcSalesHistoryWork.AddresseeAddr3;
            salesHistoryWork.AddresseeAddr4 = dcSalesHistoryWork.AddresseeAddr4;
            salesHistoryWork.AddresseeTelNo = dcSalesHistoryWork.AddresseeTelNo;
            salesHistoryWork.AddresseeFaxNo = dcSalesHistoryWork.AddresseeFaxNo;
            salesHistoryWork.PartySaleSlipNum = dcSalesHistoryWork.PartySaleSlipNum;
            salesHistoryWork.SlipNote = dcSalesHistoryWork.SlipNote;
            salesHistoryWork.SlipNote2 = dcSalesHistoryWork.SlipNote2;
            salesHistoryWork.SlipNote3 = dcSalesHistoryWork.SlipNote3;
            salesHistoryWork.RetGoodsReasonDiv = dcSalesHistoryWork.RetGoodsReasonDiv;
            salesHistoryWork.RetGoodsReason = dcSalesHistoryWork.RetGoodsReason;
            salesHistoryWork.DetailRowCount = dcSalesHistoryWork.DetailRowCount;
            salesHistoryWork.EdiSendDate = dcSalesHistoryWork.EdiSendDate;
            salesHistoryWork.EdiTakeInDate = dcSalesHistoryWork.EdiTakeInDate;
            salesHistoryWork.UoeRemark1 = dcSalesHistoryWork.UoeRemark1;
            salesHistoryWork.UoeRemark2 = dcSalesHistoryWork.UoeRemark2;
            salesHistoryWork.SlipPrintDivCd = dcSalesHistoryWork.SlipPrintDivCd;
            salesHistoryWork.SlipPrintFinishCd = dcSalesHistoryWork.SlipPrintFinishCd;
            salesHistoryWork.SalesSlipPrintDate = dcSalesHistoryWork.SalesSlipPrintDate;
            salesHistoryWork.BusinessTypeCode = dcSalesHistoryWork.BusinessTypeCode;
            salesHistoryWork.BusinessTypeName = dcSalesHistoryWork.BusinessTypeName;
            salesHistoryWork.DeliveredGoodsDiv = dcSalesHistoryWork.DeliveredGoodsDiv;
            salesHistoryWork.DeliveredGoodsDivNm = dcSalesHistoryWork.DeliveredGoodsDivNm;
            salesHistoryWork.SalesAreaCode = dcSalesHistoryWork.SalesAreaCode;
            salesHistoryWork.SalesAreaName = dcSalesHistoryWork.SalesAreaName;
            salesHistoryWork.SlipPrtSetPaperId = dcSalesHistoryWork.SlipPrtSetPaperId;
            salesHistoryWork.CompleteCd = dcSalesHistoryWork.CompleteCd;
            salesHistoryWork.SalesPriceFracProcCd = dcSalesHistoryWork.SalesPriceFracProcCd;
            salesHistoryWork.StockGoodsTtlTaxExc = dcSalesHistoryWork.StockGoodsTtlTaxExc;
            salesHistoryWork.PureGoodsTtlTaxExc = dcSalesHistoryWork.PureGoodsTtlTaxExc;
            salesHistoryWork.ListPricePrintDiv = dcSalesHistoryWork.ListPricePrintDiv;
            salesHistoryWork.EraNameDispCd1 = dcSalesHistoryWork.EraNameDispCd1;

            return salesHistoryWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcSalesHistDtlWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        /// <br>Update Note: PMKOBETSU-3877の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/09/25</br>
        public static APSalesHistDtlWork SearchDataFromUpdateData(DCSalesHistDtlWork dcSalesHistDtlWork)
        {
            if (dcSalesHistDtlWork == null)
            {
                return null;
            }

            APSalesHistDtlWork salesHistDtlWork = new APSalesHistDtlWork();

            // 変換
            salesHistDtlWork.CreateDateTime = dcSalesHistDtlWork.CreateDateTime;
            salesHistDtlWork.UpdateDateTime = dcSalesHistDtlWork.UpdateDateTime;
            salesHistDtlWork.EnterpriseCode = dcSalesHistDtlWork.EnterpriseCode;
            salesHistDtlWork.FileHeaderGuid = dcSalesHistDtlWork.FileHeaderGuid;
            salesHistDtlWork.UpdEmployeeCode = dcSalesHistDtlWork.UpdEmployeeCode;
            salesHistDtlWork.UpdAssemblyId1 = dcSalesHistDtlWork.UpdAssemblyId1;
            salesHistDtlWork.UpdAssemblyId2 = dcSalesHistDtlWork.UpdAssemblyId2;
            salesHistDtlWork.LogicalDeleteCode = dcSalesHistDtlWork.LogicalDeleteCode;
            salesHistDtlWork.AcceptAnOrderNo = dcSalesHistDtlWork.AcceptAnOrderNo;
            salesHistDtlWork.AcptAnOdrStatus = dcSalesHistDtlWork.AcptAnOdrStatus;
            salesHistDtlWork.SalesSlipNum = dcSalesHistDtlWork.SalesSlipNum;
            salesHistDtlWork.SalesRowNo = dcSalesHistDtlWork.SalesRowNo;
            salesHistDtlWork.SalesRowDerivNo = dcSalesHistDtlWork.SalesRowDerivNo;
            salesHistDtlWork.SectionCode = dcSalesHistDtlWork.SectionCode;
            salesHistDtlWork.SubSectionCode = dcSalesHistDtlWork.SubSectionCode;
            salesHistDtlWork.SalesDate = dcSalesHistDtlWork.SalesDate;
            salesHistDtlWork.CommonSeqNo = dcSalesHistDtlWork.CommonSeqNo;
            salesHistDtlWork.SalesSlipDtlNum = dcSalesHistDtlWork.SalesSlipDtlNum;
            salesHistDtlWork.AcptAnOdrStatusSrc = dcSalesHistDtlWork.AcptAnOdrStatusSrc;
            salesHistDtlWork.SalesSlipDtlNumSrc = dcSalesHistDtlWork.SalesSlipDtlNumSrc;
            salesHistDtlWork.SupplierFormalSync = dcSalesHistDtlWork.SupplierFormalSync;
            salesHistDtlWork.StockSlipDtlNumSync = dcSalesHistDtlWork.StockSlipDtlNumSync;
            salesHistDtlWork.SalesSlipCdDtl = dcSalesHistDtlWork.SalesSlipCdDtl;
            salesHistDtlWork.GoodsKindCode = dcSalesHistDtlWork.GoodsKindCode;
            salesHistDtlWork.GoodsMakerCd = dcSalesHistDtlWork.GoodsMakerCd;
            salesHistDtlWork.MakerName = dcSalesHistDtlWork.MakerName;
            salesHistDtlWork.MakerKanaName = dcSalesHistDtlWork.MakerKanaName;
            salesHistDtlWork.GoodsNo = dcSalesHistDtlWork.GoodsNo;
            salesHistDtlWork.GoodsName = dcSalesHistDtlWork.GoodsName;
            salesHistDtlWork.GoodsNameKana = dcSalesHistDtlWork.GoodsNameKana;
            salesHistDtlWork.GoodsLGroup = dcSalesHistDtlWork.GoodsLGroup;
            salesHistDtlWork.GoodsLGroupName = dcSalesHistDtlWork.GoodsLGroupName;
            salesHistDtlWork.GoodsMGroup = dcSalesHistDtlWork.GoodsMGroup;
            salesHistDtlWork.GoodsMGroupName = dcSalesHistDtlWork.GoodsMGroupName;
            salesHistDtlWork.BLGroupCode = dcSalesHistDtlWork.BLGroupCode;
            salesHistDtlWork.BLGroupName = dcSalesHistDtlWork.BLGroupName;
            salesHistDtlWork.BLGoodsCode = dcSalesHistDtlWork.BLGoodsCode;
            salesHistDtlWork.BLGoodsFullName = dcSalesHistDtlWork.BLGoodsFullName;
            salesHistDtlWork.EnterpriseGanreCode = dcSalesHistDtlWork.EnterpriseGanreCode;
            salesHistDtlWork.EnterpriseGanreName = dcSalesHistDtlWork.EnterpriseGanreName;
            salesHistDtlWork.WarehouseCode = dcSalesHistDtlWork.WarehouseCode;
            salesHistDtlWork.WarehouseName = dcSalesHistDtlWork.WarehouseName;
            salesHistDtlWork.WarehouseShelfNo = dcSalesHistDtlWork.WarehouseShelfNo;
            salesHistDtlWork.SalesOrderDivCd = dcSalesHistDtlWork.SalesOrderDivCd;
            salesHistDtlWork.OpenPriceDiv = dcSalesHistDtlWork.OpenPriceDiv;
            salesHistDtlWork.GoodsRateRank = dcSalesHistDtlWork.GoodsRateRank;
            salesHistDtlWork.CustRateGrpCode = dcSalesHistDtlWork.CustRateGrpCode;
            salesHistDtlWork.ListPriceRate = dcSalesHistDtlWork.ListPriceRate;
            salesHistDtlWork.RateSectPriceUnPrc = dcSalesHistDtlWork.RateSectPriceUnPrc;
            salesHistDtlWork.RateDivLPrice = dcSalesHistDtlWork.RateDivLPrice;
            salesHistDtlWork.UnPrcCalcCdLPrice = dcSalesHistDtlWork.UnPrcCalcCdLPrice;
            salesHistDtlWork.PriceCdLPrice = dcSalesHistDtlWork.PriceCdLPrice;
            salesHistDtlWork.StdUnPrcLPrice = dcSalesHistDtlWork.StdUnPrcLPrice;
            salesHistDtlWork.FracProcUnitLPrice = dcSalesHistDtlWork.FracProcUnitLPrice;
            salesHistDtlWork.FracProcLPrice = dcSalesHistDtlWork.FracProcLPrice;
            salesHistDtlWork.ListPriceTaxIncFl = dcSalesHistDtlWork.ListPriceTaxIncFl;
            salesHistDtlWork.ListPriceTaxExcFl = dcSalesHistDtlWork.ListPriceTaxExcFl;
            salesHistDtlWork.ListPriceChngCd = dcSalesHistDtlWork.ListPriceChngCd;
            salesHistDtlWork.SalesRate = dcSalesHistDtlWork.SalesRate;
            salesHistDtlWork.RateSectSalUnPrc = dcSalesHistDtlWork.RateSectSalUnPrc;
            salesHistDtlWork.RateDivSalUnPrc = dcSalesHistDtlWork.RateDivSalUnPrc;
            salesHistDtlWork.UnPrcCalcCdSalUnPrc = dcSalesHistDtlWork.UnPrcCalcCdSalUnPrc;
            salesHistDtlWork.PriceCdSalUnPrc = dcSalesHistDtlWork.PriceCdSalUnPrc;
            salesHistDtlWork.StdUnPrcSalUnPrc = dcSalesHistDtlWork.StdUnPrcSalUnPrc;
            salesHistDtlWork.FracProcUnitSalUnPrc = dcSalesHistDtlWork.FracProcUnitSalUnPrc;
            salesHistDtlWork.FracProcSalUnPrc = dcSalesHistDtlWork.FracProcSalUnPrc;
            salesHistDtlWork.SalesUnPrcTaxIncFl = dcSalesHistDtlWork.SalesUnPrcTaxIncFl;
            salesHistDtlWork.SalesUnPrcTaxExcFl = dcSalesHistDtlWork.SalesUnPrcTaxExcFl;
            salesHistDtlWork.SalesUnPrcChngCd = dcSalesHistDtlWork.SalesUnPrcChngCd;
            salesHistDtlWork.CostRate = dcSalesHistDtlWork.CostRate;
            salesHistDtlWork.RateSectCstUnPrc = dcSalesHistDtlWork.RateSectCstUnPrc;
            salesHistDtlWork.RateDivUnCst = dcSalesHistDtlWork.RateDivUnCst;
            salesHistDtlWork.UnPrcCalcCdUnCst = dcSalesHistDtlWork.UnPrcCalcCdUnCst;
            salesHistDtlWork.PriceCdUnCst = dcSalesHistDtlWork.PriceCdUnCst;
            salesHistDtlWork.StdUnPrcUnCst = dcSalesHistDtlWork.StdUnPrcUnCst;
            salesHistDtlWork.FracProcUnitUnCst = dcSalesHistDtlWork.FracProcUnitUnCst;
            salesHistDtlWork.FracProcUnCst = dcSalesHistDtlWork.FracProcUnCst;
            salesHistDtlWork.SalesUnitCost = dcSalesHistDtlWork.SalesUnitCost;
            salesHistDtlWork.SalesUnitCostChngDiv = dcSalesHistDtlWork.SalesUnitCostChngDiv;
            salesHistDtlWork.RateBLGoodsCode = dcSalesHistDtlWork.RateBLGoodsCode;
            salesHistDtlWork.RateBLGoodsName = dcSalesHistDtlWork.RateBLGoodsName;
            salesHistDtlWork.RateGoodsRateGrpCd = dcSalesHistDtlWork.RateGoodsRateGrpCd;
            salesHistDtlWork.RateGoodsRateGrpNm = dcSalesHistDtlWork.RateGoodsRateGrpNm;
            salesHistDtlWork.RateBLGroupCode = dcSalesHistDtlWork.RateBLGroupCode;
            salesHistDtlWork.RateBLGroupName = dcSalesHistDtlWork.RateBLGroupName;
            salesHistDtlWork.PrtBLGoodsCode = dcSalesHistDtlWork.PrtBLGoodsCode;
            salesHistDtlWork.PrtBLGoodsName = dcSalesHistDtlWork.PrtBLGoodsName;
            salesHistDtlWork.SalesCode = dcSalesHistDtlWork.SalesCode;
            salesHistDtlWork.SalesCdNm = dcSalesHistDtlWork.SalesCdNm;
            salesHistDtlWork.WorkManHour = dcSalesHistDtlWork.WorkManHour;
            salesHistDtlWork.ShipmentCnt = dcSalesHistDtlWork.ShipmentCnt;
            salesHistDtlWork.SalesMoneyTaxInc = dcSalesHistDtlWork.SalesMoneyTaxInc;
            salesHistDtlWork.SalesMoneyTaxExc = dcSalesHistDtlWork.SalesMoneyTaxExc;
            salesHistDtlWork.Cost = dcSalesHistDtlWork.Cost;
            salesHistDtlWork.GrsProfitChkDiv = dcSalesHistDtlWork.GrsProfitChkDiv;
            salesHistDtlWork.SalesGoodsCd = dcSalesHistDtlWork.SalesGoodsCd;
            salesHistDtlWork.SalesPriceConsTax = dcSalesHistDtlWork.SalesPriceConsTax;
            salesHistDtlWork.TaxationDivCd = dcSalesHistDtlWork.TaxationDivCd;
            salesHistDtlWork.PartySlipNumDtl = dcSalesHistDtlWork.PartySlipNumDtl;
            salesHistDtlWork.DtlNote = dcSalesHistDtlWork.DtlNote;
            salesHistDtlWork.SupplierCd = dcSalesHistDtlWork.SupplierCd;
            salesHistDtlWork.SupplierSnm = dcSalesHistDtlWork.SupplierSnm;
            salesHistDtlWork.OrderNumber = dcSalesHistDtlWork.OrderNumber;
            salesHistDtlWork.WayToOrder = dcSalesHistDtlWork.WayToOrder;
            salesHistDtlWork.SlipMemo1 = dcSalesHistDtlWork.SlipMemo1;
            salesHistDtlWork.SlipMemo2 = dcSalesHistDtlWork.SlipMemo2;
            salesHistDtlWork.SlipMemo3 = dcSalesHistDtlWork.SlipMemo3;
            salesHistDtlWork.InsideMemo1 = dcSalesHistDtlWork.InsideMemo1;
            salesHistDtlWork.InsideMemo2 = dcSalesHistDtlWork.InsideMemo2;
            salesHistDtlWork.InsideMemo3 = dcSalesHistDtlWork.InsideMemo3;
            salesHistDtlWork.BfListPrice = dcSalesHistDtlWork.BfListPrice;
            salesHistDtlWork.BfSalesUnitPrice = dcSalesHistDtlWork.BfSalesUnitPrice;
            salesHistDtlWork.BfUnitCost = dcSalesHistDtlWork.BfUnitCost;
            salesHistDtlWork.CmpltSalesRowNo = dcSalesHistDtlWork.CmpltSalesRowNo;
            salesHistDtlWork.CmpltGoodsMakerCd = dcSalesHistDtlWork.CmpltGoodsMakerCd;
            salesHistDtlWork.CmpltMakerName = dcSalesHistDtlWork.CmpltMakerName;
            salesHistDtlWork.CmpltMakerKanaName = dcSalesHistDtlWork.CmpltMakerKanaName;
            salesHistDtlWork.CmpltGoodsName = dcSalesHistDtlWork.CmpltGoodsName;
            salesHistDtlWork.CmpltShipmentCnt = dcSalesHistDtlWork.CmpltShipmentCnt;
            salesHistDtlWork.CmpltSalesUnPrcFl = dcSalesHistDtlWork.CmpltSalesUnPrcFl;
            salesHistDtlWork.CmpltSalesMoney = dcSalesHistDtlWork.CmpltSalesMoney;
            salesHistDtlWork.CmpltSalesUnitCost = dcSalesHistDtlWork.CmpltSalesUnitCost;
            salesHistDtlWork.CmpltCost = dcSalesHistDtlWork.CmpltCost;
            salesHistDtlWork.CmpltPartySalSlNum = dcSalesHistDtlWork.CmpltPartySalSlNum;
            salesHistDtlWork.CmpltNote = dcSalesHistDtlWork.CmpltNote;
            salesHistDtlWork.PrtGoodsNo = dcSalesHistDtlWork.PrtGoodsNo;
            salesHistDtlWork.PrtMakerCode = dcSalesHistDtlWork.PrtMakerCode;
            salesHistDtlWork.PrtMakerName = dcSalesHistDtlWork.PrtMakerName;
            // ↓ 2009.05.26 liuyang add
            salesHistDtlWork.CampaignCode = dcSalesHistDtlWork.CampaignCode;
            salesHistDtlWork.CampaignName = dcSalesHistDtlWork.CampaignName;
            salesHistDtlWork.GoodsDivCd = dcSalesHistDtlWork.GoodsDivCd;
            salesHistDtlWork.AnswerDelivDate = dcSalesHistDtlWork.AnswerDelivDate;
            salesHistDtlWork.RecycleDiv = dcSalesHistDtlWork.RecycleDiv;
            salesHistDtlWork.RecycleDivNm = dcSalesHistDtlWork.RecycleDivNm;
            salesHistDtlWork.WayToAcptOdr = dcSalesHistDtlWork.WayToAcptOdr;
            // ↑ 2009.05.26 liuyang add
			// ADD 2011/09/15 ---------- >>>>>
			salesHistDtlWork.AutoAnswerDivSCM = dcSalesHistDtlWork.AutoAnswerDivSCM;
			salesHistDtlWork.AcceptOrOrderKind = dcSalesHistDtlWork.AcceptOrOrderKind;
			salesHistDtlWork.InquiryNumber = dcSalesHistDtlWork.InquiryNumber;
			salesHistDtlWork.InqRowNumber = dcSalesHistDtlWork.InqRowNumber;
			// ADD 2011/09/15 ---------- <<<<<
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 ----->>>>>
            salesHistDtlWork.RentSyncSupplier = dcSalesHistDtlWork.RentSyncSupplier; // 貸出同時仕入先
            salesHistDtlWork.RentSyncStockDate = dcSalesHistDtlWork.RentSyncStockDate; // 貸出同時仕入日
            salesHistDtlWork.RentSyncSupSlipNo = dcSalesHistDtlWork.RentSyncSupSlipNo; // 貸出同時仕入伝票番号
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 -----<<<<<
            return salesHistDtlWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcDepsitMainWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APDepsitMainWork SearchDataFromUpdateData(DCDepsitMainWork dcDepsitMainWork)
        {
            if (dcDepsitMainWork == null)
            {
                return null;
            }

            APDepsitMainWork depsitMainWork = new APDepsitMainWork();

            // 変換
            depsitMainWork.CreateDateTime = dcDepsitMainWork.CreateDateTime;
            depsitMainWork.UpdateDateTime = dcDepsitMainWork.UpdateDateTime;
            depsitMainWork.EnterpriseCode = dcDepsitMainWork.EnterpriseCode;
            depsitMainWork.FileHeaderGuid = dcDepsitMainWork.FileHeaderGuid;
            depsitMainWork.UpdEmployeeCode = dcDepsitMainWork.UpdEmployeeCode;
            depsitMainWork.UpdAssemblyId1 = dcDepsitMainWork.UpdAssemblyId1;
            depsitMainWork.UpdAssemblyId2 = dcDepsitMainWork.UpdAssemblyId2;
            depsitMainWork.LogicalDeleteCode = dcDepsitMainWork.LogicalDeleteCode;
            depsitMainWork.AcptAnOdrStatus = dcDepsitMainWork.AcptAnOdrStatus;
            depsitMainWork.DepositDebitNoteCd = dcDepsitMainWork.DepositDebitNoteCd;
            depsitMainWork.DepositSlipNo = dcDepsitMainWork.DepositSlipNo;
            depsitMainWork.SalesSlipNum = dcDepsitMainWork.SalesSlipNum;
            depsitMainWork.InputDepositSecCd = dcDepsitMainWork.InputDepositSecCd;
            depsitMainWork.AddUpSecCode = dcDepsitMainWork.AddUpSecCode;
            depsitMainWork.UpdateSecCd = dcDepsitMainWork.UpdateSecCd;
            depsitMainWork.SubSectionCode = dcDepsitMainWork.SubSectionCode;
            depsitMainWork.InputDay = dcDepsitMainWork.InputDay;
            depsitMainWork.DepositDate = dcDepsitMainWork.DepositDate;
            depsitMainWork.AddUpADate = dcDepsitMainWork.AddUpADate;
            depsitMainWork.DepositTotal = dcDepsitMainWork.DepositTotal;
            depsitMainWork.Deposit = dcDepsitMainWork.Deposit;
            depsitMainWork.FeeDeposit = dcDepsitMainWork.FeeDeposit;
            depsitMainWork.DiscountDeposit = dcDepsitMainWork.DiscountDeposit;
            depsitMainWork.AutoDepositCd = dcDepsitMainWork.AutoDepositCd;
            depsitMainWork.DraftDrawingDate = dcDepsitMainWork.DraftDrawingDate;
            depsitMainWork.DraftKind = dcDepsitMainWork.DraftKind;
            depsitMainWork.DraftKindName = dcDepsitMainWork.DraftKindName;
            depsitMainWork.DraftDivide = dcDepsitMainWork.DraftDivide;
            depsitMainWork.DraftDivideName = dcDepsitMainWork.DraftDivideName;
            depsitMainWork.DraftNo = dcDepsitMainWork.DraftNo;
            depsitMainWork.DepositAllowance = dcDepsitMainWork.DepositAllowance;
            depsitMainWork.DepositAlwcBlnce = dcDepsitMainWork.DepositAlwcBlnce;
            depsitMainWork.DebitNoteLinkDepoNo = dcDepsitMainWork.DebitNoteLinkDepoNo;
            depsitMainWork.LastReconcileAddUpDt = dcDepsitMainWork.LastReconcileAddUpDt;
            depsitMainWork.DepositAgentCode = dcDepsitMainWork.DepositAgentCode;
            depsitMainWork.DepositAgentNm = dcDepsitMainWork.DepositAgentNm;
            depsitMainWork.DepositInputAgentCd = dcDepsitMainWork.DepositInputAgentCd;
            depsitMainWork.DepositInputAgentNm = dcDepsitMainWork.DepositInputAgentNm;
            depsitMainWork.CustomerCode = dcDepsitMainWork.CustomerCode;
            depsitMainWork.CustomerName = dcDepsitMainWork.CustomerName;
            depsitMainWork.CustomerName2 = dcDepsitMainWork.CustomerName2;
            depsitMainWork.CustomerSnm = dcDepsitMainWork.CustomerSnm;
            depsitMainWork.ClaimCode = dcDepsitMainWork.ClaimCode;
            depsitMainWork.ClaimName = dcDepsitMainWork.ClaimName;
            depsitMainWork.ClaimName2 = dcDepsitMainWork.ClaimName2;
            depsitMainWork.ClaimSnm = dcDepsitMainWork.ClaimSnm;
            depsitMainWork.Outline = dcDepsitMainWork.Outline;
            depsitMainWork.BankCode = dcDepsitMainWork.BankCode;
            depsitMainWork.BankName = dcDepsitMainWork.BankName;

            return depsitMainWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcDepsitDtlWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APDepsitDtlWork SearchDataFromUpdateData(DCDepsitDtlWork dcDepsitDtlWork)
        {
            if (dcDepsitDtlWork == null)
            {
                return null;
            }

            APDepsitDtlWork depsitDtlWork = new APDepsitDtlWork();

            // 変換
            depsitDtlWork.CreateDateTime = dcDepsitDtlWork.CreateDateTime;
            depsitDtlWork.UpdateDateTime = dcDepsitDtlWork.UpdateDateTime;
            depsitDtlWork.EnterpriseCode = dcDepsitDtlWork.EnterpriseCode;
            depsitDtlWork.FileHeaderGuid = dcDepsitDtlWork.FileHeaderGuid;
            depsitDtlWork.UpdEmployeeCode = dcDepsitDtlWork.UpdEmployeeCode;
            depsitDtlWork.UpdAssemblyId1 = dcDepsitDtlWork.UpdAssemblyId1;
            depsitDtlWork.UpdAssemblyId2 = dcDepsitDtlWork.UpdAssemblyId2;
            depsitDtlWork.LogicalDeleteCode = dcDepsitDtlWork.LogicalDeleteCode;
            depsitDtlWork.AcptAnOdrStatus = dcDepsitDtlWork.AcptAnOdrStatus;
            depsitDtlWork.DepositSlipNo = dcDepsitDtlWork.DepositSlipNo;
            depsitDtlWork.DepositRowNo = dcDepsitDtlWork.DepositRowNo;
            depsitDtlWork.MoneyKindCode = dcDepsitDtlWork.MoneyKindCode;
            depsitDtlWork.MoneyKindName = dcDepsitDtlWork.MoneyKindName;
            depsitDtlWork.MoneyKindDiv = dcDepsitDtlWork.MoneyKindDiv;
            depsitDtlWork.Deposit = dcDepsitDtlWork.Deposit;
            depsitDtlWork.ValidityTerm = dcDepsitDtlWork.ValidityTerm;

            return depsitDtlWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcStockSlipWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APStockSlipWork SearchDataFromUpdateData(DCStockSlipWork dcStockSlipWork)
        {
            if (dcStockSlipWork == null)
            {
                return null;
            }

            APStockSlipWork stockSlipWork = new APStockSlipWork();

            // 変換
            stockSlipWork.CreateDateTime = dcStockSlipWork.CreateDateTime;
            stockSlipWork.UpdateDateTime = dcStockSlipWork.UpdateDateTime;
            stockSlipWork.EnterpriseCode = dcStockSlipWork.EnterpriseCode;
            stockSlipWork.FileHeaderGuid = dcStockSlipWork.FileHeaderGuid;
            stockSlipWork.UpdEmployeeCode = dcStockSlipWork.UpdEmployeeCode;
            stockSlipWork.UpdAssemblyId1 = dcStockSlipWork.UpdAssemblyId1;
            stockSlipWork.UpdAssemblyId2 = dcStockSlipWork.UpdAssemblyId2;
            stockSlipWork.LogicalDeleteCode = dcStockSlipWork.LogicalDeleteCode;
            stockSlipWork.SupplierFormal = dcStockSlipWork.SupplierFormal;
            stockSlipWork.SupplierSlipNo = dcStockSlipWork.SupplierSlipNo;
            stockSlipWork.SectionCode = dcStockSlipWork.SectionCode;
            stockSlipWork.SubSectionCode = dcStockSlipWork.SubSectionCode;
            stockSlipWork.DebitNoteDiv = dcStockSlipWork.DebitNoteDiv;
            stockSlipWork.DebitNLnkSuppSlipNo = dcStockSlipWork.DebitNLnkSuppSlipNo;
            stockSlipWork.SupplierSlipCd = dcStockSlipWork.SupplierSlipCd;
            stockSlipWork.StockGoodsCd = dcStockSlipWork.StockGoodsCd;
            stockSlipWork.AccPayDivCd = dcStockSlipWork.AccPayDivCd;
            stockSlipWork.StockSectionCd = dcStockSlipWork.StockSectionCd;
            stockSlipWork.StockAddUpSectionCd = dcStockSlipWork.StockAddUpSectionCd;
            stockSlipWork.StockSlipUpdateCd = dcStockSlipWork.StockSlipUpdateCd;
            stockSlipWork.InputDay = dcStockSlipWork.InputDay;
            stockSlipWork.ArrivalGoodsDay = dcStockSlipWork.ArrivalGoodsDay;
            stockSlipWork.StockDate = dcStockSlipWork.StockDate;
            stockSlipWork.StockAddUpADate = dcStockSlipWork.StockAddUpADate;
            stockSlipWork.DelayPaymentDiv = dcStockSlipWork.DelayPaymentDiv;
            stockSlipWork.PayeeCode = dcStockSlipWork.PayeeCode;
            stockSlipWork.PayeeSnm = dcStockSlipWork.PayeeSnm;
            stockSlipWork.SupplierCd = dcStockSlipWork.SupplierCd;
            stockSlipWork.SupplierNm1 = dcStockSlipWork.SupplierNm1;
            stockSlipWork.SupplierNm2 = dcStockSlipWork.SupplierNm2;
            stockSlipWork.SupplierSnm = dcStockSlipWork.SupplierSnm;
            stockSlipWork.BusinessTypeCode = dcStockSlipWork.BusinessTypeCode;
            stockSlipWork.BusinessTypeName = dcStockSlipWork.BusinessTypeName;
            stockSlipWork.SalesAreaCode = dcStockSlipWork.SalesAreaCode;
            stockSlipWork.SalesAreaName = dcStockSlipWork.SalesAreaName;
            stockSlipWork.StockInputCode = dcStockSlipWork.StockInputCode;
            stockSlipWork.StockInputName = dcStockSlipWork.StockInputName;
            stockSlipWork.StockAgentCode = dcStockSlipWork.StockAgentCode;
            stockSlipWork.StockAgentName = dcStockSlipWork.StockAgentName;
            stockSlipWork.SuppTtlAmntDspWayCd = dcStockSlipWork.SuppTtlAmntDspWayCd;
            stockSlipWork.TtlAmntDispRateApy = dcStockSlipWork.TtlAmntDispRateApy;
            stockSlipWork.StockTotalPrice = dcStockSlipWork.StockTotalPrice;
            stockSlipWork.StockSubttlPrice = dcStockSlipWork.StockSubttlPrice;
            stockSlipWork.StockTtlPricTaxInc = dcStockSlipWork.StockTtlPricTaxInc;
            stockSlipWork.StockTtlPricTaxExc = dcStockSlipWork.StockTtlPricTaxExc;
            stockSlipWork.StockNetPrice = dcStockSlipWork.StockNetPrice;
            stockSlipWork.StockPriceConsTax = dcStockSlipWork.StockPriceConsTax;
            stockSlipWork.TtlItdedStcOutTax = dcStockSlipWork.TtlItdedStcOutTax;
            stockSlipWork.TtlItdedStcInTax = dcStockSlipWork.TtlItdedStcInTax;
            stockSlipWork.TtlItdedStcTaxFree = dcStockSlipWork.TtlItdedStcTaxFree;
            stockSlipWork.StockOutTax = dcStockSlipWork.StockOutTax;
            stockSlipWork.StckPrcConsTaxInclu = dcStockSlipWork.StckPrcConsTaxInclu;
            stockSlipWork.StckDisTtlTaxExc = dcStockSlipWork.StckDisTtlTaxExc;
            stockSlipWork.ItdedStockDisOutTax = dcStockSlipWork.ItdedStockDisOutTax;
            stockSlipWork.ItdedStockDisInTax = dcStockSlipWork.ItdedStockDisInTax;
            stockSlipWork.ItdedStockDisTaxFre = dcStockSlipWork.ItdedStockDisTaxFre;
            stockSlipWork.StockDisOutTax = dcStockSlipWork.StockDisOutTax;
            stockSlipWork.StckDisTtlTaxInclu = dcStockSlipWork.StckDisTtlTaxInclu;
            stockSlipWork.TaxAdjust = dcStockSlipWork.TaxAdjust;
            stockSlipWork.BalanceAdjust = dcStockSlipWork.BalanceAdjust;
            stockSlipWork.SuppCTaxLayCd = dcStockSlipWork.SuppCTaxLayCd;
            stockSlipWork.SupplierConsTaxRate = dcStockSlipWork.SupplierConsTaxRate;
            stockSlipWork.AccPayConsTax = dcStockSlipWork.AccPayConsTax;
            stockSlipWork.StockFractionProcCd = dcStockSlipWork.StockFractionProcCd;
            stockSlipWork.AutoPayment = dcStockSlipWork.AutoPayment;
            stockSlipWork.AutoPaySlipNum = dcStockSlipWork.AutoPaySlipNum;
            stockSlipWork.RetGoodsReasonDiv = dcStockSlipWork.RetGoodsReasonDiv;
            stockSlipWork.RetGoodsReason = dcStockSlipWork.RetGoodsReason;
            stockSlipWork.PartySaleSlipNum = dcStockSlipWork.PartySaleSlipNum;
            stockSlipWork.SupplierSlipNote1 = dcStockSlipWork.SupplierSlipNote1;
            stockSlipWork.SupplierSlipNote2 = dcStockSlipWork.SupplierSlipNote2;
            stockSlipWork.DetailRowCount = dcStockSlipWork.DetailRowCount;
            stockSlipWork.EdiSendDate = dcStockSlipWork.EdiSendDate;
            stockSlipWork.EdiTakeInDate = dcStockSlipWork.EdiTakeInDate;
            stockSlipWork.UoeRemark1 = dcStockSlipWork.UoeRemark1;
            stockSlipWork.UoeRemark2 = dcStockSlipWork.UoeRemark2;
            stockSlipWork.SlipPrintDivCd = dcStockSlipWork.SlipPrintDivCd;
            stockSlipWork.SlipPrintFinishCd = dcStockSlipWork.SlipPrintFinishCd;
            stockSlipWork.StockSlipPrintDate = dcStockSlipWork.StockSlipPrintDate;
            stockSlipWork.SlipPrtSetPaperId = dcStockSlipWork.SlipPrtSetPaperId;
            stockSlipWork.SlipAddressDiv = dcStockSlipWork.SlipAddressDiv;
            stockSlipWork.AddresseeCode = dcStockSlipWork.AddresseeCode;
            stockSlipWork.AddresseeName = dcStockSlipWork.AddresseeName;
            stockSlipWork.AddresseeName2 = dcStockSlipWork.AddresseeName2;
            stockSlipWork.AddresseePostNo = dcStockSlipWork.AddresseePostNo;
            stockSlipWork.AddresseeAddr1 = dcStockSlipWork.AddresseeAddr1;
            stockSlipWork.AddresseeAddr3 = dcStockSlipWork.AddresseeAddr3;
            stockSlipWork.AddresseeAddr4 = dcStockSlipWork.AddresseeAddr4;
            stockSlipWork.AddresseeTelNo = dcStockSlipWork.AddresseeTelNo;
            stockSlipWork.AddresseeFaxNo = dcStockSlipWork.AddresseeFaxNo;
            stockSlipWork.DirectSendingCd = dcStockSlipWork.DirectSendingCd;

            return stockSlipWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcStockDetailWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APStockDetailWork SearchDataFromUpdateData(DCStockDetailWork dcStockDetailWork)
        {
            if (dcStockDetailWork == null)
            {
                return null;
            }

            APStockDetailWork stockDetailWork = new APStockDetailWork();

            // 変換
            stockDetailWork.CreateDateTime = dcStockDetailWork.CreateDateTime;
            stockDetailWork.UpdateDateTime = dcStockDetailWork.UpdateDateTime;
            stockDetailWork.EnterpriseCode = dcStockDetailWork.EnterpriseCode;
            stockDetailWork.FileHeaderGuid = dcStockDetailWork.FileHeaderGuid;
            stockDetailWork.UpdEmployeeCode = dcStockDetailWork.UpdEmployeeCode;
            stockDetailWork.UpdAssemblyId1 = dcStockDetailWork.UpdAssemblyId1;
            stockDetailWork.UpdAssemblyId2 = dcStockDetailWork.UpdAssemblyId2;
            stockDetailWork.LogicalDeleteCode = dcStockDetailWork.LogicalDeleteCode;
            stockDetailWork.AcceptAnOrderNo = dcStockDetailWork.AcceptAnOrderNo;
            stockDetailWork.SupplierFormal = dcStockDetailWork.SupplierFormal;
            stockDetailWork.SupplierSlipNo = dcStockDetailWork.SupplierSlipNo;
            stockDetailWork.StockRowNo = dcStockDetailWork.StockRowNo;
            stockDetailWork.SectionCode = dcStockDetailWork.SectionCode;
            stockDetailWork.SubSectionCode = dcStockDetailWork.SubSectionCode;
            stockDetailWork.CommonSeqNo = dcStockDetailWork.CommonSeqNo;
            stockDetailWork.StockSlipDtlNum = dcStockDetailWork.StockSlipDtlNum;
            stockDetailWork.SupplierFormalSrc = dcStockDetailWork.SupplierFormalSrc;
            stockDetailWork.StockSlipDtlNumSrc = dcStockDetailWork.StockSlipDtlNumSrc;
            stockDetailWork.AcptAnOdrStatusSync = dcStockDetailWork.AcptAnOdrStatusSync;
            stockDetailWork.SalesSlipDtlNumSync = dcStockDetailWork.SalesSlipDtlNumSync;
            stockDetailWork.StockSlipCdDtl = dcStockDetailWork.StockSlipCdDtl;
            stockDetailWork.StockInputCode = dcStockDetailWork.StockInputCode;
            stockDetailWork.StockInputName = dcStockDetailWork.StockInputName;
            stockDetailWork.StockAgentCode = dcStockDetailWork.StockAgentCode;
            stockDetailWork.StockAgentName = dcStockDetailWork.StockAgentName;
            stockDetailWork.GoodsKindCode = dcStockDetailWork.GoodsKindCode;
            stockDetailWork.GoodsMakerCd = dcStockDetailWork.GoodsMakerCd;
            stockDetailWork.MakerName = dcStockDetailWork.MakerName;
            stockDetailWork.MakerKanaName = dcStockDetailWork.MakerKanaName;
            stockDetailWork.CmpltMakerKanaName = dcStockDetailWork.CmpltMakerKanaName;
            stockDetailWork.GoodsNo = dcStockDetailWork.GoodsNo;
            stockDetailWork.GoodsName = dcStockDetailWork.GoodsName;
            stockDetailWork.GoodsNameKana = dcStockDetailWork.GoodsNameKana;
            stockDetailWork.GoodsLGroup = dcStockDetailWork.GoodsLGroup;
            stockDetailWork.GoodsLGroupName = dcStockDetailWork.GoodsLGroupName;
            stockDetailWork.GoodsMGroup = dcStockDetailWork.GoodsMGroup;
            stockDetailWork.GoodsMGroupName = dcStockDetailWork.GoodsMGroupName;
            stockDetailWork.BLGroupCode = dcStockDetailWork.BLGroupCode;
            stockDetailWork.BLGroupName = dcStockDetailWork.BLGroupName;
            stockDetailWork.BLGoodsCode = dcStockDetailWork.BLGoodsCode;
            stockDetailWork.BLGoodsFullName = dcStockDetailWork.BLGoodsFullName;
            stockDetailWork.EnterpriseGanreCode = dcStockDetailWork.EnterpriseGanreCode;
            stockDetailWork.EnterpriseGanreName = dcStockDetailWork.EnterpriseGanreName;
            stockDetailWork.WarehouseCode = dcStockDetailWork.WarehouseCode;
            stockDetailWork.WarehouseName = dcStockDetailWork.WarehouseName;
            stockDetailWork.WarehouseShelfNo = dcStockDetailWork.WarehouseShelfNo;
            stockDetailWork.StockOrderDivCd = dcStockDetailWork.StockOrderDivCd;
            stockDetailWork.OpenPriceDiv = dcStockDetailWork.OpenPriceDiv;
            stockDetailWork.GoodsRateRank = dcStockDetailWork.GoodsRateRank;
            stockDetailWork.CustRateGrpCode = dcStockDetailWork.CustRateGrpCode;
            stockDetailWork.SuppRateGrpCode = dcStockDetailWork.SuppRateGrpCode;
            stockDetailWork.ListPriceTaxExcFl = dcStockDetailWork.ListPriceTaxExcFl;
            stockDetailWork.ListPriceTaxIncFl = dcStockDetailWork.ListPriceTaxIncFl;
            stockDetailWork.StockRate = dcStockDetailWork.StockRate;
            stockDetailWork.RateSectStckUnPrc = dcStockDetailWork.RateSectStckUnPrc;
            stockDetailWork.RateDivStckUnPrc = dcStockDetailWork.RateDivStckUnPrc;
            stockDetailWork.UnPrcCalcCdStckUnPrc = dcStockDetailWork.UnPrcCalcCdStckUnPrc;
            stockDetailWork.PriceCdStckUnPrc = dcStockDetailWork.PriceCdStckUnPrc;
            stockDetailWork.StdUnPrcStckUnPrc = dcStockDetailWork.StdUnPrcStckUnPrc;
            stockDetailWork.FracProcUnitStcUnPrc = dcStockDetailWork.FracProcUnitStcUnPrc;
            stockDetailWork.FracProcStckUnPrc = dcStockDetailWork.FracProcStckUnPrc;
            stockDetailWork.StockUnitPriceFl = dcStockDetailWork.StockUnitPriceFl;
            stockDetailWork.StockUnitTaxPriceFl = dcStockDetailWork.StockUnitTaxPriceFl;
            stockDetailWork.StockUnitChngDiv = dcStockDetailWork.StockUnitChngDiv;
            stockDetailWork.BfStockUnitPriceFl = dcStockDetailWork.BfStockUnitPriceFl;
            stockDetailWork.BfListPrice = dcStockDetailWork.BfListPrice;
            stockDetailWork.RateBLGoodsCode = dcStockDetailWork.RateBLGoodsCode;
            stockDetailWork.RateBLGoodsName = dcStockDetailWork.RateBLGoodsName;
            stockDetailWork.RateGoodsRateGrpCd = dcStockDetailWork.RateGoodsRateGrpCd;
            stockDetailWork.RateGoodsRateGrpNm = dcStockDetailWork.RateGoodsRateGrpNm;
            stockDetailWork.RateBLGroupCode = dcStockDetailWork.RateBLGroupCode;
            stockDetailWork.RateBLGroupName = dcStockDetailWork.RateBLGroupName;
            stockDetailWork.StockCount = dcStockDetailWork.StockCount;
            stockDetailWork.OrderCnt = dcStockDetailWork.OrderCnt;
            stockDetailWork.OrderAdjustCnt = dcStockDetailWork.OrderAdjustCnt;
            stockDetailWork.OrderRemainCnt = dcStockDetailWork.OrderRemainCnt;
            stockDetailWork.RemainCntUpdDate = dcStockDetailWork.RemainCntUpdDate;
            stockDetailWork.StockPriceTaxExc = dcStockDetailWork.StockPriceTaxExc;
            stockDetailWork.StockPriceTaxInc = dcStockDetailWork.StockPriceTaxInc;
            stockDetailWork.StockGoodsCd = dcStockDetailWork.StockGoodsCd;
            stockDetailWork.StockPriceConsTax = dcStockDetailWork.StockPriceConsTax;
            stockDetailWork.TaxationCode = dcStockDetailWork.TaxationCode;
            stockDetailWork.StockDtiSlipNote1 = dcStockDetailWork.StockDtiSlipNote1;
            stockDetailWork.SalesCustomerCode = dcStockDetailWork.SalesCustomerCode;
            stockDetailWork.SalesCustomerSnm = dcStockDetailWork.SalesCustomerSnm;
            stockDetailWork.SlipMemo1 = dcStockDetailWork.SlipMemo1;
            stockDetailWork.SlipMemo2 = dcStockDetailWork.SlipMemo2;
            stockDetailWork.SlipMemo3 = dcStockDetailWork.SlipMemo3;
            stockDetailWork.InsideMemo1 = dcStockDetailWork.InsideMemo1;
            stockDetailWork.InsideMemo2 = dcStockDetailWork.InsideMemo2;
            stockDetailWork.InsideMemo3 = dcStockDetailWork.InsideMemo3;
            stockDetailWork.SupplierCd = dcStockDetailWork.SupplierCd;
            stockDetailWork.SupplierSnm = dcStockDetailWork.SupplierSnm;
            stockDetailWork.AddresseeCode = dcStockDetailWork.AddresseeCode;
            stockDetailWork.AddresseeName = dcStockDetailWork.AddresseeName;
            stockDetailWork.DirectSendingCd = dcStockDetailWork.DirectSendingCd;
            stockDetailWork.OrderNumber = dcStockDetailWork.OrderNumber;
            stockDetailWork.WayToOrder = dcStockDetailWork.WayToOrder;
            stockDetailWork.DeliGdsCmpltDueDate = dcStockDetailWork.DeliGdsCmpltDueDate;
            stockDetailWork.ExpectDeliveryDate = dcStockDetailWork.ExpectDeliveryDate;
            stockDetailWork.OrderDataCreateDiv = dcStockDetailWork.OrderDataCreateDiv;
            stockDetailWork.OrderDataCreateDate = dcStockDetailWork.OrderDataCreateDate;
            stockDetailWork.OrderFormIssuedDiv = dcStockDetailWork.OrderFormIssuedDiv;

            return stockDetailWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcStockSlipHistWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APStockSlipHistWork SearchDataFromUpdateData(DCStockSlipHistWork dcStockSlipHistWork)
        {
            if (dcStockSlipHistWork == null)
            {
                return null;
            }

            APStockSlipHistWork stockSlipHistWork = new APStockSlipHistWork();

            // 変換
            stockSlipHistWork.CreateDateTime = dcStockSlipHistWork.CreateDateTime;
            stockSlipHistWork.UpdateDateTime = dcStockSlipHistWork.UpdateDateTime;
            stockSlipHistWork.EnterpriseCode = dcStockSlipHistWork.EnterpriseCode;
            stockSlipHistWork.FileHeaderGuid = dcStockSlipHistWork.FileHeaderGuid;
            stockSlipHistWork.UpdEmployeeCode = dcStockSlipHistWork.UpdEmployeeCode;
            stockSlipHistWork.UpdAssemblyId1 = dcStockSlipHistWork.UpdAssemblyId1;
            stockSlipHistWork.UpdAssemblyId2 = dcStockSlipHistWork.UpdAssemblyId2;
            stockSlipHistWork.LogicalDeleteCode = dcStockSlipHistWork.LogicalDeleteCode;
            stockSlipHistWork.SupplierFormal = dcStockSlipHistWork.SupplierFormal;
            stockSlipHistWork.SupplierSlipNo = dcStockSlipHistWork.SupplierSlipNo;
            stockSlipHistWork.SectionCode = dcStockSlipHistWork.SectionCode;
            stockSlipHistWork.SubSectionCode = dcStockSlipHistWork.SubSectionCode;
            stockSlipHistWork.DebitNoteDiv = dcStockSlipHistWork.DebitNoteDiv;
            stockSlipHistWork.DebitNLnkSuppSlipNo = dcStockSlipHistWork.DebitNLnkSuppSlipNo;
            stockSlipHistWork.SupplierSlipCd = dcStockSlipHistWork.SupplierSlipCd;
            stockSlipHistWork.StockGoodsCd = dcStockSlipHistWork.StockGoodsCd;
            stockSlipHistWork.AccPayDivCd = dcStockSlipHistWork.AccPayDivCd;
            stockSlipHistWork.StockSectionCd = dcStockSlipHistWork.StockSectionCd;
            stockSlipHistWork.StockAddUpSectionCd = dcStockSlipHistWork.StockAddUpSectionCd;
            stockSlipHistWork.StockSlipUpdateCd = dcStockSlipHistWork.StockSlipUpdateCd;
            stockSlipHistWork.InputDay = dcStockSlipHistWork.InputDay;
            stockSlipHistWork.ArrivalGoodsDay = dcStockSlipHistWork.ArrivalGoodsDay;
            stockSlipHistWork.StockDate = dcStockSlipHistWork.StockDate;
            stockSlipHistWork.StockAddUpADate = dcStockSlipHistWork.StockAddUpADate;
            stockSlipHistWork.DelayPaymentDiv = dcStockSlipHistWork.DelayPaymentDiv;
            stockSlipHistWork.PayeeCode = dcStockSlipHistWork.PayeeCode;
            stockSlipHistWork.PayeeSnm = dcStockSlipHistWork.PayeeSnm;
            stockSlipHistWork.SupplierCd = dcStockSlipHistWork.SupplierCd;
            stockSlipHistWork.SupplierNm1 = dcStockSlipHistWork.SupplierNm1;
            stockSlipHistWork.SupplierNm2 = dcStockSlipHistWork.SupplierNm2;
            stockSlipHistWork.SupplierSnm = dcStockSlipHistWork.SupplierSnm;
            stockSlipHistWork.BusinessTypeCode = dcStockSlipHistWork.BusinessTypeCode;
            stockSlipHistWork.BusinessTypeName = dcStockSlipHistWork.BusinessTypeName;
            stockSlipHistWork.SalesAreaCode = dcStockSlipHistWork.SalesAreaCode;
            stockSlipHistWork.SalesAreaName = dcStockSlipHistWork.SalesAreaName;
            stockSlipHistWork.StockInputCode = dcStockSlipHistWork.StockInputCode;
            stockSlipHistWork.StockInputName = dcStockSlipHistWork.StockInputName;
            stockSlipHistWork.StockAgentCode = dcStockSlipHistWork.StockAgentCode;
            stockSlipHistWork.StockAgentName = dcStockSlipHistWork.StockAgentName;
            stockSlipHistWork.SuppTtlAmntDspWayCd = dcStockSlipHistWork.SuppTtlAmntDspWayCd;
            stockSlipHistWork.TtlAmntDispRateApy = dcStockSlipHistWork.TtlAmntDispRateApy;
            stockSlipHistWork.StockTotalPrice = dcStockSlipHistWork.StockTotalPrice;
            stockSlipHistWork.StockSubttlPrice = dcStockSlipHistWork.StockSubttlPrice;
            stockSlipHistWork.StockTtlPricTaxInc = dcStockSlipHistWork.StockTtlPricTaxInc;
            stockSlipHistWork.StockTtlPricTaxExc = dcStockSlipHistWork.StockTtlPricTaxExc;
            stockSlipHistWork.StockNetPrice = dcStockSlipHistWork.StockNetPrice;
            stockSlipHistWork.StockPriceConsTax = dcStockSlipHistWork.StockPriceConsTax;
            stockSlipHistWork.TtlItdedStcOutTax = dcStockSlipHistWork.TtlItdedStcOutTax;
            stockSlipHistWork.TtlItdedStcInTax = dcStockSlipHistWork.TtlItdedStcInTax;
            stockSlipHistWork.TtlItdedStcTaxFree = dcStockSlipHistWork.TtlItdedStcTaxFree;
            stockSlipHistWork.StockOutTax = dcStockSlipHistWork.StockOutTax;
            stockSlipHistWork.StckPrcConsTaxInclu = dcStockSlipHistWork.StckPrcConsTaxInclu;
            stockSlipHistWork.StckDisTtlTaxExc = dcStockSlipHistWork.StckDisTtlTaxExc;
            stockSlipHistWork.ItdedStockDisOutTax = dcStockSlipHistWork.ItdedStockDisOutTax;
            stockSlipHistWork.ItdedStockDisInTax = dcStockSlipHistWork.ItdedStockDisInTax;
            stockSlipHistWork.ItdedStockDisTaxFre = dcStockSlipHistWork.ItdedStockDisTaxFre;
            stockSlipHistWork.StockDisOutTax = dcStockSlipHistWork.StockDisOutTax;
            stockSlipHistWork.StckDisTtlTaxInclu = dcStockSlipHistWork.StckDisTtlTaxInclu;
            stockSlipHistWork.TaxAdjust = dcStockSlipHistWork.TaxAdjust;
            stockSlipHistWork.BalanceAdjust = dcStockSlipHistWork.BalanceAdjust;
            stockSlipHistWork.SuppCTaxLayCd = dcStockSlipHistWork.SuppCTaxLayCd;
            stockSlipHistWork.SupplierConsTaxRate = dcStockSlipHistWork.SupplierConsTaxRate;
            stockSlipHistWork.AccPayConsTax = dcStockSlipHistWork.AccPayConsTax;
            stockSlipHistWork.StockFractionProcCd = dcStockSlipHistWork.StockFractionProcCd;
            stockSlipHistWork.AutoPayment = dcStockSlipHistWork.AutoPayment;
            stockSlipHistWork.AutoPaySlipNum = dcStockSlipHistWork.AutoPaySlipNum;
            stockSlipHistWork.RetGoodsReasonDiv = dcStockSlipHistWork.RetGoodsReasonDiv;
            stockSlipHistWork.RetGoodsReason = dcStockSlipHistWork.RetGoodsReason;
            stockSlipHistWork.PartySaleSlipNum = dcStockSlipHistWork.PartySaleSlipNum;
            stockSlipHistWork.SupplierSlipNote1 = dcStockSlipHistWork.SupplierSlipNote1;
            stockSlipHistWork.SupplierSlipNote2 = dcStockSlipHistWork.SupplierSlipNote2;
            stockSlipHistWork.DetailRowCount = dcStockSlipHistWork.DetailRowCount;
            stockSlipHistWork.EdiSendDate = dcStockSlipHistWork.EdiSendDate;
            stockSlipHistWork.EdiTakeInDate = dcStockSlipHistWork.EdiTakeInDate;
            stockSlipHistWork.UoeRemark1 = dcStockSlipHistWork.UoeRemark1;
            stockSlipHistWork.UoeRemark2 = dcStockSlipHistWork.UoeRemark2;
            stockSlipHistWork.SlipPrintDivCd = dcStockSlipHistWork.SlipPrintDivCd;
            stockSlipHistWork.SlipPrintFinishCd = dcStockSlipHistWork.SlipPrintFinishCd;
            stockSlipHistWork.StockSlipPrintDate = dcStockSlipHistWork.StockSlipPrintDate;
            stockSlipHistWork.SlipPrtSetPaperId = dcStockSlipHistWork.SlipPrtSetPaperId;

            return stockSlipHistWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcStockSlHistDtlWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APStockSlHistDtlWork SearchDataFromUpdateData(DCStockSlHistDtlWork dcStockSlHistDtlWork)
        {
            if (dcStockSlHistDtlWork == null)
            {
                return null;
            }

            APStockSlHistDtlWork stockSlHistDtlWork = new APStockSlHistDtlWork();

            // 変換
            stockSlHistDtlWork.CreateDateTime = dcStockSlHistDtlWork.CreateDateTime;
            stockSlHistDtlWork.UpdateDateTime = dcStockSlHistDtlWork.UpdateDateTime;
            stockSlHistDtlWork.EnterpriseCode = dcStockSlHistDtlWork.EnterpriseCode;
            stockSlHistDtlWork.FileHeaderGuid = dcStockSlHistDtlWork.FileHeaderGuid;
            stockSlHistDtlWork.UpdEmployeeCode = dcStockSlHistDtlWork.UpdEmployeeCode;
            stockSlHistDtlWork.UpdAssemblyId1 = dcStockSlHistDtlWork.UpdAssemblyId1;
            stockSlHistDtlWork.UpdAssemblyId2 = dcStockSlHistDtlWork.UpdAssemblyId2;
            stockSlHistDtlWork.LogicalDeleteCode = dcStockSlHistDtlWork.LogicalDeleteCode;
            stockSlHistDtlWork.AcceptAnOrderNo = dcStockSlHistDtlWork.AcceptAnOrderNo;
            stockSlHistDtlWork.SupplierFormal = dcStockSlHistDtlWork.SupplierFormal;
            stockSlHistDtlWork.SupplierSlipNo = dcStockSlHistDtlWork.SupplierSlipNo;
            stockSlHistDtlWork.StockRowNo = dcStockSlHistDtlWork.StockRowNo;
            stockSlHistDtlWork.SectionCode = dcStockSlHistDtlWork.SectionCode;
            stockSlHistDtlWork.SubSectionCode = dcStockSlHistDtlWork.SubSectionCode;
            stockSlHistDtlWork.CommonSeqNo = dcStockSlHistDtlWork.CommonSeqNo;
            stockSlHistDtlWork.StockSlipDtlNum = dcStockSlHistDtlWork.StockSlipDtlNum;
            stockSlHistDtlWork.SupplierFormalSrc = dcStockSlHistDtlWork.SupplierFormalSrc;
            stockSlHistDtlWork.StockSlipDtlNumSrc = dcStockSlHistDtlWork.StockSlipDtlNumSrc;
            stockSlHistDtlWork.AcptAnOdrStatusSync = dcStockSlHistDtlWork.AcptAnOdrStatusSync;
            stockSlHistDtlWork.SalesSlipDtlNumSync = dcStockSlHistDtlWork.SalesSlipDtlNumSync;
            stockSlHistDtlWork.StockSlipCdDtl = dcStockSlHistDtlWork.StockSlipCdDtl;
            stockSlHistDtlWork.StockAgentCode = dcStockSlHistDtlWork.StockAgentCode;
            stockSlHistDtlWork.StockAgentName = dcStockSlHistDtlWork.StockAgentName;
            stockSlHistDtlWork.GoodsKindCode = dcStockSlHistDtlWork.GoodsKindCode;
            stockSlHistDtlWork.GoodsMakerCd = dcStockSlHistDtlWork.GoodsMakerCd;
            stockSlHistDtlWork.MakerName = dcStockSlHistDtlWork.MakerName;
            stockSlHistDtlWork.MakerKanaName = dcStockSlHistDtlWork.MakerKanaName;
            stockSlHistDtlWork.CmpltMakerKanaName = dcStockSlHistDtlWork.CmpltMakerKanaName;
            stockSlHistDtlWork.GoodsNo = dcStockSlHistDtlWork.GoodsNo;
            stockSlHistDtlWork.GoodsName = dcStockSlHistDtlWork.GoodsName;
            stockSlHistDtlWork.GoodsNameKana = dcStockSlHistDtlWork.GoodsNameKana;
            stockSlHistDtlWork.GoodsLGroup = dcStockSlHistDtlWork.GoodsLGroup;
            stockSlHistDtlWork.GoodsLGroupName = dcStockSlHistDtlWork.GoodsLGroupName;
            stockSlHistDtlWork.GoodsMGroup = dcStockSlHistDtlWork.GoodsMGroup;
            stockSlHistDtlWork.GoodsMGroupName = dcStockSlHistDtlWork.GoodsMGroupName;
            stockSlHistDtlWork.BLGroupCode = dcStockSlHistDtlWork.BLGroupCode;
            stockSlHistDtlWork.BLGroupName = dcStockSlHistDtlWork.BLGroupName;
            stockSlHistDtlWork.BLGoodsCode = dcStockSlHistDtlWork.BLGoodsCode;
            stockSlHistDtlWork.BLGoodsFullName = dcStockSlHistDtlWork.BLGoodsFullName;
            stockSlHistDtlWork.EnterpriseGanreCode = dcStockSlHistDtlWork.EnterpriseGanreCode;
            stockSlHistDtlWork.EnterpriseGanreName = dcStockSlHistDtlWork.EnterpriseGanreName;
            stockSlHistDtlWork.WarehouseCode = dcStockSlHistDtlWork.WarehouseCode;
            stockSlHistDtlWork.WarehouseName = dcStockSlHistDtlWork.WarehouseName;
            stockSlHistDtlWork.WarehouseShelfNo = dcStockSlHistDtlWork.WarehouseShelfNo;
            stockSlHistDtlWork.StockOrderDivCd = dcStockSlHistDtlWork.StockOrderDivCd;
            stockSlHistDtlWork.OpenPriceDiv = dcStockSlHistDtlWork.OpenPriceDiv;
            stockSlHistDtlWork.GoodsRateRank = dcStockSlHistDtlWork.GoodsRateRank;
            stockSlHistDtlWork.CustRateGrpCode = dcStockSlHistDtlWork.CustRateGrpCode;
            stockSlHistDtlWork.SuppRateGrpCode = dcStockSlHistDtlWork.SuppRateGrpCode;
            stockSlHistDtlWork.ListPriceTaxExcFl = dcStockSlHistDtlWork.ListPriceTaxExcFl;
            stockSlHistDtlWork.ListPriceTaxIncFl = dcStockSlHistDtlWork.ListPriceTaxIncFl;
            stockSlHistDtlWork.StockRate = dcStockSlHistDtlWork.StockRate;
            stockSlHistDtlWork.RateSectStckUnPrc = dcStockSlHistDtlWork.RateSectStckUnPrc;
            stockSlHistDtlWork.RateDivStckUnPrc = dcStockSlHistDtlWork.RateDivStckUnPrc;
            stockSlHistDtlWork.UnPrcCalcCdStckUnPrc = dcStockSlHistDtlWork.UnPrcCalcCdStckUnPrc;
            stockSlHistDtlWork.PriceCdStckUnPrc = dcStockSlHistDtlWork.PriceCdStckUnPrc;
            stockSlHistDtlWork.StdUnPrcStckUnPrc = dcStockSlHistDtlWork.StdUnPrcStckUnPrc;
            stockSlHistDtlWork.FracProcUnitStcUnPrc = dcStockSlHistDtlWork.FracProcUnitStcUnPrc;
            stockSlHistDtlWork.FracProcStckUnPrc = dcStockSlHistDtlWork.FracProcStckUnPrc;
            stockSlHistDtlWork.StockUnitPriceFl = dcStockSlHistDtlWork.StockUnitPriceFl;
            stockSlHistDtlWork.StockUnitTaxPriceFl = dcStockSlHistDtlWork.StockUnitTaxPriceFl;
            stockSlHistDtlWork.StockUnitChngDiv = dcStockSlHistDtlWork.StockUnitChngDiv;
            stockSlHistDtlWork.BfStockUnitPriceFl = dcStockSlHistDtlWork.BfStockUnitPriceFl;
            stockSlHistDtlWork.BfListPrice = dcStockSlHistDtlWork.BfListPrice;
            stockSlHistDtlWork.RateBLGoodsCode = dcStockSlHistDtlWork.RateBLGoodsCode;
            stockSlHistDtlWork.RateBLGoodsName = dcStockSlHistDtlWork.RateBLGoodsName;
            stockSlHistDtlWork.RateGoodsRateGrpCd = dcStockSlHistDtlWork.RateGoodsRateGrpCd;
            stockSlHistDtlWork.RateGoodsRateGrpNm = dcStockSlHistDtlWork.RateGoodsRateGrpNm;
            stockSlHistDtlWork.RateBLGroupCode = dcStockSlHistDtlWork.RateBLGroupCode;
            stockSlHistDtlWork.RateBLGroupName = dcStockSlHistDtlWork.RateBLGroupName;
            stockSlHistDtlWork.StockCount = dcStockSlHistDtlWork.StockCount;
            stockSlHistDtlWork.StockPriceTaxExc = dcStockSlHistDtlWork.StockPriceTaxExc;
            stockSlHistDtlWork.StockPriceTaxInc = dcStockSlHistDtlWork.StockPriceTaxInc;
            stockSlHistDtlWork.StockGoodsCd = dcStockSlHistDtlWork.StockGoodsCd;
            stockSlHistDtlWork.StockPriceConsTax = dcStockSlHistDtlWork.StockPriceConsTax;
            stockSlHistDtlWork.TaxationCode = dcStockSlHistDtlWork.TaxationCode;
            stockSlHistDtlWork.StockDtiSlipNote1 = dcStockSlHistDtlWork.StockDtiSlipNote1;
            stockSlHistDtlWork.SalesCustomerCode = dcStockSlHistDtlWork.SalesCustomerCode;
            stockSlHistDtlWork.SalesCustomerSnm = dcStockSlHistDtlWork.SalesCustomerSnm;
            stockSlHistDtlWork.OrderNumber = dcStockSlHistDtlWork.OrderNumber;
            stockSlHistDtlWork.SlipMemo1 = dcStockSlHistDtlWork.SlipMemo1;
            stockSlHistDtlWork.SlipMemo2 = dcStockSlHistDtlWork.SlipMemo2;
            stockSlHistDtlWork.SlipMemo3 = dcStockSlHistDtlWork.SlipMemo3;
            stockSlHistDtlWork.InsideMemo1 = dcStockSlHistDtlWork.InsideMemo1;
            stockSlHistDtlWork.InsideMemo2 = dcStockSlHistDtlWork.InsideMemo2;
            stockSlHistDtlWork.InsideMemo3 = dcStockSlHistDtlWork.InsideMemo3;

            return stockSlHistDtlWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcPaymentSlpWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APPaymentSlpWork SearchDataFromUpdateData(DCPaymentSlpWork dcPaymentSlpWork)
        {
            if (dcPaymentSlpWork == null)
            {
                return null;
            }

            APPaymentSlpWork paymentSlpWork = new APPaymentSlpWork();

            // 変換
            paymentSlpWork.CreateDateTime = dcPaymentSlpWork.CreateDateTime;
            paymentSlpWork.UpdateDateTime = dcPaymentSlpWork.UpdateDateTime;
            paymentSlpWork.EnterpriseCode = dcPaymentSlpWork.EnterpriseCode;
            paymentSlpWork.FileHeaderGuid = dcPaymentSlpWork.FileHeaderGuid;
            paymentSlpWork.UpdEmployeeCode = dcPaymentSlpWork.UpdEmployeeCode;
            paymentSlpWork.UpdAssemblyId1 = dcPaymentSlpWork.UpdAssemblyId1;
            paymentSlpWork.UpdAssemblyId2 = dcPaymentSlpWork.UpdAssemblyId2;
            paymentSlpWork.LogicalDeleteCode = dcPaymentSlpWork.LogicalDeleteCode;
            paymentSlpWork.DebitNoteDiv = dcPaymentSlpWork.DebitNoteDiv;
            paymentSlpWork.PaymentSlipNo = dcPaymentSlpWork.PaymentSlipNo;
            paymentSlpWork.SupplierFormal = dcPaymentSlpWork.SupplierFormal;
            paymentSlpWork.SupplierSlipNo = dcPaymentSlpWork.SupplierSlipNo;
            paymentSlpWork.SupplierCd = dcPaymentSlpWork.SupplierCd;
            paymentSlpWork.SupplierNm1 = dcPaymentSlpWork.SupplierNm1;
            paymentSlpWork.SupplierNm2 = dcPaymentSlpWork.SupplierNm2;
            paymentSlpWork.SupplierSnm = dcPaymentSlpWork.SupplierSnm;
            paymentSlpWork.PayeeCode = dcPaymentSlpWork.PayeeCode;
            paymentSlpWork.PayeeName = dcPaymentSlpWork.PayeeName;
            paymentSlpWork.PayeeName2 = dcPaymentSlpWork.PayeeName2;
            paymentSlpWork.PayeeSnm = dcPaymentSlpWork.PayeeSnm;
            paymentSlpWork.PaymentInpSectionCd = dcPaymentSlpWork.PaymentInpSectionCd;
            paymentSlpWork.AddUpSecCode = dcPaymentSlpWork.AddUpSecCode;
            paymentSlpWork.UpdateSecCd = dcPaymentSlpWork.UpdateSecCd;
            paymentSlpWork.SubSectionCode = dcPaymentSlpWork.SubSectionCode;
            paymentSlpWork.InputDay = dcPaymentSlpWork.InputDay;
            paymentSlpWork.PaymentDate = dcPaymentSlpWork.PaymentDate;
            paymentSlpWork.AddUpADate = dcPaymentSlpWork.AddUpADate;
            paymentSlpWork.PaymentTotal = dcPaymentSlpWork.PaymentTotal;
            paymentSlpWork.Payment = dcPaymentSlpWork.Payment;
            paymentSlpWork.FeePayment = dcPaymentSlpWork.FeePayment;
            paymentSlpWork.DiscountPayment = dcPaymentSlpWork.DiscountPayment;
            paymentSlpWork.AutoPayment = dcPaymentSlpWork.AutoPayment;
            paymentSlpWork.DraftDrawingDate = dcPaymentSlpWork.DraftDrawingDate;
            paymentSlpWork.DraftKind = dcPaymentSlpWork.DraftKind;
            paymentSlpWork.DraftKindName = dcPaymentSlpWork.DraftKindName;
            paymentSlpWork.DraftDivide = dcPaymentSlpWork.DraftDivide;
            paymentSlpWork.DraftDivideName = dcPaymentSlpWork.DraftDivideName;
            paymentSlpWork.DraftNo = dcPaymentSlpWork.DraftNo;
            paymentSlpWork.DebitNoteLinkPayNo = dcPaymentSlpWork.DebitNoteLinkPayNo;
            paymentSlpWork.PaymentAgentCode = dcPaymentSlpWork.PaymentAgentCode;
            paymentSlpWork.PaymentAgentName = dcPaymentSlpWork.PaymentAgentName;
            paymentSlpWork.PaymentInputAgentCd = dcPaymentSlpWork.PaymentInputAgentCd;
            paymentSlpWork.PaymentInputAgentNm = dcPaymentSlpWork.PaymentInputAgentNm;
            paymentSlpWork.Outline = dcPaymentSlpWork.Outline;
            paymentSlpWork.BankCode = dcPaymentSlpWork.BankCode;
            paymentSlpWork.BankName = dcPaymentSlpWork.BankName;

            return paymentSlpWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcPaymentDtlWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APPaymentDtlWork SearchDataFromUpdateData(DCPaymentDtlWork dcPaymentDtlWork)
        {
            if (dcPaymentDtlWork == null)
            {
                return null;
            }

            APPaymentDtlWork paymentDtlWork = new APPaymentDtlWork();

            // 変換
            paymentDtlWork.CreateDateTime = dcPaymentDtlWork.CreateDateTime;
            paymentDtlWork.UpdateDateTime = dcPaymentDtlWork.UpdateDateTime;
            paymentDtlWork.EnterpriseCode = dcPaymentDtlWork.EnterpriseCode;
            paymentDtlWork.FileHeaderGuid = dcPaymentDtlWork.FileHeaderGuid;
            paymentDtlWork.UpdEmployeeCode = dcPaymentDtlWork.UpdEmployeeCode;
            paymentDtlWork.UpdAssemblyId1 = dcPaymentDtlWork.UpdAssemblyId1;
            paymentDtlWork.UpdAssemblyId2 = dcPaymentDtlWork.UpdAssemblyId2;
            paymentDtlWork.LogicalDeleteCode = dcPaymentDtlWork.LogicalDeleteCode;
            paymentDtlWork.SupplierFormal = dcPaymentDtlWork.SupplierFormal;
            paymentDtlWork.PaymentSlipNo = dcPaymentDtlWork.PaymentSlipNo;
            paymentDtlWork.PaymentRowNo = dcPaymentDtlWork.PaymentRowNo;
            paymentDtlWork.MoneyKindCode = dcPaymentDtlWork.MoneyKindCode;
            paymentDtlWork.MoneyKindName = dcPaymentDtlWork.MoneyKindName;
            paymentDtlWork.MoneyKindDiv = dcPaymentDtlWork.MoneyKindDiv;
            paymentDtlWork.Payment = dcPaymentDtlWork.Payment;
            paymentDtlWork.ValidityTerm = dcPaymentDtlWork.ValidityTerm;

            return paymentDtlWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcAcceptOdrWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APAcceptOdrWork SearchDataFromUpdateData(DCAcceptOdrWork dcAcceptOdrWork)
        {
            if (dcAcceptOdrWork == null)
            {
                return null;
            }

            APAcceptOdrWork acceptOdrWork = new APAcceptOdrWork();

            // 変換
            acceptOdrWork.CreateDateTime = dcAcceptOdrWork.CreateDateTime;
            acceptOdrWork.UpdateDateTime = dcAcceptOdrWork.UpdateDateTime;
            acceptOdrWork.EnterpriseCode = dcAcceptOdrWork.EnterpriseCode;
            acceptOdrWork.FileHeaderGuid = dcAcceptOdrWork.FileHeaderGuid;
            acceptOdrWork.UpdEmployeeCode = dcAcceptOdrWork.UpdEmployeeCode;
            acceptOdrWork.UpdAssemblyId1 = dcAcceptOdrWork.UpdAssemblyId1;
            acceptOdrWork.UpdAssemblyId2 = dcAcceptOdrWork.UpdAssemblyId2;
            acceptOdrWork.LogicalDeleteCode = dcAcceptOdrWork.LogicalDeleteCode;
            acceptOdrWork.SectionCode = dcAcceptOdrWork.SectionCode;
            acceptOdrWork.AcceptAnOrderNo = dcAcceptOdrWork.AcceptAnOrderNo;
            acceptOdrWork.AcptAnOdrStatus = dcAcceptOdrWork.AcptAnOdrStatus;
            acceptOdrWork.SalesSlipNum = dcAcceptOdrWork.SalesSlipNum;
            acceptOdrWork.DataInputSystem = dcAcceptOdrWork.DataInputSystem;
            acceptOdrWork.CommonSeqNo = dcAcceptOdrWork.CommonSeqNo;
            acceptOdrWork.SlipDtlNum = dcAcceptOdrWork.SlipDtlNum;
            acceptOdrWork.SlipDtlNumDerivNo = dcAcceptOdrWork.SlipDtlNumDerivNo;
            acceptOdrWork.SrcLinkDataCode = dcAcceptOdrWork.SrcLinkDataCode;
            acceptOdrWork.SrcSlipDtlNum = dcAcceptOdrWork.SrcSlipDtlNum;

            return acceptOdrWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcAcceptOdrCarWork">データワーククラス</param>
        /// <br>Update Note: 2009/09/08 黄偉兵 受注マスタ（車両）に車輌備考の追加</br>
        /// <returns>データクラス</returns>
        /// <br>Update Note: SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/03/22</br>
        public static APAcceptOdrCarWork SearchDataFromUpdateData(DCAcceptOdrCarWork dcAcceptOdrCarWork)
        {
            if (dcAcceptOdrCarWork == null)
            {
                return null;
            }

            APAcceptOdrCarWork acceptOdrCarWork = new APAcceptOdrCarWork();

            // 変換
            acceptOdrCarWork.CreateDateTime = dcAcceptOdrCarWork.CreateDateTime;
            acceptOdrCarWork.UpdateDateTime = dcAcceptOdrCarWork.UpdateDateTime;
            acceptOdrCarWork.EnterpriseCode = dcAcceptOdrCarWork.EnterpriseCode;
            acceptOdrCarWork.FileHeaderGuid = dcAcceptOdrCarWork.FileHeaderGuid;
            acceptOdrCarWork.UpdEmployeeCode = dcAcceptOdrCarWork.UpdEmployeeCode;
            acceptOdrCarWork.UpdAssemblyId1 = dcAcceptOdrCarWork.UpdAssemblyId1;
            acceptOdrCarWork.UpdAssemblyId2 = dcAcceptOdrCarWork.UpdAssemblyId2;
            acceptOdrCarWork.LogicalDeleteCode = dcAcceptOdrCarWork.LogicalDeleteCode;
            acceptOdrCarWork.AcceptAnOrderNo = dcAcceptOdrCarWork.AcceptAnOrderNo;
            acceptOdrCarWork.AcptAnOdrStatus = dcAcceptOdrCarWork.AcptAnOdrStatus;
            acceptOdrCarWork.DataInputSystem = dcAcceptOdrCarWork.DataInputSystem;
            acceptOdrCarWork.CarMngNo = dcAcceptOdrCarWork.CarMngNo;
            acceptOdrCarWork.CarMngCode = dcAcceptOdrCarWork.CarMngCode;
            acceptOdrCarWork.NumberPlate1Code = dcAcceptOdrCarWork.NumberPlate1Code;
            acceptOdrCarWork.NumberPlate1Name = dcAcceptOdrCarWork.NumberPlate1Name;
            acceptOdrCarWork.NumberPlate2 = dcAcceptOdrCarWork.NumberPlate2;
            acceptOdrCarWork.NumberPlate3 = dcAcceptOdrCarWork.NumberPlate3;
            acceptOdrCarWork.NumberPlate4 = dcAcceptOdrCarWork.NumberPlate4;
            acceptOdrCarWork.FirstEntryDate = dcAcceptOdrCarWork.FirstEntryDate;
            acceptOdrCarWork.MakerCode = dcAcceptOdrCarWork.MakerCode;
            acceptOdrCarWork.MakerFullName = dcAcceptOdrCarWork.MakerFullName;
            acceptOdrCarWork.MakerHalfName = dcAcceptOdrCarWork.MakerHalfName;
            acceptOdrCarWork.ModelCode = dcAcceptOdrCarWork.ModelCode;
            acceptOdrCarWork.ModelSubCode = dcAcceptOdrCarWork.ModelSubCode;
            acceptOdrCarWork.ModelFullName = dcAcceptOdrCarWork.ModelFullName;
            acceptOdrCarWork.ModelHalfName = dcAcceptOdrCarWork.ModelHalfName;
            acceptOdrCarWork.ExhaustGasSign = dcAcceptOdrCarWork.ExhaustGasSign;
            acceptOdrCarWork.SeriesModel = dcAcceptOdrCarWork.SeriesModel;
            acceptOdrCarWork.CategorySignModel = dcAcceptOdrCarWork.CategorySignModel;
            acceptOdrCarWork.FullModel = dcAcceptOdrCarWork.FullModel;
            acceptOdrCarWork.ModelDesignationNo = dcAcceptOdrCarWork.ModelDesignationNo;
            acceptOdrCarWork.CategoryNo = dcAcceptOdrCarWork.CategoryNo;
            acceptOdrCarWork.FrameModel = dcAcceptOdrCarWork.FrameModel;
            acceptOdrCarWork.FrameNo = dcAcceptOdrCarWork.FrameNo;
            acceptOdrCarWork.SearchFrameNo = dcAcceptOdrCarWork.SearchFrameNo;
            acceptOdrCarWork.EngineModelNm = dcAcceptOdrCarWork.EngineModelNm;
            acceptOdrCarWork.RelevanceModel = dcAcceptOdrCarWork.RelevanceModel;
            acceptOdrCarWork.SubCarNmCd = dcAcceptOdrCarWork.SubCarNmCd;
            acceptOdrCarWork.ModelGradeSname = dcAcceptOdrCarWork.ModelGradeSname;
            acceptOdrCarWork.ColorCode = dcAcceptOdrCarWork.ColorCode;
            acceptOdrCarWork.ColorName1 = dcAcceptOdrCarWork.ColorName1;
            acceptOdrCarWork.TrimCode = dcAcceptOdrCarWork.TrimCode;
            acceptOdrCarWork.TrimName = dcAcceptOdrCarWork.TrimName;
            acceptOdrCarWork.Mileage = dcAcceptOdrCarWork.Mileage;
            acceptOdrCarWork.FullModelFixedNoAry = dcAcceptOdrCarWork.FullModelFixedNoAry;
            acceptOdrCarWork.CategoryObjAry = dcAcceptOdrCarWork.CategoryObjAry;
            acceptOdrCarWork.CarNote = dcAcceptOdrCarWork.CarNote; // ADD 2009/09/08
            acceptOdrCarWork.DomesticForeignCode = dcAcceptOdrCarWork.DomesticForeignCode; // ADD 2013/03/22

            return acceptOdrCarWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcMTtlSalesSlipWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APMTtlSalesSlipWork SearchDataFromUpdateData(DCMTtlSalesSlipWork dcMTtlSalesSlipWork)
        {
            if (dcMTtlSalesSlipWork == null)
            {
                return null;
            }

            APMTtlSalesSlipWork mTtlSalesSlipWork = new APMTtlSalesSlipWork();

            // 変換
            mTtlSalesSlipWork.CreateDateTime = dcMTtlSalesSlipWork.CreateDateTime;
            mTtlSalesSlipWork.UpdateDateTime = dcMTtlSalesSlipWork.UpdateDateTime;
            mTtlSalesSlipWork.EnterpriseCode = dcMTtlSalesSlipWork.EnterpriseCode;
            mTtlSalesSlipWork.FileHeaderGuid = dcMTtlSalesSlipWork.FileHeaderGuid;
            mTtlSalesSlipWork.UpdEmployeeCode = dcMTtlSalesSlipWork.UpdEmployeeCode;
            mTtlSalesSlipWork.UpdAssemblyId1 = dcMTtlSalesSlipWork.UpdAssemblyId1;
            mTtlSalesSlipWork.UpdAssemblyId2 = dcMTtlSalesSlipWork.UpdAssemblyId2;
            mTtlSalesSlipWork.LogicalDeleteCode = dcMTtlSalesSlipWork.LogicalDeleteCode;
            mTtlSalesSlipWork.AddUpSecCode = dcMTtlSalesSlipWork.AddUpSecCode;
            mTtlSalesSlipWork.AddUpYearMonth = dcMTtlSalesSlipWork.AddUpYearMonth;
            mTtlSalesSlipWork.RsltTtlDivCd = dcMTtlSalesSlipWork.RsltTtlDivCd;
            mTtlSalesSlipWork.EmployeeDivCd = dcMTtlSalesSlipWork.EmployeeDivCd;
            mTtlSalesSlipWork.EmployeeCode = dcMTtlSalesSlipWork.EmployeeCode;
            mTtlSalesSlipWork.CustomerCode = dcMTtlSalesSlipWork.CustomerCode;
            mTtlSalesSlipWork.SupplierCd = dcMTtlSalesSlipWork.SupplierCd;
            mTtlSalesSlipWork.SalesCode = dcMTtlSalesSlipWork.SalesCode;
            mTtlSalesSlipWork.SalesTimes = dcMTtlSalesSlipWork.SalesTimes;
            mTtlSalesSlipWork.TotalSalesCount = dcMTtlSalesSlipWork.TotalSalesCount;
            mTtlSalesSlipWork.SalesMoney = dcMTtlSalesSlipWork.SalesMoney;
            mTtlSalesSlipWork.SalesRetGoodsPrice = dcMTtlSalesSlipWork.SalesRetGoodsPrice;
            mTtlSalesSlipWork.DiscountPrice = dcMTtlSalesSlipWork.DiscountPrice;
            mTtlSalesSlipWork.GrossProfit = dcMTtlSalesSlipWork.GrossProfit;

            return mTtlSalesSlipWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcGoodsMTtlSaSlipWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APGoodsMTtlSaSlipWork SearchDataFromUpdateData(DCGoodsMTtlSaSlipWork dcGoodsMTtlSaSlipWork)
        {
            if (dcGoodsMTtlSaSlipWork == null)
            {
                return null;
            }

            APGoodsMTtlSaSlipWork goodsMTtlSaSlipWork = new APGoodsMTtlSaSlipWork();

            // 変換
            goodsMTtlSaSlipWork.CreateDateTime = dcGoodsMTtlSaSlipWork.CreateDateTime;
            goodsMTtlSaSlipWork.UpdateDateTime = dcGoodsMTtlSaSlipWork.UpdateDateTime;
            goodsMTtlSaSlipWork.EnterpriseCode = dcGoodsMTtlSaSlipWork.EnterpriseCode;
            goodsMTtlSaSlipWork.FileHeaderGuid = dcGoodsMTtlSaSlipWork.FileHeaderGuid;
            goodsMTtlSaSlipWork.UpdEmployeeCode = dcGoodsMTtlSaSlipWork.UpdEmployeeCode;
            goodsMTtlSaSlipWork.UpdAssemblyId1 = dcGoodsMTtlSaSlipWork.UpdAssemblyId1;
            goodsMTtlSaSlipWork.UpdAssemblyId2 = dcGoodsMTtlSaSlipWork.UpdAssemblyId2;
            goodsMTtlSaSlipWork.LogicalDeleteCode = dcGoodsMTtlSaSlipWork.LogicalDeleteCode;
            goodsMTtlSaSlipWork.AddUpSecCode = dcGoodsMTtlSaSlipWork.AddUpSecCode;
            goodsMTtlSaSlipWork.AddUpYearMonth = dcGoodsMTtlSaSlipWork.AddUpYearMonth;
            goodsMTtlSaSlipWork.RsltTtlDivCd = dcGoodsMTtlSaSlipWork.RsltTtlDivCd;
            goodsMTtlSaSlipWork.EmployeeCode = dcGoodsMTtlSaSlipWork.EmployeeCode;
            goodsMTtlSaSlipWork.CustomerCode = dcGoodsMTtlSaSlipWork.CustomerCode;
            goodsMTtlSaSlipWork.BLGoodsCode = dcGoodsMTtlSaSlipWork.BLGoodsCode;
            goodsMTtlSaSlipWork.GoodsMakerCd = dcGoodsMTtlSaSlipWork.GoodsMakerCd;
            goodsMTtlSaSlipWork.GoodsNo = dcGoodsMTtlSaSlipWork.GoodsNo;
            goodsMTtlSaSlipWork.SupplierCd = dcGoodsMTtlSaSlipWork.SupplierCd;
            goodsMTtlSaSlipWork.SalesTimes = dcGoodsMTtlSaSlipWork.SalesTimes;
            goodsMTtlSaSlipWork.TotalSalesCount = dcGoodsMTtlSaSlipWork.TotalSalesCount;
            goodsMTtlSaSlipWork.SalesMoney = dcGoodsMTtlSaSlipWork.SalesMoney;
            goodsMTtlSaSlipWork.SalesRetGoodsPrice = dcGoodsMTtlSaSlipWork.SalesRetGoodsPrice;
            goodsMTtlSaSlipWork.DiscountPrice = dcGoodsMTtlSaSlipWork.DiscountPrice;
            goodsMTtlSaSlipWork.GrossProfit = dcGoodsMTtlSaSlipWork.GrossProfit;

            return goodsMTtlSaSlipWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcMTtlStockSlipWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APMTtlStockSlipWork SearchDataFromUpdateData(DCMTtlStockSlipWork dcMTtlStockSlipWork)
        {
            if (dcMTtlStockSlipWork == null)
            {
                return null;
            }

            APMTtlStockSlipWork mTtlStockSlipWork = new APMTtlStockSlipWork();

            // 変換
            mTtlStockSlipWork.CreateDateTime = dcMTtlStockSlipWork.CreateDateTime;
            mTtlStockSlipWork.UpdateDateTime = dcMTtlStockSlipWork.UpdateDateTime;
            mTtlStockSlipWork.EnterpriseCode = dcMTtlStockSlipWork.EnterpriseCode;
            mTtlStockSlipWork.FileHeaderGuid = dcMTtlStockSlipWork.FileHeaderGuid;
            mTtlStockSlipWork.UpdEmployeeCode = dcMTtlStockSlipWork.UpdEmployeeCode;
            mTtlStockSlipWork.UpdAssemblyId1 = dcMTtlStockSlipWork.UpdAssemblyId1;
            mTtlStockSlipWork.UpdAssemblyId2 = dcMTtlStockSlipWork.UpdAssemblyId2;
            mTtlStockSlipWork.LogicalDeleteCode = dcMTtlStockSlipWork.LogicalDeleteCode;
            mTtlStockSlipWork.StockSectionCd = dcMTtlStockSlipWork.StockSectionCd;
            mTtlStockSlipWork.StockDateYm = dcMTtlStockSlipWork.StockDateYm;
            mTtlStockSlipWork.RsltTtlDivCd = dcMTtlStockSlipWork.RsltTtlDivCd;
            mTtlStockSlipWork.EmployeeCode = dcMTtlStockSlipWork.EmployeeCode;
            mTtlStockSlipWork.SupplierCd = dcMTtlStockSlipWork.SupplierCd;
            mTtlStockSlipWork.StockTotalPrice = dcMTtlStockSlipWork.StockTotalPrice;
            mTtlStockSlipWork.TotalStockCount = dcMTtlStockSlipWork.TotalStockCount;
            mTtlStockSlipWork.StockRetGoodsPrice = dcMTtlStockSlipWork.StockRetGoodsPrice;
            mTtlStockSlipWork.StockTotalDiscount = dcMTtlStockSlipWork.StockTotalDiscount;

            return mTtlStockSlipWork;
        }
        
        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcStockAdjustWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APStockAdjustWork SearchDataFromUpdateData(DCStockAdjustWork dcStockAdjustWork)
        {
            if (dcStockAdjustWork == null)
            {
                return null;
            }

            APStockAdjustWork stockAdjustWork = new APStockAdjustWork();

            stockAdjustWork.CreateDateTime = dcStockAdjustWork.CreateDateTime;
            stockAdjustWork.UpdateDateTime = dcStockAdjustWork.UpdateDateTime;
            stockAdjustWork.EnterpriseCode = dcStockAdjustWork.EnterpriseCode;
            stockAdjustWork.FileHeaderGuid = dcStockAdjustWork.FileHeaderGuid;
            stockAdjustWork.UpdEmployeeCode = dcStockAdjustWork.UpdEmployeeCode;
            stockAdjustWork.UpdAssemblyId1 = dcStockAdjustWork.UpdAssemblyId1;
            stockAdjustWork.UpdAssemblyId2 = dcStockAdjustWork.UpdAssemblyId2;
            stockAdjustWork.LogicalDeleteCode = dcStockAdjustWork.LogicalDeleteCode;
            stockAdjustWork.SectionCode = dcStockAdjustWork.SectionCode;
            stockAdjustWork.StockAdjustSlipNo = dcStockAdjustWork.StockAdjustSlipNo;
            stockAdjustWork.AcPaySlipCd = dcStockAdjustWork.AcPaySlipCd;
            stockAdjustWork.AcPayTransCd = dcStockAdjustWork.AcPayTransCd;
            stockAdjustWork.AdjustDate = dcStockAdjustWork.AdjustDate;
            stockAdjustWork.InputDay = dcStockAdjustWork.InputDay;
            stockAdjustWork.StockSectionCd = dcStockAdjustWork.StockSectionCd;
            stockAdjustWork.StockInputCode = dcStockAdjustWork.StockInputCode;
            stockAdjustWork.StockInputName = dcStockAdjustWork.StockInputName;
            stockAdjustWork.StockAgentCode = dcStockAdjustWork.StockAgentCode;
            stockAdjustWork.StockAgentName = dcStockAdjustWork.StockAgentName;
            stockAdjustWork.StockSubttlPrice = dcStockAdjustWork.StockSubttlPrice;
            stockAdjustWork.SlipNote = dcStockAdjustWork.SlipNote;

            return stockAdjustWork;
        }
        
        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcStockAdjustDtlWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APStockAdjustDtlWork SearchDataFromUpdateData(DCStockAdjustDtlWork dcStockAdjustDtlWork)
        {
            if (dcStockAdjustDtlWork == null)
            {
                return null;
            }

            APStockAdjustDtlWork stockAdjustDtlWork = new APStockAdjustDtlWork();

            stockAdjustDtlWork.CreateDateTime = dcStockAdjustDtlWork.CreateDateTime;
            stockAdjustDtlWork.UpdateDateTime = dcStockAdjustDtlWork.UpdateDateTime;
            stockAdjustDtlWork.EnterpriseCode = dcStockAdjustDtlWork.EnterpriseCode;
            stockAdjustDtlWork.FileHeaderGuid = dcStockAdjustDtlWork.FileHeaderGuid;
            stockAdjustDtlWork.UpdEmployeeCode = dcStockAdjustDtlWork.UpdEmployeeCode;
            stockAdjustDtlWork.UpdAssemblyId1 = dcStockAdjustDtlWork.UpdAssemblyId1;
            stockAdjustDtlWork.UpdAssemblyId2 = dcStockAdjustDtlWork.UpdAssemblyId2;
            stockAdjustDtlWork.LogicalDeleteCode = dcStockAdjustDtlWork.LogicalDeleteCode;
            stockAdjustDtlWork.SectionCode = dcStockAdjustDtlWork.SectionCode;
            stockAdjustDtlWork.StockAdjustSlipNo = dcStockAdjustDtlWork.StockAdjustSlipNo;
            stockAdjustDtlWork.StockAdjustRowNo = dcStockAdjustDtlWork.StockAdjustRowNo;
            stockAdjustDtlWork.SupplierFormalSrc = dcStockAdjustDtlWork.SupplierFormalSrc;
            stockAdjustDtlWork.StockSlipDtlNumSrc = dcStockAdjustDtlWork.StockSlipDtlNumSrc;
            stockAdjustDtlWork.AcPaySlipCd = dcStockAdjustDtlWork.AcPaySlipCd;
            stockAdjustDtlWork.AcPayTransCd = dcStockAdjustDtlWork.AcPayTransCd;
            stockAdjustDtlWork.AdjustDate = dcStockAdjustDtlWork.AdjustDate;
            stockAdjustDtlWork.InputDay = dcStockAdjustDtlWork.InputDay;
            stockAdjustDtlWork.GoodsMakerCd = dcStockAdjustDtlWork.GoodsMakerCd;
            stockAdjustDtlWork.MakerName = dcStockAdjustDtlWork.MakerName;
            stockAdjustDtlWork.GoodsNo = dcStockAdjustDtlWork.GoodsNo;
            stockAdjustDtlWork.GoodsName = dcStockAdjustDtlWork.GoodsName;
            stockAdjustDtlWork.StockUnitPriceFl = dcStockAdjustDtlWork.StockUnitPriceFl;
            stockAdjustDtlWork.BfStockUnitPriceFl = dcStockAdjustDtlWork.BfStockUnitPriceFl;
            stockAdjustDtlWork.AdjustCount = dcStockAdjustDtlWork.AdjustCount;
            stockAdjustDtlWork.DtlNote = dcStockAdjustDtlWork.DtlNote;
            stockAdjustDtlWork.WarehouseCode = dcStockAdjustDtlWork.WarehouseCode;
            stockAdjustDtlWork.WarehouseName = dcStockAdjustDtlWork.WarehouseName;
            stockAdjustDtlWork.BLGoodsCode = dcStockAdjustDtlWork.BLGoodsCode;
            stockAdjustDtlWork.BLGoodsFullName = dcStockAdjustDtlWork.BLGoodsFullName;
            stockAdjustDtlWork.WarehouseShelfNo = dcStockAdjustDtlWork.WarehouseShelfNo;
            stockAdjustDtlWork.ListPriceFl = dcStockAdjustDtlWork.ListPriceFl;
            stockAdjustDtlWork.OpenPriceDiv = dcStockAdjustDtlWork.OpenPriceDiv;
            stockAdjustDtlWork.StockPriceTaxExc = dcStockAdjustDtlWork.StockPriceTaxExc;

            return stockAdjustDtlWork;
        }
        
        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcStockMoveWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APStockMoveWork SearchDataFromUpdateData(DCStockMoveWork dcStockMoveWork)
        {
            if (dcStockMoveWork == null)
            {
                return null;
            }

            APStockMoveWork stockMoveWork = new APStockMoveWork();

            stockMoveWork.CreateDateTime = dcStockMoveWork.CreateDateTime;
            stockMoveWork.UpdateDateTime = dcStockMoveWork.UpdateDateTime;
            stockMoveWork.EnterpriseCode = dcStockMoveWork.EnterpriseCode;
            stockMoveWork.FileHeaderGuid = dcStockMoveWork.FileHeaderGuid;
            stockMoveWork.UpdEmployeeCode = dcStockMoveWork.UpdEmployeeCode;
            stockMoveWork.UpdAssemblyId1 = dcStockMoveWork.UpdAssemblyId1;
            stockMoveWork.UpdAssemblyId2 = dcStockMoveWork.UpdAssemblyId2;
            stockMoveWork.LogicalDeleteCode = dcStockMoveWork.LogicalDeleteCode;
            stockMoveWork.StockMoveFormal = dcStockMoveWork.StockMoveFormal;
            stockMoveWork.StockMoveSlipNo = dcStockMoveWork.StockMoveSlipNo;
            stockMoveWork.StockMoveRowNo = dcStockMoveWork.StockMoveRowNo;
            stockMoveWork.UpdateSecCd = dcStockMoveWork.UpdateSecCd;
            stockMoveWork.BfSectionCode = dcStockMoveWork.BfSectionCode;
            stockMoveWork.BfSectionGuideSnm = dcStockMoveWork.BfSectionGuideSnm;
            stockMoveWork.BfEnterWarehCode = dcStockMoveWork.BfEnterWarehCode;
            stockMoveWork.BfEnterWarehName = dcStockMoveWork.BfEnterWarehName;
            stockMoveWork.AfSectionCode = dcStockMoveWork.AfSectionCode;
            stockMoveWork.AfSectionGuideSnm = dcStockMoveWork.AfSectionGuideSnm;
            stockMoveWork.AfEnterWarehCode = dcStockMoveWork.AfEnterWarehCode;
            stockMoveWork.AfEnterWarehName = dcStockMoveWork.AfEnterWarehName;
            stockMoveWork.ShipmentScdlDay = dcStockMoveWork.ShipmentScdlDay;
            stockMoveWork.ShipmentFixDay = dcStockMoveWork.ShipmentFixDay;
            stockMoveWork.ArrivalGoodsDay = dcStockMoveWork.ArrivalGoodsDay;
            stockMoveWork.InputDay = dcStockMoveWork.InputDay;
            stockMoveWork.MoveStatus = dcStockMoveWork.MoveStatus;
            stockMoveWork.StockMvEmpCode = dcStockMoveWork.StockMvEmpCode;
            stockMoveWork.StockMvEmpName = dcStockMoveWork.StockMvEmpName;
            stockMoveWork.ShipAgentCd = dcStockMoveWork.ShipAgentCd;
            stockMoveWork.ShipAgentNm = dcStockMoveWork.ShipAgentNm;
            stockMoveWork.ReceiveAgentCd = dcStockMoveWork.ReceiveAgentCd;
            stockMoveWork.ReceiveAgentNm = dcStockMoveWork.ReceiveAgentNm;
            stockMoveWork.SupplierCd = dcStockMoveWork.SupplierCd;
            stockMoveWork.SupplierSnm = dcStockMoveWork.SupplierSnm;
            stockMoveWork.GoodsMakerCd = dcStockMoveWork.GoodsMakerCd;
            stockMoveWork.MakerName = dcStockMoveWork.MakerName;
            stockMoveWork.GoodsNo = dcStockMoveWork.GoodsNo;
            stockMoveWork.GoodsName = dcStockMoveWork.GoodsName;
            stockMoveWork.GoodsNameKana = dcStockMoveWork.GoodsNameKana;
            stockMoveWork.StockDiv = dcStockMoveWork.StockDiv;
            stockMoveWork.StockUnitPriceFl = dcStockMoveWork.StockUnitPriceFl;
            stockMoveWork.TaxationDivCd = dcStockMoveWork.TaxationDivCd;
            stockMoveWork.MoveCount = dcStockMoveWork.MoveCount;
            stockMoveWork.BfShelfNo = dcStockMoveWork.BfShelfNo;
            stockMoveWork.AfShelfNo = dcStockMoveWork.AfShelfNo;
            stockMoveWork.BLGoodsCode = dcStockMoveWork.BLGoodsCode;
            stockMoveWork.BLGoodsFullName = dcStockMoveWork.BLGoodsFullName;
            stockMoveWork.ListPriceFl = dcStockMoveWork.ListPriceFl;
            stockMoveWork.Outline = dcStockMoveWork.Outline;
            stockMoveWork.WarehouseNote1 = dcStockMoveWork.WarehouseNote1;
            stockMoveWork.SlipPrintFinishCd = dcStockMoveWork.SlipPrintFinishCd;
            stockMoveWork.StockMovePrice = dcStockMoveWork.StockMovePrice;

            return stockMoveWork;
        }
        
        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcStockAcPayHistWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APStockAcPayHistWork SearchDataFromUpdateData(DCStockAcPayHistWork dcStockAcPayHistWork)
        {
            if (dcStockAcPayHistWork == null)
            {
                return null;
            }

            APStockAcPayHistWork stockAcPayHistWork = new APStockAcPayHistWork();

            stockAcPayHistWork.CreateDateTime = dcStockAcPayHistWork.CreateDateTime;
            stockAcPayHistWork.UpdateDateTime = dcStockAcPayHistWork.UpdateDateTime;
            stockAcPayHistWork.EnterpriseCode = dcStockAcPayHistWork.EnterpriseCode;
            stockAcPayHistWork.FileHeaderGuid = dcStockAcPayHistWork.FileHeaderGuid;
            stockAcPayHistWork.UpdEmployeeCode = dcStockAcPayHistWork.UpdEmployeeCode;
            stockAcPayHistWork.UpdAssemblyId1 = dcStockAcPayHistWork.UpdAssemblyId1;
            stockAcPayHistWork.UpdAssemblyId2 = dcStockAcPayHistWork.UpdAssemblyId2;
            stockAcPayHistWork.LogicalDeleteCode = dcStockAcPayHistWork.LogicalDeleteCode;
            stockAcPayHistWork.IoGoodsDay = dcStockAcPayHistWork.IoGoodsDay;
            stockAcPayHistWork.AddUpADate = dcStockAcPayHistWork.AddUpADate;
            stockAcPayHistWork.AcPaySlipCd = dcStockAcPayHistWork.AcPaySlipCd;
            stockAcPayHistWork.AcPaySlipNum = dcStockAcPayHistWork.AcPaySlipNum;
            stockAcPayHistWork.AcPaySlipRowNo = dcStockAcPayHistWork.AcPaySlipRowNo;
            stockAcPayHistWork.AcPayHistDateTime = dcStockAcPayHistWork.AcPayHistDateTime;
            stockAcPayHistWork.AcPayTransCd = dcStockAcPayHistWork.AcPayTransCd;
            stockAcPayHistWork.InputSectionCd = dcStockAcPayHistWork.InputSectionCd;
            stockAcPayHistWork.InputSectionGuidNm = dcStockAcPayHistWork.InputSectionGuidNm;
            stockAcPayHistWork.InputAgenCd = dcStockAcPayHistWork.InputAgenCd;
            stockAcPayHistWork.InputAgenNm = dcStockAcPayHistWork.InputAgenNm;
            stockAcPayHistWork.MoveStatus = dcStockAcPayHistWork.MoveStatus;
            stockAcPayHistWork.CustSlipNo = dcStockAcPayHistWork.CustSlipNo;
            stockAcPayHistWork.SlipDtlNum = dcStockAcPayHistWork.SlipDtlNum;
            stockAcPayHistWork.AcPayNote = dcStockAcPayHistWork.AcPayNote;
            stockAcPayHistWork.GoodsMakerCd = dcStockAcPayHistWork.GoodsMakerCd;
            stockAcPayHistWork.MakerName = dcStockAcPayHistWork.MakerName;
            stockAcPayHistWork.GoodsNo = dcStockAcPayHistWork.GoodsNo;
            stockAcPayHistWork.GoodsName = dcStockAcPayHistWork.GoodsName;
            stockAcPayHistWork.BLGoodsCode = dcStockAcPayHistWork.BLGoodsCode;
            stockAcPayHistWork.BLGoodsFullName = dcStockAcPayHistWork.BLGoodsFullName;
            stockAcPayHistWork.SectionCode = dcStockAcPayHistWork.SectionCode;
            stockAcPayHistWork.SectionGuideNm = dcStockAcPayHistWork.SectionGuideNm;
            stockAcPayHistWork.WarehouseCode = dcStockAcPayHistWork.WarehouseCode;
            stockAcPayHistWork.WarehouseName = dcStockAcPayHistWork.WarehouseName;
            stockAcPayHistWork.ShelfNo = dcStockAcPayHistWork.ShelfNo;
            stockAcPayHistWork.BfSectionCode = dcStockAcPayHistWork.BfSectionCode;
            stockAcPayHistWork.BfSectionGuideNm = dcStockAcPayHistWork.BfSectionGuideNm;
            stockAcPayHistWork.BfEnterWarehCode = dcStockAcPayHistWork.BfEnterWarehCode;
            stockAcPayHistWork.BfEnterWarehName = dcStockAcPayHistWork.BfEnterWarehName;
            stockAcPayHistWork.BfShelfNo = dcStockAcPayHistWork.BfShelfNo;
            stockAcPayHistWork.AfSectionCode = dcStockAcPayHistWork.AfSectionCode;
            stockAcPayHistWork.AfSectionGuideNm = dcStockAcPayHistWork.AfSectionGuideNm;
            stockAcPayHistWork.AfEnterWarehCode = dcStockAcPayHistWork.AfEnterWarehCode;
            stockAcPayHistWork.AfEnterWarehName = dcStockAcPayHistWork.AfEnterWarehName;
            stockAcPayHistWork.AfShelfNo = dcStockAcPayHistWork.AfShelfNo;
            stockAcPayHistWork.CustomerCode = dcStockAcPayHistWork.CustomerCode;
            stockAcPayHistWork.CustomerSnm = dcStockAcPayHistWork.CustomerSnm;
            stockAcPayHistWork.SupplierCd = dcStockAcPayHistWork.SupplierCd;
            stockAcPayHistWork.SupplierSnm = dcStockAcPayHistWork.SupplierSnm;
            stockAcPayHistWork.ArrivalCnt = dcStockAcPayHistWork.ArrivalCnt;
            stockAcPayHistWork.ShipmentCnt = dcStockAcPayHistWork.ShipmentCnt;
            stockAcPayHistWork.OpenPriceDiv = dcStockAcPayHistWork.OpenPriceDiv;
            stockAcPayHistWork.ListPriceTaxExcFl = dcStockAcPayHistWork.ListPriceTaxExcFl;
            stockAcPayHistWork.StockUnitPriceFl = dcStockAcPayHistWork.StockUnitPriceFl;
            stockAcPayHistWork.StockPrice = dcStockAcPayHistWork.StockPrice;
            stockAcPayHistWork.SalesUnPrcTaxExcFl = dcStockAcPayHistWork.SalesUnPrcTaxExcFl;
            stockAcPayHistWork.SalesMoney = dcStockAcPayHistWork.SalesMoney;
            stockAcPayHistWork.SupplierStock = dcStockAcPayHistWork.SupplierStock;
            stockAcPayHistWork.AcpOdrCount = dcStockAcPayHistWork.AcpOdrCount;
            stockAcPayHistWork.SalesOrderCount = dcStockAcPayHistWork.SalesOrderCount;
            stockAcPayHistWork.MovingSupliStock = dcStockAcPayHistWork.MovingSupliStock;
            stockAcPayHistWork.NonAddUpShipmCnt = dcStockAcPayHistWork.NonAddUpShipmCnt;
            stockAcPayHistWork.NonAddUpArrGdsCnt = dcStockAcPayHistWork.NonAddUpArrGdsCnt;
            stockAcPayHistWork.ShipmentPosCnt = dcStockAcPayHistWork.ShipmentPosCnt;
            stockAcPayHistWork.PresentStockCnt = dcStockAcPayHistWork.PresentStockCnt;

            return stockAcPayHistWork;
        }
        #region ADD 2011/07/29 SCM対応 拠点管理(10704767-00)
        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcDepositAlwWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APDepositAlwWork SearchDataFromUpdateData(DCDepositAlwWork dcDepositAlwWork)
        {
            if (dcDepositAlwWork == null)
            {
                return null;
            }
            APDepositAlwWork depositAlwWork = new APDepositAlwWork();

            depositAlwWork.CreateDateTime = dcDepositAlwWork.CreateDateTime;
            depositAlwWork.UpdateDateTime = dcDepositAlwWork.UpdateDateTime;
            depositAlwWork.EnterpriseCode = dcDepositAlwWork.EnterpriseCode;
            depositAlwWork.FileHeaderGuid = dcDepositAlwWork.FileHeaderGuid;
            depositAlwWork.UpdEmployeeCode = dcDepositAlwWork.UpdEmployeeCode;
            depositAlwWork.UpdAssemblyId1 = dcDepositAlwWork.UpdAssemblyId1;
            depositAlwWork.UpdAssemblyId2 = dcDepositAlwWork.UpdAssemblyId2;
            depositAlwWork.LogicalDeleteCode = dcDepositAlwWork.LogicalDeleteCode;
            depositAlwWork.InputDepositSecCd = dcDepositAlwWork.InputDepositSecCd;
            depositAlwWork.AddUpSecCode = dcDepositAlwWork.AddUpSecCode;
            depositAlwWork.AcptAnOdrStatus = dcDepositAlwWork.AcptAnOdrStatus;
            depositAlwWork.SalesSlipNum = dcDepositAlwWork.SalesSlipNum;
            depositAlwWork.ReconcileDate = dcDepositAlwWork.ReconcileDate;
            depositAlwWork.ReconcileAddUpDate = dcDepositAlwWork.ReconcileAddUpDate;
            depositAlwWork.DepositSlipNo = dcDepositAlwWork.DepositSlipNo;
            depositAlwWork.DepositAllowance = dcDepositAlwWork.DepositAllowance;
            depositAlwWork.DepositAgentCode = dcDepositAlwWork.DepositAgentCode;
            depositAlwWork.DepositAgentNm = dcDepositAlwWork.DepositAgentNm;
            depositAlwWork.CustomerCode = dcDepositAlwWork.CustomerCode;
            depositAlwWork.CustomerName = dcDepositAlwWork.CustomerName;
            depositAlwWork.CustomerName2 = dcDepositAlwWork.CustomerName2;
            depositAlwWork.DebitNoteOffSetCd = dcDepositAlwWork.DebitNoteOffSetCd;

            return depositAlwWork;
        }
        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcRcvDraftDataWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APRcvDraftDataWork SearchDataFromUpdateData(DCRcvDraftDataWork dcRcvDraftDataWork)
        {
            if (dcRcvDraftDataWork == null)
            {
                return null;
            }
            APRcvDraftDataWork rcvDraftDataWork = new APRcvDraftDataWork();

            rcvDraftDataWork.CreateDateTime = dcRcvDraftDataWork.CreateDateTime;
            rcvDraftDataWork.UpdateDateTime = dcRcvDraftDataWork.UpdateDateTime;
            rcvDraftDataWork.EnterpriseCode = dcRcvDraftDataWork.EnterpriseCode;
            rcvDraftDataWork.FileHeaderGuid = dcRcvDraftDataWork.FileHeaderGuid;
            rcvDraftDataWork.UpdEmployeeCode = dcRcvDraftDataWork.UpdEmployeeCode;
            rcvDraftDataWork.UpdAssemblyId1 = dcRcvDraftDataWork.UpdAssemblyId1;
            rcvDraftDataWork.UpdAssemblyId2 = dcRcvDraftDataWork.UpdAssemblyId2;
            rcvDraftDataWork.LogicalDeleteCode = dcRcvDraftDataWork.LogicalDeleteCode;
            rcvDraftDataWork.RcvDraftNo = dcRcvDraftDataWork.RcvDraftNo;
            rcvDraftDataWork.DraftKindCd = dcRcvDraftDataWork.DraftKindCd;
            rcvDraftDataWork.DraftDivide = dcRcvDraftDataWork.DraftDivide;
            rcvDraftDataWork.Deposit = dcRcvDraftDataWork.Deposit;
            rcvDraftDataWork.BankAndBranchCd = dcRcvDraftDataWork.BankAndBranchCd;
            rcvDraftDataWork.BankAndBranchNm = dcRcvDraftDataWork.BankAndBranchNm;
            rcvDraftDataWork.SectionCode = dcRcvDraftDataWork.SectionCode;
            rcvDraftDataWork.AddUpSecCode = dcRcvDraftDataWork.AddUpSecCode;
            rcvDraftDataWork.CustomerCode = dcRcvDraftDataWork.CustomerCode;
            rcvDraftDataWork.CustomerName = dcRcvDraftDataWork.CustomerName;
            rcvDraftDataWork.CustomerName2 = dcRcvDraftDataWork.CustomerName2;
            rcvDraftDataWork.CustomerSnm = dcRcvDraftDataWork.CustomerSnm;
            rcvDraftDataWork.ProcDate = dcRcvDraftDataWork.ProcDate;
            rcvDraftDataWork.DraftDrawingDate = dcRcvDraftDataWork.DraftDrawingDate;
            rcvDraftDataWork.ValidityTerm = dcRcvDraftDataWork.ValidityTerm;
            rcvDraftDataWork.DraftStmntDate = dcRcvDraftDataWork.DraftStmntDate;
            rcvDraftDataWork.Outline1 = dcRcvDraftDataWork.Outline1;
            rcvDraftDataWork.Outline2 = dcRcvDraftDataWork.Outline2;
            rcvDraftDataWork.AcptAnOdrStatus = dcRcvDraftDataWork.AcptAnOdrStatus;
            rcvDraftDataWork.DepositSlipNo = dcRcvDraftDataWork.DepositSlipNo;
            rcvDraftDataWork.DepositRowNo = dcRcvDraftDataWork.DepositRowNo;
            rcvDraftDataWork.DepositDate = dcRcvDraftDataWork.DepositDate;

            return rcvDraftDataWork;
        }
        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dcPayDraftDataWork">データワーククラス</param>
        /// <returns>データクラス</returns>
        public static APPayDraftDataWork SearchDataFromUpdateData(DCPayDraftDataWork dcPayDraftDataWork)
        {
            if (dcPayDraftDataWork == null)
            {
                return null;
            }
            APPayDraftDataWork payDraftDataWork = new APPayDraftDataWork();

            payDraftDataWork.CreateDateTime = dcPayDraftDataWork.CreateDateTime;
            payDraftDataWork.UpdateDateTime = dcPayDraftDataWork.UpdateDateTime;
            payDraftDataWork.EnterpriseCode = dcPayDraftDataWork.EnterpriseCode;
            payDraftDataWork.FileHeaderGuid = dcPayDraftDataWork.FileHeaderGuid;
            payDraftDataWork.UpdEmployeeCode = dcPayDraftDataWork.UpdEmployeeCode;
            payDraftDataWork.UpdAssemblyId1 = dcPayDraftDataWork.UpdAssemblyId1;
            payDraftDataWork.UpdAssemblyId2 = dcPayDraftDataWork.UpdAssemblyId2;
            payDraftDataWork.LogicalDeleteCode = dcPayDraftDataWork.LogicalDeleteCode;
            payDraftDataWork.PayDraftNo = dcPayDraftDataWork.PayDraftNo;
            payDraftDataWork.DraftKindCd = dcPayDraftDataWork.DraftKindCd;
            payDraftDataWork.DraftDivide = dcPayDraftDataWork.DraftDivide;
            payDraftDataWork.Payment = dcPayDraftDataWork.Payment;
            payDraftDataWork.BankAndBranchCd = dcPayDraftDataWork.BankAndBranchCd;
            payDraftDataWork.BankAndBranchNm = dcPayDraftDataWork.BankAndBranchNm;
            payDraftDataWork.SectionCode = dcPayDraftDataWork.SectionCode;
            payDraftDataWork.AddUpSecCode = dcPayDraftDataWork.AddUpSecCode;
            payDraftDataWork.SupplierCd = dcPayDraftDataWork.SupplierCd;
            payDraftDataWork.SupplierNm1 = dcPayDraftDataWork.SupplierNm1;
            payDraftDataWork.SupplierNm2 = dcPayDraftDataWork.SupplierNm2;
            payDraftDataWork.SupplierSnm = dcPayDraftDataWork.SupplierSnm;
            payDraftDataWork.ProcDate = dcPayDraftDataWork.ProcDate;
            payDraftDataWork.DraftDrawingDate = dcPayDraftDataWork.DraftDrawingDate;
            payDraftDataWork.ValidityTerm = dcPayDraftDataWork.ValidityTerm;
            payDraftDataWork.DraftStmntDate = dcPayDraftDataWork.DraftStmntDate;
            payDraftDataWork.Outline1 = dcPayDraftDataWork.Outline1;
            payDraftDataWork.Outline2 = dcPayDraftDataWork.Outline2;
            payDraftDataWork.SupplierFormal = dcPayDraftDataWork.SupplierFormal;
            payDraftDataWork.PaymentSlipNo = dcPayDraftDataWork.PaymentSlipNo;
            payDraftDataWork.PaymentRowNo = dcPayDraftDataWork.PaymentRowNo;
            payDraftDataWork.PaymentDate = dcPayDraftDataWork.PaymentDate;

            return payDraftDataWork;
        }
        #endregion

    }
}
