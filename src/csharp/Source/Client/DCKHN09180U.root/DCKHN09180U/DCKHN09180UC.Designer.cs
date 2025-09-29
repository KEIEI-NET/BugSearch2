namespace Broadleaf.Windows.Forms
{
	partial class DCKHN09180UC
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			this.Target_uLabel = new Infragistics.Win.Misc.UltraLabel();
			this.Replace_uButton = new Infragistics.Win.Misc.UltraButton();
			this.Cancel_uButton = new Infragistics.Win.Misc.UltraButton();
			this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
			this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
			this.timer_InitialSetFocus = new System.Windows.Forms.Timer(this.components);
			this.uStatusBar_Main = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.Target_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.ReplaceData_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.TargetData_uLabel = new Infragistics.Win.Misc.UltraLabel();
			this.ReplaceData_uLabel = new Infragistics.Win.Misc.UltraLabel();
			this.TargetData_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.TargetData_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.ReplaceData_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.TargetData_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
			this.ReplaceData_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
			((System.ComponentModel.ISupportInitialize)(this.Target_tComboEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ReplaceData_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TargetData_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TargetData_tComboEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ReplaceData_tComboEditor)).BeginInit();
			this.SuspendLayout();
			// 
			// Target_uLabel
			// 
			appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.Target_uLabel.Appearance = appearance1;
			this.Target_uLabel.Location = new System.Drawing.Point(12, 12);
			this.Target_uLabel.Name = "Target_uLabel";
			this.Target_uLabel.Size = new System.Drawing.Size(88, 24);
			this.Target_uLabel.TabIndex = 24;
			this.Target_uLabel.Text = "対象項目";
			// 
			// Replace_uButton
			// 
			this.Replace_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Replace_uButton.Location = new System.Drawing.Point(235, 148);
			this.Replace_uButton.Name = "Replace_uButton";
			this.Replace_uButton.Size = new System.Drawing.Size(125, 34);
			this.Replace_uButton.TabIndex = 3;
			this.Replace_uButton.Text = "置換(&R)";
			this.Replace_uButton.Click += new System.EventHandler(this.Replace_uButton_Click);
			// 
			// Cancel_uButton
			// 
			this.Cancel_uButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Cancel_uButton.Location = new System.Drawing.Point(366, 148);
			this.Cancel_uButton.Name = "Cancel_uButton";
			this.Cancel_uButton.Size = new System.Drawing.Size(125, 34);
			this.Cancel_uButton.TabIndex = 4;
			this.Cancel_uButton.Text = "閉じる(&X)";
			this.Cancel_uButton.Click += new System.EventHandler(this.Cancel_uButton_Click);
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
			// timer_InitialSetFocus
			// 
			this.timer_InitialSetFocus.Interval = 1;
			this.timer_InitialSetFocus.Tick += new System.EventHandler(this.timer_InitialSetFocus_Tick);
			// 
			// uStatusBar_Main
			// 
			this.uStatusBar_Main.Location = new System.Drawing.Point(0, 196);
			this.uStatusBar_Main.Name = "uStatusBar_Main";
			this.uStatusBar_Main.Size = new System.Drawing.Size(503, 23);
			this.uStatusBar_Main.TabIndex = 54;
			this.uStatusBar_Main.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
			// 
			// Target_tComboEditor
			// 
			appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.Target_tComboEditor.ActiveAppearance = appearance20;
			appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.Target_tComboEditor.Appearance = appearance21;
			this.Target_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.Target_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.Target_tComboEditor.ItemAppearance = appearance22;
			this.Target_tComboEditor.Location = new System.Drawing.Point(117, 12);
			this.Target_tComboEditor.Name = "Target_tComboEditor";
			this.Target_tComboEditor.Size = new System.Drawing.Size(191, 24);
			this.Target_tComboEditor.TabIndex = 0;
			this.Target_tComboEditor.SelectionChangeCommitted += new System.EventHandler(this.Target_tComboEditor_SelectionChangeCommitted);
			// 
			// ReplaceData_tNedit
			// 
			appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.ReplaceData_tNedit.ActiveAppearance = appearance18;
			appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance19.TextHAlign = Infragistics.Win.HAlign.Right;
			this.ReplaceData_tNedit.Appearance = appearance19;
			this.ReplaceData_tNedit.AutoSelect = true;
			this.ReplaceData_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
			this.ReplaceData_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.ReplaceData_tNedit.DataText = "99999";
			this.ReplaceData_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.ReplaceData_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
			this.ReplaceData_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.ReplaceData_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.ReplaceData_tNedit.Location = new System.Drawing.Point(117, 92);
			this.ReplaceData_tNedit.MaxLength = 16;
			this.ReplaceData_tNedit.Name = "ReplaceData_tNedit";
			this.ReplaceData_tNedit.NullText = "0.00";
			this.ReplaceData_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, true, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
			this.ReplaceData_tNedit.Size = new System.Drawing.Size(191, 24);
			this.ReplaceData_tNedit.TabIndex = 2;
			this.ReplaceData_tNedit.Text = "99999";
			// 
			// TargetData_uLabel
			// 
			appearance17.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.TargetData_uLabel.Appearance = appearance17;
			this.TargetData_uLabel.Location = new System.Drawing.Point(12, 52);
			this.TargetData_uLabel.Name = "TargetData_uLabel";
			this.TargetData_uLabel.Size = new System.Drawing.Size(88, 24);
			this.TargetData_uLabel.TabIndex = 58;
			this.TargetData_uLabel.Text = "対象の値";
			// 
			// ReplaceData_uLabel
			// 
			appearance16.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ReplaceData_uLabel.Appearance = appearance16;
			this.ReplaceData_uLabel.Location = new System.Drawing.Point(12, 92);
			this.ReplaceData_uLabel.Name = "ReplaceData_uLabel";
			this.ReplaceData_uLabel.Size = new System.Drawing.Size(88, 24);
			this.ReplaceData_uLabel.TabIndex = 59;
			this.ReplaceData_uLabel.Text = "置換後の値";
			// 
			// TargetData_tNedit
			// 
			appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.TargetData_tNedit.ActiveAppearance = appearance14;
			appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance15.TextHAlign = Infragistics.Win.HAlign.Right;
			this.TargetData_tNedit.Appearance = appearance15;
			this.TargetData_tNedit.AutoSelect = true;
			this.TargetData_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
			this.TargetData_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.TargetData_tNedit.DataText = "11111";
			this.TargetData_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.TargetData_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
			this.TargetData_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.TargetData_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.TargetData_tNedit.Location = new System.Drawing.Point(117, 52);
			this.TargetData_tNedit.MaxLength = 16;
			this.TargetData_tNedit.Name = "TargetData_tNedit";
			this.TargetData_tNedit.NullText = "0.00";
			this.TargetData_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, true, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
			this.TargetData_tNedit.Size = new System.Drawing.Size(191, 24);
			this.TargetData_tNedit.TabIndex = 1;
			this.TargetData_tNedit.Text = "11111";
			// 
			// TargetData_tComboEditor
			// 
			appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.TargetData_tComboEditor.ActiveAppearance = appearance11;
			appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.TargetData_tComboEditor.Appearance = appearance12;
			this.TargetData_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.TargetData_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.TargetData_tComboEditor.ItemAppearance = appearance13;
			this.TargetData_tComboEditor.Location = new System.Drawing.Point(117, 52);
			this.TargetData_tComboEditor.Name = "TargetData_tComboEditor";
			this.TargetData_tComboEditor.Size = new System.Drawing.Size(191, 24);
			this.TargetData_tComboEditor.TabIndex = 1;
			// 
			// ReplaceData_tComboEditor
			// 
			appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.ReplaceData_tComboEditor.ActiveAppearance = appearance8;
			appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.ReplaceData_tComboEditor.Appearance = appearance9;
			this.ReplaceData_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.ReplaceData_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.ReplaceData_tComboEditor.ItemAppearance = appearance10;
			this.ReplaceData_tComboEditor.Location = new System.Drawing.Point(117, 92);
			this.ReplaceData_tComboEditor.Name = "ReplaceData_tComboEditor";
			this.ReplaceData_tComboEditor.Size = new System.Drawing.Size(191, 24);
			this.ReplaceData_tComboEditor.TabIndex = 2;
			// 
			// TargetData_tDateEdit
			// 
			appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.TargetData_tDateEdit.ActiveEditAppearance = appearance5;
			this.TargetData_tDateEdit.BackColor = System.Drawing.Color.Transparent;
			this.TargetData_tDateEdit.CalendarDisp = true;
			appearance6.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance6.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.TargetData_tDateEdit.EditAppearance = appearance6;
			this.TargetData_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
			this.TargetData_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.TargetData_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			appearance7.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance7.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.TargetData_tDateEdit.LabelAppearance = appearance7;
			this.TargetData_tDateEdit.Location = new System.Drawing.Point(117, 52);
			this.TargetData_tDateEdit.Name = "TargetData_tDateEdit";
			this.TargetData_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
			this.TargetData_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
			this.TargetData_tDateEdit.Size = new System.Drawing.Size(172, 24);
			this.TargetData_tDateEdit.TabIndex = 1;
			this.TargetData_tDateEdit.TabStop = true;
			// 
			// ReplaceData_tDateEdit
			// 
			appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.ReplaceData_tDateEdit.ActiveEditAppearance = appearance2;
			this.ReplaceData_tDateEdit.BackColor = System.Drawing.Color.Transparent;
			this.ReplaceData_tDateEdit.CalendarDisp = true;
			appearance3.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance3.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ReplaceData_tDateEdit.EditAppearance = appearance3;
			this.ReplaceData_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
			this.ReplaceData_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.ReplaceData_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			appearance4.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance4.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.ReplaceData_tDateEdit.LabelAppearance = appearance4;
			this.ReplaceData_tDateEdit.Location = new System.Drawing.Point(117, 92);
			this.ReplaceData_tDateEdit.Name = "ReplaceData_tDateEdit";
			this.ReplaceData_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
			this.ReplaceData_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
			this.ReplaceData_tDateEdit.Size = new System.Drawing.Size(172, 24);
			this.ReplaceData_tDateEdit.TabIndex = 2;
			this.ReplaceData_tDateEdit.TabStop = true;
			// 
			// DCKHN09180UC
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
			this.CancelButton = this.Cancel_uButton;
			this.ClientSize = new System.Drawing.Size(503, 219);
			this.Controls.Add(this.ReplaceData_tDateEdit);
			this.Controls.Add(this.TargetData_tDateEdit);
			this.Controls.Add(this.ReplaceData_tComboEditor);
			this.Controls.Add(this.TargetData_tComboEditor);
			this.Controls.Add(this.TargetData_tNedit);
			this.Controls.Add(this.ReplaceData_uLabel);
			this.Controls.Add(this.TargetData_uLabel);
			this.Controls.Add(this.ReplaceData_tNedit);
			this.Controls.Add(this.Target_tComboEditor);
			this.Controls.Add(this.uStatusBar_Main);
			this.Controls.Add(this.Cancel_uButton);
			this.Controls.Add(this.Replace_uButton);
			this.Controls.Add(this.Target_uLabel);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DCKHN09180UC";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "掛率一括変換";
			this.Load += new System.EventHandler(this.DCKHN09180UC_Load);
			((System.ComponentModel.ISupportInitialize)(this.Target_tComboEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ReplaceData_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TargetData_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TargetData_tComboEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ReplaceData_tComboEditor)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Infragistics.Win.Misc.UltraLabel Target_uLabel;
		private Infragistics.Win.Misc.UltraButton Replace_uButton;
		private Infragistics.Win.Misc.UltraButton Cancel_uButton;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private System.Windows.Forms.Timer timer_InitialSetFocus;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar uStatusBar_Main;
		private System.Windows.Forms.ToolTip toolTip1;
		private Broadleaf.Library.Windows.Forms.TNedit ReplaceData_tNedit;
		private Broadleaf.Library.Windows.Forms.TComboEditor Target_tComboEditor;
		private Infragistics.Win.Misc.UltraLabel TargetData_uLabel;
		private Infragistics.Win.Misc.UltraLabel ReplaceData_uLabel;
		private Broadleaf.Library.Windows.Forms.TNedit TargetData_tNedit;
		private Broadleaf.Library.Windows.Forms.TComboEditor ReplaceData_tComboEditor;
		private Broadleaf.Library.Windows.Forms.TComboEditor TargetData_tComboEditor;
		private Broadleaf.Library.Windows.Forms.TDateEdit ReplaceData_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TDateEdit TargetData_tDateEdit;


	}
}