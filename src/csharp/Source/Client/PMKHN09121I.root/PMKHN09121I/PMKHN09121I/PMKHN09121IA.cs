//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : �Z�L�����e�B�Ǘ��C���^�[�t�F�[�X
// �v���O�����T�v   : �Z�L�����e�B�Ǘ��̎q�t�H�[���p���ʃC���^�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/07/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// �Z�L�����e�B�Ǘ��t�H�[���R���g���[���C���^�[�t�F�[�X
    /// </summary>
    public interface ISecurityManagementForm
    {
        /// <summary>
        /// �ۑ��{�^����\������t���O
        /// </summary>
        /// <value>true :�ۑ��{�^����\��<br/>false:�ۑ��{�^�����\��</value>
        bool CanWrite { get; }

        /// <summary>
        /// �\���X�V�{�^����\������t���O
        /// </summary>
        /// <value>true :�\���X�V�{�^����\��<br/>false:�\���X�V�{�^�����\��</value>
        bool CanUpdateDisplay { get; }

        /// <summary>
        /// �ۑ��{�^���������̏������s���܂��B
        /// </summary>
        /// <returns>�������� 0(=(int)ResultCode.Normal) ��Ԃ��܂��B </returns>
        int Write();

        /// <summary>
        /// �\���X�V�{�^���������̏������s���܂��B
        /// </summary>
        void UpdateDisplay();

        /// <summary>
        /// �Ή�����^�u���A�N�e�B�u�ɂȂ������̏������s���܂��B
        /// </summary>
        void Active();
    }

    /// <summary>
    /// ���ʃR�[�h�񋓑�
    /// </summary>
    public enum ResultCode : int
    {
        /// <summary>����</summary>
        Normal = 0,
        /// <summary>�ُ�</summary>
        Error
    }
}
