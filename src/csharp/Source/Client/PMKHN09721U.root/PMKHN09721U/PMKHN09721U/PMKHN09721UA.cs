//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ���[���O���[�v�����ݒ�}�X�^                    //
//                      �t�H�[���N���X                                  //
//                  :   PMKHN09721U.DLL                                 //
// Name Space       :   Broadleaf.Windows.Forms                         //
// Programmer       :   30746 ���� ��                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���[���O���[�v���̐ݒ�}�X�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���[���O���[�v���̐ݒ�}�X�^���s���܂��B
    ///                   IMasterMaintenanceMultiType���������Ă��܂��B</br>
    /// </remarks>
    public class PMKHN09721UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        #region -- Component --

        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraLabel RoleGroupCode_uLabel;
        private Broadleaf.Library.Windows.Forms.TNedit RoleGroupCode_tNedit;
        private Infragistics.Win.Misc.UltraLabel RoleGroupName_uLabel;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Timer;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private UiSetControl uiSetControl1;
        private TEdit RoleGroupName_tEdit;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
        #endregion

        #region -- Constructor --
        /// <summary>
        /// ���[���O���[�v���̐ݒ�}�X�^�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���[���O���[�v���̐ݒ�}�X�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09721UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;

            //  ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �ϐ�������
            this._dataIndex = -1;
            this._roleGroupNameStAcs = new RoleGroupNameStAcs();
            this._totalCount = 0;
            this._roleGroupNameStTable = new Hashtable();

            //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // ���t�擾���i
            this._dateGetAcs = DateGetAcs.GetInstance();
        }
        #endregion

        private System.ComponentModel.IContainer components;

        /// <summary>
        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region -- Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09721UA));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.RoleGroupCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.RoleGroupCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.RoleGroupName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.RoleGroupName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleGroupCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleGroupName_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(543, 126);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 15;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(416, 126);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 14;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 184);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(686, 23);
            this.ultraStatusBar1.TabIndex = 11;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(563, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 61;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // RoleGroupCode_uLabel
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.RoleGroupCode_uLabel.Appearance = appearance10;
            this.RoleGroupCode_uLabel.Location = new System.Drawing.Point(16, 44);
            this.RoleGroupCode_uLabel.Name = "RoleGroupCode_uLabel";
            this.RoleGroupCode_uLabel.Size = new System.Drawing.Size(165, 24);
            this.RoleGroupCode_uLabel.TabIndex = 171;
            this.RoleGroupCode_uLabel.Text = "���[���O���[�v�R�[�h";
            // 
            // RoleGroupCode_tNedit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            this.RoleGroupCode_tNedit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.RoleGroupCode_tNedit.Appearance = appearance9;
            this.RoleGroupCode_tNedit.AutoSelect = true;
            this.RoleGroupCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.RoleGroupCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.RoleGroupCode_tNedit.DataText = "";
            this.RoleGroupCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.RoleGroupCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.RoleGroupCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.RoleGroupCode_tNedit.Location = new System.Drawing.Point(201, 44);
            this.RoleGroupCode_tNedit.MaxLength = 4;
            this.RoleGroupCode_tNedit.Name = "RoleGroupCode_tNedit";
            this.RoleGroupCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.RoleGroupCode_tNedit.Size = new System.Drawing.Size(59, 24);
            this.RoleGroupCode_tNedit.TabIndex = 0;
            // 
            // RoleGroupName_uLabel
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.RoleGroupName_uLabel.Appearance = appearance22;
            this.RoleGroupName_uLabel.Location = new System.Drawing.Point(16, 74);
            this.RoleGroupName_uLabel.Name = "RoleGroupName_uLabel";
            this.RoleGroupName_uLabel.Size = new System.Drawing.Size(165, 24);
            this.RoleGroupName_uLabel.TabIndex = 179;
            this.RoleGroupName_uLabel.Text = "���[���O���[�v����";
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Timer
            // 
            this.Timer.Interval = 1;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(415, 126);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 14;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(287, 126);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 13;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(286, 126);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 13;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // RoleGroupName_tEdit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance12.ForeColor = System.Drawing.Color.Black;
            this.RoleGroupName_tEdit.ActiveAppearance = appearance12;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.ForeColorDisabled = System.Drawing.Color.Black;
            appearance29.TextHAlignAsString = "Left";
            this.RoleGroupName_tEdit.Appearance = appearance29;
            this.RoleGroupName_tEdit.AutoSelect = true;
            this.RoleGroupName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.RoleGroupName_tEdit.DataText = "";
            this.RoleGroupName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.RoleGroupName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.RoleGroupName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.RoleGroupName_tEdit.Location = new System.Drawing.Point(201, 74);
            this.RoleGroupName_tEdit.MaxLength = 20;
            this.RoleGroupName_tEdit.Name = "RoleGroupName_tEdit";
            this.RoleGroupName_tEdit.Size = new System.Drawing.Size(330, 24);
            this.RoleGroupName_tEdit.TabIndex = 1;
            // 
            // PMKHN09721UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(686, 207);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.RoleGroupName_tEdit);
            this.Controls.Add(this.RoleGroupName_uLabel);
            this.Controls.Add(this.RoleGroupCode_tNedit);
            this.Controls.Add(this.RoleGroupCode_uLabel);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09721UA";
            this.Text = "���[���O���[�v���̐ݒ�";
            this.Load += new System.EventHandler(this.PMKHN09721UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09721UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN09721UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.RoleGroupCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleGroupName_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region -- Events --
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region -- Private Members --
        private RoleGroupNameStAcs _roleGroupNameStAcs;
        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _roleGroupNameStTable;

        private SecInfoAcs _secInfoAcs = new SecInfoAcs();

        // ���t�擾���i
        private DateGetAcs _dateGetAcs;

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // �ۑ���r�pClone
        private RoleGroupNameSt _roleGroupNameStClone;

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canSpecificationSearch;

        //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        private int _indexBuf;

        // �V�K���[�h���烂�[�h�ύX�Ή�
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;

        private const string PROGRAM_ID = "PMKHN09721U";    // �v���O����ID

        // View�pGrid�ɕ\��������e�[�u����
        private const string VIEW_TABLE = "VIEW_TABLE";

        // Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const string DELETE_DATE = "�폜��";

        private const string VIEW_ROLEGROUP_CODE = "���[���O���[�v�R�[�h";
        private const string VIEW_ROLEGROUP_NAME = "���[���O���[�v����";

        private const string VIEW_GUID_KEY_TITLE = "Guid";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // ���̓`�F�b�N
        private const string ct_InputError = "�̓��͂��s���ł�";
        private const string ct_NoInput = "����͂��ĉ�����";

        #endregion

        #region -- Main --
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMKHN09721UA());
        }
        # endregion

        #region -- Properties --
        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
        public bool CanClose
        {
            get
            {
                return this._canClose;
            }
            set
            {
                this._canClose = value;
            }
        }

        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
        /// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
        public int DataIndex
        {
            get
            {
                return this._dataIndex;
            }
            set
            {
                this._dataIndex = value;
            }
        }

        /// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
        /// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }
        #endregion

        #region -- Public Methods --
        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note        : �t���[�����̃O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �擪����w�茏�����̃f�[�^���������A</br>
        /// <br>              ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList retList = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._roleGroupNameStTable.Clear();

            // �S����
            status = this._roleGroupNameStAcs.SearchAll(out retList, this._enterpriseCode);
            this._totalCount = retList.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;

                        foreach (RoleGroupNameSt roleGroupNameSt in retList)
                        {
                            // ���[���O���[�v���̐ݒ���N���X�̃f�[�^�Z�b�g�W�J����
                            RoleGroupNameStToDataSet(roleGroupNameSt.Clone(), index);
                            ++index;
                        }
                        break;
                    }

                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }

                default:
                    {
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,            // �G���[���x��
                            PROGRAM_ID,                             // �A�Z���u��ID
                            this.Text,                              // �v���O��������
                            "Search",                               // ��������
                            TMsgDisp.OPE_GET,                       // �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B",             // �\�����郁�b�Z�[�W
                            status,                                 // �X�e�[�^�X�l
                            this._roleGroupNameStAcs,               // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,                   // �\������{�^��
                            MessageBoxDefaultButton.Button1);       // �����\���{�^��

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br></br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // �����Ȃ�
            return 9;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Delete()
        {
            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            RoleGroupNameSt roleGroupNameSt = (RoleGroupNameSt)this._roleGroupNameStTable[guid];

            int status;

            // ���[���O���[�v���̐ݒ���̘_���폜����
            status = this._roleGroupNameStAcs.LogicalDelete(ref roleGroupNameSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // �_���폜
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                            PROGRAM_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,                          // �v���O��������
                            "Delete",                           // ��������
                            TMsgDisp.OPE_HIDE,                  // �I�y���[�V����
                            "�폜�Ɏ��s���܂����B",             // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._roleGroupNameStAcs,           // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
                        return status;
                    }
            }

            // ���[���O���[�v���̐ݒ���N���X�̃f�[�^�Z�b�g�W�J����
            RoleGroupNameStToDataSet(roleGroupNameSt.Clone(), this.DataIndex);

            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ������������s���܂��B(������)</br>
        /// <br></br>
        /// </remarks>
        public int Print()
        {
            return 0;
        }

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note        : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ���[���O���[�v�R�[�h
            appearanceTable.Add(VIEW_ROLEGROUP_CODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���[���O���[�v����
            appearanceTable.Add(VIEW_ROLEGROUP_NAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // Guid
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            return appearanceTable;
        }
        # endregion

        #region -- Private Methods --
        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                RoleGroupNameSt roleGroupNameSt = new RoleGroupNameSt();
                //�N���[���쐬
                this._roleGroupNameStClone = roleGroupNameSt.Clone();
                this._indexBuf = this._dataIndex;

                // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                ScreenToRoleGroupNameSt(ref this._roleGroupNameStClone);

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // �t�H�[�J�X�ݒ�
                this.RoleGroupCode_tNedit.Focus();
            }
            else
            {
                // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                RoleGroupNameSt roleGroupNameSt = (RoleGroupNameSt)this._roleGroupNameStTable[guid];

                // ���[���O���[�v���̐ݒ�N���X��ʓW�J����
                RoleGroupNameStToScreen(roleGroupNameSt);

                if (roleGroupNameSt.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.RoleGroupName_tEdit.Focus();

                    // �N���[���쐬
                    this._roleGroupNameStClone = roleGroupNameSt.Clone();

                    // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                    ScreenToRoleGroupNameSt(ref this._roleGroupNameStClone);
                }
                else
                {
                    // �폜��Ԃ̎�
                    this.Mode_Label.Text = DELETE_MODE;

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">���[�h(�V�K�E�X�V�E�폜)</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    {
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.Renewal_Button.Visible = true;
                        this.RoleGroupName_tEdit.Enabled = true;

                        if (mode == INSERT_MODE)
                        {
                            // �V�K���[�h
                            this.RoleGroupCode_tNedit.Enabled = true;
                        }
                        else
                        {
                            // �X�V���[�h
                            this.RoleGroupCode_tNedit.Enabled = false;
                        }

                        break;
                    }
                case DELETE_MODE:
                    {
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Renewal_Button.Visible = false;
                        this.RoleGroupCode_tNedit.Enabled = false;
                        this.RoleGroupName_tEdit.Enabled = false;

                        break;
                    }
            }
        }

        /// <summary>
        /// ���[���O���[�v���̐ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="roleGroupNameSt">���[���O���[�v���̐ݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void RoleGroupNameStToDataSet(RoleGroupNameSt roleGroupNameSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (roleGroupNameSt.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = roleGroupNameSt.UpdateDateTimeJpInFormal;
            }

            // ���[���O���[�v�R�[�h
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ROLEGROUP_CODE] = roleGroupNameSt.RoleGroupCode;

            // ���[���O���[�v����
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ROLEGROUP_NAME] = roleGroupNameSt.RoleGroupName;

            // Guid
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = roleGroupNameSt.FileHeaderGuid;

            if (this._roleGroupNameStTable.ContainsKey(roleGroupNameSt.FileHeaderGuid) == true)
            {
                this._roleGroupNameStTable.Remove(roleGroupNameSt.FileHeaderGuid);
            }
            this._roleGroupNameStTable.Add(roleGroupNameSt.FileHeaderGuid, roleGroupNameSt);
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///                  �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br></br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable roleGroupNameStTable = new DataTable(VIEW_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B

            roleGroupNameStTable.Columns.Add(DELETE_DATE, typeof(string));                  // �폜��

            roleGroupNameStTable.Columns.Add(VIEW_ROLEGROUP_CODE, typeof(int));             // ���[���O���[�v�R�[�h
            roleGroupNameStTable.Columns.Add(VIEW_ROLEGROUP_NAME, typeof(string));          // ���[���O���[�v����

            roleGroupNameStTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));             // Guid

            this.Bind_DataSet.Tables.Add(roleGroupNameStTable);
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʂ��N���A���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenClear()
        {
            this.RoleGroupCode_tNedit.DataText = "";                // ���[���O���[�v�R�[�h
            this.RoleGroupName_tEdit.DataText = "";                 // ���[���O���[�v����
        }

        /// <summary>
        /// ���[���O���[�v���̐ݒ�N���X��ʓW�J����
        /// </summary>
        /// <param name="roleGroupNameSt">���[���O���[�v���̐ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v���̐ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void RoleGroupNameStToScreen(RoleGroupNameSt roleGroupNameSt)
        {
            // ���[���O���[�v�R�[�h
            this.RoleGroupCode_tNedit.SetInt(roleGroupNameSt.RoleGroupCode);

            // ���[���O���[�v����
            this.RoleGroupName_tEdit.DataText = roleGroupNameSt.RoleGroupName;
        }

        /// <summary>
        /// ��ʏ�񃍁[���O���[�v���̐ݒ�N���X�i�[����
        /// </summary>
        /// <param name="roleGroupNameSt">���[���O���[�v���̐ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂烍�[���O���[�v���̐ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenToRoleGroupNameSt(ref RoleGroupNameSt roleGroupNameSt)
        {
            if (roleGroupNameSt == null)
            {
                // �V�K�̏ꍇ
                roleGroupNameSt = new RoleGroupNameSt();
            }

            //��ƃR�[�h
            roleGroupNameSt.EnterpriseCode = this._enterpriseCode;

            // ���[���O���[�v�R�[�h
            roleGroupNameSt.RoleGroupCode = this.RoleGroupCode_tNedit.GetInt();

            // ���[���O���[�v����
            roleGroupNameSt.RoleGroupName = this.RoleGroupName_tEdit.DataText;
        }

        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="dialogResult">�_�C�A���O����</param>
        /// <remarks>
        /// <br>Note       : �t�H�[������܂��B���̍ۉ�ʃN���[�Y�C�x���g���̔������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // ��r�p�N���[���N���A
            this._roleGroupNameStClone = null;

            // �t�H�[�����\��������B
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br></br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            PROGRAM_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0,                                  // �X�e�[�^�X�l
                            MessageBoxButtons.OK);              // �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            PROGRAM_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0,                                  // �X�e�[�^�X�l
                            MessageBoxButtons.OK);              // �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// ���[���O���[�v���̐ݒ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N����(true:OK�^false:NG)</returns>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v���̐ݒ��ʂ̓��̓`�F�b�N�����܂��B</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            // ���[���O���[�v�R�[�h
            if (this.RoleGroupCode_tNedit.DataText == "")
            {
                message = this.RoleGroupCode_uLabel.Text + "��ݒ肵�ĉ������B";
                control = this.RoleGroupCode_tNedit;
                return false;
            }

            // ���[���O���[�v����
            if (this.RoleGroupName_tEdit.DataText == "")
            {
                message = this.RoleGroupName_uLabel.Text + "��ݒ肵�ĉ������B";
                control = this.RoleGroupName_tEdit;
                return false;
            }

            return true;
        }

        /// <summary>
        ///  �ۑ�����(SaveProc())
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ۑ��������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private bool SaveProc()
        {
            bool result = false;

            //��ʃf�[�^���̓`�F�b�N����
            Control control = null;
            string message = null;

            if (!ScreenDataCheck(ref control, ref message))
            {
                // ���̓`�F�b�N
                TMsgDisp.Show(
                    this,                               // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    PROGRAM_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                    message,                            // �\�����郁�b�Z�[�W
                    0,                                  // �X�e�[�^�X�l
                    MessageBoxButtons.OK);              // �\������{�^��
                control.Focus();
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                else if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                return result;
            }

            RoleGroupNameSt roleGroupNameSt = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                roleGroupNameSt = ((RoleGroupNameSt)this._roleGroupNameStTable[guid]).Clone();
            }

            // ��ʏ����擾
            ScreenToRoleGroupNameSt(ref roleGroupNameSt);
            // �o�^�E�X�V����
            int status = this._roleGroupNameStAcs.Write(ref roleGroupNameSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        RepeatTransaction(status, ref control);
                        control.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, true);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }
                        return false;
                    }
                default:
                    {
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,            // �G���[���x��
                            PROGRAM_ID,                             // �A�Z���u��ID
                            this.Text,                              // �v���O��������
                            "SaveProc",                             // ��������
                            TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B",                 // �\�����郁�b�Z�[�W
                            status,                                 // �X�e�[�^�X�l
                            this._roleGroupNameStAcs,               // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,                   // �\������{�^��
                            MessageBoxDefaultButton.Button1);       // �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return false;
                    }
            }

            // ���[���O���[�v���̐ݒ���N���X�̃f�[�^�Z�b�g�W�J����
            RoleGroupNameStToDataSet(roleGroupNameSt, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
            result = true;
            return result;
        }


        /// <summary>
        ///  ���������b�Z�[�W�\��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �Y���R�[�h���g�p����Ă���ꍇ�Ƀ��b�Z�[�W��\�����܂��B</br>
        /// <br></br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this,                               // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                PROGRAM_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                "���̃R�[�h�͊��Ɏg�p����Ă��܂�",// �\�����郁�b�Z�[�W
                0,                                  // �X�e�[�^�X�l
                MessageBoxButtons.OK);              // �\������{�^��
            RoleGroupCode_tNedit.Focus();

            control = RoleGroupCode_tNedit;
        }

        # endregion

        # region -- Control Events --
        /// <summary>
        /// Form.Load �C�x���g(PMKHN09721UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09721UA_Load(object sender, System.EventArgs e)
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
        }

        /// <summary>
        /// Form.Closing �C�x���g(PMKHN09721UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note        : �t�H�[�������O�ɁA���[�U�[���t�H�[�����
        ///                   �悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09721UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;
            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            //�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        /// Form.VisibleChanged �C�x���g(PMKHN09721UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �t�H�[���̕\���E��\�����؂�ւ����
        ///                   ���Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PMKHN09721UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                // ���C���t���[���A�N�e�B�u��
                this.Owner.Activate();
                return;
            }

            // �������g����\���ɂȂ����ꍇ�A
            // �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            // ��ʃN���A
            ScreenClear();

            Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // �o�^�E�X�V����
            if (!SaveProc())
            {
                return;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʂ̃f�[�^���擾����
                RoleGroupNameSt compareRoleGroupNameSt = new RoleGroupNameSt();

                compareRoleGroupNameSt = this._roleGroupNameStClone.Clone();
                ScreenToRoleGroupNameSt(ref compareRoleGroupNameSt);

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                if ((!(this._roleGroupNameStClone.Equals(compareRoleGroupNameSt))))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
                        PROGRAM_ID,                                           // �A�Z���u���h�c�܂��̓N���X�h�c
                        null,                                                 // �\�����郁�b�Z�[�W
                        0,                                                    // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);                       // �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveProc())
                                {
                                    return;
                                }
                                return;
                            }
                        case DialogResult.No:
                            {
                                // ��ʔ�\���C�x���g
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }
                                break;
                            }
                        default:
                            {
                                // �V�K���[�h���烂�[�h�ύX�Ή�
                                if (_modeFlg)
                                {
                                    RoleGroupCode_tNedit.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                return;
                            }
                    }
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Timer.Tick �C�x���g(timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///                   ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///                   �X���b�h�Ŏ��s����܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            Timer.Enabled = false;

            // ��ʕ\������
            ScreenReconstruction();
        }
        #endregion

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this,                               // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                PROGRAM_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H",                 // �\�����郁�b�Z�[�W
                0,                                  // �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);   // �\������{�^��

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            RoleGroupNameSt roleGroupNameSt = (RoleGroupNameSt)this._roleGroupNameStTable[guid];

            // ���S�폜����
            int status = this._roleGroupNameStAcs.Delete(roleGroupNameSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._roleGroupNameStTable.Remove(roleGroupNameSt.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        // ���S�폜
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                            PROGRAM_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,                          // �v���O��������
                            "Delete_Button_Click",              // ��������
                            TMsgDisp.OPE_DELETE,                // �I�y���[�V����
                            "�폜�Ɏ��s���܂����B",             // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._roleGroupNameStAcs,           // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);  // �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            Guid guid;

            // �����Ώۃf�[�^�擾
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            RoleGroupNameSt roleGroupNameSt = ((RoleGroupNameSt)this._roleGroupNameStTable[guid]).Clone();

            // ��������
            status = this._roleGroupNameStAcs.Revival(ref roleGroupNameSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ���[���O���[�v���̐ݒ���N���X�̃f�[�^�Z�b�g�W�J����
                        RoleGroupNameStToDataSet(roleGroupNameSt, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            PROGRAM_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,                          // �v���O��������
                            "Revive_Button_Click",              // ��������
                            TMsgDisp.OPE_UPDATE,                // �I�y���[�V����
                            "�����Ɏ��s���܂����B",             // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this._roleGroupNameStAcs,           // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // �V�K���[�h���烂�[�h�ύX�Ή�
            _modeFlg = false;

            if (e.PrevCtrl == RoleGroupCode_tNedit)
            {
                // �V�K���[�h���烂�[�h�ύX�Ή�
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // �J�ڐ悪����{�^��
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "Renewal_Button")
                {
                    // �ŐV���{�^���͍X�V�`�F�b�N����O��
                    ;
                }
                else if (this.DataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = RoleGroupCode_tNedit;
                    }
                }
            }
            else if (e.PrevCtrl == Renewal_Button)
            {
                // �ŐV���{�^������̑J�ڎ��A�X�V�`�F�b�N��ǉ�
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // �J�ڐ悪����{�^��
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "RoleGroupCode_tNedit")
                {
                    ;
                }
                else if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = RoleGroupCode_tNedit;
                    }
                }
            }
        }

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            string msg = "���͂��ꂽ�R�[�h�̃��[���O���[�v���̐ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";

            // ���[���O���[�v�R�[�h
            int roleGroupNameCode = RoleGroupCode_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsRoleGroupNameCode = (int)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_ROLEGROUP_CODE];
                if (roleGroupNameCode == dsRoleGroupNameCode)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PROGRAM_ID,                           // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̃��[���O���[�v���̐ݒ���͊��ɍ폜����Ă��܂��B",           // �\�����郁�b�Z�[�W
                          0,                                    // �X�e�[�^�X�l
                          MessageBoxButtons.OK);                // �\������{�^��
                        // ���[���O���[�v�R�[�h�̃N���A
                        RoleGroupCode_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        PROGRAM_ID,                             // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg,                                    // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ���[���O���[�v�R�[�h�̃N���A
                                RoleGroupCode_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// �ŐV���{�^���N���b�N
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();

            TMsgDisp.Show(this,                                 // �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PROGRAM_ID,                           // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B",           // �\�����郁�b�Z�[�W
                          0,                                    // �X�e�[�^�X�l
                          MessageBoxButtons.OK);                // �\������{�^��
        }


    }
}