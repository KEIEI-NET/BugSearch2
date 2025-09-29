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
// �Ǘ��ԍ�              �쐬�S�� : LDNS�̗���
// �� �� ��  2011/08/10  �C�����e : �����񓚑Ή��ASCM�Z�b�g�}�X�^���M�ł��邽��
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�J�X�^���R���X�g���N�^��ǉ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070076-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2014/05/13  �C�����e : PM-SCM���x���� �t�F�[�Y�Q�Ή�
//                                : 13.�t���^���Œ�ԍ�����̂a�k�R�[�h�����񐔉��ǑΉ�
//                                : 14.���׎捞�敪�̍X�V���@�����ǑΉ�
//                                : 15.SCM�󔭒��f�[�^�i�ԗ����j�擾���@���ǑΉ�
//                                : 16.�����i�������ǑΉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller.Agent;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���\�b�h�R�[���ɂ��N���̉񓚑��M�����R���g���[���N���X
    /// </summary>
    public sealed class SCMMethodCalledController : PMNSBatchController
    {
        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="headerList">SCM�󒍃f�[�^�̃��R�[�h���X�g</param>
        /// <param name="carList">SCM�󒍃f�[�^(�ԗ����)�̃��R�[�h���X�g</param>
        /// <param name="detailList">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h���X�g</param>
        /// <param name="answerList">SCM���󒍖��׃f�[�^(��)�̃��R�[�h���X�g</param>
        public SCMMethodCalledController(
            IList<ISCMOrderHeaderRecord> headerList,
            IList<ISCMOrderCarRecord> carList,
            IList<ISCMOrderDetailRecord> detailList,
            IList<ISCMOrderAnswerRecord> answerList
        )
        {
            // SCMIO�Ƀf�[�^��n��
            SCMIO.FoundSendingHeaderList = headerList;
            SCMIO.FoundSendingCarList = carList;
            //SCMIO.FoundSendingDetailList = detailList;
            SCMIO.FoundSendingAnswerList = answerList;
        }
        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// �J�X�^���R���X�g���N�^(PCCUOE�̂��ߐV�K�ǉ�)
        /// </summary>
        /// <param name="headerList">SCM�󒍃f�[�^�̃��R�[�h���X�g</param>
        /// <param name="carList">SCM�󒍃f�[�^(�ԗ����)�̃��R�[�h���X�g</param>
        /// <param name="answerList">SCM���󒍖��׃f�[�^(��)�̃��R�[�h���X�g</param>
        /// <param name="setDtList">SCM�Z�b�g�}�X�^�̃��R�[�h���X�g</param>
        public SCMMethodCalledController(
            IList<ISCMOrderHeaderRecord> headerList,
            IList<ISCMOrderCarRecord> carList,
            IList<ISCMOrderAnswerRecord> answerList,
            IList<ISCMAcOdSetDtRecord> setDtList
        )
        {
            // SCMIO�Ƀf�[�^��n��
            SCMIO.FoundSendingHeaderList = headerList;
            SCMIO.FoundSendingCarList = carList;
            SCMIO.FoundSendingAnswerList = answerList;
            SCMIO.FoundSendingSetDtList = setDtList;
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��15.SCM�󔭒��f�[�^�i�ԗ����j�擾���@���ǑΉ� ---------------------------------->>>>>
        /// <summary>
        /// �J�X�^���R���X�g���N�^(PCCUOE�̂��ߐV�K�ǉ�)
        /// </summary>
        /// <param name="headerList">SCM�󒍃f�[�^�̃��R�[�h���X�g</param>
        /// <param name="carList">SCM�󒍃f�[�^(�ԗ����)�̃��R�[�h���X�g</param>
        /// <param name="answerList">SCM���󒍖��׃f�[�^(��)�̃��R�[�h���X�g</param>
        /// <param name="setDtList">SCM�Z�b�g�}�X�^�̃��R�[�h���X�g</param>
        public SCMMethodCalledController(
            IList<ISCMOrderHeaderRecord> headerList,
            IList<ISCMOrderCarRecord> carList,
            IList<ISCMOrderAnswerRecord> answerList,
            IList<ISCMAcOdSetDtRecord> setDtList,
            List<ScmOdDtCar> scmOdDtCarList
        )
        {
            // SCMIO�Ƀf�[�^��n��
            SCMIO.FoundSendingHeaderList = headerList;
            SCMIO.FoundSendingCarList = carList;
            SCMIO.FoundSendingAnswerList = answerList;
            SCMIO.FoundSendingSetDtList = setDtList;

            // SCM�󔭒��f�[�^�i�ԗ����j�}�b�v�Ƀf�[�^���L���b�V������
            this.SCMWebDB.SetWebCarReaccessionMap(scmOdDtCarList, headerList[0]);
        }
        // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��15.SCM�󔭒��f�[�^�i�ԗ����j�擾���@���ǑΉ� ----------------------------------<<<<<

        #endregion // </Constructor>
    }
}
