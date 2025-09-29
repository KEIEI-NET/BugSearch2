namespace Broadleaf.Windows.Forms
{
	partial class PMSCM00101UA
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

        // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        /// <summary>処分済みフラグ</summary>
        private bool _disposed;
        // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
                // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
                this.PMSCM00101UA_FormClosing(this, null);
                // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
				components.Dispose();
			}
			base.Dispose(disposing);

            // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            _disposed = true;
            // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance198 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance199 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance200 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance201 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance202 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance203 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance204 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance205 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance392 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance393 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance206 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance207 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance208 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSCM00101UA));
            this.uTab_Memo = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ulabel_CustomerSnm = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_CustomerCode = new Infragistics.Win.Misc.UltraLabel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.ulabel_Note4 = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_Note3 = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_Note2 = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_Note1 = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_NoteTitle = new Infragistics.Win.Misc.UltraLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ulabel_CustomerAgent = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_CustomerAgentTitle = new Infragistics.Win.Misc.UltraLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ulabel_CollectMoneyEmployee = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_MoneyKindName = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_CollectMoneyDay = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_TotalDay = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_TotalDayTitle = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_CollectMoneyDayTitle = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_CollectMoneyEmployeeTitle = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_MoneyKindTitle = new Infragistics.Win.Misc.UltraLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ulabel_Address4 = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_OfficeFaxNo = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_OfficeTelNo = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_HomeTelNo = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_Address3 = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_Address1 = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_PostNo = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_PostNoTitle = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_AddressTitle = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_HomeTelNoTitle = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_OfficeTelNoTitle = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_OfficeFaxNoTitle = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_CustomerCodeTitle = new Infragistics.Win.Misc.UltraLabel();
            this.ulabel_CustomerNameTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uTab_Total = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.uGrid_Result = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ViewButtonPanel = new System.Windows.Forms.Panel();
            this.uButton_ShowDetail = new Infragistics.Win.Misc.UltraButton();
            this.MAURI02001UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.timer_Search = new System.Windows.Forms.Timer(this.components);
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.uTabControl_Footer = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.panel25 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btnShowSalesSlipInputForm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._PMSCM00101UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.uTab_Memo.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.uTab_Total.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel13.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.uGrid_Result ) ).BeginInit();
            this.ViewButtonPanel.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.ultraTabControl1 ) ).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.uTabControl_Footer ) ).BeginInit();
            this.uTabControl_Footer.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.pictureBox4 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // uTab_Memo
            // 
            this.uTab_Memo.Controls.Add(this.panel3);
            this.uTab_Memo.Location = new System.Drawing.Point(-10000, -10000);
            this.uTab_Memo.Name = "uTab_Memo";
            this.uTab_Memo.Size = new System.Drawing.Size(790, 472);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.ulabel_CustomerSnm);
            this.panel3.Controls.Add(this.ulabel_CustomerCode);
            this.panel3.Controls.Add(this.panel12);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.ulabel_CustomerCodeTitle);
            this.panel3.Controls.Add(this.ulabel_CustomerNameTitle);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(790, 472);
            this.panel3.TabIndex = 1269;
            // 
            // ulabel_CustomerSnm
            // 
            appearance109.ForeColorDisabled = System.Drawing.Color.Black;
            appearance109.TextVAlignAsString = "Middle";
            this.ulabel_CustomerSnm.Appearance = appearance109;
            this.ulabel_CustomerSnm.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_CustomerSnm.Location = new System.Drawing.Point(143, 44);
            this.ulabel_CustomerSnm.Name = "ulabel_CustomerSnm";
            this.ulabel_CustomerSnm.Size = new System.Drawing.Size(602, 24);
            this.ulabel_CustomerSnm.TabIndex = 1275;
            this.ulabel_CustomerSnm.WrapText = false;
            // 
            // ulabel_CustomerCode
            // 
            appearance110.ForeColorDisabled = System.Drawing.Color.Black;
            appearance110.TextVAlignAsString = "Middle";
            this.ulabel_CustomerCode.Appearance = appearance110;
            this.ulabel_CustomerCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_CustomerCode.Location = new System.Drawing.Point(143, 14);
            this.ulabel_CustomerCode.Name = "ulabel_CustomerCode";
            this.ulabel_CustomerCode.Size = new System.Drawing.Size(602, 24);
            this.ulabel_CustomerCode.TabIndex = 1274;
            this.ulabel_CustomerCode.WrapText = false;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel12.Controls.Add(this.ulabel_Note4);
            this.panel12.Controls.Add(this.ulabel_Note3);
            this.panel12.Controls.Add(this.ulabel_Note2);
            this.panel12.Controls.Add(this.ulabel_Note1);
            this.panel12.Controls.Add(this.ulabel_NoteTitle);
            this.panel12.Location = new System.Drawing.Point(3, 309);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(450, 141);
            this.panel12.TabIndex = 1273;
            // 
            // ulabel_Note4
            // 
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.ulabel_Note4.Appearance = appearance2;
            this.ulabel_Note4.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_Note4.Location = new System.Drawing.Point(80, 107);
            this.ulabel_Note4.Name = "ulabel_Note4";
            this.ulabel_Note4.Size = new System.Drawing.Size(363, 24);
            this.ulabel_Note4.TabIndex = 1285;
            this.ulabel_Note4.Text = "１２３４５６７８９０１２３４５６７８９０";
            this.ulabel_Note4.WrapText = false;
            // 
            // ulabel_Note3
            // 
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextVAlignAsString = "Middle";
            this.ulabel_Note3.Appearance = appearance3;
            this.ulabel_Note3.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_Note3.Location = new System.Drawing.Point(80, 77);
            this.ulabel_Note3.Name = "ulabel_Note3";
            this.ulabel_Note3.Size = new System.Drawing.Size(363, 24);
            this.ulabel_Note3.TabIndex = 1284;
            this.ulabel_Note3.Text = "１２３４５６７８９０１２３４５６７８９０";
            this.ulabel_Note3.WrapText = false;
            // 
            // ulabel_Note2
            // 
            appearance113.ForeColorDisabled = System.Drawing.Color.Black;
            appearance113.TextVAlignAsString = "Middle";
            this.ulabel_Note2.Appearance = appearance113;
            this.ulabel_Note2.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_Note2.Location = new System.Drawing.Point(80, 47);
            this.ulabel_Note2.Name = "ulabel_Note2";
            this.ulabel_Note2.Size = new System.Drawing.Size(363, 24);
            this.ulabel_Note2.TabIndex = 1283;
            this.ulabel_Note2.Text = "１２３４５６７８９０１２３４５６７８９０";
            this.ulabel_Note2.WrapText = false;
            // 
            // ulabel_Note1
            // 
            appearance114.ForeColorDisabled = System.Drawing.Color.Black;
            appearance114.TextVAlignAsString = "Middle";
            this.ulabel_Note1.Appearance = appearance114;
            this.ulabel_Note1.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_Note1.Location = new System.Drawing.Point(80, 17);
            this.ulabel_Note1.Name = "ulabel_Note1";
            this.ulabel_Note1.Size = new System.Drawing.Size(363, 24);
            this.ulabel_Note1.TabIndex = 1282;
            this.ulabel_Note1.Text = "１２３４５６７８９０１２３４５６７８９０";
            this.ulabel_Note1.WrapText = false;
            // 
            // ulabel_NoteTitle
            // 
            appearance115.ForeColorDisabled = System.Drawing.Color.Black;
            appearance115.TextVAlignAsString = "Middle";
            this.ulabel_NoteTitle.Appearance = appearance115;
            this.ulabel_NoteTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_NoteTitle.Location = new System.Drawing.Point(15, 17);
            this.ulabel_NoteTitle.Name = "ulabel_NoteTitle";
            this.ulabel_NoteTitle.Size = new System.Drawing.Size(57, 24);
            this.ulabel_NoteTitle.TabIndex = 1259;
            this.ulabel_NoteTitle.Text = "備考";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.ulabel_CustomerAgent);
            this.panel6.Controls.Add(this.ulabel_CustomerAgentTitle);
            this.panel6.Location = new System.Drawing.Point(455, 355);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(328, 95);
            this.panel6.TabIndex = 1272;
            // 
            // ulabel_CustomerAgent
            // 
            appearance116.ForeColorDisabled = System.Drawing.Color.Black;
            appearance116.TextVAlignAsString = "Middle";
            this.ulabel_CustomerAgent.Appearance = appearance116;
            this.ulabel_CustomerAgent.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_CustomerAgent.Location = new System.Drawing.Point(158, 17);
            this.ulabel_CustomerAgent.Name = "ulabel_CustomerAgent";
            this.ulabel_CustomerAgent.Size = new System.Drawing.Size(163, 24);
            this.ulabel_CustomerAgent.TabIndex = 1286;
            this.ulabel_CustomerAgent.Text = "１２３４５６７８９";
            this.ulabel_CustomerAgent.WrapText = false;
            // 
            // ulabel_CustomerAgentTitle
            // 
            appearance117.ForeColorDisabled = System.Drawing.Color.Black;
            appearance117.TextVAlignAsString = "Middle";
            this.ulabel_CustomerAgentTitle.Appearance = appearance117;
            this.ulabel_CustomerAgentTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_CustomerAgentTitle.Location = new System.Drawing.Point(17, 17);
            this.ulabel_CustomerAgentTitle.Name = "ulabel_CustomerAgentTitle";
            this.ulabel_CustomerAgentTitle.Size = new System.Drawing.Size(144, 24);
            this.ulabel_CustomerAgentTitle.TabIndex = 1268;
            this.ulabel_CustomerAgentTitle.Text = "得意先担当者";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.ulabel_CollectMoneyEmployee);
            this.panel5.Controls.Add(this.ulabel_MoneyKindName);
            this.panel5.Controls.Add(this.ulabel_CollectMoneyDay);
            this.panel5.Controls.Add(this.ulabel_TotalDay);
            this.panel5.Controls.Add(this.ulabel_TotalDayTitle);
            this.panel5.Controls.Add(this.ulabel_CollectMoneyDayTitle);
            this.panel5.Controls.Add(this.ulabel_CollectMoneyEmployeeTitle);
            this.panel5.Controls.Add(this.ulabel_MoneyKindTitle);
            this.panel5.Location = new System.Drawing.Point(455, 75);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(328, 278);
            this.panel5.TabIndex = 1271;
            // 
            // ulabel_CollectMoneyEmployee
            // 
            appearance118.ForeColorDisabled = System.Drawing.Color.Black;
            appearance118.TextVAlignAsString = "Middle";
            this.ulabel_CollectMoneyEmployee.Appearance = appearance118;
            this.ulabel_CollectMoneyEmployee.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_CollectMoneyEmployee.Location = new System.Drawing.Point(158, 107);
            this.ulabel_CollectMoneyEmployee.Name = "ulabel_CollectMoneyEmployee";
            this.ulabel_CollectMoneyEmployee.Size = new System.Drawing.Size(163, 24);
            this.ulabel_CollectMoneyEmployee.TabIndex = 1285;
            this.ulabel_CollectMoneyEmployee.Text = "１２３４５６７８９０";
            this.ulabel_CollectMoneyEmployee.WrapText = false;
            // 
            // ulabel_MoneyKindName
            // 
            appearance119.ForeColorDisabled = System.Drawing.Color.Black;
            appearance119.TextVAlignAsString = "Middle";
            this.ulabel_MoneyKindName.Appearance = appearance119;
            this.ulabel_MoneyKindName.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_MoneyKindName.Location = new System.Drawing.Point(158, 77);
            this.ulabel_MoneyKindName.Name = "ulabel_MoneyKindName";
            this.ulabel_MoneyKindName.Size = new System.Drawing.Size(163, 24);
            this.ulabel_MoneyKindName.TabIndex = 1284;
            this.ulabel_MoneyKindName.Text = "現金";
            this.ulabel_MoneyKindName.WrapText = false;
            // 
            // ulabel_CollectMoneyDay
            // 
            appearance120.ForeColorDisabled = System.Drawing.Color.Black;
            appearance120.TextVAlignAsString = "Middle";
            this.ulabel_CollectMoneyDay.Appearance = appearance120;
            this.ulabel_CollectMoneyDay.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_CollectMoneyDay.Location = new System.Drawing.Point(158, 47);
            this.ulabel_CollectMoneyDay.Name = "ulabel_CollectMoneyDay";
            this.ulabel_CollectMoneyDay.Size = new System.Drawing.Size(163, 24);
            this.ulabel_CollectMoneyDay.TabIndex = 1283;
            this.ulabel_CollectMoneyDay.Text = "31日";
            this.ulabel_CollectMoneyDay.WrapText = false;
            // 
            // ulabel_TotalDay
            // 
            appearance121.ForeColorDisabled = System.Drawing.Color.Black;
            appearance121.TextVAlignAsString = "Middle";
            this.ulabel_TotalDay.Appearance = appearance121;
            this.ulabel_TotalDay.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_TotalDay.Location = new System.Drawing.Point(157, 17);
            this.ulabel_TotalDay.Name = "ulabel_TotalDay";
            this.ulabel_TotalDay.Size = new System.Drawing.Size(163, 24);
            this.ulabel_TotalDay.TabIndex = 1282;
            this.ulabel_TotalDay.Text = "20日";
            this.ulabel_TotalDay.WrapText = false;
            // 
            // ulabel_TotalDayTitle
            // 
            appearance122.ForeColorDisabled = System.Drawing.Color.Black;
            appearance122.TextVAlignAsString = "Middle";
            this.ulabel_TotalDayTitle.Appearance = appearance122;
            this.ulabel_TotalDayTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_TotalDayTitle.Location = new System.Drawing.Point(17, 17);
            this.ulabel_TotalDayTitle.Name = "ulabel_TotalDayTitle";
            this.ulabel_TotalDayTitle.Size = new System.Drawing.Size(113, 24);
            this.ulabel_TotalDayTitle.TabIndex = 1264;
            this.ulabel_TotalDayTitle.Text = "締日";
            // 
            // ulabel_CollectMoneyDayTitle
            // 
            appearance123.ForeColorDisabled = System.Drawing.Color.Black;
            appearance123.TextVAlignAsString = "Middle";
            this.ulabel_CollectMoneyDayTitle.Appearance = appearance123;
            this.ulabel_CollectMoneyDayTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_CollectMoneyDayTitle.Location = new System.Drawing.Point(17, 47);
            this.ulabel_CollectMoneyDayTitle.Name = "ulabel_CollectMoneyDayTitle";
            this.ulabel_CollectMoneyDayTitle.Size = new System.Drawing.Size(113, 24);
            this.ulabel_CollectMoneyDayTitle.TabIndex = 1265;
            this.ulabel_CollectMoneyDayTitle.Text = "集金日";
            // 
            // ulabel_CollectMoneyEmployeeTitle
            // 
            appearance124.ForeColorDisabled = System.Drawing.Color.Black;
            appearance124.TextVAlignAsString = "Middle";
            this.ulabel_CollectMoneyEmployeeTitle.Appearance = appearance124;
            this.ulabel_CollectMoneyEmployeeTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_CollectMoneyEmployeeTitle.Location = new System.Drawing.Point(17, 107);
            this.ulabel_CollectMoneyEmployeeTitle.Name = "ulabel_CollectMoneyEmployeeTitle";
            this.ulabel_CollectMoneyEmployeeTitle.Size = new System.Drawing.Size(113, 24);
            this.ulabel_CollectMoneyEmployeeTitle.TabIndex = 1267;
            this.ulabel_CollectMoneyEmployeeTitle.Text = "集金担当者";
            // 
            // ulabel_MoneyKindTitle
            // 
            appearance125.ForeColorDisabled = System.Drawing.Color.Black;
            appearance125.TextVAlignAsString = "Middle";
            this.ulabel_MoneyKindTitle.Appearance = appearance125;
            this.ulabel_MoneyKindTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_MoneyKindTitle.Location = new System.Drawing.Point(17, 77);
            this.ulabel_MoneyKindTitle.Name = "ulabel_MoneyKindTitle";
            this.ulabel_MoneyKindTitle.Size = new System.Drawing.Size(113, 24);
            this.ulabel_MoneyKindTitle.TabIndex = 1266;
            this.ulabel_MoneyKindTitle.Text = "回収条件";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.ulabel_Address4);
            this.panel4.Controls.Add(this.ulabel_OfficeFaxNo);
            this.panel4.Controls.Add(this.ulabel_OfficeTelNo);
            this.panel4.Controls.Add(this.ulabel_HomeTelNo);
            this.panel4.Controls.Add(this.ulabel_Address3);
            this.panel4.Controls.Add(this.ulabel_Address1);
            this.panel4.Controls.Add(this.ulabel_PostNo);
            this.panel4.Controls.Add(this.ulabel_PostNoTitle);
            this.panel4.Controls.Add(this.ulabel_AddressTitle);
            this.panel4.Controls.Add(this.ulabel_HomeTelNoTitle);
            this.panel4.Controls.Add(this.ulabel_OfficeTelNoTitle);
            this.panel4.Controls.Add(this.ulabel_OfficeFaxNoTitle);
            this.panel4.Location = new System.Drawing.Point(3, 75);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(450, 232);
            this.panel4.TabIndex = 1270;
            // 
            // ulabel_Address4
            // 
            appearance129.ForeColorDisabled = System.Drawing.Color.Black;
            appearance129.TextVAlignAsString = "Middle";
            this.ulabel_Address4.Appearance = appearance129;
            this.ulabel_Address4.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_Address4.Location = new System.Drawing.Point(141, 107);
            this.ulabel_Address4.Name = "ulabel_Address4";
            this.ulabel_Address4.Size = new System.Drawing.Size(305, 24);
            this.ulabel_Address4.TabIndex = 1282;
            this.ulabel_Address4.Text = "１２３４５６７８９０１２３４５";
            this.ulabel_Address4.WrapText = false;
            // 
            // ulabel_OfficeFaxNo
            // 
            appearance126.ForeColorDisabled = System.Drawing.Color.Black;
            appearance126.TextVAlignAsString = "Middle";
            this.ulabel_OfficeFaxNo.Appearance = appearance126;
            this.ulabel_OfficeFaxNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_OfficeFaxNo.Location = new System.Drawing.Point(141, 197);
            this.ulabel_OfficeFaxNo.Name = "ulabel_OfficeFaxNo";
            this.ulabel_OfficeFaxNo.Size = new System.Drawing.Size(305, 24);
            this.ulabel_OfficeFaxNo.TabIndex = 1281;
            this.ulabel_OfficeFaxNo.Text = "03-XXXX-XXXX";
            this.ulabel_OfficeFaxNo.WrapText = false;
            // 
            // ulabel_OfficeTelNo
            // 
            appearance127.ForeColorDisabled = System.Drawing.Color.Black;
            appearance127.TextVAlignAsString = "Middle";
            this.ulabel_OfficeTelNo.Appearance = appearance127;
            this.ulabel_OfficeTelNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_OfficeTelNo.Location = new System.Drawing.Point(141, 137);
            this.ulabel_OfficeTelNo.Name = "ulabel_OfficeTelNo";
            this.ulabel_OfficeTelNo.Size = new System.Drawing.Size(305, 24);
            this.ulabel_OfficeTelNo.TabIndex = 1280;
            this.ulabel_OfficeTelNo.Text = "03-XXXX-XXXX";
            this.ulabel_OfficeTelNo.WrapText = false;
            // 
            // ulabel_HomeTelNo
            // 
            appearance128.ForeColorDisabled = System.Drawing.Color.Black;
            appearance128.TextVAlignAsString = "Middle";
            this.ulabel_HomeTelNo.Appearance = appearance128;
            this.ulabel_HomeTelNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_HomeTelNo.Location = new System.Drawing.Point(141, 167);
            this.ulabel_HomeTelNo.Name = "ulabel_HomeTelNo";
            this.ulabel_HomeTelNo.Size = new System.Drawing.Size(305, 24);
            this.ulabel_HomeTelNo.TabIndex = 1279;
            this.ulabel_HomeTelNo.Text = "03-XXXX-XXXX";
            this.ulabel_HomeTelNo.WrapText = false;
            // 
            // ulabel_Address3
            // 
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.ulabel_Address3.Appearance = appearance1;
            this.ulabel_Address3.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_Address3.Location = new System.Drawing.Point(141, 77);
            this.ulabel_Address3.Name = "ulabel_Address3";
            this.ulabel_Address3.Size = new System.Drawing.Size(305, 24);
            this.ulabel_Address3.TabIndex = 1278;
            this.ulabel_Address3.Text = "１２３４５６７８９０１２３４５";
            this.ulabel_Address3.WrapText = false;
            // 
            // ulabel_Address1
            // 
            appearance130.ForeColorDisabled = System.Drawing.Color.Black;
            appearance130.TextVAlignAsString = "Middle";
            this.ulabel_Address1.Appearance = appearance130;
            this.ulabel_Address1.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_Address1.Location = new System.Drawing.Point(141, 47);
            this.ulabel_Address1.Name = "ulabel_Address1";
            this.ulabel_Address1.Size = new System.Drawing.Size(309, 24);
            this.ulabel_Address1.TabIndex = 1277;
            this.ulabel_Address1.Text = "○○○県○○市○○町○丁目１－１０－１";
            this.ulabel_Address1.WrapText = false;
            // 
            // ulabel_PostNo
            // 
            appearance131.ForeColorDisabled = System.Drawing.Color.Black;
            appearance131.TextVAlignAsString = "Middle";
            this.ulabel_PostNo.Appearance = appearance131;
            this.ulabel_PostNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_PostNo.Location = new System.Drawing.Point(141, 17);
            this.ulabel_PostNo.Name = "ulabel_PostNo";
            this.ulabel_PostNo.Size = new System.Drawing.Size(305, 24);
            this.ulabel_PostNo.TabIndex = 1276;
            this.ulabel_PostNo.Text = "123-4567";
            this.ulabel_PostNo.WrapText = false;
            // 
            // ulabel_PostNoTitle
            // 
            appearance132.ForeColorDisabled = System.Drawing.Color.Black;
            appearance132.TextVAlignAsString = "Middle";
            this.ulabel_PostNoTitle.Appearance = appearance132;
            this.ulabel_PostNoTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_PostNoTitle.Location = new System.Drawing.Point(15, 17);
            this.ulabel_PostNoTitle.Name = "ulabel_PostNoTitle";
            this.ulabel_PostNoTitle.Size = new System.Drawing.Size(113, 24);
            this.ulabel_PostNoTitle.TabIndex = 1259;
            this.ulabel_PostNoTitle.Text = "郵便番号";
            this.ulabel_PostNoTitle.WrapText = false;
            // 
            // ulabel_AddressTitle
            // 
            appearance133.ForeColorDisabled = System.Drawing.Color.Black;
            appearance133.TextVAlignAsString = "Middle";
            this.ulabel_AddressTitle.Appearance = appearance133;
            this.ulabel_AddressTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_AddressTitle.Location = new System.Drawing.Point(15, 47);
            this.ulabel_AddressTitle.Name = "ulabel_AddressTitle";
            this.ulabel_AddressTitle.Size = new System.Drawing.Size(113, 24);
            this.ulabel_AddressTitle.TabIndex = 1260;
            this.ulabel_AddressTitle.Text = "住所";
            this.ulabel_AddressTitle.WrapText = false;
            // 
            // ulabel_HomeTelNoTitle
            // 
            appearance134.ForeColorDisabled = System.Drawing.Color.Black;
            appearance134.TextVAlignAsString = "Middle";
            this.ulabel_HomeTelNoTitle.Appearance = appearance134;
            this.ulabel_HomeTelNoTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_HomeTelNoTitle.Location = new System.Drawing.Point(15, 167);
            this.ulabel_HomeTelNoTitle.Name = "ulabel_HomeTelNoTitle";
            this.ulabel_HomeTelNoTitle.Size = new System.Drawing.Size(113, 24);
            this.ulabel_HomeTelNoTitle.TabIndex = 1261;
            this.ulabel_HomeTelNoTitle.Text = "電話番号１";
            this.ulabel_HomeTelNoTitle.WrapText = false;
            // 
            // ulabel_OfficeTelNoTitle
            // 
            appearance135.ForeColorDisabled = System.Drawing.Color.Black;
            appearance135.TextVAlignAsString = "Middle";
            this.ulabel_OfficeTelNoTitle.Appearance = appearance135;
            this.ulabel_OfficeTelNoTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_OfficeTelNoTitle.Location = new System.Drawing.Point(15, 137);
            this.ulabel_OfficeTelNoTitle.Name = "ulabel_OfficeTelNoTitle";
            this.ulabel_OfficeTelNoTitle.Size = new System.Drawing.Size(113, 24);
            this.ulabel_OfficeTelNoTitle.TabIndex = 1262;
            this.ulabel_OfficeTelNoTitle.Text = "電話番号２";
            this.ulabel_OfficeTelNoTitle.WrapText = false;
            // 
            // ulabel_OfficeFaxNoTitle
            // 
            appearance136.ForeColorDisabled = System.Drawing.Color.Black;
            appearance136.TextVAlignAsString = "Middle";
            this.ulabel_OfficeFaxNoTitle.Appearance = appearance136;
            this.ulabel_OfficeFaxNoTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_OfficeFaxNoTitle.Location = new System.Drawing.Point(15, 197);
            this.ulabel_OfficeFaxNoTitle.Name = "ulabel_OfficeFaxNoTitle";
            this.ulabel_OfficeFaxNoTitle.Size = new System.Drawing.Size(124, 24);
            this.ulabel_OfficeFaxNoTitle.TabIndex = 1263;
            this.ulabel_OfficeFaxNoTitle.Text = "勤務先ＦＡＸ";
            this.ulabel_OfficeFaxNoTitle.WrapText = false;
            // 
            // ulabel_CustomerCodeTitle
            // 
            appearance137.ForeColorDisabled = System.Drawing.Color.Black;
            appearance137.TextVAlignAsString = "Middle";
            this.ulabel_CustomerCodeTitle.Appearance = appearance137;
            this.ulabel_CustomerCodeTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_CustomerCodeTitle.Location = new System.Drawing.Point(9, 13);
            this.ulabel_CustomerCodeTitle.Name = "ulabel_CustomerCodeTitle";
            this.ulabel_CustomerCodeTitle.Size = new System.Drawing.Size(134, 24);
            this.ulabel_CustomerCodeTitle.TabIndex = 1257;
            this.ulabel_CustomerCodeTitle.Text = "得意先コード";
            // 
            // ulabel_CustomerNameTitle
            // 
            appearance138.ForeColorDisabled = System.Drawing.Color.Black;
            appearance138.TextVAlignAsString = "Middle";
            this.ulabel_CustomerNameTitle.Appearance = appearance138;
            this.ulabel_CustomerNameTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ulabel_CustomerNameTitle.Location = new System.Drawing.Point(9, 43);
            this.ulabel_CustomerNameTitle.Name = "ulabel_CustomerNameTitle";
            this.ulabel_CustomerNameTitle.Size = new System.Drawing.Size(113, 24);
            this.ulabel_CustomerNameTitle.TabIndex = 1258;
            this.ulabel_CustomerNameTitle.Text = "得意先名";
            // 
            // uTab_Total
            // 
            this.uTab_Total.Controls.Add(this.panel2);
            this.uTab_Total.Location = new System.Drawing.Point(1, 26);
            this.uTab_Total.Name = "uTab_Total";
            this.uTab_Total.Size = new System.Drawing.Size(790, 472);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 254 ) ) ) ));
            this.panel2.Controls.Add(this.panel13);
            this.panel2.Controls.Add(this.ViewButtonPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(790, 472);
            this.panel2.TabIndex = 5;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.DimGray;
            this.panel13.Controls.Add(this.uGrid_Result);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(0, 31);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(790, 441);
            this.panel13.TabIndex = 1265;
            // 
            // uGrid_Result
            // 
            appearance198.BackColor = System.Drawing.Color.White;
            appearance198.BackColor2 = System.Drawing.Color.White;
            appearance198.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Result.DisplayLayout.Appearance = appearance198;
            this.uGrid_Result.DisplayLayout.GroupByBox.Hidden = true;
            this.uGrid_Result.DisplayLayout.GroupByBox.Style = Infragistics.Win.UltraWinGrid.GroupByBoxStyle.Compact;
            this.uGrid_Result.DisplayLayout.InterBandSpacing = 10;
            this.uGrid_Result.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid_Result.DisplayLayout.MaxRowScrollRegions = 1;
            appearance199.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.uGrid_Result.DisplayLayout.Override.ActiveCellAppearance = appearance199;
            this.uGrid_Result.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.uGrid_Result.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Result.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.uGrid_Result.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Result.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            this.uGrid_Result.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance200.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 100 ) ) ) ), ( (int)( ( (byte)( 200 ) ) ) ), ( (int)( ( (byte)( 100 ) ) ) ));
            appearance200.BackColor2 = System.Drawing.Color.DarkGreen;
            appearance200.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance200.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance200.ForeColor = System.Drawing.Color.White;
            appearance200.TextHAlignAsString = "Center";
            appearance200.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_Result.DisplayLayout.Override.HeaderAppearance = appearance200;
            this.uGrid_Result.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance201.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 230 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 230 ) ) ) ));
            this.uGrid_Result.DisplayLayout.Override.RowAlternateAppearance = appearance201;
            appearance202.BorderColor = System.Drawing.Color.DarkGreen;
            appearance202.TextVAlignAsString = "Middle";
            this.uGrid_Result.DisplayLayout.Override.RowAppearance = appearance202;
            this.uGrid_Result.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.uGrid_Result.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance203.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 100 ) ) ) ), ( (int)( ( (byte)( 200 ) ) ) ), ( (int)( ( (byte)( 100 ) ) ) ));
            appearance203.BackColor2 = System.Drawing.Color.DarkGreen;
            appearance203.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance203.ForeColor = System.Drawing.Color.White;
            this.uGrid_Result.DisplayLayout.Override.RowSelectorAppearance = appearance203;
            this.uGrid_Result.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Result.DisplayLayout.Override.RowSelectorWidth = 12;
            this.uGrid_Result.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance204.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 230 ) ) ) ), ( (int)( ( (byte)( 148 ) ) ) ));
            appearance204.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 238 ) ) ) ), ( (int)( ( (byte)( 149 ) ) ) ), ( (int)( ( (byte)( 21 ) ) ) ));
            appearance204.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance204.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Result.DisplayLayout.Override.SelectedRowAppearance = appearance204;
            this.uGrid_Result.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_Result.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.uGrid_Result.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
            this.uGrid_Result.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Result.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Result.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Result.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 168 ) ) ) ), ( (int)( ( (byte)( 167 ) ) ) ), ( (int)( ( (byte)( 191 ) ) ) ));
            this.uGrid_Result.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid_Result.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid_Result.DisplayLayout.UseFixedHeaders = true;
            this.uGrid_Result.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGrid_Result.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.uGrid_Result.Location = new System.Drawing.Point(0, 0);
            this.uGrid_Result.Name = "uGrid_Result";
            this.uGrid_Result.Size = new System.Drawing.Size(790, 441);
            this.uGrid_Result.TabIndex = 1215;
            this.uGrid_Result.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_Result_InitializeLayout);
            this.uGrid_Result.Enter += new System.EventHandler(this.uGrid_Result_Enter);
            this.uGrid_Result.DoubleClick += new System.EventHandler(this.uGrid_Result_DoubleClick);
            this.uGrid_Result.AfterCellActivate += new System.EventHandler(this.uGrid_Result_AfterCellActivate);
            // 
            // ViewButtonPanel
            // 
            this.ViewButtonPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.ViewButtonPanel.Controls.Add(this.uButton_ShowDetail);
            this.ViewButtonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ViewButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.ViewButtonPanel.Name = "ViewButtonPanel";
            this.ViewButtonPanel.Size = new System.Drawing.Size(790, 31);
            this.ViewButtonPanel.TabIndex = 1214;
            // 
            // uButton_ShowDetail
            // 
            appearance205.Image = "携帯電話検索.bmp";
            this.uButton_ShowDetail.Appearance = appearance205;
            this.uButton_ShowDetail.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.uButton_ShowDetail.ImageTransparentColor = System.Drawing.Color.Cyan;
            this.uButton_ShowDetail.Location = new System.Drawing.Point(3, 2);
            this.uButton_ShowDetail.Name = "uButton_ShowDetail";
            this.uButton_ShowDetail.Size = new System.Drawing.Size(103, 27);
            this.uButton_ShowDetail.TabIndex = 31;
            this.uButton_ShowDetail.Text = "明細情報(&D)";
            this.uButton_ShowDetail.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_ShowDetail.Click += new System.EventHandler(this.uButton_ShowDetail_Click);
            // 
            // MAURI02001UA_Fill_Panel
            // 
            this.MAURI02001UA_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.MAURI02001UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MAURI02001UA_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.MAURI02001UA_Fill_Panel.Name = "MAURI02001UA_Fill_Panel";
            this.MAURI02001UA_Fill_Panel.Size = new System.Drawing.Size(792, 633);
            this.MAURI02001UA_Fill_Panel.TabIndex = 0;
            // 
            // timer_Search
            // 
            this.timer_Search.Interval = 1;
            this.timer_Search.Tick += new System.EventHandler(this.timer_Search_Tick);
            // 
            // ultraTabControl1
            // 
            appearance392.BackColor = System.Drawing.Color.White;
            appearance392.BackColor2 = System.Drawing.Color.Pink;
            this.ultraTabControl1.ActiveTabAppearance = appearance392;
            appearance10.BackColor = System.Drawing.Color.White;
            appearance10.BackColor2 = System.Drawing.Color.White;
            this.ultraTabControl1.Appearance = appearance10;
            appearance393.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 248 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance393.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 248 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.ultraTabControl1.ClientAreaAppearance = appearance393;
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage2);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage2;
            this.ultraTabControl1.Size = new System.Drawing.Size(200, 100);
            this.ultraTabControl1.TabIndex = 0;
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(196, 77);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(890, 521);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(196, 77);
            // 
            // uTabControl_Footer
            // 
            appearance206.BackColor = System.Drawing.Color.White;
            appearance206.BackColor2 = System.Drawing.Color.Pink;
            this.uTabControl_Footer.ActiveTabAppearance = appearance206;
            appearance207.BackColor = System.Drawing.Color.White;
            appearance207.BackColor2 = System.Drawing.Color.White;
            this.uTabControl_Footer.Appearance = appearance207;
            appearance208.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 248 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance208.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 248 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.uTabControl_Footer.ClientAreaAppearance = appearance208;
            this.uTabControl_Footer.Controls.Add(this.ultraTabSharedControlsPage1);
            this.uTabControl_Footer.Controls.Add(this.uTab_Total);
            this.uTabControl_Footer.Controls.Add(this.uTab_Memo);
            this.uTabControl_Footer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uTabControl_Footer.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.uTabControl_Footer.InterTabSpacing = new Infragistics.Win.DefaultableInteger(2);
            this.uTabControl_Footer.Location = new System.Drawing.Point(0, 53);
            this.uTabControl_Footer.Name = "uTabControl_Footer";
            this.uTabControl_Footer.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.uTabControl_Footer.Size = new System.Drawing.Size(792, 499);
            this.uTabControl_Footer.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Flat;
            this.uTabControl_Footer.TabIndex = 1216;
            this.uTabControl_Footer.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.TopLeft;
            ultraTab3.Key = "MemoInfo";
            ultraTab3.TabPage = this.uTab_Memo;
            ultraTab3.Text = "お客様情報";
            ultraTab4.Key = "TotalInfo";
            ultraTab4.TabPage = this.uTab_Total;
            ultraTab4.Text = "履歴情報";
            this.uTabControl_Footer.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab3,
            ultraTab4});
            this.uTabControl_Footer.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(790, 472);
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.White;
            this.panel25.Controls.Add(this.btn_Close);
            this.panel25.Controls.Add(this.btnShowSalesSlipInputForm);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel25.Location = new System.Drawing.Point(0, 552);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(792, 47);
            this.panel25.TabIndex = 0;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btn_Close.Image = global::Broadleaf.Windows.Forms.Properties.Resources.end;
            this.btn_Close.Location = new System.Drawing.Point(586, 4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(201, 40);
            this.btn_Close.TabIndex = 1220;
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btnShowSalesSlipInputForm
            // 
            this.btnShowSalesSlipInputForm.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnShowSalesSlipInputForm.BackColor = System.Drawing.Color.White;
            this.btnShowSalesSlipInputForm.Image = global::Broadleaf.Windows.Forms.Properties.Resources.uriden;
            this.btnShowSalesSlipInputForm.Location = new System.Drawing.Point(385, 4);
            this.btnShowSalesSlipInputForm.Name = "btnShowSalesSlipInputForm";
            this.btnShowSalesSlipInputForm.Size = new System.Drawing.Size(200, 40);
            this.btnShowSalesSlipInputForm.TabIndex = 1219;
            this.btnShowSalesSlipInputForm.UseVisualStyleBackColor = false;
            this.btnShowSalesSlipInputForm.Click += new System.EventHandler(this.btnShowSalesSlipInputForm_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 254 ) ) ) ));
            this.panel1.Controls.Add(this.uTabControl_Footer);
            this.panel1.Controls.Add(this.panel25);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 633);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox4.Image = ( (System.Drawing.Image)( resources.GetObject("pictureBox4.Image") ) );
            this.pictureBox4.Location = new System.Drawing.Point(0, 599);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(792, 34);
            this.pictureBox4.TabIndex = 1218;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ( (System.Drawing.Image)( resources.GetObject("pictureBox1.Image") ) );
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(792, 53);
            this.pictureBox1.TabIndex = 1217;
            this.pictureBox1.TabStop = false;
            // 
            // _PMSCM00101UA_Toolbars_Dock_Area_Bottom
            // 
            this._PMSCM00101UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMSCM00101UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 158 ) ) ) ), ( (int)( ( (byte)( 190 ) ) ) ), ( (int)( ( (byte)( 245 ) ) ) ));
            this._PMSCM00101UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._PMSCM00101UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMSCM00101UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 0);
            this._PMSCM00101UA_Toolbars_Dock_Area_Bottom.Name = "_PMSCM00101UA_Toolbars_Dock_Area_Bottom";
            this._PMSCM00101UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(0, 0);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // PMSCM00101UA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(792, 633);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MAURI02001UA_Fill_Panel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject("$this.Icon") ) );
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PMSCM00101UA";
            this.Text = "お客様情報";
            this.Load += new System.EventHandler(this.PMSCM00101UA_Load);
            this.Shown += new System.EventHandler(this.PMSCM00101UA_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMSCM00101UA_FormClosing);
            this.uTab_Memo.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.uTab_Total.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.uGrid_Result ) ).EndInit();
            this.ViewButtonPanel.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.ultraTabControl1 ) ).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.uTabControl_Footer ) ).EndInit();
            this.uTabControl_Footer.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.pictureBox4 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Panel MAURI02001UA_Fill_Panel;
        private System.Windows.Forms.Timer timer_Search;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btnShowSalesSlipInputForm;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl uTabControl_Footer;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl uTab_Total;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel13;
        private Infragistics.Win.UltraWinGrid.UltraGrid uGrid_Result;
        private System.Windows.Forms.Panel ViewButtonPanel;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl uTab_Memo;
        private System.Windows.Forms.Panel panel3;
        private Infragistics.Win.Misc.UltraLabel ulabel_CustomerSnm;
        private Infragistics.Win.Misc.UltraLabel ulabel_CustomerCode;
        private System.Windows.Forms.Panel panel12;
        private Infragistics.Win.Misc.UltraLabel ulabel_Note3;
        private Infragistics.Win.Misc.UltraLabel ulabel_Note2;
        private Infragistics.Win.Misc.UltraLabel ulabel_Note1;
        private Infragistics.Win.Misc.UltraLabel ulabel_NoteTitle;
        private System.Windows.Forms.Panel panel6;
        private Infragistics.Win.Misc.UltraLabel ulabel_CustomerAgent;
        private Infragistics.Win.Misc.UltraLabel ulabel_CustomerAgentTitle;
        private System.Windows.Forms.Panel panel5;
        private Infragistics.Win.Misc.UltraLabel ulabel_CollectMoneyEmployee;
        private Infragistics.Win.Misc.UltraLabel ulabel_MoneyKindName;
        private Infragistics.Win.Misc.UltraLabel ulabel_CollectMoneyDay;
        private Infragistics.Win.Misc.UltraLabel ulabel_TotalDay;
        private Infragistics.Win.Misc.UltraLabel ulabel_TotalDayTitle;
        private Infragistics.Win.Misc.UltraLabel ulabel_CollectMoneyDayTitle;
        private Infragistics.Win.Misc.UltraLabel ulabel_CollectMoneyEmployeeTitle;
        private Infragistics.Win.Misc.UltraLabel ulabel_MoneyKindTitle;
        private System.Windows.Forms.Panel panel4;
        private Infragistics.Win.Misc.UltraLabel ulabel_OfficeFaxNo;
        private Infragistics.Win.Misc.UltraLabel ulabel_OfficeTelNo;
        private Infragistics.Win.Misc.UltraLabel ulabel_HomeTelNo;
        private Infragistics.Win.Misc.UltraLabel ulabel_Address3;
        private Infragistics.Win.Misc.UltraLabel ulabel_Address1;
        private Infragistics.Win.Misc.UltraLabel ulabel_PostNo;
        private Infragistics.Win.Misc.UltraLabel ulabel_PostNoTitle;
        private Infragistics.Win.Misc.UltraLabel ulabel_AddressTitle;
        private Infragistics.Win.Misc.UltraLabel ulabel_HomeTelNoTitle;
        private Infragistics.Win.Misc.UltraLabel ulabel_OfficeTelNoTitle;
        private Infragistics.Win.Misc.UltraLabel ulabel_OfficeFaxNoTitle;
        private Infragistics.Win.Misc.UltraLabel ulabel_CustomerCodeTitle;
        private Infragistics.Win.Misc.UltraLabel ulabel_CustomerNameTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMSCM00101UA_Toolbars_Dock_Area_Bottom;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraButton uButton_ShowDetail;
        private Infragistics.Win.Misc.UltraLabel ulabel_Address4;
        private Infragistics.Win.Misc.UltraLabel ulabel_Note4;
	}
}

