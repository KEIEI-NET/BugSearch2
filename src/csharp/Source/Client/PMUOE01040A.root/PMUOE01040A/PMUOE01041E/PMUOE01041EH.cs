//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ���㖾�׃e�[�u���X�L�[�}�N���X
// �v���O�����T�v   : ���㖾�׃e�[�u����`���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2011/01/19  �C�����e : Mantis.16772 SCM���ڂ����M�����Ŕ���f�[�^�ɃZ�b�g����Ȃ����̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2011/07/28  �C�����e : �����񓚋敪�ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2012/01/16  �C�����e : SCM���ǁE���L�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/12/06  �C�����e : SCM��Q��10447�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���㖾�׃e�[�u���X�L�[�}�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���㖾�ג��o���ʃe�[�u���X�L�[�}</br>
    /// <br>Programmer : 96186�@���ԗT��</br>
    /// <br>Date       : 2008.05.26</br>
    /// </remarks>
    public class SalesDetailSchema
    {
        #region Public Members
        /// <summary>���㖾�׃e�[�u����</summary>
        public const string CT_SalesDetailDataTable = "SalesDetailDataTable";

        /// <summary>�󒍖��׃e�[�u����</summary>
        public const string CT_AcptDetailDataTable = "AcptDetailDataTable";


        #region �J�����������
        public const double defValueDouble = 0;
        public const Int64 defValueInt64 = 0;
        public const Int32 defValueInt32 = 0;
        public const string defValuestring = "";
        // ADD 2012/12/06 2012/12/12�z�M�\�� SCM��Q��10447�Ή� ----------------------------------->>>>>
        public const short defValueShort = 0;
        // ADD 2012/12/06 2012/12/12�z�M�\�� SCM��Q��10447�Ή� -----------------------------------<<<<<
        #endregion

        #region �J�������
        /// <summary> �쐬���� </summary>
        public const string ct_Col_CreateDateTime = "CreateDateTime";
        /// <summary> �X�V���� </summary>
        public const string ct_Col_UpdateDateTime = "UpdateDateTime";
        /// <summary> ��ƃR�[�h </summary>
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        /// <summary> GUID </summary>
        public const string ct_Col_FileHeaderGuid = "FileHeaderGuid";
        /// <summary> �X�V�]�ƈ��R�[�h </summary>
        public const string ct_Col_UpdEmployeeCode = "UpdEmployeeCode";
        /// <summary> �X�V�A�Z���u��ID1 </summary>
        public const string ct_Col_UpdAssemblyId1 = "UpdAssemblyId1";
        /// <summary> �X�V�A�Z���u��ID2 </summary>
        public const string ct_Col_UpdAssemblyId2 = "UpdAssemblyId2";
        /// <summary> �_���폜�敪 </summary>
        public const string ct_Col_LogicalDeleteCode = "LogicalDeleteCode";
        /// <summary> �󒍔ԍ� </summary>
        public const string ct_Col_AcceptAnOrderNo = "AcceptAnOrderNo";
        /// <summary> �󒍃X�e�[�^�X </summary>
        public const string ct_Col_AcptAnOdrStatus = "AcptAnOdrStatus";
        /// <summary> ����`�[�ԍ� </summary>
        public const string ct_Col_SalesSlipNum = "SalesSlipNum";
        /// <summary> ����s�ԍ� </summary>
        public const string ct_Col_SalesRowNo = "SalesRowNo";
        /// <summary> ����s�ԍ��}�� </summary>
        public const string ct_Col_SalesRowDerivNo = "SalesRowDerivNo";
        /// <summary> ���_�R�[�h </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> ����R�[�h </summary>
        public const string ct_Col_SubSectionCode = "SubSectionCode";
        /// <summary> ������t </summary>
        public const string ct_Col_SalesDate = "SalesDate";
        /// <summary> ���ʒʔ� </summary>
        public const string ct_Col_CommonSeqNo = "CommonSeqNo";
        /// <summary> ���㖾�גʔ� </summary>
        public const string ct_Col_SalesSlipDtlNum = "SalesSlipDtlNum";
        /// <summary> �󒍃X�e�[�^�X�i���j </summary>
        public const string ct_Col_AcptAnOdrStatusSrc = "AcptAnOdrStatusSrc";
        /// <summary> ���㖾�גʔԁi���j </summary>
        public const string ct_Col_SalesSlipDtlNumSrc = "SalesSlipDtlNumSrc";
        /// <summary> �d���`���i�����j </summary>
        public const string ct_Col_SupplierFormalSync = "SupplierFormalSync";
        /// <summary> �d�����גʔԁi�����j </summary>
        public const string ct_Col_StockSlipDtlNumSync = "StockSlipDtlNumSync";
        /// <summary> ����`�[�敪�i���ׁj </summary>
        public const string ct_Col_SalesSlipCdDtl = "SalesSlipCdDtl";
        /// <summary> �[�i�����\��� </summary>
        public const string ct_Col_DeliGdsCmpltDueDate = "DeliGdsCmpltDueDate";
        /// <summary> ���i���� </summary>
        public const string ct_Col_GoodsKindCode = "GoodsKindCode";
        /// <summary> ���i�����敪 </summary>
        public const string ct_Col_GoodsSearchDivCd = "GoodsSearchDivCd";
        /// <summary> ���i���[�J�[�R�[�h </summary>
        public const string ct_Col_GoodsMakerCd = "GoodsMakerCd";
        /// <summary> ���[�J�[���� </summary>
        public const string ct_Col_MakerName = "MakerName";
        /// <summary> ���[�J�[�J�i���� </summary>
        public const string ct_Col_MakerKanaName = "MakerKanaName";
        /// <summary> ���i�ԍ� </summary>
        public const string ct_Col_GoodsNo = "GoodsNo";
        /// <summary> ���i���� </summary>
        public const string ct_Col_GoodsName = "GoodsName";
        /// <summary> ���i���̃J�i </summary>
        public const string ct_Col_GoodsNameKana = "GoodsNameKana";
        /// <summary> ���i�啪�ރR�[�h </summary>
        public const string ct_Col_GoodsLGroup = "GoodsLGroup";
        /// <summary> ���i�啪�ޖ��� </summary>
        public const string ct_Col_GoodsLGroupName = "GoodsLGroupName";
        /// <summary> ���i�����ރR�[�h </summary>
        public const string ct_Col_GoodsMGroup = "GoodsMGroup";
        /// <summary> ���i�����ޖ��� </summary>
        public const string ct_Col_GoodsMGroupName = "GoodsMGroupName";
        /// <summary> BL�O���[�v�R�[�h </summary>
        public const string ct_Col_BLGroupCode = "BLGroupCode";
        /// <summary> BL�O���[�v�R�[�h���� </summary>
        public const string ct_Col_BLGroupName = "BLGroupName";
        /// <summary> BL���i�R�[�h </summary>
        public const string ct_Col_BLGoodsCode = "BLGoodsCode";
        /// <summary> BL���i�R�[�h���́i�S�p�j </summary>
        public const string ct_Col_BLGoodsFullName = "BLGoodsFullName";
        /// <summary> ���Е��ރR�[�h </summary>
        public const string ct_Col_EnterpriseGanreCode = "EnterpriseGanreCode";
        /// <summary> ���Е��ޖ��� </summary>
        public const string ct_Col_EnterpriseGanreName = "EnterpriseGanreName";
        /// <summary> �q�ɃR�[�h </summary>
        public const string ct_Col_WarehouseCode = "WarehouseCode";
        /// <summary> �q�ɖ��� </summary>
        public const string ct_Col_WarehouseName = "WarehouseName";
        /// <summary> �q�ɒI�� </summary>
        public const string ct_Col_WarehouseShelfNo = "WarehouseShelfNo";
        /// <summary> ����݌Ɏ�񂹋敪 </summary>
        public const string ct_Col_SalesOrderDivCd = "SalesOrderDivCd";
        /// <summary> �I�[�v�����i�敪 </summary>
        public const string ct_Col_OpenPriceDiv = "OpenPriceDiv";
        /// <summary> ���i�|�������N </summary>
        public const string ct_Col_GoodsRateRank = "GoodsRateRank";
        /// <summary> ���Ӑ�|���O���[�v�R�[�h </summary>
        public const string ct_Col_CustRateGrpCode = "CustRateGrpCode";
        /// <summary> �艿�� </summary>
        public const string ct_Col_ListPriceRate = "ListPriceRate";
        /// <summary> �|���ݒ苒�_�i�艿�j </summary>
        public const string ct_Col_RateSectPriceUnPrc = "RateSectPriceUnPrc";
        /// <summary> �|���ݒ�敪�i�艿�j </summary>
        public const string ct_Col_RateDivLPrice = "RateDivLPrice";
        /// <summary> �P���Z�o�敪�i�艿�j </summary>
        public const string ct_Col_UnPrcCalcCdLPrice = "UnPrcCalcCdLPrice";
        /// <summary> ���i�敪�i�艿�j </summary>
        public const string ct_Col_PriceCdLPrice = "PriceCdLPrice";
        /// <summary> ��P���i�艿�j </summary>
        public const string ct_Col_StdUnPrcLPrice = "StdUnPrcLPrice";
        /// <summary> �[�������P�ʁi�艿�j </summary>
        public const string ct_Col_FracProcUnitLPrice = "FracProcUnitLPrice";
        /// <summary> �[�������i�艿�j </summary>
        public const string ct_Col_FracProcLPrice = "FracProcLPrice";
        /// <summary> �艿�i�ō��C�����j </summary>
        public const string ct_Col_ListPriceTaxIncFl = "ListPriceTaxIncFl";
        /// <summary> �艿�i�Ŕ��C�����j </summary>
        public const string ct_Col_ListPriceTaxExcFl = "ListPriceTaxExcFl";
        /// <summary> �艿�ύX�敪 </summary>
        public const string ct_Col_ListPriceChngCd = "ListPriceChngCd";
        /// <summary> ������ </summary>
        public const string ct_Col_SalesRate = "SalesRate";
        /// <summary> �|���ݒ苒�_�i����P���j </summary>
        public const string ct_Col_RateSectSalUnPrc = "RateSectSalUnPrc";
        /// <summary> �|���ݒ�敪�i����P���j </summary>
        public const string ct_Col_RateDivSalUnPrc = "RateDivSalUnPrc";
        /// <summary> �P���Z�o�敪�i����P���j </summary>
        public const string ct_Col_UnPrcCalcCdSalUnPrc = "UnPrcCalcCdSalUnPrc";
        /// <summary> ���i�敪�i����P���j </summary>
        public const string ct_Col_PriceCdSalUnPrc = "PriceCdSalUnPrc";
        /// <summary> ��P���i����P���j </summary>
        public const string ct_Col_StdUnPrcSalUnPrc = "StdUnPrcSalUnPrc";
        /// <summary> �[�������P�ʁi����P���j </summary>
        public const string ct_Col_FracProcUnitSalUnPrc = "FracProcUnitSalUnPrc";
        /// <summary> �[�������i����P���j </summary>
        public const string ct_Col_FracProcSalUnPrc = "FracProcSalUnPrc";
        /// <summary> ����P���i�ō��C�����j </summary>
        public const string ct_Col_SalesUnPrcTaxIncFl = "SalesUnPrcTaxIncFl";
        /// <summary> ����P���i�Ŕ��C�����j </summary>
        public const string ct_Col_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";
        /// <summary> ����P���ύX�敪 </summary>
        public const string ct_Col_SalesUnPrcChngCd = "SalesUnPrcChngCd";
        /// <summary> ������ </summary>
        public const string ct_Col_CostRate = "CostRate";
        /// <summary> �|���ݒ苒�_�i�����P���j </summary>
        public const string ct_Col_RateSectCstUnPrc = "RateSectCstUnPrc";
        /// <summary> �|���ݒ�敪�i�����P���j </summary>
        public const string ct_Col_RateDivUnCst = "RateDivUnCst";
        /// <summary> �P���Z�o�敪�i�����P���j </summary>
        public const string ct_Col_UnPrcCalcCdUnCst = "UnPrcCalcCdUnCst";
        /// <summary> ���i�敪�i�����P���j </summary>
        public const string ct_Col_PriceCdUnCst = "PriceCdUnCst";
        /// <summary> ��P���i�����P���j </summary>
        public const string ct_Col_StdUnPrcUnCst = "StdUnPrcUnCst";
        /// <summary> �[�������P�ʁi�����P���j </summary>
        public const string ct_Col_FracProcUnitUnCst = "FracProcUnitUnCst";
        /// <summary> �[�������i�����P���j </summary>
        public const string ct_Col_FracProcUnCst = "FracProcUnCst";
        /// <summary> �����P�� </summary>
        public const string ct_Col_SalesUnitCost = "SalesUnitCost";
        /// <summary> �����P���ύX�敪 </summary>
        public const string ct_Col_SalesUnitCostChngDiv = "SalesUnitCostChngDiv";
        /// <summary> BL���i�R�[�h�i�|���j </summary>
        public const string ct_Col_RateBLGoodsCode = "RateBLGoodsCode";
        /// <summary> BL���i�R�[�h���́i�|���j </summary>
        public const string ct_Col_RateBLGoodsName = "RateBLGoodsName";
        /// <summary> ���i�|���O���[�v�R�[�h�i�|���j </summary>
        public const string ct_Col_RateGoodsRateGrpCd = "RateGoodsRateGrpCd";
        /// <summary> ���i�|���O���[�v���́i�|���j </summary>
        public const string ct_Col_RateGoodsRateGrpNm = "RateGoodsRateGrpNm";
        /// <summary> BL�O���[�v�R�[�h�i�|���j </summary>
        public const string ct_Col_RateBLGroupCode = "RateBLGroupCode";
        /// <summary> BL�O���[�v���́i�|���j </summary>
        public const string ct_Col_RateBLGroupName = "RateBLGroupName";
        /// <summary> BL���i�R�[�h�i����j </summary>
        public const string ct_Col_PrtBLGoodsCode = "PrtBLGoodsCode";
        /// <summary> BL���i�R�[�h���́i����j </summary>
        public const string ct_Col_PrtBLGoodsName = "PrtBLGoodsName";
        /// <summary> �̔��敪�R�[�h </summary>
        public const string ct_Col_SalesCode = "SalesCode";
        /// <summary> �̔��敪���� </summary>
        public const string ct_Col_SalesCdNm = "SalesCdNm";
        /// <summary> ��ƍH�� </summary>
        public const string ct_Col_WorkManHour = "WorkManHour";
        /// <summary> �o�א� </summary>
        public const string ct_Col_ShipmentCnt = "ShipmentCnt";
        /// <summary> �󒍐��� </summary>
        public const string ct_Col_AcceptAnOrderCnt = "AcceptAnOrderCnt";
        /// <summary> �󒍒����� </summary>
        public const string ct_Col_AcptAnOdrAdjustCnt = "AcptAnOdrAdjustCnt";
        /// <summary> �󒍎c�� </summary>
        public const string ct_Col_AcptAnOdrRemainCnt = "AcptAnOdrRemainCnt";
        /// <summary> �c���X�V�� </summary>
        public const string ct_Col_RemainCntUpdDate = "RemainCntUpdDate";
        /// <summary> ������z�i�ō��݁j </summary>
        public const string ct_Col_SalesMoneyTaxInc = "SalesMoneyTaxInc";
        /// <summary> ������z�i�Ŕ����j </summary>
        public const string ct_Col_SalesMoneyTaxExc = "SalesMoneyTaxExc";
        /// <summary> ���� </summary>
        public const string ct_Col_Cost = "Cost";
        /// <summary> �e���`�F�b�N�敪 </summary>
        public const string ct_Col_GrsProfitChkDiv = "GrsProfitChkDiv";
        /// <summary> ���㏤�i�敪 </summary>
        public const string ct_Col_SalesGoodsCd = "SalesGoodsCd";
        /// <summary> ������z����Ŋz </summary>
        public const string ct_Col_SalesPriceConsTax = "SalesPriceConsTax";
        /// <summary> �ېŋ敪 </summary>
        public const string ct_Col_TaxationDivCd = "TaxationDivCd";
        /// <summary> �����`�[�ԍ��i���ׁj </summary>
        public const string ct_Col_PartySlipNumDtl = "PartySlipNumDtl";
        /// <summary> ���ה��l </summary>
        public const string ct_Col_DtlNote = "DtlNote";
        /// <summary> �d����R�[�h </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> �d���旪�� </summary>
        public const string ct_Col_SupplierSnm = "SupplierSnm";
        /// <summary> �����ԍ� </summary>
        public const string ct_Col_OrderNumber = "OrderNumber";
        /// <summary> �������@ </summary>
        public const string ct_Col_WayToOrder = "WayToOrder";
        /// <summary> �`�[�����P </summary>
        public const string ct_Col_SlipMemo1 = "SlipMemo1";
        /// <summary> �`�[�����Q </summary>
        public const string ct_Col_SlipMemo2 = "SlipMemo2";
        /// <summary> �`�[�����R </summary>
        public const string ct_Col_SlipMemo3 = "SlipMemo3";
        /// <summary> �Г������P </summary>
        public const string ct_Col_InsideMemo1 = "InsideMemo1";
        /// <summary> �Г������Q </summary>
        public const string ct_Col_InsideMemo2 = "InsideMemo2";
        /// <summary> �Г������R </summary>
        public const string ct_Col_InsideMemo3 = "InsideMemo3";
        /// <summary> �ύX�O�艿 </summary>
        public const string ct_Col_BfListPrice = "BfListPrice";
        /// <summary> �ύX�O���� </summary>
        public const string ct_Col_BfSalesUnitPrice = "BfSalesUnitPrice";
        /// <summary> �ύX�O���� </summary>
        public const string ct_Col_BfUnitCost = "BfUnitCost";
        /// <summary> �ꎮ���הԍ� </summary>
        public const string ct_Col_CmpltSalesRowNo = "CmpltSalesRowNo";
        /// <summary> ���[�J�[�R�[�h�i�ꎮ�j </summary>
        public const string ct_Col_CmpltGoodsMakerCd = "CmpltGoodsMakerCd";
        /// <summary> ���[�J�[���́i�ꎮ�j </summary>
        public const string ct_Col_CmpltMakerName = "CmpltMakerName";
        /// <summary> ���[�J�[�J�i���́i�ꎮ�j </summary>
        public const string ct_Col_CmpltMakerKanaName = "CmpltMakerKanaName";
        /// <summary> ���i���́i�ꎮ�j </summary>
        public const string ct_Col_CmpltGoodsName = "CmpltGoodsName";
        /// <summary> ���ʁi�ꎮ�j </summary>
        public const string ct_Col_CmpltShipmentCnt = "CmpltShipmentCnt";
        /// <summary> ����P���i�ꎮ�j </summary>
        public const string ct_Col_CmpltSalesUnPrcFl = "CmpltSalesUnPrcFl";
        /// <summary> ������z�i�ꎮ�j </summary>
        public const string ct_Col_CmpltSalesMoney = "CmpltSalesMoney";
        /// <summary> �����P���i�ꎮ�j </summary>
        public const string ct_Col_CmpltSalesUnitCost = "CmpltSalesUnitCost";
        /// <summary> �������z�i�ꎮ�j </summary>
        public const string ct_Col_CmpltCost = "CmpltCost";
        /// <summary> �����`�[�ԍ��i�ꎮ�j </summary>
        public const string ct_Col_CmpltPartySalSlNum = "CmpltPartySalSlNum";
        /// <summary> �ꎮ���l </summary>
        public const string ct_Col_CmpltNote = "CmpltNote";
        /// <summary> ����p�i�� </summary>
        public const string ct_Col_PrtGoodsNo = "PrtGoodsNo";
        /// <summary> ����p���[�J�[�R�[�h </summary>
        public const string ct_Col_PrtMakerCode = "PrtMakerCode";
        /// <summary> ����p���[�J�[���� </summary>
        public const string ct_Col_PrtMakerName = "PrtMakerName";
        /// <summary> �o�׍����� </summary>
        public const string ct_Col_ShipmCntDifference = "ShipmCntDifference";
        /// <summary> ���׊֘A�t��GUID </summary>
        public const string ct_Col_DtlRelationGuid = "DtlRelationGuid";
        /// <summary> �݌ɍX�V�敪 </summary>
        public const string ct_Col_StockUpdateDiv = "StockUpdateDiv";

        /// <summary> ����`�[�ԍ��i���j </summary>
        public const string ct_Col_TempSalesSlipNum = "TempSalesSlipNum";
        /// <summary> ���㖾�גʔԁi���j </summary>
        public const string ct_Col_TempSalesSlipDtlNum = "TempSalesSlipDtlNum";


        /// <summary> (����p)��M���� </summary>
        public const string ct_Col_PrtReceiveTime = "PrtReceiveTime";
        /// <summary> (����p)BO�敪 </summary>
        public const string ct_Col_PrtBoCode = "PrtBoCode";
        /// <summary> (����p)�[�i�敪 </summary>
        public const string ct_Col_PrtUOEDeliGoodsDiv = "PrtUOEDeliGoodsDiv";
        /// <summary> (����p)�[�i�敪���� </summary>
        public const string ct_Col_PrtDeliveredGoodsDivNm = "PrtDeliveredGoodsDivNm";
        /// <summary> (����p)�t�H���[�[�i�敪 </summary>
        public const string ct_Col_PrtFollowDeliGoodsDiv = "PrtFollowDeliGoodsDiv";
        /// <summary> (����p)�t�H���[�[�i�敪���� </summary>
        public const string ct_Col_PrtFollowDeliGoodsDivNm = "PrtFollowDeliGoodsDivNm";
        /// <summary>(����p)�󒍐�</summary>
        public const string ct_Col_PrtAcceptAnOrderCnt = "PrtAcceptAnOrderCnt";
        /// <summary>(����p)�o�ɐ�</summary>
        public const string ct_Col_PrtShipmentCnt = "PrtShipmentCnt";
        /// <summary>(����p)���_�o�ɐ�</summary>
        public const string ct_Col_PrtUOESectOutGoodsCnt = "PrtUOESectOutGoodsCnt";
        /// <summary>(����p)BO�o�ɐ�</summary>
        public const string ct_Col_PrtBOShipmentCnt = "PrtBOShipmentCnt";
        /// <summary>���׎��</summary>
        public const string ct_Col_DetailCd = "DetailCd";

        // 2011/01/19 Add >>>
        /// <summary>�L�����y�[���R�[�h</summary>
        public const string ct_Col_CampaignCode = "CampaignCode";
        /// <summary>�L�����y�[������</summary>
        public const string ct_Col_CampaignName = "CampaignName";
        /// <summary>���i���</summary>
        public const string ct_Col_GoodsDivCd = "GoodsDivCd";
        /// <summary>�񓚔[��</summary>
        public const string ct_Col_AnswerDelivDate = "AnswerDelivDate";
        /// <summary>���T�C�N���敪</summary>
        public const string ct_Col_RecycleDiv = "RecycleDiv";
        /// <summary>���T�C�N���敪����</summary>
        public const string ct_Col_RecycleDivNm = "RecycleDivNm";
        /// <summary>�󒍕��@</summary>
        public const string ct_Col_WayToAcptOdr = "WayToAcptOdr";
        // 2011/01/19 Add <<<
        // 2011/07/28 Add >>>
        /// <summary>�����񓚋敪</summary>
        public const string ct_Col_AutoAnswerDivSCM = "AutoAnswerDivSCM";
        // 2011/07/28 Add <<<
        // 2012/01/16 Add >>>
        /// <summary>���L����</summary>
        public const string ct_Col_GoodsSpecialNote = "GoodsSpecialNote";
        // 2012/01/16 Add <<<

        // ADD 2012/12/06 2012/12/12�z�M�\�� SCM��Q��10447�Ή� ----------------------------------->>>>>
        /// <summary>�󔭒����</summary>
        public const string ct_Col_AcceptOrOrderKind = "AcceptOrOrderKind";
        // ADD 2012/12/06 2012/12/12�z�M�\�� SCM��Q��10447�Ή� -----------------------------------<<<<<

        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// ���㖾�׃e�[�u���X�L�[�}�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���㖾�׃e�[�u���X�L�[�}�N���X�̏������y�уC���X�^���X�������s���܂��B</br>
        /// <br>Programmer : 96186�@���ԗT��</br>
        /// <br>Date       : 2008.05.26</br>
        /// </remarks>
        public SalesDetailSchema()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// �f�[�^�Z�b�g�A�f�[�^�e�[�u���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2006.01.21</br>
        /// </remarks>
        public static void SettingDataSet(ref DataSet ds, string dataTableName)
        {
            // �e�[�u�������݂��邩�ǂ������`�F�b�N
            if ((ds.Tables.Contains(dataTableName)))
            {
                // TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
                // �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
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
        /// ���㖾�׍쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 96186 ���ԗT��</br>
        /// <br>Date       : 2008.05.26</br>
        /// </remarks>
        private static void CreateTable(ref DataSet ds, string dataTableName)
        {
            DataTable dt = null;
            // �X�L�[�}�ݒ�
            ds.Tables.Add(dataTableName);
            dt = ds.Tables[dataTableName];

            // �쐬����
            dt.Columns.Add(ct_Col_CreateDateTime, typeof(Int64));
            dt.Columns[ct_Col_CreateDateTime].DefaultValue = defValueInt64;
            // �X�V����
            dt.Columns.Add(ct_Col_UpdateDateTime, typeof(Int64));
            dt.Columns[ct_Col_UpdateDateTime].DefaultValue = defValueInt64;
            // ��ƃR�[�h
            dt.Columns.Add(ct_Col_EnterpriseCode, typeof(string));
            dt.Columns[ct_Col_EnterpriseCode].DefaultValue = defValuestring;
            // GUID
            dt.Columns.Add(ct_Col_FileHeaderGuid, typeof(Guid));
            dt.Columns[ct_Col_FileHeaderGuid].DefaultValue = Guid.Empty;
            // �X�V�]�ƈ��R�[�h
            dt.Columns.Add(ct_Col_UpdEmployeeCode, typeof(string));
            dt.Columns[ct_Col_UpdEmployeeCode].DefaultValue = defValuestring;
            // �X�V�A�Z���u��ID1
            dt.Columns.Add(ct_Col_UpdAssemblyId1, typeof(string));
            dt.Columns[ct_Col_UpdAssemblyId1].DefaultValue = defValuestring;
            // �X�V�A�Z���u��ID2
            dt.Columns.Add(ct_Col_UpdAssemblyId2, typeof(string));
            dt.Columns[ct_Col_UpdAssemblyId2].DefaultValue = defValuestring;
            // �_���폜�敪
            dt.Columns.Add(ct_Col_LogicalDeleteCode, typeof(Int32));
            dt.Columns[ct_Col_LogicalDeleteCode].DefaultValue = defValueInt32;
            // �󒍔ԍ�
            dt.Columns.Add(ct_Col_AcceptAnOrderNo, typeof(Int32));
            dt.Columns[ct_Col_AcceptAnOrderNo].DefaultValue = defValueInt32;
            // �󒍃X�e�[�^�X
            dt.Columns.Add(ct_Col_AcptAnOdrStatus, typeof(Int32));
            dt.Columns[ct_Col_AcptAnOdrStatus].DefaultValue = defValueInt32;
            // ����`�[�ԍ�
            dt.Columns.Add(ct_Col_SalesSlipNum, typeof(string));
            dt.Columns[ct_Col_SalesSlipNum].DefaultValue = defValuestring;
            // ����s�ԍ�
            dt.Columns.Add(ct_Col_SalesRowNo, typeof(Int32));
            dt.Columns[ct_Col_SalesRowNo].DefaultValue = defValueInt32;
            // ����s�ԍ��}��
            dt.Columns.Add(ct_Col_SalesRowDerivNo, typeof(Int32));
            dt.Columns[ct_Col_SalesRowDerivNo].DefaultValue = defValueInt32;
            // ���_�R�[�h
            dt.Columns.Add(ct_Col_SectionCode, typeof(string));
            dt.Columns[ct_Col_SectionCode].DefaultValue = defValuestring;
            // ����R�[�h
            dt.Columns.Add(ct_Col_SubSectionCode, typeof(Int32));
            dt.Columns[ct_Col_SubSectionCode].DefaultValue = defValueInt32;
            // ������t
            dt.Columns.Add(ct_Col_SalesDate, typeof(DateTime));
            dt.Columns[ct_Col_SalesDate].DefaultValue = DateTime.MinValue;
            // ���ʒʔ�
            dt.Columns.Add(ct_Col_CommonSeqNo, typeof(Int64));
            dt.Columns[ct_Col_CommonSeqNo].DefaultValue = defValueInt64;
            // ���㖾�גʔ�
            dt.Columns.Add(ct_Col_SalesSlipDtlNum, typeof(Int64));
            dt.Columns[ct_Col_SalesSlipDtlNum].DefaultValue = defValueInt64;
            // �󒍃X�e�[�^�X�i���j
            dt.Columns.Add(ct_Col_AcptAnOdrStatusSrc, typeof(Int32));
            dt.Columns[ct_Col_AcptAnOdrStatusSrc].DefaultValue = defValueInt32;
            // ���㖾�גʔԁi���j
            dt.Columns.Add(ct_Col_SalesSlipDtlNumSrc, typeof(Int64));
            dt.Columns[ct_Col_SalesSlipDtlNumSrc].DefaultValue = defValueInt64;
            // �d���`���i�����j
            dt.Columns.Add(ct_Col_SupplierFormalSync, typeof(Int32));
            dt.Columns[ct_Col_SupplierFormalSync].DefaultValue = defValueInt32;
            // �d�����גʔԁi�����j
            dt.Columns.Add(ct_Col_StockSlipDtlNumSync, typeof(Int64));
            dt.Columns[ct_Col_StockSlipDtlNumSync].DefaultValue = defValueInt64;
            // ����`�[�敪�i���ׁj
            dt.Columns.Add(ct_Col_SalesSlipCdDtl, typeof(Int32));
            dt.Columns[ct_Col_SalesSlipCdDtl].DefaultValue = defValueInt32;
            // �[�i�����\���
            dt.Columns.Add(ct_Col_DeliGdsCmpltDueDate, typeof(DateTime));
            dt.Columns[ct_Col_DeliGdsCmpltDueDate].DefaultValue = DateTime.MinValue;
            // ���i����
            dt.Columns.Add(ct_Col_GoodsKindCode, typeof(Int32));
            dt.Columns[ct_Col_GoodsKindCode].DefaultValue = defValueInt32;
            // ���i�����敪
            dt.Columns.Add(ct_Col_GoodsSearchDivCd, typeof(Int32));
            dt.Columns[ct_Col_GoodsSearchDivCd].DefaultValue = defValueInt32;
            // ���i���[�J�[�R�[�h
            dt.Columns.Add(ct_Col_GoodsMakerCd, typeof(Int32));
            dt.Columns[ct_Col_GoodsMakerCd].DefaultValue = defValueInt32;
            // ���[�J�[����
            dt.Columns.Add(ct_Col_MakerName, typeof(string));
            dt.Columns[ct_Col_MakerName].DefaultValue = defValuestring;
            // ���[�J�[�J�i����
            dt.Columns.Add(ct_Col_MakerKanaName, typeof(string));
            dt.Columns[ct_Col_MakerKanaName].DefaultValue = defValuestring;
            // ���i�ԍ�
            dt.Columns.Add(ct_Col_GoodsNo, typeof(string));
            dt.Columns[ct_Col_GoodsNo].DefaultValue = defValuestring;
            // ���i����
            dt.Columns.Add(ct_Col_GoodsName, typeof(string));
            dt.Columns[ct_Col_GoodsName].DefaultValue = defValuestring;
            // ���i���̃J�i
            dt.Columns.Add(ct_Col_GoodsNameKana, typeof(string));
            dt.Columns[ct_Col_GoodsNameKana].DefaultValue = defValuestring;
            // ���i�啪�ރR�[�h
            dt.Columns.Add(ct_Col_GoodsLGroup, typeof(Int32));
            dt.Columns[ct_Col_GoodsLGroup].DefaultValue = defValueInt32;
            // ���i�啪�ޖ���
            dt.Columns.Add(ct_Col_GoodsLGroupName, typeof(string));
            dt.Columns[ct_Col_GoodsLGroupName].DefaultValue = defValuestring;
            // ���i�����ރR�[�h
            dt.Columns.Add(ct_Col_GoodsMGroup, typeof(Int32));
            dt.Columns[ct_Col_GoodsMGroup].DefaultValue = defValueInt32;
            // ���i�����ޖ���
            dt.Columns.Add(ct_Col_GoodsMGroupName, typeof(string));
            dt.Columns[ct_Col_GoodsMGroupName].DefaultValue = defValuestring;
            // BL�O���[�v�R�[�h
            dt.Columns.Add(ct_Col_BLGroupCode, typeof(Int32));
            dt.Columns[ct_Col_BLGroupCode].DefaultValue = defValueInt32;
            // BL�O���[�v�R�[�h����
            dt.Columns.Add(ct_Col_BLGroupName, typeof(string));
            dt.Columns[ct_Col_BLGroupName].DefaultValue = defValuestring;
            // BL���i�R�[�h
            dt.Columns.Add(ct_Col_BLGoodsCode, typeof(Int32));
            dt.Columns[ct_Col_BLGoodsCode].DefaultValue = defValueInt32;
            // BL���i�R�[�h���́i�S�p�j
            dt.Columns.Add(ct_Col_BLGoodsFullName, typeof(string));
            dt.Columns[ct_Col_BLGoodsFullName].DefaultValue = defValuestring;
            // ���Е��ރR�[�h
            dt.Columns.Add(ct_Col_EnterpriseGanreCode, typeof(Int32));
            dt.Columns[ct_Col_EnterpriseGanreCode].DefaultValue = defValueInt32;
            // ���Е��ޖ���
            dt.Columns.Add(ct_Col_EnterpriseGanreName, typeof(string));
            dt.Columns[ct_Col_EnterpriseGanreName].DefaultValue = defValuestring;
            // �q�ɃR�[�h
            dt.Columns.Add(ct_Col_WarehouseCode, typeof(string));
            dt.Columns[ct_Col_WarehouseCode].DefaultValue = defValuestring;
            // �q�ɖ���
            dt.Columns.Add(ct_Col_WarehouseName, typeof(string));
            dt.Columns[ct_Col_WarehouseName].DefaultValue = defValuestring;
            // �q�ɒI��
            dt.Columns.Add(ct_Col_WarehouseShelfNo, typeof(string));
            dt.Columns[ct_Col_WarehouseShelfNo].DefaultValue = defValuestring;
            // ����݌Ɏ�񂹋敪
            dt.Columns.Add(ct_Col_SalesOrderDivCd, typeof(Int32));
            dt.Columns[ct_Col_SalesOrderDivCd].DefaultValue = defValueInt32;
            // �I�[�v�����i�敪
            dt.Columns.Add(ct_Col_OpenPriceDiv, typeof(Int32));
            dt.Columns[ct_Col_OpenPriceDiv].DefaultValue = defValueInt32;
            // ���i�|�������N
            dt.Columns.Add(ct_Col_GoodsRateRank, typeof(string));
            dt.Columns[ct_Col_GoodsRateRank].DefaultValue = defValuestring;
            // ���Ӑ�|���O���[�v�R�[�h
            dt.Columns.Add(ct_Col_CustRateGrpCode, typeof(Int32));
            dt.Columns[ct_Col_CustRateGrpCode].DefaultValue = defValueInt32;
            // �艿��
            dt.Columns.Add(ct_Col_ListPriceRate, typeof(Double));
            dt.Columns[ct_Col_ListPriceRate].DefaultValue = defValueDouble;
            // �|���ݒ苒�_�i�艿�j
            dt.Columns.Add(ct_Col_RateSectPriceUnPrc, typeof(string));
            dt.Columns[ct_Col_RateSectPriceUnPrc].DefaultValue = defValuestring;
            // �|���ݒ�敪�i�艿�j
            dt.Columns.Add(ct_Col_RateDivLPrice, typeof(string));
            dt.Columns[ct_Col_RateDivLPrice].DefaultValue = defValuestring;
            // �P���Z�o�敪�i�艿�j
            dt.Columns.Add(ct_Col_UnPrcCalcCdLPrice, typeof(Int32));
            dt.Columns[ct_Col_UnPrcCalcCdLPrice].DefaultValue = defValueInt32;
            // ���i�敪�i�艿�j
            dt.Columns.Add(ct_Col_PriceCdLPrice, typeof(Int32));
            dt.Columns[ct_Col_PriceCdLPrice].DefaultValue = defValueInt32;
            // ��P���i�艿�j
            dt.Columns.Add(ct_Col_StdUnPrcLPrice, typeof(Double));
            dt.Columns[ct_Col_StdUnPrcLPrice].DefaultValue = defValueDouble;
            // �[�������P�ʁi�艿�j
            dt.Columns.Add(ct_Col_FracProcUnitLPrice, typeof(Double));
            dt.Columns[ct_Col_FracProcUnitLPrice].DefaultValue = defValueDouble;
            // �[�������i�艿�j
            dt.Columns.Add(ct_Col_FracProcLPrice, typeof(Int32));
            dt.Columns[ct_Col_FracProcLPrice].DefaultValue = defValueInt32;
            // �艿�i�ō��C�����j
            dt.Columns.Add(ct_Col_ListPriceTaxIncFl, typeof(Double));
            dt.Columns[ct_Col_ListPriceTaxIncFl].DefaultValue = defValueDouble;
            // �艿�i�Ŕ��C�����j
            dt.Columns.Add(ct_Col_ListPriceTaxExcFl, typeof(Double));
            dt.Columns[ct_Col_ListPriceTaxExcFl].DefaultValue = defValueDouble;
            // �艿�ύX�敪
            dt.Columns.Add(ct_Col_ListPriceChngCd, typeof(Int32));
            dt.Columns[ct_Col_ListPriceChngCd].DefaultValue = defValueInt32;
            // ������
            dt.Columns.Add(ct_Col_SalesRate, typeof(Double));
            dt.Columns[ct_Col_SalesRate].DefaultValue = defValueDouble;
            // �|���ݒ苒�_�i����P���j
            dt.Columns.Add(ct_Col_RateSectSalUnPrc, typeof(string));
            dt.Columns[ct_Col_RateSectSalUnPrc].DefaultValue = defValuestring;
            // �|���ݒ�敪�i����P���j
            dt.Columns.Add(ct_Col_RateDivSalUnPrc, typeof(string));
            dt.Columns[ct_Col_RateDivSalUnPrc].DefaultValue = defValuestring;
            // �P���Z�o�敪�i����P���j
            dt.Columns.Add(ct_Col_UnPrcCalcCdSalUnPrc, typeof(Int32));
            dt.Columns[ct_Col_UnPrcCalcCdSalUnPrc].DefaultValue = defValueInt32;
            // ���i�敪�i����P���j
            dt.Columns.Add(ct_Col_PriceCdSalUnPrc, typeof(Int32));
            dt.Columns[ct_Col_PriceCdSalUnPrc].DefaultValue = defValueInt32;
            // ��P���i����P���j
            dt.Columns.Add(ct_Col_StdUnPrcSalUnPrc, typeof(Double));
            dt.Columns[ct_Col_StdUnPrcSalUnPrc].DefaultValue = defValueDouble;
            // �[�������P�ʁi����P���j
            dt.Columns.Add(ct_Col_FracProcUnitSalUnPrc, typeof(Double));
            dt.Columns[ct_Col_FracProcUnitSalUnPrc].DefaultValue = defValueDouble;
            // �[�������i����P���j
            dt.Columns.Add(ct_Col_FracProcSalUnPrc, typeof(Int32));
            dt.Columns[ct_Col_FracProcSalUnPrc].DefaultValue = defValueInt32;
            // ����P���i�ō��C�����j
            dt.Columns.Add(ct_Col_SalesUnPrcTaxIncFl, typeof(Double));
            dt.Columns[ct_Col_SalesUnPrcTaxIncFl].DefaultValue = defValueDouble;
            // ����P���i�Ŕ��C�����j
            dt.Columns.Add(ct_Col_SalesUnPrcTaxExcFl, typeof(Double));
            dt.Columns[ct_Col_SalesUnPrcTaxExcFl].DefaultValue = defValueDouble;
            // ����P���ύX�敪
            dt.Columns.Add(ct_Col_SalesUnPrcChngCd, typeof(Int32));
            dt.Columns[ct_Col_SalesUnPrcChngCd].DefaultValue = defValueInt32;
            // ������
            dt.Columns.Add(ct_Col_CostRate, typeof(Double));
            dt.Columns[ct_Col_CostRate].DefaultValue = defValueDouble;
            // �|���ݒ苒�_�i�����P���j
            dt.Columns.Add(ct_Col_RateSectCstUnPrc, typeof(string));
            dt.Columns[ct_Col_RateSectCstUnPrc].DefaultValue = defValuestring;
            // �|���ݒ�敪�i�����P���j
            dt.Columns.Add(ct_Col_RateDivUnCst, typeof(string));
            dt.Columns[ct_Col_RateDivUnCst].DefaultValue = defValuestring;
            // �P���Z�o�敪�i�����P���j
            dt.Columns.Add(ct_Col_UnPrcCalcCdUnCst, typeof(Int32));
            dt.Columns[ct_Col_UnPrcCalcCdUnCst].DefaultValue = defValueInt32;
            // ���i�敪�i�����P���j
            dt.Columns.Add(ct_Col_PriceCdUnCst, typeof(Int32));
            dt.Columns[ct_Col_PriceCdUnCst].DefaultValue = defValueInt32;
            // ��P���i�����P���j
            dt.Columns.Add(ct_Col_StdUnPrcUnCst, typeof(Double));
            dt.Columns[ct_Col_StdUnPrcUnCst].DefaultValue = defValueDouble;
            // �[�������P�ʁi�����P���j
            dt.Columns.Add(ct_Col_FracProcUnitUnCst, typeof(Double));
            dt.Columns[ct_Col_FracProcUnitUnCst].DefaultValue = defValueDouble;
            // �[�������i�����P���j
            dt.Columns.Add(ct_Col_FracProcUnCst, typeof(Int32));
            dt.Columns[ct_Col_FracProcUnCst].DefaultValue = defValueInt32;
            // �����P��
            dt.Columns.Add(ct_Col_SalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_SalesUnitCost].DefaultValue = defValueDouble;
            // �����P���ύX�敪
            dt.Columns.Add(ct_Col_SalesUnitCostChngDiv, typeof(Int32));
            dt.Columns[ct_Col_SalesUnitCostChngDiv].DefaultValue = defValueInt32;
            // BL���i�R�[�h�i�|���j
            dt.Columns.Add(ct_Col_RateBLGoodsCode, typeof(Int32));
            dt.Columns[ct_Col_RateBLGoodsCode].DefaultValue = defValueInt32;
            // BL���i�R�[�h���́i�|���j
            dt.Columns.Add(ct_Col_RateBLGoodsName, typeof(string));
            dt.Columns[ct_Col_RateBLGoodsName].DefaultValue = defValuestring;
            // ���i�|���O���[�v�R�[�h�i�|���j
            dt.Columns.Add(ct_Col_RateGoodsRateGrpCd, typeof(Int32));
            dt.Columns[ct_Col_RateGoodsRateGrpCd].DefaultValue = defValueInt32;
            // ���i�|���O���[�v���́i�|���j
            dt.Columns.Add(ct_Col_RateGoodsRateGrpNm, typeof(string));
            dt.Columns[ct_Col_RateGoodsRateGrpNm].DefaultValue = defValuestring;
            // BL�O���[�v�R�[�h�i�|���j
            dt.Columns.Add(ct_Col_RateBLGroupCode, typeof(Int32));
            dt.Columns[ct_Col_RateBLGroupCode].DefaultValue = defValueInt32;
            // BL�O���[�v���́i�|���j
            dt.Columns.Add(ct_Col_RateBLGroupName, typeof(string));
            dt.Columns[ct_Col_RateBLGroupName].DefaultValue = defValuestring;
            // BL���i�R�[�h�i����j
            dt.Columns.Add(ct_Col_PrtBLGoodsCode, typeof(Int32));
            dt.Columns[ct_Col_PrtBLGoodsCode].DefaultValue = defValueInt32;
            // BL���i�R�[�h���́i����j
            dt.Columns.Add(ct_Col_PrtBLGoodsName, typeof(string));
            dt.Columns[ct_Col_PrtBLGoodsName].DefaultValue = defValuestring;
            // �̔��敪�R�[�h
            dt.Columns.Add(ct_Col_SalesCode, typeof(Int32));
            dt.Columns[ct_Col_SalesCode].DefaultValue = defValueInt32;
            // �̔��敪����
            dt.Columns.Add(ct_Col_SalesCdNm, typeof(string));
            dt.Columns[ct_Col_SalesCdNm].DefaultValue = defValuestring;
            // ��ƍH��
            dt.Columns.Add(ct_Col_WorkManHour, typeof(Double));
            dt.Columns[ct_Col_WorkManHour].DefaultValue = defValueDouble;
            // �o�א�
            dt.Columns.Add(ct_Col_ShipmentCnt, typeof(Double));
            dt.Columns[ct_Col_ShipmentCnt].DefaultValue = defValueDouble;
            // �󒍐���
            dt.Columns.Add(ct_Col_AcceptAnOrderCnt, typeof(Double));
            dt.Columns[ct_Col_AcceptAnOrderCnt].DefaultValue = defValueDouble;
            // �󒍒�����
            dt.Columns.Add(ct_Col_AcptAnOdrAdjustCnt, typeof(Double));
            dt.Columns[ct_Col_AcptAnOdrAdjustCnt].DefaultValue = defValueDouble;
            // �󒍎c��
            dt.Columns.Add(ct_Col_AcptAnOdrRemainCnt, typeof(Double));
            dt.Columns[ct_Col_AcptAnOdrRemainCnt].DefaultValue = defValueDouble;
            // �c���X�V��
            dt.Columns.Add(ct_Col_RemainCntUpdDate, typeof(DateTime));
            dt.Columns[ct_Col_RemainCntUpdDate].DefaultValue = DateTime.MinValue;
            // ������z�i�ō��݁j
            dt.Columns.Add(ct_Col_SalesMoneyTaxInc, typeof(Int64));
            dt.Columns[ct_Col_SalesMoneyTaxInc].DefaultValue = defValueInt64;
            // ������z�i�Ŕ����j
            dt.Columns.Add(ct_Col_SalesMoneyTaxExc, typeof(Int64));
            dt.Columns[ct_Col_SalesMoneyTaxExc].DefaultValue = defValueInt64;
            // ����
            dt.Columns.Add(ct_Col_Cost, typeof(Int64));
            dt.Columns[ct_Col_Cost].DefaultValue = defValueInt64;
            // �e���`�F�b�N�敪
            dt.Columns.Add(ct_Col_GrsProfitChkDiv, typeof(Int32));
            dt.Columns[ct_Col_GrsProfitChkDiv].DefaultValue = defValueInt32;
            // ���㏤�i�敪
            dt.Columns.Add(ct_Col_SalesGoodsCd, typeof(Int32));
            dt.Columns[ct_Col_SalesGoodsCd].DefaultValue = defValueInt32;
            // ������z����Ŋz
            dt.Columns.Add(ct_Col_SalesPriceConsTax, typeof(Int64));
            dt.Columns[ct_Col_SalesPriceConsTax].DefaultValue = defValueInt64;
            // �ېŋ敪
            dt.Columns.Add(ct_Col_TaxationDivCd, typeof(Int32));
            dt.Columns[ct_Col_TaxationDivCd].DefaultValue = defValueInt32;
            // �����`�[�ԍ��i���ׁj
            dt.Columns.Add(ct_Col_PartySlipNumDtl, typeof(string));
            dt.Columns[ct_Col_PartySlipNumDtl].DefaultValue = defValuestring;
            // ���ה��l
            dt.Columns.Add(ct_Col_DtlNote, typeof(string));
            dt.Columns[ct_Col_DtlNote].DefaultValue = defValuestring;
            // �d����R�[�h
            dt.Columns.Add(ct_Col_SupplierCd, typeof(Int32));
            dt.Columns[ct_Col_SupplierCd].DefaultValue = defValueInt32;
            // �d���旪��
            dt.Columns.Add(ct_Col_SupplierSnm, typeof(string));
            dt.Columns[ct_Col_SupplierSnm].DefaultValue = defValuestring;
            // �����ԍ�
            dt.Columns.Add(ct_Col_OrderNumber, typeof(string));
            dt.Columns[ct_Col_OrderNumber].DefaultValue = defValuestring;
            // �������@
            dt.Columns.Add(ct_Col_WayToOrder, typeof(Int32));
            dt.Columns[ct_Col_WayToOrder].DefaultValue = defValueInt32;
            // �`�[�����P
            dt.Columns.Add(ct_Col_SlipMemo1, typeof(string));
            dt.Columns[ct_Col_SlipMemo1].DefaultValue = defValuestring;
            // �`�[�����Q
            dt.Columns.Add(ct_Col_SlipMemo2, typeof(string));
            dt.Columns[ct_Col_SlipMemo2].DefaultValue = defValuestring;
            // �`�[�����R
            dt.Columns.Add(ct_Col_SlipMemo3, typeof(string));
            dt.Columns[ct_Col_SlipMemo3].DefaultValue = defValuestring;
            // �Г������P
            dt.Columns.Add(ct_Col_InsideMemo1, typeof(string));
            dt.Columns[ct_Col_InsideMemo1].DefaultValue = defValuestring;
            // �Г������Q
            dt.Columns.Add(ct_Col_InsideMemo2, typeof(string));
            dt.Columns[ct_Col_InsideMemo2].DefaultValue = defValuestring;
            // �Г������R
            dt.Columns.Add(ct_Col_InsideMemo3, typeof(string));
            dt.Columns[ct_Col_InsideMemo3].DefaultValue = defValuestring;
            // �ύX�O�艿
            dt.Columns.Add(ct_Col_BfListPrice, typeof(Double));
            dt.Columns[ct_Col_BfListPrice].DefaultValue = defValueDouble;
            // �ύX�O����
            dt.Columns.Add(ct_Col_BfSalesUnitPrice, typeof(Double));
            dt.Columns[ct_Col_BfSalesUnitPrice].DefaultValue = defValueDouble;
            // �ύX�O����
            dt.Columns.Add(ct_Col_BfUnitCost, typeof(Double));
            dt.Columns[ct_Col_BfUnitCost].DefaultValue = defValueDouble;
            // �ꎮ���הԍ�
            dt.Columns.Add(ct_Col_CmpltSalesRowNo, typeof(Int32));
            dt.Columns[ct_Col_CmpltSalesRowNo].DefaultValue = defValueInt32;
            // ���[�J�[�R�[�h�i�ꎮ�j
            dt.Columns.Add(ct_Col_CmpltGoodsMakerCd, typeof(Int32));
            dt.Columns[ct_Col_CmpltGoodsMakerCd].DefaultValue = defValueInt32;
            // ���[�J�[���́i�ꎮ�j
            dt.Columns.Add(ct_Col_CmpltMakerName, typeof(string));
            dt.Columns[ct_Col_CmpltMakerName].DefaultValue = defValuestring;
            // ���[�J�[�J�i���́i�ꎮ�j
            dt.Columns.Add(ct_Col_CmpltMakerKanaName, typeof(string));
            dt.Columns[ct_Col_CmpltMakerKanaName].DefaultValue = defValuestring;
            // ���i���́i�ꎮ�j
            dt.Columns.Add(ct_Col_CmpltGoodsName, typeof(string));
            dt.Columns[ct_Col_CmpltGoodsName].DefaultValue = defValuestring;
            // ���ʁi�ꎮ�j
            dt.Columns.Add(ct_Col_CmpltShipmentCnt, typeof(Double));
            dt.Columns[ct_Col_CmpltShipmentCnt].DefaultValue = defValueDouble;
            // ����P���i�ꎮ�j
            dt.Columns.Add(ct_Col_CmpltSalesUnPrcFl, typeof(Double));
            dt.Columns[ct_Col_CmpltSalesUnPrcFl].DefaultValue = defValueDouble;
            // ������z�i�ꎮ�j
            dt.Columns.Add(ct_Col_CmpltSalesMoney, typeof(Int64));
            dt.Columns[ct_Col_CmpltSalesMoney].DefaultValue = defValueInt64;
            // �����P���i�ꎮ�j
            dt.Columns.Add(ct_Col_CmpltSalesUnitCost, typeof(Double));
            dt.Columns[ct_Col_CmpltSalesUnitCost].DefaultValue = defValueDouble;
            // �������z�i�ꎮ�j
            dt.Columns.Add(ct_Col_CmpltCost, typeof(Int64));
            dt.Columns[ct_Col_CmpltCost].DefaultValue = defValueInt64;
            // �����`�[�ԍ��i�ꎮ�j
            dt.Columns.Add(ct_Col_CmpltPartySalSlNum, typeof(string));
            dt.Columns[ct_Col_CmpltPartySalSlNum].DefaultValue = defValuestring;
            // �ꎮ���l
            dt.Columns.Add(ct_Col_CmpltNote, typeof(string));
            dt.Columns[ct_Col_CmpltNote].DefaultValue = defValuestring;
            // ����p�i��
            dt.Columns.Add(ct_Col_PrtGoodsNo, typeof(string));
            dt.Columns[ct_Col_PrtGoodsNo].DefaultValue = defValuestring;
            // ����p���[�J�[�R�[�h
            dt.Columns.Add(ct_Col_PrtMakerCode, typeof(Int32));
            dt.Columns[ct_Col_PrtMakerCode].DefaultValue = defValueInt32;
            // ����p���[�J�[����
            dt.Columns.Add(ct_Col_PrtMakerName, typeof(string));
            dt.Columns[ct_Col_PrtMakerName].DefaultValue = defValuestring;
            // �o�׍�����
            dt.Columns.Add(ct_Col_ShipmCntDifference, typeof(Double));
            dt.Columns[ct_Col_ShipmCntDifference].DefaultValue = defValueDouble;
            // ���׊֘A�t��GUID
            dt.Columns.Add(ct_Col_DtlRelationGuid, typeof(Guid));
            dt.Columns[ct_Col_DtlRelationGuid].DefaultValue = Guid.Empty;

            // ����`�[�ԍ��i���j
            dt.Columns.Add(ct_Col_TempSalesSlipNum, typeof(string));
            dt.Columns[ct_Col_TempSalesSlipNum].DefaultValue = defValuestring;
            // ���㖾�גʔԁi���j
            dt.Columns.Add(ct_Col_TempSalesSlipDtlNum, typeof(Int64));
            dt.Columns[ct_Col_TempSalesSlipDtlNum].DefaultValue = defValueInt64;

            // (����p) BO�敪
            dt.Columns.Add(ct_Col_PrtReceiveTime, typeof(Int32));
            dt.Columns[ct_Col_PrtReceiveTime].DefaultValue = defValueInt32;
            // (����p) BO�敪
            dt.Columns.Add(ct_Col_PrtBoCode, typeof(string));
            dt.Columns[ct_Col_PrtBoCode].DefaultValue = defValuestring;
            // (����p)�[�i�敪
            dt.Columns.Add(ct_Col_PrtUOEDeliGoodsDiv, typeof(string));
            dt.Columns[ct_Col_PrtUOEDeliGoodsDiv].DefaultValue = defValuestring;
            // (����p)�[�i�敪����
            dt.Columns.Add(ct_Col_PrtDeliveredGoodsDivNm, typeof(string));
            dt.Columns[ct_Col_PrtDeliveredGoodsDivNm].DefaultValue = defValuestring;
            // (����p)�t�H���[�[�i�敪
            dt.Columns.Add(ct_Col_PrtFollowDeliGoodsDiv, typeof(string));
            dt.Columns[ct_Col_PrtFollowDeliGoodsDiv].DefaultValue = defValuestring;
            // (����p)�t�H���[�[�i�敪����
            dt.Columns.Add(ct_Col_PrtFollowDeliGoodsDivNm, typeof(string));
            dt.Columns[ct_Col_PrtFollowDeliGoodsDivNm].DefaultValue = defValuestring;
            //(����p)�󒍐�
            dt.Columns.Add(ct_Col_PrtAcceptAnOrderCnt, typeof(Double));
            dt.Columns[ct_Col_PrtAcceptAnOrderCnt].DefaultValue = defValueDouble;
            //(����p)�o�ɐ�
            dt.Columns.Add(ct_Col_PrtShipmentCnt, typeof(Int32));
            dt.Columns[ct_Col_PrtShipmentCnt].DefaultValue = defValueInt32;
            //(����p)���_�o�ɐ�
            dt.Columns.Add(ct_Col_PrtUOESectOutGoodsCnt, typeof(Int32));
            dt.Columns[ct_Col_PrtUOESectOutGoodsCnt].DefaultValue = defValueInt32;
            //(����p)BO�o�ɐ�
            dt.Columns.Add(ct_Col_PrtBOShipmentCnt, typeof(Int32));
            dt.Columns[ct_Col_PrtBOShipmentCnt].DefaultValue = defValueInt32;
            //���׎��
            dt.Columns.Add(ct_Col_DetailCd, typeof(Int32));
            dt.Columns[ct_Col_DetailCd].DefaultValue = defValueInt32;

            // 2011/01/19 Add >>>
            //�L�����y�[���R�[�h
            dt.Columns.Add(ct_Col_CampaignCode, typeof(Int32));
            dt.Columns[ct_Col_CampaignCode].DefaultValue = defValueInt32;
            //�L�����y�[������
            dt.Columns.Add(ct_Col_CampaignName, typeof(string));
            dt.Columns[ct_Col_CampaignName].DefaultValue = defValuestring;
            //���i���
            dt.Columns.Add(ct_Col_GoodsDivCd, typeof(Int32));
            dt.Columns[ct_Col_GoodsDivCd].DefaultValue = defValueInt32;
            //�񓚔[��
            dt.Columns.Add(ct_Col_AnswerDelivDate, typeof(string));
            dt.Columns[ct_Col_AnswerDelivDate].DefaultValue = defValuestring;
            //���T�C�N���敪
            dt.Columns.Add(ct_Col_RecycleDiv, typeof(Int32));
            dt.Columns[ct_Col_RecycleDiv].DefaultValue = defValueInt32;
            //���T�C�N���敪����
            dt.Columns.Add(ct_Col_RecycleDivNm, typeof(string));
            dt.Columns[ct_Col_RecycleDivNm].DefaultValue = defValuestring;
            //�󒍕��@
            dt.Columns.Add(ct_Col_WayToAcptOdr, typeof(Int32));
            dt.Columns[ct_Col_WayToAcptOdr].DefaultValue = defValueInt32;
            // 2011/01/19 Add <<<
            // 2011/07/28 Add >>>
            //�����񓚋敪
            dt.Columns.Add(ct_Col_AutoAnswerDivSCM, typeof(Int32));
            dt.Columns[ct_Col_AutoAnswerDivSCM].DefaultValue = defValueInt32;
            // 2011/07/28 Add <<<
            // 2012/01/16 Add >>>
            //���L����
            dt.Columns.Add(ct_Col_GoodsSpecialNote, typeof(string));
            dt.Columns[ct_Col_GoodsSpecialNote].DefaultValue = defValuestring;
            // 2012/01/16 Add <<<

            // ADD 2012/12/06 2012/12/12�z�M�\�� SCM��Q��10447�Ή� ----------------------------------->>>>>
            dt.Columns.Add(ct_Col_AcceptOrOrderKind, typeof(short));
            dt.Columns[ct_Col_AcceptOrOrderKind].DefaultValue = defValueShort;
            // ADD 2012/12/06 2012/12/12�z�M�\�� SCM��Q��10447�Ή� -----------------------------------<<<<<

            //PrimaryKey�̐ݒ�
            //���㖾�׃e�[�u��
            //�󒍃X�e�[�^�X�{���׊֘A�t��GUID
            if (dataTableName == CT_SalesDetailDataTable)
            {
                dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_AcptAnOdrStatus], dt.Columns[ct_Col_DtlRelationGuid] };
            }
            //�󒍖��׃e�[�u��
            //�󒍃X�e�[�^�X�{���㖾�גʔ�
            else
            {
                dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_AcptAnOdrStatus], dt.Columns[ct_Col_SalesSlipDtlNum] };
            }

        }
        #endregion
    }
}