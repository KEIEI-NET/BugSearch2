//****************************************************************************//
// �V�X�e��         : �񓚑��M����
// �v���O��������   : �񓚑��M�����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H��
// �� �� ��  2009/09/02  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// SCM�n�f�[�^�t�@�C�����I�[�v�����̗�O�N���X
    /// </summary>
    public sealed class SCMFileOpeningException : ApplicationException
    {
        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="innerException">���ƂȂ�����O</param>
        public SCMFileOpeningException(
            string message,
            Exception innerException
        ) : base(message, innerException)
        { }
    }
}
