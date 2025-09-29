//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫移動電子元帳
// プログラム概要   : 在庫移動電子元帳 ＵＩクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/04/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 作 成 日  2011/05/11  修正内容 : redmine #20966
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/05/18  修正内容 : redmine #21429
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/05/08  修正内容 : redmine #21627
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱俊成
// 作 成 日  2011/05/20  修正内容 : redmine #21657
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱俊成
// 作 成 日  2011/05/21  修正内容 : redmine #21678
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/05/23  修正内容 : redmine #21681
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;      // ConstantManagementの使用に必要(SFCMN00006C)
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

using Infragistics.Win;
using System.Reflection;
using System.Threading;
using Broadleaf.Library.Globarization; // SFCMN00002C
using Broadleaf.Application.Controller.Facade;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫移動電子元帳 ＵＩクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫移動電子元帳のＵＩクラスです。</br>
    /// <br>Programmer : 高峰</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br>Update Note: 2011/05/11 tianjw</br>
    /// <br>             redmine #20966</br>
    /// <br></br>
    /// </remarks>
    public partial class PMZAI04601UA : Form
    {
        #region プライベート変数

        // **** アプリケーション共通変数 ****
        private string _enterpriseCode = string.Empty;	    	// 企業コード
        private string _invokerPgId = string.Empty;             // 呼び出し元プログラムID

        // **** ログインユーザーデータ保存 ****
        private string _loginSectionCode = string.Empty;		// 自拠点コード
        private string _loginSectionName = string.Empty;		// 自拠点名

        private string _loginUserCd = string.Empty;             // ログインユーザー
        private string _loginUserName = string.Empty;           // ログインユーザー名
        private string slipCd = string.Empty;

        private int _checkCount = 0;                       // 基本条件のCheck数 

        // 在庫管理全体設定マスタアクセスクラス
        private StockMngTtlStAcs _stockMngTglStAcs;        

        /// <summary>伝票表示タブ 列サイズ自動調整値</summary>
        private bool _columnWidthAutoAdjust = false;

        /// <summary>明細グリッド選択拠点コード</summary>
        private string _selectedSectionCd = string.Empty;

        /// <summary>SFKTN09002A)拠点</summary>
        private SecInfoSetAcs _secInfoSetAcs;

        /// <summary>SFTOK09382A)従業員</summary>
        private EmployeeAcs _employeeAcs;
        /// <summary>MAKHN09112A)メーカー</summary>
        private MakerAcs _makerAcs;
        /// <summary>DCKHN09092A)BLコード</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;
        /// <summary>MAKHN09332A)倉庫</summary>
        private WarehouseAcs _warehouseAcs;
        /// <summary>PMKHN09022A)仕入先</summary>
        private SupplierAcs _supplierAcs;
        /// <summary>SFTOK9402)備考設定</summary>
        private NoteGuidAcs _noteGuidAcs;

        // **** 在庫移動電子元帳プロジェクトクラス ****
        /// <summary>PMZAI04603A)在庫移動電子元帳</summary>
        private StockMoveSlipSearchAcs _stockMoveSlipSearchAcs;

        /// <summary>PMZAI04604UA)設定フォーム</summary>
        private PMZAI04604UA _settingForm;

        // **** 抽出条件クラス ****
        /// <summary>検索条件クラス (PMZAI04602EA)</summary>
        private StockMovePpr _stockMovePpr = null;

        //抽出条件に変更があったかどうかの判断用(前回検索時と今回検索直前の値を比較)

        /// <summary>前回検索時抽出条件クラス(PMZAI04602EB)</summary>
        private string _rl_RemainTypeBackup = string.Empty;


        // **** 明細データ格納データセットオブジェクト **** 
        /// <summary>明細データ格納データセット</summary>

        private StockMoveDetailDataSet _stockMoveDataSet;

        // **** 締め日関連 ****
        /// <summary>締め日取得用クラス</summary>
        TotalDayCalculator _tCalcAcs = null;
        /// <summary>今回締処理日</summary>
        private DateTime _currentTotalDay;
        /// <summary>今回締処理月</summary>
        private DateTime _currentTotalMonth;
        /// <summary>前回締処理日</summary>
        private DateTime _prevTotalDay;
        /// <summary>前回締処理月</summary>
        private DateTime _prevTotalMonth;

        /// <summary>日付取得部品</summary>
        private DateGetAcs _dateGetAcs;

        // **** 画面設定用 ****

        // **** 文字サイズ ****
        /// <summary>文字サイズ</summary>
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };

        // **** ボタン用イメージリスト ****
        private ImageList _imageList16 = null;                  // イメージリスト

        // **** スキン設定用クラス ****
        private ControlScreenSkin _controlScreenSkin;

        /// <summary>現在のコントロール位置X (スライダー)</summary>
        int _currentLocationX = 0;
        /// <summary>現在のコントロール位置Y (スライダー)</summary>
        int _currentLocationY = 0;

        // **** テキスト出力用 ****
        private string _txtexp_FileName = string.Empty;         // 出力ファイル名
        private StockMoveUserConst _userSetting;             // 出力設定XMLからの取得設定
        private string[] _patternSetting;                       // 設定値
        private List<String> _exportColumnNameList;             // 出力カラム名

        // **** あいまい検索を行う項目用 ****
        /// <summary>備考１</summary>
        private string _srSlipNote = string.Empty;
        /// <summary>備考１(*抜き文字列)</summary>
        private string _srRvSlipNote = string.Empty;
        /// <summary>品名</summary>
        private string _srGoodsName = string.Empty;
        /// <summary>品名(*抜き文字列)</summary>
        private string _srRvGoodsName = string.Empty;
        /// <summary>品番</summary>
        private string _srGoodsNo = string.Empty;
        /// <summary>品番(*抜き文字列)</summary>
        private string _srRvGoodsNo = string.Empty;
        /// <summary>棚番</summary>
        private string _srWarehouseShelfNo = string.Empty;
        /// <summary>棚番(*抜き文字列)</summary>
        private string _srRvWarehouseShelfNo = string.Empty;

        // **** コード←→名称を切り替える項目用 ****
        /// <summary>担当者コード</summary>
        private string _swSalesEmployeeCd = string.Empty;
        /// <summary>担当者名</summary>
        private string _swSalesEmployeeName = string.Empty;
        /// <summary>BLコード</summary>
        private int _swBLGoodsCode = 0;
        /// <summary>BLコード名</summary>
        private string _swBLGoodsName = string.Empty;
        /// <summary>相手拠点コード</summary>
        //private int _swAfSectionCode = 0; // DEL 2010/05/18
        private string _swAfSectionCode = string.Empty; // ADD 2010/05/18
        /// <summary>相手拠点名</summary>
        private string _swAfSectionName = string.Empty;
        /// <summary>相手倉庫コード</summary>
        private string _swAfEnterWarehCode = string.Empty;
        /// <summary>相手倉庫名</summary>
        private string _swAfEnterWarehName = string.Empty;
        /// <summary>メーカーコード</summary>
        private int _swGoodsMakerCd = 0;
        /// <summary>メーカー名</summary>
        private string _swGoodsMakerName = string.Empty;
        /// <summary>仕入先コード</summary>
        private int _swSupplierCd = 0;
        /// <summary>仕入先名</summary>
        private string _swSupplierName = string.Empty;

        /// <summary>削除指定区分</summary>
        private int _logicalDelDiv = 0;

        /// <summary>在庫管理全体設定</summary>
        private StockMngTtlSt _stockMngTtlSt;

        /// <summary>前回入力値</summary>
        private PrevInputValue _prevInputValue;

        /// <summary>中断ダイアログ</summary>
        private SFCMN00299CA _processingDialog = null;

        // **** コントロール ****
        private Control _prevControl;

        // グリッドからの戻り先コントロール(詳細条件の中のControl)
        private Control _gridUpKeyBackControl;

        // **** グリッド表示用 ****
        // 結合セルの表示設定
        private Infragistics.Win.Appearance _margedCellAppearance;

        // グリッド・カラムチューザー制御
        GridColumnChooserControl _gridColumnChooserControl;

        //private bool tabFlg = true;

        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト
        private Dictionary<OperationCode, bool> _operationAuthorityList;  // 操作権限の制御リスト(直接参照すると遅いのでディクショナリ化)

        //発行した赤伝の先頭の明細の元黒伝票番号
        private string _searchSalesSlipNum = string.Empty;

        // マウスで赤伝タブに移動した、エラーの場合、フォーカス設定用
        private Control _control = null;

        private int _stockMoveFixCode; // 在庫移動確定区分

        /// <summary>テキスト出力オプション情報</summary>
        private int _opt_TextOutput;

        /// <summary>前回検索時抽出条件クラス(PMKAU04002EA)</summary>
        private StockMovePpr _stockMovePprBackUp = null;
        private int _logicalDelDivBackUp = -1;

        /// <summary>マスタチェックフラグ</summary>
        private bool _isError = false;
        /// <summary>フォーカスのコントロール</summary>
        private Control _nextControl;
        private bool _doSearchFlg = true;

        private bool _initFlg = true;

        // 伝票グリッドカラム制御
        private GridColPosFixController _stockMoveGridColPosCtrl;

        #region Private Const

        #region プライベート定数
        /// <summary>あいまい検索「と一致」ステータス</summary>
        private const int CT_FUZZY_MATCHWITH = 0;
        /// <summary>あいまい検索「で始る」ステータス</summary>
        private const int CT_FUZZY_STARTWITH = 1;
        /// <summary>あいまい検索「を含む」ステータス</summary>
        private const int CT_FUZZY_INCLUDEWITH = 2;
        /// <summary>あいまい検索「で終る」ステータス</summary>
        private const int CT_FUZZY_ENDWITH = 3;

        /// <summary>仕入先電子元帳PGID</summary>
        private const string CT_SUPPLIER_ERECNOTE_PGID = "PMKOU04001U";
        /// <summary>在庫移動電子元帳PGID</summary>
        private const string CT_CUSTOMER_ERECNOTE_PGID = "PMZAI04601U";

        /// <summary>在庫移動電子元帳アセンブリID</summary>
        private const string ctAssemblyName = "PMZAI04601UA";

        /// <summary>表示列数(基本条件)</summary>
        private const int CT_INITIA_COMMONL_ROW_COUNT =2;
        /// <summary>表示列数(抽出条件)</summary>
        private const int CT_INITIAL_EXTRA_ROW_COUNT = 3;
        /// <summary>初期表示位置 左上X</summary>
        private const int CT_INITIAL_FIELD_POSITION_X = 13;
        /// <summary>表示位置 左上X</summary>
        private const int CT_INITIAL_FIELD_POSITION_X_2 = 360;
        /// <summary>表示位置 左上X</summary>
        private const int CT_INITIAL_FIELD_POSITION_X_3 = 700;
        /// <summary>初期表示位置 左上Y</summary>
        private const int CT_INITIAL_FIELD_POSITION_Y = 1;
        /// <summary>表示間隔 余白</summary>
        private const int CT_FIELD_INTERVAL_X = 10;
        /// <summary>表示間隔：ラベル</summary>
        private const int CT_INTERVAL_LABEL = 100;
        /// <summary>表示間隔：コンボボックス</summary>
        private const int CT_INTERVAL_COMBOBOX = 200;
        /// <summary>表示間隔：入力域(tNedit/tEdit)(付属コントロールなし)</summary>
        private const int CT_INTERVAL_EDIT = 200;
        /// <summary>表示間隔：入力域(tNedit/tEdit)(ボタンあり)</summary>
        private const int CT_INTERVAL_EDIT_WITHBUTTON = 175;
        /// <summary>表示間隔：入力域(tNedit/tEdit)(あいまい検索あり)</summary>
        private const int CT_INTERVAL_EDIT_WITHCOMBO = 124;
        /// <summary>表示間隔：ボタン</summary>
        private const int CT_INTERVAL_BUTTON = 25;
        /// <summary>表示間隔：あいまい検索用コンボボックス</summary>
        private const int CT_INTERVAL_FUZZYCOMBO = 76;

        /// <summary>表示間隔：行</summary>
        private const int CT_INTERVAL_HEIGHT = 26;
        /// <summary>表示：初期フォントサイズ</summary>
        private const int CT_DEF_FONT_SIZE = 11;

        /// <summary>明細データ抽出最大件数</summary>
        private const long DATA_COUNT_MAX = 20000;

        #endregion // プライベート定数

        #region メッセージ定数

        /// <summary>検索時メッセージ「在庫移動データの取得に失敗しました。」</summary>
        private const string MSG_FAILED2GET_SLIP_DATA = "在庫移動データの取得に失敗しました。";

        /// <summary>検索時メッセージ「条件に合致するデータが存在しません。」</summary>
        private const string MSG_MATCHED_DATA_NOT_FOUND = "条件に合致するデータが存在しません。";

        /// <summary>チェック時メッセージ「開始日を終了日よりも後にすることはできません。」</summary>
        private const string MSG_MUST_BE_CORRECT_CALENDER = "開始日を終了日よりも後にすることはできません。";

        /// <summary>チェック時メッセージ「売上月次締日取得の初期処理でエラーが発生しました。」</summary>
        private const string MSG_TOTALDAY_INITIALIE_FAILED = "売上月次締日取得の初期処理でエラーが発生しました。";

        /// <summary>チェック時メッセージ「出力ファイル名が指定されていません。設定ボタンから設定を行ってください。」</summary>
        private const string MSG_OUTPUTFILENAME_NOTFOUND = "出力ファイル名が指定されていません。設定ボタンから設定を行ってください。";

        /// <summary>チェック時メッセージ「ファイルへの出力に失敗しました。」</summary>
        private const string MSG_OUTPUTFILE_FAILED = "ファイルへの出力に失敗しました。";

        /// <summary>テキストエクスポート成功時メッセージ「 行のデータをファイルへ出力しました。」</summary>
        private const string MSG_OUTPUTFILE_SUCCEEDED = "行のデータをファイルへ出力しました。";

        /// <summary>チェック時メッセージ「出力ファイル名が指定されていません。」</summary>
        private const string MSG_OUTPUTEXCEL_NOFILENAME = "出力ファイル名が指定されていません。";

        /// <summary>EXCELエクスポート成功時メッセージ「EXCELデータを出力しました。」</summary>
        private const string MSG_OUTPUTEXCEL_SUCCEEDED = "EXCELデータを出力しました。";

        /// <summary>検索時メッセージ「指定された文字列が存在する行はありません。」</summary>
        private const string MSG_ROWSEARCH_NOT_FOUND = "指定された文字列が存在する行はありません。";

        /// <summary>チェック時メッセージ「が不正です」</summary>
        private const string MSG_SALESDATE_ERROR = "が不正です。";
        /// <summary>チェック時メッセージ「が不正です」</summary>
        private const string MSG_ST_SALESDATE_ERROR = "開始";
        /// <summary>チェック時メッセージ「が不正です」</summary>
        private const string MSG_ED_SALESDATE_ERROR = "終了";

        /// <summary>チェック時メッセージ「開始入力日が不正です」</summary>
        private const string MSG_ST_INPUTDATE_ERROR = "開始入力日が不正です。";
        /// <summary>チェック時メッセージ「終了入力日が不正です」</summary>
        private const string MSG_ED_INPUTDATE_ERROR = "終了入力日が不正です。";
        /// <summary>クリア確認メッセージ「表示内容を初期化してよろしいですか？」</summary>
        private const string MSG_CONFIRM_CLEARINPUT = "表示内容を初期化してよろしいですか？";

        /// <summary>発行確認用メッセージ「伝票を再発行してよろしいですか」</summary>
        private const string MSG_CONFIRM_PRINTDISP = "伝票を再発行してよろしいですか？";

        #endregion // メッセージ定数   
   
        #endregion // Private Const

        #region 各種設定値

        /// <summary>明細グリッド 選択行カラー(グラデーションcolor1)</summary>
        private readonly Color _selectedRowBackColor_Detail = Color.FromArgb(253, 235, 216);

        /// <summary>明細グリッド 選択行カラー(グラデーションcolor2)</summary>
        private readonly Color _selectedRowBackColor2_Detail = Color.FromArgb(218, 144, 101);

        #endregion // 各種設定値

        #endregion // プライベート変数

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
            /// <summary>再発行</summary>
            ReissueSlip = 3
        }
        #endregion

        # region 構造体
        # region [前回値保持]
        /// <summary>
        /// 前回値保持
        /// </summary>
        private struct PrevInputValue
        {
            /// <summary>入力拠点コード</summary>
            private string _inputSectionCode;
            /// <summary>拠点コード</summary>
            private string _sectionCode;
            /// <summary>倉庫コード</summary>
            private string _warehouseCode;

            /// <summary>
            /// 入力拠点コード
            /// </summary>
            public string InputSectionCode
            {
                get { return _inputSectionCode; }
                set { _inputSectionCode = value; }
            }
            /// <summary>
            /// 拠点コード
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>
            /// 倉庫コード
            /// </summary>
            public string WarehouseCode
            {
                get { return _warehouseCode; }
                set { _warehouseCode = value; }
            }

        }
        # endregion
        # endregion

        #region プロパティ

        /// <summary>操作権限の制御オブジェクト</summary>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateReferenceOperationAuthority("PMZAI04600U", this);
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

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタです。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public PMZAI04601UA()
        {
            InitializeComponent();

            // 設定フォーム生成
            _settingForm = new PMZAI04604UA();
            _settingForm.ClearSettingStockMoveGrid += new EventHandler(SettingForm_ClearSettingStockMoveGrid);

            // 設定読み込み
            _settingForm.Deserialize();

            // グリッド内の結合セル設定
            _margedCellAppearance = new Infragistics.Win.Appearance();
            _margedCellAppearance.BackColor = Color.Lavender;
            _margedCellAppearance.BackColorAlpha = Alpha.Opaque;
            _margedCellAppearance.ForeColor = Color.Black;

            // tRetKeyControl
            // グリッド内でReturnキー押下時の処理を実装する為Circulate=trueにする。
            tRetKeyControl.Circulate = true;

            _gridColumnChooserControl = new GridColumnChooserControl();

            #region ●オプション情報
            this.CacheOptionInfo();
            #endregion
        }

        /// <summary>
        /// 呼び出し元プログラムID込みのコンストラクタ
        /// </summary>
        /// <param name="invokerPgId">呼び出し元プログラムID</param>
        /// <remarks>
        /// <br>Note       : 呼び出し元プログラムID込みのコンストラクタです。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public PMZAI04601UA(string invokerPgId)
        {
            InitializeComponent();

            // プライベートレベルでPGIDを保存
            this._invokerPgId = invokerPgId;

            // 設定フォーム生成
            _settingForm = new PMZAI04604UA();

            // 設定読み込み
            _settingForm.Deserialize();

            // グリッド内の結合セル設定
            _margedCellAppearance = new Infragistics.Win.Appearance();
            _margedCellAppearance.BackColor = Color.Lavender;
            _margedCellAppearance.BackColorAlpha = Alpha.Opaque;
            _margedCellAppearance.ForeColor = Color.Black;

            // tRetKeyControl
            // グリッド内でReturnキー押下時の処理を実装する為Circulate=trueにする。
            tRetKeyControl.Circulate = true;

        }

        #endregion // コンストラクタ

        #region プライベート関数

        /// <summary>Form.Load イベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : Form.Load イベントです。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void PMZAI04601UA_Load(object sender, System.EventArgs e)
        {
            // グリッドカラムサイズ自動調整チェックの復元
            # region [グリッドカラムサイズ自動調整の復元]
            _columnWidthAutoAdjust = _settingForm.UserSetting.AutoAdjustStockMove;
            # endregion
            // 変数などを初期化
            InitializeVariable();

            // グループ展開状態の復元
            # region [グループ展開状態の復元]
            uExGroupBox_BalanceChart.Expanded = _settingForm.UserSetting.BalanceChartExpanded;
            uExGroupBox_ExtraCondition.Expanded = _settingForm.UserSetting.ExtraConditionExpanded;
            # endregion

            // 詳細条件の復元
            # region [前回使用時の詳細条件を復元]

            if (_settingForm.UserSetting.EnabledCommonConditionList != null)
            {
                // 基本条件のチェック状態の復元
                this._checkCount = 0;
                foreach (Control control in panel_Base.Controls)
                {
                    if (control is Infragistics.Win.UltraWinEditors.UltraCheckEditor)
                    {
                        // 「２：出荷確定なし」から「1：出荷確定あり」へ変更する場合
                        if (this._stockMoveFixCode == 1)
                        {
                            if (this._checkCount > 3)
                            {
                                // チェックが付いているチェックボックスの名称をリストに追加
                                if (_settingForm.UserSetting.EnabledCommonConditionList.Contains(control.Name))
                                {
                                    string controlName = control.Name.Replace("_base", "");
                                    foreach (Control controlSelect in panel_SelectItem.Controls)
                                    {
                                        if (controlSelect is Infragistics.Win.UltraWinEditors.UltraCheckEditor)
                                        {
                                            if (controlName.Equals(controlSelect.Name))
                                            {
                                                // リストに名前があれば、チェックする
                                                (controlSelect as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = true;
                                                // リストに名前があれば、Enableする
                                                (controlSelect as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Enabled = true;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // 名前がなければ、チェックしない
                                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = false;
                                }
                                continue;
                            }
                        }

                        // チェックが付いているチェックボックスの名称をリストに追加
                        if (_settingForm.UserSetting.EnabledCommonConditionList.Contains(control.Name))
                        {
                            //２：出荷確定なしの場合
                            if (this._stockMoveFixCode == 2 && "uCheckArrivalGoodsFlag_base".Equals(control.Name))
                            {
                                // 名前がなければ、チェックしない
                                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).CheckedChanged -= this.uCheckStockMoveDtl_base_CheckedChanged;
                                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = false;
                                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).CheckedChanged += this.uCheckStockMoveDtl_base_CheckedChanged;
                                continue;
                            }
                            else
                            {
                                // リストに名前があれば、チェックする
                                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).CheckedChanged -= this.uCheckStockMoveDtl_base_CheckedChanged;
                                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = true;
                                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).CheckedChanged += this.uCheckStockMoveDtl_base_CheckedChanged;
                                this._checkCount++;
                            }
                        }
                        else
                        {
                            // 名前がなければ、チェックしない
                            (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = false;
                        }
                    }
                }
            }

            if (_settingForm.UserSetting.EnabledConditionList != null)
            {
                // チェック状態の復元
                foreach (Control control in panel_SelectItem.Controls)
                {
                    if (control is Infragistics.Win.UltraWinEditors.UltraCheckEditor)
                    {

                        // チェックが付いているチェックボックスの名称をリストに追加
                        if (_settingForm.UserSetting.EnabledConditionList.Contains(control.Name))
                        {
                            //２：出荷確定なしの場合
                            if (this._stockMoveFixCode == 2 && "uCheckArrivalGoodsFlag".Equals(control.Name))
                            {
                                // 名前がなければ、チェックしない
                                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = false;
                            }
                            else
                            {
                                // リストに名前があれば、チェックする
                                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = true;
                            }
                        }
                        else
                        {
                            // 名前がなければ、チェックしない
                            (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = false;
                        }
                        if (_settingForm.UserSetting.EnabledList != null)
                        {
                            // チェックがEnableているチェックボックスの名称をリストに追加
                            if (_settingForm.UserSetting.EnabledList.Contains(control.Name))
                            {
                                if (this._stockMoveFixCode == 1 && "uCheckArrivalGoodsFlag".Equals(control.Name) && !this.uCheckArrivalGoodsFlag_base.Checked)
                                {
                                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Enabled = true;
                                }
                                else
                                {
                                // リストに名前があれば、Enableする
                                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Enabled = false;
                                }
                            }
                            else
                            {
                                //２：出荷確定なしの場合
                                if (this._stockMoveFixCode == 2 && "uCheckArrivalGoodsFlag".Equals(control.Name))
                                {
                                    // 名前がなければ、Enableしない
                                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Enabled = false;
                                }
                                else
                                {
                                    // 名前がなければ、Enableしない
                                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Enabled = true;
                                }
                            }
                        }
                    }
                }
            }
            //if (_settingForm.UserSetting.EnabledCommonConditionList != null)
            //{
            //    // 基本条件のチェック状態の復元
            //    this._checkCount = 0;
            //    foreach (Control control in panel_Base.Controls)
            //    {
            //        if (control is Infragistics.Win.UltraWinEditors.UltraCheckEditor)
            //        {
            //            // 「２：出荷確定なし」から「1：出荷確定あり」へ変更する場合
            //            if (this._stockMoveFixCode == 1)
            //            {
            //                if (this._checkCount > 3)
            //                {
            //                    // チェックが付いているチェックボックスの名称をリストに追加
            //                    if (_settingForm.UserSetting.EnabledCommonConditionList.Contains(control.Name))
            //                    {
            //                        string controlName = control.Name.Replace("_base", "");
            //                        foreach (Control controlSelect in panel_SelectItem.Controls)
            //                        {
            //                            if (controlSelect is Infragistics.Win.UltraWinEditors.UltraCheckEditor)
            //                            {
            //                                if (controlName.Equals(controlSelect.Name))
            //                                {
            //                                    // リストに名前があれば、チェックする
            //                                    (controlSelect as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = true;
            //                                    // リストに名前があれば、Enableする
            //                                    (controlSelect as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Enabled = true;
            //                                }
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        // 名前がなければ、チェックしない
            //                        (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = false;
            //                    }
            //                    continue;
            //                }
            //            }
                        
            //            // チェックが付いているチェックボックスの名称をリストに追加
            //            if (_settingForm.UserSetting.EnabledCommonConditionList.Contains(control.Name))
            //            {
            //                //２：出荷確定なしの場合
            //                if (this._stockMoveFixCode == 2 && "uCheckArrivalGoodsFlag_base".Equals(control.Name))
            //                {
            //                    // 名前がなければ、チェックしない
            //                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).CheckedChanged -= this.uCheckStockMoveDtl_base_CheckedChanged;
            //                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = false;
            //                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).CheckedChanged += this.uCheckStockMoveDtl_base_CheckedChanged;
            //                    continue;
            //                }
            //                else
            //                {
            //                    // リストに名前があれば、チェックする
            //                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).CheckedChanged -= this.uCheckStockMoveDtl_base_CheckedChanged;
            //                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = true;
            //                    (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).CheckedChanged += this.uCheckStockMoveDtl_base_CheckedChanged;
            //                    this._checkCount++;
            //                }
            //            }
            //            else
            //            {
            //                // 名前がなければ、チェックしない
            //                (control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked = false;
            //            }
            //        }
            //    }
            //}
            // 表示内容に反映
            if ((_settingForm.UserSetting.EnabledCommonConditionList != null) || (_settingForm.UserSetting.EnabledConditionList != null))
            {
                ultraDockManager_PaneHidden(sender, null);
            }

            # endregion

            // グリッドカラム情報の復元
            # region [グリッドカラム情報の復元]
            this.LoadGridColumnsSetting(ref uGrid_StockMove, _settingForm.UserSetting.StockMoveColumnsList);
            # endregion

            // 設定フォームへのカラム一覧渡し
            _settingForm.SlipColCollection = uGrid_StockMove.DisplayLayout.Bands[0].Columns;

            // グリッドカラム制御
            _stockMoveGridColPosCtrl = new GridColPosFixController(uGrid_StockMove);

            // 画面を使用可能に
            this.Enabled = true;

            // ツールバー初期設定処理
            ToolbarManagerCustomizeSettingAcs.LoadToolManagerCustomizeInfo(ctAssemblyName, ref this.tToolbarsManager);

            // 「列自動調整」チェックに関する初期状態の更新の為、CheckedChangedイベントでの処理を実行
            uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged(null, null);

            //出力区分
            if (this.tComboEditor_OutputDiv.Visible)
            {
                this.tComboEditor_OutputDiv.SelectedIndex = _settingForm.UserSetting.OutPutDiv;
            }

            // 伝票区分
            if (this.tComboEditor_SalesSlipDiv.Visible)
            {
                this.tComboEditor_SalesSlipDiv.SelectedIndex = _settingForm.UserSetting.SalesSlipDiv;
            }
        }

        /// <summary>
        /// フォーム表示後の処理(初期フォーカスのセット)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : フォーム表示後の処理(初期フォーカスのセット)です。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        void PMZAI04601UA_Shown(object sender, System.EventArgs e)
        {
            if (_stockMngTtlSt == null) Close();

            // 初期フォーカス(出力区分または伝票区分)
            if (this._stockMoveFixCode == 1) {
                this.tEdit_WarehouseCd.Focus();
            }
            else if (this._stockMoveFixCode == 2)
            {
                this.tEdit_InputSectionCode.Focus();
            }
            this._initFlg = false;
        }

        /// <summary>
        /// フォームクロージングイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームクロージングイベントです。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void PMZAI04601UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.CurrentDirectory = ConstantManagement_ClientDirectory.NSCurrentDirectory;
            //今回設定情報の保存(プログラム終了時に実装)
            ToolbarManagerCustomizeSettingAcs.SaveToolManagerCustomizeInfo(ctAssemblyName, this.tToolbarsManager);
        }

        /// <summary>
        /// プライベートレベルの変数などを初期化および初期取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : プライベートレベルの変数などを初期化および初期取得です。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void InitializeVariable()
        {
            int status;

            #region セッション初期値取得

            // アプリケーションに必要となる値を設定する
            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 自拠点コード
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

            // ログインユーザーコード
            this._loginUserCd = LoginInfoAcquisition.Employee.EmployeeCode;

            // ログインユーザー名
            this._loginUserName = LoginInfoAcquisition.Employee.Name;

            #endregion // セッション初期値取得

            #region アクセスクラス初期化

            // アクセスクラスを初期化
            this._stockMngTglStAcs = new StockMngTtlStAcs();

            //this._customerInfoAcs = new CustomerInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();

            this._employeeAcs = new EmployeeAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._supplierAcs = new SupplierAcs();

            this._noteGuidAcs = new NoteGuidAcs();

            #endregion // アクセスクラス初期化

            // 自拠点名
            SecInfoSet secInfoSet;
            _secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this._loginSectionCode.Trim());
            this._loginSectionName = secInfoSet.SectionGuideNm;

            //// 検索条件クラスを初期化
            this._stockMovePpr = new StockMovePpr();

            //// 前回検索時抽出条件クラス
            this._stockMovePprBackUp = null;

            //--------------------------
            // 画面のセッティング
            //--------------------------

            #region ボタンイメージ設定

            // イメージリストを指定(16x16)
            this._imageList16 = IconResourceManagement.ImageList16;

            // ボタンイメージを設定
            // 共通部分
            this.uButton_InputSectionGuide.ImageList = this._imageList16;
            this.uButton_InputSectionGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_SecGuide.ImageList = this._imageList16;
            this.uButton_SecGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_WarehouseGuide.ImageList = this._imageList16;
            this.uButton_WarehouseGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_SalesEmployeeCd.ImageList = this._imageList16;
            this.uButton_SalesEmployeeCd.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_SupplierCd.ImageList = this._imageList16;
            this.uButton_SupplierCd.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_MakerCd.ImageList = this._imageList16;
            this.uButton_MakerCd.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_BlGoodsCode.ImageList = this._imageList16;
            this.uButton_BlGoodsCode.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_AfSectionCode.ImageList = this._imageList16;
            this.uButton_AfSectionCode.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_AfEnterWarehCode.ImageList = this._imageList16;
            this.uButton_AfEnterWarehCode.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_SlipNote.ImageList = this._imageList16;
            this.uButton_SlipNote.Appearance.Image = (int)Size16_Index.STAR1;

            this.tToolbarsManager.ImageListSmall = this._imageList16;
            this.tToolbarsManager.Tools["LabelTool_RowSearchTitle"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SEARCH;
            this.tToolbarsManager.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CLOSE;
            this.tToolbarsManager.Tools["ButtonTool_Search"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SEARCH;

            this.tToolbarsManager.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.ALLCANCEL;

            this.tToolbarsManager.Tools["ButtonTool_ExtractText"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CSVOUTPUT;
            this.tToolbarsManager.Tools["ButtonTool_ExtractExcel"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CSVOUTPUT;
            this.tToolbarsManager.Tools["ButtonTool_ReissueSlip"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SLIP;
            this.tToolbarsManager.Tools["ButtonTool_Configuration"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SETUP1;
            this.tToolbarsManager.Tools["ButtonTool_RowSelect"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.DETAILS;

            this.tToolbarsManager.Tools["ButtonTool_SalesSlipSelect"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.DECISION;
            this.tToolbarsManager.Tools["ButtonTool_CommonCondition"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.INDICATIONCHANGE;
            this.tToolbarsManager.Tools["ButtonTool_ExtraCondition"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.INDICATIONCHANGE;
            this.tToolbarsManager.Tools["ButtonTool_TotalShow"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.INDICATIONCHANGE;

            #endregion // ボタンイメージ設定

            // 全ての詳細検索条件を非表示にし、拡張検索条件の拡張可能グループボックスを不可視に
            SetAllDetailSearchCondition2Hidden();
            this.uExGroupBox_ExtraCondition.Visible = false;

            #region 在庫管理全体設定取得

            // 在庫管理全体設定を取得
            ArrayList retList;

            status = this._stockMngTglStAcs.Search(out retList, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 在庫管理全体設定
                # region [在庫管理全体設定 取得]
                _stockMngTtlSt = null;
                StockMngTtlSt allStockMngTtlSt = null;
                status = this._stockMngTglStAcs.Search(out retList, this._enterpriseCode);
                foreach (StockMngTtlSt tockMngTtlSt in retList)
                {
                    if (tockMngTtlSt.SectionCode.Trim() == this._loginSectionCode.Trim())
                    {
                        // 拠点別設定
                        _stockMngTtlSt = tockMngTtlSt;
                        break;
                    }
                    else if (tockMngTtlSt.SectionCode.Trim() == string.Empty || tockMngTtlSt.SectionCode.Trim() == "00")
                    {
                        // 全社設定
                        allStockMngTtlSt = tockMngTtlSt;
                        continue;
                    }
                }
                // 拠点別設定が無ければ全社設定を使用
                if (_stockMngTtlSt == null)
                {
                    _stockMngTtlSt = allStockMngTtlSt;
                }
                # endregion

                // 拠点別設定も全社設定も無ければ終了
                if (_stockMngTtlSt == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "在庫管理全体設定マスタの登録を行って下さい。",
                        status, MessageBoxButtons.OK);
                    this.timer_Close.Enabled = true;
                    return;
                }

                this._stockMoveFixCode = _stockMngTtlSt.StockMoveFixCode;

                // 在庫管理全体設定による項目表示・非表示設定
                # region [表示・非表示設定]
                // 在庫移動確定区分
                switch (_stockMngTtlSt.StockMoveFixCode)
                {
                    // 1：出荷確定あり、２：出荷確定なし 
                    case 1:
                        {
                            #region 基本条件の表示・非表示設定
                            // 基本条件の表示・非表示設定
                            this.uLabel_SalesSlipDiv.Visible = false;
                            this.tComboEditor_SalesSlipDiv.Visible = false;

                            this.uLabel_InputSectionCodeTitle.Visible = false;
                            this.tEdit_InputSectionCode.Visible = false;
                            this.ultraLabel_InputSectionName.Visible = false;
                            this.uButton_InputSectionGuide.Visible = false;

                            this.uLabel_SecCd.Location = new Point(this.uLabel_SecCd.Location.X, this.uLabel_SecCd.Location.Y - CT_INTERVAL_HEIGHT);
                            this.tEdit_SecCd.Location = new Point(this.tEdit_SecCd.Location.X, this.tEdit_SecCd.Location.Y - CT_INTERVAL_HEIGHT);
                            this.ultraLabel_SecName.Location = new Point(this.ultraLabel_SecName.Location.X, this.ultraLabel_SecName.Location.Y - CT_INTERVAL_HEIGHT);
                            this.uButton_SecGuide.Location = new Point(this.uButton_SecGuide.Location.X, this.uButton_SecGuide.Location.Y - CT_INTERVAL_HEIGHT);

                            this.uLabel_WarehouseCd.Location = new Point(this.uLabel_WarehouseCd.Location.X, this.uLabel_WarehouseCd.Location.Y - CT_INTERVAL_HEIGHT);
                            this.tEdit_WarehouseCd.Location = new Point(this.tEdit_WarehouseCd.Location.X, this.tEdit_WarehouseCd.Location.Y - CT_INTERVAL_HEIGHT);
                            this.ultraLabel_WarehouseName.Location = new Point(this.ultraLabel_WarehouseName.Location.X, this.ultraLabel_WarehouseName.Location.Y - CT_INTERVAL_HEIGHT);
                            this.uButton_WarehouseGuide.Location = new Point(this.uButton_WarehouseGuide.Location.X, this.uButton_WarehouseGuide.Location.Y - CT_INTERVAL_HEIGHT);
                            this.uExGroupBox_CommonCondition.Size = new Size(this.uExGroupBox_CommonCondition.Size.Width, this.uExGroupBox_CommonCondition.Size.Height - CT_INTERVAL_HEIGHT);

                            #endregion

                            break;
                        }
                    case 2:
                        {
                            #region 基本条件の表示・非表示設定
                            // 基本条件の表示・非表示設定
                            this.uLabel_OutputDiv.Visible = false;
                            this.tComboEditor_OutputDiv.Visible = false;
                            this.uLabel_SalesSlipDiv.Location = this.uLabel_OutputDiv.Location;
                            this.tComboEditor_SalesSlipDiv.Location = this.tComboEditor_OutputDiv.Location;

                            this.uLabel_SecCd.Visible = false;
                            this.tEdit_SecCd.Enabled = false;
                            this.ultraLabel_SecName.Enabled = false;
                            this.uButton_SecGuide.Enabled = false;
                            this.tEdit_SecCd.Clear();
                            this.ultraLabel_SecName.Text = string.Empty;

                            this.uLabel_WarehouseCd.Visible = false;
                            this.tEdit_WarehouseCd.Enabled = false;
                            this.ultraLabel_WarehouseName.Enabled = false;
                            this.uButton_WarehouseGuide.Enabled = false;

                            this.uLabel_DateTitle.Text = "伝票日付";

                            // 棚番
                            this.tEdit_WarehouseShelfNo.Enabled = false;
                            this.tComboEditor_WarehouseShelfNoFuzzy.Enabled = false;

                            // 相手拠点
                            this.tEdit_AfSectionCode.Enabled = false;
                            this.uButton_AfSectionCode.Enabled = false;

                            // 相手倉庫
                            this.tEdit_AfEnterWarehCode.Enabled = false;
                            this.uButton_AfEnterWarehCode.Enabled = false;

                            #endregion

                            #region 合計の表示・非表示設定
                            // 合計の表示・非表示設定
                            this.uLabel_LeftTitle1.Text = "出庫";
                            this.uLabel_LeftTitle2.Text = "入庫";
                            this.uLabel_LeftTitle3.Visible = false;
                            this.uLabel_Count3.Visible = false;
                            this.uLabel_Money3.Visible = false;
                            this.uLabel_Cost3.Visible = false;
                            this.tLine11.Visible = false;

                            this.tLine23.Height = this.tLine23.Height - 24;
                            this.tLine24.Height = this.tLine24.Height - 24;
                            this.tLine25.Height = this.tLine25.Height - 24;
                            this.tLine26.Height = this.tLine26.Height - 24;
                            this.tLine34.Height = this.tLine34.Height - 24;

                            // 「基本条件・抽出条件選択画面」の表示・非表示設定
                            this.uCheckArrivalGoodsFlag_base.Visible = false;
                            this.uCheckDeleteFlag_base.Location = this.uCheckNote_base.Location;
                            this.uCheckNote_base.Location = this.uCheckArrivalGoodsFlag_base.Location;

                            this.uCheckArrivalGoodsFlag.Visible = false;
                            this.uCheckDeleteFlag.Location = this.uCheckNote.Location;
                            this.uCheckNote.Location = this.uCheckArrivalGoodsFlag.Location;
                            #endregion

                            break;
                        }
                    default: break;
                }
                # endregion
            }
            else
            {
                if (_stockMngTtlSt == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "在庫管理全体設定マスタの登録を行って下さい。",
                        status, MessageBoxButtons.OK);
                    this.timer_Close.Enabled = true;
                    return;
                }
            }

            #endregion // 在庫管理全体設定取得

            #region 締め日取得

            // 日付取得部品
            _dateGetAcs = DateGetAcs.GetInstance();

            _tCalcAcs = TotalDayCalculator.GetInstance();

            #endregion // 締め日取得

            // アクセスクラスを初期化し、データセットを取得
            this._stockMoveSlipSearchAcs = new StockMoveSlipSearchAcs();

            this._stockMoveDataSet = this._stockMoveSlipSearchAcs.DataSet;

            // グリッド毎に使用するデータビューを作成

            DataView dViewStockMove = new DataView(this._stockMoveDataSet.StockMoveDetail);

            // データソースとしてデータビューを指定
            this.uGrid_StockMove.DataSource = dViewStockMove;

            // グリッドを作成
            // グリッド列初期設定処理
            InitializeGridColumns(this.uGrid_StockMove.DisplayLayout.Bands[0].Columns);

            // 全てのグリッドの自動調整
            autoColumnAdjust(this._columnWidthAutoAdjust);
            this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked = this._columnWidthAutoAdjust;

            // 行選択ボタンOFF
            this.tToolbarsManager.Tools["ButtonTool_RowSelect"].SharedProps.Enabled = false;

            // スキンをロード
            this._controlScreenSkin = new ControlScreenSkin();
            List<string> controlNameList = new List<string>();
            controlNameList.Add(this.uExGroupBox_CommonCondition.Name);
            controlNameList.Add(this.uExGroupBox_ExtraCondition.Name);
            controlNameList.Add(this.uExGroupBox_BalanceChart.Name);
            this._controlScreenSkin.SetExceptionCtrl(controlNameList);
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // 文字サイズ設定
            for (int i = 0; i < this._fontpitchSize.Length; i++)
            {
                this.tComboEditor_StatusBar_FontSize.Items.Add(this._fontpitchSize[i], this._fontpitchSize[i].ToString());
            }

            this.tComboEditor_StatusBar_FontSize.Text = CT_DEF_FONT_SIZE.ToString();

            // ログイン名を表示
            this.tToolbarsManager.Tools["LabelTool_LoginCharge"].SharedProps.Caption = this._loginUserName;


            // 仕入先電子元帳から呼び出された場合は、仕入先電子元帳へのリンクを削除
            if (this._invokerPgId.Equals(CT_SUPPLIER_ERECNOTE_PGID))
            {
                this.tToolbarsManager.Tools["ButtonTool_W_SuppPrtPprRef"].SharedProps.Visible = false;
            }

            // 初期化
            ClearInputProc();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期化処理です。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void ClearInputProc()
        {
            int status;

            // 締日取得前初期処理
            status = _tCalcAcs.InitializeHisMonthlyAccRec();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 今回および前回の締め日/月を取得(月と日は異なる場合がある)
                status = _tCalcAcs.GetHisTotalDayMonthlyAccRec(this._loginSectionCode, out this._prevTotalDay, out this._currentTotalDay, out this._prevTotalMonth, out this._currentTotalMonth);

                if (_prevTotalDay == DateTime.MinValue)
                {
                    DateTime today = DateTime.Today;
                    this.tDateEdit_DateSt.SetDateTime(today);
                    this.tDateEdit_DateEd.SetDateTime(today);
                }
                else
                {
                    this.tDateEdit_DateSt.SetDateTime(this._prevTotalDay.AddDays(1));
                    this.tDateEdit_DateEd.SetDateTime(DateTime.Today);
                    if (this._prevTotalDay.AddDays(1) > DateTime.Today)
                    {
                        this.tDateEdit_DateEd.SetDateTime(this._prevTotalDay.AddDays(1));
                    }
                }
            }
            else
            {
                // 初期処理失敗
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_TOTALDAY_INITIALIE_FAILED, -1, MessageBoxButtons.OK);
            }

            setToolbarSearchSurface();

            ClearAllField();

            // 自拠点名
            SecInfoSet secInfoSet;
            _secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this._loginSectionCode.Trim());
            this._loginSectionName = secInfoSet.SectionGuideNm;

            if (this._stockMoveFixCode == 1) // 1：出荷確定あり
            {
                if (this._initFlg)
                {
                    this.tComboEditor_OutputDiv.SelectedIndex = 0;
                }
                this.tEdit_SecCd.Text = this._loginSectionCode.Trim();
                this.ultraLabel_SecName.Text = this._loginSectionName.Trim();
                this.tEdit_WarehouseCd.Text = string.Empty;
                this.ultraLabel_WarehouseName.Text = string.Empty;

                this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = this.uLabel_DateTitle.Text;
            }
            else if (this._stockMoveFixCode == 2) // ２：出荷確定なし 
            {
                if (this._initFlg)
                {
                    this.tComboEditor_SalesSlipDiv.SelectedIndex = 0;
                }
                this.tEdit_InputSectionCode.Text = this._loginSectionCode.Trim();
                this.ultraLabel_InputSectionName.Text = this._loginSectionName.Trim();
                this.tEdit_SecCd.Text = string.Empty;
                this.ultraLabel_SecName.Text = string.Empty;
                this.tEdit_WarehouseCd.Text = string.Empty;
                this.ultraLabel_WarehouseName.Text = string.Empty;
            }

            // 前回入力値保持用
            _prevInputValue = new PrevInputValue();

            // 前回値としての初期値セット
            _prevInputValue.InputSectionCode = this.tEdit_InputSectionCode.Text.Trim();
            _prevInputValue.SectionCode = this.tEdit_SecCd.Text.Trim();
            _prevInputValue.WarehouseCode = this.tEdit_WarehouseCd.Text.Trim();
            
            // データセットをクリア
            this._stockMovePprBackUp = null;

            adjustButtonEnable();
        }

        /// <summary>
        /// 出力区分変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 出力区分変更です。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tComboEditor_OutputDiv_ValueChanged(object sender, EventArgs e)
        {
            // 出力区分
            switch ((int)this.tComboEditor_OutputDiv.Value)
            {
                case 0: // 出荷分
                    {
                        this.uLabel_SecCd.Text = "出庫拠点";
                        this.uLabel_WarehouseCd.Text = "出庫倉庫";
                        this.uLabel_DateTitle.Text = "出荷日";

                        // 入荷区分入力:可
                        this.tComboEditor_ArrivalGoodsFlag.SelectedIndex = 0;
                        this.tComboEditor_ArrivalGoodsFlag.Enabled = true;
                        break;
                    }
                case 1: // 入荷済分
                    {
                        this.uLabel_SecCd.Text = "入庫拠点";
                        this.uLabel_WarehouseCd.Text = "入庫倉庫";
                        this.uLabel_DateTitle.Text = "入荷日";

                        // 入荷区分入力:不可
                        this.tComboEditor_ArrivalGoodsFlag.SelectedIndex = 1;
                        this.tComboEditor_ArrivalGoodsFlag.Enabled = false;
                        break;
                    }
                case 2: // 未入荷分
                    {
                        this.uLabel_SecCd.Text = "入庫拠点";
                        this.uLabel_WarehouseCd.Text = "入庫倉庫";
                        this.uLabel_DateTitle.Text = "出荷日";

                        // 入荷区分入力:不可
                        this.tComboEditor_ArrivalGoodsFlag.SelectedIndex = 2;
                        this.tComboEditor_ArrivalGoodsFlag.Enabled = false;
                        break;
                    }
                default: break;
            }
            if (this._stockMoveFixCode == 1 && this._stockMoveDataSet.StockMoveDetail.Rows.Count == 0)
            {
                this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = this.uLabel_DateTitle.Text;
            }
        }

        /// <summary>
        /// 伝票区分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 伝票区分です。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tComboEditor_SalesSlipDiv_ValueChanged(object sender, EventArgs e)
        {
            // 伝票区分
            switch ((int)this.tComboEditor_SalesSlipDiv.Value)
            {
                case 0: // 全て
                    {
                        this.uLabel_SecCd.Visible = false;
                        this.tEdit_SecCd.Enabled = false;
                        this.ultraLabel_SecName.Enabled = false;
                        this.uButton_SecGuide.Enabled = false;

                        this.tEdit_SecCd.Clear();
                        this.ultraLabel_SecName.Text = string.Empty;
                        this._prevInputValue.SectionCode = string.Empty;


                        this.uLabel_WarehouseCd.Visible = false;
                        this.tEdit_WarehouseCd.Enabled = false;
                        this.ultraLabel_WarehouseName.Enabled = false;
                        this.uButton_WarehouseGuide.Enabled = false;

                        this.tEdit_WarehouseCd.Clear();
                        this.ultraLabel_WarehouseName.Text = string.Empty;
                        this._prevInputValue.WarehouseCode = string.Empty;

                        // 棚番
                        this.tEdit_WarehouseShelfNo.Clear();
                        this._srWarehouseShelfNo = string.Empty;
                        this.tEdit_WarehouseShelfNo.Enabled = false;
                        this.tComboEditor_WarehouseShelfNoFuzzy.SelectedIndex = 0;
                        this.tComboEditor_WarehouseShelfNoFuzzy.Enabled = false;

                        // 相手拠点
                        this.tEdit_AfSectionCode.Clear();
                        //this._swAfSectionCode = 0; // DEL 2010/05/18
                        this._swAfSectionCode = string.Empty; // ADD 2010/05/18
                        this.tEdit_AfSectionCode.Enabled = false;
                        this.uButton_AfSectionCode.Enabled = false;

                        // 相手倉庫
                        this.tEdit_AfEnterWarehCode.Clear();
                        this._swAfEnterWarehCode = string.Empty;
                        this.tEdit_AfEnterWarehCode.Enabled = false;
                        this.uButton_AfEnterWarehCode.Enabled = false;

                        break;
                    }
                case 1: // 出庫
                    {
                        if (!this.uLabel_SecCd.Visible)
                        {
                            this.tEdit_SecCd.Text = "00";
                            this.ultraLabel_SecName.Text = "全社";
                        }

                        this.uLabel_SecCd.Visible = true;

                        this.tEdit_SecCd.Enabled = true;
                        this.uButton_SecGuide.Enabled = true;


                        this.uLabel_WarehouseCd.Visible = true;

                        this.tEdit_WarehouseCd.Enabled = true;
                        this.uButton_WarehouseGuide.Enabled = true;

                        this.uLabel_SecCd.Text = "出庫拠点";
                        this.uLabel_WarehouseCd.Text = "出庫倉庫";

                        // 棚番
                        this.tEdit_WarehouseShelfNo.Enabled = true;
                        this.tComboEditor_WarehouseShelfNoFuzzy.Enabled = true;

                        // 相手拠点
                        this.tEdit_AfSectionCode.Enabled = true;
                        this.uButton_AfSectionCode.Enabled = true;

                        // 相手倉庫
                        this.tEdit_AfEnterWarehCode.Enabled = true;
                        this.uButton_AfEnterWarehCode.Enabled = true;
                        
                        break;
                    }
                case 2: // 入庫
                    {
                        if (!this.uLabel_SecCd.Visible)
                        {
                            this.tEdit_SecCd.Text = "00";
                            this.ultraLabel_SecName.Text = "全社";

                        }

                        this.uLabel_SecCd.Visible = true;

                        this.tEdit_SecCd.Enabled = true;
                        this.uButton_SecGuide.Enabled = true;


                        this.uLabel_WarehouseCd.Visible = true;

                        this.tEdit_WarehouseCd.Enabled = true;
                        this.uButton_WarehouseGuide.Enabled = true;

                        this.uLabel_SecCd.Text = "入庫拠点";
                        this.uLabel_WarehouseCd.Text = "入庫倉庫";

                        // 棚番
                        this.tEdit_WarehouseShelfNo.Enabled = true;
                        this.tComboEditor_WarehouseShelfNoFuzzy.Enabled = true;

                        // 相手拠点
                        this.tEdit_AfSectionCode.Enabled = true;
                        this.uButton_AfSectionCode.Enabled = true;

                        // 相手倉庫
                        this.tEdit_AfEnterWarehCode.Enabled = true;
                        this.uButton_AfEnterWarehCode.Enabled = true;

                        break;
                    }
                default: break;
            }
        }

        #region ツールバー

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ツールバークリックイベントです。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                #region 終了ボタン
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                #endregion // 終了ボタン

                # region クリアボタン
                case "ButtonTool_Clear":
                    {
                        this.ClearInput();
                        break;
                    }
                # endregion

                #region 検索ボタン
                case "ButtonTool_Search":
                    // 検索ボタン
                    {
                        _stockMovePprBackUp = null;
                        ChangeFocusEventArgs eArgs = null;
                        bool findFocusItem = false;
                        if (_nextControl == null
                            || _nextControl.Name == "tEdit_InputSectionCode"
                            || _nextControl.Name == "tEdit_SecCd"
                            || _nextControl.Name == "tEdit_WarehouseCd"
                            || _nextControl.Name == "tEdit_SalesEmployeeCd"
                            || _nextControl.Name == "tEdit_SupplierCd"
                            || _nextControl.Name == "tEdit_MakerCd"
                            || _nextControl.Name == "tEdit_BlGoodsCode"
                            || _nextControl.Name == "tEdit_AfSectionCode"
                            || _nextControl.Name == "tEdit_AfEnterWarehCode"
                            || _nextControl.Name == "tEdit_GoodsNo"
                            || _nextControl.Name == "tEdit_GoodsName"
                            || _nextControl.Name == "tEdit_WarehouseShelfNo"
                            || _nextControl.Name == "tEdit_SlipNote")
                        {
                            if (this.ultraExpandableGroupBoxPanel1.Visible)
                            {
                                foreach (Control control in this.ultraExpandableGroupBoxPanel1.Controls)
                                {
                                    if (control.ContainsFocus)
                                    {
                                        eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, control, control);
                                        findFocusItem = true;
                                        break;
                                    }
                                }
                            }
                            if (!findFocusItem && this.ultraExpandableGroupBoxPanel2.Visible)
                            {
                                foreach (Control control in this.ultraExpandableGroupBoxPanel2.Controls)
                                {
                                    if (control.ContainsFocus)
                                    {
                                        eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, control, control);
                                        break;
                                    }
                                }
                            }
                            if (eArgs != null)
                            {
                                this._doSearchFlg = false;
                                tArrowKeyControl_ChangeFocus(null, eArgs);
                                if (_isError == true)
                                {
                                    _isError = false;
                                    return;
                                }
                            }
                        }
                        Control errorControl = this.SearchOnChangeFocus(null);
                        // エラーコントロールに移動
                        if (errorControl != null)
                        {
                            errorControl.Focus();
                        }
                        break;
                    }
                #endregion // 検索ボタン

                #region 伝票選択ボタン
                case "ButtonTool_SalesSlipSelect":
                    {
                        this.stockMoveSlipSelectSetting();
                        break;
                    }
                #endregion

                #region 基本条件ボタン
                case "ButtonTool_CommonCondition":
                    {
                        this.commonConditionSetting();
                        break;
                    }
                #endregion

                #region 抽出条件ボタン
                case "ButtonTool_ExtraCondition":
                    {
                        this.extraConditionSetting();
                        break;
                    }
                #endregion

                #region 合計表示ボタン
                case "ButtonTool_TotalShow":
                    {
                        this.totalShowSetting();
                        break;
                    }
                #endregion

                #region 伝票再発行ボタン
                case "ButtonTool_ReissueSlip":
                    {
                        this.ReisssueSlip();
                        break;
                    }
                #endregion 伝票再発行ボタン

                #region テキスト出力
                case "ButtonTool_ExtractText":
                    {
                        exportIntoTextFile();
                        break;
                    }
                #endregion // テキスト出力

                #region EXCEL出力
                case "ButtonTool_ExtractExcel":
                    {
                        exportIntoExcelData();
                        break;
                    }
                #endregion // EXCEL出力

                #region 設定ボタン
                case "ButtonTool_Configuration":
                    {
                        this.openSetting();
                        break;
                    }
                #endregion

                #region 行検索ボタン
                case "ButtonTool_RowSearchStart":
                    {
                        this.rowSearchStart();
                        break;
                    }
                #endregion // 行検索ボタン

                default: break;
            }

            _nextControl = null;
        }
        #endregion // ツールバー

        #region クリア
        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面クリア処理です。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void ClearInput()
        {
            // 確認ダイアログ
            if (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, this.Name,
                MSG_CONFIRM_CLEARINPUT,
                -1, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            // 描画停止 ＞＞＞
            this.SuspendLayout();
            try
            {
                // 共通条件グループを強制的に展開状態にする
                uExGroupBox_CommonCondition.Expanded = true;

                // 初期フォーカス(出力区分または伝票区分)
                if (this._stockMoveFixCode == 1)
                {
                    this.tEdit_WarehouseCd.Focus();
                }
                else if (this._stockMoveFixCode == 2)
                {
                    this.tEdit_InputSectionCode.Focus();
                }

                // 初期化
                ClearInputProc();

                this._stockMovePpr = new StockMovePpr();

                // 詳細条件のクリア
                this.ClearExtraConditions();

                this._stockMoveDataSet.StockMoveDetail.Clear();

                this.adjustButtonEnable();

            }
            finally
            {
                // 描画再開 ＜＜＜
                this.ResumeLayout();
            }
        }
        #endregion // クリア

        #region 検索

        /// <summary>
        /// フォーカス移動時の検索処理
        /// </summary>
        /// <param name="prevControl"></param>
        /// <remarks>PM7同様の操作性を実現する為の処理</remarks>
        /// <remarks>
        /// <br>Note       : フォーカス移動時の検索処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private Control SearchOnChangeFocus(Control prevControl)
        {
            Control nextControl = prevControl;

            // 検索実行
            Control errorControl = this.SearchSlipDetailList();
            if (errorControl != null)
            {
                nextControl = errorControl;
            }
            else
            {
                if (this.uGrid_StockMove.Rows.Count > 0)
                {
                    this.uGrid_StockMove.Focus();
                    uGrid_StockMove.Rows[0].Cells[0].Activate();
                    uGrid_StockMove.Rows[0].Cells[0].Selected = true;
                    return null;
                }
            }

            return nextControl;
        }

        #region 画面→検索条件クラス
        /// <summary>
        /// 画面の値を検索条件クラスに保存
        /// </summary>
        /// <returns>正常に変換 true, 値が不正 false</returns>
        /// <br>Note       : 品名入力欄Enterイベント</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private bool SetDisplaySearchConditionClass()
        {
            // 在庫移動確定区分
            this._stockMovePpr.StockMoveFixCode = this._stockMoveFixCode;

            // 検索上限
            this._stockMovePpr.SearchCnt = DATA_COUNT_MAX + 1;

            // 企業コード
            this._stockMovePpr.EnterpriseCode = this._enterpriseCode;

            // 出力区分
            this._stockMovePpr.OutputDiv = (int)this.tComboEditor_OutputDiv.SelectedIndex;

            // 伝票区分
            this._stockMovePpr.SalesSlipDiv = (int)this.tComboEditor_SalesSlipDiv.SelectedIndex;

            // 入力拠点コード
            if (String.IsNullOrEmpty(this.tEdit_InputSectionCode.Text.Trim()) || this.tEdit_InputSectionCode.Text.Trim() == "00")
            {
                this._stockMovePpr.InputSectionCode = null;
            }
            else
            {
                this._stockMovePpr.InputSectionCode = this.tEdit_InputSectionCode.Text.Trim();
            }

            // 拠点コード
            if (String.IsNullOrEmpty(this.tEdit_SecCd.Text.Trim()) || this.tEdit_SecCd.Text.Trim() == "00")
            {
                this._stockMovePpr.SectionCode = null;
            }
            else
            {
                this._stockMovePpr.SectionCode = this.tEdit_SecCd.Text.Trim();
            }

            // 倉庫コード
            this._stockMovePpr.WarehouseCode = this.tEdit_WarehouseCd.Text.Trim();

            // 開始売上日付
            this._stockMovePpr.St_Date = this.tDateEdit_DateSt.GetDateTime();

            // 終了売上日付
            this._stockMovePpr.Ed_Date = this.tDateEdit_DateEd.GetDateTime();

            // 伝票番号
            this._stockMovePpr.SalesSlipNum = this.tEdit_StockMoveSlipNum.Text.Trim();

            // 開始入力日付
            this._stockMovePpr.St_AddUpADate = this.tDateEdit_AddUpADateSt.GetDateTime();

            // 終了入力日付
            this._stockMovePpr.Ed_AddUpADate = this.tDateEdit_AddUpADateEd.GetDateTime();

            // 担当者
            this._stockMovePpr.SalesEmployeeCd = this._swSalesEmployeeCd;

            // BLコード
            this._stockMovePpr.BLGoodsCode = this._swBLGoodsCode;

            // メーカーコード
            this._stockMovePpr.GoodsMakerCd = this._swGoodsMakerCd;

            // 仕入先
            this._stockMovePpr.SupplierCd = this._swSupplierCd;

            // 品名
            this._stockMovePpr.GoodsName = _srGoodsName.Replace("*", "%");

            // 品番
            this._stockMovePpr.GoodsNo = _srGoodsNo.Replace("*", "%");

            // 明細備考
            this._stockMovePpr.SlipNote = _srSlipNote.Replace("*", "%");

            // 棚番
            this._stockMovePpr.WarehouseShelfNo = _srWarehouseShelfNo.Replace("*", "%");

            // 相手拠点
            //if (String.IsNullOrEmpty(this._swAfSectionCode.ToString()) || this._swAfSectionCode.ToString() == "0") // DEL 2010/05/18
            if (String.IsNullOrEmpty(this._swAfSectionCode)) // ADD 2010/05/18
            {
                this._stockMovePpr.AfSectionCode = null;
            }
            else
            {
                //this._stockMovePpr.AfSectionCode = this._swAfSectionCode.ToString(); // DEL 2010/05/18
                this._stockMovePpr.AfSectionCode = this._swAfSectionCode; // ADD 2010/05/18
            }

            // 相手倉庫
            if (String.IsNullOrEmpty(this._swAfEnterWarehCode))
            {
                this._stockMovePpr.AfEnterWarehCode = null;
            }
            else
            {
                this._stockMovePpr.AfEnterWarehCode = this._swAfEnterWarehCode;
            }


            // 入荷区分
            this._stockMovePpr.ArrivalGoodsFlag = (int)this.tComboEditor_ArrivalGoodsFlag.SelectedIndex;

            // 削除指定区分
            this._stockMovePpr.DeleteFlag = (int)this.tComboEditor_DeleteFlag.SelectedIndex;
            return true;
        }

        #endregion // 画面→検索条件クラス

        #region 検索実行処理
        /// <summary>
        /// 検索実行処理
        /// </summary>
        /// <returns>エラーコントロール</returns>
        /// <remarks>
        /// <br>Note       : エラーコントロール。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private Control SearchSlipDetailList()
        {
            long dataCount = 0;
            _stockMoveSlipSearchAcs.ExtractCancelFlag = false;

            Control errorControl = null;

            int status = 0;

            // 必須入力チェック
            if (!CheckItemValues(out errorControl)) return errorControl;

            // 画面上の項目からパラメータを作成
            if (!SetDisplaySearchConditionClass())
            {
                return null;
            }

            if (CompareStockMovePpr(this._stockMovePpr, _stockMovePprBackUp))
            {
                return null;
            }
            // 削除指定区分
            this._logicalDelDiv = (int)tComboEditor_DeleteFlag.SelectedItem.DataValue;

            // 行選択ボタンOFF
            this.tToolbarsManager.Tools["ButtonTool_RowSelect"].SharedProps.Enabled = false;

            // クリア
            this._stockMoveDataSet.StockMoveDetail.Clear();
            this._stockMoveDataSet.StockMoveTotal.Clear();

            if (this._stockMoveFixCode == 1)
            {
                if (this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Hidden)
                {
                    this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Hidden = false;
                    this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = this.uLabel_DateTitle.Text;
                    this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Hidden = true;
                }
                else
                {
                    this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = this.uLabel_DateTitle.Text;
                }
            }
            // 在庫移動確定区分＝入荷確定なしの場合
            else if (this._stockMoveFixCode == 2)
            {
                this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = "伝票日付";
            }

            _processingDialog = new SFCMN00299CA();
            SFCMN00299CA processingDialog = _processingDialog;
            try
            {
                processingDialog.Title = "抽出処理";
                processingDialog.Message = "現在、データ抽出中です。(ESCで中断します)";
                processingDialog.DispCancelButton = true;
                processingDialog.CancelButtonClick += new EventHandler(processingDialog_CancelButtonClick);
                processingDialog.Show((Form)this.Parent);
                // パラメータクラスを使って検索開始
                if (_stockMoveSlipSearchAcs.ExtractCancelFlag == false)
                {
                    status = this._stockMoveSlipSearchAcs.Search(this._stockMovePpr, this._logicalDelDiv, out dataCount);
                }
            }
            finally
            {
                processingDialog.Dispose();
            }

            SetGridCheckBoxEnabled();

            if (this._stockMoveDataSet.StockMoveTotal.Rows.Count > 0)
            {
                //--------------------
                // 合計表示タブ
                //--------------------
                // 出荷/出庫 合計数量
                uLabel_Count1.Text = ((double)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.ShipmentCount_TotalColumn.ColumnName]).ToString("#,##0.00;-#,##0.00;");

                // 出荷/出庫 合計金額
                uLabel_Money1.Text = ((long)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.ShipmentPrice_TotalColumn.ColumnName]).ToString("#,##0;-#,##0;");

                // 出荷/出庫 合計標準価格
                uLabel_Cost1.Text = ((double)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.ShipmentListPriceFl_TotalColumn.ColumnName]).ToString("#,##0;-#,##0;");

                // 入荷済/入庫 合計数量
                uLabel_Count2.Text = ((double)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.ArrivalCount_TotalColumn.ColumnName]).ToString("#,##0.00;-#,##0.00;");

                // 入荷済/入庫 合計金額
                uLabel_Money2.Text = ((long)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.ArrivalPrice_TotalColumn.ColumnName]).ToString("#,##0;-#,##0;");

                // 入荷済/入庫 合計標準価格
                uLabel_Cost2.Text = ((double)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.ArrivalListPriceFl_TotalColumn.ColumnName]).ToString("#,##0;-#,##0;");

                // 未入荷 合計数量
                uLabel_Count3.Text = ((double)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.NotArrivalCount_TotalColumn.ColumnName]).ToString("#,##0.00;-#,##0.00;");

                // 未入荷 合計金額
                uLabel_Money3.Text = ((long)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.NotArrivalPrice_TotalColumn.ColumnName]).ToString("#,##0;-#,##0;");

                // 未入荷 合計標準価格
                uLabel_Cost3.Text = ((double)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.NotArrivalListPriceFl_TotalColumn.ColumnName]).ToString("#,##0;-#,##0;");

                // 伝票枚数
                uLabel_SlipCount.Text = ((int)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.SlipCountColumn.ColumnName]).ToString("#,##0;-#,##0;");

                // 明細数
                if (dataCount > DATA_COUNT_MAX)
                {
                    uLabel_DetailCount.Text = (((int)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.DetailCountColumn.ColumnName])).ToString("#,##0;-#,##0;");
                }
                else
                {
                    uLabel_DetailCount.Text = ((int)this._stockMoveDataSet.StockMoveTotal.Rows[0][_stockMoveDataSet.StockMoveTotal.DetailCountColumn.ColumnName]).ToString("#,##0;-#,##0;");
                }

                if (this._stockMoveFixCode == 1)
                {
                    switch (this.tComboEditor_OutputDiv.SelectedIndex)
                    {
                        case 0:
                            {
                                this.uLabel_Count2.Text = string.Empty;
                                this.uLabel_Money2.Text = string.Empty;
                                this.uLabel_Cost2.Text = string.Empty;

                                this.uLabel_Count3.Text = string.Empty;
                                this.uLabel_Money3.Text = string.Empty;
                                this.uLabel_Cost3.Text = string.Empty;
                            }
                            break;
                        case 1:
                            {
                                this.uLabel_Count1.Text = string.Empty;
                                this.uLabel_Money1.Text = string.Empty;
                                this.uLabel_Cost1.Text = string.Empty;

                                this.uLabel_Count3.Text = string.Empty;
                                this.uLabel_Money3.Text = string.Empty;
                                this.uLabel_Cost3.Text = string.Empty;
                            }
                            break;
                        case 2:
                            {
                                this.uLabel_Count1.Text = string.Empty;
                                this.uLabel_Money1.Text = string.Empty;
                                this.uLabel_Cost1.Text = string.Empty;

                                this.uLabel_Count2.Text = string.Empty;
                                this.uLabel_Money2.Text = string.Empty;
                                this.uLabel_Cost2.Text = string.Empty;
                            }
                            break;
                    }
                }
                else if (this._stockMoveFixCode == 2)
                {
                    switch (this.tComboEditor_SalesSlipDiv.SelectedIndex)
                    {
                        case 0:
                            break;
                        case 1:
                            {
                                this.uLabel_Count2.Text = string.Empty;
                                this.uLabel_Money2.Text = string.Empty;
                                this.uLabel_Cost2.Text = string.Empty;
                            }
                            break;
                        case 2:
                            {
                                this.uLabel_Count1.Text = string.Empty;
                                this.uLabel_Money1.Text = string.Empty;
                                this.uLabel_Cost1.Text = string.Empty;
                            }
                            break;
                    }
                }
            }
            else
            {
                this.uLabel_Count1.Text = string.Empty;
                this.uLabel_Money1.Text = string.Empty;
                this.uLabel_Cost1.Text = string.Empty;

                this.uLabel_Count2.Text = string.Empty;
                this.uLabel_Money2.Text = string.Empty;
                this.uLabel_Cost2.Text = string.Empty;

                this.uLabel_Count3.Text = string.Empty;
                this.uLabel_Money3.Text = string.Empty;
                this.uLabel_Cost3.Text = string.Empty;

                this.uLabel_SlipCount.Text = string.Empty;
                this.uLabel_DetailCount.Text = string.Empty;
            }

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                        (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                // 条件に合うデータなし
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    MSG_MATCHED_DATA_NOT_FOUND, -1, MessageBoxButtons.OK);
                //前回検索条件格納
                this._stockMovePprBackUp = null;
                this._logicalDelDivBackUp = -1;
                //_clearFlg = true;
                if (this.tEdit_InputSectionCode.Visible)
                {
                    errorControl = this.tEdit_InputSectionCode;
                }
                else
                {
                    errorControl = this.tEdit_SecCd;
                }
            }
            else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // それ以外のステータス
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    MSG_FAILED2GET_SLIP_DATA, status, MessageBoxButtons.OK);

                if (this.tEdit_InputSectionCode.Visible)
                {
                    errorControl = this.tEdit_InputSectionCode;
                }
                else
                {
                    errorControl = this.tEdit_SecCd;
                }
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 正常終了時は明細選択行の「選択」に移動する
                if (uGrid_StockMove.Rows.Count > 0)
                {
                    // 在庫移動確定区分＝入荷確定あり
                    if (this._stockMoveFixCode == 1)
                    {
                        // 出力区分＝入荷済分
                        if (this._stockMovePpr.OutputDiv == 1)
                        {
                            this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = "入荷日";
                        }
                        else
                        {
                            this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = "出荷日";
                        }

                    }
                    // 在庫移動確定区分＝入荷確定なし
                    else if (this._stockMoveFixCode == 2)
                    {
                        this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = "伝票日付";
                    }
                }

                //前回検索条件格納
                this._stockMovePprBackUp = this._stockMovePpr.Clone();
                this._logicalDelDivBackUp = this._logicalDelDiv;
            }

            adjustButtonEnable();

            if (_stockMoveSlipSearchAcs.ExtractCancelFlag == true)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    "処理を中断しました。",
                    status, MessageBoxButtons.OK);

                if (this.tEdit_InputSectionCode.Visible)
                {
                    return this.tEdit_InputSectionCode;
                }
                else
                {
                    return this.tEdit_SecCd;
                }
            }
            else if (dataCount > DATA_COUNT_MAX)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    string.Format("データ件数が{0:#,##0}件を超えました。", DATA_COUNT_MAX),
                    status, MessageBoxButtons.OK);
            }
            _stockMoveSlipSearchAcs.ExtractCancelFlag = false;
            return errorControl;
        }
        #endregion // 検索実行処理

        #region 必須項目チェック
        /// <summary>
        /// 必須項目チェック
        /// </summary>
        /// <param name="errorControl"></param>
        /// <returns>必須条件を満たす true, 違反 false</returns>
        /// <br>Note       : 必須項目チェック</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private bool CheckItemValues(out Control errorControl)
        {
            errorControl = null;
            DateGetAcs.CheckDateRangeResult cdrResult;

            //-----------------------------------------------------------
            // 入出荷日（開始～終了）
            //-----------------------------------------------------------
            # region [入出荷日]
            if (CheckDateRangeForSlip(ref tDateEdit_DateSt, ref tDateEdit_DateEd, out cdrResult, true) == false)
            {
                string errorMessage = string.Empty;
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        errorMessage = MSG_ST_SALESDATE_ERROR + this.uLabel_DateTitle.Text + MSG_SALESDATE_ERROR;
                        errorControl = tDateEdit_DateSt;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        errorMessage = MSG_ED_SALESDATE_ERROR + this.uLabel_DateTitle.Text + MSG_SALESDATE_ERROR;
                        errorControl = tDateEdit_DateEd;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        errorMessage = MSG_MUST_BE_CORRECT_CALENDER;
                        errorControl = tDateEdit_DateSt;
                        break;
                }

                if (errorMessage != string.Empty && errorControl != null)
                {
                    // メッセージ表示
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        errorMessage, -1, MessageBoxButtons.OK);

                    return false;
                }
            }
            # endregion

            //-----------------------------------------------------------
            // 入力日（開始～終了）
            //-----------------------------------------------------------
            # region [入力日]

            string errorMessage2 = string.Empty;

            if (CheckDateRangeForSlip(ref tDateEdit_AddUpADateSt, ref tDateEdit_AddUpADateEd, out cdrResult, true) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        errorMessage2 = MSG_ST_INPUTDATE_ERROR;
                        errorControl = tDateEdit_AddUpADateSt;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        errorMessage2 = MSG_ED_INPUTDATE_ERROR;
                        errorControl = tDateEdit_AddUpADateEd;
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        errorMessage2 = MSG_MUST_BE_CORRECT_CALENDER;
                        errorControl = tDateEdit_AddUpADateSt;
                        break;
                }
            }
            if (errorMessage2 != string.Empty && errorControl != null)
            {
                // メッセージ表示
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    errorMessage2, -1, MessageBoxButtons.OK);

                return false;
            }
            # endregion

            // 全て正常時のみtrue
            return true;
        }

        #endregion // 必須項目チェック

        #region 中断ボタン押下
        /// <summary>
        /// 中断ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : 日付範囲チェック処理</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private void processingDialog_CancelButtonClick(object sender, EventArgs e)
        {
            // 抽出キャンセル
            CancelExtract();
        }

        # region 抽出キャンセル処理
        /// <summary>
        /// 抽出キャンセル
        /// </summary>
        /// <br>Note       : 抽出キャンセル処理</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private void CancelExtract()
        {
            // 抽出キャンセル
            _stockMoveSlipSearchAcs.ExtractCancelFlag = true;
            if (_processingDialog != null)
            {
                _processingDialog.Message = "中断します。";
            }
        }
        # endregion // 抽出キャンセル処理
        #endregion // 中断ボタン押下
        #endregion 検索

        #region 伝票選択

        /// <summary>
        /// 伝票選択
        /// </summary>
        /// <remarks>
        /// <br>Note       : 伝票選択です。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void stockMoveSlipSelectSetting()
        {
            try
            {
                this.uGrid_StockMove.BeginUpdate();
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                string stockMoveSlipNo = string.Empty;
                DateTime date;
                int stockMoveFormalCd;
                if (this.uGrid_StockMove.ActiveCell == null && this.uGrid_StockMove.ActiveRow != null)
                {
                    this.uGrid_StockMove.ActiveCell = this.uGrid_StockMove.ActiveRow.Cells[0];
                }
                if (this.uGrid_StockMove.ActiveCell != null)
                {
                    gridRow = this.uGrid_StockMove.ActiveCell.Row;

                    stockMoveSlipNo = gridRow.Cells[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].Value.ToString();
                    date = (DateTime)gridRow.Cells[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Value;
                    stockMoveFormalCd = (int)gridRow.Cells[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalCdColumn.ColumnName].Value;
                    // 明細表示DataTableのビューを生成
                    DataView detailView = new DataView(this._stockMoveDataSet.StockMoveDetail);
                    // (フィルタ)
                    detailView.RowFilter = string.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}'",
                                                            this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName, stockMoveSlipNo,
                                                            this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName, date,
                                                            this._stockMoveDataSet.StockMoveDetail.StockMoveFormalCdColumn.ColumnName, stockMoveFormalCd);
                    // (ソート)
                    detailView.Sort = string.Format("{0},{1},{2}",
                                                            this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName,
                                                            this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName,
                                                            this._stockMoveDataSet.StockMoveDetail.StockMoveFormalCdColumn.ColumnName);

                    if (detailView.Count > 0)
                    {
                        int rowNo = 0;
                        bool selectionCheckFlg = true;
                        foreach (DataRowView rowView in detailView)
                        {
                            // RowViewに対応するRowを取得
                            DataRow detailRow = rowView.Row;

                            // 行を選択
                            rowNo = Int32.Parse(detailRow["RowNo"].ToString());

                            // 明細行を選択
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridDetailRow in this.uGrid_StockMove.Rows)
                            {
                                if (gridDetailRow.Cells[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Hidden == false &&
                                    (int)gridDetailRow.Cells[this._stockMoveDataSet.StockMoveDetail.RowNoColumn.ColumnName].Value == rowNo &&
                                    gridDetailRow.Cells[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Value != DBNull.Value &&
                                    (bool)gridDetailRow.Cells[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Value == false)
                                {
                                    selectionCheckFlg = false;
                                    break;
                                }
                            }
                            if (!selectionCheckFlg) break;
                        }

                        foreach (DataRowView dataRowView in detailView)
                        {
                            // dataRowViewに対応するRowを取得
                            DataRow detailRow = dataRowView.Row;

                            // 行を選択
                            rowNo = Int32.Parse(detailRow["RowNo"].ToString());

                            // 明細行を選択
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridDetailRow in this.uGrid_StockMove.Rows)
                            {
                                if (gridDetailRow.Cells[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Hidden == false &&
                                    (int)gridDetailRow.Cells[this._stockMoveDataSet.StockMoveDetail.RowNoColumn.ColumnName].Value == rowNo &&
                                    gridDetailRow.Cells[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Value != DBNull.Value)
                                {
                                    // 伝票の明細行が全部選択した場合
                                    if (selectionCheckFlg)
                                    {
                                        this.RowSelectClicked(false, gridDetailRow);
                                    }
                                    else
                                    {
                                        this.RowSelectClicked(true, gridDetailRow);
                                    }
                                    
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                this.uGrid_StockMove.EndUpdate();
                // グリッドを更新
                this.uGrid_StockMove.Refresh();
            }

        }
        #endregion

        #region 基本条件
        /// <summary>
        /// 基本条件グループＢＯＸの展開と縮小を切り替える
        /// </summary>
        /// <remarks>
        /// <br>Note       : 基本条件グループＢＯＸの展開と縮小を切り替える。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void commonConditionSetting()
        {
            if (this.uExGroupBox_CommonCondition.Expanded)
            {
                this.uExGroupBox_CommonCondition.Expanded = false;
            }
            else
            {
                this.uExGroupBox_CommonCondition.Expanded = true;
            }
        }
        #endregion

        #region 抽出条件
        /// <summary>
        /// 抽出条件グループＢＯＸの展開と縮小を切り替える
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出条件グループＢＯＸの展開と縮小を切り替える。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void extraConditionSetting()
        {
            if (this.uExGroupBox_ExtraCondition.Expanded)
            {
                this.uExGroupBox_ExtraCondition.Expanded = false;
            }
            else
            {
                this.uExGroupBox_ExtraCondition.Expanded = true;
            }
        }
        #endregion

        #region 合計表示
        /// <summary>
        /// 合計グループＢＯＸの展開と縮小を切り替える
        /// </summary>
        /// <remarks>
        /// <br>Note       : 合計グループＢＯＸの展開と縮小を切り替える。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void totalShowSetting()
        {
            if (this.uExGroupBox_BalanceChart.Expanded)
            {
                // 縮小
                this.uExGroupBox_BalanceChart.Expanded = false;
            }
            else
            {
                // 展開
                this.uExGroupBox_BalanceChart.Expanded = true;
            }
        }
        #endregion

        #region 伝票再発行

        /// <summary>
        /// 伝票再発行
        /// </summary>
        /// <remarks>
        /// <br>Note       : 選択したデータ、伝票再発行処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void ReisssueSlip()
        {
            DataRow[] rows = this._stockMoveDataSet.StockMoveDetail.Select("SelectionCheck = true");
            // 伝票が選択されている場合のみ
            if (rows == null) return;
            if (rows.Length > 0)
            {
                // 初期処理
                DCCMN02000UA printDisp = new DCCMN02000UA(); // 伝票印刷情報設定画面インスタンス生成
                StockMoveSlipPrintCndtn.StockMoveSlipKey key = new StockMoveSlipPrintCndtn.StockMoveSlipKey(); // 伝票印刷用Keyインスタンス生成
                List<StockMoveSlipPrintCndtn.StockMoveSlipKey> keyList = new List<StockMoveSlipPrintCndtn.StockMoveSlipKey>(); // 伝票印刷用KeyListインスタンス生成

                // keyListを作成する。
                foreach (DataRow row in rows)
                {
                    key = new StockMoveSlipPrintCndtn.StockMoveSlipKey();

                    // 移動形式
                    key.StockMoveFormal = (int)row[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalCdColumn.ColumnName];
                    // 移動伝票番号
                    key.StockMoveSlipNo = (int)row[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName];
                    if (keyList.Count == 0 || !keyList.Contains(key))
                    {
                        keyList.Add(key);
                    }
                }

                // 印刷情報パラメータセット
                StockMoveSlipPrintCndtn stockMoveSlipPrintCndtn = new StockMoveSlipPrintCndtn();
                stockMoveSlipPrintCndtn.EnterpriseCode = this._enterpriseCode;
                stockMoveSlipPrintCndtn.ReissueDiv = true; // 再発行=true
                stockMoveSlipPrintCndtn.StockMoveSlipKeyList = keyList;

                // 確認ダイアログ
                if (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    MSG_CONFIRM_PRINTDISP,
                    -1, MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                if (keyList.Count > 0)
                {
                    printDisp.Print(stockMoveSlipPrintCndtn);
                }

                #region タブチェック削除
                string selectionColName = this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName;
                string rowNoColName = this._stockMoveDataSet.StockMoveDetail.RowNoColumn.ColumnName;

                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow salesDetailRow in this.uGrid_StockMove.Rows)
                {
                    if (salesDetailRow.Cells[selectionColName].Value != DBNull.Value && (bool)salesDetailRow.Cells[selectionColName].Value == true)
                    {
                        DataRow denRow = this._stockMoveDataSet.StockMoveDetail.Rows.Find((int)salesDetailRow.Cells[rowNoColName].Value);
                        denRow[selectionColName] = false;
                        this.RowBackColorChange(false, salesDetailRow);
                    }
                }

                this.uGrid_StockMove.Refresh();
                this.adjustButtonEnable();
                #endregion

            }
        }

        #endregion

        #region テキスト出力

        /// <summary>
        /// テキスト出力
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void exportIntoTextFile()
        {
            PMZAI04604UA settingConstForm = this._settingForm;

            // 設定オブジェクトを取得
            this._userSetting = settingConstForm.UserSetting;
            string outputFileName = this._userSetting.OutputFileName;
            if (String.IsNullOrEmpty(this._userSetting.OutputFileName))
            {
                // ファイル名が指定されていないとエラー
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_OUTPUTFILENAME_NOTFOUND, -1, MessageBoxButtons.OK);

                return;
            }

            // 確認ダイアログ生成・表示
            PMZAI04604UB textOutDialog = new PMZAI04604UB();
            textOutDialog.UserSetting = _userSetting;
            if (textOutDialog.ShowDialog() != DialogResult.OK)
            {
                // 中止
                return;
            }

            // ShowDialogにより、_userSettingは書き変わっているので設定XML更新
            settingConstForm.Serialize();

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

            // パターンを分解
            _patternSetting = new string[9];
            settingConstForm.Degradation(this._userSetting.SelectedPatternName, out _patternSetting);

            // パターンの構成
            // 区切り文字(タブ・任意・固定長）/区切り文字任意/  0-1
            // 括り文字(”・任意）/括り文字任意/                2-3
            // 数値括り（する／しない)                          4
            // 文字括り（する／しない)                          5
            // タイトル行（あり／なし）                         6
            // 出力項目リスト (xx項目x3文字) 基本的に表示順の数字,非表示の場合は+100, 必ずStockMoveDetailの順に並んでいる 7


            // カラム名一覧を作成
            // 明細
            _exportColumnNameList = settingConstForm.GetColumnNameList(_patternSetting[7], false);
            string[] gridSetting;
            getGridSettingPattern(_patternSetting[7], out gridSetting);
            List<String> schemeList;
            getSchemeList(gridSetting, out schemeList);

            // 出力項目名
            tw.SchemeList = schemeList;

            // 固定長：明細
            SalesDtlMaxLength(ref tw);

            if (_stockMoveFixCode == 1)
            {
                // 出力区分＝入荷済分
                if (this._stockMovePpr.OutputDiv == 1)
                {
                    this._stockMoveDataSet.StockMoveDetail.DateColumn.Caption = "入荷日";
                }
                else
                {
                    this._stockMoveDataSet.StockMoveDetail.DateColumn.Caption = "出荷日";
                }

            }
            else if (_stockMoveFixCode == 2)
            {
                this._stockMoveDataSet.StockMoveDetail.DateColumn.Caption = "伝票日付";
            }
            tw.DataSource = this.uGrid_StockMove.DataSource;

            // グリッドのソート情報を適用する
            if (tw.DataSource is DataView)
            {
                (tw.DataSource as DataView).Sort = GetSortingColumns(this.uGrid_StockMove);
            }

            # region [フォーマットリスト]
            Dictionary<string, string> formatList = new Dictionary<string, string>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in uGrid_StockMove.DisplayLayout.Bands[0].Columns)
            {
                formatList.Add(col.Key, col.Format);
            }
            tw.FormatList = formatList;
            # endregion

            #region オプションセット
            // ファイル名
            tw.OutputFileName = this._userSetting.OutputFileName;
            // 区切り文字
            if (this._patternSetting[0] == "0")
            {
                tw.Splitter = "\t";
            }
            else if (this._patternSetting[0] == "1")
            {
                tw.Splitter = this._patternSetting[1];
            }
            else
            {
                tw.Splitter = string.Empty;
            }
            // 項目括り文字
            if (this._patternSetting[2] == "0")
            {
                tw.Encloser = "\"";
            }
            else if (this._patternSetting[2] == "1")
            {
                tw.Encloser = this._patternSetting[3];
            }
            // 固定幅
            if (this._patternSetting[0] == "2")
            {
                tw.FixedLength = true;
            }
            else
            {
                tw.FixedLength = false;
            }
            // タイトル行出力
            if (this._patternSetting[6] == "1")
            {
                tw.CaptionOutput = false;
            }
            else
            {
                tw.CaptionOutput = true;
            }
            // 項目括り適用
            List<Type> enclosingList = new List<Type>();
            if (this._patternSetting[4] == "0")
            {
                enclosingList.Add(typeInt16.GetType());
                enclosingList.Add(typeInt32.GetType());
                enclosingList.Add(typeInt64.GetType());
                enclosingList.Add(typeDouble.GetType());
                enclosingList.Add(typeDecimal.GetType());
                enclosingList.Add(typeSingle.GetType());
            }
            if (this._patternSetting[5] == "0")
            {
                enclosingList.Add(typeStr.GetType());
                enclosingList.Add(typeChar.GetType());
                enclosingList.Add(typeByte.GetType());
                enclosingList.Add(typeDate.GetType());
            }
            tw.EnclosingTypeList = enclosingList;
            #endregion

            int outputCount = 0;
            int status = tw.TextOut(out outputCount);

            if (status == 9)// 異常終了
            {
                // 出力失敗
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_OUTPUTFILE_FAILED, -1, MessageBoxButtons.OK);
            }
            else
            {
                // 出力成功
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    outputCount.ToString() + MSG_OUTPUTFILE_SUCCEEDED, -1, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 固定長：明細
        /// </summary>
        /// <param name="tw"></param>
        /// <remarks>
        /// <br>Note       : 固定長：明細。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/20 朱俊成 仕入先と仕入先名を追加します</br>
        /// </remarks>
        private void SalesDtlMaxLength(ref FormattedTextWriter tw)
        {
            #region

            tw.MaxLengthList = new Dictionary<string, int>();
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName, 10);          //入出荷日/伝票日付
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName, 9);    //伝票番号
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName, 6);         //行No
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName, 4);       //区分
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.AgentNmColumn.ColumnName, 20);    //担当者名
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.GoodsNameColumn.ColumnName, 80);         //品名
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.GoodsNoColumn.ColumnName, 24);          //品番
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName, 6);       //メーカーコード
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.MakerNameColumn.ColumnName, 60);       　//メーカー名称
            // ADD 2011/05/20 ---------------->>>>>>
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName, 6);       //仕入先コード
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.SupplierSnmColumn.ColumnName, 40);       　//仕入先名
            // ADD 2011/05/20 ----------------<<<<<<
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName, 6);        //BLコード
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName, 12); //移動単価
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName, 8);        //数量
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName, 9);     //標準価格
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName, 12);       　//移動金額
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName, 8);        //入力拠点コード
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName, 20); //入力拠点名
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName, 8);        //出庫拠点コード
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName, 20);     //出庫拠点名
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName, 8);       　//出庫倉庫
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName, 40);        //出庫倉庫名
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.BfShelfNoColumn.ColumnName, 8); //出庫棚番
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName, 8);        //入庫拠点コード
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName, 20);     //入庫拠点名
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName, 8);     //入庫倉庫
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName, 40);        //入庫倉庫名
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.AfShelfNoColumn.ColumnName, 8);     //入庫棚番
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName, 8);       　//入荷区分
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName, 10);        //出荷日
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName, 10);        //入荷日
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName, 10);        //入力日
            tw.MaxLengthList.Add(this._stockMoveDataSet.StockMoveDetail.WarehouseNote1Column.ColumnName, 80);     //備考

            #endregion
        }

        /// <summary>
        /// グリッドのセッティングを文字列から取り出す
        /// </summary>
        /// <param name="patternStr"></param>
        /// <param name="gridSetting"></param>
        /// <remarks>
        /// <br>Note       : グリッドのセッティングを文字列から取り出す。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void getGridSettingPattern(string patternStr, out string[] gridSetting)
        {
            int count = patternStr.Length / (PMZAI04604UA.ct_ColumnCountLength + 1);
            gridSetting = new string[count];

            for (int i = 0; i < count; i++)
            {
                gridSetting[i] = patternStr.Substring(i * (PMZAI04604UA.ct_ColumnCountLength + 1), (PMZAI04604UA.ct_ColumnCountLength + 1));
            }
        }

        /// <summary>
        /// スキーマリストを取得する
        /// </summary>
        /// <param name="gridSetting"></param>
        /// <param name="schemeList"></param>
        /// <remarks>
        /// <br>Note       : スキーマリストを取得する。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool getSchemeList(string[] gridSetting, out List<String> schemeList)
        {
            schemeList = new List<string>();

            Dictionary<int, string> sortList = new Dictionary<int, string>();
            string displayFlag = string.Empty;
            string displayOrder = string.Empty;
            int columnOrder = 0;
            DataTable targetTable;
            targetTable = _stockMoveDataSet.StockMoveDetail;

            foreach (string settings in gridSetting)
            {
                if (targetTable.Columns.Count <= columnOrder) break;

                // ４桁の数値なので１＋３に分割
                displayFlag = settings.Substring(0, 1);
                displayOrder = settings.Substring(1, PMZAI04604UA.ct_ColumnCountLength);

                // 表示するであればDictionaryに追加
                if (displayFlag == "0")
                {
                    sortList.Add(int.Parse(displayOrder), targetTable.Columns[columnOrder].ColumnName);
                }
                columnOrder++;
            }

            List<int> keyList = new List<int>(sortList.Keys);
            keyList.Sort();


            foreach (int key in keyList)
            {
                schemeList.Add(sortList[key]);
            }

            return true;
        }

        #endregion

        #region EXCEL出力

        /// <summary>
        /// EXCELデータ出力
        /// </summary>
        /// <remarks>
        /// <br>Note       : EXCELデータ出力。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void exportIntoExcelData()
        {
            string fileName = string.Empty;

            // ファイル保存ダイアログ表示
            this.openFileDialog.Multiselect = false;
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.Filter = "Excelファイル(*.xls) | *.xls";
            this.openFileDialog.FilterIndex = 0;

            fileName = string.Empty;

            // ファイル選択
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }

            if (String.IsNullOrEmpty(fileName))
            {
                // ファイル名が指定されていない
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_OUTPUTEXCEL_NOFILENAME, -1, MessageBoxButtons.OK);

                return;
            }

            try
            {
                if (this.ultraGridExcelExporter.Export(this.uGrid_StockMove, fileName) != null)
                {
                    // 成功
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                        MSG_OUTPUTEXCEL_SUCCEEDED, -1, MessageBoxButtons.OK);
                };
            }
            catch (Exception e)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    e.Message, -1, MessageBoxButtons.OK);
            }
        }

        #endregion // EXCEL出力

        #region 設定

        /// <summary>
        /// 設定ダイアログを表示します
        /// </summary>
        /// <remarks>
        /// <br>Note       : 設定ダイアログを表示します。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void openSetting()
        {
            DialogResult dialogResult = _settingForm.ShowDialog(this);
        }

        #endregion // 設定

        #region ツールバー検索

        #region 列コンボボックス調整

        /// <summary>
        /// ツールバーの列コンボボックスを調整
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバーの列コンボボックスを調整。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void setToolbarSearchSurface()
        {
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.tToolbarsManager.Tools["ComboBoxTool_TargetColumn"];

            ValueList list = new ValueList();
            ValueListItemsCollection collection = list.ValueListItems;
            ValueListItem item = null;

            collection.Clear();

            // 全ての列を追加
            item = new ValueListItem();
            item.DisplayText = "全ての列";
            item.DataValue = "*all*";
            collection.Add(item);

            // 全ての設計された列を追加(uGridの列設定準拠)
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in this.uGrid_StockMove.DisplayLayout.Bands[0].Columns)
            {
                if (!column.Hidden)
                {
                    item = new ValueListItem();
                    item.DisplayText = column.Header.Caption;
                    item.DataValue = column.Key;

                    if (!String.IsNullOrEmpty(item.DisplayText))
                    {
                        collection.Add(item);
                    }
                }
            }

            comboTool.ValueList = list;
            comboTool.Text = "全ての列";
        }

        #endregion // 列コンボボックス調整

        #region 行検索開始

        /// <summary>
        /// ツールバー検索
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバー検索。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void rowSearchStart()
        {
            // 検索文字列を取得
            Infragistics.Win.UltraWinToolbars.TextBoxTool textTool = (Infragistics.Win.UltraWinToolbars.TextBoxTool)this.tToolbarsManager.Tools["TextBoxTool_SearchWord"];
            string searchStr = textTool.Text;
            if (String.IsNullOrEmpty(searchStr))
            {
                return;
            }

            // 対象となる列を取得
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.tToolbarsManager.Tools["ComboBoxTool_TargetColumn"];
            ValueListItem item = (ValueListItem)comboTool.SelectedItem;
            string valueStr = item.DataValue.ToString();
            string textStr = item.DisplayText;

            if (String.IsNullOrEmpty(valueStr) || String.IsNullOrEmpty(textStr))
            {
                return;
            }

            bool continueFlag = false;
            Infragistics.Win.UltraWinGrid.UltraGridRow selectRow = null;

            #region 明細

            // 現在選択されている行がなければ最初から
            if (this.uGrid_StockMove.ActiveRow == null) continueFlag = true;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_StockMove.Rows)
            {
                if (continueFlag)
                {
                    if (valueStr != "*all*")
                    {
                        if (gridRow.Cells[valueStr].Value.ToString().IndexOf(searchStr) > -1)
                        {
                            selectRow = gridRow;
                            break;
                        }
                    }
                    else
                    {
                        // 全ての列で検索
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell cell in gridRow.Cells)
                        {
                            if (cell.Value.ToString().IndexOf(searchStr) > -1)
                            {
                                selectRow = gridRow;
                                break;
                            }
                        }
                        if (selectRow != null) break;
                    }
                }

                // 現在の行に達したら次の行から検索実行可に
                if (!continueFlag && gridRow == this.uGrid_StockMove.ActiveRow) continueFlag = true;
            }

            // 最後まで検索してもないなら最初から
            if (selectRow == null)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_StockMove.Rows)
                {
                    // 現在の行に達したら終了
                    if (gridRow == this.uGrid_StockMove.ActiveRow) break;

                    if (valueStr != "*all*")
                    {
                        if (gridRow.Cells[valueStr].Value.ToString().IndexOf(searchStr) > -1)
                        {
                            selectRow = gridRow;
                            break;
                        }
                    }
                    else
                    {
                        // 全ての列で検索
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell cell in gridRow.Cells)
                        {
                            if (cell.Value.ToString().IndexOf(searchStr) > -1)
                            {
                                selectRow = gridRow;
                                break;
                            }
                        }
                        if (selectRow != null) break;
                    }
                }
            }

            // 選択された行を現在行に設定
            if (selectRow != null)
            {
                // 選択
                if (this.uGrid_StockMove.ActiveRow != null)
                {
                    this.uGrid_StockMove.Rows[this.uGrid_StockMove.ActiveRow.Index].Selected = false;
                }
                else
                {
                    this.uGrid_StockMove.Rows[0].Selected = false;
                }
                this.uGrid_StockMove.Rows[selectRow.Index].Selected = true;

                this.uGrid_StockMove.ActiveRow = selectRow;
                return;
            }
            else
            {
                // 見つかりません
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    MSG_ROWSEARCH_NOT_FOUND, -1, MessageBoxButtons.OK);
                return;
            }

            #endregion // 明細
        }

        #endregion // 行検索開始

        #endregion // ツールバー検索

        #region 列幅自動調整変更

        /// <summary>
        /// 列幅自動調整チェックボックスの変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 列幅自動調整チェックボックスの変更。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged(object sender, EventArgs e)
        {
            this._columnWidthAutoAdjust = this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked;
            autoColumnAdjust(this._columnWidthAutoAdjust);
        }

        #endregion // 列幅自動調整変更

        #region 列幅自動調整

        /// <summary>
        /// 列幅自動調整
        /// </summary>
        /// <param name="autoAdjust">自動調整するかどうか</param>
        /// <remarks>
        /// <br>Note       : 列幅自動調整。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void autoColumnAdjust(bool autoAdjust)
        {
            if (this.uGrid_StockMove.DisplayLayout.AutoFitStyle == Infragistics.Win.UltraWinGrid.AutoFitStyle.None && !autoAdjust ||
                 this.uGrid_StockMove.DisplayLayout.AutoFitStyle != Infragistics.Win.UltraWinGrid.AutoFitStyle.None && autoAdjust) return;

            // 自動調整プロパティを調整
            if (autoAdjust)
            {
                this.uGrid_StockMove.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.uGrid_StockMove.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            }
            // 全ての列でサイズ調整
            for (int i = 0; i < this.uGrid_StockMove.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                this.uGrid_StockMove.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
            }
            return;
        }

        #endregion //列幅自動調整

        #region フォントサイズ変更

        /// <summary>
        /// フォントサイズ変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : フォントサイズ変更。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tComboEditor_StatusBar_FontSize_ValueChanged(object sender, EventArgs e)
        {
            int a = this.StrToIntDefOfValue(this.tComboEditor_StatusBar_FontSize.Value, CT_DEF_FONT_SIZE);
            float fontPoint = (float)a;

            this.uGrid_StockMove.DisplayLayout.Appearance.FontData.SizeInPoints = fontPoint;
            this.uGrid_StockMove.Refresh();

            uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged(null, null);
        }

        /// <summary>
        /// StrToInt転換
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultNo"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : StrToInt転換。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private int StrToIntDefOfValue(object obj, int defaultNo)
        {
            try
            {
                return (int)obj;
            }
            catch
            {
                return defaultNo;
            }
        }

        #endregion // フォントサイズ変更        

        /// <summary>
        /// 基本条件のCheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 基本条件のCheckedChanged。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uCheckStockMoveDtl_base_CheckedChanged(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinEditors.UltraCheckEditor uCheckEditor = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)sender;
            bool status = true;
            string checkMessage = string.Empty;
            int maxCount = 0;

            // 1：出荷確定あり、２：出荷確定なし
            if (this._stockMoveFixCode == 1)
            {
                checkMessage = "選択可能な項目は４項目までです。";
                maxCount = 4;
            }
            else if (this._stockMoveFixCode == 2)
            {
                checkMessage = "選択可能な項目は６項目までです。";
                maxCount = 6;
            }

            #region[伝票番号]
            // 伝票番号
            if (uCheckEditor == this.uCheckSalesSlipNum_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckSalesSlipNum.Checked = true;
                        this.uCheckSalesSlipNum.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckSalesSlipNum.Checked = false;
                    this.uCheckSalesSlipNum.Enabled = true;

                }
            }
            #endregion

            #region [入力日開始]
            // 入力日開始
            else if (uCheckEditor == this.uCheckAddUpADateSt_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckAddUpADateSt.Checked = true;
                        this.uCheckAddUpADateSt.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckAddUpADateSt.Checked = false;
                    this.uCheckAddUpADateSt.Enabled = true;

                }
            }
            #endregion

            #region [入力日終了]
            // 入力日終了
            else if (uCheckEditor == this.uCheckAddUpADateEd_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckAddUpADateEd.Checked = true;
                        this.uCheckAddUpADateEd.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckAddUpADateEd.Checked = false;
                    this.uCheckAddUpADateEd.Enabled = true;

                }
            }
            #endregion

            #region [担当者]
            // 担当者
            else if (uCheckEditor == this.uCheckSalesEmployeeCd_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckSalesEmployeeCd.Checked = true;
                        this.uCheckSalesEmployeeCd.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckSalesEmployeeCd.Checked = false;
                    this.uCheckSalesEmployeeCd.Enabled = true;

                }
            }
            #endregion

            #region [仕入先]
            // 仕入先
            else if (uCheckEditor == this.uCheckSupplierCd_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckSupplierCd.Checked = true;
                        this.uCheckSupplierCd.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckSupplierCd.Checked = false;
                    this.uCheckSupplierCd.Enabled = true;

                }
            }
            #endregion

            #region [メーカー]
            // 担当者
            else if (uCheckEditor == this.uCheckGoodsMakerCd_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckGoodsMakerCd.Checked = true;
                        this.uCheckGoodsMakerCd.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckGoodsMakerCd.Checked = false;
                    this.uCheckGoodsMakerCd.Enabled = true;

                }
            }
            #endregion

            #region [BLコード]
            // BLコード
            else if (uCheckEditor == this.uCheckBLGoodsCode_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckBLGoodsCode.Checked = true;
                        this.uCheckBLGoodsCode.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckBLGoodsCode.Checked = false;
                    this.uCheckBLGoodsCode.Enabled = true;

                }
            }
            #endregion

            #region [品番]
            // 品番
            else if (uCheckEditor == this.uCheckGoodsNo_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckGoodsNo.Checked = true;
                        this.uCheckGoodsNo.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckGoodsNo.Checked = false;
                    this.uCheckGoodsNo.Enabled = true;

                }
            }
            #endregion

            #region [品名]
            // 品名
            else if (uCheckEditor == this.uCheckGoodsName_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckGoodsName.Checked = true;
                        this.uCheckGoodsName.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckGoodsName.Checked = false;
                    this.uCheckGoodsName.Enabled = true;

                }
            }
            #endregion

            #region [棚番]
            // 棚番
            else if (uCheckEditor == this.uCheckWarehouseShelfNo_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckWarehouseShelfNo.Checked = true;
                        this.uCheckWarehouseShelfNo.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckWarehouseShelfNo.Checked = false;
                    this.uCheckWarehouseShelfNo.Enabled = true;

                }
            }
            #endregion

            #region [相手拠点]
            // 相手拠点
            else if (uCheckEditor == this.uCheckAfSectionCode_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckAfSectionCode.Checked = true;
                        this.uCheckAfSectionCode.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckAfSectionCode.Checked = false;
                    this.uCheckAfSectionCode.Enabled = true;

                }
            }
            #endregion

            #region [相手倉庫]
            // 相手倉庫
            else if (uCheckEditor == this.uCheckAfEnterWarehCode_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckAfEnterWarehCode.Checked = true;
                        this.uCheckAfEnterWarehCode.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckAfEnterWarehCode.Checked = false;
                    this.uCheckAfEnterWarehCode.Enabled = true;

                }
            }
            #endregion

            #region [入荷区分]
            // 入荷区分
            else if (uCheckEditor == this.uCheckArrivalGoodsFlag_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckArrivalGoodsFlag.Checked = true;
                        this.uCheckArrivalGoodsFlag.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckArrivalGoodsFlag.Checked = false;
                    this.uCheckArrivalGoodsFlag.Enabled = true;

                }
            }
            #endregion

            #region [備考]
            // 備考
            else if (uCheckEditor == this.uCheckNote_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckNote.Checked = true;
                        this.uCheckNote.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckNote.Checked = false;
                    this.uCheckNote.Enabled = true;

                }
            }
            #endregion

            #region [削除指定区分]
            // 削除指定区分
            else if (uCheckEditor == this.uCheckDeleteFlag_base)
            {
                if (uCheckEditor.Checked)
                {
                    this._checkCount++;
                    if (this._checkCount > maxCount)
                    {
                        status = false;
                        this._checkCount--;
                        uCheckEditor.Checked = false;
                    }
                    else
                    {
                        this.uCheckDeleteFlag.Checked = true;
                        this.uCheckDeleteFlag.Enabled = false;
                    }
                }
                else
                {
                    this._checkCount--;
                    this.uCheckDeleteFlag.Checked = false;
                    this.uCheckDeleteFlag.Enabled = true;

                }
            }
            #endregion

            if (status == false)
            {
                TMsgDisp.Show(this,                         // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                    "PMZAI04601U",							// アセンブリID
                    checkMessage,	                        // 表示するメッセージ
                    0,									    // ステータス値
                    MessageBoxButtons.OK);					// 表示するボタン
            }
        }

        /// <summary>
        /// 詳細条件グループの縮小・展開 変更時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 詳細条件グループの縮小・展開 変更時処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uExGroupBox_ExtraCondition_ExpandedStateChanged(object sender, EventArgs e)
        {
            if (uExGroupBox_ExtraCondition.Expanded)
            {
                this.SuspendLayout();
                try
                {
                    DisplayExtraConditions();
                }
                finally
                {
                    this.ResumeLayout();
                }
            }
        }

        /// <summary>
        /// 拡張検索条件の表示設定用ペインが非表示になったタイミングでのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : このタイミングでチェックボックスを設定を取得し、表示項目を調整する。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        void ultraDockManager_PaneHidden(object sender, Infragistics.Win.UltraWinDock.PaneHiddenEventArgs e)
        {
            // 画面の更新を停止
            this.SuspendLayout();

            DisplayExtraConditions();

            // 画面更新を再開
            this.ResumeLayout();

        }

        #region 詳細条件の表示
        /// <summary>
        /// 詳細条件の表示
        /// </summary>
        /// <remarks>
        /// <br>Note       : 詳細条件の表示。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void DisplayExtraConditions()
        {
            int displayedItemCount = 0;     // 表示されている検索条件の項目数

            // 全ての項目をHiddenに
            SetAllDetailSearchCondition2Hidden();

            int tabIndex = 0;
            #region [基本条件]
            DisplayCommonConditions(out tabIndex);
            #endregion

            this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
            this._currentLocationY = CT_INITIAL_FIELD_POSITION_Y;

            _gridUpKeyBackControl = null;

            // チェックボックスの設定をすべて取得、チェックがついている項目を表示
            // タグで一括管理しようかとも考えたが少し無理が出てきそうなので直接管理

            #region 伝票番号
            // 伝票番号
            if ((this.uCheckSalesSlipNum.Checked) && (this.uCheckSalesSlipNum.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tEdit_StockMoveSlipNum;
                }

                // 伝票番号ラベル
                this.uLabel_SalesSlipNumTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SalesSlipNumTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 伝票番号tNedit
                this.tEdit_StockMoveSlipNum.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_StockMoveSlipNum.Visible = true;
                this.tEdit_StockMoveSlipNum.Width = 150;
                this._currentLocationX += 155;

                // 伝票番号ラベル２
                this.uLabel_SalesSlipNumEnd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SalesSlipNumEnd.Visible = true;
                this.uLabel_SalesSlipNumEnd.Width = 50;

                this.tEdit_StockMoveSlipNum.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckSalesSlipNum_base.Checked)
                {
                    tEdit_StockMoveSlipNum.Clear();
                }
            }
            #endregion // 伝票番号

            #region 入力日開始
            // 入力日開始
            if ((this.uCheckAddUpADateSt.Checked) && (this.uCheckAddUpADateSt.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tDateEdit_AddUpADateSt;
                }

                // 入力日開始ラベル
                this.uLabel_AddUpADateTitle_St.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_AddUpADateTitle_St.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 入力日開始tDateEdit
                this.tDateEdit_AddUpADateSt.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tDateEdit_AddUpADateSt.Visible = true;
                this.tDateEdit_AddUpADateSt.Width = 176;
                this.tDateEdit_AddUpADateSt.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckAddUpADateSt_base.Checked)
                {
                    tDateEdit_AddUpADateSt.Clear();
                }
            }
            #endregion // 入力日開始

            #region 入力日終了
            // 入力日終了
            if ((this.uCheckAddUpADateEd.Checked) && ((this.uCheckAddUpADateEd.Enabled == true)))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tDateEdit_AddUpADateEd;
                }

                // 入力日終了ラベル
                this.uLabel_AddUpADateTitle_Ed.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_AddUpADateTitle_Ed.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 入力日終了tDateEdit
                this.tDateEdit_AddUpADateEd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tDateEdit_AddUpADateEd.Visible = true;
                this.tDateEdit_AddUpADateEd.Width = 176;
                this.tDateEdit_AddUpADateEd.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckAddUpADateEd_base.Checked)
                {
                    tDateEdit_AddUpADateEd.Clear();
                }
            }
            #endregion // 入力日終了

            #region 担当者
            // 担当者
            if ((this.uCheckSalesEmployeeCd.Checked) && (this.uCheckSalesEmployeeCd.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tEdit_SalesEmployeeCd;
                }

                // 担当者ラベル
                this.uLabel_SalesEmployeeCdTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SalesEmployeeCdTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 担当者tEdit
                this.tEdit_SalesEmployeeCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_SalesEmployeeCd.Visible = true;
                this.tEdit_SalesEmployeeCd.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_SalesEmployeeCd.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // 担当者ガイドボタン
                this.uButton_SalesEmployeeCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_SalesEmployeeCd.Visible = true;
                this.uButton_SalesEmployeeCd.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckSalesEmployeeCd_base.Checked)
                {
                    _swSalesEmployeeCd = string.Empty;
                    _swSalesEmployeeName = string.Empty;
                    tEdit_SalesEmployeeCd.Text = string.Empty;
                }
            }
            #endregion // 担当者

            #region 仕入先
            // 仕入先
            if ((this.uCheckSupplierCd.Checked) && (this.uCheckSupplierCd.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tEdit_SupplierCd;
                }

                // 仕入先ラベル
                this.uLabel_SupplierCdTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SupplierCdTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 仕入先tEdit
                this.tEdit_SupplierCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_SupplierCd.Visible = true;
                this.tEdit_SupplierCd.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_SupplierCd.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // 仕入先ガイドボタン
                this.uButton_SupplierCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_SupplierCd.Visible = true;
                this.uButton_SupplierCd.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckSupplierCd_base.Checked)
                {
                    _swSupplierCd = 0;
                    _swSupplierName = string.Empty;
                    tEdit_SupplierCd.Text = string.Empty;
                }
            }
            #endregion // 仕入先

            #region メーカー
            // メーカー
            if ((this.uCheckGoodsMakerCd.Checked) && (this.uCheckGoodsMakerCd.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tEdit_MakerCd;
                }

                // メーカーラベル
                this.uLabel_MakerCdTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_MakerCdTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // メーカーtEdit
                this.tEdit_MakerCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_MakerCd.Visible = true;
                this.tEdit_MakerCd.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_MakerCd.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // メーカーガイドボタン
                this.uButton_MakerCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_MakerCd.Visible = true;
                this.uButton_MakerCd.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckGoodsMakerCd_base.Checked)
                {
                    _swGoodsMakerCd = 0;
                    _swGoodsMakerName = string.Empty;
                    tEdit_MakerCd.Text = string.Empty;
                }
            }
            #endregion // メーカー

            #region BLコード
            // BLコード
            if ((this.uCheckBLGoodsCode.Checked) && (this.uCheckBLGoodsCode.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tEdit_BlGoodsCode;
                }

                // BLコードラベル
                this.uLabel_BlGoodsCodeTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_BlGoodsCodeTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // BLコードtEdit
                this.tEdit_BlGoodsCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_BlGoodsCode.Visible = true;
                this.tEdit_BlGoodsCode.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_BlGoodsCode.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // BLコードガイドボタン
                this.uButton_BlGoodsCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_BlGoodsCode.Visible = true;
                this.uButton_BlGoodsCode.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckBLGoodsCode_base.Checked)
                {
                    _swBLGoodsCode = 0;
                    _swBLGoodsName = string.Empty;
                    tEdit_BlGoodsCode.Text = string.Empty;
                }
            }
            #endregion // BLコード

            #region 品番
            // 品番
            if ((this.uCheckGoodsNo.Checked) && (this.uCheckGoodsNo.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tEdit_GoodsNo;
                }

                // 品番ラベル
                this.uLabel_GoodsNoTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_GoodsNoTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 品番tEdit
                this.tEdit_GoodsNo.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_GoodsNo.Visible = true;
                this.tEdit_GoodsNo.Width = CT_INTERVAL_EDIT_WITHCOMBO - 4;
                this.tEdit_GoodsNo.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHCOMBO;

                // 品番曖昧検索
                this.tComboEditor_GoodsNoFuzzy.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_GoodsNoFuzzy.Visible = true;
                this.tComboEditor_GoodsNoFuzzy.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckGoodsNo_base.Checked)
                {
                    tEdit_GoodsNo.Text = string.Empty;
                }
            }
            #endregion // 品番

            #region 品名
            // 品名
            if ((this.uCheckGoodsName.Checked) && (this.uCheckGoodsName.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tEdit_GoodsName;
                }

                // 品名ラベル
                this.uLabel_GoodsNameTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_GoodsNameTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 品名tEdit
                this.tEdit_GoodsName.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_GoodsName.Visible = true;
                this.tEdit_GoodsName.Width = CT_INTERVAL_EDIT_WITHCOMBO - 4;
                this.tEdit_GoodsName.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHCOMBO;

                // 品名曖昧検索
                this.tComboEditor_GoodsNameFuzzy.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_GoodsNameFuzzy.Visible = true;
                this.tComboEditor_GoodsNameFuzzy.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckGoodsName_base.Checked)
                {
                    tEdit_GoodsName.Text = string.Empty;
                }
            }
            #endregion // 品名

            # region [棚番]
            // 棚番
            if ((this.uCheckWarehouseShelfNo.Checked) && (this.uCheckWarehouseShelfNo.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0 && tEdit_WarehouseShelfNo.Enabled == true)
                {
                    this._gridUpKeyBackControl = tEdit_WarehouseShelfNo;
                }

                // 棚番ラベル
                this.uLabel_WarehouseShelfNo.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_WarehouseShelfNo.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 棚番tEdit
                this.tEdit_WarehouseShelfNo.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_WarehouseShelfNo.Visible = true;
                this.tEdit_WarehouseShelfNo.Width = CT_INTERVAL_EDIT_WITHCOMBO - 4;
                this.tEdit_WarehouseShelfNo.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHCOMBO;

                // 棚番曖昧検索
                this.tComboEditor_WarehouseShelfNoFuzzy.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_WarehouseShelfNoFuzzy.Visible = true;
                this.tComboEditor_WarehouseShelfNoFuzzy.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckWarehouseShelfNo_base.Checked)
                {
                    tEdit_WarehouseShelfNo.Text = string.Empty;
                }
            }
            # endregion

            # region [相手拠点]
            // 相手拠点
            if ((this.uCheckAfSectionCode.Checked) && (this.uCheckAfSectionCode.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0 && tEdit_AfSectionCode.Enabled == true)
                {
                    this._gridUpKeyBackControl = tEdit_AfSectionCode;
                }

                // 相手拠点ラベル
                this.uLabel_AfSectionCodeTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_AfSectionCodeTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 相手拠点tEdit
                this.tEdit_AfSectionCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_AfSectionCode.Visible = true;
                this.tEdit_AfSectionCode.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_AfSectionCode.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // 相手拠点ガイドボタン
                this.uButton_AfSectionCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_AfSectionCode.Visible = true;
                this.uButton_AfSectionCode.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckAfSectionCode_base.Checked)
                {
                    tEdit_WarehouseShelfNo.Text = string.Empty;
                    //_swAfSectionCode = 0; // DEL 2010/05/18
                    _swAfSectionCode = string.Empty; // ADD 2010/05/18
                    _swAfSectionName = string.Empty;
                    tEdit_AfSectionCode.Text = string.Empty;
                }
            }
            # endregion

            # region [相手倉庫]
            // 相手倉庫
            if ((this.uCheckAfEnterWarehCode.Checked) && (this.uCheckAfEnterWarehCode.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0 && tEdit_AfEnterWarehCode.Enabled == true)
                {
                    this._gridUpKeyBackControl = tEdit_AfEnterWarehCode;
                }

                // 相手倉庫ラベル
                this.uLabel_AfEnterWarehCodeTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_AfEnterWarehCodeTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 相手倉庫tEdit
                this.tEdit_AfEnterWarehCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_AfEnterWarehCode.Visible = true;
                this.tEdit_AfEnterWarehCode.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_AfEnterWarehCode.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // 相手倉庫ガイドボタン
                this.uButton_AfEnterWarehCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_AfEnterWarehCode.Visible = true;
                this.uButton_AfEnterWarehCode.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckAfEnterWarehCode_base.Checked)
                {
                    _swAfEnterWarehCode = string.Empty;
                    _swAfEnterWarehName = string.Empty;
                    tEdit_AfEnterWarehCode.Text = string.Empty;
                }
            }
            # endregion

            # region [入荷区分]
            // 入荷区分
            if ((this.uCheckArrivalGoodsFlag.Checked) && (this.uCheckArrivalGoodsFlag.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0 && tComboEditor_ArrivalGoodsFlag.Enabled == true)
                {
                    this._gridUpKeyBackControl = tComboEditor_ArrivalGoodsFlag;
                }

                // 入荷区分ラベル
                this.uLabel_ArrivalGoodsFlagTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_ArrivalGoodsFlagTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 入荷区分コンボボックス
                this.tComboEditor_ArrivalGoodsFlag.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_ArrivalGoodsFlag.Visible = true;
                this.tComboEditor_ArrivalGoodsFlag.Width = CT_INTERVAL_COMBOBOX;
                this.tComboEditor_ArrivalGoodsFlag.TabIndex = tabIndex++;

                displayedItemCount++;

                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckArrivalGoodsFlag_base.Checked)
                {
                    tComboEditor_ArrivalGoodsFlag.SelectedIndex = this.tComboEditor_OutputDiv.SelectedIndex;
                }
            }
            # endregion

            #region 備考
            // 備考
            if ((this.uCheckNote.Checked) && (this.uCheckNote.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tEdit_SlipNote;
                }

                // 備考ラベル
                this.uLabel_SlipNoteTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SlipNoteTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 備考tEdit
                this.tEdit_SlipNote.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_SlipNote.Visible = true;
                this.tEdit_SlipNote.Width = CT_INTERVAL_LABEL + CT_FIELD_INTERVAL_X - 1;
                this.tEdit_SlipNote.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_LABEL + 1;

                // 備考１ガイド
                this.uButton_SlipNote.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_SlipNote.Visible = true;
                this._currentLocationX += 24 + 1;
                this.uButton_SlipNote.TabIndex = tabIndex++;

                // 備考曖昧検索
                this.tComboEditor_SlipNoteFuzzy.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_SlipNoteFuzzy.Visible = true;
                this.tComboEditor_SlipNoteFuzzy.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckNote_base.Checked)
                {
                    tEdit_SlipNote.Text = string.Empty;
                }
            }
            #endregion // 備考

            #region 削除指定区分
            // 削除指定区分
            if ((this.uCheckDeleteFlag.Checked) && (this.uCheckDeleteFlag.Enabled == true))
            {
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._gridUpKeyBackControl = tComboEditor_DeleteFlag;
                }

                // 削除指定区分ラベル
                this.uLabel_DeleteFlagTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_DeleteFlagTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 削除指定区分コンボボックス
                this.tComboEditor_DeleteFlag.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_DeleteFlag.Visible = true;
                this.tComboEditor_DeleteFlag.Width = CT_INTERVAL_COMBOBOX;
                this.tComboEditor_DeleteFlag.TabIndex = tabIndex++;

                displayedItemCount++;
                
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 1)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_2;
                }
                if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 2)
                {
                    this._currentLocationX = CT_INITIAL_FIELD_POSITION_X_3;
                }
            }
            else
            {
                if (!this.uCheckDeleteFlag_base.Checked)
                {
                    _logicalDelDiv = 0;
                    tComboEditor_DeleteFlag.SelectedIndex = 0;
                }
            }
            #endregion // 削除指定区分

            // 拡張検索条件エリアの表示/非表示を設定
            if (displayedItemCount > 0)
            {
                // 一つでも項目がチェックされていれば表示
                this.uExGroupBox_ExtraCondition.Visible = true;
            }
            else
            {
                // 項目が一つもチェックされていなければ非表示
                this.uExGroupBox_ExtraCondition.Visible = false;
            }

            // 拡張検索条件エリアの高さを計算
            if (displayedItemCount % CT_INITIAL_EXTRA_ROW_COUNT == 0) this._currentLocationY -= CT_INTERVAL_HEIGHT;  // 項目数が3の倍数個の時は改行されているので改行を削除
            this.uExGroupBox_ExtraCondition.Height = this._currentLocationY + CT_INTERVAL_HEIGHT + CT_INTERVAL_HEIGHT;
        }

        #endregion

        #region 詳細検索条件非表示

        /// <summary>
        /// 詳細検索条件エリアのコントロールをすべて非表示
        /// </summary>
        /// <remarks>
        /// <br>Note       : 詳細検索条件エリアのコントロールをすべて非表示。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void SetAllDetailSearchCondition2Hidden()
        {
            // 伝票番号
            this.uLabel_SalesSlipNumTitle.Visible = false;
            this.tEdit_StockMoveSlipNum.Visible = false;
            this.uLabel_SalesSlipNumEnd.Visible = false;

            // 入力日開始
            this.uLabel_AddUpADateTitle_St.Visible = false;
            this.tDateEdit_AddUpADateSt.Visible = false;

            // 入力日終了
            this.uLabel_AddUpADateTitle_Ed.Visible = false;
            this.tDateEdit_AddUpADateEd.Visible = false;

            // 担当者
            this.uLabel_SalesEmployeeCdTitle.Visible = false;
            this.tEdit_SalesEmployeeCd.Visible = false;
            this.uButton_SalesEmployeeCd.Visible = false;

            // 仕入先
            this.uLabel_SupplierCdTitle.Visible = false;
            this.tEdit_SupplierCd.Visible = false;
            this.uButton_SupplierCd.Visible = false;

            // メーカー
            this.uLabel_MakerCdTitle.Visible = false;
            this.tEdit_MakerCd.Visible = false;
            this.uButton_MakerCd.Visible = false;

            // ＢＬコード
            this.uLabel_BlGoodsCodeTitle.Visible = false;
            this.tEdit_BlGoodsCode.Visible = false;
            this.uButton_BlGoodsCode.Visible = false;

            // 品番
            this.uLabel_GoodsNoTitle.Visible = false;
            this.tEdit_GoodsNo.Visible = false;
            this.tComboEditor_GoodsNoFuzzy.Visible = false;

            // 品名
            this.uLabel_GoodsNameTitle.Visible = false;
            this.tEdit_GoodsName.Visible = false;
            this.tComboEditor_GoodsNameFuzzy.Visible = false;

            // 棚番
            this.uLabel_WarehouseShelfNo.Visible = false;
            this.tEdit_WarehouseShelfNo.Visible = false;
            this.tComboEditor_WarehouseShelfNoFuzzy.Visible = false;

            // 相手拠点
            this.uLabel_AfSectionCodeTitle.Visible = false;
            this.tEdit_AfSectionCode.Visible = false;
            this.uButton_AfSectionCode.Visible = false;

            // 相手拠点
            this.uLabel_AfEnterWarehCodeTitle.Visible = false;
            this.tEdit_AfEnterWarehCode.Visible = false;
            this.uButton_AfEnterWarehCode.Visible = false;

            // 入荷区分
            this.uLabel_ArrivalGoodsFlagTitle.Visible = false;
            this.tComboEditor_ArrivalGoodsFlag.Visible = false;

            // 備考
            this.uLabel_SlipNoteTitle.Visible = false;
            this.tEdit_SlipNote.Visible = false;
            this.uButton_SlipNote.Visible = false;
            this.tComboEditor_SlipNoteFuzzy.Visible = false;

            // 削除指定区分
            this.uLabel_DeleteFlagTitle.Visible = false;
            this.tComboEditor_DeleteFlag.Visible = false;
        }

        #endregion // 詳細検索条件非表示

        #region 基本条件の表示
        /// <summary>
        /// 基本条件の表示
        /// </summary>
        /// <param name="tabIndex">tabIndex</param>
        /// <remarks>
        /// <br>Note       : 基本条件の表示。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/21 朱俊成 Redmine#21678 相手拠点・相手倉庫・入荷区分の表示の改修</br>
        /// <br></br>
        /// </remarks>
        private void DisplayCommonConditions(out int tabIndex)
        {
            tabIndex = 0;
            this._currentLocationX = 375;
            this._currentLocationY = 27;
            int displayedItemCount = 0;     // 表示されている検索条件の項目数
            int startLocationX = 375;

            #region 伝票番号
            // 伝票番号
            if (this.uCheckSalesSlipNum_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_StockMoveSlipNum))
                {
                    // 伝票番号
                    tEdit_StockMoveSlipNum.Clear();
                }
                
                // 伝票番号ラベル
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_SalesSlipNumTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SalesSlipNumTitle);
                this.uLabel_SalesSlipNumTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SalesSlipNumTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 伝票番号tNedit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_StockMoveSlipNum);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_StockMoveSlipNum);
                this.tEdit_StockMoveSlipNum.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_StockMoveSlipNum.Visible = true;
                this.tEdit_StockMoveSlipNum.Width = 150;
                this.tEdit_StockMoveSlipNum.TabIndex = tabIndex++;
                this._currentLocationX += 155;

                // 伝票番号ラベル２
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_SalesSlipNumEnd);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SalesSlipNumEnd);
                this.uLabel_SalesSlipNumEnd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SalesSlipNumEnd.Visible = true;
                this.uLabel_SalesSlipNumEnd.Width = 50;
                this._currentLocationX += 55; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;
                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_SalesSlipNumTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_StockMoveSlipNum);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_SalesSlipNumEnd);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_SalesSlipNumTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_StockMoveSlipNum);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_SalesSlipNumEnd);
                if (!this.uCheckSalesSlipNum.Checked)
                {
                    tEdit_StockMoveSlipNum.Clear();
                }
            }
            #endregion // 伝票番号

            #region 入力日開始
            // 入力日開始
            if (this.uCheckAddUpADateSt_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tDateEdit_AddUpADateSt))
                {
                    // 入力日開始
                    tDateEdit_AddUpADateSt.Clear();
                }

                // 入力日開始ラベル
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_AddUpADateTitle_St);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_AddUpADateTitle_St);
                this.uLabel_AddUpADateTitle_St.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_AddUpADateTitle_St.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 入力日開始tDateEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tDateEdit_AddUpADateSt);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tDateEdit_AddUpADateSt);
                this.tDateEdit_AddUpADateSt.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tDateEdit_AddUpADateSt.Visible = true;
                this.tDateEdit_AddUpADateSt.Width = 176;
                this.tDateEdit_AddUpADateSt.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_AddUpADateTitle_St);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tDateEdit_AddUpADateSt);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_AddUpADateTitle_St);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tDateEdit_AddUpADateSt);
                if (!this.uCheckAddUpADateSt.Checked)
                {
                    tDateEdit_AddUpADateSt.Clear();
                }
            }

            #endregion // 入力日開始

            #region 入力日終了
            // 入力日終了
            if (this.uCheckAddUpADateEd_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tDateEdit_AddUpADateEd))
                {
                    // 入力日終了
                    tDateEdit_AddUpADateEd.Clear();
                }
                // 入力日終了ラベル
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_AddUpADateTitle_Ed);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_AddUpADateTitle_Ed);
                this.uLabel_AddUpADateTitle_Ed.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_AddUpADateTitle_Ed.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 入力日終了tDateEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tDateEdit_AddUpADateEd);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tDateEdit_AddUpADateEd);
                this.tDateEdit_AddUpADateEd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tDateEdit_AddUpADateEd.Visible = true;
                this.tDateEdit_AddUpADateEd.Width = 176;
                this.tDateEdit_AddUpADateEd.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_AddUpADateTitle_Ed);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tDateEdit_AddUpADateEd);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_AddUpADateTitle_Ed);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tDateEdit_AddUpADateEd);
                if (!this.uCheckAddUpADateEd.Checked)
                {
                    tDateEdit_AddUpADateEd.Clear();
                }
            }
            #endregion // 入力日終了

            #region 担当者
            // 担当者
            if (this.uCheckSalesEmployeeCd_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_SalesEmployeeCd))
                {
                    // 担当者
                    _swSalesEmployeeCd = string.Empty;
                    _swSalesEmployeeName = string.Empty;
                    tEdit_SalesEmployeeCd.Text = string.Empty;
                }

                // 担当者ラベル
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_SalesEmployeeCdTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SalesEmployeeCdTitle);
                this.uLabel_SalesEmployeeCdTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SalesEmployeeCdTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 担当者tEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_SalesEmployeeCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_SalesEmployeeCd);
                this.tEdit_SalesEmployeeCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_SalesEmployeeCd.Visible = true;
                this.tEdit_SalesEmployeeCd.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_SalesEmployeeCd.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // 担当者ガイドボタン
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uButton_SalesEmployeeCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_SalesEmployeeCd);
                this.uButton_SalesEmployeeCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_SalesEmployeeCd.Visible = true;
                this.uButton_SalesEmployeeCd.TabIndex = tabIndex++;
                this._currentLocationX += 35;  // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_SalesEmployeeCdTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_SalesEmployeeCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uButton_SalesEmployeeCd);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_SalesEmployeeCdTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_SalesEmployeeCd);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_SalesEmployeeCd);
                if (!this.uCheckSalesEmployeeCd.Checked)
                {
                    _swSalesEmployeeCd = string.Empty;
                    _swSalesEmployeeName = string.Empty;
                    tEdit_SalesEmployeeCd.Text = string.Empty;
                }
            }
            #endregion // 担当者

            #region 仕入先
            // 仕入先
            if (this.uCheckSupplierCd_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_SupplierCd))
                {
                    // 仕入先
                    _swSupplierCd = 0;
                    _swSupplierName = string.Empty;
                    tEdit_SupplierCd.Text = string.Empty;
                }

                // 仕入先ラベル
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_SupplierCdTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SupplierCdTitle);
                this.uLabel_SupplierCdTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SupplierCdTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 仕入先tEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_SupplierCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_SupplierCd);
                this.tEdit_SupplierCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_SupplierCd.Visible = true;
                this.tEdit_SupplierCd.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_SupplierCd.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // 仕入先ガイドボタン
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uButton_SupplierCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_SupplierCd);
                this.uButton_SupplierCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_SupplierCd.Visible = true;
                this.uButton_SupplierCd.TabIndex = tabIndex++;
                this._currentLocationX += 35; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_SupplierCdTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_SupplierCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uButton_SupplierCd);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_SupplierCdTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_SupplierCd);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_SupplierCd);
                if (!this.uCheckSupplierCd.Checked)
                {
                    _swSupplierCd = 0;
                    _swSupplierName = string.Empty;
                    tEdit_SupplierCd.Text = string.Empty;
                }
            }
            #endregion // 仕入先

            #region メーカー
            // メーカー
            if (this.uCheckGoodsMakerCd_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_MakerCd))
                {
                    // メーカー
                    _swGoodsMakerCd = 0;
                    _swGoodsMakerName = string.Empty;
                    tEdit_MakerCd.Text = string.Empty;
                }

                // メーカーラベル
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_MakerCdTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_MakerCdTitle);
                this.uLabel_MakerCdTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_MakerCdTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // メーカーtEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_MakerCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_MakerCd);
                this.tEdit_MakerCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_MakerCd.Visible = true;
                this.tEdit_MakerCd.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_MakerCd.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // メーカーガイドボタン
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uButton_MakerCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_MakerCd);
                this.uButton_MakerCd.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_MakerCd.Visible = true;
                this.uButton_MakerCd.TabIndex = tabIndex++;
                this._currentLocationX += 35; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_MakerCdTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_MakerCd);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uButton_MakerCd);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_MakerCdTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_MakerCd);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_MakerCd);
                if (!this.uCheckGoodsMakerCd.Checked)
                {
                    _swGoodsMakerCd = 0;
                    _swGoodsMakerName = string.Empty;
                    tEdit_MakerCd.Text = string.Empty;
                }
            }
            #endregion // メーカー

            #region BLコード
            // BLコード
            if (this.uCheckBLGoodsCode_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_BlGoodsCode))
                {
                    // BLコード
                    _swBLGoodsCode = 0;
                    _swBLGoodsName = string.Empty;
                    tEdit_BlGoodsCode.Text = string.Empty;
                }

                // BLコードラベル
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_BlGoodsCodeTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_BlGoodsCodeTitle);
                this.uLabel_BlGoodsCodeTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_BlGoodsCodeTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // BLコードtEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_BlGoodsCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_BlGoodsCode);
                this.tEdit_BlGoodsCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_BlGoodsCode.Visible = true;
                this.tEdit_BlGoodsCode.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_BlGoodsCode.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // BLコードガイドボタン
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uButton_BlGoodsCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_BlGoodsCode);
                this.uButton_BlGoodsCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_BlGoodsCode.Visible = true;
                this.uButton_BlGoodsCode.TabIndex = tabIndex++;
                this._currentLocationX += 35; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_BlGoodsCodeTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_BlGoodsCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uButton_BlGoodsCode);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_BlGoodsCodeTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_BlGoodsCode);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_BlGoodsCode);
                if (!this.uCheckBLGoodsCode.Checked)
                {
                    _swBLGoodsCode = 0;
                    _swBLGoodsName = string.Empty;
                    tEdit_BlGoodsCode.Text = string.Empty;
                }
            }
            #endregion // BLコード

            #region 品番
            // 品番
            if (this.uCheckGoodsNo_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_GoodsNo))
                {
                    // 品番
                    tEdit_GoodsNo.Text = string.Empty;
                    tComboEditor_GoodsNoFuzzy.Value = CT_FUZZY_MATCHWITH;
                    _srGoodsNo = string.Empty;
                    _srRvGoodsNo = string.Empty;
                }

                // 品番ラベル
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_GoodsNoTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_GoodsNoTitle);
                this.uLabel_GoodsNoTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_GoodsNoTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 品番tEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_GoodsNo);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_GoodsNo);
                this.tEdit_GoodsNo.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_GoodsNo.Visible = true;
                this.tEdit_GoodsNo.Width = CT_INTERVAL_EDIT_WITHCOMBO - 4;
                this.tEdit_GoodsNo.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHCOMBO;

                // 品番曖昧検索
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tComboEditor_GoodsNoFuzzy);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_GoodsNoFuzzy);
                this.tComboEditor_GoodsNoFuzzy.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_GoodsNoFuzzy.Visible = true;
                this.tComboEditor_GoodsNoFuzzy.TabIndex = tabIndex++;
                this._currentLocationX += 86; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_GoodsNoTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_GoodsNo);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tComboEditor_GoodsNoFuzzy);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_GoodsNoTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_GoodsNo);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tComboEditor_GoodsNoFuzzy);
                if (!this.uCheckGoodsNo.Checked)
                {
                    tEdit_GoodsNo.Text = string.Empty;
                    tComboEditor_GoodsNoFuzzy.Value = CT_FUZZY_MATCHWITH;
                    _srGoodsNo = string.Empty;
                    _srRvGoodsNo = string.Empty;
                }
            }
            #endregion // 品番

            #region 品名
            // 品名
            if (this.uCheckGoodsName_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_GoodsName))
                {
                    // 品名
                    tEdit_GoodsName.Text = string.Empty;
                    tComboEditor_GoodsNameFuzzy.Value = CT_FUZZY_MATCHWITH;
                    _srGoodsName = string.Empty;
                    _srRvGoodsName = string.Empty;
                }

                // 品名ラベル
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_GoodsNameTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_GoodsNameTitle);
                this.uLabel_GoodsNameTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_GoodsNameTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 品名tEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_GoodsName);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_GoodsName);
                this.tEdit_GoodsName.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_GoodsName.Visible = true;
                this.tEdit_GoodsName.Width = CT_INTERVAL_EDIT_WITHCOMBO - 4;
                this.tEdit_GoodsName.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHCOMBO;

                // 品名曖昧検索
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tComboEditor_GoodsNameFuzzy);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_GoodsNameFuzzy);
                this.tComboEditor_GoodsNameFuzzy.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_GoodsNameFuzzy.Visible = true;
                this.tComboEditor_GoodsNameFuzzy.TabIndex = tabIndex++;
                this._currentLocationX += 86; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_GoodsNameTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_GoodsName);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tComboEditor_GoodsNameFuzzy);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_GoodsNameTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_GoodsName);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tComboEditor_GoodsNameFuzzy);
                if (!this.uCheckGoodsName.Checked)
                {
                    tEdit_GoodsName.Text = string.Empty;
                    tComboEditor_GoodsNameFuzzy.Value = CT_FUZZY_MATCHWITH;
                    _srGoodsName = string.Empty;
                    _srRvGoodsName = string.Empty;
                }
            }
            #endregion // 品名

            # region [棚番]
            // 棚番
            if (this.uCheckWarehouseShelfNo_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_WarehouseShelfNo))
                {
                    // 棚番
                    tEdit_WarehouseShelfNo.Text = string.Empty;
                    tComboEditor_WarehouseShelfNoFuzzy.Value = CT_FUZZY_MATCHWITH;
                    _srWarehouseShelfNo = string.Empty;
                    _srRvWarehouseShelfNo = string.Empty;
                }

                // 棚番ラベル
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_WarehouseShelfNo);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_WarehouseShelfNo);
                this.uLabel_WarehouseShelfNo.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_WarehouseShelfNo.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 棚番tEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_WarehouseShelfNo);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_WarehouseShelfNo);
                this.tEdit_WarehouseShelfNo.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_WarehouseShelfNo.Visible = true;
                this.tEdit_WarehouseShelfNo.Width = CT_INTERVAL_EDIT_WITHCOMBO - 4;
                this.tEdit_WarehouseShelfNo.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHCOMBO;

                // 棚番曖昧検索
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tComboEditor_WarehouseShelfNoFuzzy);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_WarehouseShelfNoFuzzy);
                this.tComboEditor_WarehouseShelfNoFuzzy.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_WarehouseShelfNoFuzzy.Visible = true;
                this.tComboEditor_WarehouseShelfNoFuzzy.TabIndex = tabIndex++;
                this._currentLocationX += 86; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_WarehouseShelfNo);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_WarehouseShelfNo);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tComboEditor_WarehouseShelfNoFuzzy);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_WarehouseShelfNo);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_WarehouseShelfNo);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tComboEditor_WarehouseShelfNoFuzzy);
                if (!this.uCheckWarehouseShelfNo.Checked)
                {
                    tEdit_WarehouseShelfNo.Text = string.Empty;
                    tComboEditor_WarehouseShelfNoFuzzy.Value = CT_FUZZY_MATCHWITH;
                    _srWarehouseShelfNo = string.Empty;
                    _srRvWarehouseShelfNo = string.Empty;
                }
            }
            # endregion

            # region [相手拠点]
            // 相手拠点
            if (this.uCheckAfSectionCode_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_AfSectionCode))
                {
                    // 相手拠点
                    //_swAfSectionCode = 0; // DEL 2010/05/18
                    _swAfSectionCode = string.Empty; // ADD 2010/05/18
                    _swAfSectionName = string.Empty;
                    tEdit_AfSectionCode.Text = string.Empty;
                }

                // 相手拠点ラベル
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_AfSectionCodeTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_AfSectionCodeTitle);
                this.uLabel_AfSectionCodeTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_AfSectionCodeTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 相手拠点tEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_AfSectionCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_AfSectionCode);
                this.tEdit_AfSectionCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_AfSectionCode.Visible = true;
                this.tEdit_AfSectionCode.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_AfSectionCode.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // 相手拠点ガイドボタン
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uButton_AfSectionCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_AfSectionCode);
                this.uButton_AfSectionCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_AfSectionCode.Visible = true;
                this.uButton_AfSectionCode.TabIndex = tabIndex++;
                this._currentLocationX += 35; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_AfSectionCodeTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_AfSectionCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uButton_AfSectionCode);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_AfSectionCodeTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_AfSectionCode);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_AfSectionCode);
                // if (!this.uCheckSupplierCd.Checked) // DEL 2011/05/21
                if (!this.uCheckAfSectionCode.Checked) // ADD 2011/05/21
                {
                    // 相手拠点
                    //_swAfSectionCode = 0; // DEL 2010/05/18
                    _swAfSectionCode = string.Empty; // ADD 2010/05/18
                    _swAfSectionName = string.Empty;
                    tEdit_AfSectionCode.Text = string.Empty;
                }
            }
            # endregion

            # region [相手倉庫]
            // 相手倉庫
            if (this.uCheckAfEnterWarehCode_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_AfEnterWarehCode))
                {
                    // 相手倉庫
                    _swAfEnterWarehCode = string.Empty;
                    _swAfEnterWarehName = string.Empty;
                    tEdit_AfEnterWarehCode.Text = string.Empty;
                }

                // 相手倉庫ラベル
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_AfEnterWarehCodeTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_AfEnterWarehCodeTitle);
                this.uLabel_AfEnterWarehCodeTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_AfEnterWarehCodeTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 相手倉庫tEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_AfEnterWarehCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_AfEnterWarehCode);
                this.tEdit_AfEnterWarehCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_AfEnterWarehCode.Visible = true;
                this.tEdit_AfEnterWarehCode.Width = CT_INTERVAL_EDIT_WITHBUTTON - 4;
                this.tEdit_AfEnterWarehCode.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_EDIT_WITHBUTTON;

                // 相手倉庫ガイドボタン
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uButton_AfEnterWarehCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_AfEnterWarehCode);
                this.uButton_AfEnterWarehCode.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_AfEnterWarehCode.Visible = true;
                this.uButton_AfEnterWarehCode.TabIndex = tabIndex++;
                this._currentLocationX += 35; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_AfEnterWarehCodeTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_AfEnterWarehCode);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uButton_AfEnterWarehCode);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_AfEnterWarehCodeTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_AfEnterWarehCode);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_AfEnterWarehCode);
                // if (!this.uCheckSupplierCd.Checked) // DEL 2011/05/21
                if (!this.uCheckAfEnterWarehCode.Checked) // ADD 2011/05/21
                {
                    // 相手倉庫
                    _swAfEnterWarehCode = string.Empty;
                    _swAfEnterWarehName = string.Empty;
                    tEdit_AfEnterWarehCode.Text = string.Empty;
                }
            }

            # endregion

            # region [入荷区分]
             // 入荷区分
            if (this.uCheckArrivalGoodsFlag_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tComboEditor_ArrivalGoodsFlag))
                {
                    // 入荷区分
                        tComboEditor_ArrivalGoodsFlag.SelectedIndex = this.tComboEditor_OutputDiv.SelectedIndex;
                    }

                // 入荷区分ラベル
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_ArrivalGoodsFlagTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_ArrivalGoodsFlagTitle);
                this.uLabel_ArrivalGoodsFlagTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_ArrivalGoodsFlagTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 入荷区分コンボボックス
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tComboEditor_ArrivalGoodsFlag);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_ArrivalGoodsFlag);
                this.tComboEditor_ArrivalGoodsFlag.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_ArrivalGoodsFlag.Visible = true;
                this.tComboEditor_ArrivalGoodsFlag.Width = CT_INTERVAL_COMBOBOX;
                this.tComboEditor_ArrivalGoodsFlag.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_ArrivalGoodsFlagTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tComboEditor_ArrivalGoodsFlag);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_ArrivalGoodsFlagTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tComboEditor_ArrivalGoodsFlag);
                // if (!this.uCheckDeleteFlag.Checked) // DEL 2011/05/21
                if (!this.uCheckArrivalGoodsFlag.Checked) // ADD 2011/05/21
                {
                    // 入荷区分
                    tComboEditor_ArrivalGoodsFlag.SelectedIndex = this.tComboEditor_OutputDiv.SelectedIndex;
                }
            }
            #endregion // 入荷区分

            #region 備考
            // 備考
            if (this.uCheckNote_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tEdit_SlipNote))
                {
                    // 備考
                    tEdit_SlipNote.Text = string.Empty;
                    tComboEditor_SlipNoteFuzzy.Value = CT_FUZZY_MATCHWITH;
                    _srSlipNote = string.Empty;
                    _srRvSlipNote = string.Empty;
                }

                // 備考ラベル
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_SlipNoteTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SlipNoteTitle);
                this.uLabel_SlipNoteTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_SlipNoteTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 備考tEdit
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tEdit_SlipNote);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_SlipNote);
                this.tEdit_SlipNote.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tEdit_SlipNote.Visible = true;
                this.tEdit_SlipNote.Width = CT_INTERVAL_LABEL + CT_FIELD_INTERVAL_X - 1;
                this.tEdit_SlipNote.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_LABEL + 1;


                // 備考１ガイド
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uButton_SlipNote);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_SlipNote);
                this.uButton_SlipNote.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uButton_SlipNote.Visible = true;
                this._currentLocationX += 24 + 1;
                this.uButton_SlipNote.TabIndex = tabIndex++;


                // 備考曖昧検索
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tComboEditor_SlipNoteFuzzy);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_SlipNoteFuzzy);
                this.tComboEditor_SlipNoteFuzzy.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_SlipNoteFuzzy.Visible = true;
                this.tComboEditor_SlipNoteFuzzy.TabIndex = tabIndex++;
                this._currentLocationX += 86; // CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;
                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_SlipNoteTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tEdit_SlipNote);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uButton_SlipNote);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tComboEditor_SlipNoteFuzzy);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_SlipNoteTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_SlipNote);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_SlipNote);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tComboEditor_SlipNoteFuzzy);
                if (!this.uCheckNote.Checked)
                {
                    tEdit_SlipNote.Text = string.Empty;
                    tComboEditor_SlipNoteFuzzy.Value = CT_FUZZY_MATCHWITH;
                    _srSlipNote = string.Empty;
                    _srRvSlipNote = string.Empty;
                }
            }
            #endregion // 備考

            #region 削除指定区分
            // 削除指定区分
            if (this.uCheckDeleteFlag_base.Checked)
            {
                if (this.ultraExpandableGroupBoxPanel2.Controls.Contains(this.tComboEditor_DeleteFlag))
                {
                    // 削除指定区分
                    _logicalDelDiv = 0;
                    tComboEditor_DeleteFlag.SelectedIndex = 0;
                }

                // 削除指定区分ラベル
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.uLabel_DeleteFlagTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_DeleteFlagTitle);
                this.uLabel_DeleteFlagTitle.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.uLabel_DeleteFlagTitle.Visible = true;
                this._currentLocationX += CT_INTERVAL_LABEL;

                // 削除指定区分コンボボックス
                this.ultraExpandableGroupBoxPanel2.Controls.Remove(this.tComboEditor_DeleteFlag);
                this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_DeleteFlag);
                this.tComboEditor_DeleteFlag.Location = new Point(this._currentLocationX, this._currentLocationY);
                this.tComboEditor_DeleteFlag.Visible = true;
                this.tComboEditor_DeleteFlag.Width = CT_INTERVAL_COMBOBOX;
                this.tComboEditor_DeleteFlag.TabIndex = tabIndex++;
                this._currentLocationX += CT_INTERVAL_COMBOBOX + CT_FIELD_INTERVAL_X;

                displayedItemCount++;
                if (displayedItemCount % CT_INITIA_COMMONL_ROW_COUNT == 0)
                {
                    this._currentLocationX = startLocationX;
                    this._currentLocationY += CT_INTERVAL_HEIGHT;
                }
            }
            else
            {
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.uLabel_DeleteFlagTitle);
                this.ultraExpandableGroupBoxPanel1.Controls.Remove(this.tComboEditor_DeleteFlag);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_DeleteFlagTitle);
                this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tComboEditor_DeleteFlag);
                if (!this.uCheckDeleteFlag.Checked)
                {
                    _logicalDelDiv = 0;
                    tComboEditor_DeleteFlag.SelectedIndex = 0;
                }
            }
            #endregion // 削除指定区分

        }
        #endregion

        #region 表示されている次のコントロールを取得する
        /// <summary>
        /// 拡張基本条件で、表示されている次のコントロールを取得する
        /// </summary>
        /// <remarks>
        /// <param name="controlName">controlName</param>
        /// <returns>次のコントロール</returns>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// </remarks>
        private Control GetNextCommonControl(string controlName)
        {
            Control nextCtrl = null;

            // 出荷日
            if (controlName == "tDateEdit_DateEd")
            {
                if (this.tEdit_StockMoveSlipNum.Visible && this.uCheckSalesSlipNum_base.Checked) nextCtrl = this.tEdit_StockMoveSlipNum;
                else nextCtrl = GetNextCommonControl("tEdit_StockMoveSlipNum");

            }

            // 伝票番号
            if (controlName == "tEdit_StockMoveSlipNum")
            {
                if (this.tDateEdit_AddUpADateSt.Visible && this.uCheckAddUpADateSt_base.Checked) nextCtrl = this.tDateEdit_AddUpADateSt;
                else nextCtrl = GetNextCommonControl("tDateEdit_AddUpADateSt");
            }

            // 入力日開始
            if (controlName == "tDateEdit_AddUpADateSt")
            {
                if (this.tDateEdit_AddUpADateEd.Visible && this.uCheckAddUpADateEd_base.Checked) nextCtrl = this.tDateEdit_AddUpADateEd;
                else nextCtrl = GetNextCommonControl("tDateEdit_AddUpADateEd");
            }

            // 入力日終了
            if (controlName == "tDateEdit_AddUpADateEd")
            {
                if (this.tEdit_SalesEmployeeCd.Visible && this.uCheckSalesEmployeeCd_base.Checked) nextCtrl = this.tEdit_SalesEmployeeCd;
                else nextCtrl = GetNextCommonControl("tEdit_SalesEmployeeCd");
            }

            // 担当者
            if (controlName == "tEdit_SalesEmployeeCd")
            {
                if (this.tEdit_SalesEmployeeCd.Visible && String.IsNullOrEmpty(this.tEdit_SalesEmployeeCd.Text.Trim()) && this.uCheckSalesEmployeeCd_base.Checked)
                {
                    nextCtrl = this.uButton_SalesEmployeeCd;
                }
                else
                {
                    if (this.tEdit_SupplierCd.Visible && this.uCheckSupplierCd_base.Checked) nextCtrl = this.tEdit_SupplierCd;
                    else nextCtrl = GetNextCommonControl("tEdit_SupplierCd");
                }
            }

            // 担当者ガイド
            if (controlName == "uButton_SalesEmployeeCd")
            {
                if (this.tEdit_SupplierCd.Visible && this.uCheckSupplierCd_base.Checked) nextCtrl = this.tEdit_SupplierCd;
                else nextCtrl = GetNextCommonControl("tEdit_SupplierCd");
            }

            // 仕入先
            if (controlName == "tEdit_SupplierCd")
            {
                if (this.tEdit_SupplierCd.Visible && String.IsNullOrEmpty(this.tEdit_SupplierCd.Text.Trim()) && this.uCheckSupplierCd_base.Checked)
                {
                    nextCtrl = this.uButton_SupplierCd;
                }
                else
                {
                    if (this.tEdit_MakerCd.Visible && this.uCheckGoodsMakerCd_base.Checked) nextCtrl = this.tEdit_MakerCd;
                    else nextCtrl = GetNextCommonControl("tEdit_MakerCd");
                }
            }

            // 仕入先ガイド
            if (controlName == "uButton_SupplierCd")
            {
                if (this.tEdit_MakerCd.Visible && this.uCheckGoodsMakerCd_base.Checked) nextCtrl = this.tEdit_MakerCd;
                else nextCtrl = GetNextCommonControl("tEdit_MakerCd");
            }

            // メーカーコード
            if (controlName == "tEdit_MakerCd")
            {
                if (this.tEdit_MakerCd.Visible && String.IsNullOrEmpty(this.tEdit_MakerCd.Text.Trim()) && this.uCheckGoodsMakerCd_base.Checked)
                {
                    nextCtrl = this.uButton_MakerCd;
                }
                else
                {
                    if (this.tEdit_BlGoodsCode.Visible && this.uCheckBLGoodsCode_base.Checked) nextCtrl = this.tEdit_BlGoodsCode;
                    else nextCtrl = GetNextCommonControl("tEdit_BlGoodsCode");
                }
            }

            // メーカーガイド
            if (controlName == "uButton_MakerCd")
            {
                if (this.tEdit_BlGoodsCode.Visible && this.uCheckBLGoodsCode_base.Checked) nextCtrl = this.tEdit_BlGoodsCode;
                else nextCtrl = GetNextCommonControl("tEdit_BlGoodsCode");
            }

            // BLコード
            if (controlName == "tEdit_BlGoodsCode")
            {
                if (this.tEdit_BlGoodsCode.Visible && String.IsNullOrEmpty(this.tEdit_BlGoodsCode.Text.Trim()) && this.uCheckBLGoodsCode_base.Checked)
                {
                    nextCtrl = this.uButton_BlGoodsCode;
                }
                else
                {
                    if (this.tEdit_GoodsNo.Visible && this.uCheckGoodsNo_base.Checked) nextCtrl = this.tEdit_GoodsNo;
                    else nextCtrl = GetNextCommonControl("tEdit_GoodsNo");
                }
            }

            // BLコードガイド
            if (controlName == "uButton_BlGoodsCode")
            {
                if (this.tEdit_GoodsNo.Visible && this.uCheckGoodsNo_base.Checked) nextCtrl = this.tEdit_GoodsNo;
                else nextCtrl = GetNextCommonControl("tEdit_GoodsNo");
            }

            // 品番
            if (controlName == "tEdit_GoodsNo")
            {
                if (this.tEdit_GoodsNo.Visible && String.IsNullOrEmpty(this.tEdit_GoodsNo.Text.Trim()) && this.uCheckGoodsNo_base.Checked)
                {
                    nextCtrl = this.tComboEditor_GoodsNoFuzzy;
                }
                else
                {
                    if (this.tEdit_GoodsName.Visible && this.uCheckGoodsName_base.Checked) nextCtrl = this.tEdit_GoodsName;
                    else nextCtrl = GetNextCommonControl("tEdit_GoodsName");
                }
            }

            // 品番あいまい条件
            if (controlName == "tComboEditor_GoodsNoFuzzy")
            {
                if (this.tEdit_GoodsName.Visible && this.uCheckGoodsName_base.Checked) nextCtrl = this.tEdit_GoodsName;
                else nextCtrl = GetNextCommonControl("tEdit_GoodsName");
            }

            // 品名
            if (controlName == "tEdit_GoodsName")
            {
                if (this.tEdit_GoodsName.Visible && String.IsNullOrEmpty(this.tEdit_GoodsName.Text.Trim()) && this.uCheckGoodsName_base.Checked)
                {
                    nextCtrl = this.tComboEditor_GoodsNameFuzzy;
                }
                else
                {
                    if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && this.uCheckWarehouseShelfNo_base.Checked) nextCtrl = this.tEdit_WarehouseShelfNo;
                    else nextCtrl = GetNextCommonControl("tEdit_WarehouseShelfNo");
                }
            }

            // 品名あいまい条件
            if (controlName == "tComboEditor_GoodsNameFuzzy")
            {
                if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && this.uCheckWarehouseShelfNo_base.Checked) nextCtrl = this.tEdit_WarehouseShelfNo;
                else nextCtrl = GetNextCommonControl("tEdit_WarehouseShelfNo");
            }

            // 棚番
            if (controlName == "tEdit_WarehouseShelfNo")
            {
                if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && String.IsNullOrEmpty(this.tEdit_WarehouseShelfNo.Text.Trim()) && this.uCheckWarehouseShelfNo_base.Checked)
                {
                    nextCtrl = this.tComboEditor_WarehouseShelfNoFuzzy;
                }
                else
                {
                    if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && this.uCheckAfSectionCode_base.Checked) nextCtrl = this.tEdit_AfSectionCode;
                    else nextCtrl = GetNextCommonControl("tEdit_AfSectionCode");
                }
            }

            // 棚番あいまい条件
            if (controlName == "tComboEditor_WarehouseShelfNoFuzzy")
            {
                if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && this.uCheckAfSectionCode_base.Checked) nextCtrl = this.tEdit_AfSectionCode;
                else nextCtrl = GetNextCommonControl("tEdit_AfSectionCode");
            }

            // 相手拠点
            if (controlName == "tEdit_AfSectionCode")
            {
                if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && String.IsNullOrEmpty(this.tEdit_AfSectionCode.Text.Trim()) && this.uCheckAfSectionCode_base.Checked)
                {
                    nextCtrl = this.uButton_AfSectionCode;
                }
                else
                {
                    if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && this.uCheckAfEnterWarehCode_base.Checked) nextCtrl = this.tEdit_AfEnterWarehCode;
                    else nextCtrl = GetNextCommonControl("tEdit_AfEnterWarehCode");
                }
            }

            // 相手拠点ガイド
            if (controlName == "uButton_AfSectionCode")
            {
                if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && this.uCheckAfEnterWarehCode_base.Checked) nextCtrl = this.tEdit_AfEnterWarehCode;
                else nextCtrl = GetNextCommonControl("tEdit_AfEnterWarehCode");
            }

            // 相手倉庫
            if (controlName == "tEdit_AfEnterWarehCode")
            {
                if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && String.IsNullOrEmpty(this.tEdit_AfEnterWarehCode.Text.Trim()) && this.uCheckAfEnterWarehCode_base.Checked)
                {
                    nextCtrl = this.uButton_AfEnterWarehCode;
                }
                else
                {
                    if (this.tComboEditor_ArrivalGoodsFlag.Visible && this.uCheckArrivalGoodsFlag_base.Checked && this.tComboEditor_ArrivalGoodsFlag.Enabled) nextCtrl = this.tComboEditor_ArrivalGoodsFlag;
                    else nextCtrl = GetNextCommonControl("tComboEditor_ArrivalGoodsFlag");
                }
            }

            // 相手倉庫ガイド
            if (controlName == "uButton_AfEnterWarehCode")
            {
                if (this.tComboEditor_ArrivalGoodsFlag.Visible && this.uCheckArrivalGoodsFlag_base.Checked && this.tComboEditor_ArrivalGoodsFlag.Enabled) nextCtrl = this.tComboEditor_ArrivalGoodsFlag;
                else nextCtrl = GetNextCommonControl("tComboEditor_ArrivalGoodsFlag");
            }

            // 入荷区分
            if (controlName == "tComboEditor_ArrivalGoodsFlag")
            {
                if (this.tEdit_SlipNote.Visible && this.uCheckNote_base.Checked) nextCtrl = this.tEdit_SlipNote;
                else nextCtrl = GetNextCommonControl("tEdit_SlipNote");
            }

            // 備考
            if (controlName == "tEdit_SlipNote")
            {
                if (this.tEdit_SlipNote.Visible && String.IsNullOrEmpty(this.tEdit_SlipNote.Text.Trim()) && this.uCheckNote_base.Checked)
                {
                    nextCtrl = this.uButton_SlipNote;
                }
                else
                {
                    if (this.tComboEditor_DeleteFlag.Visible && this.uCheckDeleteFlag_base.Checked) nextCtrl = this.tComboEditor_DeleteFlag;
                    else nextCtrl = GetNextCommonControl("tComboEditor_DeleteFlag");
                }
            }

            // 備考ガイド
            if (controlName == "uButton_SlipNote")
            {
                if (this.tComboEditor_SlipNoteFuzzy.Visible && this.uCheckNote_base.Checked) nextCtrl = this.tComboEditor_SlipNoteFuzzy;
                else nextCtrl = GetNextCommonControl("tComboEditor_SlipNoteFuzzy");
            }

            // 備考あいまい条件
            if (controlName == "tComboEditor_SlipNoteFuzzy")
            {
                if (this.tComboEditor_DeleteFlag.Visible && this.uCheckDeleteFlag_base.Checked) nextCtrl = this.tComboEditor_DeleteFlag;
                else nextCtrl = GetNextCommonControl("tComboEditor_DeleteFlag");
            }

            // 削除指定区分
            if (controlName == "tComboEditor_DeleteFlag")
            {
                // 抽出条件
                if (this.uExGroupBox_ExtraCondition.Visible)
                {
                    if (this.tEdit_StockMoveSlipNum.Visible && this.uCheckSalesSlipNum.Checked && this.uCheckSalesSlipNum.Enabled == true)
                    {
                        nextCtrl = this.tEdit_StockMoveSlipNum;
                    }
                    else
                    {
                        //拡張検索条件の表示状態を調べて次へ
                        nextCtrl = this.GetNextControl("tEdit_StockMoveSlipNum");
                    }
                }
                //else nextCtrl = this.SearchOnChangeFocus(nextCtrl);
                else nextCtrl = uGrid_StockMove;
            }

            return nextCtrl;
        }

        /// <summary>
        /// 拡張検索条件で、表示されている次のコントロールを取得する
        /// </summary>
        /// <param name="controlName">controlName</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 拡張検索条件で、表示されている次のコントロールを取得する。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private Control GetNextControl(string controlName)
        {
            Control nextCtrl = null;

            // 出荷日（終了）
            if (controlName == "tDateEdit_DateEd")
            {
                if (this.tEdit_StockMoveSlipNum.Visible && this.uCheckSalesSlipNum.Checked && this.uCheckSalesSlipNum.Enabled == true) nextCtrl = this.tEdit_StockMoveSlipNum;
                else nextCtrl = GetNextControl("tEdit_StockMoveSlipNum");
            }
            // 伝票番号
            if (controlName == "tEdit_StockMoveSlipNum")
            {
                if (this.tDateEdit_AddUpADateSt.Visible && this.uCheckAddUpADateSt.Checked && this.uCheckAddUpADateSt.Enabled == true) nextCtrl = this.tDateEdit_AddUpADateSt;
                else nextCtrl = GetNextControl("tDateEdit_AddUpADateSt");
            }

            // 入力日開始
            if (controlName == "tDateEdit_AddUpADateSt")
            {
                if (this.tDateEdit_AddUpADateEd.Visible && this.uCheckAddUpADateEd.Checked && this.uCheckAddUpADateEd.Enabled == true) nextCtrl = this.tDateEdit_AddUpADateEd;
                else nextCtrl = GetNextControl("tDateEdit_AddUpADateEd");
            }

            // 入力日終了
            if (controlName == "tDateEdit_AddUpADateEd")
            {
                if (this.tEdit_SalesEmployeeCd.Visible && this.uCheckSalesEmployeeCd.Checked && this.uCheckSalesEmployeeCd.Enabled == true) nextCtrl = this.tEdit_SalesEmployeeCd;
                else nextCtrl = GetNextControl("tEdit_SalesEmployeeCd");
            }

            // 担当者
            if (controlName == "tEdit_SalesEmployeeCd")
            {
                if (this.tEdit_SalesEmployeeCd.Visible && String.IsNullOrEmpty(this.tEdit_SalesEmployeeCd.Text.Trim()) &&
                    this.uCheckSalesEmployeeCd.Checked && this.uCheckSalesEmployeeCd.Enabled == true)
                {
                    nextCtrl = this.uButton_SalesEmployeeCd;
                }
                else
                {
                    if (this.tEdit_SupplierCd.Visible && this.uCheckSupplierCd.Checked && this.uCheckSupplierCd.Enabled == true) nextCtrl = this.tEdit_SupplierCd;
                    else nextCtrl = GetNextControl("tEdit_SupplierCd");
                }
            }

            // 担当者ガイド
            if (controlName == "uButton_SalesEmployeeCd")
            {
                if (this.tEdit_SupplierCd.Visible && this.uCheckSupplierCd.Checked && this.uCheckSupplierCd.Enabled == true) nextCtrl = this.tEdit_SupplierCd;
                else nextCtrl = GetNextControl("tEdit_SupplierCd");
            }

            // 仕入先
            if (controlName == "tEdit_SupplierCd")
            {
                if (this.tEdit_SupplierCd.Visible && String.IsNullOrEmpty(this.tEdit_SupplierCd.Text.Trim()) &&
                    this.uCheckSupplierCd.Checked && this.uCheckSupplierCd.Enabled == true)
                {
                    nextCtrl = this.uButton_SupplierCd;
                }
                else
                {
                    if (this.tEdit_MakerCd.Visible && this.uCheckGoodsMakerCd.Checked && this.uCheckGoodsMakerCd.Enabled == true) nextCtrl = this.tEdit_MakerCd;
                    else nextCtrl = GetNextControl("tEdit_MakerCd");
                }
            }

            // 仕入先ガイド
            if (controlName == "uButton_SupplierCd")
            {
                if (this.tEdit_MakerCd.Visible && this.uCheckGoodsMakerCd.Checked && this.uCheckGoodsMakerCd.Enabled == true) nextCtrl = this.tEdit_MakerCd;
                else nextCtrl = GetNextControl("tEdit_MakerCd");
            }

            // メーカーコード
            if (controlName == "tEdit_MakerCd")
            {
                if (this.tEdit_MakerCd.Visible && String.IsNullOrEmpty(this.tEdit_MakerCd.Text.Trim()) &&
                    this.uCheckGoodsMakerCd.Checked && this.uCheckGoodsMakerCd.Enabled == true)
                {
                    nextCtrl = this.uButton_MakerCd;
                }
                else
                {
                    if (this.tEdit_BlGoodsCode.Visible && this.uCheckBLGoodsCode.Checked && this.uCheckBLGoodsCode.Enabled == true) nextCtrl = this.tEdit_BlGoodsCode;
                    else nextCtrl = GetNextControl("tEdit_BlGoodsCode");
                }
            }

            // メーカーガイド
            if (controlName == "uButton_MakerCd")
            {
                if (this.tEdit_BlGoodsCode.Visible && this.uCheckBLGoodsCode.Checked && this.uCheckBLGoodsCode.Enabled == true) nextCtrl = this.tEdit_BlGoodsCode;
                else nextCtrl = GetNextControl("tEdit_BlGoodsCode");
            }

            // BLコード
            if (controlName == "tEdit_BlGoodsCode")
            {
                if (this.tEdit_BlGoodsCode.Visible && String.IsNullOrEmpty(this.tEdit_BlGoodsCode.Text.Trim()) &&
                    this.uCheckBLGoodsCode.Checked && this.uCheckBLGoodsCode.Enabled == true)
                {
                    nextCtrl = this.uButton_BlGoodsCode;
                }
                else
                {
                    if (this.tEdit_GoodsNo.Visible && this.uCheckGoodsNo.Checked && this.uCheckGoodsNo.Enabled == true) nextCtrl = this.tEdit_GoodsNo;
                    else nextCtrl = GetNextControl("tEdit_GoodsNo");
                }
            }

            // BLコードガイド
            if (controlName == "uButton_BlGoodsCode")
            {
                if (this.tEdit_GoodsNo.Visible && this.uCheckGoodsNo.Checked && this.uCheckGoodsNo.Enabled == true) nextCtrl = this.tEdit_GoodsNo;
                else nextCtrl = GetNextControl("tEdit_GoodsNo");
            }

            // 品番
            if (controlName == "tEdit_GoodsNo")
            {
                if (this.tEdit_GoodsNo.Visible && String.IsNullOrEmpty(this.tEdit_GoodsNo.Text.Trim()) &&
                    this.uCheckGoodsNo.Checked && this.uCheckGoodsNo.Enabled == true)
                {
                    nextCtrl = this.tComboEditor_GoodsNoFuzzy;
                }
                else
                {
                    if (this.tEdit_GoodsName.Visible && this.uCheckGoodsName.Checked && this.uCheckGoodsName.Enabled == true) nextCtrl = this.tEdit_GoodsName;
                    else nextCtrl = GetNextControl("tEdit_GoodsName");
                }
            }

            // 品番あいまい条件
            if (controlName == "tComboEditor_GoodsNoFuzzy")
            {
                if (this.tEdit_GoodsName.Visible && this.uCheckGoodsName.Checked && this.uCheckGoodsName.Enabled == true) nextCtrl = this.tEdit_GoodsName;
                else nextCtrl = GetNextControl("tEdit_GoodsName");
            }

            // 品名
            if (controlName == "tEdit_GoodsName")
            {
                if (this.tEdit_GoodsName.Visible && String.IsNullOrEmpty(this.tEdit_GoodsName.Text.Trim()) &&
                    this.uCheckGoodsName.Checked && this.uCheckGoodsName.Enabled == true)
                {
                    nextCtrl = this.tComboEditor_GoodsNameFuzzy;
                }
                else
                {
                    if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && this.tEdit_WarehouseShelfNo.Enabled == true && this.uCheckWarehouseShelfNo.Checked && this.uCheckWarehouseShelfNo.Enabled == true) nextCtrl = this.tEdit_WarehouseShelfNo;
                    else nextCtrl = GetNextControl("tEdit_WarehouseShelfNo");
                }
            }

            // 品名あいまい条件
            if (controlName == "tComboEditor_GoodsNameFuzzy")
            {
                if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && this.uCheckWarehouseShelfNo.Checked && this.uCheckWarehouseShelfNo.Enabled == true) nextCtrl = this.tEdit_WarehouseShelfNo;
                else nextCtrl = GetNextControl("tEdit_WarehouseShelfNo");
            }

            // 棚番
            if (controlName == "tEdit_WarehouseShelfNo")
            {
                if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && String.IsNullOrEmpty(this.tEdit_WarehouseShelfNo.Text.Trim()) &&
                    this.uCheckWarehouseShelfNo.Checked && this.uCheckWarehouseShelfNo.Enabled == true)
                {
                    nextCtrl = this.tComboEditor_WarehouseShelfNoFuzzy;
                }
                else
                {
                    if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && this.uCheckAfSectionCode.Checked && this.uCheckAfSectionCode.Enabled == true) nextCtrl = this.tEdit_AfSectionCode;
                    else nextCtrl = GetNextControl("tEdit_AfSectionCode");
                }
            }

            // 棚番あいまい条件
            if (controlName == "tComboEditor_WarehouseShelfNoFuzzy")
            {
                if (this.tEdit_AfSectionCode.Visible && this.uCheckAfSectionCode.Checked && this.uCheckAfSectionCode.Enabled == true) nextCtrl = this.tEdit_AfSectionCode;
                else nextCtrl = GetNextControl("tEdit_AfSectionCode");
            }

            // 相手拠点
            if (controlName == "tEdit_AfSectionCode")
            {
                if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && String.IsNullOrEmpty(this.tEdit_AfSectionCode.Text.Trim()) &&
                    this.uCheckAfSectionCode.Checked && this.uCheckAfSectionCode.Enabled == true)
                {
                    nextCtrl = this.uButton_AfSectionCode;
                }
                else
                {
                    if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && this.uCheckAfEnterWarehCode.Checked && this.uCheckAfEnterWarehCode.Enabled == true) nextCtrl = this.tEdit_AfEnterWarehCode;
                    else nextCtrl = GetNextControl("tEdit_AfEnterWarehCode");
                }
            }

            // 相手拠点ガイド
            if (controlName == "uButton_AfSectionCode")
            {
                if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && this.uCheckAfEnterWarehCode.Checked && this.uCheckAfEnterWarehCode.Enabled == true) nextCtrl = this.tEdit_AfEnterWarehCode;
                else nextCtrl = GetNextControl("tEdit_AfEnterWarehCode");
            }

            // 相手倉庫
            if (controlName == "tEdit_AfEnterWarehCode")
            {
                if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && String.IsNullOrEmpty(this.tEdit_AfEnterWarehCode.Text.Trim()) &&
                    this.uCheckAfEnterWarehCode.Checked && this.uCheckAfEnterWarehCode.Enabled == true)
                {
                    nextCtrl = this.uButton_AfEnterWarehCode;
                }
                else
                {
                    if (this.tComboEditor_ArrivalGoodsFlag.Visible && this.uCheckArrivalGoodsFlag.Checked && this.uCheckArrivalGoodsFlag.Enabled == true && this.tComboEditor_ArrivalGoodsFlag.Enabled) nextCtrl = this.tComboEditor_ArrivalGoodsFlag;
                    else nextCtrl = GetNextControl("tComboEditor_ArrivalGoodsFlag");
                }
            }

            // 相手倉庫ガイド
            if (controlName == "uButton_AfEnterWarehCode")
            {
                if (this.tComboEditor_ArrivalGoodsFlag.Visible && this.uCheckArrivalGoodsFlag.Checked && this.uCheckArrivalGoodsFlag.Enabled == true && this.tComboEditor_ArrivalGoodsFlag.Enabled) nextCtrl = this.tComboEditor_ArrivalGoodsFlag;
                else nextCtrl = GetNextControl("tComboEditor_ArrivalGoodsFlag");
            }

            // 入荷区分
            if (controlName == "tComboEditor_ArrivalGoodsFlag")
            {
                if (this.tEdit_SlipNote.Visible && this.uCheckNote.Checked && this.uCheckNote.Enabled == true) nextCtrl = this.tEdit_SlipNote;
                else nextCtrl = GetNextControl("tEdit_SlipNote");
            }

            // 備考
            if (controlName == "tEdit_SlipNote")
            {
                if (this.tEdit_SlipNote.Visible && String.IsNullOrEmpty(this.tEdit_SlipNote.Text.Trim()) &&
                    this.uCheckNote.Checked && this.uCheckNote.Enabled == true)
                {
                    nextCtrl = this.uButton_SlipNote;
                }
                else
                {
                    if (this.tComboEditor_DeleteFlag.Visible && this.uCheckDeleteFlag.Checked && this.uCheckDeleteFlag.Enabled == true) nextCtrl = this.tComboEditor_DeleteFlag;
                    else nextCtrl = GetNextControl("tComboEditor_DeleteFlag");
                }
            }

            // 備考ガイド
            if (controlName == "uButton_SlipNote")
            {
                if (this.tComboEditor_SlipNoteFuzzy.Visible && this.uCheckNote.Checked && this.uCheckNote.Enabled == true) nextCtrl = this.tComboEditor_SlipNoteFuzzy;
                else nextCtrl = GetNextControl("tComboEditor_SlipNoteFuzzy");
            }

            // 備考あいまい条件
            if (controlName == "tComboEditor_SlipNoteFuzzy")
            {
                if (this.tComboEditor_DeleteFlag.Visible && this.uCheckDeleteFlag.Checked && this.uCheckDeleteFlag.Enabled == true) nextCtrl = this.tComboEditor_DeleteFlag;
                else nextCtrl = GetNextControl("tComboEditor_DeleteFlag");
            }

            // 削除指定区分
            if (controlName == "tComboEditor_DeleteFlag")
            {
                // 検索実行・フォーカス移動
                nextCtrl = uGrid_StockMove;
            }
            return nextCtrl;
        }
        #endregion // 表示されている次のコントロールを取得する

        #region 表示されている前のコントロールを取得する
        /// <summary>
        /// 拡張基本条件で、表示されている前のコントロールを取得する
        /// </summary>
        /// <param name="controlName">controlName</param>
        /// <returns>前のコントロール</returns>
        /// <remarks>
        /// <br>Note       : 拡張基本条件で、表示されている前のコントロールを取得する。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private Control GetBeforeCommonControl(string controlName)
        {
            Control nextCtrl = null;

            // 伝票番号
            if (controlName == "tEdit_StockMoveSlipNum")
            {
                nextCtrl = this.tDateEdit_DateEd;
            }

            // 入力日開始
            if (controlName == "tDateEdit_AddUpADateSt")
            {
                if (this.tEdit_StockMoveSlipNum.Visible && this.uCheckSalesSlipNum_base.Checked) nextCtrl = this.tEdit_StockMoveSlipNum;
                else nextCtrl = GetBeforeCommonControl("tEdit_StockMoveSlipNum");
            }

            // 入力日終了
            if (controlName == "tDateEdit_AddUpADateEd")
            {
                if (this.tDateEdit_AddUpADateSt.Visible && this.uCheckAddUpADateSt_base.Checked) nextCtrl = this.tDateEdit_AddUpADateSt;
                else nextCtrl = GetBeforeCommonControl("tDateEdit_AddUpADateSt");
            }

            // 担当者
            if (controlName == "tEdit_SalesEmployeeCd")
            {
                if (this.tDateEdit_AddUpADateEd.Visible && this.uCheckAddUpADateEd_base.Checked) nextCtrl = this.tDateEdit_AddUpADateEd;
                else nextCtrl = GetBeforeCommonControl("tDateEdit_AddUpADateEd");
            }

            // 担当者ガイド
            if (controlName == "uButton_SalesEmployeeCd")
            {
                if (this.tEdit_SalesEmployeeCd.Visible && this.uCheckSalesEmployeeCd_base.Checked) nextCtrl = this.tEdit_SalesEmployeeCd;
                else nextCtrl = GetBeforeCommonControl("tEdit_SalesEmployeeCd");
            }

            // 仕入先
            if (controlName == "tEdit_SupplierCd")
            {
                if (this.tEdit_SalesEmployeeCd.Visible && this.uCheckSalesEmployeeCd_base.Checked) nextCtrl = this.uButton_SalesEmployeeCd;
                else nextCtrl = GetBeforeCommonControl("tEdit_SalesEmployeeCd");
            }

            // 仕入先ガイド
            if (controlName == "uButton_SupplierCd")
            {
                if (this.tEdit_SupplierCd.Visible && this.uCheckSupplierCd_base.Checked) nextCtrl = this.tEdit_SupplierCd;
                else nextCtrl = GetBeforeCommonControl("tEdit_SupplierCd");
            }

            // メーカーコード
            if (controlName == "tEdit_MakerCd")
            {
                if (this.tEdit_SupplierCd.Visible && this.uCheckSupplierCd_base.Checked) nextCtrl = this.uButton_SupplierCd;
                else nextCtrl = GetBeforeCommonControl("tEdit_SupplierCd");
            }

            // メーカーガイド
            if (controlName == "uButton_MakerCd")
            {
                if (this.tEdit_MakerCd.Visible && this.uCheckGoodsMakerCd_base.Checked) nextCtrl = this.tEdit_MakerCd;
                else nextCtrl = GetBeforeCommonControl("tEdit_MakerCd");
            }

            // BLコード
            if (controlName == "tEdit_BlGoodsCode")
            {
                if (this.tEdit_MakerCd.Visible && this.uCheckGoodsMakerCd_base.Checked) nextCtrl = this.uButton_MakerCd;
                else nextCtrl = GetBeforeCommonControl("tEdit_MakerCd");
            }

            // BLコードガイド
            if (controlName == "uButton_BlGoodsCode")
            {
                if (this.tEdit_BlGoodsCode.Visible && this.uCheckBLGoodsCode_base.Checked) nextCtrl = this.tEdit_BlGoodsCode;
                else nextCtrl = GetBeforeCommonControl("tEdit_BlGoodsCode");
            }

            // 品番
            if (controlName == "tEdit_GoodsNo")
            {
                if (this.tEdit_BlGoodsCode.Visible && this.uCheckBLGoodsCode_base.Checked) nextCtrl = this.uButton_BlGoodsCode;
                else nextCtrl = GetBeforeCommonControl("tEdit_BlGoodsCode");
            }

            // 品番あいまい条件
            if (controlName == "tComboEditor_GoodsNoFuzzy")
            {
                if (this.tEdit_GoodsNo.Visible && this.uCheckGoodsNo_base.Checked) nextCtrl = this.tEdit_GoodsNo;
                else nextCtrl = GetBeforeCommonControl("tEdit_GoodsNo");
            }

            // 品名
            if (controlName == "tEdit_GoodsName")
            {
                if (this.tEdit_GoodsNo.Visible && this.uCheckGoodsNo_base.Checked) nextCtrl = this.tComboEditor_GoodsNoFuzzy;
                else nextCtrl = GetBeforeCommonControl("tEdit_GoodsNo");
            }

            // 品名あいまい条件
            if (controlName == "tComboEditor_GoodsNameFuzzy")
            {
                if (this.tEdit_GoodsName.Visible && this.uCheckGoodsName_base.Checked) nextCtrl = this.tEdit_GoodsName;
                else nextCtrl = GetBeforeCommonControl("tEdit_GoodsName");
            }

            // 棚番
            if (controlName == "tEdit_WarehouseShelfNo")
            {
                if (this.tEdit_GoodsName.Visible && this.uCheckGoodsName_base.Checked) nextCtrl = this.tComboEditor_GoodsNameFuzzy;
                else nextCtrl = GetBeforeCommonControl("tEdit_GoodsName");
            }

            // 棚番あいまい条件
            if (controlName == "tComboEditor_WarehouseShelfNoFuzzy")
            {
                if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && this.uCheckWarehouseShelfNo_base.Checked) nextCtrl = this.tEdit_WarehouseShelfNo;
                else nextCtrl = GetBeforeCommonControl("tEdit_WarehouseShelfNo");
            }

            // 相手拠点
            if (controlName == "tEdit_AfSectionCode")
            {
                if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && this.uCheckWarehouseShelfNo_base.Checked) nextCtrl = this.tComboEditor_WarehouseShelfNoFuzzy;
                else nextCtrl = GetBeforeCommonControl("tEdit_WarehouseShelfNo");
            }

            // 相手拠点ガイド
            if (controlName == "uButton_AfSectionCode")
            {
                if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && this.uCheckAfSectionCode_base.Checked) nextCtrl = this.tEdit_AfSectionCode;
                else nextCtrl = GetBeforeCommonControl("tEdit_AfSectionCode");
            }

            // 相手倉庫コード
            if (controlName == "tEdit_AfEnterWarehCode")
            {
                if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && this.uCheckAfSectionCode_base.Checked) nextCtrl = this.uButton_AfSectionCode;
                else nextCtrl = GetBeforeCommonControl("tEdit_AfSectionCode");
            }

            // 相手倉庫ガイド
            if (controlName == "uButton_AfEnterWarehCode")
            {
                if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && this.uCheckAfEnterWarehCode_base.Checked) nextCtrl = this.tEdit_AfEnterWarehCode;
                else nextCtrl = GetBeforeCommonControl("tEdit_AfEnterWarehCode");
            }

            // 入荷区分
            if (controlName == "tComboEditor_ArrivalGoodsFlag")
            {
                if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && this.uCheckAfEnterWarehCode_base.Checked) nextCtrl = this.uButton_AfEnterWarehCode;
                else nextCtrl = GetBeforeCommonControl("tEdit_AfEnterWarehCode");
            }

            // 備考
            if (controlName == "tEdit_SlipNote")
            {
                if (this.tComboEditor_ArrivalGoodsFlag.Visible && this.uCheckArrivalGoodsFlag_base.Checked && this.tComboEditor_ArrivalGoodsFlag.Enabled) nextCtrl = this.tComboEditor_ArrivalGoodsFlag;
                else nextCtrl = GetBeforeCommonControl("tComboEditor_ArrivalGoodsFlag");
            }

            // 備考ガイド
            if (controlName == "uButton_SlipNote")
            {
                if (this.tEdit_SlipNote.Visible && this.uCheckNote_base.Checked) nextCtrl = this.tEdit_SlipNote;
                else nextCtrl = GetBeforeCommonControl("tEdit_SlipNote");
            }

            // 備考あいまい条件
            if (controlName == "tComboEditor_SlipNoteFuzzy")
            {
                if (this.tEdit_SlipNote.Visible && this.uCheckNote_base.Checked) nextCtrl = this.uButton_SlipNote;
                else nextCtrl = GetBeforeCommonControl("tEdit_SlipNote");
            }

            // 入荷区分
            if (controlName == "tComboEditor_DeleteFlag")
            {
                if (this.tEdit_SlipNote.Visible && this.uCheckNote_base.Checked) nextCtrl = this.tComboEditor_SlipNoteFuzzy;
                else nextCtrl = GetBeforeCommonControl("tEdit_SlipNote");
            }
            return nextCtrl;
        }

        /// <summary>
        /// 拡張抽出条件で、表示されている前のコントロールを取得する
        /// </summary>
        /// <param name="controlName">controlName</param>
        /// <returns>前のコントロール</returns>
        /// <remarks>
        /// <br>Note       : 拡張抽出条件で、表示されている前のコントロールを取得する。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private Control GetBeforeControl(string controlName)
        {
            Control nextCtrl = null;

            // 伝票番号
            if (controlName == "tEdit_StockMoveSlipNum")
            {
                // 基本条件
                if (this.uExGroupBox_CommonCondition.Visible)
                {
                    if (this.tComboEditor_DeleteFlag.Visible && this.uCheckDeleteFlag_base.Checked)
                    {
                        nextCtrl = this.tComboEditor_DeleteFlag;
                    }
                    else
                    {
                        //拡張検索条件の表示状態を調べて次へ
                        nextCtrl = this.GetBeforeCommonControl("tComboEditor_DeleteFlag");
                    }
                }
                else nextCtrl = null;
            }

            // 入力日開始
            if (controlName == "tDateEdit_AddUpADateSt")
            {
                if (this.tEdit_StockMoveSlipNum.Visible && this.uCheckSalesSlipNum.Checked && this.uCheckSalesSlipNum.Enabled == true) nextCtrl = this.tEdit_StockMoveSlipNum;
                else nextCtrl = GetBeforeControl("tEdit_StockMoveSlipNum");
            }

            // 入力日終了
            if (controlName == "tDateEdit_AddUpADateEd")
            {
                if (this.tDateEdit_AddUpADateSt.Visible && this.uCheckAddUpADateEd.Checked && this.uCheckAddUpADateEd.Enabled == true) nextCtrl = this.tDateEdit_AddUpADateSt;
                else nextCtrl = GetBeforeControl("tDateEdit_AddUpADateSt");
            }

            // 担当者
            if (controlName == "tEdit_SalesEmployeeCd")
            {
                if (this.tDateEdit_AddUpADateEd.Visible && this.uCheckAddUpADateEd.Checked && this.uCheckAddUpADateEd.Enabled == true) nextCtrl = this.tDateEdit_AddUpADateEd;
                else nextCtrl = GetBeforeControl("tDateEdit_AddUpADateEd");
            }

            // 担当者ガイド
            if (controlName == "uButton_SalesEmployeeCd")
            {
                if (this.tEdit_SalesEmployeeCd.Visible && this.uCheckSalesEmployeeCd.Checked && this.uCheckSalesEmployeeCd.Enabled == true) nextCtrl = this.tEdit_SalesEmployeeCd;
                else nextCtrl = GetBeforeControl("tEdit_SalesEmployeeCd");
            }

            // 仕入先
            if (controlName == "tEdit_SupplierCd")
            {
                if (this.tEdit_SalesEmployeeCd.Visible && this.uCheckSalesEmployeeCd.Checked && this.uCheckSalesEmployeeCd.Enabled == true) nextCtrl = this.uButton_SalesEmployeeCd;
                else nextCtrl = GetBeforeControl("tEdit_SalesEmployeeCd");
            }

            // 仕入先ガイド
            if (controlName == "uButton_SupplierCd")
            {
                if (this.tEdit_SupplierCd.Visible && this.uCheckSupplierCd.Checked && this.uCheckSupplierCd.Enabled == true) nextCtrl = this.tEdit_SupplierCd;
                else nextCtrl = GetBeforeControl("tEdit_SupplierCd");
            }

            // メーカーコード
            if (controlName == "tEdit_MakerCd")
            {
                if (this.tEdit_SupplierCd.Visible && this.uCheckSupplierCd.Checked && this.uCheckSupplierCd.Enabled == true) nextCtrl = this.uButton_SupplierCd;
                else nextCtrl = GetBeforeControl("tEdit_SupplierCd");
            }

            // メーカーガイド
            if (controlName == "uButton_MakerCd")
            {
                if (this.tEdit_MakerCd.Visible && this.uCheckGoodsMakerCd.Checked && this.uCheckGoodsMakerCd.Enabled == true) nextCtrl = this.tEdit_MakerCd;
                else nextCtrl = GetBeforeControl("tEdit_MakerCd");
            }

            // BLコード
            if (controlName == "tEdit_BlGoodsCode")
            {
                if (this.tEdit_MakerCd.Visible && this.uCheckGoodsMakerCd.Checked && this.uCheckGoodsMakerCd.Enabled == true) nextCtrl = this.uButton_MakerCd;
                else nextCtrl = GetBeforeControl("tEdit_MakerCd");
            }

            // BLコードガイド
            if (controlName == "uButton_BlGoodsCode")
            {
                if (this.tEdit_BlGoodsCode.Visible && this.uCheckBLGoodsCode.Checked && this.uCheckBLGoodsCode.Enabled == true) nextCtrl = this.tEdit_BlGoodsCode;
                else nextCtrl = GetBeforeControl("tEdit_BlGoodsCode");
            }

            // 品番
            if (controlName == "tEdit_GoodsNo")
            {
                if (this.tEdit_BlGoodsCode.Visible && this.uCheckBLGoodsCode.Checked && this.uCheckBLGoodsCode.Enabled == true) nextCtrl = this.uButton_BlGoodsCode;
                else nextCtrl = GetBeforeControl("tEdit_BlGoodsCode");
            }

            // 品番あいまい条件
            if (controlName == "tComboEditor_GoodsNoFuzzy")
            {
                if (this.tEdit_GoodsNo.Visible && this.uCheckGoodsNo.Checked && this.uCheckGoodsNo.Enabled == true) nextCtrl = this.tEdit_GoodsNo;
                else nextCtrl = GetBeforeControl("tEdit_GoodsNo");
            }

            // 品名
            if (controlName == "tEdit_GoodsName")
            {
                if (this.tEdit_GoodsNo.Visible && this.uCheckGoodsNo.Checked && this.uCheckGoodsNo.Enabled == true) nextCtrl = this.tComboEditor_GoodsNoFuzzy;
                else nextCtrl = GetBeforeControl("tEdit_GoodsNo");
            }

            // 品名あいまい条件
            if (controlName == "tComboEditor_GoodsNameFuzzy")
            {
                if (this.tEdit_GoodsName.Visible && this.uCheckGoodsName.Checked && this.uCheckGoodsName.Enabled == true) nextCtrl = this.tEdit_GoodsName;
                else nextCtrl = GetBeforeControl("tEdit_GoodsName");
            }

            // 棚番
            if (controlName == "tEdit_WarehouseShelfNo")
            {
                if (this.tEdit_GoodsName.Visible && this.uCheckGoodsName.Checked && this.uCheckGoodsName.Enabled == true) nextCtrl = this.tComboEditor_GoodsNameFuzzy;
                else nextCtrl = GetBeforeControl("tEdit_GoodsName");
            }

            // 棚番あいまい条件
            if (controlName == "tComboEditor_WarehouseShelfNoFuzzy")
            {
                if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && this.uCheckWarehouseShelfNo.Checked && this.uCheckWarehouseShelfNo.Enabled == true) nextCtrl = this.tEdit_WarehouseShelfNo;
                else nextCtrl = GetBeforeControl("tEdit_WarehouseShelfNo");
            }

            // 相手拠点
            if (controlName == "tEdit_AfSectionCode")
            {
                if (this.tEdit_WarehouseShelfNo.Visible && this.tEdit_WarehouseShelfNo.Enabled == true && this.uCheckWarehouseShelfNo.Checked && this.uCheckWarehouseShelfNo.Enabled == true) nextCtrl = this.tComboEditor_WarehouseShelfNoFuzzy;
                else nextCtrl = GetBeforeControl("tEdit_WarehouseShelfNo");
            }

            // 相手拠点ガイド
            if (controlName == "uButton_AfSectionCode")
            {
                if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && this.uCheckAfSectionCode.Checked && this.uCheckAfSectionCode.Enabled == true) nextCtrl = this.tEdit_AfSectionCode;
                else nextCtrl = GetBeforeControl("tEdit_AfSectionCode");
            }

            // 相手倉庫
            if (controlName == "tEdit_AfEnterWarehCode")
            {
                if (this.tEdit_AfSectionCode.Visible && this.tEdit_AfSectionCode.Enabled == true && this.uCheckAfSectionCode.Checked && this.uCheckAfSectionCode.Enabled == true) nextCtrl = this.uButton_AfSectionCode;
                else nextCtrl = GetBeforeControl("tEdit_AfSectionCode");
            }

            // 相手倉庫ガイド
            if (controlName == "uButton_AfEnterWarehCode")
            {
                if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && this.uCheckAfEnterWarehCode.Checked && this.uCheckAfEnterWarehCode.Enabled == true) nextCtrl = this.tEdit_AfEnterWarehCode;
                else nextCtrl = GetBeforeControl("tEdit_AfEnterWarehCode");
            }

            // 入荷区分
            if (controlName == "tComboEditor_ArrivalGoodsFlag")
            {
                if (this.tEdit_AfEnterWarehCode.Visible && this.tEdit_AfEnterWarehCode.Enabled == true && this.uCheckAfEnterWarehCode.Checked && this.uCheckAfEnterWarehCode.Enabled == true) nextCtrl = this.uButton_AfEnterWarehCode;
                else nextCtrl = GetBeforeControl("tEdit_AfEnterWarehCode");
            }

            // 備考
            if (controlName == "tEdit_SlipNote")
            {
                if (this.tComboEditor_ArrivalGoodsFlag.Visible && this.uCheckArrivalGoodsFlag.Checked && this.uCheckArrivalGoodsFlag.Enabled == true && this.tComboEditor_ArrivalGoodsFlag.Enabled) nextCtrl = this.tComboEditor_ArrivalGoodsFlag;
                else nextCtrl = GetBeforeControl("tComboEditor_ArrivalGoodsFlag");
            }

            // 備考ガイド
            if (controlName == "uButton_SlipNote")
            {
                if (this.tEdit_SlipNote.Visible && this.uCheckNote.Checked && this.uCheckNote.Enabled == true) nextCtrl = this.tEdit_SlipNote;
                else nextCtrl = GetBeforeControl("tEdit_SlipNote");
            }


            // 備考あいまい条件
            if (controlName == "tComboEditor_SlipNoteFuzzy")
            {
                if (this.tEdit_SlipNote.Visible && this.uCheckNote.Checked && this.uCheckNote.Enabled == true) nextCtrl = this.uButton_SlipNote;
                else nextCtrl = GetBeforeControl("tEdit_SlipNote");
            }

            // 削除指定区分
            if (controlName == "tComboEditor_DeleteFlag")
            {
                if (this.tEdit_SlipNote.Visible && this.uCheckNote.Checked && this.uCheckNote.Enabled == true) nextCtrl = this.tComboEditor_SlipNoteFuzzy;
                else nextCtrl = GetBeforeControl("tEdit_SlipNote");
            }
            return nextCtrl;
        }

        #endregion // 表示されている前のコントロールを取得する

        # region [あいまい検索用テキスト分解処理]
        /// <summary>
        /// あいまい検索用テキスト分解処理
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="searchText"></param>
        /// <param name="fuzzyValue"></param>
        /// <remarks>
        /// <br>Note       : あいまい検索用テキスト分解処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void GetFuzzyInput(string inputValue, out string searchText, out int fuzzyValue)
        {
            if (!string.IsNullOrEmpty(inputValue))
            {
                fuzzyValue = 0;     // コンボボックスの値

                if (!inputValue.Contains("*"))
                {
                    // [*]なし（「と一致」）
                    fuzzyValue = CT_FUZZY_MATCHWITH;
                }
                else if (inputValue.StartsWith("*") && inputValue.EndsWith("*"))
                {
                    // [*]…[*]（「を含む」）
                    fuzzyValue = CT_FUZZY_INCLUDEWITH;
                }
                else if (inputValue.StartsWith("*"))
                {
                    // [*]…（「で終る」）
                    fuzzyValue = CT_FUZZY_ENDWITH;
                }
                else if (inputValue.EndsWith("*"))
                {
                    // …[*]（「で始る」）
                    fuzzyValue = CT_FUZZY_STARTWITH;
                }
                searchText = inputValue.Replace("*", ""); // [*]抜き文字列
            }
            else
            {
                // クリア
                searchText = string.Empty;
                fuzzyValue = 0;
            }
        }
        # endregion

        # region [あいまい検索用テキスト変換処理] 
        /// <summary>
        /// あいまい検索用テキスト変換処理
        /// </summary>
        /// <param name="fuzzyValue"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : あいまい検索用テキスト変換処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private string GetFuzzyInputOnChangeFuzzyValue(int fuzzyValue, string searchValue)
        {
            string fullValue = searchValue;

            switch (fuzzyValue)
            {
                // 完全一致
                case CT_FUZZY_MATCHWITH:
                default:
                    fullValue = searchValue;
                    break;
                // あいまい
                case CT_FUZZY_INCLUDEWITH:
                    fullValue = "*" + searchValue + "*";
                    break;
                // 後方一致
                case CT_FUZZY_ENDWITH:
                    fullValue = "*" + searchValue;
                    break;
                // 前方一致
                case CT_FUZZY_STARTWITH:
                    fullValue = searchValue + "*";
                    break;
            }

            return fullValue;
        }
        # endregion        

        #region 名称取得
        #region 入力拠点
        /// <summary>
        /// 入力拠点名称取得処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 入力拠点名称取得処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool ReadInputSectionCodeAllowZeroName(out string code, out string name)
        {
            // 入力値を取得
            string sectionCode = this.tEdit_InputSectionCode.Text.Trim().PadLeft(2, '0');
            code = sectionCode;
            name = ultraLabel_InputSectionName.Text;

            if (_prevInputValue.InputSectionCode == sectionCode)
            {
                this.tEdit_InputSectionCode.Text = sectionCode;
                return true;
            }

            // 00:全社
            if (sectionCode == "00")
            {
                sectionCode = "00";
                _prevInputValue.InputSectionCode = sectionCode;
                code = sectionCode;
                name = "全社";
                return true;
            }
            else if (!String.IsNullOrEmpty(sectionCode.Trim()))
            {
                // 拠点情報を取得
                SecInfoSet sectionInfo;
                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                // ステータスが正常の場合はUIにセット
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0)
                {

                    code = sectionInfo.SectionCode.TrimEnd();
                    name = sectionInfo.SectionGuideNm.TrimEnd();
                    _prevInputValue.InputSectionCode = code;
                    return true;
                }
                else
                {
                    _isError = true;
                    code = uiSetControl1.GetZeroPadCanceledText("tEdit_InputSectionCode", _prevInputValue.InputSectionCode);
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                name = string.Empty;
                _prevInputValue.InputSectionCode = code;
                return true;
            }
        }
        #endregion

        #region 出庫拠点
        /// <summary>
        /// 出庫拠点名称取得処理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 出庫拠点名称取得処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool ReadSectionCodeAllowZeroName(out string code, out string name)
        {
            // 入力値を取得
            string sectionCode = this.tEdit_SecCd.Text.Trim().PadLeft(2, '0');
            code = sectionCode;
            name = ultraLabel_SecName.Text;

            if (_prevInputValue.SectionCode == sectionCode)
            {
                this.tEdit_SecCd.Text = sectionCode;
                return true;
            }

            // 00:全社
            if (sectionCode == "00")
            {
                sectionCode = "00";
                _prevInputValue.SectionCode = sectionCode;
                code = sectionCode;
                name = "全社";
                return true;
            }
            else if (!String.IsNullOrEmpty(sectionCode.Trim()))
            {
                // 拠点情報を取得
                SecInfoSet sectionInfo;
                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                // ステータスが正常の場合はUIにセット
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0)
                {

                    code = sectionInfo.SectionCode.TrimEnd();
                    name = sectionInfo.SectionGuideNm.TrimEnd();
                    _prevInputValue.SectionCode = code;
                    return true;
                }
                else
                {
                    _isError = true;
                    code = uiSetControl1.GetZeroPadCanceledText("tEdit_SecCd", _prevInputValue.SectionCode);
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                name = string.Empty;
                _prevInputValue.SectionCode = code;
                return true;
            }
        }
        #endregion

        #region 出庫倉庫
        /// <summary>
        /// 倉庫名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <remarks>
        /// <br>Note       : 倉庫名称取得。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool ReadWarehouseName(out string code, out string name)
        {
            // 入力値を取得
            string inputValue = this.tEdit_WarehouseCd.Text.Trim().PadLeft(4, '0');
            code = inputValue;
            name = ultraLabel_WarehouseName.Text;

            // 空でなければ処理開始
            if ("0000".Equals(inputValue))
            {
                code = string.Empty;
                name = string.Empty;
                _prevInputValue.WarehouseCode = code;
                return true;
            }
            else if (!string.IsNullOrEmpty(inputValue))
            {
                try
                {
                    // 入力値が変わっていた場合のみコード変換
                    if (inputValue != _prevInputValue.WarehouseCode)
                    {
                        // コードから名称へ変換
                        Warehouse warehouseInfo;
                        int status = this._warehouseAcs.Read(out warehouseInfo, this._enterpriseCode, string.Empty, inputValue);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && warehouseInfo.LogicalDeleteCode == 0)
                        {
                            code = warehouseInfo.WarehouseCode.Trim();
                            name = warehouseInfo.WarehouseName;
                            _prevInputValue.WarehouseCode = code;
                            return true;
                        }
                        else
                        {
                            _isError = true;
                            // 戻す
                            code = uiSetControl1.GetZeroPadCanceledText(tEdit_WarehouseCd.Name, _prevInputValue.WarehouseCode);
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // 戻す
                    code = uiSetControl1.GetZeroPadCanceledText(tEdit_WarehouseCd.Name, _prevInputValue.WarehouseCode);
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                name = string.Empty;
                _prevInputValue.WarehouseCode = code;
                return true;
            }
        }
        #endregion // 出庫倉庫

        #region 担当者
        /// <summary>
        /// 担当者名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 担当者名称取得。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool ReadSalesEmployeeName(out string code)
        {
            // 入力値を取得
            string inputValue = this.tEdit_SalesEmployeeCd.Text.Trim();
            code = inputValue;

            // 空でなければ処理開始
            if (!string.IsNullOrEmpty(inputValue))
            {
                try
                {
                    // 入力値が変わっていた場合のみコード変換
                    if (inputValue != this._swSalesEmployeeCd)
                    {
                        // コードから名称へ変換
                        Employee employeeInfo;
                        int status = this._employeeAcs.Read(out employeeInfo, this._enterpriseCode, inputValue);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && employeeInfo.LogicalDeleteCode == 0)
                        {
                            this._swSalesEmployeeCd = inputValue;
                            this._swSalesEmployeeName = employeeInfo.Name;
                            code = _swSalesEmployeeCd;
                            return true;
                        }
                        else
                        {
                            _isError = true;
                            // 戻す
                            code = uiSetControl1.GetZeroPadCanceledText(tEdit_SalesEmployeeCd.Name, _swSalesEmployeeCd);
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // 戻す
                    code = uiSetControl1.GetZeroPadCanceledText(tEdit_SalesEmployeeCd.Name, _swSalesEmployeeCd);
                    return false;
                }
            }
            else
            {
                this._swSalesEmployeeCd = string.Empty;
                this._swSalesEmployeeName = string.Empty;
                code = _swSalesEmployeeCd;
                return true;
            }
        }

        /// <summary>
        /// 担当者入力欄Enterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 担当者入力欄Enterイベント。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tEdit_SalesEmployeeCd_Enter(object sender, System.EventArgs e)
        {
            // 担当者コードが保存されていれば置き換え
            if (!String.IsNullOrEmpty(this._swSalesEmployeeCd))
            {
                this.tEdit_SalesEmployeeCd.Text = this._swSalesEmployeeCd.Trim();
            }
        }

        #endregion // 担当者

        #region BLコード 
        /// <summary>
        /// BLコード名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <remarks>
        /// <br>Note       : BLコード名称取得。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool ReadBlCodeName(out int code)
        {
            // 入力値を取得
            int inputValue;
            try
            {
                inputValue = Int32.Parse(this.tEdit_BlGoodsCode.Text.Trim());
            }
            catch
            {
                inputValue = 0;
            }
            code = inputValue;

            // 空でなければ処理開始
            if (inputValue != 0)
            {
                try
                {
                    // 入力値が変わっていた場合のみコード変換
                    if (inputValue != this._swBLGoodsCode)
                    {
                        // コードから名称へ変換
                        BLGoodsCdUMnt blGoodsCd;
                        int status = _blGoodsCdAcs.Read(out blGoodsCd, this._enterpriseCode, inputValue);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && blGoodsCd.LogicalDeleteCode == 0)
                        {
                            this._swBLGoodsCode = inputValue;
                            this._swBLGoodsName = blGoodsCd.BLGoodsHalfName;
                            code = _swBLGoodsCode;
                            return true;
                        }
                        else
                        {
                            _isError = true;
                            // 戻す
                            code = _swBLGoodsCode;
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // 戻す
                    code = _swBLGoodsCode;
                    return false;
                }
            }
            else
            {
                this._swBLGoodsCode = 0;
                this._swBLGoodsName = string.Empty;
                code = _swBLGoodsCode;
                return true;
            }
        }

        /// <summary>
        /// BLコード入力欄Enterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : BLコード入力欄Enterイベント。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tEdit_BlGoodsCode_Enter(object sender, System.EventArgs e)
        {
            // BLコードが保存されていれば置き換え
            if (this._swBLGoodsCode > 0)
            {
                this.tEdit_BlGoodsCode.Text = this._swBLGoodsCode.ToString();
            }

        }

        #endregion

        #region メーカー 
        /// <summary>
        /// メーカー名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <remarks>
        /// <br>Note       : メーカー名称取得。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool ReadGoodsMakerName(out int code)
        {
            // 入力値を取得
            int inputValue;
            try
            {
                inputValue = Int32.Parse(this.tEdit_MakerCd.Text.Trim());
            }
            catch
            {
                inputValue = 0;
            }
            code = inputValue;

            // 空でなければ処理開始
            if (inputValue != 0)
            {
                try
                {
                    // 入力値が変わっていた場合のみコード変換
                    if (inputValue != this._swGoodsMakerCd)
                    {
                        // コードから名称へ変換
                        MakerUMnt makerInfo;
                        int status = this._makerAcs.Read(out makerInfo, this._enterpriseCode, inputValue);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && makerInfo.LogicalDeleteCode == 0)
                        {
                            this._swGoodsMakerCd = inputValue;
                            this._swGoodsMakerName = makerInfo.MakerKanaName;
                            code = _swGoodsMakerCd;
                            return true;
                        }
                        else
                        {
                            _isError = true;
                            // 戻す
                            code = _swGoodsMakerCd;
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // 戻す
                    code = _swGoodsMakerCd;
                    return false;
                }
            }
            else
            {
                this._swGoodsMakerCd = 0;
                this._swGoodsMakerName = string.Empty;
                code = _swGoodsMakerCd;
                return true;
            }
        }

        /// <summary>
        /// メーカー入力欄Enterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : メーカー入力欄Enterイベント。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tEdit_MakerCd_Enter(object sender, System.EventArgs e)
        {
            // メーカーコードが保存されていれば置き換え
            if (this._swGoodsMakerCd > 0)
            {
                this.tEdit_MakerCd.Text = this._swGoodsMakerCd.ToString();
            }
        }

        #endregion // メーカー

        #region 仕入先 
        /// <summary>
        /// 仕入先名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 仕入先名称取得。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool ReadSupplierName(out int code)
        {
            // 入力値を取得
            int inputValue;
            try
            {
                inputValue = Int32.Parse(this.tEdit_SupplierCd.Text.Trim());
            }
            catch
            {
                inputValue = 0;
            }
            code = inputValue;

            // 空でなければ処理開始
            if (inputValue != 0)
            {
                try
                {
                    // 入力値が変わっていた場合のみコード変換
                    if (inputValue != this._swSupplierCd)
                    {
                        // コードから名称へ変換
                        Supplier supplierInfo;
                        int status = this._supplierAcs.Read(out supplierInfo, this._enterpriseCode, inputValue);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplierInfo.LogicalDeleteCode == 0)
                        {
                            this._swSupplierCd = inputValue;
                            // 仕入先マスタ.仕入先略称が入力されていた場合には仕入先マスタ.仕入先略称を表示
                            if (!string.IsNullOrEmpty(supplierInfo.SupplierSnm))
                            {
                                this._swSupplierName = supplierInfo.SupplierSnm;
                            }
                            // 仕入先マスタ.仕入先略称が未入力の場合には仕入先マスタ.仕入先名1を表示
                            else if (!string.IsNullOrEmpty(supplierInfo.SupplierNm1))
                            {
                                this._swSupplierName = supplierInfo.SupplierNm1;
                            }
                            // 仕入先マスタ.仕入先名称1が未入力の場合には仕入先マスタ.仕入先カナを表示
                            else
                            {
                                this._swSupplierName = supplierInfo.SupplierKana;
                            }
                            code = _swSupplierCd;
                            return true;
                        }
                        else
                        {
                            _isError = true;
                            // 戻す
                            code = _swSupplierCd;
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // 戻す
                    code = _swSupplierCd;
                    return false;
                }
            }
            else
            {
                this._swSupplierCd = 0;
                this._swSupplierName = string.Empty;
                code = _swSupplierCd;
                return true;
            }
        }

        /// <summary>
        /// 仕入先入力欄Enterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 仕入先入力欄Enterイベント。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tEdit_SupplierCd_Enter(object sender, System.EventArgs e)
        {
            // 仕入先コードが保存されていれば置き換え
            if (this._swSupplierCd > 0)
            {
                this.tEdit_SupplierCd.Text = this._swSupplierCd.ToString();
            }
        }

        #endregion // 仕入先

        #region 相手拠点 
        /// <summary>
        /// 相手拠点名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <br>Note       : 相手拠点名称取得</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        //private bool ReadAfSectionName(out int code) // DEL 2010/05/18
        private bool ReadAfSectionName(out string code) // ADD 2010/05/18
        {
            // 入力値を取得
            //int inputValue; // DEL 2010/05/18
            string inputValue; // ADD 2010/05/18
            try
            {
                //inputValue = Int32.Parse(this.tEdit_AfSectionCode.Text.Trim()); // DEL 2010/05/18
                inputValue = this.tEdit_AfSectionCode.Text.Trim(); // ADD 2010/05/18
            }
            catch
            {
                //inputValue = 0; // DEL 2010/05/18
                inputValue = string.Empty; // ADD 2010/05/18
            }
            code = inputValue;

            // 空でなければ処理開始
            //if (inputValue != 0) // DEL 2010/05/18
            if (!string.IsNullOrEmpty(inputValue)) // ADD 2010/05/18
            {
                try
                {
                    // 入力値が変わっていた場合のみコード変換
                    if (inputValue != this._swAfSectionCode)
                    {
                        // コードから名称へ変換
                        SecInfoSet sectionInfo;
                        int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, this.tEdit_AfSectionCode.Text.Trim().PadLeft(2, '0'));
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0)
                        {
                            this._swAfSectionCode = inputValue;
                            this._swAfSectionName = sectionInfo.SectionGuideNm;
                            code = _swAfSectionCode;
                            return true;
                        }
                        else
                        {
                            _isError = true;
                            // 戻す
                            code = _swAfSectionCode;
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // 戻す
                    code = _swAfSectionCode;
                    return false;
                }
            }
            else
            {
                //TODO:空場合、[00:全社]を表示する
                //this._swAfSectionCode = 0; // DEL 2010/05/18
                this._swAfSectionCode = string.Empty; // ADD 2010/05/18
                this._swAfSectionName = "全社";
                code = _swAfSectionCode;
                return true;
            }
        }

        /// <summary>
        /// 相手拠点名称Enterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : 相手拠点名称Enterイベント</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private void tEdit_AfSectionCode_Enter(object sender, System.EventArgs e)
        {
            // 相手拠点コードが保存されていれば置き換え
            //if (this._swAfSectionCode > 0) // ADD 2010/05/18
            if (!string.IsNullOrEmpty(this._swAfSectionCode)) // DEL 2010/05/18
            {
                //this.tEdit_AfSectionCode.Text = this._swAfSectionCode.ToString(); // DEL 2010/05/18
                this.tEdit_AfSectionCode.Text = this._swAfSectionCode; // ADD 2010/05/18
            }
        }

        #endregion // 仕入先

        #region 相手倉庫
        /// <summary>
        /// 倉庫名称取得
        /// </summary>
        /// <param name="code"></param>
        /// <br>Note       : 倉庫名称取得</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private bool ReadAfEnterWarehName(out string code)
        {
            // 入力値を取得
            string inputValue;
            try
            {
                inputValue = this.tEdit_AfEnterWarehCode.Text.Trim();
            }
            catch
            {
                inputValue = string.Empty;
            }
            code = inputValue;
            // 空でなければ処理開始
            if (!string.IsNullOrEmpty(inputValue))
            {
                try
                {
                    // 入力値が変わっていた場合のみコード変換
                    if (inputValue != this._swAfEnterWarehCode)
                    {
                        // コードから名称へ変換
                        Warehouse warehouseInfo;
                        //int status = this._warehouseAcs.Read(out warehouseInfo, this._enterpriseCode, string.Empty, inputValue); // DEL 2010/05/18
                        int status = this._warehouseAcs.Read(out warehouseInfo, this._enterpriseCode, string.Empty, this.tEdit_AfEnterWarehCode.Text.Trim().PadLeft(4, '0')); // ADD 2010/05/18
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && warehouseInfo.LogicalDeleteCode == 0)
                        {
                            this._swAfEnterWarehCode = inputValue;
                            this._swAfEnterWarehName = warehouseInfo.WarehouseName;
                            code = _swAfEnterWarehCode;
                            return true;
                        }
                        else
                        {
                            _isError = true;
                            // 戻す
                            code = _swAfEnterWarehCode;
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // 戻す
                    code = _swAfEnterWarehCode;
                    return false;
                }
            }
            else
            {
                this._swAfEnterWarehCode = string.Empty;
                this._swAfEnterWarehName = string.Empty;
                code = _swAfEnterWarehCode;
                return true;
            }
        }

        /// <summary>
        /// 倉庫入力欄Enterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : 倉庫入力欄Enterイベント</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private void tEdit_AfEnterWarehCode_Enter(object sender, System.EventArgs e)
        {
            // 倉庫コードが保存されていれば置き換え
            if (!string.IsNullOrEmpty(this._swAfEnterWarehCode))
            {
                this.tEdit_AfEnterWarehCode.Text = this._swAfEnterWarehCode;
            }
        }

        #endregion // 相手倉庫
        #endregion // 名称取得                

        /// <summary>
        /// 日付範囲チェック処理（伝票・明細抽出の売上日付・入力日付用）
        /// </summary>
        /// <param name="stEdit"></param>
        /// <param name="edEdit"></param>
        /// <param name="result"></param>
        /// <param name="allowNoInput"></param>
        /// <returns></returns>
        /// <br>Note       : 日付範囲チェック処理</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private bool CheckDateRangeForSlip(ref TDateEdit stEdit, ref TDateEdit edEdit, out DateGetAcs.CheckDateRangeResult result, bool allowNoInput)
        {
            int range = 3;
            if (allowNoInput) range = 0;

            result = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, range, ref stEdit, ref edEdit, allowNoInput);
            return (result == DateGetAcs.CheckDateRangeResult.OK);
        }

        #region ■オプション情報制御処理

        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オプション情報キャッシュ。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/11 tianjw</br>
        /// <br>             redmine #20966</br>
        /// <br></br>
        /// </remarks>
        private void CacheOptionInfo()
        {
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
            #region[テキスト出力、Excel出力]
            //テキスト出力オプションが有効の場合
            if (this._opt_TextOutput == (int)Option.ON)
            {
                // テキスト出力セキュリティ権限
                if (OpeAuthDictionary[OperationCode.TextOut])
                {
                    // テキスト出力
                    this.tToolbarsManager.Tools["ButtonTool_ExtractText"].SharedProps.Visible = true;
                    //設定画面のテキスト出力タブを表示する
                    this._settingForm.uTabControlSet(true);
                }
                else
                {
                    // テキスト出力
                    this.tToolbarsManager.Tools["ButtonTool_ExtractText"].SharedProps.Visible = false;
                    //設定画面のテキスト出力タブを表示する
                    this._settingForm.uTabControlSet(false);
                }
                // EXCEL出力セキュリティ権限
                if (OpeAuthDictionary[OperationCode.ExcelOut])
                {
                    // EXCEL出力
                    this.tToolbarsManager.Tools["ButtonTool_ExtractExcel"].SharedProps.Visible = true;
                    //設定画面のテキスト出力タブを表示する
                    //this._settingForm.uTabControlSet(true); // DEL 2011/05/11 tianjw
                }
                else
                {
                    // EXCEL出力
                    this.tToolbarsManager.Tools["ButtonTool_ExtractExcel"].SharedProps.Visible = false;
                    //設定画面のテキスト出力タブを表示する
                    //this._settingForm.uTabControlSet(false); // DEL 2011/05/11 tianjw
                }
            }
            //テキスト出力オプションが無効の場合
            else
            {
                // テキスト出力
                this.tToolbarsManager.Tools["ButtonTool_ExtractText"].SharedProps.Visible = false;
                // EXCEL出力
                this.tToolbarsManager.Tools["ButtonTool_ExtractExcel"].SharedProps.Visible = false;
                //設定画面のテキスト出力タブを表示する
                this._settingForm.uTabControlSet(false);
            }
            #endregion

            #endregion

            //if (!OpeAuthDictionary[OperationCode.ReissueSlip])
            //{
            //    this.tToolbarsManager.Tools["ButtonTool_ReissueSlip"].SharedProps.Visible = false;
            //    this.tToolbarsManager.Tools["ButtonTool_ReissueSlip"].SharedProps.Shortcut = Shortcut.None;
            //}

        }
        #endregion ■オプション情報制御処理
    
    　　/// <summary>
        /// 明細表示設定初期化イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 明細表示設定初期化イベント処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void SettingForm_ClearSettingStockMoveGrid(object sender, EventArgs e)
        {
            InitializeGridColumns(this.uGrid_StockMove.DisplayLayout.Bands[0].Columns);
            LoadGridColumnsSetting(ref uGrid_StockMove, _settingForm.UserSetting.StockMoveColumnsList);

            autoColumnAdjust(this._columnWidthAutoAdjust);
        }

        /// <summary>
        /// グリッドカラム情報の読み込み
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        /// <remarks>
        /// <br>Note       : グリッドカラム情報の読み込み。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void LoadGridColumnsSetting(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, List<ColumnInfo> settingList)
        {
            if (settingList == null || settingList.Count == 0) return;

            targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            // カラム設定情報を表示順でソートする
            settingList.Sort(new ColumnInfoComparer());

            // 一度、全てのカラムのFixedを解除する
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                ultraGridColumn.Header.Fixed = false;
            }

            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Header.VisiblePosition = columnInfo.VisiblePosition;

                    if (this._stockMoveFixCode == 1)
                    {
                        switch (columnInfo.ColumnName)
                        {
                            case "StockMoveFormalDisplay":
                            case "UpdateSecCd":
                            case "UpdateSecGuideSnm":
                                {
                                    ultraGridColumn.Hidden = true;
                                    break;
                                }
                            default:
                                {
                                    ultraGridColumn.Hidden = columnInfo.Hidden;
                                    break;
                                } 
                        }
                    }
                    else
                    {
                        switch (columnInfo.ColumnName)
                        {
                            case "MoveStatus":
                            case "ShipmentFixDay":
                            case "ArrivalGoodsDay":
                                {
                                    ultraGridColumn.Hidden = true;
                                    break;
                                }
                            default:
                                {
                                    ultraGridColumn.Hidden = columnInfo.Hidden;
                                    break;
                                } 
                        }
                    }

                    ultraGridColumn.Width = columnInfo.Width;
                }
                catch
                {
                }
            }

            // 列並び換え後、まとめてFixedを設定する。
            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Header.Fixed = columnInfo.ColumnFixed;
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// グリッド列の初期化
        /// </summary>
        /// <param name="Columns"></param>
        /// <remarks>
        /// <br>Note       : グリッド列の初期化。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br>Update Note: 2011/05/20 朱俊成 仕入先と仕入先名を追加します</br>
        /// </remarks>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            // 表示形式のある列で使用
            string formatCurrency = "#,##0;-#,##0;";
            string formatFraction = "#,##0.00;-#,##0.00;";
            string formatDate = "yyyy/MM/dd";
            string formatSlipNo = "000000000";
            string formatSectionCode = "0#";
            string formatWarehCode = "000#";

            // 表示位置初期値
            int visiblePosition = 1;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
                column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                column.AutoEdit = false;
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                column.ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
                column.Header.Fixed = false;
            }

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------

            // 選択チェックボックス
            // カラムチューザ：対象外　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Hidden = false;

            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Width = 50;

            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;

            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Header.Caption = "選択";

            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].CellAppearance.BackColor = _margedCellAppearance.BackColor;
            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].CellAppearance.BackColor2 = _margedCellAppearance.BackColor2;
            Columns[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Header.Fixed = true;

            // 行No
            // 非表示
            // カラムチューザ：対象外　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.RowNoColumn.ColumnName].Hidden = true;
            Columns[this._stockMoveDataSet.StockMoveDetail.RowNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;

            // 伝票日付
            // カラムチューザ：対象　　フォーマット：日付（yyyy/mm/dd）
            Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Format = formatDate;
            Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            // 在庫移動確定区分＝入荷確定ありの場合
            if (this._stockMoveFixCode == 1)
            {
                if (this._stockMoveDataSet.StockMoveDetail.Rows.Count == 0) {
                    Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = this.uLabel_DateTitle.Text;
                }
            }
            // 在庫移動確定区分＝入荷確定なしの場合
            else if (this._stockMoveFixCode == 2)
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Caption = "伝票日付";
            }
            Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName].Header.Fixed = true;
            SettingMergedCell(Columns[this._stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName]);

            // 伝票番号
            // カラムチューザ：対象　　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].Format = formatSlipNo;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].Header.Caption = "伝票番号";
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName].Header.Fixed = true;
            SettingMergedCell(Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName]);


            // 行No
            // カラムチューザ：対象　　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName].Width = 40;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName].Header.Caption = "行No";
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveRowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 区分コード
            // カラムチューザ：対象外　フォーマット：非表示
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalCdColumn.ColumnName].Hidden = true;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;

            // 区分表示
            // カラムチューザ：対象　　フォーマット：通常
            if (this._stockMoveFixCode == 1)
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].Hidden = true;
                Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
            }
            // 在庫移動確定区分＝入荷確定なしの場合
            else
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].Hidden = false;
                Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            }
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].Width = 70;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].Header.Caption = "区分";
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 担当者名
            // カラムチューザ：対象　　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.AgentNmColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.AgentNmColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.AgentNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.AgentNmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.AgentNmColumn.ColumnName].Header.Caption = "担当者名";
            Columns[this._stockMoveDataSet.StockMoveDetail.AgentNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.AgentNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 品名
            // カラムチューザ：対象　　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNameColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNameColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNameColumn.ColumnName].Header.Caption = "品名";
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 品番
            // カラムチューザ：対象　　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNoColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNoColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNoColumn.ColumnName].Header.Caption = "品番";
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // メーカーコード
            // カラムチューザ：対象　　フォーマット：数値だが表示は通常
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName].Header.Caption = "メーカーコード";
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._stockMoveDataSet.StockMoveDetail.GoodsMakerCdColumn.ColumnName].Format = GetMakerFormat();

            // メーカー
            // カラムチューザ：対象　　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.MakerNameColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.MakerNameColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.MakerNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.MakerNameColumn.ColumnName].Header.Caption = "メーカー名";
            Columns[this._stockMoveDataSet.StockMoveDetail.MakerNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            
            // ADD 2011/05/20 -------------------------------->>>>>>
            // 仕入先コード
            // カラムチューザ：対象　　フォーマット：数値だが表示は通常
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName].Header.Caption = "仕入先コード";
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierCdColumn.ColumnName].Format = GetFormat("tEdit_SupplierCd");

            // メーカー
            // カラムチューザ：対象　　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierSnmColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierSnmColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierSnmColumn.ColumnName].Header.Caption = "仕入先名";
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // ADD 2011/05/20 --------------------------------<<<<<<

            // BLコード
            // カラムチューザ：対象　　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName].Width = 90;
            Columns[this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName].Header.Caption = "BLｺｰﾄﾞ";
            Columns[this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._stockMoveDataSet.StockMoveDetail.BLGoodsCodeColumn.ColumnName].Format = GetBLCodeFormat();

            // 移動単価
            // カラムチューザ：対象　　フォーマット：金額
            Columns[this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName].Format = formatFraction;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName].Header.Caption = "移動単価";
            Columns[this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockUnitPriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 数量
            // カラムチューザ：対象　　フォーマット：数値
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName].Width = 70;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName].Format = formatFraction;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName].Header.Caption = "数量";
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveCounColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 標準価格
            // カラムチューザ：対象　　フォーマット：金額
            Columns[this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName].Format = formatCurrency;
            Columns[this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName].Header.Caption = "標準価格";
            Columns[this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.ListPriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 移動金額（明細）
            // カラムチューザ：対象　　フォーマット：金額
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName].Format = formatCurrency;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName].Header.Caption = "移動金額";
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.StockMovePriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 入力拠点コード
            // カラムチューザ：対象外　フォーマット：コード
            if (this._stockMoveFixCode == 1)
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].Hidden = true;
                Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
            }
            // 在庫移動確定区分＝入荷確定なしの場合
            else
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].Hidden = false;
                Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            }
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].Format = formatSectionCode;
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].Header.Caption = "入力拠点コード";
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;


            // 入力拠点名
            // カラムチューザ：対象　　フォーマット：文字列
            if (this._stockMoveFixCode == 1)
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].Hidden = true;
                Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
            }
            // 在庫移動確定区分＝入荷確定なしの場合
            else
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].Hidden = false;
                Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            }
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].Header.Caption = "入力拠点名";
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.UpdateSecGuideSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 出庫拠点コード
            // カラムチューザ：対象外　フォーマット：コード
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName].Format = formatSectionCode;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName].Header.Caption = "出庫拠点コード";
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 出庫拠点名
            // カラムチューザ：対象　　フォーマット：文字列
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName].Header.Caption = "出庫拠点名";
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfSectionGuideSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 出庫倉庫コード
            // カラムチューザ：対象　　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName].Format = formatWarehCode;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName].Header.Caption = "出庫倉庫";
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 出庫倉庫名
            // カラムチューザ：対象　　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName].Header.Caption = "出庫倉庫名";
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfEnterWarehNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 出庫棚番
            // カラムチューザ：対象　　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.BfShelfNoColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfShelfNoColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfShelfNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfShelfNoColumn.ColumnName].Header.Caption = "出庫棚番";
            Columns[this._stockMoveDataSet.StockMoveDetail.BfShelfNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.BfShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 入庫拠点コード
            // カラムチューザ：対象外　フォーマット：コード
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName].Format = formatSectionCode;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName].Header.Caption = "入庫拠点コード";
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionCodColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 入庫拠点名
            // カラムチューザ：対象　　フォーマット：文字列
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName].Width = 80;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName].Header.Caption = "入庫拠点名";
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfSectionGuideSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 入庫倉庫コード
            // カラムチューザ：対象　　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName].Format = formatWarehCode;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName].Header.Caption = "入庫倉庫";
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 入庫倉庫名
            // カラムチューザ：対象　　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName].Header.Caption = "入庫倉庫名";
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfEnterWarehNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 入庫棚番
            // カラムチューザ：対象　　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.AfShelfNoColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfShelfNoColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfShelfNoColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfShelfNoColumn.ColumnName].Header.Caption = "入庫棚番";
            Columns[this._stockMoveDataSet.StockMoveDetail.AfShelfNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.AfShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 入荷区分
            // カラムチューザ：対象　　フォーマット：通常
            if (this._stockMoveFixCode == 1)
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].Hidden = false;
                Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            }
            // 在庫移動確定区分＝入荷確定なしの場合
            else
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].Hidden = true;
                Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
            }
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].Header.Caption = "入荷区分";
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.MoveStatusColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 出荷日
            // カラムチューザ：対象　　フォーマット：日付（yyyy/mm/dd）
            if (this._stockMoveFixCode == 1)
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].Hidden = false;
                Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            }
            // 在庫移動確定区分＝入荷確定なしの場合
            else
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].Hidden = true;
                Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
            }
            Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].Format = formatDate;
            Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].Header.Caption = "出荷日";
            Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.ShipmentFixDayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 入荷日
            // カラムチューザ：対象　　フォーマット：日付（yyyy/mm/dd）
            if (this._stockMoveFixCode == 1)
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].Hidden = false;
                Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            }
            // 在庫移動確定区分＝入荷確定なしの場合
            else
            {
                Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].Hidden = true;
                Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.True;
            }
            Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].Format = formatDate;
            Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].Header.Caption = "入荷日";
            Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.ArrivalGoodsDayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 入力日
            // カラムチューザ：対象　　フォーマット：日付（yyyy/mm/dd）
            Columns[this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName].Format = formatDate;
            Columns[this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName].Header.Caption = "入力日";
            Columns[this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.InputDayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 備考
            // カラムチューザ：対象　　フォーマット：通常
            Columns[this._stockMoveDataSet.StockMoveDetail.WarehouseNote1Column.ColumnName].Hidden = false;
            Columns[this._stockMoveDataSet.StockMoveDetail.WarehouseNote1Column.ColumnName].Width = 100;
            Columns[this._stockMoveDataSet.StockMoveDetail.WarehouseNote1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._stockMoveDataSet.StockMoveDetail.WarehouseNote1Column.ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this._stockMoveDataSet.StockMoveDetail.WarehouseNote1Column.ColumnName].Header.Caption = "備考";
            Columns[this._stockMoveDataSet.StockMoveDetail.WarehouseNote1Column.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._stockMoveDataSet.StockMoveDetail.WarehouseNote1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

            //--------------------------------------------------------------------------------
            //  カラムチューザを有効にする
            //--------------------------------------------------------------------------------
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton;
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorWidth = 24;
            _gridColumnChooserControl.Add(this.uGrid_StockMove);

            // カラムチューザボタンの外観を設定		
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = GradientStyle.Vertical;
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = this.uGrid_StockMove.DisplayLayout.Override.RowSelectorAppearance.BackColor;
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor2 = this.uGrid_StockMove.DisplayLayout.Override.RowSelectorAppearance.BackColor2;
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorHeaderAppearance.BackGradientStyle = this.uGrid_StockMove.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle;
            this.uGrid_StockMove.ImageList = Broadleaf.Library.Resources.IconResourceManagement.ImageList16;
            this.uGrid_StockMove.DisplayLayout.Override.RowSelectorHeaderAppearance.Image = (int)Broadleaf.Library.Resources.Size16_Index.STAR1;

            // 列幅自動調整を設定値にしたがって行う
            autoColumnAdjust(_columnWidthAutoAdjust);

        }

        /// <summary>
        /// セル結合設定処理
        /// </summary>
        /// <param name="column"></param>
        /// <remarks>
        /// <br>Note       : セル結合設定処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void SettingMergedCell(Infragistics.Win.UltraWinGrid.UltraGridColumn column)
        {
            //--------------------------------------------------
            // CellAppearanceを強制的に統一する
            //--------------------------------------------------
            column.MergedCellAppearance = _margedCellAppearance;
            column.CellAppearance.BackColor = _margedCellAppearance.BackColor;
            column.CellAppearance.BackColor2 = _margedCellAppearance.BackColor2;
            column.CellAppearance.TextVAlign = VAlign.Top;

            //--------------------------------------------------
            // セル結合設定
            //--------------------------------------------------
            column.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            column.MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameText;
            column.MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;

            // セル結合判定クラス
            CustomMergedCellEvaluator customMergedCellEvaluator = new CustomMergedCellEvaluator();

            if (column.Key == _stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName)
            {
                // 日付
                customMergedCellEvaluator.JoinColList.Add(_stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName);
            }
            else
            {
                // 伝票番号
                customMergedCellEvaluator.JoinColList.Add(_stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName);
                // (伝票区分)
                customMergedCellEvaluator.JoinColList.Add(_stockMoveDataSet.StockMoveDetail.StockMoveFormalDisplayColumn.ColumnName);
            }
            column.MergedCellEvaluator = customMergedCellEvaluator;
        }

        # region [グリッドセル結合判定クラス]
        /// <summary>
        /// グリッドセル結合判定クラス(カスタマイズ)
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドセル結合判定クラス(カスタマイズ)。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private class CustomMergedCellEvaluator : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
        {
            /// <summary>結合条件セルリスト</summary>
            private List<string> _joinColList;
            /// <summary>
            /// 結合条件セルリスト
            /// </summary>
            public List<string> JoinColList
            {
                get { return _joinColList; }
                set { _joinColList = value; }
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public CustomMergedCellEvaluator()
            {
                _joinColList = new List<string>();
            }

            /// <summary>
            /// セル結合判定処理
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="column"></param>
            /// <returns></returns>
            /// <remarks>
            /// <br>Note       : セル結合判定処理。</br>
            /// <br>Programmer : 高峰</br>
            /// <br>Date       : 2011/04/06</br>
            /// <br></br>
            /// </remarks>
            public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
            {
                foreach (string joinColName in JoinColList)
                {
                    if (!EqualCellValue(row1, row2, joinColName)) return false;
                }
                return true;
            }
            /// <summary>
            /// セルValue比較処理
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="columnName"></param>
            /// <returns></returns>
            /// <remarks>
            /// <br>Note       : セルValue比較処理。</br>
            /// <br>Programmer : 高峰</br>
            /// <br>Date       : 2011/04/06</br>
            /// <br></br>
            /// </remarks>
            private bool EqualCellValue(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, string columnName)
            {
                return (row1.Cells[columnName].Value.ToString() == row2.Cells[columnName].Value.ToString());
            }
        }
        # endregion

        # region [コードフォーマット取得処理]
        /// <summary>
        /// メーカーコードフォーマット取得
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : メーカーコードフォーマット取得。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private string GetMakerFormat()
        {
            return GetFormat("tNedit_GoodsMakerCd");
        }
        /// <summary>
        /// ＢＬコードフォーマット取得
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＢＬコードフォーマット取得。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private string GetBLCodeFormat()
        {
            return GetFormat("tNedit_BLGoodsCode");
        }
        /// <summary>
        /// 汎用フォーマット取得処理
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 汎用フォーマット取得処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private string GetFormat(string editName)
        {
            string format = string.Empty;

            UiSet uiset;
            this.uiSetControl1.ReadUISet(out uiset, editName);
            if (uiset != null)
            {
                format = string.Format("{0};-{0};''", new string('0', uiset.Column));
            }

            return format;
        }
        # endregion        

        /// <summary>
        /// ボタンの有効/無効切替
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタンの有効/無効切替。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void adjustButtonEnable()
        {
            #region 明細一覧

            if (this._stockMoveDataSet != null)
            {
                DataRow[] dataRow = this._stockMoveDataSet.StockMoveDetail.Select("SelectionCheck = true");
                //DataRow[] dataRow = ((DataView)this.uGrid_StockMove.DataSource).Table.Select("SelectionCheck = true");

                if (dataRow.Length == 0)
                {
                    // 伝票再発行
                    this.tToolbarsManager.Tools["ButtonTool_ReissueSlip"].SharedProps.Enabled = false;
                }
                else
                {
                    // 伝票再発行
                    this.tToolbarsManager.Tools["ButtonTool_ReissueSlip"].SharedProps.Enabled = true;
                }
            }

            if (this._stockMoveDataSet != null && this._stockMoveDataSet.StockMoveDetail.Rows.Count > 0)
            {
                // テキスト出力
                this.tToolbarsManager.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = true;
                // EXCEL出力
                this.tToolbarsManager.Tools["ButtonTool_ExtractExcel"].SharedProps.Enabled = true;
                // 行検索文字列
                this.tToolbarsManager.Tools["TextBoxTool_SearchWord"].SharedProps.Enabled = true;
                // 検索列
                this.tToolbarsManager.Tools["ComboBoxTool_TargetColumn"].SharedProps.Enabled = true;
                // 行検索ボタン
                this.tToolbarsManager.Tools["ButtonTool_RowSearchStart"].SharedProps.Enabled = true;
            }
            else
            {
                // テキスト出力
                this.tToolbarsManager.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = false;
                // EXCEL出力
                this.tToolbarsManager.Tools["ButtonTool_ExtractExcel"].SharedProps.Enabled = false;
                // 行検索文字列
                this.tToolbarsManager.Tools["TextBoxTool_SearchWord"].SharedProps.Enabled = false;
                // 検索列
                this.tToolbarsManager.Tools["ComboBoxTool_TargetColumn"].SharedProps.Enabled = false;
                // 行検索ボタン
                this.tToolbarsManager.Tools["ButtonTool_RowSearchStart"].SharedProps.Enabled = false;
            }

            #endregion // 明細一覧
        }

        /// <summary>
        /// 現在ソート中カラム取得処理
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 現在ソート中カラム取得処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private string GetSortingColumns(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            string sortText = string.Empty;
            bool firstCol = true;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in grid.DisplayLayout.Bands[0].SortedColumns)
            {
                if (firstCol == false)
                {
                    sortText += ",";
                }

                // 列名を取得
                sortText += ultraGridColumn.Key;

                // 列のソート方向(昇順,降順)を取得
                if (ultraGridColumn.SortIndicator == Infragistics.Win.UltraWinGrid.SortIndicator.Ascending)
                {
                    sortText += " ASC";
                }
                else
                {
                    sortText += " DESC";
                }

                firstCol = false;
            }

            return sortText;
        }

        #region クリックイベント

        /// <summary>
        /// 伝票明細グリッド クリックイベント
        /// </summary>
        /// <param name="sender">グリッドオブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 伝票明細グリッド クリックイベント。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_StockMove_Click(object sender, System.EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;


            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElementを取得
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // 列ヘッダクリックかどうかを判定
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));
            if (objHeader != null) return;

            // 行クリックかどうかを判定
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));
            if (objRow == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
              (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

            // 選択チェック
            if (objCell == objRow.Cells[this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName])
            {
                RowSelectClicked(null, objRow);
            }
        }

        /// <summary>
        /// 選択チェックボックス クリック処理
        /// </summary>
        /// <param name="checkValue"></param>
        /// <param name="gridRow"></param>
        /// <remarks>
        /// <br>Note       : 選択チェックボックス クリック処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void RowSelectClicked(object checkValue, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            // 関数呼び出しに使用する変数
            string tableName = string.Empty;
            string selectionColName = string.Empty;
            string rowNoColName = string.Empty;

            // 対象とするグリッドの各カラム名を取得
            selectionColName = this._stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName;
            rowNoColName = this._stockMoveDataSet.StockMoveDetail.RowNoColumn.ColumnName;
            tableName = "StockMoveDetail";

            if (gridRow.Cells[selectionColName].Value == DBNull.Value) return; 
            // 選択チェックボックスの値を取得
            bool newSelectedValue = !(bool)gridRow.Cells[selectionColName].Value;

            if (checkValue != null)
            {
                newSelectedValue = (bool)checkValue;
            }

            // 行を取得（RowNoカラムがキー設定されている）
            DataRow row = this._stockMoveDataSet.Tables[tableName].Rows.Find((int)gridRow.Cells[rowNoColName].Value);
            if (!gridRow.Cells[selectionColName].Hidden)
            {
                row[selectionColName] = newSelectedValue;

                // 背景色変更メソッド
                RowBackColorChange(newSelectedValue, gridRow);

                this.adjustButtonEnable();
            }

            // グリッドを更新
            this.uGrid_StockMove.Refresh();
        }



        #endregion // クリックイベント

        #region 行の背景色変更処理(伝票区分ごとの前景色・背景色)

        /// <summary>
        /// 行の背景色変更処理(伝票区分ごとの前景色・背景色)
        /// </summary>
        /// <param name="isSelected">bool 選択されている</param>
        /// <param name="gridRow">行オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 行の背景色変更処理(伝票区分ごとの前景色・背景色)。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void RowBackColorChange(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            if (gridRow == null) return;

            Infragistics.Win.Appearance cellApp = new Infragistics.Win.Appearance();
            cellApp.ForeColor = Color.Black; // 初期化

            if (isSelected)
            {
                // 明細一覧用の色を設定
                cellApp.BackColor = _selectedRowBackColor_Detail;
                cellApp.BackColor2 = _selectedRowBackColor2_Detail;

                // グラデーションを設定
                cellApp.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            }
            else
            {
                // 背景色を標準の配色に戻す
                cellApp.BackColor = Color.White;
                cellApp.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            }

            foreach (Infragistics.Win.UltraWinGrid.UltraGridCell cell in gridRow.Cells)
            {
                if (cell.Column.Key == _stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName ||
                     cell.Column.Key == _stockMoveDataSet.StockMoveDetail.DateColumn.ColumnName ||
                     cell.Column.Key == _stockMoveDataSet.StockMoveDetail.StockMoveSlipNoColumn.ColumnName)
                {
                    continue;
                }
                cell.Appearance.BackColor = cellApp.BackColor;
                cell.Appearance.BackColor2 = cellApp.BackColor2;
                cell.Appearance.BackGradientStyle = cellApp.BackGradientStyle;
                cell.Appearance.ForeColor = cellApp.ForeColor;
            }
        }

        #endregion // 行の背景色変更処理(伝票区分ごとの前景色・背景色)               

        # region [フォームクローズ前処理]
        /// <summary>
        /// フォームクローズ前処理
        /// </summary>
        /// <remarks>FormClosingイベントだと×ボタン時に抜けてしまうので、Parentでウィンドウメッセージを扱う</remarks>
        /// <remarks>
        /// <br>Note       : フォームクローズ前処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        public void BeforeFormClose()
        {
            //-----------------------------------------
            // フォームを閉じる時(×ボタンも含む)
            //-----------------------------------------
            // ユーザー設定保存(→XML書き込み)
            SaveSettings();
        }
        /// <summary>
        /// ユーザー設定保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザー設定保存処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void SaveSettings()
        {
            // グループの展開状態を保存する
            # region [グループ展開状態]
            _settingForm.UserSetting.BalanceChartExpanded = uExGroupBox_BalanceChart.Expanded;
            _settingForm.UserSetting.ExtraConditionExpanded = uExGroupBox_ExtraCondition.Expanded;
            # endregion

            // 詳細条件のチェック状態を保存する
            # region [詳細条件]
            List<string> cndtnList = new List<string>();
            List<string> enableList = new List<string>();
            // 抽出条件選択パネル内の全てのコントロールに対して処理
            foreach (Control control in panel_SelectItem.Controls)
            {
                if (control is Infragistics.Win.UltraWinEditors.UltraCheckEditor)
                {
                    // チェックが付いているチェックボックスの名称をリストに追加
                    if ((control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked)
                    {
                        cndtnList.Add(control.Name);
                    }
                    // チェックがEnableているチェックボックスの名称をリストに追加
                    if ((control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Enabled == false)
                    {
                        enableList.Add(control.Name);
                    }
                }

            }
            _settingForm.UserSetting.EnabledConditionList = cndtnList;
            _settingForm.UserSetting.EnabledList = enableList;

            # endregion

            // 基本条件のチェック状態を保存する
            # region [基本条件]
            List<string> commonCndtnList = new List<string>();

            // 抽出条件選択パネル内の全てのコントロールに対して処理
            foreach (Control control in panel_Base.Controls)
            {
                if (control is Infragistics.Win.UltraWinEditors.UltraCheckEditor)
                {
                    // チェックが付いているチェックボックスの名称をリストに追加
                    if ((control as Infragistics.Win.UltraWinEditors.UltraCheckEditor).Checked)
                    {
                        commonCndtnList.Add(control.Name);
                    }
                }
            }
            _settingForm.UserSetting.EnabledCommonConditionList = commonCndtnList;

            # endregion

            // グリッドのカラム情報を保存する
            # region [グリッドカラム]
            // グリッド
            List<ColumnInfo> stockMoveColumnsList;
            this.SaveGridColumnsSetting(uGrid_StockMove, out stockMoveColumnsList);
            _settingForm.UserSetting.StockMoveColumnsList = stockMoveColumnsList;
            # endregion

            // グリッドのカラムサイズ自動調整状態を保存する
            # region  [グリッドカラム自動調整]
            // グリッド
            _settingForm.UserSetting.AutoAdjustStockMove = _columnWidthAutoAdjust;
            # endregion

            if (this.tComboEditor_OutputDiv.Visible)
            {
                _settingForm.UserSetting.OutPutDiv = this.tComboEditor_OutputDiv.SelectedIndex;
            }
            if (this.tComboEditor_SalesSlipDiv.Visible)
            {
                _settingForm.UserSetting.SalesSlipDiv = this.tComboEditor_SalesSlipDiv.SelectedIndex;
            }
            // 設定保存
            _settingForm.Serialize();
        }
        # endregion

        # region [グリッドカラム情報 保存・復元]
        /// <summary>
        /// グリッドカラム情報の保存
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        /// <remarks>
        /// <br>Note       : グリッドカラム情報の保存。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void SaveGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, out List<ColumnInfo> settingList)
        {
            settingList = new List<ColumnInfo>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                settingList.Add(new ColumnInfo(ultraGridColumn.Key, ultraGridColumn.Header.VisiblePosition, ultraGridColumn.Hidden, ultraGridColumn.Width, ultraGridColumn.Header.Fixed));
            }
        }
        
        # endregion        

        #region 全ての入力欄をクリア

        /// <summary>
        /// 全ての入力欄をクリアします
        /// </summary>
        /// <remarks>
        /// <br>Note       : 全ての入力欄をクリアします。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void ClearAllField()
        {
            // 合計表示部エリア
            this.uLabel_Count1.Text = string.Empty;
            this.uLabel_Count2.Text = string.Empty;
            this.uLabel_Count3.Text = string.Empty;

            this.uLabel_Cost1.Text = string.Empty;
            this.uLabel_Cost2.Text = string.Empty;
            this.uLabel_Cost3.Text = string.Empty;

            this.uLabel_Money1.Text = string.Empty;
            this.uLabel_Money2.Text = string.Empty;
            this.uLabel_Money3.Text = string.Empty;

            this.uLabel_SlipCount.Text = string.Empty;
            this.uLabel_DetailCount.Text = string.Empty;
        }

        #endregion // 全ての入力欄をクリア

        /// <summary>
        /// 詳細条件のクリア
        /// </summary>
        /// <remarks>
        /// <br>Note       : 詳細条件のクリア。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void ClearExtraConditions()
        {
            # region [ＵＩ入力値のクリア]
            // 詳細条件パネル内の全コントロールに対して処理する
            foreach (Control targetControl in this.ultraExpandableGroupBoxPanel2.Controls)
            {
                if (targetControl is TNedit)
                {
                    // 内容クリア
                    (targetControl as TNedit).Clear();
                }
                else if (targetControl is TEdit)
                {
                    // 内容クリア
                    (targetControl as TEdit).Text = string.Empty;
                }
                else if (targetControl is TComboEditor)
                {
                    if (targetControl.Name != "tComboEditor_ArrivalGoodsFlag")
                    {
                        // 先頭アイテムを選択
                        (targetControl as TComboEditor).SelectedIndex = 0;
                    }
                    else
                    {
                        (targetControl as TComboEditor).SelectedIndex = this.tComboEditor_OutputDiv.SelectedIndex;
                    }
                }
                else if (targetControl is TDateEdit)
                {
                    // 内容クリア
                    (targetControl as TDateEdit).Clear();
                }
            }

            foreach (Control targetControl in this.ultraExpandableGroupBoxPanel1.Controls)
            {
                if (targetControl.Name != "tComboEditor_OutputDiv" && targetControl.Name != "tComboEditor_SalesSlipDiv" &&
                    targetControl.Name != "tEdit_InputSectionCode" && targetControl.Name != "tEdit_SecCd"
                    && targetControl.Name != "tEdit_WarehouseCd" && targetControl.Name != "tDateEdit_DateSt"
                    && targetControl.Name != "tDateEdit_DateEd")
                {
                    if (targetControl is TNedit)
                    {
                        // 内容クリア
                        (targetControl as TNedit).Clear();
                    }
                    else if (targetControl is TEdit)
                    {
                        // 内容クリア
                        (targetControl as TEdit).Text = string.Empty;
                    }
                    else if (targetControl is TComboEditor)
                    {
                        if (targetControl.Name != "tComboEditor_ArrivalGoodsFlag")
                        {
                            // 先頭アイテムを選択
                            (targetControl as TComboEditor).SelectedIndex = 0;
                        }
                        else
                        {
                            (targetControl as TComboEditor).SelectedIndex = this.tComboEditor_OutputDiv.SelectedIndex;
                        }
                    }
                    else if (targetControl is TDateEdit)
                    {
                        // 内容クリア
                        (targetControl as TDateEdit).Clear();
                    }
                }
            }

            # endregion

            # region [退避値のクリア]
            // **** あいまい検索を行う項目用 ****
            _srSlipNote = string.Empty;
            _srRvSlipNote = string.Empty;
            _srGoodsName = string.Empty;
            _srRvGoodsName = string.Empty;
            _srGoodsNo = string.Empty;
            _srRvGoodsNo = string.Empty;
            _srSlipNote = string.Empty;
            _srRvSlipNote = string.Empty;
            _srWarehouseShelfNo = string.Empty;
            _srRvWarehouseShelfNo = string.Empty;

            // **** コード←→名称を切り替える項目用 ****
            _swSalesEmployeeCd = string.Empty;
            _swSalesEmployeeName = string.Empty;
            _swBLGoodsCode = 0;
            _swBLGoodsName = string.Empty;
            //_swAfSectionCode = 0; // DEL 2010/05/18
            _swAfSectionCode = string.Empty; // ADD 2010/05/18
            _swAfSectionName = string.Empty;
            _swAfEnterWarehCode = string.Empty;
            _swAfEnterWarehName = string.Empty;
            _swGoodsMakerCd = 0;
            _swGoodsMakerName = string.Empty;
            _swSupplierCd = 0;
            _swSupplierName = string.Empty;

            _logicalDelDiv = 0;
            # endregion
        }

        /// <summary>
        /// 入力値比較
        /// </summary>
        /// <param name="stockMovePpr"></param>
        /// <param name="stockMovePprBackUp"></param>
        /// <returns>True：変更なし、False：変更あり</returns>
        /// <remarks>
        /// <br>Note       : 入力値比較。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private bool CompareStockMovePpr(StockMovePpr stockMovePpr, StockMovePpr stockMovePprBackUp)
        {
            if (stockMovePprBackUp == null)
            {
                return false;
            }

            ArrayList arrayList = stockMovePpr.Compare(stockMovePprBackUp);

            // 配列以外の比較
            if (arrayList.Count > 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// クローズタイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : クローズタイマー起動イベント。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void timer_Close_Tick(object sender, EventArgs e)
        {
            this.timer_Close.Enabled = false;
            this.Close();
        }

        /// <summary>
        /// Excelエクスポート・カラム初期化イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : Excelエクスポート・カラム初期化イベント処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void ultraGridExcelExporter_InitializeColumn( object sender, Infragistics.Win.UltraWinGrid.ExcelExport.InitializeColumnEventArgs e )
        {
            // グリッドカラムのフォーマットをExcelセルにコピーする。
            try
            {
                string format = e.Column.Format;

                // コード用フォーマットは(ゼロ空白にする場合)グリッドとエクセルで異なるので補正する。
                // 「0000;-0000;''」→「0000;-0000;」
                if ( format.EndsWith( ";''" ) )
                {
                    format = format.Substring( 0, format.Length - 2 );
                }
                e.ExcelFormatStr = format;
            }
            catch
            {
                e.ExcelFormatStr = string.Empty;
            }
        }

        /// <summary>
        /// 選択チェックボックスの非表示
        /// </summary>
        /// <remarks>
        /// <br>Note       : 選択チェックボックスの非表示。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void SetGridCheckBoxEnabled()
        {
            // 明細表示グリッド
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_StockMove.Rows)
            {
                // DBNullならチェックボックス表示しない
                if (row.Cells[_stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Value == DBNull.Value)
                {
                    row.Cells[_stockMoveDataSet.StockMoveDetail.SelectionCheckColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                }
            }
        }

        #endregion // プライベート関数

        #region イベント

        #region ガイド動作
        /// <summary>
        /// 入力拠点ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 入力拠点ガイド。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_InputSectionGuide_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_InputSectionCode.Text = sectionInfo.SectionCode.Trim();
                this.ultraLabel_InputSectionName.Text = sectionInfo.SectionGuideNm.Trim();
                _prevInputValue.InputSectionCode = sectionInfo.SectionCode.Trim();
                // 次フォーカス(出庫拠点)
                this.tEdit_SecCd.Focus();
            }
        }

        /// <summary>
        /// 出庫拠点ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 出庫拠点ガイド。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_SecGuide_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SecCd.Text = sectionInfo.SectionCode.Trim();
                this.ultraLabel_SecName.Text = sectionInfo.SectionGuideNm.Trim();
                _prevInputValue.SectionCode = sectionInfo.SectionCode.Trim();
                // 次フォーカス(出庫倉庫)
                this.tEdit_WarehouseCd.Focus();
            }
        }

        /// <summary>
        /// 倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンクリックイベント。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_WarehouseGuide_Click(object sender, EventArgs e)
        {
            // 拠点コードを取得
            string sectioncode = this.tEdit_SecCd.Text.Trim();
            int status = 0;

            // コードから名称へ変換
            Warehouse warehouseInfo;

            // 拠点コードが入力されていれば拠点内、なければ全拠点表示
            if (!String.IsNullOrEmpty(sectioncode))
            {
                status = this._warehouseAcs.ExecuteGuid(out warehouseInfo, this._enterpriseCode, sectioncode);
            }
            else
            {
                status = this._warehouseAcs.ExecuteGuid(out warehouseInfo, this._enterpriseCode);
            }

            // 戻り値が正常であれば
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // UI上には名前をセット、コードはメモリ内に格納
                this.tEdit_WarehouseCd.Text = warehouseInfo.WarehouseCode.Trim();
                this.ultraLabel_WarehouseName.Text = warehouseInfo.WarehouseName.Trim();
                _prevInputValue.WarehouseCode = warehouseInfo.WarehouseCode.Trim();
                // 次フォーカス(入出荷日)
                this.tDateEdit_DateSt.Focus();
            }
        }
        /// <summary>
        /// 担当者ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 担当者ガイドボタンクリックイベント。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_SalesEmployeeCd_Click(object sender, EventArgs e)
        {
            // ガイド表示
            Employee employeeInfo;
            int status;

            status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employeeInfo);

            // ステータスが正常の場合
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 名前をUIにセット、コードはメモリ内に保存
                this._swSalesEmployeeName = employeeInfo.Name.TrimEnd();
                this._swSalesEmployeeCd = employeeInfo.EmployeeCode;
                if (!string.IsNullOrEmpty(_swSalesEmployeeCd))
                {
                    this.tEdit_SalesEmployeeCd.Text = this._swSalesEmployeeCd.Trim().PadLeft(4, '0') + ":" + _swSalesEmployeeName;
                }

                Control nextControl = null;
                if (this.uCheckSalesEmployeeCd_base.Checked)
                {
                    nextControl = GetNextCommonControl(this.tEdit_SalesEmployeeCd.Name);
                }
                else
                {
                    nextControl = GetNextControl(this.tEdit_SalesEmployeeCd.Name);
                }
                if (nextControl != null) nextControl.Focus();
            }
        }

        /// <summary>
        /// 仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 仕入先ガイドボタンクリックイベント。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_SupplierCd_Click(object sender, EventArgs e)
        {

            // コードから名称へ変換
            Supplier supplierInfo;
            int status = this._supplierAcs.ExecuteGuid(out supplierInfo, this._enterpriseCode, string.Empty);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._swSupplierCd = supplierInfo.SupplierCd;
                // 仕入先マスタ.仕入先略称が入力されていた場合には仕入先マスタ.仕入先略称を表示
                if (!string.IsNullOrEmpty(supplierInfo.SupplierSnm))
                {
                    this._swSupplierName = supplierInfo.SupplierSnm;
                }
                // 仕入先マスタ.仕入先略称が未入力の場合には仕入先マスタ.仕入先名1を表示
                else if (!string.IsNullOrEmpty(supplierInfo.SupplierNm1))
                {
                    this._swSupplierName = supplierInfo.SupplierNm1;
                }
                // 仕入先マスタ.仕入先名称1が未入力の場合には仕入先マスタ.仕入先カナを表示
                else
                {
                    this._swSupplierName = supplierInfo.SupplierKana;
                }
                if (_swSupplierCd != 0)
                {
                    this.tEdit_SupplierCd.Text = this._swSupplierCd.ToString("D6") + ":" + this._swSupplierName;
                }
                Control nextControl = null;
                if (this.uCheckSupplierCd_base.Checked)
                {
                    nextControl = GetNextCommonControl(this.tEdit_SupplierCd.Name);
                }
                else
                {
                    nextControl = GetNextControl(this.tEdit_SupplierCd.Name);
                }
                if (nextControl != null) nextControl.Focus();
            }
        }

        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : メーカーガイドボタンクリックイベント。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_MakerCd_Click(object sender, EventArgs e)
        {
            // コードから名称へ変換
            MakerUMnt makerInfo;
            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._swGoodsMakerCd = makerInfo.GoodsMakerCd;
                this._swGoodsMakerName = makerInfo.MakerKanaName;
                if (_swGoodsMakerCd != 0)
                {
                    this.tEdit_MakerCd.Text = _swGoodsMakerCd.ToString("D4") + ":" + _swGoodsMakerName;
                }
                Control nextControl = null;
                if (this.uCheckGoodsMakerCd_base.Checked)
                {
                    nextControl = GetNextCommonControl(this.tEdit_MakerCd.Name);
                }
                else
                {
                    nextControl = GetNextControl(this.tEdit_MakerCd.Name);
                }
                if (nextControl != null) nextControl.Focus();
            }
        }

        /// <summary>
        /// BLコードガイドクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : BLコードガイドクリックイベント。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_BlGoodsCode_Click(object sender, EventArgs e)
        {
            // コードから名称へ変換
            BLGoodsCdUMnt blGoodsUnit;
            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsUnit);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._swBLGoodsCode = blGoodsUnit.BLGoodsCode;

                this._swBLGoodsName = blGoodsUnit.BLGoodsHalfName;
                if (_swBLGoodsCode != 0)
                {
                    this.tEdit_BlGoodsCode.Text = this._swBLGoodsCode.ToString("D5") + ":" + _swBLGoodsName;
                }
                Control nextControl = null;
                if (this.uCheckBLGoodsCode_base.Checked)
                {
                    nextControl = GetNextCommonControl(this.tEdit_BlGoodsCode.Name);
                }
                else
                {
                    nextControl = GetNextControl(this.tEdit_BlGoodsCode.Name);
                }
                if (nextControl != null) nextControl.Focus();
            }
        }

        /// <summary>
        /// 相手拠点ガイドクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 相手拠点ガイドクリックイベント。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_AfSectionCode_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //this._swAfSectionCode = Int32.Parse(sectionInfo.SectionCode); // DEL 2010/05/18
                //this._swAfSectionCode = sectionInfo.SectionCode; // ADD 2010/05/18
                this._swAfSectionCode = sectionInfo.SectionCode.Trim() ; // ADD 2010/05/20

                this._swAfSectionName = sectionInfo.SectionGuideNm;
                //this.tEdit_AfSectionCode.Text = this._swAfSectionCode.ToString("D2") + ":" + _swAfSectionName; // DEL 2010/05/18
                this.tEdit_AfSectionCode.Text = this._swAfSectionCode + ":" + _swAfSectionName; // ADD 2010/05/18
                Control nextControl = null;
                if (this.uCheckAfSectionCode_base.Checked)
                {
                    nextControl = GetNextCommonControl(this.tEdit_AfSectionCode.Name);
                }
                else
                {
                    nextControl = GetNextControl(this.tEdit_AfSectionCode.Name);
                }
                if (nextControl != null) nextControl.Focus();
            }
        }

        /// <summary>
        /// 相手倉庫ガイドクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 相手倉庫ガイドクリックイベント。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_AfEnterWarehCode_Click(object sender, EventArgs e)
        {
            // TODO:拠点コードを取得
            string sectioncode = this.tEdit_SecCd.Text.Trim();
            int status = 0;

            // コードから名称へ変換
            Warehouse warehouseInfo;

            // 拠点コードが入力されていれば拠点内、なければ全拠点表示
            if (!String.IsNullOrEmpty(sectioncode))
            {
                status = this._warehouseAcs.ExecuteGuid(out warehouseInfo, this._enterpriseCode, sectioncode);
            }
            else
            {
                status = this._warehouseAcs.ExecuteGuid(out warehouseInfo, this._enterpriseCode);
            }

            // 戻り値が正常であれば
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // UI上には名前をセット、コードはメモリ内に格納
                this._swAfEnterWarehCode = warehouseInfo.WarehouseCode.Trim();

                this._swAfEnterWarehName = warehouseInfo.WarehouseName;
                if (_swAfEnterWarehCode != string.Empty)
                {
                    this.tEdit_AfEnterWarehCode.Text = this._swAfEnterWarehCode + ":" + _swAfEnterWarehName;
                }
                Control nextControl = null;
                if (this.uCheckAfEnterWarehCode_base.Checked)
                {
                    nextControl = GetNextCommonControl(this.tEdit_AfEnterWarehCode.Name);
                }
                else
                {
                    nextControl = GetNextControl(this.tEdit_AfEnterWarehCode.Name);
                }
                if (nextControl != null) nextControl.Focus();
            }
        }

        /// <summary>
        /// 備考ガイドクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 備考ガイドクリックイベント。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uButton_SlipNote_Click(object sender, EventArgs e)
        {
            const int ctSlipNote1Div = 105;

            NoteGuidBd noteGuidBd;
            int status = _noteGuidAcs.ExecuteGuide(out noteGuidBd, this._enterpriseCode, ctSlipNote1Div);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 備考セット
                tEdit_SlipNote.Text = noteGuidBd.NoteGuideName;

                // 退避
                _srSlipNote = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_SlipNoteFuzzy.Value, tEdit_SlipNote.Text);

                // 次フォーカス
                Control nextControl = null;
                if (this.uCheckNote_base.Checked)
                {
                    nextControl = GetNextCommonControl(this.tEdit_SlipNote.Name);
                }
                else
                {
                    nextControl = GetNextControl(this.tEdit_SlipNote.Name);
                }
                if (nextControl != null) nextControl.Focus();
            }
        }
        #endregion // ガイド動作        

        #region Enterイベント
        /// <summary>
        /// 品番入力欄Enterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : 品番入力欄Enterイベント</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private void tEdit_GoodsNo_Enter(object sender, EventArgs e)
        {
            // 編集開始時に[*]入りの品番が保存されていれば置き換え
            if (!String.IsNullOrEmpty(this._srGoodsNo))
            {
                this.tEdit_GoodsNo.Text = this._srGoodsNo;
            }
        }

        /// <summary>
        /// 品名入力欄Enterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : 品名入力欄Enterイベント</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private void tEdit_GoodsName_Enter(object sender, EventArgs e)
        {
            // 編集開始時に[*]入りの品名が保存されていれば置き換え
            if (!String.IsNullOrEmpty(this._srGoodsName))
            {
                this.tEdit_GoodsName.Text = this._srGoodsName;
            }

        }

        /// <summary>
        /// 棚番入力欄Enterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : 棚番入力欄Enterイベント</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private void tEdit_WarehouseShelfNo_Enter(object sender, EventArgs e)
        {
            // 編集開始時に[*]入りの棚番が保存されていれば置き換え
            if (!String.IsNullOrEmpty(this._srWarehouseShelfNo))
            {
                this.tEdit_WarehouseShelfNo.Text = this._srWarehouseShelfNo;
            }
        }

        /// <summary>
        /// 備考入力欄Enterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : 品名入力欄Enterイベント</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        private void tEdit_SlipNote_Enter(object sender, EventArgs e)
        {
            // 編集開始時に[*]入りの備考が保存されていれば置き換え
            if (!String.IsNullOrEmpty(this._srSlipNote))
            {
                this.tEdit_SlipNote.Text = this._srSlipNote;
            }
        }
        #endregion // Enterイベント        

        # region フォーカス変換処理
        /// <summary>
        /// アローキーコントロール
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : アローキーコントロール。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // 抽出キャンセル
            if (e.Key == Keys.Escape)
            {
                CancelExtract();
            }

            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            this._prevControl = e.NextCtrl;

            // PrevCtrl設定
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
                this._control = prevCtrl;
            }
            // フッタ項目へ移動した場合は移動キャンセル
            if (e.NextCtrl == tComboEditor_StatusBar_FontSize)
            {
                if (!e.ShiftKey && (e.Key == Keys.Down || e.Key == Keys.Right || e.Key == Keys.Tab || e.Key == Keys.Return))
                {
                    e.NextCtrl = e.PrevCtrl;
                    return;
                }
            }

            // 名前により分岐
            switch (prevCtrl.Name)
            {
                # region 出力区分

                case "tComboEditor_OutputDiv":
                case "tComboEditor_SalesSlipDiv":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.tEdit_InputSectionCode.Visible)
                                    {
                                        e.NextCtrl = this.tEdit_InputSectionCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_SecCd;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = null;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region 入力拠点コード
                case "tEdit_InputSectionCode":
                    {
                        string inputValue = this.tEdit_InputSectionCode.Text;

                        string code;
                        string name;
                        bool status = ReadInputSectionCodeAllowZeroName(out code, out name);

                        if (status == true)
                        {
                            this.tEdit_InputSectionCode.Text = code;
                            this.ultraLabel_InputSectionName.Text = name;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Left:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    case Keys.Up:
                                        {
                                            e.NextCtrl = this.tComboEditor_SalesSlipDiv;
                                        }
                                        break;
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tEdit_InputSectionCode.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_InputSectionGuide;
                                            }
                                            else
                                            {
                                                if (this.tEdit_SecCd.Enabled)
                                                {
                                                    e.NextCtrl = this.tEdit_SecCd;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tDateEdit_DateSt;
                                                }
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            e.NextCtrl = this.tComboEditor_SalesSlipDiv;
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "拠点が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コード戻す
                            this.tEdit_InputSectionCode.Text = code;
                            this.tEdit_InputSectionCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                #endregion

                # region 入力拠点ガイド
                case "uButton_InputSectionGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.tEdit_SecCd.Enabled)
                                        {
                                            e.NextCtrl = this.tEdit_SecCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tDateEdit_DateSt;
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (!this.uButton_SecGuide.Enabled && !this.uButton_WarehouseGuide.Enabled)
                                        {
                                            if (this.uExGroupBox_ExtraCondition.Visible)
                                            {
                                                // 拡張検索条件の表示状態を調べて次へ(あえて"tDateEdit_AddUpADateEd"を指定して終了入力日の次項目を探す)
                                                e.NextCtrl = this.GetNextControl("tDateEdit_DateEd");
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = tEdit_InputSectionCode;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region 出庫拠点
                case "tEdit_SecCd":
                    {
                        string inputValue = this.tEdit_SecCd.Text;

                        string code;
                        string name;
                        bool status = ReadSectionCodeAllowZeroName(out code, out name);

                        if (status == true)
                        {
                            this.tEdit_SecCd.Text = code;
                            this.ultraLabel_SecName.Text = name;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Left:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    case Keys.Up:
                                        {
                                            if (this.tEdit_InputSectionCode.Visible)
                                            {
                                                e.NextCtrl = this.tEdit_InputSectionCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tComboEditor_OutputDiv;
                                            }
                                        }
                                        break;
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tEdit_SecCd.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SecGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_WarehouseCd;
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.tEdit_InputSectionCode.Visible)
                                            {
                                                e.NextCtrl = this.uButton_InputSectionGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tComboEditor_OutputDiv;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "拠点が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コード戻す
                            this.tEdit_SecCd.Text = code;
                            this.tEdit_SecCd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                #endregion

                # region 出庫拠点ガイド
                case "uButton_SecGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    e.NextCtrl = this.tEdit_WarehouseCd;
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = tEdit_SecCd;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region 出庫/入庫倉庫
                case "tEdit_WarehouseCd":
                    {
                        string inputValue = this.tEdit_WarehouseCd.Text;

                        string code;
                        string name;
                        bool status = ReadWarehouseName(out code, out name);

                        if (status == true)
                        {
                            this.tEdit_WarehouseCd.Text = code;
                            this.ultraLabel_WarehouseName.Text = name;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Left:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    case Keys.Up:
                                        {
                                            e.NextCtrl = this.tEdit_SecCd;
                                        }
                                        break;
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tEdit_WarehouseCd.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_WarehouseGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tDateEdit_DateSt;
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            e.NextCtrl = uButton_SecGuide;
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "倉庫が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コード戻す
                            this.tEdit_WarehouseCd.Text = code;
                            this.tEdit_WarehouseCd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                #endregion

                # region 出庫/入庫倉庫ガイド
                case "uButton_WarehouseGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    e.NextCtrl = this.tDateEdit_DateSt;
                                    break;
                                case Keys.Down:
                                    {
                                        if (this.uExGroupBox_ExtraCondition.Visible)
                                        {
                                            // 拡張検索条件の表示状態を調べて次へ(あえて"tDateEdit_AddUpADateEd"を指定して終了入力日の次項目を探す)
                                            e.NextCtrl = this.GetNextControl("tDateEdit_DateEd");
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = tEdit_WarehouseCd;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region 入出荷日（開始）
                // 入出荷日（開始）
                case "tDateEdit_DateSt":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tDateEdit_DateEd;// 入出荷日（終了）
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uButton_WarehouseGuide.Enabled)
                                        {
                                            e.NextCtrl = this.uButton_WarehouseGuide;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_InputSectionGuide;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region 入出荷日（終了）
                // 売上日（終了）
                case "tDateEdit_DateEd":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = this.tDateEdit_DateSt;
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region 入力日開始
                // 入力日開始
                case "tDateEdit_AddUpADateSt":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.uCheckAddUpADateSt_base.Checked)
                                        {
                                            e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckAddUpADateSt_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                #region 入力日終了
                // 入力日終了
                case "tDateEdit_AddUpADateEd":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.uCheckAddUpADateEd_base.Checked)
                                        {
                                            e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckAddUpADateEd_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                # region 伝票番号
                // 伝票番号
                case "tEdit_StockMoveSlipNum":
                    {
                        this.tEdit_StockMoveSlipNum.Text = this.uiSetControl1.GetZeroPaddedText("tEdit_SalesSlipNum", this.tEdit_StockMoveSlipNum.Text);
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckSalesSlipNum_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckSalesSlipNum_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                # region 入荷区分
                // 入荷区分
                case "tComboEditor_ArrivalGoodsFlag":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckArrivalGoodsFlag_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckArrivalGoodsFlag_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                # region 削除指定区分
                // 削除指定区分
                case "tComboEditor_DeleteFlag":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckDeleteFlag_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckDeleteFlag_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                # region 担当者ガイド

                case "uButton_SalesEmployeeCd":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckSalesEmployeeCd_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckSalesEmployeeCd_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                # region 仕入先ガイド
                case "uButton_SupplierCd":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckSupplierCd_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckSupplierCd_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                # region メーカーガイド
                case "uButton_MakerCd":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckGoodsMakerCd_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckGoodsMakerCd_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    }
                #endregion

                # region BLコードガイド
                // BLコードガイド
                case "uButton_BlGoodsCode":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckBLGoodsCode_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckBLGoodsCode_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                # region 相手拠点ガイド
                // 相手拠点ガイド
                case "uButton_AfSectionCode":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckAfSectionCode_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckAfSectionCode_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                # region 相手倉庫ガイド
                // 相手倉庫ガイド
                case "uButton_AfEnterWarehCode":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckAfEnterWarehCode_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckAfEnterWarehCode_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                # region 備考ガイド
                // 備考１ガイド
                case "uButton_SlipNote":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckNote_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckNote_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                #endregion

                # region [コード←→名称 切り替え項目]

                # region [担当者]
                // 担当者
                case "tEdit_SalesEmployeeCd":
                    {
                        string inputValue = tEdit_SalesEmployeeCd.Text;

                        string code;
                        bool status = ReadSalesEmployeeName(out code);

                        if (status == true)
                        {
                            // 名称表示
                            if (!string.IsNullOrEmpty(_swSalesEmployeeCd))
                            {
                                tEdit_SalesEmployeeCd.Text = _swSalesEmployeeCd.Trim().PadLeft(4, '0') + ":" + _swSalesEmployeeName;
                            }
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.uCheckSalesEmployeeCd_base.Checked)
                                        {
                                            e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.uCheckSalesEmployeeCd_base.Checked)
                                            {
                                                e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "担当者が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コードに戻す
                            tEdit_SalesEmployeeCd.Text = code;
                            tEdit_SalesEmployeeCd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                # endregion

                # region [BLコード]
                // BLコード
                case "tEdit_BlGoodsCode":
                    {
                        int inputValue;
                        try
                        {
                            inputValue = Int32.Parse(tEdit_BlGoodsCode.Text);
                        }
                        catch
                        {
                            inputValue = 0;
                        }

                        int code;
                        bool status = ReadBlCodeName(out code);

                        if (status == true)
                        {
                            // 名称表示
                            if (_swBLGoodsCode != 0)
                            {
                                this.tEdit_BlGoodsCode.Text = this._swBLGoodsCode.ToString("D5") + ":" + _swBLGoodsName;
                            }

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.uCheckBLGoodsCode_base.Checked)
                                        {
                                            e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.uCheckBLGoodsCode_base.Checked)
                                            {
                                                e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "ＢＬコードが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コードに戻す
                            tEdit_BlGoodsCode.Text = code.ToString();
                            tEdit_BlGoodsCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                # endregion

                # region [メーカー]
                // メーカー
                case "tEdit_MakerCd":
                    {
                        int inputValue;
                        try
                        {
                            inputValue = Int32.Parse(tEdit_MakerCd.Text);
                        }
                        catch
                        {
                            inputValue = 0;
                        }

                        int code;
                        bool status = ReadGoodsMakerName(out code);

                        if (status == true)
                        {
                            // 名称表示
                            if (_swGoodsMakerCd != 0)
                            {
                                tEdit_MakerCd.Text = _swGoodsMakerCd.ToString("D4") + ":" + _swGoodsMakerName;
                            }

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.uCheckGoodsMakerCd_base.Checked)
                                        {
                                            e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.uCheckGoodsMakerCd_base.Checked)
                                            {
                                                e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "メーカーが存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コードに戻す
                            tEdit_MakerCd.Text = code.ToString();
                            tEdit_MakerCd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                # endregion

                # region [倉庫]
                // 倉庫
                case "tEdit_AfEnterWarehCode":
                    {
                        string inputValue = tEdit_AfEnterWarehCode.Text;

                        string code;
                        bool status = ReadAfEnterWarehName(out code);

                        if (status == true)
                        {
                            // 名称表示
                            if (_swAfEnterWarehCode != string.Empty)
                            {
                                this._swAfEnterWarehCode = this._swAfEnterWarehCode.PadLeft(4, '0'); // ADD 2010/05/18
                                this.tEdit_AfEnterWarehCode.Text = this._swAfEnterWarehCode + ":" + _swAfEnterWarehName;
                            }
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.uCheckAfEnterWarehCode_base.Checked)
                                        {
                                            e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.uCheckAfEnterWarehCode_base.Checked)
                                            {
                                                e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "倉庫が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コードに戻す
                            tEdit_AfEnterWarehCode.Text = code;
                            tEdit_AfEnterWarehCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                # endregion

                # region [仕入先]
                // 仕入先
                case "tEdit_SupplierCd":
                    {
                        int inputValue;
                        try
                        {
                            inputValue = Int32.Parse(tEdit_SupplierCd.Text);
                        }
                        catch
                        {
                            inputValue = 0;
                        }

                        int code;
                        bool status = ReadSupplierName(out code);

                        if (status == true)
                        {
                            // 名称表示
                            if (_swSupplierCd != 0)
                            {
                                tEdit_SupplierCd.Text = this._swSupplierCd.ToString("D6") + ":" + this._swSupplierName;
                            }
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.uCheckSupplierCd_base.Checked)
                                        {
                                            e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.uCheckSupplierCd_base.Checked)
                                            {
                                                e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "仕入先が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コードに戻す
                            tEdit_SupplierCd.Text = code.ToString();
                            tEdit_SupplierCd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                # endregion

                # region [相手拠点]
                // 相手拠点
                case "tEdit_AfSectionCode":
                    {
                        int inputValue;
                        try
                        {
                            inputValue = Int32.Parse(tEdit_AfSectionCode.Text);
                        }
                        catch
                        {
                            inputValue = 0;
                        }

                        //int code; // DEL 2010/05/18
                        string code; // ADD 2010/05/18
                        bool status = ReadAfSectionName(out code);

                        if (status == true)
                        {
                            // 名称表示
                            //if (_swAfSectionCode != 0) // DEL 2010/05/18
                            if (!string.IsNullOrEmpty(_swAfSectionCode)) // ADD 2010/05/18
                            {
                                //tEdit_AfSectionCode.Text = this._swAfSectionCode.ToString("D2") + ":" + this._swAfSectionName; // DEL 2010/05/18
                                this._swAfSectionCode = this._swAfSectionCode.PadLeft(2, '0'); // ADD 2010/05/18
                                tEdit_AfSectionCode.Text = this._swAfSectionCode + ":" + this._swAfSectionName; // ADD 2010/05/18
                            }
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        if (this.uCheckAfSectionCode_base.Checked)
                                        {
                                            e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (this.uCheckAfSectionCode_base.Checked)
                                            {
                                                e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "拠点が存在しません。",
                                -1,
                                MessageBoxButtons.OK);

                            // コードに戻す
                            tEdit_AfSectionCode.Text = code.ToString();
                            tEdit_AfSectionCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                # endregion

                # endregion

                # region [あいまい検索項目]

                # region [備考]
                // 備考
                case "tEdit_SlipNote":
                    {
                        string inputValue = tEdit_SlipNote.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // 表示
                        tEdit_SlipNote.Text = searchText;
                        tComboEditor_SlipNoteFuzzy.Value = fuzzyValue;

                        // 退避
                        _srSlipNote = inputValue;
                        _srRvSlipNote = searchText;

                        # region [フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckNote_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckNote_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }

                        # endregion
                    }
                    break;
                // 備考1あいまい条件
                case "tComboEditor_SlipNoteFuzzy":
                    {
                        // 退避
                        _srSlipNote = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_SlipNoteFuzzy.Value, tEdit_SlipNote.Text);

                        # region [フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckNote_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckNote_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                # endregion

                # region [品名]
                // 品名
                case "tEdit_GoodsName":
                    {
                        string inputValue = tEdit_GoodsName.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // 表示
                        tEdit_GoodsName.Text = searchText;
                        tComboEditor_GoodsNameFuzzy.Value = fuzzyValue;

                        // 退避
                        _srGoodsName = inputValue;
                        _srRvGoodsName = searchText;

                        # region [フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckGoodsName_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckGoodsName_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                // 品名あいまい条件
                case "tComboEditor_GoodsNameFuzzy":
                    {
                        // 退避
                        _srGoodsName = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_GoodsNameFuzzy.Value, tEdit_GoodsName.Text);

                        # region [フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckGoodsName_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckGoodsName_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                # endregion

                # region [品番]
                // 品番
                case "tEdit_GoodsNo":
                    {
                        string inputValue = tEdit_GoodsNo.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // 表示
                        tEdit_GoodsNo.Text = searchText;
                        tComboEditor_GoodsNoFuzzy.Value = fuzzyValue;

                        // 退避
                        _srGoodsNo = inputValue;
                        _srRvGoodsNo = searchText;

                        # region [フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckGoodsNo_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckGoodsNo_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                // 品番あいまい条件
                case "tComboEditor_GoodsNoFuzzy":
                    {
                        // 退避
                        _srGoodsNo = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_GoodsNoFuzzy.Value, tEdit_GoodsNo.Text);

                        # region [フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckGoodsNo_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckGoodsNo_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                # endregion

                # region [棚番]
                // 棚番
                case "tEdit_WarehouseShelfNo":
                    {
                        string inputValue = tEdit_WarehouseShelfNo.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // 表示
                        tEdit_WarehouseShelfNo.Text = searchText;
                        tComboEditor_WarehouseShelfNoFuzzy.Value = fuzzyValue;

                        // 退避
                        _srWarehouseShelfNo = inputValue;
                        _srRvWarehouseShelfNo = searchText;

                        # region [フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckWarehouseShelfNo_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckWarehouseShelfNo_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                // 棚番あいまい条件
                case "tComboEditor_WarehouseShelfNoFuzzy":
                    {
                        // 退避
                        _srWarehouseShelfNo = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_WarehouseShelfNoFuzzy.Value, tEdit_WarehouseShelfNo.Text);

                        # region [フォーカス]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    if (this.uCheckWarehouseShelfNo_base.Checked)
                                    {
                                        e.NextCtrl = this.GetNextCommonControl(e.PrevCtrl.Name);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.uCheckWarehouseShelfNo_base.Checked)
                                        {
                                            e.NextCtrl = this.GetBeforeCommonControl(e.PrevCtrl.Name);
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.GetBeforeControl(e.PrevCtrl.Name);
                                        }
                                    }
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                #region 明細一覧
                //---------------------------------------------------------------
                // 明細一覧
                //---------------------------------------------------------------
                case "uGrid_StockMove":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    if (this.uGrid_StockMove.ActiveCell != null)
                                    {
                                        this.uGrid_StockMove.ActiveCell.Row.Activate();
                                    }

                                    if (this.uGrid_StockMove.ActiveRow != null)
                                    {
                                        e.NextCtrl = null;
                                    }
                                    else
                                    {
                                        e.NextCtrl = uCheckEditor_StatusBar_AutoFillToGridColumn;
                                    }
                                }
                                break;
                            case Keys.Tab:
                                if (!e.ShiftKey)
                                {
                                    //出力区分
                                    if (this.tComboEditor_OutputDiv.Visible)
                                    {
                                        e.NextCtrl = this.tComboEditor_OutputDiv;
                                    }

                                    // 伝票区分
                                    if (this.tComboEditor_SalesSlipDiv.Visible)
                                    {
                                        e.NextCtrl = this.tComboEditor_SalesSlipDiv;
                                    }
                                }
                                break;
                        }
                    }
                    break;
                #endregion

                # endregion
                # endregion
            }

            // 合計タブor明細タブに移動する場合は検索実行チェックする
            if ((e.NextCtrl == uGrid_StockMove || e.NextCtrl == uTabControl_BlDspRslt) && this._doSearchFlg)
            {
                if (!e.ShiftKey && (e.Key == Keys.Down || e.Key == Keys.Right || e.Key == Keys.Tab || e.Key == Keys.Return))
                {
                    // 検索実行
                    e.NextCtrl = SearchOnChangeFocus(e.PrevCtrl);
                    return;
                }
            }
            else if (e.NextCtrl == uButton_SlipNote)
            {
                if (!e.ShiftKey && (e.Key == Keys.Up || e.Key == Keys.Down))
                {
                    e.NextCtrl = tEdit_SlipNote;
                }
            }

            this._nextControl = e.NextCtrl;
            this._doSearchFlg = true;
        }
        # endregion

        #region グリッドKeyDownイベント
        /// <summary>
        /// KeyDownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : KeyDownイベント。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void uGrid_StockMove_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                this.uGrid_StockMove.BeginUpdate();

                switch (e.KeyCode)
                {
                    case Keys.Space:
                        {
                            if (this.uGrid_StockMove.ActiveCell == null && this.uGrid_StockMove.ActiveRow != null)
                            {
                                this.uGrid_StockMove.ActiveCell = this.uGrid_StockMove.ActiveRow.Cells[0];
                            }
                            if (this.uGrid_StockMove.ActiveCell != null)
                            {
                                this.stockMoveSlipSelectSetting();
                            }
                        }
                        break;
                    case Keys.Left:
                        {
                            if (this.uGrid_StockMove.ActiveCell == null && this.uGrid_StockMove.ActiveRow != null)
                            {
                                this.uGrid_StockMove.ActiveCell = this.uGrid_StockMove.ActiveRow.Cells[0];
                            }

                            // 左端のVisiblePositionを取得
                            int firstPosition = this.GetGridFirstPosition(this.uGrid_StockMove);

                            // 左端から前行右端に移動させない
                            if (this.uGrid_StockMove.ActiveCell.Column.Header.VisiblePosition == firstPosition)
                            {
                                e.Handled = true;
                            }
                        }
                        break;
                    case Keys.Right:
                        {
                            if (this.uGrid_StockMove.ActiveCell == null && this.uGrid_StockMove.ActiveRow != null)
                            {
                                this.uGrid_StockMove.ActiveCell = this.uGrid_StockMove.ActiveRow.Cells[0];
                            }

                            // 右端のVisiblePositionを取得
                            int lastPosition = this.GetGridLastPosition(this.uGrid_StockMove);

                            if (this.uGrid_StockMove.ActiveCell == null) break; 
                            // 右端から次行左端に移動させない
                            if (this.uGrid_StockMove.ActiveCell.Column.Header.VisiblePosition == lastPosition)
                            {
                                e.Handled = true;
                            }
                        }
                        break;
                    case Keys.Up:
                        {
                            Infragistics.Win.UltraWinGrid.UltraGridRow row = uGrid_StockMove.ActiveRow;
                            if (row == null && uGrid_StockMove.ActiveCell != null)
                            {
                                row = uGrid_StockMove.ActiveCell.Row;
                            }

                            if (row != null && row.Index == 0)
                            {
                                // 先頭行から上移動
                                Control nextControl = GetNextControlForGridUpKey();
                                if (nextControl != null)
                                {
                                    if (uGrid_StockMove.ActiveCell != null)
                                    {
                                        uGrid_StockMove.ActiveCell.Selected = false;
                                        uGrid_StockMove.ActiveCell = null;
                                    }
                                    if (uGrid_StockMove.ActiveRow != null)
                                    {
                                        uGrid_StockMove.ActiveRow.Selected = false;
                                        uGrid_StockMove.ActiveRow = null;
                                    }
                                    nextControl.Focus();
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            finally
            {
                this.uGrid_StockMove.EndUpdate();
            }
        }

        /// <summary>
        /// グリッド内の最初のVisiblePosition取得
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private int GetGridFirstPosition(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            if (grid.ActiveRow == null) return 0;

            int colCount = grid.ActiveRow.Cells.Count;
            for (int index = 0; index < grid.ActiveRow.Cells.Count; index++)
            {
                if (grid.ActiveRow.Cells[index].Column.Hidden == false)
                {
                    if (colCount > grid.ActiveRow.Cells[index].Column.Header.VisiblePosition)
                    {
                        colCount = grid.ActiveRow.Cells[index].Column.Header.VisiblePosition;
                    }
                }
            }
            return colCount;
        }

        /// <summary>
        /// グリッド内の最後のVisiblePosition取得
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private int GetGridLastPosition(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            if (grid.ActiveRow == null) return 0;

            int colCount = 0;
            for (int index = 0; index < grid.ActiveRow.Cells.Count; index++)
            {
                if (grid.ActiveRow.Cells[index].Column.Hidden == false)
                {
                    if (colCount < grid.ActiveRow.Cells[index].Column.Header.VisiblePosition)
                    {
                        colCount = grid.ActiveRow.Cells[index].Column.Header.VisiblePosition;
                    }
                }
            }
            return colCount;
        }

        /// <summary>
        /// グリッド先頭行からのUpキー戻り先取得
        /// </summary>
        /// <returns></returns>
        private Control GetNextControlForGridUpKey()
        {
            DisplayExtraConditions();

            if (uExGroupBox_ExtraCondition.Expanded && _gridUpKeyBackControl != null)
            {
                // 詳細条件
                return _gridUpKeyBackControl;
            }
            else if (uExGroupBox_CommonCondition.Expanded)
            {
                // 基本条件
                if (tEdit_WarehouseCd.Enabled == true)
                {
                    return this.tEdit_WarehouseCd;
                }
                else
                {
                    // 入荷確定あり
                    if (this._stockMoveFixCode == 1)
                    {
                        return this.tEdit_SecCd;
                    }
                    // 入荷確定なし
                    else
                    {
                        return this.tEdit_InputSectionCode;
                    }
                }
            }
            else
            {
                // 移動しない
                return null;
            }
        }
        #endregion // グリッドKeyDownイベント

        /// <summary>
        /// 入荷区分の変更エベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ValueChangedイベント。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/05/23</br>
        /// <br>Update Note: #21681</br>
        /// <br></br>
        /// </remarks>
        private void tComboEditor_ArrivalGoodsFlag_ValueChanged(object sender, EventArgs e)
        {
            // 入荷区分が「入荷済」の場合
            if (this.tComboEditor_ArrivalGoodsFlag.SelectedIndex == 1)
            {
                // 削除指定区分を入力不可とし、「通常」固定とする。
                this.tComboEditor_DeleteFlag.SelectedIndex = 0;
                this.tComboEditor_DeleteFlag.Enabled = false;
            }
            else
            {
                this.tComboEditor_DeleteFlag.Enabled = true;
            }
        }

        #endregion // イベント
    }
    
    # region [グリッドカラムポジションFix制御クラス]
    /// <summary>
    /// グリッドカラムポジションFix制御クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : グリッドカラムポジションFix制御クラス。</br>
    /// <br>Programmer : 高峰</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br></br>
    /// </remarks>
    internal class GridColPosFixController
    {
        private Infragistics.Win.UltraWinGrid.UltraGrid _targetGrid;
        private Dictionary<string, int> _fixPosDic;
        private Dictionary<string, bool> _fixDic;

        # region [プロパティ]
        /// <summary>
        /// 対象グリッド
        /// </summary>
        public Infragistics.Win.UltraWinGrid.UltraGrid TargetGrid
        {
            get { return _targetGrid; }
            set
            {
                // 対象グリッドが既に設定済みならばイベントハンドラの登録を削除する
                if (_targetGrid != null)
                {
                    _targetGrid.BeforeColPosChanged -= Grid_BeforeColPosChanged;
                    _targetGrid.AfterColPosChanged -= Grid_AfterColPosChanged;
                }

                // グリッド
                _targetGrid = value;

                // グリッドイベント
                _targetGrid.BeforeColPosChanged += Grid_BeforeColPosChanged;
                _targetGrid.AfterColPosChanged += Grid_AfterColPosChanged;

                // 内部使用するフィールド初期化
                _fixPosDic = new Dictionary<string, int>();
                _fixDic = new Dictionary<string, bool>();
            }
        }
        # endregion

        # region [コンストラクタ]
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public GridColPosFixController()
        {
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GridColPosFixController(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid)
            : this()
        {
            this.TargetGrid = targetGrid;
        }
        # endregion

        # region [対象のグリッドに追加するイベント処理]
        /// <summary>
        /// カラムポジション変更前イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : カラムポジション変更前イベント処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void Grid_BeforeColPosChanged(object sender, Infragistics.Win.UltraWinGrid.BeforeColPosChangedEventArgs e)
        {
            // Moved以外は無視する
            if (e.PosChanged != Infragistics.Win.UltraWinGrid.PosChanged.Moved) return;

            if (_fixDic.ContainsKey(e.ColumnHeaders[0].Column.Key))
            {
                if (_fixDic[e.ColumnHeaders[0].Column.Key] != e.ColumnHeaders[0].Fixed)
                {
                    if (e.ColumnHeaders[0].Fixed == true)
                    {
                        int fixedColCount = 0;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in _targetGrid.DisplayLayout.Bands[0].Columns)
                        {
                            if (!col.Hidden && col.Header.Fixed) fixedColCount++;
                        }

                        // 変更前のポジションを退避する(fixedになっているカラム数は除く)
                        _fixPosDic[e.ColumnHeaders[0].Column.Key] = e.ColumnHeaders[0].VisiblePosition - fixedColCount;
                    }
                }
            }
            else
            {
                int fixedColCount = 0;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in _targetGrid.DisplayLayout.Bands[0].Columns)
                {
                    if (!col.Hidden && col.Header.Fixed) fixedColCount++;
                }

                // 追加して次回以降の変更で処理
                _fixDic.Add(e.ColumnHeaders[0].Column.Key, false);
                _fixPosDic.Add(e.ColumnHeaders[0].Column.Key, e.ColumnHeaders[0].VisiblePosition - fixedColCount);
            }
        }
        /// <summary>
        /// カラムポジション変更後イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : カラムポジション変更後イベント処理。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void Grid_AfterColPosChanged(object sender, Infragistics.Win.UltraWinGrid.AfterColPosChangedEventArgs e)
        {
            if (e.PosChanged != Infragistics.Win.UltraWinGrid.PosChanged.Moved) return;

            if (_fixDic.ContainsKey(e.ColumnHeaders[0].Column.Key) && _fixDic[e.ColumnHeaders[0].Column.Key] != e.ColumnHeaders[0].Fixed)
            {
                // Fix状態が変更された
                if (e.ColumnHeaders[0].Fixed == false)
                {
                    int fixedColCount = 0;
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in _targetGrid.DisplayLayout.Bands[0].Columns)
                    {
                        if (!col.Hidden && col.Header.Fixed) fixedColCount++;
                    }

                    // ポジションを戻す（fixedになっているカラム数を考慮する）
                    e.ColumnHeaders[0].VisiblePosition = _fixPosDic[e.ColumnHeaders[0].Column.Key] + fixedColCount;

                    // 戻すことで他のカラムに影響する
                    List<string> dicKeyList = new List<string>();
                    foreach (string colKey in _fixPosDic.Keys)
                    {
                        if (_fixPosDic[colKey] > _fixPosDic[e.ColumnHeaders[0].Column.Key])
                        {
                            dicKeyList.Add(colKey);
                        }
                    }
                    foreach (string colKey in dicKeyList)
                    {
                        _fixPosDic[colKey]--;
                    }
                }

                // 前回退避値更新
                _fixDic[e.ColumnHeaders[0].Column.Key] = e.ColumnHeaders[0].Fixed;
            }
        }
        # endregion

    }
    # endregion

}