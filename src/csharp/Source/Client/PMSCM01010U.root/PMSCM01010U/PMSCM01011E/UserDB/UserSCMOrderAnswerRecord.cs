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
// �� �� ��  2010/05/26  �C�����e :�e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2011/02/09  �C�����e :�e�[�u�����C�A�E�g�ύX�Ή�(���׎捞�敪�̒ǉ�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018�@��� ���b
// �� �� ��  2011/05/23  �C�����e : �e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS wangqx
// �� �� ��  2011/08/08  �C�����e : �e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10800003-00 �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2012/01/16  �C�����e : SCM���ǑΉ��E���L�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30745 �g�� �F��
// �� �� ��  2012/04/12  �C�����e : ��Q��170 PS�Ǘ��ԍ����ڒǉ�
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
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30745 �g��
// �� �� ��  2013/05/08  �C�����e : 2013/06/18�z�M�@SCM��Q��10308,��10528
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30745 �g��
// �� �� ��  2013/05/15  �C�����e : 2013/06/18�z�M�@SCM��Q��10410
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �e�c ���V
// �� �� ��  2013/06/13  �C�����e : 2013/06/18�z�M�@�V�X�e���e�X�g��Q��22
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
using Broadleaf.Library.Text;   // 2010/05/24 Add

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdDtAns;

    /// <summary>
    /// ���[�U�[DB SCM�󒍖��׃f�[�^(��)�̃��R�[�h�N���X
    /// </summary>
    public class UserSCMOrderAnswerRecord : UserSCMOrderAnswerWrapper
    {
        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public UserSCMOrderAnswerRecord() : base() { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realRecord">�{���̃��R�[�h</param>
        public UserSCMOrderAnswerRecord(RecordType realRecord) : base(realRecord) { }

        #endregion // </Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^(Web��User�ϊ�)
        /// </summary>
        /// <param name="webRecord">SCM�󔭒����׃f�[�^(��)</param>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
        /// </remarks>
        public UserSCMOrderAnswerRecord(WebSCMOrderAnswerRecord webRecord) : base(new RecordType())
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
            RealRecord.InqPureGoodsNo = webRecord.InqPureGoodsNo; // �������i�ԍ�
            RealRecord.AnsPureGoodsNo = webRecord.AnsPureGoodsNo; // �������i�ԍ�
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
            RealRecord.AcptAnOdrStatus = webRecord.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            RealRecord.SalesSlipNum = webRecord.SalesSlipNum; // ����`�[�ԍ�
            RealRecord.SalesRowNo = webRecord.SalesRowNo; // ����s�ԍ�
            //RealRecord.CampaignCode = webRecord.CampaignCode; // �L�����y�[���R�[�h
            //RealRecord.StockDiv = webRecord.StockDiv; // �݌ɋ敪
            RealRecord.InqOrdDivCd = webRecord.InqOrdDivCd; // �⍇���E�������
            RealRecord.DisplayOrder = webRecord.DisplayOrder; // �\������
            //RealRecord.GoodsMngNo = webRecord.GoodsMngNo; // ���i�Ǘ��ԍ�

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
            RealRecord.WarehouseShelfNo= webRecord.PmShelfNo; // �I��
            // --- ADD m.suzuki 2011/05/23 ----------<<<<<

            // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>�@�@
            RealRecord.PmPrsntCount = webRecord.PmPrsntCount; // PM���݌ɐ�
            RealRecord.SetPartsMkrCd = webRecord.SetPartsMkrCd; // �Z�b�g���i���[�J�[�R�[�h
            RealRecord.SetPartsNumber = webRecord.SetPartsNumber; // �Z�b�g���i�ԍ�
            RealRecord.SetPartsMainSubNo = webRecord.SetPartsMainSubNo; // �Z�b�g���i�e�q�ԍ�
            // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<
            RealRecord.CampaignCode = webRecord.CampaignCode; // �L�����y�[���R�[�h  // ADD 2011/10/10

            // 2012/01/16 Add >>>
            RealRecord.GoodsSpecialNote = webRecord.GoodsSpecialNote; // ���L����
            // 2012/01/16 Add <<<
            // --- ADD �g�� 2012/04/12 ��170 ---------->>>>>
            RealRecord.PSMngNo = webRecord.PsMngNo; // PS�Ǘ��ԍ�
            // --- ADD �g�� 2012/04/12 ��170 ----------<<<<<

            // --- ADD T.Nishi 2012/05/30 ---------->>>>>
            RealRecord.AutoEstimatePartsCd = webRecord.AutoEstimatePartsCd; // �������ϕ��i�R�[�h
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
            RealRecord.DataInputSystem = webRecord.DataInputSystem; //�f�[�^���̓V�X�e��
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
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="detailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)</param>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
        /// </remarks>
        public UserSCMOrderAnswerRecord(ISCMOrderDetailRecord detailRecord) : base(new RecordType())
        {
            UserSCMOrderDetailRecord userDetailRecord = detailRecord as UserSCMOrderDetailRecord;
            if (userDetailRecord == null) return;

            // ���ʃt�@�C���w�b�_�͉������Ȃ�
            //RealRecord.CreateDateTime = userDetailRecord.CreateDateTime; // �쐬����
            //RealRecord.UpdateDateTime = userDetailRecord.UpdateDateTime; // �X�V����
            //RealRecord.EnterpriseCode = userDetailRecord.EnterpriseCode; // ��ƃR�[�h
            //RealRecord.FileHeaderGuid = userDetailRecord.FileHeaderGuid; // GUID
            //RealRecord.UpdEmployeeCode = userDetailRecord.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            //RealRecord.UpdAssemblyId1 = userDetailRecord.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            //RealRecord.UpdAssemblyId2 = userDetailRecord.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            //RealRecord.LogicalDeleteCode = userDetailRecord.LogicalDeleteCode; // �_���폜�敪

            RealRecord.InqOriginalEpCd = userDetailRecord.InqOriginalEpCd.Trim(); // �⍇������ƃR�[�h//@@@@20230303
            RealRecord.InqOriginalSecCd = userDetailRecord.InqOriginalSecCd; // �⍇�������_�R�[�h
            RealRecord.InqOtherEpCd = userDetailRecord.InqOtherEpCd; // �⍇�����ƃR�[�h
            RealRecord.InqOtherSecCd = userDetailRecord.InqOtherSecCd; // �⍇���拒�_�R�[�h
            RealRecord.InquiryNumber = userDetailRecord.InquiryNumber; // �⍇���ԍ�
            RealRecord.UpdateDate = userDetailRecord.UpdateDate; // �X�V�N����
            RealRecord.UpdateTime = userDetailRecord.UpdateTime; // �X�V�����b�~���b
            RealRecord.InqRowNumber = userDetailRecord.InqRowNumber; // �⍇���s�ԍ�
            RealRecord.InqRowNumDerivedNo = userDetailRecord.InqRowNumDerivedNo; // �⍇���s�ԍ��}��
            RealRecord.InqOrgDtlDiscGuid = userDetailRecord.InqOrgDtlDiscGuid; // �⍇�������׎���GUID
            RealRecord.InqOthDtlDiscGuid = userDetailRecord.InqOthDtlDiscGuid; // �⍇���斾�׎���GUID
            RealRecord.GoodsDivCd = userDetailRecord.GoodsDivCd; // ���i���
            RealRecord.RecyclePrtKindCode = userDetailRecord.RecyclePrtKindCode; // ���T�C�N�����i���
            RealRecord.RecyclePrtKindName = userDetailRecord.RecyclePrtKindName; // ���T�C�N�����i��ʖ���
            RealRecord.DeliveredGoodsDiv = userDetailRecord.DeliveredGoodsDiv; // �[�i�敪
            RealRecord.HandleDivCode = userDetailRecord.HandleDivCode; // �戵�敪
            RealRecord.GoodsShape = userDetailRecord.GoodsShape; // ���i�`��
            RealRecord.DelivrdGdsConfCd = userDetailRecord.DelivrdGdsConfCd; // �[�i�m�F�敪
            RealRecord.DeliGdsCmpltDueDate = userDetailRecord.DeliGdsCmpltDueDate; // �[�i�����\���
            RealRecord.AnswerDeliveryDate = userDetailRecord.AnswerDeliveryDate; // �񓚔[��
            RealRecord.BLGoodsCode = userDetailRecord.BLGoodsCode; // BL���i�R�[�h
            RealRecord.BLGoodsDrCode = userDetailRecord.BLGoodsDrCode; // BL���i�R�[�h�}��
            //RealRecord.GoodsName = userDetailRecord.GoodsName; // ���i���i�J�i�j
            RealRecord.InqGoodsName = userDetailRecord.InqGoodsName; // �┭���i��
            RealRecord.AnsGoodsName = userDetailRecord.AnsGoodsName; // �񓚏��i��
            RealRecord.SalesOrderCount = userDetailRecord.SalesOrderCount; // ������
            RealRecord.DeliveredGoodsCount = userDetailRecord.DeliveredGoodsCount; // �[�i��
            RealRecord.GoodsNo = userDetailRecord.GoodsNo; // ���i�ԍ�
            RealRecord.GoodsMakerCd = userDetailRecord.GoodsMakerCd; // ���i���[�J�[�R�[�h
            RealRecord.GoodsMakerNm = userDetailRecord.GoodsMakerNm; // ���i���[�J�[����
            RealRecord.PureGoodsMakerCd = userDetailRecord.PureGoodsMakerCd; // �������i���[�J�[�R�[�h
            //RealRecord.PureGoodsNo = userDetailRecord.PureGoodsNo; // �������i�ԍ�
            RealRecord.InqPureGoodsNo = userDetailRecord.InqPureGoodsNo; // �������i�ԍ�
            RealRecord.AnsPureGoodsNo = userDetailRecord.AnsPureGoodsNo; // �������i�ԍ�
            RealRecord.ListPrice = userDetailRecord.ListPrice; // �艿
            RealRecord.UnitPrice = userDetailRecord.UnitPrice; // �P��
            RealRecord.GoodsAddInfo = userDetailRecord.GoodsAddInfo; // ���i�⑫���
            RealRecord.RoughRrofit = userDetailRecord.RoughRrofit; // �e���z
            RealRecord.RoughRate = userDetailRecord.RoughRate; // �e����
            RealRecord.AnswerLimitDate = userDetailRecord.AnswerLimitDate; // �񓚊���
            RealRecord.CommentDtl = userDetailRecord.CommentDtl; // ���l(����)
            RealRecord.AppendingFileDtl = userDetailRecord.AppendingFileDtl; // �Y�t�t�@�C��(����)
            RealRecord.AppendingFileNmDtl = userDetailRecord.AppendingFileNmDtl; // �Y�t�t�@�C����(����)
            RealRecord.ShelfNo = userDetailRecord.ShelfNo; // �I��
            RealRecord.AdditionalDivCd = userDetailRecord.AdditionalDivCd; // �ǉ��敪
            RealRecord.CorrectDivCD = userDetailRecord.CorrectDivCD; // �����敪
            //RealRecord.AcptAnOdrStatus = userDetailRecord.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            //RealRecord.SalesSlipNum = userDetailRecord.SalesSlipNum; // ����`�[�ԍ�
            //RealRecord.SalesRowNo = userDetailRecord.SalesRowNo; // ����s�ԍ�
            //RealRecord.CampaignCode = userDetailRecord.CampaignCode; // �L�����y�[���R�[�h
            //RealRecord.StockDiv = userDetailRecord.StockDiv; // �݌ɋ敪
            RealRecord.InqOrdDivCd = userDetailRecord.InqOrdDivCd; // �⍇���E�������
            RealRecord.DisplayOrder = userDetailRecord.DisplayOrder; // �\������
            //RealRecord.GoodsMngNo = userDetailRecord.GoodsMngNo; // ���i�Ǘ��ԍ�
            // 2010/05/26 Add >>>
            RealRecord.CancelCndtinDiv = userDetailRecord.CancelCndtinDiv; // �L�����Z����ԋ敪
            RealRecord.AcptAnOdrStatus = userDetailRecord.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            RealRecord.SalesSlipNum = userDetailRecord.SalesSlipNum; // ����`�[�ԍ�
            RealRecord.SalesRowNo = userDetailRecord.SalesRowNo; // ����s�ԍ�
            // 2010/05/26 Add <<<
            // 2011/02/09 Add >>>
            RealRecord.DtlTakeinDivCd = userDetailRecord.DtlTakeinDivCd; // ���׎捞�敪
            // 2011/02/09 Add <<<
            // --- ADD m.suzuki 2011/05/23 ---------->>>>>
            RealRecord.WarehouseCode = userDetailRecord.PmWarehouseCd; // PM�q�ɃR�[�h
            RealRecord.WarehouseName = userDetailRecord.PmWarehouseName; // PM�q�ɖ���
            RealRecord.WarehouseShelfNo = userDetailRecord.PmShelfNo; // �I��
            // --- ADD m.suzuki 2011/05/23 ----------<<<<<

            // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
            RealRecord.PmPrsntCount = userDetailRecord.PmPrsntCount; // PM���݌�
            RealRecord.SetPartsMkrCd = userDetailRecord.SetPartsMkrCd; // �Z�b�g���i���[�J�[�R�[�h
            RealRecord.SetPartsNumber = userDetailRecord.SetPartsNumber; // �Z�b�g���i�ԍ�
            RealRecord.SetPartsMainSubNo = userDetailRecord.SetPartsMainSubNo; // �Z�b�g���i�e�q�ԍ�
            // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<

            RealRecord.CampaignCode = userDetailRecord.CampaignCode; // �L�����y�[���R�[�h  // ADD 2011/10/10

            // 2012/01/16 Add >>>
            RealRecord.GoodsSpecialNote = userDetailRecord.GoodsSpecialNote; // ���L����
            // 2012/01/16 Add <<<
            // --- ADD �g�� 2012/04/12 ��170 ---------->>>>>
            RealRecord.PSMngNo = userDetailRecord.PsMngNo; // PS�Ǘ��ԍ�
            // --- ADD �g�� 2012/04/12 ��170 ----------<<<<<

            // --- ADD T.Nishi 2012/05/30 ---------->>>>>
            RealRecord.AutoEstimatePartsCd = userDetailRecord.AutoEstimatePartsCd; // �������ϕ��i�R�[�h
            // --- ADD T.Nishi 2012/05/30 ----------<<<<<

            // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.SalesTotalTaxInc = userDetailRecord.SalesTotalTaxInc; // ����`�[���v�i�ō��j
            RealRecord.SalesTotalTaxExc = userDetailRecord.SalesTotalTaxExc; // ����`�[���v�i�Ŕ��j
            RealRecord.ScmConsTaxLayMethod = userDetailRecord.ScmConsTaxLayMethod; // SCM����œ]�ŕ���
            RealRecord.ConsTaxRate = userDetailRecord.ConsTaxRate; // ����Őŗ�
            RealRecord.ScmFractionProcCd = userDetailRecord.ScmFractionProcCd; // SCM�[�������敪
            RealRecord.AccRecConsTax = userDetailRecord.AccRecConsTax; // ���|�����
            RealRecord.PMSalesDate = userDetailRecord.PMSalesDate; // PM�����
            RealRecord.SuppSlpPrtTime = userDetailRecord.SuppSlpPrtTime; // �d����`�[���s����
            RealRecord.SalesMoneyTaxInc = userDetailRecord.SalesMoneyTaxInc; // ������z�i�ō��݁j
            RealRecord.SalesMoneyTaxExc = userDetailRecord.SalesMoneyTaxExc; // ������z�i�Ŕ����j
            // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.DataInputSystem = userDetailRecord.DataInputSystem; // �f�[�^���̓V�X�e��
            // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
            RealRecord.PrmSetDtlNo2 = userDetailRecord.PrmSetDtlNo2; // �D�ǐݒ�ڍ׃R�[�h�Q
            RealRecord.PrmSetDtlName2 = userDetailRecord.PrmSetDtlName2; // �D�ǐݒ�ڍז��̂Q
            RealRecord.StockStatusDiv = userDetailRecord.StockStatusDiv; // �݌ɏ󋵋敪
            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<
            // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
            RealRecord.RentDiv = userDetailRecord.RentDiv; // �ݏo�敪            
            RealRecord.MkrSuggestRtPric = userDetailRecord.MkrSuggestRtPric; // ���[�J�[��]�������i
            RealRecord.OpenPriceDiv = userDetailRecord.OpenPriceDiv; // �I�[�v�����i�敪    
            // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
            // ADD 2015/01/19 �L�� ���R�����h�Ή� --------------------->>>>>
            RealRecord.BgnGoodsDiv = userDetailRecord.BgnGoodsDiv; // ���������i�I���敪
            // ADD 2015/01/19 �L�� ���R�����h�Ή� ---------------------<<<<<
            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
            RealRecord.ModelPrtsAdptYm = userDetailRecord.ModelPrtsAdptYm; // �^���ʕ��i�̗p�N��
            RealRecord.ModelPrtsAblsYm = userDetailRecord.ModelPrtsAblsYm; // �^���ʕ��i�p�~�N��
            RealRecord.ModelPrtsAdptFrameNo = userDetailRecord.ModelPrtsAdptFrameNo; // �^���ʕ��i�̗p�ԑ�ԍ�
            RealRecord.ModelPrtsAblsFrameNo = userDetailRecord.ModelPrtsAblsFrameNo; // �^���ʕ��i�p�~�ԑ�ԍ�
            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.AnsDeliDateDiv = userDetailRecord.AnsDeliDateDiv; // �񓚔[���敪
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
            RealRecord.GoodsSpecialNtForFac = userDetailRecord.GoodsSpecialNtForFac;    // ���i�K�i�E���L����(�H�����)
            RealRecord.GoodsSpecialNtForCOw = userDetailRecord.GoodsSpecialNtForCOw;    // ���i�K�i�E���L����(�J�[�I�[�i�[����)
            RealRecord.PrmSetDtlName2ForFac = userDetailRecord.PrmSetDtlName2ForFac;    // �D�ǐݒ�ڍז��̂Q(�H�����)
            RealRecord.PrmSetDtlName2ForCOw = userDetailRecord.PrmSetDtlName2ForCOw;    // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<

            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.InqBlUtyPtThCd = userDetailRecord.InqBlUtyPtThCd;   // �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
            RealRecord.InqBlUtyPtSbCd = userDetailRecord.InqBlUtyPtSbCd;   // �┭BL���ꕔ�i�T�u�R�[�h
            RealRecord.AnsBlUtyPtThCd = userDetailRecord.AnsBlUtyPtThCd;   // ��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
            RealRecord.AnsBlUtyPtSbCd = userDetailRecord.AnsBlUtyPtSbCd;   // ��BL���ꕔ�i�T�u�R�[�h
            RealRecord.AnsBLGoodsCode = userDetailRecord.AnsBLGoodsCode;   // ��BL���i�R�[�h
            RealRecord.AnsBLGoodsDrCode = userDetailRecord.AnsBLGoodsDrCode;   // ��BL���i�R�[�h�}��
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            Initialize();
        }

        /// <summary>
        /// ���������܂��B
        /// </summary>
        private void Initialize()
        {
            RealRecord.UpdateDate = DateTime.MinValue;  // �X�V�N����
            RealRecord.UpdateTime = 0;                  // �X�V�����b�~���b
        }

        #region <User��WEB�ϊ�>
        /// <summary>
        /// UserDB����WebDB�ւ̋l�ւ�����(�⍇�����ƁA���_�͕ʓr�ݒ肪�K�v)
        /// </summary>
        /// <returns>SCM�󔭒����׃f�[�^(��)</returns>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
        /// </remarks>
        public WebSCMOrderAnswerRecord CopyToWebSCMOrderAnswerRecord()
        {
            RecordTypeWeb webRecord = new RecordTypeWeb();
            {
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
                webRecord.InqPureGoodsNo = RealRecord.InqPureGoodsNo; // �┭�������i�ԍ�
                webRecord.AnsPureGoodsNo = RealRecord.AnsPureGoodsNo; // �񓚏������i�ԍ�
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
                //webRecord.SalesRowNo = RealRecord.SalesRowNo; // ����s�ԍ�
                //webRecord.CampaignCode = RealRecord.CampaignCode; // �L�����y�[���R�[�h
                //webRecord.StockDiv = RealRecord.StockDiv; // �݌ɋ敪
                webRecord.InqOrdDivCd = RealRecord.InqOrdDivCd; // �⍇���E�������
                webRecord.DisplayOrder = RealRecord.DisplayOrder; // �\������
                //webRecord.GoodsMngNo = RealRecord.GoodsMngNo; // ���i�Ǘ��ԍ�
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

                // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
                webRecord.PmPrsntCount = RealRecord.PmPrsntCount; // PM���݌ɐ�
                webRecord.SetPartsMkrCd = RealRecord.SetPartsMkrCd; // �Z�b�g���i���[�J�[�R�[�h
                webRecord.SetPartsNumber = RealRecord.SetPartsNumber; // �Z�b�g���i�ԍ�
                webRecord.SetPartsMainSubNo = RealRecord.SetPartsMainSubNo; // �Z�b�g���i�e�q�ԍ�
                //// --- ADD LDNS wangqx 2011/08/08 ----------<<<<<
                webRecord.CampaignCode = RealRecord.CampaignCode; // �L�����y�[���R�[�h  // ADD 2011/10/10

                // 2012/01/16 Add >>>
                webRecord.GoodsSpecialNote = RealRecord.GoodsSpecialNote; // ���L����
                // 2012/01/16 Add <<<
                // --- ADD T.Nishi 2012/05/30 ---------->>>>>
                webRecord.AutoEstimatePartsCd = RealRecord.AutoEstimatePartsCd; // �������ϕ��i�R�[�h
                // --- ADD T.Nishi 2012/05/30 ----------<<<<<

                // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                webRecord.SalesTotalTaxInc = RealRecord.SalesTotalTaxInc; // ����`�[���v�i�ō��j
                // --- UPD 2013/06/13 Y.Wakita ---------->>>>>
                //webRecord.SalesTotalTaxInc = RealRecord.SalesTotalTaxExc; // ����`�[���v�i�Ŕ��j
                webRecord.SalesTotalTaxExc = RealRecord.SalesTotalTaxExc; // ����`�[���v�i�Ŕ��j
                // --- UPD 2013/06/13 Y.Wakita ----------<<<<<
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
                webRecord.ModelPrtsAblsYm = SCMEntityUtil.ConvertModelPrtsAblsYm(RealRecord.ModelPrtsAblsYm); // �^���ʕ��i�p�~�N��
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
            return new WebSCMOrderAnswerRecord(webRecord);
        }
        #endregion
    }
}
