//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : �Z�L�����e�B�Ǘ��C���^�[�t�F�[�X
// �v���O�����T�v   : �Z�L�����e�B�Ǘ��̎q�t�H�[���p�Ɖ�C���^�t�F�[�X
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
    /// �O���b�h���I�����ꂽ�Ƃ��̃C�x���g�n���h��
    /// </summary>
    /// <param name="sender">�O���b�h�̐e�I�u�W�F�N�g</param>
    /// <param name="operationSt">�I�����ꂽ�s�ɑ΂���I�y���[�V�������</param>
    public delegate void GridSelectedEventHandler(
        object sender,
        OperationSt operationSt
    );

    /// <summary>
    /// �Z�L�����e�B�Ǘ��Ɖ�C���^�t�F�[�X
    /// </summary>
    public interface ISecurityManagementView
    {
        /// <summary>
        /// �s�_�u���N���b�N���ꂽ�Ƃ��ɔ���������C�x���g
        /// </summary>
        event GridSelectedEventHandler Selected;
    }
}
