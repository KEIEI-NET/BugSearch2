using Infragistics.Win;
using Infragistics.Win.Misc;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms.Design
{
	internal class TNumEditEditorForm : Form
	{
		private GroupBox gbComma;
		private GroupBox gbZeroDisp;
		private CheckBox cbCalcInp;
		private CheckBox cbMinusSupp;
		private GroupBox gbZeroSupp;
		private Label lbDecLen;
		private TextBox tbDecLen;
		private RadioButton rbCommaOff;
		private RadioButton rbCommaOn;
		private RadioButton rbZeroDispOff;
		private RadioButton rbZeroDispOn;
		private RadioButton rbZeroSuppOff;
		private RadioButton rbZeroSuppOn;
		private RadioButton rbZeroSuppFill;
		private UltraButton btnCancel;
		private UltraButton btnOK;
        private Container components = null;
		public TNumEditEditorForm()
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TNumEditEditorForm));
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			this.gbComma = new GroupBox();
			this.rbCommaOn = new RadioButton();
			this.rbCommaOff = new RadioButton();
			this.gbZeroDisp = new GroupBox();
			this.rbZeroDispOn = new RadioButton();
			this.rbZeroDispOff = new RadioButton();
			this.cbCalcInp = new CheckBox();
			this.cbMinusSupp = new CheckBox();
			this.gbZeroSupp = new GroupBox();
			this.rbZeroSuppFill = new RadioButton();
			this.rbZeroSuppOn = new RadioButton();
			this.rbZeroSuppOff = new RadioButton();
			this.lbDecLen = new Label();
			this.tbDecLen = new TextBox();
			this.btnCancel = new UltraButton();
			this.btnOK = new UltraButton();
			this.gbComma.SuspendLayout();
			this.gbZeroDisp.SuspendLayout();
			this.gbZeroSupp.SuspendLayout();
			base.SuspendLayout();
			this.gbComma.Controls.Add(this.rbCommaOn);
			this.gbComma.Controls.Add(this.rbCommaOff);
			this.gbComma.Location = new Point(12, 12);
			this.gbComma.Name = "gbComma";
			this.gbComma.Size = new Size(124, 68);
			this.gbComma.TabIndex = 0;
			this.gbComma.TabStop = false;
			this.gbComma.Text = "カンマ編集(&K)";
			this.rbCommaOn.Location = new Point(8, 40);
			this.rbCommaOn.Name = "rbCommaOn";
			this.rbCommaOn.Size = new Size(104, 24);
			this.rbCommaOn.TabIndex = 1;
			this.rbCommaOn.Text = "する";
			this.rbCommaOff.Location = new Point(8, 16);
			this.rbCommaOff.Name = "rbCommaOff";
			this.rbCommaOff.Size = new Size(104, 24);
			this.rbCommaOff.TabIndex = 0;
			this.rbCommaOff.Text = "しない";
			this.gbZeroDisp.Controls.Add(this.rbZeroDispOn);
			this.gbZeroDisp.Controls.Add(this.rbZeroDispOff);
			this.gbZeroDisp.Location = new Point(12, 92);
			this.gbZeroDisp.Name = "gbZeroDisp";
			this.gbZeroDisp.Size = new Size(120, 72);
			this.gbZeroDisp.TabIndex = 1;
			this.gbZeroDisp.TabStop = false;
			this.gbZeroDisp.Text = "0表示(&0)";
			this.rbZeroDispOn.Location = new Point(8, 40);
			this.rbZeroDispOn.Name = "rbZeroDispOn";
			this.rbZeroDispOn.Size = new Size(104, 24);
			this.rbZeroDispOn.TabIndex = 1;
			this.rbZeroDispOn.Text = "する";
			this.rbZeroDispOff.Location = new Point(8, 16);
			this.rbZeroDispOff.Name = "rbZeroDispOff";
			this.rbZeroDispOff.Size = new Size(104, 24);
			this.rbZeroDispOff.TabIndex = 0;
			this.rbZeroDispOff.Text = "しない";
			this.cbCalcInp.Location = new Point(16, 168);
			this.cbCalcInp.Name = "cbCalcInp";
			this.cbCalcInp.Size = new Size(104, 24);
			this.cbCalcInp.TabIndex = 2;
			this.cbCalcInp.Text = "電卓入力(&I)";
			this.cbMinusSupp.Location = new Point(16, 192);
			this.cbMinusSupp.Name = "cbMinusSupp";
			this.cbMinusSupp.Size = new Size(136, 24);
			this.cbMinusSupp.TabIndex = 3;
			this.cbMinusSupp.Text = "マイナス入力抑制(&M)";
			this.gbZeroSupp.Controls.Add(this.rbZeroSuppFill);
			this.gbZeroSupp.Controls.Add(this.rbZeroSuppOn);
			this.gbZeroSupp.Controls.Add(this.rbZeroSuppOff);
			this.gbZeroSupp.Location = new Point(160, 12);
			this.gbZeroSupp.Name = "gbZeroSupp";
			this.gbZeroSupp.Size = new Size(120, 92);
			this.gbZeroSupp.TabIndex = 4;
			this.gbZeroSupp.TabStop = false;
			this.gbZeroSupp.Text = "ゼロ抑制(&Z)";
			this.rbZeroSuppFill.Location = new Point(8, 64);
			this.rbZeroSuppFill.Name = "rbZeroSuppFill";
			this.rbZeroSuppFill.Size = new Size(96, 24);
			this.rbZeroSuppFill.TabIndex = 2;
			this.rbZeroSuppFill.Text = "ゼロ詰め";
			this.rbZeroSuppOn.Location = new Point(8, 40);
			this.rbZeroSuppOn.Name = "rbZeroSuppOn";
			this.rbZeroSuppOn.Size = new Size(96, 24);
			this.rbZeroSuppOn.TabIndex = 1;
			this.rbZeroSuppOn.Text = "する";
			this.rbZeroSuppOff.Location = new Point(8, 16);
			this.rbZeroSuppOff.Name = "rbZeroSuppOff";
			this.rbZeroSuppOff.Size = new Size(96, 24);
			this.rbZeroSuppOff.TabIndex = 0;
			this.rbZeroSuppOff.Text = "しない";
			this.lbDecLen.Location = new Point(160, 112);
			this.lbDecLen.Name = "lbDecLen";
			this.lbDecLen.Size = new Size(88, 23);
			this.lbDecLen.TabIndex = 5;
			this.lbDecLen.Text = "小数桁数(&D)";
			this.lbDecLen.TextAlign = ContentAlignment.MiddleLeft;
			this.tbDecLen.Location = new Point(256, 112);
			this.tbDecLen.Name = "tbDecLen";
			this.tbDecLen.Size = new Size(24, 19);
			this.tbDecLen.TabIndex = 6;
			appearance.Image = componentResourceManager.GetObject("appearance1.Image");
			this.btnCancel.Appearance = appearance;
			this.btnCancel.DialogResult = DialogResult.Cancel;
			this.btnCancel.ImageSize = new Size(24, 24);
			this.btnCancel.ImageTransparentColor = Color.White;
			this.btnCancel.Location = new Point(192, 188);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new Size(92, 36);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			appearance2.Image = componentResourceManager.GetObject("appearance2.Image");
			this.btnOK.Appearance = appearance2;
			this.btnOK.DialogResult = DialogResult.OK;
			this.btnOK.ImageSize = new Size(24, 24);
			this.btnOK.ImageTransparentColor = Color.White;
			this.btnOK.Location = new Point(192, 144);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new Size(92, 36);
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "OK";
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new Size(5, 12);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new Size(292, 233);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.tbDecLen);
			base.Controls.Add(this.lbDecLen);
			base.Controls.Add(this.gbZeroSupp);
			base.Controls.Add(this.cbMinusSupp);
			base.Controls.Add(this.cbCalcInp);
			base.Controls.Add(this.gbZeroDisp);
			base.Controls.Add(this.gbComma);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.KeyPreview = true;
			base.Name = "TNumEditEditorForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "数値編集プロパティの設定";
			base.KeyDown += new KeyEventHandler(this.TNumEditEditorForm_KeyDown);
			this.gbComma.ResumeLayout(false);
			this.gbZeroDisp.ResumeLayout(false);
			this.gbZeroSupp.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public void SetValue(TNumEdit value)
		{
			if (value.CommaEdit)
			{
				this.rbCommaOn.Checked = true;
			}
			else
			{
				this.rbCommaOff.Checked = true;
			}
			if (value.ZeroDisp)
			{
				this.rbZeroDispOn.Checked = true;
			}
			else
			{
				this.rbZeroDispOff.Checked = true;
			}
			this.cbCalcInp.Checked = value.CalcInput;
			this.cbMinusSupp.Checked = value.MinusSupp;
			switch (value.ZeroSupp)
			{
			case emZeroSupp.zsFILL:
				this.rbZeroSuppFill.Checked = true;
				break;
			case emZeroSupp.zsOFF:
				this.rbZeroSuppOff.Checked = true;
				break;
			case emZeroSupp.zsON:
				this.rbZeroSuppOn.Checked = true;
				break;
			}
			this.tbDecLen.Text = value.DecLen.ToString();
		}
		public TNumEdit GetValue()
		{
			emZeroSupp iZeroSupp;
			if (this.rbZeroSuppFill.Checked)
			{
				iZeroSupp = emZeroSupp.zsFILL;
			}
			else
			{
				if (this.rbZeroSuppOn.Checked)
				{
					iZeroSupp = emZeroSupp.zsON;
				}
				else
				{
					iZeroSupp = emZeroSupp.zsOFF;
				}
			}
			return new TNumEdit(this.cbCalcInp.Checked, int.Parse(this.tbDecLen.Text.Trim()), this.rbCommaOn.Checked, this.cbMinusSupp.Checked, this.rbZeroDispOn.Checked, iZeroSupp);
		}
		private void TNumEditEditorForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}
	}
}
