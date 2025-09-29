//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : qijh  
// �� �� ��  2013/02/27  �C�����e : Redmine#34752
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/05/09  �C�����e : SCM��Q��10470�Ή��E���i�K�i�E���L�����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 31065 �L�� ���O
// �C �� ��  2015/01/19  �C�����e : SCM������ PMNS�Ή� ���ڒǉ� ���[�J�[��]�������i�A�I�[�v�����i�敪
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30745 �g��
// �C �� ��  2015/02/10  �C�����e : SCM������ �񓚔[���敪�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30746 ���� ��
// �C �� ��  2015/02/20  �C�����e : SCM������ C������ʁE���L�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2015/02/27  �C�����e : SCM������ �Z�b�g�i�ɗD�ǐݒ�ڍ׃R�[�h�Q�A�D�ǐݒ�ڍז��́A�݌ɏ󋵋敪�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470007-00 �쐬�S�� : �c����
// �C �� ��  2018/04/16  �C�����e : SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�
//----------------------------------------------------------------------------//


using System;

using Broadleaf.Application.UIData.WebDB;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.UIData
{
    using RecordType = Broadleaf.Application.Remoting.ParamData.SCMAcOdSetDtWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdSetDt;
    using Broadleaf.Library.Globarization;

    /// <summary>
    /// ���[�U�[DB SCM�󒍃Z�b�g���i�f�[�^�̃��R�[�h�N���X
    /// </summary>
    public class UserSCMAcOdSetDtRecord : UserSCMAcOdSetDtWrapper
    {
        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public UserSCMAcOdSetDtRecord() : base() { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realRecord">�{���̃��R�[�h</param>
        public UserSCMAcOdSetDtRecord(RecordType realRecord) : base(realRecord) { }

        #endregion // </Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^(Web��User�ϊ�)
        /// </summary>
        /// <param name="webRecord">SCM�󒍃Z�b�g���i�f�[�^</param>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
        /// </remarks>
        public UserSCMAcOdSetDtRecord(WebSCMAcOdSetDtRecord webRecord)
            : base(new RecordType())
        {
            RealRecord.CreateDateTime = webRecord.CreateDateTime; // �쐬����
            RealRecord.UpdateDateTime = webRecord.UpdateDateTime; // �X�V����
            RealRecord.LogicalDeleteCode = webRecord.LogicalDeleteCode; // �_���폜�敪
            RealRecord.InqOriginalEpCd = webRecord.InqOriginalEpCd.Trim(); // �⍇������ƃR�[�h//@@@@20230303
            RealRecord.InqOriginalSecCd = webRecord.InqOriginalSecCd; // �⍇�������_�R�[�h
            RealRecord.InqOtherEpCd = webRecord.InqOtherEpCd; // �⍇�����ƃR�[�h
            RealRecord.InqOtherSecCd = webRecord.InqOtherSecCd; // �⍇���拒�_�R�[�h
            RealRecord.InquiryNumber = webRecord.InquiryNumber; // �⍇���ԍ�
            RealRecord.SetPartsMkrCd = webRecord.SetPartsMkrCd; // �Z�b�g���i���[�J�[�R�[�h
            RealRecord.SetPartsNumber = webRecord.SetPartsNumber; // �Z�b�g���i�ԍ�
            RealRecord.SetPartsMainSubNo = webRecord.SetPartsMainSubNo; // �Z�b�g���i�e�q�ԍ�
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
            RealRecord.InqGoodsName = webRecord.InqGoodsName; // �┭���i��
            RealRecord.AnsGoodsName = webRecord.AnsGoodsName; // �񓚏��i��
            RealRecord.SalesOrderCount = webRecord.SalesOrderCount; // ������
            RealRecord.DeliveredGoodsCount = webRecord.DeliveredGoodsCount; // �[�i��
            RealRecord.GoodsNo = webRecord.GoodsNo; // ���i�ԍ�
            RealRecord.GoodsMakerCd = webRecord.GoodsMakerCd; // ���i���[�J�[�R�[�h
            RealRecord.GoodsMakerNm = webRecord.GoodsMakerNm; // ���i���[�J�[����
            RealRecord.PureGoodsMakerCd = webRecord.PureGoodsMakerCd; // �������i���[�J�[�R�[�h
            RealRecord.InqPureGoodsNo = webRecord.InqPureGoodsNo; // �┭�������i�ԍ�
            RealRecord.AnsPureGoodsNo = webRecord.AnsPureGoodsNo; // �񓚏������i�ԍ�
            RealRecord.ListPrice = webRecord.ListPrice; // �艿
            RealRecord.UnitPrice = webRecord.UnitPrice; // �P��
            RealRecord.GoodsAddInfo = webRecord.GoodsAddInfo; // ���i�⑫���
            RealRecord.RoughRrofit = webRecord.RoughRrofit; // �e���z
            RealRecord.RoughRate = webRecord.RoughRate; // �e����
            RealRecord.AnswerLimitDate = webRecord.AnswerLimitDate; // �񓚊���
            RealRecord.CommentDtl = webRecord.CommentDtl; // ���l(����)
            RealRecord.ShelfNo = webRecord.ShelfNo; // �I��
            RealRecord.PMAcptAnOdrStatus = webRecord.PMAcptAnOdrStatus; //PM�󒍃X�e�[�^�X
            RealRecord.PMSalesSlipNum = webRecord.PMSalesSlipNum; //PM����`�[�ԍ�
            RealRecord.PMSalesRowNo = webRecord.PMSalesRowNo; //PM����s�ԍ�
            RealRecord.PmWarehouseCd = webRecord.PmWarehouseCd; // PM�q�ɃR�[�h
            RealRecord.PmWarehouseName = webRecord.PmWarehouseName; // PM�q�ɖ���
            RealRecord.PmShelfNo = webRecord.PmShelfNo; // PM�I��
            RealRecord.PmPrsntCount = webRecord.PmPrsntCount; //PM���݌�
            // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
            RealRecord.GoodsSpclInstruction = webRecord.GoodsSpclInstruction; //���i�K�i�E���L����
            // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<
            // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� --------------------------------->>>>>
            RealRecord.MkrSuggestRtPric = webRecord.MkrSuggestRtPric; // ���[�J�[��]�������i
            RealRecord.OpenPriceDiv = webRecord.OpenPriceDiv; // �I�[�v�����i�敪
            // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.AnsDeliDateDiv = webRecord.AnsDeliDateDiv; // �񓚔[���敪
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
            RealRecord.GoodsSpecialNtForFac = webRecord.GoodsSpecialNtForFac;   // ���i�K�i�E���L����(�H�����)
            RealRecord.GoodsSpecialNtForCOw = webRecord.GoodsSpecialNtForCOw;   // ���i�K�i�E���L����(�J�[�I�[�i�[����)
            RealRecord.PrmSetDtlName2ForFac = webRecord.PrmSetDtlName2ForFac;   // �D�ǐݒ�ڍז��̂Q(�H�����)
            RealRecord.PrmSetDtlName2ForCOw = webRecord.PrmSetDtlName2ForCOw;   // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<
            // ADD 2015/02/27 SCM������ C������ʑΉ� -------------------------------->>>>>
            RealRecord.PrmSetDtlNo2 = webRecord.PrmSetDtlNo2;   // �D�ǐݒ�ڍ׃R�[�h�Q
            RealRecord.PrmSetDtlName2 = webRecord.PrmSetDtlName2;   // �D�ǐݒ�ڍז��̂Q
            RealRecord.StockStatusDiv = webRecord.StockStatusDiv;   // �݌ɏ󋵋敪
            // ADD 2015/02/27 SCM������ C������ʑΉ� --------------------------------<<<<<

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
        public UserSCMAcOdSetDtRecord(UserSCMAcOdSetDtRecord other)
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
            RealRecord.SetPartsMkrCd = other.SetPartsMkrCd; // �Z�b�g���i���[�J�[�R�[�h
            RealRecord.SetPartsNumber = other.SetPartsNumber; // �Z�b�g���i�ԍ�
            RealRecord.SetPartsMainSubNo = other.SetPartsMainSubNo; // �Z�b�g���i�e�q�ԍ�
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
            RealRecord.InqGoodsName = other.InqGoodsName; // �┭���i��
            RealRecord.AnsGoodsName = other.AnsGoodsName; // �񓚏��i��
            RealRecord.SalesOrderCount = other.SalesOrderCount; // ������
            RealRecord.DeliveredGoodsCount = other.DeliveredGoodsCount; // �[�i��
            RealRecord.GoodsNo = other.GoodsNo; // ���i�ԍ�
            RealRecord.GoodsMakerCd = other.GoodsMakerCd; // ���i���[�J�[�R�[�h
            RealRecord.GoodsMakerNm = other.GoodsMakerNm; // ���i���[�J�[����
            RealRecord.PureGoodsMakerCd = other.PureGoodsMakerCd; // �������i���[�J�[�R�[�h
            RealRecord.InqPureGoodsNo = other.InqPureGoodsNo; // �┭�������i�ԍ�
            RealRecord.AnsPureGoodsNo = other.AnsPureGoodsNo; // �񓚏������i�ԍ�
            RealRecord.ListPrice = other.ListPrice; // �艿
            RealRecord.UnitPrice = other.UnitPrice; // �P��
            RealRecord.GoodsAddInfo = other.GoodsAddInfo; // ���i�⑫���
            RealRecord.RoughRrofit = other.RoughRrofit; // �e���z
            RealRecord.RoughRate = other.RoughRate; // �e����
            RealRecord.AnswerLimitDate = other.AnswerLimitDate; // �񓚊���
            RealRecord.CommentDtl = other.CommentDtl; // ���l(����)
            RealRecord.ShelfNo = other.ShelfNo; // �I��
            RealRecord.PMAcptAnOdrStatus = other.PMAcptAnOdrStatus; //PM�󒍃X�e�[�^�X
            RealRecord.PMSalesSlipNum = other.PMSalesSlipNum; //PM����`�[�ԍ�
            RealRecord.PMSalesRowNo = other.PMSalesRowNo; //PM����s�ԍ�
            RealRecord.PmWarehouseCd = other.PmWarehouseCd; // PM�q�ɃR�[�h
            RealRecord.PmWarehouseName = other.PmWarehouseName; // PM�q�ɖ���
            RealRecord.PmShelfNo = other.PmShelfNo; // PM�I��
            RealRecord.PmPrsntCount = other.PmPrsntCount; //PM���݌�
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            RealRecord.PmMainMngWarehouseCd = other.PmMainMngWarehouseCd; // PM�q�ɃR�[�h
            RealRecord.PmMainMngWarehouseName = other.PmMainMngWarehouseName; // PM�q�ɖ���
            RealRecord.PmMainMngShelfNo = other.PmMainMngShelfNo; // PM�I��
            RealRecord.PmMainMngPrsntCount = other.PmMainMngPrsntCount; //PM���݌�
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
            // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
            RealRecord.GoodsSpclInstruction = other.GoodsSpclInstruction; //���i�K�i�E���L����
            // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<
            // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� --------------------------------->>>>>
            RealRecord.MkrSuggestRtPric = other.MkrSuggestRtPric; // ���[�J�[��]�������i
            RealRecord.OpenPriceDiv = other.OpenPriceDiv; // �I�[�v�����i�敪
            // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.AnsDeliDateDiv = other.AnsDeliDateDiv; // �񓚔[���敪
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
            RealRecord.GoodsSpecialNtForFac = other.GoodsSpecialNtForFac;   // ���i�K�i�E���L����(�H�����)
            RealRecord.GoodsSpecialNtForCOw = other.GoodsSpecialNtForCOw;   // ���i�K�i�E���L����(�J�[�I�[�i�[����)
            RealRecord.PrmSetDtlName2ForFac = other.PrmSetDtlName2ForFac;   // �D�ǐݒ�ڍז��̂Q(�H�����)
            RealRecord.PrmSetDtlName2ForCOw = other.PrmSetDtlName2ForCOw;   // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<
            // ADD 2015/02/27 SCM������ C������ʑΉ� -------------------------------->>>>>
            RealRecord.PrmSetDtlNo2 = other.PrmSetDtlNo2;   // �D�ǐݒ�ڍ׃R�[�h�Q
            RealRecord.PrmSetDtlName2 = other.PrmSetDtlName2;   // �D�ǐݒ�ڍז��̂Q
            RealRecord.StockStatusDiv = other.StockStatusDiv;   // �݌ɏ󋵋敪
            // ADD 2015/02/27 SCM������ C������ʑΉ� --------------------------------<<<<<

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
        /// <returns>SCM�󒍃Z�b�g���i�f�[�^</returns>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
        /// </remarks>
        public WebSCMAcOdSetDtRecord CopyToWebSCMAcOdSetDtRecord()
        {
            RecordTypeWeb webRecord = new RecordTypeWeb();
            {
                webRecord.CreateDateTime = RealRecord.CreateDateTime; // �쐬����
                webRecord.UpdateDateTime = RealRecord.UpdateDateTime; // �X�V����
                webRecord.LogicalDeleteCode = RealRecord.LogicalDeleteCode; // �_���폜�敪
                webRecord.InqOriginalEpCd = RealRecord.InqOriginalEpCd.Trim(); // �⍇������ƃR�[�h//@@@@20230303
                webRecord.InqOriginalSecCd = RealRecord.InqOriginalSecCd; // �⍇�������_�R�[�h
                webRecord.InqOtherEpCd = RealRecord.InqOtherEpCd; // �⍇�����ƃR�[�h
                webRecord.InqOtherSecCd = RealRecord.InqOtherSecCd; // �⍇���拒�_�R�[�h
                webRecord.InquiryNumber = RealRecord.InquiryNumber; // �⍇���ԍ�
                webRecord.SetPartsMkrCd = RealRecord.SetPartsMkrCd; // �Z�b�g���i���[�J�[�R�[�h
                webRecord.SetPartsNumber = RealRecord.SetPartsNumber; // �Z�b�g���i�ԍ�
                webRecord.SetPartsMainSubNo = RealRecord.SetPartsMainSubNo; // �Z�b�g���i�e�q�ԍ�
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
                webRecord.InqGoodsName = RealRecord.InqGoodsName; // �┭���i��
                webRecord.AnsGoodsName = RealRecord.AnsGoodsName; // �񓚏��i��
                webRecord.SalesOrderCount = RealRecord.SalesOrderCount; // ������
                webRecord.DeliveredGoodsCount = RealRecord.DeliveredGoodsCount; // �[�i��
                webRecord.GoodsNo = RealRecord.GoodsNo; // ���i�ԍ�
                webRecord.GoodsMakerCd = RealRecord.GoodsMakerCd; // ���i���[�J�[�R�[�h
                webRecord.GoodsMakerNm = RealRecord.GoodsMakerNm; // ���i���[�J�[����
                webRecord.PureGoodsMakerCd = RealRecord.PureGoodsMakerCd; // �������i���[�J�[�R�[�h
                webRecord.InqPureGoodsNo = RealRecord.InqPureGoodsNo; // �┭�������i�ԍ�
                webRecord.AnsPureGoodsNo = RealRecord.AnsPureGoodsNo; // �񓚏������i�ԍ�
                webRecord.ListPrice = RealRecord.ListPrice; // �艿
                webRecord.UnitPrice = RealRecord.UnitPrice; // �P��
                webRecord.GoodsAddInfo = RealRecord.GoodsAddInfo; // ���i�⑫���
                webRecord.RoughRrofit = RealRecord.RoughRrofit; // �e���z
                webRecord.RoughRate = RealRecord.RoughRate; // �e����
                webRecord.AnswerLimitDate = RealRecord.AnswerLimitDate; // �񓚊���
                webRecord.CommentDtl = RealRecord.CommentDtl; // ���l(����)
                webRecord.ShelfNo = RealRecord.ShelfNo; // �I��
                webRecord.PMAcptAnOdrStatus = RealRecord.PMAcptAnOdrStatus; //PM�󒍃X�e�[�^�X
                webRecord.PMSalesSlipNum = RealRecord.PMSalesSlipNum; // PM����`�[�ԍ�
                webRecord.PMSalesRowNo = RealRecord.PMSalesRowNo; //PM����s�ԍ�
                webRecord.PmWarehouseCd = RealRecord.PmWarehouseCd; // PM�q�ɃR�[�h
                webRecord.PmWarehouseName = RealRecord.PmWarehouseName; //PM�q�ɖ���
                webRecord.PmShelfNo = RealRecord.PmShelfNo; //PM�I��
                webRecord.PmPrsntCount = RealRecord.PmPrsntCount; //PM���݌�
                webRecord.DeliGdsCmpltDueDate = RealRecord.DeliGdsCmpltDueDate; //�[�i�����\���
                // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
                webRecord.GoodsSpclInstruction = RealRecord.GoodsSpclInstruction; //���i�K�i�E���L����
                // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<
                // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� --------------------------------->>>>>
                webRecord.MkrSuggestRtPric = RealRecord.MkrSuggestRtPric; // ���[�J�[��]�������i
                webRecord.OpenPriceDiv = RealRecord.OpenPriceDiv; // �I�[�v�����i�敪
                // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                webRecord.AnsDeliDateDiv = RealRecord.AnsDeliDateDiv; // �񓚔[���敪
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
                webRecord.GoodsSpecialNtForFac = RealRecord.GoodsSpecialNtForFac;   // ���i�K�i�E���L����(�H�����)
                webRecord.GoodsSpecialNtForCOw = RealRecord.GoodsSpecialNtForCOw;   // ���i�K�i�E���L����(�J�[�I�[�i�[����)
                webRecord.PrmSetDtlName2ForFac = RealRecord.PrmSetDtlName2ForFac;   // �D�ǐݒ�ڍז��̂Q(�H�����)
                webRecord.PrmSetDtlName2ForCOw = RealRecord.PrmSetDtlName2ForCOw;   // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
                // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<
                // ADD 2015/02/27 SCM������ C������ʑΉ� -------------------------------->>>>>
                webRecord.PrmSetDtlNo2 = RealRecord.PrmSetDtlNo2;   // �D�ǐݒ�ڍ׃R�[�h�Q
                webRecord.PrmSetDtlName2 = RealRecord.PrmSetDtlName2;   // �D�ǐݒ�ڍז��̂Q
                webRecord.StockStatusDiv = RealRecord.StockStatusDiv;   // �݌ɏ󋵋敪
                // ADD 2015/02/27 SCM������ C������ʑΉ� --------------------------------<<<<<

                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                webRecord.InqBlUtyPtThCd = RealRecord.InqBlUtyPtThCd;   // �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
                webRecord.InqBlUtyPtSbCd = RealRecord.InqBlUtyPtSbCd;   // �┭BL���ꕔ�i�T�u�R�[�h
                webRecord.AnsBlUtyPtThCd = RealRecord.AnsBlUtyPtThCd;   // ��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)
                webRecord.AnsBlUtyPtSbCd = RealRecord.AnsBlUtyPtSbCd;   // ��BL���ꕔ�i�T�u�R�[�h
                webRecord.AnsBLGoodsCode = RealRecord.AnsBLGoodsCode;   // ��BL���i�R�[�h
                webRecord.AnsBLGoodsDrCode = RealRecord.AnsBLGoodsDrCode;   // ��BL���i�R�[�h�}��
                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            return new WebSCMAcOdSetDtRecord(webRecord);
        }
        #endregion
    }
}
