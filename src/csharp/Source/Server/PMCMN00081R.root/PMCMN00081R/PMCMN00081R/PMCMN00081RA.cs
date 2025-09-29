using System;
using System.IO;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;

using Microsoft.Win32;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// LSM���O�`�F�b�N���W���[��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : LSM���O�̃`�F�b�N���s���N���X�ł��B</br>
    /// <br>Programmer : �e�c ���V</br>
    /// <br>Date       : 2015/09/24</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public partial class LSMLogCheckDB : RemoteDB, ILSMLogCheckDB
    {
        /// <summary>
        /// LSM���O�`�F�b�N���W���[��DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/09/24</br>
        /// </remarks>
        public LSMLogCheckDB()
        {
        }

        /// <summary>
        /// LSM���O�`�F�b�N
        /// </summary>
        /// <param name="retWorkList">��������</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : LSM���O���`�F�b�N���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/09/24</br>
        /// </remarks>
        public int CheckLSMLog(out object retWorkList, out string machineName, object lsmChkWordWorkList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            machineName = Environment.MachineName;
            retWorkList = null;

            try
            {
                status = CheckLSMLogProc(out retWorkList, lsmChkWordWorkList);
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog(ex, "LSMLogCheckDB.CheckLSMLog Exception=" + ex.Message);
                retWorkList = new CustomSerializeArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        /// <summary>
        /// LSM���O�`�F�b�N
        /// </summary>
        /// <param name="retWorkList"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private int CheckLSMLogProc(out object retWorkList, object lsmChkWordWorkList)
        {
            string lsmLogDir = string.Empty;   // LSM���O�f�B���N�g���i�[
            string lsmLogFile = string.Empty;  // �t�@�C�����i�[
            string lsmLogFileName = "LSMService_Log.txt";

            ArrayList msgList = new ArrayList();

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            retWorkList = null;

            CustomSerializeArrayList retList = new CustomSerializeArrayList();  // ���o����(�S��)

            try
            {

                // LSM���O�f�B���N�g���擾
                status = GetLSMLogDir(out lsmLogDir, out msgList);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    lsmLogFile = Path.Combine(lsmLogDir, lsmLogFileName);

                    // LSM���O�t�@�C���̃`�F�b�N����
                    status = CheckLSMLogFile(lsmLogFile, out msgList, lsmChkWordWorkList);
                }

                retWorkList = msgList;
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog(ex, "LSMLogCheckDB.CheckLSMLogProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// LSM���O�f�B���N�g���擾
        /// </summary>
        /// <param name="lsmLogDir">LSM���O�f�B���N�g��</param>
        /// <param name="msgList">���b�Z�[�W���X�g</param>
        /// <returns>���ʃX�e�[�^�X�i0:����A�ȊO�F�G���[</returns>
        private int GetLSMLogDir(out string lsmLogDir, out ArrayList msgList)
        {
            // LSM�C���X�g�[���f�B���N�g���擾���Ɏg�p���郌�W�X�g���L�[��
            string keyName = @"SOFTWARE\Broadleaf\Service\PMC\LSM";
            // LSM�C���X�g�[���f�B���N�g���擾���Ɏg�p���郌�W�X�g��������
            string valueName = "InstallDirectory";
            // LSM���O�t�@�C���擾���Ɏg�p����LOG�t�H���_��
            string logDir = @"Log\";
            string lsmLogDateTimeFmt = "yyyy/MM/dd HH:mm:ss.fff";

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            string _now = DateTime.Now.ToString(lsmLogDateTimeFmt);

            // ������
            lsmLogDir = string.Empty;
            msgList = new ArrayList();

            // ���W�X�g�����LSM�C���X�g�[���f�B���N�g���擾
            RegistryKey regKey = null;
            try
            {
                regKey = Registry.LocalMachine.OpenSubKey(keyName);

                if (regKey != null)
                {
                    // ���W�X�g���̒l���擾
                    string regValue = (string)regKey.GetValue(valueName, "").ToString().Trim();

                    if (regValue != "")
                    {
                        // �f�B���N�g�����݃`�F�b�N
                        if (Directory.Exists(regValue))
                        {
                            // LSM���O�f�B���N�g���Ƃ��ĕێ�����
                            lsmLogDir = Path.Combine(regValue, logDir);
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;  // ����
                        }
                        else
                        {
                            // �t�H���_�����݂��Ȃ��ꍇ
                            msgList.Add(_now + " LSM�̃C���X�g�[���f�B���N�g�������݂��܂���B");
                        }
                    }
                    else
                    {
                        // ���W�X�g���Ƀf�B���N�g�����ݒ肳��Ă��Ȃ��ꍇ
                        msgList.Add(_now + " LSM�̃f�B���N�g�����ݒ肳��Ă��܂���B");
                    }
                }
                else
                {
                    // ���W�X�g�������݂��Ȃ��ꍇ
                    msgList.Add(_now + " LSM�̃��W�X�g�����擾�ł��܂���B");
                }
            }
            catch (NullReferenceException)
            {
                // �����񂪑��݂��Ȃ��ꍇ�A�C�x���g���O�o��
                msgList.Add(_now + " LSM�̃��W�X�g����񂪕s�����Ă��܂��B");
            }
            catch (Exception ex)
            {
                // ��O
                msgList.Add(_now + " " + ex.Message);
            }
            finally
            {
                if (regKey != null)
                {
                    regKey.Close();
                }
            }
            return status;
        }

        /// <summary>
        /// LSM���O�t�@�C���`�F�b�N����
        /// </summary>
        /// <param name="lsmLogFile">LSM���O�t�@�C��</param>
        /// <returns>���ʃX�e�[�^�X�i0:����A�ȊO�F�G���[</returns>
        private int CheckLSMLogFile(string lsmLogFile, out ArrayList msgList, object lsmChkWordWorkList)
        {
            string lsmLogDateTimeFmt = "yyyy/MM/dd HH:mm:ss.fff";
            DateTime checkTimeTo = DateTime.Now;
            DateTime checkTimeFm = checkTimeTo.AddHours(-1);
            string _now = DateTime.Now.ToString(lsmLogDateTimeFmt);
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ������
            msgList = new ArrayList();

            // LSM���O�t�@�C�������݂��Ȃ��ꍇ
            if (File.Exists(lsmLogFile) == false)
            {
                // �t�H���_�����݂��Ȃ��ꍇ
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                msgList.Add(_now + " LSM���O�t�@�C��(LSMService_Log.txt)�����݂��܂���B");
                return status;
            }

            try
            {
                FileStream fs = null;                                           // filestream
                StreamReader reader = null;                                     // streamreader
                string line = string.Empty;                                     // LSM���O�t�@�C���@�s�P�ʂŊi�[
                int dateTimeLength = string.Format(lsmLogDateTimeFmt).Length;   // �ϊ��O�̓��t�����t�H�[�}�b�g�̕������擾
                bool cheackFlg = false;     // True:�Ώۃf�[�^�L��@False:�Ώۃf�[�^����

                try
                {
                    fs = new FileStream(lsmLogFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);  // �t�@�C���I�[�v��
                    reader = new StreamReader(fs, Encoding.UTF8);

                    while ((line = reader.ReadLine()) != null)
                    {
                        // ���t�����t�H�[�}�b�g�ύX
                        if (line.Length >= dateTimeLength)  // �������ȏ㑶�݂����ꍇ�̂ݕϊ��\
                        {
                            DateTime dtLog;
                            string lsmLogDateTime = line.Substring(0, dateTimeLength);
                            if (DateTime.TryParse(lsmLogDateTime, out dtLog))   // ���t�����ɕϊ��\�ȏꍇ�̂ݑΏ�
                            {
                                if ((dtLog >= checkTimeFm) && (dtLog <= checkTimeTo))   // �͈͓��̂ݑΏ�
                                {
                                    cheackFlg = true;   // �Ώۃf�[�^�L��

                                    // �`�F�b�N
                                    ArrayList _lsmChkWordWorkList = new ArrayList();
                                    _lsmChkWordWorkList = (ArrayList)lsmChkWordWorkList;
                                    foreach (LsmChkWordWork newDtlWork in _lsmChkWordWorkList)
                                    {
                                        if (0 <= line.IndexOf(newDtlWork.Massage))
                                        {
                                            msgList.Add(line);
                                            status = newDtlWork.Status;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }


                    if (cheackFlg == true)
                    {
                       // �Ώۃf�[�^�L��
                       if (msgList.Count == 0)
                       {
                           // �Ώۃ��b�Z�[�W����
                           msgList.Add(_now + " LSM�T�[�r�X�ɂăA�b�v�f�[�g�������s���Ă���\��������܂��B\r\n���΂炭���Ԃ������Ă���ēx���s���Ă��������B");
                           status = (int)ConstantManagement.MethodResult.ctFNC_WARNING;
                           return status;
                       }
                    }
                    else
                    {
                       // �Ώۃf�[�^����
                       msgList.Add(_now + " LSM�T�[�r�X�Ɉُ킪�������Ă���\��������܂��B");
                       status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                       return status;
                    }
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                msgList.Add(_now + " CheckLSMLogFile:" + ex.Message);
                status = -1;
            }
            return status;
        }
    }
}
