namespace Broadleaf.Windows.Forms
{
	partial class MAZAI04117U
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Select");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Back");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_SearchChange");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Select");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Back");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_SearchChange");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAZAI04117U));
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.ColReSize_Timer = new System.Windows.Forms.Timer(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.uGrid_SearchResult = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this._MAZAI04117U_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_UToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._MAZAI04117U_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAZAI04117U_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAZAI04117U_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.uiMemInput1 = new Broadleaf.Library.Windows.Forms.UiMemInput(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_SearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_UToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // ColReSize_Timer
            // 
            this.ColReSize_Timer.Interval = 1;
            this.ColReSize_Timer.Tick += new System.EventHandler(this.ColReSize_Timer_Tick);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // uGrid_SearchResult
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            this.uGrid_SearchResult.DisplayLayout.Appearance = appearance1;
            this.uGrid_SearchResult.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.uGrid_SearchResult.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.WithinBand;
            this.uGrid_SearchResult.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.uGrid_SearchResult.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.FontData.BoldAsString = "True";
            appearance3.FontData.Name = "Arial";
            appearance3.FontData.SizeInPoints = 10F;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_SearchResult.DisplayLayout.Override.HeaderAppearance = appearance3;
            appearance4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uGrid_SearchResult.DisplayLayout.Override.RowAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_SearchResult.DisplayLayout.Override.RowSelectorAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_SearchResult.DisplayLayout.Override.SelectedRowAppearance = appearance6;
            this.uGrid_SearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGrid_SearchResult.Location = new System.Drawing.Point(0, 28);
            this.uGrid_SearchResult.Name = "uGrid_SearchResult";
            this.uGrid_SearchResult.Size = new System.Drawing.Size(692, 328);
            this.uGrid_SearchResult.TabIndex = 1006;
            this.uGrid_SearchResult.Click += new System.EventHandler(this.uGrid_SearchResult_Click);
            this.uGrid_SearchResult.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_SearchResult_InitializeLayout);
            this.uGrid_SearchResult.DoubleClick += new System.EventHandler(this.uGrid_SearchResult_DoubleClick);
            this.uGrid_SearchResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uGrid_SearchResult_KeyDown);
            // 
            // _MAZAI04117U_Toolbars_Dock_Area_Left
            // 
            this._MAZAI04117U_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAZAI04117U_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAZAI04117U_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._MAZAI04117U_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAZAI04117U_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 28);
            this._MAZAI04117U_Toolbars_Dock_Area_Left.Name = "_MAZAI04117U_Toolbars_Dock_Area_Left";
            this._MAZAI04117U_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 328);
            this._MAZAI04117U_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_UToolbarsManager;
            // 
            // Main_UToolbarsManager
            // 
            this.Main_UToolbarsManager.AlwaysShowMenusExpanded = Infragistics.Win.DefaultableBoolean.False;
            this.Main_UToolbarsManager.DesignerFlags = 1;
            this.Main_UToolbarsManager.DockWithinContainer = this;
            this.Main_UToolbarsManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.Main_UToolbarsManager.ShowFullMenusDelay = 500;
            this.Main_UToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3});
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Text = "UltraToolbar1";
            this.Main_UToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            buttonTool4.SharedProps.Caption = "選択(&S)";
            buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool5.SharedProps.Caption = "戻る(&X)";
            buttonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool6.SharedProps.Caption = "拠点切替(F12)";
            buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool6.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F12;
            this.Main_UToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4,
            buttonTool5,
            buttonTool6});
            this.Main_UToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_UToolbarsManager_ToolClick);
            // 
            // _MAZAI04117U_Toolbars_Dock_Area_Right
            // 
            this._MAZAI04117U_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAZAI04117U_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAZAI04117U_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._MAZAI04117U_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAZAI04117U_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(692, 28);
            this._MAZAI04117U_Toolbars_Dock_Area_Right.Name = "_MAZAI04117U_Toolbars_Dock_Area_Right";
            this._MAZAI04117U_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 328);
            this._MAZAI04117U_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_UToolbarsManager;
            // 
            // _MAZAI04117U_Toolbars_Dock_Area_Top
            // 
            this._MAZAI04117U_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAZAI04117U_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAZAI04117U_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._MAZAI04117U_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAZAI04117U_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._MAZAI04117U_Toolbars_Dock_Area_Top.Name = "_MAZAI04117U_Toolbars_Dock_Area_Top";
            this._MAZAI04117U_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(692, 28);
            this._MAZAI04117U_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_UToolbarsManager;
            // 
            // _MAZAI04117U_Toolbars_Dock_Area_Bottom
            // 
            this._MAZAI04117U_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAZAI04117U_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAZAI04117U_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._MAZAI04117U_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAZAI04117U_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 356);
            this._MAZAI04117U_Toolbars_Dock_Area_Bottom.Name = "_MAZAI04117U_Toolbars_Dock_Area_Bottom";
            this._MAZAI04117U_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(692, 0);
            this._MAZAI04117U_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_UToolbarsManager;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Enabled = false;
            this.ultraLabel2.Location = new System.Drawing.Point(124, 34);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel2.TabIndex = 1013;
            this.ultraLabel2.Visible = false;
            // 
            // uiMemInput1
            // 
            this.uiMemInput1.OwnerForm = this;
            this.uiMemInput1.ReadOnLoad = false;
            // 
            // MAZAI04117U
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 356);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.uGrid_SearchResult);
            this.Controls.Add(this._MAZAI04117U_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._MAZAI04117U_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._MAZAI04117U_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._MAZAI04117U_Toolbars_Dock_Area_Bottom);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MAZAI04117U";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "在庫品倉庫検索";
            this.Load += new System.EventHandler(this.MAZAI04117U_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MAZAI04117U_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_SearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_UToolbarsManager)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_UToolbarsManager;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAZAI04117U_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAZAI04117U_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAZAI04117U_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAZAI04117U_Toolbars_Dock_Area_Bottom;
        private System.Windows.Forms.Timer Initial_Timer;
        private System.Windows.Forms.Timer ColReSize_Timer;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.UltraWinGrid.UltraGrid uGrid_SearchResult;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Broadleaf.Library.Windows.Forms.UiMemInput uiMemInput1;
	}
}

