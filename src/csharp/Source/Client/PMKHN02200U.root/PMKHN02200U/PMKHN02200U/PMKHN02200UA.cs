using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller.Util;  
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���j���[����ݒ�i����jUI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���j���[����ݒ�i����jUI�t�H�[���N���X</br>
    /// <br>Programmer : 30747 �O�� �L��</br>
    /// <br>Date       : 2013/02/15</br>
    /// <br>Update Note: 2013/02/25 �O�� �L��</br>
    /// <br>             2013/03/06�z�M �V�X�e����Q��124�Ή�</br>
    /// </remarks>
    public partial class PMKHN02200UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� Constructor
        /// <summary>
        /// ���j���[����ݒ�i����jUI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���j���[����ݒ�i����jUI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : 30747 �O�� �L��</br>
        /// <br>Date       : 2013/02/15</br>
        /// <br></br>
        /// </remarks>
        public PMKHN02200UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            this._menueStSetAcs = new MenueStSetAcs();


            // �ϐ�������
            this.secInfoSetTable = new Hashtable();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();
        }
        #endregion �� Constructor

        #region �� Private Member
        #region �� Interface member
        //--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract = false;
        // PDF�o�̓{�^����Ԏ擾�v���p�e�B    
        private bool _canPdf = true;
        // ����{�^����Ԏ擾�v���p�e�B
        private bool _canPrint = true;
        // ���o�{�^���\���L���v���p�e�B
        private bool _visibledExtractButton = false;
        // PDF�o�̓{�^���\���L���v���p�e�B	
        private bool _visibledPdfButton = true;
        // ����{�^���\���L���v���p�e�B
        private bool _visibledPrintButton = true;


        #endregion �� Interface member

        // ��ƃR�[�h
        private string _enterpriseCode = "";
        private Employee _loginWorker = null;
        // �����_�R�[�h
        private string _ownSectionCode = "";

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���o�����N���X
        private MenueStPrintWork _menueStPrintWork;

        // �f�[�^�A�N�Z�X
        private MenueStSetAcs _menueStSetAcs;

        // �]�ƈ��}�X�^�A�N�Z�X�N���X
        private EmployeeAcs _employeeAcs;
        //private Hashtable _employeeTb = null;

        private Hashtable secInfoSetTable;

        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
        // �N���XID
        private const string ct_ClassID = "PMKHN02200UA";
        // �v���O����ID
        private const string ct_PGID = "PMKHN02200U";
        //// ���[����
        private string _printName = "���j���[����ݒ�i����j";
        // ���[�L�[	
        private string _printKey = "499521e5-3fa7-41c7-90a0-f37eb7de7ff0";
        #endregion �� Interface member

        // ExporerBar �O���[�v����
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// �o�͏���
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// ���o����


        private const string PRINTSET_TABLE = "MENUEST";

        // dataview���̗p
        private const string SORTKEY = "sortkey";
        private const string ROLEGROUPCODE = "rolegroupcode";
        private const string ROLEGROUPNAME = "rolegroupname";
        private const string SYSTEMNAME = "systemname";
        private const string EMPLOYEECODE = "employeecode";
        private const string EMPLOYEENAME = "employeename";

        private const string SORTKEY_TITLE = "�\�[�g�L�[";
        private const string ROLEGROUPCODE_TITLE = "����";
        private const string ROLEGROUPNAME_TITLE = "���[���O���[�v�ݒ薼��";
        private const string SYSTEMNAME_TITLE = "�V�X�e���@�\";
        private const string EMPLOYEECODE_TITLE = "�]�ƈ��R�[�h";
        private const string EMPLOYEENAME_TITLE = "�]�ƈ�����";

        private const string ct_ZERO_NAME = "���ʐݒ�";
        private const string RoleNotDefined = "���ݒ�";

        private static readonly Color ct_DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color ct_DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color ct_READONLY_COLOR = Color.WhiteSmoke;
        private static readonly Color ct_ROWSTATUS_COPY_COLOR = Color.Pink;
        private static readonly Color ct_ROWSTATUS_CUT_COLOR = Color.Gray;
        private static readonly Color ct_REDUCTION_FONT_COLOR = Color.Green;
        private static readonly Color ct_MINUS_FONT_COLOR = Color.Red;
        private static readonly Color ct_GOODSDISCOUNT_CELL_COLOR = Color.Pink;
        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        private static readonly Color ct_ALLWAYS_CELL_COLOR = Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));

        private static readonly Color ct_MARGIN_LESS_COLOR = Color.Orchid;
        private static readonly Color ct_MARGIN_NORMAL_COLOR = Color.Gainsboro;
        private static readonly Color ct_MARGIN_OVER_COLOR = Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));

        private static readonly Color ct_UNITPRICE_NORMAL_COLOR = Color.Gainsboro;
        private static readonly Color ct_UNITPRICE_CHANGE_COLOR = Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(255)))), ((int)(((byte)(210)))));

        #endregion

        #region �� IPrintConditionInpType �����o
        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Property
        /// <summary> ���o�{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF�o�̓{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> ����{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> ���o�{�^���\���L���v���p�e�B </summary>
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF�o�̓{�^���\���L���v���p�e�B </summary>
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> ����{�^���\���v���p�e�B </summary>
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }

        #endregion �� Public Property

        #region �� Public Method
        #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        public int Extract(ref object parameter)
        {

            int status = 0;
            ArrayList PrintSets = null;

            // ��ʁ����o�����N���X
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // --- DEL 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��Q��124 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //// �f�[�^�Z�b�g����č\�z����
            //DataSetColumnReset();
            // --- DEL 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��Q��124 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Clear();

            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 0)
            {
                status = this._menueStSetAcs.Search(
                    out PrintSets,
                    this._enterpriseCode,
                    this._menueStPrintWork);
            }
            else
            {
                status = this._menueStSetAcs.SearchAll(
                    out PrintSets,
                    this._enterpriseCode,
                    this._menueStPrintWork);
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // --- ADD 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��Q��124 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        if (PrintSets.Count > 0)
                        {
                            // �f�[�^�Z�b�g����č\�z����
                            DataSetColumnReset();
                        }
                        // --- ADD 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��Q��124 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                        // ���j���[����ݒ�N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        foreach (MenueStSet menueStSet in PrintSets)
                        {

                            SecPrintSetToDataSet(menueStSet.Clone(), index);
                            ++index;
                        }

                        // �f�[�^���L�[���Ƀ\�[�g���čč\�z
                        DataSort();

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "PMKHN02200U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���j���[����ݒ�i����j", 			// �v���O��������
                            "Extract", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._menueStSetAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
            }
            return 0;
        }
        #endregion

        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer	: 30747 �O�� �L��</br>
        /// <br>Date		: 2013/02/15</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// �N��PGID

            // PDF�o�͗���p
            printInfo.key = this._printKey;
            printInfo.prpnm = "���j���[����ݒ�(" + this.tComboEditor_SortCode.Text + ")";

            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // ���o�����̐ݒ�
            printInfo.jyoken = this._menueStPrintWork;
            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        #region �� ����O�m�F����
        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer	: 30747 �O�� �L��</br>
        /// <br>Date		: 2013/02/15</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }
        #endregion

        #region �� ��ʕ\������
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ��ʕ\�����s���B</br>
        /// <br>Programmer	: 30747 �O�� �L��</br>
        /// <br>Date		: 2013/02/15</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._menueStPrintWork = new MenueStPrintWork();

            this.Show();
            return;
        }
        #endregion

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer	: 30747 �O�� �L��</br>
        /// <br>Date		: 2013/02/15</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PRINTSET_TABLE;
        }

        /// <summary>
        /// ���C���t���[���O���b�g���C�A�E�g�ݒ�
        /// </summary>
        /// <param name="UGrid"></param>
        public void SetGridStyle(ref Infragistics.Win.UltraWinGrid.UltraGrid UGrid)
        {

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = UGrid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            UGrid.DisplayLayout.Bands[0].UseRowLayout = true;

            // �񕝂̎����������@
            UGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            UGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            UGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            UGrid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            UGrid.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            UGrid.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;


            UGrid.DisplayLayout.Bands[0].RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
            UGrid.DisplayLayout.Bands[0].RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;
            System.Drawing.Size sizeHeader = new Size();
            System.Drawing.Size sizeCell = new Size();

            #region ���ڂ̃T�C�Y��ݒ�
            sizeCell.Height = 22;
            sizeCell.Width = 60;
            sizeHeader.Height = 20;
            sizeHeader.Width = 60;

            // �R�[�h
            UGrid.DisplayLayout.Bands[0].Columns[ROLEGROUPCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[ROLEGROUPCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // �P�s��
            sizeCell.Width = 200;
            sizeHeader.Width = 200;
            UGrid.DisplayLayout.Bands[0].Columns[ROLEGROUPNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[ROLEGROUPNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            UGrid.DisplayLayout.Bands[0].Columns[SYSTEMNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[SYSTEMNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            #endregion  ���ڂ̃T�C�Y��ݒ�

            #region LabelSpan�̐ݒ�
            UGrid.DisplayLayout.Bands[0].Columns[ROLEGROUPCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[ROLEGROUPNAME].RowLayoutColumnInfo.LabelSpan = 2;
            #endregion LabelSpan�̐ݒ�

            // �w�b�_���̂�ݒ�
            UGrid.DisplayLayout.Bands[0].Columns[SORTKEY].Header.Caption = SORTKEY_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[ROLEGROUPCODE].Header.Caption = ROLEGROUPCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[ROLEGROUPNAME].Header.Caption = ROLEGROUPNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[SYSTEMNAME].Header.Caption = SYSTEMNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYEECODE].Header.Caption = EMPLOYEECODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[EMPLOYEENAME].Header.Caption = EMPLOYEENAME_TITLE;

            // �\�[�g�L�[�̓O���b�h��ɕ\�����Ȃ�
            UGrid.DisplayLayout.Bands[0].Columns[SORTKEY].Hidden = true;
        }

        /// <summary>
        /// ���o�����`�F�b�N����
        /// </summary>
        /// <returns></returns>
        public bool DataCheck()
        {
            bool status = true;
            // �J�n�]�ƈ�
            if (this._menueStPrintWork.EmployeeCodeSt != this.tNedit_EmployeeCode_St.DataText)
            {
                status = false;
                return status;
            }
            // �I���]�ƈ�
            if (this._menueStPrintWork.EmployeeCodeEd != this.tNedit_EmployeeCode_Ed.DataText)
            {
                status = false;
                return status;
            }
            // �����
            if (this._menueStPrintWork.SortCode != (int)this.tComboEditor_SortCode.Value)
            {
                status = false;
                return status;
            }
            return status;
        }
        #endregion �� Public Method
        #endregion �� IPrintConditionInpType �����o

        #region �� IPrintConditionInpTypePdfCareer �����o
        #region �� Public Property

        /// <summary> ���[�L�[�v���p�e�B </summary>
        public string PrintKey
        {
            get { return this._printKey; }
        }

        /// <summary> ���[���v���p�e�B </summary>
        public string PrintName
        {
            get { return this._printName; }
        }

        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypePdfCareer �����o

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer	: 30747 �O�� �L��</br>
        /// <br>Date		: 2013/02/15</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // �����l�Z�b�g�E������
                this.tComboEditor_SortCode.SelectedIndex = 0;
                this.tNedit_EmployeeCode_St.DataText = string.Empty;
                this.tNedit_EmployeeCode_Ed.DataText = string.Empty;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);

                // �{�^���ݒ�
                this.SetIconImage(this.ub_St_EmployeeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_EmployeeGuide, Size16_Index.STAR1);

                // �폜�w��R���{�̐ݒ�
                this.tComboEditor_LogicalDeleteCode.Value = 0;
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;

                // �����t�H�[�J�X�Z�b�g
                this.tNedit_EmployeeCode_St.Focus();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion �� ��ʏ������֌W

        #region �� ����O����
        #region �� ���̓`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: 30747 �O�� �L��</br>
        /// <br>Date		: 2013/02/15</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";


            // �S����
            if (
                (this.tNedit_EmployeeCode_St.GetInt() != 0) &&
                (this.tNedit_EmployeeCode_Ed.GetInt() != 0) &&
                this.tNedit_EmployeeCode_St.GetInt() > this.tNedit_EmployeeCode_Ed.GetInt())
            {
                errMessage = string.Format("�S����{0}", ct_RangeError);
                errComponent = this.tNedit_EmployeeCode_St;
                status = false;
                return status;  
            }

            // �폜���t
            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 1)
            {
                if (IsErrorTDateEdit(this.SerchSlipDataStRF_tDateEdit, false, out errMessage) == false)
                {
                    errComponent = this.SerchSlipDataStRF_tDateEdit;
                    status = false;
                    return status;
                }

                if (IsErrorTDateEdit(this.SerchSlipDataEdRF_tDateEdit, false, out errMessage) == false)
                {
                    errComponent = this.SerchSlipDataEdRF_tDateEdit;
                    status = false;
                    return status;
                }

                // �͈̓`�F�b�N
                if ((this.SerchSlipDataStRF_tDateEdit.GetDateTime() != DateTime.MinValue) &&
                    (this.SerchSlipDataEdRF_tDateEdit.GetDateTime() != DateTime.MinValue))
                {
                    if (this.SerchSlipDataStRF_tDateEdit.GetDateTime() > this.SerchSlipDataEdRF_tDateEdit.GetDateTime())
                    {
                        errMessage = "�폜���t�͈͎̔w��Ɍ�肪����܂��B";
                        this.SerchSlipDataStRF_tDateEdit.Focus();
                        return (false);
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="tDateEdit">�`�F�b�N�Ώ�TDateEdit</param>
        /// <param name="minValueCheck">�����̓`�F�b�N�t���O(True:�����͕s�� False:�����͉�)</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
        /// <remarks>
        /// <br>Note       : ���t�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30747 �O�� �L��</br>
        /// <br>Date       : 2013/02/15</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, bool minValueCheck, out string errMsg)
        {
            errMsg = "";

            int year = tDateEdit.GetDateYear();
            int month = tDateEdit.GetDateMonth();
            int day = tDateEdit.GetDateDay();

            if (minValueCheck == true)
            {
                if ((year == 0) || (month == 0) || (day == 0))
                {
                    errMsg = "���t���w�肵�Ă��������B";
                    return (false);
                }
            }
            else
            {
                if ((year == 0) && (month == 0) && (day == 0))
                {
                    return (true);
                }

                if ((year == 0) || (month == 0) || (day == 0))
                {
                    errMsg = "���t���w�肵�Ă��������B";
                    return (false);
                }
            }

            if (year < 1900)
            {
                errMsg = "���������t���w�肵�Ă��������B";
                return (false);
            }

            if (month > 12)
            {
                errMsg = "���������t���w�肵�Ă��������B";
                return (false);
            }

            if (day > DateTime.DaysInMonth(year, month))
            {
                errMsg = "���������t���w�肵�Ă��������B";
                return (false);
            }

            return (true);
        }
        #endregion


        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer	: 30747 �O�� �L��</br>
        /// <br>Date		: 2013/02/15</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // �J�n�]�ƈ��R�[�h
                this._menueStPrintWork.EmployeeCodeSt = this.tNedit_EmployeeCode_St.DataText;
                // �I���]�ƈ��R�[�h
                this._menueStPrintWork.EmployeeCodeEd = this.tNedit_EmployeeCode_Ed.DataText;
                // �����
                this._menueStPrintWork.SortCode = (int)this.tComboEditor_SortCode.Value;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>���l�R�[�h���ڂ̓��e���擾����</br>
        /// <br>�@�R�[�h�l���[���@���@�l�`�w�l</br>
        /// <br>�@�R�[�h�l���[���@���@���͒l</br>
        /// </remarks>
        private int GetEndCode(TNedit tNedit)
        {
            // ��ʏ�R���|�[�l���g��Column�ŏI���R�[�h���擾
            return GetEndCode(tNedit, Int32.Parse(new string('9', (tNedit.ExtEdit.Column))));
        }
        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="endCodeOnDB"></param>
        /// <returns></returns>
        private int GetEndCode(TNedit tNedit, int endCodeOnDB)
        {
            if (tNedit.GetInt() == 0)
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetInt();
            }
        }
        #endregion
        #endregion �� ����O����

        #region �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )
        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 30747 �O�� �L��</br>
        /// <br>Date       : 2013/02/15</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                this._printName,					// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion

        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="procnm">�������\�b�hID</param>
        /// <param name="ex">��O���</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 30747 �O�� �L��</br>
        /// <br>Date       : 2013/02/15</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                this._printName,					// �v���O��������
                procnm, 							// ��������
                "",									// �I�y���[�V����
                errMessage,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion
        #endregion �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )

        #region DataSet�֘A
        /// <summary>
        /// ���j���[����ݒ�N���X�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="menueStSet">���j���[����ݒ�N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���j���[����ݒ�N���X���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : 30747 �O�� �L��</br>
        /// <br>Date       : 2013/02/15</br>
        /// </remarks>
        private void SecPrintSetToDataSet(MenueStSet menueStSet, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }

            if (menueStSet.RoleGroupCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ROLEGROUPCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ROLEGROUPCODE] = menueStSet.RoleGroupCode;
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][ROLEGROUPNAME] = menueStSet.RoleGroupName;

            ReadSfNetMenuNavigator readSfNetMenuNavigator = new ReadSfNetMenuNavigator();
            string[] ClassAndName = new string[3];
            int status = readSfNetMenuNavigator.GetClassAndName(menueStSet.RoleCategoryId, menueStSet.RoleCategorySubId, menueStSet.RoleItemId, out ClassAndName);
            menueStSet.SystemName = ClassAndName[1];

            string wkEmployeeCode = menueStSet.EmployeeCode.Trim();
            if (string.IsNullOrEmpty(wkEmployeeCode)) wkEmployeeCode = "    ";

            switch (this._menueStPrintWork.SortCode)
            {
                case 0:
                    {
                        menueStSet.SortKey = string.Format("{0:D4}", menueStSet.RoleGroupCode) + ClassAndName[2] + wkEmployeeCode;
                        break;
                    }
                case 1:
                    {
                        menueStSet.SortKey = ClassAndName[2] + string.Format("{0:D4}", menueStSet.RoleGroupCode) + wkEmployeeCode;
                        break;
                    }
                case 2:
                    {
                        menueStSet.SortKey = wkEmployeeCode + ClassAndName[2] + string.Format("{0:D4}", menueStSet.RoleGroupCode);
                        break;
                    }
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SORTKEY] = menueStSet.SortKey;

            if (string.IsNullOrEmpty(menueStSet.SystemName)) menueStSet.SystemName = RoleNotDefined;

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][SYSTEMNAME] = menueStSet.SystemName;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EMPLOYEECODE] = menueStSet.EmployeeCode;

            if (menueStSet.EmployeeCode.Trim() == "0000")
            {
                menueStSet.EmployeeName = ct_ZERO_NAME;
            }
            else if (string.IsNullOrEmpty(menueStSet.EmployeeCode))
            {
                menueStSet.EmployeeName = RoleNotDefined;
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EMPLOYEENAME] = menueStSet.EmployeeName;

        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : 30747 �O�� �L��</br>
        /// <br>Date       : 2013/02/15</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable PrintSetTable = new DataTable(PRINTSET_TABLE);

            //Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B

            // --- ADD 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��Q��124 --------->>>>>>>>>>>>>>>>>>>>>>>>
            PrintSetTable.Columns.Add(SORTKEY, typeof(string));                 // �\�[�g�L�[
            // --- ADD 2013/02/25 �O�� 2013/03/06�z�M�� �V�X�e���e�X�g��Q��124 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            PrintSetTable.Columns.Add(ROLEGROUPCODE, typeof(string));		    // ���[���O���[�v�R�[�h
            PrintSetTable.Columns.Add(ROLEGROUPNAME, typeof(string));		    // ���[���O���[�v����
            PrintSetTable.Columns.Add(SYSTEMNAME, typeof(string));              // �V�X�e���@�\
            PrintSetTable.Columns.Add(EMPLOYEECODE, typeof(string));            // �]�ƈ��R�[�h
            PrintSetTable.Columns.Add(EMPLOYEENAME, typeof(string));            // �]�ƈ�����
            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�Ēz����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : 30747 �O�� �L��</br>
        /// <br>Date       : 2013/02/15</br>
        /// </remarks>
        private void DataSetColumnReset()
        {
            DataTable PrintSetTable = this.Bind_DataSet.Tables[PRINTSET_TABLE];

            PrintSetTable.Columns.Clear();

            //Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            if (this._menueStPrintWork != null)
            {
                switch (this._menueStPrintWork.SortCode)
                {
                    case 0:
                        {
                            PrintSetTable.Columns.Add(SORTKEY, typeof(string));                 //  �\�[�g�L�[
                            PrintSetTable.Columns.Add(ROLEGROUPCODE, typeof(string));		    // 	���[���O���[�v�R�[�h
                            PrintSetTable.Columns.Add(ROLEGROUPNAME, typeof(string));		    // 	���[���O���[�v����
                            PrintSetTable.Columns.Add(SYSTEMNAME, typeof(string));              //  �V�X�e���@�\
                            PrintSetTable.Columns.Add(EMPLOYEECODE, typeof(string));            //  �]�ƈ��R�[�h
                            PrintSetTable.Columns.Add(EMPLOYEENAME, typeof(string));            //  �]�ƈ�����
                            break;
                        }
                    case 1:
                        {
                            PrintSetTable.Columns.Add(SORTKEY, typeof(string));                 //  �\�[�g�L�[
                            PrintSetTable.Columns.Add(SYSTEMNAME, typeof(string));              //  �V�X�e���@�\
                            PrintSetTable.Columns.Add(ROLEGROUPCODE, typeof(string));		    // 	���[���O���[�v�R�[�h
                            PrintSetTable.Columns.Add(ROLEGROUPNAME, typeof(string));		    // 	���[���O���[�v����
                            PrintSetTable.Columns.Add(EMPLOYEECODE, typeof(string));            //  �]�ƈ��R�[�h
                            PrintSetTable.Columns.Add(EMPLOYEENAME, typeof(string));            //  �]�ƈ�����
                            break;
                        }
                    default:
                        {
                            PrintSetTable.Columns.Add(SORTKEY, typeof(string));                 //  �\�[�g�L�[
                            PrintSetTable.Columns.Add(EMPLOYEECODE, typeof(string));            //  �]�ƈ��R�[�h
                            PrintSetTable.Columns.Add(EMPLOYEENAME, typeof(string));            //  �]�ƈ�����
                            PrintSetTable.Columns.Add(SYSTEMNAME, typeof(string));              //  �V�X�e���@�\
                            PrintSetTable.Columns.Add(ROLEGROUPCODE, typeof(string));		    // 	���[���O���[�v�R�[�h
                            PrintSetTable.Columns.Add(ROLEGROUPNAME, typeof(string));		    // 	���[���O���[�v����
                            break;
                        }
                }
            }
            else
            {
                PrintSetTable.Columns.Add(SORTKEY, typeof(string));                 // �\�[�g�L�[
                PrintSetTable.Columns.Add(ROLEGROUPCODE, typeof(string));		    // ���[���O���[�v�R�[�h
                PrintSetTable.Columns.Add(ROLEGROUPNAME, typeof(string));		    // ���[���O���[�v����
                PrintSetTable.Columns.Add(SYSTEMNAME, typeof(string));              // �V�X�e���@�\
                PrintSetTable.Columns.Add(EMPLOYEECODE, typeof(string));            // �]�ƈ��R�[�h
                PrintSetTable.Columns.Add(EMPLOYEENAME, typeof(string));            // �]�ƈ�����
            }
        }

        #endregion DataSet�֘A
        #endregion �� Private Method

        #region �� Control Event
        #region �� PMKHN02200UA
        #region �� PMKHN02200UA_Load Event
        /// <summary>
        /// PMKHN02200UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���j���[����ݒ肪̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer	: 30747 �O�� �L��</br>
        /// <br>Date		: 2013/02/15</br>
        /// </remarks>
        private void PMKHN02200UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;


            // �R���g���[��������
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // ��ʃC���[�W����
            this._controlScreenSkin.LoadSkin();						// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.SettingScreenSkin(this);		// ��ʃX�L���ύX

            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N��
        }
        #endregion

        #endregion �� PMKHN02200UA

        /// <summary>
        /// �]�ƈ��K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_EmployeeGuide_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;

            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status != 0) return;

            TNedit targetControl;        
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_EmployeeCode_St;
                nextControl = this.tNedit_EmployeeCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_EmployeeCode_Ed;
                nextControl = this.tComboEditor_LogicalDeleteCode;
            }
            else
            {
                return;
            }
            targetControl.Value = employee.EmployeeCode.TrimEnd();
            // �t�H�[�J�X�ړ�
            nextControl.Focus();
        }

        /// <summary>
        /// �O���[�v���k�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            // ��ɃL�����Z��
            e.Cancel = true;
        }
        /// <summary>
        /// �O���[�v�W�J�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            // ��ɃL�����Z��
            e.Cancel = true;
        }
        
        /// <summary>
        /// �폜�w��ݒ莞
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_LogicalDeleteCode_ValueChanged(object sender, EventArgs e)
        {
            if ((int)tComboEditor_LogicalDeleteCode.Value == 1)
            {
                this.SerchSlipDataStRF_tDateEdit.Enabled = true;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = true;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.Now);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.Now);
            }
            else
            {
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);
            }
        }

        /// <summary>
        /// ������w�莞
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_UserGuideDiv_ValueChanged(object sender, EventArgs e)
        {
        }
        #endregion �� Control Event

        /// <summary>
        /// �f�[�^���L�[���Ƀ\�[�g���čč\�z
        /// </summary>
        private void DataSort()
        {
            if (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count > 0)
            {
                // �f�[�^�Z�b�g�𕡐�
                DataSet Bind_DataSetWk = Bind_DataSet.Copy();

                // ���̃f�[�^�Z�b�g���N���A
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Clear();

                // �f�[�^�Z�b�g���\�[�g�L�[���ɍč\�z
                DataRow[] dataRows = Bind_DataSetWk.Tables[PRINTSET_TABLE].Select("", SORTKEY);
                foreach (DataRow dataRow in dataRows)
                {
                    this.Bind_DataSet.Tables[PRINTSET_TABLE].ImportRow(dataRow);
                }
            }
        }

    }
}
