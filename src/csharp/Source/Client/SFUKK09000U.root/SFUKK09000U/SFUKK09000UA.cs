//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 税率設定
// プログラム概要   : 税率設定マスタの修正を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2008/06/03  修正内容 : Partsman対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 修 正 日  2008/11/06  修正内容 : 項目名称変更　「税率固有名称」→「消費税種類」
//                                :               「表示／印刷名称」→「表示／印刷名」
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/19  修正内容 : MANTIS【13568】項目名称変更　「表示／印刷名」→「表示名」
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 鄭慕鈞
// 修 正 日  2014/02/18  修正内容 : Redmine#42120 税率設定マスタにチェックを追加する
//----------------------------------------------------------------------------//

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
	/// 税率入力フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 税率設定を行います。
	///					 IMasterMaintenanceMultiTypeを実装しています。</br>
	/// <br>Programmer : 21041　中村　健</br>
	/// <br>Date       : 2004.04.01</br>
	/// <br></br>
	/// <br>Update Note: 2005.05.27 22025 當間 豊</br>
	/// <br>					・フレームの最小化対応</br>
	/// <br>Update Note: 2005.06.09 22025 當間 豊</br>
	/// <br>					・フレームに表示する内容の表示位置を右詰めに変更</br>
	/// <br>Update Note: 2005.06.10 96138 佐藤 健治</br>
	/// <br>					・タイトルを「税率設定」と変更。（プロパティにて変更。）</br>
	/// <br>Update Note: 2005.06.13 96138 佐藤 健治</br>
	/// <br>					・UI画面数値項目の右詰め対応。（プロパティにて変更。）</br>
	/// <br>Update Note: 2005.06.18 96138 佐藤  健治</br>
	/// <br>           : ・使用不可項目の文字色、背景色の設定を変更。プロパティにて変更。</br>
	/// <br>           : ・FontColorDisabled = Black、BackColorDisabled = Control</br>
	/// <br>Update Note: 2005.06.20 96138 佐藤  健治</br>
	/// <br>           : ・税率項目表示の最適化。</br>
	/// <br>Update Note: 2005.06.21 96138 佐藤  健治</br>
	/// <br>           : ・未設定時、「未設定」ではなく空白で表示する。</br>
	/// <br>Update Note: 2005.06.21 96138 佐藤  健治</br>
	/// <br>           : ①IMEモード Off→Disableへ変更。プロパティにて変更。</br>	
	/// <br>Update Note: 2005.06.23 96138 佐藤  健治</br>
	/// <br>           : ・コンボボックスのMaxDropDownItemsを18に変更。プロパティにて変更。</br>	
	/// <br>Update Note: 2005.06.24 96138 佐藤  健治</br>
	/// <br>           : ・TNeditデフォルト設定の最適化。プロパティにて変更。</br>	
	/// <br>Update Note: 2005.06.30 21020 黒木  慎介</br>
	/// <br>           : ・TDateEditのImeModeプロパティをDisableに変更</br>	
	/// <br>Update Note: 2005.07.02 22035 三橋　弘憲</br>
	/// <br>           : ・フレームの最小化対応改良</br>
	/// <br>Update Note: 2005.07.06 22035 三橋　弘憲</br>
	/// <br>           : 排他制御対応</br>
	/// <br>Update Note: 2005.07.12 22035 三橋　弘憲</br>
	/// <br>           : 排他制御コメント変更</br>
	/// <br>Update Note: 2005.09.09 23003 enokida</br>
	/// <br>           : ログイン情報取得対応</br>
	/// <br>Update Note: 2005.09.20 23003 enokida</br>
	/// <br>           : Message部品対応</br>
	/// <br>Update Note: 2005.10.19 22021 谷藤　範幸</br>
	/// <br>		   : ・UI子画面Hide時のOwner.Activate処理追加</br>
	/// <br></br>
	/// <br>Update Note	: 2007.02.06 18322 T.Kimura MA.NS用に変更</br>
	/// <br>			:                           ・画面スキン変更対応</br>
	/// <br></br>
	/// <br>Update Note	: 2007.08.01 18322 T.Kimura MK.NS用に和暦から西暦に日付を変更</br>
    /// <br>Update Note: 2007.08.16 980035 金沢 貞義</br>
    /// <br>			 ・端数処理区分を削除して消費税転嫁方式を追加</br>
    /// <br>Update Note: 2008.03.06 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応（日付の重複チェック追加）</br>
    /// <br>Update Note: 2008.06.03 30413 犬飼</br>
    /// <br>             ・PM.NS対応 (インターフェースをシングルタイプに変更)</br>
    /// <br>Update Note: 2008.11.06 30452 上野 俊治</br>
    /// <br>             ・項目名称変更</br>
    /// <br>             「税率固有名称」→「消費税種類」</br>
    /// <br>             「表示／印刷名称」→「表示／印刷名」</br>
    /// <br>Update Note: 2014/02/18 鄭慕鈞</br>
    /// <br>           : Redmine#42120 税率設定マスタにチェックを追加する</br>
    /// </remarks>
	public class SFUKK09000UA : System.Windows.Forms.Form, IMasterMaintenanceSingleType
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
		private Infragistics.Win.Misc.UltraLabel Name_Title_Label;
		private Infragistics.Win.Misc.UltraLabel AgencyCodeCode_Title_Label;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Broadleaf.Library.Windows.Forms.TLine tLine3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Broadleaf.Library.Windows.Forms.TLine tLine4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Broadleaf.Library.Windows.Forms.TEdit TaxRateName_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TaxRateProperNounNm_tEdit;
		private Broadleaf.Library.Windows.Forms.TNedit TaxRate_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit TaxRate2_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit TaxRate3_tNedit;
		private Broadleaf.Library.Windows.Forms.TComboEditor ConsTaxLayMethod_tComboEditor;
		private Infragistics.Win.Misc.UltraLabel ConsTaxLayMethod_Label;
		private Infragistics.Win.Misc.UltraLabel TaxRateDate1_Label;
		private Infragistics.Win.Misc.UltraLabel TaxRate1_Label;
		private Infragistics.Win.Misc.UltraLabel TaxRate2_Label;
		private Infragistics.Win.Misc.UltraLabel TaxRateDate2_Label;
		private Infragistics.Win.Misc.UltraLabel TaxRateDate3_Label;
		private Infragistics.Win.Misc.UltraLabel TaxRate3_Label;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 TaxRateEndDate3_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 TaxRateStartDate3_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 TaxRateEndDate2_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 TaxRateStartDate2_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 TaxRateEndDate_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 TaxRateStartDate_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private THtmlGenerate tHtmlGenerate1;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// 税率情報入力フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 税率情報入力フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 21041　中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public SFUKK09000UA()
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

			// 2005.09.09 enokida ADD ログイン情報取得対応 >>>>>>>>>>>>>>>>> START
			//　企業コードを取得する
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// 2005.09.09 enokida ADD ログイン情報取得対応 <<<<<<<<<<<<<<<<< END


			// 変数初期化
			this._dataIndex = -1;
			this._taxratesetAcs = new TaxRateSetAcs();
			this._prevTaxRateSet = null;
			this._nextData = false;
			this._totalCount = 0;
			this._taxratesetTable = new Hashtable();
            
			//2005.07.02 フレームの最小化対応改良　三橋>>>>>START
			this._indexBuf = -2;
			//// 2005.05.27 TOUMA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//// 最小化判定用フラグ
			//this._minFlg = false;
			//// 2005.05.27 TOUMA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			//2005.07.02 フレームの最小化対応改良  三橋<<<<<<END
		
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
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK09000UA));
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.TaxRateName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Name_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AgencyCodeCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.TaxRateDate1_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TaxRateProperNounNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TaxRate1_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TaxRate_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tLine3 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.TaxRate2_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TaxRate2_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TaxRateDate2_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tLine4 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.TaxRateDate3_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TaxRate3_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TaxRate3_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ConsTaxLayMethod_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ConsTaxLayMethod_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.TaxRateEndDate3_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.TaxRateStartDate3_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.TaxRateEndDate2_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.TaxRateStartDate2_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.TaxRateEndDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.TaxRateStartDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.tHtmlGenerate1 = new Broadleaf.Library.Windows.Forms.THtmlGenerate(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRateName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRateProperNounNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRate_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRate2_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRate3_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxLayMethod_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 478);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(677, 23);
            this.ultraStatusBar1.TabIndex = 46;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
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
            this.Mode_Label.Location = new System.Drawing.Point(545, 5);
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
            this.Ok_Button.Location = new System.Drawing.Point(415, 425);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 14;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(540, 425);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 15;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // TaxRateName_tEdit
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TaxRateName_tEdit.ActiveAppearance = appearance32;
            this.TaxRateName_tEdit.AlwaysInEditMode = true;
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance33.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance33.ForeColorDisabled = System.Drawing.Color.Black;
            this.TaxRateName_tEdit.Appearance = appearance33;
            this.TaxRateName_tEdit.AutoSelect = true;
            this.TaxRateName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.TaxRateName_tEdit.DataText = "一般消費税";
            this.TaxRateName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRateName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TaxRateName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TaxRateName_tEdit.Location = new System.Drawing.Point(145, 95);
            this.TaxRateName_tEdit.MaxLength = 24;
            this.TaxRateName_tEdit.Name = "TaxRateName_tEdit";
            this.TaxRateName_tEdit.Size = new System.Drawing.Size(401, 24);
            this.TaxRateName_tEdit.TabIndex = 1;
            this.TaxRateName_tEdit.Text = "一般消費税";
            // 
            // Name_Title_Label
            // 
            appearance39.TextVAlignAsString = "Middle";
            this.Name_Title_Label.Appearance = appearance39;
            this.Name_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.Name_Title_Label.Location = new System.Drawing.Point(10, 95);
            this.Name_Title_Label.Name = "Name_Title_Label";
            this.Name_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.Name_Title_Label.TabIndex = 92;
            this.Name_Title_Label.Text = "表示名";
            // 
            // AgencyCodeCode_Title_Label
            // 
            appearance40.TextVAlignAsString = "Middle";
            this.AgencyCodeCode_Title_Label.Appearance = appearance40;
            this.AgencyCodeCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.AgencyCodeCode_Title_Label.Location = new System.Drawing.Point(10, 40);
            this.AgencyCodeCode_Title_Label.Name = "AgencyCodeCode_Title_Label";
            this.AgencyCodeCode_Title_Label.Size = new System.Drawing.Size(130, 24);
            this.AgencyCodeCode_Title_Label.TabIndex = 91;
            this.AgencyCodeCode_Title_Label.Text = "消費税種類";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(290, 425);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 12;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Visible = false;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(415, 425);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 13;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Visible = false;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // TaxRateDate1_Label
            // 
            appearance38.TextVAlignAsString = "Middle";
            this.TaxRateDate1_Label.Appearance = appearance38;
            this.TaxRateDate1_Label.Location = new System.Drawing.Point(10, 185);
            this.TaxRateDate1_Label.Name = "TaxRateDate1_Label";
            this.TaxRateDate1_Label.Size = new System.Drawing.Size(105, 23);
            this.TaxRateDate1_Label.TabIndex = 93;
            this.TaxRateDate1_Label.Text = "税率改定日１";
            // 
            // TaxRateProperNounNm_tEdit
            // 
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TaxRateProperNounNm_tEdit.ActiveAppearance = appearance30;
            appearance31.BackColor = System.Drawing.Color.Transparent;
            appearance31.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance31.ForeColorDisabled = System.Drawing.Color.Black;
            this.TaxRateProperNounNm_tEdit.Appearance = appearance31;
            this.TaxRateProperNounNm_tEdit.AutoSelect = true;
            this.TaxRateProperNounNm_tEdit.BackColor = System.Drawing.Color.Transparent;
            this.TaxRateProperNounNm_tEdit.DataText = "一般消費税";
            this.TaxRateProperNounNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRateProperNounNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TaxRateProperNounNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TaxRateProperNounNm_tEdit.Location = new System.Drawing.Point(145, 40);
            this.TaxRateProperNounNm_tEdit.MaxLength = 24;
            this.TaxRateProperNounNm_tEdit.Name = "TaxRateProperNounNm_tEdit";
            this.TaxRateProperNounNm_tEdit.ReadOnly = true;
            this.TaxRateProperNounNm_tEdit.Size = new System.Drawing.Size(401, 24);
            this.TaxRateProperNounNm_tEdit.TabIndex = 0;
            this.TaxRateProperNounNm_tEdit.Text = "一般消費税";
            // 
            // TaxRate1_Label
            // 
            appearance37.TextVAlignAsString = "Middle";
            this.TaxRate1_Label.Appearance = appearance37;
            this.TaxRate1_Label.Location = new System.Drawing.Point(10, 220);
            this.TaxRate1_Label.Name = "TaxRate1_Label";
            this.TaxRate1_Label.Size = new System.Drawing.Size(105, 23);
            this.TaxRate1_Label.TabIndex = 96;
            this.TaxRate1_Label.Text = "税率１";
            // 
            // TaxRate_tNedit
            // 
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.TextHAlignAsString = "Right";
            this.TaxRate_tNedit.ActiveAppearance = appearance28;
            appearance29.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.ForeColorDisabled = System.Drawing.Color.Black;
            appearance29.TextHAlignAsString = "Right";
            this.TaxRate_tNedit.Appearance = appearance29;
            this.TaxRate_tNedit.AutoSelect = true;
            this.TaxRate_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TaxRate_tNedit.DataText = "";
            this.TaxRate_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRate_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TaxRate_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TaxRate_tNedit.Location = new System.Drawing.Point(145, 220);
            this.TaxRate_tNedit.MaxLength = 5;
            this.TaxRate_tNedit.Name = "TaxRate_tNedit";
            this.TaxRate_tNedit.NullText = "0.0";
            this.TaxRate_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 1, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TaxRate_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TaxRate_tNedit.Size = new System.Drawing.Size(51, 24);
            this.TaxRate_tNedit.TabIndex = 5;
            this.TaxRate_tNedit.Leave += new System.EventHandler(this.TaxRate_tNedit_Leave);
            // 
            // ultraLabel2
            // 
            appearance36.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance36;
            this.ultraLabel2.Location = new System.Drawing.Point(335, 185);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(24, 23);
            this.ultraLabel2.TabIndex = 99;
            this.ultraLabel2.Text = "～";
            // 
            // tLine3
            // 
            this.tLine3.BackColor = System.Drawing.Color.Transparent;
            this.tLine3.LineStyle = Broadleaf.Library.Windows.Forms.emLineStyle.lsDash;
            this.tLine3.Location = new System.Drawing.Point(10, 255);
            this.tLine3.Name = "tLine3";
            this.tLine3.Size = new System.Drawing.Size(645, 5);
            this.tLine3.TabIndex = 101;
            this.tLine3.Text = "tLine3";
            // 
            // ultraLabel3
            // 
            appearance42.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance42;
            this.ultraLabel3.Location = new System.Drawing.Point(335, 270);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(24, 23);
            this.ultraLabel3.TabIndex = 105;
            this.ultraLabel3.Text = "～";
            // 
            // TaxRate2_tNedit
            // 
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance34.ForeColor = System.Drawing.Color.Black;
            appearance34.TextHAlignAsString = "Right";
            this.TaxRate2_tNedit.ActiveAppearance = appearance34;
            appearance35.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance35.ForeColor = System.Drawing.Color.Black;
            appearance35.ForeColorDisabled = System.Drawing.Color.Black;
            appearance35.TextHAlignAsString = "Right";
            this.TaxRate2_tNedit.Appearance = appearance35;
            this.TaxRate2_tNedit.AutoSelect = true;
            this.TaxRate2_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TaxRate2_tNedit.DataText = "";
            this.TaxRate2_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRate2_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TaxRate2_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TaxRate2_tNedit.Location = new System.Drawing.Point(145, 305);
            this.TaxRate2_tNedit.MaxLength = 5;
            this.TaxRate2_tNedit.Name = "TaxRate2_tNedit";
            this.TaxRate2_tNedit.NullText = "0.0";
            this.TaxRate2_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 1, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TaxRate2_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TaxRate2_tNedit.Size = new System.Drawing.Size(51, 24);
            this.TaxRate2_tNedit.TabIndex = 8;
            this.TaxRate2_tNedit.Leave += new System.EventHandler(this.TaxRate2_tNedit_Leave);
            // 
            // TaxRate2_Label
            // 
            appearance44.TextVAlignAsString = "Middle";
            this.TaxRate2_Label.Appearance = appearance44;
            this.TaxRate2_Label.Location = new System.Drawing.Point(10, 305);
            this.TaxRate2_Label.Name = "TaxRate2_Label";
            this.TaxRate2_Label.Size = new System.Drawing.Size(105, 23);
            this.TaxRate2_Label.TabIndex = 102;
            this.TaxRate2_Label.Text = "税率２";
            // 
            // TaxRateDate2_Label
            // 
            appearance43.TextVAlignAsString = "Middle";
            this.TaxRateDate2_Label.Appearance = appearance43;
            this.TaxRateDate2_Label.Location = new System.Drawing.Point(10, 270);
            this.TaxRateDate2_Label.Name = "TaxRateDate2_Label";
            this.TaxRateDate2_Label.Size = new System.Drawing.Size(105, 23);
            this.TaxRateDate2_Label.TabIndex = 101;
            this.TaxRateDate2_Label.Text = "税率改定日２";
            // 
            // tLine4
            // 
            this.tLine4.BackColor = System.Drawing.Color.Transparent;
            this.tLine4.LineStyle = Broadleaf.Library.Windows.Forms.emLineStyle.lsDash;
            this.tLine4.Location = new System.Drawing.Point(10, 340);
            this.tLine4.Name = "tLine4";
            this.tLine4.Size = new System.Drawing.Size(645, 5);
            this.tLine4.TabIndex = 107;
            this.tLine4.Text = "tLine4";
            // 
            // ultraLabel6
            // 
            appearance45.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance45;
            this.ultraLabel6.Location = new System.Drawing.Point(335, 350);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(24, 23);
            this.ultraLabel6.TabIndex = 111;
            this.ultraLabel6.Text = "～";
            // 
            // TaxRateDate3_Label
            // 
            appearance46.TextVAlignAsString = "Middle";
            this.TaxRateDate3_Label.Appearance = appearance46;
            this.TaxRateDate3_Label.Location = new System.Drawing.Point(10, 355);
            this.TaxRateDate3_Label.Name = "TaxRateDate3_Label";
            this.TaxRateDate3_Label.Size = new System.Drawing.Size(105, 23);
            this.TaxRateDate3_Label.TabIndex = 107;
            this.TaxRateDate3_Label.Text = "税率改定日３";
            // 
            // TaxRate3_Label
            // 
            appearance47.TextVAlignAsString = "Middle";
            this.TaxRate3_Label.Appearance = appearance47;
            this.TaxRate3_Label.Location = new System.Drawing.Point(10, 390);
            this.TaxRate3_Label.Name = "TaxRate3_Label";
            this.TaxRate3_Label.Size = new System.Drawing.Size(105, 23);
            this.TaxRate3_Label.TabIndex = 108;
            this.TaxRate3_Label.Text = "税率３";
            // 
            // TaxRate3_tNedit
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.TextHAlignAsString = "Right";
            this.TaxRate3_tNedit.ActiveAppearance = appearance26;
            appearance27.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.ForeColorDisabled = System.Drawing.Color.Black;
            appearance27.TextHAlignAsString = "Right";
            this.TaxRate3_tNedit.Appearance = appearance27;
            this.TaxRate3_tNedit.AutoSelect = true;
            this.TaxRate3_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TaxRate3_tNedit.DataText = "";
            this.TaxRate3_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRate3_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TaxRate3_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TaxRate3_tNedit.Location = new System.Drawing.Point(145, 390);
            this.TaxRate3_tNedit.MaxLength = 5;
            this.TaxRate3_tNedit.Name = "TaxRate3_tNedit";
            this.TaxRate3_tNedit.NullText = "0.0";
            this.TaxRate3_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 1, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TaxRate3_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TaxRate3_tNedit.Size = new System.Drawing.Size(51, 24);
            this.TaxRate3_tNedit.TabIndex = 11;
            this.TaxRate3_tNedit.Leave += new System.EventHandler(this.TaxRate3_tNedit_Leave);
            // 
            // ConsTaxLayMethod_Label
            // 
            appearance25.TextVAlignAsString = "Middle";
            this.ConsTaxLayMethod_Label.Appearance = appearance25;
            this.ConsTaxLayMethod_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.ConsTaxLayMethod_Label.Location = new System.Drawing.Point(10, 132);
            this.ConsTaxLayMethod_Label.Name = "ConsTaxLayMethod_Label";
            this.ConsTaxLayMethod_Label.Size = new System.Drawing.Size(130, 24);
            this.ConsTaxLayMethod_Label.TabIndex = 116;
            this.ConsTaxLayMethod_Label.Text = "消費税転嫁方式";
            // 
            // ConsTaxLayMethod_tComboEditor
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ConsTaxLayMethod_tComboEditor.ActiveAppearance = appearance22;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance23.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            this.ConsTaxLayMethod_tComboEditor.Appearance = appearance23;
            this.ConsTaxLayMethod_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ConsTaxLayMethod_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ConsTaxLayMethod_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ConsTaxLayMethod_tComboEditor.ItemAppearance = appearance24;
            this.ConsTaxLayMethod_tComboEditor.Location = new System.Drawing.Point(145, 135);
            this.ConsTaxLayMethod_tComboEditor.MaxDropDownItems = 18;
            this.ConsTaxLayMethod_tComboEditor.Name = "ConsTaxLayMethod_tComboEditor";
            this.ConsTaxLayMethod_tComboEditor.Size = new System.Drawing.Size(150, 24);
            this.ConsTaxLayMethod_tComboEditor.TabIndex = 2;
            // 
            // ultraLabel1
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance21;
            this.ultraLabel1.Location = new System.Drawing.Point(202, 221);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(24, 23);
            this.ultraLabel1.TabIndex = 117;
            this.ultraLabel1.Text = "％";
            // 
            // ultraLabel4
            // 
            appearance20.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance20;
            this.ultraLabel4.Location = new System.Drawing.Point(202, 306);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(24, 23);
            this.ultraLabel4.TabIndex = 118;
            this.ultraLabel4.Text = "％";
            // 
            // ultraLabel5
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance19;
            this.ultraLabel5.Location = new System.Drawing.Point(202, 391);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(24, 21);
            this.ultraLabel5.TabIndex = 119;
            this.ultraLabel5.Text = "％";
            // 
            // TaxRateEndDate3_tDateEdit
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.TextHAlignAsString = "Right";
            this.TaxRateEndDate3_tDateEdit.ActiveEditAppearance = appearance1;
            this.TaxRateEndDate3_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.TaxRateEndDate3_tDateEdit.CalendarDisp = true;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.TaxRateEndDate3_tDateEdit.EditAppearance = appearance2;
            this.TaxRateEndDate3_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.TaxRateEndDate3_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRateEndDate3_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.TaxRateEndDate3_tDateEdit.LabelAppearance = appearance3;
            this.TaxRateEndDate3_tDateEdit.Location = new System.Drawing.Point(370, 350);
            this.TaxRateEndDate3_tDateEdit.Name = "TaxRateEndDate3_tDateEdit";
            this.TaxRateEndDate3_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.TaxRateEndDate3_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.TaxRateEndDate3_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.TaxRateEndDate3_tDateEdit.TabIndex = 10;
            this.TaxRateEndDate3_tDateEdit.TabStop = true;
            // 
            // TaxRateStartDate3_tDateEdit
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.TextHAlignAsString = "Right";
            this.TaxRateStartDate3_tDateEdit.ActiveEditAppearance = appearance4;
            this.TaxRateStartDate3_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.TaxRateStartDate3_tDateEdit.CalendarDisp = true;
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.TaxRateStartDate3_tDateEdit.EditAppearance = appearance5;
            this.TaxRateStartDate3_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.TaxRateStartDate3_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRateStartDate3_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.TaxRateStartDate3_tDateEdit.LabelAppearance = appearance6;
            this.TaxRateStartDate3_tDateEdit.Location = new System.Drawing.Point(145, 350);
            this.TaxRateStartDate3_tDateEdit.Name = "TaxRateStartDate3_tDateEdit";
            this.TaxRateStartDate3_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.TaxRateStartDate3_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.TaxRateStartDate3_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.TaxRateStartDate3_tDateEdit.TabIndex = 9;
            this.TaxRateStartDate3_tDateEdit.TabStop = true;
            // 
            // TaxRateEndDate2_tDateEdit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance7.TextHAlignAsString = "Right";
            this.TaxRateEndDate2_tDateEdit.ActiveEditAppearance = appearance7;
            this.TaxRateEndDate2_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.TaxRateEndDate2_tDateEdit.CalendarDisp = true;
            appearance8.TextHAlignAsString = "Right";
            appearance8.TextVAlignAsString = "Middle";
            this.TaxRateEndDate2_tDateEdit.EditAppearance = appearance8;
            this.TaxRateEndDate2_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.TaxRateEndDate2_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRateEndDate2_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance9.TextHAlignAsString = "Left";
            appearance9.TextVAlignAsString = "Middle";
            this.TaxRateEndDate2_tDateEdit.LabelAppearance = appearance9;
            this.TaxRateEndDate2_tDateEdit.Location = new System.Drawing.Point(370, 270);
            this.TaxRateEndDate2_tDateEdit.Name = "TaxRateEndDate2_tDateEdit";
            this.TaxRateEndDate2_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.TaxRateEndDate2_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.TaxRateEndDate2_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.TaxRateEndDate2_tDateEdit.TabIndex = 7;
            this.TaxRateEndDate2_tDateEdit.TabStop = true;
            // 
            // TaxRateStartDate2_tDateEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.TextHAlignAsString = "Right";
            this.TaxRateStartDate2_tDateEdit.ActiveEditAppearance = appearance10;
            this.TaxRateStartDate2_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.TaxRateStartDate2_tDateEdit.CalendarDisp = true;
            appearance11.TextHAlignAsString = "Right";
            appearance11.TextVAlignAsString = "Middle";
            this.TaxRateStartDate2_tDateEdit.EditAppearance = appearance11;
            this.TaxRateStartDate2_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.TaxRateStartDate2_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRateStartDate2_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance12.TextHAlignAsString = "Left";
            appearance12.TextVAlignAsString = "Middle";
            this.TaxRateStartDate2_tDateEdit.LabelAppearance = appearance12;
            this.TaxRateStartDate2_tDateEdit.Location = new System.Drawing.Point(145, 270);
            this.TaxRateStartDate2_tDateEdit.Name = "TaxRateStartDate2_tDateEdit";
            this.TaxRateStartDate2_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.TaxRateStartDate2_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.TaxRateStartDate2_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.TaxRateStartDate2_tDateEdit.TabIndex = 6;
            this.TaxRateStartDate2_tDateEdit.TabStop = true;
            // 
            // TaxRateEndDate_tDateEdit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.TextHAlignAsString = "Right";
            this.TaxRateEndDate_tDateEdit.ActiveEditAppearance = appearance13;
            this.TaxRateEndDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.TaxRateEndDate_tDateEdit.CalendarDisp = true;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance14.TextHAlignAsString = "Right";
            appearance14.TextVAlignAsString = "Middle";
            this.TaxRateEndDate_tDateEdit.EditAppearance = appearance14;
            this.TaxRateEndDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.TaxRateEndDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRateEndDate_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance15.TextHAlignAsString = "Left";
            appearance15.TextVAlignAsString = "Middle";
            this.TaxRateEndDate_tDateEdit.LabelAppearance = appearance15;
            this.TaxRateEndDate_tDateEdit.Location = new System.Drawing.Point(370, 185);
            this.TaxRateEndDate_tDateEdit.Name = "TaxRateEndDate_tDateEdit";
            this.TaxRateEndDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.TaxRateEndDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.TaxRateEndDate_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.TaxRateEndDate_tDateEdit.TabIndex = 4;
            this.TaxRateEndDate_tDateEdit.TabStop = true;
            // 
            // TaxRateStartDate_tDateEdit
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance16.TextHAlignAsString = "Right";
            this.TaxRateStartDate_tDateEdit.ActiveEditAppearance = appearance16;
            this.TaxRateStartDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.TaxRateStartDate_tDateEdit.CalendarDisp = true;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance17.TextHAlignAsString = "Right";
            appearance17.TextVAlignAsString = "Middle";
            this.TaxRateStartDate_tDateEdit.EditAppearance = appearance17;
            this.TaxRateStartDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.TaxRateStartDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TaxRateStartDate_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance18.TextHAlignAsString = "Left";
            appearance18.TextVAlignAsString = "Middle";
            this.TaxRateStartDate_tDateEdit.LabelAppearance = appearance18;
            this.TaxRateStartDate_tDateEdit.Location = new System.Drawing.Point(145, 185);
            this.TaxRateStartDate_tDateEdit.Name = "TaxRateStartDate_tDateEdit";
            this.TaxRateStartDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.TaxRateStartDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.TaxRateStartDate_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.TaxRateStartDate_tDateEdit.TabIndex = 3;
            this.TaxRateStartDate_tDateEdit.TabStop = true;
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(10, 75);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(650, 3);
            this.ultraLabel17.TabIndex = 120;
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel7.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel7.Location = new System.Drawing.Point(10, 170);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(650, 3);
            this.ultraLabel7.TabIndex = 121;
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
            // SFUKK09000UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(677, 501);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.TaxRateEndDate3_tDateEdit);
            this.Controls.Add(this.TaxRateStartDate3_tDateEdit);
            this.Controls.Add(this.TaxRateEndDate2_tDateEdit);
            this.Controls.Add(this.TaxRateStartDate2_tDateEdit);
            this.Controls.Add(this.TaxRateEndDate_tDateEdit);
            this.Controls.Add(this.TaxRateStartDate_tDateEdit);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.ConsTaxLayMethod_tComboEditor);
            this.Controls.Add(this.ConsTaxLayMethod_Label);
            this.Controls.Add(this.TaxRate3_tNedit);
            this.Controls.Add(this.TaxRate_tNedit);
            this.Controls.Add(this.TaxRateProperNounNm_tEdit);
            this.Controls.Add(this.TaxRateName_tEdit);
            this.Controls.Add(this.TaxRate2_tNedit);
            this.Controls.Add(this.tLine4);
            this.Controls.Add(this.tLine3);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.TaxRate1_Label);
            this.Controls.Add(this.TaxRateDate1_Label);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Name_Title_Label);
            this.Controls.Add(this.AgencyCodeCode_Title_Label);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.TaxRateDate2_Label);
            this.Controls.Add(this.TaxRate2_Label);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.TaxRateDate3_Label);
            this.Controls.Add(this.TaxRate3_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKK09000UA";
            this.Text = "税率設定";
            this.Load += new System.EventHandler(this.SFUKK09000UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFUKK09000UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFUKK09000UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRateName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRateProperNounNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRate_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRate2_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxRate3_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxLayMethod_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
        // 2008.06.03 30413 犬飼 シングルタイプに変更 >>>>>>START
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
        // 2008.06.03 30413 犬飼 シングルタイプに変更 <<<<<<END
		# endregion
				
		#region Private Members
		private TaxRateSetAcs _taxratesetAcs;
		private TaxRateSet _prevTaxRateSet;
		private bool _nextData;
		private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _taxratesetTable;

        // ↓ 20070206 18322 a MA.NS用に変更
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // ↑ 20070206 18322 a

		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;

        //2005.07.02 フレームの最小化対応改良  三橋>>>>>>START
		private int _indexBuf;
		//// 2005.05.27 TOUMA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
		//// 最小化判定用フラグ
		//private bool _minFlg;
		//// 2005.05.27 TOUMA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
		//2005.07.02 フレームの最小化対応改良　三橋<<<<<<END

        // 2008.06.03 30413 犬飼 シングルタイプに変更 >>>>>>START
        // HTML情報
        private const string HTML_HEADER_TITLE = "設定項目";
        private const string HTML_HEADER_VALUE = "設定値";
        private const string HTML_UNREGISTER = "未設定";
        private const string HTML_PERIOD = "～";
        private const string TAXRATE1_UPDATE = "税率改定日１";
        private const string TAXRATE2_UPDATE = "税率改定日２";
        private const string TAXRATE3_UPDATE = "税率改定日３";
        
        // 税率設定データ取得時の引数
        private int TAXRATE_CODE_PUBLIC = 0;    //一般消費税(固定)

        // エラー出力情報
        private const string CT_PGID = "SFUKK09000U";
        private const string CT_PGNM = "税率設定";
        // 2008.06.03 30413 犬飼 シングルタイプに変更 <<<<<<END

		// FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
		private const string DELETE_DATE = "削除日";
		private const string CODE_TITLE = "税率コード";
        //private const string PROPERNOUNNM_TITLE = "税率固有名称"; // DEL 2008/11/06
        private const string PROPERNOUNNM_TITLE = "消費税種類"; // ADD 2008/11/06
        //private const string NAME_TITLE = "表示／印刷名称"; // DEL 2008/11/06
        //private const string NAME_TITLE = "表示／印刷名"; // ADD 2008/11/06   // DEL 2009/06/19
        private const string NAME_TITLE = "表示名"; // ADD 2009/06/19
        // 2007.08.16 修正 >>>>>>>>>>>>>>>>>>>>
		//private const string FRACTION_TITLE = "端数処理";
        private const string FRACTION_TITLE = "消費税転嫁方式";
        // 2007.08.16 修正 <<<<<<<<<<<<<<<<<<<<
        private const string STARTDATE1_TITLE = "開始日１";
		private const string ENDDATE1_TITLE = "終了日１";
		private const string TAXRATE1_TITLE = "税率１";
		private const string STARTDATE2_TITLE = "開始日２";
		private const string ENDDATE2_TITLE = "終了日２";
		private const string TAXRATE2_TITLE = "税率２";
		private const string STARTDATE3_TITLE = "開始日３";
		private const string ENDDATE3_TITLE = "終了日３";
		private const string TAXRATE3_TITLE = "税率３";
		private const string GUID_TITLE = "GUID";

		private const string TAXRATESET_TABLE = "TAXRATESET";

		//比較用clone
		private TaxRateSet _taxRateSetClone;

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";

		// 2005.06.21 未設定時、「未設定」ではなく空白で表示する。 >>>> START
		//private const string UNREGISTER = "未設定";
		private const string UNREGISTER = "";
		// 2005.06.21 未設定時、「未設定」ではなく空白で表示する。 >>>> END

        // 2007.08.16 修正 >>>>>>>>>>>>>>>>>>>>
        //// 消費税端数処理区分
        //private const string TAXFRACPROC_NON = "処理しない";
        //private const string TAXFRACPROC_1CUT   = "下一桁切捨";
        //private const string TAXFRACPROC_1ROUND = "下一桁四捨五入";
        //private const string TAXFRACPROC_1RAISE = "下一桁切上";
        //private const string TAXFRACPROC_2CUT   = "下二桁切捨";
        //private const string TAXFRACPROC_2ROUND = "下二桁四捨五入";
        //private const string TAXFRACPROC_2RAISE = "下二桁切上";
        //private const string TAXFRACPROC_3CUT   = "下三桁切捨";
        //private const string TAXFRACPROC_3ROUND = "下三桁四捨五入";
        //private const string TAXFRACPROC_3RAISE = "下三桁切上";
        //private const string TAXFRACPROC_CUT    = "円未満切捨";
        //private const string TAXFRACPROC_ROUND  = "円未満四捨五入";
		//private const string TAXFRACPROC_RAISE  = "円未満切上";
        // 消費税転嫁方式
        // 2008.12.18 30413 犬飼 名称を変更 >>>>>>START
        //private const string CONSTAXLAY_SLIP        = "伝票単位";
        //private const string CONSTAXLAY_DETAILS     = "明細単位";
        private const string CONSTAXLAY_SLIP = "伝票転嫁";
        private const string CONSTAXLAY_DETAILS = "明細転嫁";
        // 2008.12.18 30413 犬飼 名称を変更 <<<<<<END
        private const string CONSTAXLAY_CLAIMPARENT = "請求親";
        private const string CONSTAXLAY_CLAIMCHILD  = "請求子";
        // 2007.08.16 修正 <<<<<<<<<<<<<<<<<<<<
		
		//2005.09.20 enokida ADD MessageBox対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
		string pgId = "SFUKK09000U";
		string pgNm = "税率設定";
		string obj = "TaxRateSetAcs";
		//2005.09.20 enokida ADD MessageBox対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
		#endregion
    
		# region Main
		/// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFUKK09000UA());
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
			tableName = TAXRATESET_TABLE;
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
			ArrayList taxratesets = null;

			if (readCount == 0)
			{
				// 抽出対象件数が0の場合は全件抽出を実行する
				status = this._taxratesetAcs.SearchAll(
							out taxratesets,
							this._enterpriseCode);

				this._totalCount = taxratesets.Count;
			}
			else
			{
				status = this._taxratesetAcs.SearchSpecificationAll(
							out taxratesets,
							out this._totalCount,
							out this._nextData,
							this._enterpriseCode,
							readCount,
							this._prevTaxRateSet);
			}

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( taxratesets.Count > 0 ) {
						// 最終の税率オブジェクトを退避する
						this._prevTaxRateSet = ((TaxRateSet)taxratesets[taxratesets.Count - 1]).Clone();
					}

					int index = 0;
					foreach(TaxRateSet taxrateset in taxratesets)
					{
						if (this._taxratesetTable.ContainsKey(taxrateset.FileHeaderGuid) == false)
						{
							TaxratesetToDataSet(taxrateset.Clone(), index);
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
					//2005.09.17 enokida 変更 MessageBox対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
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
					//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//					MessageBox.Show(
//						"読み込みに失敗しました。 st = " + status.ToString(),
//						"エラー",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);

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
			ArrayList taxratesets = null;

			// 抽出対象件数が0の場合は、残りの全件を抽出
			if (readCount == 0)
			{
				readCount =	this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			}

			int status = this._taxratesetAcs.SearchSpecificationAll(
							out taxratesets,
							out dummy,
							out this._nextData, 
							this._enterpriseCode,
							readCount,
							this._prevTaxRateSet);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( taxratesets.Count > 0 ) {
						// 最終の税率クラスを退避する
						this._prevTaxRateSet = ((TaxRateSet)taxratesets[taxratesets.Count - 1]).Clone();
					}

					int index = 0;
					foreach(TaxRateSet taxrateset in taxratesets)
					{
						if (this._taxratesetTable.ContainsKey(taxrateset.FileHeaderGuid) == false)
						{
							index = this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows.Count;
							TaxratesetToDataSet(taxrateset.Clone(), index);
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
					//2005.09.17 enokida 変更 MessageBox対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
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
					//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//					MessageBox.Show(
//						"読み込みに失敗しました。 st = " + status.ToString(),
//						"エラー",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);

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
			Guid guid = (Guid)this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[this._dataIndex][GUID_TITLE];
			TaxRateSet taxrateset = (TaxRateSet)this._taxratesetTable[guid];

			int status = this._taxratesetAcs.LogicalDelete(ref taxrateset);
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //2005.07.06 排他制御対応　三橋>>>>>START
				if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
				{

					//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						pgId,
						"既に他端末より削除されています",
						status,
						MessageBoxButtons.OK);
					//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
                    //2005.07.12 排他制御コメント変更　三橋>>>>>START
//					MessageBox.Show(
//						"既に他端末より削除されています",
//						"注意",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Exclamation,
//						MessageBoxDefaultButton.Button1);
					//MessageBox.Show(
					//	"既に他端末で削除されています",
					//	"注意",
					//	MessageBoxButtons.OK,
					//	MessageBoxIcon.Exclamation,
					//	MessageBoxDefaultButton.Button1);
                    //2005.07.12 排他制御コメント変更　三橋<<<<<<END

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
					//2005.09.17 enokida 変更 MessageBox対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
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
					//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//					MessageBox.Show(
//						"削除に失敗しました。 st = " + status.ToString(),
//						"エラー",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
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
				//MessageBox.Show(
				//	"削除に失敗しました。 st = " + status.ToString(),
				//	"エラー",
				//	MessageBoxButtons.OK,
				//	MessageBoxIcon.Error,
				//	MessageBoxDefaultButton.Button1);
				//return status;
                //2005.07.06 排他制御対応　三橋<<<<<<END
			}

			status = this._taxratesetAcs.Read(out taxrateset, taxrateset.EnterpriseCode, taxrateset.TaxRateCode);

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				//2005.09.17 enokida 変更 MessageBox対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
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
				//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//				MessageBox.Show(
//					"読み込みに失敗しました。 st = " + status.ToString(),
//					"エラー",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Error,
//					MessageBoxDefaultButton.Button1);
				return status;
			}

			TaxratesetToDataSet(taxrateset.Clone(), this._dataIndex);

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
			appearanceTable.Add(CODE_TITLE,			new GridColAppearance(MGridColDispType.None,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(PROPERNOUNNM_TITLE,	new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(NAME_TITLE,			new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(FRACTION_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(STARTDATE1_TITLE,	new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(ENDDATE1_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
//			appearanceTable.Add(TAXRATE1_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));	// 2005.06.09 TOUMA DEL フレームに表示する内容の表示位置を右詰めに変更
			appearanceTable.Add(TAXRATE1_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleRight,"",Color.Black));	// 2005.06.09 TOUMA ADD フレームに表示する内容の表示位置を右詰めに変更
			appearanceTable.Add(STARTDATE2_TITLE,	new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(ENDDATE2_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
//			appearanceTable.Add(TAXRATE2_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));	// 2005.06.09 TOUMA DEL フレームに表示する内容の表示位置を右詰めに変更
			appearanceTable.Add(TAXRATE2_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleRight,"",Color.Black));	// 2005.06.09 TOUMA ADD フレームに表示する内容の表示位置を右詰めに変更
			appearanceTable.Add(STARTDATE3_TITLE,	new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(ENDDATE3_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));
//			appearanceTable.Add(TAXRATE3_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleLeft,"",Color.Black));	// 2005.06.09 TOUMA DEL フレームに表示する内容の表示位置を右詰めに変更
			appearanceTable.Add(TAXRATE3_TITLE,		new GridColAppearance(MGridColDispType.Both,			ContentAlignment.MiddleRight,"",Color.Black));	// 2005.06.09 TOUMA ADD フレームに表示する内容の表示位置を右詰めに変更


			appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None,			ContentAlignment.MiddleLeft,"",Color.Black));

			return appearanceTable;
		}
		# endregion

		# region Private Methods
		/// <summary>
		/// 税率オブジェクトデータセット展開処理
		/// </summary>
		/// <param name="taxrateset">税率オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note       : 税率クラスをデータセットに格納します。</br>
		/// <br>Programmer : 21041　中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private void TaxratesetToDataSet(TaxRateSet taxrateset, int index)
		{
			Double ix = 0;

			if ((index < 0) || (this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[TAXRATESET_TABLE].NewRow();
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows.Add(dataRow);

				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows.Count - 1;
			}

			// 論理削除日付
			if (taxrateset.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][DELETE_DATE] = "";
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][DELETE_DATE] = taxrateset.UpdateDateTimeJpInFormal;
			}

			// 税率コード（非表示） 
			this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][CODE_TITLE] = taxrateset.TaxRateCode;

			// 固定税率名称
			this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][PROPERNOUNNM_TITLE] = taxrateset.TaxRateProperNounNm;

			// 表示／印刷用名称
			this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][NAME_TITLE] = taxrateset.TaxRateName;

            // 2007.08.16 修正 >>>>>>>>>>>>>>>>>>>>
            //// 端数処理
			//string wrkstr;
			//switch(taxrateset.FractionProcCd)
			//{
			//	case 0:
			//		wrkstr = TAXFRACPROC_NON;// "処理しない"
			//		break;
			//	case 11:
			//		wrkstr = TAXFRACPROC_1CUT;//"下一桁切捨"
			//		break;
			//	case 12:
			//		wrkstr = TAXFRACPROC_1ROUND;//"下一桁四捨五入"
			//		break;
			//	case 13:
			//		wrkstr = TAXFRACPROC_1RAISE;//"下一桁切上";
			//		break;
			//	case 21:
			//		wrkstr = TAXFRACPROC_2CUT;// "下二桁切捨"
			//		break;
			//	case 22:
			//		wrkstr = TAXFRACPROC_2ROUND;//"下二桁四捨五入";
			//		break;
			//	case 23:
			//		wrkstr = TAXFRACPROC_2RAISE;//"下二桁切上";
			//		break;
			//	case 31:
			//		wrkstr = TAXFRACPROC_3CUT;  //"下三桁切捨";
			//		break;
			//	case 32:
			//		wrkstr = TAXFRACPROC_3ROUND; //"下三桁四捨五入";
			//		break;
			//	case 33:
			//		wrkstr = TAXFRACPROC_3RAISE; //"下三桁切上";
			//		break;
			//	case -11:
			//		wrkstr = TAXFRACPROC_CUT;    //"円未満切捨";
			//		break;
			//	case -12:
			//		wrkstr = TAXFRACPROC_ROUND;  //"円未満四捨五入";
			//		break;
			//	case -13:
			//		wrkstr = TAXFRACPROC_RAISE;  //"円未満切上";
			//		break;
            //	default:
            //		wrkstr = UNREGISTER;
            //		break;
            //}
            // 消費税転嫁方式
            string wrkstr;
            switch (taxrateset.ConsTaxLayMethod)
            {
                case 0:
                    wrkstr = CONSTAXLAY_SLIP;       // "伝票単位"
                    break;
                case 1:
                    wrkstr = CONSTAXLAY_DETAILS;    //"明細単位"
                    break;
                case 2:
                    wrkstr = CONSTAXLAY_CLAIMPARENT;//"請求親"
                    break;
                case 3:
                    wrkstr = CONSTAXLAY_CLAIMCHILD; //"請求子"
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            // 2007.08.16 修正 <<<<<<<<<<<<<<<<<<<<
            this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][FRACTION_TITLE] = wrkstr;

			// 税率改定日１ 開始日
			if (taxrateset.TaxRateStartDate != DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][STARTDATE1_TITLE] = taxrateset.TaxRateStartDateJpFormal;
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][STARTDATE1_TITLE] = UNREGISTER;
			}

			// 税率改定日２ 開始日
			if (taxrateset.TaxRateStartDate2 != DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][STARTDATE2_TITLE] = taxrateset.TaxRateStartDate2JpFormal;
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][STARTDATE2_TITLE] = UNREGISTER;
			}

			// 税率改定日３ 開始日
			if (taxrateset.TaxRateStartDate3 != DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][STARTDATE3_TITLE] = taxrateset.TaxRateStartDate3JpFormal;
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][STARTDATE3_TITLE] = UNREGISTER;
			}

			// 税率改定日１ 終了日
			if (taxrateset.TaxRateEndDate != DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][ENDDATE1_TITLE] = taxrateset.TaxRateEndDateJpFormal;
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][ENDDATE1_TITLE] = UNREGISTER;
			}

			// 税率改定日２ 終了日
			if (taxrateset.TaxRateEndDate2 != DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][ENDDATE2_TITLE] = taxrateset.TaxRateEndDate2JpFormal;
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][ENDDATE2_TITLE] = UNREGISTER;
			}

			// 税率改定日３ 終了日
			if (taxrateset.TaxRateEndDate3 != DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][ENDDATE3_TITLE] = taxrateset.TaxRateEndDate3JpFormal;
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][ENDDATE3_TITLE] = UNREGISTER;
			}

			// 税率１ ※改定日付入力時には「未設定」ではなく「0.0％」と表示する
			if ((taxrateset.TaxRate != 0) ||
			   ((taxrateset.TaxRateStartDate != DateTime.MinValue) || (taxrateset.TaxRateEndDate != DateTime.MinValue)))
			{
				ix = taxrateset.TaxRate * 100;
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][TAXRATE1_TITLE] = ix.ToString("f1")+"%";
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][TAXRATE1_TITLE] = UNREGISTER;
			}

			// 税率２ ※改定日付入力時には「未設定」ではなく「0.0％」と表示する
			if ((taxrateset.TaxRate2 != 0) || 
			   ((taxrateset.TaxRateStartDate2 != DateTime.MinValue) || (taxrateset.TaxRateEndDate2 != DateTime.MinValue)))
			{
				ix = taxrateset.TaxRate2 * 100;
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][TAXRATE2_TITLE] = ix.ToString("f1")+"%";
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][TAXRATE2_TITLE] = UNREGISTER;
			}

			// 税率３ ※改定日付入力時には「未設定」ではなく「0.0％」と表示する
			if ((taxrateset.TaxRate3 != 0) ||
			   ((taxrateset.TaxRateStartDate3 != DateTime.MinValue) || (taxrateset.TaxRateEndDate3 != DateTime.MinValue)))
			{
				ix = taxrateset.TaxRate3 * 100;
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][TAXRATE3_TITLE] = ix.ToString("f1")+"%";
			}
			else
			{
				this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][TAXRATE3_TITLE] = UNREGISTER;
			}

			this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[index][GUID_TITLE] = taxrateset.FileHeaderGuid;

			if (this._taxratesetTable.ContainsKey(taxrateset.FileHeaderGuid) == true)
			{
				this._taxratesetTable.Remove(taxrateset.FileHeaderGuid);
			}
			this._taxratesetTable.Add(taxrateset.FileHeaderGuid, taxrateset);
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
			DataTable taxratesetTable = new DataTable(TAXRATESET_TABLE);

			// Addを行う順番が、列の表示順位となります。
			taxratesetTable.Columns.Add(DELETE_DATE, typeof(string));
			taxratesetTable.Columns.Add(CODE_TITLE, typeof(int));
			taxratesetTable.Columns.Add(PROPERNOUNNM_TITLE, typeof(string));
			taxratesetTable.Columns.Add(NAME_TITLE, typeof(string));
			taxratesetTable.Columns.Add(FRACTION_TITLE, typeof(string));
			taxratesetTable.Columns.Add(STARTDATE1_TITLE, typeof(string));
			taxratesetTable.Columns.Add(ENDDATE1_TITLE, typeof(string));
			taxratesetTable.Columns.Add(TAXRATE1_TITLE, typeof(string));
			taxratesetTable.Columns.Add(STARTDATE2_TITLE, typeof(string));
			taxratesetTable.Columns.Add(ENDDATE2_TITLE, typeof(string));
			taxratesetTable.Columns.Add(TAXRATE2_TITLE, typeof(string));
			taxratesetTable.Columns.Add(STARTDATE3_TITLE, typeof(string));
			taxratesetTable.Columns.Add(ENDDATE3_TITLE, typeof(string));
			taxratesetTable.Columns.Add(TAXRATE3_TITLE, typeof(string));
			taxratesetTable.Columns.Add(GUID_TITLE, typeof(Guid));

			this.Bind_DataSet.Tables.Add(taxratesetTable);
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
            // 2007.08.16 修正 >>>>>>>>>>>>>>>>>>>>
            ////端数処理区分のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            //FractionProc_tComboEditor.Items.Clear();
            //FractionProc_tComboEditor.Items.Add(0,TAXFRACPROC_NON);
            //FractionProc_tComboEditor.Items.Add(11,TAXFRACPROC_1CUT);
            //FractionProc_tComboEditor.Items.Add(12,TAXFRACPROC_1ROUND);
            //FractionProc_tComboEditor.Items.Add(13,TAXFRACPROC_1RAISE);
            //FractionProc_tComboEditor.Items.Add(21,TAXFRACPROC_2CUT);
            //FractionProc_tComboEditor.Items.Add(22,TAXFRACPROC_2ROUND);
            //FractionProc_tComboEditor.Items.Add(23,TAXFRACPROC_2RAISE);
            //FractionProc_tComboEditor.Items.Add(31,TAXFRACPROC_3CUT);
            //FractionProc_tComboEditor.Items.Add(32,TAXFRACPROC_3ROUND);
            //FractionProc_tComboEditor.Items.Add(33,TAXFRACPROC_3RAISE);
            //FractionProc_tComboEditor.Items.Add(-11,TAXFRACPROC_CUT);
            //FractionProc_tComboEditor.Items.Add(-12,TAXFRACPROC_ROUND);
            //FractionProc_tComboEditor.Items.Add(-13,TAXFRACPROC_RAISE);
            //FractionProc_tComboEditor.MaxDropDownItems = FractionProc_tComboEditor.Items.Count;
            //消費税転嫁方式のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            ConsTaxLayMethod_tComboEditor.Items.Clear();
            ConsTaxLayMethod_tComboEditor.Items.Add(0, CONSTAXLAY_SLIP);
            ConsTaxLayMethod_tComboEditor.Items.Add(1, CONSTAXLAY_DETAILS);
            ConsTaxLayMethod_tComboEditor.Items.Add(2, CONSTAXLAY_CLAIMPARENT);
            ConsTaxLayMethod_tComboEditor.Items.Add(3, CONSTAXLAY_CLAIMCHILD);
            ConsTaxLayMethod_tComboEditor.MaxDropDownItems = ConsTaxLayMethod_tComboEditor.Items.Count;
            // 2007.08.16 修正 <<<<<<<<<<<<<<<<<<<<
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
			this.TaxRateProperNounNm_tEdit.Clear();
			this.TaxRateName_tEdit.Clear();
            // 2007.08.16 修正 >>>>>>>>>>>>>>>>>>>>
            //this.FractionProc_tComboEditor.Value = 0;
            this.ConsTaxLayMethod_tComboEditor.Value = 0;
            // 2007.08.16 修正 <<<<<<<<<<<<<<<<<<<<
            this.TaxRate_tNedit.Clear();
			this.TaxRate2_tNedit.Clear();
			this.TaxRate3_tNedit.Clear();
			this.TaxRateStartDate_tDateEdit.Clear();
			this.TaxRateStartDate2_tDateEdit.Clear();
			this.TaxRateStartDate3_tDateEdit.Clear();
			this.TaxRateEndDate_tDateEdit.Clear();
			this.TaxRateEndDate2_tDateEdit.Clear();
			this.TaxRateEndDate3_tDateEdit.Clear();
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

            this._prevTaxRateSet = new TaxRateSet();

            // 税率設定データ取得
            status = this._taxratesetAcs.Read(out this._prevTaxRateSet, this._enterpriseCode, TAXRATE_CODE_PUBLIC);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (this._prevTaxRateSet == null)
                {
                    this._prevTaxRateSet = new TaxRateSet();
                }

                this.Mode_Label.Text = UPDATE_MODE;

                // 税率設定画面展開処理
                this.TaxratesetToDataSet(this._prevTaxRateSet);
                // 比較用クローン作成
                this._taxRateSetClone = this._prevTaxRateSet.Clone();
                // 画面情報を比較用クローンにコピー
                this.DispToTaxrateset(ref this._taxRateSetClone);

                // 画面入力許可制御
                ScreenInputPermissionControl(true);

                // 初期フォーカスをセット
                this.TaxRateName_tEdit.Focus();
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
                    this._taxratesetAcs,                  // エラーが発生したオブジェクト
                    MessageBoxButtons.OK,                 // 表示するボタン
                    MessageBoxDefaultButton.Button1);    // 初期表示ボタン

                this.Mode_Label.Text = UPDATE_MODE;

                this._prevTaxRateSet = new TaxRateSet();

                // 税率設定画面展開処理
                this.TaxratesetToDataSet(this._prevTaxRateSet);
                // 比較用クローン作成
                this._taxRateSetClone = this._prevTaxRateSet.Clone();
                // 画面情報を比較用クローンにコピー
                this.DispToTaxrateset(ref this._taxRateSetClone);

                // 画面入力許可制御
                ScreenInputPermissionControl(true);

                // 初期フォーカスをセット
                this.TaxRateName_tEdit.Focus();
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
			this.TaxRateProperNounNm_tEdit.Enabled = enabled;
			this.TaxRateName_tEdit.Enabled = enabled;
            // 2007.08.16 修正 >>>>>>>>>>>>>>>>>>>>
            //this.FractionProc_tComboEditor.Enabled = enabled;
            this.ConsTaxLayMethod_tComboEditor.Enabled = enabled;
            // 2007.08.16 修正 <<<<<<<<<<<<<<<<<<<<
            this.TaxRate_tNedit.Enabled = enabled;
			this.TaxRate2_tNedit.Enabled = enabled;
			this.TaxRate3_tNedit.Enabled = enabled;
			this.TaxRateStartDate_tDateEdit.Enabled = enabled;
			this.TaxRateStartDate2_tDateEdit.Enabled = enabled;
			this.TaxRateStartDate3_tDateEdit.Enabled = enabled;
			this.TaxRateEndDate_tDateEdit.Enabled = enabled;
			this.TaxRateEndDate2_tDateEdit.Enabled = enabled;
			this.TaxRateEndDate3_tDateEdit.Enabled = enabled;
		}

		/// <summary>
		/// 税率クラス画面展開処理
		/// </summary>
		/// <param name="taxrateset">税率オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 税率オブジェクトから画面にデータを展開します。</br>
		/// <br>Programmer : 21041　中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private void TaxratesetToDataSet(TaxRateSet taxrateset)
		{
			this.TaxRateProperNounNm_tEdit.Text = taxrateset.TaxRateProperNounNm;
			this.TaxRateName_tEdit.Text = taxrateset.TaxRateName;
            // 2007.08.16 修正 >>>>>>>>>>>>>>>>>>>>
            //this.FractionProc_tComboEditor.Value = taxrateset.FractionProcCd;
            this.ConsTaxLayMethod_tComboEditor.Value = taxrateset.ConsTaxLayMethod;
            // 2007.08.16 修正 <<<<<<<<<<<<<<<<<<<<

			// 各日付が最小値の場合は表示しない
			if (taxrateset.TaxRateStartDate != DateTime.MinValue)
			{
				this.TaxRateStartDate_tDateEdit.SetDateTime(taxrateset.TaxRateStartDate);
			}

			if (taxrateset.TaxRateStartDate2 != DateTime.MinValue)
			{
				this.TaxRateStartDate2_tDateEdit.SetDateTime(taxrateset.TaxRateStartDate2);
			}

			if (taxrateset.TaxRateStartDate3 != DateTime.MinValue)
			{
				this.TaxRateStartDate3_tDateEdit.SetDateTime(taxrateset.TaxRateStartDate3);
			}

			if (taxrateset.TaxRateEndDate != DateTime.MinValue)
			{
				this.TaxRateEndDate_tDateEdit.SetDateTime(taxrateset.TaxRateEndDate);
			}

			if (taxrateset.TaxRateEndDate2 != DateTime.MinValue)
			{
				this.TaxRateEndDate2_tDateEdit.SetDateTime(taxrateset.TaxRateEndDate2);
			}

			if (taxrateset.TaxRateEndDate3 != DateTime.MinValue)
			{
				this.TaxRateEndDate3_tDateEdit.SetDateTime(taxrateset.TaxRateEndDate3);
			}

			this.TaxRate_tNedit.SetValue(taxrateset.TaxRate * 100);
			this.TaxRate2_tNedit.SetValue(taxrateset.TaxRate2 * 100);
			this.TaxRate3_tNedit.SetValue(taxrateset.TaxRate3 * 100);
		}

		/// <summary>
		/// 画面情報税率クラス格納処理
		/// </summary>
		/// <param name="taxrateset">税率オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 画面情報から税率オブジェクトにデータを格納します。</br>
		/// <br>Programmer : 21041　中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
 		private void DispToTaxrateset(ref TaxRateSet taxrateset)
		{
			if (taxrateset == null)
			{
				// 新規の場合
				taxrateset = new TaxRateSet();
			}

			taxrateset.EnterpriseCode		= this._enterpriseCode;			// ← 要変更
			taxrateset.TaxRateProperNounNm	= this.TaxRateProperNounNm_tEdit.Text;
			taxrateset.TaxRateName			= this.TaxRateName_tEdit.Text;
            // 2007.08.16 修正 >>>>>>>>>>>>>>>>>>>>
            //taxrateset.FractionProcCd = (int)this.FractionProc_tComboEditor.Value;
            taxrateset.ConsTaxLayMethod = (int)this.ConsTaxLayMethod_tComboEditor.Value;
            // 2007.08.16 修正 <<<<<<<<<<<<<<<<<<<<
            taxrateset.TaxRateStartDate = this.TaxRateStartDate_tDateEdit.GetDateTime();
			taxrateset.TaxRateStartDate2	= this.TaxRateStartDate2_tDateEdit.GetDateTime();
			taxrateset.TaxRateStartDate3	= this.TaxRateStartDate3_tDateEdit.GetDateTime();
			taxrateset.TaxRateEndDate		= this.TaxRateEndDate_tDateEdit.GetDateTime();
			taxrateset.TaxRateEndDate2		= this.TaxRateEndDate2_tDateEdit.GetDateTime();
			taxrateset.TaxRateEndDate3		= this.TaxRateEndDate3_tDateEdit.GetDateTime();
			taxrateset.TaxRate				= this.TaxRate_tNedit.GetValue() / 100;
			taxrateset.TaxRate2				= this.TaxRate2_tNedit.GetValue() / 100;
			taxrateset.TaxRate3				= this.TaxRate3_tNedit.GetValue() / 100;
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
        /// <br>Note       : Redmine#42120 税率設定マスタにチェックを追加する</br>
        /// <br>Programmer : 鄭慕鈞</br>
        /// <br>Date       : 2014/02/18</br>
		/// </remarks>
		private bool ScreenDataCheck(ref Control control, ref string message)
		{
			// 表示／印刷用名称
			if (this.TaxRateName_tEdit.Text.Trim() == "")
			{
				control = this.TaxRateName_tEdit;
				message = this.Name_Title_Label.Text + "を入力して下さい。";
				return false;
			}
			
            // 2007.08.16 修正 >>>>>>>>>>>>>>>>>>>>
            // 端数処理
			//if ((int)this.FractionProc_tComboEditor.Value == -1)
			//{
			//	control = this.FractionProc_tComboEditor;
			//	message = this.FractionProc_Label.Text + "を選択して下さい。";
			//	return false;
			//}
            // 消費税転嫁
            if ((int)this.ConsTaxLayMethod_tComboEditor.Value == -1)
            {
                control = this.ConsTaxLayMethod_tComboEditor;
                message = this.ConsTaxLayMethod_Label.Text + "を選択して下さい。";
                return false;
            }
            // 2007.08.16 修正 <<<<<<<<<<<<<<<<<<<<
			
			// 税金改定日１開始日
			if (this.TaxRateStartDate_tDateEdit.LongDate == 0)
			{
				control = this.TaxRateStartDate_tDateEdit;
				message = this.TaxRateDate1_Label.Text + "を入力して下さい。";
				return false;
			}
			
			// 税金改定日１終了日
			if (this.TaxRateEndDate_tDateEdit.LongDate == 0)
			{
				control = this.TaxRateEndDate_tDateEdit;
				message = this.TaxRateDate1_Label.Text + "を入力して下さい。";
				return false;
			}
			
			//--日付の有効性チェック--//
			if ((TaxRateStartDate_tDateEdit.CheckInputData() != null) ||
				!(CheckDateEffect(TaxRateStartDate_tDateEdit)))
			{
				message = "税率改定日１の開始日が不正です。";
				control = TaxRateStartDate_tDateEdit;
				return false;
			}
			if ((TaxRateEndDate_tDateEdit.CheckInputData() != null) ||
				!(CheckDateEffect(TaxRateEndDate_tDateEdit)))
			{
				message = "税率改定日１の終了日が不正です。";
				control = TaxRateEndDate_tDateEdit;
				return false;
			}

			//--有効日の大小チェック--//
			if (TaxRateStartDate_tDateEdit.LongDate >= TaxRateEndDate_tDateEdit.LongDate)
			{
				control = TaxRateStartDate_tDateEdit;
				message = "税率改定日１の範囲が不正です。";
				return false;
			}

			// 税金改定日２もしくは税率２のいづれかが入力されていた場合
			if ((this.TaxRate2_tNedit.GetValue() != 0) || 
				(this.TaxRateStartDate2_tDateEdit.LongDate != 0) ||
				(this.TaxRateEndDate2_tDateEdit.LongDate != 0))
			{
				// 税金改定日２開始日
				if (this.TaxRateStartDate2_tDateEdit.LongDate == 0)
				{
					control = this.TaxRateStartDate2_tDateEdit;
					message = this.TaxRateDate2_Label.Text + "を入力して下さい。";
					return false;
				}
			
				// 税金改定日２終了日
				if (this.TaxRateEndDate2_tDateEdit.LongDate == 0)
				{
					control = this.TaxRateEndDate2_tDateEdit;
					message = this.TaxRateDate2_Label.Text + "を入力して下さい。";
					return false;
				}
			
				//--日付の有効性チェック--//
				if ((TaxRateStartDate2_tDateEdit.CheckInputData() != null) ||
					!(CheckDateEffect(TaxRateStartDate2_tDateEdit)))
				{
					message = "税率改定日２の開始日が不正です。";
					control = TaxRateStartDate2_tDateEdit;
					return false;
				}
				if ((TaxRateEndDate2_tDateEdit.CheckInputData() != null) ||
					!(CheckDateEffect(TaxRateEndDate2_tDateEdit)))
				{
					message = "税率改定日２の終了日が不正です。";
					control = TaxRateEndDate2_tDateEdit;
					return false;
				}

				//--有効日の大小チェック--//
				if (TaxRateStartDate2_tDateEdit.LongDate >= TaxRateEndDate2_tDateEdit.LongDate)
				{
					control = TaxRateStartDate2_tDateEdit;
					message = "税率改定日２の範囲が不正です。";
					return false;
				}

                // 2008.03.06 追加 >>>>>>>>>>>>>>>>>>>>
				//--有効日の重複チェック--//
                if ( (TaxRateEndDate_tDateEdit.LongDate   >= TaxRateStartDate2_tDateEdit.LongDate) ||
                    ((TaxRateStartDate_tDateEdit.LongDate >  TaxRateStartDate2_tDateEdit.LongDate) &&
                     (TaxRateEndDate2_tDateEdit.LongDate  >= TaxRateStartDate_tDateEdit.LongDate )))
				{
					control = TaxRateStartDate2_tDateEdit;
                    message = "税率改定日２の範囲が税率改定日１の範囲と重複してます。";
					return false;
				}
                // 2008.03.06 追加 <<<<<<<<<<<<<<<<<<<<
            }

			// 税金改定日３もしくは税率３のいづれかが入力されていた場合
			if ((this.TaxRate3_tNedit.GetValue() != 0) || 
				(this.TaxRateStartDate3_tDateEdit.LongDate != 0) ||
				(this.TaxRateEndDate3_tDateEdit.LongDate != 0))
			{
				// 税金改定日３開始日
				if (this.TaxRateStartDate3_tDateEdit.LongDate == 0)
				{
					control = this.TaxRateStartDate3_tDateEdit;
					message = this.TaxRateDate3_Label.Text + "を入力して下さい。";
					return false;
				}
			
				// 税金改定日３終了日
				if (this.TaxRateEndDate3_tDateEdit.LongDate == 0)
				{
					control = this.TaxRateEndDate3_tDateEdit;
					message = this.TaxRateDate3_Label.Text + "を入力して下さい。";
					return false;
				}
			
				//--日付の有効性チェック--//
				if ((TaxRateStartDate3_tDateEdit.CheckInputData() != null) ||
					!(CheckDateEffect(TaxRateStartDate3_tDateEdit)))
				{
					message = "税率改定日３の開始日が不正です。";
                    // 2007.03.27  S.Koga  amend ------------------------------------------
                    //control = TaxRateStartDate_tDateEdit;
                    control = TaxRateStartDate3_tDateEdit;
                    // --------------------------------------------------------------------
                    return false;
				}
				if ((TaxRateEndDate3_tDateEdit.CheckInputData() != null) ||
					!(CheckDateEffect(TaxRateEndDate3_tDateEdit)))
				{
					message = "税率改定日３の終了日が不正です。";
                    // 2007.03.27  S.Koga  amend ------------------------------------------
					//control = TaxRateEndDate_tDateEdit;
                    control = TaxRateEndDate3_tDateEdit;
                    // --------------------------------------------------------------------
                    return false;
				}

				//--有効日の大小チェック--//
				if (TaxRateStartDate3_tDateEdit.LongDate >= TaxRateEndDate3_tDateEdit.LongDate)
				{
					control = TaxRateStartDate3_tDateEdit;
					message = "税率改定日３の範囲が不正です。";
					return false;
				}

                // 2008.03.06 追加 >>>>>>>>>>>>>>>>>>>>
                //--有効日の重複チェック--//
                if ( (TaxRateEndDate_tDateEdit.LongDate   >= TaxRateStartDate3_tDateEdit.LongDate) ||
                    ((TaxRateStartDate_tDateEdit.LongDate >  TaxRateStartDate3_tDateEdit.LongDate) &&
                     (TaxRateEndDate3_tDateEdit.LongDate  >= TaxRateStartDate_tDateEdit.LongDate )))
                {
                    control = TaxRateStartDate3_tDateEdit;
                    message = "税率改定日３の範囲が税率改定日１の範囲と重複してます。";
                    return false;
                }
                if ( (TaxRateEndDate2_tDateEdit.LongDate   >= TaxRateStartDate3_tDateEdit.LongDate) ||
                    ((TaxRateStartDate2_tDateEdit.LongDate >  TaxRateStartDate3_tDateEdit.LongDate) &&
                     (TaxRateEndDate3_tDateEdit.LongDate   >= TaxRateStartDate2_tDateEdit.LongDate)))
                {
                    control = TaxRateStartDate3_tDateEdit;
                    message = "税率改定日３の範囲が税率改定日２の範囲と重複してます。";
                    return false;
                }
                // 2008.03.06 追加 <<<<<<<<<<<<<<<<<<<<
            }

            //-----ADD 鄭慕鈞 2014/02/18 Redmine#42120 税率設定マスタにチェックを追加する----->>>>>
            // 税金改定日２もしくは税率２のいづれかが入力されていた場合
            if ((this.TaxRate2_tNedit.GetValue() != 0) ||
                (this.TaxRateStartDate2_tDateEdit.LongDate != 0) ||
                (this.TaxRateEndDate2_tDateEdit.LongDate != 0))
            {
                //税率改定日で期間1と期間2の間に空白がある
                if (TaxRateStartDate2_tDateEdit.GetDateTime() > TaxRateEndDate_tDateEdit.GetDateTime().AddDays(1))
                {
                    control = TaxRateStartDate2_tDateEdit;
                    message = "税率改定日１と税率改定日２の間に空白期間があります。空白期間が無いように設定して下さい。";
                    return false;
                }
            }
            //税金改定日３もしくは税率３のいづれかが入力されていた場合
            if ((this.TaxRate3_tNedit.GetValue() != 0) ||
                (this.TaxRateStartDate3_tDateEdit.LongDate != 0) ||
                (this.TaxRateEndDate3_tDateEdit.LongDate != 0))
            {
                //税金改定日２もしくは税率２のいづれかが入力されていた場合
                if ((this.TaxRate2_tNedit.GetValue() != 0) ||
                (this.TaxRateStartDate2_tDateEdit.LongDate != 0) ||
                (this.TaxRateEndDate2_tDateEdit.LongDate != 0))
                {
                    //税率改定日で期間2と期間3の間に空白がある
                    if (TaxRateStartDate3_tDateEdit.GetDateTime() > TaxRateEndDate2_tDateEdit.GetDateTime().AddDays(1))
                    {
                        control = TaxRateStartDate3_tDateEdit;
                        message = "税率改定日２と税率改定日３の間に空白期間があります。空白期間が無いように設定して下さい。";
                        return false;
                    }
                }
                else
                {
                    //税率改定日で期間1と期間3の間に空白がある
                    if (TaxRateStartDate3_tDateEdit.GetDateTime() > TaxRateEndDate_tDateEdit.GetDateTime().AddDays(1))
                    {
                        control = TaxRateStartDate3_tDateEdit;
                        message = "税率改定日１と税率改定日３の間に空白期間があります。空白期間が無いように設定して下さい。";
                        return false;
                    }
                }
            }
            //-----ADD 鄭慕鈞 2014/02/18 Redmine#42120 税率設定マスタにチェックを追加する-----<<<<<
			
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
		/// 税率保存処理
		/// </summary>
		/// <returns>登録結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 税率登録を行います。</br>
		/// <br>Programmer : 21041　中村　健</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		private bool SaveTaxRateSet()
		{
			Control control = null;
			string message = null;

			if (!ScreenDataCheck(ref control, ref message))
			{
				//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
				TMsgDisp.Show(this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					pgId,
					message,
					0,
					MessageBoxButtons.OK);
				//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//				MessageBox.Show(
//					message,
//					"入力チェック",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Exclamation,
//					MessageBoxDefaultButton.Button1);

				control.Focus();
				return false;
			}

			TaxRateSet taxrateset = null;
            // 2008.06.03 30413 犬飼 シングルタイプに変更 >>>>>>START
            // マルチタイプ時のリスト選択インデックスでは更新処理が行えない為、
            // 比較用クローンから画面情報以外を設定する
            //if (this.DataIndex >= 0)
			//{
				//Guid guid = (Guid)this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[this._dataIndex][GUID_TITLE];
				//taxrateset = ((TaxRateSet)this._taxratesetTable[guid]).Clone();
			//}
            taxrateset = this._taxRateSetClone.Clone();
            // 2008.06.03 30413 犬飼 シングルタイプに変更 <<<<<<End
			
			DispToTaxrateset(ref taxrateset);
            
			int status = this._taxratesetAcs.Write(ref taxrateset);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						pgId,
						"この税率コードは既に使用されています。",
						0,
						MessageBoxButtons.OK);
					//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//					MessageBox.Show(
//						"この税率コードは既に使用されています。",
//						"情報",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Information,
//						MessageBoxDefaultButton.Button1);
					return false;
				}
                //2005.07.06 排他制御対応　三橋>>>>>START
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{

					//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						pgId,
						"既に他端末より更新されています",
						status,
						MessageBoxButtons.OK);
					//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
                    //2005.07.12 排他制御コメント変更　三橋>>>>>START
//					MessageBox.Show(
//						"既に他端末より更新されています",
//						"注意",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Exclamation,
//						MessageBoxDefaultButton.Button1);
					//MessageBox.Show(
					//	"既に他端末で削除されています",
					//	"注意",
					//	MessageBoxButtons.OK,
					//	MessageBoxIcon.Exclamation,
					//	MessageBoxDefaultButton.Button1);
                    //2005.07.12 排他制御コメント変更　三橋<<<<<<END

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
					//2005.09.17 enokida 変更 MessageBox対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_STOP,
						pgId,
						pgNm,
						"SaveTaxRateSet",
						TMsgDisp.OPE_UPDATE,
						"登録に失敗しました。",
						status,
						obj,
						MessageBoxButtons.OK,
						MessageBoxDefaultButton.Button1);
					//2005.09.17 enokida 変更 MessageBox対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//					MessageBox.Show(
//						"登録に失敗しました。 st = " + status.ToString(),
//						"エラー",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
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
				//default:
				//{
				//	MessageBox.Show(
				//		"登録に失敗しました。 st = " + status.ToString(),
				//		"エラー",
				//		MessageBoxButtons.OK,
				//		MessageBoxIcon.Error,
				//		MessageBoxDefaultButton.Button1);
				//	return false;
				//}
                //2005.07.06 排他制御対応　三橋<<<<<<END

			}

			TaxratesetToDataSet(taxrateset, this.DataIndex);

			return true;
		}
		# endregion

		#region Control Events
		/// <summary>
		/// Form.Load イベント(SFUKK09000UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer  : 21041　中村　健</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void SFUKK09000UA_Load(object sender, System.EventArgs e)
		{
            // ↓ 20070206 18322 a MA.NS用に変更
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            // ↑ 20070206 18322 a

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
        /// Form.Closing イベント(SFUKK09000UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note　　　  : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
		/// <br>Programmer  : 21041　中村　健</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void SFUKK09000UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{

            //2005.07.02  フレームの最小化対応改良　三橋>>>>>>STRAT
			this._indexBuf = -2;
			//// 2005.05.27 TOUMA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//// 最小化判定フラグの初期化
			//this._minFlg = false;
			//// 2005.05.27 TOUMA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            //2005.07.02  フレームの最小化対応改良　三橋<<<<<<END

			// フォームの「×」をクリックされた場合の対応です。
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
        /// Control.VisibleChanged イベント(SFUKK09000UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
		/// <br>Programmer  : 21041　中村　健</br>
		/// <br>Date        : 2005.05.06</br>
		/// </remarks>
		private void SFUKK09000UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				//2005.10.19 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
				// メインフレームアクティブ化
				this.Owner.Activate();
				//2005.10.19 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
				return;
			}

            //2005.07.02  フレームの最小化対応改良　三橋>>>>>>START
			// 自分自身が非表示になった場合、
			// またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}
			//// 2005.05.27 TOUMA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//if (this._minFlg == false)
		    //{
			//	// キー情報の初期化
			//	this.TaxRateProperNounNm_tEdit.Clear();
			//}														  

			// 新規モード以外の場合
			//if(this._dataIndex >= 0)
			//{
			//	// フレームで選択されているレコードのGUIDを取得
			//	Guid guid = (Guid)this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[this._dataIndex][GUID_TITLE];
			//	// 上記のレコードをクラスにセット
			//	TaxRateSet taxRateSet = (TaxRateSet)this._taxratesetTable[guid];
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
			//// 2005.05.27 TOUMA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            //2005.07.02  フレームの最小化対応改良　三橋<<<<<<END
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
            // 税率登録処理
			if (SaveTaxRateSet() == false)
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
				this.TaxRateProperNounNm_tEdit.Focus();
				// クローンを再度取得する
				TaxRateSet newTaxRateSet = new TaxRateSet();
				//クローン作成
				this._taxRateSetClone = newTaxRateSet.Clone(); 
				DispToTaxrateset( ref this._taxRateSetClone);

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

                //2005.07.02　フレームの最小化対応改良　三橋>>>>>>START
				this._indexBuf = -2;
				//// 2005.05.27 TOUMA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				//// 最小化判定フラグの初期化
				//this._minFlg = false;
				//// 2005.05.27 TOUMA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
                //2005.07.02  フレームの最小化対応改良　三橋<<<<<<END
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
            // 2008.06.03 30413 犬飼 登録後に画面に変更が反映されない点を修正 >>>>>>START
            DialogResult res = DialogResult.Cancel;
            // 2008.06.03 30413 犬飼 登録後に画面に変更が反映されない点を修正 <<<<<<END

			// 削除モード・参照モード以外の場合は保存確認処理を行う
			if (this.Mode_Label.Text != DELETE_MODE)
			{
				//保存確認
				TaxRateSet compareTaxRateSet = new TaxRateSet();
				compareTaxRateSet = this._taxRateSetClone.Clone();  

				//現在の画面情報を取得する
				DispToTaxrateset( ref compareTaxRateSet);
				//最初に取得した画面情報と比較
				if (!(this._taxRateSetClone.Equals(compareTaxRateSet)))	
				{
					//画面情報が変更されていた場合は、保存確認メッセージを表示する
					//DialogResult res = MessageBox.Show("編集中のデータが存在します"+"\r\n"+"\r\n"+"登録してもよろしいですか？","保存確認",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);

					//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
                    // 2008.06.03 30413 犬飼 登録後に画面に変更が反映されない点を修正 >>>>>>START
					//DialogResult res = TMsgDisp.Show(this,
					//	emErrorLevel.ERR_LEVEL_SAVECONFIRM,
					//	pgId,
					//	"",
					//	0,
					//	MessageBoxButtons.YesNoCancel);
                    res = TMsgDisp.Show(this,
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                        pgId,
                        "",
                        0,
                        MessageBoxButtons.YesNoCancel);
                    // 2008.06.03 30413 犬飼 登録後に画面に変更が反映されない点を修正 <<<<<<END
					//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
					switch(res)
					{
						case DialogResult.Yes:
						{
							// 税率登録処理
							if (SaveTaxRateSet() ==false)
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
                // TODO Cancelの場合、登録後に画面に変更が反映されていない。OKだと反映される。
                // 2008.06.03 30413 犬飼 登録後に画面に変更が反映されない点を修正 >>>>>>START
				//MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(res);
                // 2008.06.03 30413 犬飼 登録後に画面に変更が反映されない点を修正 <<<<<<END
				UnDisplaying(this, me);
			}

            //2005.07.02  フレームの最小化対応改良　三橋>>>>>START
			//// 2005.05.27 TOUMA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//// 最小化判定フラグの初期化
			//this._minFlg = false;
			//// 2005.05.27 TOUMA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			//this.DialogResult = DialogResult.Cancel;
            // 2008.06.03 30413 犬飼 登録後に画面に変更が反映されない点を修正 >>>>>>START
            //this.DialogResult = DialogResult.Cancel;
            this.DialogResult = res;
            // 2008.06.03 30413 犬飼 登録後に画面に変更が反映されない点を修正 <<<<<<END
            this._indexBuf = -2;
            //2005.07.02  フレームの最小化対応改良　三橋<<<<<<END
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
			//2005.09.17 Message部品対応 変更 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
			DialogResult result = TMsgDisp.Show(this,
				emErrorLevel.ERR_LEVEL_QUESTION,
				pgId,
				"データを削除します。" + "\r\n" + "よろしいですか？",
				0,
				MessageBoxButtons.OKCancel,
				MessageBoxDefaultButton.Button2);
			//2005.09.17 Message部品対応 変更 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//			DialogResult result = MessageBox.Show(
//				"データを削除します。" + "\r\n" + "よろしいですか？",
//				"削除確認",
//				MessageBoxButtons.OKCancel,
//				MessageBoxIcon.Exclamation,
//				MessageBoxDefaultButton.Button2);

			if (result == DialogResult.OK)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[this._dataIndex][GUID_TITLE];
				TaxRateSet taxrateset = (TaxRateSet)this._taxratesetTable[guid];

				int status = this._taxratesetAcs.Delete(taxrateset);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[this.DataIndex].Delete();
						this._taxratesetTable.Remove(taxrateset.FileHeaderGuid);

						break;
					}
					default:
					{
						//2005.09.17 enokida 変更 MessageBox対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
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
						//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

//						MessageBox.Show(
//							"削除に失敗しました。 st = " + status.ToString(),
//							"エラー",
//							MessageBoxButtons.OK,
//							MessageBoxIcon.Error,
//							MessageBoxDefaultButton.Button1);
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

            //2005.07.02  フレームの最小化対応改良　三橋>>>>>>START
			this._indexBuf = -2;
            //2005.07.02  フレームの最小化対応改良　三橋<<<<<<END
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
			Guid guid = (Guid)this.Bind_DataSet.Tables[TAXRATESET_TABLE].Rows[this._dataIndex][GUID_TITLE];
			TaxRateSet taxrateset = (TaxRateSet)_taxratesetTable[guid];

			int status = this._taxratesetAcs.Revival(ref taxrateset);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					
					//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< start
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						pgId,
						"既にデータが完全削除されています。" ,
						status,
						MessageBoxButtons.OK);
					//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

//					MessageBox.Show(
//						"既にデータが完全削除されています。" + status.ToString(),
//						"情報",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Information,
//						MessageBoxDefaultButton.Button1);

					break;
				}
				default:
				{
					
					//2005.09.17 enokida 変更 MessageBox対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
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
					//2005.09.17 enokida 変更 MessageBox対応<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
//					MessageBox.Show(
//						"復活に失敗しました。 st = " + status.ToString(),
//						"エラー",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);

					break;
				}
			}

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
			}

			TaxratesetToDataSet(taxrateset, this.DataIndex);

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

            //2005.07.02  フレームの最小化対応改良　三橋>>>>>>START
			this._indexBuf = -2;
            //2005.07.02  フレームの最小化対応改良　三橋<<<<<<END

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
		// 2005.06.20 税率項目表示の最適化。 >>>> START
		private void TaxRate_tNedit_Leave(object sender, System.EventArgs e)
		{
			Double value = TaxRate_tNedit.GetValue();
			TaxRate_tNedit.Text = value.ToString("#0.0");		
		}

		private void TaxRate2_tNedit_Leave(object sender, System.EventArgs e)
		{
			Double value = TaxRate2_tNedit.GetValue();
			TaxRate2_tNedit.Text = value.ToString("#0.0");				
		}

		private void TaxRate3_tNedit_Leave(object sender, System.EventArgs e)
		{
			Double value = TaxRate3_tNedit.GetValue();
			TaxRate3_tNedit.Text = value.ToString("#0.0");						
		}
        // 2005.06.20 税率項目表示の最適化。 >>>> END

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
            titleList.Add(PROPERNOUNNM_TITLE);             // 税率固有名称
            titleList.Add(NAME_TITLE);    // 表示／印刷名称
            titleList.Add(FRACTION_TITLE);    // 消費税転嫁方式
            titleList.Add(TAXRATE1_UPDATE);     // 税率改定日１
            titleList.Add(this.TaxRate1_Label.Text);      // 税率１
            titleList.Add(TAXRATE2_UPDATE);    // 税率改定日２
            titleList.Add(this.TaxRate2_Label.Text);       // 税率２
            titleList.Add(TAXRATE3_UPDATE);       // 税率改定日３
            titleList.Add(this.TaxRate3_Label.Text);       // 税率３

            // 税率設定データ取得
            int status = 0;
            status = this._taxratesetAcs.Read(out this._prevTaxRateSet, this._enterpriseCode, TAXRATE_CODE_PUBLIC);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {

                        // 税率設定取得データ設定
                        if (this._prevTaxRateSet != null)
                        {
                            valueList.Add(this._prevTaxRateSet.TaxRateProperNounNm);
                            valueList.Add(this._prevTaxRateSet.TaxRateName);

                            // 消費税転嫁方式
                            string wrkstr;
                            switch (_prevTaxRateSet.ConsTaxLayMethod)
                            {
                                case 0:
                                    wrkstr = CONSTAXLAY_SLIP;       // "伝票単位"
                                    break;
                                case 1:
                                    wrkstr = CONSTAXLAY_DETAILS;    //"明細単位"
                                    break;
                                case 2:
                                    wrkstr = CONSTAXLAY_CLAIMPARENT;//"請求親"
                                    break;
                                case 3:
                                    wrkstr = CONSTAXLAY_CLAIMCHILD; //"請求子"
                                    break;
                                default:
                                    wrkstr = UNREGISTER;
                                    break;
                            }
                            valueList.Add(wrkstr);
                            valueList.Add(this._prevTaxRateSet.TaxRateStartDateAdFormal + HTML_PERIOD + this._prevTaxRateSet.TaxRateEndDateAdFormal);
                            valueList.Add(this._prevTaxRateSet.TaxRate.ToString("#0.0%"));
                            // 2008.09.25 30413 犬飼 税率改定日と税率を未設定時は空白に修正 >>>>>>START
                            //valueList.Add(this._prevTaxRateSet.TaxRateStartDate2AdFormal + HTML_PERIOD + this._prevTaxRateSet.TaxRateEndDate2AdFormal);
                            //valueList.Add(this._prevTaxRateSet.TaxRate2.ToString("#0.0%"));
                            //valueList.Add(this._prevTaxRateSet.TaxRateStartDate3AdFormal + HTML_PERIOD + this._prevTaxRateSet.TaxRateEndDate3AdFormal);
                            //valueList.Add(this._prevTaxRateSet.TaxRate3.ToString("#0.0%"));

                            // 税率改定日２ 開始日～終了日
                            if ((this._prevTaxRateSet.TaxRateStartDate2 != DateTime.MinValue) && (this._prevTaxRateSet.TaxRateEndDate2 != DateTime.MinValue))
                            {
                                // 開始日と終了日が両方とも設定されている
                                valueList.Add(this._prevTaxRateSet.TaxRateStartDate2AdFormal + HTML_PERIOD + this._prevTaxRateSet.TaxRateEndDate2AdFormal);
                            }
                            else
                            {
                                // 上記以外は空白
                                valueList.Add(UNREGISTER);
                            }

                            // 税率２
                            if (this._prevTaxRateSet.TaxRate2 != 0.0)
                            {
                                // 税率が設定されている
                                valueList.Add(this._prevTaxRateSet.TaxRate2.ToString("#0.0%"));
                            }
                            else
                            {
                                // 上記以外は空白
                                valueList.Add(UNREGISTER);
                            }
                            
                            // 税率改定日３ 開始日～終了日
                            if ((this._prevTaxRateSet.TaxRateStartDate3 != DateTime.MinValue) && (this._prevTaxRateSet.TaxRateEndDate3 != DateTime.MinValue))
                            {
                                // 開始日と終了日が両方とも設定されている
                                valueList.Add(this._prevTaxRateSet.TaxRateStartDate3AdFormal + HTML_PERIOD + this._prevTaxRateSet.TaxRateEndDate3AdFormal);
                            }
                            else
                            {
                                // 上記以外は空白
                                valueList.Add(UNREGISTER);
                            }

                            // 税率３
                            if (this._prevTaxRateSet.TaxRate3 != 0.0)
                            {
                                // 税率が設定されている
                                valueList.Add(this._prevTaxRateSet.TaxRate3.ToString("#0.0%"));
                            }
                            else
                            {
                                // 上記以外は空白
                                valueList.Add(UNREGISTER);
                            }
                            // 2008.09.25 30413 犬飼 税率改定日と税率を未設定時は空白に修正 <<<<<<END
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
                            this._taxratesetAcs,                  // エラーが発生したオブジェクト
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

        /// <summary>Control.ChangeFocus イベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : フォーカス移動時に発生します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.09.25</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            bool canChangeFocus = true;
            string message = "";

            switch (e.PrevCtrl.Name)
            {
                // 2008.10.03 30413 犬飼 フォーカス制御を変更 >>>>>>START
                case "ConsTaxLayMethod_tComboEditor":
                    {
                        if (e.Key == Keys.Down)
                        {
                            // ↓キーの場合は、税率改定日１の年に強制フォーカス移動
                            e.NextCtrl = null;
                            this.TaxRateStartDate_tDateEdit.Focus();                            
                        }
                        break;
                    }
                // 2008.10.03 30413 犬飼 フォーカス制御を変更 <<<<<<END
                case "TaxRateStartDate_tDateEdit":
                    {
                        // 税率改定日１(開始)
                        TDateEdit2 tDateEdit = e.PrevCtrl as TDateEdit2;
                        if ((tDateEdit.CheckInputData() != null) || !(CheckDateEffect(tDateEdit)))
                        {
                            message = this.TaxRateDate1_Label.Text + "の開始日が不正です。";
                            canChangeFocus = false;
                        }
                        break;
                    }
                case "TaxRateEndDate_tDateEdit":
                    {
                        // 税率改定日１(終了)
                        TDateEdit2 tDateEdit = e.PrevCtrl as TDateEdit2;
                        if ((tDateEdit.CheckInputData() != null) || !(CheckDateEffect(tDateEdit)))
                        {
                            message = this.TaxRateDate1_Label.Text + "の終了日が不正です。";
                            canChangeFocus = false;
                        }
                        // 2008.10.03 30413 犬飼 フォーカス制御を変更 >>>>>>START
                        else
                        {
                            if (e.Key == Keys.Down)
                            {
                                // ↓キーの場合は、税率１に強制フォーカス移動
                                e.NextCtrl = this.TaxRate_tNedit;
                            }
                        }
                        // 2008.10.03 30413 犬飼 フォーカス制御を変更 <<<<<<END
                        break;
                    }
                case "TaxRateStartDate2_tDateEdit":
                    {
                        // 税率改定日２(開始)
                        TDateEdit2 tDateEdit = e.PrevCtrl as TDateEdit2;
                        if ((tDateEdit.CheckInputData() != null) || !(CheckDateEffect(tDateEdit)))
                        {
                            message = this.TaxRateDate2_Label.Text + "の開始日が不正です。";
                            canChangeFocus = false;
                        }
                        break;
                    }
                case "TaxRateEndDate2_tDateEdit":
                    {
                        // 税率改定日２(終了)
                        TDateEdit2 tDateEdit = e.PrevCtrl as TDateEdit2;
                        if ((tDateEdit.CheckInputData() != null) || !(CheckDateEffect(tDateEdit)))
                        {
                            message = this.TaxRateDate2_Label.Text + "の終了日が不正です。";
                            canChangeFocus = false;
                        }
                        // 2008.10.03 30413 犬飼 フォーカス制御を変更 >>>>>>START
                        else
                        {
                            if (e.Key == Keys.Down)
                            {
                                // ↓キーの場合は、税率２に強制フォーカス移動
                                e.NextCtrl = this.TaxRate2_tNedit;
                            }
                        }
                        // 2008.10.03 30413 犬飼 フォーカス制御を変更 <<<<<<END
                        break;
                    }
                case "TaxRateStartDate3_tDateEdit":
                    {
                        // 税率改定日３(開始)
                        TDateEdit2 tDateEdit = e.PrevCtrl as TDateEdit2;
                        if ((tDateEdit.CheckInputData() != null) || !(CheckDateEffect(tDateEdit)))
                        {
                            message = this.TaxRateDate3_Label.Text + "の開始日が不正です。";                            
                            canChangeFocus = false;
                        }
                        break;
                    }
                case "TaxRateEndDate3_tDateEdit":
                    {
                        // 税率改定日３(終了)
                        TDateEdit2 tDateEdit = e.PrevCtrl as TDateEdit2;
                        if ((tDateEdit.CheckInputData() != null) || !(CheckDateEffect(tDateEdit)))
                        {
                            message = this.TaxRateDate3_Label.Text + "の終了日が不正です。";
                            canChangeFocus = false;
                        }
                        // 2008.10.03 30413 犬飼 フォーカス制御を変更 >>>>>>START
                        else
                        {
                            if (e.Key == Keys.Down)
                            {
                                // ↓キーの場合は、税率３に強制フォーカス移動
                                e.NextCtrl = this.TaxRate3_tNedit;
                            }
                        }
                        // 2008.10.03 30413 犬飼 フォーカス制御を変更 <<<<<<END
                        break;
                    }
            }

            // フォーカス制御
            if (canChangeFocus == false)
            {
                if (message != "")
                {
                    // エラーメッセージがあれば表示
                    TMsgDisp.Show(this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                pgId,
                                message,
                                0,
                                MessageBoxButtons.OK);
                }

                e.NextCtrl = e.PrevCtrl;

                // 現在の項目から移動せず、テキスト全選択状態とする
                e.NextCtrl.Select();
            }
        }
    }
}