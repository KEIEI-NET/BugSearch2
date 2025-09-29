//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/08/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Windows.Forms;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �蓮�񓚏����̃R���t�B�O�N���X
    /// </summary>
    public sealed class SCMManualConfig
    {
        #region <���L�҃t�H�[��>

        /// <summary>���L�҃t�H�[��</summary>
        private readonly IWin32Window _ownerForm;
        /// <summary>���L�҃t�H�[�����擾�܂��͐ݒ肵�܂��B</summary>
        public IWin32Window OwnerForm { get { return _ownerForm; } }

        #endregion // </���L�҃t�H�[��>

        #region <�蓮��������>

        /// <summary>�蓮��������</summary>
        private readonly GoodsCndtn _seachingConditionManually;
        /// <summary>�蓮�����������擾���܂��B</summary>
        public GoodsCndtn SeachingConditionManually { get { return _seachingConditionManually; } }

        #endregion // </�蓮��������>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="ownerForm">���L�҃t�H�[��</param>
        /// <param name="seachingConditionManually">�蓮��������</param>
        public SCMManualConfig(
            IWin32Window ownerForm,
            GoodsCndtn seachingConditionManually
        )
        {
            _ownerForm = ownerForm;
            _seachingConditionManually = seachingConditionManually;
        }

        #endregion // </Constructor>
    }
}
