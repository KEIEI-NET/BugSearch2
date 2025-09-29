//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : TSP�A�g�}�X�^�ݒ�
// �v���O�����T�v   : TSP�A�g�}�X�^�ݒ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11670305-00  �쐬�S�� : 3H ������
// �� �� �� : 2020/11/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// TSP�A�g�}�X�^�ݒ�t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : TSP�A�g�}�X�^�̐ݒ���s���N���X�ł��B</br>
	/// <br>Programmer : 3H ������</br>
	/// <br>Date       : 2020/11/23</br>
    /// </remarks>
	public class PMTSP09000UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region Private Members (Component)
		private System.Data.DataSet Bind_DataSet;
		private System.Windows.Forms.Timer Initial_Timer;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Save_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel CustomerNameCode_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SendCode_Title_Label;
        private Broadleaf.Library.Windows.Forms.TNedit CustomerNameCode_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.Misc.UltraButton CustomerGuide_Button;
		private Broadleaf.Library.Windows.Forms.TEdit CustomerName_tEdit;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
        private TComboEditor SendCode_tComboEditor;
        private TComboEditor DebitNSendCode_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel DebitNSendCode_Title_Label;
        private TNedit SendEnterpriseCode_tNedit;
        private Infragistics.Win.Misc.UltraLabel SendEnterpriseCode_Title_Label;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Constructor
		/// <summary>
        /// TSP�A�g�ݒ�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : TSP�A�g�ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 3H ������</br>
		/// <br>Date       : 2020/11/23</br>
		/// </remarks>
        public PMTSP09000UA()
        {
            InitializeComponent();

            // �v���p�e�B�����l
            this._canClose = false;                       // ����@�\�i�f�t�H���gtrue�Œ�j
            this._canDelete = true;                       // �폜�@�\
            this._canLogicalDeleteDataExtraction = true;  // �_���폜�f�[�^�\���@�\
            this._canNew = true;                          // �V�K�쐬�@�\
            this._canPrint = false;                       // ����@�\
            this._canSpecificationSearch = false;         // �����w�茟���@�\
            this._defaultAutoFillToColumn = false;        // ��T�C�Y���������@�\

            // �f�[�^�Z�b�g������
            this.Bind_DataSet = new DataSet();
            this._tspCprtStWorkTable = new Hashtable();
            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();
            this._customerInfoAcs = new CustomerInfoAcs();
            // TSP�A�g�ݒ�A�N�Z�X
            this._tspCprtStAcs = new TspCprtStAcs();
            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �O���b�h�I���C���f�b�N�X
            this._dataIndex = -1;
            // _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;
        }
		#endregion

        #region Private Members
        /// <summary>TSP�A�g�ݒ�A�N�Z�X�N���X</summary>
        private TspCprtStAcs _tspCprtStAcs;
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>�n�b�V���e�[�u</summary>
        private Hashtable _tspCprtStWorkTable;
        /// <summary>���Ӑ���A�N�Z�X�N���X</summary>
        private CustomerInfoAcs _customerInfoAcs;
        /// <summary>��r�pclone</summary>	
        private TspCprtStWork _compareTspCprtStWork;
		
		// �v���p�e�B�p
		private bool	_canClose;
		private bool	_canDelete;
		private bool	_canLogicalDeleteDataExtraction;
		private bool	_canNew;
		private bool	_canPrint;
		private bool	_canSpecificationSearch;
		private int		_dataIndex;
		private bool	_defaultAutoFillToColumn;
        // _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        private int     _indexBuf;
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;

        /// <summary>�v���O����ID</summary>
        private const string CT_PGID = "PMTSP09000U";

		// Frame��View�pGrid���KEY���i�w�b�_�̃^�C�g�����ƂȂ�܂��B�j
        /// <summary>�e�[�u������</summary>
        public static readonly string TSPCPRTST_TABLE = "TSPCPRTST";
        /// <summary>�폜��</summary>
		private const string DELETE_DATE				= "�폜��";
        /// <summary>���Ӑ�R�[�h</summary>
        private const string CUSTOMERCODE_TITLE         = "���Ӑ�R�[�h";
        /// <summary>���M�敪</summary>
        private const string SENDCODE_TITLE             = "���M�敪";
        /// <summary>�ԓ`���M�敪</summary>
        private const string DEBITNSENDCODE_TITLE       = "�ԓ`���M�敪";
        /// <summary>��ƃR�[�h</summary>
        private const string SENDENTERPRISECODE_TITLE   = "��ƃR�[�h";
        /// <summary>GUID</summary>
		private const string GUID_TITLE					= "GUID";
		
		// �ҏW���[�h
		private const string INSERT_MODE				= "�V�K���[�h";
		private const string UPDATE_MODE				= "�X�V���[�h";
		private const string DELETE_MODE				= "�폜���[�h";
		#endregion

		#region Dispose
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���Ӑ�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMTSP09000UA));
            this.Bind_DataSet = new System.Data.DataSet();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Save_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.CustomerNameCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SendCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerNameCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.SendCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DebitNSendCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DebitNSendCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SendEnterpriseCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SendEnterpriseCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNameCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebitNSendCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendEnterpriseCode_tNedit)).BeginInit();
            this.SuspendLayout();
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(579, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 58;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // CustomerGuide_Button
            // 
            this.CustomerGuide_Button.Location = new System.Drawing.Point(535, 30);
            this.CustomerGuide_Button.Name = "CustomerGuide_Button";
            this.CustomerGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.CustomerGuide_Button.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "���Ӑ�K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.CustomerGuide_Button, ultraToolTipInfo1);
            this.CustomerGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerGuide_Button.Click += new System.EventHandler(this.CustomerGuide_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(175, 226);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 6;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(300, 226);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 7;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Save_Button.Location = new System.Drawing.Point(425, 226);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(125, 34);
            this.Save_Button.TabIndex = 9;
            this.Save_Button.Text = "�ۑ�(&S)";
            this.Save_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(550, 226);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 10;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 262);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(684, 23);
            this.ultraStatusBar1.TabIndex = 59;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // CustomerNameCode_Title_Label
            // 
            appearance68.TextVAlignAsString = "Middle";
            this.CustomerNameCode_Title_Label.Appearance = appearance68;
            this.CustomerNameCode_Title_Label.Location = new System.Drawing.Point(20, 31);
            this.CustomerNameCode_Title_Label.Name = "CustomerNameCode_Title_Label";
            this.CustomerNameCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.CustomerNameCode_Title_Label.TabIndex = 34;
            this.CustomerNameCode_Title_Label.Text = "���Ӑ�";
            // 
            // SendCode_Title_Label
            // 
            appearance33.TextVAlignAsString = "Middle";
            this.SendCode_Title_Label.Appearance = appearance33;
            this.SendCode_Title_Label.Location = new System.Drawing.Point(20, 91);
            this.SendCode_Title_Label.Name = "SendCode_Title_Label";
            this.SendCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.SendCode_Title_Label.TabIndex = 40;
            this.SendCode_Title_Label.Text = "���M�敪";
            // 
            // CustomerNameCode_tNedit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Right";
            appearance10.TextVAlignAsString = "Middle";
            this.CustomerNameCode_tNedit.ActiveAppearance = appearance10;
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance34.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance34.ForeColor = System.Drawing.Color.Black;
            appearance34.ForeColorDisabled = System.Drawing.Color.Black;
            appearance34.TextHAlignAsString = "Right";
            appearance34.TextVAlignAsString = "Middle";
            this.CustomerNameCode_tNedit.Appearance = appearance34;
            this.CustomerNameCode_tNedit.AutoSelect = true;
            this.CustomerNameCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CustomerNameCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerNameCode_tNedit.DataText = "";
            this.CustomerNameCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerNameCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CustomerNameCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CustomerNameCode_tNedit.Location = new System.Drawing.Point(151, 31);
            this.CustomerNameCode_tNedit.MaxLength = 8;
            this.CustomerNameCode_tNedit.Name = "CustomerNameCode_tNedit";
            this.CustomerNameCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.CustomerNameCode_tNedit.Size = new System.Drawing.Size(76, 24);
            this.CustomerNameCode_tNedit.TabIndex = 1;
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(7, 70);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(665, 3);
            this.ultraLabel17.TabIndex = 39;
            // 
            // CustomerName_tEdit
            // 
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance60.ForeColor = System.Drawing.Color.Black;
            appearance60.TextVAlignAsString = "Middle";
            this.CustomerName_tEdit.ActiveAppearance = appearance60;
            appearance61.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance61.ForeColor = System.Drawing.Color.Black;
            appearance61.ForeColorDisabled = System.Drawing.Color.Black;
            appearance61.TextVAlignAsString = "Middle";
            this.CustomerName_tEdit.Appearance = appearance61;
            this.CustomerName_tEdit.AutoSelect = true;
            this.CustomerName_tEdit.DataText = "";
            this.CustomerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CustomerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CustomerName_tEdit.Location = new System.Drawing.Point(257, 31);
            this.CustomerName_tEdit.MaxLength = 16;
            this.CustomerName_tEdit.Name = "CustomerName_tEdit";
            this.CustomerName_tEdit.ReadOnly = true;
            this.CustomerName_tEdit.Size = new System.Drawing.Size(274, 24);
            this.CustomerName_tEdit.TabIndex = 0;
            this.CustomerName_tEdit.TabStop = false;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(300, 226);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 8;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // SendCode_tComboEditor
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextVAlignAsString = "Middle";
            this.SendCode_tComboEditor.ActiveAppearance = appearance11;
            appearance12.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.SendCode_tComboEditor.Appearance = appearance12;
            this.SendCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SendCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            this.SendCode_tComboEditor.ItemAppearance = appearance13;
            valueListItem3.DataValue = "ValueListItem0";
            valueListItem3.DisplayText = "0:����";
            valueListItem4.DataValue = "ValueListItem1";
            valueListItem4.DisplayText = "1:�ꊇ";
            this.SendCode_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.SendCode_tComboEditor.Location = new System.Drawing.Point(151, 90);
            this.SendCode_tComboEditor.Name = "SendCode_tComboEditor";
            this.SendCode_tComboEditor.Size = new System.Drawing.Size(100, 24);
            this.SendCode_tComboEditor.TabIndex = 3;
            // 
            // DebitNSendCode_tComboEditor
            // 
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance65.ForeColor = System.Drawing.Color.Black;
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            appearance65.TextVAlignAsString = "Middle";
            this.DebitNSendCode_tComboEditor.ActiveAppearance = appearance65;
            appearance66.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance66.ForeColor = System.Drawing.Color.Black;
            appearance66.ForeColorDisabled = System.Drawing.Color.Black;
            appearance66.TextVAlignAsString = "Middle";
            this.DebitNSendCode_tComboEditor.Appearance = appearance66;
            this.DebitNSendCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DebitNSendCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance67.ForeColor = System.Drawing.Color.Black;
            appearance67.ForeColorDisabled = System.Drawing.Color.Black;
            this.DebitNSendCode_tComboEditor.ItemAppearance = appearance67;
            valueListItem1.DataValue = "ValueListItem0";
            valueListItem1.DisplayText = "0:����";
            valueListItem2.DataValue = "ValueListItem1";
            valueListItem2.DisplayText = "1:���Ȃ�";
            this.DebitNSendCode_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.DebitNSendCode_tComboEditor.Location = new System.Drawing.Point(151, 134);
            this.DebitNSendCode_tComboEditor.Name = "DebitNSendCode_tComboEditor";
            this.DebitNSendCode_tComboEditor.Size = new System.Drawing.Size(100, 24);
            this.DebitNSendCode_tComboEditor.TabIndex = 4;
            // 
            // DebitNSendCode_Title_Label
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.DebitNSendCode_Title_Label.Appearance = appearance4;
            this.DebitNSendCode_Title_Label.Location = new System.Drawing.Point(20, 135);
            this.DebitNSendCode_Title_Label.Name = "DebitNSendCode_Title_Label";
            this.DebitNSendCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.DebitNSendCode_Title_Label.TabIndex = 61;
            this.DebitNSendCode_Title_Label.Text = "�ԓ`���M�敪";
            // 
            // SendEnterpriseCode_tNedit
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.SendEnterpriseCode_tNedit.ActiveAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.White;
            appearance17.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Right";
            appearance17.TextVAlignAsString = "Middle";
            this.SendEnterpriseCode_tNedit.Appearance = appearance17;
            this.SendEnterpriseCode_tNedit.AutoSelect = true;
            this.SendEnterpriseCode_tNedit.BackColor = System.Drawing.Color.White;
            this.SendEnterpriseCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SendEnterpriseCode_tNedit.DataText = "";
            this.SendEnterpriseCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SendEnterpriseCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.SendEnterpriseCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SendEnterpriseCode_tNedit.Location = new System.Drawing.Point(151, 177);
            this.SendEnterpriseCode_tNedit.MaxLength = 16;
            this.SendEnterpriseCode_tNedit.Name = "SendEnterpriseCode_tNedit";
            this.SendEnterpriseCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.SendEnterpriseCode_tNedit.Size = new System.Drawing.Size(139, 24);
            this.SendEnterpriseCode_tNedit.TabIndex = 5;
            // 
            // SendEnterpriseCode_Title_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.SendEnterpriseCode_Title_Label.Appearance = appearance2;
            this.SendEnterpriseCode_Title_Label.Location = new System.Drawing.Point(20, 177);
            this.SendEnterpriseCode_Title_Label.Name = "SendEnterpriseCode_Title_Label";
            this.SendEnterpriseCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.SendEnterpriseCode_Title_Label.TabIndex = 63;
            this.SendEnterpriseCode_Title_Label.Text = "��ƃR�[�h";
            // 
            // PMTSP09000UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(684, 285);
            this.Controls.Add(this.SendEnterpriseCode_tNedit);
            this.Controls.Add(this.SendEnterpriseCode_Title_Label);
            this.Controls.Add(this.DebitNSendCode_tComboEditor);
            this.Controls.Add(this.DebitNSendCode_Title_Label);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.SendCode_tComboEditor);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.CustomerNameCode_tNedit);
            this.Controls.Add(this.CustomerName_tEdit);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.CustomerNameCode_Title_Label);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.CustomerGuide_Button);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.SendCode_Title_Label);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMTSP09000UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TSP�A�g�}�X�^�ݒ�";
            this.Load += new System.EventHandler(this.PMTSP09000UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMTSP09000UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMTSP09000UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerNameCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebitNSendCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendEnterpriseCode_tNedit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
		}
		#endregion

        #region Main
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMTSP09000UA());
        }
        #endregion

        #region Events
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ������ɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region Properties
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

        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
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

        /// <summary>�V�K�쐬�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�쐬���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>������\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
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
        #endregion

        #region Public Methods
        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̊e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();
            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ���Ӑ�R�[�h
            appearanceTable.Add(CUSTOMERCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���M�敪
            appearanceTable.Add(SENDCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleCenter, "", Color.Black));
            // �ԓ`���M�敪
            appearanceTable.Add(DEBITNSENDCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleCenter, "", Color.Black));
            // ���M��ƃR�[�h
            appearanceTable.Add(SENDENTERPRISECODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // GUID
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleCenter, "", Color.Black));

            return appearanceTable;
        }

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u����</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = TSPCPRTST_TABLE;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCnt">�S�Y������</param>
        /// <param name="readCnt">���o�Ώی���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^���������A���o���ʂ�W�J�����f�[�^�Z�b�g�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int Search(ref int totalCnt, int readCnt)
        {
            return SearchTspCprtStWork(ref totalCnt, readCnt);
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCnt">���o�Ώی���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�茏�����̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int SearchNext(int readCnt)
        {
            // ������
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int Delete()
        {
            return LogicalDelete();
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int Print()
        {
            // ����p�A�Z���u�������[�h����i�������j
            return 0;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCnt">�S�Y������</param>
        /// <param name="readCnt">���o�Ώی���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^���������A���o���ʂ�W�J�����f�[�^�Z�b�g�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int SearchTspCprtStWork(ref int totalCnt, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; ;

            // �f�[�^�Z�b�g�̃N���A
            this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Clear();
            this._tspCprtStWorkTable.Clear();

            // ���������̐ݒ�
            ArrayList tspCprtWorkList = null;
            TspCprtStWork tspCprtWork = new TspCprtStWork();
            tspCprtWork.EnterpriseCode = this._enterpriseCode;

            // ���o�Ώی�����0���̏ꍇ�͑S�����o�����s����
            status = this._tspCprtStAcs.SearchAll(tspCprtWork, out tspCprtWorkList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (TspCprtStWork tspCprtStWork in tspCprtWorkList)
                        {
                            if (this._tspCprtStWorkTable.ContainsKey(tspCprtStWork.FileHeaderGuid) == false)
                            {
                                TspCprtStWorkToDataSet(tspCprtStWork.Clone(), index);
                                index++;
                            }
                        }
                        totalCnt = tspCprtWorkList.Count;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                default:
                    break;
            }
            return status;
        }

        /// <summary>
        /// TSP�A�g�ݒ�I�u�W�F�N�g�W�J����
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�ݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : TSP�A�g�ݒ�N���X��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void TspCprtStWorkToDataSet(TspCprtStWork tspCprtStWork, int index)
        {
            if ((index < 0) || (index >= this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Count))
            {
                // �V�K�Ɣ��f���A�s��ǉ�����B
                DataRow dataRow = this.Bind_DataSet.Tables[TSPCPRTST_TABLE].NewRow();
                this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Add(dataRow);

                // index���ŏI�s�ԍ��ɂ���
                index = this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Count - 1;
            }

            // �_���폜�敪
            if (tspCprtStWork.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][DELETE_DATE] = tspCprtStWork.UpdateDateTimeJpInFormal;
            }

            // ���Ӑ�R�[�h
            this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][CUSTOMERCODE_TITLE] = Convert.ToString(tspCprtStWork.CustomerCode).PadLeft(8, '0');
            // ���M�敪
            if (tspCprtStWork.SendCode == 0)
            {
                this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][SENDCODE_TITLE] = "����";
            }
            else
            {
                this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][SENDCODE_TITLE] = "�ꊇ";
            }

            // �ԓ`���M�敪
            if (tspCprtStWork.DebitNSendCode == 0)
            {
                this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][DEBITNSENDCODE_TITLE] = "����";
            }
            else
            {
                this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][DEBITNSENDCODE_TITLE] = "���Ȃ�";
            }

            // ���M��ƃR�[�h
            this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][SENDENTERPRISECODE_TITLE] = Convert.ToString(tspCprtStWork.SendEnterpriseCode).PadLeft(16, '0');

            // GUID
            this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[index][GUID_TITLE] = tspCprtStWork.FileHeaderGuid;

            if (this._tspCprtStWorkTable.ContainsKey(tspCprtStWork.FileHeaderGuid) == true)
            {
                this._tspCprtStWorkTable.Remove(tspCprtStWork.FileHeaderGuid);
            }
            this._tspCprtStWorkTable.Add(tspCprtStWork.FileHeaderGuid, tspCprtStWork);

        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///                  �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            // TSP�A�g�ݒ�}�X�^�e�[�u��
            DataTable tspCprtStWorkTable = new DataTable(TSPCPRTST_TABLE);
            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            tspCprtStWorkTable.Columns.Add(DELETE_DATE, typeof(string));              // �폜��
            tspCprtStWorkTable.Columns.Add(CUSTOMERCODE_TITLE, typeof(string));       // ���Ӑ�R�[�h
            tspCprtStWorkTable.Columns.Add(SENDCODE_TITLE, typeof(string));           // ���M�敪
            tspCprtStWorkTable.Columns.Add(DEBITNSENDCODE_TITLE, typeof(string));     // �ԓ`���M�敪
            tspCprtStWorkTable.Columns.Add(SENDENTERPRISECODE_TITLE, typeof(string)); // ���M��ƃR�[�h
            tspCprtStWorkTable.Columns.Add(GUID_TITLE, typeof(Guid));                 // GUID
            this.Bind_DataSet.Tables.Add(tspCprtStWorkTable);
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // �{�^���z�u
            int CANCELBUTTONLOCATION_X = this.Cancel_Button.Location.X;
            int OKBUTTONLOCATION_X = this.Save_Button.Location.X;
            int DELETEBUTTONLOCATION_X = this.Renewal_Button.Location.X;
            int BUTTONLOCATION_Y = this.Cancel_Button.Location.Y;
            this.Cancel_Button.Location = new System.Drawing.Point(CANCELBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Save_Button.Location = new System.Drawing.Point(OKBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Revive_Button.Location = new System.Drawing.Point(OKBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Delete_Button.Location = new System.Drawing.Point(DELETEBUTTONLOCATION_X, BUTTONLOCATION_Y);

            // �V�K�̏ꍇ
            if (this._dataIndex < 0)
            {
                // ��ʓ��͋�����
                this.ScreenItemsSetting(0);
                this.CustomerNameCode_tNedit.Focus();
            }
            else
            {
                // �폜�̏ꍇ
                if ((string)this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[this._dataIndex][DELETE_DATE] != "")
                {
                    // ��ʓ��͋�����
                    this.ScreenItemsSetting(2);
                }
                // �X�V�̏ꍇ
                else
                {
                    // ��ʓ��͋�����
                    this.ScreenItemsSetting(1);
                    this.SendCode_tComboEditor.Focus();
                }
            }

        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.CustomerNameCode_tNedit.Clear();		         // ���Ӑ�R�[�h
            this.CustomerName_tEdit.Clear();		             // ���Ӑ於��
            this.SendCode_tComboEditor.SelectedIndex = 0;        // ���M�敪
            this.DebitNSendCode_tComboEditor.SelectedIndex = 0;  // �ԓ`���M�敪
            this.SendEnterpriseCode_tNedit.Clear();		         // ��ƃR�[�h
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            TspCprtStWork tspCprtStWork = new TspCprtStWork();
            tspCprtStWork.EnterpriseCode = this._enterpriseCode;
            // �V�K�̏ꍇ
            if (this._dataIndex < 0)
            {
                // �N���[���쐬
                this._compareTspCprtStWork = tspCprtStWork.Clone();
                // TSP�A�g�}�X�^�ݒ�I�u�W�F�N�g����ʂɓW�J
                TspCprtStWorkToScreen(tspCprtStWork);
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                tspCprtStWork = (TspCprtStWork)this._tspCprtStWorkTable[guid];
                // �N���[���쐬
                this._compareTspCprtStWork = tspCprtStWork.Clone();
                // TSP�A�g�}�X�^�ݒ�I�u�W�F�N�g����ʂɓW�J
                TspCprtStWorkToScreen(this._compareTspCprtStWork);
            }
            // _GridIndex�o�b�t�@�ێ��i���C���t���[���ŏ����Ή��j
            this._indexBuf = this._dataIndex;
        }

        /// <summary>
        /// ��ʏ�������
        /// </summary>
        /// <param name="mode">���[�h(0:�V�K 1:�X�V 2:���W�b�N�폜)</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ��ʏ���������s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : K2018/02/28</br>
        /// </remarks>
        private void ScreenItemsSetting(int mode)
        {
            // �{�^�����䏈��
            this.SetButton(mode);
            // ��ʍ��ڐ��䏈��
            this.SetMenuItem(mode);
        }

        /// <summary>
        /// �{�^�����䏈��
        /// </summary>
        /// <param name="mode">���[�h(0:�V�K 1:�X�V 2:���W�b�N�폜)</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �{�^��������s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void SetButton(int mode)
        {
            // �ۑ��{�^��
            this.Save_Button.Visible = mode == 2 ? false : true;
            // �ŐV���擾�{�^��
            this.Renewal_Button.Visible = mode == 2 ? false : true;
            // �����{�^��
            this.Revive_Button.Visible = mode == 2 ? true : false;
            // ���S�폜�{�^��
            this.Delete_Button.Visible = mode == 2 ? true : false;
        }

        /// <summary>
        /// ��ʍ��ڐ��䏈��
        /// </summary>
        /// <param name="mode">���[�h(0:�V�K 1:�X�V 2:���W�b�N�폜)</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ��ʍ��ڐ�����s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void SetMenuItem(int mode)
        {
            switch (mode)
            {
                case 0:
                    Mode_Label.Text = INSERT_MODE;
                    break;
                case 1:
                    Mode_Label.Text = UPDATE_MODE;
                    break;
                case 2:
                    Mode_Label.Text = DELETE_MODE;
                    break;
                default:
                    Mode_Label.Text = INSERT_MODE;
                    break;
            }

            // ���Ӑ�R�[�h
            this.CustomerNameCode_tNedit.Enabled = mode == 0 ? true : false;
            // ���Ӑ於�̃K�C�h
            this.CustomerGuide_Button.Enabled = mode == 0 ? true : false;
            // ���M�敪
            this.SendCode_tComboEditor.Enabled = mode == 2 ? false : true;
            // �ԓ`���M�敪
            this.DebitNSendCode_tComboEditor.Enabled = mode == 2 ? false : true;
            // ���M��ƃR�[�h
            this.SendEnterpriseCode_tNedit.Enabled = mode == 2 ? false : true;
        }

        /// <summary>
        /// TSP�A�g�ݒ�N���X��ʓW�J����
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : TSP�A�g�ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void TspCprtStWorkToScreen(TspCprtStWork tspCprtStWork)
        {
            // ���Ӑ�R�[�h
            if (tspCprtStWork.CustomerCode == 0)
            {
                this.CustomerNameCode_tNedit.Clear();
                // ���Ӑ於��
                CustomerName_tEdit.Clear();
            }
            else
            {
                // ���Ӑ�R�[�h
                this.CustomerNameCode_tNedit.SetInt(tspCprtStWork.CustomerCode);
                // ���Ӑ於��
                CustomerInfo customerInfo;
                int customerCode = CustomerNameCode_tNedit.GetInt();
                this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                if ((customerInfo != null) && (!string.IsNullOrEmpty(customerInfo.CustomerSnm)))
                {
                    // ���Ӑ於��
                    CustomerName_tEdit.Text = customerInfo.CustomerSnm.TrimEnd();
                }
                else
                {
                    // ���Ӑ於��
                    CustomerName_tEdit.Text = string.Empty;
                }
            }
            this.SendCode_tComboEditor.SelectedIndex = tspCprtStWork.SendCode;		            // ���M�敪
            this.DebitNSendCode_tComboEditor.SelectedIndex = tspCprtStWork.DebitNSendCode;		// �ԓ`���M�敪
            this.SendEnterpriseCode_tNedit.DataText = tspCprtStWork.SendEnterpriseCode;			// ���M��ƃR�[�h
        }

        /// <summary>
        /// TSP�A�g�ݒ�N���X�i�[����
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�TSP�A�g�ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void DispToTspCprtStWork(ref TspCprtStWork tspCprtStWork)
        {
            if (tspCprtStWork == null)
            {
                tspCprtStWork = new TspCprtStWork();
            }
            tspCprtStWork.EnterpriseCode = this._enterpriseCode;					       // ��ƃR�[�h
            tspCprtStWork.CustomerCode = this.CustomerNameCode_tNedit.GetInt();            // ���Ӑ�R�[�h
            tspCprtStWork.SendCode = this.SendCode_tComboEditor.SelectedIndex;             // ���M�敪
            tspCprtStWork.DebitNSendCode = this.DebitNSendCode_tComboEditor.SelectedIndex; // �ԓ`���M�敪
            tspCprtStWork.SendEnterpriseCode = this.SendEnterpriseCode_tNedit.Text.Trim(); // ���M��ƃR�[�h
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N����(true:OK�^false:NG)</returns>
        /// <remarks>
        /// <br>Note       : ��ʓ��͂̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            bool result = false;

            // ���Ӑ�R�[�h
            if (this.CustomerNameCode_tNedit.GetInt() == 0)
            {
                message = this.CustomerNameCode_Title_Label.Text + "����͂��Ă��������B";
                control = this.CustomerNameCode_tNedit;
                return result;
            }

            // ���M��ƃR�[�h
            if (Convert.ToInt64(this.SendEnterpriseCode_tNedit.Value) == 0)
            {
                message = this.SendEnterpriseCode_Title_Label.Text + "����͂��Ă��������B";
                control = this.SendEnterpriseCode_tNedit;
                return result;
            }
            return true; ;
        }

        /// <summary>
        /// TSP�A�g�ݒ�ۑ�����
        /// </summary>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : TSP�A�g�ݒ�̕ۑ����s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private bool SaveProc()
        {
            bool result = false;

            // ���̓`�F�b�N
            Control control = null;
            string message = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                // ���̓`�F�b�N
                TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                              emErrorLevel.ERR_LEVEL_EXCLAMATION,   // �G���[���x��
                              CT_PGID, 						        // �A�Z���u���h�c�܂��̓N���X�h�c
                              message, 							    // �\�����郁�b�Z�[�W
                              0, 									// �X�e�[�^�X�l
                              MessageBoxButtons.OK);				// �\������{�^��
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

            TspCprtStWork tspCprtStWork = null;
            if (this._dataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                tspCprtStWork = ((TspCprtStWork)this._tspCprtStWorkTable[guid]).Clone();
            }
            DispToTspCprtStWork(ref tspCprtStWork);

            int status = this._tspCprtStAcs.Write(ref tspCprtStWork);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // VIEW�̃f�[�^�Z�b�g���X�V
                        TspCprtStWorkToDataSet(tspCprtStWork.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // �R�[�h�d��
                        TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                                      emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
                                      CT_PGID, 							    // �A�Z���u���h�c�܂��̓N���X�h�c
                                      "���̓��Ӑ�͊��Ɏg�p����Ă��܂��B", // �\�����郁�b�Z�[�W
                                      0, 									// �X�e�[�^�X�l
                                      MessageBoxButtons.OK);				// �\������{�^��
                        this.CustomerNameCode_tNedit.Focus();
                        this.CustomerNameCode_tNedit.SelectAll();
                        return result;
                    }
                // �r������
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return result;
                    }
                default:
                    {
                        // �o�^���s
                        TMsgDisp.Show(this,                             // �e�E�B���h�E�t�H�[��
                                      emErrorLevel.ERR_LEVEL_STOP,      // �G���[���x��
                                      CT_PGID,                          // �A�Z���u���h�c�܂��̓N���X�h�c
                                      "TSP�A�g�}�X�^�ݒ�",              // �v���O��������
                                      "SaveProc",                       // ��������
                                      TMsgDisp.OPE_INSERT,              // �I�y���[�V����
                                      "�o�^�Ɏ��s���܂����B",           // �\�����郁�b�Z�[�W
                                      status,                           // �X�e�[�^�X�l
                                      this._tspCprtStAcs,               // �G���[�����������I�u�W�F�N�g
                                      MessageBoxButtons.OK,             // �\������{�^��
                                      MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return result;
                    }
            }

            return true;
        }

        /// <summary>
        /// TSP�A�g�}�X�^�I�u�W�F�N�g�_���폜����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : TSP�A�g�}�X�^�I�u�W�F�N�g�̘_���폜���s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int LogicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Count))
            {
                return -1;
            }

            // ���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            TspCprtStWork tspCprtStWork = ((TspCprtStWork)this._tspCprtStWorkTable[guid]).Clone();

            // TSP�A�g�ݒ肪���݂��Ă��Ȃ�
            if (tspCprtStWork == null)
            {
                return -1;
            }

            status = this._tspCprtStAcs.LogicalDelete(ref tspCprtStWork);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        TspCprtStWorkToDataSet(tspCprtStWork.Clone(), this._dataIndex);
                        break;
                    }
                // �r������
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // �_���폜
                        TMsgDisp.Show(this,                             // �e�E�B���h�E�t�H�[��
                                      emErrorLevel.ERR_LEVEL_STOP,      // �G���[���x��
                                      CT_PGID,                          // �A�Z���u���h�c�܂��̓N���X�h�c
                                      "TSP�A�g�}�X�^�ݒ�",              // �v���O��������
                                      "LogicalDelete",                  // ��������
                                      TMsgDisp.OPE_DELETE,              // �I�y���[�V����
                                      "�폜�Ɏ��s���܂����B",           // �\�����郁�b�Z�[�W
                                      status,                           // �X�e�[�^�X�l
                                      this._tspCprtStAcs,               // �G���[�����������I�u�W�F�N�g
                                      MessageBoxButtons.OK,             // �\������{�^��
                                      MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// TSP�A�g�}�X�^�I�u�W�F�N�g�_���폜��������
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : TSP�A�g�}�X�^�I�u�W�F�N�g�̘_���폜�������s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int Revival()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Count))
            {
                return -1;
            }

            // ���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            TspCprtStWork tspCprtStWork = ((TspCprtStWork)this._tspCprtStWorkTable[guid]).Clone();

            // TSP�A�g�}�X�^�����݂��Ă��Ȃ�
            if (tspCprtStWork == null)
            {
                return -1;
            }

            status = this._tspCprtStAcs.Relive(ref tspCprtStWork);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        TspCprtStWorkToDataSet(tspCprtStWork.Clone(), this._dataIndex);
                        break;
                    }
                // �r������
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // �������s
                        TMsgDisp.Show(this,                             // �e�E�B���h�E�t�H�[��
                                      emErrorLevel.ERR_LEVEL_STOP,      // �G���[���x��
                                      CT_PGID,                          // �A�Z���u���h�c�܂��̓N���X�h�c
                                      "TSP�A�g�}�X�^�ݒ�",              // �v���O��������
                                      "Revival",                        // ��������
                                      TMsgDisp.OPE_RECIEVE,             // �I�y���[�V����
                                      "�����Ɏ��s���܂����B",           // �\�����郁�b�Z�[�W
                                      status,                           // �X�e�[�^�X�l
                                      this._tspCprtStAcs,               // �G���[�����������I�u�W�F�N�g
                                      MessageBoxButtons.OK,             // �\������{�^��
                                      MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// TSP�A�g�ݒ�I�u�W�F�N�g���S�폜����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : TSP�A�g�ݒ�I�u�W�F�N�g�̊��S�폜���s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int PhysicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Count))
            {
                return -1;
            }

            // ���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            TspCprtStWork tspCprtStWork = (TspCprtStWork)this._tspCprtStWorkTable[guid];

            // TSP�A�g�ݒ肪���݂��Ă��Ȃ�
            if (tspCprtStWork == null)
            {
                return -1;
            }

            status = this._tspCprtStAcs.Delete(tspCprtStWork);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �n�b�V���e�[�u������f�[�^���폜
                        this._tspCprtStWorkTable.Remove((Guid)this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[this._dataIndex][GUID_TITLE]);
                        // �f�[�^�Z�b�g����f�[�^���폜
                        this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[this._dataIndex].Delete();
                        break;
                    }
                // �r������
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // �����폜
                        TMsgDisp.Show(this,                             // �e�E�B���h�E�t�H�[��
                                      emErrorLevel.ERR_LEVEL_STOP,      // �G���[���x��
                                      CT_PGID,                          // �A�Z���u���h�c�܂��̓N���X�h�c
                                      "TSP�A�g�}�X�^�ݒ�",              // �v���O��������
                                      "PhysicalDelete",                 // ��������
                                      TMsgDisp.OPE_DELETE,              // �I�y���[�V����
                                      "�폜�Ɏ��s���܂����B",           // �\�����郁�b�Z�[�W
                                      status,                           // �X�e�[�^�X�l
                                      this._tspCprtStAcs,               // �G���[�����������I�u�W�F�N�g
                                      MessageBoxButtons.OK,             // �\������{�^��
                                      MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

		/// <summary>
		/// �r������
		/// </summary>
		/// <param name="status">STATUS</param>
		/// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
		/// <remarks>
		/// <br>Note       : �r���������s���܂�</br>
		/// <br>Programmer : 3H ������</br>
		/// <br>Date       : 2020/11/23</br>
		/// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(this, 							  // �e�E�B���h�E�t�H�[��
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                                      CT_PGID, 						      // �A�Z���u���h�c�܂��̓N���X�h�c
                                      "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                                      0, 								  // �X�e�[�^�X�l
                                      MessageBoxButtons.OK);			  // �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(this, 							  // �e�E�B���h�E�t�H�[��
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                                      CT_PGID, 						      // �A�Z���u���h�c�܂��̓N���X�h�c
                                      "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                                      0, 								  // �X�e�[�^�X�l
                                      MessageBoxButtons.OK);			  // �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="dialogResult">�_�C�A���O����</param>
        /// <remarks>
        /// <br>Note       : �t�H�[������܂��B���̍ۉ�ʃN���[�Y�C�x���g���̔������s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
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
            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
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
		#endregion

        #region Control Events
        /// <summary>
        /// Form.Load �C�x���g(PMTSP09000UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�U���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void PMTSP09000UA_Load(object sender, System.EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Save_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;
            this.Cancel_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.CustomerGuide_Button.ImageList = imageList16;

            this.Save_Button.Appearance.Image = Size24_Index.SAVE;	         // �ۑ��{�^��
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;     // �ŐV���{�^��
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;	     // ����{�^��
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;      // �����{�^��
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;       // ���S�폜�{�^��
            this.CustomerGuide_Button.Appearance.Image = Size16_Index.STAR1; // ���Ӑ�K�C�h�{�^��

            // ��ʂ��\�z
            ScreenInitialSetting();
        }

        /// <summary>
        /// Form.Closing �C�x���g(PMTSP09000UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void PMTSP09000UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // _GridIndex�o�b�t�@������
            this._indexBuf = -2;

            if (this._canClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        /// <summary>
        /// Form.VisibleChanged �C�x���g(PMTSP09000UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void PMTSP09000UA_VisibleChanged(object sender, System.EventArgs e)
        {
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }
            // _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            // �^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ������ꍇ�ȉ��̏������L�����Z������
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            // ��ʏ���������
            ScreenInitialSetting();
            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Timer.Tick �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///                   ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///	                  �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click �C�x���g(save_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void Save_Button_Click(object sender, System.EventArgs e)
        {
            // �o�^
            if (!SaveProc())
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                ScreenClear();
                TspCprtStWork tspCprtStWork = new TspCprtStWork();
                tspCprtStWork.EnterpriseCode = this._enterpriseCode;
                // TSP�A�g�ݒ�I�u�W�F�N�g����ʂɓW�J
                TspCprtStWorkToScreen(tspCprtStWork);
                // �N���[���쐬
                this._compareTspCprtStWork = tspCprtStWork.Clone();
                // _GridIndex�o�b�t�@�ێ�
                this._indexBuf = this._dataIndex;
                CustomerNameCode_tNedit.Focus();

            }
            else
            {
                this.DialogResult = DialogResult.OK;

                // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
                this._indexBuf = -2;
                if (this._canClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ���݂̉�ʏ����擾����
                TspCprtStWork tspCprtStWork = new TspCprtStWork();
                tspCprtStWork = this._compareTspCprtStWork.Clone();
                DispToTspCprtStWork(ref tspCprtStWork);

                // �ŏ��Ɏ擾������ʏ��Ɣ�r
                if (!(this._compareTspCprtStWork.Equals(tspCprtStWork)))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    // �ۑ��m�F
                    DialogResult res = TMsgDisp.Show(
                        this, 								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
                        CT_PGID, 						    // �A�Z���u���h�c�܂��̓N���X�h�c
                        null, 								// �\�����郁�b�Z�[�W
                        0, 									// �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	// �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveProc())
                                {
                                    return;
                                }
                                break;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                        default:
                            {
                                if (_modeFlg)
                                {
                                    CustomerNameCode_tNedit.Focus();
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

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            if (this._canClose)
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
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, System.EventArgs e)
        {
            DialogResult res = TMsgDisp.Show(this,
                     emErrorLevel.ERR_LEVEL_QUESTION,
                     CT_PGID,
                     "���ݕ\������TSP�A�g�}�X�^�ݒ�𕜊����܂��B\r\n��낵���ł����H",
                     0,
                     MessageBoxButtons.YesNo,
                     MessageBoxDefaultButton.Button1);

            if (res != DialogResult.Yes)
            {
                return;
            }

            if (Revival() != 0)
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

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
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                CT_PGID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel, 		// �\������{�^��
                MessageBoxDefaultButton.Button2);	// �����\���{�^��

            if (result == DialogResult.OK)
            {
                if (PhysicalDelete() != 0)
                {
                    return;
                }
            }
            else
            {
                this.Delete_Button.Focus();
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

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
        /// Control.Click �C�x���g(CustomerGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, System.EventArgs e)
        {
            // ���Ӑ�K�C�h�\��
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);

            customerSearchForm.ShowDialog(this);
        }

        #region ���Ӑ�I���K�C�h�{�^���N���b�N���C�x���g
        /// <summary>
        /// ���Ӑ�I���K�C�h�{�^���N���b�N�������C�x���g
        /// </summary>
        /// <param name="sender">PMKHN4002E�t�H�[���I�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ���߂�l�N���X(PMKHN4002E)</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^���N���b�N�C�x���g���s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // �C�x���g�n���h����n�������肩��߂�l�N���X���󂯎��Ȃ���ΏI��
            if (customerSearchRet == null) return;
            string sErrMsg = string.Empty;
            int iERR_LEVEL = 0;
            // DB�f�[�^��ǂݏo��(�L���b�V�����g�p)
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, out customerInfo);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (customerInfo.LogicalDeleteCode == 1)
                        {
                            sErrMsg = "�I���������Ӑ�͊��ɍ폜����Ă��܂��B";
                            iERR_LEVEL = (int)emErrorLevel.ERR_LEVEL_EXCLAMATION;
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    sErrMsg = "�I���������Ӑ�͓��Ӑ�����͂��s���Ă��Ȃ��ׁA�g�p�o���܂���B";
                    iERR_LEVEL = (int)emErrorLevel.ERR_LEVEL_EXCLAMATION;
                    break;
                default:
                    sErrMsg = "���Ӑ���̎擾�Ɏ��s���܂����B";
                    iERR_LEVEL = (int)emErrorLevel.ERR_LEVEL_STOP;
                    break;
            }

            if (!string.IsNullOrEmpty(sErrMsg))
            {

                TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                              (emErrorLevel)iERR_LEVEL, // �G���[���x��
                              CT_PGID,					// �A�Z���u���h�c�܂��̓N���X�h�c
                              sErrMsg,                  // �\�����郁�b�Z�[�W
                              0, 						// �X�e�[�^�X�l
                              MessageBoxButtons.OK);	// �\������{�^��
                CustomerNameCode_tNedit.Clear();
                CustomerName_tEdit.Clear();
                CustomerNameCode_tNedit.Focus();
            }
            else
            {
                // ���Ӑ����UI�ɐݒ�
                this.CustomerNameCode_tNedit.SetInt(customerInfo.CustomerCode);
                this.CustomerName_tEdit.Text = customerInfo.CustomerSnm.TrimEnd();
                SendCode_tComboEditor.Focus();
            }
        }
        #endregion

        /// <summary>
        /// ���Ӑ�ύX����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ύX�����B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private Control SetCustomerCode()
        {
            Control e = null;

            // ���Ӑ�R�[�h�����͂̏ꍇ�A
            int iCustomerCode = CustomerNameCode_tNedit.GetInt();

            if (iCustomerCode == 0)
            {
                return e;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            TspCprtStWork tspCprtStWork = new TspCprtStWork();
            tspCprtStWork.EnterpriseCode = this._enterpriseCode;
            string sErrMsg = string.Empty;
            int iERR_LEVEL = 0;

            // �O���b�h����f�[�^���擾����
            for (int i = 0; i < this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                Int32 tempCustomerCd = Convert.ToInt32(this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[i][CUSTOMERCODE_TITLE].ToString().Trim());
                if (tempCustomerCd == iCustomerCode)
                {
                    this._dataIndex = i;
                    Guid guid = (Guid)this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows[i][GUID_TITLE];
                    tspCprtStWork = (TspCprtStWork)this._tspCprtStWorkTable[guid];
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                DialogResult res = TMsgDisp.Show(this,                                   // �e�E�B���h�E�t�H�[��
                                                 emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                                                 CT_PGID,                                // �A�Z���u���h�c�܂��̓N���X�h�c
                                                 "���͂��ꂽ�R�[�h��TSP�A�g�}�X�^�ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                                                 0,                                      // �X�e�[�^�X�l
                                                 MessageBoxButtons.YesNo);               // �\������{�^��
                switch (res)
                {
                    case DialogResult.Yes:
                        {

                            // ��ʓW�J����
                            TspCprtStWorkToScreen(tspCprtStWork);
                            this._compareTspCprtStWork = tspCprtStWork.Clone();
                            // ���W�b�N�폜�̏ꍇ
                            if (tspCprtStWork.LogicalDeleteCode == 1)
                            {
                                // ��ʓ��͋�����
                                this.ScreenItemsSetting(2);

                            }
                            // �X�V�̏ꍇ
                            else
                            {
                                // ��ʓ��͋�����
                                this.ScreenItemsSetting(1);
                            }
                            break;
                        }
                    case DialogResult.No:
                        {
                            // ���Ӑ�R�[�h�̃N���A
                            CustomerNameCode_tNedit.Clear();
                            CustomerName_tEdit.Clear();
                            e = CustomerNameCode_tNedit;
                            return e;
                        }
                }

            }
            else
            {
                CustomerInfo customerInfo;
                status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, iCustomerCode, out customerInfo);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            if (customerInfo.LogicalDeleteCode == 1)
                            {
                                sErrMsg = "���͂������Ӑ�͊��ɍ폜����Ă��܂��B";
                                iERR_LEVEL = (int)emErrorLevel.ERR_LEVEL_EXCLAMATION;
                            }
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        sErrMsg = "���͂������Ӑ�͓��Ӑ�����͂��s���Ă��Ȃ��ׁA�g�p�o���܂���B";
                        iERR_LEVEL = (int)emErrorLevel.ERR_LEVEL_EXCLAMATION;
                        break;
                    default:
                        sErrMsg = "���Ӑ���̎擾�Ɏ��s���܂����B";
                        iERR_LEVEL = (int)emErrorLevel.ERR_LEVEL_STOP;
                        break;
                }

                if (!string.IsNullOrEmpty(sErrMsg))
                {
                    TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                      (emErrorLevel)iERR_LEVEL,             // �G���[���x��
                      CT_PGID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                      sErrMsg,                              // �\�����郁�b�Z�[�W
                      0, 									// �X�e�[�^�X�l
                      MessageBoxButtons.OK);				// �\������{�^��
                    CustomerNameCode_tNedit.Text = string.Empty;
                    CustomerName_tEdit.Text = string.Empty;
                    e = CustomerNameCode_tNedit;
                }
                else
                {

                    tspCprtStWork.CustomerCode = customerInfo.CustomerCode;
                    // ��ʓ��͋�����
                    this.ScreenItemsSetting(0);
                    // ��ʓW�J����
                    TspCprtStWorkToScreen(tspCprtStWork);
                    this._compareTspCprtStWork = tspCprtStWork.Clone();
                    this.CustomerNameCode_tNedit.SetInt(customerInfo.CustomerCode);
                    this.CustomerName_tEdit.Text = customerInfo.CustomerSnm.TrimEnd();
                    e = SendCode_tComboEditor;
                }

            }
            return e;
        }

        /// <summary>
        /// tArrowKeyControlChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[���̃t�H�[�J�X���ς��^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer	: 3H ������</br>
        /// <br>Date		: 2020/11/23</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                return;
            }
            _modeFlg = false;

            switch (e.PrevCtrl.Name)
            {
                // ���Ӑ�R�[�h
                case "CustomerNameCode_tNedit":
                    {
                        // ���Ӑ�R�[�h�Č���
                        Control control = this.SetCustomerCode();

                        if (control != null)
                        {
                            e.NextCtrl = control;
                        }

                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// Renewal_Button Click�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: Renewal_Button Click�C�x���g�B</br>
        /// <br>Programmer	: 3H ������</br>
        /// <br>Date		: 2020/11/23</br>
        /// </remarks>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // ���������̐ݒ�
            ArrayList tspCprtWorkList = null;
            this._customerInfoAcs = new CustomerInfoAcs();
            // TSP�A�g�ݒ�A�N�Z�X
            this._tspCprtStAcs = new TspCprtStAcs();
            TspCprtStWork tspCprtWork = new TspCprtStWork();
            tspCprtWork.EnterpriseCode = this._enterpriseCode;
            // ���o�Ώی�����0���̏ꍇ�͑S�����o�����s����
            status = this._tspCprtStAcs.SearchAll(tspCprtWork, out tspCprtWorkList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        // �f�[�^�Z�b�g�̃N���A
                        this.Bind_DataSet.Tables[TSPCPRTST_TABLE].Rows.Clear();
                        this._tspCprtStWorkTable.Clear();
                        foreach (TspCprtStWork tspCprtStWork in tspCprtWorkList)
                        {
                            if (this._tspCprtStWorkTable.ContainsKey(tspCprtStWork.FileHeaderGuid) == false)
                            {
                                if (tspCprtStWork.CustomerCode == CustomerNameCode_tNedit.GetInt())
                                {
                                    // �N���[���쐬
                                    this._compareTspCprtStWork = tspCprtStWork.Clone();
                                    // TSP�A�g�}�X�^�ݒ�I�u�W�F�N�g����ʂɓW�J
                                    TspCprtStWorkToScreen(this._compareTspCprtStWork);
                                }
                                TspCprtStWorkToDataSet(tspCprtStWork.Clone(), index);
                                index++;
                            }
                        }

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }
                        TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                                      emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                                      CT_PGID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                                      "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                                      0, 									// �X�e�[�^�X�l
                                      MessageBoxButtons.OK);				// �\������{�^��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    break;
                default:
                    TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                                  emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                                  CT_PGID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                                  "�ŐV�����擾���s�B", 			// �\�����郁�b�Z�[�W
                                  0, 									// �X�e�[�^�X�l
                                  MessageBoxButtons.OK);				// �\������{�^��
                    break;
            }
        }
        #endregion

    }
}