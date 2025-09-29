using System;
using System.IO;
using System.Reflection;
using System.Text;

using Microsoft.Win32;

using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Batch
{
    /// <summary>
    /// LSM���O�t�@�C������N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : LSM���O�t�@�C����ϊ���CLC���O�f�B���N�g���ɕۑ����܂��B</br>
    /// <br>Programmer : ���X�� �j</br>
    /// <br>Date       : 2015/05/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class LSMLogFileControl
    {

        /// <summary>
        /// �C�x���g���O�o�͎��Ɏg�p����N���X��
        /// </summary>
        const string cClassName = "PMCMN00071U";

        /// <summary>
        /// LSM�C���X�g�[���f�B���N�g���擾���Ɏg�p���郌�W�X�g���L�[��
        /// </summary>
        /// <remarks>
        /// ���W�X�g���L�[�FHKEY_LOCAL_MACHINE\SOFTWARE\Broadleaf\Service\PMC\LSM
        /// </remarks>
        const string cKeyName = @"SOFTWARE\Broadleaf\Service\PMC\LSM";

        /// <summary>
        /// LSM�C���X�g�[���f�B���N�g���擾���Ɏg�p���郌�W�X�g��������
        /// </summary>
        /// <remarks>
        /// ���W�X�g��������FInstallDirectory
        /// <br>�l�FC:\Program Files\LSM\</br>
        /// </remarks>
        const string cValueName = "InstallDirectory";

        /// <summary>
        /// LSM���O�t�@�C���擾���Ɏg�p����LOG�t�H���_��
        /// </summary>
        /// <remarks>
        /// LOG�t�H���_���FLog\
        /// <br>CLC�pLSM���O�t�@�C���쐬���ɂ��g�p</br>
        /// </remarks>
        const string cLogDir = @"Log\";

        /// <summary>
        /// CLC�pLSM���O�t�@�C���쐬���Ɏg�p����CLC�pLSM���O�t�@�C���̊g���q
        /// </summary>
        /// <remarks>
        /// �g���q�Fclc
        /// </remarks>
        const string cCLCLogFileExt = "clc";

        /// <summary>
        /// LSM���O�t�@�C�����̓��t�����t�H�[�}�b�g��`
        /// </summary>
        /// <remarks>
        /// CLC�pLSM���O�t�@�C���쐬���ɓ��t�������̒����𔻒肷��ׂɎg�p
        /// <br>�t�H�[�}�b�g��`�Fyyyy/MM/dd HH:mm:ss.fff</br>
        /// </remarks>
        const string cLsmLogDateTimeFmt = "yyyy/MM/dd HH:mm:ss.fff";

        /// <summary>
        /// CLC�pLSM���O�t�@�C���̓��t�����t�H�[�}�b�g��`
        /// </summary>
        /// <remarks>
        /// CLC�pLSM���O�t�@�C���쐬���ɓ��t�����t�H�[�}�b�g�ɕϊ�����ׂɎg�p
        /// <br>�t�H�[�}�b�g��`�FMM/dd HH:mm:ss</br>
        /// </remarks>
        const string cLsmToCLCLogDateTimeFmt = "MM/dd HH:mm:ss";

        /// <summary>
        /// CLC�pLSM���O�t�@�C���쐬�Ώۂ̃t�@�C�������X�g
        /// </summary>
        /// <remarks>
        /// CLC�p��LSM���O�t�@�C����ǉ��ō쐬����ۂ͂��̃��X�g�ɒǉ�����
        /// <br>BAUClient_Log.txt</br>
        /// <br>LSMService_Log.txt</br>
        /// </remarks>
        static readonly string[] cLSMLogFile = { "BAUClient_Log.txt", 
                                                 "LSMService_Log.txt" };

        /// <summary>
        /// CLC�pLSM���O�t�@�C���̕�����
        /// </summary>
        /// <remarks>
        /// CLC-Tbl_LogHeader ErrorMessage�Ɋi�[�ł��镶�����F4000����
        /// </remarks>
        const int cCLCLogFileWordCount = 4000;

        /// <summary>
        /// CLC�pLSM���O�t�@�C���R�s�[���C������
        /// </summary>
        public void CopyLSMToCLCLogFileMain()
        {
            string lsmLogDir = string.Empty;   // LSM���O�f�B���N�g���i�[
            string lsmLogFile = string.Empty;  // CLC�o�^�p�t�@�C�����i�[

            // LSM���O�f�B���N�g���擾
            int status = GetLSMLogDir(out lsmLogDir);
            if (status == 0)
            {
                for (int i = 0; i < cLSMLogFile.Length; i++)
                {
                    lsmLogFile = Path.Combine(lsmLogDir, cLSMLogFile[i]);
                    // CLC�pLSM���O�t�@�C���̍쐬
                    status = GetLSMToCLCLogFile(lsmLogFile);
                    if (status == 0)
                    {
                        // CLC�T�[�o�[�A�b�v���[�h�f�B���N�g���փR�s�[
                        CopyLSMToCLCLogFile(lsmLogFile);
                    }
                }
            }
        }

        /// <summary>
        /// LSM���O�f�B���N�g���擾
        /// </summary>
        /// <param name="lsmLogDir">LSM���O�f�B���N�g��</param>
        /// <returns>���ʃX�e�[�^�X�i0:����A�ȊO�F�G���[</returns>
        protected int GetLSMLogDir(out string lsmLogDir)
        {
            int status = -1;  // �G���[

            // ������
            lsmLogDir = string.Empty;

            // ���W�X�g�����LSM�C���X�g�[���f�B���N�g���擾
            RegistryKey regKey = null;
            try
            {
                regKey = Registry.LocalMachine.OpenSubKey(cKeyName);

                if (regKey != null)
                {
                    // ���W�X�g���̒l���擾
                    string regValue = (string)regKey.GetValue(cValueName, "").ToString().Trim();

                    if (regValue != "")
                    {
                        // �f�B���N�g�����݃`�F�b�N
                        if (Directory.Exists(regValue))
                        {
                            // LSM���O�f�B���N�g���Ƃ��ĕێ�����
                            lsmLogDir = Path.Combine(regValue, cLogDir);
                            status = 0;  // ����
                        }
                        else
                        {
                            // �t�H���_�����݂��Ȃ��ꍇ�A�C�x���g���O�ɏo��
                            EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("�C���X�g�[���f�B���N�g�������݂��܂���B"));
                        }
                    }
                    else
                    {
                        // ���W�X�g���Ƀf�B���N�g�����ݒ肳��Ă��Ȃ��ꍇ�A�C�x���g���O�o��
                        EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("�f�B���N�g�����ݒ肳��Ă��܂���B"));
                    }
                }
                else
                {
                    // ���W�X�g�������݂��Ȃ��ꍇ�A�C�x���g���O�o��
                    EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("���W�X�g�����擾�ł��܂���B"));
                }
            }
            catch (NullReferenceException)
            {
                // �����񂪑��݂��Ȃ��ꍇ�A�C�x���g���O�o��
                EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("���W�X�g����񂪕s�����Ă��܂��B"));
            }
            catch (Exception ex)
            {
                EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("���O�̃R�s�[�Ɏ��s���܂����B Exception:[{0}]", ex.Message));
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
        /// CLC�o�^�pLSM���O�t�@�C���쐬
        /// </summary>
        /// <param name="lsmLogFile">LSM���O�t�@�C��</param>
        /// <returns>���ʃX�e�[�^�X�i0:����A�ȊO�F�G���[</returns>
        protected int GetLSMToCLCLogFile(string lsmLogFile)
        {
            int status = 0;  // ����

            // LSM���O�t�@�C�������݂��Ȃ��ꍇ
            if (File.Exists(lsmLogFile) == false)
            {
                return status;
            }

            try
            {
                StringBuilder buffer = new StringBuilder(1024 * 4 * 4);         // CLC�o�^�pLSM���O�t�@�C���̕����i�[�i4000���� 1���� 4�o�C�g���j
                FileStream fs = null;                                           // filestream
                StreamReader reader = null;                                     // streamreader
                string line = string.Empty;                                     // LSM���O�t�@�C���@�s�P�ʂŊi�[
                int charLength = -1;                                            // CLC�o�^�pLSM���O�t�@�C���������i�[
                int dateTimeLength = string.Format(cLsmLogDateTimeFmt).Length;  // �ϊ��O�̓��t�����t�H�[�}�b�g�̕������擾
                try
                {
                    fs = new FileStream(lsmLogFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);  // �t�@�C���I�[�v��
                    reader = new StreamReader(fs, Encoding.UTF8);
                    while ((line = reader.ReadLine()) != null)
                    {
                        // ���t�����t�H�[�}�b�g�ύX
                        if (line.Length >= dateTimeLength)                  // �������ȏ㑶�݂����ꍇ�̂ݕϊ��\
                        {
                            DateTime dt;
                            string lsmLogDateTime = line.Substring(0, dateTimeLength);
                            if (DateTime.TryParse(lsmLogDateTime, out dt))       // ���t�����ɕϊ��\�ȏꍇ�̂ݑΏ�
                            {
                                // �ϊ���̓��t�����ɒu�������i�[����
                                buffer.Append(dt.ToString(cLsmToCLCLogDateTimeFmt)).AppendLine(line.Substring(dateTimeLength));
                            }
                            else
                            {
                                // �ϊ������ɂ��̂܂܊i�[
                                buffer.AppendLine(line);
                            }
                        }
                        else
                        {
                            // ��̍s�͊܂߂Ȃ�
                            if (line.Length != 0)
                            {
                                // �ϊ������ɂ��̂܂܊i�[
                                buffer.AppendLine(line);
                            }
                        }

                        // 4000�����𒴂����ꍇ�A�擪�s����s�폜����
                        // ���������m�F
                        charLength = buffer.Length;
                        while (charLength > cCLCLogFileWordCount)
                        {
                            // �擪�����񂩂���s�܂ł̕�����
                            int endPos = buffer.ToString().IndexOf(Environment.NewLine) + Environment.NewLine.Length;

                            // ���s������ �܂��́@4000�����ȏ���J�b�g����ꍇ�̓I�[�o�[�������������폜����B
                            endPos = ((endPos <= 0) | (endPos >= cCLCLogFileWordCount)) ? (charLength - cCLCLogFileWordCount) : endPos;

                            // �擪����������s�܂ō폜
                            buffer.Remove(0, endPos);
                            // ���������m�F
                            charLength = buffer.Length;
                        }
                    }
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Dispose();
                    }
                }

                // �������݉\�ȕ��������݂���ꍇ
                if (buffer.Length != 0)
                {
                    // LSM���O�t�H���_��CLC���O�t�@�C�����쐬
                    // �g���q��CLC�ɕύX
                    string clcLogFileName = Path.ChangeExtension(lsmLogFile, cCLCLogFileExt);
                    StreamWriter writer = null;
                    try
                    {
                        writer = new StreamWriter(clcLogFileName, false, Encoding.UTF8);
                        writer.Write(buffer);
                    }
                    finally
                    {
                        if (writer != null)
                        {
                            writer.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("���O�̃R�s�[�Ɏ��s���܂����B Exception:[{0}]", ex.Message));
                status = -1;
            }
            return status;
        }

        /// <summary>
        /// CLC�T�[�o�[�A�b�v���[�h�f�B���N�g���R�s�[����
        /// </summary>
        /// <param name="sFile">LSM���O�t�@�C��</param>
        protected void CopyLSMToCLCLogFile(string lsmLogFile)
        {
            try
            {
                string clcLogFileName = Path.ChangeExtension(lsmLogFile, cCLCLogFileExt);

                // CLC�pLSM���O�t�@�C�������݂��Ȃ��ꍇ
                if (File.Exists(clcLogFileName) == false)
                {
                    return;
                }

                // CLC���O�t�@�C����CLC�A�b�v���[�h�f�B���N�g���ɕۑ�
                CLCLogTextOut clcLogTextOut = new CLCLogTextOut();
                int status = clcLogTextOut.CopyClcLogFile(clcLogFileName);
                switch (status)
                {
                    case 0:  // ����I��
                        break;
                    case 4:
                        // �R�s�[���t�@�C�������݂��Ȃ��ꍇ�A�C�x���g���O�o��
                        EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("CLC�pLSM���O�t�@�C�������݂��܂���BST:[{0}] [{1}]", status, lsmLogFile));
                        break;
                    case 9:
                        // �R�s�[���s�����i�Ώۃt�H���_�A�t�@�C���ɏo�͌��������݂��Ȃ��j�ꍇ�A�C�x���g���O�o��
                        EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("CLC�pLSM���O�t�@�C���̃R�s�[�Ɏ��s���܂����BST:[{0}] [{1}]", status, lsmLogFile));
                        break;
                    case -1:
                        // ��O�G���[�̏ꍇ�A�C�x���g���O�o��
                        EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("CLC�pLSM���O�t�@�C���̃R�s�[�ŗ�O�G���[���������܂����BST:[{0}] [{1}]", status, lsmLogFile));
                        break;
                    default:
                        // ���̑��̃G���[�̏ꍇ�A�C�x���g���O�o��
                        EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("CLC�pLSM���O�t�@�C���̃R�s�[�ŃG���[���������܂����BST:[{0}] [{1}]", status, lsmLogFile));
                        break;
                }
            }
            catch (Exception ex)
            {
                EventLogControl.SetEventLogOut(cClassName, MethodBase.GetCurrentMethod().Name, string.Format("���O�̃R�s�[�Ɏ��s���܂����B Exception:[{0}]", ex.Message));
            }
        }
    }
}
