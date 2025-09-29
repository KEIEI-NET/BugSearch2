using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;     // ADD 陳健 K2014/02/06
using Broadleaf.Application.Resources; // ADD 陳健 K2014/02/06

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 得意先画面用ユーザー設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先画面用のユーザー設定フォームクラスです。</br>
	/// <br>Programmer : 22018 鈴木正臣</br>
	/// <br>Date       : 2008.04.30</br>
    /// <br>UpdateNote : 2011/08/04 caohh</br>
    /// <br>             NSユーザー改良要望一覧連番265の対応</br>
    /// <br>UpdateNote : K2014/02/06 陳健</br>
    /// <br>             前橋京和商会個別 得意先マスタ改良対応</br>
    /// <br>UpdateNote : 2014/03/07 陳健</br>
    /// <br>             前橋京和商会個別 Redmine#42174 初期表示タブの対応</br>
    /// <br>UpdateNote : 2021/05/10 梶谷貴士</br>
    /// <br>             得意先情報ガイド表示PKG対応</br>
	/// </remarks>
	public class CustomerInputSetUp : System.Windows.Forms.Form
	{
		# region Components
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.UltraWinTabControl.UltraTabControl UserSetup_TabControl;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
		private Broadleaf.Library.Windows.Forms.TLine tLine1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		internal Infragistics.Win.UltraWinEditors.UltraOptionSet InputType_UOptionSet;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TComboEditor FirstDisplayTab_TComboEditor;
		private Broadleaf.Library.Windows.Forms.TLine tLine4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Broadleaf.Library.Windows.Forms.TLine tLine2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private System.ComponentModel.IContainer components;
		# endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// 得意先画面用ユーザー設定クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先画面用ユーザー設定クラスの初期処理を行います。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
		/// <br>Date       : 2008.04.30</br>
		/// <br></br>
		/// </remarks>
		public CustomerInputSetUp()
		{
			InitializeComponent();

			// 変数初期化
			this._imageList16 = IconResourceManagement.ImageList16;
			this._customerInputConstructionAcs = new CustomerInputConstructionAcs();

			this.InputType_UOptionSet.CheckedIndex = this._customerInputConstructionAcs.InputType;
			this.FirstDisplayTab_TComboEditor.Value = this._customerInputConstructionAcs.FirstDisplayTab;
            this.tComboEditor1.Value = this._customerInputConstructionAcs.KeepOnInfoSetting; // ADD caohh 2011/09/04
		}
		# endregion

		// ===================================================================================== //
		// 破棄
		// ===================================================================================== //
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
        
		// ===================================================================================== //
		// Windows フォーム デザイナで生成されたコード
		// ===================================================================================== //
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerInputSetUp));
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.FirstDisplayTab_TComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tLine4 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.InputType_UOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.tLine1 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.tComboEditor1 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.tLine2 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.UserSetup_TabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FirstDisplayTab_TComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputType_UOptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserSetup_TabControl)).BeginInit();
            this.UserSetup_TabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.FirstDisplayTab_TComboEditor);
            this.ultraTabPageControl1.Controls.Add(this.tLine4);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel5);
            this.ultraTabPageControl1.Controls.Add(this.InputType_UOptionSet);
            this.ultraTabPageControl1.Controls.Add(this.tLine1);
            this.ultraTabPageControl1.Controls.Add(this.ultraLabel1);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 24);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(350, 170);
            // 
            // FirstDisplayTab_TComboEditor
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FirstDisplayTab_TComboEditor.ActiveAppearance = appearance1;
            this.FirstDisplayTab_TComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FirstDisplayTab_TComboEditor.ItemAppearance = appearance2;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "連絡先情報";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "備考情報";
            valueListItem3.DataValue = 2;
            valueListItem3.DisplayText = "Ｅメール情報";
            valueListItem4.DataValue = 3;
            valueListItem4.DisplayText = "口座情報";
            valueListItem5.DataValue = 4;
            valueListItem5.DisplayText = "伝票・請求書情報";
            valueListItem6.DataValue = 6;
            valueListItem6.DisplayText = "メモ情報";
            this.FirstDisplayTab_TComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5,
            valueListItem6});
            this.FirstDisplayTab_TComboEditor.Location = new System.Drawing.Point(20, 129);
            this.FirstDisplayTab_TComboEditor.Name = "FirstDisplayTab_TComboEditor";
            this.FirstDisplayTab_TComboEditor.Size = new System.Drawing.Size(318, 24);
            this.FirstDisplayTab_TComboEditor.TabIndex = 1;
            // 
            // tLine4
            // 
            this.tLine4.BackColor = System.Drawing.Color.Transparent;
            this.tLine4.ForeColor = System.Drawing.Color.Silver;
            this.tLine4.Location = new System.Drawing.Point(118, 113);
            this.tLine4.Name = "tLine4";
            this.tLine4.Size = new System.Drawing.Size(219, 10);
            this.tLine4.TabIndex = 10;
            this.tLine4.Text = "tLine4";
            // 
            // ultraLabel5
            // 
            appearance3.ForeColor = System.Drawing.Color.Blue;
            this.ultraLabel5.Appearance = appearance3;
            this.ultraLabel5.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel5.Location = new System.Drawing.Point(10, 105);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(98, 17);
            this.ultraLabel5.TabIndex = 9;
            this.ultraLabel5.Text = "初期表示タブ";
            // 
            // InputType_UOptionSet
            // 
            this.InputType_UOptionSet.BackColor = System.Drawing.Color.Transparent;
            this.InputType_UOptionSet.BackColorInternal = System.Drawing.Color.Transparent;
            this.InputType_UOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.InputType_UOptionSet.CheckedIndex = 0;
            appearance4.TextHAlignAsString = "Left";
            this.InputType_UOptionSet.ItemAppearance = appearance4;
            valueListItem7.DataValue = 0;
            valueListItem7.DisplayText = "画面サイズによる自動変更";
            valueListItem8.DataValue = 1;
            valueListItem8.DisplayText = "タブ形式固定";
            valueListItem9.DataValue = 2;
            valueListItem9.DisplayText = "スクロール形式固定";
            this.InputType_UOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem7,
            valueListItem8,
            valueListItem9});
            this.InputType_UOptionSet.ItemSpacingVertical = 5;
            this.InputType_UOptionSet.Location = new System.Drawing.Point(20, 32);
            this.InputType_UOptionSet.Name = "InputType_UOptionSet";
            this.InputType_UOptionSet.Size = new System.Drawing.Size(311, 67);
            this.InputType_UOptionSet.TabIndex = 0;
            this.InputType_UOptionSet.Text = "画面サイズによる自動変更";
            // 
            // tLine1
            // 
            this.tLine1.BackColor = System.Drawing.Color.Transparent;
            this.tLine1.ForeColor = System.Drawing.Color.Silver;
            this.tLine1.Location = new System.Drawing.Point(90, 18);
            this.tLine1.Name = "tLine1";
            this.tLine1.Size = new System.Drawing.Size(248, 3);
            this.tLine1.TabIndex = 1;
            this.tLine1.Text = "tLine1";
            // 
            // ultraLabel1
            // 
            appearance9.ForeColor = System.Drawing.Color.Blue;
            this.ultraLabel1.Appearance = appearance9;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Location = new System.Drawing.Point(10, 10);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(67, 17);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "入力方法";
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.tComboEditor1);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel3);
            this.ultraTabPageControl2.Controls.Add(this.tLine2);
            this.ultraTabPageControl2.Controls.Add(this.ultraLabel2);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(350, 170);
            // 
            // tComboEditor1
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor1.ActiveAppearance = appearance7;
            this.tComboEditor1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor1.ItemAppearance = appearance11;
            valueListItem10.DataValue = "0";
            valueListItem10.DisplayText = "得意先コード以外を保持";
            valueListItem11.DataValue = "1";
            valueListItem11.DisplayText = "得意先コードを保持";
            this.tComboEditor1.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem10,
            valueListItem11});
            this.tComboEditor1.Location = new System.Drawing.Point(142, 35);
            this.tComboEditor1.Name = "tComboEditor1";
            this.tComboEditor1.Size = new System.Drawing.Size(196, 24);
            this.tComboEditor1.TabIndex = 5;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel3.Location = new System.Drawing.Point(12, 39);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(130, 17);
            this.ultraLabel3.TabIndex = 4;
            this.ultraLabel3.Text = "前回情報保持設定";
            // 
            // tLine2
            // 
            this.tLine2.BackColor = System.Drawing.Color.Transparent;
            this.tLine2.ForeColor = System.Drawing.Color.Silver;
            this.tLine2.Location = new System.Drawing.Point(130, 18);
            this.tLine2.Name = "tLine2";
            this.tLine2.Size = new System.Drawing.Size(208, 3);
            this.tLine2.TabIndex = 3;
            this.tLine2.Text = "tLine2";
            // 
            // ultraLabel2
            // 
            appearance10.ForeColor = System.Drawing.Color.Blue;
            this.ultraLabel2.Appearance = appearance10;
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.Location = new System.Drawing.Point(8, 10);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(117, 17);
            this.ultraLabel2.TabIndex = 2;
            this.ultraLabel2.Text = "保存後動作設定";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.Location = new System.Drawing.Point(264, 213);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(96, 26);
            this.Cancel_Button.TabIndex = 6;
            this.Cancel_Button.Text = "キャンセル";
            // 
            // Ok_Button
            // 
            this.Ok_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Ok_Button.Location = new System.Drawing.Point(160, 213);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(96, 26);
            this.Ok_Button.TabIndex = 5;
            this.Ok_Button.Text = "ＯＫ";
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // UserSetup_TabControl
            // 
            this.UserSetup_TabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.UserSetup_TabControl.Controls.Add(this.ultraTabPageControl1);
            this.UserSetup_TabControl.Controls.Add(this.ultraTabPageControl2);
            this.UserSetup_TabControl.Location = new System.Drawing.Point(10, 10);
            this.UserSetup_TabControl.Name = "UserSetup_TabControl";
            this.UserSetup_TabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.UserSetup_TabControl.Size = new System.Drawing.Size(354, 197);
            this.UserSetup_TabControl.TabIndex = 4;
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.BackColor2 = System.Drawing.Color.GhostWhite;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ultraTab1.Appearance = appearance6;
            ultraTab1.Key = "Window";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "ウィンドウ制御";
            appearance8.BackColor = System.Drawing.Color.White;
            appearance8.BackColor2 = System.Drawing.Color.GhostWhite;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ultraTab2.Appearance = appearance8;
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "前回情報制御";
            this.UserSetup_TabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(350, 170);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // CustomerInputSetUp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(374, 247);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.UserSetup_TabControl);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerInputSetUp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ユーザー設定";
            this.Load += new System.EventHandler(this.CustomerInputSetUp_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FirstDisplayTab_TComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputType_UOptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine1)).EndInit();
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserSetup_TabControl)).EndInit();
            this.UserSetup_TabControl.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private ImageList _imageList16 = null;
		private CustomerInputConstructionAcs _customerInputConstructionAcs = null;
		# endregion
	
		// ===================================================================================== //
		// 各種コンポーネントイベント処理郡
		// ===================================================================================== //
		# region Event Methods
		/// <summary>
		/// Form.Load イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer  : 22018 鈴木正臣</br>
		/// <br>Date        : 2008.04.30</br>
        /// <br>Note　　　  : 前橋京和商会個別 Redmine#42174 初期表示タブの対応</br>
        /// <br>Programmer  : 陳健</br>
        /// <br>Date        : 2014/03/07</br>
        /// <br>Update Note : 得意先情報ガイド表示PKG対応</br>
        /// <br>Programmer  : 梶谷貴士</br>
        /// <br>Date        : 2021/05/10</br>
		/// </remarks>
		private void CustomerInputSetUp_Load(object sender, System.EventArgs e)
		{
			this.Ok_Button.ImageList		= this._imageList16;
			this.Cancel_Button.ImageList	= this._imageList16;

			this.Ok_Button.Appearance.Image		= (int)Size16_Index.DECISION;
			this.Cancel_Button.Appearance.Image	= (int)Size16_Index.BEFORE;

			this.InputType_UOptionSet.CheckedIndex = this._customerInputConstructionAcs.InputType;
			this.FirstDisplayTab_TComboEditor.Value = this._customerInputConstructionAcs.FirstDisplayTab;
            this.tComboEditor1.Value = this._customerInputConstructionAcs.KeepOnInfoSetting;// ADD caohh 2011/08/04
            // ADD 陳健 K2014/02/06 ----------------------------------------->>>>>
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MaehashiKyowaGuideCtl);
            // UPD 陳健 2014/03/07 -------------------------------------------------------------------->>>>>
            //if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            if (ps != Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            // UPD 陳健 2014/03/07 --------------------------------------------------------------------<<<<<
            {
                // DEL 陳健 2014/03/07 -------------------------------------------------------------------->>>>>
                //Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
                //valueListItem6.DataValue = 6;
                //valueListItem6.DisplayText = "メモ情報";
                //this.FirstDisplayTab_TComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {valueListItem6});
                // DEL 陳健 2014/03/07 --------------------------------------------------------------------<<<<<

                // DEL 梶谷貴士 2021/05/10 -------------------------------------------------------------------->>>>>
                //// ADD 陳健 2014/03/07 -------------------------------------------------------------------->>>>>
                //if (this.FirstDisplayTab_TComboEditor.Items.Count >= 6)
                //{
                //    this.FirstDisplayTab_TComboEditor.Items.RemoveAt(5);
                //}
                // ADD 陳健 2014/03/07 --------------------------------------------------------------------<<<<<
                // DEL 梶谷貴士 2021/05/10 --------------------------------------------------------------------<<<<<
           }
            // ADD 陳健 K2014/02/06 -----------------------------------------<<<<<
		}

		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 22018 鈴木正臣</br>
		/// <br>Date        : 2008.04.30</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			this._customerInputConstructionAcs.InputType = this.InputType_UOptionSet.CheckedIndex;
			try
			{
				this._customerInputConstructionAcs.FirstDisplayTab = Convert.ToInt32(this.FirstDisplayTab_TComboEditor.Value);
                this._customerInputConstructionAcs.KeepOnInfoSetting = Convert.ToInt32(this.tComboEditor1.Value);// ADD caohh 2011/08/04
			}
			catch
			{
                this._customerInputConstructionAcs.FirstDisplayTab = CustomerInputConstructionAcs.FIRST_DISPLAY_TAB_DEFAULT;
                this._customerInputConstructionAcs.KeepOnInfoSetting = CustomerInputConstructionAcs.KEEPONINFOSETTING_DEFAULT;// ADD caohh 2011/08/04
			}
			this._customerInputConstructionAcs.Serialize();
		}
		# endregion
	}
}
