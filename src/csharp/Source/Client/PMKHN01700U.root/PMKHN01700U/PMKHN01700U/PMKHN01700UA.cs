//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 品番変換一括処理
// プログラム概要   : 品番変換一括処理フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当  : 陳永康
// 作 成 日  2015/01/26  修正内容  : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 時シン
// 作 成 日  2015/02/17   修正内容 : Redmine#44209 パスの部分から改行されていない対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 田建委
// 作 成 日  2015/02/25   修正内容 : Redmine#44209 ファイル名、処理区分等の対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 宋剛
// 作 成 日  2015/02/25   修正内容 : Redmine#44209 No.35 ログフォルダを開くボタン追加
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 時シン
// 作 成 日  2015/02/26   修正内容 : Redmine#44209 ファイル名の定義を共通化対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 陳永康
// 作 成 日  2015/02/27   修正内容 : Redmine#44209 優良設定マスタ変換処理の機能追加
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 時シン
// 作 成 日  2015/03/02   修正内容 : Redmine#44209 三つ「仕様変更」の対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 時シン
// 作 成 日  2015/03/16   修正内容 : Redmine#44209 優良設定マスタ変換の仕様変更の対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 田建委
// 作 成 日  2015/04/06   修正内容 : Redmine#44209 メニュー起動制御対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : zhujc
// 作 成 日  2015/04/17   修正内容 : Redmine#44209 品番変換処理画面の制御対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 時シン
// 作 成 日  2015/04/30   修正内容 : Redmine#44209 No.100 Clientのログフォルダが存在しない状態でログフォルダ表示ボタンを押下すると例外エラーが発生する対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 呉軍
// 作 成 日  2015/05/12   修正内容 : Redmine#45436 No.105 品番変換処理中に終了ボタン、実行ボタンが効いてしまうの対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Win32;
using System.IO;
using System.Collections; //ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 品番変換一括処理
    /// </summary>
    /// <remarks>
    /// Note       : 品番変換一括処理です。<br />
    /// Programmer : 陳永康<br />
    /// Date       : 2015/01/26<br />
    /// <br>UpdateNote : 2015/02/25 田建委 </br>
    /// <br>           : Redmine#44209 ファイル名、処理区分等の対応</br>
    /// <br>UpdateNote : 2015/04/06 田建委 </br>
    /// <br>           : Redmine#44209 メニュー起動制御対応</br>
    /// <br>UpdateNote : 2015/04/17 zhujc </br>
    /// <br>           : Redmine#44209 品番変換処理画面の制御対応</br>
    /// <br>UpdateNote : 2015/05/12 呉軍 </br>
    /// <br>           : Redmine#45436 No.105 品番変換処理中に終了ボタン、実行ボタンが効いてしまうの対応</br>
    /// </remarks>
    public partial class PMKHN01700UA : Form
    {
        #region ■ Const Memebers
        private const string PROGRAM_ID = "PMKHN01700U";

        private const string DATATABLE_SLESCT = "選択";
        private const string DATATABLE_MAST = "処理対象";
        private const string DATATABLE_READ = "読込件数";
        private const string DATATABLE_UPDATE = "更新件数";
        private const string DATATABLE_ERR = "エラー件数";
        private const string CHECKFLG = "●";

        // ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------>>>>>>
        private const string ct_GOODSNOCHANGERF = "品番変換マスタ";
        private const string ct_GOODSUSTOCKRF = "商品在庫マスタ";
        private const string ct_GOODSMNGRF = "商品管理情報マスタ";
        private const string ct_RATERF = "掛率マスタ";
        private const string ct_JOINPARTSURF = "結合マスタ";
        private const string ct_PARTSSUBSTURF = "代替マスタ";
        private const string ct_GOODSSETRF = "セットマスタ";
        private const string ct_SALESDETAILRF = "未計上貸出データ";
        private const string ct_PRMSETTINGURF = "優良設定マスタ";
        // ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------<<<<<<

        #endregion

        //----- DEL 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応----->>>>>
        ////----- ADD 2015/02/25 田建委 Redmine#44209 ----->>>>>
        //private const string ct_GOODS_ERROR = "(エラー)商品マスタログ.csv";
        //private const string ct_GOODSPRICE_ERROR = "(エラー)価格マスタログ.csv";
        //private const string ct_STOCK_ERROR = "(エラー)在庫マスタログ.csv";
        //private const string ct_GOODSMNG_ERROR = "(エラー)商品管理情報マスタログ.csv";
        //private const string ct_RATE_ERROR = "(エラー)掛率マスタログ.csv";
        //private const string ct_JOINPARTS_ERROR = "(エラー)結合マスタログ.csv";
        //private const string ct_SUBST_ERROR = "(エラー)代替マスタログ.csv";
        //private const string ct_GOODSSET_ERROR = "(エラー)セットマスタログ.csv";
        //private const string ct_RENTDATA_ERROR = "(エラー)未計上貸出データログ.csv";
        //private const string ct_CROSS_INDEX_GOODSCHG_ERROR = "(エラー)品番変換マスタログ.csv";
        ////----- ADD 2015/02/25 田建委 Redmine#44209 -----<<<<<
        //----- DEL 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応-----<<<<<

        # region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>		
        /// <br>Note		: コンストラクタの処理化を行う。</br>
        /// <br>Programmer	: 陳永康</br>	
        /// <br>Date		: 2015/01/26</br>
        /// <br>UpdateNote  : 2015/04/17 zhujc </br>
        /// <br>            : Redmine#44209 品番変換処理画面の制御対応</br>
        /// </remarks>
        public PMKHN01700UA()
        {
            InitializeComponent();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._executionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Run"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            // 企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._dataTable = new DataTable();
            this._subSectionAcs = new SubSectionAcs();
            this._meijiGoodsChgAllAcs = new MeijiGoodsChgAllAcs();
            this._goodsNoChangeAcs = new GoodsNoChangeAcs();//ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応
        }

        //----- ADD 2015/04/06 田建委 Redmine#44209 メニュー起動制御対応 ----->>>>>
        /// <summary>
        /// コンストラクタ（プログラマを実行する前に、日付チェック用）
        /// </summary>
        /// <param name="mode"></param>
        public PMKHN01700UA(int mode)
        {
            InitializeComponent();
        }
        //----- ADD 2015/04/06 田建委 Redmine#44209 メニュー起動制御対応 -----<<<<<
        # endregion

        # region ■ private field
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _executionButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin;
        private string _loginSection = LoginInfoAcquisition.Employee.BelongSectionCode;
        private string _loginCode = LoginInfoAcquisition.Employee.EmployeeCode;
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _enterpriseCode;                         // 企業コード
        private DataTable _dataTable;
        private bool firstStart;
        private MeijiGoodsChgAllAcs _meijiGoodsChgAllAcs;
        private SubSectionAcs _subSectionAcs;
        private string _path = string.Empty;

        // ADD 2014/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応  ------>>>>>>
        private GoodsNoChangeAcs _goodsNoChangeAcs;
        private ArrayList _goodsNoChangeAList;
        private bool _goodsNoChangeAFlg = false;
        // ADD 2014/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応  ------<<<<<<

        #endregion

        # region ■ フォームロード
        /// <summary>
        /// 画面の処理化処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 画面の処理化を行う。</br>
        /// <br>Programmer	: 陳永康</br>	
        /// <br>Date		: 2015/01/26</br>
        /// <br>UpdateNote  : 2015/04/17 zhujc </br>
        /// <br>            : Redmine#44209 品番変換処理画面の制御対応</br>
        /// </remarks>
        private void PMKHN01700UA_Load(object sender, EventArgs e)
        {
            // 画面イメージ統一
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // ADD 2014/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応  ------>>>>>>
            this._goodsNoChangeAcs.SearchAll(this._enterpriseCode, out this._goodsNoChangeAList);
            GoodsNoChangedDataCheck();
            // ADD 2014/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応  ------<<<<<<

            // グリッド初期設定処理
            this.GridInitialSetting();

            // 初回起動チェック
            firstStart = this.firstStartCheck();
            if (firstStart)
            {
                SetDeploy(false);
            }
            else
            {
                SetDeploy(true);
            }

            // 画面データの初期化設定
            this.InitializeScreen();
        }

        #region  ■ ボタン初期設定処理 ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date		: 2015/01/26</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._executionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

        }

        /// <summary>
		/// データビュー用グリッド初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : グリッドの初期設定を行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote  : 2015/04/17 zhujc </br>
        /// <br>            : Redmine#44209 品番変換処理画面の制御対応</br>
		/// </remarks>
        private void GridInitialSetting()
        {
            // グリッドの初期設定
            _dataTable.Columns.Add(DATATABLE_SLESCT, typeof(string));
            _dataTable.Columns.Add(DATATABLE_MAST, typeof(string));
            _dataTable.Columns.Add(DATATABLE_READ, typeof(string));
            _dataTable.Columns.Add(DATATABLE_UPDATE, typeof(string));
            _dataTable.Columns.Add(DATATABLE_ERR, typeof(string));

            //_dataTable.Rows.Add("", "品番変換マスタ", "0", "0", "0"); // DEL 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応
            // ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------>>>>>>
            if (!_goodsNoChangeAFlg)
            {
            _dataTable.Rows.Add("", "品番変換マスタ", "0", "0", "0");
            }
            // ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------<<<<<<

            _dataTable.Rows.Add("", "商品在庫マスタ", "0", "0", "0");
            _dataTable.Rows.Add("", "商品管理情報マスタ", "0", "0", "0");
            _dataTable.Rows.Add("", "掛率マスタ", "0", "0", "0");
            _dataTable.Rows.Add("", "結合マスタ", "0", "0", "0");
            _dataTable.Rows.Add("", "代替マスタ", "0", "0", "0");
            _dataTable.Rows.Add("", "セットマスタ", "0", "0", "0");
            _dataTable.Rows.Add("", "未計上貸出データ", "0", "0", "0");
            _dataTable.Rows.Add("", "優良設定マスタ", "0", "0", "0");// ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加

            DataView dataView = new DataView(_dataTable);
            this.gridData.DataSource = dataView;

            Infragistics.Win.UltraWinGrid.ColumnsCollection columns = this.gridData.DisplayLayout.Bands[0].Columns;

            // 表示位置初期値
            int visiblePosition = 1;

            // 選択
            columns[DATATABLE_SLESCT].Hidden = false;
            columns[DATATABLE_SLESCT].Width = 30;
            columns[DATATABLE_SLESCT].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[DATATABLE_SLESCT].Header.Caption = DATATABLE_SLESCT;
            columns[DATATABLE_SLESCT].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[DATATABLE_SLESCT].Header.VisiblePosition = visiblePosition++;

            // 処理対象
            columns[DATATABLE_MAST].Hidden = false;
            columns[DATATABLE_MAST].Width = 325;
            columns[DATATABLE_MAST].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[DATATABLE_MAST].Header.Caption = DATATABLE_MAST;
            columns[DATATABLE_MAST].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[DATATABLE_MAST].Header.VisiblePosition = visiblePosition++;

            // 読込件数
            columns[DATATABLE_READ].Hidden = false;
            columns[DATATABLE_READ].Width = 100;
            columns[DATATABLE_READ].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[DATATABLE_READ].Header.Caption = DATATABLE_READ;
            columns[DATATABLE_READ].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[DATATABLE_READ].Header.VisiblePosition = visiblePosition++;

            // 更新件数
            columns[DATATABLE_UPDATE].Hidden = false;
            columns[DATATABLE_UPDATE].Width = 100;
            columns[DATATABLE_UPDATE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[DATATABLE_UPDATE].Header.Caption = DATATABLE_UPDATE;
            columns[DATATABLE_UPDATE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[DATATABLE_UPDATE].Header.VisiblePosition = visiblePosition++;

            // エラー件数
            columns[DATATABLE_ERR].Hidden = false;
            columns[DATATABLE_ERR].Width = 100;
            columns[DATATABLE_ERR].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[DATATABLE_ERR].Header.Caption = DATATABLE_ERR;
            columns[DATATABLE_ERR].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            columns[DATATABLE_ERR].Header.VisiblePosition = visiblePosition++;
        }


        /// <summary>
        /// 初回起動チェック
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初回起動チェックを行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private bool firstStartCheck()
        {
            string workDir = null;
            // レジストリキー取得
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Product\Partsman");
            if (key == null)    // 通常はありえない
            {
                workDir = @"C:\Program Files\Partsman";     // レジストリに情報がないため、仮にデフォルトのフォルダを設定
            }
            else
            {
                workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman").ToString();
            }
            _path = Path.Combine(@workDir, "Log\\Trance_csv");

            // フォルダ存在する
            if (Directory.Exists(_path))
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(_path);
                //フォルダにログが無い
                if (di.GetFiles().Length + di.GetDirectories().Length == 0)
                {
                    return false;
                }
            }
            // フォルダ存在しない
            else
            {
                Directory.CreateDirectory(_path);
                return false;
            }
            return true;
        }
        # endregion

        #region ■ 画面データの初期化処理 ■
        /// <summary>
        /// 画面データの初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面データのを行う</br>
        /// <br>Programmer	: 陳永康</br>
        /// <br>Date		: 2015/01/26</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // 拠点
            this.tComboEditor_ChangeDiv.SelectedIndex = 0;
        }
        #endregion

        
        #endregion

        #region ■ 品番変換一括処理メッソド関連
        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 陳永康</br>	
        /// <br>Date		: 2015/01/26</br>
        /// <br>UpdateNote : 2015/05/12 呉軍 </br>
        /// <br>           : Redmine#45436 No.105 品番変換処理中に終了ボタン、実行ボタンが効いてしまうの対応</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        this.Close();
                        break;
                    }
                case "ButtonTool_Run":
                    {
                        bool inputCheck = this.ExecutBeforeCheck();

                        if (inputCheck)
                        {
                            DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "実行しますか？",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                            if (dialogResult == DialogResult.Yes)
                            {
                                changeButtonEnabled(false); // ADD 2015/05/12 呉軍 Redmine#45436 №105 
                                // 実行処理
                                this.ExecuteProcess();
                                changeButtonEnabled(true); // ADD 2015/05/12 呉軍 Redmine#45436 №105 
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: フォームロードイベント処理発生します。</br>
        /// <br>Programmer	: 陳永康</br>
        /// <br>Date		: 2015/01/26</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }
            // Grid関係処理
            if (e.PrevCtrl == gridData)
            {
                if (gridData.ActiveRow != null)
                {
                    if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                    {
                        SetValue(gridData.ActiveRow);
                        gridData.UpdateData();

                        UltraGridRow ugr = gridData.ActiveRow.GetSibling(SiblingRow.Next);
                        if (ugr != null)
                        {
                            ugr.Activate();
                            ugr.Selected = true;
                        }
                        e.NextCtrl = gridData;
                    }
                }
            }
        }

        #endregion

        #region ■ private method
        /// <summary>
        /// 品番変換一括処理処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 品番変換一括処理処理を行う。</br>
        /// <br>Programmer	: 陳永康</br>	
        /// <br>Date		: 2015/01/26</br>
        /// <br>UpdateNote  : 2015/02/25 田建委 </br>
        /// <br>            : Redmine#44209 ファイル名、処理区分等の対応</br>
        /// <br>UpdateNote  : 2015/02/26 時シン </br>
        /// <br>            : Redmine#44209 ファイル名の定義を共通化対応</br>
        /// </remarks>
        private void ExecuteProcess()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            string errMsg = string.Empty;
            string newPath = "";// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応

            GoodsChangeResultWork goodsChangeResultWork = null;

            // 処理条件を設定する
            GoodsChangeAllCndWorkWork cndWork = getCndWork();

            #region 画面件数のクリア
            this.updateGridData(goodsChangeResultWork, cndWork, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
            #endregion

            // インポート中画面部品のインスタンスを作成
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();

            try
            {
                // 表示文字を設定
                form.Title = "品番変換処理中";
                form.Message = "現在、データを変換中です。" + "\r\n" + "しばらくお待ちください";
                // ダイアログ表示
                form.Show();

                //status = _meijiGoodsChgAllAcs.GoodsChange(cndWork, _path, out goodsChangeResultWork);// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応
                status = _meijiGoodsChgAllAcs.GoodsChange(cndWork, _path, out goodsChangeResultWork, out newPath);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応

                //----- ADD 2015/02/25 田建委 Redmine#44209 ----->>>>>
                // Gridをセット
                updateGridData(goodsChangeResultWork, cndWork, status);
                //----- ADD 2015/02/25 田建委 Redmine#44209 -----<<<<<

                // ダイアログを閉じる
                form.Close();
            }
            catch (Exception)
            {
                form.Close();
                DialogResult result = TMsgDisp.Show(
                        this,													    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOP,						        // エラーレベル
                        PROGRAM_ID,											        // アセンブリＩＤまたはクラスＩＤ
                        "品番変換処理中に予期しないエラーが発生しました。" + "\r\n" + "処理区分を「全て」に設定して再度実行して下さい。",// 表示するメッセージ 
                        status,														    // ステータス値
                        MessageBoxButtons.OK,								        // 表示するボタン
                        MessageBoxDefaultButton.Button1);						    // 初期表示ボタン
            }
            //if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL || goodsChangeResultWork.ErrCntGoodsChgMst > 0) //DEL 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL || goodsChangeResultWork.ErrCntGoodsChgMst > 0 || !string.IsNullOrEmpty(goodsChangeResultWork.ErrMsg)) //ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
            {
                string resultMessage = "";
                StringBuilder builderMessage = new StringBuilder();
                //----- DEL 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
                //int allCount = goodsChangeResultWork.ReadCntGoodsChgMst + goodsChangeResultWork.ReadCntGoodsAll + goodsChangeResultWork.ReadCntMng
                //    + goodsChangeResultWork.ReadCntRate + goodsChangeResultWork.ReadCntJoin + goodsChangeResultWork.ReadCntParts
                //    + goodsChangeResultWork.ReadCntSet + goodsChangeResultWork.ReadCntShipment;
                //----- DEL 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<
                //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
                int allCount = goodsChangeResultWork.ReadCntGoodsChgMst + goodsChangeResultWork.ReadCntGoodsAll + goodsChangeResultWork.ReadCntMng
                      + goodsChangeResultWork.ReadCntRate + goodsChangeResultWork.ReadCntJoin + goodsChangeResultWork.ReadCntParts
                      + goodsChangeResultWork.ReadCntSet + goodsChangeResultWork.ReadCntShipment + goodsChangeResultWork.ReadCntPrm;
                //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<
                //if (allCount == 0)//DEL 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                if (allCount == 0 && string.IsNullOrEmpty(goodsChangeResultWork.ErrMsg)) //ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                {
                    Directory.Delete(newPath); // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応
                    errMsg = "該当するデータがありません。";
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PROGRAM_ID, errMsg, 0, MessageBoxButtons.OK);
                }
                //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------>>>>>
                // 優良設定の提供分データが取得できない場合
                else if (this._meijiGoodsChgAllAcs.ct_PRMOFFER_ERROR.Equals(goodsChangeResultWork.ErrMsg))
                {
                    // フォルダ存在する
                    if (Directory.Exists(newPath))
                    {
                        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(newPath);
                        //フォルダにログが無い
                        if (di.GetFiles().Length + di.GetDirectories().Length == 0)
                        {
                            Directory.Delete(newPath);
                        }
                    }
                    // メッセージ表示
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, PROGRAM_ID, goodsChangeResultWork.ErrMsg, 0, MessageBoxButtons.OK);
                }
                //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------<<<<<
                else
                {
                    // 品番変換マスタ
                    if (goodsChangeResultWork.ErrCntGoodsChgMst > 0 && goodsChangeResultWork.MstStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        //builderMessage.Append("\r\n" + " ・Cross_Index_Goodschg_error.csv"); // DEL 2015/02/25 田建委 Redmine#44209
                        //builderMessage.Append("\r\n ・" + ct_CROSS_INDEX_GOODSCHG_ERROR); // ADD 2015/02/25 田建委 Redmine#44209 // DEL 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                        builderMessage.Append("\r\n ・" + this._meijiGoodsChgAllAcs.ct_CROSS_INDEX_GOODSCHG_ERROR); // ADD 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                    }
                    //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
                    //// 商品在庫マスタ
                    //if (goodsChangeResultWork.ErrorCntGoods > 0 && goodsChangeResultWork.GoodsStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    //{
                    //    //builderMessage.Append("\r\n" + " ・Goods_error.csv"); // DEL 2015/02/25 田建委 Redmine#44209
                    //    //builderMessage.Append("\r\n ・" + ct_GOODS_ERROR); // ADD 2015/02/25 田建委 Redmine#44209 // DEL 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                    //    builderMessage.Append("\r\n ・" + this._meijiGoodsChgAllAcs.ct_GOODS_ERROR); // ADD 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                    //}
                    //if (goodsChangeResultWork.ErrorCntPrice > 0 && goodsChangeResultWork.PriceStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    //{
                    //    //builderMessage.Append("\r\n" + " ・GoodsPrice_error.csv"); // DEL 2015/02/25 田建委 Redmine#44209
                    //    //builderMessage.Append("\r\n ・" + ct_GOODSPRICE_ERROR); // ADD 2015/02/25 田建委 Redmine#44209 // DEL 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                    //    builderMessage.Append("\r\n ・" + this._meijiGoodsChgAllAcs.ct_GOODSPRICE_ERROR); // ADD 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                    //}
                    //if (goodsChangeResultWork.ErrorCntStock > 0 && goodsChangeResultWork.StockStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    //{
                    //    //builderMessage.Append("\r\n" + " ・Stock_error.csv"); // DEL 2015/02/25 田建委 Redmine#44209
                    //    //builderMessage.Append("\r\n ・" + ct_STOCK_ERROR); // ADD 2015/02/25 田建委 Redmine#44209 // DEL 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                    //    builderMessage.Append("\r\n ・" + this._meijiGoodsChgAllAcs.ct_STOCK_ERROR); // ADD 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                    //}
                    //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
                    //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
                    // 商品在庫マスタ
                    if (goodsChangeResultWork.ErrorCntGoods > 0 && goodsChangeResultWork.GoodsStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        builderMessage.Append("\r\n ・" + this._meijiGoodsChgAllAcs.ct_GOODSSTOCK_ERROR);
                    }
                    //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
                    // 管理情報マスタ
                    if (goodsChangeResultWork.ErrorCntMng > 0 && goodsChangeResultWork.MngStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        //builderMessage.Append("\r\n" + " ・GoodsMng_error.csv"); // DEL 2015/02/25 田建委 Redmine#44209
                        //builderMessage.Append("\r\n ・" + ct_GOODSMNG_ERROR); // ADD 2015/02/25 田建委 Redmine#44209 // DEL 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                        builderMessage.Append("\r\n ・" + this._meijiGoodsChgAllAcs.ct_GOODSMNG_ERROR); // ADD 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                    }
                    // 掛率マスタ
                    if (goodsChangeResultWork.ErrorCntRate > 0 && goodsChangeResultWork.RateStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        //builderMessage.Append("\r\n" + " ・Rate_error.csv"); // DEL 2015/02/25 田建委 Redmine#44209
                        //builderMessage.Append("\r\n ・" + ct_RATE_ERROR); // ADD 2015/02/25 田建委 Redmine#44209 // DEL 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                        builderMessage.Append("\r\n ・" + this._meijiGoodsChgAllAcs.ct_RATE_ERROR); // ADD 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                    }
                    // 結合マスタ
                    if (goodsChangeResultWork.ErrorCntJoin > 0 && goodsChangeResultWork.JoinStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        //builderMessage.Append("\r\n" + " ・JoinParts_error.csv"); // DEL 2015/02/25 田建委 Redmine#44209
                        //builderMessage.Append("\r\n ・" + ct_JOINPARTS_ERROR); // ADD 2015/02/25 田建委 Redmine#44209 // DEL 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                        builderMessage.Append("\r\n ・" + this._meijiGoodsChgAllAcs.ct_JOINPARTS_ERROR); // ADD 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                    }
                    // 代替マスタ
                    if (goodsChangeResultWork.ErrCntParts > 0 && goodsChangeResultWork.PartsStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        //builderMessage.Append("\r\n" + " ・Subst_error.csv"); // DEL 2015/02/25 田建委 Redmine#44209
                        //builderMessage.Append("\r\n ・" + ct_SUBST_ERROR); // ADD 2015/02/25 田建委 Redmine#44209 // DEL 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                        builderMessage.Append("\r\n ・" + this._meijiGoodsChgAllAcs.ct_SUBST_ERROR); // ADD 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                    }
                    // セットマスタ
                    if (goodsChangeResultWork.ErrCntSet > 0 && goodsChangeResultWork.SetStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        //builderMessage.Append("\r\n" + " ・GoodsSet_error.csv"); // DEL 2015/02/25 田建委 Redmine#44209
                        //builderMessage.Append("\r\n ・" + ct_GOODSSET_ERROR); // ADD 2015/02/25 田建委 Redmine#44209 // DEL 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                        builderMessage.Append("\r\n ・" + this._meijiGoodsChgAllAcs.ct_GOODSSET_ERROR); // ADD 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                    }
                    // 未計上貸出データ
                    if (goodsChangeResultWork.ErrCntShipment > 0 && goodsChangeResultWork.ShipmentStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        //builderMessage.Append("\r\n" + " ・RentData_error.csv"); // DEL 2015/02/25 田建委 Redmine#44209
                        //builderMessage.Append("\r\n ・" + ct_RENTDATA_ERROR); // ADD 2015/02/25 田建委 Redmine#44209 // DEL 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                        builderMessage.Append("\r\n ・" + this._meijiGoodsChgAllAcs.ct_RENTDATA_ERROR); // ADD 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応
                    }
                    //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
                    // 優良設定マスタ
                    if (goodsChangeResultWork.ErrCntPrm > 0 && goodsChangeResultWork.PrmStatusErrCSV == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        builderMessage.Append("\r\n ・" + this._meijiGoodsChgAllAcs.ct_PRMSETTING_ERROR);
                    }
                    //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<

                    // エラーデータがある
                    if (!string.IsNullOrEmpty(builderMessage.ToString()))
                    {
                        // --- DEL 2015/02/17 時シン Redmine#44209 パスの部分から改行されていない対応 -------------->>>>>
                        //resultMessage = "変換に失敗した行があります。" + "\r\n" + "下記エラーログを参照して下さい。" 
                        //    + _path + "\\"  + builderMessage.ToString();
                        // --- DEL 2015/02/17 時シン Redmine#44209 パスの部分から改行されていない対応 --------------<<<<<
                        // --- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応 ----->>>>>
                        // --- ADD 2015/02/17 時シン Redmine#44209 パスの部分から改行されていない対応 -------------->>>>>
                        //resultMessage = "変換に失敗した行があります。" + "\r\n" +"ログフォルダ表示ボタンを押してログフォルダを開き、"+"\r\n" + "下記エラーログを参照して下さい。" + "\r\n" + "\r\n"
                        //    + _path + "\\" + builderMessage.ToString();
                        // --- ADD 2015/02/17 時シン Redmine#44209 パスの部分から改行されていない対応 --------------<<<<<
                        // --- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応 -----<<<<<
                        // --- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応 ----->>>>>
                        resultMessage = "変換に失敗した行があります。" + "\r\n" + "ログフォルダ表示ボタンを押してログフォルダを開き、" + "\r\n" + "下記エラーログを参照して下さい。" + "\r\n" + "\r\n"
                            + newPath + "\\" + builderMessage.ToString();
                        // --- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応 -----<<<<<
                        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
                        if (!string.IsNullOrEmpty(goodsChangeResultWork.ErrMsg))
                        {
                            resultMessage = resultMessage + "\r\n" + "\r\n" + goodsChangeResultWork.ErrMsg;
                        }
                    }
                    else
                    {
                        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
                        if (!string.IsNullOrEmpty(goodsChangeResultWork.ErrMsg))
                        {
                            resultMessage = goodsChangeResultWork.ErrMsg;
                        }
                        else
                        {
                            //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<<
                            // 正常な完了
                            if (goodsChangeResultWork.LogCSVOpen == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsChangeResultWork.ErrLogCSVOpen == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                resultMessage = "マスタ変換処理が完了しました。";
                            }
                        }//ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                    }

                    // メッセージ表示
                    if (!string.IsNullOrEmpty(resultMessage))
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PROGRAM_ID, resultMessage, 0, MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                // --- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応 --->>>>>
                // フォルダ存在する
                if (Directory.Exists(newPath))
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(newPath);
                    //フォルダにログが無い
                    if (di.GetFiles().Length + di.GetDirectories().Length == 0)
                    {
                        Directory.Delete(newPath);
                    }
                }
                // --- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応 ---<<<<<
                // --- DEL 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
                //if (!string.IsNullOrEmpty(goodsChangeResultWork.ErrMsg))
                //{
                //    DialogResult result = TMsgDisp.Show(
                //        this,													    // 親ウィンドウフォーム
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,						    // エラーレベル
                //        PROGRAM_ID,											        // アセンブリＩＤまたはクラスＩＤ
                //        goodsChangeResultWork.ErrMsg,                               // 表示するメッセージ 
                //        status,														// ステータス値
                //        MessageBoxButtons.OK,								        // 表示するボタン
                //        MessageBoxDefaultButton.Button1);						    // 初期表示ボタン
                //}
                //else
                //{
                    // --- DEL 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<
                    DialogResult result = TMsgDisp.Show(
                        this,													    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOP,						        // エラーレベル
                        PROGRAM_ID,											        // アセンブリＩＤまたはクラスＩＤ
                        "品番変換処理中に予期しないエラーが発生しました。" + "\r\n" + "処理区分を「全て」に設定して再度実行して下さい。",// 表示するメッセージ 
                        status,														    // ステータス値
                        MessageBoxButtons.OK,								        // 表示するボタン
                        MessageBoxDefaultButton.Button1);						    // 初期表示ボタン
                //}//  DEL 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
            }

            //----- DEL 2015/02/25 田建委 Redmine#44209 ----->>>>>
            //// Gridをセット
            //updateGridData(goodsChangeResultWork, cndWork, status);
            //----- DEL 2015/02/25 田建委 Redmine#44209 -----<<<<<
        }

        /// <summary>
        /// チェック処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: チェック処理を行う。</br>
        /// <br>Programmer	: 陳永康</br>	
        /// <br>Date		: 2015/01/26</br>
        /// </remarks>
        private bool ExecutBeforeCheck()
        {
            int checkeCount = 0;
            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                if (CHECKFLG.Equals(_dataTable.Rows[i][0]))
                {
                    checkeCount++;
                }
            }
            if (checkeCount == 0)
            {
                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                    "品番変換処理対象を選んで下さい。",	// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                return false;
            }

            return true;
        }

        /// <summary>
        /// 処理条件を設定する
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 処理条件の設定を行う。</br>
        /// <br>Programmer	: 陳永康</br>	
        /// <br>Date		: 2015/01/26</br>
        /// <br>UpdateNote  : 2015/04/17 zhujc </br>
        /// <br>            : Redmine#44209 品番変換処理画面の制御対応</br>
        /// </remarks>
        private GoodsChangeAllCndWorkWork getCndWork()
        {
            GoodsChangeAllCndWorkWork cndWork = new GoodsChangeAllCndWorkWork();
            cndWork.EnterpriseCode = this._enterpriseCode;
            cndWork.LoginEmpleeCode = this._loginCode;
            cndWork.LoginEmpleeName = this._loginName;
            cndWork.LoginSectionCode = this._loginSection;
            cndWork.LoginSectionNm = this._subSectionAcs.GetSectionName(this._loginSection);

            cndWork.ChangeDiv = this.tComboEditor_ChangeDiv.SelectedIndex;

            #region DEL 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応
            /* 
            if (CHECKFLG.Equals(_dataTable.Rows[0][0]))
            {
                cndWork.GoodsChangeMstDiv = 1;
            }
            else
            {
                cndWork.GoodsChangeMstDiv = 0;
            }
            if (CHECKFLG.Equals(_dataTable.Rows[1][0]))
            {
                cndWork.GoodsMstDiv = 1;
            }
            else
            {
                cndWork.GoodsMstDiv = 0;
            }
            if (CHECKFLG.Equals(_dataTable.Rows[2][0]))
            {
                cndWork.GoodsMngMstDiv = 1;
            }
            else
            {
                cndWork.GoodsMngMstDiv = 0;
            }
            if (CHECKFLG.Equals(_dataTable.Rows[3][0]))
            {
                cndWork.RateMstDiv = 1;
            }
            else
            {
                cndWork.RateMstDiv = 0;
            }
            if (CHECKFLG.Equals(_dataTable.Rows[4][0]))
            {
                cndWork.JoinMstDiv = 1;
            }
            else
            {
                cndWork.JoinMstDiv = 0;
            }
            if (CHECKFLG.Equals(_dataTable.Rows[5][0]))
            {
                cndWork.PartsMstDiv = 1;
            }
            else
            {
                cndWork.PartsMstDiv = 0;
            }
            if (CHECKFLG.Equals(_dataTable.Rows[6][0]))
            {
                cndWork.SetMstDiv = 1;
            }
            else
            {
                cndWork.SetMstDiv = 0;
            }
            if (CHECKFLG.Equals(_dataTable.Rows[7][0]))
            {
                cndWork.ShipmentDiv = 1;
            }
            else
            {
                cndWork.ShipmentDiv = 0;
            }
            //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
            if (CHECKFLG.Equals(_dataTable.Rows[8][0]))
            {
                cndWork.PrmMstDiv = 1;
            }
            else
            {
                cndWork.PrmMstDiv = 0;
            }
            //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<
            */
            #endregion DEL Redmine#44209 品番変換処理画面の制御対応
            // ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------>>>>>>
            foreach (DataRow dataRow in _dataTable.Rows)
            {
                if (dataRow[DATATABLE_SLESCT].ToString().Equals(CHECKFLG))
                {
                    this.getCndWorkProc(ref cndWork, dataRow, 1);
                }
                else
                {
                    this.getCndWorkProc(ref cndWork, dataRow, 0);
                }
            }
            // ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------<<<<<<
            return cndWork;
        }

        /// <summary>
        /// 件数のセット
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 件数のセットを行う。</br>
        /// <br>Programmer	: 陳永康</br>	
        /// <br>Date		: 2015/01/26</br>
        /// <br>UpdateNote  : 2015/04/17 zhujc </br>
        /// <br>            : Redmine#44209 品番変換処理画面の制御対応</br>
        /// </remarks>
        private void updateGridData(GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork, int status)
        {
            #region DEL 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応
            /*
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // 品番変換マスタ
                _dataTable.Rows[0][2] = goodsChangeResultWork.ReadCntGoodsChgMst.ToString("#,###,##0");
                _dataTable.Rows[0][3] = goodsChangeResultWork.LoadCntGoodsChgMst.ToString("#,###,##0");
                _dataTable.Rows[0][4] = goodsChangeResultWork.ErrCntGoodsChgMst.ToString("#,###,##0");
                // 商品在庫マスタ
                _dataTable.Rows[1][2] = goodsChangeResultWork.ReadCntGoodsAll.ToString("#,###,##0");
                _dataTable.Rows[1][3] = goodsChangeResultWork.LoadCntGoodsAll.ToString("#,###,##0");
                _dataTable.Rows[1][4] = goodsChangeResultWork.ErrCntGoodsAll.ToString("#,###,##0");
                // 管理情報マスタ
                _dataTable.Rows[2][2] = goodsChangeResultWork.ReadCntMng.ToString("#,###,##0");
                _dataTable.Rows[2][3] = goodsChangeResultWork.LoadCntMng.ToString("#,###,##0");
                _dataTable.Rows[2][4] = goodsChangeResultWork.ErrorCntMng.ToString("#,###,##0");
                // 掛率マスタ
                _dataTable.Rows[3][2] = goodsChangeResultWork.ReadCntRate.ToString("#,###,##0");
                _dataTable.Rows[3][3] = goodsChangeResultWork.LoadCntRate.ToString("#,###,##0");
                _dataTable.Rows[3][4] = goodsChangeResultWork.ErrorCntRate.ToString("#,###,##0");
                // 結合マスタ
                _dataTable.Rows[4][2] = goodsChangeResultWork.ReadCntJoin.ToString("#,###,##0");
                _dataTable.Rows[4][3] = goodsChangeResultWork.LoadCntJoin.ToString("#,###,##0");
                _dataTable.Rows[4][4] = goodsChangeResultWork.ErrorCntJoin.ToString("#,###,##0");
                // 代替マスタ
                _dataTable.Rows[5][2] = goodsChangeResultWork.ReadCntParts.ToString("#,###,##0");
                _dataTable.Rows[5][3] = goodsChangeResultWork.LoadCntParts.ToString("#,###,##0");
                _dataTable.Rows[5][4] = goodsChangeResultWork.ErrCntParts.ToString("#,###,##0");
                // セットマスタ
                _dataTable.Rows[6][2] = goodsChangeResultWork.ReadCntSet.ToString("#,###,##0");
                _dataTable.Rows[6][3] = goodsChangeResultWork.LoadCntSet.ToString("#,###,##0");
                _dataTable.Rows[6][4] = goodsChangeResultWork.ErrCntSet.ToString("#,###,##0");
                // 未計上貸出データ
                _dataTable.Rows[7][2] = goodsChangeResultWork.ReadCntShipment.ToString("#,###,##0");
                _dataTable.Rows[7][3] = goodsChangeResultWork.LoadCntShipment.ToString("#,###,##0");
                _dataTable.Rows[7][4] = goodsChangeResultWork.ErrCntShipment.ToString("#,###,##0");
                //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
                // 優良設定マスタ
                _dataTable.Rows[8][2] = goodsChangeResultWork.ReadCntPrm.ToString("#,###,##0");
                _dataTable.Rows[8][3] = goodsChangeResultWork.LoadCntPrm.ToString("#,###,##0");
                _dataTable.Rows[8][4] = goodsChangeResultWork.ErrCntPrm.ToString("#,###,##0");
                //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<
            }
            else
            {
                // 品番変換マスタ
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[0][2] = 0;
                    _dataTable.Rows[0][3] = 0;
                    _dataTable.Rows[0][4] = 0;
                }
                else
                {
                    _dataTable.Rows[0][2] = goodsChangeResultWork.ReadCntGoodsChgMst.ToString("#,###,##0");
                    _dataTable.Rows[0][3] = goodsChangeResultWork.LoadCntGoodsChgMst.ToString("#,###,##0");
                    _dataTable.Rows[0][4] = goodsChangeResultWork.ErrCntGoodsChgMst.ToString("#,###,##0");
                }
                //----- DEL 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
                // 商品在庫マスタ
                //_dataTable.Rows[1][2] = 0;
                //_dataTable.Rows[1][3] = 0;
                //_dataTable.Rows[1][4] = 0;
                //// 管理情報マスタ
                //_dataTable.Rows[2][2] = 0;
                //_dataTable.Rows[2][3] = 0;
                //_dataTable.Rows[2][4] = 0;
                //// 掛率マスタ
                //_dataTable.Rows[3][2] = 0;
                //_dataTable.Rows[3][3] = 0;
                //_dataTable.Rows[3][4] = 0;
                //// 結合マスタ
                //_dataTable.Rows[4][2] = 0;
                //_dataTable.Rows[4][3] = 0;
                //_dataTable.Rows[4][4] = 0;
                //// 代替マスタ
                //_dataTable.Rows[5][2] = 0;
                //_dataTable.Rows[5][3] = 0;
                //_dataTable.Rows[5][4] = 0;
                //// セットマスタ
                //_dataTable.Rows[6][2] = 0;
                //_dataTable.Rows[6][3] = 0;
                //_dataTable.Rows[6][4] = 0;
                //----- DEL 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<
                //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
                // 商品在庫マスタ
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[1][2] = 0;
                    _dataTable.Rows[1][3] = 0;
                    _dataTable.Rows[1][4] = 0;
                }
                else
                {
                    _dataTable.Rows[1][2] = goodsChangeResultWork.ReadCntGoodsAll.ToString("#,###,##0");
                    _dataTable.Rows[1][3] = goodsChangeResultWork.LoadCntGoodsAll.ToString("#,###,##0");
                    _dataTable.Rows[1][4] = goodsChangeResultWork.ErrCntGoodsAll.ToString("#,###,##0");
                }
                // 管理情報マスタ
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[2][2] = 0;
                    _dataTable.Rows[2][3] = 0;
                    _dataTable.Rows[2][4] = 0;
                }
                else
                {
                    _dataTable.Rows[2][2] = goodsChangeResultWork.ReadCntMng.ToString("#,###,##0");
                    _dataTable.Rows[2][3] = goodsChangeResultWork.LoadCntMng.ToString("#,###,##0");
                    _dataTable.Rows[2][4] = goodsChangeResultWork.ErrorCntMng.ToString("#,###,##0");
                }
                // 掛率マスタ
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[3][2] = 0;
                    _dataTable.Rows[3][3] = 0;
                    _dataTable.Rows[3][4] = 0;
                }
                else
                {
                    _dataTable.Rows[3][2] = goodsChangeResultWork.ReadCntRate.ToString("#,###,##0");
                    _dataTable.Rows[3][3] = goodsChangeResultWork.LoadCntRate.ToString("#,###,##0");
                    _dataTable.Rows[3][4] = goodsChangeResultWork.ErrorCntRate.ToString("#,###,##0");
                }
                // 結合マスタ
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[4][2] = 0;
                    _dataTable.Rows[4][3] = 0;
                    _dataTable.Rows[4][4] = 0;
                }
                else
                {
                    _dataTable.Rows[4][2] = goodsChangeResultWork.ReadCntJoin.ToString("#,###,##0");
                    _dataTable.Rows[4][3] = goodsChangeResultWork.LoadCntJoin.ToString("#,###,##0");
                    _dataTable.Rows[4][4] = goodsChangeResultWork.ErrorCntJoin.ToString("#,###,##0");
                }
                // 代替マスタ
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[5][2] = 0;
                    _dataTable.Rows[5][3] = 0;
                    _dataTable.Rows[5][4] = 0;
                }
                else
                {
                    _dataTable.Rows[5][2] = goodsChangeResultWork.ReadCntParts.ToString("#,###,##0");
                    _dataTable.Rows[5][3] = goodsChangeResultWork.LoadCntParts.ToString("#,###,##0");
                    _dataTable.Rows[5][4] = goodsChangeResultWork.ErrCntParts.ToString("#,###,##0");
                }
                // セットマスタ
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[6][2] = 0;
                    _dataTable.Rows[6][3] = 0;
                    _dataTable.Rows[6][4] = 0;
                }
                else
                {
                    _dataTable.Rows[6][2] = goodsChangeResultWork.ReadCntSet.ToString("#,###,##0");
                    _dataTable.Rows[6][3] = goodsChangeResultWork.LoadCntSet.ToString("#,###,##0");
                    _dataTable.Rows[6][4] = goodsChangeResultWork.ErrCntSet.ToString("#,###,##0");
                }
                //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<
                // 未計上貸出データ
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[7][2] = 0;
                    _dataTable.Rows[7][3] = 0;
                    _dataTable.Rows[7][4] = 0;
                }
                else
                {
                    _dataTable.Rows[7][2] = goodsChangeResultWork.ReadCntShipment.ToString("#,###,##0");
                    _dataTable.Rows[7][3] = goodsChangeResultWork.LoadCntShipment.ToString("#,###,##0");
                    _dataTable.Rows[7][4] = goodsChangeResultWork.ErrCntShipment.ToString("#,###,##0");
                }
                //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
                // 優良設定マスタ
                if (goodsChangeResultWork == null)
                {
                    _dataTable.Rows[8][2] = 0;
                    _dataTable.Rows[8][3] = 0;
                    _dataTable.Rows[8][4] = 0;
                }
                else
                {
                    _dataTable.Rows[8][2] = goodsChangeResultWork.ReadCntPrm.ToString("#,###,##0");
                    _dataTable.Rows[8][3] = goodsChangeResultWork.LoadCntPrm.ToString("#,###,##0");
                    _dataTable.Rows[8][4] = goodsChangeResultWork.ErrCntPrm.ToString("#,###,##0");
                }
                //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<
            }
            */
            #endregion DEL 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応

            //ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------>>>>>>
            if (goodsChangeResultWork == null)
            {
                for (int rowIndex = 0; rowIndex < _dataTable.Rows.Count; rowIndex++)
                {
                    _dataTable.Rows[rowIndex][2] = 0;
                    _dataTable.Rows[rowIndex][3] = 0;
                    _dataTable.Rows[rowIndex][4] = 0;
                }
            }
            else
            {
                for (int rowIndex = 0; rowIndex < _dataTable.Rows.Count; rowIndex++)
                {
                    if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_GOODSNOCHANGERF))
                    {
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntGoodsChgMst.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntGoodsChgMst.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrCntGoodsChgMst.ToString("#,###,##0");
                    }
                    else if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_GOODSUSTOCKRF))
                    {
                        // 商品在庫マスタ
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntGoodsAll.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntGoodsAll.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrCntGoodsAll.ToString("#,###,##0");
                    }
                    else if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_GOODSMNGRF))
                    {
                        // 管理情報マスタ
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntMng.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntMng.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrorCntMng.ToString("#,###,##0");
                    }
                    else if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_RATERF))
                    {
                        // 掛率マスタ
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntRate.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntRate.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrorCntRate.ToString("#,###,##0");
                    }
                    else if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_JOINPARTSURF))
                    {
                        // 結合マスタ
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntJoin.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntJoin.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrorCntJoin.ToString("#,###,##0");
                    }
                    else if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_PARTSSUBSTURF))
                    {
                        // 代替マスタ
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntParts.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntParts.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrCntParts.ToString("#,###,##0");
                    }
                    else if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_GOODSSETRF))
                    {
                        // セットマスタ
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntSet.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntSet.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrCntSet.ToString("#,###,##0");
                    }
                    else if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_SALESDETAILRF))
                    {
                        // 未計上貸出データ
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntShipment.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntShipment.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrCntShipment.ToString("#,###,##0");
                    }
                    else if (_dataTable.Rows[rowIndex][DATATABLE_MAST].ToString().Equals(ct_PRMSETTINGURF))
                    {
                        // 優良設定マスタ
                        _dataTable.Rows[rowIndex][2] = goodsChangeResultWork.ReadCntPrm.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][3] = goodsChangeResultWork.LoadCntPrm.ToString("#,###,##0");
                        _dataTable.Rows[rowIndex][4] = goodsChangeResultWork.ErrCntPrm.ToString("#,###,##0");
                    }
                }

            }
            //ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------<<<<<<

        }

        // ADD 2015/02/25 宋剛 Redmine#44209 No.35 ログフォルダを開くボタン追加----->>>>> 
        /// <summary>
        /// ログフォルダ表示
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void ultraButtonLogOutput_Click(object sender, EventArgs e)
        {
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応----->>>>>
            DirectoryInfo di = new DirectoryInfo(_path);
            //----- ADD 2015/04/30 時シン No.100 Clientのログフォルダが存在しない状態でログフォルダ表示ボタンを押下すると例外エラーが発生する対応------>>>>>
            // フォルダ存在する
            if (!Directory.Exists(_path))
            {
                TMsgDisp.Show(
                                this,								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                                PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                                "ログフォルダが存在しません。",	    // 表示するメッセージ 
                                0,									// ステータス値
                                MessageBoxButtons.OK);				// 表示するボタン
            }
            else
            {
                //----- ADD 2015/04/30 時シン No.100 Clientのログフォルダが存在しない状態でログフォルダ表示ボタンを押下すると例外エラーが発生する対応------<<<<<
                DirectoryInfo[] files = di.GetDirectories();
                string path = string.Empty;
                if (di.GetDirectories().Length > 0)
                {
                    FileComparer fc = new FileComparer();
                    Array.Sort(files, fc);
                    path = files[0].FullName;
                }
                else
                {
                    path = _path;
                }
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応-----<<<<<
                //System.Diagnostics.Process.Start("explorer.exe", _path); //DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応
                System.Diagnostics.Process.Start("explorer.exe", path); //ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応
            }
        }//ADD 2015/04/30 時シン No.100 Clientのログフォルダが存在しない状態でログフォルダ表示ボタンを押下すると例外エラーが発生する対応
        // ADD 2015/02/25 宋剛 Redmine#44209 No.35 ログフォルダを開くボタン追加-----<<<<<

        #endregion

        #region ■ Event
        #region Grid Event
        /// <summary>
        /// gridData_Leave
        /// </summary>
        /// <remarks>		
        /// <br>Note		: GridのLeave Eventを行う。</br>
        /// <br>Programmer	: 陳永康</br>	
        /// <br>Date		: 2015/01/26</br>
        /// </remarks>
        private void gridData_Leave(object sender, EventArgs e)
        {
            gridData.Selected.Rows.Clear();
        }

        /// <summary>
        /// gridData_Enter
        /// </summary>
        /// <remarks>		
        /// <br>Note		: GridのEnter Eventを行う。</br>
        /// <br>Programmer	: 陳永康</br>	
        /// <br>Date		: 2015/01/26</br>
        /// </remarks>
        private void gridData_Enter(object sender, EventArgs e)
        {
            if (gridData.Selected.Rows.Count == 0)
            {
                if (gridData.ActiveRow != null)
                {
                    gridData.ActiveRow.Selected = true;
                }
                else
                {
                    if (gridData.Rows.Count > 0)
                    {
                        gridData.Rows[0].Activate();
                        gridData.Rows[0].Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// gridData_DoubleClickRow
        /// </summary>
        /// <remarks>		
        /// <br>Note		: GridのDoubleClickRow Eventを行う。</br>
        /// <br>Programmer	: 陳永康</br>	
        /// <br>Date		: 2015/01/26</br>
        /// </remarks>
        private void gridData_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            SetValue(e.Row);

            gridData.UpdateData();
        }

        /// <summary>
        /// 選択状態更新処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 選択状態更新処理を行う。</br>
        /// <br>Programmer	: 陳永康</br>	
        /// <br>Date		: 2015/01/26</br>
        /// <br>UpdateNote  : 2015/04/17 zhujc </br>
        /// <br>            : Redmine#44209 品番変換処理画面の制御対応</br>
        /// </remarks>
        private void SetValue(UltraGridRow row)
        {
            UltraGridCell cell = row.Cells[0];
            string val = string.Empty;
            if (this.tComboEditor_ChangeDiv.SelectedIndex == 0)
            {
                if (cell.Value.Equals(CHECKFLG))
                {
                    val = string.Empty;
                }
                else
                {
                    val = CHECKFLG;
                }
                cell.Value = val;
            }
            else
            {
                //if (row.Index != 0 && row.Index != 7) // DEL 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                //if (row.Index != 0 && row.Index != 7 && row.Index != 8) // ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 //DEL 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応
                if (!((row.Cells[DATATABLE_MAST].Text).Equals(ct_GOODSNOCHANGERF)
                    ||(row.Cells[DATATABLE_MAST].Text).Equals(ct_SALESDETAILRF)
                    || (row.Cells[DATATABLE_MAST].Text).Equals(ct_PRMSETTINGURF))) //ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応
                {
                    if (cell.Value.Equals(CHECKFLG))
                    {
                        val = string.Empty;
                    }
                    else
                    {
                        val = CHECKFLG;
                    }
                    cell.Value = val;
                }
            }
        }

        /// <summary>
        /// gridData_KeyDown
        /// </summary>
        /// <remarks>		
        /// <br>Note		: GridのKeyDown Eventを行う。</br>
        /// <br>Programmer	: 陳永康</br>	
        /// <br>Date		: 2015/01/26</br>
        /// </remarks>
        private void gridData_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridData.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    SetValue(gridData.ActiveRow);

                    gridData.UpdateData();

                    UltraGridRow ugr = gridData.ActiveRow.GetSibling(SiblingRow.Next);
                    if (ugr != null)
                    {
                        ugr.Activate();
                        ugr.Selected = true;
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// [全て解除]ボタン押下イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_ClearAll_Click(object sender, EventArgs e)
        {
            SetDeploy(false);
        }

        /// <summary>
        /// [全て選択]ボタン押下イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SelectAll_Click(object sender, EventArgs e)
        {
            SetDeploy(false);
            SetDeploy(true);
        }

        /// <summary>
        /// 展開区分設定
        /// </summary>
        /// <param name="flg">true: 全選択/false: 全解除</param>
        /// <br>UpdateNote  : 2015/04/17 zhujc </br>
        /// <br>            : Redmine#44209 品番変換処理画面の制御対応</br>
        private void SetDeploy(bool flg)
        {
            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                DataRow dw = _dataTable.Rows[i];
                if (flg)
                {
                    //if ((i == 0 || i == 7) && this.tComboEditor_ChangeDiv.SelectedIndex == 1) // DEL 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
                    //if ((i == 0 || i == 7 || i == 8) && this.tComboEditor_ChangeDiv.SelectedIndex == 1) // ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加 //DEL 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応
                    if (
                        (
                        dw[DATATABLE_MAST].ToString().Equals(ct_GOODSNOCHANGERF) || 
                        dw[DATATABLE_MAST].ToString().Equals(ct_SALESDETAILRF) || 
                        dw[DATATABLE_MAST].ToString().Equals(ct_PRMSETTINGURF)
                        ) &&
                        this.tComboEditor_ChangeDiv.SelectedIndex == 1) //ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応
                    {
                        _dataTable.Rows[i][0] = string.Empty;
                    }
                    else
                    {
                        _dataTable.Rows[i][0] = CHECKFLG;
                    }
                }
                else
                {
                    _dataTable.Rows[i][0] = string.Empty;
                }
            }
        }

        /// <summary>
        /// 処理区分
        /// </summary>
        /// <br>UpdateNote  : 2015/04/17 zhujc </br>
        /// <br>            : Redmine#44209 品番変換処理画面の制御対応</br>
        private void tComboEditor_ChangeDiv_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_ChangeDiv.SelectedIndex == 0)
            {
                // DEL 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------>>>>>>
                //gridData.Rows[0].Appearance.BackColor = Color.White;
                //gridData.Rows[0].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                //gridData.Rows[7].Appearance.BackColor = gridData.Rows[1].Appearance.BackColor;
                //gridData.Rows[7].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                ////----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
                //gridData.Rows[8].Appearance.BackColor = Color.White;
                //gridData.Rows[8].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                ////----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<
                // DEL 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------<<<<<<

                //ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------>>>>>>
                string targetRow = "";
                for (int rowIndex = 0; rowIndex < gridData.Rows.Count; rowIndex++ )
                {
                    targetRow = gridData.Rows[rowIndex].Cells[DATATABLE_MAST].Text;
                    if (targetRow.Equals(ct_GOODSNOCHANGERF)
                        || targetRow.Equals(ct_SALESDETAILRF)
                        || targetRow.Equals(ct_PRMSETTINGURF))
                    {
                        if (rowIndex == 0 || (rowIndex % 2) == 0)
                        {
                            gridData.Rows[rowIndex].Appearance.BackColor = Color.White;
            }
            else
            {
                            gridData.Rows[rowIndex].Appearance.BackColor = gridData.Rows[1].Appearance.BackColor;
                        }
                        gridData.Rows[rowIndex].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    }
                }
                //ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------<<<<<<
            }
            else
            {
                // DEL 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------>>>>>>
                //gridData.Rows[0].Appearance.BackColor = Color.Gainsboro;
                //_dataTable.Rows[0][0] = string.Empty;
                //gridData.Rows[0].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                //gridData.Rows[7].Appearance.BackColor = Color.Gainsboro;
                //_dataTable.Rows[7][0] = string.Empty;
                //gridData.Rows[7].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                ////----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
                //gridData.Rows[8].Appearance.BackColor = Color.Gainsboro;
                //_dataTable.Rows[8][0] = string.Empty;
                //gridData.Rows[8].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                ////----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<
                // DEL 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------<<<<<<

                // ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------>>>>>>
                string targetRow = "";
                for (int rowIndex = 0; rowIndex < gridData.Rows.Count; rowIndex++)
                {
                    targetRow = gridData.Rows[rowIndex].Cells[DATATABLE_MAST].Text;
                    if (targetRow.Equals(ct_GOODSNOCHANGERF)
                        || targetRow.Equals(ct_SALESDETAILRF)
                        || targetRow.Equals(ct_PRMSETTINGURF))
                    {
                        gridData.Rows[rowIndex].Appearance.BackColor = Color.Gainsboro;
                        _dataTable.Rows[rowIndex][0] = string.Empty;
                        gridData.Rows[rowIndex].Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                    }
                }
                // ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------<<<<<<
            }
        }

        #endregion

        //ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------>>>>>>
        #region Redmine#44209 配信で品番変換マスタ取込むことにより、品番変換処理画面の制御対応
        /// <summary>
        /// 品番変換処理画面の制御
        /// </summary>
        /// <remarks>
        /// <br>Note       : 品番変換処理画面の制御</br>
        /// <br>Programmer : zhujc</br>
        /// <br>Date       : 2015/04/17</br>
        /// </remarks>
        private void GoodsNoChangedDataCheck()
        {
            if(this._goodsNoChangeAList != null && this._goodsNoChangeAList.Count > 0)
            {
                this._goodsNoChangeAFlg = true;
            }
        }

        /// <summary>
        /// 処理条件の設定
        /// </summary>
        /// <param name="cndWork">処理条件</param>
        /// <param name="dataRow">行データ</param>
        /// <param name="setValue">設定値</param>
        private void getCndWorkProc(ref GoodsChangeAllCndWorkWork cndWork, DataRow dataRow, int setValue)
        {
            if (dataRow[DATATABLE_MAST].ToString().Equals(ct_GOODSNOCHANGERF))
            {
                cndWork.GoodsChangeMstDiv = setValue;
            }
            else if (dataRow[DATATABLE_MAST].ToString().Equals(ct_GOODSUSTOCKRF))
            {
                cndWork.GoodsMstDiv = setValue;
            }
            else if (dataRow[DATATABLE_MAST].ToString().Equals(ct_GOODSMNGRF))
            {
                cndWork.GoodsMngMstDiv = setValue;
            }
            else if (dataRow[DATATABLE_MAST].ToString().Equals(ct_RATERF))
            {
                cndWork.RateMstDiv = setValue;
            }
            else if (dataRow[DATATABLE_MAST].ToString().Equals(ct_JOINPARTSURF))
            {
                cndWork.JoinMstDiv = setValue;
            }
            else if (dataRow[DATATABLE_MAST].ToString().Equals(ct_PARTSSUBSTURF))
            {
                cndWork.PartsMstDiv = setValue;
            }
            else if (dataRow[DATATABLE_MAST].ToString().Equals(ct_GOODSSETRF))
            {
                cndWork.SetMstDiv = setValue;
            }
            else if (dataRow[DATATABLE_MAST].ToString().Equals(ct_SALESDETAILRF))
            {
                cndWork.ShipmentDiv = setValue;
            }
            else if (dataRow[DATATABLE_MAST].ToString().Equals(ct_PRMSETTINGURF))
            {
                cndWork.PrmMstDiv = setValue;
            }
        }

        #endregion
        //ADD 2015/04/17 zhujc Redmine#44209 品番変換処理画面の制御対応 ------<<<<<<

        //ADD 2015/05/12 呉軍 Redmine#45436 №105 ------>>>>>>
        #region ■ 変換処理中ボタン制御
        /// <summary>
        /// 変換処理中ツールバーボタンの制御
        /// </summary>
        /// <remarks>
        /// <br>Note       : 変換処理中ツールバーボタンの制御</br>
        /// <br>Programmer : 呉軍</br>
        /// <br>Date       : 2015/05/12</br>
        /// </remarks>
        private void changeButtonEnabled(bool enable)
        {
            this.tToolsManager_MainMenu.Tools["ButtonTool_Run"].SharedProps.Enabled = enable;
            this.tToolsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = enable;
            // 画面のリフレッシュ
            System.Windows.Forms.Application.DoEvents();
        }
        #endregion
        //ADD 2015/05/12 呉軍 Redmine#45436 №105 ------<<<<<

    }

    //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応----->>>>>
    /// <summary>フォルダの更新日時比較クラス</summary>
    /// <remarks>
    /// <br>Note       : フォルダの更新日時比較を行う</br>
    /// <br>Programmer : 時シン</br>
    /// <br>Date       : 2015/03/02</br>
    /// </remarks>
    public class FileComparer : IComparer 
    { 
        int IComparer.Compare(Object o1, Object o2) 
        {
            DirectoryInfo fi1 = o1 as DirectoryInfo;
            DirectoryInfo fi2 = o2 as DirectoryInfo;
            return fi2.CreationTime.CompareTo(fi1.CreationTime);
        }
    }
    //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応-----<<<<<
}