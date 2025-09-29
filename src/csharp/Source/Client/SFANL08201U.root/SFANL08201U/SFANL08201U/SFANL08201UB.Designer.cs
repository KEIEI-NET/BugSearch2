namespace Broadleaf.Windows.Forms
{
    partial class MaintenanceDlg
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
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintenanceDlg));
            this.GrCancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.GrOk_Button = new Infragistics.Win.Misc.UltraButton();
            this.GroupNm_Title = new Infragistics.Win.Misc.UltraLabel();
            this.GroupNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GroupCd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.GroupCd_Title = new Infragistics.Win.Misc.UltraLabel();
            this.groupAdd_panel = new System.Windows.Forms.Panel();
            this.Mode_Label1 = new Infragistics.Win.Misc.UltraLabel();
            this.TranceAdd_Panel = new System.Windows.Forms.Panel();
            this.FrePprSelect_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Mode_Label2 = new Infragistics.Win.Misc.UltraLabel();
            this.Group_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.FrrPptDispOrderCd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.FrrPptDispOrderCd_Title = new Infragistics.Win.Misc.UltraLabel();
            this.FrePpr_Title = new Infragistics.Win.Misc.UltraLabel();
            this.TrCancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.TrOk_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.GroupNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupCd_tNedit)).BeginInit();
            this.groupAdd_panel.SuspendLayout();
            this.TranceAdd_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrePprSelect_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrrPptDispOrderCd_tNedit)).BeginInit();
            this.SuspendLayout();
            // 
            // GrCancel_Button
            // 
            this.GrCancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.GrCancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GrCancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.GrCancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.GrCancel_Button.Location = new System.Drawing.Point(366, 118);
            this.GrCancel_Button.Name = "GrCancel_Button";
            this.GrCancel_Button.Size = new System.Drawing.Size(125, 34);
            this.GrCancel_Button.TabIndex = 3;
            this.GrCancel_Button.Text = "閉じる(&X)";
            this.GrCancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            this.GrCancel_Button.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaintenanceDlg_KeyDown);
            // 
            // GrOk_Button
            // 
            this.GrOk_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.GrOk_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GrOk_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.GrOk_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.GrOk_Button.Location = new System.Drawing.Point(235, 118);
            this.GrOk_Button.Name = "GrOk_Button";
            this.GrOk_Button.Size = new System.Drawing.Size(125, 34);
            this.GrOk_Button.TabIndex = 2;
            this.GrOk_Button.Text = "保存(&S)";
            this.GrOk_Button.Click += new System.EventHandler(this.GrOk_Button_Click);
            this.GrOk_Button.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaintenanceDlg_KeyDown);
            // 
            // GroupNm_Title
            // 
            appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.GroupNm_Title.Appearance = appearance1;
            this.GroupNm_Title.BackColor = System.Drawing.Color.Transparent;
            this.GroupNm_Title.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupNm_Title.Location = new System.Drawing.Point(12, 67);
            this.GroupNm_Title.Name = "GroupNm_Title";
            this.GroupNm_Title.Size = new System.Drawing.Size(127, 24);
            this.GroupNm_Title.TabIndex = 10;
            this.GroupNm_Title.Text = "帳票グループ";
            // 
            // GroupNm_tEdit
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GroupNm_tEdit.ActiveAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.GroupNm_tEdit.Appearance = appearance3;
            this.GroupNm_tEdit.AutoSelect = true;
            this.GroupNm_tEdit.DataText = "";
            this.GroupNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GroupNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.GroupNm_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.GroupNm_tEdit.Location = new System.Drawing.Point(145, 70);
            this.GroupNm_tEdit.MaxLength = 20;
            this.GroupNm_tEdit.Name = "GroupNm_tEdit";
            this.GroupNm_tEdit.Size = new System.Drawing.Size(337, 24);
            this.GroupNm_tEdit.TabIndex = 1;
            this.GroupNm_tEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaintenanceDlg_KeyDown);
            // 
            // GroupCd_tNedit
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.TextHAlign = Infragistics.Win.HAlign.Right;
            this.GroupCd_tNedit.ActiveAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextHAlign = Infragistics.Win.HAlign.Right;
            this.GroupCd_tNedit.Appearance = appearance5;
            this.GroupCd_tNedit.AutoSelect = true;
            this.GroupCd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GroupCd_tNedit.DataText = "";
            this.GroupCd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GroupCd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.GroupCd_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupCd_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GroupCd_tNedit.Location = new System.Drawing.Point(145, 40);
            this.GroupCd_tNedit.MaxLength = 3;
            this.GroupCd_tNedit.Name = "GroupCd_tNedit";
            this.GroupCd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.GroupCd_tNedit.Size = new System.Drawing.Size(36, 24);
            this.GroupCd_tNedit.TabIndex = 0;
            this.GroupCd_tNedit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaintenanceDlg_KeyDown);
            // 
            // GroupCd_Title
            // 
            appearance6.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.GroupCd_Title.Appearance = appearance6;
            this.GroupCd_Title.BackColor = System.Drawing.Color.Transparent;
            this.GroupCd_Title.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupCd_Title.Location = new System.Drawing.Point(12, 37);
            this.GroupCd_Title.Name = "GroupCd_Title";
            this.GroupCd_Title.Size = new System.Drawing.Size(127, 24);
            this.GroupCd_Title.TabIndex = 19;
            this.GroupCd_Title.Text = "グループコード";
            // 
            // groupAdd_panel
            // 
            this.groupAdd_panel.Controls.Add(this.Mode_Label1);
            this.groupAdd_panel.Controls.Add(this.GrOk_Button);
            this.groupAdd_panel.Controls.Add(this.GroupCd_Title);
            this.groupAdd_panel.Controls.Add(this.GrCancel_Button);
            this.groupAdd_panel.Controls.Add(this.GroupCd_tNedit);
            this.groupAdd_panel.Controls.Add(this.GroupNm_Title);
            this.groupAdd_panel.Controls.Add(this.GroupNm_tEdit);
            this.groupAdd_panel.Location = new System.Drawing.Point(0, 0);
            this.groupAdd_panel.Name = "groupAdd_panel";
            this.groupAdd_panel.Size = new System.Drawing.Size(501, 155);
            this.groupAdd_panel.TabIndex = 20;
            // 
            // Mode_Label1
            // 
            this.Mode_Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.ForeColor = System.Drawing.Color.White;
            appearance7.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance7.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.Mode_Label1.Appearance = appearance7;
            this.Mode_Label1.BackColor = System.Drawing.Color.Navy;
            this.Mode_Label1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Mode_Label1.Location = new System.Drawing.Point(388, 3);
            this.Mode_Label1.Name = "Mode_Label1";
            this.Mode_Label1.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label1.TabIndex = 20;
            this.Mode_Label1.Text = "更新モード";
            // 
            // TranceAdd_Panel
            // 
            this.TranceAdd_Panel.Controls.Add(this.ultraLabel2);
            this.TranceAdd_Panel.Controls.Add(this.FrePprSelect_Grid);
            this.TranceAdd_Panel.Controls.Add(this.Mode_Label2);
            this.TranceAdd_Panel.Controls.Add(this.Group_tComboEditor);
            this.TranceAdd_Panel.Controls.Add(this.ultraLabel1);
            this.TranceAdd_Panel.Controls.Add(this.FrrPptDispOrderCd_tNedit);
            this.TranceAdd_Panel.Controls.Add(this.FrrPptDispOrderCd_Title);
            this.TranceAdd_Panel.Controls.Add(this.FrePpr_Title);
            this.TranceAdd_Panel.Controls.Add(this.TrCancel_Button);
            this.TranceAdd_Panel.Controls.Add(this.TrOk_Button);
            this.TranceAdd_Panel.Location = new System.Drawing.Point(0, 161);
            this.TranceAdd_Panel.Name = "TranceAdd_Panel";
            this.TranceAdd_Panel.Size = new System.Drawing.Size(501, 351);
            this.TranceAdd_Panel.TabIndex = 0;
            // 
            // FrePprSelect_Grid
            // 
            appearance9.BackColor = System.Drawing.Color.White;
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.FrePprSelect_Grid.DisplayLayout.Appearance = appearance9;
            this.FrePprSelect_Grid.DisplayLayout.InterBandSpacing = 10;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.ForeColor = System.Drawing.Color.Black;
            this.FrePprSelect_Grid.DisplayLayout.Override.ActiveCellAppearance = appearance10;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            this.FrePprSelect_Grid.DisplayLayout.Override.CellAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance12.ForeColor = System.Drawing.Color.White;
            appearance12.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance12.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.FrePprSelect_Grid.DisplayLayout.Override.HeaderAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.Lavender;
            this.FrePprSelect_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance13;
            appearance14.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FrePprSelect_Grid.DisplayLayout.Override.RowAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.ForeColor = System.Drawing.Color.White;
            this.FrePprSelect_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance15;
            this.FrePprSelect_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.FrePprSelect_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.FrePprSelect_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.FrePprSelect_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.FrePprSelect_Grid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.FrePprSelect_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.FrePprSelect_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.FrePprSelect_Grid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.FrePprSelect_Grid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FrePprSelect_Grid.Location = new System.Drawing.Point(115, 98);
            this.FrePprSelect_Grid.Name = "FrePprSelect_Grid";
            this.FrePprSelect_Grid.Size = new System.Drawing.Size(376, 177);
            this.FrePprSelect_Grid.TabIndex = 2;
            this.FrePprSelect_Grid.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.FrePprSelect_Grid_InitializeRow);
            this.FrePprSelect_Grid.Paint += new System.Windows.Forms.PaintEventHandler(this.FrePprSelect_Grid_Paint);
            this.FrePprSelect_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrePprSelect_Grid_KeyDown);
            this.FrePprSelect_Grid.AfterRowActivate += new System.EventHandler(this.FrePprSelect_Grid_AfterRowActivate_1);
            // 
            // Mode_Label2
            // 
            this.Mode_Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance16.ForeColor = System.Drawing.Color.White;
            appearance16.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance16.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.Mode_Label2.Appearance = appearance16;
            this.Mode_Label2.BackColor = System.Drawing.Color.Navy;
            this.Mode_Label2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Mode_Label2.Location = new System.Drawing.Point(388, 3);
            this.Mode_Label2.Name = "Mode_Label2";
            this.Mode_Label2.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label2.TabIndex = 26;
            this.Mode_Label2.Text = "更新モード";
            // 
            // Group_tComboEditor
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Group_tComboEditor.ActiveAppearance = appearance17;
            appearance18.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            this.Group_tComboEditor.Appearance = appearance18;
            this.Group_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Group_tComboEditor.Enabled = false;
            this.Group_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Group_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Group_tComboEditor.ItemAppearance = appearance19;
            this.Group_tComboEditor.Location = new System.Drawing.Point(115, 38);
            this.Group_tComboEditor.MaxDropDownItems = 16;
            this.Group_tComboEditor.Name = "Group_tComboEditor";
            this.Group_tComboEditor.Size = new System.Drawing.Size(376, 24);
            this.Group_tComboEditor.TabIndex = 0;
            this.Group_tComboEditor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaintenanceDlg_KeyDown);
            // 
            // ultraLabel1
            // 
            appearance20.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel1.Appearance = appearance20;
            this.ultraLabel1.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(12, 38);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(107, 24);
            this.ultraLabel1.TabIndex = 25;
            this.ultraLabel1.Text = "グループ名称";
            // 
            // FrrPptDispOrderCd_tNedit
            // 
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance21.TextHAlign = Infragistics.Win.HAlign.Right;
            this.FrrPptDispOrderCd_tNedit.ActiveAppearance = appearance21;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance22.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance22.ForeColorDisabled = System.Drawing.Color.Black;
            appearance22.TextHAlign = Infragistics.Win.HAlign.Right;
            this.FrrPptDispOrderCd_tNedit.Appearance = appearance22;
            this.FrrPptDispOrderCd_tNedit.AutoSelect = true;
            this.FrrPptDispOrderCd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.FrrPptDispOrderCd_tNedit.DataText = "";
            this.FrrPptDispOrderCd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.FrrPptDispOrderCd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.FrrPptDispOrderCd_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FrrPptDispOrderCd_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.FrrPptDispOrderCd_tNedit.Location = new System.Drawing.Point(115, 68);
            this.FrrPptDispOrderCd_tNedit.MaxLength = 4;
            this.FrrPptDispOrderCd_tNedit.Name = "FrrPptDispOrderCd_tNedit";
            this.FrrPptDispOrderCd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.FrrPptDispOrderCd_tNedit.Size = new System.Drawing.Size(44, 24);
            this.FrrPptDispOrderCd_tNedit.TabIndex = 1;
            this.FrrPptDispOrderCd_tNedit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaintenanceDlg_KeyDown);
            // 
            // FrrPptDispOrderCd_Title
            // 
            appearance23.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.FrrPptDispOrderCd_Title.Appearance = appearance23;
            this.FrrPptDispOrderCd_Title.BackColor = System.Drawing.Color.Transparent;
            this.FrrPptDispOrderCd_Title.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FrrPptDispOrderCd_Title.Location = new System.Drawing.Point(12, 68);
            this.FrrPptDispOrderCd_Title.Name = "FrrPptDispOrderCd_Title";
            this.FrrPptDispOrderCd_Title.Size = new System.Drawing.Size(97, 24);
            this.FrrPptDispOrderCd_Title.TabIndex = 24;
            this.FrrPptDispOrderCd_Title.Text = "表示順位";
            // 
            // FrePpr_Title
            // 
            appearance24.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.FrePpr_Title.Appearance = appearance24;
            this.FrePpr_Title.BackColor = System.Drawing.Color.Transparent;
            this.FrePpr_Title.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FrePpr_Title.Location = new System.Drawing.Point(12, 98);
            this.FrePpr_Title.Name = "FrePpr_Title";
            this.FrePpr_Title.Size = new System.Drawing.Size(97, 24);
            this.FrePpr_Title.TabIndex = 23;
            this.FrePpr_Title.Text = "帳票名";
            // 
            // TrCancel_Button
            // 
            this.TrCancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TrCancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.TrCancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.TrCancel_Button.Location = new System.Drawing.Point(373, 310);
            this.TrCancel_Button.Name = "TrCancel_Button";
            this.TrCancel_Button.Size = new System.Drawing.Size(125, 34);
            this.TrCancel_Button.TabIndex = 5;
            this.TrCancel_Button.Text = "閉じる(&X)";
            this.TrCancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            this.TrCancel_Button.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaintenanceDlg_KeyDown);
            // 
            // TrOk_Button
            // 
            this.TrOk_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TrOk_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.TrOk_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.TrOk_Button.Location = new System.Drawing.Point(242, 310);
            this.TrOk_Button.Name = "TrOk_Button";
            this.TrOk_Button.Size = new System.Drawing.Size(125, 34);
            this.TrOk_Button.TabIndex = 4;
            this.TrOk_Button.Text = "保存(&S)";
            this.TrOk_Button.Click += new System.EventHandler(this.TrOk_Button_Click);
            this.TrOk_Button.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaintenanceDlg_KeyDown);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // ultraLabel2
            // 
            appearance8.ForeColor = System.Drawing.Color.Red;
            appearance8.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel2.Appearance = appearance8;
            this.ultraLabel2.BackColor = System.Drawing.Color.Transparent;
            this.ultraLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(115, 276);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(252, 24);
            this.ultraLabel2.TabIndex = 27;
            this.ultraLabel2.Text = "※赤文字：グループに登録済み";
            // 
            // MaintenanceDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(505, 517);
            this.Controls.Add(this.TranceAdd_Panel);
            this.Controls.Add(this.groupAdd_panel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaintenanceDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "グループ追加";
            this.VisibleChanged += new System.EventHandler(this.MaintenanceDlg_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaintenanceDlg_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaintenanceDlg_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GroupNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupCd_tNedit)).EndInit();
            this.groupAdd_panel.ResumeLayout(false);
            this.groupAdd_panel.PerformLayout();
            this.TranceAdd_Panel.ResumeLayout(false);
            this.TranceAdd_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrePprSelect_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrrPptDispOrderCd_tNedit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton GrCancel_Button;
        private Infragistics.Win.Misc.UltraButton GrOk_Button;
        private Infragistics.Win.Misc.UltraLabel GroupNm_Title;
        private Broadleaf.Library.Windows.Forms.TEdit GroupNm_tEdit;
        private Broadleaf.Library.Windows.Forms.TNedit GroupCd_tNedit;
        private Infragistics.Win.Misc.UltraLabel GroupCd_Title;
        private System.Windows.Forms.Panel groupAdd_panel;
        private System.Windows.Forms.Panel TranceAdd_Panel;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Broadleaf.Library.Windows.Forms.TNedit FrrPptDispOrderCd_tNedit;
        private Infragistics.Win.Misc.UltraLabel FrrPptDispOrderCd_Title;
        private Infragistics.Win.Misc.UltraLabel FrePpr_Title;
        private Infragistics.Win.Misc.UltraButton TrCancel_Button;
        private Infragistics.Win.Misc.UltraButton TrOk_Button;
        private Broadleaf.Library.Windows.Forms.TComboEditor Group_tComboEditor;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        /// <summary>FrePprSelect_Grid</summary>
        public Infragistics.Win.UltraWinGrid.UltraGrid FrePprSelect_Grid;
    }
}