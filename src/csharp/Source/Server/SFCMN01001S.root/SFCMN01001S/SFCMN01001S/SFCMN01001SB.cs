using System;
using System.Data;
using System.ServiceProcess;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
using System.Xml;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

namespace Broadleaf.ServiceProcess
{

    /// <summary>
    /// �R���o�[�g�Ώۃo�b�N�A�b�v���s�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g�Ώۂ̃o�b�N�A�b�v���������s���܂��B</br>
    /// <br>Programmer : 32470�@���� ���</br>
    /// <br>Date       : 2020.06.15</br>
    /// <br></br>
    /// </remarks>
    public class ConvObjBkExec 
    {
        // �莞�N���ݒ�
        private const string ct_BkSettingFile = "SFCMN01001S_BkSetting.XML"; // �ݒ�t�@�C��
        private const int ct_DefaultBkStarthh = 2;                           // �o�b�N�A�b�v�J�n�i���ԁj
        private const int ct_DefaultBkStartmm = 0;                           // �o�b�N�A�b�v�J�n�i���j
        private const string ct_ConvObjBkExec = "PMCMN00160U.exe";           // �o�b�N�A�b�v���s�v���O����
        private const string ct_ConvObjBkProcName = "PMCMN00160U";           // �o�b�N�A�b�v���s�v���O�����v���Z�X��
        private const string ct_FirstDeliveryFile = "PMCMN00160U_Delivery.txt"; // ������s���z�M�t�@�C��

        /// <summary>
        /// �N���p�����[�^�F�T�[�r�X
        /// </summary>
        private const string ARGS_Service = "Service";

        // ���(millisecond)
        private const int INTERVAL_1DAY = 86400000;

        // 1��(millisecond)
        private const int INTERVAL_1MINUTE = 60000;

        // �o�b�N�A�b�v�J�n�^�C�}�[
        private System.Timers.Timer _ConvObjBkExecTimer = null;

        // �o�b�N�A�b�v�쐬�������s�X���b�h
        private Thread _threadBk = null;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public ConvObjBkExec()
        {
        }

        /// <summary>
        /// �o�b�N�A�b�v�����J�n
        /// ����N�����Ƀo�b�N�A�b�v���s
        /// �莞�Ńo�b�N�A�b�v���s�i�ݒ�t�@�C���Ɏ��s���ԕێ��j
        /// </summary>
        public void ConvertObjBkStart()
        {
            int interval = 0;

            try
            {
                // USER_AP�t�H���_�擾
                string fileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                // ���s�t�@�C���p�X�ݒ�
                string filePath = Path.Combine(fileDir, ct_FirstDeliveryFile);

                // ����z�M���̃t�@�C�����Ȃ��ꍇ�o�b�N�A�b�v�������s
                if (!File.Exists(filePath))
                {
                    // ���łɎ��s���̃v���Z�X�����݂���ꍇ�͏I������
                    Process[] ps = Process.GetProcessesByName(ct_ConvObjBkProcName);
                    {
                        foreach (Process p in ps)
                        {
                            p.Kill();
                        }
                    }

                    // �N�����̃o�b�N�A�b�v�������s
                    // �T�[�r�X�ɉe�����Ȃ��悤�ʃX���b�h�Ŏ��s����
                    _threadBk = new Thread(new ThreadStart(ConvertObjBkExec));
                    _threadBk.Start();
                    _threadBk.IsBackground = true;
                }

                // �o�b�N�A�b�v�����^�C�}�[�ݒ�
                _ConvObjBkExecTimer = new System.Timers.Timer();
                _ConvObjBkExecTimer.Enabled = false;
                _ConvObjBkExecTimer.Elapsed += new System.Timers.ElapsedEventHandler(ConvObjBkTimer_Elapsed);
                
                // �C���^�[�o���ݒ�
                SetConvObjBkExecTimer(ref interval);
                _ConvObjBkExecTimer.Interval = interval;

                _ConvObjBkExecTimer.Enabled = true; // �o�b�N�A�b�v���s�^�C�}�[�N��

            }
            catch (Exception ex)
            {
                WriteErrorLog(typeof(ConvObjBkExec).Assembly.FullName, "ConvertObjBkStart", ex.Message, ex, -1);
            }
            finally
            {
            }

        }

        /// <summary>
        /// �T�[�r�X�I�����Ɍ㏈�����s��
        /// </summary>
        public void ConvertObjBkStop()
        {
            try
            {
                if (_ConvObjBkExecTimer.Enabled)
                {
                    _ConvObjBkExecTimer.Enabled = false; // �o�b�N�A�b�v���s�^�C�}�[��~
                }

                if (_threadBk != null)
                {
                    // �X���b�h�I��
                    _threadBk.Abort();
                    _threadBk = null;
                }

                // ���łɎ��s���̃v���Z�X���c���Ă���ꍇ�͏I������
                Process[] ps = Process.GetProcessesByName(ct_ConvObjBkProcName);
                {
                    foreach (Process p in ps)
                    {
                        p.Kill();
                    }
                }


            }
            catch (Exception ex)
            {
                WriteErrorLog(typeof(ConvObjBkExec).Assembly.FullName, "ConvertObjBkStop", ex.Message, ex, -1);
            }
        }

        /// <summary>
        /// �o�b�N�A�b�v�����N��
        /// </summary>
        private void ConvertObjBkExec()
        {
            try
            {
                // USER_AP�t�H���_�擾
                string fileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                // ���s�t�@�C���p�X�ݒ�
                string filePath = Path.Combine(fileDir, ct_ConvObjBkExec);

                Process ps = new Process();
                ps.StartInfo.FileName = filePath;
                ps.StartInfo.Arguments = ARGS_Service;
                ps.Start();
            }
            catch (Exception ex)
            {
                WriteErrorLog(typeof(ConvObjBkExec).Assembly.FullName, "ConvertObjBkExec", ex.Message, ex, -1);
            }
            finally
            {
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
        private void WriteErrorLog(string pgId, string method, string Msg, Exception ex, int status)
        {
            try
            {
                string exceptionMsg = "����";
                if (ex != null) exceptionMsg = ex.Message;
                string msg = string.Format("Method:{0} Msg:{1} Exception.Msg:{2}", method, Msg, exceptionMsg);
                LogTextOut logTextOut = new LogTextOut();
                logTextOut.Output(pgId, msg, status);
                // CLC���O�o�͕��i�ďo�ǉ�
                CLCLogTextOut clcLogTextOut = new CLCLogTextOut();
                clcLogTextOut.OutputClcLog(pgId, null, msg, status, ex);
            }
            catch
            {
                // ���O�o�͂͗�O�����������s
            }
            finally
            {
            }
        }

        /// <summary>
        /// �o�b�N�A�b�v���s�Ď��^�C�}�[�ݒ�
        /// </summary>
        private int SetConvObjBkExecTimer(ref int interval)
        {
            // LSM�T�[�r�X�Ď��^�C�}�[�ݒ�t�@�C���Ǎ�
            ConvObjBkExecInfo convObjBkExecInfo = new ConvObjBkExecInfo();
            int status = ReadBkSettingFile(ref convObjBkExecInfo);

            try
            {
                // ����N������
                TimeSpan ts = new TimeSpan(convObjBkExecInfo.BkStartTime_HH, convObjBkExecInfo.BkStartTime_mm, 0);
                int execTime = Convert.ToInt32(ts.TotalMilliseconds);

                // �V�X�e�����Ԏ擾
                int systemTime = Convert.ToInt32(DateTime.Now.TimeOfDay.TotalMilliseconds);

                if (execTime > systemTime)
                {
                    // �莞�N������ > �V�X�e������
                    // �莞�N������ - �V�X�e���������^�C�}�[�Ƃ���
                    interval = (execTime - systemTime);
                }
                else
                {
                    // �莞�N������ + 1�� - �V�X�e���������^�C�}�[�Ƃ���
                    interval = (execTime + INTERVAL_1DAY) - systemTime;
                }
            }
            catch(Exception ex)
            {
                WriteErrorLog(typeof(ConvObjBkExec).Assembly.FullName, "SetConvObjBkExecTimer", ex.Message, ex, -1);
                // ��O��������1����Ƀ��g���C
                interval = INTERVAL_1MINUTE;
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// �o�b�N�A�b�v���s�^�C�}�[�ݒ�t�@�C���Ǎ�
        /// </summary>
        private int ReadBkSettingFile(ref ConvObjBkExecInfo convObjBkExecInfo)
        {
            int status = 0;

            FileStream fs = null;

            convObjBkExecInfo.BkStartTime_HH = ct_DefaultBkStarthh;
            convObjBkExecInfo.BkStartTime_mm = ct_DefaultBkStartmm;

            try
            {
                // �ݒ�t�@�C���ǂݍ���(���[�U�[AP�T�[�r�X�Ɠ���t�H���_�ɑ���)
                string fileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string filePath = Path.Combine(fileDir, ct_BkSettingFile);

                convObjBkExecInfo = UserSettingController.DeserializeUserSetting<ConvObjBkExecInfo>(filePath);
            }
            catch (System.IO.FileNotFoundException)
            {
                // �t�@�C�������݂��Ȃ��ꍇ�͏����l��ݒ肷��
                convObjBkExecInfo.BkStartTime_HH = ct_DefaultBkStarthh;
                convObjBkExecInfo.BkStartTime_mm = ct_DefaultBkStartmm;
            }
            catch (Exception ex)
            {
                WriteErrorLog(typeof(ConvObjBkExec).Assembly.FullName, "ConvertObjBkStart", ex.Message, ex, -1);
                // ��O�������͏����l��ݒ肷��
                convObjBkExecInfo.BkStartTime_HH = ct_DefaultBkStarthh;
                convObjBkExecInfo.BkStartTime_mm = ct_DefaultBkStartmm;
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
        /// �o�b�N�A�b�v���s�^�C�}�[����
        /// </summary>
        void ConvObjBkTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                int interval = 0;
                long now = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));
                long day = long.Parse(DateTime.Now.ToString("yyyyMMdd"));       // �N�����t

                //----------------------------------------
                // �o�b�N�A�b�v����N��
                //----------------------------------------
                // �N�����̃o�b�N�A�b�v�������s
                // �T�[�r�X�ɉe�����Ȃ��悤�ʃX���b�h�Ŏ��s����
                _threadBk = new Thread(new ThreadStart(ConvertObjBkExec));
                _threadBk.Start();
                _threadBk.IsBackground = true;

                // �C���^�[�o���ݒ�
                SetConvObjBkExecTimer(ref interval);
                _ConvObjBkExecTimer.Interval = interval;
            }
            catch (Exception ex)
            {
                WriteErrorLog(typeof(ConvObjBkExec).Assembly.FullName, "ConvObjBkTimer_Elapsed", ex.Message, ex, -1);
            }
        }

    }

    /// <summary>
    /// �o�b�N�A�b�v�N���Ď��ݒ�t�@�C�����
    /// </summary>
    public class ConvObjBkExecInfo
    {
        /// <summary>����N������(��)</summary>
        private int _bkStartTime_HH;
        /// <summary>����N������(��)</summary>
        private int _bkStartTime_mm;

        /// <summary>
        /// ����N������
        /// </summary>
        public int BkStartTime_HH
        {
            get
            {
                return _bkStartTime_HH;
            }
            set
            {
                _bkStartTime_HH = value;
            }
        }
        /// <summary>
        /// ����N������
        /// </summary>
        public int BkStartTime_mm
        {
            get
            {
                return _bkStartTime_mm;
            }
            set
            {
                _bkStartTime_mm = value;
            }
        }

    }
}
