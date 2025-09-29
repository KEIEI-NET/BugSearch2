using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���Ӑ挟���p���[�U�[�ݒ�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ挟���p�̃��[�U�[�ݒ�t�H�[���N���X�ł��B</br>
	/// <br>Programmer : 22018 ��ؐ��b</br>
	/// <br>Date       : 2006.08.24</br>
	/// <br>Update Note: </br>
	/// <br>2006.08.24 men �V�K�쐬</br>
	/// <br>2006.11.27 men �R���X�g���N�^�ɂ�XML�̃p�X���擾����悤�ɉ��ǁi�݌ɕ��i�Ή��j</br>
	/// </remarks>
	public class CustomerSearchSetUp : System.Windows.Forms.Form
	{
		# region Components
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.UltraWinTabControl.UltraTabControl UserSetup_TabControl;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
		private Broadleaf.Library.Windows.Forms.TLine tLine3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		internal Infragistics.Win.UltraWinEditors.UltraOptionSet StringSearchInitialType_UOptionSet;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        internal Infragistics.Win.UltraWinEditors.UltraOptionSet AutoSearch_uOptionSet;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Broadleaf.Library.Windows.Forms.TLine tLine2;
        internal Infragistics.Win.UltraWinEditors.UltraOptionSet MultiSelect_uOptionSet;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Broadleaf.Library.Windows.Forms.TLine tLine1;
		private System.ComponentModel.IContainer components;
		# endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// ���Ӑ挟���p���[�U�[�ݒ�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ挟���p���[�U�[�ݒ�N���X�̏����������s���܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2006.08.24</br>
		/// <br></br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2009/12/02 30517 �Ė� �x��</br>
        /// <br>             MANTIS:14678 ���������C�����I���̏����l�ݒ���\�Ƃ���</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// </remarks>
		public CustomerSearchSetUp()
		{
			InitializeComponent();

			// �ϐ�������
			this._imageList16 = IconResourceManagement.ImageList16;
			this._customerSearchConstructionAcs = new CustomerSearchConstructionAcs();

			this.StringSearchInitialType_UOptionSet.CheckedIndex = this._customerSearchConstructionAcs.StringSearchInitialType;

            // 2009/12/02 Add >>>
            this.AutoSearch_uOptionSet.CheckedIndex = this._customerSearchConstructionAcs.AutoSearch;
            this.MultiSelect_uOptionSet.CheckedIndex = this._customerSearchConstructionAcs.MultiSelect;
            // 2009/12/02 Add <<<
        }

		/// <summary>
		/// ���Ӑ挟���p���[�U�[�ݒ�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="xmlFileName">XML�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : ���Ӑ挟���p���[�U�[�ݒ�N���X�̏����������s���܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2006.11.27</br>
		/// <br></br>
		/// </remarks>
		public CustomerSearchSetUp(string xmlFileName)
		{
			InitializeComponent();

			// �ϐ�������
			this._imageList16 = IconResourceManagement.ImageList16;
			this._customerSearchConstructionAcs = new CustomerSearchConstructionAcs(xmlFileName);

			this.StringSearchInitialType_UOptionSet.CheckedIndex = this._customerSearchConstructionAcs.StringSearchInitialType;

            // 2009/12/02 Add >>>
            this.AutoSearch_uOptionSet.CheckedIndex = this._customerSearchConstructionAcs.AutoSearch;
            this.MultiSelect_uOptionSet.CheckedIndex = this._customerSearchConstructionAcs.MultiSelect;
            // 2009/12/02 Add <<<
		}
		# endregion

		// ===================================================================================== //
		// �j��
		// ===================================================================================== //
		# region Dispose
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

		// ===================================================================================== //
		// Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h
		// ===================================================================================== //
		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerSearchSetUp));
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.StringSearchInitialType_UOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.tLine3 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.UserSetup_TabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.AutoSearch_uOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.tLine1 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.MultiSelect_uOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.tLine2 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StringSearchInitialType_UOptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserSetup_TabControl)).BeginInit();
            this.UserSetup_TabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoSearch_uOptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiSelect_uOptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine2)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.tLine2);
            this.ultraTabPageControl2.Controls.Add(this.MultiSelect_uOptionSet);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel2);
            this.ultraTabPageControl2.Controls.Add(this.tLine1);
            this.ultraTabPageControl2.Controls.Add(this.AutoSearch_uOptionSet);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel1);
            this.ultraTabPageControl2.Controls.Add(this.StringSearchInitialType_UOptionSet);
            this.ultraTabPageControl2.Controls.Add(this.tLine3);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel3);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(1, 24);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(370, 266);
            // 
            // StringSearchInitialType_UOptionSet
            // 
            this.StringSearchInitialType_UOptionSet.BackColor = System.Drawing.Color.Transparent;
            this.StringSearchInitialType_UOptionSet.BackColorInternal = System.Drawing.Color.Transparent;
            this.StringSearchInitialType_UOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.StringSearchInitialType_UOptionSet.CheckedIndex = 0;
            appearance4.TextHAlignAsString = "Left";
            this.StringSearchInitialType_UOptionSet.ItemAppearance = appearance4;
            valueListItem5.DataValue = 0;
            valueListItem5.DisplayText = "�擪��v����";
            valueListItem6.DataValue = 1;
            valueListItem6.DisplayText = "�B������";
            this.StringSearchInitialType_UOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6});
            this.StringSearchInitialType_UOptionSet.ItemSpacingVertical = 5;
            this.StringSearchInitialType_UOptionSet.Location = new System.Drawing.Point(20, 32);
            this.StringSearchInitialType_UOptionSet.Name = "StringSearchInitialType_UOptionSet";
            this.StringSearchInitialType_UOptionSet.Size = new System.Drawing.Size(311, 43);
            this.StringSearchInitialType_UOptionSet.TabIndex = 0;
            this.StringSearchInitialType_UOptionSet.Text = "�擪��v����";
            // 
            // tLine3
            // 
            this.tLine3.BackColor = System.Drawing.Color.Transparent;
            this.tLine3.ForeColor = System.Drawing.Color.Silver;
            this.tLine3.Location = new System.Drawing.Point(177, 18);
            this.tLine3.Name = "tLine3";
            this.tLine3.Size = new System.Drawing.Size(179, 10);
            this.tLine3.TabIndex = 4;
            this.tLine3.Text = "tLine3";
            // 
            // ultraLabel3
            // 
            appearance5.ForeColor = System.Drawing.Color.Blue;
            this.ultraLabel3.Appearance = appearance5;
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel3.Location = new System.Drawing.Point(10, 10);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(160, 17);
            this.ultraLabel3.TabIndex = 2;
            this.ultraLabel3.Text = "�����񌟍����@�����l";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.Location = new System.Drawing.Point(292, 338);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(96, 26);
            this.Cancel_Button.TabIndex = 2;
            this.Cancel_Button.Text = "�L�����Z��";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            // 
            // Ok_Button
            // 
            this.Ok_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Ok_Button.Location = new System.Drawing.Point(188, 338);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(96, 26);
            this.Ok_Button.TabIndex = 1;
            this.Ok_Button.Text = "�n�j";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // UserSetup_TabControl
            // 
            this.UserSetup_TabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.UserSetup_TabControl.Controls.Add(this.ultraTabPageControl2);
            this.UserSetup_TabControl.Location = new System.Drawing.Point(10, 10);
            this.UserSetup_TabControl.Name = "UserSetup_TabControl";
            this.UserSetup_TabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.UserSetup_TabControl.Size = new System.Drawing.Size(374, 293);
            this.UserSetup_TabControl.TabIndex = 0;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.GhostWhite;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ultraTab1.Appearance = appearance3;
            ultraTab1.Key = "Extract";
            ultraTab1.TabPage = this.ultraTabPageControl2;
            ultraTab1.Text = "���o��������";
            this.UserSetup_TabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(370, 266);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // ultraLabel1
            // 
            appearance7.ForeColor = System.Drawing.Color.Blue;
            this.ultraLabel1.Appearance = appearance7;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Location = new System.Drawing.Point(10, 81);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(160, 17);
            this.ultraLabel1.TabIndex = 5;
            this.ultraLabel1.Text = "�������������l";
            // 
            // AutoSearch_uOptionSet
            // 
            this.AutoSearch_uOptionSet.BackColor = System.Drawing.Color.Transparent;
            this.AutoSearch_uOptionSet.BackColorInternal = System.Drawing.Color.Transparent;
            this.AutoSearch_uOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.AutoSearch_uOptionSet.CheckedIndex = 0;
            appearance6.TextHAlignAsString = "Left";
            this.AutoSearch_uOptionSet.ItemAppearance = appearance6;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "�L��";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "����";
            this.AutoSearch_uOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.AutoSearch_uOptionSet.ItemSpacingVertical = 5;
            this.AutoSearch_uOptionSet.Location = new System.Drawing.Point(20, 104);
            this.AutoSearch_uOptionSet.Name = "AutoSearch_uOptionSet";
            this.AutoSearch_uOptionSet.Size = new System.Drawing.Size(311, 43);
            this.AutoSearch_uOptionSet.TabIndex = 6;
            this.AutoSearch_uOptionSet.Text = "�L��";
            // 
            // tLine1
            // 
            this.tLine1.BackColor = System.Drawing.Color.Transparent;
            this.tLine1.ForeColor = System.Drawing.Color.Silver;
            this.tLine1.Location = new System.Drawing.Point(177, 88);
            this.tLine1.Name = "tLine1";
            this.tLine1.Size = new System.Drawing.Size(179, 10);
            this.tLine1.TabIndex = 7;
            this.tLine1.Text = "tLine1";
            // 
            // ultraLabel2
            // 
            appearance2.ForeColor = System.Drawing.Color.Blue;
            this.ultraLabel2.Appearance = appearance2;
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.Location = new System.Drawing.Point(10, 153);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(160, 17);
            this.ultraLabel2.TabIndex = 8;
            this.ultraLabel2.Text = "�����I�������l";
            // 
            // MultiSelect_uOptionSet
            // 
            this.MultiSelect_uOptionSet.BackColor = System.Drawing.Color.Transparent;
            this.MultiSelect_uOptionSet.BackColorInternal = System.Drawing.Color.Transparent;
            this.MultiSelect_uOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.MultiSelect_uOptionSet.CheckedIndex = 0;
            appearance1.TextHAlignAsString = "Left";
            this.MultiSelect_uOptionSet.ItemAppearance = appearance1;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "�L��";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "����";
            this.MultiSelect_uOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.MultiSelect_uOptionSet.ItemSpacingVertical = 5;
            this.MultiSelect_uOptionSet.Location = new System.Drawing.Point(20, 176);
            this.MultiSelect_uOptionSet.Name = "MultiSelect_uOptionSet";
            this.MultiSelect_uOptionSet.Size = new System.Drawing.Size(311, 43);
            this.MultiSelect_uOptionSet.TabIndex = 9;
            this.MultiSelect_uOptionSet.Text = "�L��";
            // 
            // tLine2
            // 
            this.tLine2.BackColor = System.Drawing.Color.Transparent;
            this.tLine2.ForeColor = System.Drawing.Color.Silver;
            this.tLine2.Location = new System.Drawing.Point(177, 160);
            this.tLine2.Name = "tLine2";
            this.tLine2.Size = new System.Drawing.Size(179, 10);
            this.tLine2.TabIndex = 10;
            this.tLine2.Text = "tLine2";
            // 
            // CustomerSearchSetUp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(394, 376);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.UserSetup_TabControl);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerSearchSetUp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "���[�U�[�ݒ�";
            this.Load += new System.EventHandler(this.InspectCertSetUp_Load);
            this.ultraTabPageControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StringSearchInitialType_UOptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserSetup_TabControl)).EndInit();
            this.UserSetup_TabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AutoSearch_uOptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiSelect_uOptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private ImageList _imageList16 = null;
		private CustomerSearchConstructionAcs _customerSearchConstructionAcs = null;
		# endregion
	
		// ===================================================================================== //
		// �e��R���|�[�l���g�C�x���g�����S
		// ===================================================================================== //
		# region Event Methods
		/// <summary>
		/// Form.Load �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer  : 22018 ��ؐ��b</br>
		/// <br>Date        : 2006.08.24</br>
		/// </remarks>
		private void InspectCertSetUp_Load(object sender, System.EventArgs e)
		{
			this.Ok_Button.ImageList = this._imageList16;
			this.Cancel_Button.ImageList = this._imageList16;

			this.Ok_Button.Appearance.Image = (int)Size16_Index.DECISION;
			this.Cancel_Button.Appearance.Image	= (int)Size16_Index.BEFORE;

			this.StringSearchInitialType_UOptionSet.CheckedIndex = this._customerSearchConstructionAcs.StringSearchInitialType;
		}

		/// <summary>
		/// Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 22018 ��ؐ��b</br>
		/// <br>Date        : 2006.08.24</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			this._customerSearchConstructionAcs.StringSearchInitialType = this.StringSearchInitialType_UOptionSet.CheckedIndex;

            // 2009/12/02 Add >>>
            this._customerSearchConstructionAcs.AutoSearch = this.AutoSearch_uOptionSet.CheckedIndex;
            this._customerSearchConstructionAcs.MultiSelect = this.MultiSelect_uOptionSet.CheckedIndex;
            // 2009/12/02 Add <<<
			
            this._customerSearchConstructionAcs.Serialize();
		}
		# endregion
	}
}
