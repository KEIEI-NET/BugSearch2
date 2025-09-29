//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン名称設定マスタ
// プログラム概要   : キャンペーン名称設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// Update Note      :   2011/05/06 譚洪                         
//                  :   ①保存前のチェック処理を追加
//                  :   ②ＰＧ名称、項目名の変更                               
//----------------------------------------------------------------------------//
// Update Note      :   2011/06/20 曹文傑                         
//                  :   得意先対象区分「中止」を無くします
//----------------------------------------------------------------------------//
// Update Note      :   2011/07/28 周雨                         
//                  :   画面のメッセージを変更
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// キャンペーン名称設定マスタフォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note		: キャンペーン名称設定マスタを行います。
	///					  IMasterMaintenanceMultiTypeを実装しています。</br>   
    /// <br>Update Note:  2011/05/06 譚洪</br>
    /// <br>              ①保存前のチェック処理を追加</br>
    /// <br>　　　　　　　②ＰＧ名称、項目名の変更</br>
    /// </remarks>
	public class PMKHN09560UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region -- Component --

        private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraLabel CampaignCode_uLabel;
        private Broadleaf.Library.Windows.Forms.TNedit CampaignCode_tNedit;
        private Infragistics.Win.Misc.UltraLabel ApplyEndDate_uLabel;
        private Infragistics.Win.Misc.UltraLabel CampaignName_uLabel;
		private Infragistics.Win.Misc.UltraLabel Section_uLabel;
		private Broadleaf.Library.Windows.Forms.TEdit SectionName_tEdit;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Timer;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraLabel CampaignObjDiv_uLabel;
        private Infragistics.Win.Misc.UltraLabel ApplyStaDate_uLabel;
        private TComboEditor CampaignObjDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private TEdit tEdit_SectionCodeAllowZero;
        private UiSetControl uiSetControl1;
        private TEdit CampaignName_tEdit;
        private TDateEdit ApplyEndDate_TDateEdit;
        private TDateEdit ApplyStaDate_TDateEdit;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
		#endregion

		#region -- Constructor --
		/// <summary>
        /// キャンペーン名称設定マスタフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note		: キャンペーン名称設定マスタフォームクラスの新しいインスタンスを初期化します。</br>
		/// <br></br>
		/// </remarks>
        public PMKHN09560UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;

            //　企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 変数初期化
            this._dataIndex = -1;
            this._campaignStAcs = new CampaignStAcs();
            this._totalCount = 0;
            this._campaignStTable = new Hashtable();

            //_dataIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            // 拠点設定アクセスクラス
            this._secInfoAcs = new SecInfoAcs();

            // 日付取得部品
            this._dateGetAcs = DateGetAcs.GetInstance();
        }
		#endregion

		private System.ComponentModel.IContainer components;

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

		#region -- Windows フォーム デザイナで生成されたコード --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("拠点ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09560UA));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CampaignCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.CampaignCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ApplyEndDate_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.CampaignName_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Section_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.CampaignObjDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ApplyStaDate_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.CampaignObjDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SectionCodeAllowZero = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.CampaignName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ApplyEndDate_TDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ApplyStaDate_TDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignObjDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignName_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(621, 242);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 15;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(494, 242);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 14;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 285);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(759, 23);
            this.ultraStatusBar1.TabIndex = 11;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(635, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 61;
            this.Mode_Label.Text = "更新モード";
            // 
            // CampaignCode_uLabel
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.CampaignCode_uLabel.Appearance = appearance10;
            this.CampaignCode_uLabel.Location = new System.Drawing.Point(16, 44);
            this.CampaignCode_uLabel.Name = "CampaignCode_uLabel";
            this.CampaignCode_uLabel.Size = new System.Drawing.Size(165, 24);
            this.CampaignCode_uLabel.TabIndex = 171;
            this.CampaignCode_uLabel.Text = "キャンペーンコード";
            // 
            // CampaignCode_tNedit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            this.CampaignCode_tNedit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.CampaignCode_tNedit.Appearance = appearance9;
            this.CampaignCode_tNedit.AutoSelect = true;
            this.CampaignCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CampaignCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CampaignCode_tNedit.DataText = "";
            this.CampaignCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CampaignCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CampaignCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CampaignCode_tNedit.Location = new System.Drawing.Point(201, 44);
            this.CampaignCode_tNedit.MaxLength = 6;
            this.CampaignCode_tNedit.Name = "CampaignCode_tNedit";
            this.CampaignCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.CampaignCode_tNedit.Size = new System.Drawing.Size(84, 24);
            this.CampaignCode_tNedit.TabIndex = 0;
            // 
            // ApplyEndDate_uLabel
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.ApplyEndDate_uLabel.Appearance = appearance26;
            this.ApplyEndDate_uLabel.Location = new System.Drawing.Point(16, 194);
            this.ApplyEndDate_uLabel.Name = "ApplyEndDate_uLabel";
            this.ApplyEndDate_uLabel.Size = new System.Drawing.Size(165, 24);
            this.ApplyEndDate_uLabel.TabIndex = 177;
            this.ApplyEndDate_uLabel.Text = "適用終了日";
            // 
            // CampaignName_uLabel
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.CampaignName_uLabel.Appearance = appearance22;
            this.CampaignName_uLabel.Location = new System.Drawing.Point(16, 74);
            this.CampaignName_uLabel.Name = "CampaignName_uLabel";
            this.CampaignName_uLabel.Size = new System.Drawing.Size(165, 24);
            this.CampaignName_uLabel.TabIndex = 179;
            this.CampaignName_uLabel.Text = "キャンペーン名称";
            // 
            // Section_uLabel
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.Section_uLabel.Appearance = appearance4;
            this.Section_uLabel.Location = new System.Drawing.Point(16, 104);
            this.Section_uLabel.Name = "Section_uLabel";
            this.Section_uLabel.Size = new System.Drawing.Size(165, 24);
            this.Section_uLabel.TabIndex = 184;
            this.Section_uLabel.Text = "拠点";
            // 
            // SectionName_tEdit
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance27.ForeColor = System.Drawing.Color.Black;
            this.SectionName_tEdit.ActiveAppearance = appearance27;
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            appearance28.TextHAlignAsString = "Left";
            this.SectionName_tEdit.Appearance = appearance28;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SectionName_tEdit.Location = new System.Drawing.Point(235, 104);
            this.SectionName_tEdit.MaxLength = 10;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.ReadOnly = true;
            this.SectionName_tEdit.Size = new System.Drawing.Size(195, 24);
            this.SectionName_tEdit.TabIndex = 1;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Timer
            // 
            this.Timer.Interval = 1;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // SectionGuide_Button
            // 
            this.SectionGuide_Button.Location = new System.Drawing.Point(436, 104);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.SectionGuide_Button.TabIndex = 3;
            ultraToolTipInfo1.ToolTipText = "拠点ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_Button, ultraToolTipInfo1);
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // CampaignObjDiv_uLabel
            // 
            appearance68.TextVAlignAsString = "Middle";
            this.CampaignObjDiv_uLabel.Appearance = appearance68;
            this.CampaignObjDiv_uLabel.Location = new System.Drawing.Point(16, 134);
            this.CampaignObjDiv_uLabel.Name = "CampaignObjDiv_uLabel";
            this.CampaignObjDiv_uLabel.Size = new System.Drawing.Size(165, 24);
            this.CampaignObjDiv_uLabel.TabIndex = 253;
            this.CampaignObjDiv_uLabel.Text = "対象得意先区分";
            // 
            // ApplyStaDate_uLabel
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.ApplyStaDate_uLabel.Appearance = appearance63;
            this.ApplyStaDate_uLabel.Location = new System.Drawing.Point(16, 164);
            this.ApplyStaDate_uLabel.Name = "ApplyStaDate_uLabel";
            this.ApplyStaDate_uLabel.Size = new System.Drawing.Size(165, 24);
            this.ApplyStaDate_uLabel.TabIndex = 258;
            this.ApplyStaDate_uLabel.Text = "適用開始日";
            // 
            // CampaignObjDiv_tComboEditor
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextVAlignAsString = "Middle";
            this.CampaignObjDiv_tComboEditor.ActiveAppearance = appearance58;
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance59.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            this.CampaignObjDiv_tComboEditor.Appearance = appearance59;
            this.CampaignObjDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CampaignObjDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.CampaignObjDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CampaignObjDiv_tComboEditor.ItemAppearance = appearance60;
            this.CampaignObjDiv_tComboEditor.Location = new System.Drawing.Point(201, 134);
            this.CampaignObjDiv_tComboEditor.Name = "CampaignObjDiv_tComboEditor";
            this.CampaignObjDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.CampaignObjDiv_tComboEditor.TabIndex = 4;
            // 
            // ultraLabel6
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance34;
            this.ultraLabel6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel6.Location = new System.Drawing.Point(467, 101);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(273, 65);
            this.ultraLabel6.TabIndex = 262;
            this.ultraLabel6.Text = "※拠点は対象商品設定マスタ登録時の\n　初期値に使用します\n　ゼロで共通設定になります";
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(493, 242);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 14;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(365, 242);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 13;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // tEdit_SectionCodeAllowZero
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance7.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero.ActiveAppearance = appearance7;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero.Appearance = appearance11;
            this.tEdit_SectionCodeAllowZero.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero.DataText = "";
            this.tEdit_SectionCodeAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, true, true, true));
            this.tEdit_SectionCodeAllowZero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_SectionCodeAllowZero.Location = new System.Drawing.Point(201, 104);
            this.tEdit_SectionCodeAllowZero.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero.Name = "tEdit_SectionCodeAllowZero";
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero.TabIndex = 2;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(364, 242);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 13;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // CampaignName_tEdit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance12.ForeColor = System.Drawing.Color.Black;
            this.CampaignName_tEdit.ActiveAppearance = appearance12;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.ForeColorDisabled = System.Drawing.Color.Black;
            appearance29.TextHAlignAsString = "Left";
            this.CampaignName_tEdit.Appearance = appearance29;
            this.CampaignName_tEdit.AutoSelect = true;
            this.CampaignName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CampaignName_tEdit.DataText = "";
            this.CampaignName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CampaignName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.CampaignName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CampaignName_tEdit.Location = new System.Drawing.Point(201, 74);
            this.CampaignName_tEdit.MaxLength = 30;
            this.CampaignName_tEdit.Name = "CampaignName_tEdit";
            this.CampaignName_tEdit.Size = new System.Drawing.Size(544, 24);
            this.CampaignName_tEdit.TabIndex = 1;
            // 
            // ApplyEndDate_TDateEdit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ApplyEndDate_TDateEdit.ActiveEditAppearance = appearance14;
            this.ApplyEndDate_TDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ApplyEndDate_TDateEdit.CalendarDisp = true;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.ApplyEndDate_TDateEdit.EditAppearance = appearance15;
            this.ApplyEndDate_TDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ApplyEndDate_TDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ApplyEndDate_TDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            appearance16.TextHAlignAsString = "Left";
            appearance16.TextVAlignAsString = "Middle";
            this.ApplyEndDate_TDateEdit.LabelAppearance = appearance16;
            this.ApplyEndDate_TDateEdit.Location = new System.Drawing.Point(201, 194);
            this.ApplyEndDate_TDateEdit.Name = "ApplyEndDate_TDateEdit";
            this.ApplyEndDate_TDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ApplyEndDate_TDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ApplyEndDate_TDateEdit.Size = new System.Drawing.Size(172, 24);
            this.ApplyEndDate_TDateEdit.TabIndex = 6;
            this.ApplyEndDate_TDateEdit.TabStop = true;
            // 
            // ApplyStaDate_TDateEdit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ApplyStaDate_TDateEdit.ActiveEditAppearance = appearance17;
            this.ApplyStaDate_TDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ApplyStaDate_TDateEdit.CalendarDisp = true;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            this.ApplyStaDate_TDateEdit.EditAppearance = appearance18;
            this.ApplyStaDate_TDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ApplyStaDate_TDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ApplyStaDate_TDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            appearance19.TextHAlignAsString = "Left";
            appearance19.TextVAlignAsString = "Middle";
            this.ApplyStaDate_TDateEdit.LabelAppearance = appearance19;
            this.ApplyStaDate_TDateEdit.Location = new System.Drawing.Point(201, 164);
            this.ApplyStaDate_TDateEdit.Name = "ApplyStaDate_TDateEdit";
            this.ApplyStaDate_TDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ApplyStaDate_TDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ApplyStaDate_TDateEdit.Size = new System.Drawing.Size(172, 24);
            this.ApplyStaDate_TDateEdit.TabIndex = 5;
            this.ApplyStaDate_TDateEdit.TabStop = true;
            // 
            // PMKHN09560UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(759, 308);
            this.Controls.Add(this.ApplyEndDate_TDateEdit);
            this.Controls.Add(this.ApplyStaDate_TDateEdit);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.SectionGuide_Button);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.CampaignObjDiv_tComboEditor);
            this.Controls.Add(this.ApplyStaDate_uLabel);
            this.Controls.Add(this.CampaignObjDiv_uLabel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.CampaignName_tEdit);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.Section_uLabel);
            this.Controls.Add(this.CampaignName_uLabel);
            this.Controls.Add(this.ApplyEndDate_uLabel);
            this.Controls.Add(this.CampaignCode_tNedit);
            this.Controls.Add(this.CampaignCode_uLabel);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09560UA";
            this.Text = "キャンペーン名称設定マスタ";
            this.Load += new System.EventHandler(this.PMKHN09560UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09560UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN09560UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.CampaignCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignObjDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampaignName_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region -- Events --
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		#endregion
        
		#region -- Private Members --
		private CampaignStAcs _campaignStAcs;
        private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _campaignStTable;

        private SecInfoAcs _secInfoAcs;

        // 日付取得部品
        private DateGetAcs _dateGetAcs;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        
		// 保存比較用Clone
		private CampaignSt _campaignStClone;

		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int	 _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		//_dataIndexバッファ（メインフレーム最小化対応）
		private int _indexBuf;

        // 新規モードからモード変更対応
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;

        private const string PROGRAM_ID = "PMKHN09560U";    // プログラムID

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "VIEW_TABLE";

		// FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE = "削除日";

        private const string VIEW_SECTION_CODE_TITLE = "拠点コード";
        private const string VIEW_SECTION_NAME_TITLE = "拠点名称";

        private const string VIEW_CAMPAIGN_CODE = "キャンペーンコード";
        private const string VIEW_CAMPAIGN_NAME = "キャンペーン名称";
        private const string VIEW_CAMPAIGN_OBJ_DIV = "キャンペーン対象区分";
        private const string VIEW_APPLY_STA_DATE = "適用開始日";
        private const string VIEW_APPLY_END_DATE = "適用終了日";
        
        private const string VIEW_GUID_KEY_TITLE = "Guid";
		
		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";	   
		private const string DELETE_MODE = "削除モード";

        // 入力チェック
        private const string ct_InputError = "の入力が不正です";
        private const string ct_NoInput = "を入力して下さい";

        // 全社共通
        private const string ALL_SECTIONCODE = "00";
        
		#endregion

		#region -- Main --
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new PMKHN09560UA());
		}
		# endregion

		#region -- Properties --
		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get
			{ 
				return this._canPrint; 
			}
		}

		/// <summary>論理削除データ抽出可能設定プロパティ</summary>
		/// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get
			{ 
				return this._canLogicalDeleteDataExtraction;
			}
		}

		/// <summary>画面終了設定プロパティ</summary>
		/// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
		/// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
		public bool CanClose
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

		/// <summary>新規登録可能設定プロパティ</summary>
		/// <value>新規登録が可能かどうかの設定を取得します。</value>
		public bool CanNew
		{
			get
			{
				return this._canNew;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>削除可能設定プロパティ</summary>
		/// <value>削除が可能かどうかの設定を取得します。</value>
		public bool CanDelete
		{
			get
			{
				return this._canDelete;
			}
		}

		/// <summary>データセットの選択データインデックスプロパティ</summary>
		/// <value>データセットの選択データインデックスを取得または設定します。</value>
		public int DataIndex
		{
			get
			{ 
				return this._dataIndex;
			}
			set
			{
				this._dataIndex = value;
			}
		}

		/// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
		/// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
		public bool DefaultAutoFillToColumn
		{
			get
			{ 
				return this._defaultAutoFillToColumn;
			}
		}

		/// <summary>件数指定抽出可能設定プロパティ</summary>
		/// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
		public bool CanSpecificationSearch
		{
			get
			{
				return this._canSpecificationSearch;
			}
		}
		#endregion

		#region -- Public Methods --
		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッドリッド用データセット</param>
		/// <param name="tableName">テーブル名称</param>
		/// <remarks>
		/// <br>Note		: フレーム側のグリッドにバインドさせるデータセットを取得します。</br>
		/// <br></br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = VIEW_TABLE;
		}
		
		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 先頭から指定件数分のデータを検索し、</br>
		///	<br>			  抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br></br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList retList = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._campaignStTable.Clear();

            // 全検索
            status = this._campaignStAcs.SearchAll(out retList, this._enterpriseCode);
            this._totalCount = retList.Count;

			switch(status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    int index = 0;

                    foreach (CampaignSt campaignSt in retList)
					{
                        // キャンペーン設定情報クラスのデータセット展開処理
                        CampaignStToDataSet(campaignSt.Clone(), index);
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
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                        PROGRAM_ID,							    // アセンブリID
                        this.Text,              　　            // プログラム名称
						"Search",                               // 処理名称
						TMsgDisp.OPE_GET,                       // オペレーション
						"読み込みに失敗しました。",				// 表示するメッセージ
						status,									// ステータス値
						this._campaignStAcs,					    // エラーが発生したオブジェクト
						MessageBoxButtons.OK,					// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン

					break;
				}
			}
			return status;
		}

		/// <summary>
		/// ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定した件数分のネクストデータを検索します。</br>
		/// <br></br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
            // 実装なし
            return 9;
        }

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note        : 選択中のデータを削除します。</br>
		/// <br></br>
		/// </remarks>
		public int Delete()
		{
            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            CampaignSt campaignSt = (CampaignSt)this._campaignStTable[guid];

            // 全社共通データは削除可能
            //// 全社共通データは削除不可
            //if (campaignSt.SectionCode.Trim() == ALL_SECTIONCODE)
            //{
            //    TMsgDisp.Show(this,                             // 親ウィンドウフォーム
            //            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
            //            PROGRAM_ID,							    // アセンブリID
            //            "全社共通データは削除できません。",	    // 表示するメッセージ
            //            0,									    // ステータス値
            //            MessageBoxButtons.OK);					// 表示するボタン
            //    return (0);
            //}
            
            int status;

            // キャンペーン設定情報の論理削除処理
            status = this._campaignStAcs.LogicalDelete(ref campaignSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._campaignStAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            // キャンペーン設定情報クラスのデータセット展開処理
            CampaignStToDataSet(campaignSt.Clone(), this.DataIndex);

            return status;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note        : 印刷処理を実行します。(未実装)</br>
		/// <br></br>
		/// </remarks>
		public int Print()
		{
			return 0;
		}

		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note        : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
		/// <br></br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // キャンペーンコード
            appearanceTable.Add(VIEW_CAMPAIGN_CODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "000000", Color.Black));
            // キャンペーン名称
            appearanceTable.Add(VIEW_CAMPAIGN_NAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 拠点コード
            appearanceTable.Add(VIEW_SECTION_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 拠点名称
			appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            // キャンペーン対象区分
            appearanceTable.Add(VIEW_CAMPAIGN_OBJ_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 適用開始日
            appearanceTable.Add(VIEW_APPLY_STA_DATE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 適用終了日
            appearanceTable.Add(VIEW_APPLY_END_DATE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // Guid
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			
			return appearanceTable;
		}
		# endregion

		#region -- Private Methods --
        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面の再構築を行います。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                CampaignSt campaignSt = new CampaignSt();
                //クローン作成
                this._campaignStClone = campaignSt.Clone();
                this._indexBuf = this._dataIndex;

                // 画面情報を比較用クローンにコピーします
                ScreenToCampaignSt(ref this._campaignStClone);

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // フォーカス設定
                this.CampaignCode_tNedit.Focus();
            }
            else
            {
                // 保持しているデータセットより修正前情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                CampaignSt campaignSt = (CampaignSt)this._campaignStTable[guid];

                // キャンペーン設定クラス画面展開処理
                CampaignStToScreen(campaignSt);

                if (campaignSt.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // フォーカス設定
                    this.CampaignName_tEdit.Focus();

                    // クローン作成
                    this._campaignStClone = campaignSt.Clone();

                    // 画面情報を比較用クローンにコピーします　   
                    ScreenToCampaignSt(ref this._campaignStClone);
                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(DELETE_MODE);

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="mode">モード(新規・更新・削除)</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    {
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.Renewal_Button.Visible = true;                        
                        this.CampaignName_tEdit.Enabled = true;
                        this.tEdit_SectionCodeAllowZero.Enabled = true;
                        this.SectionName_tEdit.Enabled = false;
                        this.SectionGuide_Button.Enabled = true;
                        this.CampaignObjDiv_tComboEditor.Enabled = true;
                        this.ApplyStaDate_TDateEdit.Enabled = true;
                        this.ApplyEndDate_TDateEdit.Enabled = true;
                        
                        if (mode == INSERT_MODE)
                        {
                            // 新規モード
                            this.CampaignCode_tNedit.Enabled = true;
                        }
                        else
                        {
                            // 更新モード
                            this.CampaignCode_tNedit.Enabled = false;
                        }

                        break;
                    }
                case DELETE_MODE:
                    {
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Renewal_Button.Visible = false;
                        this.CampaignCode_tNedit.Enabled = false;
                        this.CampaignName_tEdit.Enabled = false;
                        this.tEdit_SectionCodeAllowZero.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.SectionName_tEdit.Enabled = false;
                        this.CampaignObjDiv_tComboEditor.Enabled = false;
                        this.ApplyStaDate_TDateEdit.Enabled = false;
                        this.ApplyEndDate_TDateEdit.Enabled = false;
                        
                        break;
                    }
            }
        }

		/// <summary>
		/// キャンペーン設定オブジェクトデータセット展開処理
		/// </summary>
        /// <param name="campaignSt">キャンペーン設定オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
        /// <br>Note       : キャンペーン設定クラスをデータセットに格納します。</br>
        /// <br></br>
        /// <br>Update Note: 2011/06/20 曹文傑</br>
        /// <br>             得意先対象区分「中止」を無くします</br>
		/// </remarks>
		private void CampaignStToDataSet(CampaignSt campaignSt, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
			}

            if (campaignSt.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = campaignSt.UpdateDateTimeJpInFormal;
            }

            // キャンペーンコード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CAMPAIGN_CODE] = campaignSt.CampaignCode;

            // キャンペーン名称
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CAMPAIGN_NAME] = campaignSt.CampaignName;

			// 拠点コード
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = campaignSt.SectionCode;
            // 拠点名称
            string sectionName = GetSectionName(campaignSt.SectionCode);
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = sectionName;
            
            // キャンペーン対象区分
            switch (campaignSt.CampaignObjDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CAMPAIGN_OBJ_DIV] = "全得意先";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CAMPAIGN_OBJ_DIV] = "対象得意先";
                    break;
                // ---DEL 2011/06/20--------------->>>>>
                //case 9:
                //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CAMPAIGN_OBJ_DIV] = "中止";
                //    break;
                // ---DEL 2011/06/20---------------<<<<<
            }

            // 適用開始日
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_APPLY_STA_DATE] = campaignSt.ApplyStaDateAdFormal;

            // 適用終了日
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_APPLY_END_DATE] = campaignSt.ApplyEndDateAdFormal;

            // Guid
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = campaignSt.FileHeaderGuid;
			
			if (this._campaignStTable.ContainsKey(campaignSt.FileHeaderGuid) == true)
			{
				this._campaignStTable.Remove(campaignSt.FileHeaderGuid);
			}
			this._campaignStTable.Add(campaignSt.FileHeaderGuid, campaignSt);
		}

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
		/// <br></br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable campaignStTable = new DataTable(VIEW_TABLE);

			// Addを行う順番が、列の表示順位となります。

            campaignStTable.Columns.Add(DELETE_DATE, typeof(string));			        // 削除日

            campaignStTable.Columns.Add(VIEW_CAMPAIGN_CODE, typeof(int));               // キャンペーンコード
            campaignStTable.Columns.Add(VIEW_CAMPAIGN_NAME, typeof(string));            // キャンペーン名称
            
            campaignStTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));       // 拠点コード
			campaignStTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));       // 拠点名称

            campaignStTable.Columns.Add(VIEW_CAMPAIGN_OBJ_DIV, typeof(string));         // キャンペーン対象区分
            campaignStTable.Columns.Add(VIEW_APPLY_STA_DATE, typeof(string));           // 適用開始日
            campaignStTable.Columns.Add(VIEW_APPLY_END_DATE, typeof(string));           // 適用終了日
            
            campaignStTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));             // Guid

			this.Bind_DataSet.Tables.Add(campaignStTable);
		}

        // ------ ADD 2011/05/06 ------------->>>>>
        /// <summary>
        /// 設定画面入力の時間チェック処理
        /// </summary>
        ///  <remarks>
        /// <br>Note       : 設定画面入力の時間チェック処理します。 </br>
        /// <returns>FLAG</returns>
        /// </remarks>
        private bool DateCheck()
        {   
            bool flag = true;

            DateTime endDt = this.ApplyEndDate_TDateEdit.GetDateTime();
            DateTime staDt=this.ApplyStaDate_TDateEdit.GetDateTime();

            if ((endDt.Year - staDt.Year) > 1)//時間大于１年間の場合
            {
                flag = false;
            }
            else if (endDt.Year - staDt.Year == 1)
            {
                if (endDt.Month > staDt.Month) //月比較
                {
                    flag = false;
                }
                else if((endDt.Month == staDt.Month) && (endDt.Day >= staDt.Day))
                {
                    flag = false;
                }
            }
            return flag;
        }
        // ------ ADD 2011/05/06 -------------<<<<<

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
        /// <br></br>
        /// <br>Update Note: 2011/06/20 曹文傑</br>
        /// <br>             得意先対象区分「中止」を無くします</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
            // キャンペーン対象区分
            CampaignObjDiv_tComboEditor.Items.Clear();
            CampaignObjDiv_tComboEditor.Items.Add(0, "全得意先");
            CampaignObjDiv_tComboEditor.Items.Add(1, "対象得意先");
            //CampaignObjDiv_tComboEditor.Items.Add(9, "中止"); // DEL 2011/06/20
            CampaignObjDiv_tComboEditor.MaxDropDownItems = CampaignObjDiv_tComboEditor.Items.Count;

        }
		
       	/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : 画面をクリアします。</br>
		/// <br></br>
		/// </remarks>
		private void ScreenClear()
		{
            this.tEdit_SectionCodeAllowZero.DataText = "";
            
            this.CampaignCode_tNedit.DataText = "";                 // キャンペーンコード
            this.CampaignName_tEdit.DataText = "";                  // キャンペーン名称
            this.SectionName_tEdit.DataText = "";                   // 拠点コード
            this.CampaignObjDiv_tComboEditor.SelectedIndex = 0;     // キャンペーン対象区分
            this.ApplyStaDate_TDateEdit.Clear();                    // 適用開始日
            this.ApplyEndDate_TDateEdit.Clear();                    // 適用終了日
        }

		/// <summary>
        /// キャンペーン設定クラス画面展開処理
		/// </summary>
        /// <param name="campaignSt">キャンペーン設定オブジェクト</param>
		/// <remarks>
        /// <br>Note       : キャンペーン設定オブジェクトから画面にデータを展開します。</br>
		/// <br></br>
		/// </remarks>
		private void CampaignStToScreen(CampaignSt campaignSt)
		{
            // キャンペーンコード
            this.CampaignCode_tNedit.SetInt(campaignSt.CampaignCode);

            // キャンペーン名称
            this.CampaignName_tEdit.DataText = campaignSt.CampaignName;

            // 拠点コード
            this.tEdit_SectionCodeAllowZero.DataText = campaignSt.SectionCode.Trim();
            // 拠点名称
            string sectionName = string.Empty;
            if (campaignSt.SectionCode.Trim().Equals(ALL_SECTIONCODE))
            {
                sectionName = "全社共通";
            }
            else
            {
                sectionName = this.GetSectionName(campaignSt.SectionCode);
            }
            this.SectionName_tEdit.DataText = sectionName;

            // キャンペーン対象区分
            this.CampaignObjDiv_tComboEditor.Value = campaignSt.CampaignObjDiv;

            // 適用開始日
            this.ApplyStaDate_TDateEdit.SetDateTime(campaignSt.ApplyStaDate);

            // 適用終了日
            this.ApplyEndDate_TDateEdit.SetDateTime(campaignSt.ApplyEndDate);
        }

		/// <summary>
        /// 画面情報キャンペーン設定クラス格納処理
		/// </summary>
        /// <param name="campaignSt">キャンペーン設定オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 画面情報からキャンペーン設定オブジェクトにデータを格納します。</br>
        /// <br></br>
        /// <br>Update Note: 2011/06/20 曹文傑</br>
        /// <br>             得意先対象区分「中止」を無くします</br>
		/// </remarks>
		private void ScreenToCampaignSt(ref CampaignSt campaignSt)
		{
			if (campaignSt == null)
			{
				// 新規の場合
                campaignSt = new CampaignSt();
			}

            //企業コード
            campaignSt.EnterpriseCode = this._enterpriseCode; 
            
            // キャンペーンコード
            campaignSt.CampaignCode = this.CampaignCode_tNedit.GetInt();

            // キャンペーン名称
            campaignSt.CampaignName = this.CampaignName_tEdit.DataText;

            // 拠点コード
            campaignSt.SectionCode = this.tEdit_SectionCodeAllowZero.DataText;

            // ---UPD 2011/06/20-------------->>>>>
            if (this.CampaignObjDiv_tComboEditor.Value == null)
            {
                // キャンペーン対象区分
                campaignSt.CampaignObjDiv = -1;
            }
            else
            {
                // キャンペーン対象区分
                campaignSt.CampaignObjDiv = (int)this.CampaignObjDiv_tComboEditor.Value;
            }
            // ---UPD 2011/06/20--------------<<<<<

            // 適用開始日
            campaignSt.ApplyStaDate = this.ApplyStaDate_TDateEdit.GetDateTime();

            // 適用終了日
            campaignSt.ApplyEndDate = this.ApplyEndDate_TDateEdit.GetDateTime();
		}

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br></br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            // 比較用クローンクリア
            this._campaignStClone = null;

            // フォームを非表示化する。
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br></br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
		{
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
		}

		/// <summary>
		///	キャンペーン設定画面入力チェック処理
		/// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note	   : キャンペーン設定画面の入力チェックをします。</br>
        /// <br></br>
        /// <br>Update Note: 2011/06/20 曹文傑</br>
        /// <br>             得意先対象区分「中止」を無くします</br>
		/// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
		{
            DateGetAcs.CheckDateResult cdResult;

            // キャンペーンコード
            if (this.CampaignCode_tNedit.DataText == "")
            {
                message = this.CampaignCode_uLabel.Text + "を設定して下さい。";
                control = this.CampaignCode_tNedit;
                return false;
            }

            // キャンペーン名称
            if (this.CampaignName_tEdit.DataText == "")
            {
                message = this.CampaignName_uLabel.Text + "を設定して下さい。";
                control = this.CampaignName_tEdit;
                return false;
            }

            // 拠点コード
            if (this.tEdit_SectionCodeAllowZero.DataText == "")
            {
                message = this.Section_uLabel.Text + "を設定して下さい。";
                control = this.tEdit_SectionCodeAllowZero;
                return false;
            }

            // ---ADD 2011/06/20------------->>>>>
            // 対象得意先区分
            if (this.CampaignObjDiv_tComboEditor.SelectedIndex != 0
                && this.CampaignObjDiv_tComboEditor.SelectedIndex != 1)
            {
                message = this.CampaignObjDiv_uLabel.Text + "を設定して下さい。";
                control = this.CampaignObjDiv_tComboEditor;
                return false;
            }
            // ---ADD 2011/06/20-------------<<<<<

            // 適用開始日
            if (CallCheckDate(out cdResult, ref this.ApplyStaDate_TDateEdit) == false)
            {
                // 処理日
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            message = string.Format("適用開始日{0}", ct_InputError);
                            control = this.ApplyStaDate_TDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            message = string.Format("適用開始日{0}", ct_NoInput);
                            control = this.ApplyStaDate_TDateEdit;
                        }
                        break;
                }
                return false;
            }

            // 適用終了日
            if (CallCheckDate(out cdResult, ref this.ApplyEndDate_TDateEdit) == false)
            {
                // 処理日
                switch (cdResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            message = string.Format("適用終了日{0}", ct_InputError);
                            control = this.ApplyEndDate_TDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            message = string.Format("適用終了日{0}", ct_NoInput);
                            control = this.ApplyEndDate_TDateEdit;
                        }
                        break;
                }
                return false;
            }

            if (this.ApplyStaDate_TDateEdit.GetLongDate() > this.ApplyEndDate_TDateEdit.GetLongDate())
            {
                message = "「適用開始日　≦　適用終了日」で設定してください。";
                control = this.ApplyStaDate_TDateEdit;
                return false;
            }

            return true;
		}

        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdResult"></param>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit)
        {
            cdResult = this._dateGetAcs.CheckDate(ref targetDateEdit, false);
            return (cdResult == DateGetAcs.CheckDateResult.OK);
        }

		/// <summary>
        ///　保存処理(SaveProc())
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 保存処理を行います。</br>
		/// <br></br>
		/// </remarks>
		private bool SaveProc()
		{
			bool result = false;
            
			//画面データ入力チェック処理
            Control control = null;
            string message = null;

            /*-----DEL 2011/07/28 -------------->>>>>
            // ------ ADD 2011/05/06 ------------->>>>>
            bool flag = DateCheck();
            if (!flag)
            {
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO,        // エラーレベル
                    PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                    "適用日の範囲は１年以内で入力して下さい。",// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.ApplyStaDate_TDateEdit.Focus();
                return result;
            }
            // ------ ADD 2011/05/06 -------------<<<<<
            -----DEL 2011/07/28 --------------<<<<<*/

            if (!ScreenDataCheck(ref control, ref message))
            {
                // 入力チェック
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                control.Focus();
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                else if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                return result;
            }

            // ------ ADD 2011/07/28 ------------->>>>>
            bool flag = DateCheck();
            if (!flag)
            {
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO,        // エラーレベル
                    PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                    "適用日の範囲は１年以内で入力して下さい。",// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                this.ApplyStaDate_TDateEdit.Focus();
                return result;
            }
            // ------ ADD 2011/07/28 -------------<<<<<
	
			CampaignSt campaignSt = null;

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                campaignSt = ((CampaignSt)this._campaignStTable[guid]).Clone();
			}

            // 画面情報を取得
			ScreenToCampaignSt(ref campaignSt);
            // 登録・更新処理
			int status = this._campaignStAcs.Write(ref campaignSt);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                {
                    RepeatTransaction(status, ref control);
                    control.Focus();
                    return false;
                }
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    // 排他処理
                    ExclusiveTransaction(status, true);					
					
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;

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
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                        PROGRAM_ID,							    // アセンブリID
						this.Text,  　　                        // プログラム名称
                        "SaveProc",                             // 処理名称
						TMsgDisp.OPE_UPDATE,                    // オペレーション
						"登録に失敗しました。",				    // 表示するメッセージ
						status,									// ステータス値
						this._campaignStAcs,				    	// エラーが発生したオブジェクト
						MessageBoxButtons.OK,			  		// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン
                    CloseForm(DialogResult.Cancel);
					return false;
				}
			}

            // キャンペーン設定情報クラスのデータセット展開処理
			CampaignStToDataSet(campaignSt, this.DataIndex);

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
			result = true;
			return result;
		}


        /// <summary>
        ///　競合中メッセージ表示
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 該当コードが使用されている場合にメッセージを表示します。</br>
        /// <br></br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                "このコードは既に使用されています" ,// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン
                tEdit_SectionCodeAllowZero.Focus();

                control = tEdit_SectionCodeAllowZero;
        }

        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールのサイズ設定処理を行います。</br>
        /// <br></br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.SectionName_tEdit.Size = new System.Drawing.Size(195, 24);
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称 ※該当するものがない場合、<c>null</c>を返します。</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br></br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // 全社共通チェック
            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                sectionName = "全社共通";
                return sectionName;
            }

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
                sectionName = null;
            }
            catch
            {
                sectionName = null;
            }

            return sectionName;
        }

        # endregion

        # region -- Control Events --
       	/// <summary>
        ///	Form.Load イベント(PMKHN09560UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
		/// <br></br>
		/// </remarks>
		private void PMKHN09560UA_Load(object sender, System.EventArgs e)
		{
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            
            // コントロールサイズ設定
            SetControlSize();
            
			// 画面初期設定処理
			ScreenInitialSetting();
		}

		/// <summary>
        ///	Form.Closing イベント(PMKHN09560UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note		: フォームを閉じる前に、ユーザーがフォームを閉じ
		///					  ようとしたときに発生します。</br>
		/// <br></br>
		/// </remarks>
		private void PMKHN09560UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._indexBuf = -2;
			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			//（フォームの「×」をクリックされた場合の対応です。）
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
			}		
		}

		/// <summary>
        ///	Form.VisibleChanged イベント(PMKHN09560UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: フォームの表示・非表示が切り替えられ
		///					  たときに発生します。</br>
		/// <br></br>
		/// </remarks>
		private void PMKHN09560UA_VisibleChanged(object sender, System.EventArgs e)
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
			
            // 画面クリア
			ScreenClear();

            Timer.Enabled = true;
		}

		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
		/// <br></br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
            // 登録・更新処理
			if (!SaveProc())
			{
				return;
			}
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
		/// <br></br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                CampaignSt compareCampaignSt = new CampaignSt();

                compareCampaignSt = this._campaignStClone.Clone();
                ScreenToCampaignSt(ref compareCampaignSt);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if ((!(this._campaignStClone.Equals(compareCampaignSt))))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
                        PROGRAM_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
                        null, 					                              // 表示するメッセージ
                        0, 					                                  // ステータス値
                        MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveProc())
                                {
                                    return;
                                }
                                return;
                            }
                        case DialogResult.No:
                            {
                                // 画面非表示イベント
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }
                                break;
                            }
                        default:
                            {
                                // 新規モードからモード変更対応
                                if (_modeFlg)
                                {
                                    CampaignCode_tNedit.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                return;
                            }
                    }
                }
            }
            
            this.DialogResult = DialogResult.Cancel;
			this._indexBuf = -2;

			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
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
		/// Timer.Tick イベント(timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
		///					  この処理は、システムが提供するスレッド プール
		///					  スレッドで実行されます。</br>
		/// <br></br>
		/// </remarks>
		private void Timer_Tick(object sender, System.EventArgs e)
		{
			Timer.Enabled = false;

            // 画面表示処理
			ScreenReconstruction();
		}
		#endregion

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                //status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet); // DEL 2011/05/06
                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);  // ADD 2011/05/06

                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();

                    this.CampaignObjDiv_tComboEditor.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);	// 表示するボタン

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // 保持しているデータセットより情報取得
			Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            CampaignSt campaignSt = (CampaignSt)this._campaignStTable[guid];

			// 完全削除処理
            int status = this._campaignStAcs.Delete(campaignSt);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                    this._campaignStTable.Remove(campaignSt.FileHeaderGuid);

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    // 排他処理
                    ExclusiveTransaction(status, true);
					return;
				}
				default:
				{
					// 完全削除
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                        PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
						this.Text, 				            // プログラム名称
						"Delete_Button_Click", 				// 処理名称
						TMsgDisp.OPE_DELETE, 				// オペレーション
						"削除に失敗しました。", 			// 表示するメッセージ
						status, 							// ステータス値
                        this._campaignStAcs, 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
                    CloseForm(DialogResult.Cancel);
					return;
				}
			}

			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			this._indexBuf = -2;

			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
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
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            Guid guid;

            // 復活対象データ取得
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            CampaignSt campaignSt = ((CampaignSt)this._campaignStTable[guid]).Clone();

            // 復活処理
            status = this._campaignStAcs.Revival(ref campaignSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // キャンペーン設定情報クラスのデータセット展開処理
                        CampaignStToDataSet(campaignSt, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "Revive_Button_Click",				// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "復活に失敗しました。",			    // 表示するメッセージ 
                            status,								// ステータス値
                            this._campaignStAcs,				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return;
                    }
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
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
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 新規モードからモード変更対応
            _modeFlg = false;
            
            if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero)
            {
                // 拠点コード取得
                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText;

                // 拠点名称取得
                string sectionName = GetSectionName(sectionCode);
                if (sectionName == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "拠点が存在しません。",
                        -1,
                        MessageBoxButtons.OK
                    );
                    this.tEdit_SectionCodeAllowZero.Clear();
                    this.SectionName_tEdit.Clear();
                    //e.NextCtrl = SectionGuide_Button;
                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                    e.NextCtrl.Select();
                    return;
                }
                this.SectionName_tEdit.DataText = sectionName;

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.SectionName_tEdit.DataText.Trim() != "")
                        {
                            // フォーカス設定
                            e.NextCtrl = this.CampaignObjDiv_tComboEditor;
                        }
                    }
                }
            }
            else if (e.PrevCtrl == CampaignCode_tNedit)
            {
                // 新規モードからモード変更対応
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // 遷移先が閉じるボタン
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "Renewal_Button")
                {
                    // 最新情報ボタンは更新チェックから外す
                    ;
                }
                else if (this.DataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = CampaignCode_tNedit;
                    }
                }
            }
            else if (e.PrevCtrl == Renewal_Button)
            {
                // 最新情報ボタンからの遷移時、更新チェックを追加
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // 遷移先が閉じるボタン
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "CampaignCode_tNedit")
                {
                    ;
                }
                else if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = CampaignCode_tNedit;
                    }
                }
            }
            else if (e.PrevCtrl == CampaignObjDiv_tComboEditor)
            {
                if ((e.ShiftKey) && (e.Key == Keys.Tab))
                {
                    // SHIFT+TAB制御
                    if (!tEdit_SectionCodeAllowZero.Enabled)
                    {
                        e.NextCtrl = CampaignName_tEdit;
                    }
                    else
                    {
                        if (SectionName_tEdit.DataText != "")
                        {
                            e.NextCtrl = tEdit_SectionCodeAllowZero;
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            //string msg = "入力されたコードのキャンペーン設定情報が既に登録されています。\n編集を行いますか？";    // DEL 2011/05/06
            string msg = "入力されたコードのキャンペーン名称設定情報が既に登録されています。\n編集を行いますか？";  // ADD 2011/05/06

            // キャンペーンコード
            int campaignCode = CampaignCode_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsCampaignCode = (int)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CAMPAIGN_CODE];
                if (campaignCode == dsCampaignCode)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                            //"入力されたコードのキャンペーン設定情報は既に削除されています。", 			// 表示するメッセージ  // DEL 2011/05/06
                          "入力されたコードのキャンペーン名称設定情報は既に削除されています。", 			// 表示するメッセージ  // ADD 2011/05/06
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // キャンペーンコードのクリア
                        CampaignCode_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        PROGRAM_ID,                             // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // キャンペーンコードのクリア
                                CampaignCode_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 最新情報ボタンクリック
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }

	}
}
