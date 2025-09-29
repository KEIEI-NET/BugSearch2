//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ɉꊇ�폜���
// �v���O�����T�v   : �݌Ɉꊇ�폜��ʃG���g���|�C���g
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570249-00  �쐬�S�� : 杍^
// �� �� ��  2020/03/09   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Diagnostics;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �݌Ɉꊇ�폜��ʃ��C���t���[���̃G���g���|�C���g�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �݌Ɉꊇ�폜��ʃ��C���t���[���̃G���g���|�C���g�N���X�B</br>
    /// <br>Programmer	: 杍^</br>
    /// <br>Date		: 2020/03/09</br>
    /// </remarks>
    internal static class Program
    {
        #region <Const/>

        /// <summary>�v���O����ID</summary>
        private const string ProGramId = "PMKHN09770U";
        /// <summary>����</summary>
        private const int NormalStatus = 0;
        /// <summary>�ُ�</summary>
        private const int ErrorStatus = -1;    
        
        #endregion  // <Const/>

        /// <summary>���C���t���[��</summary>
        private static Form MainForm;

        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        /// <param name="args">�R�}���h���C������</param>
        /// <remarks>
        /// <br>Note		: ���O�C���`�F�b�N���s���A���C���t���[���i�t�H�[���j���N�����܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                // ���b�Z�[�W�{�b�N�X��XP�X�^�C��
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

                // �N������
                string msg = string.Empty;
                int status = ApplicationStartControl.StartApplication(
                    out msg,
                    ref args,
                    ConstantManagement_SF_PRO.ProductCode,  // �A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��i�ł��Ȃ��ꍇ�̓v���_�N�g�R�[�h�j
                    new EventHandler(ReleasedApplicationEventHandler)
                );
                if (status.Equals(NormalStatus))
                {
                    if (HasSecurityError(out msg))
                    {
                        ShowDefaultAlert(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, status);
                        return;
                    }
                }
                else
                {
                    ShowDefaultAlert(emErrorLevel.ERR_LEVEL_INFO, msg, status);
                    return;
                }

                // �A�v���P�[�V�����J�n
                MainForm = new PMKHN09770UA();
                System.Windows.Forms.Application.Run(MainForm);
            }
            catch (Exception e)
            {
                Debug.WriteLine("\n" + e.ToString() + "\n");
                ShowDefaultAlert(emErrorLevel.ERR_LEVEL_STOPDISP, e.Message, ErrorStatus);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        #region <����/>

        /// <summary>
        /// �Z�L�����e�B�G���[�����邩���肵�܂��B
        /// </summary>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <returns>
        /// <c>true</c> :�Z�L�����e�B�G���[����<br/>
        /// <c>false</c>:�Z�L�����e�B�G���[�Ȃ�
        /// </returns>
        /// <remarks>
        /// <br>Note		: �Z�L�����e�B�G���[�����邩���肵�܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        private static bool HasSecurityError(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!LoginInfoAcquisition.OnlineFlag)
            {
                errorMessage = "�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B"; // LITERAL:
                return true;
            }
            else
            {
                //�Ȃ�
            }

            return false;
        }

        /// <summary>
        /// �A�v���P�[�V�����I�����̃C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �A�v���P�[�V�����I�����̃C�x���g�n���h���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        private static void ReleasedApplicationEventHandler(
            object sender,
            EventArgs e
        )
        {
            // ���b�Z�[�W���o���O�ɑS�ĊJ��
            ApplicationStartControl.EndApplication();

            // �]�ƈ����O�I�t�̃��b�Z�[�W��\��
            if (MainForm != null)
            {
                TMsgDisp.Show(
                    MainForm.Owner,
                    emErrorLevel.ERR_LEVEL_INFO,
                    ProGramId,
                    e.ToString(),
                    ErrorStatus,
                    MessageBoxButtons.OK
                );
            }
            else
            {
                ShowDefaultAlert(emErrorLevel.ERR_LEVEL_INFO, e.ToString(), ErrorStatus);
            }

            // �A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// �f�t�H���g�̃A���[�g��\�����܂��B
        /// </summary>
        /// <param name="errorLevel">�G���[���x��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="status">��������</param>
        /// <remarks>
        /// <br>Note		: �f�t�H���g�̃A���[�g��\�����܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        public static void ShowDefaultAlert(
            emErrorLevel errorLevel, 
            string message, 
            int status
        )
        {
            TMsgDisp.Show(errorLevel, ProGramId, message, status, MessageBoxButtons.OK);
        }

        #endregion  // <����/>
    }
}