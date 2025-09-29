//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/05/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/05/26  �C�����e : �e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2011/02/09  �C�����e :�e�[�u�����C�A�E�g�ύX�Ή�(���׎捞�敪�̒ǉ�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018�@��� ���b
// �� �� ��  2011/05/23  �C�����e : �e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/08/10  �C�����e : PCCUOE�����񓚑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10800003-00 �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2012/01/16  �C�����e : SCM���ǑΉ��E���L�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 20073 �� �B
// �� �� ��  2012/05/30  �C�����e : SCM���ǑΉ��E�������ϕ��i�R�[�h
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30745 �g��
// �� �� ��  2013/05/08  �C�����e : 2013/06/18�z�M�@SCM��Q��10308,��10528
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30745 �g��
// �� �� ��  2013/05/15  �C�����e : 2013/06/18�z�M�@SCM��Q��10410
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �C �� ��  2014/06/04  �C�����e : SCM�d�|�ꗗ��10659�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2014/12/19  �C�����e : SCM������ PMNS�Ή� ���ڒǉ��@�ݏo�敪�A���[�J�[��]�������i�A�I�[�v�����i�敪
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 31065 �L�� ���O
// �C �� ��  2015/01/19  �C�����e : ���R�����h�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2015/01/30  �C�����e : SCM������ ���Y�N���A�ԑ�ԍ��Ή��@���ڒǉ��@�^���ʕ��i�̗p�N���A�^���ʕ��i�p�~�N���A�^���ʕ��i�̗p�ԑ�ԍ��A�^���ʕ��i�p�~�ԑ�ԍ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30745 �g��
// �C �� ��  2015/02/10  �C�����e : SCM������ �񓚔[���敪�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30746 ���� ��
// �C �� ��  2015/02/20  �C�����e : SCM������ C������ʁE���L�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470007-00 �쐬�S�� : �c����
// �C �� ��  2018/04/16  �C�����e : SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Application.UIData.WebDB;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Library.Text;   // 2010/05/26 Add

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdDtInq;

    /// <summary>
    /// ���[�U�[DB SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h�N���X
    /// </summary>
    public class UserSCMOrderDetailRecord : UserSCMOrderDetailWrapper
    {
        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public UserSCMOrderDetailRecord() : base() { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realRecord">�{���̃��R�[�h</param>
        public UserSCMOrderDetailRecord(RecordType realRecord) : base(realRecord) { }

        #endregion // </Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^(Web��User�ϊ�)
        /// </summary>
        /// <param name="webRecord">SCM�󔭒����׃f�[�^(�⍇���E����)</param>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
        /// </remarks>
        public UserSCMOrderDetailRecord(WebSCMOrderDetailRecord webRecord) : base(new RecordType())
        {
            RealRecord.CreateDateTime = webRecord.CreateDateTime; // �쐬����
            RealRecord.UpdateDateTime = webRecord.UpdateDateTime; // �X�V����
            RealRecord.EnterpriseCode = webRecord.EnterpriseCode; // ��ƃR�[�h
            //RealRecord.FileHeaderGuid = webRecord.FileHeaderGuid; // GUID
            //RealRecord.UpdEmployeeCode = webRecord.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            //RealRecord.UpdAssemblyId1 = webRecord.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            //RealRecord.UpdAssemblyId2 = webRecord.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            RealRecord.LogicalDeleteCode = webRecord.LogicalDeleteCode; // �_���폜�敪
            RealRecord.InqOriginalEpCd = webRecord.InqOriginalEpCd.Trim(); // �⍇������ƃR�[�h//@@@@20230303
            RealRecord.InqOriginalSecCd = webRecord.InqOriginalSecCd; // �⍇�������_�R�[�h
            RealRecord.InqOtherEpCd = webRecord.InqOtherEpCd; // �⍇�����ƃR�[�h
            RealRecord.InqOtherSecCd = webRecord.InqOtherSecCd; // �⍇���拒�_�R�[�h
            RealRecord.InquiryNumber = webRecord.InquiryNumber; // �⍇���ԍ�
            RealRecord.UpdateDate = webRecord.UpdateDate; // �X�V�N����
            RealRecord.UpdateTime = webRecord.UpdateTime; // �X�V�����b�~���b
            RealRecord.InqRowNumber = webRecord.InqRowNumber; // �⍇���s�ԍ�
            RealRecord.InqRowNumDerivedNo = webRecord.InqRowNumDerivedNo; // �⍇���s�ԍ��}��
            RealRecord.InqOrgDtlDiscGuid = webRecord.InqOrgDtlDiscGuid; // �⍇�������׎���GUID
            RealRecord.InqOthDtlDiscGuid = webRecord.InqOthDtlDiscGuid; // �⍇���斾�׎���GUID
            RealRecord.GoodsDivCd = webRecord.GoodsDivCd; // ���i���
            RealRecord.RecyclePrtKindCode = webRecord.RecyclePrtKindCode; // ���T�C�N�����i���
            RealRecord.RecyclePrtKindName = webRecord.RecyclePrtKindName; // ���T�C�N�����i��ʖ���
            RealRecord.DeliveredGoodsDiv = webRecord.DeliveredGoodsDiv; // �[�i�敪
            RealRecord.HandleDivCode = webRecord.HandleDivCode; // �戵�敪
            RealRecord.GoodsShape = webRecord.GoodsShape; // ���i�`��
            RealRecord.DelivrdGdsConfCd = webRecord.DelivrdGdsConfCd; // �[�i�m�F�敪
            RealRecord.DeliGdsCmpltDueDate = webRecord.DeliGdsCmpltDueDate; // �[�i�����\���
            RealRecord.AnswerDeliveryDate = webRecord.AnswerDeliveryDate; // �񓚔[��
            RealRecord.BLGoodsCode = webRecord.BLGoodsCode; // BL���i�R�[�h
            RealRecord.BLGoodsDrCode = webRecord.BLGoodsDrCode; // BL���i�R�[�h�}��
            //RealRecord.GoodsName = webRecord.GoodsName; // ���i���i�J�i�j
            RealRecord.InqGoodsName = webRecord.InqGoodsName; // �┭���i��
            RealRecord.AnsGoodsName = webRecord.AnsGoodsName; // �񓚏��i��
            RealRecord.SalesOrderCount = webRecord.SalesOrderCount; // ������
            RealRecord.DeliveredGoodsCount = webRecord.DeliveredGoodsCount; // �[�i��
            RealRecord.GoodsNo = webRecord.GoodsNo; // ���i�ԍ�
            RealRecord.GoodsMakerCd = webRecord.GoodsMakerCd; // ���i���[�J�[�R�[�h
            RealRecord.GoodsMakerNm = webRecord.GoodsMakerNm; // ���i���[�J�[����
            RealRecord.PureGoodsMakerCd = webRecord.PureGoodsMakerCd; // �������i���[�J�[�R�[�h
            //RealRecord.PureGoodsNo = webRecord.PureGoodsNo; // �������i�ԍ�
            RealRecord.InqPureGoodsNo = webRecord.InqPureGoodsNo; // �┭�������i�ԍ�
            RealRecord.AnsPureGoodsNo = webRecord.AnsPureGoodsNo; // �񓚏������i�ԍ�
            RealRecord.ListPrice = webRecord.ListPrice; // �艿
            RealRecord.UnitPrice = webRecord.UnitPrice; // �P��
            RealRecord.GoodsAddInfo = webRecord.GoodsAddInfo; // ���i�⑫���
            RealRecord.RoughRrofit = webRecord.RoughRrofit; // �e���z
            RealRecord.RoughRate = webRecord.RoughRate; // �e����
            RealRecord.AnswerLimitDate = webRecord.AnswerLimitDate; // �񓚊���
            RealRecord.CommentDtl = webRecord.CommentDtl; // ���l(����)
            //RealRecord.AppendingFileDtl = webRecord.AppendingFileDtl; // �Y�t�t�@�C��(����)
            //RealRecord.AppendingFileNmDtl = webRecord.AppendingFileNmDtl; // �Y�t�t�@�C����(����)
            RealRecord.ShelfNo = webRecord.ShelfNo; // �I��
            RealRecord.AdditionalDivCd = webRecord.AdditionalDivCd; // �ǉ��敪
            RealRecord.CorrectDivCD = webRecord.CorrectDivCD; // �����敪
            //RealRecord.AcptAnOdrStatus = webRecord.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            //RealRecord.SalesSlipNum = webRecord.SalesSlipNum; // ����`�[�ԍ�
            RealRecord.InqOrdDivCd = webRecord.InqOrdDivCd; // �⍇���E�������
            RealRecord.DisplayOrder = webRecord.DisplayOrder; // �\������

            // 2010/05/26 Add >>>
            RealRecord.CancelCndtinDiv = webRecord.CancelCndtinDiv; // �L�����Z����ԋ敪
            RealRecord.AcptAnOdrStatus = webRecord.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            RealRecord.SalesSlipNum = webRecord.SalesSlipNum; // ����`�[�ԍ�
            RealRecord.SalesRowNo = webRecord.SalesRowNo; // ����s�ԍ�
            // 2010/05/26 Add <<<
            // 2011/02/09 Add >>>
            RealRecord.DtlTakeinDivCd = webRecord.DtlTakeinDivCd; // ���׎捞�敪
            // 2011/02/09 Add <<<
            // --- ADD m.suzuki 2011/05/23 ---------->>>>>
            RealRecord.WarehouseCode = webRecord.PmWarehouseCd; // PM�q�ɃR�[�h
            RealRecord.WarehouseName = webRecord.PmWarehouseName; // PM�q�ɖ���
            RealRecord.WarehouseShelfNo = webRecord.PmShelfNo; // �I��
            // --- ADD m.suzuki 2011/05/23 ----------<<<<<

            // ----- ADD 2011/08/10 ----- >>>>>
            RealRecord.PmPrsntCount = webRecord.PmPrsntCount; // PM���݌ɐ�
            RealRecord.SetPartsMkrCd = webRecord.SetPartsMkrCd; // �Z�b�g���i���[�J�[�R�[�h
            RealRecord.SetPartsNumber = webRecord.SetPartsNumber; // �Z�b�g���i�ԍ�
            RealRecord.SetPartsMainSubNo = webRecord.SetPartsMainSubNo; // �Z�b�g���i�e�q�ԍ�
            // ----- ADD 2011/08/10 ----- <<<<<

            // ----- ADD 2011/10/10 ----- >>>>>
            RealRecord.CampaignCode = webRecord.CampaignCode;
            // ----- ADD 2011/10/10 ----- <<<<<

            // 2012/01/16 Add >>>
            RealRecord.GoodsSpecialNote = webRecord.GoodsSpecialNote;
            // 2012/01/16 Add <<<

            // --- ADD T.Nishi 2012/05/30 ---------->>>>>
            RealRecord.AutoEstimatePartsCd = webRecord.AutoEstimatePartsCd;
            // --- ADD T.Nishi 2012/05/30 ----------<<<<<

            // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.SalesTotalTaxInc = webRecord.SalesTotalTaxInc; // ����`�[���v�i�ō��j
            RealRecord.SalesTotalTaxExc = webRecord.SalesTotalTaxExc; // ����`�[���v�i�Ŕ��j
            RealRecord.ScmConsTaxLayMethod = webRecord.ScmConsTaxLayMethod; // SCM����œ]�ŕ���
            RealRecord.ConsTaxRate = webRecord.ConsTaxRate; // ����Őŗ�
            RealRecord.ScmFractionProcCd = webRecord.ScmFractionProcCd; // SCM�[�������敪
            RealRecord.AccRecConsTax = webRecord.AccRecConsTax; // ���|�����
            RealRecord.PMSalesDate = webRecord.PMSalesDate; // PM�����
            RealRecord.SuppSlpPrtTime = webRecord.SuppSlpPrtTime; // �d����`�[���s����
            RealRecord.SalesMoneyTaxInc = webRecord.SalesMoneyTaxInc; // ������z�i�ō��݁j
            RealRecord.SalesMoneyTaxExc = webRecord.SalesMoneyTaxExc; // ������z�i�Ŕ����j
            // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.DataInputSystem = webRecord.DataInputSystem; // �f�[�^���̓V�X�e��
            // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
            RealRecord.PrmSetDtlNo2 = webRecord.PrmSetDtlNo2; // �D�ǐݒ�ڍ׃R�[�h�Q
            RealRecord.PrmSetDtlName2 = webRecord.PrmSetDtlName2; // �D�ǐݒ�ڍז��̂Q
            RealRecord.StockStatusDiv = webRecord.StockStatusDiv; // �݌ɏ󋵋敪
            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<
            // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
            RealRecord.RentDiv = webRecord.RentDiv; // �ݏo�敪            
            RealRecord.MkrSuggestRtPric = webRecord.MkrSuggestRtPric; // ���[�J�[��]�������i
            RealRecord.OpenPriceDiv = webRecord.OpenPriceDiv; // �I�[�v�����i�敪    
            // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
            // ADD 2015/01/19 �L�� ���R�����h�Ή� --------------------->>>>>
            RealRecord.BgnGoodsDiv = webRecord.BgnGoodsDiv; // ���������i�I���敪
            // ADD 2015/01/19 �L�� ���R�����h�Ή� ---------------------<<<<<
            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
            RealRecord.ModelPrtsAdptYm = webRecord.ModelPrtsAdptYm; // �^���ʕ��i�̗p�N��
            RealRecord.ModelPrtsAblsYm = webRecord.ModelPrtsAblsYm; // �^���ʕ��i�p�~�N��
            RealRecord.ModelPrtsAdptFrameNo = webRecord.ModelPrtsAdptFrameNo; // �^���ʕ��i�̗p�ԑ�ԍ�
            RealRecord.ModelPrtsAblsFrameNo = webRecord.ModelPrtsAblsFrameNo; // �^���ʕ��i�p�~�ԑ�ԍ�
            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.AnsDeliDateDiv = webRecord.AnsDeliDateDiv; // �񓚔[���敪
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
            RealRecord.GoodsSpecialNtForFac = webRecord.GoodsSpecialNtForFac;   // ���i�K�i�E���L����(�H�����)
            RealRecord.GoodsSpecialNtForCOw = webRecord.GoodsSpecialNtForCOw;   // ���i�K�i�E���L����(�J�[�I�[�i�[����)
            RealRecord.PrmSetDtlName2ForFac = webRecord.PrmSetDtlName2ForFac;   // �D�ǐݒ�ڍז��̂Q(�H�����)
            RealRecord.PrmSetDtlName2ForCOw = webRecord.PrmSetDtlName2ForCOw;   // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<

            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.InqBlUtyPtThCd = webRecord.InqBlUtyPtThCd;   // �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
            RealRecord.InqBlUtyPtSbCd = webRecord.InqBlUtyPtSbCd;   // �┭BL���ꕔ�i�T�u�R�[�h
            RealRecord.AnsBlUtyPtThCd = webRecord.AnsBlUtyPtThCd;   // ��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
            RealRecord.AnsBlUtyPtSbCd = webRecord.AnsBlUtyPtSbCd;   // ��BL���ꕔ�i�T�u�R�[�h
            RealRecord.AnsBLGoodsCode = webRecord.AnsBLGoodsCode;   // ��BL���i�R�[�h
            RealRecord.AnsBLGoodsDrCode = webRecord.AnsBLGoodsDrCode;   // ��BL���i�R�[�h�}��
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }



        /// <summary>
        /// �R�s�[�R���X�g���N�^
        /// </summary>
        /// <param name="other">�R�s�[��</param>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
        /// </remarks>
        public UserSCMOrderDetailRecord(UserSCMOrderDetailRecord other)
        {
            if (other == null || other == this) return;

            RealRecord.CreateDateTime = other.CreateDateTime; // �쐬����
            RealRecord.UpdateDateTime = other.UpdateDateTime; // �X�V����
            RealRecord.EnterpriseCode = other.EnterpriseCode; // ��ƃR�[�h
            RealRecord.FileHeaderGuid = other.FileHeaderGuid; // GUID
            RealRecord.UpdEmployeeCode = other.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            RealRecord.UpdAssemblyId1 = other.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            RealRecord.UpdAssemblyId2 = other.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            RealRecord.LogicalDeleteCode = other.LogicalDeleteCode; // �_���폜�敪
            RealRecord.InqOriginalEpCd = other.InqOriginalEpCd.Trim(); // �⍇������ƃR�[�h//@@@@20230303
            RealRecord.InqOriginalSecCd = other.InqOriginalSecCd; // �⍇�������_�R�[�h
            RealRecord.InqOtherEpCd = other.InqOtherEpCd; // �⍇�����ƃR�[�h
            RealRecord.InqOtherSecCd = other.InqOtherSecCd; // �⍇���拒�_�R�[�h
            RealRecord.InquiryNumber = other.InquiryNumber; // �⍇���ԍ�
            RealRecord.UpdateDate = other.UpdateDate; // �X�V�N����
            RealRecord.UpdateTime = other.UpdateTime; // �X�V�����b�~���b
            RealRecord.InqRowNumber = other.InqRowNumber; // �⍇���s�ԍ�
            RealRecord.InqRowNumDerivedNo = other.InqRowNumDerivedNo; // �⍇���s�ԍ��}��
            RealRecord.InqOrgDtlDiscGuid = other.InqOrgDtlDiscGuid; // �⍇�������׎���GUID
            RealRecord.InqOthDtlDiscGuid = other.InqOthDtlDiscGuid; // �⍇���斾�׎���GUID
            RealRecord.GoodsDivCd = other.GoodsDivCd; // ���i���
            RealRecord.RecyclePrtKindCode = other.RecyclePrtKindCode; // ���T�C�N�����i���
            RealRecord.RecyclePrtKindName = other.RecyclePrtKindName; // ���T�C�N�����i��ʖ���
            RealRecord.DeliveredGoodsDiv = other.DeliveredGoodsDiv; // �[�i�敪
            RealRecord.HandleDivCode = other.HandleDivCode; // �戵�敪
            RealRecord.GoodsShape = other.GoodsShape; // ���i�`��
            RealRecord.DelivrdGdsConfCd = other.DelivrdGdsConfCd; // �[�i�m�F�敪
            RealRecord.DeliGdsCmpltDueDate = other.DeliGdsCmpltDueDate; // �[�i�����\���
            RealRecord.AnswerDeliveryDate = other.AnswerDeliveryDate; // �񓚔[��
            RealRecord.BLGoodsCode = other.BLGoodsCode; // BL���i�R�[�h
            RealRecord.BLGoodsDrCode = other.BLGoodsDrCode; // BL���i�R�[�h�}��
            //RealRecord.GoodsName = other.GoodsName; // ���i���i�J�i�j
            RealRecord.InqGoodsName = other.InqGoodsName; // �┭���i��
            RealRecord.AnsGoodsName = other.AnsGoodsName; // �񓚏��i��
            RealRecord.SalesOrderCount = other.SalesOrderCount; // ������
            RealRecord.DeliveredGoodsCount = other.DeliveredGoodsCount; // �[�i��
            RealRecord.GoodsNo = other.GoodsNo; // ���i�ԍ�
            RealRecord.GoodsMakerCd = other.GoodsMakerCd; // ���i���[�J�[�R�[�h
            RealRecord.GoodsMakerNm = other.GoodsMakerNm; // ���i���[�J�[����
            RealRecord.PureGoodsMakerCd = other.PureGoodsMakerCd; // �������i���[�J�[�R�[�h
            //RealRecord.PureGoodsNo = other.PureGoodsNo; // �������i�ԍ�
            RealRecord.InqPureGoodsNo = other.InqPureGoodsNo; // �������i�ԍ�
            RealRecord.AnsPureGoodsNo = other.AnsPureGoodsNo; // �������i�ԍ�
            RealRecord.ListPrice = other.ListPrice; // �艿
            RealRecord.UnitPrice = other.UnitPrice; // �P��
            RealRecord.GoodsAddInfo = other.GoodsAddInfo; // ���i�⑫���
            RealRecord.RoughRrofit = other.RoughRrofit; // �e���z
            RealRecord.RoughRate = other.RoughRate; // �e����
            RealRecord.AnswerLimitDate = other.AnswerLimitDate; // �񓚊���
            RealRecord.CommentDtl = other.CommentDtl; // ���l(����)
            RealRecord.AppendingFileDtl = other.AppendingFileDtl; // �Y�t�t�@�C��(����)
            RealRecord.AppendingFileNmDtl = other.AppendingFileNmDtl; // �Y�t�t�@�C����(����)
            RealRecord.ShelfNo = other.ShelfNo; // �I��
            RealRecord.AdditionalDivCd = other.AdditionalDivCd; // �ǉ��敪
            RealRecord.CorrectDivCD = other.CorrectDivCD; // �����敪
            //RealRecord.AcptAnOdrStatus = other.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            //RealRecord.SalesSlipNum = other.SalesSlipNum; // ����`�[�ԍ�
            RealRecord.InqOrdDivCd = other.InqOrdDivCd; // �⍇���E�������
            RealRecord.DisplayOrder = other.DisplayOrder; // �\������

            // 2010/05/26 Add >>>
            RealRecord.CancelCndtinDiv = other.CancelCndtinDiv; // �L�����Z����ԋ敪
            RealRecord.AcptAnOdrStatus = other.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            RealRecord.SalesSlipNum = other.SalesSlipNum; // ����`�[�ԍ�
            RealRecord.SalesRowNo = other.SalesRowNo; // ����s�ԍ�
            // 2010/05/26 Add <<<

            // 2011/02/09 Add >>>
            RealRecord.DtlTakeinDivCd = other.DtlTakeinDivCd; // ���׎捞�敪
            // 2011/02/09 Add <<<
            // --- ADD m.suzuki 2011/05/23 ---------->>>>>
            RealRecord.WarehouseCode = other.PmWarehouseCd; // PM�q�ɃR�[�h
            RealRecord.WarehouseName = other.PmWarehouseName; // PM�q�ɖ���
            RealRecord.WarehouseShelfNo = other.PmShelfNo; // �I��
            // --- ADD m.suzuki 2011/05/23 ----------<<<<<
            // 2011/10/10 Add >>>
            RealRecord.CampaignCode = other.CampaignCode; // �L�����y�[���R�[�h
            // 2011/10/10 Add <<<

            // 2012/01/16 Add >>>
            RealRecord.GoodsSpecialNote = other.GoodsSpecialNote;
            // 2012/01/16 Add <<<

            // --- ADD T.Nishi 2012/05/30 ---------->>>>>
            RealRecord.AutoEstimatePartsCd = other.AutoEstimatePartsCd;
            // --- ADD T.Nishi 2012/05/30 ----------<<<<<

            // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.SalesTotalTaxInc = other.SalesTotalTaxInc; // ����`�[���v�i�ō��j
            RealRecord.SalesTotalTaxExc = other.SalesTotalTaxExc; // ����`�[���v�i�Ŕ��j
            RealRecord.ScmConsTaxLayMethod = other.ScmConsTaxLayMethod; // SCM����œ]�ŕ���
            RealRecord.ConsTaxRate = other.ScmConsTaxLayMethod; // ����Őŗ�
            RealRecord.ScmFractionProcCd = other.ScmConsTaxLayMethod; // SCM�[�������敪
            RealRecord.AccRecConsTax = other.ScmConsTaxLayMethod; // ���|�����
            RealRecord.PMSalesDate = other.ScmConsTaxLayMethod; // PM�����
            RealRecord.SuppSlpPrtTime = other.ScmConsTaxLayMethod; // �d����`�[���s����
            RealRecord.SalesMoneyTaxInc = other.SalesMoneyTaxInc; // ������z�i�ō��݁j
            RealRecord.SalesMoneyTaxExc = other.SalesMoneyTaxExc; // ������z�i�Ŕ����j
            // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.DataInputSystem = other.DataInputSystem; // �f�[�^���̓V�X�e��
            // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<        

            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
            RealRecord.PrmSetDtlNo2 = other.PrmSetDtlNo2; // �D�ǐݒ�ڍ׃R�[�h�Q
            RealRecord.PrmSetDtlName2 = other.PrmSetDtlName2; // �D�ǐݒ�ڍז��̂Q
            RealRecord.StockStatusDiv = other.StockStatusDiv; // �݌ɏ󋵋敪
            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<

            // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
            RealRecord.RentDiv = other.RentDiv; // �ݏo�敪            
            RealRecord.MkrSuggestRtPric = other.MkrSuggestRtPric; // ���[�J�[��]�������i
            RealRecord.OpenPriceDiv = other.OpenPriceDiv; // �I�[�v�����i�敪    
            // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<

            // ADD 2015/01/19 �L�� ���R�����h�Ή� --------------------->>>>>
            RealRecord.BgnGoodsDiv = other.BgnGoodsDiv; // ���������i�I���敪
            // ADD 2015/01/19 �L�� ���R�����h�Ή� ---------------------<<<<<

            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
            RealRecord.ModelPrtsAdptYm = other.ModelPrtsAdptYm; // �^���ʕ��i�̗p�N��
            RealRecord.ModelPrtsAblsYm = other.ModelPrtsAblsYm; // �^���ʕ��i�p�~�N��
            RealRecord.ModelPrtsAdptFrameNo = other.ModelPrtsAdptFrameNo; // �^���ʕ��i�̗p�ԑ�ԍ�
            RealRecord.ModelPrtsAblsFrameNo = other.ModelPrtsAblsFrameNo; // �^���ʕ��i�p�~�ԑ�ԍ�
            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.AnsDeliDateDiv = other.AnsDeliDateDiv; // �񓚔[���敪
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
            RealRecord.GoodsSpecialNtForFac = other.GoodsSpecialNtForFac;    // ���i�K�i�E���L����(�H�����)
            RealRecord.GoodsSpecialNtForCOw = other.GoodsSpecialNtForCOw;    // ���i�K�i�E���L����(�J�[�I�[�i�[����)
            RealRecord.PrmSetDtlName2ForFac = other.PrmSetDtlName2ForFac;    // �D�ǐݒ�ڍז��̂Q(�H�����)
            RealRecord.PrmSetDtlName2ForCOw = other.PrmSetDtlName2ForCOw;    // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<

            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.InqBlUtyPtThCd = other.InqBlUtyPtThCd;   // �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
            RealRecord.InqBlUtyPtSbCd = other.InqBlUtyPtSbCd;   // �┭BL���ꕔ�i�T�u�R�[�h
            RealRecord.AnsBlUtyPtThCd = other.AnsBlUtyPtThCd;   // ��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
            RealRecord.AnsBlUtyPtSbCd = other.AnsBlUtyPtSbCd;   // ��BL���ꕔ�i�T�u�R�[�h
            RealRecord.AnsBLGoodsCode = other.AnsBLGoodsCode;   // ��BL���i�R�[�h
            RealRecord.AnsBLGoodsDrCode = other.AnsBLGoodsDrCode;   // ��BL���i�R�[�h�}��
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        #region <User��WEB�ϊ�>
        /// <summary>
        /// UserDB����WebDB�ւ̋l�ւ�����(�⍇�����ƁA���_�͕ʓr�ݒ肪�K�v)
        /// </summary>
        /// <returns>SCM�󔭒����׃f�[�^(�⍇���E����)</returns>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
        /// </remarks>
        public WebSCMOrderDetailRecord CopyToWebSCMOrderDetailRecord()
        {
            RecordTypeWeb webRecord = new RecordTypeWeb();
            {
                //webRecord.CreateDateTime = RealRecord.CreateDateTime; // �쐬����
                //webRecord.UpdateDateTime = RealRecord.UpdateDateTime; // �X�V����
                ////webRecord.EnterpriseCode = RealRecord.EnterpriseCode; // ��ƃR�[�h
                ////webRecord.FileHeaderGuid = RealRecord.FileHeaderGuid; // GUID
                ////webRecord.UpdEmployeeCode = RealRecord.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                ////webRecord.UpdAssemblyId1 = RealRecord.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                ////webRecord.UpdAssemblyId2 = RealRecord.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                //webRecord.LogicalDeleteCode = RealRecord.LogicalDeleteCode; // �_���폜�敪
                //webRecord.InqOriginalEpCd = RealRecord.InqOriginalEpCd; // �⍇������ƃR�[�h
                //webRecord.InqOriginalSecCd = RealRecord.InqOriginalSecCd; // �⍇�������_�R�[�h
                //webRecord.InqOtherEpCd = RealRecord.InqOtherEpCd; // �⍇�����ƃR�[�h
                //webRecord.InqOtherSecCd = RealRecord.InqOtherSecCd; // �⍇���拒�_�R�[�h
                //webRecord.InquiryNumber = RealRecord.InquiryNumber; // �⍇���ԍ�
                //webRecord.UpdateDate = RealRecord.UpdateDate; // �X�V�N����
                //webRecord.UpdateTime = RealRecord.UpdateTime; // �X�V�����b�~���b
                //webRecord.InqRowNumber = RealRecord.InqRowNumber; // �⍇���s�ԍ�
                //webRecord.InqRowNumDerivedNo = RealRecord.InqRowNumDerivedNo; // �⍇���s�ԍ��}��
                //webRecord.InqOrgDtlDiscGuid = RealRecord.InqOrgDtlDiscGuid; // �⍇�������׎���GUID
                //webRecord.InqOthDtlDiscGuid = RealRecord.InqOthDtlDiscGuid; // �⍇���斾�׎���GUID
                //webRecord.GoodsDivCd = RealRecord.GoodsDivCd; // ���i���
                //webRecord.RecyclePrtKindCode = RealRecord.RecyclePrtKindCode; // ���T�C�N�����i���
                //webRecord.RecyclePrtKindName = RealRecord.RecyclePrtKindName; // ���T�C�N�����i��ʖ���
                //webRecord.DeliveredGoodsDiv = RealRecord.DeliveredGoodsDiv; // �[�i�敪
                //webRecord.HandleDivCode = RealRecord.HandleDivCode; // �戵�敪
                //webRecord.GoodsShape = RealRecord.GoodsShape; // ���i�`��
                //webRecord.DelivrdGdsConfCd = RealRecord.DelivrdGdsConfCd; // �[�i�m�F�敪
                //webRecord.DeliGdsCmpltDueDate = RealRecord.DeliGdsCmpltDueDate; // �[�i�����\���
                //webRecord.AnswerDeliveryDate = RealRecord.AnswerDeliveryDate; // �񓚔[��
                //webRecord.BLGoodsCode = RealRecord.BLGoodsCode; // BL���i�R�[�h
                //webRecord.BLGoodsDrCode = RealRecord.BLGoodsDrCode; // BL���i�R�[�h�}��
                //webRecord.GoodsName = RealRecord.GoodsName; // ���i���i�J�i�j
                //webRecord.SalesOrderCount = RealRecord.SalesOrderCount; // ������
                //webRecord.DeliveredGoodsCount = RealRecord.DeliveredGoodsCount; // �[�i��
                //webRecord.GoodsNo = RealRecord.GoodsNo; // ���i�ԍ�
                //webRecord.GoodsMakerCd = RealRecord.GoodsMakerCd; // ���i���[�J�[�R�[�h
                //webRecord.PureGoodsMakerCd = RealRecord.PureGoodsMakerCd; // �������i���[�J�[�R�[�h
                //webRecord.PureGoodsNo = RealRecord.PureGoodsNo; // �������i�ԍ�
                //webRecord.ListPrice = RealRecord.ListPrice; // �艿
                //webRecord.UnitPrice = RealRecord.UnitPrice; // �P��
                //webRecord.GoodsAddInfo = RealRecord.GoodsAddInfo; // ���i�⑫���
                //webRecord.RoughRrofit = RealRecord.RoughRrofit; // �e���z
                //webRecord.RoughRate = RealRecord.RoughRate; // �e����
                ////webRecord.AnswerLimitDate = RealRecord.AnswerLimitDate; // �񓚊���
                //webRecord.CommentDtl = RealRecord.CommentDtl; // ���l(����)
                ////webRecord.AppendingFileDtl = RealRecord.AppendingFileDtl; // �Y�t�t�@�C��(����)
                ////webRecord.AppendingFileNmDtl = RealRecord.AppendingFileNmDtl; // �Y�t�t�@�C����(����)
                //webRecord.ShelfNo = RealRecord.ShelfNo; // �I��
                //webRecord.AdditionalDivCd = RealRecord.AdditionalDivCd; // �ǉ��敪
                //webRecord.CorrectDivCD = RealRecord.CorrectDivCD; // �����敪
                ////webRecord.AcptAnOdrStatus = RealRecord.AcptAnOdrStatus; // �󒍃X�e�[�^�X
                ////webRecord.SalesSlipNum = RealRecord.SalesSlipNum; // ����`�[�ԍ�
                //webRecord.InqOrdDivCd = RealRecord.InqOrdDivCd; // �⍇���E�������
                //webRecord.DisplayOrder = RealRecord.DisplayOrder; // �\������

                webRecord.CreateDateTime = RealRecord.CreateDateTime; // �쐬����
                webRecord.UpdateDateTime = RealRecord.UpdateDateTime; // �X�V����
                //webRecord.EnterpriseCode = RealRecord.EnterpriseCode; // ��ƃR�[�h
                //webRecord.FileHeaderGuid = RealRecord.FileHeaderGuid; // GUID
                //webRecord.UpdEmployeeCode = RealRecord.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                //webRecord.UpdAssemblyId1 = RealRecord.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                //webRecord.UpdAssemblyId2 = RealRecord.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                webRecord.LogicalDeleteCode = RealRecord.LogicalDeleteCode; // �_���폜�敪
                webRecord.InqOriginalEpCd = RealRecord.InqOriginalEpCd.Trim(); // �⍇������ƃR�[�h//@@@@20230303
                webRecord.InqOriginalSecCd = RealRecord.InqOriginalSecCd; // �⍇�������_�R�[�h
                webRecord.InqOtherEpCd = RealRecord.InqOtherEpCd; // �⍇�����ƃR�[�h
                webRecord.InqOtherSecCd = RealRecord.InqOtherSecCd; // �⍇���拒�_�R�[�h
                webRecord.InquiryNumber = RealRecord.InquiryNumber; // �⍇���ԍ�
                webRecord.UpdateDate = RealRecord.UpdateDate; // �X�V�N����
                webRecord.UpdateTime = RealRecord.UpdateTime; // �X�V�����b�~���b
                webRecord.InqRowNumber = RealRecord.InqRowNumber; // �⍇���s�ԍ�
                webRecord.InqRowNumDerivedNo = RealRecord.InqRowNumDerivedNo; // �⍇���s�ԍ��}��
                webRecord.InqOrgDtlDiscGuid = RealRecord.InqOrgDtlDiscGuid; // �⍇�������׎���GUID
                webRecord.InqOthDtlDiscGuid = RealRecord.InqOthDtlDiscGuid; // �⍇���斾�׎���GUID
                webRecord.GoodsDivCd = RealRecord.GoodsDivCd; // ���i���
                webRecord.RecyclePrtKindCode = RealRecord.RecyclePrtKindCode; // ���T�C�N�����i���
                webRecord.RecyclePrtKindName = RealRecord.RecyclePrtKindName; // ���T�C�N�����i��ʖ���
                webRecord.DeliveredGoodsDiv = RealRecord.DeliveredGoodsDiv; // �[�i�敪
                webRecord.HandleDivCode = RealRecord.HandleDivCode; // �戵�敪
                webRecord.GoodsShape = RealRecord.GoodsShape; // ���i�`��
                webRecord.DelivrdGdsConfCd = RealRecord.DelivrdGdsConfCd; // �[�i�m�F�敪
                webRecord.DeliGdsCmpltDueDate = RealRecord.DeliGdsCmpltDueDate; // �[�i�����\���
                webRecord.AnswerDeliveryDate = RealRecord.AnswerDeliveryDate; // �񓚔[��
                webRecord.BLGoodsCode = RealRecord.BLGoodsCode; // BL���i�R�[�h
                webRecord.BLGoodsDrCode = RealRecord.BLGoodsDrCode; // BL���i�R�[�h�}��
                //webRecord.GoodsName = RealRecord.GoodsName; // ���i���i�J�i�j
                webRecord.InqGoodsName = RealRecord.InqGoodsName; // �┭���i��
                webRecord.AnsGoodsName = RealRecord.AnsGoodsName; // �񓚏��i��
                webRecord.SalesOrderCount = RealRecord.SalesOrderCount; // ������
                webRecord.DeliveredGoodsCount = RealRecord.DeliveredGoodsCount; // �[�i��
                webRecord.GoodsNo = RealRecord.GoodsNo; // ���i�ԍ�
                webRecord.GoodsMakerCd = RealRecord.GoodsMakerCd; // ���i���[�J�[�R�[�h
                webRecord.GoodsMakerNm = RealRecord.GoodsMakerNm; // ���i���[�J�[����
                webRecord.PureGoodsMakerCd = RealRecord.PureGoodsMakerCd; // �������i���[�J�[�R�[�h
                //webRecord.PureGoodsNo = RealRecord.PureGoodsNo; // �������i�ԍ�
                webRecord.InqPureGoodsNo = RealRecord.InqPureGoodsNo; // �������i�ԍ�
                webRecord.AnsPureGoodsNo = RealRecord.AnsPureGoodsNo; // �������i�ԍ�
                webRecord.ListPrice = RealRecord.ListPrice; // �艿
                webRecord.UnitPrice = RealRecord.UnitPrice; // �P��
                webRecord.GoodsAddInfo = RealRecord.GoodsAddInfo; // ���i�⑫���
                webRecord.RoughRrofit = RealRecord.RoughRrofit; // �e���z
                webRecord.RoughRate = RealRecord.RoughRate; // �e����
                webRecord.AnswerLimitDate = RealRecord.AnswerLimitDate; // �񓚊���
                webRecord.CommentDtl = RealRecord.CommentDtl; // ���l(����)
                //webRecord.AppendingFileDtl = RealRecord.AppendingFileDtl; // �Y�t�t�@�C��(����)
                //webRecord.AppendingFileNmDtl = RealRecord.AppendingFileNmDtl; // �Y�t�t�@�C����(����)
                webRecord.ShelfNo = RealRecord.ShelfNo; // �I��
                webRecord.AdditionalDivCd = RealRecord.AdditionalDivCd; // �ǉ��敪
                webRecord.CorrectDivCD = RealRecord.CorrectDivCD; // �����敪
                //webRecord.AcptAnOdrStatus = RealRecord.AcptAnOdrStatus; // �󒍃X�e�[�^�X
                //webRecord.SalesSlipNum = RealRecord.SalesSlipNum; // ����`�[�ԍ�
                webRecord.InqOrdDivCd = RealRecord.InqOrdDivCd; // �⍇���E�������
                webRecord.DisplayOrder = RealRecord.DisplayOrder; // �\������

                // 2010/05/26 Add >>>
                webRecord.CancelCndtinDiv = RealRecord.CancelCndtinDiv; // �L�����Z����ԋ敪
                webRecord.PMAcptAnOdrStatus = RealRecord.AcptAnOdrStatus; // �󒍃X�e�[�^�X
                webRecord.PMSalesSlipNum = TStrConv.StrToIntDef(RealRecord.SalesSlipNum.Trim(), 0); // ����`�[�ԍ�
                webRecord.PMSalesRowNo = RealRecord.SalesRowNo; // ����s�ԍ�
                // 2010/05/26 Add <<<

                // 2011/02/09 Add >>>
                webRecord.DtlTakeinDivCd = RealRecord.DtlTakeinDivCd; // ���׎捞�敪
                // 2011/02/09 Add <<<
                // --- ADD m.suzuki 2011/05/23 ---------->>>>>
                webRecord.PmWarehouseCd = RealRecord.WarehouseCode; // PM�q�ɃR�[�h
                webRecord.PmWarehouseName = RealRecord.WarehouseName; // PM�q�ɖ���
                webRecord.PmShelfNo = RealRecord.WarehouseShelfNo; // �I��
                // --- ADD m.suzuki 2011/05/23 ----------<<<<<

                // ----- ADD 2011/10/10 ----- >>>>>
                webRecord.CampaignCode = RealRecord.CampaignCode;
                // ----- ADD 2011/10/10 ----- <<<<<

                // 2012/01/16 Add >>>
                webRecord.GoodsSpecialNote = RealRecord.GoodsSpecialNote;
                // 2012/01/16 Add <<<

                // --- ADD T.Nishi 2012/05/30 ---------->>>>>
                webRecord.AutoEstimatePartsCd = RealRecord.AutoEstimatePartsCd;
                // --- ADD T.Nishi 2012/05/30 ----------<<<<<

                // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                webRecord.SalesTotalTaxInc = RealRecord.SalesTotalTaxInc; // ����`�[���v�i�ō��j
                webRecord.SalesTotalTaxExc = RealRecord.SalesTotalTaxExc; // ����`�[���v�i�Ŕ��j
                webRecord.ScmConsTaxLayMethod = RealRecord.ScmConsTaxLayMethod; // SCM����œ]�ŕ���
                webRecord.ConsTaxRate = RealRecord.ConsTaxRate; // ����Őŗ�
                webRecord.ScmFractionProcCd = RealRecord.ScmFractionProcCd; // SCM�[�������敪
                webRecord.AccRecConsTax = RealRecord.AccRecConsTax; // ���|�����
                //webRecord.PMSalesDate = DateTime.ParseExact(RealRecord.PMSalesDate.ToString(), "yyyyMMdd", null); // PM�����
                DateTime PMSalesDate;
                if (DateTime.TryParseExact(RealRecord.PMSalesDate.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out PMSalesDate))
                {
                    webRecord.PMSalesDate = PMSalesDate;    // PM�����
                }
                webRecord.SuppSlpPrtTime = RealRecord.SuppSlpPrtTime; // �d����`�[���s����
                webRecord.SalesMoneyTaxInc = RealRecord.SalesMoneyTaxInc; // ������z�i�ō��݁j
                webRecord.SalesMoneyTaxExc = RealRecord.SalesMoneyTaxExc; // ������z�i�Ŕ����j
                // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                webRecord.DataInputSystem = RealRecord.DataInputSystem; // �f�[�^���̓V�X�e��
                // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
                webRecord.PrmSetDtlNo2 = RealRecord.PrmSetDtlNo2; // �D�ǐݒ�ڍ׃R�[�h�Q
                webRecord.PrmSetDtlName2 = RealRecord.PrmSetDtlName2; // �D�ǐݒ�ڍז��̂Q
                webRecord.StockStatusDiv = RealRecord.StockStatusDiv; // �݌ɏ󋵋敪
                // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<
                // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
                webRecord.RentDiv = RealRecord.RentDiv; // �ݏo�敪            
                webRecord.MkrSuggestRtPric = RealRecord.MkrSuggestRtPric; // ���[�J�[��]�������i
                webRecord.OpenPriceDiv = RealRecord.OpenPriceDiv; // �I�[�v�����i�敪    
                // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
                // ADD 2015/01/19 �L�� ���R�����h�Ή� --------------------->>>>>
                webRecord.BgnGoodsDiv = RealRecord.BgnGoodsDiv; // ���������i�I���敪
                // ADD 2015/01/19 �L�� ���R�����h�Ή� ---------------------<<<<<
                // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
                webRecord.ModelPrtsAdptYm = SCMEntityUtil.ConvertModelPrtsAdptYm(RealRecord.ModelPrtsAdptYm); // �^���ʕ��i�̗p�N��
                webRecord.ModelPrtsAblsYm = SCMEntityUtil.ConvertModelPrtsAdptYm(RealRecord.ModelPrtsAblsYm); // �^���ʕ��i�p�~�N��
                webRecord.ModelPrtsAdptFrameNo = RealRecord.ModelPrtsAdptFrameNo; // �^���ʕ��i�̗p�ԑ�ԍ�
                webRecord.ModelPrtsAblsFrameNo = RealRecord.ModelPrtsAblsFrameNo; // �^���ʕ��i�p�~�ԑ�ԍ�
                // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                webRecord.AnsDeliDateDiv = RealRecord.AnsDeliDateDiv; // �񓚔[���敪
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
                webRecord.GoodsSpecialNtForFac = RealRecord.GoodsSpecialNtForFac;   // ���i�K�i�E���L����(�H�����)
                webRecord.GoodsSpecialNtForCOw = RealRecord.GoodsSpecialNtForCOw;   // ���i�K�i�E���L����(�J�[�I�[�i�[����)
                webRecord.PrmSetDtlName2ForFac = RealRecord.PrmSetDtlName2ForFac;   // �D�ǐݒ�ڍז��̂Q(�H�����)
                webRecord.PrmSetDtlName2ForCOw = RealRecord.PrmSetDtlName2ForCOw;   // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
                // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<

                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                webRecord.InqBlUtyPtThCd = RealRecord.InqBlUtyPtThCd;   // �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
                webRecord.InqBlUtyPtSbCd = RealRecord.InqBlUtyPtSbCd;   // �┭BL���ꕔ�i�T�u�R�[�h
                webRecord.AnsBlUtyPtThCd = RealRecord.AnsBlUtyPtThCd;   // ��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
                webRecord.AnsBlUtyPtSbCd = RealRecord.AnsBlUtyPtSbCd;   // ��BL���ꕔ�i�T�u�R�[�h
                webRecord.AnsBLGoodsCode = RealRecord.AnsBLGoodsCode;   // ��BL���i�R�[�h
                webRecord.AnsBLGoodsDrCode = RealRecord.AnsBLGoodsDrCode;   // ��BL���i�R�[�h�}��
                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            return new WebSCMOrderDetailRecord(webRecord);
        }
        #endregion
    }
}
