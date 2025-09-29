using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 入金引当表示ＵＩクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金引当の内容を表示します。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
    /// <br></br>
    /// <br>Update Note: 2007.01.31 18322 T.Kimura MA.NS用に変更</br>
    /// <br>                                         ・売上伝票追加</br>
    /// <br>                                         ・画面スキン変更対応</br>
    /// <br>Update Note: 2007.10.05 20081 疋田 勇人 DC.NS用に変更</br>
    /// </remarks>
	public class SFUKK01415UA : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private Infragistics.Win.UltraWinGrid.UltraGrid grdDepositAllowance;
		private System.Windows.Forms.Panel SFUKK01415UA_Fill_Panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFUKK01415UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFUKK01415UA_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFUKK01415UA_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFUKK01415UA_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager;
		private Broadleaf.Library.Windows.Forms.TLine tLine1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Broadleaf.Library.Windows.Forms.TLine tLine2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel labTotalDepositAllowance;
		private Infragistics.Win.Misc.UltraLabel labSlipNo;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// 入金引当表示ＵＩクラス コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 使用するメンバの初期化を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		public SFUKK01415UA()
		{
			InitializeComponent();

			// 入金引当表示アクセスクラス
			this.depositAlwViewAcs = new DepositAlwViewAcs();

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			// 諸費用別入金オプション
			this._optSeparateCost = false;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            
            // 企業コード
			this._enterpriseCode = "";

			// 得意先コード
			this._customerCode = 0;

			// 受注番号
			//this._acceptOdrNo = 0;     // 2007.10.15 del

            // 受注ステータス
            this._acptAnOdrStatus = 0;   // 2007.10.15 add

            // ↓ 20070131 18322 c MA.NS用に変更
			//// 伝票番号
			//this._slipNo = "";

            // 売上伝票番号
			this._salesSlipNum = "";
            // ↑ 20070131 18322 c

			// 初回フラグ
			this._FirstFlg = true;
		}
		# endregion

		# region Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		# endregion

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnClose");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnClose");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK01415UA));
            this.grdDepositAllowance = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.SFUKK01415UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.labTotalDepositAllowance = new Infragistics.Win.Misc.UltraLabel();
            this.tLine2 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.labSlipNo = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tLine1 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraStatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this._SFUKK01415UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFUKK01415UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFUKK01415UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepositAllowance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager)).BeginInit();
            this.SFUKK01415UA_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDepositAllowance
            // 
            this.grdDepositAllowance.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdDepositAllowance.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grdDepositAllowance.Location = new System.Drawing.Point(8, 68);
            this.grdDepositAllowance.Name = "grdDepositAllowance";
            this.grdDepositAllowance.Size = new System.Drawing.Size(451, 184);
            this.grdDepositAllowance.TabIndex = 0;
            this.grdDepositAllowance.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdDepositAllowance_InitializeLayout);
            // 
            // ultraToolbarsManager
            // 
            this.ultraToolbarsManager.DesignerFlags = 1;
            this.ultraToolbarsManager.DockWithinContainer = this;
            this.ultraToolbarsManager.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.Text = "標準";
            ultraToolbar1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1});
            this.ultraToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            buttonTool2.SharedProps.Caption = "戻る(&C)";
            buttonTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.ultraToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2});
            this.ultraToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager_ToolClick);
            // 
            // SFUKK01415UA_Fill_Panel
            // 
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.labTotalDepositAllowance);
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.tLine2);
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.ultraLabel4);
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.labSlipNo);
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.ultraLabel2);
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.tLine1);
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.ultraStatusBar);
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.ultraLabel1);
            this.SFUKK01415UA_Fill_Panel.Controls.Add(this.grdDepositAllowance);
            this.SFUKK01415UA_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SFUKK01415UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SFUKK01415UA_Fill_Panel.Location = new System.Drawing.Point(0, 27);
            this.SFUKK01415UA_Fill_Panel.Name = "SFUKK01415UA_Fill_Panel";
            this.SFUKK01415UA_Fill_Panel.Size = new System.Drawing.Size(466, 307);
            this.SFUKK01415UA_Fill_Panel.TabIndex = 0;
            // 
            // labTotalDepositAllowance
            // 
            appearance1.TextHAlign = Infragistics.Win.HAlign.Right;
            appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.labTotalDepositAllowance.Appearance = appearance1;
            this.labTotalDepositAllowance.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labTotalDepositAllowance.Location = new System.Drawing.Point(322, 255);
            this.labTotalDepositAllowance.Name = "labTotalDepositAllowance";
            this.labTotalDepositAllowance.Size = new System.Drawing.Size(128, 23);
            this.labTotalDepositAllowance.TabIndex = 10;
            // 
            // tLine2
            // 
            this.tLine2.BackColor = System.Drawing.Color.Transparent;
            this.tLine2.ForeColor = System.Drawing.Color.Gray;
            this.tLine2.Location = new System.Drawing.Point(234, 279);
            this.tLine2.Name = "tLine2";
            this.tLine2.Size = new System.Drawing.Size(224, 8);
            this.tLine2.TabIndex = 9;
            this.tLine2.Text = "tLine2";
            // 
            // ultraLabel4
            // 
            appearance2.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance2.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel4.Appearance = appearance2;
            this.ultraLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel4.Location = new System.Drawing.Point(234, 255);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(80, 23);
            this.ultraLabel4.TabIndex = 8;
            this.ultraLabel4.Text = "引当合計";
            // 
            // labSlipNo
            // 
            appearance3.TextHAlign = Infragistics.Win.HAlign.Right;
            appearance3.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.labSlipNo.Appearance = appearance3;
            this.labSlipNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labSlipNo.Location = new System.Drawing.Point(130, 9);
            this.labSlipNo.Name = "labSlipNo";
            this.labSlipNo.Size = new System.Drawing.Size(80, 23);
            this.labSlipNo.TabIndex = 7;
            // 
            // ultraLabel2
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance4.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.FontData.BoldAsString = "True";
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance4.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel2.Appearance = appearance4;
            this.ultraLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(8, 43);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(451, 24);
            this.ultraLabel2.TabIndex = 6;
            this.ultraLabel2.Text = "入 金 引 当 内 訳";
            // 
            // tLine1
            // 
            this.tLine1.BackColor = System.Drawing.Color.Transparent;
            this.tLine1.ForeColor = System.Drawing.Color.Gray;
            this.tLine1.Location = new System.Drawing.Point(10, 33);
            this.tLine1.Name = "tLine1";
            this.tLine1.Size = new System.Drawing.Size(224, 8);
            this.tLine1.TabIndex = 5;
            this.tLine1.Text = "tLine1";
            // 
            // ultraStatusBar
            // 
            this.ultraStatusBar.Location = new System.Drawing.Point(0, 284);
            this.ultraStatusBar.Name = "ultraStatusBar";
            this.ultraStatusBar.Size = new System.Drawing.Size(466, 23);
            this.ultraStatusBar.TabIndex = 3;
            this.ultraStatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // ultraLabel1
            // 
            appearance5.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance5.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel1.Appearance = appearance5;
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(10, 9);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 2;
            this.ultraLabel1.Text = "伝票番号";
            // 
            // _SFUKK01415UA_Toolbars_Dock_Area_Left
            // 
            this._SFUKK01415UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFUKK01415UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFUKK01415UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFUKK01415UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFUKK01415UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 27);
            this._SFUKK01415UA_Toolbars_Dock_Area_Left.Name = "_SFUKK01415UA_Toolbars_Dock_Area_Left";
            this._SFUKK01415UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 307);
            this._SFUKK01415UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager;
            // 
            // _SFUKK01415UA_Toolbars_Dock_Area_Right
            // 
            this._SFUKK01415UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFUKK01415UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFUKK01415UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFUKK01415UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFUKK01415UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(466, 27);
            this._SFUKK01415UA_Toolbars_Dock_Area_Right.Name = "_SFUKK01415UA_Toolbars_Dock_Area_Right";
            this._SFUKK01415UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 307);
            this._SFUKK01415UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager;
            // 
            // _SFUKK01415UA_Toolbars_Dock_Area_Top
            // 
            this._SFUKK01415UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFUKK01415UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFUKK01415UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SFUKK01415UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFUKK01415UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SFUKK01415UA_Toolbars_Dock_Area_Top.Name = "_SFUKK01415UA_Toolbars_Dock_Area_Top";
            this._SFUKK01415UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(466, 27);
            this._SFUKK01415UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager;
            // 
            // _SFUKK01415UA_Toolbars_Dock_Area_Bottom
            // 
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 334);
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom.Name = "_SFUKK01415UA_Toolbars_Dock_Area_Bottom";
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(466, 0);
            this._SFUKK01415UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager;
            // 
            // SFUKK01415UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(466, 334);
            this.Controls.Add(this.SFUKK01415UA_Fill_Panel);
            this.Controls.Add(this._SFUKK01415UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._SFUKK01415UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFUKK01415UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._SFUKK01415UA_Toolbars_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SFUKK01415UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "入金引当 内訳";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SFUKK01415UA_KeyDown);
            this.Load += new System.EventHandler(this.SFUKK01415UA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDepositAllowance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager)).EndInit();
            this.SFUKK01415UA_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		# region Private Menbers
		//***************************************************************
		// メンバー
		//***************************************************************
		/// <summary>入金引当表示アクセスクラス</summary>
		private DepositAlwViewAcs depositAlwViewAcs;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>諸費用別入金オプション</summary>
		private bool _optSeparateCost;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>企業コード</summary>
		private string _enterpriseCode;

		/// <summary>得意先コード</summary>
		private int _customerCode;

		///// <summary>受注番号</summary>
		//private int _acceptOdrNo;    // 2007.10.15 del

		/// <summary>受注ステータス</summary>
		private int _acptAnOdrStatus;  // 2007.10.15 add

        // ↓ 20070131 18322 c MA.NS用に変更
		///// <summary>伝票番号</summary>
		//private string _slipNo;

        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum;
        // ↑ 20070131 18322 c

		/// <summary>初回フラグ</summary>
		private bool _FirstFlg;
		# endregion

		# region public Methods
		/// <summary>
		/// 入金引当表示処理(受注伝票→入金引当)
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
		/// <param name="salesSlipNum">売上伝票番号</param>
		/// <remarks>
		/// <br>Note　　　  : 指定された受注番号に結びつく入金引当を表示します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.08.26</br>
        /// <br>Update Note : 2007.01.31 18322 T.Kimura MA.NS用に変更</br>
		/// </remarks>
        // ↓ 20070131 18322 c MA.NS用に変更
		//public void ViewAllowanceOfAcceptOdr(bool optSeparateCost, string enterpriseCode, int customerCode, int acceptOdrNo, string slipNo)
        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
        //public void ViewAllowanceOfAcceptOdr(bool optSeparateCost, string enterpriseCode, int customerCode, int acptAnOdrStatus, string salesSlipNum)
        public void ViewAllowanceOfAcceptOdr(string enterpriseCode, int customerCode, int acptAnOdrStatus, string salesSlipNum)
        // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
        // ↑ 20070131 18322 c
		{
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			// 諸費用別入金オプション
			this._optSeparateCost = optSeparateCost;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            
            // 企業コード
			this._enterpriseCode = enterpriseCode;

			// 得意先コード
			this._customerCode = customerCode;

			// 受注番号
			//this._acceptOdrNo = acceptOdrNo;       // 2007.10.15 del

            this._acptAnOdrStatus = acptAnOdrStatus; // 2007.10.15 add

            // ↓ 20070131 18322 c MA.NS用に変更
			//// 伝票番号
			//this._slipNo = slipNo;

            // 売上伝票番号
            this._salesSlipNum = salesSlipNum;
            // ↑ 20070131 18322 c

			labSlipNo.Text = "";
			ultraStatusBar.Text = "";

			// 画面表示
			this.ShowDialog();
		}
		# endregion

		# region Private Methods
		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.26</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			ImageList imageList16 = IconResourceManagement.ImageList16;

			ultraToolbarsManager.ImageListSmall = imageList16;

			// 戻るボタン
			Infragistics.Win.UltraWinToolbars.ButtonTool ButtonClose = (Infragistics.Win.UltraWinToolbars.ButtonTool)ultraToolbarsManager.Tools["btnClose"];
			if (ButtonClose != null)
			{
				ButtonClose.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
			}
		}
		
		/// <summary>
		/// 入金グリッド初期設定処理処理
		/// </summary>
		/// <param name="grd">対象グリッド</param>
		/// <remarks>
		/// <br>Note       : 入金グリッドの初期設定を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.26</br>
		/// </remarks>
		private void InitializeDepositAllowanceList(Infragistics.Win.UltraWinGrid.UltraGrid grd)
		{
			// 列幅をオートに設定
            grd.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;

			// 行選択設定 行選択無しモード(アクティブのみ)
			grd.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
			grd.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			grd.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;

			// グリッド全体の外観設定
            // ↓ 20070131 18322 d MA.NS用に変更
			//grd.DisplayLayout.Appearance.BackColor = Color.White;
			//grd.DisplayLayout.Appearance.BackColor2 = Color.FromArgb(198, 219, 255);
			//grd.DisplayLayout.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            // ↑ 20070131 18322 d

			// 行選択モードの設定
			grd.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

			// 行の外観設定
			grd.DisplayLayout.Override.RowAppearance.BackColor = Color.White;

			// 1行おきの外観設定
			grd.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;

			// 選択行の外観設定
			grd.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
			grd.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
			grd.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

			// アクティブ行の外観設定
			grd.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
			grd.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
			grd.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

			// ヘッダーの外観設定
			grd.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
			grd.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			grd.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			grd.DisplayLayout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
			grd.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			grd.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			grd.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			grd.DisplayLayout.Override.HeaderAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

			// 行セレクターの外観設定
			grd.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
			grd.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
			grd.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

			// 行フィルターの設定
//			grd.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
//			grd.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
//			grd.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;

			// 垂直方向のスクロールスタイル
			grd.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;

			// 複数画面表示(スプリッター)の表示設定
			grd.DisplayLayout.MaxRowScrollRegions = 1;

			// スクロールバー最終行制御
			grd.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;

			// ヘッダークリックアクション設定
			grd.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;

			// フィルタの使用設定
//			grd.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

			// 「固定列」プッシュピンアイコンを消す
			grd.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

			// 列幅の設定
			grd.DisplayLayout.Bands[DepositAlwViewAcs.ctDepositAlwDataTable].Columns[DepositAlwViewAcs.ctDepositSlipNo].Width	= 180;					// 入金番号
		}

		/// <summary>
		/// 入金引当グリッドデータビューバインド処理
		/// </summary>
		/// <param></param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 入金引当グリッドにデータビューをバインドします。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void BindingDsDepositAlwView()
		{
			// 入金引当グリッドにViewをバインドする
			grdDepositAllowance.DataSource = depositAlwViewAcs.GetDsDepositAlwInfo().Tables[DepositAlwViewAcs.ctDepositAlwDataTable].DefaultView;
		}
		
		/// <summary>
		/// 入金引当グリッドビュー設定処理
		/// </summary>
		/// <param></param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 入金引当グリッドにデータビューをバインドします。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void SettingDepositAlwView()
		{
			Infragistics.Win.UltraWinGrid.UltraGridBand bdDepositAlw = grdDepositAllowance.DisplayLayout.Bands[DepositAlwViewAcs.ctDepositAlwDataTable];
			
			// 入金引当グリッド列の書式設定
			bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositSlipNo].Format				= "000000000";			// 入金番号
			// bdDepositAlw.Columns[DepositAlwViewAcs.ctAcceptAnOrderNo].Format			= "#########";			// 受注番号  // 2007.10.05 hikita del
            // ↓ 20070131 18322 c MA.NS用に変更
			//bdDepositAlw.Columns[DepositAlwViewAcs.ctAcpOdrDepositAlwc].Format			= "###,###,###,##0";	// 入金引当額 受注
			//bdDepositAlw.Columns[DepositAlwViewAcs.ctVarCostDepoAlwc].Format			= "###,###,###,##0";	// 入金引当額 諸費用
            // ↑ 20070131 18322 c
			bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositAllowance].Format			= "###,###,###,##0";	// 入金引当額 共通
			bdDepositAlw.Columns[DepositAlwViewAcs.ctReconcileAddUpADate].Format		= "####/##/##";			// 引当計上日

			bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositSlipNo].CellAppearance.TextHAlign		= Infragistics.Win.HAlign.Right;	// 入金伝票番号
            // ↓ 20070131 18322 c MA.NS用に変更
			//bdDepositAlw.Columns[DepositAlwViewAcs.ctAcpOdrDepositAlwc].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Right;	// 入金引当額 受注
			//bdDepositAlw.Columns[DepositAlwViewAcs.ctVarCostDepoAlwc].CellAppearance.TextHAlign		= Infragistics.Win.HAlign.Right;	// 入金引当額 諸費用
            // ↑ 20070131 18322 c
			bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositAllowance].CellAppearance.TextHAlign	= Infragistics.Win.HAlign.Right;	// 入金引当額 共通

			bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositSlipNo].Header.Caption			= "入金番号";		// 入金番号
			// bdDepositAlw.Columns[DepositAlwViewAcs.ctAcceptAnOrderNo].Header.Caption		= "受注番号";		// 受注伝票番号 // 2007.10.10 hikita del
            // ↓ 20070131 18322 c MA.NS用に変更
			//bdDepositAlw.Columns[DepositAlwViewAcs.ctAcpOdrDepositAlwc].Header.Caption		= "引当額(受)";		// 入金引当額 受注
			//bdDepositAlw.Columns[DepositAlwViewAcs.ctVarCostDepoAlwc].Header.Caption		= "引当額(諸)";		// 入金引当額 諸費用
            // ↑ 20070131 18322 c
			bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositAllowance].Header.Caption		= "引当額";			// 入金引当額 共通
			bdDepositAlw.Columns[DepositAlwViewAcs.ctReconcileDateDisp].Header.Caption		= "引当日";			// 引当日
			bdDepositAlw.Columns[DepositAlwViewAcs.ctReconcileAddUpADate].Header.Caption	= "引当計上日";		// 引当計上日

            // ↓ 20070131 18322 c MA.NS用に変更
            #region SF 諸費用別入金オプションによる表示制御（全てコメントアウト）
            //// 諸費用別入金オプションによる表示制御
			//if (this._optSeparateCost == true)
			//{
			//	bdDepositAlw.Columns[DepositAlwViewAcs.ctAcpOdrDepositAlwc].Hidden		= false;				// 入金引当額 受注
			//	bdDepositAlw.Columns[DepositAlwViewAcs.ctVarCostDepoAlwc].Hidden		= false;				// 入金引当額 諸費用
			//	bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositAllowance].Hidden		= true;					// 入金引当額 共通
			//}
			//else
			//{
			//	bdDepositAlw.Columns[DepositAlwViewAcs.ctAcpOdrDepositAlwc].Hidden		= true;					// 入金引当額 受注
			//	bdDepositAlw.Columns[DepositAlwViewAcs.ctVarCostDepoAlwc].Hidden		= true;					// 入金引当額 諸費用
			//	bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositAllowance].Hidden		= false;				// 入金引当額 共通
            //}
            #endregion

			// 入金引当額 共通
            bdDepositAlw.Columns[DepositAlwViewAcs.ctDepositAllowance].Hidden = false;
            // ↑ 20070131 18322 c

			// 常に非表示
			bdDepositAlw.Columns[DepositAlwViewAcs.ctReconcileDate].Hidden				= true;					// 引当日
			// bdDepositAlw.Columns[DepositAlwViewAcs.ctAcceptAnOrderNo].Hidden			= true;					// 受注番号  // 2007.10.05 hikita del
			bdDepositAlw.Columns[DepositAlwViewAcs.ctReconcileAddUpADate].Hidden		= true;					// 引当計上日

			// 入金グリッドを展開する (１行もデータが無くてもタイトルを表示する為)
			grdDepositAllowance.Rows.ExpandAll(true);
		}
		# endregion

		# region Control Events
		/// <summary>
		/// 画面ロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込む時に発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.08.26</br>
		/// </remarks>
		private void SFUKK01415UA_Load(object sender, System.EventArgs e)
		{
			if (this._FirstFlg == true)
			{
				// 画面初期設定処理
				this.ScreenInitialSetting();

				// 入金引当 DataSet Table 作成処理
				depositAlwViewAcs.CreateDepositAlwDataTable();

				// 入金引当グリッドデータビューバインド処理
				this.BindingDsDepositAlwView();

				this._FirstFlg = false;
			}
			else
			{
				// 入金引当DataSet初期化処理
				depositAlwViewAcs.ClearDsDepositAlwInfo();
			}
			
			// 入金引当グリッドビュー設定処理
			this.SettingDepositAlwView();

            // ↓ 20070131 18322 c MA.NS用に変更
			//// 伝票番号
			//labSlipNo.Text = _slipNo;

			// 伝票番号
			labSlipNo.Text = _salesSlipNum;
            // ↑ 20070131 18322 c

			labTotalDepositAllowance.Text = "";

			// 入金引当データ取得処理
			string message;
            int st = depositAlwViewAcs.SearchAllowanceOfAcceptOdrNo(_enterpriseCode, _customerCode, _acptAnOdrStatus, _salesSlipNum, out message);
			if (st == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
                // ↓ 20070131 18322 c MA.NS用に変更
				//ultraStatusBar.Text = "この受注伝票には、入金引当は行われていません。";

				ultraStatusBar.Text = "この売上伝票には、入金引当は行われていません。";
                // ↑ 20070131 18322 c
			}
			else if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// エラー発生
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, "入金引当の読込処理に失敗しました。" + "\r\n\r\n" + message, st, MessageBoxButtons.OK);
			}

			// 入金引当合計
			labTotalDepositAllowance.Text = depositAlwViewAcs.GetTotalDepositAllowance().ToString("###,###,###,##0");
		}

		/// <summary>
		/// 入金引当グリッド初期化 イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : データソースからコントロールにデータがロードされるときなど、
		///                   表示レイアウトが初期化されるときに発生します。 </br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.08.26</br>
		/// </remarks>
		private void grdDepositAllowance_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			// 入金引当グリッド初期設定処理
			this.InitializeDepositAllowanceList(grdDepositAllowance);
		}

		/// <summary>
		/// フォームＫＥＹ押下イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note       : フォーム上でキーを押された時に発生します。</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2006.06.07</br>
		/// </remarks>
		private void SFUKK01415UA_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		/// <summary>
		/// ツールバーボタン押下イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : ツールバーをクリックした時に発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void ultraToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
					// 戻る
				case "btnClose":
				{
					this.Close();
					break;
				}
			}		
		}
		# endregion
	}
}
