namespace Broadleaf.Windows.Forms
{
	partial class MAKHN04110UB
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
			Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Decision_ButtonTool");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("AllSelect_ButtonTool");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Back_ButtonTool");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Decision_ButtonTool");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Back_ButtonTool");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("AllSelect_ButtonTool");
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKHN04110UB));
			this.Main_UToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
			this.MAKHN04110UB_Fill_Panel = new System.Windows.Forms.Panel();
			this.SELECTGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this._MAKHN04110UB_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._MAKHN04110UB_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._MAKHN04110UB_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._MAKHN04110UB_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this.ColReSize_Timer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.Main_UToolbarsManager)).BeginInit();
			this.MAKHN04110UB_Fill_Panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SELECTGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// Main_UToolbarsManager
			// 
			this.Main_UToolbarsManager.DesignerFlags = 1;
			this.Main_UToolbarsManager.DockWithinContainer = this;
			this.Main_UToolbarsManager.ShowFullMenusDelay = 500;
			this.Main_UToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
			ultraToolbar1.DockedColumn = 0;
			ultraToolbar1.DockedRow = 0;
			ultraToolbar1.Text = "標準";
			ultraToolbar1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3});
			this.Main_UToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
			buttonTool4.SharedProps.Caption = "確定(&S)";
			buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool5.SharedProps.Caption = "戻る(&X)";
			buttonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool6.SharedProps.Caption = "全選択";
			buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			this.Main_UToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4,
            buttonTool5,
            buttonTool6});
			this.Main_UToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_UToolbarsManager_ToolClick);
			// 
			// MAKHN04110UB_Fill_Panel
			// 
			this.MAKHN04110UB_Fill_Panel.Controls.Add(this.SELECTGrid);
			this.MAKHN04110UB_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
			this.MAKHN04110UB_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MAKHN04110UB_Fill_Panel.Location = new System.Drawing.Point(0, 27);
			this.MAKHN04110UB_Fill_Panel.Name = "MAKHN04110UB_Fill_Panel";
			this.MAKHN04110UB_Fill_Panel.Size = new System.Drawing.Size(872, 333);
			this.MAKHN04110UB_Fill_Panel.TabIndex = 0;
			// 
			// SELECTGrid
			// 
			appearance1.BackColor = System.Drawing.Color.White;
			this.SELECTGrid.DisplayLayout.Appearance = appearance1;
			appearance2.BackColor = System.Drawing.Color.Transparent;
			this.SELECTGrid.DisplayLayout.Override.CardAreaAppearance = appearance2;
			appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
			appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
			appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance3.FontData.BoldAsString = "True";
			appearance3.FontData.Name = "Arial";
			appearance3.FontData.SizeInPoints = 10F;
			appearance3.ForeColor = System.Drawing.Color.White;
			appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			this.SELECTGrid.DisplayLayout.Override.HeaderAppearance = appearance3;
			appearance4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SELECTGrid.DisplayLayout.Override.RowAppearance = appearance4;
			appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
			appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
			appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.SELECTGrid.DisplayLayout.Override.RowSelectorAppearance = appearance5;
			appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
			appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
			appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.SELECTGrid.DisplayLayout.Override.SelectedRowAppearance = appearance6;
			this.SELECTGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SELECTGrid.Location = new System.Drawing.Point(0, 0);
			this.SELECTGrid.Name = "SELECTGrid";
			this.SELECTGrid.Size = new System.Drawing.Size(872, 333);
			this.SELECTGrid.TabIndex = 0;
			this.SELECTGrid.Click += new System.EventHandler(this.SELECTGrid_Click);
			this.SELECTGrid.DoubleClick += new System.EventHandler(this.SELECTGrid_DoubleClick);
			this.SELECTGrid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.SELECTGrid_InitializeLayout);
			this.SELECTGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SELECTGrid_KeyDown);
			this.SELECTGrid.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.SELECTGrid_CellChange);
			// 
			// _MAKHN04110UB_Toolbars_Dock_Area_Left
			// 
			this._MAKHN04110UB_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._MAKHN04110UB_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._MAKHN04110UB_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
			this._MAKHN04110UB_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
			this._MAKHN04110UB_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 27);
			this._MAKHN04110UB_Toolbars_Dock_Area_Left.Name = "_MAKHN04110UB_Toolbars_Dock_Area_Left";
			this._MAKHN04110UB_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 333);
			this._MAKHN04110UB_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_UToolbarsManager;
			// 
			// _MAKHN04110UB_Toolbars_Dock_Area_Right
			// 
			this._MAKHN04110UB_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._MAKHN04110UB_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._MAKHN04110UB_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
			this._MAKHN04110UB_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
			this._MAKHN04110UB_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(872, 27);
			this._MAKHN04110UB_Toolbars_Dock_Area_Right.Name = "_MAKHN04110UB_Toolbars_Dock_Area_Right";
			this._MAKHN04110UB_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 333);
			this._MAKHN04110UB_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_UToolbarsManager;
			// 
			// _MAKHN04110UB_Toolbars_Dock_Area_Top
			// 
			this._MAKHN04110UB_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._MAKHN04110UB_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._MAKHN04110UB_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
			this._MAKHN04110UB_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
			this._MAKHN04110UB_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
			this._MAKHN04110UB_Toolbars_Dock_Area_Top.Name = "_MAKHN04110UB_Toolbars_Dock_Area_Top";
			this._MAKHN04110UB_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(872, 27);
			this._MAKHN04110UB_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_UToolbarsManager;
			// 
			// _MAKHN04110UB_Toolbars_Dock_Area_Bottom
			// 
			this._MAKHN04110UB_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._MAKHN04110UB_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._MAKHN04110UB_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
			this._MAKHN04110UB_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
			this._MAKHN04110UB_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 360);
			this._MAKHN04110UB_Toolbars_Dock_Area_Bottom.Name = "_MAKHN04110UB_Toolbars_Dock_Area_Bottom";
			this._MAKHN04110UB_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(872, 0);
			this._MAKHN04110UB_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_UToolbarsManager;
			// 
			// ColReSize_Timer
			// 
			this.ColReSize_Timer.Interval = 1;
			this.ColReSize_Timer.Tick += new System.EventHandler(this.ColReSize_Timer_Tick);
			// 
			// MAKHN04110UB
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(872, 360);
			this.Controls.Add(this.MAKHN04110UB_Fill_Panel);
			this.Controls.Add(this._MAKHN04110UB_Toolbars_Dock_Area_Left);
			this.Controls.Add(this._MAKHN04110UB_Toolbars_Dock_Area_Right);
			this.Controls.Add(this._MAKHN04110UB_Toolbars_Dock_Area_Top);
			this.Controls.Add(this._MAKHN04110UB_Toolbars_Dock_Area_Bottom);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MAKHN04110UB";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "商品選択";
			this.Load += new System.EventHandler(this.MAKHN04110UB_Load);
			((System.ComponentModel.ISupportInitialize)(this.Main_UToolbarsManager)).EndInit();
			this.MAKHN04110UB_Fill_Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SELECTGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_UToolbarsManager;
		private System.Windows.Forms.Panel MAKHN04110UB_Fill_Panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKHN04110UB_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKHN04110UB_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKHN04110UB_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKHN04110UB_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinGrid.UltraGrid SELECTGrid;
		private System.Windows.Forms.Timer ColReSize_Timer;
	}
}