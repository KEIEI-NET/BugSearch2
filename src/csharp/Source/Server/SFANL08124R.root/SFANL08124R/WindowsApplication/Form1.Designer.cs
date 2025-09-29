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
			this.txtOutputFormFileName = new System.Windows.Forms.TextBox();
			this.txtEnterpriseCode = new System.Windows.Forms.TextBox();
			this.lblEnterpriseCode = new System.Windows.Forms.Label();
			this.lblOutputFormFileName = new System.Windows.Forms.Label();
			this.btnWrite = new System.Windows.Forms.Button();
			this.btnReadFrePrtPSet = new System.Windows.Forms.Button();
			this.btnSearchFrePExCndD = new System.Windows.Forms.Button();
			this.gridFrePrtPSet = new System.Windows.Forms.DataGridView();
			this.gridFrePExCndD = new System.Windows.Forms.DataGridView();
			this.gridFrePprECnd = new System.Windows.Forms.DataGridView();
			this.lblUserPrtPprIdDerivNo = new System.Windows.Forms.Label();
			this.txtUserPrtPprIdDerivNo = new System.Windows.Forms.TextBox();
			this.btnNewRow1 = new System.Windows.Forms.Button();
			this.btnNewRow2 = new System.Windows.Forms.Button();
			this.btnGetLastUserPrtPprIdDerivNo = new System.Windows.Forms.Button();
			this.gridFrePprSrtO = new System.Windows.Forms.DataGridView();
			this.btnNewRow3 = new System.Windows.Forms.Button();
			this.btnDeleteFrePprSrtO = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.gridFrePrtPSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridFrePExCndD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridFrePprECnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridFrePprSrtO)).BeginInit();
			this.SuspendLayout();
			// 
			// txtOutputFormFileName
			// 
			this.txtOutputFormFileName.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txtOutputFormFileName.Location = new System.Drawing.Point(135, 33);
			this.txtOutputFormFileName.MaxLength = 30;
			this.txtOutputFormFileName.Name = "txtOutputFormFileName";
			this.txtOutputFormFileName.Size = new System.Drawing.Size(210, 19);
			this.txtOutputFormFileName.TabIndex = 2;
			this.txtOutputFormFileName.Leave += new System.EventHandler(this.ExtrCond_Leave);
			// 
			// txtEnterpriseCode
			// 
			this.txtEnterpriseCode.Enabled = false;
			this.txtEnterpriseCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txtEnterpriseCode.Location = new System.Drawing.Point(135, 10);
			this.txtEnterpriseCode.MaxLength = 16;
			this.txtEnterpriseCode.Name = "txtEnterpriseCode";
			this.txtEnterpriseCode.Size = new System.Drawing.Size(123, 19);
			this.txtEnterpriseCode.TabIndex = 1;
			// 
			// lblEnterpriseCode
			// 
			this.lblEnterpriseCode.Location = new System.Drawing.Point(8, 8);
			this.lblEnterpriseCode.Name = "lblEnterpriseCode";
			this.lblEnterpriseCode.Size = new System.Drawing.Size(114, 23);
			this.lblEnterpriseCode.TabIndex = 4;
			this.lblEnterpriseCode.Text = "EnterpriseCode";
			this.lblEnterpriseCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblOutputFormFileName
			// 
			this.lblOutputFormFileName.Location = new System.Drawing.Point(8, 31);
			this.lblOutputFormFileName.Name = "lblOutputFormFileName";
			this.lblOutputFormFileName.Size = new System.Drawing.Size(114, 23);
			this.lblOutputFormFileName.TabIndex = 3;
			this.lblOutputFormFileName.Text = "OutputFormFileName";
			this.lblOutputFormFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnWrite
			// 
			this.btnWrite.Enabled = false;
			this.btnWrite.Location = new System.Drawing.Point(515, 110);
			this.btnWrite.Name = "btnWrite";
			this.btnWrite.Size = new System.Drawing.Size(123, 23);
			this.btnWrite.TabIndex = 5;
			this.btnWrite.Text = "Write";
			this.btnWrite.UseVisualStyleBackColor = true;
			this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
			// 
			// btnReadFrePrtPSet
			// 
			this.btnReadFrePrtPSet.Enabled = false;
			this.btnReadFrePrtPSet.Location = new System.Drawing.Point(515, 81);
			this.btnReadFrePrtPSet.Name = "btnReadFrePrtPSet";
			this.btnReadFrePrtPSet.Size = new System.Drawing.Size(123, 23);
			this.btnReadFrePrtPSet.TabIndex = 4;
			this.btnReadFrePrtPSet.Text = "ReadFrePrtPSet";
			this.btnReadFrePrtPSet.UseVisualStyleBackColor = true;
			this.btnReadFrePrtPSet.Click += new System.EventHandler(this.btnReadFrePrtPSet_Click);
			// 
			// btnSearchFrePExCndD
			// 
			this.btnSearchFrePExCndD.Location = new System.Drawing.Point(515, 488);
			this.btnSearchFrePExCndD.Name = "btnSearchFrePExCndD";
			this.btnSearchFrePExCndD.Size = new System.Drawing.Size(123, 23);
			this.btnSearchFrePExCndD.TabIndex = 8;
			this.btnSearchFrePExCndD.Text = "SearchFrePExCndD";
			this.btnSearchFrePExCndD.UseVisualStyleBackColor = true;
			this.btnSearchFrePExCndD.Click += new System.EventHandler(this.btnSearchFrePExCndD_Click);
			// 
			// gridFrePrtPSet
			// 
			this.gridFrePrtPSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridFrePrtPSet.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.gridFrePrtPSet.Location = new System.Drawing.Point(10, 81);
			this.gridFrePrtPSet.Name = "gridFrePrtPSet";
			this.gridFrePrtPSet.RowTemplate.Height = 21;
			this.gridFrePrtPSet.Size = new System.Drawing.Size(499, 124);
			this.gridFrePrtPSet.TabIndex = 10;
			// 
			// gridFrePExCndD
			// 
			this.gridFrePExCndD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridFrePExCndD.Location = new System.Drawing.Point(10, 488);
			this.gridFrePExCndD.Name = "gridFrePExCndD";
			this.gridFrePExCndD.ReadOnly = true;
			this.gridFrePExCndD.RowTemplate.Height = 21;
			this.gridFrePExCndD.Size = new System.Drawing.Size(499, 124);
			this.gridFrePExCndD.TabIndex = 12;
			// 
			// gridFrePprECnd
			// 
			this.gridFrePprECnd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridFrePprECnd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.gridFrePprECnd.Location = new System.Drawing.Point(10, 211);
			this.gridFrePprECnd.Name = "gridFrePprECnd";
			this.gridFrePprECnd.RowTemplate.Height = 21;
			this.gridFrePprECnd.Size = new System.Drawing.Size(499, 124);
			this.gridFrePprECnd.TabIndex = 11;
			// 
			// lblUserPrtPprIdDerivNo
			// 
			this.lblUserPrtPprIdDerivNo.Location = new System.Drawing.Point(8, 54);
			this.lblUserPrtPprIdDerivNo.Name = "lblUserPrtPprIdDerivNo";
			this.lblUserPrtPprIdDerivNo.Size = new System.Drawing.Size(114, 23);
			this.lblUserPrtPprIdDerivNo.TabIndex = 3;
			this.lblUserPrtPprIdDerivNo.Text = "UserPrtPprIdDerivNo";
			this.lblUserPrtPprIdDerivNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtUserPrtPprIdDerivNo
			// 
			this.txtUserPrtPprIdDerivNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.txtUserPrtPprIdDerivNo.Location = new System.Drawing.Point(135, 56);
			this.txtUserPrtPprIdDerivNo.MaxLength = 3;
			this.txtUserPrtPprIdDerivNo.Name = "txtUserPrtPprIdDerivNo";
			this.txtUserPrtPprIdDerivNo.Size = new System.Drawing.Size(210, 19);
			this.txtUserPrtPprIdDerivNo.TabIndex = 3;
			this.txtUserPrtPprIdDerivNo.Leave += new System.EventHandler(this.ExtrCond_Leave);
			// 
			// btnNewRow1
			// 
			this.btnNewRow1.Enabled = false;
			this.btnNewRow1.Location = new System.Drawing.Point(515, 182);
			this.btnNewRow1.Name = "btnNewRow1";
			this.btnNewRow1.Size = new System.Drawing.Size(123, 23);
			this.btnNewRow1.TabIndex = 6;
			this.btnNewRow1.Text = "NewRow";
			this.btnNewRow1.UseVisualStyleBackColor = true;
			this.btnNewRow1.Click += new System.EventHandler(this.btnNewRow1_Click);
			// 
			// btnNewRow2
			// 
			this.btnNewRow2.Enabled = false;
			this.btnNewRow2.Location = new System.Drawing.Point(515, 312);
			this.btnNewRow2.Name = "btnNewRow2";
			this.btnNewRow2.Size = new System.Drawing.Size(123, 23);
			this.btnNewRow2.TabIndex = 7;
			this.btnNewRow2.Text = "NewRow";
			this.btnNewRow2.UseVisualStyleBackColor = true;
			this.btnNewRow2.Click += new System.EventHandler(this.btnNewRow2_Click);
			// 
			// btnGetLastUserPrtPprIdDerivNo
			// 
			this.btnGetLastUserPrtPprIdDerivNo.Location = new System.Drawing.Point(474, 8);
			this.btnGetLastUserPrtPprIdDerivNo.Name = "btnGetLastUserPrtPprIdDerivNo";
			this.btnGetLastUserPrtPprIdDerivNo.Size = new System.Drawing.Size(164, 23);
			this.btnGetLastUserPrtPprIdDerivNo.TabIndex = 13;
			this.btnGetLastUserPrtPprIdDerivNo.Text = "GetLastUserPrtPprIdDerivNo";
			this.btnGetLastUserPrtPprIdDerivNo.UseVisualStyleBackColor = true;
			this.btnGetLastUserPrtPprIdDerivNo.Click += new System.EventHandler(this.btnGetLastUserPrtPprIdDerivNo_Click);
			// 
			// gridFrePprSrtO
			// 
			this.gridFrePprSrtO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridFrePprSrtO.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.gridFrePprSrtO.Location = new System.Drawing.Point(10, 341);
			this.gridFrePprSrtO.Name = "gridFrePprSrtO";
			this.gridFrePprSrtO.RowTemplate.Height = 21;
			this.gridFrePprSrtO.Size = new System.Drawing.Size(499, 124);
			this.gridFrePprSrtO.TabIndex = 14;
			this.gridFrePprSrtO.SelectionChanged += new System.EventHandler(this.gridFrePprSrtO_SelectionChanged);
			// 
			// btnNewRow3
			// 
			this.btnNewRow3.Enabled = false;
			this.btnNewRow3.Location = new System.Drawing.Point(515, 442);
			this.btnNewRow3.Name = "btnNewRow3";
			this.btnNewRow3.Size = new System.Drawing.Size(123, 23);
			this.btnNewRow3.TabIndex = 15;
			this.btnNewRow3.Text = "NewRow";
			this.btnNewRow3.UseVisualStyleBackColor = true;
			this.btnNewRow3.Click += new System.EventHandler(this.btnNewRow3_Click);
			// 
			// btnDeleteFrePprSrtO
			// 
			this.btnDeleteFrePprSrtO.Enabled = false;
			this.btnDeleteFrePprSrtO.Location = new System.Drawing.Point(515, 413);
			this.btnDeleteFrePprSrtO.Name = "btnDeleteFrePprSrtO";
			this.btnDeleteFrePprSrtO.Size = new System.Drawing.Size(123, 23);
			this.btnDeleteFrePprSrtO.TabIndex = 16;
			this.btnDeleteFrePprSrtO.Text = "DeleteFrePprSrtO";
			this.btnDeleteFrePprSrtO.UseVisualStyleBackColor = true;
			this.btnDeleteFrePprSrtO.Click += new System.EventHandler(this.btnDeleteFrePprSrtO_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(643, 618);
			this.Controls.Add(this.btnDeleteFrePprSrtO);
			this.Controls.Add(this.btnNewRow3);
			this.Controls.Add(this.gridFrePprSrtO);
			this.Controls.Add(this.btnGetLastUserPrtPprIdDerivNo);
			this.Controls.Add(this.btnNewRow2);
			this.Controls.Add(this.btnNewRow1);
			this.Controls.Add(this.btnWrite);
			this.Controls.Add(this.txtUserPrtPprIdDerivNo);
			this.Controls.Add(this.txtOutputFormFileName);
			this.Controls.Add(this.gridFrePprECnd);
			this.Controls.Add(this.txtEnterpriseCode);
			this.Controls.Add(this.gridFrePExCndD);
			this.Controls.Add(this.lblEnterpriseCode);
			this.Controls.Add(this.lblUserPrtPprIdDerivNo);
			this.Controls.Add(this.lblOutputFormFileName);
			this.Controls.Add(this.gridFrePrtPSet);
			this.Controls.Add(this.btnReadFrePrtPSet);
			this.Controls.Add(this.btnSearchFrePExCndD);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridFrePrtPSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridFrePExCndD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridFrePprECnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridFrePprSrtO)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView gridFrePrtPSet;
		private System.Windows.Forms.Button btnWrite;
		private System.Windows.Forms.Button btnReadFrePrtPSet;
		private System.Windows.Forms.Button btnSearchFrePExCndD;
		private System.Windows.Forms.TextBox txtEnterpriseCode;
		private System.Windows.Forms.Label lblEnterpriseCode;
		private System.Windows.Forms.TextBox txtOutputFormFileName;
		private System.Windows.Forms.Label lblOutputFormFileName;
		private System.Windows.Forms.DataGridView gridFrePExCndD;
		private System.Windows.Forms.DataGridView gridFrePprECnd;
		private System.Windows.Forms.Label lblUserPrtPprIdDerivNo;
		private System.Windows.Forms.TextBox txtUserPrtPprIdDerivNo;
		private System.Windows.Forms.Button btnNewRow1;
		private System.Windows.Forms.Button btnNewRow2;
		private System.Windows.Forms.Button btnGetLastUserPrtPprIdDerivNo;
		private System.Windows.Forms.DataGridView gridFrePprSrtO;
		private System.Windows.Forms.Button btnNewRow3;
		private System.Windows.Forms.Button btnDeleteFrePprSrtO;
	}
}

