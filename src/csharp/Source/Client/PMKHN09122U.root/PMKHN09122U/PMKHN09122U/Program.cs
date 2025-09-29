//****************************************************************************//
// �V�X�e��         : ���엚��\��
// �v���O��������   : ���엚��\��
// �v���O�����T�v   : �Z�L�����e�B�Ǘ��̑��엚��\���^�G���[���O�\���݂̂Ɍ��肵���Q�Ɨp�o�f
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b
// �� �� ��  2010/02/22  �C�����e : �V�K�쐬
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
    /// ���엚��\�����C���t���[���̃G���g���|�C���g�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : ���엚��\���E���O�\�����s���܂��B</br>
    /// <br>Programmer   : 22018 ��؁@���b</br>
    /// <br>Date         : 2010.02.22</br>
    /// <br></br>
    /// </remarks>

    internal static class Program
    {
        #region <Const/>

        /// <summary>�v���O����ID</summary>
        // --- UPD m.suzuki 2010/02/22 ---------->>>>>
        //private const string PROGRAM_ID = "PMKHN09120";
        private const string PROGRAM_ID = "PMKHN09122";
        // --- UPD m.suzuki 2010/02/22 ----------<<<<<

        /// <summary>����</summary>
        private const int NORMAL_STATUS = 0;
        /// <summary>�ُ�</summary>
        private const int ERROR_STATUS = -1;    // HACK:ApplicationStartControl.StartApplication() �ُ̈�R�[�h

        // --- DEL m.suzuki 2010/02/22 ---------->>>>>
        ///// <summary>�Ǘ��҂�\���l</summary>
        //private const int ADMIN_USER_NO = 1;    // HACK:LoginInfoAcquisition.Employee.UserAdminFlag �̊Ǘ��҃t���O

        ///// <summary>�T�|�[�g��\���l</summary>
        //private const int SUPPORT_USER_NO = 2;    // HACK:LoginInfoAcquisition.Employee.UserAdminFlag �̃T�|�[�g�t���O
        // --- DEL m.suzuki 2010/02/22 ----------<<<<<

        #endregion  // <Const/>

        /// <summary>���C���t���[��</summary>
        private static Form _mainFrameForm;

        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        /// <remarks>
        /// ���O�C���`�F�b�N���s���A���C���t���[���i�t�H�[���j���N�����܂��B
        /// </remarks>
        /// <param name="args">�R�}���h���C������</param>
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
                if (status.Equals(NORMAL_STATUS))
                {
                    if (HasSecurityError(out msg))
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, PROGRAM_ID, msg, status, MessageBoxButtons.OK);
                        return;
                    }
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PROGRAM_ID, msg, status, MessageBoxButtons.OK);
                    return;
                }

                // �A�v���P�[�V�����J�n
                _mainFrameForm = new PMKHN09122UA();
                System.Windows.Forms.Application.Run(_mainFrameForm);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n" + ex.ToString() + "\n");
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PROGRAM_ID, ex.Message, ERROR_STATUS, MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// �Z�L�����e�B�G���[�����邩���肵�܂��B
        /// </summary>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <returns>true :�Z�L�����e�B�G���[����<br/>false:�Z�L�����e�B�G���[�Ȃ�</returns>
        private static bool HasSecurityError(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!LoginInfoAcquisition.OnlineFlag)
            {
                errorMessage = "�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B"; // LITERAL:
                return true;
            }

            // --- DEL m.suzuki 2010/02/22 ---------->>>>>
            //// --- CHG 2009/02/26 ��QID:11960�Ή�------------------------------------------------------>>>>>
            ////if (!LoginInfoAcquisition.Employee.UserAdminFlag.Equals(ADMIN_USER_NO))
            //if ((!LoginInfoAcquisition.Employee.UserAdminFlag.Equals(ADMIN_USER_NO)) &&
            //    (!LoginInfoAcquisition.Employee.UserAdminFlag.Equals(SUPPORT_USER_NO)))
            //// --- CHG 2009/02/26 ��QID:11960�Ή�------------------------------------------------------<<<<<
            //{
            //    errorMessage = "�{�@�\�͊Ǘ��҈ȊO�͎��s�ł��܂���B" + Environment.NewLine + "�I�����܂��B"; // LITERAL:
            //    return true;
            //}
            // --- DEL m.suzuki 2010/02/22 ----------<<<<<

            return false;
        }

        /// <summary>
        /// �A�v���P�[�V�����I�����̃C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private static void ReleasedApplicationEventHandler(
            object sender,
            EventArgs e
        )
        {
            // ���b�Z�[�W���o���O�ɑS�ĊJ��
            ApplicationStartControl.EndApplication();

            // �]�ƈ����O�I�t�̃��b�Z�[�W��\��
            if (_mainFrameForm != null)
            {
                TMsgDisp.Show(
                    _mainFrameForm.Owner,
                    emErrorLevel.ERR_LEVEL_INFO, PROGRAM_ID,
                    e.ToString(),
                    ERROR_STATUS,
                    MessageBoxButtons.OK
                );
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PROGRAM_ID, e.ToString(), ERROR_STATUS, MessageBoxButtons.OK);
            }

            // �A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }
    }
}