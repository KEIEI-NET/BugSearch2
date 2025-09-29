namespace Broadleaf.Windows.Forms
{
	partial class SFANL08105UA
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Dispose
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
		#endregion

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SFANL08105UA ) );
            this.designer = new DataDynamics.ActiveReports.Design.Designer();
            this.LayoutIconList = new System.Windows.Forms.ImageList( this.components );
            this.toolTipManager = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager( this.components );
            this.ilARControlIcon = new System.Windows.Forms.ImageList( this.components );
            this.SuspendLayout();
            // 
            // designer
            // 
            this.designer.AllowDrop = true;
            this.designer.BackColor = System.Drawing.SystemColors.Control;
            this.designer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.designer.IsDirty = false;
            this.designer.Location = new System.Drawing.Point( 0, 0 );
            this.designer.LockControls = false;
            this.designer.Name = "designer";
            this.designer.PropertyGrid = null;
            this.designer.ReportTabsVisible = false;
            this.designer.ShowDataSourceIcon = false;
            this.designer.Size = new System.Drawing.Size( 792, 566 );
            this.designer.TabIndex = 0;
            this.designer.Toolbox = null;
            this.designer.ToolBoxItem = null;
            this.designer.SelectionChanged += new DataDynamics.ActiveReports.Design.SelectionChangedEventHandler( this.designer_SelectionChanged );
            this.designer.LayoutChanging += new DataDynamics.ActiveReports.Design.LayoutChangingEventHandler( this.designer_LayoutChanging );
            this.designer.DragOver += new System.Windows.Forms.DragEventHandler( this.designer_DragOver );
            this.designer.DragDrop += new System.Windows.Forms.DragEventHandler( this.designer_DragDrop );
            this.designer.LayoutChanged += new DataDynamics.ActiveReports.Design.LayoutChangedEventHandler( this.designer_LayoutChanged );
            // 
            // LayoutIconList
            // 
            this.LayoutIconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject( "LayoutIconList.ImageStream" )));
            this.LayoutIconList.TransparentColor = System.Drawing.Color.Transparent;
            this.LayoutIconList.Images.SetKeyName( 0, "AR_AlignGrid.ico" );
            this.LayoutIconList.Images.SetKeyName( 1, "AR_AlignLefts.ico" );
            this.LayoutIconList.Images.SetKeyName( 2, "AR_AlignCenters.ico" );
            this.LayoutIconList.Images.SetKeyName( 3, "AR_AlignRights.ico" );
            this.LayoutIconList.Images.SetKeyName( 4, "AR_AlignTops.ico" );
            this.LayoutIconList.Images.SetKeyName( 5, "AR_AlignMiddles.ico" );
            this.LayoutIconList.Images.SetKeyName( 6, "AR_AlignBottoms.ico" );
            this.LayoutIconList.Images.SetKeyName( 7, "AR_MakeSameWidth.ico" );
            this.LayoutIconList.Images.SetKeyName( 8, "AR_SizeGrid.ico" );
            this.LayoutIconList.Images.SetKeyName( 9, "AR_MakeSameHeight.ico" );
            this.LayoutIconList.Images.SetKeyName( 10, "AR_MakeSameSize.ico" );
            this.LayoutIconList.Images.SetKeyName( 11, "AR_MakeHorizSpaceEqual.ico" );
            this.LayoutIconList.Images.SetKeyName( 12, "AR_IncreaseHorizSpace.ico" );
            this.LayoutIconList.Images.SetKeyName( 13, "AR_DecreaseHorizSpace.ico" );
            this.LayoutIconList.Images.SetKeyName( 14, "AR_RemoveHorizSpace.ico" );
            this.LayoutIconList.Images.SetKeyName( 15, "AR_MakeVertSpaceEqual.ico" );
            this.LayoutIconList.Images.SetKeyName( 16, "AR_IncreaseVertSpace.ico" );
            this.LayoutIconList.Images.SetKeyName( 17, "AR_DecreaseVertSpace.ico" );
            this.LayoutIconList.Images.SetKeyName( 18, "AR_RemoveVertSpace.ico" );
            this.LayoutIconList.Images.SetKeyName( 19, "AR_CenterHoriz.ico" );
            this.LayoutIconList.Images.SetKeyName( 20, "AR_CenterVert.ico" );
            this.LayoutIconList.Images.SetKeyName( 21, "AR_BringFront.ico" );
            this.LayoutIconList.Images.SetKeyName( 22, "AR_SendBack.ico" );
            // 
            // toolTipManager
            // 
            this.toolTipManager.ContainingControl = this;
            // 
            // ilARControlIcon
            // 
            this.ilARControlIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject( "ilARControlIcon.ImageStream" )));
            this.ilARControlIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.ilARControlIcon.Images.SetKeyName( 0, "AR_Textbox" );
            this.ilARControlIcon.Images.SetKeyName( 1, "AR_Label" );
            this.ilARControlIcon.Images.SetKeyName( 2, "AR_Line" );
            this.ilARControlIcon.Images.SetKeyName( 3, "AR_Picture" );
            this.ilARControlIcon.Images.SetKeyName( 4, "AR_Shape" );
            this.ilARControlIcon.Images.SetKeyName( 5, "AR_Barcode" );
            // 
            // SFANL08105UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 15F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 792, 566 );
            this.Controls.Add( this.designer );
            this.Font = new System.Drawing.Font( "ＭＳ ゴシック", 11F );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Margin = new System.Windows.Forms.Padding( 4 );
            this.Name = "SFANL08105UA";
            this.Text = "自由帳票印字位置設定";
            this.Load += new System.EventHandler( this.SFANL08105UA_Load );
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.SFANL08105UA_FormClosed );
            this.ResumeLayout( false );

		}

		#endregion

		private DataDynamics.ActiveReports.Design.Designer designer;
		private System.Windows.Forms.ImageList LayoutIconList;
		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager toolTipManager;
        private System.Windows.Forms.ImageList ilARControlIcon;
	}
}