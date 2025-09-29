//****************************************************************************//
// �V�X�e��         : LSM���O�`�F�b�N
// �v���O��������   : LSM���O�`�F�b�N�A�N�Z�X�N���X
// �v���O�����T�v   : LSM���O�`�F�b�N�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �e�c ���V
// �� �� ��  2015/09/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �� �� ��  2015/10/08  �C�����e : �@������`�F�b�N�����[�g�̒ǉ�
//                                  �ALSM�`�F�b�N�����[�g�̖߂�l����ŐV���R�[�h�݂̂�
//                                    �擾���ċ��_�Ǘ������[�g�ɓn���悤�ɕύX
//                                  �B���s�R�[�h�������Ă���ꍇ�A�f�[�^���͍폜�A
//                                    ��ʑ��͂��̂܂ܓn���B
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{

    /// <summary>
    /// ���O�A�b�v���[�h���O���i�N���X
    /// </summary>
    public class LsmHistoryLog
    {
        #region <Const/>

        /// <summary>��������</summary>
        //--- DEL 2015/10/08 20073 T.Nishi ----->>>>>
        //private string[] LOGMSG_ERROR = { "�G���[", "���s", "�ǂݍ��߂܂���", "������܂���" };
        //private string LOGMSG_NORMAL = "���i�T�[�r�X�̃A�b�v�f�[�g������";
        //--- DEL 2015/10/08 20073 T.Nishi -----<<<<<

        /// <summary>���b�Z�[�W�̍ő咷</summary>
        private const int MAX_MESSAGE_LENGTH = 500;

        #endregion  // <Const/>

        #region <�����[�g��`/>

        /// <summary>���O�A�b�v���[�h�f�[�^�����[�g</summary>
        private readonly ILsmHisLogDB _lsmHisLogDB;
        /// <summary>LSM���O�`�F�b�N�����[�g</summary>
        private readonly ILSMLogCheckDB _lsmLogCheckDB;
        //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
        private readonly ILsmChkWordDB _lsmChkWordDB;
        //--- ADD 2015/10/08 20073 T.Nishi -----<<<<<

        #endregion  // <�����[�g��`/>

        #region <�A�N�Z�T/>
        /// <summary>
        /// �쐬�������擾���܂��B
        /// </summary>
        /// <value>�쐬����</value>
        public static DateTime LogDataCreateDateTime
        {
            get { return TDateTime.GetSFDateNow(); }
        }

        /// <summary>��ƃR�[�h</summary>
        private readonly string _enterpriseCode;
        /// <summary>
        /// ��ƃR�[�h���擾���܂��B
        /// </summary>
        /// <remarks>��2�� + ��2�� + �Ǝ�2�� + ���[�U�[�R�[�h10��</remarks>
        /// <value>��ƃR�[�h</value>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
        }

        /// <summary>���O�f�[�^�[����</summary>
        private string _logDataMachineName;
        /// <summary>
        /// ���O�f�[�^�[�������擾���܂��B
        /// </summary>
        /// <value>���O�f�[�^�[����</value>
        public string LogDataMachineName
        {
            get { return _logDataMachineName; }
            set { _logDataMachineName = value; }
        }

        #endregion  // <�A�N�Z�T/>

        #region <Constructor/>
        
        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        public LsmHistoryLog()
        {
            try
            {
                _lsmHisLogDB = (ILsmHisLogDB)MediationLsmHisLogDB.GetLsmHisLogDB();
                _lsmLogCheckDB = (ILSMLogCheckDB)MediationLSMLogCheckDB.GetLSMLogCheckDB();
                //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
                _lsmChkWordDB = (ILsmChkWordDB)MediationLsmChkWordDB.GetLsmChkWordDB();
                //--- ADD 2015/10/08 20073 T.Nishi -----<<<<<
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                // 
                _lsmHisLogDB = null;
                _lsmLogCheckDB = null;
            }

            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //_logDataMachineName = Environment.MachineName;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// �������ݏ������s���܂��B
        /// </summary>
        /// <param name="retList">���X�g</param>
        public int WriteLsmLog(out object retList, bool LogWriteFlg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            int status2 = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            object retWorkList = null;
            //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
            object chkParaList = null;
            //--- ADD 2015/10/08 20073 T.Nishi -----<<<<<
            LsmHisLogWork writingLog;
            ArrayList list = new ArrayList();

            retList = null;
            try
            {

                //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
                status = _lsmChkWordDB.Search(out chkParaList);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //--- ADD 2015/10/08 20073 T.Nishi -----<<<<<

                    //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
                    // LSM���O�`�F�b�N�����[�g
                    //status = _lsmLogCheckDB.CheckLSMLog(out retWorkList);
                    status = _lsmLogCheckDB.CheckLSMLog(out retWorkList, out _logDataMachineName, chkParaList);
                    //--- UPD 2015/10/08 20073 T.Nishi -----<<<<<

                    ArrayList msgList = (ArrayList)retWorkList;
                    //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
                    //for (int i = 0; i < msgList.Count; i++)
                    //{
                    //    // LSM���O�f�[�^�ݒ�
                    //    this.SetWritingLog(msgList[i].ToString(), out writingLog);
                    //    // ���X�g�ɐݒ�
                    //    list.Add(writingLog);
                    //}
                    this.SetWritingLog(msgList[msgList.Count - 1].ToString(), chkParaList, status, out writingLog);
                    //�f�[�^���̃��b�Z�[�W�ɉ��s�R�[�h���܂܂�Ă���ꍇ�͍폜
                    //writingLog.LogDataMassage = writingLog.LogDataMassage.Replace("\r\n", "");
                    list.Add(writingLog);
                    //--- UPD 2015/10/08 20073 T.Nishi -----<<<<<
                    if (LogWriteFlg == true)
                    {
                        // LSM���O�f�[�^�o�^
                        status2 = this.Write(ref list);
                    }
                    else
                    {
                        status2 = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    if (status2.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    {
                    }
                    else
                    {
                        status = status2;
                    }
                    //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
                }
                else
                {
                    // LSM���O�f�[�^�ݒ�
                    string message = "�`�F�b�N�Ώۂ̕�����̎擾�Ɏ��s���܂����Bstatus=" + status.ToString();
                    //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
                    //this.SetWritingLog(message, out writingLog);
                    this.SetWritingLog(message, chkParaList, (int)ConstantManagement.MethodResult.ctFNC_ERROR, out writingLog);
                    //--- UPD 2015/10/08 20073 T.Nishi -----<<<<<
                    list.Add(writingLog);
                }
                //--- ADD 2015/10/08 20073 T.Nishi ----->>>>>
            }
            catch (Exception ex)
            {
                // LSM���O�f�[�^�ݒ�
                //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
                //this.SetWritingLog(ex.Message + "(WriteLsmLog)", out writingLog);
                this.SetWritingLog(ex.Message + "(WriteLsmLog)", chkParaList, (int)ConstantManagement.MethodResult.ctFNC_ERROR, out writingLog);
                //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
                list.Add(writingLog);
            }
            finally
            {
                retList = list;
            }

            return status;
        }

        /// <summary>
        /// �������ݏ������s���܂��B
        /// </summary>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="writingLog">LSM���O�f�[�^</param>
        //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
        //private void SetWritingLog(string message, out LsmHisLogWork writingLog)
        private void SetWritingLog(string message, object chkParaList, int Retstatus, out LsmHisLogWork writingLog)
        //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
        {
            int logDataKindCd = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
            //// �����񌟍�
            //if (0 <= message.IndexOf(LOGMSG_NORMAL))
            //{
            //    // ����`�F�b�N
            //    logDataKindCd = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //}
            int status = Retstatus;
            int operationcode = 0;
            if (chkParaList != null)
            {
                ArrayList _lsmChkWordWorkList = new ArrayList();
                _lsmChkWordWorkList = (ArrayList)chkParaList;
                foreach (LsmChkWordWork lsmChkWordWork in _lsmChkWordWorkList)
                {
                    if (0 <= message.IndexOf(lsmChkWordWork.Massage))
                    {
                        status = lsmChkWordWork.Status;
                        operationcode = lsmChkWordWork.OperationCode;
                        message = message + "\r\n" + lsmChkWordWork.LogDataMessage;
                        break;
                    }
                }
            }
            logDataKindCd = status;
            //--- UPD 2015/10/08 20073 T.Nishi -----<<<<<

            writingLog = new LsmHisLogWork();
            {
                // �쐬����
                // �X�V����
                // ��ƃR�[�h
                writingLog.EnterpriseCode = EnterpriseCode;
                // GUID
                // �X�V�]�ƈ��R�[�h
                // �X�V�A�Z���u��ID1
                // �X�V�A�Z���u��ID2
                // �_���폜�敪
                // ���O�f�[�^�쐬����
                writingLog.LogDataCreateDateTime = LogDataCreateDateTime;
                // ���O�f�[�^GUID
                // ���O�C�����_�R�[�h
                writingLog.LoginSectionCd = "";
                // ���O�f�[�^��ʋ敪�R�[�h
                writingLog.LogDataKindCd = logDataKindCd;
                // ���O�f�[�^�[����
                writingLog.LogDataMachineName = LogDataMachineName;
                // ���O�f�[�^�S���҃R�[�h
                writingLog.LogDataAgentCd = "";
                // ���O�f�[�^�S���Җ�
                writingLog.LogDataAgentNm = "";
                // ���O�f�[�^�ΏۋN���v���O��������
                writingLog.LogDataObjBootProgramNm = "�z�M�`�F�b�N�c�[��";
                // ���O�f�[�^�ΏۃA�Z���u��ID
                writingLog.LogDataObjAssemblyID = "PMCMN00083A";
                // ���O�f�[�^�ΏۃA�Z���u������
                writingLog.LogDataObjAssemblyNm = "LSM�`�F�b�N�A�N�Z�X�N���X";
                // ���O�f�[�^�ΏۃN���XID
                writingLog.LogDataObjClassID = "";
                // ���O�f�[�^�Ώۏ�����
                writingLog.LogDataObjProcNm = "";
                // ���O�f�[�^�I�y���[�V�����R�[�h
                writingLog.LogDataOperationCd = operationcode;
                // ���O�f�[�^�I�y���[�^�[�f�[�^�������x��
                writingLog.LogOperaterDtProcLvl = "";
                // ���O�f�[�^�I�y���[�^�[�@�\�������x��
                writingLog.LogOperaterFuncLvl = "";
                // ���O�f�[�^�V�X�e���o�[�W����
                writingLog.LogDataSystemVersion = "";
                // ���O�I�y���[�V�����X�e�[�^�X
                writingLog.LogOperationStatus = 0;

                // ���O�f�[�^���b�Z�[�W
                if (message.Length > MAX_MESSAGE_LENGTH)
                {
                    writingLog.LogDataMassage = message.Substring(0, MAX_MESSAGE_LENGTH);
                }
                else
                {
                    writingLog.LogDataMassage = message;
                }
                // ���O�I�y���[�V�����f�[�^
                writingLog.LogOperationData = "USB�ԍ��F";
            }
        }

        /// <summary>
        /// ���O���������݂܂��B
        /// </summary>
        /// <param name="logList">���X�g</param>
        public int Write(ref ArrayList logList)
        {
            LsmHisLogWork writingLog;
            ArrayList list = new ArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            object objDoingRecord = logList;

            try
            {
                status = _lsmHisLogDB.Write(ref objDoingRecord);

                if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
                {
                    // ���O�̏������݂ɐ���
                    list = logList;
                }
                else
                {
                    // ���O�̏������݂Ɏ��s
                    //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
                    //this.SetWritingLog("���O�̏������݂Ɏ��s", out writingLog);
                    this.SetWritingLog("���O�̏������݂Ɏ��s", null, status, out writingLog);
                    //--- UPD 2015/10/08 20073 T.Nishi -----<<<<<
                    list.Add(writingLog);
                }
            }
            catch (Exception ex)
            {
                // LSM���O�f�[�^�ݒ�
                //--- UPD 2015/10/08 20073 T.Nishi ----->>>>>
                //this.SetWritingLog(ex.Message + "(Write)", out writingLog);
                this.SetWritingLog(ex.Message + "(Write)", null, status, out writingLog);
                //--- UPD 2015/10/08 20073 T.Nishi -----<<<<<
                list.Add(writingLog);
            }
            finally
            {
                logList = list;
            }

            return status;
        }
    }
}
