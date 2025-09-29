namespace Broadleaf.Windows.Forms
{
	partial class SFANL08140UB
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
			Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OK_Button");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OK_Button");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFANL08140UB));
			this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
			this.SFANL08140UB_Fill_Panel = new System.Windows.Forms.Panel();
			this.DmGuideSnt_ultraGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this._SFANL08140UB_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._SFANL08140UB_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._SFANL08140UB_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._SFANL08140UB_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
			this.SFANL08140UB_Fill_Panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DmGuideSnt_ultraGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// ultraToolbarsManager1
			// 
			this.ultraToolbarsManager1.DesignerFlags = 1;
			this.ultraToolbarsManager1.DockWithinContainer = this;
			this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
			this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
			ultraToolbar1.DockedColumn = 0;
			ultraToolbar1.DockedRow = 0;
			ultraToolbar1.Text = "UltraToolbar1";
			ultraToolbar1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1});
			this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
			buttonTool2.SharedProps.Caption = "確定(&S)";
			buttonTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2});
			this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
			// 
			// SFANL08140UB_Fill_Panel
			// 
			this.SFANL08140UB_Fill_Panel.Controls.Add(this.DmGuideSnt_ultraGrid);
			this.SFANL08140UB_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
			this.SFANL08140UB_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SFANL08140UB_Fill_Panel.Location = new System.Drawing.Point(0, 27);
			this.SFANL08140UB_Fill_Panel.Name = "SFANL08140UB_Fill_Panel";
			this.SFANL08140UB_Fill_Panel.Size = new System.Drawing.Size(536, 438);
			this.SFANL08140UB_Fill_Panel.TabIndex = 0;
			// 
			// DmGuideSnt_ultraGrid
			// 
			this.DmGuideSnt_ultraGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DmGuideSnt_ultraGrid.Location = new System.Drawing.Point(0, 0);
			this.DmGuideSnt_ultraGrid.Name = "DmGuideSnt_ultraGrid";
			this.DmGuideSnt_ultraGrid.Size = new System.Drawing.Size(536, 438);
			this.DmGuideSnt_ultraGrid.TabIndex = 2;
			this.DmGuideSnt_ultraGrid.DoubleClick += new System.EventHandler(this.DmGuideSnt_ultraGrid_DoubleClick);
			this.DmGuideSnt_ultraGrid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.DmGuideSnt_ultraGrid_InitializeLayout);
			this.DmGuideSnt_ultraGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DmGuideSnt_ultraGrid_KeyDown);
			this.DmGuideSnt_ultraGrid.AfterRowActivate += new System.EventHandler(this.DmGuideSnt_ultraGrid_AfterRowActivate);
			// 
			// _SFANL08140UB_Toolbars_Dock_Area_Left
			// 
			this._SFANL08140UB_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._SFANL08140UB_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._SFANL08140UB_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
			this._SFANL08140UB_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
			this._SFANL08140UB_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 27);
			this._SFANL08140UB_Toolbars_Dock_Area_Left.Name = "_SFANL08140UB_Toolbars_Dock_Area_Left";
			this._SFANL08140UB_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 438);
			this._SFANL08140UB_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _SFANL08140UB_Toolbars_Dock_Area_Right
			// 
			this._SFANL08140UB_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._SFANL08140UB_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._SFANL08140UB_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
			this._SFANL08140UB_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
			this._SFANL08140UB_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(536, 27);
			this._SFANL08140UB_Toolbars_Dock_Area_Right.Name = "_SFANL08140UB_Toolbars_Dock_Area_Right";
			this._SFANL08140UB_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 438);
			this._SFANL08140UB_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _SFANL08140UB_Toolbars_Dock_Area_Top
			// 
			this._SFANL08140UB_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._SFANL08140UB_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._SFANL08140UB_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
			this._SFANL08140UB_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
			this._SFANL08140UB_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
			this._SFANL08140UB_Toolbars_Dock_Area_Top.Name = "_SFANL08140UB_Toolbars_Dock_Area_Top";
			this._SFANL08140UB_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(536, 27);
			this._SFANL08140UB_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// _SFANL08140UB_Toolbars_Dock_Area_Bottom
			// 
			this._SFANL08140UB_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._SFANL08140UB_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._SFANL08140UB_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
			this._SFANL08140UB_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
			this._SFANL08140UB_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 465);
			this._SFANL08140UB_Toolbars_Dock_Area_Bottom.Name = "_SFANL08140UB_Toolbars_Dock_Area_Bottom";
			this._SFANL08140UB_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(536, 0);
			this._SFANL08140UB_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
			// 
			// Initial_Timer
			// 
			this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
			// 
			// SFANL08140UB
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(536, 465);
			this.ControlBox = false;
			this.Controls.Add(this.SFANL08140UB_Fill_Panel);
			this.Controls.Add(this._SFANL08140UB_Toolbars_Dock_Area_Left);
			this.Controls.Add(this._SFANL08140UB_Toolbars_Dock_Area_Right);
			this.Controls.Add(this._SFANL08140UB_Toolbars_Dock_Area_Top);
			this.Controls.Add(this._SFANL08140UB_Toolbars_Dock_Area_Bottom);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SFANL08140UB";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "案内文はがき選択ガイド";
			this.Load += new System.EventHandler(this.SFANL08140UB_Load);
			((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
			this.SFANL08140UB_Fill_Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DmGuideSnt_ultraGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private System.Windows.Forms.Panel SFANL08140UB_Fill_Panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFANL08140UB_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFANL08140UB_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFANL08140UB_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFANL08140UB_Toolbars_Dock_Area_Bottom;
		private System.Windows.Forms.Timer Initial_Timer;
		private Infragistics.Win.UltraWinGrid.UltraGrid DmGuideSnt_ultraGrid;
	}
}