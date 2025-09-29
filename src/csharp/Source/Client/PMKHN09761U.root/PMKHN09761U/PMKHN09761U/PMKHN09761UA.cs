# region ��using
using Infragistics.Win.Misc;
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using System.Text;
# endregion

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// �i�ԕϊ��}�X�^ �t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note		: �i�ԕϊ��̐ݒ���s���܂��B
	///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>
    /// <br>Programmer  : �i�N</br>
    /// <br>Date        : 2014/12/23</br>
    /// <br>UpdateNote  : Redmine#45436 No.93�̑Ή�</br>
    /// <br>            : �i�N</br>
    /// <br>            : 2015/4/27</br>
    /// </remarks>
    public class PMKHN09761UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region ��Private Members (Component)

        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private System.Windows.Forms.Timer Initial_Timer;
        private System.Data.DataSet Bind_DataSet;
        private Broadleaf.Library.Windows.Forms.TImeControl tImeControl1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private UltraLabel GoodsMakerCd_Label;
        private UltraLabel OldGoodsNo_Label;
        private TNedit tNedit_GoodsMakerCd;
        private TEdit tEdit_OldGoodsNo;
        private TEdit GoodsMakerName_tEdit;
        private UiSetControl uiSetControl1;
        private UltraButton GoodsMakerGuide_Button;
		private System.ComponentModel.IContainer components;
        private UltraLabel NewGoodsNo_Label;
        private TEdit tEdit_NewGoodsNo;

		# endregion

		# region ��Constructor
		/// <summary>
        /// �i�ԕϊ��}�X�^ �t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �i�ԕϊ��}�X�^ �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2014/12/23</br>
        /// </remarks>
        public PMKHN09761UA()
		{
			InitializeComponent();

			// �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ�
			this._canPrint = false;
			this._canClose = false;
			this._canNew = true;
			this._canDelete = true;
			this._canLogicalDeleteDataExtraction = true;
			this._canClose = true;		// �f�t�H���g:true�Œ�
            this._defaultAutoFillToColumn = true;
            this._canSpecificationSearch = false;

			//�@��ƃR�[�h�擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// �ϐ�������
			this._dataIndex = -1;
            this._goodsNoChangeAcs = new GoodsNoChangeAcs();
			 
			this._totalCount = 0;
            this._goodsNoChangeTable = new Hashtable();

			//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			this._indexBuf = -2;

            this._newGoodsNo = string.Empty;
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
				if (components != null) 
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
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���[�J�[���̃K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09761UA));
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tImeControl1 = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.GoodsMakerGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.GoodsMakerCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.OldGoodsNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_GoodsMakerCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_OldGoodsNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GoodsMakerName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.NewGoodsNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_NewGoodsNo = new Broadleaf.Library.Windows.Forms.TEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OldGoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_NewGoodsNo)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(305, 161);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 16;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 202);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(574, 23);
            this.ultraStatusBar1.TabIndex = 11;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Mode_Label
            // 
            appearance56.ForeColor = System.Drawing.Color.White;
            appearance56.TextHAlignAsString = "Center";
            appearance56.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance56;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(446, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 12;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(180, 161);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 15;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(305, 161);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 17;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(430, 161);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 18;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // tImeControl1
            // 
            this.tImeControl1.InControl = null;
            this.tImeControl1.OutControl = null;
            this.tImeControl1.OwnerForm = this;
            this.tImeControl1.PutLength = 30;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // GoodsMakerGuide_Button
            // 
            this.GoodsMakerGuide_Button.Location = new System.Drawing.Point(174, 108);
            this.GoodsMakerGuide_Button.Name = "GoodsMakerGuide_Button";
            this.GoodsMakerGuide_Button.Size = new System.Drawing.Size(26, 26);
            this.GoodsMakerGuide_Button.TabIndex = 7;
            ultraToolTipInfo1.ToolTipText = "���[�J�[���̃K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.GoodsMakerGuide_Button, ultraToolTipInfo1);
            this.GoodsMakerGuide_Button.Click += new System.EventHandler(this.GoodsMakerGuide_Button_Click);
            // 
            // GoodsMakerCd_Label
            // 
            this.GoodsMakerCd_Label.Location = new System.Drawing.Point(30, 110);
            this.GoodsMakerCd_Label.Name = "GoodsMakerCd_Label";
            this.GoodsMakerCd_Label.Size = new System.Drawing.Size(79, 23);
            this.GoodsMakerCd_Label.TabIndex = 4;
            this.GoodsMakerCd_Label.Text = "���[�J�[";
            // 
            // OldGoodsNo_Label
            // 
            this.OldGoodsNo_Label.Location = new System.Drawing.Point(30, 51);
            this.OldGoodsNo_Label.Name = "OldGoodsNo_Label";
            this.OldGoodsNo_Label.Size = new System.Drawing.Size(79, 23);
            this.OldGoodsNo_Label.TabIndex = 8;
            this.OldGoodsNo_Label.Text = "���i��";
            // 
            // tNedit_GoodsMakerCd
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_GoodsMakerCd.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_GoodsMakerCd.Appearance = appearance6;
            this.tNedit_GoodsMakerCd.AutoSelect = true;
            this.tNedit_GoodsMakerCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_GoodsMakerCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMakerCd.DataText = "";
            this.tNedit_GoodsMakerCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMakerCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMakerCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMakerCd.Location = new System.Drawing.Point(125, 109);
            this.tNedit_GoodsMakerCd.MaxLength = 4;
            this.tNedit_GoodsMakerCd.Name = "tNedit_GoodsMakerCd";
            this.tNedit_GoodsMakerCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_GoodsMakerCd.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsMakerCd.TabIndex = 6;
            // 
            // tEdit_OldGoodsNo
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_OldGoodsNo.ActiveAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_OldGoodsNo.Appearance = appearance14;
            this.tEdit_OldGoodsNo.AutoSelect = true;
            this.tEdit_OldGoodsNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_OldGoodsNo.DataText = "";
            this.tEdit_OldGoodsNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_OldGoodsNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_OldGoodsNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_OldGoodsNo.Location = new System.Drawing.Point(125, 49);
            this.tEdit_OldGoodsNo.MaxLength = 24;
            this.tEdit_OldGoodsNo.Name = "tEdit_OldGoodsNo";
            this.tEdit_OldGoodsNo.Size = new System.Drawing.Size(198, 24);
            this.tEdit_OldGoodsNo.TabIndex = 4;
            // 
            // GoodsMakerName_tEdit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsMakerName_tEdit.ActiveAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance8.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance8.Cursor = System.Windows.Forms.Cursors.Default;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.GoodsMakerName_tEdit.Appearance = appearance8;
            this.GoodsMakerName_tEdit.AutoSelect = true;
            this.GoodsMakerName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GoodsMakerName_tEdit.DataText = "������������������������������";
            this.GoodsMakerName_tEdit.Enabled = false;
            this.GoodsMakerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GoodsMakerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.GoodsMakerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GoodsMakerName_tEdit.Location = new System.Drawing.Point(206, 109);
            this.GoodsMakerName_tEdit.MaxLength = 30;
            this.GoodsMakerName_tEdit.Name = "GoodsMakerName_tEdit";
            this.GoodsMakerName_tEdit.Size = new System.Drawing.Size(252, 24);
            this.GoodsMakerName_tEdit.TabIndex = 24;
            this.GoodsMakerName_tEdit.Tag = "False";
            this.GoodsMakerName_tEdit.Text = "������������������������������";
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // NewGoodsNo_Label
            // 
            this.NewGoodsNo_Label.Location = new System.Drawing.Point(30, 81);
            this.NewGoodsNo_Label.Name = "NewGoodsNo_Label";
            this.NewGoodsNo_Label.Size = new System.Drawing.Size(79, 23);
            this.NewGoodsNo_Label.TabIndex = 26;
            this.NewGoodsNo_Label.Text = "�V�i��";
            // 
            // tEdit_NewGoodsNo
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_NewGoodsNo.ActiveAppearance = appearance44;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_NewGoodsNo.Appearance = appearance45;
            this.tEdit_NewGoodsNo.AutoSelect = true;
            this.tEdit_NewGoodsNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_NewGoodsNo.DataText = "";
            this.tEdit_NewGoodsNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_NewGoodsNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_NewGoodsNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_NewGoodsNo.Location = new System.Drawing.Point(125, 79);
            this.tEdit_NewGoodsNo.MaxLength = 24;
            this.tEdit_NewGoodsNo.Name = "tEdit_NewGoodsNo";
            this.tEdit_NewGoodsNo.Size = new System.Drawing.Size(198, 24);
            this.tEdit_NewGoodsNo.TabIndex = 5;
            // 
            // PMKHN09761UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(574, 225);
            this.Controls.Add(this.NewGoodsNo_Label);
            this.Controls.Add(this.tEdit_NewGoodsNo);
            this.Controls.Add(this.GoodsMakerGuide_Button);
            this.Controls.Add(this.GoodsMakerCd_Label);
            this.Controls.Add(this.OldGoodsNo_Label);
            this.Controls.Add(this.tNedit_GoodsMakerCd);
            this.Controls.Add(this.tEdit_OldGoodsNo);
            this.Controls.Add(this.GoodsMakerName_tEdit);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09761UA";
            this.Text = "�i�ԕϊ��}�X�^";
            this.Load += new System.EventHandler(this.PMKHN09761UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09761UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN09761UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OldGoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_NewGoodsNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region ��IMasterMaintenanceArrayType�����o�[

		# region ��Events
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
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

		/// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
		/// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		public bool CanSpecificationSearch
		{
			get
			{
				return this._canSpecificationSearch;
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
		# endregion

        //���[�J�[�R�[�h�ϐ�
        int prvGoodsMakerCd = 0;

		# region ��Public Methods
		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u������</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = MAKERU_TABLE;
		}

		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList goodsNoChangeList = null;

            // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
            status = this._goodsNoChangeAcs.SearchAll(this._enterpriseCode, out goodsNoChangeList);
 
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this._totalCount = goodsNoChangeList.Count;

                        if (goodsNoChangeList.Count > 0)
                        {
                            this._goodsNoChangeTable.Clear();
                            this.Bind_DataSet.Tables[MAKERU_TABLE].Clear();
                        }
                        int index = 0;
                        foreach (GoodsNoChange lgoodsgranre in goodsNoChangeList)
                        {
                            if (this._goodsNoChangeTable.ContainsKey(lgoodsgranre.FileHeaderGuid) == false)
                            {
                                GoodsNoChangeToDataSet(lgoodsgranre.Clone(), index);
                                ++index;
                            }
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "Search",							  // ��������
                            TMsgDisp.OPE_GET,					  // �I�y���[�V����
                            ERR_READ_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._goodsNoChangeAcs,				  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                        break;
                    }
            }

            totalCount = this._totalCount;
            
            return status;
		}

		/// <summary>
		/// �l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		public int SearchNext(int readCount)
		{
			// �l�N�X�g�f�[�^���������i�������j
			return 0;
		}

		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		public int Delete()
		{
			int status = 0;
            Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsNoChangeAcs.FILEHEADERGUID_TITLE];
            GoodsNoChange goodsNoChange = ((GoodsNoChange)this._goodsNoChangeTable[guid]).Clone();
            status = this._goodsNoChangeAcs.LogicalDelete(ref goodsNoChange);

            switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// �r������
                    ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._goodsNoChangeAcs);
					return status;
				}
                case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                {
                    //�폜�s��
                    TMsgDisp.Show(this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        ASSEMBLY_ID,
                        "���̃��R�[�h�͕i�ԕϊ��}�X�^�ō폜���ĉ�����",
                        status,
                        MessageBoxButtons.OK);
                    this.Hide();

                    return status;
                }
				case -2:
				{
					//���Ɛݒ�Ŏg�p��
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						ASSEMBLY_ID,
						"���̃��R�[�h�͎��Ɛݒ�Ŏg�p����Ă��邽�ߍ폜�ł��܂���",
						status,
						MessageBoxButtons.OK);
					this.Hide();

					return status;
				}

				default:
				{
					TMsgDisp.Show(
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							// �v���O��������
						"Delete",							// ��������
						TMsgDisp.OPE_HIDE,					// �I�y���[�V����
						ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
                        this._goodsNoChangeAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��

					return status;
				}
			}

			// �f�[�^�Z�b�g�W�J����
            GoodsNoChangeToDataSet(goodsNoChange.Clone(), this._dataIndex);
			return status;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		public int Print()
		{
			// ����p�A�Z���u�������[�h����i�������j
			return 0;
		}

		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

            #region ���O���b�h��ݒ�
            /******************
             *�@�폜��            
             *�A�_���폜�敪    
             *�B���i��
             *�C�V�i��
             *�D���i���[�J�[�R�[�h
             *�E���[�J�[����      
             ******************/

            appearanceTable.Add(GoodsNoChangeAcs.DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(GoodsNoChangeAcs.LOGICALDELETE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GoodsNoChangeAcs.OLDGOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));             // ���i�R�[�h
            appearanceTable.Add(GoodsNoChangeAcs.NEWGOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));             // ���i�R�[�h
            appearanceTable.Add(GoodsNoChangeAcs.GOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));       // ���i���[�J�[�R�[�h
            appearanceTable.Add(GoodsNoChangeAcs.MAKERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));           // ���[�J�[����
            appearanceTable.Add(GoodsNoChangeAcs.FILEHEADERGUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));     // �f�[�^�e�[�u���J��������           
            #endregion

			return appearanceTable;
		}
		# endregion

		# endregion

		#region ��Private Menbers
        private GoodsNoChangeAcs _goodsNoChangeAcs;
		private int _totalCount;
		private string _enterpriseCode;
        private Hashtable _goodsNoChangeTable;

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
        private GoodsNoChange _goodsNoChangeClone;

		//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _indexBuf;

        private string _newGoodsNo;
		# endregion

		# region ��Consts
        private const string MAKERU_TABLE = "LGOODSGANRE";

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";

		// Message�֘A��`
		private const string ASSEMBLY_ID	= "PMKHN09761U";
		private const string PG_NM			= "�i�ԕϊ��}�X�^";
		private const string ERR_READ_MSG	= "�ǂݍ��݂Ɏ��s���܂����B";
		private const string ERR_DPR_MSG	= "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
		private const string ERR_RDEL_MSG	= "�폜�Ɏ��s���܂����B";
		private const string ERR_UPDT_MSG	= "�o�^�Ɏ��s���܂����B";
		private const string ERR_RVV_MSG	= "�����Ɏ��s���܂����B";
		private const string ERR_800_MSG	= "���ɑ��[�����X�V����Ă��܂�";
		private const string ERR_801_MSG	= "���ɑ��[�����폜����Ă��܂�";
		private const string SDC_RDEL_MSG	= "�}�X�^����폜����Ă��܂�";

        #endregion

        #region enum
        /// <summary>
        /// ���̓G���[�`�F�b�N�X�e�[�^�X
        /// </summary>
        private enum InputChkStatus
        {
            // ������
            NotInput = -1,
            // ���݂��Ȃ�
            NotExist = -2,
            // ���̓~�X
            InputErr = -3,
            // ����
            Normal = 0,
            // �L�����Z��
            Cancel = 1
        }

        /// <summary>
        /// ��ʃf�[�^�ݒ�X�e�[�^�X
        /// </summary>
        private enum DispSetStatus
        {
            // �N���A
            Clear = 0,
            // �X�V
            Update = 1,
            // ���ɖ߂�
            Back = 2
        }
        #endregion enum

		# region ��Main
		/// <summary>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new PMKHN09761UA());
		}
		# endregion

		#region ��IMasterMaintenanceInputStart Members
		/// <summary>
		/// 
		/// </summary>
		/// <param name="paraTable"></param>
		/// <returns></returns>
		public DialogResult ShowDialog(Hashtable paraTable)
		{
			this.ShowDialog();
			return this.DialogResult;
		}
		#endregion

		# region ��Private Methods
		/// <summary>
        /// �i�ԕϊ��}�X�^ �I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
        /// <param name="goodsNoChange">�i�ԕϊ��}�X�^ �I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
        /// <br>Note       : �i�ԕϊ��}�X�^ �N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void GoodsNoChangeToDataSet(GoodsNoChange goodsNoChange, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[MAKERU_TABLE].NewRow();
				this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count - 1;
			}

            if (goodsNoChange.LogicalDeleteCode == 0)
			{
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsNoChangeAcs.DELETE_DATE] = "";
            }
			else
			{
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsNoChangeAcs.DELETE_DATE] = TDateTime.DateTimeToString("ggYY/MM/DD", goodsNoChange.UpdateDateTime);
            }

            #region �����i���[�J�[
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsNoChangeAcs.GOODSMAKERCD_TITLE] = goodsNoChange.GoodsMakerCd;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsNoChangeAcs.MAKERNAME_TITLE] = goodsNoChange.MakerName;
            #endregion

            #region �����i�R�[�h
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsNoChangeAcs.OLDGOODSNO_TITLE] = goodsNoChange.OldGoodsNo;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsNoChangeAcs.NEWGOODSNO_TITLE] = goodsNoChange.NewGoodsNo;
            #endregion
          
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsNoChangeAcs.FILEHEADERGUID_TITLE] = goodsNoChange.FileHeaderGuid;

            if (this._goodsNoChangeTable.ContainsKey(goodsNoChange.FileHeaderGuid))
            {
                this._goodsNoChangeTable.Remove(goodsNoChange.FileHeaderGuid);
            }
            this._goodsNoChangeTable.Add(goodsNoChange.FileHeaderGuid, goodsNoChange);

        }

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
            DataTable goodsNoChangeTable = new DataTable(MAKERU_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            goodsNoChangeTable.Columns.Add(GoodsNoChangeAcs.DELETE_DATE, typeof(string));

            // ���i�R�[�h
            goodsNoChangeTable.Columns.Add(GoodsNoChangeAcs.OLDGOODSNO_TITLE, typeof(string));
            goodsNoChangeTable.Columns.Add(GoodsNoChangeAcs.NEWGOODSNO_TITLE, typeof(string));
            // ���i���[�J�[
            goodsNoChangeTable.Columns.Add(GoodsNoChangeAcs.GOODSMAKERCD_TITLE, typeof(int));
            goodsNoChangeTable.Columns.Add(GoodsNoChangeAcs.MAKERNAME_TITLE, typeof(string));


            // GUID
            goodsNoChangeTable.Columns.Add(GoodsNoChangeAcs.FILEHEADERGUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(goodsNoChangeTable);
        }

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void ScreenInitialSetting()
		{
            Point point = new Point();
            point.X = this.Cancel_Button.Location.X;
            point.Y = this.Cancel_Button.Location.Y;

            point.X = point.X - this.Ok_Button.Size.Width;
            this.Ok_Button.Location     = point;
            this.Revive_Button.Location = point;

            point.X = point.X - this.Delete_Button.Size.Width;
            this.Delete_Button.Location = point;
        }

		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void ScreenClear()
		{
            this.tNedit_GoodsMakerCd.Clear();
            this.GoodsMakerName_tEdit.Clear();
            this.tEdit_OldGoodsNo.Clear();
            this.tEdit_NewGoodsNo.Clear();
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void ScreenReconstruction()
		{
			if (this.DataIndex < 0)
			{
				// �V�K���[�h
				this.Mode_Label.Text = INSERT_MODE;

                // �{�^���ݒ�
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                
                //_dataIndex�o�b�t�@�ێ�
				this._indexBuf = this._dataIndex;
                                       				
				// ��ʓ��͋����䏈��
				ScreenInputPermissionControl(true);

                this.tEdit_OldGoodsNo.Focus();

                GoodsNoChange goodsNoChange = new GoodsNoChange();
				//�N���[���쐬
                this._goodsNoChangeClone = goodsNoChange.Clone(); 
                DispToGoodsNoChange(ref this._goodsNoChangeClone);

            }
			else
			{
                Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsNoChangeAcs.FILEHEADERGUID_TITLE];
                GoodsNoChange goodsNoChange = (GoodsNoChange)this._goodsNoChangeTable[guid];

                if (goodsNoChange.LogicalDeleteCode == 0)
				{
					// �X�V���[�h
					this.Mode_Label.Text = UPDATE_MODE;

					// �{�^���ݒ�
					this.Ok_Button.Visible = true;
					this.Delete_Button.Visible = false;
					this.Revive_Button.Visible = false;

					// ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(false);
                    this.tEdit_NewGoodsNo.Focus();

					// ��ʓW�J����
                    MakerUMntToScreen(goodsNoChange);

					//�N���[���쐬
                    this._goodsNoChangeClone = goodsNoChange.Clone();
                    DispToGoodsNoChange(ref this._goodsNoChangeClone);
                    //_dataIndex�o�b�t�@�ێ�
					this._indexBuf = this._dataIndex;
                    

				}
				else
				{
					// �폜���[�h
					this.Mode_Label.Text = DELETE_MODE;

					// �{�^���ݒ�
					this.Ok_Button.Visible = false;
					this.Revive_Button.Visible = true;
                    this.Delete_Button.Visible = true;
					//_dataIndex�o�b�t�@�ێ�
					this._indexBuf = this._dataIndex;

					// ��ʓ��͋����䏈��
					ScreenInputPermissionControl(false);

					// ��ʓW�J����
                    MakerUMntToScreen(goodsNoChange);

					// �t�H�[�J�X�ݒ�
					this.Delete_Button.Focus();
				}

			}
		}

		/// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <param name="enabled">���͋��ݒ�l</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void ScreenInputPermissionControl(bool enabled)
        {
            this.tNedit_GoodsMakerCd.Enabled = enabled;
            this.tEdit_OldGoodsNo.Enabled = enabled;
            this.tEdit_NewGoodsNo.Enabled = enabled;
            this.GoodsMakerGuide_Button.Enabled = enabled;  // ���i���[�J�[�K�C�h�{�^��

            if (this.Mode_Label.Text == UPDATE_MODE)
            {
                this.tEdit_NewGoodsNo.Enabled = true;
            }
        }

		/// <summary>
        /// �i�ԕϊ��}�X�^ �N���X��ʓW�J����
		/// </summary>
        /// <param name="goodsNoChange">�i�ԕϊ��ݒ�}�X�^ �I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : �i�ԕϊ��}�X�^ �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void MakerUMntToScreen(GoodsNoChange goodsNoChange)
        {
            #region �����i���[�J�[
            if (goodsNoChange.GoodsMakerCd != 0)
            {
                this.tNedit_GoodsMakerCd.SetInt(goodsNoChange.GoodsMakerCd);
            }
            if (goodsNoChange.MakerName != string.Empty)
            {
                this.GoodsMakerName_tEdit.DataText = goodsNoChange.MakerName;
            }
            #endregion

            #region �����i�R�[�h
            if (goodsNoChange.OldGoodsNo != string.Empty)
            {
                this.tEdit_OldGoodsNo.DataText = goodsNoChange.OldGoodsNo;
            }
            if (goodsNoChange.NewGoodsNo != string.Empty)
            {
                this.tEdit_NewGoodsNo.DataText = goodsNoChange.NewGoodsNo;
                this._newGoodsNo = this.tEdit_NewGoodsNo.Text.Trim();
            }
            #endregion

        }

		/// <summary>
		/// Value�`�F�b�N�����iint�j
		/// </summary>
		/// <param name="sorce">tCombo��Value</param>
		/// <returns>�`�F�b�N��̒l</returns>
		/// <remarks>
		/// <br>Note       : tCombo�̒l��Class�ɓ���鎞��NULL�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
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
        /// ��ʏ��i�[����
        /// </summary>
        /// <param name="goodsNoChange">�i�ԕϊ��f�[�^�N���X</param>
        /// <remarks>
        /// Note       : ��ʏ��̃f�[�^�N���X�i�[�������s���܂�<br />
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void DispToGoodsNoChange(ref GoodsNoChange goodsNoChange)
        {
            if (goodsNoChange == null)
            {
                // �V�K�̏ꍇ
                goodsNoChange = new GoodsNoChange();
            }

            goodsNoChange.EnterpriseCode = this._enterpriseCode;

            goodsNoChange.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();   // ���i���[�J�[�R�[�h
            goodsNoChange.MakerName = this.GoodsMakerName_tEdit.DataText;     // ���[�J�[����
            goodsNoChange.OldGoodsNo = this.tEdit_OldGoodsNo.DataText;        // �����i�R�[�h
            goodsNoChange.NewGoodsNo = this.tEdit_NewGoodsNo.DataText;        // �V���i�R�[�h
        }


        /// <summary>
		/// ��ʓ��͏��s���`�F�b�N����
		/// </summary>
		/// <param name="control">�s���ΏۃR���g���[��</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <param name="loginID">���O�C��ID</param>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
 		private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
		{
			bool result = true;

            #region < ���[�J�[,�i�ԓ��̓`�F�b�N >

            if (this.Mode_Label.Text == INSERT_MODE || this.Mode_Label.Text == UPDATE_MODE)
            {
                string valNew = this.tEdit_NewGoodsNo.Text.Trim();
                if (!(valNew.Length == Encoding.Default.GetByteCount(valNew)))
                {
                    this.tEdit_NewGoodsNo.Text = string.Empty;
                }
                string valOld = this.tEdit_OldGoodsNo.Text.Trim();
                if (!(valOld.Length == Encoding.Default.GetByteCount(valOld)))
                {
                    this.tEdit_OldGoodsNo.Text = string.Empty;
                }
                if (this.tEdit_OldGoodsNo.DataText.Trim().Equals(string.Empty))
                {
                    message = "���i�Ԃ���͂��ĉ������B";
                    control = this.tEdit_OldGoodsNo;
                    result = false;
                }
                else if (this.tEdit_NewGoodsNo.DataText.Trim().Equals(string.Empty))
                {
                    message = "�V�i�Ԃ���͂��ĉ������B";
                    control = this.tEdit_NewGoodsNo;
                    result = false;
                }
                else if (this.tEdit_OldGoodsNo.DataText.Trim() == this.tEdit_NewGoodsNo.DataText.Trim())
                {
                    message = "�V���i�Ԃ��d�����Ă��܂��B";
                    control = this.tEdit_NewGoodsNo;
                    result = false;
                }
                else if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                {
                    message = "���[�J�[����͂��ĉ������B";
                    control = this.tNedit_GoodsMakerCd;
                    result = false;
                }
                else
                {
                    // ���[�J�[�f�[�^�N���X
                    MakerUMnt makerUMnt;
                    // ���i�f�[�^�N���X�C���X�^���X��
                    MakerAcs makerAcs = new MakerAcs();

                    #region < ���[�J�[���擾���� >
                    makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt());
                    #endregion
                    if (makerUMnt != null && makerUMnt.LogicalDeleteCode != 1)
                    {
                        this.GoodsMakerName_tEdit.DataText = makerUMnt.MakerName;
                    }
                    else
                    {
                        message = "���[�J�[���o�^����Ă��܂���B";
                        control = this.tNedit_GoodsMakerCd;
                        this.tNedit_GoodsMakerCd.SetInt(prvGoodsMakerCd);
                        result = false;
                    }
                }
            }
            #endregion

			return result;
		}

		/// <summary>
		/// �r������
		/// </summary>
		/// <param name="operation">�I�y���[�V����</param>
		/// <param name="erObject">�G���[�I�u�W�F�N�g</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
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
		# endregion

		#region ��Control Events
		/// <summary>
		/// Form.Load �C�x���g(PMKHN09761UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void PMKHN09761UA_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList25 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList     = imageList25;
			this.Cancel_Button.ImageList = imageList25;
			this.Revive_Button.ImageList = imageList25;
			this.Delete_Button.ImageList = imageList25;

            this.GoodsMakerGuide_Button.ImageList        = imageList16;
            // �����{�^���̃A�C�R���ݒ�
            this.Ok_Button.Appearance.Image     = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.GoodsMakerGuide_Button.Appearance.Image        = Size16_Index.STAR1;

			// ��ʏ����ݒ菈��
            ScreenInitialSetting();
		}

		/// <summary>
        /// Form.Closing �C�x���g(PMKHN09761UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void PMKHN09761UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._indexBuf = -2;

			// �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
        /// Control.VisibleChanged �C�x���g(DCKHN09090UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void PMKHN09761UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				this.Owner.Activate();
				return;
			}

			// �������g����\���ɂȂ����ꍇ�A
			// �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}

			Initial_Timer.Enabled = true;
			ScreenClear();
		}

		/// <summary>
		/// Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			if (SaveProc() == false)
			{
				return;
			}
			// �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				// �f�[�^�C���f�b�N�X������������
				this.DataIndex = -1;

				// ��ʃN���A����
                this.tNedit_GoodsMakerCd.Clear();
                this.GoodsMakerName_tEdit.Clear();
                this.tEdit_OldGoodsNo.Clear();
                this.tEdit_NewGoodsNo.Clear();

				// �V�K���[�h
				this.Mode_Label.Text = INSERT_MODE;

				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				ScreenInputPermissionControl(true);

				// �����l�ݒ�

				// �N���[�����ēx�擾����
                GoodsNoChange goodsNoChange = new GoodsNoChange();
				
				//�N���[���쐬
                this._goodsNoChangeClone = goodsNoChange.Clone(); 
                DispToGoodsNoChange(ref this._goodsNoChangeClone);

				// �t�H�[�J�X�ݒ�
                this.tEdit_OldGoodsNo.Focus();
                //SetKind_tComboEditor_ValueChanged(sender, e);
            }
			else
			{
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
			}
		}
		/// <summary>
        /// �i�ԕϊ��}�X�^ ���o�^����
		/// </summary>
		/// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
        /// <br>Note       : �i�ԕϊ��}�X�^ ���o�^���s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private bool SaveProc()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			Control control = null;
			string message = null;
			string loginID = "";

            GoodsNoChange goodsNoChange = null;


			if (this.DataIndex >= 0)
			{
                Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsNoChangeAcs.FILEHEADERGUID_TITLE];
                goodsNoChange = ((GoodsNoChange)this._goodsNoChangeTable[guid]).Clone();
			}

            if (!ScreenDataCheck(ref control, ref message, loginID))
            {
				TMsgDisp.Show( 
					this,								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
					ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
					message,							// �\�����郁�b�Z�[�W 
					0,									// �X�e�[�^�X�l
					MessageBoxButtons.OK);				// �\������{�^��

				control.Focus();
				return false;
            }

            #region �i�ԏd���`�F�N�E
            ArrayList goodsNoChangeList = null;
            status = this._goodsNoChangeAcs.SearchAll(this._enterpriseCode, out goodsNoChangeList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �i�ԕϊ��}�X�^��Dictionary�̍쐬
                Dictionary<string, GoodsNoChange> oldGoodsNoChangeDict = new Dictionary<string, GoodsNoChange>();
                foreach (GoodsNoChange work in goodsNoChangeList)
                {
                    string key = work.EnterpriseCode + "-" + work.OldGoodsNo.Trim() + "-" + work.GoodsMakerCd.ToString().PadLeft(4, '0');
                    if (!oldGoodsNoChangeDict.ContainsKey(key))
                    {
                        oldGoodsNoChangeDict.Add(key, work);
                    }
                }
                Dictionary<string, GoodsNoChange> newGoodsNoChangeDict = new Dictionary<string, GoodsNoChange>();
                foreach (GoodsNoChange work in goodsNoChangeList)
                {
                    string key = work.EnterpriseCode + "-" + work.NewGoodsNo.Trim() + "-" + work.GoodsMakerCd.ToString().PadLeft(4, '0');
                    if (!newGoodsNoChangeDict.ContainsKey(key))
                    {
                        newGoodsNoChangeDict.Add(key, work);
                    }
                }
                string key1 = this._enterpriseCode + "-" + this.tEdit_OldGoodsNo.DataText.Trim() + "-" + this.tNedit_GoodsMakerCd.DataText.Trim().PadLeft(4, '0');
                string key2 = this._enterpriseCode + "-" + this.tEdit_NewGoodsNo.DataText.Trim() + "-" + this.tNedit_GoodsMakerCd.DataText.Trim().PadLeft(4, '0');

                if (this.Mode_Label.Text == UPDATE_MODE)
                {
                    if (!_newGoodsNo.Equals(this.tEdit_NewGoodsNo.DataText.Trim()))
                    {
                        if (oldGoodsNoChangeDict.ContainsKey(key2) || newGoodsNoChangeDict.ContainsKey(key2))
                        {
                            message = "�V�i�Ԃ͊��ɕi�ԕϊ��}�X�^�ɓo�^����Ă��܂��B";
                            control = this.tEdit_NewGoodsNo;
                        }
                    }
                }

                if (this.Mode_Label.Text == INSERT_MODE)
                {
                    if (oldGoodsNoChangeDict.ContainsKey(key1) || newGoodsNoChangeDict.ContainsKey(key1))
                    {
                        message = "���i�Ԃ͊��ɕi�ԕϊ��}�X�^�ɓo�^����Ă��܂��B";
                        control = this.tEdit_OldGoodsNo;
                    }
                    else if (oldGoodsNoChangeDict.ContainsKey(key2) || newGoodsNoChangeDict.ContainsKey(key2))
                    {
                        message = "�V�i�Ԃ͊��ɕi�ԕϊ��}�X�^�ɓo�^����Ă��܂��B";
                        control = this.tEdit_NewGoodsNo;
                    }
                    else
                    { 
                    }
                }
                if (!string.IsNullOrEmpty(message))
                {
                    TMsgDisp.Show(
                                        this,								// �e�E�B���h�E�t�H�[��
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                                        ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                                        message,							// �\�����郁�b�Z�[�W 
                                        0,									// �X�e�[�^�X�l
                                        MessageBoxButtons.OK);				// �\������{�^��
                    control.Focus();
                    return false;
                }
            }
            #endregion

            this.DispToGoodsNoChange(ref goodsNoChange);

            status = this._goodsNoChangeAcs.Write(ref goodsNoChange);
            switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                        ERR_800_MSG,						// �\�����郁�b�Z�[�W
						status,								// �X�e�[�^�X�l
						MessageBoxButtons.OK);				// �\������{�^��

                    this.tEdit_NewGoodsNo.Focus();
                    this.tEdit_NewGoodsNo.SelectAll();
                    return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._goodsNoChangeAcs);

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
					TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							// �v���O��������
						"SaveProc",							// ��������
						TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
						ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
                        this._goodsNoChangeAcs,				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��
					
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
			}

			// DataSet�W�J����
            GoodsNoChangeToDataSet(goodsNoChange, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
			
			return true;
		}

		/// <summary>
		/// �[�����ߌ�e�L�X�g�擾��������
		/// </summary>
		/// <param name="fullText">���͍ς݃e�L�X�g</param>
		/// <param name="columnCount">���͉\����</param>
		/// <returns>�[�����߂����e�L�X�g</returns>
		/// <br>Note       : ��������[�����߂��܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        private static string GetZeroPaddedTextProc(string fullText, int columnCount)
		{
			if (fullText.Trim() != string.Empty)
			{
				// �[���l�ߏ���
				return fullText.PadLeft(columnCount, '0');
			}
			else
			{
				return string.Empty;
			}
		}
		
		/// <summary>
		/// �����񁨐��l�ϊ�
		/// </summary>
		/// <param name="str"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        static int GetIntFromString(string str, int defaultValue)
		{
			try
			{
				return Int32.Parse(str);
			}
			catch
			{
				return defaultValue;
			}
		}

		/// <summary>
		/// �[�����߃L�����Z����e�L�X�g�擾��������
		/// </summary>
		/// <param name="fullText">���͍ς݃e�L�X�g</param>
		/// <returns>�[�����߃L�����Z�������e�L�X�g</returns>
		/// <br>Note       : �����񂩂�[�����폜���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        private static string GetZeroPadCanceledTextProc(string fullText)
		{
			if (fullText.Trim() != string.Empty)
			{
				int cnt = 0;
				string wkStr = fullText;
				
				// �擪�̃[���l�߂��폜
				while (fullText.StartsWith("0"))
				{
					fullText = fullText.Substring(1, fullText.Length - 1);
					cnt++;
				}
				
				// �I�[���[���̏ꍇ�A���ʃR�[�h�Ƃ���
				if (wkStr.Length == cnt)
				{
					fullText = "0";
				}
				return fullText;
			}
			else
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if (this.Mode_Label.Text != DELETE_MODE) 
			{
				//�ۑ��m�F
                GoodsNoChange compareGoodsNoChange = new GoodsNoChange();
                compareGoodsNoChange = this._goodsNoChangeClone.Clone();  
				//���݂̉�ʏ����擾����
                DispToGoodsNoChange(ref compareGoodsNoChange);
                //�ŏ��Ɏ擾������ʏ��Ɣ�r
                if (!(this._goodsNoChangeClone.Equals(compareGoodsNoChange)))	
				{
					//��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
					DialogResult res = TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						"",									// �\�����郁�b�Z�[�W 
						0,									// �X�e�[�^�X�l
						MessageBoxButtons.YesNoCancel);		// �\������{�^��

					switch(res)
					{
						case DialogResult.Yes:
						{
							if (SaveProc() == false)
							{
								return;
							}

							if (UnDisplaying != null)
							{
								MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
								UnDisplaying(this, me);
							}

							break;
						}
						case DialogResult.No:
						{
							if (UnDisplaying != null)
							{
								MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
								UnDisplaying(this, me);
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
		}

		/// <summary>
		/// Control.Click �C�x���g(Delete_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			int status = 0;
			DialogResult result = TMsgDisp.Show( 
				this,													// �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_QUESTION,						// �G���[���x��
				ASSEMBLY_ID,											// �A�Z���u���h�c�܂��̓N���X�h�c
				"�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",	// �\�����郁�b�Z�[�W 
				0,														// �X�e�[�^�X�l
				MessageBoxButtons.OKCancel,								// �\������{�^��
				MessageBoxDefaultButton.Button2);						// �����\���{�^��


			if (result == DialogResult.OK)
			{
                Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsNoChangeAcs.FILEHEADERGUID_TITLE];
                GoodsNoChange goodsNoChange = ((GoodsNoChange)this._goodsNoChangeTable[guid]).Clone();
                
                status = this._goodsNoChangeAcs.Delete(goodsNoChange);

                switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this.DataIndex].Delete();
                        this._goodsNoChangeTable.Remove(goodsNoChange.FileHeaderGuid);

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._goodsNoChangeAcs);

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
						
						return;
					}
					default:
					{
						TMsgDisp.Show( 
							this,								  // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
							ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
							this.Text,							  // �v���O��������
							"Delete_Button_Click",				  // ��������
							TMsgDisp.OPE_DELETE,				  // �I�y���[�V����
							ERR_RDEL_MSG,						  // �\�����郁�b�Z�[�W 
							status,								  // �X�e�[�^�X�l
                            this._goodsNoChangeAcs,				  // �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK,				  // �\������{�^��
							MessageBoxDefaultButton.Button1);	  // �����\���{�^��
						
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
						
						return;
					}
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
			this._indexBuf = -2;

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
		/// <br>Note �@�@  : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsNoChangeAcs.FILEHEADERGUID_TITLE];
            GoodsNoChange goodsNoChange = ((GoodsNoChange)_goodsNoChangeTable[guid]).Clone();

            status = this._goodsNoChangeAcs.Revival(ref goodsNoChange);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._goodsNoChangeAcs);

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
					
					return;
				}
				default:
				{
					TMsgDisp.Show( 
						this,								  // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
						ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							  // �v���O��������
						"Revive_Button_Click",				  // ��������
						TMsgDisp.OPE_UPDATE,				  // �I�y���[�V����
						ERR_RVV_MSG,						  // �\�����郁�b�Z�[�W 
						status,								  // �X�e�[�^�X�l
                        this._goodsNoChangeAcs,				  // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				  // �\������{�^��
						MessageBoxDefaultButton.Button1);	  // �����\���{�^��

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
					
					return;
				}
			}

			// DataSet�W�J����
            GoodsNoChangeToDataSet(goodsNoChange, this.DataIndex);

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
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
            ScreenReconstruction();
		}

		/// <summary>
		/// TRetKeyControl.ChangeFocus �C�x���g �C�x���g(tRetKeyControl1)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : �t�H�[�J�X���J�ڂ���ۂɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            if (e.NextCtrl == this.tNedit_GoodsMakerCd)
            {
                prvGoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            }

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_GoodsMakerCd":
                    {
                        #region < �[�����̓`�F�b�N >
                        if (this.tNedit_GoodsMakerCd.GetInt() != 0)
                        {
                            if (prvGoodsMakerCd != tNedit_GoodsMakerCd.GetInt())
                            {
                                // ���[�J�[�f�[�^�N���X
                                MakerUMnt makerUMnt;
                                // ���i�f�[�^�N���X�C���X�^���X��
                                MakerAcs makerAcs = new MakerAcs();

                                #region < ���[�J�[���擾���� >
                                makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt());
                                #endregion

                                #region < ��ʕ\������ >

                                if (makerUMnt != null && makerUMnt.LogicalDeleteCode != 1)
                                {
                                    #region -- �擾�f�[�^�W�J --
                                    // ���[�J�[����ʕ\��
                                    this.GoodsMakerName_tEdit.DataText = makerUMnt.MakerName;
                                    if (!e.ShiftKey)
                                    {
                                        if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                                        {
                                            e.NextCtrl = this.Ok_Button;
                                        }
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region -- �擾���s --
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "���[�J�[���o�^����Ă��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                    this.tNedit_GoodsMakerCd.SetInt(prvGoodsMakerCd);
                                    e.NextCtrl.Select();
                                    e.NextCtrl = tNedit_GoodsMakerCd;
                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {
                                if (!e.ShiftKey)
                                {
                                    if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.tNedit_GoodsMakerCd.DataText = string.Empty;
                            this.GoodsMakerName_tEdit.DataText = string.Empty;
                        }
                        #endregion

                        break;
                    }

                case "tEdit_OldGoodsNo":
                    {
                        string val = this.tEdit_OldGoodsNo.Text.Trim();
                        if (!(val.Length == Encoding.Default.GetByteCount(val)))
                        {
                            this.tEdit_OldGoodsNo.Text = string.Empty;
                        }
                        break;
                    }

                case "tEdit_NewGoodsNo":
                    {
                        string val = this.tEdit_NewGoodsNo.Text.Trim();
                        if (!(val.Length == Encoding.Default.GetByteCount(val)))
                        {
                            this.tEdit_NewGoodsNo.Text = string.Empty;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �����^�C�v�擾����
        /// </summary>
        /// <param name="inputCode">���͂��ꂽ�R�[�h</param>
        /// <param name="searchCode">�����p�R�[�h�i*�������j</param>
        /// <returns>0:���S��v���� 1:�O����v���� 2:�����v���� 3:�B������</returns>
        /// <remarks>
        /// Note           : ����������@���擾���鏈�����s���܂��B<br />
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if ((firstString == "*") && (lastString == "*"))
                {
                    return 3;
                }
                else if (firstString == "*")
                {
                    return 2;
                }
                else if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                // *�����݂��Ȃ����ߊ��S��v����
                return 0;
            }
        }

        # endregion

		# region �K�C�h����
        /// <summary>
        /// Control.Click �C�x���g(GoodsMakerGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���i���[�J�[�K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void GoodsMakerGuide_Button_Click(object sender, EventArgs e)
        {
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt = new MakerUMnt();

            //���[�J�[�K�C�h�N��
            int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            if (status != 0) return;

            // �擾�f�[�^�\��
            this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
            this.GoodsMakerName_tEdit.DataText = makerUMnt.MakerName;

            // --- DEL �i�N 2015/04/27 Redmine#45436 No.93�̑Ή�----->>>>>
            //// ���i�f�[�^�Ƃ̐���������邽�ߏ��i���̃N���A
            //this.tEdit_OldGoodsNo.Clear();
            // --- DEL �i�N 2015/04/27 Redmine#45436 No.93�̑Ή�-----<<<<<
        }
        # endregion
    }
}
