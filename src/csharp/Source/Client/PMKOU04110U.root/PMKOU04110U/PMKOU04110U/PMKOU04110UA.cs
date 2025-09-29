using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;
// --- ADD 2010/07/20-------------------------------->>>>>
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Infragistics.Excel;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Controller.Facade;
// --- ADD 2010/07/20--------------------------------<<<<<

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 仕入先年間実績照会フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 仕入先年間実績照会のフォームクラスです。</br>
    /// <br>Programmer : 30418 徳永</br>
    /// <br>Date       : 2008.12.11</br>
    /// <br>Update Note: 2009.01.28 30452 上野 俊治</br>
    /// <br>            ・障害対応10587,10588,10589,10595,10596</br> 
    /// <br>Update Note: 2009.01.29 30452 上野 俊治</br>
    /// <br>            ・障害対応10590,10609</br> 
    /// <br>Update Note: 2009.01.30 30452 上野 俊治</br>
    /// <br>            ・障害対応10717(精算先区分の取得処理を修正)</br> 
    /// <br>Update Note: 2009.02.02 30452 上野 俊治</br>
    /// <br>            ・障害対応10701(仕入と純仕入が逆になっていたのを修正)</br>
    /// <br>Update Note: 2009.02.13 30414 忍 幸史</br>
    /// <br>            ・締日取得方法を変更</br>
    /// <br>Update Note: 2009.02.13 30452 上野 俊治</br>
    /// <br>            ・自社締日取得方法を変更</br>
    /// <br>            ・支払情報合計を設定</br>
    /// <br>Update Note: 2009.03.12 30414 忍 幸史</br>
    /// <br>            ・障害ID:12299対応</br>
    /// <br>Update Note: 2010/02/18 22008 長内 数馬</br>
    /// <br>            ・グラフ機能の追加</br>
    /// <br>Update Note: 2010/02/22 980035 金沢 貞義</br>
    /// <br>            ・グリッド部のフォントサイズ変更</br>
    /// <br>Update Note: 2010/03/15 980035 金沢 貞義</br>
    /// <br>            ・グラフのデータテーブルの金額項目を"int"から"double"に変更</br>
    /// <br>            　(10桁の金額がセットされている時、エラーになるため)</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/30 30517 夏野 駿希</br>
    /// <br>            ・MANTIS対応15359 グラフ改良</br>
    /// <br>Update Note: 2010/07/20 杜志剛</br>
    /// <br>            ・テキスト、Excek出力対応</br>
    /// <br>Update Note: 2010/08/23 chenyd</br>
    /// <br>            ・テキスト出力対応13482</br>
    /// <br>Update Note : 2010/09/08 楊明俊</br>
    /// <br>            ・障害ID:14443 テキスト出力対応</br>
    /// <br>Update Note : 2010/09/21 李永平</br>
    /// <br>            ・障害ID:14876 テキスト出力対応</br>
    /// <br>Update Note : 2010/09/26 tianjw</br>
    /// <br>            : Redmine#14876対応</br>
    /// <br>Update Note: 2010/10/09 tianjw</br>
    /// <br>           : #15881 テキスト出力対応</br>
    /// <br>Update Note: 2010/11/01 tianjw</br>
    /// <br>            redmine#16602 テキスト出力対応 不具合修正</br>
    /// <br>Update Note :2011/02/16 liyp</br>
    /// <br>             テキスト出力機能の場合のみの修正</br>
    /// <br>Update Note : 2012/09/18 FSI今野 利裕</br>
    /// <br>              仕入先総括対応に伴う対応</br>
    /// <br>Update Note : 2012/11/08 FSI今野 利裕</br>
    /// <br>              残高照会出力結果の修正</br>
    /// <br>Update Note : 2024/11/22 陳艶丹</br>
    /// <br>              PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
    /// <br></br>
    /// </remarks>
	public partial class PMKOU04110UA : Form
	{
		# region Inner Class
        /// <summary>
        /// セル結合条件クラス（IMergedCellEvaluator インタフェースをインプリメント）
        /// </summary>
        private class CustomMergedCellEvaluatorRowNo : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
        {
            /// <summary>
            /// セル結合条件判定処理
            /// </summary>
            /// <param name="row1">行１</param>
            /// <param name="row2">行２</param>
            /// <param name="column">列</param>
            /// <returns>列に関連付けられたrow1とrow2のセルが結合される場合、Trueを返します</returns>
            public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
            {
                string Title1 = row1.Cells["Title"].Value.ToString();
                string Title2 = row2.Cells["Title"].Value.ToString();
                return (true);

                //if ((Title1.Trim() == "") || (Title2.Trim() == "")) return false;
                //return (Title1 == Title2);
            }
        }
        # endregion

        #region プライベート変数

        /// <summary>仕入先年間実績照会 アクセスクラス</summary>
        private SuppYearResultAcs _suppYearResultAcs = null;

        /// <summary>仕入先年間実績照会 検索条件クラス</summary>
        SuppYearResultCndtn _suppYearResultCndtn = null;

        /// <summary>仕入先年間実績照会 検索結果データセット</summary>
        private InventoryUpdateDataSet _dataSet;

        /// <summary>PMKHN09022A)仕入先</summary>
        private SupplierAcs _supplierAcs;

        /// <summary>PMKHN09021E)仕入先情報データクラス</summary>
        //private Supplier _supplier = null; // プライベートにしない

        /// <summary>SFSIR09021E)支払設定 アクセスクラス</summary>
        private PaymentSetAcs _paymentSetAcs;

        /// <summary>PMCMN00102A)締め日算出モジュール</summary>
        private TotalDayCalculator _totalDayCalculator;

        private PMKOU04110UC _userSetupFrm = null;              // ユーザー設定画面 // ADD 2010/02/18

        private PMKOU04110UE _extractSetupFrm = null;           // 出力条件設定画面 // ADD 2010/07/20

        private bool isError = false; // ADD 2010/09/26
        // --- DEL 2009/01/30 -------------------------------->>>>>
        ///// <summary>精算先区分</summary>
        ///// <remarks>仕入先マスタの仕入先コード=支払先コードの場合は親(0)、そうでなければ子(1)/初期値は子（残高照会タブを開かせない）</remarks>
        //private int _accDiv = 1;
        // --- DEL 2009/01/30 --------------------------------<<<<<

        /// <summary>仕入先締日</summary>
        /// <remarks>年月日</remarks>
        private DateTime _suppTotalDay = DateTime.MinValue;

        /// <summary>機首年月日</summary>
        /// <remarks>年月</remarks>
        private DateTime _companyBeginDate = DateTime.MinValue;

        /// <summary>当期開始年月度</summary>
        /// <remarks>年月</remarks>
        private DateTime _this_YearMonth = DateTime.MinValue;

        /// <summary>計上年月</summary>
        /// <remarks>現在処理中年月（年月）</remarks>
        private DateTime _addUpYearMonth = DateTime.MinValue;

        /// <summary>自社締日</summary>
        /// <remarks>年月日</remarks>
        private DateTime _secTotalDay = DateTime.MinValue;

        /// <summary>仕入先年間実績照会 検索結果データセット</summary>
        private DateTime _baseDate = DateTime.MinValue;

        /// <summary>仕入金額端数処理コード（金額の丸めに必要）</summary>
        private int _stockPriceFrcProcCd = 0;

        //private PMKOU04110UC _userSetupFrm = null;              // ユーザー設定画面

        /// <summary>SFKTN09002A)拠点アクセスクラス</summary>
        private SecInfoSetAcs _secInfoSetAcs;

        /// <summary>企業コード</summary>
        private string _enterpriseCode;

        /// <summary>本社機能フラグ</summary>
        private bool _mainOfficeFunc;

        /// <summary>現会計年度</summary>
        /// <remarks>開始時に自社設定から取得し、変更されません</remarks>
        private int _currentFinancialYear;

        /// <summary>会計年度</summary>
        private int _financialYear;

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>拠点コードスタート</summary>
        private string _sectionCodeSt = "";

        /// <summary>拠点コード終了</summary>
        private string _sectionCodeEnd = "";

        /// <summary>仕入先コードスタート</summary>
        private Int32 _supplierCdSt;

        /// <summary>仕入先コード終了</summary>
        private Int32 _supplierCdEnd;

        /// <summary>テキスト出力オプション情報</summary>
        private int _opt_TextOutput;

        /// <summary>データセットがnullかどうかフラグ</summary>
        private bool _monthResultNullFlg;
        
        private const int WM_COPYDATA = 0x004A;

        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト
        private Dictionary<OperationCode, bool> _operationAuthorityList;  // 操作権限の制御リスト(直接参照すると遅いのでディクショナリ化)
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// <summary>年度開始月</summary>
        private int _companyBeginMonth;

        //private bool CustomerCk = false; // DEL 2009/01/30
        //private bool startflg = false; // DEL 2009/01/30

        // 2010/04/30 Add >>>
        private string _befortEditSectionCode = "";
        private string _befortEditSectionName = "";
        private int _beforFinancialYear = 0;
        private int _beforSupplierCode = 0;
        private string _beforSupplierName = "";
        private bool isSearch = false;                          // 検索ボタンをクリックするかどうか // ADD 2010/10/27
        // 2010/04/30 Add <<<

        private bool _checkInputScreenErr = false; // ADD 2010/09/09

        // --- ADD 2012/09/18 ---------->>>>>
        // 仕入先総括のオプションコード利用可否設定用フラグ
        // true → 仕入先総括使用する。 false → 仕入先総括使用しない。
        private bool _optSuppSumEnable = false;
        // --- ADD 2012/09/18 ----------<<<<<
        //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
        private TextOutPutOprtnHisLogAcs TextOutPutOprtnHisLogAcsObj = null;
        // メソッド名
        private const string MethodNm = "outputTextData";
        private const string MethodNm2 = "outputExcelData";
        // 出力件数
        private const string CountNumStr = "データ出力件数:{0},";
        /// <summary>仕入先年間実績照会PGID</summary>
        private const string CT_SUPPLIER_YEAR_RESULT_PGID = "PMKOU04110U";
        // アセンブリ名
        private const string AssemblyNm = "仕入年間実績照会";
        // テキストとExcel出力条件
        private const string Con = "拠点:{0} ～ {1},仕入先:{2} ～ {3},対象年度:{4},出力ファイル名:{5}";
        // 最初から
        private const string StartStr = "最初から";
        // 最後まで
        private const string EndStr = "最後まで";
        //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<
        #endregion // プライベート変数

        #region 画面設定用

        /// <summary>ControlScreenSkinクラス</summary>
        private ControlScreenSkin _controlScreenSkin;

        /// <summary>ボタンイメージ用 イメージリスト</summary>
        private ImageList _imageList16 = null;

        #endregion // 画面設定用

        # region プログラムＩＤ

        /// <summary>プログラムＩＤ</summary>
        public const string programID = "PMKOU04100U";

        # endregion // プログラムＩＤ

        // --- ADD 2010/07/20-------------------------------->>>>>
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
            ExcelOut = 2
        }
        #endregion
        // --- ADD 2010/07/20--------------------------------<<<<<

        #region コンストラクタ
        /// <summary>
        /// 仕入先年間実績照会のコンストラクタです。
		/// </summary>
        /// <remarks>
        /// <br>Update Note: 2024/11/22 陳艶丹</br>
        /// <br>管理番号   : 12070203-00</br>
        /// <br>           : PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        /// </remarks>
        public PMKOU04110UA()
		{
			InitializeComponent();

        // --- ADD 2010/07/20-------------------------------->>>>>
            this._userSetupFrm = new PMKOU04110UC();

            #region ●オプション情報
            this.CacheOptionInfo();
            #endregion
        // --- ADD 2010/07/20--------------------------------<<<<<
            //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応---->>>>>
            TextOutPutOprtnHisLogAcsObj = new TextOutPutOprtnHisLogAcs();  //テキスト出力操作ログ登録及び出力時アラートメッセージ表示処理スクラス対象
            //--- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応----<<<<<
        }

        /// <summary>
        /// 仕入実績照会ロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PMKOU04110UA_Load(object sender, EventArgs e)
        {

            #region アクセスクラス初期設定

            // 拠点
            this._secInfoSetAcs = new SecInfoSetAcs();

            // 仕入先
            this._supplierAcs = new SupplierAcs();

            // 支払設定
            this._paymentSetAcs = new PaymentSetAcs();

            // 締日取得モジュール
            this._totalDayCalculator = TotalDayCalculator.GetInstance();
            this._totalDayCalculator.InitializeHisMonthlyAccPay();  // 自社買掛締日取得初期化処理

            // コントロールスキン
            this._controlScreenSkin = new ControlScreenSkin();

            #endregion // アクセスクラス初期設定

            // 仕入年間実績照会アクセスクラス初期化、結果データセット取得
            this._suppYearResultAcs = new SuppYearResultAcs();
            this._dataSet = this._suppYearResultAcs.DataSet;

            #region ログイン情報取得

            // 企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            #endregion //ログイン情報取得

            // 本社/拠点情報を取得する
            this._mainOfficeFunc = this.IsMainOfficeFunc();

            #region 画面設定

            // ボタン設定
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;

            // ツールバーボタンアイコン表示
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BARGRAPH1;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BARGRAPH1; // ADD 2010/02/18

            // --- ADD 2010/07/20-------------------------------->>>>>
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CSVOUTPUT;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CSVOUTPUT;
            // --- ADD 2010/07/20--------------------------------<<<<<

            // ボタンアイコン表示
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = Size16_Index.STAR1;
            this.uButton_SupplierGuide.ImageList = this._imageList16;
            this.uButton_SupplierGuide.Appearance.Image = Size16_Index.STAR1;

            // ログイン情報表示
            this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            // スキンロード
            List<string> controlNameList = new List<string>();
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            #endregion // 画面設定
            
            // 会計年度取得
            this._suppYearResultAcs.GetCompanyInf(this._enterpriseCode, out this._currentFinancialYear, out this._companyBeginMonth);
            this._financialYear = this._currentFinancialYear;

            // 初期値設定
            this.tDateEdit_FinancialYear.SetLongDate(this._financialYear * 10000);

            // 画面クリア
            this.ClearScreen();

            #region データグリッド設定

            // --- ADD 2010/07/20-------------------------------->>>>>
            this.ultraGrid_OutPut.DataSource = this._suppYearResultAcs.OutPutDataView;
            InitializeOutGrid(this.ultraGrid_OutPut.DisplayLayout.Bands[0].Columns);
            // --- ADD 2010/07/20--------------------------------<<<<<

            // データビューを設定
            this.uGrid_Result.DataSource = this._suppYearResultAcs.DataView;

            // データグリッド初期化
            //InitializeGrid(this.uGrid_Result.DisplayLayout.Bands[0].Columns); // DEL 2010/07/20
            InitializeGrid(this.uGrid_Result.DisplayLayout.Bands[0].Columns, true); // ADD 2010/07/20

            // 残高照会タブの初期化
            this.BalanceInquiryInit();

            #endregion // データグリッド設定

            // 画面の初期値を設定
            this.tEdit_SectionCode.Text = CT_SECTIONCODE_WHOLE;
            this.tEdit_SectionName.Text = CT_SECTIONNAME_WHOLE;
        }

        /// <summary>
        /// 初期フォーカス設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PMKOU04110UA_Shown(object sender, System.EventArgs e)
        {
            // 拠点が初期フォーカス
            this.tEdit_SectionCode.Focus();
        }

		# endregion

		# region プライベート変数
        
        
        private const string TOTALDIV_SECT = "拠点";
        private const string TOTALDIV_CUST = "得意先";
        private const string TOTALDIV_SEMP = "担当者";
        private const string TOTALDIV_FEMP = "受注者";
        private const string TOTALDIV_INPU = "発行者";
        private const string TOTALDIV_AREA = "地区";
        private const string TOTALDIV_TYPE = "業種";

        private const int SELECT_CUST = 77;
        private const int SELECT_EMP = 44;
        private const int SELECT_AREA = 44;
        private const int SELECT_TYPE = 44;

		# endregion

        #region 定数

        /// <summary>定数：全社コード「00」</summary>
        private const string CT_SECTIONCODE_WHOLE = "00";

        /// <summary>定数：「全社」</summary>
        private const string CT_SECTIONNAME_WHOLE = "全社";

        /// <summary>エラーメッセージ：「仕入先コードの指定が不正です。」</summary>
        private const string CT_INVALID_SUPPLIERCODE = "仕入先コードの指定が不正です。";

        /// <summary>エラーメッセージ：「年度の指定が不正です。」</summary>
        private const string CT_INVALID_FINANCIALYEAR = "年度の指定が不正です。";

        /// <summary>エラーメッセージ：「該当データが存在しません。」</summary>
        private const string CT_DATA_NOT_FOUND = "該当データが存在しません。";

        /// <summary>エラーメッセージ：「仕入年間実績データの取得に失敗しました。」</summary>
        private const string CT_FAILED_TO_GET_RESULT = "仕入年間実績データの取得に失敗しました。";

        /// <summary>メッセージ：「抽出中」</summary>
        private const string CT_UNDER_PROCESSING_TITLE = "抽出中";

        /// <summary>メッセージ：「仕入年間実績データの抽出中です。」</summary>
        private const string CT_UNDER_PROCESSING = "仕入年間実績データの抽出中です。";

        /// <summary>エラーメッセージ：「翌年度は入力出来ません。」</summary>
        private const string CT_CANNOT_INPUT_FOLLOWING = "翌年度は入力出来ません。";

        /// <summary>エラーメッセージ：「本年度のみ選択可能です。」</summary>
        private const string CT_SHOW_ONLY_CURRENTYEAR = "本年度のみ選択可能です。";

        /// <summary>エラーメッセージ：「本年度または昨年度のみ入力可能です。」</summary>
        private const string CT_CAN_INPUT_ONLY_TWICE = "本年度または昨年度のみ入力可能です。";

        /// <summary>エラーメッセージ：「支払仕入先以外は参照できません。」</summary>
        private const string CT_CANNOT_SHOW_CHILD_SUPPLIER = "支払仕入先以外は参照できません。";

        #endregion

        #region グリッド配色

        /// <summary>グリッド ヘッダーカラー1</summary>
        private readonly Color _headerBackColor1 = Color.FromArgb(89, 135, 214);
        /// <summary>グリッド ヘッダーカラー2</summary>
        private readonly Color _headerBackColor2 = Color.FromArgb(7, 59, 150);
        /// <summary>グリッド 文字色1</summary>
        private readonly Color _headerForeColor1 = Color.FromArgb(255, 255, 255);

        #endregion // グリッド配色

        # region プライベート関数

        #region パラメータチェック

        /// <summary>
        /// パラメータチェック
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool CheckParameters(out string message)
        {
            message = string.Empty;

            // 仕入先コード（必須）
            if (this.tNedit_SupplierCode.GetInt() == 0)
            {
                message = CT_INVALID_SUPPLIERCODE;
                this.tNedit_SupplierCode.Focus();
                return false;
            }

            // 対象年度（必須）
            if (this.tDateEdit_FinancialYear.GetDateYear() == 0)
            {
                message = CT_INVALID_FINANCIALYEAR;
                this.tDateEdit_FinancialYear.Focus();
                return false;
            }

            return true;
        }

        #endregion // パラメータチェック

        #region パラメータ作成

        /// <summary>
        /// パラメータ作成
        /// </summary>
        private void GetParameter()
        {
            _suppYearResultCndtn = new SuppYearResultCndtn();

            // 企業コード
            _suppYearResultCndtn.EnterpriseCode = this._enterpriseCode;

            // 拠点コード
            if (String.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()) ||
                this.tEdit_SectionCode.Text.Trim() == CT_SECTIONCODE_WHOLE)
            {
                _suppYearResultCndtn.SectionCode = string.Empty;
                //_suppYearResultCndtn.AccDiv = 1; // DEL 2009/01/29
                //_suppYearResultCndtn.AccDiv = this._accDiv; // ADD 2009/01/29 DEL 2009/01/30
            }
            else
            {
                _suppYearResultCndtn.SectionCode = this.tEdit_SectionCode.Text.Trim().PadLeft(2, '0');
                // 精算先区分
                //_suppYearResultCndtn.AccDiv = this._accDiv;// DEL 2009/01/30
            }

            // 精算先区分
            _suppYearResultCndtn.AccDiv = this.GetAccDiv(); // ADD 2009/01/30

            // 仕入先コード
            _suppYearResultCndtn.SupplierCd = this.tNedit_SupplierCode.GetInt();

            // 仕入先締日
            _suppYearResultCndtn.SuppTotalDay = this._suppTotalDay;

            // 期首年月日
            _suppYearResultCndtn.CompanyBiginDate = this._companyBeginDate;

            // 当期開始年月度
            _suppYearResultCndtn.This_YearMonth = this._this_YearMonth;

            // 計上年月
            _suppYearResultCndtn.AddUpYearMonth = this._addUpYearMonth;

            // 自社締日
            _suppYearResultCndtn.SecTotalDay = this._secTotalDay;

        }
        #endregion // パラメータ作成

        #region 検索

        /// <summary>
        /// 仕入年間実績照会データの検索を行います。
		/// </summary>
        /// <remarks>
        /// <param name="div">画面区分</param>
        /// </remarks>
        /// <returns>STATUS</returns>
        //private int Search() // DEL 2010/07/20
        private int Search(string div) // ADD 2010/07/20
		{

            // パラメータチェック
            string errorMessage = string.Empty;
            if (!"SubMain".Equals(div) && !CheckParameters(out errorMessage))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    errorMessage, -1, MessageBoxButtons.OK);
                return -1;
            }
            // 画面からパラメータ作成
            GetParameter();
            // --- ADD 2010/07/20-------------------------------->>>>>
            _suppYearResultCndtn.MainDiv = div;
            if ("SubMain".Equals(div))
            {
                // 拠点コードFrom～To
                _suppYearResultCndtn.SectionCodeSt = this._sectionCodeSt;
                _suppYearResultCndtn.SectionCodeEnd = this._sectionCodeEnd;

                // 仕入先コードFrom～To
                _suppYearResultCndtn.SupplierCdSt = this._supplierCdSt;
                _suppYearResultCndtn.SupplierCdEnd = this._supplierCdEnd;
            }
            // --- ADD 2010/07/20--------------------------------<<<<<

            // 日付などを取得
            DateTime paramDate;
            this._suppYearResultAcs.GetCompanyBeginDate(this._enterpriseCode, this._financialYear, out paramDate);

            // 日付設定を再取得
            this._suppYearResultAcs.GetDateParams(this._financialYear, paramDate, this._enterpriseCode);

            // 検索条件に日付などを設定
            this._suppYearResultCndtn.CompanyBiginDate = this._suppYearResultAcs.CompanyBeginDate;
            this._suppYearResultCndtn.This_YearMonth = this._suppYearResultAcs.This_YearMonth;

            if (this._financialYear != this._currentFinancialYear)
            {
                // 前年の時は年度終了日
                this._suppYearResultCndtn.AddUpYearMonth = this._suppYearResultAcs.CompanyBeginDate.AddYears(1).AddDays(-1);
            }
            else
            {
                this._suppYearResultCndtn.AddUpYearMonth = this._suppYearResultAcs.AddUpYearMonth;
            }

            // -- ADD 2010/02/18 ----------------->>>
            //期首年月度から抽出の終了年月度が1年を超えた場合を考慮。
            DateTime dt = this._suppYearResultCndtn.This_YearMonth.AddMonths(11);
            if (dt < this._suppYearResultCndtn.AddUpYearMonth)
            {
                //期首年月から１年を超えた場合は、強制的に１２ヶ月後の年月にする
                _suppYearResultCndtn.AddUpYearMonth = dt;
            }
            // -- ADD 2010/02/18 -----------------<<<

            int status = 0;

            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = CT_UNDER_PROCESSING_TITLE;
            msgForm.Message = CT_UNDER_PROCESSING;
			try
			{
				msgForm.Show();	// ダイアログ表示

                // 仕入金額端数処理区分を渡す
                this._suppYearResultAcs.StockPriceFrcProcCd = this._stockPriceFrcProcCd;

                status = this._suppYearResultAcs.Search(this._suppYearResultCndtn);

            }
			catch (Exception ex)
            {
				TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
					ex.Message,	-1, MessageBoxButtons.OK);
				return -1;
            }
			finally
			{
				msgForm.Close();
			}

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                if (this._dataSet.MonthResult.Rows.Count == 0)
                {
                    // データセットに行を作成
                    this._suppYearResultAcs.SetDataSetBase();
                }
                #region 画面上に展開

                // 画面上に展開
                if (this._dataSet.AccPayResult.Rows.Count > 0)
                {
                    DataRow row = this._dataSet.AccPayResult.Rows[0];   // 一行のみ
                    this.tNedit_bc_1MthMonth.Text = ((Int64)row[this._dataSet.AccPayResult.MonthLastTimeAccPayColumn.ColumnName]).ToString("#,##0");
                    this.tNedit_bc_1MthPayment.Text = ((Int64)row[this._dataSet.AccPayResult.LastTimePaymenColumn.ColumnName]).ToString("#,##0");
                    this.tNedit_bc_2MthPayment.Text = ((Int64)row[this._dataSet.AccPayResult.StockTtl2TmBfBlPayColumn.ColumnName]).ToString("#,##0");
                    this.tNedit_bc_3MthPayment.Text = ((Int64)row[this._dataSet.AccPayResult.StockTtl3TmBfBlPayColumn.ColumnName]).ToString("#,##0");

                    // 伝票枚数[支払]
                    this.tNedit_bc_SlipPayment.Text = ((Int32)row[this._dataSet.AccPayResult.StockSlipCountColumn.ColumnName]).ToString("#,##0");
                    // 仕入[支払] = 今回仕入額
                    this.tNedit_bc_StockPricePayment.Text = ((Int64)row[this._dataSet.AccPayResult.ThisTimeStockPriceColumn.ColumnName]).ToString("#,##0");
                    // 今回返品金額[支払] = 今回返品金額
                    this.tNedit_bc_StckPricRgdsPayment.Text = ((Int64)row[this._dataSet.AccPayResult.ThisStckPricRgdsColumn.ColumnName]).ToString("#,##0");
                    // 今回値引金額[支払] = 今回値引金額
                    this.tNedit_bc_StckPricDisPayment.Text = ((Int64)row[this._dataSet.AccPayResult.ThisStckPricDisColumn.ColumnName]).ToString("#,##0");
                    // 純仕入[支払] = 相殺後今回仕入金額
                    this.tNedit_bc_OfsStockPayment.Text = ((Int64)row[this._dataSet.AccPayResult.OfsThisTimeStockColumn.ColumnName]).ToString("#,##0");
                    // 消費税[支払] = 相殺後今回仕入消費税
                    this.tNedit_bc_OfsStockTaxPayment.Text = ((Int64)row[this._dataSet.AccPayResult.OfsThisStockTaxColumn.ColumnName]).ToString("#,##0");

                    // 伝票枚数[当月]
                    this.tNedit_bc_Slip.Text = ((Int32)row[this._dataSet.AccPayResult.MonthStockSlipCountColumn.ColumnName]).ToString("#,##0");
                    // 仕入[当月] = 当月今回仕入額
                    this.tNedit_bc_StockPrice.Text = ((Int64)row[this._dataSet.AccPayResult.MonthThisTimeStockPriceColumn.ColumnName]).ToString("#,##0");
                    // 今回返品金額[当月] = 当月今回返品金額
                    this.tNedit_bc_StckPricRgds.Text = ((Int64)row[this._dataSet.AccPayResult.MonthThisStckPricRgdsColumn.ColumnName]).ToString("#,##0");
                    // 今回値引金額[当月] = 当月今回値引金額
                    this.tNedit_bc_StckPricDis.Text = ((Int64)row[this._dataSet.AccPayResult.MonthThisStckPricDisColumn.ColumnName]).ToString("#,##0");
                    // 純仕入[当月] = 当月相殺後今回仕入金額
                    this.tNedit_bc_OfsStock.Text = ((Int64)row[this._dataSet.AccPayResult.MonthOfsThisTimeStockColumn.ColumnName]).ToString("#,##0");
                    // 消費税[当月] = 当月相殺後今回仕入消費税
                    this.tNedit_bc_OfsStockTax.Text = ((Int64)row[this._dataSet.AccPayResult.MonthOfsThisStockTaxColumn.ColumnName]).ToString("#,##0");

                    // 伝票枚数[当期]
                    this.tNedit_bc_SlipTerm.Text = ((Int32)row[this._dataSet.AccPayResult.YearStockSlipCountColumn.ColumnName]).ToString("#,##0");
                    // 仕入[当期] = 当期今回仕入額
                    this.tNedit_bc_StockPriceTerm.Text = ((Int64)row[this._dataSet.AccPayResult.YearThisTimeStockPriceColumn.ColumnName]).ToString("#,##0");
                    // 今回返品金額[当期] = 当期今回返品金額
                    this.tNedit_bc_StckPricRgdsTerm.Text = ((Int64)row[this._dataSet.AccPayResult.YearThisStckPricRgdsColumn.ColumnName]).ToString("#,##0");
                    // 今回値引金額[当期] = 当期今回値引金額
                    this.tNedit_bc_StckPricDisTerm.Text = ((Int64)row[this._dataSet.AccPayResult.YearThisStckPricDisColumn.ColumnName]).ToString("#,##0");
                    // 純仕入[当期] = 当期相殺後今回仕入金額
                    this.tNedit_bc_OfsStockTerm.Text = ((Int64)row[this._dataSet.AccPayResult.YearOfsThisTimeStockColumn.ColumnName]).ToString("#,##0");
                    // 消費税[当期] = 当期相殺後今回仕入消費税
                    this.tNedit_bc_OfsStockTaxTerm.Text = ((Int64)row[this._dataSet.AccPayResult.YearOfsThisStockTaxColumn.ColumnName]).ToString("#,##0");

                    // 支払残高[支払] = 仕入合計残高（支払計）
                    this.tNedit_bc_TotalPayBalance.Text = ((Int64)row[this._dataSet.AccPayResult.StockTotalPayBalanceColumn.ColumnName]).ToString("#,##0");
                    // 支払残高[当月] = 当月仕入合計残高（買掛計）
                    this.tNedit_bc_TtlAccPayBalance.Text = ((Int64)row[this._dataSet.AccPayResult.MonthStckTtlAccPayBalanceColumn.ColumnName]).ToString("#,##0");


                    // 支払情報(現金)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.CashePaymenColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment01.Text = ((Int64)row[this._dataSet.AccPayResult.CashePaymenColumn.ColumnName]).ToString("#,##0");
                    }
                    // 支払情報(振込)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.TrfrPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment02.Text = ((Int64)row[this._dataSet.AccPayResult.TrfrPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // 支払情報(小切手)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.CheckKPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment03.Text = ((Int64)row[this._dataSet.AccPayResult.CheckKPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // 支払情報(手形)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.DraftPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment04.Text = ((Int64)row[this._dataSet.AccPayResult.DraftPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // 支払情報(相殺)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.OffsetPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment05.Text = ((Int64)row[this._dataSet.AccPayResult.OffsetPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- DEL 2012/09/18 ---------------------------->>>>>
                    //// 支払情報(口座振替)
                    //if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.FundtransferPaymentColumn.ColumnName].ToString()))
                    //{
                    //    this.tNedit_bc_Payment06.Text = ((Int64)row[this._dataSet.AccPayResult.FundtransferPaymentColumn.ColumnName]).ToString("#,##0");
                    //}
                    //// 支払情報(E-Money)
                    //if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.EmoneyPaymentColumn.ColumnName].ToString()))
                    //{
                    //    this.tNedit_bc_Payment07.Text = ((Int64)row[this._dataSet.AccPayResult.EmoneyPaymentColumn.ColumnName]).ToString("#,##0");
                    //}
                    //// 支払情報(その他)
                    //if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.OtherPaymentColumn.ColumnName].ToString()))
                    //{
                    //    this.tNedit_bc_Payment08.Text = ((Int64)row[this._dataSet.AccPayResult.OtherPaymentColumn.ColumnName]).ToString("#,##0");
                    //}
                    // --- DEL 2012/09/18 ----------------------------<<<<<
                    // --- ADD 2012/09/18 ---------------------------->>>>>
                    // 支払情報(その他)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.OtherPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment06.Text = ((Int64)row[this._dataSet.AccPayResult.OtherPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // 支払情報(口座振替)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.FundtransferPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment07.Text = ((Int64)row[this._dataSet.AccPayResult.FundtransferPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // 支払情報(E-Money)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.EmoneyPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment08.Text = ((Int64)row[this._dataSet.AccPayResult.EmoneyPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- ADD 2012/09/18 ----------------------------<<<<<
                    // 支払情報(手数料)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.ThisTimeFeePayNrmlColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment09.Text = ((Int64)row[this._dataSet.AccPayResult.ThisTimeFeePayNrmlColumn.ColumnName]).ToString("#,##0");
                    }
                    // 支払情報(値引)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.ThisTimeDisPayNrmlColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment10.Text = ((Int64)row[this._dataSet.AccPayResult.ThisTimeDisPayNrmlColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- ADD 2009/02/13 -------------------------------->>>>>
                    // 支払情報(合計)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.PaymentInfoSumColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_PaymentSum.Text = ((Int64)row[this._dataSet.AccPayResult.PaymentInfoSumColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- ADD 2009/02/13 --------------------------------<<<<<

                    // 当月支払情報(現金)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthCashePaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment01c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthCashePaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // 当月支払情報(振込)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthTrfrPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment02c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthTrfrPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- DEL 2012/09/18 ---------------------------->>>>>
                    //// 当月支払情報(小切手)
                    //if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthTrfrPaymentColumn.ColumnName].ToString()))
                    //{
                    //    this.tNedit_bc_Payment03c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthTrfrPaymentColumn.ColumnName]).ToString("#,##0");
                    //}
                    // --- DEL 2012/09/18 ----------------------------<<<<<
                    // --- ADD 2012/09/18 ---------------------------->>>>>
                    // 当月支払情報(小切手)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthCheckKPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment03c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthCheckKPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- ADD 2012/09/18 ----------------------------<<<<<
                    // 当月支払情報(手形)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthDraftPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment04c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthDraftPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // 当月支払情報(相殺)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthOffsetPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment05c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthOffsetPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- DEL 2012/09/18 ---------------------------->>>>>
                    //// 当月支払情報(口座振替)
                    //if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthFundtransferPaymentColumn.ColumnName].ToString()))
                    //{
                    //    this.tNedit_bc_Payment06c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthFundtransferPaymentColumn.ColumnName]).ToString("#,##0");
                    //}
                    //// 当月支払情報(E-Money)
                    //if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthEmoneyPaymentColumn.ColumnName].ToString()))
                    //{
                    //    this.tNedit_bc_Payment07c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthEmoneyPaymentColumn.ColumnName]).ToString("#,##0");
                    //}
                    //// 当月支払情報(その他)
                    //if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthOtherPaymentColumn.ColumnName].ToString()))
                    //{
                    //    this.tNedit_bc_Payment08c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthOtherPaymentColumn.ColumnName]).ToString("#,##0");
                    //}
                    // --- DEL 2012/09/18 ----------------------------<<<<<
                    // --- ADD 2012/09/18 ---------------------------->>>>>
                    // 当月支払情報(その他)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthOtherPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment06c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthOtherPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // 当月支払情報(口座振替)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthFundtransferPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment07c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthFundtransferPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // 当月支払情報(E-Money)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthEmoneyPaymentColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment08c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthEmoneyPaymentColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- ADD 2012/09/18 ----------------------------<<<<<
                    // 当月支払情報(手数料)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthThisTimeFeePayNrmlColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment09c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthThisTimeFeePayNrmlColumn.ColumnName]).ToString("#,##0");
                    }
                    // 当月支払情報(値引)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthThisTimeDisPayNrmlColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_Payment10c.Text = ((Int64)row[this._dataSet.AccPayResult.MonthThisTimeDisPayNrmlColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- ADD 2009/02/13 -------------------------------->>>>>
                    // 当月支払情報(合計)
                    if (!String.IsNullOrEmpty(row[this._dataSet.AccPayResult.MonthPaymentInfoSumColumn.ColumnName].ToString()))
                    {
                        this.tNedit_bc_PaymentSumc.Text = ((Int64)row[this._dataSet.AccPayResult.MonthPaymentInfoSumColumn.ColumnName]).ToString("#,##0");
                    }
                    // --- ADD 2009/02/13 --------------------------------<<<<<
                }
                #endregion // 画面上に展開

                // --- DEL 2009/02/13 -------------------------------->>>>>
                //// 支払情報(合計)
                //this.tNedit_bc_PaymentSum.Text = "0";
                //// 当月支払情報(合計)
                //this.tNedit_bc_PaymentSumc.Text = "0";
                // --- DEL 2009/02/13 --------------------------------<<<<<

                // --- DEL 2009/01/29 -------------------------------->>>>>
                //// タブを見えるように
                //if (this._suppYearResultCndtn.AccDiv == 0)
                //{
                //    this.utc_InventTab.Tabs["BalanceInquiryTab"].Visible = true;
                //}
                // --- DEL 2009/01/29 -------------------------------->>>>>
			}
			else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
						(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
			{
                this.uGrid_Result.SuspendLayout();
                this._dataSet.MonthResult.Rows.Clear();
                _monthResultNullFlg = true; // ADD 2010/07/20
                this._suppYearResultAcs.SetDataSetBase();
                this.uGrid_Result.ResumeLayout();

                if (!"SubMain".Equals(div)) // ADD 2010/07/20
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                        CT_DATA_NOT_FOUND, -1, MessageBoxButtons.OK);

				//this.timer_InitFocusSetting.Enabled = true;
			}
			else
			{
                this.uGrid_Result.SuspendLayout();
                this._dataSet.MonthResult.Rows.Clear();
                _monthResultNullFlg = true; // ADD 2010/07/20
                this._suppYearResultAcs.SetDataSetBase();
                this.uGrid_Result.ResumeLayout();

                if (!"SubMain".Equals(div)) // ADD 2010/07/20
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                        CT_FAILED_TO_GET_RESULT, status, MessageBoxButtons.OK);
				//this.timer_InitFocusSetting.Enabled = true;
			}
		

            // test
            //this.utc_InventTab.Tabs["BalanceInquiryTab"].Visible = true;
            return 0;
        }

        #endregion // 検索

        #region 画面を初期化

        /// <summary>
		/// 画面を初期化します。
		/// </summary>
		private void ClearScreen()
		{
            // 拠点
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tEdit_SectionCode.DataText = CT_SECTIONCODE_WHOLE;
            this.tEdit_SectionName.DataText = CT_SECTIONNAME_WHOLE;

            // 仕入先
            this.tNedit_SupplierCode.Clear();
            this.tEdit_SupplierName.Clear();

            // 対象年度
            this.tDateEdit_FinancialYear.SetLongDate(this._financialYear * 10000);

            // 締日
            this.tEdit_PaymentTotalDay.Clear();

            // 条件
            this.tEdit_PaymentCondName.Clear();
            this.tEdit_PaymentMonthDivName.Clear();
            this.tEdit_PaymentDay.Clear();

            // グラフ表示ボタンを押せなくする
            //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;  // ADD 2010/02/18

            // 2009.01.07 add [9774]
            // データセットをクリア
            this._suppYearResultAcs.ClearDataset();

            // 残高照会のタブを初期設定
            this._suppYearResultAcs.SetDataSetBase();

            // --- DEL 2009/01/29 -------------------------------->>>>>
            //// 残高表示タブが表示されていれば非表示に
            //// タブを見えるように
            //this.utc_InventTab.Tabs["BalanceInquiryTab"].Visible = false;
            // --- DEL 2009/01/29 --------------------------------<<<<<
            // 2009.01.07 add [9774]

            this.isSearch = false; // ADD 2010/10/27

        }

        #endregion // 画面を初期化

        #region グリッド初期化

        /// <summary>
        /// グリッド初期化
        /// </summary>
        /// <param name="Columns"></param>
        /// <br>Update Note : 2010/09/08 楊明俊</br>
        /// <br>            ・障害ID:14443 テキスト出力対応</br>
        //private void InitializeGrid(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns) // DEL 2010/07/20
        private void InitializeGrid(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns, bool hidleFlg) // ADD 2010/07/20
        {
            this.uLabel_HeaderTitle.Appearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.uLabel_HeaderTitle.Appearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.ultraLabel1.Appearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.ultraLabel1.Appearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.ultraLabel2.Appearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.ultraLabel2.Appearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;

            // 列選択ボタン非表示
            this.uGrid_Result.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            // 金額表示
            string moneyFormat = "#,###,##0;-#,###,##0;0";

            // フォントサイズ：11
            //int titlWidth = 59;
            //int defoWidth = 95;   //（11桁）
            //int discWidth = 88;   //（10桁）
            //int rateWidth = 57;   //（ 6桁）
            // フォントサイズ：10
            //int titlWidth = 69;
            //int defoWidth = 97;   //（13桁）
            //int discWidth = 88;   //（10桁）
            //int rateWidth = 50;   //（ 6桁）
            ////int titlWidth = 61;
            ////int defoWidth = 97;     //（13桁）
            ////int discWidth = 83;     //（11桁）
            ////int rateWidth = 54;     //（ 6桁）
            // フォントサイズ：9
            //int defaultWidth13 = 94;     //（13桁）
            //int titlWidth = 61; // DEL 2009/01/30
            //int discWidth = 94;     //（13桁） // DEL 2009/01/30
            //int rateWidth = 54;     //（ 6桁） // DEL 2009/01/30
            // フォントサイズ：8
            //int defaultWidth13 = 80;     //（13桁） // DEL 2010/02/22
            //int titleWidth = 53;
            //int titleWidth = 45;                    // DEL 2010/02/22
            int titleWidth = 48;
            int defaultWidth13 = 90;     //（13桁）ADD 2010/02/22
            int defaultWidth10 = 71;     //（10桁）ADD 2010/02/22


            // 全ての列をいったん非表示に
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in Columns)
            {
                col.Hidden = true;
                
                // ヘッダ設定
                col.Header.Appearance.BackColor = _headerBackColor1;
                col.Header.Appearance.BackColor2 = _headerBackColor2;
                col.Header.Appearance.ForeColor = _headerForeColor1;
                col.Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

                // 共通部分を設定
                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                col.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Left;
                col.CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                //col.CellAppearance.FontData.SizeInPoints = 8f;   // フォントサイズ変更// DEL 2010/02/22
                col.CellAppearance.FontData.SizeInPoints = 9f;   // フォントサイズ変更  // ADD 2010/02/22

                col.Format = moneyFormat;
                col.Width = defaultWidth13;
            }

            // 全ての列を設定
            int visiblePosition = 1;

            // タイトル列(＊月/合計/平均)
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].Width = titleWidth;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].Header.Caption = string.Empty;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.MonthResult.RowTitleColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // --- ADD 2010/07/20-------------------------------->>>>>
            // --- ADD 2010/09/08-------------------------------->>>>>
            // 拠点コード
            Columns[this._dataSet.MonthResult.StockSectionCdColumn.ColumnName].Hidden = hidleFlg;
            //Columns[this._dataSet.MonthResult.StockSectionCdColumn.ColumnName].Header.Caption = "拠点コード";
            Columns[this._dataSet.MonthResult.StockSectionCdColumn.ColumnName].Header.Caption = "拠点";
            Columns[this._dataSet.MonthResult.StockSectionCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 拠点名称
            //Columns[this._dataSet.MonthResult.SectionGuideNmColumn.ColumnName].Hidden = hidleFlg;
            //Columns[this._dataSet.MonthResult.SectionGuideNmColumn.ColumnName].Header.Caption = "拠点名称";
            //Columns[this._dataSet.MonthResult.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 仕入先コード
            Columns[this._dataSet.MonthResult.SupplierCdColumn.ColumnName].Hidden = hidleFlg;
            //Columns[this._dataSet.MonthResult.SupplierCdColumn.ColumnName].Header.Caption = "仕入先コード";
            Columns[this._dataSet.MonthResult.SupplierCdColumn.ColumnName].Header.Caption = "仕入先";
            Columns[this._dataSet.MonthResult.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 仕入先名称
            Columns[this._dataSet.MonthResult.SupplierNmColumn.ColumnName].Hidden = hidleFlg;
            //Columns[this._dataSet.MonthResult.SupplierNmColumn.ColumnName].Header.Caption = "仕入先名称";
            Columns[this._dataSet.MonthResult.SupplierNmColumn.ColumnName].Header.Caption = "仕入先名";
            Columns[this._dataSet.MonthResult.SupplierNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2010/09/08--------------------------------<<<<<
            // --- ADD 2010/07/20--------------------------------<<<<<

            // 在庫（仕入）
            // --- DEL 2009/02/02 -------------------------------->>>>>
            //Columns[this._dataSet.MonthResult.St_StockPriceSumColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.MonthResult.St_StockPriceSumColumn.ColumnName].Header.Caption = "仕入";
            //Columns[this._dataSet.MonthResult.St_StockPriceSumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- DEL 2009/02/02 --------------------------------<<<<<
            // --- ADD 2009/02/02 -------------------------------->>>>>
            Columns[this._dataSet.MonthResult.St_StockPriceTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.St_StockPriceTaxExcColumn.ColumnName].Header.Caption = "仕入";
            Columns[this._dataSet.MonthResult.St_StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2009/02/02 --------------------------------<<<<<

            // 在庫（返品）
            Columns[this._dataSet.MonthResult.St_StockRetGoodsPriceColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.St_StockRetGoodsPriceColumn.ColumnName].Header.Caption = "返品";
            Columns[this._dataSet.MonthResult.St_StockRetGoodsPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MonthResult.St_StockRetGoodsPriceColumn.ColumnName].Width = defaultWidth10;   // ADD 2010/02/22

            // 在庫（値引）
            Columns[this._dataSet.MonthResult.St_StockTotalDiscountColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.St_StockTotalDiscountColumn.ColumnName].Header.Caption = "値引";
            Columns[this._dataSet.MonthResult.St_StockTotalDiscountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MonthResult.St_StockTotalDiscountColumn.ColumnName].Width = defaultWidth10;   // ADD 2010/02/22

            // 在庫（純仕入）
            // --- DEL 2009/02/02 -------------------------------->>>>>
            //Columns[this._dataSet.MonthResult.St_StockPriceTaxExcColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.MonthResult.St_StockPriceTaxExcColumn.ColumnName].Header.Caption = "純仕入";
            //Columns[this._dataSet.MonthResult.St_StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- DEL 2009/02/02 --------------------------------<<<<<
            // --- ADD 2009/02/02 -------------------------------->>>>>
            Columns[this._dataSet.MonthResult.St_StockPriceSumColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.St_StockPriceSumColumn.ColumnName].Header.Caption = "純仕入";
            Columns[this._dataSet.MonthResult.St_StockPriceSumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2009/02/02 --------------------------------<<<<<

            // 取寄（仕入）
            // --- DEL 2009/02/02 -------------------------------->>>>>
            //Columns[this._dataSet.MonthResult.Or_StockPriceSumColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.MonthResult.Or_StockPriceSumColumn.ColumnName].Header.Caption = "仕入";
            //Columns[this._dataSet.MonthResult.Or_StockPriceSumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- DEL 2009/02/02 --------------------------------<<<<<
            // --- ADD 2009/02/02 -------------------------------->>>>>
            Columns[this._dataSet.MonthResult.Or_StockPriceTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.Or_StockPriceTaxExcColumn.ColumnName].Header.Caption = "仕入";
            Columns[this._dataSet.MonthResult.Or_StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2009/02/02 --------------------------------<<<<<

            // 取寄（返品）
            Columns[this._dataSet.MonthResult.Or_StockRetGoodsPriceColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.Or_StockRetGoodsPriceColumn.ColumnName].Header.Caption = "返品";
            Columns[this._dataSet.MonthResult.Or_StockRetGoodsPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MonthResult.Or_StockRetGoodsPriceColumn.ColumnName].Width = defaultWidth10;   // ADD 2010/02/22

            // 取寄（値引）
            Columns[this._dataSet.MonthResult.Or_StockTotalDiscountColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.Or_StockTotalDiscountColumn.ColumnName].Header.Caption = "値引";
            Columns[this._dataSet.MonthResult.Or_StockTotalDiscountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MonthResult.Or_StockTotalDiscountColumn.ColumnName].Width = defaultWidth10;   // ADD 2010/02/22

            // 取寄（純仕入）
            // --- DEL 2009/02/02 -------------------------------->>>>>
            //Columns[this._dataSet.MonthResult.Or_StockPriceTaxExcColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.MonthResult.Or_StockPriceTaxExcColumn.ColumnName].Header.Caption = "純仕入";
            //Columns[this._dataSet.MonthResult.Or_StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- DEL 2009/02/02 --------------------------------<<<<<
            // --- ADD 2009/02/02 -------------------------------->>>>>
            Columns[this._dataSet.MonthResult.Or_StockPriceSumColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.Or_StockPriceSumColumn.ColumnName].Header.Caption = "純仕入";
            Columns[this._dataSet.MonthResult.Or_StockPriceSumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2009/02/02 --------------------------------<<<<<

            // 合計（仕入）
            // --- DEL 2009/02/02 -------------------------------->>>>>
            //Columns[this._dataSet.MonthResult.To_StockPriceSumColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.MonthResult.To_StockPriceSumColumn.ColumnName].Header.Caption = "仕入";
            //Columns[this._dataSet.MonthResult.To_StockPriceSumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- DEL 2009/02/02 --------------------------------<<<<<
            // --- ADD 2009/02/02 -------------------------------->>>>>
            Columns[this._dataSet.MonthResult.To_StockPriceTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.To_StockPriceTaxExcColumn.ColumnName].Header.Caption = "仕入";
            Columns[this._dataSet.MonthResult.To_StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2009/02/02 --------------------------------<<<<<

            // 合計（返品）
            Columns[this._dataSet.MonthResult.To_StockRetGoodsPriceColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.To_StockRetGoodsPriceColumn.ColumnName].Header.Caption = "返品";
            Columns[this._dataSet.MonthResult.To_StockRetGoodsPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MonthResult.To_StockRetGoodsPriceColumn.ColumnName].Width = defaultWidth10;   // ADD 2010/02/22

            // 合計（値引）
            Columns[this._dataSet.MonthResult.To_StockTotalDiscountColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.To_StockTotalDiscountColumn.ColumnName].Header.Caption = "値引";
            Columns[this._dataSet.MonthResult.To_StockTotalDiscountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.MonthResult.To_StockTotalDiscountColumn.ColumnName].Width = defaultWidth10;   // ADD 2010/02/22

            // 合計（純仕入）
            // --- DEL 2009/02/02 -------------------------------->>>>>
            //Columns[this._dataSet.MonthResult.To_StockPriceTaxExcColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.MonthResult.To_StockPriceTaxExcColumn.ColumnName].Header.Caption = "純仕入";
            //Columns[this._dataSet.MonthResult.To_StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- DEL 2009/02/02 --------------------------------<<<<<
            // --- ADD 2009/02/02 -------------------------------->>>>>
            Columns[this._dataSet.MonthResult.To_StockPriceSumColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.MonthResult.To_StockPriceSumColumn.ColumnName].Header.Caption = "純仕入";
            Columns[this._dataSet.MonthResult.To_StockPriceSumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2009/02/02 --------------------------------<<<<<

            // --- ADD 2010/07/20-------------------------------->>>>>
            if(hidleFlg)
            {
            // --- ADD 2010/07/20--------------------------------<<<<<
                // 合計行色変更
                // --- ADD 2009/01/29 -------------------------------->>>>>
                this.uGrid_Result.DisplayLayout.Rows[12].Appearance.BackColor = Color.LightGray;
                this.uGrid_Result.DisplayLayout.Rows[12].Appearance.BackColor2 = Color.LightGray;
                this.uGrid_Result.DisplayLayout.Rows[13].Appearance.BackColor = Color.LightGray;
                this.uGrid_Result.DisplayLayout.Rows[13].Appearance.BackColor2 = Color.LightGray;
                // --- ADD 2009/01/29 --------------------------------<<<<<
            }
        } // ADD 2010/07/20

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// グリッド初期化
        /// </summary>
        /// <param name="Columns"></param>
        /// <br>Update Note : 2010/09/08 楊明俊</br>
        /// <br>            ・障害ID:14443 テキスト出力対応</br>
        private void InitializeOutGrid(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {

            // 列選択ボタン非表示
            this.ultraGrid_OutPut.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            // 金額表示
            string moneyFormat = "#,###,##0;-#,###,##0;0";
            int defaultWidth13 = 90;
            int defaultWidth10 = 140;


            // 全ての列をいったん非表示に
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in Columns)
            {
                col.Hidden = true;

                // ヘッダ設定
                col.Header.Appearance.BackColor = _headerBackColor1;
                col.Header.Appearance.BackColor2 = _headerBackColor2;
                col.Header.Appearance.ForeColor = _headerForeColor1;
                col.Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

                // 共通部分を設定
                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                col.CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Left;
                col.CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                col.CellAppearance.FontData.SizeInPoints = 9f;   // フォントサイズ変更

                col.Format = moneyFormat;
                col.Width = defaultWidth13;
            }

            //年月を設定
            int companyBiginMonth = this._companyBeginMonth;
            string[] monthFlg = new string[12];
            for (int ix = 0; ix < 12; ix++)
            {
                int biginMonth = companyBiginMonth + ix;
                if (biginMonth > 12) { biginMonth = biginMonth - 12; }
                monthFlg[ix] = biginMonth.ToString() + "月";
            }

            // 全ての列を設定
            int visiblePosition = 1;
            // --- ADD 2010/09/08-------------------------------->>>>>
            // 拠点コード
            Columns[this._dataSet.OutPutResult.StockSectionCdColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OutPutResult.StockSectionCdColumn.ColumnName].Header.Caption = "拠点コード";
            Columns[this._dataSet.OutPutResult.StockSectionCdColumn.ColumnName].Header.Caption = "拠点";
            Columns[this._dataSet.OutPutResult.StockSectionCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OutPutResult.StockSectionCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 拠点名称
            //Columns[this._dataSet.OutPutResult.SectionGuideNmColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OutPutResult.SectionGuideNmColumn.ColumnName].Header.Caption = "拠点名称";
            //Columns[this._dataSet.OutPutResult.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.OutPutResult.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 仕入先コード
            Columns[this._dataSet.OutPutResult.SupplierCdColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OutPutResult.SupplierCdColumn.ColumnName].Header.Caption = "仕入先コード";
            Columns[this._dataSet.OutPutResult.SupplierCdColumn.ColumnName].Header.Caption = "仕入先";
            Columns[this._dataSet.OutPutResult.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OutPutResult.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 仕入先名称
            Columns[this._dataSet.OutPutResult.SupplierNmColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OutPutResult.SupplierNmColumn.ColumnName].Header.Caption = "仕入先名称";
            Columns[this._dataSet.OutPutResult.SupplierNmColumn.ColumnName].Header.Caption = "仕入先名";
            Columns[this._dataSet.OutPutResult.SupplierNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OutPutResult.SupplierNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2010/09/08--------------------------------<<<<<
            // 当期実績・仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_1_MonthColumn.ColumnName].Header.Caption = "当期実績・仕入(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・返品
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_1_MonthColumn.ColumnName].Header.Caption = "当期実績・返品(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・値引
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_1_MonthColumn.ColumnName].Header.Caption = "当期実績・値引(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・純仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_1_MonthColumn.ColumnName].Header.Caption = "当期実績・純仕入(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_2_MonthColumn.ColumnName].Header.Caption = "当期実績・仕入(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・返品
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_2_MonthColumn.ColumnName].Header.Caption = "当期実績・返品(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・値引
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_2_MonthColumn.ColumnName].Header.Caption = "当期実績・値引(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・純仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_2_MonthColumn.ColumnName].Header.Caption = "当期実績・純仕入(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_3_MonthColumn.ColumnName].Header.Caption = "当期実績・仕入(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・返品
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_3_MonthColumn.ColumnName].Header.Caption = "当期実績・返品(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・値引
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_3_MonthColumn.ColumnName].Header.Caption = "当期実績・値引(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・純仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_3_MonthColumn.ColumnName].Header.Caption = "当期実績・純仕入(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_4_MonthColumn.ColumnName].Header.Caption = "当期実績・仕入(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・返品
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_4_MonthColumn.ColumnName].Header.Caption = "当期実績・返品(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・値引
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_4_MonthColumn.ColumnName].Header.Caption = "当期実績・値引(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・純仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_4_MonthColumn.ColumnName].Header.Caption = "当期実績・純仕入(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_5_MonthColumn.ColumnName].Header.Caption = "当期実績・仕入(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・返品
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_5_MonthColumn.ColumnName].Header.Caption = "当期実績・返品(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・値引
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_5_MonthColumn.ColumnName].Header.Caption = "当期実績・値引(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・純仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_5_MonthColumn.ColumnName].Header.Caption = "当期実績・純仕入(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_6_MonthColumn.ColumnName].Header.Caption = "当期実績・仕入(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・返品
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_6_MonthColumn.ColumnName].Header.Caption = "当期実績・返品(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・値引
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_6_MonthColumn.ColumnName].Header.Caption = "当期実績・値引(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・純仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_6_MonthColumn.ColumnName].Header.Caption = "当期実績・純仕入(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_7_MonthColumn.ColumnName].Header.Caption = "当期実績・仕入(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・返品
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_7_MonthColumn.ColumnName].Header.Caption = "当期実績・返品(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・値引
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_7_MonthColumn.ColumnName].Header.Caption = "当期実績・値引(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・純仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_7_MonthColumn.ColumnName].Header.Caption = "当期実績・純仕入(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_8_MonthColumn.ColumnName].Header.Caption = "当期実績・仕入(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・返品
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_8_MonthColumn.ColumnName].Header.Caption = "当期実績・返品(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・値引
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_8_MonthColumn.ColumnName].Header.Caption = "当期実績・値引(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・純仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_8_MonthColumn.ColumnName].Header.Caption = "当期実績・純仕入(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_9_MonthColumn.ColumnName].Header.Caption = "当期実績・仕入(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・返品
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_9_MonthColumn.ColumnName].Header.Caption = "当期実績・返品(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・値引
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_9_MonthColumn.ColumnName].Header.Caption = "当期実績・値引(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・純仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_9_MonthColumn.ColumnName].Header.Caption = "当期実績・純仕入(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_10_MonthColumn.ColumnName].Header.Caption = "当期実績・仕入(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・返品
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_10_MonthColumn.ColumnName].Header.Caption = "当期実績・返品(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・値引
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_10_MonthColumn.ColumnName].Header.Caption = "当期実績・値引(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・純仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_10_MonthColumn.ColumnName].Header.Caption = "当期実績・純仕入(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_11_MonthColumn.ColumnName].Header.Caption = "当期実績・仕入(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・返品
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_11_MonthColumn.ColumnName].Header.Caption = "当期実績・返品(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・値引
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_11_MonthColumn.ColumnName].Header.Caption = "当期実績・値引(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・純仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_11_MonthColumn.ColumnName].Header.Caption = "当期実績・純仕入(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_12_MonthColumn.ColumnName].Header.Caption = "当期実績・仕入(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceTaxExc_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・返品
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_12_MonthColumn.ColumnName].Header.Caption = "当期実績・返品(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockRetGoodsPrice_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・値引
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_12_MonthColumn.ColumnName].Header.Caption = "当期実績・値引(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockTotalDiscount_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // 当期実績・純仕入
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_12_MonthColumn.ColumnName].Header.Caption = "当期実績・純仕入(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.To_StockPriceSum_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_1_MonthColumn.ColumnName].Header.Caption = "在庫・仕入(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・返品
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_1_MonthColumn.ColumnName].Header.Caption = "在庫・返品(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・値引
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_1_MonthColumn.ColumnName].Header.Caption = "在庫・値引(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・純仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_1_MonthColumn.ColumnName].Header.Caption = "在庫・純仕入(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_2_MonthColumn.ColumnName].Header.Caption = "在庫・仕入(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・返品
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_2_MonthColumn.ColumnName].Header.Caption = "在庫・返品(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・値引
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_2_MonthColumn.ColumnName].Header.Caption = "在庫・値引(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・純仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_2_MonthColumn.ColumnName].Header.Caption = "在庫・純仕入(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_3_MonthColumn.ColumnName].Header.Caption = "在庫・仕入(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・返品
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_3_MonthColumn.ColumnName].Header.Caption = "在庫・返品(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・値引
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_3_MonthColumn.ColumnName].Header.Caption = "在庫・値引(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・純仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_3_MonthColumn.ColumnName].Header.Caption = "在庫・純仕入(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_4_MonthColumn.ColumnName].Header.Caption = "在庫・仕入(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・返品
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_4_MonthColumn.ColumnName].Header.Caption = "在庫・返品(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・値引
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_4_MonthColumn.ColumnName].Header.Caption = "在庫・値引(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・純仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_4_MonthColumn.ColumnName].Header.Caption = "在庫・純仕入(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_5_MonthColumn.ColumnName].Header.Caption = "在庫・仕入(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・返品
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_5_MonthColumn.ColumnName].Header.Caption = "在庫・返品(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・値引
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_5_MonthColumn.ColumnName].Header.Caption = "在庫・値引(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・純仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_5_MonthColumn.ColumnName].Header.Caption = "在庫・純仕入(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_6_MonthColumn.ColumnName].Header.Caption = "在庫・仕入(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・返品
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_6_MonthColumn.ColumnName].Header.Caption = "在庫・返品(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・値引
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_6_MonthColumn.ColumnName].Header.Caption = "在庫・値引(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・純仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_6_MonthColumn.ColumnName].Header.Caption = "在庫・純仕入(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_7_MonthColumn.ColumnName].Header.Caption = "在庫・仕入(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・返品
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_7_MonthColumn.ColumnName].Header.Caption = "在庫・返品(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・値引
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_7_MonthColumn.ColumnName].Header.Caption = "在庫・値引(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・純仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_7_MonthColumn.ColumnName].Header.Caption = "在庫・純仕入(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_8_MonthColumn.ColumnName].Header.Caption = "在庫・仕入(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・返品
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_8_MonthColumn.ColumnName].Header.Caption = "在庫・返品(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・値引
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_8_MonthColumn.ColumnName].Header.Caption = "在庫・値引(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・純仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_8_MonthColumn.ColumnName].Header.Caption = "在庫・純仕入(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_9_MonthColumn.ColumnName].Header.Caption = "在庫・仕入(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・返品
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_9_MonthColumn.ColumnName].Header.Caption = "在庫・返品(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・値引
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_9_MonthColumn.ColumnName].Header.Caption = "在庫・値引(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・純仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_9_MonthColumn.ColumnName].Header.Caption = "在庫・純仕入(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_10_MonthColumn.ColumnName].Header.Caption = "在庫・仕入(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・返品
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_10_MonthColumn.ColumnName].Header.Caption = "在庫・返品(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・値引
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_10_MonthColumn.ColumnName].Header.Caption = "在庫・値引(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・純仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_10_MonthColumn.ColumnName].Header.Caption = "在庫・純仕入(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_11_MonthColumn.ColumnName].Header.Caption = "在庫・仕入(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・返品
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_11_MonthColumn.ColumnName].Header.Caption = "在庫・返品(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・値引
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_11_MonthColumn.ColumnName].Header.Caption = "在庫・値引(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・純仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_11_MonthColumn.ColumnName].Header.Caption = "在庫・純仕入(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_12_MonthColumn.ColumnName].Header.Caption = "在庫・仕入(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceTaxExc_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・返品
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_12_MonthColumn.ColumnName].Header.Caption = "在庫・返品(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockRetGoodsPrice_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・値引
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_12_MonthColumn.ColumnName].Header.Caption = "在庫・値引(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockTotalDiscount_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // 在庫・純仕入
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_12_MonthColumn.ColumnName].Header.Caption = "在庫・純仕入(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.St_StockPriceSum_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_1_MonthColumn.ColumnName].Header.Caption = "取寄・仕入(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・返品
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_1_MonthColumn.ColumnName].Header.Caption = "取寄・返品(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・値引
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_1_MonthColumn.ColumnName].Header.Caption = "取寄・値引(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・純仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_1_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_1_MonthColumn.ColumnName].Header.Caption = "取寄・純仕入(" + monthFlg[0] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_1_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_1_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_2_MonthColumn.ColumnName].Header.Caption = "取寄・仕入(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・返品
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_2_MonthColumn.ColumnName].Header.Caption = "取寄・返品(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・値引
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_2_MonthColumn.ColumnName].Header.Caption = "取寄・値引(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・純仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_2_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_2_MonthColumn.ColumnName].Header.Caption = "取寄・純仕入(" + monthFlg[1] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_2_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_2_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_3_MonthColumn.ColumnName].Header.Caption = "取寄・仕入(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・返品
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_3_MonthColumn.ColumnName].Header.Caption = "取寄・返品(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・値引
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_3_MonthColumn.ColumnName].Header.Caption = "取寄・値引(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・純仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_3_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_3_MonthColumn.ColumnName].Header.Caption = "取寄・純仕入(" + monthFlg[2] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_3_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_3_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_4_MonthColumn.ColumnName].Header.Caption = "取寄・仕入(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・返品
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_4_MonthColumn.ColumnName].Header.Caption = "取寄・返品(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・値引
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_4_MonthColumn.ColumnName].Header.Caption = "取寄・値引(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・純仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_4_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_4_MonthColumn.ColumnName].Header.Caption = "取寄・純仕入(" + monthFlg[3] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_4_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_4_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_5_MonthColumn.ColumnName].Header.Caption = "取寄・仕入(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・返品
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_5_MonthColumn.ColumnName].Header.Caption = "取寄・返品(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・値引
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_5_MonthColumn.ColumnName].Header.Caption = "取寄・値引(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・純仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_5_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_5_MonthColumn.ColumnName].Header.Caption = "取寄・純仕入(" + monthFlg[4] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_5_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_5_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_6_MonthColumn.ColumnName].Header.Caption = "取寄・仕入(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・返品
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_6_MonthColumn.ColumnName].Header.Caption = "取寄・返品(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・値引
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_6_MonthColumn.ColumnName].Header.Caption = "取寄・値引(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・純仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_6_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_6_MonthColumn.ColumnName].Header.Caption = "取寄・純仕入(" + monthFlg[5] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_6_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_6_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_7_MonthColumn.ColumnName].Header.Caption = "取寄・仕入(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・返品
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_7_MonthColumn.ColumnName].Header.Caption = "取寄・返品(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・値引
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_7_MonthColumn.ColumnName].Header.Caption = "取寄・値引(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・純仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_7_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_7_MonthColumn.ColumnName].Header.Caption = "取寄・純仕入(" + monthFlg[6] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_7_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_7_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_8_MonthColumn.ColumnName].Header.Caption = "取寄・仕入(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・返品
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_8_MonthColumn.ColumnName].Header.Caption = "取寄・返品(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・値引
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_8_MonthColumn.ColumnName].Header.Caption = "取寄・値引(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・純仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_8_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_8_MonthColumn.ColumnName].Header.Caption = "取寄・純仕入(" + monthFlg[7] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_8_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_8_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_9_MonthColumn.ColumnName].Header.Caption = "取寄・仕入(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・返品
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_9_MonthColumn.ColumnName].Header.Caption = "取寄・返品(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・値引
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_9_MonthColumn.ColumnName].Header.Caption = "取寄・値引(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・純仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_9_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_9_MonthColumn.ColumnName].Header.Caption = "取寄・純仕入(" + monthFlg[8] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_9_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_9_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_10_MonthColumn.ColumnName].Header.Caption = "取寄・仕入(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・返品
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_10_MonthColumn.ColumnName].Header.Caption = "取寄・返品(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・値引
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_10_MonthColumn.ColumnName].Header.Caption = "取寄・値引(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・純仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_10_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_10_MonthColumn.ColumnName].Header.Caption = "取寄・純仕入(" + monthFlg[9] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_10_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_10_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_11_MonthColumn.ColumnName].Header.Caption = "取寄・仕入(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・返品
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_11_MonthColumn.ColumnName].Header.Caption = "取寄・返品(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・値引
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_11_MonthColumn.ColumnName].Header.Caption = "取寄・値引(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・純仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_11_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_11_MonthColumn.ColumnName].Header.Caption = "取寄・純仕入(" + monthFlg[10] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_11_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_11_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_12_MonthColumn.ColumnName].Header.Caption = "取寄・仕入(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceTaxExc_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・返品
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_12_MonthColumn.ColumnName].Header.Caption = "取寄・返品(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockRetGoodsPrice_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・値引
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_12_MonthColumn.ColumnName].Header.Caption = "取寄・値引(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockTotalDiscount_12_MonthColumn.ColumnName].Width = defaultWidth10;

            // 取寄・純仕入
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_12_MonthColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_12_MonthColumn.ColumnName].Header.Caption = "取寄・純仕入(" + monthFlg[11] + ")";
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_12_MonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.OutPutResult.Or_StockPriceSum_12_MonthColumn.ColumnName].Width = defaultWidth10;

        }
        // --- ADD 2010/07/20--------------------------------<<<<<


        /// <summary>
        /// GRIDの初期化を行います。
        /// </summary>
        private void ViewGrid()
        {
            //this._suppYearResultAcs.Clear();
            //this._suppYearResultAcs.SetDataSetBase(this.tDateEdit_FinancialYear.GetDateYear(),this.tComboEditor_TotalDiv.SelectedIndex);
            //if (this.tDateEdit_FinancialYear.GetDateYear() == this._financialYear)
            //{
            //    this.ultraLabel1.Text = "当期実績";
            //}
            //else
            //{
            //    this.ultraLabel1.Text = "対象年度実績";
            //}


        }

        #endregion // グリッド初期化

        #region グラフ表示

        /// <summary>
		/// グラフの表示を行います
		/// </summary>
        private void ViewGraph()
        {
            #region 削除
            //if ((this._resultData == null) || (this._resultData.MonthResult.Count == 0)) return;

            //// 共通処理中画面生成
            //SFCMN00299CA progressForm = new SFCMN00299CA();
            //progressForm.DispCancelButton = false;
            //progressForm.Title = "分析チャート作成中";
            //progressForm.Message = "現在、分析チャート作成中です．．．";

            //try
            //{
            //    // 共通処理中画面表示
            //    progressForm.Show();

            //    // タブページに既にコントロールが有る場合はクリアする
            //    if (this.ultraTabPageControl2.Controls.Count > 0)
            //    {
            //        this.ultraTabPageControl2.Controls.Remove(this.ultraTabPageControl2.Controls[0]);
            //    }

            //    AnalysisChartViewForm viewForm = new AnalysisChartViewForm(this);
            //    viewForm.TopLevel = false;
            //    viewForm.FormBorderStyle = FormBorderStyle.None;
            //    viewForm.ShowMe(this._resultData);

            //    // タブページに分析チャートビューフォームを追加
            //    ultraTabPageControl2.Controls.Add(viewForm);
            //    viewForm.Dock = DockStyle.Fill;

            //    this.utc_InventTab.Tabs["GraphTab"].Visible = true;
            //    this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectNextTab);
            //    //this.utc_InventTab.Scroll(Infragistics.Win.UltraWinTabs.ScrollType.First);
            //}
            //catch (Exception ex)
            //{
            //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMKOU04110UA.programID, "タブ画面の初期化に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
            //}
            //finally
            //{
            //    // 共通処理中画面終了
            //    progressForm.Close();
            //}
            #endregion

            // -- ADD 2010/02/18 --------------------------->>>
            if ((this._dataSet == null) || (this._dataSet.MonthResult.Count == 0)) return;

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
                viewForm.ShowMe(this._dataSet);

                // タブページに分析チャートビューフォームを追加
                ultraTabPageControl2.Controls.Add(viewForm);
                viewForm.Dock = DockStyle.Fill;

                this.utc_InventTab.Tabs["GraphTab"].Visible = true;
                //this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectNextTab);
                this.utc_InventTab.SelectedTab = this.utc_InventTab.Tabs["GraphTab"];

                //this.utc_InventTab.Scroll(Infragistics.Win.UltraWinTabs.ScrollType.First);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, PMKOU04110UA.programID, "タブ画面の初期化に失敗しました。" + "\r\n" + ex.Message, 0, MessageBoxButtons.OK);
            }
            finally
            {
                // 共通処理中画面終了
                progressForm.Close();
            }
            // -- ADD 2010/02/18 ---------------------------<<<

        }

        #endregion グラフ表示

        // --- ADD 2009/01/30 -------------------------------->>>>>
        #region 精算先区分取得
        /// <summary>
        /// 精算先区分取得処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>0:支払仕入先(残高照会する)、1:支払仕入先でない</remarks>
        private int GetAccDiv()
        {
            if (String.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim())
                || this.tNedit_SupplierCode.GetInt() == 0)
            {
                // 拠点、仕入先の入力が無ければ子(1)
                return 1;
            }

            Supplier supplier;

            int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, this.tNedit_SupplierCode.GetInt());

            if (status == 0)
            {
                if (supplier.MngSectionCode.TrimEnd() == this.tEdit_SectionCode.Text
                    && supplier.MngSectionCode == supplier.PaymentSectionCode
                    && supplier.SupplierCd == supplier.PayeeCode)
                {
                    // 「管理拠点=画面指定の拠点」かつ「管理拠点=支払拠点」かつ「仕入先コード=支払先コード」
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }
        #endregion

        #endregion
        // --- ADD 2009/01/30 --------------------------------<<<<<

        # region 各種コントロールイベント処理

        #region フォーカスコントロール

        /// <summary>
		/// フォーカスコントロールイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note : 2010/09/21 李永平</br>
        /// <br>            : Redmine#14876対応</br>
        /// <br>Update Note : 2010/09/26 tianjw</br>
        /// <br>            : Redmine#14876対応</br>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null) return;

            //// フォーカス制御 ============================================ //
            //if ((e.PrevCtrl == this.tNedit_SupplierCode) ||
            //    (e.PrevCtrl == this.tEdit_EmployeeCode) ||
            //    (e.PrevCtrl == this.uButton_SupplierGuide))
            //{
            //    if (e.Key == Keys.Down)
            //    {
            //        e.NextCtrl = e.PrevCtrl;
            //    }
            //}
            //if ((this.tNedit_SupplierCode.Visible == false) && (this.tEdit_EmployeeCode.Visible == false) &&
            //   ((e.PrevCtrl == this.tEdit_SectionCode) || (e.PrevCtrl == this.uButton_SectionGuide)))
            //{
            //    if (e.Key == Keys.Down)
            //    {
            //        e.NextCtrl = e.PrevCtrl;
            //    }
            //}

			// 名称取得 ============================================ //
            switch (e.PrevCtrl.Name)
            {
                #region 拠点コード
                case "tEdit_SectionCode":
                    {
                        //string code = this.tEdit_SectionCode.Text.PadLeft(2, '0'); // DEL 2010/09/26
                        string code = this.tEdit_SectionCode.Text.Trim(); // ADD 2010/09/26
                        string name = CT_SECTIONNAME_WHOLE;
                        this._checkInputScreenErr = false;
                        if (code != "")
                        {
                            SecInfoSet secInfoSet;
                            int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, code);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // --------UPD 2010/09/21-------->>>>>
                                //code = sectionInfo.SectionCode.TrimEnd();
                                //name = sectionInfo.SectionGuideSnm.TrimEnd();
                                //return true;

                                if (secInfoSet.LogicalDeleteCode != 0)
                                {
                                    // エラー時
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "拠点コードが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    isError = true; // 2010/09/26
                                    // コード戻す
                                    this.tEdit_SectionCode.Text = _befortEditSectionCode;
                                    this.tEdit_SectionName.Text = _befortEditSectionName;
                                    this.tEdit_SectionCode.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                    _checkInputScreenErr = true;
                                    return;
                                }
                                else
                                {
                                    code = secInfoSet.SectionCode.TrimEnd();
                                    name = secInfoSet.SectionGuideSnm.TrimEnd();
                                }
                                // --------UPD 2010/09/21--------<<<<<
                                // 2010/04/30 Add >>>
                                if (this._befortEditSectionCode.Equals(code) == false)
                                {
                                    this.BalanceInquiryInit();
                                    this._suppYearResultAcs.ClearDataset();
                                    this._suppYearResultAcs.SetDataSetBase();
                                    this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                                    this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectFirstTab);
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                                    this._befortEditSectionCode = code;
                                    this._befortEditSectionName = name;
                                }
                                // 2010/04/30 Add <<<
                                name = secInfoSet.SectionGuideNm.Trim();

                                //status = GetTotalDay(code); // DEL 2009/02/13

                                // --- ADD 2009/02/13 -------------------------------->>>>>
                                // 締日情報を取得
                                if (this.tNedit_SupplierCode.GetInt() != 0)
                                {
                                    status = GetTotalDay(code, this.tNedit_SupplierCode.GetInt());
                                }
                                // --- ADD 2009/02/13 --------------------------------<<<<<
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                    "拠点が存在しません。", -1, MessageBoxButtons.OK);
                                isError = true; // 2010/09/26
                                code = CT_SECTIONCODE_WHOLE;
                                this.tEdit_SectionCode.SelectAll();
                                e.NextCtrl = e.PrevCtrl;
                            }
                            else
                            {
                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                    "拠点の取得に失敗しました。", -1, MessageBoxButtons.OK);
                                code = CT_SECTIONCODE_WHOLE;
                            }
                        }
                        else
                        {
                            code = CT_SECTIONCODE_WHOLE;
                        }
                        // コード・名称セット
                        this.tEdit_SectionCode.Text = code;
                        this.tEdit_SectionName.Text = name;
                        this._befortEditSectionCode = code;
                        this._befortEditSectionName = name;

                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (String.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
                                    {
                                        e.NextCtrl = this.uButton_SectionGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_SupplierCode;
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 拠点コード

                #region 仕入先コード
                case "tNedit_SupplierCode":
                    {
                        int code = this.tNedit_SupplierCode.GetInt();
                        string name = "";
                        this._checkInputScreenErr = false;
                        if (code > 0)
                        {
                            Supplier supplier;
                            int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, code);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // --------UPD 2010/09/21-------->>>>>

                                if (supplier.LogicalDeleteCode != 0)
                                {
                                    // エラー時
                                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                        "仕入先コードが存在しません。", -1, MessageBoxButtons.OK);

                                    isError = true; // 2010/09/26
                                    // コード戻す
                                    this.tNedit_SupplierCode.Text = this._beforSupplierCode + "";
                                    this.tEdit_SupplierName.Text = this._beforSupplierName;
                                    this.tNedit_SupplierCode.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                    _checkInputScreenErr = true;
                                    return;
                                }
                                else
                                {
                                    code = supplier.SupplierCd;
                                    name = supplier.SupplierSnm.TrimEnd();
                                }
                                // --------UPD 2010/09/21--------<<<<<

                                // 2010/04/30 Add >>>
                                if (this._beforSupplierCode.Equals(code) == false)
                                {
                                    this.BalanceInquiryInit();
                                    this._suppYearResultAcs.ClearDataset();
                                    this._suppYearResultAcs.SetDataSetBase();
                                    this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectFirstTab);
                                    this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                                }
                                // 2010/04/30 Add <<<
                                this._beforSupplierCode = code;
                                this._beforSupplierName = name;
                                this.tNedit_SupplierCode.SetInt(code);
                                this.tEdit_SupplierName.Text = name;

                                // 精算先区分を取得
                                GetSettingFromSupplierInfo(supplier);

                                // --- ADD 2009/02/13 -------------------------------->>>>>
                                // 締日情報を取得
                                if (!string.IsNullOrEmpty(this.tEdit_SectionCode.Text))
                                {
                                    status = GetTotalDay(this.tEdit_SectionCode.Text.Trim().PadLeft(2, '0'), supplier.SupplierCd);
                                }
                                // --- ADD 2009/02/13 --------------------------------<<<<<
                            }
                            else
                            {
                                // --- ADD 2009/01/28 -------------------------------->>>>>
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                        "仕入先コードが存在しません。", -1, MessageBoxButtons.OK);
                                    isError = true; // 2010/09/26
                                }
                                else
                                {
                                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                        "仕入先コードの取得に失敗しました。", -1, MessageBoxButtons.OK);
                                }
                                // --- ADD 2009/01/28 --------------------------------<<<<<

                                this.tNedit_SupplierCode.Clear();
                                this.tEdit_SupplierName.Clear();

                                // 仕入先から取得される情報をリセット
                                GetSettingFromSupplierInfo(null);
                            }
                        }
                        else
                        {
                            // 2009.01.05 add [9652]
                            this.tEdit_SupplierName.Clear();
                            GetSettingFromSupplierInfo(null);
                        }

                        // NextCtrl制御
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    if (String.IsNullOrEmpty(this.tNedit_SupplierCode.Text.Trim())) // 2009.01.05 [9651]
                                    {
                                        e.NextCtrl = this.uButton_SupplierGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tDateEdit_FinancialYear;
                                    }

                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 仕入先コード

                #region 対象年度
                case "tDateEdit_FinancialYear":
                    {
                        int year = this.tDateEdit_FinancialYear.GetDateYear();
                        if (year == 0)
                        {
                            this.tDateEdit_FinancialYear.SetLongDate(this._financialYear * 10000);
                            e.NextCtrl = e.PrevCtrl;
                        }
                        else
                        {
                            // 2010/04/30 Add >>>
                            if (this._beforFinancialYear.Equals(year) == false)
                            {
                                this.BalanceInquiryInit();
                                this._suppYearResultAcs.ClearDataset();
                                this._suppYearResultAcs.SetDataSetBase();
                                this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectFirstTab);
                                this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                                this._beforFinancialYear = year;
                            }
                            // 2010/04/30 Add <<<
                            // NextCtrl制御
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tEdit_SectionCode;
                                    }
                                    break;
                            }
                        }
                        break;
                    }

                #endregion // 対象年度
            }
        }

        #endregion // フォーカスコントロール

        #region ツールバー

        /// <summary>
		/// ツールバーツールクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note : 2010/09/21 李永平</br>
        /// <br>            : Redmine#14876対応</br>
		private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
            {
                #region 閉じる
                case "ButtonTool_Close":
				    {
					    this.Close();
					    break;
                    }
                #endregion // 閉じる

                #region クリア
                case "ButtonTool_Clear":
				    {
                        this.ViewGrid();
                        //this.ShipmentInit();
                        this.BalanceInquiryInit();
					    this.ClearScreen();
					    this.timer_InitFocusSetting.Enabled = true;

                        //this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                        this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectFirstTab);
                        this.utc_InventTab.Tabs["GraphTab"].Visible = false;  // ADD 2010/02/18
                        this.isSearch = false; // ADD 2010/10/27
                        break;
                    }
                #endregion // クリア

                #region 検索
                case "ButtonTool_Search":
				    {
                        //this.SetDataSetBase();
                        //this.ShipmentInit();
                        //this.BalanceInquiryInit();
                        // 2010/04/30 >>>
                        //this.Search();
                        //int status = this.Search(); // DEL 2010/07/20

                        this.isSearch = true; // ADD 2010/10/27
                        // ---------------UPD 2010/09/21--------------<<<<<
                        if (this.tEdit_SectionCode.Focused)
                        {
                            ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCode, this.tNedit_SupplierCode);
                            this.tEdit_SectionCode.Text = this.uiSetControl1.GetZeroPaddedText(this.tEdit_SectionCode.Name, this.tEdit_SectionCode.Text);
                            tArrowKeyControl1_ChangeFocus(null, eArgs);
                            if (isError == true)
                            {
                                isError = false;
                                return;
                            }
                        }

                        if (this.tNedit_SupplierCode.Focused)
                        {
                            ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tNedit_SupplierCode, this.tDateEdit_FinancialYear);
                            this.tDateEdit_FinancialYear.Text = this.uiSetControl1.GetZeroPaddedText(this.tDateEdit_FinancialYear.Name, this.tDateEdit_FinancialYear.Text);
                            tArrowKeyControl1_ChangeFocus(null, eArgs);
                            if (isError == true)
                            {
                                isError = false;
                                return;
                            }
                        }

                        if (!_checkInputScreenErr)
                        {
                            int status = this.Search("Main"); // ADD 2010/07/20
                            // 2010/04/30 <<<

                            //this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                            this.utc_InventTab.Tabs["GraphTab"].Visible = false;  // ADD 2010/02/18
                            this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectFirstTab);
                            //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = true;
                            if (status == 0)   // 2010/04/30 Add
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = true; // ADD 2010/02/18
                        }
                        // ---------------UPD 2010/09/21-------------->>>>>
                            break;
                    }
                #endregion // 検索

                // --- DEL 2009/01/28 -------------------------------->>>>>
                //#region グラフ表示
                //case "ButtonTool_Graph":
                //    {
                //        this.ViewGraph();
                //        this.utc_InventTab.Focus();
                //        break;
                //    }
                //#endregion // グラフ表示

                //#region 設定
                //case "ButtonTool_Setup":
                //    {
                //        //if (this._userSetupFrm == null)
                //        //    this._userSetupFrm = new PMKOU04110UC();

                //        //this._userSetupFrm.ShowDialog();
                //        break;
                //    }
                //#endregion // 設定
                // --- DEL 2009/01/28 --------------------------------<<<<<

                // -- ADD 2010/02/18 ------------------->>>
                #region グラフ表示
                case "ButtonTool_Graph":
                    {
                        this.ViewGraph();
                        this.utc_InventTab.Focus();
                        break;
                    }
                #endregion // グラフ表示
                #region 設定
                case "ButtonTool_Setup":
                    {
                        if (this._userSetupFrm == null)
                            this._userSetupFrm = new PMKOU04110UC();

                        this._userSetupFrm.ShowDialog();
                        break;
                    }
                #endregion // 設定
                // -- ADD 2010/02/18 -------------------<<<
                // --- ADD 2010/07/20-------------------------------->>>>>
                case "ButtonTool_Text":
                    {
                        this.ExportIntoTextFile(false);
                        break;
                    }
                case "ButtonTool_Excel":
                    {
                        this.ExportIntoExcelFile(true);
                        break;
                    }
                // --- ADD 2010/07/20--------------------------------<<<<<

            }
        }

        #endregion // ツールバー

        #region ガイドボタン

        /// <summary>
        /// 拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            SecInfoSet secInfoSet;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, this._mainOfficeFunc, out secInfoSet);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                this.tEdit_SectionName.Text = secInfoSet.SectionGuideNm.Trim();

                // 2010/04/30 Add >>>
                string code = this.tEdit_SectionCode.Text.Trim();
                string name = this.tEdit_SectionName.Text.Trim();
                if (this._befortEditSectionCode.Equals(code) == false)
                {
                    this.BalanceInquiryInit();
                    this._suppYearResultAcs.ClearDataset();
                    this._suppYearResultAcs.SetDataSetBase();
                    this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                    this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectFirstTab);
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                    this._befortEditSectionCode = code;
                    this._befortEditSectionName = name;
                }
                // 2010/04/30 Add <<<
                
                // 拠点ごとの締め日を取得
                //GetTotalDay(secInfoSet.SectionCode.Trim().PadLeft(2, '0')); // DEL 2009/02/13
                // --- ADD 2009/02/13 -------------------------------->>>>>
                if (this.tNedit_SupplierCode.GetInt() != 0)
                {
                    this.GetTotalDay(secInfoSet.SectionCode.Trim().PadLeft(2, '0'), this.tNedit_SupplierCode.GetInt());
                }
                // --- ADD 2009/02/13 --------------------------------<<<<<
            }
            // --- DEL 2009/01/28 -------------------------------->>>>>
            //else
            //{
            //    GetTotalDay(CT_SECTIONCODE_WHOLE);
            //}
            // --- DEL 2009/01/28 --------------------------------<<<<<
        }

        /// <summary>
        /// 仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_SupplierGuide_Click(object sender, EventArgs e)
        {
            // 仕入先ガイド表示
            int status = 0;
            Supplier supplier;
            if (!String.IsNullOrEmpty(this.tEdit_SectionCode.Text.Trim()))
            {
                status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, this.tEdit_SectionCode.Text.Trim().PadLeft(2, '0'));
            }
            else
            {
                status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, CT_SECTIONCODE_WHOLE);
            }

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SupplierCode.SetInt(supplier.SupplierCd);
                this.tEdit_SupplierName.Text = supplier.SupplierSnm.Trim();

                // 2010/04/30 Add >>>
                int code = this.tNedit_SupplierCode.GetInt();
                if (this._beforSupplierCode.Equals(code) == false)
                {
                    this.BalanceInquiryInit();
                    this._suppYearResultAcs.ClearDataset();
                    this._suppYearResultAcs.SetDataSetBase();
                    this.utc_InventTab.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectFirstTab);
                    this.utc_InventTab.Tabs["GraphTab"].Visible = false;
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Graph"].SharedProps.Enabled = false;
                    this._beforSupplierCode = code;
                }
                // 2010/04/30 Add <<<
                
                // 精算先区分を取得
                GetSettingFromSupplierInfo(supplier);

                // --- ADD 2009/02/13 -------------------------------->>>>>
                // 拠点ごとの締め日を取得
                if (!string.IsNullOrEmpty(this.tEdit_SectionCode.Text))
                {
                    this.GetTotalDay(this.tEdit_SectionCode.Text.Trim().PadLeft(2, '0'), supplier.SupplierCd);
                }
                // --- ADD 2009/02/13 --------------------------------<<<<<
            }
            // --- DEL 2009/01/28 -------------------------------->>>>>
            //else
            //{
            //    this.tNedit_SupplierCode.Clear();
            //    this.tEdit_SupplierName.Text = "";

            //    // 仕入先から取得される情報をリセット
            //    GetSettingFromSupplierInfo(null);
            //}
            // --- DEL 2009/01/28 --------------------------------<<<<<
        }

        #endregion // ガイドボタン

        #region データグリッドイベント

        /// <summary>
        /// データグリッドセルアクティブ後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_AfterCellActivate(object sender, EventArgs e)
        {
            //
        }

        /// <summary>
        /// データグリッドエンターイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_Enter(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Result.ActiveRow;


            if (this.uGrid_Result.Rows.Count > 0)
            {
                this.uGrid_Result.Selected.Rows.Clear();
                this.uGrid_Result.ActiveRow = this.uGrid_Result.Rows[0];
                this.uGrid_Result.ActiveRow.Selected = true;
            }
        }

        /// <summary>
        /// データグリッドリーブイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_Leave(object sender, EventArgs e)
        {
            this.uStatusBar_Main.Text = "";
        }



        /// <summary>
        /// データグリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (this.uGrid_Result.ActiveRow != null)
                        {
                            if (this.uGrid_Result.ActiveRow.Index == 0)
                            {
                                //this.tDateEdit_InventoryDayStart.Focus();
                            }
                        }

                        break;
                    }
            }
        }

        #endregion

        #region 本社機能／拠点機能チェック処理

        /// <summary>
        /// 本社機能／拠点機能チェック処理
        /// </summary>
        /// <returns>true:本社機能 false:拠点機能</returns>
        private bool IsMainOfficeFunc()
        {
            bool isMainOfficeFunc = false;

            // ログイン担当拠点情報の取得
            SecInfoSet secInfoSet;
            int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (secInfoSet.MainOfficeFuncFlag == 1) // 本社機能か？
                {
                    isMainOfficeFunc = true;
                }
            }

            return isMainOfficeFunc;
        }

        #endregion // 本社機能／拠点機能チェック処理

        #region 拠点コードから締日情報を取得

        /// <summary>
        /// 拠点コードから締日情報を取得
        /// </summary>
        /// <param name="sectionCd"></param>
        /// <returns></returns>
        //private int GetTotalDay(string sectionCd) // DEL 2009/02/13
        private int GetTotalDay(string sectionCd, int supplierCd) // ADD 2009/02/13
        {
            int status = 0;

            // 全社コードおよび空白は締日をリセット
            if (sectionCd == CT_SECTIONCODE_WHOLE || String.IsNullOrEmpty(sectionCd))
            {
                // --- DEL 2012/11/08 ---------->>>>>
                //this._secTotalDay = DateTime.MinValue;

                //return -1;
                // --- DEL 2012/11/08 ----------<<<<<
                // --- ADD 2012/11/08 ---------->>>>>
                // 全社コードが指定された場合には拠点コードを空文字指定で締日取得を実行する
                DateTime prevTotalDay;
                status = this._suppYearResultAcs.GetTotalDayMonthlyAccPay(this._enterpriseCode, "", supplierCd, out prevTotalDay);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._secTotalDay = prevTotalDay;
                }
                // --- ADD 2012/11/08 ----------<<<<<
            }
            else
            {
                DateTime prevTotalDay;
                //status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay(sectionCd, out prevTotalDay); // DEL 2009/02/13
                // --- DEL 2012/11/08 ---------->>>>>
                //status = this._totalDayCalculator.GetTotalDayMonthlyAccPay(sectionCd, supplierCd, out prevTotalDay); // ADD 2009/02/13
                // --- DEL 2012/11/08 ----------<<<<<
                // --- ADD 2012/11/08 ---------->>>>>
                status = this._suppYearResultAcs.GetTotalDayMonthlyAccPay(this._enterpriseCode, sectionCd, supplierCd, out prevTotalDay);
                // --- ADD 2012/11/08 ----------<<<<<
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._secTotalDay = prevTotalDay;
                }
            }
            return status;
        }

        #endregion // 拠点コードから締日情報を取得

        #region 仕入先情報から各種設定値を取得

        /// <summary>
        /// 仕入先情報から各種設定値を取得
        /// </summary>
        /// <param name="supplier">仕入先情報クラス</param>
        /// <remarks>引数がNullの場合は設定値をクリアのみ行う</remarks>
        private void GetSettingFromSupplierInfo(Supplier supplier)
        {
            //// パラメータを初期化
            //this._accDiv = 1;   // 子 // DEL 2009/01/30

            // 締日をクリア
            this.tEdit_PaymentTotalDay.Clear();

            // 支払条件欄をクリア
            this.tEdit_PaymentMonthDivName.Clear();
            this.tEdit_PaymentDay.Clear();
            this.tEdit_PaymentCondName.Clear();

            // 初期化までは行う
            if (supplier == null) return;

            // --- DEL 2009/01/30 -------------------------------->>>>>
            //// 精算区分チェック
            //if (supplier.SupplierCd == supplier.PayeeCode)
            //{
            //    this._accDiv = 0;
            //}
            // --- DEL 2009/01/30 --------------------------------<<<<<

            // 支払締日
            this.tEdit_PaymentTotalDay.Text = supplier.PaymentTotalDay.ToString() + "日";

            // 支払条件欄
            // 支払月区分名称
            this.tEdit_PaymentMonthDivName.Text = supplier.PaymentMonthName;
            // 支払日
            this.tEdit_PaymentDay.Text = supplier.PaymentDay.ToString() + "日";
            // 支払条件
            int paymentCondCode = supplier.PaymentCond;
            string paymentCondName = string.Empty;
            this._suppYearResultAcs.GetMoneyKindName(paymentCondCode, out paymentCondName, this._enterpriseCode);
            this.tEdit_PaymentCondName.Text = paymentCondName;

            // プライベート変数に値をセット(パラメータにセットされるのはGetParameter()のタイミング)
            // 仕入先の最終締年月日
            // --- CHG 2009/02/13 締日取得方法変更------------------------------------------------------>>>>>
            //int status = this._totalDayCalculator.GetTotalDayMonthlyAccPay(supplier.SupplierCd, out this._suppTotalDay);
            int status = this._totalDayCalculator.GetTotalDayPayment(supplier.SupplierCd, out this._suppTotalDay);
            // --- CHG 2009/02/13 締日取得方法変更------------------------------------------------------<<<<<

            // 仕入金額端数処理コード
            this._stockPriceFrcProcCd = supplier.StockMoneyFrcProcCd;
        }

        #endregion // 仕入先情報から各種設定値を取得

        #region 支払条件情報クリア処理

        /// <summary>
        /// 支払条件情報クリア処理
        /// </summary>
        private void CollectMoneySelect()
        {
            this.tEdit_PaymentTotalDay.DataText = "";
            this.tEdit_PaymentMonthDivName.DataText = "";
            this.tEdit_PaymentDay.DataText = "";
            this.tEdit_PaymentCondName.DataText = "";
        }

        #endregion // 支払条件情報クリア処理

        #region 残高照会タブ設定

        /// <summary>
        /// 残高照会タブ設定
        /// </summary>
        private void BalanceInquiryInit()
        {
            #region 支払名称設定

            PaymentSet paymentSet;
            int status = this._paymentSetAcs.Read(out paymentSet, this._enterpriseCode, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.lblPayment01.Text = paymentSet.PayStMoneyKindNm1.Replace("未登録", string.Empty);
                this.lblPayment02.Text = paymentSet.PayStMoneyKindNm2.Replace("未登録", string.Empty);
                this.lblPayment03.Text = paymentSet.PayStMoneyKindNm3.Replace("未登録", string.Empty);
                this.lblPayment04.Text = paymentSet.PayStMoneyKindNm4.Replace("未登録", string.Empty);
                this.lblPayment05.Text = paymentSet.PayStMoneyKindNm5.Replace("未登録", string.Empty);
                this.lblPayment06.Text = paymentSet.PayStMoneyKindNm6.Replace("未登録", string.Empty);
                this.lblPayment07.Text = paymentSet.PayStMoneyKindNm7.Replace("未登録", string.Empty);
                this.lblPayment08.Text = paymentSet.PayStMoneyKindNm8.Replace("未登録", string.Empty);
            }
            else
            {
                this.lblPayment01.Text = string.Empty;
                this.lblPayment02.Text = string.Empty;
                this.lblPayment03.Text = string.Empty;
                this.lblPayment04.Text = string.Empty;
                this.lblPayment05.Text = string.Empty;
                this.lblPayment06.Text = string.Empty;
                this.lblPayment07.Text = string.Empty;
                this.lblPayment08.Text = string.Empty;
            }

            #endregion

            #region 数値項目のコントロールの幅を調整

            Broadleaf.Library.Windows.Forms.TNedit[] ControlList_TNEDIT;
            ControlList_TNEDIT = new Broadleaf.Library.Windows.Forms.TNedit[]{
                                                                    this.tNedit_bc_1MthMonth,
                                                                    this.tNedit_bc_1MthPayment,
                                                                    this.tNedit_bc_2MthMonth,
                                                                    this.tNedit_bc_2MthPayment,
                                                                    this.tNedit_bc_3MthMonth,
                                                                    this.tNedit_bc_3MthPayment,
                                                                    this.tNedit_bc_OfsStock,
                                                                    this.tNedit_bc_OfsStockPayment,
                                                                    this.tNedit_bc_OfsStockTax,
                                                                    this.tNedit_bc_OfsStockTaxPayment,
                                                                    this.tNedit_bc_OfsStockTaxTerm,
                                                                    this.tNedit_bc_OfsStockTerm,
                                                                    this.tNedit_bc_Payment01,
                                                                    this.tNedit_bc_Payment01c,
                                                                    this.tNedit_bc_Payment02,
                                                                    this.tNedit_bc_Payment02c,
                                                                    this.tNedit_bc_Payment03,
                                                                    this.tNedit_bc_Payment03c,
                                                                    this.tNedit_bc_Payment04,
                                                                    this.tNedit_bc_Payment04c,
                                                                    this.tNedit_bc_Payment05,
                                                                    this.tNedit_bc_Payment05c,
                                                                    this.tNedit_bc_Payment06,
                                                                    this.tNedit_bc_Payment06c,
                                                                    this.tNedit_bc_Payment07,
                                                                    this.tNedit_bc_Payment07c,
                                                                    this.tNedit_bc_Payment08,
                                                                    this.tNedit_bc_Payment08c,
                                                                    this.tNedit_bc_Payment09,
                                                                    this.tNedit_bc_Payment09c,
                                                                    this.tNedit_bc_Payment10,
                                                                    this.tNedit_bc_Payment10c,
                                                                    this.tNedit_bc_PaymentSum,
                                                                    this.tNedit_bc_PaymentSumc,
                                                                    this.tNedit_bc_Slip,
                                                                    this.tNedit_bc_SlipPayment,
                                                                    this.tNedit_bc_SlipTerm,
                                                                    this.tNedit_bc_StckPricDis,
                                                                    this.tNedit_bc_StckPricDisPayment,
                                                                    this.tNedit_bc_StckPricDisTerm,
                                                                    this.tNedit_bc_StckPricRgds,
                                                                    this.tNedit_bc_StckPricRgdsPayment,
                                                                    this.tNedit_bc_StckPricRgdsTerm,
                                                                    this.tNedit_bc_StockPrice,
                                                                    this.tNedit_bc_StockPricePayment,
                                                                    this.tNedit_bc_StockPriceTerm,
                                                                    this.tNedit_bc_TotalPayBalance,
                                                                    this.tNedit_bc_TtlAccPayBalance};
            Size controlSize = new Size(131, 26);
            for (int ix = 0; ix < ControlList_TNEDIT.Length; ix++)
            {
                ControlList_TNEDIT[ix].Size = controlSize;
                ControlList_TNEDIT[ix].Clear();
            }

            #endregion
        }

        #endregion // 残高照会タブ設定

        #region タブ切替制御

        /// <summary>
        /// タブ切り替え時の制御
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraTab_SelectedTabChanging(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangingEventArgs e)
        {
            if (e.Tab == null) return;

            e.Cancel = false;
            string key = e.Tab.Key;

            if (key.Equals("BalanceInquiryTab"))
            {
                // 支払仕入先ではない場合
                //if (this._accDiv == 1) // DEL 2009/01/30
                // --- DEL 2012/09/18 ---------->>>>>
                //if (this.GetAccDiv() == 1)  // ADD 2009/01/30
                // --- DEL 2012/09/18 ----------<<<<<
                // --- ADD 2012/09/18 ---------->>>>>
                if (!this._optSuppSumEnable && this.GetAccDiv() == 1)
                // --- ADD 2012/09/18 ----------<<<<<
                {
                    // メッセージを表示
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                        CT_CANNOT_SHOW_CHILD_SUPPLIER, -1, MessageBoxButtons.OK);

                    // タブを元に戻す
                    e.Cancel = true;
                    this.utc_InventTab.Tabs["ResultsTab"].Selected = true;
                    this.utc_InventTab.Tabs["ResultsTab"].Active = true;
                    this.utc_InventTab.Tabs["ResultsTab"].Appearance = this.utc_InventTab.Tabs["ResultsTab"].ActiveAppearance;
                    return;
                }

                // 本年度ではない場合
                if (this._financialYear != this._currentFinancialYear)
                {
                    // メッセージを表示
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                        CT_SHOW_ONLY_CURRENTYEAR, -1, MessageBoxButtons.OK);

                    // タブを元に戻す
                    e.Cancel = true;
                    this.utc_InventTab.Tabs["ResultsTab"].Selected = true;
                    this.utc_InventTab.Tabs["ResultsTab"].Active = true;
                    this.utc_InventTab.Tabs["ResultsTab"].Appearance = this.utc_InventTab.Tabs["ResultsTab"].ActiveAppearance;
                    return;
                }
            }
        }

        #endregion // タブ切替制御

        #region 年度変更時

        /// <summary>
        /// 年度変更時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tDateEdit_FinancialYear_Leave(object sender, EventArgs e)
        {
            // 会計年度計算
            if (this.tDateEdit_FinancialYear.GetDateYear() == this._currentFinancialYear ||
                this.tDateEdit_FinancialYear.GetDateYear() == this._currentFinancialYear - 1)
            {
                this._financialYear = this.tDateEdit_FinancialYear.GetDateYear();
            }
            else if (this.tDateEdit_FinancialYear.GetDateYear() > this._currentFinancialYear)
            {
                // 現年度へ修正
                this.tDateEdit_FinancialYear.SetLongDate(this._currentFinancialYear * 10000);

                // メッセージ表示
                //TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                //    CT_CANNOT_INPUT_FOLLOWING, -1, MessageBoxButtons.OK); // DEL 2009/01/28
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    CT_CANNOT_INPUT_FOLLOWING, -1, MessageBoxButtons.OK); // ADD 2009/01/28
                return;
            }
            else
            {
                // 現年度へ修正
                this.tDateEdit_FinancialYear.SetLongDate(this._currentFinancialYear * 10000);

                // メッセージ表示
                //TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                //    CT_CAN_INPUT_ONLY_TWICE, -1, MessageBoxButtons.OK); // DEL 2009/01/28
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    CT_CAN_INPUT_ONLY_TWICE, -1, MessageBoxButtons.OK); // ADD 2009/01/28

                return;
            }

            // 会計年度開始日を取得
            DateTime paramDate;
            if (!this._suppYearResultAcs.GetCompanyBeginDate(this._enterpriseCode, this._financialYear, out paramDate))
            {
                return;
            }
            else
            {
                // 日付設定を再取得
                this._suppYearResultAcs.GetDateParams(this._financialYear, paramDate, this._enterpriseCode);

                //// 残高照会タブを再設定
                //this.BalanceInquiryInit(); // DEL 2009/01/29
            }
        }

        #endregion // 年度変更時

        #region テストデータ作成

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            // テストデータ挿入
            DataRow row = this._dataSet.MonthResult.NewRow();
            row[this._dataSet.MonthResult.RowNoColumn.ColumnName] = 0;
            row[this._dataSet.MonthResult.RowMonthColumn.ColumnName] = 1;
            row[this._dataSet.MonthResult.RowSetFlgColumn.ColumnName] = 0;
            row[this._dataSet.MonthResult.RowTitleColumn.ColumnName] = "12月";
            row[this._dataSet.MonthResult.St_StockPriceTaxExcColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.St_StockRetGoodsPriceColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.St_StockTotalDiscountColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.St_StockPriceConsTaxColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.Or_StockPriceTaxExcColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.Or_StockRetGoodsPriceColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.Or_StockTotalDiscountColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.Or_StockPriceConsTaxColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.To_StockPriceTaxExcColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.To_StockRetGoodsPriceColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.To_StockTotalDiscountColumn.ColumnName] = 9999999999;
            row[this._dataSet.MonthResult.To_StockPriceConsTaxColumn.ColumnName] = 9999999999;

            this._dataSet.MonthResult.Rows.Add(row);

            DataView dv = this._dataSet.MonthResult.DefaultView;
            this.uGrid_Result.DataSource = dv;

        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// セルのコレクションイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 杜志剛</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/11/01 tianjw</br>
        /// <br>            redmine#16602 テキスト出力対応 不具合修正</br>
        private void ultraGridExcelExport_CellExported(object sender, Infragistics.Win.UltraWinGrid.ExcelExport.CellExportedEventArgs e)
        {
            int index = e.CurrentRowIndex;
            // ---------- UPD 2010/11/01 ------------------------------------->>>>>
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.ultraGrid_OutPut.DisplayLayout.Bands[0].Columns;
            
            if (Columns != null)
            {
                //for (int celIndex = 0; celIndex < 24; celIndex++) 
                for (int celIndex = 0; celIndex < Columns.Count; celIndex++)
                {
                    IWorksheetCellFormat tmCF = e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat;
                    tmCF.FormatString = "#,###,##0;-#,###,##0;0";
                    e.CurrentWorksheet.Rows[index].Cells[celIndex].CellFormat.SetFormatting(tmCF);
                }
            }
            // ---------- UPD 2010/11/01 -------------------------------------<<<<<
        }
        // --- ADD 2010/07/20--------------------------------<<<<<

        #endregion //テストデータ作成

        # endregion

        // --- ADD 2010/07/20-------------------------------->>>>>
        #region ■テキスト、Excsl出力処理
        /// <summary>
        /// 仕入年間実績をExcel出力します。
        /// </summary>
        /// <remarks>
        /// <param name="excelFlg">出力形式フラグ：
        /// 　　　　　　　　　　　　False:テキスト出力
        /// 　　　　　　　　　　　　True:Excel出力</param>
        /// <br>Update Note: 2010/10/09 tianjw</br>
        /// <br>           : #15881 テキスト出力対応</br>
        /// <br>Update Note: 2024/11/22 陳艶丹</br>
        /// <br>             PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        /// </remarks>
        private void ExportIntoExcelFile(bool excelFlg)
        {
            this._extractSetupFrm = new PMKOU04110UE();
            this._extractSetupFrm.FormcloseFlg = false;
            // 対象年度
            this._extractSetupFrm.FinancialYear = this.tDateEdit_FinancialYear.GetDateYear();

            // 出力形式
            this._extractSetupFrm.ExcelFlg = excelFlg;
            this._extractSetupFrm.parentHanPtr = this.Handle;

            this._extractSetupFrm.OutputData += new PMKOU04110UE.OutputDataEvent(this.outputExcelData); // ADD 2010/10/09

            //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----->>>>>
            // エラーメッセージ
            string errMsg = string.Empty;
            // アラート表示
            int logStatus = TextOutPutOprtnHisLogAcsObj.ShowTextOutPut(this, out errMsg);
            // アラートでOKボタンが押されない場合、テキスト出力が実行できない
            if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (!string.IsNullOrEmpty(errMsg))
                {
                    Form form = new Form();
                    form.TopMost = true;
                    DialogResult dialogResult = TMsgDisp.Show(
                        form, 
                        emErrorLevel.ERR_LEVEL_STOP,
                        this.Name,
                        errMsg,
                        logStatus,
                        MessageBoxButtons.OK);
                    form.TopMost = false;
                }
                // 中止
                return;
            }
            //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 -----<<<<<

            this._extractSetupFrm.ShowDialog();

            // -------- DEL 2010/10/09 ------------------------------------------->>>>>
            //if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            //{
            //    return;
            //}

            //// 開始拠点コード
            //this._sectionCodeSt = this._extractSetupFrm.SectionCodeSt;
            //// 終了拠点コード
            //this._sectionCodeEnd = this._extractSetupFrm.SectionCodeEd;
            //// 開始仕入先コード
            //this._supplierCdSt = this._extractSetupFrm.SupplierCodeSt;
            //// 終了仕入先コード
            //this._supplierCdEnd = this._extractSetupFrm.SupplierCodeEd;
 
            //SFCMN00299CA processingDialog = new SFCMN00299CA();
            //try
            //{
            //    processingDialog.Title = "抽出処理";
            //    processingDialog.Message = "現在、データ抽出中です。";
            //    processingDialog.DispCancelButton = false;
            //    processingDialog.Show((Form)this.Parent);
            //    this.Search("SubMain");
            //}
            //finally
            //{
            //    processingDialog.Dispose();
            //}

            //if (this._dataSet.OutPutResult.Count == 0 && this._dataSet.AccPayResult.Count == 0)
            //{
            //    // データセットをクリア
            //    tDateEdit_FinancialYear_Leave(null, null);
            //    this._suppYearResultCndtn.MainDiv = "Main";
            //    string errorMessage = string.Empty;
            //    if (CheckParameters(out errorMessage))
            //        this._suppYearResultAcs.Search(this._suppYearResultCndtn);
            //    else
            //    {
            //        this._dataSet.MonthResult.Rows.Clear();
            //        this._suppYearResultAcs.SetDataSetBase();
            //    }

            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        "条件に合致するデータが存在しません。",
            //        -1,
            //        MessageBoxButtons.OK);
            //    return;
            //}

            //try
            //{
            //    if (this.ultraGridExcelExport.Export(this.ultraGrid_OutPut, this._extractSetupFrm.SettingFileName) != null)
            //    {
            //        // データセットをクリア
            //        tDateEdit_FinancialYear_Leave(null, null);
            //        this._suppYearResultCndtn.MainDiv = "Main";
            //        string errorMessage = string.Empty;
            //        if (CheckParameters(out errorMessage))
            //            this._suppYearResultAcs.Search(this._suppYearResultCndtn);
            //        else
            //        {
            //            this._dataSet.MonthResult.Rows.Clear();
            //            this._suppYearResultAcs.SetDataSetBase();
            //        }

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
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        ex.Message,
            //        -1,
            //        MessageBoxButtons.OK);
            //}
            // -------- DEL 2010/10/09 -------------------------------------------<<<<<
        }

        /// <summary>
        /// 仕入年間実績をテキスト出力します。
        /// </summary>
        /// <remarks>
        /// <param name="excelFlg">出力形式フラグ：
        /// 　　　　　　　　　　　　False:テキスト出力
        /// 　　　　　　　　　　　　True:Excel出力</param>
        /// </remarks>
        /// <br>Update Note : 2010/09/08 楊明俊</br>
        /// <br>            ・障害ID:14443 テキスト出力対応</br>
        /// <br>Update Note: 2010/10/09 tianjw</br>
        /// <br>           : #15881 テキスト出力対応</br>
        /// <br>Update Note : 2024/11/22 陳艶丹</br>
        /// <br>             PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        private void ExportIntoTextFile(bool excelFlg)
        {
            this._extractSetupFrm = new PMKOU04110UE();

            this._extractSetupFrm.FormcloseFlg = false;

            // 対象年度
            this._extractSetupFrm.FinancialYear = this.tDateEdit_FinancialYear.GetDateYear();

            // 出力形式
            this._extractSetupFrm.ExcelFlg = excelFlg;
            this._extractSetupFrm.parentHanPtr = this.Handle;

            this._extractSetupFrm.OutputData += new PMKOU04110UE.OutputDataEvent(this.outputTextData); // ADD 2010/10/09

            //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----->>>>>
            // エラーメッセージ
            string errMsg = string.Empty;
            // アラート表示
            int logStatus = TextOutPutOprtnHisLogAcsObj.ShowTextOutPut(this, out errMsg);
            // アラートでOKボタンが押されない場合、テキスト出力が実行できない
            if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (!string.IsNullOrEmpty(errMsg))
                {
                    Form form = new Form();
                    form.TopMost = true;
                    DialogResult dialogResult = TMsgDisp.Show(
                        form,
                        emErrorLevel.ERR_LEVEL_STOP,
                        this.Name,
                        errMsg,
                        logStatus,
                        MessageBoxButtons.OK);
                    form.TopMost = false;
                }
                // 中止
                return;
            }
            //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 -----<<<<<

            this._extractSetupFrm.ShowDialog();

            // -------- DEL 2010/10/09 ------------------------------------------->>>>>
            //if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            //{
            //    return;
            //}

            //// 開始拠点コード
            //this._sectionCodeSt = this._extractSetupFrm.SectionCodeSt;
            //// 終了拠点コード
            //this._sectionCodeEnd = this._extractSetupFrm.SectionCodeEd;
            //// 開始仕入先コード
            //this._supplierCdSt = this._extractSetupFrm.SupplierCodeSt;
            //// 終了仕入先コード
            //this._supplierCdEnd = this._extractSetupFrm.SupplierCodeEd;

            //SFCMN00299CA processingDialog = new SFCMN00299CA();
            //try
            //{
            //    processingDialog.Title = "抽出処理";
            //    processingDialog.Message = "現在、データ抽出中です。";
            //    processingDialog.DispCancelButton = false;
            //    processingDialog.Show((Form)this.Parent);
            //    this.Search("SubMain");
            //}
            //finally
            //{
            //    processingDialog.Dispose();
            //}

            //if (this._dataSet.MonthResult.Count == 0 || _monthResultNullFlg)
            //{
            //    _monthResultNullFlg = false;
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        "条件に合致するデータが存在しません。",
            //        -1,
            //        MessageBoxButtons.OK);
            //    return;
            //}

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

            //DataTable targetTable = this._dataSet.OutPutResult;


            ////年月を設定
            //int companyBiginMonth = this._companyBeginMonth;
            //string[] monthFlg = new string[12];
            //for (int ix = 0; ix < 12; ix++)
            //{
            //    int biginMonth = companyBiginMonth + ix;
            //    if (biginMonth > 12) { biginMonth = biginMonth - 12; }
            //    monthFlg[ix] = biginMonth.ToString() + "月";
            //}
            //targetTable.Columns["To_StockPriceTaxExc_1_Month"].Caption = "当期実績・仕入(" + monthFlg[0] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_1_Month"].Caption = "当期実績・返品(" + monthFlg[0] + ")";
            //targetTable.Columns["To_StockTotalDiscount_1_Month"].Caption = "当期実績・値引(" + monthFlg[0] + ")";
            //targetTable.Columns["To_StockPriceSum_1_Month"].Caption = "当期実績・純仕入(" + monthFlg[0] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_2_Month"].Caption = "当期実績・仕入(" + monthFlg[1] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_2_Month"].Caption = "当期実績・返品(" + monthFlg[1] + ")";
            //targetTable.Columns["To_StockTotalDiscount_2_Month"].Caption = "当期実績・値引(" + monthFlg[1] + ")";
            //targetTable.Columns["To_StockPriceSum_2_Month"].Caption = "当期実績・純仕入(" + monthFlg[1] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_3_Month"].Caption = "当期実績・仕入(" + monthFlg[2] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_3_Month"].Caption = "当期実績・返品(" + monthFlg[2] + ")";
            //targetTable.Columns["To_StockTotalDiscount_3_Month"].Caption = "当期実績・値引(" + monthFlg[2] + ")";
            //targetTable.Columns["To_StockPriceSum_3_Month"].Caption = "当期実績・純仕入(" + monthFlg[2] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_4_Month"].Caption = "当期実績・仕入(" + monthFlg[3] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_4_Month"].Caption = "当期実績・返品(" + monthFlg[3] + ")";
            //targetTable.Columns["To_StockTotalDiscount_4_Month"].Caption = "当期実績・値引(" + monthFlg[3] + ")";
            //targetTable.Columns["To_StockPriceSum_4_Month"].Caption = "当期実績・純仕入(" + monthFlg[3] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_5_Month"].Caption = "当期実績・仕入(" + monthFlg[4] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_5_Month"].Caption = "当期実績・返品(" + monthFlg[4] + ")";
            //targetTable.Columns["To_StockTotalDiscount_5_Month"].Caption = "当期実績・値引(" + monthFlg[4] + ")";
            //targetTable.Columns["To_StockPriceSum_5_Month"].Caption = "当期実績・純仕入(" + monthFlg[4] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_6_Month"].Caption = "当期実績・仕入(" + monthFlg[5] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_6_Month"].Caption = "当期実績・返品(" + monthFlg[5] + ")";
            //targetTable.Columns["To_StockTotalDiscount_6_Month"].Caption = "当期実績・値引(" + monthFlg[5] + ")";
            //targetTable.Columns["To_StockPriceSum_6_Month"].Caption = "当期実績・純仕入(" + monthFlg[5] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_7_Month"].Caption = "当期実績・仕入(" + monthFlg[6] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_7_Month"].Caption = "当期実績・返品(" + monthFlg[6] + ")";
            //targetTable.Columns["To_StockTotalDiscount_7_Month"].Caption = "当期実績・値引(" + monthFlg[6] + ")";
            //targetTable.Columns["To_StockPriceSum_7_Month"].Caption = "当期実績・純仕入(" + monthFlg[6] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_8_Month"].Caption = "当期実績・仕入(" + monthFlg[7] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_8_Month"].Caption = "当期実績・返品(" + monthFlg[7] + ")";
            //targetTable.Columns["To_StockTotalDiscount_8_Month"].Caption = "当期実績・値引(" + monthFlg[7] + ")";
            //targetTable.Columns["To_StockPriceSum_8_Month"].Caption = "当期実績・純仕入(" + monthFlg[7] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_9_Month"].Caption = "当期実績・仕入(" + monthFlg[8] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_9_Month"].Caption = "当期実績・返品(" + monthFlg[8] + ")";
            //targetTable.Columns["To_StockTotalDiscount_9_Month"].Caption = "当期実績・値引(" + monthFlg[8] + ")";
            //targetTable.Columns["To_StockPriceSum_9_Month"].Caption = "当期実績・純仕入(" + monthFlg[8] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_10_Month"].Caption = "当期実績・仕入(" + monthFlg[9] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_10_Month"].Caption = "当期実績・返品(" + monthFlg[9] + ")";
            //targetTable.Columns["To_StockTotalDiscount_10_Month"].Caption = "当期実績・値引(" + monthFlg[9] + ")";
            //targetTable.Columns["To_StockPriceSum_10_Month"].Caption = "当期実績・純仕入(" + monthFlg[9] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_11_Month"].Caption = "当期実績・仕入(" + monthFlg[10] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_11_Month"].Caption = "当期実績・返品(" + monthFlg[10] + ")";
            //targetTable.Columns["To_StockTotalDiscount_11_Month"].Caption = "当期実績・値引(" + monthFlg[10] + ")";
            //targetTable.Columns["To_StockPriceSum_11_Month"].Caption = "当期実績・純仕入(" + monthFlg[10] + ")";

            //targetTable.Columns["To_StockPriceTaxExc_12_Month"].Caption = "当期実績・仕入(" + monthFlg[11] + ")";
            //targetTable.Columns["To_StockRetGoodsPrice_12_Month"].Caption = "当期実績・返品(" + monthFlg[11] + ")";
            //targetTable.Columns["To_StockTotalDiscount_12_Month"].Caption = "当期実績・値引(" + monthFlg[11] + ")";
            //targetTable.Columns["To_StockPriceSum_12_Month"].Caption = "当期実績・純仕入(" + monthFlg[11] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_1_Month"].Caption = "在庫・仕入(" + monthFlg[0] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_1_Month"].Caption = "在庫・返品(" + monthFlg[0] + ")";
            //targetTable.Columns["St_StockTotalDiscount_1_Month"].Caption = "在庫・値引(" + monthFlg[0] + ")";
            //targetTable.Columns["St_StockPriceSum_1_Month"].Caption = "在庫・純仕入(" + monthFlg[0] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_2_Month"].Caption = "在庫・仕入(" + monthFlg[1] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_2_Month"].Caption = "在庫・返品(" + monthFlg[1] + ")";
            //targetTable.Columns["St_StockTotalDiscount_2_Month"].Caption = "在庫・値引(" + monthFlg[1] + ")";
            //targetTable.Columns["St_StockPriceSum_2_Month"].Caption = "在庫・純仕入(" + monthFlg[1] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_3_Month"].Caption = "在庫・仕入(" + monthFlg[2] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_3_Month"].Caption = "在庫・返品(" + monthFlg[2] + ")";
            //targetTable.Columns["St_StockTotalDiscount_3_Month"].Caption = "在庫・値引(" + monthFlg[2] + ")";
            //targetTable.Columns["St_StockPriceSum_3_Month"].Caption = "在庫・純仕入(" + monthFlg[2] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_4_Month"].Caption = "在庫・仕入(" + monthFlg[3] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_4_Month"].Caption = "在庫・返品(" + monthFlg[3] + ")";
            //targetTable.Columns["St_StockTotalDiscount_4_Month"].Caption = "在庫・値引(" + monthFlg[3] + ")";
            //targetTable.Columns["St_StockPriceSum_4_Month"].Caption = "在庫・純仕入(" + monthFlg[3] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_5_Month"].Caption = "在庫・仕入(" + monthFlg[4] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_5_Month"].Caption = "在庫・返品(" + monthFlg[4] + ")";
            //targetTable.Columns["St_StockTotalDiscount_5_Month"].Caption = "在庫・値引(" + monthFlg[4] + ")";
            //targetTable.Columns["St_StockPriceSum_5_Month"].Caption = "在庫・純仕入(" + monthFlg[4] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_6_Month"].Caption = "在庫・仕入(" + monthFlg[5] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_6_Month"].Caption = "在庫・返品(" + monthFlg[5] + ")";
            //targetTable.Columns["St_StockTotalDiscount_6_Month"].Caption = "在庫・値引(" + monthFlg[5] + ")";
            //targetTable.Columns["St_StockPriceSum_6_Month"].Caption = "在庫・純仕入(" + monthFlg[5] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_7_Month"].Caption = "在庫・仕入(" + monthFlg[6] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_7_Month"].Caption = "在庫・返品(" + monthFlg[6] + ")";
            //targetTable.Columns["St_StockTotalDiscount_7_Month"].Caption = "在庫・値引(" + monthFlg[6] + ")";
            //targetTable.Columns["St_StockPriceSum_7_Month"].Caption = "在庫・純仕入(" + monthFlg[6] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_8_Month"].Caption = "在庫・仕入(" + monthFlg[7] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_8_Month"].Caption = "在庫・返品(" + monthFlg[7] + ")";
            //targetTable.Columns["St_StockTotalDiscount_8_Month"].Caption = "在庫・値引(" + monthFlg[7] + ")";
            //targetTable.Columns["St_StockPriceSum_8_Month"].Caption = "在庫・純仕入(" + monthFlg[7] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_9_Month"].Caption = "在庫・仕入(" + monthFlg[8] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_9_Month"].Caption = "在庫・返品(" + monthFlg[8] + ")";
            //targetTable.Columns["St_StockTotalDiscount_9_Month"].Caption = "在庫・値引(" + monthFlg[8] + ")";
            //targetTable.Columns["St_StockPriceSum_9_Month"].Caption = "在庫・純仕入(" + monthFlg[8] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_10_Month"].Caption = "在庫・仕入(" + monthFlg[9] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_10_Month"].Caption = "在庫・返品(" + monthFlg[9] + ")";
            //targetTable.Columns["St_StockTotalDiscount_10_Month"].Caption = "在庫・値引(" + monthFlg[9] + ")";
            //targetTable.Columns["St_StockPriceSum_10_Month"].Caption = "在庫・純仕入(" + monthFlg[9] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_11_Month"].Caption = "在庫・仕入(" + monthFlg[10] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_11_Month"].Caption = "在庫・返品(" + monthFlg[10] + ")";
            //targetTable.Columns["St_StockTotalDiscount_11_Month"].Caption = "在庫・値引(" + monthFlg[10] + ")";
            //targetTable.Columns["St_StockPriceSum_11_Month"].Caption = "在庫・純仕入(" + monthFlg[10] + ")";

            //targetTable.Columns["St_StockPriceTaxExc_12_Month"].Caption = "在庫・仕入(" + monthFlg[11] + ")";
            //targetTable.Columns["St_StockRetGoodsPrice_12_Month"].Caption = "在庫・返品(" + monthFlg[11] + ")";
            //targetTable.Columns["St_StockTotalDiscount_12_Month"].Caption = "在庫・値引(" + monthFlg[11] + ")";
            //targetTable.Columns["St_StockPriceSum_12_Month"].Caption = "在庫・純仕入(" + monthFlg[11] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_1_Month"].Caption = "取寄・仕入(" + monthFlg[0] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_1_Month"].Caption = "取寄・返品(" + monthFlg[0] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_1_Month"].Caption = "取寄・値引(" + monthFlg[0] + ")";
            //targetTable.Columns["Or_StockPriceSum_1_Month"].Caption = "取寄・純仕入(" + monthFlg[0] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_2_Month"].Caption = "取寄・仕入(" + monthFlg[1] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_2_Month"].Caption = "取寄・返品(" + monthFlg[1] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_2_Month"].Caption = "取寄・値引(" + monthFlg[1] + ")";
            //targetTable.Columns["Or_StockPriceSum_2_Month"].Caption = "取寄・純仕入(" + monthFlg[1] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_3_Month"].Caption = "取寄・仕入(" + monthFlg[2] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_3_Month"].Caption = "取寄・返品(" + monthFlg[2] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_3_Month"].Caption = "取寄・値引(" + monthFlg[2] + ")";
            //targetTable.Columns["Or_StockPriceSum_3_Month"].Caption = "取寄・純仕入(" + monthFlg[2] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_4_Month"].Caption = "取寄・仕入(" + monthFlg[3] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_4_Month"].Caption = "取寄・返品(" + monthFlg[3] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_4_Month"].Caption = "取寄・値引(" + monthFlg[3] + ")";
            //targetTable.Columns["Or_StockPriceSum_4_Month"].Caption = "取寄・純仕入(" + monthFlg[3] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_5_Month"].Caption = "取寄・仕入(" + monthFlg[4] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_5_Month"].Caption = "取寄・返品(" + monthFlg[4] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_5_Month"].Caption = "取寄・値引(" + monthFlg[4] + ")";
            //targetTable.Columns["Or_StockPriceSum_5_Month"].Caption = "取寄・純仕入(" + monthFlg[4] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_6_Month"].Caption = "取寄・仕入(" + monthFlg[5] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_6_Month"].Caption = "取寄・返品(" + monthFlg[5] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_6_Month"].Caption = "取寄・値引(" + monthFlg[5] + ")";
            //targetTable.Columns["Or_StockPriceSum_6_Month"].Caption = "取寄・純仕入(" + monthFlg[5] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_7_Month"].Caption = "取寄・仕入(" + monthFlg[6] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_7_Month"].Caption = "取寄・返品(" + monthFlg[6] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_7_Month"].Caption = "取寄・値引(" + monthFlg[6] + ")";
            //targetTable.Columns["Or_StockPriceSum_7_Month"].Caption = "取寄・純仕入(" + monthFlg[6] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_8_Month"].Caption = "取寄・仕入(" + monthFlg[7] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_8_Month"].Caption = "取寄・返品(" + monthFlg[7] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_8_Month"].Caption = "取寄・値引(" + monthFlg[7] + ")";
            //targetTable.Columns["Or_StockPriceSum_8_Month"].Caption = "取寄・純仕入(" + monthFlg[7] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_9_Month"].Caption = "取寄・仕入(" + monthFlg[8] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_9_Month"].Caption = "取寄・返品(" + monthFlg[8] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_9_Month"].Caption = "取寄・値引(" + monthFlg[8] + ")";
            //targetTable.Columns["Or_StockPriceSum_9_Month"].Caption = "取寄・純仕入(" + monthFlg[8] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_10_Month"].Caption = "取寄・仕入(" + monthFlg[9] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_10_Month"].Caption = "取寄・返品(" + monthFlg[9] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_10_Month"].Caption = "取寄・値引(" + monthFlg[9] + ")";
            //targetTable.Columns["Or_StockPriceSum_10_Month"].Caption = "取寄・純仕入(" + monthFlg[9] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_11_Month"].Caption = "取寄・仕入(" + monthFlg[10] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_11_Month"].Caption = "取寄・返品(" + monthFlg[10] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_11_Month"].Caption = "取寄・値引(" + monthFlg[10] + ")";
            //targetTable.Columns["Or_StockPriceSum_11_Month"].Caption = "取寄・純仕入(" + monthFlg[10] + ")";

            //targetTable.Columns["Or_StockPriceTaxExc_12_Month"].Caption = "取寄・仕入(" + monthFlg[11] + ")";
            //targetTable.Columns["Or_StockRetGoodsPrice_12_Month"].Caption = "取寄・返品(" + monthFlg[11] + ")";
            //targetTable.Columns["Or_StockTotalDiscount_12_Month"].Caption = "取寄・値引(" + monthFlg[11] + ")";
            //targetTable.Columns["Or_StockPriceSum_12_Month"].Caption = "取寄・純仕入(" + monthFlg[11] + ")";
            //// ---------ADD 2010/09/08----------->>>>>
            //targetTable.Columns["StockSectionCd"].Caption = "拠点";
            //targetTable.Columns["SupplierCd"].Caption = "仕入先";
            //targetTable.Columns["SupplierNm"].Caption = "仕入先名";
            //// ---------ADD 2010/09/08-----------<<<<<
            //Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.ultraGrid_OutPut.DisplayLayout.Bands[0].Columns;
            //int dispOrder;
            //string columnName;
            //for (int i = 0; i < Columns.Count; i++)
            //{
            //    // ---------ADD 2010/09/08----------->>>>>
            //    if (Columns[i].Header.Caption == "拠点名称")
            //    {
            //        Columns[i].Hidden = true;
            //    }
            //    // ---------ADD 2010/09/08-----------<<<<<

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
            //tw.DataSource = this.ultraGrid_OutPut.DataSource;

            //# region [フォーマットリスト]
            //Dictionary<string, string> formatList = new Dictionary<string, string>();
            //foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.ultraGrid_OutPut.DisplayLayout.Bands[0].Columns)
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
            //InitializeGrid(this.uGrid_Result.DisplayLayout.Bands[0].Columns, true);

            //if (status == 9)// 異常終了
            //{
            //    // 出力失敗
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
            //        "ファイルへの出力に失敗しました。", -1, MessageBoxButtons.OK);
            //}
            //else
            //{
            //    // データセットをクリア
            //    tDateEdit_FinancialYear_Leave(null, null);
            //    this._suppYearResultCndtn.MainDiv = "Main";

            //    string errorMessage = string.Empty;
            //    if (CheckParameters(out errorMessage))
            //        this._suppYearResultAcs.Search(this._suppYearResultCndtn);
            //    else
            //    {
            //        this._dataSet.MonthResult.Rows.Clear();
            //        this._suppYearResultAcs.SetDataSetBase();
            //    }
                    
            //    // 出力成功
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
            //        outputCount.ToString() + "行のデータをファイルへ出力しました。", -1, MessageBoxButtons.OK);
            //}
            // -------- DEL 2010/10/09 -------------------------------------------<<<<<
        }

        // ------------ ADD 2010/10/09 --------------------------------------------------------->>>>>
        /// <summary>
        /// Excel出力処理
        /// </summary>
        /// <returns>True:正常; False:異常</returns>
        /// <br>Update Note :2024/11/22 陳艶丹</br>
        /// <br>             PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        private bool outputExcelData()
        {
            this._suppYearResultAcs.ExcOrtxtDiv = false; // ADD 2011/03/23
            if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            {
                return true;
            }
            // 開始拠点コード
            this._sectionCodeSt = this._extractSetupFrm.SectionCodeSt;
            // 終了拠点コード
            this._sectionCodeEnd = this._extractSetupFrm.SectionCodeEd;
            // 開始仕入先コード
            this._supplierCdSt = this._extractSetupFrm.SupplierCodeSt;
            // 終了仕入先コード
            this._supplierCdEnd = this._extractSetupFrm.SupplierCodeEd;

            SFCMN00299CA processingDialog = new SFCMN00299CA();

            //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----->>>>>
            // エラーメッセージ
            string errMsg = string.Empty;
            TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj = null;
            int logStatus = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 -----<<<<<
            try
            {
                //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
                // テキスト出力操作ログ登録及び出力時アラートメッセージ表示処理[Excel出力]
                logStatus = TextOutPutWrite((int)OperationCode.ExcelOut, ref textOutPutOprtnHisLogWorkObj, out errMsg);

                // ログ登録異常場合、テキスト出力が実行できない
                if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        Form form = new Form();
                        form.TopMost = true;
                        DialogResult dialogResult = TMsgDisp.Show(
                            form, 
                            emErrorLevel.ERR_LEVEL_STOP, 
                            this.Name,
                            errMsg, 
                            logStatus, 
                            MessageBoxButtons.OK);
                        form.TopMost = false;
                    }
                    // 中止
                    return false;
                }
                //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<
                processingDialog.Title = "抽出処理";
                processingDialog.Message = "現在、データ抽出中です。";
                processingDialog.DispCancelButton = false;
                processingDialog.Show((Form)this.Parent);
                this.Search("SubMain");
            }
            finally
            {
                processingDialog.Dispose();
            }

            if (this._dataSet.OutPutResult.Count == 0 && this._dataSet.AccPayResult.Count == 0)
            {
                // データセットをクリア
                tDateEdit_FinancialYear_Leave(null, null);
                this._suppYearResultCndtn.MainDiv = "Main";
                // ----------UPD 2010/10/27 ----------<<<<<
                //string errorMessage = string.Empty;
                //if (CheckParameters(out errorMessage))
                //    this._suppYearResultAcs.Search(this._suppYearResultCndtn);
                //else
                //{
                //    this._dataSet.MonthResult.Rows.Clear();
                //    this._suppYearResultAcs.SetDataSetBase();
                //}
                if (isSearch)
                {
                    this._suppYearResultAcs.Search(this._suppYearResultCndtn);
                }
                // ----------UPD 2010/10/27 ----------<<<<<
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "条件に合致するデータが存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }

            try
            {
                if (this.ultraGridExcelExport.Export(this.ultraGrid_OutPut, this._extractSetupFrm.SettingFileName) != null)
                {
                    int outputCount = ((DataView)this.ultraGrid_OutPut.DataSource).Count;//ADD 2024/11/29 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応
                    // データセットをクリア
                    tDateEdit_FinancialYear_Leave(null, null);
                    this._suppYearResultCndtn.MainDiv = "Main";
                    // ----------UPD 2010/10/27 ----------<<<<<
                    //string errorMessage = string.Empty;
                    //if (CheckParameters(out errorMessage))
                    //    this._suppYearResultAcs.Search(this._suppYearResultCndtn);
                    //else
                    //{
                    //    this._dataSet.MonthResult.Rows.Clear();
                    //    this._suppYearResultAcs.SetDataSetBase();
                    //}
                    if (isSearch)
                    {
                        this._suppYearResultAcs.Search(this._suppYearResultCndtn);
                    }
                    // ----------UPD 2010/10/27 ----------<<<<<
                    // 成功
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "EXCELデータを出力しました。",
                        -1,
                        MessageBoxButtons.OK);

                    //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----->>>>>
                    // エラーメッセージ
                    errMsg = string.Empty;
                    // 操作履歴登録
                    textOutPutOprtnHisLogWorkObj.LogOperationData = string.Format(CountNumStr, outputCount.ToString()) + textOutPutOprtnHisLogWorkObj.LogOperationData;
                    logStatus = TextOutPutOprtnHisLogAcsObj.Write(this, ref textOutPutOprtnHisLogWorkObj, out errMsg);
                    // ログ登録異常の場合、ログ登録異常メッセージを表示する
                    if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (!string.IsNullOrEmpty(errMsg))
                        {
                            Form form = new Form();
                            form.TopMost = true;
                            DialogResult dialogResult = TMsgDisp.Show(
                                form,
                                emErrorLevel.ERR_LEVEL_STOP,
                                this.Name,
                                errMsg,
                                logStatus,
                                MessageBoxButtons.OK);
                            form.TopMost = false;
                        }
                        // 中止
                        return false;
                    }
                    //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 -----<<<<<
                }
            }
            catch (Exception ex)
            {
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

        //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----->>>>>
        /// <summary>
        /// テキスト出力操作ログおよび出力時アラートメッセージ追加処理
        /// </summary>
        /// <param name="mode">モード「テキスト出力：1　Excel出力：2」</param>
        /// <param name="textOutPutOprtnHisLogWorkObj">登録用対象ワーク</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : テキスト出力操作ログおよび出力時アラートメッセージ追加対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2024/11/22</br>
        /// </remarks>
        private int TextOutPutWrite(int mode, ref TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                string outPutCon = string.Empty;
                textOutPutOprtnHisLogWorkObj = new TextOutPutOprtnHisLogWork();
                // ログデータ対象アセンブリID
                textOutPutOprtnHisLogWorkObj.LogDataObjAssemblyID = CT_SUPPLIER_YEAR_RESULT_PGID;
                // ログデータ対象アセンブリ名称
                textOutPutOprtnHisLogWorkObj.LogDataObjAssemblyNm = AssemblyNm;
                // ログデータ対象起動プログラム名称
                textOutPutOprtnHisLogWorkObj.LogDataObjBootProgramNm = AssemblyNm;
                if (mode == (int)OperationCode.TextOut || mode == (int)OperationCode.ExcelOut)
                {
                    if (mode == (int)OperationCode.TextOut)
                    {
                        // テキスト出力の場合
                        // ログデータ対象処理名:テキスト出力メソッド名
                        textOutPutOprtnHisLogWorkObj.LogDataObjProcNm = MethodNm;
                        // ログオペレーションデータ
                    }
                    else
                    {
                        // Excel出力の場合
                        // ログデータ対象処理名:Excel出力メソッド名
                        textOutPutOprtnHisLogWorkObj.LogDataObjProcNm = MethodNm2;
                    }
                }
                // ログオペレーションデータ
                // 拠点
                string sectionCdSt = this._extractSetupFrm.SectionCodeSt.Trim();
                sectionCdSt = string.IsNullOrEmpty(sectionCdSt) ? StartStr : sectionCdSt;
                string sectionCdEd = this._extractSetupFrm.SectionCodeEd.Trim();
                sectionCdEd = string.IsNullOrEmpty(sectionCdEd) ? EndStr : sectionCdEd;
                // 仕入先
                string supplierCdSt = this._extractSetupFrm.SuppPrtPprCodeSt.ToString();
                supplierCdSt = string.IsNullOrEmpty(supplierCdSt) ? StartStr : supplierCdSt;
                string supplierCdEd = this._extractSetupFrm.SuppPrtPprCodeEd.ToString();
                supplierCdEd = string.IsNullOrEmpty(supplierCdEd) ? EndStr : supplierCdEd;
                // 対象年月
                string checkDate = this._extractSetupFrm.FinancialYear.ToString();
                outPutCon = string.Format(Con, sectionCdSt, sectionCdEd, supplierCdSt, supplierCdEd,
                    checkDate, this._extractSetupFrm.SettingFileName);
                // ログオペレーションデータ
                textOutPutOprtnHisLogWorkObj.LogOperationData = outPutCon;
                status = TextOutPutOprtnHisLogAcsObj.Write(this, ref textOutPutOprtnHisLogWorkObj, out errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

            return status;
        }
        //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 -----<<<<<


        /// <summary>
        /// テキスト出力処理
        /// </summary>
        /// <returns>True:正常; False:異常</returns>
        /// <br>Update Note :2011/02/16 liyp</br>
        /// <br>             テキスト出力機能の場合のみの修正</br>
        /// <br>Update Note :2011/03/23 liyp</br>
        /// <br>             テキスト出力修正</br>
        /// <br>Update Note :2024/11/22 陳艶丹</br>
        /// <br>             PMKOBETSU-4368 2024年PKG格上のログ出力対応</br>
        private bool outputTextData()
        {
            this._suppYearResultAcs.ExcOrtxtDiv = true; // ADD 2011/03/23
            if (this._extractSetupFrm.DResult == DialogResult.Cancel)
            {
                return true;
            }

            // 開始拠点コード
            this._sectionCodeSt = this._extractSetupFrm.SectionCodeSt;
            // 終了拠点コード
            this._sectionCodeEnd = this._extractSetupFrm.SectionCodeEd;
            // 開始仕入先コード
            this._supplierCdSt = this._extractSetupFrm.SupplierCodeSt;
            // 終了仕入先コード
            this._supplierCdEnd = this._extractSetupFrm.SupplierCodeEd;

            SFCMN00299CA processingDialog = new SFCMN00299CA();
            //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
            // エラーメッセージ
            string errMsg = string.Empty;
            TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWorkObj = null;
            int logStatus = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<
            try
            {
                //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ---->>>>>
                // テキスト出力操作ログ登録及び出力時アラートメッセージ表示処理[テキスト出力]
                logStatus = TextOutPutWrite((int)OperationCode.TextOut, ref textOutPutOprtnHisLogWorkObj, out errMsg);

                // ログ登録異常場合、テキスト出力が実行できない
                if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        Form form = new Form();
                        form.TopMost = true;
                        DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                    errMsg, logStatus, MessageBoxButtons.OK);
                        form.TopMost = false;
                    }
                    // 中止
                    return false;
                }
                //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----<<<<<
                processingDialog.Title = "抽出処理";
                processingDialog.Message = "現在、データ抽出中です。";
                processingDialog.DispCancelButton = false;
                processingDialog.Show((Form)this.Parent);
                this.Search("SubMain");
            }
            finally
            {
                processingDialog.Dispose();
            }

            if (this._dataSet.MonthResult.Count == 0 || _monthResultNullFlg)
            {
                _monthResultNullFlg = false;
                // ------------ADD 2010/10/27 ----------------<<<<<
                // データセットをクリア
                tDateEdit_FinancialYear_Leave(null, null);
                this._suppYearResultCndtn.MainDiv = "Main";
                if (isSearch)
                {
                    this._suppYearResultAcs.Search(this._suppYearResultCndtn);
                }
                // ------------ADD 2010/10/27 ---------------->>>>>
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "条件に合致するデータが存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }


            
            // ------------ADD 2010/10/27 ----------------<<<<<
            if (this._dataSet.OutPutResult.Count == 0)
            {
                // データセットをクリア
                tDateEdit_FinancialYear_Leave(null, null);
                this._suppYearResultCndtn.MainDiv = "Main";
                if (isSearch)
                {
                    this._suppYearResultAcs.Search(this._suppYearResultCndtn);
                }
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "条件に合致するデータが存在しません。",
                    -1,
                    MessageBoxButtons.OK);
                return false;
            }
            // ------------ADD 2010/10/27 ----------------<<<<<

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

            DataTable targetTable = this._dataSet.OutPutResult;


            //年月を設定
            int companyBiginMonth = this._companyBeginMonth;
            string[] monthFlg = new string[12];
            for (int ix = 0; ix < 12; ix++)
            {
                int biginMonth = companyBiginMonth + ix;
                if (biginMonth > 12) { biginMonth = biginMonth - 12; }
                monthFlg[ix] = biginMonth.ToString() + "月";
            }
            targetTable.Columns["To_StockPriceTaxExc_1_Month"].Caption = "当期実績・仕入(" + monthFlg[0] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_1_Month"].Caption = "当期実績・返品(" + monthFlg[0] + ")";
            targetTable.Columns["To_StockTotalDiscount_1_Month"].Caption = "当期実績・値引(" + monthFlg[0] + ")";
            targetTable.Columns["To_StockPriceSum_1_Month"].Caption = "当期実績・純仕入(" + monthFlg[0] + ")";

            targetTable.Columns["To_StockPriceTaxExc_2_Month"].Caption = "当期実績・仕入(" + monthFlg[1] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_2_Month"].Caption = "当期実績・返品(" + monthFlg[1] + ")";
            targetTable.Columns["To_StockTotalDiscount_2_Month"].Caption = "当期実績・値引(" + monthFlg[1] + ")";
            targetTable.Columns["To_StockPriceSum_2_Month"].Caption = "当期実績・純仕入(" + monthFlg[1] + ")";

            targetTable.Columns["To_StockPriceTaxExc_3_Month"].Caption = "当期実績・仕入(" + monthFlg[2] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_3_Month"].Caption = "当期実績・返品(" + monthFlg[2] + ")";
            targetTable.Columns["To_StockTotalDiscount_3_Month"].Caption = "当期実績・値引(" + monthFlg[2] + ")";
            targetTable.Columns["To_StockPriceSum_3_Month"].Caption = "当期実績・純仕入(" + monthFlg[2] + ")";

            targetTable.Columns["To_StockPriceTaxExc_4_Month"].Caption = "当期実績・仕入(" + monthFlg[3] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_4_Month"].Caption = "当期実績・返品(" + monthFlg[3] + ")";
            targetTable.Columns["To_StockTotalDiscount_4_Month"].Caption = "当期実績・値引(" + monthFlg[3] + ")";
            targetTable.Columns["To_StockPriceSum_4_Month"].Caption = "当期実績・純仕入(" + monthFlg[3] + ")";

            targetTable.Columns["To_StockPriceTaxExc_5_Month"].Caption = "当期実績・仕入(" + monthFlg[4] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_5_Month"].Caption = "当期実績・返品(" + monthFlg[4] + ")";
            targetTable.Columns["To_StockTotalDiscount_5_Month"].Caption = "当期実績・値引(" + monthFlg[4] + ")";
            targetTable.Columns["To_StockPriceSum_5_Month"].Caption = "当期実績・純仕入(" + monthFlg[4] + ")";

            targetTable.Columns["To_StockPriceTaxExc_6_Month"].Caption = "当期実績・仕入(" + monthFlg[5] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_6_Month"].Caption = "当期実績・返品(" + monthFlg[5] + ")";
            targetTable.Columns["To_StockTotalDiscount_6_Month"].Caption = "当期実績・値引(" + monthFlg[5] + ")";
            targetTable.Columns["To_StockPriceSum_6_Month"].Caption = "当期実績・純仕入(" + monthFlg[5] + ")";

            targetTable.Columns["To_StockPriceTaxExc_7_Month"].Caption = "当期実績・仕入(" + monthFlg[6] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_7_Month"].Caption = "当期実績・返品(" + monthFlg[6] + ")";
            targetTable.Columns["To_StockTotalDiscount_7_Month"].Caption = "当期実績・値引(" + monthFlg[6] + ")";
            targetTable.Columns["To_StockPriceSum_7_Month"].Caption = "当期実績・純仕入(" + monthFlg[6] + ")";

            targetTable.Columns["To_StockPriceTaxExc_8_Month"].Caption = "当期実績・仕入(" + monthFlg[7] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_8_Month"].Caption = "当期実績・返品(" + monthFlg[7] + ")";
            targetTable.Columns["To_StockTotalDiscount_8_Month"].Caption = "当期実績・値引(" + monthFlg[7] + ")";
            targetTable.Columns["To_StockPriceSum_8_Month"].Caption = "当期実績・純仕入(" + monthFlg[7] + ")";

            targetTable.Columns["To_StockPriceTaxExc_9_Month"].Caption = "当期実績・仕入(" + monthFlg[8] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_9_Month"].Caption = "当期実績・返品(" + monthFlg[8] + ")";
            targetTable.Columns["To_StockTotalDiscount_9_Month"].Caption = "当期実績・値引(" + monthFlg[8] + ")";
            targetTable.Columns["To_StockPriceSum_9_Month"].Caption = "当期実績・純仕入(" + monthFlg[8] + ")";

            targetTable.Columns["To_StockPriceTaxExc_10_Month"].Caption = "当期実績・仕入(" + monthFlg[9] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_10_Month"].Caption = "当期実績・返品(" + monthFlg[9] + ")";
            targetTable.Columns["To_StockTotalDiscount_10_Month"].Caption = "当期実績・値引(" + monthFlg[9] + ")";
            targetTable.Columns["To_StockPriceSum_10_Month"].Caption = "当期実績・純仕入(" + monthFlg[9] + ")";

            targetTable.Columns["To_StockPriceTaxExc_11_Month"].Caption = "当期実績・仕入(" + monthFlg[10] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_11_Month"].Caption = "当期実績・返品(" + monthFlg[10] + ")";
            targetTable.Columns["To_StockTotalDiscount_11_Month"].Caption = "当期実績・値引(" + monthFlg[10] + ")";
            targetTable.Columns["To_StockPriceSum_11_Month"].Caption = "当期実績・純仕入(" + monthFlg[10] + ")";

            targetTable.Columns["To_StockPriceTaxExc_12_Month"].Caption = "当期実績・仕入(" + monthFlg[11] + ")";
            targetTable.Columns["To_StockRetGoodsPrice_12_Month"].Caption = "当期実績・返品(" + monthFlg[11] + ")";
            targetTable.Columns["To_StockTotalDiscount_12_Month"].Caption = "当期実績・値引(" + monthFlg[11] + ")";
            targetTable.Columns["To_StockPriceSum_12_Month"].Caption = "当期実績・純仕入(" + monthFlg[11] + ")";

            targetTable.Columns["St_StockPriceTaxExc_1_Month"].Caption = "在庫・仕入(" + monthFlg[0] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_1_Month"].Caption = "在庫・返品(" + monthFlg[0] + ")";
            targetTable.Columns["St_StockTotalDiscount_1_Month"].Caption = "在庫・値引(" + monthFlg[0] + ")";
            targetTable.Columns["St_StockPriceSum_1_Month"].Caption = "在庫・純仕入(" + monthFlg[0] + ")";

            targetTable.Columns["St_StockPriceTaxExc_2_Month"].Caption = "在庫・仕入(" + monthFlg[1] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_2_Month"].Caption = "在庫・返品(" + monthFlg[1] + ")";
            targetTable.Columns["St_StockTotalDiscount_2_Month"].Caption = "在庫・値引(" + monthFlg[1] + ")";
            targetTable.Columns["St_StockPriceSum_2_Month"].Caption = "在庫・純仕入(" + monthFlg[1] + ")";

            targetTable.Columns["St_StockPriceTaxExc_3_Month"].Caption = "在庫・仕入(" + monthFlg[2] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_3_Month"].Caption = "在庫・返品(" + monthFlg[2] + ")";
            targetTable.Columns["St_StockTotalDiscount_3_Month"].Caption = "在庫・値引(" + monthFlg[2] + ")";
            targetTable.Columns["St_StockPriceSum_3_Month"].Caption = "在庫・純仕入(" + monthFlg[2] + ")";

            targetTable.Columns["St_StockPriceTaxExc_4_Month"].Caption = "在庫・仕入(" + monthFlg[3] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_4_Month"].Caption = "在庫・返品(" + monthFlg[3] + ")";
            targetTable.Columns["St_StockTotalDiscount_4_Month"].Caption = "在庫・値引(" + monthFlg[3] + ")";
            targetTable.Columns["St_StockPriceSum_4_Month"].Caption = "在庫・純仕入(" + monthFlg[3] + ")";

            targetTable.Columns["St_StockPriceTaxExc_5_Month"].Caption = "在庫・仕入(" + monthFlg[4] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_5_Month"].Caption = "在庫・返品(" + monthFlg[4] + ")";
            targetTable.Columns["St_StockTotalDiscount_5_Month"].Caption = "在庫・値引(" + monthFlg[4] + ")";
            targetTable.Columns["St_StockPriceSum_5_Month"].Caption = "在庫・純仕入(" + monthFlg[4] + ")";

            targetTable.Columns["St_StockPriceTaxExc_6_Month"].Caption = "在庫・仕入(" + monthFlg[5] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_6_Month"].Caption = "在庫・返品(" + monthFlg[5] + ")";
            targetTable.Columns["St_StockTotalDiscount_6_Month"].Caption = "在庫・値引(" + monthFlg[5] + ")";
            targetTable.Columns["St_StockPriceSum_6_Month"].Caption = "在庫・純仕入(" + monthFlg[5] + ")";

            targetTable.Columns["St_StockPriceTaxExc_7_Month"].Caption = "在庫・仕入(" + monthFlg[6] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_7_Month"].Caption = "在庫・返品(" + monthFlg[6] + ")";
            targetTable.Columns["St_StockTotalDiscount_7_Month"].Caption = "在庫・値引(" + monthFlg[6] + ")";
            targetTable.Columns["St_StockPriceSum_7_Month"].Caption = "在庫・純仕入(" + monthFlg[6] + ")";

            targetTable.Columns["St_StockPriceTaxExc_8_Month"].Caption = "在庫・仕入(" + monthFlg[7] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_8_Month"].Caption = "在庫・返品(" + monthFlg[7] + ")";
            targetTable.Columns["St_StockTotalDiscount_8_Month"].Caption = "在庫・値引(" + monthFlg[7] + ")";
            targetTable.Columns["St_StockPriceSum_8_Month"].Caption = "在庫・純仕入(" + monthFlg[7] + ")";

            targetTable.Columns["St_StockPriceTaxExc_9_Month"].Caption = "在庫・仕入(" + monthFlg[8] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_9_Month"].Caption = "在庫・返品(" + monthFlg[8] + ")";
            targetTable.Columns["St_StockTotalDiscount_9_Month"].Caption = "在庫・値引(" + monthFlg[8] + ")";
            targetTable.Columns["St_StockPriceSum_9_Month"].Caption = "在庫・純仕入(" + monthFlg[8] + ")";

            targetTable.Columns["St_StockPriceTaxExc_10_Month"].Caption = "在庫・仕入(" + monthFlg[9] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_10_Month"].Caption = "在庫・返品(" + monthFlg[9] + ")";
            targetTable.Columns["St_StockTotalDiscount_10_Month"].Caption = "在庫・値引(" + monthFlg[9] + ")";
            targetTable.Columns["St_StockPriceSum_10_Month"].Caption = "在庫・純仕入(" + monthFlg[9] + ")";

            targetTable.Columns["St_StockPriceTaxExc_11_Month"].Caption = "在庫・仕入(" + monthFlg[10] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_11_Month"].Caption = "在庫・返品(" + monthFlg[10] + ")";
            targetTable.Columns["St_StockTotalDiscount_11_Month"].Caption = "在庫・値引(" + monthFlg[10] + ")";
            targetTable.Columns["St_StockPriceSum_11_Month"].Caption = "在庫・純仕入(" + monthFlg[10] + ")";

            targetTable.Columns["St_StockPriceTaxExc_12_Month"].Caption = "在庫・仕入(" + monthFlg[11] + ")";
            targetTable.Columns["St_StockRetGoodsPrice_12_Month"].Caption = "在庫・返品(" + monthFlg[11] + ")";
            targetTable.Columns["St_StockTotalDiscount_12_Month"].Caption = "在庫・値引(" + monthFlg[11] + ")";
            targetTable.Columns["St_StockPriceSum_12_Month"].Caption = "在庫・純仕入(" + monthFlg[11] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_1_Month"].Caption = "取寄・仕入(" + monthFlg[0] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_1_Month"].Caption = "取寄・返品(" + monthFlg[0] + ")";
            targetTable.Columns["Or_StockTotalDiscount_1_Month"].Caption = "取寄・値引(" + monthFlg[0] + ")";
            targetTable.Columns["Or_StockPriceSum_1_Month"].Caption = "取寄・純仕入(" + monthFlg[0] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_2_Month"].Caption = "取寄・仕入(" + monthFlg[1] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_2_Month"].Caption = "取寄・返品(" + monthFlg[1] + ")";
            targetTable.Columns["Or_StockTotalDiscount_2_Month"].Caption = "取寄・値引(" + monthFlg[1] + ")";
            targetTable.Columns["Or_StockPriceSum_2_Month"].Caption = "取寄・純仕入(" + monthFlg[1] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_3_Month"].Caption = "取寄・仕入(" + monthFlg[2] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_3_Month"].Caption = "取寄・返品(" + monthFlg[2] + ")";
            targetTable.Columns["Or_StockTotalDiscount_3_Month"].Caption = "取寄・値引(" + monthFlg[2] + ")";
            targetTable.Columns["Or_StockPriceSum_3_Month"].Caption = "取寄・純仕入(" + monthFlg[2] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_4_Month"].Caption = "取寄・仕入(" + monthFlg[3] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_4_Month"].Caption = "取寄・返品(" + monthFlg[3] + ")";
            targetTable.Columns["Or_StockTotalDiscount_4_Month"].Caption = "取寄・値引(" + monthFlg[3] + ")";
            targetTable.Columns["Or_StockPriceSum_4_Month"].Caption = "取寄・純仕入(" + monthFlg[3] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_5_Month"].Caption = "取寄・仕入(" + monthFlg[4] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_5_Month"].Caption = "取寄・返品(" + monthFlg[4] + ")";
            targetTable.Columns["Or_StockTotalDiscount_5_Month"].Caption = "取寄・値引(" + monthFlg[4] + ")";
            targetTable.Columns["Or_StockPriceSum_5_Month"].Caption = "取寄・純仕入(" + monthFlg[4] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_6_Month"].Caption = "取寄・仕入(" + monthFlg[5] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_6_Month"].Caption = "取寄・返品(" + monthFlg[5] + ")";
            targetTable.Columns["Or_StockTotalDiscount_6_Month"].Caption = "取寄・値引(" + monthFlg[5] + ")";
            targetTable.Columns["Or_StockPriceSum_6_Month"].Caption = "取寄・純仕入(" + monthFlg[5] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_7_Month"].Caption = "取寄・仕入(" + monthFlg[6] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_7_Month"].Caption = "取寄・返品(" + monthFlg[6] + ")";
            targetTable.Columns["Or_StockTotalDiscount_7_Month"].Caption = "取寄・値引(" + monthFlg[6] + ")";
            targetTable.Columns["Or_StockPriceSum_7_Month"].Caption = "取寄・純仕入(" + monthFlg[6] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_8_Month"].Caption = "取寄・仕入(" + monthFlg[7] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_8_Month"].Caption = "取寄・返品(" + monthFlg[7] + ")";
            targetTable.Columns["Or_StockTotalDiscount_8_Month"].Caption = "取寄・値引(" + monthFlg[7] + ")";
            targetTable.Columns["Or_StockPriceSum_8_Month"].Caption = "取寄・純仕入(" + monthFlg[7] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_9_Month"].Caption = "取寄・仕入(" + monthFlg[8] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_9_Month"].Caption = "取寄・返品(" + monthFlg[8] + ")";
            targetTable.Columns["Or_StockTotalDiscount_9_Month"].Caption = "取寄・値引(" + monthFlg[8] + ")";
            targetTable.Columns["Or_StockPriceSum_9_Month"].Caption = "取寄・純仕入(" + monthFlg[8] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_10_Month"].Caption = "取寄・仕入(" + monthFlg[9] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_10_Month"].Caption = "取寄・返品(" + monthFlg[9] + ")";
            targetTable.Columns["Or_StockTotalDiscount_10_Month"].Caption = "取寄・値引(" + monthFlg[9] + ")";
            targetTable.Columns["Or_StockPriceSum_10_Month"].Caption = "取寄・純仕入(" + monthFlg[9] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_11_Month"].Caption = "取寄・仕入(" + monthFlg[10] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_11_Month"].Caption = "取寄・返品(" + monthFlg[10] + ")";
            targetTable.Columns["Or_StockTotalDiscount_11_Month"].Caption = "取寄・値引(" + monthFlg[10] + ")";
            targetTable.Columns["Or_StockPriceSum_11_Month"].Caption = "取寄・純仕入(" + monthFlg[10] + ")";

            targetTable.Columns["Or_StockPriceTaxExc_12_Month"].Caption = "取寄・仕入(" + monthFlg[11] + ")";
            targetTable.Columns["Or_StockRetGoodsPrice_12_Month"].Caption = "取寄・返品(" + monthFlg[11] + ")";
            targetTable.Columns["Or_StockTotalDiscount_12_Month"].Caption = "取寄・値引(" + monthFlg[11] + ")";
            targetTable.Columns["Or_StockPriceSum_12_Month"].Caption = "取寄・純仕入(" + monthFlg[11] + ")";
            // ---------ADD 2010/09/08----------->>>>>
            targetTable.Columns["StockSectionCd"].Caption = "拠点";
            targetTable.Columns["SupplierCd"].Caption = "仕入先";
            targetTable.Columns["SupplierNm"].Caption = "仕入先名";
            // ---------ADD 2010/09/08-----------<<<<<
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.ultraGrid_OutPut.DisplayLayout.Bands[0].Columns;
            int dispOrder;
            string columnName;
            for (int i = 0; i < Columns.Count; i++)
            {
                // ---------ADD 2010/09/08----------->>>>>
                if (Columns[i].Header.Caption == "拠点名称")
                {
                    Columns[i].Hidden = true;
                }
                // ---------ADD 2010/09/08-----------<<<<<

                if (Columns[i].Hidden == false)
                {
                    dispOrder = Columns[i].Header.VisiblePosition;
                    columnName = targetTable.Columns[Columns[i].Index].ColumnName;
                    sortList.Add(dispOrder, columnName);
                }
                Columns[i].Format = ""; // ADD 2011/02/16
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
            tw.DataSource = this.ultraGrid_OutPut.DataSource;

            # region [フォーマットリスト]

            Dictionary<string, string> formatList = new Dictionary<string, string>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.ultraGrid_OutPut.DisplayLayout.Bands[0].Columns)
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
            InitializeGrid(this.uGrid_Result.DisplayLayout.Bands[0].Columns, true);
            if (status == 9)// 異常終了
            {
                // 出力失敗
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "ファイルへの出力に失敗しました。", -1, MessageBoxButtons.OK);
                return false;
            }
            else
            {
                // データセットをクリア
                tDateEdit_FinancialYear_Leave(null, null);
                this._suppYearResultCndtn.MainDiv = "Main";
                // -----------UPD 2010/10/27-------------<<<<<
                //string errorMessage = string.Empty;
                //if (CheckParameters(out errorMessage))
                //    this._suppYearResultAcs.Search(this._suppYearResultCndtn);
                //else
                //{
                //    this._dataSet.MonthResult.Rows.Clear();
                //    this._suppYearResultAcs.SetDataSetBase();
                //}
                if (isSearch)
                {
                    this._suppYearResultAcs.Search(this._suppYearResultCndtn);
                }
                // -----------UPD 2010/10/27------------->>>>>
                // 出力成功
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    outputCount.ToString() + "行のデータをファイルへ出力しました。", -1, MessageBoxButtons.OK);

                //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 ----->>>>>
                // エラーメッセージ
                errMsg = string.Empty;
                // 操作履歴登録
                textOutPutOprtnHisLogWorkObj.LogOperationData = string.Format(CountNumStr, outputCount.ToString()) + textOutPutOprtnHisLogWorkObj.LogOperationData;
                logStatus = TextOutPutOprtnHisLogAcsObj.Write(this, ref textOutPutOprtnHisLogWorkObj, out errMsg);
                // ログ登録異常の場合、ログ登録異常メッセージを表示する
                if (logStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        Form form = new Form();
                        form.TopMost = true;
                        DialogResult dialogResult = TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                    errMsg, logStatus, MessageBoxButtons.OK);
                        form.TopMost = false;
                    }
                    // 中止
                    return false;
                }
                //----- ADD 2024/11/22 陳艶丹 PMKOBETSU-4368 2024年PKG格上のログ出力対応 -----<<<<<

                return true;
            }
        }
        // ------------ ADD 2010/10/09 ---------------------------------------------------------<<<<<

        #endregion

        #region ■オプション情報制御処理

        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オプション情報制御処理。</br>
        /// <br>Programmer : 杜志剛</br>
        /// <br>Date       : 2010/07/21</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
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
                // テキスト出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.Visible = true;
                // EXCEL出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.Visible = true;
                //設定画面のテキスト出力タブを表示する
                this._userSetupFrm.uTabControlSet(true);
            }
            //テキスト出力オプションが無効の場合
            else
            {
                // テキスト出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.Visible = false;
                // EXCEL出力
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.Visible = false;
                //設定画面のテキスト出力タブを表示する
                this._userSetupFrm.uTabControlSet(false);
            }

            // 操作権限の制御
            if (!OpeAuthDictionary[OperationCode.TextOut])
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.Visible = false;
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Text"].SharedProps.Shortcut = Shortcut.None;
            }
            if (!OpeAuthDictionary[OperationCode.ExcelOut])
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.Visible = false;
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Excel"].SharedProps.Shortcut = Shortcut.None;
            }
            if ((!OpeAuthDictionary[OperationCode.TextOut]) && (!OpeAuthDictionary[OperationCode.ExcelOut])) // ADD 2010/08/23
            {
                //設定画面のテキスト出力タブを表示する
                this._userSetupFrm.uTabControlSet(false); // ADD 2010/08/23
            }
            #endregion

            // --- ADD 2012/09/18 ---------->>>>>
            #region ●仕入総括機能（個別）オプション
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._optSuppSumEnable = true;
            }
            else
            {
                this._optSuppSumEnable = false;
            }
            #endregion
            // --- ADD 2012/09/18 ----------<<<<<

        }

        /// <summary>操作権限の制御オブジェクト</summary>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateReferenceOperationAuthority("PMKOU04110U", this);
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
        #endregion ■オプション情報制御処理

        #region ■プロパティ
        /// <summary>
        /// テキスト出力オプション情報
        /// </summary>
        public int Opt_TextOutput
        {
            get { return this._opt_TextOutput; }
            set { this._opt_TextOutput = value; }
        }
        #endregion

        # region ■[グリッドカラム情報 保存・復元]
        /// <summary>
        /// グリッドカラム情報の保存
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        private void SaveGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, out List<ColumnInfo> settingList)
        {
            settingList = new List<ColumnInfo>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                settingList.Add(new ColumnInfo(ultraGridColumn.Key, ultraGridColumn.Header.VisiblePosition, ultraGridColumn.Hidden, ultraGridColumn.Width, ultraGridColumn.Header.Fixed));
            }
        }
        /// <summary>
        /// グリッドカラム情報の読み込み
        /// </summary>
        /// <param name="targetGrid">グリッド</param>
        /// <param name="settingList"></param>
        private void LoadGridColumnsSetting(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, List<ColumnInfo> settingList)
        {
            if (settingList == null || settingList.Count == 0) return;

            targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            foreach (ColumnInfo columnInfo in settingList)
            {
                Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                ultraGridColumn.Header.VisiblePosition = columnInfo.VisiblePosition;
                ultraGridColumn.Hidden = columnInfo.Hidden;
                ultraGridColumn.Header.Fixed = columnInfo.ColumnFixed;
                ultraGridColumn.Width = columnInfo.Width;
            }
            this._suppYearResultCndtn.MainDiv = "Main";
            this._suppYearResultAcs.Search(this._suppYearResultCndtn);
        }
        # endregion

        # region ■[ColumnInfo]
        /// <summary>
        /// ColumnInfo
        /// </summary>
        [Serializable]
        public struct ColumnInfo
        {
            /// <summary>列名</summary>
            private string _columnName;
            /// <summary>並び順</summary>
            private int _visiblePosition;
            /// <summary>非表示フラグ</summary>
            private bool _hidden;
            /// <summary>幅</summary>
            private int _width;
            /// <summary>固定フラグ</summary>
            private bool _columnFixed;
            /// <summary>
            /// 列名
            /// </summary>
            public string ColumnName
            {
                get { return _columnName; }
                set { _columnName = value; }
            }
            /// <summary>
            /// 並び順
            /// </summary>
            public int VisiblePosition
            {
                get { return _visiblePosition; }
                set { _visiblePosition = value; }
            }
            /// <summary>
            /// 非表示フラグ
            /// </summary>
            public bool Hidden
            {
                get { return _hidden; }
                set { _hidden = value; }
            }
            /// <summary>
            /// 幅
            /// </summary>
            public int Width
            {
                get { return _width; }
                set { _width = value; }
            }
            /// <summary>
            /// 固定フラグ
            /// </summary>
            public bool ColumnFixed
            {
                get { return _columnFixed; }
                set { _columnFixed = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="columnName">列名</param>
            /// <param name="visiblePosition">並び順</param>
            /// <param name="hidden">非表示フラグ</param>
            /// <param name="width">幅</param>
            /// <param name="columnFixed">固定フラグ</param>
            public ColumnInfo(string columnName, int visiblePosition, bool hidden, int width, bool columnFixed)
            {
                _columnName = columnName;
                _visiblePosition = visiblePosition;
                _hidden = hidden;
                _width = width;
                _columnFixed = columnFixed;
            }
        }
        # endregion

        /// <summary>
        /// ポップアップ画面からのパラメーターの処理
        /// </summary>
        /// <param name="m">Message</param>
        /// <br>Note       : ポップアップ画面からのパラメーターの処理を行う</br>
        /// <br>Programmer : 杜志剛</br>
        /// <br>Date       : 2010/07/20</br>
        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_COPYDATA:
                    int year = m.LParam.ToInt32();
                    // 会計年度計算
                    if (year == this._currentFinancialYear ||
                        year == this._currentFinancialYear - 1)
                    {
                        this._financialYear = year;
                    }
                    else if (year > this._currentFinancialYear)
                    {
                        // 現年度へ修正
                        this.tDateEdit_FinancialYear.SetLongDate(this._currentFinancialYear * 10000);

                        // メッセージ表示
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                            CT_CANNOT_INPUT_FOLLOWING, -1, MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        // 現年度へ修正
                        this.tDateEdit_FinancialYear.SetLongDate(this._currentFinancialYear * 10000);

                        // メッセージ表示
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                            CT_CAN_INPUT_ONLY_TWICE, -1, MessageBoxButtons.OK);

                        return;
                    }

                    // 会計年度開始日を取得
                    DateTime paramDate;
                    if (!this._suppYearResultAcs.GetCompanyBeginDate(this._enterpriseCode, this._financialYear, out paramDate))
                    {
                        return;
                    }
                    else
                    {
                        // 日付設定を再取得
                        this._suppYearResultAcs.GetDateParams(this._financialYear, paramDate, this._enterpriseCode);
                    }
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }

        }

        // --- ADD 2010/07/20--------------------------------<<<<<
    }
}