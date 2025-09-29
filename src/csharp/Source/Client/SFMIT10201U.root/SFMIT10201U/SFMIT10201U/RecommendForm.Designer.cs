namespace Broadleaf.Windows.Forms
{
    partial class RecommendForm
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.Category_Label = new System.Windows.Forms.Label();
            this.Category_textBox = new System.Windows.Forms.TextBox();
            this.Cndition_Lable = new System.Windows.Forms.Label();
            this.Target1_ComboEditor = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.PM_Label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Save_Button = new Infragistics.Win.Misc.UltraButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Target1_panel = new System.Windows.Forms.Panel();
            this.SF_Lable = new System.Windows.Forms.Label();
            this.Target3_panel = new System.Windows.Forms.Panel();
            this.Target2_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Target1_ComboEditor)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Target1_panel.SuspendLayout();
            this.Target3_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Target2_ComboEditor)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // Category_Label
            // 
            this.Category_Label.Location = new System.Drawing.Point(15, 15);
            this.Category_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Category_Label.Name = "Category_Label";
            this.Category_Label.Size = new System.Drawing.Size(133, 19);
            this.Category_Label.TabIndex = 2;
            this.Category_Label.Text = "商品カテゴリ";
            // 
            // Category_textBox
            // 
            this.Category_textBox.Enabled = false;
            this.Category_textBox.Location = new System.Drawing.Point(126, 12);
            this.Category_textBox.Name = "Category_textBox";
            this.Category_textBox.Size = new System.Drawing.Size(145, 22);
            this.Category_textBox.TabIndex = 3;
            // 
            // Cndition_Lable
            // 
            this.Cndition_Lable.Location = new System.Drawing.Point(15, 9);
            this.Cndition_Lable.Name = "Cndition_Lable";
            this.Cndition_Lable.Size = new System.Drawing.Size(298, 18);
            this.Cndition_Lable.TabIndex = 4;
            this.Cndition_Lable.Text = "各サイズの中で";
            // 
            // Target1_ComboEditor
            // 
            this.Target1_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Target1_ComboEditor.Location = new System.Drawing.Point(18, 6);
            this.Target1_ComboEditor.Name = "Target1_ComboEditor";
            this.Target1_ComboEditor.Size = new System.Drawing.Size(128, 24);
            this.Target1_ComboEditor.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(152, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 9;
            // 
            // PM_Label
            // 
            this.PM_Label.Location = new System.Drawing.Point(153, 10);
            this.PM_Label.Name = "PM_Label";
            this.PM_Label.Size = new System.Drawing.Size(162, 24);
            this.PM_Label.TabIndex = 11;
            this.PM_Label.Text = "の粗利が高い商品";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(153, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "件をオススメする";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.Cancel_Button.Appearance = appearance1;
            this.Cancel_Button.HotTracking = true;
            this.Cancel_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Cancel_Button.Location = new System.Drawing.Point(261, 15);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(78, 34);
            this.Cancel_Button.TabIndex = 107;
            this.Cancel_Button.Text = "戻る(&X)";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.Save_Button.Appearance = appearance2;
            this.Save_Button.HotTracking = true;
            this.Save_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Save_Button.Location = new System.Drawing.Point(174, 15);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(81, 34);
            this.Save_Button.TabIndex = 106;
            this.Save_Button.Text = "確定(&S)";
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Category_textBox);
            this.panel1.Controls.Add(this.Category_Label);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 44);
            this.panel1.TabIndex = 108;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Cndition_Lable);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 38);
            this.panel2.TabIndex = 109;
            // 
            // Target1_panel
            // 
            this.Target1_panel.Controls.Add(this.Target1_ComboEditor);
            this.Target1_panel.Controls.Add(this.SF_Lable);
            this.Target1_panel.Controls.Add(this.PM_Label);
            this.Target1_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Target1_panel.Location = new System.Drawing.Point(0, 82);
            this.Target1_panel.Name = "Target1_panel";
            this.Target1_panel.Size = new System.Drawing.Size(345, 38);
            this.Target1_panel.TabIndex = 110;
            // 
            // SF_Lable
            // 
            this.SF_Lable.Location = new System.Drawing.Point(15, 9);
            this.SF_Lable.Name = "SF_Lable";
            this.SF_Lable.Size = new System.Drawing.Size(121, 24);
            this.SF_Lable.TabIndex = 12;
            this.SF_Lable.Text = "粗利が高い商品";
            this.SF_Lable.Visible = false;
            // 
            // Target3_panel
            // 
            this.Target3_panel.Controls.Add(this.Target2_ComboEditor);
            this.Target3_panel.Controls.Add(this.label2);
            this.Target3_panel.Controls.Add(this.label4);
            this.Target3_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Target3_panel.Location = new System.Drawing.Point(0, 120);
            this.Target3_panel.Name = "Target3_panel";
            this.Target3_panel.Size = new System.Drawing.Size(345, 38);
            this.Target3_panel.TabIndex = 112;
            // 
            // Target2_ComboEditor
            // 
            this.Target2_ComboEditor.ActiveAppearance = appearance3;
            appearance4.TextHAlign = Infragistics.Win.HAlign.Right;
            this.Target2_ComboEditor.Appearance = appearance4;
            this.Target2_ComboEditor.Location = new System.Drawing.Point(60, 8);
            this.Target2_ComboEditor.Name = "Target2_ComboEditor";
            this.Target2_ComboEditor.Size = new System.Drawing.Size(86, 24);
            this.Target2_ComboEditor.TabIndex = 109;
            this.Target2_ComboEditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tComboEditor1_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 21);
            this.label2.TabIndex = 108;
            this.label2.Text = "上位";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.Cancel_Button);
            this.panel6.Controls.Add(this.Save_Button);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 158);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(345, 61);
            this.panel6.TabIndex = 113;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // RecommendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 219);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.Target3_panel);
            this.Controls.Add(this.Target1_panel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RecommendForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "オススメ設定";
            ((System.ComponentModel.ISupportInitialize)(this.Target1_ComboEditor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.Target1_panel.ResumeLayout(false);
            this.Target1_panel.PerformLayout();
            this.Target3_panel.ResumeLayout(false);
            this.Target3_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Target2_ComboEditor)).EndInit();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Category_Label;
        private System.Windows.Forms.TextBox Category_textBox;
        private System.Windows.Forms.Label Cndition_Lable;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor Target1_ComboEditor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PM_Label;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Save_Button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel Target1_panel;
        private System.Windows.Forms.Panel Target3_panel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label SF_Lable;
        private System.Windows.Forms.Label label2;
        private Broadleaf.Library.Windows.Forms.TComboEditor Target2_ComboEditor;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
    }
}