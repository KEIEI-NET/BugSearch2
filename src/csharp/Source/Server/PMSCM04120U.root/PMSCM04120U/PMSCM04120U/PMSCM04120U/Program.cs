//****************************************************************************//
// �V�X�e��         : �o�l.�m�r
// �v���O��������   : PM�f�[�^���������N�����
// �v���O�����T�v   : �A�N�Z�X�N���X�̓����������R�[������
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �ђ��}
// �� �� ��  2014/08/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    static class Program
    {
        private static string[] _parameter;						// �N���p�����[�^
        private static System.Windows.Forms.Form _form = null;

        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            try
            {
                string msg = string.Empty;
                _parameter = args;
                string workDir = null;

                // ڼ޽�ط��擾
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
                if (key == null) // �����Ă͂����Ȃ��P�[�X
                {
                    workDir = @"C:\Program Files\Partsman\USER_AP"; // ���W�X�g���ɏ�񂪂Ȃ����߁A���Ƀf�t�H���g�̃t�H���_��ݒ�
                }
                else
                {
                    // �J�����g�t�H���_�̐ݒ�
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }
                System.IO.Directory.SetCurrentDirectory(workDir);
                // �A�v���P�[�V�����J�n��������
                // ���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��ł���ꍇ�͖���B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h                
                int status = ServerApplicationMethodCallControl.StartApplication(
                        out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode);
                DebugLog("�N������:" + status);
                if (status == 0)
                {
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    // �A�N�Z�X�N���X�̓����������R�[�������珈�����I������B
                    _form = new PMSCM04120UA();
                    if (args.Length >= 1 && args[0].Trim() == "/T")
                    {
                        ((PMSCM04120UA)_form).TranslateExecute(); // �����N��������          
                    }
                    else
                    {
                        ((PMSCM04120UA)_form).RegularStart(); // �����N��������          
                    }
                }
            }
            catch (Exception e)
            {
                DebugLog("�G���[����:" + e.Message + "\r\n" + e.StackTrace);
            }
            finally
            {
                DebugLog("�I������");
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// �����p���O
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        static void DebugLog(string message)
        {
            RegistryKey keyForLog = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            string homeDir = keyForLog.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
            StreamWriter writer = null;
            try
            {
                try
                {
                    if (!Directory.Exists(Path.Combine(homeDir, @"Log\PMSCM04120U")))
                    {
                        Directory.CreateDirectory(Path.Combine(homeDir, @"Log\PMSCM04120U"));
                    }
                }
                catch
                {
                }
                DirectoryInfo dir = new DirectoryInfo(Path.Combine(homeDir, @"Log\PMSCM04120U"));
                if (dir.Exists)
                {
                    DateTime deleteTime = DateTime.Now.AddMonths(-1);
                    foreach (FileInfo f in dir.GetFiles())
                    {
                        if (f.LastWriteTime <= deleteTime)
                        {
                            f.Delete();
                        }
                    }
                }
                writer = new StreamWriter(Path.Combine(homeDir, @"Log\PMSCM04120U\" + DateTime.Now.ToString("yyyyMMdd", null) + ".txt"), true);
                writer.WriteLine(string.Format(DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + " : " + message));
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
    }
}