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
using Broadleaf.Library.Text;
using Broadleaf.Application.Remoting.ParamData;
using System.Text.RegularExpressions;
using Broadleaf.Library.Globarization; // 譚洪  2019/01/08 FOR 新元号の対応

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 検索見積フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検索見積のフォームクラスです。</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2008.05.21</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.06.24 men 新規作成</br>
    /// <br>2009.05.26 20056 對馬 大輔 MANTIS[0013399] 最新情報取得時に拠点名称が最新情報に更新されない対応</br>
    /// <br>2009.06.18 21024 佐々木 健 MANTIS[0013556] 車台番号の範囲チェックを追加</br>
    /// <br>2009.07.15 22018 鈴木 正臣 MANTIS[0013805] 車台番号の範囲チェックを一部修正(範囲:1～xなら入力:000…0を許可しない)</br>
    /// <br>2009/10/15 22018 鈴木 正臣 MANTIS[0014360] 見出貼付機能の修正に伴う変更。（フル型式固定番号＝ゼロを含む場合の対応）</br>
    /// <br>                           MANTIS[0014407] 年式・車台番号をセット後に再検索した時、年式・車台番号をクリアしないよう変更</br>
    /// <br>Update Note: 2009/09/08       汪千来</br>
    /// <br>             PM.NS-2-A・車輌管理</br>
    /// <br>             車輌管理機能の追加</br>
    /// <br>Update Note: 2009/10/16       張莉莉</br>
    /// <br>             Redmine#648の対応</br>
    /// <br>Update Note: 2009/10/22       張莉莉</br>
    /// <br>             Redmine#779の対応</br>
    /// <br>Update Note: 2010/05/21 22018 鈴木正臣</br>
    /// <br>             自由検索型式固定番号の処理を修正</br>
    /// <br>Update Note: 2010/06/08　李占川　障害改良対応（７月リリース分）の対応</br>
    /// <br>             ①モード変更時のフォーカス位置修正</br>
    /// <br>             ②年式絞込み条件変更</br>
    /// <br>Update Note: 2010/08/05　張凱　障害改良対応（８月リリース分）の対応</br>
    /// <br>             ①優良品の結合情報を表示する可能にするため、ファンクションを追加して結合情報を表示可能にする修正</br>
    /// <br>Update Note: 2011/02/14  鄧潘ハン</br>
    /// <br>             ①得意先名称の表示を略称に変更</br>
    /// <br>             ②ユーザー設定ファイルが存在しない場合の動作修正</br>
    /// <br>             ③得意先掛率グループ取得処理対応</br>
    /// <br>             ④車台番号入力時の年式チェック修正</br>
    /// <br>             ⑤修正呼出時の諸元情報表示の制御変更</br>
    /// <br>Update Note: 2011/03/28　曹文傑</br>
    /// <br>             Redmine #20177の対応</br>
    /// <br>Update Note: 2011/07/25 譚洪 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応</br>
    /// <br>Update Note: 2011/11/12 李占川 Redmine#26535 BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑの在庫確認で作成された見積伝票の対応</br>
    /// <br>Update Note: 2012/09/07 脇田　靖之 </br>
    /// <br>             カラー・トリムの存在チェックを外し、マスタに存在しないコードも入力可能にするように修正</br>
    /// <br>Update Note: 2013/02/19  鄭慕鈞</br>
    /// <br>管理番号     10806793-00　 2013/03/13配信分</br>
    /// <br>             Redmine#34639</br>
    /// <br>             拠点が存在しないメッセージが表示されるの対応</br>
    /// <br>Update Note: 2013/03/21 FSI今野 利裕</br>
    /// <br>管理番号   : 10900269-00</br>
    /// <br>             SPK車台番号文字列対応</br>   
    /// <br>Update Note: 2013/05/13 chenw</br>
    /// <br>管理番号   : 10801804-00 2013/05/15 配信分</br>
    /// <br>           : redmine#34803、起動後Ｆ１０を押すとエラーが発生するようになりました</br>
    /// <br>Update Note: 2013/11/05 脇田 靖之</br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>           : 仕掛一覧 №2119</br>
    /// <br>           : 見積時に値引行が入力できない。入力できるようにする。</br>
    /// <br>Update Note: 2013/07/18 kuangf </br>
    /// <br>             仕掛一覧 №1948 Redmine #35748 </br>
    /// <br>             検索見積発行にて車両管理マスタに登録されている特定車両を検索すると処理が固まる</br>
    /// <br>             20141126配信分システムテスト障害№21と同内容</br>
    /// <br>Update Note: 2014/11/17 鹿庭 一郎</br>
    /// <br>管理番号   : 11070184-00</br>
    /// <br>           : SCM仕掛一覧No.10598</br>
    /// <br>           : 文字列車台番号での発注・問合せ対応 システム障害No.22 桁数17桁表示に拡張</br>
    /// <br>Update Note: 2014/11/19 鹿庭 一郎</br>
    /// <br>管理番号   : 11070184-00</br>
    /// <br>           : SCM仕掛一覧No.10598</br>
    /// <br>           : 文字列車台番号での発注・問合せ対応 システム障害No.22 桁数17桁表示 車台番号9桁以上入力可能になっている</br>
    /// <br>Update Note: 2019/01/08 譚洪</br>
    /// <br>管理番号   : 11470076-00</br>
    /// <br>           : 新元号の対応</br>
    /// </remarks>
    public partial class PMMIT01010UA : Form, IEstimateMDIChild
    {
        // ==========================================================	=========================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructors
        /// <summary>
        /// 検索見積フォームクラス デフォルトコンストラクタ
        /// </summary>
        public PMMIT01010UA()
        {
            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "開始");

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "EstimateInputInitDataAcs インスタンス化");
            this._estimateInputInitDataAcs = EstimateInputInitDataAcs.GetInstance();

            this._initialReadThread2 = new Thread(this.InitialReadThread2);
            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "InitialReadThread2 開始");
            this._initialReadThread2.Start();

            this._initialReadThread = new Thread(this.InitialReadThread);
            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "InitialReadThread 開始");
            this._initialReadThread.Start();

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "InitializeComponent");
            InitializeComponent();

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "変数初期化");

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "ControlScreenSkin インスタンス化");
            this._controlScreenSkin = new ControlScreenSkin();

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "EstimateInputColInfoInitialSetting インスタンス化");
            this._estimateInputColInfoInitialSetting = EstimateInputColInfoInitialSetting.GetInstance();

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "EstimateInputAcs インスタンス化");
            this._estimateInputAcs = new EstimateInputAcs();

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "PMMIT01010UB（明細UI） インスタンス化");
            this._estimateDetailInput = new PMMIT01010UB(this._estimateInputAcs);


            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "EstimateInputConstructionAcs インスタンス化");
            this._estimateInputConstructionAcs = EstimateInputConstructionAcs.GetInstance();

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "PMMIT01010UH（優良部品情報UI） インスタンス化");
            this._estimatePrimeInfoDisplay = new PMMIT01010UH(this._estimateInputAcs);

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "EstimateInputInitData） インスタンス化");
            this._estimateInputInitData = new EstimateInputInitData();

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "デリゲート設定");
            this._estimateInputConstructionAcs.DataChanged += new EventHandler(this.EstimateInputConstructionAcs_DataChanged);
            this._estimateDetailInput.GridKeyDownTopRow += new EventHandler(this.EstimateDetailInput_GridKeyDownTopRow);
            this._estimateDetailInput.GridKeyDownButtomRow += new EventHandler(this.EstimateDetailInput_GridKeyDownButtomRow);
            this._estimateDetailInput.StatusBarMessageSetting += new PMMIT01010UB.SettingStatusBarMessageEventHandler(this.EstimateDetailInput_StatusBarMessageSetting);
            this._estimateDetailInput.FocusSetting += new PMMIT01010UB.SettingFocusEventHandler(this.EstimateDetailInput_FocusSetting);
            this._estimateDetailInput.SettingFooter += new PMMIT01010UB.SettingFooterEventHandler(this._estimateInputAcs.PrimeInfoSetting);
            this._estimateDetailInput.SettingCarInfo += new PMMIT01010UB.SettingCarInfoEventHandler(this.CarInfoFormSetting);
            this._estimateDetailInput.SetToolbarButton += new PMMIT01010UB.SettingToolbarEventHandler(this.SettingGuideButtonTool_Detail);
            this._estimateDetailInput.SetToolbarButton += new PMMIT01010UB.SettingToolbarEventHandler(this.SettingToolBarButtonEnabled_Detail);
            this._estimateInputAcs.DataChanged += new EventHandler(this.EstimateInputAcs_DataChanged);

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "空の車輌追加");
            this._carInfoDataTable = this._estimateInputAcs.CarInfoDataTable;
            this._carSpecDataTable = new EstimateInputDataSet.CarSpecDataTable();
            EstimateInputDataSet.CarSpecRow carSpecRow = this._carSpecDataTable.NewCarSpecRow();
            this._carSpecDataTable.AddCarSpecRow(carSpecRow);

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "PMMIT01010UG（車輌情報UI） インスタンス化");
            this._carOtherInfoInput = new PMMIT01010UG(this._estimateInputAcs);
            this._carOtherInfoInput.SettingColorInfo += new PMMIT01010UG.SettingColorEventHandler(this.SettingColorInfo);
            this._carOtherInfoInput.SettingTrimInfo += new PMMIT01010UG.SettingTrimEventHandler(this.SettingTrimInfo);

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "その他クラスのインスタンス化");
            this._imageList16 = IconResourceManagement.ImageList16;
            // --- ADD 2009/09/08 ---------->>>>>
            this._carMngInputAcs = CarMngInputAcs.GetInstance();            // 車輌管理マスタアクセスクラス
            // --- ADD 2009/09/08 ----------<<<<<
            // ---ADD 2011/02/14------------------->>>>>
            // 得意先掛率グループ設定の全件を保持するリストを更新する
            this._estimateInputAcs.ReNewalCustRateGroupList(this._enterpriseCode);
            // ---ADD 2011/02/14-------------------<<<<<
            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "内部変数初期化");
            this._guideEnableControlDictionary.Add(this.tEdit_SectionCode.Name, ctGUIDE_NAME_SectionGuide);
            this._guideEnableControlDictionary.Add(this.uButton_SectionGuide.Name, ctGUIDE_NAME_SectionGuide);
            this._guideEnableControlDictionary.Add(this.tNedit_SubSectionCode.Name, ctGUIDE_NAME_SubSectionGuide);
            this._guideEnableControlDictionary.Add(this.uButton_SubSectionGuide.Name, ctGUIDE_NAME_SubSectionGuide);
            this._guideEnableControlDictionary.Add(this.tEdit_SalesEmployeeCd.Name, ctGUIDE_NAME_EmployeeGuide);
            this._guideEnableControlDictionary.Add(this.uButton_SalesEmployeeGuide.Name, ctGUIDE_NAME_EmployeeGuide);
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode.Name, ctGUIDE_NAME_CustomerGuide);
            this._guideEnableControlDictionary.Add(this.tEdit_CustomerName.Name, ctGUIDE_NAME_CustomerGuide);
            this._guideEnableControlDictionary.Add(this.uButton_CustomerGuide.Name, ctGUIDE_NAME_CustomerGuide);
            this._guideEnableControlDictionary.Add(this.tEdit_CarMngCode.Name, ctGUIDE_NAME_CarMngNoGuide);
            this._guideEnableControlDictionary.Add(this.uButton_CarMngNoGuide.Name, ctGUIDE_NAME_CarMngNoGuide);
            this._guideEnableControlDictionary.Add(this.tNedit_SalesSlipNum.Name, ctGUIDE_NAME_SalesSlipGuide);
            this._guideEnableControlDictionary.Add(this.uButton_SalesSlipGuide.Name, ctGUIDE_NAME_SalesSlipGuide);

            this._guideEnableControlDictionary.Add(this.tNedit_MakerCode.Name, ctGUIDE_NAME_ModelFullGuide);
            this._guideEnableControlDictionary.Add(this.tNedit_ModelCode.Name, ctGUIDE_NAME_ModelFullGuide);
            this._guideEnableControlDictionary.Add(this.tNedit_ModelSubCode.Name, ctGUIDE_NAME_ModelFullGuide);
            this._guideEnableControlDictionary.Add(this.tEdit_ModelFullName.Name, ctGUIDE_NAME_ModelFullGuide);
            this._guideEnableControlDictionary.Add(this.uButton_ModelFullGuide.Name, ctGUIDE_NAME_ModelFullGuide);

            this._guideEnableExceptControlDictionary.Add(this._estimateDetailInput.Name, this._estimateDetailInput);
            this._guideEnableExceptControlDictionary.Add(this._estimateDetailInput.uGrid_Details.Name, this._estimateDetailInput.uGrid_Details);
            this._guideEnableExceptControlDictionary.Add(this._estimateDetailInput.uButton_Guide.Name, this._estimateDetailInput.uButton_Guide);

            int controlIndexForword = 0;
            this._controlIndexForwordDictionary.Add(this.tEdit_SectionCode.Name, controlIndexForword++);               // 拠点
            this._controlIndexForwordDictionary.Add(this.tNedit_SubSectionCode.Name, controlIndexForword++);           // 部門
            this._controlIndexForwordDictionary.Add(this.tEdit_SalesEmployeeCd.Name, controlIndexForword++);           // 担当者
            this._controlIndexForwordDictionary.Add(this.tNedit_CustomerCode.Name, controlIndexForword++);             // 得意先
            this._controlIndexForwordDictionary.Add(this.tEdit_CustomerName.Name, controlIndexForword++);              // 得意先名称
            this._controlIndexForwordDictionary.Add(this.tDateEdit_SalesDate.Name, controlIndexForword++);             // 見積日
            this._controlIndexForwordDictionary.Add(this.tDateEdit_EstimateValidityDate.Name, controlIndexForword++);  // 見積有効期限
            this._controlIndexForwordDictionary.Add(this.tEdit_CarMngCode.Name, controlIndexForword++);                // 管理番号
            this._controlIndexForwordDictionary.Add(this.tNedit_ModelDesignationNo.Name, controlIndexForword++);       // 類別
            this._controlIndexForwordDictionary.Add(this.tEdit_EngineModelNm.Name, controlIndexForword++);             // エンジン型式
            this._controlIndexForwordDictionary.Add(this.uButton_ChangeSearchCarMode.Name, controlIndexForword++);     // 車輌検索切替ボタン
            this._controlIndexForwordDictionary.Add(this.tEdit_FullModel.Name, controlIndexForword++);                 // 型式
            this._controlIndexForwordDictionary.Add(this.tNedit_MakerCode.Name, controlIndexForword++);                // カーメーカーコード
            this._controlIndexForwordDictionary.Add(this.tNedit_ModelCode.Name, controlIndexForword++);                // 車種コード
            this._controlIndexForwordDictionary.Add(this.tNedit_ModelSubCode.Name, controlIndexForword++);             // 車種呼称コード
            this._controlIndexForwordDictionary.Add(this.tEdit_ModelFullName.Name, controlIndexForword++);             // 車種名称
            this._controlIndexForwordDictionary.Add(this.tDateEdit_FirstEntryDate.Name, controlIndexForword++);        // 年式
            this._controlIndexForwordDictionary.Add(this.tEdit_ProduceFrameNo.Name, controlIndexForword++);            // 車台番号
            this._controlIndexForwordDictionary.Add(this.tEdit_ColorNo.Name, controlIndexForword++);                   // カラー
            this._controlIndexForwordDictionary.Add(this.tEdit_TrimNo.Name, controlIndexForword++);                    // トリム


            int controlIndexBack = 99;
            this._controlIndexBackDictionary.Add(this.tEdit_SectionCode.Name, controlIndexBack--);                     // 拠点
            this._controlIndexBackDictionary.Add(this.tNedit_SubSectionCode.Name, controlIndexBack--);                 // 部門
            this._controlIndexBackDictionary.Add(this.tEdit_SalesEmployeeCd.Name, controlIndexBack--);                 // 担当者
            this._controlIndexBackDictionary.Add(this.tNedit_CustomerCode.Name, controlIndexBack--);                   // 得意先
            this._controlIndexBackDictionary.Add(this.tEdit_CustomerName.Name, controlIndexBack--);                    // 得意先名称
            this._controlIndexBackDictionary.Add(this.tDateEdit_SalesDate.Name, controlIndexBack--);                   // 見積日
            this._controlIndexBackDictionary.Add(this.tDateEdit_EstimateValidityDate.Name, controlIndexBack--);        // 見積有効期限
            this._controlIndexBackDictionary.Add(this.tEdit_CarMngCode.Name, controlIndexBack--);                      // 管理番号
            this._controlIndexBackDictionary.Add(this.tNedit_ModelDesignationNo.Name, controlIndexBack--);             // 類別
            this._controlIndexBackDictionary.Add(this.tEdit_EngineModelNm.Name, controlIndexBack--);                   // エンジン型式
            this._controlIndexBackDictionary.Add(this.uButton_ChangeSearchCarMode.Name, controlIndexBack--);           // 車輌検索切替ボタン
            this._controlIndexBackDictionary.Add(this.tEdit_FullModel.Name, controlIndexBack--);                       // 型式
            this._controlIndexBackDictionary.Add(this.tNedit_MakerCode.Name, controlIndexBack--);                      // カーメーカーコード
            this._controlIndexBackDictionary.Add(this.tNedit_ModelCode.Name, controlIndexBack--);                      // 車種コード
            this._controlIndexBackDictionary.Add(this.tNedit_ModelSubCode.Name, controlIndexBack--);                   // 車種呼称コード
            this._controlIndexBackDictionary.Add(this.tEdit_ModelFullName.Name, controlIndexBack--);                   // 車種名称
            this._controlIndexBackDictionary.Add(this.tDateEdit_FirstEntryDate.Name, controlIndexBack--);              // 年式
            this._controlIndexBackDictionary.Add(this.tEdit_ProduceFrameNo.Name, controlIndexBack--);                  // 車台番号
            this._controlIndexBackDictionary.Add(this.tEdit_ColorNo.Name, controlIndexBack--);                         // カラー
            this._controlIndexBackDictionary.Add(this.tEdit_TrimNo.Name, controlIndexBack--);                          // トリム

            // ヘッダ項目Dictionary作成
            this._headerItemsDictionary.Add(this.uLabel_SectionTitle.Text, this.tEdit_SectionCode);
            this._headerItemsDictionary.Add(this.uLabel_SubSectionTitle.Text, this.tNedit_SubSectionCode);
            this._headerItemsDictionary.Add(this.uLabel_SalesEmployeeTitle.Text, this.tEdit_SalesEmployeeCd);
            this._headerItemsDictionary.Add(this.uLabel_CustomerTitle.Text, this.tNedit_CustomerCode);
            this._headerItemsDictionary.Add(this.uLabel_CustomerName.Text, this.tEdit_CustomerName);
            this._headerItemsDictionary.Add(this.uLabel_SalesDateTitle.Text, this.tDateEdit_SalesDate);
            this._headerItemsDictionary.Add(this.uLabel_EstimateValidityDateTitle.Text, this.tDateEdit_EstimateValidityDate);
            this._headerItemsDictionary.Add(this.uLabel_CarMngNoTitle.Text.Trim(), this.tEdit_CarMngCode);
            this._headerItemsDictionary.Add(this.uLabel_ModelDesignationNoTitle.Text.Trim(), this.tNedit_ModelDesignationNo);
            this._headerItemsDictionary.Add(this.uLabel_EngineModelTitle.Text.Trim(), this.tEdit_EngineModelNm);
            this._headerItemsDictionary.Add(this.uButton_ChangeSearchCarMode.Text.Trim(), this.tEdit_FullModel);
            this._headerItemsDictionary.Add(this.uLabel_MakerCode.Text.Trim(), this.tNedit_MakerCode);
            this._headerItemsDictionary.Add(this.uLabel_ModelCode.Text.Trim(), this.tNedit_ModelCode);
            this._headerItemsDictionary.Add(this.uLabel_ModelSubCode.Text.Trim(), this.tNedit_ModelSubCode);
            this._headerItemsDictionary.Add(this.uLabel_ModelFullName.Text.Trim(), this.tEdit_ModelFullName);
            this._headerItemsDictionary.Add(this.uLabel_FirstEntryDateTitle.Text.Trim(), this.tDateEdit_FirstEntryDate);
            this._headerItemsDictionary.Add(this.uLabel_ProduceFrameNoTitle.Text.Trim(), this.tEdit_ProduceFrameNo);
            this._headerItemsDictionary.Add(this.uLabel_ColorNoTitle.Text.Trim(), this.tEdit_ColorNo);
            this._headerItemsDictionary.Add(this.uLabel_TrimNoTitle.Text.Trim(), this.tEdit_TrimNo);

            this._estimateInputConstructionAcs.HeaderItemsDictionary = this._headerItemsDictionary;

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "Constructor", "終了");
        }

        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private PMMIT01010UB _estimateDetailInput;
        private PMMIT01010UH _estimatePrimeInfoDisplay;
        private ImageList _imageList16 = null;											// イメージリスト

        private ControlScreenSkin _controlScreenSkin;
        private EstimateInputAcs _estimateInputAcs;
        private EstimateInputInitDataAcs _estimateInputInitDataAcs;
        private EstimateInputConstructionAcs _estimateInputConstructionAcs;
        private Dictionary<string, string> _guideEnableControlDictionary = new Dictionary<string, string>();
        private Dictionary<string, Control> _guideEnableExceptControlDictionary = new Dictionary<string, Control>();
        private Dictionary<string, int> _controlIndexForwordDictionary = new Dictionary<string, int>();
        private Dictionary<string, int> _controlIndexBackDictionary = new Dictionary<string, int>();
        private Dictionary<string, Control> _headerItemsDictionary = new Dictionary<string, Control>();
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        private CustomerInfoAcs _customerInfoAcs;
        private Control _prevControl = null;									// 現在のコントロール
        private EstimateInputInitData _estimateInputInitData;
        private string _guideKey;
        private DateGetAcs _dateGetAcs;
        // --- ADD 2009/09/08 ---------->>>>>
        private CarMngInputAcs _carMngInputAcs;                                         // 車輌管理マスタアクセスクラス
        // --- ADD 2009/09/08 ----------<<<<<
        //private SalesTempInputAcs _salesTempInputAcs;							// 売上情報アクセスクラス

        private PMMIT01010UG _carOtherInfoInput;

        private EstimateInputColInfoInitialSetting _estimateInputColInfoInitialSetting;

        private EstimateInputDataSet.CarInfoDataTable _carInfoDataTable;
        private EstimateInputDataSet.CarSpecDataTable _carSpecDataTable;

        // ツールバー有効無効設定
        private bool _canReturn = true;
        private bool _canForward = true;
        private bool _canPrint = true;
        private bool _canNew = true;
        private bool _canDeleteSlip = true;
        private bool _canUndo = true;
        private bool _canGuide = true;
        private bool _canReadSlip = true;
        private bool _canCopySlip = true;
        private bool _canChangePartsSearch = true;
        private bool _canOrderSelect = true;
        private bool _canChangeDisplay = true;
        private bool _canEntryJoinParts = true;
        private bool _canShowSet = true;
        private bool _canEstimateReference = true;
        private bool _canReNewal = true; // 2009.03.26

        private Thread _initialReadThread;
        private Thread _initialReadThread2;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 ADD
        private BeforeCarSearchBuffer _beforeCarSearchBuffer;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 ADD

        private bool _carNoErrorFlg = false; // ADD 2011/03/28
        # endregion

        // ===================================================================================== //
        // 定数
        // ===================================================================================== //
        # region ■Const Members

        private const string ctGUIDE_NAME_SectionGuide = "SectionGuide";
        private const string ctGUIDE_NAME_SubSectionGuide = "SubSectionGuide";
        private const string ctGUIDE_NAME_EmployeeGuide = "EmployeeGuide";
        private const string ctGUIDE_NAME_SalesSlipGuide = "SalesSlipGuide";
        private const string ctGUIDE_NAME_CustomerGuide = "CustomerGuide";
        private const string ctGUIDE_NAME_ModelFullGuide = "ModelFullGuide";
        private const string ctGUIDE_NAME_CarMngNoGuide = "CarMngNoGuide";
        private const string ctAssemblyName = "PMMIT01010UA";

        private const string ctSearchCarMode_FullModel = "型式";
        private const string ctSearchCarMode_ModelPlate = "ﾓﾃﾞﾙﾌﾟﾚｰﾄ";

        private const string ctSearchMode_BLSearch = "部品検索";            // BLコード検索
        private const string ctSearchMode_GoodsNoSearch = "品番入力";       // 品番検索

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
        /// 仕入先変更デリゲート
        /// </summary>
        /// <param name="reCalcPrice">True:単価再計算する</param>
        public delegate void SupplierChangeEventHandler(bool reCalcPrice);

        #endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ■Events

        #endregion

        // ===================================================================================== //
        // IEstimateMDIChildメンバ
        // ===================================================================================== //
        #region ■IEstimateMDIChildメンバ

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ◆ Event
        /// <summary>ツールバー制御イベント</summary>
        public event ParentToolbarLedgerSettingEventHandler ParentToolbarLedgerSettingEvent;
        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ◆Properties

        /// <summary>戻るボタン有効無効プロパティ(読取専用)</summary>
        public bool CanReturnButton
        {
            get { return _canReturn; }
        }

        /// <summary>進むボタン有効無効プロパティ(読取専用)</summary>
        public bool CanForwardButton
        {
            get { return _canForward; }
        }


        /// <summary>印刷ボタン有効無効プロパティ(読取専用)</summary>
        public bool CanPrintButton
        {
            get { return _canPrint; }
        }

        /// <summary>新規ボタン有効無効プロパティ(読取専用)</summary>
        public bool CanNewButton
        {
            get { return _canNew; }
        }

        /// <summary>伝票削除ボタン有効無効プロパティ(読取専用)</summary>
        public bool CanDeleteSlipButton
        {
            get { return _canDeleteSlip; }
        }

        /// <summary>元に戻すボタン有効無効プロパティ(読取専用)</summary>
        public bool CanUndoButton
        {
            get { return _canUndo; }
        }

        /// <summary>ガイドボタン有効無効プロパティ(読取専用)</summary>
        public bool CanGuideButton
        {
            get { return _canGuide; }
        }

        /// <summary>伝票呼出ボタン有効無効プロパティ(読取専用)</summary>
        public bool CanReadSlipButton
        {
            get { return _canReadSlip; }
        }


        /// <summary>伝票複写ボタン有効無効プロパティ(読取専用)</summary>
        public bool CanCopySlipButton
        {
            get { return _canCopySlip; }
        }


        /// <summary>部品検索切替ボタン有効無効プロパティ(読取専用)</summary>
        public bool CanChangePartsSearchButton
        {
            get { return _canChangePartsSearch; }
        }

        /// <summary>結合登録ボタン有効無効プロパティ(読取専用)</summary>
        public bool CanEntryJoinPartsButton
        {
            get { return _canEntryJoinParts; }
        }


        /// <summary>発注選択ボタン有効無効プロパティ(読取専用)</summary>
        public bool CanOrderSelectButton
        {
            get { return _canOrderSelect; }
        }


        /// <summary>画面切替ボタン有効無効プロパティ(読取専用)</summary>
        public bool CanChangeDisplayButton
        {
            get { return _canChangeDisplay; }
        }


        /// <summary>セットボタン有効無効プロパティ(読取専用)</summary>
        public bool CanShowSetButton
        {
            get { return _canShowSet; }
        }

        /// <summary>見積照会有効無効プロパティ(読取専用)</summary>
        public bool CanEstimateReferenceButton
        {
            get { return _canEstimateReference; }
        }

        // 2009.03.26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>最新情報ボタン有効無効プロパティ(読取専用)</summary>
        public bool CanReNewalButton
        {
            get { return _canReNewal; }
        }
        // 2009.03.26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        // ===================================================================================== //
        // メソッド
        // ===================================================================================== //
        #region ◆Methods

        /// <summary>
        /// 表示処理
        /// </summary>
        /// <param name="parameters"></param>
        public void Show(object[] parameters)
        {
            this.Show();
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>印刷結果ステータス</returns>
        public int Print()
        {
            PMMIT01010UI printForm = new PMMIT01010UI(this._estimateInputAcs);
            printForm.RefreshScreen += new PMMIT01010UI.RefreshScreenEventHandler(this.RefreshScreen);
            printForm.InitialScreen += new EventHandler(this.ClearScreen);
            printForm.InitialScreenAfterSave += new EventHandler(this.ClearScreenAfterSave);
            printForm.Reload += new EventHandler(this.ReLoadSlip);

            printForm.ShowDialog(this);
            if (printForm.DialogResult == DialogResult.OK)
            {
            }

            return 0;
        }


        /// <summary>
        /// 印刷前チェック
        /// </summary>
        /// <returns>True:印刷可</returns>
        /// <br>Update Note: 2011/03/28 曹文傑</br>
        /// <br>             Redmine #20177の対応</br>
        public bool PrintBeforeCheack()
        {
            bool checkReturn = true;
            // --- ADD 2013/03/21 ---------->>>>>
            // 選択されている明細を取得
            int salesRowNo = this._estimateDetailInput.GetActiveRowSalesRowNo();
            EstimateInputDataSet.CarInfoRow carInfoRowCurrent = this._estimateInputAcs.GetCarInfoRow(salesRowNo, EstimateInputAcs.GetCarInfoMode.ExistGetMode);

            // 型式が入力済みかつ、メーカーコードがBENZ、
            // VINコードが入力済みの場合(外車の場合)
            // ハンドル位置をチェックする
            //if (!string.IsNullOrEmpty(carInfoRowCurrent.FullModel) && //DEL 2013/05/13 chenw FOR Redmine#34803
            if (carInfoRowCurrent != null && !string.IsNullOrEmpty(carInfoRowCurrent.FullModel) && //ADD 2013/05/13 chenw FOR Redmine#34803
                carInfoRowCurrent.MakerCode == 80 &&
                carInfoRowCurrent.DomesticForeignCode == 2 &&
                !this._estimateInputAcs.CheckHandlePosition(carInfoRowCurrent.CarRelationGuid, this.tEdit_ProduceFrameNo.Text))
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_INFO,
                this.Name,
                "ハンドル位置が異なります。",
                -1,
                MessageBoxButtons.OK);
                // フォーカスを車台番号/VINコードに移して印刷処理をキャンセルする
                this.tEdit_ProduceFrameNo.Focus();
                this.tEdit_ProduceFrameNo.Select(0, this.tEdit_ProduceFrameNo.Text.Length);
                return false;
            }
            // --- ADD 2013/03/21 ----------<<<<<

            // ---ADD 2011/03/28--------------->>>>>
            this._carNoErrorFlg = false;

            bool doChangeFocus = false;
            if (this._prevControl != null && this._prevControl != this.tEdit_ProduceFrameNo)
            {
                doChangeFocus = true;
            }
            // ---ADD 2011/03/28---------------<<<<<
            // 一括ゼロ詰め
            this.uiSetControl1.SettingAllControlsZeroPaddedText();
            if (this._prevControl != null)
            {
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tArrowKeyControl1_ChangeFocus(this, e);
                // ---ADD 2011/03/28--------------->>>>>
                if (this._carNoErrorFlg)
                {
                    this._carNoErrorFlg = false;
                    this.tEdit_ProduceFrameNo.Focus();
                    return false;
                }
                else
                {
                    //なし。
                }
                // ---ADD 2011/03/28---------------<<<<<
            }


            List<string> itemNameList;
            List<string> itemList;
            List<int> errorRowList;
            string mainMessage;

            bool check = this._estimateInputAcs.CheckSaveData(out mainMessage, out itemNameList, out itemList, out errorRowList);

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
                    this.SetControlFocus(itemName, (errorRowList.Count > 0) ? errorRowList[0] : -1);
                }
                checkReturn = false;
            }

            // ---ADD 2011/03/28--------------->>>>>
            if (checkReturn && doChangeFocus)
            {
                ChangeFocusEventArgs ea = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.tEdit_ProduceFrameNo, this.tEdit_ProduceFrameNo);
                this.tArrowKeyControl1_ChangeFocus(this, ea);
                if (this._carNoErrorFlg)
                {
                    this._carNoErrorFlg = false;
                    this.tEdit_ProduceFrameNo.Focus();
                    return false;
                }
                else
                {
                    //なし。
                }
            }
            // ---ADD 2011/03/28---------------<<<<<

            return checkReturn;
        }

        /// <summary>
        /// 画面初期化
        /// </summary>
        public void InitialScreen()
        {
        }

        /// <summary>
        /// 「戻る」処理
        /// </summary>
        public void FocusSet_Return()
        {
            Control nextControl = null;

            if (this._estimatePrimeInfoDisplay.ContainsFocus)
            {
                //this._estimateDetailInput.uGrid_Details.Focus();
                nextControl = this._estimateDetailInput.uGrid_Details;
            }
            else if (this._estimateDetailInput.ContainsFocus)
            {
                Control firstControl = this.GetHeaderFirstControl();
                if ((firstControl != null) && (firstControl.Enabled))
                {
                    nextControl = firstControl;
                    //firstControl.Focus();
                }
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
        }

        /// <summary>
        /// 「進む」処理
        /// </summary>
        /// <returns></returns>
        public void FocusSet_Forward()
        {
            Control nextControl = null;
            if (this._estimateDetailInput.ContainsFocus)
            {
                if (this._estimatePrimeInfoDisplay.PrimeDataCount > 0)
                {
                    this.uExpandableGroupBox_PrimeInfo.Expanded = true;
                    //this._estimatePrimeInfoDisplay.Focus();
                    nextControl = this._estimatePrimeInfoDisplay;
                }
            }
            else if (this._estimatePrimeInfoDisplay.ContainsFocus)
            {
            }
            else
            {
                nextControl = this._estimateDetailInput.uGrid_Details;
                //this._estimateDetailInput.uGrid_Details.Focus();
            }

            if (nextControl != null)
            {
                // 一括ゼロ詰め
                this.uiSetControl1.SettingAllControlsZeroPaddedText();
                ChangeFocusEventArgs ex = new ChangeFocusEventArgs(false, false, false, Keys.None, this.GetActiveControl(), nextControl);
                this.tArrowKeyControl1_ChangeFocus(this, ex);
                nextControl = ex.NextCtrl;

                if (nextControl == this._estimatePrimeInfoDisplay)
                {
                    this.uExpandableGroupBox_PrimeInfo.Expanded = true;
                }
                nextControl.Focus();
            }
        }

        /// <summary>
        /// 「新規作成」処理
        /// </summary>
        public void CreateNewSlip()
        {
            // クリア処理
            this.Clear(true, true);

            this.timer_InitialSetFocus.Enabled = true;
        }

        /// <summary>
        /// 「伝票削除」処理
        /// </summary>
        public void DeleteSlip()
        {
            this.Delete();
        }

        /// <summary>
        /// 「ガイド」処理
        /// </summary>
        /// <br>Update Note: 2009/09/08 汪千来 車輌管理機能対応</br>
        public void ExecuteGuide()
        {
            if (this._estimateDetailInput.ContainsFocus)
            {
                this._estimateDetailInput.ExecuteGuide();
            }
            else
            {
                switch (this._guideKey)
                {
                    // 拠点ガイド
                    case ctGUIDE_NAME_SectionGuide:
                        this.uButton_SectionGuide_Click(this.uButton_SectionGuide, new EventArgs());
                        break;
                    // 部門ガイド
                    case ctGUIDE_NAME_SubSectionGuide:
                        this.uButton_SubSectionGuide_Click(this.uButton_SubSectionGuide, new EventArgs());
                        break;
                    // 担当者ガイド
                    case ctGUIDE_NAME_EmployeeGuide:
                        this.uButton_SalesEmployeeGuide_Click(this.uButton_SalesEmployeeGuide, new EventArgs());
                        break;
                    // 得意先ガイド
                    case ctGUIDE_NAME_CustomerGuide:
                        this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide, new EventArgs());
                        break;
                    // 伝票番号ガイド
                    case ctGUIDE_NAME_SalesSlipGuide:
                        this.uButton_SalesSlipGuide_Click(this.uButton_SalesSlipGuide, new EventArgs());
                        break;
                    // 管理車輌ガイド
                    case ctGUIDE_NAME_CarMngNoGuide:
                        // --- ADD 2009/09/08 ---------->>>>>
                        this.uButton_CarMngNoGuide_Click(this.uButton_CarMngNoGuide, new EventArgs());
                        break;
                    // --- ADD 2009/09/08 ----------<<<<<
                    // 車種ガイド
                    case ctGUIDE_NAME_ModelFullGuide:
                        {
                            this.uButton_ModelFullGuide_Click(this.uButton_ModelFullGuide, new EventArgs());
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 「伝票呼出」処理
        /// </summary>
        public void ReadSlip()
        {
            this.uButton_SalesSlipGuide_Click(this.uButton_SalesSlipGuide, new EventArgs());
        }

        /// <summary>
        /// 「伝票複写」処理
        /// </summary>
        public void CopySlip()
        {
            if (this._estimateDetailInput.ContainsFocus)
            {
                this._estimateDetailInput.EstimateReferenceSearch();
            }
            else
            {
                this.CopySlip(true);
            }
        }

        /// <summary>
        /// 「部品検索切替」処理
        /// </summary>
        public void ChangePartsSearch()
        {
            SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

            this.ChangePartsSearchMode(ref salesSlip, true);
        }

        /// <summary>
        /// 「画面切替」処理
        /// </summary>
        public void ChangeDisplay()
        {
            this._estimateDetailInput.ChangeNextDetailPattern();
            if (this._estimateDetailInput.ContainsFocus)
            {
                this._estimateDetailInput.CellExitEnterEditEnter();
            }
        }

        /// <summary>
        /// 「結合登録」処理
        /// </summary>
        public void EntryJoinParts()
        {
            PMMIT01010UJ entryJoinPartsDisplay = new PMMIT01010UJ(this._estimateInputAcs);

            entryJoinPartsDisplay.ShowDialog(this, this._estimateInputAcs.EstimateDetailDataTable);
        }

        /// <summary>
        /// 「元に戻す」処理
        /// </summary>
        public void Undo()
        {
            this.Retry(true);
            this.timer_InitialSetFocus.Enabled = true;
        }

        /// <summary>
        /// 「発注選択」処理
        /// </summary>
        public void OrderSelect()
        {
            PMMIT01010UK orderSelect = new PMMIT01010UK(this._estimateInputAcs);

            DialogResult dialogResult = orderSelect.ShowDialog(this, this._estimateInputAcs.EstimateDetailDataTable, this._estimateInputAcs.PrimeInfoDataTable, this._estimateInputAcs.UOEOrderDataTable, this._estimateInputAcs.UOEOrderDetailDataTable);
            if (dialogResult == DialogResult.OK)
            {
                this._estimateInputAcs.ReflectionOrderSelectInfo(orderSelect.UOEOrderDataTable, orderSelect.UOEOrderDetailDataTable);

                this._estimatePrimeInfoDisplay.GridRefresh();
                this._estimateDetailInput.SettingGrid();
            }
        }

        /// <summary>
        /// 「セット」処理
        /// </summary>
        public void ShowSet()
        {
            this._estimateDetailInput.ShowSetWindow();
        }

        /// <summary>
        /// 見積履歴
        /// </summary>
        public void EstimateReference()
        {
            this._estimateDetailInput.EstimateReferenceSearch();
        }

        // 2009.03.26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 「最新情報」処理
        /// </summary>
        /// <br>Update Note: 2011/02/14 yangmj</br>
        /// <br>             得意先掛率グループ取得処理対応</br>
        /// <br>Update Note: 2011/07/25 譚洪 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応</br>
        public void ReNewal()
        {
            SFCMN00299CA processingDialog = new SFCMN00299CA();
            try
            {
                processingDialog.Title = "最新情報取得";
                processingDialog.Message = "現在、最新情報取得中です。";
                processingDialog.DispCancelButton = false;
                processingDialog.Show((Form)this.Parent.Parent.Parent);

                this._estimateInputInitDataAcs.ReadInitData(this._enterpriseCode, this._loginSectionCode);
                this._estimateInputInitDataAcs.ReadInitData2(this._enterpriseCode, this._loginSectionCode);

                // 2009.05.26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                this._customerInfoAcs.DeleteStaticMemoryData();
                this._estimateInputInitDataAcs.GetOwnSectionName();
                // 2009.05.26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // --- ADD 2011/02/14---------->>>>>
                this._estimateInputAcs.ReNewalCustRateGroupList(this._enterpriseCode);
                this._estimateInputAcs.ReNewalDisplayDivList(this._enterpriseCode);
                // --- ADD 2011/02/14----------<<<<<

                // 初期データ取得後のグリッド設定
                this._estimateDetailInput.SettingAfterInitDataRead();

                if (this._estimateInputInitDataAcs.GetCompanyInf().SecMngDiv == 0)
                {
                    if (this._headerItemsDictionary.ContainsKey(this.uLabel_SubSectionTitle.Text.Trim()))
                    {
                        this._headerItemsDictionary.Remove(this.uLabel_SubSectionTitle.Text.Trim());
                    }
                }

                this._estimateInputAcs.SetUnitPriceCalculation();  // ADD 2011/07/25

                this._estimateInputInitDataAcs.CacheEventCall();

                // フォーカス移動設定処理
                this.SettingFocusDictionary();

                // コンボエディタアイテム初期設定処理
                this.ComboEditorItemInitialSetting();

                // Visible設定
                this.SettingVisible();

                // 画面項目名称設定処理
                this.DisplayNameSetting();

                // クリア処理
                this.Clear(false);

                this.timer_InitialSetFocus.Enabled = true;

                this._estimateDetailInput.SettingFooterEventCall();

                this.SettingOptionInfo();

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
        }
        // 2009.03.26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods

        /// <summary>
        /// 初期データ取得スレッド
        /// </summary>
        private void InitialReadThread()
        {
            this._estimateInputInitDataAcs.ReadInitData(this._enterpriseCode, this._loginSectionCode);
            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "InitialReadThread", "終了");
        }

        /// <summary>
        /// 初期データ取得スレッド
        /// </summary>
        private void InitialReadThread2()
        {
            this._estimateInputInitDataAcs.ReadInitData2(this._enterpriseCode, this._loginSectionCode);
            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "InitialReadThread2", "終了");
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
        private Control GetParentControl(Control ctrl)
        {
            Control retCtrl = ctrl;
            if (ctrl.Parent != null)
            {
                if ((ctrl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
                    (ctrl.Parent is Broadleaf.Library.Windows.Forms.TEdit) ||
                    (ctrl.Parent is Broadleaf.Library.Windows.Forms.TDateEdit) ||
                    (ctrl.Parent is Broadleaf.Library.Windows.Forms.TComboEditor))
                {
                    //retCtrl = ctrl.Parent;
                    retCtrl = GetParentControl(ctrl.Parent);
                }
            }

            return retCtrl;
        }


        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SubSectionGuide.ImageList = this._imageList16;
            this.uButton_SalesEmployeeGuide.ImageList = this._imageList16;
            this.uButton_CustomerGuide.ImageList = this._imageList16;
            this.uButton_SalesSlipGuide.ImageList = this._imageList16;
            this.uButton_CarMngNoGuide.ImageList = this._imageList16;
            this.uButton_ModelFullGuide.ImageList = this._imageList16;

            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SubSectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SalesEmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SalesSlipGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_CarMngNoGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_ModelFullGuide.Appearance.Image = (int)Size16_Index.STAR1;
        }

        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        private void ToolBarInitilSetting()
        {
            //// 管理拠点コンボボックスの設定
            //try
            //{
            //    this._estimateInputInitDataAcs.SetSectionComboEditor(ref this._sectionComboBox, false);

            //    // 拠点コンボエディタ選択値設定処理
            //    this._estimateInputInitDataAcs.SetSectionComboEditorValue(this._sectionComboBox, this._loginSectionCode);
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
        }

        /// <summary>
        /// 仕入データクラス→画面格納処理
        /// </summary>
        /// <param name="stockSlip">仕入データオブジェクト</param>
        private void SetDisplay(SalesSlip salesSlip)
        {
            this.SetDisplay(salesSlip, SetDisplayMode.All);
        }

        /// <summary>
        /// 仕入データクラス→画面格納処理（オーバーロード）
        /// </summary>
        /// <param name="stockSlip">仕入データオブジェクト</param>
        /// <param name="setDisplayMode">表示モード</param>
        private void SetDisplay(SalesSlip salesSlip, SetDisplayMode setDisplayMode)
        {
            switch (setDisplayMode)
            {
                case SetDisplayMode.All:
                    {
                        // 画面表示処理（ヘッダ、フッタ情報／仕入データより）
                        this.SetDisplayHeaderFooterInfo(salesSlip);

                        break;
                    }
            }
        }

        /// <summary>
        /// 明細コンポーネント取得処理
        /// </summary>
        /// <returns></returns>
        private Control GetDetailComponent()
        {
            return this._estimateDetailInput;
        }

        /// <summary>
        /// 画面表示処理（ヘッダ、フッタ情報／仕入データより）
        /// </summary>
        /// <param name="stockSlip">仕入データオブジェクト</param>
        /// <br>Update Note: 2011/02/14  鄧潘ハン</br>
        /// <br>             得意先名称の表示を略称に変更</br>
        /// <br>Update Note: 2011/02/14  徐嘉</br>
        /// <br>             修正呼出時の諸元情報表示の制御変更</br>
        /// <br>Update Note: 2013/02/19  鄭慕鈞</br>
        /// <br>管理番号     10806793-00　 2013/03/13配信分</br>
        /// <br>             Redmine#34639</br>
        /// <br>             拠点が存在しないメッセージが表示されるの対応</br>
        private void SetDisplayHeaderFooterInfo(SalesSlip salesSlip)
        {
            if (salesSlip == null) return;

            try
            {
                // 各コントロールの描画を一時的に停止させる
                this.tEdit_SectionCode.BeginUpdate();
                this.tNedit_SubSectionCode.BeginUpdate();
                this.tNedit_SalesSlipNum.BeginUpdate();
                this.tEdit_SalesEmployeeCd.BeginUpdate();
                this.tNedit_CustomerCode.BeginUpdate();
                this.tEdit_CustomerName.BeginUpdate();
                this.tEdit_CarMngCode.BeginUpdate();
                this.tNedit_ModelDesignationNo.BeginUpdate();
                this.tNedit_CategoryNo.BeginUpdate();
                this.tEdit_EngineModelNm.BeginUpdate();
                this.tEdit_FullModel.BeginUpdate();
                this.tNedit_MakerCode.BeginUpdate();
                this.tNedit_ModelCode.BeginUpdate();
                this.tNedit_ModelSubCode.BeginUpdate();
                this.tEdit_ModelFullName.BeginUpdate();
                this.tEdit_ProduceFrameNo.BeginUpdate();
                this.tEdit_ColorNo.BeginUpdate();
                this.tEdit_TrimNo.BeginUpdate();
                this.uButton_ChangeSearchCarMode.BeginUpdate();
                this.tNedit_SalesSlipNum.SetInt(TStrConv.StrToIntDef(salesSlip.SalesSlipNum, 0));

                // 拠点
                //this.tEdit_SectionCode.Text = salesSlip.ResultsAddUpSecCd; // DEL 鄭慕鈞　Redmine#34639 2013/02/19
                this.tEdit_SectionCode.Text = salesSlip.ResultsAddUpSecCd.Trim();// ADD 鄭慕鈞　Redmine#34639 2013/02/19
                this.uLabel_SectionName.Text = salesSlip.ResultsAddUpSecNm;
                // 部門
                this.tNedit_SubSectionCode.SetInt(salesSlip.SubSectionCode);
                this.uLabel_SubSectionName.Text = salesSlip.SubSectionName;
                // 担当者
                this.tEdit_SalesEmployeeCd.Text = salesSlip.SalesEmployeeCd.Trim();
                this.uLabel_SalesEmployeeNm.Text = salesSlip.SalesEmployeeNm.Trim();
                // 得意先
                this.tNedit_CustomerCode.SetInt(salesSlip.CustomerCode);
                //this.tEdit_CustomerName.Text = salesSlip.CustomerName + salesSlip.CustomerName2; // DEL 2011/02/14
                this.tEdit_CustomerName.Text = salesSlip.CustomerSnm; // ADD 2011/02/14
                // 得意先情報表示
                this.SetDisplayCustomerInfo(salesSlip.CustomerCode);
                // 売上日
                this.tDateEdit_SalesDate.SetDateTime(salesSlip.SalesDate);
                // 見積有効期限
                this.tDateEdit_EstimateValidityDate.SetDateTime(salesSlip.EstimateValidityDate);
                // 検索モード
                this.uLabel_PartsSearchMode.Text = (salesSlip.SearchMode == (int)EstimateInputAcs.SearchMode.BLSearch) ? ctSearchMode_BLSearch : ctSearchMode_GoodsNoSearch;
                // 型式/モデムプレート
                this.uButton_ChangeSearchCarMode.Text = (salesSlip.SearchCarMode == (int)EstimateInputAcs.SearchCarMode.FullModelSearch) ? ctSearchCarMode_FullModel : ctSearchCarMode_ModelPlate;

                if (salesSlip.InputMode == EstimateInputAcs.ctINPUTMODE_Estimate_ReadOnly)
                {
                    this.tEdit_SectionCode.Enabled = false;
                    this.tNedit_SubSectionCode.Enabled = false;
                    this.tNedit_SalesSlipNum.Enabled = false;
                    this.tEdit_SalesEmployeeCd.Enabled = false;
                    this.tNedit_CustomerCode.Enabled = false;
                    this.tEdit_CustomerName.Enabled = false;
                    this.tEdit_CarMngCode.Enabled = false;
                    this.tNedit_ModelDesignationNo.Enabled = false;
                    this.tNedit_CategoryNo.Enabled = false;
                    this.tEdit_EngineModelNm.Enabled = false;
                    this.tEdit_FullModel.Enabled = false;
                    this.tNedit_MakerCode.Enabled = false;
                    this.tNedit_ModelCode.Enabled = false;
                    this.tNedit_ModelSubCode.Enabled = false;
                    this.tEdit_ModelFullName.Enabled = false;
                    this.tEdit_ProduceFrameNo.Enabled = false;
                    this.tEdit_ColorNo.Enabled = false;
                    this.tEdit_TrimNo.Enabled = false;
                }

                else
                {
                    this.tEdit_SectionCode.Enabled = true;
                    this.tNedit_SubSectionCode.Enabled = true;
                    this.tNedit_SalesSlipNum.Enabled = true;
                    this.tEdit_SalesEmployeeCd.Enabled = true;
                    this.tNedit_CustomerCode.Enabled = true;
                    this.tEdit_CustomerName.Enabled = true;
                    this.tEdit_CarMngCode.Enabled = true;
                    this.tNedit_ModelDesignationNo.Enabled = true;
                    this.tNedit_CategoryNo.Enabled = true;
                    this.tEdit_EngineModelNm.Enabled = true;
                    this.tEdit_FullModel.Enabled = true;
                    this.tNedit_MakerCode.Enabled = true;
                    this.tNedit_ModelCode.Enabled = true;
                    this.tNedit_ModelSubCode.Enabled = true;
                    this.tEdit_ModelFullName.Enabled = true;
                    this.tEdit_ProduceFrameNo.Enabled = true;
                    this.tEdit_ColorNo.Enabled = true;
                    this.tEdit_TrimNo.Enabled = true;

                    if ((salesSlip.AccRecDivCd == 0) || (salesSlip.CustomerCode == 0))
                    {
                        this.tEdit_CustomerName.Enabled = true;
                    }
                    else
                    {
                        this.tEdit_CustomerName.Enabled = false;
                    }
                }


                // カラー・トリム・装備情報
                if (((this._carOtherInfoInput.ColorCdInfoDataTable != null) &&
                      (this._carOtherInfoInput.ColorCdInfoDataTable.Count != 0)) ||
                    ((this._carOtherInfoInput.TrimCdInfoDataTable != null) &&
                      (this._carOtherInfoInput.TrimCdInfoDataTable.Count != 0)) ||
                    ((this._carOtherInfoInput.CEqpDefDspInfoDataTable != null) &&
                      (this._carOtherInfoInput.CEqpDefDspInfoDataTable.Count != 0)))
                {
                    // --- UPD 2011/02/14 ------- >>>>>>>
                    this.uExpandableGroupBox_CarInfo.Enabled = true;

                    if (this.tEdit_FullModel.Enabled == false)
                    {
                        this._carOtherInfoInput.uGrid_ColorInfoEnableSet(false);
                        this._carOtherInfoInput.uGrid_EquipInfoEnableSet(false);
                        this._carOtherInfoInput.uGrid_TrimInfoEnableSet(false);
                    }
                    else
                    {
                        this._carOtherInfoInput.uGrid_ColorInfoEnableSet(true);
                        this._carOtherInfoInput.uGrid_EquipInfoEnableSet(true);
                        this._carOtherInfoInput.uGrid_TrimInfoEnableSet(true);
                    }
                    // --- UPD 2011/02/14 ------- <<<<<<<
                }
                else
                {
                    this.uExpandableGroupBox_CarInfo.Enabled = false;
                    this.uExpandableGroupBox_CarInfo.Expanded = false;
                }

#if false
				this.tEdit_StockAgentCode.Text = salesSlip.StockAgentCode.Trim();
				this.uLabel_StockAgentName.Text = salesSlip.StockAgentName;
				this.tNedit_SupplierSlipNo.SetInt(salesSlip.SupplierSlipNo);
				ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_SupplierFormal, salesSlip.SupplierFormal, true);
				ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_SupplierSlipDisplay, salesSlip.SupplierSlipDisplay, true);
				ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_SupplierSlipCd, salesSlip.SupplierSlipCd, true);
				ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_StockGoodsCd, salesSlip.StockGoodsCd, true);
				ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_AccPayDivCd, salesSlip.AccPayDivCd, true);
				this.tNedit_SupplierCode.SetInt(salesSlip.SupplierCd);
				this.uLabel_SupplierName.Text = salesSlip.SupplierNm1 + " " + salesSlip.SupplierNm2;
				this.tEdit_WarehouseCode.Text = salesSlip.WarehouseCode.Trim();
				this.uLabel_WarehouseName.Text = salesSlip.WarehouseName;
				this.tDateEdit_ArrivalGoodsDay.SetDateTime(salesSlip.ArrivalGoodsDay);
				this.tDateEdit_StockDate.SetDateTime(salesSlip.StockDate);
				this.tEdit_PartySaleSlipNum.Text = salesSlip.PartySaleSlipNum;
				this._stockSlipInputInitDataAcs.SetSectionComboEditorValue(this._sectionComboBox, salesSlip.StockSectionCd);

				this.tEdit_SupplierSlipNote1.Text = salesSlip.SupplierSlipNote1;
				this.tEdit_SupplierSlipNote2.Text = salesSlip.SupplierSlipNote2;

				if (salesSlip.RetGoodsReasonDiv == 0)
				{
					this.tComboEditor_RetGoodsReason.Text = salesSlip.RetGoodsReason;
				}
				else
				{
					ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_RetGoodsReason, salesSlip.RetGoodsReasonDiv, false);
				}

				switch (salesSlip.ConsTaxLayMethod)
				{
					case 0:
						{
							this.uLabel_ConsTaxLayMethodTitle.Text = "(伝票毎)";
							break;
						}
					case 1:
						{
							this.uLabel_ConsTaxLayMethodTitle.Text = "(明細毎)";
							break;
						}
					case 2:
						{
							this.uLabel_ConsTaxLayMethodTitle.Text = "(請求毎)";
							break;
						}
				}

				ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_TotalAmountDispWayCd, salesSlip.TotalAmountDispWayCd, true);

				if (salesSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Return)
				{
					this.uLabel_InputModeTitle.Text = "返品";
				}
				else if (salesSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red)
				{
					this.uLabel_InputModeTitle.Text = "赤伝";
				}
				else if (salesSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ArrivalAddUp)
				{
					this.uLabel_InputModeTitle.Text = "入荷計上";
				}
				else if (salesSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly)
				{
					if (salesSlip.DebitNoteDiv == 2)
					{
						this.uLabel_InputModeTitle.Text = "元黒";
					}
					else if (salesSlip.TrustAddUpSpCd == 2)
					{
						this.uLabel_InputModeTitle.Text = "売上済";
					}
					else
					{
						this.uLabel_InputModeTitle.Text = "編集不可";
					}
				}
				else if (salesSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp)
				{
					this.uLabel_InputModeTitle.Text = "締済み";
				}
				else
				{
					this.uLabel_InputModeTitle.Text = "通常";
				}

				// 伝票区分が返品の場合は返品理由を表示、売上タブを非表示
				if (salesSlip.SupplierSlipCd == 20)
				{
					this.uLabel_ReturnReasonTitle.Visible = true;
					this.tComboEditor_RetGoodsReason.Visible = true;
					//if (this.Footer_UTabControl.SelectedTab == this.Footer_UTabControl.Tabs[MAKON01110UH.ctTAB_KEY_SalesInfo])
					//{
					//    this.Footer_UTabControl.SelectedTab = this.Footer_UTabControl.Tabs[ctTAB_KEY_StockInfo];
					//}
				}
				else
				{
					this.uLabel_ReturnReasonTitle.Visible = false;
					this.tComboEditor_RetGoodsReason.Visible = false;
				}

				// 一旦全てのコントロールを入力可能とする
				this.panel_Footer.Enabled = true;
				this._stockSlipInputInitDataAcs.EnabledSettingSectionComboEditor(ref this._sectionComboBox, false);

				this.tEdit_StockAgentCode.Enabled = true;
				this.uButton_EmployeeGuide.Enabled = true;
				this.tNedit_SupplierSlipNo.Enabled = true;
				this.uButton_SupplierSlipGuide.Enabled = true;
				this.tComboEditor_SupplierFormal.Enabled = true;
				this.tComboEditor_SupplierSlipCd.Enabled = true;
				this.tComboEditor_StockGoodsCd.Enabled = true;
				this.tComboEditor_AccPayDivCd.Enabled = true;
				this.tComboEditor_SupplierSlipDisplay.Enabled = true;
				this.tComboEditor_PriceCostUpdtDiv.Enabled = true;
				this.tNedit_SupplierCode.Enabled = true;
				this.uButton_SupplierGuideGuide.Enabled = true;
				this.tEdit_WarehouseCode.Enabled = true;
				this.uButton_WarehouseGuide.Enabled = true;
				this.tDateEdit_ArrivalGoodsDay.Enabled = true;
				this.tEdit_PartySaleSlipNum.Enabled = true;
				this.tEdit_SupplierSlipNote1.Enabled = true;
				this.tEdit_SupplierSlipNote2.Enabled = true;
				this.tNedit_ConsTaxRate.Enabled = true;

					//this._stockSlipDetailInput.Enabled = true;

					if (salesSlip.ConsTaxLayMethod == 2)
					{
						// 請求転嫁の場合は総額表示方法区分を「0:総額表示しない」固定とする
						this.tComboEditor_TotalAmountDispWayCd.Enabled = false;
					}
					else
					{
						this.tComboEditor_TotalAmountDispWayCd.Enabled = true;
					}

					// 入力モードが「参照モード」の場合は、全て入力不可とする
					// 入力モードが「締済みモード」の場合は、赤伝以外入力不可とする
					if (( salesSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
						( salesSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ))
					{
						this.tEdit_StockAgentCode.Enabled = false;
						this.uButton_EmployeeGuide.Enabled = false;
						this.tNedit_SupplierSlipNo.Enabled = false;
						this.tComboEditor_SupplierFormal.Enabled = false;
						this.tComboEditor_SupplierSlipCd.Enabled = false;
						this.tComboEditor_StockGoodsCd.Enabled = false;
						this.tComboEditor_AccPayDivCd.Enabled = false;
						this.tComboEditor_SupplierSlipDisplay.Enabled = false;
						this.tNedit_SupplierCode.Enabled = false;
						this.uButton_SupplierGuideGuide.Enabled = false;
						this.tEdit_WarehouseCode.Enabled = false;
						this.uButton_WarehouseGuide.Enabled = false;
						this.tDateEdit_ArrivalGoodsDay.Enabled = false;
						stockDateEnabled = false;
						this.tEdit_PartySaleSlipNum.Enabled = false;
						this.tEdit_SupplierSlipNote1.Enabled = false;
						this.tEdit_SupplierSlipNote2.Enabled = false;
						this.tNedit_ConsTaxRate.Enabled = false;

						this.panel_Footer.Enabled = false;
						this._stockSlipInputInitDataAcs.EnabledSettingSectionComboEditor(ref this._sectionComboBox, false);
					}
					// 入力モードが「返品入力モード」の場合は、「仕入形式」「伝票区分」「商品区分」「買掛区分」を変更不可とする
					else if (salesSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Return)
					{
						this.tComboEditor_SupplierFormal.Enabled = false;
						this.tComboEditor_SupplierSlipCd.Enabled = false;
						this.tComboEditor_StockGoodsCd.Enabled = false;
						this.tComboEditor_AccPayDivCd.Enabled = false;
						this.tComboEditor_SupplierSlipDisplay.Enabled = false;
						this.tNedit_ConsTaxRate.Enabled = false;
						this.tComboEditor_TotalAmountDispWayCd.Enabled = false;
						this._stockSlipInputInitDataAcs.EnabledSettingSectionComboEditor(ref this._sectionComboBox, false);
					}
					// 入力モードが「赤伝入力モード」の場合は、「仕入形式」「伝票区分」「商品区分」「買掛区分」「仕入先」「倉庫」「明細」を変更不可とする
					else if (salesSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red)
					{
						this.tComboEditor_SupplierFormal.Enabled = false;
						this.tComboEditor_SupplierSlipCd.Enabled = false;
						this.tComboEditor_StockGoodsCd.Enabled = false;
						this.tComboEditor_AccPayDivCd.Enabled = false;
						this.tComboEditor_SupplierSlipDisplay.Enabled = false;
						this.tNedit_SupplierCode.Enabled = false;
						this.uButton_SupplierGuideGuide.Enabled = false;
						this.tEdit_WarehouseCode.Enabled = false;
						this.uButton_WarehouseGuide.Enabled = false;
						this.tNedit_ConsTaxRate.Enabled = false;
						this.tComboEditor_TotalAmountDispWayCd.Enabled = false;
						this._stockSlipInputInitDataAcs.EnabledSettingSectionComboEditor(ref this._sectionComboBox, false);
					}
					// 入力モードが「在庫状態変更済み仕入伝票編集モード」の場合は、「仕入形式」「伝票区分」「商品区分」「買掛区分」「仕入先」を変更不可とする
					else if (salesSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ChangeStockStatus)
					{
						this.tComboEditor_SupplierFormal.Enabled = false;
						this.tComboEditor_SupplierSlipCd.Enabled = false;
						this.tComboEditor_StockGoodsCd.Enabled = false;
						this.tComboEditor_AccPayDivCd.Enabled = false;
						this.tComboEditor_SupplierSlipDisplay.Enabled = false;
						this.tNedit_SupplierCode.Enabled = false;
						this.uButton_SupplierGuideGuide.Enabled = false;
						this.tNedit_ConsTaxRate.Enabled = false;
						this.tComboEditor_TotalAmountDispWayCd.Enabled = false;
						this._stockSlipInputInitDataAcs.EnabledSettingSectionComboEditor(ref this._sectionComboBox, false);
					}
					else
					{
						// 仕入伝票番号が入力されている場合は「仕入形式」「伝票区分」「商品区分」「買掛区分」を入力不可とする
						if (salesSlip.SupplierSlipNo != 0)
						{
							this.tComboEditor_SupplierFormal.Enabled = false;
							this.tComboEditor_SupplierSlipCd.Enabled = false;
							this.tComboEditor_StockGoodsCd.Enabled = false;
							this.tComboEditor_AccPayDivCd.Enabled = false;
							this.tComboEditor_SupplierSlipDisplay.Enabled = false;
							this._stockSlipInputInitDataAcs.EnabledSettingSectionComboEditor(ref this._sectionComboBox, false);
						}
						else
						{
							// 仕入形式が「1:入荷」の場合は「買掛区分」入力不可とする。
							if (salesSlip.SupplierFormal == 1)
							{
								this.tComboEditor_AccPayDivCd.Enabled = false;
							}
						}

						if (salesSlip.StockGoodsCd == 6)
						{
							canDetailInput = false;
						}
						else
						{
							canDetailInput = true;
						}

					}

					// 仕入形式が「1:入荷」の場合は「計上日」を入力不可とする
					if (salesSlip.SupplierFormal == 1)
					{
						//this.tDateEdit_StockDate.Enabled = false;
						stockDateEnabled = false;
						paymentConfirmationEnabled = false;
					}

					// 仕入伝票番号が入力されている場合は「仕入伝票番号」を入力不可とする
					if (salesSlip.SupplierSlipNo != 0)
					{
						this.tNedit_SupplierSlipNo.Enabled = false;
					}

#endif

                // 伝票番号が入力されている場合は「仕入伝票番号」を入力不可とする
                if (salesSlip.SalesSlipNum != EstimateInputAcs.ctDefaultSalesSlipNum)
                {
                    this.tNedit_SalesSlipNum.Enabled = false;
                }

                if (salesSlip.CarMngDivCd == 0)
                {
                    // --- UPD 2009/09/08 ---------->>>>>
                    this.tEdit_CarMngCode.Enabled = true;
                    this.uButton_CarMngNoGuide.Enabled = true;
                    // --- UPD 2009/09/08 ----------<<<<<
                }
                // --- ADD 2009/09/08 ---------->>>>>
                else if (salesSlip.CarMngDivCd == 3)
                {
                    this.uButton_CarMngNoGuide.Enabled = false;
                }
                // --- ADD 2009/09/08 ----------<<<<<
                else
                {
                    this.tEdit_CarMngCode.Enabled = true;
                    this.uButton_CarMngNoGuide.Enabled = true;
                }

                // 車種コード、車種サブコード
                if (this.tNedit_MakerCode.GetInt() == 0)
                {
                    this.tNedit_ModelCode.Enabled = false;
                    this.tNedit_ModelSubCode.Enabled = false;
                }
                else if (this.tNedit_ModelCode.GetInt() == 0)
                {
                    this.tNedit_ModelSubCode.Enabled = false;
                }

                if (salesSlip.SearchMode == (int)EstimateInputAcs.SearchMode.BLSearch)
                {
                    this.uButton_ChangeSearchCarMode.Enabled = true;
                    this.tEdit_ModelFullName.Enabled = false;
                }
                else
                {
                    //this.tEdit_ModelFullName.Enabled = false;

                    this.uButton_ChangeSearchCarMode.Enabled = false;
                    if (salesSlip.SearchCarMode == (int)EstimateInputAcs.SearchCarMode.ModelPlateSearch) this.ChangeCarSearchMode(ref salesSlip, false);
                }

                if (this._estimateInputInitDataAcs.GetSalesTtlSt().SectDspDivCd == 2)
                {
                    this.tEdit_SectionCode.Enabled = false;
                }

                // 車輌データ既存更新の場合、車輌項目無効
                double acceptAnOrderNo = (double)this.tNedit_AcceptAnOrderNo.GetValue();
                if (acceptAnOrderNo != 0)
                {
                    // --- UPD 2011/02/14 ---------->>>>>
                    //this.panel_CarInfo.Enabled = false;
                    this.SettingPanelCarInfo(false);
                    // --- UPD 2011/02/14 ----------<<<<<
                }

                // 自社情報設定マスタで「部署管理区分」が「0:拠点」の場合は部門非表示
                if (this._estimateInputInitDataAcs.GetCompanyInf().SecMngDiv == 0)
                {
                    this.tNedit_SubSectionCode.Visible = false;
                    this.uLabel_SubSectionName.Visible = false;
                    this.uButton_SubSectionGuide.Visible = false;
                    this.uLabel_SubSectionTitle.Visible = false;
                }
                // 2009.03.26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                else
                {
                    this.tNedit_SubSectionCode.Visible = true;
                    this.uLabel_SubSectionName.Visible = true;
                    this.uButton_SubSectionGuide.Visible = true;
                    this.uLabel_SubSectionTitle.Visible = true;
                }
                // 2009.03.26 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            finally
            {
                //this.tDateEdit_StockDate.Enabled = stockDateEnabled;
                //this.uButton_PaymentConfirmation.Enabled = paymentConfirmationEnabled;
                //this._estimateDetailInput.Enabled = canDetailInput;

                //// 各コントロールの描画を一時的に停止させる
                this.tEdit_SectionCode.EndUpdate();
                this.tNedit_SubSectionCode.EndUpdate();
                this.tNedit_SalesSlipNum.EndUpdate();
                this.tEdit_SalesEmployeeCd.EndUpdate();
                this.tNedit_CustomerCode.EndUpdate();
                this.tEdit_CustomerName.EndUpdate();

                this.tEdit_CarMngCode.EndUpdate();
                this.tNedit_ModelDesignationNo.EndUpdate();
                this.tNedit_CategoryNo.EndUpdate();
                this.tEdit_EngineModelNm.EndUpdate();
                this.tEdit_FullModel.EndUpdate();
                this.tNedit_MakerCode.EndUpdate();
                this.tNedit_ModelCode.EndUpdate();
                this.tNedit_ModelSubCode.EndUpdate();
                this.tEdit_ModelFullName.EndUpdate();
                this.tEdit_ProduceFrameNo.EndUpdate();
                this.tEdit_ColorNo.EndUpdate();
                this.tEdit_TrimNo.EndUpdate();
                this.uButton_ChangeSearchCarMode.EndUpdate();

                // ツールバーボタン有効無効設定処理
                this.SettingToolBarButtonEnabled();
                this.SettingToolBarButtonEnabled_Detail();
            }
        }

        /// <summary>
        /// 得意先情報画面格納処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        private void SetDisplayCustomerInfo(int customerCode)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            if (this._customerInfoAcs == null) this._customerInfoAcs = new CustomerInfoAcs();
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerCode, true, false, out customerInfo);
            this.SetDisplayCustomerInfo(customerInfo);
        }

        /// <summary>
        /// 得意先情報画面格納処理
        /// </summary>
        /// <param name="customerInfo">得意先情報データクラス</param>
        private void SetDisplayCustomerInfo(CustomerInfo customerInfo)
        {
            if (customerInfo != null)
            {
                // 得意先名称
                if (customerInfo.AccRecDivCd != 0) // 0:現金 1:売掛
                {
                    this.tEdit_CustomerName.Enabled = false;
                }
                else
                {
                    this.tEdit_CustomerName.Enabled = true;
                }
            }
            else
            {
                // 得意先名称
                this.tEdit_CustomerName.Enabled = false;
            }
        }


        /// <summary>
        /// 画面表示処理（車輌情報）
        /// </summary>
        /// <param name="row"></param>
        /// <br>Update Note: 2009/09/08       汪千来</br>
        ///	<br>		   : 管理番号を修正する</br>
        private void SetDisplayCarInfo(EstimateInputDataSet.CarInfoRow row, CarSearchType searchType)
        {
            if (row == null) return;

            try
            {
                this.tEdit_CarMngCode.BeginUpdate();
                this.tNedit_ModelDesignationNo.BeginUpdate();
                this.tNedit_CategoryNo.BeginUpdate();
                this.tEdit_EngineModelNm.BeginUpdate();
                this.tEdit_FullModel.BeginUpdate();
                this.tNedit_MakerCode.BeginUpdate();
                this.tNedit_ModelCode.BeginUpdate();
                this.tNedit_ModelSubCode.BeginUpdate();
                this.tEdit_ModelFullName.BeginUpdate();
                this.tEdit_ProduceFrameNo.BeginUpdate();
                this.tEdit_ColorNo.BeginUpdate();
                this.tEdit_TrimNo.BeginUpdate();
                this._carOtherInfoInput.uGrid_ColorInfo.BeginUpdate();
                this._carOtherInfoInput.uGrid_EquipInfo.BeginUpdate();
                this._carOtherInfoInput.uGrid_TrimInfo.BeginUpdate();

                this.tNedit_AcceptAnOrderNo.SetInt(row.AcceptAnOrderNo); // 受注番号

                //this.tEdit_CarMngCode.Enabled = false;
                //this.tNedit_ModelDesignationNo.Enabled = false;
                //this.tNedit_CategoryNo.Enabled = false;
                //this.tEdit_EngineModelNm.Enabled = false;
                //this.tEdit_FullModel.Enabled = false;
                //this.tNedit_MakerCode.Enabled = false;
                //this.tNedit_ModelCode.Enabled = false;
                //this.tNedit_ModelSubCode.Enabled = false;
                //this.tEdit_ModelFullName.Enabled = false;
                //this.tNedit_ProduceFrameNo.Enabled = false;
                //this.tEdit_ColorNo.Enabled = false;
                //this.tEdit_TrimNo.Enabled = false;
                //this._carOtherInfoInput.uGrid_ColorInfo.Enabled = false;
                //this._carOtherInfoInput.uGrid_EquipInfo.Enabled = false;
                //this._carOtherInfoInput.uGrid_TrimInfo.Enabled = false;

                // --- ADD 2012/09/07 Y.Wakita ---------->>>>>
                if (this.tNedit_CustomerCode.Text == "")
                {
                    row.CustomerCode = 0;                                           // 得意先コード
                }
                else
                {
                    row.CustomerCode = int.Parse(this.tNedit_CustomerCode.Text);    // 得意先コード
                }
                // --- ADD 2012/09/07 Y.Wakita ----------<<<<<
                this.tNedit_ModelDesignationNo.SetInt(row.ModelDesignationNo);      // 型式指定番号
                this.tNedit_CategoryNo.SetInt(row.CategoryNo);                      // 類別区分番号

                // --- UPD 2009/09/08 ---------->>>>>
                //this.tEdit_CarMngCode.Text = "";                                      // 管理番号
                this.tEdit_CarMngCode.Text = row.CarMngCode;                        // 管理番号
                // --- UPD 2009/09/08 ----------<<<<<

                this.tEdit_FullModel.Text = row.FullModel;                          // 型式
                this.tEdit_EngineModelNm.Text = row.EngineModelNm;                  // エンジン型式
                this.tNedit_MakerCode.SetInt(row.MakerCode);                        // カーメーカーコード
                this.tNedit_ModelCode.SetInt(row.ModelCode);                        // 車種コード
                this.tNedit_ModelSubCode.SetInt(row.ModelSubCode);                  // 車種呼称コード
                this.tEdit_ModelFullName.Text = row.ModelFullName;                  // 車種名称

                this.tDateEdit_FirstEntryDate.Clear();
                if (row.ProduceTypeOfYearInput != 0) this.tDateEdit_FirstEntryDate.SetLongDate(row.ProduceTypeOfYearInput * 100 + 1); // 年式
                string stProduceTypeOfYear = this.GetProduceTypeOfYear(row.StProduceTypeOfYear);
                string edProduceTypeOfYear = this.GetProduceTypeOfYear(row.EdProduceTypeOfYear);
                this.SettingProduceTypeOfYearRange(stProduceTypeOfYear, edProduceTypeOfYear);

                // --- DEL 2013/03/21 ---------->>>>>
                //this.tEdit_ProduceFrameNo.SetInt(row.ProduceFrameNoInput);         // 車台番号
                // --- DEL 2013/03/21 ----------<<<<<
                // PMNS:車台番号切り替え
                // --- ADD 2013/03/21 ---------->>>>>
                // 国産/外車区分が外車(2)の場合に、表示をVINコードに切り替える
                // 外車以外の場合は車台番号を表示する
                if (row.DomesticForeignCode == 2)
                {
                    this.uLabel_ProduceFrameNoTitle.Text = "VINｺｰﾄﾞ";
                    // --- DEL 2014/11/17 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------>>>>>
                    //this.uLabel_ProduceFrameNoTitle.Size = new Size(80, 24);
                    // --- DEL 2014/11/17 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------<<<<<
                    this.uLabel_ProduceFrameNoRange.Visible = false;
                    // --- DEL 2014/11/17 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------>>>>>
                    //this.tEdit_ProduceFrameNo.Size = new Size(120, 24);
                    //this.tEdit_ProduceFrameNo.ExtEdit.Column = 17;
                    // --- DEL 2014/11/17 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------<<<<<
                    // --- ADD 2014/11/19 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------>>>>>
                    this.tEdit_ProduceFrameNo.ExtEdit.Column = 17;
                    // --- ADD 2014/11/19 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------<<<<<
                    this.tEdit_ProduceFrameNo.ExtEdit.EnableChars.Alpha = true;
                }
                else
                {
                    this.uLabel_ProduceFrameNoTitle.Text = "車台番号";
                    // --- DEL 2014/11/17 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------>>>>>
                    //this.uLabel_ProduceFrameNoTitle.Size = new Size(67, 24);
                    // --- DEL 2014/11/17 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------<<<<<
                    this.uLabel_ProduceFrameNoRange.Visible = true;
                    // --- DEL 2014/11/17 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------>>>>>
                    //this.tEdit_ProduceFrameNo.Size = new Size(76, 24);
                    //this.tEdit_ProduceFrameNo.ExtEdit.Column = 8;
                    // --- DEL 2014/11/17 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------<<<<<
                    // --- ADD 2014/11/19 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------>>>>>
                    this.tEdit_ProduceFrameNo.ExtEdit.Column = 8;
                    // --- ADD 2014/11/19 鹿庭 仕掛一覧 №10598 システム障害No.22 ------------------------------<<<<<
                    this.tEdit_ProduceFrameNo.ExtEdit.EnableChars.Alpha = false;
                }
                // 車台番号/VINコードの値をテキストボックスに表示する
                this.tEdit_ProduceFrameNo.Text = row.FrameNo;
                // --- ADD 2013/03/21 ----------<<<<<
                string stProduceFrameNo = (row.StProduceFrameNo != 0) ? string.Format("{0,8:########}", row.StProduceFrameNo) : string.Empty;
                string edProduceFrameNo = (row.EdProduceFrameNo != 0) ? string.Format("{0,8:########}", row.EdProduceFrameNo) : string.Empty;
                this.SettingProduceFrameNoRange(stProduceFrameNo, edProduceFrameNo);

                // カラー情報
                this._carOtherInfoInput.ColorCdInfoDataTable = this._estimateInputAcs.GetColorInfo(row.CarRelationGuid);

                // カラー
                PMKEN01010E.ColorCdInfoRow colorInfoRow = this._estimateInputAcs.GetSelectColorInfo(row.CarRelationGuid);
                if (colorInfoRow != null)
                {
                    this.tEdit_ColorNo.Text = colorInfoRow.ColorCode;
                }
                else
                {
                    this.tEdit_ColorNo.Text = string.Empty;
                    // --- ADD 2012/09/07 Y.Wakita ---------->>>>>
                    if (row.ColorCode != "")
                    {
                        this.tEdit_ColorNo.Text = row.ColorCode;
                    }
                    // --- ADD 2012/09/07 Y.Wakita ----------<<<<<
                }

                // トリム情報
                this._carOtherInfoInput.TrimCdInfoDataTable = this._estimateInputAcs.GetTrimInfo(row.CarRelationGuid);

                // トリム
                PMKEN01010E.TrimCdInfoRow trimInfoRow = this._estimateInputAcs.GetSelectTrimInfo(row.CarRelationGuid);
                if (trimInfoRow != null)
                {
                    this.tEdit_TrimNo.Text = trimInfoRow.TrimCode;
                }
                else
                {
                    this.tEdit_TrimNo.Text = string.Empty;
                    // --- ADD 2012/09/07 Y.Wakita ---------->>>>>
                    if (row.TrimCode != "")
                    {
                        this.tEdit_TrimNo.Text = row.TrimCode;
                    }
                    // --- ADD 2012/09/07 Y.Wakita ----------<<<<<
                }

                // 諸元情報
                EstimateInputDataSet.CarSpecRow carSpecRow = this._carSpecDataTable[0];
                this._estimateInputAcs.SetCarSpecFromCarInfoRow(ref carSpecRow, row);
                this.SettingCarSpecGridCol(row);


                // 装備情報
                this._carOtherInfoInput.CEqpDefDspInfoDataTable = this._estimateInputAcs.GetEquipInfo(row.CarRelationGuid);
                this._carOtherInfoInput.SettingEquipGridLayout();

                // 車輌情報共通キー
                this._carOtherInfoInput.CarRelationGuid = row.CarRelationGuid;

                // 前回車輌情報共通キー(保持用)
                this._estimateInputAcs.BeforeCarRelationGuid = row.CarRelationGuid;

                // --- ADD 2009/09/08 ---------->>>>>
                // カラー・トリム・装備情報
                if (((this._carOtherInfoInput.ColorCdInfoDataTable != null) &&
                     (this._carOtherInfoInput.ColorCdInfoDataTable.Count != 0)) ||
                    ((this._carOtherInfoInput.TrimCdInfoDataTable != null) &&
                     (this._carOtherInfoInput.TrimCdInfoDataTable.Count != 0)) ||
                    ((this._carOtherInfoInput.CEqpDefDspInfoDataTable != null) &&
                     (this._carOtherInfoInput.CEqpDefDspInfoDataTable.Count != 0)))
                {
                    // --- UPD 2011/02/14 ------- >>>>>>>
                    this.uExpandableGroupBox_CarInfo.Enabled = true;

                    if (this.tEdit_FullModel.Enabled == false)
                    {
                        this._carOtherInfoInput.uGrid_ColorInfoEnableSet(false);
                        this._carOtherInfoInput.uGrid_EquipInfoEnableSet(false);
                        this._carOtherInfoInput.uGrid_TrimInfoEnableSet(false);
                    }
                    else
                    {
                        this._carOtherInfoInput.uGrid_ColorInfoEnableSet(true);
                        this._carOtherInfoInput.uGrid_EquipInfoEnableSet(true);
                        this._carOtherInfoInput.uGrid_TrimInfoEnableSet(true);
                    }
                    // --- UPD 2011/02/14 ------- <<<<<<<
                }
                else
                {
                    this.uExpandableGroupBox_CarInfo.Enabled = false;
                    this.uExpandableGroupBox_CarInfo.Expanded = false;
                }
                // --- ADD 2009/09/08 ----------<<<<<
            }
            finally
            {
                //this.tEdit_CarMngCode.Enabled = true;
                //this.tNedit_ModelDesignationNo.Enabled = true;
                //this.tNedit_CategoryNo.Enabled = true;
                //this.tEdit_EngineModelNm.Enabled = true;
                //this.tEdit_FullModel.Enabled = true;
                //this.tNedit_MakerCode.Enabled = true;
                //this.tNedit_ModelCode.Enabled = true;
                //this.tNedit_ModelSubCode.Enabled = true;
                //this.tEdit_ModelFullName.Enabled = true;
                //this.tNedit_ProduceFrameNo.Enabled = true;
                //this.tEdit_ColorNo.Enabled = true;
                //this.tEdit_TrimNo.Enabled = true;
                //this._carOtherInfoInput.uGrid_ColorInfo.Enabled = true;
                //this._carOtherInfoInput.uGrid_EquipInfo.Enabled = true;
                //this._carOtherInfoInput.uGrid_TrimInfo.Enabled = true;

                this.tEdit_CarMngCode.EndUpdate();
                this.tNedit_ModelDesignationNo.EndUpdate();
                this.tNedit_CategoryNo.EndUpdate();
                this.tEdit_EngineModelNm.EndUpdate();
                this.tEdit_FullModel.EndUpdate();
                this.tNedit_MakerCode.EndUpdate();
                this.tNedit_ModelCode.EndUpdate();
                this.tNedit_ModelSubCode.EndUpdate();
                this.tEdit_ModelFullName.EndUpdate();
                this.tEdit_ProduceFrameNo.EndUpdate();
                this.tEdit_ColorNo.EndUpdate();
                this.tEdit_TrimNo.EndUpdate();
                this._carOtherInfoInput.uGrid_ColorInfo.EndUpdate();
                this._carOtherInfoInput.uGrid_EquipInfo.EndUpdate();
                this._carOtherInfoInput.uGrid_TrimInfo.EndUpdate();
            }
        }

        /// <summary>
        /// 画面表示処理（車輌情報）
        /// </summary>
        /// <param name="salesRowNo"></param>
        private void SetDisplayCarInfo(int salesRowNo, CarSearchType searchType)
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this._estimateInputAcs.GetCarInfoRow(salesRowNo, EstimateInputAcs.GetCarInfoMode.ExistGetMode);

            this.SetDisplayCarInfo(carInfoRow, searchType);
        }

        /// <summary>
        /// 画面表示処理（車両情報）
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面表示処理（車両情報）の内容をクリアします。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/09/08</br>
        /// </remarks>
        private void ClearDisplayCarInfo()
        {
            try
            {
                this._carOtherInfoInput.uGrid_EquipInfo.BeginUpdate();
                this._carOtherInfoInput.uGrid_ColorInfo.BeginUpdate();
                this._carOtherInfoInput.uGrid_TrimInfo.BeginUpdate();

                this.tNedit_AcceptAnOrderNo.Clear(); // 受注番号

                this.tNedit_ModelDesignationNo.Clear(); // 型式指定番号
                this.tNedit_CategoryNo.Clear();// 類別区分番号

                //this.tEdit_CarMngCode.Clear();// 管理番号
                this.tEdit_FullModel.Clear();// 型式
                this.tEdit_EngineModelNm.Clear();// エンジン型式
                this.tNedit_MakerCode.Clear();// カーメーカーコード
                this.tNedit_ModelCode.Clear();// 車種コード
                this.tNedit_ModelSubCode.Clear();// 車種呼称コード
                this.tEdit_ModelFullName.Clear();// 車種名称

                this.tDateEdit_FirstEntryDate.Clear(); // 年式
                this.uLabel_FirstEntryDateRange.Text = string.Empty; // 年式範囲

                this.tEdit_ProduceFrameNo.Clear();// 車台番号
                this.uLabel_ProduceFrameNoRange.Text = string.Empty; // 車台番号範囲

                // カラー情報
                if (this._carOtherInfoInput.ColorCdInfoDataTable != null) this._carOtherInfoInput.ColorCdInfoDataTable.Clear();

                this.tEdit_ColorNo.Clear();

                // トリム情報
                if (this._carOtherInfoInput.TrimCdInfoDataTable != null) this._carOtherInfoInput.TrimCdInfoDataTable.Clear();
                this.tEdit_TrimNo.Clear();

                // 諸元情報
                this.ClearCarSpecDataTable();

                // 装備情報
                if (this._carOtherInfoInput.CEqpDefDspInfoDataTable != null) this._carOtherInfoInput.CEqpDefDspInfoDataTable.Clear();
                this._carOtherInfoInput.SettingEquipGridLayout();

            }
            finally
            {
                this._carOtherInfoInput.uGrid_TrimInfo.EndUpdate();
                this._carOtherInfoInput.uGrid_ColorInfo.EndUpdate();
                this._carOtherInfoInput.uGrid_EquipInfo.EndUpdate();
            }
        }

        /// <summary>
        /// 諸元情報テーブルクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 諸元情報テーブルの内容をクリアします。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/09/08</br>
        /// </remarks>
        private void ClearCarSpecDataTable()
        {
            this._carSpecDataTable[0].AddiCarSpec1 = string.Empty;
            this._carSpecDataTable[0].AddiCarSpec2 = string.Empty;
            this._carSpecDataTable[0].AddiCarSpec3 = string.Empty;
            this._carSpecDataTable[0].AddiCarSpec4 = string.Empty;
            this._carSpecDataTable[0].AddiCarSpec5 = string.Empty;
            this._carSpecDataTable[0].AddiCarSpec6 = string.Empty;
            this._carSpecDataTable[0].BodyName = string.Empty;
            this._carSpecDataTable[0].DoorCount = 0;
            this._carSpecDataTable[0].EDivNm = string.Empty;
            this._carSpecDataTable[0].EngineDisplaceNm = string.Empty;
            this._carSpecDataTable[0].EngineModelNm = string.Empty;
            this._carSpecDataTable[0].ModelGradeNm = string.Empty;
            this._carSpecDataTable[0].ShiftNm = string.Empty;
            this._carSpecDataTable[0].TransmissionNm = string.Empty;
            this._carSpecDataTable[0].WheelDriveMethodNm = string.Empty;
        }

        /// <summary>
        /// 生産年式取得処理(和歴／西暦)
        /// </summary>
        /// <br>UpdateNote  : 2019/01/08  譚洪</br>
        /// <br>修正内容    : 新元号の対応</br>
        /// <param name="StProduceTypeOfYear"></param>
        /// <param name="EdProduceTypeOfYear"></param>
        private string GetProduceTypeOfYear(DateTime produceTypeOfYear)
        {
            string retYear = string.Empty;
            if (produceTypeOfYear != DateTime.MinValue)
            {
                if (this._estimateInputInitDataAcs.GetAllDefSet().EraNameDispCd1 == 0)
                {
                    // 0:西暦
                    int iyy = produceTypeOfYear.Year;
                    int imm = produceTypeOfYear.Month;
                    retYear = (produceTypeOfYear != DateTime.MinValue) ? string.Format(@"{0:0000}{1:\.00}", iyy, imm) : string.Empty;
                }
                else
                {
                    // 1:和歴
                    //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ---->>>>>
                    //System.Globalization.DateTimeFormatInfo FormatInfo = null;
                    //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("ja-JP");
                    //System.Globalization.Calendar calendar = new System.Globalization.JapaneseCalendar();
                    //culture.DateTimeFormat.Calendar = calendar;
                    //FormatInfo = culture.DateTimeFormat;
                    //FormatInfo.Calendar = calendar;

                    //retYear = produceTypeOfYear.ToString("gyy/MM/dd", culture);

                    //int Era = FormatInfo.Calendar.GetEra(produceTypeOfYear);
                    //string eraString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    //string eraName = string.Empty;
                    //string tempRetYear = string.Empty;
                    //tempRetYear = retYear.Substring(2, retYear.Length - 2);
                    //for (int eraCounter = 0; eraCounter < eraString.Length; eraCounter++)
                    //{
                    //    if (FormatInfo.GetEra(eraString[eraCounter].ToString()) == Era)
                    //    {
                    //        eraName = eraString[eraCounter].ToString();
                    //        break;
                    //    }
                    //}
                    //tempRetYear = eraName + tempRetYear;
                    //retYear = tempRetYear.Remove(tempRetYear.Length - 3);
                    //retYear = retYear.Replace('/', '.');

                    retYear = TDateTime.DateTimeToString("ggYY.MM", produceTypeOfYear);
                    //---- UPD 譚洪  2019/01/08 FOR 新元号の対応 ----<<<<<
                }
            }
            return retYear;
        }

        /// <summary>
        /// 生産年式範囲設定処理
        /// </summary>
        /// <param name="stProduceTypeOfYear"></param>
        /// <param name="edProduceTypeOfYear"></param>
        /// <returns></returns>
        private void SettingProduceTypeOfYearRange(string stProduceTypeOfYear, string edProduceTypeOfYear)
        {
            string retString = string.Empty;
            int maxLength = 7;

            stProduceTypeOfYear = stProduceTypeOfYear.PadRight(maxLength, ' ');
            edProduceTypeOfYear = edProduceTypeOfYear.PadRight(maxLength, ' ');
            if ((string.IsNullOrEmpty(stProduceTypeOfYear.Trim())) && (string.IsNullOrEmpty(edProduceTypeOfYear.Trim())))
            {
                this.uLabel_FirstEntryDateRange.Text = string.Empty;
            }
            else
            {
                this.uLabel_FirstEntryDateRange.Text = stProduceTypeOfYear + "-" + edProduceTypeOfYear;
            }
        }

        /// <summary>
        /// 車台番号範囲設定処理
        /// </summary>
        /// <param name="stProduceFrameNo"></param>
        /// <param name="edProduceFrameNo"></param>
        private void SettingProduceFrameNoRange(string stProduceFrameNo, string edProduceFrameNo)
        {
            string retString = string.Empty;
            int maxLength = 8;

            stProduceFrameNo = stProduceFrameNo.PadLeft(maxLength, ' ');
            edProduceFrameNo = edProduceFrameNo.PadLeft(maxLength, ' ');
            if ((string.IsNullOrEmpty(stProduceFrameNo.Trim())) && (string.IsNullOrEmpty(edProduceFrameNo.Trim())))
            {
                this.uLabel_ProduceFrameNoRange.Text = string.Empty;
            }
            else
            {
                this.uLabel_ProduceFrameNoRange.Text = stProduceFrameNo + "-" + edProduceFrameNo;
            }
        }

        /// <summary>
        /// 明細グリッド最上位行キーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void EstimateDetailInput_GridKeyDownTopRow(object sender, EventArgs e)
        {
            Control control = this.tEdit_FullModel;

            if (this.tEdit_FullModel.Enabled)
            {
                this.tEdit_FullModel.Focus();
                this.ActiveControl = tEdit_FullModel;
            }
            else if (this.tNedit_CustomerCode.Enabled)
            {
                this.tNedit_CustomerCode.Focus();
                this.ActiveControl = this.tNedit_CustomerCode;
            }
            else if (this.tEdit_SalesEmployeeCd.Enabled)
            {
                this.tEdit_SalesEmployeeCd.Focus();
                this.ActiveControl = this.tEdit_SalesEmployeeCd;
            }

            // ガイドボタンツール有効無効設定処理
            this.SettingGuideButtonToolEnabled(this.ActiveControl);

            this._prevControl = this.ActiveControl;
        }

        /// <summary>
        /// 詳細グリッド最下層行キーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void EstimateDetailInput_GridKeyDownButtomRow(object sender, EventArgs e)
        {
#if false
			Footer_UTabControl.SelectedTab = this.Footer_UTabControl.Tabs[0];

            this.tEdit_SupplierSlipNote1.Focus();

			// ガイドボタンツール有効無効設定処理
			this.SettingGuideButtonToolEnabled(this.tEdit_SupplierSlipNote1);

			this._prevControl = this.ActiveControl;
#endif
        }

        /// <summary>
        /// ステータスバーメッセージ表示イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        private void EstimateDetailInput_StatusBarMessageSetting(object sender, string message)
        {
            //this.uStatusBar_Main.Panels[0].Text = message;
        }

        /// <summary>
        /// フォーカスセッティングイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="itemName">項目名称</param>
        private void EstimateDetailInput_FocusSetting(object sender, string itemName)
        {
            if (itemName == PMMIT01010UB.ct_ITEM_NAME_CUSTOMERCODE)
            {
                this.tNedit_CustomerCode.Focus();
                this.ActiveControl = this.tNedit_CustomerCode;

                // ガイドボタンツール有効無効設定処理
                this.SettingGuideButtonToolEnabled(this.tNedit_CustomerCode);

                this._prevControl = this.ActiveControl;
            }
            else if (itemName == PMMIT01010UB.ct_ITEM_NAME_CARMNGCODE)
            {
                Control ctrl = this.tEdit_CarMngCode;
                if ((!ctrl.Enabled) || (!ctrl.Visible))
                {
                    ctrl = this.tNedit_ModelDesignationNo;
                }
                if (ctrl != null)
                {
                    ctrl.Focus();
                    this.ActiveControl = ctrl;
                    // ガイドボタンツール有効無効設定処理
                    this.SettingGuideButtonToolEnabled(ctrl);
                    this._prevControl = this.ActiveControl;
                }
            }
        }

        /// <summary>
        /// ガイドボタン有効無効設定処理（明細用）
        /// </summary>
        private void SettingGuideButtonTool_Detail()
        {
            this._canGuide = this._estimateDetailInput.GuideButtonEnabled;
            this.ParentToolbarLedgerSettingEventCall();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SettingToolBarButtonEnabled_Detail()
        {
            this._canShowSet = this._estimateDetailInput.SetButtonEnabled;

            this.ParentToolbarLedgerSettingEventCall();
            if ((this.ActiveControl == this._estimateDetailInput) || (this._estimateDetailInput.ContainsFocus))
            {
                this._canCopySlip = this._estimateDetailInput.EstimateReferenceButtonEnabled;
            }
#if false
			if (( this.ActiveControl == this._stockSlipDetailInput ) || ( this._stockSlipDetailInput.ContainsFocus ))
			{
				this._stockReferenceButton.SharedProps.Enabled = this._stockSlipDetailInput.StockReferenceButtonEnabled;
				this._arrivalAppropriateButton.SharedProps.Enabled = this._stockSlipDetailInput.ArrivalReferenceButtonEnabled;
				this._orderReferenceButton.SharedProps.Enabled = this._stockSlipDetailInput.OrderReferenceButtonEnabled;
			}
#endif
        }

        /// <summary>
        /// 関連データ変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void EstimateInputAcs_DataChanged(object sender, EventArgs e)
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
        private void EstimateInputConstructionAcs_DataChanged(object sender, EventArgs e)
        {
            // データ画面格納処理
            this.SetDisplay(this._estimateInputAcs.SalesSlip);
            this.SettingFocusDictionary();
        }

        /// <summary>
        /// ボタンツール有効無効設定処理
        /// </summary>
        /// <param name="nextControl">次のコントロール</param>
        private void SettingGuideButtonToolEnabled(Control nextControl)
        {
            if (nextControl == null) return;

            bool beforeCanGuide = this._canGuide;
            Control targetControl = nextControl;
            if (nextControl.Parent != null)
            {
                if ((nextControl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
                    (nextControl.Parent is Broadleaf.Library.Windows.Forms.TEdit))
                {
                    targetControl = nextControl.Parent;
                }
            }

            // 明細部にフォーカスがある時は明細画面に従って設定する
            if ((this._estimateDetailInput.Contains(targetControl)) || (targetControl == this._estimateDetailInput))
            {
                this.SettingGuideButtonTool_Detail();
            }
            else
            {
                if (this._estimateInputAcs.SalesSlip.InputMode == EstimateInputAcs.ctINPUTMODE_Estimate_ReadOnly)
                {
                    this._canGuide = false;
                    this._guideKey = "";
                }
                else
                {
                    if (this._guideEnableControlDictionary.ContainsKey(targetControl.Name))
                    {
                        this._guideKey = this._guideEnableControlDictionary[targetControl.Name];
                        // --- UPD 2009/09/08 -------------->>>
                        if (this.tEdit_CarMngCode.Name.Equals(targetControl.Name))
                        {
                            if (this._estimateInputInitDataAcs.Opt_CarMng)
                            {
                                this._canGuide = true;
                            }
                            else
                            {
                                this._canGuide = false;
                            }
                        }
                        else
                        {
                            this._canGuide = true;
                        }
                        // --- UPD 2009/09/08 --------------<<<
                    }
                    else
                    {
                        this._canGuide = false;
                        this._guideKey = "";
                    }
                }
            }

            // Enabledが変わった場合はフレーム通知
            if (this._canGuide != beforeCanGuide)
            {
                // 親にツールバー状態通知
                this.ParentToolbarLedgerSettingEventCall();
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
        /// 画面再描画
        /// </summary>
        private void RefreshScreen()
        {
            this.uLabel_BeforeSalesSlipNum.Text = this._estimateInputAcs.SalesSlip.SalesSlipNum.ToString().PadLeft(9, '0');
            try
            {
                this._estimateDetailInput.uGrid_Details.BeginUpdate();

                SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

                // 仕入データクラス→画面格納処理
                this.SetDisplay(salesSlip);
            }
            finally
            {
                this._estimateDetailInput.uGrid_Details.EndUpdate();
            }

            // 明細グリッド設定処理
            this._estimateDetailInput.SettingGrid();

            if (this._estimateInputConstructionAcs.SaveInfoStoreValue == EstimateInputConstructionAcs.SaveInfoStore_ON)
            {
                // 検索見積用初期値クラスをシリアライズ
                this._estimateInputInitData.EnterpriseCode = this._estimateInputAcs.SalesSlip.EnterpriseCode;
                this._estimateInputInitData.CustomerCode = this._estimateInputAcs.SalesSlip.CustomerCode;
                this._estimateInputInitData.Serialize();
            }

        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        private void ClearScreen(object sender, EventArgs e)
        {
            this.Clear(false, true);

            this.timer_InitialSetFocus.Enabled = true;
        }

        /// <summary>
        /// 再読み込み処理
        /// </summary>
        private void ReLoadSlip(object sender, EventArgs e)
        {
            bool reLoad = this.ReLoad(this._estimateInputAcs.SalesSlip.EnterpriseCode, this._estimateInputAcs.SalesSlip.AcptAnOdrStatus, this._estimateInputAcs.SalesSlip.SalesSlipNum);
            if (!reLoad)
            {
                this.Clear(false, false);
            }
        }

        /// <summary>
        /// 保存後の画面初期化処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearScreenAfterSave(object sender, EventArgs e)
        {
            if ((this._estimateInputConstructionAcs.ClearAfterSaveValue == EstimateInputConstructionAcs.ClearAfterSave_ON) ||
                (this._estimateInputAcs.EstimateDetailDataTable.Count == 0))
            {
                bool keepDate = (this._estimateInputConstructionAcs.DateClearAfterSaveValue == (int)EstimateInputConstructionAcs.DateClearAfterSave_OFF) ? false : true;

                // クリア処理
                this.Clear(false, keepDate);
            }
            this.timer_InitialSetFocus.Enabled = true;
        }

        /// <summary>
        /// 元に戻す処理
        /// </summary>
        /// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
        private void Retry(bool isConfirm)
        {
            this.Retry(isConfirm, this._estimateInputAcs.SalesSlip.AcptAnOdrStatus, this._estimateInputAcs.SalesSlip.SalesSlipNum);
        }

        /// <summary>
        /// 再読込処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierFormal">仕入形式</param>
        /// <param name="supplierSlipNo">仕入伝票番号</param>
        private bool ReLoad(string enterpriseCode, int acptAnOdrStatus, string salesSlipNum)
        {
            bool isSuccess = false;

            // データリード処理
            this.Cursor = Cursors.WaitCursor;
            int status = this._estimateInputAcs.ReadDBData(enterpriseCode, acptAnOdrStatus, salesSlipNum);
            this.Cursor = Cursors.Default;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
                if (this._estimateInputAcs.IsDiscount)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "値引きデータが含まれるため、呼出しできません。",
                        -1,
                        MessageBoxButtons.OK);

                    // 画面初期化処理
                    this.Clear(false, false);

                    this.tNedit_SalesSlipNum.Focus();
                    
                    return true;
                }
                // --- ADD 2013/11/05 Y.Wakita ----------<<<<<

                SalesSlip salesSlip = this._estimateInputAcs.SalesSlip.Clone();

                // 入力モード設定
                this.SettingSalesSlipInputMode(ref salesSlip);

                // 画面表示
                this.SetDisplay(salesSlip);

                // データキャッシュ
                this._estimateInputAcs.Cache(salesSlip);

                // 明細グリッド設定
                this._estimateDetailInput.SettingGrid();

                if (this._estimateDetailInput.Enabled)
                {
                    this._estimateDetailInput.Focus();
                }
                else
                {
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
                    "見積データの取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);
            }

            return isSuccess;
        }

        /// <summary>
        /// 元に戻す処理
        /// </summary>
        /// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        private void Retry(bool isConfirm, int acptAnOdrStatus, string salesSlipNum)
        {
            if ((isConfirm) && (this._estimateInputAcs.IsDataChanged))
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
                    return;
                }
            }

            // 画面初期化処理
            this.Clear(false, false);

            if ((!string.IsNullOrEmpty(salesSlipNum)) && (salesSlipNum != EstimateInputAcs.ctDefaultSalesSlipNum))
            {
                // データリード処理
                this.Cursor = Cursors.WaitCursor;
                int status = this._estimateInputAcs.ReadDBData(this._enterpriseCode, acptAnOdrStatus, salesSlipNum);
                this.Cursor = Cursors.Default;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
                    if (this._estimateInputAcs.IsDiscount)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "値引きデータが含まれるため、呼出しできません。",
                            -1,
                            MessageBoxButtons.OK);

                        return;
                    }
                    // --- ADD 2013/11/05 Y.Wakita ----------<<<<<

                    SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

                    // 仕入データクラス→画面格納処理
                    this.SetDisplay(salesSlip);

                    // 明細グリッド設定処理
                    this._estimateDetailInput.SettingGrid();
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
                        "見積データの取得に失敗しました。",
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
        private bool Clear(bool isConfirm)
        {
            return this.Clear(isConfirm, false);
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
        /// <param name="keepSupplierFormal">true:仕入形式を保持する false:保持しない</param>
        /// <param name="keepDate">true:日付を保持する false:保持しない</param>
        /// <returns>true:初期化実行 false:初期化未実行</returns>
        private bool Clear(bool isConfirm, bool keepDate)
        {
            try
            {
                if ((isConfirm) && (this._estimateInputAcs.IsDataChanged))
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

                // 検索見積データ初期インスタンス取得処理
                this._estimateInputAcs.CreateSalesSlipInitialData(keepDate);

                SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

                this.SettingInitData(salesSlip);

                // 税率取得
                salesSlip.ConsTaxRate = this._estimateInputInitDataAcs.GetTaxRate(salesSlip.SalesDate);

                // 伝票番号
                salesSlip.SalesSlipNum = EstimateInputAcs.ctDefaultSalesSlipNum;
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

            // 各種データクリア処理
            this._estimateInputAcs.ClearDataForNew();

            // 検索見積明細クリア処理
            this._estimateDetailInput.Clear();

            // 車輌情報データ→画面
            EstimateInputDataSet.CarInfoRow row = this._estimateInputAcs.GetCarInfoRow(1, EstimateInputAcs.GetCarInfoMode.NewInsertMode);
            this.SetDisplayCarInfo(row, CarSearchType.csNone);

            // 売上データクラス→画面格納処理
            this.SetDisplay(this._estimateInputAcs.SalesSlip);

            this._estimateDetailInput.SettingGrid();

            // データ変更フラグプロパティをfalseにする
            this._estimateInputAcs.IsDataChanged = false;

            return true;
        }

        /// <summary>
        /// ツールバーボタン有効無効設定処理
        /// </summary>
        private void SettingToolBarButtonEnabled()
        {
            if (this._estimateInputAcs.SalesSlip.InputMode == EstimateInputAcs.ctINPUTMODE_Estimate_ReadOnly)
            {
                this._canPrint = false;
                this._canDeleteSlip = false;
            }
            else
            {
                this._canPrint = true;
                this._canDeleteSlip = true;
                this._canUndo = this._estimateInputAcs.IsDataChanged;

                if (this._estimateInputAcs.SalesSlip.SalesSlipNum.PadLeft(9, '0') == EstimateInputAcs.ctDefaultSalesSlipNum)
                {
                    this._canDeleteSlip = false;
                }
                bool existDetailData = (this._estimateInputAcs.ExistDetailData());
                this._canEntryJoinParts = existDetailData;
                this._canOrderSelect = existDetailData;

            }
#if false
			if ((this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly) ||
				(this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp))
			{
				this._saveButton.SharedProps.Enabled = false;
				this._retryButton.SharedProps.Enabled = false;
				this._deleteSlipButton.SharedProps.Enabled = false;
			}
			else
			{
				this._saveButton.SharedProps.Enabled = true;
				this._retryButton.SharedProps.Enabled = this._stockSlipInputAcs.IsDataChanged;

				if (this._stockSlipInputAcs.StockSlip.SupplierSlipNo == 0)
				{
					this._deleteSlipButton.SharedProps.Enabled = false;
				}
				else
				{
					if ((this._stockSlipInputAcs.StockSlip.DebitNoteDiv == 2) || (this._stockSlipInputAcs.StockSlip.TrustAddUpSpCd == 2))
					{
						this._deleteSlipButton.SharedProps.Enabled = false;
					}
					else
					{
						this._deleteSlipButton.SharedProps.Enabled = true;
					}
				}
			}

			if (( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Red ) ||
				( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_Return ) ||
				( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ReadOnly ) ||
				( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_ArrivalAddUp ) ||
				( this._stockSlipInputAcs.StockSlip.InputMode == StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp ))
			{
				this._stockReferenceButton.SharedProps.Enabled = false;
				this._orderReferenceButton.SharedProps.Enabled = false;
			}
			else
			{
				this._stockReferenceButton.SharedProps.Enabled = true;
				this._orderReferenceButton.SharedProps.Enabled = true;
			}
#endif
        }

        /// <summary>
        /// 画面項目名称設定処理
        /// </summary>
        private void DisplayNameSetting()
        {
            //this._loginSectionNameLabel.SharedProps.Caption = this._stockSlipInputInitDataAcs.OwnSectionName;
        }

        /// <summary>
        /// 指定フォーカス設定処理
        /// </summary>
        /// <param name="ddID">項目ID</param>
        /// <param name="rowNo">行番号</param>
        private void SetControlFocus(string ddID, int rowNo)
        {
            if (ddID == "SectionCode")
            {
                this.uExpandableGroupBox_EstimateInfo.Expanded = true;
                this.tEdit_SectionCode.Focus();
            }
            else if (ddID == "SalesEmployeeCd")
            {
                this.uExpandableGroupBox_EstimateInfo.Expanded = true;
                this.tEdit_SalesEmployeeCd.Focus();
            }
            else if (ddID == "CustomerCode")
            {
                this.uExpandableGroupBox_EstimateInfo.Expanded = true;
                this.tNedit_CustomerCode.Focus();
            }
            else if (ddID == "SalesDate")
            {
                this.uExpandableGroupBox_EstimateInfo.Expanded = true;
                this.tDateEdit_SalesDate.Focus();
            }
            else if (ddID == "EstimateValidityDate")
            {
                this.uExpandableGroupBox_EstimateInfo.Expanded = true;
                this.tDateEdit_EstimateValidityDate.Focus();
            }
            else if (ddID.Contains("EstimateDetail"))
            {
                this._estimateDetailInput.Focus();

                if (ddID.Contains(this._estimateInputAcs.EstimateDetailDataTable.ShipmentCntColumn.ColumnName))
                {
                    this._estimateDetailInput.SettingActiveCell(PMMIT01010UB.ct_SettingActiveCell_ShipmentCntError, rowNo);
                }
                else if (ddID.Contains(this._estimateInputAcs.EstimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName))
                {
                    this._estimateDetailInput.SettingActiveCell(PMMIT01010UB.ct_SettingActiveCell_ShipmentCntError_Prime, rowNo);
                }
                else
                {
                }
            }

            // ガイドボタンツール有効無効設定処理
            this.SettingGuideButtonToolEnabled(this.ActiveControl);

            this._prevControl = this.ActiveControl;
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        private void Delete()
        {
            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "表示中の見積データを削除します。" + "\r\n" + "\r\n" +
                "よろしいですか？",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            List<string> itemNameList = new List<string>();
            List<string> itemList = new List<string>();
            string mainMessage;

            // 削除データチェック処理
            bool check = this._estimateInputAcs.CheckDeleteData(this._estimateInputAcs.SalesSlip, out mainMessage, out itemNameList, out itemList);

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
            int status = this._estimateInputAcs.DeleteDBData(this._estimateInputAcs.SalesSlip, out retMessage);
            this.Cursor = Cursors.Default;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
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
                // 類別にフォーカスをセット（一時的に）
                this.tNedit_ModelDesignationNo.Focus();

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "現在、編集中の見積データは既に更新されています。" + "\r\n" + "\r\n" +
                    "最新の情報を取得します。",
                    -1,
                    MessageBoxButtons.OK);

                // 再読込処理
                this.ReLoad(this._estimateInputAcs.SalesSlip.EnterpriseCode, this._estimateInputAcs.SalesSlip.AcptAnOdrStatus, this._estimateInputAcs.SalesSlip.SalesSlipNum);

                // 明細グリッドにフォーカスをセット
                this._estimateDetailInput.Focus();
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)				// 排他（別端末物理削除済）
            {
                // 仕入担当にフォーカスをセット（一時的に）
                this.tNedit_ModelDesignationNo.Focus();

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "現在、編集中の見積データは既に削除されています。",
                    -1,
                    MessageBoxButtons.OK);

                this.Clear(false, true);

                this.timer_InitialSetFocus.Enabled = true;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "見積データの削除に失敗しました。",
                    status,
                    MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 伝票複写処理
        /// </summary>
        private void CopySlip(bool isConfirm)
        {
            bool canCopy = this.ShowSaveCheckDialog(isConfirm);
            if (!canCopy)
            {
                return;
            }

            MAHNB04110UA salesSlipGuide = new MAHNB04110UA();
            salesSlipGuide.TComboEditor_SalesFormalCode = false;
            salesSlipGuide.AutoSearch = true;
            salesSlipGuide.SectionCode = this._estimateInputAcs.SalesSlip.ResultsAddUpSecCd;
            salesSlipGuide.SectionName = this._estimateInputAcs.SalesSlip.ResultsAddUpSecNm;
            salesSlipGuide.AcptAnOdrStatus = 30;
            SalesSlipSearchResult searchResult;
            DialogResult result = salesSlipGuide.ShowGuide(this, _enterpriseCode, 10, 3, out searchResult);

            if ((result == DialogResult.OK) && (searchResult != null))
            {
                this.CopySlip(searchResult.EnterpriseCode, searchResult.AcptAnOdrStatus, searchResult.SalesSlipNum);
                this._estimateDetailInput.uGrid_Details.Focus();

                // --- ADD 2009/10/22 ----->>>>>
                 int custCd = this.tNedit_CustomerCode.GetInt();

                 if (custCd != 0)
                 {
                     CustomerInfo custInfo;
                     int stus = this._customerInfoAcs.ReadDBData(this._enterpriseCode, custCd, true, out custInfo);
                     int carMngDiv = 0;
                     carMngDiv = custInfo.CarMngDivCd;
                     if (carMngDiv!=0)
                     {
                         this.tEdit_CarMngCode.Enabled = true;
                         this.uButton_CarMngNoGuide.Enabled = true;
                     }
                 }

                // --- ADD 2009/10/22 -----<<<<<
            }
        }

        /// <summary>
        /// 伝票複写
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierFormal">仕入形式</param>
        /// <param name="supplierSlipNo">仕入伝票番号</param>
        private void CopySlip(string enterpriseCode, int acptAnOdrStatus, string salesSlipNum)
        {
            SalesSlip salesSlip;
            List<SalesDetail> salesDetailList;
            List<StockWork> stockWorkList;
            List<AcceptOdrCar> acceptOdrCarList;

            // データリード処理
            this.Cursor = Cursors.WaitCursor;
            int status = this._estimateInputAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, acptAnOdrStatus, salesSlipNum, out salesSlip, out salesDetailList, out stockWorkList, out acceptOdrCarList);
            this.Cursor = Cursors.Default;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.CopySlip(salesSlip, salesDetailList, stockWorkList, acceptOdrCarList);
            }
        }

        /// <summary>
        /// 伝票複写
        /// </summary>
        /// <param name="stockSlip">仕入データオブジェクト</param>
        /// <param name="salesDetailList">仕入明細データオブジェクトリスト</param>
        /// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
        private void CopySlip(SalesSlip salesSlip, List<SalesDetail> salesDetailList, List<StockWork> stockWorkList, List<AcceptOdrCar> acceptOdrCarList)
        {
            SalesSlip baseSalesSlip = salesSlip.Clone();

            // 複写伝票情報生成処理
            this._estimateInputAcs.CreateSlipCopyInfo(ref salesSlip);

            // キャッシュ処理
            this._estimateInputAcs.Cache(salesSlip, baseSalesSlip, salesDetailList, stockWorkList, acceptOdrCarList);

            // コピー伝票明細情報生成処理
            this._estimateInputAcs.CreateSlipCopyDetailInfo(stockWorkList);

            // コピー伝票車輌情報生成処理
            this._estimateInputAcs.CreateSlipCopyCarInfo();

            // 売上データクラス→画面格納処理
            this.SetDisplay(this._estimateInputAcs.SalesSlip);

            // 明細グリッド設定処理
            this._estimateDetailInput.SettingGrid();

            // ガイドボタンツール有効無効設定処理
            this.SettingGuideButtonToolEnabled(this._estimateDetailInput);

            // データ変更フラグプロパティをtrueにする
            this._estimateInputAcs.IsDataChanged = true;

            this._prevControl = this.ActiveControl;
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車輌検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // 得意先設定処理
            this.SettingCustomer(false, customerSearchRet);

        }

        /// <summary>
        /// 得意先設定処理
        /// </summary>
        /// <param name="isClear">true:クリアする false:クリアしない</param>
        /// <param name="seldata">得意先検索結果クラス</param>
        /// <br>Update Note: 2009/09/08 汪千来 車輌管理機能対応</br>
        private void SettingCustomer(bool isClear, CustomerSearchRet seldata)
        {
            if (isClear)
            {
                // 画面初期化処理
                bool canClear = this.Clear(true);

                if (!canClear) return;
            }
            else
            {
                if (!this.tNedit_CustomerCode.Enabled)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "選択中の伝票に対して得意先を変更することができません。",
                        -1,
                        MessageBoxButtons.OK);

                    return;
                }
            }

            // 得意先を自動で設定
            SalesSlip salesSlip = this._estimateInputAcs.SalesSlip.Clone();

            bool reCalctPrice = false;
            bool clearRateInfo = false;
            CustomerInfo customerInfo;
            this.Cursor = Cursors.WaitCursor;
            if (this._customerInfoAcs == null) this._customerInfoAcs = new CustomerInfoAcs();
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, seldata.CustomerCode, true, out customerInfo);
            this.Cursor = Cursors.Default;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (salesSlip.CustomerCode != customerInfo.CustomerCode)
                {
                    // --- ADD 2009/09/08 ---------->>>>>
                    //得意先を変更した場合は、管理番号の値をクリアする
                    this.tEdit_CarMngCode.Text = string.Empty;

                    int salesRowNo = this._estimateDetailInput.GetActiveRowSalesRowNo();
                    this._estimateInputAcs.SettingCarInfoRowFromCarMngCode(salesRowNo, string.Empty);
                    // --- ADD 2009/09/08 ----------<<<<<

                    // 得意先（仕入先）情報設定処理
                    this._estimateInputAcs.DataSettingSalesSlip(ref salesSlip, customerInfo);

                    // 仕入明細データセッティング処理（課税区分設定）
                    this._estimateInputAcs.DisplayPriceSetting(salesSlip.TotalAmountDispWayCd);

                    if (this._estimateInputAcs.ExistEstimateDetailCanGoodsPriceReSettingData())
                    {
                        string msg = "得意先が変更されました。" + "\r\n" + "\r\n" + "商品価格を再取得しますか？";
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
                            reCalctPrice = true;
                        }
                        else
                        {
                            clearRateInfo = true;
                        }
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
                    "得意先が存在しません。",
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
                    "得意先の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }

            // 売上データクラス→画面格納処理
            this.SetDisplay(salesSlip);

            // 売上データキャッシュ処理
            this._estimateInputAcs.Cache(salesSlip);

            // データ変更フラグプロパティをTrueにする
            this._estimateInputAcs.IsDataChanged = true;

            if (reCalctPrice)
            {
                this.PriceReSetting();
            }

            // 掛率情報のクリア
            if (clearRateInfo)
            {
                this._estimateInputAcs.AllTableClearRateInfo();
            }

            // 明細グリッドセル設定処理
            this._estimateDetailInput.SettingGrid();

            this._estimateDetailInput.SettingFooterEventCall();
        }

        /// <summary>
        /// 保存確認ダイアログ表示処理
        /// </summary>
        /// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
        /// <returns>確認後OK 確認後NG</returns>
        private bool ShowSaveCheckDialog(bool isConfirm)
        {
            bool checkedValue = false;

            if ((isConfirm) && (this._estimateInputAcs.IsDataChanged))
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
                    "処理を続行してよろしいですか？",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    checkedValue = true;
                    //checkedValue = this.Save(true);
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
        /// 入力モード設定処理
        /// </summary>
        /// <param name="stockSlip">仕入データオブジェクト</param>
        private void SettingSalesSlipInputMode(ref SalesSlip salesSlip)
        {
            if (salesSlip.DebitNoteDiv == 1)
            {
                // 赤伝の場合は何もしない
            }
            else if (salesSlip.DebitNoteDiv == 2)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "既に「赤伝」が発行されている為、編集できません。" + "\r\n" + "\r\n" + "参照モードで表示します。",
                    -1,
                    MessageBoxButtons.OK);

                salesSlip.InputMode = EstimateInputAcs.ctINPUTMODE_Estimate_ReadOnly;
            }
            else
            {
                bool isAddUp = false;
                //if (salesSlip.SupplierFormal == 0)
                //{
                //    string message;
                //    isAddUp = this._stockSlipInputAcs.CheckAddUp(salesSlip, 1, out message);

                //    if (isAddUp)
                //    {
                //        TMsgDisp.Show(
                //            this,
                //            emErrorLevel.ERR_LEVEL_INFO,
                //            this.Name,
                //            message + "\r\n" + "\r\n" + "参照モードで表示します。",
                //            -1,
                //            MessageBoxButtons.OK);

                //        salesSlip.InputMode = StockSlipInputAcs.ctINPUTMODE_StockSlip_AddUp;
                //    }
                //}

                if (!isAddUp)
                {
                    //bool exist = this._stockSlipInputAcs.ExistAllReadonlyRow();

                    //if (exist)
                    //{
                    //    TMsgDisp.Show(
                    //        this,
                    //        emErrorLevel.ERR_LEVEL_INFO,
                    //        this.Name,
                    //        "「在庫状態」が変更されているか、または「在庫移動」が行われている商品が存在する為、" + "\r\n" + "編集できない項目があります。" + "\r\n" + "\r\n" +
                    //        "詳細を確認する場合は、商品の数量にマウスカーソルを合わせて下さい。",
                    //        -1,
                    //        MessageBoxButtons.OK);

                    //    stockSlip.InputMode = StockSlipInputAcs.ctINPUTMODE_StockSlip_ChangeStockStatus;
                    //}
                }
            }
        }

        /// <summary>
        /// 初期データ設定処理
        /// </summary>
        /// <param name="stockSlip">仕入データオブジェクト</param>
        private void SettingInitData(SalesSlip salesSlip)
        {
            if (this._estimateInputConstructionAcs.SaveInfoStoreValue == EstimateInputConstructionAcs.SaveInfoStore_OFF)
            {
                return;
            }

            this._estimateInputInitData.Deserialize();

            if (this._enterpriseCode == this._estimateInputInitData.EnterpriseCode)
            {
                if (this._estimateInputInitData.CustomerCode != 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    CustomerInfo customerInfo;
                    if (this._customerInfoAcs == null) this._customerInfoAcs = new CustomerInfoAcs();
                    int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, this._estimateInputInitData.CustomerCode, true, false, out customerInfo);
                    this.Cursor = Cursors.Default;

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (customerInfo != null)
                        {
                            // 得意先（仕入先）情報設定処理
                            this._estimateInputAcs.DataSettingSalesSlip(ref salesSlip, customerInfo);

                            // 明細データセッティング処理（課税区分設定）
                            this._estimateInputAcs.DisplayPriceSetting(salesSlip.TotalAmountDispWayCd);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 部品検索モードを切り替えます。（BL検索⇔部品検索）
        /// </summary>
        /// <param name="salesSlip"></param>
        private void ChangePartsSearchMode(ref SalesSlip salesSlip, bool isCache)
        {
            this._estimateInputAcs.SearchCarDiv = true;
            if (salesSlip.SearchMode == (int)EstimateInputAcs.SearchMode.BLSearch)
            {
                salesSlip.SearchMode = (int)EstimateInputAcs.SearchMode.GoodsNoSearch;

                // モデルプレート検索は、BLコード検索の場合のみ有効
                if (salesSlip.SearchCarMode == (int)EstimateInputAcs.SearchCarMode.ModelPlateSearch)
                {
                    this.ChangeCarSearchMode(ref salesSlip, isCache);
                }
            }
            else
            {
                salesSlip.SearchMode = (int)EstimateInputAcs.SearchMode.BLSearch;
            }

            if (isCache)
            {
                this._estimateInputAcs.Cache(salesSlip);
            }
            this.SetDisplay(salesSlip);
            this._estimateDetailInput.SettingGrid();

            // 明細にフォーーカスがある場合はアクティブセルを変更する
            if (this._estimateDetailInput.ContainsFocus)
            {
                this._estimateDetailInput.ChangeActiveCell(0);
            }

            this._estimateDetailInput.ActiveCellButtonEnabledControl();
            this.SettingGuideButtonToolEnabled(this.ActiveControl);
        }

        /// <summary>
        /// 車輌検索モードを切り替えます。（型式⇔モデルプレート）
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="isCache">True:キャッシュする</param>
        private void ChangeCarSearchMode(ref SalesSlip salesSlip, bool isCache)
        {
            if (salesSlip.SearchCarMode == (int)EstimateInputAcs.SearchCarMode.FullModelSearch)
            {
                salesSlip.SearchCarMode = (int)EstimateInputAcs.SearchCarMode.ModelPlateSearch;
            }
            else if (salesSlip.SearchCarMode == (int)EstimateInputAcs.SearchCarMode.ModelPlateSearch)
            {
                salesSlip.SearchCarMode = (int)EstimateInputAcs.SearchCarMode.FullModelSearch;
            }

            if (isCache)
            {
                this._estimateInputAcs.Cache(salesSlip);
            }

            this.SetDisplay(salesSlip);
        }

        /// <summary>
        /// 価格を再取得します。
        /// </summary>
        private void PriceReSetting()
        {
            // 共通処理中画面生成
            SFCMN00299CA progressForm = new SFCMN00299CA();
            progressForm.DispCancelButton = false;
            progressForm.Title = "価格取得中";
            progressForm.Message = "現在、価格取得中です．．．";

            try
            {
                System.Windows.Forms.Application.DoEvents();
                this.Cursor = Cursors.WaitCursor;
                progressForm.Show();

                this._estimateInputAcs.PriceReSetting();
            }
            finally
            {
                progressForm.Close();
                this.Cursor = Cursors.Default;
            }
            this.Activate();
        }

        #region フォーカス制御関連

        /// <summary>
        /// コントロールインデックス取得処理
        /// </summary>
        /// <param name="prevCtrl">現在のコントロールの名称</param>
        /// <param name="mode">0:上から 1:下から</param>
        /// <returns>コントロールインデックス</returns>
        private int GetGontrolIndex(string prevCtrl, EstimateInputAcs.MoveMethod mode)
        {
            int controlIndex = -1;

            switch (mode)
            {
                case EstimateInputAcs.MoveMethod.NextMove:
                    {
                        if (this._controlIndexForwordDictionary.ContainsKey(prevCtrl))
                        {
                            controlIndex = this._controlIndexForwordDictionary[prevCtrl];
                        }

                        break;
                    }
                case EstimateInputAcs.MoveMethod.PrevMove:
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
        private Control GetNextControl(Control prevCtrl, EstimateInputAcs.MoveMethod mode)
        {

            Control control = null;
            Control nextCtrl = null;

            HeaderFocusConstructionList headerFocusConstructionList = this._estimateInputConstructionAcs.HeaderFocusConstructionListValue;
            int targetControlIndex = 0;
            int prevControlIndex = this.GetGontrolIndex(prevCtrl.Name, mode);
            if (prevControlIndex < 0) return this.GetNextControlException(prevCtrl, mode);

            switch (mode)
            {
                case EstimateInputAcs.MoveMethod.NextMove:
                    {
                        foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
                        {
                            control = this._headerItemsDictionary[headerFocusConstruction.Caption];
                            targetControlIndex = this.GetGontrolIndex(control.Name, mode);

                            if (targetControlIndex == 0)
                                nextCtrl = this._estimateDetailInput.uGrid_Details;

                            if ((control.Enabled) &&
                                (control.Visible) &&
                                (prevCtrl != control) &&
                                (prevControlIndex < targetControlIndex))
                            {
                                nextCtrl = control;
                                break;
                            }
                        }
                        break;
                    }
                case EstimateInputAcs.MoveMethod.PrevMove:
                    {
                        for (int count = headerFocusConstructionList.headerFocusConstruction.Count - 1; count >= 0; count--)
                        {
                            HeaderFocusConstruction headerFocusConstruction = headerFocusConstructionList.headerFocusConstruction[count];

                            control = this._headerItemsDictionary[headerFocusConstruction.Caption];

                            if ((control.Enabled) &&
                                (control.Visible) &&
                                (prevCtrl != control) &&
                                (prevControlIndex < this.GetGontrolIndex(control.Name, mode)))
                            {
                                nextCtrl = control;
                                break;
                            }
                        }
                        break;
                    }
            }

            if (nextCtrl == null) nextCtrl = this.GetNextControlException(prevCtrl, mode);

            return nextCtrl;
        }

        /// <summary>
        /// ネクストコントロール取得処理
        /// </summary>
        /// <param name="prevCtrl">現在のコントロール</param>
        /// <param name="mode">0:上から 1:下から</param>
        /// <returns>次のコントロール</returns>
        private Control GetNextControlException(Control prevCtrl, EstimateInputAcs.MoveMethod mode)
        {
            Control control = null;
            Control nextCtrl = null;

            HeaderFocusConstructionList headerFocusConstructionList = this._estimateInputConstructionAcs.HeaderFocusConstructionListValue;
            bool selectFlg = false;

            switch (mode)
            {
                case EstimateInputAcs.MoveMethod.NextMove:
                    {
                        foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
                        {
                            control = this._headerItemsDictionary[headerFocusConstruction.Caption];

                            if (selectFlg)
                            {
                                if ((control.Enabled) && (control.Visible))
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

                        //  ADD 2011/02/14  >>>
                        if (headerFocusConstructionList.headerFocusConstruction == null || headerFocusConstructionList.headerFocusConstruction.Count == 0)
                        {
                            switch (prevCtrl.Name)
                            {
                                case "tEdit_SectionCode":
                                    {
                                        control = this.tNedit_SubSectionCode;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tNedit_SubSectionCode":
                                    {
                                        control = this.tEdit_SalesEmployeeCd;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_SalesEmployeeCd":
                                    {
                                        control = this.tNedit_CustomerCode;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tNedit_CustomerCode":
                                    {
                                        control = this.tEdit_CustomerName;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_CustomerName":
                                    {
                                        control = this.tDateEdit_SalesDate;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tDateEdit_SalesDate":
                                    {
                                        control = this.tDateEdit_EstimateValidityDate;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tDateEdit_EstimateValidityDate":
                                    {
                                        control = this.tEdit_CarMngCode;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_CarMngCode":
                                    {
                                        control = this.tNedit_ModelDesignationNo;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tNedit_ModelDesignationNo":
                                    {
                                        control = this.tEdit_EngineModelNm;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_EngineModelNm":
                                    {
                                        control = this.tEdit_FullModel;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_FullModel":
                                    {
                                        control = this.tNedit_MakerCode;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tNedit_MakerCode":
                                    {
                                        control = this.tNedit_ModelCode;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tNedit_ModelCode":
                                    {
                                        control = this.tNedit_ModelSubCode;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tNedit_ModelSubCode":
                                    {
                                        control = this.tEdit_ModelFullName;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_ModelFullName":
                                    {
                                        control = this.tDateEdit_FirstEntryDate;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tDateEdit_FirstEntryDate":
                                    {
                                        control = this.tEdit_ProduceFrameNo;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_ProduceFrameNo":
                                    {
                                        control = this.tEdit_ColorNo;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_ColorNo":
                                    {
                                        control = this.tEdit_TrimNo;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_TrimNo":
                                    {
                                        control = this._estimateDetailInput.uGrid_Details;
                                        if ((control.Enabled) && (control.Visible))
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
                            }
                        }
                        //  ADD 2011/02/14  <<<

                        if (nextCtrl == null) nextCtrl = this._estimateDetailInput.uGrid_Details;
                        break;
                    }
                case EstimateInputAcs.MoveMethod.PrevMove:
                    {
                        for (int count = headerFocusConstructionList.headerFocusConstruction.Count - 1; count >= 0; count--)
                        {
                            HeaderFocusConstruction headerFocusConstruction = headerFocusConstructionList.headerFocusConstruction[count];

                            control = this._headerItemsDictionary[headerFocusConstruction.Caption];

                            if (selectFlg)
                            {
                                if ((control.Enabled) && (control.Visible))
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

                        //  ADD 2011/02/14  >>>
                        if (headerFocusConstructionList.headerFocusConstruction == null || headerFocusConstructionList.headerFocusConstruction.Count == 0)
                        {
                            switch (prevCtrl.Name)
                            {
                                case "tEdit_SectionCode":
                                    {
                                        control = this.tEdit_SectionCode;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tNedit_SubSectionCode":
                                    {
                                        control = this.tEdit_SectionCode;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_SalesEmployeeCd":
                                    {
                                        control = this.tNedit_SubSectionCode;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tNedit_CustomerCode":
                                    {
                                        control = this.tEdit_SalesEmployeeCd;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_CustomerName":
                                    {

                                        control = this.tNedit_CustomerCode;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tDateEdit_SalesDate":
                                    {
                                        if (this.tEdit_CustomerName.Text == "")
                                            control = this.tEdit_CustomerName;
                                        else
                                            control = this.tNedit_CustomerCode;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tDateEdit_EstimateValidityDate":
                                    {
                                        control = this.tDateEdit_SalesDate;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_CarMngCode":
                                    {
                                        control = this.tDateEdit_EstimateValidityDate;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tNedit_ModelDesignationNo":
                                    {
                                        control = this.tEdit_CarMngCode;

                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_EngineModelNm":
                                    {
                                        control = this.tNedit_ModelDesignationNo;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_FullModel":
                                    {
                                        control = this.tEdit_EngineModelNm;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tNedit_MakerCode":
                                    {
                                        control = this.tEdit_FullModel;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tNedit_ModelCode":
                                    {
                                        control = this.tNedit_MakerCode;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tNedit_ModelSubCode":
                                    {
                                        control = this.tNedit_ModelCode;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_ModelFullName":
                                    {
                                        control = this.tNedit_ModelSubCode;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tDateEdit_FirstEntryDate":
                                    {
                                        control = this.tEdit_ModelFullName;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_ProduceFrameNo":
                                    {
                                        control = this.tDateEdit_FirstEntryDate;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_ColorNo":
                                    {
                                        control = this.tEdit_ProduceFrameNo;
                                        if ((control.Enabled) && (control.Visible))
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

                                case "tEdit_TrimNo":
                                    {
                                        control = this.tEdit_ColorNo;
                                        if ((control.Enabled) && (control.Visible))
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
                            }
                        }
                        //  ADD 2011/02/14  <<<

                        if (nextCtrl == null) nextCtrl = prevCtrl;
                        break;
                    }
            }

            return nextCtrl;
        }

        /// <summary>
        /// ヘッダー部 フォーカス先頭コントロール取得処理
        /// </summary>
        /// <returns>先頭コントロール</returns>
        private Control GetHeaderFirstControl()
        {
            Control retControl = null;

            if ((this._estimateInputConstructionAcs.FocusPositionValue == EstimateInputConstructionAcs.ForcusPosition_CustomerCode) && (this.tNedit_CustomerCode.Enabled) && (this.tNedit_CustomerCode.Visible))
            {
                retControl = tNedit_CustomerCode;
            }
            else if ((this._estimateInputConstructionAcs.FocusPositionValue == EstimateInputConstructionAcs.ForcusPosition_EngineModelNm) && (this.tEdit_EngineModelNm.Enabled) && (this.tEdit_EngineModelNm.Visible))
            {
                retControl = tEdit_EngineModelNm;
            }
            else if ((this._estimateInputConstructionAcs.FocusPositionValue == EstimateInputConstructionAcs.ForcusPosition_FullModel) && (this.tEdit_FullModel.Enabled) && (this.tEdit_FullModel.Visible))
            {
                retControl = tEdit_FullModel;
            }
            else if ((this._estimateInputConstructionAcs.FocusPositionValue == EstimateInputConstructionAcs.ForcusPosition_ModelDesignationNo) && (this.tNedit_ModelDesignationNo.Enabled) && (this.tNedit_ModelDesignationNo.Visible))
            {
                retControl = tNedit_ModelDesignationNo;
            }
            else if ((this._estimateInputConstructionAcs.FocusPositionValue == EstimateInputConstructionAcs.ForcusPosition_SalesEmployeeCd) && (this.tEdit_SalesEmployeeCd.Enabled) && (this.tEdit_SalesEmployeeCd.Visible))
            {
                retControl = tEdit_SalesEmployeeCd;
            }
            else if ((this._estimateInputConstructionAcs.FocusPositionValue == EstimateInputConstructionAcs.ForcusPosition_SalesSlipNum) && (this.tNedit_SalesSlipNum.Enabled) && (this.tNedit_SalesSlipNum.Visible))
            {
                retControl = tNedit_SalesSlipNum;
            }
            else if ((this._estimateInputConstructionAcs.FocusPositionValue == EstimateInputConstructionAcs.ForcusPosition_SectionCode) && (this.tEdit_SectionCode.Enabled) && (this.tEdit_SectionCode.Visible))
            {
                retControl = tEdit_SectionCode;
            }
            else
            {
                HeaderFocusConstructionList headerFocusConstructionList = this._estimateInputConstructionAcs.HeaderFocusConstructionListValue;

                foreach (HeaderFocusConstruction headerFocusConstruction in headerFocusConstructionList.headerFocusConstruction)
                {
                    Control ctrl = this._headerItemsDictionary[headerFocusConstruction.Caption];
                    if ((ctrl != null) && (ctrl.Enabled) && (ctrl.Visible))
                    {
                        retControl = ctrl;
                        break;
                    }
                }
            }

            return retControl;
        }

        /// <summary>
        /// フォーカス移動Dictionary設定処理
        /// </summary>
        private void SettingFocusDictionary()
        {
            HeaderFocusConstructionList headerFocusConstructionList = this._estimateInputConstructionAcs.HeaderFocusConstructionListValue;

            if ((headerFocusConstructionList.headerFocusConstruction != null) &&
                (headerFocusConstructionList.headerFocusConstruction.Count != 0))
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
                this._estimateInputConstructionAcs.HeaderFocusConstructionListValue = headerFocusConstructionList;

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
                            if ((tempHeaderFocusConstruction.Key == headerFocusConstruction.Key) &&
                                (tempHeaderFocusConstruction.Caption == headerFocusConstruction.Caption))
                            {
                                cloneHeaderFocusConstructionList.Remove(tempHeaderFocusConstruction);
                                break;
                            }
                        }
                    }
                }
                this._estimateInputConstructionAcs.HeaderFocusConstructionListValue.headerFocusConstruction = cloneHeaderFocusConstructionList;

            }
        }

        /// <summary>
        /// ツールバーボタン制御イベントをコールします。
        /// </summary>
        private void ParentToolbarLedgerSettingEventCall()
        {
            if (this.ParentToolbarLedgerSettingEvent != null)
            {
                this.ParentToolbarLedgerSettingEvent(this);
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
        private void PMMIT01010UA_Load(object sender, EventArgs e)
        {
            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "PMMIT01010UA_Load", "開始");

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "PMMIT01010UA_Load", "見積情報の表示");
            if (this._estimateInputConstructionAcs.ShowEstimateInfoValue == EstimateInputConstructionAcs.ShowEstimateInfo_OFF)
            {
                this.uExpandableGroupBox_EstimateInfo.Expanded = false;
            }
            else
            {
                this.uExpandableGroupBox_EstimateInfo.Expanded = true;
            }

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "PMMIT01010UA_Load", "ControlScreenSkin Load");
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this._estimateDetailInput);
            this._controlScreenSkin.SettingScreenSkin(this._estimatePrimeInfoDisplay);

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "PMMIT01010UA_Load", "明細UIをメインUIへ追加");
            this.panel_Detail.Controls.Add(this._estimateDetailInput);
            this._estimateDetailInput.Dock = DockStyle.Fill;

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "PMMIT01010UA_Load", "優良情報UIをメインUIへ追加");
            this.panel_PrimeInfo.Controls.Add(this._estimatePrimeInfoDisplay);
            this._estimatePrimeInfoDisplay.Dock = DockStyle.Fill;

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "PMMIT01010UA_Load", "車輌情報(諸元)のデータソース設定");
            this.ultraGrid_CarSpec.DataSource = this._carSpecDataTable;

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "PMMIT01010UA_Load", "車輌情報UIをメインUIへ追加");
            this.ultraExpandableGroupBoxPanel7.Controls.Add(this._carOtherInfoInput);
            this._carOtherInfoInput.Dock = DockStyle.Fill;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "PMMIT01010UA_Load", "初期データ取得スレッド待ち 開始");
            // 初期データ取得スレッドが終了するまで待機
            while (this._initialReadThread.ThreadState == ThreadState.Running)
            {
                Thread.Sleep(100);
            }
            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "PMMIT01010UA_Load", "初期データ取得スレッド待ち 終了");

            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "PMMIT01010UA_Load", "初期データ取得スレッド２待ち 開始");
            // 初期データ取得スレッドが終了するまで待機
            while (this._initialReadThread2.ThreadState == ThreadState.Running)
            {
                Thread.Sleep(100);
            }
            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "PMMIT01010UA_Load", "初期データ取得スレッド待ち２ 終了");

            //// 初期データ取得処理
            //this._estimateInputInitDataAcs.ReadInitData(this._enterpriseCode, this._loginSectionCode);

            // 初期データ取得後のグリッド設定
            this._estimateDetailInput.SettingAfterInitDataRead();

            if (this._estimateInputInitDataAcs.GetCompanyInf().SecMngDiv == 0)
            {
                if (this._headerItemsDictionary.ContainsKey(this.uLabel_SubSectionTitle.Text.Trim()))
                {
                    this._headerItemsDictionary.Remove(this.uLabel_SubSectionTitle.Text.Trim());
                }
            }

            this._estimateInputInitDataAcs.CacheEventCall();

            // フォーカス移動設定処理
            this.SettingFocusDictionary();

            // コンボエディタアイテム初期設定処理
            this.ComboEditorItemInitialSetting();

            // Visible設定
            this.SettingVisible();

            // 画面項目名称設定処理
            this.DisplayNameSetting();

            // クリア処理
            bool canClear = this.Clear(false);

            if (canClear)
            {
                this.timer_InitialSetFocus.Enabled = true;
            }
            else
            {
                this.timer_Close.Enabled = true;
            }

            this._estimateDetailInput.SettingFooterEventCall();

            this._estimateDetailInput.OwnerForm = this.Owner;

            this.SettingOptionInfo();

            this._estimateInputAcs.SetUnitPriceCalculation();  // ADD 2011/07/25
            
            EstimateInputInitDataAcs.LogWrite("PMMIT01010UA", "PMMIT01010UA_Load", "終了");
        }

        /// <summary>
        /// オプション情報の反映
        /// </summary>
        private void SettingOptionInfo()
        {

        }

        /// <summary>
        /// 画面項目Visible設定
        /// </summary>
        private void SettingVisible()
        {
            #region 年式
            if (this._estimateInputInitDataAcs.GetAllDefSet() != null)
            {
                if (this._estimateInputInitDataAcs.GetAllDefSet().EraNameDispCd1 == 0)
                {
                    // 西暦
                    this.tDateEdit_FirstEntryDate.DateFormat = emDateFormat.df4Y2M;
                }
                else
                {
                    // 和歴
                    this.tDateEdit_FirstEntryDate.DateFormat = emDateFormat.dfG2Y2M;
                }
            }
            #endregion

            #region 車輌管理番号
            // --- UPD 2009/09/08 -------------->>>
            if (this._estimateInputInitDataAcs.GetSalesTtlSt() != null)
            {
                switch (this._estimateInputInitDataAcs.GetSalesTtlSt().CarMngNoDispDiv)
                {
                    // しない
                    case 0:
                        this.panel_CarMngNo.Visible = false;
                        break;
                    // する
                    case 1:
                        this.panel_CarMngNo.Visible = true;
                        break;
                }
            }
            if (this._estimateInputInitDataAcs.Opt_CarMng)
            {
                this.uButton_CarMngNoGuide.Visible = true;
            }
            else
            {
                this.uButton_CarMngNoGuide.Visible = false;
            }
            // --- UPD 2009/09/08 --------------<<<
            #endregion
        }

        /// <summary>
        /// フォーム表示後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PMMIT01010UA_Shown(object sender, EventArgs e)
        {
            //this.timer_InitialSetSlider.Enabled = true;
        }

        /// <summary>
        /// フォームクロージングイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PMMIT01010UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this._estimateDetailInput.Closing();
            }
            catch (NullReferenceException)
            {
                //
            }
        }

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Update Note: 2010/06/08　李占川　障害改良対応（７月リリース分）の対応</br>
        /// <br>             ①モード変更時のフォーカス位置修正</br>
        /// <br>             ②年式絞込み条件変更</br>
        /// <br>Update Note: 2011/02/14　徐嘉　障害改良対応（検索見積発行）の対応</br>
        /// <br>             ①車台番号入力時の年式チェック修正</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            this._prevControl = e.NextCtrl;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 ADD
            _beforeCarSearchBuffer = new BeforeCarSearchBuffer();
            _beforeCarSearchBuffer.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 ADD

            SalesSlip salesSlipCurrent = this._estimateInputAcs.SalesSlip.Clone();
            if (salesSlipCurrent == null) return;

            int salesRowNo = this._estimateDetailInput.GetActiveRowSalesRowNo();

            EstimateInputDataSet.CarInfoRow carInfoRowCurrent = this._estimateInputAcs.GetCarInfoRow(salesRowNo, EstimateInputAcs.GetCarInfoMode.ExistGetMode);

            SalesSlip salesSlip = salesSlipCurrent.Clone();
            bool adjustPrice = false;
            bool reCalcPrice = false;
            bool getNextCtrl = false;	// Tab,Enterでのフォーカス移動項目自動取得有無の判定フラグ
            bool settingFotter = true;
            bool changeCarInfo = false;
            bool clearRateInfo = false;
            Control nextCtrl = null;
            Control prevCtrl = e.PrevCtrl;
            bool inputError = false;

            #region 明細グリッド
            if (this._estimateDetailInput.Contains(e.PrevCtrl))
            {
                switch (e.PrevCtrl.Name)
                {
                    #region 明細グリッド
                    //---------------------------------------------------------------
                    // 明細グリッド
                    //---------------------------------------------------------------
                    case "uGrid_Details":
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                    {
                                        if (this._estimateDetailInput.uGrid_Details.ActiveCell != null)
                                        {
                                            if (this._estimateDetailInput.ReturnKeyDown())
                                            {
                                                e.NextCtrl = null;
                                            }
                                            else
                                            {
                                                //if (Footer_UTabControl.ActiveTab != Footer_UTabControl.Tabs[uTab_StockInfo.Tab.Key])
                                                //{
                                                //    Footer_UTabControl.SelectedTab = Footer_UTabControl.Tabs[uTab_StockInfo.Tab.Key];
                                                //}
                                                //e.NextCtrl = this.tEdit_SupplierSlipNote1;
                                            }
                                        }

                                        salesSlipCurrent = this._estimateInputAcs.SalesSlip;
                                        salesSlip = salesSlipCurrent.Clone();

                                        break;
                                    }
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
                    #region ○見積情報

                    #region ●拠点コード
                    case "tEdit_SectionCode":
                        {
                            getNextCtrl = true;

                            bool canChangeFocus = true;

                            string code = this.tEdit_SectionCode.Text.Trim();

                            if (salesSlipCurrent.ResultsAddUpSecCd.Trim() != code)
                            {
                                if (string.IsNullOrEmpty(code))
                                {
                                    salesSlip.ResultsAddUpSecCd = string.Empty;
                                    salesSlip.ResultsAddUpSecNm = string.Empty;

                                }
                                else
                                {
                                    SecInfoSet secInfoSet = this._estimateInputInitDataAcs.GetSecInfo(code);
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
                                        inputError = true;
                                    }
                                    else
                                    {
                                        if (this._estimateInputAcs.ExistEstimateDetailCanGoodsPriceReSettingData())
                                        {
                                            string msg = "拠点が変更されました。" + "\r\n" + "\r\n" + "商品価格を再取得しますか？";

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
                                                reCalcPrice = true;
                                            }
                                            else
                                            {
                                                clearRateInfo = true;
                                            }
                                        }
                                        salesSlip.ResultsAddUpSecCd = code.Trim();
                                        salesSlip.ResultsAddUpSecNm = secInfoSet.SectionGuideNm;
                                    }
                                }

                                // 仕入データクラス→画面格納処理
                                this.SetDisplay(salesSlip);
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
                    case "tNedit_SubSectionCode":
                        {
                            getNextCtrl = true;

                            bool canChangeFocus = true;
                            int code = this.tNedit_SubSectionCode.GetInt();

                            if (salesSlipCurrent.SubSectionCode != code)
                            {
                                if (code == 0)
                                {
                                    salesSlip.SubSectionCode = code;
                                    salesSlip.SubSectionName = "";
                                    //salesSlip.
                                }
                                else
                                {
                                    string name = this._estimateInputInitDataAcs.GetName_FromSubSection(code);

                                    if (name == "")
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "部門が存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);

                                        canChangeFocus = false;
                                        inputError = true;
                                    }
                                    else
                                    {
                                        salesSlip.SubSectionCode = code;
                                        salesSlip.SubSectionName = name;
                                    }
                                }

                                // 仕入データクラス→画面格納処理
                                this.SetDisplay(salesSlip);
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

                    #region ●伝票番号
                    case "tNedit_SalesSlipNum":
                        {
                            getNextCtrl = true;

                            bool readed = false;
                            string code = this.tNedit_SalesSlipNum.GetInt().ToString().PadLeft(9, '0');

                            if (salesSlipCurrent.SalesSlipNum.PadLeft(9, '0') != code)
                            {
                                DialogResult dialogResult = DialogResult.Yes;

                                if (this._estimateInputAcs.IsDataChanged)
                                {
                                    dialogResult = TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "入力中の見積情報がクリアされます。" + "\r\n" + "\r\n" +
                                        "よろしいですか？",
                                        0,
                                        MessageBoxButtons.YesNo,
                                        MessageBoxDefaultButton.Button1);
                                }
                                if (dialogResult == DialogResult.Yes)
                                {
                                    //// 画面初期化処理
                                    //this.Clear(false, true);

                                    // 仕入伝票番号を再設定
                                    this.tNedit_SalesSlipNum.SetInt(TStrConv.StrToIntDef(code, 0));

                                    // データリード処理
                                    this.Cursor = Cursors.WaitCursor;

                                    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                                    status = this._estimateInputAcs.ReadDBData(this._enterpriseCode, 10, code);

                                    carInfoRowCurrent = this._estimateInputAcs.GetCarInfoRow(salesRowNo, EstimateInputAcs.GetCarInfoMode.ExistGetMode);   // ADD 2011/02/14

                                    this.Cursor = Cursors.Default;

                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
                                        if (this._estimateInputAcs.IsDiscount)
                                        {
                                            TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                "値引きデータが含まれるため、呼出しできません。",
                                                -1,
                                                MessageBoxButtons.OK);

                                            e.NextCtrl = e.PrevCtrl;

                                            getNextCtrl = false;

                                            break;
                                        }
                                        // --- ADD 2013/11/05 Y.Wakita ----------<<<<<

                                        salesSlipCurrent = this._estimateInputAcs.SalesSlip;
                                        salesSlip = salesSlipCurrent.Clone();

                                        // 入力モード設定処理
                                        this.SettingSalesSlipInputMode(ref salesSlip);

                                        readed = true;
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
                                            "見積データの取得に失敗しました。",
                                            status,
                                            MessageBoxButtons.OK);

                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                }

                                // --- ADD 2011/11/12---------->>>>>
                                // BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑの在庫確認で作成された見積伝票を修正呼出しした場合
                                if (this.isStockSales(salesSlip))
                                {
                                    // 入力モード設定処理
                                    // 参照モードで画面に表示する
                                    salesSlip.InputMode = EstimateInputAcs.ctINPUTMODE_Estimate_ReadOnly;
                                }
                                // --- ADD 2011/11/12----------<<<<<

                                // 仕入データキャッシュ処理
                                this._estimateInputAcs.Cache(salesSlip);

                                // 仕入データクラス→画面格納処理
                                this.SetDisplay(salesSlip);

                                salesSlipCurrent = salesSlip.Clone();

                                // 明細グリッド設定処理
                                this._estimateDetailInput.SettingGrid();

                                if (readed)
                                {
                                    if (this._estimateDetailInput.Enabled)
                                    {
                                        e.NextCtrl = this._estimateDetailInput;
                                    }
                                    else
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                }
                            }

                            getNextCtrl = false;

                            break;
                        }
                    #endregion

                    #region ●担当者コード
                    case "tEdit_SalesEmployeeCd":
                        {
                            getNextCtrl = true;

                            bool canChangeFocus = true;
                            string code = this.tEdit_SalesEmployeeCd.Text.Trim();

                            if (salesSlipCurrent.SalesEmployeeCd.Trim() != code)
                            {
                                if (code == "")
                                {
                                    salesSlip.SalesEmployeeCd = code;
                                    salesSlip.SalesEmployeeNm = "";
                                    salesSlip.SubSectionCode = 0;
                                }
                                else
                                {
                                    string name = this._estimateInputInitDataAcs.GetName_FromEmployee(code);

                                    if (name.Trim() == "")
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "担当者が存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);
                                        canChangeFocus = false;
                                        inputError = true;
                                    }
                                    else
                                    {
                                        salesSlip.SalesEmployeeCd = code;
                                        salesSlip.SalesEmployeeNm = name;
                                        if (salesSlip.SalesEmployeeNm.Length > 16)
                                        {
                                            salesSlip.SalesEmployeeNm = salesSlip.SalesEmployeeNm.Substring(0, 16);
                                        }
                                        this._estimateInputAcs.SalesEmployeeBelongInfoSetting(ref salesSlip);
                                    }
                                    // 仕入データクラス→画面格納処理
                                    this.SetDisplay(salesSlip);
                                }

                                if (canChangeFocus)
                                {
                                    if (!e.ShiftKey)
                                    {
                                        switch (e.Key)
                                        {
                                            case Keys.Return:
                                            case Keys.Tab:
                                                if (this.tEdit_SalesEmployeeCd.Text.Trim() == "")
                                                {
                                                    nextCtrl = this.uButton_SalesEmployeeGuide;
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
                            }


                            break;
                        }
                    #endregion

                    #region ●担当者ガイドボタン
                    case "uButton_SalesEmployeeGuide":
                        {
                            getNextCtrl = true;

                            if (e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        nextCtrl = this.tEdit_SalesEmployeeCd;
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
                                        prevCtrl = this.tEdit_SalesEmployeeCd;
                                        break;
                                    default:
                                        break;
                                }
                            }

                            break;

                        }
                    #endregion

                    #region ●得意先コード
                    case "tNedit_CustomerCode":
                        {
                            getNextCtrl = true;

                            bool canChangeFocus = true;
                            int code = this.tNedit_CustomerCode.GetInt();
                            CustomerInfo customerInfo = null;

                            if (salesSlipCurrent.CustomerCode != code)
                            {
                                // --- ADD 2009/09/08 ---------->>>>>
                                CustomerInfo mycustomerInfo;
                                int stu = this._customerInfoAcs.ReadDBData(this._enterpriseCode, code, true, out mycustomerInfo);
                                int carMngDiv = 0;
                                if (mycustomerInfo != null)
                                {
                                    carMngDiv = mycustomerInfo.CarMngDivCd;
                                }
                                // 車輌管理オプション有りの場合
                                if (this._estimateInputInitDataAcs.Opt_CarMng)
                                {
                                    //新規登録時の場合
                                    if (!_canDeleteSlip)
                                    {
                                        //得意先を変更した場合は、管理番号の値をクリアする
                                        this.tEdit_CarMngCode.Text = string.Empty;
                                        this._estimateInputAcs.SettingCarInfoRowFromCarMngCode(salesRowNo, string.Empty);
                                    }
                                    else
                                    {
                                        // 修正呼出しの場合
                                        if (carMngDiv == 0)
                                        {
                                            //得意先を変更した場合は、管理番号の値をクリアする
                                            this.tEdit_CarMngCode.Text = string.Empty;
                                            this._estimateInputAcs.SettingCarInfoRowFromCarMngCode(salesRowNo, string.Empty);
                                        }
                                    }
                                }
                                // --- ADD 2009/09/08 ----------<<<<<
                                if (code == 0)
                                {
                                    if (this._estimateInputAcs.ExistEstimateDetailCanGoodsPriceReSettingData())
                                    {
                                        string msg = "得意先が変更されました。" + "\r\n" + "\r\n" + "商品価格を再取得しますか？";

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
                                            reCalcPrice = true;
                                        }
                                        else
                                        {
                                            clearRateInfo = true;
                                        }
                                    }

                                    try
                                    {
                                        // 得意先（仕入先）情報設定処理
                                        this._estimateInputAcs.DataSettingSalesSlip(ref salesSlip, null);

                                        // 仕入明細データセッティング処理（課税区分設定）
                                        this._estimateInputAcs.DisplayPriceSetting(salesSlip.TotalAmountDispWayCd);

                                        // 非課税から変わったか、非課税に変わった場合は価格調整
                                        if ((salesSlip.ConsTaxLayMethod != salesSlipCurrent.ConsTaxLayMethod) &&
                                            ((salesSlip.ConsTaxLayMethod == 9) || (salesSlipCurrent.ConsTaxLayMethod == 9)))
                                        {
                                            adjustPrice = true;
                                        }
                                        reCalcPrice = true;
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
                                        inputError = true;
                                    }
                                    // 仕入データクラス→画面格納処理
                                    this.SetDisplay(salesSlip);
                                }
                                else
                                {
                                    this.Cursor = Cursors.WaitCursor;
                                    if (this._customerInfoAcs == null) this._customerInfoAcs = new CustomerInfoAcs();
                                    int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, code, true, false, out customerInfo);
                                    this.Cursor = Cursors.Default;


                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        // 得意先（仕入先）情報設定処理
                                        this._estimateInputAcs.DataSettingSalesSlip(ref salesSlip, customerInfo);

                                        // 仕入明細データセッティング処理（課税区分設定）
                                        this._estimateInputAcs.DisplayPriceSetting(salesSlip.TotalAmountDispWayCd);

                                        //if (( stockSlip.SupplierFormal == 0 ) && ( this._stockSlipInputAcs.ExistStockDetailCanGoodsPriceReSettingData() ))
                                        if (this._estimateInputAcs.ExistEstimateDetailCanGoodsPriceReSettingData())
                                        {
                                            string msg = "得意先が変更されました。" + "\r\n" + "\r\n" + "商品価格を再取得しますか？";

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
                                                reCalcPrice = true;
                                            }
                                            else
                                            {
                                                clearRateInfo = true;
                                            }

                                            // 非課税から変わったか、非課税に変わった場合は価格調整
                                            if ((salesSlip.ConsTaxLayMethod != salesSlipCurrent.ConsTaxLayMethod) &&
                                                ((salesSlip.ConsTaxLayMethod == 9) || (salesSlipCurrent.ConsTaxLayMethod == 9)))
                                            {
                                                adjustPrice = true;
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
                                            "得意先が存在しません。",
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
                                            "得意先の取得に失敗しました。",
                                            status,
                                            MessageBoxButtons.OK);

                                        canChangeFocus = false;
                                    }
                                }

                                // 仕入データクラス→画面格納処理
                                this.SetDisplay(salesSlip);
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

                                            if (this.tNedit_CustomerCode.GetInt() == 0)
                                            {
                                                //nextCtrl = this.uButton_CustomerGuide;
                                                nextCtrl = this.tEdit_CustomerName;
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

                    #region ●得意先名
                    case "tEdit_CustomerName":
                        {
                            getNextCtrl = true;
                            string name = this.tEdit_CustomerName.Text;

                            // --- UPD 2011/02/14 --------- >>>>>>>>>>
                            //if ((salesSlipCurrent.CustomerName.Trim() + salesSlipCurrent.CustomerName2.Trim()) != name)
                            if (salesSlipCurrent.CustomerSnm.Trim() != name)
                            {
                                if (!string.IsNullOrEmpty(name))
                                {
                                    //if (name.Length > 30) name = name.Substring(0, 30);
                                    if (name.Length > 20) name = name.Substring(0, 20);
                                    salesSlip.CustomerName = name;
                                    salesSlip.CustomerName2 = string.Empty;
                                    salesSlip.CustomerSnm = name;

                                    //if (salesSlip.CustomerSnm.Length > 20)
                                    //    salesSlip.CustomerSnm = salesSlip.CustomerSnm.Substring(0, 20);
                                }
                                else
                                {
                                    salesSlip.CustomerName = string.Empty;
                                    salesSlip.CustomerName2 = string.Empty;
                                    salesSlip.CustomerSnm = string.Empty;
                                }
                            }
                            // --- UPD 2011/02/14 --------- <<<<<<<<<<

                            getNextCtrl = true;
                            if (e.ShiftKey)
                            {
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        if ((salesSlip.CustomerCode == 0) && (string.IsNullOrEmpty(salesSlip.CustomerName)))
                                        {
                                            nextCtrl = this.uButton_CustomerGuide;
                                            getNextCtrl = false;
                                        }
                                        else
                                        {
                                            prevCtrl = this.tEdit_CustomerName;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        }
                    #endregion

                    #region ●得意先ガイドボタン
                    case "uButton_CustomerGuide":
                        {
                            getNextCtrl = true;

                            if (e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        if (this.tEdit_CustomerName.Enabled)
                                        {
                                            nextCtrl = this.tEdit_CustomerName;
                                        }
                                        else
                                        {
                                            nextCtrl = this.tNedit_CustomerCode;
                                        }
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
                                        if (this.tEdit_CustomerName.Enabled)
                                        {
                                            prevCtrl = this.tEdit_CustomerName;
                                        }
                                        else
                                        {
                                            prevCtrl = this.tNedit_CustomerCode;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        }
                    #endregion

                    #region ●見積日
                    case "tDateEdit_SalesDate":
                        {
                            getNextCtrl = true;

                            DateTime value = this.tDateEdit_SalesDate.GetDateTime();

                            if (salesSlipCurrent.SalesDate != value)
                            {
                                salesSlip.SalesDate = value;
                                salesSlip.EstimateValidityDate = salesSlip.SalesDate.AddMonths(this._estimateInputInitDataAcs.GetEstimateDefSet().EstimateValidityTerm);

                                DialogResult dialogResult = TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    this.Name,
                                    "見積日が変更されました。" + "\r\n" + "\r\n" + "商品価格を再取得しますか？",
                                    0,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxDefaultButton.Button1);

                                if (dialogResult == DialogResult.Yes)
                                {
                                    reCalcPrice = true;
                                }
                                else
                                {
                                    clearRateInfo = true;
                                }
                                double taxRate = this._estimateInputInitDataAcs.GetTaxRate(salesSlip.SalesDate);

                                if (taxRate != salesSlip.ConsTaxRate)
                                {
                                    salesSlip.ConsTaxRate = taxRate;
                                    adjustPrice = true;
                                }
                            }

                            break;

                        }
                    #endregion

                    #region ●見積有効期限
                    case "tDateEdit_EstimateValidityDate":
                        {
                            getNextCtrl = true;

                            DateTime value = this.tDateEdit_EstimateValidityDate.GetDateTime();

                            if (salesSlipCurrent.EstimateValidityDate != value)
                            {
                                salesSlip.EstimateValidityDate = value;
                            }

                            break;
                        }
                    #endregion

                    #endregion

                    #region ○車輌情報

                    #region 諸元情報
                    case "ultraGrid_CarSpec":
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    getNextCtrl = false;
                                    e.NextCtrl = this.tEdit_FullModel;
                                    break;
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    getNextCtrl = false;
                                    e.NextCtrl = this._estimateDetailInput.uGrid_Details;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                    #endregion

                    #region 管理番号
                    case "tEdit_CarMngCode":
                        {
                            // --- ADD 2009/09/08 ---------->>>>>
                            int flag = 0; //フォーカス　0:次項目　1:型式

                            int inputflg = 1; // 管理番号　0:異なる　1:同じ
                            // --- ADD 2009/09/08 ----------<<<<<

                            if ((carInfoRowCurrent != null) &&
                                (carInfoRowCurrent.CarMngCode != this.tEdit_CarMngCode.Text.Trim()))
                            {
                                this._estimateInputAcs.SettingCarInfoRowFromCarMngCode(salesRowNo, this.tEdit_CarMngCode.Text.Trim());
                                // --- ADD 2009/09/08 ---------->>>>>
                                inputflg = 0;
                            }

                            
                            //管理番号でのガイド表示設定
                            if (this._estimateInputInitDataAcs.Opt_CarMng)
                            {
                                flag = SettingCarMngNoGuide(this.tEdit_CarMngCode.Text.Trim(), inputflg);
                            }

                            getNextCtrl = true;
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    getNextCtrl = false;
                                    e.NextCtrl = this.tNedit_ModelDesignationNo;
                                    break;
                                case Keys.Return:
                                case Keys.Tab:
                                    if (flag == 0)
                                    {
                                        prevCtrl = this.tEdit_CarMngCode;
                                    }
                                    else if (flag == 1)
                                    {
                                        getNextCtrl = false;
                                        nextCtrl = this.GetNextCtrlAfterCarSearch();
                                    }
                                    else
                                    {
                                        prevCtrl = this.tDateEdit_EstimateValidityDate;
                                    }
                                    break;
                                default:
                                    break;
                            }
                           // --- ADD 2009/09/08 ----------<<<<<
                            break;
                        }
                    #endregion

                    #region 管理番号ガイドボタン
                    case "uButton_CarMngNoGuide":
                        {
                            getNextCtrl = true;

                            if (e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        nextCtrl = this.tEdit_CarMngCode;
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
                                        prevCtrl = this.tEdit_CarMngCode;
                                        break;
                                    default:
                                        break;
                                }
                            }

                            break;

                        }
                    #endregion

                    #region 型式指定番号
                    case "tNedit_ModelDesignationNo":
                        {
                            getNextCtrl = true;

                            //if (salesSlip.SearchMode == (int)EstimateInputAcs.SearchMode.BLSearch)
                            //{
                            //    if ((this.tNedit_ModelDesignationNo.GetInt() != 0) &&
                            //        (this.tNedit_CategoryNo.GetInt() != 0) &&
                            //        ((this.tNedit_ModelDesignationNo.GetInt() != carInfoRowCurrent.ModelDesignationNo) ||
                            //          (this.tNedit_CategoryNo.GetInt() != carInfoRowCurrent.CategoryNo) ||
                            //          (this._estimateInputAcs.SearchCarDiv)))
                            //    {
                            //        this._estimateInputAcs.SearchCarDiv = false;
                            //        CarSearchCondition con = new CarSearchCondition();
                            //        con.ModelDesignationNo = this.tNedit_ModelDesignationNo.GetInt();
                            //        con.CategoryNo = this.tNedit_CategoryNo.GetInt();
                            //        con.Type = CarSearchType.csCategory;
                            //        int status = this.CarSearch(con);
                            //        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            //        {
                            //            changeCarInfo = true;
                            //            nextCtrl = this.GetNextCtrlAfterCarSearch();
                            //            getNextCtrl = (nextCtrl == null);
                            //        }
                            //        else if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                            //        {
                            //            changeCarInfo = true;
                            //            inputError = true;
                            //            getNextCtrl = false;
                            //            e.NextCtrl = e.PrevCtrl;
                            //            break;
                            //        }
                            //        else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                            //        {
                            //            DialogResult dialogResult = TMsgDisp.Show(
                            //                this,
                            //                emErrorLevel.ERR_LEVEL_INFO,
                            //                this.Name,
                            //                "該当する車輌がありません。" + Environment.NewLine + "品番入力モードにしますか？",
                            //                0,
                            //                MessageBoxButtons.YesNo,
                            //                MessageBoxDefaultButton.Button2);

                            //            if (dialogResult == DialogResult.Yes)
                            //            {
                            //                this.ChangePartsSearchMode(ref salesSlip, true);
                            //                this._estimateInputAcs.SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo, carInfoRowCurrent.CarRelationGuid, this.tNedit_ModelDesignationNo.GetInt(), this.tNedit_CategoryNo.GetInt());
                            //            }
                            //            else
                            //            {
                            //                inputError = true;
                            //                getNextCtrl = false;
                            //                e.NextCtrl = e.PrevCtrl;
                            //            }
                            //            changeCarInfo = true;
                            //            break;
                            //        }
                            //        else if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                            //        {
                            //            DialogResult dialogResult = TMsgDisp.Show(
                            //                this,
                            //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            //                this.Name,
                            //                "検索中にエラーが発生しました。",
                            //                0,
                            //                MessageBoxButtons.OK,
                            //                MessageBoxDefaultButton.Button1);
                            //            changeCarInfo = true;
                            //            inputError = true;
                            //            getNextCtrl = false;
                            //            e.NextCtrl = e.PrevCtrl;
                            //        }
                            //        else
                            //        {
                            //            getNextCtrl = false;
                            //            e.NextCtrl = e.PrevCtrl;
                            //            break;
                            //        }
                            //    }
                            //    else
                            //    {
                            //        this._estimateInputAcs.SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo, carInfoRowCurrent.CarRelationGuid, this.tNedit_ModelDesignationNo.GetInt(), this.tNedit_CategoryNo.GetInt());
                            //    }
                            //}
                            //else
                            //{
                                this._estimateInputAcs.SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo, carInfoRowCurrent.CarRelationGuid, this.tNedit_ModelDesignationNo.GetInt(), this.tNedit_CategoryNo.GetInt());
                            //}

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Down:
                                        e.NextCtrl = this.tEdit_FullModel;
                                        break;
                                    case Keys.Return:
                                    case Keys.Tab:
                                        e.NextCtrl = this.tNedit_CategoryNo;
                                        getNextCtrl = false;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        }
                    #endregion

                    #region 類別区分番号
                    case "tNedit_CategoryNo":
                        {
                            getNextCtrl = true;
                            if (salesSlip.SearchMode == (int)EstimateInputAcs.SearchMode.BLSearch)
                            {
                                if ((this.tNedit_ModelDesignationNo.GetInt() != 0) &&
                                    (this.tNedit_CategoryNo.GetInt() != 0) &&
                                    ((this.tNedit_ModelDesignationNo.GetInt() != carInfoRowCurrent.ModelDesignationNo) ||
                                      (this.tNedit_CategoryNo.GetInt() != carInfoRowCurrent.CategoryNo) ||
                                      (this._estimateInputAcs.SearchCarDiv)))
                                {
                                    this._estimateInputAcs.SearchCarDiv = false;
                                    CarSearchCondition con = new CarSearchCondition();
                                    con.ModelDesignationNo = this.tNedit_ModelDesignationNo.GetInt();
                                    con.CategoryNo = this.tNedit_CategoryNo.GetInt();
                                    con.Type = CarSearchType.csCategory;
                                    int status = this.CarSearch(con);
                                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                    {
                                        changeCarInfo = true;
                                        nextCtrl = this.GetNextCtrlAfterCarSearch();
                                        getNextCtrl = (nextCtrl == null);

                                    }
                                    else if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                                    {
                                        changeCarInfo = true;
                                        inputError = true;
                                        getNextCtrl = false;
                                        e.NextCtrl = e.PrevCtrl;
                                        break;
                                    }
                                    else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                                    {
                                        DialogResult dialogResult = TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "該当する車輌がありません。" + Environment.NewLine + "品番入力モードにしますか？",
                                            0,
                                            MessageBoxButtons.YesNo,
                                            MessageBoxDefaultButton.Button2);

                                        if (dialogResult == DialogResult.Yes)
                                        {
                                            this.ChangePartsSearchMode(ref salesSlip, true);
                                            this._estimateInputAcs.SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo, carInfoRowCurrent.CarRelationGuid, this.tNedit_ModelDesignationNo.GetInt(), this.tNedit_CategoryNo.GetInt());
                                        }
                                        else
                                        {
                                            inputError = true;
                                            getNextCtrl = false;
                                            // --- UPD 2010/06/08 ---------->>>>>
                                            //e.NextCtrl = e.PrevCtrl;
                                            e.NextCtrl = tNedit_ModelDesignationNo;
                                            // --- UPD 2010/06/08 ----------<<<<<
                                        }
                                        changeCarInfo = true;
                                        break;
                                    }
                                    else if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                                    {
                                        DialogResult dialogResult = TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                            this.Name,
                                            "検索中にエラーが発生しました。",
                                            0,
                                            MessageBoxButtons.OK,
                                            MessageBoxDefaultButton.Button1);
                                        changeCarInfo = true;
                                        inputError = true;
                                        getNextCtrl = false;
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    else
                                    {
                                        getNextCtrl = false;
                                        e.NextCtrl = e.PrevCtrl;
                                        break;
                                    }
                                }
                                else
                                {
                                    this._estimateInputAcs.SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo, carInfoRowCurrent.CarRelationGuid, this.tNedit_ModelDesignationNo.GetInt(), this.tNedit_CategoryNo.GetInt());
                                }
                            }
                            else
                            {
                                this._estimateInputAcs.SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo, carInfoRowCurrent.CarRelationGuid, this.tNedit_ModelDesignationNo.GetInt(), this.tNedit_CategoryNo.GetInt());
                            }
                            prevCtrl = tNedit_ModelDesignationNo;
                            break;
                        }
                    #endregion

                    #region 型式／モデルプレート
                    case "tEdit_FullModel":
                        {
                            getNextCtrl = true;

                            if (salesSlip.SearchMode == (int)EstimateInputAcs.SearchMode.BLSearch)
                            {
                                string newValue = this.tEdit_FullModel.Text.Trim();
                                if (salesSlip.SearchCarMode == (int)EstimateInputAcs.SearchCarMode.FullModelSearch)
                                {
                                    //---------------------------------------------------------------
                                    // 型式検索
                                    //---------------------------------------------------------------
                                    if ((!string.IsNullOrEmpty(newValue)) &&
                                        ((carInfoRowCurrent == null) ||
                                          (carInfoRowCurrent.FullModel != newValue) ||
                                          (this._estimateInputAcs.SearchCarDiv)))
                                    {
                                        this._estimateInputAcs.SearchCarDiv = false;
                                        CarSearchCondition con = new CarSearchCondition();
                                        con.CarModel.FullModel = newValue;
                                        con.Type = CarSearchType.csModel;
                                        int status = this.CarSearch(con);
                                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                        {
                                            changeCarInfo = true;
                                            nextCtrl = this.GetNextCtrlAfterCarSearch();
                                            getNextCtrl = (nextCtrl == null);

                                        }
                                        else if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                                        {
                                            changeCarInfo = true;
                                            inputError = true;
                                            getNextCtrl = false;
                                            e.NextCtrl = e.PrevCtrl;
                                            break;
                                        }
                                        else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                                        {
                                            DialogResult dialogResult = TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                "該当する車輌がありません。" + Environment.NewLine + "品番入力モードにしますか？",
                                                0,
                                                MessageBoxButtons.YesNo,
                                                MessageBoxDefaultButton.Button2);

                                            if (dialogResult == DialogResult.Yes)
                                            {
                                                this.ChangePartsSearchMode(ref salesSlip, true);
                                                this._estimateInputAcs.SettingCarInfoRowFromFullModel(salesRowNo, carInfoRowCurrent.CarRelationGuid, newValue);
                                            }
                                            else
                                            {
                                                inputError = true;
                                                getNextCtrl = false;
                                                e.NextCtrl = e.PrevCtrl;
                                            }
                                            changeCarInfo = true;
                                            break;
                                        }
                                        else if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                                        {
                                            DialogResult dialogResult = TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                this.Name,
                                                "検索中にエラーが発生しました。",
                                                0,
                                                MessageBoxButtons.OK,
                                                MessageBoxDefaultButton.Button1);
                                            changeCarInfo = true;
                                            inputError = true;
                                            getNextCtrl = false;
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        else
                                        {
                                            getNextCtrl = false;
                                            e.NextCtrl = e.PrevCtrl;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        // 車輌情報クリア
                                        if ((!string.IsNullOrEmpty(carInfoRowCurrent.FullModel)) &&
                                            (string.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim()))) this._estimateInputAcs.ClearCarInfoRow(salesRowNo);
                                    }
                                }
                                else if (salesSlip.SearchCarMode == (int)EstimateInputAcs.SearchCarMode.ModelPlateSearch)
                                {
                                    //---------------------------------------------------------------
                                    // モデルプレート検索
                                    //---------------------------------------------------------------
                                    if ((!string.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim())) &&
                                        ((carInfoRowCurrent == null) ||
                                        (carInfoRowCurrent.FullModel != this.tEdit_FullModel.Text.Trim()) ||
                                        (this._estimateInputAcs.SearchCarDiv)))
                                    {
                                        this._estimateInputAcs.SearchCarDiv = false;
                                        CarSearchCondition con = new CarSearchCondition();
                                        con.ModelPlate = this.tEdit_FullModel.Text;
                                        con.Type = CarSearchType.csPlate;
                                        int status = this.CarSearch(con);
                                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                        {
                                            changeCarInfo = true;
                                            nextCtrl = this.GetNextCtrlAfterCarSearch();
                                            getNextCtrl = (nextCtrl == null);

                                            this.ChangeCarSearchMode(ref salesSlip, false); // 型式へ戻す
                                        }
                                        else if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                                        {
                                            changeCarInfo = true;
                                            inputError = true;
                                            getNextCtrl = false;
                                            e.NextCtrl = e.PrevCtrl;
                                            break;
                                        }
                                        else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                                        {
                                            DialogResult dialogResult = TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                "該当する車輌がありません。" + Environment.NewLine + "品番入力モードにしますか？",
                                                0,
                                                MessageBoxButtons.YesNo,
                                                MessageBoxDefaultButton.Button2);

                                            if (dialogResult == DialogResult.Yes)
                                            {
                                                this.ChangePartsSearchMode(ref salesSlip, true);
                                                this._estimateInputAcs.SettingCarInfoRowFromFullModel(salesRowNo, carInfoRowCurrent.CarRelationGuid, newValue);
                                            }
                                            else
                                            {
                                                inputError = true;
                                                getNextCtrl = false;
                                                e.NextCtrl = e.PrevCtrl;
                                            }
                                            changeCarInfo = true;
                                            break;
                                        }
                                        else if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                                        {
                                            DialogResult dialogResult = TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                this.Name,
                                                "検索中にエラーが発生しました。",
                                                0,
                                                MessageBoxButtons.OK,
                                                MessageBoxDefaultButton.Button1);
                                            changeCarInfo = true;
                                            inputError = true;
                                            getNextCtrl = false;
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        else
                                        {
                                            getNextCtrl = false;
                                            e.NextCtrl = e.PrevCtrl;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        // 車輌情報クリア
                                        if ((!string.IsNullOrEmpty(carInfoRowCurrent.FullModel)) &&
                                            (string.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim()))) this._estimateInputAcs.ClearCarInfoRow(salesRowNo);
                                    }
                                }
                            }
                            else
                            {
                                this._estimateInputAcs.SettingCarInfoRowFromFullModel(salesRowNo, carInfoRowCurrent.CarRelationGuid, this.tEdit_FullModel.Text);
                            }


                            switch (e.Key)
                            {
                                case Keys.Down:
                                    if (!inputError)
                                    {
                                        getNextCtrl = false;
                                        e.NextCtrl = this._estimateDetailInput.uGrid_Details;
                                    }
                                    break;
                                case Keys.Up:
                                    if (!inputError)
                                    {
                                        getNextCtrl = false;
                                        e.NextCtrl = this.tNedit_ModelDesignationNo;
                                    }
                                    break;
                                default:
                                    break;
                            }

                            break;
                        }
                    #endregion

                    #region エンジン型式
                    case "tEdit_EngineModelNm":
                        {
                            getNextCtrl = true;
                            if (salesSlip.SearchMode == (int)EstimateInputAcs.SearchMode.BLSearch)
                            {
                                string newValue = this.tEdit_EngineModelNm.Text.Trim();

                                if ((!string.IsNullOrEmpty(newValue)) &&
                                    ((carInfoRowCurrent == null) ||
                                      (carInfoRowCurrent.EngineModelNm != newValue) ||
                                      (this._estimateInputAcs.SearchCarDiv)))
                                {
                                    this._estimateInputAcs.SearchCarDiv = false;
                                    CarSearchCondition con = new CarSearchCondition();
                                    con.EngineModel.FullModel = newValue;
                                    con.Type = CarSearchType.csEngineModel;
                                    int status = this.CarSearch(con);
                                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                    {
                                        nextCtrl = this.GetNextCtrlAfterCarSearch();
                                        getNextCtrl = (nextCtrl == null);

                                        changeCarInfo = true;
                                        break;
                                    }
                                    else if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                                    {
                                        inputError = true;
                                        getNextCtrl = false;
                                        e.NextCtrl = e.PrevCtrl;
                                        changeCarInfo = true;
                                        break;

                                    }
                                    else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                                    {
                                        DialogResult dialogResult = TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "該当する車輌がありません。" + Environment.NewLine + "品番入力モードにしますか？",
                                            0,
                                            MessageBoxButtons.YesNo,
                                            MessageBoxDefaultButton.Button2);

                                        if (dialogResult == DialogResult.Yes)
                                        {
                                            this.ChangePartsSearchMode(ref salesSlip, true);
                                            this._estimateInputAcs.SettingCarInfoRowFromEngineModelNm(salesRowNo, newValue);
                                        }
                                        else
                                        {
                                            inputError = true;
                                            getNextCtrl = false;
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        changeCarInfo = true;
                                        break;
                                    }
                                    else if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                                    {
                                        DialogResult dialogResult = TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                            this.Name,
                                            "検索中にエラーが発生しました。",
                                            0,
                                            MessageBoxButtons.OK,
                                            MessageBoxDefaultButton.Button1);
                                        changeCarInfo = true;
                                        inputError = true;
                                        getNextCtrl = false;
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    else
                                    {
                                        getNextCtrl = false;
                                        e.NextCtrl = e.PrevCtrl;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                this._estimateInputAcs.SettingCarInfoRowFromEngineModelNm(salesRowNo, this.tEdit_EngineModelNm.Text.Trim());
                            }

                            break;
                        }
                    #endregion

                    #region カラー
                    case "tEdit_ColorNo":
                        {
                            bool canChangeFocus = true;
                            string code = this.tEdit_ColorNo.Text.Trim();
                            string beforeCode = carInfoRowCurrent.ColorCode;
                            if (beforeCode != code)
                            {
                                if (string.IsNullOrEmpty(code))
                                {
                                    this._estimateInputAcs.SelectColorInfo(carInfoRowCurrent.CarRelationGuid, code);
                                    //this.tEdit_ColorNo.Text = string.Empty;
                                }
                                else
                                {
                                    if (!this._estimateInputAcs.SelectColorInfo(carInfoRowCurrent.CarRelationGuid, code))
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "カラーが存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);

                                        canChangeFocus = false;
                                        inputError = true;
                                        this._estimateInputAcs.SelectColorInfo(carInfoRowCurrent.CarRelationGuid, beforeCode);
                                        this.tEdit_ColorNo.Text = beforeCode;
                                    }
                                }
                                changeCarInfo = true;
                            }

                            if (!canChangeFocus)
                            {
                                getNextCtrl = false;
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                getNextCtrl = true;
                            }

                            break;
                        }
                    #endregion

                    #region トリム
                    case "tEdit_TrimNo":
                        {

                            bool canChangeFocus = true;
                            string code = this.tEdit_TrimNo.Text.Trim();
                            string beforeCode = carInfoRowCurrent.TrimCode;
                            if (beforeCode != code)
                            {
                                if (string.IsNullOrEmpty(code))
                                {
                                    this._estimateInputAcs.SelectTrimInfo(carInfoRowCurrent.CarRelationGuid, code);
                                    //this.tEdit_TrimNo.Text = string.Empty;
                                }
                                else
                                {
                                    if (!this._estimateInputAcs.SelectTrimInfo(carInfoRowCurrent.CarRelationGuid, code))
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "トリムが存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);

                                        canChangeFocus = false;
                                        inputError = true;
                                        this._estimateInputAcs.SelectTrimInfo(carInfoRowCurrent.CarRelationGuid, beforeCode);
                                        //this.tEdit_TrimNo.Text = beforeCode;
                                    }
                                }
                                changeCarInfo = true;
                            }

                            if (!canChangeFocus)
                            {
                                getNextCtrl = false;
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                getNextCtrl = true;

                                switch (e.Key)
                                {
                                    case Keys.Down:
                                        getNextCtrl = false;
                                        e.NextCtrl = this._estimateDetailInput.uGrid_Details;
                                        break;
                                    default:
                                        break;
                                }
                            }

                            break;
                        }
                    #endregion

                    #region カーメーカーコード
                    case "tNedit_MakerCode":
                        {
                            bool canChangeFocus = true;

                            int code = this.tNedit_MakerCode.GetInt();

                            if ((carInfoRowCurrent != null) &&
                                (carInfoRowCurrent.MakerCode != code))
                            {
                                changeCarInfo = true;
                                if (code == 0)
                                {
                                    this._estimateInputAcs.ClearCarInfo(salesRowNo);   // ADD 2011/02/14
                                    this._estimateInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, 0, string.Empty, string.Empty, 0, 0, string.Empty, string.Empty);
                                    this.ClearDisplayCarInfoForModelCode(); // ADD 2011/02/14
                                    this.uExpandableGroupBox_CarInfo.Enabled = false; // ADD 2011/02/14
                                    this.uExpandableGroupBox_CarInfo.Expanded = false; // ADD 2011/02/14
                                    changeCarInfo = true;
                                }
                                else
                                {
                                    int makerCode = this.tNedit_MakerCode.GetInt();
                                    string makerName, makerKanaName;
                                    bool readed = this._estimateInputInitDataAcs.GetName_FromMaker(makerCode, out makerName, out makerKanaName);
                                    if (!readed)
                                    {
                                        TMsgDisp.Show(
                                           this,
                                           emErrorLevel.ERR_LEVEL_INFO,
                                           this.Name,
                                           "メーカーが存在しません",
                                           -1,
                                           MessageBoxButtons.OK);

                                        canChangeFocus = false;
                                        inputError = true;
                                    }
                                    else
                                    {
                                        this._estimateInputAcs.ClearCarInfo(salesRowNo);   // ADD 2011/02/14
                                        this._estimateInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, makerCode, makerName, makerKanaName, 0, 0, string.Empty, string.Empty);
                                        this.ClearDisplayCarInfoForModelCode(); // ADD 2011/02/14
                                        this.uExpandableGroupBox_CarInfo.Enabled = false; // ADD 2011/02/14
                                        this.uExpandableGroupBox_CarInfo.Expanded = false; // ADD 2011/02/14
                                    }
                                }
                            }
                           
                            if (!canChangeFocus)
                            {
                                getNextCtrl = false;
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                getNextCtrl = true;
                            }
                            break;
                        }
                    #endregion

                    #region 車種コード
                    case "tNedit_ModelCode":
                        {
                            bool canChangeFocus = true;

                            int code = this.tNedit_ModelCode.GetInt();

                            if ((carInfoRowCurrent != null) &&
                                (carInfoRowCurrent.ModelCode != code))
                            {
                                changeCarInfo = true;

                                if (code == 0)
                                {
                                    this._estimateInputAcs.ClearCarInfoForModelCode(salesRowNo);   // ADD 2011/02/14
                                    this._estimateInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, carInfoRowCurrent.MakerCode, carInfoRowCurrent.MakerFullName, carInfoRowCurrent.MakerHalfName, 0, 0, string.Empty, string.Empty);
                                    this.ClearDisplayCarInfoForModelCode(); // ADD 2011/02/14
                                    this.uExpandableGroupBox_CarInfo.Enabled = false; // ADD 2011/02/14
                                    this.uExpandableGroupBox_CarInfo.Expanded = false; // ADD 2011/02/14
                                }
                                else
                                {
                                    ModelNameU modelNameU = this._estimateInputAcs.GetModelInfo(carInfoRowCurrent.MakerCode, code, 0);

                                    if (modelNameU == null)
                                    {
                                        TMsgDisp.Show(
                                              this,
                                              emErrorLevel.ERR_LEVEL_INFO,
                                              this.Name,
                                              "車種が存在しません",
                                              -1,
                                              MessageBoxButtons.OK);

                                        canChangeFocus = false;
                                        inputError = true;
                                    }
                                    else
                                    {
                                        this._estimateInputAcs.ClearCarInfoForModelCode(salesRowNo);   // ADD 2011/02/14
                                        this._estimateInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, carInfoRowCurrent.MakerCode, carInfoRowCurrent.MakerFullName, carInfoRowCurrent.MakerHalfName, modelNameU.ModelCode, modelNameU.ModelSubCode, modelNameU.ModelFullName, modelNameU.ModelHalfName);
                                        this.ClearDisplayCarInfoForModelCode(); // ADD 2011/02/14
                                        this.uExpandableGroupBox_CarInfo.Enabled = false; // ADD 2011/02/14
                                        this.uExpandableGroupBox_CarInfo.Expanded = false; // ADD 2011/02/14
                                    }
                                }
                            }

                            if (!canChangeFocus)
                            {
                                getNextCtrl = false;
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                getNextCtrl = true;
                            }

                            break;
                        }
                    #endregion

                    #region 車種呼称コード
                    case "tNedit_ModelSubCode":
                        {
                            bool canChangeFocus = true;

                            int code = this.tNedit_ModelSubCode.GetInt();

                            if ((carInfoRowCurrent != null) &&
                                (carInfoRowCurrent.ModelSubCode != code))
                            {
                                changeCarInfo = true;

                                ModelNameU modelNameU = this._estimateInputAcs.GetModelInfo(carInfoRowCurrent.MakerCode, carInfoRowCurrent.ModelCode, code);

                                if (modelNameU == null)
                                {
                                    TMsgDisp.Show(
                                          this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "車種が存在しません",
                                          -1,
                                          MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                    inputError = true;
                                }
                                else
                                {
                                    this._estimateInputAcs.ClearCarInfoForModelCode(salesRowNo);   // ADD 2011/02/14
                                    this._estimateInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, carInfoRowCurrent.MakerCode, carInfoRowCurrent.MakerFullName, carInfoRowCurrent.MakerHalfName, modelNameU.ModelCode, modelNameU.ModelSubCode, modelNameU.ModelFullName, modelNameU.ModelHalfName);
                                    this.ClearDisplayCarInfoForModelCode(); // ADD 2011/02/14
                                    this.uExpandableGroupBox_CarInfo.Enabled = false; // ADD 2011/02/14
                                    this.uExpandableGroupBox_CarInfo.Expanded = false; // ADD 2011/02/14
                                }
                            }

                            if (!canChangeFocus)
                            {
                                getNextCtrl = false;
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                getNextCtrl = true;

                            }

                            break;
                        }
                    #endregion

                    #region 車種名称
                    case "tEdit_ModelFullName":
                        {
                            bool canChangeFocus = true;

                            string newValue = this.tEdit_ModelFullName.Text.Trim();
                            if ((carInfoRowCurrent != null) &&
                                (carInfoRowCurrent.ModelFullName != newValue))
                            {
                                changeCarInfo = true;
                                this._estimateInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, carInfoRowCurrent.MakerCode, carInfoRowCurrent.MakerFullName, carInfoRowCurrent.MakerHalfName, carInfoRowCurrent.ModelCode, carInfoRowCurrent.ModelSubCode, newValue, newValue);
                            }

                            if (!canChangeFocus)
                            {
                                getNextCtrl = false;
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                getNextCtrl = true;
                                if (!e.ShiftKey)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Return:
                                        case Keys.Tab:

                                            if (string.IsNullOrEmpty(this.tEdit_ModelFullName.Text.Trim()))
                                            {
                                                nextCtrl = this.uButton_ModelFullGuide;
                                                getNextCtrl = false;
                                            }

                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }

                            break;
                        }
                    #endregion

                    #region 年式
                    case "tDateEdit_FirstEntryDate":
                        {
                            bool canChangeFocus = true;
                            TDateEdit tempFirstEntryDate = (this.tDateEdit_FirstEntryDate as TDateEdit);
                            if (this._dateGetAcs == null) this._dateGetAcs = DateGetAcs.GetInstance();
                            DateGetAcs.CheckDateResult res = this._dateGetAcs.CheckDateForFirstEntryDate(ref tempFirstEntryDate, true);
                            if (res == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "日付が不正です。",
                                    -1,
                                    MessageBoxButtons.OK);
                                e.NextCtrl = prevCtrl;
                                changeCarInfo = true;
                                canChangeFocus = false;

                            }
                            else
                            {
                                int newValue = this.tDateEdit_FirstEntryDate.GetLongDate();
                                if (carInfoRowCurrent.ProduceTypeOfYearInput != (newValue / 100))
                                {
                                    if (this._estimateInputAcs.CheckProduceTypeOfYearRange(carInfoRowCurrent.CarRelationGuid, newValue))
                                    {
                                        // 年式設定処理
                                        this._estimateInputAcs.SettingCarInfoRowFromFirstEntryDate(salesRowNo, newValue);
                                        this._estimateInputAcs.SettingCarModelUIDataFromFirstEntryDate(carInfoRowCurrent.CarRelationGuid, newValue);
                                        changeCarInfo = true;
                                        getNextCtrl = true;
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "生産年式が設定範囲外です。",
                                            -1,
                                            MessageBoxButtons.OK);
                                        e.NextCtrl = prevCtrl;
                                        changeCarInfo = true;
                                        canChangeFocus = false;
                                    }
                                }

                                if (canChangeFocus)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Down:
                                            canChangeFocus = false;
                                            e.NextCtrl = this.tEdit_ProduceFrameNo;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            getNextCtrl = canChangeFocus;

                            break;
                        }
                    #endregion

                    #region 車台番号
                    case "tEdit_ProduceFrameNo":
                        {
                            bool canChangeFocus = true;
                            bool focusFlg = true;         // ADD 2011/02/14

                            string newValue = this.tEdit_ProduceFrameNo.Text;
                            int newIntValue = TStrConv.StrToIntDef(newValue.Trim(), 0);
                            if (carInfoRowCurrent.FrameNo != newValue)
                            {
                                // 2009.06.18 >>>
                                //// 車台番号設定処理
                                //this._estimateInputAcs.SettingCarInfoRowFromFrameNo(salesRowNo, newValue);
                                //this._estimateInputAcs.SettingCarModelUIDataFromProduceFrameNo(carInfoRowCurrent.CarRelationGuid, newValue);

                                //// 年式取得処理
                                //int firstEntryDate = this._estimateInputAcs.GetProduceTypeOfYear(carInfoRowCurrent.CarRelationGuid, newIntValue);

                                //// 年式設定処理
                                //if ( firstEntryDate != 0 )
                                //{
                                //    this._estimateInputAcs.SettingCarInfoRowFromFirstEntryDate(salesRowNo, firstEntryDate);
                                //}

                                //this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);

                                //changeCarInfo = true;

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 DEL
                                //if (this._estimateInputAcs.CheckProduceFrameNo(carInfoRowCurrent.CarRelationGuid, newIntValue))
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
                                if (this._estimateInputAcs.CheckProduceFrameNo(carInfoRowCurrent.CarRelationGuid, newValue, newIntValue))
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
                                {
                                    // 車台番号設定処理
                                    this._estimateInputAcs.SettingCarInfoRowFromFrameNo(salesRowNo, newValue);
                                    this._estimateInputAcs.SettingCarModelUIDataFromProduceFrameNo(carInfoRowCurrent.CarRelationGuid, newValue);

                                    // 年式取得処理
                                    int firstEntryDate = this._estimateInputAcs.GetProduceTypeOfYear(carInfoRowCurrent.CarRelationGuid, newIntValue);

                                    // 年式設定処理
                                    // --- UPD 2011/02/14 ---------->>>>>
                                    if (firstEntryDate != 0)
                                    {
                                        if (this._estimateInputAcs.CheckProduceTypeOfYearRange(carInfoRowCurrent.CarRelationGuid, firstEntryDate))
                                        {
                                            this._estimateInputAcs.SettingCarInfoRowFromFirstEntryDate(salesRowNo, firstEntryDate);
                                        }
                                        else if (!string.IsNullOrEmpty(tEdit_ProduceFrameNo.Text))
                                        {
                                            TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "生産年式が設定範囲外です。",
                                            -1,
                                            MessageBoxButtons.OK);
                                            e.NextCtrl = prevCtrl;
                                            canChangeFocus = false;
                                            focusFlg = false;
                                            this._carNoErrorFlg = true; // ADD 2011/03/28
                                            this._estimateInputAcs.ClearCarInfoForProduceTypeOfYear(salesRowNo); // ADD 2011/02/14
                                        }
                                    }
                                    // --- UPD 2011/02/14 ----------<<<<<
                                    this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);

                                    changeCarInfo = true;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "車台番号が設定範囲外です。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    e.NextCtrl = prevCtrl;
                                    changeCarInfo = true;
                                    canChangeFocus = false;
                                    inputError = true;
                                    focusFlg = false; // ADD 2011/02/14
                                }
                                // 2009.06.18 <<<
                            }
                            // --- ADD 2011/02/14 ---------->>>>>
                            else
                            {
                                if (this._estimateInputAcs.CheckProduceFrameNo(carInfoRowCurrent.CarRelationGuid, newValue, newIntValue))
                                {
                                    // 車台番号設定処理
                                    this._estimateInputAcs.SettingCarInfoRowFromFrameNo(salesRowNo, newValue);
                                    this._estimateInputAcs.SettingCarModelUIDataFromProduceFrameNo(carInfoRowCurrent.CarRelationGuid, newValue);

                                    // 年式取得処理
                                    int firstEntryDate = this._estimateInputAcs.GetProduceTypeOfYear(carInfoRowCurrent.CarRelationGuid, newIntValue);

                                    // 年式設定処理
                                    // --- UPD 2011/02/14 ---------->>>>>
                                    if (firstEntryDate != 0)
                                    {
                                        if (this._estimateInputAcs.CheckProduceTypeOfYearRange(carInfoRowCurrent.CarRelationGuid, firstEntryDate))
                                        {
                                            this._estimateInputAcs.SettingCarInfoRowFromFirstEntryDate(salesRowNo, firstEntryDate);
                                        }
                                        else if (!string.IsNullOrEmpty(tEdit_ProduceFrameNo.Text))
                                        {
                                            TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "生産年式が設定範囲外です。",
                                            -1,
                                            MessageBoxButtons.OK);
                                            e.NextCtrl = prevCtrl;
                                            canChangeFocus = false;
                                            focusFlg = false; // ADD 2011/02/14
                                            this._carNoErrorFlg = true; // ADD 2011/03/28
                                            this._estimateInputAcs.ClearCarInfoForProduceTypeOfYear(salesRowNo); // ADD 2011/02/14
                                        }
                                    }
                                    // --- UPD 2011/02/14 ----------<<<<<
                                    this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "車台番号が設定範囲外です。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    e.NextCtrl = prevCtrl;
                                    canChangeFocus = false;
                                    focusFlg = false; // ADD 2011/02/14
                                }
                            }
                            // --- ADD 2011/02/14 ----------<<<<<
                            getNextCtrl = canChangeFocus;
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    getNextCtrl = false;
                                    // UPD 2011/02/14 --- >>>>
                                    //e.NextCtrl = this._estimateDetailInput.uGrid_Details;
                                    if (focusFlg)
                                    {
                                        e.NextCtrl = this._estimateDetailInput.uGrid_Details;
                                    }
                                    // UPD 2011/02/14 --- <<<<
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                    #endregion

                    #region 車輌検索切替ボタン
                    case "uButton_ChangeSearchCarMode":
                        {
                            switch (e.Key)
                            {
                                case Keys.Down:
                                    getNextCtrl = false;
                                    e.NextCtrl = this._estimateDetailInput.uGrid_Details;
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                    #endregion

                    #region 車種ガイドボタン
                    case "uButton_ModelFullGuide":
                        {
                            getNextCtrl = true;

                            if (e.ShiftKey)
                            {
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        prevCtrl = this.tEdit_ModelFullName;
                                        break;
                                    default:
                                        break;
                                }
                            }

                            break;

                        }
                    #endregion

                    #endregion
                }
            }
            if (inputError)
            {
                this.ultraLabel17.Focus();
            }

            // メモリ上の内容と比較する
            ArrayList arRetList = salesSlip.Compare(salesSlipCurrent);

            if (arRetList.Count > 0)
            {
                // 売上データキャッシュ処理
                this._estimateInputAcs.Cache(salesSlip);

                // 売上データクラス→画面格納処理
                this.SetDisplay(salesSlip);

                // データ変更フラグプロパティをTrueにする
                this._estimateInputAcs.IsDataChanged = true;

                // --- ADD 2009/09/08 ---------->>>>>
                //管理番号でのガイド表示
                SettingCarMngNoGuideVisible();
                // --- ADD 2009/09/08 ----------<<<<<
            }

            if (adjustPrice)
            {
                // 仕入明細データセッティング処理（単価調整）
                this._estimateInputAcs.EstimateDetailRowPriceAdjust();
            }

            if (reCalcPrice)
            {
                // 商品価格の再設定を行います。
                //this._estimateInputAcs.PriceReSetting();
                this.PriceReSetting();
            }

            if (clearRateInfo)
            {
                this._estimateInputAcs.AllTableClearRateInfo();
            }
            //---------------------------------------------------------------
            // 車輌情報変更時
            //---------------------------------------------------------------
            if (changeCarInfo == true)
            {
                // 車輌情報画面表示処理
                this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);

                // 売上データクラス→画面格納処理
                this.SetDisplay(salesSlip);
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 ADD
            //----------------------------------------------------------------
            // 車輌検索前に退避しておいた内容の再セット
            //----------------------------------------------------------------
            # region [車輌検索前に退避しておいた内容の再セット]
            // 退避しておいた値のセット（※UI表示の都合により先にセットだけしておき、まとめて入力チェックする）
            if ( this._beforeCarSearchBuffer.ProduceFrameNo != string.Empty )
            {
                tEdit_ProduceFrameNo.Text = this._beforeCarSearchBuffer.ProduceFrameNo;
            }
            if ( this._beforeCarSearchBuffer.FirstEntryDate != 0 )
            {
                tDateEdit_FirstEntryDate.SetLongDate( this._beforeCarSearchBuffer.FirstEntryDate );
            }
            if ( this._beforeCarSearchBuffer.ColorNo != string.Empty )
            {
                tEdit_ColorNo.Text = this._beforeCarSearchBuffer.ColorNo;
            }
            if ( this._beforeCarSearchBuffer.TrimNo != string.Empty )
            {
                tEdit_TrimNo.Text = this._beforeCarSearchBuffer.TrimNo;
            }

            // 入力チェック
            // --- UPD 2010/06/08 ---------->>>>>
            //if ( this._beforeCarSearchBuffer.ProduceFrameNo != string.Empty )
            if ((this._beforeCarSearchBuffer.ProduceFrameNo != string.Empty) ||
                (!string.IsNullOrEmpty(tEdit_ProduceFrameNo.Text)))
            // --- UPD 2010/06/08 ----------<<<<<
            {
                # region [車台番号]
                //tEdit_ProduceFrameNo.Text = this._beforeCarSearchBuffer.ProduceFrameNo; // DEL 2010/06/08
                string newValue = this.tEdit_ProduceFrameNo.Text;
                int newIntValue = TStrConv.StrToIntDef( newValue.Trim(), 0 );

                // 車台番号番号のチェック
                if ( this._estimateInputAcs.CheckProduceFrameNo( carInfoRowCurrent.CarRelationGuid, newValue, newIntValue ) )
                {
                    // 車台番号設定処理
                    this._estimateInputAcs.SettingCarInfoRowFromFrameNo( salesRowNo, newValue );
                    this._estimateInputAcs.SettingCarModelUIDataFromProduceFrameNo( carInfoRowCurrent.CarRelationGuid, newValue );

                    // 年式取得処理
                    int firstEntryDate = this._estimateInputAcs.GetProduceTypeOfYear( carInfoRowCurrent.CarRelationGuid, newIntValue );

                    // --- UPD 2011/02/14 ---------->>>>>
                    //if (firstEntryDate != 0)
                    if (firstEntryDate != 0 && this._estimateInputAcs.CheckProduceTypeOfYearRange(carInfoRowCurrent.CarRelationGuid, firstEntryDate))
                    // --- UPD 2011/02/14 ----------<<<<<
                    {
                        this._estimateInputAcs.SettingCarInfoRowFromFirstEntryDate( salesRowNo, firstEntryDate );
                        this._estimateInputAcs.SettingCarModelUIDataFromFirstEntryDate( carInfoRowCurrent.CarRelationGuid, firstEntryDate );
                    }
                    
                    // --- UPD 2011/02/14 ---------->>>>>
                    //this.SetDisplayCarInfo( salesRowNo, CarSearchType.csNone );
                    if (!this._estimateInputAcs.CheckProduceTypeOfYearRange(carInfoRowCurrent.CarRelationGuid, firstEntryDate))
                    {
                        this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);
                        this.tDateEdit_FirstEntryDate.Clear();
                    }
                    else
                    {
                        this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);
                    }
                    // --- UPD 2011/02/14 ----------<<<<<

                    // PMNS:ハンドル位置のチェック
                    // --- ADD 2013/03/21 ---------->>>>>
                    // 型式が入力済みかつ、メーカーコードがBENZ、
                    // VINコードが入力済みの場合(外車の場合)
                    // ハンドル位置をチェックする
                    //if (!string.IsNullOrEmpty(carInfoRowCurrent.FullModel) && //DEL 2013/05/13 chenw FOR Redmine#34803
                    if (carInfoRowCurrent != null && !string.IsNullOrEmpty(carInfoRowCurrent.FullModel) && //ADD 2013/05/13 chenw FOR Redmine#34803
                        carInfoRowCurrent.MakerCode == 80 &&
                        carInfoRowCurrent.DomesticForeignCode == 2 &&
                        !this._estimateInputAcs.CheckHandlePosition(carInfoRowCurrent.CarRelationGuid, carInfoRowCurrent.FrameNo))
                    {
                        if (!(e.PrevCtrl != tEdit_ProduceFrameNo && e.NextCtrl != tEdit_ProduceFrameNo))
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "ハンドル位置が異なります。",
                            -1,
                            MessageBoxButtons.OK);
                        }
                        e.NextCtrl = tEdit_ProduceFrameNo;
                        nextCtrl = null;
                        getNextCtrl = false;
                        this.tEdit_ProduceFrameNo.Select(0, this.tEdit_ProduceFrameNo.Text.Length);
                    }
                    // --- ADD 2013/03/21 ----------<<<<<
                }
                else
                {
                    TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "車台番号が設定範囲外です。",
                            -1,
                            MessageBoxButtons.OK );
                    e.NextCtrl = tEdit_ProduceFrameNo;
                    nextCtrl = null;
                    getNextCtrl = false;
                    this.tEdit_ProduceFrameNo.Text = string.Empty;
                }
                # endregion
            }
            if ( this._beforeCarSearchBuffer.FirstEntryDate != 0 )
            {
                # region [年式]
                tDateEdit_FirstEntryDate.SetLongDate( this._beforeCarSearchBuffer.FirstEntryDate );
                TDateEdit tempFirstEntryDate = (this.tDateEdit_FirstEntryDate as TDateEdit);
                if (this._dateGetAcs == null) this._dateGetAcs = DateGetAcs.GetInstance();// ADD 2009/10/16
                DateGetAcs.CheckDateResult res = this._dateGetAcs.CheckDateForFirstEntryDate( ref tempFirstEntryDate, true );
                if ( res == DateGetAcs.CheckDateResult.ErrorOfInvalid )
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "日付が不正です。",
                        -1,
                        MessageBoxButtons.OK );
                    e.NextCtrl = tDateEdit_FirstEntryDate;
                    nextCtrl = null;
                    getNextCtrl = false;
                }
                else
                {
                    int newValue = this.tDateEdit_FirstEntryDate.GetLongDate();
                    if ( carInfoRowCurrent.ProduceTypeOfYearInput != (newValue / 100) )
                    {
                        if ( this._estimateInputAcs.CheckProduceTypeOfYearRange( carInfoRowCurrent.CarRelationGuid, tDateEdit_FirstEntryDate.GetLongDate() ) )
                        {
                            // 年式設定処理
                            this._estimateInputAcs.SettingCarInfoRowFromFirstEntryDate( salesRowNo, tDateEdit_FirstEntryDate.GetLongDate() );
                            this._estimateInputAcs.SettingCarModelUIDataFromFirstEntryDate( carInfoRowCurrent.CarRelationGuid, tDateEdit_FirstEntryDate.GetLongDate() );
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "生産年式が設定範囲外です。",
                                -1,
                                MessageBoxButtons.OK );
                            e.NextCtrl = tDateEdit_FirstEntryDate;
                            nextCtrl = null;
                            getNextCtrl = false;
                            this.tDateEdit_FirstEntryDate.SetLongDate( 0 );
                        }
                    }
                }
                # endregion
            }
            if ( this._beforeCarSearchBuffer.ColorNo != string.Empty )
            {
                # region [カラー]
                tEdit_ColorNo.Text = this._beforeCarSearchBuffer.ColorNo;
                if ( this.tEdit_ColorNo.Text.Trim() != string.Empty )
                {
                    string currentColorCode = carInfoRowCurrent.ColorCode;
                    if ( !this._estimateInputAcs.SelectColorInfo( carInfoRowCurrent.CarRelationGuid, this.tEdit_ColorNo.Text.Trim() ) )
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "カラーコードが設定範囲外です。",
                            -1,
                            MessageBoxButtons.OK );
                        this.tEdit_ColorNo.Text = string.Empty;

                        this._estimateInputAcs.SelectColorInfo( carInfoRowCurrent.CarRelationGuid, this.tEdit_ColorNo.Text.Trim() );
                        e.NextCtrl = tEdit_ColorNo;
                        nextCtrl = null;
                        getNextCtrl = false;
                    }
                }
                else
                {
                    this._estimateInputAcs.SelectColorInfo( carInfoRowCurrent.CarRelationGuid, this.tEdit_ColorNo.Text.Trim() );
                }
                # endregion
            }
            if ( this._beforeCarSearchBuffer.TrimNo != string.Empty )
            {
                # region [トリム]
                tEdit_TrimNo.Text = this._beforeCarSearchBuffer.TrimNo;
                if ( this.tEdit_TrimNo.Text.Trim() != string.Empty )
                {
                    string currentTrimCode = carInfoRowCurrent.TrimCode;
                    if ( !this._estimateInputAcs.SelectTrimInfo( carInfoRowCurrent.CarRelationGuid, this.tEdit_TrimNo.Text.Trim() ) )
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "トリムコードが設定範囲外です。",
                            -1,
                            MessageBoxButtons.OK );
                        this.tEdit_TrimNo.Text = string.Empty;

                        this._estimateInputAcs.SelectTrimInfo( carInfoRowCurrent.CarRelationGuid, this.tEdit_TrimNo.Text.Trim() );
                        e.NextCtrl = tEdit_TrimNo;
                        nextCtrl = null;
                        getNextCtrl = false;
                    }
                }
                else
                {
                    this._estimateInputAcs.SelectTrimInfo( carInfoRowCurrent.CarRelationGuid, this.tEdit_TrimNo.Text.Trim() );
                }
                # endregion
            }
            # endregion
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 ADD


            // フォーカス移動項目の自動取得
            if (getNextCtrl)
            {
                if (e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Return:
                        case Keys.Tab:
                            nextCtrl = this.GetNextControl(prevCtrl, EstimateInputAcs.MoveMethod.PrevMove);

                            // ---- DEL 2011/02/14 ------------- >>>>>
                            //if ((prevCtrl != this.tNedit_CustomerCode) && (nextCtrl == this.tNedit_CustomerCode) && (salesSlip.CustomerCode == 0))
                            //{
                            //    nextCtrl = this.tEdit_CustomerName;
                            //}
                            // ---- DEL 2011/02/14 ------------- <<<<<

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
                            nextCtrl = this.GetNextControl(prevCtrl, EstimateInputAcs.MoveMethod.NextMove);
                            break;
                        case Keys.Down:
                            if ((prevCtrl == this.tEdit_FullModel) || (prevCtrl == tEdit_ProduceFrameNo) || (prevCtrl == tEdit_TrimNo))
                            {
                                nextCtrl = this._estimateDetailInput.uGrid_Details;
                            }
                            break;
                    }
                }
            }
            if (nextCtrl != null) e.NextCtrl = nextCtrl;

            // ガイドボタンツール有効無効設定処理
            if ((e.NextCtrl != null) && (e.NextCtrl.TabStop))
            {
                this.SettingGuideButtonToolEnabled(e.NextCtrl);
            }


            if (settingFotter)
            {
                this._estimateDetailInput.SettingFooterEventCall();
            }
        }


        /// <summary>
        /// 管理番号でガイドVisible設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 管理番号でガイドをVisible設定します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/09/08</br>
        /// </remarks>
        private void SettingCarMngNoGuideVisible()
        {
            if (tNedit_CustomerCode.GetInt() != 0)
            {
                switch (this._estimateInputAcs.SalesSlip.CarMngDivCd)
                {
                    case 0: // しない
                        this.uButton_CarMngNoGuide.Enabled = false;
                        break;
                    case 1: // 登録(確認)
                    case 2: // 登録(自動)
                        break;
                    case 3: // 登録無
                        this.uButton_CarMngNoGuide.Enabled = false;
                        break;
                }
            }
        }

        /// <summary>
        /// 車輌検索後のコントロール取得処理
        /// </summary>
        /// <returns></returns>
        private Control GetNextCtrlAfterCarSearch()
        {
            Control retControl = null;

            if ((this._estimateInputConstructionAcs.FocusPositionAfterCarSearchValue == EstimateInputConstructionAcs.FocusPositionAfterCarSearch_FirstEntryDate) &&
                (this.tDateEdit_FirstEntryDate.Visible) && (this.tDateEdit_FirstEntryDate.Enabled))
            {
                retControl = this.tDateEdit_FirstEntryDate;
            }
            else if ((this._estimateInputConstructionAcs.FocusPositionAfterCarSearchValue == EstimateInputConstructionAcs.FocusPositionAfterCarSearch_ProduceFrameNo) &&
                     (this.tEdit_ProduceFrameNo.Visible) && (this.tEdit_ProduceFrameNo.Enabled))
            {
                retControl = this.tEdit_ProduceFrameNo;
            }
            else if ((this._estimateInputConstructionAcs.FocusPositionAfterCarSearchValue == EstimateInputConstructionAcs.FocusPositionAfterCarSearch_Detail) &&
                     (this._estimateDetailInput.Enabled))
            {
                retControl = this._estimateDetailInput.uGrid_Details;
            }
            return retControl;
        }

        /// <summary>
        /// 車輌検索処理
        /// </summary>
        /// <param name="condition"></param>
        private int CarSearch(CarSearchCondition condition)
        {
            //------------------------------------------------------
            // 初期処理
            //------------------------------------------------------
            int retStatus = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 ADD
            this._beforeCarSearchBuffer.ProduceFrameNo = tEdit_ProduceFrameNo.Text.Trim();
            this._beforeCarSearchBuffer.FirstEntryDate = tDateEdit_FirstEntryDate.GetLongDate();
            this._beforeCarSearchBuffer.ColorNo = tEdit_ColorNo.Text.Trim();
            this._beforeCarSearchBuffer.TrimNo = tEdit_TrimNo.Text.Trim();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 ADD

            //------------------------------------------------------
            // 売上行番号取得
            //------------------------------------------------------
            int salesRowNo = this._estimateDetailInput.GetActiveRowSalesRowNo();

            //------------------------------------------------------
            // カーメーカーコード、車種コード、車種呼称コード設定
            //------------------------------------------------------
            int makerCd, modelCd, modelSubCd;
            if (int.TryParse(this.tNedit_MakerCode.Text, out makerCd))
            {
                condition.MakerCode = makerCd;
            }
            if (int.TryParse(this.tNedit_ModelCode.Text, out modelCd))
            {
                condition.ModelCode = modelCd;
            }
            if (int.TryParse(this.tNedit_ModelSubCode.Text, out modelSubCd))
            {
                condition.ModelSubCode = modelSubCd;
            }

            condition.EraNameDispCd1 = this._estimateInputInitDataAcs.GetAllDefSet().EraNameDispCd1;

            //------------------------------------------------------
            // 各種検索処理
            //------------------------------------------------------
            //  CarSearchCondition の検索タイプにより指定
            //------------------------------------------------------
            CarSearchResultReport ret;
            PMKEN01010E dat = new PMKEN01010E();
            ret = this._estimateInputAcs.SearchCar(condition, ref dat);
            if (ret == CarSearchResultReport.retFailed)
            {
                //DialogResult dialogResult = TMsgDisp.Show(
                //    this,
                //    emErrorLevel.ERR_LEVEL_INFO,
                //    this.Name,
                //    "該当する車輌はありません。",
                //    0,
                //    MessageBoxButtons.OK,
                //    MessageBoxDefaultButton.Button1);
                return retStatus = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            else if (ret == CarSearchResultReport.retError)
            {
                //DialogResult dialogResult = TMsgDisp.Show(
                //    this,
                //    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //    this.Name,
                //    "検索中にエラーが発生しました。",
                //    0,
                //    MessageBoxButtons.OK,
                //    MessageBoxDefaultButton.Button1);
                return retStatus = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            if (ret == CarSearchResultReport.retMultipleCarKind)
            {
                //------------------------------------------------------
                // 車種選択画面起動
                //------------------------------------------------------
                if (SelectionCarKind.ShowDialog(dat.CarKindInfo, condition) == DialogResult.OK)
                {
                    ret = this._estimateInputAcs.SearchCar(condition, ref dat);
                }
                else
                {
                    return retStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }
            }
            if (ret == CarSearchResultReport.retMultipleCarModel)
            {
                //------------------------------------------------------
                // 型式選択画面起動
                //------------------------------------------------------
                if (SelectionCarModel.ShowDialog(dat) == DialogResult.OK)
                {
                    ret = this._estimateInputAcs.SearchCar(condition, ref dat);
                }
                else
                {
                    return retStatus = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }
            }

            if ((ret == CarSearchResultReport.retSingleCarModel) || (ret == CarSearchResultReport.retMultipleCarModel))
            {
                //------------------------------------------------------
                // 検索結果キャッシュ
                //------------------------------------------------------
                this._estimateInputAcs.CacheCarInfo(salesRowNo, dat);
                //------------------------------------------------------
                // 車輌情報画面表示処理
                //------------------------------------------------------
                this.SetDisplayCarInfo(salesRowNo, condition.Type);

                return retStatus = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            return retStatus;
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
            if (firstControl != null)
                firstControl.Focus();
            else
                tNedit_ModelDesignationNo.Focus();

            // ガイドボタンツール有効無効設定処理
            this.SettingGuideButtonToolEnabled(this.ActiveControl);

            // フッター情報設定
            this._estimateDetailInput.SettingFooterEventCall();

            this._prevControl = this.ActiveControl;
        }

        /// <summary>
        /// 拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            bool reCalcPrice = false;
            bool clearRateInfo = false;
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;

            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

                if (salesSlip.ResultsAddUpSecCd.Trim() != secInfoSet.SectionCode.Trim())
                {
                    if (this._estimateInputAcs.ExistEstimateDetailCanGoodsPriceReSettingData())
                    {
                        string msg = "拠点が変更されました。" + "\r\n" + "\r\n" + "商品価格を再取得しますか？";
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
                            reCalcPrice = true;
                        }
                        else
                        {
                            clearRateInfo = true;
                        }
                    }
                    salesSlip.ResultsAddUpSecCd = secInfoSet.SectionCode.Trim();
                    salesSlip.ResultsAddUpSecNm = secInfoSet.SectionGuideNm;
                }

                // 売上データクラス→画面格納処理
                this.SetDisplay(salesSlip);

                // 売上データキャッシュ処理
                this._estimateInputAcs.Cache(salesSlip);

                this._estimateDetailInput.SettingFooterEventCall();

                // 次の項目へフォーカス移動
                Control nextCtrl = this.GetNextControl(this.tEdit_SectionCode, EstimateInputAcs.MoveMethod.NextMove);
                if (nextCtrl != null)
                {
                    nextCtrl.Focus();
                    this._prevControl = nextCtrl;
                    this.SettingGuideButtonToolEnabled(nextCtrl);
                }
            }

            if (reCalcPrice)
            {
                this.PriceReSetting();
            }

            // 掛率情報のクリア
            if (clearRateInfo)
            {
                this._estimateInputAcs.AllTableClearRateInfo();
            }

        }

        /// <summary>
        /// 部門ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_SubSectionGuide_Click(object sender, EventArgs e)
        {
            SubSectionAcs subSectionAcs = new SubSectionAcs();
            SubSection subSection;

            int status = subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

                if (salesSlip.SubSectionCode != subSection.SubSectionCode)
                {
                    salesSlip.SubSectionCode = subSection.SubSectionCode;
                    salesSlip.SubSectionName = subSection.SubSectionName;
                }

                // 売上データクラス→画面格納処理
                this.SetDisplay(salesSlip);

                // 売上データキャッシュ処理
                this._estimateInputAcs.Cache(salesSlip);

                this._estimateDetailInput.SettingFooterEventCall();

                // 次の項目へフォーカス移動
                Control nextCtrl = this.GetNextControl(this.tNedit_SubSectionCode, EstimateInputAcs.MoveMethod.NextMove);
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
        private void uButton_SalesEmployeeGuide_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;
            int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

                if (salesSlip.SalesEmployeeCd != employee.EmployeeCode.Trim())
                {
                    salesSlip.SalesEmployeeCd = employee.EmployeeCode.Trim();
                    salesSlip.SalesEmployeeNm = employee.Name.Trim();
                    if (salesSlip.SalesEmployeeNm.Length > 16)
                    {
                        salesSlip.SalesEmployeeNm = salesSlip.SalesEmployeeNm.Substring(0, 16);
                    }

                    this._estimateInputAcs.SalesEmployeeBelongInfoSetting(ref salesSlip);
                }

                // 売上データクラス→画面格納処理
                this.SetDisplay(salesSlip);

                // 売上データキャッシュ処理
                this._estimateInputAcs.Cache(salesSlip);

                this._estimateDetailInput.SettingFooterEventCall();

                // 次の項目へフォーカス移動
                Control nextCtrl = this.GetNextControl(this.tEdit_SalesEmployeeCd, EstimateInputAcs.MoveMethod.NextMove);
                if (nextCtrl != null)
                {
                    nextCtrl.Focus();
                    this._prevControl = nextCtrl;
                    this.SettingGuideButtonToolEnabled(nextCtrl);
                }
            }
        }

        /// <summary>
        /// 得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            PMKHN04001UA customerSearchForm = new PMKHN04001UA();

            customerSearchForm = new PMKHN04001UA(PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04001UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.MngSectionCode = this._estimateInputInitDataAcs.OwnSectionCode;
            customerSearchForm.MngSectionName = this._estimateInputInitDataAcs.OwnSectionName;
            customerSearchForm.AutoSearch = true;
            if (customerSearchForm.ShowDialog(this) == DialogResult.OK)
            {
                // --- ADD 2009/09/08 ---------->>>>>
                CustomerInfo mycustomerInfo;
                int code = this.tNedit_CustomerCode.GetInt();
                int carMngDiv = 0;
                if (code > 0)
                {
                    int stu = this._customerInfoAcs.ReadDBData(this._enterpriseCode, code, true, out mycustomerInfo);

                    if (mycustomerInfo != null)
                    {
                        carMngDiv = mycustomerInfo.CarMngDivCd;
                    }
                }
                int salesRowNo = this._estimateDetailInput.GetActiveRowSalesRowNo();
                // 車輌管理オプション有りの場合
                if (this._estimateInputInitDataAcs.Opt_CarMng)
                {
                    //新規登録時の場合
                    if (!_canDeleteSlip)
                    {
                        //得意先を変更した場合は、管理番号の値をクリアする
                        this.tEdit_CarMngCode.Text = string.Empty;
                        this._estimateInputAcs.SettingCarInfoRowFromCarMngCode(salesRowNo, string.Empty);
                    }
                    else
                    {
                        // 修正呼出しの場合
                        if (carMngDiv == 0)
                        {
                            //得意先を変更した場合は、管理番号の値をクリアする
                            this.tEdit_CarMngCode.Text = string.Empty;
                            this._estimateInputAcs.SettingCarInfoRowFromCarMngCode(salesRowNo, string.Empty);
                        }
                    }
                }
                // --- ADD 2009/09/08 ----------<<<<<

                // 次の項目へフォーカス移動
                Control prevCtrl = (this.tEdit_CustomerName.Enabled) ? this.tEdit_CustomerName : tNedit_CustomerCode;
                Control nextCtrl = this.GetNextControl(prevCtrl, EstimateInputAcs.MoveMethod.NextMove);
                if (nextCtrl != null)
                {
                    nextCtrl.Focus();
                    this._prevControl = nextCtrl;
                    this.SettingGuideButtonToolEnabled(nextCtrl);

                }
            }
        }

        /// <summary>
        /// 車種ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_ModelFullGuide_Click(object sender, EventArgs e)
        {
            ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
            ModelNameU modelNameU;
            int makerCode = this.tNedit_MakerCode.GetInt();
            // -------UPD 2011/02/14------->>>>>
            //int status = modelNameUAcs.ExecuteGuid(makerCode, this._enterpriseCode, out modelNameU);
            int modelCode = this.tNedit_ModelCode.GetInt();
            int modelSubCode = this.tNedit_ModelSubCode.GetInt();
            int status = modelNameUAcs.ExecuteGuid2(makerCode, modelCode, modelSubCode,
                this._enterpriseCode, out modelNameU);
            
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int salesRowNo = this._estimateDetailInput.GetActiveRowSalesRowNo();
                if (modelNameU != null 
                    && (makerCode != modelNameU.MakerCode 
                        || modelCode != modelNameU.ModelCode 
                        || modelSubCode != modelNameU.ModelSubCode))
                {
                    this._estimateInputAcs.ClearCarInfoForModelCode(salesRowNo);
                    this.ClearDisplayCarInfoForModelCode(); 
                    this.uExpandableGroupBox_CarInfo.Enabled = false; 
                    this.uExpandableGroupBox_CarInfo.Expanded = false; 
                }
                // -------UPD 2011/02/14------->>>>>
                this._estimateInputAcs.SettingCarInfoRowFromModelInfo(salesRowNo, modelNameU);
                this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);
                this.SetDisplayHeaderFooterInfo(this._estimateInputAcs.SalesSlip);
                
                // 次の項目へフォーカス移動
                Control nextCtrl = this.GetNextControl(this.tEdit_ModelFullName, EstimateInputAcs.MoveMethod.NextMove);
                if (nextCtrl != null)
                {
                    nextCtrl.Focus();
                    this._prevControl = nextCtrl;
                    this.SettingGuideButtonToolEnabled(nextCtrl);

                }
            }
        }

        /// <summary>
        /// クローズタイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_Close_Tick(object sender, EventArgs e)
        {
            this.timer_Close.Enabled = false;
        }

        #region ●車輌情報
        /// <summary>
        /// 車輌情報設定処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="salesRowNo"></param>
        /// <br>Update Note: 2011/02/14  徐嘉</br>
        /// <br>             修正呼出時の諸元情報表示の制御変更</br>
        private void CarInfoFormSetting(object sender, int salesRowNo)
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this._estimateInputAcs.GetCarInfoRow(salesRowNo, EstimateInputAcs.GetCarInfoMode.CarInfoChangeMode);
            if (carInfoRow != null)
            {
                this.SetDisplayCarInfo(carInfoRow, CarSearchType.csNone);

                double acceptAnOrderNo = (double)this.tNedit_AcceptAnOrderNo.GetValue();
                if (acceptAnOrderNo != 0)
                {
                    // --- UPD 2011/02/14 ---------->>>>>
                    //this.panel_CarInfo.Enabled = false;
                    this.SettingPanelCarInfo(false);
                    // --- UPD 2011/02/14 ----------<<<<<
                }
                else
                {   // --- UPD 2011/02/14 ---------->>>>>
                    //this.panel_CarInfo.Enabled = true;
                    this.SettingPanelCarInfo(true);
                    // --- UPD 2011/02/14 ----------<<<<<
                }

                // カラー・トリム・装備情報
                if (((this._carOtherInfoInput.ColorCdInfoDataTable != null) &&
                      (this._carOtherInfoInput.ColorCdInfoDataTable.Count != 0)) ||
                    ((this._carOtherInfoInput.TrimCdInfoDataTable != null) &&
                      (this._carOtherInfoInput.TrimCdInfoDataTable.Count != 0)) ||
                    ((this._carOtherInfoInput.CEqpDefDspInfoDataTable != null) &&
                      (this._carOtherInfoInput.CEqpDefDspInfoDataTable.Count != 0)))
                {
                    // --- UPD 2011/02/14 ------- >>>>>>>
                    this.uExpandableGroupBox_CarInfo.Enabled = true;

                    if (this.tEdit_FullModel.Enabled == false)
                    {
                        this._carOtherInfoInput.uGrid_ColorInfoEnableSet(false);
                        this._carOtherInfoInput.uGrid_EquipInfoEnableSet(false);
                        this._carOtherInfoInput.uGrid_TrimInfoEnableSet(false);
                    }
                    else
                    {
                        this._carOtherInfoInput.uGrid_ColorInfoEnableSet(true);
                        this._carOtherInfoInput.uGrid_EquipInfoEnableSet(true);
                        this._carOtherInfoInput.uGrid_TrimInfoEnableSet(true);
                    }
                    // --- UPD 2011/02/14 ------- <<<<<<<
                }
                else
                {
                    this.uExpandableGroupBox_CarInfo.Enabled = false;
                    this.uExpandableGroupBox_CarInfo.Expanded = false;
                }
            }
        }
        #endregion

        #region ●カラー情報
        /// <summary>
        /// カラー情報設定処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="colorCode"></param>
        private void SettingColorInfo(object sender, string colorCode)
        {
            this.tEdit_ColorNo.Text = colorCode;
        }
        #endregion

        #region ●トリム情報
        /// <summary>
        /// トリム情報設定処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="trimCode"></param>
        private void SettingTrimInfo(object sender, string trimCode)
        {
            this.tEdit_TrimNo.Text = trimCode;
        }
        #endregion

        #region 諸元情報グリッド関係

        /// <summary>
        /// グリッド初期設定イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid_CarSpec_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.InitialSettingGridCol();
        }

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid_CarSpec.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;

                if ((col.Key == this._carSpecDataTable.AddiCarSpec1Column.ColumnName) ||
                    (col.Key == this._carSpecDataTable.AddiCarSpec2Column.ColumnName) ||
                    (col.Key == this._carSpecDataTable.AddiCarSpec3Column.ColumnName) ||
                    (col.Key == this._carSpecDataTable.AddiCarSpec4Column.ColumnName) ||
                    (col.Key == this._carSpecDataTable.AddiCarSpec5Column.ColumnName) ||
                    (col.Key == this._carSpecDataTable.AddiCarSpec6Column.ColumnName) ||
                    (col.Key == this._carSpecDataTable.BodyNameColumn.ColumnName) ||
                    (col.Key == this._carSpecDataTable.DoorCountColumn.ColumnName) ||
                    (col.Key == this._carSpecDataTable.EDivNmColumn.ColumnName) ||
                    (col.Key == this._carSpecDataTable.EngineDisplaceNmColumn.ColumnName) ||
                    (col.Key == this._carSpecDataTable.EngineModelNmColumn.ColumnName) ||
                    (col.Key == this._carSpecDataTable.ModelGradeNmColumn.ColumnName) ||
                    (col.Key == this._carSpecDataTable.ShiftNmColumn.ColumnName) ||
                    (col.Key == this._carSpecDataTable.TransmissionNmColumn.ColumnName) ||
                    (col.Key == this._carSpecDataTable.WheelDriveMethodNmColumn.ColumnName))
                {
                    col.Hidden = false;
                }
            }

            ////---------------------------------------------------------------------
            //// 入力許可設定
            ////---------------------------------------------------------------------
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.ModelGradeNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.BodyNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.DoorCountColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EngineModelNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EngineDisplaceNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EDivNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.TransmissionNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.ShiftNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.WheelDriveMethodNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec1Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec2Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec3Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec4Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec5Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            ////---------------------------------------------------------------------
            //// フォーマット設定
            ////---------------------------------------------------------------------
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.DoorCountColumn.ColumnName].Format = "#0;'';''";

        }

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        private void SettingCarSpecGridCol(EstimateInputDataSet.CarInfoRow carInfoRow)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid_CarSpec.DisplayLayout.Bands[0];
            if (editBand == null) return;
            // --- UPD 2011/02/14 ---------->>>>>
            ////this.ultraGrid_CarSpec.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;

            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec1Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpec1)) ? true : false;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec2Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpec2)) ? true : false;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec3Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpec3)) ? true : false;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec4Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpec4)) ? true : false;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec5Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpec5)) ? true : false;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec6Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpec6)) ? true : false;

            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.ModelGradeNmColumn.ColumnName].MaxLength = this._carSpecDataTable.ModelGradeNmColumn.MaxLength;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.BodyNameColumn.ColumnName].MaxLength = this._carSpecDataTable.BodyNameColumn.MaxLength;
            ////this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.DoorCountColumn.ColumnName].MaxLength          = this._carSpecDataTable.DoorCountColumn.MaxLength;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EngineModelNmColumn.ColumnName].MaxLength = this._carSpecDataTable.EngineModelNmColumn.MaxLength;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EngineDisplaceNmColumn.ColumnName].MaxLength = this._carSpecDataTable.EngineDisplaceNmColumn.MaxLength;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EDivNmColumn.ColumnName].MaxLength = this._carSpecDataTable.EDivNmColumn.MaxLength;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.TransmissionNmColumn.ColumnName].MaxLength = this._carSpecDataTable.TransmissionNmColumn.MaxLength;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.WheelDriveMethodNmColumn.ColumnName].MaxLength = this._carSpecDataTable.WheelDriveMethodNmColumn.MaxLength;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.ShiftNmColumn.ColumnName].MaxLength = this._carSpecDataTable.ShiftNmColumn.MaxLength;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec1Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec1Column.MaxLength;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec2Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec2Column.MaxLength;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec3Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec3Column.MaxLength;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec4Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec4Column.MaxLength;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec5Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec5Column.MaxLength;
            //this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec6Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec6Column.MaxLength;

            //this._carSpecDataTable.AddiCarSpec1Column.Caption = carInfoRow.AddiCarSpecTitle1;
            //this._carSpecDataTable.AddiCarSpec2Column.Caption = carInfoRow.AddiCarSpecTitle2;
            //this._carSpecDataTable.AddiCarSpec3Column.Caption = carInfoRow.AddiCarSpecTitle3;
            //this._carSpecDataTable.AddiCarSpec4Column.Caption = carInfoRow.AddiCarSpecTitle4;
            //this._carSpecDataTable.AddiCarSpec5Column.Caption = carInfoRow.AddiCarSpecTitle5;
            //this._carSpecDataTable.AddiCarSpec6Column.Caption = carInfoRow.AddiCarSpecTitle6;
            if (carInfoRow != null)
            {
                this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec1Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpecTitle1)) ? true : false;
                this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec2Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpecTitle2)) ? true : false;
                this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec3Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpecTitle3)) ? true : false;
                this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec4Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpecTitle4)) ? true : false;
                this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec5Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpecTitle5)) ? true : false;
                this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec6Column.ColumnName].Hidden = (string.IsNullOrEmpty(carInfoRow.AddiCarSpecTitle6)) ? true : false;

                this._carSpecDataTable.AddiCarSpec1Column.Caption = carInfoRow.AddiCarSpecTitle1;
                this._carSpecDataTable.AddiCarSpec2Column.Caption = carInfoRow.AddiCarSpecTitle2;
                this._carSpecDataTable.AddiCarSpec3Column.Caption = carInfoRow.AddiCarSpecTitle3;
                this._carSpecDataTable.AddiCarSpec4Column.Caption = carInfoRow.AddiCarSpecTitle4;
                this._carSpecDataTable.AddiCarSpec5Column.Caption = carInfoRow.AddiCarSpecTitle5;
                this._carSpecDataTable.AddiCarSpec6Column.Caption = carInfoRow.AddiCarSpecTitle6;
            }
            else
            {
                this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec1Column.ColumnName].Hidden = false;
                this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec2Column.ColumnName].Hidden = false;
                this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec3Column.ColumnName].Hidden = false;
                this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec4Column.ColumnName].Hidden = false;
                this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec5Column.ColumnName].Hidden = false;
                this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec6Column.ColumnName].Hidden = false;

                this._carSpecDataTable.AddiCarSpec1Column.Caption = string.Empty;
                this._carSpecDataTable.AddiCarSpec2Column.Caption = string.Empty;
                this._carSpecDataTable.AddiCarSpec3Column.Caption = string.Empty;
                this._carSpecDataTable.AddiCarSpec4Column.Caption = string.Empty;
                this._carSpecDataTable.AddiCarSpec5Column.Caption = string.Empty;
                this._carSpecDataTable.AddiCarSpec6Column.Caption = string.Empty;
            }

            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.ModelGradeNmColumn.ColumnName].MaxLength = this._carSpecDataTable.ModelGradeNmColumn.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.BodyNameColumn.ColumnName].MaxLength = this._carSpecDataTable.BodyNameColumn.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EngineModelNmColumn.ColumnName].MaxLength = this._carSpecDataTable.EngineModelNmColumn.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EngineDisplaceNmColumn.ColumnName].MaxLength = this._carSpecDataTable.EngineDisplaceNmColumn.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.EDivNmColumn.ColumnName].MaxLength = this._carSpecDataTable.EDivNmColumn.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.TransmissionNmColumn.ColumnName].MaxLength = this._carSpecDataTable.TransmissionNmColumn.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.WheelDriveMethodNmColumn.ColumnName].MaxLength = this._carSpecDataTable.WheelDriveMethodNmColumn.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.ShiftNmColumn.ColumnName].MaxLength = this._carSpecDataTable.ShiftNmColumn.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec1Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec1Column.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec2Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec2Column.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec3Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec3Column.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec4Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec4Column.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec5Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec5Column.MaxLength;
            this.ultraGrid_CarSpec.DisplayLayout.Bands[0].Columns[this._carSpecDataTable.AddiCarSpec6Column.ColumnName].MaxLength = this._carSpecDataTable.AddiCarSpec6Column.MaxLength;
            // --- UPD 2011/02/14 ----------<<<<<
        }

        /// <summary>
        /// ultraGrid_CarSpec_KeyDownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid_CarSpec_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                this.ultraGrid_CarSpec.BeginUpdate();

                //-----------------------------------------------------------------------------
                // ActivCell判定
                //-----------------------------------------------------------------------------
                if (this.ultraGrid_CarSpec.ActiveCell != null)
                {
                    Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.ultraGrid_CarSpec.ActiveCell;

                    switch (e.KeyCode)
                    {
                        //-----------------------------------------------------------------------------
                        // UP
                        //-----------------------------------------------------------------------------
                        case Keys.Up:
                            this.tEdit_FullModel.Focus(); // 型式へ移動
                            e.Handled = true;
                            break;
                        //-----------------------------------------------------------------------------
                        // DOWN
                        //-----------------------------------------------------------------------------
                        case Keys.Down:
                            this._estimateDetailInput.uGrid_Details.Focus(); // 売上明細へ移動
                            e.Handled = true;
                            break;
                    }
                }
            }
            finally
            {
                this.ultraGrid_CarSpec.EndUpdate();
            }
        }


        #endregion

        /// <summary>
        /// tNedit_ModelDesignationNo_ValueChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tNedit_ModelDesignationNo_ValueChanged(object sender, EventArgs e)
        {
            string modelDesignationNo = this.tNedit_ModelDesignationNo.Text;


            if (this.tNedit_ModelDesignationNo.Focused)
            {
                if (this.tNedit_ModelDesignationNo.ExtEdit.Column <= modelDesignationNo.Length)
                {
                    this.tNedit_CategoryNo.Focus();
                }
            }

            //if (this.tNedit_ModelDesignationNo.ExtEdit.Column <= modelDesignationNo.Length)
            //{
            //    if (this.ActiveControl == this.tNedit_ModelDesignationNo)
            //    {
            //        this.tNedit_CategoryNo.Focus();
            //    }
            //}
        }

        /// <summary>
        /// uButton_ChangeSearchCarMode Clickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_ChangeSearchCarMode_Click(object sender, EventArgs e)
        {
            SalesSlip salesSlip = this._estimateInputAcs.SalesSlip;

            this.ChangeCarSearchMode(ref salesSlip, true);
        }

        /// <summary>
        /// 売上伝票検索ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SalesSlipGuide_Click(object sender, EventArgs e)
        {
            MAHNB04110UA salesSlipGuide = new MAHNB04110UA();
            salesSlipGuide.TComboEditor_SalesFormalCode = false;
            salesSlipGuide.AutoSearch = true;
            salesSlipGuide.SectionCode = this._estimateInputAcs.SalesSlip.ResultsAddUpSecCd;
            salesSlipGuide.SectionName = this._estimateInputAcs.SalesSlip.ResultsAddUpSecNm;
            salesSlipGuide.AcptAnOdrStatus = 30;
            SalesSlipSearchResult searchResult;
            DialogResult result = salesSlipGuide.ShowGuide(this, _enterpriseCode, 10, 3, out searchResult);

            if (result == DialogResult.OK)
            {
                if (searchResult != null)
                {
                    DialogResult dialogResult = DialogResult.Yes;

                    if (this._estimateInputAcs.IsDataChanged)
                    {
                        dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "入力中の情報がクリアされます。" + "\r\n" + "\r\n" +
                            "よろしいですか？",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);
                    }

                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Clear(false, false);

                        // データリード処理
                        this.Cursor = Cursors.WaitCursor;
                        int status = this._estimateInputAcs.ReadDBData(searchResult.EnterpriseCode, searchResult.AcptAnOdrStatus, searchResult.SalesSlipNum);
                        this.Cursor = Cursors.Default;

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            SalesSlip salesSlip = this._estimateInputAcs.SalesSlip.Clone();

                            // 売上データ入力モード設定処理
                            this._estimateInputAcs.SettingInputMode(ref salesSlip);

                            // --- ADD 2011/11/12---------->>>>>
                            // BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑの在庫確認で作成された見積伝票を修正呼出しした場合
                            if (this.isStockSales(salesSlip))
                            {
                                // 入力モード設定処理
                                // 参照モードで画面に表示する
                                salesSlip.InputMode = EstimateInputAcs.ctINPUTMODE_Estimate_ReadOnly;
                            }
                            // --- ADD 2011/11/12----------<<<<<

                            // 売上データクラス→画面格納処理
                            this.SetDisplay(salesSlip);

                            // 売上データキャッシュ処理
                            this._estimateInputAcs.Cache(salesSlip);

                            // 明細グリッド設定処理
                            this._estimateDetailInput.SettingGrid();

                            // ツールバーボタン有効無効設定処理
                            this.SettingToolBarButtonEnabled();

                            //--------- ADD 2013/05/07 xujx FOR Redmine#34803 --------------->>>>>
                            bool isGridAllowEdit = false;
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow ultraGridRow in this._estimateDetailInput.uGrid_Details.Rows)
                            {
                                foreach (Infragistics.Win.UltraWinGrid.UltraGridCell ultraGridCell in ultraGridRow.Cells)
                                {
                                    if (ultraGridCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                                    {
                                        isGridAllowEdit = true;
                                        break;
                                    }
                                }
                                if (isGridAllowEdit == true) break;
                            }
                            //--------- ADD 2013/05/07 xujx FOR Redmine#34803 ---------------<<<<<

                            if (this._estimateDetailInput.Enabled)
                            {
                                //this._estimateDetailInput.uGrid_Details.Focus(); //DEL 2013/05/07 xujx FOR Redmine#34803
                                //--------- ADD 2013/05/07 xujx FOR Redmine#34803 --------------->>>>>
                                if (isGridAllowEdit == true)
                                {
                                    this._estimateDetailInput.uGrid_Details.Focus();
                                }
                                else
                                {
                                    this._estimateDetailInput.uGrid_Details.Rows[0].Activated = true;
                                }
                                //--------- ADD 2013/05/07 xujx FOR Redmine#34803 ---------------<<<<<
                                this._prevControl = this._estimateDetailInput.uGrid_Details;
                                this.SettingGuideButtonToolEnabled(this._prevControl);

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
                                "データの取得に失敗しました。",
                                status,
                                MessageBoxButtons.OK);

                            return;
                        }

                    }
                }
            }

        }
        # endregion

        /// <summary>
        /// 諸元グリッド　Leaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid_CarSpec_Leave(object sender, EventArgs e)
        {
            if (this.ultraGrid_CarSpec.ActiveRow != null)
            {
                this.ultraGrid_CarSpec.ActiveRow.Selected = false;
                this.ultraGrid_CarSpec.ActiveRow = null;
            }
            if (this.ultraGrid_CarSpec.ActiveCell != null)
            {
                this.ultraGrid_CarSpec.ActiveCell.Selected = false;
                this.ultraGrid_CarSpec.ActiveCell = null;
            }
        }

        /// <summary>
        /// 管理番号ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 管理番号ガイドボタンをクリックします。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/09/08</br>
        /// </remarks>
        private void uButton_CarMngNoGuide_Click(object sender, EventArgs e)
        {
            int flag = 0;

            CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
            CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();

            paramInfo.EnterpriseCode = this._enterpriseCode;

            // ガイドイベントフラグ
            paramInfo.IsGuideClick = true;

            if (tNedit_CustomerCode.GetInt() != 0)
            {
                switch (this._estimateInputAcs.SalesSlip.CarMngDivCd)
                {
                    case 0: // しない
                        break;
                    case 1: // 登録(確認)
                    case 2: // 登録(自動)
                        // 「新規登録」行表示なし
                        paramInfo.IsDispNewRow = false;
                        // 得意先表示なし
                        paramInfo.IsDispCustomerInfo = false;
                        //得意先コード絞り込み有り
                        paramInfo.IsCheckCustomerCode = true;
                        //得意先コード
                        paramInfo.CustomerCode = this._estimateInputAcs.SalesSlip.CustomerCode;
                        // 管理番号絞り込み無し
                        paramInfo.IsCheckCarMngCode = false;
                        // 車輌管理区分チェック有り
                        paramInfo.IsCheckCarMngDivCd = true;
                        break;
                    case 3: // 登録無
                        break;
                }
            }
            else
            {
                // 「新規登録」行表示なし
                paramInfo.IsDispNewRow = false;
                // 得意先表示有り
                paramInfo.IsDispCustomerInfo = true;
                //得意先コード絞り込みなし
                paramInfo.IsCheckCustomerCode = false;
                // 管理番号絞り込み無し
                paramInfo.IsCheckCarMngCode = false;
                // 車輌管理区分チェック有り
                paramInfo.IsCheckCarMngDivCd = true;
            }

            int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);

            flag = AfterCarMngNoGuideReturn(status, selectedInfo, 0);

        }

        /// <summary>
        ///自動起動で管理番号ガイド表示設定の処理
        /// </summary>
        /// <param name="carMngCode">管理コード</param>
        /// <param name="inputflag">管理番号　0:異なる　1:同じ</param>
        /// <returns>フォーカス　0:次項目　1:型式</returns>
        /// <remarks>
        /// <br>Note       : 自動起動で管理番号ガイド表示を設定処理します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/09/08</br>
        /// </remarks>
        private int SettingCarMngNoGuide(string carMngCode, int inputflag)
        {
            int flag = 0;
            if (!string.IsNullOrEmpty(carMngCode))
            {
                CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
                CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();

                paramInfo.EnterpriseCode = this._enterpriseCode;
                // ガイドイベントフラグ
                paramInfo.IsGuideClick = false;
                // 「新規登録」行表示有り
                paramInfo.IsDispNewRow = true;
                // 管理番号絞り込み前方一致
                paramInfo.IsCheckCarMngCode = true;
                // 管理コード
                paramInfo.CarMngCode = carMngCode;
                // 管理コードの前方
                paramInfo.CheckCarMngCodeType = 1;
                // 車輌管理区分チェック有り
                paramInfo.IsCheckCarMngDivCd = true;

                if (tNedit_CustomerCode.GetInt() != 0)
                {
                    switch (this._estimateInputAcs.SalesSlip.CarMngDivCd)
                    {
                        case 0: // しない
                            break;
                        case 1: // 登録(確認)
                        case 2: // 登録(自動)
                            // 得意先表示なし
                            paramInfo.IsDispCustomerInfo = false;
                            //得意先コード絞り込み有り
                            paramInfo.IsCheckCustomerCode = true;
                            //得意先コード
                            paramInfo.CustomerCode = this._estimateInputAcs.SalesSlip.CustomerCode;
                            break;
                        case 3: // 登録無
                            //得意先コード絞り込み有り
                            paramInfo.IsCheckCustomerCode = true;
                            //得意先コード
                            paramInfo.CustomerCode = this._estimateInputAcs.SalesSlip.CustomerCode;
                            break;
                    }
                }
                else
                {
                    // 得意先表示有り
                    paramInfo.IsDispCustomerInfo = true;
                    //得意先コード絞り込み無し
                    paramInfo.IsCheckCustomerCode = false;
                }

                if (this._estimateInputAcs.SalesSlip.CustomerCode == 0)
                {
                    int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);

                    flag = AfterCarMngNoGuideReturn(status, selectedInfo, inputflag);
                }
                else
                {
                    //車輌管理区分しない
                    if (this._estimateInputAcs.SalesSlip.CarMngDivCd != 0)
                    {
                        int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);

                        flag = AfterCarMngNoGuideReturn(status, selectedInfo, inputflag);
                    }
                }
            }

            return flag;
        }

        /// <summary>
        ///管理番号ガイド表示後の処理
        /// </summary>
        /// <param name="status">対象オブジェクト</param>
        /// <param name="selectedInfo">イベントパラメータクラス</param>
        /// <param name="inputflag">管理番号　0:異なる　1:同じ</param>
        /// <returns>フォーカス　0:次項目　1:型式</returns>
        /// <remarks>
        /// <br>Note       : 管理番号ガイド表示後を処理します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/09/08</br>
        /// </remarks>
        private int AfterCarMngNoGuideReturn(int status, CarMangInputExtraInfo selectedInfo, int inputflag)
        {
            int flag = 0;

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                //ガイド表示後のフォーカス制御
                if ("新規登録".Equals(selectedInfo.CarMngCode))
                {
                    this.tNedit_ModelDesignationNo.Focus();

                    flag = 0;
                    inputflag = 0;
                }
                else
                {
                    //得意先コード
                    tNedit_CustomerCode.SetInt(selectedInfo.CustomerCode);

                    ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.tNedit_CustomerCode, this.tNedit_CustomerCode);
                    this.tArrowKeyControl1_ChangeFocus(this, changeFocusEventArgs);

                    // 型式指定番号
                    tNedit_ModelDesignationNo.SetInt(selectedInfo.ModelDesignationNo);
                    // 類別番号
                    tNedit_CategoryNo.SetInt(selectedInfo.CategoryNo);

                    SalesSlipHeaderCopyData salesSlipHeaderCopyData = this._estimateInputAcs.CacheCarInfo(selectedInfo);

                    // 車輌検索
                    CopySlipHeaderCarSearch(salesSlipHeaderCopyData);

                    //新規登録以外が選択された場合
                    // ---UPD 2009/10/16 ----->>>>>
                    //this.tEdit_FullModel.Focus();
                    if (selectedInfo.FullModelFixedNoAry != null 
                        && selectedInfo.FullModelFixedNoAry.Length > 0)
                    {
                        //「フル型式固定番号配列」セッありの場合、ユーザー設定の「入力制御」の「車輌確定後のフォーカス位置」へ移動する。
                        flag = 1;
                        if (this.GetNextCtrlAfterCarSearch() != null) this.GetNextCtrlAfterCarSearch().Focus();
                    }
                    else
                    {
                        flag = 0;
                        inputflag = 1;
                        this.tNedit_ModelDesignationNo.Focus();
                    }
                    // flag = 1;
                    // ---UPD 2009/10/16 -----<<<<<
                    
                    
                }

            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN && (string.IsNullOrEmpty(selectedInfo.CarMngCode)))
            {
                flag = 0;
            }
            else
            {
                //新規登録
                flag = 2;
            }

            //車輌情報をクリア処理
            if (flag == 0 && inputflag == 0)
            {
                string tempCarMngCode = this.tEdit_CarMngCode.Text;
                this._estimateInputAcs.ClearCarInfo(tempCarMngCode);

                // 車両情報画面表示クリア処理
                this.ClearDisplayCarInfo();
            }

            return flag;
        }


        /// <summary>
        /// 車両検索処理
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        private int CopySlipHeaderCarSearch(SalesSlipHeaderCopyData salesSlipHeaderCopyData)
        {
            //------------------------------------------------------
            // 初期処理
            //------------------------------------------------------
            int retStatus = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            //------------------------------------------------------
            // 売上行番号取得
            //------------------------------------------------------
            int salesRowNo = this._estimateDetailInput.GetActiveRowSalesRowNo();

            //------------------------------------------------------
            // 各種検索処理
            //------------------------------------------------------
            //  CarSearchCondition の検索タイプにより指定
            //------------------------------------------------------
            CarSearchResultReport ret;
            PMKEN01010E dat = new PMKEN01010E();
            int[] fullModelFixedNo = salesSlipHeaderCopyData.FullModelFixedNoAry;
            // --- ADD m.suzuki 2010/05/21 ---------->>>>>
            string[] freeSrchMdlFxdNo = salesSlipHeaderCopyData.FreeSrchMdlFxdNoAry;
            // --- ADD m.suzuki 2010/05/21 ----------<<<<<

            // --- UPD m.suzuki 2010/05/21 ---------->>>>>
            //if (fullModelFixedNo != null && fullModelFixedNo.Length > 0)
            if ((fullModelFixedNo != null && fullModelFixedNo.Length > 0) ||
                 (freeSrchMdlFxdNo != null && freeSrchMdlFxdNo.Length > 0))
            // --- UPD m.suzuki 2010/05/21 ----------<<<<<
            {
                // --- ADD kuangf 2013/07/18 ---------->>>>>
                CarSearchCondition carSearchCond = new CarSearchCondition();
                carSearchCond.CarModel.FullModel = salesSlipHeaderCopyData.FullModel;
                carSearchCond.MakerCode = salesSlipHeaderCopyData.MakerCode;
                carSearchCond.ModelCode = salesSlipHeaderCopyData.ModelCode;
                carSearchCond.ModelSubCode = salesSlipHeaderCopyData.ModelSubCode;
                carSearchCond.ModelDesignationNo = tNedit_ModelDesignationNo.GetInt();
                carSearchCond.CategoryNo = tNedit_CategoryNo.GetInt();
                // --- ADD kuangf 2013/07/18 ----------<<<<<

                // --- UPD m.suzuki 2010/05/21 ---------->>>>>
                //ret = this._estimateInputAcs.SearchCar(fullModelFixedNo, tNedit_ModelDesignationNo.GetInt(), tNedit_CategoryNo.GetInt(), ref dat);
                // --- UPD kuangf 2013/07/18 ---------->>>>>
                //ret = this._estimateInputAcs.SearchCar(fullModelFixedNo, freeSrchMdlFxdNo, tNedit_ModelDesignationNo.GetInt(), tNedit_CategoryNo.GetInt(), ref dat);
                ret = this._estimateInputAcs.SearchCar(fullModelFixedNo, freeSrchMdlFxdNo, carSearchCond, ref dat);
                // --- UPD kuangf 2013/07/18 ----------<<<<<
                // --- UPD m.suzuki 2010/05/21 ----------<<<<<

                // 検索結果キャッシュ
                this._estimateInputAcs.CacheCarInfoForSlipHeaderCopy(salesRowNo, dat, salesSlipHeaderCopyData);
                // 検索済みにする
                this._estimateInputAcs.SearchCarDiv = false;

                // 車両情報画面表示処理
                this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);
            }
            else
            {
                // ---ADD 2009/10/16 ------>>>>>
                // 検索結果キャッシュ
                this._estimateInputAcs.CacheCarInfoForSlipHeaderCopy(salesRowNo, dat, salesSlipHeaderCopyData);

                // 車両情報画面表示処理
                this.SetDisplayCarInfo(salesRowNo, CarSearchType.csNone);

                // ---ADD 2009/10/16 ------<<<<< 
                // 後で検索が必要
                this._estimateInputAcs.SearchCarDiv = true;
            }
            return retStatus;
        }

        /// <summary>
        /// 管理番号ValueChangedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 管理番号ValueChangedを発生します。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/09/08</br>
        /// </remarks>
        private void tEdit_CarMngCode_ValueChanged(object sender, EventArgs e)
        {
            // --- DEL 2009/09/08 ---------->>>>>

            //string carMngCode = this.tEdit_CarMngCode.Text;

            //Regex r = new Regex(@"^[A-Za-z0-9]+$");

            //if ((!String.IsNullOrEmpty(carMngCode)) && !r.IsMatch(carMngCode))
            //{
            //    this.tEdit_CarMngCode.Text = string.Empty;
            //}

            //--- DEL 2009/09/08 ----------<<<<<
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 ADD
        # region [車輌情報保持用]
        /// <summary>
        /// 車輌情報保持用
        /// </summary>
        private struct BeforeCarSearchBuffer
        {
            /// <summary>車台番号</summary>
            private string _produceFrameNo;
            /// <summary>生産年式</summary>
            private int _firstEntryDate;
            /// <summary>カラーコード</summary>
            private string _colorNo;
            /// <summary>トリムコード</summary>
            private string _trimNo;
            /// <summary>
            /// 車台番号
            /// </summary>
            public string ProduceFrameNo
            {
                get { return _produceFrameNo; }
                set { _produceFrameNo = value; }
            }
            /// <summary>
            /// 生産年式
            /// </summary>
            public int FirstEntryDate
            {
                get { return _firstEntryDate; }
                set { _firstEntryDate = value; }
            }
            /// <summary>
            /// カラーコード
            /// </summary>
            public string ColorNo
            {
                get { return _colorNo; }
                set { _colorNo = value; }
            }
            /// <summary>
            /// トリムコード
            /// </summary>
            public string TrimNo
            {
                get { return _trimNo; }
                set { _trimNo = value; }
            }
            /// <summary>
            /// 初期化
            /// </summary>
            public void Clear()
            {
                _produceFrameNo = string.Empty;
                _firstEntryDate = 0;
                _colorNo = string.Empty;
                _trimNo = string.Empty;
            }
        }
        # endregion

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 ADD

        // --- ADD 2010/08/05 ---------->>>>>
        # region [『Alt+F11』に【次候補】、『Alt+F12』に【全候補】用]
        /// <summary>
        /// KeyDownイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : KeyDownを発生します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2010/08/05</br>
        /// </remarks>
        private void PMMIT01010UA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                switch (e.KeyCode)
                {
                    //--------------------------------------------------
                    // F11
                    //--------------------------------------------------
                    case Keys.F11:
                        {
                            //次候補
                            this._estimateDetailInput.SetCandidate(0);
                            break;
                        }
                    //--------------------------------------------------
                    // F12
                    //--------------------------------------------------
                    case Keys.F12:
                        {
                            //全候補
                            this._estimateDetailInput.SetCandidate(1);
                            break;
                        }
                }
            }
        }
        # endregion
        // --- ADD 2010/08/05 ----------<<<<<
        // --- ADD 2011/02/14 ---------->>>>>
        /// <summary>
        /// 画面表示処理（車両情報）
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面表示処理（車両情報）の内容をクリアします。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/02/14</br>
        /// </remarks>
        private void ClearDisplayCarInfoForModelCode()
        {
            try
            {
                this._carOtherInfoInput.uGrid_EquipInfo.BeginUpdate();
                this._carOtherInfoInput.uGrid_ColorInfo.BeginUpdate();
                this._carOtherInfoInput.uGrid_TrimInfo.BeginUpdate();


                // カラー情報
                if (this._carOtherInfoInput.ColorCdInfoDataTable != null) this._carOtherInfoInput.ColorCdInfoDataTable.Clear();

                this.tEdit_ColorNo.Clear();

                // トリム情報
                if (this._carOtherInfoInput.TrimCdInfoDataTable != null) this._carOtherInfoInput.TrimCdInfoDataTable.Clear();
                this.tEdit_TrimNo.Clear();

                // 諸元情報
                this.ClearCarSpecDataTable();

                // 装備情報
                if (this._carOtherInfoInput.CEqpDefDspInfoDataTable != null) this._carOtherInfoInput.CEqpDefDspInfoDataTable.Clear();
                this._carOtherInfoInput.SettingEquipGridLayout();

            }
            finally
            {
                this._carOtherInfoInput.uGrid_TrimInfo.EndUpdate();
                this._carOtherInfoInput.uGrid_ColorInfo.EndUpdate();
                this._carOtherInfoInput.uGrid_EquipInfo.EndUpdate();
            }
        }

        /// <summary>
        /// 画面表示処理（車両情報）
        /// </summary>
        /// <param name="flag">フラッグ</param>
        /// <remarks>
        /// <br>Note       : 画面表示処理（車両情報）</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/02/14</br>
        /// <br>Update Note: 2011/03/28 曹文傑</br>
        /// <br>             Redmine #20177の対応</br>
        /// </remarks>
        private void SettingPanelCarInfo(bool flag)
        {
            this.uLabel_PartsSearchMode.Enabled = flag;
            this.panel_CarMngNo.Enabled = flag;
            this.uLabel_ModelFullNameTitle.Enabled = flag;
            this.tNedit_MakerCode.Enabled = flag;
            this.ultraLabel14.Enabled = flag;
            this.tNedit_ModelCode.Enabled = flag;
            this.ultraLabel13.Enabled = flag;
            this.tNedit_ModelSubCode.Enabled = flag;
            this.tEdit_ModelFullName.Enabled = flag;
            this.uButton_ModelFullGuide.Enabled = flag;
            this.uLabel_ModelDesignationNoTitle.Enabled = flag;
            this.tNedit_ModelDesignationNo.Enabled = flag;
            this.ultraLabel5.Enabled = flag;
            this.tNedit_CategoryNo.Enabled = flag;
            this.uLabel_EngineModelTitle.Enabled = flag;
            this.tEdit_EngineModelNm.Enabled = flag;
            this.uLabel_FirstEntryDateTitle.Enabled = flag;
            this.tDateEdit_FirstEntryDate.Enabled = flag;
            this.uLabel_FirstEntryDateRange.Enabled = flag;
            this.uLabel_ColorNoTitle.Enabled = flag;
            this.tEdit_ColorNo.Enabled = flag;
            this.uButton_ChangeSearchCarMode.Enabled = flag;
            this.tEdit_FullModel.Enabled = flag;
            this.uLabel_ProduceFrameNoTitle.Enabled = flag;
            this.tEdit_ProduceFrameNo.Enabled = flag;
            this.uLabel_ProduceFrameNoRange.Enabled = flag;
            this.uLabel_TrimNoTitle.Enabled = flag;
            this.tEdit_TrimNo.Enabled = flag;
            this.ultraGrid_CarSpec.Enabled = true;

            // ---ADD 2011/03/28------------------>>>>>
            if (flag == true)
            {
                if (this.tNedit_MakerCode.Text.Trim() == string.Empty)
                {
                    this.tNedit_ModelCode.Enabled = false;
                    this.tNedit_ModelSubCode.Enabled = false;
                }
                else
                {
                    this.tNedit_ModelCode.Enabled = true;
                    if (this.tNedit_ModelCode.Text.Trim() == string.Empty)
                    {
                        this.tNedit_ModelSubCode.Enabled = false;
                    }
                    else
                    {
                        this.tNedit_ModelSubCode.Enabled = true;
                    }
                }

                if (this.uLabel_PartsSearchMode.Text == ctSearchMode_GoodsNoSearch)
                {
                    this.tEdit_ModelFullName.Enabled = true;
                }
                else
                {
                    this.tEdit_ModelFullName.Enabled = false;
                }
            }
            // ---ADD 2011/03/28------------------<<<<<
        }
        // --- ADD 2011/02/14 ----------<<<<<

        // --- ADD 2011/11/12---------->>>>>
        /// <summary>
        /// BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑの在庫確認で作成された見積伝票の判断
        /// </summary>
        /// <param name="salesSlip">仕入データオブジェクト</param>
        /// <returns>判断結果</returns>
        /// <remarks>
        /// <br>Note       : BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑの在庫確認で作成された見積伝票の判断処理</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/11/12</br>
        /// </remarks>
        private bool isStockSales(SalesSlip salesSlip)
        {
            if (this._estimateInputAcs.SalesDetailList.Count == 0)
            {
                return false;
            }

            // 10：見積 と1:BLﾊﾟｰﾂｵｰﾀﾞｰ
            if (salesSlip.AcptAnOdrStatus == 10
                && this._estimateInputAcs.SalesDetailList[0].AcceptOrOrderKind == 1)
            {
                // メッセージを表示
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "指定した伝票は、BLﾊﾟｰﾂｵｰﾀﾞｰの在庫確認で" + "\r\n" + "\r\n" +
                    "作成された伝票なので、修正できません。",
                    -1,
                    MessageBoxButtons.OK);

                return true;
            }

            return false;
        }
        // --- ADD 2011/11/12----------<<<<<
    }
}