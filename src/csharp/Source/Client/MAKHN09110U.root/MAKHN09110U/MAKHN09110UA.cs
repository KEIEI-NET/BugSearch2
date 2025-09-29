//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : メーカー設定マスタ
// プログラム概要   : メーカー設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2008/06/11  修正内容 : PM.NS対応
//                                : 提供ＤＢ（部品メーカー名称マスタ）のデータは参照のみに変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30462 行澤 仁美
// 作 成 日  2008/10/07  修正内容 : バグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/12  修正内容 : MANTIS【13467】メーカー略称の削除
//----------------------------------------------------------------------------//

# region ※using
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
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
# endregion

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// メーカーマスタ フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note		: メーカーマスタ情報の設定を行います。
	///					  IMasterMaintenanceMultiTypeを実装しています。</br>
	/// <br>Programmer	: 96186 立花裕輔</br>
	/// <br>Date		: 2007.08.01</br>
    /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
    /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
    /// <br>           : 2008.06.11 30413 犬飼</br>
    /// <br>           : PM.NS対応</br>
    /// <br>           : 提供ＤＢ（部品メーカー名称マスタ）のデータは参照のみに変更</br>
    /// <br>UpdateNote   : 2008/10/07 30462 行澤 仁美　バグ修正</br>
    /// </remarks>
    public class MAKHN09110UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region ※Private Members (Component)

        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private System.Windows.Forms.Timer Initial_Timer;
        private System.Data.DataSet Bind_DataSet;
        private Broadleaf.Library.Windows.Forms.TImeControl tImeControl1;
        private Infragistics.Win.Misc.UltraLabel Guid_Label;
        private TEdit MakerNameRF_tEdit;
        private Infragistics.Win.Misc.UltraLabel MakerName_Title_Label;
		private Infragistics.Win.Misc.UltraLabel GoodsMakerCd_Title_Label;
        private TEdit MakerKanaNameRF_tEdit;
        private Infragistics.Win.Misc.UltraLabel MakerKanaName_Title_Label;
		private Infragistics.Win.Misc.UltraLabel DisplayOrder_Title_Label;
		private Infragistics.Win.Misc.UltraLabel Division_Label;
		private TNedit GoodsMakerCdRF_tNedit;
		private TNedit DisplayOrderRF_tNedit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.Misc.UltraLabel DivisionName_Label;
		private UiSetControl uiSetControl1;
		private System.ComponentModel.IContainer components;
		# endregion

		# region ■Constructor
		/// <summary>
        /// メーカーマスタ フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : メーカーマスタ フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 96186 立花裕輔</br>
		/// <br>Date       : 2007.08.01</br>
		/// </remarks>
        public MAKHN09110UA()
		{
			InitializeComponent();

			// データセット列情報構築処理
			DataSetColumnConstruction();

			// プロパティ初期値設定
			this._canPrint = false;
			this._canClose = false;
			this._canNew = true;
			this._canDelete = true;
			this._canLogicalDeleteDataExtraction = true;
			this._canClose = true;		// デフォルト:true固定
            // 2007.03.28  S.Koga  amend --------------------------------------------------
			//this._defaultAutoFillToColumn = false;
            this._defaultAutoFillToColumn = true;
            // ----------------------------------------------------------------------------
            this._canSpecificationSearch = false;

			//　企業コード取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// 変数初期化
			this._dataIndex = -1;
			this._secInfoAcs = new SecInfoAcs();
			this._makerUAcs = new MakerAcs();
            //this._userGuideAcs = new UserGuideAcs();  // iitani d 2007.05.18
			 
			this._prevmakerU = null;
#if False
			this._nextData = false;
#endif
			this._totalCount = 0;
            this._makerUTable = new Hashtable();

			//_dataIndexバッファ（メインフレーム最小化対応）
			this._indexBuf = -2;

			// 拠点OPの判定
			this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
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
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKHN09110UA));
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tImeControl1 = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.MakerNameRF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MakerKanaNameRF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GoodsMakerCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MakerName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Guid_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MakerKanaName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DisplayOrder_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Division_Label = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsMakerCdRF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DisplayOrderRF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.DivisionName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerNameRF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerKanaNameRF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCdRF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayOrderRF_tNedit)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(448, 267);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 4;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 314);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(722, 23);
            this.ultraStatusBar1.TabIndex = 46;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Mode_Label
            // 
            appearance13.ForeColor = System.Drawing.Color.White;
            appearance13.TextHAlignAsString = "Center";
            appearance13.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance13;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(604, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 58;
            this.Mode_Label.Text = "更新モード";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(320, 267);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 2;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(448, 267);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 3;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(579, 267);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 5;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // tImeControl1
            // 
            this.tImeControl1.InControl = this.MakerNameRF_tEdit;
            this.tImeControl1.OutControl = this.MakerKanaNameRF_tEdit;
            this.tImeControl1.OwnerForm = this;
            this.tImeControl1.PutLength = 30;
            // 
            // MakerNameRF_tEdit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerNameRF_tEdit.ActiveAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerNameRF_tEdit.Appearance = appearance15;
            this.MakerNameRF_tEdit.AutoSelect = true;
            this.MakerNameRF_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MakerNameRF_tEdit.DataText = "";
            this.MakerNameRF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MakerNameRF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.MakerNameRF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.MakerNameRF_tEdit.Location = new System.Drawing.Point(208, 145);
            this.MakerNameRF_tEdit.MaxLength = 30;
            this.MakerNameRF_tEdit.Name = "MakerNameRF_tEdit";
            this.MakerNameRF_tEdit.Size = new System.Drawing.Size(484, 24);
            this.MakerNameRF_tEdit.TabIndex = 60;
            this.MakerNameRF_tEdit.ValueChanged += new System.EventHandler(this.MakerNameRF_tEdit_ValueChanged);
            // 
            // MakerKanaNameRF_tEdit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerKanaNameRF_tEdit.ActiveAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerKanaNameRF_tEdit.Appearance = appearance8;
            this.MakerKanaNameRF_tEdit.AutoSelect = true;
            this.MakerKanaNameRF_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MakerKanaNameRF_tEdit.DataText = "";
            this.MakerKanaNameRF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MakerKanaNameRF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, true, true, false, true));
            this.MakerKanaNameRF_tEdit.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.MakerKanaNameRF_tEdit.Location = new System.Drawing.Point(208, 185);
            this.MakerKanaNameRF_tEdit.MaxLength = 20;
            this.MakerKanaNameRF_tEdit.Name = "MakerKanaNameRF_tEdit";
            this.MakerKanaNameRF_tEdit.Size = new System.Drawing.Size(175, 24);
            this.MakerKanaNameRF_tEdit.TabIndex = 61;
            this.MakerKanaNameRF_tEdit.ValueChanged += new System.EventHandler(this.MakerKanaNameRF_tEdit_ValueChanged);
            // 
            // GoodsMakerCd_Title_Label
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.GoodsMakerCd_Title_Label.Appearance = appearance17;
            this.GoodsMakerCd_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.GoodsMakerCd_Title_Label.Location = new System.Drawing.Point(23, 105);
            this.GoodsMakerCd_Title_Label.Name = "GoodsMakerCd_Title_Label";
            this.GoodsMakerCd_Title_Label.Size = new System.Drawing.Size(191, 24);
            this.GoodsMakerCd_Title_Label.TabIndex = 10;
            this.GoodsMakerCd_Title_Label.Text = "メーカーコード";
            // 
            // MakerName_Title_Label
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.MakerName_Title_Label.Appearance = appearance16;
            this.MakerName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MakerName_Title_Label.Location = new System.Drawing.Point(23, 145);
            this.MakerName_Title_Label.Name = "MakerName_Title_Label";
            this.MakerName_Title_Label.Size = new System.Drawing.Size(191, 24);
            this.MakerName_Title_Label.TabIndex = 11;
            this.MakerName_Title_Label.Text = "メーカー名";
            // 
            // Guid_Label
            // 
            this.Guid_Label.Location = new System.Drawing.Point(208, 52);
            this.Guid_Label.Name = "Guid_Label";
            this.Guid_Label.Size = new System.Drawing.Size(240, 25);
            this.Guid_Label.TabIndex = 46;
            this.Guid_Label.Visible = false;
            // 
            // MakerKanaName_Title_Label
            // 
            appearance11.TextVAlignAsString = "Middle";
            this.MakerKanaName_Title_Label.Appearance = appearance11;
            this.MakerKanaName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MakerKanaName_Title_Label.Location = new System.Drawing.Point(23, 185);
            this.MakerKanaName_Title_Label.Name = "MakerKanaName_Title_Label";
            this.MakerKanaName_Title_Label.Size = new System.Drawing.Size(191, 24);
            this.MakerKanaName_Title_Label.TabIndex = 61;
            this.MakerKanaName_Title_Label.Text = "メーカー名(ｶﾅ)";
            // 
            // DisplayOrder_Title_Label
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.DisplayOrder_Title_Label.Appearance = appearance6;
            this.DisplayOrder_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DisplayOrder_Title_Label.Location = new System.Drawing.Point(23, 226);
            this.DisplayOrder_Title_Label.Name = "DisplayOrder_Title_Label";
            this.DisplayOrder_Title_Label.Size = new System.Drawing.Size(191, 24);
            this.DisplayOrder_Title_Label.TabIndex = 64;
            this.DisplayOrder_Title_Label.Text = "表示順位";
            // 
            // Division_Label
            // 
            this.Division_Label.Location = new System.Drawing.Point(393, 55);
            this.Division_Label.Name = "Division_Label";
            this.Division_Label.Size = new System.Drawing.Size(240, 25);
            this.Division_Label.TabIndex = 66;
            this.Division_Label.Visible = false;
            // 
            // GoodsMakerCdRF_tNedit
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.TextHAlignAsString = "Right";
            this.GoodsMakerCdRF_tNedit.ActiveAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            this.GoodsMakerCdRF_tNedit.Appearance = appearance5;
            this.GoodsMakerCdRF_tNedit.AutoSelect = true;
            this.GoodsMakerCdRF_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.GoodsMakerCdRF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GoodsMakerCdRF_tNedit.DataText = "";
            this.GoodsMakerCdRF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GoodsMakerCdRF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.GoodsMakerCdRF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GoodsMakerCdRF_tNedit.Location = new System.Drawing.Point(208, 104);
            this.GoodsMakerCdRF_tNedit.MaxLength = 4;
            this.GoodsMakerCdRF_tNedit.Name = "GoodsMakerCdRF_tNedit";
            this.GoodsMakerCdRF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GoodsMakerCdRF_tNedit.Size = new System.Drawing.Size(51, 24);
            this.GoodsMakerCdRF_tNedit.TabIndex = 59;
            // 
            // DisplayOrderRF_tNedit
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.TextHAlignAsString = "Right";
            this.DisplayOrderRF_tNedit.ActiveAppearance = appearance2;
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            this.DisplayOrderRF_tNedit.Appearance = appearance3;
            this.DisplayOrderRF_tNedit.AutoSelect = true;
            this.DisplayOrderRF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DisplayOrderRF_tNedit.DataText = "";
            this.DisplayOrderRF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DisplayOrderRF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.DisplayOrderRF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DisplayOrderRF_tNedit.Location = new System.Drawing.Point(208, 226);
            this.DisplayOrderRF_tNedit.MaxLength = 3;
            this.DisplayOrderRF_tNedit.Name = "DisplayOrderRF_tNedit";
            this.DisplayOrderRF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DisplayOrderRF_tNedit.Size = new System.Drawing.Size(35, 24);
            this.DisplayOrderRF_tNedit.TabIndex = 65;
            // 
            // ultraLabel15
            // 
            this.ultraLabel15.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel15.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel15.Location = new System.Drawing.Point(23, 90);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(681, 3);
            this.ultraLabel15.TabIndex = 121;
            // 
            // DivisionName_Label
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.ForeColor = System.Drawing.Color.Yellow;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.DivisionName_Label.Appearance = appearance1;
            this.DivisionName_Label.BackColorInternal = System.Drawing.Color.AliceBlue;
            this.DivisionName_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.DivisionName_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DivisionName_Label.Location = new System.Drawing.Point(23, 53);
            this.DivisionName_Label.Name = "DivisionName_Label";
            this.DivisionName_Label.Size = new System.Drawing.Size(172, 24);
            this.DivisionName_Label.TabIndex = 2297;
            this.DivisionName_Label.Text = "ユーザーデータ";
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // MAKHN09110UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(722, 337);
            this.Controls.Add(this.DivisionName_Label);
            this.Controls.Add(this.ultraLabel15);
            this.Controls.Add(this.DisplayOrderRF_tNedit);
            this.Controls.Add(this.GoodsMakerCdRF_tNedit);
            this.Controls.Add(this.Division_Label);
            this.Controls.Add(this.DisplayOrder_Title_Label);
            this.Controls.Add(this.MakerKanaNameRF_tEdit);
            this.Controls.Add(this.MakerKanaName_Title_Label);
            this.Controls.Add(this.Guid_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.MakerNameRF_tEdit);
            this.Controls.Add(this.MakerName_Title_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.GoodsMakerCd_Title_Label);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAKHN09110UA";
            this.Text = "メーカーマスタ";
            this.Load += new System.EventHandler(this.MAKHN09110UA_Load);
            this.VisibleChanged += new System.EventHandler(this.MAKHN09110UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MAKHN09110UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerNameRF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerKanaNameRF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCdRF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayOrderRF_tNedit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region ■IMasterMaintenanceArrayTypeメンバー

		# region ▼Events
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region ▼Properties
		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get
			{
				return this._canPrint;
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
		# endregion

		# region ▼Public Methods
		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッドリッド用データセット</param>
		/// <param name="tableName">テーブル名称</param>
        /// <returns>なし</returns>
        /// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
		/// <br>Programmer : 96186 立花裕輔</br>
		/// <br>Date       : 2007.08.01</br>
		/// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = MAKERU_TABLE;
		}

		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList makerUMntretList = null;


            if (readCount == 0)
			{
                // 抽出対象件数が0の場合は全件抽出を実行する
                status = this._makerUAcs.SearchAll(
                            out makerUMntretList,
                            this._enterpriseCode);

                this._totalCount = makerUMntretList.Count;
			}
            else
            {
#if False
				 
				status = this._makerUAcs.SearchAll(
                            out makerUMntretList,
                            out this._totalCount,
                            out this._nextData,
                            this._enterpriseCode,
                            readCount,
                            this._prevmakerU);
#endif
			}

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 最終のメーカーマスタオブジェクトを退避する
                        this._prevmakerU = ((MakerUMnt)makerUMntretList[makerUMntretList.Count - 1]).Clone();

                        int index = 0;
                        foreach (MakerUMnt lgoodsgranre in makerUMntretList)
                        {
                            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
                            //if (this._makerUTable.ContainsKey(lgoodsgranre.FileHeaderGuid) == false)
                            if (this._makerUTable.ContainsKey(CreateHashKey(lgoodsgranre)) == false)
                            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
                            {
                                MakerUMntToDataSet(lgoodsgranre.Clone(), index);
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
                            "Search",							  // 処理名称
                            TMsgDisp.OPE_GET,					  // オペレーション
                            ERR_READ_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._makerUAcs,				  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                        break;
                    }
            }

            totalCount = this._totalCount;

            // iitani 仮データ
            //makerUMntretList = new ArrayList();
            //MakerUMnt LG1 = new MakerUMnt();
            //LG1.EnterpriseCode = this._enterpriseCode;
            //LG1.LargeGoodsGanreCode = 1;
            //LG1.LargeGoodsGanreName = "あ";
            //LG1.CreateDateTime = DateTime.Now.Date.Ticks;
            //LG1.UpdateDateTime = DateTime.Now.Date.Ticks;
            //Guid guid1 = new Guid("{28732AC1-1FF8-D211-BA4B-00A0C93EC93B}");
            //LG1.FileHeaderGuid = guid1;
            //makerUMntretList.Add(LG1);

            //MakerUMnt LG2 = new MakerUMnt();
            //LG2.EnterpriseCode = this._enterpriseCode;
            //LG2.LargeGoodsGanreCode = 999;
            //LG2.LargeGoodsGanreName = "あいうえおかきくけこ";
            //LG2.CreateDateTime = DateTime.Now.Date.Ticks;
            //LG2.UpdateDateTime = DateTime.Now.Date.Ticks;
            //Guid guid2 = new Guid("{28732AC1-1FF8-D211-BA4B-00A0C93EC93C}");
            //LG2.FileHeaderGuid = guid2;
            //makerUMntretList.Add(LG2);

            //this._totalCount = makerUMntretList.Count;
            //readCount = 2;

            // 最終のメーカーマスタオブジェクトを退避する
            //this._prevmakerU = ((MakerUMnt)makerUMntretList[makerUMntretList.Count - 1]).Clone();

            //int index = 0;
            //foreach (MakerUMnt lgoodsgranre in makerUMntretList)
            //{
            //    if (this._makerUTable.ContainsKey(lgoodsgranre.FileHeaderGuid) == false)
            //    {
            //        MakerUMntToDataSet(lgoodsgranre.Clone(), index);
            //        ++index;
            //    }
            //}
            /////////////////////////////////////end

            // 最終のメーカーマスタオブジェクトを退避する
            
            return status;
		}

		/// <summary>
		/// ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		public int SearchNext(int readCount)
		{
#if False
			int dummy = 0;
#endif
			int status = 0;
            ArrayList makerUMntretList = null;

			// 抽出対象件数が0の場合は、残りの全件を抽出
			if (readCount == 0)
			{
				readCount =	this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			}

#if False
			status = this._makerUAcs.SearchAll(
                            out makerUMntretList,
							out dummy,
							out this._nextData,
							this._enterpriseCode,
							readCount,
							this._prevmakerU);

#endif
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    // 最終のメーカーマスタクラスを退避する
                    this._prevmakerU = ((MakerUMnt)makerUMntretList[makerUMntretList.Count - 1]).Clone();

					int index = 0;
                    foreach (MakerUMnt lgoodsgranre in makerUMntretList)
					{
                        // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
                        //if (this._makerUTable.ContainsKey(lgoodsgranre.FileHeaderGuid) == false)
                        if (this._makerUTable.ContainsKey(CreateHashKey(lgoodsgranre)) == false)
                        // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
                        {
							index = this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count;
                            MakerUMntToDataSet(lgoodsgranre.Clone(), index);
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
						"SearchNext",						  // 処理名称
						TMsgDisp.OPE_GET,					  // オペレーション
						ERR_READ_MSG,						  // 表示するメッセージ 
						status,								  // ステータス値
						this._makerUAcs,				  // エラーが発生したオブジェクト
						MessageBoxButtons.OK,				  // 表示するボタン
						MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

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
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		public int Delete()
		{
			int status = 0;
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
            //Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
            string guid = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
            MakerUMnt makerU = ((MakerUMnt)this._makerUTable[guid]).Clone();

			if (makerU.Division == DIVISION_OFR)
			{
				TMsgDisp.Show(this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					ASSEMBLY_ID,
					"このレコードは提供データのため削除できません",
					status,
					MessageBoxButtons.OK);
				this.Hide();

				return -2;
			}

			status = this._makerUAcs.LogicalDelete(ref makerU);
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
					ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._makerUAcs);
					return status;
				}

				case -2:
				{
					//主作業設定で使用中
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						ASSEMBLY_ID,
						"このレコードは主作業設定で使用されているため削除できません",
						status,
						MessageBoxButtons.OK);
					this.Hide();

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
						this._makerUAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン

					return status;
				}
			}

			// データセット展開処理
			MakerUMntToDataSet(makerU.Clone(), this._dataIndex);
			return status;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
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
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 2008.06.11 30413 犬飼 メーカーコードは右詰 >>>>>>START
            // DEL 2008/10/07 不具合対応[6296] ↓
            //appearanceTable.Add(GOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "0000", Color.Black));   // ADD 2008/10/07 不具合対応[6296]
            // 2008.06.11 30413 犬飼 メーカーコードは右詰 <<<<<<END
			appearanceTable.Add(MAKERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //appearanceTable.Add(MAKERSHORTNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));    // DEL 2009/06/12
			appearanceTable.Add(MAKERKANANAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.06.11 30413 犬飼 表示順位は右詰 >>>>>>START
            appearanceTable.Add(DISPLAYORDER_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 2008.06.11 30413 犬飼 表示順位は右詰 <<<<<<END
            appearanceTable.Add(DIVISION_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(DIVISIONNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			return appearanceTable;
		}
		# endregion

		# endregion

		#region ■Private Menbers
		private MakerAcs _makerUAcs;
		private MakerUMnt _prevmakerU;
		private SecInfoAcs _secInfoAcs;
		//private UserGuideAcs _userGuideAcs;  // iitani d  2007.05.18
#if False
		private bool _nextData;
#endif
		private int _totalCount;
		private string _enterpriseCode;
        private Hashtable _makerUTable;
		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private MakerUMnt _makerUClone;

		//_dataIndexバッファ（メインフレーム最小化対応）
		private int _indexBuf;
		/// <summary>拠点オプションフラグ</summary>
		private bool _optSection = false;

        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
		# endregion

		# region ■Consts
		// FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
		private const string DELETE_DATE = "削除日";
		private const string SECTIONNAME_TITLE = "所属拠点";
		private const string GOODSMAKERCD_TITLE = "メーカーコード";
		private const string MAKERNAME_TITLE = "メーカー名";
        //private const string MAKERSHORTNAME_TITLE = "メーカー略称";   // DEL 2009/06/12
		private const string MAKERKANANAME_TITLE = "メーカー名(ｶﾅ)";
		private const string DISPLAYORDER_TITLE = "表示順位";
		private const string DIVISION_TITLE = "データ区分コード";
		private const string DIVISIONNAME_TITLE = "データ区分";

		private const string GUID_TITLE = "GUID";
		private const string MAKERU_TABLE = "LGOODSGANRE";
		
		//データ区分
		private const int DIVISION_USR = 0;
		private const int DIVISION_OFR = 1;	

		private const string DIVISION_USR_NAME = "0";
		private const string DIVISION_OFR_NAME = "1";

		private const string DIVISION_USR_NAME_TITLE = "ユーザーデータ";
		private const string DIVISION_OFR_NAME_TITLE = "提供データ";	

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";
		private const string REFERENCE_MODE = "参照モード";

		// コントロール名称
		private const string TAB1_NAME = "GeneralTab";
		private const string TAB2_NAME = "SecurityTab";

		// Message関連定義
		private const string ASSEMBLY_ID	= "MAKHN09110U";
		private const string PG_NM			= "メーカーマスタ";
		private const string ERR_READ_MSG	= "読み込みに失敗しました。";
		private const string ERR_DPR_MSG	= "このコードは既に使用されています。";
		private const string ERR_RDEL_MSG	= "削除に失敗しました。";
		private const string ERR_UPDT_MSG	= "登録に失敗しました。";
		private const string ERR_RVV_MSG	= "復活に失敗しました。";
		private const string ERR_800_MSG	= "既に他端末より更新されています";
		private const string ERR_801_MSG	= "既に他端末より削除されています";
		private const string SDC_RDEL_MSG	= "マスタから削除されています";
		#endregion
    
		# region ※Main
		/// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new MAKHN09110UA());
		}
		# endregion

		#region ■IMasterMaintenanceInputStart Members
		/// <summary>
		/// 
		/// </summary>
		/// <param name="paraTable"></param>
		/// <returns></returns>
		public DialogResult ShowDialog(Hashtable paraTable)
		{
			this.ShowDialog();
			return this.DialogResult;
		}
		#endregion

		# region ■Private Methods
		/// <summary>
        /// メーカーマスタ オブジェクトデータセット展開処理
		/// </summary>
        /// <param name="makerU">メーカーマスタ オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
        /// <br>Note       : メーカーマスタ クラスをデータセットに格納します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		private void MakerUMntToDataSet(MakerUMnt makerU, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[MAKERU_TABLE].NewRow();
				this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Add(dataRow);

				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count - 1;
			}

			if (makerU.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DELETE_DATE] = "";
			}
			else
			{
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DELETE_DATE] = makerU.UpdateDateTimeJpInFormal;
            }

			//メーカーコード
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GOODSMAKERCD_TITLE] = makerU.GoodsMakerCd;
			//メーカー名
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][MAKERNAME_TITLE] = makerU.MakerName;
			//メーカー略称
            //this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][MAKERSHORTNAME_TITLE] = makerU.MakerShortName;     // DEL 2009/06/12
            //メーカー名(ｶﾅ)
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][MAKERKANANAME_TITLE] = makerU.MakerKanaName;
			//表示順位
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DISPLAYORDER_TITLE] = makerU.DisplayOrder;
			//データー区分
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DIVISION_TITLE] = makerU.Division;
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DIVISIONNAME_TITLE] = makerU.DivisionName;
			// GUID
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
            //this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GUID_TITLE] = makerU.FileHeaderGuid;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GUID_TITLE] = CreateHashKey(makerU);
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end

            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
            //if (this._makerUTable.ContainsKey(makerU.FileHeaderGuid))
			//{
			//	this._makerUTable.Remove(makerU.FileHeaderGuid);
			//}
			//this._makerUTable.Add(makerU.FileHeaderGuid, makerU);
            if (this._makerUTable.ContainsKey(CreateHashKey(makerU)))
            {
                this._makerUTable.Remove(CreateHashKey(makerU));
            }
            this._makerUTable.Add(CreateHashKey(makerU), makerU);
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
        }

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable makerUTable = new DataTable(MAKERU_TABLE);

			// Addを行う順番が、列の表示順位となります。
			makerUTable.Columns.Add(DELETE_DATE,           typeof(string));

			//メーカーコード
			makerUTable.Columns.Add(GOODSMAKERCD_TITLE, typeof(int));
			//メーカー名
			makerUTable.Columns.Add(MAKERNAME_TITLE, typeof(string));
			//メーカー略称
            //makerUTable.Columns.Add(MAKERSHORTNAME_TITLE, typeof(string));    // DEL 2009/06/12
            //メーカー名(ｶﾅ)
			makerUTable.Columns.Add(MAKERKANANAME_TITLE, typeof(string));
			//表示順位
			makerUTable.Columns.Add(DISPLAYORDER_TITLE, typeof(int));
			//データ区分
			makerUTable.Columns.Add(DIVISION_TITLE, typeof(int));
			makerUTable.Columns.Add(DIVISIONNAME_TITLE, typeof(string));

			// GUID
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
            //makerUTable.Columns.Add(GUID_TITLE, typeof(Guid));
            makerUTable.Columns.Add(GUID_TITLE, typeof(string));
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end

			this.Bind_DataSet.Tables.Add(makerUTable);
		}

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void ScreenInitialSetting()
		{
            // DEL 2009/06/12 ------>>>
            //this.Ok_Button.Location = new System.Drawing.Point(448, 313);
            //this.Cancel_Button.Location = new System.Drawing.Point(579, 313);
            //this.Delete_Button.Location = new System.Drawing.Point(320, 313);
            //this.Revive_Button.Location = new System.Drawing.Point(448, 313);
            // DEL 2009/06/12 ------<<<
            // ADD 2009/06/12 ------>>>
            this.Ok_Button.Location = new System.Drawing.Point(448, 267);
            this.Cancel_Button.Location = new System.Drawing.Point(579, 267);
            this.Delete_Button.Location = new System.Drawing.Point(320, 267);
            this.Revive_Button.Location = new System.Drawing.Point(448, 267);
            // ADD 2009/06/12 ------<<<
        }

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void ScreenClear()
		{
			this.Guid_Label.Text = "";
			this.Division_Label.Text = "";
			this.DivisionName_Label.Text = "";
			this.GoodsMakerCdRF_tNedit.Clear();
			this.MakerNameRF_tEdit.Clear();
            //this.MakerShortNameRF_tEdit.Clear();  // DEL 2009/06/12
			this.MakerKanaNameRF_tEdit.Clear();
			this.DisplayOrderRF_tNedit.Clear();
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		private void ScreenReconstruction()
		{
			if (this.DataIndex < 0)
			{
				// 新規モード
				this.Mode_Label.Text = INSERT_MODE;
				DivisionName_Label.Text = DIVISION_USR_NAME_TITLE;
				Division_Label.Text = DIVISION_USR_NAME;

				// ボタン設定
				this.Ok_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				//_dataIndexバッファ保持
				this._indexBuf = this._dataIndex;
                                       				
				// 画面入力許可制御処理
				ScreenInputPermissionControl(true);
				MakerUMnt makerU = new MakerUMnt();

				//クローン作成
				this._makerUClone = makerU.Clone(); 

				DispToMakerUMnt(ref this._makerUClone);

				// フォーカス設定
				this.GoodsMakerCdRF_tNedit.Focus();
			}
			else
			{
                // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
                //Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                string guid = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
                MakerUMnt makerU = (MakerUMnt)this._makerUTable[guid];
				
				if (makerU.LogicalDeleteCode == 0)
				{
					// 画面入力許可制御処理
                    // 2008.06.11 30413 犬飼 提供データの場合は参照 >>>>>>START
                    //if (Division_Label.Text == DIVISION_OFR_NAME)
                    if (makerU.Division == DIVISION_OFR)
                    // 2008.06.11 30413 犬飼 提供データの場合は参照 <<<<<<END
					{
						// 参照モード
						this.Mode_Label.Text = REFERENCE_MODE;

						// ボタン設定
						this.Ok_Button.Visible = false;
						this.Delete_Button.Visible = false;
						this.Revive_Button.Visible = false;

						// 画面展開処理
						MakerUMntToScreen(makerU);

						//クローン作成
						this._makerUClone = makerU.Clone();
						DispToMakerUMnt(ref this._makerUClone);
						//_dataIndexバッファ保持
						this._indexBuf = this._dataIndex;

						// 画面入力許可制御処理
						ScreenInputPermissionControl(false);
					}
					else
					{
						// 更新モード
						this.Mode_Label.Text = UPDATE_MODE;

						// ボタン設定
						this.Ok_Button.Visible = true;
						this.Delete_Button.Visible = false;
						this.Revive_Button.Visible = false;

						// 画面展開処理
						MakerUMntToScreen(makerU);

						//クローン作成
						this._makerUClone = makerU.Clone();
						DispToMakerUMnt(ref this._makerUClone);
						//_dataIndexバッファ保持
						this._indexBuf = this._dataIndex;

						// 画面入力許可制御処理
						ScreenInputPermissionControl(true);

						// 更新モードの場合は、メーカーマスタコードのみ入力不可とする
						this.GoodsMakerCdRF_tNedit.Enabled = false;

						// フォーカス設定
						this.MakerNameRF_tEdit.Focus();
						this.MakerNameRF_tEdit.SelectAll();
					}
				}
				else
				{
					// 削除モード
					this.Mode_Label.Text = DELETE_MODE;

					// ボタン設定
					this.Ok_Button.Visible = false;
					this.Delete_Button.Visible = true;
					this.Revive_Button.Visible = true;
					
					//_dataIndexバッファ保持
					this._indexBuf = this._dataIndex;

					// 画面入力許可制御処理
					ScreenInputPermissionControl(false);

					// 画面展開処理
					MakerUMntToScreen(makerU);

					// フォーカス設定
					this.Delete_Button.Focus();
				}

			}
		}

		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <param name="enabled">入力許可設定値</param>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void ScreenInputPermissionControl(bool enabled)
		{
			this.GoodsMakerCdRF_tNedit.Enabled = enabled;
            this.MakerNameRF_tEdit.Enabled = enabled;
            //this.MakerShortNameRF_tEdit.Enabled = enabled;    // DEL 2009/06/12
			this.MakerKanaNameRF_tEdit.Enabled = enabled;
			this.DisplayOrderRF_tNedit.Enabled = enabled;
		}

		/// <summary>
        /// メーカーマスタ クラス画面展開処理
		/// </summary>
        /// <param name="makerU">メーカーマスタ オブジェクト</param>
		/// <remarks>
        /// <br>Note       : メーカーマスタ オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		private void MakerUMntToScreen(MakerUMnt makerU)
		{
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
            //this.Guid_Label.Text = makerU.FileHeaderGuid.ToString();
            this.Guid_Label.Text = CreateHashKey(makerU).ToString();
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
            this.Division_Label.Text = makerU.Division.ToString();
			this.DivisionName_Label.Text = makerU.DivisionName;
			//this.GoodsMakerCdRF_tNedit.Text = makerU.GoodsMakerCd.ToString();
			this.GoodsMakerCdRF_tNedit.SetInt(makerU.GoodsMakerCd);

			this.MakerNameRF_tEdit.Text = makerU.MakerName;
            //this.MakerShortNameRF_tEdit.Text = makerU.MakerShortName;     // DEL 2009/06/12
			this.MakerKanaNameRF_tEdit.Text = makerU.MakerKanaName;
			//this.DisplayOrderRF_tNedit.Text = makerU.DisplayOrder.ToString();
			this.DisplayOrderRF_tNedit.SetInt(makerU.DisplayOrder);
		}

		/// <summary>
		/// Valueチェック処理（int）
		/// </summary>
		/// <param name="sorce">tComboのValue</param>
		/// <returns>チェック後の値</returns>
		/// <remarks>
		/// <br>Note       : tComboの値をClassに入れる時のNULLチェックを行います。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private int ValueToInt(object sorce)
		{
			int dest = 0;
			try
			{
				dest = Convert.ToInt32(sorce);
			}
			catch
			{
				return dest;
			}
			return dest;
		}

		/// <summary>
        /// 画面情報メーカーマスタ クラス格納処理
		/// </summary>
        /// <param name="makerU">メーカーマスタ オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 画面情報からメーカーマスタ オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void DispToMakerUMnt(ref MakerUMnt makerU)
		{
            if (makerU == null)
			{
				// 新規の場合
                makerU = new MakerUMnt();
			}

            makerU.EnterpriseCode = this._enterpriseCode;

			if (this.Division_Label.Text == null || this.Division_Label.Text == "")
			{
				makerU.Division = DIVISION_USR;
			}
			else
			{
				makerU.Division = int.Parse(this.Division_Label.Text);
			}
			makerU.DivisionName = this.DivisionName_Label.Text;

			if (this.GoodsMakerCdRF_tNedit.Text == "0" || this.GoodsMakerCdRF_tNedit.Text == "")
            //if (this.GoodsMakerCdRF_tNedit.Text == null || this.GoodsMakerCdRF_tNedit.Text == "")
            {
				makerU.GoodsMakerCd = 0;
				//makerU.GoodsMakerCd = "";
			}
            else
            {
				makerU.GoodsMakerCd = int.Parse(this.GoodsMakerCdRF_tNedit.Text);
				//makerU.GoodsMakerCd = this.GoodsMakerCdRF_tNedit.Text;  
            }
			makerU.MakerName = this.MakerNameRF_tEdit.Text;

            //makerU.MakerShortName = this.MakerShortNameRF_tEdit.Text;     // DEL 2009/06/12
			makerU.MakerKanaName = this.MakerKanaNameRF_tEdit.Text;


			//if (this.DisplayOrderRF_tNedit.Text == null	|| this.DisplayOrderRF_tNedit.Text == "")
			if (this.DisplayOrderRF_tNedit.Text == "0"	|| this.DisplayOrderRF_tNedit.Text == "")
			{
				makerU.DisplayOrder = 0;
			}
			else
			{
				makerU.DisplayOrder = int.Parse(this.DisplayOrderRF_tNedit.Text);
			}
		}

		/// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <param name="loginID">ログインID</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
        // 2007.03.27  S.Koga  amdne ------------------------------------------------------
 		//private bool ScreenDataCheck(ref Control control, ref string message, ref Infragistics.Win.UltraWinTabControl.UltraTab selectedTab, string loginID)
 		private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
        // --------------------------------------------------------------------------------
		{
			bool result = true;

			if (this.GoodsMakerCdRF_tNedit.Text == "0" || this.GoodsMakerCdRF_tNedit.Text == "")
            //if (this.GoodsMakerCdRF_tNedit.Text == "")
			{
                // メーカーコード
				control = this.GoodsMakerCdRF_tNedit;
				message = this.GoodsMakerCd_Title_Label.Text + "を入力して下さい。";
				result = false;
			}
			else if (this.MakerNameRF_tEdit.Text.Trim() == "")
			{
                // メーカー名
				control = this.MakerNameRF_tEdit;
                message = this.MakerName_Title_Label.Text + "を入力して下さい。";
				result = false;
			}
            // DEL 2009/06/12 ------>>>
            //else if (this.MakerShortNameRF_tEdit.Text.Trim() == "")
            //{
            //    // メーカー略称
            //    control = this.MakerShortNameRF_tEdit;
            //    message = this.MakerShortName_Title_Label.Text + "を入力して下さい。";
            //    result = false;
            //}
            // DEL 2009/06/12 ------<<<
            else if (this.MakerKanaNameRF_tEdit.Text.Trim() == "")
			{
                // メーカー名(ｶﾅ)
				control = this.MakerKanaNameRF_tEdit;
				message = this.MakerKanaName_Title_Label.Text + "を入力して下さい。";
				result = false;
			}
/*
			//else if (this.DisplayOrderRF_tNedit.Text.Trim() == "")
			else if (this.DisplayOrderRF_tNedit.Text == "0" || this.DisplayOrderRF_tNedit.Text == "")
			{
				// 表示順位
				control = this.DisplayOrderRF_tNedit;
				message = this.DisplayOrder_Title_Label.Text + "を入力して下さい。";
				result = false;
			}
*/
			return result;
		}

		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="operation">オペレーション</param>
		/// <param name="erObject">エラーオブジェクト</param>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
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
        // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
        /// <summary>
        /// HashTable用キー作成
        /// </summary>
        /// <param name="makerUMnt">MakerUMntクラス</param>
        /// <returns>Hashテーブル用キー</returns>
        /// <remarks>
        /// <br>Note      : MakerUMntクラスからハッシュテーブル用のキーを作成します。</br>
        /// <br>Programer : 96012 日色 馨</br>
        /// <br>Date      : 2008.02.29</br>
        /// </remarks>
        private string CreateHashKey(MakerUMnt makerUMnt)
        {
            return makerUMnt.GoodsMakerCd.ToString("d6");
        }
        // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
        # endregion

		#region ■Control Events
		/// <summary>
		/// Form.Load イベント(MAKHN09110UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
        private void MAKHN09110UA_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList25 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList25;
			this.Cancel_Button.ImageList = imageList25;
			this.Revive_Button.ImageList = imageList25;
			this.Delete_Button.ImageList = imageList25;

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

			// 画面初期設定処理
			ScreenInitialSetting();
		}

		/// <summary>
        /// Form.Closing イベント(MAKHN09110UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
        private void MAKHN09110UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        /// Control.VisibleChanged イベント(MAKHN09110UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
        private void MAKHN09110UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				this.Owner.Activate();
				return;
			}

			// 自分自身が非表示になった場合、
			// またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}

			Initial_Timer.Enabled = true;
			ScreenClear();
		}

		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			if (SaveProc() == false)
			{
				return;
			}
			// 新規モードの場合は画面を終了せずに連続入力を可能とする
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				// データインデックスを初期化する
				this.DataIndex = -1;

				// 画面クリア処理
				ScreenClear();

				// 新規モード
				this.Mode_Label.Text = INSERT_MODE;
				DivisionName_Label.Text = DIVISION_USR_NAME_TITLE;
				Division_Label.Text = DIVISION_USR_NAME;

				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				ScreenInputPermissionControl(true);

				// クローンを再度取得する
				MakerUMnt makerU = new MakerUMnt();
				
				//クローン作成
				this._makerUClone = makerU.Clone(); 
				DispToMakerUMnt(ref this._makerUClone);

				this.GoodsMakerCdRF_tNedit.Focus();
			}
			else
			{
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
		}

		/// <summary>
        /// メーカーマスタ 情報登録処理
		/// </summary>
		/// <returns>登録結果（true:OK／false:NG）</returns>
		/// <remarks>
        /// <br>Note       : メーカーマスタ 情報登録を行います。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		private bool SaveProc()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			Control control = null;
			string message = null;
			string loginID = "";
            // 2007.03.27  S.Koga  delete -------------------------------------------------
            //Infragistics.Win.UltraWinTabControl.UltraTab selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
            // ----------------------------------------------------------------------------

			MakerUMnt makerU = null;

			if (this.DataIndex >= 0)
			{
                // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
                //Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                string guid = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
                makerU = ((MakerUMnt)this._makerUTable[guid]).Clone();
			}

            // 2007.03.27  S.Koga  amend --------------------------------------------------
            //if (!ScreenDataCheck(ref control, ref message, ref selectedTab, loginID))
            if (!ScreenDataCheck(ref control, ref message, loginID))
            // ----------------------------------------------------------------------------
            {
				TMsgDisp.Show( 
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
					ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
					message,							// 表示するメッセージ 
					0,									// ステータス値
					MessageBoxButtons.OK);				// 表示するボタン

                // 2007.03.27  S.Koga  delete ---------------------------------------------
                //this.MainTabControl.SelectedTab = selectedTab;
                // ------------------------------------------------------------------------
				control.Focus();
				return false;
			}

			this.DispToMakerUMnt(ref makerU);

			status = this._makerUAcs.Write(ref makerU);
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
						ERR_DPR_MSG,						// 表示するメッセージ 
						status,								// ステータス値
						MessageBoxButtons.OK);				// 表示するボタン

                    // 2007.03.27  S.Koga  delete -----------------------------------------
                    //this.MainTabControl.SelectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                    // --------------------------------------------------------------------
					this.GoodsMakerCdRF_tNedit.Focus();
					return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._makerUAcs);

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
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"SaveProc",							// 処理名称
						TMsgDisp.OPE_UPDATE,				// オペレーション
						ERR_UPDT_MSG,						// 表示するメッセージ 
						status,								// ステータス値
						this._makerUAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					
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
			}

			// DataSet展開処理
			MakerUMntToDataSet(makerU, this.DataIndex);
			
			return true;
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// 削除モード以外の場合は保存確認処理を行う
			if (this.Mode_Label.Text != DELETE_MODE) 
			{
				//保存確認
				MakerUMnt compareMakerUMnt = new MakerUMnt();
				compareMakerUMnt = this._makerUClone.Clone();  
				//現在の画面情報を取得する
				DispToMakerUMnt(ref compareMakerUMnt);
				//最初に取得した画面情報と比較
				if (!(this._makerUClone.Equals(compareMakerUMnt)))	
				{
					//画面情報が変更されていた場合は、保存確認メッセージを表示する
					DialogResult res = TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						"",									// 表示するメッセージ 
						0,									// ステータス値
						MessageBoxButtons.YesNoCancel);		// 表示するボタン

					switch(res)
					{
						case DialogResult.Yes:
						{
							if (SaveProc() == false)
							{
								return;
							}

							if (UnDisplaying != null)
							{
								MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
								UnDisplaying(this, me);
							}

							break;
						}
						case DialogResult.No:
						{
							if (UnDisplaying != null)
							{
								MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
								UnDisplaying(this, me);
							}

							break;
						}
						default:
						{
							// 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                GoodsMakerCdRF_tNedit.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                            return;
						}
					}
				}
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
		}

		/// <summary>
		/// Control.Click イベント(Delete_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			int status = 0;
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
                // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
                //Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                string guid = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
                // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
                MakerUMnt makerU = ((MakerUMnt)this._makerUTable[guid]).Clone();

				status = this._makerUAcs.Delete(makerU);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this.DataIndex].Delete();
                        // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
                        //this._makerUTable.Remove(makerU.FileHeaderGuid);
                        this._makerUTable.Remove(CreateHashKey(makerU));
                        // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._makerUAcs);

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
							this._makerUAcs,					  // エラーが発生したオブジェクト
							MessageBoxButtons.OK,				  // 表示するボタン
							MessageBoxDefaultButton.Button1);	  // 初期表示ボタン
						
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
		/// <br>Note 　　  : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
            //Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
            string guid = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
            MakerUMnt makerU = ((MakerUMnt)_makerUTable[guid]).Clone();

			status = this._makerUAcs.Revival(ref makerU);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._makerUAcs);

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
						this._makerUAcs,					  // エラーが発生したオブジェクト
						MessageBoxButtons.OK,				  // 表示するボタン
						MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

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
					
					return;
				}
			}

			// DataSet展開処理
			MakerUMntToDataSet(makerU, this.DataIndex);

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
        /// <br>Programmer  : 96186 立花裕輔</br>
        /// <br>Date        : 2007.08.01</br>
        /// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}

		/// <summary>
		/// TRetKeyControl.ChangeFocus イベント イベント(tRetKeyControl1)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォーカスが遷移する際に発生します。</br>
        /// <br>Programmer  : 96186 立花裕輔</br>
        /// <br>Date        : 2007.08.01</br>
        /// </remarks>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
            // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            if (e.PrevCtrl == null)
            {
                return;
            }

            _modeFlg = false;

            switch (e.PrevCtrl.Name)
            {
                case "GoodsMakerCdRF_tNedit":
                    // メーカーコードにフォーカスがある場合
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // 遷移先が閉じるボタン
                        _modeFlg = true;
                    }
                    else if (this._dataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            e.NextCtrl = GoodsMakerCdRF_tNedit;
                        }
                    }
                    break;
            }
            // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        }

        /// <summary>
        /// MakerNameRF_tEdit_ValueChanged
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : メーカー名の値が変更されると発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.09.16</br>
        /// </remarks>
        private void MakerNameRF_tEdit_ValueChanged(object sender, EventArgs e)
        {
            TEdit tEdit = sender as TEdit;

            if (tEdit.Text == "")
            {
                this.MakerKanaNameRF_tEdit.Text = "";
            }
        }

        /// <summary>
        /// MakerKanaNameRF_tEdit_ValueChanged
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : メーカー名(ｶﾅ)の値が変更されると発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.09.16</br>
        /// </remarks>
        private void MakerKanaNameRF_tEdit_ValueChanged(object sender, EventArgs e)
        {
            TEdit tEdit = sender as TEdit;
            // 全角カナを半角ｶﾅに強制変換
            tEdit.Text = Microsoft.VisualBasic.Strings.StrConv(tEdit.Text, Microsoft.VisualBasic.VbStrConv.Narrow, 0);
        }

		# endregion

        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // メーカーコード
            int makerCd = GoodsMakerCdRF_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsMakerCd = (int)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GOODSMAKERCD_TITLE];
                if (makerCd == dsMakerCd)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのメーカーマスタ情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // メーカーコードのクリア
                        GoodsMakerCdRF_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードのメーカーマスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
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
                                // メーカーコードのクリア
                                GoodsMakerCdRF_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
    }

    # region メーカーマスタ情報印刷範囲クラス
    /// <summary>
    /// メーカーマスタ情報印刷範囲クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : メーカーマスタ情報印刷範囲のクラスです。</br>
    /// <br>Programmer : 96186 立花裕輔</br>
    /// <br>Date       : 2007.08.01</br>
    /// <br></br>
	/// </remarks>
	public class sendMakerUMntData
	{
		/// <summary>
        /// メーカーマスタ情報印刷範囲クラスデータセット処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 印刷用のデータセットです。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		public DataSet dataSet;

		/// <summary>
        /// メーカーマスタ情報ハッシュテーブル
		/// </summary>
		/// <remarks>
		/// <br>Note       : 印刷用のハッシュテーブルです。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		public Hashtable emphashtable;
	}
	# endregion

    # region メーカーマスタ情報印刷抽出条件クラス
    /// <summary>
    /// メーカーマスタ情報印刷抽出条件クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : メーカーマスタ情報印刷抽出条件のクラスです。</br>
    /// <br>Programmer : 96186 立花裕輔</br>
    /// <br>Date       : 2007.08.01</br>
    /// <br></br>
	/// </remarks>
	public class ConditionData
	{
		/// <summary>
        /// 開始メーカーマスタコード
		/// </summary>
		public int StartMakerUMntCode;
		/// <summary>
        /// 終了メーカーマスタコード
		/// </summary>
        public int EndMakerUMntCode;
	}
	# endregion
}
