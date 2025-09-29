//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���엚�����O�f�[�^�̏�������
// �v���O�����T�v   : ���엚�����O�f�[�^�ǉ��������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/05/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Data;


using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.IO;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���엚�����O�f�[�^�̏�������DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���엚�����O�f�[�^�̏�������DB�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class OperationLogSvrDB
    {

        #region �� Const Memebers ��
        // �X�V�]�ƈ��R�[�h
        private const string UPDEMPLOYEE_ID = "9999";
        #endregion

        # region �� Constructor ��
        /// <summary>
        /// ���엚�����O�f�[�^���[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���엚�����O�f�[�^�̏������݂���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.5.15</br>
        /// </remarks>
        public OperationLogSvrDB()
        {
        }
        #endregion

        # region �� ���엚�����O�f�[�^�̏������݊֘A ��
        /// <summary>
        /// ���엚�����O�f�[�^�̏������݁B
        /// </summary>
        /// <param name="sender">�ďo���I�u�W�F�N�g</param>
        /// <param name="logDataCreateDateTime">����</param>
        /// <param name="logDataKind">���O���</param>
        /// <param name="programId">�v���O����ID</param>
        /// <param name="programName">�v���O������</param>
        /// <param name="methodName">���\�b�h��</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="data">�f�[�^</param>
        /// <br>Note       : ���엚�����O�f�[�^���������݂���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.5.15</br>
        public void WriteOperationLogSvr(object sender, DateTime logDataCreateDateTime, LogDataKind logDataKind,
                            string programId, string programName, string methodName, Int32 operationCode,
                            Int32 status, string message, string data)
        {

            // ��ƃR�[�h
            string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �o�^�w�b�_���
            OprtnHisLogWork oprtnHisLogInsertWork = new OprtnHisLogWork();
            object objInsert = (object)this;
            IFileHeader insertIf = (IFileHeader)oprtnHisLogInsertWork;
            FileHeader fileInsert = new FileHeader(objInsert);
            fileInsert.SetInsertHeader(ref insertIf, objInsert);

            ArrayList oprtnHisLogWorkList = new ArrayList();
            OprtnHisLogWork oprtnHisLogWork = new OprtnHisLogWork();
            // �쐬����
            oprtnHisLogWork.CreateDateTime = oprtnHisLogInsertWork.CreateDateTime;
            // �X�V����
            oprtnHisLogWork.UpdateDateTime = oprtnHisLogInsertWork.UpdateDateTime;
            // ��ƃR�[�h
            oprtnHisLogWork.EnterpriseCode = _enterpriseCode;
            // GUID
            oprtnHisLogWork.FileHeaderGuid = oprtnHisLogInsertWork.FileHeaderGuid;
            // �X�V�]�ƈ��R�[�h
            oprtnHisLogWork.UpdEmployeeCode = UPDEMPLOYEE_ID;
            // �X�V�A�Z���u��ID1
            oprtnHisLogWork.UpdAssemblyId1 = oprtnHisLogInsertWork.UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            oprtnHisLogWork.UpdAssemblyId2 = oprtnHisLogInsertWork.UpdAssemblyId2;
            // �_���폜�敪
            oprtnHisLogWork.LogicalDeleteCode = oprtnHisLogInsertWork.LogicalDeleteCode;
            // ���O�f�[�^�쐬����
            oprtnHisLogWork.LogDataCreateDateTime = logDataCreateDateTime;
            // ���O�f�[�^GUID
            Guid guid = Guid.NewGuid();
            oprtnHisLogWork.LogDataGuid = guid;
            // ���O�f�[�^��ʋ敪�R�[�h
            oprtnHisLogWork.LogDataKindCd = (int)logDataKind;
            // ���O�f�[�^�ΏۋN���v���O��������
            oprtnHisLogWork.LogDataObjBootProgramNm = programName;
            // ���O�f�[�^�ΏۃA�Z���u��ID
            oprtnHisLogWork.LogDataObjAssemblyID = programId;
            // ���O�f�[�^�ΏۃA�Z���u������
            oprtnHisLogWork.LogDataObjAssemblyNm = programName;
            // ���O�f�[�^�ΏۃN���XID
            string[] senderInfo = this.GetSenderInfo(sender);
            oprtnHisLogWork.LogDataObjClassID = senderInfo[1];
            // ���O�f�[�^�Ώۏ�����
            oprtnHisLogWork.LogDataObjProcNm = methodName;
            // ���O�f�[�^�I�y���[�V�����R�[�h
            oprtnHisLogWork.LogDataOperationCd = operationCode;
            // ���O�f�[�^�V�X�e���o�[�W����
            oprtnHisLogWork.LogDataSystemVersion = senderInfo[2];
            // ���O�I�y���[�V�����X�e�[�^�X
            oprtnHisLogWork.LogOperationStatus = status;
            // ���O�f�[�^���b�Z�[�W
            if (message.Length > 500)
            {
                oprtnHisLogWork.LogDataMassage = message.Substring(0, 500);
            }
            else
            {
                oprtnHisLogWork.LogDataMassage = message;
            }
            // ���O�I�y���[�V�����f�[�^
            if (data.Length > 80)
            {
                oprtnHisLogWork.LogOperationData = data.Substring(0, 80);
            }
            else
            {
                oprtnHisLogWork.LogOperationData = data;
            }
            oprtnHisLogWorkList.Add(oprtnHisLogWork);

            IOprtnHisLogDB iOprtnHisLogDB = MediationOprtnHisLogDB.GetOprtnHisLogDB();

            object objPara = (object)oprtnHisLogWorkList;

            // ���엚�����O�f�[�^�̏������݁B
            int dbStatus = iOprtnHisLogDB.Write(ref objPara);

        }

        /// <summary>
        /// �I�y���[�V�����}�X�^�̓o�^���e�Ɛ����������Ă���B
        /// </summary>
        /// <param name="sender">�ďo���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �I�y���[�V�����}�X�^�̓o�^���e�Ɛ����������Ă���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.5.15</br>
        private string[] GetSenderInfo(object sender)
        {
            string[] strArray = new string[] { string.Empty, string.Empty, string.Empty };
            if (sender != null)
            {
                Type type = sender.GetType();
                AssemblyName name = type.Assembly.GetName();
                if (name != null)
                {
                    strArray[0] = name.Name;
                    strArray[2] = name.Version.ToString();
                }
                if (type != null)
                {
                    strArray[1] = type.Name;
                }
            }
            return strArray;
        }
        #endregion

    }
}
