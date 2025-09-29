//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ������ԕ\���[���ݒ�
// �v���O�����T�v   : ������ԕ\���[���ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2014/08/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Net.NetworkInformation;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ������ԕ\���[���ݒ�}�X�^�����e�i���X�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������ԕ\���[���ݒ�}�X�^�����e�i���X�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2014/08/18</br>
    /// <br></br>
    /// <br>Update Note :</br>
    /// </remarks>
    public class SyncStateDspTermStAcs
    {
        # region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        private ISyncStateDspTermStDB _iSyncStateDspTermStDB = null;
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public SyncStateDspTermStAcs()
        {
            // �����[�g�I�u�W�F�N�g�擾
            this._iSyncStateDspTermStDB = (ISyncStateDspTermStDB)MediationSyncStateDspTermStDB.GetSyncStateDspTermStDB();
        }
        # endregion

        # region -- ������������� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ������ԕ\���[���ݒ�}�X�^���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������ԕ\���[���ݒ�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchAll(out retList, enterpriseCode, SearchMode.Remote);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ������ԕ\���[���ݒ�}�X�^���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������ԕ\���[���ݒ�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>             �������[�h�Ń��[�J���ǂݍ��݂������[�e�B���O����؂�ւ��܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, searchMode);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ������ԕ\���[���ݒ�}�X�^��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>  
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="prevSyncStateSt">�O��ŏI�Ԕ̏��ޓ�����ԕ\���[���ݒ�}�X�^�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������ԕ\���[���ݒ�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, SyncStateDspTermStWork prevSyncStateSt, SearchMode searchMode)
        {
            SyncStateDspTermStWork syncStateSt = new SyncStateDspTermStWork();

            syncStateSt.EnterpriseCode = enterpriseCode;

            // ���f�[�^�L��������
            nextData = false;

            // �Ǎ��Ώۃf�[�^������0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList secMngSetWorkList = new ArrayList();
            secMngSetWorkList.Clear();

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            object paraobj = syncStateSt;
            object retobj = null;
            try
            {
                status = this._iSyncStateDspTermStDB.Search(out retobj, paraobj, 0, logicalMode);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    secMngSetWorkList = retobj as ArrayList;

                    foreach (SyncStateDspTermStWork secMngSetWorkTemp in secMngSetWorkList)
                    {
                        retList.Add(secMngSetWorkTemp);
                    }
                }

                // STATUS ��ݒ�
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (retList.Count == 0))
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSyncStateDspTermStDB = null;
                // �ʐM�G���[��-1��߂�
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ������ԕ\���[���ݒ�}�X�^�_���폜��������
        /// </summary>
        /// <param name="syncStateSt">������ԕ\���[���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������ԕ\���[���ݒ�}�X�^�̕������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public int Revival(ref SyncStateDspTermStWork syncStateSt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            object objSecMngSetWork = syncStateSt;

            try
            {
                status = this._iSyncStateDspTermStDB.RevivalLogicalDelete(ref objSecMngSetWork);

                if (status == 0)
                {
                    // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                    syncStateSt = (SyncStateDspTermStWork)objSecMngSetWork;
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSyncStateDspTermStDB = null;
                // �ʐM�G���[��-1��߂�
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        # endregion

        # region -- �o�^��X�V���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �o�^�E�X�V����
        /// </summary>
        /// <param name="syncStateSt">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public int Write(ref SyncStateDspTermStWork syncStateSt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            object objSecMngSetWork = syncStateSt;

            try
            {
                status = this._iSyncStateDspTermStDB.Write(ref objSecMngSetWork);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (objSecMngSetWork is ArrayList)
                    {
                        // �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y����
                        syncStateSt = (SyncStateDspTermStWork)((ArrayList)objSecMngSetWork)[0];
                    }
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSyncStateDspTermStDB = null;
                // �ʐM�G���[��-1��߂�
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        # endregion

        #region -- �폜���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="syncStateSt">������ԕ\���[���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������ԕ\���[���ݒ�}�X�^�̘_���폜���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public int LogicalDelete(ref SyncStateDspTermStWork syncStateSt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            object objSecMngSetWork = syncStateSt;

            try
            {
                // ���_���_���폜
                status = this._iSyncStateDspTermStDB.LogicalDelete(ref objSecMngSetWork);

                if (status == 0)
                {
                    // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                    syncStateSt = objSecMngSetWork as SyncStateDspTermStWork;
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSyncStateDspTermStDB = null;
                // �ʐM�G���[��-1��߂�
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="syncStateSt">������ԕ\���[���ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������ԕ\���[���ݒ�}�X�^�̕����폜���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public int Delete(SyncStateDspTermStWork syncStateSt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            object objSecMngSetWork = syncStateSt;

            // ������ԕ\���[���ݒ�}�X�^�����폜
            status = this._iSyncStateDspTermStDB.Delete(objSecMngSetWork);

            return status;
        }

        # endregion
    }
}
