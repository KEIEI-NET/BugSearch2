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
// �Ǘ��ԍ�              �쐬�S�� : 22018�@��� ���b
// �� �� ��  2011/05/23  �C�����e : �e�[�u�����C�A�E�g�ύX�Ή�
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
// �C �� ��  2014/12/19  �C�����e : SCM������ PMNS�Ή� �ݏo�敪�A���[�J�[��]�������i�A�I�[�v�����i�敪�̒ǉ�
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

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// SCM�󒍖��׃f�[�^(��)�̃��R�[�h�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Update Note      :   2018/04/16 �c����</br>
    /// <br>�Ǘ��ԍ�         :   11470007-00</br>
    /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
    /// </remarks>
    public interface ISCMOrderAnswerRecord
    {
        /// <summary>
        /// �⍇������ƃR�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string InqOriginalEpCd { get; set; }

        /// <summary>
        /// �⍇�������_�R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string InqOriginalSecCd { get; set; }

        /// <summary>
        /// �⍇�����ƃR�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string InqOtherEpCd { get; set; }

        /// <summary>
        /// �⍇���拒�_�R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string InqOtherSecCd { get; set; }

        /// <summary>
        /// �⍇���ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        long InquiryNumber { get; set; }

        /// <summary>
        /// �X�V�N�������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        DateTime UpdateDate { get; set; }

        /// <summary>
        /// �X�V�����b�~���b���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int UpdateTime { get; set; }

        /// <summary>
        /// �⍇���s�ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int InqRowNumber { get; set; }

        /// <summary>
        /// �⍇���s�ԍ��}�Ԃ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int InqRowNumDerivedNo { get; set; }

        /// <summary>
        /// ���i��ʂ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int GoodsDivCd { get; set; }

        /// <summary>
        /// BL���i�R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int BLGoodsCode { get; set; }

        /// <summary>
        /// BL���i�R�[�h�}�Ԃ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int BLGoodsDrCode { get; set; }

        /// <summary>
        /// �┭���i�����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string InqGoodsName { get; set; }

        /// <summary>
        /// �񓚏��i�����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string AnsGoodsName { get; set; }

        /// <summary>
        /// ���i�ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string GoodsNo { get; set; }

        /// <summary>
        /// ���i���[�J�[�R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int GoodsMakerCd { get; set; }

        /// <summary>
        /// ���������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        double SalesOrderCount { get; set; }

        /// <summary>
        /// �[�i�����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        double DeliveredGoodsCount { get; set; }

        /// <summary>
        /// �艿���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        long ListPrice { get; set; }

        /// <summary>
        /// �P�����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        long UnitPrice { get; set; }

        /// <summary>
        /// �I�Ԃ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string ShelfNo { get; set; }

        /// <summary>
        /// �⍇���E������ʂ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int InqOrdDivCd { get; set; }

        /// <summary>
        /// ���T�C�N�����i��ʂ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int RecyclePrtKindCode { get; set; }

        /// <summary>
        /// ���T�C�N�����i��ʖ��̂��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string RecyclePrtKindName { get; set; }

        /// <summary>
        /// �񓚔[�����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string AnswerDeliveryDate { get; set; }

        /// <summary>
        /// �\�����ʂ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int DisplayOrder { get; set; }

        /// <summary>
        /// ��ƃR�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string EnterpriseCode { get; set; }

        /// <summary>
        /// �󒍃X�e�[�^�X���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int AcptAnOdrStatus { get; set; }

        /// <summary>
        /// ����`�[�ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string SalesSlipNum { get; set; }

        /// <summary>
        /// ����s�ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int SalesRowNo { get; set; }

        // 2010/05/26 Add >>>
        /// <summary>
        /// �L�����Z����ԋ敪���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        /// <remarks>0:�L�����Z���Ȃ� 10:�L�����Z���v�� 20:�L�����Z���p�� 30:�L�����Z���m��</remarks>
        short CancelCndtinDiv { get;set;}
        // 2010/05/26 Add <<<

        // 2011/02/09 Add >>>
        /// <summary>
        /// ���׎捞�敪���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int DtlTakeinDivCd { get; set; }
        // 2011/02/09 Add <<<

        // --- ADD m.suzuki 2011/05/23 ---------->>>>>
        /// <summary>
        /// ���l(����)���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string CommentDtl { get; set; }
        /// <summary>
        /// PM�q�ɃR�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string PmWarehouseCd { get; set; }
        /// <summary>
        /// PM�q�ɖ��̂��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string PmWarehouseName { get; set; }
        /// <summary>
        /// PM�I�Ԃ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string PmShelfNo { get; set; }
        // --- ADD m.suzuki 2011/05/23 ----------<<<<<
        // --- ADD 2011/08/08 ---------->>>>>�@�@
        /// <summary>
        /// PMPM���݌����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        double PmPrsntCount { get; set; }
        // --- ADD 2011/08/08 ----------<<<<<<

        // --- ADD LDNS tanh 2011/10/10 ----------<<<<<
        /// <summary>
        /// �L�����y�[���R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int CampaignCode { get; set; }
        // --- ADD LDNS tanh 2011/10/10 ----------<<<<<

        // 2012/01/16 Add >>>
        /// <summary>
        /// ���L�������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string GoodsSpecialNote { get; set; }
        // 2012/01/16 Add <<<
        // --- ADD T.Nishi 2012/05/30 ---------->>>>>
        /// <summary>
        /// �������ϕ��i�R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string AutoEstimatePartsCd { get; set; }
        // --- ADD T.Nishi 2012/05/30 ----------<<<<<

        // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ����`�[���v�i�ō��j���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        long SalesTotalTaxInc { get; set; }
        /// <summary>
        /// ����`�[���v�i�Ŕ��j���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        long SalesTotalTaxExc { get; set; }
        /// <summary>
        /// SCM����œ]�ŕ������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int ScmConsTaxLayMethod { get; set; }
        /// <summary>
        /// ����Őŗ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        double ConsTaxRate { get; set; }
        /// <summary>
        /// SCM�[�������敪���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int ScmFractionProcCd { get; set; }
        /// <summary>
        /// ���|����ł��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        long AccRecConsTax { get; set; }
        /// <summary>
        /// PM��������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int PMSalesDate { get; set; }
        /// <summary>
        /// �d����`�[���s�������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int SuppSlpPrtTime { get; set; }
        /// <summary>
        /// ������z�i�ō��݁j���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        long SalesMoneyTaxInc { get; set; }
        /// <summary>
        /// ������z�i�Ŕ����j���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        long SalesMoneyTaxExc { get; set; }
        // ADD 2013/05/08 �g�� 2013/06/18�z�M SCM��Q��10308,��10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> �f�[�^���̓V�X�e�����擾�܂��͐ݒ肵�܂��B </summary>
        int DataInputSystem { get; set; }
        // ADD 2013/05/15 �g�� 2013/06/18�z�M SCM��Q��10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
        /// <summary> 
        /// �D�ǐݒ�ڍ׃R�[�h�Q���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int PrmSetDtlNo2 { get; set; }
        /// <summary> 
        /// �D�ǐݒ�ڍז��̂Q���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string PrmSetDtlName2 { get; set; }
        /// <summary> 
        /// �݌ɏ󋵋敪�Q���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        short StockStatusDiv { get; set; }
        // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<

        // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
        /// <summary> 
        /// �ݏo�敪���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        short RentDiv { get; set; }
        /// <summary> 
        /// ���[�J�[��]�������i���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        long MkrSuggestRtPric { get; set; }
        /// <summary> 
        /// �I�[�v�����i�敪���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int OpenPriceDiv { get; set; }
        // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<

        // ADD 2015/01/19 �L�� ���R�����h�Ή� --------------------->>>>>
        /// <summary> 
        /// ���������i�I���敪���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        short BgnGoodsDiv { get; set; }
        // ADD 2015/01/19 �L�� ���R�����h�Ή� ---------------------<<<<<

        // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
        /// <summary> 
        /// �^���ʕ��i�̗p�N�����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int ModelPrtsAdptYm { get; set; }

        /// <summary> 
        /// �^���ʕ��i�p�~�N�����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int ModelPrtsAblsYm { get; set; }

        /// <summary> 
        /// �^���ʕ��i�̗p�ԑ�ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int ModelPrtsAdptFrameNo { get; set; }

        /// <summary> 
        /// �^���ʕ��i�p�~�ԑ�ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int ModelPrtsAblsFrameNo { get; set; }
        // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<

        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> �񓚔[���敪���擾�܂��͐ݒ肵�܂��B</summary>
        short AnsDeliDateDiv { get; set; }
        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
        /// <summary>���i�K�i�E���L����(�H�����)���擾�܂��͐ݒ肵�܂��B</summary>
        string GoodsSpecialNtForFac { get; set; }

        /// <summary>���i�K�i�E���L����(�J�[�I�[�i�[����)���擾�܂��͐ݒ肵�܂��B</summary>
        string GoodsSpecialNtForCOw { get; set; }

        /// <summary>�D�ǐݒ�ڍז��̂Q(�H�����)���擾�܂��͐ݒ肵�܂��B</summary>
        string PrmSetDtlName2ForFac { get; set; }

        /// <summary>�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)���擾�܂��͐ݒ肵�܂��B</summary>
        string PrmSetDtlName2ForCOw { get; set; }
        // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<

        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)���擾�܂��͐ݒ肵�܂��B</summary>
        string InqBlUtyPtThCd { get; set; }
       
        /// <summary>�┭BL���ꕔ�i�T�u�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        Int32 InqBlUtyPtSbCd { get; set; }

        /// <summary>��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)���擾�܂��͐ݒ肵�܂��B</summary>
        string AnsBlUtyPtThCd { get; set; }

        /// <summary>��BL���ꕔ�i�T�u�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        Int32 AnsBlUtyPtSbCd { get; set; }

        /// <summary>��BL���i�R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        Int32 AnsBLGoodsCode { get; set; }

        /// <summary>��BL���i�R�[�h�}�Ԃ��擾�܂��͐ݒ肵�܂��B</summary>
        Int32 AnsBLGoodsDrCode { get; set; }
        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// �L�[�ɕϊ����܂��B
        /// </summary>
        /// <returns>�L�[</returns>
        string ToKey();

        /// <summary>
        /// SCM�󒍃f�[�^�̊֘A�L�[�ɕϊ����܂��B
        /// </summary>
        /// <returns>SCM�󒍃f�[�^�̊֘A�L�[</returns>
        string ToRelationKey();

        /// <summary>
        /// ������Ƃ̊֘AGUID(������Ƃ̊֘A�t���ɗp���܂�)
        /// </summary>
        /// <remarks>�e�[�u�����C�A�E�g�ɂ͑��݂��܂���B</remarks>
        Guid SalesRelationId { get; set; }

        /// <summary>
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <returns>CSV</returns>
        string ToCSV();
    }
}
