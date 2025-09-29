namespace Broadleaf.Windows.Forms
{
    partial class CsvImportForm
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
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            this.FolderSelect_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OutputPath_TextBox = new System.Windows.Forms.TextBox();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Output_button = new System.Windows.Forms.Button();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Import_button = new System.Windows.Forms.Button();
            this.ImportPath_TextBox = new System.Windows.Forms.TextBox();
            this.FileSelect_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Category_textBox = new Broadleaf.Library.Windows.Forms.TEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Category_textBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FolderSelect_button
            // 
            this.FolderSelect_button.Location = new System.Drawing.Point(613, 87);
            this.FolderSelect_button.Margin = new System.Windows.Forms.Padding(4);
            this.FolderSelect_button.Name = "FolderSelect_button";
            this.FolderSelect_button.Size = new System.Drawing.Size(52, 24);
            this.FolderSelect_button.TabIndex = 6;
            this.FolderSelect_button.Text = "選択";
            this.FolderSelect_button.UseVisualStyleBackColor = true;
            this.FolderSelect_button.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(156, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "出力先";
            this.label1.Visible = false;
            // 
            // OutputPath_TextBox
            // 
            this.OutputPath_TextBox.Location = new System.Drawing.Point(215, 89);
            this.OutputPath_TextBox.Multiline = true;
            this.OutputPath_TextBox.Name = "OutputPath_TextBox";
            this.OutputPath_TextBox.Size = new System.Drawing.Size(396, 22);
            this.OutputPath_TextBox.TabIndex = 8;
            this.OutputPath_TextBox.Visible = false;
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.label4);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Controls.Add(this.Output_button);
            this.ultraGroupBox1.Controls.Add(this.OutputPath_TextBox);
            this.ultraGroupBox1.Controls.Add(this.FolderSelect_button);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(12, 53);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(702, 123);
            this.ultraGroupBox1.SupportThemes = false;
            this.ultraGroupBox1.TabIndex = 10;
            this.ultraGroupBox1.Text = "フォーマット出力";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(591, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "出力先を選択して出力ボタンをクリックして下さい。";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(591, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "CSV取込を行う為のフォーマットファイルを出力します。";
            // 
            // Output_button
            // 
            this.Output_button.Location = new System.Drawing.Point(23, 83);
            this.Output_button.Margin = new System.Windows.Forms.Padding(4);
            this.Output_button.Name = "Output_button";
            this.Output_button.Size = new System.Drawing.Size(87, 30);
            this.Output_button.TabIndex = 9;
            this.Output_button.Text = "出力(&O)";
            this.Output_button.UseVisualStyleBackColor = true;
            this.Output_button.Click += new System.EventHandler(this.Output_button_Click);
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.label11);
            this.ultraGroupBox2.Controls.Add(this.label10);
            this.ultraGroupBox2.Controls.Add(this.label9);
            this.ultraGroupBox2.Controls.Add(this.label8);
            this.ultraGroupBox2.Controls.Add(this.label7);
            this.ultraGroupBox2.Controls.Add(this.label5);
            this.ultraGroupBox2.Controls.Add(this.Import_button);
            this.ultraGroupBox2.Controls.Add(this.ImportPath_TextBox);
            this.ultraGroupBox2.Controls.Add(this.FileSelect_button);
            this.ultraGroupBox2.Controls.Add(this.label2);
            this.ultraGroupBox2.Location = new System.Drawing.Point(12, 180);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(702, 216);
            this.ultraGroupBox2.SupportThemes = false;
            this.ultraGroupBox2.TabIndex = 11;
            this.ultraGroupBox2.Text = "CSV取込";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(21, 143);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(644, 22);
            this.label9.TabIndex = 14;
            this.label9.Text = "データ例）1,0,0123456,2680,ブリヂストン,・・・";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(20, 120);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(644, 22);
            this.label8.TabIndex = 13;
            this.label8.Text = "※各項目は「,(カンマ)」で区切って下さい。";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(20, 51);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(645, 22);
            this.label7.TabIndex = 12;
            this.label7.Text = "取込ボタンをクリックして、上記商品カテゴリのCSVファイルを選択して下さい。";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(20, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(591, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "CSVファイルより商品データの取込を行います。";
            // 
            // Import_button
            // 
            this.Import_button.Location = new System.Drawing.Point(23, 171);
            this.Import_button.Margin = new System.Windows.Forms.Padding(4);
            this.Import_button.Name = "Import_button";
            this.Import_button.Size = new System.Drawing.Size(87, 30);
            this.Import_button.TabIndex = 10;
            this.Import_button.Text = "取込(&I)";
            this.Import_button.UseVisualStyleBackColor = true;
            this.Import_button.Click += new System.EventHandler(this.Import_button_Click);
            // 
            // ImportPath_TextBox
            // 
            this.ImportPath_TextBox.Location = new System.Drawing.Point(215, 176);
            this.ImportPath_TextBox.Name = "ImportPath_TextBox";
            this.ImportPath_TextBox.Size = new System.Drawing.Size(396, 22);
            this.ImportPath_TextBox.TabIndex = 8;
            this.ImportPath_TextBox.Visible = false;
            // 
            // FileSelect_button
            // 
            this.FileSelect_button.Location = new System.Drawing.Point(613, 175);
            this.FileSelect_button.Margin = new System.Windows.Forms.Padding(4);
            this.FileSelect_button.Name = "FileSelect_button";
            this.FileSelect_button.Size = new System.Drawing.Size(51, 24);
            this.FileSelect_button.TabIndex = 6;
            this.FileSelect_button.Text = "選択";
            this.FileSelect_button.UseVisualStyleBackColor = true;
            this.FileSelect_button.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(120, 176);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "CSVファイル";
            this.label2.Visible = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(14, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "商品カテゴリ";
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
            // Category_textBox
            // 
            this.Category_textBox.ActiveAppearance = appearance9;
            appearance10.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            this.Category_textBox.Appearance = appearance10;
            this.Category_textBox.AutoSelect = true;
            this.Category_textBox.AutoSize = false;
            this.Category_textBox.DataText = "";
            this.Category_textBox.Enabled = false;
            this.Category_textBox.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Category_textBox.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.Category_textBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Category_textBox.Location = new System.Drawing.Point(133, 14);
            this.Category_textBox.MaxLength = 30;
            this.Category_textBox.Name = "Category_textBox";
            this.Category_textBox.Size = new System.Drawing.Size(200, 24);
            this.Category_textBox.TabIndex = 151;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(21, 74);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(644, 22);
            this.label10.TabIndex = 15;
            this.label10.Text = "【CSVデータ形式について】";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(21, 97);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(644, 22);
            this.label11.TabIndex = 16;
            this.label11.Text = "※先頭行はヘッダー列の為、取込対象外です。";
            // 
            // CsvImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 405);
            this.Controls.Add(this.Category_textBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CsvImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSV取込";
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Category_textBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FolderSelect_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox OutputPath_TextBox;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private System.Windows.Forms.Button Output_button;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private System.Windows.Forms.Button Import_button;
        private System.Windows.Forms.TextBox ImportPath_TextBox;
        private System.Windows.Forms.Button FileSelect_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TEdit Category_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}