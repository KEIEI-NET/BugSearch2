//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌ɗ������݌ɐ��ݒ�
// �v���O�����T�v   : �݌Ƀ}�X�^�̌��݌ɐ������ɁA�݌ɗ����f�[�^�̐��������݌ɐ����Čv�Z���X�V����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/12/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �݌ɗ������݌ɐ��ݒ�
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ȃ�</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009/12/24</br>
    /// </remarks>
    static class Program
    {
        // �N���p�����[�^
        private static string[] _parameter;
        private static Form _form = null;

        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        [STAThread]
        static void Main(String[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

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
                    // �I�����C����Ԕ��f
                    if (!LoginInfoAcquisition.OnlineFlag)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMZAI09150U",
                            "�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        _form = new PMZAI09150UA();
                        System.Windows.Forms.Application.Run(_form);
                    }
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMZAI09150U", msg, 0, MessageBoxButtons.OK);
                }
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// �A�v���P�[�V�����I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>		
        /// <br>Note		: �A�v���P�[�V�����I���C�x���g���s���B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            // ���b�Z�[�W���o���O�ɑS�ĊJ��
            ApplicationStartControl.EndApplication();

            // �]�ƈ����O�I�t�̃��b�Z�[�W��\��
            if (_form != null)
            {
                TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "PMZAI09150U", e.ToString(), 0, MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "PMZAI09150U", e.ToString(), 0, MessageBoxButtons.OK);
            }

            // �A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }
    }
}
