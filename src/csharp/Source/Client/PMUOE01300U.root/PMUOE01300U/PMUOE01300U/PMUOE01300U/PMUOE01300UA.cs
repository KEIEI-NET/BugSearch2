//****************************************************************************//
// �V�X�e��         : �����d����M����
// �v���O��������   : �����d����M�������C���t���[��
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/11/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2009/10/09  �C�����e : ��M�̊Y���f�[�^�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024  ���X�� �� 
// �� �� ��  2010/10/19  �C�����e : EXE�̃A�C�R���̕ύX(MANTIS[0016443])
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Exception;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
    using LoginWorkerAcs = SingletonPolicy<LoginWorker>;

	/// <summary>
    /// �����d����M�������C���t���[���t�H�[��
	/// </summary>
	public partial class PMUOE01300UA : Form
    {
        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMUOE01300UA()
        {
            #region <Designer Code/>

            InitializeComponent();

            #endregion  // <Designer Code/>
        }

        #endregion  // <Constructor/>

        #region <�t�H�[��/>

        /// <summary>
		/// �Z�L�����e�B�Ǘ����C���t���[����Load�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�C�x���g�\�[�X</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
        private void PMUOE01300UA_Load(object sender, EventArgs e)
        {
            // ���݂̃J�[�\����ێ�
            Cursor localCursor = Cursor;
            try
            {
                // �J�[�\���������v�ɐݒ�
                Cursor = Cursors.WaitCursor;

                // �c�[���o�[��������
                InitializeToolbar();

                // View��������
                this.oroshishoStockReceptionView.Initialize();

                // UOE�����悪���݂��Ȃ��ꍇ�A�����͍s���Ȃ�
                if (!this.oroshishoStockReceptionView.ExistsUOESupplier)
                {
                    SaveToolButton.SharedProps.Enabled = false;
                }

                // �i���\���p�̃C�x���g��ݒ�
                this.oroshishoStockReceptionView.UpdateProgress += this.UpdateProgress;
            }
            catch (OroshishoStockReceptionException ex)
            {
                Program.ShowDefaultAlert(emErrorLevel.ERR_LEVEL_EXCLAMATION, ex.Message, ex.Status);
            }
			finally
			{
                // �J�[�\����߂�
                Cursor = localCursor;
			}
		}

        /// <summary>
        /// �����d����M�������C���t���[����KeyDown�C�x���g�n���h��
        /// </summary>
        /// <remarks>
        /// [Escape]�L�[�������ɏI���������s���܂��B
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void PMUOE01300UA_KeyDown(object sender, KeyEventArgs e)
        {
            #region <Guard Phrase/>
            
            if (!e.KeyCode.Equals(Keys.Escape)) return;

            #endregion  // <Guard Phrase/>

            const string TEXT = "�I�����܂����H";   // LITERAL:
            const string CAPTION = "�m�F";          // LITERAL:
            if (MessageBox.Show(TEXT, CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
            {
                Close();
            }
        }

        #endregion  // <�t�H�[��/>

        #region <�c�[���o�[/>

        #region <[�I��]�c�[���{�^��/>

        /// <summary>[�I��]�c�[���{�^���̃L�[</summary>
        private const string TOOL_BUTTON_CLOSE_KEY = "Close";
        /// <summary>[�I��]�c�[���{�^���̃A�C�R���i�C���f�b�N�X�j</summary>
        private const int TOOL_BUTTON_CLOSE_ICON_INDEX = (int)Size16_Index.CLOSE;

        /// <summary>
        /// [�I��]�c�[���{�^�����擾���܂��B
        /// </summary>
        /// <value>����c�[���{�^��</value>
        private ButtonTool CloseToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[TOOL_BUTTON_CLOSE_KEY]; }
        }

        #endregion  // <[�I��]�c�[���{�^��/>

        #region <[�m��]�c�[���{�^��/>

        /// <summary>[�m��]�c�[���{�^���̃L�[</summary>
        private const string TOOL_BUTTON_SAVE_KEY = "Save";
        /// <summary>[�m��]�c�[���{�^���̃A�C�R���i�C���f�b�N�X�j</summary>
        private const int TOOL_BUTTON_SAVE_ICON_INDEX = (int)Size16_Index.SAVE;

        /// <summary>
        /// [�m��]�c�[���{�^�����擾���܂��B
        /// </summary>
        /// <value>[�m��]�c�[���{�^��</value>
        private ButtonTool SaveToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[TOOL_BUTTON_SAVE_KEY]; }
        }

        #endregion

        /// <summary>
        /// �c�[���o�[��ToolClick�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void mainToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case TOOL_BUTTON_CLOSE_KEY: // [�I��]
                {
                    Close();
                    break;
                }
                case TOOL_BUTTON_SAVE_KEY:  // [�m��]
                {
                    const string TEXT = "�d����M���������s���܂����H"; // LITERAL:
                    const string CAPTION = "�m�F";                      // LITERAL:
                    if (!MessageBox.Show(TEXT, CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes)) break;
                    SetStatusBarText(string.Empty);
                    this.Update();

                    // [�m��]�c�[���{�^�����N���b�N
                    // 2009/10/09 >>>
                    //int resultCode = this.oroshishoStockReceptionView.Execute();
                    Result.ProcessID processID;
                    int resultCode = this.oroshishoStockReceptionView.Execute(out processID);
                    // 2009/10/09 <<<
                    if (
                        !resultCode.Equals((int)Result.Code.Normal)
                            &&
                        !resultCode.Equals((int)Result.Code.Abort)  // ���Ƀ��b�Z�[�W���o�͍ς�
                    )
                    {
                        // TODO:�G���[���b�Z�[�W�̐ݒ�ӏ�
                        // 2009/10/09 >>>
                        //string msg = Result.ToErrorMessage(resultCode);
                        string msg = Result.ToErrorMessage(resultCode, processID);
                        // 2009/10/09 <<<
                        MessageBox.Show(
                            msg,
                            "�������d����M������", 
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    SetStatusBarText(string.Empty);
                    break;
                }
            }
        }

        /// <summary>
        /// �c�[���o�[�����������܂��B
        /// </summary>
        private void InitializeToolbar()
        {
            // �C���[�W���X�g��ݒ肷��
            this.mainToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

            //--------------------------------------------------------------
            // ���C�� �c�[���o�[
            //--------------------------------------------------------------
            // ���O�C���S���҂̃A�C�R���ݒ�
            LabelTool loginEmployeeLabel = (LabelTool)this.mainToolbarsManager.Tools["LOGINTITLE"];
            loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // ���O�C����
            LabelTool loginName = (LabelTool)this.mainToolbarsManager.Tools["LoginName_LabelTool"];
            if (LoginWorkerAcs.Instance.Policy.Profile != null)
            {
                loginName.SharedProps.Caption = LoginWorkerAcs.Instance.Policy.Profile.Name;
            }

            //--------------------------------------------------------------
            // �W�� �c�[���o�[
            //--------------------------------------------------------------
            // ����c�[���{�^���̃A�C�R���ݒ�
            CloseToolButton.SharedProps.AppearancesSmall.Appearance.Image = TOOL_BUTTON_CLOSE_ICON_INDEX;

            // �ۑ��c�[���{�^���̃A�C�R���ݒ�
            SaveToolButton.SharedProps.AppearancesSmall.Appearance.Image = TOOL_BUTTON_SAVE_ICON_INDEX;
        }

        #endregion  // <�c�[���o�[/>

        #region <�X�e�[�^�X�o�[/>

        /// <summary>
        /// �X�e�[�^�X�o�[�̃e�L�X�g��ݒ肵�܂��B
        /// </summary>
        /// <param name="text">�e�L�X�g</param>
        private void SetStatusBarText(string text)
        {
            this.ultraStatusBar.Panels["Text"].Text = text;
        }

        /// <summary>
        /// �i�����X�V���܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void UpdateProgress(
            object sender,
            UpdateProgressEventArgs e
        )
        {
            SetStatusBarText(e.ToString());
            this.Update();
        }

        #endregion  // <�X�e�[�^�X�o�[/>
    }
}