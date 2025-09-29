using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 価格改正設定マスタ フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 価格改正設定を行います。
    ///					 IMasterMaintenanceSingleTypeを実装しています。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.19</br>
    /// <br></br>
    /// <br>Update Note: BLコード更新区分の追加(MANTIS[0014774])</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2009/12/11</br>    
    /// <br></br>
    /// <br>Update Note: オープン価格区分の項目タイトル変更(MANTIS[0015345])</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/04/28</br>    
    /// <br>Update Note: Redmine#8191 「価格０対応」の選択肢の文字不正の対応</br>
    /// <br>Programmer : 葛中華</br>
    /// <br>Date       : 2011/11/29</br>
    /// <br>Update Note: Redmine#8191の対応</br>
    /// <br>Programmer : 凌小青</br>
    /// <br>Date       : 2011/12/05</br> 
    /// <br>Update Note: 層別更新不具合対応</br>
    /// <br>Programmer : 高峰</br>
    /// <br>Date       : 2012/06/26</br>  
    /// <br>Update Note: BLコード更新不具合対応</br>
    /// <br>Programmer : 宮本</br>
    /// <br>Date       : 2013/01/31</br>  
    /// </remarks>
	public class PMKHN09221UA : System.Windows.Forms.Form, IMasterMaintenanceSingleType
	{
		# region Private Members (Component)

		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Data.DataSet Bind_DataSet;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraLabel lblPartsLayer;
		private Infragistics.Win.Misc.UltraLabel lblName;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraLabel lblPrice;
		private Infragistics.Win.Misc.UltraLabel lblOpenPrice;
        private Infragistics.Win.Misc.UltraLabel lblPriceMngCnt;
        private Infragistics.Win.Misc.UltraLabel lblPriceChgProc;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private THtmlGenerate tHtmlGenerate1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbPriceChgProc;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbPriceMngCnt;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbOpenPrice;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbPartsLayer;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbPrice;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbName;
        private Infragistics.Win.Misc.UltraLabel lblBLGoodsCdUpd;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbBLGoodsCdUpd;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// 価格改正設定情報入力フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 価格改正設定情報入力フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21041　中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public PMKHN09221UA()
		{
			InitializeComponent();

			// データセット列情報構築処理
			DataSetColumnConstruction();

			// プロパティ初期値設定
			this._canPrint = false;
			this._canNew = false;
			this._canDelete = false;
			this._canClose = true;		// デフォルト:true固定
			this._canLogicalDeleteDataExtraction = false;
			this._canSpecificationSearch = false;
			this._defaultAutoFillToColumn = false;

			//　企業コードを取得する
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;


			// 変数初期化
			this._dataIndex = -1;
            this._PriceChgSetAcs = new PriceChgSetAcs();
			this._prevPriceChgSet = null;
			this._nextData = false;
			this._totalCount = 0;
			this._priceChgSetTable = new Hashtable();
            
			this._indexBuf = -2;
		
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
				if (components != null) 
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
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09221UA));
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.lblPartsLayer = new Infragistics.Win.Misc.UltraLabel();
            this.lblName = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.lblOpenPrice = new Infragistics.Win.Misc.UltraLabel();
            this.lblPriceMngCnt = new Infragistics.Win.Misc.UltraLabel();
            this.lblPriceChgProc = new Infragistics.Win.Misc.UltraLabel();
            this.lblPrice = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.tHtmlGenerate1 = new Broadleaf.Library.Windows.Forms.THtmlGenerate(this.components);
            this.cmbPartsLayer = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbOpenPrice = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbPriceMngCnt = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbPriceChgProc = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbName = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbPrice = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbBLGoodsCdUpd = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblBLGoodsCdUpd = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPartsLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOpenPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPriceMngCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPriceChgProc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBLGoodsCdUpd)).BeginInit();
            this.SuspendLayout();
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 330);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(542, 23);
            this.ultraStatusBar1.TabIndex = 46;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Mode_Label
            // 
            appearance41.ForeColor = System.Drawing.Color.White;
            appearance41.TextHAlignAsString = "Center";
            appearance41.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance41;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(415, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 58;
            this.Mode_Label.Text = "更新モード";
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(280, 284);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 136;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(405, 284);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 137;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // lblPartsLayer
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.lblPartsLayer.Appearance = appearance1;
            this.lblPartsLayer.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblPartsLayer.Location = new System.Drawing.Point(33, 74);
            this.lblPartsLayer.Name = "lblPartsLayer";
            this.lblPartsLayer.Size = new System.Drawing.Size(135, 24);
            this.lblPartsLayer.TabIndex = 92;
            this.lblPartsLayer.Text = "層別更新区分";
            // 
            // lblName
            // 
            appearance40.TextVAlignAsString = "Middle";
            this.lblName.Appearance = appearance40;
            this.lblName.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblName.Location = new System.Drawing.Point(33, 44);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(135, 24);
            this.lblName.TabIndex = 91;
            this.lblName.Text = "名称更新区分";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(155, 284);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 135;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Visible = false;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(280, 284);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 136;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Visible = false;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // lblOpenPrice
            // 
            appearance38.TextVAlignAsString = "Middle";
            this.lblOpenPrice.Appearance = appearance38;
            this.lblOpenPrice.Location = new System.Drawing.Point(33, 185);
            this.lblOpenPrice.Name = "lblOpenPrice";
            this.lblOpenPrice.Size = new System.Drawing.Size(135, 23);
            this.lblOpenPrice.TabIndex = 93;
            this.lblOpenPrice.Text = "価格０対応";
            // 
            // lblPriceMngCnt
            // 
            appearance37.TextVAlignAsString = "Middle";
            this.lblPriceMngCnt.Appearance = appearance37;
            this.lblPriceMngCnt.Location = new System.Drawing.Point(33, 215);
            this.lblPriceMngCnt.Name = "lblPriceMngCnt";
            this.lblPriceMngCnt.Size = new System.Drawing.Size(135, 23);
            this.lblPriceMngCnt.TabIndex = 96;
            this.lblPriceMngCnt.Text = "価格管理件数";
            // 
            // lblPriceChgProc
            // 
            appearance43.TextVAlignAsString = "Middle";
            this.lblPriceChgProc.Appearance = appearance43;
            this.lblPriceChgProc.Location = new System.Drawing.Point(33, 245);
            this.lblPriceChgProc.Name = "lblPriceChgProc";
            this.lblPriceChgProc.Size = new System.Drawing.Size(135, 23);
            this.lblPriceChgProc.TabIndex = 101;
            this.lblPriceChgProc.Text = "価格改正処理区分";
            this.lblPriceChgProc.Visible = false;
            // 
            // lblPrice
            // 
            appearance25.TextVAlignAsString = "Middle";
            this.lblPrice.Appearance = appearance25;
            this.lblPrice.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblPrice.Location = new System.Drawing.Point(33, 155);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(135, 24);
            this.lblPrice.TabIndex = 116;
            this.lblPrice.Text = "価格更新区分";
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(7, 142);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(530, 3);
            this.ultraLabel17.TabIndex = 120;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // tHtmlGenerate1
            // 
            this.tHtmlGenerate1.Align = Broadleaf.Library.Windows.Forms.align.center;
            this.tHtmlGenerate1.coltype = true;
            this.tHtmlGenerate1.Guusuucolor = System.Drawing.Color.PaleTurquoise;
            this.tHtmlGenerate1.GuusuuRow = true;
            this.tHtmlGenerate1.HaikeiColor = System.Drawing.Color.AliceBlue;
            this.tHtmlGenerate1.HightBR = 1;
            this.tHtmlGenerate1.koteicolcolor = System.Drawing.Color.RoyalBlue;
            this.tHtmlGenerate1.koteifontcolor = System.Drawing.Color.White;
            this.tHtmlGenerate1.RowBackColor = System.Drawing.Color.Transparent;
            this.tHtmlGenerate1.RowFontColor = System.Drawing.Color.Black;
            this.tHtmlGenerate1.RowFontSize = 7;
            this.tHtmlGenerate1.SelectedBackColor = System.Drawing.Color.White;
            this.tHtmlGenerate1.TitleColor = System.Drawing.Color.Navy;
            this.tHtmlGenerate1.TitleFontColor = System.Drawing.Color.White;
            this.tHtmlGenerate1.TitleFontSize = 7;
            // 
            // cmbPartsLayer
            // 
            this.cmbPartsLayer.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem15.DataValue = 0;
            valueListItem15.DisplayText = "する（提供未設定分は更新無）";
            valueListItem16.DataValue = 1;
            valueListItem16.DisplayText = "しない";
            valueListItem17.DataValue = 2;
            valueListItem17.DisplayText = "する（無条件更新）";
            this.cmbPartsLayer.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem15,
            valueListItem16,
            valueListItem17});
            this.cmbPartsLayer.Location = new System.Drawing.Point(197, 74);
            this.cmbPartsLayer.Name = "cmbPartsLayer";
            this.cmbPartsLayer.Size = new System.Drawing.Size(254, 24);
            this.cmbPartsLayer.TabIndex = 129;
            // 
            // cmbOpenPrice
            // 
            this.cmbOpenPrice.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem13.DataValue = 0;
            valueListItem13.DisplayText = "価格を引継ぐ";
            valueListItem14.DataValue = 1;
            valueListItem14.DisplayText = "0で更新する";
            this.cmbOpenPrice.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem13,
            valueListItem14});
            this.cmbOpenPrice.Location = new System.Drawing.Point(197, 185);
            this.cmbOpenPrice.Name = "cmbOpenPrice";
            this.cmbOpenPrice.Size = new System.Drawing.Size(177, 24);
            this.cmbOpenPrice.TabIndex = 132;
            // 
            // cmbPriceMngCnt
            // 
            this.cmbPriceMngCnt.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem10.DataValue = 3;
            valueListItem10.DisplayText = "3";
            valueListItem11.DataValue = 4;
            valueListItem11.DisplayText = "4";
            valueListItem12.DataValue = 5;
            valueListItem12.DisplayText = "5";
            this.cmbPriceMngCnt.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem10,
            valueListItem11,
            valueListItem12});
            this.cmbPriceMngCnt.Location = new System.Drawing.Point(197, 215);
            this.cmbPriceMngCnt.Name = "cmbPriceMngCnt";
            this.cmbPriceMngCnt.Size = new System.Drawing.Size(177, 24);
            this.cmbPriceMngCnt.TabIndex = 133;
            // 
            // cmbPriceChgProc
            // 
            this.cmbPriceChgProc.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem8.DataValue = 0;
            valueListItem8.DisplayText = "シンクと同期";
            valueListItem9.DataValue = 1;
            valueListItem9.DisplayText = "手動処理";
            this.cmbPriceChgProc.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem8,
            valueListItem9});
            this.cmbPriceChgProc.Location = new System.Drawing.Point(197, 245);
            this.cmbPriceChgProc.Name = "cmbPriceChgProc";
            this.cmbPriceChgProc.Size = new System.Drawing.Size(177, 24);
            this.cmbPriceChgProc.TabIndex = 134;
            this.cmbPriceChgProc.Visible = false;
            // 
            // cmbName
            // 
            this.cmbName.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem6.DataValue = 0;
            valueListItem6.DisplayText = "する";
            valueListItem7.DataValue = 1;
            valueListItem7.DisplayText = "しない";
            this.cmbName.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem6,
            valueListItem7});
            this.cmbName.Location = new System.Drawing.Point(197, 44);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(177, 24);
            this.cmbName.TabIndex = 128;
            // 
            // cmbPrice
            // 
            this.cmbPrice.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem4.DataValue = 0;
            valueListItem4.DisplayText = "する";
            valueListItem5.DataValue = 1;
            valueListItem5.DisplayText = "しない";
            this.cmbPrice.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5});
            this.cmbPrice.Location = new System.Drawing.Point(197, 155);
            this.cmbPrice.Name = "cmbPrice";
            this.cmbPrice.Size = new System.Drawing.Size(177, 24);
            this.cmbPrice.TabIndex = 131;
            // 
            // cmbBLGoodsCdUpd
            // 
            this.cmbBLGoodsCdUpd.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "する（提供未設定分は更新無）";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "しない";
            valueListItem3.DataValue = 2;
            valueListItem3.DisplayText = "する（無条件更新）";
            this.cmbBLGoodsCdUpd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.cmbBLGoodsCdUpd.Location = new System.Drawing.Point(197, 104);
            this.cmbBLGoodsCdUpd.Name = "cmbBLGoodsCdUpd";
            this.cmbBLGoodsCdUpd.Size = new System.Drawing.Size(254, 24);
            this.cmbBLGoodsCdUpd.TabIndex = 130;
            // 
            // lblBLGoodsCdUpd
            // 
            appearance39.TextVAlignAsString = "Middle";
            this.lblBLGoodsCdUpd.Appearance = appearance39;
            this.lblBLGoodsCdUpd.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblBLGoodsCdUpd.Location = new System.Drawing.Point(33, 104);
            this.lblBLGoodsCdUpd.Name = "lblBLGoodsCdUpd";
            this.lblBLGoodsCdUpd.Size = new System.Drawing.Size(135, 24);
            this.lblBLGoodsCdUpd.TabIndex = 131;
            this.lblBLGoodsCdUpd.Text = "BLｺｰﾄﾞ更新区分";
            // 
            // PMKHN09221UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(542, 353);
            this.Controls.Add(this.lblBLGoodsCdUpd);
            this.Controls.Add(this.cmbBLGoodsCdUpd);
            this.Controls.Add(this.cmbPrice);
            this.Controls.Add(this.cmbName);
            this.Controls.Add(this.cmbPriceChgProc);
            this.Controls.Add(this.cmbPriceMngCnt);
            this.Controls.Add(this.cmbOpenPrice);
            this.Controls.Add(this.cmbPartsLayer);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblPriceMngCnt);
            this.Controls.Add(this.lblOpenPrice);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.lblPartsLayer);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.lblPriceChgProc);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09221UA";
            this.Text = "提供データ更新設定";
            this.Load += new System.EventHandler(this.PMKHN09221UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09221UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN09221UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPartsLayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOpenPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPriceMngCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPriceChgProc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBLGoodsCdUpd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
		# endregion
				
		#region Private Members
        private PriceChgSetAcs _PriceChgSetAcs;
        private PriceChgSet _prevPriceChgSet;
		private bool _nextData;
		private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _priceChgSetTable;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;

		private int _indexBuf;

        // HTML情報
        private const string HTML_HEADER_TITLE = "設定項目";
        private const string HTML_HEADER_VALUE = "設定値";
        private const string HTML_UNREGISTER = "未設定";
        
        // エラー出力情報
        private const string CT_PGID = "PMKHN09221U";
        private const string CT_PGNM = "価格改正設定";

		// FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
		private const string DELETE_DATE = "削除日";
		//private const string CODE_TITLE = "税率コード";
                
        private const string GUID_TITLE = "GUID";

        private const string PRICECHGSET_TABLE = "PRICECHGSET";

		//比較用clone
        private PriceChgSet _priceChgSetClone;

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";

		// 2005.06.21 未設定時、「未設定」ではなく空白で表示する。 >>>> START
		//private const string UNREGISTER = "未設定";
		private const string UNREGISTER = "";
		// 2005.06.21 未設定時、「未設定」ではなく空白で表示する。 >>>> END

		string pgId = "PMKHN09221U";
        string pgNm = "価格改正設定";
        string obj = "PriceChgSetAcs";
		
		#endregion
    
		# region Main
        //private static string[] _parameter;
        //private static System.Windows.Forms.Form _form = null;
		/// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
		[STAThread]
        static void Main(String[] args) 
		{
            //try
            //{
            //    string msg = "";
            //    _parameter = args;
            //    //アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
            //    int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
            //    if (status == 0)
            //    {
            //        _form = new PMKHN09221UA();
            //        System.Windows.Forms.Application.Run(_form);
            //    }
            //    if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", msg, 0, MessageBoxButtons.OK);
            //}
            //catch (Exception ex)
            //{
            //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
            //}
            //finally
            //{
            //    ApplicationStartControl.EndApplication();
            //}
			System.Windows.Forms.Application.Run(new PMKHN09221UA());
		}
		# endregion

		# region Properties
		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get{ return this._canPrint; }
		}

		/// <summary>論理削除データ抽出可能設定プロパティ</summary>
		/// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get{ return this._canLogicalDeleteDataExtraction; }
		}

		/// <summary>画面終了設定プロパティ</summary>
		/// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
		/// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
		public bool CanClose
		{
			get{ return this._canClose; }
			set{ this._canClose = value; }
		}

		/// <summary>新規登録可能設定プロパティ</summary>
		/// <value>新規登録が可能かどうかの設定を取得します。</value>
		public bool CanNew
		{
			get{ return this._canNew; }
		}

		/// <summary>削除可能設定プロパティ</summary>
		/// <value>削除が可能かどうかの設定を取得します。</value>
		public bool CanDelete
		{
			get{ return this._canDelete; }
		}

		/// <summary>件数指定読込設定プロパティ</summary>
		/// <value>件数指定読込が可能かどうかの設定を取得します。</value>
		public bool CanSpecificationSearch
		{
			get{ return this._canSpecificationSearch; }
		}

		/// <summary>データセットの選択データインデックスプロパティ</summary>
		/// <value>データセットの選択データインデックスを取得または設定します。</value>
		public int DataIndex
		{
			get{ return this._dataIndex; }
			set{ this._dataIndex = value; }
		}

		/// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
		/// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
		public bool DefaultAutoFillToColumn
		{
			get{ return this._defaultAutoFillToColumn; }
		}
		# endregion

		# region Public Methods
		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッドリッド用データセット</param>
		/// <param name="tableName">テーブル名称</param>
		/// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = PRICECHGSET_TABLE;
		}

		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList priceChgSets = null;

			if (readCount == 0)
			{
				// 抽出対象件数が0の場合は全件抽出を実行する
				status = this._PriceChgSetAcs.SearchAll(
							out priceChgSets,
							this._enterpriseCode);

				this._totalCount = priceChgSets.Count;
			}
			else
			{
				status = this._PriceChgSetAcs.SearchSpecificationAll(
							out priceChgSets,
							out this._totalCount,
							out this._nextData,
							this._enterpriseCode,
							readCount,
							this._prevPriceChgSet);
			}

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( priceChgSets.Count > 0 ) {
						// 最終の価格改正設定オブジェクトを退避する
						this._prevPriceChgSet = ((PriceChgSet)priceChgSets[priceChgSets.Count - 1]).Clone();
					}

					int index = 0;
					foreach(PriceChgSet priceChgSet in priceChgSets)
					{
						if (this._priceChgSetTable.ContainsKey(priceChgSet.FileHeaderGuid) == false)
						{
							PriceChgSetToDataSet(priceChgSet.Clone(), index);
							++index;
						}
					}

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_STOP,
						pgId,
						pgNm,
						"Search",
						TMsgDisp.OPE_READ,
						"読込みに失敗しました。",
						status,
						obj,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);

					break;
				}
			}

			totalCount = this._totalCount;

			return status;
		}

		/// <summary>
		/// ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			int dummy = 0;
			ArrayList priceChgSets = null;

			// 抽出対象件数が0の場合は、残りの全件を抽出
			if (readCount == 0)
			{
				readCount =	this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			}

			int status = this._PriceChgSetAcs.SearchSpecificationAll(
							out priceChgSets,
							out dummy,
							out this._nextData, 
							this._enterpriseCode,
							readCount,
							this._prevPriceChgSet);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( priceChgSets.Count > 0 ) {
						// 最終の価格改正設定クラスを退避する
						this._prevPriceChgSet = ((PriceChgSet)priceChgSets[priceChgSets.Count - 1]).Clone();
					}

					int index = 0;
					foreach(PriceChgSet priceChgSet in priceChgSets)
					{
						if (this._priceChgSetTable.ContainsKey(priceChgSet.FileHeaderGuid) == false)
						{
							index = this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows.Count;
							PriceChgSetToDataSet(priceChgSet.Clone(), index);
						}
					}

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_STOP,
						pgId,
						pgNm,
						"SearchNext",
						TMsgDisp.OPE_READ,
						"読込みに失敗しました。",
						status,
						obj,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);

					break;
				}
			}

			return status;
		}

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを削除します。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public int Delete()
		{
			Guid guid = (Guid)this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[this._dataIndex][GUID_TITLE];
			PriceChgSet priceChgSet = (PriceChgSet)this._priceChgSetTable[guid];

			int status = this._PriceChgSetAcs.LogicalDelete(ref priceChgSet);
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //2005.07.06 排他制御対応　三橋>>>>>START
				if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
				{
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						pgId,
						"既に他端末より削除されています",
						status,
						MessageBoxButtons.OK);

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return status;
				}	
				else
				{
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_STOP,
						pgId,
						pgNm,
						"Delete",
						TMsgDisp.OPE_DELETE,
						"削除に失敗しました。",
						status,
						obj,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return status;
				}
			}

			status = this._PriceChgSetAcs.Read(out priceChgSet, priceChgSet.EnterpriseCode);

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				TMsgDisp.Show(this,
					emErrorLevel.ERR_LEVEL_STOP,
					pgId,
					pgNm,
					"Delete",
					TMsgDisp.OPE_READ,
					"読込みに失敗しました。",
					status,
					obj,
					MessageBoxButtons.OK,
					MessageBoxDefaultButton.Button1);
				return status;
			}

			PriceChgSetToDataSet(priceChgSet.Clone(), this._dataIndex);

			return status;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.05.06</br>
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
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			appearanceTable.Add(DELETE_DATE,		new GridColAppearance(MGridColDispType.DeletionDataBoth,ContentAlignment.MiddleLeft,"",Color.Red));
			//appearanceTable.Add(CODE_TITLE,			new GridColAppearance(MGridColDispType.None,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(lblName.Text,   	new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(lblPartsLayer.Text,	new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
            // 2009/12/11 Add >>>
            appearanceTable.Add(lblBLGoodsCdUpd.Text, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2009/12/11 Add <<<
			appearanceTable.Add(lblPrice.Text,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(lblOpenPrice.Text,	new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(lblPriceMngCnt.Text,new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));

            // DEL 2009/01/22 不具合対応[9898] ↓
            //appearanceTable.Add(lblPriceChgProc.Text,new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleRight,"",Color.Black));	// 2005.06.09 TOUMA ADD フレームに表示する内容の表示位置を右詰めに変更

			appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None,			ContentAlignment.MiddleLeft,"",Color.Black));

			return appearanceTable;
		}
		# endregion

		# region Private Methods
		/// <summary>
		/// 価格改正設定オブジェクトデータセット展開処理
		/// </summary>
        /// <param name="priceChgSet">価格改正設定オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note       : 価格改正設定クラスをデータセットに格納します。</br>
		/// <br>Programmer : 21041　中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
        private void PriceChgSetToDataSet(PriceChgSet priceChgSet, int index)
		{

			if ((index < 0) || (this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[PRICECHGSET_TABLE].NewRow();
				this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows.Add(dataRow);

				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows.Count - 1;
			}

			// 論理削除日付
			if (priceChgSet.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][DELETE_DATE] = string.Empty;
			}
			else
			{
				this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][DELETE_DATE] = priceChgSet.UpdateDateTimeJpInFormal;
			}

			// 名称更新区分
			this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][lblName.Text] = priceChgSet.NameUpdDiv;

			// 層別更新区分
            this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][lblPartsLayer.Text] = priceChgSet.PartsLayerUpdDiv;

            // 2009/12/11 Add >>>
            // BLコード更新区分
            this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][lblBLGoodsCdUpd.Text] = priceChgSet.BLGoodsCdUpdDiv;
            // 2009/12/11 Add <<<

			// 価格更新区分
            this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][lblPrice.Text] = priceChgSet.PriceUpdDiv;
            
            // オープン価格区分
            this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][lblOpenPrice.Text] = priceChgSet.OpenPriceDiv;

            // 価格管理件数
            this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][lblPriceMngCnt.Text] = priceChgSet.PriceMngCnt;

            // 価格改正処理区分
            // DEL 2009/01/22 不具合対応[9898] ↓
            //this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][lblPriceChgProc.Text] = priceChgSet.PriceChgProcDiv;

			this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[index][GUID_TITLE] = priceChgSet.FileHeaderGuid;

			if (this._priceChgSetTable.ContainsKey(priceChgSet.FileHeaderGuid) == true)
			{
				this._priceChgSetTable.Remove(priceChgSet.FileHeaderGuid);
			}
			this._priceChgSetTable.Add(priceChgSet.FileHeaderGuid, priceChgSet);
		}

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
		/// <br>Programmer : 21041　中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable priceChgSetTable = new DataTable(PRICECHGSET_TABLE);

			// Addを行う順番が、列の表示順位となります。
			priceChgSetTable.Columns.Add(DELETE_DATE, typeof(string));
            priceChgSetTable.Columns.Add(lblName.Text, typeof(int));
            priceChgSetTable.Columns.Add(lblPartsLayer.Text, typeof(int));
            // 2009/12/11 Add >>>
            priceChgSetTable.Columns.Add(lblBLGoodsCdUpd.Text, typeof(int));
            // 2009/12/11 Add <<<
            priceChgSetTable.Columns.Add(lblPrice.Text, typeof(int));
            priceChgSetTable.Columns.Add(lblOpenPrice.Text, typeof(int));
            priceChgSetTable.Columns.Add(lblPriceMngCnt.Text, typeof(int));

            // DEL 2009/01/22 不具合対応[9898] ↓
            //priceChgSetTable.Columns.Add(lblPriceChgProc.Text, typeof(int));            
			
            priceChgSetTable.Columns.Add(GUID_TITLE, typeof(Guid));

			this.Bind_DataSet.Tables.Add(priceChgSetTable);
		}

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 21041　中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
            
        }

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
		/// <br>Programmer : 21041　中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private void ScreenClear()
		{
			
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 21041　中村　健</br>
		/// <br>Date       : 2005.05.06</br>
        /// <br>Update Note: 2008.06.03 30413 犬飼</br>
        /// <br>             ・インターフェースをシングルタイプに変更した為</br>
        /// <br>               画面再構築処理をシングルタイプ処理に置き換え</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
            const string ctPROCNM = "ScreenReconstruction";
            int status = 0;

            this._prevPriceChgSet = new PriceChgSet();

            // 価格改正設定データ取得
            status = this._PriceChgSetAcs.Read(out this._prevPriceChgSet, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (this._prevPriceChgSet == null)
                {
                    this._prevPriceChgSet = new PriceChgSet();
                }

                this.Mode_Label.Text = UPDATE_MODE;

                // 価格改正設定画面展開処理
                this.PriceChgSetToDataSet(this._prevPriceChgSet);
                // 比較用クローン作成
                this._priceChgSetClone = this._prevPriceChgSet.Clone();
                // 画面情報を比較用クローンにコピー
                this.DispToPriceChgSet(ref this._priceChgSetClone);

                // 画面入力許可制御
                ScreenInputPermissionControl(true);

                // 初期フォーカスをセット
                this.cmbName.Focus();
            }
            else
            {
                // リード
                TMsgDisp.Show(
                    this,                                 // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
                    CT_PGID,                              // アセンブリＩＤまたはクラスＩＤ
                    CT_PGNM,                              // プログラム名称
                    ctPROCNM,                             // 処理名称
                    TMsgDisp.OPE_READ,                    // オペレーション
                    "読み込みに失敗しました。",           // 表示するメッセージ
                    status,                               // ステータス値
                    this._PriceChgSetAcs,                  // エラーが発生したオブジェクト
                    MessageBoxButtons.OK,                 // 表示するボタン
                    MessageBoxDefaultButton.Button1);    // 初期表示ボタン

                this.Mode_Label.Text = UPDATE_MODE;

                this._prevPriceChgSet = new PriceChgSet();

                // 価格改正設定画面展開処理
                this.PriceChgSetToDataSet(this._prevPriceChgSet);
                // 比較用クローン作成
                this._priceChgSetClone = this._prevPriceChgSet.Clone();
                // 画面情報を比較用クローンにコピー
                this.DispToPriceChgSet(ref this._priceChgSetClone);

                // 画面入力許可制御
                ScreenInputPermissionControl(true);

                // 初期フォーカスをセット
                this.cmbName.Focus();
            }
		}

		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <param name="enabled">入力許可設定値</param>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
		/// <br>Programmer : 21041　中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private void ScreenInputPermissionControl(bool enabled)
		{
            this.cmbName.Enabled = enabled;
            this.cmbPartsLayer.Enabled = enabled;
            // 2009/12/11 Add >>>
            this.cmbBLGoodsCdUpd.Enabled = enabled;
            // 2009/12/11 Add <<<
            this.cmbPrice.Enabled = enabled;
            this.cmbOpenPrice.Enabled = enabled;
            this.cmbPriceMngCnt.Enabled = enabled;
            this.cmbPriceChgProc.Enabled = enabled;
		}

		/// <summary>
		/// 価格改正設定クラス画面展開処理
		/// </summary>
        /// <param name="priceChgSet">価格改正設定オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 価格改正設定オブジェクトから画面にデータを展開します。</br>
		/// <br>Programmer : 21041　中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
        private void PriceChgSetToDataSet(PriceChgSet priceChgSet)
		{
            this.cmbName.Value = priceChgSet.NameUpdDiv;
            this.cmbPartsLayer.Value = priceChgSet.PartsLayerUpdDiv;
            // 2009/12/11 Add >>>
            this.cmbBLGoodsCdUpd.Value = priceChgSet.BLGoodsCdUpdDiv;
            // 2009/12/11 Add <<<
            this.cmbPrice.Value = priceChgSet.PriceUpdDiv;
            this.cmbOpenPrice.Value = priceChgSet.OpenPriceDiv;
            this.cmbPriceMngCnt.Value = priceChgSet.PriceMngCnt;
            this.cmbPriceChgProc.Value = priceChgSet.PriceChgProcDiv;
		}

		/// <summary>
		/// 画面情報価格改正設定クラス格納処理
		/// </summary>
        /// <param name="priceChgSet">価格改正設定オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 画面情報から価格改正設定オブジェクトにデータを格納します。</br>
		/// <br>Programmer : 21041　中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
        private void DispToPriceChgSet(ref PriceChgSet priceChgSet)
		{
			if (priceChgSet == null)
			{
				// 新規の場合
				priceChgSet = new PriceChgSet();
			}

			priceChgSet.EnterpriseCode		= this._enterpriseCode;
            priceChgSet.NameUpdDiv = (int)this.cmbName.Value;
            priceChgSet.PartsLayerUpdDiv = (int)cmbPartsLayer.Value;
            // 2009/12/11 Add >>>
            priceChgSet.BLGoodsCdUpdDiv = (int)cmbBLGoodsCdUpd.Value;
            // 2009/12/11 Add <<<
            priceChgSet.PriceUpdDiv = (int)cmbPrice.Value;
            priceChgSet.OpenPriceDiv = (int)cmbOpenPrice.Value;
            priceChgSet.PriceMngCnt = (int)cmbPriceMngCnt.Value;
            priceChgSet.PriceChgProcDiv = (int)cmbPriceChgProc.Value;
		}

		/// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
		/// <br>Programmer : 21041　中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private bool ScreenDataCheck(ref Control control, ref string message)
		{			
			
			return true;
		}

		/// <summary>
		/// 入力日付の有効性チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 年月日が空白だとチェックが走らないため、UI側でも有効性チェックを行います。</br>
		/// <br>Programmer : 21041 中村　健</br>
		/// <br>Date       : 2005.05.07</br>
		/// </remarks>
		private bool CheckDateEffect( Control control )
		{
			//何らかの入力があるが、年・月・日のいづれかに入力がなければ、警告。
			if (((TDateEdit)control).LongDate != 0)
			{
				int lYear = Convert.ToInt32((((TDateEdit)control).LongDate) / 10000);
				int lMonth =  Convert.ToInt32(((((TDateEdit)control).LongDate) % 10000) / 100);
				int lDay = (((TDateEdit)control).LongDate) % 100;
      
				if ((lDay == 0) || (lMonth == 0) || (lYear == 0))
				{
       　          return false;
				}
			}
			return true;    
		}

		/// <summary>
		/// 価格改正設定保存処理
		/// </summary>
		/// <returns>登録結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 価格改正設定登録を行います。</br>
		/// <br>Programmer : 21041　中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private bool SavePriceChgProcSet()
		{
			Control control = null;
			string message = null;

			if (!ScreenDataCheck(ref control, ref message))
			{
				TMsgDisp.Show(this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					pgId,
					message,
					0,
					MessageBoxButtons.OK);

				control.Focus();
				return false;
			}

			PriceChgSet priceChgSet = null;
            // 2008.06.03 30413 犬飼 シングルタイプに変更 >>>>>>START
            // マルチタイプ時のリスト選択インデックスでは更新処理が行えない為、
            // 比較用クローンから画面情報以外を設定する
            //if (this.DataIndex >= 0)
			//{
				//Guid guid = (Guid)this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[this._dataIndex][GUID_TITLE];
				//taxrateset = ((PriceChgSet)this._taxratesetTable[guid]).Clone();
			//}
            priceChgSet = this._priceChgSetClone.Clone();
            // 2008.06.03 30413 犬飼 シングルタイプに変更 <<<<<<End
			
			DispToPriceChgSet(ref priceChgSet);
            
			int status = this._PriceChgSetAcs.Write(ref priceChgSet);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						pgId,
						"この価格改正設定コードは既に使用されています。",
						0,
						MessageBoxButtons.OK);
					return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{

					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						pgId,
						"既に他端末より更新されています",
						status,
						MessageBoxButtons.OK);

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return false;
				}
				default:
				{
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_STOP,
						pgId,
						pgNm,
                        "SavePriceChgProcSet",
						TMsgDisp.OPE_UPDATE,
						"登録に失敗しました。",
						status,
						obj,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return false;
				}

			}

			PriceChgSetToDataSet(priceChgSet, this.DataIndex);

			return true;
		}
		# endregion

		#region Control Events
		/// <summary>
		/// Form.Load イベント(SFSSH09460UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer  : 21041　中村　健</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void PMKHN09221UA_Load(object sender, System.EventArgs e)
		{
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList25 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList25;
			this.Cancel_Button.ImageList = imageList25;
			this.Delete_Button.ImageList = imageList25;
			this.Revive_Button.ImageList = imageList25;

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;

			ScreenInitialSetting();
		}

		/// <summary>
		/// Form.Closing イベント(SFSSH09460UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note　　　  : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
		/// <br>Programmer  : 21041　中村　健</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void PMKHN09221UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{

			this._indexBuf = -2;
			// フォームの「×」をクリックされた場合の対応です。
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
		/// Control.VisibleChanged イベント(SFSSH09460UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
		/// <br>Programmer  : 21041　中村　健</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void PMKHN09221UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				// メインフレームアクティブ化
				this.Owner.Activate();
				return;
			}

			// 自分自身が非表示になった場合、
			// またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}

			// 新規モード以外の場合
			//if(this._dataIndex >= 0)
			//{
			//	// フレームで選択されているレコードのGUIDを取得
			//	Guid guid = (Guid)this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[this._dataIndex][GUID_TITLE];
			//	// 上記のレコードをクラスにセット
			//	PriceChgSet taxRateSet = (PriceChgSet)this._taxratesetTable[guid];
			//	// 現在の画面のキー情報とクラスのキー情報を比較
			//	// 同じだったら以下の処理をキャンセルする
			//	if ( this.TaxRateProperNounNm_tEdit.Text.Trim() == taxRateSet.TaxRateProperNounNm.Trim() )
			//	{
			//		return;
			//	}
			//		// メインフレームの選択が変更された場合
			//	else
			//	{
			//		// 読込みを行う為にフラグを初期化
			//		this._minFlg = false;
			//	}
			//}

			//// フラグがtrueだったら以下の処理をキャンセルする
			//if (this._minFlg == false)
			//{
			//	this._minFlg = true;
			//}
			//else
			//{
			//	return;
			//}
			Initial_Timer.Enabled = true;
			ScreenClear();
		}

		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 21041　中村　健</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
            // 価格改正設定登録処理
			if (SavePriceChgProcSet() == false)
			{
				return;
			}
			
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			// 登録モードの場合は画面を終了せずに連続入力を可能とする
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				this.DataIndex = -1;

				ScreenClear();
				this.cmbName.Focus();
				// クローンを再度取得する
				PriceChgSet newPriceChgSet = new PriceChgSet();
				//クローン作成
				this._priceChgSetClone = newPriceChgSet.Clone(); 
				DispToPriceChgSet( ref this._priceChgSetClone);

			}
			else
			{
				this.DialogResult = DialogResult.OK;

				if (CanClose == true)
				{
					this.Close();
				}
				else
				{
					this.Hide();
				}

				this._indexBuf = -2;
			}
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 21041　中村　健</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
            DialogResult res = DialogResult.Cancel;

			// 削除モード・参照モード以外の場合は保存確認処理を行う
			if (this.Mode_Label.Text != DELETE_MODE)
			{
				//保存確認
				PriceChgSet comparePriceChgSet = new PriceChgSet();
				comparePriceChgSet = this._priceChgSetClone.Clone();  

				//現在の画面情報を取得する
				DispToPriceChgSet( ref comparePriceChgSet);
				//最初に取得した画面情報と比較
				if (!(this._priceChgSetClone.Equals(comparePriceChgSet)))	
				{
                    res = TMsgDisp.Show(this,
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        pgId,
                        "",
                        0,
                        MessageBoxButtons.YesNoCancel);
					switch(res)
					{
						case DialogResult.Yes:
						{
							// 価格改正設定登録処理
							if (SavePriceChgProcSet() ==false)
							{
								return;
							}

							break;
						}
						case DialogResult.No:
						{
							break;
						}
						default:
						{
							this.Cancel_Button.Focus();
							return;
						}
					}
				}
			}
			
			if (UnDisplaying != null)
			{
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(res);
				UnDisplaying(this, me);
			}

            this.DialogResult = res;
            this._indexBuf = -2;
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
		/// Control.Click イベント(Delete_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 21041　中村　健</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			DialogResult result = TMsgDisp.Show(this,
				emErrorLevel.ERR_LEVEL_QUESTION,
				pgId,
				"データを削除します。" + "\r\n" + "よろしいですか？",
				0,
				MessageBoxButtons.OKCancel,
				MessageBoxDefaultButton.Button2);

			if (result == DialogResult.OK)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[this._dataIndex][GUID_TITLE];
				PriceChgSet priceChgSet = (PriceChgSet)this._priceChgSetTable[guid];

				int status = this._PriceChgSetAcs.Delete(priceChgSet);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[this.DataIndex].Delete();
						this._priceChgSetTable.Remove(priceChgSet.FileHeaderGuid);

						break;
					}
					default:
					{
						TMsgDisp.Show(this,
							emErrorLevel.ERR_LEVEL_STOP,
							pgId,
							pgNm,
							"Delete_Button_Click",
							TMsgDisp.OPE_DELETE,
							"削除に失敗しました。",
							status,
							obj,
							MessageBoxButtons.OK,
							MessageBoxDefaultButton.Button1);
						return;
					}
				}
			}
			else
			{
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			this._indexBuf = -2;
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
		/// Control.Click イベント(Revive_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 復活ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 21041　中村　健</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			Guid guid = (Guid)this.Bind_DataSet.Tables[PRICECHGSET_TABLE].Rows[this._dataIndex][GUID_TITLE];
			PriceChgSet priceChgSet = (PriceChgSet)_priceChgSetTable[guid];

			int status = this._PriceChgSetAcs.Revival(ref priceChgSet);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						pgId,
						"既にデータが完全削除されています。" ,
						status,
						MessageBoxButtons.OK);

					break;
				}
				default:
				{
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_STOP,
						pgId,
						pgNm,
						"Delete",
						TMsgDisp.OPE_UPDATE,
						"復活に失敗しました。",
						status,
						obj,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);
					break;
				}
			}

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
			}

			PriceChgSetToDataSet(priceChgSet, this.DataIndex);

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			this._indexBuf = -2;

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
		/// Timer.Tick イベント イベント(Initial_Timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
		///					  この処理は、システムが提供するスレッド プール
		///					  スレッドで実行されます。</br>
		/// <br>Programmer  : 21041　中村　健</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}
		# endregion
		

        #region IMasterMaintenanceSingleType メンバ

        /// <summary>
        /// 画面クローズプロパティ
        /// </summary>
        /// <remarks>
        /// 画面クローズを許可するかどうかの設定を取得または設定します。
        /// falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。
        /// </remarks>
        bool IMasterMaintenanceSingleType.CanClose
        {
            get
            {
                return this._canClose;
            }
            set
            {
                this._canClose = value;
            }
        }

        /// <summary>
        /// 印刷プロパティ
        /// </summary>
        /// <remarks>
        /// 印刷可能かどうかの設定を取得します。（false固定）
        /// </remarks>
        bool IMasterMaintenanceSingleType.CanPrint
        {
            get { 
                return this._canPrint;
            }
        }
        
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 未実装</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.03</br>
        /// </remarks>
        int IMasterMaintenanceSingleType.Print()
        {
            // 印刷アセンブリをロードする（未実装）
            return 0;
        }

        /// <summary>
        /// HTMLコード取得処理
        /// </summary>
        /// <returns>HTMLコード</returns>
        /// <remarks>
        /// <br>Note       : HTMLコードの取得を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.03</br>
        /// </remarks>
        String IMasterMaintenanceSingleType.GetHtmlCode()
        {
            const string ctPROCNM = "GetHtmlCode";
            string outCode = "";

            // tHtmlGenerate部品の引数を生成する
            List<string> titleList = new List<string>();
            List<string> valueList = new List<string>();
            titleList.Add(HTML_HEADER_TITLE);							// 「設定項目」
            valueList.Add(HTML_HEADER_VALUE);							// 「設定値」

            // 設定項目タイトル設定
            titleList.Add(lblName.Text);             // 名称更新区分
            titleList.Add(lblPartsLayer.Text);    // 層別更新区分
            // 2009/12/11 Add >>>
            titleList.Add(lblBLGoodsCdUpd.Text);    // BLコード更新区分
            // 2009/12/11 Add <<<
            titleList.Add(lblPrice.Text);    // 価格更新区分
            titleList.Add(lblOpenPrice.Text);     // オープン価格区分
            titleList.Add(lblPriceMngCnt.Text);      // 価格管理件数

            // DEL 2009/01/22 不具合対応[9898] ↓
            //titleList.Add(lblPriceChgProc.Text);       // 価格改正処理区分

            string[] kubun = new string[] { "する","しない"};
            //string[] kubun2 = new string[] { "価格を引継く", "0で更新" };  // DEL by gezh 2011/11/29 redmine#8191
            //string[] kubun2 = new string[] { "価格を引継ぐ", "0で更新" };    // ADD by gezh 2011/11/29 redmine#8191  //DEL BY 凌小青 on 2011/12/05 for redmine#8191
            string[] kubun2 = new string[] { "価格を引継ぐ", "0で更新する" };  //ADD BY 凌小青 2011/12/05 redmine#8191
            string[] kubun3 = new string[] { "シンクと同期", "手動処理" };
            string[] kubun4 = new string[] { "する（提供未設定分は更新無）", "しない", "する（無条件更新）" }; // ADD 2012/06/26 高峰 層別更新不具合対応
            // 価格改正設定データ取得
            int status = 0;
            status = this._PriceChgSetAcs.Read(out this._prevPriceChgSet, this._enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {

                        // 価格改正設定取得データ設定
                        if (this._prevPriceChgSet != null)
                        {
                            valueList.Add(kubun[this._prevPriceChgSet.NameUpdDiv]);
                            //valueList.Add(kubun[this._prevPriceChgSet.PartsLayerUpdDiv]); // DEL 2012/06/26 高峰 層別更新不具合対応
                            valueList.Add(kubun4[this._prevPriceChgSet.PartsLayerUpdDiv]); // ADD 2012/06/26 高峰 層別更新不具合対応
                            // 2009/12/11 Add >>>
                            //valueList.Add(kubun[this._prevPriceChgSet.BLGoodsCdUpdDiv]); // DEL 2013/01/31 T.Miyamoto
                            valueList.Add(kubun4[this._prevPriceChgSet.BLGoodsCdUpdDiv]);  // ADD 2013/01/31 T.Miyamoto
                            // 2009/12/11 Add <<<
                            valueList.Add(kubun[this._prevPriceChgSet.PriceUpdDiv]);
                            valueList.Add(kubun2[this._prevPriceChgSet.OpenPriceDiv]);
                            valueList.Add(this._prevPriceChgSet.PriceMngCnt.ToString());
                            valueList.Add(kubun3[this._prevPriceChgSet.PriceChgProcDiv]);
                        }
                        else
                        {
                            // 未設定
                            for (int ix = 0; ix < titleList.Count; ix++)
                            {
                                valueList.Add(HTML_UNREGISTER);
                            }
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        // 未設定
                        for (int ix = 0; ix < titleList.Count; ix++)
                        {
                            valueList.Add(HTML_UNREGISTER);
                        }
                        break;
                    }
                default:
                    {
                        // リード
                        TMsgDisp.Show(
                            this,                                 // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
                            CT_PGID,                              // アセンブリＩＤまたはクラスＩＤ
                            CT_PGNM,                              // プログラム名称
                            ctPROCNM,                             // 処理名称
                            TMsgDisp.OPE_READ,                    // オペレーション
                            "読み込みに失敗しました。",           // 表示するメッセージ
                            status,                               // ステータス値
                            this._PriceChgSetAcs,                  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,                 // 表示するボタン
                            MessageBoxDefaultButton.Button1);    // 初期表示ボタン

                        // 未設定
                        for (int ix = 0; ix < titleList.Count; ix++)
                        {
                            valueList.Add(HTML_UNREGISTER);
                        }
                        break;
                    }
            }

            this.tHtmlGenerate1.Coltypes = new int[2];
            this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
            this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;

            // 配列にコピー
            string[,] array = new string[titleList.Count, 2];
            for (int ix = 0; ix < array.GetLength(0); ix++)
            {
                array[ix, 0] = titleList[ix];
                array[ix, 1] = valueList[ix];
            }

            this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array, ref outCode);

            return outCode;
        }        
        #endregion
    }
}