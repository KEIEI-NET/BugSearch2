//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����ꗗ�X�V����
// �v���O�����T�v   : �z���_e-Parts�V�X�e�����u�������ꗗCSV�v����荞�݁A
//                    �񓚏����X�V���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/05/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using System.IO;
using System.Collections;
using Broadleaf.Application.Controller;
using System.Diagnostics;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �����ꗗ�X�V�������̓t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����ꗗ�X�V�����̓��̓t�H�[���N���X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.05.31</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.05.31 lizc �V�K�쐬</br>
    /// <br>Update Note: 2009/06/25 �����</br>
    /// <br>             PVCS#273�ɂ��āA�A�C�e���`�F�b�N���C�����܂��B</br>
    /// </remarks>
    public partial class PMUOE01551UA : Form
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region �R���X�g���N�^
        /// <summary>
        /// �����ꗗ�X�V�������̓t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����ꗗ�X�V�����̃R���X�g���N�^�ł��B</br>      
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        public PMUOE01551UA()
        {
            InitializeComponent();

            this._startMode = HAND_MODE;

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._uoeOrderAllInfoAcs = new UoeOrderAllInfoAcs();
            this._dataTable = this._uoeOrderAllInfoAcs.DetailDataTable;

            // �t�H�[���̃^�C�g��
            this.Text = FORM_HANDTITLE;
        }

        /// <summary>
        /// �����ꗗ�X�V�������̓t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <param name="uOESupplier">uOESupplier</param>
        /// <remarks>
        /// <br>Note       : �����ꗗ�X�V�����̃R���X�g���N�^�ł��B</br>      
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        public PMUOE01551UA(UOESupplier uOESupplier)
        {
            InitializeComponent();

            this._startMode = AUTO_MODE;

            // �N���p�����[�^
            this._paraUOESupplier = uOESupplier;

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._uoeOrderAllInfoAcs = new UoeOrderAllInfoAcs();
            this._dataTable = this._uoeOrderAllInfoAcs.DetailDataTable;

            // �t�H�[���̃^�C�g��
            this.Text = FORM_AUTOTITLE;
        }
        # endregion �R���X�g���N�^

        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        # region Private Constant
        // �^�C�g��
        private const string FORM_AUTOTITLE = "���� e-Parts �����ꗗ�X�V����";
        private const string FORM_HANDTITLE = "���� e-Parts �����ꗗ�X�V����";

        // �c�[���o�[�c�[���L�[�ݒ�
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_CONFIRMBUTTON_KEY = "ButtonTool_Confirm";
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LableTool_LoginName";
        private const string TOOLBAR_LOGINLABEL_TITLE = "LableTool_LoginTitle";

        private const string ASSEMBLY_ID = "PMUOE01551U";

        // datatable���̗p
        private const string TABLE_ID = "RESULT_TABLE";
        private const string FILENAME = "FileName"; // �t�@�C����
        private const string PROCESSNUM = "processNum"; // ����
        private const string RESULT = "result"; // ����

        // �N��Mode
        private const int HAND_MODE = 1;  // �蓮�N��
        private const int AUTO_MODE = 0;  // �����N��

        // �V���[�g�J�b�g���j���[
        private const string TOOLSTRIPMENUITEM_SCREEN = "toolStripMenuItem_Screen";
        private const string TOOLSTRIPMENUITEM_CLOSE = "toolStripMenuItem_Close";

        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        // �N��mode. 1:�蓮�N��;0:�����N��
        private int _startMode;
        // ��ƃR�[�h�擾�p
        private string _enterpriseCode;
        // ���O�C�����_(�����_)
        private string _loginSectionCode;

        // �A�N�Z�X�N���X
        private UoeOrderAllInfoAcs _uoeOrderAllInfoAcs;

        private DataTable _dataTable;

        private Dictionary<int, UOESupplier> _uOESupplierDic;

        private ImageList _imageList16 = null;											// �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _confirmButton;			// �m��{�^��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;		    // ���O�C���S���Җ���
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;            // ���O�C���S���Җ���

        // �N���p�����[�^
        private UOESupplier _paraUOESupplier;

        # endregion Private Members

        // ===================================================================================== //
        // �v���C�x�[�g
        // ===================================================================================== //
        # region Private Method
        # region ��ʏ�����
        /// <summary>
        /// ������ʐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.03.31</br>
        /// </remarks> 
        private void InitialScreenSetting()
        {
            // -----------------------------
            // �c�[���o�[�����ݒ菈��
            // -----------------------------
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;

            // �I���̃A�C�R���ݒ�
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            if (this._closeButton != null)
            {
                this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.CLOSE];
            }

            // �m��̃A�C�R���ݒ�
            this._confirmButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CONFIRMBUTTON_KEY];
            if (this._confirmButton != null)
            {
                this._confirmButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.SAVE];
            }

            // ���O�C���S���҂̃A�C�R���ݒ�
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINLABEL_TITLE];
            if (this._loginTitleLabel != null)
            {
                this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.EMPLOYEE];
            }

            // -----------------------------
            // �{�^���A�C�R���ݒ�
            // -----------------------------
            this.FolderGuide_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }
        # endregion ��ʏ�����

        # region ��ʃf�[�^������
        /// <summary>
        /// ������ʂ̃f�[�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.31</br>
        /// </remarks> 
        private void InitialScreenData()
        {
            // ���O�C���S���Җ�
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABLE_KEY];
            if (this._loginNameLabel != null && LoginInfoAcquisition.Employee != null)
            {
                Employee employee = new Employee();
                employee = LoginInfoAcquisition.Employee;
                this._loginNameLabel.SharedProps.Caption = employee.Name;
            }

            this._uOESupplierDic = new Dictionary<int, UOESupplier>();
            if (this._startMode == HAND_MODE)
            {
                // ������̎Z�o
                this.LoadUOESupplier();

                // �������ComboEditor�f�[�^������
                this.InitialUOESupplierCombo();
            }
            else
            {
                if (this._paraUOESupplier.CommAssemblyId == "0502")
                {
                    this._uOESupplierDic.Add(this._paraUOESupplier.UOESupplierCd, this._paraUOESupplier);
                }
                // �������ComboEditor�f�[�^������
                this.InitialUOESupplierCombo();
            }
        }
        # endregion ��ʃf�[�^������

        # region �������ComboEditor�f�[�^������
        /// <summary>
        /// �������ComboEditor�f�[�^������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �������ComboEditor�f�[�^�������������s���܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.06.03</br>
        /// </remarks> 
        private void InitialUOESupplierCombo()
        {
            if (this._uOESupplierDic.Count == 0) return;

            // ������
            this.tComboEditor_UOESupplier.Items.Clear();
            foreach (KeyValuePair<int, UOESupplier> kvp in this._uOESupplierDic)
            {
                this.tComboEditor_UOESupplier.Items.Add(kvp.Key, kvp.Key.ToString("000000") + ":" + kvp.Value.UOESupplierName);
            }

            this.tComboEditor_UOESupplier.SelectedIndex = 0;
        }
        # endregion

        # region ������̎Z�o
        /// <summary>
        /// ������̎Z�o
        /// </summary>
        /// <remarks>
        /// <br>Note        : ������̎Z�o�������s���܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.06.03</br>
        /// </remarks> 
        private void LoadUOESupplier()
        {
            // ������Ɖ񓚕ۑ��t�H���_
            ArrayList uOESupplierList;
            int status = this._uoeOrderAllInfoAcs.GetUOESupplier(out uOESupplierList, this._enterpriseCode, this._loginSectionCode);

            switch (status)
            {
                case 0:
                    foreach (UOESupplier uOESupplier in uOESupplierList)
                    {
                        this._uOESupplierDic.Add(uOESupplier.UOESupplierCd, uOESupplier);
                    }
                    break;
                default:
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                       "InitialScreenData",
                       "���̑��ُ킪�������܂����B",
                       0,
                       MessageBoxButtons.OK);
                    this.Close();
                    break;
            }
        }
        # endregion

        #region ��ʐݒ�
        /// <summary>
        /// �R���g���[��Focus�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[��Focus��ݒ肷��</br>
        /// <br>Programer  : �����</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        private void SetControlFocus(Control control)
        {
            if (control == null) return;

            // Focus�ݒ�
            control.Focus();

            this.SetStatusBarMsg(control);
        }

        /// <summary>
        /// StatusBar�̃��b�Z�[�W�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : StatusBar�̃��b�Z�[�W��ݒ肷��</br>
        /// <br>Programer  : �����</br>
        /// <br>Date       : 2009.06.04</br>
        /// </remarks>
        private void SetStatusBarMsg(Control control)
        {
            // �����N���ꍇ�A�ݒ肵�Ȃ�
            if (this._startMode == AUTO_MODE) return;

            // control�����ݒ�ꍇ
            if (control == null) return;

            // ������
            if (control == this.tComboEditor_UOESupplier)
            {
                this.MainStatusBar.Panels["Text"].Text = "�������I�����ĉ������B";
            }
            // �񓚕ۑ��t�H���_
            else if (control == this.tEdit_AnswerSaveFolder)
            {
                this.MainStatusBar.Panels["Text"].Text = "�񓚕ۑ��t�H���_����͂��ĉ������B";
            }
            // ���̑�
            else
            {
                this.MainStatusBar.Panels["Text"].Text = string.Empty;
            }
        }

        /// <summary>
        /// Visible�ݒ菈��(From)
        /// </summary>
        /// <param name="visible">�\��</param>
        /// <remarks>
        /// <br>Note       : Visible��ݒ肷��</br>
        /// <br>Programer  : �����</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        private void SetFromVisible(bool visible)
        {
            switch (visible)
            {
                // �蓮�N����
                case true:
                    {
                        this.Visible = true;
                        this.ParentForm.Visible = true;
                        break;
                    }
                // �����N����
                case false:
                    {
                        this.ParentForm.Visible = false;
                        this.Visible = false;
                        break;
                    }
            }
        }

        /// <summary>
        /// �R���g���[��Enabled���䏈��
        /// </summary>
        /// <param name="mode">�ҏW���[�h</param>
        /// <remarks>
        /// <br>Note       : �R���g���[����Enabled������s���܂��B</br>
        /// <br>Programer  : �����</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        private void SetControlEnabled(int mode)
        {
            switch (mode)
            {
                // �蓮�N����
                case HAND_MODE:
                    {
                        this._closeButton.SharedProps.Enabled = true;
                        this._confirmButton.SharedProps.Enabled = true;
                        this.tComboEditor_UOESupplier.Enabled = true;
                        this.tEdit_AnswerSaveFolder.Enabled = true;
                        this.FolderGuide_Button.Enabled = true;
                        break;
                    }
                // �����N����
                case AUTO_MODE:
                    {
                        this._closeButton.SharedProps.Enabled = false;
                        this._confirmButton.SharedProps.Enabled = false;
                        this.tComboEditor_UOESupplier.Enabled = false;
                        this.tEdit_AnswerSaveFolder.Enabled = false;
                        this.FolderGuide_Button.Enabled = false;
                        break;
                    }
            }
        }
        # endregion ��ʐݒ�

        # region �m�菈��
        /// <summary>
        ///�@�m�菈��(ConfirmProc())
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.31</br>
        /// </remarks>
        private void ConfirmProc()
        {
            // �f�[�^�Z�b�g�N���A
            this._uoeOrderAllInfoAcs.DataTableClear();

            // ���̓`�F�b�N
            if (this.CheckInputScreen() != true)
            {
                // PM�A��
                if (this._startMode == AUTO_MODE)
                {
                    this.Close();
                }
                return;
            }

            // ��ʏ��f�[�^�N���X�i�[����
            UOESupplierInfo uOESupplierInfo = new UOESupplierInfo();
            this.ScreenToUOESupplierInfo(ref uOESupplierInfo);

            SFCMN00299CA form = new SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "�X�V������";
            form.Message = "�X�V�������ł�";

            // �����ꗗ�b�r�u�t�@�C���̎擾
            string resultMessage;
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // �_�C�A���O�\��
                form.Show();
                this.Cursor = Cursors.WaitCursor;
                status = this._uoeOrderAllInfoAcs.DoConfirm(uOESupplierInfo, out resultMessage);

                this.Cursor = Cursors.Default;
            }
            finally
            {
                // �_�C�A���O�����
                form.Close();
            }

            emErrorLevel errLevel = emErrorLevel.ERR_LEVEL_INFO;
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:    // ��������
                    resultMessage = "����I�����܂����B";
                    break;
                case (int)ConstantManagement.MethodResult.ctFNC_ERROR:
                    errLevel = emErrorLevel.ERR_LEVEL_INFO;
                    break;
                default:    // ���̑��G���[
                    errLevel = emErrorLevel.ERR_LEVEL_STOP;
                    //resultMessage = "���̑��ُ킪�������܂����B";
                    break;
            }

            // ���b�Z�[�W�\��
            if (resultMessage != "")
            {
                this.ShowMessageBox(errLevel, "ConfirmProc", resultMessage, status, MessageBoxButtons.OK);
            }

            this.SetControlFocus(this.tComboEditor_UOESupplier);

            // PM�A���ꍇ�A��ʂ����
            if (this._startMode == AUTO_MODE)
            {
                this.Close();
            }
        }
        # endregion �m�菈��

        # region �`�F�b�N����
        /// <summary>
        /// ��ʏ����̓`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.31</br>
        /// </remarks>
        private bool CheckInputScreen()
        {
            string errMsg = "";

            try
            {
                // �����悪���I���̏ꍇ
                if (this.tComboEditor_UOESupplier.SelectedIndex == -1)
                {
                    errMsg = "�����悪�I������Ă��܂���B";
                    this.SetControlFocus(this.tComboEditor_UOESupplier);
                    return false;
                }

                string answerSaveFolder = this.tEdit_AnswerSaveFolder.DataText;

                // �񓚕ۑ��t�H���_�������͎��̏ꍇ
                if (answerSaveFolder == string.Empty)
                {
                    errMsg = "�񓚕ۑ��t�H���_�������͂ł��B";
                    this.SetControlFocus(this.tEdit_AnswerSaveFolder);
                    return false;
                }

                // �ݒ肳�ꂽ�񓚕ۑ��t�H���_�����݂��Ȃ��ꍇ
                if (!Directory.Exists(answerSaveFolder))
                {
                    errMsg = "�񓚕ۑ��t�H���_�������ł��B";
                    this.SetControlFocus(this.tEdit_AnswerSaveFolder);
                    return false;
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    this.ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO
                                 , "CheckInputScreen"
                                 , errMsg
                                 , 0
                                 , MessageBoxButtons.OK);
                }
            }
            return true;
        }
        # endregion �`�F�b�N����

        # region ��ʏ��擾
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ʏ��f�[�^�N���X�i�[����
        /// </summary>
        /// <param name="uOESupplierInfo">�f�[�^�N���X�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note        : ��ʏ�񂩂�f�[�^�N���X�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/06/02</br>
        /// </remarks>
        private void ScreenToUOESupplierInfo(ref UOESupplierInfo uOESupplierInfo)
        {
            if (uOESupplierInfo == null)
            {
                // �V�K�̏ꍇ
                uOESupplierInfo = new UOESupplierInfo();
            }

            // ��ƃR�[�h
            uOESupplierInfo.EnterpriseCode = this._enterpriseCode;
            // ���_�R�[�h
            uOESupplierInfo.SectionCode = this._loginSectionCode;
            // UOE������R�[�h
            uOESupplierInfo.UOESupplierCd = (int)this.tComboEditor_UOESupplier.SelectedItem.DataValue;
            // �񓚕ۑ��t�H���_
            uOESupplierInfo.AnswerSaveFolder = this.tEdit_AnswerSaveFolder.DataText.Trim();

            // --- ADD 2009/06/25 ------------------------------->>>>>
            UOESupplier outUOESupplier;
            this._uOESupplierDic.TryGetValue((int)this.tComboEditor_UOESupplier.SelectedItem.DataValue, out outUOESupplier);
            // �A�C�e��
            uOESupplierInfo.UOEItemCd = outUOESupplier.UOEItemCd;
            // --- ADD 2009/06/25 ------------------------------<<<<<
        }
        # endregion

        # region Grid�֘A
        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ������̎��A�O���b�h�񏉊��ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.31</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.Detail_uGrid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            editBand.ColHeadersVisible = true;

            //---------------------------------------------------------------------
            // �\�����ݒ�
            //---------------------------------------------------------------------
            editBand.Columns[FILENAME].Width = 400;
            editBand.Columns[PROCESSNUM].Width = 92;
            editBand.Columns[RESULT].Width = 230;

            //---------------------------------------------------------------------
            // ���͋��ݒ�
            //---------------------------------------------------------------------
            editBand.Columns[FILENAME].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[PROCESSNUM].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[RESULT].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

            //---------------------------------------------------------------------
            // �l��
            //---------------------------------------------------------------------
            editBand.Columns[FILENAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[PROCESSNUM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[RESULT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            //---------------------------------------------------------------------
            // �l��(header)
            //---------------------------------------------------------------------
            editBand.Columns[FILENAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[PROCESSNUM].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[RESULT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
        }
        # endregion Grid�֘A

        # region ���b�Z�[�W�{�b�N�X�\��
        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="methodName">��������</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/05/31</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            //dialogResult = TMsgDisp.Show(this, 						        // �e�E�B���h�E�t�H�[��
            //                             errLevel,			                // �G���[���x��
            //                             this.Name,						    // �v���O��������
            //                             ASSEMBLY_ID, 		  �@�@			// �A�Z���u��ID
            //                             methodName,						// ��������
            //                             "",					            // �I�y���[�V����
            //                             message,	                        // �\�����郁�b�Z�[�W
            //                             status,							// �X�e�[�^�X�l
            //                             this._uoeOrderAllInfoAcs,			// �G���[�����������I�u�W�F�N�g
            //                             msgButton,         			  	// �\������{�^��
            //                             MessageBoxDefaultButton.Button1);	// �����\���{�^��
            dialogResult = this.ShowMsg(this.Text,
                                        this, errLevel,
                                        ASSEMBLY_ID,
                                        message,
                                        status,
                                        msgButton,
                                        MessageBoxDefaultButton.Button1);

            return dialogResult;
        }

        /// <summary>
        /// ���b�Z�[�W�̕\��
        /// </summary>
        /// <param name="mainWindowTitle">�^�C�g��</param>
        /// <param name="iWin">�E�C���h�[</param>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iPgid">�v���O����ID</param>
        /// <param name="iMsg">���b�Z�[�W</param>
        /// <param name="iSt">�X�e�[�^�X</param>
        /// <param name="iButton">�{�^���^�C�v</param>
        /// <param name="iDefButton">�{�^���^�C�v</param>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/06/25</br>
        /// </remarks>
        private DialogResult ShowMsg(string mainWindowTitle, IWin32Window iWin, emErrorLevel iLevel, string iPgid, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            MessageBoxIcon hand = MessageBoxIcon.Hand;
            MessageBoxButtons oK = MessageBoxButtons.OK;
            string text = iMsg;
            switch (iLevel)
            {
                case emErrorLevel.ERR_LEVEL_STOP:
                case emErrorLevel.ERR_LEVEL_STOPDISP:
                case emErrorLevel.ERR_LEVEL_NODISP:
                    {
                        string[] strArray = System.Windows.Forms.Application.ExecutablePath.Split(new char[] { '\\' });
                        hand = MessageBoxIcon.Hand;
                        mainWindowTitle = "�G���[���� - ��" + mainWindowTitle + "��";
                        text = strArray[strArray.Length - 1] + "(" + iPgid + ") �ɂăG���[���������܂���\n\n" + iMsg + " ST = " + iSt.ToString();
                        ClientLogTextOut @out = new ClientLogTextOut();
                        @out.Output(iPgid, iMsg, iSt);
                        if (iLevel == emErrorLevel.ERR_LEVEL_NODISP)
                        {
                            return DialogResult.OK;
                        }
                        break;
                    }
                case emErrorLevel.ERR_LEVEL_EXCLAMATION:
                    hand = MessageBoxIcon.Exclamation;
                    mainWindowTitle = "���� - ��" + mainWindowTitle + "��";
                    break;

                case emErrorLevel.ERR_LEVEL_INFO:
                    hand = MessageBoxIcon.Asterisk;
                    mainWindowTitle = "��� - ��" + mainWindowTitle + "��";
                    break;

                case emErrorLevel.ERR_LEVEL_QUESTION:
                    hand = MessageBoxIcon.Question;
                    mainWindowTitle = "�m�F - ��" + mainWindowTitle + "��";
                    break;

                case emErrorLevel.ERR_LEVEL_CONFIRM:
                    hand = MessageBoxIcon.Question;
                    mainWindowTitle = "�m�F - ��" + mainWindowTitle + "��";
                    text = "���݁A�ҏW���̃f�[�^�����݂��܂�\n\n" + iMsg + "�I�����Ă���낵���ł����H";
                    oK = MessageBoxButtons.YesNo;
                    break;

                case emErrorLevel.ERR_LEVEL_SAVECONFIRM:
                    hand = MessageBoxIcon.Question;
                    mainWindowTitle = "�m�F - ��" + mainWindowTitle + "��";
                    text = "���݁A�ҏW���̃f�[�^�����݂��܂�\n\n" + iMsg + "�o�^���Ă���낵���ł����H";
                    oK = MessageBoxButtons.YesNoCancel;
                    break;

                default:
                    return DialogResult.OK;
            }
            if (oK == MessageBoxButtons.OK)
            {
                oK = iButton;
            }
            if (iWin == null)
            {
                iWin = Form.ActiveForm;
                if (iWin == null)
                {
                    IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
                    if (handle != IntPtr.Zero)
                    {
                        Control control = Control.FromHandle(handle);
                        if ((control != null) && !control.IsDisposed)
                        {
                            iWin = control;
                        }
                    }
                    if (iWin == null)
                    {
                        if (System.Windows.Forms.Application.OpenForms.Count > 0)
                        {
                            iWin = System.Windows.Forms.Application.OpenForms[0];
                        }
                        if (iWin == null)
                        {
                            System.Windows.Forms.Application.DoEvents();
                            iWin = Form.ActiveForm;
                        }
                    }
                }
            }
            return MessageBox.Show(iWin, text, mainWindowTitle, oK, hand, iDefButton);
        }
        # endregion ���b�Z�[�W�{�b�N�X�\��

        # endregion Private Method

        // ===================================================================================== //
        // �R���g���[���C�x���g
        // ===================================================================================== //
        # region Control Event Methods
        /// <summary>
        /// ���[�h�C�x���g                                            
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                            
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : ��ʂ����[�h���ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.31</br>
        /// </remarks>
        private void PMUOE01550UA_Load(object sender, EventArgs e)
        {
            // ��ʏ�����
            this.InitialScreenSetting();

            // ��ʃf�[�^������
            InitialScreenData();

            // �R���g���[��Enabled���䏈��
            this.SetControlEnabled(this._startMode);

            this.Detail_uGrid.DataSource = this._dataTable;

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.31</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I��
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        this.Close();
                        break;
                    }
                // �m��
                case TOOLBAR_CONFIRMBUTTON_KEY:
                    {
                        this.ConfirmProc();
                        break;
                    }
            }
        }

        /// <summary>
        /// Timer.Tick �C�x���g(timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					  �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.31</br>
        /// </remarks>
        private void Timer_Init_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // ��ʃf�[�^������
            //InitialScreenData();

            this.SetControlFocus(this.tComboEditor_UOESupplier);

            // PM�A���ꍇ
            if (this._startMode == AUTO_MODE)
            {
                this.ConfirmProc();
            }
        }

        /// <summary>
        /// �񓚕ۑ��t�H���_�I���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �񓚕ۑ��t�H���_�I���{�^���N���b�N���ɔ������܂��B</br> 
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.31</br>
        /// </remarks>
        private void FolderGuide_Button_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                //folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowserDialog.Description = "�񓚕ۑ��t�H���_��I�����ĉ������B";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_AnswerSaveFolder.DataText = folderBrowserDialog.SelectedPath;
                    //this.SetControlFocus(this.tComboEditor_UOESupplier);
                }
            }
        }

        /// <summary>
        /// �O���b�h�������C�A�E�g�ݒ�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ��ʏ��������A�O���b�h�������C�A�E�g�ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.31</br>
        /// </remarks>
        private void Detail_uGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // �O���b�h�񏉊��ݒ菈��
            this.InitialSettingGridCol();
        }

        /// <summary>
        /// ValueChanged�C�x���g(tComboEditor_UOESupplier)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : ValueChanged�C�x���g���ɔ������܂��B</br> 
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.06.03</br>
        /// </remarks>
        private void tComboEditor_UOESupplier_ValueChanged(object sender, EventArgs e)
        {

            UOESupplier outUOESupplier;
            this._uOESupplierDic.TryGetValue((int)this.tComboEditor_UOESupplier.SelectedItem.DataValue, out outUOESupplier);

            // �񓚕ۑ��t�H���_�̐ݒ�
            this.tEdit_AnswerSaveFolder.DataText = outUOESupplier.AnswerSaveFolder;
        }

        /// <summary>
        /// ChangeFocus �C�x���g(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.06.04</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // ������
            if (e.PrevCtrl == this.tComboEditor_UOESupplier)
            {
                // �t�H�[�J�X�ݒ�
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.tEdit_AnswerSaveFolder;
                    }
                }
                else
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.FolderGuide_Button;
                    }
                }
            }
            // �񓚕ۑ��t�H���_
            else if (e.PrevCtrl == this.tEdit_AnswerSaveFolder)
            {
                // �t�H�[�J�X�ݒ�
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.FolderGuide_Button;
                    }
                }
                else
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.tComboEditor_UOESupplier;
                    }
                }
            }
            // �񓚕ۑ��t�H���_Button
            else if (e.PrevCtrl == this.FolderGuide_Button)
            {
                // �t�H�[�J�X�ݒ�
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.tComboEditor_UOESupplier;
                    }
                }
                else
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        e.NextCtrl = this.tEdit_AnswerSaveFolder;
                    }
                }
            }

            if (e.NextCtrl != null)
            {
                // StatusBar�̃��b�Z�[�W�ݒ菈��
                this.SetStatusBarMsg(e.NextCtrl);
            }
        }
        # endregion Control Event Methods
    }
}