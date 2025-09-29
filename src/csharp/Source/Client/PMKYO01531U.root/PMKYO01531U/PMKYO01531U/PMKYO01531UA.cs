//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�U�[�K�C�h�}�X�^�i�̔��敪�j���o�������
// �v���O�����T�v   : ���[�U�[�K�C�h�}�X�^�i�̔��敪�j���o�����̐ݒ�E�Q�Ə������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI�� ���j
// �� �� ��   2012.07.26 �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���[�U�[�K�C�h�}�X�^�i�̔��敪�j���o������ʃt�H�[���N���X
    /// </summary>
    /// <remarks>
    /// Note       : ���[�U�[�K�C�h�}�X�^�i�̔��敪�j���o�����̐ݒ�E�Q�Ə����ł��B<br />
    /// Programmer : FSI�� ���j<br />
    /// Date       : 2012.07.26<br />
    /// </remarks>
    public partial class PMKYO01531UA : Form
    {

        #region �� Const Memebers ��

        private const string PROGRAM_ID = "PMKYO01531UA";
        
        #endregion �� Const Memebers ��

        # region �� Private field ��

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        // ���[�U�[�K�C�h�A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs;

        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginEmplooyCode = LoginInfoAcquisition.Employee.EmployeeCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

        # endregion �� Private field ��

        #region �� Public Memebers ��
        /// <summary>
        /// 1:�V�K���[�h 2:�Q�ƃ��[�h
        /// </summary>
        public int Mode;
        /// <summary>
        /// APUserGdBuyDivUProcParamWork
        /// </summary>
        public APUserGdBuyDivUProcParamWork _userGdBuyDivUProcParam;

        #endregion �� Public Memebers ��

        #region  �� �{�^�������ݒ菈�� ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈���ł��B</br>
        /// <br>Programmer : FSI�� ���j</br>
        /// <br>Date       : 2012.07.26</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

        }
        # endregion �� �{�^�������ݒ菈�� ��

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKYO01531UA()
        {
            InitializeComponent();

            // ���[�U�[�K�C�h�p�A�N�Z�X�N���X
            this._userGuideAcs = new UserGuideAcs();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();

        }
        # endregion �� �R���X�g���N�^ ��

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̏��������s���B</br>
        /// <br>Programmer	: FSI�� ���j</br>	
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void PMKYO01201UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.ButtonInitialSetting();

            // �Q�ƃ��[�h
            if (this.Mode == 2)
            {
                this._saveButton.SharedProps.Visible = false;
                this._clearButton.SharedProps.Visible = false;

                // �̔��敪
                this.tNedit_SalesCode_St.Enabled = false;
                this.tNedit_SalesCode_Ed.Enabled = false;
                this.SalesStGuide_Button.Enabled = false;
                this.SalesEdGuide_Button.Enabled = false;
            }
            // �V�K���[�h
            else
            {
                this._saveButton.SharedProps.Visible = true;
                this._clearButton.SharedProps.Visible = true;

                // �̔��敪
                this.tNedit_SalesCode_St.Enabled = true;
                this.tNedit_SalesCode_Ed.Enabled = true;
                this.SalesStGuide_Button.Enabled = true;
                this.SalesEdGuide_Button.Enabled = true;
            }
            
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.SalesStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SalesEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            this.timer_InitialSetFocus.Enabled = true;
        }
        # endregion �� �t�H�[�����[�h ��

        # region �� ��ʏ�������C�x���g ��
        /// <summary>
        /// ��ʏ�������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ��ʏ�������C�x���g�����������܂��B</br>
        /// <br>Programmer	: FSI�� ���j</br>
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;
            if (this._userGdBuyDivUProcParam != null)
            {
                // �̔��敪
                this.tNedit_SalesCode_St.SetInt(_userGdBuyDivUProcParam.GuideCodeBeginRF);
                this.tNedit_SalesCode_Ed.SetInt(_userGdBuyDivUProcParam.GuideCodeEndRF);
            }
        }
        #endregion

        # region �� �c�[���o�[���� ��

        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: FSI�� ���j</br>	
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        this.Close();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // �ۑ�����
                        this.Save();
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        // �N���A����
                        this.Clear();
                        break;
                    }
            }
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �ۑ������ł��B</br>
        /// <br>Programmer	: FSI�� ���j</br>	
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void Save()
        {
            string errMessage = "";
            Control errCtrl = null;
            // ��ʃf�[�^�`�F�b�N����
            if (!this.ScreenInputCheck(out errCtrl, ref errMessage))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                // �t�H�[�J�X���G���[���ڂֈړ�
                if (null != errCtrl && errCtrl.Enabled)
                {
                    errCtrl.Focus();
                }
                return;
            }
            if (_userGdBuyDivUProcParam == null)
            {
                _userGdBuyDivUProcParam = new APUserGdBuyDivUProcParamWork();
            }
            else
            {
                // �̔��敪
                _userGdBuyDivUProcParam.GuideCodeBeginRF = this.tNedit_SalesCode_St.GetInt();
                _userGdBuyDivUProcParam.GuideCodeEndRF = this.tNedit_SalesCode_Ed.GetInt();
            }

            //�ۑ������������ʂ����
            this.Close();
        }

        /// <summary>
        /// �N���A����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �N���A�����ł��B</br>
        /// <br>Programmer	: FSI�� ���j</br>	
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void Clear()
        {
            // �̔��敪
            this.tNedit_SalesCode_St.SetInt(0);
            this.tNedit_SalesCode_Ed.SetInt(0);

            this.tNedit_SalesCode_St.Focus();
        }

        #endregion region �� �c�[���o�[���� ��

        #region �� Private Method ��

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�����[�h�C�x���g�����������܂��B</br>
        /// <br>Programmer	: FSI�� ���j</br>
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                // �̔��敪(�J�n)
                case "tNedit_SalesCode_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tNedit_SalesCode_St.DataText))
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_SalesCode_Ed;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.SalesStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                // �̔��敪(�I��)
                case "tNedit_SalesCode_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (!string.Empty.Equals(this.tNedit_SalesCode_Ed.DataText))
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.tNedit_SalesCode_St;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�
                                    e.NextCtrl = this.SalesEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errCtrl">Control</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: FSI�� ���j</br>
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private bool ScreenInputCheck(out Control errCtrl, ref string errMessage)
        {
            bool status = true;
            errCtrl = null;
            const string ct_RangeError = "�͈̔͂��s���ł��B";

            // �ꊇ�[���l�ߏ���
            uiSetControl1.SettingAllControlsZeroPaddedText();

            // �̔��敪�͈̓`�F�b�N
            if (this.tNedit_SalesCode_Ed.GetInt() > 0 &&
                this.tNedit_SalesCode_St.GetInt() > this.tNedit_SalesCode_Ed.GetInt())
            {
                errMessage = this.ultraLabel_Sales.Text + ct_RangeError;
                errCtrl = tNedit_SalesCode_St;
                status = false;
                return status;
            }
            return status;
        }

        /// <summary>
        /// Control.Click �C�x���g(SalesGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �̔��敪�K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : FSI�� ���j</br>
        /// <br>Date        : 2012.07.26</br>
        /// </remarks>
        private void SalesGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdHd userGdHd = new UserGdHd();
                UserGdBd userGdBd = new UserGdBd();

                status = _userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 71);
                if (status == 0)
                {
                    // �擾�����̔��敪�R�[�h����ʂɕ\������
                    if ("SalesStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_SalesCode_St.SetInt(userGdBd.GuideCode);
                        this.tNedit_SalesCode_Ed.Focus();
                    }
                    else if ("SalesEdGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_SalesCode_Ed.SetInt(userGdBd.GuideCode);
                        this.tNedit_SalesCode_St.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �G���[���b�Z�[�W����
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">STATUS</param>
        /// <returns>true:�`�F�b�N���� false:�`�F�b�N������</returns>
        /// <remarks>
        /// <br>Note		: �G���[���b�Z�[�W���s���B</br>
        /// <br>Programmer	: FSI�� ���j</br>
        /// <br>Date		: 2012.07.26</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,
                PROGRAM_ID,
                "",
                "",
                "",
                message,
                status,
                null,
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);
        }

        #endregion Private Method

		# region �� ExplorerBar�̏k���E�W�J���� ��
		/// <summary>
		/// �O���[�v�W�J
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// ��ɃL�����Z��
			e.Cancel = true;
		}
		/// <summary>
		/// �O���[�v�k��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// ��ɃL�����Z��
			e.Cancel = true;
		}
		# endregion ��  ��
    }
}