//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[�����̐ݒ�}�X�^
// �v���O�����T�v   : �L�����y�[�����̐ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// Update Note      :   2011/05/06 杍^                         
//                  :   �@�ۑ��O�̃`�F�b�N������ǉ�
//                  :   �A�o�f���́A���ږ��̕ύX                               
//----------------------------------------------------------------------------//
// Update Note      :   2011/06/20 ������                         
//                  :   ���Ӑ�Ώۋ敪�u���~�v�𖳂����܂�
//----------------------------------------------------------------------------//
// Update Note      :   2011/07/28 ���J                         
//                  :   ��ʂ̃��b�Z�[�W��ύX
//----------------------------------------------------------------------------//

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
    /// �L�����y�[�����̐ݒ�}�X�^�t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note		: �L�����y�[�����̐ݒ�}�X�^���s���܂��B
	///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>   
    /// <br>Update Note:  2011/05/06 杍^</br>
    /// <br>              �@�ۑ��O�̃`�F�b�N������ǉ�</br>
    /// <br>�@�@�@�@�@�@�@�A�o�f���́A���ږ��̕ύX</br>
    /// </remarks>
	public class PMKHN09560UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region -- Component --

        private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraLabel CampaignCode_uLabel;
        private Broadleaf.Library.Windows.Forms.TNedit CampaignCode_tNedit;
        private Infragistics.Win.Misc.UltraLabel ApplyEndDate_uLabel;
        private Infragistics.Win.Misc.UltraLabel CampaignName_uLabel;
		private Infragistics.Win.Misc.UltraLabel Section_uLabel;
		private Broadleaf.Library.Windows.Forms.TEdit SectionName_tEdit;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Timer;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraLabel CampaignObjDiv_uLabel;
        private Infragistics.Win.Misc.UltraLabel ApplyStaDate_uLabel;
        private TComboEditor CampaignObjDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private TEdit tEdit_SectionCodeAllowZero;
        private UiSetControl uiSetControl1;
        private TEdit CampaignName_tEdit;
        private TDateEdit ApplyEndDate_TDateEdit;
        private TDateEdit ApplyStaDate_TDateEdit;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
		#endregion

		#region -- Constructor --
		/// <summary>
        /// �L�����y�[�����̐ݒ�}�X�^�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note		: �L�����y�[�����̐ݒ�}�X�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br></br>
		/// </remarks>
        public PMKHN09560UA()
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

            //�@��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �ϐ�������
            this._dataIndex = -1;
            this._campaignStAcs = new CampaignStAcs();
            this._totalCount = 0;
            this._campaignStTable = new Hashtable();

            //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // ���_�ݒ�A�N�Z�X�N���X
            this._secInfoAcs = new SecInfoAcs();

            // ���t�擾���i
            this._dateGetAcs = DateGetAcs.GetInstance();
        }
		#endregion

		private System.ComponentModel.IContainer components;

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
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���_�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09560UA));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CampaignCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.CampaignCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ApplyEndDate_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.CampaignName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Section_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.CampaignObjDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ApplyStaDate_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.CampaignObjDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SectionCodeAllowZero = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.CampaignName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ApplyEndDate_TDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ApplyStaDate_TDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignObjDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignName_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(621, 242);
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
            this.Ok_Button.Location = new System.Drawing.Point(494, 242);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 14;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 285);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(759, 23);
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
            this.Mode_Label.Location = new System.Drawing.Point(635, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 61;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // CampaignCode_uLabel
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.CampaignCode_uLabel.Appearance = appearance10;
            this.CampaignCode_uLabel.Location = new System.Drawing.Point(16, 44);
            this.CampaignCode_uLabel.Name = "CampaignCode_uLabel";
            this.CampaignCode_uLabel.Size = new System.Drawing.Size(165, 24);
            this.CampaignCode_uLabel.TabIndex = 171;
            this.CampaignCode_uLabel.Text = "�L�����y�[���R�[�h";
            // 
            // CampaignCode_tNedit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            this.CampaignCode_tNedit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.CampaignCode_tNedit.Appearance = appearance9;
            this.CampaignCode_tNedit.AutoSelect = true;
            this.CampaignCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CampaignCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CampaignCode_tNedit.DataText = "";
            this.CampaignCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CampaignCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CampaignCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CampaignCode_tNedit.Location = new System.Drawing.Point(201, 44);
            this.CampaignCode_tNedit.MaxLength = 6;
            this.CampaignCode_tNedit.Name = "CampaignCode_tNedit";
            this.CampaignCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.CampaignCode_tNedit.Size = new System.Drawing.Size(84, 24);
            this.CampaignCode_tNedit.TabIndex = 0;
            // 
            // ApplyEndDate_uLabel
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.ApplyEndDate_uLabel.Appearance = appearance26;
            this.ApplyEndDate_uLabel.Location = new System.Drawing.Point(16, 194);
            this.ApplyEndDate_uLabel.Name = "ApplyEndDate_uLabel";
            this.ApplyEndDate_uLabel.Size = new System.Drawing.Size(165, 24);
            this.ApplyEndDate_uLabel.TabIndex = 177;
            this.ApplyEndDate_uLabel.Text = "�K�p�I����";
            // 
            // CampaignName_uLabel
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.CampaignName_uLabel.Appearance = appearance22;
            this.CampaignName_uLabel.Location = new System.Drawing.Point(16, 74);
            this.CampaignName_uLabel.Name = "CampaignName_uLabel";
            this.CampaignName_uLabel.Size = new System.Drawing.Size(165, 24);
            this.CampaignName_uLabel.TabIndex = 179;
            this.CampaignName_uLabel.Text = "�L�����y�[������";
            // 
            // Section_uLabel
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.Section_uLabel.Appearance = appearance4;
            this.Section_uLabel.Location = new System.Drawing.Point(16, 104);
            this.Section_uLabel.Name = "Section_uLabel";
            this.Section_uLabel.Size = new System.Drawing.Size(165, 24);
            this.Section_uLabel.TabIndex = 184;
            this.Section_uLabel.Text = "���_";
            // 
            // SectionName_tEdit
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance27.ForeColor = System.Drawing.Color.Black;
            this.SectionName_tEdit.ActiveAppearance = appearance27;
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            appearance28.TextHAlignAsString = "Left";
            this.SectionName_tEdit.Appearance = appearance28;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SectionName_tEdit.Location = new System.Drawing.Point(235, 104);
            this.SectionName_tEdit.MaxLength = 10;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.ReadOnly = true;
            this.SectionName_tEdit.Size = new System.Drawing.Size(195, 24);
            this.SectionName_tEdit.TabIndex = 1;
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
            // SectionGuide_Button
            // 
            this.SectionGuide_Button.Location = new System.Drawing.Point(436, 104);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.SectionGuide_Button.TabIndex = 3;
            ultraToolTipInfo1.ToolTipText = "���_�K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_Button, ultraToolTipInfo1);
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // CampaignObjDiv_uLabel
            // 
            appearance68.TextVAlignAsString = "Middle";
            this.CampaignObjDiv_uLabel.Appearance = appearance68;
            this.CampaignObjDiv_uLabel.Location = new System.Drawing.Point(16, 134);
            this.CampaignObjDiv_uLabel.Name = "CampaignObjDiv_uLabel";
            this.CampaignObjDiv_uLabel.Size = new System.Drawing.Size(165, 24);
            this.CampaignObjDiv_uLabel.TabIndex = 253;
            this.CampaignObjDiv_uLabel.Text = "�Ώۓ��Ӑ�敪";
            // 
            // ApplyStaDate_uLabel
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.ApplyStaDate_uLabel.Appearance = appearance63;
            this.ApplyStaDate_uLabel.Location = new System.Drawing.Point(16, 164);
            this.ApplyStaDate_uLabel.Name = "ApplyStaDate_uLabel";
            this.ApplyStaDate_uLabel.Size = new System.Drawing.Size(165, 24);
            this.ApplyStaDate_uLabel.TabIndex = 258;
            this.ApplyStaDate_uLabel.Text = "�K�p�J�n��";
            // 
            // CampaignObjDiv_tComboEditor
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextVAlignAsString = "Middle";
            this.CampaignObjDiv_tComboEditor.ActiveAppearance = appearance58;
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance59.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            this.CampaignObjDiv_tComboEditor.Appearance = appearance59;
            this.CampaignObjDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CampaignObjDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.CampaignObjDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CampaignObjDiv_tComboEditor.ItemAppearance = appearance60;
            this.CampaignObjDiv_tComboEditor.Location = new System.Drawing.Point(201, 134);
            this.CampaignObjDiv_tComboEditor.Name = "CampaignObjDiv_tComboEditor";
            this.CampaignObjDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.CampaignObjDiv_tComboEditor.TabIndex = 4;
            // 
            // ultraLabel6
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance34;
            this.ultraLabel6.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel6.Location = new System.Drawing.Point(467, 101);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(273, 65);
            this.ultraLabel6.TabIndex = 262;
            this.ultraLabel6.Text = "�����_�͑Ώۏ��i�ݒ�}�X�^�o�^����\n�@�����l�Ɏg�p���܂�\n�@�[���ŋ��ʐݒ�ɂȂ�܂�";
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(493, 242);
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
            this.Delete_Button.Location = new System.Drawing.Point(365, 242);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 13;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // tEdit_SectionCodeAllowZero
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance7.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero.ActiveAppearance = appearance7;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero.Appearance = appearance11;
            this.tEdit_SectionCodeAllowZero.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero.DataText = "";
            this.tEdit_SectionCodeAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, true, true, true));
            this.tEdit_SectionCodeAllowZero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_SectionCodeAllowZero.Location = new System.Drawing.Point(201, 104);
            this.tEdit_SectionCodeAllowZero.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero.Name = "tEdit_SectionCodeAllowZero";
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero.TabIndex = 2;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(364, 242);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 13;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // CampaignName_tEdit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance12.ForeColor = System.Drawing.Color.Black;
            this.CampaignName_tEdit.ActiveAppearance = appearance12;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.ForeColorDisabled = System.Drawing.Color.Black;
            appearance29.TextHAlignAsString = "Left";
            this.CampaignName_tEdit.Appearance = appearance29;
            this.CampaignName_tEdit.AutoSelect = true;
            this.CampaignName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CampaignName_tEdit.DataText = "";
            this.CampaignName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CampaignName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.CampaignName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CampaignName_tEdit.Location = new System.Drawing.Point(201, 74);
            this.CampaignName_tEdit.MaxLength = 30;
            this.CampaignName_tEdit.Name = "CampaignName_tEdit";
            this.CampaignName_tEdit.Size = new System.Drawing.Size(544, 24);
            this.CampaignName_tEdit.TabIndex = 1;
            // 
            // ApplyEndDate_TDateEdit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ApplyEndDate_TDateEdit.ActiveEditAppearance = appearance14;
            this.ApplyEndDate_TDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ApplyEndDate_TDateEdit.CalendarDisp = true;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.ApplyEndDate_TDateEdit.EditAppearance = appearance15;
            this.ApplyEndDate_TDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ApplyEndDate_TDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ApplyEndDate_TDateEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            appearance16.TextHAlignAsString = "Left";
            appearance16.TextVAlignAsString = "Middle";
            this.ApplyEndDate_TDateEdit.LabelAppearance = appearance16;
            this.ApplyEndDate_TDateEdit.Location = new System.Drawing.Point(201, 194);
            this.ApplyEndDate_TDateEdit.Name = "ApplyEndDate_TDateEdit";
            this.ApplyEndDate_TDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ApplyEndDate_TDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ApplyEndDate_TDateEdit.Size = new System.Drawing.Size(172, 24);
            this.ApplyEndDate_TDateEdit.TabIndex = 6;
            this.ApplyEndDate_TDateEdit.TabStop = true;
            // 
            // ApplyStaDate_TDateEdit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ApplyStaDate_TDateEdit.ActiveEditAppearance = appearance17;
            this.ApplyStaDate_TDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ApplyStaDate_TDateEdit.CalendarDisp = true;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            this.ApplyStaDate_TDateEdit.EditAppearance = appearance18;
            this.ApplyStaDate_TDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ApplyStaDate_TDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ApplyStaDate_TDateEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            appearance19.TextHAlignAsString = "Left";
            appearance19.TextVAlignAsString = "Middle";
            this.ApplyStaDate_TDateEdit.LabelAppearance = appearance19;
            this.ApplyStaDate_TDateEdit.Location = new System.Drawing.Point(201, 164);
            this.ApplyStaDate_TDateEdit.Name = "ApplyStaDate_TDateEdit";
            this.ApplyStaDate_TDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ApplyStaDate_TDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ApplyStaDate_TDateEdit.Size = new System.Drawing.Size(172, 24);
            this.ApplyStaDate_TDateEdit.TabIndex = 5;
            this.ApplyStaDate_TDateEdit.TabStop = true;
            // 
            // PMKHN09560UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(759, 308);
            this.Controls.Add(this.ApplyEndDate_TDateEdit);
            this.Controls.Add(this.ApplyStaDate_TDateEdit);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.SectionGuide_Button);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.CampaignObjDiv_tComboEditor);
            this.Controls.Add(this.ApplyStaDate_uLabel);
            this.Controls.Add(this.CampaignObjDiv_uLabel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.CampaignName_tEdit);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.Section_uLabel);
            this.Controls.Add(this.CampaignName_uLabel);
            this.Controls.Add(this.ApplyEndDate_uLabel);
            this.Controls.Add(this.CampaignCode_tNedit);
            this.Controls.Add(this.CampaignCode_uLabel);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09560UA";
            this.Text = "�L�����y�[�����̐ݒ�}�X�^";
            this.Load += new System.EventHandler(this.PMKHN09560UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09560UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN09560UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.CampaignCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignObjDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignName_tEdit)).EndInit();
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
		private CampaignStAcs _campaignStAcs;
        private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _campaignStTable;

        private SecInfoAcs _secInfoAcs;

        // ���t�擾���i
        private DateGetAcs _dateGetAcs;

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        
		// �ۑ���r�pClone
		private CampaignSt _campaignStClone;

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int	 _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _indexBuf;

        // �V�K���[�h���烂�[�h�ύX�Ή�
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;

        private const string PROGRAM_ID = "PMKHN09560U";    // �v���O����ID

        // View�pGrid�ɕ\��������e�[�u����
        private const string VIEW_TABLE = "VIEW_TABLE";

		// Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const string DELETE_DATE = "�폜��";

        private const string VIEW_SECTION_CODE_TITLE = "���_�R�[�h";
        private const string VIEW_SECTION_NAME_TITLE = "���_����";

        private const string VIEW_CAMPAIGN_CODE = "�L�����y�[���R�[�h";
        private const string VIEW_CAMPAIGN_NAME = "�L�����y�[������";
        private const string VIEW_CAMPAIGN_OBJ_DIV = "�L�����y�[���Ώۋ敪";
        private const string VIEW_APPLY_STA_DATE = "�K�p�J�n��";
        private const string VIEW_APPLY_END_DATE = "�K�p�I����";
        
        private const string VIEW_GUID_KEY_TITLE = "Guid";
		
		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";	   
		private const string DELETE_MODE = "�폜���[�h";

        // ���̓`�F�b�N
        private const string ct_InputError = "�̓��͂��s���ł�";
        private const string ct_NoInput = "����͂��ĉ�����";

        // �S�Ћ���
        private const string ALL_SECTIONCODE = "00";
        
		#endregion

		#region -- Main --
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new PMKHN09560UA());
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
		/// <br>Note		: �t���[�����̃O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
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
		/// <br>Note		: �擪����w�茏�����̃f�[�^���������A</br>
		///	<br>			  ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
		/// <br></br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList retList = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._campaignStTable.Clear();

            // �S����
            status = this._campaignStAcs.SearchAll(out retList, this._enterpriseCode);
            this._totalCount = retList.Count;

			switch(status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    int index = 0;

                    foreach (CampaignSt campaignSt in retList)
					{
                        // �L�����y�[���ݒ���N���X�̃f�[�^�Z�b�g�W�J����
                        CampaignStToDataSet(campaignSt.Clone(), index);
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
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                        PROGRAM_ID,							    // �A�Z���u��ID
                        this.Text,              �@�@            // �v���O��������
						"Search",                               // ��������
						TMsgDisp.OPE_GET,                       // �I�y���[�V����
						"�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._campaignStAcs,					    // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��

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
		/// <br>Note		: �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
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
            CampaignSt campaignSt = (CampaignSt)this._campaignStTable[guid];

            // �S�Ћ��ʃf�[�^�͍폜�\
            //// �S�Ћ��ʃf�[�^�͍폜�s��
            //if (campaignSt.SectionCode.Trim() == ALL_SECTIONCODE)
            //{
            //    TMsgDisp.Show(this,                             // �e�E�B���h�E�t�H�[��
            //            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
            //            PROGRAM_ID,							    // �A�Z���u��ID
            //            "�S�Ћ��ʃf�[�^�͍폜�ł��܂���B",	    // �\�����郁�b�Z�[�W
            //            0,									    // �X�e�[�^�X�l
            //            MessageBoxButtons.OK);					// �\������{�^��
            //    return (0);
            //}
            
            int status;

            // �L�����y�[���ݒ���̘_���폜����
            status = this._campaignStAcs.LogicalDelete(ref campaignSt);
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
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete", 							// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._campaignStAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
            }

            // �L�����y�[���ݒ���N���X�̃f�[�^�Z�b�g�W�J����
            CampaignStToDataSet(campaignSt.Clone(), this.DataIndex);

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
            // �L�����y�[���R�[�h
            appearanceTable.Add(VIEW_CAMPAIGN_CODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "000000", Color.Black));
            // �L�����y�[������
            appearanceTable.Add(VIEW_CAMPAIGN_NAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���_�R�[�h
            appearanceTable.Add(VIEW_SECTION_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���_����
			appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            // �L�����y�[���Ώۋ敪
            appearanceTable.Add(VIEW_CAMPAIGN_OBJ_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �K�p�J�n��
            appearanceTable.Add(VIEW_APPLY_STA_DATE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �K�p�I����
            appearanceTable.Add(VIEW_APPLY_END_DATE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // Guid
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			
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
                CampaignSt campaignSt = new CampaignSt();
                //�N���[���쐬
                this._campaignStClone = campaignSt.Clone();
                this._indexBuf = this._dataIndex;

                // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                ScreenToCampaignSt(ref this._campaignStClone);

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // �t�H�[�J�X�ݒ�
                this.CampaignCode_tNedit.Focus();
            }
            else
            {
                // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                CampaignSt campaignSt = (CampaignSt)this._campaignStTable[guid];

                // �L�����y�[���ݒ�N���X��ʓW�J����
                CampaignStToScreen(campaignSt);

                if (campaignSt.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.CampaignName_tEdit.Focus();

                    // �N���[���쐬
                    this._campaignStClone = campaignSt.Clone();

                    // ��ʏ����r�p�N���[���ɃR�s�[���܂��@   
                    ScreenToCampaignSt(ref this._campaignStClone);
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
                        this.CampaignName_tEdit.Enabled = true;
                        this.tEdit_SectionCodeAllowZero.Enabled = true;
                        this.SectionName_tEdit.Enabled = false;
                        this.SectionGuide_Button.Enabled = true;
                        this.CampaignObjDiv_tComboEditor.Enabled = true;
                        this.ApplyStaDate_TDateEdit.Enabled = true;
                        this.ApplyEndDate_TDateEdit.Enabled = true;
                        
                        if (mode == INSERT_MODE)
                        {
                            // �V�K���[�h
                            this.CampaignCode_tNedit.Enabled = true;
                        }
                        else
                        {
                            // �X�V���[�h
                            this.CampaignCode_tNedit.Enabled = false;
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
                        this.CampaignCode_tNedit.Enabled = false;
                        this.CampaignName_tEdit.Enabled = false;
                        this.tEdit_SectionCodeAllowZero.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.SectionName_tEdit.Enabled = false;
                        this.CampaignObjDiv_tComboEditor.Enabled = false;
                        this.ApplyStaDate_TDateEdit.Enabled = false;
                        this.ApplyEndDate_TDateEdit.Enabled = false;
                        
                        break;
                    }
            }
        }

		/// <summary>
		/// �L�����y�[���ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
        /// <param name="campaignSt">�L�����y�[���ݒ�I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
        /// <br>Note       : �L�����y�[���ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br></br>
        /// <br>Update Note: 2011/06/20 ������</br>
        /// <br>             ���Ӑ�Ώۋ敪�u���~�v�𖳂����܂�</br>
		/// </remarks>
		private void CampaignStToDataSet(CampaignSt campaignSt, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
			}

            if (campaignSt.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = campaignSt.UpdateDateTimeJpInFormal;
            }

            // �L�����y�[���R�[�h
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CAMPAIGN_CODE] = campaignSt.CampaignCode;

            // �L�����y�[������
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CAMPAIGN_NAME] = campaignSt.CampaignName;

			// ���_�R�[�h
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = campaignSt.SectionCode;
            // ���_����
            string sectionName = GetSectionName(campaignSt.SectionCode);
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = sectionName;
            
            // �L�����y�[���Ώۋ敪
            switch (campaignSt.CampaignObjDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CAMPAIGN_OBJ_DIV] = "�S���Ӑ�";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CAMPAIGN_OBJ_DIV] = "�Ώۓ��Ӑ�";
                    break;
                // ---DEL 2011/06/20--------------->>>>>
                //case 9:
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CAMPAIGN_OBJ_DIV] = "���~";
                //    break;
                // ---DEL 2011/06/20---------------<<<<<
            }

            // �K�p�J�n��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_APPLY_STA_DATE] = campaignSt.ApplyStaDateAdFormal;

            // �K�p�I����
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_APPLY_END_DATE] = campaignSt.ApplyEndDateAdFormal;

            // Guid
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = campaignSt.FileHeaderGuid;
			
			if (this._campaignStTable.ContainsKey(campaignSt.FileHeaderGuid) == true)
			{
				this._campaignStTable.Remove(campaignSt.FileHeaderGuid);
			}
			this._campaignStTable.Add(campaignSt.FileHeaderGuid, campaignSt);
		}

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
		/// <br></br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable campaignStTable = new DataTable(VIEW_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B

            campaignStTable.Columns.Add(DELETE_DATE, typeof(string));			        // �폜��

            campaignStTable.Columns.Add(VIEW_CAMPAIGN_CODE, typeof(int));               // �L�����y�[���R�[�h
            campaignStTable.Columns.Add(VIEW_CAMPAIGN_NAME, typeof(string));            // �L�����y�[������
            
            campaignStTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));       // ���_�R�[�h
			campaignStTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));       // ���_����

            campaignStTable.Columns.Add(VIEW_CAMPAIGN_OBJ_DIV, typeof(string));         // �L�����y�[���Ώۋ敪
            campaignStTable.Columns.Add(VIEW_APPLY_STA_DATE, typeof(string));           // �K�p�J�n��
            campaignStTable.Columns.Add(VIEW_APPLY_END_DATE, typeof(string));           // �K�p�I����
            
            campaignStTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));             // Guid

			this.Bind_DataSet.Tables.Add(campaignStTable);
		}

        // ------ ADD 2011/05/06 ------------->>>>>
        /// <summary>
        /// �ݒ��ʓ��͂̎��ԃ`�F�b�N����
        /// </summary>
        ///  <remarks>
        /// <br>Note       : �ݒ��ʓ��͂̎��ԃ`�F�b�N�������܂��B </br>
        /// <returns>FLAG</returns>
        /// </remarks>
        private bool DateCheck()
        {   
            bool flag = true;

            DateTime endDt = this.ApplyEndDate_TDateEdit.GetDateTime();
            DateTime staDt=this.ApplyStaDate_TDateEdit.GetDateTime();

            if ((endDt.Year - staDt.Year) > 1)//���ԑ嘰�P�N�Ԃ̏ꍇ
            {
                flag = false;
            }
            else if (endDt.Year - staDt.Year == 1)
            {
                if (endDt.Month > staDt.Month) //����r
                {
                    flag = false;
                }
                else if((endDt.Month == staDt.Month) && (endDt.Day >= staDt.Day))
                {
                    flag = false;
                }
            }
            return flag;
        }
        // ------ ADD 2011/05/06 -------------<<<<<

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br></br>
        /// <br>Update Note: 2011/06/20 ������</br>
        /// <br>             ���Ӑ�Ώۋ敪�u���~�v�𖳂����܂�</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
            // �L�����y�[���Ώۋ敪
            CampaignObjDiv_tComboEditor.Items.Clear();
            CampaignObjDiv_tComboEditor.Items.Add(0, "�S���Ӑ�");
            CampaignObjDiv_tComboEditor.Items.Add(1, "�Ώۓ��Ӑ�");
            //CampaignObjDiv_tComboEditor.Items.Add(9, "���~"); // DEL 2011/06/20
            CampaignObjDiv_tComboEditor.MaxDropDownItems = CampaignObjDiv_tComboEditor.Items.Count;

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
            this.tEdit_SectionCodeAllowZero.DataText = "";
            
            this.CampaignCode_tNedit.DataText = "";                 // �L�����y�[���R�[�h
            this.CampaignName_tEdit.DataText = "";                  // �L�����y�[������
            this.SectionName_tEdit.DataText = "";                   // ���_�R�[�h
            this.CampaignObjDiv_tComboEditor.SelectedIndex = 0;     // �L�����y�[���Ώۋ敪
            this.ApplyStaDate_TDateEdit.Clear();                    // �K�p�J�n��
            this.ApplyEndDate_TDateEdit.Clear();                    // �K�p�I����
        }

		/// <summary>
        /// �L�����y�[���ݒ�N���X��ʓW�J����
		/// </summary>
        /// <param name="campaignSt">�L�����y�[���ݒ�I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : �L�����y�[���ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br></br>
		/// </remarks>
		private void CampaignStToScreen(CampaignSt campaignSt)
		{
            // �L�����y�[���R�[�h
            this.CampaignCode_tNedit.SetInt(campaignSt.CampaignCode);

            // �L�����y�[������
            this.CampaignName_tEdit.DataText = campaignSt.CampaignName;

            // ���_�R�[�h
            this.tEdit_SectionCodeAllowZero.DataText = campaignSt.SectionCode.Trim();
            // ���_����
            string sectionName = string.Empty;
            if (campaignSt.SectionCode.Trim().Equals(ALL_SECTIONCODE))
            {
                sectionName = "�S�Ћ���";
            }
            else
            {
                sectionName = this.GetSectionName(campaignSt.SectionCode);
            }
            this.SectionName_tEdit.DataText = sectionName;

            // �L�����y�[���Ώۋ敪
            this.CampaignObjDiv_tComboEditor.Value = campaignSt.CampaignObjDiv;

            // �K�p�J�n��
            this.ApplyStaDate_TDateEdit.SetDateTime(campaignSt.ApplyStaDate);

            // �K�p�I����
            this.ApplyEndDate_TDateEdit.SetDateTime(campaignSt.ApplyEndDate);
        }

		/// <summary>
        /// ��ʏ��L�����y�[���ݒ�N���X�i�[����
		/// </summary>
        /// <param name="campaignSt">�L�����y�[���ݒ�I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : ��ʏ�񂩂�L�����y�[���ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br></br>
        /// <br>Update Note: 2011/06/20 ������</br>
        /// <br>             ���Ӑ�Ώۋ敪�u���~�v�𖳂����܂�</br>
		/// </remarks>
		private void ScreenToCampaignSt(ref CampaignSt campaignSt)
		{
			if (campaignSt == null)
			{
				// �V�K�̏ꍇ
                campaignSt = new CampaignSt();
			}

            //��ƃR�[�h
            campaignSt.EnterpriseCode = this._enterpriseCode; 
            
            // �L�����y�[���R�[�h
            campaignSt.CampaignCode = this.CampaignCode_tNedit.GetInt();

            // �L�����y�[������
            campaignSt.CampaignName = this.CampaignName_tEdit.DataText;

            // ���_�R�[�h
            campaignSt.SectionCode = this.tEdit_SectionCodeAllowZero.DataText;

            // ---UPD 2011/06/20-------------->>>>>
            if (this.CampaignObjDiv_tComboEditor.Value == null)
            {
                // �L�����y�[���Ώۋ敪
                campaignSt.CampaignObjDiv = -1;
            }
            else
            {
                // �L�����y�[���Ώۋ敪
                campaignSt.CampaignObjDiv = (int)this.CampaignObjDiv_tComboEditor.Value;
            }
            // ---UPD 2011/06/20--------------<<<<<

            // �K�p�J�n��
            campaignSt.ApplyStaDate = this.ApplyStaDate_TDateEdit.GetDateTime();

            // �K�p�I����
            campaignSt.ApplyEndDate = this.ApplyEndDate_TDateEdit.GetDateTime();
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
            this._campaignStClone = null;

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
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
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
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
		}

		/// <summary>
		///	�L�����y�[���ݒ��ʓ��̓`�F�b�N����
		/// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N����(true:OK�^false:NG)</returns>
        /// <remarks>
        /// <br>Note	   : �L�����y�[���ݒ��ʂ̓��̓`�F�b�N�����܂��B</br>
        /// <br></br>
        /// <br>Update Note: 2011/06/20 ������</br>
        /// <br>             ���Ӑ�Ώۋ敪�u���~�v�𖳂����܂�</br>
		/// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
		{
            DateGetAcs.CheckDateResult cdResult;

            // �L�����y�[���R�[�h
            if (this.CampaignCode_tNedit.DataText == "")
            {
                message = this.CampaignCode_uLabel.Text + "��ݒ肵�ĉ������B";
                control = this.CampaignCode_tNedit;
                return false;
            }

            // �L�����y�[������
            if (this.CampaignName_tEdit.DataText == "")
            {
                message = this.CampaignName_uLabel.Text + "��ݒ肵�ĉ������B";
                control = this.CampaignName_tEdit;
                return false;
            }

            // ���_�R�[�h
            if (this.tEdit_SectionCodeAllowZero.DataText == "")
            {
                message = this.Section_uLabel.Text + "��ݒ肵�ĉ������B";
                control = this.tEdit_SectionCodeAllowZero;
                return false;
            }

            // ---ADD 2011/06/20------------->>>>>
            // �Ώۓ��Ӑ�敪
            if (this.CampaignObjDiv_tComboEditor.SelectedIndex != 0
                && this.CampaignObjDiv_tComboEditor.SelectedIndex != 1)
            {
                message = this.CampaignObjDiv_uLabel.Text + "��ݒ肵�ĉ������B";
                control = this.CampaignObjDiv_tComboEditor;
                return false;
            }
            // ---ADD 2011/06/20-------------<<<<<

            // �K�p�J�n��
            if (CallCheckDate(out cdResult, ref this.ApplyStaDate_TDateEdit) == false)
            {
                // ������
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            message = string.Format("�K�p�J�n��{0}", ct_InputError);
                            control = this.ApplyStaDate_TDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            message = string.Format("�K�p�J�n��{0}", ct_NoInput);
                            control = this.ApplyStaDate_TDateEdit;
                        }
                        break;
                }
                return false;
            }

            // �K�p�I����
            if (CallCheckDate(out cdResult, ref this.ApplyEndDate_TDateEdit) == false)
            {
                // ������
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            message = string.Format("�K�p�I����{0}", ct_InputError);
                            control = this.ApplyEndDate_TDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            message = string.Format("�K�p�I����{0}", ct_NoInput);
                            control = this.ApplyEndDate_TDateEdit;
                        }
                        break;
                }
                return false;
            }

            if (this.ApplyStaDate_TDateEdit.GetLongDate() > this.ApplyEndDate_TDateEdit.GetLongDate())
            {
                message = "�u�K�p�J�n���@���@�K�p�I�����v�Őݒ肵�Ă��������B";
                control = this.ApplyStaDate_TDateEdit;
                return false;
            }

            return true;
		}

        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdResult"></param>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit)
        {
            cdResult = this._dateGetAcs.CheckDate(ref targetDateEdit, false);
            return (cdResult == DateGetAcs.CheckDateResult.OK);
        }

		/// <summary>
        ///�@�ۑ�����(SaveProc())
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
		/// <br></br>
		/// </remarks>
		private bool SaveProc()
		{
			bool result = false;
            
			//��ʃf�[�^���̓`�F�b�N����
            Control control = null;
            string message = null;

            /*-----DEL 2011/07/28 -------------->>>>>
            // ------ ADD 2011/05/06 ------------->>>>>
            bool flag = DateCheck();
            if (!flag)
            {
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO,        // �G���[���x��
                    PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                    "�K�p���͈̔͂͂P�N�ȓ��œ��͂��ĉ������B",// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.ApplyStaDate_TDateEdit.Focus();
                return result;
            }
            // ------ ADD 2011/05/06 -------------<<<<<
            -----DEL 2011/07/28 --------------<<<<<*/

            if (!ScreenDataCheck(ref control, ref message))
            {
                // ���̓`�F�b�N
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message, 							// �\�����郁�b�Z�[�W
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

            // ------ ADD 2011/07/28 ------------->>>>>
            bool flag = DateCheck();
            if (!flag)
            {
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO,        // �G���[���x��
                    PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                    "�K�p���͈̔͂͂P�N�ȓ��œ��͂��ĉ������B",// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                this.ApplyStaDate_TDateEdit.Focus();
                return result;
            }
            // ------ ADD 2011/07/28 -------------<<<<<
	
			CampaignSt campaignSt = null;

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                campaignSt = ((CampaignSt)this._campaignStTable[guid]).Clone();
			}

            // ��ʏ����擾
			ScreenToCampaignSt(ref campaignSt);
            // �o�^�E�X�V����
			int status = this._campaignStAcs.Write(ref campaignSt);

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
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                        PROGRAM_ID,							    // �A�Z���u��ID
						this.Text,  �@�@                        // �v���O��������
                        "SaveProc",                             // ��������
						TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
						"�o�^�Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._campaignStAcs,				    	// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,			  		// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��
                    CloseForm(DialogResult.Cancel);
					return false;
				}
			}

            // �L�����y�[���ݒ���N���X�̃f�[�^�Z�b�g�W�J����
			CampaignStToDataSet(campaignSt, this.DataIndex);

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
        ///�@���������b�Z�[�W�\��
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �Y���R�[�h���g�p����Ă���ꍇ�Ƀ��b�Z�[�W��\�����܂��B</br>
        /// <br></br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                "���̃R�[�h�͊��Ɏg�p����Ă��܂�" ,// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK);				// �\������{�^��
                tEdit_SectionCodeAllowZero.Focus();

                control = tEdit_SectionCodeAllowZero;
        }

        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃T�C�Y�ݒ菈�����s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.SectionName_tEdit.Size = new System.Drawing.Size(195, 24);
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_���� ���Y��������̂��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // �S�Ћ��ʃ`�F�b�N
            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                sectionName = "�S�Ћ���";
                return sectionName;
            }

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
                sectionName = null;
            }
            catch
            {
                sectionName = null;
            }

            return sectionName;
        }

        # endregion

        # region -- Control Events --
       	/// <summary>
        ///	Form.Load �C�x���g(PMKHN09560UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br></br>
		/// </remarks>
		private void PMKHN09560UA_Load(object sender, System.EventArgs e)
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

            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            
            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();
            
			// ��ʏ����ݒ菈��
			ScreenInitialSetting();
		}

		/// <summary>
        ///	Form.Closing �C�x���g(PMKHN09560UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�������O�ɁA���[�U�[���t�H�[�����
		///					  �悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br></br>
		/// </remarks>
		private void PMKHN09560UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        ///	Form.VisibleChanged �C�x���g(PMKHN09560UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �t�H�[���̕\���E��\�����؂�ւ����
		///					  ���Ƃ��ɔ������܂��B</br>
		/// <br></br>
		/// </remarks>
		private void PMKHN09560UA_VisibleChanged(object sender, System.EventArgs e)
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
		/// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
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
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br></br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʂ̃f�[�^���擾����
                CampaignSt compareCampaignSt = new CampaignSt();

                compareCampaignSt = this._campaignStClone.Clone();
                ScreenToCampaignSt(ref compareCampaignSt);

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                if ((!(this._campaignStClone.Equals(compareCampaignSt))))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
                        PROGRAM_ID, 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
                        null, 					                              // �\�����郁�b�Z�[�W
                        0, 					                                  // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	                      // �\������{�^��

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
                                    CampaignCode_tNedit.Focus();
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
		/// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
		///					  �X���b�h�Ŏ��s����܂��B</br>
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
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                //status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet); // DEL 2011/05/06
                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);  // ADD 2011/05/06

                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();

                    this.CampaignObjDiv_tComboEditor.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);	// �\������{�^��

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // �ێ����Ă���f�[�^�Z�b�g�����擾
			Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            CampaignSt campaignSt = (CampaignSt)this._campaignStTable[guid];

			// ���S�폜����
            int status = this._campaignStAcs.Delete(campaignSt);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                    this._campaignStTable.Remove(campaignSt.FileHeaderGuid);

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
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                        PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text, 				            // �v���O��������
						"Delete_Button_Click", 				// ��������
						TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
						"�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
                        this._campaignStAcs, 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
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
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            Guid guid;

            // �����Ώۃf�[�^�擾
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            CampaignSt campaignSt = ((CampaignSt)this._campaignStTable[guid]).Clone();

            // ��������
            status = this._campaignStAcs.Revival(ref campaignSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �L�����y�[���ݒ���N���X�̃f�[�^�Z�b�g�W�J����
                        CampaignStToDataSet(campaignSt, this._dataIndex);
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
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "Revive_Button_Click",				// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�����Ɏ��s���܂����B",			    // �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._campaignStAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
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
            
            if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero)
            {
                // ���_�R�[�h�擾
                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText;

                // ���_���̎擾
                string sectionName = GetSectionName(sectionCode);
                if (sectionName == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���_�����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK
                    );
                    this.tEdit_SectionCodeAllowZero.Clear();
                    this.SectionName_tEdit.Clear();
                    //e.NextCtrl = SectionGuide_Button;
                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                    e.NextCtrl.Select();
                    return;
                }
                this.SectionName_tEdit.DataText = sectionName;

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.SectionName_tEdit.DataText.Trim() != "")
                        {
                            // �t�H�[�J�X�ݒ�
                            e.NextCtrl = this.CampaignObjDiv_tComboEditor;
                        }
                    }
                }
            }
            else if (e.PrevCtrl == CampaignCode_tNedit)
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
                        e.NextCtrl = CampaignCode_tNedit;
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
                else if (e.NextCtrl.Name == "CampaignCode_tNedit")
                {
                    ;
                }
                else if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = CampaignCode_tNedit;
                    }
                }
            }
            else if (e.PrevCtrl == CampaignObjDiv_tComboEditor)
            {
                if ((e.ShiftKey) && (e.Key == Keys.Tab))
                {
                    // SHIFT+TAB����
                    if (!tEdit_SectionCodeAllowZero.Enabled)
                    {
                        e.NextCtrl = CampaignName_tEdit;
                    }
                    else
                    {
                        if (SectionName_tEdit.DataText != "")
                        {
                            e.NextCtrl = tEdit_SectionCodeAllowZero;
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            //string msg = "���͂��ꂽ�R�[�h�̃L�����y�[���ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";    // DEL 2011/05/06
            string msg = "���͂��ꂽ�R�[�h�̃L�����y�[�����̐ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";  // ADD 2011/05/06

            // �L�����y�[���R�[�h
            int campaignCode = CampaignCode_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsCampaignCode = (int)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CAMPAIGN_CODE];
                if (campaignCode == dsCampaignCode)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                            //"���͂��ꂽ�R�[�h�̃L�����y�[���ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W  // DEL 2011/05/06
                          "���͂��ꂽ�R�[�h�̃L�����y�[�����̐ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W  // ADD 2011/05/06
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // �L�����y�[���R�[�h�̃N���A
                        CampaignCode_tNedit.Clear();
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
                                // �L�����y�[���R�[�h�̃N���A
                                CampaignCode_tNedit.Clear();
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

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }

	}
}
