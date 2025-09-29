using Infragistics.Win;
using Infragistics.Win.Misc;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms.Design
{
	internal class TExtEditEditorForm : Form
	{
		private Label label1;
		private GroupBox gbCurPos;
		private CheckBox cbWord;
		private CheckBox cbSpace;
		private CheckBox cbSign;
		private CheckBox cbKana;
		private CheckBox cbAlpha;
		private CheckBox cbNumSign;
		private CheckBox cbNum;
		private RadioButton rbPrev;
		private RadioButton rbLeft;
		private RadioButton rbRight;
		private CheckBox cbFreeCursor;
		private CheckBox cbAutoWidth;
		private TextBox tbColumn;
		private GroupBox gbChar;
		private UltraButton btnCancel;
		private UltraButton btnOK;
        private Container components = null;
		public TExtEditEditorForm()
		{
			this.InitializeComponent();
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TExtEditEditorForm));
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			this.gbCurPos = new GroupBox();
			this.rbRight = new RadioButton();
			this.rbLeft = new RadioButton();
			this.rbPrev = new RadioButton();
			this.gbChar = new GroupBox();
			this.cbNum = new CheckBox();
			this.cbNumSign = new CheckBox();
			this.cbAlpha = new CheckBox();
			this.cbKana = new CheckBox();
			this.cbSign = new CheckBox();
			this.cbSpace = new CheckBox();
			this.cbWord = new CheckBox();
			this.label1 = new Label();
			this.cbFreeCursor = new CheckBox();
			this.cbAutoWidth = new CheckBox();
			this.tbColumn = new TextBox();
			this.btnCancel = new UltraButton();
			this.btnOK = new UltraButton();
			this.gbCurPos.SuspendLayout();
			this.gbChar.SuspendLayout();
			base.SuspendLayout();
			this.gbCurPos.Controls.Add(this.rbRight);
			this.gbCurPos.Controls.Add(this.rbLeft);
			this.gbCurPos.Controls.Add(this.rbPrev);
			this.gbCurPos.Location = new Point(12, 12);
			this.gbCurPos.Name = "gbCurPos";
			this.gbCurPos.Size = new Size(128, 108);
			this.gbCurPos.TabIndex = 0;
			this.gbCurPos.TabStop = false;
			this.gbCurPos.Text = "カーソル位置(&P)";
			this.rbRight.Location = new Point(12, 76);
			this.rbRight.Name = "rbRight";
			this.rbRight.Size = new Size(104, 24);
			this.rbRight.TabIndex = 2;
			this.rbRight.Text = "末尾";
			this.rbLeft.Location = new Point(12, 48);
			this.rbLeft.Name = "rbLeft";
			this.rbLeft.Size = new Size(104, 24);
			this.rbLeft.TabIndex = 1;
			this.rbLeft.Text = "先頭";
			this.rbPrev.Location = new Point(12, 20);
			this.rbPrev.Name = "rbPrev";
			this.rbPrev.Size = new Size(104, 24);
			this.rbPrev.TabIndex = 0;
			this.rbPrev.Text = "前回位置";
			this.gbChar.Controls.Add(this.cbNum);
			this.gbChar.Controls.Add(this.cbNumSign);
			this.gbChar.Controls.Add(this.cbAlpha);
			this.gbChar.Controls.Add(this.cbKana);
			this.gbChar.Controls.Add(this.cbSign);
			this.gbChar.Controls.Add(this.cbSpace);
			this.gbChar.Controls.Add(this.cbWord);
			this.gbChar.Location = new Point(148, 12);
			this.gbChar.Name = "gbChar";
			this.gbChar.Size = new Size(128, 192);
			this.gbChar.TabIndex = 1;
			this.gbChar.TabStop = false;
			this.gbChar.Text = "入力字種(&I)";
			this.cbNum.Location = new Point(12, 164);
			this.cbNum.Name = "cbNum";
			this.cbNum.Size = new Size(104, 24);
			this.cbNum.TabIndex = 6;
			this.cbNum.Text = "数字";
			this.cbNumSign.Location = new Point(12, 140);
			this.cbNumSign.Name = "cbNumSign";
			this.cbNumSign.Size = new Size(104, 24);
			this.cbNumSign.TabIndex = 5;
			this.cbNumSign.Text = "数字記号";
			this.cbAlpha.Location = new Point(12, 116);
			this.cbAlpha.Name = "cbAlpha";
			this.cbAlpha.Size = new Size(104, 24);
			this.cbAlpha.TabIndex = 4;
			this.cbAlpha.Text = "英字";
			this.cbKana.Location = new Point(12, 92);
			this.cbKana.Name = "cbKana";
			this.cbKana.Size = new Size(104, 24);
			this.cbKana.TabIndex = 3;
			this.cbKana.Text = "カナ";
			this.cbSign.Location = new Point(12, 68);
			this.cbSign.Name = "cbSign";
			this.cbSign.Size = new Size(104, 24);
			this.cbSign.TabIndex = 2;
			this.cbSign.Text = "記号";
			this.cbSpace.Location = new Point(12, 44);
			this.cbSpace.Name = "cbSpace";
			this.cbSpace.Size = new Size(104, 24);
			this.cbSpace.TabIndex = 1;
			this.cbSpace.Text = "スペース";
			this.cbWord.Location = new Point(12, 20);
			this.cbWord.Name = "cbWord";
			this.cbWord.Size = new Size(104, 24);
			this.cbWord.TabIndex = 0;
			this.cbWord.Text = "全角";
			this.label1.Location = new Point(284, 12);
			this.label1.Name = "label1";
			this.label1.Size = new Size(68, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "桁数(&L)";
			this.cbFreeCursor.Location = new Point(284, 36);
			this.cbFreeCursor.Name = "cbFreeCursor";
			this.cbFreeCursor.Size = new Size(148, 24);
			this.cbFreeCursor.TabIndex = 4;
			this.cbFreeCursor.Text = "フリーカーソルモード(&F)";
			this.cbAutoWidth.Location = new Point(284, 64);
			this.cbAutoWidth.Name = "cbAutoWidth";
			this.cbAutoWidth.Size = new Size(148, 24);
			this.cbAutoWidth.TabIndex = 5;
			this.cbAutoWidth.Text = "自動フィールド幅(&A)";
			this.tbColumn.Location = new Point(360, 8);
			this.tbColumn.Name = "tbColumn";
			this.tbColumn.Size = new Size(52, 19);
			this.tbColumn.TabIndex = 3;
			this.tbColumn.TextAlign = HorizontalAlignment.Right;
			this.tbColumn.KeyPress += new KeyPressEventHandler(this.tbColumn_KeyPress);
			appearance.Image = componentResourceManager.GetObject("appearance1.Image");
			this.btnCancel.Appearance = appearance;
			this.btnCancel.DialogResult = DialogResult.Cancel;
			this.btnCancel.ImageSize = new Size(24, 24);
			this.btnCancel.ImageTransparentColor = Color.White;
			this.btnCancel.Location = new Point(344, 160);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new Size(92, 36);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			appearance2.Image = componentResourceManager.GetObject("appearance2.Image");
			this.btnOK.Appearance = appearance2;
			this.btnOK.DialogResult = DialogResult.OK;
			this.btnOK.ImageSize = new Size(24, 24);
			this.btnOK.ImageTransparentColor = Color.White;
			this.btnOK.Location = new Point(344, 112);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new Size(92, 36);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "OK";
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new Size(5, 12);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new Size(450, 212);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.tbColumn);
			base.Controls.Add(this.cbAutoWidth);
			base.Controls.Add(this.cbFreeCursor);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.gbChar);
			base.Controls.Add(this.gbCurPos);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.KeyPreview = true;
			base.Name = "TExtEditEditorForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "拡張編集プロパティ設定";
			base.KeyDown += new KeyEventHandler(this.TExtEditEditorForm_KeyDown);
			this.gbCurPos.ResumeLayout(false);
			this.gbChar.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public void SetValue(TExtEdit value)
		{
			this.tbColumn.Text = value.Column.ToString();
			this.cbFreeCursor.Checked = value.FreeCursor;
			this.cbAutoWidth.Checked = value.AutoWidth;
			switch (value.CursorPos)
			{
			case emCursorPosition.Prev:
				this.rbPrev.Checked = true;
				break;
			case emCursorPosition.Top:
				this.rbLeft.Checked = true;
				break;
			case emCursorPosition.End:
				this.rbRight.Checked = true;
				break;
			}
			this.cbWord.Checked = value.EnableChars.Word;
			this.cbAlpha.Checked = value.EnableChars.Alpha;
			this.cbKana.Checked = value.EnableChars.Kana;
			this.cbNum.Checked = value.EnableChars.Num;
			this.cbNumSign.Checked = value.EnableChars.NumSign;
			this.cbSpace.Checked = value.EnableChars.Space;
			this.cbSign.Checked = value.EnableChars.Sign;
		}
		public TExtEdit GetValue()
		{
			emCursorPosition cpos;
			if (this.rbPrev.Checked)
			{
				cpos = emCursorPosition.Prev;
			}
			else
			{
				if (this.rbLeft.Checked)
				{
					cpos = emCursorPosition.Top;
				}
				else
				{
					if (this.rbRight.Checked)
					{
						cpos = emCursorPosition.End;
					}
					else
					{
						cpos = emCursorPosition.Prev;
					}
				}
			}
			return new TExtEdit(cpos, this.cbFreeCursor.Checked, this.cbAutoWidth.Checked, int.Parse(this.tbColumn.Text.TrimStart(new char[0])), new TEnableChars(this.cbWord.Checked, this.cbSpace.Checked, this.cbSign.Checked, this.cbKana.Checked, this.cbAlpha.Checked, this.cbNumSign.Checked, this.cbNum.Checked));
		}
		private void tbColumn_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = (!TLib.IsCtrl(e.KeyChar) && !TLib.IsNum(e.KeyChar));
		}
		private void TExtEditEditorForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}
	}
}
