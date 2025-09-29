//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：掛率優先管理マスタ
// プログラム概要   ：掛率優先管理の登録・変更・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2008/06/16     修正内容：単価種類に「5:作業原価」「6:作業単価」追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2008/09/11     修正内容：データビュー幅自動調整の初期値変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/11     修正内容：Mantis【13464】コンボボックスの再表示不具合修正
// ---------------------------------------------------------------------//
// 管理番号　 　　　　　    作成担当：王君
// 修 正 日  2012/11/30 　　修正内容：20130116配信分 Redmine#33663の対応
//----------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 掛率優先管理マスタ設定
    /// </summary>
    /// <remarks>
	/// <br>Note       : 掛率優先管理マスタ設定を行います。</br>
    ///	<br>				 IMasterMaintenanceThreeArrayTypeを実装しています。</br>
    /// <br>Programmer : 30167 上野　弘貴</br>
    /// <br>Date       : 2007.09.10</br>
	/// <br>Update Note: 2008.02.20 30167 上野　弘貴</br>
	/// <br>			 全社共通読込時、拠点データが削除される旨をメッセージとして表示する</br>
	/// <br>Update Note: 2008.02.22 30167 上野　弘貴</br>
	/// <br>			 全社共通設定時、優先順位設定画面で並び順が優先順位順になっていなかったので修正</br>
	/// <br>Update Note: 2008.03.03 30167 上野　弘貴</br>
	/// <br>			 全社共通読込時の警告メッセージ文言修正</br>
    /// <br>Update Note: 2008/06/16 30414 忍　幸史</br>
    /// <br>             単価種類に「5:作業原価」「6:作業単価」追加</br>
    /// <br>Update Note: 2008/09/11 30414 忍　幸史</br>
    /// <br>             データビュー幅自動調整の初期値変更</br>
    /// <br>Update Note: 2012/11/30  王君</br>
    /// <br>	         20130116配信分 Redmine#33663の対応</br>
    /// </remarks>
    public class DCKHN09100UA : Form, IMasterMaintenanceThreeArrayType
	{
		# region Private Members (Component)
		private System.Data.DataSet Bind_DataSet;
		private UltraButton Add_uButton;
        private UltraButton Del_uButton;
		private TComboEditor RateSettingDivideCust_tComboEditor;
		private TComboEditor RateSettingDivideGoods_tComboEditor;
		private System.Windows.Forms.Timer Initial_Timer;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private UltraLabel RateSettingDivideGoods_uLabel;
		private UltraLabel RateSettingDivideCust_uLabel;
		private UltraLabel message_uLabel;
		private UltraGrid RateSettingDivide_uGrid;
		private UltraGrid RateSettingDivideSet_uGrid;
		private Label UnitPriceKind_label;
		private UltraButton DispCancel_uButton;
		private TComboEditor UtilityDiv_tComboEditor;
		private UltraLabel UtilityDiv_uLabel;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private System.ComponentModel.IContainer components = null;
		# endregion

		/// <summary>
		/// 掛率優先管理マスタ入力フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 掛率優先管理マスタ入力フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		public DCKHN09100UA()
		{
			InitializeComponent();

			// プロパティ初期値設定
			this._canPrint = false;
			this._canClose = true;
			this._canNew = true;
            // --- CHG 2008/06/09 --------------------------------------------------------------------->>>>>
            //this._canDelete = true;
            this._canDelete = false;
            // --- CHG 2008/06/09 ---------------------------------------------------------------------<<<<<

			this._mainGridTitle = SECTION_GRID_TITLE;
			this._secondGridTitle = UNITPRICEKIND_GRID_TITLE;
			this._thirdGridTitle = RATEPRIORITYORDER_GRID_TITLE;
			this._defaultGridDisplayLayout = MGridDisplayLayout.Horizontal;

			// 企業コード
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// 従業員
			this._employee = LoginInfoAcquisition.Employee;

			// 掛率優先管理マスタアクセス
			this._rateProtyMngAcs = new RateProtyMngAcs();
			
			// 掛率設定管理マスタアクセス
			this._rateMngGoodsCustAcs = new RateMngGoodsCust();

            this._secInfoAcs = new SecInfoAcs();

			// 各種インデックス初期化
			this._mainDataIndex = -1;
			this._secondDataIndex = -1;
			this._thirdDataIndex = -1;

			// アイコン用
			this._mainGridIcon = null;
			this._secondGridIcon = null;
			this._thirdGridIcon = null;

			// データセット列情報構築処理
			this._bindDataSet = new DataSet();
			DataSetColumnConstruction(ref this._bindDataSet);

			//------------------
			// コンボボックス用
			//------------------
            /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
			this._dataTableUtilityDiv = new DataTable();	// 使用区分
               --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/
            this._dataTableGoods = new DataTable();			// 掛率設定区分（商品）
			this._dataTableCust = new DataTable();			// 掛率設定区分（得意先）

            // コンボボックス用データセット列情報構築
            /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
			DataTblColumnComboInt(ref this._dataTableUtilityDiv);
               --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/
            DataTblColumnComboStr(ref this._dataTableGoods);
			DataTblColumnComboStr(ref this._dataTableCust);

			// 文字列結合用
			this._stringBuilder = new StringBuilder();			
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
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
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKHN09100UA));
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Add_uButton = new Infragistics.Win.Misc.UltraButton();
            this.Del_uButton = new Infragistics.Win.Misc.UltraButton();
            this.RateSettingDivideGoods_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.RateSettingDivideCust_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.RateSettingDivideGoods_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.RateSettingDivideCust_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.message_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.RateSettingDivide_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.RateSettingDivideSet_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.UnitPriceKind_label = new System.Windows.Forms.Label();
            this.DispCancel_uButton = new Infragistics.Win.Misc.UltraButton();
            this.UtilityDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.UtilityDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateSettingDivideGoods_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateSettingDivideCust_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateSettingDivide_uGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateSettingDivideSet_uGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UtilityDiv_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
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
            // Mode_Label
            // 
            appearance29.ForeColor = System.Drawing.Color.White;
            appearance29.TextHAlignAsString = "Center";
            appearance29.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance29;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(879, 5);
            this.Mode_Label.Margin = new System.Windows.Forms.Padding(4);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 59;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(841, 540);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 11;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(710, 540);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 10;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Add_uButton
            // 
            this.Add_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.Add_uButton.Location = new System.Drawing.Point(444, 168);
            this.Add_uButton.Name = "Add_uButton";
            this.Add_uButton.Size = new System.Drawing.Size(96, 25);
            this.Add_uButton.TabIndex = 4;
            this.Add_uButton.Text = "追加(&A)>>";
            this.Add_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Add_uButton.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // Del_uButton
            // 
            this.Del_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.Del_uButton.Location = new System.Drawing.Point(444, 210);
            this.Del_uButton.Name = "Del_uButton";
            this.Del_uButton.Size = new System.Drawing.Size(96, 25);
            this.Del_uButton.TabIndex = 5;
            this.Del_uButton.Text = "<<削除(&R)";
            this.Del_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Del_uButton.Click += new System.EventHandler(this.Del_uButton_Click);
            // 
            // RateSettingDivideGoods_tComboEditor
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance26.ForeColor = System.Drawing.Color.Black;
            this.RateSettingDivideGoods_tComboEditor.ActiveAppearance = appearance26;
            appearance27.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.ForeColorDisabled = System.Drawing.Color.Black;
            appearance27.TextVAlignAsString = "Middle";
            this.RateSettingDivideGoods_tComboEditor.Appearance = appearance27;
            this.RateSettingDivideGoods_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.RateSettingDivideGoods_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RateSettingDivideGoods_tComboEditor.ItemAppearance = appearance28;
            this.RateSettingDivideGoods_tComboEditor.Location = new System.Drawing.Point(176, 62);
            this.RateSettingDivideGoods_tComboEditor.Name = "RateSettingDivideGoods_tComboEditor";
            this.RateSettingDivideGoods_tComboEditor.Size = new System.Drawing.Size(567, 24);
            this.RateSettingDivideGoods_tComboEditor.TabIndex = 1;
            this.RateSettingDivideGoods_tComboEditor.SelectionChangeCommitted += new System.EventHandler(this.RateSettingDivideGoods_tComboEditor_SelectionChangeCommitted);
            // 
            // RateSettingDivideCust_tComboEditor
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance23.ForeColor = System.Drawing.Color.Black;
            this.RateSettingDivideCust_tComboEditor.ActiveAppearance = appearance23;
            appearance24.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.ForeColorDisabled = System.Drawing.Color.Black;
            appearance24.TextVAlignAsString = "Middle";
            this.RateSettingDivideCust_tComboEditor.Appearance = appearance24;
            this.RateSettingDivideCust_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.RateSettingDivideCust_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RateSettingDivideCust_tComboEditor.ItemAppearance = appearance25;
            this.RateSettingDivideCust_tComboEditor.Location = new System.Drawing.Point(176, 92);
            this.RateSettingDivideCust_tComboEditor.Name = "RateSettingDivideCust_tComboEditor";
            this.RateSettingDivideCust_tComboEditor.Size = new System.Drawing.Size(567, 24);
            this.RateSettingDivideCust_tComboEditor.TabIndex = 2;
            this.RateSettingDivideCust_tComboEditor.SelectionChangeCommitted += new System.EventHandler(this.RateSettingDivideCust_tComboEditor_SelectionChangeCommitted);
            // 
            // RateSettingDivideGoods_uLabel
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.RateSettingDivideGoods_uLabel.Appearance = appearance22;
            this.RateSettingDivideGoods_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.RateSettingDivideGoods_uLabel.Location = new System.Drawing.Point(20, 62);
            this.RateSettingDivideGoods_uLabel.Name = "RateSettingDivideGoods_uLabel";
            this.RateSettingDivideGoods_uLabel.Size = new System.Drawing.Size(96, 24);
            this.RateSettingDivideGoods_uLabel.TabIndex = 3;
            this.RateSettingDivideGoods_uLabel.Text = "商品情報";
            // 
            // RateSettingDivideCust_uLabel
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.RateSettingDivideCust_uLabel.Appearance = appearance21;
            this.RateSettingDivideCust_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.RateSettingDivideCust_uLabel.Location = new System.Drawing.Point(20, 92);
            this.RateSettingDivideCust_uLabel.Name = "RateSettingDivideCust_uLabel";
            this.RateSettingDivideCust_uLabel.Size = new System.Drawing.Size(150, 24);
            this.RateSettingDivideCust_uLabel.TabIndex = 5;
            this.RateSettingDivideCust_uLabel.Text = "得意先／仕入先情報";
            // 
            // message_uLabel
            // 
            appearance20.TextVAlignAsString = "Middle";
            this.message_uLabel.Appearance = appearance20;
            this.message_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.message_uLabel.Location = new System.Drawing.Point(20, 122);
            this.message_uLabel.Name = "message_uLabel";
            this.message_uLabel.Size = new System.Drawing.Size(408, 24);
            this.message_uLabel.TabIndex = 7;
            // 
            // RateSettingDivide_uGrid
            // 
            this.RateSettingDivide_uGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance13.BackColor2 = System.Drawing.Color.White;
            this.RateSettingDivide_uGrid.DisplayLayout.Appearance = appearance13;
            this.RateSettingDivide_uGrid.DisplayLayout.MaxColScrollRegions = 1;
            this.RateSettingDivide_uGrid.DisplayLayout.MaxRowScrollRegions = 1;
            this.RateSettingDivide_uGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.RateSettingDivide_uGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.RateSettingDivide_uGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            this.RateSettingDivide_uGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.RateSettingDivide_uGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.RateSettingDivide_uGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.RateSettingDivide_uGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance14.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.FontData.BoldAsString = "False";
            appearance14.FontData.Name = "Arial";
            appearance14.FontData.SizeInPoints = 10F;
            appearance14.ForeColor = System.Drawing.Color.White;
            appearance14.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.RateSettingDivide_uGrid.DisplayLayout.Override.HeaderAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.Lavender;
            this.RateSettingDivide_uGrid.DisplayLayout.Override.RowAlternateAppearance = appearance15;
            appearance16.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.RateSettingDivide_uGrid.DisplayLayout.Override.RowAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance17.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance17.ForeColor = System.Drawing.Color.White;
            this.RateSettingDivide_uGrid.DisplayLayout.Override.RowSelectorAppearance = appearance17;
            this.RateSettingDivide_uGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.RateSettingDivide_uGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance18.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance18.ForeColor = System.Drawing.Color.Black;
            this.RateSettingDivide_uGrid.DisplayLayout.Override.SelectedRowAppearance = appearance18;
            this.RateSettingDivide_uGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.RateSettingDivide_uGrid.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            this.RateSettingDivide_uGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Vertical;
            this.RateSettingDivide_uGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            appearance19.BackColor = System.Drawing.Color.White;
            this.RateSettingDivide_uGrid.DisplayLayout.SplitterBarHorizontalAppearance = appearance19;
            this.RateSettingDivide_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RateSettingDivide_uGrid.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.RateSettingDivide_uGrid.Location = new System.Drawing.Point(20, 152);
            this.RateSettingDivide_uGrid.Name = "RateSettingDivide_uGrid";
            this.RateSettingDivide_uGrid.Size = new System.Drawing.Size(408, 358);
            this.RateSettingDivide_uGrid.TabIndex = 3;
            this.RateSettingDivide_uGrid.Click += new System.EventHandler(this.RateSettingDivide_uGrid_Click);
            this.RateSettingDivide_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
            // 
            // RateSettingDivideSet_uGrid
            // 
            this.RateSettingDivideSet_uGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance5.BackColor2 = System.Drawing.Color.White;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Appearance = appearance5;
            this.RateSettingDivideSet_uGrid.DisplayLayout.MaxColScrollRegions = 1;
            this.RateSettingDivideSet_uGrid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.ForeColor = System.Drawing.Color.Black;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.FontData.BoldAsString = "False";
            appearance7.FontData.Name = "Arial";
            appearance7.FontData.SizeInPoints = 10F;
            appearance7.ForeColor = System.Drawing.Color.White;
            appearance7.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Override.HeaderAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.Lavender;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Override.RowAlternateAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.RateSettingDivideSet_uGrid.DisplayLayout.Override.RowAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.ForeColor = System.Drawing.Color.White;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Override.RowSelectorAppearance = appearance10;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.ForeColor = System.Drawing.Color.Black;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.RateSettingDivideSet_uGrid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Vertical;
            this.RateSettingDivideSet_uGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            appearance12.BackColor = System.Drawing.Color.White;
            this.RateSettingDivideSet_uGrid.DisplayLayout.SplitterBarHorizontalAppearance = appearance12;
            this.RateSettingDivideSet_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RateSettingDivideSet_uGrid.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.RateSettingDivideSet_uGrid.Location = new System.Drawing.Point(558, 152);
            this.RateSettingDivideSet_uGrid.Name = "RateSettingDivideSet_uGrid";
            this.RateSettingDivideSet_uGrid.Size = new System.Drawing.Size(408, 358);
            this.RateSettingDivideSet_uGrid.TabIndex = 8;
            this.RateSettingDivideSet_uGrid.Click += new System.EventHandler(this.RateSettingDivide_uGrid_Click);
            this.RateSettingDivideSet_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
            // 
            // UnitPriceKind_label
            // 
            this.UnitPriceKind_label.BackColor = System.Drawing.Color.Orange;
            this.UnitPriceKind_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UnitPriceKind_label.ForeColor = System.Drawing.Color.White;
            this.UnitPriceKind_label.Location = new System.Drawing.Point(749, 4);
            this.UnitPriceKind_label.Name = "UnitPriceKind_label";
            this.UnitPriceKind_label.Size = new System.Drawing.Size(103, 29);
            this.UnitPriceKind_label.TabIndex = 109;
            this.UnitPriceKind_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DispCancel_uButton
            // 
            this.DispCancel_uButton.ImageSize = new System.Drawing.Size(24, 24);
            this.DispCancel_uButton.Location = new System.Drawing.Point(579, 540);
            this.DispCancel_uButton.Name = "DispCancel_uButton";
            this.DispCancel_uButton.Size = new System.Drawing.Size(125, 34);
            this.DispCancel_uButton.TabIndex = 9;
            this.DispCancel_uButton.Text = "取消(&C)";
            this.DispCancel_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DispCancel_uButton.Click += new System.EventHandler(this.Cancel_uButton_Click);
            // 
            // UtilityDiv_tComboEditor
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UtilityDiv_tComboEditor.ActiveAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.UtilityDiv_tComboEditor.Appearance = appearance3;
            this.UtilityDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.UtilityDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UtilityDiv_tComboEditor.ItemAppearance = appearance4;
            this.UtilityDiv_tComboEditor.Location = new System.Drawing.Point(176, 32);
            this.UtilityDiv_tComboEditor.Name = "UtilityDiv_tComboEditor";
            this.UtilityDiv_tComboEditor.Size = new System.Drawing.Size(191, 24);
            this.UtilityDiv_tComboEditor.TabIndex = 0;
            this.UtilityDiv_tComboEditor.SelectionChangeCommitted += new System.EventHandler(this.UtilityDiv_tComboEditor_SelectionChangeCommitted);
            // 
            // UtilityDiv_uLabel
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.UtilityDiv_uLabel.Appearance = appearance1;
            this.UtilityDiv_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.UtilityDiv_uLabel.Location = new System.Drawing.Point(20, 32);
            this.UtilityDiv_uLabel.Name = "UtilityDiv_uLabel";
            this.UtilityDiv_uLabel.Size = new System.Drawing.Size(96, 24);
            this.UtilityDiv_uLabel.TabIndex = 216;
            this.UtilityDiv_uLabel.Text = "拠点指定";
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 584);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(984, 27);
            this.ultraStatusBar1.TabIndex = 217;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // DCKHN09100UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.UtilityDiv_uLabel);
            this.Controls.Add(this.UtilityDiv_tComboEditor);
            this.Controls.Add(this.DispCancel_uButton);
            this.Controls.Add(this.UnitPriceKind_label);
            this.Controls.Add(this.RateSettingDivideSet_uGrid);
            this.Controls.Add(this.RateSettingDivide_uGrid);
            this.Controls.Add(this.message_uLabel);
            this.Controls.Add(this.RateSettingDivideCust_uLabel);
            this.Controls.Add(this.RateSettingDivideGoods_uLabel);
            this.Controls.Add(this.RateSettingDivideCust_tComboEditor);
            this.Controls.Add(this.RateSettingDivideGoods_tComboEditor);
            this.Controls.Add(this.Del_uButton);
            this.Controls.Add(this.Add_uButton);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Mode_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DCKHN09100UA";
            this.Text = "掛率優先管理マスタ";
            this.Load += new System.EventHandler(this.DCKHN09100UA_Load);
            this.VisibleChanged += new System.EventHandler(this.DCKHN09100UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DCKHN09100UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateSettingDivideGoods_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateSettingDivideCust_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateSettingDivide_uGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateSettingDivideSet_uGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UtilityDiv_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceThreeArrayTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		#region Private Members

		// UIグリッド用HashTable
		private Hashtable _gridSearchHash;
		
		// プロパティ用
		private bool _canPrint;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private MGridDisplayLayout _defaultGridDisplayLayout;
		private string _targetTableName;

		// タイトル
		private string _mainGridTitle;
		private string _secondGridTitle;
		private string _thirdGridTitle;

		// アイコン
		private Image _mainGridIcon;
		private Image _secondGridIcon;
		private Image _thirdGridIcon;

		// 選択データインデックス
		private int _mainDataIndex;
		private int _secondDataIndex;
		private int _thirdDataIndex;

		// 企業コード
		private string _enterpriseCode = "";
		
		// 掛率優先管理マスタ
		private RateProtyMngAcs _rateProtyMngAcs = null;
		
		// 掛率設定管理マスタ
		private RateMngGoodsCust _rateMngGoodsCustAcs = null;

		// データセット（フレーム用）
		private DataSet _bindDataSet = null;
		
		//--------------
		// UIグリッド用
		//--------------
        private DataTable _listDataTableAll = null;
		private DataTable _listDataTable = null;			// UI選択グリッド表示用データテーブル
		private DataTable _listSaveDataTable = null;		// UI確定グリッド表示用データテーブル
		private DataTable _listSaveDataTableClone = null;	// UI確定用グリッドデータテーブルクローン

		// グリッド選択色設定
		private readonly Color _selectedBackColor = Color.FromArgb(216, 235, 253);
		private readonly Color _selectedBackColor2 = Color.FromArgb(101, 144, 218);
		
		//------------------
		// コンボボックス用
		//------------------
        /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
		private DataTable _dataTableUtilityDiv = null;	// 使用区分
           --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/
        private DataTable _dataTableGoods = null;		// 掛率設定区分（商品）
		private DataTable _dataTableCust = null;		// 掛率設定区分（得意先）

		private int _utilityDivtComboEditorValue = -1;	// 使用区分ワークデータ
		private string _rateSettingDivideGoods_tComboEditorValue = "";
		private string _rateSettingDivideCust_tComboEditorValue = "";
		
		// 文字列結合用
		private StringBuilder _stringBuilder = null;
		
		// 従業員
		private Employee _employee = null;
		
		// 画面デザイン変更クラス
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // --- ADD 2008/06/16 --------------------------------------------------------------------->>>>>
        // 追加リスト
        private List<string> _addList;

        private SecInfoAcs _secInfoAcs;
        // --- ADD 2008/06/16 ---------------------------------------------------------------------<<<<<

		#endregion

		#region Private Const

		// コンボボックス用
		private const string COMBO_CODE = "COMBO_CODE";
		private const string COMBO_NAME = "COMBO_NAME";

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";
		private const string COMMON_MODE = "全社共通";

		// FrameのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
		private const string MAIN_TABLE = "PrintingItem";
		private const string SECOND_TABLE = "CountItem";
		private const string THIRD_TABLE = "CountCondition";
		
		// グリッドタイトル
		private const string SECTION_GRID_TITLE = "拠点";
		private const string UNITPRICEKIND_GRID_TITLE = "単価種類";
		private const string RATEPRIORITYORDER_GRID_TITLE = "掛率優先順位";

		// Grid表示用
		private const string MY_RATEMNGSETTINGDIVIDE_TABLE = "RATEMNGSETTINGDIVIDE_TABLE";
		private const string MY_RATEMNGSETTINGDIVIDE_SET_TABLE = "RATEMNGSETTINGDIVIDE_SET_TABLE";

		private const int MAX_SELECT_LIST = 20;	// リストボックス選択最大数
        // --- CHG 2008/06/16 --------------------------------------------------------------------->>>>>
        //private const string COM_SECTION_CODE = "000000";	// 全社共通拠点コード
        private const string COM_SECTION_CODE = "00";	// 全社共通拠点コード
        // --- CHG 2008/06/16 ---------------------------------------------------------------------<<<<<

		// Message関連定義
		private const string ASSEMBLY_ID = "DCKHN09100U";
		private const string ERR_READ_MSG = "読み込みに失敗しました。";
		private const string ERR_DPR_MSG = "このコードは既に使用されています。";
		private const string ERR_RDEL_MSG = "削除に失敗しました。";
		private const string ERR_UPDT_MSG = "登録に失敗しました。";
		private const string ERR_RVV_MSG = "復活に失敗しました。";
		private const string ERR_800_MSG = "既に他端末より更新されています";
		private const string ERR_801_MSG = "既に他端末より削除されています";
		private const string SDC_RDEL_MSG = "マスタから削除されています";
		private const string FRM_DTL_MSG = "明細項目がヒットしません。";
		private const string SEL_ROW_MSG = "選択行が複数行、または未選択です。";
		private const string COM_RED_QMSG = "全社共通設定を読み込んでよろしいですか？";
		private const string COM_RED_MSG = "拠点利用の設定が行われていない為\n全社共通の設定となります。";
		private const string PRE_STAT_QMSG = "既定の状態に戻してもよろしいですか？";
		private const string DISP_INFO_MSG = "掛率優先順位設定を行うデータを追加してください。";
		private const string MAX_SEL_OVER_MSG = "掛率は20個以内で設定してください。";
		//----- ueno upd ---------- start 2008.03.03
		private const string CONF_DEL_MSG = "拠点設定が全社共通設定に変更されます。\n\nよろしいですか？";
		private const string CONF_DEL_LAST_MSG = "次回起動時より、全社共通設定が表示されます。\n\n現在の拠点設定は削除されます。" +
												"\n\n本当によろしいですか？";
		//----- ueno upd ---------- end 2008.03.03
		
		#endregion

		# region Main
		/// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new DCKHN09100UA());
        }
        # endregion

        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
        public bool CanClose
        {
            get { return this._canClose; }
            set { this._canClose = value; }
        }

        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get { return this._canNew; }
        }

        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get { return this._canDelete; }
        }

        /// <summary>グリッドのデフォルト表示位置プロパティ</summary>
        /// <value>グリッドのデフォルト表示位置を取得します。</value>
        public MGridDisplayLayout DefaultGridDisplayLayout
        {
            get { return this._defaultGridDisplayLayout; }
        }

        /// <summary>操作対象データテーブル名称プロパティ</summary>
        /// <value>操作対象データのテーブル名称を取得または設定します。</value>
        public string TargetTableName
        {
            get { return this._targetTableName; }
            set { this._targetTableName = value; }
        }

        /// <summary>
        /// 論理削除データ抽出可能設定リスト取得処理
        /// </summary>
        /// <returns>論理削除データ抽出可能設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 論理削除データの抽出が可能かどうかの設定を配列で取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] logicalDelete = { false, false, false};
            return logicalDelete;
        }

        /// <summary>
        /// グリッドタイトルリスト取得処理
        /// </summary>
        /// <returns>グリッドタイトルリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのタイトルを配列で取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public string[] GetGridTitleList()
        {
            string[] gridTitle = { _mainGridTitle, _secondGridTitle, _thirdGridTitle };
            return gridTitle;
        }

        /// <summary>
        /// グリッドアイコンリスト取得処理
        /// </summary>
        /// <returns>グリッドアイコンリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアイコンを配列で取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public System.Drawing.Image[] GetGridIconList()
        {
            System.Drawing.Image[] gridIcon = { _mainGridIcon, _secondGridIcon, _thirdGridIcon };
            return gridIcon;
        }

        /// <summary>
        /// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
        /// </summary>
        /// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
        /// <remarks>
        /// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            // --- CHG 2008/09/11 --------------------------------------------------------------------->>>>>
            //bool[] defaultAutoFill = { true, true, true };
            bool[] defaultAutoFill = { false, false, false };
            // --- CHG 2008/09/11 ---------------------------------------------------------------------<<<<<
            return defaultAutoFill;
        }

        /// <summary>
        /// データテーブルの選択データインデックスリスト設定処理
        /// </summary>
        /// <param name="indexList">データテーブルの選択データインデックスリスト</param>
        /// <remarks>
        /// <br>Note       : データテーブルの選択データインデックスリストを設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;

            this._mainDataIndex   = intVal[0];
            this._secondDataIndex = intVal[1];
            this._thirdDataIndex  = intVal[2];
        }

        /// <summary>
        /// 新規ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>新規ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 新規ボタンの有効設定リストを取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.25</br>
		/// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] newButtonEnabled = { false, false, true };
            //bool[] newButtonEnabled = { false, true, false };

			if (this._bindDataSet.Tables[THIRD_TABLE].Rows.Count > 0)
			{
				newButtonEnabled[2] = false;
			}
			return newButtonEnabled;
        }

        /// <summary>
        /// 修正ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>修正ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            //bool[] modifyButtonEnabled = { false, false, true };
            bool[] modifyButtonEnabled = { false, true, false };

			if (this._bindDataSet.Tables[THIRD_TABLE].Rows.Count == 0)
			{
				modifyButtonEnabled[2] = false;
			}
			return modifyButtonEnabled;
        }

        /// <summary>
        /// 削除ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>削除ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 削除ボタンの有効設定リストを取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] deleteButtonEnabled = { false, false, false };
            return deleteButtonEnabled;
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string[] tableName)
        {
            bindDataSet = this._bindDataSet;
            tableName[0] = MAIN_TABLE;
            tableName[1] = SECOND_TABLE;
            tableName[2] = THIRD_TABLE;
        }

        /// <summary>
        /// データ検索処理(１アレイ目)
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭からキャリアの全データを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            string  message;
            bool    nextData;
            DataSet ds;

			//------------------------------------------------------
			// 掛率設定管理（商品・得意先）マスタから提供データ取得
			//------------------------------------------------------
			// 掛率設定管理マスタから取得
            status = this._rateMngGoodsCustAcs.SearchAll(out _listDataTableAll
												   , out totalCount
												   , out nextData
												   , this._enterpriseCode
												   , this._employee.BelongSectionCode
												   , out message);

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				emErrorLevel emErrLvl = emErrorLevel.ERR_LEVEL_INFO;
				if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
				{
					emErrLvl = emErrorLevel.ERR_LEVEL_STOP;
				}
				
				// 提供データサーチ
				TMsgDisp.Show(
						this, 								// 親ウィンドウフォーム
						emErrLvl,                           // エラーレベル
						ASSEMBLY_ID,                        // アセンブリＩＤまたはクラスＩＤ
						this.Text,			                // プログラム名称
						"Search", 							// 処理名称
						TMsgDisp.OPE_GET,                   // オペレーション
						ERR_READ_MSG,					    // 表示するメッセージ
						status,                             // ステータス値
						this._rateProtyMngAcs,    	        // エラーが発生したオブジェクト
						MessageBoxButtons.OK,               // 表示するボタン
						MessageBoxDefaultButton.Button1);   // 初期表示ボタン

				return status;
			}

            this._listDataTable = this._listDataTableAll.Clone();
            foreach (DataRow dr in this._listDataTableAll.Rows)
            {
                this._listDataTable.Rows.Add(dr.ItemArray);
            }
			
			// 掛率優先管理確定用データテーブルメモリ取得
			this._rateMngGoodsCustAcs.GetListSaveDataTable(out _listSaveDataTable);

			// HashTable取得
			this._rateMngGoodsCustAcs.GetUiGridHashTable(out this._gridSearchHash);

			//------------------------------------------------
			// 掛率優先管理マスタからユーザデータ取得
			//------------------------------------------------
            // 掛率優先管理マスタから抽出
            status = this._rateProtyMngAcs.SearchAll(out ds
                                                    ,out totalCount
                                                    ,out nextData
                                                    ,this._enterpriseCode
                                                    ,this._employee.BelongSectionCode
                                                    ,out message);
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    emErrorLevel emErrLvl = emErrorLevel.ERR_LEVEL_INFO;
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
            //    {
            //        emErrLvl = emErrorLevel.ERR_LEVEL_STOP;
            //    }

            //    // サーチ
            //    TMsgDisp.Show(
            //            this, 								// 親ウィンドウフォーム
            //            emErrLvl,                           // エラーレベル
            //            ASSEMBLY_ID,                        // アセンブリＩＤまたはクラスＩＤ
            //            this.Text,			                // プログラム名称
            //            "Search", 							// 処理名称
            //            TMsgDisp.OPE_GET,                   // オペレーション
            //            ERR_READ_MSG,					    // 表示するメッセージ
            //            status,                             // ステータス値
            //            this._rateProtyMngAcs,    	        // エラーが発生したオブジェクト
            //            MessageBoxButtons.OK,               // 表示するボタン
            //            MessageBoxDefaultButton.Button1);   // 初期表示ボタン

            //    return status;
            //}
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    emErrorLevel emErrLvl = emErrorLevel.ERR_LEVEL_INFO;
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        emErrLvl = emErrorLevel.ERR_LEVEL_STOP;
                    }

                    // サーチ
                    TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrLvl,                           // エラーレベル
                            ASSEMBLY_ID,                        // アセンブリＩＤまたはクラスＩＤ
                            this.Text,			                // プログラム名称
                            "Search", 							// 処理名称
                            TMsgDisp.OPE_GET,                   // オペレーション
                            ERR_READ_MSG,					    // 表示するメッセージ
                            status,                             // ステータス値
                            this._rateProtyMngAcs,    	        // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,               // 表示するボタン
                            MessageBoxDefaultButton.Button1);   // 初期表示ボタン

                    return status;
            }

            this._bindDataSet.Tables[MAIN_TABLE].Rows.Clear();
            this._bindDataSet.Tables[SECOND_TABLE].Rows.Clear();
            this._bindDataSet.Tables[THIRD_TABLE].Rows.Clear();

            foreach (DataRow dr in ds.Tables[RateProtyMngAcs.SECTION_TABLE].Rows)
            {
				DataRow check = this._bindDataSet.Tables[MAIN_TABLE].Rows.Find(dr[RateProtyMngAcs.SECTIONCODE]);
                if (check != null)
                {
                    // 登録済みなので次へ
                    continue;
                }
                // メインテーブルへの登録
                DataRow drMain = this._bindDataSet.Tables[MAIN_TABLE].NewRow();

				// 拠点コード
				drMain[RateProtyMngAcs.SECTIONCODE] = dr[RateProtyMngAcs.SECTIONCODE];
				// 拠点名称
				drMain[RateProtyMngAcs.SECTIONNAME] = dr[RateProtyMngAcs.SECTIONNAME];
				
                this._bindDataSet.Tables[MAIN_TABLE].Rows.Add(drMain);
            }
            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理(１アレイ目)
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ArrayTypeでは未実装</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public int SearchNext(int readCount)
        {
            // EOF
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// データ検索処理(２アレイ目)
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public int SecondDataSearch(ref int totalCount, int readCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            if ((this._bindDataSet == null) || (this._mainDataIndex < 0))
            {
                return status;
            }

            this._bindDataSet.Tables[SECOND_TABLE].Rows.Clear();
            this._bindDataSet.Tables[THIRD_TABLE].Rows.Clear();

			string sectionCode = (string)this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][RateProtyMngAcs.SECTIONCODE];

			// 第１グリッド抽出時に既に抽出済みのテーブルから表示
			foreach (DataRow dr in this._rateProtyMngAcs.DtSecondTable.Rows)
            {
				if (sectionCode != (string)dr[RateProtyMngAcs.SECTIONCODE])
				{
					// 拠点コードが不一致のデータは除外
					continue;
				}

				DataRow check = this._bindDataSet.Tables[SECOND_TABLE].Rows.Find(dr[RateProtyMngAcs.UNITPRICEKIND]);
                if ( check != null )
                {
                    // 登録済みなので次へ
                    continue;
                }

                // セカンドテーブルへの登録
                DataRow drSecond = this._bindDataSet.Tables[SECOND_TABLE].NewRow();

                // 拠点コード
				drSecond[RateProtyMngAcs.SECTIONCODE] = dr[RateProtyMngAcs.SECTIONCODE];
                // 拠点名称
				drSecond[RateProtyMngAcs.SECTIONNAME] = dr[RateProtyMngAcs.SECTIONNAME];
                // 単価種類
				drSecond[RateProtyMngAcs.UNITPRICEKIND] = dr[RateProtyMngAcs.UNITPRICEKIND];
				// 単価種類（名称）
				drSecond[RateProtyMngAcs.UNITPRICEKINDNM] = dr[RateProtyMngAcs.UNITPRICEKINDNM];
                // 使用区分
				drSecond[RateProtyMngAcs.UTILITYDIV_TITLE] = dr[RateProtyMngAcs.UTILITYDIV_TITLE];

                this._bindDataSet.Tables[SECOND_TABLE].Rows.Add(drSecond);
            }

            totalCount = this._bindDataSet.Tables[SECOND_TABLE].Rows.Count;
            status = ( int ) ConstantManagement.DB_Status.ctDB_NORMAL;

            return status;
        }

        /// <summary>
        /// ネクストデータ検索処理(２アレイ目)
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: ArrayTypeでは未実装</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public int SecondDataSearchNext(int readCount)
        {
            // EOF
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// データ検索処理(３アレイ目)
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public int ThirdDataSearch(ref int totalCount, int readCount)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			if ((this._bindDataSet == null) || (this._mainDataIndex < 0))
			{
				return status;
			}

			this._bindDataSet.Tables[THIRD_TABLE].Rows.Clear();

			string sectionCode = (string)this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][RateProtyMngAcs.SECTIONCODE];
			int unitPriceKind = (int)this._bindDataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][RateProtyMngAcs.UNITPRICEKIND];

			//----------------------------
			// 第３グリッドデータをソート
			//----------------------------
			DataTable sortDtThirdTable = new DataTable();
			sortDtThirdTable = this._rateProtyMngAcs.DtThirdTable.Clone();

			// ビューデータ取得
			DataView dView = this._rateProtyMngAcs.DtThirdTable.DefaultView;

			_stringBuilder.Remove(0, _stringBuilder.Length);
			_stringBuilder.Append(RateProtyMngAcs.RATEPRIORITYORDER);
			_stringBuilder.Append(" ASC");

			// 掛率優先順位昇順でソート
			dView.Sort = _stringBuilder.ToString();

			// ソートしたレコードをワークテーブルに詰め替え
			foreach (DataRowView drv in dView)
			{
				sortDtThirdTable.ImportRow(drv.Row);
			}
			
			// 第１グリッド抽出時に既に抽出済みのテーブルから表示
			foreach (DataRow dr in sortDtThirdTable.Rows)
			{
                // --- CHG 2008/06/16 --------------------------------------------------------------------->>>>>
                //if (sectionCode != (string)dr[RateProtyMngAcs.SECTIONCODE])
                string sectionCode2 = (string)dr[RateProtyMngAcs.SECTIONCODE];
                if (sectionCode.Trim() != sectionCode2.Trim())
                // --- CHG 2008/06/16 ---------------------------------------------------------------------<<<<<
				{
					// 拠点コードが不一致のデータは除外
					continue;
				}
				if (unitPriceKind != (int)dr[RateProtyMngAcs.UNITPRICEKIND])
				{
					// 単価種類が不一致のデータは除外
					continue;
				}

				DataRow check = this._bindDataSet.Tables[THIRD_TABLE].Rows.Find(dr[RateProtyMngAcs.RATEPRIORITYORDER]);
				if (check != null)
				{
					// 登録済みなので次へ
					continue;
				}

                if ((sectionCode.Trim() != "00") && (string.Equals(dr[RateProtyMngAcs.UTILITYDIV_TITLE].ToString(), RateProtyMngAcs.ALL_SECTION_NAME)))
                {
                    continue;
                }

				// サードテーブル(掛率優先管理)への登録
				DataRow drThird = this._bindDataSet.Tables[THIRD_TABLE].NewRow();

				// 作成日付
				drThird[RateProtyMngAcs.CREATEDATETIME] = dr[RateProtyMngAcs.CREATEDATETIME];
				// 更新日付
				drThird[RateProtyMngAcs.UPDATEDATETIME] = dr[RateProtyMngAcs.UPDATEDATETIME];
				// GUID
				drThird[RateProtyMngAcs.FILEHEADERGUID] = dr[RateProtyMngAcs.FILEHEADERGUID];				
				// 拠点コード
				drThird[RateProtyMngAcs.SECTIONCODE] = dr[RateProtyMngAcs.SECTIONCODE];
				// 拠点名称
				drThird[RateProtyMngAcs.SECTIONNAME] = dr[RateProtyMngAcs.SECTIONNAME];
				// 単価種類
				drThird[RateProtyMngAcs.UNITPRICEKIND] = dr[RateProtyMngAcs.UNITPRICEKIND];
				// 単価種類（名称）
				drThird[RateProtyMngAcs.UNITPRICEKINDNM] = dr[RateProtyMngAcs.UNITPRICEKINDNM];
				// 使用区分
				drThird[RateProtyMngAcs.UTILITYDIV_TITLE] = dr[RateProtyMngAcs.UTILITYDIV_TITLE];
				// 順位
				drThird[RateProtyMngAcs.RATEPRIORITYORDER] = dr[RateProtyMngAcs.RATEPRIORITYORDER];
				// 区分
				drThird[RateProtyMngAcs.RATESETTINGDIVIDE] = dr[RateProtyMngAcs.RATESETTINGDIVIDE];
				// 区分（商品）非表示
				drThird[RateProtyMngAcs.RATEMNGGOODSCD] = dr[RateProtyMngAcs.RATEMNGGOODSCD];
				// 商品情報
				drThird[RateProtyMngAcs.RATEMNGGOODSNM] = dr[RateProtyMngAcs.RATEMNGGOODSNM];
				// 区分（得意先）非表示
				drThird[RateProtyMngAcs.RATEMNGCUSTCD] = dr[RateProtyMngAcs.RATEMNGCUSTCD];
				// 得意先情報
				drThird[RateProtyMngAcs.RATEMNGCUSTNM] = dr[RateProtyMngAcs.RATEMNGCUSTNM];
				// 削除日
				drThird[RateProtyMngAcs.DELETE_DATE_TITLE] = dr[RateProtyMngAcs.DELETE_DATE_TITLE];
				
				this._bindDataSet.Tables[THIRD_TABLE].Rows.Add(drThird);
			}

			totalCount = this._bindDataSet.Tables[THIRD_TABLE].Rows.Count;
			status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			
			return status;
		}

        /// <summary>
        /// ネクストデータ検索処理(３アレイ目)
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ArrayTypeでは未実装</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public int ThirdDataSearchNext(int readCount)
        {
            // EOF
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを削除します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		public int Delete()
		{
			// 未実装
			return 0;
		}

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public int Print()
        {
            // 印刷用アセンブリをロードする（未実装）
            return 0;
        }

        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        public void GetAppearanceTable(out Hashtable[] _hashtable)
        {
            //==============================
            // メイン
            //==============================
            Hashtable main = new Hashtable();

			main.Add(RateProtyMngAcs.SECTIONCODE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			main.Add(RateProtyMngAcs.SECTIONNAME, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));

            //==============================
            // セカンド
            //==============================
            Hashtable second = new Hashtable();

			second.Add(RateProtyMngAcs.SECTIONCODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			second.Add(RateProtyMngAcs.SECTIONNAME, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			second.Add(RateProtyMngAcs.UNITPRICEKIND, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
			second.Add(RateProtyMngAcs.UNITPRICEKINDNM, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			second.Add(RateProtyMngAcs.UTILITYDIV_TITLE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));

            //==============================
            // サード
            //==============================
            Hashtable third = new Hashtable();

			third.Add(RateProtyMngAcs.DELETE_DATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataListOnly, ContentAlignment.MiddleLeft, "", Color.Red));
			third.Add(RateProtyMngAcs.CREATEDATETIME, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			third.Add(RateProtyMngAcs.UPDATEDATETIME, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			third.Add(RateProtyMngAcs.UPDASSEMBLYID1, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			third.Add(RateProtyMngAcs.UPDASSEMBLYID2, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			third.Add(RateProtyMngAcs.ENTERPRISECODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			third.Add(RateProtyMngAcs.UPDEMPLOYEECODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			third.Add(RateProtyMngAcs.FILEHEADERGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			third.Add(RateProtyMngAcs.LOGICALDELETECODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

			third.Add(RateProtyMngAcs.SECTIONCODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Red));
			third.Add(RateProtyMngAcs.SECTIONNAME, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			third.Add(RateProtyMngAcs.UNITPRICEKIND, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Red));
			third.Add(RateProtyMngAcs.UNITPRICEKINDNM, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Red));
			third.Add(RateProtyMngAcs.UTILITYDIV_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			
			third.Add(RateProtyMngAcs.RATEPRIORITYORDER, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleRight, "", Color.Black));
			third.Add(RateProtyMngAcs.RATESETTINGDIVIDE, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));

			third.Add(RateProtyMngAcs.RATEMNGGOODSCD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			third.Add(RateProtyMngAcs.RATEMNGGOODSNM, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			third.Add(RateProtyMngAcs.RATEMNGCUSTCD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			third.Add(RateProtyMngAcs.RATEMNGCUSTNM, new GridColAppearance(MGridColDispType.ListOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			
            _hashtable = new Hashtable[3];
            _hashtable[0] = main;
            _hashtable[1] = second;
            _hashtable[2] = third;
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
            //==========================
            // メインテーブル定義
            //==========================
            DataTable mainTable = new DataTable(MAIN_TABLE);

			// 拠点コード
			mainTable.Columns.Add(RateProtyMngAcs.SECTIONCODE, typeof(string));
			// 拠点名称
			mainTable.Columns.Add(RateProtyMngAcs.SECTIONNAME, typeof(string));

			DataColumn[] primaryKey1 = { mainTable.Columns[RateProtyMngAcs.SECTIONCODE] };
			mainTable.PrimaryKey = primaryKey1;

			this._bindDataSet.Tables.Add(mainTable);

            //==========================
            // セカンドテーブル定義
            //==========================
            DataTable secondTable = new DataTable(SECOND_TABLE);

			// 拠点コード
			secondTable.Columns.Add(RateProtyMngAcs.SECTIONCODE, typeof(string));
			// 拠点名称
			secondTable.Columns.Add(RateProtyMngAcs.SECTIONNAME, typeof(string));
			// 単価種類
			secondTable.Columns.Add(RateProtyMngAcs.UNITPRICEKIND, typeof(int));
			// 単価種類（名称）
			secondTable.Columns.Add(RateProtyMngAcs.UNITPRICEKINDNM, typeof(string));
			// 使用区分
			secondTable.Columns.Add(RateProtyMngAcs.UTILITYDIV_TITLE, typeof(string));

			DataColumn[] primaryKey2 = { secondTable.Columns[RateProtyMngAcs.UNITPRICEKIND] };
			secondTable.PrimaryKey = primaryKey2;

			this._bindDataSet.Tables.Add(secondTable);

            //==========================
            // サードテーブル定義
            //==========================
            DataTable thirdTable = new DataTable(THIRD_TABLE);

			// 作成日付
			thirdTable.Columns.Add(RateProtyMngAcs.CREATEDATETIME, typeof(DateTime));
			//更新日付
			thirdTable.Columns.Add(RateProtyMngAcs.UPDATEDATETIME, typeof(DateTime));
			// GUID
			thirdTable.Columns.Add(RateProtyMngAcs.FILEHEADERGUID, typeof(Guid));
			// 削除日
			thirdTable.Columns.Add(RateProtyMngAcs.DELETE_DATE_TITLE, typeof(string));
			// 拠点コード
			thirdTable.Columns.Add(RateProtyMngAcs.SECTIONCODE, typeof(string));
			// 拠点名称
			thirdTable.Columns.Add(RateProtyMngAcs.SECTIONNAME, typeof(string));
			// 単価種類
			thirdTable.Columns.Add(RateProtyMngAcs.UNITPRICEKIND, typeof(int));
			// 単価種類（名称）
			thirdTable.Columns.Add(RateProtyMngAcs.UNITPRICEKINDNM, typeof(string));
			// 使用区分
			thirdTable.Columns.Add(RateProtyMngAcs.UTILITYDIV_TITLE, typeof(string));
			// 順位
			thirdTable.Columns.Add(RateProtyMngAcs.RATEPRIORITYORDER, typeof(int));
			// 区分
			thirdTable.Columns.Add(RateProtyMngAcs.RATESETTINGDIVIDE, typeof(string));
			// 区分（商品）非表示
			thirdTable.Columns.Add(RateProtyMngAcs.RATEMNGGOODSCD, typeof(string));
			// 商品情報
			thirdTable.Columns.Add(RateProtyMngAcs.RATEMNGGOODSNM, typeof(string));
			// 区分（得意先）非表示
			thirdTable.Columns.Add(RateProtyMngAcs.RATEMNGCUSTCD, typeof(string));
			// 得意先情報
			thirdTable.Columns.Add(RateProtyMngAcs.RATEMNGCUSTNM, typeof(string));

			DataColumn[] primaryKey3 = { thirdTable.Columns[RateProtyMngAcs.RATEPRIORITYORDER] };
			thirdTable.PrimaryKey = primaryKey3;

			this._bindDataSet.Tables.Add(thirdTable);
		}

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        private void ScreenInitialSetting()
        {
			//--------------------
			// コンボボックス設定
			//--------------------
			// コンボボックス初期化
			this.UtilityDiv_tComboEditor.Items.Clear();
            this.RateSettingDivideGoods_tComboEditor.Items.Clear();
            this.RateSettingDivideGoods_tComboEditor.MaxDropDownItems = 13;
			this.RateSettingDivideCust_tComboEditor.Items.Clear();
			
			// コンボボックス用データテーブル設定
            /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
            SetComboDataInt(ref RateProtyMng._utilityDivTable, ref this._dataTableUtilityDiv);
               --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/
            SetComboDataStrDefault(ref RateProtyMng._rateSettingDivideGoodsTable, ref this._dataTableGoods);
			SetComboDataStrDefault(ref RateProtyMng._rateSettingDivideCustTable, ref this._dataTableCust);
			
			// コンボボックスバインド
            /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
			BindCombo(ref this.UtilityDiv_tComboEditor, ref this._dataTableUtilityDiv);
               --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/
            BindCombo(ref this.RateSettingDivideGoods_tComboEditor, ref this._dataTableGoods);
			BindCombo(ref this.RateSettingDivideCust_tComboEditor, ref this._dataTableCust);
			
			// 使用区分ワークデータ初期化
			this._utilityDivtComboEditorValue = -1;
			
			// コンボボックス選択状態
			this._rateSettingDivideGoods_tComboEditorValue = "";
			this._rateSettingDivideCust_tComboEditorValue = "";

			// モードラベル
			this.Mode_Label.Text = INSERT_MODE;
			
			// グリッド追加
            //GridInitialSetting(ref this.RateSettingDivide_uGrid, ref this._listDataTable);
			GridInitialSetting(ref this.RateSettingDivideSet_uGrid, ref this._listSaveDataTable);
			
			// クローン作成
			this._listSaveDataTableClone = new DataTable();
			this._listSaveDataTableClone = this._listSaveDataTable.Clone();
		}

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.11</br>
		/// </remarks>
        private void ScreenClear()
		{
			// ボタン
			this.Ok_Button.Visible		= true;	// 保存ボタン
			this.Cancel_Button.Visible	= true;	// 閉じるボタン
			this.Add_uButton.Enabled	= true;	// 追加ボタン
			this.Del_uButton.Enabled	= true;	// 削除ボタン
            // --- DEL 2009/01/13 --------------------------------------------------------------------->>>>>
            //this.Up_uButton.Enabled		= true;	// 上ボタン
            //this.Down_uButton.Enabled	= true;	// 下ボタン
            // --- DEL 2009/01/13 ---------------------------------------------------------------------<<<<<
            this.DispCancel_uButton.Enabled = true;	// 取消ボタン
			
			// コンボボックス位置解除
			this.RateSettingDivideGoods_tComboEditor.Value = "";	// 商品情報コンボボックス
			this.RateSettingDivideCust_tComboEditor.Value = "";		// 得意先／仕入先情報コンボボックス
			
			this._rateSettingDivideGoods_tComboEditorValue = "";	// 商品情報コンボボックス選択状態文字列
			this._rateSettingDivideCust_tComboEditorValue = "";		// 得意先／仕入先情報コンボボックス選択状態文字列
			
			this.UtilityDiv_tComboEditor.Value = 0;	// 使用区分（0:全社共通, 1:拠点設定）
			
			// コンボボックス選択状態解除
			GridFillter();

			//------------------
			// グリッド関連処理
			//------------------
			// グリッド選択状態解除
			CancelSelectUgrid(ref this.RateSettingDivide_uGrid);
			CancelSelectUgrid(ref this.RateSettingDivideSet_uGrid);

			// データテーブル選択状態解除
			CancelSelectDataTable(ref this._listDataTable);
			CancelSelectDataTable(ref this._listSaveDataTable);

			// 選択グリッド更新
			this.RateSettingDivide_uGrid.UpdateData();
			// 確定グリッド更新
			this.RateSettingDivideSet_uGrid.UpdateData();
		}

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.11</br>
		/// </remarks>
        private void ScreenReconstruction()
        {
            switch (this._targetTableName)
            {
				// 拠点テーブルの場合、または、単価種類テーブルの場合
				case MAIN_TABLE:
				case SECOND_TABLE:
                    //{
                    //    break;
                    //}
				// 掛率優先順位設定テーブルの場合
				case THIRD_TABLE:
					{
						this._listSaveDataTable.Rows.Clear();			// 確定データテーブルクリア
						this._listSaveDataTableClone.Rows.Clear();		// 確定データテーブルクローンクリア（元データ）

                        // --- ADD 2008/06/16 --------------------------------------------------------------------->>>>>
                        this._addList = new List<string>();
                        // --- ADD 2008/06/16 ---------------------------------------------------------------------<<<<<

						// 使用区分ワークデータ初期化
						this._utilityDivtComboEditorValue = -1;
						
						// グリッド選択インデックス取得
						DataRow dr1 = this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex];
						DataRow dr2 = this._bindDataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex];
						
						// 選択データテーブルに設定
						foreach (DataRow listDataRow in this._listDataTable.Rows)
						{
							listDataRow[RateMngGoodsCust.SECTIONCODE] = dr1[RateProtyMngAcs.SECTIONCODE];
							listDataRow[RateMngGoodsCust.UNITPRICEKIND] = dr2[RateProtyMngAcs.UNITPRICEKIND];
						}
						
						// 各フラグ解除
						foreach (DataRow wkDr in this._listDataTable.Rows)
						{
							wkDr[RateMngGoodsCust.DATAEXIST_FLAG] = 0;	// グリッド有無フラグ解除
							wkDr[RateMngGoodsCust.HIDDEN_FLAG] = 0;		// 非表示フラグ解除

							wkDr[RateMngGoodsCust.SELECT_FLAG] = false;	// 選択状態解除
							wkDr[RateMngGoodsCust.SELECT] = "";			// 選択表示解除
						}
						
						// 単価種類ラベル設定
						this.UnitPriceKind_label.Text = RateProtyMng.GetUnitPriceKindNm((Int32)dr2[RateProtyMngAcs.UNITPRICEKIND]);

                        this._listDataTable = this._listDataTableAll.Clone();
                        foreach (DataRow dr in this._listDataTableAll.Rows)
                        {
                            this._listDataTable.Rows.Add(dr.ItemArray);
                        }

                        switch ((Int32)dr2[RateProtyMngAcs.UNITPRICEKIND])
                        {
                            // 売価設定、価格設定(No.1～No.71)
                            case 1:
                            case 3:
                                {
                                    break;
                                }
                            // 原価設定(No.51～No.71)
                            case 2:
                                {
                                    for (int index = this._listDataTable.Rows.Count - 1; index >= 0; index--)
                                    {
                                        int rateOrder = (int)this._listDataTable.Rows[index]["RatePriorityOrder"];

                                        //if (rateOrder < 51) // DEL 2012/11/30 王君 Redmine#33663 
                                        if (rateOrder < 51 && rateOrder != 6)   // ADD 2012/11/30 王君 Redmine#33663 
                                        {
                                            this._listDataTable.Rows[index].Delete();
                                        }
                                    }
                                    break;
                                }
                        }

                        GridInitialSetting(ref this.RateSettingDivide_uGrid, ref this._listDataTable);
                        
                        //--------------------
						// 全社共通拠点コード
						//--------------------
						if (string.Equals(dr1[RateProtyMngAcs.SECTIONCODE].ToString(), COM_SECTION_CODE) == true)
						{
							this.message_uLabel.Text = DISP_INFO_MSG;	// 「掛率優先順位設定を行うデータを追加してください。」
							this.Mode_Label.Text = COMMON_MODE;
							this.Ok_Button.Enabled = true;				// 保存ボタン有効
							this.RateSettingDivideGoods_tComboEditor.Enabled = true;
							this.RateSettingDivideCust_tComboEditor.Enabled = true;

                            // --- ADD 2008/06/16 --------------------------------------------------------------------->>>>>
                            this.UtilityDiv_tComboEditor.Items.Clear();
                            this.UtilityDiv_tComboEditor.Items.Add(0, COMMON_MODE);
                            this.UtilityDiv_tComboEditor.Items.Add(999, COMMON_MODE);
                            // --- ADD 2008/06/16 ---------------------------------------------------------------------<<<<<
							
							// 使用区分
                            // --- CHG 2008/06/16 --------------------------------------------------------------------->>>>>
                            //this.UtilityDiv_tComboEditor.Value = 1;
                            this.UtilityDiv_tComboEditor.Value = 999;
                            // --- CHG 2008/06/16 ---------------------------------------------------------------------<<<<<
							this.UtilityDiv_tComboEditor.Enabled = false;
							
							this.RateSettingDivideGoods_tComboEditor.Enabled = true;
							this.RateSettingDivideCust_tComboEditor.Enabled = true;
							
							// 新規の場合
							if (this._thirdDataIndex < 0)
							{
								// 何もしない
							}
							// 更新の場合
							else
							{
								// 画面展開処理
								DataRowToScreen(dr2);
							}
						}
						//--------------------
						// 自拠点コード
						//--------------------
						else
						{
							this.message_uLabel.Text = DISP_INFO_MSG;	// 掛率優先順位設定を行うデータを追加してください。
							this.Ok_Button.Enabled = true;				// 保存ボタン有効
							this.UtilityDiv_tComboEditor.Enabled = true;
							this.RateSettingDivideGoods_tComboEditor.Enabled = true;
							this.RateSettingDivideCust_tComboEditor.Enabled = true;

                            // --- ADD 2008/06/16 --------------------------------------------------------------------->>>>>
                            this.UtilityDiv_tComboEditor.Items.Clear();
                            this.UtilityDiv_tComboEditor.Items.Add(0, COMMON_MODE);
                            this.UtilityDiv_tComboEditor.Items.Add(int.Parse(dr1[RateProtyMngAcs.SECTIONCODE].ToString().Trim()), dr1[RateProtyMngAcs.SECTIONNAME].ToString());
                            // --- ADD 2008/06/16 ---------------------------------------------------------------------<<<<<
							
							// 新規（全社共通）の場合
							if (string.Equals(dr2[RateProtyMngAcs.UTILITYDIV_TITLE].ToString(), RateProtyMngAcs.ALL_SECTION_NAME) == true)
							{
								this.Mode_Label.Text = INSERT_MODE;			// 新規モード
                                this.UtilityDiv_tComboEditor.Value = 0;		// 全社共通
							}
							// 更新（自拠点）の場合
							else
							{
								this.Mode_Label.Text = UPDATE_MODE;			// 更新モード
                                // --- CHG 2008/06/16 --------------------------------------------------------------------->>>>>
                                //this.UtilityDiv_tComboEditor.Value = 1;		// 拠点設定
                                this.UtilityDiv_tComboEditor.Value = int.Parse(dr1[RateProtyMngAcs.SECTIONCODE].ToString().Trim());		// 拠点設定
                                // --- CHG 2008/06/16 ---------------------------------------------------------------------<<<<<

								// 画面展開処理
								DataRowToScreen(dr2);
							}
						}
						
						// データテーブル比較
						CompareDataTable();
						
						// 表示グリッドフィルター設定
						GridFillter();
						
						// 各ボタン表示設定
						UtilityDivVisibleChange((Int32)this.UtilityDiv_tComboEditor.Value);

                        // --- CHG 2008/06/16 --------------------------------------------------------------------->>>>>
						// 先頭行アクティブ化
                        //HeadLineGridActivate(ref this.RateSettingDivide_uGrid);
                        //HeadLineGridActivate(ref this.RateSettingDivideSet_uGrid);
                        HeadLineGridActivate(ref this.RateSettingDivide_uGrid, false);
                        HeadLineGridActivate(ref this.RateSettingDivideSet_uGrid, false);

                        // スクロールポジション初期化
                        this.RateSettingDivide_uGrid.DisplayLayout.RowScrollRegions.Clear();
                        this.RateSettingDivideSet_uGrid.DisplayLayout.RowScrollRegions.Clear();
                        // --- CHG 2008/06/16 ---------------------------------------------------------------------<<<<<
						break;
					}
			}
        }

		/// <summary>
		/// 掛率優先管理マスタクラス画面展開処理
		/// </summary>
		/// <param name="row">掛率優先管理マスタオブジェクト</param>
		/// <remarks>
		/// <br>Note       : オブジェクトから画面にデータを展開します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.17</br>
		/// </remarks>
		private void DataRowToScreen(DataRow row)
		{
			DataRow dr, drClone;
			
			// 確定データテーブルへ設定
			foreach (DataRow bindDataRow in this._bindDataSet.Tables[THIRD_TABLE].Rows)
			{
				// 単価種類が不一致の場合は処理しない
				if (Convert.ToInt32(row[RateProtyMngAcs.UNITPRICEKIND]) != Convert.ToInt32(bindDataRow[RateProtyMngAcs.UNITPRICEKIND]))
				{
					continue;
				}
				
				//----------------------------------
				// 確定データテーブル初期表示用設定
				//----------------------------------
				dr = this._listSaveDataTable.NewRow();

				dr[RateMngGoodsCust.CREATEDATETIME]		= bindDataRow[RateProtyMngAcs.CREATEDATETIME];
				dr[RateMngGoodsCust.UPDATEDATETIME]		= bindDataRow[RateProtyMngAcs.UPDATEDATETIME];
				dr[RateMngGoodsCust.FILEHEADERGUID]		= bindDataRow[RateProtyMngAcs.FILEHEADERGUID];
				dr[RateMngGoodsCust.SECTIONCODE]		= bindDataRow[RateProtyMngAcs.SECTIONCODE];
				dr[RateMngGoodsCust.UNITPRICEKIND]		= bindDataRow[RateProtyMngAcs.UNITPRICEKIND];
				dr[RateMngGoodsCust.RATEPRIORITYORDER]	= bindDataRow[RateProtyMngAcs.RATEPRIORITYORDER];
				dr[RateMngGoodsCust.RATESETTINGDIVIDE]	= bindDataRow[RateProtyMngAcs.RATESETTINGDIVIDE];
				dr[RateMngGoodsCust.RATEMNGGOODSCD]		= bindDataRow[RateProtyMngAcs.RATEMNGGOODSCD];
				dr[RateMngGoodsCust.RATEMNGGOODSNM]		= bindDataRow[RateProtyMngAcs.RATEMNGGOODSNM];
				dr[RateMngGoodsCust.RATEMNGCUSTCD]		= bindDataRow[RateProtyMngAcs.RATEMNGCUSTCD];
				dr[RateMngGoodsCust.RATEMNGCUSTNM]		= bindDataRow[RateProtyMngAcs.RATEMNGCUSTNM];
				
				// 文字列結合(例:A1 ﾒｰｶｰ＋商品 得意先＋仕入先)
				_stringBuilder.Remove(0, _stringBuilder.Length);	// 初期化
                _stringBuilder.Append(dr[RateMngGoodsCust.RATEMNGCUSTCD]);
                _stringBuilder.Append(dr[RateMngGoodsCust.RATEMNGGOODSCD]);
                _stringBuilder.Append(" ");
                _stringBuilder.Append(dr[RateMngGoodsCust.RATEMNGCUSTNM]);
                _stringBuilder.Append("+");
                _stringBuilder.Append(dr[RateMngGoodsCust.RATEMNGGOODSNM]);

				dr[RateMngGoodsCust.RATEMNGALLNM] = _stringBuilder.ToString();
				
				dr[RateMngGoodsCust.DATAEXIST_FLAG] = 0;	// 確定グリッド有無フラグ
				dr[RateMngGoodsCust.HIDDEN_FLAG] = 0;		// 表示フラグ
				
				dr[RateMngGoodsCust.SELECT_FLAG] = false;	// 選択フラグ（false:未選択, true:選択）
				dr[RateMngGoodsCust.SELECT] = "";			// 選択フラグ

				this._listSaveDataTable.Rows.Add(dr);
				
				//------------------------------------
				// 確定データテーブルクローンへコピー
				//------------------------------------
				drClone = this._listSaveDataTableClone.NewRow();

				// アイテムコピー
				for (int i = 0; i < dr.ItemArray.Length; i++)
				{
					drClone[i] = dr[i];
				}
				this._listSaveDataTableClone.Rows.Add(drClone);
			}
		}

		/// <summary>
		/// 掛率優先管理マスタクラス全社共通データ画面展開処理
		/// </summary>
		/// <param name="row">掛率優先管理マスタオブジェクト</param>
		/// <remarks>
		/// <br>Note       : オブジェクトから画面に全社共通データを展開します。</br>
		/// <br>             クローンへはコピーしません。後で保存時の変更チェックのため。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.27</br>
		/// </remarks>
		private void CommonDataRowToScreen(DataRow row)
		{
			string selStr = "";
			_stringBuilder.Remove(0, _stringBuilder.Length);
			_stringBuilder.Append(RateProtyMngAcs.SECTIONCODE);
			_stringBuilder.Append(" = '");
			_stringBuilder.Append(COM_SECTION_CODE);
			_stringBuilder.Append("' and ");
			_stringBuilder.Append(RateProtyMngAcs.UNITPRICEKIND);
			_stringBuilder.Append(" = '");
			_stringBuilder.Append(row[RateProtyMngAcs.UNITPRICEKIND]);
			_stringBuilder.Append("'");
			selStr = _stringBuilder.ToString();

			// 第３データテーブルから拠点コード「000000」,該当単価種類のレコードを検索
			//----- ueno upd ---------- start 2008.02.22 ソート追加
			DataRow[] foundRow = this._rateProtyMngAcs.DtThirdTable.Select(selStr, RateProtyMngAcs.RATEPRIORITYORDER);
			//----- ueno upd ---------- end 2008.02.22

			DataRow dr;

			// 確定データテーブルへ設定
			foreach (DataRow fRow in foundRow)
			{
				//----------------------------------
				// 確定データテーブル初期表示用設定
				//----------------------------------
				dr = this._listSaveDataTable.NewRow();
				
				dr[RateMngGoodsCust.SECTIONCODE]		= row[RateProtyMngAcs.SECTIONCODE];	// 拠点コードは現在選択中のデータを使用
				dr[RateMngGoodsCust.UNITPRICEKIND]		= fRow[RateProtyMngAcs.UNITPRICEKIND];
				dr[RateMngGoodsCust.RATEPRIORITYORDER]	= fRow[RateProtyMngAcs.RATEPRIORITYORDER];
				dr[RateMngGoodsCust.RATESETTINGDIVIDE]	= fRow[RateProtyMngAcs.RATESETTINGDIVIDE];
				dr[RateMngGoodsCust.RATEMNGGOODSCD]		= fRow[RateProtyMngAcs.RATEMNGGOODSCD];
				dr[RateMngGoodsCust.RATEMNGGOODSNM]		= fRow[RateProtyMngAcs.RATEMNGGOODSNM];
				dr[RateMngGoodsCust.RATEMNGCUSTCD]		= fRow[RateProtyMngAcs.RATEMNGCUSTCD];
				dr[RateMngGoodsCust.RATEMNGCUSTNM]		= fRow[RateProtyMngAcs.RATEMNGCUSTNM];
				
				// 文字列結合(例:A1 ﾒｰｶｰ＋商品 得意先＋仕入先)
				_stringBuilder.Remove(0, _stringBuilder.Length);	// 初期化

                _stringBuilder.Append(dr[RateMngGoodsCust.RATEMNGCUSTCD]);
                _stringBuilder.Append(dr[RateMngGoodsCust.RATEMNGGOODSCD]);
				_stringBuilder.Append(" ");
                _stringBuilder.Append(dr[RateMngGoodsCust.RATEMNGCUSTNM]);
				_stringBuilder.Append(" ");
                _stringBuilder.Append(dr[RateMngGoodsCust.RATEMNGGOODSNM]);
                
                dr[RateMngGoodsCust.RATEMNGALLNM] = _stringBuilder.ToString();
				
				dr[RateMngGoodsCust.DATAEXIST_FLAG] = 0;	// 確定グリッド有無フラグ
				dr[RateMngGoodsCust.HIDDEN_FLAG] = 0;		// 表示フラグ

				dr[RateMngGoodsCust.SELECT_FLAG] = false;	// 選択フラグ（false:未選択, true:選択）
				dr[RateMngGoodsCust.SELECT] = "";			// 選択フラグ

				this._listSaveDataTable.Rows.Add(dr);
			}
		}

		/// <summary>
		/// データテーブル比較処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 選択データテーブルと確定データテーブルを比較し、両者存在時、選択データテーブルに表示しません。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private void CompareDataTable()
		{
			// 選択データテーブルと確定データテーブルを比較
			foreach(DataRow listDataRow in this._listDataTable.Rows)
			{
				foreach (DataRow listSaveData in this._listSaveDataTable.Rows)
				{
					if(string.Equals(listDataRow[RateMngGoodsCust.RATESETTINGDIVIDE].ToString(),
						listSaveData[RateMngGoodsCust.RATESETTINGDIVIDE].ToString()) == true)
					{
						// 選択データテーブルの非表示フラグＯＮ
						listDataRow[RateMngGoodsCust.HIDDEN_FLAG] = 1;

						//------------------------------------
						// 更新情報を選択データテーブルへ設定
						//------------------------------------
						listDataRow[RateMngGoodsCust.CREATEDATETIME] = listSaveData[RateMngGoodsCust.CREATEDATETIME];
						listDataRow[RateMngGoodsCust.UPDATEDATETIME] = listSaveData[RateMngGoodsCust.UPDATEDATETIME];
						listDataRow[RateMngGoodsCust.FILEHEADERGUID] = listSaveData[RateMngGoodsCust.FILEHEADERGUID];
					}
				}
			}
		}

		/// <summary>
		///	ＧＲＩＤ初期設定処理
		/// </summary>
		/// <remarks>
		/// <param name="uGrid">ウルトラグリッド</param>
		/// <param name="dataTable">データテーブル</param>
		/// <br>Note		: ＧＲＩＤの初期設定を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private void GridInitialSetting(ref UltraGrid uGrid, ref DataTable dataTable)
		{
			// データソースへ追加
			uGrid.DataSource = dataTable;

			// 選択フラグ設定
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.SELECT_FLAG].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.SELECT_FLAG].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.SELECT_FLAG].Hidden = true;
			
			// 選択設定
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.SELECT].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.SELECT].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.SELECT].Hidden = false;

            // --- ADD 2009/01/13 --------------------------------------------------------------------->>>>>
            uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.RATEPRIORITYORDER].CellActivation = Activation.Disabled;
            uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.RATEPRIORITYORDER].CellClickAction = CellClickAction.CellSelect;
            uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.RATEPRIORITYORDER].Header.Caption = "優先";
            // --- ADD 2009/01/13 ---------------------------------------------------------------------<<<<<

			// 区分表示行はアクティブ化不可（固定項目として設定）
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.RATEMNGALLNM].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;

			//特定列を非表示に
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.CREATEDATETIME].Hidden = true;
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.UPDATEDATETIME].Hidden = true;
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.SECTIONCODE].Hidden = true;
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.UNITPRICEKIND].Hidden = true;
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.RATESETTINGDIVIDE].Hidden = true;
            // --- DEL 2009/01/13 --------------------------------------------------------------------->>>>>
            //uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.RATEPRIORITYORDER].Hidden = true;
            // --- DEL 2009/01/13 ---------------------------------------------------------------------<<<<<
            uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.RATEMNGGOODSCD].Hidden = true;
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.RATEMNGGOODSNM].Hidden = true;
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.RATEMNGCUSTCD].Hidden = true;
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.RATEMNGCUSTNM].Hidden = true;
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.DATAEXIST_FLAG].Hidden = true;
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.HIDDEN_FLAG].Hidden = true;
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.FILEHEADERGUID].Hidden = true;
			
			// セルの幅の設定
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.SELECT].Width = 45;
			uGrid.DisplayLayout.Bands[0].Columns[RateMngGoodsCust.RATEMNGALLNM].Width = 355;

			// アクティブ行の外観設定
			uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
			uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
			uGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			uGrid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
			uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
			uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);
			
			// 行セレクタの外観設定
			uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(89)), ((System.Byte)(135)), ((System.Byte)(214)));
			uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(7)), ((System.Byte)(59)), ((System.Byte)(150)));
			uGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

			// 罫線の色を変更
			uGrid.DisplayLayout.Appearance.BorderColor = Color.FromArgb(1, 68, 208);

		}

        /// <summary>
        /// 保存処理
        /// </summary>
		/// <returns>登録結果（true:OK／false:NG）</returns>
		/// <remarks>
        /// <br>Note		: 画面情報の保存処理を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.11</br>
		/// </remarks>
        private bool SaveProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			//----- ueno add ---------- start 2008.02.20
			//--------------------------------
			// 全社共通選択時
			//--------------------------------
			if((int)this.UtilityDiv_tComboEditor.Value == 0)
			{
				// 元データ有無チェック
				if (_listSaveDataTableClone.Rows.Count > 0)
				{
					// 全社共通データの追加処理を行わないために保存データ全削除
					// この時点で右側の表示がクリアされる。
					this._listSaveDataTable.Rows.Clear();
				}
			}
			//----- ueno add ---------- end 2008.02.20


            string message = "";
			ArrayList rateProtyMngList = new ArrayList();
			ArrayList rateProtyMngDelList = new ArrayList();
			rateProtyMngList.Clear();
			rateProtyMngDelList.Clear();

			RateProtyMng rateProtyMngDelWk;	// 削除データ格納用
			RateProtyMng rateProtyMngWk;	// 追加・更新データ格納用
			
			//----------------
			// 削除データ取得
			//----------------
			foreach(DataRow motoRow in _listSaveDataTableClone.Rows)
			{
				// 削除データ
				if ( Convert.ToInt32(motoRow[RateMngGoodsCust.DATAEXIST_FLAG]) == 0)
				{
                    // 画面情報格納
					status = DispToRateProtyMng(out rateProtyMngDelWk, motoRow, message, 1);

					if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
					{
						TMsgDisp.Show(this, 								// 親ウィンドウフォーム
									   emErrorLevel.ERR_LEVEL_INFO,     	// エラーレベル
									   ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
									   FRM_DTL_MSG,					        // 表示するメッセージ
									   0, 		                            // ステータス値
									   MessageBoxButtons.OK, 				// 表示するボタン
									   MessageBoxDefaultButton.Button1);	// 初期表示ボタン
						return false;
					}
					// 削除データ追加
					rateProtyMngDelList.Add(rateProtyMngDelWk);
				}
			}
			//----------------------
			// 追加・更新データ取得
			//----------------------
			foreach(DataRow svRow in _listSaveDataTable.Rows)
			{
				// 追加・更新データ
				if (Convert.ToInt32(svRow[RateMngGoodsCust.DATAEXIST_FLAG]) != 1)
				{
					int flag = 0;
					
					// フラグ設定（更新データ）
					if (Convert.ToInt32(svRow[RateMngGoodsCust.DATAEXIST_FLAG]) == 2)
					{
						flag = 1;
					}

                    // 画面情報格納
					status = DispToRateProtyMng(out rateProtyMngWk, svRow, message, flag);
					
					if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
					{
						TMsgDisp.Show(this, 								// 親ウィンドウフォーム
									   emErrorLevel.ERR_LEVEL_INFO,     	// エラーレベル
									   ASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
									   FRM_DTL_MSG,							// 表示するメッセージ
									   0, 		                            // ステータス値
									   MessageBoxButtons.OK, 				// 表示するボタン
									   MessageBoxDefaultButton.Button1);	// 初期表示ボタン
						return false;
					}
					// 追加・更新データ追加
					rateProtyMngList.Add(rateProtyMngWk);
				}
			}

			//--------------------
			// テーブルデータ削除
			//--------------------
			if (rateProtyMngDelList.Count > 0)
			{
				// 削除
				status = this._rateProtyMngAcs.Delete(0, ref rateProtyMngDelList, out message);
				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					emErrorLevel emErrLvl = emErrorLevel.ERR_LEVEL_INFO;
					if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
					{
						emErrLvl = emErrorLevel.ERR_LEVEL_STOP;
					}
					TMsgDisp.Show(this,                                 // 親ウィンドウフォーム
								   emErrLvl,                            // エラーレベル
								   ASSEMBLY_ID,                         // アセンブリＩＤまたはクラスＩＤ
								   this.Text, 						    // プログラム名称
								   "SaveProc", 							// 処理名称
								   TMsgDisp.OPE_UPDATE, 				// オペレーション
								   message,                             // 表示するメッセージ
								   status,  							// ステータス値
								   this._rateProtyMngAcs,               // エラーが発生したオブジェクト
								   MessageBoxButtons.OK,                // 表示するボタン
								   MessageBoxDefaultButton.Button1);	// 初期選択ボタン
					return false;
				}
			}
			
			//--------------------
			// テーブルデータ追加
			//--------------------
			if (rateProtyMngList.Count > 0)
			{
				// 書き込み
				status = this._rateProtyMngAcs.Write(ref rateProtyMngList, out message);
				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					emErrorLevel emErrLvl = emErrorLevel.ERR_LEVEL_INFO;
					if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
					{
						emErrLvl = emErrorLevel.ERR_LEVEL_STOP;
					}
					TMsgDisp.Show(this,                                 // 親ウィンドウフォーム
								   emErrLvl,                            // エラーレベル
								   ASSEMBLY_ID,                         // アセンブリＩＤまたはクラスＩＤ
								   this.Text, 						    // プログラム名称
								   "SaveProc", 							// 処理名称
								   TMsgDisp.OPE_UPDATE, 				// オペレーション
								   message,                             // 表示するメッセージ
								   status,  							// ステータス値
								   this._rateProtyMngAcs,               // エラーが発生したオブジェクト
								   MessageBoxButtons.OK,                // 表示するボタン
								   MessageBoxDefaultButton.Button1);	// 初期選択ボタン
					return false;
				}
			}
			
			//-------------------------------------------------------
			// レコードが0件の場合、全社共通使用メッセージを表示する
			//-------------------------------------------------------
			// 確定データテーブルのレコードが無い場合
			if (this._listSaveDataTable.Rows.Count == 0)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					COM_RED_MSG,
					0,
					MessageBoxButtons.OK);
			}

			//----------------------
			// データテーブル再構築
			//----------------------
			int totalCount = 0;
			int readCount = 0;
			
            // データ検索処理(２アレイ目)
			this.SecondDataSearch(ref totalCount, readCount);

            // データ検索処理(３アレイ目)
			this.ThirdDataSearch(ref totalCount, readCount);

			this._bindDataSet.AcceptChanges(); 

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}
			
			// 終了処理
			this.DialogResult = DialogResult.OK;
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}

            return true;
        }

		/// <summary>
		/// 掛率設定区分リスト表示変更
		/// </summary>
		/// <param name="oldTcomboEditorValue">現在選択中の掛率設定区分</param>
		/// <param name="newTcomboEditorValue">新たに選択した掛率設定区分</param>
		/// <remarks>
		/// <br>Note　     : 掛率設定区分の選択を変更したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.11</br>
		/// </remarks>
		private void RateSettingDivideVisibleChange(ref string oldTcomboEditorValue, string newTcomboEditorValue)
		{
			if (string.Compare(oldTcomboEditorValue, newTcomboEditorValue) == 0) return;
			
			// 選択したデータを保持
			oldTcomboEditorValue = newTcomboEditorValue;

			// 選択データで絞り込む
			GridFillter();
		}

		/// <summary>
		/// グリッドデータ絞り込み
		/// </summary>
		/// <remarks>
		/// <br>Note　     : グリッドデータを特定文字列で絞り込みます。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private void GridFillter()
		{
			string fillStr = "";
			
			// 未設定時
			if ((_rateSettingDivideGoods_tComboEditorValue == "") && (_rateSettingDivideCust_tComboEditorValue == ""))
			{
				// 表示フラグがオフのデータをフィルター設定
				_stringBuilder.Remove(0, _stringBuilder.Length);	// 初期化
				_stringBuilder.Append(RateMngGoodsCust.HIDDEN_FLAG);
				_stringBuilder.Append(" = '0'");
				fillStr = _stringBuilder.ToString();
			}
			else
			{
				// 掛率区分（商品）フィルター設定
				if (_rateSettingDivideGoods_tComboEditorValue != "")
				{
					_stringBuilder.Remove(0, _stringBuilder.Length);	// 初期化
					_stringBuilder.Append(RateMngGoodsCust.RATEMNGGOODSCD);
					_stringBuilder.Append("= '");
					_stringBuilder.Append(_rateSettingDivideGoods_tComboEditorValue);
					_stringBuilder.Append("'");
					fillStr = _stringBuilder.ToString();
				}
				// 掛率区分（得意先）フィルター設定
				if (_rateSettingDivideCust_tComboEditorValue != "")
				{
					_stringBuilder.Remove(0, _stringBuilder.Length);	// 初期化

					// 掛率区分（商品）が設定有りか
					if (fillStr != "")
					{
						_stringBuilder.Append(fillStr);	// 掛率区分（商品）設定
						_stringBuilder.Append(" and ");
					}
					_stringBuilder.Append(RateMngGoodsCust.RATEMNGCUSTCD);
					_stringBuilder.Append("= '");
					_stringBuilder.Append(_rateSettingDivideCust_tComboEditorValue);
					_stringBuilder.Append("'");
				}
				// 表示フラグがオフのデータをフィルター設定
				_stringBuilder.Append(" and ");
				_stringBuilder.Append(RateMngGoodsCust.HIDDEN_FLAG);
				_stringBuilder.Append(" = '0'");
				
				fillStr = _stringBuilder.ToString();
			}
			
			// フィルター設定
			this._listDataTable.DefaultView.RowFilter = fillStr;
			
			//------------------
			// グリッド関連処理
			//------------------
			// グリッド選択状態解除
			CancelSelectUgrid(ref this.RateSettingDivide_uGrid);
			CancelSelectUgrid(ref this.RateSettingDivideSet_uGrid);

			// データテーブル選択状態解除
			CancelSelectDataTable(ref this._listDataTable);
			CancelSelectDataTable(ref this._listSaveDataTable);

			// 選択グリッド更新
			this.RateSettingDivide_uGrid.UpdateData();
			// 確定グリッド更新
			this.RateSettingDivideSet_uGrid.UpdateData();
		}
		
		/// <summary>
		/// 元データテーブルと保存データテーブルの変更点を比較
		/// </summary>
		/// <remarks>
		/// <br>Note       : 元データテーブルと保存データテーブルの変更点を比較します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.20</br>
		/// </remarks>
		private bool CompareSaveDataCloneSaveData()
		{	
			int orderNum = 1;	// 優先順位カウンタ
			bool retBool = false;
			
			//--------------------------------
			// 全社共通選択時
			//--------------------------------
			if((int)this.UtilityDiv_tComboEditor.Value == 0)
			{
				// 元データ有無チェック
				if (_listSaveDataTableClone.Rows.Count > 0)
				{
					// 既存データの削除処理を行う
					retBool = true;

					//----- ueno mov ---------- start 2008.02.20
					// この比較処理後の物理削除確認でNO選択時のために、
					// 右側の表示データクリアタイミングをずらす（SaveProcで行う）
					
					//// 全社共通データの追加処理を行わないために保存データ全削除
					//this._listSaveDataTable.Rows.Clear();
					//----- ueno mov ---------- end 2008.02.20
				}
				else
				{
					retBool = false;
				}
			}
			//--------------------------------
			// 自拠点選択時
			//--------------------------------
			else
			{
                //// 現在のデータの優先順位を設定する
                //foreach (UltraGridRow uGridRow in RateSettingDivideSet_uGrid.Rows)
                //{
                //    foreach (DataRow svUgridRow in this._listSaveDataTable.Rows)
                //    {
                //        if (string.Equals(uGridRow.Cells[RateMngGoodsCust.RATESETTINGDIVIDE].Value.ToString(),
                //                svUgridRow[RateMngGoodsCust.RATESETTINGDIVIDE].ToString()) == true)
                //        {
                //            // 優先順位設定
                //            svUgridRow[RateMngGoodsCust.RATEPRIORITYORDER] = orderNum;
                //            orderNum++;
                //        }
                //    }
                //}
				
				//---------------------------------------------------------------------------------------------------------
				// 元データ(clone)と保存データの比較
				//     元データ   DATAEXIT_FLAG 0:削除(保存データ無), 1:保存データ有
				//     保存データ DATAEXIT_FLAG 0:追加(元データ無), 1:元データ有(変更無), 2:更新(元データと順位が異なる)
				//---------------------------------------------------------------------------------------------------------
				
				// 元データ有無チェック
				foreach(DataRow motoRow in this._listSaveDataTableClone.Rows)
				{
					foreach(DataRow svRow in this._listSaveDataTable.Rows)
					{
						// 掛率設定区分で比較
						if(string.Equals(motoRow[RateMngGoodsCust.RATESETTINGDIVIDE].ToString(),
							svRow[RateMngGoodsCust.RATESETTINGDIVIDE].ToString()) == true)
						{
							// データ存在フラグを立てる
							motoRow[RateMngGoodsCust.DATAEXIST_FLAG] = 1;	// 存在
							svRow[RateMngGoodsCust.DATAEXIST_FLAG] = 1;		// 存在
							
							// 優先順位判定
							if(int.Parse(motoRow[RateMngGoodsCust.RATEPRIORITYORDER].ToString())
								== int.Parse(svRow[RateMngGoodsCust.RATEPRIORITYORDER].ToString()))
							{
								// 変更無し
							}
							else
							{
								// 順位変更有り
								svRow[RateMngGoodsCust.DATAEXIST_FLAG] = 2;		// 更新
							}
						}
					}
				}

				// 元データ変更有無チェック(DATAEXIST_FLAG=0 削除データ)
				string fillStr = "";
				_stringBuilder.Remove(0, _stringBuilder.Length);
				_stringBuilder.Append(RateMngGoodsCust.DATAEXIST_FLAG);
				_stringBuilder.Append(" = ");
				_stringBuilder.Append("'0'");
				fillStr = _stringBuilder.ToString();
				
				DataRow[] dRow = _listSaveDataTableClone.Select(fillStr);

				// 保存データ変更有無チェック(DATAEXIST_FLAG=1 元データに存在し、順位が一致)
				fillStr = "";
				_stringBuilder.Remove(0, _stringBuilder.Length);
				_stringBuilder.Append(RateMngGoodsCust.DATAEXIST_FLAG);
				_stringBuilder.Append(" = ");
				_stringBuilder.Append("'1'");
				fillStr = _stringBuilder.ToString();
				
				DataRow[] svDrow = this._listSaveDataTable.Select(fillStr);
				
				// 元データの削除及び保存データの追加が無ければ変更無し
				if ((dRow.Length == 0)&&(this._listSaveDataTable.Rows.Count == svDrow.Length))
				{
					// 変更無し
					retBool = false;
				}
				else
				{
					// 変更有り
					retBool = true;
				}
			}
			return retBool;
		}

		//----- ueno add ---------- start 2008.02.20
		/// <summary>
		/// 物理削除確認処理
		/// </summary>
		/// <returns>true:物理削除OK, false:物理削除NG</returns>
		/// <remarks>
		/// <br>Note       : 物理削除確認処理</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.02.20</br>
		/// </remarks>
		private bool PhysicalDeleteConf()
		{
			bool retBool = false;
			
			// 物理削除確認
			DialogResult result = TMsgDisp.Show(
				this, 								// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
				ASSEMBLY_ID,   						// アセンブリＩＤまたはクラスＩＤ
				CONF_DEL_MSG,						// 表示するメッセージ
				0, 									// ステータス値
				MessageBoxButtons.YesNo, 			// 表示するボタン
				MessageBoxDefaultButton.Button2);	// 初期表示ボタン

			if(result == DialogResult.Yes)
			{
				// 物理削除最終確認
				DialogResult lastResult = TMsgDisp.Show(
					this, 								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
					ASSEMBLY_ID,   						// アセンブリＩＤまたはクラスＩＤ
					CONF_DEL_LAST_MSG,					// 表示するメッセージ
					0, 									// ステータス値
					MessageBoxButtons.YesNo, 			// 表示するボタン
					MessageBoxDefaultButton.Button2);	// 初期表示ボタン
					
				if (lastResult == DialogResult.Yes)
				{
					retBool = true;
				}
			}
			return retBool;
		}
		//----- ueno add ---------- end 2008.02.20

		/// <summary>
		/// 画面情報掛率優先管理設定クラス格納処理
		/// </summary>
		/// <param name="rateProtyMng">掛率優先管理設定オブジェクト</param>
		/// <param name="dr">データロウオブジェクト</param>
		/// <param name="message">エラーメッセージ</param>
		/// <param name="flag">設定フラグ(0:設定しない, 1:設定する)</param>
		/// <remarks>
		/// <br>Note       : 画面情報から掛率優先管理設定オブジェクトにデータを格納します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.20</br>
		/// </remarks>
		private int DispToRateProtyMng(out RateProtyMng rateProtyMng, DataRow dr, string message, int flag)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			rateProtyMng = new RateProtyMng();
			
			message = "";
		
			try
			{
				// 更新、削除時に更新日付を設定する
				if(flag == 1)
				{
					// 作成日付
					rateProtyMng.CreateDateTime = (DateTime)dr[RateMngGoodsCust.CREATEDATETIME];
				    // 更新日付
				    rateProtyMng.UpdateDateTime = (DateTime)dr[RateMngGoodsCust.UPDATEDATETIME];
					// GUID
					rateProtyMng.FileHeaderGuid = (Guid)dr[RateMngGoodsCust.FILEHEADERGUID];
				}

				// 企業コード
				rateProtyMng.EnterpriseCode = this._enterpriseCode;
				// 論理削除区分
				rateProtyMng.LogicalDeleteCode = 0;
				// 拠点コード
                rateProtyMng.SectionCode = (string)this._bindDataSet.Tables[MAIN_TABLE].Rows[this._mainDataIndex][RateProtyMngAcs.SECTIONCODE];
				// 単価種類
				rateProtyMng.UnitPriceKind = Convert.ToInt32( this._bindDataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex][RateProtyMngAcs.UNITPRICEKIND]);
				// 掛率優先順位
				rateProtyMng.RatePriorityOrder = Convert.ToInt32(dr[RateMngGoodsCust.RATEPRIORITYORDER]);
				// 掛率設定区分
				rateProtyMng.RateSettingDivide = dr[RateMngGoodsCust.RATESETTINGDIVIDE].ToString();
				// 掛率設定区分（商品）
				rateProtyMng.RateMngGoodsCd = dr[RateMngGoodsCust.RATEMNGGOODSCD].ToString();
				// 掛率設定名称（商品）
				rateProtyMng.RateMngGoodsNm = dr[RateMngGoodsCust.RATEMNGGOODSNM].ToString();
				// 掛率設定区分（得意先）
				rateProtyMng.RateMngCustCd = dr[RateMngGoodsCust.RATEMNGCUSTCD].ToString();
				// 掛率設定名称（得意先）
				rateProtyMng.RateMngCustNm = dr[RateMngGoodsCust.RATEMNGCUSTNM].ToString();
				
				status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
				rateProtyMng = null;
            }
            return status;
		}

		/// <summary>
		/// 選択グリッド確定グリッド間データコピー
		/// </summary>
		/// <return>コピー結果（true:コピー完了, false:データが無いためコピー無し）</return>
		/// <remarks>
		/// <br>Note       : 選択グリッド⇔確定グリッド間でデータをコピーします。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private bool AddSetGrid()
		{
			int selCnt = 0;	// 選択数取得
			
			// 選択データテーブルから確定データテーブルに追加
			foreach (DataRow dr in this._listDataTable.Rows)
			{
				if ((bool)dr[RateMngGoodsCust.SELECT_FLAG] == true)
				{
                    // --- ADD 2008/06/16 --------------------------------------------------------------------->>>>>
                    bool sameFlg = false;
                    foreach (DataRow dataRow in this._listSaveDataTableClone.Rows)
                    {
                        if (dr[RateMngGoodsCust.RATEMNGALLNM].ToString() ==
                            dataRow[RateMngGoodsCust.RATEMNGALLNM].ToString())
                        {
                            sameFlg = true;
                            break;
                        }
                    }
                    if (sameFlg == false)
                    {
                        // 追加リストに追加
                        this._addList.Add(dr[RateMngGoodsCust.RATEMNGALLNM].ToString());
                    }
                    // --- ADD 2008/06/16 ---------------------------------------------------------------------<<<<<

					this._listSaveDataTable.ImportRow(dr);
					
					// 選択データテーブルの非表示フラグをONにする
					dr[RateMngGoodsCust.HIDDEN_FLAG] = 1;
					
					selCnt++;
				}
			}
			
			// データが無いのでコピーしない
			if(selCnt == 0)
			{
				return false;
			}
			
			//------------------
			// グリッド関連処理
			//------------------
			// グリッド選択状態解除
			CancelSelectUgrid(ref this.RateSettingDivide_uGrid);
			
			// データテーブル選択状態解除
			CancelSelectDataTable(ref this._listDataTable);
			
			// グリッド更新
			this.RateSettingDivide_uGrid.UpdateData();
			this.RateSettingDivideSet_uGrid.UpdateData();

			// 先頭行アクティブ化
            // --- CHG 2008/06/16 --------------------------------------------------------------------->>>>>
            //HeadLineGridActivate(ref this.RateSettingDivide_uGrid);
            HeadLineGridActivate(ref this.RateSettingDivide_uGrid, true);
            // --- CHG 2008/06/16 ---------------------------------------------------------------------<<<<<

			return true;
		}

		/// <summary>
		/// 確定テーブルデータ行削除処理
		/// </summary>
		/// <remarks>
		/// <return>コピー結果（true:コピー完了, false:データが無いためコピー無し）</return>
		/// <br>Note       : 確定データテーブルのデータの行を削除します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private bool DelDataRow()
		{
			int selCnt = 0;	// 選択数取得

			// 選択データの区分一時保存用
			List<string> wkList = new List<string>();

			foreach (DataRow dr in this._listSaveDataTable.Rows)
			{
				if ((bool)dr[RateMngGoodsCust.SELECT_FLAG] == true)
				{
					// 選択データの区分を一時保存
					wkList.Add(dr[RateMngGoodsCust.RATESETTINGDIVIDE].ToString());
					selCnt++;
				}
			}

			// データが無いのでコピーしない
			if (selCnt == 0)
			{
				return false;
			}
			
			// 選択グリッド行の掛率区分を確定データテーブルから検索
			string fillStr;
			DataRow[] selRow = null;
			
			foreach (string rateSettiingDivideWk in wkList)
			{
				// テーブル削除は後ろから処理する
				for (int i = this._listSaveDataTable.Rows.Count - 1; i >= 0; i--)
				{
					if (string.Equals(rateSettiingDivideWk, this._listSaveDataTable.Rows[i][RateMngGoodsCust.RATESETTINGDIVIDE].ToString()) == true)
					{
						// 確定データテーブルから削除
						this._listSaveDataTable.Rows.RemoveAt(i);
					}
				}

				// 選択データテーブルのデータを表示する
				fillStr = "";
				_stringBuilder.Remove(0, _stringBuilder.Length);
				_stringBuilder.Append(RateMngGoodsCust.RATESETTINGDIVIDE);
				_stringBuilder.Append(" = '");
				_stringBuilder.Append(rateSettiingDivideWk);
				_stringBuilder.Append("'");
				fillStr = _stringBuilder.ToString();
				
				selRow = this._listDataTable.Select(fillStr);
				
				if (selRow != null)
				{
					foreach (DataRow wkDr in selRow)
					{
						wkDr[RateMngGoodsCust.HIDDEN_FLAG] = 0;
					}
				}
			}

			//------------------
			// グリッド関連処理
			//------------------
			// グリッド選択状態解除
			CancelSelectUgrid(ref this.RateSettingDivide_uGrid);
			CancelSelectUgrid(ref this.RateSettingDivideSet_uGrid);
			
			// データテーブル選択状態解除
			CancelSelectDataTable(ref this._listDataTable);
			CancelSelectDataTable(ref this._listSaveDataTable);
			
			// グリッド更新
			this.RateSettingDivide_uGrid.UpdateData();
			this.RateSettingDivideSet_uGrid.UpdateData();
			
			// 先頭行アクティブ化
            // --- CHG 2008/06/16 --------------------------------------------------------------------->>>>>
            //HeadLineGridActivate(ref this.RateSettingDivideSet_uGrid);
            HeadLineGridActivate(ref this.RateSettingDivideSet_uGrid, true);
            // --- CHG 2008/06/16 ---------------------------------------------------------------------<<<<<
			
			return true;
		}

        // --- DEL 2009/01/13 --------------------------------------------------------------------->>>>>
        ///// <summary>
        ///// 順位入れ替え処理
        ///// </summary>
        ///// <param name="upDownFlag">上下フラグ</param>
        ///// <param name="getNum">移動数</param>
        ///// <remarks>
        ///// <br>Note		: 上下の順位を入れ替えます。</br>
        ///// <br>Programmer : 30167 上野　弘貴</br>
        ///// <br>Date       : 2007.09.20</br>
        ///// </remarks>
        //private void UpDownButtonClick(int upDownFlag, int getNum)
        //{
        //    UltraGridRow currentRow = null;	// 選択行
			
        //    //選択行が複数行、未選択の場合処理しない
        //    int selCnt = 0;
        //    foreach (UltraGridRow uRow in this.RateSettingDivideSet_uGrid.Rows)
        //    {
        //        if ((bool)uRow.Cells[RateMngGoodsCust.SELECT_FLAG].Value == true)
        //        {
        //            selCnt++;
        //            currentRow = uRow;
        //        }
        //    }
			
        //    if (selCnt != 1)
        //    {
        //        TMsgDisp.Show(
        //            emErrorLevel.ERR_LEVEL_INFO,
        //            this.Name,
        //            SEL_ROW_MSG,
        //            0,
        //            MessageBoxButtons.OK);
        //        return;
        //    }
			
        //    // 上移動処理
        //    if (upDownFlag == 0)
        //    {
        //        //最上位の行の場合と表示名称が空の場合は処理しない
        //        if (currentRow.Index - 1 < 0 || currentRow.Cells[RateMngGoodsCust.RATEMNGALLNM].Value.ToString() == "")
        //        {
        //            return;
        //        }
        //    }
        //    // 下移動処理
        //    else
        //    {
        //        //最下位の行の場合と表示名称が空の場合は処理しない
        //        if (currentRow.Index == RateSettingDivideSet_uGrid.Rows.Count - 1 || currentRow.Cells[RateMngGoodsCust.RATEMNGALLNM].Value.ToString() == "")
        //        {
        //            return;
        //        }
        //    }
			
        //    // 移動先アイテム退避
        //    Object[] wkRowArray = new Object[] { };
        //    wkRowArray = this._listSaveDataTable.Rows[currentRow.Index].ItemArray;

        //    // 選択アイテム移動
        //    for (int i = 0; i < _listSaveDataTable.Columns.Count; i++)
        //    {
        //        this._listSaveDataTable.Rows[currentRow.Index][i] = this._listSaveDataTable.Rows[currentRow.Index + getNum][i];
        //    }

        //    // 退避アイテムを戻す
        //    if (wkRowArray.Length == this._listSaveDataTable.Columns.Count)
        //    {
        //        int index = 0;
        //        foreach (Object recField in wkRowArray)
        //        {
        //            this._listSaveDataTable.Rows[currentRow.Index + getNum][index] = recField;
        //            index++;
        //        }
        //    }
			
        //    //------------------
        //    // グリッド関連処理
        //    //------------------
        //    ChangedSelect(true, this.RateSettingDivideSet_uGrid.Rows[currentRow.Index + getNum]);	// 移動先選択状態設定
        //    ChangedSelect(false, this.RateSettingDivideSet_uGrid.Rows[currentRow.Index]);			// 移動元選択状態解除
			
        //    this.RateSettingDivideSet_uGrid.UpdateData();											// グリッドの変更を反映

        //    // --- ADD 2008/06/16 --------------------------------------------------------------------->>>>>
        //    // 追加行文字色変更処理
        //    ChangeForeColorOfAddRow();
        //    // --- ADD 2008/06/16 ---------------------------------------------------------------------<<<<<
        //}
        // --- DEL 2009/01/13 ---------------------------------------------------------------------<<<<<

        // --- ADD 2008/06/16 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グリッド追加行文字色変更処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドの追加行の文字色を変更します。</br>
        /// <br>Programmer : 30414　忍　幸史</br>
        /// <br>Date       : 2008/06/16</br>
        /// </remarks>
        private void ChangeForeColorOfAddRow()
        {
            for (int rowIndex = 0; rowIndex < this.RateSettingDivideSet_uGrid.Rows.Count; rowIndex++)
            {
                // 結合掛率設定区分（グリッド表示用）取得
                string rateSettingDivName = (string)this.RateSettingDivideSet_uGrid.Rows[rowIndex].Cells[RateMngGoodsCust.RATEMNGALLNM].Value;

                // 追加リストの行数分だけループ
                for (int addIndex = 0; addIndex < this._addList.Count; addIndex++)
                {
                    if (rateSettingDivName == this._addList[addIndex])
                    {
                        // 追加行の文字色を変更(赤)
                        this.RateSettingDivideSet_uGrid.DisplayLayout.Rows[rowIndex].Cells[RateMngGoodsCust.RATEMNGALLNM].Appearance.ForeColorDisabled = Color.Red;
                        break;
                    }
                    else
                    {
                        // 追加行ではない文字色を設定(黒)
                        this.RateSettingDivideSet_uGrid.DisplayLayout.Rows[rowIndex].Cells[RateMngGoodsCust.RATEMNGALLNM].Appearance.ForeColorDisabled = Color.Black;
                    }
                }
            }
        }
        // --- ADD 2008/06/16 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// グリッド表示状態取消処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド表示状態を初回起動時に戻します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.12.25</br>
        /// </remarks>
        private void GridCancel()
		{
			// 確認メッセージ出力
			DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_INFO,		                  // エラーレベル
				ASSEMBLY_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
				PRE_STAT_QMSG,							              // 表示するメッセージ
				0, 					                                  // ステータス値
				MessageBoxButtons.YesNo);							  // 表示するボタン
			
			if (res == DialogResult.Yes)
			{
				ScreenClear();
				Initial_Timer.Enabled = true;
			}
		}
		
		/// <summary>
		/// 確定グリッド追加チェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 確定グリッドにデータを設定可能かチェックします。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private bool AddSetGridCheck()
		{
			bool retBool = false;
			int selCnt = 0;
			// 選択数＋設定数 <= 20個ならば追加可能とする
			foreach(DataRow dr in this._listDataTable.Rows)
			{
				if ((bool)dr[RateMngGoodsCust.SELECT_FLAG] == true)
				{
					selCnt++;
				}
			}
			
			if ((selCnt + this.RateSettingDivideSet_uGrid.Rows.Count) <= MAX_SELECT_LIST)
			{
				retBool = true;
			}
			return retBool;
		}

		/// <summary>
		/// コンボボックス用データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <param name="wkTable">データテーブル</param>
		/// <br>Note       : コンボボックス用データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void DataTblColumnComboInt(ref DataTable wkTable)
		{
			wkTable.Columns.Add(COMBO_CODE, typeof(Int32));		// コード
			wkTable.Columns.Add(COMBO_NAME, typeof(string));	// 名称

			// プライマリキー設定
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COMBO_CODE] };
		}

		/// <summary>
		/// コンボボックス用データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <param name="wkTable">データテーブル</param>
		/// <br>Note       : コンボボックス用データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void DataTblColumnComboStr(ref DataTable wkTable)
		{
			// コンボボックス表示項目
			wkTable.Columns.Add(COMBO_CODE, typeof(string));	// コード
			wkTable.Columns.Add(COMBO_NAME, typeof(string));	// 名称

			// プライマリキー設定
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COMBO_CODE] };
		}

        /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// コンボボックスデータ設定
		/// </summary>
		/// <remarks>
		/// <param name="sList">ソートリスト</param>
		/// <param name="dataTable">データテーブル</param>
		/// <br>Note       : コンボボックスデータを設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void SetComboDataInt(ref SortedList sList, ref DataTable dataTable)
		{
			try
			{
				foreach (DictionaryEntry de in sList)
				{
					DataRow dr = dataTable.NewRow();

					dr[COMBO_CODE] = (Int32)de.Key;
					dr[COMBO_NAME] = de.Value.ToString();

					dataTable.Rows.Add(dr);
				}
			}
			catch
			{
			}
		}
           --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>
		/// コンボボックスデフォルトデータ設定
		/// </summary>
		/// <remarks>
		/// <param name="sList">ソートリスト</param>
		/// <param name="dataTable">データテーブル</param>
		/// <br>Note       : コンボボックスデフォルトデータを先頭に設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void SetComboDataStrDefault(ref SortedList sList, ref DataTable dataTable)
		{
			try
			{
                // ADD 2009/06/11 ------>>>
                // データテーブルの行を削除
                dataTable.Rows.Clear();
                // ADD 2009/06/11 ------<<<
                
				DataRow dr = dataTable.NewRow();

				dr[COMBO_CODE] = "";
				dr[COMBO_NAME] = "";
				
				dataTable.Rows.Add(dr);

                // コンボボックスデータ設定
				SetComboDataStr(ref sList, ref dataTable);
			}
			catch
			{
			}
		}

		/// <summary>
		/// コンボボックスデータ設定
		/// </summary>
		/// <remarks>
		/// <param name="sList">ソートリスト</param>
		/// <param name="dataTable">データテーブル</param>
		/// <br>Note       : コンボボックスデータを設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void SetComboDataStr(ref SortedList sList, ref DataTable dataTable)
		{
			try
			{
				foreach (DictionaryEntry de in sList)
				{
					DataRow dr = dataTable.NewRow();

					dr[COMBO_CODE] = de.Key.ToString();
					dr[COMBO_NAME] = de.Value.ToString();

					dataTable.Rows.Add(dr);
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// コンボボックスバインド
		/// </summary>
		/// <remarks>
		/// <param name="tCombo">TComboEditor</param>
		/// <param name="dataTable">データテーブル</param>
		/// <br>Note       : コンボボックスにバインドします。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void BindCombo(ref TComboEditor tCombo, ref DataTable dataTable)
		{
			tCombo.DisplayMember = COMBO_NAME;
			tCombo.DataSource = dataTable.DefaultView;
		}

		/// <summary>
		/// 使用区分確認表示処理
		/// </summary>
		/// <param name="utilityDiv">使用区分</param>
		/// <remarks>
		/// <br>Note　     : 使用区分選択を変更したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void UtilityDivConfirm(int utilityDiv)
		{
			if (this._utilityDivtComboEditorValue == utilityDiv) return;
			
			// 使用区分イベント停止
			this.UtilityDiv_tComboEditor.SelectionChangeCommitted -= new EventHandler(this.UtilityDiv_tComboEditor_SelectionChangeCommitted);
			
			// 全社共通設定を選択した場合
			if((Int32)this.UtilityDiv_tComboEditor.Value == 0)
			{
				// 確認メッセージ出力
				DialogResult res = TMsgDisp.Show(this,                // 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_INFO,		                  // エラーレベル
				ASSEMBLY_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
				COM_RED_QMSG,							              // 表示するメッセージ
				0, 					                                  // ステータス値
				MessageBoxButtons.YesNo);							  // 表示するボタン
				
				if (res == DialogResult.Yes)
				{
                    // 使用区分表示変更
					UtilityDivVisibleChange(utilityDiv);
				}
				else
				{
					// 元に戻す
					this.UtilityDiv_tComboEditor.Value = this._utilityDivtComboEditorValue;
				}
			}
			// 拠点設定
			else
			{
                // 使用区分表示変更
				UtilityDivVisibleChange(utilityDiv);
			}
			
			// 使用区分イベント発動
			this.UtilityDiv_tComboEditor.SelectionChangeCommitted += new EventHandler(this.UtilityDiv_tComboEditor_SelectionChangeCommitted);
		}

		/// <summary>
		/// 使用区分表示変更
		/// </summary>
		/// <param name="utilityDiv">使用区分</param>
		/// <remarks>
		/// <br>Note　     : 使用区分選択を変更したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void UtilityDivVisibleChange(int utilityDiv)
		{
			try
			{
				if (this._utilityDivtComboEditorValue == utilityDiv) return;
				
				bool check = true;
				
				// 全社設定
				if(utilityDiv == 0)
				{
                    check = false;	// 各種ボタン有効設定
                    this.message_uLabel.Text = "";	// 表示メッセージ無し

                    // 選択データテーブルの各フラグ解除
                    foreach (DataRow wkDr in this._listDataTable.Rows)
                    {
                        wkDr[RateMngGoodsCust.DATAEXIST_FLAG] = 0;	// グリッド有無フラグ解除
                        wkDr[RateMngGoodsCust.HIDDEN_FLAG] = 0;		// 非表示フラグ解除
                    }

                    // 確定データテーブル全行削除
                    this._listSaveDataTable.Rows.Clear();

                    // 全社共通データ画面展開処理
                    CommonDataRowToScreen(this._bindDataSet.Tables[SECOND_TABLE].Rows[this._secondDataIndex]);

                    // データテーブル比較
                    CompareDataTable();

                    // 表示グリッドフィルター設定
                    GridFillter();
				}
				else
				{
					check = true;	// 各種ボタン有効設定
					this.message_uLabel.Text = DISP_INFO_MSG;	// 表示メッセージ
				}

			    // 各ボタン設定
			    this.Add_uButton.Enabled	= check;
			    this.Del_uButton.Enabled	= check;
                // --- DEL 2009/01/13 --------------------------------------------------------------------->>>>>
                //this.Up_uButton.Enabled		= check;
                //this.Down_uButton.Enabled	= check;
                // --- DEL 2009/01/13 ---------------------------------------------------------------------<<<<<
				
				this.RateSettingDivide_uGrid.Enabled = check;
				this.RateSettingDivideSet_uGrid.Enabled = check;
				
				// 選択した番号を保持
				this._utilityDivtComboEditorValue = utilityDiv;
			}
			catch
			{
			}
		}

		/// <summary>
		/// 選択・非選択変更処理
		/// </summary>
		/// <param name="isSelected">[T:選択,F:非選択]</param>
		/// <param name="gridRow">対象のグリッド行</param>
		/// <remarks>
		/// <br>Note　　　 : 選択・非選択状態を変更します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void ChangedSelect(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
		{
			if (gridRow == null) return;

			// 対象行の選択色を設定する
			if (isSelected)
			{
				gridRow.Appearance.BackColor = _selectedBackColor;
				gridRow.Appearance.BackColor2 = _selectedBackColor2;
				gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

				gridRow.Cells[RateMngGoodsCust.SELECT].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			}
			else
			{
				if (gridRow.Index % 2 == 1)
				{
					gridRow.Appearance.BackColor = Color.Lavender;
				}
				else
				{
					gridRow.Appearance.BackColor = Color.White;
				}
				gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
				gridRow.Cells[RateMngGoodsCust.SELECT].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.Default;
			}

			// 選択・非選択
			gridRow.Cells[RateMngGoodsCust.SELECT].Value = isSelected ? "選択" : "";
			gridRow.Cells[RateMngGoodsCust.SELECT_FLAG].Value = isSelected;
		}

		/// <summary>
		/// グリッド先頭行アクティブ化
		/// </summary>
		/// <remarks>
		/// <br>Note　　　 : グリッド先頭行をアクティブ化します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
        // --- CHG 2008/06/16 --------------------------------------------------------------------->>>>>
        //private void HeadLineGridActivate(ref UltraGrid uGrid)
		private void HeadLineGridActivate(ref UltraGrid uGrid, bool checkFlg)
        // --- CHG 2008/06/16 ---------------------------------------------------------------------<<<<<
		{
			// アクティブロウ有無判定
			bool activeRowFlag = false;

            // --- CHG 2008/06/16 --------------------------------------------------------------------->>>>>
            //foreach (UltraGridRow uRow in uGrid.Rows)
            //{
            //    if ((bool)uRow.Activated == true)
            //    {
            //        activeRowFlag = true;
            //        break;
            //    }
            //}
            if (checkFlg == true)
            {
                foreach (UltraGridRow uRow in uGrid.Rows)
                {
                    if ((bool)uRow.Activated == true)
                    {
                        activeRowFlag = true;
                        break;
                    }
                }
            }
            // --- CHG 2008/06/16 ---------------------------------------------------------------------<<<<<

			// アクティブロウが無い場合
			if(activeRowFlag == false)
			{
				foreach(UltraGridRow uRow in uGrid.Rows)
				{
					if((int)uRow.Cells[RateMngGoodsCust.HIDDEN_FLAG].Value == 0)
					{
						uRow.Activate();
						break;
					}
				}
			}
		}

		/// <summary>
		/// グリッド選択解除処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　 : 選択状態を解除します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void CancelSelectUgrid(ref UltraGrid uGrid)
		{
			foreach (UltraGridRow uRow in uGrid.Rows)
			{
				// 選択・非選択状態を変更します
				ChangedSelect(false, uRow);
                        
                uRow.Selected = false;  // ADD 2008/10/07 不具合対応[6291]
			}
		}

		/// <summary>
		/// データテーブル選択解除処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　 : 選択状態を解除します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void CancelSelectDataTable(ref DataTable dataTable)
		{
			foreach (DataRow dr in dataTable.Rows)
			{
				dr[RateMngGoodsCust.SELECT_FLAG] = false;
				dr[RateMngGoodsCust.SELECT] = "";
			}
		}

		/// <summary>
		/// DCKHN09100UA_Load イベント(DCKHN09100UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.11</br>
		/// </remarks>
		private void DCKHN09100UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList16 = IconResourceManagement.ImageList16;
			ImageList imageList24 = IconResourceManagement.ImageList24;
			
			this.Ok_Button.ImageList = imageList24;
			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.ImageList = imageList24;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            // --- DEL 2009/01/13 --------------------------------------------------------------------->>>>>
            //this.Up_uButton.ImageList = imageList24;
            //this.Up_uButton.Appearance.Image = Size24_Index.LATERARROW;
            //this.Down_uButton.ImageList = imageList24;
            //this.Down_uButton.Appearance.Image = Size24_Index.BUTTOMARROW;
            // --- DEL 2009/01/13 ---------------------------------------------------------------------<<<<<
            this.DispCancel_uButton.ImageList = imageList16;
			this.DispCancel_uButton.Appearance.Image = Size16_Index.UNDO;
			
			// 画面クリア
			ScreenClear();

			// 画面初期設定
            ScreenInitialSetting();
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)(SF100%流用)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過したときに発生します。</br>
        ///	<br>             この処理は、システムが提供するスレッド プール</br>
        ///	<br>             スレッドで実行されます。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.11</br>
		/// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;

           

            // 画面再構築処理
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.VisibleChanged イベント(MAKHN09810UA)(SF100%流用)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : フォームの表示状態が変わったときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.11</br>
		/// </remarks>
        private void DCKHN09100UA_VisibleChanged(object sender, EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // 画面クリア
            ScreenClear();

            Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click イベント(OK_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンがクリックされたときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.11</br>
		/// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // 変更点チェック
            if (CompareSaveDataCloneSaveData() == true)
            {
                //----- ueno add ---------- start 2008.02.20
                // 全社共通または、データ無しの場合
                if (((int)this.UtilityDiv_tComboEditor.Value == 0) || (this._listSaveDataTable.Rows.Count == 0))
                {
                    // 物理削除確認
                    if (PhysicalDeleteConf() == false) return;
                }
                //----- ueno add ---------- end 2008.02.20

                if (!SaveProc())
                {
                    // 失敗した場合は元に戻す
                    ScreenClear();

                    Initial_Timer.Enabled = true;
                }
            }
            // --- ADD 2008/06/16 --------------------------------------------------------------------->>>>>
            else
            {
                if (UnDisplaying != null)
                {
                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                    UnDisplaying(this, me);
                }

                // 終了処理
                this.DialogResult = DialogResult.OK;
                if (CanClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
            }
            // --- ADD 2008/06/16 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// Control.Click イベント(Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンがクリックされたときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.11</br>
		/// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
			// 変更点チェック
			if(CompareSaveDataCloneSaveData() == true)
			{
				//画面情報が変更されていた場合は、保存確認メッセージを表示する
				DialogResult res = TMsgDisp.Show(
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
					ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
					"",									// 表示するメッセージ 
					0,									// ステータス値
					MessageBoxButtons.YesNoCancel);		// 表示するボタン

				switch (res)
				{
					case DialogResult.Yes:
						{
							//----- ueno add ---------- start 2008.02.20
							// 全社共通または、データ無しの場合
							if (((int)this.UtilityDiv_tComboEditor.Value == 0) || (this._listSaveDataTable.Rows.Count == 0))
							{
								// 物理削除確認
								if (PhysicalDeleteConf() == false) return;
							}
							//----- ueno add ---------- end 2008.02.20

							if (!SaveProc())
							{
								// 失敗した場合は元に戻して終了
								ScreenClear();
							}
							break;
						}
					case DialogResult.No:
						{
							this.DialogResult = DialogResult.Cancel;
							break;
						}
					default:
						{
							this.Cancel_Button.Focus();
							return;
						}
				}
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
        }

        /// <summary>
        /// Form.Closing イベント(DCKHN09100UA)(SF100%流用)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.11</br>
		/// </remarks>
        private void DCKHN09100UA_Closing(object sender, FormClosingEventArgs e)
        {
            // フォームの「×」をクリックされた場合の対応です。
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

		/// <summary>
		/// Control.Click イベント(Add_Button_Click)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 追加ボタンがクリックされたときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.11</br>
		/// </remarks>
		private void Add_Button_Click(object sender, EventArgs e)
		{
            // 確定グリッド追加チェック
			if (AddSetGridCheck() == true)
			{
                /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
                // 選択グリッド確定グリッド間データコピー
				if (AddSetGrid() == true)
				{
                    // グリッドデータ絞り込み
					GridFillter();
				}
                   --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/16 --------------------------------------------------------------------->>>>>
                // 選択グリッド確定グリッド間データコピー
                if (AddSetGrid() != true)
                {
                    return;
                }

                // グリッドデータ絞り込み
                GridFillter();

                // 追加行文字色変更処理
                ChangeForeColorOfAddRow();
                // --- ADD 2008/06/16 ---------------------------------------------------------------------<<<<<
			}
			// エラーメッセージ出力
			else
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					MAX_SEL_OVER_MSG,
					0,
					MessageBoxButtons.OK);
			}
		}

		/// <summary>
		/// Control.Click イベント(Del_uButton_Click)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 削除ボタンがクリックされたときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.11</br>
		/// </remarks>
		private void Del_uButton_Click(object sender, EventArgs e)
		{
            // 確定テーブルデータ行削除
			if (DelDataRow() == true)
			{
                // グリッドデータ絞り込み
				GridFillter();
			}
		}

		/// <summary>
		/// Control.Click イベント(Cancel_uButton_Click)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 取消ボタンがクリックされたときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.11</br>
		/// </remarks>
		private void Cancel_uButton_Click(object sender, EventArgs e)
		{
			// グリッド表示状態を最初の状態に戻す
			GridCancel();
		}

        // --- DEL 2009/01/13 --------------------------------------------------------------------->>>>>
        ///// <summary>
        ///// Control.Click イベント(Up_uButton_Click)
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 上へボタンがクリックされたときに発生します。</br>
        ///// <br>Programmer : 30167 上野　弘貴</br>
        ///// <br>Date       : 2007.09.11</br>
        ///// </remarks>
        //private void Up_uButton_Click(object sender, EventArgs e)
        //{
        //    // 順位入れ替え処理
        //    UpDownButtonClick(0, -1);
        //}

        ///// <summary>
        ///// Control.Click イベント(Down_uButton_Click)
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 下へボタンがクリックされたときに発生します。</br>
        ///// <br>Programmer : 30167 上野　弘貴</br>
        ///// <br>Date       : 2007.09.11</br>
        ///// </remarks>
        //private void Down_uButton_Click(object sender, EventArgs e)
        //{
        //    // 順位入れ替え処理
        //    UpDownButtonClick(1, 1);
        //}
        // --- DEL 2009/01/13 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// UtilityDiv_tComboEditor_SelectionChangeCommitted イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　 : 使用区分が変化したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void UtilityDiv_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.UtilityDiv_tComboEditor.Value != null)
			{
				// 使用区分変更確認
				UtilityDivConfirm((Int32)this.UtilityDiv_tComboEditor.Value);
			}
		}

		/// <summary>
		/// RateSettingDivideGoods_tComboEditor_SelectionChangeCommitted イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 掛率設定区分(商品情報)が変化したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.11</br>
		/// </remarks>
		private void RateSettingDivideGoods_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (RateSettingDivideGoods_tComboEditor.Value != null)
			{
                // 掛率設定区分リスト表示変更
				RateSettingDivideVisibleChange(
					ref this._rateSettingDivideGoods_tComboEditorValue,
					this.RateSettingDivideGoods_tComboEditor.Value.ToString());
			}
		}

		/// <summary>
		///  RateSettingDivideCust_tComboEditor_SelectionChangeCommittedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 掛率設定区分(得意先情報)が変化したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.11</br>
		/// </remarks>
		private void RateSettingDivideCust_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (RateSettingDivideCust_tComboEditor.Value != null)
			{
                // 掛率設定区分リスト表示変更
				RateSettingDivideVisibleChange(
					ref this._rateSettingDivideCust_tComboEditorValue,
					this.RateSettingDivideCust_tComboEditor.Value.ToString());
			}
		}

		/// <summary>
		/// tArrowKeyControl1_ChangeFocusイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : コンボボックスやチェックボックスでキーボード押下時に発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.11</br>
		/// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

			switch(e.PrevCtrl.Name)
			{
				// 使用区分
				case "UtilityDiv_tComboEditor":
					{
						if(this.UtilityDiv_tComboEditor.Value != null)
						{
							// 使用区分変更確認
							UtilityDivConfirm((Int32)this.UtilityDiv_tComboEditor.Value);
						}
						break;
					}
				// 掛率設定区分（商品）
				case "RateSettingDivideGoods_tComboEditor":
					{
						if (this.RateSettingDivideGoods_tComboEditor.Value != null)
						{
                            // 掛率設定区分リスト表示変更
							RateSettingDivideVisibleChange(
								ref this._rateSettingDivideGoods_tComboEditorValue,
								this.RateSettingDivideGoods_tComboEditor.Value.ToString());
						}
						break;
					}
				// 掛率設定区分（得意先）
				case "RateSettingDivideCust_tComboEditor":
					{
						if (this.RateSettingDivideCust_tComboEditor.Value != null)
						{
                            // 掛率設定区分リスト表示変更
							RateSettingDivideVisibleChange(
								ref this._rateSettingDivideCust_tComboEditorValue,
								this.RateSettingDivideCust_tComboEditor.Value.ToString());
						}
						break;
					}
			}
		}

		#region グリッドイベント

		/// <summary>
		/// グリッドクリックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// <br>Note		: グリッド上でクリックされた時に発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void RateSettingDivide_uGrid_Click(object sender, EventArgs e)
		{
			// イベントソースの取得
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

			try
			{
				// マウスポインタがグリッドのどの位置にあるかを判定する
				Point point = System.Windows.Forms.Cursor.Position;
				point = targetGrid.PointToClient(point);

				// UIElementを取得する。
				Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
				if (objUIElement == null)
					return;

				// マウスポインターが列のヘッダ上にあるかチェック。
				Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
					(Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

				if (objHeader != null) return;

				// マウスポインターが行の上にあるかチェック。
				Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
					(Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

				if (objRow == null) return;

				// マウスポインターが行の上にあるかチェック。
				Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
					(Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

				// 選択・非選択セル、及び、掛率設定区分名称以外はキャンセル
                // --- CHG 2009/01/13 --------------------------------------------------------------------->>>>>
                //if ((objCell.Column.Key == RateMngGoodsCust.SELECT) || (objCell.Column.Key == RateMngGoodsCust.RATEMNGALLNM))
                if ((objCell.Column.Key == RateMngGoodsCust.SELECT) || (objCell.Column.Key == RateMngGoodsCust.RATEMNGALLNM) ||
                    (objCell.Column.Key == RateMngGoodsCust.RATEPRIORITYORDER))
                // --- CHG 2009/01/13 ---------------------------------------------------------------------<<<<<
                {
					bool isSelected = (bool)objRow.Cells[RateMngGoodsCust.SELECT_FLAG].Value;
					
					// 選択・非選択状態を変更します
					this.ChangedSelect(!isSelected, objRow);

                    // --- ADD 2009/01/13 --------------------------------------------------------------------->>>>>
                    for (int index = 0; index < targetGrid.Rows.Count; index++)
                    {
                        targetGrid.Rows[index].Selected = false;
                        targetGrid.Rows[index].Activated = false;
                    }

                    objRow.Selected = true;
                    // --- ADD 2009/01/13 ---------------------------------------------------------------------<<<<<
                }
			}
			catch
			{
			}
		}

        // --- ADD 2008/06/16 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グリッドKeyDownイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: グリッド上でキーを押した時に発生します。</br>
        /// <br>Programmer  : 30414 忍　幸史</br>
        /// <br>Date        : 2008/06/16</br>
        /// </remarks>
        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid targetGrid = (UltraGrid)sender;

            if (targetGrid.ActiveRow == null)
            {
                return;
            }

            // アクティブ行取得
            int activeRowIndex = targetGrid.ActiveRow.Index;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    // 先頭行だった場合
                    if (activeRowIndex == 0)
                    {
                        // 得意先／仕入先情報コンボボックスにフォーカスを移します
                        this.RateSettingDivideCust_tComboEditor.Focus();
                    }
                    break;
                case Keys.Down:
                    // 最終行だった場合
                    if (activeRowIndex == targetGrid.Rows.Count - 1)
                    {
                        // 取消ボタンにフォーカスを移します
                        this.DispCancel_uButton.Focus();
                    }
                    break;
                case Keys.Right:
                    if (targetGrid.Name == "RateSettingDivide_uGrid")
                    {
                        // 追加ボタンにフォーカスを移します
                        e.Handled = true;
                        this.Add_uButton.Focus();
                    }
                    else
                    {
                        e.Handled = true;
                    }
                    break;
                case Keys.Left:
                    if (targetGrid.Name == "RateSettingDivide_uGrid")
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        // 追加ボタンにフォーカスを移します
                        e.Handled = true;
                        this.Add_uButton.Focus();
                    }
                    break;
                case Keys.Space:
                    UltraGridRow row = targetGrid.ActiveRow;
                    if (row != null)
                    {
                        bool isSelected = (bool)row.Cells[RateMngGoodsCust.SELECT_FLAG].Value;

                        // 選択・非選択状態を変更します
                        this.ChangedSelect(!isSelected, row);
                    }
                    break;
            }
        }
        // --- ADD 2008/06/16 ---------------------------------------------------------------------<<<<<

        /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// グリッドキーアップイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: グリッド上でキーを離した時に発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void RateSettingDivide_uGrid_KeyUp(object sender, KeyEventArgs e)
		{
			UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
			
			if(targetGrid == null) return;

			switch (e.KeyCode)
			{
				case Keys.Up:	// カーソル上移動
					{
						//--------------
						// セル移動制御
						//--------------
                        if (targetGrid.ActiveRow.Index == 0)
                        {
                            // セル移動不可
                            break;
                        }
                        else
                        {
                            targetGrid.PerformAction(UltraGridAction.AboveCell);
                            e.Handled = true;

                            // 選択状態解除
                            if ((targetGrid.ActiveRow != null) && (targetGrid.ActiveRow.Index == 0))
                            {
                                targetGrid.ActiveRow.Selected = false;
                                targetGrid.ActiveRow = null;
                            }
                        }
						break;
					}
				case Keys.Space:	// 選択
					{
                        Infragistics.Win.UltraWinGrid.UltraGridRow row = targetGrid.ActiveRow;
                        if (row != null)
                        {
                            bool isSelected = (bool)row.Cells[RateMngGoodsCust.SELECT_FLAG].Value;

                            // 選択・非選択状態を変更します
                            this.ChangedSelect(!isSelected, row);
                        }
						break;
					}
			}
		}
           --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/

        #endregion グリッドイベント
    }
}