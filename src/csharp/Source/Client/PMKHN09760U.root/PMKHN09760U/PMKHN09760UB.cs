using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 単票表示フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : マスタメンテナンス情報の単票表示を行います。</br>
    /// <br>Programmer : 陳永康</br>
    /// <br>Date       : 2014/12/23</br>
	/// <br></br>
	/// </remarks>
    internal class PMKHN09760UB
        : System.Windows.Forms.Form,
        IOperationAuthorityControllable
	{
		# region Private Members (Component)

		private System.Windows.Forms.Panel ViewButtonPanel;
		private Infragistics.Win.Misc.UltraButton Print_Button;
		private Infragistics.Win.Misc.UltraButton Modify_Button;
		private Infragistics.Win.Misc.UltraButton Close_Button;
		private System.Windows.Forms.Timer Init_Timer;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09760UB_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09760UB_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09760UB_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09760UB_Toolbars_Dock_Area_Bottom;
		private WebBrowser ViewWebBrowser;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// 単票表示フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 単票表示フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		internal PMKHN09760UB()
		{
			InitializeComponent();
		}
		# endregion

		# region Dospose
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Main_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Close_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Modify_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool3 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Print_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool4 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Close_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool5 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Modify_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool6 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Print_ControlContainerTool");
            this.Close_Button = new Infragistics.Win.Misc.UltraButton();
            this.Modify_Button = new Infragistics.Win.Misc.UltraButton();
            this.Print_Button = new Infragistics.Win.Misc.UltraButton();
            this.ViewButtonPanel = new System.Windows.Forms.Panel();
            this.Init_Timer = new System.Windows.Forms.Timer(this.components);
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._PMKHN09760UB_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09760UB_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09760UB_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09760UB_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ViewWebBrowser = new System.Windows.Forms.WebBrowser();
            this.ViewButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // Close_Button
            // 
            this.Close_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Close_Button.Location = new System.Drawing.Point(0, 0);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(90, 27);
            this.Close_Button.TabIndex = 0;
            this.Close_Button.Text = "閉じる(&C)";
            this.Close_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // Modify_Button
            // 
            this.Modify_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Modify_Button.Location = new System.Drawing.Point(90, 0);
            this.Modify_Button.Name = "Modify_Button";
            this.Modify_Button.Size = new System.Drawing.Size(75, 27);
            this.Modify_Button.TabIndex = 1;
            this.Modify_Button.Text = "修正(&E)";
            this.Modify_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Modify_Button.Click += new System.EventHandler(this.Modify_Button_Click);
            // 
            // Print_Button
            // 
            this.Print_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Print_Button.Location = new System.Drawing.Point(170, 0);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.Size = new System.Drawing.Size(80, 27);
            this.Print_Button.TabIndex = 2;
            this.Print_Button.Text = "印刷(&P)";
            this.Print_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Print_Button.Click += new System.EventHandler(this.Print_Button_Click);
            // 
            // ViewButtonPanel
            // 
            this.ViewButtonPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.ViewButtonPanel.Controls.Add(this.Print_Button);
            this.ViewButtonPanel.Controls.Add(this.Modify_Button);
            this.ViewButtonPanel.Controls.Add(this.Close_Button);
            this.ViewButtonPanel.Location = new System.Drawing.Point(0, 60);
            this.ViewButtonPanel.Name = "ViewButtonPanel";
            this.ViewButtonPanel.Size = new System.Drawing.Size(759, 27);
            this.ViewButtonPanel.TabIndex = 0;
            this.ViewButtonPanel.Visible = false;
            // 
            // Init_Timer
            // 
            this.Init_Timer.Interval = 1;
            this.Init_Timer.Tick += new System.EventHandler(this.Init_Timer_Tick);
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            appearance1.BackColor = System.Drawing.Color.GhostWhite;
            this.ultraToolbarsManager1.Appearance = appearance1;
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.LockToolbars = true;
            this.ultraToolbarsManager1.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.ShowQuickCustomizeButton = false;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            controlContainerTool1.ControlName = "Close_Button";
            controlContainerTool2.ControlName = "Modify_Button";
            controlContainerTool3.ControlName = "Print_Button";
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool1,
            controlContainerTool2,
            controlContainerTool3});
            ultraToolbar1.Text = "標準";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            controlContainerTool4.ControlName = "Close_Button";
            controlContainerTool4.SharedProps.Caption = "Close_ControlContainerTool";
            controlContainerTool5.ControlName = "Modify_Button";
            controlContainerTool5.SharedProps.Caption = "Modify_ControlContainerTool";
            controlContainerTool6.ControlName = "Print_Button";
            controlContainerTool6.SharedProps.Caption = "Print_ControlContainerTool";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool4,
            controlContainerTool5,
            controlContainerTool6});
            this.ultraToolbarsManager1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // _PMKHN09760UB_Toolbars_Dock_Area_Left
            // 
            this._PMKHN09760UB_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09760UB_Toolbars_Dock_Area_Left.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._PMKHN09760UB_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.GhostWhite;
            this._PMKHN09760UB_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._PMKHN09760UB_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09760UB_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 54);
            this._PMKHN09760UB_Toolbars_Dock_Area_Left.Name = "_PMKHN09760UB_Toolbars_Dock_Area_Left";
            this._PMKHN09760UB_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 616);
            this._PMKHN09760UB_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _PMKHN09760UB_Toolbars_Dock_Area_Right
            // 
            this._PMKHN09760UB_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09760UB_Toolbars_Dock_Area_Right.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._PMKHN09760UB_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.GhostWhite;
            this._PMKHN09760UB_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._PMKHN09760UB_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09760UB_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(759, 54);
            this._PMKHN09760UB_Toolbars_Dock_Area_Right.Name = "_PMKHN09760UB_Toolbars_Dock_Area_Right";
            this._PMKHN09760UB_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 616);
            this._PMKHN09760UB_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _PMKHN09760UB_Toolbars_Dock_Area_Top
            // 
            this._PMKHN09760UB_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09760UB_Toolbars_Dock_Area_Top.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._PMKHN09760UB_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.GhostWhite;
            this._PMKHN09760UB_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._PMKHN09760UB_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09760UB_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._PMKHN09760UB_Toolbars_Dock_Area_Top.Name = "_PMKHN09760UB_Toolbars_Dock_Area_Top";
            this._PMKHN09760UB_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(759, 54);
            this._PMKHN09760UB_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _PMKHN09760UB_Toolbars_Dock_Area_Bottom
            // 
            this._PMKHN09760UB_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09760UB_Toolbars_Dock_Area_Bottom.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._PMKHN09760UB_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.GhostWhite;
            this._PMKHN09760UB_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._PMKHN09760UB_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09760UB_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 670);
            this._PMKHN09760UB_Toolbars_Dock_Area_Bottom.Name = "_PMKHN09760UB_Toolbars_Dock_Area_Bottom";
            this._PMKHN09760UB_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(759, 0);
            this._PMKHN09760UB_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ViewWebBrowser
            // 
            this.ViewWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewWebBrowser.Location = new System.Drawing.Point(0, 54);
            this.ViewWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.ViewWebBrowser.Name = "ViewWebBrowser";
            this.ViewWebBrowser.Size = new System.Drawing.Size(759, 616);
            this.ViewWebBrowser.TabIndex = 6;
            // 
            // PMKHN09760UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(759, 670);
            this.Controls.Add(this.ViewButtonPanel);
            this.Controls.Add(this.ViewWebBrowser);
            this.Controls.Add(this._PMKHN09760UB_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMKHN09760UB_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._PMKHN09760UB_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._PMKHN09760UB_Toolbars_Dock_Area_Bottom);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PMKHN09760UB";
            this.Load += new System.EventHandler(this.PMKHN09760UB_Load);
            this.ViewButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		# region Private Members
		private bool _navigateFlg = false;
		private PMKHN09760UA _owningForm;
		private IMasterMaintenanceSingleType _singleTypeObj;
		private ProgramItem _programItemObj;

        /// <summary>閉じるツールボタンのキー</summary>
        private const string CLOSE_TOOL_BUTTON_KEY = "Close_ControlContainerTool";
        /// <summary>修正ツールボタンのキー</summary>
        private const string MODIFY_TOOL_BUTTON_KEY = "Modify_ControlContainerTool";
        /// <summary>印刷ツールボタンのキー</summary>
        private const string PRINT_TOOL_BUTTON_KEY = "Print_ControlContainerTool";

        #region <IOperationAuthorityControllable メンバ/>

        /// <see cref="IOperationAuthorityControllable"/>
        public OperationAuthorityController OperationController
        {
            get { return _operationController; }
            set { _operationController = value; }
        }

        #endregion  // <IOperationAuthorityControllable メンバ/>

        /// <summary>操作権限の制御オブジェクト</summary>
        private OperationAuthorityController _operationController;
        /// <summary>
        /// 操作権限の制御オブジェクトを取得します。
        /// </summary>
        /// <value>操作権限の制御オブジェクト</value>
        /// <exception cref="InvalidCastException">操作権限の制御オブジェクトの型が合っていません</exception>
        protected MasMainController MyOpeCtrl
        {
            get { return (MasMainController)_operationController; }
        }

        # endregion

		# region Internal Methods
		/// <summary>
		/// 画面表示処理
		/// </summary>
		/// <param name="owningForm">親フォームのインスタンス</param>
		/// <param name="programItemObj">プログラム情報管理クラスのインスタンス</param>
		/// <remarks>
		/// <br>Note       : 親フォームのインスタンスを受け取り、自身のフォームをモードレスで表示します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		internal void ShowMe(PMKHN09760UA owningForm, ProgramItem programItemObj)
		{
			this._owningForm = owningForm;
			this._programItemObj = programItemObj;
			this._singleTypeObj = (IMasterMaintenanceSingleType)programItemObj.CustomForm;
			this.Show();
		}

		/// <summary>
		/// ウェブブラウザーコントロール書込処理
		/// </summary>
		/// <param name="htmlCode">HTMLコード</param>
		/// <remarks>
		/// <br>Note       : 引数のHTMLコードをWebBrouzerコントロールに書込み、HTMLを表示します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		internal void WebBrowserWrite(string htmlCode)
		{
			// 起動後１回だけblankをナビゲートする
			if (this._navigateFlg == false)
			{
				object o = Type.Missing;
				this.ViewWebBrowser.Navigate("about:blank");
				this._navigateFlg = true;
			}

			HtmlDocument htmlDocument = this.ViewWebBrowser.Document.OpenNew(false);
			htmlDocument.Write(htmlCode);
		}

		/// <summary>
		/// プリンタボタン表示非表示設定処理
		/// </summary>
		/// <param name="canPrint">表示非表示フラグ</param>
		/// <remarks>
		/// <br>Note       : プリンタボタンの表示非表示を設定します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		internal void SetPrintButtonVisible(bool canPrint)
		{
			this.Print_Button.Visible = canPrint;
		}
		# endregion

		# region Private Methods
		/// <summary>
		///  画面初期処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面起動時の初期処理を行います。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void InitialDisplay()
		{
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Close_Button.ImageList = imageList16;
			this.Modify_Button.ImageList = imageList16;
			this.Print_Button.ImageList = imageList16;
			this.Close_Button.Appearance.Image = Size16_Index.CLOSE;
			this.Modify_Button.Appearance.Image = Size16_Index.MODIFY;
			this.Print_Button.Appearance.Image = Size16_Index.PRINT;

			this._singleTypeObj.UnDisplaying += new MasterMaintenanceSingleTypeUnDisplayingEventHandler(MasterMaintenance_UnDisplaying);
			((Form)this._singleTypeObj).VisibleChanged +=new EventHandler(this.PMKHN09760UB_VisibleChanged);

			this.Print_Button.Visible = this._singleTypeObj.CanPrint;
			this.ultraToolbarsManager1.Tools["Print_ControlContainerTool"].SharedProps.Visible = this._singleTypeObj.CanPrint;
		}

		/// <summary>
		/// 画面非表示イベント用メソッド
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="me">イベントパラメータクラス</param>
		/// <remarks>
		/// <br>Note       : マスタメンテナンスの画面非表示イベント用メソッドです。
		///					 ツリーチェックボックスのチェック処理を実行します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void MasterMaintenance_UnDisplaying(object sender, MasterMaintenanceUnDisplayingEventArgs me)
		{
			// 引数のDialogResultがOKまたはYesの場合は、ノードのチェックボックスに
			// チェックを付ける
			if ((me.DialogResult == DialogResult.OK) || (me.DialogResult == DialogResult.Yes))
			{
				this._owningForm.TreeNodeCheckBoxChecked(this);

				string htmlCode = _singleTypeObj.GetHtmlCode();
				this.WebBrowserWrite(htmlCode);
			}
		}

		/// <summary>
		/// 画面表示変更後発生イベント用メソッド
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <remarks>
		/// <br>Note       : 子画面のVisibleが変更になった後に発生します。
		///					 ボタンの有効無効チェックを行います。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void PMKHN09760UB_VisibleChanged(object sender, EventArgs e)
		{
			if (((Form)this._singleTypeObj).Visible == true)
			{
				this.Close_Button.Enabled   = false;
				this.Modify_Button.Enabled  = false;
				this.Print_Button.Enabled   = false;
			}
			else
			{
				this.Close_Button.Enabled   = true;
				this.Modify_Button.Enabled  = true;
				this.Print_Button.Enabled   = true;
			}
		}
		# endregion

		# region Control Events

        /// <summary>
        /// 操作権限の制御を開始します。
        /// </summary>
        /// <remarks>
        /// </remarks>
        private void BeginControllingByOperationAuthority()
        {
            // ボタンを設定
            MyOpeCtrl.AddControlItem(MasMainFrameOpeCode.Modify, this.Modify_Button, false);
            MyOpeCtrl.AddControlItem(MasMainFrameOpeCode.Print, this.Print_Button, false);

            // ツールバーを設定
            List<ToolButtonInfo> toolButtonInfoList = new List<ToolButtonInfo>();
            toolButtonInfoList.Add(new MasMainToolButtonInfo(MODIFY_TOOL_BUTTON_KEY, MasMainFrameOpeCode.Modify, false));
            toolButtonInfoList.Add(new MasMainToolButtonInfo(PRINT_TOOL_BUTTON_KEY, MasMainFrameOpeCode.Print, false));
            MyOpeCtrl.AddControlItem(this.ultraToolbarsManager1, toolButtonInfoList);

            // 操作権限の制御を開始
            MyOpeCtrl.BeginControl();
        }

		/// <summary>
		/// Form.Load イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　 : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void PMKHN09760UB_Load(object sender, System.EventArgs e)
		{
			InitialDisplay();

            BeginControllingByOperationAuthority();

            Init_Timer.Enabled = true;
		}

		/// <summary>
		/// Control.Click イベント(Modify_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　 : 修正ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void Modify_Button_Click(object sender, System.EventArgs e)
		{
			if (this.ultraToolbarsManager1.Tools["Modify_ControlContainerTool"].SharedProps.Visible == false)
			{
				return;
			}

			this._singleTypeObj.CanClose = false;

			Form customForm = (Form)this._singleTypeObj;
			customForm.StartPosition = FormStartPosition.CenterScreen;
			customForm.Owner = this._owningForm;
			customForm.Show();
		}

		/// <summary>
		/// Control.Click イベント(Close_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　 : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		internal void Close_Button_Click(object sender, System.EventArgs e)
		{
			Form customForm = (Form)this._singleTypeObj;
			customForm.Close();
			this.Close();
		}

		/// <summary>
		/// Control.Click イベント(PrintButton)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　 : 印刷ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void Print_Button_Click(object sender, System.EventArgs e)
		{
			if (this.ultraToolbarsManager1.Tools["Print_ControlContainerTool"].SharedProps.Visible == false)
			{
				return;
			}

			this._singleTypeObj.Print();
		}

		/// <summary>
		/// Timer.Tick イベント(Init_Timer_Tick)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　 : 指定された間隔の時間が経過したときに発生します。
		///					　この処理は、システムが提供するスレッド プールスレッドで実行されます。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void Init_Timer_Tick(object sender, System.EventArgs e)
		{
			Init_Timer.Enabled = false;

			string htmlCode = _singleTypeObj.GetHtmlCode();
			this.WebBrowserWrite(htmlCode);

            SetFocusOnParentTabActive();
		}
		# endregion
        
        /// <summary>
        /// 親タブがアクティブになった場合のフォーカス制御
        /// </summary>
        public void SetFocusOnParentTabActive()
        {
            this.Focus();
            if ( Modify_Button.Visible == true && Modify_Button.Enabled == true )
            {
                Modify_Button.Focus();
            }
            else
            {
                Close_Button.Focus();
            }
        }
    }
}
