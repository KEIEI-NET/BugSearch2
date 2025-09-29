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

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �P�̋N�����[�h�񓚑��M�����R���g���[���N���X
    /// </summary>
    public abstract class NormalModeController : SCMSendController
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
            get { return false; }
        }
        #endregion // </Override>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        protected NormalModeController() : base(string.Empty) { }

        #endregion // </Constructor>

        
    }
}
