//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫年間実績照会
// プログラム概要   : 在庫年間実績照会UIフォーム
//----------------------------------------------------------------------------//
//                (c)Copyright  2006 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 櫻井 亮太
// 作 成 日  2008/11/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2009/03/12  修正内容 : 障害ID:12295対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/13  修正内容 : 不具合対応[12377][12378]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/03/16  修正内容 : 不具合対応[12274]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/16  修正内容 : 不具合対応[12376][12379]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/03/23  修正内容 : 不具合対応[12274]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/06  修正内容 : 不具合対応[13034][13041]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/19  修正内容 : 不具合対応[13034]のフィードバック対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/27  修正内容 : 不具合対応[13377]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/25  修正内容 : 不具合対応[13611]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2010/02/18  修正内容 : MANTIS対応[15001]グラフ機能の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2010/03/15  修正内容 : MANTIS対応[15001]グラフ機能の追加（細部の修正）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 夏野 駿希
// 修 正 日  2010/04/30  修正内容 : MANTIS対応[15360]グラフ表示の改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王　増喜
// 修 正 日  2010/07/20  修正内容 : テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : chenyd
// 修 正 日  2010/08/12  修正内容 :  障害ID:13055対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 修 正 日  2010/09/08  修正内容 :  障害ID:14444 テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 修 正 日  2010/09/13  修正内容 : テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gaofeng
// 修 正 日  2010/09/21  修正内容 : 障害ID:14876 テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 修 正 日  2010/09/28  修正内容 : 障害ID:15612 テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 修 正 日  2010/10/09  修正内容 : 障害ID:15882 テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liyp
// 修 正 日  2011/02/16  修正内容 : テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liyp
// 修 正 日  2011/03/23  修正内容 : テキスト出力対応
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 李占川
// 修 正 日  2011/07/29  修正内容 : NSユーザー改良要望一覧連番984
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : cheq
// 修 正 日  2013/01/17  修正内容 : 2013/03/13配信分 Redmine#33835 
//                                  優先倉庫制御の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Controller.Facade;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫実績照会UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 在庫実績照会UIフォームクラス</br>
    /// <br>Programmer  : 30350 櫻井 亮太</br>
    /// <br>Date        : 2008/11/25</br>
    /// <br>Update Note : 2009/03/12 30414 忍 幸史 障害ID:12295対応</br>
    /// <br>            : 2009/03/13       照田 貴志　不具合対応[12377][12378]</br>
    /// <br>            : 2009/03/16       上野 俊治　不具合対応[12274]</br>
    /// <br>            : 2009/03/16       照田 貴志　不具合対応[12376][12379]</br>
    /// <br>            : 2009/03/23       上野 俊治　不具合対応[12274]</br>
    /// <br>            : 2009/04/06       照田 貴志　不具合対応[13034][13041]</br>
    /// <br>            : 2009/05/19       照田 貴志　不具合対応[13034]のフィードバック対応</br>
    /// <br>            : 2009/05/27       照田 貴志　不具合対応[13377]</br>
    /// <br>            : 2009/06/25       照田 貴志　不具合対応[13611]</br>
    /// <br>            : 2010/07/20       王　増喜　 テキスト出力対応</br>
    /// <br>            : 2010/08/12、2010/08/19　 chenyd　    障害ID:13055対応</br>
    /// <br>            : 2010/10/09　     曹文傑 障害ID:15882対応</br>
    /// <br>            : 2011/03/23       liyp　 テキスト出力対応</br>
    /// <br>            : 2011/07/29       李占川　 NSユーザー改良要望一覧連番984</br>
    /// <br>Update Note : 2013/01/17 cheq</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#33835 優先倉庫制御の対応</br>
    /// </remarks>
    public partial class PMZAI04101UA : Form
    {
        #region Constants

        // アセンブリID
        private const string ASSMBLY_ID = "PMZAI04101U";

        // グリッド列
        private const string COLUMN_TITLE = "Title1";   　 //子列タイトル
        private const string COLUMN_SALES = "Sales"; 　 　　//売上
        private const string COLUMN_SUPPL = "Suppl"; 　 　　//仕入
        private const string COLUMN_GROSS = "Gross";　  　　//粗利
        private const string COLUMN_MOVEARRI = "MoveArri";  //移動入庫
        private const string COLUMN_MOVESHIP = "MoveShip";  //移動出庫        
        private const string COLUMN_SALESNO = "SalesNo";    //売上数
        private const string COLUMN_SALESCNT = "SalesCnt";  //売上回数
        private const string COLUMN_SALESAVG = "SalesAvg";  //売上平均
        private const string COLUMN_SALESMONY = "SalesMony";//売上金額
        private const string COLUMN_SUPPLNO = "SuppleNo";   //仕入数
        private const string COLUMN_SUPPLCNT = "SupplCnt";  //仕入回数
        private const string COLUMN_SUPPLAVG = "SupplAvg";  //仕入平均
        private const string COLUMN_SUPPLMONY = "SupplMony";//仕入金額
        private const string COLUMN_GROSSMONY = "GrossMony";//粗利金額
        private const string COLUMN_ARRINO = "ArriNo";      //移動入庫数
        private const string COLUMN_ARRIMONY = "ArraiMony"; //移動入庫金額
        private const string COLUMN_SHIPNO = "ShipNo";      //移動出庫数
        private const string COLUMN_SHIPMONY = "ShipMony";  //移動出庫金額

        private const string COLUMN_TITLE2 = "Title2"; //親列タイトル

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        private const string COLUMN_WAREHOUSECODE = "WarehouseCode";// 倉庫コード
        private const string COLUMN_GOODSNO = "GoodsNo";            // 品番				
        private const string COLUMN_MAKERCD = "MakerCd";            // メーカコード				
        private const string COLUMN_GOODSNAME = "GoodsName";        // 品名				
        private const string COLUMN_WAREHOUSESHELFNO = "WarehouseShelfNo";// 棚番				
        private const string COLUMN_BLGOODSCODE = "BlGoodsCode";    // BLコード				
        private const string COLUMN_ZAIKUYMD = "ZaikuYmd";          // 在庫登録日				
        private const string COLUMN_SALESYMDED = "SalesYmdEd";      // 最終売上日				
        private const string COLUMN_SUPPLIERYMDED = "SupplierYmdEd";// 最終仕入日
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

        #endregion Constants


        #region Private Members

        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode;

        //private string _sectionCode;

        private StockHistoryDspAcs _stockHistoryDspAcs;

        private DateGetAcs _dateGetAcs;
        private TotalDayCalculator _totalDayCalculator = null;      //ADD 2009/03/16 不具合対応[12376][12379]   締日取得部品

        private DateTime _thisYearMonth;
        private DateTime stMonth;
        private DateTime edMonth;
        private int stAddUpDate;
        private int edAddUpDate;
        private int blCode;

        private DataSet dataSet;

        private MakerAcs _makerAcs;
        private MakerUMnt makerUmnt;
        private SecInfoSetAcs _secInfoSetAcs;
        private SecInfoSet sectionInfoSet;

        private GoodsAcs _goodsAcs;

        private SupplierAcs _supplierInfoAcs;

        private WarehouseAcs _warehouseAcs;
        private Warehouse warehouse;

        private Dictionary<string, Warehouse> _warehouseDic;

        private PMZAI04101UC _userSetupFrm = null;

        // --- ADD 2009/03/23 -------------------------------->>>>>
        // 前回入力情報の保持
        private string _prevGoodsNo;
        private int _prevGoodsMakerCode;
        // --- ADD 2009/03/23 --------------------------------<<<<<

        private string _prevWarehouseCode = "";  // 2010/04/30 Add

        // ---ADD 2010/02/18 MANTIS対応[15001] -------------------->>>>>
        private List<StockHistoryDspSearchResult> _resultData;
        // ---ADD 2010/02/18 MANTIS対応[15001] --------------------<<<<<

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        private PMZAI04101UE _extractSetupFrm = null;           // 出力条件設定画面 
        private DataTable _gridBoundDataTable = null;
        private DataTable _saveGamenDataTable = null;

        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト
        private Dictionary<OperationCode, bool> _operationAuthorityList;  // 操作権限の制御リスト(直接参照すると遅いのでディクショナリ化)

        private bool _excOrtxtDiv = false;                                // テキスト出力orExcel出力区分 // ADD 2011/02/16 
        /// <summary>テキスト出力オプション情報</summary>
        private int _opt_TextOutput;
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

        #endregion

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        #region ■列挙体
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効</summary>
            OFF = 0,
            /// <summary>有効</summary>
            ON = 1,
        }

        /// <summary>
        /// オペレーションコード
        /// </summary>
        public enum OperationCode : int
        {
            /// <summary>テキスト出力</summary>
            TextOut = 1,
            /// <summary>エクセル出力</summary>
            ExcelOut = 2,
        }
        #endregion
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

        # region グローバル変数
        // ---ADD 2010/02/18 MANTIS対応[15001] -------------------->>>>>
        public const string programID = "PMZAI04100U";  // プログラムＩＤ
        // ---ADD 2010/02/18 MANTIS対応[15001] --------------------<<<<<
        # endregion

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        #region プロパティ
        /// <summary>操作権限の制御オブジェクト</summary>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateReferenceOperationAuthority(ASSMBLY_ID, this);
                }
                return _operationAuthority;
            }
        }

        /// <summary>操作権限の制御リスト</summary>
        private Dictionary<OperationCode, bool> OpeAuthDictionary
        {
            get
            {
                if (_operationAuthorityList == null)
                {
                    _operationAuthorityList = new Dictionary<OperationCode, bool>();
                    _operationAuthorityList.Add(OperationCode.TextOut, !MyOpeCtrl.Disabled((int)OperationCode.TextOut));
                    _operationAuthorityList.Add(OperationCode.ExcelOut, !MyOpeCtrl.Disabled((int)OperationCode.ExcelOut));
                }
                return _operationAuthorityList;
            }
        }
        #endregion
        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

        #region Constructor

        /// <summary>
        /// 在庫実績照会UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 在庫実績照会UIフォームクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/25</br>
        /// </remarks>
        public PMZAI04101UA ()
		{
			InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._stockHistoryDspAcs = new StockHistoryDspAcs();

            this._makerAcs = new MakerAcs();
            this.makerUmnt = new MakerUMnt();

            this._goodsAcs = new GoodsAcs();

            this._secInfoSetAcs = new SecInfoSetAcs();
            this.sectionInfoSet = new SecInfoSet();

            this._warehouseAcs = new WarehouseAcs();
            this.warehouse = new Warehouse();

            this._supplierInfoAcs = new SupplierAcs();
            this._dateGetAcs = DateGetAcs.GetInstance();
            _userSetupFrm = new PMZAI04101UC(); // ADD 2010/08/23

            // ---ADD 2009/03/16 不具合対応[12376][12379] ----------------------->>>>>
            // 締日取得部品
            this._totalDayCalculator = TotalDayCalculator.GetInstance();
            this._totalDayCalculator.InitializeHisMonthly();
            // ---ADD 2009/03/16 不具合対応[12376][12379] -----------------------<<<<<

            this.dataSet = new DataSet();
            // 倉庫マスタ読込
            ReadWarehouse();

            // 現在処理年月取得
            GetThisYearMonth();

            // 画面クリア
            ClearScreen();

            // 画面初期設定
            SetInitialSetting();

            //ログイン担当
            SetLogin();

        }

        #endregion


        #region Private Methods

        private void SetLogin()
        {
            // ログイン担当者へのアイコン設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LoginTitle_LabelToo3"];
            if (loginEmployeeLabel != null) loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            //loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.ImageHAlign = HAlign.Right;

            // ログイン担当者表示
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LoginName_LabelToo1"];
            if (LoginInfoAcquisition.Employee != null)
            {
                if (loginNameLabel != null) loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }
        }

        /// <summary>
        /// 倉庫マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 倉庫マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/25</br>
        /// </remarks>
        private void ReadWarehouse()
        {
            ArrayList retList = new ArrayList();
            this._warehouseDic = new Dictionary<string, Warehouse>();

            int status = _warehouseAcs.SearchAll(out  retList, this._enterpriseCode);

            try
            {
                foreach (Warehouse warehouse in retList)
                {
                    if (warehouse.LogicalDeleteCode == 0)
                    {
                        this._warehouseDic.Add(warehouse.WarehouseCode.Trim(), warehouse);
                    }
                }
            }
            catch
            {
                this._warehouseDic = new Dictionary<string, Warehouse>();
            }

        }

        /// <summary>
        /// 現在処理年月取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 現在処理年月を取得します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/25</br>
        /// </remarks>
        private void GetThisYearMonth()
        {
            try
            {
                /* ---DEL 2009/03/16 不具合対応[12376][12379] --------------------------------------------->>>>>
                this._dateGetAcs.GetThisYearMonth(out this._thisYearMonth);
                //_thisYearMonth = new DateTime(2008, 04, 01);
                   ---DEL 2009/03/16 不具合対応[12376][12379] ---------------------------------------------<<<<< */
                // ---ADD 2009/03/16 不具合対応[12376][12379] --------------------------------------------->>>>>
                // 今回月次更新日を取得
                DateTime prevTotalDay;
                DateTime currentTotalDay;
                DateTime prevTotalMonth;
                DateTime currentTotalMonth;
                // ---DEL 2009/05/27 不具合対応[13377] ---------------------------------------->>>>>
                //this._totalDayCalculator.GetHisTotalDayMonthly(tEdit_SectionCodeAllowZero.Text,
                //                                        out prevTotalDay,
                //                                        out currentTotalDay,
                //                                        out prevTotalMonth,
                //                                        out currentTotalMonth);
                // ---DEL 2009/05/27 不具合対応[13377] ----------------------------------------<<<<<
                // ---ADD 2009/05/27 不具合対応[13377] ---------------------------------------->>>>>
                this._totalDayCalculator.GetHisTotalDayMonthly(string.Empty,
                                                        out prevTotalDay,
                                                        out currentTotalDay,
                                                        out prevTotalMonth,
                                                        out currentTotalMonth);
                // ---ADD 2009/05/27 不具合対応[13377] ----------------------------------------<<<<<
                if (currentTotalMonth != DateTime.MinValue)
                {
                    this._thisYearMonth = currentTotalMonth;
                }
                else
                {
                    this._dateGetAcs.GetThisYearMonth(out this._thisYearMonth); 
                }
                // ---ADD 2009/03/16 不具合対応[12376][12379] ---------------------------------------------<<<<<

                this._dateGetAcs.GetDaysFromMonth(_thisYearMonth, out stMonth, out edMonth);
                
                stAddUpDate = stMonth.Year * 10000 + stMonth.Month * 100 + stMonth.Day;
                edAddUpDate = edMonth.Year * 10000 + edMonth.Month * 100 + edMonth.Day;
            }
            catch
            {
                this._thisYearMonth = new DateTime();
            }
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報の初期設定を行います。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/25</br>
        /// </remarks>
        private void SetInitialSetting()
        {
            //---------------------------------
            // 画面スキンファイルの読込(デフォルトスキン指定)
            //---------------------------------
            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.Standard_UGroupBox.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            //---------------------------------
            // アイコン設定
            //---------------------------------
            this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            ButtonTool workButton;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
            // --- CHG 2009/03/12 障害ID:12295対応------------------------------------------------------>>>>>
            //workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // --- CHG 2009/03/12 障害ID:12295対応------------------------------------------------------<<<<<
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            // --- CHG 2009/03/12 障害ID:12295対応------------------------------------------------------>>>>>
            //workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // --- CHG 2009/03/12 障害ID:12295対応------------------------------------------------------<<<<<
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BARGRAPH1;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools[" ButtonTool_Setup"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;

            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractExcel"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;

            #region ● テキスト出力オプション
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus textOutputPs;
            textOutputPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            if (textOutputPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_TextOutput = (int)Option.ON;
            }
            else
            {
                this._opt_TextOutput = (int)Option.OFF;
            }
            //テキスト出力オプションが有効の場合
            if (this._opt_TextOutput == (int)Option.ON)
            {
                // テキスト出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Visible = true;
                // EXCEL出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractExcel"].SharedProps.Visible = true;
                //設定画面のテキスト出力タブを表示する
                this._userSetupFrm.uTabControlSet(true); // ADD 2010/08/23
            }
            //テキスト出力オプションが無効の場合
            else
            {
                // テキスト出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Visible = false;
                // EXCEL出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractExcel"].SharedProps.Visible = false;
                //設定画面のテキスト出力タブを表示する
                this._userSetupFrm.uTabControlSet(false); // ADD 2010/08/23
            }
            #endregion

            if (!OpeAuthDictionary[OperationCode.TextOut])
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Visible = false;
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Shortcut = Shortcut.None;
            }
            if (!OpeAuthDictionary[OperationCode.ExcelOut])
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractExcel"].SharedProps.Visible = false;
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractExcel"].SharedProps.Shortcut = Shortcut.None;
            }
            if ((!OpeAuthDictionary[OperationCode.TextOut]) && (!OpeAuthDictionary[OperationCode.ExcelOut])) //ADD 2010/08/23
            {
                //設定画面のテキスト出力タブを表示する
                this._userSetupFrm.uTabControlSet(false);// ADD 2010/08/23
            }

            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

            //this._setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"];
            //this._graphButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"];

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.MakerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.warehouseGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.sectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // --- ADD 2010/02/18 -------------------------------->>>>>
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
            // --- ADD 2010/02/18 --------------------------------<<<<<

            //---------------------------------
            // グリッド設定
            //---------------------------------

            CreateGrid(new List<StockHistoryDspSearchResult>());
            
            SetGridLayout();

        }

        /// <summary>
        /// 画面情報クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/111/25</br>
        /// </remarks>
        private void ClearScreen()
        {

            this.tEdit_GoodsNo.Clear();
            this.tEdit_GoodsName.Clear();
            this.tNedit_GoodsMakerCd.Clear();
            this.tEdit_MakerName.Clear();
            this.tEdit_WarehouseCode.Clear();
            this.tEdit_WarehouseName.Clear();
            this.tNedit_SupplierCd.Clear();
            this.tEdit_SupplierName.Clear();
            this.tDateEdit_CAddUpUpdExecDateSt.Clear();
            this.tDateEdit_LastSalesDate.Clear();
            this.tDateEdit_LastStockDate.Clear();
            //this.tEdit_SectionCodeAllowZero.Clear();          //DEL 2009/06/25 不具合対応[13611]
            this.tEdit_SectionGuideNm.Clear();

            // --- ADD 2009/03/23 -------------------------------->>>>>
            this._prevGoodsNo = string.Empty;
            this._prevGoodsMakerCode = 0;
            // --- ADD 2009/03/23 --------------------------------<<<<<
            
            // グリッド
            CreateGrid(new List<StockHistoryDspSearchResult>());

            // フォーカス設定
            //this.tEdit_SectionCodeAllowZero.Focus();          //DEL 2009/06/25 不具合対応[13611]
            this.tEdit_GoodsNo.Focus();                         //ADD 2009/06/25 不具合対応[13611]
        }

        /// <summary>
        /// グリッド作成処理
        /// </summary>
        /// <param name="updHisDspWorkList">更新履歴リスト</param>
        /// <remarks>
        /// <br>Note        : グリッドを作成します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/25</br>
        /// </remarks>
        private void CreateGrid(List<StockHistoryDspSearchResult> stockHistoryDspSearchResult)
        {
            //--------------------------------------
            // グリッド列、データ設定
            //--------------------------------------
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add(COLUMN_TITLE, typeof(string));

            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            dataTable.Columns.Add(COLUMN_WAREHOUSECODE, typeof(string));
            dataTable.Columns.Add(COLUMN_GOODSNO, typeof(string));
            dataTable.Columns.Add(COLUMN_MAKERCD, typeof(string));
            dataTable.Columns.Add(COLUMN_GOODSNAME, typeof(string));
            dataTable.Columns.Add(COLUMN_WAREHOUSESHELFNO, typeof(string));
            dataTable.Columns.Add(COLUMN_BLGOODSCODE, typeof(string));
            dataTable.Columns.Add(COLUMN_ZAIKUYMD, typeof(string));
            dataTable.Columns.Add(COLUMN_SALESYMDED, typeof(string));
            dataTable.Columns.Add(COLUMN_SUPPLIERYMDED, typeof(string));

            // 売上・*
            for (int i = 0; i <= 12; i++)
            {
                dataTable.Columns.Add(COLUMN_SALESNO + i.ToString(), typeof(double));
                //dataTable.Columns.Add(COLUMN_SALESCNT + i.ToString(), typeof(string)); // DEL 2010/10/09
                //dataTable.Columns.Add(COLUMN_SALESMONY + i.ToString(), typeof(string)); // DEL 2010/10/09
                dataTable.Columns.Add(COLUMN_SALESCNT + i.ToString(), typeof(int)); // ADD 2010/10/09
                dataTable.Columns.Add(COLUMN_SALESMONY + i.ToString(), typeof(long)); // ADD 2010/10/09
            }

            // 仕入・*
            for (int i = 0; i <= 12; i++)
            {
                dataTable.Columns.Add(COLUMN_SUPPLNO + i.ToString(), typeof(double));
                //dataTable.Columns.Add(COLUMN_SUPPLCNT + i.ToString(), typeof(string)); // DEL 2010/10/09
                //dataTable.Columns.Add(COLUMN_SUPPLMONY + i.ToString(), typeof(string)); // DEL 2010/10/09
                dataTable.Columns.Add(COLUMN_SUPPLCNT + i.ToString(), typeof(int)); // ADD 2010/10/09
                dataTable.Columns.Add(COLUMN_SUPPLMONY + i.ToString(), typeof(long)); // ADD 2010/10/09
            }

            // 粗利数
            for (int i = 0; i <= 12; i++)
            {
                dataTable.Columns.Add(COLUMN_GROSSMONY + i.ToString(), typeof(double));
            }

            // 移動入庫・*
            for (int i = 0; i <= 12; i++)
            {
                dataTable.Columns.Add(COLUMN_ARRINO + i.ToString(), typeof(double));
                //dataTable.Columns.Add(COLUMN_ARRIMONY + i.ToString(), typeof(string)); // DEL 2010/10/09
                dataTable.Columns.Add(COLUMN_ARRIMONY + i.ToString(), typeof(long)); // ADD 2010/10/09
            }

            // 移動入庫・*
            for (int i = 0; i <= 12; i++)
            {
                dataTable.Columns.Add(COLUMN_SHIPNO + i.ToString(), typeof(double));
                //dataTable.Columns.Add(COLUMN_SHIPMONY + i.ToString(), typeof(string)); // DEL 2010/10/09
                dataTable.Columns.Add(COLUMN_SHIPMONY + i.ToString(), typeof(long)); // ADD 2010/10/09
            }
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

            dataTable.Columns.Add(COLUMN_SALESNO, typeof(double));
            dataTable.Columns.Add(COLUMN_SALESCNT, typeof(string));
            dataTable.Columns.Add(COLUMN_SALESAVG, typeof(double));
            dataTable.Columns.Add(COLUMN_SALESMONY, typeof(string));
            dataTable.Columns.Add(COLUMN_SUPPLNO, typeof(double));
            dataTable.Columns.Add(COLUMN_SUPPLCNT, typeof(string));
            dataTable.Columns.Add(COLUMN_SUPPLAVG, typeof(double));
            dataTable.Columns.Add(COLUMN_SUPPLMONY, typeof(string));
            dataTable.Columns.Add(COLUMN_GROSSMONY, typeof(string));
            dataTable.Columns.Add(COLUMN_ARRINO, typeof(double));
            dataTable.Columns.Add(COLUMN_ARRIMONY, typeof(string));
            dataTable.Columns.Add(COLUMN_SHIPNO, typeof(double));
            dataTable.Columns.Add(COLUMN_SHIPMONY, typeof(string));

            _gridBoundDataTable = dataTable.Copy(); // ADD 2010/07/20 テキスト出力対応 --------------------

            string[] titleArray = new string[15];
            titleArray[0] = "当月";
            for (int i = 1; i <= 12; i++)
            {
                titleArray[i] = _thisYearMonth.AddMonths(-i).Month.ToString() + "月";
            }
            titleArray[13] = "合計";
            titleArray[14] = "平均";

            for (int index = 0; index < 15; index++)
            {
                DataRow dataRow = dataTable.NewRow();

                dataRow[COLUMN_TITLE] = titleArray[index];
                //dataRow[COLUMN_SALESNO] = "";
                dataRow[COLUMN_SALESCNT] = "";
                //dataRow[COLUMN_SALESAVG];
                dataRow[COLUMN_SALESMONY] = "";
                //dataRow[COLUMN_SUPPLNO] = "";
                dataRow[COLUMN_SUPPLCNT] = "";
                //dataRow[COLUMN_SUPPLAVG];
                dataRow[COLUMN_SUPPLMONY] = "";
                dataRow[COLUMN_GROSSMONY] = "";
                //dataRow[COLUMN_ARRINO] = "";
                dataRow[COLUMN_ARRIMONY] = "";
                //dataRow[COLUMN_SHIPNO] = "";
                dataRow[COLUMN_SHIPMONY] = "";
                
                dataTable.Rows.Add(dataRow);
            }
            this.uGrid_Details.DataSource = dataTable;
            this.uGrid_Details.ActiveRow = null;

            this.uGrid_Details.Rows[14].Cells[COLUMN_SALESAVG].Activation = Activation.NoEdit;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SALESAVG].Appearance.BackColorDisabled = Color.Gainsboro;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SALESAVG].Appearance.BackColorDisabled2 = Color.Gainsboro;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SALESAVG].Appearance.BackColor = Color.Gainsboro;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SALESAVG].Appearance.BackColor2 = Color.Gainsboro;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SALESAVG].Appearance.BackGradientStyle = GradientStyle.Vertical;

            this.uGrid_Details.Rows[14].Cells[COLUMN_SUPPLAVG].Activation = Activation.NoEdit;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SUPPLAVG].Appearance.BackColorDisabled = Color.Gainsboro;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SUPPLAVG].Appearance.BackColorDisabled2 = Color.Gainsboro;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SUPPLAVG].Appearance.BackColor = Color.Gainsboro;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SUPPLAVG].Appearance.BackColor2 = Color.Gainsboro;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SUPPLAVG].Appearance.BackGradientStyle = GradientStyle.Vertical;

            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;
                col.CellAppearance.FontData.SizeInPoints = 9f;   // フォントサイズ変更
            }

            // 列表示状態
            columns[COLUMN_TITLE].Hidden = false;
            columns[COLUMN_SALESNO].Hidden = false;
            columns[COLUMN_SALESCNT].Hidden = false;
            columns[COLUMN_SALESAVG].Hidden = false;
            columns[COLUMN_SALESMONY].Hidden = false;
            columns[COLUMN_SUPPLNO].Hidden = false;
            columns[COLUMN_SUPPLCNT].Hidden = false;
            columns[COLUMN_SUPPLAVG].Hidden = false;
            columns[COLUMN_SUPPLMONY].Hidden = false;
            columns[COLUMN_GROSSMONY].Hidden = false;
            columns[COLUMN_ARRINO].Hidden = false;
            columns[COLUMN_ARRIMONY].Hidden = false;
            columns[COLUMN_SHIPNO].Hidden = false;
            columns[COLUMN_SHIPMONY].Hidden = false;

            _saveGamenDataTable = dataTable.Copy();
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
        }


        /// <summary>
        /// グリッドレイアウト設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドレイアウトを設定します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/25</br>
        /// </remarks>
        private void SetGridLayout()
        {
            //--------------------------------------
            // グリッド外観設定
            //--------------------------------------

            ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // キャプション
            columns[COLUMN_TITLE].Header.Caption = "";
            columns[COLUMN_SALESNO].Header.Caption = "数";
            columns[COLUMN_SALESCNT].Header.Caption = "回数";
            columns[COLUMN_SALESAVG].Header.Caption = "平均";
            columns[COLUMN_SALESMONY].Header.Caption = "金額";
            columns[COLUMN_SUPPLNO].Header.Caption = "数";
            columns[COLUMN_SUPPLCNT].Header.Caption = "回数";
            columns[COLUMN_SUPPLAVG].Header.Caption = "平均";
            columns[COLUMN_SUPPLMONY].Header.Caption = "金額";
            columns[COLUMN_GROSSMONY].Header.Caption = "金額";
            columns[COLUMN_ARRINO].Header.Caption = "数";
            columns[COLUMN_ARRIMONY].Header.Caption = "金額";
            columns[COLUMN_SHIPNO].Header.Caption = "数";
            columns[COLUMN_SHIPMONY].Header.Caption = "金額";

            columns[COLUMN_TITLE].Width = 35;
            columns[COLUMN_SALESNO].Width = 66;
            columns[COLUMN_SALESCNT].Width = 66;
            columns[COLUMN_SALESAVG].Width = 61;
            columns[COLUMN_SALESMONY].Width = 90;
            columns[COLUMN_SUPPLNO].Width = 66;
            columns[COLUMN_SUPPLCNT].Width = 66;
            columns[COLUMN_SUPPLAVG].Width = 61;
            columns[COLUMN_SUPPLMONY].Width = 90;
            columns[COLUMN_GROSSMONY].Width = 90;
            columns[COLUMN_ARRINO].Width = 66;
            columns[COLUMN_ARRIMONY].Width = 90;
            columns[COLUMN_SHIPNO].Width = 66;
            columns[COLUMN_SHIPMONY].Width = 90;

            // テキスト位置(HAlign)
            columns[COLUMN_TITLE].CellAppearance.TextHAlign = HAlign.Center;
            columns[COLUMN_SALESNO].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_SALESCNT].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_SALESAVG].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_SALESMONY].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_SUPPLNO].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_SUPPLCNT].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_SUPPLAVG].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_SUPPLMONY].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_GROSSMONY].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_ARRINO].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_ARRIMONY].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_SHIPNO].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_SHIPMONY].CellAppearance.TextHAlign = HAlign.Right;

            // テキスト位置(VAlign)
            columns[COLUMN_TITLE].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SALESNO].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SALESCNT].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SALESAVG].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SALESMONY].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SUPPLNO].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SUPPLCNT].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SUPPLAVG].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SUPPLMONY].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_GROSSMONY].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_ARRINO].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_ARRIMONY].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SHIPNO].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_SHIPMONY].CellAppearance.TextVAlign = VAlign.Middle;

            // セルカラー
            columns[COLUMN_TITLE].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            columns[COLUMN_TITLE].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            columns[COLUMN_TITLE].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[COLUMN_TITLE].CellAppearance.ForeColor = Color.White;
            columns[COLUMN_TITLE].CellAppearance.ForeColorDisabled = Color.White;
            
            
            //columns[COLUMN_SALESAVG].

            columns[COLUMN_SALESAVG].Format = "##,##0.00";
            columns[COLUMN_SUPPLAVG].Format = "##,##0.00";
            columns[COLUMN_SALESNO].Format = "##,##0.00";
            columns[COLUMN_SUPPLNO].Format = "##,##0.00";
            columns[COLUMN_ARRINO].Format = "##,##0.00";
            columns[COLUMN_SHIPNO].Format = "##,##0.00";

            // 固定ヘッダー
            columns[COLUMN_TITLE].Header.Fixed = true;
        }

        ///// <summary>
        ///// グリッドレイアウト設定処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note        : グリッドレイアウトを設定します。</br>
        ///// <br>Programmer  : 30350 櫻井 亮太</br>
        ///// <br>Date        : 2008/11/25</br>
        ///// </remarks>
        //private void SetGridLayout2()
        //{
        //    //--------------------------------------
        //    // グリッド外観設定
        //    //--------------------------------------
        //    ColumnsCollection columns2 = this.ultraGrid1.DisplayLayout.Bands[0].Columns;

        //    //// キャプション
        //    columns2[COLUMN_TITLE2].Header.Caption = "";
        //    columns2[COLUMN_SALES].Header.Caption = "売上";
        //    columns2[COLUMN_SUPPL].Header.Caption = "仕入";
        //    columns2[COLUMN_GROSS].Header.Caption = "粗利";
        //    columns2[COLUMN_MOVEARRI].Header.Caption = "移動入庫";
        //    columns2[COLUMN_MOVESHIP].Header.Caption = "移動出庫";

        //    // 列幅
        //    columns2[COLUMN_TITLE2].Width = 70;
        //    columns2[COLUMN_SALES].Width = 280;
        //    columns2[COLUMN_SUPPL].Width = 280;
        //    columns2[COLUMN_GROSS].Width = 70;
        //    columns2[COLUMN_MOVEARRI].Width = 140;
        //    columns2[COLUMN_MOVESHIP].Width = 140;

        //    // テキスト位置(HAlign)
        //    columns2[COLUMN_TITLE2].CellAppearance.TextHAlign = HAlign.Center;
        //    columns2[COLUMN_SALES].CellAppearance.TextHAlign = HAlign.Right;
        //    columns2[COLUMN_SUPPL].CellAppearance.TextHAlign = HAlign.Right;
        //    columns2[COLUMN_GROSS].CellAppearance.TextHAlign = HAlign.Right;
        //    columns2[COLUMN_MOVEARRI].CellAppearance.TextHAlign = HAlign.Right;
        //    columns2[COLUMN_MOVESHIP].CellAppearance.TextHAlign = HAlign.Right;

        //    // テキスト位置(VAlign)
        //    columns2[COLUMN_TITLE2].CellAppearance.TextVAlign = VAlign.Middle;
        //    columns2[COLUMN_SALES].CellAppearance.TextVAlign = VAlign.Middle;
        //    columns2[COLUMN_SUPPL].CellAppearance.TextVAlign = VAlign.Middle;
        //    columns2[COLUMN_GROSS].CellAppearance.TextVAlign = VAlign.Middle;
        //    columns2[COLUMN_MOVEARRI].CellAppearance.TextVAlign = VAlign.Middle;
        //    columns2[COLUMN_MOVESHIP].CellAppearance.TextVAlign = VAlign.Middle;

        //    // セルカラー
        //    columns2[COLUMN_TITLE2].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
        //    columns2[COLUMN_TITLE2].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
        //    columns2[COLUMN_TITLE2].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
        //    columns2[COLUMN_TITLE2].CellAppearance.ForeColor = Color.White;
        //    columns2[COLUMN_TITLE2].CellAppearance.ForeColorDisabled = Color.White;

        //    // 固定ヘッダー
        //    columns2[COLUMN_TITLE2].Header.Fixed = true;
        //}


        /// <summary>
        /// 在庫実績照会抽出結果画面表示処理
        /// </summary>
        /// <param name="shipmentPartsDspResultList">在庫実績照会抽出結果リスト</param>
        /// <remarks>
        /// <br>Note        : 在庫実績照会抽出結果リストを画面表示します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/25</br>
        /// </remarks>
        private void ShipmentPartsDspResultToScreen(List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList)
        {
            if (stockHistoryDspSearchResultList == null)
            {
                return;
            }

            double salesNo, sumSalesNo=0;
            int salesCnt, sumSalesCnt=0;
            double salesAvg;
            long salesMoney, sumSalesMoney=0;
            double stockNo, sumStockNo=0;
            int stockCnt, sumStockCnt=0;
            double stockAvg;
            long stockMoney, sumStockMoney=0;
            long grossProfit, sumGrossProfit=0;
            double arriNo, sumArriNo=0;
            long arriMoney, sumArriMoney=0;
            double shipNo, sumShipNo=0;
            long shipMoney, sumShipMoney=0;

            int i = 0;
            ArrayList avgList = new ArrayList();

            // ---ADD 2009/04/06 不具合対応[13041] --------------------------------------->>>>>
            for (i = 0; i <= 12; i++)
            {
                // 売上
                this.uGrid_Details.Rows[i].Cells[COLUMN_SALESNO].Value = 0;
                this.uGrid_Details.Rows[i].Cells[COLUMN_SALESCNT].Value = "0";
                this.uGrid_Details.Rows[i].Cells[COLUMN_SALESAVG].Value = 0;
                this.uGrid_Details.Rows[i].Cells[COLUMN_SALESMONY].Value = "0";

                // 仕入
                this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLNO].Value = 0;
                this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLCNT].Value = "0";
                this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLAVG].Value = 0;
                this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLMONY].Value = "0";

                // 粗利
                this.uGrid_Details.Rows[i].Cells[COLUMN_GROSSMONY].Value = "0";

                // 移動入庫
                this.uGrid_Details.Rows[i].Cells[COLUMN_ARRINO].Value = 0;
                this.uGrid_Details.Rows[i].Cells[COLUMN_ARRIMONY].Value = "0";

                // 移動出庫
                this.uGrid_Details.Rows[i].Cells[COLUMN_SHIPNO].Value = 0;
                this.uGrid_Details.Rows[i].Cells[COLUMN_SHIPMONY].Value = "0";
            }
            // ---ADD 2009/04/06 不具合対応[13041] ---------------------------------------<<<<<

            foreach (StockHistoryDspSearchResult stockHistoryDspSearchResult in stockHistoryDspSearchResultList)
            {
                if (stockHistoryDspSearchResult.SearchDiv == 1)
                {
                    avgList.Add(stockHistoryDspSearchResult);
                }

                    #region 前月～1年間
                    for (i = 12; i >= 0; i--)
                    {
                        if (stockHistoryDspSearchResult.SearchDiv == 0)
                        {
                            #region 当月
                            // 売上
                            salesNo = stockHistoryDspSearchResult.SalesCount;
                            this.uGrid_Details.Rows[0].Cells[COLUMN_SALESNO].Value = salesNo;
                            


                            salesCnt = stockHistoryDspSearchResult.SalesTimes;
                            this.uGrid_Details.Rows[0].Cells[COLUMN_SALESCNT].Value = salesCnt.ToString("#,###,##0");

                            if (stockHistoryDspSearchResult.SalesTimes == 0)
                            {
                                this.uGrid_Details.Rows[0].Cells[COLUMN_SALESAVG].Value = 0.00;
                            }
                            else
                            {
                                //salesAvg = (double)stockHistoryDspSearchResult.SalesCount / (double)stockHistoryDspSearchResult.SalesTimes;               //DEL 2009/03/13 不具合対応[12378]
                                salesAvg = Math.Round((double)stockHistoryDspSearchResult.SalesCount / (double)stockHistoryDspSearchResult.SalesTimes, 2);  //ADD 2009/03/13 不具合対応[12378]
                                this.uGrid_Details.Rows[0].Cells[COLUMN_SALESAVG].Value = salesAvg.ToString("##,##0.00");
                            }
                            salesMoney = stockHistoryDspSearchResult.SalesMoneyTaxExc;
                            this.uGrid_Details.Rows[0].Cells[COLUMN_SALESMONY].Value = salesMoney.ToString("#,###,###,##0");

                            // 仕入
                            stockNo = stockHistoryDspSearchResult.StockCount;
                            this.uGrid_Details.Rows[0].Cells[COLUMN_SUPPLNO].Value = stockNo;

                            stockCnt = stockHistoryDspSearchResult.StockTimes;
                            this.uGrid_Details.Rows[0].Cells[COLUMN_SUPPLCNT].Value = stockCnt.ToString("#,###,##0");

                            if (stockHistoryDspSearchResult.StockTimes == 0)
                            {
                                this.uGrid_Details.Rows[0].Cells[COLUMN_SUPPLAVG].Value = 0.00;
                            }
                            else
                            {
                                //stockAvg = (double)stockHistoryDspSearchResult.StockCount / (double)stockHistoryDspSearchResult.StockTimes;               //DEL 2009/03/13 不具合対応[12378]
                                stockAvg = Math.Round((double)stockHistoryDspSearchResult.StockCount / (double)stockHistoryDspSearchResult.StockTimes, 2);  //ADD 2009/03/13 不具合対応[12378]
                                this.uGrid_Details.Rows[0].Cells[COLUMN_SUPPLAVG].Value = stockAvg.ToString("##,##0.00");
                            }
                            stockMoney = stockHistoryDspSearchResult.StockPriceTaxExc;
                            this.uGrid_Details.Rows[0].Cells[COLUMN_SUPPLMONY].Value = stockMoney.ToString("#,###,###,##0");

                            // 粗利
                            grossProfit = stockHistoryDspSearchResult.GrossProfit;
                            this.uGrid_Details.Rows[0].Cells[COLUMN_GROSSMONY].Value = grossProfit.ToString("#,###,###,##0");

                            // 移動入庫
                            arriNo = stockHistoryDspSearchResult.MoveArrivalCnt;
                            this.uGrid_Details.Rows[0].Cells[COLUMN_ARRINO].Value = arriNo;

                            arriMoney = stockHistoryDspSearchResult.MoveArrivalPrice;
                            this.uGrid_Details.Rows[0].Cells[COLUMN_ARRIMONY].Value = arriMoney.ToString("#,###,###,##0");

                            // 移動出庫
                            shipNo = stockHistoryDspSearchResult.MoveShipmentCnt;
                            this.uGrid_Details.Rows[0].Cells[COLUMN_SHIPNO].Value = shipNo;

                            shipMoney = stockHistoryDspSearchResult.MoveShipmentPrice;
                            this.uGrid_Details.Rows[0].Cells[COLUMN_SHIPMONY].Value = shipMoney.ToString("#,###,###,##0");
                            #endregion
                        }
                        else
                        {
                            int month = _thisYearMonth.AddMonths(-i).Month;
                            int year = _thisYearMonth.AddMonths(-i).Year;
                            if (stockHistoryDspSearchResult.AddUpYearMonth.Month == month && stockHistoryDspSearchResult.AddUpYearMonth.Year == year)
                            {
                                // 売上
                                salesNo = stockHistoryDspSearchResult.SalesCount;
                                this.uGrid_Details.Rows[i].Cells[COLUMN_SALESNO].Value = salesNo;
                                sumSalesNo += salesNo;

                                salesCnt = stockHistoryDspSearchResult.SalesTimes;
                                this.uGrid_Details.Rows[i].Cells[COLUMN_SALESCNT].Value = salesCnt.ToString("#,###,##0");
                                sumSalesCnt += salesCnt;
                                if (stockHistoryDspSearchResult.SalesTimes == 0)
                                {
                                    this.uGrid_Details.Rows[i].Cells[COLUMN_SALESAVG].Value = 0.00;
                                }
                                else
                                {
                                    //salesAvg = (double)stockHistoryDspSearchResult.SalesCount / (double)stockHistoryDspSearchResult.SalesTimes;               //DEL 2009/03/13 不具合対応[12378]
                                    salesAvg = Math.Round((double)stockHistoryDspSearchResult.SalesCount / (double)stockHistoryDspSearchResult.SalesTimes, 2);  //ADD 2009/03/13 不具合対応[12378]
                                    this.uGrid_Details.Rows[i].Cells[COLUMN_SALESAVG].Value = salesAvg;//.ToString("##,##0.00");
                                }
                                salesMoney = stockHistoryDspSearchResult.SalesMoneyTaxExc;
                                this.uGrid_Details.Rows[i].Cells[COLUMN_SALESMONY].Value = salesMoney.ToString("#,###,###,##0");
                                sumSalesMoney += salesMoney;

                                // 仕入
                                stockNo = stockHistoryDspSearchResult.StockCount;
                                this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLNO].Value = stockNo;
                                sumStockNo += stockNo;

                                stockCnt = stockHistoryDspSearchResult.StockTimes;
                                this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLCNT].Value = stockCnt.ToString("#,###,##0");
                                sumStockCnt += stockCnt;
                                if (stockHistoryDspSearchResult.StockTimes == 0)
                                {
                                    this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLAVG].Value = 0.00;
                                }
                                else
                                {
                                    //stockAvg = (double)stockHistoryDspSearchResult.StockCount / (double)stockHistoryDspSearchResult.StockTimes;               //DEL 2009/03/13 不具合対応[12378]
                                    stockAvg = Math.Round((double)stockHistoryDspSearchResult.StockCount / (double)stockHistoryDspSearchResult.StockTimes, 2);  //ADD 2009/03/13 不具合対応[12378]
                                    this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLAVG].Value = stockAvg;//.ToString("##,##0.00");
                                }
                                stockMoney = stockHistoryDspSearchResult.StockPriceTaxExc;
                                this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLMONY].Value = stockMoney.ToString("#,###,###,##0"); 
                                sumStockMoney += stockMoney;

                                // 粗利
                                grossProfit = stockHistoryDspSearchResult.GrossProfit;
                                this.uGrid_Details.Rows[i].Cells[COLUMN_GROSSMONY].Value = grossProfit.ToString("#,###,###,##0");
                                sumGrossProfit += grossProfit;

                                // 移動入庫
                                arriNo = stockHistoryDspSearchResult.MoveArrivalCnt;
                                this.uGrid_Details.Rows[i].Cells[COLUMN_ARRINO].Value = arriNo;
                                sumArriNo += arriNo;

                                arriMoney = stockHistoryDspSearchResult.MoveArrivalPrice;
                                this.uGrid_Details.Rows[i].Cells[COLUMN_ARRIMONY].Value = arriMoney.ToString("#,###,###,##0");
                                sumArriMoney += arriMoney;

                                // 移動出庫
                                shipNo = stockHistoryDspSearchResult.MoveShipmentCnt;
                                this.uGrid_Details.Rows[i].Cells[COLUMN_SHIPNO].Value = shipNo;
                                sumShipNo += shipNo;

                                shipMoney = stockHistoryDspSearchResult.MoveShipmentPrice;
                                this.uGrid_Details.Rows[i].Cells[COLUMN_SHIPMONY].Value = shipMoney.ToString("#,###,###,##0");
                                sumShipMoney += shipMoney;
                            }
                    }
                  
                    #endregion
                }
                i--;
            }

            #region 合計
            double sumStockAvg = 0.00;
            double sumSaleAvg = 0.00;
            if (sumSalesCnt != 0)
            {
                sumSaleAvg = (double)sumSalesNo / (double)sumSalesCnt;
            }
            if (sumStockCnt != 0)
            {
                sumStockAvg = (double)sumStockNo / (double)sumStockCnt;
            }

            // 売上
            this.uGrid_Details.Rows[13].Cells[COLUMN_SALESNO].Value = sumSalesNo;
            this.uGrid_Details.Rows[13].Cells[COLUMN_SALESCNT].Value = sumSalesCnt.ToString("#,###,##0");
            this.uGrid_Details.Rows[13].Cells[COLUMN_SALESAVG].Value = sumSaleAvg;//.ToString("##,##0.00");
            this.uGrid_Details.Rows[13].Cells[COLUMN_SALESMONY].Value = sumSalesMoney.ToString("#,###,###,##0");

            // 仕入
            this.uGrid_Details.Rows[13].Cells[COLUMN_SUPPLNO].Value = sumStockNo;
            this.uGrid_Details.Rows[13].Cells[COLUMN_SUPPLCNT].Value = sumStockCnt.ToString("#,###,##0");
            this.uGrid_Details.Rows[13].Cells[COLUMN_SUPPLAVG].Value = sumStockAvg;//.ToString("##,##0.00");
            this.uGrid_Details.Rows[13].Cells[COLUMN_SUPPLMONY].Value = sumStockMoney.ToString("#,###,###,##0");

            // 粗利
            this.uGrid_Details.Rows[13].Cells[COLUMN_GROSSMONY].Value = sumGrossProfit.ToString("#,###,###,##0");

            // 移動入庫
            this.uGrid_Details.Rows[13].Cells[COLUMN_ARRINO].Value = sumArriNo;
            this.uGrid_Details.Rows[13].Cells[COLUMN_ARRIMONY].Value = sumArriMoney.ToString("#,###,###,##0");

            // 移動出庫
            this.uGrid_Details.Rows[13].Cells[COLUMN_SHIPNO].Value = sumShipNo;
            this.uGrid_Details.Rows[13].Cells[COLUMN_SHIPMONY].Value = sumShipMoney.ToString("#,###,###,##0");
            #endregion

            #region 平均

            double sumSaNo = 0;
            double sumStNo = 0;
            //double avSaleAvg = ((double)(sumSalesNo / avgList.Count)) / ((double)(sumSalesCnt / avgList.Count));
            //double avStockAvg = ((double)(sumStockNo / avgList.Count)) / ((double)(sumStockCnt / avgList.Count));
            double avSalesCnt = 0;
            double avSumSalesMony = 0;
            double avSumStockCnt = 0;
            double avSumStockMony = 0;
            double avSumGross = 0;
            double avSumArriNo = 0;
            double avSumArriMony = 0;
            double avSumShipNo = 0;
            double avSumShipMony = 0;
            /* ---DEL 2009/03/13 不具合対応[12377][12378] ---------------------------------------------------->>>>>
            if (avgList.Count != 0)
            {
                sumSaNo = sumSalesNo / avgList.Count;
                sumStNo = sumStockNo / avgList.Count;
                //double avSaleAvg = ((double)(sumSalesNo / avgList.Count)) / ((double)(sumSalesCnt / avgList.Count));
                //double avStockAvg = ((double)(sumStockNo / avgList.Count)) / ((double)(sumStockCnt / avgList.Count));
                avSalesCnt = (sumSalesCnt / avgList.Count);
                avSumSalesMony = sumSalesMoney / avgList.Count;
                avSumStockCnt = sumStockCnt / avgList.Count;
                avSumStockMony = sumStockMoney / avgList.Count;
                avSumGross = sumGrossProfit / avgList.Count;
                avSumArriNo = sumArriNo / avgList.Count;
                avSumArriMony = sumArriMoney / avgList.Count;
                avSumShipNo = sumShipNo / avgList.Count;
                avSumShipMony = sumShipMoney / avgList.Count;
            }
               ---DEL 2009/03/13 不具合対応[12377][12378] ----------------------------------------------------<<<<< */
            // ---ADD 2009/03/13 不具合対応[12377][12378] ---------------------------------------------------->>>>>
            sumSaNo = Math.Round(sumSalesNo / 12, 2);
            avSalesCnt = Math.Round((double)sumSalesCnt / 12, 0);
            avSumSalesMony = Math.Round((double)sumSalesMoney / 12, 0);
            sumStNo = Math.Round(sumStockNo / 12, 2);
            avSumStockCnt = Math.Round((double)sumStockCnt / 12, 0);
            avSumStockMony = Math.Round((double)sumStockMoney / 12, 0);
            avSumGross = Math.Round((double)sumGrossProfit / 12, 0);
            avSumArriNo = Math.Round(sumArriNo / 12, 2);
            avSumArriMony = Math.Round((double)sumArriMoney / 12, 0);
            avSumShipNo = Math.Round(sumShipNo / 12, 2);
            avSumShipMony = Math.Round((double)sumShipMoney / 12, 0);
            // ---ADD 2009/03/13 不具合対応[12377][12378] ----------------------------------------------------<<<<<

            // 売上
            this.uGrid_Details.Rows[14].Cells[COLUMN_SALESNO].Value = sumSaNo;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SALESCNT].Value = avSalesCnt.ToString("#,###,##0");;
            //this.uGrid_Details.Rows[14].Cells[COLUMN_SALESAVG].Value = avSaleAvg;//.ToString("##,##0.00");
            this.uGrid_Details.Rows[14].Cells[COLUMN_SALESMONY].Value = avSumSalesMony.ToString("#,###,###,##0");


            // 仕入
            this.uGrid_Details.Rows[14].Cells[COLUMN_SUPPLNO].Value = sumStNo;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SUPPLCNT].Value = avSumStockCnt.ToString("#,###,##0");
            //this.uGrid_Details.Rows[14].Cells[COLUMN_SUPPLAVG].Value = avStockAvg;//.ToString("##,##0.00");
            this.uGrid_Details.Rows[14].Cells[COLUMN_SUPPLMONY].Value = avSumStockMony.ToString("#,###,###,##0");

            // 粗利
            this.uGrid_Details.Rows[14].Cells[COLUMN_GROSSMONY].Value = avSumGross.ToString("#,###,###,##0");

            // 移動入庫
            this.uGrid_Details.Rows[14].Cells[COLUMN_ARRINO].Value = avSumArriNo;
            this.uGrid_Details.Rows[14].Cells[COLUMN_ARRIMONY].Value = avSumArriMony.ToString("#,###,###,##0");

            // 移動出庫
            this.uGrid_Details.Rows[14].Cells[COLUMN_SHIPNO].Value = avSumShipNo;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SHIPMONY].Value = avSumShipMony.ToString("#,###,###,##0");

            #endregion

            // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
            DataTable dt = ((DataTable)this.uGrid_Details.DataSource);

            _saveGamenDataTable.Clone();
            for (i = 0; i < dt.Rows.Count; i++)
            {
                _saveGamenDataTable.Rows[i][COLUMN_SALESNO] = this.uGrid_Details.Rows[i].Cells[COLUMN_SALESNO].Value;
                _saveGamenDataTable.Rows[i][COLUMN_SALESCNT] = this.uGrid_Details.Rows[i].Cells[COLUMN_SALESCNT].Value;
                _saveGamenDataTable.Rows[i][COLUMN_SALESAVG] = this.uGrid_Details.Rows[i].Cells[COLUMN_SALESAVG].Value;
                _saveGamenDataTable.Rows[i][COLUMN_SALESMONY] = this.uGrid_Details.Rows[i].Cells[COLUMN_SALESMONY].Value;
                _saveGamenDataTable.Rows[i][COLUMN_SUPPLNO] = this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLNO].Value;
                _saveGamenDataTable.Rows[i][COLUMN_SUPPLCNT] = this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLCNT].Value;
                _saveGamenDataTable.Rows[i][COLUMN_SUPPLAVG] = this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLAVG].Value;
                _saveGamenDataTable.Rows[i][COLUMN_SUPPLMONY] = this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLMONY].Value;
                _saveGamenDataTable.Rows[i][COLUMN_GROSSMONY] = this.uGrid_Details.Rows[i].Cells[COLUMN_GROSSMONY].Value;
                _saveGamenDataTable.Rows[i][COLUMN_ARRINO] = this.uGrid_Details.Rows[i].Cells[COLUMN_ARRINO].Value;
                _saveGamenDataTable.Rows[i][COLUMN_ARRIMONY] = this.uGrid_Details.Rows[i].Cells[COLUMN_ARRIMONY].Value;
                _saveGamenDataTable.Rows[i][COLUMN_SHIPNO] = this.uGrid_Details.Rows[i].Cells[COLUMN_SHIPNO].Value;
                _saveGamenDataTable.Rows[i][COLUMN_SHIPMONY] = this.uGrid_Details.Rows[i].Cells[COLUMN_SHIPMONY].Value;
            }
            // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
        }

        /// <summary>
        /// 確定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 確定処理を行います。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/25</br>
        /// </remarks>
        private void Search()
        {
            // 画面情報チェック
            bool bStatus = CheckScreenInput();
            if (!bStatus)
            {
                return;
            }

            this.GetThisYearMonth();            //ADD 2009/03/16 不具合対応[12376][12379]

            // 検索条件格納
            StockHistoryDspSearchParam extrInfo;
            SetExtrInfo(out extrInfo);

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "抽出中";
            msgForm.Message = "在庫実績データの抽出中です。";

            int status;
            List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList;

            try
            {
                msgForm.Show();

                // --- ADD 2010/02/18 -------------------------------->>>>>
                this._resultData = new List<StockHistoryDspSearchResult>();
                // --- ADD 2010/02/18 --------------------------------<<<<<
                
                // 検索処理
                status = this._stockHistoryDspAcs.Search(extrInfo, out stockHistoryDspSearchResultList);
                if (status == 0)
                {
                    // --- ADD 2010/02/18 -------------------------------->>>>>
                    this._resultData = stockHistoryDspSearchResultList;
                    if (this._resultData.Count > 1)
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = true;
                    // --- ADD 2010/02/18 --------------------------------<<<<<

                    // 画面表示
                    CreateGrid(new List<StockHistoryDspSearchResult>());
                    ShipmentPartsDspResultToScreen(stockHistoryDspSearchResultList);
                    return;
                }
            }
            finally
            {
                msgForm.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "Search",
                                       "検索条件に該当する年間実績データは存在しません。",
                                       status,
                                       MessageBoxButtons.OK);

                        // グリッド情報クリア
                        CreateGrid(new List<StockHistoryDspSearchResult>());
                        return;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "Search",
                                       "確定処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        // グリッド情報クリア
                        CreateGrid(new List<StockHistoryDspSearchResult>());
                        return;
                    }
            }
        }

        /// <summary>
        /// 画面情報チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 画面情報をチェックします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                //品番
                if (this.tEdit_GoodsNo.DataText == "")
                {
                    errMsg = this.GoodsNoLabel.Text + "を入力してください";
                    this.tEdit_GoodsNo.Focus();
                    return (false);

                }
                //メーカーコード
                if (this.tNedit_GoodsMakerCd.Text == "")
                {
                    errMsg = this.GoodsMakerLabel.Text + "を入力してください";
                    this.tNedit_GoodsMakerCd.Focus();
                    return (false);
                }
                // 倉庫
                if (this.tEdit_WarehouseCode.DataText == "")
                {
                    errMsg = this.WarehouseLabel.Text + "を入力してください";
                    this.tEdit_WarehouseCode.Focus();
                    return (false);
                }
                // ---DEL 2009/06/25 不具合対応[13611] -------------------->>>>>
                //// 拠点
                //if (this.tEdit_SectionCodeAllowZero.DataText == "")
                //{
                //    errMsg = this.sectionLabel.Text + "を入力してください";
                //    this.tEdit_SectionCodeAllowZero.Focus();
                //    return (false);
                //}
                // ---DEL 2009/06/25 不具合対応[13611] --------------------<<<<<
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// 検索条件格納処理
        /// </summary>
        /// <param name="extrInfo">検索条件(明示的にoutパラメータで渡します)</param>
        /// <remarks>
        /// <br>Note        : 検索条件を格納します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void SetExtrInfo(out StockHistoryDspSearchParam extrInfo)
        {
            extrInfo = new StockHistoryDspSearchParam();

            // 企業コード
            extrInfo.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 品番
            extrInfo.GoodsNo = this.tEdit_GoodsNo.DataText.Trim();
            //メーカー
            extrInfo.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            // 開始倉庫コード
            extrInfo.WarehouseCode = this.tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0');
            // 終了年月
            extrInfo.EdAddUpYearMonth = this._thisYearMonth.AddMonths(-1).Year * 100 + this._thisYearMonth.AddMonths(-1).Month;
            // 開始年月
            extrInfo.StAddUpYearMonth = this._thisYearMonth.AddMonths(-12).Year * 100 + this._thisYearMonth.AddMonths(-12).Month;
            // 開始年月日
            extrInfo.StAddUpDate = this.stAddUpDate;
            // 終了年月日
            extrInfo.EdAddUpDate = this.edAddUpDate;
            // 拠点コード
            // ---DEL 2009/06/25 不具合対応[13611] ----------------------------->>>>>
            //if (this.tEdit_SectionCodeAllowZero.DataText == "00")
            //{
            //    extrInfo.SectionCode = "";
            //}
            //else
            //{
            //    extrInfo.SectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
            //}
            // ---DEL 2009/06/25 不具合対応[13611] -----------------------------<<<<<
            extrInfo.SectionCode = "";              //ADD 2009/06/25 不具合対応[13611]
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSMBLY_ID,                        // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSMBLY_ID, 		  　　		    // アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._stockHistoryDspAcs,			// エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }

        #endregion Private Methods


        #region Control Events

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォームがLoadされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void PMHNB04101UA_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = true;

        }

        /// <summary>
        /// ToolClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ツールバーがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        Close();
                        break;
                    }
                case "ButtonTool_Decision":
                    {
                        // 確定処理
                        // --- ADD 2010/03/15 -------------------------------->>>>>
                        this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                        // --- ADD 2010/03/15 --------------------------------<<<<<
                        Search();
                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // クリア処理
                        ClearScreen();
                        // --- ADD 2010/02/18 -------------------------------->>>>>
                        this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                        // --- ADD 2010/02/18 --------------------------------<<<<<
                        break;
                    }
                // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
                case "ButtonTool_ExtractText":
                    {
                        this.ExportIntoTextFile(false);
                        break;
                    }
                case "ButtonTool_ExtractExcel":
                    {
                        this.ExportIntoExcelData(true);
                        break;
                    }
                // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<
                //case "ButtonTool_Graph":
                //    {
                //        this.ViewGraph();
                //        this.utc_InventTab.Focus();
                //        break;
                //    }
                // --- ADD 2010/02/18 -------------------------------->>>>>
                case "ButtonTool_Graph":
                    {
                        this.ViewGraph();
                        this.utc_InventTab.Focus();
                        break;
                    }
                // --- ADD 2010/02/18 --------------------------------<<<<<
                case " ButtonTool_Setup":
                    {
                        if (this._userSetupFrm == null)
                            this._userSetupFrm = new PMZAI04101UC();

                        this._userSetupFrm.ShowDialog();
                        break;
                    }
            }
        }

        ///// <summary>
        ///// グラフの表示を行います
        ///// </summary>
        //private void ViewGraph()
        //{
        //    if ((this._resultData == null) || (this._resultData.MonthResult.Count == 0)) return;

        //    // 共通処理中画面生成
        //    SFCMN00299CA progressForm = new SFCMN00299CA();
        //    progressForm.DispCancelButton = false;
        //    progressForm.Title = "分析チャート作成中";
        //    progressForm.Message = "現在、分析チャート作成中です．．．";

        //    try
        //    {
        //        // 共通処理中画面表示
        //        progressForm.Show();

        //        // タブページに既にコントロールが有る場合はクリアする
        //        if (this.ultraTabPageControl2.Controls.Count > 0)
        //        {
        //            this.ultraTabPageControl2.Controls.Remove(this.ultraTabPageControl2.Controls[0]);
        //        }

        //        AnalysisChartViewForm viewForm = new AnalysisChartViewForm(this);
        //        viewForm.TopLevel = false;
        //        viewForm.FormBorderStyle = FormBorderStyle.None;
        //        viewForm.ShowMe(this._resultData);

        //        // タブページに分析チャートビューフォームを追加
        //        ultraTabPageControl2.Controls.Add(viewForm);
        //        viewForm.Dock = DockStyle.Fill;

        //        this.utc_InventTab.Tabs["GraphTab"].Visible = true;
        //        this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectNextTab);
        //    }
        //    catch (Exception ex)
        //    {
        //        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, DCHNB04180UA.programID, "タブ画面の初期化に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
        //    }
        //    finally
        //    {
        //        // 共通処理中画面終了
        //        progressForm.Close();
        //    }
        //}
        // ---ADD 2010/02/18 MANTIS対応[15001] -------------------->>>>>
        /// <summary>
        /// グラフの表示を行います
        /// </summary>
        private void ViewGraph()
        {
            if ((this._resultData == null) || (this._resultData.Count <= 1)) return;

            // 共通処理中画面生成
            SFCMN00299CA progressForm = new SFCMN00299CA();
            progressForm.DispCancelButton = false;
            progressForm.Title = "分析チャート作成中";
            progressForm.Message = "現在、分析チャート作成中です．．．";

            try
            {
                // 共通処理中画面表示
                progressForm.Show();

                // タブページに既にコントロールが有る場合はクリアする
                if (this.ultraTabPageControl2.Controls.Count > 0)
                {
                    this.ultraTabPageControl2.Controls.Remove(this.ultraTabPageControl2.Controls[0]);
                }

                AnalysisChartViewForm viewForm = new AnalysisChartViewForm(this);
                viewForm.TopLevel = false;
                viewForm.FormBorderStyle = FormBorderStyle.None;
                viewForm.ShowMe(this._resultData);

                // タブページに分析チャートビューフォームを追加
                ultraTabPageControl2.Controls.Add(viewForm);
                viewForm.Dock = DockStyle.Fill;

                this.utc_InventTab.Tabs["GraphTab"].Visible = true;
                this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectNextTab);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMZAI04101UA.programID, "タブ画面の初期化に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
            }
            finally
            {
                // 共通処理中画面終了
                progressForm.Close();
            }
        }
        // ---ADD 2010/02/18 MANTIS対応[15001] --------------------<<<<<

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : メーカーガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/25</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt makerUmnt;

                int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUmnt);
                if (status == 0)
                {
                    this.tNedit_GoodsMakerCd.DataText = makerUmnt.GoodsMakerCd.ToString();
                    this.tEdit_MakerName.DataText = makerUmnt.MakerName.Trim();

                    // 2010/04/30 Add >>>
                    if (tNedit_GoodsMakerCd.GetInt() != this._prevGoodsMakerCode)
                    {
                        this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                        CreateGrid(new List<StockHistoryDspSearchResult>());
                    }
                    // 2010/04/30 Add <<<
                    this._prevGoodsMakerCode = makerUmnt.GoodsMakerCd; // ADD 2009/03/23

                    // フォーカス設定
                    this.tEdit_WarehouseCode.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 倉庫ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/25</br>
        /// </remarks>
        private void warehouseGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Warehouse warehouse;

                int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
                if (status == 0)
                {
                    this.tEdit_WarehouseCode.DataText = warehouse.WarehouseCode.Trim();
                    this.tEdit_WarehouseName.DataText = warehouse.WarehouseName.Trim();
                    // 2010/04/30 Add >>>
                    if (_prevWarehouseCode.Equals(this.tEdit_WarehouseCode.Text.Trim().PadLeft(4, '0')) == false)
                    {
                        this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                        CreateGrid(new List<StockHistoryDspSearchResult>());
                    }

                    this._prevWarehouseCode = this.tEdit_WarehouseCode.Text.Trim().PadLeft(4, '0');
                    // 2010/04/30 Add <<<
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 倉庫ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/25</br>
        /// </remarks>
        private void sectionGuide_Button_Click(object sender, EventArgs e)
        {
            // ---DEL 2009/06/25 不具合対応[13611] ------------------------------>>>>>
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;

            //    SecInfoSet secInfoSet;

            //    int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
            //    if (status == 0)
            //    {
            //        this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
            //        //this.tEdit_SectionGuideNm.DataText = sectionInfoSet.SectionGuideNm.Trim();            //DEL 2099/04/06 不具合対応[13034]
            //        this.tEdit_SectionGuideNm.DataText = secInfoSet.SectionGuideNm.Trim();                  //ADD 2009/04/06 不具合対応[13034]

            //        this.tEdit_GoodsNo.Focus();           //ADD 2009/04/06 不具合対応[13034]
            //    }
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
            // ---DEL 2009/06/25 不具合対応[13611] ------------------------------<<<<<
        }

        /// <summary>
        /// ExpandedStateChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 展開ステータスが変更された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void Standard_UGroupBox_ExpandedStateChanged(object sender, EventArgs e)
        {
            Size topSize = new Size();

            topSize.Width = this.Form1_Top_Panel.Size.Width;
            topSize.Height = 20;

            if (this.Standard_UGroupBox.Expanded == true)
            {
                topSize.Height = 154;
            }
            else
            {
                topSize.Height = 20;
            }

            this.Form1_Top_Panel.Size = topSize;
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            int rowIndex = this.uGrid_Details.ActiveRow.Index;

          
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if (rowIndex == 0)
                        {
                            e.Handled = true;
                            this.tEdit_WarehouseCode.Focus();
                        }
                        else
                        {
                            e.Handled = true;
                            this.uGrid_Details.Rows[rowIndex - 1].Activate();
                            this.uGrid_Details.Rows[rowIndex - 1].Selected = true;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (rowIndex == this.uGrid_Details.Rows.Count - 1)
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = true;
                            this.uGrid_Details.Rows[rowIndex + 1].Activate();
                            this.uGrid_Details.Rows[rowIndex + 1].Selected = true;
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        // グリッド表示を右にスクロール
                        this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position + 40;
                        break;
                    }
                case Keys.Left:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        if (this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position != 0)
                        {
                            // グリッド表示を左にスクロール
                            this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position - 40;
                        }
                        break;
                    }
                case Keys.Home:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;

                        // 他キーとの組合せ無しの場合
                        if (e.Modifiers == Keys.None)
                        {
                            // グリッド表示を左先頭にスクロール
                            this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
                        }

                        // Controlキーとの組合せの場合
                        if (e.Modifiers == Keys.Control)
                        {
                            // 先頭行に移動
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                        }
                        break;
                    }
                case Keys.End:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;

                        // 他キーとの組合せ無しの場合
                        if (e.Modifiers == Keys.None)
                        {
                            // グリッド表示を左先頭にスクロール
                            this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Range;
                        }

                        // Controlキーとの組合せの場合
                        if (e.Modifiers == Keys.Control)
                        {
                            // 最終行に移動
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                        }
                        break;
                    }
            }
        }


        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドが非アクティブになった時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveCell = null;
            this.uGrid_Details.ActiveRow = null;

            for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
            {
                this.uGrid_Details.Rows[index].Selected = false;
            }
        }

        /// <summary>
        /// Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 一定間隔が過ぎる度に時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            //this.tEdit_SectionCodeAllowZero.Focus();          //DEL 2009/06/25 不具合対応[13611]
            this.tEdit_GoodsNo.Focus();                         //ADD 2009/06/25 不具合対応[13611]

            // グリッドのアクティブ行を削除
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : コントロールのフォーカスが変更された時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/10</br>
        /// <br>Update Note: 2010/09/21 gaofeng</br>
        /// <br>             Redmine#14876 テキスト出力対応</br>
        /// <br>Update Note: 2011/07/29 李占川</br>
        /// <br>             NSユーザー改良要望一覧連番984 選択している倉庫が表示されるよう修正する</br>
        /// <br>Update Note: 2013/01/17 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#33835 優先倉庫制御の対応</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            // 拠点取得
            if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero)
            {
                //if (this.tEdit_SectionCodeAllowZero.Text == "00" || this.tEdit_SectionCodeAllowZero.Text == "")       //DEL 2009/04/06 不具合対応[13034]
                // ---ADD 2009/04/06 不具合対応[13034] -------------------------->>>>>
                if (this.tEdit_SectionCodeAllowZero.Text == "00" ||
                    this.tEdit_SectionCodeAllowZero.Text == "0" ||
                    this.tEdit_SectionCodeAllowZero.Text == "")
                // ---ADD 2009/04/06 不具合対応[13034] --------------------------<<<<<
                {
                    this.tEdit_SectionCodeAllowZero.DataText = "00";
                    //this.tEdit_SectionGuideNm.DataText = "全社共通";      //DEL 2009/04/06 不具合対応[13034]
                    this.tEdit_SectionGuideNm.DataText = "全社";            //ADD 2009/04/06 不具合対応[13034]
                    if (e.ShiftKey == false)
                    {
                        if (e.Key == Keys.Enter || e.Key == Keys.Tab)  
                        {
                            e.NextCtrl = tEdit_GoodsNo;
                            e.NextCtrl.Select();
                        }
                    }
                }
                else
                {
                    sectionInfoSet = new SecInfoSet();
                    int status = _secInfoSetAcs.Read(out sectionInfoSet, this._enterpriseCode, this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0'));
                    if (status == 0 && sectionInfoSet.LogicalDeleteCode != 1)
                    {
                        this.tEdit_SectionGuideNm.DataText = sectionInfoSet.SectionGuideNm;
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Enter || e.Key == Keys.Tab)  
                            {
                                e.NextCtrl = tEdit_GoodsNo;
                                e.NextCtrl.Select();
                            }
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当するデータが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                        this.tEdit_SectionCodeAllowZero.Clear();
                        //this.tEdit_SectionGuideNm.Clear();            //DEL 2009/05/19 不具合対応[13034]
                        this.tEdit_SectionGuideNm.DataText = "全社";    //ADD 2009/05/19 不具合対応[13034]
                        e.NextCtrl = sectionGuide_Button;
                        e.NextCtrl.Select();
                    }
                }
            }

            // 品番取得
            if (e.PrevCtrl == this.tEdit_GoodsNo)
            {
                if (this.tEdit_GoodsNo.DataText != "")
                {
                    if (this.tEdit_GoodsNo.DataText.Trim() != this._prevGoodsNo.Trim()) // ADD 2009/03/23
                    {
                        MakerUMnt makerUMnt = null; //= new MakerUMnt();
                        GoodsCndtn goodsCndtn = new GoodsCndtn();
                        GoodsUnitData goodsUnitData = new GoodsUnitData();
                        string message;
                        List<GoodsUnitData> list = new List<GoodsUnitData>();
                        goodsCndtn.EnterpriseCode = this._enterpriseCode;
                        goodsCndtn.GoodsNo = this.tEdit_GoodsNo.DataText;
                        //goodsCndtn.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt(); // DEL 2009/03/16

                        // --- ADD 2011/07/29 ---------->>>>>
                        goodsCndtn.PriceApplyDate = DateTime.Today;
                        // --- ADD 2011/07/29  ----------<<<<<

                        // 2010/04/30 Add >>>
                        this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                        CreateGrid(new List<StockHistoryDspSearchResult>());
                        // 2010/04/30 Add <<<

                        this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out list, out message);

                        if (list.Count != 0)
                        {
                            goodsUnitData = (GoodsUnitData)list[0];
                            if (goodsUnitData.LogicalDeleteCode != 1)
                            {
                                this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo;
                                this.tEdit_GoodsName.DataText = goodsUnitData.GoodsName;
                                this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);

                                // --- ADD 2011/07/29 ---------->>>>>
                                this.tEdit_WarehouseCode.DataText = goodsUnitData.SelectedWarehouseCode;
                                //tEdit_WarehouseName.DataText = this._warehouseDic[tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0')].WarehouseName.Trim(); // DEL cheq 2013/01/17 Redmine#33835
                                // --- ADD cheq 2013/01/17 Redmine#33835---------->>>>>
                                if (this._warehouseDic.ContainsKey(tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0')))
                                {
                                    tEdit_WarehouseName.DataText = this._warehouseDic[tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0')].WarehouseName.Trim();
                                }
                                else
                                {
                                    this.tEdit_WarehouseCode.Clear();
                                    this.tEdit_WarehouseName.Clear();
                                }
                                // --- ADD cheq 2013/01/17 Redmine#33835----------<<<<<
                                // --- ADD 2011/07/29  ----------<<<<<

                                this._makerAcs.Read(out makerUMnt, this._enterpriseCode, goodsUnitData.GoodsMakerCd);
                                if (makerUMnt != null)
                                {
                                    if (makerUMnt.LogicalDeleteCode == 0) // ADD 2010/09/21
                                    { // ADD 2010/09/21
                                        this.tEdit_MakerName.DataText = makerUMnt.MakerName;

                                        blCode = goodsUnitData.BLGoodsCode;
                                        if (e.Key == Keys.Enter)
                                        {
                                            e.NextCtrl = tNedit_GoodsMakerCd;
                                        }

                                        // --- ADD 2009/03/23 -------------------------------->>>>>
                                        this._prevGoodsNo = goodsUnitData.GoodsNo.Trim();
                                        this._prevGoodsMakerCode = goodsUnitData.GoodsMakerCd;
                                        //this._prevWarehouseCode = goodsUnitData.SelectedWarehouseCode; // ADD 2011/07/29 // DEL cheq 2013/01/17 Redmine#33835
                                        // --- ADD cheq 2013/01/17 Redmine#33835---------->>>>>
                                        if (!string.IsNullOrEmpty(goodsUnitData.SelectedWarehouseCode))
                                        {
                                            this._prevWarehouseCode = goodsUnitData.SelectedWarehouseCode;
                                        }
                                        else
                                        {
                                            this._prevWarehouseCode = string.Empty;
                                        }
                                        // --- ADD cheq 2013/01/17 Redmine#33835----------<<<<<
                                        // --- ADD 2009/03/23 --------------------------------<<<<<
                                    // --- ADD 2010/09/21 ---------->>>>>
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する品番が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                        this.tNedit_GoodsMakerCd.Clear();
                                        this.tEdit_MakerName.Clear();
                                        this.tEdit_GoodsNo.Clear();
                                        this.tEdit_GoodsName.Clear();
                                        // --- ADD 2011/07/29 ---------->>>>>
                                        this.tEdit_WarehouseCode.Clear();
                                        this.tEdit_WarehouseName.Clear();
                                        // --- ADD 2011/07/29  ----------<<<<<
                                        e.NextCtrl = this.tEdit_GoodsNo;

                                        this._prevGoodsNo = string.Empty;
                                        this._prevGoodsMakerCode = 0;
                                        this._prevWarehouseCode = string.Empty; // ADD 2011/07/29
                                        return;
                                    }
                                    // --- ADD 2010/09/21 ----------<<<<<
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "該当する品番が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                                this.tNedit_GoodsMakerCd.Clear();
                                this.tEdit_MakerName.Clear();
                                this.tEdit_GoodsNo.Clear();
                                this.tEdit_GoodsName.Clear();
                                // --- ADD 2011/07/29 ---------->>>>>
                                this.tEdit_WarehouseCode.Clear();
                                this.tEdit_WarehouseName.Clear();
                                // --- ADD 2011/07/29  ----------<<<<<
                                e.NextCtrl = this.tEdit_GoodsNo;

                                // --- ADD 2009/03/23 -------------------------------->>>>>
                                this._prevGoodsNo = string.Empty;
                                this._prevGoodsMakerCode = 0;
                                this._prevWarehouseCode = string.Empty; // ADD 2011/07/29
                                // --- ADD 2009/03/23 --------------------------------<<<<<
                            }
                        }
                        else
                        {
                            TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "該当する品番が存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                            this.tNedit_GoodsMakerCd.Clear();
                            this.tEdit_MakerName.Clear();
                            this.tEdit_GoodsNo.Clear();
                            this.tEdit_GoodsName.Clear();
                            // --- ADD 2011/07/29 ---------->>>>>
                            this.tEdit_WarehouseCode.Clear();
                            this.tEdit_WarehouseName.Clear();
                            // --- ADD 2011/07/29  ----------<<<<<
                            e.NextCtrl = this.tEdit_GoodsNo;

                            // --- ADD 2009/03/23 -------------------------------->>>>>
                            this._prevGoodsNo = string.Empty;
                            this._prevGoodsMakerCode = 0;
                            this._prevWarehouseCode = string.Empty; // ADD 2011/07/29
                            // --- ADD 2009/03/23 --------------------------------<<<<<
                        }
                    }
                }
                else
                {
                    tEdit_GoodsName.Clear();
                }
            }


            // メーカーコード
            if (e.PrevCtrl == this.tNedit_GoodsMakerCd)
            {
                if (tNedit_GoodsMakerCd.GetInt() != 0)
                {
                    if (tNedit_GoodsMakerCd.GetInt() != this._prevGoodsMakerCode) // ADD 2009/03/23
                    {
                        MakerUMnt makerUMnt = new MakerUMnt();
                        GoodsCndtn goodsCndtn = new GoodsCndtn();
                        GoodsUnitData goodsUnitData = new GoodsUnitData();
                        string message;
                        List<GoodsUnitData> list = new List<GoodsUnitData>();
                        goodsCndtn.EnterpriseCode = this._enterpriseCode;
                        goodsCndtn.GoodsNo = this.tEdit_GoodsNo.DataText;
                        goodsCndtn.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

                        // 2010/04/30 Add >>>
                        this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                        CreateGrid(new List<StockHistoryDspSearchResult>());
                        // 2010/04/30 Add <<<
                        
                        if (tEdit_GoodsNo.DataText != "")
                        {
                            this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out list, out message);
                            if (list.Count != 0)
                            {
                                goodsUnitData = (GoodsUnitData)list[0];
                                if (goodsUnitData.LogicalDeleteCode != 1)
                                {
                                    this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo;
                                    this.tEdit_GoodsName.DataText = goodsUnitData.GoodsName;
                                    //this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd.ToString().Trim().PadLeft(4, '0'));
                                    this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);
                                    this._makerAcs.Read(out makerUMnt, this._enterpriseCode, goodsUnitData.GoodsMakerCd);
                                    if (makerUMnt != null)
                                    {
                                        this.tEdit_MakerName.DataText = makerUMnt.MakerName;
                                    }
                                    blCode = goodsUnitData.BLGoodsCode;
                                    if (e.ShiftKey == false)
                                    {
                                        if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                                        {
                                            e.NextCtrl = this.tEdit_WarehouseCode;
                                        }
                                    }

                                    // --- ADD 2009/03/23 -------------------------------->>>>>
                                    this._prevGoodsNo = goodsUnitData.GoodsNo.Trim();
                                    this._prevGoodsMakerCode = goodsUnitData.GoodsMakerCd;
                                    // --- ADD 2009/03/23 --------------------------------<<<<<
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "該当する品番が存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                    this.tNedit_GoodsMakerCd.Clear();
                                    this.tEdit_MakerName.Clear();
                                    this.tEdit_GoodsNo.Clear();
                                    this.tEdit_GoodsName.Clear();
                                    e.NextCtrl = this.tEdit_GoodsNo;

                                    // --- ADD 2009/03/23 -------------------------------->>>>>
                                    this._prevGoodsNo = string.Empty;
                                    this._prevGoodsMakerCode = 0;
                                    // --- ADD 2009/03/23 --------------------------------<<<<<
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "該当する品番が存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tNedit_GoodsMakerCd.Clear();
                                this.tEdit_MakerName.Clear();
                                this.tEdit_GoodsNo.Clear();
                                this.tEdit_GoodsName.Clear();
                                e.NextCtrl = this.tEdit_GoodsNo;

                                // --- ADD 2009/03/23 -------------------------------->>>>>
                                this._prevGoodsNo = string.Empty;
                                this._prevGoodsMakerCode = 0;
                                // --- ADD 2009/03/23 --------------------------------<<<<<
                            }
                        }
                        else
                        {
                            this._makerAcs.Read(out makerUMnt, this._enterpriseCode, tNedit_GoodsMakerCd.GetInt());

                            if (this.tNedit_GoodsMakerCd.GetInt() != 0)
                            {
                                if (makerUMnt != null && makerUMnt.LogicalDeleteCode != 1)
                                {
                                    this.tEdit_MakerName.DataText = makerUMnt.MakerName;

                                    this._prevGoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt(); // ADD 2009/03/23
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "該当するメーカーが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                    this.tNedit_GoodsMakerCd.Clear();
                                    this.tEdit_MakerName.Clear();
                                    e.NextCtrl = this.MakerGuide_Button;

                                    this._prevGoodsMakerCode = 0; // ADD 2009/03/23
                                }
                            }
                        }
                    }
                    // --- ADD 2009/03/23 -------------------------------->>>>>
                    else
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                            {
                                //e.NextCtrl = this.MakerGuide_Button;
                                e.NextCtrl = this.tEdit_WarehouseCode;
                            }
                        }
                    }
                    // --- ADD 2009/03/23 --------------------------------<<<<<
                }
                else
                {
                    if (e.ShiftKey == false)
                    {
                        if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                        {
                            e.NextCtrl = this.MakerGuide_Button;
                        }
                        tEdit_MakerName.Clear();
                    }

                    this._prevGoodsMakerCode = 0; // ADD 2009/03/23
                }
            }


            if (this.tEdit_WarehouseCode.Text == "")
            {
                if (e.PrevCtrl == this.tEdit_WarehouseCode)
                {
                    if (e.Key == Keys.Enter)
                    {
                        e.NextCtrl = this.tEdit_GoodsNo;
                    }
                }
            }
            if (e.ShiftKey == false)
            {
                if (e.PrevCtrl == this.MakerGuide_Button)
                {
                    if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                    {
                        e.NextCtrl = this.tEdit_WarehouseCode;
                    }
                }

                if (e.PrevCtrl == this.warehouseGuide_Button)
                {
                    if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                    {
                        //e.NextCtrl = this.tEdit_SectionCodeAllowZero;     //DEL 2009/06/25 不具合対応[13611]
                        e.NextCtrl = this.tEdit_GoodsNo;                    //ADD 2009/06/25 不具合対応[13611]
                    }
                }

                if (e.PrevCtrl == this.sectionGuide_Button)
                {
                    if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                    {
                        e.NextCtrl = this.tEdit_GoodsNo;
                    }
                }
            }

            // 倉庫コード
            if (e.PrevCtrl == this.tEdit_WarehouseCode)
            {
                WarehouseAcs warehouseAcs = new WarehouseAcs();
                Warehouse warehouse = new Warehouse();
                if (this.tEdit_WarehouseCode.Text != "")
                {
                    // 2010/04/30 Add >>>
                    if (_prevWarehouseCode.Equals(this.tEdit_WarehouseCode.Text.Trim().PadLeft(4, '0')) == false)
                    {
                        this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                        CreateGrid(new List<StockHistoryDspSearchResult>());
                    }
                    // 2010/04/30 Add <<<

                    if (this._warehouseDic.ContainsKey(tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0')))
                    {
                        tEdit_WarehouseName.DataText = this._warehouseDic[tEdit_WarehouseCode.DataText.Trim().PadLeft(4, '0')].WarehouseName.Trim();

                        if (this.tEdit_GoodsNo.DataText != "" && this.tEdit_WarehouseCode.DataText != "")
                        {
                            //SearchStockAcs _searchStockAcs = new SearchStockAcs();
                            //StockSearchPara searchPara = new StockSearchPara();
                            //Stock stock = new Stock();

                            //searchPara.EnterpriseCode = this._enterpriseCode;
                            //searchPara.WarehouseCode = tEdit_WarehouseCode.Text.Trim().PadLeft(4, '0');
                            //searchPara.GoodsMakerCd = tNedit_GoodsMakerCd.GetInt();
                            //searchPara.GoodsNo = tEdit_GoodsNo.Text;

                            //List<Stock> retStockList = new List<Stock>();
                            //string msg;

                            //_searchStockAcs.Search(searchPara, out retStockList, out msg);

                            //if (retStockList.Count != 0)
                            //{
                            //    stock = (Stock)retStockList[0];
                            //    if (stock.LogicalDeleteCode != 1)
                            //    {
                            //        this.tNedit_SupplierCd.SetInt(stock.SupplierCd);
                            //        this.tEdit_SupplierName.DataText = stock.SupplierSnm;
                            //        this.tDateEdit_LastSalesDate.SetDateTime(stock.LastSalesDate);
                            //        this.tDateEdit_LastStockDate.SetDateTime(stock.LastStockDate);
                            //        this.tDateEdit_CAddUpUpdExecDateSt.SetDateTime(stock.StockCreateDate);

                            //    }
                            //}
                        }
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                            {
                                //e.NextCtrl = this.tEdit_SectionCodeAllowZero;     //DEL 2009/06/25 不具合対応[13611]
                                e.NextCtrl = tEdit_GoodsNo;                         //ADD 2009/06/25 不具合対応[13611]
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "該当する倉庫が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                        this.tEdit_WarehouseCode.Clear();
                        this.tEdit_WarehouseName.Clear();
                        e.NextCtrl = this.warehouseGuide_Button;
                    }
                    this._prevWarehouseCode = this.tEdit_WarehouseCode.Text.Trim().PadLeft(4, '0');    // 2010/04/30 Add

                }
                else
                {
                    tEdit_WarehouseName.Clear();
                    if (e.ShiftKey == false)
                    {
                        if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                        {
                            e.NextCtrl = this.warehouseGuide_Button;
                        }
                    }
                    else
                    {
                        if (e.Key == Keys.Tab)
                            e.NextCtrl = this.tNedit_GoodsMakerCd;
                    }
                }
            }
            if (e.PrevCtrl != this.uGrid_Details && this.tEdit_GoodsNo.Text != "" && this.tNedit_GoodsMakerCd.Text != "" && this.tEdit_WarehouseCode.Text != "")
            {
                tNedit_SupplierCd.Clear();
                tEdit_SupplierName.Clear();
                tDateEdit_CAddUpUpdExecDateSt.Clear();
                tDateEdit_LastSalesDate.Clear();
                tDateEdit_LastStockDate.Clear();

                string msg;
                _goodsAcs.SearchInitial_GoodsMng(this._enterpriseCode, out msg);

                GoodsUnitData goodsUnitData = new GoodsUnitData();
                //goodsUnitData.SectionCode = this.tEdit_SectionCodeAllowZero.Text;     //DEL 2009/06/25 不具合対応[13611]
                goodsUnitData.SectionCode = "00";                                       //ADD 2009/06/25 不具合対応[13611]
                goodsUnitData.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                goodsUnitData.GoodsNo = this.tEdit_GoodsNo.Text;
                goodsUnitData.BLGoodsCode = blCode;

                _goodsAcs.GetGoodsMngInfo(ref goodsUnitData);
                tNedit_SupplierCd.SetInt(goodsUnitData.SupplierCd);

                Supplier supplier;

                int status = _supplierInfoAcs.Read(out supplier, this._enterpriseCode, goodsUnitData.SupplierCd);

                tEdit_SupplierName.Text = supplier.SupplierSnm;

                SearchStockAcs _searchStockAcs = new SearchStockAcs();
                StockSearchPara searchPara = new StockSearchPara();
                Stock stock = new Stock();

                searchPara.EnterpriseCode = this._enterpriseCode;
                searchPara.WarehouseCode = tEdit_WarehouseCode.Text.Trim().PadLeft(4, '0');
                searchPara.GoodsMakerCd = tNedit_GoodsMakerCd.GetInt();
                searchPara.GoodsNo = tEdit_GoodsNo.Text;

                List<Stock> retStockList = new List<Stock>();
                //string msg;

                _searchStockAcs.Search(searchPara, out retStockList, out msg);

                if (retStockList.Count != 0)
                {
                    stock = (Stock)retStockList[0];
                    if (stock.LogicalDeleteCode != 1)
                    {
                        this.tDateEdit_LastSalesDate.SetDateTime(stock.LastSalesDate);
                        this.tDateEdit_LastStockDate.SetDateTime(stock.LastStockDate);
                        this.tDateEdit_CAddUpUpdExecDateSt.SetDateTime(stock.StockCreateDate);

                    }
                }
            }
            if (this.tEdit_WarehouseCode.Text == "")
            {
                this.tNedit_SupplierCd.Clear();
                this.tEdit_SupplierName.Clear();
                this.tDateEdit_CAddUpUpdExecDateSt.Clear();
                this.tDateEdit_LastSalesDate.Clear();
                this.tDateEdit_LastStockDate.Clear();
            }
            if (this.tEdit_GoodsNo.Text == "")
            {
                this.tNedit_SupplierCd.Clear();
                this.tEdit_SupplierName.Clear();
                this.tDateEdit_CAddUpUpdExecDateSt.Clear();
                this.tDateEdit_LastSalesDate.Clear();
                this.tDateEdit_LastStockDate.Clear();
            }
            if (this.tNedit_GoodsMakerCd.Text == "")
            {
                this.tNedit_SupplierCd.Clear();
                this.tEdit_SupplierName.Clear();
                this.tDateEdit_CAddUpUpdExecDateSt.Clear();
                this.tDateEdit_LastSalesDate.Clear();
                this.tDateEdit_LastStockDate.Clear();
            }
            if (e.PrevCtrl == this.tEdit_GoodsNo)
            {
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                }
            }
            if (e.PrevCtrl == this.tEdit_WarehouseCode)
            {
                if (e.Key == Keys.Up)
                {
                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                }
            }

        // グリッド
            if (e.PrevCtrl == this.uGrid_Details)
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        if (this.uGrid_Details.ActiveRow == null)
                        {
                            e.NextCtrl = null;
                            this.uGrid_Details.Rows[0].Activate();
                            this.uGrid_Details.Rows[0].Selected = true;
                        }
                        else
                        {
                            int rowIndex = this.uGrid_Details.ActiveRow.Index;
                            if (rowIndex != this.uGrid_Details.Rows.Count - 1)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Rows[rowIndex + 1].Activate();
                                this.uGrid_Details.Rows[rowIndex + 1].Selected = true;
                            }
                        }
                    }
                    return;
                }
                else
                {
                    if (e.Key == Keys.Tab)
                    {
                        if (this.uGrid_Details.ActiveRow == null)
                        {
                            e.NextCtrl = null;
                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Activate();
                            this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Selected = true;
                        }
                        else
                        {
                            int rowIndex = this.uGrid_Details.ActiveRow.Index;
                            if (rowIndex != 0)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Rows[rowIndex - 1].Activate();
                                this.uGrid_Details.Rows[rowIndex - 1].Selected = true;
                            }
                            else
                            {
                                e.NextCtrl = tEdit_WarehouseCode;
                            }
                        }
                    }
                    return;
                }
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            // グリッド
            if (e.NextCtrl == this.uGrid_Details)
            {
                if (e.ShiftKey == false)
                {
                    this.uGrid_Details.Rows[0].Activate();
                    this.uGrid_Details.Rows[0].Selected = true;
                    return;
                }
                else
                {
                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Activate();
                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Selected = true;
                }
            }
        }

        #endregion Control Events

        private void Standard_UGroupBox_ExpandedStateChanging(object sender, CancelEventArgs e)
        {

        }

        private void ultraLabel3_Click(object sender, EventArgs e)
        {

        }

        private void tDateEdit_CAddUpUpdExecDateSt_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tDateEdit_CAddUpUpdExecDateSt_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tDateEdit_CAddUpUpdExecDateSt_Paint_2(object sender, PaintEventArgs e)
        {

        }


        private void panel_Detail_Paint(object sender, PaintEventArgs e)
        {

        }
        private void uGrid_Details_AfterColRegionSize(object sender, ColScrollRegionEventArgs e)
        {


        }

        private void panel_Detail_Scroll(object sender, ScrollEventArgs e)
        {

        }

        // ---ADD 2010/07/20 テキスト出力対応 -------------------->>>>>
        /// <summary>
        /// EXCELデータ出力
        /// </summary>
        /// <remarks>
        /// <br>Note        : EXCELデータ出力処理します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/23</br>
        /// <br>Update Note: 2010/08/19 chenyd</br>
        /// <br>            ・障害ID:13055 テキスト出力対応</br>
        /// <br>Update Note: 2010/10/09 曹文傑</br>
        /// <br>            ・障害ID:15882 テキスト出力対応</br>
        /// </remarks>
        private void ExportIntoExcelData(bool excelFlg)
        {
            this._extractSetupFrm = new PMZAI04101UE();

            // 出力形式
            this._extractSetupFrm.ExcelFlg = excelFlg;

            this._extractSetupFrm.OutputData += new PMZAI04101UE.OutputDataEvent(this.outputExcelData); // ADD 2010/10/09

            this._extractSetupFrm.ShowDialog();

            // --- DEL 2010/10/09 ---------->>>>>
            //if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            //{
            //    return;
            //}
            //int count = 0; // ADD 2010/08/19 障害ID:13055対応
            //SFCMN00299CA processingDialog = new SFCMN00299CA();
            //try
            //{
            //    processingDialog.Title = "抽出処理";
            //    processingDialog.Message = "現在、データ抽出中です。";
            //    processingDialog.DispCancelButton = false;
            //    processingDialog.Show((Form)this.Parent);

            //    // 検索条件格納
            //    StockHistoryDspSearchParam extrInfo;
            //    SetExtrInfo(out extrInfo);
            //    extrInfo.WarehouseCodeList = this._extractSetupFrm.WarehouseCodeList;
            //    extrInfo.WarehouseShelfNoList = this._extractSetupFrm.WarehouseShelfNoList;
            //    extrInfo.MakerCodeList = this._extractSetupFrm.MakerCodeList;
            //    extrInfo.BlGoodsCodeList = this._extractSetupFrm.BlGoodsCodeList;
            //    extrInfo.GoodsNoList = this._extractSetupFrm.GoodsNoList;

            //    List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList;

            //    this._stockHistoryDspAcs.SearchAll(extrInfo, out stockHistoryDspSearchResultList);

            //    this._resultData = stockHistoryDspSearchResultList;
            //    // --- ADD 2010/08/19 障害ID:13055対応--------------------------->>>>>
            //    for (int i = 0; i < stockHistoryDspSearchResultList.Count; i++)
            //    {
            //        if (stockHistoryDspSearchResultList[i].SearchDiv != 0)
            //        {
            //            count++;
            //        }
            //    }
            //    // --- ADD 2010/08/19 障害ID:13055対応---------------------------<<<<<
            //}
            //finally
            //{
            //    processingDialog.Dispose();
            //}
            ////if (this._resultData == null || this._resultData.Count == 0) // DEL 2010/08/19 障害ID:13055対応
            ////if (this._resultData == null || this._resultData.Count == 0 || count == 0) // ADD 2010/08/19 障害ID:13055対応
            //if (this._resultData == null || this._resultData.Count == 0) // ADD 2010/09/15
            //{
            //    this.InitializeGridColumns(false);

            //    ReGridBinding();

            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        "条件に合致するデータが存在しません。",
            //        -1,
            //        MessageBoxButtons.OK);
            //    return;
            //}

            //this.InitializeGridColumns(true);

            //try
            //{
            //    if (this.ultraGridExcelExporter1.Export(this.uGrid_Details, this._extractSetupFrm.SettingFileName) != null)
            //    {
            //        this.InitializeGridColumns(false);

            //        ReGridBinding();

            //        // 成功
            //        TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_INFO,
            //            this.Name,
            //            "EXCELデータを出力しました。",
            //            -1,
            //            MessageBoxButtons.OK);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.InitializeGridColumns(false);

            //    ReGridBinding();

            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        ex.Message,
            //        -1,
            //        MessageBoxButtons.OK);
            //}
            // --- DEL 2010/10/09 ----------<<<<<
        }

        /// <summary>
        /// テキスト出力処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : テキスト出力処理します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/23</br>
        /// <br>Update Note: 2010/08/19 chenyd</br>
        /// <br>            ・障害ID:13055 テキスト出力対応</br>
        /// <br>Update Note: 2010/09/08 朱 猛</br>
        /// <br>            ・障害ID:14444 テキスト出力対応</br>
        /// <br>Update Note: 2010/10/09 曹文傑</br>
        /// <br>            ・障害ID:15882 テキスト出力対応</br>
        /// </remarks>
        private void ExportIntoTextFile(bool excelFlg)
        {
            this._extractSetupFrm = new PMZAI04101UE();

            // 出力形式
            this._extractSetupFrm.ExcelFlg = excelFlg;

            this._extractSetupFrm.OutputData += new PMZAI04101UE.OutputDataEvent(this.outputTextData); // ADD 2010/10/09

            this._extractSetupFrm.ShowDialog();

            // --- DEL 2010/10/09 ---------->>>>>
            //if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            //{
            //    return;
            //}
            //int count = 0; //ADD 2010/08/19 障害ID:13055対応
            //SFCMN00299CA processingDialog = new SFCMN00299CA();
            //try
            //{
            //    processingDialog.Title = "抽出処理";
            //    processingDialog.Message = "現在、データ抽出中です。";
            //    processingDialog.DispCancelButton = false;
            //    processingDialog.Show((Form)this.Parent);

            //    // 検索条件格納
            //    StockHistoryDspSearchParam extrInfo;
            //    SetExtrInfo(out extrInfo);
            //    extrInfo.WarehouseCodeList = this._extractSetupFrm.WarehouseCodeList;
            //    extrInfo.WarehouseShelfNoList = this._extractSetupFrm.WarehouseShelfNoList;
            //    extrInfo.MakerCodeList = this._extractSetupFrm.MakerCodeList;
            //    extrInfo.BlGoodsCodeList = this._extractSetupFrm.BlGoodsCodeList;
            //    extrInfo.GoodsNoList = this._extractSetupFrm.GoodsNoList;

            //    List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList;

            //    this._stockHistoryDspAcs.SearchAll(extrInfo, out stockHistoryDspSearchResultList);

            //    this._resultData = stockHistoryDspSearchResultList;
            //    // --- ADD 2010/08/19 障害ID:13055対応--------------------------->>>>>
            //    for (int i = 0; i < stockHistoryDspSearchResultList.Count; i++)
            //    {
            //        if (stockHistoryDspSearchResultList[i].SearchDiv != 0)
            //        {
            //            count++;
            //        }
            //    }
            //    // --- ADD 2010/08/19 障害ID:13055対応--------------------------->>>>>
            //}
            //finally
            //{
            //    processingDialog.Dispose();
            //}
            ////if (this._resultData == null || this._resultData.Count == 0) //DEL 2010/08/19 障害ID:13055対応
            ////if (this._resultData == null || this._resultData.Count == 0 || count == 0) // ADD 2010/08/19 障害ID:13055対応
            //if (this._resultData == null || this._resultData.Count == 0) // ADD 2010/09/15
            //{
            //    this.InitializeGridColumns(false);

            //    ReGridBinding();

            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        "条件に合致するデータが存在しません。",
            //        -1,
            //        MessageBoxButtons.OK);
            //    return;
            //}

            //this.InitializeGridColumns(true);

            //String typeStr = string.Empty;
            //Char typeChar = new char();
            //Byte typeByte = new byte();
            //DateTime typeDate = new DateTime();
            //Int16 typeInt16 = new short();
            //Int32 typeInt32 = new int();
            //Int64 typeInt64 = new long();
            //Single typeSingle = new float();
            //Double typeDouble = new double();
            //Decimal typeDecimal = new decimal();
            //FormattedTextWriter tw = new FormattedTextWriter();

            //Dictionary<int, string> sortList = new Dictionary<int, string>();
            //List<String> schemeList = new List<string>();

            //DataTable targetTable = this._gridBoundDataTable;

            //for (int i = 0; i <= 12; i++)
            //{
            //    if (i == 0)
            //    {
            //        targetTable.Columns[COLUMN_SALESNO + i.ToString()].Caption = "売上・数量（当月）";
            //        targetTable.Columns[COLUMN_SALESCNT + i.ToString()].Caption = "売上・回数（当月）";
            //        targetTable.Columns[COLUMN_SALESMONY + i.ToString()].Caption = "売上・金額（当月）";
            //        targetTable.Columns[COLUMN_SUPPLNO + i.ToString()].Caption = "仕入・数量（当月）";
            //        targetTable.Columns[COLUMN_SUPPLCNT + i.ToString()].Caption = "仕入・回数（当月）";
            //        targetTable.Columns[COLUMN_SUPPLMONY + i.ToString()].Caption = "仕入・金額（当月）";
            //        targetTable.Columns[COLUMN_GROSSMONY + i.ToString()].Caption = "粗利数（当月）";
            //        targetTable.Columns[COLUMN_ARRINO + i.ToString()].Caption = "移動入庫・数量（当月）";
            //        targetTable.Columns[COLUMN_ARRIMONY + i.ToString()].Caption = "移動入庫・金額（当月）";
            //        targetTable.Columns[COLUMN_SHIPNO + i.ToString()].Caption = "移動出庫・数量（当月）";
            //        targetTable.Columns[COLUMN_SHIPMONY + i.ToString()].Caption = "移動出庫・金額（当月）";
            //    }
            //    else
            //    {
            //        targetTable.Columns[COLUMN_SALESNO + i.ToString()].Caption = "売上・数量（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
            //        targetTable.Columns[COLUMN_SALESCNT + i.ToString()].Caption = "売上・回数（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
            //        targetTable.Columns[COLUMN_SALESMONY + i.ToString()].Caption = "売上・金額（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
            //        targetTable.Columns[COLUMN_SUPPLNO + i.ToString()].Caption = "仕入・数量（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
            //        targetTable.Columns[COLUMN_SUPPLCNT + i.ToString()].Caption = "仕入・回数（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
            //        targetTable.Columns[COLUMN_SUPPLMONY + i.ToString()].Caption = "仕入・金額（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
            //        targetTable.Columns[COLUMN_GROSSMONY + i.ToString()].Caption = "粗利数（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
            //        targetTable.Columns[COLUMN_ARRINO + i.ToString()].Caption = "移動入庫・数量（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
            //        targetTable.Columns[COLUMN_ARRIMONY + i.ToString()].Caption = "移動入庫・金額（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
            //        targetTable.Columns[COLUMN_SHIPNO + i.ToString()].Caption = "移動出庫・数量（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
            //        targetTable.Columns[COLUMN_SHIPMONY + i.ToString()].Caption = "移動出庫・金額（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
            //    }
            //}

            //// ---------------------- UPD  2010/09/08 --------------------------------->>>>>
            ////targetTable.Columns[COLUMN_WAREHOUSECODE].Caption = "倉庫コード";
            //targetTable.Columns[COLUMN_WAREHOUSECODE].Caption = "倉庫";
            //// ---------------------- UPD  2010/09/08 ---------------------------------<<<<<
            //targetTable.Columns[COLUMN_GOODSNO].Caption = "品番";
            //// ---------------------- UPD  2010/09/08 --------------------------------->>>>>
            ////targetTable.Columns[COLUMN_MAKERCD].Caption = "メーカコード";
            //targetTable.Columns[COLUMN_MAKERCD].Caption = "メーカー";
            //// ---------------------- UPD  2010/09/08 ---------------------------------<<<<<
            //targetTable.Columns[COLUMN_GOODSNAME].Caption = "品名";
            //targetTable.Columns[COLUMN_WAREHOUSESHELFNO].Caption = "棚番";
            //targetTable.Columns[COLUMN_BLGOODSCODE].Caption = "BLコード";
            //targetTable.Columns[COLUMN_ZAIKUYMD].Caption = "在庫登録日";
            //targetTable.Columns[COLUMN_SALESYMDED].Caption = "最終売上日";
            //targetTable.Columns[COLUMN_SUPPLIERYMDED].Caption = "最終仕入日";
            
            //Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;
            //int dispOrder;
            //string columnName;
            //for (int i = 0; i < Columns.Count; i++)
            //{
            //    if (Columns[i].Hidden == false)
            //    {
            //        dispOrder = Columns[i].Header.VisiblePosition;
            //        columnName = targetTable.Columns[Columns[i].Index].ColumnName;
            //        sortList.Add(dispOrder, columnName);
            //    }
            //}

            //List<int> keyList = new List<int>(sortList.Keys);
            //keyList.Sort();

            //foreach (int key in keyList)
            //{
            //    schemeList.Add(sortList[key]);
            //}

            //// 出力項目名
            //tw.SchemeList = schemeList;

            //// データソース
            //tw.DataSource = this.uGrid_Details.DataSource;

            //# region [フォーマットリスト]
            //Dictionary<string, string> formatList = new Dictionary<string, string>();
            //foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.uGrid_Details.DisplayLayout.Bands[0].Columns)
            //{
            //    formatList.Add(col.Key, col.Format);
            //}
            //tw.FormatList = formatList;

            //#endregion // フォーマットリスト

            //#region オプションセット
            //// ファイル名
            //tw.OutputFileName = this._extractSetupFrm.SettingFileName;
            //// 区切り文字
            //tw.Splitter = ",";
            //// 項目括り文字
            //tw.Encloser = "\"";
            //// 固定幅
            //tw.FixedLength = false;
            //// タイトル行出力
            //tw.CaptionOutput = true;
            //// 項目括り適用
            //List<Type> enclosingList = new List<Type>();
            //enclosingList.Add(typeInt16.GetType());
            //enclosingList.Add(typeInt32.GetType());
            //enclosingList.Add(typeInt64.GetType());
            //enclosingList.Add(typeDouble.GetType());
            //enclosingList.Add(typeDecimal.GetType());
            //enclosingList.Add(typeSingle.GetType());
            //enclosingList.Add(typeStr.GetType());
            //enclosingList.Add(typeChar.GetType());
            //enclosingList.Add(typeByte.GetType());
            //enclosingList.Add(typeDate.GetType());
            //tw.EnclosingTypeList = enclosingList;
            //#endregion

            //int outputCount = 0;
            //int status = tw.TextOut(out outputCount);

            //this.InitializeGridColumns(false);

            //ReGridBinding();

            //if (status == 9)// 異常終了
            //{
            //    // 出力失敗
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
            //        "ファイルへの出力に失敗しました。", -1, MessageBoxButtons.OK);
            //}
            //else
            //{
            //    // 出力成功
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
            //        outputCount.ToString() + "行のデータをファイルへ出力しました。", -1, MessageBoxButtons.OK);
            //}
            // --- DEL 2010/10/09 ----------<<<<<
        }

        // --- ADD 2010/10/09 ---------->>>>>
        /// <summary>
        /// Excel出力処理
        /// </summary>
        /// <returns>True:正常; False:異常</returns>
        private bool outputExcelData()
        {
            _excOrtxtDiv = false;// ADD 2011/03/23
            if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            {
                return true;
            }
            int count = 0; // ADD 2010/08/19 障害ID:13055対応
            SFCMN00299CA processingDialog = new SFCMN00299CA();
            try
            {
                processingDialog.Title = "抽出処理";
                processingDialog.Message = "現在、データ抽出中です。";
                processingDialog.DispCancelButton = false;
                processingDialog.Show((Form)this.Parent);

                // 検索条件格納
                StockHistoryDspSearchParam extrInfo;
                SetExtrInfo(out extrInfo);
                extrInfo.WarehouseCodeList = this._extractSetupFrm.WarehouseCodeList;
                extrInfo.WarehouseShelfNoList = this._extractSetupFrm.WarehouseShelfNoList;
                extrInfo.MakerCodeList = this._extractSetupFrm.MakerCodeList;
                extrInfo.BlGoodsCodeList = this._extractSetupFrm.BlGoodsCodeList;
                extrInfo.GoodsNoList = this._extractSetupFrm.GoodsNoList;

                List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList;

                this._stockHistoryDspAcs.SearchAll(extrInfo, out stockHistoryDspSearchResultList);

                this._resultData = stockHistoryDspSearchResultList;
                // --- ADD 2010/08/19 障害ID:13055対応--------------------------->>>>>
                for (int i = 0; i < stockHistoryDspSearchResultList.Count; i++)
                {
                    if (stockHistoryDspSearchResultList[i].SearchDiv != 0)
                    {
                        count++;
                    }
                }
                // --- ADD 2010/08/19 障害ID:13055対応---------------------------<<<<<
            }
            finally
            {
                processingDialog.Dispose();
            }
            //if (this._resultData == null || this._resultData.Count == 0) // DEL 2010/08/19 障害ID:13055対応
            //if (this._resultData == null || this._resultData.Count == 0 || count == 0) // ADD 2010/08/19 障害ID:13055対応
            if (this._resultData == null || this._resultData.Count == 0) // ADD 2010/09/15
            {
                this.InitializeGridColumns(false);

                ReGridBinding();

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "条件に合致するデータが存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }

            this.InitializeGridColumns(true);

            // --- ADD 2010/10/09 --------------------------->>>>>
            if (this.uGrid_Details.Rows.Count == 0)
            {
                this.InitializeGridColumns(false);
                ReGridBinding();

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "条件に合致するデータが存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }
            // --- ADD 2010/10/09 ---------------------------<<<<<

            try
            {
                if (this.ultraGridExcelExporter1.Export(this.uGrid_Details, this._extractSetupFrm.SettingFileName) != null)
                {
                    this.InitializeGridColumns(false);

                    ReGridBinding();

                    // 成功
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "EXCELデータを出力しました。",
                        -1,
                        MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                this.InitializeGridColumns(false);

                ReGridBinding();

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// テキスト出力処理
        /// </summary>
        /// <returns>True:正常; False:異常</returns>
        /// <br>Update Note : 2011/02/16 liyp</br>
        /// <br>            ・テキスト出力対応</br>
        private bool outputTextData()
        {
            _excOrtxtDiv = true; // ADD 2011/02/16
            if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            {
                return true;
            }
            int count = 0; //ADD 2010/08/19 障害ID:13055対応
            SFCMN00299CA processingDialog = new SFCMN00299CA();
            try
            {
                processingDialog.Title = "抽出処理";
                processingDialog.Message = "現在、データ抽出中です。";
                processingDialog.DispCancelButton = false;
                processingDialog.Show((Form)this.Parent);

                // 検索条件格納
                StockHistoryDspSearchParam extrInfo;
                SetExtrInfo(out extrInfo);
                extrInfo.WarehouseCodeList = this._extractSetupFrm.WarehouseCodeList;
                extrInfo.WarehouseShelfNoList = this._extractSetupFrm.WarehouseShelfNoList;
                extrInfo.MakerCodeList = this._extractSetupFrm.MakerCodeList;
                extrInfo.BlGoodsCodeList = this._extractSetupFrm.BlGoodsCodeList;
                extrInfo.GoodsNoList = this._extractSetupFrm.GoodsNoList;

                List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList;

                this._stockHistoryDspAcs.SearchAll(extrInfo, out stockHistoryDspSearchResultList);

                this._resultData = stockHistoryDspSearchResultList;
                // --- ADD 2010/08/19 障害ID:13055対応--------------------------->>>>>
                for (int i = 0; i < stockHistoryDspSearchResultList.Count; i++)
                {
                    if (stockHistoryDspSearchResultList[i].SearchDiv != 0)
                    {
                        count++;
                    }
                }
                // --- ADD 2010/08/19 障害ID:13055対応--------------------------->>>>>
            }
            finally
            {
                processingDialog.Dispose();
            }
            //if (this._resultData == null || this._resultData.Count == 0) //DEL 2010/08/19 障害ID:13055対応
            //if (this._resultData == null || this._resultData.Count == 0 || count == 0) // ADD 2010/08/19 障害ID:13055対応
            if (this._resultData == null || this._resultData.Count == 0) // ADD 2010/09/15
            {
                this.InitializeGridColumns(false);
                ReGridBinding();

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "条件に合致するデータが存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }

            this.InitializeGridColumns(true);

            // --- ADD 2010/10/09 --------------------------->>>>>
            if (this.uGrid_Details.Rows.Count == 0)
            {
                this.InitializeGridColumns(false);

                ReGridBinding();

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "条件に合致するデータが存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }
            // --- ADD 2010/10/09 ---------------------------<<<<<


            String typeStr = string.Empty;
            Char typeChar = new char();
            Byte typeByte = new byte();
            DateTime typeDate = new DateTime();
            Int16 typeInt16 = new short();
            Int32 typeInt32 = new int();
            Int64 typeInt64 = new long();
            Single typeSingle = new float();
            Double typeDouble = new double();
            Decimal typeDecimal = new decimal();
            FormattedTextWriter tw = new FormattedTextWriter();

            Dictionary<int, string> sortList = new Dictionary<int, string>();
            List<String> schemeList = new List<string>();

            DataTable targetTable = this._gridBoundDataTable;

            for (int i = 0; i <= 12; i++)
            {
                if (i == 0)
                {
                    targetTable.Columns[COLUMN_SALESNO + i.ToString()].Caption = "売上・数量（当月）";
                    targetTable.Columns[COLUMN_SALESCNT + i.ToString()].Caption = "売上・回数（当月）";
                    targetTable.Columns[COLUMN_SALESMONY + i.ToString()].Caption = "売上・金額（当月）";
                    targetTable.Columns[COLUMN_SUPPLNO + i.ToString()].Caption = "仕入・数量（当月）";
                    targetTable.Columns[COLUMN_SUPPLCNT + i.ToString()].Caption = "仕入・回数（当月）";
                    targetTable.Columns[COLUMN_SUPPLMONY + i.ToString()].Caption = "仕入・金額（当月）";
                    targetTable.Columns[COLUMN_GROSSMONY + i.ToString()].Caption = "粗利数（当月）";
                    targetTable.Columns[COLUMN_ARRINO + i.ToString()].Caption = "移動入庫・数量（当月）";
                    targetTable.Columns[COLUMN_ARRIMONY + i.ToString()].Caption = "移動入庫・金額（当月）";
                    targetTable.Columns[COLUMN_SHIPNO + i.ToString()].Caption = "移動出庫・数量（当月）";
                    targetTable.Columns[COLUMN_SHIPMONY + i.ToString()].Caption = "移動出庫・金額（当月）";
                }
                else
                {
                    targetTable.Columns[COLUMN_SALESNO + i.ToString()].Caption = "売上・数量（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                    targetTable.Columns[COLUMN_SALESCNT + i.ToString()].Caption = "売上・回数（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                    targetTable.Columns[COLUMN_SALESMONY + i.ToString()].Caption = "売上・金額（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                    targetTable.Columns[COLUMN_SUPPLNO + i.ToString()].Caption = "仕入・数量（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                    targetTable.Columns[COLUMN_SUPPLCNT + i.ToString()].Caption = "仕入・回数（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                    targetTable.Columns[COLUMN_SUPPLMONY + i.ToString()].Caption = "仕入・金額（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                    targetTable.Columns[COLUMN_GROSSMONY + i.ToString()].Caption = "粗利数（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                    targetTable.Columns[COLUMN_ARRINO + i.ToString()].Caption = "移動入庫・数量（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                    targetTable.Columns[COLUMN_ARRIMONY + i.ToString()].Caption = "移動入庫・金額（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                    targetTable.Columns[COLUMN_SHIPNO + i.ToString()].Caption = "移動出庫・数量（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                    targetTable.Columns[COLUMN_SHIPMONY + i.ToString()].Caption = "移動出庫・金額（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                }
            }

            // ---------------------- UPD  2010/09/08 --------------------------------->>>>>
            //targetTable.Columns[COLUMN_WAREHOUSECODE].Caption = "倉庫コード";
            targetTable.Columns[COLUMN_WAREHOUSECODE].Caption = "倉庫";
            // ---------------------- UPD  2010/09/08 ---------------------------------<<<<<
            targetTable.Columns[COLUMN_GOODSNO].Caption = "品番";
            // ---------------------- UPD  2010/09/08 --------------------------------->>>>>
            //targetTable.Columns[COLUMN_MAKERCD].Caption = "メーカコード";
            targetTable.Columns[COLUMN_MAKERCD].Caption = "メーカー";
            // ---------------------- UPD  2010/09/08 ---------------------------------<<<<<
            targetTable.Columns[COLUMN_GOODSNAME].Caption = "品名";
            targetTable.Columns[COLUMN_WAREHOUSESHELFNO].Caption = "棚番";
            targetTable.Columns[COLUMN_BLGOODSCODE].Caption = "BLコード";
            targetTable.Columns[COLUMN_ZAIKUYMD].Caption = "在庫登録日";
            targetTable.Columns[COLUMN_SALESYMDED].Caption = "最終売上日";
            targetTable.Columns[COLUMN_SUPPLIERYMDED].Caption = "最終仕入日";

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;
            int dispOrder;
            string columnName;
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i].Hidden == false)
                {
                    dispOrder = Columns[i].Header.VisiblePosition;
                    columnName = targetTable.Columns[Columns[i].Index].ColumnName;
                    sortList.Add(dispOrder, columnName);
                }
            }

            List<int> keyList = new List<int>(sortList.Keys);
            keyList.Sort();

            foreach (int key in keyList)
            {
                schemeList.Add(sortList[key]);
            }

            // 出力項目名
            tw.SchemeList = schemeList;

            // データソース
            tw.DataSource = this.uGrid_Details.DataSource;

            # region [フォーマットリスト]
            Dictionary<string, string> formatList = new Dictionary<string, string>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.uGrid_Details.DisplayLayout.Bands[0].Columns)
            {
                formatList.Add(col.Key, col.Format);
            }
            tw.FormatList = formatList;

            #endregion // フォーマットリスト

            #region オプションセット
            // ファイル名
            tw.OutputFileName = this._extractSetupFrm.SettingFileName;
            // 区切り文字
            tw.Splitter = ",";
            // 項目括り文字
            tw.Encloser = "\"";
            // 固定幅
            tw.FixedLength = false;
            // タイトル行出力
            tw.CaptionOutput = true;
            // 項目括り適用
            List<Type> enclosingList = new List<Type>();
            enclosingList.Add(typeInt16.GetType());
            enclosingList.Add(typeInt32.GetType());
            enclosingList.Add(typeInt64.GetType());
            enclosingList.Add(typeDouble.GetType());
            enclosingList.Add(typeDecimal.GetType());
            enclosingList.Add(typeSingle.GetType());
            enclosingList.Add(typeStr.GetType());
            enclosingList.Add(typeChar.GetType());
            enclosingList.Add(typeByte.GetType());
            enclosingList.Add(typeDate.GetType());
            tw.EnclosingTypeList = enclosingList;
            #endregion

            int outputCount = 0;
            int status = tw.TextOut(out outputCount);

            this.InitializeGridColumns(false);

            ReGridBinding();
            if (status == 9)// 異常終了
            {
                // 出力失敗
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "ファイルへの出力に失敗しました。", -1, MessageBoxButtons.OK);
                return false;
            }
            else
            {
                // 出力成功
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    outputCount.ToString() + "行のデータをファイルへ出力しました。", -1, MessageBoxButtons.OK);
                return true;
            }
        }
        // --- ADD 2010/10/09 ----------<<<<<

        /// <summary>
        /// 画面再検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面再検索処理します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/23</br>
        /// </remarks>
        private void ReGridBinding()
        {
            this.SetGridLayout();

            DataTable dtBounding = _saveGamenDataTable.Copy();

            this.uGrid_Details.DataSource = dtBounding;
            this.uGrid_Details.DataBind();

            this.uGrid_Details.Rows[14].Cells[COLUMN_SALESAVG].Activation = Activation.NoEdit;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SALESAVG].Appearance.BackColorDisabled = Color.Gainsboro;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SALESAVG].Appearance.BackColorDisabled2 = Color.Gainsboro;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SALESAVG].Appearance.BackColor = Color.Gainsboro;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SALESAVG].Appearance.BackColor2 = Color.Gainsboro;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SALESAVG].Appearance.BackGradientStyle = GradientStyle.Vertical;

            this.uGrid_Details.Rows[14].Cells[COLUMN_SUPPLAVG].Activation = Activation.NoEdit;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SUPPLAVG].Appearance.BackColorDisabled = Color.Gainsboro;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SUPPLAVG].Appearance.BackColorDisabled2 = Color.Gainsboro;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SUPPLAVG].Appearance.BackColor = Color.Gainsboro;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SUPPLAVG].Appearance.BackColor2 = Color.Gainsboro;
            this.uGrid_Details.Rows[14].Cells[COLUMN_SUPPLAVG].Appearance.BackGradientStyle = GradientStyle.Vertical;
        }

        /// <summary>
        /// グリッド列の初期化処理
        /// </summary>
        /// <param name="Columns">Columns</param>
        /// <remarks>
        /// <br>Note        : グリッド列の初期化処理します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/23</br>
        /// <br>Update Note : 2010/09/08 楊明俊</br>
        /// <br>            ・障害ID:14444 テキスト出力対応</br>
        /// <br>Update Note : 2010/09/13 tianjw</br>
        /// <br>            ・テキスト出力対応</br>
        /// <br>Update Note : 2011/02/16 liyp</br>
        /// <br>            ・テキスト出力対応</br>
        /// </remarks>
        private void InitializeGridColumns(bool excelFlg)
        {
            ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;
            
            // 出力用
            if (excelFlg)
            {
                _gridBoundDataTable.Clear();

                ShipmentPartsDspResultToFile();

                this.uGrid_Details.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

                string moneyFormat = "#,###,##0;-#,###,##0;0";
                // -----------ADD 2011/02/16 ------------------------->>>>>
                if (_excOrtxtDiv)
                {
                    moneyFormat = "";
                    // _excOrtxtDiv = false; // DEL 2011/03/23
                }
                // -----------ADD 2011/02/16 -------------------------<<<<<
                int defoWidth = 150; 
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
                {
                    // 全ての列をいったん非表示にする。
                    col.Hidden = false;
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    col.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Left;
                    col.CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                    // フォントサイズ：9
                    col.CellAppearance.FontData.SizeInPoints = 9f;   // フォントサイズ変更
                    col.Format = moneyFormat;
                    col.Width = defoWidth;
                }

                // -------------------------------- ADD 2010/09/13 ------------------------------------------------------>>>>>
                for (int cellIndex = 0; cellIndex < 10; cellIndex++)
                {
                    this.uGrid_Details.DisplayLayout.Bands[0].Columns[cellIndex].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                // -------------------------------- ADD 2010/09/13 ------------------------------------------------------<<<<<

                columns[COLUMN_WAREHOUSECODE].Format = "";
                columns[COLUMN_GOODSNO].Format = "";
                columns[COLUMN_MAKERCD].Format = "";
                columns[COLUMN_GOODSNAME].Format = "";
                columns[COLUMN_WAREHOUSESHELFNO].Format = "";
                columns[COLUMN_BLGOODSCODE].Format = "";
                columns[COLUMN_ZAIKUYMD].Format = "yyyy/MM/dd";
                columns[COLUMN_SALESYMDED].Format = "yyyy/MM/dd";
                columns[COLUMN_SUPPLIERYMDED].Format = "yyyy/MM/dd";

                // 列表示状態
                columns[COLUMN_TITLE].Hidden = true;
                columns[COLUMN_SALESNO].Hidden = true;
                columns[COLUMN_SALESCNT].Hidden = true;
                columns[COLUMN_SALESAVG].Hidden = true;
                columns[COLUMN_SALESMONY].Hidden = true;
                columns[COLUMN_SUPPLNO].Hidden = true;
                columns[COLUMN_SUPPLCNT].Hidden = true;
                columns[COLUMN_SUPPLAVG].Hidden = true;
                columns[COLUMN_SUPPLMONY].Hidden = true;
                columns[COLUMN_GROSSMONY].Hidden = true;
                columns[COLUMN_ARRINO].Hidden = true;
                columns[COLUMN_ARRIMONY].Hidden = true;
                columns[COLUMN_SHIPNO].Hidden = true;
                columns[COLUMN_SHIPMONY].Hidden = true;

                for (int i = 0; i <= 12; i++)
                {
                    if (i == 0)
                    {
                        columns[COLUMN_SALESNO + i.ToString()].Header.Caption = "売上・数量（当月）";
                        columns[COLUMN_SALESCNT + i.ToString()].Header.Caption = "売上・回数（当月）";
                        columns[COLUMN_SALESMONY + i.ToString()].Header.Caption = "売上・金額（当月）";
                        columns[COLUMN_SUPPLNO + i.ToString()].Header.Caption = "仕入・数量（当月）";
                        columns[COLUMN_SUPPLCNT + i.ToString()].Header.Caption = "仕入・回数（当月）";
                        columns[COLUMN_SUPPLMONY + i.ToString()].Header.Caption = "仕入・金額（当月）";
                        columns[COLUMN_GROSSMONY + i.ToString()].Header.Caption = "粗利数（当月）";
                        columns[COLUMN_ARRINO + i.ToString()].Header.Caption = "移動入庫・数量（当月）";
                        columns[COLUMN_ARRIMONY + i.ToString()].Header.Caption = "移動入庫・金額（当月）";
                        columns[COLUMN_SHIPNO + i.ToString()].Header.Caption = "移動出庫・数量（当月）";
                        columns[COLUMN_SHIPMONY + i.ToString()].Header.Caption = "移動出庫・金額（当月）";
                    }
                    else
                    {
                        columns[COLUMN_SALESNO + i.ToString()].Header.Caption = "売上・数量（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                        columns[COLUMN_SALESCNT + i.ToString()].Header.Caption = "売上・回数（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                        columns[COLUMN_SALESMONY + i.ToString()].Header.Caption = "売上・金額（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                        columns[COLUMN_SUPPLNO + i.ToString()].Header.Caption = "仕入・数量（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                        columns[COLUMN_SUPPLCNT + i.ToString()].Header.Caption = "仕入・回数（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                        columns[COLUMN_SUPPLMONY + i.ToString()].Header.Caption = "仕入・金額（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                        columns[COLUMN_GROSSMONY + i.ToString()].Header.Caption = "粗利数（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                        columns[COLUMN_ARRINO + i.ToString()].Header.Caption = "移動入庫・数量（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                        columns[COLUMN_ARRIMONY + i.ToString()].Header.Caption = "移動入庫・金額（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                        columns[COLUMN_SHIPNO + i.ToString()].Header.Caption = "移動出庫・数量（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                        columns[COLUMN_SHIPMONY + i.ToString()].Header.Caption = "移動出庫・金額（" + _thisYearMonth.AddMonths(-i).Month.ToString() + "月）";
                    }
                }
                // ---------------------- UPD  2010/09/08 --------------------------------->>>>>
                //columns[COLUMN_WAREHOUSECODE].Header.Caption = "倉庫コード";
                columns[COLUMN_WAREHOUSECODE].Header.Caption = "倉庫";
                // ---------------------- UPD  2010/09/08 ---------------------------------<<<<<
                columns[COLUMN_GOODSNO].Header.Caption = "品番";
                // ---------------------- UPD  2010/09/08 --------------------------------->>>>>
                //columns[COLUMN_MAKERCD].Header.Caption = "メーカコード";
                columns[COLUMN_MAKERCD].Header.Caption = "メーカー";
                // ---------------------- UPD  2010/09/08 ---------------------------------<<<<<
                columns[COLUMN_GOODSNAME].Header.Caption = "品名";
                columns[COLUMN_WAREHOUSESHELFNO].Header.Caption = "棚番";
                columns[COLUMN_BLGOODSCODE].Header.Caption = "BLコード";
                columns[COLUMN_ZAIKUYMD].Header.Caption = "在庫登録日";
                columns[COLUMN_SALESYMDED].Header.Caption = "最終売上日";
                columns[COLUMN_SUPPLIERYMDED].Header.Caption = "最終仕入日";
            }
            // 検索用
            else
            {
                this.SetGridLayout();

                this.ultraLabel4.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
                this.ultraLabel4.Appearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
                this.ultraLabel5.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
                this.ultraLabel5.Appearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
                this.ultraLabel8.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
                this.ultraLabel8.Appearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
                this.ultraLabel9.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
                this.ultraLabel9.Appearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
                this.ultraLabel10.Appearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
                this.ultraLabel10.Appearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;

                this.uGrid_Details.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

                string moneyFormat = "#,###,##0;-#,###,##0;0";

                // フォントサイズ：9
                int defoWidth = 94;     //（13桁）
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in columns)
                {
                    // 全ての列をいったん非表示にする。
                    col.Hidden = true;
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    col.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Left;
                    col.CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                    col.CellAppearance.FontData.SizeInPoints = 9f;   // フォントサイズ変更
                    col.Format = moneyFormat;
                    col.Width = defoWidth;
                }

                // 列表示状態
                columns[COLUMN_TITLE].Hidden = false;
                columns[COLUMN_SALESNO].Hidden = false;
                columns[COLUMN_SALESCNT].Hidden = false;
                columns[COLUMN_SALESAVG].Hidden = false;
                columns[COLUMN_SALESMONY].Hidden = false;
                columns[COLUMN_SUPPLNO].Hidden = false;
                columns[COLUMN_SUPPLCNT].Hidden = false;
                columns[COLUMN_SUPPLAVG].Hidden = false;
                columns[COLUMN_SUPPLMONY].Hidden = false;
                columns[COLUMN_GROSSMONY].Hidden = false;
                columns[COLUMN_ARRINO].Hidden = false;
                columns[COLUMN_ARRIMONY].Hidden = false;
                columns[COLUMN_SHIPNO].Hidden = false;
                columns[COLUMN_SHIPMONY].Hidden = false;

                // キャプション
                columns[COLUMN_TITLE].Header.Caption = "";
                columns[COLUMN_SALESNO].Header.Caption = "数";
                columns[COLUMN_SALESCNT].Header.Caption = "回数";
                columns[COLUMN_SALESAVG].Header.Caption = "平均";
                columns[COLUMN_SALESMONY].Header.Caption = "金額";
                columns[COLUMN_SUPPLNO].Header.Caption = "数";
                columns[COLUMN_SUPPLCNT].Header.Caption = "回数";
                columns[COLUMN_SUPPLAVG].Header.Caption = "平均";
                columns[COLUMN_SUPPLMONY].Header.Caption = "金額";
                columns[COLUMN_GROSSMONY].Header.Caption = "金額";
                columns[COLUMN_ARRINO].Header.Caption = "数";
                columns[COLUMN_ARRIMONY].Header.Caption = "金額";
                columns[COLUMN_SHIPNO].Header.Caption = "数";
                columns[COLUMN_SHIPMONY].Header.Caption = "金額";
            }
        }

        /// <summary>
        /// 画面表示データからテキスト出力データに変更処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面表示データからテキスト出力データに変更処理します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/23</br>
        /// <br>Update Note: 2010/08/12 chenyd</br>
        /// <br>            ・障害ID:13055 テキスト出力対応</br>
        /// <br>Update Note: 2010/09/28 tianjw</br>
        /// <br>            ・障害ID:15612 テキスト出力対応</br>
        /// <br>Update Note: 2011/02/16 liyp</br>
        /// <br>            ・テキスト出力対応</br>
        /// <br>Update Note: 2011/03/23 liyp</br>
        /// <br>            ・テキスト出力対応</br>
        /// </remarks>
        private void ShipmentPartsDspResultToFile()
        {
            List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList = this._resultData;
            List<StockHistoryDspSearchResult> stockCurrentMonResultList = new List<StockHistoryDspSearchResult>();
            List<StockHistoryDspSearchResult> stockHistoryMonResultList = new List<StockHistoryDspSearchResult>();

            if (stockHistoryDspSearchResultList == null)
            {
                return;
            }

            for (int i = 0; i < stockHistoryDspSearchResultList.Count; i++)
            {
                if (stockHistoryDspSearchResultList[i].SearchDiv == 0)
                {
                    // 当月データを取得
                    stockCurrentMonResultList.Add(stockHistoryDspSearchResultList[i]);
                }
                else
                {
                    // 前月～1年間データを取得
                    stockHistoryMonResultList.Add(stockHistoryDspSearchResultList[i]);
                }
            }

            List<List<StockHistoryDspSearchResult>> stockHistoryDspSearchResultListList = new List<List<StockHistoryDspSearchResult>>();
            List<StockHistoryDspSearchResult> tempResultList;

            List<StockHistoryDspSearchResult> stockHistoryMonResultListTmp = stockHistoryMonResultList;
            List<StockHistoryDspSearchResult> stockHistoryMonResultListAfterRemove = new List<StockHistoryDspSearchResult>();
            List<StockHistoryDspSearchResult> stockCurrentMonResultListTmp = stockCurrentMonResultList; // ADD 2010/09/15

            for (int i = 0; i < stockCurrentMonResultList.Count; i++)
            {
                tempResultList = new List<StockHistoryDspSearchResult>();
                //tempResultList.Add(stockCurrentMonResultList[i]);  // DEL 2010/08/12 障害ID:13055対応

                // ---ADD 2010/09/15 ---------->>>>>
                bool removeStockCurrentFlg = false;
                // ---ADD 2010/09/15 ----------<<<<<

                for (int j = 0; j < stockHistoryMonResultListTmp.Count; j++)
                {
                    if (stockCurrentMonResultList[i].WarehouseCode == stockHistoryMonResultListTmp[j].WarehouseCode
                        && stockCurrentMonResultList[i].GoodsMakerCd == stockHistoryMonResultListTmp[j].GoodsMakerCd
                        && stockCurrentMonResultList[i].GoodsNo == stockHistoryMonResultListTmp[j].GoodsNo)
                    {
                        tempResultList.Add(stockCurrentMonResultList[i]); // ADD 2010/08/12 障害ID:13055対応
                        removeStockCurrentFlg = true; // ADD 2010/09/15
                        tempResultList[0].WarehouseShelfNo = stockHistoryMonResultListTmp[j].WarehouseShelfNo;
                        tempResultList[0].BlGoodsCode = stockHistoryMonResultListTmp[j].BlGoodsCode;

                        tempResultList[0].StockCreateDate = stockHistoryMonResultListTmp[j].StockCreateDate;
                        tempResultList[0].LastSalesDate = stockHistoryMonResultListTmp[j].LastSalesDate;
                        tempResultList[0].LastStockDate = stockHistoryMonResultListTmp[j].LastStockDate;

                        tempResultList.Add(stockHistoryMonResultListTmp[j]);
                        stockHistoryMonResultListTmp.Remove(stockHistoryMonResultListTmp[j]);// ADD 2010/08/12 障害ID:13055対応
                        j--;// ADD 2010/08/12 障害ID:13055対応
                    }
                    // --- DEL 2010/08/12 障害ID:13055対応-------------------------------->>>>>
                    //else
                    //{
                    //    stockHistoryMonResultListAfterRemove.Add(stockHistoryMonResultListTmp[j]);
                    //}
                    // --- DEL 2010/08/12 障害ID:13055対応--------------------------------<<<<<
                }

                // --- ADD 2010/09/15-------------------------------->>>>>
                if (removeStockCurrentFlg)
                {
                    stockCurrentMonResultListTmp.Remove(stockCurrentMonResultList[i]);
                    i--;
                }
                // --- ADD 2010/09/15--------------------------------<<<<<

                //stockHistoryMonResultList = stockHistoryMonResultListAfterRemove;// DEL 2010/08/12 障害ID:13055対応

                // 同じなキーの当月データと前月～1年間データを取得
                if (tempResultList.Count != 0) // ADD 2010/08/12 障害ID:13055対応
                {
                    stockHistoryDspSearchResultListList.Add(tempResultList);
                }
            }
            // --- ADD 2010/09/15-------------------------------->>>>>
            if (stockCurrentMonResultListTmp.Count != 0)
            {
                foreach (StockHistoryDspSearchResult stockHis in stockCurrentMonResultListTmp)
                {
                    List<StockHistoryDspSearchResult> stockHisList = new List<StockHistoryDspSearchResult>();
                    stockHisList.Add(stockHis);
                    stockHistoryDspSearchResultListList.Add(stockHisList);
                }
            }
            // --- ADD 2010/09/15--------------------------------<<<<<
            stockHistoryMonResultList = stockHistoryMonResultListTmp; // ADD 2010/08/12 障害ID:13055対応

            // 当月データがない、前月～1年間データがあるの場合、
            if (stockHistoryMonResultList != null && stockHistoryMonResultList.Count > 0)
            {
                string wareHouseCode = string.Empty;
                Int32 goodsMakerCd = 0;
                string goodsNo = string.Empty;
                StockHistoryDspSearchResult tempSearchResult;
                tempResultList = new List<StockHistoryDspSearchResult>();

                for (int i = 0; i < stockHistoryMonResultList.Count; i++)
                {
                    // 先頭レコード
                    if (i == 0)
                    {
                        // キーを保存
                        wareHouseCode = stockHistoryMonResultList[i].WarehouseCode;
                        goodsMakerCd = stockHistoryMonResultList[i].GoodsMakerCd;
                        goodsNo = stockHistoryMonResultList[i].GoodsNo;

                        // 仮当月データを作成。
                        tempSearchResult = new StockHistoryDspSearchResult();
                        tempSearchResult.WarehouseCode = stockHistoryMonResultList[i].WarehouseCode;
                        tempSearchResult.GoodsMakerCd = stockHistoryMonResultList[i].GoodsMakerCd;
                        tempSearchResult.GoodsNo = stockHistoryMonResultList[i].GoodsNo;
                        tempSearchResult.GoodsName = stockHistoryMonResultList[i].GoodsName;
                        tempSearchResult.WarehouseShelfNo = stockHistoryMonResultList[i].WarehouseShelfNo;
                        tempSearchResult.BlGoodsCode = stockHistoryMonResultList[i].BlGoodsCode;
                        tempSearchResult.StockCreateDate = stockHistoryMonResultList[i].StockCreateDate;
                        tempSearchResult.LastSalesDate = stockHistoryMonResultList[i].LastSalesDate;
                        tempSearchResult.LastStockDate = stockHistoryMonResultList[i].LastStockDate;
                        tempSearchResult.SearchDiv = 0;

                        tempResultList.Add(tempSearchResult);
                    }
                    else
                    {
                        if (wareHouseCode == stockHistoryMonResultList[i].WarehouseCode
                           && goodsMakerCd == stockHistoryMonResultList[i].GoodsMakerCd
                           && goodsNo == stockHistoryMonResultList[i].GoodsNo)
                        {
                            tempResultList.Add(stockHistoryMonResultList[i]);
                        }
                        else
                        {
                            stockHistoryDspSearchResultListList.Add(tempResultList);

                            // キーを変更
                            wareHouseCode = stockHistoryMonResultList[i].WarehouseCode;
                            goodsMakerCd = stockHistoryMonResultList[i].GoodsMakerCd;
                            goodsNo = stockHistoryMonResultList[i].GoodsNo;

                            // 仮当月データを作成。
                            tempSearchResult = new StockHistoryDspSearchResult();
                            tempSearchResult.WarehouseCode = stockHistoryMonResultList[i].WarehouseCode;
                            tempSearchResult.GoodsMakerCd = stockHistoryMonResultList[i].GoodsMakerCd;
                            tempSearchResult.GoodsNo = stockHistoryMonResultList[i].GoodsNo;
                            tempSearchResult.GoodsName = stockHistoryMonResultList[i].GoodsName;
                            tempSearchResult.WarehouseShelfNo = stockHistoryMonResultList[i].WarehouseShelfNo;
                            tempSearchResult.BlGoodsCode = stockHistoryMonResultList[i].BlGoodsCode;
                            tempSearchResult.StockCreateDate = stockHistoryMonResultList[i].StockCreateDate;
                            tempSearchResult.LastSalesDate = stockHistoryMonResultList[i].LastSalesDate;
                            tempSearchResult.LastStockDate = stockHistoryMonResultList[i].LastStockDate;
                            tempSearchResult.SearchDiv = 0;

                            tempResultList = new List<StockHistoryDspSearchResult>();
                            tempResultList.Add(tempSearchResult);
                        }
                    }
                }

                stockHistoryDspSearchResultListList.Add(tempResultList);
            }

            // ------------ ADD 2010/09/28 ------------------------------------------------------------>>>>>
            for(int i = stockHistoryDspSearchResultListList.Count - 1; i >= 0; i--) 
            {
                List<StockHistoryDspSearchResult> resultList = stockHistoryDspSearchResultListList[i];
                for (int j = resultList.Count - 1; j >= 0; j--)
                {
                    StockHistoryDspSearchResult stockHistoryDspSearchResult = resultList[j];

                    if (stockHistoryDspSearchResult.SalesCount == 0 && stockHistoryDspSearchResult.SalesTimes == 0 &&
                    stockHistoryDspSearchResult.SalesMoneyTaxExc == 0 && stockHistoryDspSearchResult.StockCount == 0 &&
                    stockHistoryDspSearchResult.StockTimes == 0 && stockHistoryDspSearchResult.StockPriceTaxExc == 0 &&
                    stockHistoryDspSearchResult.GrossProfit == 0 && stockHistoryDspSearchResult.MoveArrivalCnt == 0 &&
                    stockHistoryDspSearchResult.MoveArrivalPrice == 0 && stockHistoryDspSearchResult.MoveShipmentCnt == 0 &&
                    stockHistoryDspSearchResult.MoveShipmentPrice == 0)
                    {
                        resultList.Remove(stockHistoryDspSearchResult);
                    }
                }
                if (resultList.Count == 0)
                {
                    stockHistoryDspSearchResultListList.Remove(resultList);
                }
            }
            // ------------ ADD 2010/09/28 ------------------------------------------------------------<<<<<

            for (int i = 0; i < stockHistoryDspSearchResultListList.Count; i++)
            {
                DataRow dr = _gridBoundDataTable.NewRow();
                _gridBoundDataTable.Rows.Add(dr);
            }

            for (int i = 0; i < stockHistoryDspSearchResultListList.Count; i++)
            {
                // テキスト出力データをグリッドに設定処理
                ShipmentPartsDspResult(stockHistoryDspSearchResultListList[i]);

                this._gridBoundDataTable.Rows[i][COLUMN_WAREHOUSECODE] = stockHistoryDspSearchResultListList[i][0].WarehouseCode;
                this._gridBoundDataTable.Rows[i][COLUMN_GOODSNO] = stockHistoryDspSearchResultListList[i][0].GoodsNo;
                // this._gridBoundDataTable.Rows[i][COLUMN_MAKERCD] = stockHistoryDspSearchResultListList[i][0].GoodsMakerCd;//DEL 2011/03/23
                // -------------------------ADD 2011/03/23 ----------------->>>>>
               if (_excOrtxtDiv)
                {
                    this._gridBoundDataTable.Rows[i][COLUMN_MAKERCD] = stockHistoryDspSearchResultListList[i][0].GoodsMakerCd.ToString().PadLeft(4, '0');
                    this._gridBoundDataTable.Rows[i][COLUMN_BLGOODSCODE] = stockHistoryDspSearchResultListList[i][0].BlGoodsCode.ToString().PadLeft(5, '0');
                }
                else
                {
                    this._gridBoundDataTable.Rows[i][COLUMN_MAKERCD] = stockHistoryDspSearchResultListList[i][0].GoodsMakerCd;
                    this._gridBoundDataTable.Rows[i][COLUMN_BLGOODSCODE] = stockHistoryDspSearchResultListList[i][0].BlGoodsCode;
                }
                // -------------------------ADD 2011/03/23 -----------------<<<<<
                this._gridBoundDataTable.Rows[i][COLUMN_GOODSNAME] = stockHistoryDspSearchResultListList[i][0].GoodsName;
                this._gridBoundDataTable.Rows[i][COLUMN_WAREHOUSESHELFNO] = stockHistoryDspSearchResultListList[i][0].WarehouseShelfNo;
                // this._gridBoundDataTable.Rows[i][COLUMN_BLGOODSCODE] = stockHistoryDspSearchResultListList[i][0].BlGoodsCode; //DEL 2011/03/23
                this._gridBoundDataTable.Rows[i][COLUMN_ZAIKUYMD] = TDateTime.DateTimeToString("YYYY/MM/DD", stockHistoryDspSearchResultListList[i][0].StockCreateDate);
                this._gridBoundDataTable.Rows[i][COLUMN_SALESYMDED] = TDateTime.DateTimeToString("YYYY/MM/DD", stockHistoryDspSearchResultListList[i][0].LastSalesDate);
                this._gridBoundDataTable.Rows[i][COLUMN_SUPPLIERYMDED] = TDateTime.DateTimeToString("YYYY/MM/DD", stockHistoryDspSearchResultListList[i][0].LastStockDate);
                // -------------------------ADD 2011/02/16 ----------------->>>>>
                if (_excOrtxtDiv)
                {
                    if (!string.IsNullOrEmpty(this._gridBoundDataTable.Rows[i][COLUMN_ZAIKUYMD].ToString()))
                    {
                        this._gridBoundDataTable.Rows[i][COLUMN_ZAIKUYMD] = this._gridBoundDataTable.Rows[i][COLUMN_ZAIKUYMD].ToString().Replace("/", "");
                    }
                    if (!string.IsNullOrEmpty(this._gridBoundDataTable.Rows[i][COLUMN_SALESYMDED].ToString()))
                    {
                        this._gridBoundDataTable.Rows[i][COLUMN_SALESYMDED] = this._gridBoundDataTable.Rows[i][COLUMN_SALESYMDED].ToString().Replace("/", "");
                    }
                    if (!string.IsNullOrEmpty(this._gridBoundDataTable.Rows[i][COLUMN_SUPPLIERYMDED].ToString()))
                    {
                        this._gridBoundDataTable.Rows[i][COLUMN_SUPPLIERYMDED] = this._gridBoundDataTable.Rows[i][COLUMN_SUPPLIERYMDED].ToString().Replace("/", "");
                    }
                }
                // -------------------------ADD 2011/02/16 -----------------<<<<<

                // テキスト出力部グリッドのデータを作成
                for (int j = 0; j <= 12; j++)
                {
                    this._gridBoundDataTable.Rows[i][COLUMN_SALESNO + j.ToString()] = this.uGrid_Details.Rows[j].Cells[COLUMN_SALESNO].Value;
                    this._gridBoundDataTable.Rows[i][COLUMN_SALESCNT + j.ToString()] = this.uGrid_Details.Rows[j].Cells[COLUMN_SALESCNT].Value;
                    this._gridBoundDataTable.Rows[i][COLUMN_SALESMONY + j.ToString()] = this.uGrid_Details.Rows[j].Cells[COLUMN_SALESMONY].Value;
                    this._gridBoundDataTable.Rows[i][COLUMN_SUPPLNO + j.ToString()] = this.uGrid_Details.Rows[j].Cells[COLUMN_SUPPLNO].Value;
                    this._gridBoundDataTable.Rows[i][COLUMN_SUPPLCNT + j.ToString()] = this.uGrid_Details.Rows[j].Cells[COLUMN_SUPPLCNT].Value;
                    this._gridBoundDataTable.Rows[i][COLUMN_SUPPLMONY + j.ToString()] = this.uGrid_Details.Rows[j].Cells[COLUMN_SUPPLMONY].Value;
                    this._gridBoundDataTable.Rows[i][COLUMN_GROSSMONY + j.ToString()] = this.uGrid_Details.Rows[j].Cells[COLUMN_GROSSMONY].Value;
                    this._gridBoundDataTable.Rows[i][COLUMN_ARRINO + j.ToString()] = this.uGrid_Details.Rows[j].Cells[COLUMN_ARRINO].Value;
                    this._gridBoundDataTable.Rows[i][COLUMN_ARRIMONY + j.ToString()] = this.uGrid_Details.Rows[j].Cells[COLUMN_ARRIMONY].Value;
                    this._gridBoundDataTable.Rows[i][COLUMN_SHIPNO + j.ToString()] = this.uGrid_Details.Rows[j].Cells[COLUMN_SHIPNO].Value;
                    this._gridBoundDataTable.Rows[i][COLUMN_SHIPMONY + j.ToString()] = this.uGrid_Details.Rows[j].Cells[COLUMN_SHIPMONY].Value;
                }
            }

            DataView dv = _gridBoundDataTable.DefaultView;
            dv.Sort = COLUMN_WAREHOUSECODE + " ASC, " + COLUMN_GOODSNO + " ASC, " + COLUMN_MAKERCD + " ASC";

            this.uGrid_Details.DataSource = dv;
            this.uGrid_Details.DataBind();
        }

        /// <summary>
        /// テキスト出力データをグリッドに設定処理
        /// </summary>
        /// <param name="shipmentPartsDspResultList">在庫実績照会抽出結果リスト</param>
        /// <remarks>
        /// <remarks>
        /// <br>Note        : テキスト出力データをグリッドに設定処理します。</br>
        /// <br>Programmer  : 王増喜</br>
        /// <br>Date        : 2010/07/23</br>
        /// <br>Update Note : 2010/10/09 曹文傑</br>
        /// <br>            ・障害ID:15882 テキスト出力対応</br>
        /// </remarks>
        private void ShipmentPartsDspResult(List<StockHistoryDspSearchResult> stockHistoryDspSearchResultList)
        {
            if (stockHistoryDspSearchResultList == null)
            {
                return;
            }

            double salesNo, sumSalesNo = 0;
            int salesCnt, sumSalesCnt = 0;
            long salesMoney, sumSalesMoney = 0;
            double stockNo, sumStockNo = 0;
            int stockCnt, sumStockCnt = 0;
            long stockMoney, sumStockMoney = 0;
            long grossProfit, sumGrossProfit = 0;
            double arriNo, sumArriNo = 0;
            long arriMoney, sumArriMoney = 0;
            double shipNo, sumShipNo = 0;
            long shipMoney, sumShipMoney = 0;

            int i = 0;

            for (i = 0; i <= 12; i++)
            {
                // 売上
                this.uGrid_Details.Rows[i].Cells[COLUMN_SALESNO].Value = 0;
                this.uGrid_Details.Rows[i].Cells[COLUMN_SALESCNT].Value = "0";
                this.uGrid_Details.Rows[i].Cells[COLUMN_SALESMONY].Value = "0";

                // 仕入
                this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLNO].Value = 0;
                this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLCNT].Value = "0";
                this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLMONY].Value = "0";

                // 粗利
                this.uGrid_Details.Rows[i].Cells[COLUMN_GROSSMONY].Value = "0";

                // 移動入庫
                this.uGrid_Details.Rows[i].Cells[COLUMN_ARRINO].Value = 0;
                this.uGrid_Details.Rows[i].Cells[COLUMN_ARRIMONY].Value = "0";

                // 移動出庫
                this.uGrid_Details.Rows[i].Cells[COLUMN_SHIPNO].Value = 0;
                this.uGrid_Details.Rows[i].Cells[COLUMN_SHIPMONY].Value = "0";
            }

            foreach (StockHistoryDspSearchResult stockHistoryDspSearchResult in stockHistoryDspSearchResultList)
            {
                #region 前月～1年間
                for (i = 12; i >= 0; i--)
                {
                    if (stockHistoryDspSearchResult.SearchDiv == 0)
                    {
                        #region 当月
                        // 売上
                        salesNo = stockHistoryDspSearchResult.SalesCount;
                        this.uGrid_Details.Rows[0].Cells[COLUMN_SALESNO].Value = salesNo;

                        salesCnt = stockHistoryDspSearchResult.SalesTimes;
                        // ---UPD 2010/10/09------------->>>>>
                        //this.uGrid_Details.Rows[0].Cells[COLUMN_SALESCNT].Value = salesCnt.ToString("#,###,##0");
                        this.uGrid_Details.Rows[0].Cells[COLUMN_SALESCNT].Value = salesCnt;
                        // ---UPD 2010/10/09-------------<<<<<

                        salesMoney = stockHistoryDspSearchResult.SalesMoneyTaxExc;
                        // ---UPD 2010/10/09------------->>>>>
                        //this.uGrid_Details.Rows[0].Cells[COLUMN_SALESMONY].Value = salesMoney.ToString("#,###,###,##0");
                        this.uGrid_Details.Rows[0].Cells[COLUMN_SALESMONY].Value = salesMoney;
                        // ---UPD 2010/10/09-------------<<<<<

                        // 仕入
                        stockNo = stockHistoryDspSearchResult.StockCount;
                        this.uGrid_Details.Rows[0].Cells[COLUMN_SUPPLNO].Value = stockNo;

                        stockCnt = stockHistoryDspSearchResult.StockTimes;
                        // ---UPD 2010/10/09------------->>>>>
                        //this.uGrid_Details.Rows[0].Cells[COLUMN_SUPPLCNT].Value = stockCnt.ToString("#,###,##0");
                        this.uGrid_Details.Rows[0].Cells[COLUMN_SUPPLCNT].Value = stockCnt;
                        // ---UPD 2010/10/09-------------<<<<<

                        stockMoney = stockHistoryDspSearchResult.StockPriceTaxExc;
                        // ---UPD 2010/10/09------------->>>>>
                        //this.uGrid_Details.Rows[0].Cells[COLUMN_SUPPLMONY].Value = stockMoney.ToString("#,###,###,##0");
                        this.uGrid_Details.Rows[0].Cells[COLUMN_SUPPLMONY].Value = stockMoney;
                        // ---UPD 2010/10/09-------------<<<<<

                        // 粗利
                        grossProfit = stockHistoryDspSearchResult.GrossProfit;
                        this.uGrid_Details.Rows[0].Cells[COLUMN_GROSSMONY].Value = grossProfit.ToString("#,###,###,##0");

                        // 移動入庫
                        arriNo = stockHistoryDspSearchResult.MoveArrivalCnt;
                        this.uGrid_Details.Rows[0].Cells[COLUMN_ARRINO].Value = arriNo;

                        arriMoney = stockHistoryDspSearchResult.MoveArrivalPrice;
                        // ---UPD 2010/10/09------------->>>>>
                        //this.uGrid_Details.Rows[0].Cells[COLUMN_ARRIMONY].Value = arriMoney.ToString("#,###,###,##0");
                        this.uGrid_Details.Rows[0].Cells[COLUMN_ARRIMONY].Value = arriMoney;
                        // ---UPD 2010/10/09-------------<<<<<

                        // 移動出庫
                        shipNo = stockHistoryDspSearchResult.MoveShipmentCnt;
                        this.uGrid_Details.Rows[0].Cells[COLUMN_SHIPNO].Value = shipNo;

                        shipMoney = stockHistoryDspSearchResult.MoveShipmentPrice;
                        // ---UPD 2010/10/09------------->>>>>
                        //this.uGrid_Details.Rows[0].Cells[COLUMN_SHIPMONY].Value = shipMoney.ToString("#,###,###,##0");
                        this.uGrid_Details.Rows[0].Cells[COLUMN_SHIPMONY].Value = shipMoney;
                        // ---UPD 2010/10/09-------------<<<<<
                        #endregion
                    }
                    else
                    {
                        int month = _thisYearMonth.AddMonths(-i).Month;
                        int year = _thisYearMonth.AddMonths(-i).Year;
                        if (stockHistoryDspSearchResult.AddUpYearMonth.Month == month
                            && stockHistoryDspSearchResult.AddUpYearMonth.Year == year)
                        {
                            // 売上
                            salesNo = stockHistoryDspSearchResult.SalesCount;
                            this.uGrid_Details.Rows[i].Cells[COLUMN_SALESNO].Value = salesNo;
                            sumSalesNo += salesNo;

                            salesCnt = stockHistoryDspSearchResult.SalesTimes;
                            // ---UPD 2010/10/09------------->>>>>
                            //this.uGrid_Details.Rows[i].Cells[COLUMN_SALESCNT].Value = salesCnt.ToString("#,###,##0");
                            this.uGrid_Details.Rows[i].Cells[COLUMN_SALESCNT].Value = salesCnt;
                            // ---UPD 2010/10/09-------------<<<<<
                            sumSalesCnt += salesCnt;

                            salesMoney = stockHistoryDspSearchResult.SalesMoneyTaxExc;
                            // ---UPD 2010/10/09------------->>>>>
                            //this.uGrid_Details.Rows[i].Cells[COLUMN_SALESMONY].Value = salesMoney.ToString("#,###,###,##0");
                            this.uGrid_Details.Rows[i].Cells[COLUMN_SALESMONY].Value = salesMoney;
                            // ---UPD 2010/10/09-------------<<<<<
                            sumSalesMoney += salesMoney;

                            // 仕入
                            stockNo = stockHistoryDspSearchResult.StockCount;
                            this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLNO].Value = stockNo;
                            sumStockNo += stockNo;

                            stockCnt = stockHistoryDspSearchResult.StockTimes;
                            // ---UPD 2010/10/09------------->>>>>
                            //this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLCNT].Value = stockCnt.ToString("#,###,##0");
                            this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLCNT].Value = stockCnt;
                            // ---UPD 2010/10/09-------------<<<<<
                            sumStockCnt += stockCnt;

                            stockMoney = stockHistoryDspSearchResult.StockPriceTaxExc;
                            // ---UPD 2010/10/09------------->>>>>
                            //this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLMONY].Value = stockMoney.ToString("#,###,###,##0");
                            this.uGrid_Details.Rows[i].Cells[COLUMN_SUPPLMONY].Value = stockMoney;
                            // ---UPD 2010/10/09-------------<<<<<
                            sumStockMoney += stockMoney;

                            // 粗利
                            grossProfit = stockHistoryDspSearchResult.GrossProfit;
                            this.uGrid_Details.Rows[i].Cells[COLUMN_GROSSMONY].Value = grossProfit.ToString("#,###,###,##0");
                            sumGrossProfit += grossProfit;

                            // 移動入庫
                            arriNo = stockHistoryDspSearchResult.MoveArrivalCnt;
                            this.uGrid_Details.Rows[i].Cells[COLUMN_ARRINO].Value = arriNo;
                            sumArriNo += arriNo;

                            arriMoney = stockHistoryDspSearchResult.MoveArrivalPrice;
                            // ---UPD 2010/10/09------------->>>>>
                            //this.uGrid_Details.Rows[i].Cells[COLUMN_ARRIMONY].Value = arriMoney.ToString("#,###,###,##0");
                            this.uGrid_Details.Rows[i].Cells[COLUMN_ARRIMONY].Value = arriMoney;
                            // ---UPD 2010/10/09-------------<<<<<
                            sumArriMoney += arriMoney;

                            // 移動出庫
                            shipNo = stockHistoryDspSearchResult.MoveShipmentCnt;
                            this.uGrid_Details.Rows[i].Cells[COLUMN_SHIPNO].Value = shipNo;
                            sumShipNo += shipNo;

                            shipMoney = stockHistoryDspSearchResult.MoveShipmentPrice;
                            // ---UPD 2010/10/09------------->>>>>
                            //this.uGrid_Details.Rows[i].Cells[COLUMN_SHIPMONY].Value = shipMoney.ToString("#,###,###,##0");
                            this.uGrid_Details.Rows[i].Cells[COLUMN_SHIPMONY].Value = shipMoney;
                            // ---UPD 2010/10/09-------------<<<<<
                            sumShipMoney += shipMoney;
                        }
                    }

            #endregion
                }
            }
        }

        // --- ADD 2010/10/09-------------------------------->>>>>
        # region [ExcelExporterイベント処理]
        /// <summary>
        /// セルのコレクションイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/10/09</br>
        private void ultraGridExcelExporter1_InitializeColumn(object sender, Infragistics.Win.UltraWinGrid.ExcelExport.InitializeColumnEventArgs e)
        {
            // グリッドカラムのフォーマットをExcelセルにコピーする。
            try
            {
                string format = e.Column.Format;

                // コード用フォーマットは(ゼロ空白にする場合)グリッドとエクセルで異なるので補正する。
                // 「0000;-0000;''」→「0000;-0000;」
                if (format.EndsWith(";''"))
                {
                    format = format.Substring(0, format.Length - 2);
                }
                e.ExcelFormatStr = format;
            }
            catch
            {
                e.ExcelFormatStr = string.Empty;
            }
        }
        #endregion
        // --- ADD 2010/10/09--------------------------------<<<<<

        // ---ADD 2010/07/20 テキスト出力対応 --------------------<<<<<

    }
}
