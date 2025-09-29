namespace WindowsApplication
{
	partial class Form1
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.gridPrtItemGrp = new System.Windows.Forms.DataGridView();
			this.pnlPrtItemGrp = new System.Windows.Forms.Panel();
			this.btnSearchPrtItemGrp = new System.Windows.Forms.Button();
			this.btnSearchPrtItemSet = new System.Windows.Forms.Button();
			this.gridPrtItemSet = new System.Windows.Forms.DataGridView();
			this.pnlPrtItemSet = new System.Windows.Forms.Panel();
			this.txtFreePrtPprItemGrpCd = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.gridPrtItemGrp)).BeginInit();
			this.pnlPrtItemGrp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridPrtItemSet)).BeginInit();
			this.pnlPrtItemSet.SuspendLayout();
			this.SuspendLayout();
			// 
			// gridPrtItemGrp
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridPrtItemGrp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.gridPrtItemGrp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridPrtItemGrp.DefaultCellStyle = dataGridViewCellStyle2;
			this.gridPrtItemGrp.Dock = System.Windows.Forms.DockStyle.Top;
			this.gridPrtItemGrp.Location = new System.Drawing.Point(0, 39);
			this.gridPrtItemGrp.Name = "gridPrtItemGrp";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridPrtItemGrp.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.gridPrtItemGrp.RowTemplate.Height = 21;
			this.gridPrtItemGrp.Size = new System.Drawing.Size(722, 133);
			this.gridPrtItemGrp.TabIndex = 0;
			// 
			// pnlPrtItemGrp
			// 
			this.pnlPrtItemGrp.Controls.Add(this.btnSearchPrtItemGrp);
			this.pnlPrtItemGrp.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlPrtItemGrp.Location = new System.Drawing.Point(0, 0);
			this.pnlPrtItemGrp.Name = "pnlPrtItemGrp";
			this.pnlPrtItemGrp.Size = new System.Drawing.Size(722, 39);
			this.pnlPrtItemGrp.TabIndex = 1;
			// 
			// btnSearchPrtItemGrp
			// 
			this.btnSearchPrtItemGrp.Location = new System.Drawing.Point(8, 8);
			this.btnSearchPrtItemGrp.Name = "btnSearchPrtItemGrp";
			this.btnSearchPrtItemGrp.Size = new System.Drawing.Size(128, 23);
			this.btnSearchPrtItemGrp.TabIndex = 0;
			this.btnSearchPrtItemGrp.Text = "SearchPrtItemGrp";
			this.btnSearchPrtItemGrp.UseVisualStyleBackColor = true;
			this.btnSearchPrtItemGrp.Click += new System.EventHandler(this.btnSearchPrtItemGrp_Click);
			// 
			// btnSearchPrtItemSet
			// 
			this.btnSearchPrtItemSet.Location = new System.Drawing.Point(8, 8);
			this.btnSearchPrtItemSet.Name = "btnSearchPrtItemSet";
			this.btnSearchPrtItemSet.Size = new System.Drawing.Size(128, 23);
			this.btnSearchPrtItemSet.TabIndex = 1;
			this.btnSearchPrtItemSet.Text = "SearchPrtItemSet";
			this.btnSearchPrtItemSet.UseVisualStyleBackColor = true;
			this.btnSearchPrtItemSet.Click += new System.EventHandler(this.btnSearchPrtItemSet_Click);
			// 
			// gridPrtItemSet
			// 
			this.gridPrtItemSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridPrtItemSet.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridPrtItemSet.Location = new System.Drawing.Point(0, 211);
			this.gridPrtItemSet.Name = "gridPrtItemSet";
			this.gridPrtItemSet.RowTemplate.Height = 21;
			this.gridPrtItemSet.Size = new System.Drawing.Size(722, 305);
			this.gridPrtItemSet.TabIndex = 2;
			// 
			// pnlPrtItemSet
			// 
			this.pnlPrtItemSet.Controls.Add(this.txtFreePrtPprItemGrpCd);
			this.pnlPrtItemSet.Controls.Add(this.btnSearchPrtItemSet);
			this.pnlPrtItemSet.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlPrtItemSet.Location = new System.Drawing.Point(0, 172);
			this.pnlPrtItemSet.Name = "pnlPrtItemSet";
			this.pnlPrtItemSet.Size = new System.Drawing.Size(722, 39);
			this.pnlPrtItemSet.TabIndex = 3;
			// 
			// txtFreePrtPprItemGrpCd
			// 
			this.txtFreePrtPprItemGrpCd.Location = new System.Drawing.Point(161, 10);
			this.txtFreePrtPprItemGrpCd.Name = "txtFreePrtPprItemGrpCd";
			this.txtFreePrtPprItemGrpCd.Size = new System.Drawing.Size(100, 19);
			this.txtFreePrtPprItemGrpCd.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(722, 516);
			this.Controls.Add(this.gridPrtItemSet);
			this.Controls.Add(this.pnlPrtItemSet);
			this.Controls.Add(this.gridPrtItemGrp);
			this.Controls.Add(this.pnlPrtItemGrp);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.gridPrtItemGrp)).EndInit();
			this.pnlPrtItemGrp.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridPrtItemSet)).EndInit();
			this.pnlPrtItemSet.ResumeLayout(false);
			this.pnlPrtItemSet.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gridPrtItemGrp;
		private System.Windows.Forms.Panel pnlPrtItemGrp;
		private System.Windows.Forms.Button btnSearchPrtItemSet;
		private System.Windows.Forms.Button btnSearchPrtItemGrp;
		private System.Windows.Forms.DataGridView gridPrtItemSet;
		private System.Windows.Forms.Panel pnlPrtItemSet;
		private System.Windows.Forms.TextBox txtFreePrtPprItemGrpCd;
	}
}

