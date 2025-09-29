using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using Microsoft.Win32;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// ���O�o�̓N���X
    /// </summary>
    /// <remarks>
    /// <br>Update Note	: ���O�t�@�C������ύX�iSCMChcker.log��SCMCheker_���t.log)</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2010/03/05</br>
    /// </remarks>
    public static class LogWriter
    {
        public static bool isKillLog = false;

        /// <summary>
        /// ���O�o��(DEBUG)����
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
            if (isKillLog) return;

            string workDir = null;

			#region 2012.04.10 TERASAKA DEL STA
//            // ڼ޽�ط��擾
//            StreamWriter writer = null;                          // �e�L�X�g���O�p
			#endregion
            //>>>2010/07/30
            //RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Product\Partsman");
            //<<<2010/07/30

            if (key == null) // �����Ă͂����Ȃ��P�[�X
            {
                //>>>2010/07/30
                //workDir = @"C:\Program Files\Partsman\USER_AP"; // ���W�X�g���ɏ�񂪂Ȃ����߁A���Ƀf�t�H���g�̃t�H���_��ݒ�
                workDir = @"C:\Program Files\Partsman"; // ���W�X�g���ɏ�񂪂Ȃ����߁A���Ƀf�t�H���g�̃t�H���_��ݒ�
                //<<<2010/07/30
            }
            else
            {
                // ���O��������̫��ގw��
                //>>>2010/07/30
                //workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman").ToString();
                //<<<2010/07/30
            }
            // �J�����g�f�B���N�g���ݒ�
            System.IO.Directory.SetCurrentDirectory(workDir);

            // 2010/03/05 >>>
            //string backupedLog = SimpleLogger.BackupLogIf(workDir + @"\Log\PMCMN06200S\SCMChecker.Log");
            string backupedLog = SimpleLogger.BackupLogIf(workDir + @"\Log\PMCMN06200S\" + string.Format("SCMChecker_{0}.Log", DateTime.Now.ToString("yyyyMMdd")));
            // 2010/03/05 <<<

            System.IO.FileStream _fs;										// �t�@�C���X�g���[��
            System.IO.StreamWriter _sw;										// �X�g���[��writer
            if (string.IsNullOrEmpty(backupedLog))
            {
                // 2010/03/05 >>>
                //_fs = new FileStream(workDir + @"\Log\PMCMN06200S\SCMChecker.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
                _fs = new FileStream(workDir + @"\Log\PMCMN06200S\" + string.Format("SCMChecker_{0}.Log", DateTime.Now.ToString("yyyyMMdd")), FileMode.Append, FileAccess.Write, FileShare.Write);
                // 2010/03/05 <<<
            }
            else
            {
                // 2010/03/05 >>>
                //_fs = new FileStream(workDir + @"\Log\PMCMN06200S\SCMChecker.Log", FileMode.Create, FileAccess.Write, FileShare.Write);
                _fs = new FileStream(workDir + @"\Log\PMCMN06200S\" + string.Format("SCMChecker_{0}.Log", DateTime.Now.ToString("yyyyMMdd")), FileMode.Create, FileAccess.Write, FileShare.Write);
                // 2010/03/05 <<<
            }
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
        }

        /// <summary>�f�o�b�O���O��INI�t�@�C��</summary>
        private const string DEBUG_FILE_INI = "_DEBUG_.ini";

        /// <summary>
        /// �f�o�b�O���O���o�͂��܂��B
        /// </summary>
        /// <param name="author">�M��</param>
        /// <param name="msg">���b�Z�[�W</param>
        public static void WriteDebugLog(
            string author,
            string msg
        )
        {
            //Debug.WriteLine(Environment.CurrentDirectory);
            //if (!File.Exists(DEBUG_FILE_INI)) return;

            string message = "(Debug)" + author + "->";
            message += msg;
            LogWrite(message);
        }
    }
}
