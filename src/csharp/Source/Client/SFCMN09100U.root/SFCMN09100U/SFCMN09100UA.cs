# region ��using
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
# endregion

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �ԍ��Ǘ��ݒ���̓t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �ԍ��Ǘ��ݒ���s���܂��B
	///					  IMasterMaintenanceArrayType���������Ă��܂��B</br>
	/// <br>Programmer	: 22033 �O��  �M�j</br>
	/// <br>Date		: 2005.09.09</br>
	/// <br>Update Note	: 2006.09.01 22033 �O�� �M�j</br>
	/// <br>			: �E�Z���̒l��null�ɂ��Ĕ��������̃G���[�Ή��iUltraGrid�o�O�Ή��j</br>
	/// <br>			: �EGrid��KeyPress�C�x���g�̃��W�b�N�C���i����L�[�V���[�g�J�b�g���o���Ȃ������ׁj</br>
	/// <br>Update Note	: 2006.09.07 22033 �O�� �M�j</br>
	/// <br>			: �E�ۑ��`�F�b�NNG��Write���s���Ă��Ȃ����ɁA�t���[���O���b�h�Ɠ��������Ă���Hashtable�������������Ă����ׂɁA</br>
	/// <br>			:   �t���[���O���b�h�̃f�[�^���X�V����Ă����G���[�C��</br>
	/// <br></br>
	/// <br>			: 2007.02.06 18322 T.Kimura MA.NS�p�ɕύX</br>
	/// <br>			:                           �E��ʃX�L���ύX�Ή�</br>
    /// <br>Update Note : 2007.05.23 980023 �ђJ �k��</br>
    /// <br>            : �E���_���̎擾��������[�g�ɏC��</br>
    /// <br>Update Note : 2008.09.25 30413 ����</br>
    /// <br>            : �EPM.NS�Ή�</br>
    /// </remarks>
	public class SFCMN09100UA : System.Windows.Forms.Form, IMasterMaintenanceArrayType
	{
		# region ��Private Members (Component)

		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Data.DataSet Bind_DataSet;
		private Infragistics.Win.UltraWinGrid.UltraGrid NoMngSet_uGrid;
		private Broadleaf.Library.Windows.Forms.TEdit SectionNm_tEdit;
        private Infragistics.Win.Misc.UltraButton InitSet_Button;
		private System.ComponentModel.IContainer components;

		# endregion

		# region ��Constructor
		/// <summary>
		/// �ԍ��Ǘ��ݒ���̓t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �ԍ��Ǘ��ݒ���̓t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public SFCMN09100UA()
		{
			InitializeComponent();
			// �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ�
			this._canPrint					= false;
			this._canClose					= true;
			this._canNew					= false;
			this._canDelete					= false;
			this._mainGridTitle				= "���_";
			this._detailsGridTitle			= "�ԍ��ݒ�";
			this._defaultGridDisplayLayout	= MGridDisplayLayout.Vertical;

			// ��ƃR�[�h���擾
			this._enterpriseCode			= LoginInfoAcquisition.EnterpriseCode;

			// �ϐ�������
			this._targetTableName			= "";
			this._mainDataIndex				= -1;
			this._detailsDataIndex			= -1;
			this._noMngSetAcs				= new NoMngSetAcs();
            // ----- iitani c ----- start 2007.05.23
            //this._secInfoAcs = new SecInfoAcs();
            this._secInfoAcs = new SecInfoAcs(1);   // searchMode(0:���[�J�� 1:�����[�g)
            // ----- iitani c ----- end 2007.05.23
			this._secInfoSetTable			= new Hashtable();
			this._noTypeMngTable			= new Hashtable();
			this._noMngSetTable				= new Hashtable();
			//GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			this._detailsIndexBuf			= -2;
			this._mainIndexBuf				= -2;
			// �ҏWCheck�pList
			this._noMngSetClone				= new ArrayList();
		}
		# endregion

		# region ��Dispose
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		# endregion

		#region ��Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN09100UA));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.NoMngSet_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.SectionNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.InitSet_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoMngSet_uGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(788, 416);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 3;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(664, 416);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 2;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(812, 8);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 160;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 463);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(920, 23);
            this.ultraStatusBar1.TabIndex = 163;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
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
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // NoMngSet_uGrid
            // 
            this.NoMngSet_uGrid.Cursor = System.Windows.Forms.Cursors.Arrow;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance4.BackColor2 = System.Drawing.Color.White;
            this.NoMngSet_uGrid.DisplayLayout.Appearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.NoMngSet_uGrid.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            this.NoMngSet_uGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.NoMngSet_uGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.NoMngSet_uGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            this.NoMngSet_uGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.NoMngSet_uGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.NoMngSet_uGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NoMngSet_uGrid.DisplayLayout.Override.EditCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.FontData.BoldAsString = "False";
            appearance7.FontData.Name = "Arial";
            appearance7.FontData.SizeInPoints = 10F;
            appearance7.ForeColor = System.Drawing.Color.White;
            appearance7.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.NoMngSet_uGrid.DisplayLayout.Override.HeaderAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.Lavender;
            this.NoMngSet_uGrid.DisplayLayout.Override.RowAlternateAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.NoMngSet_uGrid.DisplayLayout.Override.RowAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.ForeColor = System.Drawing.Color.White;
            this.NoMngSet_uGrid.DisplayLayout.Override.RowSelectorAppearance = appearance10;
            this.NoMngSet_uGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.NoMngSet_uGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.ForeColor = System.Drawing.Color.Black;
            this.NoMngSet_uGrid.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.NoMngSet_uGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.NoMngSet_uGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.NoMngSet_uGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.NoMngSet_uGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Vertical;
            this.NoMngSet_uGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            appearance12.BackColor = System.Drawing.Color.White;
            this.NoMngSet_uGrid.DisplayLayout.SplitterBarHorizontalAppearance = appearance12;
            this.NoMngSet_uGrid.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NoMngSet_uGrid.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.NoMngSet_uGrid.Location = new System.Drawing.Point(12, 44);
            this.NoMngSet_uGrid.Name = "NoMngSet_uGrid";
            this.NoMngSet_uGrid.Size = new System.Drawing.Size(900, 358);
            this.NoMngSet_uGrid.TabIndex = 1;
            this.NoMngSet_uGrid.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.NoMngSet_uGrid_BeforeEnterEditMode);
            this.NoMngSet_uGrid.AfterExitEditMode += new System.EventHandler(this.NoMngSet_uGrid_AfterExitEditMode);
            this.NoMngSet_uGrid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.NoMngSet_uGrid_InitializeLayout);
            this.NoMngSet_uGrid.BeforeSelectChange += new Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventHandler(this.NoMngSet_uGrid_BeforeSelectChange);
            this.NoMngSet_uGrid.BeforeExitEditMode += new Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler(this.NoMngSet_uGrid_BeforeExitEditMode);
            this.NoMngSet_uGrid.AfterRowActivate += new System.EventHandler(this.NoMngSet_uGrid_AfterRowActivate);
            this.NoMngSet_uGrid.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.NoMngSet_uGrid_InitializeRow);
            this.NoMngSet_uGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoMngSet_uGrid_KeyPress);
            this.NoMngSet_uGrid.Leave += new System.EventHandler(this.NoMngSet_uGrid_Leave);
            this.NoMngSet_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoMngSet_uGrid_KeyDown);
            this.NoMngSet_uGrid.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.NoMngSet_uGrid_BeforeRowDeactivate);
            this.NoMngSet_uGrid.AfterCellActivate += new System.EventHandler(this.NoMngSet_uGrid_AfterCellActivate);
            // 
            // SectionNm_tEdit
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SectionNm_tEdit.ActiveAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionNm_tEdit.Appearance = appearance3;
            this.SectionNm_tEdit.AutoSelect = true;
            this.SectionNm_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SectionNm_tEdit.DataText = "";
            this.SectionNm_tEdit.Enabled = false;
            this.SectionNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, true, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SectionNm_tEdit.Location = new System.Drawing.Point(12, 8);
            this.SectionNm_tEdit.MaxLength = 6;
            this.SectionNm_tEdit.Name = "SectionNm_tEdit";
            this.SectionNm_tEdit.Size = new System.Drawing.Size(115, 24);
            this.SectionNm_tEdit.TabIndex = 0;
            // 
            // InitSet_Button
            // 
            this.InitSet_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.InitSet_Button.Location = new System.Drawing.Point(455, 416);
            this.InitSet_Button.Name = "InitSet_Button";
            this.InitSet_Button.Size = new System.Drawing.Size(161, 34);
            this.InitSet_Button.TabIndex = 2;
            this.InitSet_Button.Text = "�����l�Z�b�g(&D)";
            this.InitSet_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.InitSet_Button.Click += new System.EventHandler(this.InitSet_Button_Click);
            // 
            // SFCMN09100UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(920, 486);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.SectionNm_tEdit);
            this.Controls.Add(this.NoMngSet_uGrid);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.InitSet_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Mode_Label);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFCMN09100UA";
            this.Text = "�ԍ��Ǘ��ݒ�";
            this.Load += new System.EventHandler(this.SFCMN09100UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFCMN09100UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFCMN09100UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoMngSet_uGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region ��IMasterMaintenanceArrayType�����o�[

		# region ��Events
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region ��Properties
		/// <summary>����\�ݒ�v���p�e�B</summary>
		/// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanPrint
		{
			get
			{
				return this._canPrint;
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

		/// <summary>�폜�\�ݒ�v���p�e�B</summary>
		/// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanDelete
		{
			get
			{
				return this._canDelete;
			}
		}

		/// <summary>�O���b�h�̃f�t�H���g�\���ʒu�v���p�e�B</summary>
		/// <value>�O���b�h�̃f�t�H���g�\���ʒu���擾���܂��B</value>
		public MGridDisplayLayout DefaultGridDisplayLayout
		{
			get
			{
				return this._defaultGridDisplayLayout;
			}
		}

		/// <summary>����Ώۃf�[�^�e�[�u�����̃v���p�e�B</summary>
		/// <value>�{���Ώۃf�[�^�̃e�[�u�����̂��擾�܂��͐ݒ肵�܂��B</value>
		public string TargetTableName
		{
			get
			{
				return this._targetTableName;
			}
			set
			{
				this._targetTableName = value;
			}
		}
		# endregion

		# region ��Public Methods
		/// <summary>
		/// �_���폜�f�[�^���o�\�ݒ胊�X�g�擾����
		/// </summary>
		/// <returns>�_���폜�f�[�^���o�\�ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �_���폜�f�[�^�̒��o���\���ǂ����̐ݒ��z��Ŏ擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public bool[] GetCanLogicalDeleteDataExtractionList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= false;
			return blRet;
		}

		/// <summary>
		/// �O���b�h�^�C�g�����X�g�擾����
		/// </summary>
		/// <returns>�O���b�h�^�C�g�����X�g</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h�̃^�C�g����z��Ŏ擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public string[] GetGridTitleList()
		{
			string[] strRet	= new string[2];
			strRet[0]		= this._mainGridTitle;
			strRet[1]		= this._detailsGridTitle;
			return strRet;
		}

		/// <summary>
		/// �O���b�h�A�C�R�����X�g�擾����
		/// </summary>
		/// <returns>�O���b�h�A�C�R�����X�g</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h�̃A�C�R����z��Ŏ擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public Image[] GetGridIconList()
		{
			Image[] objRet	= new Image[2];
			objRet[0]		= null;
			objRet[1]		= null;
			return objRet;
		}

		/// <summary>
		/// �O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g�擾����
		/// </summary>
		/// <returns>�O���b�h��̃T�C�Y�̎��������̃f�t�H���g�l���X�g</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l��z��Ŏ擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public bool[] GetDefaultAutoFillToGridColumnList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= false;
			return blRet;
		}

		/// <summary>
		/// �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g�ݒ菈��
		/// </summary>
		/// <param name="indexList">�f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�e�[�u���̑I���f�[�^�C���f�b�N�X���X�g��ݒ肵�܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public void SetDataIndexList(int[] indexList)
		{
			int[] intVal			= indexList;
			this._mainDataIndex		= intVal[0];
			this._detailsDataIndex	= intVal[1];
		}

		/// <summary>
		/// �V�K�{�^���̗L���ݒ胊�X�g�擾����
		/// </summary>
		/// <returns>�V�K�{�^���̗L���ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �V�K�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public bool[] GetNewButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= false;

			return blRet;
		}

		/// <summary>
		/// �C���{�^���̗L���ݒ胊�X�g�擾����
		/// </summary>
		/// <returns>�C���{�^���̗L���ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �C���{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public bool[] GetModifyButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
            // 2008.09.23 30413 ���� ���_���ŏC���{�^����L�� >>>>>>START
            //blRet[0]		= false;
            //blRet[1]		= true;
            blRet[0] = true;
            blRet[1] = false;
            // 2008.09.23 30413 ���� ���_���ŏC���{�^����L�� <<<<<<END
            return blRet;
		}

		/// <summary>
		/// �폜�{�^���̗L���ݒ胊�X�g�擾����
		/// </summary>
		/// <returns>�폜�{�^���̗L���ݒ胊�X�g</returns>
		/// <remarks>
		/// <br>Note       : �폜�{�^���̗L���ݒ胊�X�g���擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public bool[] GetDeleteButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= false;

			return blRet;
		}

		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet"></param>
		/// <param name="tableName"></param>
		/// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		/// 
		public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
		{
			bindDataSet = this.Bind_DataSet;

			string[] strRet	= new string[3];
			strRet[0]		= SECTION_TABLE;
			strRet[1]		= NOMNGSET_TABLE;
			// UI_Grid�p
			strRet[2]		= UIGRID_TABLE;
			tableName		= strRet;
		}

		/// <summary>
		/// ���_���ݒ茟������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �擪���狒�_���ݒ�}�X�^���������A
		///					 ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			int index = 0;
			SecInfoSet dummy = new SecInfoSet();

			// �S�Ћ��ʕ��Z�b�g
			SecInfoSetToDataSet(dummy, index);
			index++;

			foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
			{
				// ���_Table�W�J����
				SecInfoSetToDataSet(secInfoSet.Clone(), index);
				++index;
			}

			totalCount = 0;
			return status;
		}

		/// <summary>
		/// �l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			// �����Ȃ�
			return 9;
		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ茟������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �擪����ԍ��Ǘ��ݒ�}�X�^���������A
		///					 ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int DetailsDataSearch(ref int totalCount, int readCount)
		{
			int status = 0;
			int index = 0;
			string hashKey;
			ArrayList noMngSetList = null;
			ArrayList noTypeMngList = null;

			// ���C���t���[���������UI��ʏI�������pClear����
			this._detailsIndexBuf = -2;

			// Buffer�������ꍇ�̂݃����[�e�B���O
			if ((this._noMngSetTable.Count == 0) &&
				(this._noTypeMngTable.Count == 0))
			{
				status = this._noMngSetAcs.Search(out noMngSetList, out noTypeMngList, this._enterpriseCode);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// �ԍ��ݒ茟������
						foreach (NoMngSet noMngSet in noMngSetList)
						{
							// HashKey��Primary Key
							hashKey = noMngSet.SectionCode.TrimEnd() + "_" + noMngSet.NoCode.ToString();

                            if (_noMngSetTable.ContainsKey(hashKey) != true)
                            {
							    // Buffer�Ɋi�[
							    this._noMngSetTable.Add(hashKey, noMngSet);
                            }
						}

						// �ԍ��^�C�v�Ǘ���������
						foreach (NoTypeMng noTypeMng in noTypeMngList)
						{
							// HashKey��Primary Key
							hashKey = noTypeMng.NoCode.ToString();
							
                            if (_noTypeMngTable.ContainsKey(hashKey) != true)
                            {
                                // Buffer�Ɋi�[
                                this._noTypeMngTable.Add(hashKey, noTypeMng);
                            }
						}

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						return status;
					}
					default:
					{
						TMsgDisp.Show(
							this,								  // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
							ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
							this.Text,							  // �v���O��������
							"DetailsDataSearch",				  // ��������
							TMsgDisp.OPE_GET,					  // �I�y���[�V����
							ERR_READ_MSG,						  // �\�����郁�b�Z�[�W 
							status,								  // �X�e�[�^�X�l
							this._noMngSetAcs,					  // �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,				  // �\������{�^��
							MessageBoxDefaultButton.Button1);	  // �����\���{�^��

						return status;
					}
				}
			}

			// �I������Ă��鋒�_�����擾����
			string sectionCode = this.Bind_DataSet.Tables[SECTION_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE].ToString();
			SecInfoSet secInfoSet = (SecInfoSet)this._secInfoSetTable[sectionCode];

			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows.Clear();

			SortedList sortList = new SortedList();

			// �e���_��
			if (secInfoSet != null)
			{
				// Sort
				foreach (NoMngSet noMngSet in this._noMngSetTable.Values)
				{
					if (noMngSet.SectionCode.TrimEnd() == secInfoSet.SectionCode.TrimEnd())
					{
						sortList.Add(noMngSet.NoCode, noMngSet);
					}
				}
			}
			// �S�Ћ���
			else
			{
				// Sort
				foreach (NoMngSet noMngSet in this._noMngSetTable.Values)
				{
					if (noMngSet.SectionCode == DUMMYSECCD)
					{
						sortList.Add(noMngSet.NoCode, noMngSet);
					}
				}
			}

			foreach (NoMngSet noMngSet in sortList.Values)
			{
				// �ԍ��ݒ�Table�W�J����
				NoMngSetToDataSet(noMngSet.Clone(), (NoTypeMng)this._noTypeMngTable[noMngSet.NoCode.ToString()], index);
				++index;
			}

			totalCount = 0;
			return status;
		}

		/// <summary>
		/// ���׃l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int DetailsDataSearchNext(int readCount)
		{
			// ������
			return 9;
		}

		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B(������)</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Delete()
		{
			// ������
			return 0;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B(������)</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Print()
		{
			// ����@�\�����̈ז�����
			return 0;
		}

		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public void GetAppearanceTable(out Hashtable[] appearanceTable)
		{
			// MainGrid
			Hashtable main = new Hashtable();
			main.Add(SECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			main.Add(SECTIONNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

			// DetailsGrid
			Hashtable details = new Hashtable();
			details.Add(NOCODE_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleRight, "", Color.Black));
			details.Add(NONAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(NOITEMPATTERNCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(NOCHARCTERCOUNT_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
			details.Add(CONSNOCHRCTERCOUNT_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
			details.Add(NODISPPOSITIONDIVCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(NUMBERINGTYPE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(NUMBERINGAMBITDIVCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			details.Add(NOPRESENTVAL_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
			details.Add(SETTINGSTARTNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
			details.Add(SETTINGENDNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
			details.Add(NOINCDECWIDTH_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

			appearanceTable = new Hashtable[2];
			appearanceTable[0] = main;
			appearanceTable[1] = details;
		}
		# endregion

		# endregion

		# region ��Private Members
		private NoMngSetAcs _noMngSetAcs;
		private SecInfoAcs _secInfoAcs;
		private string _enterpriseCode;
		private Hashtable _secInfoSetTable;
		private Hashtable _noMngSetTable;
		private Hashtable _noTypeMngTable;
		//_GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _detailsIndexBuf;
		private int _mainIndexBuf;
		// GridFocus�J�ڗp
		private int _leaveRowBuf;
		private int _leaveColBuf;
		// �ҏWCheck�pList
		private ArrayList _noMngSetClone;

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		# region ��IMasterMaintenanceArrayType�p

		# region ���v���p�e�B�p
		/// <summary>����{�^��Visible</summary>
		private bool _canPrint;
		/// <summary>����{�^��Visible</summary>
		private bool _canClose;
		/// <summary>�V�K�{�^��Visible</summary>
		private bool _canNew;
		/// <summary>�폜�{�^��Visible</summary>
		private bool _canDelete;
		/// <summary>�t���[��MainGrid�^�C�g��</summary>
		private string _mainGridTitle;
		/// <summary>�t���[��DetailGrid�^�C�g��</summary>
		private string _detailsGridTitle;
		/// <summary>�t���[���I��DataTable��</summary>
		private string _targetTableName;
		# endregion

		# region �����\�b�h�p
		/// <summary>�t���[��MainGrid_Index</summary>
		private int _mainDataIndex;
		/// <summary>�t���[��DetailGrid_Index</summary>
		private int _detailsDataIndex;
		/// <summary>�t���[��Grid_DisplayLayout</summary>
		private MGridDisplayLayout _defaultGridDisplayLayout;
		# endregion
	
		# endregion

		# endregion

		# region ��Consts
		// Frame��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
		private const string SECTIONCODE_TITLE		   = "���_�R�[�h";
		private const string SECTIONNAME_TITLE		   = "���_��";
		private const string SECTION_TABLE			   = "SECTION_TABLE";

		private const string NOCODE_TITLE			   = "�ԍ��R�[�h";
		private const string NONAME_TITLE			   = "�ԍ���";
		private const string NOITEMPATTERNCD_TITLE	   = "�ԍ����ڌ^";
		private const string NOCHARCTERCOUNT_TITLE	   = "�ԍ�����";	   
		private const string CONSNOCHRCTERCOUNT_TITLE  = "�ԍ��A�Ԍ���";	   
		private const string NODISPPOSITIONDIVCD_TITLE = "�ԍ��\���ʒu�敪";	   
		private const string NUMBERINGTYPE_TITLE       = "�ԍ��̔ԃ^�C�v";	   
		private const string NUMBERINGAMBITDIVCD_TITLE = "�ԍ��̔Ԕ͈�";	   
		private const string NOPRESENTVAL_TITLE		   = "�ԍ����ݒl";	   
		private const string SETTINGSTARTNO_TITLE	   = "�ݒ�J�n�ԍ�";	   
		private const string SETTINGENDNO_TITLE		   = "�ݒ�I���ԍ�";	   
		private const string NOINCDECWIDTH_TITLE	   = "�ԍ�������";	   
		private const string NOMNGSET_TABLE			   = "NOMNGSET_TABLE";
		private const string UIGRID_TABLE			   = "UIGRID_TABLE";

		// �ҏW���[�h�i�X�V�̂݁j
		private const string UPDATE_MODE			   = "�X�V���[�h";
		// ��ƒʔԂ͋��_�R�[�h"000000"
        // 2008.09.23 30413 ���� ���_�R�[�h��2���ɏC�� >>>>>>START
        private const string DUMMYSECCD = "000000";
        //private const string DUMMYSECCD = "00";
        // 2008.09.23 30413 ���� ���_�R�[�h��2���ɏC�� <<<<<<END
        // �ԍ����ݒl�p"�����l"
		private const string NOPRESENTVAL_NULL		   = "�����l";
		// Message�֘A��`
		private const string ASSEMBLY_ID	= "SFCMN09100U";
		private const string ERR_READ_MSG	= "�ǂݍ��݂Ɏ��s���܂����B";
		private const string ERR_DPR_MSG	= "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
		private const string ERR_RDEL_MSG	= "�폜�Ɏ��s���܂����B";
		private const string ERR_UPDT_MSG	= "�o�^�Ɏ��s���܂����B";
		private const string ERR_RVV_MSG	= "�����Ɏ��s���܂����B";
		private const string ERR_800_MSG	= "���ɑ��[�����X�V����Ă��܂�";
		private const string ERR_801_MSG	= "���ɑ��[�����폜����Ă��܂�";
		# endregion

		# region ��Main
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFCMN09100UA());
		}
		# endregion

		# region ��Private Methods
		/// <summary>
		/// ���_���}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�f�[�^�Z�b�g�W�J����
		/// </summary>
		/// <param name="secInfoSet">���_���ݒ�}�X�^�I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : �ԍ��Ǘ��ݒ�}�X�^�f�[�^�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void SecInfoSetToDataSet(SecInfoSet secInfoSet, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[SECTION_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[SECTION_TABLE].NewRow();
				this.Bind_DataSet.Tables[SECTION_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[SECTION_TABLE].Rows.Count - 1;
			}

			// �S�Ћ��ʕ��̎�
			if (index == 0)
			{
				// DataTable�Ƀf�[�^���Z�b�g
                // 2008.10.02 30413 ���� �S�Ћ��ʂ̋��_�R�[�h��ݒ� >>>>>>START
                this.Bind_DataSet.Tables[SECTION_TABLE].Rows[index][SECTIONCODE_TITLE] = "00";
                // 2008.10.02 30413 ���� �S�Ћ��ʂ̋��_�R�[�h��ݒ� <<<<<<END
                this.Bind_DataSet.Tables[SECTION_TABLE].Rows[index][SECTIONNAME_TITLE] = "�S�Ћ���";
			}
			else
			{
				// DataTable�Ƀf�[�^���Z�b�g
				this.Bind_DataSet.Tables[SECTION_TABLE].Rows[index][SECTIONCODE_TITLE]	= secInfoSet.SectionCode;
				this.Bind_DataSet.Tables[SECTION_TABLE].Rows[index][SECTIONNAME_TITLE]	= secInfoSet.SectionGuideNm;
				// HashKey�͋��_�R�[�h
				string hashKey = secInfoSet.SectionCode.ToString();
				// ���_Table�Ƀf�[�^���Z�b�g
				if (this._secInfoSetTable.ContainsKey(hashKey))
				{
					this._secInfoSetTable.Remove(hashKey);
				}
				this._secInfoSetTable.Add(hashKey, secInfoSet);
			}
		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ�}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
		/// <param name="noMngSet">�ԍ��Ǘ��ݒ�}�X�^�I�u�W�F�N�g</param>
		/// <param name="noTypeMng">�ԍ��^�C�v�Ǘ��}�X�^�I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : �ԍ��Ǘ��ݒ�}�X�^�f�[�^�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void NoMngSetToDataSet(NoMngSet noMngSet, NoTypeMng noTypeMng, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[NOMNGSET_TABLE].NewRow();
				this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows.Add( dataRow );

				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows.Count - 1;
			}

			// DataTable�Ƀf�[�^���Z�b�g
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NOCODE_TITLE]			    = noMngSet.NoCode;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NONAME_TITLE]				= noTypeMng.NoName;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NOITEMPATTERNCD_TITLE]		= noTypeMng.NoItemPatternCd;
			if (noMngSet.NoPresentVal == 0)
			{
				this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NOPRESENTVAL_TITLE]	= NOPRESENTVAL_NULL;
			}
			else
			{
				this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NOPRESENTVAL_TITLE]	= noMngSet.NoPresentVal;
			}
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NOCHARCTERCOUNT_TITLE]		= noTypeMng.NoCharcterCount;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][CONSNOCHRCTERCOUNT_TITLE]	= noTypeMng.ConsNoCharcterCount;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NODISPPOSITIONDIVCD_TITLE]	= noTypeMng.NoDispPositionDivCd;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NUMBERINGTYPE_TITLE]		= noTypeMng.NumberingTypeDivCd;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NUMBERINGAMBITDIVCD_TITLE]	= noTypeMng.NumberingAmbitDivCd;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][SETTINGSTARTNO_TITLE]		= noMngSet.SettingStartNo;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][SETTINGENDNO_TITLE]		= noMngSet.SettingEndNo;
			this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[index][NOINCDECWIDTH_TITLE]		= noMngSet.NoIncDecWidth;
		}

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			// ���_���R�[�h�p�e�[�u��
			DataTable secInfoSetTable = new DataTable(SECTION_TABLE);
			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			secInfoSetTable.Columns.Add(SECTIONCODE_TITLE,	typeof(string));
			secInfoSetTable.Columns.Add(SECTIONNAME_TITLE,	typeof(string));

			this.Bind_DataSet.Tables.Add(secInfoSetTable);

			// �R�[�h���R�[�h�p�e�[�u��
			DataTable noMngSetTable = new DataTable(NOMNGSET_TABLE);
			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			noMngSetTable.Columns.Add(NOCODE_TITLE,			     typeof(int));
			noMngSetTable.Columns.Add(NONAME_TITLE,				 typeof(string));
			noMngSetTable.Columns.Add(NOITEMPATTERNCD_TITLE,	 typeof(string));
			noMngSetTable.Columns.Add(NOCHARCTERCOUNT_TITLE,	 typeof(int));
			noMngSetTable.Columns.Add(CONSNOCHRCTERCOUNT_TITLE,	 typeof(int));
			noMngSetTable.Columns.Add(NODISPPOSITIONDIVCD_TITLE, typeof(string));
			noMngSetTable.Columns.Add(NUMBERINGTYPE_TITLE,	 	 typeof(string));
			noMngSetTable.Columns.Add(NUMBERINGAMBITDIVCD_TITLE, typeof(string));
			noMngSetTable.Columns.Add(NOPRESENTVAL_TITLE,		 typeof(string));
			noMngSetTable.Columns.Add(SETTINGSTARTNO_TITLE,		 typeof(int));
			noMngSetTable.Columns.Add(SETTINGENDNO_TITLE,		 typeof(int));
			noMngSetTable.Columns.Add(NOINCDECWIDTH_TITLE,		 typeof(int));

			this.Bind_DataSet.Tables.Add(noMngSetTable);

			// UI_Grid�p�e�[�u��
			DataTable uiGridTable = new DataTable(UIGRID_TABLE);
			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			uiGridTable.Columns.Add(NOCODE_TITLE,			    typeof(int));
			uiGridTable.Columns.Add(NONAME_TITLE,				typeof(string));
			uiGridTable.Columns.Add(NOPRESENTVAL_TITLE,			typeof(string));
			uiGridTable.Columns.Add(SETTINGSTARTNO_TITLE,		typeof(long));
			uiGridTable.Columns.Add(SETTINGENDNO_TITLE,			typeof(long));
			uiGridTable.Columns.Add(NOINCDECWIDTH_TITLE,		typeof(int));
			uiGridTable.Columns.Add(CONSNOCHRCTERCOUNT_TITLE, 	typeof(int));

			this.Bind_DataSet.Tables.Add(uiGridTable);
		}

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			// ������
			return;
		}

		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void ScreenClear()
		{
			this.SectionNm_tEdit.Clear();
			this.Bind_DataSet.Tables[UIGRID_TABLE].Rows.Clear();
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			// ��ʃN���A
			ScreenClear();
			// �ҏW�`�F�b�N�pBuffer�N���A
			this._noMngSetClone.Clear();

			// ���_���̃Z�b�g
			this.SectionNm_tEdit.Text = this.Bind_DataSet.Tables[SECTION_TABLE].Rows[this._mainDataIndex][SECTIONNAME_TITLE].ToString();

			int index = 0;
			SortedList sortList = new SortedList();
			
			// �u�S�Ћ��ʁv�̏ꍇ
            // 2008.10.02 30413 ���� �S�Ћ��ʂ̋��_�R�[�h��ݒ� >>>>>>START
            //if (this.Bind_DataSet.Tables[SECTION_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE].ToString() == "")
            if (this.Bind_DataSet.Tables[SECTION_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE].ToString() == "00")
            // 2008.10.02 30413 ���� �S�Ћ��ʂ̋��_�R�[�h��ݒ� <<<<<<END
            {
				// Sort
				foreach(NoMngSet noMngSet in this._noMngSetTable.Values)
				{
					if (noMngSet.SectionCode == DUMMYSECCD)
					{
						sortList.Add(noMngSet.NoCode, noMngSet);
					}
				}
			}
				// ���_���̏ꍇ
			else
			{
				// Sort
				foreach(NoMngSet noMngSet in this._noMngSetTable.Values)
				{
					if (noMngSet.SectionCode.TrimEnd() == this.Bind_DataSet.Tables[SECTION_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE].ToString().TrimEnd())
					{
						sortList.Add(noMngSet.NoCode, noMngSet);
					}
				}
			}

			foreach (NoMngSet noMngSet in sortList.Values)
			{
				// �ԍ��Ǘ��ݒ��ʓW�J����
				NoMngSetToScreen(noMngSet, (NoTypeMng)this._noTypeMngTable[noMngSet.NoCode.ToString()], index);
				index++;
			}

			this.NoMngSet_uGrid.Focus();
			this.NoMngSet_uGrid.Rows[0].Activate();

			//_GridIndex�o�b�t�@�ێ�
			this._detailsIndexBuf	= this._detailsDataIndex;
			this._mainIndexBuf		= this._mainDataIndex;
		}

		/// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <param name="enabled">���͋��ݒ�l</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void ScreenInputPermissionControl(bool enabled)
		{
			// ������
			return;
		}

		/// <summary>
		/// �ԍ��Ǘ��ݒ�}�X�^�N���X��ʓW�J����
		/// </summary>
		/// <param name="noMngSet">�ԍ��Ǘ��ݒ�}�X�^�I�u�W�F�N�g</param>
		/// <param name="noTypeMng">�ԍ��^�C�v�Ǘ��}�X�^�I�u�W�F�N�g</param>
		/// <param name="index">�C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : �ԍ��Ǘ��ݒ�}�X�^�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void NoMngSetToScreen(NoMngSet noMngSet, NoTypeMng noTypeMng, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[UIGRID_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[UIGRID_TABLE].NewRow();
				this.Bind_DataSet.Tables[UIGRID_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ��Ƃ���
				index = this.Bind_DataSet.Tables[UIGRID_TABLE].Rows.Count - 1;
			}
			
			this.Bind_DataSet.Tables[UIGRID_TABLE].Rows[index][NOCODE_TITLE]			 = noMngSet.NoCode;
			this.Bind_DataSet.Tables[UIGRID_TABLE].Rows[index][NONAME_TITLE]			 = noTypeMng.NoName;
			// �u�ԍ����ݒl�v���O�̏ꍇ
			if (noMngSet.NoPresentVal == 0)
			{
				this.Bind_DataSet.Tables[UIGRID_TABLE].Rows[index][NOPRESENTVAL_TITLE]	 = NOPRESENTVAL_NULL;
			}
			else
			{
				this.Bind_DataSet.Tables[UIGRID_TABLE].Rows[index][NOPRESENTVAL_TITLE]	 = noMngSet.NoPresentVal;
			}
			this.Bind_DataSet.Tables[UIGRID_TABLE].Rows[index][SETTINGSTARTNO_TITLE]	 = noMngSet.SettingStartNo;
			this.Bind_DataSet.Tables[UIGRID_TABLE].Rows[index][SETTINGENDNO_TITLE]		 = noMngSet.SettingEndNo;
			this.Bind_DataSet.Tables[UIGRID_TABLE].Rows[index][NOINCDECWIDTH_TITLE]		 = noMngSet.NoIncDecWidth;
			this.Bind_DataSet.Tables[UIGRID_TABLE].Rows[index][CONSNOCHRCTERCOUNT_TITLE] = noTypeMng.ConsNoCharcterCount;
			
			// �f�[�^�\�[�X�֒ǉ�
			this.NoMngSet_uGrid.DataSource = this.Bind_DataSet.Tables[UIGRID_TABLE];

			// �ŏ����Ή��pClone�쐬
			this._noMngSetClone.Add(noMngSet.Clone());
		}									

		/// <summary>
		/// Value�`�F�b�N�����iint�j
		/// </summary>
		/// <param name="sorce">Cell��Value</param>
		/// <returns>�`�F�b�N��̒l</returns>
		/// <remarks>
		/// <br>Note		: Cell�̒l��Class�ɓ���鎞��DBNULL�`�F�b�N���s���܂��B</br>
		/// <br>Programmer	: 22033 �O��  �M�j</br>
		/// <br>Date		: 2005.12.01</br>
		/// </remarks>
		private int ValueToInt(object sorce)
		{
			int dest = 0;
			try
			{
				dest = Convert.ToInt32(sorce);
			}
			catch
			{
				return dest;
			}
			return dest;
		}

		/// <summary>
		/// ��ʏ��ԍ��Ǘ��ݒ�}�X�^�N���X�i�[����
		/// </summary>
		/// <param name="noMngSet">�ԍ��Ǘ��ݒ�}�X�^�I�u�W�F�N�g</param>
		/// <param name="index">�C���f�b�N�X</param>
		/// <returns>�ԍ��Ǘ��ݒ�}�X�^�I�u�W�F�N�g</returns>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂�ԍ��Ǘ��ݒ�}�X�^�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private NoMngSet DispToNoMngSet(NoMngSet noMngSet, int index)
		{
			for (int ix = 0; ix != this.NoMngSet_uGrid.Rows.Count; ix++)
			{
				if (noMngSet.NoCode == (int)this.NoMngSet_uGrid.Rows[ix].Cells[NOCODE_TITLE].Value)
				{
					if (this.NoMngSet_uGrid.Rows[ix].Cells[NOPRESENTVAL_TITLE].Value.ToString() == NOPRESENTVAL_NULL)
					{
						noMngSet.NoPresentVal = 0;
					}
					else
					{
						noMngSet.NoPresentVal	= TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[NOPRESENTVAL_TITLE].Value.ToString(), 0);
					}
					noMngSet.SettingStartNo = TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[SETTINGSTARTNO_TITLE].Value.ToString(), 0);
					noMngSet.SettingEndNo	= TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[SETTINGENDNO_TITLE].Value.ToString(), 0);
					noMngSet.NoIncDecWidth	= ValueToInt(this.NoMngSet_uGrid.Rows[ix].Cells[NOINCDECWIDTH_TITLE].Value);
				
					break;
				}
			}

			return noMngSet;
		}

		/// <summary>
		/// ��ʓ��͏��s���`�F�b�N����
		/// </summary>
		/// <param name="message">���b�Z�[�W</param>
		/// <param name="index">�t�H�[�J�X��߂�Row</param>
		/// <param name="column">�t�H�[�J�X��߂�column</param>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private bool ScreenDataCheck(ref string message, out int index, out string column)
		{
			bool result = true;
			index = 0;
			column = null;

			for (int ix = 0 ; ix != this.NoMngSet_uGrid.Rows.Count ; ix++)
			{
                // 2009.02.23 30413 ���� UOE�����ԍ���6�����ɂ��A�G���[�`�F�b�N���C�� >>>>>>START
                int noCode = TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[NOCODE_TITLE].Text, 0);
				
                // �ԍ����ݒl
                int noPreset = TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[NOPRESENTVAL_TITLE].Text, 0);
                if ((noCode == 3300) && (noPreset > 999999))
                {
                    message = "�ԍ����ݒl���s���ł��B";
                    index = ix;
                    column = NOPRESENTVAL_TITLE;
                    return false;
                }

				// �u�ݒ�J�n�ԍ��v���O�̎�
                int setting = TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[SETTINGSTARTNO_TITLE].Text, 0);
                //if (TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[SETTINGSTARTNO_TITLE].Text, 0) == 0)
                if (setting == 0)
				{
					message = "�ݒ�J�n�ԍ���ݒ肵�ĉ������B";
					index = ix;
					column = SETTINGSTARTNO_TITLE;
					return false;
				}
                else if ((noCode == 3300) && (setting > 999999))
                {
                    // UOE�����ԍ��̏ꍇ
                    message = "�ݒ�J�n�ԍ����s���ł��B";
                    index = ix;
                    column = SETTINGSTARTNO_TITLE;
                    return false;
                }

				// �J�n�ԍ��ƏI���ԍ��̑召���t�̎�
				int startNo	= TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[SETTINGSTARTNO_TITLE].Text, 0);
				int endNo	= TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[SETTINGENDNO_TITLE].Text, 0);
                if (startNo > endNo)
				{
					message = "�J�n�E�I���ԍ����s���ł��B";
					index = ix;
					column = SETTINGSTARTNO_TITLE;
					return false;
				}
                else if ((noCode == 3300) && (endNo > 999999))
                {
                    // UOE�����ԍ��̏ꍇ
                    message = "�ݒ�I���ԍ����s���ł��B";
                    index = ix;
                    column = SETTINGENDNO_TITLE;
                    return false;
                }
                // 2009.02.23 30413 ���� UOE�����ԍ���6�����ɂ��A�G���[�`�F�b�N���C�� <<<<<<END
                
				// ���������J�n�ԍ��ƏI���ԍ��̍����傫����
				int lengthNo = TStrConv.StrToIntDef(this.NoMngSet_uGrid.Rows[ix].Cells[NOINCDECWIDTH_TITLE].Text, 0);
				if (lengthNo > endNo - startNo)
				{
					message = "�J�n�E�I���ԍ��E���������s���ł��B";
					index = ix;
					column = NOINCDECWIDTH_TITLE;
					return false;
				}

				if (lengthNo == 0)
				{
					message = "�ԍ���������ݒ肵�ĉ������B";
					index = ix;
					column = NOINCDECWIDTH_TITLE;
					return false;
				}
			}

			return result;
		}

		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <returns>�`�F�b�N����</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �ԍ��Ǘ��ݒ�}�X�^�I�u�W�F�N�g�̕ۑ��������s���܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.09.09</br>
		/// </remarks>
		private bool SaveProc()
		{
			int index = 0;
			int status = 0;
			string message = null;	
			string column = null;	
			NoTypeMng noTypeMng = new NoTypeMng();
			ArrayList noMngSetList = new ArrayList();

			if (!ScreenDataCheck(ref message, out index, out column))
			{
				TMsgDisp.Show( 
					this,								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
					ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
					message,							// �\�����郁�b�Z�[�W 
					0,									// �X�e�[�^�X�l
					MessageBoxButtons.OK);				// �\������{�^��

				this.NoMngSet_uGrid.Rows[index].Cells[column].Activate();
				return false;
			}

			// �ύX�����������R�[�h�̂ݕۑ��ɂ����i�G���g���[���Ő�ɍX�V���ꂽ�ꍇ�̔r���G���[�����炷�ׁj
			index = 0;
			// �u�S�Ћ��ʁv�̏ꍇ
            // 2008.10.02 30413 ���� �S�Ћ��ʂ̋��_�R�[�h��ݒ� >>>>>>START
            //if (this.Bind_DataSet.Tables[SECTION_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE].ToString() == "")
            if (this.Bind_DataSet.Tables[SECTION_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE].ToString() == "00")
            // 2008.10.02 30413 ���� �S�Ћ��ʂ̋��_�R�[�h��ݒ� <<<<<<END
            {
				foreach (NoMngSet noMngSetWk in _noMngSetTable.Values)
				{
					// �u�S�Ћ��ʁv��
					if (noMngSetWk.SectionCode == DUMMYSECCD)
					{
						foreach (NoMngSet noMngSetWk2 in this._noMngSetClone) 
						{
							// �ҏW�`�F�b�N�pBuffer���瓯�����̂�����
							if (noMngSetWk2.NoCode == noMngSetWk.NoCode)
							{
								NoMngSet noMngSetWkClone = (NoMngSet)noMngSetWk.Clone();

								// �ύX����Ă����ꍇ�̂�Write�pList��Set
								if (!(noMngSetWk2.Equals(DispToNoMngSet(noMngSetWkClone, index))))
								{
									// ��ʏ��}�X�^�I�u�W�F�N�g�i�[������Write�pArrayList��Add
									noMngSetList.Add(DispToNoMngSet(noMngSetWkClone, index));
									index++;
								}
							}
						}
					}
				}
			}
			// ���_���̏ꍇ
			else
			{
				foreach (NoMngSet noMngSetWk in _noMngSetTable.Values)
				{
					if (noMngSetWk.SectionCode.TrimEnd() == this.Bind_DataSet.Tables[SECTION_TABLE].Rows[this._mainDataIndex][SECTIONCODE_TITLE].ToString().TrimEnd())
					{
						foreach (NoMngSet noMngSetWk2 in this._noMngSetClone) 
						{
							// �ҏW�`�F�b�N�pBuffer���瓯�����̂�����
							if (noMngSetWk2.NoCode == noMngSetWk.NoCode)
							{
								NoMngSet noMngSetWkClone = (NoMngSet)noMngSetWk.Clone();
								
								// �ύX����Ă����ꍇ�̂�Write�pList��Set
								if (!(noMngSetWk2.Equals(DispToNoMngSet(noMngSetWkClone, index))))
								{
									// ��ʏ��}�X�^�I�u�W�F�N�g�i�[������Write�pArrayList��Add
									noMngSetList.Add(DispToNoMngSet(noMngSetWkClone, index));
									index++;
								}
							}
						}
					}
				}
			}

			// �ύX���������ꍇ�̂݃����[�g
			if (noMngSetList.Count != 0)
			{
				status = this._noMngSetAcs.Write(ref noMngSetList);
			}

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					foreach (NoMngSet noMngSet in noMngSetList)
					{
						noTypeMng = ((NoTypeMng)this._noTypeMngTable[noMngSet.NoCode.ToString()]).Clone();
						
						// �u�ԍ��R�[�h�v������Row��Index�擾
						for (int ix = 0; ix != this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows.Count; ix++)
						{
							if (noTypeMng.NoCode == (int)this.Bind_DataSet.Tables[NOMNGSET_TABLE].Rows[ix][NOCODE_TITLE])
							{
								NoMngSetToDataSet(noMngSet, noTypeMng, ix);
							}
						}
			
						// HashKey��PrimaryKey
						string hashKey = noMngSet.SectionCode.TrimEnd() + "_" + noMngSet.NoCode;
						// �ԍ��ݒ�Table�Ƀf�[�^���Z�b�g
						if (this._noMngSetTable.ContainsKey(hashKey))
						{
							this._noMngSetTable.Remove(hashKey);
						}
						this._noMngSetTable.Add(hashKey, noMngSet);
				
						// HashKey��PrimaryKey
						hashKey = noTypeMng.NoCode.ToString();
						// �ԍ��ݒ�Table�Ƀf�[�^���Z�b�g
						if (this._noTypeMngTable.ContainsKey(hashKey))
						{
							this._noTypeMngTable.Remove(hashKey);
						}
						this._noTypeMngTable.Add(hashKey, noTypeMng);
					}

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					TMsgDisp.Show( 
						this,											// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,				// �G���[���x��
						ASSEMBLY_ID,									// �A�Z���u���h�c�܂��̓N���X�h�c
						"�ԍ��̐ݒ�͈͂����̋��_�Əd�����Ă��܂��B",	// �\�����郁�b�Z�[�W 
						0,												// �X�e�[�^�X�l
						MessageBoxButtons.OK);							// �\������{�^��

					this.NoMngSet_uGrid.Rows[0].Cells[2].Activate();
					return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// �r������
					ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._noMngSetAcs);
					
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._detailsIndexBuf	= -2;
					this._mainIndexBuf		= -2;

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
					TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							// �v���O��������
						"SaveProc",							// ��������
						TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
						ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						this._noMngSetAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��
					
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._detailsIndexBuf	= -2;
					this._mainIndexBuf		= -2;

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
			}
			
			return true;
		}

		/// <summary>
		/// �r������
		/// </summary>
		/// <param name="operation">�I�y���[�V����</param>
		/// <param name="erObject">�G���[�I�u�W�F�N�g</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
		/// <br>Programmer : 22033  �O�� �M�j</br>
		/// <br>Date       : 2005.09.21</br>
		/// </remarks>
		private void ExclusiveTransaction(int status, string operation, object erObject)
		{				   
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							// �v���O��������
						"ExclusiveTransaction",				// ��������
						operation,							// �I�y���[�V����
						ERR_800_MSG,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						erObject,							// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							// �v���O��������
						"ExclusiveTransaction",				// ��������
						operation,							// �I�y���[�V����
						ERR_801_MSG,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						erObject,							// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��
					break;
				}
			}
		}

		/// <summary>
		/// ���͕s�� �Z���O�ώ擾����
		/// </summary>
		/// <returns>�O�Ϗ��</returns>
		/// <remarks>
		/// <br>Note       : ���͕s�Z���̊O�Ϗ����擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private Infragistics.Win.Appearance GetImpossibleCellAppearance()
		{
			Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
			appearance.BackColor = Color.FromArgb(251, 230, 148);
			appearance.BackColor2 = Color.FromArgb(238, 149, 21);
			appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance.ForeColor = Color.Black;
			return appearance;
		}

		/// <summary>
		/// ���͉\/��A�N�e�B�u �Z���O�ώ擾����
		/// </summary>
		/// <returns>�O�Ϗ��</returns>
		/// <remarks>
		/// <br>Note       : ���͉\��A�N�e�B�u�Z���̊O�Ϗ����擾���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private Infragistics.Win.Appearance GetPossibleCellAppearance()
		{
			Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
			appearance.BackColor = Color.White;
			appearance.BackColor2 = Color.FromArgb(238, 149, 21);
			appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance.ForeColor = Color.Black;
			return appearance;
		}
		# endregion

		# region ��Control Events
		/// <summary>
		/// Form.Load �C�x���g(SFCMN09100UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.09.09</br>
		/// </remarks>
		private void SFCMN09100UA_Load(object sender, System.EventArgs e)
		{
            // �� 20070206 18322 a MA.NS�p�ɕύX
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();
            
            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);
            // �� 20070206 18322 a

            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;

			this.Ok_Button.ImageList = imageList24;
			this.Cancel_Button.ImageList = imageList24;

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            // 2008.09.25 30413 ���� �����l�Z�b�g�{�^���ǉ� >>>>>>START
            this.InitSet_Button.ImageList = imageList24;
            this.InitSet_Button.Appearance.Image = Size24_Index.MODIFY;
            // 2008.09.25 30413 ���� �����l�Z�b�g�{�^���ǉ� <<<<<<END
            
			// ��ʏ����ݒ菈��
			ScreenInitialSetting();
		}

		/// <summary>
		/// Form.Closing �C�x���g(SFCMN09100UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.09.09</br>
		/// </remarks>
		private void SFCMN09100UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._detailsIndexBuf	= -2;
			this._mainIndexBuf		= -2;

			// �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}	
		}

		/// <summary>
		/// Control.VisibleChanged �C�x���g(SFCMN09100UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.09.09</br>
		/// </remarks>
		private void SFCMN09100UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				this.Owner.Activate();
				return;
			}
			
			if ((this._detailsIndexBuf == this._detailsDataIndex) &&
				(this._mainIndexBuf == this._mainDataIndex))
			{
				return;
			}

			Initial_Timer.Enabled = true;
		}

		/// <summary>
		/// Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.09.09</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// �o�^����
			if (SaveProc() == false)
			{
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;
			this._detailsIndexBuf = -2;
			this._mainIndexBuf = -2;

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
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.09.09</br>
		/// </remarks>		
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// �V���[�g�J�b�g�[Key�Ή�
			this.Cancel_Button.Focus();
			
			// �ύX�t���O
			bool check = true;
			NoMngSet compareNoMngSet = new NoMngSet();
			NoMngSet cloneNoMngSet = new NoMngSet();
			
			for (int ix = 0; ix != this._noMngSetClone.Count; ix++)
			{
				cloneNoMngSet = (NoMngSet)this._noMngSetClone[ix];
				compareNoMngSet = cloneNoMngSet.Clone();
				DispToNoMngSet(compareNoMngSet, ix);
				if (!(cloneNoMngSet.Equals(compareNoMngSet)))
				{
					check = false;
					break;
				}
			}

			if (!check)
			{
				// ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
				DialogResult res = TMsgDisp.Show( 
					this,								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
					ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
					"",									// �\�����郁�b�Z�[�W 
					0,									// �X�e�[�^�X�l
					MessageBoxButtons.YesNoCancel);		// �\������{�^��
				
				switch (res)
				{
					case DialogResult.Yes:
					{
						if (!SaveProc())
						{
							return;
						}
						if (UnDisplaying != null)
						{
							this.DialogResult = DialogResult.OK;
						}
						break;
					}
					case DialogResult.No:
					{
						if (UnDisplaying != null)
						{
							this.DialogResult = DialogResult.Cancel;
						}
						break;
					}
					default:
					{
						this.Cancel_Button.Focus();
						return;
					}
				}
			}

			MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
			UnDisplaying(this, me);

			this.DialogResult = DialogResult.Cancel;

			this._detailsIndexBuf = -2;
			this._mainIndexBuf = -2;

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
		/// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
		///					  �X���b�h�Ŏ��s����܂��B</br>
		/// <br>Programmer  : 22033 �O��  �M�j</br>
		/// <br>Date        : 2005.09.09</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();		
		}

		/// <summary>
		/// ���^�[���L�[�ړ��C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���^�[���L�[�������̐�����s���܂��B</br>
		/// <br>Programmer	: 22033 �O��  �M�j</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			// Grid��Control�����鎞��Return/Tab�̓����ݒ�
			if (e.PrevCtrl == this.NoMngSet_uGrid)
			{
				// ���^�[���L�[�̎�
				if ((e.Key == Keys.Return) ||
					(e.Key == Keys.Tab))
				{
					e.NextCtrl = null;

					if (this.NoMngSet_uGrid.ActiveCell != null)
					{
						// �ŏI�Z���̎�
						if ((this.NoMngSet_uGrid.ActiveCell.Row.Index == this.NoMngSet_uGrid.Rows.Count - 1) &&
							(this.NoMngSet_uGrid.ActiveCell.Column.Index == this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOINCDECWIDTH_TITLE].Index))
						{
							// �ۑ��{�^���Ƀt�H�[�J�X�J��
							e.NextCtrl = this.Ok_Button;
						}
						else
						{
							// �u�ԍ��������v�̏ꍇ�͎���Row��
							if (this.NoMngSet_uGrid.ActiveCell.Column.Index == this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOINCDECWIDTH_TITLE].Index)
							{
								// ����Row�Ƀt�H�[�J�X�J��
								this.NoMngSet_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);
								this.NoMngSet_uGrid.PerformAction(UltraGridAction.EnterEditMode);

							}
							else
							{
								// ����Cell�Ƀt�H�[�J�X�J��
								this.NoMngSet_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
							}
						}
					}
				}
			}
			else if ((e.PrevCtrl == this.Cancel_Button) ||
				(e.PrevCtrl == this.Ok_Button))
			{
				if (e.NextCtrl == this.NoMngSet_uGrid)
				{
					e.NextCtrl = null;
					switch (e.Key)
					{
						case Keys.Return:
						{
							this.NoMngSet_uGrid.Rows[0].Cells[NOPRESENTVAL_TITLE].Activate();
							break;
						}
						case Keys.Tab:
						{
							this.NoMngSet_uGrid.Rows[0].Cells[NOPRESENTVAL_TITLE].Activate();
							break;
						}
						case Keys.Up:
						{
							this.NoMngSet_uGrid.Rows[this._leaveRowBuf].Cells[this._leaveColBuf].Activate();
							break;
						}
					}
				}
			}
		}
		# endregion

		# region ��Grid Control
		/// <summary>
		/// UltraGrid.KeyDown�C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note		: �O���b�h��ŉ����L�[�������������̐�����s���܂��B</br>
		/// <br>Programmer	: 22033 �O��  �M�j</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void NoMngSet_uGrid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			// Grid�ҏW���̎�
			if ((this.NoMngSet_uGrid.ActiveCell != null) &&
				(this.NoMngSet_uGrid.ActiveCell.IsInEditMode == true))
			{
				switch (e.KeyCode)
				{
					case Keys.Up:
					{
						if (this.NoMngSet_uGrid.ActiveCell.Row.Index == 0)
						{
							break;
						}
						else
						{
							this.NoMngSet_uGrid.PerformAction(UltraGridAction.AboveCell);
							e.Handled = true;
						}
						break;
					}

					case Keys.Down:
					{
						if (this.NoMngSet_uGrid.ActiveCell.Row.Index == (this.NoMngSet_uGrid.Rows.Count - 1))
						{
							this.Ok_Button.Focus();
						}
						else
						{
							this.NoMngSet_uGrid.PerformAction(UltraGridAction.BelowCell);
							e.Handled = true;
						}
						break;
					}
					case Keys.Right:
					{
						if ((this.NoMngSet_uGrid.ActiveCell.SelLength == 0) &&
							(this.NoMngSet_uGrid.ActiveCell.SelStart == this.NoMngSet_uGrid.ActiveCell.Text.Length))
						{
							// �u�ԍ��������v�̏ꍇ�͎���Row��
							if (this.NoMngSet_uGrid.ActiveCell.Column.Index == this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOINCDECWIDTH_TITLE].Index)
							{
								this.NoMngSet_uGrid.PerformAction(UltraGridAction.NextRow);
								this.NoMngSet_uGrid.PerformAction(UltraGridAction.EnterEditMode);
							}
							else
							{
								this.NoMngSet_uGrid.PerformAction(UltraGridAction.NextCell);
							}
							e.Handled = true;
						}	
						break;
					}
					case Keys.Left:
					{
						// �Q�s�ڈȍ~�Łu�ԍ����ݒl�v�̎�
						if ((this.NoMngSet_uGrid.ActiveCell.SelLength == 0) &&
							(this.NoMngSet_uGrid.ActiveCell.SelStart == 0) &&
							(this.NoMngSet_uGrid.ActiveCell.Row.Index != 0) &&
							(this.NoMngSet_uGrid.ActiveCell.Column.Index == this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOPRESENTVAL_TITLE].Index))
						{
							// ��̍s�́u�ԍ��������v��
							this.NoMngSet_uGrid.Rows[this.NoMngSet_uGrid.ActiveCell.Row.Index - 1].Cells[NOINCDECWIDTH_TITLE].Activate();
							e.Handled = true;
						}
						else if ((this.NoMngSet_uGrid.ActiveCell.SelLength == 0) &&
							(this.NoMngSet_uGrid.ActiveCell.SelStart == 0))
						{
							// ��O��Cell��
							this.NoMngSet_uGrid.PerformAction(UltraGridAction.PrevCell);
							e.Handled = true;
						}
						break;
					}
				}
			}	
		}

		/// <summary>
		/// UltraGrid.AfterRowActivate�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �s���A�N�e�B�u�����ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22033 �O��  �M�j</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void NoMngSet_uGrid_AfterRowActivate(object sender, System.EventArgs e)
		{
			// Row��Active������Ă��āACell��Active������Ă��Ȃ��ꍇ�A�u�ԍ����ݒl�v��Activeate
			if (this.NoMngSet_uGrid.ActiveRow == null) 
			{
				return;
			}

			if (this.NoMngSet_uGrid.ActiveCell == null)
			{
				this.NoMngSet_uGrid.ActiveRow.Cells[NOPRESENTVAL_TITLE].Activate();
			}
		}

		/// <summary>
		/// UltraGrid.BeforeRowDeactivate�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>						
		/// <br>Note		: �s����A�N�e�B�u������钼�O�ɔ������܂��B</br>
		/// <br>Programmer	: 22033 �O��  �M�j</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void NoMngSet_uGrid_BeforeRowDeactivate(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// �A�N�e�B�u�������s�̃Z���̊O�ς�����
			foreach (UltraGridCell wkCell in this.NoMngSet_uGrid.ActiveRow.Cells)
			{
				wkCell.Appearance = null;
			}
		}

		/// <summary>
		/// UltraGrid.AfterCellActivate�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �Z�����A�N�e�B�u�����ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22033 �O��  �M�j</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void NoMngSet_uGrid_AfterCellActivate(object sender, System.EventArgs e)
		{
			// �u�ԍ����́vCell�̎�
			if (this.NoMngSet_uGrid.ActiveCell == this.NoMngSet_uGrid.ActiveRow.Cells[NONAME_TITLE])
			{
				// ActiveCell���u�ԍ����́v�փZ�b�g����
				this.NoMngSet_uGrid.ActiveCell = this.NoMngSet_uGrid.ActiveRow.Cells[NOPRESENTVAL_TITLE];
			}

			this.NoMngSet_uGrid.PerformAction(UltraGridAction.EnterEditMode);
			
			// �A�N�e�B�u�s�̑S�ẴZ���ɂ����ĐF��������(���͉�/�s�ɂ�)
			foreach (UltraGridCell wkCell in this.NoMngSet_uGrid.ActiveRow.Cells)
			{
				if ((wkCell.Column.CellActivation == Activation.NoEdit) ||
					(wkCell.Activation == Activation.NoEdit))
				{
					wkCell.Appearance = GetImpossibleCellAppearance();
				}
				else
				{
					wkCell.Appearance = GetPossibleCellAppearance();
				}
			}
		}

		/// <summary>
		/// UltraGrid.BeforeSelectChange�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �P�ȏ�̍s�A�Z���A�܂��͗�I�u�W�F�N�g���I���܂��͑I�����������O�ɔ������܂��B</br>
		/// <br>Programmer	: 22033 �O��  �M�j</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void NoMngSet_uGrid_BeforeSelectChange(object sender, Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs e)
		{
			e.Cancel = true;
		}
		
		/// <summary>
		/// UltraGrid.Leave�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �A�N�e�B�u�R���g���[���łȂ��Ȃ������ɔ������܂��B</br>
		/// <br>Programmer	: 22033 �O��  �M�j</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void NoMngSet_uGrid_Leave(object sender, System.EventArgs e)
		{
			if (this.NoMngSet_uGrid.ActiveCell != null)
			{
				// �A�N�e�B�u�������s�̃Z���̊O�ς�����
				foreach (UltraGridCell wkCell in this.NoMngSet_uGrid.ActiveRow.Cells)
				{
					wkCell.Appearance = null;
				}
				// �A�N�e�B�u�ȍs�A��̃C���f�b�N�X���o�b�t�@�Ɋm��
				this._leaveRowBuf = this.NoMngSet_uGrid.ActiveRow.Index;
				this._leaveColBuf = this.NoMngSet_uGrid.ActiveCell.Column.Index;
				this.NoMngSet_uGrid.PerformAction(UltraGridAction.DeactivateCell);
			}
		}

		/// <summary>
		/// UltraGrid.InitializeRow�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �s�����������ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22033 �O��  �M�j</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void NoMngSet_uGrid_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
		{
			// 2008.09.25 30413 ���� �ԍ����ݒl�A�ݒ�J�n�ԍ��A�ݒ�I���ԍ��̌�����9���Œ� >>>>>>START
            // �u�A�Ԍ����v�ɍ��킹�ē��͌�����ݒ�
            //e.Row.Cells[NOPRESENTVAL_TITLE].Column.MaxLength   = TStrConv.StrToIntDef(e.Row.Cells[CONSNOCHRCTERCOUNT_TITLE].Value.ToString(), 0);
            //e.Row.Cells[SETTINGSTARTNO_TITLE].Column.MaxLength = TStrConv.StrToIntDef(e.Row.Cells[CONSNOCHRCTERCOUNT_TITLE].Value.ToString(), 0);
            //e.Row.Cells[SETTINGENDNO_TITLE].Column.MaxLength   = TStrConv.StrToIntDef(e.Row.Cells[CONSNOCHRCTERCOUNT_TITLE].Value.ToString(), 0);
            e.Row.Cells[NOPRESENTVAL_TITLE].Column.MaxLength = 9;       // �ԍ����ݒl
            e.Row.Cells[SETTINGSTARTNO_TITLE].Column.MaxLength = 9;     // �ݒ�J�n�ԍ�
            e.Row.Cells[SETTINGENDNO_TITLE].Column.MaxLength = 9;       // �ݒ�I���ԍ�
            // 2008.09.25 30413 ���� �ԍ����ݒl�A�ݒ�J�n�ԍ��A�ݒ�I���ԍ��̌�����9���Œ� <<<<<<END
        }

		/// <summary>
		/// UltraGrid.InitializeLayout�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\�[�X����R���g���[���Ƀf�[�^�����[�h�����Ƃ��ȂǁA
		///					  �\�����C�A�E�g�������������Ƃ��ɔ������܂��B </br>
		/// <br>Programmer	: 22033 �O��  �M�j</br>
		/// <br>Date		: 2005.09.12</br>
		/// </remarks>
		private void NoMngSet_uGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			// �u�ԍ����́v�͕ҏW�s�i�Œ荀�ڂƂ��Đݒ�j
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NONAME_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			// ��\������
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOCODE_TITLE].Hidden = true;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[CONSNOCHRCTERCOUNT_TITLE].Hidden = true;

			// ���l���ڂ͕����ʒu���E�񂹂ɂ���
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOCODE_TITLE].CellAppearance.TextHAlign = HAlign.Right;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOPRESENTVAL_TITLE].CellAppearance.TextHAlign = HAlign.Right;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[SETTINGSTARTNO_TITLE].CellAppearance.TextHAlign = HAlign.Right;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[SETTINGENDNO_TITLE].CellAppearance.TextHAlign = HAlign.Right;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOINCDECWIDTH_TITLE].CellAppearance.TextHAlign = HAlign.Right;

			// �Z���̓��͌����ݒ肷��
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOINCDECWIDTH_TITLE].MaxLength = 2;

			// Cell��Size��ݒ�
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NONAME_TITLE].Width		   = 460;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOPRESENTVAL_TITLE].Width   = 100;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[SETTINGSTARTNO_TITLE].Width = 100;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[SETTINGENDNO_TITLE].Width   = 100;
			this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOINCDECWIDTH_TITLE].Width  = 100;
		}

		/// <summary>
		/// UltraGrid.AfterExitEditMode�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �Z�����ҏW���[�h���I��������ɔ������܂��B</br>
		/// <br>Programmer	: 22033 �O��  �M�j</br>
		/// <br>Date		: 2005.09.13</br>
		/// </remarks>
		private void NoMngSet_uGrid_AfterExitEditMode(object sender, System.EventArgs e)
		{
			// �u�ԍ����ݒl�v�̏ꍇ
			if (this.NoMngSet_uGrid.ActiveCell.Column == this.NoMngSet_uGrid.DisplayLayout.Bands[0].Columns[NOPRESENTVAL_TITLE])
			{
				// null���O�̏ꍇ
				if ((this.NoMngSet_uGrid.ActiveCell.Text == "") ||
					(this.NoMngSet_uGrid.ActiveCell.Text == "0"))
				{
					this.NoMngSet_uGrid.ActiveCell.Value = NOPRESENTVAL_NULL;
				}
			}
		}
		
		/// <summary>
		/// UltraGrid.KeyPress�C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note		: �O���b�h��ŉ����L�[�������I�������̐�����s���܂��B</br>
		/// <br>Programmer	: 22033 �O��  �M�j</br>
		/// <br>Date		: 2005.09.13</br>
		/// </remarks>
		private void NoMngSet_uGrid_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			// ����L�[�������ꂽ�H
			if (Char.IsControl(e.KeyChar))
			{
				return;
			}

			// ���l�ȊO�́A�m�f
            if (!Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            // 2009.02.23 30413 ���� UOE�����ԍ���6�����ɂ����͐��� >>>>>>START
            else
            {
                UltraGridCell cell = this.NoMngSet_uGrid.ActiveCell;
                if ((int)cell.Row.Cells[NOCODE_TITLE].Value == 3300)
                {
                    switch (cell.Column.Key)
                    {
                        case NOPRESENTVAL_TITLE:
                        case SETTINGSTARTNO_TITLE:
                        case SETTINGENDNO_TITLE:
                            {
                                if ((cell.SelText.Length == 0) && (cell.Text.Length >= 6))
                                {
                                    e.Handled = true;
                                }
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
            // 2009.02.23 30413 ���� UOE�����ԍ���6�����ɂ����͐��� >>>>>>START
        }

		/// <summary>
		/// UltraGrid.BeforeEnterEditMode�C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note		: �O���b�h��ŃG�f�B�b�g���[�h�J�n���O�ł̐�����s���܂��B</br>
		/// <br>Programmer	: 22033 �O��  �M�j</br>
		/// <br>Date		: 2005.09.13</br>
		/// </remarks>
		private void NoMngSet_uGrid_BeforeEnterEditMode(object sender, System.ComponentModel.CancelEventArgs e)
		{
			int rowIndex = this.NoMngSet_uGrid.ActiveCell.Row.Index;

			// �A�N�e�B�u�Z�����u�ԍ����ݒl�v�̏ꍇ
			if ((this.NoMngSet_uGrid.ActiveCell == this.NoMngSet_uGrid.Rows[rowIndex].Cells[NOPRESENTVAL_TITLE]) &&
				(this.NoMngSet_uGrid.ActiveCell.Text.Trim() == NOPRESENTVAL_NULL))
			{
				this.NoMngSet_uGrid.Rows[rowIndex].Cells[NOPRESENTVAL_TITLE].Value = 0;
			}
		}

		/// <summary>
		/// �O���b�h BeforeExitEditMode�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>�Z���̒l��null�ɂ��Ĕ��������̃G���[�Ή��p</remarks>
		private void NoMngSet_uGrid_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
		{
			if (((UltraGrid)sender).ActiveCell.Text == "")
			{
				((UltraGrid)sender).ActiveCell.Value = 0;
			}
		}
		#endregion

        /// <summary>
        /// �{�^�� InitSet_Button_Click�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �����l�{�^���̃N���b�N�C�x���g�̐�����s���܂�</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.09.25</br>
		/// </remarks>
        private void InitSet_Button_Click(object sender, EventArgs e)
        {
            // �O���b�h�̍s�����擾
            int maxRowCnt = this.NoMngSet_uGrid.Rows.Count;

            for (int i = 0; i < maxRowCnt; i++)
            {
                // �ԍ����ݒl�̃`�F�b�N
                if ((this.NoMngSet_uGrid.Rows[i].Cells[NOPRESENTVAL_TITLE].Text.Trim() == NOPRESENTVAL_NULL)
                    || (this.NoMngSet_uGrid.Rows[i].Cells[NOPRESENTVAL_TITLE].Text.Trim() == "")
                    || (this.NoMngSet_uGrid.Rows[i].Cells[NOPRESENTVAL_TITLE].Text.Trim() == "0"))
                {
                    // 2009.02.23 30413 ���� UOE�����ԍ���6�����ɂ�鏉���l�ݒ���C�� >>>>>>START
                    // �ԍ����ݒl�������l
                    // �ݒ�J�n�ԍ��A�ݒ�I���ԍ��A�ԍ����������`�F�b�N
                    if ((this.NoMngSet_uGrid.Rows[i].Cells[SETTINGSTARTNO_TITLE].Text.Trim() == "0")
                        && (this.NoMngSet_uGrid.Rows[i].Cells[SETTINGENDNO_TITLE].Text.Trim() == "0")
                        && (this.NoMngSet_uGrid.Rows[i].Cells[NOINCDECWIDTH_TITLE].Text.Trim() == "0"))
                    {
                        // �ݒ�J�n�ԍ��A�ݒ�I���ԍ��A�ԍ����������S�ă[��
                        this.NoMngSet_uGrid.Rows[i].Cells[SETTINGSTARTNO_TITLE].Value = 1;          // �ݒ�J�n�ԍ�
                        this.NoMngSet_uGrid.Rows[i].Cells[SETTINGENDNO_TITLE].Value = 999999999;    // �ݒ�I���ԍ�
                        if ((int)this.NoMngSet_uGrid.Rows[i].Cells[NOCODE_TITLE].Value != 3300)
                        {
                            // UOE�����ԍ��ȊO
                            this.NoMngSet_uGrid.Rows[i].Cells[SETTINGENDNO_TITLE].Value = 999999999;    // �ݒ�I���ԍ�
                        }
                        else
                        {
                            // UOE�����ԍ�
                            this.NoMngSet_uGrid.Rows[i].Cells[SETTINGENDNO_TITLE].Value = 999999;       // �ݒ�I���ԍ�
                        }
                        this.NoMngSet_uGrid.Rows[i].Cells[NOINCDECWIDTH_TITLE].Value = 1;           // �ԍ�������
                    }
                    // 2009.02.23 30413 ���� UOE�����ԍ���6�����ɂ�鏉���l�ݒ���C�� <<<<<<END
                }
            }
            
        }
    }
}
