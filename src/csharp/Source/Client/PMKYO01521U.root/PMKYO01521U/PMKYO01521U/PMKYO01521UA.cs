//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����}�X�^���o�������
// �v���O�����T�v   : �����}�X�^���o�����̐ݒ�E�Q�Ə������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI��k�c �G��
// �� �� ��  2012/07/26  �C�����e : �V�K�쐬
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
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �����}�X�^���o������ʃt�H�[���N���X
    /// </summary>
    /// <remarks>
    /// Note       : �����}�X�^���o�����̐ݒ�E�Q�Ə����ł��B<br />
    /// Programmer : FSI��k�c �G��<br />
    /// Date       : 2012/07/26<br />
    /// </remarks>
    public partial class PMKYO01521UA : Form
    {

        #region �� Const Memebers ��

        private const string PROGRAM_ID = "PMKYO01521UA";
        
        #endregion �� Const Memebers ��

        # region �� Private field ��

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        private MakerAcs _makerAcs;             // ���[�J�[�p


        private string _loginName;
        private string _enterpriseCode;
        private string _loginEmplooyCode;
        private string _loginSectionCode;

        # endregion �� Private field ��

        #region �� Public Memebers ��
        /// <summary>
        /// 1:�V�K���[�h 2:�Q�ƃ��[�h
        /// </summary>
        public int Mode; 
        /// <summary>
        /// APJoinPartsUProcParamWork
        /// </summary>
        public APJoinPartsUProcParamWork _joinPartsUProcParam;

        #endregion �� Public Memebers ��

        #region  �� �{�^�������ݒ菈�� ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈���ł��B</br>
        /// <br>Programmer : FSI��k�c �G��</br>
        /// <br>Date       : 2012/07/26</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.JoinSourceMakerCdStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.JoinSourceMakerCdEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            this.JoinDestMakerCdStGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.JoinDestMakerCdEdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;
        }
        # endregion �� �{�^�������ݒ菈�� ��

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMKYO01521UA()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Save"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._makerAcs = new MakerAcs();

            this._loginName = LoginInfoAcquisition.Employee.Name;
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginEmplooyCode = LoginInfoAcquisition.Employee.EmployeeCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

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
        /// <br>Programmer	: FSI��k�c �G��</br>	
        /// <br>Date		: 2012/07/26</br>
        /// </remarks>
        private void PMKYO01201UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.ButtonInitialSetting();

            //�Q�ƃ��[�h
            if (this.Mode == 2)
            {
                this._saveButton.SharedProps.Visible = false;
                this._clearButton.SharedProps.Visible = false;

                // �������i��
                this.tEdit_GoodsNo_St.Enabled = false;
                this.tEdit_GoodsNo_Ed.Enabled = false;

                // ���������[�J�[�R�[�h
                this.tNedit_JoinSourceMakerCd_St.Enabled = false;
                this.tNedit_JoinSourceMakerCd_Ed.Enabled = false;
                this.JoinSourceMakerCdStGuide_Button.Enabled = false;
                this.JoinSourceMakerCdEdGuide_Button.Enabled = false;

                // �����\������
                this.tNedit_JoinDispOrder_St.Enabled = false;
                this.tNedit_JoinDispOrder_Ed.Enabled = false;

                // �����惁�[�J�[�R�[�h
                this.tNedit_JoinDestMakerCd_St.Enabled = false;
                this.tNedit_JoinDestMakerCd_Ed.Enabled = false;
                this.JoinDestMakerCdStGuide_Button.Enabled = false;
                this.JoinDestMakerCdEdGuide_Button.Enabled = false;
            }
            //�V�K���[�h
            else
            {
                this._saveButton.SharedProps.Visible = true;
                this._clearButton.SharedProps.Visible = true;

                // �������i��
                this.tEdit_GoodsNo_St.Enabled = true;
                this.tEdit_GoodsNo_Ed.Enabled = true;

                // ���������[�J�[�R�[�h
                this.tNedit_JoinSourceMakerCd_St.Enabled = true;
                this.tNedit_JoinSourceMakerCd_Ed.Enabled = true;
                this.JoinSourceMakerCdStGuide_Button.Enabled = true;
                this.JoinSourceMakerCdEdGuide_Button.Enabled = true;

                // �����\������
                this.tNedit_JoinDispOrder_St.Enabled = true;
                this.tNedit_JoinDispOrder_Ed.Enabled = true;

                // �����惁�[�J�[�R�[�h
                this.tNedit_JoinDestMakerCd_St.Enabled = true;
                this.tNedit_JoinDestMakerCd_Ed.Enabled = true;
                this.JoinDestMakerCdStGuide_Button.Enabled = true;
                this.JoinDestMakerCdEdGuide_Button.Enabled = true;

            }

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
        /// <br>Programmer	: FSI��k�c �G��</br>
        /// <br>Date		: 2012/07/26</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;
            if (this._joinPartsUProcParam != null)
            {

                // �������i��
                this.tEdit_GoodsNo_St.Text = _joinPartsUProcParam.JoinSourPartsNoWithHBeginRF;
                this.tEdit_GoodsNo_Ed.Text = _joinPartsUProcParam.JoinSourPartsNoWithHEndRF;

                // ���������[�J�[�R�[�h
                this.tNedit_JoinSourceMakerCd_St.SetInt(Convert.ToInt32(_joinPartsUProcParam.JoinSourceMakerCodeBeginRF));
                this.tNedit_JoinSourceMakerCd_Ed.SetInt(Convert.ToInt32(_joinPartsUProcParam.JoinSourceMakerCodeEndRF));

                // �����\������
                this.tNedit_JoinDispOrder_St.SetInt(Convert.ToInt32(_joinPartsUProcParam.JoinDispOrderBeginRF));
                this.tNedit_JoinDispOrder_Ed.SetInt(Convert.ToInt32(_joinPartsUProcParam.JoinDispOrderEndRF));

                // �����惁�[�J�[�R�[�h
                this.tNedit_JoinDestMakerCd_St.SetInt(Convert.ToInt32(_joinPartsUProcParam.JoinDestMakerCodeBeginRF));
                this.tNedit_JoinDestMakerCd_Ed.SetInt(Convert.ToInt32(_joinPartsUProcParam.JoinDestMakerCodeEndRF));
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
        /// <br>Programmer	: FSI��k�c �G��</br>	
        /// <br>Date		: 2012/07/26</br>
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
                        //�ۑ�����
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
        /// <br>Programmer	: FSI��k�c �G��</br>	
        /// <br>Date		: 2012/07/26</br>
        /// </remarks>
        private void Save()
        {
            string errMessage = "";
            Control errCtrl = null;

            // ��ʃf�[�^�`�F�b�N����
            if (!this.ScreenInputCheck(out errCtrl, ref errMessage))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);
                //�t�H�[�J�X���G���[���ڂֈړ�
                if (null != errCtrl && errCtrl.Enabled)
                {
                    errCtrl.Focus();
                }
                return;
            }
            if (_joinPartsUProcParam == null)
            {
                _joinPartsUProcParam = new APJoinPartsUProcParamWork();
            }
            else
            {
                // �������i��
                _joinPartsUProcParam.JoinSourPartsNoWithHBeginRF = this.tEdit_GoodsNo_St.Text;
                _joinPartsUProcParam.JoinSourPartsNoWithHEndRF = this.tEdit_GoodsNo_Ed.Text;
  
                // ���������[�J�[�R�[�h
                _joinPartsUProcParam.JoinSourceMakerCodeBeginRF = this.tNedit_JoinSourceMakerCd_St.GetInt();
                _joinPartsUProcParam.JoinSourceMakerCodeEndRF = this.tNedit_JoinSourceMakerCd_Ed.GetInt();

                // �����\������
                _joinPartsUProcParam.JoinDispOrderBeginRF = this.tNedit_JoinDispOrder_St.GetInt();
                _joinPartsUProcParam.JoinDispOrderEndRF = this.tNedit_JoinDispOrder_Ed.GetInt();

                // �����惁�[�J�[�R�[�h
                _joinPartsUProcParam.JoinDestMakerCodeBeginRF = this.tNedit_JoinDestMakerCd_St.GetInt();
                _joinPartsUProcParam.JoinDestMakerCodeEndRF = this.tNedit_JoinDestMakerCd_Ed.GetInt();
            }

            //�ۑ������������ʂ����
            this.Close();
        }

        /// <summary>
        /// �N���A����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �N���A�����ł��B</br>
        /// <br>Programmer	: FSI��k�c �G��</br>	
        /// <br>Date		: 2012/07/26</br>
        /// </remarks>
        private void Clear()
        {
            // �������i��
            this.tEdit_GoodsNo_St.Text = String.Empty;
            this.tEdit_GoodsNo_Ed.Text = String.Empty;
            // ���������[�J�[�R�[�h
            this.tNedit_JoinSourceMakerCd_St.SetInt(0);
            this.tNedit_JoinSourceMakerCd_Ed.SetInt(0);
            // �����\������
            this.tNedit_JoinDispOrder_St.SetInt(0);
            this.tNedit_JoinDispOrder_Ed.SetInt(0);
            // �����惁�[�J�[�R�[�h
            this.tNedit_JoinDestMakerCd_St.SetInt(0);
            this.tNedit_JoinDestMakerCd_Ed.SetInt(0);

            this.tEdit_GoodsNo_St.Focus();
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
        /// <br>Programmer	: FSI��k�c �G��</br>
        /// <br>Date		: 2012/07/26</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                // �������i�ԁ@�I��
                case "tEdit_GoodsNo_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�(���������[�J�[�R�[�h�@�J�n)
                                e.NextCtrl = this.tNedit_JoinSourceMakerCd_St;
                            }
                        }
                        break;
                    }
                // ���������[�J�[�R�[�h�@�J�n
                case "tNedit_JoinSourceMakerCd_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_JoinSourceMakerCd_St.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�(���������[�J�[�R�[�h�@�I��)
                                    e.NextCtrl = this.tNedit_JoinSourceMakerCd_Ed;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�(���������[�J�[�R�[�h�@�J�n�K�C�h�{�^��)
                                    e.NextCtrl = this.JoinSourceMakerCdStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                // ���������[�J�[�R�[�h�@�I��
                case "tNedit_JoinSourceMakerCd_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_JoinSourceMakerCd_Ed.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�(�����\������)
                                    e.NextCtrl = this.tNedit_JoinDispOrder_St;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�(���������[�J�[�R�[�h�@�I���K�C�h�{�^��)
                                    e.NextCtrl = this.JoinSourceMakerCdEdGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                // �����\�����ʁ@�I��
                case "tNedit_JoinDispOrder_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�(�����惁�[�J�[�R�[�h �J�n)
                                e.NextCtrl = this.tNedit_JoinDestMakerCd_St;
                            }
                        }
                        break;
                    }
                // �����惁�[�J�[�R�[�h�@�J�n
                case "tNedit_JoinDestMakerCd_St":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_JoinDestMakerCd_St.GetInt() > 0 )
                                {
                                    // �t�H�[�J�X�ݒ�(�����惁�[�J�[�R�[�h�@�I��)
                                    e.NextCtrl = this.tNedit_JoinDestMakerCd_Ed;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�(�����惁�[�J�[�R�[�h�@�J�n�K�C�h�{�^��)
                                    e.NextCtrl = this.JoinDestMakerCdStGuide_Button;
                                }
                            }
                        }
                        break;
                    }
                // �����惁�[�J�[�R�[�h�@�I��
                case "tNedit_JoinDestMakerCd_Ed":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tNedit_JoinDestMakerCd_Ed.GetInt() > 0)
                                {
                                    // �t�H�[�J�X�ݒ�(�������i�ԁ@�J�n)
                                    e.NextCtrl = this.tEdit_GoodsNo_St;
                                }
                                else
                                {
                                    // �t�H�[�J�X�ݒ�(�����惁�[�J�[�R�[�h�@�I���K�C�h�{�^��)
                                    e.NextCtrl = this.JoinDestMakerCdEdGuide_Button;
                                }
                            }

                        }
                        break;
                    }

                // �����惁�[�J�[�R�[�h�@�I���K�C�h�{�^��
                case "JoinDestMakerCdEdGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // �t�H�[�J�X�ݒ�(�������i�ԁ@�J�n)
                                e.NextCtrl = this.tEdit_GoodsNo_St;
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
        /// <param name="errCtrl"></param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: FSI��k�c �G��</br>
        /// <br>Date		: 2012/07/26</br>
        /// </remarks>
        private bool ScreenInputCheck(out Control errCtrl, ref string errMessage)
        {
            bool status = true;
            errCtrl = null;
            const string ct_RangeError = "�͈̔͂��s���ł��B";

            // �ꊇ�[���l�ߏ���
            uiSetControl1.SettingAllControlsZeroPaddedText();

            // �������i��
            if (String.Compare(this.tEdit_GoodsNo_Ed.Text, "0") > 0 && String.Compare(this.tEdit_GoodsNo_St.Text, this.tEdit_GoodsNo_Ed.Text) > 0)
            {
                errMessage = "�������i��" + ct_RangeError;
                status = false;
                errCtrl = tEdit_GoodsNo_St;
                return status;
            }
            // ���������[�J�[�R�[�h
            if (this.tNedit_JoinSourceMakerCd_Ed.GetInt() > 0 && this.tNedit_JoinSourceMakerCd_St.GetInt() > this.tNedit_JoinSourceMakerCd_Ed.GetInt())
            {
                errMessage = "���������[�J�[�R�[�h" + ct_RangeError;
                status = false;
                errCtrl = tNedit_JoinSourceMakerCd_St;
                return status;
            }
            // �����\������
            if (this.tNedit_JoinDispOrder_Ed.GetInt() > 0 && this.tNedit_JoinDispOrder_St.GetInt() > this.tNedit_JoinDispOrder_Ed.GetInt())
            {
                errMessage = "�\������" + ct_RangeError;
                status = false;
                errCtrl = tNedit_JoinDispOrder_St;
                return status;
            }
            // �����惁�[�J�[�R�[�h
            if (this.tNedit_JoinDestMakerCd_Ed.GetInt() > 0 && this.tNedit_JoinDestMakerCd_St.GetInt() > this.tNedit_JoinDestMakerCd_Ed.GetInt())
            {
                errMessage = "�����惁�[�J�[�R�[�h" + ct_RangeError;
                status = false;
                errCtrl = tNedit_JoinDestMakerCd_St;
                return status;
            }
            return status;
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
        /// <br>Programmer	: FSI��k�c �G��</br>
        /// <br>Date		: 2012/07/26</br>
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
		private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// ��ɃL�����Z��
			e.Cancel = true;
		}
		/// <summary>
		/// �O���[�v�k��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			// ��ɃL�����Z��
			e.Cancel = true;
		}
		# endregion ��  ��

        /// <summary>
        /// Control.Click �C�x���g(SourceMakerCdStGuide_Button , SourceMakerCdEdGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���������[�J�[�R�[�h�@�J�n�K�C�h�{�^���E�I���K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : FSI��k�c �G��</br>
        /// <br>Date        : 2012/07/26</br>
        /// </remarks>
        private void JoinSourceMakerCdStGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            MakerUMnt makerUMnt;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    if ("JoinSourceMakerCdStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_JoinSourceMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                        this.JoinSourceMakerCdStGuide_Button.Focus();
                    }
                    else if ("JoinSourceMakerCdEdGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_JoinSourceMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                        this.JoinSourceMakerCdEdGuide_Button.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(DestMakerCdStGuide_Button , DestMakerCdEdGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �����惁�[�J�[�R�[�h�@�J�n�K�C�h�{�^���E�I���K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : FSI��k�c �G��</br>
        /// <br>Date        : 2012/07/26</br>
        /// </remarks>
        private void JoinDestMakerCdStGuide_Button_Click(object sender, EventArgs e)
        {
            int status;
            MakerUMnt makerUMnt;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    if ("JoinDestMakerCdStGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_JoinDestMakerCd_St.SetInt(makerUMnt.GoodsMakerCd);
                        this.JoinDestMakerCdStGuide_Button.Focus();
                    }
                    else if ("JoinDestMakerCdEdGuide_Button".Equals(((Infragistics.Win.Misc.UltraButton)sender).Name))
                    {
                        this.tNedit_JoinDestMakerCd_Ed.SetInt(makerUMnt.GoodsMakerCd);
                        this.JoinDestMakerCdEdGuide_Button.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}