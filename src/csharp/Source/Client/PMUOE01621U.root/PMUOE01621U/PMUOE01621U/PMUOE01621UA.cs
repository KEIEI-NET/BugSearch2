//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Y�񓚃f�[�^�捞����
// �v���O�����T�v   : UOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A
//                    ����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : �����
// �� �� ��  2010/03/08  �C�����e : �V�K�쐬
//                                 �y�v��No.6�zUOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A����E�d���f�[�^�̍쐬���s��
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
    /// ���Y�񓚃f�[�^�捞�������̓t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Y�񓚃f�[�^�捞�����̓��̓t�H�[���N���X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2010/03/08</br>
    /// <br>UpdateNote : </br>
    /// <br></br>
    /// </remarks>
    public partial class PMUOE01621UA : Form
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region �R���X�g���N�^
        /// <summary>
        /// ���Y�񓚃f�[�^�捞�������̓t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Y�񓚃f�[�^�捞�����̃R���X�g���N�^�ł��B</br>      
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        public PMUOE01621UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._uOEOrderDtlNissanAcs = new UOEOrderDtlNissanAcs();
            this._dataTable = this._uOEOrderDtlNissanAcs.DetailDataTable;
        }
        # endregion �R���X�g���N�^

        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        # region Private Constant
        // �c�[���o�[�c�[���L�[�ݒ�
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_CONFIRMBUTTON_KEY = "ButtonTool_Confirm";
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LableTool_LoginName";
        private const string TOOLBAR_LOGINLABEL_TITLE = "LableTool_LoginTitle";

        private const string ASSEMBLY_ID = "PMUOE01621U";

        private const int INIT_MODE = 0;
        private const int AFTERSEARCH_MODE = 1;
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        // ��ƃR�[�h�擾�p
        private string _enterpriseCode;
        // ���O�C�����_(�����_)
        private string _loginSectionCode;

        // �A�N�Z�X�N���X
        private UOEOrderDtlNissanAcs _uOEOrderDtlNissanAcs;

        private DataTable _dataTable;

        private Dictionary<int, UOESupplier> _uOESupplierDic;

        private ImageList _imageList16 = null;											// �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _confirmButton;			// �m��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;			    // �����{�^��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;		    // ���O�C���S���Җ���
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;            // ���O�C���S���Җ���

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
        /// <br>Date        : 2010/03/08</br>
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

            // �����̃A�C�R���ݒ�
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SEARCHBUTTON_KEY];
            if (this._searchButton != null)
            {
                this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.SEARCH];
            }

            // ���O�C���S���҂̃A�C�R���ݒ�
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINLABEL_TITLE];
            if (this._loginTitleLabel != null)
            {
                this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.EMPLOYEE];
            }
        }
        # endregion ��ʏ�����

        # region ��ʃf�[�^������
        /// <summary>
        /// ������ʂ̃f�[�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��������ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/03/08</br>
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
            // ������̎Z�o
            this.LoadUOESupplier();

            // �������ComboEditor�f�[�^������
            this.InitialUOESupplierCombo();
        }
        # endregion ��ʃf�[�^������

        # region �������ComboEditor�f�[�^������
        /// <summary>
        /// �������ComboEditor�f�[�^������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �������ComboEditor�f�[�^�������������s���܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/03/08</br>
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
        /// <br>Date        : 2010/03/08</br>
        /// </remarks> 
        private void LoadUOESupplier()
        {
            // ������Ɖ񓚕ۑ��t�H���_
            ArrayList uOESupplierList;
            int status = this._uOEOrderDtlNissanAcs.GetUOESupplier(out uOESupplierList, this._enterpriseCode, this._loginSectionCode);

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
        /// <br>Date       : 2010/03/08</br>
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
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void SetStatusBarMsg(Control control)
        {
            // control�����ݒ�ꍇ
            if (control == null) return;

            // ������
            if (control == this.tComboEditor_UOESupplier)
            {
                this.MainStatusBar.Panels["Text"].Text = "�������I�����ĉ������B";
            }
            // ���̑�
            else
            {
                this.MainStatusBar.Panels["Text"].Text = string.Empty;
            }
        }

        /// <summary>
        /// �R���g���[��Enabled���䏈��
        /// </summary>
        /// <param name="mode">�ҏW���[�h</param>
        /// <remarks>
        /// <br>Note       : �R���g���[����Enabled������s���܂��B</br>
        /// <br>Programer  : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void SetControlEnabled(int mode)
        {
            switch (mode)
            {
                // ��������
                case INIT_MODE:
                    {
                        this._closeButton.SharedProps.Enabled = true;
                        this._confirmButton.SharedProps.Enabled = false;
                        this._searchButton.SharedProps.Enabled = true;
                        this.tComboEditor_UOESupplier.Enabled = true;
                        this.tEdit_AnswerSaveFolder.Enabled = false;
                        break;
                    }
                // �������ʂ����鎞
                case AFTERSEARCH_MODE:
                    {
                        this._closeButton.SharedProps.Enabled = true;
                        this._confirmButton.SharedProps.Enabled = true;
                        this._searchButton.SharedProps.Enabled = false;
                        this.tComboEditor_UOESupplier.Enabled = false;
                        this.tEdit_AnswerSaveFolder.Enabled = false;
                        break;
                    }
            }
        }
        # endregion ��ʐݒ�

        # region ��������
        /// <summary>
        ///�@��������(SearchProc())
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �����������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private void SearchProc()
        {
            // �f�[�^�Z�b�g�N���A
            this._uOEOrderDtlNissanAcs.DataTableClear();

            // ���̓`�F�b�N
            if (this.CheckInputScreen() != true)
            {
                this.uLabel_UOESupplier.Focus();
                this.SetControlFocus(this.tComboEditor_UOESupplier);

                return;
            }

            // ��ʏ��f�[�^�N���X�i�[����
            AnswerDateNissanPara answerDateNissanPara = new AnswerDateNissanPara();
            this.ScreenToAnswerDateNissanPara(ref answerDateNissanPara);

            SFCMN00299CA form = new SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "����������";
            form.Message = "�����������ł�";

            // �����ꗗ�b�r�u�t�@�C���̎擾
            string resultMessage = string.Empty;
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // �_�C�A���O�\��
                form.Show();
                this.Cursor = Cursors.WaitCursor;
                status = this._uOEOrderDtlNissanAcs.DoSearch(answerDateNissanPara, out resultMessage);

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
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    this.SetControlEnabled(AFTERSEARCH_MODE);
                    break;
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    resultMessage = "�Y���f�[�^�����݂��܂���B";
                    errLevel = emErrorLevel.ERR_LEVEL_INFO;

                    this.ShowMessageBox(errLevel,
                            "SearchProc",
                            resultMessage,
                            status,
                            MessageBoxButtons.OK);

                    break;
                case (int)ConstantManagement.MethodResult.ctFNC_WARNING:
                    DialogResult dialogResult = this.ShowMessageBox(errLevel,
                                                    "SearchProc",
                                                    resultMessage,
                                                    status,
                                                    MessageBoxButtons.RetryCancel);

                    if (dialogResult == DialogResult.Retry)
                    {
                        this.SearchProc();
                    }
                    break;
                default:    // ���̑��G���[
                    errLevel = emErrorLevel.ERR_LEVEL_STOP;

                    this.ShowMessageBox(errLevel,
                            "SearchProc",
                            resultMessage,
                            status,
                            MessageBoxButtons.OK);
                    break;
            }

            this.uLabel_UOESupplier.Focus();
            this.SetControlFocus(this.tComboEditor_UOESupplier);
        }
        # endregion ��������

        # region �m�菈��
        /// <summary>
        ///�@�m�菈��(ConfirmProc())
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �m�菈�����s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/03/08</br>
        /// <br>UpdateNote  : </br>
        /// </remarks>
        private void ConfirmProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string resultMessage = string.Empty;

            // ��ʏ��f�[�^�N���X�i�[����
            AnswerDateNissanPara answerDateNissanPara = new AnswerDateNissanPara();
            this.ScreenToAnswerDateNissanPara(ref answerDateNissanPara);

            SFCMN00299CA form = new SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "�捞������";
            form.Message = "�捞�������ł�";

            // �i���\���p�t�H�[����ݒ�
            this._uOEOrderDtlNissanAcs.ProgressForm = form;

            try
            {
                // �_�C�A���O�\��
                form.Show();
                this.Cursor = Cursors.WaitCursor;

                // �m�菈��
                status = this._uOEOrderDtlNissanAcs.DoConfirm(answerDateNissanPara, out resultMessage);

                this.Cursor = Cursors.Default;
            }
            finally
            {
                // �_�C�A���O�����
                form.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:    // ��������
                    {
                        // ��ʏ��N���A����
                        this.ClearScreen();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        break;
                    }
                default:    // ���̑��G���[
                    {
                        this.ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                "ConfirmProc",
                                resultMessage,
                                status,
                                MessageBoxButtons.OK);
                        break;
                    }
            }
        }
        # endregion

        # region �`�F�b�N����
        /// <summary>
        /// ��ʏ����̓`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/03/08</br>
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
                    return false;
                }

                string answerSaveFolder = this.tEdit_AnswerSaveFolder.DataText;

                // �񓚕ۑ��t�H���_�������͎��̏ꍇ
                if (answerSaveFolder == string.Empty)
                {
                    errMsg = "�񓚕ۑ��t�H���_�������͂ł��BUOE������}�X�^�̐ݒ�����m�F���������B";
                    return false;
                }

                // �ݒ肳�ꂽ�񓚕ۑ��t�H���_�����݂��Ȃ��ꍇ
                if (!Directory.Exists(answerSaveFolder))
                {
                    errMsg = "�񓚕ۑ��t�H���_������܂���B";
                    return false;
                }

                // �񓚕ۑ��t�H���_�Ƀg���^�����񓚃t�@�C�������݂��Ȃ��ꍇ
                if (!File.Exists(answerSaveFolder + "\\HKAITO.DAT")
                    && !File.Exists(answerSaveFolder + "\\Order.csv")
                    && !File.Exists(answerSaveFolder + "\\OrderAns.csv"))
                {
                    errMsg = "�񓚕ۑ��t�H���_�ɔ����񓚃t�@�C��������܂���B";
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

        /// <summary>
        /// �ҏW���̃f�[�^�`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �ҏW���̃f�[�^�`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private bool EditCheck()
        {
            // �������ʂ�����ꍇ
            if (this.Detail_uGrid.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }
        # endregion �`�F�b�N����

        # region ��ʏ��擾
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ʏ��f�[�^�N���X�i�[����
        /// </summary>
        /// <param name="answerDateNissanPara">�f�[�^�N���X�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note        : ��ʏ�񂩂�f�[�^�N���X�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private void ScreenToAnswerDateNissanPara(ref AnswerDateNissanPara answerDateNissanPara)
        {
            if (answerDateNissanPara == null)
            {
                // �V�K�̏ꍇ
                answerDateNissanPara = new AnswerDateNissanPara();
            }

            // ��ƃR�[�h
            answerDateNissanPara.EnterpriseCode = this._enterpriseCode;
            // ���_�R�[�h
            answerDateNissanPara.SectionCode = this._loginSectionCode;
            // UOE������R�[�h
            answerDateNissanPara.UOESupplierCd = (int)this.tComboEditor_UOESupplier.SelectedItem.DataValue;
            // �񓚕ۑ��t�H���_
            answerDateNissanPara.AnswerSaveFolder = this.tEdit_AnswerSaveFolder.DataText.Trim();

            UOESupplier outUOESupplier;
            this._uOESupplierDic.TryGetValue((int)this.tComboEditor_UOESupplier.SelectedItem.DataValue, out outUOESupplier);
        }
        # endregion

        # region Grid�֘A
        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ������̎��A�O���b�h�񏉊��ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.Detail_uGrid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            editBand.ColHeadersVisible = true;

            //---------------------------------------------------------------------
            // �\�����ݒ�
            //---------------------------------------------------------------------
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.NO].Width = 34;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNO].Width = 180;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSMAKERCD].Width = 44;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNAME].Width = 190;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COUNT].Width = 90;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.ANSWERPARTSNO].Width = 210;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.LISTPRICE].Width = 80;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.SALESUNITCOST].Width = 80;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COMMENT].Width = 110;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTIONSLIPNO].Width = 60;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTOUTGOODSCNT].Width = 110;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO1].Width = 94;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT1].Width = 80;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO2].Width = 94;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT2].Width = 80;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO3].Width = 94;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT3].Width = 80;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOMANAGEMENTNO].Width = 94;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.EOALWCCOUNT].Width = 94;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.MAKERFOLLOWCNT].Width = 100;

            //---------------------------------------------------------------------
            // ���͋��ݒ�
            //---------------------------------------------------------------------
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.NO].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNO].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSMAKERCD].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNAME].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COUNT].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.ANSWERPARTSNO].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.LISTPRICE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.SALESUNITCOST].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COMMENT].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTIONSLIPNO].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTOUTGOODSCNT].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO1].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT1].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO2].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT2].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO3].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT3].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.MAKERFOLLOWCNT].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOMANAGEMENTNO].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.EOALWCCOUNT].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

            //---------------------------------------------------------------------
            // �l��
            //---------------------------------------------------------------------
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.NO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSMAKERCD].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COUNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.ANSWERPARTSNO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.LISTPRICE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.SALESUNITCOST].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COMMENT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTIONSLIPNO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTOUTGOODSCNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.MAKERFOLLOWCNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOMANAGEMENTNO].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.EOALWCCOUNT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            //---------------------------------------------------------------------
            // �l��(header)
            //---------------------------------------------------------------------
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.NO].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNO].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSMAKERCD].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COUNT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.ANSWERPARTSNO].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.LISTPRICE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.SALESUNITCOST].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COMMENT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTIONSLIPNO].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTOUTGOODSCNT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO1].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT1].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO2].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT2].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSLIPNO3].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT3].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.MAKERFOLLOWCNT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOMANAGEMENTNO].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.EOALWCCOUNT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

            //---------------------------------------------------------------------
            // �t�H�[�}�b�g�ݒ�
            //---------------------------------------------------------------------
            string codeFormat = "#";
            string codeFormat_GoodsMakerCd = "0000";
            string numFormat = "#,###";

            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSNO].Format = codeFormat; // �i��
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.GOODSMAKERCD].Format = codeFormat_GoodsMakerCd; // ���[�J�[
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.COUNT].Format = numFormat; // ����
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.LISTPRICE].Format = numFormat; // �艿
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.SALESUNITCOST].Format = numFormat; //�P��
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.UOESECTOUTGOODSCNT].Format = numFormat; // UOE���_�o�ɐ�
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT1].Format = numFormat; // BO�o�ɐ�1
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT2].Format = numFormat; // BO�o�ɐ�2
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.BOSHIPMENTCNT3].Format = numFormat; // BO�o�ɐ�3
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.MAKERFOLLOWCNT].Format = numFormat; // ���[�J�[�t�H���[��
            editBand.Columns[NissanWebUOEOrderDtlInfoBuilder.EOALWCCOUNT].Format = numFormat; // EO������
        }
        # endregion Grid�֘A

        # region ��ʏ��N���A����
        /// <summary>
        /// ��ʏ��N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʏ��N���A�������s���B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private void ClearScreen()
        {
            // �������ComboEditor�f�[�^������
            this.InitialUOESupplierCombo();

            // �f�[�^�Z�b�g�N���A����
            this._uOEOrderDtlNissanAcs.DataTableClear();

            // �R���g���[��Enabled���䏈��
            this.SetControlEnabled(INIT_MODE);

            // �R���g���[��Focus�ݒ菈��
            this.uLabel_UOESupplier.Focus();
            this.SetControlFocus(this.tComboEditor_UOESupplier);
        }
        # endregion

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
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
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
        /// <br>Date       : 2010/03/08</br>
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

        # region �� �r������ ��
        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �r��������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            string errMsg = "";

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        errMsg = "���ɑ��[�����X�V����Ă��܂��B";
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        errMsg = "���ɑ��[�����폜����Ă��܂��B";
                        break;
                    }
            }

            this.ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    "ConfirmProc",
                    errMsg,
                    status,
                    MessageBoxButtons.OK);
        }
        # endregion �� �r������
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
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private void PMUOE01621UA_Load(object sender, EventArgs e)
        {
            // ��ʏ�����
            this.InitialScreenSetting();

            // ��ʃf�[�^������
            InitialScreenData();

            // �R���g���[��Enabled���䏈��
            this.SetControlEnabled(INIT_MODE);

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
        /// <br>Date        : 2010/03/08</br>
        /// <br>UpdateNote  : </br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I��
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        if (this.EditCheck())
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                                "���s���ċX�����ł����H",
                                0,
                                MessageBoxButtons.YesNo,
                                MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.No)
                            {
                                return;
                            }
                        }

                        this.Close();
                        break;
                    }
                // �m��
                case TOOLBAR_CONFIRMBUTTON_KEY:
                    {
                        this.ConfirmProc();
                        break;
                    }
                // ����
                case TOOLBAR_SEARCHBUTTON_KEY:
                    {
                        this.SearchProc();
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
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private void Timer_Init_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;

            this.SetControlFocus(this.tComboEditor_UOESupplier);
        }

        /// <summary>
        /// �O���b�h�������C�A�E�g�ݒ�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ��ʏ��������A�O���b�h�������C�A�E�g�ݒ���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/03/08</br>
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
        /// <br>Date        : 2010/03/08</br>
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
        /// <br>Date        : 2010/03/08</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // ������
            if (e.PrevCtrl == this.tComboEditor_UOESupplier)
            {
                // �t�H�[�J�X�ݒ�
                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                {
                    e.NextCtrl = this.tComboEditor_UOESupplier;
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