//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/05/09  �C�����e : SCM��Q��10470�Ή��E���i�K�i�E���L�����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 31065 �L�� ���O
// �C �� ��  2015/01/19  �C�����e : SCM������ PMNS�Ή� �Z�b�g�i�Ƀ��[�J�[��]�������i�A�I�[�v�����i�敪�̒ǉ�
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

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// SCM�󒍃Z�b�g���i�f�[�^�̃��R�[�h�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Update Note      :   2018/04/16 �c����</br>
    /// <br>�Ǘ��ԍ�         :   11470007-00</br>
    /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
    /// </remarks>
    public interface ISCMAcOdSetDtRecord
    {
        /// <summary>
        /// ��ƃR�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string EnterpriseCode { get; set; }

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
        /// �Z�b�g���i���[�J�[�R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int SetPartsMkrCd { get; set; }

        /// <summary>
        /// �Z�b�g���i�ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string SetPartsNumber { get; set; }

        /// <summary>
        /// �Z�b�g���i�e�q�ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int SetPartsMainSubNo { get; set; }

        /// <summary>
        /// ���i��ʂ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int GoodsDivCd { get; set; }

        /// <summary>
        /// ���T�C�N�����i��ʂ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int RecyclePrtKindCode { get; set; }

        /// <summary>
        /// ���T�C�N�����i��ʖ��̂��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string RecyclePrtKindName { get; set; }

        /// <summary>
        /// �[�i�敪���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int DeliveredGoodsDiv { get; set; }

        /// <summary>
        /// �戵�敪���̂��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int HandleDivCode { get; set; }

        /// <summary>
        /// ���i�`�Ԃ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int GoodsShape { get; set; }

        /// <summary>
        /// �[�i�m�F�敪���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int DelivrdGdsConfCd { get; set; }

        /// <summary>
        /// �񓚔[�����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string AnswerDeliveryDate { get; set; }

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
        /// ���������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        double SalesOrderCount { get; set; }

        /// <summary>
        /// �[�i�����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        double DeliveredGoodsCount { get; set; }

        /// <summary>
        /// ���i�ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string GoodsNo { get; set; }

        /// <summary>
        /// ���i���[�J�[�R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int GoodsMakerCd { get; set; }

        /// <summary>
        /// ���i���[�J�[���̂��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string GoodsMakerNm { get; set; }

        /// <summary>
        /// �������i���[�J�[�R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int PureGoodsMakerCd { get; set; }

        /// <summary>
        /// �┭�������i�ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string InqPureGoodsNo { get; set; }

        /// <summary>
        /// �񓚏������i�ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string AnsPureGoodsNo { get; set; }

        /// <summary>
        /// �艿���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        long ListPrice { get; set; }

        /// <summary>
        /// �P�����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        long UnitPrice { get; set; }

        /// <summary>
        /// ���i�⑫�����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string GoodsAddInfo { get; set; }

        /// <summary>
        /// �e���z���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        long RoughRrofit { get; set; }

        /// <summary>
        /// �e�������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        double RoughRate { get; set; }

        /// <summary>
        /// �񓚊������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        DateTime AnswerLimitDate { get; set; }

        /// <summary>
        /// ���l(����)���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string CommentDtl { get; set; }

        /// <summary>
        /// �I�Ԃ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string ShelfNo { get; set; }

        /// <summary>
        /// PM�󒍃X�e�[�^�X���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int PMAcptAnOdrStatus { get; set; }

        /// <summary>
        /// PM����`�[�ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int PMSalesSlipNum { get; set; }

        /// <summary>
        /// PM����s�ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int PMSalesRowNo { get; set; }

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

        /// <summary>
        /// PM���݌����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        double PmPrsntCount { get; set; }

        /// <summary>
        /// �[�i�����\������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        DateTime DeliGdsCmpltDueDate { get; set; }
        
        // ADD 2013/05/09 SCM��Q��10470�Ή� ----------------------------------------->>>>>
        /// <summary>
        /// ���i�K�i�E���L�������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string GoodsSpclInstruction { get; set; }

        // ADD 2013/05/09 SCM��Q��10470�Ή� -----------------------------------------<<<<<

        // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� --------------------------------->>>>>
        /// <summary> 
        /// ���[�J�[��]�������i���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        long MkrSuggestRtPric { get; set; }
        /// <summary> 
        /// �I�[�v�����i�敪���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int OpenPriceDiv { get; set; }
        // ADD 2015/01/19 �L�� SCM������ PMNS�Ή� ---------------------------------<<<<<

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

        // ADD 2015/02/27 SCM������ C������ʑΉ� -------------------------------->>>>>
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q���擾�܂��͐ݒ肵�܂��B</summary>
        int PrmSetDtlNo2 { get; set; }

        /// <summary>�D�ǐݒ�ڍז��̂Q���擾�܂��͐ݒ肵�܂��B</summary>
        string PrmSetDtlName2 { get; set; }

        /// <summary>�݌ɏ󋵋敪���擾�܂��͐ݒ肵�܂��B</summary>
        short StockStatusDiv { get; set; }
        // ADD 2015/02/27 SCM������ C������ʑΉ� --------------------------------<<<<<

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

        ///// <summary>
        ///// �L�[�ɕϊ����܂��B
        ///// </summary>
        ///// <returns>�L�[</returns>
        //string ToKey();

        ///// <summary>
        ///// SCM�󒍃f�[�^�̊֘A�L�[�ɕϊ����܂��B
        ///// </summary>
        ///// <returns>SCM�󒍃f�[�^�̊֘A�L�[</returns>
        //string ToRelationKey();

        ///// <summary>
        ///// ������Ƃ̊֘AGUID(������Ƃ̊֘A�t���ɗp���܂�)
        ///// </summary>
        ///// <remarks>�e�[�u�����C�A�E�g�ɂ͑��݂��܂���B</remarks>
        //Guid SalesRelationId { get; set; }

        /// <summary>
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <returns>CSV</returns>
        string ToCSV();
    }
}
