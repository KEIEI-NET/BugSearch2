using System;
using System.Data;
using System.ServiceProcess;
using System.IO;
using System.Diagnostics;// --- ADD 2015/12/21 ���{ ���[�U�[AP�N���s��Ή�
using System.Collections.Generic;// --- ADD 2015/12/21 ���{ ���[�U�[AP�N���s��Ή�
using System.Configuration;// --- ADD 2015/12/21 ���{ ���[�U�[AP�N���s��Ή�

using Broadleaf.Library.Resources;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
//--- ADD 2015.05.22 30809 ���X�� ----->>>>>
using Microsoft.Win32;
using System.Threading;
//--- ADD 2015.05.22 30809 ���X�� -----<<<<<
// --- ADD 2015/09/25 T.Miyamoto LSM�T�[�o�[�z�M���� -------------------->>>>>
using System.Xml;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
// --- ADD 2015/09/25 T.Miyamoto LSM�T�[�o�[�z�M���� --------------------<<<<<

namespace Broadleaf.ServiceProcess
{

	/// <summary>
	/// ���[�U�[AP�����[�g�v���L�V�T�[�o�[�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X�̓����[�g�I�u�W�F�N�g�̃v���L�V�N���X�ł��B</br>
	/// <br>Programmer : 20402�@���� ���F</br>
	/// <br>Date       : 2007.08.08</br>
    /// <br></br>
    /// <br>Update     : 2015.05.22 30809 ���X�� 11101069-00 LSM�z�M���� </br>
    /// <br>           : �EPM������ޭ�װ�N����~�����ǉ�</br>
    /// <br>           : �E���O�o�͕��i��CLC���O�o�͕��i�ďo�ɕύX</br>
    /// <br>Update     : 2015/09/25 11170140-00 LSM�T�[�o�[�z�M���� </br>
    /// <br>           : �E����N�������A����󋵊Ď�������ǉ�</br>
    /// <br>Update     : 2015/12/21 11170XXX-00 ���{ ���[�U�[AP�N���s��Ή� </br>
    /// <br>           : �E���[�U�[AP�N�������O�o�́A�y�эĎ��s����悤�ɏC��</br>
    /// <br>Update     : 2020/06/05 11670219-00 ���� �d�a�d�΍� </br>
    /// <br>           : �E���[�U�[AP�N�����y�ђ莞�Ńo�b�N�A�b�v���������s����</br>
    /// </remarks>
	public class Tbs001ServerService : System.ServiceProcess.ServiceBase
	{

        //--- ADD 2015.05.22 30809 ���X�� ----->>>>>
        /// <summary>
        /// PM�^�X�N�X�P�W���[���[�̃T�[�r�X�N���ƒ�~�����Ŏg�p����T�[�r�X��
        /// </summary>
        /// <remarks>
        /// �T�[�r�X���FPartsman.NS Task Scheduler
        /// </remarks>
        const string cServiceName = @"Partsman.NS Task Scheduler";       

        /// <summary>
        /// PM�^�X�N�X�P�W���[���[�̃T�[�r�X �X�^�[�g�A�b�v�̏�Ԋm�F�p���W�X�g���L�[��
        /// </summary>
        /// <remarks>
        /// ���W�X�g���L�[�FHKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\Partsman.NS Task Scheduler
        /// <br>�uPartsman.NS Task Scheduler�v�̕������cServiceName���g�p����</br>
        /// </remarks>
        const string cKeyName = @"SYSTEM\CurrentControlSet\Services\";

        /// <summary>
        /// PM�^�X�N�X�P�W���[���[�̃T�[�r�X �X�^�[�g�A�b�v�̏�Ԋm�F�p���W�X�g��������
        /// </summary>
        /// <remarks>
        /// ���W�X�g��������FStart
        /// <br>2�F�����A3�F�蓮�A4�F����</br>
        /// </remarks>
        const string cValueName = "Start";      

        /// <summary>
        /// PM�^�X�N�X�P�W���[���[�̃T�[�r�X �X�^�[�g�A�b�v�́u�����v��ԗp���f�l
        /// </summary>
        /// <remarks>
        /// <br>4�F����</br>
        /// </remarks>
        const int cSERVICE_DISABLED = 4;           
        //--- ADD 2015.05.22 30809 ���X�� -----<<<<<

        // --- ADD 2015/09/25 T.Miyamoto LSM�T�[�o�[�z�M���� -------------------->>>>>
        // LSM�T�[�r�X���EID
        const string cLsmServiceName = "LSMWinService";
        const string cLsmServiceID = "LSMWinService.exe";

        // LSM�T�[�r�X�Ď��ݒ�
        private const string ct_LsmCheckInfoFile = "SFCMN01001S_LsmCheckInfo.XML"; // �ݒ�t�@�C��
        private const int ct_LsmCheckInterval = 60000;      // LSM�T�[�r�X�Ď��Ԋu(�f�t�H���g�F1��)
        private string _lsmStartTime;
        private int _lsmCheckInterval;
        private int _lsmCheckIntervalCounter;

        // LSM�T�[�r�X�Ď��^�C�}�[
        private System.Timers.Timer LsmCheckTimer = null;

        private long _startDay = 0;
        // --- ADD 2015/09/25 T.Miyamoto LSM�T�[�o�[�z�M���� --------------------<<<<<

        // --- ADD 2020/06/15 ����  -------------------->>>>>
        private ConvObjBkExec convObjBkExec;
        // --- ADD 2020/06/15 ����  --------------------<<<<<

		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public Tbs001ServerService()
		{
			// ���̌Ăяo���́AWindows.Forms �R���|�[�l���g �f�U�C�i�ŕK�v�ł��B
			InitializeComponent();

			// TODO: InitComponent �Ăяo���̌�ɏ�����������ǉ����Ă��������B
            // --- ADD 2020/06/15 ����  -------------------->>>>>
             convObjBkExec = new ConvObjBkExec();
            // --- ADD 2020/06/15 ����  --------------------<<<<<
		}

		// �����̃��C�� �G���g�� �|�C���g�ł��B
		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
	
			// 2 �ȏ�� NT �T�[�r�X�𓯂��������Ŏ��s�ł��܂��B�ʂ̃T�[�r�X��
			// ���̏����ɒǉ�����ɂ́A�ȉ��̍s��ύX����
			// 2 �Ԗڂ̃T�[�r�X �I�u�W�F�N�g���쐬���Ă��������B�� :
			//
			//   ServicesToRun = New System.ServiceProcess.ServiceBase[] {new Service1(), new MySecondUserService()};
			//
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new Tbs001ServerService() };

			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}

		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Tbs001ServerService
			// 
			this.ServiceName = "Tbs001ServerService";

		}

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// ���삪�؂�Ȃ��s���A�T�[�r�X�̎��s���W�����Ȃ��悤�ɐݒ肵�܂��B
		/// </summary>
		protected override void OnStart(string[] args)
		{
            // --- ADD 2015/09/25 T.Miyamoto LSM�T�[�o�[�z�M���� -------------------->>>>>
            LsmCheckTimer = new System.Timers.Timer();
            LsmCheckTimer.Enabled = false;
            LsmCheckTimer.Elapsed += new System.Timers.ElapsedEventHandler(LsmCheckTimer_Elapsed);
            LsmCheckTimer.Interval = ct_LsmCheckInterval;
            // --- ADD 2015/09/25 T.Miyamoto LSM�T�[�o�[�z�M���� --------------------<<<<<
            try
			{
                //�T�[�r�X�X�^�[�g
                //int status = ServerServiceStartControl.StartServerService(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP, Tbs001ServerServiceResource.GetRemoteResource()); // --- DEL 2015/12/21 ���{ ���[�U�[AP�N���s��Ή�
                // --- ADD 2015/12/21 ���{ ���[�U�[AP�N���s��Ή� -------------------->>>>>
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                List<RemoteAssemblyInfo> remoteAssemblyInfoList = Tbs001ServerServiceResource.GetRemoteResource();
                for (int retryCount = 0, maxRetryCount = 5; retryCount <= maxRetryCount; retryCount++)
                {
                    try
                    {
                       status = ServerServiceStartControl.StartServerService(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP, remoteAssemblyInfoList);
                        break;//�\�����Ă���G���[�ł���Ȃ�΁A����͂��̂܂܏������p��������
                    }
                    catch (System.Net.Sockets.SocketException ex)
                    {
                        #region 2A.1.1.�Ď��s���f
                        if ((retryCount + 1) <= maxRetryCount)
                        {
                            this.WriteErrorLogStop(this.ServiceName, "OnStart", "�N���������Ď��s���܂�[" + ex.Message + "]", ex, -1);
                            this.OnStartRetryLogic(retryCount, maxRetryCount);
                        }
                        else
                        {
                            throw;
                        }
                        #endregion
                    }
                }
                // --- ADD 2015/12/21 ���{ ���[�U�[AP�N���s��Ή� --------------------<<<<<
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    WriteErrorLog(this.ServiceName, "OnStart", string.Format("StartServerService�ɂ�ERROR�����B�T�[�o�[�����������Ă�������"), null, status);
                }
                //--- ADD 2015.05.22 30809 ���X�� ----->>>>>
                else
                {
                    // �ʃX���b�h��PM�^�X�N�X�P�W���[���T�[�r�X���N������
                    Thread startServicePMTaskSchedulerThread = new Thread(new ThreadStart(StartServicePMTaskScheduler));
                    startServicePMTaskSchedulerThread.Start();
                    
                    // --- ADD 2015/09/25 T.Miyamoto LSM�T�[�o�[�z�M���� -------------------->>>>>
                    if (SetLsmCheckTimer() == 0)
                    {
                        LsmCheckTimer.Enabled = true; // LSM�Ď��^�C�}�[�N��
                    }
                    // --- ADD 2015/09/25 T.Miyamoto LSM�T�[�o�[�z�M���� --------------------<<<<<

                    // --- ADD 2020/06/15 ����  -------------------->>>>>
                    // �o�b�N�A�b�v�J�n
                    // �T�[�r�X�N�����A�莞�N��
                    // �ʃX���b�h�Ŏ��s
                    convObjBkExec.ConvertObjBkStart();
                    // --- ADD 2020/06/15 ����  --------------------<<<<<

                }
                //--- ADD 2015.05.22 30809 ���X�� -----<<<<<
			}
			catch(Exception ex)
			{
				WriteErrorLog(this.ServiceName,"OnStart",ex.Message,ex,-1);
			}
		}

		/// <summary>
		/// �G���[Log����
		/// </summary>
		/// <param name="pgId"></param>
		/// <param name="method"></param>
		/// <param name="Msg"></param>
		/// <param name="ex"></param>
		/// <param name="status"></param>
		private void WriteErrorLog(string pgId,string method,string Msg,Exception ex,int status)
		{
			string exceptionMsg = "����";
			if (ex != null) exceptionMsg = ex.Message;
			string msg = string.Format("Method:{0} Msg:{1} Exception.Msg:{2}",method,Msg,exceptionMsg);
            LogTextOut logTextOut = new LogTextOut();
			logTextOut.Output(pgId,msg,status);
            //--- ADD 2015.05.22 30809 ���X�� ----->>>>>
            // CLC���O�o�͕��i�ďo�ǉ�
            CLCLogTextOut clcLogTextOut = new CLCLogTextOut();
			clcLogTextOut.OutputClcLog(pgId,null,msg,status,ex);
            //--- ADD 2015.05.22 30809 ���X�� -----<<<<<
            this.Stop();    //2006.07.11 add �v�ۓc
        }

        //--- ADD 2015.05.22 30809 ���X�� ----->>>>>
        /// <summary>
        /// �G���[Log����(Stop����)
        /// </summary>
        /// <param name="pgId"></param>
        /// <param name="method"></param>
        /// <param name="Msg"></param>
        /// <param name="ex"></param>
        /// <param name="status"></param>
        protected void WriteErrorLogStop(string pgId, string method, string Msg, Exception ex, int status)
        {
            string exceptionMsg = "����";
            if (ex != null) exceptionMsg = ex.Message;
            string msg = string.Format("Method:{0} Msg:{1} Exception.Msg:{2}", method, Msg, exceptionMsg);
            LogTextOut logTextOut = new LogTextOut();
            logTextOut.Output(pgId, msg, status);
            // CLC���O�o�͕��i�ɕύX
            CLCLogTextOut clcLogTextOut = new CLCLogTextOut();
            clcLogTextOut.OutputClcLog(pgId, null, msg, status, ex);
        }
        //--- ADD 2015.05.22 30809 ���X�� -----<<<<<


		/// <summary>
		/// ���̃T�[�r�X���~���܂��B
		/// </summary>
		protected override void OnStop()
		{
            //--- ADD 2015.05.22 30809 ���X�� ----->>>>>
			try
			{
                // �ʃX���b�h��PM�^�X�N�X�P�W���[���T�[�r�X���~����
                //Thread stopServicePMTaskSchedulerThread = new Thread(new ThreadStart(StopServicePMTaskScheduler)); //--- DEL 2015.06.05 22035 �O��
                //stopServicePMTaskSchedulerThread.Start(); //--- DEL 2015.06.05 22035 �O��

                this.StopServicePMTaskScheduler(); // �I�������ł̓X���b�h�����Ȃ�  //--- ADD 2015.06.05 22035 �O��
            }
            catch (Exception ex)
            {
                WriteErrorLogStop(this.ServiceName, "OnStop", "PM������ޭ�װ���޽��~ ��O " + ex.Message, ex, -1);
            }
            //--- ADD 2015.05.22 30809 ���X�� -----<<<<<
            // --- ADD 2015/09/25 T.Miyamoto LSM�T�[�o�[�z�M���� -------------------->>>>>
            if (LsmCheckTimer.Enabled)
            {
                LsmCheckTimer.Enabled = false; // LSM�Ď��^�C�}�[��~
            }
            // --- ADD 2015/09/25 T.Miyamoto LSM�T�[�o�[�z�M���� --------------------<<<<<

            // --- ADD 2020/06/15 ����  -------------------->>>>>
            // �o�b�N�A�b�v��~
            convObjBkExec.ConvertObjBkStop();
            // --- ADD 2020/06/15 ����  --------------------<<<<<

		}

        //--- ADD 2015.05.22 30809 ���X�� ----->>>>>
        /// <summary>
        /// PM�^�X�N�}�l�[�W���[�T�[�r�X �N�����C������
        /// </summary>
        protected void StartServicePMTaskScheduler()
        {
            // �T�[�r�X�ꗗ�擾
            ServiceController[] scList = ServiceController.GetServices();
            foreach (ServiceController sc in scList)
            {
                // �w�肵���T�[�r�X�����T�[�r�X�ꗗ�ɑ��݂��Ă���ꍇ
                if (sc.ServiceName == cServiceName)
                {
                    // �T�[�r�X����~���Ă���ꍇ
                    if (sc.Status == ServiceControllerStatus.Stopped)
                    {
                        // �T�[�r�X �X�^�[�g�A�b�v�̏�Ԋm�F
                        if (ChkServiceStartMode(cServiceName) == true)
                        {
                            try
                            {
                                sc.Start();  // �T�[�r�X�N��
                            }
                            catch
                            {
                                // �T�[�r�X�N�����ɃG���[�����������\��������
                                WriteErrorLog(this.ServiceName, "OnStart", string.Format("Partsman.NS Task Scheduler�T�[�r�X�N���ɂ�ERROR����"), null, -1);
                            }
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// PM�^�X�N�}�l�[�W���[�T�[�r�X ��~���C������
        /// </summary>
        protected void StopServicePMTaskScheduler()
        {
            // �T�[�r�X�ꗗ�擾
            ServiceController[] scList = ServiceController.GetServices();
            foreach (ServiceController sc in scList)
            {
                // �w�肵���T�[�r�X�����T�[�r�X�ꗗ�ɑ��݂��Ă���ꍇ
                if (sc.ServiceName == cServiceName)
                {
                    // �T�[�r�X���N�����Ă���ꍇ
                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        // �T�[�r�X �X�^�[�g�A�b�v�̏�Ԋm�F
                        if (ChkServiceStartMode(cServiceName) == true)
                        {
                            try
                            {
                                sc.Stop();  // �T�[�r�X��~
                                // --- ADD 2015/12/21 ���{ ���[�U�[AP�N���s��Ή� --------- >>>>>
                                if (sc.Status != ServiceControllerStatus.Stopped)
                                {
                                    sc.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 1, 30));
                                }
                                // --- ADD 2015/12/21 ���{ ���[�U�[AP�N���s��Ή� --------- <<<<<
                            }
                            catch
                            {
                                // �T�[�r�X��~���ɃG���[�����������\��������
                                WriteErrorLogStop(this.ServiceName, "OnStop", string.Format("Partsman.NS Task Scheduler�T�[�r�X��~�ɂ�ERROR����"), null, -1);
                            }
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// �T�[�r�X �X�^�[�g�A�b�v��ނ̊m�F
        /// </summary>
        /// <param name="sServiceName"></param>
        /// <returns>���ʃX�e�[�^�X�itrue:�N���E��~�\�Afalse:�N���E��~�s�j</returns>
        protected Boolean ChkServiceStartMode(string sServiceName)
        {
            // �T�[�r�X�̃X�^�[�g�A�b�v��ނ� [����] �̏ꍇ�̂݃T�[�r�X�N������ђ�~���s��Ȃ�

            Boolean status = true;  // �N���E��~�\

            // ���W�X�g���E�L�[�̃p�X���w�肵�ă��W�X�g�����J��
            RegistryKey rKey = null;

            try
            {
                rKey = Registry.LocalMachine.OpenSubKey(cKeyName + sServiceName);

                if (rKey != null)
                {
                    // ���W�X�g���̒l���擾
                    int iValue = (int)rKey.GetValue(cValueName, 0);

                    if (iValue == cSERVICE_DISABLED)         // ����
                    {
                        status = false;  // �N���E��~�s��
                    }
                }
            }
            catch (NullReferenceException)
            {
                // �L�[�����݂��Ȃ��ꍇ�A�G���[�Ƃ��Ȃ�
            }
            catch
            {
                // ��O�G���[
            }
            finally
            {
                if (rKey != null)
                {
                    // �J�����L�[�����
                    rKey.Close();
                }
            }

            return status;
        }

        //--- ADD 2015.05.22 30809 ���X�� -----<<<<<

        // --- ADD 2015/09/25 T.Miyamoto LSM�T�[�o�[�z�M���� -------------------->>>>>
        /// <summary>
        /// LSM�T�[�r�X�Ď��^�C�}�[�ݒ�
        /// </summary>
        private int SetLsmCheckTimer()
        {
            // LSM�T�[�r�X�Ď��^�C�}�[�ݒ�t�@�C���Ǎ�
            LsmServiceCheckInfo lsmServiceCheckInfo = new LsmServiceCheckInfo();
            int status = ReadLsmCheckFile(ref lsmServiceCheckInfo);
            
            if (status == 0)
            {
                // �Ď��Ԋu�`�F�b�N
                if (lsmServiceCheckInfo.LsmCheckInterval == 0)
                {
                    return -1;
                }

                // XML���e��ݒ�
                this._lsmCheckInterval = lsmServiceCheckInfo.LsmCheckInterval;  // XML�̊Ď��Ԋu��ޔ�
                this._lsmCheckIntervalCounter = this._lsmCheckInterval - 1;     // XML�̊Ď��Ԋu

                try
                {
                    // ����N������
                    string lsmStartTime = lsmServiceCheckInfo.LsmStartTime_HH.ToString("00") + lsmServiceCheckInfo.LsmStartTime_mm.ToString("00");
                    DateTime dt = DateTime.ParseExact(lsmStartTime, "HHmm", null);

                    // XML���e��ݒ�
                    this._lsmStartTime = lsmStartTime;


                    long now = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));
                    long day = long.Parse(DateTime.Now.ToString("yyyyMMdd"));       // �N�����t

                    if (long.Parse(day.ToString() + this._lsmStartTime) <= now)
                    {
                        this._startDay = day;
                    }
                }
                catch
                {
                    status = -1;
                }
            }

            return status;
        }

        /// <summary>
        /// LSM�T�[�r�X�Ď��^�C�}�[�ݒ�t�@�C���Ǎ�
        /// </summary>
        protected int ReadLsmCheckFile(ref LsmServiceCheckInfo lsmServiceCheckInfo)
        {
            int status = 0;

            FileStream fs = null;
            try
            {
                // �ݒ�t�@�C���ǂݍ���(���[�U�[AP�T�[�r�X�Ɠ���t�H���_�ɑ���)
                string fileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string filePath = Path.Combine(fileDir, ct_LsmCheckInfoFile);

                lsmServiceCheckInfo = UserSettingController.DeserializeUserSetting<LsmServiceCheckInfo>(filePath);
            }
            catch (System.IO.FileNotFoundException)
            {
                // �t�@�C�������݂��Ȃ��ꍇ�̓G���[�Ƃ���
                status = -1;
            }
            catch (Exception ex)
            {
                status = -1;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// LSM�Ď��^�C�}�[����
        /// </summary>
        void LsmCheckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            long now = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));
            long day = long.Parse(DateTime.Now.ToString("yyyyMMdd"));       // �N�����t

            bool startFlg = false;
            //----------------------------------------
            // LSM�T�[�r�X����N��
            //----------------------------------------
            if (this._startDay != day)
            {   // �O��N�����t�ƌ��ݓ��t���قȂ�ꍇ

                if (long.Parse(day.ToString() + this._lsmStartTime) <= now)
                {   // �ݒ莞����茻�ݎ����̕����傫���ꍇ
                    startFlg = true;

                    // LSM�T�[�r�X��~
                    StopService(cLsmServiceName);

                    // �J�E���^�[���Z�b�g
                    this._lsmCheckIntervalCounter = 0;

                    // �N�����t�Đݒ�
                    this._startDay = day;
                }
            }

            //----------------------------------------
            // LSM�T�[�r�X�Ď��i��~���̏ꍇ�ɋN���j
            //----------------------------------------
            if (this._lsmCheckIntervalCounter <= 0)
            {
                // LSM�T�[�r�X�J�n
                StartService(cLsmServiceName, startFlg);

                // �J�E���^�[�Đݒ�
                this._lsmCheckIntervalCounter = this._lsmCheckInterval; // XML�̊Ď��Ԋu
            }
            // �J�E���^�[�X�V
            this._lsmCheckIntervalCounter -= 1;
        }

        /// <summary>
        /// �T�[�r�X �N������
        /// </summary>
        protected void StartService(string targetServiceName, bool startFlg)
        {
            string sMsg = "Partsman.NS LSM�T�[�r�X����~���Ă����ׁA�N�����܂����B";
            if (startFlg)
            {
                sMsg = "����N�������ɂ�Partsman.NS LSM�T�[�r�X���N�����܂����B";
            }

            // �T�[�r�X�ꗗ�擾
            ServiceController[] scList = ServiceController.GetServices();
            foreach (ServiceController sc in scList)
            {
                // �w�肵���T�[�r�X�����T�[�r�X�ꗗ�ɑ��݂��Ă���ꍇ
                if (sc.ServiceName == (string)targetServiceName)
                {
                    // �T�[�r�X����~���Ă���ꍇ
                    if (sc.Status == ServiceControllerStatus.Stopped)
                    {
                        // �T�[�r�X �X�^�[�g�A�b�v�̏�Ԋm�F
                        if (ChkServiceStartMode((string)targetServiceName) == true)
                        {
                            try
                            {
                                sc.Start();  // �T�[�r�X�N��
                                WriteErrorLogStop(this.ServiceName, "StartService", sMsg, null, -1);
                            }
                            catch
                            {
                                // �T�[�r�X�N�����ɃG���[�����������\��������
                                WriteErrorLog(this.ServiceName, "StartService", string.Format("Partsman.NS LSM�T�[�r�X�N���ɂ�ERROR����"), null, -1);
                            }
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// �T�[�r�X ��~����
        /// </summary>
        protected void StopService(object targetServiceName)
        {
            // �T�[�r�X�ꗗ�擾
            ServiceController[] scList = ServiceController.GetServices();
            foreach (ServiceController sc in scList)
            {
                // �w�肵���T�[�r�X�����T�[�r�X�ꗗ�ɑ��݂��Ă���ꍇ
                if (sc.ServiceName == (string)targetServiceName)
                {
                    // �T�[�r�X���N�����Ă���ꍇ
                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        // �T�[�r�X �X�^�[�g�A�b�v�̏�Ԋm�F
                        if (ChkServiceStartMode((string)targetServiceName) == true)
                        {
                            try
                            {
                                sc.Stop();  // �T�[�r�X��~
                                sc.WaitForStatus(ServiceControllerStatus.Stopped);
                                WriteErrorLogStop(this.ServiceName, "StopService", string.Format("����N�������ɂ�Partsman.NS LSM�T�[�r�X����~���܂����B"), null, -1);
                            }
                            catch
                            {
                                // �T�[�r�X��~���ɃG���[�����������\��������
                                WriteErrorLogStop(this.ServiceName, "StopService", string.Format("Partsman.NS LSM�T�[�r�X��~�ɂ�ERROR����"), null, -1);
                            }
                        }
                    }
                    break;
                }
            }
        }
        // --- ADD 2015/09/25 T.Miyamoto LSM�T�[�o�[�z�M���� --------------------<<<<<

        // --- ADD 2015/12/21 ���{ ���[�U�[AP�N���s��Ή� -------------------->>>>>
        /// <summary>
        /// �����[�g�T�[�r�X�̍Ď��s���̎��O�������s���s���܂��B
        /// �A�v���P�[�V�����\���t�@�C���ɐݒ肳�ꂽ���L���𗘗p�����O�������s���܂��B
        /// �����w��b���ҋ@���邾���ƂȂ�܂����A���L�ݒ���ɂ�蓮�삪�ς��܂��B
        /// �@�EServiceOnStartRetryLogicType = kill
        /// �@�@������v���Z�X���̑��̃v���Z�X�������I�����܂��B
        /// 
        /// �@�EServiceOnStartRetryIntervalSeconds
        /// �@�@���ҋ@�b����ݒ�l�ɕύX���܂��B(1�`59�̂ݗL��)
        /// </summary>
        /// <param name="retryCount">�Ď��s��</param>
        /// <param name="retryMaxCount">�Ď��s�ő��</param>
        protected void OnStartRetryLogic(int retryCount,int retryMaxCount)
        {
            //2B.1.1.�Ď��s�������f
            string retryLogicType = ConfigurationManager.AppSettings["ServiceOnStartRetryLogicType"];
            if (!string.IsNullOrEmpty(retryLogicType) && "kill".Equals(retryLogicType) || (retryCount + 1) == retryMaxCount)
            {
                #region 2D.���v���Z�X�����I��
                Process currentProcess = Process.GetCurrentProcess();
                Process[] processArray = Process.GetProcessesByName(currentProcess.ProcessName);
                foreach (Process p in processArray)
                {
                    if (p.Id == currentProcess.Id)
                    {
                        continue;
                    }
                    try
                    {
                        this.WriteErrorLogStop(this.ServiceName, "OnStartRetryLogic", "���v���Z�X�𔭌����܂����B�����I�����܂�:"+p.Id+","+p.ProcessName, null, 0);
                        p.Kill();
                    }
                    catch (Exception ex)
                    {
                        this.WriteErrorLogStop(this.ServiceName, "OnStartRetryLogic", "�����I�����ɃG���[���������܂����B[" + ex.Message + "]", ex, -1);
                    }
                }
                #endregion
            }

            #region 2C.1.1.�w��b���ҋ@
            string retryIntervalSecondsSettings = ConfigurationManager.AppSettings["ServiceOnStartRetryIntervalSeconds"];
            int retryIntervalSeconds = 10;
            if (!string.IsNullOrEmpty(retryIntervalSecondsSettings) && Int32.TryParse(retryIntervalSecondsSettings, out retryIntervalSeconds))
            {
                if (retryIntervalSeconds <= 0 || retryIntervalSeconds >= 60)
                {
                    retryIntervalSeconds = 10;
                }
            }
            else
            {
                retryIntervalSeconds = 10;
            }
            Thread.Sleep(retryIntervalSeconds * 1000);
            #endregion
        }
        // --- ADD 2015/12/21 ���{ ���[�U�[AP�N���s��Ή� --------------------<<<<<

	}

    // --- ADD 2015/09/25 T.Miyamoto LSM�T�[�o�[�z�M���� -------------------->>>>>
    /// <summary>
    /// LSM�T�[�r�X�Ď��ݒ�t�@�C�����
    /// </summary>
    public class LsmServiceCheckInfo
    {
        /// <summary>�Ď��Ԋu</summary>
        private int _lsmCheckInterval;
        /// <summary>����N������(��)</summary>
        private int _lsmStartTime_HH;
        /// <summary>����N������(��)</summary>
        private int _lsmStartTime_mm;

        /// <summary>
        /// �Ď��Ԋu
        /// </summary>
        public int LsmCheckInterval
        {
            get
            {
                return _lsmCheckInterval;
            }
            set
            {
                _lsmCheckInterval = value;
            }
        }

        /// <summary>
        /// ����N������
        /// </summary>
        public int LsmStartTime_HH
        {
            get
            {
                return _lsmStartTime_HH;
            }
            set
            {
                _lsmStartTime_HH = value;
            }
        }
        /// <summary>
        /// ����N������
        /// </summary>
        public int LsmStartTime_mm
        {
            get
            {
                return _lsmStartTime_mm;
            }
            set
            {
                _lsmStartTime_mm = value;
            }
        }

    }
    // --- ADD 2015/09/25 T.Miyamoto LSM�T�[�o�[�z�M���� --------------------<<<<<
}
