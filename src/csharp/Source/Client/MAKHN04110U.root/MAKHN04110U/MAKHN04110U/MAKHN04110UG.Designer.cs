namespace Broadleaf.Windows.Forms
{
	partial class MAKHN04110UG
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
			Infragistics.Win.UltraWinTree.UltraTreeColumnSet ultraTreeColumnSet1 = new Infragistics.Win.UltraWinTree.UltraTreeColumnSet();
			Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Enter_ButtonTool");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Back_ButtonTool");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Enter_ButtonTool");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Back_ButtonTool");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKHN04110UG));
			this.GoodsKind_uTree = new Infragistics.Win.UltraWinTree.UltraTree();
			this.Sub_uToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
			this.MAKHN04110UG_Fill_Panel = new System.Windows.Forms.Panel();
			this._MAKHN04110UG_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._MAKHN04110UG_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._MAKHN04110UG_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._MAKHN04110UG_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			((System.ComponentModel.ISupportInitialize)(this.GoodsKind_uTree)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Sub_uToolbarsManager)).BeginInit();
			this.MAKHN04110UG_Fill_Panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// GoodsKind_uTree
			// 
			this.GoodsKind_uTree.ColumnSettings.RootColumnSet = ultraTreeColumnSet1;
			this.GoodsKind_uTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GoodsKind_uTree.Location = new System.Drawing.Point(0, 0);
			this.GoodsKind_uTree.Name = "GoodsKind_uTree";
			this.GoodsKind_uTree.ShowLines = false;
			this.GoodsKind_uTree.Size = new System.Drawing.Size(292, 564);
			this.GoodsKind_uTree.TabIndex = 0;
			// 
			// Sub_uToolbarsManager
			// 
			this.Sub_uToolbarsManager.DesignerFlags = 1;
			this.Sub_uToolbarsManager.DockWithinContainer = this;
			this.Sub_uToolbarsManager.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
			this.Sub_uToolbarsManager.ShowFullMenusDelay = 500;
			this.Sub_uToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
			ultraToolbar1.DockedColumn = 0;
			ultraToolbar1.DockedRow = 0;
			ultraToolbar1.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
			ultraToolbar1.Text = "標準";
			ultraToolbar1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2});
			this.Sub_uToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
			buttonTool3.SharedProps.Caption = "選択(&S)";
			buttonTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			buttonTool4.SharedProps.Caption = "戻る(&X)";
			buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
			this.Sub_uToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool4});
			this.Sub_uToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Sub_uToolbarsManager_ToolClick);
			// 
			// MAKHN04110UG_Fill_Panel
			// 
			this.MAKHN04110UG_Fill_Panel.Controls.Add(this.GoodsKind_uTree);
			this.MAKHN04110UG_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
			this.MAKHN04110UG_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MAKHN04110UG_Fill_Panel.Location = new System.Drawing.Point(0, 42);
			this.MAKHN04110UG_Fill_Panel.Name = "MAKHN04110UG_Fill_Panel";
			this.MAKHN04110UG_Fill_Panel.Size = new System.Drawing.Size(292, 564);
			this.MAKHN04110UG_Fill_Panel.TabIndex = 0;
			// 
			// _MAKHN04110UG_Toolbars_Dock_Area_Left
			// 
			this._MAKHN04110UG_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._MAKHN04110UG_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._MAKHN04110UG_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
			this._MAKHN04110UG_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
			this._MAKHN04110UG_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 42);
			this._MAKHN04110UG_Toolbars_Dock_Area_Left.Name = "_MAKHN04110UG_Toolbars_Dock_Area_Left";
			this._MAKHN04110UG_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 564);
			this._MAKHN04110UG_Toolbars_Dock_Area_Left.ToolbarsManager = this.Sub_uToolbarsManager;
			// 
			// _MAKHN04110UG_Toolbars_Dock_Area_Right
			// 
			this._MAKHN04110UG_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._MAKHN04110UG_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._MAKHN04110UG_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
			this._MAKHN04110UG_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
			this._MAKHN04110UG_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(292, 42);
			this._MAKHN04110UG_Toolbars_Dock_Area_Right.Name = "_MAKHN04110UG_Toolbars_Dock_Area_Right";
			this._MAKHN04110UG_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 564);
			this._MAKHN04110UG_Toolbars_Dock_Area_Right.ToolbarsManager = this.Sub_uToolbarsManager;
			// 
			// _MAKHN04110UG_Toolbars_Dock_Area_Top
			// 
			this._MAKHN04110UG_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._MAKHN04110UG_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._MAKHN04110UG_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
			this._MAKHN04110UG_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
			this._MAKHN04110UG_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
			this._MAKHN04110UG_Toolbars_Dock_Area_Top.Name = "_MAKHN04110UG_Toolbars_Dock_Area_Top";
			this._MAKHN04110UG_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(292, 42);
			this._MAKHN04110UG_Toolbars_Dock_Area_Top.ToolbarsManager = this.Sub_uToolbarsManager;
			// 
			// _MAKHN04110UG_Toolbars_Dock_Area_Bottom
			// 
			this._MAKHN04110UG_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._MAKHN04110UG_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._MAKHN04110UG_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
			this._MAKHN04110UG_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
			this._MAKHN04110UG_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 606);
			this._MAKHN04110UG_Toolbars_Dock_Area_Bottom.Name = "_MAKHN04110UG_Toolbars_Dock_Area_Bottom";
			this._MAKHN04110UG_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(292, 0);
			this._MAKHN04110UG_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Sub_uToolbarsManager;
			// 
			// MAKHN04110UG
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 606);
			this.Controls.Add(this.MAKHN04110UG_Fill_Panel);
			this.Controls.Add(this._MAKHN04110UG_Toolbars_Dock_Area_Left);
			this.Controls.Add(this._MAKHN04110UG_Toolbars_Dock_Area_Right);
			this.Controls.Add(this._MAKHN04110UG_Toolbars_Dock_Area_Top);
			this.Controls.Add(this._MAKHN04110UG_Toolbars_Dock_Area_Bottom);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MAKHN04110UG";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "商品属性設定";
			this.Load += new System.EventHandler(this.MAKHN04110UG_Load);
			((System.ComponentModel.ISupportInitialize)(this.GoodsKind_uTree)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Sub_uToolbarsManager)).EndInit();
			this.MAKHN04110UG_Fill_Panel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Infragistics.Win.UltraWinTree.UltraTree GoodsKind_uTree;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Sub_uToolbarsManager;
		private System.Windows.Forms.Panel MAKHN04110UG_Fill_Panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKHN04110UG_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKHN04110UG_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKHN04110UG_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKHN04110UG_Toolbars_Dock_Area_Bottom;
	}
}