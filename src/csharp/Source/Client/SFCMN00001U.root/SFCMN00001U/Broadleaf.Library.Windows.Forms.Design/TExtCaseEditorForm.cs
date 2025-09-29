using Infragistics.Win;
using Infragistics.Win.Misc;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms.Design
{
	internal class TExtCaseEditorForm : Form
	{
		private CheckBox cbEnter;
		private CheckBox cbTAB;
		private CheckBox cbSTAB;
		private CheckBox cbUP;
		private CheckBox cbRIGHT;
		private CheckBox cbDOWN;
		private CheckBox cbLEFT;
		private CheckBox cbSEnter;
		private UltraButton btnOK;
		private UltraButton btnCancel;
		private GroupBox groupBox1;
		private CheckBox cbNecessary;
		private GroupBox groupBox2;
		private GroupBox groupBox3;
        private Container components = null;
		public TExtCaseEditorForm()
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TExtCaseEditorForm));
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			this.cbEnter = new CheckBox();
			this.cbSEnter = new CheckBox();
			this.cbTAB = new CheckBox();
			this.cbSTAB = new CheckBox();
			this.cbUP = new CheckBox();
			this.cbLEFT = new CheckBox();
			this.cbRIGHT = new CheckBox();
			this.cbDOWN = new CheckBox();
			this.btnOK = new UltraButton();
			this.btnCancel = new UltraButton();
			this.groupBox1 = new GroupBox();
			this.cbNecessary = new CheckBox();
			this.groupBox2 = new GroupBox();
			this.groupBox3 = new GroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			base.SuspendLayout();
			this.cbEnter.Font = new Font("MS UI Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);
			this.cbEnter.Location = new Point(8, 20);
			this.cbEnter.Name = "cbEnter";
			this.cbEnter.Size = new Size(74, 24);
			this.cbEnter.TabIndex = 1;
			this.cbEnter.Text = "改行キー";
			this.cbSEnter.Font = new Font("MS UI Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);
			this.cbSEnter.Location = new Point(88, 20);
			this.cbSEnter.Name = "cbSEnter";
			this.cbSEnter.Size = new Size(120, 24);
			this.cbSEnter.TabIndex = 2;
			this.cbSEnter.Text = "SHIFT+改行キー";
			this.cbTAB.Font = new Font("MS UI Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);
			this.cbTAB.Location = new Point(8, 44);
			this.cbTAB.Name = "cbTAB";
			this.cbTAB.Size = new Size(74, 24);
			this.cbTAB.TabIndex = 3;
			this.cbTAB.Text = "TABキー";
			this.cbSTAB.Font = new Font("MS UI Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);
			this.cbSTAB.Location = new Point(88, 44);
			this.cbSTAB.Name = "cbSTAB";
			this.cbSTAB.Size = new Size(120, 24);
			this.cbSTAB.TabIndex = 4;
			this.cbSTAB.Text = "SHIFT+TABキー";
			this.cbUP.Font = new Font("MS UI Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);
			this.cbUP.Location = new Point(68, 24);
			this.cbUP.Name = "cbUP";
			this.cbUP.Size = new Size(104, 24);
			this.cbUP.TabIndex = 0;
			this.cbUP.Text = "↑キー";
			this.cbLEFT.Font = new Font("MS UI Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);
			this.cbLEFT.Location = new Point(20, 48);
			this.cbLEFT.Name = "cbLEFT";
			this.cbLEFT.Size = new Size(68, 24);
			this.cbLEFT.TabIndex = 1;
			this.cbLEFT.Text = "←キー";
			this.cbRIGHT.Font = new Font("MS UI Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);
			this.cbRIGHT.Location = new Point(116, 48);
			this.cbRIGHT.Name = "cbRIGHT";
			this.cbRIGHT.Size = new Size(80, 24);
			this.cbRIGHT.TabIndex = 2;
			this.cbRIGHT.Text = "→キー";
			this.cbDOWN.Font = new Font("MS UI Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);
			this.cbDOWN.Location = new Point(68, 72);
			this.cbDOWN.Name = "cbDOWN";
			this.cbDOWN.Size = new Size(104, 24);
			this.cbDOWN.TabIndex = 3;
			this.cbDOWN.Text = "↓キー";
			appearance.Image = componentResourceManager.GetObject("appearance1.Image");
			this.btnOK.Appearance = appearance;
			this.btnOK.DialogResult = DialogResult.OK;
			this.btnOK.ImageSize = new Size(24, 24);
			this.btnOK.ImageTransparentColor = Color.White;
			this.btnOK.Location = new Point(24, 244);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new Size(92, 36);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			appearance2.Image = componentResourceManager.GetObject("appearance2.Image");
			this.btnCancel.Appearance = appearance2;
			this.btnCancel.DialogResult = DialogResult.Cancel;
			this.btnCancel.ImageSize = new Size(24, 24);
			this.btnCancel.ImageTransparentColor = Color.White;
			this.btnCancel.Location = new Point(132, 244);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new Size(92, 36);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.groupBox1.Controls.Add(this.cbNecessary);
			this.groupBox1.Font = new Font("MS UI Gothic", 9f, FontStyle.Bold, GraphicsUnit.Point, 128);
			this.groupBox1.Location = new Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(216, 44);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Both Check Item";
			this.cbNecessary.Font = new Font("MS UI Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);
			this.cbNecessary.Location = new Point(56, 16);
			this.cbNecessary.Name = "cbNecessary";
			this.cbNecessary.Size = new Size(104, 24);
			this.cbNecessary.TabIndex = 1;
			this.cbNecessary.Text = "入力必須";
			this.groupBox2.Controls.Add(this.cbSTAB);
			this.groupBox2.Controls.Add(this.cbTAB);
			this.groupBox2.Controls.Add(this.cbSEnter);
			this.groupBox2.Controls.Add(this.cbEnter);
			this.groupBox2.Font = new Font("MS UI Gothic", 9f, FontStyle.Bold, GraphicsUnit.Point, 128);
			this.groupBox2.Location = new Point(16, 56);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(216, 72);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "TRetKeyControl Check Item";
			this.groupBox3.Controls.Add(this.cbDOWN);
			this.groupBox3.Controls.Add(this.cbRIGHT);
			this.groupBox3.Controls.Add(this.cbLEFT);
			this.groupBox3.Controls.Add(this.cbUP);
			this.groupBox3.Font = new Font("MS UI Gothic", 9f, FontStyle.Bold, GraphicsUnit.Point, 128);
			this.groupBox3.Location = new Point(16, 132);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(216, 100);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "TArrowKeyControl Check Item";
			base.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new Size(5, 12);
			base.CancelButton = this.btnCancel;
			base.ClientSize = new Size(250, 292);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.KeyPreview = true;
			base.Name = "TExtCaseEditorForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "脱出要件プロパティ設定";
			base.KeyDown += new KeyEventHandler(this.TExtCaseEditorForm_KeyDown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			base.ResumeLayout(false);
		}
		public void SetValue(TExtCase value)
		{
			this.cbNecessary.Checked = value.Necessary;
			this.cbEnter.Checked = value.RetKey;
			this.cbSEnter.Checked = value.ShiftRetKey;
			this.cbTAB.Checked = value.TabKey;
			this.cbSTAB.Checked = value.ShiftTabKey;
			this.cbUP.Checked = value.UpKey;
			this.cbLEFT.Checked = value.LeftKey;
			this.cbRIGHT.Checked = value.RightKey;
			this.cbDOWN.Checked = value.DownKey;
		}
		public TExtCase GetValue()
		{
			return new TExtCase(this.cbDOWN.Checked, this.cbUP.Checked, this.cbLEFT.Checked, this.cbRIGHT.Checked, this.cbEnter.Checked, this.cbSEnter.Checked, this.cbTAB.Checked, this.cbSTAB.Checked, this.cbNecessary.Checked);
		}
		private void TExtCaseEditorForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}
	}
}
