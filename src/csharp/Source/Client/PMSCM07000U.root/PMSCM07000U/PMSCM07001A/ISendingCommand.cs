//****************************************************************************//
// �V�X�e��         : �ҋ@����
// �v���O��������   : ���M�R�}���h
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/06/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���M�R�}���h�C���^�[�t�F�[�X
    /// </summary>
    public interface ISendingCommand
    {
        /// <summary>
        /// ���̂��擾���܂��B
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ���s���܂��B
        /// </summary>
        /// <returns>�������ʃX�e�[�^�X</returns>
        int Execute();
    }

    /// <summary>
    /// �������Ȃ����M�R�}���h�N���X
    /// </summary>
    public sealed class NullSendingCommand : ISendingCommand
    {
        #region ISendingCommand �����o

        /// <summary>
        /// ���̂��擾���܂��B
        /// </summary>
        /// <see cref="ISendingCommand"/>
        public string Name
        {
            get { return "�������܂���"; }
        }

        /// <summary>
        /// ���s���܂��B
        /// </summary>
        /// <returns>�������ʃX�e�[�^�X(����I��)</returns>
        /// <see cref="ISendingCommand"/>
        public int Execute()
        {
            return 0;
        }

        #endregion // ISendingCommand �����o

        #region Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public NullSendingCommand() { }

        #endregion // Constructor
    }
}
