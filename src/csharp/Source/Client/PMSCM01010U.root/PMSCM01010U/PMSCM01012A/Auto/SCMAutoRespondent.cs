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
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/04/05  �C�����e : �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬����
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Auto
{
    using SCMOrderHeaderRecordType  = ISCMOrderHeaderRecord;    // SCM�󒍃f�[�^
    using SCMOrderCarRecordType     = ISCMOrderCarRecord;       // SCM�󒍃f�[�^(�ԗ����)
    using SCMOrderDetailRecordType  = ISCMOrderDetailRecord;    // SCM�󒍖��׃f�[�^(�⍇���E����)
    using SCMOrderAnswerRecordType  = ISCMOrderAnswerRecord;    // SCM�󒍖��׃f�[�^(��)

    /// <summary>
    /// SCM�����񓚏����N���X
    /// </summary>
    public sealed class SCMAutoRespondent : SCMRespondent
    {
        private const string MY_NAME = "SCMAutoRespondent"; // ���O�p

        #region <Constructor>

        // DEL 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ---------->>>>>
        #region �폜�R�[�h

        ///// <summary>
        ///// �J�X�^���R���X�g���N�^
        ///// </summary>
        ///// <param name="seacher">SCM��������</param>
        ///// <param name="referee">SCM�񓚔��菈��</param>
        ///// <param name="salesDataMaker">SCM����f�[�^�쐬����</param>
        //public SCMAutoRespondent(
        //    SCMSearcher seacher,
        //    SCMReferee referee,
        //    SCMSalesDataMaker salesDataMaker
        //) : base(
        //    seacher.HeaderRecordList,
        //    seacher.CarRecordList,
        //    seacher.DetailRecordList,
        //    seacher,
        //    referee,
        //    salesDataMaker
        //)
        //{
        //    EasyLogger.Write(MY_NAME, "Constructor()", LogHelper.GetRunMsg("�����񓚏���"));
        //}

        #endregion // �폜�R�[�h
        // DEL 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ----------<<<<<
        // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ---------->>>>>
        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="seacher">SCM��������</param>
        /// <param name="referee">SCM�񓚔��菈��</param>
        /// <param name="salesDataMaker">SCM����f�[�^�쐬����</param>
        public SCMAutoRespondent(
            SCMSearcher seacher,
            SCMReferee referee,
            SCMSalesDataMaker salesDataMaker
        ) : base(seacher, referee, salesDataMaker)
        {
            EasyLogger.Write(MY_NAME, "Constructor()", LogHelper.GetRunMsg("�����񓚏���"));
        }
        // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ----------<<<<<

        #endregion // </Constructor>
    }
}
