//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 備考設定マスタ
// プログラム概要   : 備考設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三崎 貴史
// 作 成 日  2005/10/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三崎 貴史
// 修 正 日  2006/08/30  修正内容 : 画面表示位置を正しく修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 段上 知子
// 修 正 日  2007/02/27  修正内容 : SF版を流用し携帯版を作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 修 正 日  2007/10/04  修正内容 : 携帯版を流用しDC.NS版を作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2008/09/11  修正内容 : 初期表示位置の演算コードを削除
//----------------------------------------------------------------------------//
// 管理番号  12690       作成担当 : 工藤 恵優
// 修 正 日  2008/03/24  修正内容 : 「削除済データの表示」は最上位項目で制御
//----------------------------------------------------------------------------//
# region ※using
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
	/// 備考設定入力フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 備考の設定を行います。
	///					 IMasterMaintenanceArrayTypeを実装しています。</br>
	/// <br>Programmer : 22033 三崎  貴史</br>
	/// <br>Date       : 2005.10.14</br>
	/// <br>Update Note: 2006.08.30 22033 三崎 貴史</br>
    /// <br>			 ・画面表示位置を正しく修正</br>
    /// <br>Update Note: 2007.02.27 22022 段上 知子</br>
    /// <br>		     ・SF版を流用し携帯版を作成</br>
	/// <br>Update Note: 2007.10.04 21024 佐々木 健</br>
	/// <br>		     ・携帯版を流用しDC.NS版を作成</br>
    /// <br>Update Note: 2008.09.11 30434 工藤 恵優</br>
    /// <br>		     ・初期表示位置の演算コードを削除</br>
    /// <br>Update Note: 2009.03.24 30434 工藤 恵優</br>
    /// <br>		     ・「削除済データの表示」は最上位項目で制御</br>
	/// </remarks>
	public class SFTOK09400UA : System.Windows.Forms.Form, IMasterMaintenanceArrayType
	{
		# region ■Private Members (Component)

		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Data.DataSet Bind_DataSet;
		private System.Data.DataSet Details_DataSet;
		private Infragistics.Win.Misc.UltraLabel NoteGuideDivCode_uLabel;
		private Broadleaf.Library.Windows.Forms.TEdit NoteGuideDivName_tEdit;
		private Infragistics.Win.Misc.UltraLabel NoteGuideDivName_uLabel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Broadleaf.Library.Windows.Forms.TEdit NoteGuideName_tEdit;
		private Broadleaf.Library.Windows.Forms.TNedit NoteGuideCode_tNedit;
		private Infragistics.Win.Misc.UltraLabel NoteGuideName_uLabel;
		private Infragistics.Win.Misc.UltraLabel NoteGuideCode_uLabel;
		private Broadleaf.Library.Windows.Forms.TNedit NoteGuideDivCode_tNedit;
		private System.Windows.Forms.Panel Body_Panel;
		private System.Windows.Forms.Panel Button_Panel;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private TMemPos tMemPos;
		private System.ComponentModel.IContainer components;

		# endregion

		# region ■Constructor

		/// <summary>
		/// 備考設定入力フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 備考設定入力フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public SFTOK09400UA()
		{
			InitializeComponent();

			// データセット列情報構築処理
			DataSetColumnConstruction();

			// プロパティ初期値設定
			this._canPrint					= false;
			this._canClose					= true;
			this._canNew					= true;
			this._canDelete					= true;
			this._mainGridTitle				= "区分";
			this._detailsGridTitle			= "コード";
			this._defaultGridDisplayLayout	= MGridDisplayLayout.Vertical;

			// 企業コードを取得する
			this._enterpriseCode			= LoginInfoAcquisition.EnterpriseCode;

			// 変数初期化
			this._targetTableName			= "";
			this._mainDataIndex				= -1;
			this._detailsDataIndex			= -1;
			this._noteGuidAcs				= new NoteGuidAcs();
			this._noteGuideHdTable			= new Hashtable();	  
			this._noteGuideBdTable			= new Hashtable();	  
			//GridIndexバッファ（メインフレーム最小化対応）
			this._detailsIndexBuf			= -2;
			this._mainIndexBuf				= -2;
			this._targetTableBuf			= "";
			this._mainGridIcon				= null;	
			this._detailsGridIcon			= null;	
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFTOK09400UA));
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.NoteGuideDivCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Details_DataSet = new System.Data.DataSet();
            this.Bind_DataSet = new System.Data.DataSet();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.NoteGuideDivName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.NoteGuideDivName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Body_Panel = new System.Windows.Forms.Panel();
            this.NoteGuideName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.NoteGuideCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.NoteGuideName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.NoteGuideCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.NoteGuideDivCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Button_Panel = new System.Windows.Forms.Panel();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.tMemPos = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Details_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteGuideDivName_tEdit)).BeginInit();
            this.Body_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NoteGuideName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteGuideCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteGuideDivCode_tNedit)).BeginInit();
            this.Button_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 231);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(484, 23);
            this.ultraStatusBar1.TabIndex = 1;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(376, 8);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 10;
            this.Mode_Label.Text = "更新モード";
            // 
            // NoteGuideDivCode_uLabel
            // 
            this.NoteGuideDivCode_uLabel.Location = new System.Drawing.Point(12, 42);
            this.NoteGuideDivCode_uLabel.Name = "NoteGuideDivCode_uLabel";
            this.NoteGuideDivCode_uLabel.Size = new System.Drawing.Size(88, 23);
            this.NoteGuideDivCode_uLabel.TabIndex = 17;
            this.NoteGuideDivCode_uLabel.Text = "ガイド区分";
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
            // NoteGuideDivName_tEdit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NoteGuideDivName_tEdit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            this.NoteGuideDivName_tEdit.Appearance = appearance9;
            this.NoteGuideDivName_tEdit.AutoSelect = true;
            this.NoteGuideDivName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.NoteGuideDivName_tEdit.DataText = "";
            this.NoteGuideDivName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.NoteGuideDivName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.NoteGuideDivName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.NoteGuideDivName_tEdit.Location = new System.Drawing.Point(135, 71);
            this.NoteGuideDivName_tEdit.MaxLength = 20;
            this.NoteGuideDivName_tEdit.Name = "NoteGuideDivName_tEdit";
            this.NoteGuideDivName_tEdit.Size = new System.Drawing.Size(337, 24);
            this.NoteGuideDivName_tEdit.TabIndex = 152;
            // 
            // NoteGuideDivName_uLabel
            // 
            this.NoteGuideDivName_uLabel.Location = new System.Drawing.Point(12, 75);
            this.NoteGuideDivName_uLabel.Name = "NoteGuideDivName_uLabel";
            this.NoteGuideDivName_uLabel.Size = new System.Drawing.Size(117, 23);
            this.NoteGuideDivName_uLabel.TabIndex = 151;
            this.NoteGuideDivName_uLabel.Text = "ガイド区分名";
            // 
            // Body_Panel
            // 
            this.Body_Panel.Controls.Add(this.NoteGuideName_tEdit);
            this.Body_Panel.Controls.Add(this.NoteGuideCode_tNedit);
            this.Body_Panel.Controls.Add(this.NoteGuideName_uLabel);
            this.Body_Panel.Controls.Add(this.NoteGuideCode_uLabel);
            this.Body_Panel.Controls.Add(this.ultraLabel1);
            this.Body_Panel.Location = new System.Drawing.Point(4, 96);
            this.Body_Panel.Name = "Body_Panel";
            this.Body_Panel.Size = new System.Drawing.Size(476, 80);
            this.Body_Panel.TabIndex = 153;
            // 
            // NoteGuideName_tEdit
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NoteGuideName_tEdit.ActiveAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.NoteGuideName_tEdit.Appearance = appearance5;
            this.NoteGuideName_tEdit.AutoSelect = true;
            this.NoteGuideName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.NoteGuideName_tEdit.DataText = "";
            this.NoteGuideName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.NoteGuideName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.NoteGuideName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.NoteGuideName_tEdit.Location = new System.Drawing.Point(132, 48);
            this.NoteGuideName_tEdit.MaxLength = 20;
            this.NoteGuideName_tEdit.Name = "NoteGuideName_tEdit";
            this.NoteGuideName_tEdit.Size = new System.Drawing.Size(337, 24);
            this.NoteGuideName_tEdit.TabIndex = 152;
            // 
            // NoteGuideCode_tNedit
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance6.TextHAlignAsString = "Right";
            this.NoteGuideCode_tNedit.ActiveAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Right";
            this.NoteGuideCode_tNedit.Appearance = appearance7;
            this.NoteGuideCode_tNedit.AutoSelect = true;
            this.NoteGuideCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.NoteGuideCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.NoteGuideCode_tNedit.DataText = "";
            this.NoteGuideCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.NoteGuideCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.NoteGuideCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.NoteGuideCode_tNedit.Location = new System.Drawing.Point(132, 16);
            this.NoteGuideCode_tNedit.MaxLength = 4;
            this.NoteGuideCode_tNedit.Name = "NoteGuideCode_tNedit";
            this.NoteGuideCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.NoteGuideCode_tNedit.Size = new System.Drawing.Size(44, 24);
            this.NoteGuideCode_tNedit.TabIndex = 151;
            // 
            // NoteGuideName_uLabel
            // 
            this.NoteGuideName_uLabel.Location = new System.Drawing.Point(8, 52);
            this.NoteGuideName_uLabel.Name = "NoteGuideName_uLabel";
            this.NoteGuideName_uLabel.Size = new System.Drawing.Size(85, 23);
            this.NoteGuideName_uLabel.TabIndex = 153;
            this.NoteGuideName_uLabel.Text = "ガイド名";
            // 
            // NoteGuideCode_uLabel
            // 
            this.NoteGuideCode_uLabel.Location = new System.Drawing.Point(8, 20);
            this.NoteGuideCode_uLabel.Name = "NoteGuideCode_uLabel";
            this.NoteGuideCode_uLabel.Size = new System.Drawing.Size(104, 23);
            this.NoteGuideCode_uLabel.TabIndex = 150;
            this.NoteGuideCode_uLabel.Text = "ガイドコード";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel1.Location = new System.Drawing.Point(4, 8);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(464, 3);
            this.ultraLabel1.TabIndex = 149;
            // 
            // NoteGuideDivCode_tNedit
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.TextHAlignAsString = "Right";
            this.NoteGuideDivCode_tNedit.ActiveAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            this.NoteGuideDivCode_tNedit.Appearance = appearance3;
            this.NoteGuideDivCode_tNedit.AutoSelect = true;
            this.NoteGuideDivCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.NoteGuideDivCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.NoteGuideDivCode_tNedit.DataText = "";
            this.NoteGuideDivCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.NoteGuideDivCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.NoteGuideDivCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.NoteGuideDivCode_tNedit.Location = new System.Drawing.Point(136, 36);
            this.NoteGuideDivCode_tNedit.MaxLength = 4;
            this.NoteGuideDivCode_tNedit.Name = "NoteGuideDivCode_tNedit";
            this.NoteGuideDivCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.NoteGuideDivCode_tNedit.Size = new System.Drawing.Size(44, 24);
            this.NoteGuideDivCode_tNedit.TabIndex = 154;
            // 
            // Button_Panel
            // 
            this.Button_Panel.Controls.Add(this.Revive_Button);
            this.Button_Panel.Controls.Add(this.Delete_Button);
            this.Button_Panel.Controls.Add(this.Cancel_Button);
            this.Button_Panel.Controls.Add(this.Ok_Button);
            this.Button_Panel.Location = new System.Drawing.Point(92, 180);
            this.Button_Panel.Name = "Button_Panel";
            this.Button_Panel.Size = new System.Drawing.Size(388, 48);
            this.Button_Panel.TabIndex = 155;
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(134, 8);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 6;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(8, 8);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 5;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(260, 8);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 7;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(134, 8);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 4;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // tMemPos
            // 
            this.tMemPos.OwnerForm = this;
            // 
            // SFTOK09400UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(484, 254);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Button_Panel);
            this.Controls.Add(this.NoteGuideDivCode_tNedit);
            this.Controls.Add(this.Body_Panel);
            this.Controls.Add(this.NoteGuideDivName_tEdit);
            this.Controls.Add(this.NoteGuideDivName_uLabel);
            this.Controls.Add(this.NoteGuideDivCode_uLabel);
            this.Controls.Add(this.Mode_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFTOK09400UA";
            this.Text = "備考設定";
            this.Load += new System.EventHandler(this.SFTOK09400UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFTOK09400UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFTOK09400UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Details_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteGuideDivName_tEdit)).EndInit();
            this.Body_Panel.ResumeLayout(false);
            this.Body_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NoteGuideName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteGuideCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteGuideDivCode_tNedit)).EndInit();
            this.Button_Panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		# region ■Private Members
		private NoteGuidAcs _noteGuidAcs;
		private string _enterpriseCode;
		private Hashtable _noteGuideHdTable;
		private Hashtable _noteGuideBdTable;
		//_GridIndexバッファ（メインフレーム最小化対応）
		private int _detailsIndexBuf;
		private int _mainIndexBuf;
		private string _targetTableBuf;

        // 2009.03.26 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.26 30413 犬飼 新規モードからモード変更対応 <<<<<<END

		/// <summary>入力フォーム起動モード_区分</summary>
		private const int DISPMODE_DIV = 0;
		/// <summary>入力フォーム起動モード_コード</summary>
		private const int DISPMODE_CODE = 1;

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
		// FrameのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
		private const string NOTE_GUIDE_DIVCODE_TITLE = "ガイド区分";
        private const string NOTE_GUIDE_DIVNAME_TITLE = "ガイド区分名"; // MOD 2008/10/09 不具合対応[6326] "ガイド区分名称"→"ガイド区分名"
		private const string NOTE_GUID_HD_TABLE		  = "NOTEGUIDHD";
        private const string NOTE_GUIDE_DIVCODE_FORMAT= "0000";         // ADD 2008/10/09 不具合対応[6325]

		private const string DELETEDATE_TITLE		  = "削除日";
		private const string NOTE_GUIDE_CODE_TITLE	  = "ガイドコード";
        private const string NOTE_GUIDE_NAME_TITLE    = "ガイド名";     // MOD 2008/10/09 不具合対応[6326] "ガイド名称"→"ガイド名"
		private const string NOTE_GUID_BD_TABLE		  = "NOTEGUIDBD";
        private const string NOTE_GUIDE_CODE_FORMAT   = "0000";         // ADD 2008/10/09 不具合対応[6325]

		// 編集モード
		private const string INSERT_MODE			= "新規モード";
		private const string UPDATE_MODE			= "更新モード";
		private const string DELETE_MODE			= "削除モード";

		// 比較用clone
		private NoteGuidHd _noteGuidHdClone;
		private NoteGuidBd _noteGuidBdClone;

		// Message関連定義
		private const string ASSEMBLY_ID	= "SFTOK09400U";
		private const string ERR_READ_MSG	= "読み込みに失敗しました。";
		private const string ERR_DPR_MSG	= "このコードは既に使用されています。";
		private const string ERR_RDEL_MSG	= "削除に失敗しました。";
		private const string ERR_UPDT_MSG	= "登録に失敗しました。";
		private const string ERR_RVV_MSG	= "復活に失敗しました。";
		private const string ERR_800_MSG	= "既に他端末より更新されています";
		private const string ERR_801_MSG	= "既に他端末より削除されています";
		# endregion

		# region ※Main

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			System.Windows.Forms.Application.Run(new SFTOK09400UA());
		}

		# endregion
		
		# region ■IMasterMaintenanceArrayTypeメンバー

		# region ▼Events

		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;

		# endregion

		# region ▼Properties

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
		/// <value>捜査対象データのテーブル名称を取得または設定します。</value>
		public string TargetTableName
		{
			get{ return this._targetTableName; }
			set{  this._targetTableName = value; }
		}

		# endregion

		# region ▼Public Methods

		/// <summary>
		/// 論理削除データ抽出可能設定リスト取得処理
		/// </summary>
		/// <returns>論理削除データ抽出可能設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 論理削除データの抽出が可能かどうかの設定を配列で取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public bool[] GetCanLogicalDeleteDataExtractionList()
		{
			bool[] blRet	= new bool[2];
			blRet[0] = true;    // MOD 2009/03/24 不具合対応[12690]：「削除済データの表示」は最上位項目で制御 false→true
            blRet[1] = false;   // MOD 2009/03/24 不具合対応[12690]：「削除済データの表示」は最上位項目で制御 true→false
			return blRet; 
		}

		/// <summary>
		/// グリッドタイトルリスト取得処理
		/// </summary>
		/// <returns>グリッドタイトルリスト</returns>
		/// <remarks>
		/// <br>Note       : グリッドのタイトルを配列で取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
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
		/// <br>Date       : 2005.10.14</br>
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
		/// <br>Date       : 2005.10.14</br>
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
		/// <br>Date       : 2005.10.14</br>
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
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public bool[] GetNewButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= true;

			return blRet;
		}

		/// <summary>
		/// 修正ボタンの有効設定リスト取得処理
		/// </summary>
		/// <returns>修正ボタンの有効設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public bool[] GetModifyButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= true;
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
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public bool[] GetDeleteButtonEnabledList()
		{
			bool[] blRet	= new bool[2];
			blRet[0]		= false;
			blRet[1]		= true;

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
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		/// 
		public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
		{
			bindDataSet = this.Bind_DataSet;

			string[] strRet	= new string[2];
			strRet[0]		= NOTE_GUID_HD_TABLE;
			strRet[1]		= NOTE_GUID_BD_TABLE;
			tableName		= strRet;
		}

		/// <summary>
		/// 備考ガイド（ヘッダ）レコード検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 先頭から指定件数分の備考ガイド（ヘッダ）レコードを検索し、
		///					 抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			ArrayList noteGuidHdList = null;

			int status = this._noteGuidAcs.SearchHeader(out noteGuidHdList, this._enterpriseCode);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					int index = 0;
					foreach (NoteGuidHd noteGuidHd in noteGuidHdList)
					{
						NoteGuidHdToDataSet(noteGuidHd.Clone(), index);
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
						ERR_READ_MSG,						  // 表示するメッセージ 
						status,								  // ステータス値
						this._noteGuidAcs,					  // エラーが発生したオブジェクト
						MessageBoxButtons.OK,				  // 表示するボタン
						MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

					break;
				}
			}

			totalCount = noteGuidHdList.Count;

            // メインテーブルの削除日をサブテーブルから設定（メインテーブルの削除日の設定用）
            SetDeleteDateOfMainTable(); // ADD 2009/03/24 不具合対応[12690]：「削除済データの表示」は最上位項目で制御

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
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			// 実装なし
			return 9;
		}

		/// <summary>
		/// 備考ガイド（ボディ）レコード検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 先頭から指定件数分の備考ガイド（ボディ）レコードを検索し、
		///					 抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public int DetailsDataSearch(ref int totalCount, int readCount)
		{
			ArrayList noteGuidBdList = null;
			string hashKey;

            // ADD 2009/03/24 不具合対応[12690]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // readCountが負の場合、強制終了
            if (readCount < 0)
            {
                this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows.Clear();
                return 0;
            }
            // ADD 2009/03/24 不具合対応[12690]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

			this._detailsIndexBuf = -2;
			this._targetTableBuf  = "";

			// Bufferが無い場合リモート
			if (this._noteGuideBdTable.Count == 0)
			{
				int status = this._noteGuidAcs.SearchAllBody(out noteGuidBdList, this._enterpriseCode);

                // 備考ガイドをキャッシュ
                CacheNoteGuidBdList(noteGuidBdList);    // ADD 2009/03/24 不具合対応[12690]：「削除済データの表示」は最上位項目で制御

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						foreach(NoteGuidBd noteGuidBd in noteGuidBdList)
						{
							hashKey = noteGuidBd.NoteGuideDivCode.ToString() + "_" + noteGuidBd.NoteGuideCode.ToString();
							this._noteGuideBdTable.Add(hashKey, noteGuidBd.Clone());
						}

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						return status;
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
							ERR_READ_MSG,						  // 表示するメッセージ 
							status,								  // ステータス値
							this._noteGuidAcs,					  // エラーが発生したオブジェクト
							MessageBoxButtons.OK,				  // 表示するボタン
							MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

						return status;
					}
				}
			}

			this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows.Clear();

			SortedList sortList = new SortedList();
			foreach (NoteGuidBd noteGuidBd in this._noteGuideBdTable.Values)
			{
				if ((int)this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows[this._mainDataIndex][NOTE_GUIDE_DIVCODE_TITLE] == noteGuidBd.NoteGuideDivCode)
				{
					sortList.Add(noteGuidBd.NoteGuideCode, noteGuidBd.Clone());
				}
			}

			int index = 0;
			foreach (NoteGuidBd noteGuidBd in sortList.Values)
			{
				NoteGuidBdToDataSet(noteGuidBd, index);
				++index;
			}

			totalCount = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows.Count;

            // メインテーブルの削除日をサブテーブルから設定
            SetDeleteDateOfMainTable(); // ADD 2009/03/24 不具合対応[12690]：「削除済データの表示」は最上位項目で制御

			return 0;
		}

		/// <summary>
		/// 明細ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public int DetailsDataSearchNext(int readCount)
		{
			// 未実装
			return 9;
		}

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを削除します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public int Delete()
		{
			string hashKey = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_DIVCODE_TITLE].ToString()
				+ "_" + this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_CODE_TITLE].ToString();
			NoteGuidBd noteGuidBd = ((NoteGuidBd)this._noteGuideBdTable[hashKey]).Clone();

			int status = this._noteGuidAcs.LogicalDelete(ref noteGuidBd);
			
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status, TMsgDisp.OPE_HIDE, this._noteGuidAcs);
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
						ERR_RDEL_MSG,						// 表示するメッセージ 
						status,								// ステータス値
						this._noteGuidAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン

					return status;
				}
			}

			NoteGuidBdToDataSet(noteGuidBd.Clone(), this._detailsDataIndex);

            // 備考ガイドのキャッシュを初期化（メインテーブルの削除日の設定用）
            InitializeCacheNoteGuidBdList();    // ADD 2009/03/24 不具合対応[12690]：「削除済データの表示」は最上位項目で制御

			return status;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public int Print()
		{
			// 印刷機能無しの為未実装
			return 0;
		}

		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		public void GetAppearanceTable(out Hashtable[] appearanceTable)
		{
			// MainGrid
			Hashtable main = new Hashtable();
            main.Add(DELETEDATE_TITLE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));   // ADD 2009/03/24 不具合対応[12690]：「削除済データの表示」は最上位項目で制御
            main.Add(NOTE_GUIDE_DIVCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, NOTE_GUIDE_DIVCODE_FORMAT, Color.Black));     // MOD 2008/10/09 不具合対応[6325] ""→NOTE_GUIDE_DIVCODE_FORMAT
			main.Add(NOTE_GUIDE_DIVNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft,  "", Color.Black));

			// DetailsGrid
			Hashtable details = new Hashtable();
			details.Add(DELETEDATE_TITLE,		  new GridColAppearance(MGridColDispType.DeletionDataBoth,ContentAlignment.MiddleLeft,"",Color.Red));
            details.Add(NOTE_GUIDE_DIVCODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, NOTE_GUIDE_DIVCODE_FORMAT, Color.Black));  // MOD 2008/10/09 不具合対応[6325] ""→NOTE_GUIDE_DIVCODE_FORMAT
			details.Add(NOTE_GUIDE_DIVNAME_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft,  "", Color.Black));
            details.Add(NOTE_GUIDE_CODE_TITLE,    new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, NOTE_GUIDE_CODE_FORMAT, Color.Black));     // MOD 2008/10/09 不具合対応[6325] ""→NOTE_GUIDE_CODE_FORMAT
			details.Add(NOTE_GUIDE_NAME_TITLE,	  new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft,  "", Color.Black));

			appearanceTable = new Hashtable[2];
			appearanceTable[0] = main;
			appearanceTable[1] = details;
		}

		# endregion

		# endregion

		# region ■Private Methods

		/// <summary>
		/// 備考オブジェクトデータセット展開処理 (ヘッダ)
		/// </summary>
		/// <param name="noteGuidHd">備考オブジェクト（ヘッダ）</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note       : 備考データクラス（ヘッダ）をデータセットに格納します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void NoteGuidHdToDataSet(NoteGuidHd noteGuidHd, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].NewRow();
				this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows.Add(dataRow);

				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows.Count - 1;
			}

			// DataTableにデータをセット
            this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows[index][DELETEDATE_TITLE] = GetDeleteDate(noteGuidHd); // ADD 2008/03/24 不具合対応[12690]：「削除済データの表示」は最上位項目で制御
			this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows[index][NOTE_GUIDE_DIVCODE_TITLE] = noteGuidHd.NoteGuideDivCode;
			this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows[index][NOTE_GUIDE_DIVNAME_TITLE] = noteGuidHd.NoteGuideDivName;

			int hashKey = noteGuidHd.NoteGuideDivCode;
			// HashTableにデータをセット
			if (this._noteGuideHdTable.ContainsKey(hashKey))
			{
				this._noteGuideHdTable.Remove(hashKey);
			}
			this._noteGuideHdTable.Add(hashKey, noteGuidHd);
		}

        // ADD 2009/03/24 不具合対応[12690]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
        #region <備考ガイドのキャッシュ/>

        /// <summary>備考ガイドのキャッシュ</summary>
        /// <remarks>キー：備考ガイド区分コード</remarks>
        private readonly IDictionary<int, ArrayList> _noteGuidBdListCacheMap = new Dictionary<int, ArrayList>();
        /// <summary>
        /// 備考ガイドのキャッシュを取得します。
        /// </summary>
        private IDictionary<int, ArrayList> NoteGuidBdListCacheMap
        {
            get { return _noteGuidBdListCacheMap; }
        }

        /// <summary>
        /// 備考ガイドをキャッシュします。
        /// </summary>
        /// <param name="allNoteGuidBdList">全備考ガイドのレコードリスト</param>
        private void CacheNoteGuidBdList(ArrayList allNoteGuidBdList)
        {
            if (allNoteGuidBdList == null) return;

            // 備考ガイド区分コード別に分別
            NoteGuidBdListCacheMap.Clear();
            foreach (NoteGuidBd noteGuidBd in allNoteGuidBdList)
            {
                int noteGuideDivCode = noteGuidBd.NoteGuideDivCode;
                if (!NoteGuidBdListCacheMap.ContainsKey(noteGuideDivCode))
                {
                    NoteGuidBdListCacheMap.Add(noteGuideDivCode, new ArrayList());
                }
                NoteGuidBdListCacheMap[noteGuideDivCode].Add(noteGuidBd);
            }
        }

        /// <summary>
        /// 備考ガイドのキャッシュを初期化します。
        /// </summary>
        private void InitializeCacheNoteGuidBdList()
        {
            ArrayList noteGuidBdList = null;
            int status = this._noteGuidAcs.SearchAllBody(out noteGuidBdList, this._enterpriseCode);
            CacheNoteGuidBdList(noteGuidBdList);
        }

        #endregion  // <備考ガイドのキャッシュ/>

        /// <summary>
        /// メインテーブルの削除日を取得します。
        /// </summary>
        /// <param name="noteGuidHd"></param>
        /// <returns>削除日（削除されたレコードでは無い場合、<c>string.Empty</c>を返します。）</returns>
        private string GetDeleteDate(NoteGuidHd noteGuidHd)
        {
            if (noteGuidHd.LogicalDeleteCode.Equals(0))
            {
                return string.Empty;
            }
            else
            {
                return noteGuidHd.UpdateDateTimeJpInFormal;
            }
        }

        /// <summary>
        /// メインテーブルの削除日を設定します。
        /// </summary>
        [Conditional("DELETE_DATE_DEPEND_ON_SUB_TABLE")]
        private void SetDeleteDateOfMainTable()
        {
            const string MAIN_TABLE_NAME        = NOTE_GUID_HD_TABLE;
            const string RELATION_COLUMN_NAME   = NOTE_GUIDE_DIVCODE_TITLE;
            const string SUB_TABLE_NAME         = NOTE_GUID_BD_TABLE;
            const string DELETE_DATE_COLUMN_NAME= DELETEDATE_TITLE;

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

                    // 備考ガイド区分コード指定 車種名称検索処理（論理削除含む）
                    ArrayList noteGuidBdList = null;
                    if (NoteGuidBdListCacheMap.ContainsKey(relationColumn))
                    {
                        noteGuidBdList = NoteGuidBdListCacheMap[relationColumn];
                    }
                    else
                    {
                        int status = this._noteGuidAcs.SearchAllBody(out noteGuidBdList, this._enterpriseCode);
                        CacheNoteGuidBdList(noteGuidBdList);
                    }
                    if (noteGuidBdList == null || noteGuidBdList.Count.Equals(0)) continue;

                    // 削除日を降順で抽出
                    int deleteRowCount = 0;
                    SortedList<string, string> sortedDeleteDateList = new SortedList<string, string>(
                        new ReverseComparer<string>()
                    );
                    foreach (NoteGuidBd noteGuidBd in noteGuidBdList)
                    {
                        if (noteGuidBd.LogicalDeleteCode.Equals(0)) continue;

                        deleteRowCount++;
                        if (!sortedDeleteDateList.ContainsKey(noteGuidBd.UpdateDateTimeJpInFormal))
                        {
                            sortedDeleteDateList.Add(
                                noteGuidBd.UpdateDateTimeJpInFormal,
                                noteGuidBd.UpdateDateTimeJpInFormal
                            );
                        }
                    }

                    // レコードが全件削除されている場合
                    string deleteDate = string.Empty;
                    if (deleteRowCount > 0 && deleteRowCount.Equals(noteGuidBdList.Count))
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
                    mainRow[DELETEDATE_TITLE] = deleteDate;

                    #endregion  // サブテーブルに該当レコードがある場合、サブテーブルより設定
                }
            }
        }
        // ADD 2009/03/24 不具合対応[12690]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

		/// <summary>
		/// 備考オブジェクトデータセット展開処理 (ボディ)
		/// </summary>
		/// <param name="noteGuidBd">備考オブジェクト（ボディ）</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note       : 備考データクラス（ボディ）をデータセットに格納します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void NoteGuidBdToDataSet(NoteGuidBd noteGuidBd, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].NewRow();
				this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows.Add(dataRow);

				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows.Count - 1;
			}

			// DataTableにデータをセット
			if (noteGuidBd.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[index][DELETEDATE_TITLE] = "";
			}
			else
			{
				this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[index][DELETEDATE_TITLE] = noteGuidBd.UpdateDateTimeJpInFormal;
			}
		
			this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[index][NOTE_GUIDE_DIVCODE_TITLE] = noteGuidBd.NoteGuideDivCode;
			this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[index][NOTE_GUIDE_NAME_TITLE]	   = noteGuidBd.NoteGuideDivName;
			this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[index][NOTE_GUIDE_CODE_TITLE]	   = noteGuidBd.NoteGuideCode;
			this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[index][NOTE_GUIDE_NAME_TITLE]	   = noteGuidBd.NoteGuideName;

			string hashKey = noteGuidBd.NoteGuideDivCode.ToString() 
				+ "_" + noteGuidBd.NoteGuideCode.ToString();

			// HashTable更新
			this._noteGuideBdTable[hashKey] = noteGuidBd;
		}

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			// ヘッダレコード用テーブル
			DataTable noteGuideHdTable = new DataTable(NOTE_GUID_HD_TABLE);

			// Addを行う順番が、列の表示順位となります。
            noteGuideHdTable.Columns.Add(DELETEDATE_TITLE, typeof(string)); // ADD 2008/03/24 不具合対応[12690]：「削除済データの表示」は最上位項目で制御
			noteGuideHdTable.Columns.Add(NOTE_GUIDE_DIVCODE_TITLE, typeof(int));
			noteGuideHdTable.Columns.Add(NOTE_GUIDE_DIVNAME_TITLE, typeof(string));

			this.Bind_DataSet.Tables.Add(noteGuideHdTable);

			// ボディレコード用テーブル
			DataTable noteGuideBdTable = new DataTable(NOTE_GUID_BD_TABLE);

			// Addを行う順番が、列の表示順位となります。
			noteGuideBdTable.Columns.Add(DELETEDATE_TITLE,		   typeof(string));
			noteGuideBdTable.Columns.Add(NOTE_GUIDE_DIVCODE_TITLE, typeof(int));
			noteGuideBdTable.Columns.Add(NOTE_GUIDE_DIVNAME_TITLE, typeof(string));
			noteGuideBdTable.Columns.Add(NOTE_GUIDE_CODE_TITLE,	   typeof(int));
			noteGuideBdTable.Columns.Add(NOTE_GUIDE_NAME_TITLE,	   typeof(string));

			this.Bind_DataSet.Tables.Add(noteGuideBdTable);
		}

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			// UI画面表示時のチラつきを抑える為に、ここでサイズ等変更
			switch (this._targetTableName)
			{
				// ヘッダ
				case NOTE_GUID_HD_TABLE:
				{
					// 画面サイズ/ロケーション設定
					this.SetFormLocationAndSize(DISPMODE_DIV);
					// 更新モード
					this.Mode_Label.Text = UPDATE_MODE;
					// 画面入力許可制御
					ScreenInputPermissionControl(1);

					break;
				}
				// ボディ
				case NOTE_GUID_BD_TABLE:
				{
					// 画面サイズ/ロケーション設定
					this.SetFormLocationAndSize(DISPMODE_CODE);

					// 新規の場合
					if (this._detailsDataIndex < 0)
					{
						// 画面入力許可制御
						ScreenInputPermissionControl(2);
						break;
					}
					// 削除の場合
					if((string)this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][DELETEDATE_TITLE] != "")
					{
						// 画面入力許可制御
						ScreenInputPermissionControl(4);
						break;
					}
						// 更新の場合
					else
					{
						// 画面入力許可制御
						ScreenInputPermissionControl(3);
						break;
					}
				}
			}		
		}

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void ScreenClear()
		{
			// ヘッダ
			this.NoteGuideDivCode_tNedit.Clear();
			this.NoteGuideDivName_tEdit.Clear();
			this.NoteGuideDivCode_tNedit.Enabled = true;
			this.NoteGuideDivName_tEdit.Enabled = true;
			// ボディ
			this.NoteGuideCode_tNedit.Clear();
			this.NoteGuideName_tEdit.Clear();
			this.NoteGuideCode_tNedit.Enabled = true;
			this.NoteGuideName_tEdit.Enabled = true;
			this.Body_Panel.Visible = true;
			// ボタン
			this.Button_Panel.Visible = true;
			this.Ok_Button.Visible = true;
			this.Revive_Button.Visible = true;
			this.Delete_Button.Visible = true;
			// モードラベル
			this.Mode_Label.Text = INSERT_MODE;
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			switch (this._targetTableName)
			{
				// ヘッダ
				case NOTE_GUID_HD_TABLE:
				{
					NoteGuidHd noteGuidHd = new NoteGuidHd();
					
					// 更新モード
					this.Mode_Label.Text = UPDATE_MODE;

					// 表示情報取得
					int hashKey = (int)this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows[this._mainDataIndex][NOTE_GUIDE_DIVCODE_TITLE];
					noteGuidHd = (NoteGuidHd)this._noteGuideHdTable[hashKey];
						
					// 画面展開処理
					NoteGuidHdToScreen(noteGuidHd);
						
					// クローン作成
					this._noteGuidHdClone = noteGuidHd.Clone(); 
					DispToNoteGuidHd(ref this._noteGuidHdClone);
						
					// フォーカス設定
					this.NoteGuideDivName_tEdit.SelectAll();

					break;
				}
				// ボディ
				case NOTE_GUID_BD_TABLE:
				{
					NoteGuidBd noteGuidBd = new NoteGuidBd();
			
					// 新規の場合
					if (this._detailsDataIndex < 0)
					{
						// 表示情報取得
						int hashKey = (int)this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows[this._mainDataIndex][NOTE_GUIDE_DIVCODE_TITLE];
						NoteGuidHd noteGuidHd = (NoteGuidHd)this._noteGuideHdTable[hashKey];
						
						// 画面展開処理
						NoteGuidHdToScreen(noteGuidHd);
						
						// クローン作成
						DispToNoteGuidBd(ref noteGuidBd);
						this._noteGuidBdClone = noteGuidBd; 
						
						// フォーカス設定
						this.NoteGuideCode_tNedit.Focus();
			
						break;
					}
					// 削除の場合
					if ((string)this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][DELETEDATE_TITLE] != "")
					{
						// 削除モード
						this.Mode_Label.Text = DELETE_MODE;
						
						// 表示情報取得
						string hashKey = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_DIVCODE_TITLE].ToString()
							+ "_" + this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_CODE_TITLE].ToString(); 
						noteGuidBd = (NoteGuidBd)this._noteGuideBdTable[hashKey];
						
						// 画面展開処理
						NoteGuidBdToScreen(noteGuidBd);
	
						break;
					}
					// 更新の場合
					else
					{
						// 更新モード
						this.Mode_Label.Text = UPDATE_MODE;

						// 表示情報取得
						string hashKey = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_DIVCODE_TITLE].ToString()
							+ "_" + this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_CODE_TITLE].ToString(); 
						noteGuidBd = (NoteGuidBd)this._noteGuideBdTable[hashKey];
						
						// 画面展開処理
						NoteGuidBdToScreen(noteGuidBd);
						
						// クローン作成
						this._noteGuidBdClone = noteGuidBd.Clone(); 
						DispToNoteGuidBd(ref this._noteGuidBdClone);
						
						// フォーカス設定
						this.NoteGuideName_tEdit.SelectAll();

						break;
					}
				}
			}		
			//_GridIndexバッファ保持
			this._detailsIndexBuf	= this._detailsDataIndex;
			this._mainIndexBuf		= this._mainDataIndex;
			this._targetTableBuf	= this._targetTableName;
		}

		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <param name="setType">設定タイプ 1:ヘッダ-更新, 2:ボディ-新規, 3:ボディ-更新, 4:ボディ-削除</param>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void ScreenInputPermissionControl(int setType)
		{
			switch (setType)
			{
					// 1:ヘッダ-更新
				case 1:
				{
					this.NoteGuideDivCode_tNedit.Enabled = false;
					this.Body_Panel.Visible = false;
					this.Revive_Button.Visible = false;
					this.Delete_Button.Visible = false;
					break;
				}
					// 2:ボディ-新規
				case 2:
				{
					this.NoteGuideDivCode_tNedit.Enabled = false;
					this.NoteGuideDivName_tEdit.Enabled = false;
					this.Revive_Button.Visible = false;
					this.Delete_Button.Visible = false;
					break;
				}
					// 3:ボディ-更新
				case 3:
				{
					this.NoteGuideDivCode_tNedit.Enabled = false;
					this.NoteGuideDivName_tEdit.Enabled = false;
					this.NoteGuideCode_tNedit.Enabled = false;
					this.Revive_Button.Visible = false;
					this.Delete_Button.Visible = false;
					break;
				}
					// 4:ボディ-削除
				case 4:
				{
					this.NoteGuideDivCode_tNedit.Enabled = false;
					this.NoteGuideDivName_tEdit.Enabled = false;
					this.NoteGuideCode_tNedit.Enabled = false;
					this.NoteGuideName_tEdit.Enabled = false; 
					this.Ok_Button.Visible = false;
					break;
				}
			}
		}

		/// <summary>
		/// 備考クラス（ヘッダ）画面展開処理
		/// </summary>
		/// <param name="noteGuidHd">備考オブジェクト（ヘッダ）</param>
		/// <remarks>
		/// <br>Note       : 備考オブジェクト（ヘッダ）から画面にデータを展開します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void NoteGuidHdToScreen(NoteGuidHd noteGuidHd)
		{
			this.NoteGuideDivCode_tNedit.SetInt(noteGuidHd.NoteGuideDivCode);
			this.NoteGuideDivName_tEdit.Text = noteGuidHd.NoteGuideDivName;
		}									

		/// <summary>
		/// 備考クラス（ボディ）画面展開処理
		/// </summary>
		/// <param name="noteGuidBd">備考オブジェクト（ボディ）</param>
		/// <remarks>
		/// <br>Note       : 備考オブジェクト（ボディ）から画面にデータを展開します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void NoteGuidBdToScreen(NoteGuidBd noteGuidBd)
		{
			this.NoteGuideDivCode_tNedit.SetInt(noteGuidBd.NoteGuideDivCode);
			this.NoteGuideDivName_tEdit.Text = this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows[this._mainDataIndex][NOTE_GUIDE_DIVNAME_TITLE].ToString();
			
			this.NoteGuideCode_tNedit.SetInt(noteGuidBd.NoteGuideCode);
			this.NoteGuideName_tEdit.Text = noteGuidBd.NoteGuideName;
		}									

		/// <summary>
		/// 画面情報備考クラス（ヘッダ）格納処理
		/// </summary>
		/// <param name="noteGuidHd">備考オブジェクト（ヘッダ）</param>
		/// <remarks>
		/// <br>Note       : 画面情報から備考オブジェクト（ヘッダ）にデータを格納します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void DispToNoteGuidHd(ref NoteGuidHd noteGuidHd)
		{
			if (noteGuidHd == null)
			{
				// 新規の場合
				noteGuidHd = new NoteGuidHd();
			}													  

			noteGuidHd.EnterpriseCode	= this._enterpriseCode;	
			noteGuidHd.NoteGuideDivCode	= this.NoteGuideDivCode_tNedit.GetInt();
			noteGuidHd.NoteGuideDivName	= this.NoteGuideDivName_tEdit.Text;
		}

		/// <summary>
		/// 画面情報備考クラス（ボディ）格納処理
		/// </summary>
		/// <param name="noteGuidBd">備考オブジェクト（ボディ）</param>
		/// <remarks>
		/// <br>Note       : 画面情報から備考オブジェクト（ボディ）にデータを格納します。</br>
		/// <br>Programmer : 22033 三崎  貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void DispToNoteGuidBd(ref NoteGuidBd noteGuidBd)
		{
			if (noteGuidBd == null)
			{
				// 新規の場合
				noteGuidBd = new NoteGuidBd();
			}													  

			noteGuidBd.EnterpriseCode	= this._enterpriseCode;	
			noteGuidBd.NoteGuideDivCode	= this.NoteGuideDivCode_tNedit.GetInt();
			noteGuidBd.NoteGuideDivName	= this.NoteGuideDivName_tEdit.Text;
			noteGuidBd.NoteGuideCode	= this.NoteGuideCode_tNedit.GetInt();
			noteGuidBd.NoteGuideName	= this.NoteGuideName_tEdit.Text;
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
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private bool ScreenDataCheck(ref Control control, ref string message)
		{
			bool result = true;

			// ヘッダの場合
			if (this.Body_Panel.Visible == false)
			{
				if (this.NoteGuideDivName_tEdit.Text == "")
				{
					control = this.NoteGuideDivName_tEdit;
					message = this.NoteGuideDivName_uLabel.Text + "を入力して下さい。";
					result	= false;	
				}
			}
			else	// ボディの場合
			{
				if (this.NoteGuideCode_tNedit.GetInt() == 0)
				{
					control = this.NoteGuideCode_tNedit;
					message = this.NoteGuideCode_uLabel.Text + "を入力して下さい。";
					result	= false;
				}
				else if (this.NoteGuideName_tEdit.Text == "")
				{
					control = this.NoteGuideName_tEdit;
					message = this.NoteGuideName_uLabel.Text + "を入力して下さい。";
					result	= false;	
				}
			}

			return result;
		}

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <returns>チェック結果</returns>
		/// <remarks>
		/// <br>Note　　　  : 備考オブジェクトの保存処理を行います。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>
		private bool SaveProc()
		{
			Control control = null;
			string message = null;	

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

			// ヘッダ
			if (this.Body_Panel.Visible == false)
			{
				NoteGuidHd noteGuidHd = null;
				if (this._mainDataIndex >= 0)
				{
					int hashKey = (int)this.Bind_DataSet.Tables[NOTE_GUID_HD_TABLE].Rows[this._mainIndexBuf][NOTE_GUIDE_DIVCODE_TITLE];
					noteGuidHd = ((NoteGuidHd)this._noteGuideHdTable[hashKey]).Clone();
				}

				// 画面情報格納処理
				DispToNoteGuidHd(ref noteGuidHd);

				int status = this._noteGuidAcs.Write(ref noteGuidHd);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						NoteGuidHdToDataSet(noteGuidHd, this._mainIndexBuf);
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
					{
						TMsgDisp.Show( 
							this,								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
							ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
							ERR_DPR_MSG,						// 表示するメッセージ 
							status,								// ステータス値
							MessageBoxButtons.OK);				// 表示するボタン

						this.NoteGuideDivCode_tNedit.Focus();
						return false;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// 排他処理
						ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._noteGuidAcs);

						// UI画面強制終了処理
						EnforcedEndTransaction();
					
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
							ERR_UPDT_MSG,						// 表示するメッセージ 
							status,								// ステータス値
							this._noteGuidAcs,					// エラーが発生したオブジェクト
							MessageBoxButtons.OK,				// 表示するボタン
							MessageBoxDefaultButton.Button1);	// 初期表示ボタン

						// UI子画面強制終了処理
						EnforcedEndTransaction();					
				
						return false;
					}
				}
				// 新規登録時処理
				NewEntryTransaction();
				return true;
			}
			else
			{
				NoteGuidBd noteGuidBd = null;
				if (this._detailsDataIndex >= 0)
				{
					string hashKey = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_DIVCODE_TITLE].ToString()
						+ "_" + this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_CODE_TITLE].ToString();
						noteGuidBd = ((NoteGuidBd)this._noteGuideBdTable[hashKey]).Clone();
				}

				// 画面情報格納処理
				DispToNoteGuidBd(ref noteGuidBd);

				int status = this._noteGuidAcs.Write(ref noteGuidBd);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						NoteGuidBdToDataSet(noteGuidBd, this._detailsDataIndex);
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
					{
						TMsgDisp.Show( 
							this,								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
							ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
							ERR_DPR_MSG,						// 表示するメッセージ 
							status,								// ステータス値
							MessageBoxButtons.OK);				// 表示するボタン

						this.NoteGuideCode_tNedit.Focus();
						return false;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// 排他処理
						ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._noteGuidAcs);

						// UI画面強制終了処理
						EnforcedEndTransaction();
					
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
							ERR_UPDT_MSG,						// 表示するメッセージ 
							status,								// ステータス値
							this._noteGuidAcs,					// エラーが発生したオブジェクト
							MessageBoxButtons.OK,				// 表示するボタン
							MessageBoxDefaultButton.Button1);	// 初期表示ボタン

						// UI画面強制終了処理
						EnforcedEndTransaction();
						return false;
					}
				}
				// 新規登録時処理
				NewEntryTransaction();
				return true;
			}
		}

		/// <summary>
		/// 新規登録時処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 新規登録時の処理を行います。</br>
		/// <br>Programmer : 22033  三崎 貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void NewEntryTransaction ()
		{
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}
			// 新規モードの場合は画面を終了せずに連続入力を可能とする
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				if (TargetTableName == NOTE_GUID_HD_TABLE)
				{
					// データインデックスを初期化する
					this._mainDataIndex = -1;
				}
				// 画面クリア処理
				ScreenClear();
				// 画面初期設定処理
				ScreenInitialSetting();
				// 画面再構築処理
				ScreenReconstruction();
			}
			else
			{
				this.DialogResult = DialogResult.OK;
				this._detailsIndexBuf = -2;
				this._mainIndexBuf = -2;
				this._targetTableBuf = "";

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
						ERR_800_MSG,						// 表示するメッセージ 
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
						ERR_801_MSG,						// 表示するメッセージ 
						status,								// ステータス値
						erObject,							// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					break;
				}
			}
		}

		/// <summary>
		/// UI子画面強制終了処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データ更新エラー時のUI子画面強制終了処理を行います。</br>
		/// <br>Programmer : 22033  三崎 貴史</br>
		/// <br>Date       : 2005.10.14</br>
		/// </remarks>
		private void EnforcedEndTransaction ()
		{
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;
			this._detailsIndexBuf = -2;
			this._mainIndexBuf	  = -2;
			this._targetTableBuf  = "";

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
		/// 入力フォーム画面サイズ/表示位置設定処理
		/// </summary>
		/// <param name="mode">入力フォーム起動モード</param>
		private void SetFormLocationAndSize(int mode)
		{
			// スクリーンサイズの取得
			int width = Screen.PrimaryScreen.Bounds.Width;
			int hight = Screen.PrimaryScreen.Bounds.Height;

			// 区分の場合
			if (mode == DISPMODE_DIV)
			{
				// 入力フォームのサイズ
				this.ClientSize = new Size(484, 180);
				// ボタンパネル移動
				this.Button_Panel.Location = new System.Drawing.Point(88, 105);
			}
			// コードの場合
			else if (mode == DISPMODE_CODE)
			{
				// 入力フォームのサイズ
				this.ClientSize = new Size(484, 250);
				// ボタンパネル移動
				this.Button_Panel.Location = new System.Drawing.Point(88, 180);
			}

			// 入力フォームのロケーション
            //this.Location = new Point((width / 2) - (this.Size.Width / 2), (hight / 2) - (this.Size.Height / 2)); // DEL 2008/09/11
		}
		# endregion

		# region ■Control Events

		/// <summary>
		/// Form.Load イベント(SFTOK09400UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>
		private void SFTOK09400UA_Load(object sender, System.EventArgs e)
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

			// 画面初期設定処理
			ScreenInitialSetting();
		}

		/// <summary>
		/// Form.Closing イベント(SFTOK09400UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note　　　  : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>
		private void SFTOK09400UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._detailsIndexBuf	= -2;
			this._mainIndexBuf		= -2;
			this._targetTableBuf  = "";

			// フォームの「×」をクリックされた場合の対応です。
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}	
		}

		/// <summary>
		/// Control.VisibleChanged イベント(SFTOK09400UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>
		private void SFTOK09400UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				this.Owner.Activate();
				
				return;
			}
			
			if ((this._detailsIndexBuf == this._detailsDataIndex) &&
				(this._mainIndexBuf == this._mainDataIndex) &&
				(this._targetTableBuf == this._targetTableName))
			{
				return;
			}

			// 画面クリア処理
			ScreenClear();
			// 画面初期設定処理
			ScreenInitialSetting();

			Initial_Timer.Enabled = true;
		}

		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// 備考登録処理
			SaveProc();
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>		
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			bool cloneFlg;
			// 削除モード以外の場合は保存確認処理を行う
			if (this.Mode_Label.Text != DELETE_MODE)
			{
				switch (this._targetTableName)
				{
					case NOTE_GUID_HD_TABLE:
					{
						// 現在の画面情報を取得
						NoteGuidHd compareNoteGuidHd = new NoteGuidHd();  
						compareNoteGuidHd = this._noteGuidHdClone.Clone();  
						DispToNoteGuidHd(ref compareNoteGuidHd);
						// 最初に取得した画面情報と比較
						cloneFlg = this._noteGuidHdClone.Equals(compareNoteGuidHd);
						break;
					}
					default:
					{
						// 現在の画面情報を取得
						NoteGuidBd compareNoteGuidBd = new NoteGuidBd();  
						compareNoteGuidBd = this._noteGuidBdClone.Clone();  
						DispToNoteGuidBd(ref compareNoteGuidBd);
						// 最初に取得した画面情報と比較
						cloneFlg = this._noteGuidBdClone.Equals(compareNoteGuidBd);
						break;
					}
				}
				if (!(cloneFlg))
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
							if (SaveProc())
							{
								this.DialogResult = DialogResult.OK;
								break;
							}
							else
							{
								return;
							}
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
                                NoteGuideCode_tNedit.Focus();
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
			this._targetTableBuf = "";

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
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			// 画面再構築処理
			ScreenReconstruction();		
		}

		/// <summary>
		/// Control.Click イベント(Revive_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 復活ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			string hashKey = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_DIVCODE_TITLE]
				+ "_" + this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_CODE_TITLE];
			NoteGuidBd noteGuidBd = ((NoteGuidBd)_noteGuideBdTable[hashKey]).Clone();

			int status = this._noteGuidAcs.Revival(ref noteGuidBd);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					// DataSet展開処理
					NoteGuidBdToDataSet(noteGuidBd, this._detailsDataIndex);
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 排他処理
					ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._noteGuidAcs);
					
					// UI画面強制終了処理
					EnforcedEndTransaction();
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
						ERR_RVV_MSG,						  // 表示するメッセージ 
						status,								  // ステータス値
						this._noteGuidAcs,					  // エラーが発生したオブジェクト
						MessageBoxButtons.OK,				  // 表示するボタン
						MessageBoxDefaultButton.Button1);	  // 初期表示ボタン
					
					// UI画面強制終了処理
					EnforcedEndTransaction();
					
					return;
				}
			}
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;
			this._detailsIndexBuf = -2;
			this._mainIndexBuf = -2;
			this._targetTableBuf = "";

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}

            // 備考ガイドのキャッシュを初期化
            InitializeCacheNoteGuidBdList();    // ADD 2009/03/24 不具合対応[12690]：「削除済データの表示」は最上位項目で制御
		}

		/// <summary>
		/// Control.Click イベント(Delete_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 22033 三崎  貴史</br>
		/// <br>Date        : 2005.10.14</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
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
				string hashKey = this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_DIVCODE_TITLE]
					+ "_" + this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex][NOTE_GUIDE_CODE_TITLE];
				NoteGuidBd noteGuidBd = ((NoteGuidBd)_noteGuideBdTable[hashKey]).Clone();

				int status = this._noteGuidAcs.Delete(noteGuidBd);
				
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[this._detailsDataIndex].Delete();
						this._noteGuideBdTable.Remove(hashKey);

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// 排他処理
						ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._noteGuidAcs);
			
						// UI子画面強制終了処理
						EnforcedEndTransaction();
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
							ERR_RDEL_MSG,						  // 表示するメッセージ 
							status,								  // ステータス値
							this._noteGuidAcs,					  // エラーが発生したオブジェクト
							MessageBoxButtons.OK,				  // 表示するボタン
							MessageBoxDefaultButton.Button1);	  // 初期表示ボタン
			
						if (UnDisplaying != null)
						{
							MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
							UnDisplaying(this, me);
						}

						// UI子画面強制終了処理
						EnforcedEndTransaction();
						return;
					}
				}
			}
			else
			{
				this.Delete_Button.Focus();
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;
			this._detailsIndexBuf = -2;
			this._mainIndexBuf = -2;
			this._targetTableBuf = "";

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
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
                case "NoteGuideCode_tNedit":
                    // ガイドコードにフォーカスがある場合
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // 遷移先が閉じるボタン
                        _modeFlg = true;
                    }
                    else if (this._detailsDataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            e.NextCtrl = NoteGuideCode_tNedit;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // ガイドコード
            int noteGuideCode = NoteGuideCode_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsNoteGuideCode = (int)this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[i][NOTE_GUIDE_CODE_TITLE];
                if (noteGuideCode == dsNoteGuideCode)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[NOTE_GUID_BD_TABLE].Rows[i][DELETEDATE_TITLE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの備考設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // ガイドコードのクリア
                        NoteGuideCode_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの備考設定情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._detailsDataIndex = i;
                                ScreenClear();
                                ScreenInitialSetting();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ガイドコードのクリア
                                NoteGuideCode_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.26 30413 犬飼 新規モードからモード変更対応 <<<<<<END
	}
}
