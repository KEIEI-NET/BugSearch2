//****************************************************************************//
// �V�X�e��         : PM.NS                                                   //
// �v���O��������   : ���i�f�[�^�폜���� �t�H�[���N���X                       //
// �v���O�����T�v   : ���i�f�[�^�e�[�u���ɑ΂��č폜�������s��                //
//                    ��V�K�쐬����B                                        //
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.                       //
//============================================================================//
// ����                                                                       //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 3H ������                                 //
// �� �� ��  2017/05/22  �C�����e : �V�K�쐬                                  //
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�f�[�^�폜���� �t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�f�[�^�e�[�u���ɑ΂��č폜�����̃t�H�[���N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date       : 2017/05/22</br>
    /// </remarks>
    static class PMHND00200UB
    {
        private static string[] _parameter;						// �N���p�����[�^
        private static System.Windows.Forms.Form _form = null;

        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        /// <param name="args">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���i�f�[�^�e�[�u���ɑ΂��č폜�����N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/05/22</br>
        /// </remarks>
        [STAThread]
        static void Main(String[] args)
        {
            
            string msg = "";
            _parameter = args;
            string workDir = null;
            string dateTime_yyyyMMdd = DateTime.Now.ToString("yyyyMMdd");

            StreamWriter writer = null; // �e�L�X�g���O�p

            try
            {
                
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

                Directory.CreateDirectory(@"" + workDir + @"\Log\PMHND00200U");

                // ÷��۸ޏ����� (Main())
                writer = new StreamWriter(@"" + workDir + @"\Log\PMHND00200U\RunLog_" + dateTime_yyyyMMdd + ".txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now + " PMHND00200U.exe�@�����J�n " + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();


                // �A�v���P�[�V�����J�n��������
                // ���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��ł���ꍇ�͖���B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
                int status = ServerApplicationMethodCallControl.StartApplication(
                        out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode);

                if (status == 0)
                {
                    // ÷��۸ޏ����� (���������N��)
                    writer = new StreamWriter(@"" + workDir + @"\Log\PMHND00200U\RunLog_" + dateTime_yyyyMMdd + ".txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                    writer.Write(DateTime.Now + " ���O�C�����擾���� " + "\r\n");
                    writer.Flush();
                    if (writer != null) writer.Close();

                    _form = new PMHND00200UA(workDir);
                    string errMsg = string.Empty;
                    ((PMHND00200UA)_form).DeleteData();
                }
                else
                {
                    string parmMsg = "";
                    foreach (string param in _parameter)
                    {
                        parmMsg = param;
                    }


                    // ÷��۸ޏ����� (���������N��)
                    writer = new StreamWriter(@"" + workDir + @"\Log\PMHND00200U\RunLog_" + dateTime_yyyyMMdd + ".txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                    writer.Write(DateTime.Now
                        + " ���O�C�����擾���s " + "\r\n" + "�G���[���b�Z�[�W " + msg + "\r\n"
                        + " �p�����[�^�[ " + parmMsg + "\r\n"
                        + " �v���_�N�g�R�[�h " + ConstantManagement_SF_PRO.ProductCode + "\r\n"
                        + " �X�e�[�^�X" + status + "\r\n");
                    writer.Flush();
                    if (writer != null) writer.Close();
                }
            }
            catch (Exception ex)
            {
                writer = new StreamWriter(@"" + workDir + @"\Log\PMHND00200U\RunLog_" + dateTime_yyyyMMdd + ".txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now
                    + " catch() "
                    + " ���O�C�����擾���s " + "\r\n" + "�G���[���b�Z�[�W " + ex + "\r\n"
                    + " �p�����[�^�[ " + _parameter + "\r\n"
                    + " �v���_�N�g�R�[�h " + ConstantManagement_SF_PRO.ProductCode + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();
            }
            finally
            {
                // ÷��۸ޏ����� (���������N���I��)
                writer = new StreamWriter(@"" + workDir + @"\Log\PMHND00200U\RunLog_" + dateTime_yyyyMMdd + ".txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now + " PMHND00200U.exe�@�����I�� " + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();

                ApplicationStartControl.EndApplication();
            }
        }
       
    }
}