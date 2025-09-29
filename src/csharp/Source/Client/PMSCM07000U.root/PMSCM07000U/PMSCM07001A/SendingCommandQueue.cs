//****************************************************************************//
// �V�X�e��         : NS�ҋ@����
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
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���M�R�}���h�̑҂��s��N���X
    /// </summary>
    public sealed class SendingCommandQueue
    {
        #region �҂��s��

        /// <summary>���M�R�}���h�̑҂��s��</summary>
        private readonly Queue<ISendingCommand> _commandQueue = new Queue<ISendingCommand>();
        /// <summary>���M�R�}���h�̑҂��s����擾���܂��B</summary>
        private Queue<ISendingCommand> CommandQueue { get { return _commandQueue; } }

        #endregion // �҂��s��

        #region Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SendingCommandQueue() { }

        #endregion // Constructor

        /// <summary>
        /// ���M�R�}���h�����݂��邩���f���܂��B
        /// </summary>
        public bool ExistsCommand
        {
            get { return CommandQueue.Count > 0; }
        }

        /// <summary>
        /// �҂��s��ɒǉ����܂��B
        /// </summary>
        /// <param name="command">���M�R�}���h</param>
        public void Enqueue(ISendingCommand command)
        {
            CommandQueue.Enqueue(command);
        }

        /// <summary>
        /// �҂��s�񂩂���o���܂��B
        /// </summary>
        /// <returns>���M�R�}���h</returns>
        public ISendingCommand Dequeue()
        {
            if (!ExistsCommand) return new NullSendingCommand();

            return CommandQueue.Dequeue();
        }
    }
}
