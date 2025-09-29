# region ※using

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

using Infragistics.Win.Misc;

using Microsoft.VisualBasic;
using System.Collections.Generic;

# endregion

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ＢＬ商品コードマスタ フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note		: ＢＬ商品コードマスタ情報の設定を行います。
	///					  IMasterMaintenanceMultiTypeを実装しています。</br>
	/// <br>Programmer	: 96186 立花裕輔</br>
	/// <br>Date		: 2007.08.01</br>
	/// <br>UpdateNote  : 2008.02.29 30167　上野　弘貴</br>
	/// <br>            : ハッシュキーをGUIDからテーブルプライマリキーに修正</br>
	/// <br>UpdateNote  : 2008.03.31 30167　上野　弘貴</br>
	/// <br>            : 更新画面起動時キー項目を設定できてしまう不具合修正</br>
	/// <br>            : 提供画面起動時各項目を設定できてしまう不具合修正</br>
    /// <br>UpdateNote  : 2008/06/10 30414　忍　幸史</br>
    /// <br>            : 「BLグループコード」「BLグループコード名称」「商品掛率グループコード」「商品掛率グループ名称」追加</br>
    /// <br>            : 「商品区分グループコード」「商品区分グループコード名称」「商品区分コード」「商品区分コード名称」「商品区分詳細」「商品区分詳細名称」削除</br>
    /// <br>UpdateNote  : 2009/03/17 30452　上野　俊治</br>
    /// <br>            : カナ入力補助の出力先を設定</br>
    /// </remarks>
    public class DCKHN09090UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
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
        private Infragistics.Win.Misc.UltraLabel Guid_Label;
        private TEdit BLGoodsFullNameRF_tEdit;
        private Infragistics.Win.Misc.UltraLabel BLGoodsFullName_Title_Label;
        private Infragistics.Win.Misc.UltraLabel BLGoodsCode_Title_Label;
		private Infragistics.Win.Misc.UltraLabel BLGoodsHalfName_Title_Label;
		private Infragistics.Win.Misc.UltraLabel BLGoodsGenreCode_Title_Label;
        private Infragistics.Win.Misc.UltraLabel Division_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
		private UltraLabel ultraLabel1;
        private TNedit tNedit_BLGoodsCode;
        private UltraLabel DivisionName_Label;
        private TComboEditor EquipGenre_tComboEditor;
        private TNedit tNedit_BLGloupCode;
        private UltraLabel GoodsRateGrp_uLabel;
        private UltraLabel BLGloup_uLabel;
        private TEdit GoodsRateGrpName_tEdit;
        private TNedit tNedit_GoodsRateGrpCode;
        private TEdit BLGloupName_tEdit;
        private UltraButton GoodsRateGrpGuide_Button;
        private UltraButton BLGloupGuide_Button;
        private UiSetControl uiSetControl1;
        private TImeControl tImeControl1;
        private TEdit tEdit_BLGoodsHalfName;
        private UltraButton Renewal_Button;
		private System.ComponentModel.IContainer components;
		# endregion

		# region ■Constructor
		/// <summary>
        /// ＢＬ商品コードマスタ フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : ＢＬ商品コードマスタ フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 96186 立花裕輔</br>
		/// <br>Date       : 2007.08.01</br>
		/// </remarks>
        public DCKHN09090UA()
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
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;

			//　企業コード取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// 変数初期化
			this._dataIndex = -1;
			this._secInfoAcs = new SecInfoAcs();
			this._bLGoodsCdAcs = new BLGoodsCdAcs();
            //this._userGuideAcs = new UserGuideAcs();  // iitani d 2007.05.18
			 
			this._totalCount = 0;
            this._bLGoodsCdUMntTable = new Hashtable();

			//_dataIndexバッファ（メインフレーム最小化対応）
			this._indexBuf = -2;

			// 拠点OPの判定
			this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            this._bLGroupUAcs = new BLGroupUAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();

            // 各種マスタ読込
            ReadBLGroup();
            ReadGoodsRateGrp();
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
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("ｸﾞﾙｰﾌﾟｺｰﾄﾞガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("商品中分類ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKHN09090UA));
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
            this.BLGoodsFullNameRF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.BLGoodsCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BLGoodsFullName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Guid_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BLGoodsHalfName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BLGoodsGenreCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Division_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.BLGloupGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.GoodsRateGrpGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_BLGoodsCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DivisionName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EquipGenre_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.BLGloup_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsRateGrp_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_BLGloupCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.BLGloupName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_GoodsRateGrpCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.GoodsRateGrpName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.tImeControl1 = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.tEdit_BLGoodsHalfName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsFullNameRF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EquipGenre_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGloupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGloupName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsRateGrpCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsRateGrpName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_BLGoodsHalfName)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(253, 448);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 11;
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
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 499);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(520, 23);
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
            appearance25.ForeColor = System.Drawing.Color.White;
            appearance25.TextHAlignAsString = "Center";
            appearance25.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance25;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(400, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(115, 23);
            this.Mode_Label.TabIndex = 658;
            this.Mode_Label.Text = "更新モード";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(128, 448);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 10;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(253, 448);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 11;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(378, 448);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 12;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // BLGoodsFullNameRF_tEdit
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BLGoodsFullNameRF_tEdit.ActiveAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance16.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            this.BLGoodsFullNameRF_tEdit.Appearance = appearance16;
            this.BLGoodsFullNameRF_tEdit.AutoSelect = true;
            this.BLGoodsFullNameRF_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BLGoodsFullNameRF_tEdit.DataText = "";
            this.BLGoodsFullNameRF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BLGoodsFullNameRF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.BLGoodsFullNameRF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.BLGoodsFullNameRF_tEdit.Location = new System.Drawing.Point(161, 150);
            this.BLGoodsFullNameRF_tEdit.MaxLength = 20;
            this.BLGoodsFullNameRF_tEdit.Name = "BLGoodsFullNameRF_tEdit";
            this.BLGoodsFullNameRF_tEdit.Size = new System.Drawing.Size(330, 24);
            this.BLGoodsFullNameRF_tEdit.TabIndex = 1;
            this.BLGoodsFullNameRF_tEdit.ValueChanged += new System.EventHandler(this.BLGoodsFullNameRF_tEdit_ValueChanged);
            // 
            // BLGoodsCode_Title_Label
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.BLGoodsCode_Title_Label.Appearance = appearance6;
            this.BLGoodsCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BLGoodsCode_Title_Label.Location = new System.Drawing.Point(23, 111);
            this.BLGoodsCode_Title_Label.Name = "BLGoodsCode_Title_Label";
            this.BLGoodsCode_Title_Label.Size = new System.Drawing.Size(123, 24);
            this.BLGoodsCode_Title_Label.TabIndex = 610;
            this.BLGoodsCode_Title_Label.Text = "BLｺｰﾄﾞ";
            // 
            // BLGoodsFullName_Title_Label
            // 
            appearance28.TextVAlignAsString = "Middle";
            this.BLGoodsFullName_Title_Label.Appearance = appearance28;
            this.BLGoodsFullName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BLGoodsFullName_Title_Label.Location = new System.Drawing.Point(23, 150);
            this.BLGoodsFullName_Title_Label.Name = "BLGoodsFullName_Title_Label";
            this.BLGoodsFullName_Title_Label.Size = new System.Drawing.Size(123, 24);
            this.BLGoodsFullName_Title_Label.TabIndex = 611;
            this.BLGoodsFullName_Title_Label.Text = "BLｺｰﾄﾞ名";
            // 
            // Guid_Label
            // 
            this.Guid_Label.Location = new System.Drawing.Point(381, 34);
            this.Guid_Label.Name = "Guid_Label";
            this.Guid_Label.Size = new System.Drawing.Size(240, 25);
            this.Guid_Label.TabIndex = 46;
            this.Guid_Label.Visible = false;
            // 
            // BLGoodsHalfName_Title_Label
            // 
            appearance24.TextVAlignAsString = "Middle";
            this.BLGoodsHalfName_Title_Label.Appearance = appearance24;
            this.BLGoodsHalfName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BLGoodsHalfName_Title_Label.Location = new System.Drawing.Point(23, 189);
            this.BLGoodsHalfName_Title_Label.Name = "BLGoodsHalfName_Title_Label";
            this.BLGoodsHalfName_Title_Label.Size = new System.Drawing.Size(123, 24);
            this.BLGoodsHalfName_Title_Label.TabIndex = 600;
            this.BLGoodsHalfName_Title_Label.Text = "BLｺｰﾄﾞ名(ｶﾅ)";
            // 
            // BLGoodsGenreCode_Title_Label
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.BLGoodsGenreCode_Title_Label.Appearance = appearance10;
            this.BLGoodsGenreCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BLGoodsGenreCode_Title_Label.Location = new System.Drawing.Point(23, 228);
            this.BLGoodsGenreCode_Title_Label.Name = "BLGoodsGenreCode_Title_Label";
            this.BLGoodsGenreCode_Title_Label.Size = new System.Drawing.Size(123, 24);
            this.BLGoodsGenreCode_Title_Label.TabIndex = 640;
            this.BLGoodsGenreCode_Title_Label.Text = "装備分類";
            // 
            // Division_Label
            // 
            this.Division_Label.Location = new System.Drawing.Point(208, 55);
            this.Division_Label.Name = "Division_Label";
            this.Division_Label.Size = new System.Drawing.Size(240, 25);
            this.Division_Label.TabIndex = 66;
            this.Division_Label.Visible = false;
            // 
            // ultraLabel15
            // 
            this.ultraLabel15.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel15.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel15.Location = new System.Drawing.Point(23, 272);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(480, 3);
            this.ultraLabel15.TabIndex = 621;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // BLGloupGuide_Button
            // 
            this.BLGloupGuide_Button.Location = new System.Drawing.Point(219, 295);
            this.BLGloupGuide_Button.Name = "BLGloupGuide_Button";
            this.BLGloupGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.BLGloupGuide_Button.TabIndex = 5;
            ultraToolTipInfo2.ToolTipText = "ｸﾞﾙｰﾌﾟｺｰﾄﾞガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.BLGloupGuide_Button, ultraToolTipInfo2);
            this.BLGloupGuide_Button.Click += new System.EventHandler(this.BLGloupGuide_Button_Click);
            // 
            // GoodsRateGrpGuide_Button
            // 
            this.GoodsRateGrpGuide_Button.Location = new System.Drawing.Point(219, 364);
            this.GoodsRateGrpGuide_Button.Name = "GoodsRateGrpGuide_Button";
            this.GoodsRateGrpGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.GoodsRateGrpGuide_Button.TabIndex = 8;
            ultraToolTipInfo1.ToolTipText = "商品中分類ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.GoodsRateGrpGuide_Button, ultraToolTipInfo1);
            this.GoodsRateGrpGuide_Button.Click += new System.EventHandler(this.GoodsRateGrpGuide_Button_Click);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel1.Location = new System.Drawing.Point(21, 88);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(480, 3);
            this.ultraLabel1.TabIndex = 627;
            // 
            // tNedit_BLGoodsCode
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.TextHAlignAsString = "Right";
            this.tNedit_BLGoodsCode.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Right";
            this.tNedit_BLGoodsCode.Appearance = appearance9;
            this.tNedit_BLGoodsCode.AutoSelect = true;
            this.tNedit_BLGoodsCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_BLGoodsCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGoodsCode.DataText = "";
            this.tNedit_BLGoodsCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGoodsCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_BLGoodsCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_BLGoodsCode.Location = new System.Drawing.Point(161, 111);
            this.tNedit_BLGoodsCode.MaxLength = 8;
            this.tNedit_BLGoodsCode.Name = "tNedit_BLGoodsCode";
            this.tNedit_BLGoodsCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BLGoodsCode.Size = new System.Drawing.Size(43, 24);
            this.tNedit_BLGoodsCode.TabIndex = 0;
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
            this.DivisionName_Label.Location = new System.Drawing.Point(21, 50);
            this.DivisionName_Label.Name = "DivisionName_Label";
            this.DivisionName_Label.Size = new System.Drawing.Size(172, 24);
            this.DivisionName_Label.TabIndex = 2296;
            this.DivisionName_Label.Text = "ユーザーデータ";
            // 
            // EquipGenre_tComboEditor
            // 
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EquipGenre_tComboEditor.ActiveAppearance = appearance29;
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance30.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance30.ForeColorDisabled = System.Drawing.Color.Black;
            this.EquipGenre_tComboEditor.Appearance = appearance30;
            this.EquipGenre_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.EquipGenre_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EquipGenre_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EquipGenre_tComboEditor.ItemAppearance = appearance31;
            this.EquipGenre_tComboEditor.Location = new System.Drawing.Point(161, 228);
            this.EquipGenre_tComboEditor.MaxDropDownItems = 18;
            this.EquipGenre_tComboEditor.Name = "EquipGenre_tComboEditor";
            this.EquipGenre_tComboEditor.Size = new System.Drawing.Size(151, 24);
            this.EquipGenre_tComboEditor.TabIndex = 3;
            // 
            // BLGloup_uLabel
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.BLGloup_uLabel.Appearance = appearance7;
            this.BLGloup_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.BLGloup_uLabel.Location = new System.Drawing.Point(23, 295);
            this.BLGloup_uLabel.Name = "BLGloup_uLabel";
            this.BLGloup_uLabel.Size = new System.Drawing.Size(123, 24);
            this.BLGloup_uLabel.TabIndex = 2298;
            this.BLGloup_uLabel.Text = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
            // 
            // GoodsRateGrp_uLabel
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.GoodsRateGrp_uLabel.Appearance = appearance21;
            this.GoodsRateGrp_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.GoodsRateGrp_uLabel.Location = new System.Drawing.Point(23, 364);
            this.GoodsRateGrp_uLabel.Name = "GoodsRateGrp_uLabel";
            this.GoodsRateGrp_uLabel.Size = new System.Drawing.Size(123, 24);
            this.GoodsRateGrp_uLabel.TabIndex = 2299;
            this.GoodsRateGrp_uLabel.Text = "商品中分類";
            // 
            // tNedit_BLGloupCode
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.TextHAlignAsString = "Right";
            this.tNedit_BLGloupCode.ActiveAppearance = appearance13;
            appearance14.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Right";
            this.tNedit_BLGloupCode.Appearance = appearance14;
            this.tNedit_BLGloupCode.AutoSelect = true;
            this.tNedit_BLGloupCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGloupCode.DataText = "";
            this.tNedit_BLGloupCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGloupCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_BLGloupCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_BLGloupCode.Location = new System.Drawing.Point(161, 295);
            this.tNedit_BLGloupCode.MaxLength = 5;
            this.tNedit_BLGloupCode.Name = "tNedit_BLGloupCode";
            this.tNedit_BLGloupCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BLGloupCode.Size = new System.Drawing.Size(35, 24);
            this.tNedit_BLGloupCode.TabIndex = 4;
            // 
            // BLGloupName_tEdit
            // 
            this.BLGloupName_tEdit.AcceptsTab = true;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BLGloupName_tEdit.ActiveAppearance = appearance11;
            appearance12.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            this.BLGloupName_tEdit.Appearance = appearance12;
            this.BLGloupName_tEdit.AutoSelect = true;
            this.BLGloupName_tEdit.DataText = "";
            this.BLGloupName_tEdit.Enabled = false;
            this.BLGloupName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BLGloupName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.BLGloupName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.BLGloupName_tEdit.Location = new System.Drawing.Point(161, 325);
            this.BLGloupName_tEdit.MaxLength = 20;
            this.BLGloupName_tEdit.Name = "BLGloupName_tEdit";
            this.BLGloupName_tEdit.ReadOnly = true;
            this.BLGloupName_tEdit.Size = new System.Drawing.Size(330, 24);
            this.BLGloupName_tEdit.TabIndex = 6;
            // 
            // tNedit_GoodsRateGrpCode
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.TextHAlignAsString = "Right";
            this.tNedit_GoodsRateGrpCode.ActiveAppearance = appearance4;
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            this.tNedit_GoodsRateGrpCode.Appearance = appearance5;
            this.tNedit_GoodsRateGrpCode.AutoSelect = true;
            this.tNedit_GoodsRateGrpCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsRateGrpCode.DataText = "";
            this.tNedit_GoodsRateGrpCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsRateGrpCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_GoodsRateGrpCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_GoodsRateGrpCode.Location = new System.Drawing.Point(161, 364);
            this.tNedit_GoodsRateGrpCode.MaxLength = 5;
            this.tNedit_GoodsRateGrpCode.Name = "tNedit_GoodsRateGrpCode";
            this.tNedit_GoodsRateGrpCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_GoodsRateGrpCode.Size = new System.Drawing.Size(35, 24);
            this.tNedit_GoodsRateGrpCode.TabIndex = 7;
            // 
            // GoodsRateGrpName_tEdit
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsRateGrpName_tEdit.ActiveAppearance = appearance26;
            appearance27.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance27.ForeColorDisabled = System.Drawing.Color.Black;
            this.GoodsRateGrpName_tEdit.Appearance = appearance27;
            this.GoodsRateGrpName_tEdit.AutoSelect = true;
            this.GoodsRateGrpName_tEdit.DataText = "";
            this.GoodsRateGrpName_tEdit.Enabled = false;
            this.GoodsRateGrpName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GoodsRateGrpName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.GoodsRateGrpName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.GoodsRateGrpName_tEdit.Location = new System.Drawing.Point(161, 394);
            this.GoodsRateGrpName_tEdit.MaxLength = 20;
            this.GoodsRateGrpName_tEdit.Name = "GoodsRateGrpName_tEdit";
            this.GoodsRateGrpName_tEdit.ReadOnly = true;
            this.GoodsRateGrpName_tEdit.Size = new System.Drawing.Size(330, 24);
            this.GoodsRateGrpName_tEdit.TabIndex = 9;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // tImeControl1
            // 
            this.tImeControl1.InControl = this.BLGoodsFullNameRF_tEdit;
            this.tImeControl1.OutControl = this.tEdit_BLGoodsHalfName;
            this.tImeControl1.OwnerForm = this;
            this.tImeControl1.PutLength = 20;
            // 
            // tEdit_BLGoodsHalfName
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_BLGoodsHalfName.ActiveAppearance = appearance22;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance23.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_BLGoodsHalfName.Appearance = appearance23;
            this.tEdit_BLGoodsHalfName.AutoSelect = true;
            this.tEdit_BLGoodsHalfName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_BLGoodsHalfName.DataText = "";
            this.tEdit_BLGoodsHalfName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_BLGoodsHalfName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_BLGoodsHalfName.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.tEdit_BLGoodsHalfName.Location = new System.Drawing.Point(161, 189);
            this.tEdit_BLGoodsHalfName.MaxLength = 40;
            this.tEdit_BLGoodsHalfName.Name = "tEdit_BLGoodsHalfName";
            this.tEdit_BLGoodsHalfName.Size = new System.Drawing.Size(337, 24);
            this.tEdit_BLGoodsHalfName.TabIndex = 2;
            this.tEdit_BLGoodsHalfName.ValueChanged += new System.EventHandler(this.tEdit_BLGoodsHalfName_ValueChanged);
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(128, 448);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 10;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // DCKHN09090UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(520, 522);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.tEdit_BLGoodsHalfName);
            this.Controls.Add(this.GoodsRateGrpGuide_Button);
            this.Controls.Add(this.BLGloupGuide_Button);
            this.Controls.Add(this.GoodsRateGrpName_tEdit);
            this.Controls.Add(this.tNedit_GoodsRateGrpCode);
            this.Controls.Add(this.BLGloupName_tEdit);
            this.Controls.Add(this.tNedit_BLGloupCode);
            this.Controls.Add(this.GoodsRateGrp_uLabel);
            this.Controls.Add(this.BLGloup_uLabel);
            this.Controls.Add(this.EquipGenre_tComboEditor);
            this.Controls.Add(this.DivisionName_Label);
            this.Controls.Add(this.tNedit_BLGoodsCode);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.ultraLabel15);
            this.Controls.Add(this.Division_Label);
            this.Controls.Add(this.BLGoodsGenreCode_Title_Label);
            this.Controls.Add(this.BLGoodsHalfName_Title_Label);
            this.Controls.Add(this.Guid_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.BLGoodsFullNameRF_tEdit);
            this.Controls.Add(this.BLGoodsFullName_Title_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.BLGoodsCode_Title_Label);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DCKHN09090UA";
            this.Text = "BLｺｰﾄﾞマスタ";
            this.Load += new System.EventHandler(this.DCKHN09090UA_Load);
            this.VisibleChanged += new System.EventHandler(this.DCKHN09090UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.DCKHN09090UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsFullNameRF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EquipGenre_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGloupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGloupName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsRateGrpCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsRateGrpName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_BLGoodsHalfName)).EndInit();
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
        /// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList makerUMntretList = null;

            // 抽出対象件数が0の場合は全件抽出を実行する
            status = this._bLGoodsCdAcs.SearchAll(
                        out makerUMntretList,
                        this._enterpriseCode);

            this._totalCount = makerUMntretList.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (BLGoodsCdUMnt lgoodsgranre in makerUMntretList)
                        {
							//----- ueno upd ---------- start 2008.02.29
							// ハッシュキー取得
							string hashKey = CreateHashKey(lgoodsgranre);
							
							//if (this._bLGoodsCdUMntTable.ContainsKey(lgoodsgranre.FileHeaderGuid) == false)
							if (this._bLGoodsCdUMntTable.ContainsKey(hashKey) == false)
                            {
                                // DataSet展開
                                MakerUMntToDataSet(lgoodsgranre.Clone(), index);
                                ++index;
                            }
							//----- ueno upd ---------- end 2008.02.29
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
                            this._bLGoodsCdAcs,				  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

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
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		public int SearchNext(int readCount)
		{
			// ネクストデータ検索処理（未実装）
			return 0;
		}

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		public int Delete()
		{
			int status = 0;

			//----- ueno upd ---------- start 2008.02.29
			// ハッシュキー取得
			string hashKey = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
			BLGoodsCdUMnt bLGoodsCdUMnt = ((BLGoodsCdUMnt)this._bLGoodsCdUMntTable[hashKey]).Clone();

			//Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
			//BLGoodsCdUMnt bLGoodsCdUMnt = ((BLGoodsCdUMnt)this._bLGoodsCdUMntTable[guid]).Clone();
			//----- ueno upd ---------- end 2008.02.29

			if (bLGoodsCdUMnt.Division == DIVISION_OFR)
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

			status = this._bLGoodsCdAcs.LogicalDelete(ref bLGoodsCdUMnt);
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
					ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._bLGoodsCdAcs);
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
						this._bLGoodsCdAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン

					return status;
				}
			}

			// データセット展開処理
			MakerUMntToDataSet(bLGoodsCdUMnt.Clone(), this._dataIndex);
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

			appearanceTable.Add(BLGoodsCode_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			appearanceTable.Add(BLGoodsCdDerivedNo_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            appearanceTable.Add(BLGoodsFullName_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(BLGoodsHalfName_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			appearanceTable.Add(BLGoodsGenreCode_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(LargeGoodsGanreCode_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(LargeGoodsGanreName_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(MediumGoodsGanreCode_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(MediumGoodsGanreName_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(DetailGoodsGanreCode_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(DetailGoodsGanreName_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            // BLグループコード
            appearanceTable.Add(BLGloupCode_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // BLグループコード名称
            appearanceTable.Add(BLGloupCodeName_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 商品掛率グループコード
            appearanceTable.Add(GoodsRateGrpCode_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 商品掛率グループ名称
            appearanceTable.Add(GoodsRateGrpName_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 装備分類
            appearanceTable.Add(EquipGenre_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

            appearanceTable.Add(DIVISION_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(DIVISIONNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

			appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			return appearanceTable;
		}
		# endregion

		# endregion

		#region ■Private Menbers
		private BLGoodsCdAcs _bLGoodsCdAcs;
		private SecInfoAcs _secInfoAcs;
		private int _totalCount;
		private string _enterpriseCode;
        private Hashtable _bLGoodsCdUMntTable;
		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private BLGoodsCdUMnt _makerUClone;

		//_dataIndexバッファ（メインフレーム最小化対応）
		private int _indexBuf;
		/// <summary>拠点オプションフラグ</summary>
		private bool _optSection = false;

        // データ区分(0:ユーザー 1:提供)
        private int _divisionCode;

        private BLGroupUAcs _bLGroupUAcs;
        private GoodsGroupUAcs _goodsGroupUAcs;

        private Dictionary<int, BLGroupU> _blGroupUDic;
        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;

        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
		
		# endregion

		# region ■Consts
		// FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
		private const string DELETE_DATE = "削除日";
		private const string SECTIONNAME_TITLE = "所属拠点";

        private const string BLGoodsCode_TITLE = "BLｺｰﾄﾞ";
        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
		private const string BLGoodsCdDerivedNo_TITLE	= "枝番";
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
        private const string BLGoodsFullName_TITLE = "BLｺｰﾄﾞ名";
        private const string BLGoodsHalfName_TITLE = "BLｺｰﾄﾞ名(ｶﾅ)";
        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
		private const string BLGoodsGenreCode_TITLE	= "BL商品分類";
		private const string LargeGoodsGanreCode_TITLE	= "商品区分グループ";
		private const string LargeGoodsGanreName_TITLE	= "商品区分グループ名称";
		private const string MediumGoodsGanreCode_TITLE	= "商品区分";
		private const string MediumGoodsGanreName_TITLE	= "商品区分名称";
		private const string DetailGoodsGanreCode_TITLE	= "商品区分詳細";
		private const string DetailGoodsGanreName_TITLE	= "商品区分詳細名称";
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
        private const string EquipGenre_TITLE           = "装備分類";
        private const string BLGloupCode_TITLE = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
        private const string BLGloupCodeName_TITLE = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ名";
        private const string GoodsRateGrpCode_TITLE     = "商品中分類コード";
        private const string GoodsRateGrpName_TITLE = "商品中分類名";
        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
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

        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
        // 装備分類
        private const int EQUIPGANRE_CODE_0         = 0;
        private const int EQUIPGANRE_CODE_1001      = 1001;
        private const int EQUIPGANRE_CODE_1005      = 1005;
        private const int EQUIPGANRE_CODE_1010      = 1010;
        private const string EQUIPGANRE_NAME_0      = "無し";
        private const string EQUIPGANRE_NAME_1001   = "バッテリー";
        private const string EQUIPGANRE_NAME_1005   = "タイヤ";
        private const string EQUIPGANRE_NAME_1010   = "オイル";
        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";
		private const string REFERENCE_MODE = "参照モード";

		// コントロール名称
		private const string TAB1_NAME = "GeneralTab";
		private const string TAB2_NAME = "SecurityTab";

		// Message関連定義
		private const string ASSEMBLY_ID	= "DCKHN09090U";
		private const string PG_NM			= "BLｺｰﾄﾞマスタ";
		private const string ERR_READ_MSG	= "読み込みに失敗しました。";
		private const string ERR_DPR_MSG	= "このBLｺｰﾄﾞは既に使用されています。";
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
			System.Windows.Forms.Application.Run(new DCKHN09090UA());
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
        /// ＢＬ商品コードマスタ オブジェクトデータセット展開処理
		/// </summary>
		/// <param name="bLGoodsCdUMnt">ＢＬ商品コードマスタ オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
        /// <br>Note       : ＢＬ商品コードマスタ クラスをデータセットに格納します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void MakerUMntToDataSet(BLGoodsCdUMnt bLGoodsCdUMnt, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[MAKERU_TABLE].NewRow();
				this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Add(dataRow);

				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count - 1;
			}

			if (bLGoodsCdUMnt.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DELETE_DATE] = "";
			}
			else
			{
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DELETE_DATE] = bLGoodsCdUMnt.UpdateDateTimeJpInFormal;
            }

			//BL商品コード
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][BLGoodsCode_TITLE] = bLGoodsCdUMnt.BLGoodsCode.ToString("00000");
			//枝番
			//this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][BLGoodsCdDerivedNo_TITLE] = bLGoodsCdUMnt.BLGoodsCdDerivedNo;
			//BL商品コード名称（全角）
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][BLGoodsFullName_TITLE] = bLGoodsCdUMnt.BLGoodsFullName;
			//BL商品コード名称（半角）
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][BLGoodsHalfName_TITLE] = bLGoodsCdUMnt.BLGoodsHalfName;

            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			//BL商品分類
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][BLGoodsGenreCode_TITLE] = bLGoodsCdUMnt.BLGoodsGenreCode;
			//商品区分グループコード
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][LargeGoodsGanreCode_TITLE] = bLGoodsCdUMnt.LargeGoodsGanreCode;
			//商品区分グループ名称
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][LargeGoodsGanreName_TITLE] = bLGoodsCdUMnt.LargeGoodsGanreName;
			//商品区分コード
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][MediumGoodsGanreCode_TITLE] = bLGoodsCdUMnt.MediumGoodsGanreCode;
			//商品区分名称
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][MediumGoodsGanreName_TITLE] = bLGoodsCdUMnt.MediumGoodsGanreName;
			//商品区分詳細コード
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DetailGoodsGanreCode_TITLE] = bLGoodsCdUMnt.DetailGoodsGanreCode;
			//商品区分詳細名称
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DetailGoodsGanreName_TITLE] = bLGoodsCdUMnt.DetailGoodsGanreName;
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            // BLグループコード
            if (bLGoodsCdUMnt.BLGloupCode == 0)
            {
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][BLGloupCode_TITLE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][BLGloupCode_TITLE] = bLGoodsCdUMnt.BLGloupCode.ToString("00000");
            }
            // BLグループコード名称
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][BLGloupCodeName_TITLE] = GetBLGroupName(bLGoodsCdUMnt.BLGloupCode);
            // 商品掛率グループコード
            if (bLGoodsCdUMnt.GoodsRateGrpCode == 0)
            {
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsRateGrpCode_TITLE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsRateGrpCode_TITLE] = bLGoodsCdUMnt.GoodsRateGrpCode.ToString("0000");
            }
            // 商品掛率グループ名称
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsRateGrpName_TITLE] = GetGoodsRateGrpName(bLGoodsCdUMnt.GoodsRateGrpCode);
            // 装備分類
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][EquipGenre_TITLE] = GetEquipGenreName(bLGoodsCdUMnt.BLGoodsGenreCode);
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

            //データー区分
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DIVISION_TITLE] = bLGoodsCdUMnt.Division;
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][DIVISIONNAME_TITLE] = bLGoodsCdUMnt.DivisionName;

			//----- ueno upd ---------- start 2008.02.29
			// ハッシュキー取得
			string hashKey = CreateHashKey(bLGoodsCdUMnt);

			// キー設定
			this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GUID_TITLE] = hashKey;

			if (this._bLGoodsCdUMntTable.ContainsKey(hashKey))
			{
				this._bLGoodsCdUMntTable.Remove(hashKey);
			}
			this._bLGoodsCdUMntTable.Add(hashKey, bLGoodsCdUMnt);

			//// GUID
			//this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GUID_TITLE] = bLGoodsCdUMnt.FileHeaderGuid;

			//if (this._bLGoodsCdUMntTable.ContainsKey(bLGoodsCdUMnt.FileHeaderGuid))
			//{
			//    this._bLGoodsCdUMntTable.Remove(bLGoodsCdUMnt.FileHeaderGuid);
			//}
			//this._bLGoodsCdUMntTable.Add(bLGoodsCdUMnt.FileHeaderGuid, bLGoodsCdUMnt);
			//----- ueno upd ---------- end 2008.02.29
		}

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable makerUTable = new DataTable(MAKERU_TABLE);

			// Addを行う順番が、列の表示順位となります。
			makerUTable.Columns.Add(DELETE_DATE,           typeof(string));

			//BL商品コード
			makerUTable.Columns.Add(BLGoodsCode_TITLE, typeof(string));
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			//枝番
			makerUTable.Columns.Add(BLGoodsCdDerivedNo_TITLE, typeof(int));
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            //BL商品コード名称（全角）
			makerUTable.Columns.Add(BLGoodsFullName_TITLE, typeof(string));
			//BL商品コード名称（半角）
			makerUTable.Columns.Add(BLGoodsHalfName_TITLE, typeof(string));

            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			//BL商品分類
			makerUTable.Columns.Add(BLGoodsGenreCode_TITLE, typeof(int));
			//商品区分グループコード
			makerUTable.Columns.Add(LargeGoodsGanreCode_TITLE, typeof(string));
			//商品区分グループ名称
			makerUTable.Columns.Add(LargeGoodsGanreName_TITLE, typeof(string));
			//商品区分コード
			makerUTable.Columns.Add(MediumGoodsGanreCode_TITLE, typeof(string));
			//商品区分名称
			makerUTable.Columns.Add(MediumGoodsGanreName_TITLE, typeof(string));
			//商品区分詳細コード
			makerUTable.Columns.Add(DetailGoodsGanreCode_TITLE, typeof(string));
			//商品区分詳細名称
			makerUTable.Columns.Add(DetailGoodsGanreName_TITLE, typeof(string));
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            // BLグループコード
            makerUTable.Columns.Add(BLGloupCode_TITLE, typeof(string));
            // BLグループコード名称
            makerUTable.Columns.Add(BLGloupCodeName_TITLE, typeof(string));
            // 商品掛率グループコード
            makerUTable.Columns.Add(GoodsRateGrpCode_TITLE, typeof(string));
            // 商品掛率グループ名称
            makerUTable.Columns.Add(GoodsRateGrpName_TITLE, typeof(string));
            // 装備分類
            makerUTable.Columns.Add(EquipGenre_TITLE, typeof(string));
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

            //データ区分
			makerUTable.Columns.Add(DIVISION_TITLE, typeof(int));
			makerUTable.Columns.Add(DIVISIONNAME_TITLE, typeof(string));

			//----- ueno upd ---------- start 2008.02.29
			// GUID
			//makerUTable.Columns.Add(GUID_TITLE, typeof(Guid));
			makerUTable.Columns.Add(GUID_TITLE, typeof(string));
			//----- ueno upd ---------- end 2008.02.29

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
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
            this.Ok_Button.Location = new System.Drawing.Point(359, 490);
            this.Cancel_Button.Location = new System.Drawing.Point(484, 490);
            this.Delete_Button.Location = new System.Drawing.Point(234, 490);
            this.Revive_Button.Location = new System.Drawing.Point(359, 490);
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            // 装備分類
            this.EquipGenre_tComboEditor.Items.Add(EQUIPGANRE_CODE_0, EQUIPGANRE_NAME_0);         // 無し
            this.EquipGenre_tComboEditor.Items.Add(EQUIPGANRE_CODE_1001, EQUIPGANRE_NAME_1001);   // バッテリー
            this.EquipGenre_tComboEditor.Items.Add(EQUIPGANRE_CODE_1005, EQUIPGANRE_NAME_1005);   // タイヤ
            this.EquipGenre_tComboEditor.Items.Add(EQUIPGANRE_CODE_1010, EQUIPGANRE_NAME_1010);   // オイル
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
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

			this.tNedit_BLGoodsCode.Clear();
			//this.BLGoodsCdDerivedNoRF_tNedit.Clear();
			this.BLGoodsFullNameRF_tEdit.Clear();
			this.tEdit_BLGoodsHalfName.Clear();
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			this.BLGoodsGenreCodeRF_tNedit.Clear();
			this.LargeGoodsGanreCodeRF_tEdit.Clear();
			this.LargeGoodsGanreNameRF_tEdit.Clear();
			this.MediumGoodsGanreCodeRF_tEdit.Clear();
			this.MediumGoodsGanreNameRF_tEdit.Clear();
			this.DetailGoodsGanreCodeRF_tEdit.Clear();
			this.DetailGoodsGanreNameRF_tEdit.Clear();
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            this.EquipGenre_tComboEditor.SelectedIndex = 0;
            this.tNedit_BLGloupCode.Clear();
            this.BLGloupName_tEdit.Clear();
            this.tNedit_GoodsRateGrpCode.Clear();
            this.GoodsRateGrpName_tEdit.Clear();
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
        }

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void ScreenReconstruction()
		{
			if (this.DataIndex < 0)
			{
				// 新規モード
				this.Mode_Label.Text = INSERT_MODE;
				Division_Label.Text = DIVISION_USR_NAME;
				DivisionName_Label.Text = DIVISION_USR_NAME_TITLE;

                // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
                // データ区分
                this._divisionCode = DIVISION_USR;
                // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

				// ボタン設定
				this.Ok_Button.Visible = true;
                this.Renewal_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				//_dataIndexバッファ保持
				this._indexBuf = this._dataIndex;
                                       				
				// 画面入力許可制御処理
				//----- ueno upd ---------- start 2008.03.31
				ScreenInputPermissionControl(INSERT_MODE);
				//----- ueno upd ---------- end 2008.03.31

				BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();

				//クローン作成
				this._makerUClone = bLGoodsCdUMnt.Clone(); 

                // 画面情報格納
				DispToBLGoodsCdUMnt(ref this._makerUClone);

				// フォーカス設定
				this.tNedit_BLGoodsCode.Focus();
			}
			else
			{
				//----- ueno upd ---------- start 2008.02.29
				// ハッシュキー取得
				string hashKey = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
				BLGoodsCdUMnt bLGoodsCdUMnt = (BLGoodsCdUMnt)this._bLGoodsCdUMntTable[hashKey];

				//Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
				//BLGoodsCdUMnt bLGoodsCdUMnt = (BLGoodsCdUMnt)this._bLGoodsCdUMntTable[guid];
				//----- ueno upd ---------- end 2008.02.29

                // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
                // データ区分
                this._divisionCode = bLGoodsCdUMnt.Division;
                // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

				if (bLGoodsCdUMnt.LogicalDeleteCode == 0)
				{
                    ////----- ueno upd ---------- end 2008.03.31
                    ////if (Division_Label.Text == DIVISION_OFR_NAME)
                    //if (bLGoodsCdUMnt.Division == DIVISION_OFR)
                    ////----- ueno upd ---------- end 2008.03.31
                    //{
                    //    // 参照モード
                    //    this.Mode_Label.Text = REFERENCE_MODE;

                    //    // ボタン設定
                    //    this.Ok_Button.Visible = false;
                    //    this.Delete_Button.Visible = false;
                    //    this.Revive_Button.Visible = false;

                    //    // 画面展開処理
                    //    MakerUMntToScreen(bLGoodsCdUMnt);

                    //    //クローン作成
                    //    this._makerUClone = bLGoodsCdUMnt.Clone();

                    //    // 画面情報格納
                    //    DispToBLGoodsCdUMnt(ref this._makerUClone);

                    //    //_dataIndexバッファ保持
                    //    this._indexBuf = this._dataIndex;

                    //    // 画面入力許可制御処理
                    //    //----- ueno upd ---------- start 2008.03.31
                    //    ScreenInputPermissionControl(REFERENCE_MODE);
                    //    //----- ueno upd ---------- end 2008.03.31
                    //}
                    //else
                    //{
						// 更新モード
						this.Mode_Label.Text = UPDATE_MODE;

						// ボタン設定
						this.Ok_Button.Visible = true;
                        this.Renewal_Button.Visible = true;
						this.Delete_Button.Visible = false;
						this.Revive_Button.Visible = false;

						// 画面入力許可制御処理
						//----- ueno upd ---------- start 2008.03.31
						ScreenInputPermissionControl(UPDATE_MODE);
						//----- ueno upd ---------- end 2008.03.31

						// 画面展開処理
						MakerUMntToScreen(bLGoodsCdUMnt);

						//クローン作成
						this._makerUClone = bLGoodsCdUMnt.Clone();

                        // 画面情報格納
						DispToBLGoodsCdUMnt(ref this._makerUClone);

						//_dataIndexバッファ保持
						this._indexBuf = this._dataIndex;

						// 更新モードの場合は、ＢＬ商品コードマスタコード-枝版を入力不可とする
						//this.BLGoodsCodeRF_tNedit.Enabled = false;
						//this.BLGoodsCdDerivedNoRF_tNedit.Enabled = false;

						// フォーカス設定
						this.BLGoodsFullNameRF_tEdit.Focus();
						this.BLGoodsFullNameRF_tEdit.SelectAll();
					//}
				}
				else
				{
					// 削除モード
					this.Mode_Label.Text = DELETE_MODE;

					// ボタン設定
					this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
					this.Delete_Button.Visible = true;
					this.Revive_Button.Visible = true;
					
					//_dataIndexバッファ保持
					this._indexBuf = this._dataIndex;

					// 画面入力許可制御処理
					//----- ueno upd ---------- start 2008.03.31
					ScreenInputPermissionControl(DELETE_MODE);
					//----- ueno upd ---------- end 2008.03.31

					// 画面展開処理
					MakerUMntToScreen(bLGoodsCdUMnt);

					// フォーカス設定
					this.Delete_Button.Focus();
				}
			}
		}

		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <param name="mode">編集モード</param>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
		/// <br>UpdateNote : 2008.03.31 30167　上野　弘貴</br>
		/// <br>Note       : 各モード毎の処理追加</br>
        /// </remarks>
		private void ScreenInputPermissionControl(string mode)
		{
			//----- ueno add ---------- start 2008.03.31
			switch(mode)
			{
				case INSERT_MODE:		// 新規
					{
						this.tNedit_BLGoodsCode.Enabled = true;				// BL商品コード
						this.BLGoodsFullNameRF_tEdit.Enabled = true;			// BL商品名称
						this.tEdit_BLGoodsHalfName.Enabled = true;			// BL商品名称（カナ）
                        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
						this.BLGoodsGenreCodeRF_tNedit.Enabled = true;			// BL商品分類
                        this.LargeGoodsGanreCodeRF_tUltraBtn.Enabled = true;	// 商品区分グループガイド
                        this.LargeGoodsGanreCodeRF_tEdit.Enabled = false;		// 商品区分グループ
                        this.MediumGoodsGanreCodeRF_tEdit.Enabled = false;		// 商品区分
                        this.DetailGoodsGanreCodeRF_tEdit.Enabled = false;		// 商品区分詳細
                        this.LargeGoodsGanreNameRF_tEdit.Enabled = false;		// 商品区分グループ名称
                        this.MediumGoodsGanreNameRF_tEdit.Enabled = false;		// 商品区分名称
                        this.DetailGoodsGanreNameRF_tEdit.Enabled = false;		// 商品区分詳細名称
                           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
                        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
                        this.EquipGenre_tComboEditor.Enabled = true;            // 装備分類
                        this.tNedit_BLGloupCode.Enabled = true;                 // BLグループコード
                        this.BLGloupGuide_Button.Enabled = true;                // BLグループガイドボタン
                        this.tNedit_GoodsRateGrpCode.Enabled = true;            // 商品掛率グループコード
                        this.GoodsRateGrpGuide_Button.Enabled = true;           // 商品掛率グループガイドボタン
                        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
                        break;
					}
				case UPDATE_MODE:		// 更新
					{
						this.tNedit_BLGoodsCode.Enabled = false;				// BL商品コード
                        this.BLGoodsFullNameRF_tEdit.Enabled = true;			// BL商品名称
                        this.tEdit_BLGoodsHalfName.Enabled = true;			// BL商品名称（カナ）
                        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
						this.BLGoodsGenreCodeRF_tNedit.Enabled = false;			// BL商品分類
						this.LargeGoodsGanreCodeRF_tUltraBtn.Enabled = true;	// 商品区分グループガイド
						this.LargeGoodsGanreCodeRF_tEdit.Enabled = false;		// 商品区分グループ
						this.MediumGoodsGanreCodeRF_tEdit.Enabled = false;		// 商品区分
						this.DetailGoodsGanreCodeRF_tEdit.Enabled = false;		// 商品区分詳細
						this.LargeGoodsGanreNameRF_tEdit.Enabled = false;		// 商品区分グループ名称
						this.MediumGoodsGanreNameRF_tEdit.Enabled = false;		// 商品区分名称
						this.DetailGoodsGanreNameRF_tEdit.Enabled = false;		// 商品区分詳細名称
                           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
                        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
                        this.EquipGenre_tComboEditor.Enabled = true;           // 装備分類
                        this.tNedit_BLGloupCode.Enabled = true;                 // BLグループコード
                        this.BLGloupGuide_Button.Enabled = true;                // BLグループガイドボタン
                        this.tNedit_GoodsRateGrpCode.Enabled = true;            // 商品掛率グループコード
                        this.GoodsRateGrpGuide_Button.Enabled = true;           // 商品掛率グループガイドボタン
                        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
                        break;
					}
				case DELETE_MODE:		// 削除
				case REFERENCE_MODE:	// 参照
					{
						this.tNedit_BLGoodsCode.Enabled = false;				// BL商品コード
						this.BLGoodsFullNameRF_tEdit.Enabled = false;			// BL商品名称
						this.tEdit_BLGoodsHalfName.Enabled = false;			// BL商品名称（カナ）
                        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
						this.BLGoodsGenreCodeRF_tNedit.Enabled = false;			// BL商品分類
						this.LargeGoodsGanreCodeRF_tUltraBtn.Enabled = false;	// 商品区分グループガイド
						this.LargeGoodsGanreCodeRF_tEdit.Enabled = false;		// 商品区分グループ
						this.MediumGoodsGanreCodeRF_tEdit.Enabled = false;		// 商品区分
						this.DetailGoodsGanreCodeRF_tEdit.Enabled = false;		// 商品区分詳細
						this.LargeGoodsGanreNameRF_tEdit.Enabled = false;		// 商品区分グループ名称
						this.MediumGoodsGanreNameRF_tEdit.Enabled = false;		// 商品区分名称
						this.DetailGoodsGanreNameRF_tEdit.Enabled = false;		// 商品区分詳細名称
                           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
                        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
                        this.EquipGenre_tComboEditor.Enabled = false;           // 装備分類
                        this.tNedit_BLGloupCode.Enabled = false;                // BLグループコード
                        this.BLGloupGuide_Button.Enabled = false;               // BLグループガイドボタン
                        this.tNedit_GoodsRateGrpCode.Enabled = false;           // 商品掛率グループコード
                        this.GoodsRateGrpGuide_Button.Enabled = false;          // 商品掛率グループガイドボタン
                        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
                        break;
					}
			}
			
			//this.BLGoodsCodeRF_tNedit.Enabled = enabled;
			////this.BLGoodsCdDerivedNoRF_tNedit.Enabled = enabled;
			//this.BLGoodsFullNameRF_tEdit.Enabled = enabled;
			//this.tEdit_BLGoodsHalfName.Enabled = enabled;
			//this.BLGoodsGenreCodeRF_tNedit.Enabled = enabled;
			//this.LargeGoodsGanreCodeRF_tUltraBtn.Enabled = enabled;

			//this.LargeGoodsGanreCodeRF_tEdit.Enabled = false;
			//this.MediumGoodsGanreCodeRF_tEdit.Enabled = false;
			//this.DetailGoodsGanreCodeRF_tEdit.Enabled = false;
			//this.LargeGoodsGanreNameRF_tEdit.Enabled = false;
			//this.MediumGoodsGanreNameRF_tEdit.Enabled = false;
			//this.DetailGoodsGanreNameRF_tEdit.Enabled = false;

			//----- ueno add ---------- end 2008.03.31
		}

		/// <summary>
        /// ＢＬ商品コードマスタ クラス画面展開処理
		/// </summary>
		/// <param name="bLGoodsCdUMnt">ＢＬ商品コードマスタ オブジェクト</param>
		/// <remarks>
        /// <br>Note       : ＢＬ商品コードマスタ オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void MakerUMntToScreen(BLGoodsCdUMnt bLGoodsCdUMnt)
		{
			this.Guid_Label.Text = bLGoodsCdUMnt.FileHeaderGuid.ToString();
			this.Division_Label.Text = bLGoodsCdUMnt.Division.ToString();
			this.DivisionName_Label.Text = bLGoodsCdUMnt.DivisionName;

			//this.BLGoodsCodeRF_tNedit.Text = bLGoodsCdUMnt.BLGoodsCode.ToString();
			this.tNedit_BLGoodsCode.SetInt(bLGoodsCdUMnt.BLGoodsCode);

			//this.BLGoodsCdDerivedNoRF_tNedit.Text = bLGoodsCdUMnt.BLGoodsCdDerivedNo.ToString();
			this.BLGoodsFullNameRF_tEdit.Text = bLGoodsCdUMnt.BLGoodsFullName;
			this.tEdit_BLGoodsHalfName.Text = bLGoodsCdUMnt.BLGoodsHalfName;
			//this.BLGoodsGenreCodeRF_tNedit.Text = bLGoodsCdUMnt.BLGoodsGenreCode.ToString();

            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			this.BLGoodsGenreCodeRF_tNedit.SetInt(bLGoodsCdUMnt.BLGoodsGenreCode);
			this.LargeGoodsGanreCodeRF_tEdit.Text = bLGoodsCdUMnt.LargeGoodsGanreCode;
			this.LargeGoodsGanreNameRF_tEdit.Text = bLGoodsCdUMnt.LargeGoodsGanreName;
			this.MediumGoodsGanreCodeRF_tEdit.Text = bLGoodsCdUMnt.MediumGoodsGanreCode;
			this.MediumGoodsGanreNameRF_tEdit.Text = bLGoodsCdUMnt.MediumGoodsGanreName;
			this.DetailGoodsGanreCodeRF_tEdit.Text = bLGoodsCdUMnt.DetailGoodsGanreCode;
			this.DetailGoodsGanreNameRF_tEdit.Text = bLGoodsCdUMnt.DetailGoodsGanreName;
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            this.EquipGenre_tComboEditor.Value = bLGoodsCdUMnt.BLGoodsGenreCode;
            this.tNedit_BLGloupCode.SetInt(bLGoodsCdUMnt.BLGloupCode);
            this.BLGloupName_tEdit.DataText = GetBLGroupName(bLGoodsCdUMnt.BLGloupCode);
            this.tNedit_GoodsRateGrpCode.SetInt(bLGoodsCdUMnt.GoodsRateGrpCode);
            this.GoodsRateGrpName_tEdit.DataText = GetGoodsRateGrpName(bLGoodsCdUMnt.GoodsRateGrpCode);
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
        }

        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
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
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>
        /// 画面情報ＢＬ商品コードマスタ クラス格納処理
		/// </summary>
		/// <param name="bLGoodsCdUMnt">ＢＬ商品コードマスタ オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 画面情報からＢＬ商品コードマスタ オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private void DispToBLGoodsCdUMnt(ref BLGoodsCdUMnt bLGoodsCdUMnt)
		{
			if (bLGoodsCdUMnt == null)
			{
				// 新規の場合
				bLGoodsCdUMnt = new BLGoodsCdUMnt();
			}

			//データ区分
			bLGoodsCdUMnt.EnterpriseCode = this._enterpriseCode;

			if (this.Division_Label.Text == null || this.Division_Label.Text == "")
			{
				bLGoodsCdUMnt.Division = DIVISION_USR;
			}
			else
			{
				bLGoodsCdUMnt.Division = int.Parse(this.Division_Label.Text);
			}
			bLGoodsCdUMnt.DivisionName = this.DivisionName_Label.Text;


			//BL商品コード
			if (this.tNedit_BLGoodsCode.Text == "0"
                || this.tNedit_BLGoodsCode.Text == "")
            {
				bLGoodsCdUMnt.BLGoodsCode = 0;
				//makerU.GoodsMakerCd = "";
			}
            else
            {
				bLGoodsCdUMnt.BLGoodsCode = int.Parse(this.tNedit_BLGoodsCode.Text);
            }

			//BL商品コード枝番
			//if (this.BLGoodsCdDerivedNoRF_tNedit.Text == "0"
			//	|| this.BLGoodsCdDerivedNoRF_tNedit.Text == "")
			//{
			//	//bLGoodsCdUMnt.BLGoodsCdDerivedNo = 0;
			//	//makerU.BLGoodsCdDerivedNo = "";
			//}
			//else
			//{
			//	bLGoodsCdUMnt.BLGoodsCdDerivedNo = int.Parse(this.BLGoodsCdDerivedNoRF_tNedit.Text);
			//}


			//BL商品コード名称（全角）
			bLGoodsCdUMnt.BLGoodsFullName = this.BLGoodsFullNameRF_tEdit.Text;
			//BL商品コード名称（半角）
			bLGoodsCdUMnt.BLGoodsHalfName = this.tEdit_BLGoodsHalfName.Text;
			//BL商品分類
            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            if (this.EquipGenre_tComboEditor.Value == null)
            {
                bLGoodsCdUMnt.BLGoodsGenreCode = EQUIPGANRE_CODE_0;
            }
            else
            {
                bLGoodsCdUMnt.BLGoodsGenreCode = (int)this.EquipGenre_tComboEditor.Value;
            }
            // BLグループコード
            bLGoodsCdUMnt.BLGloupCode = this.tNedit_BLGloupCode.GetInt();
            // 商品掛率グループコード
            bLGoodsCdUMnt.GoodsRateGrpCode = this.tNedit_GoodsRateGrpCode.GetInt();
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<
            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			if (this.BLGoodsGenreCodeRF_tNedit.Text == "0"
				|| this.BLGoodsGenreCodeRF_tNedit.Text == "")
			{
				bLGoodsCdUMnt.BLGoodsGenreCode = 0;
			}
			else
			{
				bLGoodsCdUMnt.BLGoodsGenreCode = int.Parse(this.BLGoodsGenreCodeRF_tNedit.Text);
			}
			//商品区分グループコード
			bLGoodsCdUMnt.LargeGoodsGanreCode = this.LargeGoodsGanreCodeRF_tEdit.Text;
			//商品区分グループ名称
			bLGoodsCdUMnt.LargeGoodsGanreName = this.LargeGoodsGanreNameRF_tEdit.Text;
			//商品区分コード
			bLGoodsCdUMnt.MediumGoodsGanreCode = this.MediumGoodsGanreCodeRF_tEdit.Text;
			//商品区分名称
			bLGoodsCdUMnt.MediumGoodsGanreName = this.MediumGoodsGanreNameRF_tEdit.Text;
			//商品区分詳細コード
			bLGoodsCdUMnt.DetailGoodsGanreCode = this.DetailGoodsGanreCodeRF_tEdit.Text;
			//商品区分詳細名称
			bLGoodsCdUMnt.DetailGoodsGanreName = this.DetailGoodsGanreNameRF_tEdit.Text;
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
        }

        #region DEL 2008/06/10 Partsman用に変更
        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
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
 		private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
		{
			bool result = true;

            //if (this.LargeGoodsGanreCodeRF_tNedit.Text == "0" || this.LargeGoodsGanreCodeRF_tNedit.Text == "")
            if ((this.tNedit_BLGoodsCode.Text == "") || (this.tNedit_BLGoodsCode.Text == "0"))
			{
				// BL商品コード
				control = this.tNedit_BLGoodsCode;
				message = this.BLGoodsCode_Title_Label.Text + "を入力して下さい。";
				result = false;
			}
            //else if (this.BLGoodsCdDerivedNoRF_tNedit.Text.Trim() == "")
            //{
            //	// BL商品コード枝番
            //	control = this.BLGoodsCdDerivedNoRF_tNedit;
            //	message = this.BLGoodsCode_Title_Label.Text + "を入力して下さい。";
            //	result = false;
            //}
            else if (this.BLGoodsFullNameRF_tEdit.Text.Trim() == "")
            {
                // BL商品名称
                control = this.BLGoodsFullNameRF_tEdit;
                message = this.BLGoodsFullName_Title_Label.Text + "を入力して下さい。";
                result = false;
            }
            else if (this.tEdit_BLGoodsHalfName.Text.Trim() == "")
            {
                // BL商品名称(カナ)
                control = this.tEdit_BLGoodsHalfName;
                message = this.BLGoodsHalfName_Title_Label.Text + "を入力して下さい。";
                result = false;
            }
			else if ((this.BLGoodsGenreCodeRF_tNedit.Text == "") || (this.BLGoodsGenreCodeRF_tNedit.Text == "0"))
			{
				// BL商品分類
				control = this.BLGoodsGenreCodeRF_tNedit;
				message = this.BLGoodsGenreCode_Title_Label.Text + "を入力して下さい。";
				result = false;
			}
            
            return result;
		}
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/10 Partsman用に変更

        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <param name="loginID">ログインID</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/06/10</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
        {
            if ((this.tNedit_BLGoodsCode.Text == "") || (this.tNedit_BLGoodsCode.Text == "0"))
            {
                // BL商品コード
                control = this.tNedit_BLGoodsCode;
                message = this.BLGoodsCode_Title_Label.Text + "を入力して下さい。";
                return (false);
            }

            if (this._divisionCode == DIVISION_USR)
            {
                if (this.tNedit_BLGoodsCode.GetInt() < 9000)
                {
                    control = this.tNedit_BLGoodsCode;
                    message = "BLｺｰﾄﾞは9000以上の数値を入力してください。";
                    return (false);
                }
            }

            if (this.BLGoodsFullNameRF_tEdit.Text.Trim() == "")
            {
                // BL商品名称
                control = this.BLGoodsFullNameRF_tEdit;
                message = this.BLGoodsFullName_Title_Label.Text + "を入力して下さい。";
                return (false);
            }

            if (this.tEdit_BLGoodsHalfName.Text.Trim() == "")
            {
                // BL商品名称(カナ)
                control = this.tEdit_BLGoodsHalfName;
                message = this.BLGoodsHalfName_Title_Label.Text + "を入力して下さい。";
                return (false);
            }

            if (this.EquipGenre_tComboEditor.Value == null)
            {
                // 装備分類
                control = this.EquipGenre_tComboEditor;
                message = this.BLGoodsGenreCode_Title_Label.Text + "を選択して下さい。";
                return (false);
            }

            if (this.tNedit_BLGloupCode.DataText != "")
            {
                // BLグループコード
                if (GetBLGroupName(this.tNedit_BLGloupCode.GetInt()) == "")
                {
                    control = this.tNedit_BLGloupCode;
                    message = "マスタに登録されていません。";
                    return (false);
                }
            }

            if (this.tNedit_GoodsRateGrpCode.DataText != "")
            {
                // 商品掛率グループコード
                if (GetGoodsRateGrpName(this.tNedit_GoodsRateGrpCode.GetInt()) == "")
                {
                    control = this.tNedit_GoodsRateGrpCode;
                    message = "マスタに登録されていません。";
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// BLグループ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLグループ一覧を読み込みます。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/10</br>
        /// </remarks>
        private void ReadBLGroup()
        {
            this._blGroupUDic = new Dictionary<int, BLGroupU>();

            ArrayList retList;

            int status = this._bLGroupUAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (BLGroupU bLGroupU in retList)
                {
                    if (bLGroupU.LogicalDeleteCode == 0)
                    {
                        this._blGroupUDic.Add(bLGroupU.BLGroupCode, bLGroupU);
                    }
                }
            }

            return;
        }

        /// <summary>
        /// BLグループ名称取得処理
        /// </summary>
        /// <param name="blGroupCode">BLグループコード</param>
        /// <remarks>
        /// <br>Note       : BLグループ名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/10</br>
        /// </remarks>
        private string GetBLGroupName(int blGroupCode)
        {
            string blGroupName = "";

            if (this._blGroupUDic.ContainsKey(blGroupCode))
            {
                blGroupName = this._blGroupUDic[blGroupCode].BLGroupName.Trim();
            }

            return blGroupName;
        }

        /// <summary>
        /// 商品掛率グループ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品掛率グループ一覧を読み込みます。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/10</br>
        /// </remarks>
        private void ReadGoodsRateGrp()
        {
            this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();

            ArrayList retList;

            int status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (GoodsGroupU goodsGroupU in retList)
                {
                    if (goodsGroupU.LogicalDeleteCode == 0)
                    {
                        this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                    }
                }
            }

            return;
        }

        /// <summary>
        /// 商品掛率グループ名称取得処理
        /// </summary>
        /// <param name="goodsGroupUCode">商品掛率グループコード</param>
        /// <remarks>
        /// <returns>商品掛率グループ名称</returns>
        /// <br>Note       : 商品掛率グループ名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/10</br>
        /// </remarks>
        private string GetGoodsRateGrpName(int goodsGroupUCode)
        {
            string goodsGroupUName = "";

            if (this._goodsGroupUDic.ContainsKey(goodsGroupUCode))
            {
                goodsGroupUName = this._goodsGroupUDic[goodsGroupUCode].GoodsMGroupName.Trim();
            }

            return goodsGroupUName;
        }

        /// <summary>
        /// 装備分類名称取得処理
        /// </summary>
        /// <param name="goodsRateGrpCode">ステータス</param>
        /// <remarks>
        /// <br>Note       : 装備分類名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/10</br>
        /// </remarks>
        private string GetEquipGenreName(int EquipGenreCode)
        {
            string EquipGenreName = "";

            switch (EquipGenreCode)
            {
                case EQUIPGANRE_CODE_0:
                    EquipGenreName = EQUIPGANRE_NAME_0;
                    break;
                case EQUIPGANRE_CODE_1001:
                    EquipGenreName = EQUIPGANRE_NAME_1001;
                    break;
                case EQUIPGANRE_CODE_1005:
                    EquipGenreName = EQUIPGANRE_NAME_1005;
                    break;
                case EQUIPGANRE_CODE_1010:
                    EquipGenreName = EQUIPGANRE_NAME_1010;
                    break;
                default:
                    break;
            }

            return EquipGenreName;
        }

        /// <summary>
        /// 画面情報比較処理
        /// </summary>
        /// <returns>ステータス(True:変更なし False:変更あり)</returns>
        /// <remarks>
        /// <br>Note       : 画面情報の比較を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/11</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            bLGoodsCdUMnt = this._makerUClone.Clone();

            // 画面情報取得
            DispToBLGoodsCdUMnt(ref bLGoodsCdUMnt);
            
            // 最初に取得した画面情報と比較
            if (!(this._makerUClone.Equals(bLGoodsCdUMnt)))
            {
                //画面情報が変更されていた場合
                return (false);
            }

            return (true);
        }

        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

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

		//----- ueno add ---------- start 2008.02.29
		# region HashTable用Key作成
		/// <summary>
		/// HashTable用Key作成
		/// </summary>
		/// <param name="bLGoodsCdUMnt">ＢＬ商品クラス</param>
		/// <returns>Hash用Key</returns>
		/// <remarks>
		/// <br>Note       : ＢＬ商品クラスからハッシュテーブル用の
		///					 キーを作成します。</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.02.29</br>
		/// </remarks>
		private string CreateHashKey(BLGoodsCdUMnt bLGoodsCdUMnt)
		{
			return bLGoodsCdUMnt.BLGoodsCode.ToString("d8");
		}
		#endregion HashTable用Key作成
		//----- ueno add ---------- end 2008.02.29

        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールのサイズ設定処理を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/6/9</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tNedit_BLGoodsCode.Size = new System.Drawing.Size(60, 24);
            this.BLGoodsFullNameRF_tEdit.Size = new System.Drawing.Size(337, 24);
            this.tEdit_BLGoodsHalfName.Size = new System.Drawing.Size(337, 24);
            this.EquipGenre_tComboEditor.Size = new System.Drawing.Size(151, 24);
            this.tNedit_BLGloupCode.Size = new System.Drawing.Size(52, 24);
            this.BLGloupName_tEdit.Size = new System.Drawing.Size(337, 24);
            this.tNedit_GoodsRateGrpCode.Size = new System.Drawing.Size(52, 24);
            this.GoodsRateGrpName_tEdit.Size = new System.Drawing.Size(337, 24);
        }
        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

		# endregion

		#region ■Control Events
		/// <summary>
		/// Form.Load イベント(DCKHN09090UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
        private void DCKHN09090UA_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList25 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList25;
			this.Cancel_Button.ImageList = imageList25;
			this.Revive_Button.ImageList = imageList25;
			this.Delete_Button.ImageList = imageList25;
            this.Renewal_Button.ImageList = imageList16;

            //this.LargeGoodsGanreCodeRF_tUltraBtn.ImageList = imageList16;  // DEL 2008/06/10

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            //this.LargeGoodsGanreCodeRF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;  // DEL 2008/06/10

            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            // ガイドボタンのアイコン設定
            this.BLGloupGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GoodsRateGrpGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // コントロールサイズ設定
            SetControlSize();
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

			// 画面初期設定処理
			ScreenInitialSetting();
		}

		/// <summary>
        /// Form.Closing イベント(DCKHN09090UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
        private void DCKHN09090UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        /// Control.VisibleChanged イベント(DCKHN09090UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
        private void DCKHN09090UA_VisibleChanged(object sender, System.EventArgs e)
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

            // 画面クリア
			ScreenClear();

            Initial_Timer.Enabled = true;
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
            // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
            if ((this._divisionCode == DIVISION_OFR) && (CompareOriginalScreen() == true))
            {
                // 提供データ　かつ　画面情報未変更の場合
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
            else
            {
                if (SaveProc() == false)
                {
                    return;
                }
            }
            // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

            /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
			if (SaveProc() == false)
			{
				return;
			}
               --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            
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

				//----- ueno upd ---------- start 2008.03.31
                // 画面入力許可制御処理
				ScreenInputPermissionControl(INSERT_MODE);
				//----- ueno upd ---------- end 2008.03.31

				// クローンを再度取得する
				BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
				
				//クローン作成
				this._makerUClone = bLGoodsCdUMnt.Clone(); 

                // 画面情報格納
				DispToBLGoodsCdUMnt(ref this._makerUClone);

				this.tNedit_BLGoodsCode.Focus();
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
        /// ＢＬ商品コードマスタ 情報登録処理
		/// </summary>
		/// <returns>登録結果（true:OK／false:NG）</returns>
		/// <remarks>
        /// <br>Note       : ＢＬ商品コードマスタ 情報登録を行います。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		private bool SaveProc()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			Control control = null;
			string message = null;
			string loginID = "";

			BLGoodsCdUMnt bLGoodsCdUMnt = null;

			if (this.DataIndex >= 0)
			{
				//----- ueno upd ---------- start 2008.02.29
				// ハッシュキー取得
				string hashKey = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
				bLGoodsCdUMnt = ((BLGoodsCdUMnt)this._bLGoodsCdUMntTable[hashKey]).Clone();

				//Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
				//bLGoodsCdUMnt = ((BLGoodsCdUMnt)this._bLGoodsCdUMntTable[guid]).Clone();
				//----- ueno upd ---------- end 2008.02.29
			}

            // 入力チェック
            if (!ScreenDataCheck(ref control, ref message, loginID))
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

            // 画面情報格納
			this.DispToBLGoodsCdUMnt(ref bLGoodsCdUMnt);

			status = this._bLGoodsCdAcs.Write(ref bLGoodsCdUMnt);
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

					this.tNedit_BLGoodsCode.Focus();
					return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    // 排他処理
					ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._bLGoodsCdAcs);

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
						this._bLGoodsCdAcs,					// エラーが発生したオブジェクト
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
			MakerUMntToDataSet(bLGoodsCdUMnt, this.DataIndex);
			
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
                // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
                // 画面情報比較
                if (!CompareOriginalScreen())
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
                                if (SaveProc() == false)
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
                                // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                                //this.Cancel_Button.Focus();
                                if (_modeFlg)
                                {
                                    tNedit_BLGoodsCode.Focus();
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
                // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

                /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
				//保存確認
				BLGoodsCdUMnt compareBLGoodsCdUMnt = new BLGoodsCdUMnt();
				compareBLGoodsCdUMnt = this._makerUClone.Clone();  

				//現在の画面情報を取得する
				DispToBLGoodsCdUMnt(ref compareBLGoodsCdUMnt);

				//最初に取得した画面情報と比較
				if (!(this._makerUClone.Equals(compareBLGoodsCdUMnt)))	
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
							this.Cancel_Button.Focus();
							return;
						}
					}
				}
                   --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
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
				//----- ueno upd ---------- start 2008.02.29
				// ハッシュキー取得
				string hashKey = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
				BLGoodsCdUMnt bLGoodsCdUMnt = ((BLGoodsCdUMnt)this._bLGoodsCdUMntTable[hashKey]).Clone();

				//Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
				//BLGoodsCdUMnt bLGoodsCdUMnt = ((BLGoodsCdUMnt)this._bLGoodsCdUMntTable[guid]).Clone();
				//----- ueno upd ---------- end 2008.02.29

				status = this._bLGoodsCdAcs.Delete(bLGoodsCdUMnt);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this.DataIndex].Delete();

						//----- ueno upd ---------- start 2008.02.29
						this._bLGoodsCdUMntTable.Remove(hashKey);
						//this._bLGoodsCdUMntTable.Remove(bLGoodsCdUMnt.FileHeaderGuid);
						//----- ueno upd ---------- end 2008.02.29

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
                        // 排他処理
						ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._bLGoodsCdAcs);

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
							this._bLGoodsCdAcs,					  // エラーが発生したオブジェクト
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
        /// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			//----- ueno upd ---------- start 2008.02.29
			// ハッシュキー取得
			string hashKey = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
			BLGoodsCdUMnt bLGoodsCdUMnt = ((BLGoodsCdUMnt)_bLGoodsCdUMntTable[hashKey]).Clone();

			//Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GUID_TITLE];
			//BLGoodsCdUMnt bLGoodsCdUMnt = ((BLGoodsCdUMnt)_bLGoodsCdUMntTable[guid]).Clone();
			//----- ueno upd ---------- end 2008.02.29

			status = this._bLGoodsCdAcs.Revival(ref bLGoodsCdUMnt);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    // 排他
					ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._bLGoodsCdAcs);

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
						this._bLGoodsCdAcs,					  // エラーが発生したオブジェクト
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
			MakerUMntToDataSet(bLGoodsCdUMnt, this.DataIndex);

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

            // 各種マスタ読込
            ReadBLGroup();
            ReadGoodsRateGrp();

            // 画面再構築処理
			ScreenReconstruction();
		}

        // --- ADD 2008/06/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Control.Click イベント(BLGloupGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : BLグループガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/10</br>
        /// </remarks>
        private void BLGloupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGroupU bLGroupU = new BLGroupU();
                BLGroupUAcs bLGroupUAcs = new BLGroupUAcs();

                status = bLGroupUAcs.ExecuteGuid(this._enterpriseCode, out bLGroupU);
                if (status == 0)
                {
                    this.tNedit_BLGloupCode.SetInt(bLGroupU.BLGroupCode);
                    this.BLGloupName_tEdit.DataText = bLGroupU.BLGroupName.Trim();

                    // フォーカス設定
                    this.tNedit_GoodsRateGrpCode.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click イベント(GoodsRateGrpGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 商品掛率グループガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/10</br>
        /// </remarks>
        private void GoodsRateGrpGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                GoodsGroupU goodsGroupU = new GoodsGroupU();
                GoodsGroupUAcs goodsGroupUAcs = new GoodsGroupUAcs();

                status = goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);
                if (status == 0)
                {
                    this.tNedit_GoodsRateGrpCode.SetInt(goodsGroupU.GoodsMGroup);
                    this.GoodsRateGrpName_tEdit.DataText = goodsGroupU.GoodsMGroupName.Trim();

                    // フォーカス設定
                    //this.Ok_Button.Focus();
                    this.Renewal_Button.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// TEdit.ValueChanged イベント イベント(Name_tEdit)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 名称を変更した際に発生します。</br>
        /// <br>Programmer  : 30414 忍　幸史</br>
        /// <br>Date        : 2008/06/10</br>
        /// </remarks>
        private void BLGoodsFullNameRF_tEdit_ValueChanged(object sender, EventArgs e)
        {
            if (this.BLGoodsFullNameRF_tEdit.DataText.Equals(""))
            {
                this.tEdit_BLGoodsHalfName.Clear();
            }
        }

        /// <summary>
        /// ValueChanged イベント(tEdit_BLGoodsHalfName)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールの値が変わるタイミングで発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/09/11</br>
        /// </remarks>
        private void tEdit_BLGoodsHalfName_ValueChanged(object sender, EventArgs e)
        {
            TEdit tEdit = (TEdit)sender;

            // 半角に変換
            tEdit.Text = Strings.StrConv(tEdit.Text.Trim(), VbStrConv.Narrow, 0);
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

            // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
            
            switch (e.PrevCtrl.Name)
            {
                case "tNedit_BLGloupCode":
                    if ((this.tNedit_BLGloupCode.DataText == "") || (this.tNedit_BLGloupCode.GetInt() == 0))
                    {
                        this.BLGloupName_tEdit.DataText = "";
                        return;
                    }

                    // BLグループコード取得
                    int bLGroupCode = this.tNedit_BLGloupCode.GetInt();

                    // BLグループ名称取得
                    this.BLGloupName_tEdit.DataText = GetBLGroupName(bLGroupCode);

                    if (e.Key == Keys.Enter)
                    {
                        // フォーカス設定
                        if (this.BLGloupName_tEdit.DataText.Trim() != "")
                        {
                            e.NextCtrl = this.tNedit_GoodsRateGrpCode;
                        }
                    }
                    break;
                case "tNedit_GoodsRateGrpCode":
                    if ((this.tNedit_GoodsRateGrpCode.DataText == "") || (this.tNedit_GoodsRateGrpCode.GetInt() == 0))
                    {
                        this.GoodsRateGrpName_tEdit.DataText = "";
                        return;
                    }

                    // 商品掛率グループコード取得
                    int goodsRateGrpCode = this.tNedit_GoodsRateGrpCode.GetInt();

                    // 商品掛率グループ名称取得
                    this.GoodsRateGrpName_tEdit.DataText = GetGoodsRateGrpName(goodsRateGrpCode);

                    if (e.Key == Keys.Enter)
                    {
                        // フォーカス設定
                        if (this.GoodsRateGrpName_tEdit.DataText.Trim() != "")
                        {
                            //e.NextCtrl = this.Ok_Button;
                            e.NextCtrl = this.Renewal_Button;
                        }
                    }
                    break;
                case "tNedit_BLGoodsCode":
                    // BL商品コードにフォーカスがある場合
                    if (e.Key == Keys.Right)
                    {
                        // BL商品名称にフォーカスを移します
                        e.NextCtrl = BLGoodsFullNameRF_tEdit;
                    }

                    // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // 遷移先が閉じるボタン
                        _modeFlg = true;
                    }
                    else if (this._dataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            e.NextCtrl = tNedit_BLGoodsCode;
                        }
                    }
                    // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                    break;
                case "EquipGenre_tComboEditor":
                    // 装備分類にフォーカスがある場合
                    if (e.Key == Keys.Down)
                    {
                        // BLグループコードにフォーカスを移します
                        e.NextCtrl = tNedit_BLGloupCode;
                    }
                    break;
                case "Ok_Button":
                case "Cancel_Button":
                    // 保存ボタン、閉じるボタンにフォーカスがある場合
                    if (e.Key == Keys.Up)
                    {
                        // 商品掛率グループガイドボタンにフォーカスを移します
                        e.NextCtrl = GoodsRateGrpGuide_Button;
                    }
                    break;
                default:
                    break;
            }
        }

        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            ReadBLGroup();
            ReadGoodsRateGrp();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "DCKHN09090U",						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }
        // --- ADD 2008/06/10 ---------------------------------------------------------------------<<<<<

        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // BLコード
            int blGoodsCode = tNedit_BLGoodsCode.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsBLGoodsCode = int.Parse((string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][BLGoodsCode_TITLE]);
                if (blGoodsCode == dsBLGoodsCode)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのBLコードマスタ情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // BLコードのクリア
                        tNedit_BLGoodsCode.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードのBLコードマスタ情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
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
                                // BLコードのクリア
                                tNedit_BLGoodsCode.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
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
		}
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
        
# endregion

        /* --- DEL 2008/06/10 --------------------------------------------------------------------->>>>>
		# region ガイド処理
		/// <summary>
		/// 商品ガイド
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LargeGoodsGanreCodeRF_tUltraBtn_Click(object sender, EventArgs e)
		{
			if (sender is UltraButton)
			{
				DGoodsGanreAcs dGoodsGanreAcs = new DGoodsGanreAcs();
				DGoodsGanre dGoodsGanre = new DGoodsGanre();

				if (dGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out dGoodsGanre, 1) == 0)
				{
					//大分類
					this.LargeGoodsGanreCodeRF_tEdit.Text = dGoodsGanre.LargeGoodsGanreCode;
					this.LargeGoodsGanreNameRF_tEdit.Text = dGoodsGanre.LargeGoodsGanreName;

					//中分類
					this.MediumGoodsGanreCodeRF_tEdit.Text = dGoodsGanre.MediumGoodsGanreCode;
					this.MediumGoodsGanreNameRF_tEdit.Text = dGoodsGanre.MediumGoodsGanreName;


					//小分類
					this.DetailGoodsGanreCodeRF_tEdit.Text = dGoodsGanre.DetailGoodsGanreCode;
					this.DetailGoodsGanreNameRF_tEdit.Text = dGoodsGanre.DetailGoodsGanreName;

					this.LargeGoodsGanreCodeRF_tEdit.Focus();
				}
			}
			else
			{
				return;
			}			

		}

		# endregion
           --- DEL 2008/06/10 ---------------------------------------------------------------------<<<<<*/
    }

    # region ＢＬ商品コードマスタ情報印刷範囲クラス
    /// <summary>
    /// ＢＬ商品コードマスタ情報印刷範囲クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : ＢＬ商品コードマスタ情報印刷範囲のクラスです。</br>
    /// <br>Programmer : 96186 立花裕輔</br>
    /// <br>Date       : 2007.08.01</br>
    /// <br></br>
	/// </remarks>
	public class sendMakerUMntData
	{
		/// <summary>
        /// ＢＬ商品コードマスタ情報印刷範囲クラスデータセット処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 印刷用のデータセットです。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		public DataSet dataSet;

		/// <summary>
        /// ＢＬ商品コードマスタ情報ハッシュテーブル
		/// </summary>
		/// <remarks>
		/// <br>Note       : 印刷用のハッシュテーブルです。</br>
        /// <br>Programmer : 96186 立花裕輔</br>
        /// <br>Date       : 2007.08.01</br>
        /// </remarks>
		public Hashtable emphashtable;
	}
	# endregion

    # region ＢＬ商品コードマスタ情報印刷抽出条件クラス
    /// <summary>
    /// ＢＬ商品コードマスタ情報印刷抽出条件クラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : ＢＬ商品コードマスタ情報印刷抽出条件のクラスです。</br>
    /// <br>Programmer : 96186 立花裕輔</br>
    /// <br>Date       : 2007.08.01</br>
    /// <br></br>
	/// </remarks>
	public class ConditionData
	{
		/// <summary>
        /// 開始ＢＬ商品コードマスタコード
		/// </summary>
		public int StartMakerUMntCode;
		/// <summary>
        /// 終了ＢＬ商品コードマスタコード
		/// </summary>
        public int EndMakerUMntCode;
	}
	# endregion
}
