//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : �Z�L�����e�B�Ǘ����C���t���[��
// �v���O�����T�v   : �@�I�y���[�V�������쌠���ݒ�}�X�����Ăяo��
//                  : �A�I�y���[�V�������쌠���ݒ�ꗗ�\���̌Ăяo��
//                  : �B���엚��\���̌Ăяo��
//                  : �C�G���[���O�\���̌Ăяo��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/07/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g��
// �� �� ��  2013/08/09  �C�����e : �^�u���b�g �}�X�^�A�b�v���[�h�Ώۂ̏ꍇ�Ƀ��b�Z�[�W�\��
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// �Z�L�����e�B�Ǘ����C���t���[���̃t�H�[���N���X
	/// </summary>
	public partial class PMKHN09120UA : Form
	{
        #region <�c�[���o�[/>
        
        #region <[����]�c�[���{�^��/>

        /// <summary>[����]�c�[���{�^���̃L�[</summary>
        private const string TOOL_BUTTON_CLOSE_KEY = "Close";
        /// <summary>[����]�c�[���{�^���̃A�C�R���i�C���f�b�N�X�j</summary>
        private const int TOOL_BUTTON_CLOSE_ICON_INDEX = (int)Size16_Index.CLOSE;

        /// <summary>
        /// ����c�[���{�^�����擾���܂��B
        /// </summary>
        /// <value>����c�[���{�^��</value>
        private ButtonTool CloseToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[TOOL_BUTTON_CLOSE_KEY]; }
        }

        #endregion  // <[����]�c�[���{�^��/>

        #region <[�\���X�V]�c�[���{�^��/>

        /// <summary>[�\���X�V]�c�[���{�^���̃L�[</summary>
        private const string TOOL_BUTTON_UPDATE_KEY = "Update";
        /// <summary>[�\���X�V]�c�[���{�^���̃A�C�R���i�C���f�b�N�X�j</summary>
        private const int TOOL_BUTTON_UPDATE_ICON_INDEX = (int)Size16_Index.VIEW;

        /// <summary>
        /// �\���X�V�c�[���{�^�����擾���܂��B
        /// </summary>
        /// <value>�\���X�V�c�[���{�^��</value>
        private ButtonTool UpdateToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[TOOL_BUTTON_UPDATE_KEY]; }
        }

        #endregion  // <[�\���X�V]�c�[���{�^��/>

        #region <[�ۑ�]�c�[���{�^��/>

        /// <summary>�ۑ��c�[���{�^���̃L�[</summary>
        private const string TOOL_BUTTON_SAVE_KEY = "Save";
        /// <summary>�ۑ��c�[���{�^���̃A�C�R���i�C���f�b�N�X�j</summary>
        private const int TOOL_BUTTON_SAVE_ICON_INDEX = (int)Size16_Index.SAVE;

        /// <summary>
        /// �ۑ��c�[���{�^�����擾���܂��B
        /// </summary>
        /// <value>�ۑ��c�[���{�^��</value>
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
                case TOOL_BUTTON_CLOSE_KEY: // [����]
                    {
                        Close();
                        break;
                    }
                case TOOL_BUTTON_UPDATE_KEY:// [�\���X�V]
                    {
                        #region <Guard Phrase/>

                        if (CurrentChildForm == null) break;

                        #endregion  // <Guard Phrase/>

                        CurrentChildForm.UpdateDisplay();
                        break;
                    }
                case TOOL_BUTTON_SAVE_KEY:  // [�ۑ�]
                    {
                        #region <Guard Phrase/>

                        const string TEXT = "�ۑ����܂����H";   // LITERAL:
                        const string CAPTION = "�m�F";          // LITERAL:
                        if (!MessageBox.Show(
                            TEXT, CAPTION,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question).Equals(DialogResult.Yes)
                        ) break;

                        if (CurrentChildForm == null) break;

                        #endregion  // <Guard Phrase/>

                        if (!CurrentChildForm.Write().Equals((int)ResultCode.Normal))
                        {
                            MessageBox.Show(
                                "�ۑ��Ɏ��s���܂����B", // LITERAL:
                                "���Z�L�����e�B�Ǘ���", // LITERAL:
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                        break;
                    }
            }
        }

        #endregion  // <�c�[���o�[/>

        #region <�^�u/>

        /// <summary>�^�u�̃L�[�z��</summary>
        /// <remarks>�^�u��ǉ�����ꍇ�͂����ɒǉ�</remarks>
        private readonly string[] _entryTabKeys = new string[]
        {
            // TODO:�^�u��ǉ�����ꍇ�͂����ɒǉ�
            TabConfig.SECURITY_MANAGEMENT_SETTING_KEY,
            TabConfig.SECURITY_MANAGEMENT_VIEW_KEY,
            TabConfig.OPERATION_LOG_VIEW_KEY,
            TabConfig.ERROR_LOG_VIEW_KEY
        };

        /// <summary>�^�u�\���̃}�b�v</summary>
        private readonly Dictionary<string, TabConfig> _tabConfigMap = new Dictionary<string, TabConfig>();

        /// <summary>
        /// ���݂̎q�t�H�[�����擾���܂��B
        /// </summary>
        /// <value>���݂̎q�t�H�[��</value>
        private ISecurityManagementForm CurrentChildForm
        {
            get { return this._tabConfigMap[this.mainTabControl.ActiveTab.Key].Form as ISecurityManagementForm; }
        }

        /// <summary>
        /// �^�u��SelectedTabChanged�C�x���g�n���h��
        /// </summary>
        /// <remarks>
        /// �I���^�u�ɉ������c�[���o�[������s���܂��B
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void mainTabControl_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
        {
            if (CurrentChildForm != null)
            {
                UpdateToolButton.SharedProps.Visible= CurrentChildForm.CanUpdateDisplay;
                SaveToolButton.SharedProps.Visible  = CurrentChildForm.CanWrite;
            }
            else
            {
                UpdateToolButton.SharedProps.Visible= false;
                SaveToolButton.SharedProps.Visible  = false;
            }

            if (CurrentChildForm is ISecurityManagementForm)
            {
                ((ISecurityManagementForm)CurrentChildForm).Active();
            }

            // ADD �g�� 2013/08/09 �^�u���b�g�A�b�v���[�h���b�Z�[�W�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // �I�v�V�����`�F�b�N
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BasicTablet);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                if (mainTabControl.ActiveTab.Key.Equals(TabConfig.SECURITY_MANAGEMENT_SETTING_KEY)
                    || mainTabControl.ActiveTab.Key.Equals(TabConfig.SECURITY_MANAGEMENT_VIEW_KEY))
                {
                    ultraStatusBar.Panels["Msg"].Visible = true;
                }
                else
                {
                    ultraStatusBar.Panels["Msg"].Visible = false;
                }
            }
            // ADD �g�� 2013/08/09 �^�u���b�g�A�b�v���[�h���b�Z�[�W�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        }

        #endregion  // <�^�u/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMKHN09120UA()
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
        private void PMKHN09120UA_Load(object sender, EventArgs e)
        {
            // ���݂̃J�[�\����ێ�
            Cursor localCursor = Cursor;
			try
			{
                // �J�[�\���������v�ɐݒ�
                Cursor = Cursors.WaitCursor;

				// �c�[���o�[��������
				InitializeToolbar();

                // �^�u��������
                InitializeTab();

                // �C�x���g�n���h����ǉ�
                ISecurityManagementView
                    viewForm = this._tabConfigMap[TabConfig.SECURITY_MANAGEMENT_VIEW_KEY].Form
                        as ISecurityManagementView;
                if (viewForm != null)
                {
                    viewForm.Selected += new GridSelectedEventHandler(this.SecurityManagementViewGridSelected);
                }

                IStatusBarShowable settingForm = this._tabConfigMap[TabConfig.SECURITY_MANAGEMENT_SETTING_KEY].Form
                        as IStatusBarShowable;
                if (settingForm != null)
                {
                    settingForm.ShowStatusBar += new ValueIsInvalidEventHandler(this.ShowStatusBar);
                }
			}
			finally
			{
                // �J�[�\����߂�
                Cursor = localCursor;
			}
		}

        /// <summary>
        /// �Z�L�����e�B�Ǘ����C���t���[����KeyDown�C�x���g�n���h��
        /// </summary>
        /// <remarks>
        /// [Escape]�L�[�������ɏI���������s���܂��B
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void PMKHN09120UA_KeyDown(object sender, KeyEventArgs e)
        {
            #region <Guard Phrase/>
            
            if (!e.KeyCode.Equals(Keys.Escape)) return;

            #endregion  // <Guard Phrase/>

            const string TEXT = "�I�����܂����H";   // LITERAL:
            const string CAPTION = "�m�F";          // LITERAL:
            if (MessageBox.Show(TEXT, CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes)) Close();
        }

        #endregion  // <�t�H�[��/>

        #region <���쌠���ꗗ�\���̃O���b�h���I�����ꂽ�Ƃ��̃C�x���g/>

        /// <summary>
        /// ���쌠���ꗗ�\���̃O���b�h���I�����ꂽ�Ƃ��̃C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�O���b�h�̐e�I�u�W�F�N�g</param>
        /// <param name="operationSt">�I�����ꂽ�s�ɑ΂���I�y���[�V�������</param>
        private void SecurityManagementViewGridSelected(
            object sender,
            OperationSt operationSt
        )
        {
            ISecurityManagementSetting
                settingForm = this._tabConfigMap[TabConfig.SECURITY_MANAGEMENT_SETTING_KEY].Form
                    as ISecurityManagementSetting;
            if (settingForm == null) return;

            this.mainTabControl.SelectedTab = this.mainTabControl.Tabs[TabConfig.SECURITY_MANAGEMENT_SETTING_KEY];

            settingForm.Select(operationSt);
        }

        #endregion  // <���쌠���ꗗ�\���̃O���b�h���I�����ꂽ�Ƃ��̃C�x���g/>

        #region <�c�[���o�[�̍\�z/>

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
            if (LoginInfoAcquisition.Employee != null)
            {
                loginName.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            //--------------------------------------------------------------
            // �W�� �c�[���o�[
            //--------------------------------------------------------------
            // ����c�[���{�^���̃A�C�R���ݒ�
            CloseToolButton.SharedProps.AppearancesSmall.Appearance.Image = TOOL_BUTTON_CLOSE_ICON_INDEX;

            // �\���X�V�c�[���{�^���̃A�C�R���ݒ�
            UpdateToolButton.SharedProps.AppearancesSmall.Appearance.Image = TOOL_BUTTON_UPDATE_ICON_INDEX;

            // �ۑ��c�[���{�^���̃A�C�R���ݒ�
            SaveToolButton.SharedProps.AppearancesSmall.Appearance.Image = TOOL_BUTTON_SAVE_ICON_INDEX;
        }

        #endregion  // <�c�[���o�[�̍\�z/>

        #region <�^�u�̍\�z/>

        /// <summary>
        /// �^�u�����������܂��B
        /// </summary>
        private void InitializeTab()
        {
            // �^�u�ɃC���[�W���X�g��ݒ�
            this.mainTabControl.ImageList = TabConfig.ImageList;

            this._tabConfigMap.Clear();
            foreach (string tabKey in this._entryTabKeys)
            {
                // �^�u�\���}�b�v���\�z
                this._tabConfigMap.Add(tabKey, TabConfig.CreateInstance(tabKey));

                // �^�u�Ɏq�t�H�[����ǉ�
                AddChildFormToTab(this._tabConfigMap[tabKey]);
            }

            // �擪�^�u��I��
            this.mainTabControl.SelectedTab = this.mainTabControl.Tabs[0];
        }

        /// <summary>
        /// �^�u�Ɏq�t�H�[����ǉ����܂��B
        /// </summary>
        /// <param name="config">�^�u�\��</param>
        private void AddChildFormToTab(TabConfig config)
        {
            #region <Guard Phrase/>

            if (config.Form == null) return;

            #endregion  // <Guard Phrase/>

            // �Ή�����t�H�[���R���g���[���̃v���p�e�B��ύX
            config.Form.Name = config.Key;
            config.Form.TopLevel = false;
            config.Form.FormBorderStyle = FormBorderStyle.None;
            config.Form.Dock = DockStyle.Fill;

            // �^�u�y�[�W�R���g���[���̃C���X�^���X�𐶐�
            UltraTabPageControl uTabPageControl = new UltraTabPageControl();
            uTabPageControl.Controls.Add(config.Form);

            // �^�u�̊O�ς�ݒ肵�A�^�u�R���g���[���Ƀ^�u��ǉ�
            UltraTab uTab = new UltraTab();
            uTab.TabPage = uTabPageControl;

            uTab.Key = config.Key;				    // �L�[
            uTab.Text = config.Text;				// �^�C�g��
            uTab.Tag = config.Form;				    // �Ή�����t�H�[���R���g���[��
            uTab.Appearance.Image = config.Icon;    // �A�C�R��

            uTab.Appearance.BackColor = Color.White;
            uTab.Appearance.BackColor2 = Color.Lavender;
            uTab.Appearance.BackGradientStyle = GradientStyle.Vertical;
            uTab.ActiveAppearance.BackColor = Color.White;
            uTab.ActiveAppearance.BackColor2 = Color.LightPink;
            uTab.ActiveAppearance.BackGradientStyle = GradientStyle.Vertical;

            this.mainTabControl.Controls.Add(uTabPageControl);
            this.mainTabControl.Tabs.AddRange(new UltraTab[] { uTab });
            this.mainTabControl.SelectedTab = uTab;

            config.Form.Show();
        }

        #endregion  // <�^�u�̍\�z/>

        #region <�X�e�[�^�X�o�[/>

        /// <summary>
        /// �X�e�[�^�X�o�[�ɕ\������C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ShowStatusBar(
            object sender,
            StatusBarMsg e
        )
        {
            this.ultraStatusBar.Panels["Text"].Text = e.Msg;
        }

        #endregion  // <�X�e�[�^�X�o�[/>
    }
}