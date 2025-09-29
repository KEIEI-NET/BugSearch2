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
// �� �� ��  2009/05/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Manual
{
    using SCMOrderHeaderRecordType  = ISCMOrderHeaderRecord;    // SCM�󒍃f�[�^
    using SCMOrderCarRecordType     = ISCMOrderCarRecord;       // SCM�󒍃f�[�^(�ԗ����)
    using SCMOrderDetailRecordType  = ISCMOrderDetailRecord;    // SCM�󒍖��׃f�[�^(�⍇���E����)
    using SCMOrderAnswerRecordType  = ISCMOrderAnswerRecord;    // SCM�󒍖��׃f�[�^(��)

    /// <summary>
    /// SCM�蓮�p�񓚔��菈���N���X
    /// </summary>
    public sealed class SCMManualReferee : SCMReferee
    {
        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="searcher">SCM��������</param>
        public SCMManualReferee(SCMSearcher searcher) : base(searcher) { }

        #endregion // </Constructor>
    }
}
