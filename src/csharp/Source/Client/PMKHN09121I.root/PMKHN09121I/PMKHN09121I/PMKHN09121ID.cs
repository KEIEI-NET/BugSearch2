//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : �Z�L�����e�B�Ǘ��C���^�[�t�F�[�X
// �v���O�����T�v   : �Z�L�����e�B�Ǘ��̃I�y���[�V�����ݒ����ێ����܂��B
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
    /// �Z�L�����e�B�Ǘ��I�y���[�V�����ݒ���C�x���g�p�����[�^�N���X
    /// </summary>
    public sealed class OperationSt : EventArgs
    {
        /// <summary>�I�����ꂽ�O���b�h�̍s</summary>
        private readonly object _selectedGridRow;
        /// <summary>
        /// �I�����ꂽ�O���b�h�̍s���擾���܂��B
        /// </summary>
        /// <value>�I�����ꂽ�O���b�h�̍s</value>
        public object SelectedGridRow
        {
            get { return _selectedGridRow; }
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="selectedGridRow">�I�����ꂽ�O���b�h�̍s</param>
        public OperationSt(object selectedGridRow)
        {
            _selectedGridRow = selectedGridRow;
        }
    }
}
