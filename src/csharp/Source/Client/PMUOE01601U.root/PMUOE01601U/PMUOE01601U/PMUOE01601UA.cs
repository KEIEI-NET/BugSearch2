//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �`�[�ԍ���������
// �v���O�����T�v   : �`�[�ԍ���������
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/06/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��ؐ��b
// �C �� ��  2010/11/02  �C�����e : Adobe Reader9�ȍ~���ƏI�����G���[�������錏�̑Ή��B(WebBrowser��������̏C��)
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using System.Collections;
using System.IO;
// --- ADD m.suzuki 2010/11/02 ---------->>>>>
using System.Runtime.InteropServices;
// --- ADD m.suzuki 2010/11/02 ----------<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �`�[�ԍ����������t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �`�[�ԍ������������s���܂��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2008.06.01</br>
    /// <br>Update Note: 2010/11/02  22018 ��� ���b</br>
    /// <br>           : Adobe Reader9�ȍ~���ƏI�����G���[�������錏�̑Ή��B(WebBrowser��������̏C��)</br>
    /// </remarks>
    public partial class PMUOE01601UA : Form
    {
        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        [DllImport( "ole32.dll" )]
        extern static void CoFreeUnusedLibraries();
        // --- ADD m.suzuki 2010/11/02 ----------<<<<<

        #region Constroctors
        /// <summary>
        /// �`�[�ԍ����������t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �`�[�ԍ����������t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: ���m</br>
        /// <br>Date		: 2008.06.01</br>
        /// </remarks>
        public PMUOE01601UA()
        {
            InitializeComponent();
            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;

            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Print"];
            this._previewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Preview"];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Update"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];

            // �K�C�h�n�A�N�Z�X�N���X
            this._employeeAcs = new EmployeeAcs();

            // �A�N�Z�X�N���X
            _slipNoAlwcInputAcs = SlipNoAlwcInputAcs.GetInstance();
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
        }
        #endregion

        // ===================================================================================== //
        // Private Members
        // ===================================================================================== //
        #region
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;					// �X�V�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;					// �N���A�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _printButton;	                // ����{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _previewButton;                // �o�c�e�\���{�^��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;				// ���O�C���S���Җ���
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;

        // �A�N�Z�X�N���X
        private SlipNoAlwcInputAcs _slipNoAlwcInputAcs = null;

        // �K�C�h�n�A�N�Z�X�N���X
        EmployeeAcs _employeeAcs;

        // �A�Z���u��ID
        private const string ASSEMBLY_ID = "PMUOE01601U";
        private DCCMN04000UA _printControl = null;
        private string _enterpriseCode;             // ��ƃR�[�h
        private const string cTAB_PREVIEW = "Preview";
        private Control _prevControl = null;									// ���݂̃R���g���[��
        #endregion


        // ===================================================================================== //
        //  Private Methods
        // ===================================================================================== //
        #region
        /// <summary>
        /// �{�^���ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
            this._previewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            this.EmployeeCode_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.AnswerSaveFolder_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }


        /// <summary>
        /// �R���{�b�N�X�����ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private void ComboxValueSetting()
        {
            this.ultraComboEditor_SupplierCode.Items.Clear();

            if (this._slipNoAlwcInputAcs.UOESupplierData.Count > 0)
            {
                int i = 0;
                foreach (UOESupplier uoeSupplier in this._slipNoAlwcInputAcs.UOESupplierData)
                {
                    Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
                    item.Tag = i + 1;
                    item.DataValue = i;
                    item.DisplayText = uoeSupplier.UOESupplierCd.ToString("000000") + ":" + uoeSupplier.UOESupplierName;
                    this.ultraComboEditor_SupplierCode.Items.Add(item);
                    i++;
                }
            }
            else
            {
                Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
                item.Tag = 1;
                item.DataValue = "";
                item.DisplayText = "";
                this.ultraComboEditor_SupplierCode.Items.Add(item);
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private void Clear()
        {
            // �f�[�^�擾
            string msg = string.Empty;
            this._slipNoAlwcInputAcs.ReadInitData(_enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, ref msg);

            // �R���{�b�N�X�ݒ�
            this.ComboxValueSetting();

            // ��ʏ������f�[�^
            this._slipNoAlwcInputAcs.CreateSlipNoAlwcInitialData();
            // ��ʏ������\��
            this.SetDisplay(this._slipNoAlwcInputAcs.SlipNoAlwcData);

            // �������{�^��
            this.BfUpdateButtonSetting();

            // �w�b�_���͍��ڐݒ�
            this.HeaderEnabledSetting(true);

            // ���׃N���A����
            this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.Clear();

            // ��ʕ\������
            this.ultraTabControl1.Tabs[cTAB_PREVIEW].Visible = false;

            // �t�H�[�J�X�ݒ�
            this.timer_SetFocus.Enabled = true;
        }

        
        /// <summary>
        /// ��ʕ\��
        /// </summary>
        /// <param name="slipNoAlwcData">��ʃf�[�^</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private void SetDisplay(SlipNoAlwcData slipNoAlwcData)
        {
            if (slipNoAlwcData == null) return;

            this.ultraComboEditor_SupplierCode.BeginUpdate();
            this.tEdit_AnswerSaveFolder.BeginUpdate();
            this.tEdit_EmployeeCode.BeginUpdate();
            this.tEdit_EmployeeName.BeginUpdate();
            this.ultraComboEditor_PriceUpdate.BeginUpdate();
            this.ultraComboEditor_StockData.BeginUpdate();

            if (this._slipNoAlwcInputAcs.UOESupplierData.Count > 0)
            {
                this.ultraComboEditor_SupplierCode.Value = slipNoAlwcData.SupplierCode;
            }
            this.tEdit_AnswerSaveFolder.DataText = slipNoAlwcData.AnswerSaveFolder;
            this.tEdit_EmployeeCode.DataText = slipNoAlwcData.EmployeeCode;
            this.tEdit_EmployeeName.DataText = slipNoAlwcData.EmployeeName;
            this.ultraComboEditor_PriceUpdate.Value = slipNoAlwcData.PriceUpdateCode;
            this.ultraComboEditor_StockData.Value = slipNoAlwcData.StockDataCode;

            this.ultraComboEditor_SupplierCode.EndUpdate();
            this.tEdit_AnswerSaveFolder.EndUpdate();
            this.tEdit_EmployeeCode.EndUpdate();
            this.tEdit_EmployeeName.EndUpdate();
            this.ultraComboEditor_PriceUpdate.EndUpdate();
            this.ultraComboEditor_StockData.EndUpdate();
        }

        /// <summary>
        /// �������{�^���ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private void BfUpdateButtonSetting()
        {
            this._printButton.SharedProps.Enabled = false;
            this._previewButton.SharedProps.Enabled = false;
            this._updateButton.SharedProps.Enabled = true;
        }

        /// <summary>
        /// �m��㏉�����{�^���ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private void AfUpdateButtonSetting()
        {
            this._updateButton.SharedProps.Enabled = false;
            this._printButton.SharedProps.Enabled = true;
            this._previewButton.SharedProps.Enabled = true;
        }

        /// <summary>
        /// ��ʏ���r����
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X(True:�������s�@False:�������f)</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.05</br>
        /// </remarks>
        public bool CompareScreen(string msg)
        {
            // ��ʏ���r
            if (!CompareOriginalScreen())
            {
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                  msg,
                                                  0,
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxDefaultButton.Button1);

                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            // �ۑ�����
                            return (true);
                        }
                    case DialogResult.No:
                        {
                            return (false);
                        }
                }
            }

            return (true);
        }

        /// <summary>
        /// ��ʏ���r����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ��@False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note        : ��ʏ����r���A�ύX����Ă���ꍇ�̓��b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer  : ���m</br>
        /// <br>Date        : 2009/06/01</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            if (this.uGrid_Result.Rows.Count > 0)
            {
                return (false);
            }

            return (true);
        }

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <param name="defaultButton">�����\���{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // �e�E�B���h�E�t�H�[��
                                         errLevel,                          // �G���[���x��
                                         ASSEMBLY_ID,                        // �A�Z���u��ID
                                         message,                           // �\�����郁�b�Z�[�W
                                         status,                            // �X�e�[�^�X�l
                                         msgButton,                         // �\������{�^��
                                         defaultButton);                    // �����\���{�^��
            return dialogResult;
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.Clear();

            if (this._prevControl != null)
            {
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
            }

            this.ultraStatusBar1.Panels[0].Text = string.Empty;

            // �X�V�O�`�F�b�N
            bool saveFlg = BeforeSaveCheck();

            if (!saveFlg)
            {
                return;
            }

            // ��ʓ��͂��֎~����
            this.HeaderEnabledSetting(false);

            string msg = string.Empty;

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "����������";
            msgForm.Message = "�����������ł��B";

            try
            {
                msgForm.Show();
                status = this._slipNoAlwcInputAcs.SaveData(ref msg);
            }
            finally
            {
                msgForm.Close();
            }

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (this.uGrid_Result.Rows.Count == 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�����Ώۂ̃f�[�^�͑��݂��܂���ł����B",
                        -1,
                        MessageBoxButtons.OK);

                    // ��ʏ���������
                    this.Clear();
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "����I�����܂����B",
                        -1,
                        MessageBoxButtons.OK);

                    // �{�^���ݒ�
                    this.AfUpdateButtonSetting();
                }

            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_WARNING)
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_INFO,
                   this.Name,
                   "������ꗗ�b�r�u�t�@�C�������݂��܂���B",
                   -1,
                   MessageBoxButtons.OK);

                // ��ʏ���������
                this.Clear();
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    msg,
                    -1,
                    MessageBoxButtons.OK);

                // �{�^���ݒ�
                this.AfUpdateButtonSetting();
            }
        }


        /// <summary>
        /// �������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void Print(bool preview)
        {
            if (this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.Count == 0)
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_INFO,
                   this.Name,
                   "����Ώۂ̃f�[�^�����݂��܂���B",
                   -1,
                   MessageBoxButtons.OK);
                return;
            }

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "���������";
            msgForm.Message = "����������ł��B";

            SFCMN06002C printInfo = new SFCMN06002C();

            try
            {
                msgForm.Show();

                if (this._printControl == null)
                    this._printControl = new DCCMN04000UA();

                printInfo.printmode = (preview) ? 2 : 3;
                printInfo.pdfopen = false;
                printInfo.pdftemppath = "";

                // ���ڈ���o�[�W����
                printInfo.enterpriseCode = this._enterpriseCode;
                printInfo.kidopgid = "PMUOE01601U";				// �N��PGID

                SlipNoAlwcData slipNoAlwcData = this._slipNoAlwcInputAcs.SlipNoAlwcData;
                // PDF�o�͗���p
                printInfo.key = "27e4e53d-9379-460c-8c4d-189584e6d0b7";
                printInfo.prpnm = "";
                printInfo.PrintPaperSetCd = 0;

                printInfo.jyoken = slipNoAlwcData;

                DataView myView = new DataView(this._slipNoAlwcInputAcs.SlipNoAlwcDataTable, "", "", DataViewRowState.CurrentRows);

                printInfo.rdData = myView;
            }
            finally
            {
                msgForm.Close();
            }

            int status = _printControl.Print(printInfo);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (preview)
                {
                    this._printControl.PDFViewer.Dock = DockStyle.Fill;
                    this.uTab_View.Controls.Add(this._printControl.PDFViewer);
                    this.ultraTabControl1.Tabs[cTAB_PREVIEW].Visible = true;
                    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs[cTAB_PREVIEW];
                }
            }
        }

        /// <summary>
        /// ��ʓ��͍��ڋ֎~
        /// </summary>
        /// <param name="enabledFlg">�t���O</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private void HeaderEnabledSetting(bool enabledFlg)
        {
            this.panel_Header.Enabled = enabledFlg;
        }

        /// <summary>
        /// �X�V�O�`�F�b�N
        /// </summary>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private bool BeforeSaveCheck()
        {
            SlipNoAlwcData slipNoAlwcData = this._slipNoAlwcInputAcs.SlipNoAlwcData;

            // ������`�F�b�N
            if (this._slipNoAlwcInputAcs.UOESupplierData.Count == 0)
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "�����悪�I������Ă��܂���B",                     // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.ultraComboEditor_SupplierCode.Focus();
                this.ultraStatusBar1.Panels[0].Text = "�������I�����ĉ������B";

                return false;
            }

            // �ۑ��t�H���_�`�F�b�N
            if (string.IsNullOrEmpty(slipNoAlwcData.AnswerSaveFolder))
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "�񓚕ۑ��t�H���_�������͂ł��B",                   // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK); 

                // �t�H�[�J�X�ݒ�
                this.tEdit_AnswerSaveFolder.Focus();
                this.ultraStatusBar1.Panels[0].Text = "�񓚕ۑ��t�H���_����͂��ĉ������B";

                return false;
            }
            // �ۑ��t�H���_�L���`�F�b�N
            // �ݒ肳�ꂽ�񓚕ۑ��t�H���_�����݂��Ȃ��ꍇ
            if (!Directory.Exists(slipNoAlwcData.AnswerSaveFolder))
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "�񓚕ۑ��t�H���_�������ł��B",                   // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.tEdit_AnswerSaveFolder.Focus();
                this.ultraStatusBar1.Panels[0].Text = "�񓚕ۑ��t�H���_����͂��ĉ������B";
                return false;
            }
            // �S���҃`�F�b�N
            if (string.IsNullOrEmpty(slipNoAlwcData.EmployeeCode))
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                "�S���҂������͂ł��B",                             // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);

                // �t�H�[�J�X�ݒ�
                this.tEdit_EmployeeCode.Focus();
                this.ultraStatusBar1.Panels[0].Text = "�S���҂���͂��ĉ������B";

                return false;
            }

            return true;
        }
        #endregion

        // ===================================================================================== //
        // �e�R���g���[���C�x���g����
        // ===================================================================================== //
        # region ��Control Event Methods
        /// <summary>
        ///	Form.Load �C�x���g(PMUOE01601U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer	: ���m</br>
        /// <br>Date		: 2008.06.02</br>
        /// </remarks>
        private void PMUOE01601UA_Load(object sender, EventArgs e)
        {
            // �{�^���ݒ�
            this.ButtonInitialSetting();

            // ���������擾
            //string msg = string.Empty;
            //int status = this._slipNoAlwcInputAcs.ReadInitData(LoginInfoAcquisition.EnterpriseCode,
            //    LoginInfoAcquisition.Employee.BelongSectionCode, ref msg);

            // �O���b�h
            this.uGrid_Result.DataSource = this._slipNoAlwcInputAcs.SlipNoAlwcDataTable;

            // �R���{�b�N�X�ݒ�
            // this.ComboxValueSetting();

            // �]�ƈ��}�X�^
            this._slipNoAlwcInputAcs.ReadEmployeeData();

            // ����������
            this.Clear();
        }

        /// <summary>
        /// �{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �S���҃{�^�����N���b�N�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private void EmployeeCode_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �L���b�V������
                SlipNoAlwcData slipNoAlwcData = this._slipNoAlwcInputAcs.SlipNoAlwcData;

                int status = -1;

                // �K�C�h�N��
                Employee employee = new Employee();
                status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

                // ���ڂɓW�J
                if (status == 0)
                {
                    slipNoAlwcData.EmployeeCode = employee.EmployeeCode.TrimEnd();
                    slipNoAlwcData.EmployeeName = employee.Name;

                    // �ĕ\������
                    this.SetDisplay(slipNoAlwcData);

                    this._slipNoAlwcInputAcs.CacheSlipNoAlwcData(slipNoAlwcData);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �񓚕ۑ��t�H���_���N���b�N�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private void AnswerSaveFolder_Button_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "�񓚕ۑ��t�H���_�I��";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    SlipNoAlwcData slipNoAlwcData = this._slipNoAlwcInputAcs.SlipNoAlwcData;

                    slipNoAlwcData.AnswerSaveFolder = folderBrowserDialog.SelectedPath;

                    this.SetDisplay(slipNoAlwcData);

                    this._slipNoAlwcInputAcs.CacheSlipNoAlwcData(slipNoAlwcData);
                }
            }
        }

        /// <summary>
        /// �t�H�[�J�X�ݒ�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note	�@ : �t�H�[�J�X�ݒ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private void timer_SetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_SetFocus.Enabled = false;

            this.ultraComboEditor_SupplierCode.Focus();
            this.ultraStatusBar1.Panels[0].Text = "�������I�����ĉ������B";
        }

        /// <summary>
        /// �O���b�h�ݒ�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private void uGrid_Result_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.uGrid_Result.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Result.DisplayLayout.Bands[0];
            if (editBand == null) return;

            editBand.ColHeadersVisible = true;

            // �O���b�h
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.SupplierDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.OrderDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.OldSupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.SupplierSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.GoodsNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.GoodsNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.UpdatePriceColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.PriceColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.FilesNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.UpdateResultColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // CellAppearance�ݒ�
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.SupplierDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.OrderDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.OldSupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.UpdatePriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.PriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.FilesNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.UpdateResultColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // �\�����ݒ�
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.SupplierDateColumn.ColumnName].Width = 90;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.OrderDateColumn.ColumnName].Width = 90;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.OldSupplierSlipNoColumn.ColumnName].Width = 120;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.SupplierSlipNoColumn.ColumnName].Width = 100;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.GoodsNoColumn.ColumnName].Width = 95;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.GoodsNameColumn.ColumnName].Width = 100;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.UpdatePriceColumn.ColumnName].Width = 92;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.PriceColumn.ColumnName].Width = 80;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.FilesNameColumn.ColumnName].Width = 165;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.UpdateResultColumn.ColumnName].Width = 80;

            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.SupplierDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.OrderDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.OldSupplierSlipNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.SupplierSlipNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.GoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.UpdatePriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.PriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.FilesNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._slipNoAlwcInputAcs.SlipNoAlwcDataTable.UpdateResultColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        }

        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.02</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            this.ultraStatusBar1.Panels[0].Text = string.Empty;

            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // ��ʏ���r
                        string msg = "���݁A�ҏW���̃f�[�^�����݂��܂��B\r\n�`�[�ԍ������������I�����Ă�낵���ł����H";
                        bool bStatus = CompareScreen(msg);
                        if (!bStatus)
                        {
                            return;
                        }

                        this.Close();
                        break;
                    }
                case "ButtonTool_Update":
                    {
                        this.Save();

                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        // ��ʏ���r
                        string msg = "���݁A�ҏW���̃f�[�^�����݂��܂��B\r\n������Ԃɖ߂��܂����H";
                        bool bStatus = CompareScreen(msg);
                        if (!bStatus)
                        {
                            return;
                        }

                        this.Clear();
                        break;
                    }
                case "ButtonTool_Print":
                    {
                        // �������
                        Print(false);

                        break;
                    }
                case "ButtonTool_Preview":
                    {
                        // �������
                        Print(true);

                        break;
                    }
            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.01</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            this._prevControl = e.NextCtrl;

            bool reRead = false;

            SlipNoAlwcData slipNoAlwcDataCurrent = this._slipNoAlwcInputAcs.SlipNoAlwcData.Clone();
            if (slipNoAlwcDataCurrent == null) return;

            SlipNoAlwcData slipNoAlwcData = slipNoAlwcDataCurrent.Clone();

            switch (e.PrevCtrl.Name)
            {
                // ������
                case "ultraComboEditor_SupplierCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.tEdit_AnswerSaveFolder;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.ultraComboEditor_StockData;
                            }
                        }

                        break;
                    }
                // �񓚕ۑ��t�H���_
                case "tEdit_AnswerSaveFolder":
                    {
                        string filePath = this.tEdit_AnswerSaveFolder.DataText;

                        if (e.ShiftKey == false)
                        {
                            // �ύX�Ȃ�
                            if (filePath.Equals(slipNoAlwcData.AnswerSaveFolder))
                            {
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    if (string.IsNullOrEmpty(filePath))
                                    {
                                        e.NextCtrl = this.AnswerSaveFolder_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_EmployeeCode;
                                    }
                                }
                            }
                            else
                            {
                                slipNoAlwcData.AnswerSaveFolder = filePath;

                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.tEdit_EmployeeCode;
                                }
                            }
                        }
                        else
                        {
                            // �ύX�Ȃ�
                            if (filePath.Equals(slipNoAlwcData.AnswerSaveFolder))
                            {
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.ultraComboEditor_SupplierCode;
                                }
                            }
                            else
                            {
                                slipNoAlwcData.AnswerSaveFolder = filePath;

                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.ultraComboEditor_SupplierCode;
                                }
                            }
                        }
                        break;
                    }
                // �񓚕ۑ��t�H���_
                case "AnswerSaveFolder_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.tEdit_EmployeeCode;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.tEdit_AnswerSaveFolder;
                            }
                        }
                        break;
                    }
                // �]�ƈ��R�[�h
                case "tEdit_EmployeeCode":
                    {
                        string code = this.tEdit_EmployeeCode.Text;

                        if (e.ShiftKey == false)
                        {
                            // �ύX�Ȃ�
                            if (code.Equals(slipNoAlwcData.EmployeeCode))
                            {
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    if (string.IsNullOrEmpty(code))
                                    {
                                        e.NextCtrl = this.EmployeeCode_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.ultraComboEditor_PriceUpdate;
                                    }
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(code))
                                {
                                    slipNoAlwcData.EmployeeCode = string.Empty;
                                    slipNoAlwcData.EmployeeName = string.Empty;

                                    // �t�H�[�J�X�ݒ�
                                    if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                    {
                                        e.NextCtrl = this.EmployeeCode_Button;
                                    }
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(this._slipNoAlwcInputAcs.GetEmployeeName(code)))
                                    {
                                        slipNoAlwcData.EmployeeCode = code;
                                        slipNoAlwcData.EmployeeName = this._slipNoAlwcInputAcs.GetEmployeeName(code);

                                        if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                        {
                                            e.NextCtrl = this.ultraComboEditor_PriceUpdate;
                                        }
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                              ASSEMBLY_ID,
                                              "�S���҂����݂��܂���B",
                                              0,
                                              MessageBoxButtons.OK);

                                        // �� 2009.07.01 liuyang modify
                                        // e.NextCtrl = this.EmployeeCode_Button;
                                        e.NextCtrl = e.PrevCtrl;
                                        // �� 2009.07.01 liuyang

                                        reRead = true;

                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // �ύX�Ȃ�
                            if (code.Equals(slipNoAlwcData.EmployeeCode))
                            {
                                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                {
                                    if (string.IsNullOrEmpty(this.tEdit_AnswerSaveFolder.Text))
                                    {
                                        e.NextCtrl = this.AnswerSaveFolder_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_AnswerSaveFolder;
                                    }
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(code))
                                {
                                    slipNoAlwcData.EmployeeCode = string.Empty;
                                    slipNoAlwcData.EmployeeName = string.Empty;

                                    // �t�H�[�J�X�ݒ�
                                    if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                    {
                                        if (string.IsNullOrEmpty(this.tEdit_AnswerSaveFolder.Text))
                                        {
                                            e.NextCtrl = this.AnswerSaveFolder_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_AnswerSaveFolder;
                                        }
                                    }
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(this._slipNoAlwcInputAcs.GetEmployeeName(code)))
                                    {
                                        slipNoAlwcData.EmployeeCode = code;
                                        slipNoAlwcData.EmployeeName = this._slipNoAlwcInputAcs.GetEmployeeName(code);

                                        if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                                        {
                                            if (string.IsNullOrEmpty(this.tEdit_AnswerSaveFolder.Text))
                                            {
                                                e.NextCtrl = this.AnswerSaveFolder_Button;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_AnswerSaveFolder;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                              ASSEMBLY_ID,
                                              "�S���҂����݂��܂���B",
                                              0,
                                              MessageBoxButtons.OK);

                                        e.NextCtrl = this.EmployeeCode_Button;

                                        reRead = true;

                                        break;
                                    }
                                }
                            }
                        }

                        break;
                    }
                // �]�ƈ��{�^��
                case "EmployeeCode_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.ultraComboEditor_PriceUpdate;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.tEdit_EmployeeCode;
                            }
                        }
                        break;
                    }
                // �����X�V
                case "ultraComboEditor_PriceUpdate":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.ultraComboEditor_StockData;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                if (string.IsNullOrEmpty(this.tEdit_EmployeeCode.Text))
                                {
                                    e.NextCtrl = this.EmployeeCode_Button;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_EmployeeCode;
                                }
                            }
                        }
                        break;
                    }
                // �d���f�[�^�쐬�敪
                case "ultraComboEditor_StockData":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.ultraComboEditor_SupplierCode;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.ultraComboEditor_PriceUpdate;
                            }
                        }
                        break;
                    }
                default :
                    break;
            }

            switch (e.NextCtrl.Name)
            {
                // ���b�Z�[�W���e
                case "ultraComboEditor_SupplierCode":
                    {
                        this.ultraStatusBar1.Panels[0].Text = "�������I�����ĉ������B";

                        break;
                    }
                case "tEdit_AnswerSaveFolder":
                    {
                        this.ultraStatusBar1.Panels[0].Text = "�񓚕ۑ��t�H���_����͂��ĉ������B";

                        break;
                    }
                case "AnswerSaveFolder_Button":
                    {
                        this.ultraStatusBar1.Panels[0].Text = "�񓚕ۑ��t�H���_����͂��ĉ������B";

                        break;
                    }
                case "tEdit_EmployeeCode":
                    {
                        this.ultraStatusBar1.Panels[0].Text = "�S���҂���͂��ĉ������B";

                        break;
                    }
                case "EmployeeCode_Button":
                    {
                        this.ultraStatusBar1.Panels[0].Text = "�S���҂���͂��ĉ������B";

                        break;
                    }
                case "ultraComboEditor_PriceUpdate":
                    {
                        this.ultraStatusBar1.Panels[0].Text = "�����X�V��I�����ĉ������B";

                        break;
                    }
                case "ultraComboEditor_StockData":
                    {
                        this.ultraStatusBar1.Panels[0].Text = "�d���f�[�^�쐬�敪��I�����ĉ������B";

                        break;
                    }
                default:
                    {
                        this.ultraStatusBar1.Panels[0].Text = "";

                        break;
                    }
            }


            // ��������̓��e�Ɣ�r����
            ArrayList arRetList = slipNoAlwcData.Compare(slipNoAlwcDataCurrent);

            if (arRetList.Count > 0 || reRead)
            {
                this._slipNoAlwcInputAcs.CacheSlipNoAlwcData(slipNoAlwcData);

                // ��ʕ\��
                this.SetDisplay(slipNoAlwcData);
            }
        }

        /// <summary>
        /// ������ݒ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.03</br>
        /// </remarks>
        private void ultraComboEditor_SupplierCode_ValueChanged(object sender, EventArgs e)
        {
            if (this.ultraComboEditor_SupplierCode.Value != null && !string.IsNullOrEmpty(this.ultraComboEditor_SupplierCode.Value.ToString()))
            {
                // �L���b�V������
                SlipNoAlwcData slipNoAlwcData = this._slipNoAlwcInputAcs.SlipNoAlwcData;

                if ((int)this.ultraComboEditor_SupplierCode.Value != slipNoAlwcData.SupplierCode)
                {
                    // ��ʒl
                    slipNoAlwcData.SupplierCode = (int)this.ultraComboEditor_SupplierCode.Value;
                    // UOE������f�[�^
                    if (this._slipNoAlwcInputAcs.UOESupplierData.Count > 0)
                    {
                        UOESupplier uoeSupplier = (UOESupplier)this._slipNoAlwcInputAcs.UOESupplierData[slipNoAlwcData.SupplierCode];
                        slipNoAlwcData.UOESupplierCd = uoeSupplier.UOESupplierCd;
                        slipNoAlwcData.UOESupplierName = uoeSupplier.UOESupplierName;
                        slipNoAlwcData.AnswerSaveFolder = uoeSupplier.AnswerSaveFolder;
                        this.tEdit_AnswerSaveFolder.Text = uoeSupplier.AnswerSaveFolder;
                    }
                    else
                    {
                        slipNoAlwcData.UOESupplierCd = 0;
                        slipNoAlwcData.UOESupplierName = "";
                        slipNoAlwcData.AnswerSaveFolder = "";
                        this.tEdit_AnswerSaveFolder.Text = "";
                    }

                    this._slipNoAlwcInputAcs.CacheSlipNoAlwcData(slipNoAlwcData);
                }
            }
        }

        /// <summary>
        /// �����X�V�ݒ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.03</br>
        /// </remarks>
        private void ultraComboEditor_PriceUpdate_ValueChanged(object sender, EventArgs e)
        {
            if (this.ultraComboEditor_PriceUpdate.Value != null)
            {
                // �L���b�V������
                SlipNoAlwcData slipNoAlwcData = this._slipNoAlwcInputAcs.SlipNoAlwcData;

                // ��ʒl
                slipNoAlwcData.PriceUpdateCode = (int)this.ultraComboEditor_PriceUpdate.Value;

                this._slipNoAlwcInputAcs.CacheSlipNoAlwcData(slipNoAlwcData);
            }
        }

        /// <summary>
        /// �d���f�[�^�쐬�敪�ݒ�
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.06.03</br>
        /// </remarks>
        private void ultraComboEditor_StockData_ValueChanged(object sender, EventArgs e)
        {
            if (this.ultraComboEditor_StockData.Value != null)
            {
                // �L���b�V������
                SlipNoAlwcData slipNoAlwcData = this._slipNoAlwcInputAcs.SlipNoAlwcData;

                // ��ʒl
                slipNoAlwcData.StockDataCode = (int)this.ultraComboEditor_StockData.Value;

                this._slipNoAlwcInputAcs.CacheSlipNoAlwcData(slipNoAlwcData);
            }
        }
        #endregion

        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMUOE01601UA_FormClosed( object sender, FormClosedEventArgs e )
        {
            try
            {
                if ( this._printControl != null && this._printControl.PDFViewer != null )
                {
                    // �u���E�U�R���g���[���𖾊m�ɔj������
                    this._printControl.PDFViewer.Dispose();
                    // �j���ׂ̈̎��Ԃ��V�X�e���ɗ^����
                    System.Windows.Forms.Application.DoEvents();
                }
            }
            finally
            {
                //  �g�pDLL�����S���
                CoFreeUnusedLibraries();
            }
        }
        // --- ADD m.suzuki 2010/11/02 ----------<<<<<
    }
}