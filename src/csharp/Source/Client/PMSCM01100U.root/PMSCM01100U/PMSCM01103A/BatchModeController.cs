//****************************************************************************//
// �V�X�e��         : �񓚑��M����
// �v���O��������   : �񓚑��M�����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/06/03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���M�N�����[�h�񓚑��M�����R���g���[���N���X
    /// </summary>
    public abstract class BatchModeController : SCMSendController
    {
        #region <Override>

        /// <summary>
        /// �o�b�`����(���M�N�����[�h)�ł��邩���f���܂��B
        /// </summary>
        /// <value>
        /// <c>true</c> :�o�b�`����(���M�N�����[�h)�ł��B<br/>
        /// <c>false</c>:�Θb����(�P�̋N�����[�h)�ł��B
        /// </value>
        /// <see cref="SCMSendController"/>
        public override bool IsBatchMode
        {
            get { return true; }
        }

        #endregion // </Override>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="path">�f�[�^�p�X</param>
        protected BatchModeController(string path) : base(path) { }

        #endregion // </Constructor>
    }
}
