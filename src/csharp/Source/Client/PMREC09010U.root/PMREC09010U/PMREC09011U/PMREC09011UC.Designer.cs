namespace Broadleaf.Windows.Forms
{
    partial class PMREC09011UC
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
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Main");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Select");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Back");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool1 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Button_Guide", "");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Select");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Button_Back");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool2 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Button_Pos", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool3 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Button_All", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool4 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Button_Search", "");
            Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool5 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("Button_Guide", "");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("lbl_Cnt");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMREC09011UC));
            this.StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.SelectionForm_Fill_Panel = new System.Windows.Forms.Panel();
            this.tEdit_SectionCodeAllowZero = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_SectionName = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SectionTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_SectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.tNedit_CustomerCodeAllowZero = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_CustomerGuide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_CustomerTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_CustomerName = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this._PMREC09011UC_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ToolbarsManager = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._PMREC09011UC_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMREC09011UC_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMREC09011UC_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.SelectionForm_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCodeAllowZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 133);
            this.StatusBar.Margin = new System.Windows.Forms.Padding(4);
            this.StatusBar.Name = "StatusBar";
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            this.StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1});
            this.StatusBar.Size = new System.Drawing.Size(584, 29);
            this.StatusBar.TabIndex = 4;
            this.StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // SelectionForm_Fill_Panel
            // 
            this.SelectionForm_Fill_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.SelectionForm_Fill_Panel.Controls.Add(this.tEdit_SectionCodeAllowZero);
            this.SelectionForm_Fill_Panel.Controls.Add(this.uLabel_SectionName);
            this.SelectionForm_Fill_Panel.Controls.Add(this.uLabel_SectionTitle);
            this.SelectionForm_Fill_Panel.Controls.Add(this.uButton_SectionGuide);
            this.SelectionForm_Fill_Panel.Controls.Add(this.tNedit_CustomerCodeAllowZero);
            this.SelectionForm_Fill_Panel.Controls.Add(this.uButton_CustomerGuide);
            this.SelectionForm_Fill_Panel.Controls.Add(this.uLabel_CustomerTitle);
            this.SelectionForm_Fill_Panel.Controls.Add(this.uLabel_CustomerName);
            this.SelectionForm_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SelectionForm_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectionForm_Fill_Panel.Location = new System.Drawing.Point(0, 28);
            this.SelectionForm_Fill_Panel.Name = "SelectionForm_Fill_Panel";
            this.SelectionForm_Fill_Panel.Size = new System.Drawing.Size(584, 105);
            this.SelectionForm_Fill_Panel.TabIndex = 13;
            // 
            // tEdit_SectionCodeAllowZero
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero.ActiveAppearance = appearance4;
            appearance5.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero.Appearance = appearance5;
            this.tEdit_SectionCodeAllowZero.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero.DataText = "";
            this.tEdit_SectionCodeAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SectionCodeAllowZero.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SectionCodeAllowZero.Location = new System.Drawing.Point(80, 21);
            this.tEdit_SectionCodeAllowZero.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero.Name = "tEdit_SectionCodeAllowZero";
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero.TabIndex = 1460;
            // 
            // uLabel_SectionName
            // 
            appearance3.BackColor = System.Drawing.Color.Gainsboro;
            appearance3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.uLabel_SectionName.Appearance = appearance3;
            this.uLabel_SectionName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_SectionName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_SectionName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uLabel_SectionName.Location = new System.Drawing.Point(162, 21);
            this.uLabel_SectionName.Name = "uLabel_SectionName";
            this.uLabel_SectionName.Size = new System.Drawing.Size(268, 24);
            this.uLabel_SectionName.TabIndex = 1467;
            this.uLabel_SectionName.WrapText = false;
            // 
            // uLabel_SectionTitle
            // 
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            appearance16.TextVAlignAsString = "Middle";
            this.uLabel_SectionTitle.Appearance = appearance16;
            this.uLabel_SectionTitle.Location = new System.Drawing.Point(16, 21);
            this.uLabel_SectionTitle.Name = "uLabel_SectionTitle";
            this.uLabel_SectionTitle.Size = new System.Drawing.Size(60, 24);
            this.uLabel_SectionTitle.TabIndex = 1466;
            this.uLabel_SectionTitle.Text = "拠点";
            // 
            // uButton_SectionGuide
            // 
            appearance18.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.uButton_SectionGuide.Appearance = appearance18;
            this.uButton_SectionGuide.Location = new System.Drawing.Point(436, 21);
            this.uButton_SectionGuide.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.uButton_SectionGuide.Name = "uButton_SectionGuide";
            this.uButton_SectionGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SectionGuide.TabIndex = 1461;
            this.uButton_SectionGuide.Tag = "1";
            this.uButton_SectionGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SectionGuide.Click += new System.EventHandler(this.uButton_SectionGuide_Click);
            // 
            // tNedit_CustomerCodeAllowZero
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance9.TextHAlignAsString = "Right";
            this.tNedit_CustomerCodeAllowZero.ActiveAppearance = appearance9;
            appearance10.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Right";
            this.tNedit_CustomerCodeAllowZero.Appearance = appearance10;
            this.tNedit_CustomerCodeAllowZero.AutoSelect = true;
            this.tNedit_CustomerCodeAllowZero.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCodeAllowZero.DataText = "";
            this.tNedit_CustomerCodeAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCodeAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCodeAllowZero.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_CustomerCodeAllowZero.Location = new System.Drawing.Point(80, 51);
            this.tNedit_CustomerCodeAllowZero.MaxLength = 8;
            this.tNedit_CustomerCodeAllowZero.Name = "tNedit_CustomerCodeAllowZero";
            this.tNedit_CustomerCodeAllowZero.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_CustomerCodeAllowZero.Size = new System.Drawing.Size(74, 24);
            this.tNedit_CustomerCodeAllowZero.TabIndex = 1462;
            // 
            // uButton_CustomerGuide
            // 
            appearance11.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance11.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_CustomerGuide.Appearance = appearance11;
            this.uButton_CustomerGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_CustomerGuide.Location = new System.Drawing.Point(436, 51);
            this.uButton_CustomerGuide.Name = "uButton_CustomerGuide";
            this.uButton_CustomerGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_CustomerGuide.TabIndex = 1463;
            this.uButton_CustomerGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_CustomerGuide.Click += new System.EventHandler(this.uButton_CustomerGuide_Click);
            // 
            // uLabel_CustomerTitle
            // 
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            appearance15.TextVAlignAsString = "Middle";
            this.uLabel_CustomerTitle.Appearance = appearance15;
            this.uLabel_CustomerTitle.Location = new System.Drawing.Point(16, 51);
            this.uLabel_CustomerTitle.Name = "uLabel_CustomerTitle";
            this.uLabel_CustomerTitle.Size = new System.Drawing.Size(60, 24);
            this.uLabel_CustomerTitle.TabIndex = 1464;
            this.uLabel_CustomerTitle.Text = "得意先";
            // 
            // uLabel_CustomerName
            // 
            appearance17.BackColor = System.Drawing.Color.Gainsboro;
            appearance17.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Left";
            appearance17.TextVAlignAsString = "Middle";
            this.uLabel_CustomerName.Appearance = appearance17;
            this.uLabel_CustomerName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_CustomerName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_CustomerName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uLabel_CustomerName.Location = new System.Drawing.Point(162, 51);
            this.uLabel_CustomerName.Name = "uLabel_CustomerName";
            this.uLabel_CustomerName.Size = new System.Drawing.Size(268, 24);
            this.uLabel_CustomerName.TabIndex = 1465;
            this.uLabel_CustomerName.WrapText = false;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // _PMREC09011UC_Toolbars_Dock_Area_Left
            // 
            this._PMREC09011UC_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMREC09011UC_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMREC09011UC_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._PMREC09011UC_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMREC09011UC_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 28);
            this._PMREC09011UC_Toolbars_Dock_Area_Left.Name = "_PMREC09011UC_Toolbars_Dock_Area_Left";
            this._PMREC09011UC_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 105);
            this._PMREC09011UC_Toolbars_Dock_Area_Left.ToolbarsManager = this.ToolbarsManager;
            // 
            // ToolbarsManager
            // 
            this.ToolbarsManager.DesignerFlags = 1;
            this.ToolbarsManager.DockWithinContainer = this;
            this.ToolbarsManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ToolbarsManager.ShowFullMenusDelay = 500;
            this.ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            stateButtonTool1});
            ultraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            ultraToolbar1.Text = "BLコード選択ツールバー";
            this.ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            buttonTool3.SharedProps.Caption = "確定(F10)";
            buttonTool3.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            buttonTool4.SharedProps.Caption = "戻る(F11)";
            buttonTool4.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F11;
            buttonTool4.SharedProps.ToolTipText = "前の画面に戻ります。";
            stateButtonTool2.SharedProps.Caption = "部位別(F8)";
            stateButtonTool2.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F8;
            stateButtonTool3.SharedProps.Caption = "全て(F7)";
            stateButtonTool3.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F7;
            stateButtonTool4.SharedProps.Caption = "対象のみ(F6)";
            stateButtonTool4.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F6;
            stateButtonTool5.SharedProps.Caption = "ガイド(F5)";
            stateButtonTool5.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F5;
            appearance2.TextHAlignAsString = "Center";
            labelTool1.SharedProps.AppearancesSmall.Appearance = appearance2;
            labelTool1.SharedProps.Width = 60;
            this.ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool4,
            stateButtonTool2,
            stateButtonTool3,
            stateButtonTool4,
            stateButtonTool5,
            labelTool1});
            this.ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ToolbarsManager_ToolClick);
            // 
            // _PMREC09011UC_Toolbars_Dock_Area_Right
            // 
            this._PMREC09011UC_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMREC09011UC_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMREC09011UC_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._PMREC09011UC_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMREC09011UC_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(584, 28);
            this._PMREC09011UC_Toolbars_Dock_Area_Right.Name = "_PMREC09011UC_Toolbars_Dock_Area_Right";
            this._PMREC09011UC_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 105);
            this._PMREC09011UC_Toolbars_Dock_Area_Right.ToolbarsManager = this.ToolbarsManager;
            // 
            // _PMREC09011UC_Toolbars_Dock_Area_Top
            // 
            this._PMREC09011UC_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMREC09011UC_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMREC09011UC_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._PMREC09011UC_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMREC09011UC_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._PMREC09011UC_Toolbars_Dock_Area_Top.Name = "_PMREC09011UC_Toolbars_Dock_Area_Top";
            this._PMREC09011UC_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(584, 28);
            this._PMREC09011UC_Toolbars_Dock_Area_Top.ToolbarsManager = this.ToolbarsManager;
            // 
            // _PMREC09011UC_Toolbars_Dock_Area_Bottom
            // 
            this._PMREC09011UC_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMREC09011UC_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMREC09011UC_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._PMREC09011UC_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMREC09011UC_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 133);
            this._PMREC09011UC_Toolbars_Dock_Area_Bottom.Name = "_PMREC09011UC_Toolbars_Dock_Area_Bottom";
            this._PMREC09011UC_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(584, 0);
            this._PMREC09011UC_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ToolbarsManager;
            // 
            // PMREC09011UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 162);
            this.Controls.Add(this.SelectionForm_Fill_Panel);
            this.Controls.Add(this._PMREC09011UC_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMREC09011UC_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._PMREC09011UC_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._PMREC09011UC_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.StatusBar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 200);
            this.Name = "PMREC09011UC";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "拠点・得意先入力画面";
            this.Shown += new System.EventHandler(this.PMREC09011UC_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PMREC09011UC_KeyDown);
            this.SelectionForm_Fill_Panel.ResumeLayout(false);
            this.SelectionForm_Fill_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCodeAllowZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar StatusBar;
        private Broadleaf.Library.Windows.Forms.TToolbarsManager ToolbarsManager;
        private System.Windows.Forms.Panel SelectionForm_Fill_Panel;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionCodeAllowZero;
        private Infragistics.Win.Misc.UltraLabel uLabel_SectionName;
        private Infragistics.Win.Misc.UltraLabel uLabel_SectionTitle;
        private Infragistics.Win.Misc.UltraButton uButton_SectionGuide;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustomerCodeAllowZero;
        private Infragistics.Win.Misc.UltraButton uButton_CustomerGuide;
        private Infragistics.Win.Misc.UltraLabel uLabel_CustomerTitle;
        private Infragistics.Win.Misc.UltraLabel uLabel_CustomerName;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMREC09011UC_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMREC09011UC_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMREC09011UC_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMREC09011UC_Toolbars_Dock_Area_Bottom;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
    }
}