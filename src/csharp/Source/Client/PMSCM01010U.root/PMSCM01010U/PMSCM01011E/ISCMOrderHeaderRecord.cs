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
// �Ǘ��ԍ�              �쐬�S�� : 30434�@�H�� �b�D
// �� �� ��  2010/06/30  �C�����e : �u�񓚍쐬�敪�v��ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018�@��� ���b
// �� �� ��  2011/05/23  �C�����e : �e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/08/10  �C�����e : PCCUOE������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902175-00 �쐬�S�� : �e�c ���V
// �� �� ��  2013/06/24  �C�����e : �^�u���b�g�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/05/24  �C�����e : SCM��Q��10537�Ή� �ԗ��Ǘ��R�[�h�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/12/19  �C�����e : SCM������ PMNS�Ή� �����񓚕����̒ǉ�
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// SCM�󒍃f�[�^�̃��R�[�h�C���^�[�t�F�[�X
    /// </summary>
    public interface ISCMOrderHeaderRecord
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
        /// �񓚋敪���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int AnswerDivCd { get; set; }

        /// <summary>
        /// �⍇���E�������
        /// </summary>
        string InqOrdNote { get; set; }

        /// <summary>
        /// �񓚏]�ƈ��R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string AnsEmployeeCd { get; set; }

        /// <summary>
        /// �񓚏]�ƈ����̂��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string AnsEmployeeNm { get; set; }

        /// <summary>
        /// �⍇�������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        DateTime InquiryDate { get; set; }

        /// <summary>
        /// �┭�E�񓚎�ʂ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int InqOrdAnsDivCd { get; set; }

        /// <summary>
        /// ��M�������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        DateTime ReceiveDateTime { get; set; }

        /// <summary>
        /// ��ƃR�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string EnterpriseCode { get; set; }

        /// <summary>
        /// ���Ӑ�R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int CustomerCode { get; set; }

        /// <summary>
        /// �⍇���E������ʂ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int InqOrdDivCd { get; set; }

        /// <summary>
        /// �󒍃X�e�[�^�X���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int AcptAnOdrStatus { get; set; }

        /// <summary>
        /// ����`�[�ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string SalesSlipNum { get; set; }

        /// <summary>
        /// ����`�[���v(�ō���)���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        long SalesTotalTaxInc { get; set; }

        // ADD 2010/06/30 �u�񓚍쐬�敪�v��ǉ� ---------->>>>>
        /// <summary>
        /// �񓚍쐬�敪���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int AnswerCreateDiv { get; set; }
        // ADD 2010/06/30 �u�񓚍쐬�敪�v��ǉ� ----------<<<<<

        // 2010/05/26 Add >>>
        /// <summary>
        /// �L�����Z���敪���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        short CancelDiv { get;set;}

        /// <summary>
        /// CMT�A�g�敪���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        short CMTCooprtDiv { get;set;}
        // 2010/05/26 Add <<<

        // --- ADD m.suzuki 2011/05/23 ---------->>>>>
        /// <summary>
        /// �m������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        DateTime JudgementDate { get;set;}
        /// <summary>
        /// SF-PM�A�g�w�����ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string SfPmCprtInstSlipNo { get;set;}
        // --- ADD m.suzuki 2011/05/23 ----------<<<<<

        // ----- ADD 2011/08/10 ----- >>>>>
        /// <summary>
        /// �󔭒���ʂ��擾�܂��͐ݒ肵�܂��B
        /// </summary>
        Int16 AcceptOrOrderKind { get;set;}
        // ----- ADD 2011/08/10 ----- <<<<<

        // --- ADD 2013/06/24 Y.Wakita ---------->>>>>
        /// <summary>
        /// �^�u���b�g�g�p�敪���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int TabUseDiv { get; set; }
        // --- ADD 2013/06/24 Y.Wakita ----------<<<<<
        	
        // ADD 2013/05/24 SCM��Q��10537�Ή� ---------------------------------->>>>>
        /// <summary>
        /// �ԗ��Ǘ��R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string CarMngCode { get;set;}
        // ADD 2013/05/24 SCM��Q��10537�Ή� ----------------------------------<<<<<

        // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
        /// <summary>
        /// �����񓚕������擾�܂��͐ݒ肵�܂��B
        /// </summary>
        Int16 AutoAnsMthd { get; set; }
        // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<

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
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <returns>CSV</returns>
        string ToCSV();
    }
}
