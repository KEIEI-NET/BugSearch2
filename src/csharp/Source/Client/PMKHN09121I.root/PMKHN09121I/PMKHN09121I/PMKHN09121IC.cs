//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : �Z�L�����e�B�Ǘ��C���^�[�t�F�[�X
// �v���O�����T�v   : �Z�L�����e�B�Ǘ��̎q�t�H�[���p�ݒ�C���^�t�F�[�X
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
    /// �Z�L�����e�B�Ǘ��ݒ�C���^�t�F�[�X
    /// </summary>
    public interface ISecurityManagementSetting
    {
        /// <summary>
        /// ����OperationSt�ɑΉ�����O���b�h�s��I����Ԃɂ��鏈�����s���܂��B
        /// </summary>
        /// <param name="operationSt">�I�����ׂ��s�ɑΉ�����I�y���[�V�����ݒ���</param>
        void Select(OperationSt operationSt);
    }

    #region <�X�e�[�^�X�o�[/>

    /// <summary>
    /// �X�e�[�^�X�o�[�ɕ\�����郁�b�Z�[�W�N���X
    /// </summary>
    public sealed class StatusBarMsg : EventArgs
    {
        /// <summary>���b�Z�[�W</summary>
        private readonly string _msg;
        /// <summary>
        /// ���b�Z�[�W���擾���܂��B
        /// </summary>
        /// <value>���b�Z�[�W</value>
        public string Msg
        {
            get { return _msg; }
        }

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public StatusBarMsg()
        {
            _msg = string.Empty;
        }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        public StatusBarMsg(string msg)
        {
            _msg = msg;
        }
    }

    /// <summary>
    /// �l���s���������Ƃ��̃C�x���g�n���h��
    /// </summary>
    /// <param name="sender">�C�x���g�\�[�X</param>
    /// <param name="statusBarMsg">�C�x���g�p�����[�^</param>
    public delegate void ValueIsInvalidEventHandler(
        object sender,
        StatusBarMsg statusBarMsg
    );

    /// <summary>
    /// �X�e�[�^�X�o�[�\���C���^�t�F�[�X
    /// </summary>
    public interface IStatusBarShowable
    {
        /// <summary>
        /// �X�e�[�^�X�o�[�ɕ\������Ƃ��̃C�x���g
        /// </summary>
        event ValueIsInvalidEventHandler ShowStatusBar;
    }

    #endregion  // <�X�e�[�^�X�o�[/>
}
