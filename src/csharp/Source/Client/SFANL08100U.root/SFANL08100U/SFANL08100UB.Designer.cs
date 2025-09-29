namespace Broadleaf.Windows.Forms
{
	partial class SFANL08100UB
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
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.Bind_DataSet = new System.Data.DataSet();
			this.dt = new System.Data.DataTable();
			this.Col1 = new System.Data.DataColumn();
			this.Col2 = new System.Data.DataColumn();
			this.Col3 = new System.Data.DataColumn();
			this.Col4 = new System.Data.DataColumn();
			this.Col5 = new System.Data.DataColumn();
			this.StartArgs = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AssemblyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TitleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ChildStartArgs = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView
			// 
			this.dataGridView.AutoGenerateColumns = false;
			this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StartArgs,
            this.AssemblyID,
            this.ClassName,
            this.TitleName,
            this.ChildStartArgs});
			this.dataGridView.DataMember = "dt";
			this.dataGridView.DataSource = this.Bind_DataSet;
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dataGridView.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.dataGridView.Location = new System.Drawing.Point(0, 0);
			this.dataGridView.MultiSelect = false;
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowTemplate.Height = 21;
			this.dataGridView.Size = new System.Drawing.Size(792, 573);
			this.dataGridView.TabIndex = 0;
			this.dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
			// 
			// Bind_DataSet
			// 
			this.Bind_DataSet.DataSetName = "NewDataSet";
			this.Bind_DataSet.RemotingFormat = System.Data.SerializationFormat.Binary;
			this.Bind_DataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.dt});
			// 
			// dt
			// 
			this.dt.Columns.AddRange(new System.Data.DataColumn[] {
            this.Col1,
            this.Col2,
            this.Col3,
            this.Col4,
            this.Col5});
			this.dt.RemotingFormat = System.Data.SerializationFormat.Binary;
			this.dt.TableName = "dt";
			// 
			// Col1
			// 
			this.Col1.Caption = "起動引数";
			this.Col1.ColumnName = "StartArgs";
			this.Col1.DefaultValue = "";
			// 
			// Col2
			// 
			this.Col2.Caption = "アセンブリID";
			this.Col2.ColumnName = "AssemblyID";
			this.Col2.DefaultValue = "";
			// 
			// Col3
			// 
			this.Col3.Caption = "クラス名";
			this.Col3.ColumnName = "ClassName";
			this.Col3.DefaultValue = "";
			// 
			// Col4
			// 
			this.Col4.Caption = "タイトル名称";
			this.Col4.ColumnName = "TitleName";
			this.Col4.DefaultValue = "";
			// 
			// Col5
			// 
			this.Col5.Caption = "子画面起動引数";
			this.Col5.ColumnName = "ChildStartArgs";
			this.Col5.DefaultValue = "";
			// 
			// StartArgs
			// 
			this.StartArgs.DataPropertyName = "StartArgs";
			this.StartArgs.HeaderText = "起動引数";
			this.StartArgs.Name = "StartArgs";
			// 
			// AssemblyID
			// 
			this.AssemblyID.DataPropertyName = "AssemblyID";
			this.AssemblyID.HeaderText = "アセンブリID";
			this.AssemblyID.Name = "AssemblyID";
			// 
			// ClassName
			// 
			this.ClassName.DataPropertyName = "ClassName";
			this.ClassName.HeaderText = "クラス名";
			this.ClassName.Name = "ClassName";
			// 
			// TitleName
			// 
			this.TitleName.DataPropertyName = "TitleName";
			this.TitleName.HeaderText = "タイトル名";
			this.TitleName.Name = "TitleName";
			// 
			// ChildStartArgs
			// 
			this.ChildStartArgs.DataPropertyName = "ChildStartArgs";
			this.ChildStartArgs.HeaderText = "子画面起動引数";
			this.ChildStartArgs.Name = "ChildStartArgs";
			// 
			// SFANL00000UB
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.Add(this.dataGridView);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "SFANL00000UB";
			this.Text = "SFANL00000UB";
			this.Load += new System.EventHandler(this.SFANL00000UB_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView;
		private System.Data.DataSet Bind_DataSet;
		private System.Data.DataTable dt;
		private System.Data.DataColumn Col1;
		private System.Data.DataColumn Col2;
		private System.Data.DataColumn Col3;
		private System.Data.DataColumn Col4;
		private System.Data.DataColumn Col5;
		private System.Windows.Forms.DataGridViewTextBoxColumn StartArgs;
		private System.Windows.Forms.DataGridViewTextBoxColumn AssemblyID;
		private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
		private System.Windows.Forms.DataGridViewTextBoxColumn TitleName;
		private System.Windows.Forms.DataGridViewTextBoxColumn ChildStartArgs;
	}
}