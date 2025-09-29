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
// �� �� ��  2009/05/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.UIData.WebDB
{
    using RecordType = Broadleaf.Application.UIData.ScmOdrData;

    /// <summary>
    /// Web-DB SCM�󔭒��f�[�^�̃��R�[�h�N���X
    /// </summary>
    public class WebSCMOrderHeaderRecord : WebSCMOrderHeaderWrapper
    {
        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public WebSCMOrderHeaderRecord() : base() { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realRecord">�{���̃��R�[�h</param>
        public WebSCMOrderHeaderRecord(RecordType realRecord) : base(realRecord) { }

        #endregion // </Constructor>
    }
}
