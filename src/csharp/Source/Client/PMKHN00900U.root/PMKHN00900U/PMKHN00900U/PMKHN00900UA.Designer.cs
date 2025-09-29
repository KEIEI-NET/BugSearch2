namespace Broadleaf.Windows.Forms
{
    partial class PMKHN00900UA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN00900UA));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.tabCtlInfor = new System.Windows.Forms.TabControl();
            this.tabPgCustHis = new System.Windows.Forms.TabPage();
            this.webBroCustHis = new System.Windows.Forms.WebBrowser();
            this.tabPgVer = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpBox_Top = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.rbBtnAll = new System.Windows.Forms.RadioButton();
            this.rbBtnDiff = new System.Windows.Forms.RadioButton();
            this.panel_bottom.SuspendLayout();
            this.tabCtlInfor.SuspendLayout();
            this.tabPgCustHis.SuspendLayout();
            this.tabPgVer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gpBox_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 358);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(592, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel_bottom
            // 
            this.panel_bottom.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel_bottom.Controls.Add(this.tabCtlInfor);
            this.panel_bottom.Location = new System.Drawing.Point(12, 105);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(566, 242);
            this.panel_bottom.TabIndex = 2;
            // 
            // tabCtlInfor
            // 
            this.tabCtlInfor.Controls.Add(this.tabPgCustHis);
            this.tabCtlInfor.Controls.Add(this.tabPgVer);
            this.tabCtlInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtlInfor.Location = new System.Drawing.Point(0, 0);
            this.tabCtlInfor.Name = "tabCtlInfor";
            this.tabCtlInfor.SelectedIndex = 0;
            this.tabCtlInfor.Size = new System.Drawing.Size(566, 242);
            this.tabCtlInfor.TabIndex = 0;
            this.tabCtlInfor.SelectedIndexChanged += new System.EventHandler(this.tabCtlInfor_SelectedIndexChanged);
            // 
            // tabPgCustHis
            // 
            this.tabPgCustHis.Controls.Add(this.webBroCustHis);
            this.tabPgCustHis.Location = new System.Drawing.Point(4, 22);
            this.tabPgCustHis.Name = "tabPgCustHis";
            this.tabPgCustHis.Padding = new System.Windows.Forms.Padding(3);
            this.tabPgCustHis.Size = new System.Drawing.Size(558, 216);
            this.tabPgCustHis.TabIndex = 0;
            this.tabPgCustHis.Text = "個別導入履歴";
            this.tabPgCustHis.UseVisualStyleBackColor = true;
            // 
            // webBroCustHis
            // 
            this.webBroCustHis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBroCustHis.Location = new System.Drawing.Point(3, 3);
            this.webBroCustHis.MinimumSize = new System.Drawing.Size(20, 18);
            this.webBroCustHis.Name = "webBroCustHis";
            this.webBroCustHis.Size = new System.Drawing.Size(552, 210);
            this.webBroCustHis.TabIndex = 0;
            this.webBroCustHis.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // tabPgVer
            // 
            this.tabPgVer.Controls.Add(this.dataGridView1);
            this.tabPgVer.Location = new System.Drawing.Point(4, 22);
            this.tabPgVer.Name = "tabPgVer";
            this.tabPgVer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPgVer.Size = new System.Drawing.Size(558, 216);
            this.tabPgVer.TabIndex = 1;
            this.tabPgVer.Text = "バージョン情報";
            this.tabPgVer.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column2,
            this.Column3});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlText;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(552, 210);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "A";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "B";
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "C";
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "D";
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // gpBox_Top
            // 
            this.gpBox_Top.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gpBox_Top.Controls.Add(this.btnCopy);
            this.gpBox_Top.Controls.Add(this.rbBtnAll);
            this.gpBox_Top.Controls.Add(this.rbBtnDiff);
            this.gpBox_Top.Location = new System.Drawing.Point(13, 7);
            this.gpBox_Top.Name = "gpBox_Top";
            this.gpBox_Top.Size = new System.Drawing.Size(566, 84);
            this.gpBox_Top.TabIndex = 3;
            this.gpBox_Top.TabStop = false;
            this.gpBox_Top.Text = "ファイルコピー方法";
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::Broadleaf.Windows.Forms.Properties.Resources.個別PGインストール;
            this.btnCopy.Location = new System.Drawing.Point(483, 11);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 62);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "コピー開始";
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // rbBtnAll
            // 
            this.rbBtnAll.AutoSize = true;
            this.rbBtnAll.Location = new System.Drawing.Point(21, 51);
            this.rbBtnAll.Name = "rbBtnAll";
            this.rbBtnAll.Size = new System.Drawing.Size(151, 16);
            this.rbBtnAll.TabIndex = 1;
            this.rbBtnAll.Text = "全てのファイルをコピーする。";
            this.rbBtnAll.UseVisualStyleBackColor = true;
            // 
            // rbBtnDiff
            // 
            this.rbBtnDiff.AutoSize = true;
            this.rbBtnDiff.Checked = true;
            this.rbBtnDiff.Location = new System.Drawing.Point(21, 24);
            this.rbBtnDiff.Name = "rbBtnDiff";
            this.rbBtnDiff.Size = new System.Drawing.Size(264, 16);
            this.rbBtnDiff.TabIndex = 0;
            this.rbBtnDiff.TabStop = true;
            this.rbBtnDiff.Text = "ファイル日付が異なるファイルのみ上書きコピーする。";
            this.rbBtnDiff.UseVisualStyleBackColor = true;
            // 
            // PMKHN00900UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 380);
            this.Controls.Add(this.gpBox_Top);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(541, 234);
            this.Name = "PMKHN00900UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "個別プログラム導入";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PMKHN00900UA_FormClosed);
            this.panel_bottom.ResumeLayout(false);
            this.tabCtlInfor.ResumeLayout(false);
            this.tabPgCustHis.ResumeLayout(false);
            this.tabPgVer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gpBox_Top.ResumeLayout(false);
            this.gpBox_Top.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.GroupBox gpBox_Top;
        private System.Windows.Forms.TabControl tabCtlInfor;
        private System.Windows.Forms.TabPage tabPgCustHis;
        private System.Windows.Forms.TabPage tabPgVer;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.RadioButton rbBtnAll;
        private System.Windows.Forms.RadioButton rbBtnDiff;
        private System.Windows.Forms.WebBrowser webBroCustHis;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}

