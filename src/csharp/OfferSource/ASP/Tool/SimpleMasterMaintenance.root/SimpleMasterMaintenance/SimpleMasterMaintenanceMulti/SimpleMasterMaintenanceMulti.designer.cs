namespace Broadleaf.Windows.Forms
{
	partial class SimpleMasterMaintenanceMulti
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) ) {
				components.Dispose();

				if( this._editForm != null ) {
					if( ! this._editForm.IsDisposed ) {
						if( this._editForm.Visible ) {
							ISimpleMasterMaintenanceMulti iSimpleMasterMaintenanceMulti = this._editForm as ISimpleMasterMaintenanceMulti;
							if( iSimpleMasterMaintenanceMulti != null ) {
								iSimpleMasterMaintenanceMulti.CanClose = true;
							}
							this._editForm.Close();
						}
						if( ! this._editForm.IsDisposed ) {
							this._editForm.Dispose();
						}
					}
				}
			}
			base.Dispose( disposing );
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SimpleMasterMaintenanceMulti ) );
			this.Main_toolStripContainer = new System.Windows.Forms.ToolStripContainer();
			this.SearchData_dataGridView = new System.Windows.Forms.DataGridView();
			this.Main_menuStrip = new System.Windows.Forms.MenuStrip();
			this.File_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Exit_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Edit_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewData_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FixData_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DelData_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Tool_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Standard_toolStrip = new System.Windows.Forms.ToolStrip();
			this.Exit_toolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.NewData_toolStripButton = new System.Windows.Forms.ToolStripButton();
			this.FixData_toolStripButton = new System.Windows.Forms.ToolStripButton();
			this.DelData_toolStripButton = new System.Windows.Forms.ToolStripButton();
			this.Main_statusStrip = new System.Windows.Forms.StatusStrip();
			this.Main_toolStripContainer.ContentPanel.SuspendLayout();
			this.Main_toolStripContainer.TopToolStripPanel.SuspendLayout();
			this.Main_toolStripContainer.SuspendLayout();
			( ( System.ComponentModel.ISupportInitialize )( this.SearchData_dataGridView ) ).BeginInit();
			this.Main_menuStrip.SuspendLayout();
			this.Standard_toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// Main_toolStripContainer
			// 
			// 
			// Main_toolStripContainer.ContentPanel
			// 
			this.Main_toolStripContainer.ContentPanel.Controls.Add( this.SearchData_dataGridView );
			this.Main_toolStripContainer.ContentPanel.Size = new System.Drawing.Size( 632, 375 );
			this.Main_toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Main_toolStripContainer.Location = new System.Drawing.Point( 0, 0 );
			this.Main_toolStripContainer.Name = "Main_toolStripContainer";
			this.Main_toolStripContainer.Size = new System.Drawing.Size( 632, 424 );
			this.Main_toolStripContainer.TabIndex = 0;
			this.Main_toolStripContainer.Text = "toolStripContainer1";
			// 
			// Main_toolStripContainer.TopToolStripPanel
			// 
			this.Main_toolStripContainer.TopToolStripPanel.Controls.Add( this.Main_menuStrip );
			this.Main_toolStripContainer.TopToolStripPanel.Controls.Add( this.Standard_toolStrip );
			// 
			// SearchData_dataGridView
			// 
			this.SearchData_dataGridView.AllowUserToAddRows = false;
			this.SearchData_dataGridView.AllowUserToDeleteRows = false;
			this.SearchData_dataGridView.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb( ( ( int )( ( ( byte )( 247 ) ) ) ), ( ( int )( ( ( byte )( 227 ) ) ) ), ( ( int )( ( ( byte )( 156 ) ) ) ) );
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
			this.SearchData_dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb( ( ( int )( ( ( byte )( 7 ) ) ) ), ( ( int )( ( ( byte )( 59 ) ) ) ), ( ( int )( ( ( byte )( 150 ) ) ) ) );
			dataGridViewCellStyle2.Font = new System.Drawing.Font( "MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 128 ) ) );
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb( ( ( int )( ( ( byte )( 7 ) ) ) ), ( ( int )( ( ( byte )( 59 ) ) ) ), ( ( int )( ( ( byte )( 150 ) ) ) ) );
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.SearchData_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
			dataGridViewCellStyle3.Font = new System.Drawing.Font( "MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 128 ) ) );
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb( ( ( int )( ( ( byte )( 247 ) ) ) ), ( ( int )( ( ( byte )( 227 ) ) ) ), ( ( int )( ( ( byte )( 156 ) ) ) ) );
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.SearchData_dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
			this.SearchData_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SearchData_dataGridView.EnableHeadersVisualStyles = false;
			this.SearchData_dataGridView.GridColor = System.Drawing.Color.FromArgb( ( ( int )( ( ( byte )( 1 ) ) ) ), ( ( int )( ( ( byte )( 68 ) ) ) ), ( ( int )( ( ( byte )( 208 ) ) ) ) );
			this.SearchData_dataGridView.Location = new System.Drawing.Point( 0, 0 );
			this.SearchData_dataGridView.MultiSelect = false;
			this.SearchData_dataGridView.Name = "SearchData_dataGridView";
			this.SearchData_dataGridView.ReadOnly = true;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb( ( ( int )( ( ( byte )( 7 ) ) ) ), ( ( int )( ( ( byte )( 59 ) ) ) ), ( ( int )( ( ( byte )( 150 ) ) ) ) );
			dataGridViewCellStyle4.Font = new System.Drawing.Font( "MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 128 ) ) );
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb( ( ( int )( ( ( byte )( 7 ) ) ) ), ( ( int )( ( ( byte )( 59 ) ) ) ), ( ( int )( ( ( byte )( 150 ) ) ) ) );
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.SearchData_dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb( ( ( int )( ( ( byte )( 247 ) ) ) ), ( ( int )( ( ( byte )( 227 ) ) ) ), ( ( int )( ( ( byte )( 156 ) ) ) ) );
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
			this.SearchData_dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
			this.SearchData_dataGridView.RowTemplate.Height = 21;
			this.SearchData_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.SearchData_dataGridView.Size = new System.Drawing.Size( 632, 375 );
			this.SearchData_dataGridView.TabIndex = 0;
			this.SearchData_dataGridView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler( this.PgMulcasGd_dataGridView_MouseDoubleClick );
			// 
			// Main_menuStrip
			// 
			this.Main_menuStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.Main_menuStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.File_toolStripMenuItem,
            this.Edit_toolStripMenuItem,
            this.Tool_toolStripMenuItem} );
			this.Main_menuStrip.Location = new System.Drawing.Point( 0, 0 );
			this.Main_menuStrip.Name = "Main_menuStrip";
			this.Main_menuStrip.Size = new System.Drawing.Size( 632, 24 );
			this.Main_menuStrip.TabIndex = 0;
			this.Main_menuStrip.Text = "menuStrip1";
			// 
			// File_toolStripMenuItem
			// 
			this.File_toolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.Exit_toolStripMenuItem} );
			this.File_toolStripMenuItem.Name = "File_toolStripMenuItem";
			this.File_toolStripMenuItem.Size = new System.Drawing.Size( 66, 20 );
			this.File_toolStripMenuItem.Text = "ファイル(&F)";
			// 
			// Exit_toolStripMenuItem
			// 
			this.Exit_toolStripMenuItem.Image = ( ( System.Drawing.Image )( resources.GetObject( "Exit_toolStripMenuItem.Image" ) ) );
			this.Exit_toolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
			this.Exit_toolStripMenuItem.Name = "Exit_toolStripMenuItem";
			this.Exit_toolStripMenuItem.Size = new System.Drawing.Size( 116, 22 );
			this.Exit_toolStripMenuItem.Text = "閉じる(&C)";
			this.Exit_toolStripMenuItem.Click += new System.EventHandler( this.Exit_toolStripMenuItem_Click );
			// 
			// Edit_toolStripMenuItem
			// 
			this.Edit_toolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.NewData_toolStripMenuItem,
            this.FixData_toolStripMenuItem,
            this.DelData_toolStripMenuItem} );
			this.Edit_toolStripMenuItem.Name = "Edit_toolStripMenuItem";
			this.Edit_toolStripMenuItem.Size = new System.Drawing.Size( 56, 20 );
			this.Edit_toolStripMenuItem.Text = "編集(&E)";
			// 
			// NewData_toolStripMenuItem
			// 
			this.NewData_toolStripMenuItem.Image = ( ( System.Drawing.Image )( resources.GetObject( "NewData_toolStripMenuItem.Image" ) ) );
			this.NewData_toolStripMenuItem.Name = "NewData_toolStripMenuItem";
			this.NewData_toolStripMenuItem.Size = new System.Drawing.Size( 134, 22 );
			this.NewData_toolStripMenuItem.Text = "新規追加(&N)";
			this.NewData_toolStripMenuItem.Click += new System.EventHandler( this.NewData_toolStripMenuItem_Click );
			// 
			// FixData_toolStripMenuItem
			// 
			this.FixData_toolStripMenuItem.Image = ( ( System.Drawing.Image )( resources.GetObject( "FixData_toolStripMenuItem.Image" ) ) );
			this.FixData_toolStripMenuItem.Name = "FixData_toolStripMenuItem";
			this.FixData_toolStripMenuItem.Size = new System.Drawing.Size( 134, 22 );
			this.FixData_toolStripMenuItem.Text = "修正(&F)";
			this.FixData_toolStripMenuItem.Click += new System.EventHandler( this.FixData_toolStripMenuItem_Click );
			// 
			// DelData_toolStripMenuItem
			// 
			this.DelData_toolStripMenuItem.Image = ( ( System.Drawing.Image )( resources.GetObject( "DelData_toolStripMenuItem.Image" ) ) );
			this.DelData_toolStripMenuItem.Name = "DelData_toolStripMenuItem";
			this.DelData_toolStripMenuItem.Size = new System.Drawing.Size( 134, 22 );
			this.DelData_toolStripMenuItem.Text = "削除(&D)";
			this.DelData_toolStripMenuItem.Click += new System.EventHandler( this.DelData_toolStripMenuItem_Click );
			// 
			// Tool_toolStripMenuItem
			// 
			this.Tool_toolStripMenuItem.Name = "Tool_toolStripMenuItem";
			this.Tool_toolStripMenuItem.Size = new System.Drawing.Size( 61, 20 );
			this.Tool_toolStripMenuItem.Text = "ツール(&T)";
			// 
			// Standard_toolStrip
			// 
			this.Standard_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.Standard_toolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.Exit_toolStripButton,
            this.toolStripSeparator1,
            this.NewData_toolStripButton,
            this.FixData_toolStripButton,
            this.DelData_toolStripButton} );
			this.Standard_toolStrip.Location = new System.Drawing.Point( 3, 24 );
			this.Standard_toolStrip.Name = "Standard_toolStrip";
			this.Standard_toolStrip.Size = new System.Drawing.Size( 306, 25 );
			this.Standard_toolStrip.TabIndex = 1;
			this.Standard_toolStrip.Text = "標準";
			// 
			// Exit_toolStripButton
			// 
			this.Exit_toolStripButton.Image = ( ( System.Drawing.Image )( resources.GetObject( "Exit_toolStripButton.Image" ) ) );
			this.Exit_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Exit_toolStripButton.Name = "Exit_toolStripButton";
			this.Exit_toolStripButton.Size = new System.Drawing.Size( 70, 22 );
			this.Exit_toolStripButton.Text = "閉じる(&X)";
			this.Exit_toolStripButton.Click += new System.EventHandler( this.Exit_toolStripMenuItem_Click );
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size( 6, 25 );
			// 
			// NewData_toolStripButton
			// 
			this.NewData_toolStripButton.Image = ( ( System.Drawing.Image )( resources.GetObject( "NewData_toolStripButton.Image" ) ) );
			this.NewData_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.NewData_toolStripButton.Name = "NewData_toolStripButton";
			this.NewData_toolStripButton.Size = new System.Drawing.Size( 89, 22 );
			this.NewData_toolStripButton.Text = "新規追加(&N)";
			this.NewData_toolStripButton.Click += new System.EventHandler( this.NewData_toolStripMenuItem_Click );
			// 
			// FixData_toolStripButton
			// 
			this.FixData_toolStripButton.Image = ( ( System.Drawing.Image )( resources.GetObject( "FixData_toolStripButton.Image" ) ) );
			this.FixData_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.FixData_toolStripButton.Name = "FixData_toolStripButton";
			this.FixData_toolStripButton.Size = new System.Drawing.Size( 64, 22 );
			this.FixData_toolStripButton.Text = "修正(&F)";
			this.FixData_toolStripButton.Click += new System.EventHandler( this.FixData_toolStripMenuItem_Click );
			// 
			// DelData_toolStripButton
			// 
			this.DelData_toolStripButton.Image = ( ( System.Drawing.Image )( resources.GetObject( "DelData_toolStripButton.Image" ) ) );
			this.DelData_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DelData_toolStripButton.Name = "DelData_toolStripButton";
			this.DelData_toolStripButton.Size = new System.Drawing.Size( 65, 22 );
			this.DelData_toolStripButton.Text = "削除(&D)";
			this.DelData_toolStripButton.Click += new System.EventHandler( this.DelData_toolStripMenuItem_Click );
			// 
			// Main_statusStrip
			// 
			this.Main_statusStrip.Location = new System.Drawing.Point( 0, 424 );
			this.Main_statusStrip.Name = "Main_statusStrip";
			this.Main_statusStrip.Size = new System.Drawing.Size( 632, 22 );
			this.Main_statusStrip.TabIndex = 1;
			this.Main_statusStrip.Text = "statusStrip1";
			// 
			// SimpleMasterMaintenanceMulti
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 632, 446 );
			this.Controls.Add( this.Main_toolStripContainer );
			this.Controls.Add( this.Main_statusStrip );
			this.MainMenuStrip = this.Main_menuStrip;
			this.Name = "SimpleMasterMaintenanceMulti";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "簡易マスタメンテナンス";
			this.Load += new System.EventHandler( this.SimpleMasterMaintenanceMulti_Load );
			this.Main_toolStripContainer.ContentPanel.ResumeLayout( false );
			this.Main_toolStripContainer.TopToolStripPanel.ResumeLayout( false );
			this.Main_toolStripContainer.TopToolStripPanel.PerformLayout();
			this.Main_toolStripContainer.ResumeLayout( false );
			this.Main_toolStripContainer.PerformLayout();
			( ( System.ComponentModel.ISupportInitialize )( this.SearchData_dataGridView ) ).EndInit();
			this.Main_menuStrip.ResumeLayout( false );
			this.Main_menuStrip.PerformLayout();
			this.Standard_toolStrip.ResumeLayout( false );
			this.Standard_toolStrip.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripContainer Main_toolStripContainer;
		private System.Windows.Forms.DataGridView SearchData_dataGridView;
		private System.Windows.Forms.StatusStrip Main_statusStrip;
		private System.Windows.Forms.MenuStrip Main_menuStrip;
		private System.Windows.Forms.ToolStripMenuItem File_toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Exit_toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Edit_toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem NewData_toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FixData_toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem DelData_toolStripMenuItem;
		private System.Windows.Forms.ToolStrip Standard_toolStrip;
		private System.Windows.Forms.ToolStripButton Exit_toolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton NewData_toolStripButton;
		private System.Windows.Forms.ToolStripButton FixData_toolStripButton;
		private System.Windows.Forms.ToolStripButton DelData_toolStripButton;
		private System.Windows.Forms.ToolStripMenuItem Tool_toolStripMenuItem;
	}
}