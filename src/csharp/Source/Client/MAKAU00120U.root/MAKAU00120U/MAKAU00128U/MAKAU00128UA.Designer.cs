using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
	partial class MAKAU00128UA
	{
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// �g�p���̃��\�[�X�����ׂăN���[���A�b�v���܂��B
		/// </summary>
		/// <param name="disposing">�}�l�[�W ���\�[�X���j�������ꍇ true�A�j������Ȃ��ꍇ�� false �ł��B</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
                /*
                // �O���b�h�ݒ�ۑ�
				if (_colDispInfo != null)
				{
					

//					_colDispInfo.DispBothTaxway = this._bufDispBothTaxway;
					_colDispInfo.SerializeData(ctFILE_ColDispInfo);
					_colDispInfo = null;
				}
                 * */
/*
				// �d���Ǘ��A�N�Z�X�N���X�C�x���g�n���h���폜
				if (this._stockMngAcs != null)
				{
					this._stockMngAcs.RemoveInfoChangeStockMngEvent(this.InfoChangeStockMngEvent);
					this._stockMngAcs.RemoveInfoNewEntryStockMngEvent(this.InfoNewEntryStockMngEvent);
				}
*/
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h

		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���_�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKAU00128UA));
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraLabel42 = new Infragistics.Win.Misc.UltraLabel();
            this.tShape1 = new Broadleaf.Library.Windows.Forms.TShape();
            this.cmbGridFont = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tDateEdit_CAddUpUpdDate = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.tShape2 = new Broadleaf.Library.Windows.Forms.TShape();
            this.tEdit_SectionName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_TotalDay = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.tEdit_SectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_SectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.tDateEdit_LastCAddUpUpdDate = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tShape1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGridFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShape2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_TotalDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).BeginInit();
            this.SuspendLayout();
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraLabel42
            // 
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance51.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance51.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance51.FontData.BoldAsString = "True";
            appearance51.ForeColor = System.Drawing.Color.Black;
            appearance51.TextHAlignAsString = "Center";
            appearance51.TextVAlignAsString = "Middle";
            this.ultraLabel42.Appearance = appearance51;
            this.ultraLabel42.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraLabel42.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.ultraLabel42.Location = new System.Drawing.Point(76, 55);
            this.ultraLabel42.Name = "ultraLabel42";
            this.ultraLabel42.Size = new System.Drawing.Size(345, 24);
            this.ultraLabel42.TabIndex = 1019;
            this.ultraLabel42.Text = "��������X�V������������";
            // 
            // tShape1
            // 
            this.tShape1.BackColor = System.Drawing.Color.Transparent;
            this.tShape1.HatchBackColor = System.Drawing.Color.Empty;
            this.tShape1.HatchForeColor = System.Drawing.Color.Empty;
            this.tShape1.Location = new System.Drawing.Point(0, 0);
            this.tShape1.Name = "tShape1";
            this.tShape1.Size = new System.Drawing.Size(0, 0);
            this.tShape1.TabIndex = 1071;
            // 
            // cmbGridFont
            // 
            this.cmbGridFont.ActiveAppearance = appearance52;
            this.cmbGridFont.Location = new System.Drawing.Point(0, 0);
            this.cmbGridFont.Name = "cmbGridFont";
            this.cmbGridFont.Size = new System.Drawing.Size(144, 21);
            this.cmbGridFont.TabIndex = 0;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraLabel1
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance8;
            this.ultraLabel1.Location = new System.Drawing.Point(104, 163);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(107, 24);
            this.ultraLabel1.TabIndex = 1022;
            this.ultraLabel1.Text = "�����������";
            // 
            // tDateEdit_CAddUpUpdDate
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.tDateEdit_CAddUpUpdDate.ActiveEditAppearance = appearance3;
            this.tDateEdit_CAddUpUpdDate.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_CAddUpUpdDate.CalendarDisp = true;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.tDateEdit_CAddUpUpdDate.EditAppearance = appearance4;
            this.tDateEdit_CAddUpUpdDate.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_CAddUpUpdDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.tDateEdit_CAddUpUpdDate.LabelAppearance = appearance5;
            this.tDateEdit_CAddUpUpdDate.Location = new System.Drawing.Point(220, 163);
            this.tDateEdit_CAddUpUpdDate.Name = "tDateEdit_CAddUpUpdDate";
            this.tDateEdit_CAddUpUpdDate.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_CAddUpUpdDate.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
            this.tDateEdit_CAddUpUpdDate.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_CAddUpUpdDate.TabIndex = 4;
            this.tDateEdit_CAddUpUpdDate.TabStop = true;
            // 
            // tShape2
            // 
            this.tShape2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.tShape2.ForeColor = System.Drawing.Color.Blue;
            this.tShape2.HatchBackColor = System.Drawing.Color.Empty;
            this.tShape2.HatchForeColor = System.Drawing.Color.Empty;
            this.tShape2.Location = new System.Drawing.Point(76, 78);
            this.tShape2.Name = "tShape2";
            this.tShape2.ShapeStyle = Broadleaf.Library.Windows.Forms.emShapeStyle.ssRectangle;
            this.tShape2.Size = new System.Drawing.Size(809, 474);
            this.tShape2.TabIndex = 1072;
            this.tShape2.Text = "tShape2";
            // 
            // tEdit_SectionName
            // 
            this.tEdit_SectionName.ActiveAppearance = appearance1;
            appearance2.BackColor = System.Drawing.Color.Gainsboro;
            appearance2.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionName.Appearance = appearance2;
            this.tEdit_SectionName.AutoSelect = true;
            this.tEdit_SectionName.BackColor = System.Drawing.Color.Gainsboro;
            this.tEdit_SectionName.DataText = "";
            this.tEdit_SectionName.Enabled = false;
            this.tEdit_SectionName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SectionName.Location = new System.Drawing.Point(262, 95);
            this.tEdit_SectionName.MaxLength = 12;
            this.tEdit_SectionName.Name = "tEdit_SectionName";
            this.tEdit_SectionName.Size = new System.Drawing.Size(175, 24);
            this.tEdit_SectionName.TabIndex = 1;
            this.tEdit_SectionName.Visible = false;
            // 
            // ultraLabel4
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance10;
            this.ultraLabel4.Location = new System.Drawing.Point(261, 197);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(17, 24);
            this.ultraLabel4.TabIndex = 1099;
            this.ultraLabel4.Text = "��";
            // 
            // ultraLabel3
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance9;
            this.ultraLabel3.Location = new System.Drawing.Point(104, 197);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(87, 24);
            this.ultraLabel3.TabIndex = 1098;
            this.ultraLabel3.Text = "�Ώے���";
            // 
            // tNedit_TotalDay
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance78.ForeColor = System.Drawing.Color.Black;
            appearance78.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_TotalDay.ActiveAppearance = appearance78;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance79.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance79.TextHAlignAsString = "Right";
            this.tNedit_TotalDay.Appearance = appearance79;
            this.tNedit_TotalDay.AutoSelect = true;
            this.tNedit_TotalDay.AutoSize = false;
            this.tNedit_TotalDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_TotalDay.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_TotalDay.DataText = "";
            this.tNedit_TotalDay.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_TotalDay.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_TotalDay.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_TotalDay.Location = new System.Drawing.Point(220, 197);
            this.tNedit_TotalDay.MaxLength = 2;
            this.tNedit_TotalDay.Name = "tNedit_TotalDay";
            this.tNedit_TotalDay.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_TotalDay.Size = new System.Drawing.Size(35, 24);
            this.tNedit_TotalDay.TabIndex = 5;
            // 
            // ultraLabel2
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance6;
            this.ultraLabel2.Location = new System.Drawing.Point(104, 95);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(38, 24);
            this.ultraLabel2.TabIndex = 1097;
            this.ultraLabel2.Text = "���_";
            this.ultraLabel2.Visible = false;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // tEdit_SectionCode
            // 
            appearance76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance76.ForeColor = System.Drawing.Color.Black;
            appearance76.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCode.ActiveAppearance = appearance76;
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance77.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance77.ForeColorDisabled = System.Drawing.Color.Black;
            appearance77.ForegroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            this.tEdit_SectionCode.Appearance = appearance77;
            this.tEdit_SectionCode.AutoSelect = true;
            this.tEdit_SectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCode.DataText = "";
            this.tEdit_SectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SectionCode.Location = new System.Drawing.Point(220, 95);
            this.tEdit_SectionCode.MaxLength = 2;
            this.tEdit_SectionCode.Name = "tEdit_SectionCode";
            this.tEdit_SectionCode.Size = new System.Drawing.Size(35, 24);
            this.tEdit_SectionCode.TabIndex = 0;
            this.tEdit_SectionCode.Visible = false;
            // 
            // uButton_SectionGuide
            // 
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SectionGuide.Appearance = appearance12;
            this.uButton_SectionGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SectionGuide.Location = new System.Drawing.Point(443, 95);
            this.uButton_SectionGuide.Name = "uButton_SectionGuide";
            this.uButton_SectionGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SectionGuide.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "���_�K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.uButton_SectionGuide, ultraToolTipInfo1);
            this.uButton_SectionGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SectionGuide.Visible = false;
            this.uButton_SectionGuide.Click += new System.EventHandler(this.uButton_SectionGuide_Click);
            // 
            // ultraLabel5
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance7;
            this.ultraLabel5.Location = new System.Drawing.Point(104, 129);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(107, 24);
            this.ultraLabel5.TabIndex = 1102;
            this.ultraLabel5.Text = "�O���������";
            // 
            // tDateEdit_LastCAddUpUpdDate
            // 
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance53.ForeColor = System.Drawing.Color.Black;
            appearance53.ForeColorDisabled = System.Drawing.Color.Black;
            this.tDateEdit_LastCAddUpUpdDate.ActiveEditAppearance = appearance53;
            this.tDateEdit_LastCAddUpUpdDate.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_LastCAddUpUpdDate.CalendarDisp = true;
            appearance54.BackColor = System.Drawing.Color.Gainsboro;
            appearance54.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance54.ForeColor = System.Drawing.Color.Black;
            appearance54.ForeColorDisabled = System.Drawing.Color.Black;
            appearance54.TextHAlignAsString = "Left";
            appearance54.TextVAlignAsString = "Middle";
            this.tDateEdit_LastCAddUpUpdDate.EditAppearance = appearance54;
            this.tDateEdit_LastCAddUpUpdDate.Enabled = false;
            this.tDateEdit_LastCAddUpUpdDate.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_LastCAddUpUpdDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance55.TextHAlignAsString = "Left";
            appearance55.TextVAlignAsString = "Middle";
            this.tDateEdit_LastCAddUpUpdDate.LabelAppearance = appearance55;
            this.tDateEdit_LastCAddUpUpdDate.Location = new System.Drawing.Point(220, 129);
            this.tDateEdit_LastCAddUpUpdDate.Name = "tDateEdit_LastCAddUpUpdDate";
            this.tDateEdit_LastCAddUpUpdDate.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_LastCAddUpUpdDate.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
            this.tDateEdit_LastCAddUpUpdDate.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_LastCAddUpUpdDate.TabIndex = 3;
            this.tDateEdit_LastCAddUpUpdDate.TabStop = true;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // MAKAU00128UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(992, 734);
            this.Controls.Add(this.tDateEdit_LastCAddUpUpdDate);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.uButton_SectionGuide);
            this.Controls.Add(this.tEdit_SectionCode);
            this.Controls.Add(this.tEdit_SectionName);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.tNedit_TotalDay);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.tDateEdit_CAddUpUpdDate);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.tShape1);
            this.Controls.Add(this.ultraLabel42);
            this.Controls.Add(this.tShape2);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MAKAU00128UA";
            this.Text = "��������X�V";
            ((System.ComponentModel.ISupportInitialize)(this.tShape1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGridFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShape2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_TotalDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel42;
        private Broadleaf.Library.Windows.Forms.TShape tShape1;
        private Broadleaf.Library.Windows.Forms.TComboEditor cmbGridFont;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_CAddUpUpdDate;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Broadleaf.Library.Windows.Forms.TShape tShape2;
        public Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionName;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_TotalDay;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_LastCAddUpUpdDate;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraButton uButton_SectionGuide;
        public Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionCode;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
	}
}