using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller.Facade;
// ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- >>>>
using Broadleaf.Application.Resources;
using System.IO;
// ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- <<<<

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 仕入入力フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入入力のフォームクラスです。</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2008.05.21</br>
	/// <br></br>
	/// <br>UpDate</br>
    /// <br>2008.05.21 men 新規作成(DC.NSから流用)</br>
    /// <br>2009.03.25 20056 對馬 大輔 MANTIS[0010336] 修正、複写、計上時に再計算を行う</br>
    /// <br>                           MANTIS[0010871] 現在庫数がｾﾞﾛになる場合、倉庫あり→ｾﾞﾛ表示　倉庫なし→ｾﾞﾛ表示なし</br>
    /// <br>                           MANTIS[0010905] ｼｮｰﾄｶｯﾄ変更 赤伝A→R 返品H→Y 伝票複写Q→P</br>
    /// <br>                           MANTIS[0010905] ﾌｯﾀ部でF10の場合のみ、保存処理へ。その他はｸﾞﾙｰﾌﾟ移動</br>
    /// <br>                           MANTIS[0012624] 最新情報ボタン追加</br>
    /// <br>                           MANTIS[0012680] 参照ﾓｰﾄﾞから「新規(F9)」すると拠点、部門が入力不可のままになる対応</br>
    /// <br>                           MANTIS[0013004] ESCで終了処理追加</br>
    /// <br>2009.04.02 20056 對馬 大輔 MANTIS[0013035] 最終項目でEnter時は保存処理対応</br>
    /// <br>2009.06.17 21024 佐々木 健 MANTIS[0013495] 請求転嫁の仕入先で、仕入金額でEnterを押した場合に確定にならない現象の修正</br>
    /// <br>                           MANTIS[0013506] 合計入力で金額未入力時、合計金額が未入力というメッセージになるように修正</br>
    /// <br>2009.11.13 30434 工藤 恵優 MANTIS[0013983] 入力区分の保持機能を追加</br>
    /// <br>2010.01.06 30434 工藤 恵優 MANTIS[0013956] 仕入先名は略称とする</br>
    /// <br>2010/10/27 李占川 消費税変更時に不正にセットされる障害の修正</br>
    /// <br>2010/11/02 高峰 消費税変更時の障害の修正</br>
    /// <br>2010/12/03 yangmj 障害改良対応</br>
    /// <br>2011/02/09 田建委 Redmine18823　障害対応１２月分 仕入伝票入力</br>
    /// <br>Update Note: 2011/07/25 譚洪 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応</br>
    /// <br>2011/07/21 wangf  障害改良対応連番824</br>
    /// <br>Update Note: 2011/08/03 wangf</br>
    /// <br>             Redmine#23375</br>
    /// <br>             伝票番号欄にスペースだけ入力後、未入力チェックの対象でメッセージ表示を修正する</br>
    /// <br>Update Note: 2011/08/18 XUJS</br>
    /// <br>             Redmine#23737</br>
    /// <br>             仕入伝票入力で、今回締処理中のため登録できませんのを修正する</br>
    /// <br>2011/08/09 qijh SCM対応 - 拠点管理(10704767-00)</br>
    /// <br>2011/11/30 gezh redmine#8383</br>
    /// <br>Update Note: 2011/12/15 tianjw</br>
    /// <br>             Redmine#27390 拠点管理/売上日のチェック</br>
    /// <br>Update Note : 2011/12/19 tianjw</br>
    /// <br>              Redmine#27390 拠点管理/売上日のチェック</br>
    /// <br>Update Note : 2011/12/27 陳建明</br>
    /// <br>管理番号    : 10707327-00 2012/01/25配信分</br>
    /// <br>              redmine#27374 仕入伝票入力/締済のチェックの対応</br>
    /// <br>Update Note : 2012/03/13 鄧潘ハン</br>
    /// <br>管理番号    : 10707327-00 2012/03/28配信分</br>
    /// <br>              Redmine#27374 仕入伝票入力でガイドから呼出した場合削除でエラーになる件の対応</br>
    /// <br>Update Note : 2012/10/15 田建委</br>
    /// <br>管理番号    : 10801804-00、2012/11/14配信分</br>
    /// <br>              Redmine#32862 価格変更した明細、色を変えるように修正</br>
    /// <br>Update Note : 2013/01/09 張曼</br>
    /// <br>管理番号    : 10806793-00、2013/03/13配信分</br>
    /// <br>              Redmine#33821 仕入入力/入荷日の制御の対応</br>
    /// <br>Update Note : 2013/01/08 鄭慕鈞</br>
    /// <br>管理番号    : 10801804-00 2013/03/13配信分</br>
    /// <br>            : redmine#31984 仕入伝票入力の操作便利の対応</br>
    /// <br>Update Note : 2013/02/15 脇田　靖之</br>
    /// <br>管理番号    : 10801804-00 2013/03/13配信分</br>
    /// <br>            : redmine#31984 追加対応</br>
    /// <br>            : 保存処理後の画面制御を統一</br>
    /// <br>Update Note: 2014/01/07 譚洪</br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>           : Redmine#41771 仕入伝票入力消費税8%増税対応</br>
    /// <br>Update Note: 2014/01/31 吉岡</br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>           : Redmine#41771 システムテスト障害№12 仕入伝票入力 入荷返品 </br>
    /// <br>Update Note : 2014/09/01 衛忠明</br>
    /// <br>管理番号    : 11070149-00</br>
    /// <br>            : redmine　#43374 追加対応</br>
    /// <br>            : 仕入伝票入力(保存後ロゴ表示制御)</br>
    /// <br>Update Note : 2014/11/03 譚洪</br>
    /// <br>管理番号    : 11070149-00</br>
    /// <br>            : redmine　#43864 追加対応</br>
    /// <br>            : ハンドルエラーが出る障害の修正</br>
    /// <br>Update Note : 2014/12/08 譚洪</br>
    /// <br>管理番号    : 11070149-00</br>
    /// <br>            : redmine　#43864 追加対応</br>
    /// <br>            : Timer同時処理の障害対応</br>
    /// <br>Update Note: 2015/02/04 譚洪</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>           : 仕掛一覧№2200 redmine #43864 追加対応</br>
    /// <br>           : ハンドルエラーが出る障害の再修正</br>
    /// <br>Update Note: 2015/02/24 河原林　一生</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>           : 仕掛一覧№2200 保存完了ダイアログのインスタンス解放漏れ修正</br>
    /// <br>Update Note: 2015/02/25 河原林　一生</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>           : 仕掛一覧№2200 保存完了後に強制的にGCを実行</br>
    /// <br>Update Note: 2015/03/25 黄興貴</br>
    /// <br>管理番号   : 11175104-00</br>
    /// <br>           : Redmine#45073 宮田自動車商会 
    /// <br>           : 仕入伝票入力で仕入伝票番号が空白のデータが作成されるの不具合の対応</br>
    /// <br>Update Note: 2015/04/01 黄興貴</br>
    /// <br>管理番号   : 11175104-00</br>
    /// <br>           : Redmine#45073 宮田自動車商会 障害No.179</br>
    /// <br>           : 仕入伝票番号の登録前チェックでNGになった際、入力したスペースが削除されないの不具合の対応</br>
    /// <br>Update Note: 2015/04/08 30757 佐々木貴英</br>
    /// <br>管理番号   : 11175104-00</br>
    /// <br>           : 仕掛№2678仕入伝票入力-仕入伝票番号空白入力時処理対応(Redmine#45073)</br>
    /// <br>           : 仕入伝票番号の未入力（または空白のみ文字列が設定）チェックを保存時のみとする対応</br>
    /// <br>Update Note: 2015/04/16 黄興貴</br>
    /// <br>管理番号   : 11100008-00</br>
    /// <br>           : Redmine#45230 宮田自動車商会 
    /// <br>           : 仕入伝票入力で仕入伝票番号が欠けるの不具合の対応</br>
    /// <br>Update Note: 2015/05/20 黄興貴</br>
    /// <br>管理番号   : 11100008-00</br>
    /// <br>           : Redmine#45230 宮田自動車商会 
    /// <br>           : 仕入伝票番号が欠けるの不具合障害の対応</br>
    /// <br>Update Note: 2020/02/24 田建委</br>
    /// <br>管理番号   : 11570208-00</br>
    /// <br>           : PMKOBETSU-2912消費税税率機能追加対応</br>
    /// <br>Update Note: 2020/06/22 陳艶丹</br>
    /// <br>管理番号   : 11670231-00</br>
    /// <br>           : PMKOBETSU-4017 東邦車両サービス(仕入データテキスト入力)</br>
    /// </remarks>
    public partial class MAKON01110UA : Form
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region ■Constructors
		/// <summary>
		/// 仕入入力フォームクラス デフォルトコンストラクタ
		/// </summary>
		public MAKON01110UA()
		{
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "開始");

            //// ここでスレッドをスタートすると、Vistaで2回目に起動するとEnter,Arrowキーがきかなくなる
            //// 初期データ取得スレッド
            //this._stockSlipInputInitDataAcs = StockSlipInputInitDataAcs.GetInstance();
            //this._readInitialThread = new Thread(this.InitialReadThread);
            //StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "InitialReadThread 開始");
            //this._readInitialThread.Start();

            //// 初期データ取得スレッド２
            //this._readInitialThread2 = new Thread(this.InitialReadThread2);
            //StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "InitialReadThread2 開始");
            //this._readInitialThread2.Start();
            //StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "InitializeComponent");

            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "InitializeComponent");
            InitializeComponent();

            // 初期データ取得スレッド
            this._stockSlipInputInitDataAcs = StockSlipInputInitDataAcs.GetInstance();
            this._readInitialThread = new Thread(this.InitialReadThread);
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "InitialReadThread 開始");
            this._readInitialThread.Start();

#if false
            // 初期データ取得スレッド２
            this._readInitialThread2 = new Thread(this.InitialReadThread2);
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "InitialReadThread2 開始");
            this._readInitialThread2.Start();
#endif

            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "変数初期化");

			// 変数初期化
            //this._OLEScannerController = new OLEScannerController();
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "MAKON01110UB インスタンス化");
            this._stockSlipDetailInput = new MAKON01110UB(MyOpeCtrl);

			//this._salesTempInput = new MAKON01110UH();

            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "ControlScreenSkin インスタンス化");
            this._controlScreenSkin = new ControlScreenSkin();

			//this._stockSlipDetailInput.OLEScannerControllerObject = this._OLEScannerController;

            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "StockSlipInputAcs インスタンス取得");
            this._stockSlipInputAcs = StockSlipInputAcs.GetInstance();

			//this._salesTempInputAcs = SalesTempInputAcs.GetInstance();

            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "StockSlipInputConstructionAcs インスタンス取得");
            this._stockInputConstructionAcs = StockSlipInputConstructionAcs.GetInstance();
            this._stockInputConstructionAcsLog = StockSlipInputConstructionAcsLog.GetInstance(); // ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御)

            this._stockSlipInputInitData = new StockSlipInputInitData();

            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "デリゲート設定");
            this._stockInputConstructionAcs.DataChanged += new EventHandler(this.StockInputConstructionAcs_DataChanged);
            this._stockInputConstructionAcsLog.DataChanged += new EventHandler(this.StockInputConstructionAcsLog_DataChanged); // ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御)
			this._stockSlipDetailInput.GridKeyDownTopRow += new EventHandler(this.StockSlipDetailInput_GridKeyDownTopRow);
			this._stockSlipDetailInput.GridKeyDownButtomRow += new EventHandler(this.StockSlipDetailInput_GridKeyDownButtomRow);
            this._stockSlipDetailInput.SupplierSelect += new EventHandler(this.StockDetailInput_SupplierSelect);
			this._stockSlipDetailInput.StockPriceChanged += new EventHandler(this.StockSlipDetailInput_StockPriceChanged);
			this._stockSlipDetailInput.StatusBarMessageSetting += new MAKON01110UB.SettingStatusBarMessageEventHandler(this.StockSlipDetailInput_StatusBarMessageSetting);
			this._stockSlipDetailInput.FocusSetting += new MAKON01110UB.SettingFocusEventHandler(this.StockSlipDetailInput_FocusSetting);
            this._stockSlipDetailInput.SettingFooter += new MAKON01110UB.SettingFooterEventHandler(this.SlipMemoInfoFormSetting);
			this._stockSlipDetailInput.SetToolbarButton += new MAKON01110UB.SettingToolbarEventHandler(this.SettingGuideButtonTool_Detail);
			this._stockSlipDetailInput.SetToolbarButton += new MAKON01110UB.SettingToolbarEventHandler(this.SettingToolBarButtonEnabled_Detail);
			
			//this._salesTempInput.GetDetailControl += new MAKON01110UH.GetDetailControlEventHandler(this.GetDetailComponent);

			this._stockSlipInputAcs.DataChanged += new EventHandler(this.StockSlipInputAcs_DataChanged);
			//this._salesTempInput.SalesTempCustomerChange += new MAKON01110UH.SalesTempCustomerChangeEventHandler(this._stockSlipDetailInput.ActiveRowCustomerInfoSetting);
			//this._salesTempInput.uiSetControl1.ChangeFocus += new ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
			//this.SupplierChanged += new SupplierChangeEventHandler(this._stockSlipInputAcs.SalesTempSupplierSetting);

            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "その他クラスのインスタンス化");

			//this._supplierAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;
			this._imageList16 = IconResourceManagement.ImageList16;

            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "ツール取得");
            this._loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[ctTOOLBAR_LABELTOOL_LOGINTITLE_KEY];
			this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[ctTOOLBAR_LABELTOOL_LOGINNAME_KEY];
			this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_CLOSE_KEY];
			this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_SAVE_KEY];
			this._retryButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_RETRY_KEY];
			this._newButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_NEW_KEY];
			this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_GUIDE_KEY];
			this._setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_SETUP_KEY];
			this._redSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_REDSLIP_KEY];
			this._returnSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_RETURNSLIP_KEY];
			this._arrivalAppropriateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_ARRIVALAPPROPRIATE_KEY];
			this._loginSectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_LABELTOOL_LOGINSECTIONTITLE_KEY];
			this._loginSectionNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_LABELTOOL_LOGINSECTIONNAME_KEY];
			this._readSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_READSLIP_KEY];
			this._deleteSlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_DELETESLIP_KEY];
			this._copySlipButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_COPYSLIP_KEY];
			this._orderReferenceButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_ORDERREFERENCE_KEY];
			this._stockReferenceButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_STOCKREFERENCE_KEY];
			this._salesSlipEntryButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_SALESSLIPENTRY_KEY];
			this._forwardButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_FORWARD_KEY];
			this._returnButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_RETURN_KEY];
            this._reNewalButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_RENEWAL_KEY]; // 2009.03.25
            this._taxRateSetButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_TAXRATESET_KEY];// ADD 田建委 2020/02/24 PMKOBETSU-2912の対応
			// ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- >>>>
            this._taxtDataInputButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[ctTOOLBAR_BUTTONTOOL_TEXTDATAINPUT_KEY];

            // 仕入データテキスト入力オプション判定
            PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_StockTextInPut);

            // 仕入データテキスト入力オプションが有効
            if (ps == PurchaseStatus.Contract)
            {
                // 仕入データテキスト入力オプションあり
                this._taxtDataInputButton.SharedProps.Visible = true;
            }
            // 仕入データテキスト入力オプションが無効
            else
            {
                // 仕入データテキスト入力オプションなし
                this._taxtDataInputButton.SharedProps.Visible = false;
            }
            // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- <<<<<
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "その他変数初期化");

			this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
			this._loginSectionNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.BelongSectionName;

			this._guideEnableControlDictionary.Add(this.tEdit_SectionCode.Name, ctGUIDE_NAME_SectionGuide);
			this._guideEnableControlDictionary.Add(this.uButton_SectionGuide.Name, ctGUIDE_NAME_SectionGuide);
			this._guideEnableControlDictionary.Add(this.tNedit_SubSectionCode.Name, ctGUIDE_NAME_SubSectionGuide);
			this._guideEnableControlDictionary.Add(this.uButton_SubSectionGuide.Name, ctGUIDE_NAME_SubSectionGuide);
			this._guideEnableControlDictionary.Add(this.tEdit_StockAgentCode.Name, ctGUIDE_NAME_EmployeeGuide);
			this._guideEnableControlDictionary.Add(this.uButton_EmployeeGuide.Name, ctGUIDE_NAME_EmployeeGuide);
			this._guideEnableControlDictionary.Add(this.tNedit_SupplierCd.Name, ctGUIDE_NAME_SupplierGuide);
			this._guideEnableControlDictionary.Add(this.uButton_SupplierGuide.Name, ctGUIDE_NAME_SupplierGuide);
			this._guideEnableControlDictionary.Add(this.tEdit_WarehouseCode.Name, ctGUIDE_NAME_WarehouseGuide);
			this._guideEnableControlDictionary.Add(this.uButton_WarehouseGuide.Name, ctGUIDE_NAME_WarehouseGuide);
			this._guideEnableControlDictionary.Add(this.tNedit_SupplierSlipNo.Name, ctGUIDE_NAME_SupplierSlipGuide);
			this._guideEnableControlDictionary.Add(this.uButton_SupplierSlipGuide.Name, ctGUIDE_NAME_SupplierSlipGuide);
            // DEL 2011/11/30 gezh redmine#8383 --------------------------------------------------------------->>>>>
            //this._guideEnableControlDictionary.Add(this.tEdit_SupplierSlipNote1.Name, ctGUIDE_NAME_SupplierSlipNote1Guide);
            //this._guideEnableControlDictionary.Add(this.tEdit_SupplierSlipNote2.Name, ctGUIDE_NAME_SupplierSlipNote2Guide);
            // DEL 2011/11/30 gezh redmine#8383 ---------------------------------------------------------------<<<<<
            // ADD 2011/11/30 gezh redmine#8383 --------------------------------------------------------------->>>>>
            this._guideEnableControlDictionary.Add(this.tNedit_SupplierSlipNote1.Name, ctGUIDE_NAME_SupplierSlipNote1Guide);
            this._guideEnableControlDictionary.Add(this.tNedit_SupplierSlipNote2.Name, ctGUIDE_NAME_SupplierSlipNote2Guide);
            // ADD 2011/11/30 gezh redmine#8383 ---------------------------------------------------------------<<<<<
            this._guideEnableControlDictionary.Add(this.tEdit_RetGoodsReason.Name, ctGUIDE_NAME_ReturnReasonGuide);

			this._guideEnableExceptControlDictionary.Add(this._stockSlipDetailInput.Name, this._stockSlipDetailInput);
			this._guideEnableExceptControlDictionary.Add(this._stockSlipDetailInput.uGrid_Details.Name, this._stockSlipDetailInput.uGrid_Details);
			this._guideEnableExceptControlDictionary.Add(this._stockSlipDetailInput.uButton_Guide.Name, this._stockSlipDetailInput.uButton_Guide);

			int controlIndexForword = 0;
			this._controlIndexForwordDictionary.Add(this.tEdit_SectionCode.Name, controlIndexForword++);
			this._controlIndexForwordDictionary.Add(this.tNedit_SubSectionCode.Name, controlIndexForword++);
			this._controlIndexForwordDictionary.Add(this.tEdit_StockAgentCode.Name, controlIndexForword++);
			this._controlIndexForwordDictionary.Add(this.tNedit_SupplierCd.Name, controlIndexForword++);
			this._controlIndexForwordDictionary.Add(this.uButton_PaymentConfirmation.Name, controlIndexForword++);
			this._controlIndexForwordDictionary.Add(this.tEdit_WarehouseCode.Name, controlIndexForword++);
			this._controlIndexForwordDictionary.Add(this.tComboEditor_PriceCostUpdtDiv.Name, controlIndexForword++);
			this._controlIndexForwordDictionary.Add(this.tComboEditor_SupplierFormal.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tComboEditor_SupplierSlipCdDisplay.Name, controlIndexForword++);
			this._controlIndexForwordDictionary.Add(this.tComboEditor_SupplierSlipCd.Name, controlIndexForword++);
			this._controlIndexForwordDictionary.Add(this.tComboEditor_StockGoodsCd.Name, controlIndexForword++);
			this._controlIndexForwordDictionary.Add(this.tComboEditor_AccPayDivCd.Name, controlIndexForword++);
			this._controlIndexForwordDictionary.Add(this.tDateEdit_ArrivalGoodsDay.Name, controlIndexForword++);
			this._controlIndexForwordDictionary.Add(this.tDateEdit_StockDate.Name, controlIndexForword++);
			this._controlIndexForwordDictionary.Add(this.tEdit_PartySaleSlipNum.Name, controlIndexForword++);

			int controlIndexBack = 99;
			this._controlIndexBackDictionary.Add(this.tEdit_SectionCode.Name, controlIndexBack--);
			this._controlIndexBackDictionary.Add(this.tNedit_SubSectionCode.Name, controlIndexBack--); 
			this._controlIndexBackDictionary.Add(this.tEdit_StockAgentCode.Name, controlIndexBack--);
			this._controlIndexBackDictionary.Add(this.tNedit_SupplierCd.Name, controlIndexBack--);
			this._controlIndexBackDictionary.Add(this.tEdit_WarehouseCode.Name, controlIndexBack--);
			this._controlIndexBackDictionary.Add(this.uButton_PaymentConfirmation.Name, controlIndexForword--);
			this._controlIndexBackDictionary.Add(this.tComboEditor_PriceCostUpdtDiv.Name, controlIndexForword--);
			this._controlIndexBackDictionary.Add(this.tComboEditor_SupplierFormal.Name, controlIndexBack--);
			this._controlIndexBackDictionary.Add(this.tComboEditor_SupplierSlipCdDisplay.Name, controlIndexBack--);
			this._controlIndexBackDictionary.Add(this.tComboEditor_SupplierSlipCd.Name, controlIndexBack--);
			this._controlIndexBackDictionary.Add(this.tComboEditor_StockGoodsCd.Name, controlIndexBack--);
			this._controlIndexBackDictionary.Add(this.tComboEditor_AccPayDivCd.Name, controlIndexBack--);
			this._controlIndexBackDictionary.Add(this.tDateEdit_ArrivalGoodsDay.Name, controlIndexBack--);
			this._controlIndexBackDictionary.Add(this.tDateEdit_StockDate.Name, controlIndexBack--);
			this._controlIndexBackDictionary.Add(this.tEdit_PartySaleSlipNum.Name, controlIndexBack--);

            // ヘッダ項目Dictionary作成
			this._headerItemsDictionary.Add(this.uLabel_SectionTitle.Text.Trim(), this.tEdit_SectionCode);
			this._headerItemsDictionary.Add(this.uLabel_SubSectionTitle.Text.Trim(), this.tNedit_SubSectionCode);
			this._headerItemsDictionary.Add(this.uLabel_StockAgentTitle.Text.Trim(), this.tEdit_StockAgentCode);
			this._headerItemsDictionary.Add(this.uLabel_SupplierTitle.Text.Trim(), this.tNedit_SupplierCd);
			this._headerItemsDictionary.Add(this.uButton_PaymentConfirmation.Text.Trim(), this.uButton_PaymentConfirmation);
            this._headerItemsDictionary.Add(this.uLabel_WarehouseTitle.Text.Trim(), this.tEdit_WarehouseCode);
			this._headerItemsDictionary.Add(this.uLabel_PriceCostUpdtDivTitle.Text.Trim(), this.tComboEditor_PriceCostUpdtDiv);
			this._headerItemsDictionary.Add(this.uLabel_SupplierFormalTitle.Text.Trim(), this.tComboEditor_SupplierFormal);
			this._headerItemsDictionary.Add(this.uLabel_SupplierSlipCdDisplayTitle.Text.Trim(), this.tComboEditor_SupplierSlipCdDisplay);
			this._headerItemsDictionary.Add(this.uLabel_StockGoodsCdTitle.Text.Trim(), this.tComboEditor_StockGoodsCd);
			this._headerItemsDictionary.Add(this.uLabel_ArrivalGoodsDayTitle.Text.Trim(), this.tDateEdit_ArrivalGoodsDay);
			this._headerItemsDictionary.Add(this.uLabel_StockDateTitle.Text.Trim(), this.tDateEdit_StockDate);
			this._headerItemsDictionary.Add(this.uLabel_PartySaleSlipNumTitle.Text.Trim(), this.tEdit_PartySaleSlipNum);

			this._stockInputConstructionAcs.HeaderItemsDictionary = this._headerItemsDictionary;

            // 2009.04.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            controlIndexForword = 0;
            this._controlIndexForwordDictionaryForFooter.Add(this.tNedit_SupplierSlipNote1.Name, controlIndexForword++);                      // 伝票備考番号１  // ADD 2011/11/30 gezh redmine#8383
            this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_SupplierSlipNote1.Name, controlIndexForword++);                       // 伝票備考１
            this._controlIndexForwordDictionaryForFooter.Add(this.uButton_SlipNote1.Name, controlIndexForword++);                     // 伝票備考１ガイドボタン
            this._controlIndexForwordDictionaryForFooter.Add(this.tNedit_SupplierSlipNote2.Name, controlIndexForword++);                      // 伝票備考番号2  // ADD 2011/11/30 gezh redmine#8383
            this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_SupplierSlipNote2.Name, controlIndexForword++);                      // 伝票備考２
            this._controlIndexForwordDictionaryForFooter.Add(this.uButton_SlipNote2.Name, controlIndexForword++);                    // 伝票備考２ガイドボタン
            this._controlIndexForwordDictionaryForFooter.Add(this.tEdit_RetGoodsReason.Name, controlIndexForword++);                      // 伝票備考３
            this._controlIndexForwordDictionaryForFooter.Add(this.uButton_RetGoodsReason.Name, controlIndexForword++);                    // 伝票備考３ガイドボタン
            this._controlIndexForwordDictionaryForFooter.Add(this.tNedit_StockTotalPrice.Name, controlIndexForword++);                 // 納入先コード
            this._controlIndexForwordDictionaryForFooter.Add(this.tNedit_StockPriceConsTaxTotal.Name, controlIndexForword++);                  // 納入先名称

            controlIndexBack = 99;
            this._controlIndexBackDictionaryForFooter.Add(this.tNedit_SupplierSlipNote1.Name, controlIndexBack--);                      // 伝票備考番号１  // ADD 2011/11/30 gezh redmine#8383
            this._controlIndexBackDictionaryForFooter.Add(this.tEdit_SupplierSlipNote1.Name, controlIndexBack--);                             // 伝票備考１
            this._controlIndexBackDictionaryForFooter.Add(this.uButton_SlipNote1.Name, controlIndexBack--);                           // 伝票備考１ガイドボタン
            this._controlIndexBackDictionaryForFooter.Add(this.tNedit_SupplierSlipNote2.Name, controlIndexBack--);                      // 伝票備考番号2  // ADD 2011/11/30 gezh redmine#8383
            this._controlIndexBackDictionaryForFooter.Add(this.tEdit_SupplierSlipNote2.Name, controlIndexBack--);                            // 伝票備考２
            this._controlIndexBackDictionaryForFooter.Add(this.uButton_SlipNote2.Name, controlIndexBack--);                          // 伝票備考２ガイドボタン
            this._controlIndexBackDictionaryForFooter.Add(this.tEdit_RetGoodsReason.Name, controlIndexBack--);                            // 伝票備考３
            this._controlIndexBackDictionaryForFooter.Add(this.uButton_RetGoodsReason.Name, controlIndexBack--);                          // 伝票備考３ガイドボタン
            this._controlIndexBackDictionaryForFooter.Add(this.tNedit_StockTotalPrice.Name, controlIndexBack--);                       // 納入先コード
            this._controlIndexBackDictionaryForFooter.Add(this.tNedit_StockPriceConsTaxTotal.Name, controlIndexBack--);                        // 納入先名称
            // 2009.04.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			this._memoControlList = new List<Control>();
			this._memoControlList.Add(this.tEdit_InsideMemo1);
			this._memoControlList.Add(this.tEdit_InsideMemo2);
			this._memoControlList.Add(this.tEdit_InsideMemo3);
			this._memoControlList.Add(this.tEdit_SlipMemo1);
			this._memoControlList.Add(this.tEdit_SlipMemo2);
			this._memoControlList.Add(this.tEdit_SlipMemo3);

            this._changeFocusSaveCancel = false; // 2009.04.02

            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "Constructor", "終了");
		}

		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region ■Private Members
		private MAKON01110UB _stockSlipDetailInput;
		//private MAKON01110UH _salesTempInput;
        private ImageList _imageList16 = null;											// イメージリスト
		private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// 終了ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// 保存ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _retryButton;				// 元に戻すボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _newButton;				// 新規ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;				// ガイドボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _setupButton;				// 設定ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _redSlipButton;			// 赤伝ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _returnSlipButton;			// 返品ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _arrivalAppropriateButton;	// 入荷計上ボタン
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginEmployeeLabel;		// ログイン担当者タイトル
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;			// ログイン担当者名称
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionTitleLabel;	// ログイン拠点タイトル
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionNameLabel;		// ログイン拠点名称
		private Infragistics.Win.UltraWinToolbars.ButtonTool _readSlipButton;			// 伝票呼出ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _deleteSlipButton;			// 伝票削除ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _copySlipButton;           // 伝票複写ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _stockReferenceButton;     // 仕入履歴ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _orderReferenceButton;     // 発注履歴ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _salesSlipEntryButton;		// 売上登録ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _forwardButton;			// 進むボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _returnButton;				// 戻るボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _reNewalButton;		   	// 最新情報ボタン // 2009.03.25
        private Infragistics.Win.UltraWinToolbars.ButtonTool _taxRateSetButton;		   	// 消費税率ボタン // ADD 田建委 2020/02/24 PMKOBETSU-2912の対応
        private Infragistics.Win.UltraWinToolbars.ButtonTool _taxtDataInputButton;      //仕入データ取込ボタン　 // ADD 陳艶丹 2020/06/22 PMKOBETSU-4017の対応
        private ControlScreenSkin _controlScreenSkin;
		private StockSlipInputAcs _stockSlipInputAcs;
		private ToolBarCaptionAcs _toolBarCaptionAcs;
		private StockSlipInputInitDataAcs _stockSlipInputInitDataAcs;
		private StockSlipInputConstructionAcs _stockInputConstructionAcs;
        private StockSlipInputConstructionAcsLog _stockInputConstructionAcsLog; // ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御) 
		private Dictionary<string, string> _guideEnableControlDictionary = new Dictionary<string, string>();
		private Dictionary<string, Control> _guideEnableExceptControlDictionary = new Dictionary<string, Control>();
		private Dictionary<string, int> _controlIndexForwordDictionary = new Dictionary<string, int>();
		private Dictionary<string, int> _controlIndexBackDictionary = new Dictionary<string, int>();
        private Dictionary<string, int> _controlIndexForwordDictionaryForFooter = new Dictionary<string, int>(); // 2009.04.02
        private Dictionary<string, int> _controlIndexBackDictionaryForFooter = new Dictionary<string, int>(); // 2009.04.02
        private Dictionary<string, Control> _headerItemsDictionary = new Dictionary<string, Control>();
		private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
		private CustomerInfoAcs _customerInfoAcs;
		private SupplierAcs _supplierAcs;
		private SFCMN00221UA _superSlider;
		//private OLEScannerController _OLEScannerController;
		private Control _prevControl = null;									// 現在のコントロール
		private StockSlipInputInitData _stockSlipInputInitData;
		private List<Control> _memoControlList;									// メモ情報コントロールリスト
        private Thread _readInitialThread;
        private Thread _readInitialThread2;
		//private SalesTempInputAcs _salesTempInputAcs;							// 売上情報アクセスクラス

        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト

        private bool _changeFocusSaveCancel; // 2009.04.02
        private bool _showErrorMsg = false;//ADD 黄興貴 2015/03/25 Redmine#45073 宮田自動車商会 仕入伝票入力で仕入伝票番号が空白のデータが作成されるの不具合の対応

        //DEL 2012/03/13 鄧潘ハン Redmine #27374----->>>>>
        //add 2011/12/27 陳建明 Redmine #27374----->>>>>
        //private StockSlip _deleteStockSlip = null;
        //private List<StockDetail> _deleteStockDetailList = null;
        //private List<StockDetail> _deleteAddUpSrcDetailList = null;
        //private PaymentSlp _deletePaymentSlp = null;
        //private List<PaymentDtl> _deletePaymentDtlList = null;
        //private List<StockWork> _deleteStockWorkList = null;
        //private bool _isCannotModify = false;
        //add 2011/12/27 陳建明 Redmine #27374-----<<<<<
        //DEL 2012/03/13 鄧潘ハン Redmine #27374-----<<<<<

        private bool _timerIsRunFlag = false;   // ADD 2014/12/08 譚洪
        private bool _returnFlag;// ADD 黄興貴 2015/04/01 Redmine#45073 障害No.179

        // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
        private double taxRateSetMaster;
        private bool slipSrcTaxFlg =false;
        // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<

		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region ■Const Members
		private const string ctGUIDE_NAME_SectionGuide = "SectionGuide";
		private const string ctGUIDE_NAME_SubSectionGuide = "SubSectionGuide";
		private const string ctGUIDE_NAME_EmployeeGuide = "EmployeeGuide";
		private const string ctGUIDE_NAME_SupplierSlipGuide = "SupplierSlipGuide";
		private const string ctGUIDE_NAME_SupplierGuide = "SupplierGuide";
		private const string ctGUIDE_NAME_WarehouseGuide = "WarehouseGuide";
		private const string ctGUIDE_NAME_SupplierSlipNote1Guide = "SupplierSlipNote1Guide";
		private const string ctGUIDE_NAME_SupplierSlipNote2Guide = "SupplierSlipNote2Guide";
		private const string ctGUIDE_NAME_ReturnReasonGuide = "ReturnReasonGuide";
		private const string ctAssemblyName = "MAKON01110UA";
		private const string ctTAB_KEY_StockInfo = "StockInfo";
		private const string ctTAB_KEY_SlipMemo = "SlipMemo";
        private const string ctSave = "保存"; // 2009.03.25
        private const string ctDecision = "確定"; // 2009.03.25
        private const string ctSaveToolTipText = "現在編集中の情報を保存します。"; // 2009.03.25
        private const string ctDecisionToolTipText = "次グループへ移動します。"; // 2009.03.25
        private const int ctSTATUS_CHK_SEND_ERR = -1001; // ADD 2011/08/09 qijh
        private const string ctMSG_CHK_SEND_ERR = "送信済みのデータの為、更新できません。"; // ADD 2011/08/23 qijh SCM対応 - 拠点管理(10704767-00)
        // 2011/07/21 add wangf start
        private const string MUSTINPUTERROR = "を入力して下さい。";
        // 2011/07/21 add wangf end
		 // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- >>>>
        private const string Ct_SpreadFail = "データ展開に失敗したデータがあります。" + "\n" + "\n" + "エラーファイルを確認してください。";
        private const string Ct_SpreadSuccess = "データ展開を完了しました。";
        // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- <<<<

        #region 各ツールのキー
        private const string ctTOOLBAR_LABELTOOL_LOGINTITLE_KEY = "LabelTool_LoginTitle";
        private const string ctTOOLBAR_LABELTOOL_LOGINNAME_KEY = "LabelTool_LoginName";
        private const string ctTOOLBAR_LABELTOOL_LOGINSECTIONTITLE_KEY = "LabelTool_LoginSectionTitle";
        private const string ctTOOLBAR_LABELTOOL_LOGINSECTIONNAME_KEY = "LabelTool_LoginSectionName";
        private const string ctTOOLBAR_BUTTONTOOL_CLOSE_KEY = "ButtonTool_Close";
        private const string ctTOOLBAR_BUTTONTOOL_SAVE_KEY = "ButtonTool_Save";
        private const string ctTOOLBAR_BUTTONTOOL_RETRY_KEY = "ButtonTool_Retry";
        private const string ctTOOLBAR_BUTTONTOOL_NEW_KEY = "ButtonTool_New";
        private const string ctTOOLBAR_BUTTONTOOL_GUIDE_KEY = "ButtonTool_Guide";
        private const string ctTOOLBAR_BUTTONTOOL_SETUP_KEY = "ButtonTool_Setup";
        private const string ctTOOLBAR_BUTTONTOOL_REDSLIP_KEY = "ButtonTool_RedSlip";
        private const string ctTOOLBAR_BUTTONTOOL_RETURNSLIP_KEY = "ButtonTool_ReturnSlip";
        private const string ctTOOLBAR_BUTTONTOOL_ARRIVALAPPROPRIATE_KEY = "ButtonTool_ArrivalAppropriate";
        private const string ctTOOLBAR_BUTTONTOOL_READSLIP_KEY = "ButtonTool_ReadSlip";
        private const string ctTOOLBAR_BUTTONTOOL_DELETESLIP_KEY = "ButtonTool_DeleteSlip";
        private const string ctTOOLBAR_BUTTONTOOL_COPYSLIP_KEY = "ButtonTool_CopySlip";
        private const string ctTOOLBAR_BUTTONTOOL_ORDERREFERENCE_KEY = "ButtonTool_OrderReference";
        private const string ctTOOLBAR_BUTTONTOOL_STOCKREFERENCE_KEY = "ButtonTool_StockReference";
        private const string ctTOOLBAR_BUTTONTOOL_SALESSLIPENTRY_KEY = "ButtonTool_SalesSlipEntry";
        private const string ctTOOLBAR_BUTTONTOOL_FORWARD_KEY = "ButtonTool_Forward";
        private const string ctTOOLBAR_BUTTONTOOL_RETURN_KEY = "ButtonTool_Return";
        private const string ctTOOLBAR_BUTTONTOOL_RENEWAL_KEY = "ButtonTool_ReNewal"; // 2009.03.25
        private const string ctTOOLBAR_BUTTONTOOL_TAXRATESET_KEY = "BottonTool_TaxRateSet";// ADD 田建委 2020/02/24 PMKOBETSU-2912の対応
        private const string ctTOOLBAR_BUTTONTOOL_TEXTDATAINPUT_KEY = "ButtonTool_TextDataInpuit"; // ADD 陳艶丹 2020/06/22 PMKOBETSU-4017の対応
        #endregion

        # endregion

        // ===================================================================================== //
		// 列挙型
		// ===================================================================================== //
		#region ■Enums
		/// <summary>画面表示モード</summary>
		enum SetDisplayMode : int
		{
			/// <summary>全て</summary>
			All = 0,
			/// <summary>合計金額のみ</summary>
			TotalPriceInfoOnly = 1
		}
		#endregion

        // ===================================================================================== //
        // デリゲート
        // ===================================================================================== //
        #region ■Delegate

		/// <summary>
		/// タブ変更デリゲート
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="key">タブキー</param>
		public delegate void TabChangeEventHandler( object sender, string key );

		/// <summary>
		/// 仕入先変更デリゲート
		/// </summary>
		/// <param name="reCalcPrice">True:単価再計算する</param>
		public delegate void SupplierChangeEventHandler( bool reCalcPrice );

		#endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ■Events

		private event TabChangeEventHandler TabChanged;

		private event SupplierChangeEventHandler SupplierChanged;

		#endregion

        // 操作権限の制御オブジェクトの保有
        /// <summary>
        /// 操作権限の制御オブジェクトを取得します。
        /// </summary>
        /// <value>操作権限の制御オブジェクト</value>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateEntryOperationAuthority("MAKON01100U", this);
                }
                return _operationAuthority;
            }
        }

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		#region ■Private Methods
        /// <summary>
        /// 初期データ取得用のスレッド
        /// </summary>
        private void InitialReadThread()
        {
            this._stockSlipInputInitDataAcs.ReadInitData(this._enterpriseCode, this._loginSectionCode);
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "InitialReadThread", "終了");
        }

#if false
        /// <summary>
        /// 初期データ取得用のスレッド２
        /// </summary>
        private void InitialReadThread2()
        {
            this._stockSlipInputInitDataAcs.ReadInitData2(this._enterpriseCode, this._loginSectionCode);
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "InitialReadThread2", "終了");
        }
#endif

		/// <summary>
		/// ボタン初期設定処理
		/// </summary>
		private void ButtonInitialSetting()
		{
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			this._retryButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
			this._newButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
			this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
			this._setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
			this._redSlipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.REDSLIP;
			this._returnSlipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
			this._arrivalAppropriateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.COST;
			this._loginSectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
			this._loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			this._readSlipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPSEARCH;
			this._deleteSlipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
			this._copySlipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPCOPY;
			this._orderReferenceButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
			this._stockReferenceButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
			this._salesSlipEntryButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
			this._forwardButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT;
			this._returnButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            this._reNewalButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL; // 2009.03.25
            this._taxRateSetButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CREDITPLAN; // ADD 田建委 2020/02/24 PMKOBETSU-2912の対応d
			this._taxtDataInputButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVTAKING; //仕入データ取込ボタン　//2020.06.22

			this.uButton_SectionGuide.ImageList = this._imageList16;
			this.uButton_SubSectionGuide.ImageList = this._imageList16;
			this.uButton_EmployeeGuide.ImageList = this._imageList16;
			this.uButton_SupplierSlipGuide.ImageList = this._imageList16;
            this.uButton_SupplierGuide.ImageList = this._imageList16;
			this.uButton_WarehouseGuide.ImageList = this._imageList16;
            this.uButton_SlipNote1.ImageList = this._imageList16;
            this.uButton_SlipNote2.ImageList = this._imageList16;
            this.uButton_RetGoodsReason.ImageList = this._imageList16;

			this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_SubSectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_EmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_SupplierSlipGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SupplierGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_WarehouseGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SlipNote1.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SlipNote2.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_RetGoodsReason.Appearance.Image = (int)Size16_Index.STAR1;
		}

		/// <summary>
		/// ツールバー初期設定処理
		/// </summary>
		private void ToolBarInitilSetting()
		{
			//// 管理拠点コンボボックスの設定
			//try
			//{
			//    this._stockSlipInputInitDataAcs.SetSectionComboEditor(ref this._sectionComboBox, false);

			//    // 拠点コンボエディタ選択値設定処理
			//    this._stockSlipInputInitDataAcs.SetSectionComboEditorValue(this._sectionComboBox, this._loginSectionCode);
			//}
			//catch (ApplicationException ex)
			//{
			//    TMsgDisp.Show(
			//        this,
			//        emErrorLevel.ERR_LEVEL_STOP,
			//        this.Name,
			//        ex.Message,
			//        0,
			//        MessageBoxButtons.OK);

			//    return;
			//}

			//if (StockSlipInputInitDataAcs.IsSectionOptionIntroduce)
			//{
			//    this._sectionTitleLabel.SharedProps.Visible = true;
			//    this._sectionComboBox.SharedProps.Visible = true;
			//}
			//else
			//{
			//    this._sectionTitleLabel.SharedProps.Visible = false;
			//    this._sectionComboBox.SharedProps.Visible = false;
			//}

		}

        /// <summary>
        /// コンボエディタアイテム初期設定処理
        /// </summary>
        private void ComboEditorItemInitialSetting()
        {
            //// 返品理由
            //this._stockSlipInputInitDataAcs.SetUserGdBdComboEditor(ref this.tComboEditor_RetGoodsReason, StockSlipInputInitDataAcs.ctDIVCODE_UserGuideDivCd_RetGoodsReason);
		}

		/// <summary>
		/// 仕入データクラス→画面格納処理
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		private void SetDisplay(StockSlip stockSlip)
		{
			this.SetDisplay(stockSlip, SetDisplayMode.All);
		}

		/// <summary>
		/// 仕入データクラス→画面格納処理（オーバーロード）
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="setDisplayMode">表示モード</param>
		private void SetDisplay( StockSlip stockSlip, SetDisplayMode setDisplayMode )
		{
			switch (setDisplayMode)
			{
				case SetDisplayMode.All:
				{
					// 画面表示処理（ヘッダ、フッタ情報／仕入データより）
					this.SetDisplayHeaderFooterInfo(stockSlip);

					// 画面表示処理（仕入金額合計情報）
					this.SetDisplayTotalPriceInfo(stockSlip);

					break;
				}
				case SetDisplayMode.TotalPriceInfoOnly:
				{
					// 画面表示処理（仕入金額合計情報）
					this.SetDisplayTotalPriceInfo(stockSlip);
					break;
				}
			}
            this.SlipMemoInfoFormSetting();
		}

		/// <summary>
		/// 明細コンポーネント取得処理
		/// </summary>
		/// <returns></returns>
		private Control GetDetailComponent()
		{
			return this._stockSlipDetailInput;
		}

		/// <summary>
		/// フッタータブ変更時発生処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="key"></param>
		private void FooterTabChanged( object sender, string key )
		{
            switch (key)
			{
				case MAKON01110UA.ctTAB_KEY_StockInfo:
					{
                        // DEL 2011/11/30 gezh redmine#8383 ----------------------------------------------------------------------------------->>>>>
                        //if (( this.tEdit_SupplierSlipNote1.Visible ) && ( this.tEdit_SupplierSlipNote1.Enabled ) && ( !this.tEdit_SupplierSlipNote1.ReadOnly ))
                        //{
                        //    this.tEdit_SupplierSlipNote1.Focus();
                        //    this._prevControl = this.tEdit_SupplierSlipNote1;
                        //}
                        //else
                        //{
                        //    this._prevControl = this.GetActiveControl();
                        //}
                        // DEL 2011/11/30 gezh redmine#8383 -----------------------------------------------------------------------------------<<<<<
                        // ADD 2011/11/30 gezh redmine#8383 ----------------------------------------------------------------------------------->>>>>
                        if ((this.tNedit_SupplierSlipNote1.Visible) && (this.tNedit_SupplierSlipNote1.Enabled) && (!this.tNedit_SupplierSlipNote1.ReadOnly))
                        {
                            this.tNedit_SupplierSlipNote1.Focus();
                            this._prevControl = this.tNedit_SupplierSlipNote1;
                        }
                        else
                        {
                            this._prevControl = this.GetActiveControl();
                        }
                        // ADD 2011/11/30 gezh redmine#8383 -----------------------------------------------------------------------------------<<<<<
						break;
					}
				case MAKON01110UA.ctTAB_KEY_SlipMemo:
					{
                        if (( this.tEdit_InsideMemo1.Visible ) && ( this.tEdit_InsideMemo1.Enabled ) && ( !this.tEdit_InsideMemo1.ReadOnly ))
                        {
                            this.tEdit_InsideMemo1.Focus();
                            //this._prevControl = this.tEdit_SupplierSlipNote1;  //DEL 2011/11/30 gezh redmine#8383
                            this._prevControl = this.tNedit_SupplierSlipNote1;   //ADD 2011/11/30 gezh redmine#8383
                        }
                        else
                        {
                            this._prevControl = this.GetActiveControl();
                        }
                        break;
                    }
                default:
                    {
                        this._prevControl = this.GetActiveControl();
                        break;
                    }
			}
            this.SettingGuideButtonToolEnabled(this._prevControl);
        }

		/// <summary>
		/// 画面表示処理（ヘッダ、フッタ情報／仕入データより）
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		private void SetDisplayHeaderFooterInfo(StockSlip stockSlip)
		{
			if (stockSlip == null) return;

			bool stockDateEnabled = true;
			bool paymentConfirmationEnabled = true;
			bool canDetailInput = true;

			try
			{
                // 各コントロールの描画を一時的に停止させる
                this.tComboEditor_SupplierFormal.BeginUpdate();
                this.tComboEditor_SupplierSlipCd.BeginUpdate();
                this.tComboEditor_StockGoodsCd.BeginUpdate();
                this.tComboEditor_AccPayDivCd.BeginUpdate();
                this.tNedit_SupplierCd.BeginUpdate();
                this.uButton_SupplierGuide.BeginUpdate();
                this.tEdit_WarehouseCode.BeginUpdate();
                this.uButton_WarehouseGuide.BeginUpdate();
                this.tEdit_PartySaleSlipNum.BeginUpdate();
                this.tEdit_SupplierSlipNote1.BeginUpdate();
                this.tEdit_SupplierSlipNote2.BeginUpdate();
                // ADD 2011/11/30 gezh redmine#8383 -------->>>>>
                this.tNedit_SupplierSlipNote1.BeginUpdate();
                this.tNedit_SupplierSlipNote2.BeginUpdate();
                // ADD 2011/11/30 gezh redmine#8383 --------<<<<<
                this.tEdit_RetGoodsReason.BeginUpdate();
                this.tEdit_SectionCode.BeginUpdate();
                this.tNedit_SubSectionCode.BeginUpdate();
                this.tNedit_SupplierConsTaxRate.BeginUpdate();
                this.tComboEditor_SuppTtlAmntDspWayCd.BeginUpdate();
                this.tComboEditor_SupplierSlipCdDisplay.BeginUpdate();
                this.tComboEditor_PriceCostUpdtDiv.BeginUpdate();
                this.uTabControl_Footer.BeginUpdate();

				this.tEdit_StockAgentCode.Text = stockSlip.StockAgentCode.Trim();   // TODO:担当者の画面初期値はここで設定
                this.uLabel_StockAgentName.Text = stockSlip.StockAgentName;         // TODO:担当者の画面初期値はここで設定
				this.tNedit_SupplierSlipNo.SetInt(stockSlip.SupplierSlipNo);
				ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_SupplierFormal, stockSlip.SupplierFormal, true);
				ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_SupplierSlipCdDisplay, stockSlip.SupplierSlipDisplay, true);
				ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_SupplierSlipCd, stockSlip.SupplierSlipCd, true);
				ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_StockGoodsCd, stockSlip.StockGoodsCd, true);
				ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_AccPayDivCd, stockSlip.AccPayDivCd, true);
				ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_PriceCostUpdtDiv, stockSlip.PriceCostUpdtDiv, true);
				this.tEdit_SectionCode.Text = stockSlip.StockSectionCd.Trim();
				this.uLabel_SectionName.Text = stockSlip.StockSectionNm;
				this.tNedit_SubSectionCode.SetInt(stockSlip.SubSectionCode);
				this.uLabel_SubSectionName.Text = stockSlip.SubSectionName;
				this.tNedit_SupplierCd.SetInt(stockSlip.SupplierCd);

                // DEL 2010/01/06 MANTIS対応[13956]：仕入先名は略称とする ---------->>>>>
				// this.uLabel_SupplierName.Text = stockSlip.SupplierNm1 + " " + stockSlip.SupplierNm2;
                // DEL 2010/01/06 MANTIS対応[13956]：仕入先名は略称とする ----------<<<<<
                // ADD 2010/01/06 MANTIS対応[13956]：仕入先名は略称とする ---------->>>>>
                this.uLabel_SupplierName.Text = stockSlip.SupplierSnm;
                // ADD 2010/01/06 MANTIS対応[13956]：仕入先名は略称とする ----------<<<<<

				this.tEdit_WarehouseCode.Text = stockSlip.WarehouseCode.Trim();
				this.uLabel_WarehouseName.Text = stockSlip.WarehouseName;
				this.tDateEdit_ArrivalGoodsDay.SetDateTime(stockSlip.ArrivalGoodsDay);
				this.tDateEdit_StockDate.SetDateTime(stockSlip.StockDate);
				this.tEdit_PartySaleSlipNum.Text = stockSlip.PartySaleSlipNum;

				this.tEdit_SupplierSlipNote1.Text = stockSlip.SupplierSlipNote1;
				this.tEdit_SupplierSlipNote2.Text = stockSlip.SupplierSlipNote2;
                // ADD 2011/11/30 gezh redmine#8383 -------->>>>>
                if (stockSlip.SupplierSlipNoteNo1 != 0)
                {
                    this.tNedit_SupplierSlipNote1.Text = stockSlip.SupplierSlipNoteNo1.ToString("D4");
                }
                else
                {
                    this.tNedit_SupplierSlipNote1.Text = "";
                }
                if (stockSlip.SupplierSlipNoteNo2 != 0)
                {
                    this.tNedit_SupplierSlipNote2.Text = stockSlip.SupplierSlipNoteNo2.ToString("D4");
                }
                else
                {
                    this.tNedit_SupplierSlipNote2.Text = "";
                }
                // ADD 2011/11/30 gezh redmine#8383 --------<<<<<
                this.tEdit_RetGoodsReason.Text = stockSlip.RetGoodsReason;

				if (stockSlip.RetGoodsReasonDiv == 0)
				{
                    this.tEdit_RetGoodsReason.Text = stockSlip.RetGoodsReason;
				}

                //switch (stockSlip.SuppCTaxLayCd)
                //{
                //    case 0:
                //        {
                //            this.uLabel_SuppCTaxLayCdTitle.Text = "(伝票毎)";
                //            break;
                //        }
                //    case 1:
                //        {
                //            this.uLabel_SuppCTaxLayCdTitle.Text = "(明細毎)";
                //            break;
                //        }
                //    case 2:
                //        {
                //            this.uLabel_SuppCTaxLayCdTitle.Text = "(請求毎)";
                //            break;
                //        }
                //}

				ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_SuppTtlAmntDspWayCd, stockSlip.SuppTtlAmntDspWayCd, true);

				if (stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Return)
				{
					this.uLabel_InputModeTitle.Text = "返品";
				}
				else if (stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red)
				{
					this.uLabel_InputModeTitle.Text = "赤伝";
				}
				else if (stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ArrivalAddUp)
				{
					this.uLabel_InputModeTitle.Text = "入荷計上";
				}
				else if (stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly)
				{
					if (stockSlip.DebitNoteDiv == 2)
					{
						this.uLabel_InputModeTitle.Text = "元黒";
					}
					//else if (stockSlip.TrustAddUpSpCd == 2)
					//{
					//    this.uLabel_InputModeTitle.Text = "売上済";
					//}
					else
					{
						this.uLabel_InputModeTitle.Text = "編集不可";
					}
				}
				else if (stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp)
				{
					this.uLabel_InputModeTitle.Text = "締済み";
				}
				else
				{
					this.uLabel_InputModeTitle.Text = "通常";
				}

				// 伝票区分が返品の場合は返品理由を表示、売上タブを非表示
				if (stockSlip.SupplierSlipCd == 20)
				{
					this.uLabel_ReturnReasonTitle.Visible = true;
                    this.tEdit_RetGoodsReason.Visible = true;
					//if (this.Footer_UTabControl.SelectedTab == this.Footer_UTabControl.Tabs[MAKON01110UH.ctTAB_KEY_SalesInfo])
					//{
					//    this.Footer_UTabControl.SelectedTab = this.Footer_UTabControl.Tabs[ctTAB_KEY_StockInfo];
					//}
				}
				else
				{
					this.uLabel_ReturnReasonTitle.Visible = false;
                    this.tEdit_RetGoodsReason.Visible = false;
				}

				// 一旦全てのコントロールを入力可能とする
				this.panel_Footer.Enabled = true;

				this.tEdit_StockAgentCode.Enabled = true;
				this.uButton_EmployeeGuide.Enabled = true;
				this.tNedit_SupplierSlipNo.Enabled = true;
				this.tComboEditor_SupplierFormal.Enabled = true;
				this.tComboEditor_SupplierSlipCd.Enabled = true;
				this.tComboEditor_StockGoodsCd.Enabled = true;
				this.tComboEditor_AccPayDivCd.Enabled = true;
				this.tComboEditor_SupplierSlipCdDisplay.Enabled = true;
				this.tComboEditor_PriceCostUpdtDiv.Enabled = true;
				this.tNedit_SupplierCd.Enabled = true;
				this.tEdit_WarehouseCode.Enabled = true;
				//this.tDateEdit_ArrivalGoodsDay.Enabled = true;// DEL 2013/01/09 張曼 Redmine#33821
                //---ADD 2013/01/09 張曼 Redmine#33821 ----->>>>>               
                if (stockSlip.SupplierFormal == 0)
                {
                    //伝票種別は「仕入」の場合、「入荷日」は入力できない。
                    this.tDateEdit_ArrivalGoodsDay.Enabled = false;
                }
                else
                {
                    //伝票種別は「入荷」の場合、「入荷日」は入力できる。
                    this.tDateEdit_ArrivalGoodsDay.Enabled = true;
                }
                //---ADD 2013/01/09 張曼 Redmine#33821 -----<<<<<
				this.tEdit_PartySaleSlipNum.Enabled = true;
				this.tEdit_SupplierSlipNote1.Enabled = true;
				this.tEdit_SupplierSlipNote2.Enabled = true;
                // ADD 2011/11/30 gezh redmine#8383 -------->>>>>
                this.tNedit_SupplierSlipNote1.Enabled = true;
                this.tNedit_SupplierSlipNote2.Enabled = true;
                // ADD 2011/11/30 gezh redmine#8383 --------<<<<<
				this.tNedit_SupplierConsTaxRate.Enabled = true;
                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                this.tEdit_SectionCode.Enabled = true;
                this.tNedit_SubSectionCode.Enabled = true;
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				//this._stockSlipDetailInput.Enabled = true;

				if (stockSlip.SuppCTaxLayCd == 2)
				{
					// 請求転嫁の場合は総額表示方法区分を「0:総額表示しない」固定とする
					this.tComboEditor_SuppTtlAmntDspWayCd.Enabled = false;
				}
				else
				{
					this.tComboEditor_SuppTtlAmntDspWayCd.Enabled = true;
				}

				// 入力モードが「参照モード」の場合は、全て入力不可とする
				// 入力モードが「締済みモード」の場合は、赤伝以外入力不可とする
				if (( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
					( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ))
				{
					this.tEdit_StockAgentCode.Enabled = false;
					this.tNedit_SupplierSlipNo.Enabled = false;
					this.tComboEditor_SupplierFormal.Enabled = false;
					this.tComboEditor_SupplierSlipCd.Enabled = false;
					this.tComboEditor_StockGoodsCd.Enabled = false;
					this.tComboEditor_AccPayDivCd.Enabled = false;
					this.tComboEditor_PriceCostUpdtDiv.Enabled = false;
					this.tComboEditor_SupplierSlipCdDisplay.Enabled = false;
					this.tNedit_SupplierCd.Enabled = false;
					this.tEdit_SectionCode.Enabled = false;
					this.tNedit_SubSectionCode.Enabled = false;
					this.tEdit_WarehouseCode.Enabled = false;
					this.tDateEdit_ArrivalGoodsDay.Enabled = false;
					stockDateEnabled = false;
					this.tEdit_PartySaleSlipNum.Enabled = false;
					this.tEdit_SupplierSlipNote1.Enabled = false;
					this.tEdit_SupplierSlipNote2.Enabled = false;
                    // ADD 2011/11/30 gezh redmine#8383 -------->>>>>
                    this.tNedit_SupplierSlipNote1.Enabled = false;
                    this.tNedit_SupplierSlipNote2.Enabled = false;
                    // ADD 2011/11/30 gezh redmine#8383 --------<<<<<
					this.tNedit_SupplierConsTaxRate.Enabled = false;

					this.panel_Footer.Enabled = false;
				}
				// 入力モードが「返品入力モード」の場合は、「仕入形式」「伝票区分」「商品区分」「買掛区分」を変更不可とする
				else if (stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Return)
				{
					this.tComboEditor_SupplierFormal.Enabled = false;
					this.tComboEditor_SupplierSlipCd.Enabled = false;
					this.tComboEditor_StockGoodsCd.Enabled = false;
					this.tComboEditor_AccPayDivCd.Enabled = false;
					this.tComboEditor_SupplierSlipCdDisplay.Enabled = false;
					this.tNedit_SupplierConsTaxRate.Enabled = false;
					this.tComboEditor_SuppTtlAmntDspWayCd.Enabled = false;
                    this.tNedit_SupplierCd.Enabled = false;
				}
				// 入力モードが「赤伝入力モード」の場合は、「仕入形式」「伝票区分」「商品区分」「買掛区分」「仕入先」「倉庫」「明細」を変更不可とする
				else if (stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red)
				{
					this.tComboEditor_SupplierFormal.Enabled = false;
					this.tComboEditor_SupplierSlipCd.Enabled = false;
					this.tComboEditor_StockGoodsCd.Enabled = false;
					this.tComboEditor_AccPayDivCd.Enabled = false;
					this.tComboEditor_SupplierSlipCdDisplay.Enabled = false;
					this.tNedit_SupplierCd.Enabled = false;
					this.tEdit_WarehouseCode.Enabled = false;
					this.tNedit_SupplierConsTaxRate.Enabled = false;
                    this.tComboEditor_PriceCostUpdtDiv.Enabled = false;
					this.tComboEditor_SuppTtlAmntDspWayCd.Enabled = false;
                    paymentConfirmationEnabled = false;
				}
				else
				{
					// 仕入伝票番号が入力されている場合は「仕入形式」「伝票区分」「商品区分」「買掛区分」を入力不可とする
					if (stockSlip.SupplierSlipNo != 0)
					{
						this.tComboEditor_SupplierFormal.Enabled = false;
						this.tComboEditor_SupplierSlipCd.Enabled = false;
						this.tComboEditor_StockGoodsCd.Enabled = false;
						this.tComboEditor_AccPayDivCd.Enabled = false;
						this.tComboEditor_SupplierSlipCdDisplay.Enabled = false;
					}
					else
					{
						// 仕入形式が「1:入荷」の場合は「買掛区分」入力不可とする。
						if (stockSlip.SupplierFormal == 1)
						{
							this.tComboEditor_AccPayDivCd.Enabled = false;
						}
					}

					if (stockSlip.StockGoodsCd == 6)
					{
						canDetailInput = false;
					}
					else
					{
						canDetailInput = true;
					}

				}

				// 仕入形式が「1:入荷」の場合は「計上日」を入力不可とする
				if (stockSlip.SupplierFormal == 1)
				{
					//this.tDateEdit_StockDate.Enabled = false;
					stockDateEnabled = false;
					paymentConfirmationEnabled = false;
				}

				// 仕入伝票番号が入力されている場合は「仕入伝票番号」を入力不可とする
				if (stockSlip.SupplierSlipNo != 0)
				{
					this.tNedit_SupplierSlipNo.Enabled = false;
				}
				// 「定価原価更新区分」の入力設定
                this.tComboEditor_PriceCostUpdtDiv.Enabled = ( StockSlipInputAcs.CanChangePriceCostUpdtDiv(stockSlip, this._stockSlipInputInitDataAcs.GetStockTtlSt().PriceCostUpdtDiv) );

				// 仕入在庫全体設定マスタで、「拠点表示区分」が「2:表示無し」の場合は拠点入力不可
				if (this._stockSlipInputInitDataAcs.GetStockTtlSt().SectDspDivCd == 2)
				{
					this.tEdit_SectionCode.Enabled = false;
				}

                // 自社情報設定マスタで「部署管理区分」が「0:拠点」の場合は部門非表示
                if (this._stockSlipInputInitDataAcs.GetCompanyInf().SecMngDiv == 0)
                {
                    this.tNedit_SubSectionCode.Visible = false;
                    this.uLabel_SubSectionName.Visible = false;
                    this.uButton_SubSectionGuide.Visible = false;
                    this.uLabel_SubSectionTitle.Visible = false;
                }
                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                else
                {
                    this.tNedit_SubSectionCode.Visible = true;
                    this.uLabel_SubSectionName.Visible = true;
                    this.uButton_SubSectionGuide.Visible = true;
                    this.uLabel_SubSectionTitle.Visible = true;
                }
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // セキュリティ対応
                if (MyOpeCtrl.Disabled((int)OperationCode.Revision))
                {
                    this.tNedit_SupplierSlipNo.Enabled = false;
                    this.uButton_SupplierSlipGuide.Enabled = false;
                }
			}
			finally
			{
				this.tDateEdit_StockDate.Enabled = stockDateEnabled;
				this.uButton_PaymentConfirmation.Enabled = paymentConfirmationEnabled;
				this._stockSlipDetailInput.Enabled = canDetailInput;

                this.uButton_SectionGuide.Enabled = this.tEdit_SectionCode.Enabled;
                this.uButton_SubSectionGuide.Enabled = this.tNedit_SubSectionCode.Enabled;
                this.uButton_EmployeeGuide.Enabled = this.tEdit_StockAgentCode.Enabled;
                this.uButton_SupplierGuide.Enabled = this.tNedit_SupplierCd.Enabled;
                this.uButton_SupplierSlipGuide.Enabled = this.tNedit_SupplierSlipNo.Enabled;
                this.uButton_WarehouseGuide.Enabled = this.tEdit_WarehouseCode.Enabled;
                this.uButton_SlipNote1.Enabled = this.tEdit_SupplierSlipNote1.Enabled;
                this.uButton_SlipNote2.Enabled = this.tEdit_SupplierSlipNote2.Enabled;
                this.uButton_RetGoodsReason.Visible = this.tEdit_RetGoodsReason.Visible;


				// 各コントロールの描画を一時的に停止させる
				this.tComboEditor_SupplierFormal.EndUpdate();
				this.tComboEditor_SupplierSlipCd.EndUpdate();
				this.tComboEditor_StockGoodsCd.EndUpdate();
				this.tComboEditor_AccPayDivCd.EndUpdate();
				this.tEdit_SectionCode.EndUpdate();
				this.tNedit_SubSectionCode.EndUpdate();
				this.tNedit_SupplierCd.EndUpdate();
				this.uButton_SupplierGuide.EndUpdate();
				this.tEdit_WarehouseCode.EndUpdate();
				this.uButton_WarehouseGuide.EndUpdate();
				this.tEdit_PartySaleSlipNum.EndUpdate();
				this.tEdit_SupplierSlipNote1.EndUpdate();
				this.tEdit_SupplierSlipNote2.EndUpdate();
                // ADD 2011/11/30 gezh redmine#8383 -------->>>>>
                this.tNedit_SupplierSlipNote1.EndUpdate();
                this.tNedit_SupplierSlipNote2.EndUpdate();
                // ADD 2011/11/30 gezh redmine#8383 --------<<<<<
                this.tEdit_RetGoodsReason.EndUpdate();
				this.tNedit_SupplierConsTaxRate.EndUpdate();
				this.tComboEditor_SuppTtlAmntDspWayCd.EndUpdate();
				this.tComboEditor_SupplierSlipCdDisplay.EndUpdate();
				this.tComboEditor_PriceCostUpdtDiv.EndUpdate();
				this.uTabControl_Footer.EndUpdate();

				// ツールバーボタン有効無効設定処理
				this.SettingToolBarButtonEnabled();
				this.SettingToolBarButtonEnabled_Detail();
			}
		}

        /// <summary>
        /// 画面表示処理（仕入金額合計情報）
        /// </summary>
        /// <param name="stockSlip">仕入データオブジェクト</param>
        private void SetDisplayTotalPriceInfo( StockSlip stockSlip )
        {
            if (stockSlip == null) return;

			int suppTtlAmntDspWayCd = stockSlip.SuppTtlAmntDspWayCd;
			//int sign = ( ( stockSlip.SupplierSlipCd == 20 ) || ( stockSlip.DebitNoteDiv == 1 ) ) ? -1 : 1;
            int sign = ( stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;

			switch (stockSlip.StockGoodsCd)
			{
				case 2: // 消費税調整
				case 4: // 買掛消費税調整
					{
						// 仕入金額
						this.tNedit_StockTotalPrice.SetValue(0);

						// 消費税
						this.tNedit_StockPriceConsTaxTotal.SetValue(stockSlip.StockPriceConsTax * sign);

						// 総合計
						this.tNedit_TotalPrice.SetValue(stockSlip.StockPriceConsTax * sign);

						break;
					}
				case 3:	// 残高調整
				case 5: // 買掛残高調整
					{
						// 仕入金額
						this.tNedit_StockTotalPrice.SetValue(stockSlip.StockTotalPrice * sign);

						// 消費税
						this.tNedit_StockPriceConsTaxTotal.SetValue(0);

						// 総合計
						this.tNedit_TotalPrice.SetValue(stockSlip.StockTotalPrice * sign);

						break;
					}

				default:
					{
                        // 総合計
                        long totalPrice = stockSlip.StockTotalPrice * sign;

						switch (suppTtlAmntDspWayCd)
						{
							// 総額表示しない
							case 0:
								{
									// 仕入金額 = 仕入金額合計(税抜き) 
									this.tNedit_StockTotalPrice.SetValue(stockSlip.StockSubttlPrice * sign);

                                    if (( stockSlip.SuppCTaxLayCd == 0 ) || ( stockSlip.SuppCTaxLayCd == 1 ))
                                    {
                                        // 消費税 = 合計消費税
                                        this.tNedit_StockPriceConsTaxTotal.SetValue(stockSlip.StockPriceConsTax * sign);
                                    }
                                    // 非課税・請求転嫁の場合は外税を抜いた金額
                                    else
                                    {
                                        // 消費税 = 仕入金額消費税額（内税）＋仕入値引消費税額（内税）
                                        this.tNedit_StockPriceConsTaxTotal.SetValue(( stockSlip.StckPrcConsTaxInclu + stockSlip.StckDisTtlTaxInclu ) * sign);

                                        // 総合計 = 仕入金額小計 + 仕入金額消費税額（内税）+ 仕入値引消費税額（内税）
                                        totalPrice = ( stockSlip.StockSubttlPrice + stockSlip.StckPrcConsTaxInclu + stockSlip.StckDisTtlTaxInclu ) * sign;
                                    }

									break;
								}
							// 総額表示する
							case 1:
								{
									// 仕入金額 = 仕入合計金額
									this.tNedit_StockTotalPrice.SetValue(stockSlip.StockTotalPrice * sign);

									// 消費税 = 合計消費税
									this.tNedit_StockPriceConsTaxTotal.SetValue( stockSlip.StockPriceConsTax * sign);
									this.tNedit_StockPriceConsTaxTotal.Text = "内(" + ( stockSlip.StockPriceConsTax * sign ).ToString("N0") + ")";

									break;
								}
						}


                        this.tNedit_TotalPrice.SetValue(totalPrice);

						break;
					}
			}

			#region 合計金額、消費税の入力可否設定

			this.tNedit_StockPriceConsTaxTotal.BeginUpdate();
			this.tNedit_StockTotalPrice.BeginUpdate();
            this.tNedit_TotalPrice.BeginUpdate();
            bool supplierConsTaxRateEnabled = false;
			bool stockTotalPriceEnabled = false;

			try
			{

				// 入力モードが「参照モード」、「締済みモード」、「赤伝入力モード」
				if (( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
					( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ) ||
					( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red ))
				{
					//supplierConsTaxRateEnabled = false;
				}
				else
				{
					// 合計入力時
					if (stockSlip.StockGoodsCd == 6)
					{
                        if (stockSlip.SupplierCd != 0)
                        {
                            stockTotalPriceEnabled = true;

                            // 消費税は、総額表示する、もしくは伝票転嫁、明細転嫁のときは入力可
                            if (( stockSlip.SuppTtlAmntDspWayCd == 1 ) || ( stockSlip.SuppCTaxLayCd == 0 ) || ( stockSlip.SuppCTaxLayCd == 1 ))
                            {
                                supplierConsTaxRateEnabled = true;
                            }
                        }
					}
					else if (( stockSlip.SuppCTaxLayCd == 0 ) && ( stockSlip.SupplierCd != 0 ) && ( stockSlip.StockGoodsCd == 0 ))
					{
						//if (stockSlip.SuppTtlAmntDspWayCd==0)
						//{
							supplierConsTaxRateEnabled = true;
						//}
					}
				}

			}
			finally
			{
				this.tNedit_StockPriceConsTaxTotal.Enabled = supplierConsTaxRateEnabled;
				this.tNedit_StockTotalPrice.Enabled = stockTotalPriceEnabled;

				//if (( stockSlip.SupplierSlipCd == 20 ) || ( ( stockSlip.DebitNoteDiv == 1 ) ) || ( this.tNedit_StockTotalPrice.GetValue() < 0 ))
                if ( stockSlip.SupplierSlipCd == 20 ) 
				{
					this.tNedit_StockPriceConsTaxTotal.Appearance.ForeColor = Color.Red;
					this.tNedit_StockPriceConsTaxTotal.Appearance.ForeColorDisabled = Color.Red;
					this.tNedit_StockTotalPrice.Appearance.ForeColor = Color.Red;
					this.tNedit_StockTotalPrice.Appearance.ForeColorDisabled = Color.Red;
					this.tNedit_TotalPrice.Appearance.ForeColor = Color.Red;
					this.tNedit_TotalPrice.Appearance.ForeColorDisabled = Color.Red;
				}
				else
				{
					this.tNedit_StockPriceConsTaxTotal.Appearance.ForeColor = this.tEdit_SupplierSlipNote1.Appearance.ForeColor;
					this.tNedit_StockPriceConsTaxTotal.Appearance.ForeColorDisabled = Color.Black;
					this.tNedit_StockTotalPrice.Appearance.ForeColor = this.tEdit_SupplierSlipNote1.Appearance.ForeColor;
					this.tNedit_StockTotalPrice.Appearance.ForeColorDisabled = Color.Black;
					this.tNedit_TotalPrice.Appearance.ForeColor = this.tEdit_SupplierSlipNote1.Appearance.ForeColor;
					this.tNedit_TotalPrice.Appearance.ForeColorDisabled = Color.Black;
				}

				this.tNedit_StockPriceConsTaxTotal.EndUpdate();
				this.tNedit_StockTotalPrice.EndUpdate();
                this.tNedit_TotalPrice.EndUpdate();
			}


			#endregion

            # region 内税外税別表示ロジック（コメント）
            /*
            this.uLabel_StockPriceConsTaxTotal.Text = "0";

            if (stockSlip.TtlItdedStockOutTax != 0)
            {
                // 仕入外税対象額合計が0以外の場合
                this.uLabel_StockPriceConsTaxTotal.Text = stockSlip.TtlStockOuterTax.ToString("N0");
            }

            if (stockSlip.TtlItdedStockInTax != 0)
            {
                if (this.uLabel_StockPriceConsTaxTotal.Text != "")
                {
                    this.uLabel_StockPriceConsTaxTotal.Text += " " + "\r\n";
                }
			
                // 仕入内税対象額合計が0以外の場合
                this.uLabel_StockPriceConsTaxTotal.Text += "内(" + stockSlip.TtlStockInnerTax.ToString("N0") + ")";
            }
            */
            # endregion

        }

		/// <summary>
		/// 仕入合計金額を取得します。
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <returns>仕入合計金額</returns>
		private long GetStockTotalPrice( StockSlip stockSlip )
		{
			long retValue = 0;
			int suppTtlAmntDspWayCd = stockSlip.SuppTtlAmntDspWayCd;

			switch (stockSlip.StockGoodsCd)
			{
				case 2: // 消費税調整
				case 4: // 買掛消費税調整
					{
						// 仕入金額
						retValue = 0;

						break;
					}
				case 3:	// 残高調整
				case 5: // 買掛残高調整
					{
						retValue = stockSlip.StockTotalPrice;
						break;
					}
				default:
					{
						switch (suppTtlAmntDspWayCd)
						{
							// 総額表示しない
							case 0:
								{
									retValue = stockSlip.StockSubttlPrice;

									break;
								}
							// 総額表示する
							case 1:
								{
									retValue = stockSlip.StockTotalPrice;

									break;
								}
						}
						break;
					}
			}
			return retValue;
		}
        
		/// <summary>
		/// 計上区分コンボエディタアイテム設定処理
		/// </summary>
		/// <param name="supplierFormal">仕入形式</param>
		private void SetItemtStockGoodsCd(int supplierFormal)
		{
			switch (supplierFormal)
			{
                case 0:
                {
					this.tComboEditor_StockGoodsCd.Items.Clear();

					Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
					item0.Tag = 1;
					item0.DataValue = 0;
					item0.DisplayText = "明細";
					this.tComboEditor_StockGoodsCd.Items.Add(item0);

                    //Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
                    //item2.Tag = 2;
                    //item2.DataValue = 2;
                    //item2.DisplayText = "消費税調整";
                    //this.tComboEditor_StockGoodsCd.Items.Add(item2);

                    //Infragistics.Win.ValueListItem item3 = new Infragistics.Win.ValueListItem();
                    //item3.Tag = 3;
                    //item3.DataValue = 3;
                    //item3.DisplayText = "残高調整";
                    //this.tComboEditor_StockGoodsCd.Items.Add(item3);

                    //Infragistics.Win.ValueListItem item4 = new Infragistics.Win.ValueListItem();
                    //item4.Tag = 4;
                    //item4.DataValue = 4;
                    //item4.DisplayText = "消費税調整(買掛用)";
                    //this.tComboEditor_StockGoodsCd.Items.Add(item4);

                    //Infragistics.Win.ValueListItem item5 = new Infragistics.Win.ValueListItem();
                    //item5.Tag = 5;
                    //item5.DataValue = 5;
                    //item5.DisplayText = "残高調整(買掛用)";
                    //this.tComboEditor_StockGoodsCd.Items.Add(item5);

                    Infragistics.Win.ValueListItem item6 = new Infragistics.Win.ValueListItem();
                    item6.Tag = 2;
                    item6.DataValue = 6;
                    item6.DisplayText = "合計";
                    this.tComboEditor_StockGoodsCd.Items.Add(item6);

					this.tComboEditor_StockGoodsCd.Value = 0;
					
					break;
				}
 				case 1:
                {
					this.tComboEditor_StockGoodsCd.Items.Clear();

					Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
					item0.Tag = 1;
					item0.DataValue = 0;
					item0.DisplayText = "明細";
					this.tComboEditor_StockGoodsCd.Items.Add(item0);

                    this.tComboEditor_StockGoodsCd.Value = 0;

					break;
				}
			}
		}

        ///// <summary>
        ///// 計上区分コンボエディタアイテム設定処理
        ///// </summary>
        ///// <param name="supplierFormal">仕入形式</param>
        //private void SetItemtSupplierSlipDisplay( int supplierFormal )
        //{
        //    switch (supplierFormal)
        //    {
        //        case 0:
        //            {
        //                this.tComboEditor_SupplierSlipCdDisplay.Items.Clear();

        //                Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
        //                item0.Tag = 1;
        //                item0.DataValue = 10;
        //                item0.DisplayText = "仕入";
        //                this.tComboEditor_SupplierSlipCdDisplay.Items.Add(item0);

        //                Infragistics.Win.ValueListItem item2 = new Infragistics.Win.ValueListItem();
        //                item2.Tag = 2;
        //                item2.DataValue = 20;
        //                item2.DisplayText = "返品";
        //                this.tComboEditor_SupplierSlipCdDisplay.Items.Add(item2);

        //                break;
        //            }
        //        case 1:
        //            {
        //                this.tComboEditor_SupplierSlipCdDisplay.Items.Clear();

        //                Infragistics.Win.ValueListItem item0 = new Infragistics.Win.ValueListItem();
        //                item0.Tag = 1;
        //                item0.DataValue = 10;
        //                item0.DisplayText = "仕入";
        //                this.tComboEditor_SupplierSlipCdDisplay.Items.Add(item0);

        //                Infragistics.Win.ValueListItem item1 = new Infragistics.Win.ValueListItem();
        //                item1.Tag = 2;
        //                item1.DataValue = 20;
        //                item1.DisplayText = "返品";
        //                this.tComboEditor_SupplierSlipCdDisplay.Items.Add(item1);

        //                this.tComboEditor_SupplierSlipCdDisplay.Value = 10;

        //                break;
        //            }
        //    }
        //}

		/// <summary>
		/// 明細グリッド最上位行キーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void StockSlipDetailInput_GridKeyDownTopRow(object sender, EventArgs e)
		{
            this.tEdit_WarehouseCode.Focus();
            this._prevControl = this.tEdit_WarehouseCode;
            // ガイドボタンツール有効無効設定処理
            this.SettingGuideButtonToolEnabled(this._prevControl);
		}

		/// <summary>
        /// 明細グリッド最下層行キーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void StockSlipDetailInput_GridKeyDownButtomRow(object sender, EventArgs e)
		{
			uTabControl_Footer.SelectedTab = this.uTabControl_Footer.Tabs[0];

            //this.tEdit_SupplierSlipNote1.Focus();  //DEL 2011/11/30 gezh redmine#8383
            this.tNedit_SupplierSlipNote1.Focus();   //ADD 2011/11/30 gezh redmine#8383

            //this._prevControl = this.tEdit_SupplierSlipNote1;  //DEL 2011/11/30 gezh redmine#8383
            this._prevControl = this.tNedit_SupplierSlipNote1;   //ADD 2011/11/30 gezh redmine#8383

            // ガイドボタンツール有効無効設定処理
            this.SettingGuideButtonToolEnabled(this._prevControl);
        }

        /// <summary>
        /// 明細グリッド仕入先選択イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockDetailInput_SupplierSelect(object sender, EventArgs e)
        {
            if (( this.tNedit_SupplierCd.Visible ) && ( this.tNedit_SupplierCd.Enabled ))
            {
                this.tNedit_SupplierCd.Focus();
                this._prevControl = this.tNedit_SupplierCd;
            }
        }

		/// <summary>
		/// 仕入形式変更処理
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="isCache">True:キャッシュ有り</param>
		/// <returns>True:変更有り</returns>
        /// <br>Update Note: 2010/12/03 yangmj 伝票種別変更時に明細のクリア処理の修正</br>
		/// <remarks>
        /// <br>Update Note: 2020/02/24 田建委</br>
        /// <br>管理番号    : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912消費税税率機能追加対応</br>
        /// </remarks>
		private bool ChageSupplierFormal( ref StockSlip stockSlip, bool isCache )
		{
			bool changeSupplierFormal = false;

			int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_SupplierFormal, ComboEditorGetDataType.TAG);

			if (stockSlip.SupplierFormal != code)
			{
				if (code != -1)
				{
					// 入荷に変更した場合
					if (code == 1)
					{
						if (this._stockSlipInputAcs.ExistStockDetailData())
						{
							// 買掛無し、商品以外、行値引きがあった場合はクリアする
							if (( stockSlip.StockGoodsCd != 0 ) || ( this._stockSlipInputAcs.ExistStockDetailDiscountData()))
							{
								DialogResult dialogResult = TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_EXCLAMATION,
									this.Name,
									this._stockSlipInputAcs.GetSupplierFormalName(this._stockSlipInputAcs.StockSlip) + "明細情報がクリアされます。" + "\r\n" + "\r\n" +
									"よろしいですか？",
									0,
									MessageBoxButtons.YesNo,
									MessageBoxDefaultButton.Button1);

								if (dialogResult == DialogResult.Yes)
								{
									this._stockSlipDetailInput.Clear();
									changeSupplierFormal = true;
								}
							}
                            //----ADD 2010/12/03----->>>>>
                            else if (this._stockSlipInputAcs.ExistStockMaitasuData())
                            {
                                DialogResult dialogResult = TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    this._stockSlipInputAcs.GetSupplierFormalName(this._stockSlipInputAcs.StockSlip) + "明細情報がクリアされます。" + "\r\n" + "\r\n" +
                                    "よろしいですか？",
                                    0,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxDefaultButton.Button1);

                                if (dialogResult == DialogResult.Yes)
                                {
                                    this._stockSlipDetailInput.Clear();
                                    changeSupplierFormal = true;
                                }
                            }
                            //----ADD 2010/12/03-----<<<<<
							else if (this._stockSlipInputAcs.ExistArrivalAppropriateDetail())
							{
								DialogResult dialogResult = TMsgDisp.Show(
									this,
									emErrorLevel.ERR_LEVEL_EXCLAMATION,
									this.Name,
									this._stockSlipInputAcs.GetSupplierFormalName(1) + "計上情報がクリアされます。" + "\r\n" + "\r\n" +
									"よろしいですか？",
									0,
									MessageBoxButtons.YesNo,
									MessageBoxDefaultButton.Button1);

								if (dialogResult == DialogResult.Yes)
								{
									this._stockSlipInputAcs.ClearArrivalAppropriateInfo();

									if (stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ArrivalAddUp)
									{
										stockSlip.InputMode = StockSlipInputAcs.ctINPUTMODE_StockSlip_Normal;

										// 仕入明細行初期行数追加処理
										this._stockSlipInputAcs.AddStockDetailRowInitialRowCount();
									}

									changeSupplierFormal = true;
								}
							}
							else
							{
								changeSupplierFormal = true;
							}
						}
						else
						{
							changeSupplierFormal = true;
						}
					}
					else
					{
						changeSupplierFormal = true;
					}
				}
			}

			if (changeSupplierFormal)
			{
				stockSlip.SupplierFormal = code;

				// 仕入形式によって買掛区分を変更する
				switch (stockSlip.SupplierFormal)
				{
					// 仕入形式が「仕入」の場合
					case 0:
						{
							if (stockSlip.StockDate == DateTime.MinValue)
							{
								stockSlip.StockDate = stockSlip.ArrivalGoodsDay;	// 仕入日付[入荷日]
							}
							this._stockSlipInputAcs.SettingAddUpDate(ref stockSlip);

							// 税率再取得
                            //-----UPD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
                            //stockSlip.SupplierConsTaxRate = this._stockSlipInputInitDataAcs.GetTaxRate(stockSlip.StockDate);
                            // 伝票転嫁の時
                            StockPriceConsTaxTotalTitleSetC(ref stockSlip, stockSlip.StockDate);
                            //-----UPD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<
                            break;
						}
					// 仕入形式が「入荷」の場合
					case 1:
						{
							stockSlip.StockGoodsCd = 0;								// 商品区分を「商品」とする
							stockSlip.StockAddUpADate = DateTime.MinValue;			// 計上日をクリアする
							stockSlip.StockDate = DateTime.MinValue;				// 仕入日をクリアする
							stockSlip.DelayPaymentDiv = 0;							// 来勘区分 = 当月
                            //-----UPD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
                            //stockSlip.SupplierConsTaxRate = this._stockSlipInputInitDataAcs.GetTaxRate(stockSlip.ArrivalGoodsDay);
                            // 伝票転嫁の時
                            StockPriceConsTaxTotalTitleSetC(ref stockSlip, stockSlip.ArrivalGoodsDay);
                            //-----UPD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<
							// 買掛無し固定
							stockSlip.AccPayDivCd = 1;
							break;
						}
				}
				
                //// 伝票区分コンボエディタアイテム設定処理
                //SetItemtSupplierSlipDisplay(stockSlip.SupplierFormal);

				// 伝票区分を取得
				stockSlip.SupplierSlipDisplay = StockSlipInputAcs.GetSupplierSlipDisplayFromSlipCdAndAccPayDivCd(stockSlip.SupplierSlipCd, stockSlip.AccPayDivCd);

				// 伝票区分、買掛区分のセット
				StockSlipInputAcs.SetSlipCdAndAccPayDivCdFromDisplay(ref stockSlip);

                // 定価・原価更新区分のセット
                StockSlipInputAcs.SetPriceCostUpdtDiv(ref stockSlip, this._stockSlipInputInitDataAcs.GetStockTtlSt().PriceCostUpdtDiv);

				// 仕入商品区分コンボエディタアイテム設定処理
				this.SetItemtStockGoodsCd(code);

                // ツールバーボタン有効無効設定処理
                this.SettingToolBarButtonEnabled();
                this.SettingToolBarButtonEnabled_Detail();


				// 仕入商品区分を取得
				stockSlip.StockGoodsCd = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_StockGoodsCd, ComboEditorGetDataType.TAG);

				if (isCache)
				{
					// 仕入データキャッシュ処理
					this._stockSlipInputAcs.Cache(stockSlip);
                }
			}

			// 仕入データクラス→画面格納処理
			this.SetDisplay(stockSlip);

			return changeSupplierFormal;
		}

		/// <summary>
		/// 仕入先変更イベントコール処理
		/// </summary>
		/// <param name="reCalcSalesMoney"></param>
		/// <returns></returns>
		private void SupplierChangedCall( bool reCalcSalesMoney )
		{
			if (this.SupplierChanged != null)
			{
				this.SupplierChanged(reCalcSalesMoney);
			}
		}

		/// <summary>
		/// 伝票区分変更処理
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="isCache">True:キャッシュ有り</param>
		/// <returns>True:変更有り</returns>
		private bool ChageSupplierSlipDisplay( ref StockSlip stockSlip, bool isCache )
		{
			bool changeSupplierSlipDisplay = false;

			int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_SupplierSlipCdDisplay, ComboEditorGetDataType.TAG);

			if (stockSlip.SupplierSlipDisplay != code)
			{
				if (code != -1)
				{
					int supplierSlipCdOrg;
					int accPayDivCdOrg;
					int supplierSlipCd;
					int accPayDivCd;

					StockSlipInputAcs.GetSlipCdAndAccPayDivCdFromSupplierSlipDisplay(stockSlip.SupplierSlipDisplay, out supplierSlipCdOrg, out accPayDivCdOrg);
					StockSlipInputAcs.GetSlipCdAndAccPayDivCdFromSupplierSlipDisplay(code, out supplierSlipCd, out accPayDivCd);

					if (( supplierSlipCd != supplierSlipCdOrg ) && ( this._stockSlipInputAcs.ExistStockDetailData() ))
					{
						DialogResult dialogResult = TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							this._stockSlipInputAcs.GetSupplierFormalName(this._stockSlipInputAcs.StockSlip) + "明細情報がクリアされます。" + "\r\n" + "\r\n" +
							"よろしいですか？",
							0,
							MessageBoxButtons.YesNo,
							MessageBoxDefaultButton.Button1);

						if (dialogResult == DialogResult.Yes)
						{
							this._stockSlipDetailInput.Clear();
							changeSupplierSlipDisplay = true;
						}
					}
					else
					{
						changeSupplierSlipDisplay = true;
					}
				}
			}

			if (changeSupplierSlipDisplay)
			{
				stockSlip.SupplierSlipDisplay = code;

				// 伝票区分、買掛区分のセット
				StockSlipInputAcs.SetSlipCdAndAccPayDivCdFromDisplay(ref stockSlip);

                // 定価・原価更新区分のセット
                StockSlipInputAcs.SetPriceCostUpdtDiv(ref stockSlip, this._stockSlipInputInitDataAcs.GetStockTtlSt().PriceCostUpdtDiv);

                // ツールバーボタン有効無効設定処理
                this.SettingToolBarButtonEnabled();
                this.SettingToolBarButtonEnabled_Detail();

				if (isCache)
				{
					// 仕入データキャッシュ処理
					this._stockSlipInputAcs.Cache(stockSlip);
                }
			}

			// 仕入データクラス→画面格納処理
			this.SetDisplay(stockSlip);

			return changeSupplierSlipDisplay;
		}

		/// <summary>
		/// 商品区分変更処理
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="isCache">True:キャッシュ有り</param>
		/// <returns>True:変更有り</returns>
		private bool ChangeStockGoodsCd( ref StockSlip stockSlip, bool isCache )
		{
			bool changeStockGoodsCd = false;

			int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_StockGoodsCd, ComboEditorGetDataType.TAG);

			if (stockSlip.StockGoodsCd != code)
			{
				if (code != -1)
				{
					if (( stockSlip.StockGoodsCd == 6 ) && ( ( this.tNedit_StockTotalPrice.GetInt() != 0 ) || ( this.tNedit_StockPriceConsTaxTotal.GetInt() != 0 ) ))
					{
						DialogResult dialogResult = TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							"金額がクリアされます。" + "\r\n" + "\r\n" +
							"よろしいですか？",
							0,
							MessageBoxButtons.YesNo,
							MessageBoxDefaultButton.Button1);

						if (dialogResult == DialogResult.Yes)
						{
							this._stockSlipDetailInput.Clear();
							changeStockGoodsCd = true;
							stockSlip.StockGoodsCd = code;
						}
					}
					// 仕入明細データ存在チェック処理
					else if (( !this.EqualsStockGoodsCdType(stockSlip.StockGoodsCd, code) ) && ( this._stockSlipInputAcs.ExistStockDetailData() ))
					{
						DialogResult dialogResult = TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							this._stockSlipInputAcs.GetSupplierFormalName(this._stockSlipInputAcs.StockSlip) + "明細情報がクリアされます。" + "\r\n" + "\r\n" +
							"よろしいですか？",
							0,
							MessageBoxButtons.YesNo,
							MessageBoxDefaultButton.Button1);

						if (dialogResult == DialogResult.Yes)
						{
							this._stockSlipDetailInput.Clear();
							changeStockGoodsCd = true;
							stockSlip.StockGoodsCd = code;
						}
					}
					else
					{
						changeStockGoodsCd = true;
					}
				}
			}

			if (changeStockGoodsCd)
			{
				stockSlip.StockGoodsCd = code;

                // 定価・原価更新区分のセット
                StockSlipInputAcs.SetPriceCostUpdtDiv(ref stockSlip, this._stockSlipInputInitDataAcs.GetStockTtlSt().PriceCostUpdtDiv);

                // ツールバーボタン有効無効設定処理
                this.SettingToolBarButtonEnabled();
                this.SettingToolBarButtonEnabled_Detail();

				if (isCache)
				{
					// 仕入データキャッシュ処理
					this._stockSlipInputAcs.Cache(stockSlip);
				}

				// グリッド設定処理（ユーザー設定より）
				this._stockSlipDetailInput.GridSetting(this._stockInputConstructionAcs.StockInputConstruction);

				if (stockSlip.StockGoodsCd == 6)
				{
					this._stockSlipInputAcs.StockDetailRowStockGoodsCdSetting(1, 6);
				}
			}

			// 仕入データクラス→画面格納処理
			this.SetDisplay(stockSlip);

			return changeStockGoodsCd;
		}

		/// <summary>
		/// 定価原価更新区分変更処理
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="isCache">True:キャッシュ有り</param>
		/// <returns>True:変更有り</returns>
		private bool ChangePriceCostUpdtDiv( ref StockSlip stockSlip, bool isCache )
		{
			bool changePriceCostUpdtDiv = false;

			int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_PriceCostUpdtDiv, ComboEditorGetDataType.TAG);

            if (code != -1)
            {
                if (stockSlip.PriceCostUpdtDiv != code)
                {
                    changePriceCostUpdtDiv = true;
                }
            }
			if (changePriceCostUpdtDiv)
			{
				stockSlip.PriceCostUpdtDiv = code;

				if (isCache)
				{
					// 仕入データキャッシュ処理
					this._stockSlipInputAcs.Cache(stockSlip);
				}

				// グリッド設定処理（ユーザー設定より）
				this._stockSlipDetailInput.GridSetting(this._stockInputConstructionAcs.StockInputConstruction);
			}

			// 仕入データクラス→画面格納処理
			this.SetDisplay(stockSlip);

			return changePriceCostUpdtDiv;
		}

		/// <summary>
		/// 仕入金額変更後発生イベント処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void StockSlipDetailInput_StockPriceChanged(object sender, EventArgs e)
		{
			this.StockSlipDetailInput_StockPriceChanged(sender, e, true);
		}

		/// <summary>
		/// 仕入金額変更後発生イベント処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void StockSlipDetailInput_StockPriceChanged( object sender, EventArgs e, bool clearTaxAdjust )
		{
			StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;

			if (stockSlip == null) return;

            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
			int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// 仕入消費税端数処理コード

			this._stockSlipInputAcs.TotalPriceSetting(ref stockSlip, clearTaxAdjust);

			// 仕入データキャッシュ処理
			this._stockSlipInputAcs.Cache(stockSlip);

			// 仕入データクラス→画面格納処理（オーバーロード）
			this.SetDisplay(stockSlip, SetDisplayMode.TotalPriceInfoOnly);
		}


		/// <summary>
		/// ステータスバーメッセージ表示イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="message">メッセージ</param>
		private void StockSlipDetailInput_StatusBarMessageSetting(object sender, string message)
		{
			this.uStatusBar_Main.Panels[0].Text = message;
		}

		/// <summary>
		/// フォーカスセッティングイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="itemName">項目名称</param>
		private void StockSlipDetailInput_FocusSetting(object sender, string itemName)
		{
			if (itemName == MAKON01110UB.ct_ITEM_NAME_CUSTOMERCODE)
			{
				this.tNedit_SupplierCd.Focus();

                this._prevControl = this.tNedit_SupplierCd;

                // ガイドボタンツール有効無効設定処理
                this.SettingGuideButtonToolEnabled(this._prevControl);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void SettingGuideButtonTool_Detail()
		{
			this._guideButton.SharedProps.Enabled = this._stockSlipDetailInput.GuideButtonEnabled;
		}

		/// <summary>
		/// 
		/// </summary>
		private void SettingToolBarButtonEnabled_Detail()
		{
			if (( this.GetActiveControl() == this._stockSlipDetailInput ) || ( this._stockSlipDetailInput.ContainsFocus ))
			{
				this._stockReferenceButton.SharedProps.Enabled = this._stockSlipDetailInput.StockReferenceButtonEnabled;
				this._arrivalAppropriateButton.SharedProps.Enabled = this._stockSlipDetailInput.ArrivalReferenceButtonEnabled;
				this._orderReferenceButton.SharedProps.Enabled = this._stockSlipDetailInput.OrderReferenceButtonEnabled;
			}
		}

		/// <summary>
		/// 仕入関連データ変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void StockSlipInputAcs_DataChanged(object sender, EventArgs e)
		{
			// ツールバーボタン有効無効設定処理
			this.SettingToolBarButtonEnabled();
			this.SettingToolBarButtonEnabled_Detail();
		}

		/// <summary>
		/// ユーザー設定値変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void StockInputConstructionAcs_DataChanged(object sender, EventArgs e)
		{
			// 仕入データクラス→画面格納処理
			this.SetDisplay(this._stockSlipInputAcs.StockSlip);
			this.SettingToolBarButtonCaption();
			this.SettingFocusDictionary();
		}

        // --- ADD 　衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御) 　---------->>>>>
		/// <summary>
		/// ユーザー設定値 保存後ロゴ表示変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 保存後ロゴ表示変更後発生イベント</br>
        /// <br>Programmer : 衛忠明</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        private void StockInputConstructionAcsLog_DataChanged(object sender, EventArgs e)
        {
            // 仕入データクラス→画面格納処理
            this.SetDisplay(this._stockSlipInputAcs.StockSlip);
            this.SettingFocusDictionary();
        }
        // --- ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御) -----------<<<<<
	
		/// <summary>
		/// ボタンツール有効無効設定処理
		/// </summary>
		/// <param name="nextControl">次のコントロール</param>
		private void SettingGuideButtonToolEnabled(Control nextControl)
		{
			if (nextControl == null) return;

			Control targetControl = nextControl;
			if (nextControl.Parent != null)
			{
				if (( nextControl.Parent is Broadleaf.Library.Windows.Forms.TNedit ) ||
					( nextControl.Parent is Broadleaf.Library.Windows.Forms.TEdit ))
				{
					targetControl = nextControl.Parent;
				}
			}

			this._guideButton.SharedProps.Enabled = false;

			// 明細部にフォーカスがある時は明細画面に従って設定する
			if (( this._stockSlipDetailInput.Contains(targetControl) ) || ( targetControl == this._stockSlipDetailInput ))
			{
				this.SettingGuideButtonTool_Detail();
			}
			else
			{
				this._arrivalAppropriateButton.SharedProps.Enabled = true;

				if (( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
					( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ) ||
					( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ArrivalAddUp ))
				{
				}
				else
				{
					if (this._guideEnableControlDictionary.ContainsKey(targetControl.Name))
					{
						this._guideButton.SharedProps.Enabled = true;
						this._guideButton.SharedProps.Tag = this._guideEnableControlDictionary[targetControl.Name];
					}
					else
					{
						this._guideButton.SharedProps.Enabled = false;
						this._guideButton.SharedProps.Tag = "";

						if (!this._guideEnableExceptControlDictionary.ContainsKey(targetControl.Name))
						{
							//this._stockSlipDetailInput.uButton_Guide.Enabled = false;
						}
					}
				}
			}
		}

		/// <summary>
		/// 終了処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		private void Close(bool isConfirm)
		{
			bool canClose = this.ShowSaveCheckDialog(isConfirm);

			if (canClose)
			{
				this.Close();
			}
		}

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <param name="isShowSaveCompletionDialog">保存完了ダイアログ表示フラグ</param>
        /// <param name="isShowConfirmDialog">登録確認ダイアログ表示フラグ</param>
		/// <returns>true:保存完了 false:未保存</returns>
        /// <remarks>
        /// <br>Update Note: 2011/08/18 XUJS</br>
        /// <br>             Redmine#23737</br>
        /// <br>             仕入伝票入力で、今回締処理中のため登録できませんのを修正する</br>
        /// <br>Update Note : 2011/12/27 陳建明</br>
        /// <br>管理番号    : 10707327-00 2012/01/25配信分</br>
        /// <br>              redmine#27374 仕入伝票入力/締済のチェックの対応</br>
        /// <br>Update Note: 2015/03/25 黄興貴</br>
        /// <br>管理番号   : 11175104-00</br>
        /// <br>           : Redmine#45073 宮田自動車商会 
        /// <br>           : 仕入伝票入力で仕入伝票番号が空白のデータが作成されるの不具合の対応</br>
        /// <br>Update Note: 2015/04/08 30757 佐々木貴英</br>
        /// <br>管理番号   : 11175104-00</br>
        /// <br>           : 仕掛№2678仕入伝票入力-仕入伝票番号空白入力時処理対応(Redmine#45073)</br>
        /// <br>           : 仕入伝票番号に空白文字のみの文字列が設定されている場合、仕入伝票番号をクリアしない不具合対応</br>
        /// <br>Update Note: 2020/02/24 田建委</br>
        /// <br>管理番号   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912消費税税率機能追加対応</br>
        /// </remarks>
        private bool Save(bool isShowSaveCompletionDialog, bool isShowConfirmDialog)
		{
			bool isSave = false;
			string warehouseCode = "";

			try
			{
				#region ●保存前初期処理

                // 一括ゼロ詰め
                this.uiSetControl1.SettingAllControlsZeroPaddedText();
                if (this._prevControl != null)
				{
                    this._changeFocusSaveCancel = true; // 2009.04.03
                    ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                    this._showErrorMsg = false;//ADD 黄興貴 2015/03/25 Redmine#45073 宮田自動車商会 仕入伝票入力で仕入伝票番号が空白のデータが作成されるの不具合の対応
					this.tArrowKeyControl1_ChangeFocus(this, e);
                    // --- ADD 黄興貴 2015/03/25 Redmine#45073 宮田自動車商会 仕入伝票入力で仕入伝票番号が空白のデータが作成されるの不具合の対応 --->>>>>
                    if (this._showErrorMsg)
                    {
                        return false;
                    }
                    // --- ADD 黄興貴 2015/03/25 Redmine#45073 宮田自動車商会 仕入伝票入力で仕入伝票番号が空白のデータが作成されるの不具合の対応 ---<<<<<
                    this._changeFocusSaveCancel = false; // 2009.04.03
				}

				this.Cursor = Cursors.WaitCursor;
				string retMessage;

				#endregion

				#region ●保存チェック
				List<string> itemNameList = new List<string>();
				List<string> itemList = new List<string>();
                List<int> errorRowNoList;
				string mainMessage;

				// 保存データチェック処理
                bool check = this._stockSlipInputAcs.CheckSaveData(out mainMessage, out itemNameList, out itemList, out errorRowNoList);

				if (!check)
				{
					StringBuilder message = new StringBuilder();
					message.Append(mainMessage);

					if (!check)
					{
						foreach (string s in itemNameList)
						{
							message.Append(s + "\r\n");
						}
					}

					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						message.ToString(),
						0,
						MessageBoxButtons.OK);

					string itemName = "";
					if (itemList.Count > 0)
					{
						itemName = itemList[0].ToString();

						// 指定フォーカス設定処理
                        this.SetControlFocus(itemName, ( errorRowNoList.Count > 0 ) ? errorRowNoList[0] : -1);
					}

                    // --- ADD 30757 佐々木貴英 2015/04/08 仕掛№2678仕入伝票入力-仕入伝票番号空白入力時処理対応(Redmine#45073) ---------------->>>>>
                    #region 保存データチェックでNGとなった項目中、クリアが必要な項目の処理
                    if (null != itemList && 0 < itemList.Count)
                    {
                        foreach (string targetName in itemList)
                        {
                            if (string.IsNullOrEmpty(targetName))
                            {
                                continue;
                            }
                            switch (targetName)
                            {
                                case "PartySaleSlipNum":
                                    // 仕入伝票番号がNGの場合
                                    {
                                        string value = this.tEdit_PartySaleSlipNum.Text;
                                        if ( !string.IsNullOrEmpty(value) && string.IsNullOrEmpty(value.Trim()) )
                                        {
                                            // 仕入伝票番号に空白文字のみの文字列が設定されている場合
                                            // 仕入伝票番号をクリアする。
                                            this.tEdit_PartySaleSlipNum.Clear();
                                        }
                                        break;
                                    }
                                default:
                                    // その他
                                    {
                                        break;
                                    }
                            }
                        }
                    }
                    #endregion //保存データチェックでNGとなった項目中、クリアが必要な項目の処理
                    // --- ADD 30757 佐々木貴英 2015/04/08 仕掛№2678仕入伝票入力-仕入伝票番号空白入力時処理対応(Redmine#45073) ----------------<<<<<

					return isSave;
				}

                if (isShowConfirmDialog)
                {
                    //-----UPD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
                    //DialogResult dialogResult = TMsgDisp.Show(
                    //    this,
                    //    emErrorLevel.ERR_LEVEL_QUESTION,
                    //    this.Name,
                    //    "登録してもよろしいですか？",
                    //    0,
                    //    MessageBoxButtons.YesNo,
                    //    MessageBoxDefaultButton.Button1);

                    string message = "登録してもよろしいですか？";
                    // 伝票転嫁・仕入先入力ありの場合（赤伝、返品、入荷計上が除き）
                    if (this._stockSlipInputAcs.StockSlip.SuppCTaxLayCd == 0 && 
                        this._stockSlipInputAcs.StockSlip.SupplierCd != 0 &&
                        this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_ArrivalAddUp &&
                        this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_Return &&
                        this._stockSlipInputAcs.StockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_Red)
                    {
                        
                        // 消費税率設定画面.消費税率が入力あり
                        if (this.uLabel_StockPriceConsTaxTotalTitle2.Visible == true)
                        {
                            message = this.uLabel_StockPriceConsTaxTotalTitle2.Text + "が設定されています。\n" + message;
                        } 
                    }
                    DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    message,
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);
                    //-----UPD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<
                    if (dialogResult == DialogResult.No)
                    {
                        return false;
                    }
                    //add 2011/12/27 陳建明 Redmine #27374----->>>>>
                    else
                    {
                        string stockAddUpDateMessage;
                        if (!this._stockSlipInputAcs.CheckStockAddUpDate(out stockAddUpDateMessage))
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                stockAddUpDateMessage.ToString(),
                                0,
                                MessageBoxButtons.OK);
                            string itemName = "StockAddUpDate";
                            // 指定フォーカス設定処理
                            this.SetControlFocus(itemName, -1);
                            return false;
                        }
                    }
                    //add 2011/12/27 陳建明 Redmine #27374-----<<<<<
                }

				#endregion

				#region ●データ調整
#if False
				//MessageBox.Show("前" + Environment.NewLine +
				//    "仕入金額計（税込み）:" + this._stockSlipInputAcs.StockSlip.StockTtlPricTaxInc.ToString() + Environment.NewLine +
				//    "仕入金額計（税抜き）:" + this._stockSlipInputAcs.StockSlip.StockTtlPricTaxExc.ToString() + Environment.NewLine +
				//    "仕入金額消費税額:" + this._stockSlipInputAcs.StockSlip.StockPriceConsTax.ToString() + Environment.NewLine +
				//    "仕入外税対象額合計:" + this._stockSlipInputAcs.StockSlip.TtlItdedStcOutTax.ToString() + Environment.NewLine +
				//    "仕入内税対象額合計:" + this._stockSlipInputAcs.StockSlip.TtlItdedStcInTax.ToString() + Environment.NewLine +
				//    "仕入非課税対象額合計:" + this._stockSlipInputAcs.StockSlip.TtlItdedStcTaxFree.ToString() + Environment.NewLine +
				//    "仕入金額消費税額（外税）:" + this._stockSlipInputAcs.StockSlip.StockOutTax.ToString() + Environment.NewLine +
				//    "仕入金額消費税額（内税）:" + this._stockSlipInputAcs.StockSlip.StckPrcConsTaxInclu.ToString() + Environment.NewLine +
				//    "仕入値引金額計（税抜き）:" + this._stockSlipInputAcs.StockSlip.StckDisTtlTaxExc.ToString() + Environment.NewLine +
				//    "仕入値引外税対象額合計:" + this._stockSlipInputAcs.StockSlip.ItdedStockDisOutTax.ToString() + Environment.NewLine +
				//    "仕入値引内税対象額合計:" + this._stockSlipInputAcs.StockSlip.ItdedStockDisInTax.ToString() + Environment.NewLine +
				//    "仕入値引非課税対象額合計:" + this._stockSlipInputAcs.StockSlip.ItdedStockDisTaxFre.ToString() + Environment.NewLine +
				//    "仕入値引消費税額（外税）:" + this._stockSlipInputAcs.StockSlip.StockDisOutTax.ToString() + Environment.NewLine +
				//    "仕入値引消費税額（内税）:" + this._stockSlipInputAcs.StockSlip.StckDisTtlTaxInclu.ToString() + Environment.NewLine);
#endif
				// 保存用仕入データ調整処理
				this._stockSlipInputAcs.AdjustStockSaveData();

#if False
				//MessageBox.Show("後" + Environment.NewLine +
				//    "仕入金額計（税込み）:" + this._stockSlipInputAcs.StockSlip.StockTtlPricTaxInc.ToString() + Environment.NewLine +
				//    "仕入金額計（税抜き）:" + this._stockSlipInputAcs.StockSlip.StockTtlPricTaxExc.ToString() + Environment.NewLine +
				//    "仕入金額消費税額:" + this._stockSlipInputAcs.StockSlip.StockPriceConsTax.ToString() + Environment.NewLine +
				//    "仕入外税対象額合計:" + this._stockSlipInputAcs.StockSlip.TtlItdedStcOutTax.ToString() + Environment.NewLine +
				//    "仕入内税対象額合計:" + this._stockSlipInputAcs.StockSlip.TtlItdedStcInTax.ToString() + Environment.NewLine +
				//    "仕入非課税対象額合計:" + this._stockSlipInputAcs.StockSlip.TtlItdedStcTaxFree.ToString() + Environment.NewLine +
				//    "仕入金額消費税額（外税）:" + this._stockSlipInputAcs.StockSlip.StockOutTax.ToString() + Environment.NewLine +
				//    "仕入金額消費税額（内税）:" + this._stockSlipInputAcs.StockSlip.StckPrcConsTaxInclu.ToString() + Environment.NewLine +
				//    "仕入値引金額計（税抜き）:" + this._stockSlipInputAcs.StockSlip.StckDisTtlTaxExc.ToString() + Environment.NewLine +
				//    "仕入値引外税対象額合計:" + this._stockSlipInputAcs.StockSlip.ItdedStockDisOutTax.ToString() + Environment.NewLine +
				//    "仕入値引内税対象額合計:" + this._stockSlipInputAcs.StockSlip.ItdedStockDisInTax.ToString() + Environment.NewLine +
				//    "仕入値引非課税対象額合計:" + this._stockSlipInputAcs.StockSlip.ItdedStockDisTaxFre.ToString() + Environment.NewLine +
				//    "仕入値引消費税額（外税）:" + this._stockSlipInputAcs.StockSlip.StockDisOutTax.ToString() + Environment.NewLine +
				//    "仕入値引消費税額（内税）:" + this._stockSlipInputAcs.StockSlip.StckDisTtlTaxInclu.ToString() + Environment.NewLine+
				//    "仕入小計：" + this._stockSlipInputAcs.StockSlip.StockSubttlPrice.ToString() + Environment.NewLine+
				//    "仕入合計：" + this._stockSlipInputAcs.StockSlip.StockTotalPrice.ToString() + Environment.NewLine);
#endif
				#endregion

				#region ●保存処理

                // セキュリティログ出力用の各フラグのセット
                // 新規？
                bool isNew = ( this._stockSlipInputAcs.StockSlip.SupplierSlipNo == 0 );
                
                List<int> stockUnitPriceChangedRowNoList;
                bool unitPriceChanged = this._stockSlipInputAcs.ExistStockUnitPriceChangedRows(out stockUnitPriceChangedRowNoList);

                List<int> stockPriceChangedRowNoList;
                bool priceChanged = this._stockSlipInputAcs.ExistStockPriceChangedRows(out stockPriceChangedRowNoList);

                bool isRedSlip = ( this._stockSlipInputAcs.StockSlip.DebitNoteDiv == 1 );

				warehouseCode = this._stockSlipInputAcs.StockSlip.WarehouseCode;
				this.Cursor = Cursors.WaitCursor;
				int status = this._stockSlipInputAcs.SaveDBData(this._enterpriseCode, this._stockSlipInputAcs.StockSlip.SupplierSlipNo, out retMessage);
                if (status != ctSTATUS_CHK_SEND_ERR) // ADD 2011/08/09 qijh
				    retMessage = "";

				#endregion

				#region ●保存後処理
				this.Cursor = Cursors.Default;

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    if (unitPriceChanged)
                    {
                        string msg = string.Empty;
                        foreach (int i in stockUnitPriceChangedRowNoList)
                        {
                            msg += ( ( string.IsNullOrEmpty(msg) ) ? "" : "、" ) + string.Format("{0}行目", i);
                        }

                        // ログ出力
                        if (MyOpeCtrl.EnabledWithLog((int)OperationCode.UnitPriceChange))
                        {
                            MyOpeCtrl.Logger.WriteOperationLog(
                                "UnitPriceChange",
                                (int)OperationCode.UnitPriceChange,
                                0,
                                string.Format("{0}伝票、仕入SEQ番号:{1}の{2}の単価を修正", this._stockSlipInputAcs.GetSupplierFormalName(this._stockSlipInputAcs.StockSlip.SupplierFormal), this._stockSlipInputAcs.StockSlip.SupplierSlipNo, msg));
                        }
                    }

                    if (priceChanged)
                    {
                        string msg = string.Empty;
                        foreach (int i in stockPriceChangedRowNoList)
                        {
                            msg += ( ( string.IsNullOrEmpty(msg) ) ? "" : "、" ) + string.Format("{0}行目", i);
                        }

                        // ログ出力
                        if (MyOpeCtrl.EnabledWithLog((int)OperationCode.PriceChange))
                        {
                            MyOpeCtrl.Logger.WriteOperationLog(
                                "PriceChange",
                                (int)OperationCode.PriceChange,
                                0,
                                string.Format("{0}伝票、仕入SEQ番号:{1}の{2}の金額を修正", this._stockSlipInputAcs.GetSupplierFormalName(this._stockSlipInputAcs.StockSlip.SupplierFormal), this._stockSlipInputAcs.StockSlip.SupplierSlipNo, msg));
                        }
                    }

                    if (isRedSlip)
                    {
                        // ログ出力
                        if (MyOpeCtrl.EnabledWithLog((int)OperationCode.RedSlip))
                        {
                            MyOpeCtrl.Logger.WriteOperationLog(
                                "Revision",
                                (int)OperationCode.RedSlip,
                                0,
                                string.Format("{0}伝票、仕入SEQ番号:{1}の赤伝を作成（仕入SEQ番号:{2}）", this._stockSlipInputAcs.GetSupplierFormalName(this._stockSlipInputAcs.StockSlip.SupplierFormal), this._stockSlipInputAcs.StockSlip.DebitNLnkSuppSlipNo, this._stockSlipInputAcs.StockSlip.SupplierSlipNo));
                        }
                    }

                    if (!isNew)
                    {
                        // ログ出力
                        if (MyOpeCtrl.EnabledWithLog((int)OperationCode.Revision))
                        {
                            MyOpeCtrl.Logger.WriteOperationLog(
                                "Revision",
                                (int)OperationCode.Revision,
                                0,
                                string.Format("{0}伝票、仕入SEQ番号:{1}を修正", this._stockSlipInputAcs.GetSupplierFormalName(this._stockSlipInputAcs.StockSlip.SupplierFormal), this._stockSlipInputAcs.StockSlip.SupplierSlipNo));
                        }
                    }

                    //// 伝票発行
                    //this.PrintSlip(true);

					this.uLabel_BeforeSupplierSlipNo.Text = this._stockSlipInputAcs.StockSlip.SupplierSlipNo.ToString().PadLeft(9, '0');
					this.uLabel_BeforePartySaleSlipNum.Text = this._stockSlipInputAcs.StockSlip.PartySaleSlipNum.Trim();

					this._stockSlipDetailInput.uGrid_Details.BeginUpdate();

                    StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;

                    // 表示用伝票区分設定処理
                    StockSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref stockSlip);

					// 仕入データクラス→画面格納処理
					this.SetDisplay(this._stockSlipInputAcs.StockSlip);

					// 入荷計上伝票の場合は空白行を削除する
					if (this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ArrivalAddUp)
					{
						this._stockSlipDetailInput.DeleteEmptyRow(true);
					}

					this._stockSlipDetailInput.uGrid_Details.EndUpdate();

					// 明細グリッド設定処理
					this._stockSlipDetailInput.SettingGrid();

					if (isShowSaveCompletionDialog)
					{
						SaveCompletionDialog dialog = new SaveCompletionDialog();

                        //dialog.ShowDialog(2); // DEL 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御)
                        // ---ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御)  ------->>>>>
                        if (this._stockInputConstructionAcsLog.LogoDispValue == 0) 
                        {
                            dialog.ShowDialog(this._stockInputConstructionAcsLog.LogoDispTimeValue);
                        }
                        // ---ADD 衛忠明 2014/09/01　For redmine #43374 仕入伝票入力(保存後ロゴ表示制御)  -------<<<<<

                        // ---ADD 2015/02/24 河原林　一生　仕掛一覧No.2200 保存完了ダイアログのインスタンス解放漏れ修正 --------------->>>>>
                        dialog.Dispose();
                        dialog = null;
                        // ---ADD 2015/02/24 河原林　一生　仕掛一覧No.2200 保存完了ダイアログのインスタンス解放漏れ修正 ---------------<<<<<
					}

					if (this._stockInputConstructionAcs.SaveInfoStoreValue == StockSlipInputConstructionAcs.SaveInfoStore_ON)
					{
						// FIXME:仕入入力用初期値クラスをシリアライズ
						this._stockSlipInputInitData.EnterpriseCode = this._stockSlipInputAcs.StockSlip.EnterpriseCode;
						this._stockSlipInputInitData.SectionCode = this._stockSlipInputAcs.StockSlip.StockSectionCd;
						this._stockSlipInputInitData.SupplierCode = this._stockSlipInputAcs.StockSlip.SupplierCd;
						this._stockSlipInputInitData.WarehouseCode = warehouseCode;
                        // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ---------->>>>>
                        if (this._stockInputConstructionAcs.SaveAgentStoreValue == StockSlipInputConstructionAcs.SaveAgentStore_ON)
                        {
                            this._stockSlipInputInitData.StockAgentCode = this._stockSlipInputAcs.StockSlip.StockAgentCode;
                        }
                        // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ----------<<<<<
						this._stockSlipInputInitData.Serialize();
					}
                    // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ---------->>>>>
                    else if (this._stockInputConstructionAcs.SaveAgentStoreValue == StockSlipInputConstructionAcs.SaveAgentStore_ON)
                    {
                        this._stockSlipInputInitData.StockAgentCode = this._stockSlipInputAcs.StockSlip.StockAgentCode;
                        this._stockSlipInputInitData.Serialize();
                    }
                    // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ----------<<<<<

					isSave = true;
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)				// 排他（別端末更新済）
				{
					// 仕入担当にフォーカスをセット（一時的に）
					this.tEdit_StockAgentCode.Focus();

					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"現在、編集中の仕入データは既に更新されています。" + "\r\n" + "\r\n" +
						"最新の情報を取得します。",
						-1,
						MessageBoxButtons.OK);

					// 再読込処理
					this.ReLoad(this._stockSlipInputAcs.StockSlip.EnterpriseCode, this._stockSlipInputAcs.StockSlip.SupplierFormal, this._stockSlipInputAcs.StockSlip.SupplierSlipNo);

					this.timer_InitialSetFocus.Enabled = true;
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)				// 排他（別端末物理削除済）
				{
					// 仕入担当にフォーカスをセット（一時的に）
					this.tEdit_StockAgentCode.Focus();

					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"現在、編集中の仕入データは既に削除されています。",
						-1,
						MessageBoxButtons.OK);

                    this.Clear(false, true);

					this.timer_InitialSetFocus.Enabled = true;
				}
				else if (status == 999)																// 排他（別端末更新済）
				{
					// 仕入担当にフォーカスをセット（一時的に）
					this.tEdit_StockAgentCode.Focus();

					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"保存に失敗しました。" + retMessage + "\r\n" + "\r\n" +
                        "申し訳ありませんが、再度処理を行って下さい。",
						-1,
						MessageBoxButtons.OK);

                    this.Clear(false, true);

					this.timer_InitialSetFocus.Enabled = true;
				}
				else if (status == 811)
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_STOPDISP,
						this.Name,
						"保存に失敗しました。（タイムアウトエラー）" + "\r\n" + "\r\n" + retMessage,
						status,
						MessageBoxButtons.OK);
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "保存に失敗しました。" + "\r\n"
                        + "\r\n" +
                        "シェアチェックエラー（企業ロック）です。" + "\r\n" +
                        "月次処理か、その他の業務を行っているため本処理は行えません。" + "\r\n" +
                        "再試行するか、しばらく待ってから再度処理を行ってください。",
                        status,
                        MessageBoxButtons.OK);
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "保存に失敗しました。" + "\r\n"
                        + "\r\n" +
                        "シェアチェックエラー（拠点ロック）です。" + "\r\n" +
                        "締処理か、処理が込み合っているためタイムアウトしました。" + "\r\n" +
                        "再試行するか、しばらく待ってから再度処理を行ってください。",
                        status,
                        MessageBoxButtons.OK);
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "保存に失敗しました。" + "\r\n"
                        + "\r\n" +
                        "シェアチェックエラー（倉庫ロック）です。" + "\r\n" +
                        "棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。" + "\r\n" +
                        "再試行するか、しばらく待ってから再度処理を行ってください。",
                        status,
                        MessageBoxButtons.OK);
                }
                // ADD 2011/07/30 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                else if (status == ctSTATUS_CHK_SEND_ERR)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        ctMSG_CHK_SEND_ERR,
                        status,
                        MessageBoxButtons.OK);
                }
                // ADD 2011/07/30 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
                // 2011/08/18 XUJS ADD STA------>>>>>>
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ADU_LOCK_TIMEOUT)
                {
                    //---------------------------------------------------------------
                    // 締次ロックタイムアウトエラー
                    //---------------------------------------------------------------
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "対象の期間を集計処理中のため中断しました。" + "\r\n" +
                        "計上日を変更して、再度処理を実行して下さい。" + "\r\n",
                        status,
                        MessageBoxButtons.OK);
                }
                // 2011/08/18 XUJS ADD END------<<<<<<
                else
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_STOPDISP,
						this.Name,
						"保存に失敗しました。" + "\r\n" + "\r\n" + retMessage,
						status,
						MessageBoxButtons.OK);  
				}
				#endregion
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}

			this._prevControl = this.ActiveControl;
			return isSave;
		}

		/// <summary>
		/// 伝票印刷
		/// </summary>
		/// <param name="printWithoutDialog">True:印刷ダイアログを表示しない</param>
		private void PrintSlip( bool printWithoutDialog )
		{
			#region ●処理対象チェック
			if (( this._stockSlipInputAcs.StockSlip.SupplierFormal != 0 ) ||
				( this._stockSlipInputAcs.StockSlip.SupplierSlipCd != 20 ) ||
				( this._stockSlipInputInitDataAcs.GetStockTtlSt().RgdsSlipPrtDiv == 0 ))
			{
				return;
			}
			#endregion

			#region ●初期処理
			DCCMN02000UA printDisp = new DCCMN02000UA();													// 伝票印刷情報設定画面インスタンス生成
			StockSlipPrintCndtn.StockSlipKey key = new StockSlipPrintCndtn.StockSlipKey();					// 伝票印刷用Keyインスタンス生成
			List<StockSlipPrintCndtn.StockSlipKey> keyList = new List<StockSlipPrintCndtn.StockSlipKey>();	// 伝票印刷用KeyListインスタンス生成
			#endregion  

			#region ●仕入伝票Key情報セット
			key.SupplierFormal = this._stockSlipInputAcs.StockSlip.SupplierFormal;
			key.SupplierSlipNo = this._stockSlipInputAcs.StockSlip.SupplierSlipNo;
			keyList.Add(key);
			#endregion

			#region ●印刷情報パラメータセット
			StockSlipPrintCndtn stockSlipPrintCndtn = new StockSlipPrintCndtn();
			stockSlipPrintCndtn.EnterpriseCode = this._enterpriseCode;
			stockSlipPrintCndtn.StockSlipKeyList = keyList;
			#endregion

			#region ●印刷処理
			printDisp.ShowDialog(stockSlipPrintCndtn, printWithoutDialog);
			#endregion
		}

		/// <summary>
		/// 元に戻す処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		private void Retry(bool isConfirm)
		{
			this.Retry(isConfirm, this._stockSlipInputAcs.StockSlip.SupplierFormal, this._stockSlipInputAcs.StockSlip.SupplierSlipNo);
		}

		/// <summary>
		/// 再読込処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="supplierFormal">仕入形式</param>
		/// <param name="supplierSlipNo">仕入伝票番号</param>
		private bool ReLoad(string enterpriseCode, int supplierFormal, int supplierSlipNo)
		{
			bool isSuccess = false;
            StockSlip baseStockSlip; // 2009.03.25
			
			// データリード処理
			this.Cursor = Cursors.WaitCursor;
            //int status = this._stockSlipInputAcs.ReadDBData(enterpriseCode, supplierFormal, supplierSlipNo); // 2009.03.25
            int status = this._stockSlipInputAcs.ReadDBData(enterpriseCode, supplierFormal, supplierSlipNo, out baseStockSlip); // 2009.03.25
            this.Cursor = Cursors.Default;

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				StockSlip stockSlip = this._stockSlipInputAcs.StockSlip.Clone();

				// 仕入データ入力モード設定処理
				this.SettingStockSlipInputMode(ref stockSlip);

                // 表示用伝票区分の設定
                StockSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref stockSlip);

				// 仕入データクラス→画面格納処理
				this.SetDisplay(stockSlip);

				// 仕入データキャッシュ処理
				this._stockSlipInputAcs.Cache(stockSlip);

				// 入荷計上伝票、赤伝の場合は空白行を削除する
				if (( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ArrivalAddUp ) || ( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red ))
				{
					this._stockSlipDetailInput.DeleteEmptyRow(true);
				}

				// 明細グリッド設定処理
				this._stockSlipDetailInput.SettingGrid();

				if (( this._stockSlipDetailInput.Enabled ) && ( stockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_Red ))
				{
					this._stockSlipDetailInput.Focus();
				}
				else
				{
					//this.tEdit_SupplierSlipNote1.Focus();  //DEL 2011/11/30 gezh redmine#8383
                    this.tNedit_SupplierSlipNote1.Focus();   //ADD 2011/11/30 gezh redmine#8383
                }

				isSuccess = true;
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"該当するデータが存在しません。",
					-1,
					MessageBoxButtons.OK);
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"仕入・入荷データの取得に失敗しました。",
					status,
					MessageBoxButtons.OK);
			}

			return isSuccess;
		}

		/// <summary>
		/// 元に戻す処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		/// <param name="supplierFormal">仕入形式</param>
		/// <param name="supplierSlipNo">仕入伝票番号</param>
		private void Retry(bool isConfirm, int supplierFormal, int supplierSlipNo)
		{
			if ((isConfirm) && (this._stockSlipInputAcs.IsDataChanged))
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
					"初期状態に戻しますか？",
					0,
					MessageBoxButtons.YesNo,
					MessageBoxDefaultButton.Button1);

				if (dialogResult != DialogResult.Yes)
				{
                    this._returnFlag = false;// ADD 黄興貴 2015/04/01 Redmine#45073 障害No.179
					return;
				}
			}

			// 画面初期化処理
			this.Clear(false, false);

			if (supplierSlipNo != 0)
			{
                StockSlip baseStockSlip; // 2009.03.25

				// データリード処理
				this.Cursor = Cursors.WaitCursor;
                //int status = this._stockSlipInputAcs.ReadDBData(this._enterpriseCode, supplierFormal, supplierSlipNo); // 2009.03.25
                int status = this._stockSlipInputAcs.ReadDBData(this._enterpriseCode, supplierFormal, supplierSlipNo, out baseStockSlip); // 2009.03.25
                this.Cursor = Cursors.Default;

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;

                    StockSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref stockSlip);

					// 仕入データクラス→画面格納処理
					this.SetDisplay(stockSlip);

					// 明細グリッド設定処理
					this._stockSlipDetailInput.SettingGrid();
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"該当する仕入データが存在しません。",
						-1,
						MessageBoxButtons.OK);
				}
				else
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_STOPDISP,
						this.Name,
						"仕入データの取得に失敗しました。",
						status,
						MessageBoxButtons.OK);
				}
			}
		}

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		/// <param name="keepSupplierFormal">true:仕入形式を保持する false:保持しない</param>
		/// <returns>true:初期化実行 false:初期化未実行</returns>
		private bool Clear( bool isConfirm, bool keepSupplierFormal )
		{
            // DEL 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ---------->>>>>
            // HACK:入力区分の保持フラグを省略したときは？←return this.Clear(isConfirm, keepSupplierFormal, false);
            // DEL 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ----------<<<<<
            return this.Clear(isConfirm, keepSupplierFormal, false, keepSupplierFormal);    // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加
		}

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		/// <param name="keepSupplierFormal">true:仕入形式を保持する false:保持しない</param>
		/// <param name="keepDate">true:日付を保持する false:保持しない</param>
		/// <returns>true:初期化実行 false:初期化未実行</returns>
        /// <remarks>
        /// <br>Update Note : 2020/02/24 田建委</br>
        /// <br>管理番号    : 11570208-00</br>
        /// <br>            : PMKOBETSU-2912消費税税率機能追加対応</br>
        /// </remarks>
		private bool Clear(bool isConfirm, bool keepSupplierFormal, bool keepDate, bool keepStockGoodsCd)
		{
			try
			{
				if ((isConfirm) && (this._stockSlipInputAcs.IsDataChanged))
				{
					DialogResult dialogResult = TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						"現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
						"初期状態に戻しますか？",
						0,
						MessageBoxButtons.YesNo,
						MessageBoxDefaultButton.Button1);

					if (dialogResult != DialogResult.Yes)
					{
						return false;
					}
				}

				// 仕入形式を保持
				int prevSupplierFormal = this._stockSlipInputAcs.StockSlip.SupplierFormal;

                // 入力区分を保持
                int prevStockGoodsCd = this._stockSlipInputAcs.StockSlip.StockGoodsCd;  // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加

				// 仕入形式を再設定
				if (keepSupplierFormal)
				{
					// 仕入形式が「入荷」の場合は商品区分は「商品」固定
					int stockGoodsCode = ( prevSupplierFormal == 1 ) ? 0 : this._stockInputConstructionAcs.StockInputConstruction.StockGoodsCdValue;

                    // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ---------->>>>>
                    // 入力区分を保持
                    if (keepStockGoodsCd)
                    {
                        stockGoodsCode = prevStockGoodsCd;
                    }
                    // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ----------<<<<<

					// 仕入データ初期インスタンス取得処理
					this._stockSlipInputAcs.CreateStockSlipInitialData(prevSupplierFormal, 1, stockGoodsCode, keepDate);

					this._stockSlipInputAcs.StockSlip.SupplierFormal = prevSupplierFormal;

                    // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ---------->>>>>
                    // 入力区分を保持
                    if (keepStockGoodsCd)
                    {
                        this._stockSlipInputAcs.StockSlip.StockGoodsCd = prevStockGoodsCd;
                    }
                    // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ----------<<<<<
				}
				else
				{
                    // DEL 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ---------->>>>>
                    //// 仕入データ初期インスタンス取得処理
                    //this._stockSlipInputAcs.CreateStockSlipInitialData(this._stockInputConstructionAcs.StockInputConstruction.SupplierFormalValue, 1, this._stockInputConstructionAcs.StockInputConstruction.StockGoodsCdValue, keepDate);
                    // DEL 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ----------<<<<<
                    // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ---------->>>>>
                    // 入力区分を保持
                    if (!keepStockGoodsCd)
                    {
                        // 仕入データ初期インスタンス取得処理
                        this._stockSlipInputAcs.CreateStockSlipInitialData(this._stockInputConstructionAcs.StockInputConstruction.SupplierFormalValue, 1, this._stockInputConstructionAcs.StockInputConstruction.StockGoodsCdValue, keepDate);
                    }
                    else
                    {
                        // 仕入データ初期インスタンス取得処理
                        this._stockSlipInputAcs.CreateStockSlipInitialData(this._stockInputConstructionAcs.StockInputConstruction.SupplierFormalValue, 1, prevStockGoodsCd, keepDate);
                        this._stockSlipInputAcs.StockSlip.StockGoodsCd = prevStockGoodsCd;
                    }
                    // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加 ----------<<<<<
                }

				// 前回使用した値を初期表示する
				StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;
				this.SettingInitData(stockSlip);

				// 税率取得の対象は、仕入形式によって変更(仕入：仕入日、入荷：入荷日）
				DateTime targetdate = ( stockSlip.SupplierFormal == 0 ) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay;
                //-----UPD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
                //stockSlip.SupplierConsTaxRate = this._stockSlipInputInitDataAcs.GetTaxRate(targetdate);
                // 伝票転嫁の時
                StockPriceConsTaxTotalTitleSetC(ref stockSlip, targetdate);
                //-----UPD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<
                //// 伝票区分コンボエディタアイテム設定処理
                //SetItemtSupplierSlipDisplay(stockSlip.SupplierFormal);

				// 伝票区分を取得
				//stockSlip.SupplierSlipDisplay = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_SupplierSlipCdDisplay, ComboEditorGetDataType.TAG);
                // 伝票区分を取得
                stockSlip.SupplierSlipDisplay = StockSlipInputAcs.GetSupplierSlipDisplayFromSlipCdAndAccPayDivCd(stockSlip.SupplierSlipCd, stockSlip.AccPayDivCd);
                //// 伝票区分、買掛区分のセット
                //StockSlipInputAcs.SetSlipCdAndAccPayDivCdFromDisplay(ref stockSlip);

                // 定価・原価更新区分のセット
                StockSlipInputAcs.SetPriceCostUpdtDiv(ref stockSlip, this._stockSlipInputInitDataAcs.GetStockTtlSt().PriceCostUpdtDiv);

                // 仕入商品区分コンボエディタアイテム設定処理
				this.SetItemtStockGoodsCd(stockSlip.SupplierFormal);
			}
			catch (ApplicationException ae)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOP,
					this.Name,
					ae.Message,
					4,
					MessageBoxButtons.OK);

				return false;
			}

			//// 拠点コンボエディタ選択値設定処理
			//this._stockSlipInputInitDataAcs.SetSectionComboEditorValue(this._sectionComboBox, this._loginSectionCode);
			//try
			//{
			//    this._stockSlipInputAcs.StockSlip.StockSectionCd = this._sectionComboBox.ValueList.ValueListItems[this._sectionComboBox.SelectedIndex].DataValue.ToString();

			//    this._stockSlipInputAcs.Cache(this._stockSlipInputAcs.StockSlip);
			//}
			//catch { }

			// 仕入データクラス→画面格納処理
			this.SetDisplay(this._stockSlipInputAcs.StockSlip);

			// 仕入入力明細クリア処理
			this._stockSlipDetailInput.Clear();

			// データ変更フラグプロパティをfalseにする
			this._stockSlipInputAcs.IsDataChanged = false;

			return true;
		}

        //-----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
        /// <summary>
        /// 消費税率再設定
        /// </summary>
        /// <param name="stockSlip">仕入データ</param>
        /// <param name="targetdate">仕入日OR入荷日</param>
        /// <remarks> 
        /// <br>Note       : 消費税率再設定を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void StockPriceConsTaxTotalTitleSetC(ref StockSlip stockSlip, DateTime targetdate)
        {
            bool check = false;
            // 伝票転嫁・仕入先入力ありの場合（伝票呼び出すが除き）
            if (stockSlip.SuppCTaxLayCd == 0 && stockSlip.SupplierSlipNo == 0 && stockSlip.SupplierCd != 0)
            {
                taxRateSetMaster = this._stockSlipInputInitDataAcs.GetTaxRate(targetdate);
                // 消費税率設定画面.消費税率が入力あり
                if (this._stockSlipInputInitDataAcs.TaxRateValue != 0 && taxRateSetMaster != this._stockSlipInputInitDataAcs.TaxRateValue)
                {
                    stockSlip.SupplierConsTaxRate = this._stockSlipInputInitDataAcs.TaxRateValue;
                    this.uLabel_StockPriceConsTaxTotalTitle2.Text = "税(" + (this._stockSlipInputInitDataAcs.TaxRateValue * 100).ToString() + "%" + ")";
                    this.uLabel_StockPriceConsTaxTotalTitle.Visible = false;
                    this.uLabel_StockPriceConsTaxTotalTitle2.Visible = true;
                    this.uLabel_StockPriceConsTaxTotalTitle2.SendToBack();
                    check = true;
                }
            }
            // 伝票転嫁・仕入先入力あり(伝票呼出)の場合
            else if (stockSlip.SuppCTaxLayCd == 0 && stockSlip.SupplierSlipNo != 0 && stockSlip.SupplierCd != 0)
            {
                // 軽減税率の場合
                if (slipSrcTaxFlg == true)
                {
                    check = true;
                }
            }

            if (check == false)
            {
                stockSlip.SupplierConsTaxRate = this._stockSlipInputInitDataAcs.GetTaxRate(targetdate);
                this.uLabel_StockPriceConsTaxTotalTitle.Visible = true;
                this.uLabel_StockPriceConsTaxTotalTitle2.Visible = false;
                DisplayNameSetting();
            }
        }

        /// <summary>
        /// 消費税率再設定
        /// </summary>
        /// <param name="stockSlip">仕入データ</param>
        /// <param name="targetdate">仕入日OR入荷日</param>
        /// <remarks>
        /// <br>Note       : 消費税率再設定を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void StockPriceConsTaxTotalTitleSet(StockSlip stockSlip, DateTime targetdate, out double taxRate)
        {
            bool check = false;
            taxRate = 0;
            // 新規伝票転嫁・仕入先入力ありの場合
            if (stockSlip.SuppCTaxLayCd == 0 && stockSlip.SupplierSlipNo == 0 && stockSlip.SupplierCd != 0)
            {
                // 税率取得の対象は、仕入形式によって変更(仕入：仕入日、入荷：入荷日）
                DateTime targetdateCur = (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay;
                taxRateSetMaster = this._stockSlipInputInitDataAcs.GetTaxRate(targetdateCur);
                // 消費税率設定画面.消費税率が入力あり
                if (this._stockSlipInputInitDataAcs.TaxRateValue != 0 && taxRateSetMaster != this._stockSlipInputInitDataAcs.TaxRateValue)
                {
                    taxRate = this._stockSlipInputInitDataAcs.TaxRateValue;
                    this.uLabel_StockPriceConsTaxTotalTitle2.Text = "税(" + (this._stockSlipInputInitDataAcs.TaxRateValue * 100).ToString() + "%" + ")";
                    this.uLabel_StockPriceConsTaxTotalTitle.Visible = false;
                    this.uLabel_StockPriceConsTaxTotalTitle2.Visible = true;
                    this.uLabel_StockPriceConsTaxTotalTitle2.SendToBack();
                    check = true;
                }
            }
            // 伝票転嫁・仕入先入力あり(伝票呼出)の場合
            else if (stockSlip.SuppCTaxLayCd == 0 && stockSlip.SupplierSlipNo != 0 && stockSlip.SupplierCd != 0)
            {
                // 軽減税率の場合
                if (slipSrcTaxFlg == true)
                {
                    taxRate = stockSlip.SupplierConsTaxRate;
                    check = true;
                }
            }

            if (check == false)
            {
                taxRate = this._stockSlipInputInitDataAcs.GetTaxRate(targetdate);
                this.uLabel_StockPriceConsTaxTotalTitle.Visible = true;
                this.uLabel_StockPriceConsTaxTotalTitle2.Visible = false;
                DisplayNameSetting();
            }
        }

        /// <summary>
        /// メッセージ表示
        /// </summary>
        /// <param name="stockSlip">仕入データ</param>
        /// <param name="taxRate">税率</param>
        /// <remarks>
        /// <br>Note       : メッセージ表示を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void ShowMessage(StockSlip stockSlip, double taxRate)
        {
            string message = string.Format("修正元伝票に税率({0}%)が設定されています。\r\n税率({0}%)で設定します。", taxRate * 100);

            // 伝票転嫁・仕入先入力ありの場合
            if (stockSlip.SuppCTaxLayCd == 0 && stockSlip.SupplierCd != 0)
            {
                // 税率取得の対象は、仕入形式によって変更(仕入：仕入日、入荷：入荷日）
                DateTime targetdate = (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay;
                taxRateSetMaster = this._stockSlipInputInitDataAcs.GetTaxRate(targetdate);

                // 消費税率設定画面設定あり、当該伝票の税率≠手入力税率の場合
                // あるいは消費税率設定画面設定あり、当該伝票の税率≠税率マスタ税率の場合
                if ((this._stockSlipInputInitDataAcs.TaxRateValue != 0 && taxRate != this._stockSlipInputInitDataAcs.TaxRateValue) ||
                    (this._stockSlipInputInitDataAcs.TaxRateValue == 0 && taxRate != taxRateSetMaster))
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        message.ToString(),
                        0,
                        MessageBoxButtons.OK);

                    this._stockSlipInputInitDataAcs.TaxRateValue = taxRate;
                }
            }

        }
        //-----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<

		/// <summary>
		/// 商品区分タイプ比較処理
		/// </summary>
		/// <param name="stockGoodsCd1">商品区分1</param>
		/// <param name="stockGoodsCd2">商品区分2</param>
		/// <returns>true:同一タイプ false:異なるタイプ</returns>
		private bool EqualsStockGoodsCdType(int stockGoodsCd1, int stockGoodsCd2)
		{
			bool equals = false;

			if (stockGoodsCd1 == stockGoodsCd2)
			{
				equals = true;
			}
			else
			{
				equals = false;
			}

			return equals;
		}

		/// <summary>
		/// ツールバーボタン有効無効設定処理
		/// </summary>
		private void SettingToolBarButtonEnabled()
		{
            bool canSave = false;
            bool canRetry = false;
            bool canDeleteSlip = false;
            bool canStockReference = false;
            bool canOrderReference = false;

            try
            {
                if (( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
                    ( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ))
                {
                    canSave = false;
                    canRetry = false;
                    canDeleteSlip = false;
                }
                else
                {
                    canSave = true;
                    canRetry = this._stockSlipInputAcs.IsDataChanged;

                    if (this._stockSlipInputAcs.StockSlip.SupplierSlipNo == 0)
                    {
                        canDeleteSlip = false;
                    }
                    else
                    {
                        //if ((this._stockSlipInputAcs.StockSlip.DebitNoteDiv == 2) || (this._stockSlipInputAcs.StockSlip.TrustAddUpSpCd == 2))
                        if (this._stockSlipInputAcs.StockSlip.DebitNoteDiv == 2)
                        {
                            canDeleteSlip = false;
                        }
                        else
                        {
                            canDeleteSlip = true; 
                        }
                    }
                }


                if (( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red ) ||
                    ( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Return ) ||
                    ( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
                    ( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ArrivalAddUp ) ||
                    ( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ))
                {
                    canStockReference = false;
                    canOrderReference = false;
                }
                else
                {
                    if (( this._stockSlipInputAcs.StockSlip.SupplierSlipCd == 10 ) &&
                        ( this._stockSlipInputAcs.StockSlip.StockGoodsCd == 0 ))
                    {
                        canOrderReference = true;
                    }
                    else
                    {
                        canOrderReference = false;
                    }

                    if (this._stockSlipInputAcs.StockSlip.StockGoodsCd == 0)
                    {
                        canStockReference = true;
                    }
                    else
                    {
                        canStockReference = false;
                    }
                }
            }
            finally
            {
                this._saveButton.SharedProps.Enabled = canSave;
                this._retryButton.SharedProps.Enabled = canRetry;
                this._deleteSlipButton.SharedProps.Enabled = canDeleteSlip;
                this._stockReferenceButton.SharedProps.Enabled = canStockReference;
                this._orderReferenceButton.SharedProps.Enabled = canOrderReference;
            }
		}

        // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ツールバーキャプション設定
        /// </summary>
        /// <param name="ctrl"></param>
        private void SettingToolBarButtonCaption(Control ctrl)
        {
            if (ctrl == null) return;

            string subCaption = this.tToolbarsManager_MainMenu.Tools[_saveButton.Key].SharedProps.Shortcut.ToString();
            subCaption = "(" + subCaption + ")";

            if ((this.panel_Header.Contains(ctrl)) ||
                (this.panel_Detail.Contains(ctrl)))
            {
                this.tToolbarsManager_MainMenu.Tools[_saveButton.Key].SharedProps.Caption = ctDecision + subCaption;
                this.tToolbarsManager_MainMenu.Tools[_saveButton.Key].SharedProps.ToolTipText = ctDecisionToolTipText;
            }
            else
            {
                this.tToolbarsManager_MainMenu.Tools[_saveButton.Key].SharedProps.Caption = ctSave + subCaption;
                this.tToolbarsManager_MainMenu.Tools[_saveButton.Key].SharedProps.ToolTipText = ctSaveToolTipText;
            }
        }
        // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
		/// ツールバーキャプション設定
		/// </summary>
		private void SettingToolBarButtonCaption()
		{
			//this._toolBarCaptionAcs.GetToolbarCaptionsFileInfoList();
			//this._toolBarCaptionAcs.SettingToolBarCaptions(1, ctAssemblyName, ref this.tToolbarsManager_MainMenu);
		}

		/// <summary>
		/// 画面項目名称設定処理
		/// </summary>
		private void DisplayNameSetting()
		{
			this.uLabel_StockPriceConsTaxTotalTitle.Text = this._stockSlipInputInitDataAcs.GetTaxRateName();
            if (this.uLabel_StockPriceConsTaxTotalTitle.Text.Length > 5)
            {
                this.uLabel_StockPriceConsTaxTotalTitle.Text = this.uLabel_StockPriceConsTaxTotalTitle.Text.Substring(0, 5);
            }

            this._loginSectionNameLabel.SharedProps.Caption = this._stockSlipInputInitDataAcs.OwnSectionName;
		}

		/// <summary>
		/// 指定フォーカス設定処理
		/// </summary>
        /// <param name="ddID">対象DD</param>
        /// <param name="rowNo">行番号</param>
        private void SetControlFocus( string ddID, int rowNo )
		{
            if (ddID == "StockSectionCd")
            {
                this.tEdit_SectionCode.Focus();
                this._prevControl = this.tEdit_SectionCode;
            }
            else if (ddID == "StockAgentCode")
			{
				this.tEdit_StockAgentCode.Focus();
                this._prevControl = this.tEdit_StockAgentCode;
            }
            else if (ddID == "SupplierCd")
			{
				this.tNedit_SupplierCd.Focus();
                this._prevControl = this.tNedit_SupplierCd;
            }
			else if (ddID == "ArrivalGoodsDay")
			{
				this.tDateEdit_ArrivalGoodsDay.Focus();
                this._prevControl = this.tDateEdit_ArrivalGoodsDay;
            }
			else if (ddID == "StockAddUpDate")
			{
				if (this.tDateEdit_StockDate.Enabled)
				{
					this.tDateEdit_StockDate.Focus();
                    this._prevControl = this.tDateEdit_StockDate;
                }
				else
				{
					this.tEdit_StockAgentCode.Focus();
                    this._prevControl = this.tEdit_StockAgentCode;
                }
			}
            else if (ddID == "RetGoodsReason")
            {
                this.tEdit_RetGoodsReason.Focus();
                this._prevControl = this.tEdit_RetGoodsReason;
            }
            else if (ddID == "PartySaleSlipNum")
            {
                this.tEdit_PartySaleSlipNum.Focus();
                this._prevControl = this.tEdit_PartySaleSlipNum;
            }
            // 2009.06.17 Add >>>
            else if (ddID == "StockTotalPrice")
            {
                this.tNedit_StockTotalPrice.Focus();
                this._prevControl = this.tNedit_StockTotalPrice;
            }
            // 2009.06.17 Add <<<
            //else if (ddID.Contains("StockDetail"))
            else if (ddID.Contains(this._stockSlipInputAcs.StockDetailDataTable.TableName))
            {

                this._stockSlipDetailInput.Focus();

                //if (ddID.Contains("StockCountDisplay"))
                if (ddID.Contains(this._stockSlipInputAcs.StockDetailDataTable.StockCountDisplayColumn.ColumnName))
                {
                    this._stockSlipDetailInput.SettingActiveCell(MAKON01110UB.ct_SettingActiveCell_StockCountError, rowNo);
                }
                //else if (ddID.Contains("StockUnitPriceDisplay"))
                else if (ddID.Contains(this._stockSlipInputAcs.StockDetailDataTable.StockUnitPriceDisplayColumn.ColumnName))
                {
                    this._stockSlipDetailInput.SettingActiveCell(MAKON01110UB.ct_SettingActiveCell_StockUnitPriceError, rowNo);
                }
                //else if (ddID.Contains("StockPriceDisplay"))
                else if (ddID.Contains(this._stockSlipInputAcs.StockDetailDataTable.StockPriceDisplayColumn.ColumnName))
                {
                    this._stockSlipDetailInput.SettingActiveCell(MAKON01110UB.ct_SettingActiveCell_StockPriceError, rowNo);
                }
                else if (ddID.Contains(this._stockSlipInputAcs.StockDetailDataTable.GoodsNameColumn.ColumnName))
                {
                    this._stockSlipDetailInput.SettingActiveCell(MAKON01110UB.ct_SettingActiveCell_GoodsNameError, rowNo);
                }
                else
                {
                    //
                }

                this._prevControl = this._stockSlipDetailInput;
            }
            else
            {
                this._prevControl = this.ActiveControl;
            }

			// ガイドボタンツール有効無効設定処理
            this.SettingGuideButtonToolEnabled(this._prevControl);

		}

        /// <summary>
        /// アクティブコントロール取得処理
        /// </summary>
        /// <returns></returns>
        private Control GetActiveControl()
        {
            Control ctrl = this.ActiveControl;

            if (ctrl != null)
            {
                ctrl = this.GetParentControl(ctrl);
            }

            return ctrl;
        }

        /// <summary>
        /// 親コントロール取得処理
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        private Control GetParentControl(Control ctrl )
        {
            Control retCtrl = ctrl;
            if (ctrl.Parent != null)
            {
                if (( ctrl.Parent is Broadleaf.Library.Windows.Forms.TNedit ) ||
                    ( ctrl.Parent is Broadleaf.Library.Windows.Forms.TEdit ) ||
                    ( ctrl.Parent is Broadleaf.Library.Windows.Forms.TDateEdit ) ||
                    ( ctrl.Parent is Broadleaf.Library.Windows.Forms.TComboEditor ))
                {
                    //retCtrl = ctrl.Parent;
                    retCtrl = GetParentControl(ctrl.Parent);
                }
            }

            return retCtrl;
        }

		/// <summary>
		/// 仕入情報先頭項目フォーカス設定処理
		/// </summary>
		private void StockInfoTopItemFocusSetting()
		{
            // DEL 2011/11/30 gezh redmine#8383 ------------------------------------------------------------------------------------>>>>>
            //if (( this.tEdit_SupplierSlipNote1.Visible ) && ( this.tEdit_SupplierSlipNote1.Enabled ) && ( this.tEdit_SupplierSlipNote1.ReadOnly ))
            //{
            //    this.tEdit_SupplierSlipNote1.Focus();
            //    this._prevControl = this.tEdit_SupplierSlipNote1;
            //}
            // DEL 2011/11/30 gezh redmine#8383 ------------------------------------------------------------------------------------<<<<<
            // ADD 2011/11/30 gezh redmine#8383 ------------------------------------------------------------------------------------>>>>>
            if ((this.tNedit_SupplierSlipNote1.Visible) && (this.tNedit_SupplierSlipNote1.Enabled) && (this.tNedit_SupplierSlipNote1.ReadOnly))
            {
                this.tNedit_SupplierSlipNote1.Focus();
                this._prevControl = this.tNedit_SupplierSlipNote1;
            }
            // ADD 2011/11/30 gezh redmine#8383 ------------------------------------------------------------------------------------<<<<<
            else
            {
                this._prevControl = this.ActiveControl;
            }
            this.SettingGuideButtonToolEnabled(this._prevControl);
		}

		/// <summary>
		/// 仕入情報先頭項目フォーカス設定処理
		/// </summary>
		private void MemoTopItemFocusSetting()
		{
            if (( this.tEdit_InsideMemo1.Visible ) && ( this.tEdit_InsideMemo1.Enabled ) && ( this.tEdit_InsideMemo1.ReadOnly ))
            {
                this.tEdit_InsideMemo1.Focus();
                this._prevControl = this.tEdit_InsideMemo1;
            }
            else
            {
                this._prevControl = this.ActiveControl;
            }
            this.SettingGuideButtonToolEnabled(this._prevControl);
		}

        // 2009.04.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// コントロールインデックス取得処理(フッタ部)
        /// </summary>
        /// <param name="prevCtrl">現在のコントロールの名称</param>
        /// <param name="mode">0:上から 1:下から</param>
        /// <returns>コントロールインデックス</returns>
        private int GetControlIndexForFooter(string prevCtrl, StockSlipInputAcs.MoveMethod mode)
        {
            int controlIndex = -1;

            switch (mode)
            {
                case StockSlipInputAcs.MoveMethod.NextMove:
                    {
                        if (this._controlIndexForwordDictionaryForFooter.ContainsKey(prevCtrl))
                        {
                            controlIndex = this._controlIndexForwordDictionaryForFooter[prevCtrl];
                        }

                        break;
                    }
                case StockSlipInputAcs.MoveMethod.PrevMove:
                    {
                        if (this._controlIndexBackDictionaryForFooter.ContainsKey(prevCtrl))
                        {
                            controlIndex = this._controlIndexBackDictionaryForFooter[prevCtrl];
                        }

                        break;
                    }
            }
            return controlIndex;
        }

        /// <summary>
        /// ネクストコントロール取得処理(フッタ部)
        /// </summary>
        /// <param name="prevCtrl">現在のコントロール</param>
        /// <param name="mode">0:上から 1:下から</param>
        /// <returns>次のコントロール</returns>
        private Control GetNextControlForFooter(Control prevCtrl, StockSlipInputAcs.MoveMethod mode)
        {
            Control control = null;

            switch (mode)
            {
                case StockSlipInputAcs.MoveMethod.NextMove:
                    {
                        int prevControlIndex = this.GetControlIndexForFooter(prevCtrl.Name, mode);

                        if ((this.tEdit_SupplierSlipNote1.Enabled) && (!this.tEdit_SupplierSlipNote1.ReadOnly) && (this.tEdit_SupplierSlipNote1.Visible) && (prevCtrl != this.tEdit_SupplierSlipNote1) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_SupplierSlipNote1.Name, mode)))
                        {
                            control = this.tEdit_SupplierSlipNote1;
                        }
                        // ADD 2011/11/30 gezh redmine#8383 ----------------------------------------------------------------------->>>>>
                        else if ((this.tNedit_SupplierSlipNote1.Enabled) && (!this.tNedit_SupplierSlipNote1.ReadOnly) && (this.tNedit_SupplierSlipNote1.Visible) && (prevCtrl != this.tNedit_SupplierSlipNote1) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_SupplierSlipNote1.Name, mode)))
                        {
                            control = this.tNedit_SupplierSlipNote1;
                        }
                        // ADD 2011/11/30 gezh redmine#8383 -----------------------------------------------------------------------<<<<<
                        else if ((this.uButton_SlipNote1.Enabled) && (this.uButton_SlipNote1.Visible) && (prevCtrl != this.uButton_SlipNote1) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_SlipNote1.Name, mode)))
                        {
                            control = this.uButton_SlipNote1;
                        }
                        // ADD 2011/11/30 gezh redmine#8383 ----------------------------------------------------------------------->>>>>
                        else if ((this.tNedit_SupplierSlipNote2.Enabled) && (!this.tNedit_SupplierSlipNote2.ReadOnly) && (this.tNedit_SupplierSlipNote2.Visible) && (prevCtrl != this.tNedit_SupplierSlipNote2) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_SupplierSlipNote2.Name, mode)))
                        {
                            control = this.tNedit_SupplierSlipNote2;
                        }
                        // ADD 2011/11/30 gezh redmine#8383 -----------------------------------------------------------------------<<<<<
                        else if ((this.tEdit_SupplierSlipNote2.Enabled) && (!this.tEdit_SupplierSlipNote2.ReadOnly) && (this.tEdit_SupplierSlipNote2.Visible) && (prevCtrl != this.tEdit_SupplierSlipNote2) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_SupplierSlipNote2.Name, mode)))
                        {
                            control = this.tEdit_SupplierSlipNote2;
                        }
                        else if ((this.uButton_SlipNote2.Enabled) && (this.uButton_SlipNote2.Visible) && (prevCtrl != this.uButton_SlipNote2) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_SlipNote2.Name, mode)))
                        {
                            control = this.uButton_SlipNote2;
                        }
                        else if ((this.tEdit_RetGoodsReason.Enabled) && (!this.tEdit_RetGoodsReason.ReadOnly) && (this.tEdit_RetGoodsReason.Visible) && (prevCtrl != this.tEdit_RetGoodsReason) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_RetGoodsReason.Name, mode)))
                        {
                            control = this.tEdit_RetGoodsReason;
                        }
                        else if ((this.uButton_RetGoodsReason.Enabled) && (this.uButton_RetGoodsReason.Visible) && (prevCtrl != this.uButton_RetGoodsReason) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_RetGoodsReason.Name, mode)))
                        {
                            control = this.uButton_RetGoodsReason;
                        }
                        else if ((this.tNedit_StockTotalPrice.Enabled) && (!this.tNedit_StockTotalPrice.ReadOnly) && (this.tNedit_StockTotalPrice.Visible) && (prevCtrl != this.tNedit_StockTotalPrice) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_StockTotalPrice.Name, mode)))
                        {
                            control = this.tNedit_StockTotalPrice;
                        }
                        else if ((this.tNedit_StockPriceConsTaxTotal.Enabled) && (!this.tNedit_StockPriceConsTaxTotal.ReadOnly) && (this.tNedit_StockPriceConsTaxTotal.Visible) && (prevCtrl != this.tNedit_StockPriceConsTaxTotal) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_StockPriceConsTaxTotal.Name, mode)))
                        {
                            control = this.tNedit_StockPriceConsTaxTotal;
                        }
                        else
                        {
                            control = prevCtrl;
                        }

                        break;
                    }

                case StockSlipInputAcs.MoveMethod.PrevMove:
                    {
                        int prevControlIndex = this.GetControlIndexForFooter(prevCtrl.Name, mode);

                        if ((this.tNedit_StockPriceConsTaxTotal.Enabled) && (!this.tNedit_StockPriceConsTaxTotal.ReadOnly) && (this.tNedit_StockPriceConsTaxTotal.Visible) && (prevCtrl != this.tNedit_StockPriceConsTaxTotal) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_StockPriceConsTaxTotal.Name, mode)))
                        {
                            control = this.tNedit_StockPriceConsTaxTotal;
                        }
                        else if ((this.tNedit_StockTotalPrice.Enabled) && (this.tNedit_StockTotalPrice.Visible) && (prevCtrl != this.tNedit_StockTotalPrice) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_StockTotalPrice.Name, mode)))
                        {
                            control = this.tNedit_StockTotalPrice;
                        }
                        else if ((this.uButton_RetGoodsReason.Enabled) && (this.uButton_RetGoodsReason.Visible) && (prevCtrl != this.uButton_RetGoodsReason) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_RetGoodsReason.Name, mode)))
                        {
                            control = this.uButton_RetGoodsReason;
                        }
                        else if ((this.tEdit_RetGoodsReason.Enabled) && (this.tEdit_RetGoodsReason.Visible) && (prevCtrl != this.tEdit_RetGoodsReason) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_RetGoodsReason.Name, mode)))
                        {
                            control = this.tEdit_RetGoodsReason;
                        }
                        else if ((this.uButton_SlipNote2.Enabled) && (this.uButton_SlipNote2.Visible) && (prevCtrl != this.uButton_SlipNote2) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_SlipNote2.Name, mode)))
                        {
                            control = this.uButton_SlipNote2;
                        }
                        else if ((this.tEdit_SupplierSlipNote2.Enabled) && (!this.tEdit_SupplierSlipNote2.ReadOnly) && (this.tEdit_SupplierSlipNote2.Visible) && (prevCtrl != this.tEdit_SupplierSlipNote2) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_SupplierSlipNote2.Name, mode)))
                        {
                            control = this.tEdit_SupplierSlipNote2;
                        }
                        // ADD 2011/11/30 gezh redmine#8383 ----------------------------------------------------------------------->>>>>
                        else if ((this.tNedit_SupplierSlipNote2.Enabled) && (!this.tNedit_SupplierSlipNote2.ReadOnly) && (this.tNedit_SupplierSlipNote2.Visible) && (prevCtrl != this.tNedit_SupplierSlipNote2) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_SupplierSlipNote2.Name, mode)))
                        {
                            control = this.tNedit_SupplierSlipNote2;
                        }
                        // ADD 2011/11/30 gezh redmine#8383 -----------------------------------------------------------------------<<<<<
                        else if ((this.uButton_SlipNote1.Enabled) && (this.uButton_SlipNote1.Visible) && (prevCtrl != this.uButton_SlipNote1) && (prevControlIndex < this.GetControlIndexForFooter(this.uButton_SlipNote1.Name, mode)))
                        {
                            control = this.uButton_SlipNote1;
                        }
                        else if ((this.tEdit_SupplierSlipNote1.Enabled) && (!this.tEdit_SupplierSlipNote1.ReadOnly) && (this.tEdit_SupplierSlipNote1.Visible) && (prevCtrl != this.tEdit_SupplierSlipNote1) && (prevControlIndex < this.GetControlIndexForFooter(this.tEdit_SupplierSlipNote1.Name, mode)))
                        {
                            control = this.tEdit_SupplierSlipNote1;
                        }
                        // ADD 2011/11/30 gezh redmine#8383 ----------------------------------------------------------------------->>>>>
                        else if ((this.tNedit_SupplierSlipNote1.Enabled) && (!this.tNedit_SupplierSlipNote1.ReadOnly) && (this.tNedit_SupplierSlipNote1.Visible) && (prevCtrl != this.tNedit_SupplierSlipNote1) && (prevControlIndex < this.GetControlIndexForFooter(this.tNedit_SupplierSlipNote1.Name, mode)))
                        {
                            control = this.tNedit_SupplierSlipNote1;
                        }
                        // ADD 2011/11/30 gezh redmine#8383 -----------------------------------------------------------------------<<<<<
                        else
                        {
                            if ((this._stockSlipDetailInput.uGrid_Details.Enabled) && (this._stockSlipDetailInput.uGrid_Details.Visible) && (prevCtrl != this._stockSlipDetailInput.uGrid_Details))
                            {
                                control = this._stockSlipDetailInput.uGrid_Details;
                            }
                        }

                        break;
                    }
            }

            return control;
        }
        // 2009.04.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region 返品処理

		/// <summary>
		/// 返品処理
		/// </summary>
        /// <br>Update Note : 2020/02/24 田建委</br>
        /// <br>管理番号    : 11570208-00</br>
        /// <br>              PMKOBETSU-2912消費税税率機能追加対応</br>
		private void ReturnSlip(bool isConfirm)
		{
			bool canReturn = this.ShowSaveCheckDialog(isConfirm);

			if (!canReturn)
			{
				return;
			}

            //this.tEdit_StockAgentCode.Focus();// DEL 黄興貴 2015/04/01 Redmine#45073 障害No.179

            MAKON01110UD supplierSlipNoInputDialog = new MAKON01110UD(this._stockSlipInputAcs.StockSlip.SupplierFormal, this._stockSlipInputAcs.StockSlip.SupplierSlipNo, true, MAKON01320UA.ExtractSlipCdType.Purchase);
			this._controlScreenSkin.SettingScreenSkin(supplierSlipNoInputDialog);
			DialogResult dialogResult = supplierSlipNoInputDialog.ShowDialog(this);

			if (dialogResult == DialogResult.OK)
			{
                this.tEdit_StockAgentCode.Focus();// ADD 黄興貴 2015/04/01 Redmine#45073 障害No.179
				StockSlip stockSlip = supplierSlipNoInputDialog.StockSlip;
				StockSlip baseStockSlip = supplierSlipNoInputDialog.BaseStockSlip;
				List<StockDetail> stockDetailList = supplierSlipNoInputDialog.StockDetailList;
				List<StockWork> stockWorkList = supplierSlipNoInputDialog.StockWorkList;
				List<StockDetail> addUpSrcDetailList = supplierSlipNoInputDialog.AddUpSrcDetailList;

                stockSlip.SuppCTaxLayCd = baseStockSlip.SuppCTaxLayCd; // 2009.03.25

				// 返品伝票情報生成可能チェック処理
				string message;
				bool created = this._stockSlipInputAcs.CanCreateReturnSlipInfo(stockSlip, stockDetailList, out message);

				if (!created)
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						message,
						0,
						MessageBoxButtons.OK);

					return;
				}

				// 返品伝票情報生成処理
				this._stockSlipInputAcs.CreateReturnSlipInfo(ref stockSlip);

                // 表示用伝票区分設定処理
                StockSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref stockSlip);

				// キャッシュ処理(計上元には対象明細と同じ情報をキャッシュ)
                this._stockSlipInputAcs.Cache(stockSlip, baseStockSlip, stockDetailList, stockDetailList, stockWorkList);

                // 返品伝票明細情報生成処理
				this._stockSlipInputAcs.CreateReturnSlipDetailInfo(stockWorkList);

                // 仕入数量０行削除処理
                this._stockSlipDetailInput.DeleteStockCountZeroRow(false);

                ////--- UPD 2010/11/02 ---------->>>>>
                ////// 仕入金額計算処理
                ////this._stockSlipDetailInput.CalculationStockPrice(); // DEL 2010/11/02

                ////// 仕入金額変更後発生イベント処理
                ////this.StockSlipDetailInput_StockPriceChanged(this, new EventArgs()); // DEL 2010/11/02

                ////// 仕入データクラス→画面格納処理
                ////this.SetDisplay(this._stockSlipInputAcs.StockSlip);

                if (stockDetailList != null)
                {
                    bool isTrust = false;

                    foreach (StockDetail stockDetail in stockDetailList)
                    {
                        if (stockDetail.StockCount != stockDetail.OrderRemainCnt)
                        {
                            isTrust = true;
                            break;
                        }
                    }

                    if (isTrust)
                    {
                        // 仕入金額計算処理
                        this._stockSlipDetailInput.CalculationStockPrice();

                        // 仕入金額変更後発生イベント処理
                        this.StockSlipDetailInput_StockPriceChanged(this, new EventArgs());

                        // 仕入データクラス→画面格納処理
                        this.SetDisplay(this._stockSlipInputAcs.StockSlip);
                    }
                    else
                    {
                        long stockPriceConsTax = this._stockSlipInputAcs.StockSlip.StockPriceConsTax;
                        // 仕入金額計算処理
                        this._stockSlipDetailInput.CalculationStockPrice();

                        // 仕入金額変更後発生イベント処理
                        this.StockSlipDetailInput_StockPriceChanged(this, new EventArgs());

                        // 仕入データクラス→画面格納処理
                        this.SetDisplay(this._stockSlipInputAcs.StockSlip);

                        long taxAdjust = this._stockSlipInputAcs.StockSlip.StockPriceConsTax * (-1) - stockPriceConsTax;
                        if (stockSlip.StockGoodsCd != 6)
                        {
                            this._stockSlipInputAcs.StockSlip.TaxAdjust = taxAdjust;
                        }
                        tNedit_StockPriceConsTaxTotal.SetValue(stockPriceConsTax);

                        this._stockSlipInputAcs.StockSlip.StockTtlPricTaxInc = this._stockSlipInputAcs.StockSlip.StockTtlPricTaxInc + taxAdjust;
                        this._stockSlipInputAcs.StockSlip.StockPriceConsTax = this._stockSlipInputAcs.StockSlip.StockPriceConsTax + taxAdjust;
                        this._stockSlipInputAcs.StockSlip.StockOutTax = this._stockSlipInputAcs.StockSlip.StockOutTax + taxAdjust;
                        this._stockSlipInputAcs.StockSlip.StockTotalPrice = this._stockSlipInputAcs.StockSlip.StockTotalPrice + taxAdjust;
                        this._stockSlipInputAcs.StockSlip.AccPayConsTax = this._stockSlipInputAcs.StockSlip.AccPayConsTax + taxAdjust;
                        tNedit_TotalPrice.SetValue(tNedit_StockTotalPrice.GetValue() + tNedit_StockPriceConsTaxTotal.GetValue());
                    }
                }
                //--- UPD 2010/11/02 ----------<<<<<

				// 明細グリッド設定処理
				this._stockSlipDetailInput.SettingGrid();

                // 仕入単価、仕入金額のキャッシュ
                this._stockSlipInputAcs.CacheStockPrice();

				// 明細グリッドにフォーカスをセット
				this._stockSlipDetailInput.Focus();

				// ガイドボタンツール有効無効設定処理
				this.SettingGuideButtonToolEnabled(this._stockSlipDetailInput);

				// データ変更フラグプロパティをtrueにする
				this._stockSlipInputAcs.IsDataChanged = true;

                // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
                DisplayNameSetting2(stockSlip);
                // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<
			}

			this._prevControl = this.ActiveControl;
		}

		#endregion

        #region 伝票呼出
        /// <summary>
        /// 伝票呼出処理
        /// </summary>
        /// <br>Update Note : 2011/12/27 陳建明</br>
        /// <br>管理番号    : 10707327-00 2012/01/25配信分</br>
        /// <br>              redmine#27374 仕入伝票入力/締済のチェックの対応</br>
        /// <br>Update Note : 2012/03/13 鄧潘ハン</br>
        /// <br>管理番号    : 10707327-00 2012/03/28配信分</br>
        /// <br>              Redmine#27374 仕入伝票入力でガイドから呼出した場合削除でエラーになる件の対応</br>
        /// <br>Update Note : 2020/02/24 田建委</br>
        /// <br>管理番号    : 11570208-00</br>
        /// <br>              PMKOBETSU-2912消費税税率機能追加対応</br>
        private void ReadSlip( bool isConfirm )
        {
            bool canRed = this.ShowSaveCheckDialog(isConfirm);

            if (!canRed)
            {
                return;
            }

            //this.tEdit_StockAgentCode.Focus();// DEL 黄興貴 2015/04/01 Redmine#45073 障害No.179

            MAKON01110UD supplierSlipNoInputDialog = new MAKON01110UD(this._stockSlipInputAcs.StockSlip.SupplierFormal, this._stockSlipInputAcs.StockSlip.SupplierSlipNo, true, MAKON01320UA.ExtractSlipCdType.All);
            this._controlScreenSkin.SettingScreenSkin(supplierSlipNoInputDialog);
            DialogResult dialogResult = supplierSlipNoInputDialog.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
                this.tEdit_StockAgentCode.Focus();// ADD 黄興貴 2015/04/01 Redmine#45073 障害No.179
                StockSlip stockSlip = supplierSlipNoInputDialog.StockSlip;
                List<StockDetail> stockDetailList = supplierSlipNoInputDialog.StockDetailList;
                List<StockDetail> addUpSrcDetailList = supplierSlipNoInputDialog.AddUpSrcDetailList;
                PaymentSlp paymentSlp = supplierSlipNoInputDialog.PaymentSlp;
                List<PaymentDtl> paymentDtlList = supplierSlipNoInputDialog.PaymentDtlList;
                List<StockWork> stockWorkList = supplierSlipNoInputDialog.StockWorkList;
                //DEL 2012/03/13 鄧潘ハン Redmine #27374----->>>>>
                //add 2011/12/27 陳建明 Redmine #27374----->>>>>
                //_deleteStockSlip = stockSlip;
                //_deleteStockDetailList = stockDetailList;
                //_deleteAddUpSrcDetailList = addUpSrcDetailList;
                //_deletePaymentSlp = paymentSlp;
                //_deletePaymentDtlList = paymentDtlList;
                //_deleteStockWorkList = stockWorkList;
                //add 2011/12/27 陳建明 Redmine #27374-----<<<<<
                //DEL 2012/03/13 鄧潘ハン Redmine #27374-----<<<<<

                //ADD 2012/03/13 鄧潘ハン Redmine #27374----->>>>>
                this._stockSlipInputAcs.DeleteStockSlip = stockSlip;
                this._stockSlipInputAcs.DeleteStockDetailList = stockDetailList;
                this._stockSlipInputAcs.DeleteAddUpSrcDetailList = addUpSrcDetailList;
                this._stockSlipInputAcs.DeletePaymentSlp = paymentSlp;
                this._stockSlipInputAcs.DeletePaymentDtlList = paymentDtlList;
                this._stockSlipInputAcs.DeleteStockWorkList = stockWorkList;
                //ADD 2012/03/13 鄧潘ハン Redmine #27374-----<<<<<

                // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
                ShowMessage(stockSlip, stockSlip.SupplierConsTaxRate);
                slipSrcTaxFlg = false;
                // 税率取得の対象は、仕入形式によって変更(仕入：仕入日、入荷：入荷日）
                DateTime targetdate = (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay;
                taxRateSetMaster = this._stockSlipInputInitDataAcs.GetTaxRate(targetdate);
                if (stockSlip.SupplierConsTaxRate != taxRateSetMaster)
                {
                    // 伝票呼出軽減税率フラグ
                    slipSrcTaxFlg = true;

                }
                // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<

                // 画面初期化処理
                this.Clear(false, false);

                this._stockSlipInputAcs.Cache(stockSlip, stockSlip, stockDetailList, addUpSrcDetailList, paymentSlp, paymentDtlList, null, stockWorkList);

                // 仕入データ入力モード設定処理
                this.SettingStockSlipInputMode(ref stockSlip);

                // 表示用伝票区分の設定
                StockSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref stockSlip);

                // 仕入データクラス→画面格納処理
                this.SetDisplay(stockSlip);

                // 仕入データキャッシュ処理
                this._stockSlipInputAcs.Cache(stockSlip);

                // 入荷計上伝票、赤伝の場合は空白行を削除する
                if (( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ArrivalAddUp ) || ( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red ))
                {
                    this._stockSlipDetailInput.DeleteEmptyRow(true);
                }

                //this._stockSlipInputAcs.StockDetailRowTaxationCodeSetting(stockSlip.SuppTtlAmntDspWayCd);

                // 明細グリッド設定処理
                this._stockSlipDetailInput.SettingGrid();

                // ツールバーボタン有効無効設定処理
                this.SettingToolBarButtonEnabled();
                this.SettingToolBarButtonEnabled_Detail();

                if (( this._stockSlipDetailInput.Enabled ) && ( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red ))
                {
                    this._stockSlipDetailInput.Focus();
                }
                else
                {
                    //this.tEdit_SupplierSlipNote1.Focus();  //DEL 2011/11/30 gezh redmine#8383
                    this.tNedit_SupplierSlipNote1.Focus();   //ADD 2011/11/30 gezh redmine#8383
                }

                DisplayNameSetting2(stockSlip);// ADD 田建委 2020/02/24 PMKOBETSU-2912の対応
            }
            this._stockSlipDetailInput.SettingFooterEventCall();

            this._prevControl = this.GetActiveControl();
        }
        #endregion

        #region 赤伝関連

        /// <summary>
		/// 赤伝処理
		/// </summary>
		private void RedSlip(bool isConfirm)
		{
			bool canRed = this.ShowSaveCheckDialog(isConfirm);

			if (!canRed)
			{
				return;
			}

            //this.tEdit_StockAgentCode.Focus();// DEL 黄興貴 2015/04/01 Redmine#45073 障害No.179

            //MAKON01110UD supplierSlipNoInputDialog = new MAKON01110UD(this._stockSlipInputAcs.StockSlip.SupplierFormal, this._stockSlipInputAcs.StockSlip.SupplierSlipNo, false, MAKON01320UA.ExtractSlipCdType.Purchase);
            MAKON01110UD supplierSlipNoInputDialog = new MAKON01110UD(0, this._stockSlipInputAcs.StockSlip.SupplierSlipNo, false, MAKON01320UA.ExtractSlipCdType.Purchase);
			this._controlScreenSkin.SettingScreenSkin(supplierSlipNoInputDialog);
			DialogResult dialogResult = supplierSlipNoInputDialog.ShowDialog(this);

			if (dialogResult == DialogResult.OK)
			{
                this.tEdit_StockAgentCode.Focus();// ADD 黄興貴 2015/04/01 Redmine#45073 障害No.179
				StockSlip stockSlip = supplierSlipNoInputDialog.StockSlip;
                StockSlip baseStockSlip = supplierSlipNoInputDialog.BaseStockSlip; // 2009.03.25
				List<StockDetail> stockDetailList = supplierSlipNoInputDialog.StockDetailList;
				List<StockDetail> addUpSrcDetailList = supplierSlipNoInputDialog.AddUpSrcDetailList;
				PaymentSlp paymentSlp = supplierSlipNoInputDialog.PaymentSlp;
                List<PaymentDtl> paymentDtlList = supplierSlipNoInputDialog.PaymentDtlList;
				List<StockWork> stockWorkList = supplierSlipNoInputDialog.StockWorkList;

                stockSlip.SuppCTaxLayCd = baseStockSlip.SuppCTaxLayCd; // 2009.03.25

                this.RedSlip(stockSlip, stockDetailList, addUpSrcDetailList, paymentSlp, paymentDtlList, stockWorkList);
            }

			this._prevControl = this.GetActiveControl();
		}

		/// <summary>
		/// 赤伝処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="supplierFormal">仕入形式</param>
		/// <param name="supplierSlipNo">仕入伝票番号</param>
		private void RedSlip(string enterpriseCode, int supplierFormal, int supplierSlipNo)
		{
			StockSlip stockSlip;
            StockSlip baseStockSlip; // 2009.03.25
			List<StockDetail> stockDetailList;
			List<StockDetail> addUpSrcDetailList;
			PaymentSlp paymentSlp;
            List<PaymentDtl> paymentDtlList;
			List<SalesTemp> salesTempList;
			List<StockWork> stockWorkList;

			// データリード処理
			this.Cursor = Cursors.WaitCursor;
            //int status = this._stockSlipInputAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
            int status = this._stockSlipInputAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
            this.Cursor = Cursors.Default;

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                stockSlip.SuppCTaxLayCd = baseStockSlip.SuppCTaxLayCd; // 2009.03.25

                this.RedSlip(stockSlip, stockDetailList, addUpSrcDetailList, paymentSlp, paymentDtlList, stockWorkList);
            }
		}

		/// <summary>
		/// 赤伝処理
		/// </summary>
		/// <param name="stockSlip">仕入データ</param>
		/// <param name="stockDetailList">仕入明細データリスト</param>
		/// <param name="addUpSrcDetailList">計上元仕入明細データリスト</param>
		/// <param name="paymentSlp">支払データ</param>
        /// <param name="paymentDtlList">支払明細データリスト</param>
        /// <param name="stockWorkList">在庫リスト</param>
        /// <br>Update Note : 2020/02/24 田建委</br>
        /// <br>管理番号    : 11570208-00</br>
        /// <br>              PMKOBETSU-2912消費税税率機能追加対応</br>
        private void RedSlip( StockSlip stockSlip, List<StockDetail> stockDetailList, List<StockDetail> addUpSrcDetailList, PaymentSlp paymentSlp, List<PaymentDtl> paymentDtlList, List<StockWork> stockWorkList )
		{
			// 赤伝票情報生成可能チェック処理
			string message;
			bool created = this._stockSlipInputAcs.CanCreateRedSlipInfo(stockSlip, stockDetailList, out message);

			if (!created)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					message,
					0,
					MessageBoxButtons.OK);

				return;
			}

			StockSlip baseStockSlip = stockSlip.Clone();

			// 赤伝票情報生成処理
			this._stockSlipInputAcs.CreateRedSlipInfo(ref stockSlip);

			// 赤伝票情報生成処理(支払)
			this._stockSlipInputAcs.CreateRedSlipInfo(ref paymentSlp);

			// 表示用伝票区分設定処理
			StockSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref stockSlip);

			// キャッシュ処理(計上元には対象明細と同じ情報をキャッシュ)
            this._stockSlipInputAcs.Cache(stockSlip, baseStockSlip, stockDetailList, stockDetailList, paymentSlp, paymentDtlList, null, stockWorkList);

			// 赤伝票明細情報生成処理
			this._stockSlipInputAcs.CreateRedSlipDetailInfo(stockWorkList);

			//// 空白行削除処理
			//this._stockSlipDetailInput.DeleteEmptyRow(true);

            long stockPriceConsTax = this._stockSlipInputAcs.StockSlip.StockPriceConsTax; // ADD 2010/12/02

            // 仕入金額計算処理
            this._stockSlipDetailInput.CalculationStockPrice();

            // 仕入金額変更後発生イベント処理
            this.StockSlipDetailInput_StockPriceChanged(this, new EventArgs());

			// 仕入データクラス→画面格納処理
			this.SetDisplay(this._stockSlipInputAcs.StockSlip);

            // --- ADD 2010/12/02 ---------->>>>>
            long taxAdjust = this._stockSlipInputAcs.StockSlip.StockPriceConsTax * (-1) - stockPriceConsTax;
            if (stockSlip.StockGoodsCd != 6)
            {
                this._stockSlipInputAcs.StockSlip.TaxAdjust = taxAdjust;
            }
            tNedit_StockPriceConsTaxTotal.SetValue(stockPriceConsTax * (-1));

            this._stockSlipInputAcs.StockSlip.StockTtlPricTaxInc = this._stockSlipInputAcs.StockSlip.StockTtlPricTaxInc + taxAdjust;
            this._stockSlipInputAcs.StockSlip.StockPriceConsTax = this._stockSlipInputAcs.StockSlip.StockPriceConsTax + taxAdjust;
            this._stockSlipInputAcs.StockSlip.StockOutTax = this._stockSlipInputAcs.StockSlip.StockOutTax + taxAdjust;
            this._stockSlipInputAcs.StockSlip.StockTotalPrice = this._stockSlipInputAcs.StockSlip.StockTotalPrice + taxAdjust;
            this._stockSlipInputAcs.StockSlip.AccPayConsTax = this._stockSlipInputAcs.StockSlip.AccPayConsTax + taxAdjust;
            tNedit_TotalPrice.SetValue(tNedit_StockTotalPrice.GetValue() + tNedit_StockPriceConsTaxTotal.GetValue());
            // --- ADD 2010/12/02 ----------<<<<<

			// 明細グリッド設定処理
			this._stockSlipDetailInput.SettingGrid();

			// 返品理由コードにフォーカスをセット
			this.tEdit_RetGoodsReason.Focus();

			// ガイドボタンツール有効無効設定処理
			this.SettingGuideButtonToolEnabled(this.tEdit_RetGoodsReason);

			// データ変更フラグプロパティをtrueにする
			this._stockSlipInputAcs.IsDataChanged = true;

            DisplayNameSetting2(stockSlip);// ADD 田建委 2020/02/24 PMKOBETSU-2912の対応
            this._prevControl = this.GetActiveControl();
		}

		#endregion

		#region 入荷計上

		/// <summary>
		/// 入荷計上処理
		/// </summary>
        /// <br>Update Note: 2010/12/03 yangmj 入荷計上ボタン押下時の伝票番号入力ダイアログの修正</br>
        private void ArrivalAppropriate(bool isConfirm)
		{
			bool canArrivalAppropriate = this.ShowSaveCheckDialog(isConfirm);

			if (!canArrivalAppropriate)
			{
				return;
			}

            //this.tEdit_StockAgentCode.Focus();// DEL 黄興貴 2015/04/01 Redmine#45073 障害No.179

			int supplierSlipNo = 0;
			if (this._stockSlipInputAcs.StockSlip.SupplierFormal == 1)
			{
				supplierSlipNo = this._stockSlipInputAcs.StockSlip.SupplierSlipNo;
			}
            //-----ADD 2010/12/03----->>>>>
            //MAKON01110UD supplierSlipNoInputDialog = new MAKON01110UD(1, supplierSlipNo, false, MAKON01320UA.ExtractSlipCdType.Purchase);
            MAKON01110UD supplierSlipNoInputDialog = new MAKON01110UD(1, supplierSlipNo, false, MAKON01320UA.ExtractSlipCdType.Purchase, 0);
            //-----ADD 2010/12/03-----<<<<<
			this._controlScreenSkin.SettingScreenSkin(supplierSlipNoInputDialog);
			DialogResult dialogResult = supplierSlipNoInputDialog.ShowDialog(this);

			if (dialogResult == DialogResult.OK)
			{
                this.tEdit_StockAgentCode.Focus();// ADD 黄興貴 2015/04/01 Redmine#45073 障害No.179
				StockSlip stockSlip = supplierSlipNoInputDialog.StockSlip;
				List<StockDetail> stockDetailList = supplierSlipNoInputDialog.StockDetailList;
				List<StockDetail> addUpSrcDetailList = supplierSlipNoInputDialog.AddUpSrcDetailList;
				List<SalesTemp> salesTempList = supplierSlipNoInputDialog.SalesTempList;
				List<StockWork> stockWorkList = supplierSlipNoInputDialog.StockWorkList;

				// 入荷計上処理
				this.ArrivalAppropriate(stockSlip, stockDetailList, addUpSrcDetailList, salesTempList, stockWorkList);
			}


			this._prevControl = this.GetActiveControl();
		}

		/// <summary>
		/// 入荷計上処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="supplierFormal">仕入形式</param>
		/// <param name="supplierSlipNo">仕入伝票番号</param>
		private void ArrivalAppropriate(string enterpriseCode, int supplierFormal, int supplierSlipNo)
		{
			StockSlip stockSlip;
            StockSlip baseStockSlip; // 2009.03.25
			List<StockDetail> stockDetailList;
			List<StockDetail> addUpSrcDetailList;
			PaymentSlp paymentSlp;
            List<PaymentDtl> paymentDtlList;
			List<SalesTemp> salesTempList;
			List<StockWork> stockWorkList;

			// データリード処理
			this.Cursor = Cursors.WaitCursor;
            //int status = this._stockSlipInputAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
            int status = this._stockSlipInputAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
            this.Cursor = Cursors.Default;

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.ArrivalAppropriate(stockSlip, stockDetailList, addUpSrcDetailList, salesTempList, stockWorkList);
            }
		}

		/// <summary>
		/// 入荷計上処理
		/// </summary>
		/// <param name="stockSlip">仕入データクラス</param>
		/// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		/// <param name="addUpSrcDetailList">計上元仕入明細データオブジェクトリスト</param>
		/// <param name="salesTempList">売上データ(仕入同時計上)オブジェクトリスト</param>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
        /// <br>Update Note : 2020/02/24 田建委</br>
        /// <br>管理番号    : 11570208-00</br>
        /// <br>              PMKOBETSU-2912消費税税率機能追加対応</br>
        private void ArrivalAppropriate(StockSlip stockSlip, List<StockDetail> stockDetailList, List<StockDetail> addUpSrcDetailList, List<SalesTemp> salesTempList, List<StockWork> stockWorkList)
		{
			// 入荷計上情報生成可能チェック処理
			string message;
			bool created = this._stockSlipInputAcs.CanCreateArrivalAddUpInfo(stockSlip, stockDetailList, out message);

			if (!created)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					message,
					0,
					MessageBoxButtons.OK);

				return;
			}

			StockSlip baseStockSlip = stockSlip.Clone();

			// 入荷計上情報生成処理
			this._stockSlipInputAcs.CreateArrivalAppropriateInfo(ref stockSlip);

			// 表示用伝票区分設定処理
			StockSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref stockSlip);

			// キャッシュ処理(計上元には対象明細と同じ情報をキャッシュ)
            this._stockSlipInputAcs.Cache(stockSlip, baseStockSlip, stockDetailList, stockDetailList, stockWorkList);

			// 入荷計上明細情報生成処理
			this._stockSlipInputAcs.CreateArrivalAppropriateDetailInfo();

			// 仕入数量０行削除処理
			this._stockSlipDetailInput.DeleteStockCountZeroRow(false);

            //// 空白行削除処理
            //this._stockSlipDetailInput.DeleteEmptyRow(true);

			// 仕入金額計算処理
			this._stockSlipDetailInput.CalculationStockPrice();

			// 仕入金額変更後発生イベント処理
			this.StockSlipDetailInput_StockPriceChanged(this, new EventArgs());

			// 仕入データクラス→画面格納処理
			this.SetDisplay(this._stockSlipInputAcs.StockSlip);

			// 明細グリッド設定処理
			this._stockSlipDetailInput.SettingGrid();

            // 仕入単価、仕入金額のキャッシュ
            this._stockSlipInputAcs.CacheStockPrice();

			// 明細グリッドにフォーカスをセット
			this._stockSlipDetailInput.Focus();

			// ガイドボタンツール有効無効設定処理
			this.SettingGuideButtonToolEnabled(this._stockSlipDetailInput);

			// データ変更フラグプロパティをtrueにする
			this._stockSlipInputAcs.IsDataChanged = true;

            DisplayNameSetting2(stockSlip);// ADD 田建委 2020/02/24 PMKOBETSU-2912の対応

			this._prevControl = this.GetActiveControl();
		}

		#endregion

		/// <summary>
		/// 削除処理
		/// </summary>
        /// <br>Update Note : 2011/12/27 陳建明</br>
        /// <br>管理番号    : 10707327-00 2012/01/25配信分</br>
        /// <br>              redmine#27374 仕入伝票入力/締済のチェックの対応</br>
        /// <br>Update Note : 2012/03/13 鄧潘ハン</br>
        /// <br>管理番号    : 10707327-00 2012/03/28配信分</br>
        /// <br>              Redmine#27374 仕入伝票入力でガイドから呼出した場合削除でエラーになる件の対応</br>
        private void Delete()
        {

            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "表示中の" + this._stockSlipInputAcs.GetSupplierFormalName(this._stockSlipInputAcs.StockSlip) + "伝票" + "を削除します。" + "\r\n" + "\r\n" +
                "よろしいですか？",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            //add 2011/12/27 陳建明 Redmine #27374----->>>>>

            //DEL 2012/03/13 鄧潘ハン Redmine #27374 ------>>>>>
            //_isCannotModify = false;
            // 画面初期化処理
            //this.Clear(false, false);
            //this._stockSlipInputAcs.Cache(_deleteStockSlip, _deleteStockSlip, _deleteStockDetailList, _deleteAddUpSrcDetailList, _deletePaymentSlp, _deletePaymentDtlList, null, _deleteStockWorkList);
            // 仕入データ入力モード設定処理
            //this.SettingStockSlipInputMode(ref _deleteStockSlip);
            //DEL 2012/03/13 鄧潘ハン Redmine #27374 ------<<<<<

            //ADD 2012/03/13 鄧潘ハン Redmine #27374 ------>>>>>
            this._stockSlipInputAcs.IsCannotModify = false;
            // 画面初期化処理
            this.Clear(false, false);
            this._stockSlipInputAcs.Cache(this._stockSlipInputAcs.DeleteStockSlip, this._stockSlipInputAcs.DeleteStockSlip, this._stockSlipInputAcs.DeleteStockDetailList, this._stockSlipInputAcs.DeleteAddUpSrcDetailList, this._stockSlipInputAcs.DeletePaymentSlp, this._stockSlipInputAcs.DeletePaymentDtlList, null, this._stockSlipInputAcs.DeleteStockWorkList);
            // 仕入データ入力モード設定処理
            StockSlip DeleteStockSlipCopy = _stockSlipInputAcs.DeleteStockSlip;
            this.SettingStockSlipInputMode(ref DeleteStockSlipCopy);
            _stockSlipInputAcs.DeleteStockSlip = DeleteStockSlipCopy;
            //ADD 2012/03/13 鄧潘ハン Redmine #27374 ------<<<<<

            //if (_isCannotModify)//DEL 2012/03/13 鄧潘ハン Redmine #27374
            if (this._stockSlipInputAcs.IsCannotModify)//ADD 2012/03/13 鄧潘ハン Redmine #27374
            {
                //DEL 2012/03/13 鄧潘ハン Redmine #27374 ------>>>>>
                // 入荷計上伝票、赤伝の場合は空白行を削除する
                //if ((_deleteStockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ArrivalAddUp) || (_deleteStockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red))
                //{
                //    this._stockSlipDetailInput.DeleteEmptyRow(true);
                //}

                // 表示用伝票区分の設定
                //StockSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref _deleteStockSlip);

                // 仕入データクラス→画面格納処理
                //this.SetDisplay(_deleteStockSlip);

                // 仕入データキャッシュ処理
                //this._stockSlipInputAcs.Cache(_deleteStockSlip);
   
                //DEL 2012/03/13 鄧潘ハン Redmine #27374 ------<<<<<

                //ADD 2012/03/13 鄧潘ハン Redmine #27374 ------>>>>>
                // 入荷計上伝票、赤伝の場合は空白行を削除する
                if ((this._stockSlipInputAcs.DeleteStockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ArrivalAddUp) || (this._stockSlipInputAcs.DeleteStockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red))
                {
                    this._stockSlipDetailInput.DeleteEmptyRow(true);
                }

                // 表示用伝票区分の設定
                DeleteStockSlipCopy = this._stockSlipInputAcs.DeleteStockSlip;
                StockSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref DeleteStockSlipCopy);
                this._stockSlipInputAcs.DeleteStockSlip = DeleteStockSlipCopy;
                // 仕入データクラス→画面格納処理
                this.SetDisplay(this._stockSlipInputAcs.DeleteStockSlip);

                // 仕入データキャッシュ処理
                this._stockSlipInputAcs.Cache(this._stockSlipInputAcs.DeleteStockSlip);
                //ADD 2012/03/13 鄧潘ハン Redmine #27374 ------<<<<<

                // 明細グリッド設定処理
                this._stockSlipDetailInput.SettingGrid();

                // ツールバーボタン有効無効設定処理
                this.SettingToolBarButtonEnabled();
                this.SettingToolBarButtonEnabled_Detail();

                this.uButton_PaymentConfirmation.Focus();
            }    
            else
            {
            //add 2011/12/27 陳建明 Redmine #27374-----<<<<<
                List<string> itemNameList = new List<string>();
                List<string> itemList = new List<string>();
                string mainMessage;

                // 削除データチェック処理
                bool check = this._stockSlipInputAcs.CheckDeleteData(this._stockSlipInputAcs.StockSlip, out mainMessage, out itemNameList, out itemList);

                if (!check)
                {
                    StringBuilder message = new StringBuilder();
                    message.Append(mainMessage);

                    if (!check)
                    {
                        foreach (string s in itemNameList)
                        {
                            message.Append(s + "\r\n");
                        }
                    }

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        message.ToString(),
                        0,
                        MessageBoxButtons.OK);

                    string itemName = "";
                    if (itemList.Count > 0)
                    {
                        itemName = itemList[0].ToString();

                        // 指定フォーカス設定処理
                        this.SetControlFocus(itemName, -1);
                    }

                    return;
                }

                string retMessage;
                this.Cursor = Cursors.WaitCursor;
                int status = this._stockSlipInputAcs.DeleteDBData(this._stockSlipInputAcs.StockSlip, this._stockSlipInputAcs.PaymentSlp, this._stockSlipInputAcs.PaymentDtlList, out retMessage);
                this.Cursor = Cursors.Default;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ログ出力
                    if (MyOpeCtrl.EnabledWithLog((int)OperationCode.Delete))
                    {

                        MyOpeCtrl.Logger.WriteOperationLog(
                            "Delete",
                            (int)OperationCode.Delete,
                            0,
                            string.Format("{0}伝票、仕入SEQ番号:{1}を削除", this._stockSlipInputAcs.GetSupplierFormalName(this._stockSlipInputAcs.StockSlip.SupplierFormal), this._stockSlipInputAcs.StockSlip.SupplierSlipNo));
                    }

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "削除しました。",
                        -1,
                        MessageBoxButtons.OK);

                    // 画面初期化処理
                    this.Clear(false, false);

                    this.timer_InitialSetFocus.Enabled = true;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)				// 排他（別端末更新済）
                {
                    // 仕入担当にフォーカスをセット（一時的に）
                    this.tEdit_StockAgentCode.Focus();

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "現在、編集中の仕入データは既に更新されています。" + "\r\n" + "\r\n" +
                        "最新の情報を取得します。",
                        -1,
                        MessageBoxButtons.OK);

                    // 再読込処理
                    this.ReLoad(this._stockSlipInputAcs.StockSlip.EnterpriseCode, this._stockSlipInputAcs.StockSlip.SupplierFormal, this._stockSlipInputAcs.StockSlip.SupplierSlipNo);

                    // 明細グリッドにフォーカスをセット
                    this._stockSlipDetailInput.Focus();
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)				// 排他（別端末物理削除済）
                {
                    // 仕入担当にフォーカスをセット（一時的に）
                    this.tEdit_StockAgentCode.Focus();

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "現在、編集中の仕入データは既に削除されています。",
                        -1,
                        MessageBoxButtons.OK);

                    this.Clear(false, true);

                    this.timer_InitialSetFocus.Enabled = true;
                }
                // ADD 2011/08/09 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>>>
                else if (status == ctSTATUS_CHK_SEND_ERR)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        ctMSG_CHK_SEND_ERR,
                        status,
                        MessageBoxButtons.OK);
                }
                // ADD 2011/08/09 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<<<
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        this._stockSlipInputAcs.GetSupplierFormalName(this._stockSlipInputAcs.StockSlip) + "データの削除に失敗しました。",
                        status,
                        MessageBoxButtons.OK);
                }
            }          
        }//add 2011/12/27 陳建明 Redmine #27374

        /// <summary>
        /// 伝票複写処理
        /// </summary>
        private void CopySlip( bool isConfirm )
        {
            bool canRed = this.ShowSaveCheckDialog(isConfirm);

            if (!canRed)
            {
                return;
            }

            //this.tEdit_StockAgentCode.Focus();// DEL 黄興貴 2015/04/01 Redmine#45073 障害No.179

            MAKON01110UD supplierSlipNoInputDialog = new MAKON01110UD(this._stockSlipInputAcs.StockSlip.SupplierFormal, this._stockSlipInputAcs.StockSlip.SupplierSlipNo, true, MAKON01320UA.ExtractSlipCdType.All);
            this._controlScreenSkin.SettingScreenSkin(supplierSlipNoInputDialog);
            DialogResult dialogResult = supplierSlipNoInputDialog.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
                this.tEdit_StockAgentCode.Focus();// ADD 黄興貴 2015/04/01 Redmine#45073 障害No.179
                StockSlip stockSlip = supplierSlipNoInputDialog.StockSlip;
                List<StockDetail> stockDetailList = supplierSlipNoInputDialog.StockDetailList;
				List<StockWork> stockWorkList = supplierSlipNoInputDialog.StockWorkList;

				this.SlipCopy(stockSlip, stockDetailList, stockWorkList);
            }

            this._prevControl = this.GetActiveControl();
        }

        /// <summary>
        /// 伝票複写
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierFormal">仕入形式</param>
        /// <param name="supplierSlipNo">仕入伝票番号</param>
        private void SlipCopy( string enterpriseCode, int supplierFormal, int supplierSlipNo )
        {
            StockSlip stockSlip;
            StockSlip baseStockSlip; // 2009.03.25
            List<StockDetail> stockDetailList;
			List<StockDetail> addUpSrcDetailList;
			PaymentSlp paymentSlp;
            List<PaymentDtl> paymentDtlList;
			List<SalesTemp> salesTempList;
			List<StockWork> stockWorkList;

            // データリード処理
            this.Cursor = Cursors.WaitCursor;
            //int status = this._stockSlipInputAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
            int status = this._stockSlipInputAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, supplierFormal, supplierSlipNo, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
            this.Cursor = Cursors.Default;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
				this.SlipCopy(stockSlip, stockDetailList, stockWorkList);
            }
        }

        /// <summary>
        /// 伝票複写
        /// </summary>
        /// <param name="stockSlip">仕入データオブジェクト</param>
		/// <param name="stockDetailList">仕入明細データオブジェクトリスト</param>
		/// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
        /// <remarks>
        /// <br>Update Note : 2020/02/24 田建委</br>
        /// <br>管理番号    : 11570208-00</br>
        /// <br>            : PMKOBETSU-2912消費税税率機能追加対応</br>
        /// </remarks>
		private void SlipCopy( StockSlip stockSlip, List<StockDetail> stockDetailList, List<StockWork> stockWorkList )
        {
            // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
            bool handTaxRateFlg = false;
            DateTime targetdate = (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay;
            taxRateSetMaster = this._stockSlipInputInitDataAcs.GetTaxRate(targetdate);
            if (stockSlip.SuppCTaxLayCd == 0 && this._stockSlipInputInitDataAcs.TaxRateValue != 0 
                && taxRateSetMaster != this._stockSlipInputInitDataAcs.TaxRateValue)
            {
                stockSlip.SupplierConsTaxRate = this._stockSlipInputInitDataAcs.TaxRateValue;
                this.uLabel_StockPriceConsTaxTotalTitle2.Text = "税(" + (stockSlip.SupplierConsTaxRate * 100).ToString() + "%" + ")";
                this.uLabel_StockPriceConsTaxTotalTitle.Visible = false;
                this.uLabel_StockPriceConsTaxTotalTitle2.Visible = true;
                this.uLabel_StockPriceConsTaxTotalTitle2.SendToBack();
                handTaxRateFlg = true;
            }
            else
            {
                DisplayNameSetting();
                this.uLabel_StockPriceConsTaxTotalTitle.Visible = true;
                this.uLabel_StockPriceConsTaxTotalTitle2.Visible = false;
            }
            // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<
            StockSlip baseStockSlip = stockSlip.Clone();

            // 複写伝票情報生成処理
            this._stockSlipInputAcs.CreateSlipCopyInfo(ref stockSlip);

            // 表示用伝票区分設定処理
            StockSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref stockSlip);

            // キャッシュ処理
            this._stockSlipInputAcs.Cache(stockSlip, baseStockSlip, stockDetailList, stockWorkList);

            // コピー伝票明細情報生成処理
			this._stockSlipInputAcs.CreateSlipCopyDetailInfo(stockWorkList);

            long stockPriceConsTax = this._stockSlipInputAcs.StockSlip.StockPriceConsTax; // ADD 2010/12/02
            // 仕入金額計算処理
            this._stockSlipDetailInput.CalculationStockPrice();

            // 仕入金額変更後発生イベント処理
            this.StockSlipDetailInput_StockPriceChanged(this, new EventArgs());

            // 仕入データクラス→画面格納処理
            this.SetDisplay(this._stockSlipInputAcs.StockSlip);

            // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
            // 軽減税率を利用されない場合
            if (handTaxRateFlg == false)
            {
            // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<
                // --- ADD 2010/12/02 ---------->>>>>
                if (this._stockSlipInputAcs.StockSlip.SupplierSlipCd != 20)
                {
                    long taxAdjust = stockPriceConsTax - this._stockSlipInputAcs.StockSlip.StockPriceConsTax;
                    if (stockSlip.StockGoodsCd != 6)
                    {
                        this._stockSlipInputAcs.StockSlip.TaxAdjust = taxAdjust;
                    }
                    tNedit_StockPriceConsTaxTotal.SetValue(stockPriceConsTax);

                    this._stockSlipInputAcs.StockSlip.StockTtlPricTaxInc = this._stockSlipInputAcs.StockSlip.StockTtlPricTaxInc + taxAdjust;
                    this._stockSlipInputAcs.StockSlip.StockPriceConsTax = this._stockSlipInputAcs.StockSlip.StockPriceConsTax + taxAdjust;
                    this._stockSlipInputAcs.StockSlip.StockOutTax = this._stockSlipInputAcs.StockSlip.StockOutTax + taxAdjust;
                    this._stockSlipInputAcs.StockSlip.StockTotalPrice = this._stockSlipInputAcs.StockSlip.StockTotalPrice + taxAdjust;
                    this._stockSlipInputAcs.StockSlip.AccPayConsTax = this._stockSlipInputAcs.StockSlip.AccPayConsTax + taxAdjust;
                    tNedit_TotalPrice.SetValue(tNedit_StockTotalPrice.GetValue() + tNedit_StockPriceConsTaxTotal.GetValue());
                }
                else
                {
                    long taxAdjust = stockPriceConsTax - this._stockSlipInputAcs.StockSlip.StockPriceConsTax;
                    if (stockSlip.StockGoodsCd != 6)
                    {
                        this._stockSlipInputAcs.StockSlip.TaxAdjust = taxAdjust;
                    }
                    tNedit_StockPriceConsTaxTotal.SetValue(stockPriceConsTax * (-1));

                    this._stockSlipInputAcs.StockSlip.StockTtlPricTaxInc = this._stockSlipInputAcs.StockSlip.StockTtlPricTaxInc + taxAdjust;
                    this._stockSlipInputAcs.StockSlip.StockPriceConsTax = this._stockSlipInputAcs.StockSlip.StockPriceConsTax + taxAdjust;
                    this._stockSlipInputAcs.StockSlip.StockOutTax = this._stockSlipInputAcs.StockSlip.StockOutTax + taxAdjust;
                    this._stockSlipInputAcs.StockSlip.StockTotalPrice = this._stockSlipInputAcs.StockSlip.StockTotalPrice + taxAdjust;
                    this._stockSlipInputAcs.StockSlip.AccPayConsTax = this._stockSlipInputAcs.StockSlip.AccPayConsTax + taxAdjust;
                    tNedit_TotalPrice.SetValue(tNedit_StockTotalPrice.GetValue() + tNedit_StockPriceConsTaxTotal.GetValue());
                }
                // --- ADD 2010/12/02 ----------<<<<<
            } // ADD 田建委 2020/02/24 PMKOBETSU-2912の対応

            // 明細グリッド設定処理
            this._stockSlipDetailInput.SettingGrid();

            // ガイドボタンツール有効無効設定処理
			this.SettingGuideButtonToolEnabled(this._stockSlipDetailInput);

            // データ変更フラグプロパティをtrueにする
            this._stockSlipInputAcs.IsDataChanged = true;

            this._prevControl = this.GetActiveControl();
        }

		/// <summary>
		/// ガイド起動処理
		/// </summary>
		private void ExecuteGuide()
		{
			if (this._stockSlipDetailInput.ContainsFocus)
			{
				this._stockSlipDetailInput.ExecuteGuide();
			}
			//else if (this._salesTempInput.ContainsFocus)
			//{
			//    this._salesTempInput.ExecuteGuide(this._guideButton.SharedProps.Tag.ToString());
			//}
			else if (this._guideButton.SharedProps.Tag != null)
			{
				switch (this._guideButton.SharedProps.Tag.ToString())
				{
					case ctGUIDE_NAME_SectionGuide:
						{
							this.uButton_SectionGuide_Click(this.uButton_SectionGuide, new EventArgs());
							break;
						}
					case ctGUIDE_NAME_SubSectionGuide:
						{
							this.uButton_SubSectionGuide_Click(this.uButton_SubSectionGuide, new EventArgs());
							break;
						}

					case ctGUIDE_NAME_EmployeeGuide:
						{
							this.uButton_EmployeeGuide_Click(this.uButton_EmployeeGuide, new EventArgs());
							break;
						}
					case ctGUIDE_NAME_SupplierSlipGuide:
						{
							this.uButton_SupplierSlipGuide_Click(this.uButton_SupplierSlipGuide, new EventArgs());
							break;
						}
					case ctGUIDE_NAME_SupplierGuide:
						{
							this.uButton_SupplierGuide_Click(this.uButton_SupplierGuide, new EventArgs());
							break;
						}
					case ctGUIDE_NAME_WarehouseGuide:
						{
							this.uButton_WarehouseGuide_Click(this.uButton_WarehouseGuide, new EventArgs());
							break;
						}
					case ctGUIDE_NAME_SupplierSlipNote1Guide:
						{
							this.uButton_SlipNote_Click(this.uButton_SlipNote1, new EventArgs());
							break;
						}
					case ctGUIDE_NAME_SupplierSlipNote2Guide:
						{
							this.uButton_SlipNote_Click(this.uButton_SlipNote2, new EventArgs());
							break;
						}
                    case ctGUIDE_NAME_ReturnReasonGuide:
                        {
                            this.uButton_RetGoodsReason_Click(this.uButton_RetGoodsReason, new EventArgs());
                            break;
                        }

				}
			}
		}

		/// <summary>
		/// 仕入先設定処理
		/// </summary>
		/// <param name="isClear">true:クリアする false:クリアしない</param>
		/// <param name="seldata">得意先検索結果クラス</param>
        /// <remarks>
        /// <br>Update Note : 2020/02/24 田建委</br>
        /// <br>管理番号    : 11570208-00</br>
        /// <br>            : PMKOBETSU-2912消費税税率機能追加対応</br>
        /// </remarks>
		private void SettingSupplier( bool isClear, Supplier retSupplier )
		{
			if (isClear)
			{
				// 画面初期化処理
				bool canClear = this.Clear(true, true);

				if (!canClear) return;
			}
			else
			{
				if (!this.tNedit_SupplierCd.Enabled)
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"選択中の" + this._stockSlipInputAcs.GetSupplierFormalName(this._stockSlipInputAcs.StockSlip) + "伝票に対して仕入先を変更することができません。",
						-1,
						MessageBoxButtons.OK);

					return;
				}
			}

			// 仕入先を自動で設定
			StockSlip stockSlip = this._stockSlipInputAcs.StockSlip.Clone();
            StockSlip stockSlipCurrent = this._stockSlipInputAcs.StockSlip.Clone();

			bool reCalcStockUnitPrice = false;
            bool clearRateInfo = false;

			Supplier supplier;
			this.Cursor = Cursors.WaitCursor;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
			int status = this._supplierAcs.Read(out supplier, retSupplier.EnterpriseCode, retSupplier.SupplierCd);

			this.Cursor = Cursors.Default;

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				if (stockSlip.SupplierCd != supplier.SupplierCd)
				{
					// 得意先（仕入先）情報設定処理
					this._stockSlipInputAcs.DataSettingStockSlip(ref stockSlip, supplier);

					// 仕入明細データセッティング処理（課税区分設定）
                    this._stockSlipInputAcs.StockDetailRowTaxationCodeSetting(stockSlip.SuppCTaxLayCd, stockSlip.SuppTtlAmntDspWayCd);

					if (this._stockSlipInputAcs.ExistStockDetailCanGoodsPriceReSettingData())
					{
                        // 転嫁方式が変わった場合は課税区分設定(値引きが変わる為）
                        if (stockSlipCurrent.SuppCTaxLayCd != stockSlip.SuppCTaxLayCd)
                        {
                            // 転嫁方式：非課税を経由した場合は税率によって各種金額再計算
                            if (( stockSlipCurrent.SuppCTaxLayCd == 9 ) ||
                                ( stockSlip.SuppCTaxLayCd == 9 ))
                            {
                                this._stockSlipInputAcs.StockDetailRowTaxRateChanged(stockSlip.SupplierConsTaxRate, stockSlip.SuppCTaxLayCd);
                            }
                        }


						string msg = "仕入先が変更されました。" + "\r\n" + "\r\n" + "商品価格を再取得しますか？";

						DialogResult dialogResult = TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							msg,
							0,
							MessageBoxButtons.YesNo,
							MessageBoxDefaultButton.Button1);

						if (dialogResult == DialogResult.Yes)
						{
							reCalcStockUnitPrice = true;
						}
                        else 
                        {
                            clearRateInfo = true;
                        }
						this.SupplierChangedCall(reCalcStockUnitPrice);
					}
				}
				//}
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"仕入先が存在しません。",
					-1,
					MessageBoxButtons.OK);

				return;
			}
			else
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					"仕入先の取得に失敗しました。",
					status,
					MessageBoxButtons.OK);

				return;
			}
            // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
            // 税率取得の対象は、仕入形式によって変更(仕入：仕入日、入荷：入荷日）
            DateTime targetdate = (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay;
            StockPriceConsTaxTotalTitleSetC(ref stockSlip, targetdate);
            // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<
			// 仕入データクラス→画面格納処理
			this.SetDisplay(stockSlip);

			// 仕入データキャッシュ処理
			this._stockSlipInputAcs.Cache(stockSlip);

			// データ変更フラグプロパティをTrueにする
			this._stockSlipInputAcs.IsDataChanged = true;

			if (reCalcStockUnitPrice)
			{
				this._stockSlipInputAcs.StockDetailTableGoodsPriceReSetting();
			}

            if (clearRateInfo)
            {
                this._stockSlipInputAcs.StockDetailTableClearRateInfo();
            }

			// 明細グリッドセル設定処理
			this._stockSlipDetailInput.SettingGrid();

			// 仕入金額計算処理
			this._stockSlipDetailInput.CalculationStockPrice();

			// 仕入金額変更後発生イベント処理
			this.StockSlipDetailInput_StockPriceChanged(this, new EventArgs());

			this._stockSlipDetailInput.SettingFooterEventCall();
		}

		/// <summary>
		/// スーパースライダー伝票修正イベント
		/// </summary>
		/// <param name="seldata">パラメータクラス</param>
        /// <br>Update Note : 2020/02/24 田建委</br>
        /// <br>管理番号    : 11570208-00</br>
        /// <br>            : PMKOBETSU-2912消費税税率機能追加対応</br>
		private void SuperSlider_ModifyStockSlip(SearchRetStockSlip seldata)
		{
			// 画面初期化処理
			bool isClear = this.Clear(true, true);

			if (isClear)
			{
                StockSlip baseStockSlip; // 2009.03.25

				// データリード処理
				this.Cursor = Cursors.WaitCursor;
                //int status = this._stockSlipInputAcs.ReadDBData(seldata.EnterpriseCode, seldata.SupplierFormal, seldata.SupplierSlipNo); // 2009.03.25
                int status = this._stockSlipInputAcs.ReadDBData(seldata.EnterpriseCode, seldata.SupplierFormal, seldata.SupplierSlipNo, out baseStockSlip); // 2009.03.25
                this.Cursor = Cursors.Default;

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					StockSlip stockSlip = this._stockSlipInputAcs.StockSlip.Clone();

                    // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
                    ShowMessage(stockSlip, stockSlip.SupplierConsTaxRate);
                    slipSrcTaxFlg = false;
                    // 税率取得の対象は、仕入形式によって変更(仕入：仕入日、入荷：入荷日）
                    DateTime targetdate = (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay;
                    taxRateSetMaster = this._stockSlipInputInitDataAcs.GetTaxRate(targetdate);
                    if (stockSlip.SupplierConsTaxRate != taxRateSetMaster)
                    {
                        // 伝票呼出軽減税率フラグ
                        slipSrcTaxFlg = true;

                    }
                    // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<

					// 仕入データ入力モード設定処理
					this.SettingStockSlipInputMode(ref stockSlip);

                    // 表示用伝票区分設定処理
                    StockSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref stockSlip);

					// 仕入データクラス→画面格納処理
					this.SetDisplay(stockSlip);

					// 仕入データキャッシュ処理
					this._stockSlipInputAcs.Cache(stockSlip);

					// 入荷計上伝票、赤伝の場合は空白行を削除する
                    if ((stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ArrivalAddUp) || (stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red))
                    {
                        this._stockSlipDetailInput.DeleteEmptyRow(true);
                    }
                    // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    else
                    {
                        if (baseStockSlip.SuppCTaxLayCd != stockSlip.SuppCTaxLayCd)
                        {
                            // 仕入金額計算処理
                            this._stockSlipDetailInput.CalculationStockPrice();

                            // 仕入金額変更後発生イベント処理
                            this.StockSlipDetailInput_StockPriceChanged(this, new EventArgs());
                        }
                    }
                    // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

					// 明細グリッド設定処理
					this._stockSlipDetailInput.SettingGrid();

					if (( this._stockSlipDetailInput.Enabled ) && ( stockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_Red ))
					{
						this._stockSlipDetailInput.Focus();
					}
					else
					{
						//this.tEdit_SupplierSlipNote1.Focus();  //DEL 2011/11/30 gezh redmine#8383
                        this.tNedit_SupplierSlipNote1.Focus();   //ADD 2011/11/30 gezh redmine#8383
					}

                    DisplayNameSetting2(stockSlip);// ADD 田建委 2020/02/24 PMKOBETSU-2912の対応
				}
				else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"該当するデータが存在しません。",
						-1,
						MessageBoxButtons.OK);

					return;
				}
				else
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_STOPDISP,
						this.Name,
						"仕入・入荷データの取得に失敗しました。",
						status,
						MessageBoxButtons.OK);

					return;
				}
			}

			this._prevControl = this.GetActiveControl();
		}

		/// <summary>
		/// スーパースライダー新規伝票入力イベント
		/// </summary>
		/// <param name="seldata">パラメータクラス</param>
		private void SuperSlider_CreateNewSlip(Supplier seldata)
		{
			// クリア処理
			this.Clear(true, true);
			if (seldata.SupplierCd != 0)
			{
				this.SettingSupplier(false, seldata);
			}
			this.timer_InitialSetFocus.Enabled = true;
		}

		/// <summary>
		/// スーパースライダー仕入先選択イベント
		/// </summary>
		/// <param name="seldata">パラメータクラス</param>
		private void SuperSlider_SelectedCustomer(Supplier seldata)
		{
			// 仕入先設定処理
			this.SettingSupplier(false, seldata);
		}

		/// <summary>
		/// スーパースライダー赤伝発行イベント
		/// </summary>
		/// <param name="seldata">パラメータクラス</param>
		private void SuperSlider_RedWriteStockSlip(SearchRetStockSlip seldata)
		{
			// 赤伝処理
			this.RedSlip(seldata.EnterpriseCode, seldata.SupplierFormal, seldata.SupplierSlipNo);
		}

		/// <summary>
		/// スーパースライダー入荷計上イベント
		/// </summary>
		/// <param name="seldata">パラメータクラス</param>
		private void SuperSlider_TrustAppropriateStockSlip(SearchRetStockSlip seldata)
		{
			// 入荷計上処理
			this.ArrivalAppropriate(seldata.EnterpriseCode, seldata.SupplierFormal, seldata.SupplierSlipNo);
		}

		/// <summary>
		/// スーパースライダー伝票コピーイベント
		/// </summary>
		/// <param name="seldata">パラメータクラス</param>
		private void SuperSlider_SlipCopy( SearchRetStockSlip seldata )
		{
			// 入荷計上処理
			this.SlipCopy(seldata.EnterpriseCode, seldata.SupplierFormal, seldata.SupplierSlipNo);
		}

		/// <summary>
		/// 保存確認ダイアログ表示処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		/// <returns>確認後OK 確認後NG</returns>
        private bool ShowSaveCheckDialog(bool isConfirm)
        {
            bool checkedValue = false;

            if (( isConfirm ) && ( this._stockSlipInputAcs.IsDataChanged ))
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                    "登録してもよろしいですか？",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    checkedValue = this.Save(true, false);
                    // --- ADD 2013/02/15 Y.Wakita ---------->>>>>
                    if (checkedValue)
                    {
                        this.AfterSaveDisplay();
                    }
                    // --- ADD 2013/02/15 Y.Wakita ----------<<<<<
                }
                else if (dialogResult == DialogResult.No)
                {
                    checkedValue = true;
                }
                else
                {
                    //
                }
            }
            else
            {
                checkedValue = true;
            }

            return checkedValue;
        }

		/// <summary>
		/// 仕入データ入力モード設定処理
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
        /// <br>Update Note : 2011/12/27 陳建明</br>
        /// <br>管理番号    : 10707327-00 2012/01/25配信分</br>
        /// <br>              redmine#27374 仕入伝票入力/締済のチェックの対応</br>
        /// <br>Update Note : 2012/03/13 鄧潘ハン</br>
        /// <br>管理番号    : 10707327-00 2012/03/28配信分</br>
        /// <br>              Redmine#27374 仕入伝票入力でガイドから呼出した場合削除でエラーになる件の対応</br>
        private void SettingStockSlipInputMode(ref StockSlip stockSlip)
		{
			if (stockSlip.DebitNoteDiv == 1)
			{
                // 赤伝の場合は何もしない
                stockSlip.InputMode = StockSlipInputAcs.ctINPUTMODE_StockSlip_Red;
			}
			else if (stockSlip.DebitNoteDiv == 2)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"既に「赤伝」が発行されている為、編集できません。" + "\r\n" + "\r\n" + "参照モードで表示します。",
					-1,
					MessageBoxButtons.OK);

				stockSlip.InputMode = StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly;
			}
            else
            {
                bool isAddUp = false;
                if (stockSlip.SupplierFormal == 0)
                {
                    string message;
                    isAddUp = this._stockSlipInputAcs.CheckAddUp(stockSlip, 1, out message);
                    //_isCannotModify = isAddUp;//add 2011/12/27 陳建明 Redmine #27374//DEL 2012/03/13 鄧潘ハン Redmine #27374
                    this._stockSlipInputAcs.IsCannotModify = isAddUp;//ADD 2012/03/13 鄧潘ハン Redmine #27374
                    if (isAddUp)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            message + "\r\n" + "\r\n" + "参照モードで表示します。",
                            -1,
                            MessageBoxButtons.OK);

                        stockSlip.InputMode = StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp;
                    }
                }

                if (!isAddUp)
                {
                    if (this._stockSlipInputAcs.ExistAddUpDetail())
                    {
                        if (stockSlip.SupplierSlipCd == 20)
                        {
                            stockSlip.InputMode = StockSlipInputAcs.ctINPUTMODE_StockSlip_Return;
                        }
                    }
                }
            }
		}

		/// <summary>
		/// 初期データ設定処理
		/// </summary>
		/// <param name="stockSlip">仕入データオブジェクト</param>
		private void SettingInitData( StockSlip stockSlip )
		{
			if (this._stockInputConstructionAcs.SaveInfoStoreValue == StockSlipInputConstructionAcs.SaveInfoStore_OFF)
            {
                // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ---------->>>>>
                if (this._stockInputConstructionAcs.SaveAgentStoreValue == StockSlipInputConstructionAcs.SaveAgentStore_ON)
                {
                    // FIXME:仕入入力用初期値クラスをデシリアライズ
                    this._stockSlipInputInitData.Deserialize();
                    stockSlip.StockAgentCode = this._stockSlipInputInitData.StockAgentCode;
                    stockSlip.StockAgentName = GetEmployeeName(stockSlip.StockAgentCode);
                }
                // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ----------<<<<<
				return;
			}

            this._stockSlipInputInitData.Deserialize();

			if (this._enterpriseCode == this._stockSlipInputInitData.EnterpriseCode)
			{
				if (this._stockSlipInputInitData.SupplierCode != 0)
				{
					this.Cursor = Cursors.WaitCursor;
					Supplier supplier;
                    if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
					int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, this._stockSlipInputInitData.SupplierCode);
					this.Cursor = Cursors.Default;

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						if (supplier != null)
						{
							// 得意先（仕入先）情報設定処理
							this._stockSlipInputAcs.DataSettingStockSlip(ref stockSlip, supplier);

							// 仕入明細データセッティング処理（課税区分設定）
                            this._stockSlipInputAcs.StockDetailRowTaxationCodeSetting(stockSlip.SuppCTaxLayCd, stockSlip.SuppTtlAmntDspWayCd);
						}
					}
				}
                if (( !string.IsNullOrEmpty(this._stockSlipInputInitData.WarehouseCode) ))
                {
                    string name = this._stockSlipInputInitDataAcs.GetName_FromWarehouse(this._stockSlipInputInitData.WarehouseCode);

                    if (!string.IsNullOrEmpty(name))
                    {
                        stockSlip.WarehouseCode = this._stockSlipInputInitData.WarehouseCode;
                        stockSlip.WarehouseName = name;
                    }
                }
			}

            // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ---------->>>>>
            if (this._stockInputConstructionAcs.SaveAgentStoreValue == StockSlipInputConstructionAcs.SaveAgentStore_ON)
            {
                stockSlip.StockAgentCode = this._stockSlipInputInitData.StockAgentCode;
                stockSlip.StockAgentName = GetEmployeeName(stockSlip.StockAgentCode);
            }
            // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ----------<<<<<
		}

        // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ---------->>>>>
        /// <summary>
        /// 従業員名を取得します。
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>
        /// 従業員マスタより該当する従業員名を返します
        /// ※該当しない場合、<c>string.Empty</c>を返します。
        /// </returns>
        private string GetEmployeeName(string employeeCode)
        {
            string employeeName = string.Empty;
            {
                if (!string.IsNullOrEmpty(employeeCode.Trim()))
                {
                    EmployeeAcs employeeAcs = new EmployeeAcs();
                    {
                        Employee employee = null;
                        int status = employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);
                        if (employee != null)
                        {
                            employeeName = employee.Name;
                        }
                    }
                }
            }
            return employeeName;
        }
        // ADD 2010/01/06 MANTIS対応[14857]：担当者を保存後も保持する設定を追加 ----------<<<<<

		#region フォーカス制御関連

		/// <summary>
		/// コントロールインデックス取得処理
		/// </summary>
		/// <param name="prevCtrl">現在のコントロールの名称</param>
		/// <param name="mode">0:上から 1:下から</param>
		/// <returns>コントロールインデックス</returns>
		private int GetGontrolIndex( string prevCtrl, StockSlipInputAcs.MoveMethod mode )
		{
			int controlIndex = -1;

			switch (mode)
			{
				case StockSlipInputAcs.MoveMethod.NextMove:
					{
						if (this._controlIndexForwordDictionary.ContainsKey(prevCtrl))
						{
							controlIndex = this._controlIndexForwordDictionary[prevCtrl];
						}

						break;
					}
				case StockSlipInputAcs.MoveMethod.PrevMove:
					{
						if (this._controlIndexBackDictionary.ContainsKey(prevCtrl))
						{
							controlIndex = this._controlIndexBackDictionary[prevCtrl];
						}

						break;
					}
			}

			return controlIndex;
		}

		/// <summary>
		/// ネクストコントロール取得処理
		/// </summary>
		/// <param name="prevCtrl">現在のコントロール</param>
		/// <param name="mode">0:上から 1:下から</param>
		/// <returns>次のコントロール</returns>
		private Control GetNextControl( Control prevCtrl, StockSlipInputAcs.MoveMethod mode )
		{

			Control control = null;
			Control nextCtrl = null;

			HeaderFocusConstructionList headerFocusConstructionList = this._stockInputConstructionAcs.HeaderFocusConstructionListValue;
			int targetControlIndex = 0;
			int prevControlIndex = this.GetGontrolIndex(prevCtrl.Name, mode);

            if (prevControlIndex < 0) return this.GetNextControlException(prevCtrl, mode);

			switch (mode)
			{
				case StockSlipInputAcs.MoveMethod.NextMove:
					{
						foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
						{
							control = this._headerItemsDictionary[headerFocusConstruction.Caption];
							targetControlIndex = this.GetGontrolIndex(control.Name, mode);

							if (targetControlIndex == 0)
								nextCtrl = this._stockSlipDetailInput.uGrid_Details;

							if (( control.Enabled ) &&
								( control.Visible ) &&
								( prevCtrl != control ) &&
								( prevControlIndex < targetControlIndex ))
							{
								nextCtrl = control;
								break;
							}
						}
						break;
					}
				case StockSlipInputAcs.MoveMethod.PrevMove:
					{
						for (int count = headerFocusConstructionList.headerFocusConstruction.Count - 1; count >= 0; count--)
						{
							HeaderFocusConstruction headerFocusConstruction = headerFocusConstructionList.headerFocusConstruction[count];

							control = this._headerItemsDictionary[headerFocusConstruction.Caption];

							if (( control.Enabled ) &&
								( control.Visible ) &&
								( prevCtrl != control ) &&
								( prevControlIndex < this.GetGontrolIndex(control.Name, mode) ))
							{
								nextCtrl = control;
								break;
							}
						}
						break;
					}
			}

			return nextCtrl;
		}

        /// <summary>
        /// ネクストコントロール取得処理
        /// </summary>
        /// <param name="prevCtrl">現在のコントロール</param>
        /// <param name="mode">0:上から 1:下から</param>
        /// <returns>次のコントロール</returns>
        private Control GetNextControlException(Control prevCtrl, StockSlipInputAcs.MoveMethod mode)
        {
            Control control = null;
            Control nextCtrl = null;

            HeaderFocusConstructionList headerFocusConstructionList = this._stockInputConstructionAcs.HeaderFocusConstructionListValue;
            bool selectFlg = false;

            switch (mode)
            {
                case StockSlipInputAcs.MoveMethod.NextMove:
                    {
                        foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
                        {
                            control = this._headerItemsDictionary[headerFocusConstruction.Caption];

                            if (selectFlg)
                            {
                                if (( control.Enabled ) && ( control.Visible ))
                                {
                                    nextCtrl = control;
                                    break;
                                }
                                else
                                {
                                    nextCtrl = this.GetNextControlException(control, mode);
                                    break;
                                }
                            }
                            if (prevCtrl == control) selectFlg = true;
                        }
                        if (nextCtrl == null) nextCtrl = this._stockSlipDetailInput.uGrid_Details;
                        break;
                    }
                case StockSlipInputAcs.MoveMethod.PrevMove:
                    {
                        for (int count = headerFocusConstructionList.headerFocusConstruction.Count - 1; count >= 0; count--)
                        {
                            HeaderFocusConstruction headerFocusConstruction = headerFocusConstructionList.headerFocusConstruction[count];

                            control = this._headerItemsDictionary[headerFocusConstruction.Caption];

                            if (selectFlg)
                            {
                                if (( control.Enabled ) && ( control.Visible ))
                                {
                                    nextCtrl = control;
                                    break;
                                }
                                else
                                {
                                    nextCtrl = this.GetNextControlException(control, mode);
                                    break;
                                }
                            }
                            if (prevCtrl == control) selectFlg = true;
                        }
                        if (nextCtrl == null) nextCtrl = prevCtrl;
                        break;
                    }
            }
            if (nextCtrl == null) nextCtrl = this.GetNextControlException(prevCtrl, mode);

            return nextCtrl;
        }

		/// <summary>
		/// ヘッダー部 フォーカス先頭コントロール取得処理
		/// </summary>
		/// <returns>先頭コントロール</returns>
		private Control GetHeaderFirstControl()
		{
			Control retControl = null;

			if (( this._stockInputConstructionAcs.FocusPositionValue == StockSlipInputConstructionAcs.ForcusPosition_SectionCode ) && ( this.tEdit_SectionCode.Enabled ) && ( this.tEdit_SectionCode.Visible ))
			{
				retControl = tEdit_SectionCode;
			}
			else if (( this._stockInputConstructionAcs.FocusPositionValue == StockSlipInputConstructionAcs.ForcusPosition_SupplierCode ) && ( this.tNedit_SupplierCd.Enabled ) && ( this.tNedit_SupplierCd.Visible ))
			{
				retControl = tNedit_SupplierCd;
			}
			else if (( this._stockInputConstructionAcs.FocusPositionValue == StockSlipInputConstructionAcs.ForcusPosition_StockAgentCode ) && ( this.tEdit_StockAgentCode.Enabled ) && ( this.tEdit_StockAgentCode.Visible ))
			{
				retControl = tEdit_StockAgentCode;
			}
			else if (( this._stockInputConstructionAcs.FocusPositionValue == StockSlipInputConstructionAcs.ForcusPosition_SupplierFormal ) && ( this.tComboEditor_SupplierFormal.Enabled ) && ( this.tComboEditor_SupplierFormal.Visible ))
			{
				retControl = tComboEditor_SupplierFormal;
			}
			else if (( this._stockInputConstructionAcs.FocusPositionValue == StockSlipInputConstructionAcs.ForcusPosition_SupplierSlipNo ) && ( this.tNedit_SupplierSlipNo.Enabled ) && ( this.tNedit_SupplierSlipNo.Visible ))
			{
				retControl = tNedit_SupplierSlipNo;
			}
            else if (( this._stockInputConstructionAcs.FocusPositionValue == StockSlipInputConstructionAcs.ForcusPosition_PartySaleSlipNum ) && ( this.tEdit_PartySaleSlipNum.Enabled ) && ( this.tEdit_PartySaleSlipNum.Visible ))
            {
                retControl = tEdit_PartySaleSlipNum;
            }
            else
            {
                HeaderFocusConstructionList headerFocusConstructionList = this._stockInputConstructionAcs.HeaderFocusConstructionListValue;

                foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
                {
                    Control ctrl = this._headerItemsDictionary[headerFocusConstruction.Caption];
                    if (( ctrl != null ) && ( ctrl.Enabled ) && ( ctrl.Visible ))
                    {
                        retControl = ctrl;
                        break;
                    }
                }
            }
			
			return retControl;
		}

        /// <summary>
        /// ヘッダー部 フォーカス先頭コントロール取得処理（保存後）
        /// </summary>
        /// <returns>先頭コントロール</returns>
        private Control GetHeaderFirstControlAfterSave()
        {
            Control retControl = null;

            if (( this._stockInputConstructionAcs.FocusPositionAfterSaveValue == StockSlipInputConstructionAcs.FocusPositionAfterSave_PartySaleSlipNum ) && ( this.tEdit_PartySaleSlipNum.Enabled ) && ( this.tEdit_PartySaleSlipNum.Visible ))
            {
                retControl = tEdit_PartySaleSlipNum;
            }
            else
            {
                retControl = this.GetHeaderFirstControl();
            }

            return retControl;
        }
		
		/// <summary>
		/// フォーカス移動Dictionary設定処理
		/// </summary>
		private void SettingFocusDictionary()
		{
			HeaderFocusConstructionList headerFocusConstructionList = this._stockInputConstructionAcs.HeaderFocusConstructionListValue;

			if (( headerFocusConstructionList.headerFocusConstruction != null ) &&
				( headerFocusConstructionList.headerFocusConstruction.Count != 0 ))
			{

				Dictionary<string, Control> tempDic = new Dictionary<string, Control>();
				foreach (string key in this._headerItemsDictionary.Keys)
				{
					bool flg = false;
					foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
					{
						if (headerFocusConstruction.Caption == key)
						{
							flg = true;
							break;
						}
					}
					if (flg != true) tempDic.Add(key, this._headerItemsDictionary[key]);
				}

				if (tempDic.Count != 0)
				{
					foreach (string key in tempDic.Keys)
					{
						HeaderFocusConstruction tempHeaderFocusConstruction = new HeaderFocusConstruction();
						tempHeaderFocusConstruction.Caption = key;
						tempHeaderFocusConstruction.EnterStop = true;
						tempHeaderFocusConstruction.Key = tempDic[key].Name;
						headerFocusConstructionList.headerFocusConstruction.Add(tempHeaderFocusConstruction);
					}
				}
				this._stockInputConstructionAcs.HeaderFocusConstructionListValue = headerFocusConstructionList;

				int controlIndexForword = 0;
				int controlIndexBack = 99;
				this._controlIndexForwordDictionary.Clear();
				this._controlIndexBackDictionary.Clear();

				List<HeaderFocusConstruction> tempHeaderFocusConstructionList = new List<HeaderFocusConstruction>();

				foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
				{
					if (this._headerItemsDictionary.ContainsKey(headerFocusConstruction.Caption) == true)
					{
						Control control = this._headerItemsDictionary[headerFocusConstruction.Caption];
						if (headerFocusConstruction.EnterStop == true)
						{
							this._controlIndexForwordDictionary.Add(control.Name, controlIndexForword++);
							this._controlIndexBackDictionary.Add(control.Name, controlIndexBack--);
						}
					}
					else
					{
						tempHeaderFocusConstructionList.Add(headerFocusConstruction);
					}
				}

				List<HeaderFocusConstruction> cloneHeaderFocusConstructionList = new List<HeaderFocusConstruction>();
				cloneHeaderFocusConstructionList.AddRange(headerFocusConstructionList.headerFocusConstruction);
				if (tempHeaderFocusConstructionList.Count != 0)
				{
					foreach (HeaderFocusConstruction tempHeaderFocusConstruction in tempHeaderFocusConstructionList)
					{
						foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
						{
							if (( tempHeaderFocusConstruction.Key == headerFocusConstruction.Key ) &&
								( tempHeaderFocusConstruction.Caption == headerFocusConstruction.Caption ))
							{
								cloneHeaderFocusConstructionList.Remove(tempHeaderFocusConstruction);
								break;
							}
						}
					}
				}
				this._stockInputConstructionAcs.HeaderFocusConstructionListValue.headerFocusConstruction = cloneHeaderFocusConstructionList;
			}
		}


        /// <summary>
        /// 操作権限の制御を開始します。
        /// </summary>
        private void BeginControllingByOperationAuthority()
        {
            // 伝票修正ボタン
            if (MyOpeCtrl.Disabled((int)OperationCode.Revision))
            {
                this._readSlipButton.SharedProps.Visible=false;
                this._readSlipButton.SharedProps.Shortcut = Shortcut.None;
            }

            // 伝票削除ボタン
            if (MyOpeCtrl.Disabled((int)OperationCode.Delete))
            {
                this._deleteSlipButton.SharedProps.Visible = false;
                this._deleteSlipButton.SharedProps.Shortcut = Shortcut.None;
            }

            // 伝票削除ボタン
            if (MyOpeCtrl.Disabled((int)OperationCode.RedSlip))
            {
                this._redSlipButton.SharedProps.Visible = false;
                this._redSlipButton.SharedProps.Shortcut = Shortcut.None;
            }
        }

		#endregion

		#endregion

		// ===================================================================================== //
		// 各コントロールイベント処理
		// ===================================================================================== //
		# region ■Control Event Methods
		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2011/07/25 譚洪 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応</br>
		private void MAKON01110UA_Load(object sender, EventArgs e)
		{
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "開始");

#if false
			try
			{
				StockSlipInputInitDataAcs.LogWrite("OLEScannerController.Open");

				string msg = string.Empty;
				int status = this._OLEScannerController.LoadOleControl(ref msg);
				if (status == 0)
				{
					// オープン実行
					status = this._OLEScannerController.Open(ref msg);

					if (status == 0)
					{
						this._OLEScannerController.ClaimDevice(0, ref msg);
						this._OLEScannerController.DeviceEnabled = true;
						this._OLEScannerController.DataEventEnabled = true;
						this._OLEScannerController.DecodeData = true;
					}
				}
				else
				{
				}

				StockSlipInputInitDataAcs.LogWrite("OLEScannerController.Open 終了");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
#endif
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "Skinの設定");
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);
			this._controlScreenSkin.SettingScreenSkin(this._stockSlipDetailInput);
			//this._controlScreenSkin.SettingScreenSkin(this._salesTempInput);

            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "明細コントロールのロード"); 
            this.panel_Detail.Controls.Add(this._stockSlipDetailInput);
			this._stockSlipDetailInput.Dock = DockStyle.Fill;

			//this.panel2.Controls.Add(this._salesTempInput);
			//this._salesTempInput.Dock = DockStyle.Fill;

            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "LoadToolManagerCustomizeInfo");
            ToolbarManagerCustomizeSettingAcs.LoadToolManagerCustomizeInfo(ctAssemblyName, ref this.tToolbarsManager_MainMenu);

            // 初期データ取得が終了するで待つ
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "InitialReadThread 待ち");

            while (this._readInitialThread.ThreadState == ThreadState.Running)
            {
                Thread.Sleep(100);
            }
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "InitialReadThread 終了");

#if false
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "InitialReadThread2 待ち");
            while (this._readInitialThread2.ThreadState == ThreadState.Running)
            {
                Thread.Sleep(100);
            }
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "InitialReadThread2 終了");
#endif

            //if (!string.IsNullOrEmpty(_readInitialThreadErrMsg))
            //{
            //    throw new Exception(_readInitialThreadErrMsg);
            //    //MessageBox.Show(_readInitialThreadErrMsg);
            //    ////this.Close();
            //    //// アプリケーション終了
            //    //System.Windows.Forms.Application.Exit();
            //    return;
            //}

            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "ボタン初期設定処理");
            // ボタン初期設定処理
            this.ButtonInitialSetting();

            if (this._stockSlipInputInitDataAcs.GetCompanyInf().SecMngDiv == 0)
            {
                if (this._headerItemsDictionary.ContainsKey(this.uLabel_SubSectionTitle.Text.Trim()))
                {
                    this._headerItemsDictionary.Remove(this.uLabel_SubSectionTitle.Text.Trim());
                }
            }

            this._stockSlipDetailInput.SettingColDisplayStatusByCommonSetting();

            // ツールバー初期設定処理
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "ツールバー初期設定処理");
            this.ToolBarInitilSetting();
            this.SettingToolBarButtonCaption();

            // フォーカス移動設定処理
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "フォーカス移動設定処理");
            this.SettingFocusDictionary();

            // コンボエディタアイテム初期設定処理
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "コンボエディタアイテム初期設定処理");
            this.ComboEditorItemInitialSetting();

            // 明細グリッドクリア
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "明細グリッドクリア");
            this._stockSlipDetailInput.Clear();

            // 画面項目名称設定処理
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "画面項目名称設定処理");
            this.DisplayNameSetting();

            // セキュリティ権限による制御開始(ツールバーボタン)
            this.BeginControllingByOperationAuthority();


            this._stockSlipInputAcs.SetUnitPriceCalculation();  // ADD 2011/07/25

            // クリア処理
            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "クリア処理");
            bool canClear = this.Clear(false, false);

            if (canClear)
            {
                this.timer_InitialSetFocus.Enabled = true;
            }
            else
            {
                this.timer_Close.Enabled = true;
            }

            this._stockSlipInputInitDataAcs.CacheEventCall();

            // フッター選択タブ変更デリゲードの挿入（画面起動時に発生させない為このタイミング）
            this.TabChanged += new TabChangeEventHandler(this.FooterTabChanged);
            //this.TabChanged += new TabChangeEventHandler(this._salesTempInput.TabChanged);

            //this.uTabControl_Footer.Tabs["SalesInfo"].Visible = false;

            this._stockSlipDetailInput.SettingFooterEventCall();

            this._stockSlipInputInitDataAcs.Owner = this;

            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "終了");

        }

		/// <summary>
		/// フォーム表示後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void MAKON01110UA_Shown(object sender, EventArgs e)
		{
			//this.timer_InitialSetSlider.Enabled = true;
		}

		/// <summary>
		/// フォームクロージングイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void MAKON01110UA_FormClosing(object sender, FormClosingEventArgs e)
		{
            try
            {
                this._stockSlipDetailInput.Closing();
                try
                {
                    this._superSlider.ClosePanel();
                }
                catch (Exception)
                {
                    //
                }
            }
            catch (NullReferenceException)
            {
            }

			string msg = "";
            //this._OLEScannerController.DeviceEnabled = false;
            //this._OLEScannerController.ReleaseDevice(ref msg);
            //this._OLEScannerController.Close(ref msg);
			ToolbarManagerCustomizeSettingAcs.SaveToolManagerCustomizeInfo(ctAssemblyName, this.tToolbarsManager_MainMenu);
		}

		/// <summary>
		/// フォーカスコントロールイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Update Note : 2011/12/19 tianjw</br>
        /// <br>              Redmine#27390 拠点管理/売上日のチェック</br>
        /// <br>Update Note : 2011/12/27 陳建明</br>
        /// <br>管理番号    : 10707327-00 2012/01/25配信分</br>
        /// <br>              redmine#27374 仕入伝票入力/締済のチェックの対応</br>
        /// <br>Update Note : 2012/03/13 鄧潘ハン</br>
        /// <br>管理番号    : 10707327-00 2012/03/28配信分</br>
        /// <br>              Redmine#27374 仕入伝票入力でガイドから呼出した場合削除でエラーになる件の対応</br>
        /// <br>Update Note : 2012/10/15 田建委</br>
        /// <br>管理番号    : 10801804-00、2012/11/14配信分</br>
        /// <br>              Redmine#32862 価格変更した明細、色を変えるように修正</br>
        /// <br>Update Note : 2013/01/08 鄭慕鈞</br>
        /// <br>管理番号    : 10801804-00 2013/03/13配信分</br>
        /// <br>            : redmine#31984 仕入伝票入力の操作便利の対応</br>
        /// <br>Update Note : 2015/03/25 黄興貴</br>
        /// <br>管理番号    : 11175104-00</br>
        /// <br>            : Redmine#45073 宮田自動車商会
        /// <br>            : 仕入伝票入力で仕入伝票番号が空白のデータが作成されるの不具合の対応</br>
        /// <br>Update Note : 2015/04/01 黄興貴</br>
        /// <br>管理番号    : 11175104-00</br>
        /// <br>            : Redmine#45073 宮田自動車商会 障害No.179</br>
        /// <br>            : 仕入伝票番号の登録前チェックでNGになった際、入力したスペースが削除されないの不具合の対応</br>
        /// <br>Update Note: 2015/04/08 30757 佐々木貴英</br>
        /// <br>管理番号   : 11175104-00</br>
        /// <br>           : 仕掛№2678仕入伝票入力-仕入伝票番号空白入力時処理対応(Redmine#45073)</br>
        /// <br>           : 2015/3/25→2015/04/01の改修にて、修正の差し戻しを修正→再修正で行っていた箇所の差し戻し</br>
        /// <br>Update Note : 2015/04/16 黄興貴</br>
        /// <br>管理番号    : 11100008-00</br>
        /// <br>            : Redmine#45230 宮田自動車商会 
        /// <br>            : 仕入伝票入力で仕入伝票番号が欠けるの不具合の対応</br>
        /// <br>Update Note : 2020/02/24 田建委</br>
        /// <br>管理番号    : 11570208-00</br>
        /// <br>            : PMKOBETSU-2912消費税税率機能追加対応</br>
        /// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null) return;
			this._prevControl = e.NextCtrl;

			StockSlip stockSlipCurrent = this._stockSlipInputAcs.StockSlip.Clone();
			if (stockSlipCurrent == null) return;

			StockSlip stockSlip = stockSlipCurrent.Clone();
			bool reCalcStockPrice = false;
			bool changeStockGoodsCd = false;
			bool changeSupplierFormal = false;
			bool changeSupplierSlipCd = false;
			bool adjustStockUnitPrice = false;
			bool reCalcStockUnitPrice = false;
			bool taxRateChanged = false;
			bool getNextCtrl = false;	// Tab,Enterでのフォーカス移動項目自動取得有無の判定フラグ
            bool getNextCtrlForFooter = false; // 2009.04.02
            bool settingFotter = true;
			bool clearTaxAdjust = true;
            bool clearRateInfo = false;
			Control nextCtrl = null;
			Control prevCtrl = e.PrevCtrl;

			#region 売上入力画面
			//// 売上情報タブにフォーカスがある場合は売上情報画面のメソッドで制御
			//if (( this._salesTempInput.Contains(e.PrevCtrl) ) || ( e.PrevCtrl == this._salesTempInput ))
			//{
			//    this._salesTempInput.SalesInfo_ChangeFocus(ref e);

			//    this._stockSlipDetailInput.DisplaySalesInfo();

			//    settingFotter = false;
			//}
			#endregion
            // ---------------- ADD 2011/07/18 --------------- >>>>>
            if ((e.PrevCtrl != null) && (e.PrevCtrl.Name == "MAKON01110UB") && (e.NextCtrl != null) && (e.NextCtrl.Name != "uGrid_Details"))
            {
                this._stockSlipDetailInput.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                this._stockSlipInputAcs.StockDetailStockInfoAdjust();
            }
            // ---------------- ADD 2011/07/18 --------------- <<<<<
            #region 明細グリッド
			if (this._stockSlipDetailInput.Contains(e.PrevCtrl))
			{
				switch (e.PrevCtrl.Name)
				{
					#region 明細グリッド
					//---------------------------------------------------------------
					// 明細グリッド
					//---------------------------------------------------------------
					case "uGrid_Details":
						{
#if false
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (this._stockSlipDetailInput.uGrid_Details.ActiveCell != null)
                                            {
                                                if (this._stockSlipDetailInput.ReturnKeyDown())
                                                {
                                                    if (this.tNedit_SupplierCd.Focused)
                                                    {
                                                        e.NextCtrl = this.tNedit_SupplierCd;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = null;
                                                    }
                                                }
                                                else
                                                {
                                                    if (uTabControl_Footer.ActiveTab != uTabControl_Footer.Tabs[uTab_StockInfo.Tab.Key])
                                                    {
                                                        uTabControl_Footer.SelectedTab = uTabControl_Footer.Tabs[uTab_StockInfo.Tab.Key];
                                                    }
                                                    e.NextCtrl = this.tEdit_SupplierSlipNote1;
                                                }
                                            }

                                            stockSlipCurrent = this._stockSlipInputAcs.StockSlip;
                                            stockSlip = stockSlipCurrent.Clone();

                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            if (this._stockSlipDetailInput.uGrid_Details.ActiveCell != null)
                                            {
                                                this._stockSlipDetailInput.GetPrevMovePosition();
                                                e.NextCtrl = null;
                                                //if (this._stockSlipDetailInput.GetPrevMovePosition())
                                                //{
                                                //    e.NextCtrl = null;
                                                //    //if (this.tNedit_SupplierCd.Focused)
                                                //    //{
                                                //    //    e.NextCtrl = this.tNedit_SupplierCd;
                                                //    //}
                                                //    //else
                                                //    //{
                                                //    //    e.NextCtrl = null;
                                                //    //}
                                                //}
                                                //else
                                                //{
                                                //    //if (uTabControl_Footer.ActiveTab != uTabControl_Footer.Tabs[uTab_StockInfo.Tab.Key])
                                                //    //{
                                                //    //    uTabControl_Footer.SelectedTab = uTabControl_Footer.Tabs[uTab_StockInfo.Tab.Key];
                                                //    //}
                                                //    //e.NextCtrl = this.tEdit_SupplierSlipNote1;
                                                //}
                                            }
                                            //stockSlipCurrent = this._stockSlipInputAcs.StockSlip;
                                            //stockSlip = stockSlipCurrent.Clone();

                                            break;
                                        }
                                }
                            }
#endif
                            switch (e.Key)
                                {
                                    case Keys.Return:
                                    //case Keys.Tab:
                                        {
                                            if (this._stockSlipDetailInput.uGrid_Details.ActiveCell != null)
                                            {
                                                if (this._stockSlipDetailInput.ReturnKeyDown())
                                                {
                                                    if (this.tNedit_SupplierCd.Focused)
                                                    {
                                                        e.NextCtrl = this.tNedit_SupplierCd;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = null;
                                                    }
                                                }
                                                else
                                                {
                                                    if (uTabControl_Footer.ActiveTab != uTabControl_Footer.Tabs[uTab_StockInfo.Tab.Key])
                                                    {
                                                        uTabControl_Footer.SelectedTab = uTabControl_Footer.Tabs[uTab_StockInfo.Tab.Key];
                                                    }
                                                    //e.NextCtrl = this.tEdit_SupplierSlipNote1;  // DEL 2011/11/30 gezh redmine#8383
                                                    e.NextCtrl = this.tNedit_SupplierSlipNote1;   // ADD 2011/11/30 gezh redmine#8383
                                                }
                                            }
                                            // -------------- ADD 2011/07/18 --------------- >>>>>
                                            if ((e.PrevCtrl != null) && (e.PrevCtrl.Name == "uGrid_Details") && (e.NextCtrl != null) && (e.NextCtrl.Name != "uGrid_Details"))
                                            {
                                                this._stockSlipDetailInput.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                                                this._stockSlipInputAcs.StockDetailStockInfoAdjust();
                                            }
                                            // -------------- ADD 2011/07/18 --------------- <<<<<
                                            stockSlipCurrent = this._stockSlipInputAcs.StockSlip;
                                            stockSlip = stockSlipCurrent.Clone();

                                            break;
                                        }
                                    // ADD 2011/11/30 gezh redmine#8383 ------------------------>>>>>
                                    case Keys.Tab:
                                        {
                                            if (this._stockSlipDetailInput.uGrid_Details.ActiveCell != null)
                                            {
                                                e.NextCtrl = this.tNedit_SupplierSlipNote1;

                                            }
                                            break;
                                        }
                                    // ADD 2011/11/30 gezh redmine#8383 ------------------------<<<<<
                                }

							getNextCtrl = false;
							break;
						}
					#endregion
				}
			}
			#endregion

			else
			{

				switch (e.PrevCtrl.Name)
				{

					#region ●拠点コード
					//---------------------------------------------------------------
					// 拠点コード
					//---------------------------------------------------------------
					case "tEdit_SectionCode":
						{
							getNextCtrl = true;

							bool canChangeFocus = true;

							string code = this.tEdit_SectionCode.Text.Trim();

							if (stockSlipCurrent.StockSectionCd.Trim() != code)
							{
                                if (string.IsNullOrEmpty(code))
                                {
                                    stockSlip.StockSectionCd = code;
                                    stockSlip.StockSectionNm = "";
                                }
                                else
                                {
                                    SecInfoSet secInfoSet = this._stockSlipInputInitDataAcs.GetSecInfo(code);

                                    if (secInfoSet == null)
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "拠点が存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);

                                        canChangeFocus = false;
                                    }
                                    else
                                    {
                                        if (this._stockSlipInputAcs.ExistStockDetailCanGoodsPriceReSettingData())
                                        {
                                            DialogResult dialogResult = TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                this.Name,
                                                "拠点が変更されました。" + "\r\n" + "\r\n" +
                                                "商品価格を再取得しますか？",
                                                0,
                                                MessageBoxButtons.YesNo,
                                                MessageBoxDefaultButton.Button1);

                                            if (dialogResult == DialogResult.Yes)
                                            {
                                                reCalcStockUnitPrice = true;
                                            }
                                            else
                                            {
                                                clearRateInfo = true;
                                            }
                                        }
                                        stockSlip.StockSectionCd = code;
                                        stockSlip.StockSectionNm = secInfoSet.SectionGuideNm;
                                    }
                                }

								// 仕入データクラス→画面格納処理
								this.SetDisplay(stockSlip);
							}

							// NextCtrl制御
							if (canChangeFocus)
							{
                                if (!e.ShiftKey)
                                {

                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:
                                            if (string.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
                                            {
                                                nextCtrl = this.uButton_SectionGuide;
                                                getNextCtrl = false;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
							}
							else
							{
								e.NextCtrl = e.PrevCtrl;
								getNextCtrl = false;
							}

							break;
						}
					#endregion

					#region ●拠点ガイドボタン
					//---------------------------------------------------------------
					// 拠点ガイドボタン
					//---------------------------------------------------------------
					case "uButton_SectionGuide":
						{
							getNextCtrl = true;

							if (e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										nextCtrl = this.tEdit_SectionCode;
										getNextCtrl = false;
										break;
									default:
										break;
								}
							}
							else
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										prevCtrl = this.tEdit_SectionCode;
										break;
									default:
										break;
								}
							}

							break;

						}
					#endregion

					#region ●部門コード
					//---------------------------------------------------------------
					// 部門コード
					//---------------------------------------------------------------
					case "tNedit_SubSectionCode":
						{
							getNextCtrl = true;

							bool canChangeFocus = true;
							int code = this.tNedit_SubSectionCode.GetInt();

							if (stockSlipCurrent.SubSectionCode != code)
							{
								if (code == 0)
								{
									stockSlip.SubSectionCode = code;
									stockSlip.SubSectionName = "";
								}
								else
								{
									string name = this._stockSlipInputInitDataAcs.GetName_FromSubSection(code);

									if (string.IsNullOrEmpty(name))
									{
										TMsgDisp.Show(
											this,
											emErrorLevel.ERR_LEVEL_INFO,
											this.Name,
											"部門が存在しません。",
											-1,
											MessageBoxButtons.OK);

										canChangeFocus = false;
									}
									else
									{
										stockSlip.SubSectionCode = code;
										stockSlip.SubSectionName = name;
									}
								}

								// 仕入データクラス→画面格納処理
								this.SetDisplay(stockSlip);
							}

							// NextCtrl制御
							if (canChangeFocus)
							{
								if (!e.ShiftKey)
								{

									switch (e.Key)
									{
										case Keys.Return:
										case Keys.Tab:
											if (this.tNedit_SubSectionCode.GetInt() == 0)
											{
												nextCtrl = this.uButton_SubSectionGuide;
												getNextCtrl = false;
											}
											break;
										default:
											break;
									}
								}
							}
							else
							{
								e.NextCtrl = e.PrevCtrl;
								getNextCtrl = false;
							}

							break;
						}
					#endregion

					#region ●部門ガイドボタン
					//---------------------------------------------------------------
					// 部門ガイドボタン
					//---------------------------------------------------------------
					case "uButton_SubSectionGuide":
						{
							getNextCtrl = true;

							if (e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										nextCtrl = this.tNedit_SubSectionCode;
										getNextCtrl = false;
										break;
									default:
										break;
								}
							}
							else
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										prevCtrl = this.tNedit_SubSectionCode;
										break;
									default:
										break;
								}
							}

							break;

						}
					#endregion
					
					#region ●仕入SEQ番号
					//---------------------------------------------------------------
                    // 仕入SEQ番号
					//---------------------------------------------------------------
					case "tNedit_SupplierSlipNo":
						{
							//getNextCtrl = true;

							bool read = false;
							int code = this.tNedit_SupplierSlipNo.GetInt();

							if (stockSlipCurrent.SupplierSlipNo != code)
							{
								DialogResult dialogResult = DialogResult.Yes;

								if (this._stockSlipInputAcs.IsDataChanged)
								{
									dialogResult = TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_EXCLAMATION,
										this.Name,
										"入力中の" + this._stockSlipInputAcs.GetSupplierFormalName(this._stockSlipInputAcs.StockSlip) + "情報がクリアされます。" + "\r\n" + "\r\n" +
										"よろしいですか？",
										0,
										MessageBoxButtons.YesNo,
										MessageBoxDefaultButton.Button1);
								}

								if (dialogResult == DialogResult.Yes)
								{
                                    StockSlip baseStockSlip = new StockSlip(); // 2009.03.25

									// 画面初期化処理
									this.Clear(false, true);

									// 仕入伝票番号を再設定
									this.tNedit_SupplierSlipNo.SetInt(code);

									// データリード処理
									this.Cursor = Cursors.WaitCursor;

									int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

									try
									{
										// 画面仕入形式を元に、データが存在しない場合は入荷データも読み込む
                                        int supplierFormal = this._stockSlipInputAcs.StockSlip.SupplierFormal;

                                        if (supplierFormal == 0)
                                        {
                                            for (int supplierFormalWk = supplierFormal; supplierFormalWk < 2; supplierFormalWk++)
                                            {
                                                //status = this._stockSlipInputAcs.ReadDBData(this._enterpriseCode, supplierFormalWk, code); // 2009.03.25
                                                status = this._stockSlipInputAcs.ReadDBData(this._enterpriseCode, supplierFormalWk, code, out baseStockSlip); // 2009.03.25
                                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;
                                            }
                                        }
                                        else
                                        {
                                            for (int supplierFormalWk = supplierFormal; supplierFormalWk >= 0; supplierFormalWk--)
                                            {
                                                //status = this._stockSlipInputAcs.ReadDBData(this._enterpriseCode, supplierFormalWk, code); // 2009.03.25
                                                status = this._stockSlipInputAcs.ReadDBData(this._enterpriseCode, supplierFormalWk, code, out baseStockSlip); // 2009.03.25
                                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;
                                            }

                                        }
									}
									finally
									{
										this.Cursor = Cursors.Default;
									}

									if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
									{
										stockSlipCurrent = this._stockSlipInputAcs.StockSlip;
										stockSlip = stockSlipCurrent.Clone();
                                        // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
                                        ShowMessage(stockSlip, stockSlip.SupplierConsTaxRate);
                                        slipSrcTaxFlg = false;
                                        // 税率取得の対象は、仕入形式によって変更(仕入：仕入日、入荷：入荷日）
                                        DateTime targetdate = (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay;
                                        taxRateSetMaster = this._stockSlipInputInitDataAcs.GetTaxRate(targetdate);
                                        if (stockSlip.SupplierConsTaxRate != taxRateSetMaster)
                                        {
                                            // 伝票呼出軽減税率フラグ
                                            slipSrcTaxFlg = true;

                                        }
                                        // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<
                                        stockSlip.PreStockDate = stockSlip.StockDate; // ADD 2011/12/19
                                        //DEL 2012/03/13 鄧潘ハン Redmine #27374----->>>>>
                                        //add 2011/12/27 陳建明 Redmine #27374----->>>>>
                                        //_deleteStockSlip = _stockSlipInputAcs.StockSlip;
                                        //_deleteStockDetailList = _stockSlipInputAcs.StockDetailList;
                                        //_deleteAddUpSrcDetailList = _stockSlipInputAcs.AddUpSrcDetailList;
                                        //_deletePaymentSlp = _stockSlipInputAcs.PaymentSlp;
                                        //_deletePaymentDtlList = _stockSlipInputAcs.PaymentDtlList;
                                        //_deleteStockWorkList = _stockSlipInputAcs.StockWorkList;
                                        //add 2011/12/27 陳建明 Redmine #27374-----<<<<<
                                        //DEL 2012/03/13 鄧潘ハン Redmine #27374-----<<<<<

                                        //ADD 2012/03/13 鄧潘ハン Redmine #27374----->>>>>
                                        this._stockSlipInputAcs.DeleteStockSlip = _stockSlipInputAcs.StockSlip;
                                        this._stockSlipInputAcs.DeleteStockDetailList = _stockSlipInputAcs.StockDetailList;
                                        this._stockSlipInputAcs.DeleteAddUpSrcDetailList = _stockSlipInputAcs.AddUpSrcDetailList;
                                        this._stockSlipInputAcs.DeletePaymentSlp = _stockSlipInputAcs.PaymentSlp;
                                        this._stockSlipInputAcs.DeletePaymentDtlList = _stockSlipInputAcs.PaymentDtlList;
                                        this._stockSlipInputAcs.DeleteStockWorkList = _stockSlipInputAcs.StockWorkList;
                                        //ADD 2012/03/13 鄧潘ハン Redmine #27374-----<<<<<

										// 仕入データ入力モード設定処理
										this.SettingStockSlipInputMode(ref stockSlip);
                                        //add 2011/12/27 陳建明 Redmine #27374----->>>>>
									    //if(_isCannotModify)//DEL 2012/03/13 鄧潘ハン Redmine #27374
                                        if (this._stockSlipInputAcs.IsCannotModify)//ADD 2012/03/13 鄧潘ハン Redmine #27374
                                           uButton_PaymentConfirmation.Focus();
                                       //add 2011/12/27 陳建明 Redmine #27374-----<<<<<

										// 表示用伝票区分の設定
										StockSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref stockSlip);

                                        // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                        if (baseStockSlip.SuppCTaxLayCd != stockSlip.SuppCTaxLayCd) reCalcStockPrice = true;
                                        // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

										read = true;
									}
									else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
									{
										TMsgDisp.Show(
											this,
											emErrorLevel.ERR_LEVEL_INFO,
											this.Name,
											"該当するデータが存在しません。",
											-1,
											MessageBoxButtons.OK);

										e.NextCtrl = e.PrevCtrl;
									}
									else
									{
										TMsgDisp.Show(
											this,
											emErrorLevel.ERR_LEVEL_STOPDISP,
											this.Name,
											"仕入・入荷データの取得に失敗しました。",
											status,
											MessageBoxButtons.OK);

										e.NextCtrl = e.PrevCtrl;
									}
								}

								// 仕入データキャッシュ処理
								this._stockSlipInputAcs.Cache(stockSlip);

								// 入荷計上伝票、赤伝の場合は空白行を削除する
								if (( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ArrivalAddUp ) || ( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red ))
								{
									this._stockSlipDetailInput.DeleteEmptyRow(true);
								}

								// 仕入データクラス→画面格納処理
								this.SetDisplay(stockSlip);

								stockSlipCurrent = stockSlip.Clone();

								// 明細グリッド設定処理
								this._stockSlipDetailInput.SettingGrid();

                                DisplayNameSetting2(stockSlip);// ADD 田建委 2020/02/24 PMKOBETSU-2912の対応

								if (read)
								{
									//if (( this._stockSlipDetailInput.Enabled ) && ( stockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_Red ))
                                    if (( this._stockSlipDetailInput.Enabled ) &&
                                        ( stockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_Red ) &&
                                        ( stockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ) &&
                                        ( stockSlip.InputMode != StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ))
                                    {
                                        nextCtrl = this._stockSlipDetailInput;
                                    }
                                    else
                                    {
                                        //nextCtrl = this.tEdit_SupplierSlipNote1;  //DEL 2011/11/30 gezh redmine#8383
                                        nextCtrl = this.tNedit_SupplierSlipNote1;   //ADD 2011/11/30 gezh redmine#8383
                                    }
								}
							}

							//getNextCtrl = false;

							break;
						}
					#endregion

					#region ●担当者コード
					//---------------------------------------------------------------
					// 担当者コード
					//---------------------------------------------------------------
					case "tEdit_StockAgentCode":
						{
							getNextCtrl = true;

							bool canChangeFocus = true;
							string code = this.tEdit_StockAgentCode.Text.Trim();

							if (stockSlipCurrent.StockAgentCode.Trim() != code)
							{
								if (string.IsNullOrEmpty(code))
								{
									stockSlip.StockAgentCode = code;
                                    stockSlip.StockAgentName = string.Empty;
									stockSlip.SubSectionCode = 0;
                                    stockSlip.SubSectionName = string.Empty;
								}
								else
								{
									string name = this._stockSlipInputInitDataAcs.GetName_FromEmployee(code);

                                    if (string.IsNullOrEmpty(name.Trim()))
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "担当者が存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);
                                        canChangeFocus = false;
                                    }
                                    else
                                    {
                                        stockSlip.StockAgentCode = code;
                                        stockSlip.StockAgentName = name;
                                        if (stockSlip.StockAgentName.Length > 16)
                                        {
                                            stockSlip.StockAgentName = stockSlip.StockAgentName.Substring(0, 16);
                                        }
                                        this._stockSlipInputAcs.StockAgentBelongInfoSetting(ref stockSlip);
                                    }
								}

								// 仕入データクラス→画面格納処理
								this.SetDisplay(stockSlip);
							}

							// NextCtrl制御
							if (canChangeFocus)
							{
								if (!e.ShiftKey)
								{
									switch (e.Key)
									{
										case Keys.Return:
										case Keys.Tab:
											if (string.IsNullOrEmpty(this.tEdit_StockAgentCode.Text.Trim()))
											{
												nextCtrl = this.uButton_EmployeeGuide;
												getNextCtrl = false;
											}
											break;
										default:
											break;
									}
								}
							}
							else
							{
								e.NextCtrl = e.PrevCtrl;
								getNextCtrl = false;
							}

							break;
						}
					#endregion

					#region ●担当者ガイドボタン
					//---------------------------------------------------------------
					// 担当者ガイドボタン
					//---------------------------------------------------------------
					case "uButton_EmployeeGuide":
						{
							getNextCtrl = true;

							if (e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										nextCtrl = this.tEdit_StockAgentCode;
										getNextCtrl = false;
										break;
									default:
										break;
								}
							}
							else
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										prevCtrl = this.tEdit_StockAgentCode;
										break;
									default:
										break;
								}
							}

							break;

						}
					#endregion

					#region ●仕入先コード
					//---------------------------------------------------------------
					// 仕入先コード
					//---------------------------------------------------------------
					case "tNedit_SupplierCd":
						{
							getNextCtrl = true;

							bool canChangeFocus = true;
							int code = this.tNedit_SupplierCd.GetInt();

							if (stockSlipCurrent.SupplierCd != code)
							{
								if (code == 0)
								{
									if (this._stockSlipInputAcs.ExistStockDetailData())
									{
										TMsgDisp.Show(
											this,
											emErrorLevel.ERR_LEVEL_INFO,
											this.Name,
											this._stockSlipInputAcs.GetSupplierFormalName(this._stockSlipInputAcs.StockSlip) + "明細情報が入力されているため、仕入先のクリアは行えません。",
											-1,
											MessageBoxButtons.OK);

										canChangeFocus = false;
									}
									else
									{
										try
										{
											// 得意先（仕入先）情報設定処理
											this._stockSlipInputAcs.DataSettingStockSlip(ref stockSlip, null);

											// 仕入明細データセッティング処理（課税区分設定）
                                            this._stockSlipInputAcs.StockDetailRowTaxationCodeSetting(stockSlip.SuppCTaxLayCd, stockSlip.SuppTtlAmntDspWayCd);

											reCalcStockPrice = true;
										}
										catch (Exception ex)
										{
											TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_INFO,
												this.Name,
												ex.Message,
												-1,
												MessageBoxButtons.OK);

											canChangeFocus = false;
										}
									}
								}
								else
								{
									Supplier supplier;
									this.Cursor = Cursors.WaitCursor;
                                    if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
									int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, code);
									this.Cursor = Cursors.Default;


									if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
									{
										reCalcStockPrice = true;

										// 得意先（仕入先）情報設定処理
										this._stockSlipInputAcs.DataSettingStockSlip(ref stockSlip, supplier);

                                        // 転嫁方式が変わった場合は課税区分設定(値引きが変わる為）
                                        if (stockSlipCurrent.SuppCTaxLayCd != stockSlip.SuppCTaxLayCd)
                                        {
                                            // 仕入明細データセッティング処理（課税区分設定）
                                            this._stockSlipInputAcs.StockDetailRowTaxationCodeSetting(stockSlip.SuppCTaxLayCd, stockSlip.SuppTtlAmntDspWayCd);

                                            // 転嫁方式：非課税を経由した場合は税率によって各種金額再計算
                                            if (( stockSlipCurrent.SuppCTaxLayCd == 9 ) ||
                                                ( stockSlip.SuppCTaxLayCd == 9 ))
                                            {
                                                taxRateChanged = true;
                                            }
                                        }

										if (this._stockSlipInputAcs.ExistStockDetailCanGoodsPriceReSettingData())
										{
											string msg = "仕入先が変更されました。" + "\r\n" + "\r\n" + "商品価格を再取得しますか？";

											DialogResult dialogResult = TMsgDisp.Show(
												this,
												emErrorLevel.ERR_LEVEL_EXCLAMATION,
												this.Name,
												msg,
												0,
												MessageBoxButtons.YesNo,
												MessageBoxDefaultButton.Button1);

                                            if (dialogResult == DialogResult.Yes)
                                            {
                                                reCalcStockUnitPrice = true;
                                            }
                                            else 
                                            {
                                                clearRateInfo = true;
                                            }
											this.SupplierChangedCall(reCalcStockUnitPrice);
										}

                                        // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
                                        // 伝票転嫁の時
                                        // 税率取得の対象は、仕入形式によって変更(仕入：仕入日、入荷：入荷日）
                                        DateTime targetdate = (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay;
                                        StockPriceConsTaxTotalTitleSetC(ref stockSlip, targetdate);
                                        // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<
									}
									else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
									{
										TMsgDisp.Show(
											this,
											emErrorLevel.ERR_LEVEL_INFO,
											this.Name,
											"仕入先が存在しません。",
											-1,
											MessageBoxButtons.OK);

										canChangeFocus = false;
									}
									else
									{
										TMsgDisp.Show(
											this,
											emErrorLevel.ERR_LEVEL_STOPDISP,
											this.Name,
											"仕入先の取得に失敗しました。",
											status,
											MessageBoxButtons.OK);

										canChangeFocus = false;
									}
								}

								// 仕入データクラス→画面格納処理
								this.SetDisplay(stockSlip);
							}

							// NextCtrl制御
							if (canChangeFocus)
							{
								if (!e.ShiftKey)
								{
									switch (e.Key)
									{
										case Keys.Return:
										case Keys.Tab:

											bool customerSerach = false;

											if (this.tNedit_SupplierCd.GetInt() == 0)
											{
												this.uButton_SupplierGuide_Click(this.uButton_SupplierGuide, EventArgs.Empty);
												customerSerach = true;
											}

											if (this.tNedit_SupplierCd.GetInt() == 0)
											{
												nextCtrl = this.uButton_SupplierGuide;
												getNextCtrl = false;
											}
											else
											{
												if (customerSerach)
												{
													stockSlip = this._stockSlipInputAcs.StockSlip.Clone();
												}
											}

											break;
										default:
											break;
									}
								}
							}
							else
							{
								e.NextCtrl = e.PrevCtrl;
								getNextCtrl = false;
							}

							break;
						}
					#endregion

					#region ●仕入先ガイドボタン
					//---------------------------------------------------------------
					// 仕入先ガイドボタン
					//---------------------------------------------------------------
                    case "uButton_SupplierGuide":
						{
							getNextCtrl = true;

							if (e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										nextCtrl = this.tNedit_SupplierCd;
										getNextCtrl = false;
										break;
									default:
										break;
								}
							}
							else
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										prevCtrl = this.tNedit_SupplierCd;
										break;
									default:
										break;
								}
							}
							break;
						}
					#endregion

					#region ●倉庫コード
					//---------------------------------------------------------------
					// 倉庫コード
					//---------------------------------------------------------------
					case "tEdit_WarehouseCode":
						{
							getNextCtrl = true;

							bool canChangeFocus = true;
							string code = this.tEdit_WarehouseCode.Text.Trim();

							if (stockSlipCurrent.WarehouseCode != code)
							{
                                if (string.IsNullOrEmpty(code))
                                {
                                    stockSlip.WarehouseCode = code;
                                    stockSlip.WarehouseName = "";
                                }
                                else
                                {
                                    string name = this._stockSlipInputInitDataAcs.GetName_FromWarehouse(code);

                                    if (string.IsNullOrEmpty(name))
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "倉庫が存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);

                                        canChangeFocus = false;
                                        //stockSlip.WarehouseCode = stockSlipCurrent.WarehouseCode;
                                        //stockSlip.WarehouseName = stockSlipCurrent.WarehouseName;
                                    }
                                    else
                                    {
                                        stockSlip.WarehouseCode = code;
                                        stockSlip.WarehouseName = name;
                                    }
                                }

								// 仕入データクラス→画面格納処理
								this.SetDisplay(stockSlip);
							}

							// NextCtrl制御
							if (canChangeFocus)
							{
								if (!e.ShiftKey)
								{

									switch (e.Key)
									{
										case Keys.Return:
										case Keys.Tab:
											if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text.Trim()))
											{
												nextCtrl = this.uButton_WarehouseGuide;
												getNextCtrl = false;
											}
											break;
										default:
											break;
									}
								}
							}
							else
							{
								e.NextCtrl = e.PrevCtrl;
								getNextCtrl = false;
							}

							break;
						}
					#endregion

					#region ●倉庫ボタン
					//---------------------------------------------------------------
					// 倉庫ボタン
					//---------------------------------------------------------------
					case "uButton_WarehouseGuide":
						{
							getNextCtrl = true;

							if (e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										nextCtrl = tEdit_WarehouseCode;
										getNextCtrl = false;
										break;
									default:
										break;
								}
							}
							else
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										prevCtrl = this.tEdit_WarehouseCode;
										break;
									default:
										break;
								}
							}
							break;
						}
					#endregion

					#region ●支払先確認ボタン
					//---------------------------------------------------------------
					// 支払先確認ボタン
					//---------------------------------------------------------------
					case "uButton_PaymentConfirmation":
						{
							getNextCtrl = true;

							break;
						}
					#endregion

					#region ●定価・原価更新
					//---------------------------------------------------------------
					// 商品区分
					//---------------------------------------------------------------
					case "tComboEditor_PriceCostUpdtDiv":
						{
							getNextCtrl = true;

							// 商品区分コンボエディタ選択確定後発生イベントを一時的に解除
							this.tComboEditor_PriceCostUpdtDiv.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_PriceCostUpdtDiv_SelectionChangeCommitted);

							this.ChangePriceCostUpdtDiv(ref stockSlip, true);

							// 商品区分コンボエディタ選択確定後発生イベントを挿入
							this.tComboEditor_PriceCostUpdtDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_PriceCostUpdtDiv_SelectionChangeCommitted);

							break;

						}
					#endregion

					#region ●仕入形式

					//---------------------------------------------------------------
					// 仕入形式 
					//---------------------------------------------------------------
					case "tComboEditor_SupplierFormal":
						{
							getNextCtrl = true;

							// 仕入形式コンボエディタ選択値変更確定後イベントを一時的に解除
							this.tComboEditor_SupplierFormal.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_SupplierFormal_SelectionChangeCommitted);

							changeSupplierFormal = this.ChageSupplierFormal(ref stockSlip, false);

							// 仕入形式コンボエディタ選択値変更確定後イベントを挿入
							this.tComboEditor_SupplierFormal.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_SupplierFormal_SelectionChangeCommitted);

							break;
						}

					#endregion

					#region ●商品区分
					//---------------------------------------------------------------
					// 商品区分
					//---------------------------------------------------------------
					case "tComboEditor_StockGoodsCd":
						{
							getNextCtrl = true;

							// 商品区分コンボエディタ選択確定後発生イベントを一時的に解除
							this.tComboEditor_StockGoodsCd.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_StockGoodsCd_SelectionChangeCommitted);

							changeStockGoodsCd = this.ChangeStockGoodsCd(ref stockSlip, true);

							// 商品区分コンボエディタ選択確定後発生イベントを挿入
							this.tComboEditor_StockGoodsCd.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_StockGoodsCd_SelectionChangeCommitted);

							break;

						}
					#endregion

					#region ●伝票区分
					//---------------------------------------------------------------
					// 伝票区分
					//---------------------------------------------------------------
					case "tComboEditor_SupplierSlipCdDisplay":
						{
							getNextCtrl = true;

							// 伝票区分コンボエディタ選択確定後発生イベントを一時的に解除
							this.tComboEditor_SupplierSlipCdDisplay.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_SupplierSlipDisplay_SelectionChangeCommitted);

							changeSupplierSlipCd = this.ChageSupplierSlipDisplay(ref stockSlip, false);

							// 伝票区分コンボエディタ選択確定後発生イベントを挿入
							this.tComboEditor_SupplierSlipCdDisplay.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_SupplierSlipDisplay_SelectionChangeCommitted);

							break;
						}
					#endregion

					#region ●入荷日
					//---------------------------------------------------------------
					// 入荷日
					//---------------------------------------------------------------
					case "tDateEdit_ArrivalGoodsDay":
						{
							getNextCtrl = true;

							DateTime value = this.tDateEdit_ArrivalGoodsDay.GetDateTime();

							if (stockSlipCurrent.ArrivalGoodsDay != value)
							{
								stockSlip.ArrivalGoodsDay = value;

								if (stockSlip.SupplierFormal == 1)
								{
                                    if (this._stockSlipInputAcs.ExistStockDetailCanGoodsPriceReSettingData())
                                    {
                                        DialogResult dialogResult = TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                            this.Name,
                                            "入荷日が変更されました。" + "\r\n" + "\r\n" +
                                            "商品価格を再取得しますか？",
                                            0,
                                            MessageBoxButtons.YesNo,
                                            MessageBoxDefaultButton.Button1);

                                        if (dialogResult == DialogResult.Yes)
                                        {
                                            reCalcStockUnitPrice = true;
                                        }
                                    }

                                    // ADD 吉岡 2014/01/31 Redmine#41771 システムテスト障害№12 ------------>>>>>>>>>>>>>>>>>>>>>>>
                                    // 入荷伝票の場合
                                    if (stockSlip.SupplierFormal == 1)
                                    {
                                        // stockSlip.SupplierSlipCd が != 20:返品の場合、stockSlip.DebitNoteDiv が != 1:赤伝の場合、
                                        if (stockSlip.DebitNoteDiv != 1 &&
                                            (stockSlip.SupplierSlipCd != 20 || (stockSlip.SupplierSlipCd == 20 && this._stockSlipInputAcs.StockDetailDataTable[0].StockSlipDtlNumSrc == 0)))
                                        {
                                    // ADD 吉岡 2014/01/31 Redmine#41771 システムテスト障害№12 ------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                            // -----UPD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
                                            //double taxRate = this._stockSlipInputInitDataAcs.GetTaxRate(stockSlip.ArrivalGoodsDay);
                                            double taxRate = 0;
                                            StockPriceConsTaxTotalTitleSet(stockSlip, stockSlip.ArrivalGoodsDay, out taxRate);
                                            // -----UPD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<
                                            if (taxRate != stockSlip.SupplierConsTaxRate)
                                            {
                                                stockSlip.SupplierConsTaxRate = taxRate;
                                                // 税率が変わった場合、転嫁方式「非課税」以外は金額再計算
                                                if (stockSlip.SuppCTaxLayCd != 9)
                                                {
                                                    taxRateChanged = true;
                                                }
                                            }
                                    // ADD 吉岡 2014/01/31 Redmine#41771 システムテスト障害№12 ------------>>>>>>>>>>>>>>>>>>>>>>>
                                        }

                                        // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
                                        // 赤伝 or 返品の場合
                                        if (stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Return ||
                                            stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red)
                                        {
                                            DisplayNameSetting2(stockSlip);
                                        }
                                        // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<
                                    }
                                    // ADD 吉岡 2014/01/31 Redmine#41771 システムテスト障害№12 ------------>>>>>>>>>>>>>>>>>>>>>>>
								}
							}

							break;

						}
					#endregion

					#region ●仕入日
					//---------------------------------------------------------------
					// 仕入日
					//---------------------------------------------------------------
					case "tDateEdit_StockDate":
						{
							getNextCtrl = true;

                            bool isAddUpDateChanged = false;

							DateTime value = this.tDateEdit_StockDate.GetDateTime();


							if (stockSlipCurrent.StockDate != value)
							{
								stockSlip.StockDate = value;

								// 計上日、来勘区分の再セット
								this._stockSlipInputAcs.SettingAddUpDate(ref stockSlip);

                                // 2009.07.10 >>>
                                //isAddUpDateChanged = ( stockSlipCurrent.StockAddUpADate != stockSlip.StockAddUpADate );

                                // 計上日が変わって、さらに以下の条件の何れか該当する場合は変更メッセージ表示
                                // ①来月勘定無しで、計上日を変更していた場合
                                // ②来月勘定有り
                                isAddUpDateChanged = ( ( ( stockSlipCurrent.NTimeCalcStDate == 0 ) && 
                                                         ( !this._stockSlipInputAcs.CheckDefaultAddUpDate(stockSlipCurrent) ) || 
                                                       ( stockSlipCurrent.NTimeCalcStDate != 0 ) ) && 
                                                       ( stockSlipCurrent.StockAddUpADate != stockSlip.StockAddUpADate ) );
                                // 2009.07.10 <<<

								if (stockSlip.StockDate != DateTime.MinValue)
								{
                                    if (this._stockSlipInputAcs.ExistStockDetailCanGoodsPriceReSettingData())
                                    {
                                        DialogResult dialogResult = TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                            this.Name,
                                            string.Format("仕入日{0}が変更されました。", ( isAddUpDateChanged ) ? "、計上日" : string.Empty) + "\r\n" + "\r\n" +
                                            "商品価格を再取得しますか？",
                                            0,
                                            MessageBoxButtons.YesNo,
                                            MessageBoxDefaultButton.Button1);

                                        if (dialogResult == DialogResult.Yes)
                                        {
                                            reCalcStockUnitPrice = true;
                                        }
                                    }
                                    else
                                    {
                                        if (isAddUpDateChanged)
                                        {
                                            TMsgDisp.Show(
                                               this,
                                               emErrorLevel.ERR_LEVEL_INFO,
                                               this.Name,
                                               "計上日が変更されました。",
                                               0,
                                               MessageBoxButtons.OK,
                                               MessageBoxDefaultButton.Button1);
                                        }
                                    }

									// 仕入伝票の場合は税率再取得
									if (stockSlip.SupplierFormal == 0)
									{
                                        // stockSlip.SupplierSlipCd が != 20:返品の場合、stockSlip.DebitNoteDiv が != 1:赤伝の場合、
                                        if (stockSlip.DebitNoteDiv != 1 &&
                                            (stockSlip.SupplierSlipCd != 20 || (stockSlip.SupplierSlipCd == 20 && this._stockSlipInputAcs.StockDetailDataTable[0].StockSlipDtlNumSrc == 0))) // --- ADD 譚洪 2014/01/07
                                        {
                                            // -----UPD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
                                            //double taxRate = this._stockSlipInputInitDataAcs.GetTaxRate(stockSlip.StockDate);
                                            double taxRate = 0;
                                            StockPriceConsTaxTotalTitleSet(stockSlip, stockSlip.StockDate, out taxRate);
                                            // -----UPD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<

                                            if (taxRate != stockSlip.SupplierConsTaxRate)
                                            {
                                                stockSlip.SupplierConsTaxRate = taxRate;
                                                taxRateChanged = true;
                                            }
                                        }
                                        // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
                                        // 赤伝 or 返品の場合
                                        if (stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Return ||
                                            stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red)
                                        {
                                            DisplayNameSetting2(stockSlip);
                                        }
                                        // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<
									}

                                    // 2009.07.10 Add >>>
                                    // 仕入日変更時に入荷日に反映させるか判断
                                    switch (this._stockInputConstructionAcs.ReflectArrivalGoodsDayValue)
                                    {
                                        // する（無条件）
                                        case StockSlipInputConstructionAcs.ReflectArrivalGoodsDay_ON:
                                            stockSlip.ArrivalGoodsDay = stockSlip.StockDate;
                                            break;
                                        // する（計上時を除く）
                                        case StockSlipInputConstructionAcs.ReflectArrivalGoodsDay_ExcludeAppropriate:
                                            if (stockSlip.SupplierFormal == 0)
                                            {
                                                List<int> addUpNoList = this._stockSlipInputAcs.GetAddUpDetailRowNoList();
                                                if (addUpNoList == null || addUpNoList.Count == 0)
                                                {
                                                    stockSlip.ArrivalGoodsDay = stockSlip.StockDate;
                                                }
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    // 2009.07.10 Add <<<
                                }
							}

							break;
						}
					#endregion

					#region ●相手先伝番
					//---------------------------------------------------------------
					// 仕入先伝票番号
					//---------------------------------------------------------------
					case "tEdit_PartySaleSlipNum":
						{
                            getNextCtrl = true;

                            bool canChangeFocus = true;

							string value = this.tEdit_PartySaleSlipNum.Text;
                            // 2011/07/21 add wangf start
                            // 伝票番号未入力の場合、エラーメッセージを追加、次フォーカスは本項目
                            //if (string.Empty.Equals(value) // 2011/08/03 del wangf for readMine#233758月納品
                            if (string.Empty.Equals(value.Trim()) // 2011/08/03 add wangf for readMine#23375 8月納品
                                  && (e.NextCtrl.Name.Equals("uGrid_Details") || e.NextCtrl.Name.Equals("MAKON01110UB")))
                            {
                                // 入力チェック
                                TMsgDisp.Show(
                                    this, 								                         // 親ウィンドウフォーム
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,                          // エラーレベル
                                    this.Name, 						                             // アセンブリＩＤまたはクラスＩＤ
                                    this.uLabel_PartySaleSlipNumTitle.Text + MUSTINPUTERROR, 	 // 表示するメッセージ
                                    0, 									                         // ステータス値
                                    MessageBoxButtons.OK);				                         // 表示するボタン
                                tEdit_PartySaleSlipNum.Clear();// 2011/08/03 add wangf for readMine#23375 8月納品
                                e.NextCtrl = tEdit_PartySaleSlipNum;
                                this._prevControl = e.NextCtrl;//ADD 黄興貴 2015/04/01 Redmine#45073 障害No.179
                                this._showErrorMsg = true;//ADD 黄興貴 2015/03/25 Redmine#45073 宮田自動車商会 仕入伝票入力で仕入伝票番号が空白のデータが作成されるの不具合の対応
                                return;
                            }
                            // 2011/07/21 add wangf end

							if (stockSlipCurrent.PartySaleSlipNum != value)
							{
                                if (!string.IsNullOrEmpty(value))
                                {
                                    string message;
                                    DateTime targetDate = ( stockSlip.SupplierFormal == 0 ) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay;
                                    if (!this._stockSlipInputAcs.CheckPartySaleSlipNumDuplicate(stockSlip.SupplierFormal, stockSlip.StockSectionCd, value, targetDate, stockSlip.SupplierSlipNo, stockSlip.SupplierCd, out message))
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            message,
                                            -1,
                                            MessageBoxButtons.OK);

                                        canChangeFocus = false;
                                        value = stockSlip.PartySaleSlipNum;
                                    }
                                }

								stockSlip.PartySaleSlipNum = value;

                                // 仕入データクラス→画面格納処理
                                this.SetDisplay(stockSlip);
                            }

                            // NextCtrl制御
                            if (canChangeFocus)
                            {
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                                getNextCtrl = false;
                            }


							break;
						}
					#endregion

                    // 2009.04.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    #region ●備考１ガイド
                    case "uButton_SlipNote1":
                        {
                            getNextCtrlForFooter = true;
                            break;
                        }
                    #endregion

                    #region ●備考２ガイド
                    case "uButton_SlipNote2":
                        {
                            getNextCtrlForFooter = true;
                            break;
                        }
                    #endregion

                    #region ●返品理由ガイド
                    case "uButton_RetGoodsReason":
                        {
                            getNextCtrlForFooter = true;
                            break;
                        }
                    #endregion
                    // 2009.04.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    #region ●備考１
                    //---------------------------------------------------------------
					// 備考１
					//---------------------------------------------------------------
					case "tEdit_SupplierSlipNote1":
						{
							string value = this.tEdit_SupplierSlipNote1.Text;

							if (stockSlipCurrent.SupplierSlipNote1 != value)
							{
								stockSlip.SupplierSlipNote1 = value;
							}

                            getNextCtrlForFooter = true; // 2009.04.02

							if (!e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										if (string.IsNullOrEmpty(this.tEdit_SupplierSlipNote1.Text.Trim()))
										{
											nextCtrl = this.uButton_SlipNote1;
										}
										else
										{
                                            getNextCtrlForFooter = false;  // ADD 2011/11/30 gezh redmine#8383
                                            //nextCtrl = this.tEdit_SupplierSlipNote2;  // DEL 2011/11/30 gezh redmine#8383
											nextCtrl = this.tNedit_SupplierSlipNote2;   // ADD 2011/11/30 gezh redmine#8383
										}
										break;
									default:
										break;
								}
							}

							break;
						}
					#endregion
                    // ADD 2011/11/30 gezh redmine#8383 -------------------------------->>>>>
                    #region ●備考番号１
                    //---------------------------------------------------------------
                    // 備考番号１
                    //---------------------------------------------------------------
                    case "tNedit_SupplierSlipNote1":
                        {
                            getNextCtrlForFooter = true;
                            int value = this.tNedit_SupplierSlipNote1.GetInt();

                            if (stockSlipCurrent.SupplierSlipNoteNo1 != value)
                            {
                                string noteGuideName = string.Empty;
                                if (value == 0)
                                {
                                    stockSlip.SupplierSlipNote1 = noteGuideName;
                                    stockSlip.SupplierSlipNoteNo1 = 0;
                                }
                                else
                                {
                                    int status = this._stockSlipInputInitDataAcs.GetName_NoteGuidBd(StockSlipInputInitDataAcs.ctDIVCODE_NoteGuid_StockSlipNote1, value, out noteGuideName);
                                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                    {
                                        stockSlip.SupplierSlipNote1 = noteGuideName;
                                        stockSlip.SupplierSlipNoteNo1 = value;
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "伝票備考コードが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    }
                                }
                            }
                            // 仕入データクラス→画面格納処理
                            this.SetDisplay(stockSlip);
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        if (string.IsNullOrEmpty(this.tNedit_SupplierSlipNote1.Text.Trim()))
                                        {
                                            nextCtrl = this.uButton_SlipNote1;
                                        }
                                        else
                                        {
                                            nextCtrl = this.tNedit_SupplierSlipNote2;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }

                            break;
                        }
                    #endregion

                    #region ●備考番号2
                    //---------------------------------------------------------------
                    // 備考番号2
                    //---------------------------------------------------------------
                    case "tNedit_SupplierSlipNote2":
                        {
                            getNextCtrlForFooter = true;
                            int value = this.tNedit_SupplierSlipNote2.GetInt();

                            if (stockSlipCurrent.SupplierSlipNoteNo2 != value)
                            {
                                string noteGuideName = string.Empty;
                                if (value == 0)
                                {
                                    stockSlip.SupplierSlipNote2 = noteGuideName;
                                    stockSlip.SupplierSlipNoteNo2 = 0;
                                }
                                else
                                {
                                    int status = this._stockSlipInputInitDataAcs.GetName_NoteGuidBd(StockSlipInputInitDataAcs.ctDIVCODE_NoteGuid_StockSlipNote2, value, out noteGuideName);
                                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                    {
                                        stockSlip.SupplierSlipNote2 = noteGuideName;
                                        stockSlip.SupplierSlipNoteNo2 = value;
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "伝票備考コードが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    }
                                }
                            }
                            // 仕入データクラス→画面格納処理
                            this.SetDisplay(stockSlip);
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        if (string.IsNullOrEmpty(this.tNedit_SupplierSlipNote1.Text.Trim()))
                                        {
                                            nextCtrl = this.uButton_SlipNote2;
                                        }
                                        else
                                        {
                                            if ((this.tEdit_RetGoodsReason.Visible) && (this.tEdit_RetGoodsReason.Enabled))
                                            {
                                                nextCtrl = this.tEdit_RetGoodsReason;
                                            }
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }

                            break;
                        }
                    #endregion
                    // ADD 2011/11/30 gezh redmine#8383 --------------------------------<<<<<

					#region ●備考２
					//---------------------------------------------------------------
					// 備考２
					//---------------------------------------------------------------
					case "tEdit_SupplierSlipNote2":
						{
							string value = this.tEdit_SupplierSlipNote2.Text;

							if (stockSlipCurrent.SupplierSlipNote2 != value)
							{
								stockSlip.SupplierSlipNote2 = value;
							}

                            getNextCtrlForFooter = true; // 2009.04.02

							if (!e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										if (string.IsNullOrEmpty(this.tEdit_SupplierSlipNote2.Text.Trim()))
										{
											nextCtrl = this.uButton_SlipNote2;
										}
										else
										{
											if (( this.tEdit_RetGoodsReason.Visible ) && ( this.tEdit_RetGoodsReason.Enabled ))
											{
												nextCtrl = this.tEdit_RetGoodsReason;
                                            }
                                            // ADD 2011/11/30 gezh redmine#8383 -------->>>>>
                                            else
                                            {
                                                getNextCtrlForFooter = false;
                                                nextCtrl = this.tEdit_SupplierSlipNote2;
                                            }
                                            // ADD 2011/11/30 gezh redmine#8383 --------<<<<<
										}
										break;
									default:
										break;
								}
							}

							break;
						}
					#endregion

					#region ●返品理由
					//---------------------------------------------------------------
					// 返品理由
					//---------------------------------------------------------------
                    case "tEdit_RetGoodsReason":
						{
                            string value = this.tEdit_RetGoodsReason.Text;

                            if (stockSlipCurrent.RetGoodsReason != value)
                            {
                                stockSlip.RetGoodsReason = value;
                                stockSlip.RetGoodsReasonDiv = 0;
                            }

                            getNextCtrlForFooter = true; // 2009.04.02

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        if (string.IsNullOrEmpty(this.tEdit_RetGoodsReason.Text.Trim()))
                                        {
                                            nextCtrl = this.uButton_RetGoodsReason;
                                        }
                                        else
                                        {
                                            prevCtrl = this.uButton_RetGoodsReason;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
							break;

						}
					#endregion

                    #region ●消費税率
                    //---------------------------------------------------------------
					// 消費税率
					//---------------------------------------------------------------
					case "tNedit_SupplierConsTaxRate":
						{
							double rate = this.tNedit_SupplierConsTaxRate.GetValue() / 100;

							if (stockSlipCurrent.SupplierConsTaxRate != rate)
							{
								stockSlip.SupplierConsTaxRate = rate;
								taxRateChanged = true;
							}
							break;
						}
					#endregion

					#region ●総額表示方法
					//---------------------------------------------------------------
					// 総額表示方法区分
					//---------------------------------------------------------------
					case "tComboEditor_SuppTtlAmntDspWayCd":
						{
							// 総額表示コンボエディタ選択確定後発生イベントを一時的に解除
							this.tComboEditor_SuppTtlAmntDspWayCd.SelectionChangeCommitted -= new System.EventHandler(this.tComboEditor_SuppTtlAmntDspWayCd_SelectionChangeCommitted);

							int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_SuppTtlAmntDspWayCd, ComboEditorGetDataType.VALUE);

                            if (stockSlipCurrent.SuppTtlAmntDspWayCd != code)
                            {
                                stockSlip.SuppTtlAmntDspWayCd = code;

                                // 仕入明細データセッティング処理（課税区分設定）
                                this._stockSlipInputAcs.StockDetailRowTaxationCodeSetting(stockSlip.SuppCTaxLayCd, code);

                                reCalcStockPrice = true;
                            }

							// 仕入データクラス→画面格納処理
							this.SetDisplay(stockSlip);

							// 伝票区分コンボエディタ選択確定後発生イベントを挿入
							this.tComboEditor_SuppTtlAmntDspWayCd.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_SuppTtlAmntDspWayCd_SelectionChangeCommitted);

							break;
						}
					#endregion

					#region ●仕入合計金額
					//---------------------------------------------------------------
					// 仕入合計金額
					//---------------------------------------------------------------
					case "tNedit_StockTotalPrice":
						{
							//int sign = ( ( stockSlip.DebitNoteDiv == 1 ) || ( stockSlip.SupplierSlipCd == 20 ) ) ? -1 : 1;
                            int sign = ( stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;
							long newValue = (long)this.tNedit_StockTotalPrice.GetValue();

							long oldValue = this.GetStockTotalPrice(stockSlipCurrent);

                            if (( newValue * sign ) != oldValue)
                            {
                                this._stockSlipInputAcs.StockDetailStockPriceSetting(1, newValue);

                                this._stockSlipInputAcs.TotalPriceSetting(ref stockSlip, true);
                            }

                            getNextCtrlForFooter = true; // 2009.04.02

							break;
						}
					#endregion

					#region ●仕入消費税
					case "tNedit_StockPriceConsTaxTotal":
						{
                            int sign = ( stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;
                            long newValue = (long)this.tNedit_StockPriceConsTaxTotal.GetValue();
							long oldValue = stockSlip.StockPriceConsTax;
                            if (( newValue * sign ) != oldValue)
                            {
                                // 商品区分によって処理分岐
                                switch (stockSlip.StockGoodsCd)
                                {
                                    // 商品
                                    case 0:
                                        if (stockSlip.SuppTtlAmntDspWayCd == 0)
                                        {
                                            // --- UPD 2010/10/27 ---------->>>>>
                                            //stockSlip.TaxAdjust = (long)( (decimal)newValue - (decimal)stockSlip.StockPriceConsTax + (decimal)stockSlip.TaxAdjust );
                                            stockSlip.TaxAdjust = (long)((decimal)(newValue * sign) - (decimal)stockSlip.StockPriceConsTax + (decimal)stockSlip.TaxAdjust);
                                            // --- UPD 2010/10/27 ----------<<<<<
                                        }
                                        else
                                        {
                                            stockSlip.TaxAdjust = (long)( (decimal)newValue - (decimal)stockSlip.StockPriceConsTax + (decimal)stockSlip.TaxAdjust );
                                            stockSlip.BalanceAdjust = stockSlip.TaxAdjust * -1;
                                        }
                                        this._stockSlipInputAcs.TotalPriceSetting(ref stockSlip, false);
                                        clearTaxAdjust = false;

                                        break;
                                    case 6:
                                        this._stockSlipInputAcs.StockDetailTaxPriceSetting(stockSlip, 1, newValue);
                                        this._stockSlipInputAcs.TotalPriceSetting(ref stockSlip, true);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                this.SetDisplay(stockSlip, SetDisplayMode.TotalPriceInfoOnly);
                            }

                            getNextCtrlForFooter = true; // 2009.04.02

							break;
						}
					#endregion

					#region ●メモ
					//---------------------------------------------------------------
					// メモ
					//---------------------------------------------------------------
					case "tEdit_InsideMemo1":
					case "tEdit_InsideMemo2":
					case "tEdit_InsideMemo3":
					case "tEdit_InsideMemo4":
					case "tEdit_InsideMemo5":
					case "tEdit_InsideMemo6":
					case "tEdit_SlipMemo1":
					case "tEdit_SlipMemo2":
					case "tEdit_SlipMemo3":
					case "tEdit_SlipMemo4":
					case "tEdit_SlipMemo5":
					case "tEdit_SlipMemo6":
						{
							SetSlipMemo();
							this._stockSlipDetailInput.DisplayMemo();
							break;
						}
					#endregion
				}
			}

			// フォーカス移動項目の自動取得
			if (getNextCtrl)
			{
				if (e.ShiftKey)
				{
					switch (e.Key)
					{
						case Keys.Return:
						case Keys.Tab:
							nextCtrl = this.GetNextControl(prevCtrl, StockSlipInputAcs.MoveMethod.PrevMove);
                            if (nextCtrl == null)
                            {
                                nextCtrl = prevCtrl;
                            }
							break;
						default:
							break;
					}
				}
				else
				{
					switch (e.Key)
					{
						case Keys.Return:
						case Keys.Tab:
							nextCtrl = this.GetNextControl(prevCtrl, StockSlipInputAcs.MoveMethod.NextMove);
							break;
					}
				}
			}
            // 2009.04.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            else if (getNextCtrlForFooter)
            {
                #region フォーカス指定
                if (e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            nextCtrl = this.GetNextControlForFooter(prevCtrl, StockSlipInputAcs.MoveMethod.PrevMove);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            nextCtrl = this.GetNextControlForFooter(prevCtrl, StockSlipInputAcs.MoveMethod.NextMove);
                            break;
                        default:
                            break;
                    }
                }
                #endregion
            }
            // 2009.04.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			if (nextCtrl != null)
			{
				// 明細が入力不可の状態で明細にフォーカス移動しようとした場合は、フッター部「備考」にフォーカスセット
				if (this._stockSlipDetailInput.Contains(nextCtrl))
				{
					if (( !this._stockSlipDetailInput.Enabled ) || ( !nextCtrl.Enabled ))
					{
						this.uTabControl_Footer.SelectedTab = this.uTabControl_Footer.Tabs[this.uTab_StockInfo.Tab.Key];
						//nextCtrl = this.tEdit_SupplierSlipNote1;  //DEL 2011/11/30 gezh redmine#8383
                        nextCtrl = this.tNedit_SupplierSlipNote1;   //ADD 2011/11/30 gezh redmine#8383
					}
				}
				e.NextCtrl = nextCtrl;
			}

			// メモリ上の内容と比較する
			ArrayList arRetList = stockSlip.Compare(stockSlipCurrent);

			if (arRetList.Count > 0)
			{
				// 仕入データキャッシュ処理
				this._stockSlipInputAcs.Cache(stockSlip);

				// 仕入データクラス→画面格納処理
				this.SetDisplay(stockSlip);

				// データ変更フラグプロパティをTrueにする
				this._stockSlipInputAcs.IsDataChanged = true;
			}

			if ((changeStockGoodsCd) || (changeSupplierFormal))
			{
				// 明細グリッドセル設定処理
				this._stockSlipDetailInput.SettingGrid();

				reCalcStockPrice = true;
			}

			if (taxRateChanged)
			{
                this._stockSlipInputAcs.StockDetailRowTaxRateChanged(stockSlip.SupplierConsTaxRate, stockSlip.SuppCTaxLayCd);

				reCalcStockPrice = true;
				adjustStockUnitPrice = true;

				// 仕入データクラス→画面格納処理
				this.SetDisplay(stockSlip);
			}
			if (changeSupplierSlipCd)
			{
				reCalcStockPrice = true;
			}

			if (adjustStockUnitPrice)
			{
				// 仕入明細データセッティング処理（単価調整）
				this._stockSlipInputAcs.StockDetailRowPriceAdjust();

				// 仕入金額変更後発生イベント処理
				this.StockSlipDetailInput_StockPriceChanged(this, new EventArgs());
			}

			if (reCalcStockUnitPrice)
			{
				// 商品価格の再設定を行います。
				this._stockSlipInputAcs.StockDetailTableGoodsPriceReSetting();
				reCalcStockPrice = true;
                // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------>>>>>
                // 明細グリッドセル設定処理
                this._stockSlipDetailInput.SettingGrid();
                // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------<<<<<
			}
			if (reCalcStockPrice)
			{
				// 仕入金額計算処理
				this._stockSlipDetailInput.CalculationStockPrice();

				// 仕入金額変更後発生イベント処理
				this.StockSlipDetailInput_StockPriceChanged(this, new EventArgs(), clearTaxAdjust);
			}

            if (clearRateInfo)
            {
                this._stockSlipInputAcs.StockDetailTableClearRateInfo();
            }

            this._stockSlipDetailInput.ActiveCellButtonEnabledControl();
			
			// ガイドボタンツール有効無効設定処理
			if ((e.NextCtrl != null) && (e.NextCtrl.TabStop))
			{
				this.SettingGuideButtonToolEnabled(e.NextCtrl);
			}

			if (settingFotter)
			{
				this._stockSlipDetailInput.SettingFooterEventCall();
                this.SettingToolBarButtonCaption(e.NextCtrl); // 2009.03.25
			}

            this._prevControl = e.NextCtrl;

            // 2009.04.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //---------------------------------------------------------------
            // 登録処理
            //---------------------------------------------------------------
            //   最終項目()でEnterキーを押下した場合
            //---------------------------------------------------------------
            if ((e.Key == Keys.Enter) && (!this._changeFocusSaveCancel))
            {
                if (e.PrevCtrl == e.NextCtrl)
                {
                    if ((e.PrevCtrl.Name == "tEdit_SupplierSlipNote2") ||
                        (e.PrevCtrl.Name == "tNedit_SupplierSlipNote2") ||  //ADD 2011/11/30 gezh redmine#8383
                        (e.PrevCtrl.Name == "uButton_SlipNote2") ||
                        (e.PrevCtrl.Name == "tEdit_RetGoodsReason") ||
                        (e.PrevCtrl.Name == "uButton_RetGoodsReason") ||
                        // 2009.06.17 Add >>>
                        ( e.PrevCtrl.Name == "tNedit_StockTotalPrice" ) ||
                        // 2009.06.17 Add <<<
                        (e.PrevCtrl.Name == "tNedit_StockPriceConsTaxTotal"))
                    {
                        bool isSave = this.Save(true, true);

                        if (isSave)
                        {
                            // --- ADD 2013/02/15 Y.Wakita ---------->>>>>
                            this.AfterSaveDisplay();
                            // --- ADD 2013/02/15 Y.Wakita ----------<<<<<
                            // --- ADD 黄興貴 2015/04/16 Redmine#45230 仕入伝票入力で仕入伝票番号が欠けるの不具合の対応 ------ >>>>>>
                            Control firstControl = this.GetHeaderFirstControlAfterSave();
                            e.NextCtrl = firstControl;
                            // --- ADD 黄興貴 2015/04/16 Redmine#45230 仕入伝票入力で仕入伝票番号が欠けるの不具合の対応 ------ <<<<<
                            
                            // --- DEL 2013/02/15 Y.Wakita ---------->>>>>
                            //// 保存後の画面初期化「する」か、セキュリティ権限で「伝票修正不可」の場合は画面を初期化
                            //if ((this._stockInputConstructionAcs.ClearAfterSaveValue == StockSlipInputConstructionAcs.ClearAfterSave_ON) ||
                            //    (MyOpeCtrl.Disabled((int)OperationCode.Revision)))
                            //{
                            //    bool keepSupplierFormal = (this._stockInputConstructionAcs.SupplierFormalAfterSaveValue == StockSlipInputConstructionAcs.SupplierFormalAfterSave_Init) ? false : true;
                            //
                            //    bool keepDate = true;
                            //
                            //    // 保存後の日付「システム日付」か、
                            //    // 保存後の日付「仕入在庫全体設定参照」でマスタ設定が「システム日付に戻す」の場合は日付を保持しない
                            //    if ((this._stockInputConstructionAcs.DateClearAfterSaveValue == StockSlipInputConstructionAcs.DateClearAfterSave_ON) ||
                            //        ((this._stockInputConstructionAcs.DateClearAfterSaveValue == StockSlipInputConstructionAcs.DateClearAfterSave_Default) && (this._stockSlipInputInitDataAcs.GetStockTtlSt().SlipDateClrDivCd == 0)))
                            //    {
                            //        keepDate = false;
                            //    }
                            //
                            //    // MEMO:保存後の入力区分の保持フラグ
                            //    bool keepStockGoodsCd = (this._stockInputConstructionAcs.StockGoodsCdAfterSaveValue == StockSlipInputConstructionAcs.StockGoodsCdAfterSave_Init) ? false : true;    // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加
                            //
                            //    // クリア処理
                            //    // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加↓4パラ目を追加
                            //    this.Clear(false, keepSupplierFormal, keepDate, keepStockGoodsCd);
                            //}
                            ////----ADD  2013/01/08 Readmine#31984　鄭慕鈞  ----->>>>>
                            ////保存後の画面初期化「しない」設定し、連続新規できるように修正する、下記のプロパティーをクリアする
                            ////クリア処理範囲は赤伝以外
                            //if (this._stockInputConstructionAcs.ClearAfterSaveValue == StockSlipInputConstructionAcs.ClearAfterSave_OFF&& !this.uLabel_InputModeTitle.Text.Equals("赤伝"))
                            //{
                            //    this.tNedit_SupplierSlipNo.Clear();
                            //    this.tNedit_SupplierSlipNo.Enabled = true;
                            //    this.tEdit_PartySaleSlipNum.Clear();
                            //    this._stockSlipInputAcs.StockSlip.UpdateDateTime = DateTime.MinValue;
                            //    this._stockSlipInputAcs.StockSlip.SupplierSlipNo = 0;
                            //    this._stockSlipInputAcs.StockSlip.PartySaleSlipNum = "";
                            //    this._stockSlipInputAcs.Cache(this._stockSlipInputAcs.StockSlip);
                            //    // 仕入データクラス→画面格納処理
                            //    this.SetDisplay(this._stockSlipInputAcs.StockSlip);
                            //}
                            ////赤伝以外の伝票登録した上で、保存後フォーカス設定
                            //if (!this.uLabel_InputModeTitle.Text.Equals("赤伝"))
                            //{
                            //    this.timer_AfterSaveSetFocus.Enabled = true;//保存後フォーカス設定
                            //}
                            ////保存後の画面初期化「しない」設定し、赤伝登録した上で、画面の初期化処理を追加する
                            //if (this._stockInputConstructionAcs.ClearAfterSaveValue == StockSlipInputConstructionAcs.ClearAfterSave_OFF && this.uLabel_InputModeTitle.Text.Equals("赤伝"))
                            //{
                            //    // 初期化処理
                            //    this.Clear(false, false);
                            //    this.timer_InitialSetFocus.Enabled = true;//初期化フォーカス設定
                            //}
                            ////----ADD  2013/01/08  Readmine#31984　鄭慕鈞 -----<<<<<
                            ////this.timer_AfterSaveSetFocus.Enabled = true;　//----- DEL 2013/01/08 Readmine#31984　鄭慕鈞
                            // --- DEL 2013/02/15 Y.Wakita ----------<<<<<
                        }
                    }
                }
            }
            // 2009.04.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }
		
		/// <summary>
		/// 初期フォーカス設定タイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
		{
			this.timer_InitialSetFocus.Enabled = false;

			Control firstControl = this.GetHeaderFirstControl();

            this.SetFocusTimerProcessing(firstControl);
		}

        /// <summary>
        /// 保存後フォーカス設定タイマー起動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2015/05/20 黄興貴</br>
        /// <br>管理番号    : 11100008-00</br>
        /// <br>            : Redmine#45230 宮田自動車商会 
        /// <br>            : 仕入伝票入力で仕入伝票番号が欠けるの不具合の対応</br>
        private void timer_AfterSaveSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_AfterSaveSetFocus.Enabled = false;

            // DEL 黄興貴 2015/05/20 仕入伝票番号が欠けるの不具合障害の対応 ---->>>>>
            //Control firstControl = this.GetHeaderFirstControlAfterSave();

            // this.SetFocusTimerProcessing(firstControl);
            // DEL 黄興貴 2015/05/20 仕入伝票番号が欠けるの不具合障害の対応 ----<<<<<
            // ボタンなど初期化処理を行う（フォーカス設定不要）
            NoSetFocusTimerProcessing();// ADD 黄興貴 2015/05/20 仕入伝票番号が欠けるの不具合障害の対応
        }

        /// <summary>
        /// フォーカス設定タイマーでの処理
        /// </summary>
        /// <param name="firstControl"></param>
        private void SetFocusTimerProcessing(Control firstControl)
        {
            if (firstControl != null)
                firstControl.Focus();

            this._stockSlipDetailInput.ActiveCellButtonEnabledControl();

            // ガイドボタンツール有効無効設定処理
            this.SettingGuideButtonToolEnabled(this.GetActiveControl());

            // フッター情報設定
            this._stockSlipDetailInput.SettingFooterEventCall();

            this.timer_InitialSetSlider.Enabled = true;
            this._prevControl = this.GetActiveControl();
        }

        // ADD 黄興貴 2015/05/20 仕入伝票番号が欠けるの不具合障害の対応 ---->>>>>
        /// <summary>
        /// ボタンなど初期化処理（フォーカス設定不要）
        /// </summary>
        /// <br>Update Note : 2015/05/20 黄興貴</br>
        /// <br>管理番号    : 11100008-00</br>
        /// <br>            : Redmine#45230 宮田自動車商会 
        /// <br>            : 仕入伝票入力で仕入伝票番号が欠けるの不具合の対応</br>
        /// <br>              メソッドSetFocusTimerProcessingを参照して、フォーカス処理を削除する。</br>
        private void NoSetFocusTimerProcessing()
        {
            this._stockSlipDetailInput.ActiveCellButtonEnabledControl();

            // ガイドボタンツール有効無効設定処理
            this.SettingGuideButtonToolEnabled(this.GetActiveControl());

            // フッター情報設定
            this._stockSlipDetailInput.SettingFooterEventCall();

            this.timer_InitialSetSlider.Enabled = true;
            this._prevControl = this.GetActiveControl();
        }
        // ADD 黄興貴 2015/05/20 仕入伝票番号が欠けるの不具合障害の対応 ----<<<<<

		/// <summary>
		/// スーパースライダー初期設定タイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note : 2014/12/08 譚洪</br>
        /// <br>管理番号    : 11070149-00</br>
        /// <br>            : redmine　#43864 追加対応</br>
        /// <br>            : Timer同時処理の障害対応</br>
		private void timer_InitialSetSlider_Tick( object sender, EventArgs e )
		{
			this.timer_InitialSetSlider.Enabled = false;

            // ADD 2014/12/08 譚洪 --- >>>
            if (this._timerIsRunFlag)
            {
                return;
            }

            this._timerIsRunFlag = true;

            try
            {
            // ADD 2014/12/08 譚洪 --- <<<

			//if (this._superSlider == null) return;

                // --- DEL 譚洪 2015/02/04 ------ >>>
                // --- ADD 譚洪 2014/11/01 ------ >>>
                //if (this._superSlider != null)
                //{
                //    this._superSlider.ClosePanel();
                //    this.panel_SuperSlider.Controls.Remove(this._superSlider.GetMainPanel());
                //    this._superSlider.DisposeForm();
                //    this._superSlider.Dispose();
                //}

                //System.Windows.Forms.Application.DoEvents();
                // --- ADD 譚洪 2014/11/01 ------ <<<
                // --- DEL 譚洪 2015/02/04 ------ <<<

                // --- ADD 譚洪 2015/02/04 ------ >>>
                if (this._superSlider != null)
                {
                    this._superSlider.InitForNoComponent();
                }
                else
                {
                    // --- ADD 譚洪 2015/02/04 ------ <<<
			// アイコン設定
			this.ultraDockManager_Main.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
			this.ultraDockManager_Main.ControlPanes[this.panel_SuperSlider].Settings.Appearance.Image = Size16_Index.TREE;

			// スライダー起動パラメータ設定
			SFCMN00221UAParam param = new SFCMN00221UAParam();
			param.SupplierDiv = 1;										// 仕入先指定
			param.ShowStockSlipList = true;
			param.ShowCustomerList = true;

			this._superSlider = new SFCMN00221UA(param);
			Panel sliderPanel = _superSlider.GetMainPanel();
			this.panel_SuperSlider.Controls.Add(sliderPanel);
			sliderPanel.Dock = System.Windows.Forms.DockStyle.Fill;

			// 伝票呼出しイベント(スライダーにて伝票修正選択時に発生)
			this._superSlider.ModifyStockSlip += new ModifyStockSlipHandler(this.SuperSlider_ModifyStockSlip);

			// 仕入先選択イベント(スライダーにて仕入先指定で新規伝票作成時に発生)
			this._superSlider.CreateNewSlipUsedSupplier += new CreateNewSlipUsedSupplierHandler(this.SuperSlider_CreateNewSlip);

			// 仕入先選択イベント(スライダーにて仕入先を伝票に反映時に発生)
			this._superSlider.SelectedSupplier += new SelectedSupplierHandler(this.SuperSlider_SelectedCustomer);

			// 赤伝発行イベント(スライダーにて赤伝発行時に発生)
			this._superSlider.RedWriteStockSlip += new ModifyStockSlipHandler(this.SuperSlider_RedWriteStockSlip);

			// 入荷計上イベント（スライダーにて入荷計上時に発生）
			this._superSlider.TrustAppropriateStockSlip += new ModifyStockSlipHandler(this.SuperSlider_TrustAppropriateStockSlip);

			// 伝票コピーイベント（スライダーにて伝票コピー時に発生)
			this._superSlider.SlipCopy += new ModifyStockSlipHandler(this.SuperSlider_SlipCopy);
		}
            // ADD 2014/12/08 譚洪 --- >>>
            }
            finally
            {
                this._timerIsRunFlag = false;  // ADD 2014/12/08 譚洪
            }
            // ADD 2014/12/08 譚洪 --- <<<
		}

		/// <summary>
		/// ツールバーボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2010/12/03 yangmj 新規ボタン押下時の仕入日、入荷日のクリア処理の修正</br>
        /// <br>Update Note: 2011/02/09 田建委 Redmine18823　障害対応１２月分 仕入伝票入力</br>
        /// <br>Update Note : 2013/01/08 鄭慕鈞</br>
        /// <br>管理番号    : 10801804-00 2013/03/13配信分</br>
        /// <br>            : redmine#31984 仕入伝票入力の操作便利の対応</br>
        /// <br>Update Note : 2020/02/24 田建委</br>
        /// <br>管理番号    : 11570208-00</br>
        /// <br>            : PMKOBETSU-2912消費税税率機能追加対応</br>
         private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				//---------------------------------------------------------------
				// 終了
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_CLOSE_KEY:
					{
						// 終了処理
						this.Close(true);
						break;
					}
				//---------------------------------------------------------------
				// 保存
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_SAVE_KEY :
					{
                        // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //// 保存処理
                        //bool isSave = this.Save(true, true);

                        //if (isSave)
                        //{
                        //    // 保存後の画面初期化「する」か、セキュリティ権限で「伝票修正不可」の場合は画面を初期化
                        //    if (( this._stockInputConstructionAcs.ClearAfterSaveValue == StockSlipInputConstructionAcs.ClearAfterSave_ON ) ||
                        //        ( MyOpeCtrl.Disabled((int)OperationCode.Revision) ))
                        //    {
                        //        bool keepSupplierFormal = ( this._stockInputConstructionAcs.SupplierFormalAfterSaveValue == StockSlipInputConstructionAcs.SupplierFormalAfterSave_Init ) ? false : true;

                        //        bool keepDate = true;

                        //        // 保存後の日付「システム日付」か、
                        //        // 保存後の日付「仕入在庫全体設定参照」でマスタ設定が「システム日付に戻す」の場合は日付を保持しない
                        //        if (( this._stockInputConstructionAcs.DateClearAfterSaveValue == StockSlipInputConstructionAcs.DateClearAfterSave_ON ) ||
                        //            ( ( this._stockInputConstructionAcs.DateClearAfterSaveValue == StockSlipInputConstructionAcs.DateClearAfterSave_Default ) && ( this._stockSlipInputInitDataAcs.GetStockTtlSt().SlipDateClrDivCd == 0 ) ))
                        //        {
                        //            keepDate = false;
                        //        }

                        //        // クリア処理
                        //        this.Clear(false, keepSupplierFormal, keepDate);
                        //    }
                        //    this.timer_AfterSaveSetFocus.Enabled = true;
                        //}

                        Control nextControl = null;

                        if (this.panel_Header.ContainsFocus)
                        {
                            if (this._stockSlipDetailInput.Enabled)
                            {
                                nextControl = this._stockSlipDetailInput;
                            }
                        }
                        if ((this.panel_Detail.ContainsFocus) && (nextControl == null))
                        {
                            if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_SlipMemo)
                            {
                                if (this.tEdit_InsideMemo1.Enabled)
                                {
                                    nextControl = this.tEdit_InsideMemo1;
                                }
                            }
                            else
                            {
                                // DEL 2011/11/30 gezh redmine#8383 ------------>>>>>
                                //if (this.tEdit_SupplierSlipNote1.Enabled)
                                //{
                                //    nextControl = this.tEdit_SupplierSlipNote1;
                                //}
                                // DEL 2011/11/30 gezh redmine#8383 ------------<<<<<
                                // ADD 2011/11/30 gezh redmine#8383 ------------<<<<<
                                if (this.tNedit_SupplierSlipNote1.Enabled)
                                {
                                    nextControl = this.tNedit_SupplierSlipNote1;
                                }
                                // ADD 2011/11/30 gezh redmine#8383 ------------<<<<<
                            }
                        }

                        if (nextControl != null)
                        {
                            // 一括ゼロ詰め
                            this.uiSetControl1.SettingAllControlsZeroPaddedText();
                            ChangeFocusEventArgs ex = new ChangeFocusEventArgs(false, false, false, Keys.Down, this.GetActiveControl(), nextControl);
                            this.tArrowKeyControl1_ChangeFocus(this, ex);
                            nextControl = ex.NextCtrl;
                            nextControl.Focus();
                            this._prevControl = nextControl;
                        }
                        else
                        {
                            // 保存処理
                            bool isSave = this.Save(true, true);

                            if (isSave)
                            {
                                // --- ADD 2013/02/15 Y.Wakita ---------->>>>>
                                this.AfterSaveDisplay();
                                // --- ADD 2013/02/15 Y.Wakita ----------<<<<<

                                // --- DEL 2013/02/15 Y.Wakita ---------->>>>>
                                //// 保存後の画面初期化「する」か、セキュリティ権限で「伝票修正不可」の場合は画面を初期化
                                //if ((this._stockInputConstructionAcs.ClearAfterSaveValue == StockSlipInputConstructionAcs.ClearAfterSave_ON) ||
                                //    (MyOpeCtrl.Disabled((int)OperationCode.Revision)))
                                //{
                                //    bool keepSupplierFormal = (this._stockInputConstructionAcs.SupplierFormalAfterSaveValue == StockSlipInputConstructionAcs.SupplierFormalAfterSave_Init) ? false : true;
                                //
                                //    bool keepDate = true;
                                //
                                //    // 保存後の日付「システム日付」か、
                                //    // 保存後の日付「仕入在庫全体設定参照」でマスタ設定が「システム日付に戻す」の場合は日付を保持しない
                                //    if ((this._stockInputConstructionAcs.DateClearAfterSaveValue == StockSlipInputConstructionAcs.DateClearAfterSave_ON) ||
                                //        ((this._stockInputConstructionAcs.DateClearAfterSaveValue == StockSlipInputConstructionAcs.DateClearAfterSave_Default) && (this._stockSlipInputInitDataAcs.GetStockTtlSt().SlipDateClrDivCd == 0)))
                                //    {
                                //        keepDate = false;
                                //    }
                                //
                                //    // MEMO:保存後の入力区分の保持フラグ
                                //    bool keepStockGoodsCd = (this._stockInputConstructionAcs.StockGoodsCdAfterSaveValue == StockSlipInputConstructionAcs.StockGoodsCdAfterSave_Init) ? false : true;    // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加
                                //
                                //    // クリア処理
                                //    // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加↓4パラ目を追加
                                //    this.Clear(false, keepSupplierFormal, keepDate, keepStockGoodsCd);
                                //}
                                ////----ADD  2013/01/08 Readmine#31984　鄭慕鈞  ----->>>>>
                                ////保存後の画面初期化「しない」設定し、連続新規できるように修正する、下記のプロパティーをクリアする
                                ////クリア処理範囲は赤伝以外
                                //if (this._stockInputConstructionAcs.ClearAfterSaveValue == StockSlipInputConstructionAcs.ClearAfterSave_OFF && !this.uLabel_InputModeTitle.Text.Equals("赤伝"))
                                //{
                                //    this.tNedit_SupplierSlipNo.Clear();
                                //    this.tNedit_SupplierSlipNo.Enabled = true;
                                //    this.tEdit_PartySaleSlipNum.Clear();
                                //    this._stockSlipInputAcs.StockSlip.UpdateDateTime = DateTime.MinValue;
                                //    this._stockSlipInputAcs.StockSlip.SupplierSlipNo = 0;
                                //    this._stockSlipInputAcs.StockSlip.PartySaleSlipNum = "";
                                //    this._stockSlipInputAcs.Cache(this._stockSlipInputAcs.StockSlip);
                                //    // 仕入データクラス→画面格納処理
                                //    this.SetDisplay(this._stockSlipInputAcs.StockSlip);
                                //}
                                ////赤伝以外の伝票登録した上で、保存後フォーカス設定
                                //if (!this.uLabel_InputModeTitle.Text.Equals("赤伝"))
                                //{
                                //    this.timer_AfterSaveSetFocus.Enabled = true;//保存後フォーカス設定
                                //}
                                ////保存後の画面初期化「しない」設定し、赤伝登録した上で、画面の初期化処理を追加する
                                //if (this._stockInputConstructionAcs.ClearAfterSaveValue == StockSlipInputConstructionAcs.ClearAfterSave_OFF && this.uLabel_InputModeTitle.Text.Equals("赤伝"))
                                //{
                                //    // 初期化処理
                                //    this.Clear(false, false);
                                //    this.timer_InitialSetFocus.Enabled = true;//初期化フォーカス設定
                                //}
                                ////----ADD  2013/01/08  Readmine#31984　鄭慕鈞 -----<<<<<
                                ////this.timer_AfterSaveSetFocus.Enabled = true;　//----- DEL 2013/01/08 Readmine#31984　鄭慕鈞
                                // --- DEL 2013/02/15 Y.Wakita ----------<<<<<
                            }
                        }
                        // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

						break;
					}
				//---------------------------------------------------------------
				// 元に戻す
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_RETRY_KEY:
					{
                        this._returnFlag = true;// ADD 黄興貴 2015/04/01 Redmine#45073 障害No.179
						// 元に戻す処理
						this.Retry(true);
                        // --- ADD 黄興貴 2015/04/01 Redmine#45073 障害No.179 ------>>>>>
                        if (!this._returnFlag)
                        {
                            return;
                        }
                        // --- ADD 黄興貴 2015/04/01 Redmine#45073 障害No.179 ------<<<<<
                        DisplayNameSetting2(this._stockSlipInputAcs.StockSlip);// ADD 田建委 2020/02/24 PMKOBETSU-2912の対応
						this.timer_InitialSetFocus.Enabled = true;
						break;
					}
				//---------------------------------------------------------------
				// 新規
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_NEW_KEY:
					{
                        //-----ADD 2010/12/03----->>>>>
                        DateTime valueArrivalGoodsDay = this.tDateEdit_ArrivalGoodsDay.GetDateTime();
                        DateTime valueStockDate = this.tDateEdit_StockDate.GetDateTime();
                        //-----ADD 2010/12/03-----<<<<<
						// クリア処理
                        //this.Clear(true, true);// DEL 黄興貴 2015/04/01 Redmine#45073 障害No.179
                        // --- ADD 黄興貴 2015/04/01 Redmine#45073 障害No.179 ------>>>>>
                        this._returnFlag = true;
                        this._returnFlag = this.Clear(true, true);
                        if (!this._returnFlag)
                        {
                            return;
                        }
                        // --- ADD 黄興貴 2015/04/01 Redmine#45073 障害No.179 ------<<<<<

                        //-----ADD 2010/12/03----->>>>>
                        if (this._stockSlipInputInitDataAcs.GetStockTtlSt().SlipDateClrDivCd != 0)
                        {
                            // ----- ADD 2011/02/09 -------------------->>>>>
                            this._stockSlipInputAcs.StockSlip.ArrivalGoodsDay = valueArrivalGoodsDay; // 入荷日
                            this._stockSlipInputAcs.StockSlip.StockDate = valueStockDate; // 仕入日
                            // ----- ADD 2011/02/09 --------------------<<<<<

                            this.tDateEdit_ArrivalGoodsDay.SetDateTime(valueArrivalGoodsDay);
                            this.tDateEdit_StockDate.SetDateTime(valueStockDate);
                        }
                        //-----ADD 2010/12/03-----<<<<<
						this.timer_InitialSetFocus.Enabled = true;
						break;
					}
				//---------------------------------------------------------------
				// 設定
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_SETUP_KEY:
					{
						// 設定
						StockSlipInputSetup stockInputSetup = new StockSlipInputSetup();
						DialogResult dialogResult = stockInputSetup.ShowDialog(this);

						if (dialogResult == DialogResult.OK)
						{
							this.timer_InitialSetFocus.Enabled = true;
						}

						break;
					}
				//---------------------------------------------------------------
				// 返品
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_RETURNSLIP_KEY:
					{
						// 返品処理
						this.ReturnSlip(true);
						break;
					}
				//---------------------------------------------------------------
				// 赤伝
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_REDSLIP_KEY:
					{
						// 赤伝処理
						this.RedSlip(true);
						break;
					}
				//---------------------------------------------------------------
				// ガイド
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_GUIDE_KEY:
					{
						// ガイド起動処理
						this.ExecuteGuide();
						break;
					}
				//---------------------------------------------------------------
				// 入荷計上
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_ARRIVALAPPROPRIATE_KEY:
					{
						if (this.panel_Detail.ContainsFocus)
						{
							this.ArrivalReferenceSearch();
						}
						else
						{
							// 入荷計上処理
							this.ArrivalAppropriate(true);
						}

						break;
					}
				//---------------------------------------------------------------
				// 伝票呼出
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_READSLIP_KEY:
					{
                        this.ReadSlip(true);
                        //// 仕入伝票ガイドボタンクリックイベント
                        //this.uButton_SupplierSlipGuide_Click(this.uButton_SupplierSlipGuide, new EventArgs());
						break;
					}
				//---------------------------------------------------------------
				// 伝票削除
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_DELETESLIP_KEY:
					{
						// 削除処理
						this.Delete();
						break;
					}
				//---------------------------------------------------------------
				// 伝票複写
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_COPYSLIP_KEY:
					{
						// 伝票複写
						this.CopySlip(true);
						break;
					}
				//---------------------------------------------------------------
				// 発注履歴
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_ORDERREFERENCE_KEY :
					{
						this.OrderReferenceSearch();
						break;
					}
				//---------------------------------------------------------------
				// 仕入履歴
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_STOCKREFERENCE_KEY:
					{
						this.StockReferenceSearch();
						break;
					}
				//---------------------------------------------------------------
				// 売上登録
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_SALESSLIPENTRY_KEY:
					{
						this.SalesEntry();
						break;
					}

				//---------------------------------------------------------------
				// 進む
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_FORWARD_KEY:
					{
						Control nextControl = null;

						if (this.panel_Header.ContainsFocus)
						{
							if (this._stockSlipDetailInput.Enabled)
							{
								nextControl = this._stockSlipDetailInput;
							}
						}
						if (( this.panel_Detail.ContainsFocus ) || ( nextControl == null ))
						{
							if (this.uTabControl_Footer.ActiveTab.Key == ctTAB_KEY_SlipMemo)
							{
								if (this.tEdit_InsideMemo1.Enabled)
								{
									nextControl = this.tEdit_InsideMemo1;
								}
							}
							else
							{
                                // DEL 2011/11/30 gezh redmine#8383 ------------>>>>>
                                //if (this.tEdit_SupplierSlipNote1.Enabled)
                                //{
                                //    nextControl = this.tEdit_SupplierSlipNote1;
                                //}
                                // DEL 2011/11/30 gezh redmine#8383 ------------<<<<<
                                // ADD 2011/11/30 gezh redmine#8383 ------------>>>>>
                                if (this.tNedit_SupplierSlipNote1.Enabled)
                                {
                                    nextControl = this.tNedit_SupplierSlipNote1;
                                }
                                // ADD 2011/11/30 gezh redmine#8383 ------------<<<<<
							}
						}

						if (nextControl != null)
						{
                            // 一括ゼロ詰め
                            this.uiSetControl1.SettingAllControlsZeroPaddedText();
                            ChangeFocusEventArgs ex = new ChangeFocusEventArgs(false, false, false, Keys.Down, this.GetActiveControl(), nextControl);
                            this.tArrowKeyControl1_ChangeFocus(this, ex);
                            nextControl = ex.NextCtrl;
                            nextControl.Focus();
                            this._prevControl = nextControl;
						} 

						break;
					}

				//---------------------------------------------------------------
				// 戻る
				//---------------------------------------------------------------
				case ctTOOLBAR_BUTTONTOOL_RETURN_KEY :
					{
						Control nextControl = null;
						if (this.uTabControl_Footer.ContainsFocus)
						{
							if (this._stockSlipDetailInput.Enabled)
							{
								nextControl = this._stockSlipDetailInput;
							}
						}

						if (( this.panel_Detail.ContainsFocus ) || ( nextControl == null ))
						{
							nextControl = this.GetHeaderFirstControl();
						}

						if (nextControl != null)
						{
                            // 一括ゼロ詰め
                            this.uiSetControl1.SettingAllControlsZeroPaddedText();
                            ChangeFocusEventArgs ex = new ChangeFocusEventArgs(false, false, false, Keys.Up, this.GetActiveControl(), nextControl);
                            this.tArrowKeyControl1_ChangeFocus(this, ex);
                            nextControl = ex.NextCtrl;

							nextControl.Focus();
						}

						break;
					}

                #region 最新情報
                //---------------------------------------------------------------
                // 最新情報
                //---------------------------------------------------------------
                case "ButtonTool_ReNewal":
                    {
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "画面情報はクリアされます。" + "\r\n" + "\r\n" +
                            "よろしいですか？",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                        if (dialogResult == DialogResult.No) break;

                        SFCMN00299CA processingDialog = new SFCMN00299CA();
                        try
                        {
                            processingDialog.Title = "最新情報取得";
                            processingDialog.Message = "現在、最新情報取得中です。";
                            processingDialog.DispCancelButton = false;
                            processingDialog.Show((Form)this.Parent);

                            this._stockSlipInputInitDataAcs.ReadInitData(this._enterpriseCode, this._loginSectionCode);

                            this._stockSlipInputInitDataAcs.CacheEventCall();

                            //// 処理区分マスタリスト設定
                            //this._salesSlipInputInitDataAcs.SettingProcMoney();


                            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "ボタン初期設定処理");
                            // ボタン初期設定処理
                            this.ButtonInitialSetting();

                            if (this._stockSlipInputInitDataAcs.GetCompanyInf().SecMngDiv == 0)
                            {
                                if (this._headerItemsDictionary.ContainsKey(this.uLabel_SubSectionTitle.Text.Trim()))
                                {
                                    this._headerItemsDictionary.Remove(this.uLabel_SubSectionTitle.Text.Trim());
                                }
                            }

                            this._stockSlipDetailInput.SettingColDisplayStatusByCommonSetting();

                            // ツールバー初期設定処理
                            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "ツールバー初期設定処理");
                            this.ToolBarInitilSetting();
                            this.SettingToolBarButtonCaption();

                            // フォーカス移動設定処理
                            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "フォーカス移動設定処理");
                            this.SettingFocusDictionary();

                            // コンボエディタアイテム初期設定処理
                            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "コンボエディタアイテム初期設定処理");
                            this.ComboEditorItemInitialSetting();

                            // 明細グリッドクリア
                            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "明細グリッドクリア");
                            this._stockSlipDetailInput.Clear();

                            // 画面項目名称設定処理
                            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "画面項目名称設定処理");
                            this.DisplayNameSetting();

                            // セキュリティ権限による制御開始(ツールバーボタン)
                            this.BeginControllingByOperationAuthority();

                            // クリア処理
                            StockSlipInputInitDataAcs.LogWrite("MAKON01110UA", "MAKON01110UA_Load", "クリア処理");
                            this._stockSlipInputInitDataAcs.TaxRateValue = 0;// ADD 田建委 2020/02/24 PMKOBETSU-2912の対応
                            this.Clear(false, false);
                            this.timer_InitialSetFocus.Enabled = true;

                            this._stockSlipInputInitDataAcs.CacheEventCall();

                            this._stockSlipDetailInput.SettingFooterEventCall();

                            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "得意先情報画面格納処理");
                            //// 得意先情報画面格納処理
                            //this.SetDisplayCustomerInfo(null);

                            //SalesSlipInputInitDataAcs.LogWrite("MAHNB01010UA", "MAHNB01010UA_Load", "画面項目Visible設定");
                            //// Visible設定
                            //this.SettingVisible();

                        }
                        finally
                        {
                            processingDialog.Dispose();

                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "最新情報を取得しました。　　",
                                0,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);
                        }

                        break;
                    }
                #endregion

                // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
                // 税率入力
                case ctTOOLBAR_BUTTONTOOL_TAXRATESET_KEY:
                    {
                        double taxRatePara = this._stockSlipInputInitDataAcs.TaxRateValue;
                        if (taxRatePara == 0)
                        {
                            // システム日付
                            taxRatePara = this._stockSlipInputInitDataAcs.GetTaxRate(DateTime.Today);
                        }
                        MAKON01110UI taxRateInput = new MAKON01110UI(taxRatePara);
                        this._controlScreenSkin.SettingScreenSkin(taxRateInput);
                        DialogResult dialogResult = taxRateInput.ShowDialog(this);
                        if (dialogResult == DialogResult.OK)
                        {
                            this.Clear(false, true);
                        }
                        break;
                    }
                // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<
                // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- >>>>
                // 仕入データ取込
                case ctTOOLBAR_BUTTONTOOL_TEXTDATAINPUT_KEY:
                    {
                        // 取込サブ画面表示
                        MAKON01110UJ stockDataDialog = new MAKON01110UJ();
                        DialogResult dialogResult = stockDataDialog.ShowDialog();

                        // 取込を行う場合
                        if (dialogResult == DialogResult.OK)
                        {
                            GetStockData();
                        }
                        // 取込をキャンセル場合
                        else
                        { 
                            // 無し
                        }
                        break;
                    }
                // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- <<<<
				// デバッグ用
#if DEBUG
				case "LabelTool_LoginTitle":
					{
						break;
					}
# endif
			}
		}

        // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
        /// <summary>
        /// 税率タイトル表示
        /// <param name="stockSlip">仕入データ</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 税率タイトルを設定する。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void DisplayNameSetting2(StockSlip stockSlip)
        {
            // 税率取得の対象は、仕入形式によって変更(仕入：仕入日、入荷：入荷日）
            DateTime targetdate = (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay;
            taxRateSetMaster = this._stockSlipInputInitDataAcs.GetTaxRate(targetdate);

            // 伝票転嫁仕入先、当前伝票の税率≠消費税率設定画面.消費税率の場合、当伝票の税率タイトルは税NN%だと表示する。
            if (taxRateSetMaster != stockSlip.SupplierConsTaxRate  &&
                stockSlip.SuppCTaxLayCd == 0 && stockSlip.SupplierCd != 0)
            {
                this.uLabel_StockPriceConsTaxTotalTitle2.Text = "税(" + (stockSlip.SupplierConsTaxRate * 100).ToString() + "%" + ")";
                this.uLabel_StockPriceConsTaxTotalTitle.Visible = false;
                this.uLabel_StockPriceConsTaxTotalTitle2.Visible = true;
                this.uLabel_StockPriceConsTaxTotalTitle2.SendToBack();
            }
            else
            {
                this.uLabel_StockPriceConsTaxTotalTitle.Visible = true;
                this.uLabel_StockPriceConsTaxTotalTitle2.Visible = false;
            }
        }
        // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<
        // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- >>>>
        /// <summary>
        /// 仕入データ取込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 仕入データ取込処理する。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/06/22</br>
        /// </remarks>
        private void GetStockData()
        {
            // 仕入画面に展開できるデータ
            List<InitDataItem> stockDataList = this._stockSlipInputAcs.StockDataWorkList;
            // 在庫を選択しないエラーデータ
            List<ErrTxtgetWork> errWorkList = new List<ErrTxtgetWork>();

            SFCMN00299CA msgForm = new SFCMN00299CA();

            try
            {
                // 展開できるデータがある場合
                if (stockDataList != null && stockDataList.Count != 0)
                {
                    msgForm.Title = "データ展開中";
                    msgForm.Show();
                    msgForm.Message = "現在、データを展開中です。";

                    // ヘッド情報
                    InitDataItem initDataItemHead = this._stockSlipInputAcs.FirstInitDataForForm;

                    // 拠点コード
                    string sectionCdStr = string.Empty;
                    string sectionNmStr = string.Empty;
                    // 画面にて仕入先と拠点を設定している場合
                    if (this._stockSlipInputAcs.StockSlip.SupplierCd != 0 && !string.IsNullOrEmpty(this._stockSlipInputAcs.StockSlip.StockSectionCd.Trim()))
                    {
                        sectionCdStr = this._stockSlipInputAcs.StockSlip.StockSectionCd.Trim();
                        sectionNmStr = this._stockSlipInputAcs.StockSlip.StockSectionNm.Trim();
                    }

                    // 取込データを画面に展開する前に画面クリア
                    this.Clear(false, true);

                    // 仕入伝票ワーク
                    StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;

                    // 入力区分
                    this.tComboEditor_StockGoodsCd.Value = 0;

                    // 伝票区分
                    int supplierSlipCdInt = 0;
                    if (Int32.TryParse(initDataItemHead.SupplierSlipCd, out supplierSlipCdInt))
                    {
                        stockSlip.SupplierSlipCd = supplierSlipCdInt;
                    }
                    else
                    {
                        // 【仕入】固定
                        stockSlip.SupplierSlipCd = 10;
                    }

                    // 仕入伝票区分
                    stockSlip.SupplierSlipDisplay = stockSlip.SupplierSlipCd;

                    // 入荷日
                    stockSlip.ArrivalGoodsDay = DateTime.ParseExact(initDataItemHead.ArrivalGoodsDay, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                    // 仕入日
                    stockSlip.StockDate = DateTime.ParseExact(initDataItemHead.StockDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);

                    // 仕入先
                    stockSlip.SupplierCd = Convert.ToInt32(initDataItemHead.SupplierCd);

                    // 価格・原価(更新しない)
                    stockSlip.PriceCostUpdtDiv = 0;
                    // 伝票種別(仕入)
                    stockSlip.SupplierFormal = 0;

                    // 東邦車両の場合
                    if (this._stockSlipInputAcs.UserDivForForm == 0)
                    {
                        //伝票番号(相手先伝票番号)
                        stockSlip.PartySaleSlipNum = initDataItemHead.AcceptAnOrderNo;
                    }
                    else
                    {
                        //伝票番号(相手先伝票番号)
                        stockSlip.PartySaleSlipNum = initDataItemHead.SupplierSlipNo;
                    }

                    // 仕入先情報取得
                    Supplier supplier = new Supplier();
                    if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
                    this._supplierAcs.Read(out supplier, this._enterpriseCode, stockSlip.SupplierCd);
                    this._stockSlipInputAcs.DataSettingStockSlip(ref stockSlip, supplier);

                    // 拠点コードのリセット
                    if (!string.IsNullOrEmpty(sectionCdStr))
                    {
                        // 拠点コード
                        stockSlip.StockSectionCd = sectionCdStr;
                        // 拠点名称
                        stockSlip.StockSectionNm = sectionNmStr;
                    }

                    // 仕入担当者コード
                    stockSlip.StockAgentCode = initDataItemHead.StockAgentCode;
                    // 仕入担当者名称
                    stockSlip.StockAgentName = this._stockSlipInputInitDataAcs.GetName_FromEmployee(initDataItemHead.StockAgentCode);

                    //部門
                    int subSectionCode;
                    this._stockSlipInputInitDataAcs.GetSubSection_FromEmployeeDtl(initDataItemHead.StockAgentCode, out subSectionCode);
                    // 部門コード
                    stockSlip.SubSectionCode = subSectionCode;
                    // 部門名称
                    stockSlip.SubSectionName = this._stockSlipInputInitDataAcs.GetName_FromSubSection(subSectionCode);

                    // 仕入データキャッシュ処理
                    this._stockSlipInputAcs.Cache(stockSlip);

                    // 明細行番号
                    int stockRowNo = 0;
                    // 明細行番号リスト
                    List<int> settingStockRowNoList = new List<int>();
                    // メーカーコード
                    int goodsMakerCd = 0;
                    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                    // 品番検索を行う
                    foreach (InitDataItem initData in stockDataList)
                    {
                        // 在庫チェックフラグ
                        bool stockCheck = true;

                        object retObj;

                        // メーカーコード
                        goodsMakerCd = 0;
                        Int32.TryParse(initData.GoodsMakerCd, out goodsMakerCd);

                        // 品番
                        string goodsCode = string.Empty;
                        // 東邦車両の場合
                        if (this._stockSlipInputAcs.UserDivForForm == 0)
                        {
                            goodsCode = initData.GoodsCode;
                        }
                        // 東邦車両以外の場合
                        else
                        {
                            goodsCode = initData.GoodsNo;
                        }

                        // 明細商品検索を行う
                        status = this._stockSlipDetailInput.SearchGoodsAndRemain(goodsCode, string.Empty, goodsMakerCd, true, out retObj);

                        // 商品＆在庫検索
                        switch (status)
                        {
                            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                {
                                    if (retObj != null)
                                    {
                                        // 商品検索
                                        if (retObj is List<GoodsUnitData>)
                                        {
                                            List<GoodsUnitData> goodsUnitDataList = (List<GoodsUnitData>)retObj;
                                            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                                            {
                                                // 仕入単価
                                                double price = 0;
                                                if (double.TryParse(initData.AcceptAnOrderUnCst, out price))
                                                {
                                                    goodsUnitData.GoodsPriceList[0].SalesUnitCost = price;
                                                }
                                                // 倉庫を選択しない場合
                                                if (string.IsNullOrEmpty(goodsUnitData.SelectedWarehouseCode))
                                                {
                                                    stockCheck = false;
                                                }
                                            }
                                            // 倉庫を選択する場合
                                            if (stockCheck)
                                            {
                                                // 明細行番号
                                                stockRowNo++;
                                                // 数量
                                                double shipmentCnt1 = 0;
                                                if (double.TryParse(initData.ShipmentCnt1, out shipmentCnt1))
                                                {
                                                    // グリッドに明細行を追加する
                                                    this._stockSlipInputAcs.StockDetailRowGoodsSettingBasedOnGoodsUnitData(stockRowNo, goodsUnitDataList, out settingStockRowNoList, true, shipmentCnt1, initData);
                                                }
                                            }
                                            else
                                            {
                                                // エラーデータ作成
                                                List<string> errorNote = new List<string>();
                                                errorNote.Add("在庫未登録");

                                                // エラーワーク作成
                                                ErrTxtgetWork errWork = this._stockSlipInputAcs.GetErrTxtWork(initData, errorNote);
                                                errWorkList.Add(errWork);
                                            }
                                        }
                                        // 発注残検索
                                        else if (retObj is OrderListResultWork)
                                        {
                                            List<OrderListResultWork> addOrderListResultWorkList = new List<OrderListResultWork>();
                                            addOrderListResultWorkList.Add((OrderListResultWork)retObj);
                                            int readStatus = this._stockSlipInputAcs.StockDetailRowSettingFromOrderListResultWorkList(stockRowNo, addOrderListResultWorkList, StockSlipInputAcs.WayToDetailExpand.AddUpRemainder, (StockSlipInputAcs.MemoMoveDiv)this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv, out settingStockRowNoList);
                                        }
                                        // 入荷残検索
                                        else if (retObj is StcHisRefDataWork)
                                        {
                                            List<StcHisRefDataWork> addStcHisRefDataWorkList = new List<StcHisRefDataWork>();
                                            addStcHisRefDataWorkList.Add((StcHisRefDataWork)retObj);
                                            this._stockSlipInputAcs.StockDetailRowSettingFromstcHisRefDataWorkList(stockRowNo, addStcHisRefDataWorkList, StockSlipInputAcs.WayToDetailExpand.AddUpRemainder, (StockSlipInputAcs.MemoMoveDiv)this._stockSlipInputInitDataAcs.GetAllDefSet().MemoMoveDiv, out settingStockRowNoList);
                                        }

                                        // 明細グリッド設定処理
                                        this._stockSlipDetailInput.SettingGrid();

                                        if (this._stockSlipInputInitDataAcs.GetAllDefSet().DtlCalcStckCntDsp == 0)
                                        {
                                            // 在庫調整
                                            this._stockSlipInputAcs.StockDetailStockInfoAdjust();
                                        }
                                        else
                                        {
                                            this._stockSlipInputAcs.StockRowNo = stockRowNo;
                                            this._stockSlipInputAcs.HasStockInfo = true;
                                            // 在庫調整
                                            this._stockSlipInputAcs.StockDetailStockInfoAdjust();
                                        }
                                    }

                                    break;
                                }
                            case -1:
                                {
                                    // エラーデータ作成
                                    List<string> errorNote = new List<string>();
                                    errorNote.Add("データ展開失敗");

                                    // エラーワーク作成
                                    ErrTxtgetWork errWork = this._stockSlipInputAcs.GetErrTxtWork(initData, errorNote);
                                    errWorkList.Add(errWork);

                                    break;
                                }
                        }
                    }

                    // 倉庫を選択しないレコードがある場合
                    if (errWorkList.Count != 0)
                    {
                        string exErrMsg = string.Empty;
                        // エラーログに出力
                        this._stockSlipInputAcs.WriteErrorMsg(errWorkList, out exErrMsg);
                    }

                    // 仕入画面にて展開できるデータがある場合
                    if (stockDataList.Count != errWorkList.Count)
                    {
                        // 仕入データクラス→画面格納処理
                        SetDisplay(stockSlip);

                        // 軽減税率設定
                        StockPriceConsTaxTotalTitleSetC(ref stockSlip, stockSlip.StockDate);
                        // 仕入データキャッシュ処理
                        this._stockSlipInputAcs.Cache(stockSlip);

                        // 仕入金額計算処理
                        this._stockSlipDetailInput.CalculationStockPrice();

                        // 仕入金額変更後発生イベント処理
                        this.StockSlipDetailInput_StockPriceChanged(this, new EventArgs(), false);
                    }

                    if (msgForm != null) msgForm.Close();
                }

                // 全件取込成功する場合、取込ファイルを削除する
                if (this._stockSlipInputAcs.ErrorStockCount == 0 && errWorkList.Count == 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        Ct_SpreadSuccess,
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);

                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "取込ファイルを削除しますか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);

                    if (dialogResult == DialogResult.Yes)
                    {
                        File.Delete(this._stockSlipInputAcs.StockFileName);
                    }
                }
                // 展開できないデータがある場合、取込ファイルリーネーム
                else
                {
                    //拡張子
                    string extension = Path.GetExtension(this._stockSlipInputAcs.StockFileName);
                    //ファイル名
                    string newFileName = Path.GetFileNameWithoutExtension(this._stockSlipInputAcs.StockFileName) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                    //ファイルパス
                    string folder = Path.GetDirectoryName(this._stockSlipInputAcs.StockFileName);
                    string newfile = Path.Combine(folder, newFileName);
                    if (File.Exists(this._stockSlipInputAcs.StockFileName))
                    {
                        File.Move(this._stockSlipInputAcs.StockFileName, newfile);
                    }

                    // 在庫未選択のデータがある場合
                    if (errWorkList.Count != 0)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            string.Format(Ct_SpreadFail + "\n" + "{0}", this._stockSlipInputAcs.ErrStockFileName),
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                    }
                    // 在庫未選択のデータがなくて、画面に展開できるデータがある場合
                    else if (stockDataList.Count != 0)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            Ct_SpreadSuccess,
                            0,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                    }
                }
            }
            finally
            {
                if (msgForm != null) msgForm.Close();
            }
        }
        // ------ ADD 2020/06/22 陳艶丹 PMKOBETSU-4017の対応 --------- <<<<
        
		/// <summary>
		/// 在庫検索処理
		/// </summary>
		private void StockSearch()
		{
			this._stockSlipDetailInput.StockSearch();
			if (this.panel_Detail.ContainsFocus)
			{
				
			}
		}

		/// <summary>
		/// 仕入履歴検索処理
		/// </summary>
		private void StockReferenceSearch()
		{
			this._stockSlipDetailInput.StockReferenceSearch();
		}

		/// <summary>
		/// 入荷履歴検索処理
		/// </summary>
		private void ArrivalReferenceSearch()
		{
			if (this.panel_Detail.ContainsFocus)
			{
				this._stockSlipDetailInput.ArrivalReferenceSearch();
			}
		}

		/// <summary>
		/// 発注履歴検索処理
		/// </summary>
		private void OrderReferenceSearch()
		{
			this._stockSlipDetailInput.OrderReferenceSearch();
		}

		/// <summary>
		/// 売上登録処理
		/// </summary>
		private void SalesEntry()
		{
			DCKOU01080UA salesEntry = new DCKOU01080UA();

			//salesEntry.IsPrintSalesSlip = ( this._stockInputConstructionAcs.PrtSalesSlipValue == 1 ) ? true : false;
			//salesEntry.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;
			salesEntry.ShowGuide(this);
		}

		/// <summary>
		/// 総額表示方式コンボボックス選択値変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_SuppTtlAmntDspWayCd_SelectionChangeCommitted(object sender, EventArgs e)
		{
            int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_SuppTtlAmntDspWayCd, ComboEditorGetDataType.VALUE);
            this._stockSlipInputAcs.StockSlip.SuppTtlAmntDspWayCd = code;

            // 仕入明細データセッティング処理（課税区分設定）
            this._stockSlipInputAcs.StockDetailRowTaxationCodeSetting(this._stockSlipInputAcs.StockSlip.SuppCTaxLayCd, code);

			// 仕入金額計算処理
			this._stockSlipDetailInput.CalculationStockPrice();

			// 仕入金額変更後発生イベント処理
			this.StockSlipDetailInput_StockPriceChanged(this, new EventArgs());

			// 仕入データクラス→画面格納処理
			this.SetDisplay(this._stockSlipInputAcs.StockSlip);

			// 明細グリッドセル設定処理
			this._stockSlipDetailInput.SettingGrid();
		}

		/// <summary>
		/// 仕入先名称ラベルマウスエンターイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uLabel_CustomerName_MouseEnter(object sender, EventArgs e)
		{
			if (this.tNedit_SupplierCd.GetInt() == 0) return;

			//CustomerInfo customerInfo;
			//int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, this.tNedit_CustomerCode.GetInt());

			//if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			//{
			//    this.uLabel_CustomerName.Cursor = Cursors.Help;

			//    StringBuilder tipString = new StringBuilder();

			//    int totalWidth = 4;

			//    // セパレータ
			//    //tipString = tipString.Append("　");

			//    // 得意先名称
			//    tipString = tipString.Append("名称".PadRight(totalWidth, '　') + "：" + customerInfo.Name + " " + customerInfo.Name2);

			//    // カナ
			//    tipString = tipString.Append("\r\n" + "カナ".PadRight(totalWidth, '　') + "：" + customerInfo.Kana);

			//    // コード
			//    tipString = tipString.Append("\r\n" + "コード".PadRight(totalWidth, '　') + "：" + customerInfo.CustomerCode.ToString());

			//    // 電話番号
			//    switch (customerInfo.MainContactCode)
			//    {
			//        case 0:
			//        {
			//            tipString = tipString.Append("\r\n" + "電話番号".PadRight(totalWidth, '　') + "：" + customerInfo.HomeTelNo);
			//            break;
			//        }
			//        case 1:
			//        {
			//            tipString = tipString.Append("\r\n" + "電話番号".PadRight(totalWidth, '　') + "：" + customerInfo.OfficeTelNo);
			//            break;
			//        }
			//        case 2:
			//        {
			//            tipString = tipString.Append("\r\n" + "電話番号".PadRight(totalWidth, '　') + "：" + customerInfo.PortableTelNo);
			//            break;
			//        }
			//        case 3:
			//        {
			//            tipString = tipString.Append("\r\n" + "電話番号".PadRight(totalWidth, '　') + "：" + customerInfo.HomeFaxNo);
			//            break;
			//        }
			//        case 4:
			//        {
			//            tipString = tipString.Append("\r\n" + "電話番号".PadRight(totalWidth, '　') + "：" + customerInfo.OfficeFaxNo);
			//            break;
			//        }
			//        case 5:
			//        {
			//            tipString = tipString.Append("\r\n" + "電話番号".PadRight(totalWidth, '　') + "：" + customerInfo.OthersTelNo);
			//            break;
			//        }
			//    }

			//    CustomerInfo payee;
			//    status = this._customerInfoAcs.ReadStaticMemoryData(out payee, this._enterpriseCode, this.tNedit_CustomerCode.GetInt());

			//    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			//    {
			//        // セパレータ
			//        tipString = tipString.Append("\r\n" + "　");

			//        // 支払先名
			//        tipString = tipString.Append("\r\n" + "支払先".PadRight(totalWidth, '　') + "：" + payee.Name + " " + payee.Name2);
			//    }

			//    Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
			//    ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
			//    ultraToolTipInfo.ToolTipTitle = "仕入先情報";
			//    ultraToolTipInfo.ToolTipText = tipString.ToString();

			//    this.uToolTipManager_Information.Appearance.FontData.Name = "ＭＳ ゴシック";
			//    this.uToolTipManager_Information.SetUltraToolTip(this.uLabel_CustomerName, ultraToolTipInfo);
			//    this.uToolTipManager_Information.Enabled = true;
			//}

			Supplier supplier;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
			int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, this.tNedit_SupplierCd.GetInt());

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.uLabel_SupplierName.Cursor = Cursors.Help;

				StringBuilder tipString = new StringBuilder();

				int totalWidth = 4;

				// セパレータ
				//tipString = tipString.Append("　");

				// 得意先名称
				tipString = tipString.Append("名称".PadRight(totalWidth, '　') + "：" + supplier.SupplierNm1 + " " + supplier.SupplierNm2);

				// カナ
				tipString = tipString.Append("\r\n" + "カナ".PadRight(totalWidth, '　') + "：" + supplier.SupplierKana);

				// コード
				tipString = tipString.Append("\r\n" + "コード".PadRight(totalWidth, '　') + "：" + supplier.SupplierCd.ToString());

				// 電話番号
				tipString = tipString.Append("\r\n" + "電話番号".PadRight(totalWidth, '　') + "：" + supplier.SupplierTelNo);

				// セパレータ
				tipString = tipString.Append("\r\n" + "　");

				// 支払先名
				tipString = tipString.Append("\r\n" + "支払先".PadRight(totalWidth, '　') + "：" + supplier.PayeeName + " " + supplier.PayeeName2);

				Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
				ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
				ultraToolTipInfo.ToolTipTitle = "仕入先情報";
				ultraToolTipInfo.ToolTipText = tipString.ToString();

				this.uToolTipManager_Information.Appearance.FontData.Name = "ＭＳ ゴシック";
				this.uToolTipManager_Information.SetUltraToolTip(this.uLabel_SupplierName, ultraToolTipInfo);
				this.uToolTipManager_Information.Enabled = true;
			}
		}

		/// <summary>
		/// 仕入先名称ラベルマウスリーヴイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uLabel_CustomerName_MouseLeave(object sender, EventArgs e)
		{
			this.uToolTipManager_Information.Enabled = false;
			this.uLabel_SupplierName.Cursor = Cursors.Default;
		}

		/// <summary>
		/// コンボボックスツール値変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tToolbarsManager_MainMenu_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
		{
		}

        /// <summary>
        /// 伝票区分コンボエディタ選択確定後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tComboEditor_SupplierSlipDisplay_SelectionChangeCommitted( object sender, EventArgs e )
        {
			StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;

			this.ChageSupplierSlipDisplay(ref stockSlip, true);

			// 明細グリッドセル設定処理
			this._stockSlipDetailInput.SettingGrid();
        }

		/// <summary>
		/// 商品区分コンボエディタ選択確定後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_StockGoodsCd_SelectionChangeCommitted(object sender, EventArgs e)
		{
			StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;
			this.ChangeStockGoodsCd(ref stockSlip, true);

            // 明細グリッドセル設定処理
			this._stockSlipDetailInput.SettingGrid();
        }

		/// <summary>
		/// 定価・原価更新コンボエディタ選択値変更確定後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_PriceCostUpdtDiv_SelectionChangeCommitted( object sender, EventArgs e )
		{
			StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;

			this.ChangePriceCostUpdtDiv(ref stockSlip, true);

			// 仕入データクラス→画面格納処理
			this.SetDisplay(stockSlip);		
		}
		
		/// <summary>
		/// 仕入形式コンボエディタ選択値変更確定後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_SupplierFormal_SelectionChangeCommitted(object sender, EventArgs e)
		{
			StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;

			// 仕入形式変更処理
			this.ChageSupplierFormal(ref stockSlip, true);

			// 明細グリッドセル設定処理
			this._stockSlipDetailInput.SettingGrid();
		}

		/// <summary>
		/// 伝票区分コンボエディタ選択値変更確定後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_SupplierSlipCd_SelectionChangeCommitted(object sender, EventArgs e)
		{
			StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;

			bool changeSupplierSlipCd = false;

			int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_SupplierSlipCd, ComboEditorGetDataType.TAG);

			if (stockSlip.SupplierSlipCd != code)
			{
				if (code != -1)
				{
					if (( !this.EqualsStockGoodsCdType(stockSlip.StockGoodsCd, code) ) && ( this._stockSlipInputAcs.ExistStockDetailData() ))
					{
						DialogResult dialogResult = TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							this._stockSlipInputAcs.GetSupplierFormalName(this._stockSlipInputAcs.StockSlip) + "明細情報がクリアされます。" + "\r\n" + "\r\n" +
							"よろしいですか？",
							0,
							MessageBoxButtons.YesNo,
							MessageBoxDefaultButton.Button1);

						if (dialogResult == DialogResult.Yes)
						{
							this._stockSlipDetailInput.Clear();
							changeSupplierSlipCd = true;
						}
					}
					else
					{
						changeSupplierSlipCd = true;
					}
				}
			}

			if (changeSupplierSlipCd)
			{
				stockSlip.SupplierSlipCd = code;

				// 仕入データキャッシュ処理
				this._stockSlipInputAcs.Cache(stockSlip);
			}

			// 仕入データクラス→画面格納処理
			this.SetDisplay(stockSlip);

			// 明細グリッドセル設定処理
			this._stockSlipDetailInput.SettingGrid();
		}

		/// <summary>
		/// 買掛区分コンボエディタ選択値変更確定後イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tComboEditor_AccPayDivCd_SelectionChangeCommitted(object sender, EventArgs e)
		{
			StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;

			int code = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_AccPayDivCd, ComboEditorGetDataType.TAG);

			if (stockSlip.AccPayDivCd != code)
			{
				stockSlip.AccPayDivCd = code;

				// 仕入データキャッシュ処理
				this._stockSlipInputAcs.Cache(stockSlip);
			}

			// 仕入データクラス→画面格納処理
			this.SetDisplay(stockSlip);

			// 明細グリッドセル設定処理
			this._stockSlipDetailInput.SettingGrid();
		}

		/// <summary>
		/// 仕入伝票ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Update Note: 2011/12/15 tianjw</br>
        /// <br>             Redmine#27390 拠点管理/売上日のチェック</br>
        /// <br>Update Note: 2020/02/24 田建委</br>
        /// <br>管理番号   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912消費税税率機能追加対応</br>
        /// </remarks>
		private void uButton_SupplierSlipGuide_Click(object sender, EventArgs e)
		{
			MAKON01320UA supplierSlipGuide = new MAKON01320UA();
            supplierSlipGuide.SectionCode = this._stockSlipInputAcs.StockSlip.StockSectionCd;
            supplierSlipGuide.SectionName = this._stockSlipInputAcs.StockSlip.StockSectionNm;

			DialogResult result = supplierSlipGuide.ShowDialog(this, this._stockSlipInputAcs.StockSlip.SupplierFormal);

			if (result == DialogResult.OK)
			{
				SearchRetStockSlip searchRetStockSlip = supplierSlipGuide.searchRetStockSlip;

				if (searchRetStockSlip != null)
				{
					DialogResult dialogResult = DialogResult.Yes;

					if (this._stockSlipInputAcs.IsDataChanged)
					{
						dialogResult = TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							"入力中の" + this._stockSlipInputAcs.GetSupplierFormalName(this._stockSlipInputAcs.StockSlip) + "情報がクリアされます。" + "\r\n" + "\r\n" +
							"よろしいですか？",
							0,
							MessageBoxButtons.YesNo,
							MessageBoxDefaultButton.Button1);
					}

					if (dialogResult == DialogResult.Yes)
					{
						this.tEdit_StockAgentCode.Focus();

						// 画面初期化処理
						this.Clear(false, false);

                        StockSlip baseStockSlip; // 2009.03.25

						// データリード処理
						this.Cursor = Cursors.WaitCursor;
                        //int status = this._stockSlipInputAcs.ReadDBData(searchRetStockSlip.EnterpriseCode, searchRetStockSlip.SupplierFormal, searchRetStockSlip.SupplierSlipNo); // 2009.03.25
                        int status = this._stockSlipInputAcs.ReadDBData(searchRetStockSlip.EnterpriseCode, searchRetStockSlip.SupplierFormal, searchRetStockSlip.SupplierSlipNo, out baseStockSlip); // 2009.03.25
                        this.Cursor = Cursors.Default;

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							StockSlip stockSlip = this._stockSlipInputAcs.StockSlip.Clone();
                            stockSlip.PreStockDate = stockSlip.StockDate; // ADD 2011/12/15

                            // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
                            ShowMessage(stockSlip, stockSlip.SupplierConsTaxRate);
                            slipSrcTaxFlg = false;
                            // 税率取得の対象は、仕入形式によって変更(仕入：仕入日、入荷：入荷日）
                            DateTime targetdate = (stockSlip.SupplierFormal == 0) ? stockSlip.StockDate : stockSlip.ArrivalGoodsDay;
                            taxRateSetMaster = this._stockSlipInputInitDataAcs.GetTaxRate(targetdate);
                            if (stockSlip.SupplierConsTaxRate != taxRateSetMaster)
                            {
                                // 伝票呼出軽減税率フラグ
                                slipSrcTaxFlg = true;

                            }
                            // -----ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<

							// 仕入データ入力モード設定処理
							this.SettingStockSlipInputMode(ref stockSlip);

                            // 表示用伝票区分の設定
                            StockSlipInputAcs.SetDisplayFromSlipCdAndAccPayDivCd(ref stockSlip);

							// 仕入データクラス→画面格納処理
							this.SetDisplay(stockSlip);

							// 仕入データキャッシュ処理
							this._stockSlipInputAcs.Cache(stockSlip);

                            // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            if (baseStockSlip.SuppCTaxLayCd != stockSlip.SuppCTaxLayCd)
                            {
                                // 仕入金額計算処理
                                this._stockSlipDetailInput.CalculationStockPrice();

                                // 仕入金額変更後発生イベント処理
                                this.StockSlipDetailInput_StockPriceChanged(this, new EventArgs());
                            }
                            // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

							// 入荷計上伝票、赤伝の場合は空白行を削除する
							if (( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ArrivalAddUp ) || ( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red ))
							{
								this._stockSlipDetailInput.DeleteEmptyRow(true);
							}

							//this._stockSlipInputAcs.StockDetailRowTaxationCodeSetting(stockSlip.SuppTtlAmntDspWayCd);

							// 明細グリッド設定処理
							this._stockSlipDetailInput.SettingGrid();

							// ツールバーボタン有効無効設定処理
							this.SettingToolBarButtonEnabled();
							this.SettingToolBarButtonEnabled_Detail();
                            DisplayNameSetting2(stockSlip);// ADD 田建委 2020/02/24 PMKOBETSU-2912の対応

							if (( this._stockSlipDetailInput.Enabled ) && ( stockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red ))
							{
								this._stockSlipDetailInput.Focus();

							}
							else
							{	
								//this.tEdit_SupplierSlipNote1.Focus();  //DEL 2011/11/30 gezh redmine#8383
                                this.tNedit_SupplierSlipNote1.Focus();   //ADD 2011/11/30 gezh redmine#8383
							}
						}
						else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
						{
							TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_INFO,
								this.Name,
								"該当するデータが存在しません。",
								-1,
								MessageBoxButtons.OK);

							return;
						}
						else
						{
							TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_STOPDISP,
								this.Name,
								"仕入・入荷データの取得に失敗しました。",
								status,
								MessageBoxButtons.OK);

							return;
						}
					}
				}
			}
			this._stockSlipDetailInput.SettingFooterEventCall();

			this._prevControl = this.GetActiveControl();
		}

		/// <summary>
		/// 拠点ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        private void uButton_SectionGuide_Click( object sender, EventArgs e )
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;

            bool reCalcStockUnitPrice = false;
            bool clearRateInfo = false;

            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;

                if (stockSlip.SectionCode.Trim() != secInfoSet.SectionCode.Trim())
                {
                    if (this._stockSlipInputAcs.ExistStockDetailCanGoodsPriceReSettingData())
                    {
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "拠点が変更されました。" + "\r\n" + "\r\n" +
                            "商品価格を再取得しますか？",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                        if (dialogResult == DialogResult.Yes)
                        {
                            reCalcStockUnitPrice = true;
                        }
                        else
                        {
                            clearRateInfo = true;
                        }
                    }

                    stockSlip.StockSectionCd = secInfoSet.SectionCode;
                    stockSlip.StockSectionNm = secInfoSet.SectionGuideNm;
                }

                // 売上データクラス→画面格納処理
                this.SetDisplay(stockSlip);

                // 売上データキャッシュ処理
                this._stockSlipInputAcs.Cache(stockSlip);

                if (reCalcStockUnitPrice)
                {
                    this._stockSlipInputAcs.StockDetailTableGoodsPriceReSetting();
                }

                if (clearRateInfo)
                {
                    this._stockSlipInputAcs.StockDetailTableClearRateInfo();
                }

                this._stockSlipDetailInput.SettingFooterEventCall();

                // 次の項目へフォーカス移動
                Control nextCtrl = this.GetNextControl(this.tEdit_SectionCode, StockSlipInputAcs.MoveMethod.NextMove);
                if (nextCtrl != null)
                {
                    nextCtrl.Focus();
                    this._prevControl = nextCtrl;
                    this.SettingGuideButtonToolEnabled(nextCtrl);
                }
            }
        }

		/// <summary>
		/// 部門ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_SubSectionGuide_Click( object sender, EventArgs e )
		{
			SubSectionAcs subSectionAcs = new SubSectionAcs();
			SubSection subSection;

			int status = subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;

				if (stockSlip.SubSectionCode != subSection.SubSectionCode)
				{
					stockSlip.SubSectionCode = subSection.SubSectionCode;
					stockSlip.SubSectionName = subSection.SubSectionName;
				}

				// 売上データクラス→画面格納処理
				this.SetDisplay(stockSlip);

				// 売上データキャッシュ処理
				this._stockSlipInputAcs.Cache(stockSlip);

				this._stockSlipDetailInput.SettingFooterEventCall();

                // 次の項目へフォーカス移動
                Control nextCtrl = this.GetNextControl(this.tNedit_SubSectionCode, StockSlipInputAcs.MoveMethod.NextMove);
                if (nextCtrl != null)
                {
                    nextCtrl.Focus();
                    this._prevControl = nextCtrl;
                    this.SettingGuideButtonToolEnabled(nextCtrl);

                }
            }
		}

		/// <summary>
		/// 従業員ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_EmployeeGuide_Click(object sender, EventArgs e)
		{
			EmployeeAcs employeeAcs = new EmployeeAcs();
			//employeeAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;
			Employee employee;
			int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;

				if (stockSlip.StockAgentCode != employee.EmployeeCode.Trim())
				{
					stockSlip.StockAgentCode = employee.EmployeeCode.Trim();
					stockSlip.StockAgentName = employee.Name.Trim();
					if (stockSlip.StockAgentName.Length > 16)
					{
						stockSlip.StockAgentName = stockSlip.StockAgentName.Substring(0, 16);
					}

					this._stockSlipInputAcs.StockAgentBelongInfoSetting(ref stockSlip);
				}

				// 仕入データクラス→画面格納処理
				this.SetDisplay(stockSlip);

				// 仕入データキャッシュ処理
				this._stockSlipInputAcs.Cache(stockSlip);

				this._stockSlipDetailInput.SettingFooterEventCall();

                // 次の項目へフォーカス移動
                Control nextCtrl = this.GetNextControl(this.tEdit_StockAgentCode, StockSlipInputAcs.MoveMethod.NextMove);
                if (nextCtrl != null)
                {
                    nextCtrl.Focus();
                    this._prevControl = nextCtrl;
                    this.SettingGuideButtonToolEnabled(nextCtrl);

                }
            }
		}

		/// <summary>
		/// 仕入先ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_SupplierGuide_Click(object sender, EventArgs e)
		{
			Supplier retSupplier;
            if (this._supplierAcs == null) this._supplierAcs = new SupplierAcs();
			int status = this._supplierAcs.ExecuteGuid(out retSupplier, this._enterpriseCode, this._stockSlipInputInitDataAcs.OwnSectionCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SettingSupplier(false, retSupplier);

                // 次の項目へフォーカス移動
                Control nextCtrl = this.GetNextControl(this.tNedit_SupplierCd, StockSlipInputAcs.MoveMethod.NextMove);
                if (nextCtrl != null)
                {
                    nextCtrl.Focus();
                    this._prevControl = nextCtrl;
                    this.SettingGuideButtonToolEnabled(nextCtrl);

                }
            }
		}

		/// <summary>
		/// 倉庫ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_WarehouseGuide_Click(object sender, EventArgs e)
		{
			StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;
			WarehouseAcs warehouseAcs = new WarehouseAcs();
			Warehouse warehouse;

			int status = warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode, stockSlip.SectionCode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				stockSlip.WarehouseCode = warehouse.WarehouseCode.Trim();
				stockSlip.WarehouseName = warehouse.WarehouseName;

				// 仕入データクラス→画面格納処理
				this.SetDisplay(stockSlip);

				// 仕入データキャッシュ処理
				this._stockSlipInputAcs.Cache(stockSlip);

				this._stockSlipDetailInput.SettingFooterEventCall();

                // 次の項目へフォーカス移動
                Control nextCtrl = this.GetNextControl(this.tEdit_WarehouseCode, StockSlipInputAcs.MoveMethod.NextMove);
                if (nextCtrl != null)
                {
                    nextCtrl.Focus();
                    this._prevControl = nextCtrl;
                    this.SettingGuideButtonToolEnabled(nextCtrl);

                }
			}
		}

        /// <summary>
        /// 支払先確認ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
		private void uButton_PaymentConfirmation_Click( object sender, EventArgs e )
		{
			StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;

			if (stockSlip.SupplierCd == 0)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"仕入先が入力されていません。",
					-1,
					MessageBoxButtons.OK);

				return;
			}

			DCKOU01050UA demandConfirm = new DCKOU01050UA();
			//demandConfirm.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;

			bool payeeReadOnly = false;
			bool addUpDateReadOnly = false;
			if (( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red ))
			{
				payeeReadOnly = true;
			}
			if (( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ))
			{
				payeeReadOnly = true;
				addUpDateReadOnly = true;
			}

			demandConfirm.IsReadOnlyPayee = payeeReadOnly;
			demandConfirm.IsReadOnlyAddUpDate = addUpDateReadOnly;

			DialogResult dialogResult = demandConfirm.ShowDialog(this, this._stockSlipInputAcs.StockSlip.PayeeCode, this._stockSlipInputAcs.StockSlip.StockAddUpSectionCd, this._stockSlipInputAcs.StockSlip.StockDate, this._stockSlipInputAcs.StockSlip.StockAddUpADate, this._stockSlipInputAcs.StockSlip.DelayPaymentDiv, CustomerClaimConfAcs.GuideType.Payment);

			if (dialogResult == DialogResult.OK)
			{
				CustomerClaimConf retCustomerClaimConf = demandConfirm.CustomerClaimConf;
				stockSlip.PayeeCode = retCustomerClaimConf.CustomerCode;
				stockSlip.PayeeSnm = retCustomerClaimConf.CustomerSnm;
				stockSlip.DelayPaymentDiv = retCustomerClaimConf.CollectMoneyCode;
				stockSlip.NTimeCalcStDate = retCustomerClaimConf.NTimeCalcStDate;
				stockSlip.PaymentTotalDay = retCustomerClaimConf.TotalDay;

				bool reCalcStockPrice = false;
				bool adjustStockUnitPrice = false;

                if (( stockSlip.SuppTtlAmntDspWayCd != retCustomerClaimConf.TotalAmountDispWayCd ) || ( stockSlip.SuppCTaxLayCd != retCustomerClaimConf.ConsTaxLayMethod ))
				{
					// 仕入明細データセッティング処理（課税区分設定）
                    this._stockSlipInputAcs.StockDetailRowTaxationCodeSetting(retCustomerClaimConf.ConsTaxLayMethod, retCustomerClaimConf.TotalAmountDispWayCd);

					reCalcStockPrice = true;
				}

                stockSlip.SuppCTaxLayCd = retCustomerClaimConf.ConsTaxLayMethod;
                stockSlip.StockAddUpADate = retCustomerClaimConf.AddUpADate;
				stockSlip.SuppTtlAmntDspWayCd = retCustomerClaimConf.TotalAmountDispWayCd;

				// 仕入データクラス→画面格納処理
				this.SetDisplay(stockSlip);

				if (adjustStockUnitPrice)
				{
					// 仕入明細データセッティング処理（単価調整）
					this._stockSlipInputAcs.StockDetailRowPriceAdjust();

					// 仕入金額変更後発生イベント処理
					this.StockSlipDetailInput_StockPriceChanged(this, new EventArgs());
				}

				if (reCalcStockPrice)
				{
					// 仕入金額計算処理
					this._stockSlipDetailInput.CalculationStockPrice();

					// 仕入金額変更後発生イベント処理
					this.StockSlipDetailInput_StockPriceChanged(this, new EventArgs());
				}

			}
		}

        /// <summary>
        /// 伝票備考ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_SlipNote_Click( object sender, EventArgs e )
        {
            if (( sender != uButton_SlipNote1 ) && ( sender != uButton_SlipNote2 )) return;

            NoteGuidAcs noteGuidAcs = new NoteGuidAcs();
            NoteGuidBd noteGuidBd;

            int noteGuideDivCode = ( sender == uButton_SlipNote1 ) ? StockSlipInputInitDataAcs.ctDIVCODE_NoteGuid_StockSlipNote1 : StockSlipInputInitDataAcs.ctDIVCODE_NoteGuid_StockSlipNote2;

            if (noteGuidAcs.ExecuteGuide(out noteGuidBd, this._enterpriseCode, noteGuideDivCode) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;

                if(sender == uButton_SlipNote1)
                {
                    stockSlip.SupplierSlipNote1 = noteGuidBd.NoteGuideName;
                    stockSlip.SupplierSlipNoteNo1 = noteGuidBd.NoteGuideCode;  // ADD 2011/11/30 gezh redmine#8383
                    if (stockSlip.SupplierSlipNote1.Length > 30)
                    {
                        stockSlip.SupplierSlipNote1 = stockSlip.SupplierSlipNote1.Substring(0, 30);
                    }
                }
                else 
                {
                    stockSlip.SupplierSlipNote2 = noteGuidBd.NoteGuideName;
                    stockSlip.SupplierSlipNoteNo2 = noteGuidBd.NoteGuideCode;  // ADD 2011/11/30 gezh redmine#8383
                    if (stockSlip.SupplierSlipNote2.Length > 30)
                    {
                        stockSlip.SupplierSlipNote2 = stockSlip.SupplierSlipNote2.Substring(0, 30);
                    }
                }

                // 仕入データクラス→画面格納処理
                this.SetDisplay(stockSlip);

                // 仕入データキャッシュ処理
                this._stockSlipInputAcs.Cache(stockSlip);

                // 次の項目へフォーカス移動
                if (sender is Control)
                {
                    Control nextCtrl = (Control)sender;
                    if (sender == this.uButton_SlipNote1)
                    {
                        //nextCtrl = this.tEdit_SupplierSlipNote2;  //DEL 2011/11/30 gezh redmine#8383
                        nextCtrl = this.tEdit_SupplierSlipNote1;   //ADD 2011/11/30 gezh redmine#8383
                    }
                    else
                    {
                        if (( this.tEdit_RetGoodsReason.Visible ) && ( this.tEdit_RetGoodsReason.Enabled ))
                        {
                            nextCtrl = this.tEdit_RetGoodsReason;
                        }
                        // ADD 2011/11/30 gezh redmine#8383 --------->>>>>
                        else
                        {
                            nextCtrl = this.tEdit_SupplierSlipNote2;
                        }
                        // ADD 2011/11/30 gezh redmine#8383 ---------<<<<<
                    }
                    if (nextCtrl != null)
                    {
                        nextCtrl.Focus();
                        this._prevControl = nextCtrl;
                        this.SettingGuideButtonToolEnabled(nextCtrl);
                    }
                }
            }
        }

        /// <summary>
        /// 返品理由ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_RetGoodsReason_Click(object sender, EventArgs e)
        {
            UserGuideAcs userGuideAcs = new UserGuideAcs();
            UserGdHd userGdHd;
            UserGdBd userGdBd;

            if (userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, StockSlipInputInitDataAcs.ctDIVCODE_UserGuideDivCd_RetGoodsReason) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;

                stockSlip.RetGoodsReasonDiv = userGdBd.GuideCode;
                stockSlip.RetGoodsReason = userGdBd.GuideName;
                if (stockSlip.RetGoodsReason.Length > 100)
                {
                    stockSlip.RetGoodsReason = stockSlip.RetGoodsReason.Substring(0, 100);
                }

                // 仕入データクラス→画面格納処理
                this.SetDisplay(stockSlip);

                // 仕入データキャッシュ処理
                this._stockSlipInputAcs.Cache(stockSlip);

                // 次の項目へフォーカス移動
                if (sender is Control)
                {
                    // 次の項目へフォーカス移動
                    Control nextCtrl = this.GetNextControl(this.tEdit_RetGoodsReason, StockSlipInputAcs.MoveMethod.NextMove);
                    if (nextCtrl != null)
                    {
                        nextCtrl.Focus();
                        this._prevControl = nextCtrl;
                        this.SettingGuideButtonToolEnabled(nextCtrl);
                    }
                }
            }
        }

        /// <summary>
        /// 金額再計算イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="s">イベントパラメータクラス</param>
        private void CalculationStockPrice( object sender, EventArgs s )
        {
            // 仕入金額計算処理
            this._stockSlipDetailInput.CalculationStockPrice();
		}

		#region 伝票メモ関連の処理
		/// <summary>
        /// 伝票メモ情報設定処理
        /// </summary>
        private void SetSlipMemo()
        {
			StockInputDataSet.StockDetailRow row = this._stockSlipInputAcs.GetStockDetailRow(this._stockSlipDetailInput.GetActiveRowStockRowNo());

			if (row != null)
			{
				row.SlipMemo1 = tEdit_SlipMemo1.Text;
				row.SlipMemo2 = tEdit_SlipMemo2.Text;
				row.SlipMemo3 = tEdit_SlipMemo3.Text;

				row.InsideMemo1 = tEdit_InsideMemo1.Text;
				row.InsideMemo2 = tEdit_InsideMemo2.Text;
				row.InsideMemo3 = tEdit_InsideMemo3.Text;
			}
        }

        /// <summary>
        /// 伝票メモデータ表示処理（オーバーロード）
        /// </summary>
        private void SlipMemoInfoFormSetting()
        {
            int dispRowNo = this._stockSlipDetailInput.GetActiveRowStockRowNo();

            if (dispRowNo < 0)
            {
                MemoInputSetting(false);
            }
            else
            {
                SlipMemoInfoFormSetting(dispRowNo);
            }
        }

        /// <summary>
		/// 伝票メモデータ表示処理（オーバーロード）
        /// </summary>
        /// <param name="stockRow">対象行</param>
        private void SlipMemoInfoFormSetting( int stockRow )
        {
            try
            {


                ComponentBlanketControl.BeginUpdate(this._memoControlList);

				StockInputDataSet.StockDetailRow row = this._stockSlipInputAcs.GetStockDetailRow(stockRow);
				bool input = false;

                if (( row != null ) && ( this._stockSlipInputAcs.ExistStockDetailInput(row) ))
				{
					input = true;
					this.tEdit_SlipMemo1.Text = row.SlipMemo1;
					this.tEdit_SlipMemo2.Text = row.SlipMemo2;
					this.tEdit_SlipMemo3.Text = row.SlipMemo3;
					this.tEdit_InsideMemo1.Text = row.InsideMemo1;
					this.tEdit_InsideMemo2.Text = row.InsideMemo2;
					this.tEdit_InsideMemo3.Text = row.InsideMemo3;
				}
				MemoInputSetting(input);
			}
            finally
            {
				ComponentBlanketControl.EndUpdate(this._memoControlList);
            }
       }

        /// <summary>
        /// メモ入力設定
        /// </summary>
        /// <param name="input">入力可否</param>
        private void MemoInputSetting( bool input )
        {
			ComponentBlanketControl.SetEnabled(this._memoControlList, input);
            if (!input) this.ClearMemoInfo();
        }

        /// <summary>
        /// 伝票メモクリア処理
        /// </summary>
        private void ClearMemoInfo()
        {
			ComponentBlanketControl.Clear(this._memoControlList);
		}
		#endregion

		#region 売上同時入力関連

		///// <summary>
		///// 売上データ(仕入同時計上)設定処理
		///// </summary>
		///// <param name="stockRowNo"></param>
		//private void SettingSalesTempInfo( int stockRowNo )
		//{
		//    StockInputDataSet.StockDetailRow row = this._stockSlipInputAcs.GetStockDetailRow(stockRowNo);

		//    if (( row == null ) ||
		//        ( row.StockSlipCdDtl == 2 ) ||
		//        ( this._stockSlipInputAcs.StockSlip.SupplierSlipCd == 20 ) ||
		//        ( this._stockSlipInputAcs.StockSlip.StockGoodsCd != 0 ) ||
		//        ( ( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red ) ||
		//        ( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Return ) ))
		//    {
		//        this.uTab_SalesInfo.Enabled = false;
		//    }
		//    else
		//    {
		//        this.uTab_SalesInfo.Enabled = true;
		//        this._stockSlipInputAcs.SettingSalesTempInfo(stockRowNo);
		//    }

		//    if (this.Footer_UTabControl.SelectedTab.Key == MAKON01110UH.ctTAB_KEY_SalesInfo)
		//    {
		//        this._salesTempInput.SettingConfirmedDiv(true);
		//    }
		//}
		#endregion

		/// <summary>
		/// クローズタイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_Close_Tick(object sender, EventArgs e)
		{
			this.timer_Close.Enabled = false;
			this.Close();
		}

		/// <summary>
		/// フッター選択タブ変更時発生イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Footer_UTabControl_SelectedTabChanged( object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e )
		{
			if (this.TabChanged != null)
			{
				this.timer_FooterSetFocus.Enabled = true;
			}
		}

		/// <summary>
		/// フッタータブフォーカスセットタイマー起動イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer_FooterSetFocus_Tick( object sender, EventArgs e )
		{
			this.timer_FooterSetFocus.Enabled = false;
			this.TabChanged(sender, this.uTabControl_Footer.SelectedTab.Key);
		}

        // 2009.03.31 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// uButton_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // ボタンは隠れてます
            DialogResult dResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "終了してもよろしいですか？",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            if (dResult == DialogResult.Yes)
            {
                this.Close(true);
            }
        }
        // 2009.03.31 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        # endregion

		/// <summary>
		/// 消費税合計 設定処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tNedit_StockPriceConsTaxTotal_Enter( object sender, EventArgs e )
		{
			StockSlip stockSlip = this._stockSlipInputAcs.StockSlip.Clone();
            int sign = ( stockSlip.SupplierSlipCd == 20 ) ? -1 : 1;
            this.tNedit_StockPriceConsTaxTotal.SetValue(stockSlip.StockPriceConsTax * sign);
            this.tNedit_StockPriceConsTaxTotal.DataText = ( stockSlip.StockPriceConsTax * sign ).ToString("N0");
            this.tNedit_StockPriceConsTaxTotal.Text = ( stockSlip.StockPriceConsTax * sign ).ToString("N0");
        }

        /* 2011/08/03 wangf del for redMine#23375 start
        // 2011.07.25 wangf add start
        /// <summary>
        /// 伝票番号コンポーネントフォーカスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : 伝票番号コンポーネントフォーカスイベントを行う</br>
        /// <br>Programmer  : wangf</br>
        /// <br>Date        : 2011.07.25</br>
        /// </remarks>
        private void tEdit_PartySaleSlipNum_KeyUp(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.Right:
            //        if (string.Empty.Equals(this.tEdit_PartySaleSlipNum.Text.Trim()))
            //        {
            //            // 入力チェック
            //            TMsgDisp.Show(
            //                this, 								                         // 親ウィンドウフォーム
            //                emErrorLevel.ERR_LEVEL_EXCLAMATION,                          // エラーレベル
            //                this.Name, 						                             // アセンブリＩＤまたはクラスＩＤ
            //                this.uLabel_PartySaleSlipNumTitle.Text + MUSTINPUTERROR, 	 // 表示するメッセージ
            //                0, 									                         // ステータス値
            //                MessageBoxButtons.OK);				                         // 表示するボタン
            //            e.NextCtrl = tEdit_PartySaleSlipNum;
            //            return;
            //        }
            //        else
            //        {

            //        }
            //        break;
            //}
        }

        private void tEdit_PartySaleSlipNum_KeyDown(object sender, KeyEventArgs e)
        {

        }
        // 2011.07.25 wangf add end
        2011/08/03 wangf del for redMine#23375 start */

        // --- ADD 2013/02/15 Y.Wakita ---------->>>>>
        /// <summary>
        /// 保存処理後の画面制御
        /// </summary>
        /// <remarks>
        /// <br>Update Note : 2015/04/16 黄興貴</br>
        /// <br>管理番号    : 11100008-00</br>
        /// <br>            : Redmine#45230 宮田自動車商会 
        /// <br>            : 仕入伝票入力で仕入伝票番号が欠けるの不具合の対応</br>
        /// <br>Update Note : 2015/05/20 黄興貴</br>
        /// <br>管理番号    : 11100008-00</br>
        /// <br>            : Redmine#45230 宮田自動車商会 
        /// <br>            : 仕入伝票入力で仕入伝票番号が欠けるの不具合の対応</br>
        /// </remarks>
        private void AfterSaveDisplay()
		{
            // 保存後の画面初期化「する」か、セキュリティ権限で「伝票修正不可」の場合は画面を初期化
            if ((this._stockInputConstructionAcs.ClearAfterSaveValue == StockSlipInputConstructionAcs.ClearAfterSave_ON) ||
                (MyOpeCtrl.Disabled((int)OperationCode.Revision)))
            {
                bool keepSupplierFormal = (this._stockInputConstructionAcs.SupplierFormalAfterSaveValue == StockSlipInputConstructionAcs.SupplierFormalAfterSave_Init) ? false : true;

                bool keepDate = true;

                // 保存後の日付「システム日付」か、
                // 保存後の日付「仕入在庫全体設定参照」でマスタ設定が「システム日付に戻す」の場合は日付を保持しない
                if ((this._stockInputConstructionAcs.DateClearAfterSaveValue == StockSlipInputConstructionAcs.DateClearAfterSave_ON) ||
                    ((this._stockInputConstructionAcs.DateClearAfterSaveValue == StockSlipInputConstructionAcs.DateClearAfterSave_Default) && (this._stockSlipInputInitDataAcs.GetStockTtlSt().SlipDateClrDivCd == 0)))
                {
                    keepDate = false;
                }

                // MEMO:保存後の入力区分の保持フラグ
                bool keepStockGoodsCd = (this._stockInputConstructionAcs.StockGoodsCdAfterSaveValue == StockSlipInputConstructionAcs.StockGoodsCdAfterSave_Init) ? false : true;    // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加

                // クリア処理
                // ADD 2009/11/13 MANTIS[0013983] 入力区分の保持機能を追加↓4パラ目を追加
                this.Clear(false, keepSupplierFormal, keepDate, keepStockGoodsCd);
            }
            //保存後の画面初期化「しない」設定し、連続新規できるように修正する、下記のプロパティーをクリアする
            //クリア処理範囲は赤伝以外
            if (this._stockInputConstructionAcs.ClearAfterSaveValue == StockSlipInputConstructionAcs.ClearAfterSave_OFF && !this.uLabel_InputModeTitle.Text.Equals("赤伝"))
            {
                this.tNedit_SupplierSlipNo.Clear();
                this.tNedit_SupplierSlipNo.Enabled = true;
                this.tEdit_PartySaleSlipNum.Clear();
                this._stockSlipInputAcs.StockSlip.UpdateDateTime = DateTime.MinValue;
                this._stockSlipInputAcs.StockSlip.SupplierSlipNo = 0;
                this._stockSlipInputAcs.StockSlip.PartySaleSlipNum = "";
                this._stockSlipInputAcs.Cache(this._stockSlipInputAcs.StockSlip);
                // 仕入データクラス→画面格納処理
                this.SetDisplay(this._stockSlipInputAcs.StockSlip);
            }
            Control firstControl = this.GetHeaderFirstControlAfterSave();// ADD 黄興貴 2015/04/16 Redmine#45230 仕入伝票入力で仕入伝票番号が欠けるの不具合の対応
            //赤伝以外の伝票登録した上で、保存後フォーカス設定
            if (!this.uLabel_InputModeTitle.Text.Equals("赤伝"))
            {
                firstControl.Focus();// ADD 黄興貴 2015/04/16 Redmine#45230 仕入伝票入力で仕入伝票番号が欠けるの不具合の対応
                this.timer_AfterSaveSetFocus.Enabled = true;//保存後フォーカス設定
            }
            //保存後の画面初期化「しない」設定し、赤伝登録した上で、画面の初期化処理を追加する
            if (this._stockInputConstructionAcs.ClearAfterSaveValue == StockSlipInputConstructionAcs.ClearAfterSave_OFF && this.uLabel_InputModeTitle.Text.Equals("赤伝"))
            {
                // 初期化処理
                this.Clear(false, false);
                // firstControl.Focus();// ADD 黄興貴 2015/04/16 Redmine#45230 仕入伝票入力で仕入伝票番号が欠けるの不具合の対応  // DEL 黄興貴 2015/05/20 Redmine#45230 仕入伝票入力で仕入伝票番号が欠けるの不具合の対応
                this.timer_InitialSetFocus.Enabled = true;//初期化フォーカス設定
            }

            // ---ADD 2015/02/25 河原林　一生　仕掛一覧No.2200 強制GC実行 --------------->>>>>
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            // ---ADD 2015/02/25 河原林　一生　仕掛一覧No.2200 強制GC実行 ---------------<<<<<
        }
        // --- ADD 2013/02/15 Y.Wakita ----------<<<<<
    }
}