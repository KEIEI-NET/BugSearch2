using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Threading;
using System.IO;
using System.Web;
using System.Net;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���iMAX�A�g���i
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�V�X�e�����畔�iMAX�ɃA�N�Z�X���邽�߂̎�i��񋟂���B</br>
    /// <br>Programmer : �e�c ���V</br>
    /// <br>Date       : 2016/01/25</br>
    /// <br></br>
    /// </remarks>
    public class BuhinMaxExhibitStockProvider
    {
        # region Private Members
        private readonly object _lockObject = new object();
        private BuhinMaxRequest _buhinMaxRequest;
        private Thread _maxThread;

        private string _loginID;            // �F��ID
        private string _password;           // �F�؃p�X���[�h
        private string _csvFileFullName;    // �ۑ�����CSV�t�@�C����
        private string _errFileName;        // �G���[���e��ۑ�����CSV�t�@�C����
        private string _wkFileName;         // �����������e��ۑ�����CSV�t�@�C����

        private volatile string _errorMessage;       // �G���[���b�Z�[�W
        private volatile int _registStatus;          // �A�b�v���[�h�����̃X�e�[�^�X

        private volatile int _maxProcStatus;                        // �A�b�v���[�h�����̃X�e�[�^�X
        private volatile Dictionary<DateTime, string> _messagelist; // �ʒm���b�Z�[�W���X�g
        private volatile int _timeLeftSeconds;                      // �c�莞��
        private volatile string _errorListCsvFileFullName;          // �G���[���X�gCSV�t�@�C����

        /// <summary>
        /// �F��ID
        /// </summary>
        public string LoginID
        {
            get { return _loginID; }
            set { _loginID = value; }
        }
        /// <summary>
        /// �F�؃p�X���[�h
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// �ۑ�����CSV�t�@�C����
        /// </summary>
        public string CsvFileFullName
        {
            get { return _csvFileFullName; }
            set { _csvFileFullName = value; }
        }
        /// <summary>
        /// �G���[���e��ۑ�����CSV�t�@�C����
        /// </summary>
        public string ErrFileName
        {
            get { return _errFileName; }
            set { _errFileName = value; }
        }
        /// <summary>
        /// �G���[���b�Z�[�W
        /// </summary>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
        /// <summary>
        /// �o�^�@�\�X�e�[�^�X
        /// </summary>
        public int RegistStatus
        {
            get { return _registStatus; }
            set { _registStatus = value; }
        }
        /// <summary>
        /// �����������e��ۑ�����CSV�t�@�C����
        /// </summary>
        public string WkFileName
        {
            get { return _wkFileName; }
            set { _wkFileName = value; }
        }
        /// <summary>
        /// �A�b�v���[�h�����̃X�e�[�^�X
        /// </summary>
        public int MaxProcStatus
        {
            get { return _maxProcStatus; }
            set { _maxProcStatus = value; }
        }
        /// <summary>
        /// �ʒm���b�Z�[�W���X�g
        /// </summary>
        public Dictionary<DateTime, string> Messagelist
        {
            get { return _messagelist; }
            set { _messagelist = value; }
        }
        /// <summary>
        /// �c�莞��
        /// </summary>
        public int TimeLeftSeconds
        {
            get { return _timeLeftSeconds; }
            set { _timeLeftSeconds = value; }
        }
        /// <summary>
        /// �G���[���X�gCSV�t�@�C����
        /// </summary>
        public string ErrorListCsvFileFullName
        {
            get { return _errorListCsvFileFullName; }
            set { _errorListCsvFileFullName = value; }
        }

        # endregion Private Members

        #region �o�i�E�݌Ɉꊇ�o�^�@�\
        /// <summary>
        /// �o�i�E�݌Ɉꊇ�o�^�@�\
        /// </summary>
        /// <param name="loginID">���ח\��ΏۂƂȂ�X�܂Ƀ��O�C�����邽�߂̔F��ID</param>
        /// <param name="password">���ח\��ΏۂƂȂ�X�܂Ƀ��O�C�����邽�߂̔F�؃p�X���[�h</param>
        /// <param name="csvFileFullName">�o�^������ח\�����ۑ�����CSV�t�@�C����</param>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        public int Regist(string loginID, string password, string csvFileFullName, ref string errorMessage)
        {
            int status = (int)BuhinMaxRequest.MAX_Status.ct_SYS_ERROR;

            try
            {
                #region �p�����[�^�`�F�b�N
                // �F��ID
                if (string.IsNullOrEmpty(loginID))
                {
                    // null or �󕶎�
                    throw new NullReferenceException();
                }
                // �F�؃p�X���[�h
                if (string.IsNullOrEmpty(password))
                {
                    // null or �󕶎�
                    throw new NullReferenceException();
                }
                // CSV�t�@�C����
                if (string.IsNullOrEmpty(csvFileFullName))
                {
                    // null or �󕶎�
                    throw new NullReferenceException();
                }
                // CSV�t�@�C������
                if (!(File.Exists(csvFileFullName)))
                {
                    // �t�@�C�������݂��Ȃ�
                    throw new FileNotFoundException();
                }
                #endregion �p�����[�^�`�F�b�N

                // �G���[�t�@�C�����쐬
                string fileExtension = Path.GetExtension(csvFileFullName);
                string errFileName = "_" + DateTime.Now.ToString("yyyy.MM.dd_HHmmss") + fileExtension;
                // �����t�@�C�����쐬
                //string wkFileName = "_E" + fileExtension;
                string wkFileName = Environment.TickCount.ToString() +"_E" + fileExtension;

                // �ϐ��ݒ�
                this.LoginID = loginID;
                this.Password = password;
                this.CsvFileFullName = csvFileFullName;
                this.ErrFileName = csvFileFullName.Replace(fileExtension, errFileName);
                //this.WkFileName = csvFileFullName.Replace(fileExtension, wkFileName);
                this.WkFileName = Path.GetDirectoryName(csvFileFullName) + "\\" + wkFileName;

                // ���iMAX�o�^����
                this._maxThread = new Thread(this.BuhinMaxThread);
                if (!this._maxThread.IsAlive)
                {
                    this._maxThread.IsBackground = true;
                    this._maxThread.Start();
                    lock (_lockObject)
                    {
                        // ���b�N���J�������܂ő҂�
                        Monitor.Wait(_lockObject);
                    }
                }

                errorMessage = this.ErrorMessage;
                status = this.RegistStatus;
            }
            catch (NullReferenceException)
            {
                errorMessage = "�p�����[�^�Ɍ�肪����܂��B";
            }
            catch (FileNotFoundException)
            {
                errorMessage = "�t�@�C�������݂��܂���B";
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return status;
        }
        #endregion �o�i�E�݌Ɉꊇ�o�^�@�\

        #region �o�^��Ԏ擾�@�\
        /// <summary>
        /// �o�^��Ԏ擾�@�\
        /// </summary>
        /// <param name="readMessageDateTime">���b�Z�[�W�Ǎ��ΏۂƂ���X�V���t���</param>
        /// <param name="errorListCsvFileFullName">�����I�ɓo�^�ł��Ȃ������G���[���X�gCSV�t�@�C����</param>
        /// <param name="timeLeftSeconds">�c�莞��</param>
        /// <param name="messagelist">�ʒm���b�Z�[�W���X�g</param>
        /// <returns></returns>
        public int GetRegistStatus(DateTime readMessageDateTime, ref string errorListCsvFileFullName, ref int timeLeftSeconds, ref List<string> messagelist)
        {
            int status = (int)BuhinMaxRequest.MAX_Status.ct_SYS_ERROR;
            try
            {
                // �G���[���X�gCSV�t�@�C����
                errorListCsvFileFullName = this.ErrorListCsvFileFullName;

                // �c�莞��
                TimeSpan ts = new TimeSpan(0, 0, this.TimeLeftSeconds);
                timeLeftSeconds = ts.Minutes;

                // �ʒm���b�Z�[�W���X�g
                Dictionary<DateTime, string> messagelist_wk = new Dictionary<DateTime, string>();
                foreach (DateTime key in this.Messagelist.Keys)
                {
                    messagelist_wk.Add(key, this.Messagelist[key]);
                }

                foreach (DateTime messageDateTime in messagelist_wk.Keys)
                {
                    if (messagelist == null)
                        messagelist = new List<string>();

                    if (readMessageDateTime < messageDateTime)
                    {
                        // �X�V���t�����V�����ꍇ
                        //string message = messageDateTime.ToString("HH:mm") + " " + this.Messagelist[messageDateTime];
                        string message = this.Messagelist[messageDateTime];
                        messagelist.Add(message);
                    }
                }

                // �X�e�[�^�X
                status = this.MaxProcStatus;
            }
            catch (Exception ex)
            {
                messagelist.Add(ex.Message);
            }
            return status;
        }
        #endregion �o�^��Ԏ擾�@�\

        #region �����t�@�C�����M�X���b�h
        /// <summary>
        /// �����t�@�C�����M�X���b�h
        /// </summary>
        public void BuhinMaxThread()
        {
            int status = (int)BuhinMaxRequest.MAX_Status.ct_SYS_ERROR;
            string message = string.Empty;

            try
            {
                // ��ԊĎ��p�X�e�[�^�X
                this.MaxProcStatus = (int)BuhinMaxRequest.MAX_Status.ct_SYS_ERROR;

                string textString = string.Empty;
                int allLineCount = -1;      // �����R�[�h��
                int procCount = 0;          // �����σ��R�[�h��
                bool somefail_Flg = false;  // �ꕔ���s�t���O
                string urlLogin = string.Empty;
                string urlPost = string.Empty;
                string fileHeader = string.Empty;

                // �t�@�C���I�[�v��
                using (StreamReader sr = new StreamReader(this.CsvFileFullName, Encoding.GetEncoding("Shift_JIS")))
                {
                    // �����R�[�h�����擾
                    while (sr.Peek() >= 0)
                    {
                        sr.ReadLine();
                        allLineCount += 1;
                    }
                }

                if (allLineCount <= 0)
                {
                    // �t�@�C���̒��g���Ȃ�
                    throw new NullReferenceException();
                }

                // ���iMAX�A�g�I�u�W�F�N�g����
                _buhinMaxRequest = new BuhinMaxRequest();

                #region DEL
                //// XML�t�@�C�����URL���擾����
                //BuhinMaxUrlInfo buhinMaxUrlInfo;
                //status = _buhinMaxRequest.DecryptFile(out buhinMaxUrlInfo, out message);
                //if (status != (int)BuhinMaxRequest.MAX_Status.ct_NORMAL)
                //{
                //    // 1��ڂ̃��N�G�X�g�^���X�|���X�p
                //    this.RegistStatus = status;
                //    this.ErrorMessage = message;

                //    lock (_lockObject)
                //    {
                //        // ���b�N���J������
                //        Monitor.PulseAll(_lockObject);
                //    }

                //    // ��ԊĎ��p�X�e�[�^�X
                //    this.MaxProcStatus = status;

                //    return;
                //}
                #endregion DEL

                this._messagelist = new Dictionary<DateTime, string>();
                // <<----- �ʒm���b�Z�[�W�쐬 ----->>
                this.SetMessagelist("���iMAX�փ��O�C�����܂��B");

                //�F�ؗp�N�b�L�[���i�[����R���e�i�𐶐�
                CookieContainer cc = new CookieContainer();

                status = _buhinMaxRequest.CreateLogInUrl(out urlLogin, out message);
                if (status != (int)BuhinMaxRequest.MAX_Status.ct_NORMAL)
                {
                    // 1��ڂ̃��N�G�X�g�^���X�|���X�p
                    this.RegistStatus = status;
                    this.ErrorMessage = message;

                    lock (_lockObject)
                    {
                        // ���b�N���J������
                        Monitor.PulseAll(_lockObject);
                    }

                    // ��ԊĎ��p�X�e�[�^�X
                    this.MaxProcStatus = status;

                    return;
                }

                // ���iMAX���O�C������
                status = _buhinMaxRequest.LoginBuhinMax(this.LoginID, this.Password, urlLogin, ref cc, out message);
                if (status != (int)BuhinMaxRequest.MAX_Status.ct_NORMAL)
                {
                    // ----------
                    // ���O�C�����s

                    // 1��ڂ̃��N�G�X�g�^���X�|���X�p
                    this.RegistStatus = status;
                    this.ErrorMessage = message;

                    lock (_lockObject)
                    {
                        // ���b�N���J������
                        Monitor.PulseAll(_lockObject);
                    }

                    // ��ԊĎ��p�X�e�[�^�X
                    this.MaxProcStatus = status;

                    return;
                }

                // <<----- �ʒm���b�Z�[�W�쐬 ----->>
                this.SetMessagelist("���iMAX�փA�b�v���[�h�����s���܂��B");

                status = _buhinMaxRequest.CreateDeriveryUrl(out urlPost, out message);
                if (status != (int)BuhinMaxRequest.MAX_Status.ct_NORMAL)
                {
                    // 1��ڂ̃��N�G�X�g�^���X�|���X�p
                    this.RegistStatus = status;
                    this.ErrorMessage = message;

                    lock (_lockObject)
                    {
                        // ���b�N���J������
                        Monitor.PulseAll(_lockObject);
                    }

                    // ��ԊĎ��p�X�e�[�^�X
                    this.MaxProcStatus = status;

                    return;
                }

                DateTime timeStart = DateTime.Now;  // �����J�n����
                TimeSpan timeProcess;               // ��������

                bool fastFlg = true;

                // �t�@�C���I�[�v��
                using (StreamReader sr = new StreamReader(this.CsvFileFullName, Encoding.GetEncoding("Shift_JIS")))
                {
                    int counter = 0;
                    while (true)
                    {
                        if (fastFlg)
                        {
                            // �w�b�_�[�s���΂�
                            fileHeader = sr.ReadLine();
                            fastFlg = false;
                            continue;
                        }
                        textString = sr.ReadLine();

                        // ���M�p�t�@�C���쐬
                        using (StreamWriter sw = new StreamWriter(this.WkFileName, true, Encoding.GetEncoding("Shift_JIS")))
                        {
                            if (counter == 0)
                            {
                                // �w�b�_�[�s�o��
                                sw.WriteLine(fileHeader);
                            }
                            sw.WriteLine(textString);
                        }
                        counter++;

                        if (counter == 10 || sr.EndOfStream == true)
                        {
                            // �����t�@�C���𑗐M
                            status = _buhinMaxRequest.PostBuhinMax(urlPost, this.WkFileName, ref cc, out message);

                            if (status != (int)BuhinMaxRequest.MAX_Status.ct_NORMAL)
                            {
                                // ----------
                                // ���M���s
                                // ----------

                                // 1��ڂ̃��N�G�X�g�^���X�|���X�p
                                this.RegistStatus = status;
                                this.ErrorMessage = message;

                                // <<----- �ʒm���b�Z�[�W�쐬 ----->>
                                this.SetMessagelist(message);

                                // ���M�p�t�@�C���폜
                                if (File.Exists(this.WkFileName))
                                {
                                    File.Delete(this.WkFileName);
                                }

                                lock (_lockObject)
                                {
                                    // ���b�N���J������
                                    Monitor.PulseAll(_lockObject);
                                }
                                // ��ԊĎ��p�X�e�[�^�X
                                this.MaxProcStatus = status;

                                return;
                            }

                            if (message != string.Empty)
                            {
                                // <<----- �ʒm���b�Z�[�W�쐬 ----->>
                                this.SetMessagelist(message);

                                // �ꕔ�G���[������ꍇ
                                if (!(File.Exists(this.ErrFileName)))
                                {
                                    // �w�b�_�[�s�o��
                                    using (StreamWriter sw = new StreamWriter(this.ErrFileName, true, Encoding.GetEncoding("Shift_JIS")))
                                    {
                                        sw.WriteLine(fileHeader);
                                    }
                                }

                                using (StreamReader sr_err = new StreamReader(this.WkFileName, Encoding.GetEncoding("Shift_JIS")))
                                {
                                    string textStringErr;
                                    fastFlg = true;
                                    while ((textStringErr = sr_err.ReadLine()) != null)
                                    {
                                        if (fastFlg)
                                        {
                                            // �w�b�_�[�s���΂�
                                            fastFlg = false;
                                            continue;
                                        }
                                        using (StreamWriter sw = new StreamWriter(this.ErrFileName, true, Encoding.GetEncoding("Shift_JIS")))
                                        {
                                            sw.WriteLine(textStringErr);
                                        }
                                    }
                                }
                                this.ErrorListCsvFileFullName = this.ErrFileName;
                                somefail_Flg = true;
                            }

                            // ��������
                            timeProcess = DateTime.Now - timeStart;

                            // �����ό���
                            procCount += counter;

                            // 1��ڂ̃��N�G�X�g�^���X�|���X�p
                            this.RegistStatus = status;
                            this.ErrorMessage = message;

                            // ���M�p�t�@�C���폜
                            if (File.Exists(this.WkFileName))
                            {
                                File.Delete(this.WkFileName);
                            }

                            lock (_lockObject)
                            {
                                // ���b�N���J������
                                Monitor.PulseAll(_lockObject);
                            }

                            if (sr.EndOfStream == true)
                            {
                                // �c�莞�� = 0
                                this._timeLeftSeconds = 0;
                                break;
                            }
                            else
                            {
                                // �c�莞�� = ( �������� / ������ ) X ( �����R�[�h���� - �����ό��� )
                                this._timeLeftSeconds = (int)(timeProcess.TotalSeconds / counter) * (allLineCount - procCount);
                                timeStart = DateTime.Now;  // �����J�n����
                                this.MaxProcStatus = (int)BuhinMaxRequest.MAX_Status.ct_RUN;    // ���s��
                            }
                            // �J�E���^�N���A
                            counter = 0;
                        }
                    }

                    if (somefail_Flg)
                    {
                        // ��ԊĎ��p�X�e�[�^�X
                        this.MaxProcStatus = (int)BuhinMaxRequest.MAX_Status.ct_SOME_FAIL;  // �ꕔ���s
                    }
                    else
                    {
                        // ��ԊĎ��p�X�e�[�^�X
                        this.MaxProcStatus = (int)BuhinMaxRequest.MAX_Status.ct_NORMAL;     // ����
                    }

                    // <<----- �ʒm���b�Z�[�W�쐬 ----->>
                    this.SetMessagelist("���iMAX�փA�b�v���[�h���������܂����B");
                }
            }
            catch (NullReferenceException)
            {
                message = "���iMAX�փA�b�v���[�h�����񂪂���܂���B";
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // <<----- �ʒm���b�Z�[�W�쐬 ----->>
                this.SetMessagelist(ex.Message);
            }
            finally
            {
                // 1��ڂ̃��N�G�X�g�^���X�|���X�p
                this.RegistStatus = status;
                this.ErrorMessage = message;

                // ���M�p�t�@�C���폜
                if (File.Exists(this.WkFileName))
                {
                    File.Delete(this.WkFileName);
                }

                lock (_lockObject)
                {
                    // ���b�N���J������
                    Monitor.PulseAll(_lockObject);
                }
            }
        }
        #endregion �����t�@�C�����M�X���b�h

        #region ���s�󋵃��O�쐬
        /// <summary>
        /// ���s�󋵃��O�쐬
        /// </summary>
        /// <param name="message">���b�Z�[�W</param>
        private void SetMessagelist(string message)
        {
            try
            {
                if (this._messagelist == null)
                    this._messagelist = new Dictionary<DateTime, string>();

                this._messagelist.Add(DateTime.Now, message);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
        #endregion ���s�󋵃��O�쐬
    }
}
