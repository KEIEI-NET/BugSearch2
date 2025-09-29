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
using System.Windows.Forms;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller.Manual
{
    using SCMOrderHeaderRecordType  = ISCMOrderHeaderRecord;    // SCM�󒍃f�[�^
    using SCMOrderCarRecordType     = ISCMOrderCarRecord;       // SCM�󒍃f�[�^(�ԗ����)
    using SCMOrderDetailRecordType  = ISCMOrderDetailRecord;    // SCM�󒍖��׃f�[�^(�⍇���E����)
    using SCMOrderAnswerRecordType  = ISCMOrderAnswerRecord;    // SCM�󒍖��׃f�[�^(��)

    /// <summary>
    /// SCM�蓮�񓚏����N���X
    /// </summary>
    public sealed class SCMManualRespondent : SCMRespondent
    {
        private const string MY_NAME = "SCMManualRespondent";

        #region <Constructor>

        // DEL 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ---------->>>>>
        #region �폜�R�[�h

        ///// <summary>
        ///// �J�X�^���R���X�g���N�^
        ///// </summary>
        ///// <param name="seacher">SCM��������</param>
        ///// <param name="referee">SCM�񓚔��菈��</param>
        ///// <param name="salesDataMaker">SCM����f�[�^�쐬����</param>
        //public SCMManualRespondent(
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
        //    EasyLogger.Write(MY_NAME, "Constructor()", LogHelper.GetRunMsg("�蓮�񓚏���"));
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
        public SCMManualRespondent(
            SCMSearcher seacher,
            SCMReferee referee,
            SCMSalesDataMaker salesDataMaker
        ) : base(seacher, referee, salesDataMaker)
        {
            EasyLogger.Write(MY_NAME, "Constructor()", LogHelper.GetRunMsg("�蓮�񓚏���"));
        }
        // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ----------<<<<<

        #endregion // </Constructor>

        /// <summary>
        /// ����f�[�^�𐶐����܂��B�i�����O�Ɍ������������s���Ă��邱�Ɓj
        /// </summary>
        /// <remarks></remarks>
        /// <returns>����f�[�^�i�`�[�f�[�^�݂̂�Ԃ��܂��j
        /// �i���f�[�^�������ꍇ�A���<c>CustomSerializeArrayList</c>��Ԃ��܂��j
        /// </returns>
        public override CustomSerializeArrayList CreateSalesData()
        {
            CustomSerializeArrayList salesDataList = base.CreateSalesData();
            {
                if (salesDataList == null || salesDataList.Count.Equals(0))
                {
                    return new CustomSerializeArrayList();
                }
                CustomSerializeArrayList salesSlipList = salesDataList[0] as CustomSerializeArrayList;
                if (salesSlipList == null)
                {
                    return new CustomSerializeArrayList();
                }
                return salesSlipList;
            }
        }
    }
}
