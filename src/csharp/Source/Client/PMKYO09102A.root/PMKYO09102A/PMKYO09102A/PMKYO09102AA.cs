//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_�Ǘ��ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���_�Ǘ��ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/03/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/21  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Net.NetworkInformation;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���_�Ǘ��ݒ�}�X�^�����e�i���X�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�����e�i���X�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.03.26</br>
    /// <br></br>
    /// <br>Update Note :</br>
    /// </remarks>
    public class SecMngSetAcs
    {
        # region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        private ISecMngSetDB _iSecMngSetDB = null;
        # endregion

        # region [���[�J���A�N�Z�X�p]
        /// <summary> �������[�h </summary>
        public enum SearchMode
        {
            /// <summary> ���[�J���A�N�Z�X </summary>
            Local = 0,
            /// <summary> �����[�g�A�N�Z�X </summary>
            Remote = 1
        }
        # endregion

        # region -- �R���X�g���N�^ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�t���C���Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public SecMngSetAcs()
        {
            // �����[�g�I�u�W�F�N�g�擾
            this._iSecMngSetDB = (ISecMngSetDB)MediationSecMngSetDB.GetSecMngSetDB();
        }
        # endregion

        # region -- ������������� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchAll(out retList, enterpriseCode, SearchMode.Remote);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>             �������[�h�Ń��[�J���ǂݍ��݂������[�e�B���O����؂�ւ��܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, searchMode);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>  
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="prevSecMngSet">�O��ŏI�Ԕ̏��ދ��_�Ǘ��ݒ�}�X�^�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, SecMngSet prevSecMngSet, SearchMode searchMode)
        {
            SecMngSetWork secMngSetWork = new SecMngSetWork();

            if (prevSecMngSet != null)
            {
                secMngSetWork = CopyToSecMngSetWorkFromSecMngSet(prevSecMngSet);
            }
            secMngSetWork.EnterpriseCode = enterpriseCode;

            // ���f�[�^�L��������
            nextData = false;

            // �Ǎ��Ώۃf�[�^������0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList secMngSetWorkList = new ArrayList();
            secMngSetWorkList.Clear();

            int status = 0;

            object paraobj = secMngSetWork;
            object retobj = null;

            status = this._iSecMngSetDB.Search(out retobj, paraobj, 0, logicalMode);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                secMngSetWorkList = retobj as ArrayList;

                foreach (SecMngSetWork secMngSetWorkTemp in secMngSetWorkList)
                {
                    retList.Add(CopyToSecMngSetFromSecMngSetWork(secMngSetWorkTemp));
                }
            }

            // STATUS ��ݒ�
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^�_���폜��������
        /// </summary>
        /// <param name="secMngSet">���_�Ǘ��ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�̕������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public int Revival(ref SecMngSet secMngSet)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // UI�f�[�^�N���X�����[�N
            SecMngSetWork secMngSetWork = CopyToSecMngSetWorkFromSecMngSet(secMngSet);

            // XML�֕ϊ����A������̃o�C�i����
            //byte[] parabyte = XmlByteSerializer.Serialize(secMngSetWork);
            object objSecMngSetWork = secMngSetWork;

            status = this._iSecMngSetDB.RevivalLogicalDelete(ref objSecMngSetWork);

            if (status == 0)
            {
                // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                //secMngSetWork = (SecMngSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngSetWork));
                secMngSetWork = objSecMngSetWork as SecMngSetWork;

                // �N���X�������o�R�s�[
                secMngSet = CopyToSecMngSetFromSecMngSetWork(secMngSetWork);
            }

            return status;
        }
        # endregion

        # region -- �o�^��X�V���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �o�^�E�X�V����
        /// </summary>
        /// <param name="secMngSet">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public int Write(ref SecMngSet secMngSet)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            int writeMode = 0;
            // UI�f�[�^�N���X�����[�N
            SecMngSetWork secMngSetWork = CopyToSecMngSetWorkFromSecMngSet(secMngSet);

            // XML�֕ϊ����A������̃o�C�i����
            //byte[] parabyte = XmlByteSerializer.Serialize(secMngSetWork);
            object objSecMngSetWork = secMngSetWork;

            status = this._iSecMngSetDB.Write(ref objSecMngSetWork, writeMode);

            if (status == 0)
            {
                // �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y����
                // secMngSetWork = (SecMngSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngSetWork));
                secMngSetWork = objSecMngSetWork as SecMngSetWork;

                secMngSet = CopyToSecMngSetFromSecMngSetWork(secMngSetWork);
            }

            return status;
        }

        # endregion

        #region -- �폜���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="secMngSet">���_�Ǘ��ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�̘_���폜���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        public int LogicalDelete(ref SecMngSet secMngSet)
        {
            // UI�f�[�^�N���X�����[�N
            SecMngSetWork secMngSetWork = CopyToSecMngSetWorkFromSecMngSet(secMngSet);

            // XML�֕ϊ����A������̃o�C�i����
            //byte[] parabyte = XmlByteSerializer.Serialize(secMngSetWork);
            object objSecMngSetWork = secMngSetWork;

            // ���_���_���폜
            int status = this._iSecMngSetDB.LogicalDelete(ref objSecMngSetWork);

            if (status == 0)
            {
                // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                //secMngSetWork = (SecMngSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngSetWork));
                secMngSetWork = objSecMngSetWork as SecMngSetWork;

                secMngSet = CopyToSecMngSetFromSecMngSetWork(secMngSetWork);
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="secMngSet">���_�Ǘ��ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�̕����폜���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        public int Delete(SecMngSet secMngSet)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // UI�f�[�^�N���X�����[�N
            SecMngSetWork secMngSetWork = CopyToSecMngSetWorkFromSecMngSet(secMngSet);

            // XML�֕ϊ����A������̃o�C�i����
            // byte[] parabyte = XmlByteSerializer.Serialize(secMngSetWork);
            object objSecMngSetWork = secMngSetWork;

            // ���_�Ǘ��ݒ�}�X�^�����폜
            status = this._iSecMngSetDB.Delete(ref objSecMngSetWork);

            return status;
        }

        # endregion

        # region �ۑ��`���b�N
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^�̃f�[�^�`�F�b�N����
        /// </summary>
        /// <param name="sCreenSecMngSet">���INFO</param>
        /// <returns>�����f�[�^number</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��ꍇ�A���_�Ǘ��ݒ�}�X�^�̃f�[�^�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.07</br>
        /// </remarks>
        public int CheckScreenData(ref SecMngSet sCreenSecMngSet)
        {
            int status = 0;

            // ����M���s���`�F�b�N
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            totalDayCalculator.InitializeHisMonthlyAccRec();
            totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);

            if (sCreenSecMngSet.Kind == 0
                && DateTime.Compare(sCreenSecMngSet.SyncExecDate, prevTotalDay) < 0)
            {
                status = 2;
                return status;
            }

			// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
            // ��ʃ`�F�b�N
			//ArrayList secMngSetList = new ArrayList();
			//status = this.SearchAll(out secMngSetList, sCreenSecMngSet.EnterpriseCode);

			//if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
			//    || status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
			//{
			//    for (int i = 0; i < secMngSetList.Count; i++)
			//    {
			//        SecMngSet secMngSet = secMngSetList[i] as SecMngSet;

			//        if (sCreenSecMngSet.ReceiveCondition == 0
			//            && secMngSet.Kind == sCreenSecMngSet.Kind
			//            && secMngSet.ReceiveCondition == 0
			//            && secMngSet.LogicalDeleteCode == 0)
			//        {
			//            status = 3;
			//            break;
			//        }

			//        if (sCreenSecMngSet.Kind == 0
			//            && secMngSet.LogicalDeleteCode == 0
			//            && secMngSet.Kind == 0
			//            && ((sCreenSecMngSet.ReceiveCondition == 0 && secMngSet.ReceiveCondition == 1)
			//            || (sCreenSecMngSet.ReceiveCondition == 1 && secMngSet.ReceiveCondition == 0)))
			//        {
			//            status = 4;
			//            break;
			//        }
			//    }
			//}
			// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

            return status;
        }
        # endregion

        # region -- �N���X�����o�[�R�s�[���� --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���_�Ǘ��ݒ�}�X�^���[�N�N���X�ˋ��_�Ǘ��ݒ�}�X�^�N���X�j
        /// </summary>
        /// <param name="secMngSetWork">���_�Ǘ��ݒ�}�X�^���[�N�N���X</param>
        /// <returns>���_�Ǘ��ݒ�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^���[�N�N���X���狒�_�Ǘ��ݒ�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        private SecMngSet CopyToSecMngSetFromSecMngSetWork(SecMngSetWork secMngSetWork)
        {
            SecMngSet secMngSet = new SecMngSet();

            secMngSet.CreateDateTime = secMngSetWork.CreateDateTime;
            secMngSet.UpdateDateTime = secMngSetWork.UpdateDateTime;
            secMngSet.EnterpriseCode = secMngSetWork.EnterpriseCode;
            secMngSet.FileHeaderGuid = secMngSetWork.FileHeaderGuid;
            secMngSet.UpdEmployeeCode = secMngSetWork.UpdEmployeeCode;
            secMngSet.UpdAssemblyId1 = secMngSetWork.UpdAssemblyId1;
            secMngSet.UpdAssemblyId2 = secMngSetWork.UpdAssemblyId2;
            secMngSet.LogicalDeleteCode = secMngSetWork.LogicalDeleteCode;
            secMngSet.Kind = secMngSetWork.Kind;
            secMngSet.ReceiveCondition = secMngSetWork.ReceiveCondition;
            secMngSet.SectionCode = secMngSetWork.SectionCode;
            secMngSet.SyncExecDate = secMngSetWork.SyncExecDate;
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			secMngSet.SendDestSecCode = secMngSetWork.SendDestSecCode;
			secMngSet.AutoSendDiv = secMngSetWork.AutoSendDiv;
			secMngSet.SndFinDataEdDiv = secMngSetWork.SndFinDataEdDiv;
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

            return secMngSet;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���_�Ǘ��ݒ�}�X�^�N���X�ˋ��_�Ǘ��ݒ�}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="secMngSet">���_�Ǘ��ݒ�}�X�^�N���X</param>
        /// <returns>���_�Ǘ��ݒ�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�N���X���狒�_�Ǘ��ݒ�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        private SecMngSetWork CopyToSecMngSetWorkFromSecMngSet(SecMngSet secMngSet)
        {
            SecMngSetWork secMngSetWork = new SecMngSetWork();

            secMngSetWork.CreateDateTime = secMngSet.CreateDateTime;
            secMngSetWork.UpdateDateTime = secMngSet.UpdateDateTime;
            secMngSetWork.EnterpriseCode = secMngSet.EnterpriseCode;
            secMngSetWork.FileHeaderGuid = secMngSet.FileHeaderGuid;
            secMngSetWork.UpdEmployeeCode = secMngSet.UpdEmployeeCode;
            secMngSetWork.UpdAssemblyId1 = secMngSet.UpdAssemblyId1;
            secMngSetWork.UpdAssemblyId2 = secMngSet.UpdAssemblyId2;
            secMngSetWork.LogicalDeleteCode = secMngSet.LogicalDeleteCode;
            secMngSetWork.Kind = secMngSet.Kind;
            secMngSetWork.ReceiveCondition = secMngSet.ReceiveCondition;
            secMngSetWork.SectionCode = secMngSet.SectionCode;
            secMngSetWork.SyncExecDate = secMngSet.SyncExecDate;
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			secMngSetWork.SendDestSecCode = secMngSet.SendDestSecCode;
			secMngSetWork.AutoSendDiv = secMngSet.AutoSendDiv;
			secMngSetWork.SndFinDataEdDiv = secMngSet.SndFinDataEdDiv;
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

            return secMngSetWork;
        }
        # endregion
    }
}
