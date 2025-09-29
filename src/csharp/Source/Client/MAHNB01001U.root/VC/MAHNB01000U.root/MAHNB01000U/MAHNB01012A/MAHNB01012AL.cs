using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Collections;
using System.Windows.Forms;
using System.Drawing;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����p���샍�O�o�̓A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����p���샍�O�o�͋@�\�B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/02/11</br>
    /// <br>Update Note: 2011/03/07 ������</br>
    /// <br>             Redmine #19637�̑Ή�</br>
    /// <br>Update Note: 2013/01/24 ���N�n��</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>             Redmine#34141 �ꊇ�l�����\��ǉ��ɂ��Ă̑Ή�</br>
    /// <br></br>
    /// </remarks>
    public class SurveyUseLogOutputAcs
    {
        #region ���v���C�x�[�g�ϐ�
        // bmp�t�@�C���ۑ��p
        private Bitmap _bmp;

        // �t�@�C����
        private string _fileName = string.Empty;

        // �t�@�C���������p
        private DateTime dateTime;

        private List<LogData> logList = null;

        public bool _isErrorFlag = false;
        #endregion

        #region ��Const Members
        private const string preFileName = "ErrorLog_MAHNB01001U_";
        private const string txtEndFileName = ".csv";
        private const string datEndFileName = ".dat";
        private const string bmpEndFileName = ".bmp";
        private const string timeFormat = "yyyyMMddHHmmss";
        //private const string filePath = @"C:\\Program Files\\Partsman\\Log\\";   // DEL 2011/03/07
        #endregion

        #region ��Constructor
        public SurveyUseLogOutputAcs()
        {
            this.dateTime = new DateTime();
            this.logList = new List<LogData>();
        }
        #endregion

        #region ���v���C�x�[�g ���\�b�h
        /// <summary>
        /// �G���[�f�[�^�N���X���t�@�C���ɃV���A���C�Y
        /// </summary>
        /// <param name="customSerializeArrayList">���ナ�X�g</param>
        /// <remarks>
        /// <br>Note       : �G���[�f�[�^�N���X���t�@�C���ɃV���A���C�Y����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/02/11</br> 
        /// <br>Update Note: 2011/03/07 ������</br>
        /// <br>             Redmine #19637�̑Ή�</br>
        /// </remarks>
        private void OutputErrorDateFile(CustomSerializeArrayList customSerializeArrayList)
        {
            if (this.dateTime == DateTime.MinValue)
            {
                this.SetDateTime();
            }
            // �t�@�C�����̐���
            string datFileName = preFileName + this.dateTime.ToString(timeFormat) + datEndFileName;
            string filePath = Path.GetFullPath(Path.Combine("log", datFileName)); // ADD 2011/03/07
            object obj = customSerializeArrayList;

            //System.IO.FileStream mem = new System.IO.FileStream(filePath + datFileName, System.IO.FileMode.OpenOrCreate); // DEL 2011/03/07
            System.IO.FileStream mem = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate); // ADD 2011/03/07
            System.IO.BinaryWriter bWriter = new System.IO.BinaryWriter(mem);

            CustomSerializeArrayList_SerializationSurrogate_For_V51010 serializer
                                             = new CustomSerializeArrayList_SerializationSurrogate_For_V51010();
            serializer.Serialize(bWriter, obj);

            mem.Close();
            mem.Dispose();
            bWriter.Close();
        }

        /// <summary>
        /// ��ʃL���v�`���摜��bmp�t�@�C���ɏo��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʃL���v�`���摜��bmp�t�@�C���ɏo�͂���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/02/11</br> 
        /// <br>Update Note: 2011/03/07 ������</br>
        /// <br>             Redmine #19637�̑Ή�</br>
        /// </remarks>
        private void OutputBmpFile()
        {
            if (this.dateTime == DateTime.MinValue)
            {
                this.SetDateTime();
            }
            // �t�@�C�����̐���
            string bmpFileName = preFileName + this.dateTime.ToString(timeFormat) + bmpEndFileName;
            string filePath = Path.GetFullPath(Path.Combine("log", bmpFileName)); // ADD 2011/03/07

            if (this._bmp == null)
            {
                this.CacheImage();
            }

            //this._bmp.Save(filePath + bmpFileName); // DEL 2011/03/07
            this._bmp.Save(filePath); // ADD 2011/03/07
        }

        /// <summary>
        /// ���앪�ނƓ��e�����
        /// </summary>
        /// <param name="logNo">���O�ԍ�</param>
        /// <param name="slipNo">�`�[�ԍ��Ȃ�</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : ���앪�ނƓ��e�����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/02/11</br> 
        /// <br>Update Note: 2013/01/24 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#34141 �ꊇ�l�����\��ǉ��ɂ��Ă̑Ή�</br>
        /// </remarks>
        private string GetLogFromLogNo(int logNo, int slipNo, int acptAnOdrStatus)
        {
            string logText = string.Empty;

            #region ���앪�ނƓ��e�����B
            switch (logNo)
            {
                case 1:
                    logText = "START,�N��";
                    break;
                case 2:
                    logText = "FUNCTION,�I��(F1)";
                    break;
                case 3:
                    logText = "FUNCTION,�V�K(F9)";
                    break;
                case 4:
                    logText = "FUNCTION,�m��(F10)";
                    break;
                case 5:
                    logText = "FUNCTION,�ۑ�(F10)";
                    break;
                case 6:
                    logText = "FUNCTION,�`�[�폜(F12)";
                    break;
                case 7:
                    logText = "FUNCTION,�߂�(F2)";
                    break;
                case 8:
                    logText = "FUNCTION,�i��(F3)";
                    break;
                case 9:
                    logText = "FUNCTION,�����ؑ�(F4)";
                    break;
                case 10:
                    logText = "FUNCTION,�K�C�h(F5)";
                    break;
                case 11:
                    logText = "FUNCTION,�`�[�ďo(X)";
                    break;
                case 12:
                    logText = "FUNCTION,�ݏo�v��(I)";
                    break;
                case 13:
                    logText = "FUNCTION,�󒍌v��(H)";
                    break;
                case 14:
                    logText = "FUNCTION,���όv��(Q)";
                    break;
                case 15:
                    logText = "FUNCTION,���o�\�t(F6)";
                    break;
                case 16:
                    logText = "FUNCTION,�X�V(V)";
                    break;
                case 17:
                    logText = "FUNCTION,���ɖ߂�(U)";
                    break;
                case 18:
                    logText = "FUNCTION,�ԓ`(R)";
                    break;
                case 19:
                    logText = "FUNCTION,�ԕi(Y)";
                    break;
                case 20:
                    logText = "FUNCTION,�`�[����(P)";
                    break;
                case 21:
                    logText = "FUNCTION,�ݒ�(O)";
                    break;
                case 22:
                    logText = "FUNCTION,�ŐV���(A)";
                    break;
                case 23:
                    logText = "ACTION,�R�s�[(C)";
                    break;
                case 24:
                    logText = "ACTION,�\��t��(V)";
                    break;
                case 25:
                    logText = "ACTION,�}��(I)";
                    break;
                case 26:
                    logText = "ACTION,�폜(F11)";
                    break;
                case 27:
                    logText = "ACTION,�؂���(T)";
                    break;
                case 28:
                    logText = "ACTION,���͐ؑ�(F7)";
                    break;
                case 29:
                    logText = "ACTION,�d��(F6)";
                    break;
                case 30:
                    logText = "ACTION,����(F12)";
                    break;
                case 31:
                    logText = "ACTION,�s�l��(M)";
                    break;
                case 32:
                    logText = "ACTION,���i�l��(N)";
                    break;
                case 33:
                    logText = "ACTION,����(L)";
                    break;
                case 34:
                    logText = "ACTION,�Ԏ�ύX(S)";
                    break;
                case 35:
                    logText = "ACTION,�݌Ɍ���(Z)";
                    break;
                case 36:
                    logText = "ACTION,�q�ɐؑ�(F8)";
                    break;
                case 37:
                    logText = "ACTION,TBO(B)";
                    break;
                case 38:
                    logText = "ACTION,�O�s����(J)";
                    break;
                case 39:
                    logText = "ACTION,�ꊇ����(K)";
                    break;
                case 40:
                    logText = "READ,�`�[�Ǎ��i�`�[�ԍ�=" + slipNo.ToString("D9") + "�A�󒍃X�e�[�^�X=" + acptAnOdrStatus.ToString("D2") + "�j";
                    break;
                case 41:
                    logText = "WRITE,�`�[�o�^�i�`�[�ԍ�=" + slipNo.ToString("D9") + "�A�󒍃X�e�[�^�X=" + acptAnOdrStatus.ToString("D2") + "�j";
                    break;
                case 42:
                    logText = "ERROR,�`�[�o�^�i�`�[�ԍ�=" + slipNo.ToString("D9") + "�A�󒍃X�e�[�^�X=" + acptAnOdrStatus.ToString("D2") + "�j";
                    break;
                case 43:
                    logText = ",�󒍃X�e�[�^�X=" + acptAnOdrStatus.ToString("D2");
                    break;
                case 44:
                    logText = ",����`�[�敪=" + slipNo.ToString();
                    break;
                case 45:
                    logText = ",����`�[�ԍ�=" + slipNo.ToString("D9");
                    break;
                case 46:
                    logText = ",����s�ԍ�=" + slipNo.ToString();
                    break;
                case 47:
                    logText = ",������t=" + slipNo.ToString("####/##/##");
                    break;
                case 48:
                    logText = ",���_�R�[�h=" + slipNo.ToString("D2");
                    break;
                case 49:
                    logText = ",���Ӑ�R�[�h=" + slipNo.ToString("D8");
                    break;
                // ----ADD 2013/01/24 ���N�n�� REDMINE#34141---- >>>>>
                case 50:
                    logText = "FUNCTION,�ꊇ�l��(E)";
                    break;
                // ----ADD 2013/01/24 ���N�n�� REDMINE#34141---- <<<<<
                default:
                    break;
            }
            #endregion

            return logText;
        }
        #endregion

        #region ���p�u���b�N ���\�b�h
        /// <summary>
        /// ���O������ێ����郍�O���X�g�ɒǉ�
        /// </summary>
        /// <param name="logNo">���O�ԍ�</param>
        /// <param name="slipNo">�`�[�ԍ��Ȃ�</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : ���O������ێ����郍�O���X�g�ɒǉ�����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/02/11</br> 
        /// </remarks>
        public void AddLine(int logNo, int slipNo, int acptAnOdrStatus)
        {
            // ���O��100���𒴂���ꍇ�́A�ŏ��̂P���R�[�h�����X�g����폜����B
            if (this.logList.Count == 100)
            {
                this.logList.RemoveAt(0);
            }

            // �����I�Ƀ��O�o�͗\��̓��e�̃f�[�^�𐶐�
            LogData logData = new LogData();
            DateTime dt = DateTime.Now;
            logData.SysDateTime = dt.Ticks;                    //����
            logData.LogNo = (byte)logNo;                       //���O�ԍ�
            logData.SalesSlipNo = slipNo;                      //����`�[�ԍ��Ȃ�
            logData.AcptAnOdrStatus = (byte)acptAnOdrStatus;   //�󒍃X�e�[�^�X

            logList.Add(logData);
        }

        /// <summary>
        /// ��ʓ��e���L���v�`�����ē����ێ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʓ��e���L���v�`�����ē����ێ�����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/02/11</br> 
        /// </remarks>
        public void CacheImage()
        {
            // ��ʓ��e�ۑ�
            int count = Screen.AllScreens.Length;
            this._bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width * count, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(this._bmp);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), _bmp.Size);
            g.Dispose();
        }

        /// <summary>
        /// �`�[�o�^�n�j�̃��O�����O���X�g�ɒǉ�
        /// </summary>
        /// <param name="customSerializeArrayList">���ナ�X�g</param>
        /// <remarks>
        /// <br>Note       : �`�[�o�^�n�j�̃��O�����O���X�g�ɒǉ�����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/02/11</br> 
        /// <br>Update Note: 2011/03/07 ������</br>
        /// <br>             Redmine #19637�̑Ή�</br>
        /// </remarks>
        public void Succeed(CustomSerializeArrayList customSerializeArrayList)
        {
            // �`�[�o�^OK�̏ꍇ�A���O�G�[�^�����O���X�g�ɒǉ�����
            SalesSlipWork salesSlipWork = new SalesSlipWork();
            foreach (object obj in customSerializeArrayList)
            {
                if (obj is SalesSlipWork)
                {
                    salesSlipWork = (SalesSlipWork)obj;
                }
                else
                {
                    continue;
                }

                // ���O�G�[�^�����O���X�g�ɒǉ�����
                int salesSlipNum = 0;
                bool isIntFlg = int.TryParse(salesSlipWork.SalesSlipNum, out salesSlipNum);
                if (isIntFlg == false) return;
                this.AddLine(41, salesSlipNum, salesSlipWork.AcptAnOdrStatus);
            }

            // ���O�G�[�^�����O���X�g�ɒǉ��O�A�Q��O�̓`�[�o�^�n�j�̃��O�����O�̃��O�́A���O���X�g����폜����B
            List<LogData> logDateList = new List<LogData>();
            int writeLogNoCount = 0;
            for (int i = this.logList.Count - 1; i >= 0; i--)
            {
                if (i != this.logList.Count - 1)
                {
                    if (writeLogNoCount > 3)
                    {
                        break;
                    }

                    if (logList[i].LogNo == logList[i + 1].LogNo)
                    {
                        logDateList.Add(logList[i]);
                    }

                    if (logList[i].LogNo != logList[i + 1].LogNo && (logList[i].LogNo == 41 || logList[i + 1].LogNo == 41))
                    {
                        writeLogNoCount++;
                        // ---UPD 2011/03/07------------->>>>
                        //logDateList.Add(logList[i]);
                        if (writeLogNoCount != 4)
                        {
                            logDateList.Add(logList[i]);
                        }
                        // ---UPD 2011/03/07-------------<<<<
                    }

                    if (logList[i].LogNo != logList[i + 1].LogNo && logList[i].LogNo != 41 && logList[i + 1].LogNo != 41)
                    {
                        logDateList.Add(logList[i]);
                    }
                }
                else
                {
                    if ((int)logList[i].LogNo == 41)
                    {
                        writeLogNoCount++;
                        logDateList.Add(logList[i]);
                    }
                }
            }
            logDateList.Reverse();
            this.logList = logDateList;

            // CacheImage�Ő�������bmp����j������B
            this._bmp = null;
        }

        /// <summary>
        /// ���O�t�@�C���ƃG���[�f�[�^�t�@�C�����o��
        /// </summary>
        /// <param name="customSerializeArrayList">���ナ�X�g</param>
        /// <remarks>
        /// <br>Note       : ���O�t�@�C���ƃG���[�f�[�^�t�@�C�����o�͂���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/02/11</br> 
        /// <br>Update Note: 2011/03/07 ������</br>
        /// <br>             Redmine #19637�̑Ή�</br>
        /// </remarks>
        public void WriteErrorLog(CustomSerializeArrayList customSerializeArrayList)
        {
            #region ���O���X�g�̓��e�����O�t�@�C��(.txt)�ɏo��
            if (this.dateTime == DateTime.MinValue)
            {
                this.SetDateTime();
            }
            // �t�@�C�����̐���
            string txtFileName = preFileName + this.dateTime.ToString(timeFormat) + txtEndFileName;
            string filePath = Path.GetFullPath(Path.Combine("log", "")); // ADD 2011/03/07
            System.IO.FileStream fs = null; ;										// �t�@�C���X�g���[��
            System.IO.StreamWriter sw = null; ;										// �X�g���[��writer
            string textContent = string.Empty;
            DateTime dt;
            try
            {
                if (Directory.Exists(filePath))
                {
                    // �Ȃ��B
                }
                else
                {
                    Directory.CreateDirectory(filePath);
                }
                filePath = Path.GetFullPath(Path.Combine("log", txtFileName)); // ADD 2011/03/07
                //fs = new FileStream(filePath + txtFileName, FileMode.Append, FileAccess.Write, FileShare.Write); // DEL 2011/03/07
                fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Write); // ADD 2011/03/07
                sw = new System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding("shift_jis"));
                foreach (LogData logData in this.logList)
                {
                    dt = new DateTime(logData.SysDateTime);
                    textContent = dt.ToString("yyyy/MM/dd") + "," + dt.ToString("HH:mm:ss") + "," + GetLogFromLogNo(logData.LogNo, logData.SalesSlipNo, logData.AcptAnOdrStatus);
                    sw.WriteLine(textContent);
                }
            }
            catch
            {
                // �Ȃ��B
            }
            finally
            {
                if (sw != null)
                    sw.Close();
                if (fs != null)
                    fs.Close();
            }
            #endregion

            // �G���[�f�[�^�t�@�C�����o��
            this.OutputErrorDateFile(customSerializeArrayList);

            // ��ʃL���v�`���摜��bmp�t�@�C���ɏo��
            this.OutputBmpFile();
            // ��ʃL���v�`���摜��bmp�t�@�C���ɏo�͂�����A���������bmp����j������B
            this._bmp = null;
        }

        /// <summary>
        /// �V�X�e�����Ԃ����i�t�@�C���������p�j
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�X�e�����Ԃ����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/02/11</br> 
        /// </remarks>
        public void SetDateTime()
        {
            this.dateTime = DateTime.Now;
        }

        /// <summary>
        /// �V�X�e�����Ԃ����i�o�^�O�̃`�F�b�N�p�j
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�X�e�����Ԃ����i�o�^�O�̃`�F�b�N�p�j</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/02/11</br> 
        /// </remarks>
        public DateTime GetDateTime()
        {
            if (this.dateTime == DateTime.MinValue)
            {
                this.SetDateTime();
            }
            return this.dateTime;
        }
        #endregion
    }
}
