using System;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using System.Runtime.Serialization.Formatters.Binary; // 2010/04/27
using System.IO; // 2010/04/27

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����f�[�^�I�u�W�F�N�g�R���o�[�g�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����֘A�N���X�̍��ڃR���o�[�g������s���܂��B</br>
    /// <br>Programmer : 20056 ���n�@���</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 ���n�@���  �V�K�쐬</br>
    /// <br>Update Note  : 2009/09/08 ���M</br>
    /// <br>               PM.NS-2-A�E���q�Ǘ�</br>
    /// <br>               ���q���l�̒ǉ�</br>
    /// <br>Update Note : 2009/10/19 ���M</br>
    /// <br>              PM.NS-3-A�EPM.NS�ێ�˗��A</br>
    /// <br>              �W�����i�I��L���敪��ǉ�</br>
    /// <br>Update Note : 2010/02/26 ���n ��� </br>
    /// <br>              SCM�Ή�</br>
    /// <br>Update Note : 2010/04/27 gaoyh</br>
    /// <br>              �󒍃}�X�^�i�ԗ��j���R�����^���Œ�ԍ��z��̒ǉ��Ή�</br>
    /// <br>UpdateNote :  2011/07/18 ���R �񓚋敪�̒ǉ�</br>
    /// <br>UpdateNote  : 2011/08/23 ���R Redmine#23645 PCCUOE_�e�[�u�����C�A�E�g�ύX�Ή�</br>
    /// <br>Update Note : 2011/12/15 tianjw</br>
    /// <br>              Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
    /// <br>Update Note : 2012/01/16 30517 �Ė� �x��</br>
    /// <br>              SCM���ǁE���L�����Ή�</br>
    /// <br>Update Note : 2012/01/19 tianjw</br>
    /// <br>              Redmine#28098 ���_�Ǘ��^���M�ς݃G���[</br>
    /// <br>Update Note: 2012/05/02 20056 ���n ���</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��Q�Ή�</br>
    /// <br>             ���ǁF�ݏo�d���������͑Ή�</br>
    /// <br>Update Note: 2013/01/18 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>           : Redmine#33797 �����������l�敪�̒ǉ�</br>
    /// <br>Update Note: 2013/01/24 ���N�n��</br>
    /// <br>�Ǘ��ԍ�   : 10900690-00 2013/03/13�z�M��</br>
    /// <br>           : Redmine#34605 �����ʂ̉��i�޲�ޕ\���Ɂw���_�x��w�\���敪�x�̒ǉ�</br>
    /// <br>Update Note: 2013/03/21 FSI���� ���T</br>
    /// <br>�Ǘ��ԍ�   : 10900269-00</br>
    /// <br>             SPK�ԑ�ԍ�������Ή�</br>   
    /// <br>Update Note: 2015/08/22 �����M</br>
    /// <br>�Ǘ��ԍ�   : 11170129-00 ��836 Redmine#47045 �ۑ����̏d���G���[�����̏�Q�Ή�</br>
    /// </remarks>
    public class ConvertSalesSlip
    {
        #region ��Public Static Methods
        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="salHisRefResultParamWorkList">���㗚���Ɖ�[�N�I�u�W�F�N�g���X�g</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g���X�g</returns>
        public static List<SalesDetail> UIDataFromParamData(List<SalHisRefResultParamWork> salHisRefResultParamWorkList)
        {
            return UIDataFromParamDataProc(salHisRefResultParamWorkList);
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="salHisRefResultParamWork">���㗚���Ɖ�[�N�I�u�W�F�N�g</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g</returns>
        public static SalesDetail UIDataFromParamData(SalHisRefResultParamWork salHisRefResultParamWork)
        {
            return UIDataFromParamDataProc(salHisRefResultParamWork);
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="preChargedDataSelectResultWorkList">�o�ׁ^���ϏƉ�[�N�I�u�W�F�N�g���X�g(���בI��)</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g���X�g</returns>
        public static List<SalesDetail> UIDataFromParamData(List<PreChargedDataSelectResultWork> preChargedDataSelectResultWorkList)
        {
            return UIDataFromParamDataProc(preChargedDataSelectResultWorkList);
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="preChargedDataSelectResultWork">�o�ׁ^���ϏƉ�[�N�I�u�W�F�N�g(���בI��)</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g</returns>
        public static SalesDetail UIDataFromParamData(PreChargedDataSelectResultWork preChargedDataSelectResultWork)
        {
            return UIDataFromParamDataProc(preChargedDataSelectResultWork);
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="acptAnOdrRemainRefDataList">�󒍏Ɖ�[�N�I�u�W�F�N�g���X�g(���בI��)</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g���X�g</returns>
        public static List<SalesDetail> UIDataFromParamData(List<AcptAnOdrRemainRefData> acptAnOdrRemainRefDataList)
        {
            return UIDataFromParamDataProc(acptAnOdrRemainRefDataList);
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="salHisRefResultParamWork">�󒍏Ɖ�[�N�I�u�W�F�N�g(���בI��)</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g</returns>
        public static SalesDetail UIDataFromParamData(AcptAnOdrRemainRefData acptAnOdrRemainRefData)
        {
            return UIDataFromParamDataProc(acptAnOdrRemainRefData);
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="addUppSrcStockDetailWorkList">�v�㌳�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g���X�g</returns>
        public static List<SalesDetail> UIDataFromParamData(AddUpOrgSalesDetailWork[] addUpSrcSalesDetailWorkList)
        {
            return UIDataFromParamDataProc(addUpSrcSalesDetailWorkList);
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <returns>����f�[�^�I�u�W�F�N�g</returns>
        public static SalesSlip UIDataFromParamData(SalesSlipWork salesSlipWork)
        {
            return UIDataFromParamDataProc(salesSlipWork);
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g���X�g</returns>
        public static List<SalesDetail> UIDataFromParamData(SalesDetailWork[] salesDetailWorkArray)
        {
            return UIDataFromParamDataProc(salesDetailWorkArray);
        }

        //>>>2010/02/26
        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="salesDetailWorkList">���㖾�׃f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g���X�g</returns>
        public static List<SalesDetail> UIDataFromParamData(List<SalesDetailWork> salesDetailWorkList)
        {
            return UIDataFromParamDataProc(salesDetailWorkList);
        }
        //<<<2010/02/26

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="salesDetailWork">���㖾�׃f�[�^���[�N�I�u�W�F�N�g</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g</returns>
        public static SalesDetail UIDataFromParamData(SalesDetailWork salesDetailWork)
        {
            return UIDataFromParamDataProc( salesDetailWork);
        }

        /// <summary>
        /// UIData��PramData�ڍ�����
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <returns>����f�[�^���[�N�I�u�W�F�N�g</returns>
        public static SalesSlipWork ParamDataFromUIData(SalesSlip salesSlip)
        {
            return ParamDataFromUIDataProc(salesSlip);
        }

        /// <summary>
        /// UIData��PramData�ڍ�����
        /// </summary>
        /// <param name="salesDetail">���㖾�׃f�[�^�I�u�W�F�N�g</param>
        /// <returns>���㖾�׃f�[�^���[�N�I�u�W�F�N�g</returns>
        public static SalesDetailWork ParamDataFromUIData(SalesDetail salesDetail)
        {
            return ParamDataFromUIDataProc(salesDetail);
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="stockSlipWork">�d���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockDetailWork">�d�����׃f�[�^���[�N�I�u�W�F�N�g</param>
        /// <returns>�d�����I�u�W�F�N�g</returns>
        public static StockTemp UIDataFromParamData(StockSlipWork stockSlipWork, StockDetailWork stockDetailWork)
        {
            return UIDataFromParamDataProc(stockSlipWork, stockDetailWork);
        }

        /// <summary>
        /// PramData��UIData�ڍs����
        /// </summary>
        /// <param name="acceptOdrCarWorkList">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        /// <returns>�󒍃}�X�^�i�ԗ��j�I�u�W�F�N�g���X�g</returns>
        public static List<AcceptOdrCar> UIDataFromParamData(AcceptOdrCarWork[] acceptOdrCarWorkList)
        {
            return UIDataFromParamDataProc(acceptOdrCarWorkList);
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="acceptOdrCarWork">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g</param>
        /// <returns>�󒍃}�X�^�i�ԗ��j�I�u�W�F�N�g</returns>
        public static AcceptOdrCar UIDataFromParamData(AcceptOdrCarWork acceptOdrCarWork)
        {
            return UIDataFromParamDataProc(acceptOdrCarWork);
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="depsitDataWork">�������[�N�I�u�W�F�N�g</param>
        /// <returns>�����f�[�^�I�u�W�F�N�g</returns>
        public static SearchDepsitMain UIDataFromParamData(DepsitDataWork depsitDataWork)
        {
            return UIDataFromParamDataProc( depsitDataWork);
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="searchDepsitMain">�����f�[�^�I�u�W�F�N�g</param>
        /// <returns>�������[�N�I�u�W�F�N�g</returns>
        public static DepsitDataWork ParamDataFromUIData(SearchDepsitMain searchDepsitMain)
        {
            return ParamDataFromUIDataProc(searchDepsitMain);
        }

        /// <summary>
        /// ���ڃR�s�[����
        /// </summary>
        /// <param name="source">�R�s�[������f�[�^�I�u�W�F�N�g</param>
        /// <param name="target">�R�s�[�攄��f�[�^�I�u�W�F�N�g</param>
        public static void CopyItem(SalesSlip source, ref SalesSlip target)
        {
            CopyItemProc(source, ref target);
        }

        /// <summary>
        /// ���ڃR�s�[����
        /// </summary>
        /// <param name="source">�R�s�[�����㖾�׃f�[�^�I�u�W�F�N�g</param>
        /// <param name="target">�R�s�[�攄�㖾�׃f�[�^�I�u�W�F�N�g</param>
        public static void CopyItem(SalesDetail source, ref SalesDetail target)
        {
            CopyItemProc(source, ref target);
        }
        #endregion

        #region ��Private Static Methods
        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="salHisRefResultParamWorkList">���㗚���Ɖ�[�N�I�u�W�F�N�g���X�g</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g���X�g</returns>
        private static List<SalesDetail> UIDataFromParamDataProc(List<SalHisRefResultParamWork> salHisRefResultParamWorkList)
        {
            if (salHisRefResultParamWorkList == null) return null;

            List<SalesDetail> salesDetailList = new List<SalesDetail>();

            foreach (SalHisRefResultParamWork salHisRefResultParamWork in salHisRefResultParamWorkList)
            {
                salesDetailList.Add(UIDataFromParamData(salHisRefResultParamWork));
            }

            return salesDetailList;
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="salHisRefResultParamWork">���㗚���Ɖ�[�N�I�u�W�F�N�g</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g</returns>
        private static SalesDetail UIDataFromParamDataProc(SalHisRefResultParamWork salHisRefResultParamWork)
        {
            SalesDetail salesDetail = new SalesDetail();
            //salesDetail.EnterpriseCode = salHisRefResultParamWork.EnterpriseCode;
            //salesDetail.LogicalDeleteCode = salHisRefResultParamWork.LogicalDeleteCode;
            //salesDetail.AcceptAnOrderNo = salHisRefResultParamWork.AcceptAnOrderNo;
            //salesDetail.AcptAnOdrStatus = salHisRefResultParamWork.AcptAnOdrStatus;
            //salesDetail.SalesSlipNum = salHisRefResultParamWork.SalesSlipNum;
            //salesDetail.SalesRowNo = salHisRefResultParamWork.SalesRowNo;
            //salesDetail.SectionCode = salHisRefResultParamWork.SectionCode;
            //salesDetail.SubSectionCode = salHisRefResultParamWork.SubSectionCode;
            //salesDetail.MinSectionCode = salHisRefResultParamWork.MinSectionCode;
            //salesDetail.SalesDate = salHisRefResultParamWork.SalesDate;
            //salesDetail.CommonSeqNo = salHisRefResultParamWork.CommonSeqNo;
            //salesDetail.SalesSlipDtlNum = salHisRefResultParamWork.SalesSlipDtlNum;
            //salesDetail.AcptAnOdrStatusSrc = salHisRefResultParamWork.AcptAnOdrStatusSrc;
            //salesDetail.SalesSlipDtlNumSrc = salHisRefResultParamWork.SalesSlipDtlNumSrc;
            //salesDetail.SupplierFormalSync = salHisRefResultParamWork.SupplierFormalSync;
            //salesDetail.StockSlipDtlNumSync = salHisRefResultParamWork.StockSlipDtlNumSync;
            //salesDetail.SalesSlipCdDtl = salHisRefResultParamWork.SalesSlipCdDtl;
            //salesDetail.ServiceSlipCd = salHisRefResultParamWork.ServiceSlipCd;
            //salesDetail.SalesDepositsDiv = salHisRefResultParamWork.SalesDepositsDiv;
            //salesDetail.StockMngExistCd = salHisRefResultParamWork.StockMngExistCd;
            //salesDetail.GoodsKindCode = salHisRefResultParamWork.GoodsKindCode;
            //salesDetail.GoodsMakerCd = salHisRefResultParamWork.GoodsMakerCd;
            //salesDetail.MakerName = salHisRefResultParamWork.MakerName;
            //salesDetail.GoodsNo = salHisRefResultParamWork.GoodsNo;
            //salesDetail.GoodsName = salHisRefResultParamWork.GoodsName;
            //salesDetail.GoodsSetDivCd = salHisRefResultParamWork.GoodsSetDivCd;
            //salesDetail.LargeGoodsGanreCode = salHisRefResultParamWork.LargeGoodsGanreCode;
            //salesDetail.LargeGoodsGanreName = salHisRefResultParamWork.LargeGoodsGanreName;
            //salesDetail.MediumGoodsGanreCode = salHisRefResultParamWork.MediumGoodsGanreCode;
            //salesDetail.MediumGoodsGanreName = salHisRefResultParamWork.MediumGoodsGanreName;
            //salesDetail.DetailGoodsGanreCode = salHisRefResultParamWork.DetailGoodsGanreCode;
            //salesDetail.DetailGoodsGanreName = salHisRefResultParamWork.DetailGoodsGanreName;
            //salesDetail.BLGoodsCode = salHisRefResultParamWork.BLGoodsCode;
            //salesDetail.BLGoodsFullName = salHisRefResultParamWork.BLGoodsFullName;
            //salesDetail.EnterpriseGanreCode = salHisRefResultParamWork.EnterpriseGanreCode;
            //salesDetail.EnterpriseGanreName = salHisRefResultParamWork.EnterpriseGanreName;
            //salesDetail.WarehouseCode = salHisRefResultParamWork.WarehouseCode;
            //salesDetail.WarehouseName = salHisRefResultParamWork.WarehouseName;
            //salesDetail.WarehouseShelfNo = salHisRefResultParamWork.WarehouseShelfNo;
            //salesDetail.SalesOrderDivCd = salHisRefResultParamWork.SalesOrderDivCd;
            //salesDetail.UnitCode = salHisRefResultParamWork.UnitCode;
            //salesDetail.UnitName = salHisRefResultParamWork.UnitName;
            //salesDetail.GoodsRateRank = salHisRefResultParamWork.GoodsRateRank;
            //salesDetail.CustRateGrpCode = salHisRefResultParamWork.CustRateGrpCode;
            //salesDetail.SuppRateGrpCode = salHisRefResultParamWork.SuppRateGrpCode;
            //salesDetail.ListPriceRate = salHisRefResultParamWork.ListPriceRate;
            //salesDetail.RateDivLPrice = salHisRefResultParamWork.RateDivLPrice;
            //salesDetail.UnPrcCalcCdLPrice = salHisRefResultParamWork.UnPrcCalcCdLPrice;
            //salesDetail.PriceCdLPrice = salHisRefResultParamWork.PriceCdLPrice;
            //salesDetail.StdUnPrcLPrice = salHisRefResultParamWork.StdUnPrcLPrice;
            //salesDetail.FracProcUnitLPrice = salHisRefResultParamWork.FracProcUnitLPrice;
            //salesDetail.FracProcLPrice = salHisRefResultParamWork.FracProcLPrice;
            //salesDetail.ListPriceTaxIncFl = salHisRefResultParamWork.ListPriceTaxIncFl;
            //salesDetail.ListPriceTaxExcFl = salHisRefResultParamWork.ListPriceTaxExcFl;
            //salesDetail.ListPriceChngCd = salHisRefResultParamWork.ListPriceChngCd;
            //salesDetail.SalesRate = salHisRefResultParamWork.SalesRate;
            //salesDetail.RateDivSalUnPrc = salHisRefResultParamWork.RateDivSalUnPrc;
            //salesDetail.UnPrcCalcCdSalUnPrc = salHisRefResultParamWork.UnPrcCalcCdSalUnPrc;
            //salesDetail.PriceCdSalUnPrc = salHisRefResultParamWork.PriceCdSalUnPrc;
            //salesDetail.StdUnPrcSalUnPrc = salHisRefResultParamWork.StdUnPrcSalUnPrc;
            //salesDetail.FracProcUnitSalUnPrc = salHisRefResultParamWork.FracProcUnitSalUnPrc;
            //salesDetail.FracProcSalUnPrc = salHisRefResultParamWork.FracProcSalUnPrc;
            //salesDetail.SalesUnPrcTaxIncFl = salHisRefResultParamWork.SalesUnPrcTaxIncFl;
            //salesDetail.SalesUnPrcTaxExcFl = salHisRefResultParamWork.SalesUnPrcTaxExcFl;
            //salesDetail.SalesUnPrcChngCd = salHisRefResultParamWork.SalesUnPrcChngCd;
            //salesDetail.CostRate = salHisRefResultParamWork.CostRate;
            //salesDetail.RateDivUnCst = salHisRefResultParamWork.RateDivUnCst;
            //salesDetail.UnPrcCalcCdUnCst = salHisRefResultParamWork.UnPrcCalcCdUnCst;
            //salesDetail.PriceCdUnCst = salHisRefResultParamWork.PriceCdUnCst;
            //salesDetail.StdUnPrcUnCst = salHisRefResultParamWork.StdUnPrcUnCst;
            //salesDetail.FracProcUnitUnCst = salHisRefResultParamWork.FracProcUnitUnCst;
            //salesDetail.FracProcUnCst = salHisRefResultParamWork.FracProcUnCst;
            //salesDetail.SalesUnitCost = salHisRefResultParamWork.SalesUnitCost;
            //salesDetail.SalesUnitCostChngDiv = salHisRefResultParamWork.SalesUnitCostChngDiv;
            //salesDetail.BargainCd = salHisRefResultParamWork.BargainCd;
            //salesDetail.BargainNm = salHisRefResultParamWork.BargainNm;
            //salesDetail.ShipmentCnt = salHisRefResultParamWork.ShipmentCnt;
            //salesDetail.SalesMoneyTaxInc = salHisRefResultParamWork.SalesMoneyTaxInc;
            //salesDetail.SalesMoneyTaxExc = salHisRefResultParamWork.SalesMoneyTaxExc;
            //salesDetail.Cost = salHisRefResultParamWork.Cost;
            //salesDetail.GrsProfitChkDiv = salHisRefResultParamWork.GrsProfitChkDiv;
            //salesDetail.SalesGoodsCd = salHisRefResultParamWork.SalesGoodsCd;
            //salesDetail.TaxAdjust = salHisRefResultParamWork.TaxAdjust;
            //salesDetail.BalanceAdjust = salHisRefResultParamWork.BalanceAdjust;
            //salesDetail.TaxationDivCd = salHisRefResultParamWork.TaxationDivCd;
            //salesDetail.PartySlipNumDtl = salHisRefResultParamWork.PartySlipNumDtl;
            //salesDetail.DtlNote = salHisRefResultParamWork.DtlNote;
            //salesDetail.SupplierCd = salHisRefResultParamWork.SupplierCd;
            //salesDetail.SupplierSnm = salHisRefResultParamWork.SupplierSnm;
            //salesDetail.ResultsAddUpSecCd = salHisRefResultParamWork.ResultsAddUpSecCd;
            //salesDetail.OrderNumber = salHisRefResultParamWork.OrderNumber;
            //salesDetail.SlipMemo1 = salHisRefResultParamWork.SlipMemo1;
            //salesDetail.SlipMemo2 = salHisRefResultParamWork.SlipMemo2;
            //salesDetail.SlipMemo3 = salHisRefResultParamWork.SlipMemo3;
            //salesDetail.SlipMemo4 = salHisRefResultParamWork.SlipMemo4;
            //salesDetail.SlipMemo5 = salHisRefResultParamWork.SlipMemo5;
            //salesDetail.SlipMemo6 = salHisRefResultParamWork.SlipMemo6;
            //salesDetail.InsideMemo1 = salHisRefResultParamWork.InsideMemo1;
            //salesDetail.InsideMemo2 = salHisRefResultParamWork.InsideMemo2;
            //salesDetail.InsideMemo3 = salHisRefResultParamWork.InsideMemo3;
            //salesDetail.InsideMemo4 = salHisRefResultParamWork.InsideMemo4;
            //salesDetail.InsideMemo5 = salHisRefResultParamWork.InsideMemo5;
            //salesDetail.InsideMemo6 = salHisRefResultParamWork.InsideMemo6;
            //salesDetail.BfListPrice = salHisRefResultParamWork.BfListPrice;
            //salesDetail.BfSalesUnitPrice = salHisRefResultParamWork.BfSalesUnitPrice;
            //salesDetail.BfUnitCost = salHisRefResultParamWork.BfUnitCost;
            //salesDetail.PrtGoodsNo = salHisRefResultParamWork.PrtGoodsNo;
            //salesDetail.PrtGoodsName = salHisRefResultParamWork.PrtGoodsName;
            //salesDetail.PrtGoodsMakerCd = salHisRefResultParamWork.PrtGoodsMakerCd;
            //salesDetail.PrtGoodsMakerNm = salHisRefResultParamWork.PrtGoodsMakerNm;
            return salesDetail;
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="preChargedDataSelectResultWorkList">�o�ׁ^���ϏƉ�[�N�I�u�W�F�N�g���X�g(���בI��)</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g���X�g</returns>
        private static List<SalesDetail> UIDataFromParamDataProc(List<PreChargedDataSelectResultWork> preChargedDataSelectResultWorkList)
        {
            if (preChargedDataSelectResultWorkList == null) return null;

            List<SalesDetail> salesDetailList = new List<SalesDetail>();

            foreach (PreChargedDataSelectResultWork preChargedDataSelectResultWork in preChargedDataSelectResultWorkList)
            {
                salesDetailList.Add(UIDataFromParamData(preChargedDataSelectResultWork));
            }

            return salesDetailList;
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="preChargedDataSelectResultWork">�o�ׁ^���ϏƉ�[�N�I�u�W�F�N�g(���בI��)</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g</returns>
        private static SalesDetail UIDataFromParamDataProc(PreChargedDataSelectResultWork preChargedDataSelectResultWork)
        {
            SalesDetail salesDetail = new SalesDetail();
            //salesDetail.EnterpriseCode = preChargedDataSelectResultWork.EnterpriseCode;
            //salesDetail.LogicalDeleteCode = preChargedDataSelectResultWork.LogicalDeleteCode;
            //salesDetail.AcceptAnOrderNo = preChargedDataSelectResultWork.AcceptAnOrderNo;
            //salesDetail.AcptAnOdrStatus = preChargedDataSelectResultWork.AcptAnOdrStatus;
            //salesDetail.SalesSlipNum = preChargedDataSelectResultWork.SalesSlipNum;
            //salesDetail.SalesRowNo = preChargedDataSelectResultWork.SalesRowNo;
            //salesDetail.SectionCode = preChargedDataSelectResultWork.SectionCode;
            //salesDetail.SubSectionCode = preChargedDataSelectResultWork.SubSectionCode;
            //salesDetail.MinSectionCode = preChargedDataSelectResultWork.MinSectionCode;
            //salesDetail.SalesDate = preChargedDataSelectResultWork.SalesDate;
            //salesDetail.CommonSeqNo = preChargedDataSelectResultWork.CommonSeqNo;
            //salesDetail.SalesSlipDtlNum = preChargedDataSelectResultWork.SalesSlipDtlNum;
            //salesDetail.AcptAnOdrStatusSrc = preChargedDataSelectResultWork.AcptAnOdrStatusSrc;
            //salesDetail.SalesSlipDtlNumSrc = preChargedDataSelectResultWork.SalesSlipDtlNumSrc;
            //salesDetail.SupplierFormalSync = preChargedDataSelectResultWork.SupplierFormalSync;
            //salesDetail.StockSlipDtlNumSync = preChargedDataSelectResultWork.StockSlipDtlNumSync;
            //salesDetail.SalesSlipCdDtl = preChargedDataSelectResultWork.SalesSlipCdDtl;
            //salesDetail.ServiceSlipCd = preChargedDataSelectResultWork.ServiceSlipCd;
            //salesDetail.SalesDepositsDiv = preChargedDataSelectResultWork.SalesDepositsDiv;
            //salesDetail.StockMngExistCd = preChargedDataSelectResultWork.StockMngExistCd;
            //salesDetail.GoodsKindCode = preChargedDataSelectResultWork.GoodsKindCode;
            //salesDetail.GoodsMakerCd = preChargedDataSelectResultWork.GoodsMakerCd;
            //salesDetail.MakerName = preChargedDataSelectResultWork.MakerName;
            //salesDetail.GoodsNo = preChargedDataSelectResultWork.GoodsNo;
            //salesDetail.GoodsName = preChargedDataSelectResultWork.GoodsName;
            //salesDetail.GoodsSetDivCd = preChargedDataSelectResultWork.GoodsSetDivCd;
            //salesDetail.LargeGoodsGanreCode = preChargedDataSelectResultWork.LargeGoodsGanreCode;
            //salesDetail.LargeGoodsGanreName = preChargedDataSelectResultWork.LargeGoodsGanreName;
            //salesDetail.MediumGoodsGanreCode = preChargedDataSelectResultWork.MediumGoodsGanreCode;
            //salesDetail.MediumGoodsGanreName = preChargedDataSelectResultWork.MediumGoodsGanreName;
            //salesDetail.DetailGoodsGanreCode = preChargedDataSelectResultWork.DetailGoodsGanreCode;
            //salesDetail.DetailGoodsGanreName = preChargedDataSelectResultWork.DetailGoodsGanreName;
            //salesDetail.BLGoodsCode = preChargedDataSelectResultWork.BLGoodsCode;
            //salesDetail.BLGoodsFullName = preChargedDataSelectResultWork.BLGoodsFullName;
            //salesDetail.EnterpriseGanreCode = preChargedDataSelectResultWork.EnterpriseGanreCode;
            //salesDetail.EnterpriseGanreName = preChargedDataSelectResultWork.EnterpriseGanreName;
            //salesDetail.WarehouseCode = preChargedDataSelectResultWork.WarehouseCode;
            //salesDetail.WarehouseName = preChargedDataSelectResultWork.WarehouseName;
            //salesDetail.WarehouseShelfNo = preChargedDataSelectResultWork.WarehouseShelfNo;
            //salesDetail.SalesOrderDivCd = preChargedDataSelectResultWork.SalesOrderDivCd;
            //salesDetail.UnitCode = preChargedDataSelectResultWork.UnitCode;
            //salesDetail.UnitName = preChargedDataSelectResultWork.UnitName;
            //salesDetail.GoodsRateRank = preChargedDataSelectResultWork.GoodsRateRank;
            //salesDetail.CustRateGrpCode = preChargedDataSelectResultWork.CustRateGrpCode;
            //salesDetail.SuppRateGrpCode = preChargedDataSelectResultWork.SuppRateGrpCode;
            //salesDetail.ListPriceRate = preChargedDataSelectResultWork.ListPriceRate;
            //salesDetail.RateDivLPrice = preChargedDataSelectResultWork.RateDivLPrice;
            //salesDetail.UnPrcCalcCdLPrice = preChargedDataSelectResultWork.UnPrcCalcCdLPrice;
            //salesDetail.PriceCdLPrice = preChargedDataSelectResultWork.PriceCdLPrice;
            //salesDetail.StdUnPrcLPrice = preChargedDataSelectResultWork.StdUnPrcLPrice;
            //salesDetail.FracProcUnitLPrice = preChargedDataSelectResultWork.FracProcUnitLPrice;
            //salesDetail.FracProcLPrice = preChargedDataSelectResultWork.FracProcLPrice;
            //salesDetail.ListPriceTaxIncFl = preChargedDataSelectResultWork.ListPriceTaxIncFl;
            //salesDetail.ListPriceTaxExcFl = preChargedDataSelectResultWork.ListPriceTaxExcFl;
            //salesDetail.ListPriceChngCd = preChargedDataSelectResultWork.ListPriceChngCd;
            //salesDetail.SalesRate = preChargedDataSelectResultWork.SalesRate;
            //salesDetail.RateDivSalUnPrc = preChargedDataSelectResultWork.RateDivSalUnPrc;
            //salesDetail.UnPrcCalcCdSalUnPrc = preChargedDataSelectResultWork.UnPrcCalcCdSalUnPrc;
            //salesDetail.PriceCdSalUnPrc = preChargedDataSelectResultWork.PriceCdSalUnPrc;
            //salesDetail.StdUnPrcSalUnPrc = preChargedDataSelectResultWork.StdUnPrcSalUnPrc;
            //salesDetail.FracProcUnitSalUnPrc = preChargedDataSelectResultWork.FracProcUnitSalUnPrc;
            //salesDetail.FracProcSalUnPrc = preChargedDataSelectResultWork.FracProcSalUnPrc;
            //salesDetail.SalesUnPrcTaxIncFl = preChargedDataSelectResultWork.SalesUnPrcTaxIncFl;
            //salesDetail.SalesUnPrcTaxExcFl = preChargedDataSelectResultWork.SalesUnPrcTaxExcFl;
            //salesDetail.SalesUnPrcChngCd = preChargedDataSelectResultWork.SalesUnPrcChngCd;
            //salesDetail.CostRate = preChargedDataSelectResultWork.CostRate;
            //salesDetail.RateDivUnCst = preChargedDataSelectResultWork.RateDivUnCst;
            //salesDetail.UnPrcCalcCdUnCst = preChargedDataSelectResultWork.UnPrcCalcCdUnCst;
            //salesDetail.PriceCdUnCst = preChargedDataSelectResultWork.PriceCdUnCst;
            //salesDetail.StdUnPrcUnCst = preChargedDataSelectResultWork.StdUnPrcUnCst;
            //salesDetail.FracProcUnitUnCst = preChargedDataSelectResultWork.FracProcUnitUnCst;
            //salesDetail.FracProcUnCst = preChargedDataSelectResultWork.FracProcUnCst;
            //salesDetail.SalesUnitCost = preChargedDataSelectResultWork.SalesUnitCost;
            //salesDetail.SalesUnitCostChngDiv = preChargedDataSelectResultWork.SalesUnitCostChngDiv;
            //salesDetail.BargainCd = preChargedDataSelectResultWork.BargainCd;
            //salesDetail.BargainNm = preChargedDataSelectResultWork.BargainNm;
            //salesDetail.ShipmentCnt = preChargedDataSelectResultWork.ShipmentCnt;
            //salesDetail.SalesMoneyTaxInc = preChargedDataSelectResultWork.SalesMoneyTaxInc;
            //salesDetail.SalesMoneyTaxExc = preChargedDataSelectResultWork.SalesMoneyTaxExc;
            //salesDetail.Cost = preChargedDataSelectResultWork.Cost;
            //salesDetail.GrsProfitChkDiv = preChargedDataSelectResultWork.GrsProfitChkDiv;
            //salesDetail.SalesGoodsCd = preChargedDataSelectResultWork.SalesGoodsCd;
            //salesDetail.TaxAdjust = preChargedDataSelectResultWork.TaxAdjust;
            //salesDetail.BalanceAdjust = preChargedDataSelectResultWork.BalanceAdjust;
            //salesDetail.TaxationDivCd = preChargedDataSelectResultWork.TaxationDivCd;
            //salesDetail.PartySlipNumDtl = preChargedDataSelectResultWork.PartySlipNumDtl;
            //salesDetail.DtlNote = preChargedDataSelectResultWork.DtlNote;
            //salesDetail.SupplierCd = preChargedDataSelectResultWork.SupplierCd;
            //salesDetail.SupplierSnm = preChargedDataSelectResultWork.SupplierSnm;
            //salesDetail.ResultsAddUpSecCd = preChargedDataSelectResultWork.ResultsAddUpSecCd;
            //salesDetail.OrderNumber = preChargedDataSelectResultWork.OrderNumber;
            //salesDetail.SlipMemo1 = preChargedDataSelectResultWork.SlipMemo1;
            //salesDetail.SlipMemo2 = preChargedDataSelectResultWork.SlipMemo2;
            //salesDetail.SlipMemo3 = preChargedDataSelectResultWork.SlipMemo3;
            //salesDetail.SlipMemo4 = preChargedDataSelectResultWork.SlipMemo4;
            //salesDetail.SlipMemo5 = preChargedDataSelectResultWork.SlipMemo5;
            //salesDetail.SlipMemo6 = preChargedDataSelectResultWork.SlipMemo6;
            //salesDetail.InsideMemo1 = preChargedDataSelectResultWork.InsideMemo1;
            //salesDetail.InsideMemo2 = preChargedDataSelectResultWork.InsideMemo2;
            //salesDetail.InsideMemo3 = preChargedDataSelectResultWork.InsideMemo3;
            //salesDetail.InsideMemo4 = preChargedDataSelectResultWork.InsideMemo4;
            //salesDetail.InsideMemo5 = preChargedDataSelectResultWork.InsideMemo5;
            //salesDetail.InsideMemo6 = preChargedDataSelectResultWork.InsideMemo6;
            //salesDetail.BfListPrice = preChargedDataSelectResultWork.BfListPrice;
            //salesDetail.BfSalesUnitPrice = preChargedDataSelectResultWork.BfSalesUnitPrice;
            //salesDetail.BfUnitCost = preChargedDataSelectResultWork.BfUnitCost;
            //salesDetail.PrtGoodsNo = preChargedDataSelectResultWork.PrtGoodsNo;
            //salesDetail.PrtGoodsName = preChargedDataSelectResultWork.PrtGoodsName;
            //salesDetail.PrtGoodsMakerCd = preChargedDataSelectResultWork.PrtGoodsMakerCd;
            //salesDetail.PrtGoodsMakerNm = preChargedDataSelectResultWork.PrtGoodsMakerNm;
            return salesDetail;
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="acptAnOdrRemainRefDataList">�󒍏Ɖ�[�N�I�u�W�F�N�g���X�g(���בI��)</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g���X�g</returns>
        private static List<SalesDetail> UIDataFromParamDataProc(List<AcptAnOdrRemainRefData> acptAnOdrRemainRefDataList)
        {
            if (acptAnOdrRemainRefDataList == null) return null;

            List<SalesDetail> salesDetailList = new List<SalesDetail>();

            foreach (AcptAnOdrRemainRefData acptAnOdrRemainRefData in acptAnOdrRemainRefDataList)
            {
                salesDetailList.Add(UIDataFromParamData(acptAnOdrRemainRefData));
            }

            return salesDetailList;
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="salHisRefResultParamWork">�󒍏Ɖ�[�N�I�u�W�F�N�g(���בI��)</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g</returns>
        private static SalesDetail UIDataFromParamDataProc(AcptAnOdrRemainRefData acptAnOdrRemainRefData)
        {
            SalesDetail salesDetail = new SalesDetail();
            //salesDetail.EnterpriseCode = acptAnOdrRemainRefData.EnterpriseCode;
            //salesDetail.AcceptAnOrderNo = acptAnOdrRemainRefData.AcceptAnOrderNo;
            //salesDetail.AcptAnOdrStatus = acptAnOdrRemainRefData.AcptAnOdrStatus;
            //salesDetail.SalesSlipNum = acptAnOdrRemainRefData.SalesSlipNum;
            //salesDetail.SalesDate = acptAnOdrRemainRefData.SalesDate;
            //salesDetail.CommonSeqNo = acptAnOdrRemainRefData.CommonSeqNo;
            //salesDetail.SalesSlipDtlNum = acptAnOdrRemainRefData.SalesSlipDtlNum;
            //salesDetail.MakerName = acptAnOdrRemainRefData.MakerName;
            //salesDetail.GoodsNo = acptAnOdrRemainRefData.GoodsNo;
            //salesDetail.GoodsName = acptAnOdrRemainRefData.GoodsName;
            //salesDetail.UnitName = acptAnOdrRemainRefData.UnitName;
            //salesDetail.StdUnPrcSalUnPrc = acptAnOdrRemainRefData.StdUnPrcSalUnPrc;
            //salesDetail.SalesUnPrcTaxExcFl = acptAnOdrRemainRefData.SalesUnPrcTaxExcFl;
            //salesDetail.SalesUnitCost = acptAnOdrRemainRefData.SalesUnitCost;
            //salesDetail.BargainNm = acptAnOdrRemainRefData.BargainNm;
            //salesDetail.PartySlipNumDtl = acptAnOdrRemainRefData.PartySlipNumDtl;
            //salesDetail.DtlNote = acptAnOdrRemainRefData.DtlNote;
            //salesDetail.SupplierSnm = acptAnOdrRemainRefData.SupplierSnm;
            //salesDetail.OrderNumber = acptAnOdrRemainRefData.OrderNumber;
            //salesDetail.SlipMemo1 = acptAnOdrRemainRefData.SlipMemo1;
            //salesDetail.SlipMemo2 = acptAnOdrRemainRefData.SlipMemo2;
            //salesDetail.SlipMemo3 = acptAnOdrRemainRefData.SlipMemo3;
            //salesDetail.SlipMemo4 = acptAnOdrRemainRefData.SlipMemo4;
            //salesDetail.SlipMemo5 = acptAnOdrRemainRefData.SlipMemo5;
            //salesDetail.SlipMemo6 = acptAnOdrRemainRefData.SlipMemo6;
            //salesDetail.InsideMemo1 = acptAnOdrRemainRefData.InsideMemo1;
            //salesDetail.InsideMemo2 = acptAnOdrRemainRefData.InsideMemo2;
            //salesDetail.InsideMemo3 = acptAnOdrRemainRefData.InsideMemo3;
            //salesDetail.InsideMemo4 = acptAnOdrRemainRefData.InsideMemo4;
            //salesDetail.InsideMemo5 = acptAnOdrRemainRefData.InsideMemo5;
            //salesDetail.InsideMemo6 = acptAnOdrRemainRefData.InsideMemo6;
            return salesDetail;
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="addUppSrcStockDetailWorkList">�v�㌳�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g���X�g</returns>
        private static List<SalesDetail> UIDataFromParamDataProc(AddUpOrgSalesDetailWork[] addUpSrcSalesDetailWorkList)
        {
            if (addUpSrcSalesDetailWorkList == null) return null;

            List<SalesDetail> addUpOrgSalesDetailList = new List<SalesDetail>();

            foreach (AddUpOrgSalesDetailWork addUpSrcSalesDetailWork in addUpSrcSalesDetailWorkList)
            {
                addUpOrgSalesDetailList.Add(UIDataFromParamData((SalesDetailWork)addUpSrcSalesDetailWork));
            }

            return addUpOrgSalesDetailList;
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <returns>����f�[�^�I�u�W�F�N�g</returns>
        private static SalesSlip UIDataFromParamDataProc(SalesSlipWork salesSlipWork)
        {
            if (salesSlipWork == null) return null;  // --- ADD 2015/08/22 �����M Redmine#47045

            SalesSlip salesSlip = new SalesSlip();

            salesSlip.CreateDateTime = salesSlipWork.CreateDateTime; // �쐬����
            salesSlip.UpdateDateTime = salesSlipWork.UpdateDateTime; // �X�V����
            salesSlip.EnterpriseCode = salesSlipWork.EnterpriseCode; // ��ƃR�[�h
            salesSlip.FileHeaderGuid = salesSlipWork.FileHeaderGuid; // GUID
            salesSlip.UpdEmployeeCode = salesSlipWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            salesSlip.UpdAssemblyId1 = salesSlipWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            salesSlip.UpdAssemblyId2 = salesSlipWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            salesSlip.LogicalDeleteCode = salesSlipWork.LogicalDeleteCode; // �_���폜�敪
            salesSlip.AcptAnOdrStatus = salesSlipWork.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            salesSlip.SalesSlipNum = salesSlipWork.SalesSlipNum; // ����`�[�ԍ�
            salesSlip.SectionCode = salesSlipWork.SectionCode; // ���_�R�[�h
            salesSlip.SubSectionCode = salesSlipWork.SubSectionCode; // ����R�[�h
            salesSlip.DebitNoteDiv = salesSlipWork.DebitNoteDiv; // �ԓ`�敪
            salesSlip.DebitNLnkSalesSlNum = salesSlipWork.DebitNLnkSalesSlNum; // �ԍ��A������`�[�ԍ�
            salesSlip.SalesSlipCd = salesSlipWork.SalesSlipCd; // ����`�[�敪
            salesSlip.SalesGoodsCd = salesSlipWork.SalesGoodsCd; // ���㏤�i�敪
            salesSlip.AccRecDivCd = salesSlipWork.AccRecDivCd; // ���|�敪
            salesSlip.SalesInpSecCd = salesSlipWork.SalesInpSecCd; // ������͋��_�R�[�h
            salesSlip.DemandAddUpSecCd = salesSlipWork.DemandAddUpSecCd; // �����v�㋒�_�R�[�h
            salesSlip.ResultsAddUpSecCd = salesSlipWork.ResultsAddUpSecCd; // ���ьv�㋒�_�R�[�h
            salesSlip.UpdateSecCd = salesSlipWork.UpdateSecCd; // �X�V���_�R�[�h
            salesSlip.SalesSlipUpdateCd = salesSlipWork.SalesSlipUpdateCd; // ����`�[�X�V�敪
            salesSlip.SearchSlipDate = salesSlipWork.SearchSlipDate; // �`�[�������t
            salesSlip.ShipmentDay = salesSlipWork.ShipmentDay; // �o�ד��t
            salesSlip.SalesDate = salesSlipWork.SalesDate; // ������t
            salesSlip.AddUpADate = salesSlipWork.AddUpADate; // �v����t
            salesSlip.DelayPaymentDiv = salesSlipWork.DelayPaymentDiv; // �����敪
            salesSlip.EstimateFormNo = salesSlipWork.EstimateFormNo; // ���Ϗ��ԍ�
            salesSlip.EstimateDivide = salesSlipWork.EstimateDivide; // ���ϋ敪
            salesSlip.InputAgenCd = salesSlipWork.InputAgenCd; // ���͒S���҃R�[�h
            salesSlip.InputAgenNm = salesSlipWork.InputAgenNm; // ���͒S���Җ���
            salesSlip.SalesInputCode = salesSlipWork.SalesInputCode; // ������͎҃R�[�h
            salesSlip.SalesInputName = salesSlipWork.SalesInputName; // ������͎Җ���
            salesSlip.FrontEmployeeCd = salesSlipWork.FrontEmployeeCd; // ��t�]�ƈ��R�[�h
            salesSlip.FrontEmployeeNm = salesSlipWork.FrontEmployeeNm; // ��t�]�ƈ�����
            salesSlip.SalesEmployeeCd = salesSlipWork.SalesEmployeeCd; // �̔��]�ƈ��R�[�h
            salesSlip.SalesEmployeeNm = salesSlipWork.SalesEmployeeNm; // �̔��]�ƈ�����
            salesSlip.TotalAmountDispWayCd = salesSlipWork.TotalAmountDispWayCd; // ���z�\�����@�敪
            salesSlip.TtlAmntDispRateApy = salesSlipWork.TtlAmntDispRateApy; // ���z�\���|���K�p�敪
            salesSlip.SalesTotalTaxInc = salesSlipWork.SalesTotalTaxInc; // ����`�[���v�i�ō��݁j
            salesSlip.SalesTotalTaxExc = salesSlipWork.SalesTotalTaxExc; // ����`�[���v�i�Ŕ����j
            salesSlip.SalesPrtTotalTaxInc = salesSlipWork.SalesPrtTotalTaxInc; // ���㕔�i���v�i�ō��݁j
            salesSlip.SalesPrtTotalTaxExc = salesSlipWork.SalesPrtTotalTaxExc; // ���㕔�i���v�i�Ŕ����j
            salesSlip.SalesWorkTotalTaxInc = salesSlipWork.SalesWorkTotalTaxInc; // �����ƍ��v�i�ō��݁j
            salesSlip.SalesWorkTotalTaxExc = salesSlipWork.SalesWorkTotalTaxExc; // �����ƍ��v�i�Ŕ����j
            salesSlip.SalesSubtotalTaxInc = salesSlipWork.SalesSubtotalTaxInc; // ���㏬�v�i�ō��݁j
            salesSlip.SalesSubtotalTaxExc = salesSlipWork.SalesSubtotalTaxExc; // ���㏬�v�i�Ŕ����j
            salesSlip.SalesPrtSubttlInc = salesSlipWork.SalesPrtSubttlInc; // ���㕔�i���v�i�ō��݁j
            salesSlip.SalesPrtSubttlExc = salesSlipWork.SalesPrtSubttlExc; // ���㕔�i���v�i�Ŕ����j
            salesSlip.SalesWorkSubttlInc = salesSlipWork.SalesWorkSubttlInc; // �����Ə��v�i�ō��݁j
            salesSlip.SalesWorkSubttlExc = salesSlipWork.SalesWorkSubttlExc; // �����Ə��v�i�Ŕ����j
            salesSlip.SalesNetPrice = salesSlipWork.SalesNetPrice; // ���㐳�����z
            salesSlip.SalesSubtotalTax = salesSlipWork.SalesSubtotalTax; // ���㏬�v�i�Łj
            salesSlip.ItdedSalesOutTax = salesSlipWork.ItdedSalesOutTax; // ����O�őΏۊz
            salesSlip.ItdedSalesInTax = salesSlipWork.ItdedSalesInTax; // ������őΏۊz
            salesSlip.SalSubttlSubToTaxFre = salesSlipWork.SalSubttlSubToTaxFre; // ���㏬�v��ېőΏۊz
            salesSlip.SalesOutTax = salesSlipWork.SalesOutTax; // ������z����Ŋz�i�O�Łj
            salesSlip.SalAmntConsTaxInclu = salesSlipWork.SalAmntConsTaxInclu; // ������z����Ŋz�i���Łj
            salesSlip.SalesDisTtlTaxExc = salesSlipWork.SalesDisTtlTaxExc; // ����l�����z�v�i�Ŕ����j
            salesSlip.ItdedSalesDisOutTax = salesSlipWork.ItdedSalesDisOutTax; // ����l���O�őΏۊz���v
            salesSlip.ItdedSalesDisInTax = salesSlipWork.ItdedSalesDisInTax; // ����l�����őΏۊz���v
            salesSlip.ItdedPartsDisOutTax = salesSlipWork.ItdedPartsDisOutTax; // ���i�l���Ώۊz���v�i�Ŕ����j
            salesSlip.ItdedPartsDisInTax = salesSlipWork.ItdedPartsDisInTax; // ���i�l���Ώۊz���v�i�ō��݁j
            salesSlip.ItdedWorkDisOutTax = salesSlipWork.ItdedWorkDisOutTax; // ��ƒl���Ώۊz���v�i�Ŕ����j
            salesSlip.ItdedWorkDisInTax = salesSlipWork.ItdedWorkDisInTax; // ��ƒl���Ώۊz���v�i�ō��݁j
            salesSlip.ItdedSalesDisTaxFre = salesSlipWork.ItdedSalesDisTaxFre; // ����l����ېőΏۊz���v
            salesSlip.SalesDisOutTax = salesSlipWork.SalesDisOutTax; // ����l������Ŋz�i�O�Łj
            salesSlip.SalesDisTtlTaxInclu = salesSlipWork.SalesDisTtlTaxInclu; // ����l������Ŋz�i���Łj
            salesSlip.PartsDiscountRate = salesSlipWork.PartsDiscountRate; // ���i�l����
            salesSlip.RavorDiscountRate = salesSlipWork.RavorDiscountRate; // �H���l����
            salesSlip.TotalCost = salesSlipWork.TotalCost; // �������z�v
            salesSlip.ConsTaxLayMethod = salesSlipWork.ConsTaxLayMethod; // ����œ]�ŕ���
            salesSlip.ConsTaxRate = salesSlipWork.ConsTaxRate; // ����Őŗ�
            salesSlip.FractionProcCd = salesSlipWork.FractionProcCd; // �[�������敪
            salesSlip.AccRecConsTax = salesSlipWork.AccRecConsTax; // ���|�����
            salesSlip.AutoDepositCd = salesSlipWork.AutoDepositCd; // ���������敪
            salesSlip.AutoDepositNoteDiv = salesSlipWork.AutoDepositNoteDiv; // �����������l�敪 // ADD 2013/01/18 �c���� Redmine#33797
            salesSlip.AutoDepositSlipNo = salesSlipWork.AutoDepositSlipNo; // ���������`�[�ԍ�
            salesSlip.DepositAllowanceTtl = salesSlipWork.DepositAllowanceTtl; // �����������v�z
            salesSlip.DepositAlwcBlnce = salesSlipWork.DepositAlwcBlnce; // ���������c��
            salesSlip.ClaimCode = salesSlipWork.ClaimCode; // ������R�[�h
            salesSlip.ClaimSnm = salesSlipWork.ClaimSnm; // �����旪��
            salesSlip.CustomerCode = salesSlipWork.CustomerCode; // ���Ӑ�R�[�h
            salesSlip.CustomerName = salesSlipWork.CustomerName; // ���Ӑ於��
            salesSlip.CustomerName2 = salesSlipWork.CustomerName2; // ���Ӑ於��2
            salesSlip.CustomerSnm = salesSlipWork.CustomerSnm; // ���Ӑ旪��
            salesSlip.HonorificTitle = salesSlipWork.HonorificTitle; // �h��
            salesSlip.OutputNameCode = salesSlipWork.OutputNameCode; // �����R�[�h
            salesSlip.OutputName = salesSlipWork.OutputName; // ��������
            salesSlip.CustSlipNo = salesSlipWork.CustSlipNo; // ���Ӑ�`�[�ԍ�
            salesSlip.SlipAddressDiv = salesSlipWork.SlipAddressDiv; // �`�[�Z���敪
            salesSlip.AddresseeCode = salesSlipWork.AddresseeCode; // �[�i��R�[�h
            salesSlip.AddresseeName = salesSlipWork.AddresseeName; // �[�i�於��
            salesSlip.AddresseeName2 = salesSlipWork.AddresseeName2; // �[�i�於��2
            salesSlip.AddresseePostNo = salesSlipWork.AddresseePostNo; // �[�i��X�֔ԍ�
            salesSlip.AddresseeAddr1 = salesSlipWork.AddresseeAddr1; // �[�i��Z��1(�s���{���s��S�E�����E��)
            salesSlip.AddresseeAddr3 = salesSlipWork.AddresseeAddr3; // �[�i��Z��3(�Ԓn)
            salesSlip.AddresseeAddr4 = salesSlipWork.AddresseeAddr4; // �[�i��Z��4(�A�p�[�g����)
            salesSlip.AddresseeTelNo = salesSlipWork.AddresseeTelNo; // �[�i��d�b�ԍ�
            salesSlip.AddresseeFaxNo = salesSlipWork.AddresseeFaxNo; // �[�i��FAX�ԍ�
            salesSlip.PartySaleSlipNum = salesSlipWork.PartySaleSlipNum; // �����`�[�ԍ�
            salesSlip.SlipNote = salesSlipWork.SlipNote; // �`�[���l
            salesSlip.SlipNote2 = salesSlipWork.SlipNote2; // �`�[���l�Q
            salesSlip.SlipNote3 = salesSlipWork.SlipNote3; // �`�[���l�R
            salesSlip.RetGoodsReasonDiv = salesSlipWork.RetGoodsReasonDiv; // �ԕi���R�R�[�h
            salesSlip.RetGoodsReason = salesSlipWork.RetGoodsReason; // �ԕi���R
            salesSlip.RegiProcDate = salesSlipWork.RegiProcDate; // ���W������
            salesSlip.CashRegisterNo = salesSlipWork.CashRegisterNo; // ���W�ԍ�
            salesSlip.PosReceiptNo = salesSlipWork.PosReceiptNo; // POS���V�[�g�ԍ�
            salesSlip.DetailRowCount = salesSlipWork.DetailRowCount; // ���׍s��
            salesSlip.EdiSendDate = salesSlipWork.EdiSendDate; // �d�c�h���M��
            salesSlip.EdiTakeInDate = salesSlipWork.EdiTakeInDate; // �d�c�h�捞��
            salesSlip.UoeRemark1 = salesSlipWork.UoeRemark1; // �t�n�d���}�[�N�P
            salesSlip.UoeRemark2 = salesSlipWork.UoeRemark2; // �t�n�d���}�[�N�Q
            salesSlip.SlipPrintDivCd = salesSlipWork.SlipPrintDivCd; // �`�[���s�敪
            salesSlip.SlipPrintFinishCd = salesSlipWork.SlipPrintFinishCd; // �`�[���s�ϋ敪
            salesSlip.SalesSlipPrintDate = salesSlipWork.SalesSlipPrintDate; // ����`�[���s��
            salesSlip.BusinessTypeCode = salesSlipWork.BusinessTypeCode; // �Ǝ�R�[�h
            salesSlip.BusinessTypeName = salesSlipWork.BusinessTypeName; // �Ǝ햼��
            salesSlip.OrderNumber = salesSlipWork.OrderNumber; // �����ԍ�
            salesSlip.DeliveredGoodsDiv = salesSlipWork.DeliveredGoodsDiv; // �[�i�敪
            salesSlip.DeliveredGoodsDivNm = salesSlipWork.DeliveredGoodsDivNm; // �[�i�敪����
            salesSlip.SalesAreaCode = salesSlipWork.SalesAreaCode; // �̔��G���A�R�[�h
            salesSlip.SalesAreaName = salesSlipWork.SalesAreaName; // �̔��G���A����
            salesSlip.ReconcileFlag = salesSlipWork.ReconcileFlag; // �����t���O
            salesSlip.SlipPrtSetPaperId = salesSlipWork.SlipPrtSetPaperId; // �`�[����ݒ�p���[ID
            salesSlip.CompleteCd = salesSlipWork.CompleteCd; // �ꎮ�`�[�敪
            salesSlip.SalesPriceFracProcCd = salesSlipWork.SalesPriceFracProcCd; // ������z�[�������敪
            salesSlip.StockGoodsTtlTaxExc = salesSlipWork.StockGoodsTtlTaxExc; // �݌ɏ��i���v���z�i�Ŕ��j
            salesSlip.PureGoodsTtlTaxExc = salesSlipWork.PureGoodsTtlTaxExc; // �������i���v���z�i�Ŕ��j
            salesSlip.ListPricePrintDiv = salesSlipWork.ListPricePrintDiv; // �艿����敪
            salesSlip.EraNameDispCd1 = salesSlipWork.EraNameDispCd1; // �����\���敪�P
            salesSlip.EstimaTaxDivCd = salesSlipWork.EstimaTaxDivCd; // ���Ϗ���ŋ敪
            salesSlip.EstimateFormPrtCd = salesSlipWork.EstimateFormPrtCd; // ���Ϗ�����敪
            salesSlip.EstimateSubject = salesSlipWork.EstimateSubject; // ���ό���
            salesSlip.Footnotes1 = salesSlipWork.Footnotes1; // �r���P
            salesSlip.Footnotes2 = salesSlipWork.Footnotes2; // �r���Q
            salesSlip.EstimateTitle1 = salesSlipWork.EstimateTitle1; // ���σ^�C�g���P
            salesSlip.EstimateTitle2 = salesSlipWork.EstimateTitle2; // ���σ^�C�g���Q
            salesSlip.EstimateTitle3 = salesSlipWork.EstimateTitle3; // ���σ^�C�g���R
            salesSlip.EstimateTitle4 = salesSlipWork.EstimateTitle4; // ���σ^�C�g���S
            salesSlip.EstimateTitle5 = salesSlipWork.EstimateTitle5; // ���σ^�C�g���T
            salesSlip.EstimateNote1 = salesSlipWork.EstimateNote1; // ���ϔ��l�P
            salesSlip.EstimateNote2 = salesSlipWork.EstimateNote2; // ���ϔ��l�Q
            salesSlip.EstimateNote3 = salesSlipWork.EstimateNote3; // ���ϔ��l�R
            salesSlip.EstimateNote4 = salesSlipWork.EstimateNote4; // ���ϔ��l�S
            salesSlip.EstimateNote5 = salesSlipWork.EstimateNote5; // ���ϔ��l�T
            salesSlip.EstimateValidityDate = salesSlipWork.EstimateValidityDate; // ���ϗL������
            salesSlip.PartsNoPrtCd = salesSlipWork.PartsNoPrtCd; // �i�Ԉ󎚋敪
            salesSlip.OptionPringDivCd = salesSlipWork.OptionPringDivCd; // �I�v�V�����󎚋敪
            salesSlip.RateUseCode = salesSlipWork.RateUseCode; // �|���g�p�敪
            //salesSlip.InputMode = salesSlipWork.InputMode; // ���̓��[�h
            //salesSlip.SalesSlipDisplay = salesSlipWork.SalesSlipDisplay; // ����`�[�敪(��ʕ\���p)
            //salesSlip.AcptAnOdrStatusDisplay = salesSlipWork.AcptAnOdrStatusDisplay; // �󒍃X�e�[�^�X
            //salesSlip.CustRateGrpCode = salesSlipWork.CustRateGrpCode; // ���Ӑ�|���O���[�v�R�[�h
            //salesSlip.ClaimName = salesSlipWork.ClaimName; // �����於��
            //salesSlip.ClaimName2 = salesSlipWork.ClaimName2; // �����於�̂Q
            //salesSlip.CreditMngCode = salesSlipWork.CreditMngCode; // �^�M�Ǘ��敪
            //salesSlip.TotalDay = salesSlipWork.TotalDay; // ����
            //salesSlip.NTimeCalcStDate = salesSlipWork.NTimeCalcStDate; // ���񊨒�J�n��
            //salesSlip.TotalMoneyForGrossProfit = salesSlipWork.TotalMoneyForGrossProfit; // �e���v�Z�p������z
            //salesSlip.AcceptAnOrderDate = salesSlipWork.AcceptAnOrderDate; // �󒍓�
            //salesSlip.SectionName = salesSlipWork.SectionName; // ���_����
            //salesSlip.SubSectionName = salesSlipWork.SubSectionName; // ���喼��
            //salesSlip.CarMngDivCd = salesSlipWork.CarMngDivCd; // ���q�Ǘ��敪
            //salesSlip.SearchMode = salesSlipWork.SearchMode; // ���i�������[�h
            //salesSlip.SearchCarMode = salesSlipWork.SearchCarMode; // �ԗ��������[�h
            //salesSlip.CustOrderNoDispDiv = salesSlipWork.CustOrderNoDispDiv; // ���Ӑ撍�ԕ\���敪

            return salesSlip;
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g���X�g</returns>
        private static List<SalesDetail> UIDataFromParamDataProc(SalesDetailWork[] salesDetailWorkArray)
        {
            if (salesDetailWorkArray == null) return null;

            List<SalesDetail> salesDetailList = new List<SalesDetail>();

            foreach (SalesDetailWork salesDetailWork in salesDetailWorkArray)
            {
                salesDetailList.Add(UIDataFromParamData(salesDetailWork));
            }

            return salesDetailList;
        }

        //>>>2010/02/26
        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="salesDetailWorkList">���㖾�׃f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g���X�g</returns>
        private static List<SalesDetail> UIDataFromParamDataProc(List<SalesDetailWork> salesDetailWorkList)
        {
            if (salesDetailWorkList == null) return null;

            List<SalesDetail> salesDetailList = new List<SalesDetail>();

            foreach (SalesDetailWork salesDetailWork in salesDetailWorkList)
            {
                salesDetailList.Add(UIDataFromParamData(salesDetailWork));
            }

            return salesDetailList;
        }
        //<<<2010/02/26

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="salesDetailWork">���㖾�׃f�[�^���[�N�I�u�W�F�N�g</param>
        /// <returns>���㖾�׃f�[�^�I�u�W�F�N�g</returns>
        private static SalesDetail UIDataFromParamDataProc(SalesDetailWork salesDetailWork)
        {
            SalesDetail salesDetail = new SalesDetail();

            salesDetail.CreateDateTime = salesDetailWork.CreateDateTime; // �쐬����
            salesDetail.UpdateDateTime = salesDetailWork.UpdateDateTime; // �X�V����
            salesDetail.EnterpriseCode = salesDetailWork.EnterpriseCode; // ��ƃR�[�h
            salesDetail.FileHeaderGuid = salesDetailWork.FileHeaderGuid; // GUID
            salesDetail.UpdEmployeeCode = salesDetailWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            salesDetail.UpdAssemblyId1 = salesDetailWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            salesDetail.UpdAssemblyId2 = salesDetailWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            salesDetail.LogicalDeleteCode = salesDetailWork.LogicalDeleteCode; // �_���폜�敪
            salesDetail.AcceptAnOrderNo = salesDetailWork.AcceptAnOrderNo; // �󒍔ԍ�
            salesDetail.AcptAnOdrStatus = salesDetailWork.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            salesDetail.SalesSlipNum = salesDetailWork.SalesSlipNum; // ����`�[�ԍ�
            salesDetail.SalesRowNo = salesDetailWork.SalesRowNo; // ����s�ԍ�
            salesDetail.SalesRowDerivNo = salesDetailWork.SalesRowDerivNo; // ����s�ԍ��}��
            salesDetail.SectionCode = salesDetailWork.SectionCode; // ���_�R�[�h
            salesDetail.SubSectionCode = salesDetailWork.SubSectionCode; // ����R�[�h
            salesDetail.SalesDate = salesDetailWork.SalesDate; // ������t
            salesDetail.CommonSeqNo = salesDetailWork.CommonSeqNo; // ���ʒʔ�
            salesDetail.SalesSlipDtlNum = salesDetailWork.SalesSlipDtlNum; // ���㖾�גʔ�
            salesDetail.AcptAnOdrStatusSrc = salesDetailWork.AcptAnOdrStatusSrc; // �󒍃X�e�[�^�X�i���j
            salesDetail.SalesSlipDtlNumSrc = salesDetailWork.SalesSlipDtlNumSrc; // ���㖾�גʔԁi���j
            salesDetail.SupplierFormalSync = salesDetailWork.SupplierFormalSync; // �d���`���i�����j
            salesDetail.StockSlipDtlNumSync = salesDetailWork.StockSlipDtlNumSync; // �d�����גʔԁi�����j
            salesDetail.SalesSlipCdDtl = salesDetailWork.SalesSlipCdDtl; // ����`�[�敪�i���ׁj
            salesDetail.DeliGdsCmpltDueDate = salesDetailWork.DeliGdsCmpltDueDate; // �[�i�����\���
            salesDetail.GoodsKindCode = salesDetailWork.GoodsKindCode; // ���i����
            salesDetail.GoodsSearchDivCd = salesDetailWork.GoodsSearchDivCd; // ���i�����敪
            salesDetail.GoodsMakerCd = salesDetailWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
            salesDetail.MakerName = salesDetailWork.MakerName; // ���[�J�[����
            salesDetail.MakerKanaName = salesDetailWork.MakerKanaName; // ���[�J�[�J�i����
            salesDetail.CmpltMakerKanaName = salesDetailWork.CmpltMakerKanaName; // ���[�J�[�J�i���́i�ꎮ�j
            salesDetail.GoodsNo = salesDetailWork.GoodsNo; // ���i�ԍ�
            salesDetail.GoodsName = salesDetailWork.GoodsName; // ���i����
            salesDetail.GoodsNameKana = salesDetailWork.GoodsNameKana; // ���i���̃J�i
            salesDetail.GoodsLGroup = salesDetailWork.GoodsLGroup; // ���i�啪�ރR�[�h
            salesDetail.GoodsLGroupName = salesDetailWork.GoodsLGroupName; // ���i�啪�ޖ���
            salesDetail.GoodsMGroup = salesDetailWork.GoodsMGroup; // ���i�����ރR�[�h
            salesDetail.GoodsMGroupName = salesDetailWork.GoodsMGroupName; // ���i�����ޖ���
            salesDetail.BLGroupCode = salesDetailWork.BLGroupCode; // BL�O���[�v�R�[�h
            salesDetail.BLGroupName = salesDetailWork.BLGroupName; // BL�O���[�v�R�[�h����
            salesDetail.BLGoodsCode = salesDetailWork.BLGoodsCode; // BL���i�R�[�h
            salesDetail.BLGoodsFullName = salesDetailWork.BLGoodsFullName; // BL���i�R�[�h���́i�S�p�j
            salesDetail.EnterpriseGanreCode = salesDetailWork.EnterpriseGanreCode; // ���Е��ރR�[�h
            salesDetail.EnterpriseGanreName = salesDetailWork.EnterpriseGanreName; // ���Е��ޖ���
            salesDetail.WarehouseCode = salesDetailWork.WarehouseCode; // �q�ɃR�[�h
            salesDetail.WarehouseName = salesDetailWork.WarehouseName; // �q�ɖ���
            salesDetail.WarehouseShelfNo = salesDetailWork.WarehouseShelfNo; // �q�ɒI��
            salesDetail.SalesOrderDivCd = salesDetailWork.SalesOrderDivCd; // ����݌Ɏ�񂹋敪
            salesDetail.OpenPriceDiv = salesDetailWork.OpenPriceDiv; // �I�[�v�����i�敪
            salesDetail.GoodsRateRank = salesDetailWork.GoodsRateRank; // ���i�|�������N
            salesDetail.CustRateGrpCode = salesDetailWork.CustRateGrpCode; // ���Ӑ�|���O���[�v�R�[�h
            salesDetail.ListPriceRate = salesDetailWork.ListPriceRate; // �艿��
            salesDetail.RateSectPriceUnPrc = salesDetailWork.RateSectPriceUnPrc; // �|���ݒ苒�_�i�艿�j
            salesDetail.RateDivLPrice = salesDetailWork.RateDivLPrice; // �|���ݒ�敪�i�艿�j
            salesDetail.PriceSelectDiv = -1; // �W�����i�I���敪�i�艿�j// ADD 2013/01/24 ���N�n�� REDMINE#34605
            salesDetail.UnPrcCalcCdLPrice = salesDetailWork.UnPrcCalcCdLPrice; // �P���Z�o�敪�i�艿�j
            salesDetail.PriceCdLPrice = salesDetailWork.PriceCdLPrice; // ���i�敪�i�艿�j
            salesDetail.StdUnPrcLPrice = salesDetailWork.StdUnPrcLPrice; // ��P���i�艿�j
            salesDetail.FracProcUnitLPrice = salesDetailWork.FracProcUnitLPrice; // �[�������P�ʁi�艿�j
            salesDetail.FracProcLPrice = salesDetailWork.FracProcLPrice; // �[�������i�艿�j
            salesDetail.ListPriceTaxIncFl = salesDetailWork.ListPriceTaxIncFl; // �艿�i�ō��C�����j
            salesDetail.ListPriceTaxExcFl = salesDetailWork.ListPriceTaxExcFl; // �艿�i�Ŕ��C�����j
            salesDetail.ListPriceChngCd = salesDetailWork.ListPriceChngCd; // �艿�ύX�敪
            salesDetail.SalesRate = salesDetailWork.SalesRate; // ������
            salesDetail.RateSectSalUnPrc = salesDetailWork.RateSectSalUnPrc; // �|���ݒ苒�_�i����P���j
            salesDetail.RateDivSalUnPrc = salesDetailWork.RateDivSalUnPrc; // �|���ݒ�敪�i����P���j
            salesDetail.UnPrcCalcCdSalUnPrc = salesDetailWork.UnPrcCalcCdSalUnPrc; // �P���Z�o�敪�i����P���j
            salesDetail.PriceCdSalUnPrc = salesDetailWork.PriceCdSalUnPrc; // ���i�敪�i����P���j
            salesDetail.StdUnPrcSalUnPrc = salesDetailWork.StdUnPrcSalUnPrc; // ��P���i����P���j
            salesDetail.FracProcUnitSalUnPrc = salesDetailWork.FracProcUnitSalUnPrc; // �[�������P�ʁi����P���j
            salesDetail.FracProcSalUnPrc = salesDetailWork.FracProcSalUnPrc; // �[�������i����P���j
            salesDetail.SalesUnPrcTaxIncFl = salesDetailWork.SalesUnPrcTaxIncFl; // ����P���i�ō��C�����j
            salesDetail.SalesUnPrcTaxExcFl = salesDetailWork.SalesUnPrcTaxExcFl; // ����P���i�Ŕ��C�����j
            salesDetail.SalesUnPrcChngCd = salesDetailWork.SalesUnPrcChngCd; // ����P���ύX�敪
            salesDetail.CostRate = salesDetailWork.CostRate; // ������
            salesDetail.RateSectCstUnPrc = salesDetailWork.RateSectCstUnPrc; // �|���ݒ苒�_�i�����P���j
            salesDetail.RateDivUnCst = salesDetailWork.RateDivUnCst; // �|���ݒ�敪�i�����P���j
            salesDetail.UnPrcCalcCdUnCst = salesDetailWork.UnPrcCalcCdUnCst; // �P���Z�o�敪�i�����P���j
            salesDetail.PriceCdUnCst = salesDetailWork.PriceCdUnCst; // ���i�敪�i�����P���j
            salesDetail.StdUnPrcUnCst = salesDetailWork.StdUnPrcUnCst; // ��P���i�����P���j
            salesDetail.FracProcUnitUnCst = salesDetailWork.FracProcUnitUnCst; // �[�������P�ʁi�����P���j
            salesDetail.FracProcUnCst = salesDetailWork.FracProcUnCst; // �[�������i�����P���j
            salesDetail.SalesUnitCost = salesDetailWork.SalesUnitCost; // �����P��
            salesDetail.SalesUnitCostChngDiv = salesDetailWork.SalesUnitCostChngDiv; // �����P���ύX�敪
            salesDetail.RateBLGoodsCode = salesDetailWork.RateBLGoodsCode; // BL���i�R�[�h�i�|���j
            salesDetail.RateBLGoodsName = salesDetailWork.RateBLGoodsName; // BL���i�R�[�h���́i�|���j
            salesDetail.RateGoodsRateGrpCd = salesDetailWork.RateGoodsRateGrpCd; // ���i�|���O���[�v�R�[�h�i�|���j
            salesDetail.RateGoodsRateGrpNm = salesDetailWork.RateGoodsRateGrpNm; // ���i�|���O���[�v���́i�|���j
            salesDetail.RateBLGroupCode = salesDetailWork.RateBLGroupCode; // BL�O���[�v�R�[�h�i�|���j
            salesDetail.RateBLGroupName = salesDetailWork.RateBLGroupName; // BL�O���[�v���́i�|���j
            salesDetail.PrtBLGoodsCode = salesDetailWork.PrtBLGoodsCode; // BL���i�R�[�h�i����j
            salesDetail.PrtBLGoodsName = salesDetailWork.PrtBLGoodsName; // BL���i�R�[�h���́i����j
            salesDetail.SalesCode = salesDetailWork.SalesCode; // �̔��敪�R�[�h
            salesDetail.SalesCdNm = salesDetailWork.SalesCdNm; // �̔��敪����
            salesDetail.WorkManHour = salesDetailWork.WorkManHour; // ��ƍH��
            salesDetail.ShipmentCnt = salesDetailWork.ShipmentCnt; // �o�א�
            salesDetail.AcceptAnOrderCnt = salesDetailWork.AcceptAnOrderCnt; // �󒍐���
            salesDetail.AcptAnOdrAdjustCnt = salesDetailWork.AcptAnOdrAdjustCnt; // �󒍒�����
            salesDetail.AcptAnOdrRemainCnt = salesDetailWork.AcptAnOdrRemainCnt; // �󒍎c��
            salesDetail.RemainCntUpdDate = salesDetailWork.RemainCntUpdDate; // �c���X�V��
            salesDetail.SalesMoneyTaxInc = salesDetailWork.SalesMoneyTaxInc; // ������z�i�ō��݁j
            salesDetail.SalesMoneyTaxExc = salesDetailWork.SalesMoneyTaxExc; // ������z�i�Ŕ����j
            salesDetail.Cost = salesDetailWork.Cost; // ����
            salesDetail.GrsProfitChkDiv = salesDetailWork.GrsProfitChkDiv; // �e���`�F�b�N�敪
            salesDetail.SalesGoodsCd = salesDetailWork.SalesGoodsCd; // ���㏤�i�敪
            salesDetail.SalesPriceConsTax = salesDetailWork.SalesPriceConsTax; // ������z����Ŋz
            salesDetail.TaxationDivCd = salesDetailWork.TaxationDivCd; // �ېŋ敪
            salesDetail.PartySlipNumDtl = salesDetailWork.PartySlipNumDtl; // �����`�[�ԍ��i���ׁj
            salesDetail.DtlNote = salesDetailWork.DtlNote; // ���ה��l
            salesDetail.SupplierCd = salesDetailWork.SupplierCd; // �d����R�[�h
            salesDetail.SupplierSnm = salesDetailWork.SupplierSnm; // �d���旪��
            salesDetail.OrderNumber = salesDetailWork.OrderNumber; // �����ԍ�
            salesDetail.WayToOrder = salesDetailWork.WayToOrder; // �������@
            salesDetail.SlipMemo1 = salesDetailWork.SlipMemo1; // �`�[�����P
            salesDetail.SlipMemo2 = salesDetailWork.SlipMemo2; // �`�[�����Q
            salesDetail.SlipMemo3 = salesDetailWork.SlipMemo3; // �`�[�����R
            salesDetail.InsideMemo1 = salesDetailWork.InsideMemo1; // �Г������P
            salesDetail.InsideMemo2 = salesDetailWork.InsideMemo2; // �Г������Q
            salesDetail.InsideMemo3 = salesDetailWork.InsideMemo3; // �Г������R
            salesDetail.BfListPrice = salesDetailWork.BfListPrice; // �ύX�O�艿
            salesDetail.BfSalesUnitPrice = salesDetailWork.BfSalesUnitPrice; // �ύX�O����
            salesDetail.BfUnitCost = salesDetailWork.BfUnitCost; // �ύX�O����
            salesDetail.CmpltSalesRowNo = salesDetailWork.CmpltSalesRowNo; // �ꎮ���הԍ�
            salesDetail.CmpltGoodsMakerCd = salesDetailWork.CmpltGoodsMakerCd; // ���[�J�[�R�[�h�i�ꎮ�j
            salesDetail.CmpltMakerName = salesDetailWork.CmpltMakerName; // ���[�J�[���́i�ꎮ�j
            salesDetail.CmpltGoodsName = salesDetailWork.CmpltGoodsName; // ���i���́i�ꎮ�j
            salesDetail.CmpltShipmentCnt = salesDetailWork.CmpltShipmentCnt; // ���ʁi�ꎮ�j
            salesDetail.CmpltSalesUnPrcFl = salesDetailWork.CmpltSalesUnPrcFl; // ����P���i�ꎮ�j
            salesDetail.CmpltSalesMoney = salesDetailWork.CmpltSalesMoney; // ������z�i�ꎮ�j
            salesDetail.CmpltSalesUnitCost = salesDetailWork.CmpltSalesUnitCost; // �����P���i�ꎮ�j
            salesDetail.CmpltCost = salesDetailWork.CmpltCost; // �������z�i�ꎮ�j
            salesDetail.CmpltPartySalSlNum = salesDetailWork.CmpltPartySalSlNum; // �����`�[�ԍ��i�ꎮ�j
            salesDetail.CmpltNote = salesDetailWork.CmpltNote; // �ꎮ���l
            salesDetail.PrtGoodsNo = salesDetailWork.PrtGoodsNo; // ����p�i��
            salesDetail.PrtMakerCode = salesDetailWork.PrtMakerCode; // ����p���[�J�[�R�[�h
            salesDetail.PrtMakerName = salesDetailWork.PrtMakerName; // ����p���[�J�[����
            salesDetail.DtlRelationGuid = salesDetailWork.DtlRelationGuid; // ���ʃL�[
            //salesDetail.CarRelationGuid = salesDetailWork.CarRelationGuid; // �ԗ���񋤒ʃL�[
            //>>>2010/02/26
            salesDetail.CampaignCode = salesDetailWork.CampaignCode;
            salesDetail.CampaignName = salesDetailWork.CampaignName;
            salesDetail.GoodsDivCd = salesDetailWork.GoodsDivCd;
            salesDetail.AnswerDelivDate = salesDetailWork.AnswerDelivDate;
            salesDetail.RecycleDiv = salesDetailWork.RecycleDiv;
            salesDetail.RecycleDivNm = salesDetailWork.RecycleDivNm;
            salesDetail.WayToAcptOdr = salesDetailWork.WayToAcptOdr;
            //<<<2010/02/26
            salesDetail.AutoAnswerDivSCM = salesDetailWork.AutoAnswerDivSCM;//�����񓚋敪 zhubj
            salesDetail.AcceptOrOrderKind = salesDetailWork.AcceptOrOrderKind;//�󔭒���� //add 2011/08/23
            salesDetail.InquiryNumber = salesDetailWork.InquiryNumber;//�⍇���ԍ� //add 2011/08/23
            salesDetail.InqRowNumber = salesDetailWork.InqRowNumber;//�⍇���s�ԍ� //add 2011/08/23
            // 2012/01/16 Add >>>
            salesDetail.GoodsSpecialNote = salesDetailWork.GoodsSpecialNote; // ���L����
            // 2012/01/16 Add <<<
            //>>>2012/05/02
            salesDetail.RentSyncStockDate = salesDetailWork.RentSyncStockDate;
            salesDetail.RentSyncSupplier = salesDetailWork.RentSyncSupplier;
            salesDetail.RentSyncSupSlipNo = salesDetailWork.RentSyncSupSlipNo;
            //<<<2012/05/02

            return salesDetail;
        }

        /// <summary>
        /// UIData��PramData�ڍ�����
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <returns>����f�[�^���[�N�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Update Note: 2011/12/15 tianjw</br>
        /// <br>             Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
        /// </remarks>
        private static SalesSlipWork ParamDataFromUIDataProc(SalesSlip salesSlip)
        {
            SalesSlipWork salesSlipWork = new SalesSlipWork();

            salesSlipWork.CreateDateTime = salesSlip.CreateDateTime; // �쐬����
            salesSlipWork.UpdateDateTime = salesSlip.UpdateDateTime; // �X�V����
            salesSlipWork.EnterpriseCode = salesSlip.EnterpriseCode; // ��ƃR�[�h
            salesSlipWork.FileHeaderGuid = salesSlip.FileHeaderGuid; // GUID
            salesSlipWork.UpdEmployeeCode = salesSlip.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            salesSlipWork.UpdAssemblyId1 = salesSlip.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            salesSlipWork.UpdAssemblyId2 = salesSlip.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            salesSlipWork.LogicalDeleteCode = salesSlip.LogicalDeleteCode; // �_���폜�敪
            salesSlipWork.AcptAnOdrStatus = salesSlip.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            salesSlipWork.SalesSlipNum = salesSlip.SalesSlipNum; // ����`�[�ԍ�
            salesSlipWork.SectionCode = salesSlip.SectionCode; // ���_�R�[�h
            salesSlipWork.SubSectionCode = salesSlip.SubSectionCode; // ����R�[�h
            salesSlipWork.DebitNoteDiv = salesSlip.DebitNoteDiv; // �ԓ`�敪
            salesSlipWork.DebitNLnkSalesSlNum = salesSlip.DebitNLnkSalesSlNum; // �ԍ��A������`�[�ԍ�
            salesSlipWork.SalesSlipCd = salesSlip.SalesSlipCd; // ����`�[�敪
            salesSlipWork.SalesGoodsCd = salesSlip.SalesGoodsCd; // ���㏤�i�敪
            salesSlipWork.AccRecDivCd = salesSlip.AccRecDivCd; // ���|�敪
            salesSlipWork.SalesInpSecCd = salesSlip.SalesInpSecCd; // ������͋��_�R�[�h
            salesSlipWork.DemandAddUpSecCd = salesSlip.DemandAddUpSecCd; // �����v�㋒�_�R�[�h
            salesSlipWork.ResultsAddUpSecCd = salesSlip.ResultsAddUpSecCd; // ���ьv�㋒�_�R�[�h
            salesSlipWork.UpdateSecCd = salesSlip.UpdateSecCd; // �X�V���_�R�[�h
            salesSlipWork.SalesSlipUpdateCd = salesSlip.SalesSlipUpdateCd; // ����`�[�X�V�敪
            salesSlipWork.SearchSlipDate = salesSlip.SearchSlipDate; // �`�[�������t
            salesSlipWork.ShipmentDay = salesSlip.ShipmentDay; // �o�ד��t
            salesSlipWork.SalesDate = salesSlip.SalesDate; // ������t
            salesSlipWork.PreSalesDate = salesSlip.PreSalesDate; // �O�񔄏���t // ADD 2011/12/15
            salesSlipWork.AddUpADate = salesSlip.AddUpADate; // �v����t
            salesSlipWork.DelayPaymentDiv = salesSlip.DelayPaymentDiv; // �����敪
            salesSlipWork.EstimateFormNo = salesSlip.EstimateFormNo; // ���Ϗ��ԍ�
            salesSlipWork.EstimateDivide = salesSlip.EstimateDivide; // ���ϋ敪
            salesSlipWork.InputAgenCd = salesSlip.InputAgenCd; // ���͒S���҃R�[�h
            salesSlipWork.InputAgenNm = salesSlip.InputAgenNm; // ���͒S���Җ���
            salesSlipWork.SalesInputCode = salesSlip.SalesInputCode; // ������͎҃R�[�h
            salesSlipWork.SalesInputName = salesSlip.SalesInputName; // ������͎Җ���
            salesSlipWork.FrontEmployeeCd = salesSlip.FrontEmployeeCd; // ��t�]�ƈ��R�[�h
            salesSlipWork.FrontEmployeeNm = salesSlip.FrontEmployeeNm; // ��t�]�ƈ�����
            salesSlipWork.SalesEmployeeCd = salesSlip.SalesEmployeeCd; // �̔��]�ƈ��R�[�h
            salesSlipWork.SalesEmployeeNm = salesSlip.SalesEmployeeNm; // �̔��]�ƈ�����
            salesSlipWork.TotalAmountDispWayCd = salesSlip.TotalAmountDispWayCd; // ���z�\�����@�敪
            salesSlipWork.TtlAmntDispRateApy = salesSlip.TtlAmntDispRateApy; // ���z�\���|���K�p�敪
            salesSlipWork.SalesTotalTaxInc = salesSlip.SalesTotalTaxInc; // ����`�[���v�i�ō��݁j
            salesSlipWork.SalesTotalTaxExc = salesSlip.SalesTotalTaxExc; // ����`�[���v�i�Ŕ����j
            salesSlipWork.SalesPrtTotalTaxInc = salesSlip.SalesPrtTotalTaxInc; // ���㕔�i���v�i�ō��݁j
            salesSlipWork.SalesPrtTotalTaxExc = salesSlip.SalesPrtTotalTaxExc; // ���㕔�i���v�i�Ŕ����j
            salesSlipWork.SalesWorkTotalTaxInc = salesSlip.SalesWorkTotalTaxInc; // �����ƍ��v�i�ō��݁j
            salesSlipWork.SalesWorkTotalTaxExc = salesSlip.SalesWorkTotalTaxExc; // �����ƍ��v�i�Ŕ����j
            salesSlipWork.SalesSubtotalTaxInc = salesSlip.SalesSubtotalTaxInc; // ���㏬�v�i�ō��݁j
            salesSlipWork.SalesSubtotalTaxExc = salesSlip.SalesSubtotalTaxExc; // ���㏬�v�i�Ŕ����j
            salesSlipWork.SalesPrtSubttlInc = salesSlip.SalesPrtSubttlInc; // ���㕔�i���v�i�ō��݁j
            salesSlipWork.SalesPrtSubttlExc = salesSlip.SalesPrtSubttlExc; // ���㕔�i���v�i�Ŕ����j
            salesSlipWork.SalesWorkSubttlInc = salesSlip.SalesWorkSubttlInc; // �����Ə��v�i�ō��݁j
            salesSlipWork.SalesWorkSubttlExc = salesSlip.SalesWorkSubttlExc; // �����Ə��v�i�Ŕ����j
            salesSlipWork.SalesNetPrice = salesSlip.SalesNetPrice; // ���㐳�����z
            salesSlipWork.SalesSubtotalTax = salesSlip.SalesSubtotalTax; // ���㏬�v�i�Łj
            salesSlipWork.ItdedSalesOutTax = salesSlip.ItdedSalesOutTax; // ����O�őΏۊz
            salesSlipWork.ItdedSalesInTax = salesSlip.ItdedSalesInTax; // ������őΏۊz
            salesSlipWork.SalSubttlSubToTaxFre = salesSlip.SalSubttlSubToTaxFre; // ���㏬�v��ېőΏۊz
            salesSlipWork.SalesOutTax = salesSlip.SalesOutTax; // ������z����Ŋz�i�O�Łj
            salesSlipWork.SalAmntConsTaxInclu = salesSlip.SalAmntConsTaxInclu; // ������z����Ŋz�i���Łj
            salesSlipWork.SalesDisTtlTaxExc = salesSlip.SalesDisTtlTaxExc; // ����l�����z�v�i�Ŕ����j
            salesSlipWork.ItdedSalesDisOutTax = salesSlip.ItdedSalesDisOutTax; // ����l���O�őΏۊz���v
            salesSlipWork.ItdedSalesDisInTax = salesSlip.ItdedSalesDisInTax; // ����l�����őΏۊz���v
            salesSlipWork.ItdedPartsDisOutTax = salesSlip.ItdedPartsDisOutTax; // ���i�l���Ώۊz���v�i�Ŕ����j
            salesSlipWork.ItdedPartsDisInTax = salesSlip.ItdedPartsDisInTax; // ���i�l���Ώۊz���v�i�ō��݁j
            salesSlipWork.ItdedWorkDisOutTax = salesSlip.ItdedWorkDisOutTax; // ��ƒl���Ώۊz���v�i�Ŕ����j
            salesSlipWork.ItdedWorkDisInTax = salesSlip.ItdedWorkDisInTax; // ��ƒl���Ώۊz���v�i�ō��݁j
            salesSlipWork.ItdedSalesDisTaxFre = salesSlip.ItdedSalesDisTaxFre; // ����l����ېőΏۊz���v
            salesSlipWork.SalesDisOutTax = salesSlip.SalesDisOutTax; // ����l������Ŋz�i�O�Łj
            salesSlipWork.SalesDisTtlTaxInclu = salesSlip.SalesDisTtlTaxInclu; // ����l������Ŋz�i���Łj
            salesSlipWork.PartsDiscountRate = salesSlip.PartsDiscountRate; // ���i�l����
            salesSlipWork.RavorDiscountRate = salesSlip.RavorDiscountRate; // �H���l����
            salesSlipWork.TotalCost = salesSlip.TotalCost; // �������z�v
            salesSlipWork.ConsTaxLayMethod = salesSlip.ConsTaxLayMethod; // ����œ]�ŕ���
            salesSlipWork.ConsTaxRate = salesSlip.ConsTaxRate; // ����Őŗ�
            salesSlipWork.FractionProcCd = salesSlip.FractionProcCd; // �[�������敪
            salesSlipWork.AccRecConsTax = salesSlip.AccRecConsTax; // ���|�����
            salesSlipWork.AutoDepositCd = salesSlip.AutoDepositCd; // ���������敪
            salesSlipWork.AutoDepositNoteDiv = salesSlip.AutoDepositNoteDiv; // �����������l�敪 // ADD 2013/01/18 �c���� Redmine#33797
            salesSlipWork.AutoDepositSlipNo = salesSlip.AutoDepositSlipNo; // ���������`�[�ԍ�
            salesSlipWork.DepositAllowanceTtl = salesSlip.DepositAllowanceTtl; // �����������v�z
            salesSlipWork.DepositAlwcBlnce = salesSlip.DepositAlwcBlnce; // ���������c��
            salesSlipWork.ClaimCode = salesSlip.ClaimCode; // ������R�[�h
            salesSlipWork.ClaimSnm = salesSlip.ClaimSnm; // �����旪��
            salesSlipWork.CustomerCode = salesSlip.CustomerCode; // ���Ӑ�R�[�h
            salesSlipWork.CustomerName = salesSlip.CustomerName; // ���Ӑ於��
            salesSlipWork.CustomerName2 = salesSlip.CustomerName2; // ���Ӑ於��2
            salesSlipWork.CustomerSnm = salesSlip.CustomerSnm; // ���Ӑ旪��
            salesSlipWork.HonorificTitle = salesSlip.HonorificTitle; // �h��
            salesSlipWork.OutputNameCode = salesSlip.OutputNameCode; // �����R�[�h
            salesSlipWork.OutputName = salesSlip.OutputName; // ��������
            salesSlipWork.CustSlipNo = salesSlip.CustSlipNo; // ���Ӑ�`�[�ԍ�
            salesSlipWork.SlipAddressDiv = salesSlip.SlipAddressDiv; // �`�[�Z���敪
            salesSlipWork.AddresseeCode = salesSlip.AddresseeCode; // �[�i��R�[�h
            salesSlipWork.AddresseeName = salesSlip.AddresseeName; // �[�i�於��
            salesSlipWork.AddresseeName2 = salesSlip.AddresseeName2; // �[�i�於��2
            salesSlipWork.AddresseePostNo = salesSlip.AddresseePostNo; // �[�i��X�֔ԍ�
            salesSlipWork.AddresseeAddr1 = salesSlip.AddresseeAddr1; // �[�i��Z��1(�s���{���s��S�E�����E��)
            salesSlipWork.AddresseeAddr3 = salesSlip.AddresseeAddr3; // �[�i��Z��3(�Ԓn)
            salesSlipWork.AddresseeAddr4 = salesSlip.AddresseeAddr4; // �[�i��Z��4(�A�p�[�g����)
            salesSlipWork.AddresseeTelNo = salesSlip.AddresseeTelNo; // �[�i��d�b�ԍ�
            salesSlipWork.AddresseeFaxNo = salesSlip.AddresseeFaxNo; // �[�i��FAX�ԍ�
            salesSlipWork.PartySaleSlipNum = salesSlip.PartySaleSlipNum; // �����`�[�ԍ�
            salesSlipWork.SlipNote = salesSlip.SlipNote; // �`�[���l
            salesSlipWork.SlipNote2 = salesSlip.SlipNote2; // �`�[���l�Q
            salesSlipWork.SlipNote3 = salesSlip.SlipNote3; // �`�[���l�R
            salesSlipWork.RetGoodsReasonDiv = salesSlip.RetGoodsReasonDiv; // �ԕi���R�R�[�h
            salesSlipWork.RetGoodsReason = salesSlip.RetGoodsReason; // �ԕi���R
            salesSlipWork.RegiProcDate = salesSlip.RegiProcDate; // ���W������
            salesSlipWork.CashRegisterNo = salesSlip.CashRegisterNo; // ���W�ԍ�
            salesSlipWork.PosReceiptNo = salesSlip.PosReceiptNo; // POS���V�[�g�ԍ�
            salesSlipWork.DetailRowCount = salesSlip.DetailRowCount; // ���׍s��
            salesSlipWork.EdiSendDate = salesSlip.EdiSendDate; // �d�c�h���M��
            salesSlipWork.EdiTakeInDate = salesSlip.EdiTakeInDate; // �d�c�h�捞��
            salesSlipWork.UoeRemark1 = salesSlip.UoeRemark1; // �t�n�d���}�[�N�P
            salesSlipWork.UoeRemark2 = salesSlip.UoeRemark2; // �t�n�d���}�[�N�Q
            salesSlipWork.SlipPrintDivCd = salesSlip.SlipPrintDivCd; // �`�[���s�敪
            salesSlipWork.SlipPrintFinishCd = salesSlip.SlipPrintFinishCd; // �`�[���s�ϋ敪
            salesSlipWork.SalesSlipPrintDate = salesSlip.SalesSlipPrintDate; // ����`�[���s��
            salesSlipWork.BusinessTypeCode = salesSlip.BusinessTypeCode; // �Ǝ�R�[�h
            salesSlipWork.BusinessTypeName = salesSlip.BusinessTypeName; // �Ǝ햼��
            salesSlipWork.OrderNumber = salesSlip.OrderNumber; // �����ԍ�
            salesSlipWork.DeliveredGoodsDiv = salesSlip.DeliveredGoodsDiv; // �[�i�敪
            salesSlipWork.DeliveredGoodsDivNm = salesSlip.DeliveredGoodsDivNm; // �[�i�敪����
            salesSlipWork.SalesAreaCode = salesSlip.SalesAreaCode; // �̔��G���A�R�[�h
            salesSlipWork.SalesAreaName = salesSlip.SalesAreaName; // �̔��G���A����
            salesSlipWork.ReconcileFlag = salesSlip.ReconcileFlag; // �����t���O
            salesSlipWork.SlipPrtSetPaperId = salesSlip.SlipPrtSetPaperId; // �`�[����ݒ�p���[ID
            salesSlipWork.CompleteCd = salesSlip.CompleteCd; // �ꎮ�`�[�敪
            salesSlipWork.SalesPriceFracProcCd = salesSlip.SalesPriceFracProcCd; // ������z�[�������敪
            salesSlipWork.StockGoodsTtlTaxExc = salesSlip.StockGoodsTtlTaxExc; // �݌ɏ��i���v���z�i�Ŕ��j
            salesSlipWork.PureGoodsTtlTaxExc = salesSlip.PureGoodsTtlTaxExc; // �������i���v���z�i�Ŕ��j
            salesSlipWork.ListPricePrintDiv = salesSlip.ListPricePrintDiv; // �艿����敪
            salesSlipWork.EraNameDispCd1 = salesSlip.EraNameDispCd1; // �����\���敪�P
            salesSlipWork.EstimaTaxDivCd = salesSlip.EstimaTaxDivCd; // ���Ϗ���ŋ敪
            salesSlipWork.EstimateFormPrtCd = salesSlip.EstimateFormPrtCd; // ���Ϗ�����敪
            salesSlipWork.EstimateSubject = salesSlip.EstimateSubject; // ���ό���
            salesSlipWork.Footnotes1 = salesSlip.Footnotes1; // �r���P
            salesSlipWork.Footnotes2 = salesSlip.Footnotes2; // �r���Q
            salesSlipWork.EstimateTitle1 = salesSlip.EstimateTitle1; // ���σ^�C�g���P
            salesSlipWork.EstimateTitle2 = salesSlip.EstimateTitle2; // ���σ^�C�g���Q
            salesSlipWork.EstimateTitle3 = salesSlip.EstimateTitle3; // ���σ^�C�g���R
            salesSlipWork.EstimateTitle4 = salesSlip.EstimateTitle4; // ���σ^�C�g���S
            salesSlipWork.EstimateTitle5 = salesSlip.EstimateTitle5; // ���σ^�C�g���T
            salesSlipWork.EstimateNote1 = salesSlip.EstimateNote1; // ���ϔ��l�P
            salesSlipWork.EstimateNote2 = salesSlip.EstimateNote2; // ���ϔ��l�Q
            salesSlipWork.EstimateNote3 = salesSlip.EstimateNote3; // ���ϔ��l�R
            salesSlipWork.EstimateNote4 = salesSlip.EstimateNote4; // ���ϔ��l�S
            salesSlipWork.EstimateNote5 = salesSlip.EstimateNote5; // ���ϔ��l�T
            salesSlipWork.EstimateValidityDate = salesSlip.EstimateValidityDate; // ���ϗL������
            salesSlipWork.PartsNoPrtCd = salesSlip.PartsNoPrtCd; // �i�Ԉ󎚋敪
            salesSlipWork.OptionPringDivCd = salesSlip.OptionPringDivCd; // �I�v�V�����󎚋敪
            salesSlipWork.RateUseCode = salesSlip.RateUseCode; // �|���g�p�敪
            //salesSlipWork.InputMode = salesSlip.InputMode; // ���̓��[�h
            //salesSlipWork.SalesSlipDisplay = salesSlip.SalesSlipDisplay; // ����`�[�敪(��ʕ\���p)
            //salesSlipWork.AcptAnOdrStatusDisplay = salesSlip.AcptAnOdrStatusDisplay; // �󒍃X�e�[�^�X
            //salesSlipWork.CustRateGrpCode = salesSlip.CustRateGrpCode; // ���Ӑ�|���O���[�v�R�[�h
            //salesSlipWork.ClaimName = salesSlip.ClaimName; // �����於��
            //salesSlipWork.ClaimName2 = salesSlip.ClaimName2; // �����於�̂Q
            //salesSlipWork.CreditMngCode = salesSlip.CreditMngCode; // �^�M�Ǘ��敪
            //salesSlipWork.TotalDay = salesSlip.TotalDay; // ����
            //salesSlipWork.NTimeCalcStDate = salesSlip.NTimeCalcStDate; // ���񊨒�J�n��
            //salesSlipWork.TotalMoneyForGrossProfit = salesSlip.TotalMoneyForGrossProfit; // �e���v�Z�p������z
            //salesSlipWork.AcceptAnOrderDate = salesSlip.AcceptAnOrderDate; // �󒍓�
            //salesSlipWork.SectionName = salesSlip.SectionName; // ���_����
            //salesSlipWork.SubSectionName = salesSlip.SubSectionName; // ���喼��
            //salesSlipWork.CarMngDivCd = salesSlip.CarMngDivCd; // ���q�Ǘ��敪
            //salesSlipWork.SearchMode = salesSlip.SearchMode; // ���i�������[�h
            //salesSlipWork.SearchCarMode = salesSlip.SearchCarMode; // �ԗ��������[�h
            //salesSlipWork.CustOrderNoDispDiv = salesSlip.CustOrderNoDispDiv; // ���Ӑ撍�ԕ\���敪

            return salesSlipWork;
        }

        /// <summary>
        /// UIData��PramData�ڍ�����
        /// </summary>
        /// <param name="salesDetail">���㖾�׃f�[�^�I�u�W�F�N�g</param>
        /// <returns>���㖾�׃f�[�^���[�N�I�u�W�F�N�g</returns>
        private static SalesDetailWork ParamDataFromUIDataProc(SalesDetail salesDetail)
        {
            SalesDetailWork salesDetailWork = new SalesDetailWork();

            salesDetailWork.CreateDateTime = salesDetail.CreateDateTime; // �쐬����
            salesDetailWork.UpdateDateTime = salesDetail.UpdateDateTime; // �X�V����
            salesDetailWork.EnterpriseCode = salesDetail.EnterpriseCode; // ��ƃR�[�h
            salesDetailWork.FileHeaderGuid = salesDetail.FileHeaderGuid; // GUID
            salesDetailWork.UpdEmployeeCode = salesDetail.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            salesDetailWork.UpdAssemblyId1 = salesDetail.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            salesDetailWork.UpdAssemblyId2 = salesDetail.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            salesDetailWork.LogicalDeleteCode = salesDetail.LogicalDeleteCode; // �_���폜�敪
            salesDetailWork.AcceptAnOrderNo = salesDetail.AcceptAnOrderNo; // �󒍔ԍ�
            salesDetailWork.AcptAnOdrStatus = salesDetail.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            salesDetailWork.SalesSlipNum = salesDetail.SalesSlipNum; // ����`�[�ԍ�
            salesDetailWork.SalesRowNo = salesDetail.SalesRowNo; // ����s�ԍ�
            salesDetailWork.SalesRowDerivNo = salesDetail.SalesRowDerivNo; // ����s�ԍ��}��
            salesDetailWork.SectionCode = salesDetail.SectionCode; // ���_�R�[�h
            salesDetailWork.SubSectionCode = salesDetail.SubSectionCode; // ����R�[�h
            salesDetailWork.SalesDate = salesDetail.SalesDate; // ������t
            salesDetailWork.CommonSeqNo = salesDetail.CommonSeqNo; // ���ʒʔ�
            salesDetailWork.SalesSlipDtlNum = salesDetail.SalesSlipDtlNum; // ���㖾�גʔ�
            salesDetailWork.AcptAnOdrStatusSrc = salesDetail.AcptAnOdrStatusSrc; // �󒍃X�e�[�^�X�i���j
            salesDetailWork.SalesSlipDtlNumSrc = salesDetail.SalesSlipDtlNumSrc; // ���㖾�גʔԁi���j
            salesDetailWork.SupplierFormalSync = salesDetail.SupplierFormalSync; // �d���`���i�����j
            salesDetailWork.StockSlipDtlNumSync = salesDetail.StockSlipDtlNumSync; // �d�����גʔԁi�����j
            salesDetailWork.SalesSlipCdDtl = salesDetail.SalesSlipCdDtl; // ����`�[�敪�i���ׁj
            salesDetailWork.DeliGdsCmpltDueDate = salesDetail.DeliGdsCmpltDueDate; // �[�i�����\���
            salesDetailWork.GoodsKindCode = salesDetail.GoodsKindCode; // ���i����
            salesDetailWork.GoodsSearchDivCd = salesDetail.GoodsSearchDivCd; // ���i�����敪
            salesDetailWork.GoodsMakerCd = salesDetail.GoodsMakerCd; // ���i���[�J�[�R�[�h
            salesDetailWork.MakerName = salesDetail.MakerName; // ���[�J�[����
            salesDetailWork.MakerKanaName = salesDetail.MakerKanaName; // ���[�J�[�J�i����
            salesDetailWork.CmpltMakerKanaName = salesDetail.CmpltMakerKanaName; // ���[�J�[�J�i���́i�ꎮ�j
            salesDetailWork.GoodsNo = salesDetail.GoodsNo; // ���i�ԍ�
            salesDetailWork.GoodsName = salesDetail.GoodsName; // ���i����
            salesDetailWork.GoodsNameKana = salesDetail.GoodsNameKana; // ���i���̃J�i
            salesDetailWork.GoodsLGroup = salesDetail.GoodsLGroup; // ���i�啪�ރR�[�h
            salesDetailWork.GoodsLGroupName = salesDetail.GoodsLGroupName; // ���i�啪�ޖ���
            salesDetailWork.GoodsMGroup = salesDetail.GoodsMGroup; // ���i�����ރR�[�h
            salesDetailWork.GoodsMGroupName = salesDetail.GoodsMGroupName; // ���i�����ޖ���
            salesDetailWork.BLGroupCode = salesDetail.BLGroupCode; // BL�O���[�v�R�[�h
            salesDetailWork.BLGroupName = salesDetail.BLGroupName; // BL�O���[�v�R�[�h����
            salesDetailWork.BLGoodsCode = salesDetail.BLGoodsCode; // BL���i�R�[�h
            salesDetailWork.BLGoodsFullName = salesDetail.BLGoodsFullName; // BL���i�R�[�h���́i�S�p�j
            salesDetailWork.EnterpriseGanreCode = salesDetail.EnterpriseGanreCode; // ���Е��ރR�[�h
            salesDetailWork.EnterpriseGanreName = salesDetail.EnterpriseGanreName; // ���Е��ޖ���
            salesDetailWork.WarehouseCode = salesDetail.WarehouseCode; // �q�ɃR�[�h
            salesDetailWork.WarehouseName = salesDetail.WarehouseName; // �q�ɖ���
            salesDetailWork.WarehouseShelfNo = salesDetail.WarehouseShelfNo; // �q�ɒI��
            salesDetailWork.SalesOrderDivCd = salesDetail.SalesOrderDivCd; // ����݌Ɏ�񂹋敪
            salesDetailWork.OpenPriceDiv = salesDetail.OpenPriceDiv; // �I�[�v�����i�敪
            salesDetailWork.GoodsRateRank = salesDetail.GoodsRateRank; // ���i�|�������N
            salesDetailWork.CustRateGrpCode = salesDetail.CustRateGrpCode; // ���Ӑ�|���O���[�v�R�[�h
            salesDetailWork.ListPriceRate = salesDetail.ListPriceRate; // �艿��
            salesDetailWork.RateSectPriceUnPrc = salesDetail.RateSectPriceUnPrc; // �|���ݒ苒�_�i�艿�j
            salesDetailWork.RateDivLPrice = salesDetail.RateDivLPrice; // �|���ݒ�敪�i�艿�j
            salesDetailWork.UnPrcCalcCdLPrice = salesDetail.UnPrcCalcCdLPrice; // �P���Z�o�敪�i�艿�j
            salesDetailWork.PriceCdLPrice = salesDetail.PriceCdLPrice; // ���i�敪�i�艿�j
            salesDetailWork.StdUnPrcLPrice = salesDetail.StdUnPrcLPrice; // ��P���i�艿�j
            salesDetailWork.FracProcUnitLPrice = salesDetail.FracProcUnitLPrice; // �[�������P�ʁi�艿�j
            salesDetailWork.FracProcLPrice = salesDetail.FracProcLPrice; // �[�������i�艿�j
            salesDetailWork.ListPriceTaxIncFl = salesDetail.ListPriceTaxIncFl; // �艿�i�ō��C�����j
            salesDetailWork.ListPriceTaxExcFl = salesDetail.ListPriceTaxExcFl; // �艿�i�Ŕ��C�����j
            salesDetailWork.ListPriceChngCd = salesDetail.ListPriceChngCd; // �艿�ύX�敪
            salesDetailWork.SalesRate = salesDetail.SalesRate; // ������
            salesDetailWork.RateSectSalUnPrc = salesDetail.RateSectSalUnPrc; // �|���ݒ苒�_�i����P���j
            salesDetailWork.RateDivSalUnPrc = salesDetail.RateDivSalUnPrc; // �|���ݒ�敪�i����P���j
            salesDetailWork.UnPrcCalcCdSalUnPrc = salesDetail.UnPrcCalcCdSalUnPrc; // �P���Z�o�敪�i����P���j
            salesDetailWork.PriceCdSalUnPrc = salesDetail.PriceCdSalUnPrc; // ���i�敪�i����P���j
            salesDetailWork.StdUnPrcSalUnPrc = salesDetail.StdUnPrcSalUnPrc; // ��P���i����P���j
            salesDetailWork.FracProcUnitSalUnPrc = salesDetail.FracProcUnitSalUnPrc; // �[�������P�ʁi����P���j
            salesDetailWork.FracProcSalUnPrc = salesDetail.FracProcSalUnPrc; // �[�������i����P���j
            salesDetailWork.SalesUnPrcTaxIncFl = salesDetail.SalesUnPrcTaxIncFl; // ����P���i�ō��C�����j
            salesDetailWork.SalesUnPrcTaxExcFl = salesDetail.SalesUnPrcTaxExcFl; // ����P���i�Ŕ��C�����j
            salesDetailWork.SalesUnPrcChngCd = salesDetail.SalesUnPrcChngCd; // ����P���ύX�敪
            salesDetailWork.CostRate = salesDetail.CostRate; // ������
            salesDetailWork.RateSectCstUnPrc = salesDetail.RateSectCstUnPrc; // �|���ݒ苒�_�i�����P���j
            salesDetailWork.RateDivUnCst = salesDetail.RateDivUnCst; // �|���ݒ�敪�i�����P���j
            salesDetailWork.UnPrcCalcCdUnCst = salesDetail.UnPrcCalcCdUnCst; // �P���Z�o�敪�i�����P���j
            salesDetailWork.PriceCdUnCst = salesDetail.PriceCdUnCst; // ���i�敪�i�����P���j
            salesDetailWork.StdUnPrcUnCst = salesDetail.StdUnPrcUnCst; // ��P���i�����P���j
            salesDetailWork.FracProcUnitUnCst = salesDetail.FracProcUnitUnCst; // �[�������P�ʁi�����P���j
            salesDetailWork.FracProcUnCst = salesDetail.FracProcUnCst; // �[�������i�����P���j
            salesDetailWork.SalesUnitCost = salesDetail.SalesUnitCost; // �����P��
            salesDetailWork.SalesUnitCostChngDiv = salesDetail.SalesUnitCostChngDiv; // �����P���ύX�敪
            salesDetailWork.RateBLGoodsCode = salesDetail.RateBLGoodsCode; // BL���i�R�[�h�i�|���j
            salesDetailWork.RateBLGoodsName = salesDetail.RateBLGoodsName; // BL���i�R�[�h���́i�|���j
            salesDetailWork.RateGoodsRateGrpCd = salesDetail.RateGoodsRateGrpCd; // ���i�|���O���[�v�R�[�h�i�|���j
            salesDetailWork.RateGoodsRateGrpNm = salesDetail.RateGoodsRateGrpNm; // ���i�|���O���[�v���́i�|���j
            salesDetailWork.RateBLGroupCode = salesDetail.RateBLGroupCode; // BL�O���[�v�R�[�h�i�|���j
            salesDetailWork.RateBLGroupName = salesDetail.RateBLGroupName; // BL�O���[�v���́i�|���j
            salesDetailWork.PrtBLGoodsCode = salesDetail.PrtBLGoodsCode; // BL���i�R�[�h�i����j
            salesDetailWork.PrtBLGoodsName = salesDetail.PrtBLGoodsName; // BL���i�R�[�h���́i����j
            salesDetailWork.SalesCode = salesDetail.SalesCode; // �̔��敪�R�[�h
            salesDetailWork.SalesCdNm = salesDetail.SalesCdNm; // �̔��敪����
            salesDetailWork.WorkManHour = salesDetail.WorkManHour; // ��ƍH��
            salesDetailWork.ShipmentCnt = salesDetail.ShipmentCnt; // �o�א�
            salesDetailWork.AcceptAnOrderCnt = salesDetail.AcceptAnOrderCnt; // �󒍐���
            salesDetailWork.AcptAnOdrAdjustCnt = salesDetail.AcptAnOdrAdjustCnt; // �󒍒�����
            salesDetailWork.AcptAnOdrRemainCnt = salesDetail.AcptAnOdrRemainCnt; // �󒍎c��
            salesDetailWork.RemainCntUpdDate = salesDetail.RemainCntUpdDate; // �c���X�V��
            salesDetailWork.SalesMoneyTaxInc = salesDetail.SalesMoneyTaxInc; // ������z�i�ō��݁j
            salesDetailWork.SalesMoneyTaxExc = salesDetail.SalesMoneyTaxExc; // ������z�i�Ŕ����j
            salesDetailWork.Cost = salesDetail.Cost; // ����
            salesDetailWork.GrsProfitChkDiv = salesDetail.GrsProfitChkDiv; // �e���`�F�b�N�敪
            salesDetailWork.SalesGoodsCd = salesDetail.SalesGoodsCd; // ���㏤�i�敪
            salesDetailWork.SalesPriceConsTax = salesDetail.SalesPriceConsTax; // ������z����Ŋz
            salesDetailWork.TaxationDivCd = salesDetail.TaxationDivCd; // �ېŋ敪
            salesDetailWork.PartySlipNumDtl = salesDetail.PartySlipNumDtl; // �����`�[�ԍ��i���ׁj
            salesDetailWork.DtlNote = salesDetail.DtlNote; // ���ה��l
            salesDetailWork.SupplierCd = salesDetail.SupplierCd; // �d����R�[�h
            salesDetailWork.SupplierSnm = salesDetail.SupplierSnm; // �d���旪��
            salesDetailWork.OrderNumber = salesDetail.OrderNumber; // �����ԍ�
            salesDetailWork.WayToOrder = salesDetail.WayToOrder; // �������@
            salesDetailWork.SlipMemo1 = salesDetail.SlipMemo1; // �`�[�����P
            salesDetailWork.SlipMemo2 = salesDetail.SlipMemo2; // �`�[�����Q
            salesDetailWork.SlipMemo3 = salesDetail.SlipMemo3; // �`�[�����R
            salesDetailWork.InsideMemo1 = salesDetail.InsideMemo1; // �Г������P
            salesDetailWork.InsideMemo2 = salesDetail.InsideMemo2; // �Г������Q
            salesDetailWork.InsideMemo3 = salesDetail.InsideMemo3; // �Г������R
            salesDetailWork.BfListPrice = salesDetail.BfListPrice; // �ύX�O�艿
            salesDetailWork.BfSalesUnitPrice = salesDetail.BfSalesUnitPrice; // �ύX�O����
            salesDetailWork.BfUnitCost = salesDetail.BfUnitCost; // �ύX�O����
            salesDetailWork.CmpltSalesRowNo = salesDetail.CmpltSalesRowNo; // �ꎮ���הԍ�
            salesDetailWork.CmpltGoodsMakerCd = salesDetail.CmpltGoodsMakerCd; // ���[�J�[�R�[�h�i�ꎮ�j
            salesDetailWork.CmpltMakerName = salesDetail.CmpltMakerName; // ���[�J�[���́i�ꎮ�j
            salesDetailWork.CmpltGoodsName = salesDetail.CmpltGoodsName; // ���i���́i�ꎮ�j
            salesDetailWork.CmpltShipmentCnt = salesDetail.CmpltShipmentCnt; // ���ʁi�ꎮ�j
            salesDetailWork.CmpltSalesUnPrcFl = salesDetail.CmpltSalesUnPrcFl; // ����P���i�ꎮ�j
            salesDetailWork.CmpltSalesMoney = salesDetail.CmpltSalesMoney; // ������z�i�ꎮ�j
            salesDetailWork.CmpltSalesUnitCost = salesDetail.CmpltSalesUnitCost; // �����P���i�ꎮ�j
            salesDetailWork.CmpltCost = salesDetail.CmpltCost; // �������z�i�ꎮ�j
            salesDetailWork.CmpltPartySalSlNum = salesDetail.CmpltPartySalSlNum; // �����`�[�ԍ��i�ꎮ�j
            salesDetailWork.CmpltNote = salesDetail.CmpltNote; // �ꎮ���l
            salesDetailWork.PrtGoodsNo = salesDetail.PrtGoodsNo; // ����p�i��
            salesDetailWork.PrtMakerCode = salesDetail.PrtMakerCode; // ����p���[�J�[�R�[�h
            salesDetailWork.PrtMakerName = salesDetail.PrtMakerName; // ����p���[�J�[����
            salesDetailWork.DtlRelationGuid = salesDetail.DtlRelationGuid; // ���ʃL�[
            //salesDetailWork.CarRelationGuid = salesDetail.CarRelationGuid; // �ԗ���񋤒ʃL�[
            //>>>2010/02/26
            salesDetailWork.CampaignCode = salesDetail.CampaignCode;
            salesDetailWork.CampaignName = salesDetail.CampaignName;
            salesDetailWork.GoodsDivCd = salesDetail.GoodsDivCd;
            salesDetailWork.AnswerDelivDate = salesDetail.AnswerDelivDate;
            salesDetailWork.RecycleDiv = salesDetail.RecycleDiv;
            salesDetailWork.RecycleDivNm = salesDetail.RecycleDivNm;
            salesDetailWork.WayToAcptOdr = salesDetail.WayToAcptOdr;
            salesDetailWork.DtlRelationGuid = salesDetail.DtlRelationGuid; // ���ʃL�[
            //<<<2010/02/26
            salesDetailWork.AutoAnswerDivSCM = salesDetail.AutoAnswerDivSCM; // �����񓚋敪
            salesDetailWork.AcceptOrOrderKind = salesDetail.AcceptOrOrderKind;//�󔭒���� //add 2011/08/23
            salesDetailWork.InquiryNumber = salesDetail.InquiryNumber;//�⍇���ԍ� //add 2011/08/23
            salesDetailWork.InqRowNumber = salesDetail.InqRowNumber;//�⍇���s�ԍ� //add 2011/08/23
            // 2012/01/16 Add >>>
            salesDetailWork.GoodsSpecialNote = salesDetail.GoodsSpecialNote; // ���L����
            // 2012/01/16 Add <<<
            //>>>2012/05/02
            salesDetailWork.RentSyncStockDate = salesDetail.RentSyncStockDate;
            salesDetailWork.RentSyncSupplier = salesDetail.RentSyncSupplier;
            salesDetailWork.RentSyncSupSlipNo = salesDetail.RentSyncSupSlipNo;
            //<<<2012/05/02
            return salesDetailWork;
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="stockSlipWork">�d���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockDetailWork">�d�����׃f�[�^���[�N�I�u�W�F�N�g</param>
        /// <returns>�d�����I�u�W�F�N�g</returns>
        private static StockTemp UIDataFromParamDataProc(StockSlipWork stockSlipWork, StockDetailWork stockDetailWork)
        {
            StockTemp stockTemp = new StockTemp();

            #region �����ڃZ�b�g
            stockTemp.CreateDateTime = stockSlipWork.CreateDateTime; // �쐬����
            stockTemp.UpdateDateTime = stockSlipWork.UpdateDateTime; // �X�V����
            stockTemp.EnterpriseCode = stockSlipWork.EnterpriseCode; // ��ƃR�[�h
            stockTemp.FileHeaderGuid = stockSlipWork.FileHeaderGuid; // GUID
            stockTemp.UpdEmployeeCode = stockSlipWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            stockTemp.UpdAssemblyId1 = stockSlipWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            stockTemp.UpdAssemblyId2 = stockSlipWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            stockTemp.LogicalDeleteCode = stockSlipWork.LogicalDeleteCode; // �_���폜�敪
            stockTemp.SupplierFormal = stockSlipWork.SupplierFormal; // �d���`��
            stockTemp.SupplierSlipNo = stockSlipWork.SupplierSlipNo; // �d���`�[�ԍ�
            stockTemp.SectionCode = stockSlipWork.SectionCode; // ���_�R�[�h
            stockTemp.SubSectionCode = stockSlipWork.SubSectionCode; // ����R�[�h
            stockTemp.DebitNoteDiv = stockSlipWork.DebitNoteDiv; // �ԓ`�敪
            stockTemp.DebitNLnkSuppSlipNo = stockSlipWork.DebitNLnkSuppSlipNo; // �ԍ��A���d���`�[�ԍ�
            stockTemp.SupplierSlipCd = stockSlipWork.SupplierSlipCd; // �d���`�[�敪
            stockTemp.StockGoodsCd = stockSlipWork.StockGoodsCd; // �d�����i�敪
            stockTemp.AccPayDivCd = stockSlipWork.AccPayDivCd; // ���|�敪
            stockTemp.StockSectionCd = stockSlipWork.StockSectionCd; // �d�����_�R�[�h
            stockTemp.StockAddUpSectionCd = stockSlipWork.StockAddUpSectionCd; // �d���v�㋒�_�R�[�h
            stockTemp.StockSlipUpdateCd = stockSlipWork.StockSlipUpdateCd; // �d���`�[�X�V�敪
            stockTemp.InputDay = stockSlipWork.InputDay; // ���͓�
            stockTemp.ArrivalGoodsDay = stockSlipWork.ArrivalGoodsDay; // ���ד�
            stockTemp.StockDate = stockSlipWork.StockDate; // �d����
            stockTemp.StockAddUpADate = stockSlipWork.StockAddUpADate; // �d���v����t
            stockTemp.DelayPaymentDiv = stockSlipWork.DelayPaymentDiv; // �����敪
            stockTemp.PayeeCode = stockSlipWork.PayeeCode; // �x����R�[�h
            stockTemp.PayeeSnm = stockSlipWork.PayeeSnm; // �x���旪��
            stockTemp.SupplierCd = stockSlipWork.SupplierCd; // �d����R�[�h
            stockTemp.SupplierNm1 = stockSlipWork.SupplierNm1; // �d���於1
            stockTemp.SupplierNm2 = stockSlipWork.SupplierNm2; // �d���於2
            stockTemp.SupplierSnm = stockSlipWork.SupplierSnm; // �d���旪��
            stockTemp.BusinessTypeCode = stockSlipWork.BusinessTypeCode; // �Ǝ�R�[�h
            stockTemp.BusinessTypeName = stockSlipWork.BusinessTypeName; // �Ǝ햼��
            stockTemp.SalesAreaCode = stockSlipWork.SalesAreaCode; // �̔��G���A�R�[�h
            stockTemp.SalesAreaName = stockSlipWork.SalesAreaName; // �̔��G���A����
            stockTemp.StockInputCode = stockSlipWork.StockInputCode; // �d�����͎҃R�[�h
            stockTemp.StockInputName = stockSlipWork.StockInputName; // �d�����͎Җ���
            stockTemp.StockAgentCode = stockSlipWork.StockAgentCode; // �d���S���҃R�[�h
            stockTemp.StockAgentName = stockSlipWork.StockAgentName; // �d���S���Җ���
            stockTemp.SuppTtlAmntDspWayCd = stockSlipWork.SuppTtlAmntDspWayCd; // �d���摍�z�\�����@�敪
            stockTemp.TtlAmntDispRateApy = stockSlipWork.TtlAmntDispRateApy; // ���z�\���|���K�p�敪
            stockTemp.StockTotalPrice = stockSlipWork.StockTotalPrice; // �d�����z���v
            stockTemp.StockSubttlPrice = stockSlipWork.StockSubttlPrice; // �d�����z���v
            stockTemp.StockTtlPricTaxInc = stockSlipWork.StockTtlPricTaxInc; // �d�����z�v�i�ō��݁j
            stockTemp.StockTtlPricTaxExc = stockSlipWork.StockTtlPricTaxExc; // �d�����z�v�i�Ŕ����j
            stockTemp.StockNetPrice = stockSlipWork.StockNetPrice; // �d���������z
            stockTemp.StockPriceConsTax = stockSlipWork.StockPriceConsTax; // �d�����z����Ŋz
            stockTemp.TtlItdedStcOutTax = stockSlipWork.TtlItdedStcOutTax; // �d���O�őΏۊz���v
            stockTemp.TtlItdedStcInTax = stockSlipWork.TtlItdedStcInTax; // �d�����őΏۊz���v
            stockTemp.TtlItdedStcTaxFree = stockSlipWork.TtlItdedStcTaxFree; // �d����ېőΏۊz���v
            stockTemp.StockOutTax = stockSlipWork.StockOutTax; // �d�����z����Ŋz�i�O�Łj
            stockTemp.StckPrcConsTaxInclu = stockSlipWork.StckPrcConsTaxInclu; // �d�����z����Ŋz�i���Łj
            stockTemp.StckDisTtlTaxExc = stockSlipWork.StckDisTtlTaxExc; // �d���l�����z�v�i�Ŕ����j
            stockTemp.ItdedStockDisOutTax = stockSlipWork.ItdedStockDisOutTax; // �d���l���O�őΏۊz���v
            stockTemp.ItdedStockDisInTax = stockSlipWork.ItdedStockDisInTax; // �d���l�����őΏۊz���v
            stockTemp.ItdedStockDisTaxFre = stockSlipWork.ItdedStockDisTaxFre; // �d���l����ېőΏۊz���v
            stockTemp.StockDisOutTax = stockSlipWork.StockDisOutTax; // �d���l������Ŋz�i�O�Łj
            stockTemp.StckDisTtlTaxInclu = stockSlipWork.StckDisTtlTaxInclu; // �d���l������Ŋz�i���Łj
            stockTemp.TaxAdjust = stockSlipWork.TaxAdjust; // ����Œ����z
            stockTemp.BalanceAdjust = stockSlipWork.BalanceAdjust; // �c�������z
            stockTemp.SuppCTaxLayCd = stockSlipWork.SuppCTaxLayCd; // �d�������œ]�ŕ����R�[�h
            stockTemp.SupplierConsTaxRate = stockSlipWork.SupplierConsTaxRate; // �d�������Őŗ�
            stockTemp.AccPayConsTax = stockSlipWork.AccPayConsTax; // ���|�����
            stockTemp.StockFractionProcCd = stockSlipWork.StockFractionProcCd; // �d���[�������敪
            stockTemp.AutoPayment = stockSlipWork.AutoPayment; // �����x���敪
            stockTemp.AutoPaySlipNum = stockSlipWork.AutoPaySlipNum; // �����x���`�[�ԍ�
            stockTemp.RetGoodsReasonDiv = stockSlipWork.RetGoodsReasonDiv; // �ԕi���R�R�[�h
            stockTemp.RetGoodsReason = stockSlipWork.RetGoodsReason; // �ԕi���R
            stockTemp.PartySaleSlipNum = stockSlipWork.PartySaleSlipNum; // �����`�[�ԍ�
            stockTemp.SupplierSlipNote1 = stockSlipWork.SupplierSlipNote1; // �d���`�[���l1
            stockTemp.SupplierSlipNote2 = stockSlipWork.SupplierSlipNote2; // �d���`�[���l2
            stockTemp.DetailRowCount = stockSlipWork.DetailRowCount; // ���׍s��
            stockTemp.EdiSendDate = stockSlipWork.EdiSendDate; // �d�c�h���M��
            stockTemp.EdiTakeInDate = stockSlipWork.EdiTakeInDate; // �d�c�h�捞��
            stockTemp.UoeRemark1 = stockSlipWork.UoeRemark1; // �t�n�d���}�[�N�P
            stockTemp.UoeRemark2 = stockSlipWork.UoeRemark2; // �t�n�d���}�[�N�Q
            stockTemp.SlipPrintDivCd = stockSlipWork.SlipPrintDivCd; // �`�[���s�敪
            stockTemp.SlipPrintFinishCd = stockSlipWork.SlipPrintFinishCd; // �`�[���s�ϋ敪
            stockTemp.StockSlipPrintDate = stockSlipWork.StockSlipPrintDate; // �d���`�[���s��
            stockTemp.SlipPrtSetPaperId = stockSlipWork.SlipPrtSetPaperId; // �`�[����ݒ�p���[ID
            stockTemp.SlipAddressDiv = stockSlipWork.SlipAddressDiv; // �`�[�Z���敪
            stockTemp.AddresseeCode = stockSlipWork.AddresseeCode; // �[�i��R�[�h
            stockTemp.AddresseeName = stockSlipWork.AddresseeName; // �[�i�於��
            stockTemp.AddresseeName2 = stockSlipWork.AddresseeName2; // �[�i�於��2
            stockTemp.AddresseePostNo = stockSlipWork.AddresseePostNo; // �[�i��X�֔ԍ�
            stockTemp.AddresseeAddr1 = stockSlipWork.AddresseeAddr1; // �[�i��Z��1(�s���{���s��S�E�����E��)
            stockTemp.AddresseeAddr3 = stockSlipWork.AddresseeAddr3; // �[�i��Z��3(�Ԓn)
            stockTemp.AddresseeAddr4 = stockSlipWork.AddresseeAddr4; // �[�i��Z��4(�A�p�[�g����)
            stockTemp.AddresseeTelNo = stockSlipWork.AddresseeTelNo; // �[�i��d�b�ԍ�
            stockTemp.AddresseeFaxNo = stockSlipWork.AddresseeFaxNo; // �[�i��FAX�ԍ�
            stockTemp.DirectSendingCd = stockSlipWork.DirectSendingCd; // �����敪

            stockTemp.AcceptAnOrderNo = stockDetailWork.AcceptAnOrderNo; // �󒍔ԍ�
            stockTemp.SupplierFormalDetail = stockDetailWork.SupplierFormal; // �d���`��
            stockTemp.SupplierSlipNoDetail = stockDetailWork.SupplierSlipNo; // �d���`�[�ԍ�
            stockTemp.StockRowNo = stockDetailWork.StockRowNo; // �d���s�ԍ�
            stockTemp.SectionCodeDetail = stockDetailWork.SectionCode; // ���_�R�[�h
            stockTemp.SubSectionCodeDetail = stockDetailWork.SubSectionCode; // ����R�[�h
            stockTemp.CommonSeqNo = stockDetailWork.CommonSeqNo; // ���ʒʔ�
            stockTemp.StockSlipDtlNum = stockDetailWork.StockSlipDtlNum; // �d�����גʔ�
            stockTemp.SupplierFormalSrc = stockDetailWork.SupplierFormalSrc; // �d���`���i���j
            stockTemp.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNumSrc; // �d�����גʔԁi���j
            stockTemp.AcptAnOdrStatusSync = stockDetailWork.AcptAnOdrStatusSync; // �󒍃X�e�[�^�X�i�����j
            stockTemp.SalesSlipDtlNumSync = stockDetailWork.SalesSlipDtlNumSync; // ���㖾�גʔԁi�����j
            stockTemp.StockSlipCdDtl = stockDetailWork.StockSlipCdDtl; // �d���`�[�敪�i���ׁj
            stockTemp.StockInputCodeDetail = stockDetailWork.StockInputCode; // �d�����͎҃R�[�h
            stockTemp.StockInputNameDetail = stockDetailWork.StockInputName; // �d�����͎Җ���
            stockTemp.StockAgentCodeDetail = stockDetailWork.StockAgentCode; // �d���S���҃R�[�h
            stockTemp.StockAgentNameDetail = stockDetailWork.StockAgentName; // �d���S���Җ���
            stockTemp.GoodsKindCode = stockDetailWork.GoodsKindCode; // ���i����
            stockTemp.GoodsMakerCd = stockDetailWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
            stockTemp.MakerName = stockDetailWork.MakerName; // ���[�J�[����
            stockTemp.MakerKanaName = stockDetailWork.MakerKanaName; // ���[�J�[�J�i����
            stockTemp.CmpltMakerKanaName = stockDetailWork.CmpltMakerKanaName; // ���[�J�[�J�i���́i�ꎮ�j
            stockTemp.GoodsNo = stockDetailWork.GoodsNo; // ���i�ԍ�
            stockTemp.GoodsName = stockDetailWork.GoodsName; // ���i����
            stockTemp.GoodsNameKana = stockDetailWork.GoodsNameKana; // ���i���̃J�i
            stockTemp.GoodsLGroup = stockDetailWork.GoodsLGroup; // ���i�啪�ރR�[�h
            stockTemp.GoodsLGroupName = stockDetailWork.GoodsLGroupName; // ���i�啪�ޖ���
            stockTemp.GoodsMGroup = stockDetailWork.GoodsMGroup; // ���i�����ރR�[�h
            stockTemp.GoodsMGroupName = stockDetailWork.GoodsMGroupName; // ���i�����ޖ���
            stockTemp.BLGroupCode = stockDetailWork.BLGroupCode; // BL�O���[�v�R�[�h
            stockTemp.BLGroupName = stockDetailWork.BLGroupName; // BL�O���[�v�R�[�h����
            stockTemp.BLGoodsCode = stockDetailWork.BLGoodsCode; // BL���i�R�[�h
            stockTemp.BLGoodsFullName = stockDetailWork.BLGoodsFullName; // BL���i�R�[�h���́i�S�p�j
            stockTemp.EnterpriseGanreCode = stockDetailWork.EnterpriseGanreCode; // ���Е��ރR�[�h
            stockTemp.EnterpriseGanreName = stockDetailWork.EnterpriseGanreName; // ���Е��ޖ���
            stockTemp.WarehouseCode = stockDetailWork.WarehouseCode; // �q�ɃR�[�h
            stockTemp.WarehouseName = stockDetailWork.WarehouseName; // �q�ɖ���
            stockTemp.WarehouseShelfNo = stockDetailWork.WarehouseShelfNo; // �q�ɒI��
            stockTemp.StockOrderDivCd = stockDetailWork.StockOrderDivCd; // �d���݌Ɏ�񂹋敪
            stockTemp.OpenPriceDiv = stockDetailWork.OpenPriceDiv; // �I�[�v�����i�敪
            stockTemp.GoodsRateRank = stockDetailWork.GoodsRateRank; // ���i�|�������N
            stockTemp.CustRateGrpCode = stockDetailWork.CustRateGrpCode; // ���Ӑ�|���O���[�v�R�[�h
            stockTemp.SuppRateGrpCode = stockDetailWork.SuppRateGrpCode; // �d����|���O���[�v�R�[�h
            stockTemp.ListPriceTaxExcFl = stockDetailWork.ListPriceTaxExcFl; // �艿�i�Ŕ��C�����j
            stockTemp.ListPriceTaxIncFl = stockDetailWork.ListPriceTaxIncFl; // �艿�i�ō��C�����j
            stockTemp.StockRate = stockDetailWork.StockRate; // �d����
            stockTemp.RateSectStckUnPrc = stockDetailWork.RateSectStckUnPrc; // �|���ݒ苒�_�i�d���P���j
            stockTemp.RateDivStckUnPrc = stockDetailWork.RateDivStckUnPrc; // �|���ݒ�敪�i�d���P���j
            stockTemp.UnPrcCalcCdStckUnPrc = stockDetailWork.UnPrcCalcCdStckUnPrc; // �P���Z�o�敪�i�d���P���j
            stockTemp.PriceCdStckUnPrc = stockDetailWork.PriceCdStckUnPrc; // ���i�敪�i�d���P���j
            stockTemp.StdUnPrcStckUnPrc = stockDetailWork.StdUnPrcStckUnPrc; // ��P���i�d���P���j
            stockTemp.FracProcUnitStcUnPrc = stockDetailWork.FracProcUnitStcUnPrc; // �[�������P�ʁi�d���P���j
            stockTemp.FracProcStckUnPrc = stockDetailWork.FracProcStckUnPrc; // �[�������i�d���P���j
            stockTemp.StockUnitPriceFl = stockDetailWork.StockUnitPriceFl; // �d���P���i�Ŕ��C�����j
            stockTemp.StockUnitTaxPriceFl = stockDetailWork.StockUnitTaxPriceFl; // �d���P���i�ō��C�����j
            stockTemp.StockUnitChngDiv = stockDetailWork.StockUnitChngDiv; // �d���P���ύX�敪
            stockTemp.BfStockUnitPriceFl = stockDetailWork.BfStockUnitPriceFl; // �ύX�O�d���P���i�����j
            stockTemp.BfListPrice = stockDetailWork.BfListPrice; // �ύX�O�艿
            stockTemp.RateBLGoodsCode = stockDetailWork.RateBLGoodsCode; // BL���i�R�[�h�i�|���j
            stockTemp.RateBLGoodsName = stockDetailWork.RateBLGoodsName; // BL���i�R�[�h���́i�|���j
            stockTemp.RateGoodsRateGrpCd = stockDetailWork.RateGoodsRateGrpCd; // ���i�|���O���[�v�R�[�h�i�|���j
            stockTemp.RateGoodsRateGrpNm = stockDetailWork.RateGoodsRateGrpNm; // ���i�|���O���[�v���́i�|���j
            stockTemp.RateBLGroupCode = stockDetailWork.RateBLGroupCode; // BL�O���[�v�R�[�h�i�|���j
            stockTemp.RateBLGroupName = stockDetailWork.RateBLGroupName; // BL�O���[�v���́i�|���j
            stockTemp.StockCount = stockDetailWork.StockCount; // �d����
            stockTemp.OrderCnt = stockDetailWork.OrderCnt; // ��������
            stockTemp.OrderAdjustCnt = stockDetailWork.OrderAdjustCnt; // ����������
            stockTemp.OrderRemainCnt = stockDetailWork.OrderRemainCnt; // �����c��
            stockTemp.RemainCntUpdDate = stockDetailWork.RemainCntUpdDate; // �c���X�V��
            stockTemp.StockPriceTaxExc = stockDetailWork.StockPriceTaxExc; // �d�����z�i�Ŕ����j
            stockTemp.StockPriceTaxInc = stockDetailWork.StockPriceTaxInc; // �d�����z�i�ō��݁j
            stockTemp.StockGoodsCdDetail = stockDetailWork.StockGoodsCd; // �d�����i�敪
            stockTemp.StockPriceConsTaxDetail = stockDetailWork.StockPriceConsTax; // �d�����z����Ŋz
            stockTemp.TaxationCode = stockDetailWork.TaxationCode; // �ېŋ敪
            stockTemp.StockDtiSlipNote1 = stockDetailWork.StockDtiSlipNote1; // �d���`�[���ה��l1
            stockTemp.SalesCustomerCode = stockDetailWork.SalesCustomerCode; // �̔���R�[�h
            stockTemp.SalesCustomerSnm = stockDetailWork.SalesCustomerSnm; // �̔��旪��
            stockTemp.SlipMemo1 = stockDetailWork.SlipMemo1; // �`�[�����P
            stockTemp.SlipMemo2 = stockDetailWork.SlipMemo2; // �`�[�����Q
            stockTemp.SlipMemo3 = stockDetailWork.SlipMemo3; // �`�[�����R
            stockTemp.InsideMemo1 = stockDetailWork.InsideMemo1; // �Г������P
            stockTemp.InsideMemo2 = stockDetailWork.InsideMemo2; // �Г������Q
            stockTemp.InsideMemo3 = stockDetailWork.InsideMemo3; // �Г������R
            stockTemp.SupplierCdDetail = stockDetailWork.SupplierCd; // �d����R�[�h
            stockTemp.SupplierSnmDetail = stockDetailWork.SupplierSnm; // �d���旪��
            stockTemp.AddresseeCodeDetail = stockDetailWork.AddresseeCode; // �[�i��R�[�h
            stockTemp.AddresseeNameDetail = stockDetailWork.AddresseeName; // �[�i�於��
            stockTemp.DirectSendingCdDetail = stockDetailWork.DirectSendingCd; // �����敪
            stockTemp.OrderNumber = stockDetailWork.OrderNumber; // �����ԍ�
            stockTemp.WayToOrder = stockDetailWork.WayToOrder; // �������@
            stockTemp.DeliGdsCmpltDueDate = stockDetailWork.DeliGdsCmpltDueDate; // �[�i�����\���
            stockTemp.ExpectDeliveryDate = stockDetailWork.ExpectDeliveryDate; // ��]�[��
            stockTemp.OrderDataCreateDiv = stockDetailWork.OrderDataCreateDiv; // �����f�[�^�쐬�敪
            stockTemp.OrderDataCreateDate = stockDetailWork.OrderDataCreateDate; // �����f�[�^�쐬��
            stockTemp.OrderFormIssuedDiv = stockDetailWork.OrderFormIssuedDiv; // ���������s�ϋ敪
            //stockTemp.TotalDay = stockDetailWork.TotalDay; // ����
            //stockTemp.NTimeCalcStDate = stockDetailWork.NTimeCalcStDate; // ���񊨒�J�n��
            //stockTemp.PayeeName = stockDetailWork.PayeeName; // �x���於��
            //stockTemp.PayeeName2 = stockDetailWork.PayeeName2; // �x���於�̂Q
            //stockTemp.AddUpEnableCnt = stockDetailWork.AddUpEnableCnt; // �v��\����
            //stockTemp.AlreadyAddUpCnt = stockDetailWork.AlreadyAddUpCnt; // �v��ϐ���
            //stockTemp.EditStatus = stockDetailWork.EditStatus; // �G�f�B�b�g�X�e�[�^�X
            stockTemp.DtlRelationGuid = stockDetailWork.DtlRelationGuid; // ���ʃL�[

            #endregion

            return stockTemp;
        }

        /// <summary>
        /// PramData��UIData�ڍs����
        /// </summary>
        /// <param name="acceptOdrCarWorkList">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        /// <returns>�󒍃}�X�^�i�ԗ��j�I�u�W�F�N�g���X�g</returns>
        private static List<AcceptOdrCar> UIDataFromParamDataProc(AcceptOdrCarWork[] acceptOdrCarWorkList)
        {
            if (acceptOdrCarWorkList == null) return null;

            List<AcceptOdrCar> acceptOdrCarList = new List<AcceptOdrCar>();

            foreach (AcceptOdrCarWork acceptOdrCarWork in acceptOdrCarWorkList)
            {
                acceptOdrCarList.Add(UIDataFromParamData(acceptOdrCarWork));
            }

            return acceptOdrCarList;
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="acceptOdrCarWork">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g</param>
        /// <returns>�󒍃}�X�^�i�ԗ��j�I�u�W�F�N�g</returns>
        /// <br>Update Note: 2009/09/08 ���M ���q�Ǘ��@�\�Ή�</br>
        private static AcceptOdrCar UIDataFromParamDataProc(AcceptOdrCarWork acceptOdrCarWork)
        {
            AcceptOdrCar acceptOdrCar = new AcceptOdrCar();

            acceptOdrCar.CreateDateTime = acceptOdrCarWork.CreateDateTime; // �쐬����
            acceptOdrCar.UpdateDateTime = acceptOdrCarWork.UpdateDateTime; // �X�V����
            acceptOdrCar.EnterpriseCode = acceptOdrCarWork.EnterpriseCode; // ��ƃR�[�h
            acceptOdrCar.FileHeaderGuid = acceptOdrCarWork.FileHeaderGuid; // GUID
            acceptOdrCar.UpdEmployeeCode = acceptOdrCarWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            acceptOdrCar.UpdAssemblyId1 = acceptOdrCarWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            acceptOdrCar.UpdAssemblyId2 = acceptOdrCarWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            acceptOdrCar.LogicalDeleteCode = acceptOdrCarWork.LogicalDeleteCode; // �_���폜�敪
            acceptOdrCar.AcceptAnOrderNo = acceptOdrCarWork.AcceptAnOrderNo; // �󒍔ԍ�
            acceptOdrCar.AcptAnOdrStatus = acceptOdrCarWork.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            acceptOdrCar.DataInputSystem = acceptOdrCarWork.DataInputSystem; // �f�[�^���̓V�X�e��
            acceptOdrCar.CarMngNo = acceptOdrCarWork.CarMngNo; // �ԗ��Ǘ��ԍ�
            acceptOdrCar.CarMngCode = acceptOdrCarWork.CarMngCode; // ���q�Ǘ��R�[�h
            acceptOdrCar.NumberPlate1Code = acceptOdrCarWork.NumberPlate1Code; // ���^�������ԍ�
            acceptOdrCar.NumberPlate1Name = acceptOdrCarWork.NumberPlate1Name; // ���^�����ǖ���
            acceptOdrCar.NumberPlate2 = acceptOdrCarWork.NumberPlate2; // �ԗ��o�^�ԍ��i��ʁj
            acceptOdrCar.NumberPlate3 = acceptOdrCarWork.NumberPlate3; // �ԗ��o�^�ԍ��i�J�i�j
            acceptOdrCar.NumberPlate4 = acceptOdrCarWork.NumberPlate4; // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            // ����
            //acceptOdrCar.FirstEntryDate = acceptOdrCarWork.FirstEntryDate; // ���N�x

            // --- UPD 2009/09/08 ---------->>>>>
            //int iyy = acceptOdrCarWork.FirstEntryDate / 100;
            //int imm = acceptOdrCarWork.FirstEntryDate % 100;
            //DateTime produceTypeOfYearInput = DateTime.MinValue;
            //if ((iyy != 0) && (imm != 0)) produceTypeOfYearInput = new DateTime(iyy, imm, 1);
            //acceptOdrCar.FirstEntryDate = produceTypeOfYearInput; // ���N�x
            acceptOdrCar.FirstEntryDate = acceptOdrCarWork.FirstEntryDate; // ���N�x
            // --- UPD 2009/09/08 ----------<<<<<
            acceptOdrCar.MakerCode = acceptOdrCarWork.MakerCode; // ���[�J�[�R�[�h
            acceptOdrCar.MakerFullName = acceptOdrCarWork.MakerFullName; // ���[�J�[�S�p����
            acceptOdrCar.MakerHalfName = acceptOdrCarWork.MakerHalfName; // ���[�J�[���p����
            acceptOdrCar.ModelCode = acceptOdrCarWork.ModelCode; // �Ԏ�R�[�h
            acceptOdrCar.ModelSubCode = acceptOdrCarWork.ModelSubCode; // �Ԏ�T�u�R�[�h
            acceptOdrCar.ModelFullName = acceptOdrCarWork.ModelFullName; // �Ԏ�S�p����
            acceptOdrCar.ModelHalfName = acceptOdrCarWork.ModelHalfName; // �Ԏ피�p����
            acceptOdrCar.ExhaustGasSign = acceptOdrCarWork.ExhaustGasSign; // �r�K�X�L��
            acceptOdrCar.SeriesModel = acceptOdrCarWork.SeriesModel; // �V���[�Y�^��
            acceptOdrCar.CategorySignModel = acceptOdrCarWork.CategorySignModel; // �^���i�ޕʋL���j
            acceptOdrCar.FullModel = acceptOdrCarWork.FullModel; // �^���i�t���^�j
            acceptOdrCar.ModelDesignationNo = acceptOdrCarWork.ModelDesignationNo; // �^���w��ԍ�
            acceptOdrCar.CategoryNo = acceptOdrCarWork.CategoryNo; // �ޕʔԍ�
            acceptOdrCar.FrameModel = acceptOdrCarWork.FrameModel; // �ԑ�^��
            acceptOdrCar.FrameNo = acceptOdrCarWork.FrameNo; // �ԑ�ԍ�
            acceptOdrCar.SearchFrameNo = acceptOdrCarWork.SearchFrameNo; // �ԑ�ԍ��i�����p�j
            acceptOdrCar.EngineModelNm = acceptOdrCarWork.EngineModelNm; // �G���W���^������
            acceptOdrCar.RelevanceModel = acceptOdrCarWork.RelevanceModel; // �֘A�^��
            acceptOdrCar.SubCarNmCd = acceptOdrCarWork.SubCarNmCd; // �T�u�Ԗ��R�[�h
            acceptOdrCar.ModelGradeSname = acceptOdrCarWork.ModelGradeSname; // �^���O���[�h����
            acceptOdrCar.ColorCode = acceptOdrCarWork.ColorCode; // �J���[�R�[�h
            acceptOdrCar.ColorName1 = acceptOdrCarWork.ColorName1; // �J���[����1
            acceptOdrCar.TrimCode = acceptOdrCarWork.TrimCode; // �g�����R�[�h
            acceptOdrCar.TrimName = acceptOdrCarWork.TrimName; // �g��������
            acceptOdrCar.Mileage = acceptOdrCarWork.Mileage; // �ԗ����s����
            acceptOdrCar.CategoryObjAry = acceptOdrCarWork.CategoryObjAry; // �����I�u�W�F�N�g�z��
            acceptOdrCar.FullModelFixedNoAry = acceptOdrCarWork.FullModelFixedNoAry; // �t���^���Œ�ԍ��z��

            // --- ADD 2009/09/08 ---------->>>>>
            acceptOdrCar.CarNote = acceptOdrCarWork.CarNote; // ���q���l
            // --- ADD 2009/09/08 ----------<<<<<

            // --- ADD 2010/04/27 ---------->>>>>
            if (null == acceptOdrCarWork.FreeSrchMdlFxdNoAry || 0 >= acceptOdrCarWork.FreeSrchMdlFxdNoAry.Length)
            {
                acceptOdrCar.FreeSrchMdlFxdNoAry = new string[0];
            }
            else
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(acceptOdrCarWork.FreeSrchMdlFxdNoAry);
                acceptOdrCar.FreeSrchMdlFxdNoAry = (string[])formatter.Deserialize(ms);  // ���R�����^���Œ�ԍ��z��
                ms.Close();
            }
            // --- ADD 2010/04/27 ----------<<<<<

            // PMNS:���Y/�O�ԋ敪�Z�b�g
            // --- ADD 2013/03/21 ---------->>>>>
            acceptOdrCar.DomesticForeignCode = acceptOdrCarWork.DomesticForeignCode; // ���Y/�O�ԋ敪
            // --- ADD 2013/03/21 ----------<<<<<

            return acceptOdrCar;
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="depsitDataWork">�������[�N�I�u�W�F�N�g</param>
        /// <returns>�����f�[�^�I�u�W�F�N�g</returns>
        private static SearchDepsitMain UIDataFromParamDataProc(DepsitDataWork depsitDataWork)
        {
            SearchDepsitMain searchDepsitMain = new SearchDepsitMain();
            DepsitMainWork depsitMainWork;
            DepsitDtlWork[] depsitDtlWorkArray;

            DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlWorkArray);
            searchDepsitMain.CreateDateTime = depsitMainWork.CreateDateTime; // �쐬����
            searchDepsitMain.UpdateDateTime = depsitMainWork.UpdateDateTime; // �X�V����
            searchDepsitMain.EnterpriseCode = depsitMainWork.EnterpriseCode; // ��ƃR�[�h
            searchDepsitMain.FileHeaderGuid = depsitMainWork.FileHeaderGuid; // GUID
            searchDepsitMain.UpdEmployeeCode = depsitMainWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            searchDepsitMain.UpdAssemblyId1 = depsitMainWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            searchDepsitMain.UpdAssemblyId2 = depsitMainWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            searchDepsitMain.LogicalDeleteCode = depsitMainWork.LogicalDeleteCode; // �_���폜�敪
            searchDepsitMain.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            searchDepsitMain.DepositDebitNoteCd = depsitMainWork.DepositDebitNoteCd; // �����ԍ��敪
            searchDepsitMain.DepositSlipNo = depsitMainWork.DepositSlipNo; // �����`�[�ԍ�
            searchDepsitMain.SalesSlipNum = depsitMainWork.SalesSlipNum; // ����`�[�ԍ�
            searchDepsitMain.InputDepositSecCd = depsitMainWork.InputDepositSecCd; // �������͋��_�R�[�h
            searchDepsitMain.AddUpSecCode = depsitMainWork.AddUpSecCode; // �v�㋒�_�R�[�h
            searchDepsitMain.UpdateSecCd = depsitMainWork.UpdateSecCd; // �X�V���_�R�[�h
            searchDepsitMain.SubSectionCode = depsitMainWork.SubSectionCode; // ����R�[�h
            searchDepsitMain.DepositDate = depsitMainWork.DepositDate; // �������t
            searchDepsitMain.AddUpADate = depsitMainWork.AddUpADate; // �v����t
            searchDepsitMain.DepositTotal = depsitMainWork.DepositTotal; // �����v
            searchDepsitMain.Deposit = depsitMainWork.Deposit; // �������z
            searchDepsitMain.FeeDeposit = depsitMainWork.FeeDeposit; // �萔�������z
            searchDepsitMain.DiscountDeposit = depsitMainWork.DiscountDeposit; // �l�������z
            searchDepsitMain.AutoDepositCd = depsitMainWork.AutoDepositCd; // ���������敪
            searchDepsitMain.DraftDrawingDate = depsitMainWork.DraftDrawingDate; // ��`�U�o��
            searchDepsitMain.DraftKind = depsitMainWork.DraftKind; // ��`���
            searchDepsitMain.DraftKindName = depsitMainWork.DraftKindName; // ��`��ޖ���
            searchDepsitMain.DraftDivide = depsitMainWork.DraftDivide; // ��`�敪
            searchDepsitMain.DraftDivideName = depsitMainWork.DraftDivideName; // ��`�敪����
            searchDepsitMain.DraftNo = depsitMainWork.DraftNo; // ��`�ԍ�
            searchDepsitMain.DepositAllowance = depsitMainWork.DepositAllowance; // ���������z
            searchDepsitMain.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce; // ���������c��
            searchDepsitMain.DebitNoteLinkDepoNo = depsitMainWork.DebitNoteLinkDepoNo; // �ԍ������A���ԍ�
            searchDepsitMain.LastReconcileAddUpDt = depsitMainWork.LastReconcileAddUpDt; // �ŏI�������݌v���
            searchDepsitMain.DepositAgentCode = depsitMainWork.DepositAgentCode; // �����S���҃R�[�h
            searchDepsitMain.DepositAgentNm = depsitMainWork.DepositAgentNm; // �����S���Җ���
            searchDepsitMain.DepositInputAgentCd = depsitMainWork.DepositInputAgentCd; // �������͎҃R�[�h
            searchDepsitMain.DepositInputAgentNm = depsitMainWork.DepositInputAgentNm; // �������͎Җ���
            searchDepsitMain.CustomerCode = depsitMainWork.CustomerCode; // ���Ӑ�R�[�h
            searchDepsitMain.CustomerName = depsitMainWork.CustomerName; // ���Ӑ於��
            searchDepsitMain.CustomerName2 = depsitMainWork.CustomerName2; // ���Ӑ於��2
            searchDepsitMain.CustomerSnm = depsitMainWork.CustomerSnm; // ���Ӑ旪��
            searchDepsitMain.ClaimCode = depsitMainWork.ClaimCode; // ������R�[�h
            searchDepsitMain.ClaimName = depsitMainWork.ClaimName; // �����於��
            searchDepsitMain.ClaimName2 = depsitMainWork.ClaimName2; // �����於��2
            searchDepsitMain.ClaimSnm = depsitMainWork.ClaimSnm; // �����旪��
            searchDepsitMain.Outline = depsitMainWork.Outline; // �`�[�E�v
            searchDepsitMain.BankCode = depsitMainWork.BankCode; // ��s�R�[�h
            searchDepsitMain.BankName = depsitMainWork.BankName; // ��s����

            //searchDepsitMain.CreateDateTime = depsitDtlWorkArray[0].CreateDateTime; // �쐬����
            //searchDepsitMain.UpdateDateTime = depsitDtlWorkArray[0].UpdateDateTime; // �X�V����
            //searchDepsitMain.EnterpriseCode = depsitDtlWorkArray[0].EnterpriseCode; // ��ƃR�[�h
            //searchDepsitMain.FileHeaderGuid = depsitDtlWorkArray[0].FileHeaderGuid; // GUID
            //searchDepsitMain.UpdEmployeeCode = depsitDtlWorkArray[0].UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            //searchDepsitMain.UpdAssemblyId1 = depsitDtlWorkArray[0].UpdAssemblyId1; // �X�V�A�Z���u��ID1
            //searchDepsitMain.UpdAssemblyId2 = depsitDtlWorkArray[0].UpdAssemblyId2; // �X�V�A�Z���u��ID2
            //searchDepsitMain.LogicalDeleteCode = depsitDtlWorkArray[0].LogicalDeleteCode; // �_���폜�敪
            //searchDepsitMain.AcptAnOdrStatus = depsitDtlWorkArray[0].AcptAnOdrStatus; // �󒍃X�e�[�^�X
            //searchDepsitMain.DepositSlipNo = depsitDtlWorkArray[0].DepositSlipNo; // �����`�[�ԍ�

            if (depsitDtlWorkArray != null)
            {
                for (int i = 0; i < depsitDtlWorkArray.Length; i++)
                {
                    searchDepsitMain.DepositRowNo[i] = depsitDtlWorkArray[i].DepositRowNo; // �����s�ԍ�
                    searchDepsitMain.MoneyKindCode[i] = depsitDtlWorkArray[i].MoneyKindCode; // ����R�[�h
                    searchDepsitMain.MoneyKindName[i] = depsitDtlWorkArray[i].MoneyKindName; // ���햼��
                    searchDepsitMain.MoneyKindDiv[i] = depsitDtlWorkArray[i].MoneyKindDiv; // ����敪
                    searchDepsitMain.DepositDtl[i] = depsitDtlWorkArray[i].Deposit; // �������z
                    searchDepsitMain.ValidityTerm[i] = depsitDtlWorkArray[i].ValidityTerm; // �L������
                }
            }

            return searchDepsitMain;
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="searchDepsitMain">�����f�[�^�I�u�W�F�N�g</param>
        /// <returns>�������[�N�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Update Note : 2012/01/19 tianjw</br>
        /// <br>              Redmine#28098 ���_�Ǘ��^���M�ς݃G���[</br>
        /// </remarks>
        private static DepsitDataWork ParamDataFromUIDataProc(SearchDepsitMain searchDepsitMain)
        {
            DepsitDataWork depsitDataWork = new DepsitDataWork();
            DepsitMainWork depsitMainWork = new DepsitMainWork();
            DepsitDtlWork[] depsitDtlWorkArray = new DepsitDtlWork[searchDepsitMain.DepositRowNo.Length];

            depsitMainWork.CreateDateTime = searchDepsitMain.CreateDateTime; // �쐬����
            depsitMainWork.UpdateDateTime = searchDepsitMain.UpdateDateTime; // �X�V����
            depsitMainWork.EnterpriseCode = searchDepsitMain.EnterpriseCode; // ��ƃR�[�h
            depsitMainWork.FileHeaderGuid = searchDepsitMain.FileHeaderGuid; // GUID
            depsitMainWork.UpdEmployeeCode = searchDepsitMain.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            depsitMainWork.UpdAssemblyId1 = searchDepsitMain.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            depsitMainWork.UpdAssemblyId2 = searchDepsitMain.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            depsitMainWork.LogicalDeleteCode = searchDepsitMain.LogicalDeleteCode; // �_���폜�敪
            depsitMainWork.AcptAnOdrStatus = searchDepsitMain.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            depsitMainWork.DepositDebitNoteCd = searchDepsitMain.DepositDebitNoteCd; // �����ԍ��敪
            depsitMainWork.DepositSlipNo = searchDepsitMain.DepositSlipNo; // �����`�[�ԍ�
            depsitMainWork.SalesSlipNum = searchDepsitMain.SalesSlipNum; // ����`�[�ԍ�
            depsitMainWork.InputDepositSecCd = searchDepsitMain.InputDepositSecCd; // �������͋��_�R�[�h
            depsitMainWork.AddUpSecCode = searchDepsitMain.AddUpSecCode; // �v�㋒�_�R�[�h
            depsitMainWork.UpdateSecCd = searchDepsitMain.UpdateSecCd; // �X�V���_�R�[�h
            depsitMainWork.SubSectionCode = searchDepsitMain.SubSectionCode; // ����R�[�h
            depsitMainWork.DepositDate = searchDepsitMain.DepositDate; // �������t
            depsitMainWork.PreDepositDate = searchDepsitMain.DepositDate; // �O��������t // ADD 2012/01/19 tianjw Redmine#27390
            depsitMainWork.AddUpADate = searchDepsitMain.AddUpADate; // �v����t
            depsitMainWork.DepositTotal = searchDepsitMain.DepositTotal; // �����v
            depsitMainWork.Deposit = searchDepsitMain.Deposit; // �������z
            depsitMainWork.FeeDeposit = searchDepsitMain.FeeDeposit; // �萔�������z
            depsitMainWork.DiscountDeposit = searchDepsitMain.DiscountDeposit; // �l�������z
            depsitMainWork.AutoDepositCd = searchDepsitMain.AutoDepositCd; // ���������敪
            depsitMainWork.DraftDrawingDate = searchDepsitMain.DraftDrawingDate; // ��`�U�o��
            depsitMainWork.DraftKind = searchDepsitMain.DraftKind; // ��`���
            depsitMainWork.DraftKindName = searchDepsitMain.DraftKindName; // ��`��ޖ���
            depsitMainWork.DraftDivide = searchDepsitMain.DraftDivide; // ��`�敪
            depsitMainWork.DraftDivideName = searchDepsitMain.DraftDivideName; // ��`�敪����
            depsitMainWork.DraftNo = searchDepsitMain.DraftNo; // ��`�ԍ�
            depsitMainWork.DepositAllowance = searchDepsitMain.DepositAllowance; // ���������z
            depsitMainWork.DepositAlwcBlnce = searchDepsitMain.DepositAlwcBlnce; // ���������c��
            depsitMainWork.DebitNoteLinkDepoNo = searchDepsitMain.DebitNoteLinkDepoNo; // �ԍ������A���ԍ�
            depsitMainWork.LastReconcileAddUpDt = searchDepsitMain.LastReconcileAddUpDt; // �ŏI�������݌v���
            depsitMainWork.DepositAgentCode = searchDepsitMain.DepositAgentCode; // �����S���҃R�[�h
            depsitMainWork.DepositAgentNm = searchDepsitMain.DepositAgentNm; // �����S���Җ���
            depsitMainWork.DepositInputAgentCd = searchDepsitMain.DepositInputAgentCd; // �������͎҃R�[�h
            depsitMainWork.DepositInputAgentNm = searchDepsitMain.DepositInputAgentNm; // �������͎Җ���
            depsitMainWork.CustomerCode = searchDepsitMain.CustomerCode; // ���Ӑ�R�[�h
            depsitMainWork.CustomerName = searchDepsitMain.CustomerName; // ���Ӑ於��
            depsitMainWork.CustomerName2 = searchDepsitMain.CustomerName2; // ���Ӑ於��2
            depsitMainWork.CustomerSnm = searchDepsitMain.CustomerSnm; // ���Ӑ旪��
            depsitMainWork.ClaimCode = searchDepsitMain.ClaimCode; // ������R�[�h
            depsitMainWork.ClaimName = searchDepsitMain.ClaimName; // �����於��
            depsitMainWork.ClaimName2 = searchDepsitMain.ClaimName2; // �����於��2
            depsitMainWork.ClaimSnm = searchDepsitMain.ClaimSnm; // �����旪��
            depsitMainWork.Outline = searchDepsitMain.Outline; // �`�[�E�v
            depsitMainWork.BankCode = searchDepsitMain.BankCode; // ��s�R�[�h
            depsitMainWork.BankName = searchDepsitMain.BankName; // ��s����

            for (int i = 0; i < searchDepsitMain.DepositRowNo.Length; i++)
            {
                DepsitDtlWork depsitDtlWork = new DepsitDtlWork();
                depsitDtlWork.DepositRowNo = searchDepsitMain.DepositRowNo[i]; // �����s�ԍ�
                depsitDtlWork.MoneyKindCode = searchDepsitMain.MoneyKindCode[i]; // ����R�[�h
                depsitDtlWork.MoneyKindName = searchDepsitMain.MoneyKindName[i]; // ���햼��
                depsitDtlWork.MoneyKindDiv = searchDepsitMain.MoneyKindDiv[i]; // ����敪
                depsitDtlWork.Deposit = searchDepsitMain.DepositDtl[i]; // �������z
                depsitDtlWork.ValidityTerm = searchDepsitMain.ValidityTerm[i]; // �L������
                depsitDtlWorkArray[i] = depsitDtlWork;
            }

            DepsitDataUtil.Union(out depsitDataWork, depsitMainWork, depsitDtlWorkArray);

            return depsitDataWork;
        }

        /// <summary>
        /// ���ڃR�s�[����
        /// </summary>
        /// <param name="source">�R�s�[������f�[�^�I�u�W�F�N�g</param>
        /// <param name="target">�R�s�[�攄��f�[�^�I�u�W�F�N�g</param>
        private static void CopyItemProc(SalesSlip source, ref SalesSlip target)
        {
            target.CreateDateTime = source.CreateDateTime; // �쐬����
            target.UpdateDateTime = source.UpdateDateTime; // �X�V����
            target.EnterpriseCode = source.EnterpriseCode; // ��ƃR�[�h
            target.FileHeaderGuid = source.FileHeaderGuid; // GUID
            target.UpdEmployeeCode = source.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            target.UpdAssemblyId1 = source.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            target.UpdAssemblyId2 = source.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            target.LogicalDeleteCode = source.LogicalDeleteCode; // �_���폜�敪
            target.AcptAnOdrStatus = source.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            target.SalesSlipNum = source.SalesSlipNum; // ����`�[�ԍ�
            target.SectionCode = source.SectionCode; // ���_�R�[�h
            target.SubSectionCode = source.SubSectionCode; // ����R�[�h
            target.DebitNoteDiv = source.DebitNoteDiv; // �ԓ`�敪
            target.DebitNLnkSalesSlNum = source.DebitNLnkSalesSlNum; // �ԍ��A������`�[�ԍ�
            target.SalesSlipCd = source.SalesSlipCd; // ����`�[�敪
            target.SalesGoodsCd = source.SalesGoodsCd; // ���㏤�i�敪
            target.AccRecDivCd = source.AccRecDivCd; // ���|�敪
            target.SalesInpSecCd = source.SalesInpSecCd; // ������͋��_�R�[�h
            target.DemandAddUpSecCd = source.DemandAddUpSecCd; // �����v�㋒�_�R�[�h
            target.ResultsAddUpSecCd = source.ResultsAddUpSecCd; // ���ьv�㋒�_�R�[�h
            target.UpdateSecCd = source.UpdateSecCd; // �X�V���_�R�[�h
            target.SalesSlipUpdateCd = source.SalesSlipUpdateCd; // ����`�[�X�V�敪
            target.SearchSlipDate = source.SearchSlipDate; // �`�[�������t
            target.ShipmentDay = source.ShipmentDay; // �o�ד��t
            target.SalesDate = source.SalesDate; // ������t
            target.AddUpADate = source.AddUpADate; // �v����t
            target.DelayPaymentDiv = source.DelayPaymentDiv; // �����敪
            target.EstimateFormNo = source.EstimateFormNo; // ���Ϗ��ԍ�
            target.EstimateDivide = source.EstimateDivide; // ���ϋ敪
            target.InputAgenCd = source.InputAgenCd; // ���͒S���҃R�[�h
            target.InputAgenNm = source.InputAgenNm; // ���͒S���Җ���
            target.SalesInputCode = source.SalesInputCode; // ������͎҃R�[�h
            target.SalesInputName = source.SalesInputName; // ������͎Җ���
            target.FrontEmployeeCd = source.FrontEmployeeCd; // ��t�]�ƈ��R�[�h
            target.FrontEmployeeNm = source.FrontEmployeeNm; // ��t�]�ƈ�����
            target.SalesEmployeeCd = source.SalesEmployeeCd; // �̔��]�ƈ��R�[�h
            target.SalesEmployeeNm = source.SalesEmployeeNm; // �̔��]�ƈ�����
            target.TotalAmountDispWayCd = source.TotalAmountDispWayCd; // ���z�\�����@�敪
            target.TtlAmntDispRateApy = source.TtlAmntDispRateApy; // ���z�\���|���K�p�敪
            target.SalesTotalTaxInc = source.SalesTotalTaxInc; // ����`�[���v�i�ō��݁j
            target.SalesTotalTaxExc = source.SalesTotalTaxExc; // ����`�[���v�i�Ŕ����j
            target.SalesPrtTotalTaxInc = source.SalesPrtTotalTaxInc; // ���㕔�i���v�i�ō��݁j
            target.SalesPrtTotalTaxExc = source.SalesPrtTotalTaxExc; // ���㕔�i���v�i�Ŕ����j
            target.SalesWorkTotalTaxInc = source.SalesWorkTotalTaxInc; // �����ƍ��v�i�ō��݁j
            target.SalesWorkTotalTaxExc = source.SalesWorkTotalTaxExc; // �����ƍ��v�i�Ŕ����j
            target.SalesSubtotalTaxInc = source.SalesSubtotalTaxInc; // ���㏬�v�i�ō��݁j
            target.SalesSubtotalTaxExc = source.SalesSubtotalTaxExc; // ���㏬�v�i�Ŕ����j
            target.SalesPrtSubttlInc = source.SalesPrtSubttlInc; // ���㕔�i���v�i�ō��݁j
            target.SalesPrtSubttlExc = source.SalesPrtSubttlExc; // ���㕔�i���v�i�Ŕ����j
            target.SalesWorkSubttlInc = source.SalesWorkSubttlInc; // �����Ə��v�i�ō��݁j
            target.SalesWorkSubttlExc = source.SalesWorkSubttlExc; // �����Ə��v�i�Ŕ����j
            target.SalesNetPrice = source.SalesNetPrice; // ���㐳�����z
            target.SalesSubtotalTax = source.SalesSubtotalTax; // ���㏬�v�i�Łj
            target.ItdedSalesOutTax = source.ItdedSalesOutTax; // ����O�őΏۊz
            target.ItdedSalesInTax = source.ItdedSalesInTax; // ������őΏۊz
            target.SalSubttlSubToTaxFre = source.SalSubttlSubToTaxFre; // ���㏬�v��ېőΏۊz
            target.SalesOutTax = source.SalesOutTax; // ������z����Ŋz�i�O�Łj
            target.SalAmntConsTaxInclu = source.SalAmntConsTaxInclu; // ������z����Ŋz�i���Łj
            target.SalesDisTtlTaxExc = source.SalesDisTtlTaxExc; // ����l�����z�v�i�Ŕ����j
            target.ItdedSalesDisOutTax = source.ItdedSalesDisOutTax; // ����l���O�őΏۊz���v
            target.ItdedSalesDisInTax = source.ItdedSalesDisInTax; // ����l�����őΏۊz���v
            target.ItdedPartsDisOutTax = source.ItdedPartsDisOutTax; // ���i�l���Ώۊz���v�i�Ŕ����j
            target.ItdedPartsDisInTax = source.ItdedPartsDisInTax; // ���i�l���Ώۊz���v�i�ō��݁j
            target.ItdedWorkDisOutTax = source.ItdedWorkDisOutTax; // ��ƒl���Ώۊz���v�i�Ŕ����j
            target.ItdedWorkDisInTax = source.ItdedWorkDisInTax; // ��ƒl���Ώۊz���v�i�ō��݁j
            target.ItdedSalesDisTaxFre = source.ItdedSalesDisTaxFre; // ����l����ېőΏۊz���v
            target.SalesDisOutTax = source.SalesDisOutTax; // ����l������Ŋz�i�O�Łj
            target.SalesDisTtlTaxInclu = source.SalesDisTtlTaxInclu; // ����l������Ŋz�i���Łj
            target.PartsDiscountRate = source.PartsDiscountRate; // ���i�l����
            target.RavorDiscountRate = source.RavorDiscountRate; // �H���l����
            target.TotalCost = source.TotalCost; // �������z�v
            target.ConsTaxLayMethod = source.ConsTaxLayMethod; // ����œ]�ŕ���
            target.ConsTaxRate = source.ConsTaxRate; // ����Őŗ�
            target.FractionProcCd = source.FractionProcCd; // �[�������敪
            target.AccRecConsTax = source.AccRecConsTax; // ���|�����
            target.AutoDepositCd = source.AutoDepositCd; // ���������敪
            target.AutoDepositNoteDiv = source.AutoDepositNoteDiv; // �����������l�敪 // ADD 2013/01/18 �c���� Redmine#33797
            target.AutoDepositSlipNo = source.AutoDepositSlipNo; // ���������`�[�ԍ�
            target.DepositAllowanceTtl = source.DepositAllowanceTtl; // �����������v�z
            target.DepositAlwcBlnce = source.DepositAlwcBlnce; // ���������c��
            target.ClaimCode = source.ClaimCode; // ������R�[�h
            target.ClaimSnm = source.ClaimSnm; // �����旪��
            target.CustomerCode = source.CustomerCode; // ���Ӑ�R�[�h
            target.CustomerName = source.CustomerName; // ���Ӑ於��
            target.CustomerName2 = source.CustomerName2; // ���Ӑ於��2
            target.CustomerSnm = source.CustomerSnm; // ���Ӑ旪��
            target.HonorificTitle = source.HonorificTitle; // �h��
            target.OutputNameCode = source.OutputNameCode; // �����R�[�h
            target.OutputName = source.OutputName; // ��������
            target.CustSlipNo = source.CustSlipNo; // ���Ӑ�`�[�ԍ�
            target.SlipAddressDiv = source.SlipAddressDiv; // �`�[�Z���敪
            target.AddresseeCode = source.AddresseeCode; // �[�i��R�[�h
            target.AddresseeName = source.AddresseeName; // �[�i�於��
            target.AddresseeName2 = source.AddresseeName2; // �[�i�於��2
            target.AddresseePostNo = source.AddresseePostNo; // �[�i��X�֔ԍ�
            target.AddresseeAddr1 = source.AddresseeAddr1; // �[�i��Z��1(�s���{���s��S�E�����E��)
            target.AddresseeAddr3 = source.AddresseeAddr3; // �[�i��Z��3(�Ԓn)
            target.AddresseeAddr4 = source.AddresseeAddr4; // �[�i��Z��4(�A�p�[�g����)
            target.AddresseeTelNo = source.AddresseeTelNo; // �[�i��d�b�ԍ�
            target.AddresseeFaxNo = source.AddresseeFaxNo; // �[�i��FAX�ԍ�
            target.PartySaleSlipNum = source.PartySaleSlipNum; // �����`�[�ԍ�
            target.SlipNote = source.SlipNote; // �`�[���l
            target.SlipNote2 = source.SlipNote2; // �`�[���l�Q
            target.SlipNote3 = source.SlipNote3; // �`�[���l�R
            target.RetGoodsReasonDiv = source.RetGoodsReasonDiv; // �ԕi���R�R�[�h
            target.RetGoodsReason = source.RetGoodsReason; // �ԕi���R
            target.RegiProcDate = source.RegiProcDate; // ���W������
            target.CashRegisterNo = source.CashRegisterNo; // ���W�ԍ�
            target.PosReceiptNo = source.PosReceiptNo; // POS���V�[�g�ԍ�
            target.DetailRowCount = source.DetailRowCount; // ���׍s��
            target.EdiSendDate = source.EdiSendDate; // �d�c�h���M��
            target.EdiTakeInDate = source.EdiTakeInDate; // �d�c�h�捞��
            target.UoeRemark1 = source.UoeRemark1; // �t�n�d���}�[�N�P
            target.UoeRemark2 = source.UoeRemark2; // �t�n�d���}�[�N�Q
            target.SlipPrintDivCd = source.SlipPrintDivCd; // �`�[���s�敪
            target.SlipPrintFinishCd = source.SlipPrintFinishCd; // �`�[���s�ϋ敪
            target.SalesSlipPrintDate = source.SalesSlipPrintDate; // ����`�[���s��
            target.BusinessTypeCode = source.BusinessTypeCode; // �Ǝ�R�[�h
            target.BusinessTypeName = source.BusinessTypeName; // �Ǝ햼��
            target.OrderNumber = source.OrderNumber; // �����ԍ�
            target.DeliveredGoodsDiv = source.DeliveredGoodsDiv; // �[�i�敪
            target.DeliveredGoodsDivNm = source.DeliveredGoodsDivNm; // �[�i�敪����
            target.SalesAreaCode = source.SalesAreaCode; // �̔��G���A�R�[�h
            target.SalesAreaName = source.SalesAreaName; // �̔��G���A����
            target.ReconcileFlag = source.ReconcileFlag; // �����t���O
            target.SlipPrtSetPaperId = source.SlipPrtSetPaperId; // �`�[����ݒ�p���[ID
            target.CompleteCd = source.CompleteCd; // �ꎮ�`�[�敪
            target.SalesPriceFracProcCd = source.SalesPriceFracProcCd; // ������z�[�������敪
            target.StockGoodsTtlTaxExc = source.StockGoodsTtlTaxExc; // �݌ɏ��i���v���z�i�Ŕ��j
            target.PureGoodsTtlTaxExc = source.PureGoodsTtlTaxExc; // �������i���v���z�i�Ŕ��j
            target.ListPricePrintDiv = source.ListPricePrintDiv; // �艿����敪
            target.EraNameDispCd1 = source.EraNameDispCd1; // �����\���敪�P
            target.EstimaTaxDivCd = source.EstimaTaxDivCd; // ���Ϗ���ŋ敪
            target.EstimateFormPrtCd = source.EstimateFormPrtCd; // ���Ϗ�����敪
            target.EstimateSubject = source.EstimateSubject; // ���ό���
            target.Footnotes1 = source.Footnotes1; // �r���P
            target.Footnotes2 = source.Footnotes2; // �r���Q
            target.EstimateTitle1 = source.EstimateTitle1; // ���σ^�C�g���P
            target.EstimateTitle2 = source.EstimateTitle2; // ���σ^�C�g���Q
            target.EstimateTitle3 = source.EstimateTitle3; // ���σ^�C�g���R
            target.EstimateTitle4 = source.EstimateTitle4; // ���σ^�C�g���S
            target.EstimateTitle5 = source.EstimateTitle5; // ���σ^�C�g���T
            target.EstimateNote1 = source.EstimateNote1; // ���ϔ��l�P
            target.EstimateNote2 = source.EstimateNote2; // ���ϔ��l�Q
            target.EstimateNote3 = source.EstimateNote3; // ���ϔ��l�R
            target.EstimateNote4 = source.EstimateNote4; // ���ϔ��l�S
            target.EstimateNote5 = source.EstimateNote5; // ���ϔ��l�T
            target.EstimateValidityDate = source.EstimateValidityDate; // ���ϗL������
            target.PartsNoPrtCd = source.PartsNoPrtCd; // �i�Ԉ󎚋敪
            target.OptionPringDivCd = source.OptionPringDivCd; // �I�v�V�����󎚋敪
            target.RateUseCode = source.RateUseCode; // �|���g�p�敪
            target.InputMode = source.InputMode; // ���̓��[�h
            target.SalesSlipDisplay = source.SalesSlipDisplay; // ����`�[�敪(��ʕ\���p)
            target.AcptAnOdrStatusDisplay = source.AcptAnOdrStatusDisplay; // �󒍃X�e�[�^�X
            target.CustRateGrpCode = source.CustRateGrpCode; // ���Ӑ�|���O���[�v�R�[�h
            target.ClaimName = source.ClaimName; // �����於��
            target.ClaimName2 = source.ClaimName2; // �����於�̂Q
            target.CreditMngCode = source.CreditMngCode; // �^�M�Ǘ��敪
            target.TotalDay = source.TotalDay; // ����
            target.NTimeCalcStDate = source.NTimeCalcStDate; // ���񊨒�J�n��
            target.TotalMoneyForGrossProfit = source.TotalMoneyForGrossProfit; // �e���v�Z�p������z
            target.SectionName = source.SectionName; // ���_����
            target.SubSectionName = source.SubSectionName; // ���喼��
            target.CarMngDivCd = source.CarMngDivCd; // ���q�Ǘ��敪
            target.SearchMode = source.SearchMode; // ���i�������[�h
            target.SearchCarMode = source.SearchCarMode; // �ԗ��������[�h
            target.CustOrderNoDispDiv = source.CustOrderNoDispDiv; // ���Ӑ撍�ԕ\���敪
            target.CustWarehouseCd = source.CustWarehouseCd; // ���Ӑ�D��q�ɃR�[�h
            target.AccRecDivCd = source.AccRecDivCd; // ���|�敪
            target.TransStopDate = source.TransStopDate; // ������~��
        }

        /// <summary>
        /// ���ڃR�s�[����
        /// </summary>
        /// <param name="source">�R�s�[�����㖾�׃f�[�^�I�u�W�F�N�g</param>
        /// <param name="target">�R�s�[�攄�㖾�׃f�[�^�I�u�W�F�N�g</param>
        private static void CopyItemProc(SalesDetail source, ref SalesDetail target)
        {
            target.CreateDateTime = source.CreateDateTime; // �쐬����
            target.UpdateDateTime = source.UpdateDateTime; // �X�V����
            target.EnterpriseCode = source.EnterpriseCode; // ��ƃR�[�h
            target.FileHeaderGuid = source.FileHeaderGuid; // GUID
            target.UpdEmployeeCode = source.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            target.UpdAssemblyId1 = source.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            target.UpdAssemblyId2 = source.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            target.LogicalDeleteCode = source.LogicalDeleteCode; // �_���폜�敪
            target.AcceptAnOrderNo = source.AcceptAnOrderNo; // �󒍔ԍ�
            target.AcptAnOdrStatus = source.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            target.SalesSlipNum = source.SalesSlipNum; // ����`�[�ԍ�
            target.SalesRowNo = source.SalesRowNo; // ����s�ԍ�
            target.SalesRowDerivNo = source.SalesRowDerivNo; // ����s�ԍ��}��
            target.SectionCode = source.SectionCode; // ���_�R�[�h
            target.SubSectionCode = source.SubSectionCode; // ����R�[�h
            target.SalesDate = source.SalesDate; // ������t
            target.CommonSeqNo = source.CommonSeqNo; // ���ʒʔ�
            target.SalesSlipDtlNum = source.SalesSlipDtlNum; // ���㖾�גʔ�
            target.AcptAnOdrStatusSrc = source.AcptAnOdrStatusSrc; // �󒍃X�e�[�^�X�i���j
            target.SalesSlipDtlNumSrc = source.SalesSlipDtlNumSrc; // ���㖾�גʔԁi���j
            target.SupplierFormalSync = source.SupplierFormalSync; // �d���`���i�����j
            target.StockSlipDtlNumSync = source.StockSlipDtlNumSync; // �d�����גʔԁi�����j
            target.SalesSlipCdDtl = source.SalesSlipCdDtl; // ����`�[�敪�i���ׁj
            target.DeliGdsCmpltDueDate = source.DeliGdsCmpltDueDate; // �[�i�����\���
            target.GoodsKindCode = source.GoodsKindCode; // ���i����
            target.GoodsSearchDivCd = source.GoodsSearchDivCd; // ���i�����敪
            target.GoodsMakerCd = source.GoodsMakerCd; // ���i���[�J�[�R�[�h
            target.MakerName = source.MakerName; // ���[�J�[����
            target.MakerKanaName = source.MakerKanaName; // ���[�J�[�J�i����
            target.CmpltMakerKanaName = source.CmpltMakerKanaName; // ���[�J�[�J�i���́i�ꎮ�j
            target.GoodsNo = source.GoodsNo; // ���i�ԍ�
            target.GoodsName = source.GoodsName; // ���i����
            target.GoodsNameKana = source.GoodsNameKana; // ���i���̃J�i
            target.GoodsLGroup = source.GoodsLGroup; // ���i�啪�ރR�[�h
            target.GoodsLGroupName = source.GoodsLGroupName; // ���i�啪�ޖ���
            target.GoodsMGroup = source.GoodsMGroup; // ���i�����ރR�[�h
            target.GoodsMGroupName = source.GoodsMGroupName; // ���i�����ޖ���
            target.BLGroupCode = source.BLGroupCode; // BL�O���[�v�R�[�h
            target.BLGroupName = source.BLGroupName; // BL�O���[�v�R�[�h����
            target.BLGoodsCode = source.BLGoodsCode; // BL���i�R�[�h
            target.BLGoodsFullName = source.BLGoodsFullName; // BL���i�R�[�h���́i�S�p�j
            target.EnterpriseGanreCode = source.EnterpriseGanreCode; // ���Е��ރR�[�h
            target.EnterpriseGanreName = source.EnterpriseGanreName; // ���Е��ޖ���
            target.WarehouseCode = source.WarehouseCode; // �q�ɃR�[�h
            target.WarehouseName = source.WarehouseName; // �q�ɖ���
            target.WarehouseShelfNo = source.WarehouseShelfNo; // �q�ɒI��
            target.SalesOrderDivCd = source.SalesOrderDivCd; // ����݌Ɏ�񂹋敪
            target.OpenPriceDiv = source.OpenPriceDiv; // �I�[�v�����i�敪
            target.GoodsRateRank = source.GoodsRateRank; // ���i�|�������N
            target.CustRateGrpCode = source.CustRateGrpCode; // ���Ӑ�|���O���[�v�R�[�h
            target.ListPriceRate = source.ListPriceRate; // �艿��
            target.RateSectPriceUnPrc = source.RateSectPriceUnPrc; // �|���ݒ苒�_�i�艿�j
            target.RateDivLPrice = source.RateDivLPrice; // �|���ݒ�敪�i�艿�j
            target.PriceSelectDiv = source.PriceSelectDiv; // �W�����i�I���敪�i�艿�j// ADD 2013/01/24 ���N�n�� REDMINE#34605
            target.UnPrcCalcCdLPrice = source.UnPrcCalcCdLPrice; // �P���Z�o�敪�i�艿�j
            target.PriceCdLPrice = source.PriceCdLPrice; // ���i�敪�i�艿�j
            target.StdUnPrcLPrice = source.StdUnPrcLPrice; // ��P���i�艿�j
            target.FracProcUnitLPrice = source.FracProcUnitLPrice; // �[�������P�ʁi�艿�j
            target.FracProcLPrice = source.FracProcLPrice; // �[�������i�艿�j
            target.ListPriceTaxIncFl = source.ListPriceTaxIncFl; // �艿�i�ō��C�����j
            target.ListPriceTaxExcFl = source.ListPriceTaxExcFl; // �艿�i�Ŕ��C�����j
            target.ListPriceChngCd = source.ListPriceChngCd; // �艿�ύX�敪
            target.SalesRate = source.SalesRate; // ������
            target.RateSectSalUnPrc = source.RateSectSalUnPrc; // �|���ݒ苒�_�i����P���j
            target.RateDivSalUnPrc = source.RateDivSalUnPrc; // �|���ݒ�敪�i����P���j
            target.UnPrcCalcCdSalUnPrc = source.UnPrcCalcCdSalUnPrc; // �P���Z�o�敪�i����P���j
            target.PriceCdSalUnPrc = source.PriceCdSalUnPrc; // ���i�敪�i����P���j
            target.StdUnPrcSalUnPrc = source.StdUnPrcSalUnPrc; // ��P���i����P���j
            target.FracProcUnitSalUnPrc = source.FracProcUnitSalUnPrc; // �[�������P�ʁi����P���j
            target.FracProcSalUnPrc = source.FracProcSalUnPrc; // �[�������i����P���j
            target.SalesUnPrcTaxIncFl = source.SalesUnPrcTaxIncFl; // ����P���i�ō��C�����j
            target.SalesUnPrcTaxExcFl = source.SalesUnPrcTaxExcFl; // ����P���i�Ŕ��C�����j
            target.SalesUnPrcChngCd = source.SalesUnPrcChngCd; // ����P���ύX�敪
            target.CostRate = source.CostRate; // ������
            target.RateSectCstUnPrc = source.RateSectCstUnPrc; // �|���ݒ苒�_�i�����P���j
            target.RateDivUnCst = source.RateDivUnCst; // �|���ݒ�敪�i�����P���j
            target.UnPrcCalcCdUnCst = source.UnPrcCalcCdUnCst; // �P���Z�o�敪�i�����P���j
            target.PriceCdUnCst = source.PriceCdUnCst; // ���i�敪�i�����P���j
            target.StdUnPrcUnCst = source.StdUnPrcUnCst; // ��P���i�����P���j
            target.FracProcUnitUnCst = source.FracProcUnitUnCst; // �[�������P�ʁi�����P���j
            target.FracProcUnCst = source.FracProcUnCst; // �[�������i�����P���j
            target.SalesUnitCost = source.SalesUnitCost; // �����P��
            target.SalesUnitCostChngDiv = source.SalesUnitCostChngDiv; // �����P���ύX�敪
            target.RateBLGoodsCode = source.RateBLGoodsCode; // BL���i�R�[�h�i�|���j
            target.RateBLGoodsName = source.RateBLGoodsName; // BL���i�R�[�h���́i�|���j
            target.RateGoodsRateGrpCd = source.RateGoodsRateGrpCd; // ���i�|���O���[�v�R�[�h�i�|���j
            target.RateGoodsRateGrpNm = source.RateGoodsRateGrpNm; // ���i�|���O���[�v���́i�|���j
            target.RateBLGroupCode = source.RateBLGroupCode; // BL�O���[�v�R�[�h�i�|���j
            target.RateBLGroupName = source.RateBLGroupName; // BL�O���[�v���́i�|���j
            target.PrtBLGoodsCode = source.PrtBLGoodsCode; // BL���i�R�[�h�i����j
            target.PrtBLGoodsName = source.PrtBLGoodsName; // BL���i�R�[�h���́i����j
            target.SalesCode = source.SalesCode; // �̔��敪�R�[�h
            target.SalesCdNm = source.SalesCdNm; // �̔��敪����
            target.WorkManHour = source.WorkManHour; // ��ƍH��
            target.ShipmentCnt = source.ShipmentCnt; // �o�א�
            target.AcceptAnOrderCnt = source.AcceptAnOrderCnt; // �󒍐���
            target.AcptAnOdrAdjustCnt = source.AcptAnOdrAdjustCnt; // �󒍒�����
            target.AcptAnOdrRemainCnt = source.AcptAnOdrRemainCnt; // �󒍎c��
            target.RemainCntUpdDate = source.RemainCntUpdDate; // �c���X�V��
            target.SalesMoneyTaxInc = source.SalesMoneyTaxInc; // ������z�i�ō��݁j
            target.SalesMoneyTaxExc = source.SalesMoneyTaxExc; // ������z�i�Ŕ����j
            target.Cost = source.Cost; // ����
            target.GrsProfitChkDiv = source.GrsProfitChkDiv; // �e���`�F�b�N�敪
            target.SalesGoodsCd = source.SalesGoodsCd; // ���㏤�i�敪
            target.SalesPriceConsTax = source.SalesPriceConsTax; // ������z����Ŋz
            target.TaxationDivCd = source.TaxationDivCd; // �ېŋ敪
            target.PartySlipNumDtl = source.PartySlipNumDtl; // �����`�[�ԍ��i���ׁj
            target.DtlNote = source.DtlNote; // ���ה��l
            target.SupplierCd = source.SupplierCd; // �d����R�[�h
            target.SupplierSnm = source.SupplierSnm; // �d���旪��
            target.OrderNumber = source.OrderNumber; // �����ԍ�
            target.WayToOrder = source.WayToOrder; // �������@
            target.SlipMemo1 = source.SlipMemo1; // �`�[�����P
            target.SlipMemo2 = source.SlipMemo2; // �`�[�����Q
            target.SlipMemo3 = source.SlipMemo3; // �`�[�����R
            target.InsideMemo1 = source.InsideMemo1; // �Г������P
            target.InsideMemo2 = source.InsideMemo2; // �Г������Q
            target.InsideMemo3 = source.InsideMemo3; // �Г������R
            target.BfListPrice = source.BfListPrice; // �ύX�O�艿
            target.BfSalesUnitPrice = source.BfSalesUnitPrice; // �ύX�O����
            target.BfUnitCost = source.BfUnitCost; // �ύX�O����
            target.CmpltSalesRowNo = source.CmpltSalesRowNo; // �ꎮ���הԍ�
            target.CmpltGoodsMakerCd = source.CmpltGoodsMakerCd; // ���[�J�[�R�[�h�i�ꎮ�j
            target.CmpltMakerName = source.CmpltMakerName; // ���[�J�[���́i�ꎮ�j
            target.CmpltGoodsName = source.CmpltGoodsName; // ���i���́i�ꎮ�j
            target.CmpltShipmentCnt = source.CmpltShipmentCnt; // ���ʁi�ꎮ�j
            target.CmpltSalesUnPrcFl = source.CmpltSalesUnPrcFl; // ����P���i�ꎮ�j
            target.CmpltSalesMoney = source.CmpltSalesMoney; // ������z�i�ꎮ�j
            target.CmpltSalesUnitCost = source.CmpltSalesUnitCost; // �����P���i�ꎮ�j
            target.CmpltCost = source.CmpltCost; // �������z�i�ꎮ�j
            target.CmpltPartySalSlNum = source.CmpltPartySalSlNum; // �����`�[�ԍ��i�ꎮ�j
            target.CmpltNote = source.CmpltNote; // �ꎮ���l
            // --- ADD 2009/10/19 ---------->>>>>
            target.SelectedGoodsNoDiv = source.SelectedGoodsNoDiv; // ����p�i�ԗL���敪
            // --- ADD 2009/10/19 ----------<<<<<
            target.PrtGoodsNo = source.PrtGoodsNo; // ����p�i��
            target.PrtMakerCode = source.PrtMakerCode; // ����p���[�J�R�[�h
            target.PrtMakerName = source.PrtMakerName; // ����p���[�J�[����
            target.DtlRelationGuid = source.DtlRelationGuid; // ���ʃL�[
            target.CarRelationGuid = source.CarRelationGuid; // �ԗ���񋤒ʃL�[
            //>>>2010/02/26
            target.CampaignCode = source.CampaignCode;
            target.CampaignName = source.CampaignName;
            target.GoodsDivCd = source.GoodsDivCd;
            target.AnswerDelivDate = source.AnswerDelivDate;
            target.RecycleDiv = source.RecycleDiv;
            target.RecycleDivNm = source.RecycleDivNm;
            target.WayToAcptOdr = source.WayToAcptOdr;
            target.DtlRelationGuid = source.DtlRelationGuid; // ���ʃL�[
            target.DtlRelationGuid = source.DtlRelationGuid; // ���ʃL�[
            //<<<2010/02/26
            // 2012/01/16 Add >>>
            target.GoodsSpecialNote = source.GoodsSpecialNote; // ���L����
            // 2012/01/16 Add <<<
            //>>>2012/05/02
            target.RentSyncStockDate = source.RentSyncStockDate;
            target.RentSyncSupplier = source.RentSyncSupplier;
            target.RentSyncSupSlipNo = source.RentSyncSupSlipNo;
            //<<<2012/05/02
        }
        #endregion
    }

    /// <summary>
    /// CustomSerializeArrayList�����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : CustomSerializeArrayList�̕����������s���܂��B</br>
    /// <br>Programmer : 20056 ���n�@���</br>
    /// <br>Date       : 2008.09.24</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.09.24 ���n�@���  �V�K�쐬</br>
    /// </remarks>
    public class DivisionSalesSlipCustomSerializeArrayList
    {
        #region ��Public Static Methods
        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�����p�j
        /// </summary>
        /// <param name="paraList">�f�[�^�������X�g</param>
        /// <param name="salesDataList">����f�[�^���X�g</param>
        /// <param name="acptDataList">�󒍃f�[�^���X�g</param>
        /// <param name="stockSlipInfoList">�d���f�[�^���X�g</param>
        public static void DivisionCustomSerializeArrayListForWriting(CustomSerializeArrayList paraList, out ArrayList salesDataList, out ArrayList acptDataList, out ArrayList stockSlipInfoList)
        {
            ArrayList uoeOrderDataList;
            DivisionCustomSerializeArrayListForWritingProc(paraList, out salesDataList, out acptDataList, out stockSlipInfoList, out uoeOrderDataList);
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�����p�j
        /// </summary>
        /// <param name="paraList">�f�[�^�������X�g</param>
        /// <param name="salesDataList">����f�[�^���X�g</param>
        /// <param name="acptDataList">�󒍃f�[�^���X�g</param>
        /// <param name="stockSlipInfoList">�d���f�[�^���X�g</param>
        /// <param name="uoeOrderDataList">UOE�����f�[�^���X�g</param>
        public static void DivisionCustomSerializeArrayListForWriting(CustomSerializeArrayList paraList, out ArrayList salesDataList, out ArrayList acptDataList, out ArrayList stockSlipInfoList, out ArrayList uoeOrderDataList)
        {
            DivisionCustomSerializeArrayListForWritingProc(paraList, out salesDataList, out acptDataList, out stockSlipInfoList, out uoeOrderDataList);
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�����p�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        public static void DivisionCustomSerializeArrayListForWriting(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray)
        {
            DivisionCustomSerializeArrayListForWritingProc(paraList, out salesSlipWork, out salesDetailWorkArray, out stockWorkArray, out acceptOdrCarWorkArray);
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�����p�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUppOrgSalesDetailWorkArray">�v�㌳���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="depsitDataWork">�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="depositAlwWork">���������f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>        
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        public static void DivisionCustomSerializeArrayListForWriting(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray)
        {
            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayList(paraList, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockWorkArray, out acceptOdrCarWorkArray);
        }

        //>>>2010/02/26
        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�����p�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUppOrgSalesDetailWorkArray">�v�㌳���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="depsitDataWork">�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="depositAlwWork">���������f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>        
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        public static void DivisionCustomSerializeArrayListForWriting(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out SCMAcOdrDataWork scmAcOdrDataWork, out SCMAcOdrDtlIqWork[] scmAcOdrDataWorkArray, out SCMAcOdrDtlAsWork[] scmAcOdrDtlAsWorkArray, out SCMAcOdrDtCarWork scmAcOdrDtCarWork)
        {
            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayList(paraList, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockWorkArray, out acceptOdrCarWorkArray, out scmAcOdrDataWork, out scmAcOdrDataWorkArray, out scmAcOdrDtlAsWorkArray, out scmAcOdrDtCarWork);
        }
        //<<<2010/02/26

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�Ǎ��p�j
        /// </summary>
        /// <param name="paraList1">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g(�e�f�[�^)</param>
        /// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        public static void DivisionCustomSerializeArrayListForReading(CustomSerializeArrayList paraList1, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray)
        {
            AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray;
            DepsitDataWork depsitDataWork;
            DepositAlwWork depositAlwWork;
            List<StockSlipWork> stockSlipWorkList;
            List<StockDetailWork> stockDetailWrokList;
            List<AddUpOrgStockDetailWork> addUpOrgStockDetailWorkList;

            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForReading(paraList1, null, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockSlipWorkList, out stockDetailWrokList, out addUpOrgStockDetailWorkList, out stockWorkArray, out acceptOdrCarWorkArray);
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�Ǎ��p�j
        /// </summary>
        /// <param name="paraList1">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g(�e�f�[�^)</param>
        /// <param name="paraList2">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g(�v�㌳�^�������̓f�[�^)</param>
        /// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUppOrgSalesDetailWorkArray">�v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="depsitDataWork">�����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="depositAlwWork">���������f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockSlipWorkList">�������̓f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="stockDetailWrokList">�������͖��׃f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="addUpOrgStockDetailWorkList">�������͌v�㌳�d�����׃f�[�^���[�N���X�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>        
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        public static void DivisionCustomSerializeArrayListForReading(CustomSerializeArrayList paraList1, CustomSerializeArrayList paraList2, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWrokList, out List<AddUpOrgStockDetailWork> addUpOrgStockDetailWorkList, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray)
        {
            UOEOrderDtlWork[] uoeOrderDtlWorkArray;
            //>>>2010/02/26
            UserSCMOrderHeaderRecord scmHeader;
            UserSCMOrderCarRecord scmCar;
            UserSCMOrderDetailRecord[] scmDetailList;
            UserSCMOrderAnswerRecord[] scmAnswerList;
            //<<<2010/02/26

            //>>>2010/02/26
            //DivisionCustomSerializeArrayListForReadingProc(paraList1, paraList2, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockSlipWorkList, out stockDetailWrokList, out addUpOrgStockDetailWorkList, out stockWorkArray, out acceptOdrCarWorkArray, out uoeOrderDtlWorkArray);
            DivisionCustomSerializeArrayListForReadingProc(paraList1, paraList2, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockSlipWorkList, out stockDetailWrokList, out addUpOrgStockDetailWorkList, out stockWorkArray, out acceptOdrCarWorkArray, out uoeOrderDtlWorkArray, out scmHeader, out scmCar, out scmDetailList, out scmAnswerList);
            //<<<2010/02/26
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�Ǎ��p�j
        /// </summary>
        /// <param name="paraList1">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g(�e�f�[�^)</param>
        /// <param name="paraList2">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g(�v�㌳�^�������̓f�[�^)</param>
        /// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUppOrgSalesDetailWorkArray">�v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="depsitDataWork">�����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="depositAlwWork">���������f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockSlipWorkList">�������̓f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="stockDetailWrokList">�������͖��׃f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="addUpOrgStockDetailWorkList">�������͌v�㌳�d�����׃f�[�^���[�N���X�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>        
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="uoeOrderDtlWorkArray">UOE�����f�[�^�I�u�W�F�N�g�z��</param>
        //>>>2010/02/26
        //public static void DivisionCustomSerializeArrayListForReading(CustomSerializeArrayList paraList1, CustomSerializeArrayList paraList2, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWrokList, out List<AddUpOrgStockDetailWork> addUpOrgStockDetailWorkList, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray)
        public static void DivisionCustomSerializeArrayListForReading(CustomSerializeArrayList paraList1, CustomSerializeArrayList paraList2, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWrokList, out List<AddUpOrgStockDetailWork> addUpOrgStockDetailWorkList, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray, out UserSCMOrderHeaderRecord scmHeader, out UserSCMOrderCarRecord scmCar, out UserSCMOrderDetailRecord[] scmDetailList, out UserSCMOrderAnswerRecord[] scmAnswerList)
        //<<<2010/02/26
        {
            //>>>2010/02/26
            //DivisionCustomSerializeArrayListForReadingProc(paraList1, paraList2, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockSlipWorkList, out stockDetailWrokList, out addUpOrgStockDetailWorkList, out stockWorkArray, out acceptOdrCarWorkArray, out uoeOrderDtlWorkArray);
            DivisionCustomSerializeArrayListForReadingProc(paraList1, paraList2, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockSlipWorkList, out stockDetailWrokList, out addUpOrgStockDetailWorkList, out stockWorkArray, out acceptOdrCarWorkArray, out uoeOrderDtlWorkArray, out scmHeader, out scmCar, out scmDetailList, out scmAnswerList);
            //<<<2010/02/26
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i���דǍ��p�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="paraList2">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="stockSlipWorkArray">�d���f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="stockDetailWorkArray">�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        public static void DivisionCustomSerializeArrayListForDetailsReading(CustomSerializeArrayList paraList, CustomSerializeArrayList paraList2, out SalesDetailWork[] salesDetailWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out StockSlipWork[] stockSlipWorkArray, out StockDetailWork[] stockDetailWorkArray)
        {
            UOEOrderDtlWork[] uoeOrderDtlWorkArray;
            DivisionCustomSerializeArrayListForDetailsReadingProc(paraList, paraList2, out salesDetailWorkArray, out acceptOdrCarWorkArray, out stockSlipWorkArray, out stockDetailWorkArray, out uoeOrderDtlWorkArray);
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i���דǍ��p�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="paraList2">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="stockSlipWorkArray">�d���f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="stockDetailWorkArray">�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="uoeOrderDtlWorkArray">UOE�����f�[�^���[�N�I�u�W�F�N�g�z��</param>
        public static void DivisionCustomSerializeArrayListForDetailsReading(CustomSerializeArrayList paraList, CustomSerializeArrayList paraList2, out SalesDetailWork[] salesDetailWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out StockSlipWork[] stockSlipWorkArray, out StockDetailWork[] stockDetailWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray)
        {
            DivisionCustomSerializeArrayListForDetailsReadingProc(paraList, paraList2, out salesDetailWorkArray, out acceptOdrCarWorkArray, out stockSlipWorkArray, out stockDetailWorkArray, out uoeOrderDtlWorkArray);
        }
        #endregion

        #region ��Private Static Methods
        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�iWrite���p�j
        /// </summary>
        /// <param name="paraList">�f�[�^�������X�g</param>
        /// <param name="salesDataList">����f�[�^���X�g</param>
        /// <param name="acptDataList">�󒍃f�[�^���X�g</param>
        /// <param name="stockSlipInfoList">�d���f�[�^���X�g</param>
        /// <param name="uoeOrderDataList">UOE�����f�[�^���X�g</param>
        private static void DivisionCustomSerializeArrayListForWritingProc(CustomSerializeArrayList paraList, out ArrayList salesDataList, out ArrayList acptDataList, out ArrayList stockSlipInfoList, out ArrayList uoeOrderDataList)
        {
            //------------------------------------------------------------------------------------
            // ParaList�\��
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            �������X�g
            //      --CustomSerializeArrayList      ���ナ�X�g
            //          --SalesSlipWork             ����f�[�^�I�u�W�F�N�g
            //          --ArrayList                 ���㖾�׃��X�g
            //              --SalesDetailWork       ���㖾�׃f�[�^�I�u�W�F�N�g
            //          --DepsitMainWork            �����f�[�^�I�u�W�F�N�g
            //          --DepositAlwWork            ���������f�[�^�I�u�W�F�N�g
            //      --CustomSerializeArrayList      �󒍃��X�g
            //          --SalesSlipWork             �󒍃f�[�^�I�u�W�F�N�g
            //          --ArrayList                 �󒍖��׃��X�g
            //              --SalesDetailWork       �󒍖��׃f�[�^�I�u�W�F�N�g
            //      --CustomSerializeArrayList      �d�����X�g
            //          --StockSlipWork             �d���f�[�^�I�u�W�F�N�g
            //          --ArrayList                 �d�����׃��X�g
            //              --StockDetailWork       �d�����׃f�[�^�I�u�W�F�N�g
            //          --PaymentSlpWork            �x���f�[�^�I�u�W�F�N�g
            //      --CustomSerializeArrayList      ���׃��X�g
            //          --StockSlipWork             ���׃f�[�^�I�u�W�F�N�g
            //          --ArrayList                 ���ז��׃��X�g
            //              --StockDetailWork       ���ז��׃f�[�^�I�u�W�F�N�g
            //          --PaymentSlpWork            �x���f�[�^�I�u�W�F�N�g
            //      --CustomSerializeArrayList      �������X�g
            //          --StockSlipWork             �����f�[�^�I�u�W�F�N�g(�������[�g�Q�Ɨp�B���f�[�^�͍쐬����܂���B)
            //          --ArrayList                 �������׃��X�g
            //              --StockDetailWork       �������׃f�[�^�I�u�W�F�N�g
            //------------------------------------------------------------------------------------

            salesDataList = new ArrayList();
            acptDataList = new ArrayList();
            stockSlipInfoList = new ArrayList();
            uoeOrderDataList = new ArrayList();

            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is CustomSerializeArrayList)
                {
                    CustomSerializeArrayList tempList = (CustomSerializeArrayList)paraList[i];
                    foreach (object tempObj in tempList)
                    {
                        //---------------------------------------
                        // ������
                        //---------------------------------------
                        if (tempObj is SalesSlipWork)
                        {
                            SalesSlipWork tempWork = (SalesSlipWork)tempObj;
                            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)tempWork.AcptAnOdrStatus)
                            {
                                case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate:
                                case SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate:
                                    salesDataList.Add(tempList);
                                    break;
                                case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder:
                                    acptDataList.Add(tempList);
                                    break;
                                case SalesSlipInputAcs.AcptAnOdrStatusState.Sales:
                                case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment:
                                    salesDataList.Add(tempList);
                                    break;
                            }
                        }
                        //---------------------------------------
                        // �d�����
                        //---------------------------------------
                        else if (tempObj is StockSlipWork)
                        {
                            stockSlipInfoList.Add(tempList);
                        }
                        //---------------------------------------
                        // �������
                        //---------------------------------------
                        else if (tempObj is CustomSerializeArrayList)
                        {
                            CustomSerializeArrayList tempCSList = (CustomSerializeArrayList)tempObj;
                            if ((tempCSList.Count != 0) && (tempCSList[0] is UOEOrderDtlWork))
                            {
                                uoeOrderDataList.Add(tempList);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�iWrite���p�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayListForWritingProc(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray)
        {
            AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray;
            DepsitDataWork depsitDataWork;
            DepositAlwWork depositAlwWork;

            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayList(paraList, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockWorkArray, out acceptOdrCarWorkArray);
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�iRead���p�j
        /// </summary>
        /// <param name="paraList1">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g(�e�f�[�^)</param>
        /// <param name="paraList2">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g(�v�㌳�^�������̓f�[�^)</param>
        /// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUppOrgSalesDetailWorkArray">�v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="depsitDataWork">�����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="depositAlwWork">���������f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockSlipWorkList">�������̓f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="stockDetailWrokList">�������͖��׃f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="addUpOrgStockDetailWorkList">�������͌v�㌳�d�����׃f�[�^���[�N���X�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>        
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="uoeOrderDtlWorkArray">UOE�����f�[�^�I�u�W�F�N�g�z��</param>
        //>>>2010/02/26
        //private static void DivisionCustomSerializeArrayListForReadingProc(CustomSerializeArrayList paraList1, CustomSerializeArrayList paraList2, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWrokList, out List<AddUpOrgStockDetailWork> addUpOrgStockDetailWorkList, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray)
        private static void DivisionCustomSerializeArrayListForReadingProc(CustomSerializeArrayList paraList1, CustomSerializeArrayList paraList2, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWrokList, out List<AddUpOrgStockDetailWork> addUpOrgStockDetailWorkList, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray, out UserSCMOrderHeaderRecord scmHeader, out UserSCMOrderCarRecord scmCar, out UserSCMOrderDetailRecord[] scmDetailList, out UserSCMOrderAnswerRecord[] scmAnswerList)
        //<<<2010/02/26
        {
            //-----------------------------------------------------------------------------------------------------------------------
            // ParaList�\��
            //-----------------------------------------------------------------------------------------------------------------------
            //  CustomSerializeArrayList                �����񃊃X�g(��P�p�����[�^ ParaList1)
            //    --SalesSlipWork                       ����f�[�^                              ���e�f�[�^
            //    --ArrayList                           ���㖾�׃��X�g
            //        --SalesDetailWork                 ���㖾�׃f�[�^                          ���e�f�[�^
            //    --ArrayList                           �v�㌳���׃��X�g
            //        --AddUppOrgSalesDetailWork        �v�㌳���׃f�[�^                        ���Q�Ƃ̂�(�c���`�F�b�N)
            //    --DepsitDataWork                      �����f�[�^                              ���e�f�[�^�����C���\
            //    --DepositAlwWork                      ���������f�[�^                          ���e�f�[�^�����C���\
            //    --ArrayList                           �݌Ƀ��[�N���X�g                        
            //        --StockWork                       �݌Ƀ��[�N�f�[�^                        ���Q�Ƃ̂�(���݌ɐ��Z�b�g)
            //    --ArrayList                           �󒍃}�X�^�i�ԗ��j���X�g
            //        --AcceptOdrCar                    �󒍃}�X�^�i�ԗ��j
            //-----------------------------------------------------------------------------------------------------------------------
            //  CustomSerializeArrayList                �v�㌳�^�������̓��X�g(��Q�p�����[�^ ParaList2)
            //    --CustomSerializeArrayList            �v�㌳��񃊃X�g(�o�ׁA�󒍁A����)
            //      --SalesSlipWork                     �v�㌳�f�[�^                            ���e�f�[�^�����C����(���ς̂�)
            //      --ArrayList                         �v�㌳���׃��X�g
            //          --SalesDetailWork               �v�㌳���׃f�[�^                        ���e�f�[�^�����C����(���ς̂�)
            //      --ArrayList                         �v�㌳�����׃��X�g
            //          --AddUppOrgSalesDetailWork      �v�㌳�����׃f�[�^                      �����g�p(���ώ��͖��Z�b�g�ƂȂ��)
            //      --DepsitMainWork                    �v�㌳�����f�[�^                        �����g�p(���ώ��͖��Z�b�g�ƂȂ��)
            //      --DepositAlwWork                    �v�㌳���������f�[�^                    �����g�p(���ώ��͖��Z�b�g�ƂȂ��)
            //      --ArrayList                         �v�㌳�݌Ƀ��[�N���X�g                        
            //          --StockWork                     �v�㌳�݌Ƀ��[�N�f�[�^                  �����g�p
            //------------------------------------------
            //    --CustomSerializeArrayList            �������̓��X�g(�d���A�o�ׁA����)
            //      --StockSlipWork                     �������̓f�[�^                          ���e�f�[�^�����C����(�󔭒��̂�)
            //      --ArrayList                         �������͖��׃��X�g
            //          --StockDetailWork               �������͖��׃f�[�^                      ���e�f�[�^�����C����(�󔭒��̂�)
            //      --ArrayList                         �������͌v�㌳���׃��X�g
            //          --AddUpOrgStockDetailWork       �������͌v�㌳���׃f�[�^                �����g�p(�������͖��Z�b�g�ƂȂ��)
            //      --PaymentSlpWork                    �������͎x���f�[�^                      ���e�f�[�^�����폜��
            //      --ArrayList                         �������͍݌Ƀ��[�N���X�g                        
            //          --StockWork                     �������͍݌Ƀ��[�N�f�[�^                �����g�p
            //------------------------------------------
            //    --CustomSerializeArrayList            �������͌v�㌳���X�g(�o�ׁA����)
            //      --StockSlipWork                     �������͌v�㌳�f�[�^                    �����g�p
            //      --ArrayList                         �������͌v�㌳���׃��X�g
            //          --StockDetailWork               �������͌v�㌳���׃f�[�^                �����g�p
            //      --ArrayList                         �������͌v�㌳�����׃��X�g
            //          --AddUpOrgStockDetailWork       �������͌v�㌳�����׃f�[�^              �����g�p
            //      --PaymentSlpWork                    �������͌v�㌳�x���f�[�^                �����g�p
            //      --ArrayList                         �������͌v�㌳�݌Ƀ��[�N���X�g                        
            //          --StockWork                     �������͌v�㌳�݌Ƀ��[�N�f�[�^          �����g�p
            //-----------------------------------------------------------------------------------------------------------------------

            salesSlipWork = null;                                                   // ����f�[�^���[�N�I�u�W�F�N�g
            salesDetailWorkArray = null;                                            // ���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��
            addUpOrgSalesDetailWorkArray = null;                                    // �v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��
            depsitDataWork = null;                                                  // �����f�[�^���[�N�I�u�W�F�N�g
            depositAlwWork = null;                                                  // ���������f�[�^���[�N�I�u�W�F�N�g
            stockWorkArray = null;                                                  // �݌Ƀ��[�N�I�u�W�F�N�g�z��
            stockSlipWorkList = new List<StockSlipWork>();                          // �������̓f�[�^���[�N�I�u�W�F�N�g���X�g
            stockDetailWrokList = new List<StockDetailWork>();                      // �������͖��׃f�[�^���[�N�I�u�W�F�N�g���X�g
            addUpOrgStockDetailWorkList = new List<AddUpOrgStockDetailWork>();      // �������͌v�㌳�d�����׃f�[�^���[�N�I�u�W�F�N�g���X�g
            acceptOdrCarWorkArray = null;                                           // �󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��
            uoeOrderDtlWorkArray = null;                                            // UOE�����f�[�^���[�N�I�u�W�F�N�g�z��
            //>>>2010/02/26
            scmHeader = new UserSCMOrderHeaderRecord();                             // SCM�󒍃f�[�^���[�N�I�u�W�F�N�g
            scmCar = new UserSCMOrderCarRecord();                                   // SCM�󒍃f�[�^(�ԗ����)���[�N�I�u�W�F�N�g
            scmDetailList = null;                                                   // SCM�󒍖��׃f�[�^(�⍇���E����)���[�N�I�u�W�F�N�g�z��
            scmAnswerList = null;                                                   // SCM�󒍖��׃f�[�^(��)���[�N�I�u�W�F�N�g�z��
            //<<<2010/02/26

            SalesSlipWork tempSalesSlipWork = null;                                 // ����f�[�^���[�N�I�u�W�F�N�g
            SalesDetailWork[] tempSalesDetailWorkArray = null;                      // ���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��
            AddUpOrgSalesDetailWork[] tempAddUpOrgSalesDetailWorkArray = null;      // �v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��
            DepsitDataWork tempDepsitDataWork = null;                               // �����f�[�^���[�N�I�u�W�F�N�g
            DepositAlwWork tempDepositAlwWork = null;                               // ���������f�[�^���[�N�I�u�W�F�N�g
            StockWork[] tempStockWorkArray = null;                                  // �݌Ƀ��[�N�I�u�W�F�N�g�z��
            StockSlipWork tempStockSlipWork = null;                                 // �������̓f�[�^���[�N�I�u�W�F�N�g
            StockDetailWork[] tempStockDetailWorkArray = null;                      // �������͖��׃f�[�^���[�N�I�u�W�F�N�g�z��
            AddUpOrgStockDetailWork[] tempAddUpOrgStockDetailWorkArray = null;      // �������͌v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��
            AcceptOdrCarWork[] tempAcceptOdrCarWorkArray = null;                    // �󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��
            UOEOrderDtlWork[] tempUOEOrderDtlWorkArray = null;                      // UOE�����f�[�^���[�N�I�u�W�F�N�g�z��
            //>>>2010/02/26
            UserSCMOrderHeaderRecord tempSCMHeader;                                 // SCM�󒍃f�[�^���[�N�I�u�W�F�N�g
            UserSCMOrderCarRecord tempSCMCar;                                       // SCM�󒍃f�[�^(�ԗ����)���[�N�I�u�W�F�N�g
            UserSCMOrderDetailRecord[] tempSCMDetailArray;                          // SCM�󒍖��׃f�[�^(�⍇���E����)���[�N�I�u�W�F�N�g�z��
            UserSCMOrderAnswerRecord[] tempSCMAnswerArray;                          // SCM�󒍖��׃f�[�^(��)���[�N�I�u�W�F�N�g�z��
            //<<<2010/02/26

            //---------------------------------------------------
            // �e�f�[�^�����i�����񃊃X�g�j
            //---------------------------------------------------
            //>>>2010/02/26
            //DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayList(paraList1, out tempSalesSlipWork, out tempSalesDetailWorkArray, out tempAddUpOrgSalesDetailWorkArray, out tempDepsitDataWork, out tempDepositAlwWork, out tempStockWorkArray, out tempAcceptOdrCarWorkArray);
            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayList(paraList1, out tempSalesSlipWork, out tempSalesDetailWorkArray, out tempAddUpOrgSalesDetailWorkArray, out tempDepsitDataWork, out tempDepositAlwWork, out tempStockWorkArray, out tempAcceptOdrCarWorkArray, out tempSCMHeader, out tempSCMCar, out tempSCMDetailArray, out tempSCMAnswerArray);
            //<<<2010/02/26
            salesSlipWork = tempSalesSlipWork;
            salesDetailWorkArray = tempSalesDetailWorkArray;
            addUpOrgSalesDetailWorkArray = tempAddUpOrgSalesDetailWorkArray;
            depsitDataWork = tempDepsitDataWork;
            depositAlwWork = tempDepositAlwWork;
            stockWorkArray = tempStockWorkArray;
            acceptOdrCarWorkArray = tempAcceptOdrCarWorkArray;
            //>>>2010/02/26
            scmHeader = tempSCMHeader;
            scmCar = tempSCMCar;
            scmDetailList = tempSCMDetailArray;
            scmAnswerList = tempSCMAnswerArray;
            //<<<2010/02/26

            //---------------------------------------------------
            // �v�㌳�^�������̓��X�g����
            //---------------------------------------------------
            if (paraList2 != null)
            {
                for (int i = 0; i < paraList2.Count; i++)
                {
                    if (paraList2[i] is CustomSerializeArrayList)
                    {

                        CustomSerializeArrayList tempList = (CustomSerializeArrayList)paraList2[i];
                        foreach (object tempObj in tempList)
                        {
                            if (tempObj is ArrayList)
                            {
                                ArrayList tempArrayList = (ArrayList)tempObj;
                                foreach (object detailObj in tempArrayList)
                                {
                                    //---------------------------------------------------
                                    // �������̓f�[�^
                                    //---------------------------------------------------
                                    if (detailObj is StockDetailWork)
                                    {
                                        StockDetailWork tempWork = (StockDetailWork)detailObj;
                                        if ((tempWork.SalesSlipDtlNumSync != 0) && (tempWork.StockSlipDtlNumSrc == 0))
                                        {
                                            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayList(tempList, out tempStockSlipWork, out tempStockDetailWorkArray, out tempAddUpOrgStockDetailWorkArray, out tempStockWorkArray, out tempUOEOrderDtlWorkArray);
                                            if (tempStockSlipWork != null)
                                            {
                                                stockSlipWorkList.Add(tempStockSlipWork);
                                                stockDetailWrokList.AddRange(tempStockDetailWorkArray);
                                            }
                                            if (tempAddUpOrgStockDetailWorkArray != null)
                                            {
                                                addUpOrgStockDetailWorkList.AddRange(tempAddUpOrgStockDetailWorkArray);
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (paraList2[i] is ArrayList)
                    {
                        CustomSerializeArrayList tempList = new CustomSerializeArrayList();
                        ArrayList tempArrayList = (ArrayList)paraList2[i];

                        foreach (object detailObj in tempArrayList)
                        {
                            //---------------------------------------------------
                            // UOE�����f�[�^
                            //---------------------------------------------------
                            if (detailObj is UOEOrderDtlWork)
                            {
                                UOEOrderDtlWork tempWork = (UOEOrderDtlWork)detailObj;
                                tempList.Add(tempArrayList);
                                DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayList(tempList, out tempStockSlipWork, out tempStockDetailWorkArray, out tempAddUpOrgStockDetailWorkArray, out tempStockWorkArray, out tempUOEOrderDtlWorkArray);
                                if (tempUOEOrderDtlWorkArray != null)
                                {
                                    uoeOrderDtlWorkArray = tempUOEOrderDtlWorkArray;
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i���דǂݍ��ݗp�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="paraList2">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="stockSlipWorkArray">�d���f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="stockDetailWorkArray">�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="uoeOrderDtlWorkArray">UOE�����f�[�^���[�N�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayListForDetailsReadingProc(CustomSerializeArrayList paraList, CustomSerializeArrayList paraList2, out SalesDetailWork[] salesDetailWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out StockSlipWork[] stockSlipWorkArray, out StockDetailWork[] stockDetailWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray)
        {
            //---------------------------------------------------
            // ���㖾�׃f�[�^�A�󒍃}�X�^�i�ԗ��j
            //---------------------------------------------------
            salesDetailWorkArray = null;
            ArrayList tempArrayList = new ArrayList();
            ArrayList retSalesDetailWorkList = new ArrayList();
            ArrayList retAcceptOdrCarWorkList = new ArrayList();
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is ArrayList)
                {
                    tempArrayList = (ArrayList)paraList[i];
                    if (tempArrayList[0].GetType() == typeof(SalesDetailWork))
                    {
                        retSalesDetailWorkList = (ArrayList)paraList[i];
                    }
                    if (tempArrayList[0] is AcceptOdrCarWork)
                    {
                        retAcceptOdrCarWorkList = (ArrayList)paraList[i];
                    }
                }
            }
            salesDetailWorkArray = (SalesDetailWork[])retSalesDetailWorkList.ToArray(typeof(SalesDetailWork));
            acceptOdrCarWorkArray = (AcceptOdrCarWork[])retAcceptOdrCarWorkList.ToArray(typeof(AcceptOdrCarWork));

            //---------------------------------------------------
            // �d���A�d�����׃f�[�^
            //---------------------------------------------------
            stockSlipWorkArray = null;
            stockDetailWorkArray = null;
            uoeOrderDtlWorkArray = null;
            if (paraList2 != null)
            {
                ArrayList retStockSlipWorkList = new ArrayList();
                ArrayList retStockDetailWorkList = new ArrayList();
                ArrayList retUOEOrderDtlWorkList = new ArrayList();

                for (int i = 0; i < paraList2.Count; i++)
                {
                    if (paraList2[i] is CustomSerializeArrayList)
                    {
                        StockSlipWork readStockSlipWork;
                        StockDetailWork[] readStockDetailWorkArray;
                        UOEOrderDtlWork[] readUOEOrderDtlWorkArray;

                        DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForSalesSlipInfo((CustomSerializeArrayList)paraList2[i], out readStockSlipWork, out readStockDetailWorkArray, out readUOEOrderDtlWorkArray);

                        if (readStockSlipWork != null) retStockSlipWorkList.Add(readStockSlipWork);

                        if (readStockDetailWorkArray != null) retStockDetailWorkList.AddRange(readStockDetailWorkArray);

                        if (readUOEOrderDtlWorkArray != null) retUOEOrderDtlWorkList.AddRange(readUOEOrderDtlWorkArray);
                    }
                }

                stockSlipWorkArray = (StockSlipWork[])retStockSlipWorkList.ToArray(typeof(StockSlipWork));
                stockDetailWorkArray = (StockDetailWork[])retStockDetailWorkList.ToArray(typeof(StockDetailWork));
                uoeOrderDtlWorkArray = (UOEOrderDtlWork[])retUOEOrderDtlWorkList.ToArray(typeof(UOEOrderDtlWork));
            }
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�d�����p�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="stockSlipWork">�d���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockDetailWorkArray">�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUpOrgStockDetailWorkArray">�v�㌳�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        /// <param name="uoeOrderDtlWorkArray">UOE�����f�[�^���[�N�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray, out StockWork[] stockWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray)
        {
            stockSlipWork = null;
            stockDetailWorkArray = null;
            addUpOrgStockDetailWorkArray = null;
            stockWorkArray = null;
            uoeOrderDtlWorkArray = null;

            object objStockSlipWork;
            object objStockDetailWorkArray;
            object objPaymentWork;
            object objDepositAlwWork;
            object objAddUpOrgStockDetailWorkArray;
            object objUOEOrderDtlWorkArray;

            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListProc(paraList, out objStockSlipWork, out objStockDetailWorkArray, out objAddUpOrgStockDetailWorkArray, out objPaymentWork, out objDepositAlwWork, out stockWorkArray, out objUOEOrderDtlWorkArray);

            if ((objStockSlipWork != null) && (objStockSlipWork is StockSlipWork)) stockSlipWork = (StockSlipWork)objStockSlipWork;

            if ((objStockDetailWorkArray != null) && (objStockDetailWorkArray is StockDetailWork[])) stockDetailWorkArray = (StockDetailWork[])objStockDetailWorkArray;

            if ((objAddUpOrgStockDetailWorkArray != null) && (objAddUpOrgStockDetailWorkArray is AddUpOrgStockDetailWork[])) addUpOrgStockDetailWorkArray = (AddUpOrgStockDetailWork[])objAddUpOrgStockDetailWorkArray;

            if ((objUOEOrderDtlWorkArray != null) && (objUOEOrderDtlWorkArray is UOEOrderDtlWork[])) uoeOrderDtlWorkArray = (UOEOrderDtlWork[])objUOEOrderDtlWorkArray;
        }

        //>>>2010/02/26
        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i������p�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUppOrgSalesDetailWorkArray">�v�㌳���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="depsitDataWork">�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="depositAlwWork">���������f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>        
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray)
        {
            SCMAcOdrDataWork scmAcOdrDataWork = null;
            SCMAcOdrDtlIqWork[] scmAcOdrDataWorkArray = null;
            SCMAcOdrDtlAsWork[] scmAcOdrDtlAsWorkArray = null;
            SCMAcOdrDtCarWork scmAcOdrDtCarWork = null;

            DivisionCustomSerializeArrayList(paraList, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockWorkArray, out acceptOdrCarWorkArray, out  scmAcOdrDataWork, out scmAcOdrDataWorkArray, out scmAcOdrDtlAsWorkArray, out scmAcOdrDtCarWork);
        }
        //<<<2010/02/26

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i������p�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUppOrgSalesDetailWorkArray">�v�㌳���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="depsitDataWork">�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="depositAlwWork">���������f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>        
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        //private static void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray) // 2010/02/26
        private static void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out SCMAcOdrDataWork scmAcOdrDataWork, out SCMAcOdrDtlIqWork[] scmAcOdrDataWorkArray, out SCMAcOdrDtlAsWork[] scmAcOdrDtlAsWorkArray, out SCMAcOdrDtCarWork scmAcOdrDtCarWork) // 2010/02/26
        {
            salesSlipWork = null;
            salesDetailWorkArray = null;
            addUpOrgSalesDetailWorkArray = null;
            depsitDataWork = null;
            depositAlwWork = null;
            stockWorkArray = null;
            acceptOdrCarWorkArray = null;
            //>>>2010/02/26
            scmAcOdrDataWork = null;
            scmAcOdrDataWorkArray = null;
            scmAcOdrDtlAsWorkArray = null;
            scmAcOdrDtCarWork = null;
            //<<<2010/02/26

            object objSalesSlipWork;
            object objSalesDetailWorkArray;
            object objAddUpOrgSalesDetailWorkArray;
            object objDepsitDataWork;
            object objDepositAlwWork;
            object objAcceptOdrCarWorkArray;
            object objUOEOrderDtlWorkArray;
            //>>>2010/02/26
            object objSCMHeader;
            object objSCMCar;
            object objSCMDetailArray;
            object objSCMAnswerArray;
            //<<<2010/02/26

            //>>>2010/02/26
            //DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListProc(paraList, out objSalesSlipWork, out objSalesDetailWorkArray, out objAddUpOrgSalesDetailWorkArray, out objDepsitDataWork, out objDepositAlwWork, out stockWorkArray, out objAcceptOdrCarWorkArray, out objUOEOrderDtlWorkArray);
            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListProc(paraList, out objSalesSlipWork, out objSalesDetailWorkArray, out objAddUpOrgSalesDetailWorkArray, out objDepsitDataWork, out objDepositAlwWork, out stockWorkArray, out objAcceptOdrCarWorkArray, out objUOEOrderDtlWorkArray, out objSCMHeader, out objSCMCar, out objSCMDetailArray, out objSCMAnswerArray);
            //<<<2010/02/26

            if ((objSalesSlipWork != null) && (objSalesSlipWork is SalesSlipWork)) salesSlipWork = (SalesSlipWork)objSalesSlipWork;

            if ((objSalesDetailWorkArray != null) && (objSalesDetailWorkArray.GetType() == typeof(SalesDetailWork[]))) salesDetailWorkArray = (SalesDetailWork[])objSalesDetailWorkArray;

            if ((objAddUpOrgSalesDetailWorkArray != null) && (objAddUpOrgSalesDetailWorkArray.GetType() == typeof(AddUpOrgSalesDetailWork[]))) addUpOrgSalesDetailWorkArray = (AddUpOrgSalesDetailWork[])objAddUpOrgSalesDetailWorkArray;

            if ((objDepsitDataWork != null) && (objDepsitDataWork is DepsitDataWork)) depsitDataWork = (DepsitDataWork)objDepsitDataWork;

            if ((objDepositAlwWork != null) && (objDepositAlwWork is DepositAlwWork)) depositAlwWork = (DepositAlwWork)objDepositAlwWork;

            if ((objAcceptOdrCarWorkArray != null) && (objAcceptOdrCarWorkArray is AcceptOdrCarWork[])) acceptOdrCarWorkArray = (AcceptOdrCarWork[])objAcceptOdrCarWorkArray;
            
            //>>>2010/02/26
            if ((objSCMHeader != null) && (objSCMHeader is SCMAcOdrDataWork)) scmAcOdrDataWork = (SCMAcOdrDataWork)objSCMHeader;
            if ((objSCMCar != null) && (objSCMCar is SCMAcOdrDtCarWork)) scmAcOdrDtCarWork = (SCMAcOdrDtCarWork)objSCMCar;
            if ((objSCMDetailArray != null) && (objSCMDetailArray is SCMAcOdrDtlIqWork[])) scmAcOdrDataWorkArray = (SCMAcOdrDtlIqWork[])objSCMDetailArray;
            if ((objSCMAnswerArray != null) && (objSCMAnswerArray is SCMAcOdrDtlAsWork[])) scmAcOdrDtlAsWorkArray = (SCMAcOdrDtlAsWork[])objSCMAnswerArray;
            //<<<2010/02/26
        }

        //>>>2010/02/26
        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i������p�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="salesSlipWork">����f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUppOrgSalesDetailWorkArray">�v�㌳���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="depsitDataWork">�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="depositAlwWork">���������f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>        
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="scmHeader">SCM�󒍃f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="scmCar">SCM�󒍃f�[�^(�ԗ����)���[�N�I�u�W�F�N�g</param>
        /// <param name="scmDetailArray">SCM�󒍖��׃f�[�^(�⍇���E����)���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="scmAnswerArray">SCM�󒍖��׃f�[�^(��)���[�N�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray, out UserSCMOrderHeaderRecord scmHeader, out UserSCMOrderCarRecord scmCar, out UserSCMOrderDetailRecord[] scmDetailArray, out UserSCMOrderAnswerRecord[] scmAnswerArray)
        {
            salesSlipWork = null;
            salesDetailWorkArray = null;
            addUpOrgSalesDetailWorkArray = null;
            depsitDataWork = null;
            depositAlwWork = null;
            stockWorkArray = null;
            acceptOdrCarWorkArray = null;
            scmHeader = null;
            scmCar = null;
            scmDetailArray = null;
            scmAnswerArray = null;

            object objSalesSlipWork;
            object objSalesDetailWorkArray;
            object objAddUpOrgSalesDetailWorkArray;
            object objDepsitDataWork;
            object objDepositAlwWork;
            object objAcceptOdrCarWorkArray;
            object objUOEOrderDtlWorkArray;
            object objSCMHeader;
            object objSCMCar;
            object objSCMDetailArray;
            object objSCMAnswerArray;

            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListProc(paraList, out objSalesSlipWork, out objSalesDetailWorkArray, out objAddUpOrgSalesDetailWorkArray, out objDepsitDataWork, out objDepositAlwWork, out stockWorkArray, out objAcceptOdrCarWorkArray, out objUOEOrderDtlWorkArray, out objSCMHeader, out objSCMCar, out objSCMDetailArray, out objSCMAnswerArray);

            if ((objSalesSlipWork != null) && (objSalesSlipWork is SalesSlipWork)) salesSlipWork = (SalesSlipWork)objSalesSlipWork;

            if ((objSalesDetailWorkArray != null) && (objSalesDetailWorkArray.GetType() == typeof(SalesDetailWork[]))) salesDetailWorkArray = (SalesDetailWork[])objSalesDetailWorkArray;

            if ((objAddUpOrgSalesDetailWorkArray != null) && (objAddUpOrgSalesDetailWorkArray.GetType() == typeof(AddUpOrgSalesDetailWork[]))) addUpOrgSalesDetailWorkArray = (AddUpOrgSalesDetailWork[])objAddUpOrgSalesDetailWorkArray;

            if ((objDepsitDataWork != null) && (objDepsitDataWork is DepsitDataWork)) depsitDataWork = (DepsitDataWork)objDepsitDataWork;

            if ((objDepositAlwWork != null) && (objDepositAlwWork is DepositAlwWork)) depositAlwWork = (DepositAlwWork)objDepositAlwWork;

            if ((objAcceptOdrCarWorkArray != null) && (objAcceptOdrCarWorkArray is AcceptOdrCarWork[])) acceptOdrCarWorkArray = (AcceptOdrCarWork[])objAcceptOdrCarWorkArray;

            if ((objSCMHeader != null) && (objSCMHeader is SCMAcOdrDataWork)) scmHeader = new UserSCMOrderHeaderRecord((SCMAcOdrDataWork)objSCMHeader);
            if ((objSCMCar != null) && (objSCMCar is SCMAcOdrDtCarWork)) scmCar = new UserSCMOrderCarRecord((SCMAcOdrDtCarWork)objSCMCar);
            if ((objSCMDetailArray != null) && (objSCMDetailArray is UserSCMOrderDetailRecord[])) scmDetailArray = (UserSCMOrderDetailRecord[])objSCMDetailArray;
            if ((objSCMAnswerArray != null) && (objSCMAnswerArray is UserSCMOrderAnswerRecord[])) scmAnswerArray = (UserSCMOrderAnswerRecord[])objSCMAnswerArray;
        }
        //<<<2010/02/26

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="slipWork">�`�[�f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="detailWorkArray">���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUpOrgDetailWorkArray">�v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="depsitDataWork">�����^�x���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="depositAlwWork">���������f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        /// <param name="uoeOrderDtlWorkArray">UOE�����f�[�^���[�N�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayListProc(CustomSerializeArrayList paraList, out object slipWork, out object detailWorkArray, out object addUpOrgDetailWorkArray, out object depsitDataWork, out object depositAlwWork, out StockWork[] stockWorkArray, out object uoeOrderDtlWorkArray)
        {
            object acceptOdrCarWorkArray = null;
            //>>>2010/02/26
            object scmHeader = null;
            object scmCar = null;
            object scmDetailArray = null;
            object scmAnswerArray = null;
            //<<<2010/02/26

            //>>>2010/02/26
            //DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListProc(paraList, out slipWork, out detailWorkArray, out addUpOrgDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockWorkArray, out acceptOdrCarWorkArray, out uoeOrderDtlWorkArray);
            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListProc(paraList, out slipWork, out detailWorkArray, out addUpOrgDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockWorkArray, out acceptOdrCarWorkArray, out uoeOrderDtlWorkArray, out scmHeader, out scmCar, out scmDetailArray, out scmAnswerArray);
            //<<<2010/02/26
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="slipWork">�`�[�f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="detailWorkArray">���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUpOrgDetailWorkArray">�v�㌳���׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="depsitDataWork">�����^�x���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="depositAlwWork">���������f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="uoeOrderDtlWorkArray">UOE�����f�[�^���[�N�I�u�W�F�N�g�z��</param>
        //>>>2010/02/26
        //private static void DivisionCustomSerializeArrayListProc(CustomSerializeArrayList paraList, out object slipWork, out object detailWorkArray, out object addUpOrgDetailWorkArray, out object depsitDataWork, out object depositAlwWork, out StockWork[] stockWorkArray, out object acceptOdrCarWorkArray, out object uoeOrderDtlWorkArray)
        private static void DivisionCustomSerializeArrayListProc(CustomSerializeArrayList paraList, out object slipWork, out object detailWorkArray, out object addUpOrgDetailWorkArray, out object depsitDataWork, out object depositAlwWork, out StockWork[] stockWorkArray, out object acceptOdrCarWorkArray, out object uoeOrderDtlWorkArray, out object scmHeader, out object scmCar, out object scmDetailArray, out object scmAnswerArray)
        //<<<2010/02/26
        {
            slipWork = null;
            detailWorkArray = null;
            addUpOrgDetailWorkArray = null;
            depsitDataWork = null;
            depositAlwWork = null;
            stockWorkArray = null;
            acceptOdrCarWorkArray = null;
            uoeOrderDtlWorkArray = null;
            //>>>2010/02/26
            scmHeader = null;
            scmCar = null;
            scmDetailArray = null;
            scmAnswerArray = null;
            //<<<2010/02/26

            for (int i = 0; i < paraList.Count; i++)
            {
                if ((paraList[i] is StockSlipWork) || (paraList[i] is SalesSlipWork))
                {
                    slipWork = paraList[i];
                }
                else if ((paraList[i] is PaymentSlpWork) || (paraList[i] is DepsitDataWork))
                {
                    depsitDataWork = paraList[i];
                }
                else if (paraList[i] is DepositAlwWork)
                {
                    depositAlwWork = paraList[i];
                }
                //>>>2010/02/26
                else if (paraList[i] is SCMAcOdrDataWork) // SCM�󒍃f�[�^���[�N�I�u�W�F�N�g
                {
                    scmHeader = paraList[i];
                }
                else if (paraList[i] is SCMAcOdrDtCarWork) // SCM�󒍃f�[�^(�ԗ����)���[�N�I�u�W�F�N�g
                {
                    scmCar = paraList[i];
                }
                //<<<2010/02/26
                else if (paraList[i] is ArrayList)
                {
                    ArrayList list = (ArrayList)paraList[i];

                    if (list.Count == 0) continue;

                    if (list[0].GetType() == typeof(AddUpOrgStockDetailWork))
                    {
                        addUpOrgDetailWorkArray = (AddUpOrgStockDetailWork[])list.ToArray(typeof(AddUpOrgStockDetailWork));
                    }
                    else if (list[0].GetType() == typeof(AddUpOrgSalesDetailWork))
                    {
                        addUpOrgDetailWorkArray = (AddUpOrgSalesDetailWork[])list.ToArray(typeof(AddUpOrgSalesDetailWork));
                    }
                    else if (list[0].GetType() == typeof(StockDetailWork))
                    {
                        detailWorkArray = (StockDetailWork[])list.ToArray(typeof(StockDetailWork));
                    }
                    else if (list[0].GetType() == typeof(SalesDetailWork))
                    {
                        detailWorkArray = (SalesDetailWork[])list.ToArray(typeof(SalesDetailWork));
                    }
                    else if (list[0] is StockWork)
                    {
                        stockWorkArray = (StockWork[])list.ToArray(typeof(StockWork));
                    }
                    else if (list[0] is AcceptOdrCarWork)
                    {
                        acceptOdrCarWorkArray = (AcceptOdrCarWork[])list.ToArray(typeof(AcceptOdrCarWork));
                    }
                    else if (list[0] is UOEOrderDtlWork)
                    {
                        uoeOrderDtlWorkArray = (UOEOrderDtlWork[])list.ToArray(typeof(UOEOrderDtlWork));
                    }
                    //>>>2010/02/26
                    else if (list[0] is SCMAcOdrDtlIqWork) // SCM�󒍖��׃f�[�^(�⍇���E����)���[�N�I�u�W�F�N�g�z��
                    {
                        ArrayList al = new ArrayList();
                        foreach (SCMAcOdrDtlIqWork work in list)
                        {
                            UserSCMOrderDetailRecord detail = new UserSCMOrderDetailRecord(work);
                            al.Add(detail);
                        }
                        scmDetailArray = (UserSCMOrderDetailRecord[])al.ToArray(typeof(UserSCMOrderDetailRecord));
                    }
                    else if (list[0] is SCMAcOdrDtlAsWork) // SCM�󒍖��׃f�[�^(��)���[�N�I�u�W�F�N�g�z��
                    {
                        ArrayList al = new ArrayList();
                        foreach (SCMAcOdrDtlAsWork work in list)
                        {
                            UserSCMOrderAnswerRecord answer = new UserSCMOrderAnswerRecord(work);
                            al.Add(answer);
                        }
                        scmAnswerArray = (UserSCMOrderAnswerRecord[])al.ToArray(typeof(UserSCMOrderAnswerRecord));
                    }
                    //<<<2010/02/26
                }
            }
        }

        /// <summary>
        /// CustomSerializeArrayList�𔄏㖾�׃f�[�^�I�u�W�F�N�g�ɕ������܂��B
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out SalesDetailWork[] salesDetailWorkArray)
        {
            salesDetailWorkArray = null;

            ArrayList retSalesDetailWorkList = new ArrayList();
            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i].GetType() == typeof(SalesDetailWork))
                {
                    retSalesDetailWorkList.Add((SalesDetailWork)paraList[i]);
                }
            }
            salesDetailWorkArray = (SalesDetailWork[])retSalesDetailWorkList.ToArray(typeof(SalesDetailWork));
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i�d�����p�j�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="stockSlipWork">�d���f�[�^���[�N�I�u�W�F�N�g</param>
        /// <param name="stockDetailWorkArray">�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="addUpOrgStockDetailWorkArray">�v�㌳�d�����׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="paymentSlpWork">�x���f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockWorkArray">�݌Ƀ��[�N�I�u�W�F�N�g�z��</param>
        /// <param name="uoeOrderDtlWorkArray">UOE�����f�[�^���[�N�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayListForStockSlipInfo(CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray, out PaymentSlpWork paymentSlpWork, out StockWork[] stockWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray)
        {
            stockSlipWork = null;
            stockDetailWorkArray = null;
            addUpOrgStockDetailWorkArray = null;
            paymentSlpWork = null;
            stockWorkArray = null;
            uoeOrderDtlWorkArray = null;

            object objStockSlipWork;
            object objStockDetailWorkArray;
            object objAddUpOrgStockDetailWorkArray;
            object objPaymentSlpWork;
            object objDummy;
            object objUOEOrderDtlWorkArray = null;

            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListProc(paraList, out objStockSlipWork, out objStockDetailWorkArray, out objAddUpOrgStockDetailWorkArray, out objPaymentSlpWork, out objDummy, out stockWorkArray, out objUOEOrderDtlWorkArray);

            if ((objStockSlipWork != null) && (objStockSlipWork is StockSlipWork)) stockSlipWork = (StockSlipWork)objStockSlipWork;

            if ((objStockDetailWorkArray != null) && (objStockDetailWorkArray.GetType() == typeof(StockDetailWork[]))) stockDetailWorkArray = (StockDetailWork[])objStockDetailWorkArray;

            if ((objAddUpOrgStockDetailWorkArray != null) && (objAddUpOrgStockDetailWorkArray.GetType() == typeof(AddUpOrgStockDetailWork[]))) objAddUpOrgStockDetailWorkArray = (AddUpOrgStockDetailWork[])objAddUpOrgStockDetailWorkArray;

            if ((objPaymentSlpWork != null) && (objPaymentSlpWork is PaymentSlpWork)) paymentSlpWork = (PaymentSlpWork)objPaymentSlpWork;
        }

        /// <summary>
        /// CustomSerializeArrayList���e��f�[�^�I�u�W�F�N�g�ɕ������܂��B�i������p�j�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="paraList">�J�X�^���V���A���C�Y���X�g�I�u�W�F�N�g</param>
        /// <param name="salesSlipWork">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesDetailWorkArray">���㖾�׃f�[�^���[�N�I�u�W�F�N�g�z��</param>
        /// <param name="uoeOrderDtlWorkArray">UOE�����f�[�^���[�N�I�u�W�F�N�g�z��</param>
        private static void DivisionCustomSerializeArrayListForSalesSlipInfo(CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out UOEOrderDtlWork[] uoeOrderDtlWorkArray)
        {
            stockSlipWork = null;
            stockDetailWorkArray = null;
            uoeOrderDtlWorkArray = null;

            object objStockSlipWork;
            object objStockDetailWorkArray;
            object objAddUpOrgStockDetailWorkArray;
            object objPaymentSlpWork;
            object objDummy;
            StockWork[] stockWorkArray;
            object objUOEOrderDtlWorkArray;

            DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListProc(paraList, out objStockSlipWork, out objStockDetailWorkArray, out objAddUpOrgStockDetailWorkArray, out objPaymentSlpWork, out objDummy, out stockWorkArray, out objUOEOrderDtlWorkArray);

            if ((objStockSlipWork != null) && (objStockSlipWork is StockSlipWork)) stockSlipWork = (StockSlipWork)objStockSlipWork;

            if ((objStockDetailWorkArray != null) && (objStockDetailWorkArray.GetType() == typeof(StockDetailWork[]))) stockDetailWorkArray = (StockDetailWork[])objStockDetailWorkArray;

            if ((objUOEOrderDtlWorkArray != null) && (objUOEOrderDtlWorkArray is UOEOrderDtlWork[])) uoeOrderDtlWorkArray = (UOEOrderDtlWork[])objUOEOrderDtlWorkArray;
        }
        #endregion
    }
}
