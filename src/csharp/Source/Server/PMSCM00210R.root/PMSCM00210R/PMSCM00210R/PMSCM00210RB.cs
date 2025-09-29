//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �������s�Ǘ� �����[�g�I�u�W�F�N�g
//                  :   PMSCM00210R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   �c����
// Date             :   2014/08/01
//----------------------------------------------------------------------
// �Ǘ��ԍ�              �쐬�S�� : ���{ �G�I
// �C �� ��  2015/02/12  �C�����e : ���񓯊��ȊO�͕ϊ��J�n�v���𑗐M���Ȃ��悤�ɏC��(#46)
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.Remoting.Lifetime;

using Microsoft.SqlServer.Server;
using Microsoft.Win32;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Data.SqlClient;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �������s�N���X �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������s�N���X������s���N���X�ł��B</br>
    /// <br>Programmer : zhubj</br>
    /// <br>Date       : 2014/08/07</br>
    /// </remarks>
    [Serializable]
    public partial class SyncExecWorkDB : RemoteWithAppLockDB
    {
        /// <summary>
        /// Singleton Objects 
        /// </summary>
        private static Dictionary<string, SyncExecWorkDB> _dictSelf;

        #region Private Member
        #region�@���b�N�I�u�W�F�N�g
        // ���񓯊��X���b�h�p
        private object _firstSyncObj = new object();
        /// <summary>���A���������b�N�I�u�W�F�N�g</summary>
        private object _syncReadLockObj = new object();
        /// <summary>�o�b�`�������b�N�I�u�W�F�N�g</summary>
        private object _syncBatchLockObj = new object();
        /// <summary>�ϊ����b�N�I�u�W�F�N�g</summary>
        private object _syncTransLockObj = new object();

        private object _syncExecLock = new object();

        /// <summary>
        /// �X���b�h�Ԕr������I�u�W�F�N�g
        /// </summary>
        public object SyncExecLock
        {
            get { return this._syncExecLock; }
        }
        #endregion

        #region �X���b�h���
        // ���񓯊��X���b�h
        private Thread _firstSyncWorker;
        // �o�b�`�������s�X���b�h�p
        private Thread _syncExecforRealWorker;
        // �o�b�`�������s�X���b�h�p
        private Thread _syncExecforBatchWorker;
        //����Ď��X���b�h
        private Thread _regularWatchOnWorker;
        //�ϊ��J�n�X���b�h
        private Thread _translateWorker;
        #endregion
        #endregion

        #region Property
        // �������s���F�؏��
        private SyncAuthenticationInfo _syncAuthInfo;
        /// <summary>
        /// �������s���F�؏��
        /// </summary>
        public SyncAuthenticationInfo SyncAuthInfo
        {
            get { return this._syncAuthInfo; }
        }

        private SynchConfirmDB _synchConfirmDB;
        /// <summary>
        /// �����󋵊m�F�����[�g
        /// </summary>
        public SynchConfirmDB WorkerSynchConfirmDB
        {
            get { return this._synchConfirmDB; }
        }

        // 
        private bool _isValidWachWorker;
        /// <summary>
        /// ����X���b�h���s�敪(TRUE:���s�AFALSE:�����s(����ap�Ŏ��s��) 
        /// </summary>
        public bool IsValidWachWorker
        {
            get { return this._isValidWachWorker; }
        }

        // ���񓯊�����ԁi���l�j
        private int _staticFirstSyncDiv = 0;
        /// <summary>
        /// ���񓯊��敪(0:�������A1:�������A2:�����ς�
        /// </summary>
        public int StaticFirstSyncDiv
        {
            get { return this._staticFirstSyncDiv; }
        }

        // �ݒ���
        private PMSCM00210R_Setting _xmlSetting;
        /// <summary>
        /// �ݒ���
        /// </summary>
        public PMSCM00210R_Setting XmlSetting
        {
            get { return this._xmlSetting; }
        }

        //������{���
        private SyncBasicWorkInfo _syncBasicWorkInfo;
        /// <summary>
        /// ������{���
        /// </summary>
        public SyncBasicWorkInfo SyncWorkInfo
        {
            set { this._syncBasicWorkInfo = value; }
            get { return this._syncBasicWorkInfo; }
        }
        #endregion

        #region �C���X�^���X�����֘A
        /// <summary>
        /// �C���X�^���X�擾
        /// </summary>
        /// <returns></returns>
        public static SyncExecWorkDB GetInstance(string enterpriseCode)
        {
            if (_dictSelf != null && _dictSelf.ContainsKey(enterpriseCode))
            {
                return _dictSelf[enterpriseCode];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="info"></param>
        /// <param name="pmDbIdDictionary"></param>
        public static void Initialize(SyncAuthenticationInfo info, Dictionary<string, string> pmDbIdDictionary)
        {
            if (info == null)
            {
                throw new NullReferenceException("SyncAuthenticationInfo is null.");
            }
            //SCM�I�v�V�����`�F�b�N�B
            List<string> enterpriseList = new CheckOptionWork().GetSoftwarePurchasedPrco(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);

            if (_dictSelf == null)
            {
                _dictSelf = new Dictionary<string, SyncExecWorkDB>();
            }
            Dictionary<string, SyncExecWorkDB> selfDict = new Dictionary<string, SyncExecWorkDB>();
            SyncExecWorkDB self = null;
            SyncAuthenticationInfo epInfo = null;
            foreach (string enterpriseCode in pmDbIdDictionary.Keys)
            {
                if (!enterpriseList.Contains(enterpriseCode))
                {
                    continue;
                }

                if (!_dictSelf.ContainsKey(enterpriseCode))
                {
                    epInfo = new SyncAuthenticationInfo();
                    epInfo.EnterpriseCode = enterpriseCode;
                    epInfo.PmDbId = pmDbIdDictionary[enterpriseCode];
                    epInfo.PmSyncUrl = info.PmSyncUrl;
                    epInfo.UserDbConnectionText = info.UserDbConnectionText;
                    self = new SyncExecWorkDB(epInfo);

                    #region �C���X�^���X��������
                    SyncExecThreadDB thread = new SyncExecThreadDB(self);
                    // �������s(���A��)
                    self._syncExecforRealWorker = new Thread(thread.SyncRealExecWork);
                    self._syncExecforRealWorker.Name = "syncExecforRealWorker";
                    self._syncExecforRealWorker.IsBackground = true;

                    // �������s(�o�b�`)
                    self._syncExecforBatchWorker = new Thread(thread.SyncBatchExecWork);
                    self._syncExecforBatchWorker.Name = "syncExecforBatchWorker";
                    self._syncExecforBatchWorker.IsBackground = true;

                    // ����Ď�
                    self._regularWatchOnWorker = new Thread(new SyncWatchThreadDB(self).RegularWatchOnWork);
                    self._regularWatchOnWorker.IsBackground = true;

                    // ���񓯊�����Ԃ̍X�V
                    self.UpdateStaticFirstSyncDiv();
                    self._syncExecforRealWorker.Start();
                    self._syncExecforBatchWorker.Start();

                    // �Ď����s�Ǘ��}�X�^�̍X�V
                    int status = self.UpdateSyncMonitMngData();
                    if (status != -1 && status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        continue;
                    }
                    else
                    {
                        self._firstSyncWorker = new Thread(new FirstSyncExecThreadDB(self).FirstSyncWork);
                        self._firstSyncWorker.IsBackground = true;
                        if (self.StaticFirstSyncDiv < 2)
                        {
                            self._firstSyncWorker.Start();
                        }

                        //�ϊ�
                        self._translateWorker = new Thread(new SyncWatchThreadDB(self).TranslateStart);
                        self._translateWorker.IsBackground = true;

                        self._regularWatchOnWorker.Start();
                        self._translateWorker.Start();
                    }
                    #endregion
                    _dictSelf.Add(enterpriseCode, self);
                }
                else
                {
                    self = _dictSelf[enterpriseCode];
                    self.UpdateStaticFirstSyncDiv();
                    #region �X���b�h�Ċ�������
                    if (self._syncExecforBatchWorker != null && !self._syncExecforBatchWorker.IsAlive)
                    {
                        self._syncExecforBatchWorker.Start();
                    }
                    if (self._syncExecforRealWorker != null && !self._syncExecforRealWorker.IsAlive)
                    {
                        self._syncExecforRealWorker.Start();
                    }

                    // �Ď����s�Ǘ��}�X�^�̍X�V
                    int status = self.UpdateSyncMonitMngData();
                    if (status != -1 && status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return;
                    }
                    //�ꉞ����ł�����ċN��������B
                    if (self._firstSyncWorker != null && !self._firstSyncWorker.IsAlive)
                    {
                        self._firstSyncWorker = new Thread(new FirstSyncExecThreadDB(self).FirstSyncWork);
                        if (self.StaticFirstSyncDiv < 2)
                        {
                            self._firstSyncWorker.IsBackground = true;
                            self._firstSyncWorker.Start();
                        }
                    }
                    if (self._translateWorker != null && !self._translateWorker.IsAlive)
                    {
                        self._translateWorker.Start();
                    }
                    if (self._regularWatchOnWorker != null && !self._regularWatchOnWorker.IsAlive)
                    {
                        self._regularWatchOnWorker.Start();
                    }
                    #endregion
                }
            }
        }

        /// <summary>
        /// �������s�N���XDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        private SyncExecWorkDB(SyncAuthenticationInfo info)
        {
            this._syncAuthInfo = info;
            _xmlSetting = null;
            // �ݒ�XML�擾����
            InitializeXmlSettings(info.PmDbId, out _xmlSetting);
            // �ݒ�XML�擾���s�ꍇ�A�������~
            if (_xmlSetting == null)
            {
                base.WriteErrorLog("PMSCM00210R_Setting.xml is not found.");
                throw new Exception("PMSCM00210R_Setting.xml is not found.");
            }
            this._syncBasicWorkInfo = new SyncBasicWorkInfo();
            this._syncBasicWorkInfo.DataCheckInterval = 60 * 24; //1���Ԋu

            // PM��DB�A�N�Z�X
            this._synchConfirmDB = new SynchConfirmDB();
        }
        #endregion

        #region �X���b�h�Ǘ�
        /// <summary>
        /// ���A�������X���b�h�̑ҋ@�p
        /// </summary>
        public void SyncThreadWait()
        {
            lock (_syncReadLockObj)
            {
                Monitor.Wait(_syncReadLockObj, XmlSetting.BatchInterval * 1000);
            }
        }

        /// <summary>
        /// ���A�������X���b�h�̋N���p
        /// </summary>
        public void SyncThreadWakeUp()
        {
            lock (_syncReadLockObj)
            {
                Monitor.PulseAll(_syncReadLockObj);
            }
        }

        /// <summary>
        /// �o�b�`�����X���b�h�̑ҋ@�p
        /// </summary>
        public void SyncBatchThreadWait()
        {
            lock (_syncBatchLockObj)
            {
                Monitor.Wait(_syncBatchLockObj, XmlSetting.BatchInterval * 1000);
            }
        }

        /// <summary>
        /// �o�b�`�����X���b�h�̋N���p
        /// </summary>
        public void SyncBatchThreadWakeUp()
        {
            lock (_syncBatchLockObj)
            {
                Monitor.PulseAll(_syncBatchLockObj);
            }
        }

        /// <summary>
        /// ���񓯊��X���b�h�ҋ@�p
        /// </summary>
        public void FirstSyncThreadWait()
        {
            lock (_firstSyncObj)
            {
                Monitor.Wait(_firstSyncObj);
            }
        }

        /// <summary>
        /// ���񓯊��X���b�h�̋N���p
        /// </summary>
        public void FirstSyncThreadWakeUp()
        {
            lock (_firstSyncObj)
            {
                Monitor.PulseAll(_firstSyncObj);
            }
        }

        /// <summary>
        /// ���񓯊��X���b�h�ҋ@�p
        /// </summary>
        public void TranslateThreadWait()
        {
            DateTime dt = DateTime.ParseExact(string.Format("{0:yyyyMMdd}{1}", DateTime.Now, this.XmlSetting.TranslateTime), "yyyyMMddHHmmss", null);
            if (dt <= DateTime.Now)
            {
                dt = dt.AddDays(1.0);
            }
            TimeSpan ts = (dt - DateTime.Now);
            lock (_syncTransLockObj)
            {
                //MOD:2015/02/12 ------------------ >>>>>
                if (this.StaticFirstSyncDiv == 2)
                {
                    //���񓯊����������Ă���̂ł���΁A
                    //�蓮���s�Ȃǂɂ�閾���I�ȗv�����Ȃ�����͉��X�Ƒҋ@������B
                    Monitor.Wait(_syncTransLockObj);
                }
                else
                {
                    Monitor.Wait(_syncTransLockObj, ts);
                }
                //MOD:2015/02/12 ------------------ <<<<<
            }
        }

        /// <summary>
        /// ���񓯊��X���b�h�̋N���p
        /// </summary>
        public void TranslateThreadWakeUp()
        {
            lock (_syncTransLockObj)
            {
                Monitor.PulseAll(_syncTransLockObj);
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// ���s�X���b�h�J�n����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���s�X���b�h�J�n�������s���B</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        public void StartSyncExec()
        {
            this.SyncThreadWakeUp();
        }

        /// <summary>
        /// �Ď����s�Ǘ��}�X�^�̍X�V����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ď����s�Ǘ��}�X�^�̍X�V�������s���B</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        public int UpdateSyncMonitMngData()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            this._isValidWachWorker = false;
            // �Ď����s����ꍇ�́A���񓯊�����Ԃ̍X�V���s��
            // �Ď����s�Ǘ��}�X�^���擪���R�[�h
            string errStr = "";
            string computerName = "";
            // �R���s���[�^�[���A
            string localName = System.Net.Dns.GetHostName();
            if (localName.Length > 20)
            {
                localName = localName.Substring(0, 20);
            }
            long monitoringTime = 0;
            status = SearchSyncMonitMngData(out computerName, out monitoringTime, out errStr);
            // TODO status �Ĕ��f
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
            {
                return status;
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �R���s���[�^�[�������[���ƈقȂ�
                // �Ď����s�������i�V�X�e�������|���v���JDB����Ď��Ԋu�i�b�j�|�Ď��P�\���ԁi�b�j�j�̏ꍇ
                if (!computerName.Equals(localName) &&
                    monitoringTime > (DateTimeToYYYYMMDDHHMMSS(DateTime.Now.AddSeconds((_xmlSetting.WatchOnReplicaDBIntervalTime + _xmlSetting.WatchOnHesitateTime) * -1))))
                {
                    return -1;
                }
            }

            // �Ď����s����
            monitoringTime = DateTimeToYYYYMMDDHHMMSS(DateTime.Now);

            // �e�[�u�����b�N�A�X�V����
            status = WriteSyncMonitMngData(localName, monitoringTime);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._isValidWachWorker = true;
            }
            return status;
        }

        /// <summary>
        /// ���񓯊�����Ԃ̍X�V����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���񓯊�����Ԃ̍X�V�������s���B</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        public int UpdateStaticFirstSyncDiv()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            object retObj = null;
            string errStr = "";

            #region  �����Ǘ��}�X�^���P���R�[�h�ȏ゠��ꍇ�́A���������Ƃ݂Ȃ��āA���񓯊�����ԁ��Q�@���Z�b�g
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlReader = null;
            //�������s��ԂɊւ�炸���񓯊����̎擾
            const string sqlText = " SELECT TOP(1) 1 FROM SYNCREQDATARF AS SUB01 WITH(READUNCOMMITTED) "
                                 + " WHERE "
                                 + " SUB01.ENTERPRISECODERF=@FINDENTERPRISECODE"
                                 + " AND SYNCTARGETDIVRF=2 "
                                 + " ";
            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�������J�n
                SqlTransaction sqlTransaction = this.CreateTransaction(ref sqlConnection);

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                #region �p�����[�^�ݒ�
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this.SyncAuthInfo.EnterpriseCode);
                #endregion

                sqlReader = sqlCommand.ExecuteReader();
                if (sqlReader.Read())
                {
                    this._staticFirstSyncDiv = 1;//������
                }
                else
                {
                    this._staticFirstSyncDiv = 0;//������
                }
            }
            finally
            {
                CloseQuietly(sqlReader);
                CloseQuietly(sqlCommand);
                CloseQuietly(sqlConnection);
            }
            #endregion

            if (this._staticFirstSyncDiv == 0)
            {
                retObj = null;
                SyncMngWork con = new SyncMngWork();
                con.EnterpriseCode = this.SyncAuthInfo.EnterpriseCode;
                object param = (object)con;
                status = _synchConfirmDB.SearchSyncMngData(out retObj, out errStr, con, ConstantManagement.LogicalMode.GetData0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._staticFirstSyncDiv = 2;//�����ς�
                }
            }
            return status;
        }

        /// <summary>
        /// �g�����U�N�V����ID�̎擾�B
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public long GetTransactionId(SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            SqlCommand sqlCommand = null;
            try
            {
                sqlCommand = new SqlCommand("SELECT TOP 1 transaction_id FROM sys.dm_tran_current_transaction", sqlConnection, sqlTransaction);
                object o = sqlCommand.ExecuteScalar();
                if (o is Int64)
                {
                    return (long)o;
                }
                else
                {
                    return 0;
                }
            }
            finally
            {
                CloseQuietly(sqlCommand);
            }
        }
        /// <summary>
        /// ���t�ϊ�����
        /// </summary>
        /// <param name="dt">���t</param>
        /// <remarks>
        /// <br>Note       : ���t�ϊ��������s���B</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        public static long DateTimeToYYYYMMDDHHMMSS(DateTime dt)
        {
            long dtLong = TDateTime.DateTimeToLongDate("YYYYMMDD", dt);
            return dtLong * 1000000 + dt.Hour * 10000 + dt.Minute * 100 + dt.Second;
        }

        /// <summary>
        /// SQLConnection���N���[�Y���܂��B
        /// ���������O�͖������܂��B
        /// </summary>
        /// <param name="sqlConnection"></param>
        public static void CloseQuietly(SqlConnection sqlConnection)
        {
            try
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// SqlCommand���N���[�Y���܂��B
        /// ���������O�͖������܂��B
        /// </summary>
        /// <param name="sqlCommand"></param>
        public static void CloseQuietly(SqlCommand sqlCommand)
        {
            try
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// SqlDataReader���N���[�Y���܂��B
        /// ���������O�͖������܂��B
        /// </summary>
        /// <param name="sqlReader"></param>
        public static void CloseQuietly(SqlDataReader sqlReader)
        {
            try
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// sqlTransaction���R�~�b�g/���[���o�b�N���܂��B
        /// �����ăI�u�W�F�N�g��j�����܂��B
        /// </summary>
        /// <param name="sqlTransaction"></param>
        /// <param name="status"></param>
        public static void CommitCloseQuietly(SqlTransaction sqlTransaction, int status)
        {
            try
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //�R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }
                    sqlTransaction.Dispose();
                }
            }
            catch
            {
            }
        }
        #endregion

        # region Private Method
        /// <summary>
        /// �ݒ�XML�t�@�C�����擾�����B
        /// �p�[�c�}��DBID�o�́B
        /// ���O�t�@�C���̍폜
        /// </summary>
        /// <param name="pmDbId">�p�[�c�}��DBID</param>
        /// <param name="pMSCM00210R_Setting">�ݒ�XML�t�@�C�����</param>
        /// <remarks>
        /// <br>Note       : �ݒ�XML�t�@�C�����擾�������s���B</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        private void InitializeXmlSettings(string pmDbId, out PMSCM00210R_Setting pMSCM00210R_Setting)
        {
            pMSCM00210R_Setting = null;
            RegistryKey keyForLog = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            string homeDir = keyForLog.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
            string path = Path.Combine(homeDir, "PMSCM00210R_Setting.xml");
            #region �ݒ�t�@�C���ǂݍ���
            if (File.Exists(path))
            {
                System.Xml.XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                settings.IgnoreWhitespace = true;
                System.Xml.XmlReader reader = null;

                try
                {
                    reader = System.Xml.XmlReader.Create(path, settings);

                    pMSCM00210R_Setting = new PMSCM00210R_Setting();
                    SyncTableInfo tableInfo = null;
                    string tableId = "";
                    string tableNm = "";
                    string tableJsonId = "";
                    string value;
                    while (reader.Read())
                    {
                        value = reader.Value;
                        // ���g���C�񐔂̍ő�l
                        if (reader.IsStartElement("MaxRetryCount"))
                        {
                            pMSCM00210R_Setting.MaxRetryCount = Convert.ToInt32(reader.ReadElementString("MaxRetryCount").Trim());
                        }
                        // ���g���C�Ԋu�i�b�j
                        if (reader.IsStartElement("RetryIntervalTime"))
                        {
                            pMSCM00210R_Setting.RetryIntervalTime = Convert.ToInt32(reader.ReadElementString("RetryIntervalTime").Trim());
                        }
                        // ���v���JDB����Ď��Ԋu�i�b�j
                        if (reader.IsStartElement("WatchOnReplicaDBIntervalTime"))
                        {
                            pMSCM00210R_Setting.WatchOnReplicaDBIntervalTime = Convert.ToInt32(reader.ReadElementString("WatchOnReplicaDBIntervalTime").Trim());
                        }
                        // �Ď��P�\���ԁi�b�j
                        if (reader.IsStartElement("WatchOnHesitateTime"))
                        {
                            pMSCM00210R_Setting.WatchOnHesitateTime = Convert.ToInt32(reader.ReadElementString("WatchOnHesitateTime").Trim());
                        }
                        // �o�b�`���s�Ԋu
                        if (reader.IsStartElement("BatchInterval"))
                        {
                            pMSCM00210R_Setting.BatchInterval = Convert.ToInt32(reader.ReadElementString("BatchInterval").Trim());
                        }
                        // �f�[�^�ꊇ���M����
                        if (reader.IsStartElement("DataSendLimitSize"))
                        {
                            pMSCM00210R_Setting.DataSendLimitSize = Convert.ToInt32(reader.ReadElementString("DataSendLimitSize").Trim());
                        }
                        // �f�[�^�ꊇ���M����
                        if (reader.IsStartElement("TranslateTime"))
                        {
                            pMSCM00210R_Setting.TranslateTime = reader.ReadElementString("TranslateTime").Trim();
                        }
                        if (reader.IsStartElement("SyncTableInfo") || (reader.NodeType == System.Xml.XmlNodeType.EndElement))
                        {
                            continue;
                        }
                        try
                        {
                            // �e�[�u��ID
                            if (reader.IsStartElement("SyncTableId"))
                            {
                                tableId = reader.ReadElementString("SyncTableId");
                            }
                            // �e�[�u������
                            if (reader.IsStartElement("SyncTableNm"))
                            {
                                tableNm = reader.ReadElementString("SyncTableNm");
                            }
                            if (reader.IsStartElement("SyncTableJsonId"))
                            {
                                tableJsonId = reader.ReadElementString("SyncTableJsonId");
                            }
                            if (!String.IsNullOrEmpty(tableId) && !String.IsNullOrEmpty(tableNm))
                            {
                                tableInfo = new SyncTableInfo();
                                tableInfo.SyncTableId = tableId;
                                tableInfo.SyncTableNm = tableNm;
                                tableInfo.SyncTableJsonId = tableJsonId;
                                pMSCM00210R_Setting.TablesInfoList.Add(tableInfo);
                                tableId = "";
                                tableNm = "";
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
                finally
                {
                    if (reader != null) reader.Close();
                }
            }
            #endregion

            #region PMDBID�o��
            StreamWriter writer = null;
            try
            {
                try
                {
                    if (!Directory.Exists(Path.Combine(homeDir, @"Log\")))
                    {
                        Directory.CreateDirectory(Path.Combine(homeDir, @"Log\"));
                    }
                }
                catch
                {
                }
                writer = File.CreateText(Path.Combine(homeDir, @"Log\PMDBID.txt"));
                writer.WriteLine(pmDbId);
                if (this._syncAuthInfo.PmSyncUrl != null && this._syncAuthInfo.PmSyncUrl.IndexOf("?") != -1)
                {
                    writer.WriteLine(this._syncAuthInfo.PmSyncUrl.Substring(0, this._syncAuthInfo.PmSyncUrl.IndexOf("?")));
                }
                writer.WriteLine(DateTime.Now.ToString());
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
            #endregion

            #region ���O�N���[��
            try
            {
                DirectoryInfo dir = new DirectoryInfo(Path.Combine(homeDir, @"Log\PMSCM00220B"));
                if (dir.Exists)
                {
                    DateTime deleteTime = DateTime.Now.AddMonths(-1);
                    foreach (DirectoryInfo d in dir.GetDirectories())
                    {
                        foreach (FileInfo f in d.GetFiles())
                        {
                            if (f.LastWriteTime <= deleteTime)
                            {
                                f.Delete();
                            }
                        }
                    }
                }
            }
            catch
            {
                //��O�����͉B��
                //���b�N�t�@�C���������Ă�����͖�������B
            }
            #endregion
        }

        /// <summary>
        /// �����p���O
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public static void DebugLog(string enterpriseCode, string message, string type)
        {
            RegistryKey keyForLog = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            string homeDir = keyForLog.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
            StreamWriter writer = null;
            try
            {
                string logDir = Path.Combine(homeDir, @"Log\PMSCM00220B\" + enterpriseCode);
                try
                {
                    if (!Directory.Exists(logDir))
                    {
                        Directory.CreateDirectory(logDir);
                    }
                }
                catch
                {
                }
                writer = new StreamWriter(Path.Combine(logDir, DateTime.Now.ToString("yyyyMMdd", null) + "_" + type + "_DebugLog.txt"), true);
                writer.WriteLine(string.Format(DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + " : " + message));
                writer.Flush();
            }
            catch
            {
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// �����Ď����s�Ǘ��̍X�V����
        /// </summary>
        /// <param name="computerName">�R���s���[�^�[��</param>
        /// <param name="monitoringTime">�Ď�����</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����Ď����s�Ǘ��̍X�V�������s���B</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        private int WriteSyncMonitMngData(string computerName, long monitoringTime)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = WriteSyncMonitMngDataProc(computerName, monitoringTime, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SyncExecDBWork.WriteSyncMonitMngData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                CommitCloseQuietly(sqlTransaction, status);
                CloseQuietly(sqlConnection);
            }

            return status;
        }

        /// <summary>
        /// �����Ď����s�Ǘ��̍X�V����
        /// </summary>
        /// <param name="computerName">�R���s���[�^�[��</param>
        /// <param name="monitoringTime">�Ď�����</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����Ď����s�Ǘ��̍X�V�������s���B</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        private int WriteSyncMonitMngDataProc(string computerName, long monitoringTime, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (computerName != null)
                {
                    sqlCommand = new SqlCommand("SELECT    CREATEDATETIMERF    ,UPDATEDATETIMERF    ,ENTERPRISECODERF    ,FILEHEADERGUIDRF    ,COMPUTERNAMERF    ,MONITORINGTIMERF  FROM SYNCMONITMNGRF WITH (HOLDLOCK) WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    sqlCommand.Parameters.Clear();
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(this.SyncAuthInfo.EnterpriseCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //Update�R�}���h�̐���
                        #region [UPDATE��]

                        sqlCommand.CommandText = "UPDATE SYNCMONITMNGRF SET   UPDATEDATETIMERF=@UPDATEDATETIME   ,COMPUTERNAMERF=@COMPUTERNAME   ,MONITORINGTIMERF=@MONITORINGTIME WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                        #endregion

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(this.SyncAuthInfo.EnterpriseCode);
                    }
                    else
                    {
                        //Insert�R�}���h�̐���
                        #region [INSERT��]

                        sqlCommand.CommandText = "INSERT INTO SYNCMONITMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, COMPUTERNAMERF, MONITORINGTIMERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @COMPUTERNAME, @MONITORINGTIME)";
                        #endregion
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraComputerName = sqlCommand.Parameters.Add("@COMPUTERNAME", SqlDbType.NVarChar);
                    SqlParameter paraMonitoringTime = sqlCommand.Parameters.Add("@MONITORINGTIME", SqlDbType.BigInt);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(DateTime.Now);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(DateTime.Now);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this.SyncAuthInfo.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(Guid.NewGuid());
                    paraComputerName.Value = SqlDataMediator.SqlSetString(computerName);
                    paraMonitoringTime.Value = SqlDataMediator.SqlSetInt64(monitoringTime);
                    #endregion

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            catch (SqlException ex)
            {
                base.WriteSQLErrorLog(ex, ex.Message, ex.Number);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                CloseQuietly(myReader);
                CloseQuietly(sqlCommand);
            }

            return status;
        }

        /// <summary>
        /// �����Ď����s�Ǘ��̌���
        /// </summary>
        /// <param name="computerName">�R���s���[�^�[��</param>
        /// <param name="monitoringTime">�Ď�����</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����Ď����s�Ǘ��̍X�V�������s���B</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        private int SearchSyncMonitMngData(out string computerName, out long monitoringTime, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            computerName = "";
            monitoringTime = 0;
            errMessage = string.Empty;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = SearchSyncMonitMngDataProc(out computerName, out monitoringTime, out errMessage, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                base.WriteErrorLog(ex, "SyncExecDBWork.SearchSyncMonitMngData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                CommitCloseQuietly(sqlTransaction, status);
                CloseQuietly(sqlConnection);
            }

            return status;
        }

        /// <summary>
        /// �����Ď����s�Ǘ��̌���
        /// </summary>
        /// <param name="computerName">�R���s���[�^�[��</param>
        /// <param name="monitoringTime">�Ď�����</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����Ď����s�Ǘ��̍X�V�������s���B</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        private int SearchSyncMonitMngDataProc(out string computerName, out long monitoringTime, out string errMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMessage = null;
            computerName = "";
            monitoringTime = 0;
            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                sqlCommand = new SqlCommand("SELECT    CREATEDATETIMERF    ,UPDATEDATETIMERF ,ENTERPRISECODERF  ,FILEHEADERGUIDRF  ,COMPUTERNAMERF  ,MONITORINGTIMERF  FROM SYNCMONITMNGRF WITH(READUNCOMMITTED) WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection, sqlTransaction);
                //��ƃR�[�h
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this.SyncAuthInfo.EnterpriseCode);

                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    computerName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("COMPUTERNAMERF"));
                    monitoringTime = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("MONITORINGTIMERF"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteSQLErrorLog(ex);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SyncExecDBWork.SearchSyncMonitMngDataProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                CloseQuietly(sqlDataReader);
                CloseQuietly(sqlCommand);
            }

            return status;
        }


        /// <summary>
        /// SqlConnection�I�u�W�F�N�g�𐶐����܂��B
        /// </summary>
        /// <returns>SqlConnection�I�u�W�F�N�g�A��������null</returns>
        /// <remarks>
        /// <br>Programmer : ���{�G�I</br>
        /// <br>Date       : 2014/08/25</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            string connectionText = this._syncAuthInfo.UserDbConnectionText;
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }
        #endregion
    }
}
