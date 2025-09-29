namespace Broadleaf.Windows.Forms
{
    partial class ServerConfigurationView
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

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.chkAdjustAutomatically = new System.Windows.Forms.CheckBox();
            this.chkShowDeletedData = new System.Windows.Forms.CheckBox();
            this.pnlDB = new System.Windows.Forms.Panel();
            this.gridDB = new System.Windows.Forms.DataGridView();
            this.btnImport = new System.Windows.Forms.Button();
            this.pnlDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDB)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "新規(&N)";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(84, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "削除(&D)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(165, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "修正(&E)";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // chkAdjustAutomatically
            // 
            this.chkAdjustAutomatically.AutoSize = true;
            this.chkAdjustAutomatically.Location = new System.Drawing.Point(3, 371);
            this.chkAdjustAutomatically.Name = "chkAdjustAutomatically";
            this.chkAdjustAutomatically.Size = new System.Drawing.Size(113, 16);
            this.chkAdjustAutomatically.TabIndex = 13;
            this.chkAdjustAutomatically.Text = "列サイズ自動調整";
            this.chkAdjustAutomatically.UseVisualStyleBackColor = true;
            this.chkAdjustAutomatically.CheckedChanged += new System.EventHandler(this.chkAdjustAutomatically_CheckedChanged);
            // 
            // chkShowDeletedData
            // 
            this.chkShowDeletedData.AutoSize = true;
            this.chkShowDeletedData.Location = new System.Drawing.Point(122, 371);
            this.chkShowDeletedData.Name = "chkShowDeletedData";
            this.chkShowDeletedData.Size = new System.Drawing.Size(133, 16);
            this.chkShowDeletedData.TabIndex = 14;
            this.chkShowDeletedData.Text = "削除済みデータの表示";
            this.chkShowDeletedData.UseVisualStyleBackColor = true;
            this.chkShowDeletedData.CheckedChanged += new System.EventHandler(this.chkShowDeletedData_CheckedChanged);
            // 
            // pnlDB
            // 
            this.pnlDB.Controls.Add(this.gridDB);
            this.pnlDB.Location = new System.Drawing.Point(3, 32);
            this.pnlDB.Name = "pnlDB";
            this.pnlDB.Size = new System.Drawing.Size(874, 333);
            this.pnlDB.TabIndex = 11;
            // 
            // gridDB
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.gridDB.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDB.Location = new System.Drawing.Point(0, 0);
            this.gridDB.MultiSelect = false;
            this.gridDB.Name = "gridDB";
            this.gridDB.ReadOnly = true;
            this.gridDB.RowTemplate.Height = 21;
            this.gridDB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDB.Size = new System.Drawing.Size(874, 333);
            this.gridDB.TabIndex = 12;
            this.gridDB.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridDB_CellMouseDoubleClick);
            this.gridDB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridDB_KeyDown);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(802, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = "インポート(&I)";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Visible = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // ServerConfigurationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.pnlDB);
            this.Controls.Add(this.chkShowDeletedData);
            this.Controls.Add(this.chkAdjustAutomatically);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Name = "ServerConfigurationView";
            this.Size = new System.Drawing.Size(880, 390);
            this.Load += new System.EventHandler(this.ServerConfiguratorView_Load);
            this.pnlDB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.CheckBox chkAdjustAutomatically;
        private System.Windows.Forms.CheckBox chkShowDeletedData;
        private System.Windows.Forms.Panel pnlDB;
        private System.Windows.Forms.DataGridView gridDB;
        private System.Windows.Forms.Button btnImport;
    }
}
