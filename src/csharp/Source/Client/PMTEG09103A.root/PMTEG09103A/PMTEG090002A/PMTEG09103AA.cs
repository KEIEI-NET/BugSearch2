//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����`�f�[�^�}�X�^�����e�i���X
// �v���O�����T�v   : ����`�f�[�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2010/04/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C �� ��  2012/10/18  �C�����e : ���o�����̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : zhuhh
// �C �� ��  2013/01/10  �C�����e : 2013/03/13�z�M�� Redmine #34123
//                                  ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;   
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����`�f�[�^�}�X�^�����e�i���X�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����`�f�[�^�}�X�^�����e�i���X�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2010.04.27</br>
    /// <br>UpdateNote : 2013/01/10 zhuhh</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
    /// </remarks>
    public class RcvDraftDataAcs
    {
        # region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        private IRcvDraftDataDB _iRcvDraftDataDB = null;
        // --- ADD 2012/10/18 T.Nishi ----->>>>>
        private RcvDraftDataSet _rcvdraftDataSet = null;
        // --- ADD 2012/10/18 T.Nishi -----<<<<<
        # endregion

        # region -- �R���X�g���N�^ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�t���C���Ή�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public RcvDraftDataAcs()
        {
            // �����[�g�I�u�W�F�N�g�擾
            this._iRcvDraftDataDB = (IRcvDraftDataDB)MediationRcvDraftDataDB.GetRcvDraftDataDB();
            // --- ADD 2012/10/18 T.Nishi ----->>>>>
            this._rcvdraftDataSet = new RcvDraftDataSet();
            // --- ADD 2012/10/18 T.Nishi -----<<<<<
        }
        # endregion

        # region -- �������� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="readMode">�ݒ�R�[�h</param>
        /// <param name="paraRcvDraftData">����`�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.03.31</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        public int Search(out List<RcvDraftData> retList, int readMode, RcvDraftData paraRcvDraftData)
        {
            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();
            rcvDraftDataWork.EnterpriseCode = paraRcvDraftData.EnterpriseCode;
            rcvDraftDataWork.RcvDraftNo = paraRcvDraftData.RcvDraftNo;
            rcvDraftDataWork.DepositRowNo = paraRcvDraftData.DepositRowNo;
            rcvDraftDataWork.DepositSlipNo = paraRcvDraftData.DepositSlipNo;
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
            rcvDraftDataWork.BankAndBranchCd = paraRcvDraftData.BankAndBranchCd;
            rcvDraftDataWork.DraftDrawingDate = paraRcvDraftData.DraftDrawingDate;
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
            // --- ADD 2012/10/18 T.Nishi ----->>>>>
            rcvDraftDataWork.ValidityTerm = paraRcvDraftData.ValidityTerm;
            rcvDraftDataWork.DraftKindCd = paraRcvDraftData.DraftKindCd;
            // --- ADD 2012/10/18 T.Nishi -----<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<RcvDraftData>();

            object paraobj = rcvDraftDataWork;
            object retobj = null;

            ArrayList rcvDraftDataWorkList = new ArrayList();
            rcvDraftDataWorkList.Clear();

            status = this._iRcvDraftDataDB.Search(out retobj, paraobj, readMode, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                rcvDraftDataWorkList = retobj as ArrayList;

                foreach (RcvDraftDataWork rcvDraftDataWorkTemp in rcvDraftDataWorkList)
                {
                    retList.Add(CopyToRcvDraftDataFromRcvDraftDataWork(rcvDraftDataWorkTemp));
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

        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="readMode">�ݒ�R�[�h</param>
        /// <param name="paraRcvDraftData">����`�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂�</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M�� Redmine#34123</br>
        /// <br>           : ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        public int SearchWithoutBabCd(out List<RcvDraftData> retList, int readMode, RcvDraftData paraRcvDraftData)
        {
            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();
            rcvDraftDataWork.EnterpriseCode = paraRcvDraftData.EnterpriseCode;
            rcvDraftDataWork.RcvDraftNo = paraRcvDraftData.RcvDraftNo;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<RcvDraftData>();

            object paraobj = rcvDraftDataWork;
            object retobj = null;

            ArrayList rcvDraftDataWorkList = new ArrayList();
            rcvDraftDataWorkList.Clear();

            status = this._iRcvDraftDataDB.SearchWithoutBabCd(out retobj, paraobj, readMode, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                rcvDraftDataWorkList = retobj as ArrayList;

                foreach (RcvDraftDataWork rcvDraftDataWorkTemp in rcvDraftDataWorkList)
                {
                    retList.Add(CopyToRcvDraftDataFromRcvDraftDataWork(rcvDraftDataWorkTemp));
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

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="readMode">�ݒ�R�[�h</param>
        /// <param name="paraRcvDraftData">����`�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂�</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M�� Redmine#34123</br>
        /// <br>           : ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        public int SearchWithBabCd(out List<RcvDraftData> retList, int readMode, RcvDraftData paraRcvDraftData)
        {
            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();
            rcvDraftDataWork.EnterpriseCode = paraRcvDraftData.EnterpriseCode;
            rcvDraftDataWork.RcvDraftNo = paraRcvDraftData.RcvDraftNo;
            rcvDraftDataWork.BankAndBranchCd = paraRcvDraftData.BankAndBranchCd;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<RcvDraftData>();

            object paraobj = rcvDraftDataWork;
            object retobj = null;

            ArrayList rcvDraftDataWorkList = new ArrayList();
            rcvDraftDataWorkList.Clear();

            status = this._iRcvDraftDataDB.SearchWithBabCd(out retobj, paraobj, readMode, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                rcvDraftDataWorkList = retobj as ArrayList;

                foreach (RcvDraftDataWork rcvDraftDataWorkTemp in rcvDraftDataWorkList)
                {
                    retList.Add(CopyToRcvDraftDataFromRcvDraftDataWork(rcvDraftDataWorkTemp));
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

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="readMode">�ݒ�R�[�h</param>
        /// <param name="paraRcvDraftData">����`�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂�</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M�� Redmine#34123</br>
        /// <br>           : ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        public int SearchWithDrawingDate(out List<RcvDraftData> retList, int readMode, RcvDraftData paraRcvDraftData)
        {
            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();
            rcvDraftDataWork.EnterpriseCode = paraRcvDraftData.EnterpriseCode;
            rcvDraftDataWork.RcvDraftNo = paraRcvDraftData.RcvDraftNo;
            rcvDraftDataWork.DraftDrawingDate = paraRcvDraftData.DraftDrawingDate;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<RcvDraftData>();

            object paraobj = rcvDraftDataWork;
            object retobj = null;

            ArrayList rcvDraftDataWorkList = new ArrayList();
            rcvDraftDataWorkList.Clear();

            status = this._iRcvDraftDataDB.SearchWithDrawingDate(out retobj, paraobj, readMode, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                rcvDraftDataWorkList = retobj as ArrayList;

                foreach (RcvDraftDataWork rcvDraftDataWorkTemp in rcvDraftDataWorkList)
                {
                    retList.Add(CopyToRcvDraftDataFromRcvDraftDataWork(rcvDraftDataWorkTemp));
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
        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
        # endregion

        # region -- �o�^��X�V���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �o�^�E�X�V����
        /// </summary>
        /// <param name="rcvDraftDataList">UI�f�[�^List</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.03.31</br>
        /// </remarks>
        public int Write(ref List<RcvDraftData> rcvDraftDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; ;

            ArrayList rcvDraftDataWorkList = new ArrayList();

            foreach (RcvDraftData rcvDraftData in rcvDraftDataList)
            {
                // UI�f�[�^�N���X�����[�N
                RcvDraftDataWork rcvDraftDataWork = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftData);

                rcvDraftDataWorkList.Add(rcvDraftDataWork);
            }

            object paraObj = rcvDraftDataWorkList;

            status = this._iRcvDraftDataDB.Write(ref paraObj);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                rcvDraftDataWorkList = paraObj as ArrayList;

                rcvDraftDataList.Clear();
                foreach (RcvDraftDataWork rcvDraftDataWork in rcvDraftDataWorkList)
                {
                    // ���[�N��UI�f�[�^�N���X
                    RcvDraftData rcvDraftData = CopyToRcvDraftDataFromRcvDraftDataWork(rcvDraftDataWork);

                    rcvDraftDataList.Add(rcvDraftData);
                }
            }

            return status;
        }
        # endregion

        #region �_���폜����
        /// <summary>
        /// �_���폜����(����`�f�[�^�}�X�^)
        /// </summary>
        /// <param name="rcvDraftDataList">����`�f�[�^�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����`�f�[�^�}�X�^��_���폜���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        public int LogicalDelete(ref List<RcvDraftData> rcvDraftDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList rcvDraftDataWorkList = new ArrayList();

                foreach (RcvDraftData rcvDraftData in rcvDraftDataList)
                {
                    // UI�f�[�^�N���X�����[�N
                    RcvDraftDataWork rcvDraftDataWork = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftData);

                    rcvDraftDataWorkList.Add(rcvDraftDataWork);
                }

                object paraObj = rcvDraftDataWorkList;

                // �_���폜����
                status = this._iRcvDraftDataDB.LogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    rcvDraftDataWorkList = paraObj as ArrayList;

                    rcvDraftDataList.Clear();
                    foreach (RcvDraftDataWork rcvDraftDataWork in rcvDraftDataWorkList)
                    {
                        // ���[�N��UI�f�[�^�N���X
                        RcvDraftData rcvDraftData = CopyToRcvDraftDataFromRcvDraftDataWork(rcvDraftDataWork);

                        rcvDraftDataList.Add(rcvDraftData);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endregion

        #region �����폜����
        /// <summary>
        /// �����폜����(����`�f�[�^�}�X�^)
        /// </summary>
        /// <param name="rcvDraftDataList">����`�f�[�^�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����`�f�[�^�}�X�^���X�g�𕨗��폜���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        public int Delete(List<RcvDraftData> rcvDraftDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList rcvDraftDataWorkList = new ArrayList();

                foreach (RcvDraftData rcvDraftData in rcvDraftDataList)
                {
                    // UI�f�[�^�N���X�����[�N
                    RcvDraftDataWork rcvDraftDataWork = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftData);

                    rcvDraftDataWorkList.Add(rcvDraftDataWork);
                }

                object paraObj = rcvDraftDataWorkList;

                // �����폜����
                status = this._iRcvDraftDataDB.Delete(ref paraObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endregion

        #region ��������
        /// <summary>
        /// ��������(����`�f�[�^�}�X�^)
        /// </summary>
        /// <param name="rcvDraftDataList">����`�f�[�^�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ����`�f�[�^�}�X�^�𕜊����܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009/04/23</br>
        /// </remarks>
        public int Revival(ref List<RcvDraftData> rcvDraftDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList rcvDraftDataWorkList = new ArrayList();

                foreach (RcvDraftData rcvDraftData in rcvDraftDataList)
                {
                    // UI�f�[�^�N���X�����[�N
                    RcvDraftDataWork rcvDraftDataWork = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftData);

                    rcvDraftDataWorkList.Add(rcvDraftDataWork);
                }

                object paraObj = rcvDraftDataWorkList;

                // �_���폜����
                status = this._iRcvDraftDataDB.RevivalLogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    rcvDraftDataWorkList = paraObj as ArrayList;

                    rcvDraftDataList.Clear();
                    foreach (RcvDraftDataWork rcvDraftDataWork in rcvDraftDataWorkList)
                    {
                        // ���[�N��UI�f�[�^�N���X
                        RcvDraftData rcvDraftData = CopyToRcvDraftDataFromRcvDraftDataWork(rcvDraftDataWork);

                        rcvDraftDataList.Add(rcvDraftData);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        # endregion

        # region -- �N���X�����o�[�R�s�[���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i����`�f�[�^�}�X�^���[�N�N���X�ˎ���`�f�[�^�}�X�^�N���X�j
        /// </summary>
        /// <param name="rcvDraftDataWork">����`�f�[�^�}�X�^���[�N�N���X</param>
        /// <returns>����`�f�[�^�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ����`�f�[�^�}�X�^���[�N�N���X�������`�f�[�^�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        private RcvDraftData CopyToRcvDraftDataFromRcvDraftDataWork(RcvDraftDataWork rcvDraftDataWork)
        {
            RcvDraftData rcvDraftData = new RcvDraftData();

            rcvDraftData.CreateDateTime = rcvDraftDataWork.CreateDateTime;
            rcvDraftData.UpdateDateTime = rcvDraftDataWork.UpdateDateTime;
            rcvDraftData.EnterpriseCode = rcvDraftDataWork.EnterpriseCode;
            rcvDraftData.FileHeaderGuid = rcvDraftDataWork.FileHeaderGuid;
            rcvDraftData.UpdEmployeeCode = rcvDraftDataWork.UpdEmployeeCode;
            rcvDraftData.UpdAssemblyId1 = rcvDraftDataWork.UpdAssemblyId1;
            rcvDraftData.UpdAssemblyId2 = rcvDraftDataWork.UpdAssemblyId2;
            rcvDraftData.LogicalDeleteCode = rcvDraftDataWork.LogicalDeleteCode;
            rcvDraftData.RcvDraftNo = rcvDraftDataWork.RcvDraftNo;
            rcvDraftData.DraftKindCd = rcvDraftDataWork.DraftKindCd;
            rcvDraftData.DraftDivide = rcvDraftDataWork.DraftDivide;
            rcvDraftData.Deposit = rcvDraftDataWork.Deposit;
            rcvDraftData.BankAndBranchCd = rcvDraftDataWork.BankAndBranchCd;
            rcvDraftData.BankAndBranchNm = rcvDraftDataWork.BankAndBranchNm;
            rcvDraftData.SectionCode = rcvDraftDataWork.SectionCode;
            rcvDraftData.AddUpSecCode = rcvDraftDataWork.AddUpSecCode;
            rcvDraftData.CustomerCode = rcvDraftDataWork.CustomerCode;
            rcvDraftData.CustomerName = rcvDraftDataWork.CustomerName;
            rcvDraftData.CustomerName2 = rcvDraftDataWork.CustomerName2;
            rcvDraftData.CustomerSnm = rcvDraftDataWork.CustomerSnm;
            rcvDraftData.ProcDate = rcvDraftDataWork.ProcDate;
            rcvDraftData.DraftDrawingDate = rcvDraftDataWork.DraftDrawingDate;
            rcvDraftData.ValidityTerm = rcvDraftDataWork.ValidityTerm;
            rcvDraftData.DraftStmntDate = rcvDraftDataWork.DraftStmntDate;
            rcvDraftData.Outline1 = rcvDraftDataWork.Outline1;
            rcvDraftData.Outline2 = rcvDraftDataWork.Outline2;
            rcvDraftData.AcptAnOdrStatus = rcvDraftDataWork.AcptAnOdrStatus;
            rcvDraftData.DepositSlipNo = rcvDraftDataWork.DepositSlipNo;
            rcvDraftData.DepositRowNo = rcvDraftDataWork.DepositRowNo;
            rcvDraftData.DepositDate = rcvDraftDataWork.DepositDate;

            return rcvDraftData;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i����`�f�[�^�}�X�^�N���X�ˎ���`�f�[�^�}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="rcvDraftData">����`�f�[�^�}�X�^�N���X</param>
        /// <returns>����`�f�[�^�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ����`�f�[�^�}�X�^�N���X�������`�f�[�^�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        private RcvDraftDataWork CopyToRcvDraftDataWorkFromRcvDraftData(RcvDraftData rcvDraftData)
        {
            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();

            rcvDraftDataWork.CreateDateTime = rcvDraftData.CreateDateTime;
            rcvDraftDataWork.UpdateDateTime = rcvDraftData.UpdateDateTime;
            rcvDraftDataWork.EnterpriseCode = rcvDraftData.EnterpriseCode;
            rcvDraftDataWork.FileHeaderGuid = rcvDraftData.FileHeaderGuid;
            rcvDraftDataWork.UpdEmployeeCode = rcvDraftData.UpdEmployeeCode;
            rcvDraftDataWork.UpdAssemblyId1 = rcvDraftData.UpdAssemblyId1;
            rcvDraftDataWork.UpdAssemblyId2 = rcvDraftData.UpdAssemblyId2;
            rcvDraftDataWork.LogicalDeleteCode = rcvDraftData.LogicalDeleteCode;
            rcvDraftDataWork.RcvDraftNo = rcvDraftData.RcvDraftNo;
            rcvDraftDataWork.DraftKindCd = rcvDraftData.DraftKindCd;
            rcvDraftDataWork.DraftDivide = rcvDraftData.DraftDivide;
            rcvDraftDataWork.Deposit = rcvDraftData.Deposit;
            rcvDraftDataWork.BankAndBranchCd = rcvDraftData.BankAndBranchCd;
            rcvDraftDataWork.BankAndBranchNm = rcvDraftData.BankAndBranchNm;
            rcvDraftDataWork.SectionCode = rcvDraftData.SectionCode;
            rcvDraftDataWork.AddUpSecCode = rcvDraftData.AddUpSecCode;
            rcvDraftDataWork.CustomerCode = rcvDraftData.CustomerCode;
            rcvDraftDataWork.CustomerName = rcvDraftData.CustomerName;
            rcvDraftDataWork.CustomerName2 = rcvDraftData.CustomerName2;
            rcvDraftDataWork.CustomerSnm = rcvDraftData.CustomerSnm;
            rcvDraftDataWork.ProcDate = rcvDraftData.ProcDate;
            rcvDraftDataWork.DraftDrawingDate = rcvDraftData.DraftDrawingDate;
            rcvDraftDataWork.ValidityTerm = rcvDraftData.ValidityTerm;
            rcvDraftDataWork.DraftStmntDate = rcvDraftData.DraftStmntDate;
            rcvDraftDataWork.Outline1 = rcvDraftData.Outline1;
            rcvDraftDataWork.Outline2 = rcvDraftData.Outline2;
            rcvDraftDataWork.AcptAnOdrStatus = rcvDraftData.AcptAnOdrStatus;
            rcvDraftDataWork.DepositSlipNo = rcvDraftData.DepositSlipNo;
            rcvDraftDataWork.DepositRowNo = rcvDraftData.DepositRowNo;
            rcvDraftDataWork.DepositDate = rcvDraftData.DepositDate;

            return rcvDraftDataWork;
        }
        # endregion
    }

    /// <summary>
    /// �x����`�f�[�^�}�X�^�����e�i���X�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �x����`�f�[�^�}�X�^�����e�i���X�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2010.04.27</br>
    /// <br>UpdateNote : 2013/01/10 zhuhh</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
    /// </remarks>
    public class PayDraftDataAcs
    {
        # region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        private IPayDraftDataDB _iPayDraftDataDB = null;
        # endregion

        # region -- �R���X�g���N�^ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�t���C���Ή�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public PayDraftDataAcs()
        {
            // �����[�g�I�u�W�F�N�g�擾
            this._iPayDraftDataDB = (IPayDraftDataDB)MediationPayDraftDataDB.GetPayDraftDataDB();
        }
        # endregion

        # region -- �������� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="readMode">�������[�h</param>
        /// <param name="paraPayDraftData">�x����`�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.27</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        public int Search(out List<PayDraftData> retList, int readMode, PayDraftData paraPayDraftData)
        {
            PayDraftDataWork payDraftDataWork = new PayDraftDataWork();

            payDraftDataWork.EnterpriseCode = paraPayDraftData.EnterpriseCode;
            payDraftDataWork.PayDraftNo = paraPayDraftData.PayDraftNo;
            payDraftDataWork.PaymentRowNo = paraPayDraftData.PaymentRowNo;
            payDraftDataWork.PaymentSlipNo = paraPayDraftData.PaymentSlipNo;
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
            payDraftDataWork.BankAndBranchCd = paraPayDraftData.BankAndBranchCd;
            payDraftDataWork.DraftDrawingDate = paraPayDraftData.DraftDrawingDate;
            // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<PayDraftData>();

            object paraobj = payDraftDataWork;
            object retobj = null;

            ArrayList payDraftDataWorkList = new ArrayList();
            payDraftDataWorkList.Clear();

            status = this._iPayDraftDataDB.Search(out retobj, paraobj, readMode, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                payDraftDataWorkList = retobj as ArrayList;

                foreach (PayDraftDataWork payDraftDataWorkTemp in payDraftDataWorkList)
                {
                    retList.Add(CopyToPayDraftDataFromPayDraftDataWork(payDraftDataWorkTemp));
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
        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="readMode">�������[�h</param>
        /// <param name="paraPayDraftData">�x����`�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M�� Redmine#34123</br>
        /// <br>           : ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        public int SearchWithoutBab(out List<PayDraftData> retList, int readMode, PayDraftData paraPayDraftData)
        {
            PayDraftDataWork payDraftDataWork = new PayDraftDataWork();

            payDraftDataWork.EnterpriseCode = paraPayDraftData.EnterpriseCode;
            payDraftDataWork.PayDraftNo = paraPayDraftData.PayDraftNo;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<PayDraftData>();

            object paraobj = payDraftDataWork;
            object retobj = null;

            ArrayList payDraftDataWorkList = new ArrayList();
            payDraftDataWorkList.Clear();

            status = this._iPayDraftDataDB.SearchWithoutBab(out retobj, paraobj, readMode, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                payDraftDataWorkList = retobj as ArrayList;

                foreach (PayDraftDataWork payDraftDataWorkTemp in payDraftDataWorkList)
                {
                    retList.Add(CopyToPayDraftDataFromPayDraftDataWork(payDraftDataWorkTemp));
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
        /// ��������
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="readMode">�������[�h</param>
        /// <param name="paraPayDraftData">�x����`�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M�� Redmine#34123</br>
        /// <br>           : ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        public int SearchWithBab(out List<PayDraftData> retList, int readMode, PayDraftData paraPayDraftData)
        {
            PayDraftDataWork payDraftDataWork = new PayDraftDataWork();

            payDraftDataWork.EnterpriseCode = paraPayDraftData.EnterpriseCode;
            payDraftDataWork.PayDraftNo = paraPayDraftData.PayDraftNo;
            payDraftDataWork.BankAndBranchCd = paraPayDraftData.BankAndBranchCd;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<PayDraftData>();

            object paraobj = payDraftDataWork;
            object retobj = null;

            ArrayList payDraftDataWorkList = new ArrayList();
            payDraftDataWorkList.Clear();

            status = this._iPayDraftDataDB.SearchWithBab(out retobj, paraobj, readMode, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                payDraftDataWorkList = retobj as ArrayList;

                foreach (PayDraftDataWork payDraftDataWorkTemp in payDraftDataWorkList)
                {
                    retList.Add(CopyToPayDraftDataFromPayDraftDataWork(payDraftDataWorkTemp));
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
        /// ��������
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="readMode">�������[�h</param>
        /// <param name="paraPayDraftData">�x����`�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : zhuhh</br>
        /// <br>Date       : 2013/01/10</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M�� Redmine#34123</br>
        /// <br>           : ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        public int SearchWithDrawingDate(out List<PayDraftData> retList, int readMode, PayDraftData paraPayDraftData)
        {
            PayDraftDataWork payDraftDataWork = new PayDraftDataWork();

            payDraftDataWork.EnterpriseCode = paraPayDraftData.EnterpriseCode;
            payDraftDataWork.PayDraftNo = paraPayDraftData.PayDraftNo;
            payDraftDataWork.DraftDrawingDate = paraPayDraftData.DraftDrawingDate;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new List<PayDraftData>();

            object paraobj = payDraftDataWork;
            object retobj = null;

            ArrayList payDraftDataWorkList = new ArrayList();
            payDraftDataWorkList.Clear();

            status = this._iPayDraftDataDB.SearchWithDrawingDate(out retobj, paraobj, readMode, ConstantManagement.LogicalMode.GetData0);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                payDraftDataWorkList = retobj as ArrayList;

                foreach (PayDraftDataWork payDraftDataWorkTemp in payDraftDataWorkList)
                {
                    retList.Add(CopyToPayDraftDataFromPayDraftDataWork(payDraftDataWorkTemp));
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
        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
        # endregion

        # region -- �o�^��X�V���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �o�^�E�X�V����
        /// </summary>
        /// <param name="payDraftDataList">UI�f�[�^List</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public int Write(ref List<PayDraftData> payDraftDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; ;

            ArrayList payDraftDataWorkList = new ArrayList();

            foreach (PayDraftData payDraftData in payDraftDataList)
            {
                // UI�f�[�^�N���X�����[�N
                PayDraftDataWork payDraftDataWork = CopyToPayDraftDataWorkFromPayDraftData(payDraftData);

                payDraftDataWorkList.Add(payDraftDataWork);
            }

            object paraObj = payDraftDataWorkList;

            status = this._iPayDraftDataDB.Write(ref paraObj);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                payDraftDataWorkList = paraObj as ArrayList;

                payDraftDataList.Clear();
                foreach (PayDraftDataWork payDraftDataWork in payDraftDataWorkList)
                {
                    // ���[�N��UI�f�[�^�N���X
                    PayDraftData payDraftData = CopyToPayDraftDataFromPayDraftDataWork(payDraftDataWork);

                    payDraftDataList.Add(payDraftData);
                }
            }

            return status;
        }
        # endregion

        #region �_���폜����
        /// <summary>
        /// �_���폜����(�x����`�f�[�^�}�X�^)
        /// </summary>
        /// <param name="payDraftDataList">�x����`�f�[�^�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �x����`�f�[�^�}�X�^��_���폜���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public int LogicalDelete(ref List<PayDraftData> payDraftDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList payDraftDataWorkList = new ArrayList();

                foreach (PayDraftData payDraftData in payDraftDataList)
                {
                    // UI�f�[�^�N���X�����[�N
                    PayDraftDataWork payDraftDataWork = CopyToPayDraftDataWorkFromPayDraftData(payDraftData);

                    payDraftDataWorkList.Add(payDraftDataWork);
                }

                object paraObj = payDraftDataWorkList;

                // �_���폜����
                status = this._iPayDraftDataDB.LogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    payDraftDataWorkList = paraObj as ArrayList;

                    payDraftDataList.Clear();
                    foreach (PayDraftDataWork payDraftDataWork in payDraftDataWorkList)
                    {
                        // ���[�N��UI�f�[�^�N���X
                        PayDraftData payDraftData = CopyToPayDraftDataFromPayDraftDataWork(payDraftDataWork);

                        payDraftDataList.Add(payDraftData);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endregion

        #region �����폜����
        /// <summary>
        /// �����폜����(�x����`�f�[�^�}�X�^)
        /// </summary>
        /// <param name="payDraftDataList">�x����`�f�[�^�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �x����`�f�[�^�}�X�^���X�g�𕨗��폜���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public int Delete(List<PayDraftData> payDraftDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList payDraftDataWorkList = new ArrayList();

                foreach (PayDraftData payDraftData in payDraftDataList)
                {
                    // UI�f�[�^�N���X�����[�N
                    PayDraftDataWork payDraftDataWork = CopyToPayDraftDataWorkFromPayDraftData(payDraftData);

                    payDraftDataWorkList.Add(payDraftDataWork);
                }

                object paraObj = payDraftDataWorkList;

                // �����폜����
                status = this._iPayDraftDataDB.Delete(ref paraObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endregion

        #region ��������
        /// <summary>
        /// ��������(�x����`�f�[�^�}�X�^)
        /// </summary>
        /// <param name="payDraftDataList">�x����`�f�[�^�}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �x����`�f�[�^�}�X�^�𕜊����܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        public int Revival(ref List<PayDraftData> payDraftDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList payDraftDataWorkList = new ArrayList();

                foreach (PayDraftData payDraftData in payDraftDataList)
                {
                    // UI�f�[�^�N���X�����[�N
                    PayDraftDataWork payDraftDataWork = CopyToPayDraftDataWorkFromPayDraftData(payDraftData);

                    payDraftDataWorkList.Add(payDraftDataWork);
                }

                object paraObj = payDraftDataWorkList;

                // �_���폜����
                status = this._iPayDraftDataDB.RevivalLogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    payDraftDataWorkList = paraObj as ArrayList;

                    payDraftDataList.Clear();
                    foreach (PayDraftDataWork payDraftDataWork in payDraftDataWorkList)
                    {
                        // ���[�N��UI�f�[�^�N���X
                        PayDraftData payDraftData = CopyToPayDraftDataFromPayDraftDataWork(payDraftDataWork);

                        payDraftDataList.Add(payDraftData);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        # endregion

        # region -- �N���X�����o�[�R�s�[���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�x����`�f�[�^�}�X�^���[�N�N���X�ˎx����`�f�[�^�}�X�^�N���X�j
        /// </summary>
        /// <param name="payDraftDataWork">�x����`�f�[�^�}�X�^���[�N�N���X</param>
        /// <returns>�x����`�f�[�^�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �x����`�f�[�^�}�X�^���[�N�N���X����x����`�f�[�^�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        private PayDraftData CopyToPayDraftDataFromPayDraftDataWork(PayDraftDataWork payDraftDataWork)
        {
            PayDraftData payDraftData = new PayDraftData();

            payDraftData.CreateDateTime = payDraftDataWork.CreateDateTime;
            payDraftData.UpdateDateTime = payDraftDataWork.UpdateDateTime;
            payDraftData.EnterpriseCode = payDraftDataWork.EnterpriseCode;
            payDraftData.FileHeaderGuid = payDraftDataWork.FileHeaderGuid;
            payDraftData.UpdEmployeeCode = payDraftDataWork.UpdEmployeeCode;
            payDraftData.UpdAssemblyId1 = payDraftDataWork.UpdAssemblyId1;
            payDraftData.UpdAssemblyId2 = payDraftDataWork.UpdAssemblyId2;
            payDraftData.LogicalDeleteCode = payDraftDataWork.LogicalDeleteCode;
            payDraftData.PayDraftNo = payDraftDataWork.PayDraftNo;
            payDraftData.DraftKindCd = payDraftDataWork.DraftKindCd;
            payDraftData.DraftDivide = payDraftDataWork.DraftDivide;
            payDraftData.Payment = payDraftDataWork.Payment;
            payDraftData.BankAndBranchCd = payDraftDataWork.BankAndBranchCd;
            payDraftData.BankAndBranchNm = payDraftDataWork.BankAndBranchNm;
            payDraftData.SectionCode = payDraftDataWork.SectionCode;
            payDraftData.AddUpSecCode = payDraftDataWork.AddUpSecCode;
            payDraftData.SupplierCd = payDraftDataWork.SupplierCd;
            payDraftData.SupplierNm1 = payDraftDataWork.SupplierNm1;
            payDraftData.SupplierNm2 = payDraftDataWork.SupplierNm2;
            payDraftData.SupplierSnm = payDraftDataWork.SupplierSnm;
            payDraftData.ProcDate = payDraftDataWork.ProcDate;
            payDraftData.DraftDrawingDate = payDraftDataWork.DraftDrawingDate;
            payDraftData.ValidityTerm = payDraftDataWork.ValidityTerm;
            payDraftData.DraftStmntDate = payDraftDataWork.DraftStmntDate;
            payDraftData.Outline1 = payDraftDataWork.Outline1;
            payDraftData.Outline2 = payDraftDataWork.Outline2;
            payDraftData.SupplierFormal = payDraftDataWork.SupplierFormal;
            payDraftData.PaymentSlipNo = payDraftDataWork.PaymentSlipNo;
            payDraftData.PaymentRowNo = payDraftDataWork.PaymentRowNo;
            payDraftData.PaymentDate = payDraftDataWork.PaymentDate;


            return payDraftData;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�x����`�f�[�^�}�X�^�N���X�ˎx����`�f�[�^�}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="payDraftData">�x����`�f�[�^�}�X�^�N���X</param>
        /// <returns>�x����`�f�[�^�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �x����`�f�[�^�}�X�^�N���X����x����`�f�[�^�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        private PayDraftDataWork CopyToPayDraftDataWorkFromPayDraftData(PayDraftData payDraftData)
        {
            PayDraftDataWork payDraftDataWork = new PayDraftDataWork();

            payDraftDataWork.CreateDateTime = payDraftData.CreateDateTime;
            payDraftDataWork.UpdateDateTime = payDraftData.UpdateDateTime;
            payDraftDataWork.EnterpriseCode = payDraftData.EnterpriseCode;
            payDraftDataWork.FileHeaderGuid = payDraftData.FileHeaderGuid;
            payDraftDataWork.UpdEmployeeCode = payDraftData.UpdEmployeeCode;
            payDraftDataWork.UpdAssemblyId1 = payDraftData.UpdAssemblyId1;
            payDraftDataWork.UpdAssemblyId2 = payDraftData.UpdAssemblyId2;
            payDraftDataWork.LogicalDeleteCode = payDraftData.LogicalDeleteCode;
            payDraftDataWork.PayDraftNo = payDraftData.PayDraftNo;
            payDraftDataWork.DraftKindCd = payDraftData.DraftKindCd;
            payDraftDataWork.DraftDivide = payDraftData.DraftDivide;
            payDraftDataWork.Payment = payDraftData.Payment;
            payDraftDataWork.BankAndBranchCd = payDraftData.BankAndBranchCd;
            payDraftDataWork.BankAndBranchNm = payDraftData.BankAndBranchNm;
            payDraftDataWork.SectionCode = payDraftData.SectionCode;
            payDraftDataWork.AddUpSecCode = payDraftData.AddUpSecCode;
            payDraftDataWork.SupplierCd = payDraftData.SupplierCd;
            payDraftDataWork.SupplierNm1 = payDraftData.SupplierNm1;
            payDraftDataWork.SupplierNm2 = payDraftData.SupplierNm2;
            payDraftDataWork.SupplierSnm = payDraftData.SupplierSnm;
            payDraftDataWork.ProcDate = payDraftData.ProcDate;
            payDraftDataWork.DraftDrawingDate = payDraftData.DraftDrawingDate;
            payDraftDataWork.ValidityTerm = payDraftData.ValidityTerm;
            payDraftDataWork.DraftStmntDate = payDraftData.DraftStmntDate;
            payDraftDataWork.Outline1 = payDraftData.Outline1;
            payDraftDataWork.Outline2 = payDraftData.Outline2;
            payDraftDataWork.SupplierFormal = payDraftData.SupplierFormal;
            payDraftDataWork.PaymentSlipNo = payDraftData.PaymentSlipNo;
            payDraftDataWork.PaymentRowNo = payDraftData.PaymentRowNo;
            payDraftDataWork.PaymentDate = payDraftData.PaymentDate;


            return payDraftDataWork;
        }
        # endregion
    }
}
