//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �o�i�ꊇ�X�V
// �v���O�����T�v   : �o�i�ꊇ�X�V
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : �v��
// �� �� �� : 2016/01/22   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : �v��
// �� �� �� : 2016/02/15   �C�����e : Redmine#48629�̏�Q�ꗗNo.1�́@M-045��M-046�̃��b�Z�[�W�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : �v��
// �� �� �� : 2016/02/15   �C�����e : Redmine#48629�̏�Q�ꗗNo.2�́@�̔��P���Ɣ������́u�����v�d�l�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : �v��
// �� �� �� : 2016/02/19   �C�����e : Redmine#48629�̏�Q�ꗗNo.237�@�`�F�b�N�����ɖ��̂ɃJ���}�ƃ_�u���N�E�H�[�e�[�V�������܂܂�Ă��Ȃ������菈���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : �v��
// �� �� �� : 2016/02/19   �C�����e : LDNS����������Q�@���b�Z�[�W�s��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���b�Z�[�W�ꗗ
    /// </summary>
    public class PMMAX02010UE
    {
        #region ���b�Z�[�W
        /// <summary></summary>
        public const string M_001 = "���Ӑ�R�[�h[{0}]�͑��݂��Ȃ����A�폜����Ă��܂��B";
        /// <summary></summary>
        public const string M_007 = "�`�F�b�N���X�g�ۑ���͑��݂��Ȃ����A�����݌���������܂���B";
        /// <summary></summary>
        public const string M_010 = "���iMAX���Ӑ����͂��Ă��������B\r\n�o�i�����o�^�̍ۂɓo�^���锄�����A���P���̎Z�o���邽�߂ɕK�v�ł��B";
        /// <summary></summary>
        public const string M_012 = "�o�i�ꊇ�X�V�������J�n���܂��B";
        /// <summary></summary>
        public const string M_013 = "��ʓ��͒l���������܂��B";
        /// <summary></summary>
        public const string M_014 = "�݌Ƀ}�X�^�𒊏o���܂��B";
        /// <summary></summary>
        public const string M_015 = "��ʓ��͒l�ɕs��������܂����̂ŁA�������I�����܂����B";
        /// <summary></summary>
        public const string M_016 = "���~�{�^���������ꂽ���߁A�����𒆎~���܂��B";
        /// <summary></summary>
        public const string M_017 = "�V�X�e���G���[���������܂����B\r\n[�X�e�[�^�X={0},���b�Z�[�W={1}]";
        // UPD BY �v�� 2016/02/15 FOR Redmine#48629�̏�Q�ꗗNo.2�́@�̔��P���Ɣ������́u�����v�d�l�ύX�Ή� ---->>>>>
        ///// <summary></summary>
        //public const string M_018 = "�������������l[{0}%]�ȉ��ƂȂ��Ă��܂��B";
        ///// <summary></summary>
        //public const string M_019 = "�̔��P���������l[{0}�~]�ȉ��ƂȂ��Ă��܂��B";
        ///// <summary></summary>
        //public const string M_020 = "�̔��P����1�~�ȉ��̏o�i�͍s���܂���B";
        /// <summary></summary>
        public const string M_018 = "�������������l[{0}%]�����ƂȂ��Ă��܂��B";
        /// <summary></summary>
        public const string M_019 = "�̔��P���������l[{0}�~]�����ƂȂ��Ă��܂��B";
        /// <summary></summary>
        public const string M_020 = "�̔��P����1�~�����̏o�i�͍s���܂���B";
        // UPD BY �v�� 2016/02/15 FOR Redmine#48629�̏�Q�ꗗNo.2�́@�̔��P���Ɣ������́u�����v�d�l�ύX�Ή� ----<<<<<
        /// <summary></summary>
        public const string M_021 = "�ꎟ�t�@�C�����o�͂��܂��B[{0}��]";
        /// <summary></summary>
        public const string M_023 = "�ꎟ�t�@�C���ۑ����ɃG���[���������܂����B\r\n[�X�e�[�^�X={0},���b�Z�[�W={1}]";
        /// <summary></summary>
        public const string M_024 = "�o�i�X�V������͌�����܂���ł����B";
        /// <summary></summary>
        public const string M_025 = "���iMAX�Ƀ��O�C���ł��܂���B�F�؏��Ɍ�܂肪����܂��B\r\n�ēx���͂��Ȃ����Ă��������B";
        /// <summary></summary>
        public const string M_026 = "���iMAX�ɏo�i�X�V����o�^���܂��B";
        /// <summary></summary>
        public const string M_027 = "���iMAX�ɐڑ��ł��܂���ł����B\r\n�C���^�[�l�b�g�ɐڑ�����Ă��鎖���m�F���Ă��������B";
        /// <summary></summary>
        // UPD BY �v�� 2016/02/19 FOR LDNS����������Q�@���b�Z�[�W�s�� ---->>>>>
        // public const string M_028 = "���iMAX�ɐڑ��ł��܂���ł����B[�X�e�[�^�X={0},���b�Z�[�W={1}]";
        public const string M_028 = "���iMAX�ɐڑ��ł��܂���ł����B\r\n[�X�e�[�^�X={0},���b�Z�[�W={1}]";
        // UPD BY �v�� 2016/02/19 FOR LDNS����������Q�@���b�Z�[�W�s�� ----<<<<<
        /// <summary></summary>
        public const string M_029 = "�o�i�X�V���̓o�^���ɕ��iMAX�ŃG���[���������܂����B\r\n[���iMAX�Ǘ����]-[�o�i�X�V���]��\�����A�o�i�X�V��񂪓o�^����Ă��邩���m�F���肢���܂��B\r\n�o�^����Ă��Ȃ��ꍇ�́A�ēx[�o�i�X�V]�{�^���������A���������Ȃ����Ă��������B";
        /// <summary></summary>
        public const string M_030 = "���iMAX�ւ̓o�^���������܂����B";
        /// <summary></summary>
        public const string M_031 = "���͒l��ۑ����Ă��܂��B";
        /// <summary></summary>
        public const string M_032 = "���͒l�̕ۑ����������܂����B";
        /// <summary></summary>
        public const string M_033 = "�o�i�X�V�������ɗ\�����ʃG���[���������܂����B\r\n[�X�e�[�^�X={0},���b�Z�[�W={1}]";
        /// <summary></summary>
        public const string M_034 = "�q�ɂɁA���iMAX�̑q�ɂ�1�ȏ�I�����Ă��������B";
        /// <summary></summary>
        public const string M_035 = "BL�R�[�h[{0}]�͑��݂��Ȃ����A�폜����Ă��܂��B";
        /// <summary></summary>
        public const string M_036 = "���[�J�[�R�[�h[{0}]�͑��݂��Ȃ����A�폜����Ă��܂��B";
        /// <summary></summary>
        public const string M_037 = "���i�|���O���[�v�R�[�h[{0}]�͑��݂��Ȃ����A�폜����Ă��܂��B";
        /// <summary></summary>
        public const string M_038 = "�d����R�[�h[{0}]�͑��݂��Ȃ����A�폜����Ă��܂��B";
        /// <summary></summary>
        public const string M_039 = "���i�Z�o������͂��Ă��������B";
        /// <summary></summary>
        public const string M_040 = "�x���ΏۂƂ��锄�����̉����l����͂��Ă��������B";
        /// <summary></summary>
        public const string M_041 = "�x���ΏۂƂ���̔��P���̉����l����͂��Ă��������B";
        /// <summary></summary>
        public const string M_042 = "�G���[�Ď捞���J�n���܂��B";
        /// <summary></summary>
        public const string M_043 = "���i�����ރR�[�h[{0}]�͑��݂��Ȃ����A�폜����Ă��܂��B";
        /// <summary></summary>
        public const string M_044 = "�������ɏ����_�ȉ����܂߂鎖�͂ł��܂���B���iMAX�ɓo�^����ۂɐ؂�̂Ă��܂��B";

        // UPD BY �v�� 2016/02/15 FOR Redmine#48629�̏�Q�ꗗNo.1�́@M-045��M-046�̃��b�Z�[�W�Ή� ---->>>>>
        ///// <summary></summary>
        //public const string M_045 = "�o�א��ɏ����_�ȉ����܂߂鎖�͂ł��܂���B���iMAX�ɓo�^����ۂɐ؂�̂Ă��܂��B";
        ///// <summary></summary>
        //public const string M_046 = "�o�א��ɏ����_�ȉ����܂߂鎖�͂ł��܂���B���iMAX�ɓo�^����ۂɐ؂�̂Ă��܂��B�o�א���1�����̏ꍇ�́A�o�^����܂���B���̖��ׂ͖�������܂��B";
        /// <summary></summary>
        public const string M_045 = "���݌ɐ��ɏ����_�ȉ����܂߂鎖�͂ł��܂���B���iMAX�ɓo�^����ۂɐ؂�̂Ă��܂��B";
        /// <summary></summary>
        public const string M_046 = "���݌ɐ���1�����̏ꍇ�́A�o�^����܂���B���̖��ׂ͖�������܂��B";
        // UPD BY �v�� 2016/02/15 FOR Redmine#48629�̏�Q�ꗗNo.1�́@M-045��M-046�̃��b�Z�[�W�Ή� ----<<<<<
        /// <summary></summary>
        public const string M_047 = "�݌Ƀ}�X�^�̒��o���ʂ��A10�����𒴂��Ă��܂��B\r\n���o�������i�荞��ł��������B";
        /// <summary></summary>
        public const string M_050 = "�s���ȕ������܂܂�Ă��܂��B���̂̏C�����s���ĉ������B"; // ADD BY �v�� 2016/02/19 FOR �`�F�b�N�����ɖ��̂ɃJ���}�ƃ_�u���N�E�H�[�e�[�V�������܂܂�Ă��Ȃ������菈���ǉ�
        #endregion
    }
}
