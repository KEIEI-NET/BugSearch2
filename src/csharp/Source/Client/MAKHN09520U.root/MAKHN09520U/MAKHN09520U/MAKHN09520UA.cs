# region ※using
using Infragistics.Win.Misc;
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
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
using Broadleaf.Library.Globarization;
# endregion

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 商品管理情報マスタ フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note		: 商品管理情報の設定を行います。
	///					  IMasterMaintenanceMultiTypeを実装しています。</br>
    /// <br>Programmer  : 980035 金沢　貞義</br>
    /// <br>Date        : 2007.08.27</br>
    /// <br>Update Note : 2008.02.28 980035 金沢 貞義</br>
    /// <br>              ・不具合対応</br>
	/// <br>Update Note : 2008.03.28 30167 上野　弘貴</br>
	///	<br>			  ・連続登録時、2件目以降拠点データが設定されない不具合修正</br>
	/// <br>Update Note : 2008.03.28 30167 上野　弘貴</br>
	///	<br>			  ・拠点コードゼロデータが表示・設定できない不具合修正</br>
	/// <br>Update Note : 2008.03.31 30167 上野　弘貴</br>
	///	<br>			  ・拠点コードアクティブ時の表示不具合修正</br>
    /// <br></br>
    /// <br>Update Note : 2008.04.24 20056 對馬 大輔</br>
    ///	<br>			・PM.NS 共通修正 得意先・仕入先分離対応</br>
    /// <br>Update Note : 2008.08.22 30350 櫻井 亮太</br>
    ///	<br>			・PM.NS用に修正</br>
    /// <br>Update Note : 2009.08.02 22008 長内 数馬</br>
    ///	<br>			・中分類コード設定のレコードは削除不可とする</br>
    /// <br>Update Note : 2009/11/25 30517 夏野 駿希</br>
    ///	<br>			・MANTIS:13894 拠点+品番で新規モードの時はBLコードと中分類を表示しない</br>
    /// <br>Update Note : 2010/12/03 曹文傑</br>
    ///	<br>			・拠点＋メーカー新規登録時の不具合修正</br>
    /// <br>Update Note : 2012/09/21 袁磊 redmine#32367</br>
    /// <br>管 理 番 号 : 10801804-00</br>
    ///	<br>			・拠点＋中分類＋メーカー＋BLコードと拠点＋中分類＋メーカーの追加</br>
    /// <br>Update Note : 2012/10/08 李亜博 redmine#32367</br>
    /// <br>管 理 番 号 : 10801804-00 2012/11/14配信分</br>
    ///	<br>			・障害一覧の対応 パタン「拠点＋中分類＋メーカー＋BLコード」</br>
    /// <br>Update Note : 2018/11/08 陳艶丹</br>
    /// <br>管 理 番 号 : 11370033-00</br>
    ///	<br>			・redmine#49781 商品管理情報マスタの削除仕様変更の対応</br>
    /// </remarks>
    public class MAKHN09520UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        #region ■Private Const
        // --- ADD 2018/11/08 陳艶丹 for redmine#49781 ---------->>>>>
        /// <summary>削除の確認メッセージ</summary>
        private const string DeleteMessage = "優良設定マスタで作成されたレコードです。" + "\r\n" +
                                             "完全削除となりますが、よろしいですか？" + "\r\n" + "\r\n" +
                                             "削除後、再設定する場合は優良設定マスタより" + "\r\n" +
                                             "設定してください。";
        // --- ADD 2018/11/08 陳艶丹 for redmine#49781 ----------<<<<<
        # endregion
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
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private TEdit tEdit_SectionCodeAllowZero;
        private TNedit tNedit_SupplierLot;
        private TEdit SupplierNm_tEdit;
        private TNedit tNedit_SupplierCd;
        private TEdit SectionName_tEdit;
        private UltraLabel SectionCode_Label;
        private UltraLabel GoodsMakerCd_Label;
        private UltraLabel ParentGoodsCode_Label;
        private TNedit tNedit_GoodsMakerCd;
        private UltraLabel BLGoodsCode_Label;
        private TNedit tNedit_BLGoodsCode;
        private TEdit tEdit_GoodsNo;
        private TEdit GoodsName_tEdit;
        private TEdit GoodsMakerName_tEdit;
        private UiSetControl uiSetControl1;
        private UltraLabel SupplierLot_Label;
        private UltraLabel SupplierCd_Label;
        private UltraLabel ultraLabel1;
        private TEdit BLGoodsName_tEdit;
        private UltraLabel SetKind_Label;
        private UltraLabel ultraLabel6;
        private TComboEditor SetKind_tComboEditor;
        private UltraLabel ultraLabel17;
        private UltraButton SupplierGd_ultraButton;
        private UltraButton BLGoodsGuide_Button;
        private UltraButton GoodsMakerGuide_Button;
        private UltraButton SectionGuide_Button;
        private TNedit tNedit_GoodsMGroup;
        private UltraLabel ultraLabel2;
        private UltraButton GoodsMGroupGuidButton;
        private TEdit tEdit_GoodsMGroupName;
		private System.ComponentModel.IContainer components;
        private Int32 _blGoodsCode = 0;//ADD 2012/09/21 袁磊 for redmine#32367 

		# endregion

		# region ■Constructor
		/// <summary>
        /// 商品管理情報マスタ フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 商品管理情報マスタ フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
		/// </remarks>
        public MAKHN09520UA()
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
            this._defaultAutoFillToColumn = true;
            this._canSpecificationSearch = false;

			//　企業コード取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 2008.02.28 追加 >>>>>>>>>>>>>>>>>>>>
            //　ログイン担当者所属拠点コード取得
            this._belongSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._belongSectionName = LoginInfoAcquisition.Employee.BelongSectionName;
            // 2008.02.28 追加 <<<<<<<<<<<<<<<<<<<<

			// 変数初期化
			this._dataIndex = -1;
            this._goodsMngAcs = new GoodsMngAcs();
			 
			this._totalCount = 0;
            this._goodsMngTable = new Hashtable();

            this._supplierAcs = new SupplierAcs(); // ADD 2008.04.24
            this._bLGoodsCdAcs = new BLGoodsCdAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();

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
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKHN09520UA));
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
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.tEdit_SectionCodeAllowZero = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_SupplierLot = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_SupplierCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsMakerCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ParentGoodsCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_GoodsMakerCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_GoodsNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GoodsName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GoodsMakerName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.SupplierLot_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BLGoodsCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_BLGoodsCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.BLGoodsName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SetKind_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.SetKind_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsMakerGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.BLGoodsGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.SupplierGd_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_GoodsMGroup = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_GoodsMGroupName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GoodsMGroupGuidButton = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetKind_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsMGroupName)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(434, 355);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            //this.Ok_Button.TabIndex = 14; //DEL 2012/09/21 袁磊 for redmine#32367
            this.Ok_Button.TabIndex = 16; //ADD 2012/09/21 袁磊 for redmine#32367
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
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 398);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(700, 23);
            this.ultraStatusBar1.TabIndex = 11;
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
            appearance56.ForeColor = System.Drawing.Color.White;
            appearance56.TextHAlignAsString = "Center";
            appearance56.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance56;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(575, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 12;
            this.Mode_Label.Text = "更新モード";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(309, 355);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            //this.Delete_Button.TabIndex = 13; //DEL 2012/09/21 袁磊 for redmine#32367
            this.Delete_Button.TabIndex = 15; //ADD 2012/09/21 袁磊 for redmine#32367
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(434, 355);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            //this.Revive_Button.TabIndex = 15; //DEL 2012/09/21 袁磊 for redmine#32367
            this.Revive_Button.TabIndex = 17; //ADD 2012/09/21 袁磊 for redmine#32367
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(559, 355);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            //this.Cancel_Button.TabIndex = 16; //DEL 2012/09/21 袁磊 for redmine#32367
            this.Cancel_Button.TabIndex = 18; //ADD 2012/09/21 袁磊 for redmine#32367
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
            this.tImeControl1.InControl = null;
            this.tImeControl1.OutControl = null;
            this.tImeControl1.OwnerForm = this;
            this.tImeControl1.PutLength = 30;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // tEdit_SectionCodeAllowZero
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero.ActiveAppearance = appearance1;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCodeAllowZero.Appearance = appearance2;
            this.tEdit_SectionCodeAllowZero.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_SectionCodeAllowZero.DataText = "";
            this.tEdit_SectionCodeAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_SectionCodeAllowZero.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SectionCodeAllowZero.Location = new System.Drawing.Point(125, 100);
            this.tEdit_SectionCodeAllowZero.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero.Name = "tEdit_SectionCodeAllowZero";
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(35, 24);
            this.tEdit_SectionCodeAllowZero.TabIndex = 1;
            this.tEdit_SectionCodeAllowZero.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.tEdit_SectionCodeAllowZero_BeforeEnterEditMode);
            // 
            // tNedit_SupplierLot
            // 
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance28.TextHAlignAsString = "Right";
            this.tNedit_SupplierLot.ActiveAppearance = appearance28;
            appearance29.ForeColorDisabled = System.Drawing.Color.Black;
            appearance29.TextHAlignAsString = "Right";
            this.tNedit_SupplierLot.Appearance = appearance29;
            this.tNedit_SupplierLot.AutoSelect = true;
            this.tNedit_SupplierLot.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierLot.DataText = "";
            this.tNedit_SupplierLot.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierLot.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.End, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierLot.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierLot.Location = new System.Drawing.Point(125, 320);
            this.tNedit_SupplierLot.MaxLength = 4;
            this.tNedit_SupplierLot.Name = "tNedit_SupplierLot";
            this.tNedit_SupplierLot.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SupplierLot.Size = new System.Drawing.Size(43, 24);
            //this.tNedit_SupplierLot.TabIndex = 12; //DEL 2012/09/21 袁磊 for redmine#32367
            this.tNedit_SupplierLot.TabIndex = 14; //ADD 2012/09/21 袁磊 for redmine#32367
            // 
            // SupplierNm_tEdit
            // 
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierNm_tEdit.ActiveAppearance = appearance35;
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance36.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance36.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance36.Cursor = System.Windows.Forms.Cursors.Default;
            appearance36.ForeColorDisabled = System.Drawing.Color.Black;
            appearance36.TextVAlignAsString = "Middle";
            this.SupplierNm_tEdit.Appearance = appearance36;
            this.SupplierNm_tEdit.AutoSelect = true;
            this.SupplierNm_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SupplierNm_tEdit.DataText = "";
            this.SupplierNm_tEdit.Enabled = false;
            this.SupplierNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SupplierNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SupplierNm_tEdit.Location = new System.Drawing.Point(190, 290);
            this.SupplierNm_tEdit.MaxLength = 20;
            this.SupplierNm_tEdit.Name = "SupplierNm_tEdit";
            this.SupplierNm_tEdit.Size = new System.Drawing.Size(330, 24);
            this.SupplierNm_tEdit.TabIndex = 28;
            this.SupplierNm_tEdit.Tag = "False";
            // 
            // tNedit_SupplierCd
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_SupplierCd.ActiveAppearance = appearance37;
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance38.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_SupplierCd.Appearance = appearance38;
            this.tNedit_SupplierCd.AutoSelect = true;
            this.tNedit_SupplierCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_SupplierCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd.DataText = "";
            this.tNedit_SupplierCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd.Location = new System.Drawing.Point(125, 290);
            this.tNedit_SupplierCd.MaxLength = 6;
            this.tNedit_SupplierCd.Name = "tNedit_SupplierCd";
            this.tNedit_SupplierCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SupplierCd.Size = new System.Drawing.Size(59, 24);
            //this.tNedit_SupplierCd.TabIndex = 10; //DEL 2012/09/21 袁磊 for redmine#32367
            this.tNedit_SupplierCd.TabIndex = 12; //ADD 2012/09/21 袁磊 for redmine#32367
            // 
            // SectionName_tEdit
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SectionName_tEdit.ActiveAppearance = appearance40;
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance41.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance41.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance41.Cursor = System.Windows.Forms.Cursors.Default;
            appearance41.ForeColorDisabled = System.Drawing.Color.Black;
            appearance41.TextVAlignAsString = "Middle";
            this.SectionName_tEdit.Appearance = appearance41;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SectionName_tEdit.Location = new System.Drawing.Point(166, 100);
            this.SectionName_tEdit.MaxLength = 10;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.Size = new System.Drawing.Size(82, 24);
            this.SectionName_tEdit.TabIndex = 3;
            this.SectionName_tEdit.Tag = "False";
            // 
            // SectionCode_Label
            // 
            this.SectionCode_Label.Location = new System.Drawing.Point(30, 103);
            this.SectionCode_Label.Name = "SectionCode_Label";
            this.SectionCode_Label.Size = new System.Drawing.Size(79, 23);
            this.SectionCode_Label.TabIndex = 0;
            this.SectionCode_Label.Text = "拠点";
            // 
            // GoodsMakerCd_Label
            // 
            this.GoodsMakerCd_Label.Location = new System.Drawing.Point(30, 191);
            this.GoodsMakerCd_Label.Name = "GoodsMakerCd_Label";
            this.GoodsMakerCd_Label.Size = new System.Drawing.Size(79, 23);
            this.GoodsMakerCd_Label.TabIndex = 4;
            this.GoodsMakerCd_Label.Text = "メーカー";
            // 
            // ParentGoodsCode_Label
            // 
            this.ParentGoodsCode_Label.Location = new System.Drawing.Point(30, 132);
            this.ParentGoodsCode_Label.Name = "ParentGoodsCode_Label";
            this.ParentGoodsCode_Label.Size = new System.Drawing.Size(79, 23);
            this.ParentGoodsCode_Label.TabIndex = 8;
            this.ParentGoodsCode_Label.Text = "品番";
            // 
            // tNedit_GoodsMakerCd
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_GoodsMakerCd.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_GoodsMakerCd.Appearance = appearance6;
            this.tNedit_GoodsMakerCd.AutoSelect = true;
            this.tNedit_GoodsMakerCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_GoodsMakerCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMakerCd.DataText = "";
            this.tNedit_GoodsMakerCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMakerCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMakerCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMakerCd.Location = new System.Drawing.Point(125, 190);
            this.tNedit_GoodsMakerCd.MaxLength = 4;
            this.tNedit_GoodsMakerCd.Name = "tNedit_GoodsMakerCd";
            this.tNedit_GoodsMakerCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_GoodsMakerCd.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsMakerCd.TabIndex = 6;
            this.tNedit_GoodsMakerCd.ValueChanged += new System.EventHandler(this.tNedit_GoodsMakerCd_ValueChanged);
            // 
            // tEdit_GoodsNo
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_GoodsNo.ActiveAppearance = appearance44;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_GoodsNo.Appearance = appearance45;
            this.tEdit_GoodsNo.AutoSelect = true;
            this.tEdit_GoodsNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_GoodsNo.DataText = "";
            this.tEdit_GoodsNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_GoodsNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_GoodsNo.Location = new System.Drawing.Point(125, 130);
            this.tEdit_GoodsNo.MaxLength = 24;
            this.tEdit_GoodsNo.Name = "tEdit_GoodsNo";
            this.tEdit_GoodsNo.Size = new System.Drawing.Size(353, 24);
            this.tEdit_GoodsNo.TabIndex = 4;
            // 
            // GoodsName_tEdit
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsName_tEdit.ActiveAppearance = appearance46;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance47.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance47.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance47.Cursor = System.Windows.Forms.Cursors.Default;
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            appearance47.TextVAlignAsString = "Middle";
            this.GoodsName_tEdit.Appearance = appearance47;
            this.GoodsName_tEdit.AutoSelect = true;
            this.GoodsName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GoodsName_tEdit.DataText = "";
            this.GoodsName_tEdit.Enabled = false;
            this.GoodsName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GoodsName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 15, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.GoodsName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GoodsName_tEdit.Location = new System.Drawing.Point(125, 160);
            this.GoodsName_tEdit.MaxLength = 15;
            this.GoodsName_tEdit.Name = "GoodsName_tEdit";
            this.GoodsName_tEdit.Size = new System.Drawing.Size(345, 24);
            this.GoodsName_tEdit.TabIndex = 5;
            this.GoodsName_tEdit.Tag = "False";
            // 
            // GoodsMakerName_tEdit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsMakerName_tEdit.ActiveAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance8.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance8.Cursor = System.Windows.Forms.Cursors.Default;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.GoodsMakerName_tEdit.Appearance = appearance8;
            this.GoodsMakerName_tEdit.AutoSelect = true;
            this.GoodsMakerName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GoodsMakerName_tEdit.DataText = "";
            this.GoodsMakerName_tEdit.Enabled = false;
            this.GoodsMakerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GoodsMakerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.GoodsMakerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GoodsMakerName_tEdit.Location = new System.Drawing.Point(174, 190);
            this.GoodsMakerName_tEdit.MaxLength = 30;
            this.GoodsMakerName_tEdit.Name = "GoodsMakerName_tEdit";
            this.GoodsMakerName_tEdit.Size = new System.Drawing.Size(314, 24);
            this.GoodsMakerName_tEdit.TabIndex = 24;
            this.GoodsMakerName_tEdit.Tag = "False";
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // SupplierLot_Label
            // 
            this.SupplierLot_Label.Location = new System.Drawing.Point(30, 321);
            this.SupplierLot_Label.Name = "SupplierLot_Label";
            this.SupplierLot_Label.Size = new System.Drawing.Size(91, 23);
            this.SupplierLot_Label.TabIndex = 294;
            this.SupplierLot_Label.Text = "流通ロット";
            // 
            // SupplierCd_Label
            // 
            this.SupplierCd_Label.Location = new System.Drawing.Point(30, 291);
            this.SupplierCd_Label.Name = "SupplierCd_Label";
            this.SupplierCd_Label.Size = new System.Drawing.Size(91, 23);
            this.SupplierCd_Label.TabIndex = 295;
            this.SupplierCd_Label.Text = "仕入先";
            // 
            // BLGoodsCode_Label
            // 
            this.BLGoodsCode_Label.Location = new System.Drawing.Point(30, 221);
            this.BLGoodsCode_Label.Name = "BLGoodsCode_Label";
            this.BLGoodsCode_Label.Size = new System.Drawing.Size(89, 23);
            this.BLGoodsCode_Label.TabIndex = 296;
            this.BLGoodsCode_Label.Text = "BLコード";
            // 
            // tNedit_BLGoodsCode
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_BLGoodsCode.ActiveAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_BLGoodsCode.Appearance = appearance10;
            this.tNedit_BLGoodsCode.AutoSelect = true;
            this.tNedit_BLGoodsCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_BLGoodsCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGoodsCode.DataText = "";
            this.tNedit_BLGoodsCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGoodsCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BLGoodsCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BLGoodsCode.Location = new System.Drawing.Point(125, 221);
            this.tNedit_BLGoodsCode.MaxLength = 5;
            this.tNedit_BLGoodsCode.Name = "tNedit_BLGoodsCode";
            this.tNedit_BLGoodsCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_BLGoodsCode.Size = new System.Drawing.Size(51, 24);
            this.tNedit_BLGoodsCode.TabIndex = 8;
            this.tNedit_BLGoodsCode.ValueChanged += new System.EventHandler(this.tNedit_BLGoodsCode_ValueChanged);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(30, 162);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(79, 23);
            this.ultraLabel1.TabIndex = 299;
            this.ultraLabel1.Text = "品名";
            // 
            // BLGoodsName_tEdit
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BLGoodsName_tEdit.ActiveAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance12.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance12.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance12.Cursor = System.Windows.Forms.Cursors.Default;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.BLGoodsName_tEdit.Appearance = appearance12;
            this.BLGoodsName_tEdit.AutoSelect = true;
            this.BLGoodsName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BLGoodsName_tEdit.DataText = "";
            this.BLGoodsName_tEdit.Enabled = false;
            this.BLGoodsName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BLGoodsName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.BLGoodsName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.BLGoodsName_tEdit.Location = new System.Drawing.Point(183, 221);
            this.BLGoodsName_tEdit.MaxLength = 20;
            this.BLGoodsName_tEdit.Name = "BLGoodsName_tEdit";
            this.BLGoodsName_tEdit.Size = new System.Drawing.Size(314, 24);
            this.BLGoodsName_tEdit.TabIndex = 26;
            this.BLGoodsName_tEdit.Tag = "False";
            // 
            // SetKind_Label
            // 
            this.SetKind_Label.Location = new System.Drawing.Point(12, 36);
            this.SetKind_Label.Name = "SetKind_Label";
            this.SetKind_Label.Size = new System.Drawing.Size(109, 23);
            this.SetKind_Label.TabIndex = 300;
            this.SetKind_Label.Text = "入力パターン";
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(464, 99);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(220, 23);
            this.ultraLabel6.TabIndex = 304;
            this.ultraLabel6.Text = "※ ゼロで共通設定になります";
            // 
            // SetKind_tComboEditor
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SetKind_tComboEditor.ActiveAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance19.TextVAlignAsString = "Middle";
            this.SetKind_tComboEditor.Appearance = appearance19;
            this.SetKind_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SetKind_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SetKind_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SetKind_tComboEditor.ItemAppearance = appearance20;
            this.SetKind_tComboEditor.Location = new System.Drawing.Point(125, 35);
            this.SetKind_tComboEditor.Name = "SetKind_tComboEditor";
            this.SetKind_tComboEditor.Size = new System.Drawing.Size(275, 24);
            this.SetKind_tComboEditor.TabIndex = 0;
            this.SetKind_tComboEditor.ValueChanged += new System.EventHandler(this.SetKind_tComboEditor_ValueChanged);
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(8, 78);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(683, 3);
            this.ultraLabel17.TabIndex = 307;
            // 
            // GoodsMakerGuide_Button
            // 
            this.GoodsMakerGuide_Button.Location = new System.Drawing.Point(494, 189);
            this.GoodsMakerGuide_Button.Name = "GoodsMakerGuide_Button";
            this.GoodsMakerGuide_Button.Size = new System.Drawing.Size(26, 26);
            this.GoodsMakerGuide_Button.TabIndex = 7;
            this.GoodsMakerGuide_Button.Click += new System.EventHandler(this.GoodsMakerGuide_Button_Click);
            // 
            // BLGoodsGuide_Button
            // 
            this.BLGoodsGuide_Button.Location = new System.Drawing.Point(503, 219);
            this.BLGoodsGuide_Button.Name = "BLGoodsGuide_Button";
            this.BLGoodsGuide_Button.Size = new System.Drawing.Size(26, 26);
            this.BLGoodsGuide_Button.TabIndex = 9;
            this.BLGoodsGuide_Button.Click += new System.EventHandler(this.BLGoodsGuide_Button_Click);
            // 
            // SupplierGd_ultraButton
            // 
            this.SupplierGd_ultraButton.Location = new System.Drawing.Point(526, 288);
            this.SupplierGd_ultraButton.Name = "SupplierGd_ultraButton";
            this.SupplierGd_ultraButton.Size = new System.Drawing.Size(26, 26);
            //this.SupplierGd_ultraButton.TabIndex = 11; //DEL 2012/09/21 袁磊 for redmine#32367
            this.SupplierGd_ultraButton.TabIndex = 13; //ADD 2012/09/21 袁磊 for redmine#32367
            this.SupplierGd_ultraButton.Click += new System.EventHandler(this.SupplierGd_ultraButton_Click);
            // 
            // SectionGuide_Button
            // 
            this.SectionGuide_Button.Location = new System.Drawing.Point(254, 99);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(25, 26);
            this.SectionGuide_Button.TabIndex = 2;
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(30, 250);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(79, 23);
            this.ultraLabel2.TabIndex = 308;
            this.ultraLabel2.Text = "中分類";
            // 
            // tNedit_GoodsMGroup
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_GoodsMGroup.ActiveAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_GoodsMGroup.Appearance = appearance4;
            this.tNedit_GoodsMGroup.AutoSelect = true;
            this.tNedit_GoodsMGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_GoodsMGroup.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMGroup.DataText = "";
            this.tNedit_GoodsMGroup.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMGroup.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMGroup.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMGroup.Location = new System.Drawing.Point(125, 251);
            this.tNedit_GoodsMGroup.MaxLength = 5;
            this.tNedit_GoodsMGroup.Name = "tNedit_GoodsMGroup";
            this.tNedit_GoodsMGroup.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_GoodsMGroup.Size = new System.Drawing.Size(43, 24);
            //this.tNedit_GoodsMGroup.TabIndex = 309; //DEL 2012/09/21 袁磊 for redmine#32367
            this.tNedit_GoodsMGroup.TabIndex = 10; //ADD 2012/09/21 袁磊 for redmine#32367
            // 
            // tEdit_GoodsMGroupName
            // 
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_GoodsMGroupName.ActiveAppearance = appearance48;
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance49.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance49.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance49.Cursor = System.Windows.Forms.Cursors.Default;
            appearance49.ForeColorDisabled = System.Drawing.Color.Black;
            appearance49.TextVAlignAsString = "Middle";
            this.tEdit_GoodsMGroupName.Appearance = appearance49;
            this.tEdit_GoodsMGroupName.AutoSelect = true;
            this.tEdit_GoodsMGroupName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tEdit_GoodsMGroupName.DataText = "";
            this.tEdit_GoodsMGroupName.Enabled = false;
            this.tEdit_GoodsMGroupName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsMGroupName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_GoodsMGroupName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tEdit_GoodsMGroupName.Location = new System.Drawing.Point(174, 251);
            this.tEdit_GoodsMGroupName.MaxLength = 20;
            this.tEdit_GoodsMGroupName.Name = "tEdit_GoodsMGroupName";
            this.tEdit_GoodsMGroupName.Size = new System.Drawing.Size(314, 24);
            this.tEdit_GoodsMGroupName.TabIndex = 310;
            this.tEdit_GoodsMGroupName.Tag = "False";
            // 
            // GoodsMGroupGuidButton
            // 
            this.GoodsMGroupGuidButton.Location = new System.Drawing.Point(495, 249);
            this.GoodsMGroupGuidButton.Name = "GoodsMGroupGuidButton";
            this.GoodsMGroupGuidButton.Size = new System.Drawing.Size(26, 26);
            //this.GoodsMGroupGuidButton.TabIndex = 311; //DEL 2012/09/21 袁磊 for redmine#32367
            // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
            this.GoodsMGroupGuidButton.TabIndex = 11;
            this.GoodsMGroupGuidButton.Click += new System.EventHandler(this.GoodsMGroupGuidButton_Click);
            // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<
            // 
            // MAKHN09520UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(700, 421);
            this.Controls.Add(this.GoodsMGroupGuidButton);
            this.Controls.Add(this.tEdit_GoodsMGroupName);
            this.Controls.Add(this.tNedit_GoodsMGroup);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.SectionGuide_Button);
            this.Controls.Add(this.SupplierGd_ultraButton);
            this.Controls.Add(this.BLGoodsGuide_Button);
            this.Controls.Add(this.GoodsMakerGuide_Button);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.SetKind_Label);
            this.Controls.Add(this.BLGoodsName_tEdit);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.tNedit_BLGoodsCode);
            this.Controls.Add(this.BLGoodsCode_Label);
            this.Controls.Add(this.SupplierCd_Label);
            this.Controls.Add(this.SupplierLot_Label);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero);
            this.Controls.Add(this.tNedit_SupplierLot);
            this.Controls.Add(this.SupplierNm_tEdit);
            this.Controls.Add(this.tNedit_SupplierCd);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.SectionCode_Label);
            this.Controls.Add(this.GoodsMakerCd_Label);
            this.Controls.Add(this.ParentGoodsCode_Label);
            this.Controls.Add(this.tNedit_GoodsMakerCd);
            this.Controls.Add(this.tEdit_GoodsNo);
            this.Controls.Add(this.GoodsName_tEdit);
            this.Controls.Add(this.GoodsMakerName_tEdit);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.SetKind_tComboEditor);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAKHN09520UA";
            this.Text = "商品管理情報マスタ";
            this.Load += new System.EventHandler(this.MAKHN09520UA_Load);
            this.VisibleChanged += new System.EventHandler(this.MAKHN09520UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MAKHN09520UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetKind_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsMGroupName)).EndInit();
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

        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region ▼Enums
        /// <summary>
        /// 仕入先コンポ指定
        /// </summary>
        private enum SupplierMode
        {
            Supplier1 = 1,
            Supplier2 = 2,
            Supplier3 = 3,
        }
        #endregion
        // ADD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2008.08.22 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //メーカーコード変数
        int prvGoodsMakerCd = 0;
        GoodsAcs goodsAcs;

        // ADD 2008.08.22 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		# region ▼Public Methods
		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッドリッド用データセット</param>
		/// <param name="tableName">テーブル名称</param>
        /// <returns>なし</returns>
        /// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
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
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList goodsMngList = null;

            // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
            // 抽出対象件数が0の場合は全件抽出を実行する
            //status = this._goodsMngAcs.SearchAll(this._enterpriseCode, out goodsMngList);

            // 拠点データクラス
            SecInfoSet secInfoSet;

            // 拠点データクラスインスタンス化
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            status = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this._belongSectionCode);
            if (status == 0)
            {
                // 2008.12.25 [9570]
                //this._mainOfficeFuncFlag = secInfoSet.MainOfficeFuncFlag;
                this._mainOfficeFuncFlag = 1;
                // 2008.12.25 [9570]
                this._belongSectionName  = secInfoSet.SectionGuideNm;
            }

            // 抽出対象件数が0の場合は全件抽出を実行する
            status = this._goodsMngAcs.SearchAll(this._enterpriseCode, out goodsMngList, this._mainOfficeFuncFlag, this._belongSectionCode);
            // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<

            this._totalCount = goodsMngList.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (GoodsMng lgoodsgranre in goodsMngList)
                        {
                            if (this._goodsMngTable.ContainsKey(lgoodsgranre.FileHeaderGuid) == false)
                            {
                                GoodsMngToDataSet(lgoodsgranre.Clone(), index);
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
                            this._goodsMngAcs,				  // エラーが発生したオブジェクト
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
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
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
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// <br>Update Note: 2018/11/08 陳艶丹</br>
        /// <br>　　　　　 : redmine#49781 商品管理情報マスタの削除仕様変更の対応</br>
        /// </remarks>
		public int Delete()
		{
			int status = 0;
            Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsMngAcs.FILEHEADERGUID_TITLE];
            GoodsMng goodsMng = ((GoodsMng)this._goodsMngTable[guid]).Clone();

            // -- 2009/08/02 ------------------------------>>
            //if (goodsMng.SectionCode != "" && goodsMng.BLGoodsCode != 0 && goodsMng.GoodsMakerCd != 0 && goodsMng.GoodsNo == "")
            if ((goodsMng.SectionCode != "" && goodsMng.BLGoodsCode != 0 && goodsMng.GoodsMakerCd != 0 && goodsMng.GoodsNo == "") ||
                 (goodsMng.SectionCode != "" && goodsMng.GoodsMGroup != 0 && goodsMng.GoodsMakerCd != 0 && goodsMng.GoodsNo == ""))
            // -- 2009/08/02 ------------------------------<<
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
                ArrayList wkList = new ArrayList();
                object objret = wkList;
                PrmSettingUWork primeSettingParaWork = new PrmSettingUWork();
                primeSettingParaWork.EnterpriseCode = goodsMng.EnterpriseCode;
                primeSettingParaWork.SectionCode = goodsMng.SectionCode;
                primeSettingParaWork.GoodsMGroup = goodsMng.GoodsMGroup;
                primeSettingParaWork.PartsMakerCd = goodsMng.GoodsMakerCd;
                primeSettingParaWork.TbsPartsCode = goodsMng.BLGoodsCode;
                primeSettingParaWork.PrimeDisplayCode = -1;

                this._goodsMngAcs.GetPrimeSettingMng(ref objret, primeSettingParaWork, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
                if (objret != null)
                {
                    if (((ArrayList)objret).Count == 0)
                    {
                        status = this._goodsMngAcs.LogicalDelete(ref goodsMng);
                    }
                    // --- ADD 2018/11/08 陳艶丹 for redmine#49781 ---------->>>>>
                    else
                    {
                        DialogResult Dialog = TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_QUESTION,
                           ASSEMBLY_ID,
                           DeleteMessage,
                           0,
                           MessageBoxButtons.YesNo,
                           MessageBoxDefaultButton.Button2);
                        if (Dialog == DialogResult.Yes)
                        {
                            status = this._goodsMngAcs.Delete(goodsMng);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this.DataIndex].Delete();
                                this._goodsMngTable.Remove(goodsMng.FileHeaderGuid);
                                return status;
                            }
                        }
                        else
                        {

                            this.Hide();
                            return status;
                        }
                    }
                    // --- ADD 2018/11/08 陳艶丹 for redmine#49781 ----------<<<<<
                }
                // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<
            }
            else
            {
                status = this._goodsMngAcs.LogicalDelete(ref goodsMng);
            }
            //MessageBox.Show(status.ToString(), "");
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
                    ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._goodsMngAcs);
					return status;
				}
            　　// --- DEL 2018/11/08 陳艶丹 for redmine#49781 ---------->>>>>
                //case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                //{
                //    //削除不可
                //    TMsgDisp.Show(this,
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //        ASSEMBLY_ID,
                //        "このレコードは優良設定マスタで削除して下さい",
                //        status,
                //        MessageBoxButtons.OK);
                //    this.Hide();

                //    return status;
                //}
                // --- DEL 2018/11/08 陳艶丹 for redmine#49781 ----------<<<<<
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
                        this._goodsMngAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン

					return status;
				}
			}

			// データセット展開処理
            GoodsMngToDataSet(goodsMng.Clone(), this._dataIndex);
			return status;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
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
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

            #region ■グリッド列設定
            /******************
             *①削除日            
             *②論理削除区分      
             *③拠点コード        
             *④拠点ガイド名称    
             *⑤商品メーカーコード
             *⑥メーカー名称      
             *⑦商品コード        
             *⑧商品名称          
             *⑨BLコード
             *⑩BL名称
             *⑩仕入先コード    
             *⑪仕入先名称      
             *⑭発注ロット           
             ******************/

            appearanceTable.Add(GoodsMngAcs.DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(GoodsMngAcs.LOGICALDELETE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GoodsMngAcs.SECTIONCODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));         // 拠点コード
            appearanceTable.Add(GoodsMngAcs.SECTIONGUIDENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));      // 拠点ガイド名称
            appearanceTable.Add(GoodsMngAcs.GOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));       // 商品メーカーコード
            appearanceTable.Add(GoodsMngAcs.MAKERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));           // メーカー名称
            appearanceTable.Add(GoodsMngAcs.GOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));             // 商品コード
            appearanceTable.Add(GoodsMngAcs.GOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));           // 商品名称
            appearanceTable.Add(GoodsMngAcs.GOODSMGROUP_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));             // 中分類コード
            appearanceTable.Add(GoodsMngAcs.GOODSMGROUPNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));           // 中分類名称
            // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
            // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
            appearanceTable.Add(GoodsMngAcs.BLGOODSCODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));        // BLコード
            appearanceTable.Add(GoodsMngAcs.BLGOODSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));        // BLコード名称
            appearanceTable.Add(GoodsMngAcs.SUPPLIERCD1_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));        // 仕入先コード
            appearanceTable.Add(GoodsMngAcs.SUPPLIERSNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));       // 仕入先名称
            appearanceTable.Add(GoodsMngAcs.SUPPLIERLOT1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));       // 発注ロット
            appearanceTable.Add(GoodsMngAcs.FILEHEADERGUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));     // データテーブルカラム名称           
            #endregion

            //appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			return appearanceTable;
		}
		# endregion

		# endregion

		#region ■Private Menbers
        private GoodsMngAcs _goodsMngAcs;
		private int _totalCount;
		private string _enterpriseCode;
        private Hashtable _goodsMngTable;
        // 2008.02.28 追加 >>>>>>>>>>>>>>>>>>>>
        private string _belongSectionCode;
        private string _belongSectionName = "";
        private SupplierAcs _supplierAcs; // ADD 2008.04.24
        private BLGoodsCdAcs _bLGoodsCdAcs;
        private GoodsGroupUAcs _goodsGroupUAcs;
        private Dictionary<int, GoodsGroupU> _goodsGroupDic;

        //　本社機能フラグ
        private int _mainOfficeFuncFlag = 0;
        // 2008.02.28 追加 <<<<<<<<<<<<<<<<<<<<

		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
        private GoodsMng _goodsMngClone;

        // 2008.08.22 追加 >>>>>>>>>>>>>>>>>>>>
        // ワークデータ関連
        //private string _chgSrcGoodsNoWork = "";		// 仕入先品番
        private string _chgDestGoodsNoWork = "";	// 品番
        // 2008.08.22 追加 <<<<<<<<<<<<<<<<<<<<

		//_dataIndexバッファ（メインフレーム最小化対応）
		private int _indexBuf;
		/// <summary>拠点オプションフラグ</summary>
		private bool _optSection = false;
		# endregion

		# region ■Consts
        private const string MAKERU_TABLE = "LGOODSGANRE";

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";

		// コントロール名称
		private const string TAB1_NAME = "GeneralTab";
		private const string TAB2_NAME = "SecurityTab";

        //設定種別
        private const string SETKIND_SECTIONGOODS = "拠点＋品番";
        private const string SETKIND_SECTIONMAKER = "拠点＋メーカー";
        private const string SETKIND_SECTIONBLMAKER = "拠点＋メーカー＋BLコード";
        private const int SETKIND_SECTIONGOODS_VALUE = 0;
        //private const int SETKIND_SECTIONMAKER_VALUE = 1; // DEL 2012/09/21 袁磊 for redmine#32367
        //private const int SETKIND_SECTIONBLMAKER_VALUE = 2; // DEL 2012/09/21 袁磊 for redmine#32367
        // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
        private const string SETKIND_SECTIONMGROUPMAKERBL = "拠点＋中分類＋メーカー＋BLコード";
        private const string SETKIND_SECTIONMGROUPMAKER = "拠点＋中分類＋メーカー";
        private const int SETKIND_SECTIONMGROUPMAKERBL_VALUE = 1;
        private const int SETKIND_SECTIONMGROUPMAKER_VALUE = 2;
        private const int SETKIND_SECTIONMAKER_VALUE = 3;
        // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<

		// Message関連定義
		private const string ASSEMBLY_ID	= "MAKHN09520U";
		private const string PG_NM			= "商品管理情報マスタ";
		private const string ERR_READ_MSG	= "読み込みに失敗しました。";
		private const string ERR_DPR_MSG	= "このコードは既に使用されています。";
		private const string ERR_RDEL_MSG	= "削除に失敗しました。";
		private const string ERR_UPDT_MSG	= "登録に失敗しました。";
		private const string ERR_RVV_MSG	= "復活に失敗しました。";
		private const string ERR_800_MSG	= "既に他端末より更新されています";
		private const string ERR_801_MSG	= "既に他端末より削除されています";
		private const string SDC_RDEL_MSG	= "マスタから削除されています";

        // 2008.02.28 追加 >>>>>>>>>>>>>>>>>>>>
        private const string ON_MSG         = "する";
        private const string OFF_MSG        = "しない";
        // 2008.02.28 追加 <<<<<<<<<<<<<<<<<<<<
        #endregion

        #region enum
        /// <summary>
        /// 入力エラーチェックステータス
        /// </summary>
        private enum InputChkStatus
        {
            // 未入力
            NotInput = -1,
            // 存在しない
            NotExist = -2,
            // 入力ミス
            InputErr = -3,
            // 正常
            Normal = 0,
            // キャンセル
            Cancel = 1
        }

        /// <summary>
        /// 画面データ設定ステータス
        /// </summary>
        private enum DispSetStatus
        {
            // クリア
            Clear = 0,
            // 更新
            Update = 1,
            // 元に戻す
            Back = 2
        }
        #endregion enum



		# region ※Main
		/// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new MAKHN09520UA());
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
        /// 商品管理情報マスタ オブジェクトデータセット展開処理
		/// </summary>
        /// <param name="goodsMng">商品管理情報マスタ オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
        /// <br>Note       : 商品管理情報マスタ クラスをデータセットに格納します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
        private void GoodsMngToDataSet(GoodsMng goodsMng, int index)
		{

			if ((index < 0) || (this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[MAKERU_TABLE].NewRow();
				this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Add(dataRow);

				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count - 1;
			}

            if (goodsMng.LogicalDeleteCode == 0)
			{
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.DELETE_DATE] = "";
            }
			else
			{
                //this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.DELETE_DATE] =TDateTime.DateTimeToString("ggYY/MM/DD", goodsMng.UpdateDateTime);
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.DELETE_DATE] = goodsMng.UpdateDateTime;
            }

            #region ●拠点コード
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.SECTIONCODE_TITLE] = goodsMng.SectionCode;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.SECTIONGUIDENM_TITLE] = goodsMng.SectionGuideNm;
            #endregion

            #region ●商品メーカー
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.GOODSMAKERCD_TITLE] = goodsMng.GoodsMakerCd;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.MAKERNAME_TITLE] = goodsMng.GoodsMakerName;
            #endregion

            #region ●商品コード
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.GOODSNO_TITLE] = goodsMng.GoodsNo;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.GOODSNAME_TITLE] = goodsMng.GoodsName;
            #endregion

            #region ●BLコード
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.BLGOODSCODE_TITLE] = goodsMng.BLGoodsCode;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.BLGOODSNAME_TITLE] = goodsMng.BLGoodsName;
            #endregion

            #region ●商品中分類
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.GOODSMGROUP_TITLE] = goodsMng.GoodsMGroup;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.GOODSMGROUPNM_TITLE] = goodsMng.GoodsMGroupNm;
            #endregion
            

            #region ●発注先１
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.SUPPLIERCD1_TITLE] = goodsMng.SupplierCd1;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.SUPPLIERSNM_TITLE] = goodsMng.SupplierSnm;
            #endregion

            #region ●流通ロット
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.SUPPLIERLOT1_TITLE] = goodsMng.SupplierLot1;
            #endregion
           
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsMngAcs.FILEHEADERGUID_TITLE] = goodsMng.FileHeaderGuid;

            if (this._goodsMngTable.ContainsKey(goodsMng.FileHeaderGuid))
            {
                this._goodsMngTable.Remove(goodsMng.FileHeaderGuid);
            }
            this._goodsMngTable.Add(goodsMng.FileHeaderGuid, goodsMng);

        }

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
            DataTable goodsMngTable = new DataTable(MAKERU_TABLE);

            // Addを行う順番が、列の表示順位となります。
            goodsMngTable.Columns.Add(GoodsMngAcs.DELETE_DATE, typeof(string));

            // 拠点コード
            goodsMngTable.Columns.Add(GoodsMngAcs.SECTIONCODE_TITLE, typeof(string));
            goodsMngTable.Columns.Add(GoodsMngAcs.SECTIONGUIDENM_TITLE, typeof(string));

            // 商品メーカー
            goodsMngTable.Columns.Add(GoodsMngAcs.GOODSMAKERCD_TITLE, typeof(int));
            goodsMngTable.Columns.Add(GoodsMngAcs.MAKERNAME_TITLE, typeof(string));

            // 商品コード
            goodsMngTable.Columns.Add(GoodsMngAcs.GOODSNO_TITLE, typeof(string));
            goodsMngTable.Columns.Add(GoodsMngAcs.GOODSNAME_TITLE, typeof(string));

            // BLコード
            goodsMngTable.Columns.Add(GoodsMngAcs.BLGOODSCODE_TITLE, typeof(int));
            goodsMngTable.Columns.Add(GoodsMngAcs.BLGOODSNAME_TITLE, typeof(string));

            // 商品中分類コード
            goodsMngTable.Columns.Add(GoodsMngAcs.GOODSMGROUP_TITLE, typeof(int));
            goodsMngTable.Columns.Add(GoodsMngAcs.GOODSMGROUPNM_TITLE, typeof(string));
 
            // 発注先
            goodsMngTable.Columns.Add(GoodsMngAcs.SUPPLIERCD1_TITLE, typeof(int));
            goodsMngTable.Columns.Add(GoodsMngAcs.SUPPLIERSNM_TITLE, typeof(string));

            // 発注ロット
            goodsMngTable.Columns.Add(GoodsMngAcs.SUPPLIERLOT1_TITLE, typeof(int));

            // GUID
            goodsMngTable.Columns.Add(GoodsMngAcs.FILEHEADERGUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(goodsMngTable);
        }

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
		private void ScreenInitialSetting()
		{
            // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
            //this.Ok_Button.Location = new System.Drawing.Point(450, 330);
            //this.Cancel_Button.Location = new System.Drawing.Point(575, 330);
            //this.Delete_Button.Location = new System.Drawing.Point(325, 330);
            //this.Revive_Button.Location = new System.Drawing.Point(450, 330);
            Point point = new Point();
            point.X = this.Cancel_Button.Location.X;
            point.Y = this.Cancel_Button.Location.Y;

            point.X = point.X - this.Ok_Button.Size.Width;
            this.Ok_Button.Location     = point;
            this.Revive_Button.Location = point;

            point.X = point.X - this.Delete_Button.Size.Width;
            this.Delete_Button.Location = point;
            // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
            // 設定種別
            this.SetKind_tComboEditor.Items.Clear();
            this.SetKind_tComboEditor.Items.Add(SETKIND_SECTIONGOODS_VALUE, SETKIND_SECTIONGOODS);
            // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
            this.SetKind_tComboEditor.Items.Add(SETKIND_SECTIONMGROUPMAKERBL_VALUE, SETKIND_SECTIONMGROUPMAKERBL);
            this.SetKind_tComboEditor.Items.Add(SETKIND_SECTIONMGROUPMAKER_VALUE, SETKIND_SECTIONMGROUPMAKER);
            // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<
            this.SetKind_tComboEditor.Items.Add(SETKIND_SECTIONMAKER_VALUE, SETKIND_SECTIONMAKER);
            this.SetKind_tComboEditor.MaxDropDownItems = this.SetKind_tComboEditor.Items.Count;
        }

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// <br>Update Note: 2012/10/08 李亜博 </br>
        ///	<br>		   ・redmine#32367 障害一覧の対応</br>
        /// </remarks>
		private void ScreenClear()
		{
            this.SetKind_tComboEditor.SelectedIndex = 0;
            this.tEdit_SectionCodeAllowZero.Clear();
            this.SectionName_tEdit.Clear();
            this.tNedit_GoodsMakerCd.Clear();
            this.GoodsMakerName_tEdit.Clear();
            this.tEdit_GoodsNo.Clear();
            this.GoodsName_tEdit.Clear();
            this.tNedit_BLGoodsCode.Clear();
            this.BLGoodsName_tEdit.Clear();
            this.tNedit_SupplierCd.Clear();
            this.SupplierNm_tEdit.Clear();
            this.tNedit_SupplierLot.Clear();
            this.tNedit_GoodsMGroup.Clear();
            this.tEdit_GoodsMGroupName.Clear();
            _blGoodsCode = 0;//ADD 2012/10/08 李亜博 for redmine#32367
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
		private void ScreenReconstruction()
		{

			if (this.DataIndex < 0)
			{
				// 新規モード
				this.Mode_Label.Text = INSERT_MODE;

                // ボタン設定
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                
                //_dataIndexバッファ保持
				this._indexBuf = this._dataIndex;
                                       				
				// 画面入力許可制御処理
				ScreenInputPermissionControl(true);

                // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
                // 初期値設定
                if (this._mainOfficeFuncFlag != 1)
                {
                    this.tEdit_SectionCodeAllowZero.DataText = this._belongSectionCode;
                    this.SectionName_tEdit.DataText = this._belongSectionName;
                }
                // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<

                GoodsMng goodsMng = new GoodsMng();
				//クローン作成
                this._goodsMngClone = goodsMng.Clone(); 
                DispToGoodsMng(ref this._goodsMngClone);

				// フォーカス設定
                // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
                //this.tEdit_SectionCodeAllowZero.Focus();
                //this.tEdit_SectionCodeAllowZero.SelectAll();

                // 初期フォーカスをセット
                this.SetKind_tComboEditor.Focus();

                //if (this._mainOfficeFuncFlag == 1)
                //{

                //    this.tEdit_SectionCodeAllowZero.Focus();
                //    this.tEdit_SectionCodeAllowZero.SelectAll();
                //}
                //else
                //{
                //    this.tNedit_GoodsMakerCd.Focus();
                //    this.tNedit_GoodsMakerCd.SelectAll();
                //}
                // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
            }
			else
			{
                Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsMngAcs.FILEHEADERGUID_TITLE];
                GoodsMng goodsMng = (GoodsMng)this._goodsMngTable[guid];

                if (goodsMng.LogicalDeleteCode == 0)
				{
					// 更新モード
					this.Mode_Label.Text = UPDATE_MODE;

					// ボタン設定
					this.Ok_Button.Visible = true;
					this.Delete_Button.Visible = false;
					this.Revive_Button.Visible = false;

					// 画面入力許可制御処理
                    ScreenInputPermissionControl(false);

					// 画面展開処理
                    MakerUMntToScreen(goodsMng);

					//クローン作成
                    this._goodsMngClone = goodsMng.Clone();
                    DispToGoodsMng(ref this._goodsMngClone);
                    //_dataIndexバッファ保持
					this._indexBuf = this._dataIndex;
                    

				}
				else
				{
					// 削除モード
					this.Mode_Label.Text = DELETE_MODE;

					// ボタン設定
					this.Ok_Button.Visible = false;
					this.Revive_Button.Visible = true;
                    this.Delete_Button.Visible = true;
					//_dataIndexバッファ保持
					this._indexBuf = this._dataIndex;

					// 画面入力許可制御処理
					ScreenInputPermissionControl(false);

					// 画面展開処理
                    MakerUMntToScreen(goodsMng);

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
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
        private void ScreenInputPermissionControl(bool enabled)
        {
            // モードによって入力許可を制御
            // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
            //this.tEdit_SectionCodeAllowZero.Enabled        = enabled;
            //this.tNedit_GoodsMakerCd.Enabled      = enabled;
            //this.tEdit_GoodsNo.Enabled            = enabled;
            //this.SectionGuide_Button.Enabled      = enabled;  // 拠点ガイドボタン
            //this.GoodsMakerGuide_Button.Enabled   = enabled;  // 商品メーカーガイドボタン
            this.tNedit_GoodsMGroup.Enabled = false;
            this.tEdit_GoodsMGroupName.Enabled = false;
            this.GoodsMGroupGuidButton.Enabled = false;
            if (this._mainOfficeFuncFlag == 1)
            {
                // 本社処理
                this.tEdit_SectionCodeAllowZero.Enabled = enabled;
                this.tNedit_GoodsMakerCd.Enabled = false;
                this.tEdit_GoodsNo.Enabled = enabled;
                this.SectionGuide_Button.Enabled = enabled;  // 拠点ガイドボタン
                this.GoodsMakerGuide_Button.Enabled = false;  // 商品メーカーガイドボタン
                this.tNedit_BLGoodsCode.Enabled = false;
                this.BLGoodsGuide_Button.Enabled = false;
                this.SetKind_tComboEditor.Visible = enabled;
                this.SetKind_Label.Visible = enabled;
                this.ultraLabel6.Visible = enabled;
            }
            else
            {
                // 拠点処理
                this.tEdit_SectionCodeAllowZero.Enabled = false;
                this.tNedit_GoodsMakerCd.Enabled = false;
                this.tEdit_GoodsNo.Enabled = enabled;
                this.SectionGuide_Button.Enabled = false;    // 拠点ガイドボタン
                this.GoodsMakerGuide_Button.Enabled = false;  // 商品メーカーガイドボタン
                this.tNedit_BLGoodsCode.Enabled = enabled;
                this.BLGoodsGuide_Button.Enabled = enabled;
                this.SetKind_tComboEditor.Visible = enabled;
                this.SetKind_Label.Visible = enabled;
                this.ultraLabel6.Visible = enabled;
            }
            if (this.Mode_Label.Text == DELETE_MODE)
            { 
                this.tNedit_SupplierCd.Enabled = enabled;
                this.tNedit_SupplierLot.Enabled = enabled;
                this.SupplierGd_ultraButton.Enabled = enabled;  
            }
            else
            {
                this.tNedit_SupplierCd.Enabled = true;
                this.tNedit_SupplierLot.Enabled = true;
                this.SupplierGd_ultraButton.Enabled = true;
            }
                // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
        }
		/// <summary>
        /// 商品管理情報マスタ クラス画面展開処理
		/// </summary>
        /// <param name="goodsMng">商品管理情報設定マスタ オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 商品管理情報マスタ オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
        private void MakerUMntToScreen(GoodsMng goodsMng)
        {
           // MakerUMnt makerUMnt;
            MakerAcs makerAcs = new MakerAcs();
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            List<GoodsUnitData> list = new List<GoodsUnitData>();
            GoodsUnitData goodsUnitData = new GoodsUnitData();


            #region ●拠点コード
            if (goodsMng.SectionCode != string.Empty)
            {
                this.tEdit_SectionCodeAllowZero.DataText = goodsMng.SectionCode;

            }
            if (goodsMng.SectionGuideNm != string.Empty)
            {
                this.SectionName_tEdit.DataText = goodsMng.SectionGuideNm;
            }
            #endregion

            #region ●商品メーカー

            if (goodsMng.GoodsMakerCd != 0)
            {
                this.tNedit_GoodsMakerCd.SetInt(goodsMng.GoodsMakerCd);
            }
            if (goodsMng.GoodsMakerName != string.Empty)
            {
                this.GoodsMakerName_tEdit.DataText = goodsMng.GoodsMakerName;
            }
            #endregion

            #region ●商品コード
            if (goodsMng.GoodsNo != string.Empty)
            {
                this.tEdit_GoodsNo.DataText = goodsMng.GoodsNo;
            }
            if (goodsMng.GoodsName != string.Empty)
            {
                this.GoodsName_tEdit.DataText = goodsMng.GoodsName;
            }
            #endregion

            #region ●仕入先
            if (goodsMng.SupplierCd1 != 0)
            {
                this.tNedit_SupplierCd.SetInt(goodsMng.SupplierCd1);
            }
            if (goodsMng.SupplierSnm != string.Empty)
            {
                this.SupplierNm_tEdit.DataText = goodsMng.SupplierSnm;
            }
            #endregion


            #region ●BLコード
            if (goodsMng.BLGoodsCode != 0)
            {
                this.tNedit_BLGoodsCode.SetInt(goodsMng.BLGoodsCode);
            }
            if (goodsMng.BLGoodsName != string.Empty)
            {
                this.BLGoodsName_tEdit.DataText = goodsMng.BLGoodsName;
            }
            #endregion

            #region ●商品中分類コード
            if (goodsMng.GoodsMGroup != 0)
            {
                this.tNedit_GoodsMGroup.SetInt(goodsMng.GoodsMGroup);
            }
            if (goodsMng.GoodsMGroupNm != string.Empty)
            {
                this.tEdit_GoodsMGroupName.DataText = goodsMng.GoodsMGroupNm;
            }
            #endregion


            #region ●発注ロット１
            this.tNedit_SupplierLot.SetInt(goodsMng.SupplierLot1);
            #endregion
        }

		/// <summary>
		/// Valueチェック処理（int）
		/// </summary>
		/// <param name="sorce">tComboのValue</param>
		/// <returns>チェック後の値</returns>
		/// <remarks>
		/// <br>Note       : tComboの値をClassに入れる時のNULLチェックを行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
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
        /// 画面情報格納処理
        /// </summary>
        /// <param name="goodsMng">商品管理情報データクラス</param>
        /// <remarks>
        /// Note       : 画面情報のデータクラス格納処理を行います<br />
        /// Programmer : 980035 金沢　貞義<br />
        /// Date       : 2007.08.27<br />
        /// </remarks>
        private void DispToGoodsMng(ref GoodsMng goodsMng)
        {
            if (goodsMng == null)
            {
                // 新規の場合
                goodsMng = new GoodsMng();
            }

            goodsMng.EnterpriseCode = this._enterpriseCode;

            if (this.tEdit_SectionCodeAllowZero.DataText == "")
            {
                goodsMng.SectionCode = "00";                  // 拠点コード
            }
            else
            {
                goodsMng.SectionCode        = this.tEdit_SectionCodeAllowZero.DataText;                  // 拠点コード
            }
            if (goodsMng.SectionCode == "00")
            {
                goodsMng.SectionGuideNm = "全社共通";
            }
            else
            {
                goodsMng.SectionGuideNm = this.SectionName_tEdit.DataText;                  // 拠点名称
            }

            goodsMng.GoodsMakerCd       = this.tNedit_GoodsMakerCd.GetInt();                // 商品メーカーコード
            goodsMng.GoodsMakerName     = this.GoodsMakerName_tEdit.DataText;               // メーカー名称
            goodsMng.GoodsNo            = this.tEdit_GoodsNo.DataText;                      // 商品コード
            goodsMng.GoodsName          = this.GoodsName_tEdit.DataText;                    // 商品名称
            //goodsMng.BLGoodsCode      = this.tNedit_BLGoodsCode.GetInt();               // BLコード
            //goodsMng.BLGoodsName      = this.BLGoodsName_tEdit.DataText;                // BLコード名称
            goodsMng.SupplierCd1        = this.tNedit_SupplierCd.GetInt();                 // 仕入先コード
            goodsMng.SupplierSnm　      = this.SupplierNm_tEdit.DataText;                    // 仕入先名称
            goodsMng.SupplierLot1       = this.tNedit_SupplierLot.GetInt();                // 発注ロット
            //goodsMng.GoodsMGroup        = this.tNedit_GoodsMGroup.GetInt();                        // 中分類コード
            //goodsMng.GoodsMGroupNm      = this.tEdit_GoodsMGroupName.DataText;                   // 中分類名称
            // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
            goodsMng.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();               // BLコード
            goodsMng.BLGoodsName = this.BLGoodsName_tEdit.DataText;                // BLコード名称
            goodsMng.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();                        // 中分類コード
            goodsMng.GoodsMGroupNm = this.tEdit_GoodsMGroupName.DataText;                   // 中分類名称
            // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<
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
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
 		private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
		{
			bool result = true;

            #region ●商品情報入力チェック

            #region < 拠点コード入力/部品メーカー,品番,BLコード入力チェック >
            
            //拠点コードが未入力の場合
            if (this.tEdit_SectionCodeAllowZero.Text.TrimEnd() == "")
            {
                message = this.SectionCode_Label.Text + "を入力してください。";
                control = this.tEdit_SectionCodeAllowZero;
                result = false;
            }
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                //拠点＋メーカーが未入力の場合
                if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)
                {
                    if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                    {
                        message = this.GoodsMakerCd_Label.Text + "を入力してください。";
                        control = this.tNedit_GoodsMakerCd;
                        result = false;
                    }
                }

                //拠点＋品番が未入力の場合
                else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONGOODS)
                {
                    if (this.tEdit_GoodsNo.DataText == "")
                    {
                        message = this.ParentGoodsCode_Label.Text + "を入力してください。";
                        control = this.tEdit_GoodsNo;
                        result = false;
                    }
                }

                ////拠点＋メーカー＋BLコードが未入力の場合
                //else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONBLMAKER)
                //{
                //    if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                //    {
                //        message = this.GoodsMakerCd_Label.Text + "を入力してください。";
                //        control = this.tNedit_GoodsMakerCd;
                //        result = false;
                //    }
                //    else if (this.tNedit_BLGoodsCode.GetInt() == 0)
                //    {
                //        message = this.BLGoodsCode_Label.Text + "を入力してください。";
                //        control = this.tNedit_BLGoodsCode;
                //        result = false;
                //    }

                //}
                // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
                //拠点＋中分類＋メーカー＋BLコードが未入力の場合
                else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKERBL)
                {
                    if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                    {
                        message = this.GoodsMakerCd_Label.Text + "を入力してください。";
                        control = this.tNedit_GoodsMakerCd;
                        result = false;
                    }
                    if (this.tNedit_BLGoodsCode.GetInt() == 0)
                    {
                        message = this.BLGoodsCode_Label.Text + "を入力してください。";
                        control = this.tNedit_BLGoodsCode;
                        result = false;
                    }
                }
                //拠点＋中分類＋メーカーが未入力の場合
                else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKER)
                {
                    if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                    {
                        message = this.GoodsMakerCd_Label.Text + "を入力してください。";
                        control = this.tNedit_GoodsMakerCd;
                        result = false;
                    }
                    if (this.tNedit_GoodsMGroup.GetInt() == 0)
                    {
                        message = this.ultraLabel2.Text + "を入力してください。";
                        control = this.tNedit_GoodsMGroup;
                        result = false;
                    }
                }
                // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<
            }
            //仕入先コードが未入力
            if (this.tNedit_SupplierCd.GetInt() == 0)
            {
                message = this.SupplierCd_Label.Text + "を入力してください。";
                control = this.tNedit_SupplierCd;
                result = false;
            }

            
            #endregion

            #endregion

			return result;
		}


        // 2008.08.22 追加 >>>>>>>>>>>>>>>>>>>>
        #region 品番設定エラーチェック処理
        /// <summary>
        /// 部品代替設定エラーチェック処理
        /// </summary>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note        : 部品代替設定のエラーチェックを行います。
        ///					  条件オブジェクト:拠点コード, メーカーコード, メーカー名称, 商品コード
        ///					  結果オブジェクト:商品マスタ検索結果ステータス, 商品コード, 商品名称, メーカーコード, メーカー名称</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private int CheckGoodsNo(GoodsCndtn goodsCndtn, out GoodsUnitData goodsUnitData)
        {
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            goodsUnitData = null;

            try
            {
                //------------------
                // 必須入力チェック
                //------------------
                if (goodsCndtn == null) return ret;

                string message;
                List<GoodsUnitData> list = new List<GoodsUnitData>();
                status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out list, out message);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 商品マスタデータクラス
                    goodsUnitData = (GoodsUnitData)list[0];

                    ret = (int)InputChkStatus.Normal;
                }
                else if (status == -1)
                {
                    // 選択ダイアログでキャンセル
                    ret = (int)InputChkStatus.Cancel;
                }
                else
                {
                    ret = (int)InputChkStatus.NotExist;
                }
            }
            catch (Exception)
            {
            }

            return ret;
        }
        #endregion 品番設定エラーチェック処理

        #region 代替先品番設定処理
        /// <summary>
        /// 代替先品番設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus"></param>
        /// <param name="goodsUnitData"></param>
        /// 
        /// <remarks>
        /// <br>Note        : 代替先品番を画面に設定します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private void DispSetChgDestGoodsNo(DispSetStatus dispSetStatus, ref bool canChangeFocus, GoodsUnitData goodsUnitData)
        {
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.tEdit_GoodsNo.Clear();
                            this.GoodsName_tEdit.Clear();


                            // 現在データクリア
                            this._chgDestGoodsNoWork = "";

                            // フォーカス
                            canChangeFocus = false;
                         
                            break;
                        }
                    case DispSetStatus.Back:		// 元に戻す
                        {
                            this.tEdit_GoodsNo.Text = this._chgDestGoodsNoWork;

                            // フォーカス移動しない
                            canChangeFocus = false;
                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            if ((goodsUnitData != null))
                            {

                                this.tEdit_GoodsNo.Text = goodsUnitData.GoodsNo;	         // 品番
                                this.GoodsName_tEdit.Text = goodsUnitData.GoodsName;	     // 品名
                                this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd); // メーカーコード
                                this.GoodsMakerName_tEdit.Text = goodsUnitData.MakerName;    // メーカー名
                                // 2009/11/25 Del >>>
                                // 更新時はBLコードとBL名称を表示しない
                                //this.tNedit_BLGoodsCode.SetInt(goodsUnitData.BLGoodsCode); 　// BLコード
                                //this.BLGoodsName_tEdit.Text = goodsUnitData.BLGoodsFullName; // BL名
                                // 2009/11/25 Del <<<
                                
                                prvGoodsMakerCd = goodsUnitData.GoodsMakerCd;

                                // 現在データ保存
                                this._chgDestGoodsNoWork = this.tEdit_GoodsNo.Text;

                                BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
                                _bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, goodsUnitData.BLGoodsCode);

                                // 2009/11/25 Del >>>
                                // 更新時は中分類コードと中分類名称を表示しない
                                //this.tNedit_GoodsMGroup.SetInt(bLGoodsCdUMnt.GoodsRateGrpCode);

                                //if (this._goodsGroupDic.ContainsKey(bLGoodsCdUMnt.GoodsRateGrpCode))
                                //{
                                //    this.tEdit_GoodsMGroupName.Text = this._goodsGroupDic[bLGoodsCdUMnt.GoodsRateGrpCode].GoodsMGroupName.Trim();
                                //}
                                // 2009/11/25 Del <<<
                   
                                
                            }
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion 品番設定処理

        // 2008.08.22 追加 <<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="operation">オペレーション</param>
		/// <param name="erObject">エラーオブジェクト</param>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
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
		# endregion

		#region ■Control Events
		/// <summary>
		/// Form.Load イベント(MAKHN09520UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date        : 2007.08.27</br>
        /// </remarks>
        private void MAKHN09520UA_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList25 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;
            goodsAcs = new GoodsAcs();
            string message;
            goodsAcs.SearchInitial(this._enterpriseCode, this._belongSectionCode, out message);

			this.Ok_Button.ImageList     = imageList25;
			this.Cancel_Button.ImageList = imageList25;
			this.Revive_Button.ImageList = imageList25;
			this.Delete_Button.ImageList = imageList25;

            this.SectionGuide_Button.ImageList           = imageList16;
            this.GoodsMakerGuide_Button.ImageList        = imageList16;
            this.SupplierGd_ultraButton.ImageList        = imageList16;
            this.BLGoodsGuide_Button.ImageList           = imageList16;
            this.GoodsMGroupGuidButton.ImageList         = imageList16;
            // 処理ボタンのアイコン設定
            this.Ok_Button.Appearance.Image     = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

            // ガイドボタンのアイコン設定
            this.SectionGuide_Button.Appearance.Image           = Size16_Index.STAR1;
            this.GoodsMakerGuide_Button.Appearance.Image        = Size16_Index.STAR1;
            this.SupplierGd_ultraButton.Appearance.Image        = Size16_Index.STAR1;
            this.BLGoodsGuide_Button.Appearance.Image           = Size16_Index.STAR1;
            this.GoodsMGroupGuidButton.Appearance.Image         = Size16_Index.STAR1;

			// 画面初期設定処理
            ScreenInitialSetting();
            ReadGoodsMGroup();
		}

		/// <summary>
        /// Form.Closing イベント(MAKHN09520UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
        private void MAKHN09520UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date        : 2007.08.27</br>
        /// </remarks>
        private void MAKHN09520UA_VisibleChanged(object sender, System.EventArgs e)
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
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// <br>Update Note: 2012/10/08 李亜博 </br>
        ///	<br>		   ・redmine#32367 障害一覧の対応</br>
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
                this.tEdit_SectionCodeAllowZero.Clear();
                this.SectionName_tEdit.Clear();
                this.tNedit_GoodsMakerCd.Clear();
                this.GoodsMakerName_tEdit.Clear();
                this.tEdit_GoodsNo.Clear();
                this.GoodsName_tEdit.Clear();
                this.tNedit_BLGoodsCode.Clear();
                this.BLGoodsName_tEdit.Clear();
                this.tNedit_SupplierCd.Clear();
                this.SupplierNm_tEdit.Clear();
                this.tNedit_SupplierLot.Clear();
                this.tNedit_GoodsMGroup.Clear();
                this.tEdit_GoodsMGroupName.Clear();
                _blGoodsCode = 0;//ADD 2012/10/08 李亜博 for redmine#32367 

				// 新規モード
				this.Mode_Label.Text = INSERT_MODE;

				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				ScreenInputPermissionControl(true);

				//----- ueno add ---------- start 2008.03.28
				// 初期値設定


				if (this._mainOfficeFuncFlag != 1)
				{
					this.tEdit_SectionCodeAllowZero.DataText = this._belongSectionCode;
					this.SectionName_tEdit.DataText = this._belongSectionName;
				}
				//----- ueno add ---------- end 2008.03.28

				// クローンを再度取得する
                GoodsMng goodsMng = new GoodsMng();
				
				//クローン作成
                this._goodsMngClone = goodsMng.Clone(); 
                DispToGoodsMng(ref this._goodsMngClone);

				// フォーカス設定
				//----- ueno add ---------- start 2008.03.28
				//this.tEdit_SectionCodeAllowZero.Focus();
				//this.tEdit_SectionCodeAllowZero.SelectAll();
				
				if (this._mainOfficeFuncFlag == 1)
				{
					this.tEdit_SectionCodeAllowZero.Focus();
					this.tEdit_SectionCodeAllowZero.SelectAll();
				}
				else
				{
					this.tNedit_GoodsMakerCd.Focus();
					this.tNedit_GoodsMakerCd.SelectAll();
				}
				//----- ueno add ---------- end 2008.03.28
                //if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)
                //{
                //    this.SetKind_tComboEditor.SelectedIndex = 1;
                //    this.
                //}
                //else
                //{
                //    this.SetKind_tComboEditor.SelectedIndex = 0;
                //}
                SetKind_tComboEditor_ValueChanged(sender, e);
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
        /// 商品管理情報マスタ 情報登録処理
		/// </summary>
		/// <returns>登録結果（true:OK／false:NG）</returns>
		/// <remarks>
        /// <br>Note       : 商品管理情報マスタ 情報登録を行います。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
		private bool SaveProc()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			Control control = null;
			string message = null;
			string loginID = "";

            GoodsMng goodsMng = null;

			//----- ueno add ---------- start 2008.03.31
			// 拠点コードゼロ詰め処理
			this.tEdit_SectionCodeAllowZero.Text = GetZeroPaddedTextProc(this.tEdit_SectionCodeAllowZero.Text, this.tEdit_SectionCodeAllowZero.ExtEdit.Column);
			//----- ueno add ---------- end 2008.03.31

			if (this.DataIndex >= 0)
			{
                Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsMngAcs.FILEHEADERGUID_TITLE];
                goodsMng = ((GoodsMng)this._goodsMngTable[guid]).Clone();
			}

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

            this.DispToGoodsMng(ref goodsMng);

            status = this._goodsMngAcs.Write(ref goodsMng);
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
						//ERR_DPR_MSG,						// 表示するメッセージ  // DEL 2012/09/21 袁磊 redmine#32367
                        ERR_800_MSG, // ADD 2012/09/21 袁磊 redmine#32367
						status,								// ステータス値
						MessageBoxButtons.OK);				// 表示するボタン

                    this.tEdit_SectionCodeAllowZero.Focus();
                    this.tEdit_SectionCodeAllowZero.SelectAll();
					
					//----- ueno add ---------- end 2008.03.31
					// 先頭のゼロ詰めを削除
					this.tEdit_SectionCodeAllowZero.Text = GetZeroPadCanceledTextProc(this.tEdit_SectionCodeAllowZero.Text);
					//----- ueno add ---------- end 2008.03.31
					
                    return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._goodsMngAcs);

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

					//----- ueno add ---------- end 2008.03.31
					// 先頭のゼロ詰めを削除
					this.tEdit_SectionCodeAllowZero.Text = GetZeroPadCanceledTextProc(this.tEdit_SectionCodeAllowZero.Text);
					//----- ueno add ---------- end 2008.03.31

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
                        this._goodsMngAcs,					// エラーが発生したオブジェクト
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

					//----- ueno add ---------- end 2008.03.31
					// 先頭のゼロ詰めを削除
					this.tEdit_SectionCodeAllowZero.Text = GetZeroPadCanceledTextProc(this.tEdit_SectionCodeAllowZero.Text);
					//----- ueno add ---------- end 2008.03.31
					
					return false;
				}
			}

			// DataSet展開処理
            GoodsMngToDataSet(goodsMng, this.DataIndex);
			
			return true;
		}

		//----- ueno del ---------- start 2008.03.31
		////----- ueno add ---------- start 2008.03.28
		///// <summary>
		///// 拠点コードゼロ埋め処理
		///// </summary>
		///// <param name="goodsMngtEdit_SectionCodeAllowZero">拠点コード</param>
		///// <remarks>
		///// <br>Note       : 拠点コードをゼロ埋めします。</br>
		///// <br>Programer  : 30167 上野　弘貴</br>
		///// <br>Date       : 2008.03.28</br>
		///// </remarks>
		//private void ZeroFillSectionCode(ref TEdit goodsMngtEdit_SectionCodeAllowZero)
		//{
		//    string wkStr = goodsMngtEdit_SectionCodeAllowZero.DataText;

		//    goodsMngtEdit_SectionCodeAllowZero.DataText = wkStr.PadLeft(6, '0');
		//}
		////----- ueno add ---------- end 2008.03.28
		//----- ueno del ---------- end 2008.03.31

		//----- ueno add ---------- start 2008.03.31
		/// <summary>
		/// ゼロ埋め後テキスト取得処理実装
		/// </summary>
		/// <param name="fullText">入力済みテキスト</param>
		/// <param name="columnCount">入力可能桁数</param>
		/// <returns>ゼロ埋めしたテキスト</returns>
		/// <br>Note       : 文字列をゼロ埋めします。</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.31</br>
		private static string GetZeroPaddedTextProc(string fullText, int columnCount)
		{
			if (fullText.Trim() != string.Empty)
			{
				// ゼロ詰め処理
				return fullText.PadLeft(columnCount, '0');
			}
			else
			{
				return string.Empty;
			}
		}
		
		/// <summary>
		/// 文字列→数値変換
		/// </summary>
		/// <param name="str"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		static int GetIntFromString(string str, int defaultValue)
		{
			try
			{
				return Int32.Parse(str);
			}
			catch
			{
				return defaultValue;
			}
		}

		/// <summary>
		/// ゼロ埋めキャンセル後テキスト取得処理実装
		/// </summary>
		/// <param name="fullText">入力済みテキスト</param>
		/// <returns>ゼロ埋めキャンセルしたテキスト</returns>
		/// <br>Note       : 文字列からゼロを削除します。</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.03.31</br>
		private static string GetZeroPadCanceledTextProc(string fullText)
		{
			if (fullText.Trim() != string.Empty)
			{
				int cnt = 0;
				string wkStr = fullText;
				
				// 先頭のゼロ詰めを削除
				while (fullText.StartsWith("0"))
				{
					fullText = fullText.Substring(1, fullText.Length - 1);
					cnt++;
				}
				
				// オールゼロの場合、共通コードとする
				if (wkStr.Length == cnt)
				{
					fullText = "0";
				}
				return fullText;
			}
			else
			{
				return string.Empty;
			}
		}
		//----- ueno add ---------- end 2008.03.31

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// 削除モード以外の場合は保存確認処理を行う
			if (this.Mode_Label.Text != DELETE_MODE) 
			{
				//保存確認
                GoodsMng compareGoodsMng = new GoodsMng();
                compareGoodsMng = this._goodsMngClone.Clone();  
				//現在の画面情報を取得する
                DispToGoodsMng(ref compareGoodsMng);
                //最初に取得した画面情報と比較
                if (!(this._goodsMngClone.Equals(compareGoodsMng)))	
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
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// <br>Update Note: 2018/11/08 陳艶丹</br>
        /// <br>　　　　　 : redmine#49781 商品管理情報マスタの削除仕様変更の対応</br>
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
                Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsMngAcs.FILEHEADERGUID_TITLE];
                GoodsMng goodsMng = ((GoodsMng)this._goodsMngTable[guid]).Clone();

                // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
                if ((goodsMng.SectionCode != "" && goodsMng.BLGoodsCode != 0 && goodsMng.GoodsMakerCd != 0 && goodsMng.GoodsNo == "") ||
                 (goodsMng.SectionCode != "" && goodsMng.GoodsMGroup != 0 && goodsMng.GoodsMakerCd != 0 && goodsMng.GoodsNo == ""))
                {
                    ArrayList wkList = new ArrayList();
                    object objret = wkList;
                    PrmSettingUWork primeSettingParaWork = new PrmSettingUWork();
                    primeSettingParaWork.EnterpriseCode = goodsMng.EnterpriseCode;
                    primeSettingParaWork.SectionCode = goodsMng.SectionCode;
                    primeSettingParaWork.GoodsMGroup = goodsMng.GoodsMGroup;
                    primeSettingParaWork.PartsMakerCd = goodsMng.GoodsMakerCd;
                    primeSettingParaWork.TbsPartsCode = goodsMng.BLGoodsCode;
                    primeSettingParaWork.PrimeDisplayCode = -1;

                    this._goodsMngAcs.GetPrimeSettingMng(ref objret, primeSettingParaWork, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
                    if (objret != null)
                    {
                        if (((ArrayList)objret).Count == 0)
                        {
                            status = this._goodsMngAcs.Delete(goodsMng);
                        }
                        else
                        {
                            // --- UPD 2018/11/08 陳艶丹 for redmine#49781 ---------->>>>>
                            //TMsgDisp.Show(this,
                            //emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            //ASSEMBLY_ID,
                            //"このレコードは優良設定マスタで削除して下さい",
                            //0,
                            //MessageBoxButtons.OK);
                            //this.Hide();
                            //return;
                            DialogResult Dialog = TMsgDisp.Show(
                                   this,
                                   emErrorLevel.ERR_LEVEL_QUESTION,
                                   ASSEMBLY_ID,
                                   DeleteMessage,
                                   0,
                                   MessageBoxButtons.YesNo,
                                   MessageBoxDefaultButton.Button2);
                            if (Dialog == DialogResult.Yes)
                            {
                                status = this._goodsMngAcs.Delete(goodsMng);
                            }
                            else
                            {
                                return;
                            }
                            // --- UPD 2018/11/08 陳艶丹 for redmine#49781 ----------<<<<<
                        }
                    }
                }
                else
                {
                    status = this._goodsMngAcs.Delete(goodsMng);
                }
                // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<
                switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this.DataIndex].Delete();
                        this._goodsMngTable.Remove(goodsMng.FileHeaderGuid);

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._goodsMngAcs);

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
                            this._goodsMngAcs,					  // エラーが発生したオブジェクト
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
        /// <br>Programmer : 980035 金沢　貞義</br>
        /// <br>Date       : 2007.08.27</br>
        /// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsMngAcs.FILEHEADERGUID_TITLE];
            GoodsMng goodsMng = ((GoodsMng)_goodsMngTable[guid]).Clone();

            status = this._goodsMngAcs.Revival(ref goodsMng);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._goodsMngAcs);

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
                        this._goodsMngAcs,					  // エラーが発生したオブジェクト
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
            GoodsMngToDataSet(goodsMng, this.DataIndex);

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
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date        : 2007.08.27</br>
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
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date        : 2007.08.27</br>
        /// </remarks>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
            GoodsUnitData goodsUnitData = null;
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

			//----- ueno add ---------- start 2008.03.31
			// 編集前イベント一時停止
			this.tEdit_SectionCodeAllowZero.BeforeEnterEditMode -= this.tEdit_SectionCodeAllowZero_BeforeEnterEditMode;
			//----- ueno add ---------- end 2008.03.31
            bool canChangeFocus = true;
            DispSetStatus dispSetStatus = DispSetStatus.Clear;

            if (e.NextCtrl == this.tNedit_GoodsMakerCd)
            {
                prvGoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            }


            //GoodsMngtEdit_SectionCodeAllowZero

            switch (e.PrevCtrl.Name)
            {
                #region ●拠点情報検索
				case "tEdit_SectionCodeAllowZero":
                    {
                        #region < 入力チェック >
                        if (this.tEdit_SectionCodeAllowZero.DataText != "")
                        {
							//----- ueno add ---------- start 2008.03.28
							// 拠点コードゼロ詰め処理
							this.tEdit_SectionCodeAllowZero.Text = GetZeroPaddedTextProc(this.tEdit_SectionCodeAllowZero.Text, this.tEdit_SectionCodeAllowZero.ExtEdit.Column);

                             //拠点コードがゼロの場合、共通とする
                            if (this.tEdit_SectionCodeAllowZero.DataText == "00")
                            {
                                this.SectionName_tEdit.DataText = "全社共通";
                                if (e.Key == Keys.Return)
                                {
                                    if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)
                                    {
                                        e.NextCtrl = tNedit_GoodsMakerCd;
                                        e.NextCtrl.Select();
                                    }
                                    //else //DEL 2012/09/21 袁磊 for redmine#32367
                                    else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONGOODS) //ADD 2012/09/21 袁磊 for redmine#32367
                                    {
                                        e.NextCtrl = tEdit_GoodsNo;
                                        e.NextCtrl.Select();
                                    }
                                    // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
                                    else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKERBL)
                                    {
                                        e.NextCtrl = tNedit_GoodsMakerCd;
                                        e.NextCtrl.Select();
                                    }
                                    else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKER)
                                    {
                                        e.NextCtrl = tNedit_GoodsMakerCd;
                                        e.NextCtrl.Select();
                                    }
                                    // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<
                                }
                                break;
                            }

							//----- ueno add ---------- end 2008.03.28

                            // 拠点データクラス
                            SecInfoSet secInfoSet;
                            // 拠点データクラスインスタンス化
                            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();

                            #region < 拠点情報取得処理 >
                            int status = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this.tEdit_SectionCodeAllowZero.DataText);
                            #endregion

                            #region < 画面表示処理 >

                            if (status == 0 && secInfoSet.LogicalDeleteCode != 1)
                            {
                                #region -- 取得データ展開 --
                                // 取得データ表示
                                // 拠点情報画面表示
                                this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm;
                                if (e.Key == Keys.Return)
                                {
                                    if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)
                                    {
                                        e.NextCtrl = tNedit_GoodsMakerCd;
                                        e.NextCtrl.Select();
                                    }
                                    //else //DEL 2012/09/21 袁磊 for redmine#32367
                                    else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONGOODS) //ADD 2012/09/21 袁磊 for redmine#32367
                                    {
                                        e.NextCtrl = tEdit_GoodsNo;
                                        e.NextCtrl.Select();
                                    }
                                    // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
                                    else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKERBL)
                                    {
                                        e.NextCtrl = tNedit_GoodsMakerCd;
                                        e.NextCtrl.Select();
                                    }
                                    else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKER)
                                    {
                                        e.NextCtrl = tNedit_GoodsMakerCd;
                                        e.NextCtrl.Select();
                                    }
                                    // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<
                                }
                                #endregion
                            }
                            else
                            {
                                #region -- 取得失敗 --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "該当するデータが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tEdit_SectionCodeAllowZero.Clear();
                                this.SectionName_tEdit.Clear();
                                e.NextCtrl = SectionGuide_Button;
                                e.NextCtrl.Select();

                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            this.tEdit_SectionCodeAllowZero.Clear();
                            this.SectionName_tEdit.Clear();
                        }


                        #endregion
                        break;
                    }

                #endregion

                #region ●メーカー情報検索
                case "tNedit_GoodsMakerCd":
                    {
                        #region < ゼロ入力チェック >
                        if (this.tNedit_GoodsMakerCd.GetInt() != 0)
                        {

                            // メーカーデータクラス
                            //Maker maker;
                            MakerUMnt makerUMnt;
                            // 商品データクラスインスタンス化
                            MakerAcs makerAcs = new MakerAcs();

                            #region < メーカー情報取得処理 >
                            makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt());
                            #endregion

                            #region < 画面表示処理 >

                            if (makerUMnt != null && makerUMnt.LogicalDeleteCode !=1)
                            {
                                #region -- 取得データ展開 --
                                // メーカー情報画面表示
                                this.GoodsMakerName_tEdit.DataText = makerUMnt.MakerName;
                                if (e.Key == Keys.Return)
                                {
                                    if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)
                                    {
                                        e.NextCtrl.Select();
                                        e.NextCtrl = tNedit_SupplierCd;
                                    }
                                    //else //DEL 2012/09/21 袁磊 for redmine#32367
                                    else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKERBL) //ADD 2012/09/21 袁磊 for redmine#32367
                                    {
                                        e.NextCtrl.Select();
                                        e.NextCtrl = tNedit_BLGoodsCode;
                                    }
                                    // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
                                    else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKER)
                                    {
                                        e.NextCtrl.Select();
                                        e.NextCtrl = tNedit_GoodsMGroup;
                                    }
                                    // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<
                                }
                                #endregion
                            }
                            else
                            {
                                #region -- 取得失敗 --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "該当するデータが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tNedit_GoodsMakerCd.Clear();
                                this.GoodsMakerName_tEdit.Clear();
                                e.NextCtrl.Select();
                                e.NextCtrl = GoodsMakerGuide_Button;

                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            this.tNedit_GoodsMakerCd.Clear();
                            this.GoodsMakerName_tEdit.Clear();
                        }

                        if (prvGoodsMakerCd != tNedit_GoodsMakerCd.GetInt())
                        {
                            // 商品情報はクリア
                            this.tEdit_GoodsNo.Clear();
                            this.GoodsName_tEdit.Clear();
                        }
                        #endregion

                        break;
                    }

                #endregion

                #region ●商品情報検索
                case "tEdit_GoodsNo":
                    {
                        #region < 空入力チェック >
                        if (this.tEdit_GoodsNo.DataText != "")
                        {
                            //string searchCode;
                            // 検索の種類を取得
                            //int searchType = this.GetSearchType(this.tEdit_GoodsNo.DataText, out searchCode);
                            //画面の初期化
                            this.GoodsName_tEdit.DataText = "";
                            this.tNedit_GoodsMakerCd.Clear();
                            this.tNedit_BLGoodsCode.Clear();
                            this._blGoodsCode = 0;//ADD 2012/10/08 李亜博for redmine#32367
                            this.GoodsMakerName_tEdit.DataText = "";
                            this.BLGoodsName_tEdit.DataText = "";
                            // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
                            // 検索条件の設定
                            GoodsCndtn goodsCndtn = new GoodsCndtn();
                            goodsCndtn.EnterpriseCode = this._enterpriseCode;
                            goodsCndtn.GoodsMakerCd   = this.tNedit_GoodsMakerCd.GetInt();
                            goodsCndtn.MakerName      = this.GoodsMakerName_tEdit.DataText;
                            //goodsCndtn.BLGoodsCode    = this.tNedit_BLGoodsCode.GetInt();
                            //goodsCndtn.BLGoodsName    = this.BLGoodsName_tEdit.DataText;
                            goodsCndtn.GoodsNo = this.tEdit_GoodsNo.DataText;//searchCode;
                            //goodsCndtn.GoodsNoSrchTyp = searchType;
                            //GoodsAcs goodsAcs         = new GoodsAcs();
                            // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<

                            // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
                            goodsCndtn.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                            goodsCndtn.BLGoodsName = this.BLGoodsName_tEdit.DataText;
                            goodsCndtn.GoodsMGroup = this.tNedit_GoodsMGroup.GetInt();
                            goodsCndtn.GoodsMGroupName = this.tEdit_GoodsMGroupName.DataText;
                            // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<

                            // 2008.08.22 修正 >>>>>>>>>>>>>>>>>>>>
                            //List<GoodsUnitData> goodsUnitDataList;
                            //string message;
                            // 2008.08.22 修正 <<<<<<<<<<<<<<<<<<<<

                            #region < 商品検索処理 >



                            // 2008.08.22 修正 >>>>>>>>>>>>>>>>>>>>
                            /* 
                            MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
                            // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
                            //int status = goodsSelectGuide.ReadGoods(this, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
                            int status = goodsSelectGuide.ReadGoods(this, false, goodsCndtn, out goodsUnitDataList, out message);
                            // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
                            */

                            // 存在チェック
                            switch (CheckGoodsNo(goodsCndtn, out goodsUnitData))
                            {
                              case (int)InputChkStatus.Normal:
                                    {
                                        dispSetStatus = DispSetStatus.Update;
                                        break;
                                     }   
                              case (int)InputChkStatus.NotInput:
                                    {
                                        dispSetStatus = DispSetStatus.Clear;
                                        break;
                                    }
                              case (int)InputChkStatus.Cancel:
                                    {
                                        dispSetStatus = DispSetStatus.Clear;
                                        break;
                                    }       
                              default:
                                   {
                                        TMsgDisp.Show(
                                                this, 												// 親ウィンドウフォーム
                                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                this.Name,											// アセンブリID
                                                "指定された条件で品番は存在しませんでした。",       // 表示するメッセージ
                                                0,													// ステータス値
                                                MessageBoxButtons.OK);								// 表示するボタン
                                        
                                                //dispSetStatus = this._chgSrcGoodsNoWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
                                                break;
                                    }
                             }   
                            // データ設定
                             DispSetChgDestGoodsNo(dispSetStatus, ref canChangeFocus, goodsUnitData);

                            // 2008.08.22 修正 <<<<<<<<<<<<<<<<<<<<
                            #endregion

                            #region < 画面表示処理 >
                            //if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                            //{
                            //    #region -- 取得データ展開 --
                            //    // 商品マスタデータクラス
                            //    GoodsUnitData goodsUnitData = new GoodsUnitData();
                            //    goodsUnitData = goodsUnitDataList[0];

                            //    // 商品情報画面表示
                            //    this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);
                            //    this.GoodsMakerName_tEdit.DataText = goodsUnitData.MakerName;
                            //    this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo;
                            //    this.GoodsName_tEdit.DataText = goodsUnitData.GoodsName;
                            //    #endregion
                            //}
                            //else
                            //    // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
                            //    if (status == -1)
                            //    {
                            //        #region -- キャンセル --
                            //        e.NextCtrl = e.PrevCtrl;
                            //        #endregion
                            //    }
                            //    else
                            //    // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
                            //    {
                            //        #region -- 取得失敗 --
                            //        TMsgDisp.Show(
                            //            this,
                            //            emErrorLevel.ERR_LEVEL_INFO,
                            //            this.Name,
                            //            "商品コード [" + searchCode + "] に該当するデータが存在しません。",
                            //            -1,
                            //            MessageBoxButtons.OK);

                            //        // 商品情報クリア
                            //        this.tEdit_GoodsNo.Clear();
                            //        this.GoodsName_tEdit.Clear();
                            //       #endregion
                            
                            #endregion
                        }
                        else
                        {
                            // 商品コードを元に戻す
                            this.tEdit_GoodsNo.DataText = "";
                            // 商品名称のクリア
                            this.GoodsName_tEdit.DataText = "";
                            this.tNedit_GoodsMakerCd.Clear();
                            this.tNedit_BLGoodsCode.Clear();
                            this._blGoodsCode = 0;//ADD 2012/10/08 李亜博for redmine#32367
                            this.GoodsMakerName_tEdit.DataText = "";
                            this.BLGoodsName_tEdit.DataText = "";
                            this.tNedit_GoodsMGroup.Clear();
                            this.tEdit_GoodsMGroupName.DataText = "";

                        }
                        if (canChangeFocus == false)
                        {
                            e.NextCtrl = e.PrevCtrl;
                            e.NextCtrl.Select();
                        }

                        #endregion

                        break;
                    }
                #endregion

                //#region BLコード検索
                //case "tNedit_BLGoodsCode":
                //    {
                //        #region < ゼロ入力チェック >
                //        if (this.tNedit_BLGoodsCode.GetInt() != 0)
                //        {

                //            // メーカーデータクラス
                //            BLGoodsCdUMnt bLGoodsCdUMnt;
                //            // 商品データクラスインスタンス化
                //            BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();

                //            #region < BLコード情報取得処理 >
                //            bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, this.tNedit_BLGoodsCode.GetInt());
                //            #endregion

                //            #region < 画面表示処理 >

                //            if (bLGoodsCdUMnt != null && bLGoodsCdUMnt.LogicalDeleteCode !=1)
                //            {
                //                #region -- 取得データ展開 --
                //                // BLコード情報画面表示
                //                this.BLGoodsName_tEdit.DataText = bLGoodsCdUMnt.BLGoodsFullName;
                //                if (e.Key == Keys.Return)
                //                {
                //                    e.NextCtrl.Select();
                //                    e.NextCtrl = tNedit_SupplierCd;
                //                }
                //                #endregion
                //            }
                //            else
                //            {
                //                #region -- 取得失敗 --
                //                TMsgDisp.Show(
                //                    this,
                //                    emErrorLevel.ERR_LEVEL_INFO,
                //                    this.Name,
                //                    "該当するデータが存在しません。",
                //                    -1,
                //                    MessageBoxButtons.OK);

                //                this.tNedit_BLGoodsCode.Clear();
                //                this.BLGoodsName_tEdit.Clear();
                //                e.NextCtrl.Select();
                //                e.NextCtrl = e.PrevCtrl;

                //                #endregion
                //            }
                //            #endregion
                //        }
                //        else
                //        {
                //            this.tNedit_BLGoodsCode.Clear();
                //            this.BLGoodsName_tEdit.Clear();
                //        }
                //        #endregion

                //        break;
                //    }



                //#endregion

                // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
                #region BLコード検索
                case "tNedit_BLGoodsCode":
                    {
                        #region < ゼロ入力チェック >
                        if (this.tNedit_BLGoodsCode.GetInt() != _blGoodsCode)
                        {
                            if (this.tNedit_BLGoodsCode.GetInt() != 0)
                            {
                                // メーカーデータクラス
                                BLGoodsCdUMnt bLGoodsCdUMnt;
                                // 商品データクラスインスタンス化
                                BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();

                                #region < BLコード情報取得処理 >
                                int status = bLGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, this.tNedit_BLGoodsCode.GetInt());
                                #endregion

                                #region < 画面表示処理 >

                                if (status == 0 && bLGoodsCdUMnt != null && bLGoodsCdUMnt.LogicalDeleteCode != 1)
                                {
                                    #region -- 取得データ展開 --
                                    // BLコード情報画面表示
                                    this.BLGoodsName_tEdit.DataText = bLGoodsCdUMnt.BLGoodsFullName;
                                    _blGoodsCode = this.tNedit_BLGoodsCode.GetInt();

                                    BLGoodsCdUMnt bLGoodsCdUMnt2;
                                    BLGroupU bLGroupU;
                                    GoodsGroupU goodsGroupU;
                                    UserGdBdU userGdBdU;

                                    GoodsAcs _goodsAcs = new GoodsAcs();
                                    _goodsAcs.GetBLGoodsRelation(this.tNedit_BLGoodsCode.GetInt(), out bLGoodsCdUMnt2, out bLGroupU, out goodsGroupU, out userGdBdU);
                                    if (goodsGroupU != null)
                                    {
                                        this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
                                        this.tEdit_GoodsMGroupName.Text = goodsGroupU.GoodsMGroupName;
                                    }
                                    if (e.Key == Keys.Return)
                                    {
                                        e.NextCtrl.Select();
                                        e.NextCtrl = tNedit_SupplierCd;
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region -- 取得失敗 --
                                    //_blGoodsCode = 0; //DEL 2012/10/08 李亜博for redmine#32367

                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当するデータが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    this.tNedit_BLGoodsCode.Clear();
                                    this._blGoodsCode = 0;//ADD 2012/10/08 李亜博for redmine#32367
                                    this.BLGoodsName_tEdit.Clear();
                                    this.tNedit_GoodsMGroup.Clear();
                                    this.tEdit_GoodsMGroupName.Clear();
                                    e.NextCtrl.Select();
                                    e.NextCtrl = BLGoodsGuide_Button;
                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {
                                this.tNedit_BLGoodsCode.Clear();
                                this._blGoodsCode = 0;//ADD 2012/10/08 李亜博for redmine#32367
                                this.BLGoodsName_tEdit.Clear();
                                this.tNedit_GoodsMGroup.Clear();
                                this.tEdit_GoodsMGroupName.Clear();
                            }
                        }
                        if (this.tNedit_BLGoodsCode.GetInt() != 0)
                        {
                            if (e.Key == Keys.Return)
                            {
                                e.NextCtrl.Select();
                                e.NextCtrl = tNedit_SupplierCd;
                            }
                        }
                        #endregion

                            break;
                        }
                #endregion

                #region 中分類検索
                case "tNedit_GoodsMGroup":
                    {
                        #region < ゼロ入力チェック >
                        if (this.tNedit_GoodsMGroup.GetInt() != 0)
                        {
                            GoodsGroupU goodsGroupU;
                            GoodsGroupUAcs goodsGroupUAcs = new GoodsGroupUAcs();

                            #region < 中分類情報取得処理 >
                            int status = goodsGroupUAcs.Search(out goodsGroupU, this._enterpriseCode, this.tNedit_GoodsMGroup.GetInt());
                            #endregion

                            #region < 画面表示処理 >

                            if (status == 0 && goodsGroupU !=null && goodsGroupU.LogicalDeleteCode != 1)//LogicalDeleteCode論理削除区分(0:有効,1:論理削除,2:保留,3:完全削除)
                            {
                                #region -- 取得データ展開 --
                                // 情報画面表示
                                this.tEdit_GoodsMGroupName.DataText = goodsGroupU.GoodsMGroupName;
                                if (e.Key == Keys.Return)
                                {
                                    e.NextCtrl.Select();
                                    e.NextCtrl = tNedit_SupplierCd;
                                }
                                #endregion
                            }
                            else
                            {
                                #region -- 取得失敗 --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "該当するデータが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tNedit_GoodsMGroup.Clear();
                                this.tEdit_GoodsMGroupName.Clear();
                                e.NextCtrl.Select();
                                e.NextCtrl = GoodsMGroupGuidButton;
                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            this.tNedit_GoodsMGroup.Clear();
                            this.tEdit_GoodsMGroupName.Clear();
                        }
                        #endregion

                        break;
                    }
                #endregion
                // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<

                #region ●仕入先
                case "tNedit_SupplierCd":
                    {
                        #region < 入力チェック >
                        if (this.tNedit_SupplierCd.GetInt() != 0)
                        {
                            // 発注先データクラス
                            Supplier supplier;
                            // 発注先データクラスインスタンス化
                            SupplierAcs supplierInfoAcs = new SupplierAcs();

                            #region < 発注情報取得処理 >
                            int status = supplierInfoAcs.Read(out supplier, this._enterpriseCode, this.tNedit_SupplierCd.GetInt());
                            #endregion

                            #region < 画面表示処理 >

                            // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
                            if ((status == 0) && (supplier.LogicalDeleteCode != 1))
    
                            // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
                            {
                                #region -- 取得データ展開 --
                                // 取得データ表示
                                // 発注情報画面表示
                                this.SupplierNm_tEdit.DataText = supplier.SupplierSnm;

                                if (e.Key == Keys.Return)
                                {
                                    e.NextCtrl = tNedit_SupplierLot;
                                    e.NextCtrl.Select();
                                }
                                #endregion
                            }
                            else
                            {
                                #region -- 取得失敗 --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "該当するデータが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tNedit_SupplierCd.Clear();
                                this.SupplierNm_tEdit.Clear();
                                e.NextCtrl = SupplierGd_ultraButton;
                                e.NextCtrl.Select();
                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            this.tNedit_SupplierCd.Clear();
                            this.SupplierNm_tEdit.Clear();
                        }
                        #endregion

                        if (this.SettingSupplier(SupplierMode.Supplier1) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            e.NextCtrl = e.PrevCtrl;
                            e.NextCtrl.Select();
                        }
                        break;
                    }

                #endregion
            }
            if (e.PrevCtrl == Ok_Button && e.Key == Keys.Up)
            {
                e.NextCtrl = tNedit_SupplierLot;
                e.NextCtrl.Select();
            }

            //----- ueno add ---------- start 2008.03.31
			// 編集前イベント再開
			this.tEdit_SectionCodeAllowZero.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.tEdit_SectionCodeAllowZero_BeforeEnterEditMode);
			//----- ueno add ---------- end 2008.03.31

            // --- DEL 2012/10/08 李亜博for redmine#32367 ---------->>>>>
            // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            //switch (e.NextCtrl.Name)
            //{
            //    case "tNedit_SupplierCd":       // 仕入先コード
            //    case "tNedit_SupplierLot":      // 流通ロット
            //        {
            //            if (this._dataIndex < 0)
            //            {
            //                if (ModeChangeProc())
            //                {
            //                    e.NextCtrl = tEdit_SectionCodeAllowZero;
            //                }
            //            }
            //            break;
            //        }
            //}
            // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END
            // --- DEL 2012/10/08 李亜博for redmine#32367 ----------<<<<<

            // --- ADD 2012/10/08 李亜博for redmine#32367 ---------->>>>>
            if ( (this.SetKind_tComboEditor.Text ==  SETKIND_SECTIONGOODS) //拠点＋品番
                || (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)　//拠点＋メーカー 
                || (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKERBL && this.tNedit_GoodsMakerCd.GetInt() != 0 && this.tNedit_BLGoodsCode.GetInt() != 0)　// 拠点＋メーカー＋中分類＋ＢＬ
                || (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKER && this.tNedit_GoodsMakerCd.GetInt() != 0 && this.tNedit_GoodsMGroup.GetInt() != 0))　// 拠点＋メーカー＋中分類
            {
                switch (e.NextCtrl.Name)
                {
                    case "tNedit_SupplierCd":       // 仕入先コード
                    case "tNedit_SupplierLot":      // 流通ロット
                        {
                            if (this._dataIndex < 0)
                            {
                                if (ModeChangeProc())
                                {
                                    e.NextCtrl = tEdit_SectionCodeAllowZero;
                                }
                            }
                            break;
                        }
                }
            }
            // --- ADD 2012/10/08 李亜博for redmine#32367 ----------<<<<<
        }

        /// <summary>
        /// 検索タイプ取得処理
        /// </summary>
        /// <param name="inputCode">入力されたコード</param>
        /// <param name="searchCode">検索用コード（*を除く）</param>
        /// <returns>0:完全一致検索 1:前方一致検索 2:後方一致検索 3:曖昧検索</returns>
        /// <remarks>
        /// Note			:	検索する方法を取得する処理を行います。<br />
        /// Programmer      :   980035 金沢　貞義<br />
        /// Date            :   2007.08.27<br />
        /// </remarks>
        public int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if ((firstString == "*") && (lastString == "*"))
                {
                    return 3;
                }
                else if (firstString == "*")
                {
                    return 2;
                }
                else if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                // *が存在しないため完全一致検索
                return 0;
            }
        }

        # endregion

		# region ガイド処理
        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 拠点ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date        : 2007.08.27</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();

            //----- ueno add ---------- start 2008.03.28
            // 共通コード有り
            //int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
            //----- ueno add ---------- end 2008.03.28

            if (status != 0) return;

            // 取得データ表示
            this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode;
            this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm;
            if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)
            {
                tNedit_GoodsMakerCd.Focus();
            }
            else
            {
                tEdit_GoodsNo.Focus();
            }

        }

        /// <summary>
        /// Control.Click イベント(GoodsMakerGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 商品メーカーガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date        : 2007.08.27</br>
        /// </remarks>
        private void GoodsMakerGuide_Button_Click(object sender, EventArgs e)
        {
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt = new MakerUMnt();

            //メーカーガイド起動
            int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            if (status != 0) return;

            // 取得データ表示
            this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
            this.GoodsMakerName_tEdit.DataText = makerUMnt.MakerName;

            // 商品データとの整合性を取るため商品情報のクリア
            this.tEdit_GoodsNo.Clear();
            this.GoodsName_tEdit.Clear();

            if (this.tNedit_GoodsMakerCd.GetInt() != 0)
            {
                if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)
                {
                    tNedit_SupplierCd.Focus();
                }
                else
                {
                    tNedit_BLGoodsCode.Focus();
                }
            }
        }


        //// 2008.08.22 >>>>>>>>>>>>>>>>>>>>>>>>>>

        /// <summary>
        /// Control.Click イベント(BLGoodsCodeGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : BLコードガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 30350　櫻井　亮太</br>
        /// <br>Date        : 2008.08.22</br>
        /// <br>Update Note : 2012/10/08 李亜博 </br>
        ///	<br>			・redmine#32367 障害一覧の対応</br>
        /// </remarks>
        private void BLGoodsGuide_Button_Click(object sender, EventArgs e)
        {

            // 検索条件の設定
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();

            //BLコードガイド起動
            int status = bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != 0) return;

            // 取得データ表示
            this.tNedit_BLGoodsCode.SetInt(bLGoodsCdUMnt.BLGoodsCode);
            //_blGoodsCode = this.tNedit_BLGoodsCode.GetInt();//ADD 2012/09/21 袁磊 for redmine#32367 //DEL 2012/10/08 李亜博 for redmine#32367
            this.BLGoodsName_tEdit.DataText = bLGoodsCdUMnt.BLGoodsFullName;
            if (this.tNedit_BLGoodsCode.GetInt() != 0)
            {   // --- ADD 2012/10/08 李亜博 for redmine#32367 ---------->>>>>
                if (this.tNedit_BLGoodsCode.GetInt() != _blGoodsCode)
                {
                    _blGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                    // --- ADD 2012/10/08 李亜博 for redmine#32367 ----------<<<<<

                    // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
                    BLGroupU bLGroupU;
                    GoodsGroupU goodsGroupU;
                    UserGdBdU userGdBdU;
                    GoodsAcs _goodsAcs = new GoodsAcs();
                    _goodsAcs.GetBLGoodsRelation(this.tNedit_BLGoodsCode.GetInt(), out bLGoodsCdUMnt, out bLGroupU, out goodsGroupU, out userGdBdU);
                    if (goodsGroupU != null)
                    {
                        this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
                        this.tEdit_GoodsMGroupName.Text = goodsGroupU.GoodsMGroupName;
                    }
                    // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<
                }//ADD 2012/10/08 李亜博 for redmine#32367
                tNedit_SupplierCd.Focus();
            }
        }
        //// 2008.08.22 修正 <<<<<<<<<<<<<<<<<<<<




        /// <summary>
        /// Control.Click イベント(SupplierGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 仕入先ガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 980035 金沢　貞義</br>
        /// <br>Date        : 2007.08.27</br>
        /// </remarks>
        private void SupplierGd_ultraButton_Click(object sender, EventArgs e)
        {
            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 得意先ガイド
            //Infragistics.Win.Misc.UltraButton _pushBtn = (Infragistics.Win.Misc.UltraButton)sender;
            //PMKHN04001UA customerSearchForm = new PMKHN04001UA(PMKHN04001UA.SEARCHMODE_SUPPLIER, PMKHN04001UA.EXECUTEMODE_GUIDE_ONLY);

            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect1);
            //customerSearchForm.ShowDialog(this);


            //// 2008.08.22 >>>>>>>>>>>>>>>>>>>>>>>>>>

            //Supplier supplier;
            //this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);
            //this.SettingSupplier(SupplierMode.Supplier1, supplier.SupplierCd);

            TNedit CodeCtrl = new TNedit();
            TEdit NameCtrl = new TEdit();

            CodeCtrl = this.tNedit_SupplierCd;
            NameCtrl = this.SupplierNm_tEdit;

            Supplier supplier;
            SupplierAcs supplierAcs = new SupplierAcs();

            int status = supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CodeCtrl.SetInt(supplier.SupplierCd);
                NameCtrl.DataText = supplier.SupplierNm1;
            }
            if (this.tNedit_SupplierCd.GetInt() != 0)
            {
                tNedit_SupplierLot.Focus();
            }
           // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            //// 2008.08.22 修正 <<<<<<<<<<<<<<<<<<<<
        }




        // DEL 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>得意先選択時発生イベント</summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        //private void CustomerSearchForm_CustomerSelect1(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
        //        if (customerInfo.SupplierDiv == 0)
        //        {
        //            TMsgDisp.Show(
        //                this,
        //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                this.Name,
        //                "得意先は選択出来ません。",
        //                status,
        //                MessageBoxButtons.OK);
        //            return;
        //        }
        //        // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
        //            //"選択した得意先は既に削除されています。",
        //            "選択した仕入先は既に削除されています。",
        //            // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //    else
        //    {
        //        TMsgDisp.Show(this,
        //                      emErrorLevel.ERR_LEVEL_STOPDISP,
        //                      this.Name,
        //                      // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
        //                      //"得意先情報の取得に失敗しました。",
        //                      "仕入先情報の取得に失敗しました。",
        //                      // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
        //                      status,
        //                      MessageBoxButtons.OK);

        //        return;
        //    }

        //    this.SupplierCd1_tNedit.Text = customerInfo.CustomerCode.ToString();
        //    this.SupplierNm1_tEdit.Text = customerInfo.Name;
        //}

        //private void CustomerSearchForm_CustomerSelect2(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
        //        if (customerInfo.SupplierDiv == 0)
        //        {
        //            TMsgDisp.Show(
        //                this,
        //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                this.Name,
        //                "得意先は選択出来ません。",
        //                status,
        //                MessageBoxButtons.OK);
        //            return;
        //        }
        //        // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
        //            //"選択した得意先は既に削除されています。",
        //            "選択した仕入先は既に削除されています。",
        //            // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //    else
        //    {
        //        TMsgDisp.Show(this,
        //                      emErrorLevel.ERR_LEVEL_STOPDISP,
        //                      this.Name,
        //                      // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
        //                      //"得意先情報の取得に失敗しました。",
        //                      "仕入先情報の取得に失敗しました。",
        //                      // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
        //                      status,
        //                      MessageBoxButtons.OK);

        //        return;
        //    }

        //    this.SupplierCd2_tNedit.Text = customerInfo.CustomerCode.ToString();
        //    this.SupplierNm2_tEdit.Text = customerInfo.Name;
        //}

        //private void CustomerSearchForm_CustomerSelect3(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
        //        if (customerInfo.SupplierDiv == 0)
        //        {
        //            TMsgDisp.Show(
        //                this,
        //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                this.Name,
        //                "得意先は選択出来ません。",
        //                status,
        //                MessageBoxButtons.OK);
        //            return;
        //        }
        //        // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
        //            //"選択した得意先は既に削除されています。",
        //            "選択した仕入先は既に削除されています。",
        //            // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //    else
        //    {
        //        TMsgDisp.Show(this,
        //                      emErrorLevel.ERR_LEVEL_STOPDISP,
        //                      this.Name,
        //                      // 2008.02.28 修正 >>>>>>>>>>>>>>>>>>>>
        //                      //"得意先情報の取得に失敗しました。",
        //                      "仕入先情報の取得に失敗しました。",
        //                      // 2008.02.28 修正 <<<<<<<<<<<<<<<<<<<<
        //                      status,
        //                      MessageBoxButtons.OK);

        //        return;
        //    }

        //    this.SupplierCd3_tNedit.Text = customerInfo.CustomerCode.ToString();
        //    this.SupplierNm3_tEdit.Text = customerInfo.Name;
        //}
        // DEL 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        # endregion

		//----- ueno add ---------- start 2008.03.31
		/// <summary>
		/// tEdit_SectionCodeAllowZero_BeforeEnterEditMode
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note        : コントロールが編集モードに入る前に発生します。</br>
		/// <br>Programmer  : 30167 上野　弘貴</br>
		/// <br>Date        : 2008.03.31</br>
		/// </remarks>
		private void tEdit_SectionCodeAllowZero_BeforeEnterEditMode(object sender, CancelEventArgs e)
		{
			// ChangeFocusイベント一時停止
			this.tArrowKeyControl1.ChangeFocus -= this.tRetKeyControl1_ChangeFocus;

			// 先頭のゼロ詰めを削除
			this.tEdit_SectionCodeAllowZero.Text = GetZeroPadCanceledTextProc(this.tEdit_SectionCodeAllowZero.Text);

			// ChangeFocusイベント再開
			this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tRetKeyControl1_ChangeFocus);
		}
		//----- ueno add ---------- end 2008.03.31

        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 仕入先情報設定処理
        /// </summary>
        /// <param name="supplierMode">仕入先コンポ指定</param>
        private int SettingSupplier(SupplierMode supplierMode)
        {
            TNedit CodeCtrl = new TNedit();

            switch (supplierMode)
            {
                case SupplierMode.Supplier1:
                    CodeCtrl = this.tNedit_SupplierCd;
                    break;
            }

            return this.SettingSupplier(supplierMode, CodeCtrl.GetInt());
        }

        /// <summary>
        /// 設定種別変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 設定種別が変更されたときに発生します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// <br>Update Note: 2012/10/08 李亜博 </br>
        ///	<br>		   ・redmine#32367 障害一覧の対応</br>
        /// </remarks>
        private void SetKind_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            ////拠点＋メーカー＋BLコード
            //if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONBLMAKER)
            //   {
            //       this.tNedit_GoodsMakerCd.Enabled = true;
            //       this.tEdit_GoodsNo.Enabled = false;
            //       this.GoodsMakerGuide_Button.Enabled = true;  // 商品メーカーガイドボタン
            //       this.tNedit_BLGoodsCode.Enabled = true;
            //       this.BLGoodsGuide_Button.Enabled = true;
            //   }

               //拠点＋メーカー
               if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMAKER)
               {
                   this.tNedit_GoodsMakerCd.Enabled = true;
                   this.tEdit_GoodsNo.Enabled = false;
                   this.GoodsMakerGuide_Button.Enabled = true;  // 商品メーカーガイドボタン
                   this.tNedit_BLGoodsCode.Enabled = false;
                   this.BLGoodsGuide_Button.Enabled = false;
                   // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
                   this.tNedit_GoodsMGroup.Enabled = false;
                   this.GoodsMGroupGuidButton.Enabled = false;
                   // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<
               }

               //拠点＋品番
               //else //DEL 2012/09/21 袁磊 for redmine#32367
               else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONGOODS) //ADD 2012/09/21 袁磊 for redmine#32367
               {
                   this.tNedit_GoodsMakerCd.Enabled = true;
                   this.tEdit_GoodsNo.Enabled = true;
                   this.GoodsMakerGuide_Button.Enabled = false;  // 商品メーカーガイドボタン
                   this.tNedit_GoodsMakerCd.Enabled = false;
                   this.tNedit_BLGoodsCode.Enabled = false;
                   this.BLGoodsGuide_Button.Enabled = false;
                   // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
                   this.tNedit_GoodsMGroup.Enabled = false;
                   this.GoodsMGroupGuidButton.Enabled = false;
                   // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<
               }
               // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
               //拠点＋中分類＋メーカー＋BLコード
               else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKERBL)
               {
                   this.tNedit_GoodsMakerCd.Enabled = true;
                   this.tEdit_GoodsNo.Enabled = false;
                   this.GoodsMakerGuide_Button.Enabled = true;  // 商品メーカーガイドボタン
                   this.tNedit_BLGoodsCode.Enabled = true;
                   this.BLGoodsGuide_Button.Enabled = true;
                   this.tNedit_GoodsMGroup.Enabled = false;
                   this.GoodsMGroupGuidButton.Enabled = false;
               }
               //拠点＋中分類＋メーカー
               else if (this.SetKind_tComboEditor.Text == SETKIND_SECTIONMGROUPMAKER)
               {
                   this.tNedit_GoodsMakerCd.Enabled = true;
                   this.tEdit_GoodsNo.Enabled = false;
                   this.GoodsMakerGuide_Button.Enabled = true;  // 商品メーカーガイドボタン
                   this.tNedit_BLGoodsCode.Enabled = false;
                   this.BLGoodsGuide_Button.Enabled = false;
                   this.tNedit_GoodsMGroup.Enabled = true;
                   this.GoodsMGroupGuidButton.Enabled = true;
               }
               // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<
               if (this._mainOfficeFuncFlag == 1)
               {
                   this.tEdit_SectionCodeAllowZero.Clear();
                   this.SectionName_tEdit.Clear();
               }
               this.tNedit_GoodsMakerCd.Clear();
               this.GoodsMakerName_tEdit.Clear();
               this.tEdit_GoodsNo.Clear();
               this.GoodsName_tEdit.Clear();
               this.tNedit_BLGoodsCode.Clear();
               this.BLGoodsName_tEdit.Clear();
               this.tNedit_SupplierCd.Clear();
               this.SupplierNm_tEdit.Clear();
               this.tNedit_SupplierLot.Clear();
               this.tNedit_GoodsMGroup.Clear();
               this.tEdit_GoodsMGroupName.Clear();
               _blGoodsCode = 0;//ADD 2012/10/08 李亜博 for redmine#32367 
        }
        
        /// <summary>
        /// 仕入先情報設定処理
        /// </summary>
        /// <param name="supplierMode">仕入先コンポ指定</param>
        /// <param name="supplierCode">仕入先コード</param>
        private int SettingSupplier(SupplierMode supplierMode, int supplierCode)
        {
            TNedit CodeCtrl = new TNedit();
            TEdit NameCtrl = new TEdit();
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            switch (supplierMode)
            {
                case SupplierMode.Supplier1:
                    CodeCtrl = this.tNedit_SupplierCd;
                    NameCtrl = this.SupplierNm_tEdit;
                    break;

            }

            if (CodeCtrl.GetInt() != 0)
            {
                Supplier supplier;
                SupplierAcs supplierAcs = new SupplierAcs();

                status = supplierAcs.Read(out supplier, this._enterpriseCode, supplierCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    CodeCtrl.SetInt(supplier.SupplierCd);
                    NameCtrl.DataText = supplier.SupplierSnm;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "選択した仕入先は既に削除されています。",
                        status,
                        MessageBoxButtons.OK);
                    CodeCtrl.Clear();
                    NameCtrl.Clear();
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "仕入先情報の取得に失敗しました。",
                        status,
                        MessageBoxButtons.OK);
                    //CodeCtrl.Clear();
                    NameCtrl.Clear();
                }
            }
            else
            {
                CodeCtrl.Clear();
               NameCtrl.Clear();
            }

            return status;

        }
        /// <summary>
        /// 商品中分類読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品中分類一覧を読み込みます。</br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2009/01/09</br>
        /// </remarks>
        private void ReadGoodsMGroup()
        {
            this._goodsGroupDic = new Dictionary<int, GoodsGroupU>();

            ArrayList retList;

            int status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (GoodsGroupU goodsGroupU in retList)
                {
                    if (goodsGroupU.LogicalDeleteCode == 0)
                    {
                        this._goodsGroupDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                    }
                }
            }

            return;
        }


        private void tNedit_GoodsMakerCd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tNedit_BLGoodsCode_ValueChanged(object sender, EventArgs e)
        {

        }


        // ADD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        /// <br>Update Note : 2010/12/03 曹文傑</br>
        ///	<br>			・拠点＋メーカー新規登録時の不具合修正</br>
        /// <br>Update Note : 2012/10/08 李亜博 </br>
        ///	<br>			・redmine#32367 障害一覧の対応</br>
        private bool ModeChangeProc()
        {
            string msg = "入力されたコードの商品管理情報マスタ情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string sectionCd = tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0');
            //// 商品中分類コード
            //int goodsMGroup = tNedit_GoodsMGroup.GetInt();
            // メーカーコード
            int makerCd = tNedit_GoodsMakerCd.GetInt();
            //// BLコード
            //int blGoodsCode = tNedit_BLGoodsCode.GetInt();
            // 品番
            string goodsNo = tEdit_GoodsNo.Text.TrimEnd();
            // ---ADD 2010/12/03----------->>>>>
            // 商品中分類コード
            int goodsMGroup = tNedit_GoodsMGroup.GetInt();
            // BLコード
            int blGoodsCode = tNedit_BLGoodsCode.GetInt();
            // ---ADD 2010/12/03-----------<<<<<

            for (int i = 0; i < this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GoodsMngAcs.SECTIONCODE_TITLE];
                //int dsGoodsMGroup = (int)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GoodsMngAcs.GOODSMGROUP_TITLE];
                int dsMakerCd = (int)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GoodsMngAcs.GOODSMAKERCD_TITLE];
                //int dsBLGoodsCode = (int)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GoodsMngAcs.BLGOODSCODE_TITLE];
                string dsGoodsNo = (string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GoodsMngAcs.GOODSNO_TITLE];
                // ---UPD 2010/12/03----------->>>>>
                //if ((sectionCd.Equals(dsSecCd.TrimEnd().PadLeft(2, '0'))) &&
                //    //(goodsMGroup == dsGoodsMGroup) &&
                //    (makerCd == dsMakerCd) &&
                //    //(blGoodsCode == dsBLGoodsCode) &&
                //    (goodsNo.Equals(dsGoodsNo.TrimEnd())))

                // 商品中分類コード
                int dsGoodsMGroup = (int)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GoodsMngAcs.GOODSMGROUP_TITLE];
                // BLコード
                int dsBLGoodsCode = (int)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GoodsMngAcs.BLGOODSCODE_TITLE];
                if ((sectionCd.Equals(dsSecCd.TrimEnd().PadLeft(2, '0'))) &&
                    (goodsMGroup == dsGoodsMGroup) &&
                    (makerCd == dsMakerCd) &&
                    (blGoodsCode == dsBLGoodsCode) &&
                    (goodsNo.Equals(dsGoodsNo.TrimEnd())))
                // ---UPD 2010/12/03-----------<<<<<
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[i][GoodsMngAcs.DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの商品管理情報マスタ情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 拠点コード、商品中分類コード、メーカーコード、BLコード、品番のクリア
                        tEdit_SectionCodeAllowZero.Clear();
                        SectionName_tEdit.Clear();
                        tNedit_GoodsMGroup.Clear();
                        tEdit_GoodsMGroupName.Clear();
                        tNedit_GoodsMakerCd.Clear();
                        GoodsMakerName_tEdit.Clear();
                        tNedit_BLGoodsCode.Clear();
                        BLGoodsName_tEdit.Clear();
                        tEdit_GoodsNo.Clear();
                        GoodsName_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードの商品管理情報マスタ情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        msg,   // 表示するメッセージ
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
                                // 拠点コード、商品中分類コード、メーカーコード、BLコード、品番のクリア
                                tEdit_SectionCodeAllowZero.Clear();
                                SectionName_tEdit.Clear();
                                tNedit_GoodsMGroup.Clear();
                                tEdit_GoodsMGroupName.Clear();
                                tNedit_GoodsMakerCd.Clear();
                                GoodsMakerName_tEdit.Clear();
                                tNedit_BLGoodsCode.Clear();
                                BLGoodsName_tEdit.Clear();
                                tEdit_GoodsNo.Clear();
                                GoodsName_tEdit.Clear();
                                _blGoodsCode = 0;//ADD 2012/10/08 李亜博 for redmine#32367  
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.27 30413 犬飼 新規モードからモード変更対応 <<<<<<END

        // --- ADD 2012/09/21 袁磊 for redmine#32367 ---------->>>>>
        /// <summary>
        /// Control.Click イベント(GoodsMGroupGuidButton)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2012/09/21 袁磊 for redmine#32367</br>
        ///	<br>			・拠点＋中分類＋メーカー＋BLコードと拠点＋中分類＋メーカーの追加</br>
        private void GoodsMGroupGuidButton_Click(object sender, EventArgs e)
        {
            if (this._goodsGroupUAcs == null)
            {
                this._goodsGroupUAcs = new GoodsGroupUAcs();
            }
            GoodsGroupU goodsGroupU;
            //中分類ガイド起動
            int status = _goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);
            if (status != 0) return;

            // 取得データ表示
            this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
            this.tEdit_GoodsMGroupName.DataText = goodsGroupU.GoodsMGroupName;
            if (this.tNedit_GoodsMGroup.GetInt() != 0)
            {
                tNedit_SupplierCd.Focus();
            }
        }
        // --- ADD 2012/09/21 袁磊 for redmine#32367 ----------<<<<<
    }
}
