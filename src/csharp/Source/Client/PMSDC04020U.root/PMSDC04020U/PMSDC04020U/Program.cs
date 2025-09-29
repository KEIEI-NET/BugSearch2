//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^���M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10901034-00 �쐬�S�� : 杍^
// �� �� ��  K2019/12/02 �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using System.Diagnostics;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �f�[�^���M�������N��
    /// </summary>
    /// <remarks>
    /// <br>Note       : �f�[�^���M�������N��</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : K2019/12/02</br>
    /// </remarks>
    static class Program
    {
        internal static string[] _parameter;						// �N���p�����[�^
        private static System.Windows.Forms.Form _form = null;

        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        /// <param name="args"></param>
        /// <remarks>
        /// <br>Note       : �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/12/02</br>
        /// </remarks>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string msg = "";
                _parameter = args;

                // �A�v���P�[�V�����J�n��������
                // ���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��ł���ꍇ�͖���B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
                int status = ApplicationStartControl.StartApplication(
                    out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length <= 1)
                    {
                        _form = new PMSDC04020UA();
                        System.Windows.Forms.Application.Run(_form);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// �A�v���P�[�V�����I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �A�v���P�[�V�����I���C�x���g</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : K2019/12/02</br>
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //���b�Z�[�W���o���O�ɑS�ĊJ��
            ApplicationStartControl.EndApplication();
            //�A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }
    }
}