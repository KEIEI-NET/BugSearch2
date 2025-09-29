//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : ユーザーガイド設定マスタ
// プログラム概要   : ユーザーガイド設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三崎 貴史
// 作 成 日  2005/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三崎 貴史
// 修 正 日  2006/07/24  修正内容 : フォームプロパティ設定（ブラッシュアップ1-28）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三崎 貴史
// 修 正 日  2006/07/28  修正内容 : ソースもブラッシュアップ！
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 行澤 仁美
// 修 正 日  2008/10/07  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号  9807        作成担当 : 忍 幸史
// 修 正 日  2009/01/09  修正内容 : 初期表示位置の演算コードを削除
//----------------------------------------------------------------------------//
// 管理番号  9995        作成担当 : 忍 幸史
// 修 正 日  2008/01/13  修正内容 : 「削除済データの表示」は最上位項目で制御
//----------------------------------------------------------------------------//
// 管理番号  12691       作成担当 : 工藤　恵優
// 修 正 日  2009/03/24  修正内容 : 「削除済データの表示」は最上位項目で制御
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 修 正 日  2010/04/21  修正内容 :  ガイド区分「４６：銀行」時の登録画面へ「支店コード」の追加を行う
//----------------------------------------------------------------------------//
# region using
#define DELETE_DATE_DEPEND_ON_SUB_TABLE // メインテーブルの削除日をサブテーブルに関連させるフラグ

using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Common;
# endregion

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ユーザーガイド設定 入力フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: ユーザーガイドの設定を行います。
	///					  IMasterMaintenanceArrayTypeを実装しています。</br>
	/// <br>Programmer	: 22033 三崎  貴史</br>
	/// <br>Date		: 2005.05.13</br>
	/// <br>UpdateNote	: 2006.07.24 22033 三崎  貴史</br>
	/// <br>			: ・フォームプロパティ設定（ブラッシュアップ1-28）</br>
	/// <br>UpdateNote	: 2006.07.28 22033 三崎  貴史</br>
	/// <br>			: ・ソースもブラッシュアップ！</br>
    /// <br>UpdateNote   : 2008/10/07 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote   : 2009/01/09 30414 忍 幸史　障害ID:9807対応</br>
    /// <br>UpdateNote   : 2009/01/13 30414 忍 幸史　障害ID:9995対応</br>
    /// <br>UpdateNote   : 2009/03/24 30434 工藤 恵優　障害ID:12691対応</br>
    /// <br>UpdateNote   : 2010/04/21 張義 PM1007</br>
    /// <br>             : ガイド区分「４６：銀行」時の登録画面へ「支店コード」の追加を行う</br>
	/// </remarks>
	public class SFCMN09060UA : System.Windows.Forms.Form, IMasterMaintenanceArrayType
	{
		# region regionマーク定義説明
		//------------------------------//
		//   ■：大分類					//
		//	 ▼：中分類					//
		//	 ●：小分類					//
		//	 ※：触るなよ(;ﾟдﾟ)ｱｯ....	//
		//------------------------------//
		# endregion

		# region ※Private Members (Component)

		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Data.DataSet Bind_DataSet;
		private System.Data.DataSet Details_DataSet;
		private Infragistics.Win.Misc.UltraLabel GuideCode_uLabel;
		private Infragistics.Win.Misc.UltraLabel GuideName_uLabel;
		private Infragistics.Win.Misc.UltraLabel GuideType_uLabel;
		private Broadleaf.Library.Windows.Forms.TNedit GuideCode_tNedit;
		private Infragistics.Win.Misc.UltraLabel GuideDivCode_uLabel;
		private Broadleaf.Library.Windows.Forms.TNedit GuideDivCode_tNedit;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Broadleaf.Library.Windows.Forms.TNedit GuideType_tNedit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel17;
		private Broadleaf.Library.Windows.Forms.TEdit GuideName_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit GuideDivName_tEdit;
		private Infragistics.Win.Misc.UltraLabel GuideDivName_uLabel;
        private Infragistics.Win.Misc.UltraLabel BranchCode_ultraLabel;
        private TNedit BranchCode_tNedit;
		private System.ComponentModel.IContainer components;

		# endregion

		# region ■Constructor
		/// <summary>
		/// ユーザーガイド設定入力フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : ユーザーガイド設定入力フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public SFCMN09060UA()
		{
			// コンポーネント初期化
			this.InitializeComponent();
			// フレームグリッドBindデータセット 列情報構築処理
			this.DataSetColumnConstruction();

			// プロパティ初期値設定 -------------------------------------------------------------------------
			this._canPrint					= false;						// 印刷ボタン
			this._canClose					= true;							// 閉じるボタン
			this._canNew					= true;							// 新規ボタン
			this._canDelete					= true;							// 削除ボタン
			this._mainGridTitle				= MAINGRID_TITLE;				// フレーム_MainGrid_Title
			this._detailsGridTitle			= DETAILGRID_TITLE;				// フレーム_DetailGrid_Title
			this._defaultGridDisplayLayout	= MGridDisplayLayout.Vertical;	// フレームグリッド_DisplayLayout
			//------------------------------------------------------------------------------------------------

			// Private Member初期化/取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._targetTableName = "";
			this._mainDataIndex = -1;
			this._detailsDataIndex = -1;
			this._userGuideAcs = new UserGuideAcs();
			this._userGuideHTable = new Hashtable();
			this._userGuideMTable = new Hashtable();
			this._mainIndexBuf = -2;		// -1は未選択なので-2で初期化
			this._detailsIndexBuf = -2;		// -1は未選択なので-2で初期化	
			this._mainGridIcon = null;		// グリッドアイコンはいらないっぽい？
			this._detailsGridIcon = null;	// グリッドアイコンはいらないっぽい？
		}
		# endregion

		# region ※Dispose
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

		#region ※Windows フォーム デザイナで生成されたコード
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN09060UA));
            this.GuideCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.GuideName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.GuideType_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.GuideCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.GuideDivCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Details_DataSet = new System.Data.DataSet();
            this.Bind_DataSet = new System.Data.DataSet();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.GuideDivCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.GuideType_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.GuideName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GuideDivName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GuideDivName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BranchCode_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BranchCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Details_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideDivCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideType_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideDivName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchCode_tNedit)).BeginInit();
            this.SuspendLayout();
            // 
            // GuideCode_uLabel
            // 
            this.GuideCode_uLabel.Location = new System.Drawing.Point(12, 119);
            this.GuideCode_uLabel.Name = "GuideCode_uLabel";
            this.GuideCode_uLabel.Size = new System.Drawing.Size(104, 23);
            this.GuideCode_uLabel.TabIndex = 0;
            this.GuideCode_uLabel.Text = "ガイドコード";
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 230);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(648, 23);
            this.ultraStatusBar1.TabIndex = 1;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // GuideName_uLabel
            // 
            this.GuideName_uLabel.Location = new System.Drawing.Point(12, 151);
            this.GuideName_uLabel.Name = "GuideName_uLabel";
            this.GuideName_uLabel.Size = new System.Drawing.Size(85, 23);
            this.GuideName_uLabel.TabIndex = 2;
            this.GuideName_uLabel.Text = "ガイド名";
            // 
            // GuideType_uLabel
            // 
            this.GuideType_uLabel.Location = new System.Drawing.Point(295, 42);
            this.GuideType_uLabel.Name = "GuideType_uLabel";
            this.GuideType_uLabel.Size = new System.Drawing.Size(64, 23);
            this.GuideType_uLabel.TabIndex = 3;
            this.GuideType_uLabel.Text = "タイプ";
            this.GuideType_uLabel.Visible = false;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(535, 8);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 10;
            this.Mode_Label.Text = "更新モード";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(507, 183);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 8;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(379, 183);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 7;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // GuideCode_tNedit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance12.TextHAlignAsString = "Right";
            this.GuideCode_tNedit.ActiveAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance13.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            appearance13.TextHAlignAsString = "Right";
            this.GuideCode_tNedit.Appearance = appearance13;
            this.GuideCode_tNedit.AutoSelect = true;
            this.GuideCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.GuideCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GuideCode_tNedit.DataText = "";
            this.GuideCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GuideCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.GuideCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GuideCode_tNedit.Location = new System.Drawing.Point(135, 116);
            this.GuideCode_tNedit.MaxLength = 4;
            this.GuideCode_tNedit.Name = "GuideCode_tNedit";
            this.GuideCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.GuideCode_tNedit.Size = new System.Drawing.Size(44, 24);
            this.GuideCode_tNedit.TabIndex = 3;
            // 
            // GuideDivCode_uLabel
            // 
            this.GuideDivCode_uLabel.Location = new System.Drawing.Point(12, 42);
            this.GuideDivCode_uLabel.Name = "GuideDivCode_uLabel";
            this.GuideDivCode_uLabel.Size = new System.Drawing.Size(88, 23);
            this.GuideDivCode_uLabel.TabIndex = 17;
            this.GuideDivCode_uLabel.Text = "ガイド区分";
            // 
            // Details_DataSet
            // 
            this.Details_DataSet.DataSetName = "NewDataSet";
            this.Details_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
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
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // GuideDivCode_tNedit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.GuideDivCode_tNedit.ActiveAppearance = appearance10;
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Right";
            this.GuideDivCode_tNedit.Appearance = appearance11;
            this.GuideDivCode_tNedit.AutoSelect = true;
            this.GuideDivCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GuideDivCode_tNedit.DataText = "";
            this.GuideDivCode_tNedit.Enabled = false;
            this.GuideDivCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GuideDivCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.GuideDivCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GuideDivCode_tNedit.Location = new System.Drawing.Point(135, 38);
            this.GuideDivCode_tNedit.MaxLength = 4;
            this.GuideDivCode_tNedit.Name = "GuideDivCode_tNedit";
            this.GuideDivCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.GuideDivCode_tNedit.Size = new System.Drawing.Size(44, 24);
            this.GuideDivCode_tNedit.TabIndex = 0;
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(379, 183);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 7;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(251, 183);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 6;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // GuideType_tNedit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GuideType_tNedit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            this.GuideType_tNedit.Appearance = appearance9;
            this.GuideType_tNedit.AutoSelect = true;
            this.GuideType_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.GuideType_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GuideType_tNedit.DataText = "";
            this.GuideType_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GuideType_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.GuideType_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GuideType_tNedit.Location = new System.Drawing.Point(359, 37);
            this.GuideType_tNedit.MaxLength = 2;
            this.GuideType_tNedit.Name = "GuideType_tNedit";
            this.GuideType_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.GuideType_tNedit.Size = new System.Drawing.Size(28, 24);
            this.GuideType_tNedit.TabIndex = 1;
            this.GuideType_tNedit.Visible = false;
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(12, 105);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(624, 3);
            this.ultraLabel17.TabIndex = 148;
            // 
            // GuideName_tEdit
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GuideName_tEdit.ActiveAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            this.GuideName_tEdit.Appearance = appearance7;
            this.GuideName_tEdit.AutoSelect = true;
            this.GuideName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.GuideName_tEdit.DataText = "";
            this.GuideName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GuideName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GuideName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.GuideName_tEdit.Location = new System.Drawing.Point(135, 148);
            this.GuideName_tEdit.MaxLength = 30;
            this.GuideName_tEdit.Name = "GuideName_tEdit";
            this.GuideName_tEdit.Size = new System.Drawing.Size(496, 24);
            this.GuideName_tEdit.TabIndex = 5;
            // 
            // GuideDivName_tEdit
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GuideDivName_tEdit.ActiveAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.GuideDivName_tEdit.Appearance = appearance5;
            this.GuideDivName_tEdit.AutoSelect = true;
            this.GuideDivName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.GuideDivName_tEdit.DataText = "";
            this.GuideDivName_tEdit.Enabled = false;
            this.GuideDivName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GuideDivName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GuideDivName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.GuideDivName_tEdit.Location = new System.Drawing.Point(135, 71);
            this.GuideDivName_tEdit.MaxLength = 30;
            this.GuideDivName_tEdit.Name = "GuideDivName_tEdit";
            this.GuideDivName_tEdit.Size = new System.Drawing.Size(496, 24);
            this.GuideDivName_tEdit.TabIndex = 2;
            // 
            // GuideDivName_uLabel
            // 
            this.GuideDivName_uLabel.Location = new System.Drawing.Point(12, 75);
            this.GuideDivName_uLabel.Name = "GuideDivName_uLabel";
            this.GuideDivName_uLabel.Size = new System.Drawing.Size(117, 23);
            this.GuideDivName_uLabel.TabIndex = 151;
            this.GuideDivName_uLabel.Text = "ガイド区分名";
            // 
            // BranchCode_ultraLabel
            // 
            this.BranchCode_ultraLabel.Location = new System.Drawing.Point(204, 119);
            this.BranchCode_ultraLabel.Name = "BranchCode_ultraLabel";
            this.BranchCode_ultraLabel.Size = new System.Drawing.Size(85, 23);
            this.BranchCode_ultraLabel.TabIndex = 153;
            this.BranchCode_ultraLabel.Text = "支店コード";
            // 
            // BranchCode_tNedit
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.TextHAlignAsString = "Right";
            this.BranchCode_tNedit.ActiveAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            this.BranchCode_tNedit.Appearance = appearance3;
            this.BranchCode_tNedit.AutoSelect = true;
            this.BranchCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BranchCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.BranchCode_tNedit.DataText = "";
            this.BranchCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BranchCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.BranchCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.BranchCode_tNedit.Location = new System.Drawing.Point(295, 116);
            this.BranchCode_tNedit.MaxLength = 3;
            this.BranchCode_tNedit.Name = "BranchCode_tNedit";
            this.BranchCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.BranchCode_tNedit.Size = new System.Drawing.Size(36, 24);
            this.BranchCode_tNedit.TabIndex = 4;
            // 
            // SFCMN09060UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(648, 253);
            this.Controls.Add(this.BranchCode_tNedit);
            this.Controls.Add(this.BranchCode_ultraLabel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.GuideDivName_tEdit);
            this.Controls.Add(this.GuideDivName_uLabel);
            this.Controls.Add(this.GuideName_tEdit);
            this.Controls.Add(this.GuideType_tNedit);
            this.Controls.Add(this.GuideDivCode_tNedit);
            this.Controls.Add(this.GuideCode_tNedit);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.GuideDivCode_uLabel);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.GuideType_uLabel);
            this.Controls.Add(this.GuideName_uLabel);
            this.Controls.Add(this.GuideCode_uLabel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFCMN09060UA";
            this.Text = "ユーザーガイド設定";
            this.Load += new System.EventHandler(this.SFCMN09060UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFCMN09060UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFCMN09060UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.GuideCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Details_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideDivCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideType_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuideDivName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BranchCode_tNedit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region ■Private Members
		/// <summary>ユーザーガイド設定 アクセスクラス</summary>
		private UserGuideAcs _userGuideAcs;
		/// <summary>企業コード</summary>
		private string _enterpriseCode;
		/// <summary>フレームBindDataSet用Hashtable_ユーザーガイド（ヘッダ）</summary>
		private Hashtable _userGuideHTable;
		/// <summary>フレームBindDataSet用Hashtable_ユーザーガイド（ボディ）</summary>
		/// <remarks>提供とユーザーをアクセスクラスでマージ済です。</remarks>
		private Hashtable _userGuideMTable;
		/// <summary>編集チェック用Buffer</summary>
		private UserGdBd _userGdBdClone;
		/// <summary>フレームMainGrid_Index_Buffer（フレーム最小化対応用）</summary>
		private int _mainIndexBuf;
		/// <summary>フレームDetailGrid_Index_Buffer（フレーム最小化対応用）</summary>
		private int _detailsIndexBuf;

        // 2009.03.26 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.26 30413 犬飼 新規モードからモード変更対応 <<<<<<END

		# region ▼IMasterMaintenanceArrayType用

		# region ●プロパティ用
		/// <summary>印刷ボタンVisible</summary>
		private bool _canPrint;
		/// <summary>閉じるボタンVisible</summary>
		private bool _canClose;
		/// <summary>新規ボタンVisible</summary>
		private bool _canNew;
		/// <summary>削除ボタンVisible</summary>
		private bool _canDelete;
		/// <summary>フレームMainGridタイトル</summary>
		private string _mainGridTitle;
		/// <summary>フレームDetailGridタイトル</summary>
		private string _detailsGridTitle;
		/// <summary>フレーム選択DataTable名</summary>
		private string _targetTableName;
		# endregion

		# region ●メソッド用
		/// <summary>フレームMainGrid_Index</summary>
		private int _mainDataIndex;
		/// <summary>フレームDetailGrid_Index</summary>
		private int _detailsDataIndex;
		/// <summary>フレームMainGrid_Icon</summary>
		private Image _mainGridIcon;
		/// <summary>フレームDetailGrid_Icon</summary>
		private Image _detailsGridIcon;
		/// <summary>フレームGrid_DisplayLayout</summary>
		private MGridDisplayLayout _defaultGridDisplayLayout;

		# endregion

		# endregion
		
		# endregion

		# region ■Consts

		# region ▼フレームのグリッドタイトル
		/// <summary>フレーム_MainGrid_Title</summary>
		private const string MAINGRID_TITLE	= "区分";
		/// <summary>フレーム_DetailGrid_Title</summary>
		private const string DETAILGRID_TITLE = "コード";
		# endregion

        // --- ADD 2010.04.21 START 張義 ---------->>>>>
        /// <summary>ラベル名称:ガイドコード</summary>
        private const string GUIDECODE_ULABEL = "ガイドコード";
        /// <summary>ラベル名称:ガイド名</summary>
        private const string GUIDENAME_ULABEL = "ガイド名";
        /// <summary>ラベル名称:銀行コード</summary>
        private const string BANKCODE_ULABEL = "銀行コード";
        /// <summary>ラベル名称:銀行名</summary>
        private const string BANKNAME_ULABEL = "銀行名";
        // --- ADD 2010.04.21 END 張義 ----------<<<<<

		# region ▼フレームグリッドのDataTble名称
		/// <summary>フレームMainGrid_DataTable名称</summary>
		private const string TABLENAME_USERGDHD_TABLE = "USERGDHD";
		/// <summary>フレームDetailGrid_DataTable名称</summary>
		private const string TABLENAME_USERGDBD_TABLE = "USERGDBD";
		# endregion

		# region ▼フレームGrid列のKEY情報 (ヘッダのタイトル部となります)

		# region ●MainGrid
		/// <summary>フレームGrid列_Key_ガイド区分（Main/Detail共通）</summary>
		private const string COLUMNNAME_MD_GUIDEDIVCODE = "ガイド区分";
		/// <summary>フレームMainGrid列_Key_ガイド区分名称</summary>
		private const string COLUMNNAME_MAIN_GUIDEDIVNAME = "ガイド区分名";
		/// <summary>フレームMainGrid列_Key_マスタ提供区分コード</summary>
		private const string COLUMNNAME_MAIN_MASTEROFFERCD = "マスタ提供区分コード";
		/// <summary>フレームMainGrid列_Key_マスタ提供区分</summary>
		private const string COLUMNNAME_MAIN_MASTEROFFERNM = "マスタ提供区分";
		# endregion

		# region ●DetaiGrid
		/// <summary>フレームDetailGrid列_Key_削除日</summary>
		private const string COLUMNNAME_DETAIL_DELETEDATE = "削除日";
		/// <summary>フレームDetailGrid列_Key_ガイドコード</summary>
		private const string COLUMNNAME_DETAIL_GUIDECODE = "ガイドコード";
		/// <summary>フレームDetailGrid列_Key_ガイド名称</summary>
		private const string COLUMNNAME_DETAIL_GUIDENAME = "ガイド名";
		/// <summary>フレームDetailGrid列_Key_ガイドタイプ</summary>
		private const string COLUMNNAME_DETAIL_GUIDETYPE = "ガイドタイプ";
		# endregion

		# endregion

		# region ▼編集モード
		/// <summary>新規モード</summary>
		private const string INSERT_MODE = "新規モード";
		/// <summary>更新モード</summary>
		private const string UPDATE_MODE = "更新モード";
		/// <summary>削除モード</summary>
		private const string DELETE_MODE = "削除モード";
		/// <summary>参照モード</summary>
		private const string REFER_MODE	= "参照モード";
		# endregion

		# region ▼メッセージボックス関連
		/// <summary>アセンブリID</summary>
		private const string ASSEMBLY_ID = "SFCMN09060U";
		/// <summary>メッセージ_エラー_読込</summary>
		private const string MSG_ERROR_READ	= "読み込みに失敗しました。";
		/// <summary>メッセージ_エラー_重複</summary>
		private const string MSG_ERROR_ST5 = "このコードは既に使用されています。";
		/// <summary>メッセージ_エラー_削除</summary>
		private const string MSG_ERROR_DELETE = "削除に失敗しました。";
		/// <summary>メッセージ_エラー_更新</summary>
		private const string MSG_ERROR_UPDATE = "登録に失敗しました。";
		/// <summary>メッセージ_エラー_復活</summary>
		private const string MSG_ERROR_REVIVE = "復活に失敗しました。";
		/// <summary>メッセージ_エラー_更新（排他）</summary>
		private const string MSG_ERROR_ST800 = "既に他端末より更新されています";
		/// <summary>メッセージ_エラー_削除（排他）</summary>
		private const string MSG_ERROR_ST801 = "既に他端末より削除されています";
		# endregion

		# endregion

		# region ※Main

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFCMN09060UA());
		}

		# endregion

		# region ■IMasterMaintenanceArrayTypeメンバー

		# region ▼Propaties
		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get{ return this._canPrint; }
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

		/// <summary>グリッドのデフォルト表示位置プロパティ</summary>
		/// <value>グリッドのデフォルト表示位置を取得します。</value>
		public MGridDisplayLayout DefaultGridDisplayLayout
		{
			get{ return this._defaultGridDisplayLayout; }
		}

		/// <summary>操作対象データテーブル名称プロパティ</summary>
		/// <value>操作対象データのテーブル名称を取得または設定します。</value>
		public string TargetTableName
		{
			get{ return this._targetTableName; }
			set{  this._targetTableName = value; }
		}
		# endregion

		# region ▼Events
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region ▼Methods

		# region ●ボタン/グリッド設定等
		/// <summary>
		/// 論理削除データ抽出可能設定リスト取得処理
		/// </summary>
		/// <returns>論理削除データ抽出可能設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 論理削除データの抽出が可能かどうかの設定を配列で取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public bool[] GetCanLogicalDeleteDataExtractionList()
		{
			bool[] blRet	= new bool[2];
            blRet[0] = true;    // MOD 2008/03/24 不具合対応[12691]：「削除済データの表示」は最上位項目で制御 false→true
            blRet[1] = false;   // MOD 2008/03/24 不具合対応[12691]：「削除済データの表示」は最上位項目で制御 true→false
			return blRet; 
		}

		/// <summary>
		/// グリッドタイトルリスト取得処理
		/// </summary>
		/// <returns>グリッドタイトルリスト</returns>
		/// <remarks>
		/// <br>Note       : グリッドのタイトルを配列で取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public string[] GetGridTitleList()
		{
			string[] strRet	= new string[2];
			strRet[0]		= this._mainGridTitle;
			strRet[1]		= this._detailsGridTitle;
			return strRet;
		}

		/// <summary>
		/// グリッドアイコンリスト取得処理
		/// </summary>
		/// <returns>グリッドアイコンリスト</returns>
		/// <remarks>
		/// <br>Note       : グリッドのアイコンを配列で取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public Image[] GetGridIconList()
		{
			Image[] objRet	= new Image[2];
			objRet[0]		= this._mainGridIcon;
			objRet[1]		= this._detailsGridIcon;
			return objRet; 
		}

		/// <summary>
		/// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
		/// </summary>
		/// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
		/// <remarks>
		/// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public bool[] GetDefaultAutoFillToGridColumnList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= true;
			blRet[1]		= true;
			return blRet; 
		}

		/// <summary>
		/// データテーブルの選択データインデックスリスト設定処理
		/// </summary>
		/// <param name="indexList">データテーブルの選択データインデックスリスト</param>
		/// <remarks>
		/// <br>Note       : データテーブルの選択データインデックスリストを設定します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public void SetDataIndexList(int[] indexList)
		{
			int[] intVal			= indexList;
			this._mainDataIndex		= intVal[0];
			this._detailsDataIndex	= intVal[1];
		}

		/// <summary>
		/// 新規ボタンの有効設定リスト取得処理
		/// </summary>
		/// <returns>新規ボタンの有効設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 新規ボタンの有効設定リストを取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public bool[] GetNewButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= true;

			// ＊＊＊ 提供データは新規不可 ＊＊＊
			if ((this._mainDataIndex >= 0) &&
				((int)this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MAIN_MASTEROFFERCD] == 0))
			{
				blRet[1]		= false;
			}
			else
			{
				blRet[1]		= true;
			}

			return blRet;
		}

		/// <summary>
		/// 修正ボタンの有効設定リスト取得処理
		/// </summary>
		/// <returns>修正ボタンの有効設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public bool[] GetModifyButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= true;
			return blRet;
		}

		/// <summary>
		/// 削除ボタンの有効設定リスト取得処理
		/// </summary>
		/// <returns>削除ボタンの有効設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 削除ボタンの有効設定リストを取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public bool[] GetDeleteButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= true;

			// ＊＊＊ 提供データは削除不可 ＊＊＊
			if ((this._mainDataIndex >= 0) &&
				((int)this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MAIN_MASTEROFFERCD] == 0))
			{
				blRet[1]		= false;
			}
			else
			{
				blRet[1]		= true;
			}

			return blRet;
		}

		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet"></param>
		/// <param name="tableName"></param>
		/// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
		{
			bindDataSet = this.Bind_DataSet;

			string[] strRet	= new string[2];
			strRet[0]		= TABLENAME_USERGDHD_TABLE;
			strRet[1]		= TABLENAME_USERGDBD_TABLE;
			tableName		= strRet;
		}
		# endregion

		# region ●グリッドデータ操作系
		/// <summary>
		/// ユーザーガイドレコード検索処理
		/// </summary>
		/// <param name="totalCount">抽出件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: ユーザーガイド（ヘッダ）をリモートで全件取得し、</br>
		///	<br>			: 抽出結果をDataSetに展開し、抽出件数を返します。</br>
		/// <br>Programmer	: 22033 三崎  貴史</br>
		/// <br>Date		: 2005.05.13</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			ArrayList userGuides = null;

			// ユーザーガイド（ヘッダ）取得
			int status = this._userGuideAcs.SearchHeader(out userGuides);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					int index = 0;
					// 取得データをデータセットに展開
					foreach (UserGdHd userGuide in userGuides)
					{
						// ユーザーガイド（ヘッダ）オブジェクト データセット展開処理
						this.UserGdHdToDataSet(userGuide.Clone(), index);
						++index;
					}
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					TMsgDisp.Show( 
						this,								  // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
						ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
						this.Text,							  // プログラム名称
						"Search",							  // 処理名称
						TMsgDisp.OPE_GET,					  // オペレーション
						MSG_ERROR_READ,						  // 表示するメッセージ 
						status,								  // ステータス値
						this._userGuideAcs,					  // エラーが発生したオブジェクト
						MessageBoxButtons.OK,				  // 表示するボタン
						MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

					break;
				}
			}

			totalCount = userGuides.Count;

            // メインテーブルの削除日をサブテーブルから設定
            SetDeleteDateOfMainTable(); // ADD 2009/03/24 不具合対応[12691]：「削除済データの表示」は最上位項目で制御

			return status;
		}

		/// <summary>
		/// ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			// 実装なし
			return 9;
		}

		/// <summary>
		/// ユーザーガイド（ボディ）検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: ・ユーザーガイド（ボディ）をリモートで全件取得し、現在選択されているユーザーガイド（ヘッダ）の</br>
		///	<br>			:   ユーザーガイド区分に該当するデータをDataSetに展開します。</br>
		/// <br>			: ・抽出結果全件をキャッシュします。</br>
		///	<br>			: ・キャッシュがある場合はそちらから検索します。</br>
		/// <br>Programmer	: 22033 三崎  貴史</br>
		/// <br>Date		: 2005.05.13</br>
		/// </remarks>
		public int DetailsDataSearch(ref int totalCount, int readCount)
		{
			int status = 0;
			int index = 0;
			ArrayList userGdBd = null;

            // ADD 2009/03/24 不具合対応[12691]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // readCountが負の場合、強制終了
            if (readCount < 0)
            {
                // 現在表示されているRowをクリア
                this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows.Clear();
                return 0;
            }
            // ADD 2009/03/24 不具合対応[12691]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

			// メインフレーム側からのUI画面終了処理用Clear処理
			this._detailsIndexBuf = -2;

			// 選択されているユーザーガイド（ヘッダ）データを取得する
			// Key:ガイド区分
			int hashKey = (int)this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE];
			UserGdHd userGdHd = (UserGdHd)this._userGuideHTable[hashKey];

			// 現在表示されているRowをクリア
			this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows.Clear();

            // --- キャッシュが無かった場合 --- //
			if (this._userGuideMTable.Count == 0)
			{
				// 抽出を実行する
				status = this._userGuideAcs.SearchAllBody(
					out userGdBd,
					this._enterpriseCode,
					UserGuideAcsData.OfferDivCodeMergeBodyData);

                // ユーザーガイドの全検索結果を保持
                CacheUserGuideBodyList(userGdBd);  // ADD 2009/03/24 不具合対応[12691]：「削除済データの表示」は最上位項目で制御

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						foreach (UserGdBd usergdbd in userGdBd)
						{
							// キャッシュ保持 Key:ガイド区分_ガイドコード
							this._userGuideMTable.Add(usergdbd.UserGuideDivCd.ToString() + "_" + usergdbd.GuideCode.ToString() , usergdbd);
						
							// 選択ユーザーガイド（ヘッダ）のガイド区分の場合
							if (usergdbd.UserGuideDivCd == userGdHd.UserGuideDivCd)
							{
								// ユーザーガイド（ヘッダ）オブジェクト データセット展開処理
								this.UserGdBdToDataSet((UserGdBd)usergdbd.Clone(), index);
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
						TMsgDisp.Show( 
							this,								  // 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
							ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
							this.Text,							  // プログラム名称
							"DetailsDataSearch",				  // 処理名称
							TMsgDisp.OPE_GET,					  // オペレーション
							MSG_ERROR_READ,						  // 表示するメッセージ 
							status,								  // ステータス値
							this._userGuideAcs,					  // エラーが発生したオブジェクト
							MessageBoxButtons.OK,				  // 表示するボタン
							MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

						break;
					}
				}
			}
			// --- キャッシュから取得 --- //
			else
			{
				Hashtable wkUserGdBdTable = (Hashtable)this._userGuideMTable.Clone();
				SortedList sortList = new SortedList();
				
				foreach (UserGdBd usergdbd in wkUserGdBdTable.Values)
				{
					// 選択ユーザーガイド（ヘッダ）のガイド区分の場合
					if (usergdbd.UserGuideDivCd == userGdHd.UserGuideDivCd)
					{
						// ガイドコードでソート
						sortList.Add(usergdbd.GuideCode, usergdbd);
					}
				}
					
				// 並べ替え済みのデータをDataSetに展開
				foreach (UserGdBd usergdbd in sortList.Values)
				{
					// ユーザーガイド（ボディ）オブジェクト データセット展開処理
					this.UserGdBdToDataSet((UserGdBd)usergdbd.Clone(), index);
					++index;
				}
			}

			totalCount = index;

            // メインテーブルの削除日をサブテーブルから設定
            SetDeleteDateOfMainTable(); // ADD 2009/03/24 不具合対応[12691]：「削除済データの表示」は最上位項目で制御

			return status;
		}

		/// <summary>
		/// 明細ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public int DetailsDataSearchNext(int readCount)
		{
			// 未実装
			return 9;
		}

		/// <summary>
		/// データ論理削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを論理削除します。</br>
		/// <br>		   : フレームの削除ボタンより呼ばれます。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public int Delete()
		{
            // --- ADD 2009/01/13 障害ID:9995対応------------------------------------------------------>>>>>
            int guideDivCode = Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE].ToString());
            int guideCode = Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString());

            if ((guideDivCode == 43) && (guideCode < 20))
            {
                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    "提供データのため削除できません。",	// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                return (-1);
            }
            // --- ADD 2009/01/13 障害ID:9995対応------------------------------------------------------<<<<<

			// Key:ガイド区分_ガイドコード
			string hashKey = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE].ToString()
				+ "_"
                // 2008.11.06 modify start
                // + this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString();
				+ Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString()).ToString();
                // 2008.11.06 modify end
			// 削除対象データ取得
			UserGdBd usergdbd = ((UserGdBd)this._userGuideMTable[hashKey]).Clone();

			// 論理削除処理
			int status = this._userGuideAcs.LogicalDelete(ref usergdbd);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 排他処理
					this.ExclusiveTransaction(status, TMsgDisp.OPE_HIDE, this._userGuideAcs);
					return status;
				}
				default:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"Delete",							// 処理名称
						TMsgDisp.OPE_HIDE,					// オペレーション
						MSG_ERROR_DELETE,					// 表示するメッセージ 
						status,								// ステータス値
						this._userGuideAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン

					return status;
				}
			}

			// フレームのグリッド更新
			this.UserGdBdToDataSet(usergdbd.Clone(), this._detailsDataIndex);

            // ユーザーガイドのキャッシュを初期化（メインテーブルの削除日の設定用）
            InitializeCacheUserGuideBodyList(); // ADD 2009/03/24 不具合対応[12691]：「削除済データの表示」は最上位項目で制御

			return status;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public int Print()
		{
			// 印刷機能無しの為未実装
			return 0;
		}
		# endregion

		# region ●グリッド設定
		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		public void GetAppearanceTable(out Hashtable[] appearanceTable)
		{
			// --- MainGrid --- //
			Hashtable main = new Hashtable();
            // 削除日
            // ADD 2008/03/24 不具合対応[12691]↓：「削除済データの表示」は最上位項目で制御
            main.Add(COLUMNNAME_DETAIL_DELETEDATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
			// ガイド区分
			main.Add(COLUMNNAME_MD_GUIDEDIVCODE,	new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
			// ガイド区分名称
			main.Add(COLUMNNAME_MAIN_GUIDEDIVNAME,	new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			// マスタ提供区分コード
			main.Add(COLUMNNAME_MAIN_MASTEROFFERCD,	new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			// マスタ提供区分名称
			main.Add(COLUMNNAME_MAIN_MASTEROFFERNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

			// --- DetailsGrid --- //
			Hashtable details = new Hashtable();
			// 削除日
			details.Add(COLUMNNAME_DETAIL_DELETEDATE,	new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
			// ガイド区分
			details.Add(COLUMNNAME_MD_GUIDEDIVCODE,		new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
			// ガイドコード
			details.Add(COLUMNNAME_DETAIL_GUIDECODE,	new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
			// ガイド名称
			details.Add(COLUMNNAME_DETAIL_GUIDENAME,	new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			// ガイドタイプ（未使用）
			details.Add(COLUMNNAME_DETAIL_GUIDETYPE,	new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

			appearanceTable = new Hashtable[2];
			appearanceTable[0] = main;
			appearanceTable[1] = details;
		}
		# endregion

		# endregion

		# endregion

		# region ■Private Methods

		# region ▼DataSet関連
		/// <summary>
		/// ユーザーガイド（ヘッダ）オブジェクト データセット展開処理
		/// </summary>
		/// <param name="usergdhd">ユーザーガイド（ヘッダ）オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note       : ユーザーガイドデータクラスをデータセットに格納します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private void UserGdHdToDataSet(UserGdHd usergdhd, int index)
		{
			// 新規追加又は、DataSetの行数以上の展開Indexが指定されている場合
			if ((index < 0) || (this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].NewRow();
				this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows.Add(dataRow);
				// indexを行の最終行番号とする
				index = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows.Count - 1;
			}

			// --- DataTableにデータをセット --- //
            // 削除日
            this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[index][COLUMNNAME_DETAIL_DELETEDATE] = GetDeleteDate(usergdhd);   // ADD 2008/03/24 不具合対応[12691]：「削除済データの表示」は最上位項目で制御
			// ガイド区分
			this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[index][COLUMNNAME_MD_GUIDEDIVCODE] = usergdhd.UserGuideDivCd;
			// ガイド区分名称
			this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[index][COLUMNNAME_MAIN_GUIDEDIVNAME] = usergdhd.UserGuideDivNm;
			// マスタ提供区分コード
			this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[index][COLUMNNAME_MAIN_MASTEROFFERCD] = usergdhd.MasterOfferCd;
			// マスタ提供区分コードが[0:提供]の場合
			if (usergdhd.MasterOfferCd == 0)
			{
				this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[index][COLUMNNAME_MAIN_MASTEROFFERNM] = "提供";
			}
			// マスタ提供区分コードが[1:初期提供]の場合
			else
			{
				this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[index][COLUMNNAME_MAIN_MASTEROFFERNM] = "初期提供";
			}
			
			// フレームBindDataSet用Hashtable_ユーザーガイド（ヘッダ）にデータをセット
			this._userGuideHTable[usergdhd.UserGuideDivCd] = usergdhd;
		}

        // ADD 2009/03/24 不具合対応[12691]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
        /// <summary>
        /// メインテーブルの削除日を取得します。
        /// </summary>
        /// <param name="usergdhd"></param>
        /// <returns>削除日（削除されたレコードでは無い場合、<c>string.Empty</c>を返します。）</returns>
        private string GetDeleteDate(UserGdHd usergdhd)
        {
            if (usergdhd.LogicalDeleteCode.Equals(0))
            {
                return string.Empty;
            }
            else
            {
                return usergdhd.UpdateDateTimeJpInFormal;
            }
        }

        #region <ユーザーガイドのキャッシュ/>

        /// <summary>ユーザーガイドのキャッシュ</summary>
        /// <remarks>キー：ユーザーガイド区分コード</remarks>
        private readonly IDictionary<int, ArrayList> _userGuideBodyListCacheMap = new Dictionary<int, ArrayList>();
        /// <summary>
        /// ユーザーガイドのキャッシュを取得します。
        /// </summary>
        private IDictionary<int, ArrayList> UserGuideBodyListCacheMap
        {
            get { return _userGuideBodyListCacheMap; }
        }

        /// <summary>
        /// ユーザーガイドをキャッシュします。
        /// </summary>
        /// <param name="userGuideBodyList">ユーザーガイドのレコードリスト</param>
        private void CacheUserGuideBodyList(ArrayList userGuideBodyList)
        {
            if (userGuideBodyList == null) return;

            UserGuideBodyListCacheMap.Clear();
            foreach (DataRow mainRow in this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows)
            {
                // ユーザーガイド区分コードで分別
                int userGuideDivCd = int.Parse(mainRow[COLUMNNAME_MD_GUIDEDIVCODE].ToString());
                if (!UserGuideBodyListCacheMap.ContainsKey(userGuideDivCd))
                {
                    UserGuideBodyListCacheMap.Add(userGuideDivCd, new ArrayList());
                }
                foreach (UserGdBd userGdBd in userGuideBodyList)
                {
                    if (!userGdBd.UserGuideDivCd.Equals(userGuideDivCd)) continue;

                    UserGuideBodyListCacheMap[userGuideDivCd].Add(userGdBd);
                }
            }
        }

        /// <summary>
        /// ユーザーガイドのキャッシュを初期化します。
        /// </summary>
        private void InitializeCacheUserGuideBodyList()
        {
            ArrayList userDgBdList = null;
            int status = this._userGuideAcs.SearchAllBody(
                out userDgBdList,
                this._enterpriseCode,
                UserGuideAcsData.OfferDivCodeMergeBodyData
            );
            CacheUserGuideBodyList(userDgBdList);
        }

        #endregion  // <ユーザーガイドのキャッシュ/>

        /// <summary>
        /// メインテーブルの削除日を設定します。
        /// </summary>
        [Conditional("DELETE_DATE_DEPEND_ON_SUB_TABLE")]
        private void SetDeleteDateOfMainTable()
        {
            const string MAIN_TABLE_NAME        = TABLENAME_USERGDHD_TABLE;
            const string RELATION_COLUMN_NAME   = COLUMNNAME_MD_GUIDEDIVCODE;
            const string SUB_TABLE_NAME         = TABLENAME_USERGDBD_TABLE;
            const string DELETE_DATE_COLUMN_NAME= COLUMNNAME_DETAIL_DELETEDATE;

            foreach (DataRow mainRow in this.Bind_DataSet.Tables[MAIN_TABLE_NAME].Rows)
            {
                // 対応するサブテーブルのレコードを抽出
                int relationColumn = (int)mainRow[RELATION_COLUMN_NAME];
                DataRow[] foundSubRows = this.Bind_DataSet.Tables[SUB_TABLE_NAME].Select(
                    RELATION_COLUMN_NAME + "=" + relationColumn.ToString()
                );
                Debug.WriteLine("関連 = " + relationColumn.ToString() + ":" + foundSubRows.Length.ToString() + "件");

                if (foundSubRows.Length.Equals(0))
                {
                    #region サブテーブルに該当レコードが無い場合、DB検索結果（キャッシュ）より設定

                    // ユーザーガイド区分コード指定 検索処理（論理削除含む）
                    ArrayList userDgBdList = null;
                    if (UserGuideBodyListCacheMap.ContainsKey(relationColumn))
                    {
                        userDgBdList = UserGuideBodyListCacheMap[relationColumn];
                    }
                    else
                    {
                        int status = this._userGuideAcs.SearchAllBody(
                            out userDgBdList,
                            this._enterpriseCode,
                            UserGuideAcsData.OfferDivCodeMergeBodyData
                        );
                        CacheUserGuideBodyList(userDgBdList);
                    }
                    if (userDgBdList == null || userDgBdList.Count.Equals(0)) continue;

                    // 削除日を降順で抽出
                    int deleteRowCount = 0;
                    SortedList<string, string> sortedDeleteDateList = new SortedList<string, string>(
                        new ReverseComparer<string>()
                    );
                    foreach (UserGdBd modelNameU in userDgBdList)
                    {
                        if (modelNameU.LogicalDeleteCode.Equals(0)) continue;

                        deleteRowCount++;
                        if (!sortedDeleteDateList.ContainsKey(modelNameU.UpdateDateTimeJpInFormal))
                        {
                            sortedDeleteDateList.Add(
                                modelNameU.UpdateDateTimeJpInFormal,
                                modelNameU.UpdateDateTimeJpInFormal
                            );
                        }
                    }

                    // レコードが全件削除されている場合
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(userDgBdList.Count))
                    {
                        deleteDate = sortedDeleteDateList.Values[0];
                    }
                    mainRow[DELETE_DATE_COLUMN_NAME] = deleteDate;

                    #endregion  // サブテーブルに該当レコードが無い場合、DB検索結果（キャッシュ）より設定
                }
                else
                {
                    #region サブテーブルに該当レコードがある場合、サブテーブルより設定

                    // 削除日を抽出
                    int deleteRowCount = 0;
                    SortedList<string, string> sortedDeleteDateList = new SortedList<string, string>(
                        new ReverseComparer<string>()
                    );
                    foreach (DataRow subRow in foundSubRows)
                    {
                        Debug.WriteLine("削除日：" + subRow[DELETE_DATE_COLUMN_NAME].ToString());
                        if (string.IsNullOrEmpty(subRow[DELETE_DATE_COLUMN_NAME].ToString()))
                        {
                            continue;
                        }

                        deleteRowCount++;
                        if (!sortedDeleteDateList.ContainsKey(subRow[DELETE_DATE_COLUMN_NAME].ToString()))
                        {
                            sortedDeleteDateList.Add(
                                subRow[DELETE_DATE_COLUMN_NAME].ToString(),
                                subRow[DELETE_DATE_COLUMN_NAME].ToString()
                            );
                        }
                    }

                    // サブテーブルが全件削除されている場合
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(foundSubRows.Length))
                    {
                        deleteDate = sortedDeleteDateList.Values[0];
                    }
                    mainRow[DELETE_DATE_COLUMN_NAME] = deleteDate;

                    #endregion  // サブテーブルに該当レコードがある場合、サブテーブルより設定
                }
            }
        }
        // ADD 2009/03/24 不具合対応[12691]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

		/// <summary>
		/// ユーザーガイド（ボディ）オブジェクト データセット展開処理
		/// </summary>
		/// <param name="usergdbd">ユーザーガイド（ボディ）オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note       : ユーザーガイドデータクラスをデータセットに格納します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private void UserGdBdToDataSet(UserGdBd usergdbd, int index)
		{
			// 新規追加又は、DataSetの行数以上の展開Indexが指定されている場合
			if ((index < 0) || (this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].NewRow();
				this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows.Add( dataRow );
				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows.Count - 1;
			}

			// --- DataTableにデータをセット --- //
			// 論理削除区分が0の場合
			if (usergdbd.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[index][COLUMNNAME_DETAIL_DELETEDATE] = "";
			}
			else
			{
				// （削除日 =）更新日付をセット
				this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[index][COLUMNNAME_DETAIL_DELETEDATE] = usergdbd.UpdateDateTimeJpInFormal;
			}
			// ガイド区分
			this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[index][COLUMNNAME_MD_GUIDEDIVCODE] = usergdbd.UserGuideDivCd;
			// ガイドコード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/02 G.Miyatsu ADD
            if ((usergdbd.UserGuideDivCd == 72) || (usergdbd.UserGuideDivCd == 73))
            {
                this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[index][COLUMNNAME_DETAIL_GUIDECODE] = usergdbd.GuideCode;
            }
            // --- ADD 2010.04.21 START 張義 ---------->>>>>
            //ガイド区分「４６：銀行」時
            else if (usergdbd.UserGuideDivCd == 46)
            {
                this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[index][COLUMNNAME_DETAIL_GUIDECODE] = usergdbd.GuideCode.ToString().PadLeft(7, '0');
            }
            // --- ADD 2010.04.21 END 張義 ----------<<<<<
            else
            {
                this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[index][COLUMNNAME_DETAIL_GUIDECODE] = usergdbd.GuideCode.ToString().PadLeft(4, '0');
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/02 G.Miyatsu ADD
			// ガイド名称
			this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[index][COLUMNNAME_DETAIL_GUIDENAME]	= usergdbd.GuideName;
			// ガイドタイプ（未使用）
			// this.Bind_DataSet.Tables[USERGDBD_TABLE].Rows[index][GUIDETYPE_TITLE] = usergdbd.GuideType;

			// フレームBindDataSet用Hashtable_ユーザーガイド（ボディ）にデータをセット
			string key = usergdbd.UserGuideDivCd.ToString() + "_" + usergdbd.GuideCode.ToString();
			this._userGuideMTable[key] = usergdbd;
		}

		/// <summary>
		/// フレームグリッドBindデータセット 列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			// ユーザーガイド（ヘッダ）用テーブル
			DataTable userGdHdTable = new DataTable(TABLENAME_USERGDHD_TABLE);
			// Addを行う順番が、列の表示順位となります。
            // ADD 2008/03/24 不具合対応[12691]↓：「削除済データの表示」は最上位項目で制御
            userGdHdTable.Columns.Add(COLUMNNAME_DETAIL_DELETEDATE, typeof(string));	// 削除日
			userGdHdTable.Columns.Add(COLUMNNAME_MD_GUIDEDIVCODE,		typeof(int));		// ガイド区分
			userGdHdTable.Columns.Add(COLUMNNAME_MAIN_GUIDEDIVNAME,		typeof(string));	// ガイド区分名称
			userGdHdTable.Columns.Add(COLUMNNAME_MAIN_MASTEROFFERCD,	typeof(int));		// マスタ提供区分コード
			userGdHdTable.Columns.Add(COLUMNNAME_MAIN_MASTEROFFERNM,	typeof(string));	// マスタ提供区分名称
			this.Bind_DataSet.Tables.Add(userGdHdTable);

			// ユーザーガイド（ボディ）用テーブル
			DataTable userGdBdTable = new DataTable(TABLENAME_USERGDBD_TABLE);
			// Addを行う順番が、列の表示順位となります。
			userGdBdTable.Columns.Add(COLUMNNAME_DETAIL_DELETEDATE,     typeof(string));	// 削除日
			userGdBdTable.Columns.Add(COLUMNNAME_MD_GUIDEDIVCODE,		typeof(int));		// ガイド区分
            // 2008.11.06 modify start
			//userGdBdTable.Columns.Add(COLUMNNAME_DETAIL_GUIDECODE,		typeof(int));		// ガイドコード
            userGdBdTable.Columns.Add(COLUMNNAME_DETAIL_GUIDECODE, typeof(string));		// ガイドコード
            // 2008.11.06 modify end
			userGdBdTable.Columns.Add(COLUMNNAME_DETAIL_GUIDENAME,		typeof(string));	// ガイド名称
			userGdBdTable.Columns.Add(COLUMNNAME_DETAIL_GUIDETYPE,		typeof(int));		// ガイドタイプ
			this.Bind_DataSet.Tables.Add(userGdBdTable);
		}
		# endregion

		# region ▼画面操作
		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private void ScreenClear()
		{
			// ガイドコード
			this.GuideCode_tNedit.Clear();		
            // --- ADD 2010.04.21 START 張義 ---------->>>>>
            if (this.GuideDivCode_tNedit.Text.Equals("46"))
            {
                this.BranchCode_tNedit.Clear();
            }
            // --- ADD 2010.04.21 END 張義 ----------<<<<<
			// ガイドタイプ（未実装）
			//this.GuideType_tNedit.Clear();
			// ガイド名称
			this.GuideName_tEdit.Clear();
			// ガイド区分名称
			this.GuideDivName_tEdit.Text = (string)this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MAIN_GUIDEDIVNAME];
			// ガイド区分
			this.GuideDivCode_tNedit.SetInt((int)this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE]);  
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			// 新規作成の場合
			if (this._detailsDataIndex < 0)
			{
				# region † 新規作成時処理 †
				// 画面クリア処理
				this.ScreenClear();
				// 新規モード
				this.Mode_Label.Text = INSERT_MODE;
				// ボタン設定
				this.Ok_Button.Visible	   = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;
				// 画面衆力許可制御処理
				this.ScreenInputPermissionControl(true);
				// 選択ガイド区分セット
				this.GuideDivCode_tNedit.SetInt((int)this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE]);
                // --- ADD 2010.04.21 START 張義 ---------->>>>>
                //ガイド区分「４６：銀行」時
                if (this.GuideDivCode_tNedit.Text.Equals("46"))
                {
                    //支店コード
                    this.BranchCode_ultraLabel.Visible = true;
                    this.BranchCode_tNedit.Visible = true;
                    //銀行コード
                    this.GuideCode_uLabel.Text = BANKCODE_ULABEL;
                    //銀行名
                    this.GuideName_uLabel.Text = BANKNAME_ULABEL;
                }
                else
                {
                    //支店コード
                    this.BranchCode_ultraLabel.Visible = false;
                    this.BranchCode_tNedit.Visible = false;
                    //ガイドコード
                    this.GuideCode_uLabel.Text = GUIDECODE_ULABEL;
                    //ガイド名
                    this.GuideName_uLabel.Text = GUIDENAME_ULABEL;
                }
                // --- ADD 2010.04.21 END 張義 ----------<<<<<
                // --- 編集チェック用クローン作成 --- //
				this._userGdBdClone = new UserGdBd();
				this.DispToUserGdBd(ref this._userGdBdClone);	// 画面情報取得処理
                                
				// 初期フォーカスセット
				this.GuideCode_tNedit.Focus();
				# endregion

                // ADD 2008/10/07 不具合対応[6271] ---------->>>>>
                if (this.GuideDivCode_tNedit.Text.Equals("72") ||
                this.GuideDivCode_tNedit.Text.Equals("73"))
                {
                    this.GuideCode_tNedit.MaxLength = 1;
                    //this.GuideCode_tNedit.//TODO
                }
                else
                {
                    this.GuideCode_tNedit.MaxLength = 4;
                }
                // ADD 2008/10/07 不具合対応[6271] ----------<<<<<

				return;
			}
			
			// マスタ提供区分が[0:提供]の場合
			if ((int)this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MAIN_MASTEROFFERCD] == 0)
			{
				# region † 参照モード時処理 †
				// 参照モード
				this.Mode_Label.Text = REFER_MODE;
				// ボタン設定
				this.Ok_Button.Visible     = false;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;
				// 参照データ取得
				string hashKey = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE].ToString()
					+ "_"
                    // 2008.11.06 modify start
                    // + this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString();
                    + Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString()).ToString();
                    // 2008.11.06 modify end
				UserGdBd userGdBd = (UserGdBd)this._userGuideMTable[hashKey];
				// 取得データを画面展開
				this.UserGdBdUToScreen(userGdBd);
				// 画面入力許可制御処理
				this.ScreenInputPermissionControl(false);
				// 初期フォーカス設定
				this.Cancel_Button.Focus();
				# endregion

                // ADD 2008/10/07 不具合対応[6271] ---------->>>>>
                if (this.GuideDivCode_tNedit.Text.Equals("72") ||
                this.GuideDivCode_tNedit.Text.Equals("73"))
                {
                    this.GuideCode_tNedit.MaxLength = 1;
                }
                else
                {
                    this.GuideCode_tNedit.MaxLength = 4;
                }
                // ADD 2008/10/07 不具合対応[6271] ----------<<<<<

				return;
			}
			
			// 削除日がある場合
			if((string)this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_DELETEDATE] != "")
			{
				# region † 参照モード時処理 †
				// 削除モード
				this.Mode_Label.Text = DELETE_MODE;
				// ボタン設定
				this.Ok_Button.Visible = false;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = true;
				this.Revive_Button.Visible = true;
				// 対象データ取得
				string hashKey = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE].ToString()
					+ "_"
                    // 2008.11.06 modify start
                    // + this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString();
					+ Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString()).ToString();
                    // 2008.11.06 modify end
				UserGdBd userGdBd = (UserGdBd)this._userGuideMTable[hashKey];
				// 取得データを画面に展開
				this.UserGdBdUToScreen(userGdBd);
				// 画面入力許可制御処理
				this.ScreenInputPermissionControl(false);
				// 初期フォーカス
				this.Delete_Button.Focus();
				# endregion
			}
			// 削除日が無い場合
			else
			{
				# region † 更新モード時処理 †
				// 更新モード
				this.Mode_Label.Text	   = UPDATE_MODE;
				// ボタン設定
				this.Ok_Button.Visible	   = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;
				// 対象データ取得
				string hashKey = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE].ToString()
					+ "_"
                    // 2008.11.06 modify start
                    // + this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString();
					+ Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString()).ToString();
                    // 2008.11.06 modify end
				UserGdBd userGdBd = (UserGdBd)this._userGuideMTable[hashKey];
				// 取得データを画面に展開
				this.UserGdBdUToScreen(userGdBd);
				// 編集チェック用クローン作成
				this._userGdBdClone = userGdBd.Clone(); 
				this.DispToUserGdBd(ref this._userGdBdClone);
				// 画面入力許可制御処理
				this.ScreenInputPermissionControl(true);
				// 追加制御
				this.GuideCode_tNedit.Enabled = false;
                // --- ADD 2010.04.21 START 張義 ---------->>>>>
                if (this.GuideDivCode_tNedit.Text.Equals("46"))
                {
                    this.BranchCode_tNedit.Enabled = false;
                }
                // --- ADD 2010.04.21 END 張義 ----------<<<<<
				// 初期フォーカス設定
				this.GuideName_tEdit.Focus();
				# endregion
			}

            // ADD 2008/10/07 不具合対応[6271] ---------->>>>>
            if (this.GuideDivCode_tNedit.Text.Equals("72") ||
            this.GuideDivCode_tNedit.Text.Equals("73"))
            {
                this.GuideCode_tNedit.MaxLength = 1;
            }
            else
            {
                this.GuideCode_tNedit.MaxLength = 4;
            }
            // ADD 2008/10/07 不具合対応[6271] ----------<<<<<

			// フレームGrid_Index_Buffer保持
			this._detailsIndexBuf = this._detailsDataIndex;
			this._mainIndexBuf = this._mainDataIndex;
		}

		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <param name="enabled">入力許可設定値</param>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private void ScreenInputPermissionControl(bool enabled)
		{
			// ガイドコード
			this.GuideCode_tNedit.Enabled	= enabled;
			// ガイド名称
			this.GuideName_tEdit.Enabled	= enabled;
			// ガイドタイプ（未使用）
			// this.GuideType_tNedit.Enabled	= enabled;
            // --- ADD 2010.04.21 START 張義 ---------->>>>>
            if (this.GuideDivCode_tNedit.Text.Equals("46"))
            {
                this.BranchCode_tNedit.Enabled = enabled;
            }
            // --- ADD 2010.04.21 END 張義 ----------<<<<<
		}

		/// <summary>
		/// ユーザーガイド（ボディ）クラス画面展開処理
		/// </summary>
		/// <param name="userGdBd">ユーザーガイド（ボディ）オブジェクト</param>
		/// <remarks>
		/// <br>Note       : ユーザーガイドオブジェクトから画面にデータを展開します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private void UserGdBdUToScreen(UserGdBd userGdBd)
		{
            if (userGdBd != null)
            {
                // ガイド区分
                this.GuideDivCode_tNedit.SetInt(userGdBd.UserGuideDivCd);
                // ガイド区分名称
                this.GuideDivName_tEdit.Text = (string)this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MAIN_GUIDEDIVNAME];
                // ガイドコード
                // --- ADD 2010.04.21 START 張義 ---------->>>>>
                //ガイド区分「４６：銀行」時
                if (this.GuideDivCode_tNedit.Text.Equals("46"))
                {
                    //支店コード
                    this.BranchCode_ultraLabel.Visible = true;
                    this.BranchCode_tNedit.Visible = true;
                    //銀行コード
                    this.GuideCode_uLabel.Text = BANKCODE_ULABEL;
                    //銀行名
                    this.GuideName_uLabel.Text = BANKNAME_ULABEL;
                }
                else
                {
                    //支店コード
                    this.BranchCode_ultraLabel.Visible = false;
                    this.BranchCode_tNedit.Visible = false;
                    //ガイドコード
                    this.GuideCode_uLabel.Text = GUIDECODE_ULABEL;
                    //ガイド名
                    this.GuideName_uLabel.Text = GUIDENAME_ULABEL;
                }
                // --- ADD 2010.04.21 END 張義 ----------<<<<<
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/02 G.Miyatsu ADD
                if (this.GuideDivCode_tNedit.Text.Equals("72") ||
                    this.GuideDivCode_tNedit.Text.Equals("73"))
                {
                    this.GuideCode_tNedit.ExtEdit.AutoWidth = false;
                    this.GuideCode_tNedit.SetInt(userGdBd.GuideCode);
                    this.GuideCode_tNedit.ExtEdit.Column = 1;
                }
                // --- ADD 2010.04.21 START 張義 ---------->>>>>
                //ガイド区分「４６：銀行」時
                else if (this.GuideDivCode_tNedit.Text.Equals("46"))
                {
                    //銀行コード
                    int guideCodeInt = userGdBd.GuideCode / 1000;
                    this.GuideCode_tNedit.Text = guideCodeInt.ToString().PadLeft(4, '0');
                    this.GuideCode_tNedit.ExtEdit.Column = 4;
                    //支店コード
                    int branchCodeInt = userGdBd.GuideCode % 1000;
                    this.BranchCode_tNedit.Text = branchCodeInt.ToString().PadLeft(3, '0');
                    this.BranchCode_tNedit.ExtEdit.Column = 3;
                }
                // --- ADD 2010.04.21 END 張義 ----------<<<<<
                else
                {
                    this.GuideCode_tNedit.ExtEdit.AutoWidth = true;
                    this.GuideCode_tNedit.Text = userGdBd.GuideCode.ToString().PadLeft(4, '0');
                    this.GuideCode_tNedit.ExtEdit.Column = 4;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/02 G.Miyatsu ADD
                // ガイド名称
                this.GuideName_tEdit.Text = userGdBd.GuideName;
                // ガイドタイプ（未使用）
                // this.GuideType_tNedit.Text = userGdBd.GuideType.ToString();
            }
		}
		# endregion

		# region ▼画面情報取得
		/// <summary>
		/// 画面情報ユーザーガイドクラス格納処理
		/// </summary>
		/// <param name="userGdBd">ユーザーガイドオブジェクト</param>
		/// <remarks>
		/// <br>Note       : 画面情報からユーザーガイドオブジェクトにデータを格納します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private void DispToUserGdBd(ref UserGdBd userGdBd)
		{
			if (userGdBd == null)
			{
				// 新規の場合
				userGdBd = new UserGdBd();
			}													  

			// 企業コード
			userGdBd.EnterpriseCode	= this._enterpriseCode;
			// ガイド区分
			userGdBd.UserGuideDivCd	= this.GuideDivCode_tNedit.GetInt();
            // --- ADD 2010.04.21 START 張義 ---------->>>>>
            //ガイド区分「４６：銀行」時
            if (this.GuideDivCode_tNedit.Text.Equals("46"))
            {
                // ガイドコード
                userGdBd.GuideCode = this.GuideCode_tNedit.GetInt() * 1000 + this.BranchCode_tNedit.GetInt();
            }
            else
            {
                // ガイドコード
                userGdBd.GuideCode = this.GuideCode_tNedit.GetInt();
            }
            // --- ADD 2010.04.21 END 張義 ----------<<<<<
            // --- DEL 2010.04.21 START 張義 ---------->>>>>
			// ガイドコード
            //userGdBd.GuideCode = this.GuideCode_tNedit.GetInt();
            // --- DEL 2010.04.21 END 張義 ----------<<<<<
			// ガイド名称
			userGdBd.GuideName		= this.GuideName_tEdit.Text;
			// ガイドタイプ（未使用）
			// userGdBd.GuideType	= GuideType_tNedit.GetInt();
		}

		/// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.05.13</br>
		/// </remarks>
		private bool ScreenDataCheck(ref Control control, ref string message)
		{
			bool result = true;

			// ガイドコードが入力されてい無い場合
            // --- CHG 2009/01/09 障害ID:9807対応------------------------------------------------------>>>>>
            //if (this.GuideCode_tNedit.GetInt() == 0)
            if (this.GuideCode_tNedit.DataText.Trim() == "")
			{
				control = this.GuideCode_tNedit;
				message = this.GuideCode_uLabel.Text + "を入力して下さい。";
				result	= false;
			}
            // --- CHG 2009/01/09 障害ID:9807対応------------------------------------------------------<<<<<
            
                // ガイド名称が入力されてい無い場合
			else if (this.GuideName_tEdit.Text == "")
			{
				control = this.GuideName_tEdit;
				message = this.GuideName_uLabel.Text + "を入力して下さい。";
				result	= false;	
			}
			
			return result;
		}
		# endregion

		# region ▼分割/重複処理
		/// <summary>
		/// 保存処理
		/// </summary>
		/// <returns>チェック結果</returns>
		/// <remarks>
		/// <br>Note　　　  : ユーザーガイドオブジェクトの保存処理を行います。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>
		private bool SaveProc()
		{
			Control control = null;
			string message = null;	

			// 入力チェックがNGの場合
			if (!ScreenDataCheck(ref control, ref message))
			{
				TMsgDisp.Show( 
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
					ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
					message,							// 表示するメッセージ 
					0,									// ステータス値
					MessageBoxButtons.OK);				// 表示するボタン

				control.Focus();
				return false;
			}

			UserGdBd usergdbd = null;
			// 更新の場合
			if (this._detailsDataIndex >= 0)
			{
				// 更新対象データ取得
				string hashKey = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE].ToString()
					+ "_"
					//+ this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString();
                    // 2008.11.06 modify start
                    + Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString()).ToString();
                    // 2008.11.06 modify end
				usergdbd = ((UserGdBd)this._userGuideMTable[hashKey]).Clone();
			}

			// 画面情報でデータを上書き
			this.DispToUserGdBd(ref usergdbd);

			// 保存処理
			int status = this._userGuideAcs.Write(ref usergdbd);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						MSG_ERROR_ST5,						// 表示するメッセージ 
						status,								// ステータス値
						MessageBoxButtons.OK);				// 表示するボタン

					// フォーカス設定
					this.GuideCode_tNedit.Focus();
					return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 排他処理
					this.ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._userGuideAcs);

					// 入力フォーム終了時処理
					this.TimeOfFormEndProc(DialogResult.OK, DialogResult.Cancel);
					
					return false;
				}
				default:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"SaveProc",							// 処理名称
						TMsgDisp.OPE_UPDATE,				// オペレーション
						MSG_ERROR_UPDATE,					// 表示するメッセージ 
						status,								// ステータス値
						this._userGuideAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン

					// 入力フォーム終了時処理
					this.TimeOfFormEndProc(DialogResult.OK, DialogResult.Cancel);
				
					return false;
				}
			}

			// フレームグリッド更新
			this.UserGdBdToDataSet(usergdbd, this._detailsDataIndex);

			return true;
		}

		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="operation">オペレーション</param>
		/// <param name="erObject">エラーオブジェクト</param>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : データ更新時の排他処理を行います。</br>
		/// <br>Programmer : 22033  三崎 貴史</br>
		/// <br>Date       : 2005.09.21</br>
		/// </remarks>
		private void ExclusiveTransaction(int status, string operation, object erObject)
		{				   
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"ExclusiveTransaction",				// 処理名称
						operation,							// オペレーション
						MSG_ERROR_ST800,					// 表示するメッセージ 
						status,								// ステータス値
						erObject,							// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"ExclusiveTransaction",				// 処理名称
						operation,							// オペレーション
						MSG_ERROR_ST801,					// 表示するメッセージ 
						status,								// ステータス値
						erObject,							// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					break;
				}
			}
		}

		/// <summary>
		/// 入力フォーム終了時処理
		/// </summary>
		/// <param name="dRet1">UnDisplaying用 DialogResult</param>
		/// <param name="dRet2">フォーム用 DialogResult</param>
		/// <remarks>イベントパラメータや変数の初期化やフォームの状態を設定します。</remarks>
		private void TimeOfFormEndProc(DialogResult dRet1, DialogResult dRet2)
		{
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dRet1);
				UnDisplaying(this, me);
			}

			this.DialogResult = dRet2;
			// フレームグリッドIndex_Buffer初期化
			this._detailsIndexBuf	= -2;
			this._mainIndexBuf		= -2;

			// フォームを閉じる
			if (CanClose)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}
		# endregion

		# endregion

		# region ■Control Events

		# region ▼フォームイベント
		/// <summary>
		/// Form.Load イベント(SFCMN09060UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>
		private void SFCMN09060UA_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;

			this.Ok_Button.ImageList = imageList24;
			this.Cancel_Button.ImageList = imageList24;
			this.Revive_Button.ImageList = imageList24;
			this.Delete_Button.ImageList = imageList24;

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
		}

		/// <summary>
		/// Form.Closing イベント(SFCMN09060UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note　　　  : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>
		private void SFCMN09060UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// フレームの最小化対応
			this._detailsIndexBuf	= -2;
			this._mainIndexBuf		= -2;

			// フォームの「×」をクリックされた場合の対応です。
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}	
		}

		/// <summary>
		/// Control.VisibleChanged イベント(SFCMN09060UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>
		private void SFCMN09060UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				this.Owner.Activate();
				return;
			}
			
			if ((this._detailsIndexBuf == this._detailsDataIndex) &&
				(this._mainIndexBuf == this._mainDataIndex))
			{
				return;
			}
			
			this.Initial_Timer.Enabled = true;
			// 画面クリア
			this.ScreenClear();
		}
		# endregion

		# region ▼ボタンクリックイベント
		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// ユーザーガイド登録処理
			if (SaveProc() == false)
			{
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			// 新規モードの場合は画面を終了せずに連続入力を可能とする
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				// データインデックスを初期化する
				this._detailsDataIndex = -1;
				// 画面クリア
				this.ScreenClear();
				// クローンを再度取得する
				UserGdBd usergdbd = new UserGdBd();
				//クローン作成
				this._userGdBdClone = usergdbd.Clone(); 
				this.DispToUserGdBd(ref this._userGdBdClone);
				// 新規モード
				this.Mode_Label.Text = INSERT_MODE;
				// ボタン設定
				this.Ok_Button.Visible	   = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;
				// 画面入力許可制御処理
				this.ScreenInputPermissionControl(true);
				// 初期フォーカスセット
				this.GuideCode_tNedit.Focus();
			}
			else
			{
				this.DialogResult = DialogResult.OK;
				this._detailsIndexBuf = -2;
				this._mainIndexBuf = -2;

				if (CanClose == true)
				{
					this.Close();
				}
				else
				{
					this.Hide();
				}
			}
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>		
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// 削除モード・参照モード以外の場合は保存確認処理を行う
			if ((this.Mode_Label.Text != DELETE_MODE) &&
				(this.Mode_Label.Text != REFER_MODE))
			{
				// 現在の画面情報を取得
				UserGdBd compareUserGdBd = new UserGdBd();  
				compareUserGdBd = this._userGdBdClone.Clone();  
				this.DispToUserGdBd(ref compareUserGdBd);

				// 最初に取得した画面情報と比較
				if (!(this._userGdBdClone.Equals(compareUserGdBd)))	
				{
					// 画面情報が変更されていた場合は、保存確認メッセージを表示する
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
							// 保存処理
							if (!this.SaveProc())
							{
								return;
							}
							this.DialogResult = DialogResult.OK;
							break;
						}
						case DialogResult.No:
						{
							this.DialogResult = DialogResult.Cancel;
							break;
						}
						default:
						{
							// 2009.03.26 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                GuideCode_tNedit.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.26 30413 犬飼 新規モードからモード変更対応 <<<<<<END
							return;
						}
					}
				}
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;
			this._detailsIndexBuf = -2;
			this._mainIndexBuf = -2;

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
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Initial_Timer.Enabled = false;
			this.ScreenReconstruction();		
		}

		/// <summary>
		/// Control.Click イベント(Revive_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 復活ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			// 対象データ取得
			string hashKey = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE].ToString()
				+ "_"
                // 2008.11.06 modify start
                // + this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString();
				+ Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString()).ToString();
                // 2008.11.06 modify end
			UserGdBd usergdbd = ((UserGdBd)_userGuideMTable[hashKey]).Clone();

			// 復活処理
			int status = this._userGuideAcs.Revival(ref usergdbd);
			
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 排他処理
					this.ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._userGuideAcs);
					// 入力フォーム終了時処理
					this.TimeOfFormEndProc(DialogResult.OK, DialogResult.Cancel);

					return;
				}
				default:
				{
					TMsgDisp.Show( 
						this,								  // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
						ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
						this.Text,							  // プログラム名称
						"Revive_Button_Click",				  // 処理名称
						TMsgDisp.OPE_UPDATE,				  // オペレーション
						MSG_ERROR_REVIVE,					  // 表示するメッセージ 
						status,								  // ステータス値
						this._userGuideAcs,					  // エラーが発生したオブジェクト
						MessageBoxButtons.OK,				  // 表示するボタン
						MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

					// 入力フォーム終了時処理
					this.TimeOfFormEndProc(DialogResult.OK, DialogResult.Cancel);
					return;
				}
			}

			// フレームグリッド更新
			this.UserGdBdToDataSet(usergdbd, this._detailsDataIndex);
			// 入力フォーム終了時処理
			this.TimeOfFormEndProc(DialogResult.OK, DialogResult.OK);

            // ユーザーガイドのキャッシュを初期化
            InitializeCacheUserGuideBodyList(); // ADD 2009/03/24 不具合対応[12691]：「削除済データの表示」は最上位項目で制御
		}

		/// <summary>
		/// Control.Click イベント(Delete_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.05.13</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			// 確認メッセージ表示
			DialogResult result = TMsgDisp.Show( 
				this,													// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_QUESTION,						// エラーレベル
				ASSEMBLY_ID,											// アセンブリＩＤまたはクラスＩＤ
				"データを削除します。" + "\r\n" + "よろしいですか？",	// 表示するメッセージ 
				0,														// ステータス値
				MessageBoxButtons.OKCancel,								// 表示するボタン
				MessageBoxDefaultButton.Button2);						// 初期表示ボタン

			if (result == DialogResult.OK)
			{
				// 対象データ取得
				string hashKey = this.Bind_DataSet.Tables[TABLENAME_USERGDHD_TABLE].Rows[this._mainDataIndex][COLUMNNAME_MD_GUIDEDIVCODE].ToString()
					+ "_"
                    // 2008.11.06 modify start
                    // + this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString();
					+ Int32.Parse(this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex][COLUMNNAME_DETAIL_GUIDECODE].ToString()).ToString();
                    // 2008.11.06 modify end
				UserGdBd usergdbd = ((UserGdBd)this._userGuideMTable[hashKey]).Clone();

				// 物理削除処理
				int status = this._userGuideAcs.Delete(usergdbd);
				
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[this._detailsDataIndex].Delete();
						this._userGuideMTable.Remove(usergdbd.UserGuideDivCd.ToString() + "_" + usergdbd.GuideCode.ToString());

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// 排他処理
						this.ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._userGuideAcs);
						// 入力フォーム終了時処理
						this.TimeOfFormEndProc(DialogResult.OK, DialogResult.Cancel);
					
						return;
					}
					default:
					{
						TMsgDisp.Show( 
							this,								  // 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
							ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
							this.Text,							  // プログラム名称
							"Delete_Button_Click",				  // 処理名称
							TMsgDisp.OPE_DELETE,				  // オペレーション
							MSG_ERROR_DELETE,					  // 表示するメッセージ 
							status,								  // ステータス値
							this._userGuideAcs,					  // エラーが発生したオブジェクト
							MessageBoxButtons.OK,				  // 表示するボタン
							MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

						// 入力フォーム終了時処理
						this.TimeOfFormEndProc(DialogResult.OK, DialogResult.Cancel);
						return;
					}
				}
			}
			else
			{
				this.Delete_Button.Focus();
				return;
			}

			// 入力フォーム終了時処理
			this.TimeOfFormEndProc(DialogResult.OK, DialogResult.OK);
		}
		# endregion

        // 2009.03.26 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// tArrowKeyControlChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            _modeFlg = false;

            switch (e.PrevCtrl.Name)
            {
                case "GuideCode_tNedit":
                    // ガイドコードにフォーカスがある場合
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // 遷移先が閉じるボタン
                        _modeFlg = true;
                    }
                    //else if (this._detailsDataIndex < 0) // DEL 2010.04.21 張義
                    else if (e.NextCtrl.Name != "BranchCode_tNedit" && this._detailsDataIndex < 0) // ADD 2010.04.21 張義
                    {
                        if (ModeChangeProc())
                        {
                            e.NextCtrl = GuideCode_tNedit;
                        }
                    }
                    break;
                // --- ADD 2010.04.21 START 張義 ---------->>>>>
                case "BranchCode_tNedit":
                    if (this.BranchCode_tNedit.GetInt() == 0)
                    {
                        int branchCodeInt = 0;
                        this.BranchCode_tNedit.Text = branchCodeInt.ToString().PadLeft(3, '0');
                        this.BranchCode_tNedit.ExtEdit.Column = 3;
                    }
                    // ガイドコードにフォーカスがある場合
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // 遷移先が閉じるボタン
                        _modeFlg = true;
                    }
                    //else if (this._detailsDataIndex < 0) // DEL 2010.04.21 張義
                    else if (e.NextCtrl.Name != "GuideCode_tNedit" && this._detailsDataIndex < 0) // ADD 2010.04.21 張義
                    {
                        if (ModeChangeProc())
                        {
                            e.NextCtrl = GuideCode_tNedit;
                        }
                    }
                    break;
                // --- ADD 2010.04.21 END 張義 ----------<<<<<
            }
        }

        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // ガイドコード
            string guideCode = GuideCode_tNedit.GetInt().ToString().PadLeft(4, '0');
            // --- ADD 2010.04.21 START 張義 ---------->>>>>
            //ガイド区分「４６：銀行」時
            if (this.GuideDivCode_tNedit.Text.Equals("46"))
            {
                int guideCodeInt = GuideCode_tNedit.GetInt() * 1000 + BranchCode_tNedit.GetInt();
                guideCode = guideCodeInt.ToString().PadLeft(7, '0');
            }
            // --- ADD 2010.04.21 END 張義 ----------<<<<<

            for (int i = 0; i < this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsGuideCode = (string)this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[i][COLUMNNAME_DETAIL_GUIDECODE];
                if (guideCode.Equals(dsGuideCode.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[TABLENAME_USERGDBD_TABLE].Rows[i][COLUMNNAME_DETAIL_DELETEDATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのユーザーガイド設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // ガイドコードのクリア
                        GuideCode_tNedit.Clear();
                        // --- ADD 2010.04.21 START 張義 ---------->>>>>
                        //ガイド区分「４６：銀行」時
                        if (this.GuideDivCode_tNedit.Text.Equals("46"))
                        {
                            BranchCode_tNedit.Clear();
                        }
                        // --- ADD 2010.04.21 END 張義 ----------<<<<<
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードのユーザーガイド設定情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._detailsDataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ガイドコードのクリア
                                GuideCode_tNedit.Clear();
                                //ガイド区分「４６：銀行」時
                                if (this.GuideDivCode_tNedit.Text.Equals("46"))
                                {
                                    BranchCode_tNedit.Clear();
                                }
                                // --- ADD 2010.04.21 END 張義 ----------<<<<<
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.26 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        # endregion
	}
}
