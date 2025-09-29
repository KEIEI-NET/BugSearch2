//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���쌠���擾���i
// �v���O�����T�v   : �ȉ��̃N���X��Facade(����)�ƂȂ�܂��B
//                  : �E���엚�������[�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/08/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/04/16  �C�����e : Mantis�y13188�z�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Log;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    using DBAccessType      = IOprtnHisLogDB;
    using DBRecordType      = OprtnHisLogWork;
    using DBConditionType   = OprtnHisLogSrchWork;

    #region <�񋓌^/>

    /// <summary>
    /// ���O���
    /// </summary>
    public enum LogDataKind : int
    {
        /// <summary>���샍�O</summary>
        OperationLog = 0,
        /// <summary>�G���[���O</summary>
        ErrorLog = 1,
        /// <summary>�V�X�e�����O</summary>
        SystemLog = 9,
        /// <summary>UOE(DSP)���O</summary>
        UoeDspLog = 10,
        /// <summary>UOE(�ʐM)���O</summary>
        UoeCommLog = 11
    }

    #endregion  // <�񋓌^/>

    /// <summary>
    /// ���엚�����O���i�N���X
    /// </summary>
    public class OperationHistoryLog
    {
        #region <Const/>

        /// <summary>������̍ő咷</summary>
        private const int MAX_STRING_LENGTH = 80;

        /// <summary>���b�Z�[�W�̍ő咷</summary>
        private const int MAX_MESSAGE_LENGTH = 500;     // ADD 2009/04/16

        /// <summary>
        /// �Ăяo�����I�u�W�F�N�g�̃A�Z���u�����C���f�b�N�X�񋓑�
        /// </summary>
        private enum SenderInfoIdx : int
        {
            /// <summary>���O�f�[�^�ΏۃA�Z���u��ID</summary>
            LogDataObjAssemblyID,
            /// <summary>���O�f�[�^�ΏۃN���XID</summary>
            LogDataObjClassID,
            /// <summary>���O�f�[�^�V�X�e���o�[�W����</summary>
            LogDataSystemVersion
        }

        /// <summary>�ő又�����x��</summary>
        private const int MAX_LEVEL = 99;

        #endregion  // <Const/>

        #region <���엚���f�[�^DB/>

        /// <summary>���엚���f�[�^DB�̃A�N�Z�T</summary>
        private readonly DBAccessType _oprtnHisLogDBAccesser;
        /// <summary>
        /// ���엚���f�[�^DB�̃A�N�Z�T���擾���܂��B
        /// </summary>
        /// <value>���엚���f�[�^DB�̃A�N�Z�T</value>
        protected DBAccessType OprtnHisLogDBAccesser { get { return _oprtnHisLogDBAccesser; } }

        #endregion  // <���엚���f�[�^DB/>

        #region <�A�N�Z�T/>

        /// <summary>�I�t���C�����̏o�̓t�H���_�p�X</summary>
        private readonly string _folderPath;
        /// <summary>
        /// �I�t���C�����̏o�̓t�H���_�p�X���擾���܂��B
        /// </summary>
        /// <value>�I�t���C�����̏o�̓t�H���_�p�X</value>
        private string FolderPath { get { return _folderPath; } }

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

        /// <summary>
        /// ���O�C�����_�R�[�h���擾���܂��B
        /// </summary>
        /// <value>���O�C�����_�R�[�h</value>
        public string LoginSectionCd
        {
            get
            {
                if (LoginEmployee != null) return LoginEmployee.BelongSectionCode;
                return string.Empty;
            }
        }

        /// <summary>���O�f�[�^�[����</summary>
        private readonly string _logDataMachineName;
        /// <summary>
        /// ���O�f�[�^�[�������擾���܂��B
        /// </summary>
        /// <value>���O�f�[�^�[����</value>
        public string LogDataMachineName
        {
            get { return _logDataMachineName; }
        }

        /// <summary>
        /// ���O�f�[�^�S���҃R�[�h���擾���܂��B
        /// </summary>
        /// <value>���O�f�[�^�S���҃R�[�h</value>
        public string LogDataAgentCd
        {
            get
            {
                if (LoginEmployee != null) return LoginEmployee.EmployeeCode;
                return string.Empty;
            }
        }

        /// <summary>
        /// ���O�f�[�^�S���Җ����擾���܂��B
        /// </summary>
        /// <value>���O�f�[�^�S���Җ�</value>
        public string LogDataAgentNm
        {
            get
            {
                if (LoginEmployee != null) return LoginEmployee.Name;
                return string.Empty;
            }
        }

        /// <summary>���O�C���]�ƈ�</summary>
        private readonly Employee _loginEmployee;
        /// <summary>
        /// ���O�C���]�ƈ����擾���܂��B
        /// </summary>
        /// <value>���O�C���]�ƈ�</value>
        public Employee LoginEmployee
        {
            get { return _loginEmployee; }
        }

        #endregion  // <�A�N�Z�T/>

        #region <Constructor/>
        
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public OperationHistoryLog() : this(OfflineLogger.DEFAULT_FOLDER_PATH) { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="folderPath">�I�t���C�����̏o�̓t�H���_�p�X</param>
        public OperationHistoryLog(string folderPath)
        {
            _folderPath = folderPath;

            try
            {
                _oprtnHisLogDBAccesser = MediationOprtnHisLogDB.GetOprtnHisLogDB();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                // 
                //_oprtnHisLogDBAccesser = new NullOnlineLogger();
                _oprtnHisLogDBAccesser = null;
            }

            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _logDataMachineName = Environment.MachineName;

            if (LoginInfoAcquisition.Employee != null)
            {
                _loginEmployee = LoginInfoAcquisition.Employee.Clone();
            }
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// �������ݏ������s���܂��B
        /// </summary>
        /// <param name="sender">�Ăяo�����I�u�W�F�N�g</param>
        /// <param name="logDataKind">���O���</param>
        /// <param name="programId">�v���O����ID(���I�y���[�V�����}�X�^�̓o�^���e�Ɛ����������Ă���K�v������܂�)</param>
        /// <param name="programName">�v���O������(���I�y���[�V�����}�X�^�̓o�^���e�Ɛ����������Ă���K�v������܂�)</param>
        /// <param name="methodName">���\�b�h��</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="data">�f�[�^</param>
        public void WriteOperationLog(
            object sender,
            LogDataKind logDataKind,
            string programId,
            string programName,
            string methodName,
            int operationCode,
            int status,
            string message,
            string data
        )
        {
            WriteOperationLog(
                sender,
                LogDataCreateDateTime,  // �f�t�H���g�̃��O�f�[�^�쐬����
                logDataKind,
                programId,
                programName,
                methodName,
                operationCode,
                status,
                message,
                data
            );
        }

        /// <summary>
        /// �������ݏ������s���܂��B
        /// </summary>
        /// <param name="sender">�Ăяo�����I�u�W�F�N�g</param>
        /// <param name="logDataCreateDateTime">���O�f�[�^�쐬����</param>
        /// <param name="logDataKind">���O���</param>
        /// <param name="programId">�v���O����ID(���I�y���[�V�����}�X�^�̓o�^���e�Ɛ����������Ă���K�v������܂�)</param>
        /// <param name="programName">�v���O������(���I�y���[�V�����}�X�^�̓o�^���e�Ɛ����������Ă���K�v������܂�)</param>
        /// <param name="methodName">���\�b�h��</param>
        /// <param name="operationCode">�I�y���[�V�����R�[�h</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="data">�f�[�^</param>
        public void WriteOperationLog(
            object sender,
            DateTime logDataCreateDateTime,
            LogDataKind logDataKind,
            string programId,
            string programName,
            string methodName,
            int operationCode,
            int status,
            string message,
            string data
        )
        {
            DBRecordType writingLog = new DBRecordType();
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
                writingLog.LogDataCreateDateTime = logDataCreateDateTime;
                // ���O�f�[�^GUID
                //
                // ���O�C�����_�R�[�h
                writingLog.LoginSectionCd = LoginSectionCd.Trim();
                // ���O�f�[�^��ʋ敪�R�[�h
                writingLog.LogDataKindCd = (int)logDataKind;
                // ���O�f�[�^�[����
                writingLog.LogDataMachineName = LogDataMachineName;
                // ���O�f�[�^�S���҃R�[�h
                writingLog.LogDataAgentCd = LogDataAgentCd.Trim();
                // ���O�f�[�^�S���Җ�
                writingLog.LogDataAgentNm = LogDataAgentNm;
                // ���O�f�[�^�ΏۋN���v���O��������
                writingLog.LogDataObjBootProgramNm = programName;

                string[] senderInfos = GetSenderInfo(sender);
                {
                    // ���O�f�[�^�ΏۃA�Z���u��ID
                    writingLog.LogDataObjAssemblyID = programId;
                    // ���O�f�[�^�ΏۃA�Z���u������
                    writingLog.LogDataObjAssemblyNm = programName;
                    // ���O�f�[�^�ΏۃN���XID
                    writingLog.LogDataObjClassID = senderInfos[(int)SenderInfoIdx.LogDataObjClassID];
                    // ���O�f�[�^�Ώۏ�����
                    writingLog.LogDataObjProcNm = methodName;
                    // ���O�f�[�^�I�y���[�V�����R�[�h
                    writingLog.LogDataOperationCd = operationCode;
                    // ���O�f�[�^�I�y���[�^�[�f�[�^�������x��
                    if (LoginEmployee.AuthorityLevel1 <= MAX_LEVEL)
                    {
                        writingLog.LogOperaterDtProcLvl = LoginEmployee.AuthorityLevel1.ToString();
                    }
                    else
                    {
                        writingLog.LogOperaterDtProcLvl = MAX_LEVEL.ToString();
                    }
                    // ���O�f�[�^�I�y���[�^�[�@�\�������x��
                    if (LoginEmployee.AuthorityLevel2 <= MAX_LEVEL)
                    {
                        writingLog.LogOperaterFuncLvl = LoginEmployee.AuthorityLevel2.ToString();
                    }
                    else
                    {
                        writingLog.LogOperaterFuncLvl = MAX_LEVEL.ToString();
                    }
                    // ���O�f�[�^�V�X�e���o�[�W����
                    writingLog.LogDataSystemVersion = senderInfos[(int)SenderInfoIdx.LogDataSystemVersion];
                }
                // ���O�I�y���[�V�����X�e�[�^�X
                writingLog.LogOperationStatus = status;
                // ���O�f�[�^���b�Z�[�W
                //if (message.Length > MAX_STRING_LENGTH)   // DEL 2009/04/16
                if (message.Length > MAX_MESSAGE_LENGTH)    // ADD 2009/04/16
                {
                    //writingLog.LogDataMassage = message.Substring(0, MAX_STRING_LENGTH);      // DEL 2009/04/16
                    writingLog.LogDataMassage = message.Substring(0, MAX_MESSAGE_LENGTH);       // ADD 2009/04/16
                }
                else
                {
                    writingLog.LogDataMassage = message;
                }
                // ���O�I�y���[�V�����f�[�^
                if (data.Length > MAX_STRING_LENGTH)
                {
                    writingLog.LogOperationData = data.Substring(0, MAX_STRING_LENGTH);
                }
                else
                {
                    writingLog.LogOperationData = data;
                }
            }

            LogRemoteHelper writer = new LogRemoteHelper(OprtnHisLogDBAccesser, writingLog);
            //writer.LogAccesserList.Add(new OfflineLogger(FolderPath));
            writer.SetOfflineLogger(FolderPath);
            // DEL 2009/02/25 �s��Ή�[11961]�� �}���`�X���b�h�̔p�~
            //Thread writeThread = new Thread(writer.TryToWrite);

            writer.TryToWrite();    // ADD 2009/02/25 �s��Ή�[11961] �}���`�X���b�h�̔p�~

            // DEL 2009/02/25 �s��Ή�[11961]�� �}���`�X���b�h�̔p�~
            //writeThread.Start();
        }

        /// <summary>
        /// �Ăяo�����I�u�W�F�N�g�����擾���܂��B
        /// </summary>
        /// <param name="sender">�Ăяo�����I�u�W�F�N�g</param>
        /// <returns>
        /// �Ăяo�����I�u�W�F�N�g���<br/>
        /// [0]:���O�f�[�^�ΏۃA�Z���u��ID<br/>
        /// [1]:���O�f�[�^�ΏۃN���XID<br/>
        /// [2]:���O�f�[�^�V�X�e���o�[�W����
        /// </returns>
        private static string[] GetSenderInfo(object sender)
        {
            string[] senderInfoArray = new string[3] { string.Empty, string.Empty, string.Empty };

            if (sender != null)
            {
                Type senderType = sender.GetType();
                AssemblyName assemblyName = senderType.Assembly.GetName();

                if (assemblyName != null)
                {
                    senderInfoArray[(int)SenderInfoIdx.LogDataObjAssemblyID] = assemblyName.Name;
                    senderInfoArray[(int)SenderInfoIdx.LogDataSystemVersion] = assemblyName.Version.ToString();
                }

                if (senderType != null) senderInfoArray[(int)SenderInfoIdx.LogDataObjClassID] = senderType.Name;
            }

            return senderInfoArray;
        }

        #region <����/>

        /// <summary>
        /// ���샍�O����������
        /// </summary>
        [Conditional("DEBUG")]
        public void TestWriteOperationLog()
        {
            OprtnHisLogWork writingLog = new OprtnHisLogWork();
            {
                // �쐬����
                // �X�V����
                // ��ƃR�[�h
                writingLog.EnterpriseCode = "0101150842020000";
                // GUID
                // �X�V�]�ƈ��R�[�h
                // �X�V�A�Z���u��ID1
                // �X�V�A�Z���u��ID2
                // �_���폜�敪
                // ���O�f�[�^�쐬����
                writingLog.LogDataCreateDateTime = DateTime.Now;
                // ���O�f�[�^GUID
                //writingLog.LogDataGuid = Guid.NewGuid();
                // ���O�C�����_�R�[�h
                writingLog.LoginSectionCd = "01";
                // ���O�f�[�^��ʋ敪�R�[�h
                writingLog.LogDataKindCd = 1;   // �G���[
                // ���O�f�[�^�[����
                writingLog.LogDataMachineName = "91405A6";
                // ���O�f�[�^�S���҃R�[�h
                writingLog.LogDataAgentCd = "9999";
                // ���O�f�[�^�S���Җ�
                writingLog.LogDataAgentNm = "�����e�S��";
                // ���O�f�[�^�ΏۋN���v���O��������
                writingLog.LogDataObjBootProgramNm = "�Z�L�����e�B�Ǘ�";

                string[] senderInfos = GetSenderInfo(this);
                {
                    // ���O�f�[�^�ΏۃA�Z���u��ID
                    writingLog.LogDataObjAssemblyID = "MAHNB01010U"; // ���v���O����ID
                    // ���O�f�[�^�ΏۃA�Z���u������
                    writingLog.LogDataObjAssemblyNm = "����`�[����";
                    // ���O�f�[�^�ΏۃN���XID
                    writingLog.LogDataObjClassID = "OperationHistoryLog";
                    // ���O�f�[�^�Ώۏ�����
                    writingLog.LogDataObjProcNm = "TestWriteOperationLog";
                    // ���O�f�[�^�I�y���[�V����
                    writingLog.LogDataOperationCd = 10; // �ԓ`
                    // ���O�f�[�^�I�y���[�^�[�f�[�^�������x��
                    writingLog.LogOperaterDtProcLvl = "10"; // 2���܂ŁI
                    // ���O�f�[�^�I�y���[�^�[�@�\�������x��
                    writingLog.LogOperaterFuncLvl = "50";
                    // ���O�f�[�^�V�X�e���o�[�W����
                    writingLog.LogDataSystemVersion = "8.10.1.0";
                }

                // ���O�I�y���[�V�����X�e�[�^�X
                writingLog.LogOperationStatus = 1;
                // ���O�f�[�^���b�Z�[�W
                writingLog.LogDataMassage = "���O�f�[�^���b�Z�[�W";
                // ���O�I�y���[�V�����f�[�^
                writingLog.LogOperationData = "���O�I�y���[�V�����f�[�^";
            }

            object objWritingLog = writingLog;

            IOprtnHisLogDB accesser = MediationOprtnHisLogDB.GetOprtnHisLogDB();
            int ret = accesser.Write(ref objWritingLog);
            if (!ret.Equals(0))
            {
                Debug.Assert(false, MsgUtil.GetMsg(ret, ""));
            }
        }

        #endregion  // <����/>
    }

    #region <Helper/>

    /// <summary>
    /// ���엚�����O�f�[�^�̃����[�g�̃w���p�N���X
    /// </summary>
    internal sealed class LogRemoteHelper
    {
        #region <Const/>

        /// <summary>�ő僊�g���C��</summary>
        private const int MAX_RETRY_COUNT = 3;

        /// <summary>�҂�����[msec]</summary>
        private const int SLEEP_MSEC = 500;

        #endregion  // <Const/>

        #region <�A�N�Z�T/>

        /// <summary>���엚�����O�f�[�^�̃����[�g�̃��X�g</summary>
        private readonly List<IOprtnHisLogDB> _logAccesserList;
        /// <summary>
        /// ���엚�����O�f�[�^�̃����[�g�̃��X�g���擾���܂��B
        /// </summary>
        /// <value>���엚�����O�f�[�^�̃����[�g�̃��X�g</value>
        public List<IOprtnHisLogDB> LogAccesserList
        {
            get { return _logAccesserList; }
        }

        /// <summary>���e�̃��R�[�h</summary>
        private OprtnHisLogWork _doingRecord;
        /// <summary>
        /// ���e�̃��R�[�h���擾���܂��B
        /// </summary>
        /// <value>���e�̃��R�[�h</value>
        public OprtnHisLogWork DoingRecord
        {
            get { return _doingRecord; }
        }

        /// <summary>���g���C�̃J�E���^</summary>
        private int _reTryCounter;
        /// <summary>
        /// ���g���C�̃J�E���^���擾���܂��B
        /// </summary>
        /// <value>���g���C�̃J�E���^</value>
        public int ReTryCounter
        {
            get { return _reTryCounter; }
        }

        #endregion  // <�A�N�Z�T/>

        #region <�I�t���C���p�̃��K�[/>

        /// <summary>
        /// �I�t���C���p�̃��K�[
        /// </summary>
        private OfflineLogger _offlineLogger;
        /// <summary>
        /// �I�t���C���p�̃��K�[���擾���܂��B
        /// </summary>
        /// <value>�I�t���C���p�̃��K�[</value>
        internal OfflineLogger OfflineLogger { get { return _offlineLogger; } }

        /// <summary>
        /// �I�t���C���p���K�[��ݒ肵�܂��B
        /// </summary>
        /// <param name="folderPath"></param>
        public void SetOfflineLogger(string folderPath)
        {
            _offlineLogger = new OfflineLogger(folderPath);
        }

        #endregion  // <�I�t���C���p�̃��K�[/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="accesser">���엚�����O�f�[�^�̃����[�g</param>
        /// <param name="doingRecord">���e���R�[�h</param>
        public LogRemoteHelper(
            IOprtnHisLogDB accesser,
            OprtnHisLogWork doingRecord
        )
        {
            _logAccesserList = new List<IOprtnHisLogDB>();
            _logAccesserList.Add(accesser);
            _doingRecord = doingRecord;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// ���O���������݂܂��B�i���g���C�t�j
        /// </summary>
        public void TryToWrite()
        {
            object objDoingRecord = DoingRecord;

            foreach (IOprtnHisLogDB writer in LogAccesserList)
            {
                if (writer == null) continue;

                try
                {
                    Debug.WriteLine("���O���������݂܂��B");

                    int status = writer.Write(ref objDoingRecord);
                    if (!status.Equals((int)DBAccessStatus.Normal) && !status.Equals((int)DBAccessStatus.RecordIsExisted))
                    {
                        if (CanNotReTry)
                        {
                            Debug.WriteLine("���O�̏������݂Ɏ��s���܂����B");
                            return;
                        }
                        Thread.Sleep(SLEEP_MSEC);

                        Debug.WriteLine("�ُ픭���F" + ReTryCounter.ToString() + "��ڂ̃��g���C�ł��B");
                        TryToWrite();
                    }

                    if (OfflineLogger != null)
                    {
                        OfflineLogger.Write(ref objDoingRecord);
                    }

                    Debug.WriteLine("���O�̏������݂ɐ������܂����B");
                }
                catch (Exception)
                {
                    if (CanNotReTry)
                    {
                        Debug.WriteLine("���O�̏������݂Ɏ��s���܂����B");
                        return;
                    }
                    Thread.Sleep(SLEEP_MSEC);

                    Debug.WriteLine("��O�����F" + ReTryCounter.ToString() + "��ڂ̃��g���C�ł��B");
                    TryToWrite();
                }
            }
        }

        /// <summary>
        /// ���g���C�ł��Ȃ������肵�܂��B
        /// </summary>
        /// <value>true :�ł��Ȃ��B<br/>false:�ł���B</value>
        private bool CanNotReTry
        {
            get { return (++_reTryCounter) > MAX_RETRY_COUNT; }
        }
    }

    #endregion  // <Helper/>
}
