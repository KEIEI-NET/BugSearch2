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
// �� �� ��  2010/03/17  �C�����e : �J���[�A�g�����A�N���̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS wangqx
// �� �� ��  2010/08/08  �C�����e : ���ԁA���[�J�[���́A�O���[�h���́A
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�{�f�B�[���́A�h�A���A�G���W���^�����́A
//                                  �ʏ̔r�C�ʁA�����@�^���i�G���W���j�A�ϑ��i���A
//                                  �ϑ��@���́AE�敪���́A�~�b�V�������́A
//                                  �V�t�g���̂̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS�̗���
// �� �� ��  2011/09/01  �C�����e : �����񓚑Ή��A�Ԍ��،^����ǉ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/05/31  �C�����e : ��Q��10277 SCM�󒍃f�[�^(�ԗ����)�������̐ݒ���@�̕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/06/06  �C�����e : ��Q��178   �ԑ�ԍ��̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/04/19  �C�����e : SCM��Q��10521�Ή� SCM�󒍃f�[�^�i�ԗ����j�Ɏԗ��Ǘ��R�[�h�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/05/09  �C�����e : ��Q��10384 SCM�󒍃f�[�^(�ԗ����)�ɓ��ɗ\�����ǉ�
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// SCM�󒍃f�[�^(�ԗ����)�̃��R�[�h�C���^�[�t�F�[�X
    /// </summary>
    public interface ISCMOrderCarRecord
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
        /// �⍇���ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        long InquiryNumber { get; set; }

        /// <summary>
        /// �ޕʔԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int CategoryNo { get; set; }

        /// <summary>
        /// �Ԏ햼���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string ModelName { get; set; }

        /// <summary>
        /// �^���w��ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int ModelDesignationNo { get; set; }

        /// <summary>
        /// �ԗ��o�^�ԍ��i�v���[�g�ԍ��j���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int NumberPlate4 { get; set; }

        /// <summary>
        /// ���[�J�[�R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int MakerCode { get; set; }

        /// <summary>
        /// �Ԏ�R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int ModelCode { get; set; }

        /// <summary>
        /// �Ԏ�T�u�R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int ModelSubCode { get; set; }

        //--- ADD 2011/09/01 -------------------------------------------->>>
        /// <summary>
        /// �Ԍ��،^�����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string CarInspectCertModel { get; set; }
        //--- ADD 2011/09/01 --------------------------------------------<<<

        /// <summary>
        /// �^��(�t���^)���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string FullModel { get; set; }

        // 2010/03/17 Add >>>
        /// <summary>
        /// ���y�A�J���[�R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string RpColorCode { get;set;}

        /// <summary>
        /// ���Y�N���iNUM�^�C�v�j���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int ProduceTypeOfYearNum { get;set;}

        /// <summary>
        /// �g�����R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string TrimCode { get;set;}
        // 2010/03/17 Add <<<

        // 2011/03/08 Add >>>
        /// <summary>
        /// �V���V�[�����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string ChassisNo { get;set;}
        // 2011/03/08 Add <<<

        /// <summary>
        /// �󒍃X�e�[�^�X���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        int AcptAnOdrStatus { get; set; }

        /// <summary>
        /// ����`�[�ԍ����擾�܂��͐ݒ肵�܂��B
        /// </summary>
        string SalesSlipNum { get; set; }
        // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
        /// <summary>
        /// ����
        /// </summary>
        string CarNo { get; set; }
        /// <summary>
        /// ���[�J�[����
        /// </summary>
        string MakerName { get; set; }
        /// <summary>
        /// �O���[�h����
        /// </summary>
        string GradeName { get; set; }
        /// <summary>
        /// �{�f�B�[����
        /// </summary>
        string BodyName { get; set; }
        /// <summary>
        /// �h�A��
        /// </summary>
        int DoorCount { get; set; }
        /// <summary>
        /// �G���W���^������
        /// </summary>
        string EngineModelNm { get; set; }
        /// <summary>
        /// �ʏ̔r�C��
        /// </summary>
        int CmnNmEngineDisPlace { get; set; }
        /// <summary>
        /// �����@�^���i�G���W���j
        /// </summary>
        string EngineModel { get; set; }
        /// <summary>
        /// �ϑ��i��
        /// </summary>
        int NumberOfGear { get; set; }
        /// <summary>
        /// �ϑ��@����
        /// </summary>
        string GearNm { get; set; }
        /// <summary>
        /// E�敪����
        /// </summary>
        string EDivNm { get; set; }
        
        /// <summary>
        /// �~�b�V��������
        /// </summary>
        string TransmissionNm { get; set; }
        /// <summary>
        /// �V�t�g����
        /// </summary>
        string ShiftNm { get; set; }
        // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<

        // ADD 2012/05/31 -------------------------->>>>>
        /// <summary>
        /// ���N�x�iNUM�^�C�v�j
        /// </summary>
        Int32 FirstEntryDateNumTyp { get; set; }
        /// <summary>
        /// �ԗ��t�����I�u�W�F�N�g
        /// </summary>
        Byte[] CarAddInf { get; set; }
        /// <summary>
        /// �������i�I�u�W�F�N�g
        /// </summary>
        Byte[] EquipPrtsObj { get; set; }
        // ADD 2012/05/31 --------------------------<<<<<

        // ADD 2012/06/06 -------------------------->>>>>
        /// <summary>
        /// �ԑ�ԍ�
        /// </summary>
        string FrameNo { get; set; }
        // ADD 2012/06/06 --------------------------<<<<<

        // ADD 2013/04/19 SCM��Q��10521�Ή� ----------------------------------->>>>>
        /// <summary>
        /// �ԗ��Ǘ��R�[�h
        /// </summary>
        string CarMngCode { get; set; }
        // ADD 2013/04/19 SCM��Q��10521�Ή� -----------------------------------<<<<<

        // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
        /// <summary>
        /// ���ɗ\���
        /// </summary>
        Int32 ExpectedCeDate { get; set; }
        // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<

        /// <summary>
        /// �L�[�ɕϊ����܂��B
        /// </summary>
        /// <returns>�L�[</returns>
        string ToKey();

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
